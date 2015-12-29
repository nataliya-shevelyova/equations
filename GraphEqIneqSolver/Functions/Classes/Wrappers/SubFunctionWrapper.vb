Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Functions.Classes.Wrappers
	Public Class SubFunctionWrapper
		Inherits CompositeFunctionWrapperBase
		Implements IFunction

		Public Sub New(ByVal leftPart As IFunction, ByVal rightPart As IFunction)
			MyBase.New(leftPart, rightPart)
		End Sub

		Protected Overrides Function Compose(ByVal y1 As Double, ByVal y2 As Double, ByVal xRange As XRange?) As Double
			Return y1 - y2
		End Function

	End Class
End NameSpace