Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports System.Collections.ObjectModel

Namespace Inequalities.Classes

	Public Class LinearInequality2
		Inherits LinearInequality1

		Public Sub New(ByVal a As Double, ByVal b As Double)
			MyBase.New(a, b)
		End Sub

		Public Overrides ReadOnly Property InequalityType() As InequalityType
			Get
				Return InequalityType.GreaterOrEqual
			End Get
		End Property

		Public Overrides ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Get
				If A.IsZero And B.IsZero Then Return AnyRangeSolution()
				Return MyBase.AllRangeSolutions(xRange)
			End Get
		End Property

	End Class
	
End Namespace