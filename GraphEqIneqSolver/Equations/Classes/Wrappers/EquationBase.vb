Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Equations.Interfaces
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports System.Collections.ObjectModel

Namespace Equations.Classes.Wrappers

	Public MustInherit Class EquationBase
		Implements IEquation

		Public MustOverride ReadOnly Property LeftPart() As IFunction Implements IExpression.LeftPart
		Public MustOverride ReadOnly Property RightPart() As IFunction Implements IExpression.RightPart
		Public MustOverride ReadOnly Property PrimaryRoots() As ReadOnlyCollection(Of Double) Implements IExpression.PrimaryRoots
		Public MustOverride ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String) Implements IExpression.TextSolutions

		Public Overridable ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double) Implements IExpression.XViewPoints
			Get
				Return MakeXViewPoints()
			End Get
		End Property

		Public Overridable ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double) Implements IExpression.YViewPoints
			Get
				Return MakeYViewPoints()
			End Get
		End Property

	End Class

End Namespace