Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class LogFunction
		Inherits FunctionBase

		Private ReadOnly _a As Double
		Private ReadOnly _c As Double
		Private ReadOnly _d As Double

		Sub New(ByVal a As Double, ByVal c As Double, ByVal d As Double)
			_a = a
			_c = c
			_d = d
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double

			Dim exp = _c * x + _d

			If exp.IsEqualTo(1) Then Return 0

			If Not xRange Is Nothing And exp.IsZero Then
				If _a > 1 Then
					Return Double.NegativeInfinity
				Else
					Return Double.PositiveInfinity
				End If
			End If

			Return Math.Log(_c * x + _d, _a)

		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)

			If _c.IsZero Then
				Return MakeRanges(xRange)
			ElseIf _c > 0 Then
				Return MakeRange(Math.Max(-_d / _c, xRange.Min), xRange.Max)
			Else
				Return MakeRange(xRange.Min, Math.Min(-_d / _c, xRange.Max))
			End If

		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If _c.IsZero Then Return MakeEmptyXViewPoints()
				Dim r = MakeXViewPoints((1 - _d) / _c + Math.Log(Math.Abs(_c)), (1 - _d) / _c)
				Return r
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If _c.IsZero Then Return MakeYViewPointsFromXPoints(0)
				Return MakeYViewPoints.Append(0)
			End Get
		End Property

	End Class

End Namespace