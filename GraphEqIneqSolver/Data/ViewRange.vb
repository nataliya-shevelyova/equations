Namespace Data

	' Задає видиму частину графіка
	Public Structure ViewRange

		Public ReadOnly XMin As Double
		Public ReadOnly XMax As Double
		Public ReadOnly YMin As Double
		Public ReadOnly YMax As Double

		Sub New(ByVal xMin As Double, ByVal xMax As Double, ByVal yMin As Double, ByVal yMax As Double)
			Me.XMin = xMin
			Me.XMax = xMax
			Me.YMin = yMin
			Me.YMax = yMax
		End Sub

	End Structure

End Namespace
