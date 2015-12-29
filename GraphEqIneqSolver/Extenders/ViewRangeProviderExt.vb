Imports System.Runtime.CompilerServices
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports ZedGraph

Namespace Extenders
	Public Module ViewRangeProviderExt

		<Extension()>
		Public Function CalculateViewRange(ByVal providers As IEnumerable(Of IViewRangeProvider), ByVal graphControl As ZedGraphControl) As ViewRange

			' Точки х, які повинні буди присутніми на графіку
			Dim xPoints = (From x In (From t In providers Select t.XViewPoints).SelectManyEx() Where Not x.IsNaN And Not x.IsInfinity).ToList.AsReadOnly
			If Not xPoints.Any Then xPoints = New Double() {0}.ToList.AsReadOnly

			' Точки y, які повинні буди присутніми на графіку
			Dim yPoints = (From y In (From t In providers Select t.YViewPoints).SelectManyEx() Where Not y.IsNaN And Not y.IsInfinity).ToList.AsReadOnly
			If Not yPoints.Any Then yPoints = New Double() {-10, 10}.ToList.AsReadOnly

			' Розрахунок видимої частини таким чином, щоб одниниця по вертикалі візуально дорівнювала одиниці по горізонталі
			Dim xMin = xPoints.Min()
			Dim xMax = xPoints.Max()
			Dim yMin = yPoints.Min()
			Dim yMax = yPoints.Max()
			Dim viewAspect = graphControl.ChartHeight / graphControl.ChartWidth
			Dim range = Math.Max((xMax - xMin) * viewAspect, yMax - yMin)
			If range.IsZero Then range = 1.0
			Dim xRangeDiv2 = range / viewAspect * 0.6
			Dim yRangeDiv2 = range * 0.6
			Dim xCenter = (xMax + xMin) / 2
			Dim yCenter = (yMax + yMin) / 2

			Return New ViewRange(xCenter - xRangeDiv2, xCenter + xRangeDiv2, yCenter - yRangeDiv2, yCenter + yRangeDiv2)

		End Function

		<Extension()>
		Public Function CalculateViewRange(ByVal provider As IViewRangeProvider, ByVal graphControl As ZedGraphControl) As ViewRange
			Return New IViewRangeProvider() {provider}.CalculateViewRange(graphControl)
		End Function

	End Module
End Namespace