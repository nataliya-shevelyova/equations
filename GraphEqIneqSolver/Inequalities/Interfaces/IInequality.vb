Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports System.Collections.ObjectModel

Namespace Inequalities.Interfaces

	' Представляє нерівность
	Public Interface IInequality
		Inherits IExpression

		ReadOnly Property InequalityType() As InequalityType
		ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)

	End Interface

End Namespace