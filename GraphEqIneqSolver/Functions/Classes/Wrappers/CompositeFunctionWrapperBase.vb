Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Functions.Classes.Wrappers

	Public MustInherit Class CompositeFunctionWrapperBase
		Inherits FunctionBase

		Private ReadOnly _func1 As IFunction
		Private ReadOnly _func2 As IFunction

		Sub New(ByVal func1 As IFunction, ByVal func2 As IFunction)
			_func1 = func1
			_func2 = func2
		End Sub

		Protected MustOverride Function Compose(y1 As Double, y2 As Double, ByVal xRange As XRange?) As Double

		Public Overrides Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
			Return Compose(_func1.GetY(x, xRange), _func2.GetY(x, xRange), xRange)
		End Function

		Public Overrides Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
			Const n = 200
			Dim res = _func1.GetRanges(xRange).UniteWith(_func2.GetRanges(xRange))
			If res.Count <= n Then Return res
			Dim k = Math.Ceiling(res.Count / n)
			Dim i As Double = 0
			Dim tmp = New List(Of XRange)(n)
			While Math.Round(i) < res.Count
				tmp.Add(res(Math.Round(i)))
				i += k
			End While
			Return tmp.AsReadOnly
		End Function

		Public Overrides ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return _func1.XViewPoints.Append(_func2.XViewPoints)
			End Get
		End Property

		Public Overrides ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
			Get
				Return MakeYViewPoints().Append(_func1.YViewPoints.Concat(_func2.YViewPoints))
			End Get
		End Property

	End Class
End Namespace