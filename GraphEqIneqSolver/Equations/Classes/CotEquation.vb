Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class CotEquation
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
			_rightPart = New ConstFunction(a)
			_leftPart = New CotFunction(c, d)
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
				If C.IsZero Then
					Return PrimaryRootsAbsent()
				Else
					Return SpecificPrimaryRoots((A.Acot() - D) / C)
				End If

			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				If C.IsZero Then
					If LeftPart.GetY(0).IsEqualTo(RightPart.GetY(0)) Then
						Return AnySolution()
					Else
						Return SolutionAbsent()
					End If
				Else
					Return PeriodicSolution("{0} πn".FormatEx(1 / C))
				End If
			End Get
		End Property

	End Class

End Namespace