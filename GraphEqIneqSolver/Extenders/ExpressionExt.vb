Imports System.Runtime.CompilerServices
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Inequalities.Interfaces

Namespace Extenders
	Public Module ExpressionExt

#Region "Primary Roots Solutions"

		<Extension()>
		Public Function SpecificPrimaryRoots(ByVal eq As IExpression, ByVal ParamArray roots() As Double) As ReadOnlyCollection(Of Double)
			Return (From x In roots Where Not x.IsNaN AndAlso Not x.IsInfinity Order By x).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function PrimaryRootsAbsent(ByVal eq As IExpression) As ReadOnlyCollection(Of Double)
			Return eq.SpecificPrimaryRoots
		End Function

#End Region

#Region "Range Solutions"

		<Extension()>
		Public Function RangeSolutionAbsent(ByVal eq As IExpression) As ReadOnlyCollection(Of XRange)
			Return New XRange() {}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function AnyRangeSolution(ByVal eq As IExpression) As ReadOnlyCollection(Of XRange)
			Return New XRange() {New XRange(Double.NegativeInfinity, Double.PositiveInfinity)}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function SingleRangeSolution(ByVal eq As IExpression, ByVal l As Double, ByVal r As Double) As ReadOnlyCollection(Of XRange)
			Return New XRange() {New XRange(Math.Min(l, r), Math.Max(l, r))}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function PeriodicRangeSolution(ByVal eq As IExpression, ByVal l As Double, ByVal r As Double, ByVal period As Double, ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Dim min = Math.Min(l, r)
			Dim max = Math.Max(l, r)
			Dim delta = max - min
			Dim ranges = xRange.Split(min, period, 200)
			Dim res = (From t In ranges Select t = New XRange(t.Min, Math.Min(t.Max, t.Min + delta))).ToList.AsReadOnly()
			Return res
		End Function

#End Region

#Region "Text Solutions"

		<Extension()>
		Public Function SolutionAbsent(ByVal eq As IExpression) As ReadOnlyCollection(Of String)
			Return New String() {"x ∈ ∅"}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function AnySolution(ByVal eq As IExpression) As ReadOnlyCollection(Of String)
			Return New String() {"x ∈ ℝ"}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function SingleSolution(ByVal eq As IExpression) As ReadOnlyCollection(Of String)
			Return New String() {"x = {0}".FormatEx(eq.PrimaryRoots.Single())}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function MultipleSolutions(ByVal eq As IExpression) As ReadOnlyCollection(Of String)
			Dim res = (From x In eq.PrimaryRoots Select "x = {0}".FormatEx(x)).ToList.AsReadOnly
			Debug.Assert(res.Count > 1)
			Return res
		End Function

		<Extension()>
		Public Function PeriodicSolution(ByVal eq As IExpression, ByVal period As String, Optional ByVal k? As Double = Nothing) As ReadOnlyCollection(Of String)
			Return (From s In eq.PrimaryRoots
			 Select s = CType(IIf(Not k Is Nothing, s + k, s), Double)
			 Select "x = {0} + {1}, n ∈ ℤ".FormatEx(s.Format(), period)).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function PeriodicSolution(ByVal eq As IExpression, ByVal x As Double, ByVal period As String) As ReadOnlyCollection(Of String)
			Return New String() {"x = {0} + {1}, n ∈ ℤ".FormatEx(x, period)}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function PeriodicSolution(ByVal eq As IExpression, ByVal leftBound As Char, ByVal l As Double, ByVal r As Double, ByVal rightBound As Char, ByVal period As String) As ReadOnlyCollection(Of String)
			Return New String() {"x ∈ {0}{1}; {3}{4} + {2}, n ∈ ℤ".FormatEx(leftBound, Math.Min(l, r).Format(), period, Math.Max(l, r).Format(), rightBound)}.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function RangeSolution(ByVal eq As IInequality, ByVal leftBound As Char, ByVal l As Double, ByVal r As Double, ByVal rightBound As Char) As ReadOnlyCollection(Of String)
			If Math.Min(l, r).Equals(Double.NegativeInfinity) AndAlso Math.Max(l, r).Equals(Double.PositiveInfinity) Then
				Return eq.AnySolution()
			End If
			If l.IsEqualTo(r) AndAlso (leftBound = "[" OrElse rightBound = "]") Then
				Return New String() {"x = {0}".FormatEx(eq.PrimaryRoots.First())}.ToList.AsReadOnly
			End If
			Return New String() {"x ∈ {0}{1}; {2}{3}".FormatEx(leftBound, Math.Min(l, r).Format(), Math.Max(l, r).Format(), rightBound)}.ToList.AsReadOnly
		End Function

#End Region

#Region "View points helpers"

		<Extension()>
		Public Function MakeXViewPoints(ByVal eq As IExpression, ByVal ParamArray xPoints() As Double) As ReadOnlyCollection(Of Double)
			Return (From x In xPoints.Concat(eq.LeftPart.XViewPoints).Concat(eq.RightPart.XViewPoints).Concat(eq.PrimaryRoots) _
			  Where Not x.IsNaN AndAlso Not x.IsInfinity) _
			 .Distinct(New DoubleComparer).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function MakeYViewPoints(ByVal eq As IExpression, ByVal ParamArray yPoints() As Double) As ReadOnlyCollection(Of Double)
			Return (From y In yPoints.Concat(From x In eq.MakeXViewPoints() Select eq.LeftPart.GetY(x)).Concat(eq.LeftPart.YViewPoints).Concat(eq.RightPart.YViewPoints) _
			  Where Not y.IsNaN AndAlso Not y.IsInfinity) _
			 .Distinct(New DoubleComparer) _
			 .ToList.AsReadOnly()
		End Function

		<Extension()>
		Public Function MakeYViewPointsFromXPoints(ByVal eq As IExpression, ByVal ParamArray xPoints() As Double) As ReadOnlyCollection(Of Double)
			Return (From x In xPoints.Concat(eq.MakeXViewPoints()) Select y = eq.LeftPart.GetY(x) Where _
			  Not y.IsNaN AndAlso Not y.IsInfinity) _
			 .Concat(eq.LeftPart.YViewPoints).Concat(eq.RightPart.YViewPoints) _
			 .Distinct(New DoubleComparer).ToList.AsReadOnly()
		End Function

#End Region

	End Module
End Namespace