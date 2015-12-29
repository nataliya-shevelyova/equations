Imports System.Runtime.CompilerServices

Namespace Extenders

	Module DoubleExt

		Public Class DoubleComparer
			Implements IEqualityComparer(Of Double)

			Public Overloads Function Equals(ByVal x As Double, ByVal y As Double) As Boolean Implements IEqualityComparer(Of Double).Equals
				Return x.IsEqualTo(y)
			End Function

			Public Overloads Function GetHashCode(ByVal x As Double) As Integer Implements IEqualityComparer(Of Double).GetHashCode
				Return x.HashCode
			End Function

		End Class

		Private Const Epsilon As Double = 0.000000000001

		<Extension()>
		Public Function HashCode(x As Double) As Integer
			If x.IsEqualTo(0) Or x.IsInfinity Then Return 0
			Dim exp = CType(Math.Floor(Math.Log(Math.Abs(x))), Integer)
			Dim t = Math.Round(x / Math.Exp(exp) * 1000000000)
			Return CType(Math.Round(t), Int64).GetHashCode()
		End Function

		<Extension()>
		Public Function Acot(x As Double) As Double
			Return Math.PI / 2 - Math.Atan(x)
		End Function

		<Extension()>
		Public Function IsZero(ByVal x As Double) As Boolean
			Return Math.Abs(x) <= Epsilon
		End Function

		<Extension()>
		Public Function IsEqualTo(ByVal x1 As Double, ByVal x2 As Double) As Boolean
			Return IsZero(x1 - x2)
		End Function

		<Extension()>
		Public Function Format(ByVal x As Single) As String
			Return CType(x, Double).Format()
		End Function

		' Математично коректне форматування Double
		<Extension()>
		Public Function Format(ByVal x As Double) As String

			If x.IsPositiveInfinity() Then
				Return "∞"
			ElseIf x.IsNegativeInfinity() Then
				Return "-∞"
			ElseIf x.IsZero Then
				Return "0.000000"
			End If

			Dim a = Math.Abs(x)

			If a >= 0.001 And a < 0.01 Then
				Return x.ToString("0.000000000")
			ElseIf a >= 0.01 And a < 0.1 Then
				Return x.ToString("0.00000000")
			ElseIf a >= 0.1 And a < 1 Then
				Return x.ToString("0.0000000")
			ElseIf a >= 1 And a < 10 Then
				Return x.ToString("0.000000")
			ElseIf a >= 10 And a < 100 Then
				Return x.ToString("0.00000")
			ElseIf a >= 100 And a < 1000 Then
				Return x.ToString("0.0000")
			ElseIf a >= 1000 And a < 10000 Then
				Return x.ToString("0.000")
			ElseIf a >= 10000 And a < 100000 Then
				Return x.ToString("0.00")
			ElseIf a >= 100000 And a < 1000000 Then
				Return x.ToString("0.0")
			ElseIf a >= 1000000 And a < 10000000 Then
				Return x.ToString("0")
			End If

			Return x.ToString("0.000000e+0")

		End Function

		<Extension()>
		Public Function IsInteger(ByVal x As Double) As Boolean
			Return x.IsEqualTo(Math.Round(x))
		End Function

		<Extension()>
		Public Function IsOdd(ByVal x As Double) As Boolean
			If Not x.IsInteger() Then Throw New Exception("X must be Integer.")
			Return (Math.Ceiling(Math.Round(x) / 2) * 2).IsEqualTo(Math.Round(x))
		End Function

		<Extension()>
		Public Function IsNaN(ByVal x As Double) As Boolean
			Return Double.IsNaN(x)
		End Function

		<Extension()>
		Public Function IsInfinity(ByVal x As Double) As Boolean
			Return Double.IsInfinity(x)
		End Function

		<Extension()>
		Public Function IsPositiveInfinity(ByVal x As Double) As Boolean
			Return Double.IsPositiveInfinity(x)
		End Function

		<Extension()>
		Public Function IsNegativeInfinity(ByVal x As Double) As Boolean
			Return Double.IsNegativeInfinity(x)
		End Function

	End Module

End Namespace