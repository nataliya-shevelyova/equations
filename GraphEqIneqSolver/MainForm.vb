Imports GraphEqIneqSolver.Functions.Classes
Imports GraphEqIneqSolver.Inequalities.Classes
Imports GraphEqIneqSolver.Data
Imports GraphEqIneqSolver.ViewModels.Classes
Imports GraphEqIneqSolver.Equations.Classes
Imports GraphEqIneqSolver.Extenders
Imports GraphEqIneqSolver.Utilities.Interfaces
Imports GraphEqIneqSolver.ViewModels.Interfaces
Imports GraphEqIneqSolver.Equations.Interfaces
Imports GraphEqIneqSolver.Inequalities.Interfaces
Imports GraphEqIneqSolver.Equations.Classes.Wrappers
Imports GraphEqIneqSolver.Inequalities.Classes.Wrapers
Imports ZedGraph

Public Class MainForm

#Region "Data"

	Private Enum Mode
		ApplyViewModel
		InvalidParameters
		SelectViewModel
		Normal
	End Enum

	' Співвідношення видимої одиниці графіка по вертикалі до одиниці графіка по горізонталі
	Private ReadOnly _aspects As List(Of Double) = New List(Of Double)()

	Private ReadOnly _viewModels As List(Of IViewModel) = New List(Of IViewModel)()
	Private ReadOnly _lines As List(Of List(Of ILine)) = New List(Of List(Of ILine))
	Private ReadOnly _viewRanges As List(Of ViewRange) = New List(Of ViewRange)()
	Private ReadOnly _modes As List(Of Mode) = New List(Of Mode)()
	Private ReadOnly _chkAutoRefresh As List(Of RibbonCheckBox) = New List(Of RibbonCheckBox)()
	Private ReadOnly _cmdRefresh As List(Of RibbonButton) = New List(Of RibbonButton)()
	Private ReadOnly _tempLines As List(Of ILine) = New List(Of ILine)

	Private Structure Model

		Public ReadOnly Index As Integer
		Public ReadOnly Current As IViewModel

		Sub New(ByVal index As Integer, ByVal current As IViewModel)
			Me.Index = index
			Me.Current = current
		End Sub

	End Structure

	Private ReadOnly Property ViewModel() As Model
		Get
			If _viewModels.Any() Then
				Dim tab = rbnMain.ActiveTab
				If ReferenceEquals(tab, rbtEquations) Then Return New Model(0, _viewModels(0))
				If ReferenceEquals(tab, rbtInequalities) Then Return New Model(1, _viewModels(1))
				If ReferenceEquals(tab, rbtEquationsSystems) Then Return New Model(2, _viewModels(2))
				If ReferenceEquals(tab, rbtInEqualitiesSystems) Then Return New Model(3, _viewModels(3))
			End If
			Return New Model(-1, Nothing)
		End Get
	End Property

	Private _equationAccessor As Func(Of IEquation)
	Private _inequalityAccessor As Func(Of IInequality)
	Private _systemEquation1Accessor As Func(Of SystemEquationWrapper)
	Private _systemEquation2Accessor As Func(Of SystemEquationWrapper)
	Private _systemInequality1Accessor As Func(Of SystemInequalityWrapper)
	Private _systemInequality2Accessor As Func(Of SystemInequalityWrapper)

#End Region

#Region "Form Initialization"

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        ' Розміри
        rbnMain.Font = New Font("Segoe UI", 12.0!)
        MinimumSize = New Size(1024, 480)
        For Each textBox In New RibbonTextBox() {rbTxtEqA, rbTxtEqB, rbTxtEqC, rbTxtEqD, rbTxtInEqA, rbTxtInEqB, rbTxtInEqC, rbTxtInEqD}
            textBox.LabelWidth = 33
            textBox.TextBoxWidth = 122
        Next
        rbnMain.Size = New Size(0, 500)
        rbnMain.OrbDropDown.Size = New Size(128, 100)

        ' Налаштувати вигляд графіка
        zedMain.GraphPane.Border.IsVisible = False
        zedMain.GraphPane.IsFontsScaled = False
        zedMain.GraphPane.Title.IsVisible = False
        zedMain.GraphPane.XAxis.Scale.IsSkipCrossLabel = True
        zedMain.GraphPane.XAxis.Scale.IsSkipFirstLabel = True
        zedMain.GraphPane.XAxis.Scale.IsSkipLastLabel = True
        zedMain.GraphPane.YAxis.Scale.IsSkipCrossLabel = True
        zedMain.GraphPane.YAxis.Scale.IsSkipFirstLabel = True
        zedMain.GraphPane.YAxis.Scale.IsSkipLastLabel = True
        zedMain.GraphPane.YAxis.Scale.FontSpec.Size = 10
        zedMain.GraphPane.XAxis.Scale.FontSpec.Size = 10
        zedMain.GraphPane.XAxis.Scale.MinAuto = False
        zedMain.GraphPane.XAxis.Scale.MaxAuto = False
        zedMain.GraphPane.XAxis.CrossAuto = False
        zedMain.GraphPane.YAxis.CrossAuto = False
        zedMain.GraphPane.XAxis.Cross = 0
        zedMain.GraphPane.YAxis.Cross = 0
        zedMain.GraphPane.XAxis.MajorGrid.IsVisible = True
        zedMain.GraphPane.YAxis.MajorGrid.IsVisible = True
        zedMain.GraphPane.XAxis.Title.IsTitleAtCross = False
        zedMain.GraphPane.YAxis.Title.IsTitleAtCross = False
        zedMain.GraphPane.XAxis.Title.Text = "X"
        zedMain.GraphPane.YAxis.Title.Text = "Y"
        zedMain.GraphPane.Margin.Top = 25
        zedMain.GraphPane.Legend.FontSpec.Size = 16
        zedMain.GraphPane.Legend.Fill.Brush = Brushes.AliceBlue
        zedMain.GraphPane.Legend.Border.InflateFactor = 3
        zedMain.GraphPane.Legend.Border.Width = 1
        zedMain.GraphPane.Legend.IsHStack = False
        zedMain.GraphPane.Legend.Position = LegendPos.Float
        zedMain.GraphPane.Legend.Location.CoordinateFrame = CoordType.ChartFraction
        zedMain.GraphPane.Legend.Location.TopLeft = New PointF(20 / zedMain.ChartWidth, 20 / zedMain.ChartHeight)

        For Each label In New Control() {lblInvalidParameters, lblSelect, lblApply}
            label.Top = zedMain.Top + (zedMain.Height - label.Height) / 2
            label.Left = zedMain.Left + (zedMain.Width - label.Width) / 2
        Next

        _chkAutoRefresh.Add(rbChkEqAutoRefresh)
        _chkAutoRefresh.Add(rbChkInEqAutoRefresh)
        _chkAutoRefresh.Add(rbChkEqSysAutoRefresh)
        _chkAutoRefresh.Add(rbChkInEqSysAutoRefresh)
        _cmdRefresh.Add(rbCmdEqRefresh)
        _cmdRefresh.Add(rbCmdInEqRefresh)
        _cmdRefresh.Add(rbCmdEqSysRefresh)
        _cmdRefresh.Add(rbCmdInEqSysRefresh)

        ' Ініціалізація початкового стану
        For Each i In Enumerable.Range(0, 4)
            _aspects.Add(1)
            _lines.Add(New List(Of ILine)())
            _viewModels.Add(Nothing)
            _viewRanges.Add(New ViewRange(0, 1, 0, 1))
            _modes.Add(Mode.SelectViewModel)
        Next
        EnterSelectViewModelMode()
        DisableAllEqParameters()
        DisableAllIneqParameters()
        DisableAllEqSysParameters1()
        DisableAllEqSysParameters2()
        DisableAllInEqSysParameters1()
        DisableAllInEqSysParameters2()
        For Each button In _cmdRefresh
            button.Enabled = False
        Next
        UpdateSolutions(rbpEqSolution, rbLblEqXVal, rbLblEqYVal, Nothing)
        UpdateSolutions(rbpInEqSolution, rbLblInEqXVal, rbLblInEqYVal, Nothing)

    End Sub

