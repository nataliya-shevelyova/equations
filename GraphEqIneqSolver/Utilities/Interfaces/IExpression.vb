Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Utilities.Interfaces

	Public Interface IExpression
		Inherits IViewRangeProvider

		' Ліва частина рівняння
		ReadOnly Property LeftPart() As IFunction

		' Права частина рівняння
		ReadOnly Property RightPart() As IFunction

		' Розв'язки
		ReadOnly Property PrimaryRoots() As ReadOnlyCollection(Of Double)

		' Розв'язки
		ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)

	End Interface
End Namespace