Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class LinearFunction
		Inherits FunctionBase

		Private ReadOnly _squareFunction As IFunction

		Sub New(ByVal a As Double, ByVal b As Double)
			_squareFunction = New SquareFunction(0, a, b)
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return _squareFunction.GetY(x, xRange)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return _squareFunction.GetRanges(xRange)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _squareFunction.XViewPoints
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _squareFunction.YViewPoints
			End Get
		End Property

	End Class

End Namespace