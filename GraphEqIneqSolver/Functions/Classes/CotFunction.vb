Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class CotFunction
		Inherits FunctionBase

		Private ReadOnly _c As Double
		Private ReadOnly _d As Double

		Sub New(ByVal c As Double, ByVal d As Double)
			_c = c
			_d = d
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double

			Dim arg = _c * x + _d

			If Not xRange Is Nothing Then
				Dim alpha = arg / Math.PI
				If alpha.IsInteger() Then
					If x.IsEqualTo(xRange.Value.Max) Then
						Return Double.NegativeInfinity
					Else
						Return Double.PositiveInfinity
					End If
				End If
			End If

			Return 1.0 / Math.Tan(arg)

		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)

			If _c.IsZero Then
				Return MakeRanges(xRange)
			Else
				Dim period = Math.Abs(Math.PI / _c)
				Dim value = (Math.PI - _d) / _c
				Return xRange.Split(value, period, 200)
			End If

		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return MakeXViewPoints(-2 * Math.PI / _c, 2 * Math.PI / _c)
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return MakeYViewPoints(-1, 1)
			End Get
		End Property

	End Class

End Namespace