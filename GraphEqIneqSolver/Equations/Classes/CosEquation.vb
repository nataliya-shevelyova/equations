Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class CosEquation
		Inherits EquationBase

		Protected ReadOnly A As Double
		Protected ReadOnly C As Double
		Protected ReadOnly D As Double

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction

		Sub New(ByVal a As Double, ByVal c As Double, ByVal d As Double)
			Me.A = a
			Me.C = c
			Me.D = d
			_leftPart = New CosFunction(c, d)
			_rightPart = New ConstFunction(a)
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

				If A.IsEqualTo(1) OrElse A.IsEqualTo(-1) OrElse A.IsZero Then ' sin(c*x + d) = ±1
					Return SpecificPrimaryRoots((Math.Acos(A) - D) / C)
				ElseIf A.IsZero Then ' sin(c*x + d) = 0
					Return SpecificPrimaryRoots((Math.Acos(A) - D) / C)
				End If

				If (-1 <= A And A <= 1) And (Not C.IsZero) Then
					Return SpecificPrimaryRoots((Math.Acos(A) - D) / C, (-Math.Acos(A) - D) / C)
				End If

				Return PrimaryRootsAbsent()

			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get

				If A.IsEqualTo(1) Or A.IsEqualTo(-1) Then	' cos(c*x + d) = ±1
					Return PeriodicSolution("{0} πn".FormatEx(2 / C))
				ElseIf A.IsZero Then ' sin(c*x + d) = 0
					Return PeriodicSolution("{0} πn".FormatEx(1 / C))
				End If

				If (-1 <= A And A <= 1) And (Not C.IsZero) Then
					Return PeriodicSolution("{0} πn".FormatEx(2 / C))
				End If

				Return SolutionAbsent()

			End Get
		End Property

	End Class

End Namespace