Imports GraphEqIneqSolver.Functions.Interfaces
Imports System.Collections.ObjectModel

Namespace Equations.Classes.Wrappers
	Public Class SystemEquationWrapper
		Inherits EquationBase

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction

		Sub New(ByVal leftPart As IFunction, ByVal rightPart As IFunction)
			_leftPart = leftPart
			_rightPart = RightPart
		End Sub

		Public Overrides ReadOnly Property LeftPart() As IFunction
			Get
				Return _leftPart
			End Get
		End Property

		Public Overrides ReadOnly Property RightPart() As IFunction
			Get
				Return _rightPart
			End Get
		End Property

		Public Overrides ReadOnly Property PrimaryRoots() As ReadOnlyCollection(Of Double)
			Get
				Return New List(Of Double)().AsReadOnly()
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				Return New List(Of String)().AsReadOnly()
			End Get
		End Property
	End Class
End Namespace