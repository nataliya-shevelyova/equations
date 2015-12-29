Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices
Imports GraphEqIneqSolver.Utilities.Classes
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Extenders

	Public Module FunctionExt

		<Extension()>
		Public Function ResolveTangentialLine(ByVal func As IFunction, ByVal xRange As XRange, ByVal point As PointF?, Optional ByVal useDash As Boolean = False) As ILine

			If point Is Nothing Then Return Nothing
			If func Is Nothing Then Return Nothing

			Dim x = point.Value.X

			Dim dX = xRange.Size / 1000000.0
			Dim x1 = x - dX / 2
			Dim x2 = x + dX / 2

			Dim y1 = func.GetY(x1)
			Dim y2 = func.GetY(x2)
			Dim y = func.GetY(x)

			Dim dY = y2 - y1

			If y.IsNaN Or y1.IsNaN Or y2.IsNaN Or y.IsInfinity Or y1.IsInfinity Or y2.IsInfinity Then
				Return Nothing
			End If

			Return New Line(x, dY / dX, y, useDash)

		End Function

		<Extension()>
		Public Function MakeRanges(ByVal func As IFunction, ByVal ParamArray xRanges() As XRange) As ReadOnlyCollection(Of XRange)
			Return xRanges.Distinct.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function MakeRange(ByVal func As IFunction, ByVal l As Double, ByVal r As Double) As ReadOnlyCollection(Of XRange)
			Return func.MakeRanges(New XRange(Math.Min(l, r), Math.Max(l, r)))
		End Function

		<Extension()>
		Public Function MakeYViewPoints(ByVal func As IFunction, ByVal ParamArray points() As Double) As ReadOnlyCollection(Of Double)
			Return func.MakeYViewPointsFromXPoints().Concat(points).Distinct(New DoubleComparer).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function MakeYViewPointsFromXPoints(ByVal func As IFunction, ByVal ParamArray points() As Double) As ReadOnlyCollection(Of Double)

			Dim xPoints = func.XViewPoints.Concat(points)
			If Not xPoints.Any Then Return New List(Of Double)().AsReadOnly
			Dim ranges = func.GetRanges(New XRange(xPoints.Min(), xPoints.Max()))
			Dim res = (From y In (From x In xPoints Select func.GetY(x)) _
			 .Concat(From r In ranges Where xPoints.Contains(r.Min, New DoubleComparer) Select func.GetY(r.Min, r)) _
			 .Concat(From r In ranges Where xPoints.Contains(r.Max, New DoubleComparer) Select func.GetY(r.Max, r)) _
			  Where Not y.IsNaN) _
			 .Distinct(New DoubleComparer).ToList.AsReadOnly()

			Return res

		End Function

		<Extension()>
		Public Function MakeXViewPoints(ByVal func As IFunction, ByVal ParamArray points() As Double) As ReadOnlyCollection(Of Double)
			Return (From x In points Where Not x.IsNaN).Distinct(New DoubleComparer).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function MakeEmptyXViewPoints(ByVal func As IFunction) As ReadOnlyCollection(Of Double)
			Return func.MakeXViewPoints
		End Function
		
	End Module

End Namespace