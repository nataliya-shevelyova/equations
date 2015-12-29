﻿Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers
Imports System.Collections.ObjectModel

Namespace Inequalities.Classes
	Public Class TanInequality2
		Inherits InequalityWrapper

		Public Sub New(ByVal a As Double, ByVal c As Double, ByVal d As Double)
			MyBase.New(New TanEquation(a, c, d), a, Double.NaN, c, d)
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
						Return AnyRangeSolution()
					Else
						Return RangeSolutionAbsent()
					End If
				Else
					Return PeriodicRangeSolution((Math.Atan(A) - D) / C, (Math.Atan(Double.PositiveInfinity) - D) / C, Math.PI / C, xRange)
				End If
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If C.IsZero Then
					If LeftPart.GetY(0) > RightPart.GetY(0) Then
						Return AnySolution()
					Else
						Return SolutionAbsent()
					End If
				Else
					Return PeriodicSolution(LeftBound, (Math.Atan(A) - D) / C, (Math.Atan(Double.PositiveInfinity) - D) / C, RightBound, "{0} πn".FormatEx(1 / C))
				End If
			End Get
		End Property

	End Class
End NameSpace