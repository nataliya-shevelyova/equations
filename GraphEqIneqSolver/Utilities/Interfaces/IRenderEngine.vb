Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Functions.Interfaces

Namespace Utilities.Interfaces

	Public Interface IRenderEngine

		Sub PlotFunction(ByVal func As IFunction, ByVal name As String, ByVal color As Color, ByVal xRange As XRange, Optional ByVal width As Double = 3)
		Sub FillRegion(ByVal func As IFunction, ByVal inequalityType As InequalityType, ByVal name As String, ByVal color As Color, ByVal xRange As XRange, Optional ByVal noLines As Boolean = False)

	End Interface

End Namespace