#End Region

#Region "Parameters Accessors"

	Private Function ReadParameter(ByVal textBox As RibbonTextBox) As Double
		If String.IsNullOrEmpty(textBox.TextBoxText) Or textBox.TextBoxText.Trim() = "-" Then Return 0
		Dim s = textBox.TextBoxText.Trim()
		If s.EndsWith("e") Then s += "0"
		Dim res = Double.Parse(s)
		If Math.Abs(res) < 0.000000001 And Not res.Equals(0) Then Throw New Exception()
		Return res
	End Function

	' Повертає параметр А. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqA() As Double
		Get
			Return ReadParameter(rbTxtEqA)
		End Get
	End Property

	' Повертає параметр B. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqB() As Double
		Get
			Return ReadParameter(rbTxtEqB)
		End Get
	End Property

	' Повертає параметр C. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqC() As Double
		Get
			Return ReadParameter(rbTxtEqC)
		End Get
	End Property

	' Повертає параметр D. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqD() As Double
		Get
			Return ReadParameter(rbTxtEqD)
		End Get
	End Property

	' Повертає параметр А. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property IneqA() As Double
		Get
			Return ReadParameter(rbTxtInEqA)
		End Get
	End Property

	' Повертає параметр B. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property IneqB() As Double
		Get
			Return ReadParameter(rbTxtInEqB)
		End Get
	End Property

	' Повертає параметр C. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property IneqC() As Double
		Get
			Return ReadParameter(rbTxtInEqC)
		End Get
	End Property

	' Повертає параметр D. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property IneqD() As Double
		Get
			Return ReadParameter(rbTxtInEqD)
		End Get
	End Property

	' Повертає параметр А. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysA1() As Double
		Get
			Return ReadParameter(rbTxtEqSysA1)
		End Get
	End Property

	' Повертає параметр B. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysB1() As Double
		Get
			Return ReadParameter(rbTxtEqSysB1)
		End Get
	End Property

	' Повертає параметр C. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysC1() As Double
		Get
			Return ReadParameter(rbTxtEqSysC1)
		End Get
	End Property

	' Повертає параметр D. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysD1() As Double
		Get
			Return ReadParameter(rbTxtEqSysD1)
		End Get
	End Property

	' Повертає параметр А. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysA2() As Double
		Get
			Return ReadParameter(rbTxtEqSysA2)
		End Get
	End Property

	' Повертає параметр B. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysB2() As Double
		Get
			Return ReadParameter(rbTxtEqSysB2)
		End Get
	End Property

	' Повертає параметр C. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysC2() As Double
		Get
			Return ReadParameter(rbTxtEqSysC2)
		End Get
	End Property

	' Повертає параметр D. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property EqSysD2() As Double
		Get
			Return ReadParameter(rbTxtEqSysD2)
		End Get
	End Property

	' Повертає параметр А. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysA1() As Double
		Get
			Return ReadParameter(rbTxtInEqSysA1)
		End Get
	End Property

	' Повертає параметр B. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysB1() As Double
		Get
			Return ReadParameter(rbTxtInEqSysB1)
		End Get
	End Property

	' Повертає параметр C. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysC1() As Double
		Get
			Return ReadParameter(rbTxtInEqSysC1)
		End Get
	End Property

	' Повертає параметр D. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysD1() As Double
		Get
			Return ReadParameter(rbTxtInEqSysD1)
		End Get
	End Property

	' Повертає параметр А. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysA2() As Double
		Get
			Return ReadParameter(rbTxtInEqSysA2)
		End Get
	End Property

	' Повертає параметр B. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysB2() As Double
		Get
			Return ReadParameter(rbTxtInEqSysB2)
		End Get
	End Property

	' Повертає параметр C. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysC2() As Double
		Get
			Return ReadParameter(rbTxtInEqSysC2)
		End Get
	End Property

	' Повертає параметр D. Якщо параметр задан некоректно, викликає виключну ситуацію.
	Private ReadOnly Property InEqSysD2() As Double
		Get
			Return ReadParameter(rbTxtInEqSysD2)
		End Get
	End Property

#End Region

