Imports System.Runtime.CompilerServices
Imports ZedGraph

Namespace Extenders

	Module ZedGraphControlExt

		<Extension()>
		Public Function ChartWidth(ByVal graphControl As ZedGraphControl) As Double
			Return graphControl.GraphPane.Rect.Width - graphControl.GraphPane.Margin.Left - graphControl.GraphPane.Margin.Right - 32
		End Function

		<Extension()>
		Public Function ChartHeight(ByVal graphControl As ZedGraphControl) As Double
			Return graphControl.GraphPane.Rect.Height - graphControl.GraphPane.Margin.Top - graphControl.GraphPane.Margin.Bottom - 32
		End Function

	End Module

End Namespace