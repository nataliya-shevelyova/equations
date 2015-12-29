Imports System.Collections.ObjectModel
Imports System.Drawing.Drawing2D
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports GraphEqIneqSolver.Functions.Interfaces
Imports ZedGraph

Namespace Utilities.Classes

	Public Class RenderEngine
		Implements IRenderEngine

		Private ReadOnly _graphControl As ZedGraphControl

		Sub New(ByVal graphControl As ZedGraphControl)
			_graphControl = graphControl
		End Sub

		Private Function GetLimits() As ViewRange

			' Мінимальна та максимальна видими точки по осі X та Y
			Dim xMax = _graphControl.GraphPane.XAxis.Scale.Max
			Dim xMin = _graphControl.GraphPane.XAxis.Scale.Min
			Dim yMax = _graphControl.GraphPane.YAxis.Scale.Max
			Dim yMin = _graphControl.GraphPane.YAxis.Scale.Min

			Dim yUnitsPerPixel = (yMax - yMin) / _graphControl.ChartHeight
			Dim xUnitsPerPixel = (xMax - xMin) / _graphControl.ChartWidth

			' Вибрати xMin, xMax, yMin, та yMax, так щоб вони знаходились у будь-якому випадку за видимою частиною графіку
			' Висота екрану використовується через те, що користувач може "рухати" графік за допомогою Ctrl+Drag
			yMax += Screens.Height * yUnitsPerPixel
			yMin -= Screens.Height * yUnitsPerPixel
			xMax += Screens.Width * xUnitsPerPixel
			xMin -= Screens.Width * xUnitsPerPixel

			Return New ViewRange(xMin, xMax, yMin, yMax)

		End Function

		Private Function GetXUnitsPerPixel() As Double
			Dim xMax = _graphControl.GraphPane.XAxis.Scale.Max
			Dim xMin = _graphControl.GraphPane.XAxis.Scale.Min
			Return (xMax - xMin) / _graphControl.ChartWidth
		End Function

		Private Function LimitY(ByVal y As Double, ByVal limits As ViewRange) As Double
			If y.IsNaN Then Return Double.NaN
			Return Math.Max(Math.Min(y, limits.YMax), limits.YMin)
		End Function

		Private Sub ApplyStyle(ByVal curve As LineItem, ByVal width As Double, ByVal color As Color)

			curve.Line.IsAntiAlias = True
			curve.Line.Width = width
			curve.Symbol.IsAntiAlias = False
			curve.Line.IsSmooth = False
			curve.Symbol.Size = width / 2.0
			curve.Symbol.Border.Color = color
			curve.Symbol.Fill.Brush = New SolidBrush(color)
			curve.Symbol.Fill.IsVisible = True

		End Sub

		Private Sub ApplyStyle(ByVal polyObj As PolyObj)
			polyObj.ZOrder = ZOrder.E_BehindCurves
			polyObj.IsClippedToChartRect = True
			polyObj.Border.IsVisible = False
		End Sub

		Private Sub PlotCurve(ByVal func As IFunction, ByVal name As String, ByVal color As Color, ByVal xRange As XRange, Optional ByVal width As Double = 3)

			Dim zedPoints = New PointPairList()
			Dim limits = GetLimits()

			' Вибрати число точок на графіку так, щоб кожен піксел на екрані мав свою точку
			Dim numPoints As Integer = xRange.Size / GetXUnitsPerPixel()

			' Заповниити xPoints та yPoints
			Dim xStep = xRange.Size / (numPoints - 1) ' Розмір кроку по осі Х
			For i = 0 To numPoints - 1
				Dim x = xRange.Min + i * xStep
				Dim y = LimitY(func.GetY(x, xRange), limits)
				If y.IsNaN Then	' Не вважати NaN за коректне значення

					If zedPoints.Any Then

						' Додати криву
						_graphControl.GraphPane.AddCurve(name, zedPoints, color, SymbolType.Circle)
						ApplyStyle(_graphControl.GraphPane.CurveList.Last(), width, color)

						zedPoints = New PointPairList()
						name = Nothing

					End If

				Else
					zedPoints.Add(x, y)
				End If
			Next

			' Додати криву
			If zedPoints.Any() Or Not name Is Nothing Then
				_graphControl.GraphPane.AddCurve(name, zedPoints, color, SymbolType.Circle)
				ApplyStyle(_graphControl.GraphPane.CurveList.Last(), width, color)
			End If

		End Sub

		Private Sub PlotPoints(ByVal func As IFunction, ByVal points As ReadOnlyCollection(Of Double), ByVal name As String, ByVal color As Color, Optional ByVal width As Double = 3)

			If Not points.Any Then Exit Sub

			Dim zedPoints = New NoDupePointList()
			Dim limits = GetLimits()

			For Each x In (From t In points Where Not t.IsEqualTo(limits.XMin) AndAlso Not t.IsEqualTo(limits.XMax))
				Dim y = LimitY(func.GetY(x), limits)
				If Not y.IsNaN Then zedPoints.Add(x, y)
			Next

			If zedPoints.Any Then
				' Додати "криву", сховати лінії, відображати лише точки
				_graphControl.GraphPane.AddCurve(name, zedPoints, color, SymbolType.Circle)
				Dim curve = DirectCast(_graphControl.GraphPane.CurveList.Last(), LineItem)
				curve.Line.IsVisible = False
				curve.Symbol.Size = 10
				curve.Symbol.IsAntiAlias = True
				curve.Symbol.Border.Color = color
				curve.Symbol.Fill.Brush = New SolidBrush(color)
				curve.Symbol.Fill.IsVisible = True
			ElseIf Not name Is Nothing Then
				_graphControl.GraphPane.AddCurve(name, zedPoints, color, SymbolType.Circle)
				ApplyStyle(_graphControl.GraphPane.CurveList.Last(), width, color)
			End If

		End Sub

		Public Sub PlotPoly(ByVal func As IFunction, ByVal inequalityType As InequalityType, ByVal color As Color, ByVal xRange As XRange)

			Dim zedPoints = New List(Of PointD)()
			Dim limits = GetLimits()

			Dim infinity = Double.NegativeInfinity
			If inequalityType = inequalityType.Greater Or inequalityType = inequalityType.GreaterOrEqual Then infinity = Double.PositiveInfinity
			infinity = LimitY(infinity, limits)

			' Вибрати число точок на графіку так, щоб кожен піксел на екрані мав свою точку
			Dim numPoints As Integer = xRange.Size / GetXUnitsPerPixel()
			Dim xMax = xRange.Min
			Dim polyObj As PolyObj

			' Заповниити xPoints та yPoints
			Dim xStep = xRange.Size / (numPoints - 1) ' Розмір кроку по осі Х
			For i = 0 To numPoints - 1

				Dim x = xRange.Min + i * xStep
				Dim y = LimitY(func.GetY(x, xRange), limits)

				If y.IsNaN Then	' Не вважати NaN за коректне значення
					If zedPoints.Any Then
						zedPoints.Add(New PointD(xMax, infinity))
						xMax = xRange.Min
						polyObj = New PolyObj(zedPoints.ToArray, color, color)
						_graphControl.GraphPane.GraphObjList.Add(polyObj)
						ApplyStyle(polyObj)
						zedPoints = New List(Of PointD)()
					End If
					Continue For
				End If

				If zedPoints.Count = 0 Then zedPoints.Add(New PointD(x, infinity))
				xMax = Math.Max(x, xMax)
				zedPoints.Add(New PointD(x, y))

			Next

			If zedPoints.Any Then
				zedPoints.Add(New PointD(xMax, infinity))
				polyObj = New PolyObj(zedPoints.ToArray, color, color)
				_graphControl.GraphPane.GraphObjList.Add(polyObj)
				ApplyStyle(polyObj)
			End If

		End Sub

		Private Function PlotVerticalLine(ByVal func As IFunction, ByVal inequalityType As InequalityType, ByVal name As String, ByVal x As Double, ByVal color As Color) As Boolean

			Dim limits = GetLimits()
			Dim opaqueColor = color.FromArgb(255, color)

			Dim infinity = Double.NegativeInfinity
			If inequalityType = inequalityType.Greater Or inequalityType = inequalityType.GreaterOrEqual Then infinity = Double.PositiveInfinity
			infinity = LimitY(infinity, limits)

			Dim y = LimitY(func.GetY(x), limits)

			If Not y.IsNaN AndAlso Not y.IsEqualTo(infinity) Then ' Не вважати NaN за коректне значення
				Dim lineXPoints = New Double() {x, x}
				Dim lineYPoints = New Double() {y, infinity}
				_graphControl.GraphPane.AddCurve(name, lineXPoints, lineYPoints, opaqueColor, SymbolType.Circle)
				Dim curve = CType(_graphControl.GraphPane.CurveList.Last(), LineItem)
				ApplyStyle(curve, 2.5, color)
				curve.Symbol.IsAntiAlias = True
				curve.Symbol.Size = 10
				curve.Symbol.Border.Color = opaqueColor
				curve.Symbol.Fill.Brush = New SolidBrush(opaqueColor)
				curve.Symbol.Fill.IsVisible = True
				curve.Symbol.IsVisible = True
				Return True
			End If

			Return False

		End Function

		Private Function PlotVerticalDashLine(ByVal func As IFunction, ByVal inequalityType As InequalityType, ByVal name As String, ByVal x As Double, ByVal color As Color) As Boolean

			Dim limits = GetLimits()
			Dim opaqueColor = color.FromArgb(255, color)

			Dim infinity = Double.NegativeInfinity
			If inequalityType = inequalityType.Greater Or inequalityType = inequalityType.GreaterOrEqual Then infinity = Double.PositiveInfinity
			infinity = LimitY(infinity, limits)

			Dim y = LimitY(func.GetY(x), limits)

			If Not y.IsNaN AndAlso Not y.IsEqualTo(infinity) Then ' Не вважати NaN за коректне значення
				Dim lineXPoints = New Double() {x, x}
				Dim lineYPoints = New Double() {y, infinity}
				_graphControl.GraphPane.AddCurve(name, lineXPoints, lineYPoints, opaqueColor, SymbolType.Circle)
				Dim curve = CType(_graphControl.GraphPane.CurveList.Last(), LineItem)
				curve.Line.IsAntiAlias = True
				curve.Line.IsSmooth = True
				curve.Line.Width = 2.5
				curve.Line.Style = DashStyle.Custom
				curve.Line.DashOn = 3
				curve.Line.DashOff = 2
				curve.Symbol.IsAntiAlias = True
				curve.Symbol.Size = 10
				curve.Symbol.Border.Color = opaqueColor
				curve.Symbol.Border.Width = 2.5
				curve.Symbol.Fill.IsVisible = False
				curve.Symbol.IsVisible = True
				Return True
			End If

			Return False

		End Function

		Public Sub PlotFunction(ByVal func As IFunction, ByVal name As String, ByVal color As Color, ByVal xRange As XRange, Optional ByVal width As Double = 3) Implements IRenderEngine.PlotFunction

			Dim ranges = func.GetRanges(xRange)
			Dim xPoints = New List(Of Double)

			For Each range In From t In ranges
			 Where Not t.Min.IsNaN And Not t.Min.IsInfinity And
			 Not t.Max.IsNaN And Not t.Max.IsInfinity

				' Крива або точка?
				If Not range.Size.IsZero Then
					PlotCurve(func, name, color, range, width)
					name = Nothing
				Else
					xPoints.Add(range.Min)
				End If

			Next

			xPoints.Sort()
			PlotPoints(func, xPoints.AsReadOnly, name, color, width)

		End Sub

		Private Sub FillRegion(ByVal func As IFunction, ByVal inequalityType As InequalityType, ByVal name As String, ByVal color As Color, ByVal xRange As XRange, Optional ByVal noLines As Boolean = False) Implements IRenderEngine.FillRegion

			Dim ranges = (From v In ((From t In func.GetRanges(xRange)
			 Where Not t.Min.IsNaN And Not t.Min.IsInfinity And
			 Not t.Max.IsNaN And Not t.Max.IsInfinity).Distinct) _
			 Order By v.Min, v.Max).ToList.AsReadOnly

			Dim mins = (From r In ranges Where Not r.Size.IsZero Select t = r.Min Where Not func.GetY(t).IsNaN).ToList.AsReadOnly
			Dim maxs = (From r In ranges Where Not r.Size.IsZero Select t = r.Max Where Not func.GetY(t).IsNaN).ToList.AsReadOnly

			Dim min = Double.NaN
			Dim max = Double.NaN
			If mins.Any Then min = mins.Min()
			If maxs.Any Then max = maxs.Max()

			For i = 0 To ranges.Count - 1
				Dim range = ranges(i)
				While i < ranges.Count - 1 AndAlso _
				 (inequalityType = inequalityType.LessOrEqual Or inequalityType = inequalityType.GreaterOrEqual) AndAlso _
				 range.Max.IsEqualTo(ranges(i + 1).Min)
					range = New XRange(range.Min, ranges(i + 1).Max)
					i = i + 1
				End While
				If Not range.Size.IsZero Then
					PlotPoly(func, inequalityType, color, range)
					If (inequalityType = inequalityType.Greater OrElse inequalityType = inequalityType.Less) AndAlso Not noLines Then
						If PlotVerticalDashLine(func, inequalityType, name, range.Min, color) Then name = Nothing
					End If
				End If
				If (inequalityType = inequalityType.GreaterOrEqual OrElse inequalityType = inequalityType.LessOrEqual) AndAlso Not noLines Then
					If Not range.Min.IsEqualTo(min) AndAlso Not range.Min.IsEqualTo(max) Then
						If PlotVerticalLine(func, inequalityType, name, range.Min, color) Then name = Nothing
					End If
				End If
			Next

			If Not noLines Then
				If inequalityType = inequalityType.GreaterOrEqual Or inequalityType = inequalityType.LessOrEqual Then

					Dim opaqueColor = color.FromArgb(255, color)
					For i = 0 To ranges.Count - 1
						Dim range = ranges(i)
						While i < ranges.Count - 1 AndAlso _
						 (inequalityType = inequalityType.LessOrEqual Or inequalityType = inequalityType.GreaterOrEqual) AndAlso _
						 range.Max.IsEqualTo(ranges(i + 1).Min)
							range = New XRange(range.Min, ranges(i + 1).Max)
							i = i + 1
						End While
						If range.Size.IsZero Then
							If PlotVerticalLine(func, inequalityType, name, range.Min, color) Then name = Nothing
						Else
							PlotCurve(func, name, opaqueColor, range, 2.5)
							name = Nothing
						End If
					Next

					If PlotVerticalLine(func, inequalityType, name, min, color) Then name = Nothing
					If PlotVerticalLine(func, inequalityType, name, max, color) Then name = Nothing

					Dim xPoints = (From r In ranges Where r.Size.IsZero Select t = r.Min).ToList.AsReadOnly
					PlotPoints(func, xPoints, name, opaqueColor)

				Else

					Dim lineXPoints = New Double() {}
					Dim lineYPoints = New Double() {}
					_graphControl.GraphPane.AddCurve(name, lineXPoints, lineYPoints, color.FromArgb(255, color))
					ApplyStyle(_graphControl.GraphPane.CurveList.Last(), 2.5, color)

				End If
			Else
				Dim lineXPoints = New Double() {}
				Dim lineYPoints = New Double() {}
				_graphControl.GraphPane.AddCurve(name, lineXPoints, lineYPoints, color.FromArgb(255, color))
				ApplyStyle(_graphControl.GraphPane.CurveList.Last(), 2.5, color)
			End If

		End Sub

	End Class

End Namespace