#Region "Recalculation and Updating"

	Private Sub UpdateGraphObjects()

		If ViewModel.Current Is Nothing Then Exit Sub

		ViewModel.Current.Render()

		For Each line In _lines(ViewModel.Index).Concat(_tempLines)
			line.Plot(zedMain.GraphPane)
		Next

		zedMain.Invalidate()

	End Sub

	Private Sub UpdateSolutions(ByVal panel As RibbonPanel, ByVal lblX As RibbonLabel, ByVal lblY As RibbonLabel, ByVal viewModel As IViewModel)

		If Not viewModel Is Nothing Then

			panel.Items.Clear()

			Dim solutions = viewModel.GetSolutions()
			For Each solution In solutions

				Dim label = New RibbonLabel
				label.LabelWidth = lblX.LabelWidth
				label.TextAlignment = RibbonItem.RibbonItemTextAlignment.Center
				label.Text = solution
				panel.Items.Add(label)

			Next

			If solutions.Any Then panel.Items.Add(New RibbonLabel)

		Else
			panel.Items.Clear()
		End If

		panel.Items.Add(lblX)
		panel.Items.Add(lblY)

		' Наступні 2 строки еквівалентні відсутній функції rbpEqSolution.Invalidate()
		panel.Visible = False
		panel.Visible = True

	End Sub

	Private Sub UpdateSolutions(ByVal viewModel As IViewModel)
		Dim tab = rbnMain.ActiveTab
		If ReferenceEquals(tab, rbtEquations) Then
			UpdateSolutions(rbpEqSolution, rbLblEqXVal, rbLblEqYVal, viewModel)
		ElseIf ReferenceEquals(tab, rbtInequalities) Then
			UpdateSolutions(rbpInEqSolution, rbLblInEqXVal, rbLblInEqYVal, viewModel)
		ElseIf ReferenceEquals(tab, rbtEquationsSystems) Then
			UpdateSolutions(rbpEqSysSolution, rbLblEqSysXVal, rbLblEqSysYVal, viewModel)
		ElseIf ReferenceEquals(tab, rbtInEqualitiesSystems) Then
			UpdateSolutions(rbpInEqSysSolution, rbLblInEqSysXVal, rbLblInEqSysYVal, viewModel)
		End If
	End Sub

	Private Property CurrentViewRange() As ViewRange
		Get
			Return New ViewRange(
			 zedMain.GraphPane.XAxis.Scale.Min, _
			 zedMain.GraphPane.XAxis.Scale.Max, _
			 zedMain.GraphPane.YAxis.Scale.Min, _
			 zedMain.GraphPane.YAxis.Scale.Max)
		End Get
		Set(viewRange As ViewRange)
			zedMain.GraphPane.XAxis.Scale.Min = viewRange.XMin
			zedMain.GraphPane.XAxis.Scale.Max = viewRange.XMax
			zedMain.GraphPane.YAxis.Scale.Min = viewRange.YMin
			zedMain.GraphPane.YAxis.Scale.Max = viewRange.YMax
			zedMain.AxisChange()
			zedMain.Invalidate()
		End Set
	End Property

	Private Sub UpdateViewRange()

		If ViewModel.Index < 0 Then Exit Sub

		_aspects(ViewModel.Index) = 1

		Dim viewRange = New ViewRange(0, 1, 0, 1)
		If Not ViewModel.Current Is Nothing Then viewRange = ViewModel.Current.CalculateViewRange()

		CurrentViewRange = viewRange

	End Sub

	Private Sub ClearGraph(Optional removeTangentialLines As Boolean = True)

		Dim pane = zedMain.GraphPane
		pane.CurveList.Clear()
		pane.GraphObjList.Clear()

		If removeTangentialLines Then
			If ViewModel.Index > 0 Then
				_lines(ViewModel.Index).Clear()
			End If
			_tempLines.Clear()
		End If

		zedMain.Invalidate()

	End Sub

	Private Sub Recalculate()

		Try
			_viewModels(ViewModel.Index) = CreateViewModel()
			_lines(ViewModel.Index).Clear()

			ClearGraph()
			' Перерахувати видиму частину графіку
			UpdateViewRange()
			' Перебудувати графік
			UpdateGraphObjects()

			If ViewModel.Current Is Nothing Then
				EnterSelectViewModelMode()
			Else
				EnterNormalMode()
			End If

		Catch
			EnterInvalidParametersMode()
		End Try

	End Sub

	Private Function CreateViewModel() As IViewModel
		Dim res As IViewModel = Nothing
		Dim tab = rbnMain.ActiveTab
		If ReferenceEquals(tab, rbtEquations) Then
			If Not _equationAccessor Is Nothing Then res = New EquationViewModel(zedMain, _equationAccessor())
		ElseIf ReferenceEquals(tab, rbtInequalities) Then
			If Not _inequalityAccessor Is Nothing Then res = New InequalityViewModel(zedMain, _inequalityAccessor())
		ElseIf ReferenceEquals(tab, rbtEquationsSystems) Then
			If Not _systemEquation1Accessor Is Nothing AndAlso Not _systemEquation2Accessor Is Nothing Then
				res = New EquationsSystemViewModel(zedMain, _systemEquation1Accessor(), _systemEquation2Accessor())
			End If
		ElseIf ReferenceEquals(tab, rbtInEqualitiesSystems) Then
			If Not _systemInequality1Accessor Is Nothing AndAlso Not _systemInequality2Accessor Is Nothing Then
				res = New InequalitiesSystemViewModel(zedMain, _systemInequality1Accessor(), _systemInequality2Accessor())
			End If
		End If
		Return res
	End Function

#End Region

#Region "Resizing and Zooming"

	Private Sub zedMain_ZoomEvent(sender As ZedGraphControl, oldState As ZoomState, newState As ZoomState) Handles zedMain.ZoomEvent

		ClearGraph(False)
		UpdateGraphObjects()
		UpdateCoords()

		Dim index = ViewModel.Index
		If index < 0 Then Exit Sub

		Dim xMin = zedMain.GraphPane.XAxis.Scale.Min
		Dim xMax = zedMain.GraphPane.XAxis.Scale.Max
		Dim yMin = zedMain.GraphPane.YAxis.Scale.Min
		Dim yMax = zedMain.GraphPane.YAxis.Scale.Max

		Dim viewAspect = zedMain.ChartHeight / zedMain.ChartWidth
		Dim realViewAspect = (yMax - yMin) / (xMax - xMin)

		_aspects(index) = realViewAspect / viewAspect

	End Sub

	Private Sub MainForm_Resize(sender As System.Object, e As EventArgs) Handles MyBase.Resize

		' Перерахування видимої частини Y осі таким чином, 
		' щоб залишити візуальне співвідношення одиниці по вертикалі к одиниці по горізонталі

		Dim index = ViewModel.Index
		If index < 0 OrElse _aspects(index).IsNaN Then Exit Sub

		Dim xMin = zedMain.GraphPane.XAxis.Scale.Min
		Dim xMax = zedMain.GraphPane.XAxis.Scale.Max
		Dim yMin = zedMain.GraphPane.YAxis.Scale.Min
		Dim yMax = zedMain.GraphPane.YAxis.Scale.Max

		Dim chartHeight = zedMain.ChartHeight
		Dim chartWidth = zedMain.ChartWidth
		Dim viewAspect = chartHeight / chartWidth
		Dim range = (xMax - xMin) * viewAspect * _aspects(index)
		Dim yRangeDiv2 = range / 2
		Dim yCenter = (yMax + yMin) / 2

		zedMain.GraphPane.YAxis.Scale.Min = yCenter - yRangeDiv2
		zedMain.GraphPane.YAxis.Scale.Max = yCenter + yRangeDiv2

		zedMain.GraphPane.Legend.Location.TopLeft = New PointF(20 / chartWidth, 20 / chartHeight)

		For Each label In New Control() {lblInvalidParameters, lblSelect, lblApply}
			label.Top = zedMain.Top + (zedMain.Height - label.Height) / 2
			label.Left = zedMain.Left + (zedMain.Width - label.Width) / 2
		Next

		Invalidate()

	End Sub

#End Region

