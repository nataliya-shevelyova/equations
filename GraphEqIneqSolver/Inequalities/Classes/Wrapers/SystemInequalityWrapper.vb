Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Inequalities.Interfaces
Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Equations.Classes.Wrappers
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Inequalities.Classes.Wrapers
	Public Class SystemInequalityWrapper
		Inherits SystemEquationWrapper
		Implements IInequality

		Private ReadOnly _type As InequalityType

		Public Sub New(ByVal leftPart As IFunction, ByVal type As InequalityType, ByVal rightPart As IFunction)
			MyBase.New(leftPart, rightPart)
			_type = type
		End Sub

		Public Overridable ReadOnly Property InequalityType() As InequalityType Implements IInequality.InequalityType
			Get
				Return _type
			End Get
		End Property

		Public Overridable ReadOnly Property AllRangeSolutions(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange) Implements IInequality.AllRangeSolutions
			Get
				Return New XRange() {}.ToList().AsReadOnly()
			End Get
		End Property

	End Class
End Namespace