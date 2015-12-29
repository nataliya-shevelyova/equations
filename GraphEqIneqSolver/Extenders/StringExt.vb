Imports System.Runtime.CompilerServices

Namespace Extenders

	Module StringExt

		<Extension()>
		Public Function FormatEx(ByVal format As String, ByVal x As Double) As String
			Return format.FormatEx(x.Format())
		End Function

		<Extension()>
		Public Function FormatEx(ByVal format As String, ParamArray args() As Object) As String
			Return String.Format(format, args)
		End Function

	End Module

End Namespace