#Region "Helpers"

	Private Sub EnterNormalMode()
		_modes(ViewModel.Index) = Mode.Normal
		UpdateSolutions(ViewModel.Current)
		_cmdRefresh(ViewModel.Index).Enabled = True
		lblInvalidParameters.Hide()
		zedMain.Show()
		lblSelect.Hide()
		lblApply.Hide()
	End Sub

	Private Sub EnterInvalidParametersMode()
		_modes(ViewModel.Index) = Mode.InvalidParameters
		UpdateSolutions(Nothing)
		_cmdRefresh(ViewModel.Index).Enabled = True
		lblInvalidParameters.Show()
		zedMain.Hide()
		lblSelect.Hide()
		lblApply.Hide()
	End Sub

	Private Sub EnterSelectViewModelMode()
		_modes(ViewModel.Index) = Mode.SelectViewModel
		DisableAllParameters()
		_cmdRefresh(ViewModel.Index).Enabled = False
		UpdateSolutions(Nothing)
		lblInvalidParameters.Hide()
		zedMain.Hide()
		lblSelect.Show()
		lblApply.Hide()
	End Sub

	Private Sub EnterApplyViewModelMode()
		_modes(ViewModel.Index) = Mode.ApplyViewModel
		UpdateSolutions(Nothing)
		_cmdRefresh(ViewModel.Index).Enabled = True
		lblInvalidParameters.Hide()
		zedMain.Hide()
		lblSelect.Hide()
		lblApply.Show()
	End Sub

	Private Sub EnterActiveMode()
		Select Case _modes(ViewModel.Index)
			Case Mode.ApplyViewModel
				EnterApplyViewModelMode()
			Case Mode.Normal
				EnterNormalMode()
			Case Mode.InvalidParameters
				EnterInvalidParametersMode()
			Case Mode.SelectViewModel
				EnterSelectViewModelMode()
		End Select
	End Sub

	Private Sub DisableAllEqParameters()
		rbTxtEqA.Enabled = False
		rbTxtEqB.Enabled = False
		rbTxtEqC.Enabled = False
		rbTxtEqD.Enabled = False
	End Sub

	Private Sub DisableAllIneqParameters()
		rbTxtInEqA.Enabled = False
		rbTxtInEqB.Enabled = False
		rbTxtInEqC.Enabled = False
		rbTxtInEqD.Enabled = False
	End Sub

	Private Sub DisableAllEqSysParameters1()
		rbTxtEqSysA1.Enabled = False
		rbTxtEqSysB1.Enabled = False
		rbTxtEqSysC1.Enabled = False
		rbTxtEqSysD1.Enabled = False
	End Sub

	Private Sub DisableAllEqSysParameters2()
		rbTxtEqSysA2.Enabled = False
		rbTxtEqSysB2.Enabled = False
		rbTxtEqSysC2.Enabled = False
		rbTxtEqSysD2.Enabled = False
	End Sub

	Private Sub DisableAllInEqSysParameters1()
		rbTxtInEqSysA1.Enabled = False
		rbTxtInEqSysB1.Enabled = False
		rbTxtInEqSysC1.Enabled = False
		rbTxtInEqSysD1.Enabled = False
	End Sub

	Private Sub DisableAllInEqSysParameters2()
		rbTxtInEqSysA2.Enabled = False
		rbTxtInEqSysB2.Enabled = False
		rbTxtInEqSysC2.Enabled = False
		rbTxtInEqSysD2.Enabled = False
	End Sub

	Private Sub DisableAllParameters(Optional ByVal panelId As Integer = -1)
		Dim tab = rbnMain.ActiveTab
		If ReferenceEquals(tab, rbtEquations) Then
			DisableAllEqParameters()
		ElseIf ReferenceEquals(tab, rbtInequalities) Then
			DisableAllIneqParameters()
		ElseIf ReferenceEquals(tab, rbtEquationsSystems) Then
			If panelId = 1 Then DisableAllEqSysParameters1() Else DisableAllEqSysParameters2()
		ElseIf ReferenceEquals(tab, rbtInEqualitiesSystems) Then
			If panelId = 1 Then DisableAllIneqSysParameters1() Else DisableAllIneqSysParameters2()
		End If
	End Sub

	Private Function GetMouseCoordsOnGraph() As PointF?

		Dim pos = zedMain.PointToClient(Cursor.Position)

		Dim mousePt As New PointF(pos.X, pos.Y)
		Dim pane As GraphPane = zedMain.MasterPane.FindChartRect(mousePt)

		If Not pane Is Nothing Then
			Dim x As Double, y As Double
			pane.ReverseTransform(mousePt, x, y)
			Return New PointF(x, y)
		Else
			Return Nothing
		End If

	End Function

	Private Sub HideTmpLines()
		Dim tmpLinesCount = _tempLines.Count
		If tmpLinesCount = 0 Then Exit Sub
		Dim count = zedMain.GraphPane.CurveList.Count
		zedMain.GraphPane.CurveList.RemoveRange(count - tmpLinesCount, tmpLinesCount)
		_tempLines.Clear()
		zedMain.Invalidate()
	End Sub

	Private Sub ShowTmpLines()
		For Each line In _tempLines
			line.Plot(zedMain.GraphPane)
		Next
		If _tempLines.Any Then zedMain.Invalidate()
	End Sub

	Private Sub UpdateCoords()

		Dim mousePt = GetMouseCoordsOnGraph()

		If Not mousePt Is Nothing AndAlso Not ViewModel.Current Is Nothing Then

			rbLblEqXVal.Text = "X: " + mousePt.Value.X.Format()
			rbLblEqYVal.Text = "Y: " + mousePt.Value.Y.Format()
			rbLblInEqXVal.Text = "X: " + mousePt.Value.X.Format()
			rbLblInEqYVal.Text = "Y: " + mousePt.Value.Y.Format()
			rbLblEqSysXVal.Text = "X: " + mousePt.Value.X.Format()
			rbLblEqSysYVal.Text = "Y: " + mousePt.Value.Y.Format()
			rbLblInEqSysXVal.Text = "X: " + mousePt.Value.X.Format()
			rbLblInEqSysYVal.Text = "Y: " + mousePt.Value.Y.Format()

		Else

			rbLblEqXVal.Text = "X: ∅"
			rbLblInEqXVal.Text = "X: ∅"
			rbLblEqYVal.Text = "Y: ∅"
			rbLblInEqYVal.Text = "Y: ∅"
			rbLblEqSysXVal.Text = "X: ∅"
			rbLblInEqSysXVal.Text = "X: ∅"
			rbLblEqSysYVal.Text = "Y: ∅"
			rbLblInEqSysYVal.Text = "Y: ∅"

		End If

	End Sub

#End Region

#Region "Mouse Events"

	Private Sub zedMain_MouseEnter(sender As System.Object, e As EventArgs) Handles zedMain.MouseEnter
		zedMain.Focus()
	End Sub

	Dim _prevPoint As PointF?

	Private Sub zedMain_MouseMove(sender As System.Object, e As MouseEventArgs) Handles zedMain.MouseMove

		Dim mousePt = GetMouseCoordsOnGraph()

		If _prevPoint Is Nothing And mousePt Is Nothing Then Exit Sub

		If Not _prevPoint Is Nothing And Not mousePt Is Nothing Then
			If _prevPoint.Value = mousePt.Value Then Exit Sub
		End If

		HideTmpLines()
		UpdateCoords()

		If Not mousePt Is Nothing AndAlso Not ViewModel.Current Is Nothing Then

			If Not ModifierKeys = Keys.None Then
				_tempLines.AddRange(ViewModel.Current.ResolveTangentialLines(mousePt, True))
				ShowTmpLines()
			End If

		End If

		_prevPoint = mousePt
		zedMain.Refresh()

	End Sub

	Private Sub zedMain_KeyUpDown(sender As System.Object, e As Windows.Forms.KeyEventArgs) Handles zedMain.KeyDown
		Dim mousePt = GetMouseCoordsOnGraph()
		HideTmpLines()
		If Not ModifierKeys = Keys.None And Not ViewModel.Current Is Nothing Then
			_tempLines.AddRange(ViewModel.Current.ResolveTangentialLines(mousePt, True))
			ShowTmpLines()
		End If
	End Sub

	Private Sub zedMain_KeyUp(sender As System.Object, e As Windows.Forms.KeyEventArgs) Handles zedMain.KeyUp
		Dim mousePt = GetMouseCoordsOnGraph()
		HideTmpLines()
		If Not ModifierKeys = Keys.None And Not ViewModel.Current Is Nothing Then
			_tempLines.AddRange(ViewModel.Current.ResolveTangentialLines(mousePt, True))
			ShowTmpLines()
		End If
	End Sub

	Private Sub zedMain_MouseLeave(sender As System.Object, e As EventArgs) Handles zedMain.MouseLeave

		HideTmpLines()

		rbLblEqXVal.Text = "X: ∅"
		rbLblInEqXVal.Text = "X: ∅"
		rbLblEqYVal.Text = "Y: ∅"
		rbLblInEqYVal.Text = "Y: ∅"
		rbLblEqSysXVal.Text = "X: ∅"
		rbLblInEqSysXVal.Text = "X: ∅"
		rbLblEqSysYVal.Text = "Y: ∅"
		rbLblInEqSysYVal.Text = "Y: ∅"
		zedMain.Invalidate()

	End Sub

