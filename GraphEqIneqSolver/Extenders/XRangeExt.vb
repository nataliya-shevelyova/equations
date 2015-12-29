Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices
Imports GraphEqIneqSolver.Data

Namespace Extenders

	Module XRangeExt

		<Extension()>
		Public Function UniteWith(ByVal r1 As IEnumerable(Of XRange), ByVal r2 As IEnumerable(Of XRange)) As ReadOnlyCollection(Of XRange)

			Dim ranges1 = (From r In r1 Order By r.Min, r.Max).ToList.AsReadOnly
			Dim ranges2 = (From r In r2 Order By r.Min, r.Max).ToList.AsReadOnly

			Dim res = New Dictionary(Of Double, Double)(Math.Max(ranges1.Count, ranges2.Count))
			Dim i = 0
			For Each r In ranges1
				While i < ranges2.Count AndAlso (ranges2(i).Max < r.Min OrElse (i < ranges2.Count - 1 AndAlso ranges2(i + 1).Min.Equals(r.Min)))
					i += 1
				End While
				If i = ranges2.Count Then Exit For
				Dim xMin = Math.Max(r.Min, ranges2(i).Min)
				Dim xMax = Math.Min(r.Max, ranges2(i).Max)
				If xMax >= xMin Then res(xMin) = xMax
			Next
			i = 0
			For Each r In ranges2
				While i < ranges1.Count AndAlso (ranges1(i).Max < r.Min OrElse (i < ranges1.Count - 1 AndAlso ranges1(i + 1).Min.Equals(r.Min)))
					i += 1
				End While
				If i = ranges1.Count Then Exit For
				Dim xMin = Math.Max(ranges1(i).Min, r.Min)
				Dim xMax = Math.Min(ranges1(i).Max, r.Max)
				If xMax >= xMin Then res(xMin) = xMax
			Next

			Return (From kvp In res Select New XRange(kvp.Key, kvp.Value)).Distinct.ToList.AsReadOnly

		End Function

		<Extension()>
		Public Function Invert(ByVal rs As IEnumerable(Of XRange), ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Dim ranges = (From r In rs Order By r.Min, r.Max Where r.Max > xRange.Min And r.Min < xRange.Max).ToList.AsReadOnly
			Dim res = New List(Of XRange)
			If Not ranges.Any Then
				res.Add(xRange)
			Else
				res.Add(New XRange(xRange.Min, ranges.First().Min))
				For i = 0 To ranges.Count - 2
					res.Add(New XRange(ranges(i).Max, ranges(i + 1).Min))
				Next
				res.Add(New XRange(ranges.Last().Max, xRange.Max))
			End If
			Return res.AsReadOnly
		End Function

		<Extension()>
		Public Function Points(ByVal rs As IEnumerable(Of XRange)) As ReadOnlyCollection(Of XRange)
			Return (From r In rs Where r.Size.IsZero).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function ExcludePoints(ByVal rs As IEnumerable(Of XRange)) As ReadOnlyCollection(Of XRange)
			Return (From r In rs Where Not r.Size.IsZero).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function Split(ByVal rs As IEnumerable(Of XRange), ByVal bounds As XRange, ByVal splitPoints As IEnumerable(Of Double)) As ReadOnlyCollection(Of XRange)

			Dim r = (From x In splitPoints Where x > bounds.Min And x < bounds.Max).ToList.AsReadOnly()
			If Not r.Any Then Return rs

			Dim ranges = New List(Of XRange)
			ranges.Add(New XRange(bounds.Min, r(0)))
			For i = 0 To r.Count - 2
				ranges.Add(New XRange(r(i), r(i + 1)))
			Next
			ranges.Add(New XRange(r.Last(), bounds.Max))

			Return ranges.UniteWith(rs)

		End Function

		<Extension()>
		Public Function AppendPoints(ByVal rs As IEnumerable(Of XRange), ByVal bounds As XRange, ByVal points As IEnumerable(Of Double)) As ReadOnlyCollection(Of XRange)
			Return (From r In rs.Split(bounds, points).Append(From x In points Where Not x.IsNaN AndAlso Not x.IsInfinity Select New XRange(x, x))
			  Order By r.Min, r.Max).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function Split(ByVal xRange As XRange, ByVal value As Double, ByVal period As Double, ByVal maxCurves As Integer) As ReadOnlyCollection(Of XRange)

			Dim nRange = New Double() {
			  (xRange.Min - value) / period,
			  (xRange.Max - value) / period}

			Dim nMin = Math.Floor(nRange.Min())
			Dim nMax = Math.Ceiling(nRange.Max())
			Dim nSize = nMax - nMin

			Dim nSteps = Math.Min(Math.Ceiling(nSize), maxCurves)

			Dim xPoints = (From n In (From i In Enumerable.Range(0, nSteps)
			 Select n = Math.Floor(nMin + nSize * i / (nSteps - 1))).Distinct()
			 Select x = n * period + value).ToList.AsReadOnly

			Dim res = (From x In xPoints
			  Let xMin = Math.Max(x, xRange.Min)
			  Let xMax = Math.Min(x + period, xRange.Max)
			  Where xMin > xRange.Min AndAlso xMax < xRange.Max AndAlso (xMin <= xMax OrElse xMin.IsEqualTo(xMax))
			  Select New XRange(xMin, xMax)).ToList.AsReadOnly

			Return res

		End Function

	End Module

End Namespace