Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers
Imports System.Collections.ObjectModel

Namespace Inequalities.Classes
	Public Class LogInequality2
		Inherits InequalityWrapper

		Public Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)
			MyBase.New(New LogEquation(a, b, c, d), a, b, c, d)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.Greater
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get

				If Not C.IsZero Then
					Dim x = PrimaryRoots.Single
					If x.IsNaN Or x.IsInfinity() Then Return RangeSolutionAbsent()
					If C < 0 Then
						Return SingleRangeSolution(Double.NegativeInfinity, x)
					Else
						Return SingleRangeSolution(x, Double.PositiveInfinity)
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
End NameSpace