#End Region

#Region "Actions"

#Region "Misc"

	Private _prevTab = 0
	Private Sub rbnMain_ActiveTabChanged(sender As System.Object, e As EventArgs) Handles rbnMain.ActiveTabChanged

		If Not _viewRanges.Any() Then Exit Sub

		ClearGraph(False)

		_viewRanges(_prevTab) = CurrentViewRange
		CurrentViewRange = _viewRanges(ViewModel.Index)

		UpdateGraphObjects()
		EnterActiveMode()

		_prevTab = ViewModel.Index

	End Sub

	Private Sub rbChkEqAutoRefresh_CheckBoxCheckChanged(sender As System.Object, e As EventArgs) Handles rbChkEqAutoRefresh.CheckBoxCheckChanged
		If (rbChkEqAutoRefresh.Checked) Then
			Recalculate()
		End If
	End Sub

	Private Sub rbChkIneqAutoRefresh_CheckBoxCheckChanged(sender As System.Object, e As EventArgs) Handles rbChkInEqAutoRefresh.CheckBoxCheckChanged
		If (rbChkInEqAutoRefresh.Checked) Then
			Recalculate()
		End If
	End Sub

	Private Sub rbChkEqSysAutoRefresh_CheckBoxCheckChanged(sender As System.Object, e As EventArgs) Handles rbChkEqSysAutoRefresh.CheckBoxCheckChanged
		If (rbChkEqSysAutoRefresh.Checked) Then
			Recalculate()
		End If
	End Sub

	Private Sub rbChkIneqSysAutoRefresh_CheckBoxCheckChanged(sender As System.Object, e As EventArgs) Handles rbChkInEqSysAutoRefresh.CheckBoxCheckChanged
		If (rbChkInEqSysAutoRefresh.Checked) Then
			Recalculate()
		End If
	End Sub

	Private Sub rbChkEqAutoRefresh_Click(sender As System.Object, e As EventArgs) Handles rbChkEqAutoRefresh.Click
		Dim value = Not rbChkEqAutoRefresh.Checked
		rbChkEqAutoRefresh.Checked = value
		rbChkInEqAutoRefresh.Checked = value
		rbChkEqSysAutoRefresh.Checked = value
		rbChkInEqSysAutoRefresh.Checked = value
		If (rbChkEqAutoRefresh.Checked) Then Recalculate()
	End Sub

	Private Sub rbChkInEqAutoRefresh_Click(sender As System.Object, e As EventArgs) Handles rbChkInEqAutoRefresh.Click
		Dim value = Not rbChkEqAutoRefresh.Checked
		rbChkEqAutoRefresh.Checked = value
		rbChkInEqAutoRefresh.Checked = value
		rbChkEqSysAutoRefresh.Checked = value
		rbChkInEqSysAutoRefresh.Checked = value
		If (rbChkInEqAutoRefresh.Checked) Then Recalculate()
	End Sub

	Private Sub rbChkEqSysAutoRefresh_Click(sender As System.Object, e As EventArgs) Handles rbChkEqSysAutoRefresh.Click
		Dim value = Not rbChkEqSysAutoRefresh.Checked
		rbChkEqAutoRefresh.Checked = value
		rbChkInEqAutoRefresh.Checked = value
		rbChkEqSysAutoRefresh.Checked = value
		rbChkInEqSysAutoRefresh.Checked = value
		If (rbChkEqSysAutoRefresh.Checked) Then Recalculate()
	End Sub

	Private Sub rbChkInEqSysAutoRefresh_Click(sender As System.Object, e As EventArgs) Handles rbChkInEqSysAutoRefresh.Click
		Dim value = Not rbChkEqSysAutoRefresh.Checked
		rbChkEqAutoRefresh.Checked = value
		rbChkInEqAutoRefresh.Checked = value
		rbChkEqSysAutoRefresh.Checked = value
		rbChkInEqSysAutoRefresh.Checked = value
		If (rbChkInEqSysAutoRefresh.Checked) Then Recalculate()
	End Sub

	Private Sub rbCmdEqRefresh_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqRefresh.Click, rbCmdInEqRefresh.Click, rbCmdEqSysRefresh.Click, rbCmdInEqSysRefresh.Click
		Recalculate()
	End Sub

	Private Sub zedMain_DoubleClick(sender As System.Object, e As EventArgs) Handles zedMain.DoubleClick

		If ViewModel.Current Is Nothing Then Exit Sub

		Dim lines = ViewModel.Current.ResolveTangentialLines(GetMouseCoordsOnGraph())
		_lines(ViewModel.Index).AddRange(lines)
		HideTmpLines()
		For Each line In lines
			line.Plot(zedMain.GraphPane)
		Next
		ShowTmpLines()
		zedMain.Invalidate()

	End Sub

	Private _eqA As String
	Private _eqB As String
	Private _eqC As String
	Private _eqD As String
	Private _inEqA As String
	Private _inEqB As String
	Private _inEqC As String
	Private _inEqD As String
	Private _eqSys1A As String
	Private _eqSys1B As String
	Private _eqSys1C As String
	Private _eqSys1D As String
	Private _inEqSys1A As String
	Private _inEqSys1B As String
	Private _inEqSys1C As String
	Private _inEqSys1D As String
	Private _eqSys2A As String
	Private _eqSys2B As String
	Private _eqSys2C As String
	Private _eqSys2D As String
	Private _inEqSys2A As String
	Private _inEqSys2B As String
	Private _inEqSys2C As String
	Private _inEqSys2D As String

	Private Sub rbEqTxtX_TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles rbTxtEqA.TextBoxTextChanged, rbTxtEqB.TextBoxTextChanged, rbTxtEqC.TextBoxTextChanged, rbTxtEqD.TextBoxTextChanged

		Dim a = rbTxtEqA.TextBoxText
		Dim b = rbTxtEqB.TextBoxText
		Dim c = rbTxtEqC.TextBoxText
		Dim d = rbTxtEqD.TextBoxText

		If (a <> _eqA Or b <> _eqB Or c <> _eqC Or d <> _eqD) And rbChkEqAutoRefresh.Checked Then
			Recalculate()
		End If

		_eqA = a
		_eqB = b
		_eqC = c
		_eqD = d

	End Sub

	Private Sub rbIneqTxtX_TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles rbTxtInEqA.TextBoxTextChanged, rbTxtInEqB.TextBoxTextChanged, rbTxtInEqC.TextBoxTextChanged, rbTxtInEqD.TextBoxTextChanged

		Dim a = rbTxtInEqA.TextBoxText
		Dim b = rbTxtInEqB.TextBoxText
		Dim c = rbTxtInEqC.TextBoxText
		Dim d = rbTxtInEqD.TextBoxText

		If (a <> _inEqA Or b <> _inEqB Or c <> _inEqC Or d <> _inEqD) And rbChkInEqAutoRefresh.Checked Then
			Recalculate()
		End If

		_inEqA = a
		_inEqB = b
		_inEqC = c
		_inEqD = d
	End Sub

	Private Sub rbEqSys1TxtX_TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles rbTxtEqSysA1.TextBoxTextChanged, rbTxtEqSysB1.TextBoxTextChanged, rbTxtEqSysC1.TextBoxTextChanged, rbTxtEqSysD1.TextBoxTextChanged

		Dim a = rbTxtEqSysA1.TextBoxText
		Dim b = rbTxtEqSysB1.TextBoxText
		Dim c = rbTxtEqSysC1.TextBoxText
		Dim d = rbTxtEqSysD1.TextBoxText

		If (a <> _eqSys1A Or b <> _eqSys1B Or c <> _eqSys1C Or d <> _eqSys1D) And rbChkEqSysAutoRefresh.Checked Then
			Recalculate()
		End If

		_eqSys1A = a
		_eqSys1B = b
		_eqSys1C = c
		_eqSys1D = d

	End Sub

	Private Sub rbIneqSys1TxtX_TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles rbTxtInEqSysA1.TextBoxTextChanged, rbTxtInEqSysB1.TextBoxTextChanged, rbTxtInEqSysC1.TextBoxTextChanged, rbTxtInEqSysD1.TextBoxTextChanged

		Dim a = rbTxtInEqSysA1.TextBoxText
		Dim b = rbTxtInEqSysB1.TextBoxText
		Dim c = rbTxtInEqSysC1.TextBoxText
		Dim d = rbTxtInEqSysD1.TextBoxText

		If (a <> _inEqSys1A Or b <> _inEqSys1B Or c <> _inEqSys1C Or d <> _inEqSys1D) And rbChkInEqSysAutoRefresh.Checked Then
			Recalculate()
		End If

		_inEqSys1A = a
		_inEqSys1B = b
		_inEqSys1C = c
		_inEqSys1D = d
	End Sub

	Private Sub rbEqSys2TxtX_TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles rbTxtEqSysA2.TextBoxTextChanged, rbTxtEqSysB2.TextBoxTextChanged, rbTxtEqSysC2.TextBoxTextChanged, rbTxtEqSysD2.TextBoxTextChanged

		Dim a = rbTxtEqSysA2.TextBoxText
		Dim b = rbTxtEqSysB2.TextBoxText
		Dim c = rbTxtEqSysC2.TextBoxText
		Dim d = rbTxtEqSysD2.TextBoxText

		If (a <> _eqSys2A Or b <> _eqSys2B Or c <> _eqSys2C Or d <> _eqSys2D) And rbChkEqSysAutoRefresh.Checked Then
			Recalculate()
		End If

		_eqSys2A = a
		_eqSys2B = b
		_eqSys2C = c
		_eqSys2D = d

	End Sub

	Private Sub rbIneqSys2TxtX_TextBoxTextChanged(sender As System.Object, e As EventArgs) Handles rbTxtInEqSysA2.TextBoxTextChanged, rbTxtInEqSysB2.TextBoxTextChanged, rbTxtInEqSysC2.TextBoxTextChanged, rbTxtInEqSysD2.TextBoxTextChanged

		Dim a = rbTxtInEqSysA2.TextBoxText
		Dim b = rbTxtInEqSysB2.TextBoxText
		Dim c = rbTxtInEqSysC2.TextBoxText
		Dim d = rbTxtInEqSysD2.TextBoxText

		If (a <> _inEqSys2A Or b <> _inEqSys2B Or c <> _inEqSys2C Or d <> _inEqSys2D) And rbChkInEqSysAutoRefresh.Checked Then
			Recalculate()
		End If

		_inEqSys2A = a
		_inEqSys2B = b
		_inEqSys2C = c
		_inEqSys2D = d
	End Sub

	Private Sub UpdateView()
		If _chkAutoRefresh(ViewModel.Index).Checked Then
			Recalculate()
		Else
			If ViewModel.Index = 0 OrElse ViewModel.Index = 1 Then EnterApplyViewModelMode()
			If ViewModel.Index = 2 AndAlso Not _systemEquation1Accessor Is Nothing AndAlso Not _systemEquation2Accessor Is Nothing Then
				EnterApplyViewModelMode()
			End If
			If ViewModel.Index = 3 AndAlso Not _systemInequality1Accessor Is Nothing AndAlso Not _systemInequality2Accessor Is Nothing Then
				EnterApplyViewModelMode()
			End If
		End If
	End Sub

	Private Sub rbCmdExit_Click(sender As System.Object, e As EventArgs) Handles rbCmdExit.Click
		Close()
	End Sub

