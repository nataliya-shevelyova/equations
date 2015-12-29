Imports GraphEqIneqSolver.Utilities.Interfaces
Imports ZedGraph

Namespace Utilities.Classes

	Public Class Line
		Implements ILine

		Private ReadOnly _a As Double
		Private ReadOnly _b As Double
		Private ReadOnly _x As Double
		Private ReadOnly _isGrayed As Boolean

		Sub New(ByVal x As Double, ByVal a As Double, ByVal b As Double, Optional ByVal isGrayed As Boolean = False)
			_a = a
			_b = b
			_x = x
			_isGrayed = isGrayed
		End Sub

		Public Sub Plot(pane As GraphPane) Implements ILine.Plot

			Dim xPoints(1) As Double
			Dim yPoints(1) As Double

			Dim width = pane.XAxis.Scale.Max - pane.XAxis.Scale.Min

			xPoints(0) = pane.XAxis.Scale.Min - width
			xPoints(1) = pane.XAxis.Scale.Max + width

			yPoints(0) = _a * (xPoints(0) - _x) + _b
			yPoints(1) = _a * (xPoints(1) - _x) + _b

			Dim yMin = pane.YAxis.Scale.Min
			Dim yMax = pane.YAxis.Scale.Max
			Dim height = yMax - yMin

			If yPoints(0) > yMax + height Then
				yPoints(0) = yMax
				xPoints(0) = (yPoints(0) - _b) / _a + _x
			ElseIf yPoints(0) < yMin - height Then
				yPoints(0) = yMin
				xPoints(0) = (yPoints(0) - _b) / _a + _x
			End If
			If yPoints(1) > yMax + height Then
				yPoints(1) = yMax
				xPoints(1) = (yPoints(1) - _b) / _a + _x
			ElseIf yPoints(1) < yMin - height Then
				yPoints(1) = yMin
				xPoints(1) = (yPoints(1) - _b) / _a + _x
			End If

			Dim line = pane.AddCurve(String.Empty, xPoints, yPoints, Color.DimGray)

			line.Symbol.IsVisible = False

			If _isGrayed Then
				line.Color = Color.DimGray
			Else
				line.Line.Width = 2
			End If

		End Sub

	End Class

End Namespace