Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Functions.Classes.Wrappers
	Public Class SystemInequalityFunctionWrapper
		Inherits CompositeFunctionWrapperBase
		Implements IFunction

		Private ReadOnly _type As InequalityType

		Public Sub New(ByVal leftPart As IFunction, ByVal rightPart As IFunction, ByVal type As InequalityType)
			MyBase.New(leftPart, rightPart)
			_type = type
		End Sub

		Protected Overrides Function Compose(ByVal y1 As Double, ByVal y2 As Double, ByVal xRange As XRange?) As Double
			If _type = InequalityType.Greater Or _type = InequalityType.GreaterOrEqual Then
				If y1 > y2 OrElse y1.IsEqualTo(y2) Then
					Return y1 - y2
				End If
			Else
				If y1 < y2 OrElse y1.IsEqualTo(y2) Then Return y1 - y2
			End If
			Return Double.NaN
		End Function

	End Class
End NameSpace