#End Region

#Region "Ineq Selection"

	Private Sub rbCmdIneqSquare1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSquare1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqSquare1.Image
		_inequalityAccessor = Function()
								  Return New SquareInequality1(IneqA, IneqB, IneqC)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqSquare2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSquare2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqSquare2.Image
		_inequalityAccessor = Function()
								  Return New SquareInequality2(IneqA, IneqB, IneqC)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqExp1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqExp1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqExp1.Image
		_inequalityAccessor = Function()
								  Return New ExpInequality1(IneqA, IneqB, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqExp2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqExp2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqExp2.Image
		_inequalityAccessor = Function()
								  Return New ExpInequality2(IneqA, IneqB, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqLog1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqLog1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqLog1.Image
		_inequalityAccessor = Function()
								  Return New LogInequality1(IneqA, IneqB, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqLog2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqLog2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqLog2.Image
		_inequalityAccessor = Function()
								  Return New LogInequality2(IneqA, IneqB, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqSin1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSin1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqSin1.Image
		_inequalityAccessor = Function()
								  Return New SinInequality1(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqSin2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSin2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqSin2.Image
		_inequalityAccessor = Function()
								  Return New SinInequality2(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqCos1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqCos1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqCos1.Image
		_inequalityAccessor = Function()
								  Return New CosInequality1(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqCos2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqCos2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqCos2.Image
		_inequalityAccessor = Function()
								  Return New CosInequality2(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqTan1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqTg1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqTg1.Image
		_inequalityAccessor = Function()
								  Return New TanInequality1(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqTan2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqTg2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqTg2.Image
		_inequalityAccessor = Function()
								  Return New TanInequality2(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqCot1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqCtg1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqCtg1.Image
		_inequalityAccessor = Function()
								  Return New CotInequality1(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqCot2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqCtg2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqC.Enabled = True
		rbTxtInEqD.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqCtg2.Image
		_inequalityAccessor = Function()
								  Return New CotInequality2(IneqA, IneqC, IneqD)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqMod1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqMod1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqMod1.Image
		_inequalityAccessor = Function()
								  Return New ModInequality1(IneqA, IneqB, IneqC)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqMod2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqMod2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True
		rbTxtInEqC.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqMod2.Image
		_inequalityAccessor = Function()
								  Return New ModInequality2(IneqA, IneqB, IneqC)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqLinear1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqLinear1.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqLinear1.Image
		_inequalityAccessor = Function()
								  Return New LinearInequality1(IneqA, IneqB)
							  End Function

		UpdateView()

	End Sub

	Private Sub rbCmdIneqLinear2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqLinear2.Click

		DisableAllParameters()
		rbTxtInEqA.Enabled = True
		rbTxtInEqB.Enabled = True

		rbCmdInEqType.Image = rbCmdInEqLinear2.Image
		_inequalityAccessor = Function()
								  Return New LinearInequality2(IneqA, IneqB)
							  End Function

		UpdateView()

	End Sub

#End Region

#Region "Eq Selection"

	Private Sub rbCmdEqLinear_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqLinear.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqB.Enabled = True

		rbCmdEqType.Image = rbCmdEqLinear.Image
		_equationAccessor = Function()
								Return New LinearEquation(EqA, EqB)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSquare_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSquare.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqB.Enabled = True
		rbTxtEqC.Enabled = True

		rbCmdEqType.Image = rbCmdEqSquare.Image
		_equationAccessor = Function()
								Return New SquareEquation(EqA, EqB, EqC)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqMod_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqMod.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqB.Enabled = True
		rbTxtEqC.Enabled = True

		rbCmdEqType.Image = rbCmdEqMod.Image
		_equationAccessor = Function()
								Return New ModEquation(EqA, EqB, EqC)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqExp_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqExp.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqB.Enabled = True
		rbTxtEqC.Enabled = True
		rbTxtEqD.Enabled = True

		rbCmdEqType.Image = rbCmdEqExp.Image
		_equationAccessor = Function()
								Return New ExpEquation(EqA, EqB, EqC, EqD)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqLog_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqLog.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqB.Enabled = True
		rbTxtEqC.Enabled = True
		rbTxtEqD.Enabled = True

		rbCmdEqType.Image = rbCmdEqLog.Image
		_equationAccessor = Function()
								Return New LogEquation(EqA, EqB, EqC, EqD)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSin_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSin.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqC.Enabled = True
		rbTxtEqD.Enabled = True

		rbCmdEqType.Image = rbCmdEqSin.Image
		_equationAccessor = Function()
								Return New SinEquation(EqA, EqC, EqD)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqCos_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqCos.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqC.Enabled = True
		rbTxtEqD.Enabled = True

		rbCmdEqType.Image = rbCmdEqCos.Image
		_equationAccessor = Function()
								Return New CosEquation(EqA, EqC, EqD)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqTg_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqTg.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqC.Enabled = True
		rbTxtEqD.Enabled = True

		rbCmdEqType.Image = rbCmdEqTg.Image
		_equationAccessor = Function()
								Return New TanEquation(EqA, EqC, EqD)
							End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqCtg_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqCtg.Click

		DisableAllParameters()
		rbTxtEqA.Enabled = True
		rbTxtEqC.Enabled = True
		rbTxtEqD.Enabled = True

		rbCmdEqType.Image = rbCmdEqCtg.Image
		_equationAccessor = Function()
								Return New CotEquation(EqA, EqC, EqD)
							End Function

		UpdateView()

	End Sub

#End Region

#Region "Eq Sys1 Selection"

	Private Sub rbCmdEqSys1Linear_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Linear.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysB1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Linear.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New LinearFunction(EqSysA1, EqSysB1), New ConstFunction(0))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys1Mod_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Mod.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysB1.Enabled = True
		rbTxtEqSysC1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Mod.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New ModFunction(EqSysA1, EqSysC1), New ConstFunction(EqSysB1))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys1Exp_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Exp.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysB1.Enabled = True
		rbTxtEqSysC1.Enabled = True
		rbTxtEqSysD1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Exp.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New ExpFunction(EqSysA1, EqSysC1, EqSysD1), New ConstFunction(EqSysB1))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys1Log_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Log.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysB1.Enabled = True
		rbTxtEqSysC1.Enabled = True
		rbTxtEqSysD1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Log.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New LogFunction(EqSysA1, EqSysC1, EqSysD1), New ConstFunction(EqSysB1))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys1Sin_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Sin.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysC1.Enabled = True
		rbTxtEqSysD1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Sin.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New SinFunction(EqSysC1, EqSysD1), New ConstFunction(EqSysA1))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys1Tg_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Tg.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysC1.Enabled = True
		rbTxtEqSysD1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Tg.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New TanFunction(EqSysC1, EqSysD1), New ConstFunction(EqSysA1))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys1Ctg_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys1Ctg.Click

		DisableAllParameters(1)
		rbTxtEqSysA1.Enabled = True
		rbTxtEqSysC1.Enabled = True
		rbTxtEqSysD1.Enabled = True

		rbCmdEqSys1Type.Image = rbCmdEqSys1Ctg.Image
		_systemEquation1Accessor = Function()
									   Return New SystemEquationWrapper(New CotFunction(EqSysC1, EqSysD1), New ConstFunction(EqSysA1))
								   End Function

		UpdateView()

	End Sub

#End Region

#Region "Eq Sys2 Selection"

	Private Sub rbCmdEqSys2Linear_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Linear.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysB2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Linear.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New LinearFunction(EqSysA2, EqSysB2), New ConstFunction(0))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys2Mod_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Mod.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysB2.Enabled = True
		rbTxtEqSysC2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Mod.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New ModFunction(EqSysA2, EqSysC2), New ConstFunction(EqSysB2))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys2Exp_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Exp.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysB2.Enabled = True
		rbTxtEqSysC2.Enabled = True
		rbTxtEqSysD2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Exp.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New ExpFunction(EqSysA2, EqSysC2, EqSysD2), New ConstFunction(EqSysB2))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys2Log_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Log.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysB2.Enabled = True
		rbTxtEqSysC2.Enabled = True
		rbTxtEqSysD2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Log.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New LogFunction(EqSysA2, EqSysC2, EqSysD2), New ConstFunction(EqSysB2))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys2Sin_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Sin.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysC2.Enabled = True
		rbTxtEqSysD2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Sin.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New SinFunction(EqSysC2, EqSysD2), New ConstFunction(EqSysA2))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys2Tg_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Tg.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysC2.Enabled = True
		rbTxtEqSysD2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Tg.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New TanFunction(EqSysC2, EqSysD2), New ConstFunction(EqSysA2))
								   End Function

		UpdateView()

	End Sub

	Private Sub rbCmdEqSys2Ctg_Click(sender As System.Object, e As EventArgs) Handles rbCmdEqSys2Ctg.Click

		DisableAllParameters(2)
		rbTxtEqSysA2.Enabled = True
		rbTxtEqSysC2.Enabled = True
		rbTxtEqSysD2.Enabled = True

		rbCmdEqSys2Type.Image = rbCmdEqSys2Ctg.Image
		_systemEquation2Accessor = Function()
									   Return New SystemEquationWrapper(New CotFunction(EqSysC2, EqSysD2), New ConstFunction(EqSysA2))
								   End Function

		UpdateView()

	End Sub

