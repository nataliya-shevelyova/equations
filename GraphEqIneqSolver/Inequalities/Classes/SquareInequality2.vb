Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports System.Collections.ObjectModel

Namespace Inequalities.Classes

	Public Class SquareInequality2
		Inherits SquareInequality1

		Public Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double)
			MyBase.New(a, b, c)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.GreaterOrEqual
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get
				If Not A.IsZero Then
					If SquareEquation.Discriminant.IsZero Then
						If A < 0 Then
							Return SingleRangeSolution(PrimaryRoots.First(), -B / (2 * A)).Append(
							 SingleRangeSolution(-B / (2 * A), PrimaryRoots.Last()))
						Else
							Return SingleRangeSolution(Double.NegativeInfinity, -B / (2 * A)).Append(
							 SingleRangeSolution(-B / (2 * A), Double.PositiveInfinity))
						End If
					End If
				Else
					Return New LinearInequality2(B, C).AllRangeSolutions(xRange)
				End If
				Return MyBase.AllRangeSolutions(xRange)
			End Get
		End Property
	End Class

End Namespace