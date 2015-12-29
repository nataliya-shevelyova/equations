Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Functions.Classes.Wrappers
	Public Class SplitFunctionWrapper
		Inherits FunctionBase

		Private ReadOnly _func As IFunction
		Private ReadOnly _splitPoints As ReadOnlyCollection(Of Double)

		Sub New(ByVal func As IFunction, ByVal splitPoints As ReadOnlyCollection(Of Double))
			_func = func
			_splitPoints = (From x In splitPoints Order By x).Distinct(New DoubleComparer).ToList.AsReadOnly
		End Sub

		Sub New(ByVal func As IFunction, ByVal splitPoints As ReadOnlyCollection(Of XRange))
			_func = func
			Dim tmp = New List(Of Double)
			tmp.AddRange(From x In splitPoints Select x.Min)
			tmp.AddRange(From x In splitPoints Select x.Max)
			tmp.Sort()
			_splitPoints = tmp.Distinct(New DoubleComparer).ToList().AsReadOnly
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return _func.GetY(x, xRange)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return _func.GetRanges(xRange).Split(xRange, _splitPoints)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _func.XViewPoints.Append(_splitPoints)
			End Get
		End Property
	End Class
End Namespace