Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class ExpFunction
		Inherits FunctionBase

		Private ReadOnly _a As Double
		Private ReadOnly _c As Double
		Private ReadOnly _d As Double

		Sub New(ByVal a As Double, ByVal c As Double, ByVal d As Double)
			If (_a < 0) AndAlso Not a.IsZero Then Throw New Exception()
			_a = a
			_c = c
			_d = d
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double

			' Нуль в будь-який ступені - завжи нуль
			If _a.IsZero Then Return 0
			Return Math.Pow(_a, _c * x + _d)

		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return MakeRanges(xRange)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				If _c.IsZero OrElse _a.IsEqualTo(1) Then Return MakeEmptyXViewPoints()
				Dim x = New ExpEquation(_a, 2, _c, _d).PrimaryRoots.Single
				Dim r = MakeXViewPoints(-_d / _c, x, -_d / _c - (x + _d / _c))
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