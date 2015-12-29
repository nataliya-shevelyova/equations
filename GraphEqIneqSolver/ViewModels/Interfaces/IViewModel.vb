Imports System.Collections.ObjectModel
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Utilities.Interfaces

Namespace ViewModels.Interfaces

	Public Interface IViewModel

		Sub Render()
		Function GetSolutions() As ReadOnlyCollection(Of String)
		Function CalculateViewRange() As ViewRange
		Function ResolveTangentialLines(ByVal point As PointF?, Optional ByVal useDash As Boolean = False) As ReadOnlyCollection(Of ILine)

	End Interface

End Namespace