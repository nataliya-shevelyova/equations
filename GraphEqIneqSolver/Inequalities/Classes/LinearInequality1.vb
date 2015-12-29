Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers

Namespace Inequalities.Classes

	Public Class LinearInequality1
		Inherits InequalityWrapper

		Public Sub New(ByVal a As Double, ByVal b As Double)
			MyBase.New(New LinearEquation(a, b), a, b)
		End Sub
		
		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.Greater
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get
				If A.IsZero Then
					If B.IsZero Or B < 0 Then Return RangeSolutionAbsent() Else Return AnyRangeSolution()
				Else
					If 0 < A Then
						Return SingleRangeSolution(PrimaryRoots.Single, Double.PositiveInfinity)
					Else
						Return SingleRangeSolution(Double.NegativeInfinity, PrimaryRoots.Single)
					End If
				End If
			End Get
		End Property

	End Class

End Namespace