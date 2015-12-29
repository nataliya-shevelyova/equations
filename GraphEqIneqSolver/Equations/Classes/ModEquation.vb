Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class ModEquation
		Inherits EquationBase

		Protected ReadOnly A As Double
		Protected ReadOnly B As Double
		Protected ReadOnly C As Double

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction

		Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double)
			Me.A = a
			Me.B = b
			Me.C = c
			_rightPart = New ConstFunction(b)
			_leftPart = New ModFunction(a, c)
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
				If Not B.IsZero Then
					' b > 0 - 2 розв'язки
					Return SpecificPrimaryRoots((A - B) / C, (A + B) / C)
				Else
					' b = 0 - 1 розв'язок
					Return SpecificPrimaryRoots(A / C)
				End If
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If C.IsZero Or B < 0 Then
					If C.IsZero And Math.Abs(A).IsEqualTo(B) And B >= 0 Then
						Return AnySolution()
					Else
						Return SolutionAbsent()
					End If
				ElseIf Not B.IsZero Then
					Return MultipleSolutions()
				Else
					Return SingleSolution()
				End If
			End Get
		End Property

	End Class

End Namespace