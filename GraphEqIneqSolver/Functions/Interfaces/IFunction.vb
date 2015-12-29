Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Interfaces

Namespace Functions.Interfaces

	Public Interface IFunction
		Inherits IViewRangeProvider

		Function GetY(ByVal x As Double, Optional ByVal xRange As XRange? = Nothing) As Double
		Function GetRanges(ByVal xRange As XRange) As ReadOnlyCollection(Of XRange)
		
	End Interface

End Namespace