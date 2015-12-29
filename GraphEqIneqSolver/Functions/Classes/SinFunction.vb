Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class SinFunction
		Inherits FunctionBase

		Private ReadOnly _c As Double
		Private ReadOnly _d As Double

		Sub New(ByVal c As Double, ByVal d As Double)
			_c = c
			_d = d
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return Math.Sin(_c * x + _d)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return MakeRanges(xRange)
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