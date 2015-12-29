Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers
Imports System.Collections.ObjectModel

Namespace Inequalities.Classes
	Public Class ExpInequality2
		Inherits InequalityWrapper

		Public Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)
			MyBase.New(New ExpEquation(a, b, c, d), a, b, c, d)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.Greater
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get

				' Загальний вигляд: a^(c*x + d) > b
				If Not C.IsZero Then ' a^d > b

					If A.IsEqualTo(1) Then ' 1^d > b

						If B < 1 Then
							Return AnyRangeSolution()
						Else
							Return RangeSolutionAbsent()
						End If

					Else ' a^(c*x + d) > b

						Dim roots = PrimaryRoots
						If Not roots.Any Then Return RangeSolutionAbsent()

						Dim x = roots.Single
						If x.IsNaN Or x.IsInfinity() Then Return RangeSolutionAbsent()

						If C < 0 Then
							Return SingleRangeSolution(Double.NegativeInfinity, x)
						Else
							Return SingleRangeSolution(x, Double.PositiveInfinity)
						End If

					End If

				Else

					Dim l = LeftPart.GetY(0)
					Dim r = RightPart.GetY(0)
					If l.IsNaN OrElse l <= r OrElse l.IsEqualTo(r) Then Return RangeSolutionAbsent()
					Return AnyRangeSolution()

				End If

			End Get
		End Property

	End Class
End Namespace