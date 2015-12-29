Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Classes
Imports GraphEqIneqSolver.ViewModels.Interfaces
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers
Imports GraphEqIneqSolver.Utilities
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Functions.Classes.Wrappers
Imports ZedGraph

Namespace ViewModels.Classes
	Public Class InequalitiesSystemViewModel
		Implements IViewModel

		Private ReadOnly _inequality1 As SystemInequalityWrapper
		Private ReadOnly _inequality2 As SystemInequalityWrapper
		Private ReadOnly _graphControl As ZedGraphControl
		Private ReadOnly _renderEngine As IRenderEngine

		Sub New(ByVal graphControl As ZedGraphControl, ByVal inequality1 As SystemInequalityWrapper, ByVal inequality2 As SystemInequalityWrapper)
			_graphControl = graphControl
			_inequality1 = inequality1
			_inequality2 = inequality2
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

				Dim func1 = New SubFunctionWrapper(_inequality1.LeftPart, _inequality1.RightPart)
				Dim func2 = New SubFunctionWrapper(_inequality2.LeftPart, _inequality2.RightPart)

				_renderEngine.FillRegion(func1, _inequality1.InequalityType, Nothing, Color.FromArgb(160, Color.Red), xRange, True)
				_renderEngine.FillRegion(func2, _inequality2.InequalityType, Nothing, Color.FromArgb(160, Color.Blue), xRange, True)
                _renderEngine.PlotFunction(New ConstFunction(Double.NaN), "Множина розв'язків", Color.FromArgb(255, 227, 104, 164), xRange, 10)
                _renderEngine.PlotFunction(New ConstFunction(Double.NaN), "Графік першої нерівністі за межами розв'язків", Color.FromArgb(255, 255, 164, 164), xRange, 10)
                _renderEngine.PlotFunction(New ConstFunction(Double.NaN), "Графік другої нерівністі за межами розв'язків", Color.FromArgb(255, 164, 164, 255), xRange, 10)

			Catch
			End Try

		End Sub

		Public Function GetSolutions() As ReadOnlyCollection(Of String) Implements IViewModel.GetSolutions
			Return New List(Of String)().AsReadOnly()
		End Function

		Public Function CalculateViewRange() As ViewRange Implements IViewModel.CalculateViewRange
			Dim func1 = New SubFunctionWrapper(_inequality1.LeftPart, _inequality1.RightPart)
			Dim func2 = New SubFunctionWrapper(_inequality2.LeftPart, _inequality2.RightPart)
			Return New IViewRangeProvider() {func1, func2}.CalculateViewRange(_graphControl)
		End Function

		Public Function ResolveTangentialLines(ByVal point As PointF?, Optional ByVal useDash As Boolean = False) As ReadOnlyCollection(Of ILine) Implements IViewModel.ResolveTangentialLines

			If point Is Nothing Then Return New List(Of ILine)().AsReadOnly()

			Dim func1 = New SubFunctionWrapper(_inequality1.LeftPart, _inequality1.RightPart)
			Dim func2 = New SubFunctionWrapper(_inequality2.LeftPart, _inequality2.RightPart)

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