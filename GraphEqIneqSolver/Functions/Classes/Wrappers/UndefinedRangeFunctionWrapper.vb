Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Functions.Classes.Wrappers
	Public Class UndefinedRangeFunctionWrapper
		Inherits CompositeFunctionWrapperBase
		Implements IFunction

		Public Sub New(ByVal func1 As IFunction, ByVal func2 As IFunction)
			MyBase.New(func1, func2)
		End Sub

		Protected Overrides Function Compose(ByVal y1 As Double, ByVal y2 As Double, ByVal xRange As XRange?) As Double
			If y2.IsNaN Then Return y1 Else Return Double.NaN
		End Function
	End Class
End NameSpace