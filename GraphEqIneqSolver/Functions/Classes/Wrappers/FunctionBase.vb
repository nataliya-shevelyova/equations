Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces
Imports System.Collections.ObjectModel

Namespace Functions.Classes.Wrappers
	Public MustInherit Class FunctionBase
		Implements IFunction

		Public MustOverride Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double Implements IFunction.GetY
		Public MustOverride Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange) Implements IFunction.GetRanges
		Public MustOverride ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double) Implements IFunction.XViewPoints

		Public Overridable ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double) Implements IFunction.YViewPoints
			Get
				Return MakeYViewPoints()
			End Get
		End Property

	End Class
End Namespace