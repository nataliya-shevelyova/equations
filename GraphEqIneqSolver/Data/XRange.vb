Imports GraphEqIneqSolver.Extenders

Namespace Data

	Public Structure XRange
		Implements IEquatable(Of XRange)

		Public ReadOnly Min As Double
		Public ReadOnly Max As Double

		Sub New(ByVal min As Double, ByVal max As Double)
			Me.Min = min
			Me.Max = max
		End Sub

		Public ReadOnly Property Size() As Double
			Get
				Size = Max - Min
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return String.Format("Min: {0}, Max: {1}", Min, Max)
		End Function

		Public Overloads Function Equals(ByVal other As XRange) As Boolean Implements IEquatable(Of XRange).Equals
			Return Min.IsEqualTo(other.Min) AndAlso Max.IsEqualTo(other.Max)
		End Function

		Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
			If ReferenceEquals(Nothing, obj) Then Return False
			Return TypeOf obj Is XRange AndAlso Equals(DirectCast(obj, XRange))
		End Function

		Public Overrides Function GetHashCode() As Integer
			Dim hashCode As Integer = Min.HashCode
			hashCode = CInt((hashCode * 397L) Mod Integer.MaxValue) Xor Max.HashCode
			Return hashCode
		End Function

		Public Shared Operator =(ByVal left As XRange, ByVal right As XRange) As Boolean
			Return left.Equals(right)
		End Operator

		Public Shared Operator <>(ByVal left As XRange, ByVal right As XRange) As Boolean
			Return Not left.Equals(right)
		End Operator

	End Structure

End Namespace