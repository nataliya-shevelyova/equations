Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Utilities.Classes
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.ViewModels.Interfaces
Imports GraphEqIneqSolver.Equations.Interfaces
Imports GraphEqIneqSolver.Utilities
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports ZedGraph

Namespace ViewModels.Classes
	Public Class EquationViewModel
		Implements IViewModel

		Private ReadOnly _equation As IEquation
		Private ReadOnly _graphControl As ZedGraphControl
		Private ReadOnly _renderEngine As IRenderEngine

		Sub New(ByVal graphControl As ZedGraphControl, ByVal equation As IEquation)
			_equation = equation
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

                _renderEngine.PlotFunction(_equation.LeftPart, "Графік лівої частини рівняння", Color.Red, xRange)
                _renderEngine.PlotFunction(_equation.RightPart, "Графік правої частини рівняння", Color.Blue, xRange)

			Catch
			End Try

		End Sub

		Public Function GetSolutions() As ReadOnlyCollection(Of String) Implements IViewModel.GetSolutions
			Return _equation.TextSolutions
		End Function

		Public Function CalculateViewRange() As ViewRange Implements IViewModel.CalculateViewRange
			Return _equation.CalculateViewRange(_graphControl)
		End Function

		Public Function ResolveTangentialLines(ByVal point As PointF?, Optional ByVal useDash As Boolean = False) As ReadOnlyCollection(Of ILine) Implements IViewModel.ResolveTangentialLines

			Dim range = New XRange(_graphControl.GraphPane.XAxis.Scale.Min, _graphControl.GraphPane.XAxis.Scale.Max)
			Dim line = _equation.LeftPart.ResolveTangentialLine(range, point, useDash)

			Return (From t In New ILine() {line} Where Not t Is Nothing).ToList.AsReadOnly

		End Function
	End Class
End Namespace