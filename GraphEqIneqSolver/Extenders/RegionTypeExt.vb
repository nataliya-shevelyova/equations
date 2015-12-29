Imports System.Runtime.CompilerServices
Imports GraphEqIneqSolver.Data

Namespace Extenders

	Public Module RegionTypeExt

		<Extension()>
		Public Function Invert(ByVal regionType As RegionType) As RegionType
			Return IIf(regionType = regionType.Positive, regionType.Negative, regionType.Positive)
		End Function

	End Module

End Namespace