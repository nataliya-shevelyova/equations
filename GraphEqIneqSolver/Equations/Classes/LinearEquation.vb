Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class LinearEquation
		Inherits EquationBase

		Protected ReadOnly A As Double
		Protected ReadOnly B As Double

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction

		Sub New(ByVal a As Double, ByVal b As Double)
			Me.A = a
			Me.B = b
			_leftPart = New LinearFunction(a, b)
			_rightPart = New ConstFunction(0)
		End Sub

		Public Overrides ReadOnly Property RightPart() As IFunction
			Get
				Return _rightPart
			End Get
		End Property

		Public Overrides ReadOnly Property LeftPart() As IFunction
			Get
				Return _leftPart
			End Get
		End Property

		Public Overrides ReadOnly Property PrimaryRoots() As ReadOnlyCollection(Of Double)
			Get
				Return SpecificPrimaryRoots(-B / A)
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If A.IsZero Then
					If Not B.IsZero Then Return SolutionAbsent() Else Return AnySolution()
				Else
					Return SingleSolution()
				End If
			End Get
		End Property

	End Class

End Namespace