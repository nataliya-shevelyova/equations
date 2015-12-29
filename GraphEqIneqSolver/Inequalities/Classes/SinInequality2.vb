﻿Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers
Imports System.Collections.ObjectModel

Namespace Inequalities.Classes
	Public Class SinInequality2
		Inherits InequalityWrapper

		Public Sub New(ByVal a As Double, ByVal c As Double, ByVal d As Double)
			MyBase.New(New SinEquation(a, c, d), a, Double.NaN, c, d)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.Greater
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get
				If C.IsZero Then
					If LeftPart.GetY(0) > RightPart.GetY(0) Then
						Return SingleRangeSolution(Double.NegativeInfinity, Double.PositiveInfinity)
					Else
						Return RangeSolutionAbsent()
					End If
				Else
					If A < -1 Then Return SingleRangeSolution(Double.NegativeInfinity, Double.PositiveInfinity)
					If A > 1 OrElse A.IsEqualTo(1) Then Return RangeSolutionAbsent()
					Return PeriodicRangeSolution((Math.Asin(A) - D) / C, (-Math.Asin(A) - D + Math.PI) / C, 2 * Math.PI / C, xRange)
				End If
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If C.IsZero Or A > 1 OrElse A < -1 OrElse A.IsEqualTo(1) Then Return MyBase.TextSolutions
				Return PeriodicSolution(LeftBound, (Math.Asin(A) - D) / C, (-Math.Asin(A) - D + Math.PI) / C, RightBound, "{0} πn".FormatEx(2 / C))
			End Get
		End Property

	End Class
End NameSpace