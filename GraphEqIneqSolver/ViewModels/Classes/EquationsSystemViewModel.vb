Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Classes
Imports GraphEqIneqSolver.ViewModels.Interfaces
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Utilities
Imports GraphEqIneqSolver.Functions.Classes.Wrappers
Imports GraphEqIneqSolver.Equations.Classes.Wrappers
Imports ZedGraph

Namespace ViewModels.Classes

	Public Class EquationsSystemViewModel
		Implements IViewModel

		Private ReadOnly _equation1 As SystemEquationWrapper
		Private ReadOnly _equation2 As SystemEquationWrapper
		Private ReadOnly _graphControl As ZedGraphControl
		Private ReadOnly _renderEngine As IRenderEngine

		Sub New(ByVal graphControl As ZedGraphControl, ByVal equation1 As SystemEquationWrapper, ByVal equation2 As SystemEquationWrapper)
			_graphControl = graphControl
			_equation1 = equation1
			_equation2 = equation2
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

				Dim func1 = New SubFunctionWrapper(_equation1.LeftPart, _equation1.RightPart)
				Dim func2 = New SubFunctionWrapper(_equation2.LeftPart, _equation2.RightPart)

                _renderEngine.PlotFunction(func1, "Графік першого рівняння", Color.Red, xRange)
                _renderEngine.PlotFunction(func2, "Графік другого рівняння", Color.Blue, xRange)

			Catch
			End Try

		End Sub

		Public Function GetSolutions() As ReadOnlyCollection(Of String) Implements IViewModel.GetSolutions
			Return New List(Of String)().AsReadOnly()
		End Function

		Public Function CalculateViewRange() As ViewRange Implements IViewModel.CalculateViewRange
			Dim func1 = New SubFunctionWrapper(_equation1.LeftPart, _equation1.RightPart)
			Dim func2 = New SubFunctionWrapper(_equation2.LeftPart, _equation2.RightPart)
			Return New IViewRangeProvider() {func1, func2}.CalculateViewRange(_graphControl)
		End Function

		Public Function ResolveTangentialLines(ByVal point As PointF?, Optional ByVal useDash As Boolean = False) As ReadOnlyCollection(Of ILine) Implements IViewModel.ResolveTangentialLines

			If point Is Nothing Then Return New List(Of ILine)().AsReadOnly()

			Dim func1 = New SubFunctionWrapper(_equation1.LeftPart, _equation1.RightPart)
			Dim func2 = New SubFunctionWrapper(_equation2.LeftPart, _equation2.RightPart)

			Dim x = point.Value.X
			Dim y = point.Value.Y
			Dim dy1 = Math.Abs(y - func1.GetY(x))
			Dim dy2 = Math.Abs(y - func2.GetY(x))

			Dim func = func1
			If dy2 < dy1 Then func = func2

			Dim range = New XRange(_graphControl.GraphPane.XAxis.Scale.Min, _graphControl.GraphPane.XAxis.Scale.Max)
			Dim line = func.ResolveTangentialLine(range, point, useDash)

			Return (From t In New ILine() {line} Where Not t Is Nothing).ToList.AsReadOnly

		End Function
	End Class

End Namespace