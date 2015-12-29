Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Equations.Classes
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers

Namespace Inequalities.Classes
	Public Class ModInequality2
		Inherits InequalityWrapper

		Public Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double)
			MyBase.New(New ModEquation(a, b, c), a, b, c)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.Greater
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get
				If B.IsZero Or B < 0 Then Return AnyRangeSolution()
				If C.IsZero Then
					If C.IsZero And Math.Abs(A) > B Then
						Return AnyRangeSolution()
					Else
						Return RangeSolutionAbsent()
					End If
				Else
					Return SingleRangeSolution(Double.NegativeInfinity, PrimaryRoots.First()).Append(
					 SingleRangeSolution(PrimaryRoots.Last(), Double.PositiveInfinity))
				End If
			End Get
		End Property
	End Class
End Namespace