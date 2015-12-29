Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class LogEquation
		Inherits EquationBase

		Protected ReadOnly A As Double
		Protected ReadOnly B As Double
		Protected ReadOnly C As Double
		Protected ReadOnly D As Double

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction

		Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)

			If a <= 0 Or a.IsZero Or a.IsEqualTo(1) Then Throw New Exception()

			Me.A = a
			Me.B = b
			Me.C = c
			Me.D = d

			_rightPart = New ConstFunction(b)
			_leftPart = New LogFunction(a, c, d)

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
				If Not C.IsZero Then
					Return SpecificPrimaryRoots((Math.Pow(A, B) - D) / C)
				Else
					Return PrimaryRootsAbsent()
				End If
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If Not C.IsZero Then
					Return SingleSolution()
				Else
					If LeftPart.GetY(0).IsEqualTo(RightPart.GetY(0)) Then
						Return AnySolution()
					Else
						Return SolutionAbsent()
					End If
				End If
			End Get
		End Property
		
	End Class
End Namespace