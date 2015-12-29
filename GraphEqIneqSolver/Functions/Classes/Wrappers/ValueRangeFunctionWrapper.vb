Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces
Imports System.Collections.ObjectModel

Namespace Functions.Classes.Wrappers

	Public Class ValueRangeFunctionWrapper
		Inherits FunctionBase

		Private ReadOnly _func As IFunction
		Private ReadOnly _ranges As ReadOnlyCollection(Of XRange)

		Public Sub New(ByVal func As IFunction, ByVal ranges As ReadOnlyCollection(Of XRange))
			_func = func
			_ranges = ranges
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return _func.GetY(x, xRange)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return _ranges.UniteWith(_func.GetRanges(xRange))
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _func.XViewPoints.Append((From x In _ranges Select x.Min).Concat(From x In _ranges Select x.Max))
			End Get
		End Property

	End Class

End Namespace