Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class SquareFunction
		Inherits FunctionBase

		Private ReadOnly _a As Double
		Private ReadOnly _b As Double
		Private ReadOnly _c As Double

		Sub New(ByVal a As Double, ByVal b As Double, ByVal c As Double)
			_a = a
			_b = b
			_c = c
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return _a * x * x + _b * x + _c
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return MakeRanges(xRange)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If _a.IsZero And Not _b.IsZero Then Return MakeXViewPoints(0)
				Return MakeXViewPoints(-_b / (2 * _a))
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If _a.IsZero Then
					If _b.IsZero Then
						Return MyBase.YViewPoints.Append(_c)
					Else
						Return MyBase.YViewPoints.Append(0, GetY(0))
					End If
				Else
					Return MyBase.YViewPoints
				End If
			End Get
		End Property

	End Class

End Namespace