Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices

Namespace Extenders

	Module EnumerableExt

		<Extension()>
		Public Function Append(Of T)(ByVal enumerable As IEnumerable(Of T), ByVal ParamArray values() As T) As ReadOnlyCollection(Of T)
			Return enumerable.Concat(values).Distinct.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function Append(Of T)(ByVal enumerable As IEnumerable(Of T), ByVal values As IEnumerable(Of T)) As ReadOnlyCollection(Of T)
			Return enumerable.Concat(values).Distinct.ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function Append(ByVal enumerable As IEnumerable(Of Double), ByVal ParamArray values() As Double) As ReadOnlyCollection(Of Double)
			Return enumerable.Concat(values).Distinct(New DoubleComparer).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function Append(ByVal enumerable As IEnumerable(Of Double), ByVal values As IEnumerable(Of Double)) As ReadOnlyCollection(Of Double)
			Return enumerable.Concat(values).Distinct(New DoubleComparer).ToList.AsReadOnly
		End Function

		<Extension()>
		Public Function SelectManyEx(Of T)(ByVal enumerable As IEnumerable(Of IEnumerable(Of T))) As ReadOnlyCollection(Of T)
			Dim res = New List(Of T)
			For Each item In enumerable
				res.AddRange(item)
			Next
			Return res.AsReadOnly()
		End Function

	End Module

End Namespace