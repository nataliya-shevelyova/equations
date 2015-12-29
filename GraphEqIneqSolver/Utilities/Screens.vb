Namespace Utilities

	Public Class Screens

		Public Shared ReadOnly Height As Double
		Public Shared ReadOnly Width As Double

		Shared Sub New()

			Dim left = Integer.MaxValue
			Dim right = Integer.MinValue
			Dim top = Integer.MaxValue
			Dim bottom = Integer.MinValue

			For Each s In Windows.Forms.Screen.AllScreens

				If left > s.Bounds.Left Then left = s.Bounds.Left
				If right < s.Bounds.Right Then right = s.Bounds.Right
				If bottom < s.Bounds.Bottom Then bottom = s.Bounds.Bottom
				If top > s.Bounds.Top Then top = s.Bounds.Top

			Next

			Width = right - left
			Height = bottom - top

		End Sub

	End Class

End Namespace