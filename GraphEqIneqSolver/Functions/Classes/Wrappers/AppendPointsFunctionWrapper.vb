Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces
Imports System.Collections.ObjectModel

Namespace Functions.Classes.Wrappers
	Public Class AppendPointsFunctionWrapper
		Inherits FunctionBase

		Private ReadOnly _func As IFunction
		Private ReadOnly _points As ReadOnlyCollection(Of Double)

		Sub New(ByVal func As IFunction, ByVal splitPoints As ReadOnlyCollection(Of Double))
			_func = func
			_points = (From x In splitPoints Order By x).Distinct(New DoubleComparer).ToList.AsReadOnly
		End Sub

		Sub New(ByVal func As IFunction, ByVal splitPoints As ReadOnlyCollection(Of XRange))
			_func = func
			Dim tmp = New List(Of Double)
			tmp.AddRange(From x In splitPoints Select x.Min)
			tmp.AddRange(From x In splitPoints Select x.Max)
			tmp.Sort()
			_points = tmp.Distinct(New DoubleComparer).ToList().AsReadOnly
		End Sub

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return _func.GetY(x, xRange)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Return _func.GetRanges(xRange).AppendPoints(xRange, _points)
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _func.XViewPoints.Append(_points)
			End Get
		End Property
	End Class
End NameSpace