Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Equations.Classes
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers

Namespace Inequalities.Classes

	Public Class SquareInequality1
		Inherits InequalityWrapper

		Protected ReadOnly SquareEquation As SquareEquation

		Public Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double)
			MyBase.New(New SquareEquation(a, b, c), a, b, c)
			SquareEquation = CType(Equation, SquareEquation)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.Greater
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get
				If A.IsZero Then ' a*0 + b*x + c = 0
					Return New LinearInequality1(B, C).AllRangeSolutions(xRange)
				Else
					Dim roots = PrimaryRoots
					If Not roots.Any Then
						If A > 0 Then Return AnyRangeSolution()
						Return RangeSolutionAbsent()
					Else
						If A < 0 Then
							If SquareEquation.Discriminant.IsZero Then Return RangeSolutionAbsent()
							Return SingleRangeSolution(PrimaryRoots.First(), PrimaryRoots.Last())
						End If
						Return SingleRangeSolution(Double.NegativeInfinity, PrimaryRoots.First()).Append(
						 SingleRangeSolution(PrimaryRoots.Last(), Double.PositiveInfinity))
					End If
				End If
			End Get
		End Property
	End Class

End Namespace