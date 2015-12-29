Imports System.Collections.ObjectModel

Namespace Utilities.Interfaces
	Public Interface IViewRangeProvider
		' Точки X, якi повинні бути видимими на графіку за замовченням
		ReadOnly Property XViewPoints() As ReadOnlyCollection(Of Double)

		' Точки Y, якi повинні бути видимими на графіку за замовченням
		ReadOnly Property YViewPoints() As ReadOnlyCollection(Of Double)
	End Interface
End NameSpace