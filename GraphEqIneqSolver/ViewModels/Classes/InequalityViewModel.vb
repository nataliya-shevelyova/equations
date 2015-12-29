Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Utilities.Classes
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.ViewModels.Interfaces
Imports GraphEqIneqSolver.Utilities
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports GraphEqIneqSolver.Inequalities.Interfaces
Imports GraphEqIneqSolver.Functions.Classes.Wrappers
Imports GraphEqIneqSolver.Functions.Interfaces
Imports ZedGraph

Namespace ViewModels.Classes

	Public Class InequalityViewModel
		Implements IViewModel

		Private ReadOnly _inequality As IInequality
		Private ReadOnly _graphControl As ZedGraphControl
		Private ReadOnly _renderEngine As IRenderEngine

		Public Sub New(ByVal graphControl As ZedGraphControl, ByVal inequality As IInequality)
			_inequality = inequality
			_graphControl = graphControl
			_renderEngine = New RenderEngine(graphControl)
		End Sub

		Public Sub Render() Implements IViewModel.Render

			Try

				Dim xMin = _graphControl.GraphPane.XAxis.Scale.Min
				Dim xMax = _graphControl.GraphPane.XAxis.Scale.Max
				Dim xUnitsPerPixel = (xMax - xMin) / _graphControl.ChartWidth

				xMax += Screens.Width * xUnitsPerPixel
				xMin -= Screens.Width * xUnitsPerPixel

				Dim xRange = New XRange(xMin, xMax)
				Dim ranges = _inequality.AllRangeSolutions(xRange)

				Dim inequalityWrapper = New InequalityFunctionWrapper(_inequality.LeftPart, _inequality.RightPart, _inequality.InequalityType)
				Dim points = (From r In ranges Select r.Min).Concat(From r In ranges Select r.Max).Concat(_inequality.PrimaryRoots).ToList.AsReadOnly()
				Dim solutionRegion As IFunction
				solutionRegion = New AppendPointsFunctionWrapper(inequalityWrapper, points)

				If Not _inequality.TextSolutions()(0) = _inequality.SolutionAbsent()(0) Then
					_renderEngine.FillRegion(solutionRegion, _inequality.InequalityType, "Множина розв'яків", Color.FromArgb(160, Color.Magenta), xRange)
				End If
				Dim wrapped = New ValueRangeFunctionWrapper(_inequality.LeftPart, ranges.Invert(xRange).ExcludePoints)
                _renderEngine.PlotFunction(wrapped, "Графік лівої частини нерівності за межами розв'зків", Color.Red, xRange, 2.5)
                _renderEngine.PlotFunction(_inequality.RightPart, "Графік правої частини нерівності", Color.Blue, xRange, 2.5)

			Catch
			End Try

		End Sub

		Public Function GetSolutions() As ReadOnlyCollection(Of String) Implements IViewModel.GetSolutions
			Return _inequality.TextSolutions
		End Function

		Public Function CalculateViewRange() As ViewRange Implements IViewModel.CalculateViewRange
			Return _inequality.CalculateViewRange(_graphControl)
		End Function

		Public Function ResolveTangentialLines(ByVal point As PointF?, Optional ByVal useDash As Boolean = False) As ReadOnlyCollection(Of ILine) Implements IViewModel.ResolveTangentialLines

			Dim range = New XRange(_graphControl.GraphPane.XAxis.Scale.Min, _graphControl.GraphPane.XAxis.Scale.Max)
			Dim line = _inequality.LeftPart.ResolveTangentialLine(range, point, useDash)

			Return (From t In New ILine() {line} Where Not t Is Nothing).ToList.AsReadOnly

		End Function

	End Class

End Namespace