Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Equations.Interfaces
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class SquareEquation
		Inherits EquationBase

		Protected ReadOnly A As Double
		Protected ReadOnly B As Double
		Protected ReadOnly C As Double

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction
		Private ReadOnly _linearEquation As IEquation

		Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double)
			Me.A = a
			Me.B = b
			Me.C = c
			_leftPart = New SquareFunction(a, b, c)
			_rightPart = New ConstFunction(0)
			_linearEquation = New LinearEquation(b, c)
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

		Public ReadOnly Property Discriminant() As Double
			Get
				Return B * B - 4 * A * C
			End Get
		End Property

		Public Overrides ReadOnly Property PrimaryRoots() As ReadOnlyCollection(Of Double)
			Get
				If A.IsZero Then	' a*0 + b*x + c = 0
					Return _linearEquation.PrimaryRoots
				Else
					Dim d = Math.Sqrt(Discriminant)
					Return SpecificPrimaryRoots((-B + d) / (2 * A), (-B - d) / (2 * A))
				End If
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If A.IsZero Then ' a*0 + b*x + c = 0
					Return New LinearEquation(B, C).TextSolutions
				Else
					Dim roots = PrimaryRoots
					If Not roots.Any Then Return SolutionAbsent()
					Return MultipleSolutions()
				End If
			End Get
		End Property
		
	End Class

End Namespace