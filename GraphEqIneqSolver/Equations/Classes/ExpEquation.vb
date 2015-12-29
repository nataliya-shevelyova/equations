Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers

Namespace Equations.Classes

	Public Class ExpEquation
		Inherits EquationBase

		Protected ReadOnly A As Double
		Protected ReadOnly B As Double
		Protected ReadOnly C As Double
		Protected ReadOnly D As Double

		Private ReadOnly _leftPart As IFunction
		Private ReadOnly _rightPart As IFunction

		Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)

			If a < 0 Then Throw New Exception()

			Me.A = a
			Me.B = b
			Me.C = c
			Me.D = d

			_rightPart = New ConstFunction(b)
			_leftPart = New ExpFunction(a, c, d)

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
				' Загальний вигляд: a^(c*x + d) = b
				If Not C.IsZero Then ' a^d = b
					If A.IsEqualTo(1) Then	' 1^d = b
						Return PrimaryRootsAbsent()
					Else ' a^d = b

						Dim x = (Math.Log10(B) - D * Math.Log10(Math.Abs(A))) / (C * Math.Log10(Math.Abs(A)))
						If x.IsNaN Or x.IsInfinity() Then Return PrimaryRootsAbsent()
						Return SpecificPrimaryRoots(x)

					End If
				Else
					Return PrimaryRootsAbsent()
				End If
			End Get
		End Property

		Public Overrides ReadOnly Property TextSolutions() As ReadOnlyCollection(Of String)
			Get
				' Загальний вигляд: a^(c*x + d) = b
				If Not C.IsZero Then ' a^d = b

					If A.IsEqualTo(1) Then	' 1^d = b

						If B.IsEqualTo(1) Then	' 1^d = 1
							Return AnySolution()
						Else ' 1^d = b, b ≠ 1
							Return SolutionAbsent()
						End If

					Else ' a^(c*d + d) = b

						Dim x = (Math.Log10(B) - D * Math.Log10(Math.Abs(A))) / (C * Math.Log10(Math.Abs(A)))
						If x.IsNaN Or x.IsInfinity() Then Return SolutionAbsent()
						Return SingleSolution()

					End If

				Else ' a^d = b

					Dim l = LeftPart.GetY(0)
					Dim r = RightPart.GetY(0)
					If l.IsEqualTo(r) Then Return AnySolution() Else Return SolutionAbsent()

				End If

			End Get

		End Property

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return MakeXViewPoints()
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If C.IsZero Then
					Return MakeYViewPoints.Append(B)
				Else
					Return MakeYViewPoints.Append(B)
				End If
			End Get
		End Property

	End Class

End Namespace