Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces
Imports GraphEqIneqSolver.Functions.Classes.Wrappers

Namespace Functions.Classes

	Public Class ConstFunction
		Inherits FunctionBase

		Private ReadOnly _linearFunction As IFunction

		Sub New(ByVal c As Double)
			_linearFunction = New LinearFunction(0, c)
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return _linearFunction.GetY(x, xRange)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return _linearFunction.GetRanges(xRange)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _linearFunction.XViewPoints
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _linearFunction.YViewPoints
			End Get
		End Property

	End Class

End Namespace