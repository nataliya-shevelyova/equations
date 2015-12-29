Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class ModFunction
		Inherits FunctionBase

		Private ReadOnly _a As Double
		Private ReadOnly _c As Double

		Sub New(ByVal a As Double, ByVal c As Double)
			_a = a
			_c = c
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return Math.Abs(_c * x - _a)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return MakeRanges(xRange)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return MakeXViewPoints(_a / _c)
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If _c.IsZero Then
					Return MakeYViewPoints(_a)
				Else
					Return MakeYViewPoints(_a / _c)
				End If
			End Get
		End Property

	End Class

End Namespace