#End Region

#Region "InEq Sys1 Selection"

	Private Sub rbCmdInEqSys1Linear1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Linear1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Linear1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New LinearFunction(InEqSysA1, InEqSysB1), InequalityType.Greater, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Square1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Square1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Square1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New SquareFunction(InEqSysA1, InEqSysB1, InEqSysC1), InequalityType.Greater, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Mod1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Mod1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Mod1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New ModFunction(InEqSysA1, InEqSysC1), InequalityType.Greater, New ConstFunction(InEqSysB1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Exp1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Exp1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Exp1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New ExpFunction(InEqSysA1, InEqSysC1, InEqSysD1), InequalityType.Greater, New ConstFunction(InEqSysB1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Log1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Log1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Log1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New LogFunction(InEqSysA1, InEqSysC1, InEqSysD1), InequalityType.Greater, New ConstFunction(InEqSysB1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Sin1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Sin1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Sin1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New SinFunction(InEqSysC1, InEqSysD1), InequalityType.Greater, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Cos1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Cos1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Cos1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New CosFunction(InEqSysC1, InEqSysD1), InequalityType.Greater, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Tg1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Tg1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Tg1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New TanFunction(InEqSysC1, InEqSysD1), InequalityType.Greater, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Ctg1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Ctg1.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Ctg1.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New CotFunction(InEqSysC1, InEqSysD1), InequalityType.Greater, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Linear2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Linear2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Linear2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New LinearFunction(InEqSysA1, InEqSysB1), InequalityType.Less, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Square2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Square2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Square2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New SquareFunction(InEqSysA1, InEqSysB1, InEqSysC1), InequalityType.Less, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Mod2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Mod2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Mod2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New ModFunction(InEqSysA1, InEqSysC1), InequalityType.Less, New ConstFunction(InEqSysB1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Exp2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Exp2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Exp2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New ExpFunction(InEqSysA1, InEqSysC1, InEqSysD1), InequalityType.Less, New ConstFunction(InEqSysB1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Log2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Log2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysB1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Log2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New LogFunction(InEqSysA1, InEqSysC1, InEqSysD1), InequalityType.Less, New ConstFunction(InEqSysB1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Sin2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Sin2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Sin2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New SinFunction(InEqSysC1, InEqSysD1), InequalityType.Less, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Cos2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Cos2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Cos2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New CosFunction(InEqSysC1, InEqSysD1), InequalityType.Less, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Tg2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Tg2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Tg2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New TanFunction(InEqSysC1, InEqSysD1), InequalityType.Less, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys1Ctg2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys1Ctg2.Click

		DisableAllParameters(1)
		rbTxtInEqSysA1.Enabled = True
		rbTxtInEqSysC1.Enabled = True
		rbTxtInEqSysD1.Enabled = True

		rbCmdInEqSys1Type.Image = rbCmdInEqSys1Ctg2.Image
		_systemInequality1Accessor = Function()
										 Return New SystemInequalityWrapper(New CotFunction(InEqSysC1, InEqSysD1), InequalityType.Less, New ConstFunction(InEqSysA1))
									 End Function

		UpdateView()

	End Sub

#End Region

#Region "InEq Sys2 Selection"

	Private Sub rbCmdInEqSys2Linear1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Linear1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Linear1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New LinearFunction(InEqSysA2, InEqSysB2), InequalityType.Greater, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Square1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Square1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Square1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New SquareFunction(InEqSysA2, InEqSysB2, InEqSysC2), InequalityType.Greater, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Mod1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Mod1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Mod1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New ModFunction(InEqSysA2, InEqSysC2), InequalityType.Greater, New ConstFunction(InEqSysB2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Exp1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Exp1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Exp1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New ExpFunction(InEqSysA2, InEqSysC2, InEqSysD2), InequalityType.Greater, New ConstFunction(InEqSysB2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Log1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Log1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Log1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New LogFunction(InEqSysA2, InEqSysC2, InEqSysD2), InequalityType.Greater, New ConstFunction(InEqSysB2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Sin1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Sin1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Sin1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New SinFunction(InEqSysC2, InEqSysD2), InequalityType.Greater, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Cos1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Cos1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Cos1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New CosFunction(InEqSysC2, InEqSysD2), InequalityType.Greater, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Tg1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Tg1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Tg1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New TanFunction(InEqSysC2, InEqSysD2), InequalityType.Greater, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Ctg1_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Ctg1.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Ctg1.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New CotFunction(InEqSysC2, InEqSysD2), InequalityType.Greater, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Linear2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Linear2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Linear2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New LinearFunction(InEqSysA2, InEqSysB2), InequalityType.Less, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Square2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Square2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Square2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New SquareFunction(InEqSysA2, InEqSysB2, InEqSysC2), InequalityType.Less, New ConstFunction(0))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Mod2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Mod2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Mod2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New ModFunction(InEqSysA2, InEqSysC2), InequalityType.Less, New ConstFunction(InEqSysB2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Exp2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Exp2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Exp2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New ExpFunction(InEqSysA2, InEqSysC2, InEqSysD2), InequalityType.Less, New ConstFunction(InEqSysB2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Log2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Log2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysB2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Log2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New LogFunction(InEqSysA2, InEqSysC2, InEqSysD2), InequalityType.Less, New ConstFunction(InEqSysB2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Sin2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Sin2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Sin2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New SinFunction(InEqSysC2, InEqSysD2), InequalityType.Less, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Cos2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Cos2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Cos2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New CosFunction(InEqSysC2, InEqSysD2), InequalityType.Less, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Tg2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Tg2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Tg2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New TanFunction(InEqSysC2, InEqSysD2), InequalityType.Less, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

	Private Sub rbCmdInEqSys2Ctg2_Click(sender As System.Object, e As EventArgs) Handles rbCmdInEqSys2Ctg2.Click

		DisableAllParameters(2)
		rbTxtInEqSysA2.Enabled = True
		rbTxtInEqSysC2.Enabled = True
		rbTxtInEqSysD2.Enabled = True

		rbCmdInEqSys2Type.Image = rbCmdInEqSys2Ctg2.Image
		_systemInequality2Accessor = Function()
										 Return New SystemInequalityWrapper(New CotFunction(InEqSysC2, InEqSysD2), InequalityType.Less, New ConstFunction(InEqSysA2))
									 End Function

		UpdateView()

	End Sub

#End Region

#End Region

    Private Sub zedMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zedMain.Load

    End Sub
End Class

