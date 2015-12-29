<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
	Inherits RibbonForm

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.zedMain = New ZedGraph.ZedGraphControl()
        Me.rbtEquations = New System.Windows.Forms.RibbonTab()
        Me.rbpEqConfig = New System.Windows.Forms.RibbonPanel()
        Me.rbCmdEqType = New System.Windows.Forms.RibbonButton()
        Me.rbLblEqTypesSimple = New System.Windows.Forms.RibbonLabel()
        Me.rbBlEqTypesSimple = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqLinear = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSquare = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqMod = New System.Windows.Forms.RibbonButton()
        Me.rbLblEqTypesLogExp = New System.Windows.Forms.RibbonLabel()
        Me.rbBlEqTypesLogExp = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqExp = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqLog = New System.Windows.Forms.RibbonButton()
        Me.rbLblEqTypesTrig = New System.Windows.Forms.RibbonLabel()
        Me.rbBlEqTypesTrig = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSin = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqCos = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqTg = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqCtg = New System.Windows.Forms.RibbonButton()
        Me.rbTxtEqA = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqB = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqC = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqD = New System.Windows.Forms.RibbonTextBox()
        Me.rbChkEqAutoRefresh = New System.Windows.Forms.RibbonCheckBox()
        Me.rbCmdEqRefresh = New System.Windows.Forms.RibbonButton()
        Me.rbpEqSolution = New System.Windows.Forms.RibbonPanel()
        Me.rbLblEqXVal = New System.Windows.Forms.RibbonLabel()
        Me.rbLblEqYVal = New System.Windows.Forms.RibbonLabel()
        Me.rbLblEqSys1TypesSimple = New System.Windows.Forms.RibbonLabel()
        Me.rbLblEqSys2TypesSimple = New System.Windows.Forms.RibbonLabel()
        Me.rbBlEqSys1TypesSimple = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSys1Linear = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys1Mod = New System.Windows.Forms.RibbonButton()
        Me.rbBlEqSys2TypesSimple = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSys2Linear = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys2Mod = New System.Windows.Forms.RibbonButton()
        Me.rbLblEqSys1TypesLogExp = New System.Windows.Forms.RibbonLabel()
        Me.rbLblEqSys2TypesLogExp = New System.Windows.Forms.RibbonLabel()
        Me.rbBlEqSys1TypesLogExp = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSys1Exp = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys1Log = New System.Windows.Forms.RibbonButton()
        Me.rbBlEqSys2TypesLogExp = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSys2Exp = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys2Log = New System.Windows.Forms.RibbonButton()
        Me.rbLblEqSys1TypesTrig = New System.Windows.Forms.RibbonLabel()
        Me.rbLblEqSys2TypesTrig = New System.Windows.Forms.RibbonLabel()
        Me.rbBlEqSys1TypesTrig = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSys1Sin = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys1Tg = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys1Ctg = New System.Windows.Forms.RibbonButton()
        Me.rbBlEqSys2TypesTrig = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdEqSys2Sin = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys2Tg = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys2Ctg = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys1Type = New System.Windows.Forms.RibbonButton()
        Me.rbCmdEqSys2Type = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Type = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqSys1TypesSimple = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqSys1TypesSimple = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSys1Linear1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Square1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Mod1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1TypeSimpleDummy = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Linear2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Square2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Mod2 = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqSys1TypesLogExp = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqSys1TypesLogExp = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSys1Exp1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Exp2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Log1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Log2 = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqSys1TypesTrig = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqSys1TypesTrig = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSys1Sin1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Cos1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Tg1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Ctg1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Sin2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Cos2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Tg2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys1Ctg2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Type = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqSys2TypesSimple = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqSys2TypesSimple = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSys2Linear1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Square1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Mod1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2TypeSimpleDummy = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Linear2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Square2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Mod2 = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqSys2TypesLogExp = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqSys2TypesLogExp = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSys2Exp1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Exp2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Log1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Log2 = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqSys2TypesTrig = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqSys2TypesTrig = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSys2Sin1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Cos1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Tg1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Ctg1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Sin2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Cos2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Tg2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSys2Ctg2 = New System.Windows.Forms.RibbonButton()
        Me.rbTxtEqSysA1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysB1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysC1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysD1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysA2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysB2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysC2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtEqSysD2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysA1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysB1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysC1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysD1 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysA2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysB2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysC2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqSysD2 = New System.Windows.Forms.RibbonTextBox()
        Me.rbpEqSysConfig = New System.Windows.Forms.RibbonPanel()
        Me.rbChkEqSysAutoRefresh = New System.Windows.Forms.RibbonCheckBox()
        Me.rbCmdEqSysRefresh = New System.Windows.Forms.RibbonButton()
        Me.rbpInEqSysConfig = New System.Windows.Forms.RibbonPanel()
        Me.rbChkInEqSysAutoRefresh = New System.Windows.Forms.RibbonCheckBox()
        Me.rbCmdInEqSysRefresh = New System.Windows.Forms.RibbonButton()
        Me.rbpEqSysSolution = New System.Windows.Forms.RibbonPanel()
        Me.rbLblEqSysXVal = New System.Windows.Forms.RibbonLabel()
        Me.rbLblEqSysYVal = New System.Windows.Forms.RibbonLabel()
        Me.rbpInEqSysSolution = New System.Windows.Forms.RibbonPanel()
        Me.rbLblInEqSysXVal = New System.Windows.Forms.RibbonLabel()
        Me.rbLblInEqSysYVal = New System.Windows.Forms.RibbonLabel()
        Me.rbtInequalities = New System.Windows.Forms.RibbonTab()
        Me.rbpInEqConfig = New System.Windows.Forms.RibbonPanel()
        Me.rbCmdInEqType = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqTypesSimple = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqTypesSimple = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqLinear1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSquare1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqMod1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqTypeSimpleDummy = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqLinear2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSquare2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqMod2 = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqTypesLogExp = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqTypesLogExp = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqExp1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqExp2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqLog1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqLog2 = New System.Windows.Forms.RibbonButton()
        Me.rbLblInEqTypesTrig = New System.Windows.Forms.RibbonLabel()
        Me.rbBlInEqTypesTrig = New System.Windows.Forms.RibbonButtonList()
        Me.rbCmdInEqSin1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqCos1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqTg1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqCtg1 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqSin2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqCos2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqTg2 = New System.Windows.Forms.RibbonButton()
        Me.rbCmdInEqCtg2 = New System.Windows.Forms.RibbonButton()
        Me.rbTxtInEqA = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqB = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqC = New System.Windows.Forms.RibbonTextBox()
        Me.rbTxtInEqD = New System.Windows.Forms.RibbonTextBox()
        Me.rbChkInEqAutoRefresh = New System.Windows.Forms.RibbonCheckBox()
        Me.rbCmdInEqRefresh = New System.Windows.Forms.RibbonButton()
        Me.rbpInEqSolution = New System.Windows.Forms.RibbonPanel()
        Me.rbLblInEqXVal = New System.Windows.Forms.RibbonLabel()
        Me.rbLblInEqYVal = New System.Windows.Forms.RibbonLabel()
        Me.rbtEquationsSystems = New System.Windows.Forms.RibbonTab()
        Me.rbtInEqualitiesSystems = New System.Windows.Forms.RibbonTab()
        Me.rbnMain = New System.Windows.Forms.Ribbon()
        Me.rbCmdExit = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.lblInvalidParameters = New System.Windows.Forms.Label()
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.lblApply = New System.Windows.Forms.Label()
        Me.rbBlEqSys1TypesSq = New System.Windows.Forms.RibbonButton()
        Me.SuspendLayout()
        '
        'zedMain
        '
        Me.zedMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zedMain.IsAntiAlias = True
        Me.zedMain.Location = New System.Drawing.Point(0, 186)
        Me.zedMain.Name = "zedMain"
        Me.zedMain.ScrollGrace = 0.0R
        Me.zedMain.ScrollMaxX = 0.0R
        Me.zedMain.ScrollMaxY = 0.0R
        Me.zedMain.ScrollMaxY2 = 0.0R
        Me.zedMain.ScrollMinX = 0.0R
        Me.zedMain.ScrollMinY = 0.0R
        Me.zedMain.ScrollMinY2 = 0.0R
        Me.zedMain.Size = New System.Drawing.Size(944, 498)
        Me.zedMain.TabIndex = 7
        '
        'rbtEquations
        '
        Me.rbtEquations.Panels.Add(Me.rbpEqConfig)
        Me.rbtEquations.Panels.Add(Me.rbpEqSolution)
        Me.rbtEquations.Text = "Рiвняння"
        '
        'rbpEqConfig
        '
        Me.rbpEqConfig.ButtonMoreVisible = False
        Me.rbpEqConfig.Items.Add(Me.rbCmdEqType)
        Me.rbpEqConfig.Items.Add(Me.rbTxtEqA)
        Me.rbpEqConfig.Items.Add(Me.rbTxtEqB)
        Me.rbpEqConfig.Items.Add(Me.rbTxtEqC)
        Me.rbpEqConfig.Items.Add(Me.rbTxtEqD)
        Me.rbpEqConfig.Items.Add(Me.rbChkEqAutoRefresh)
        Me.rbpEqConfig.Items.Add(Me.rbCmdEqRefresh)
        Me.rbpEqConfig.Text = "Рiвняння"
        '
        'rbCmdEqType
        '
        Me.rbCmdEqType.DropDownItems.Add(Me.rbLblEqTypesSimple)
        Me.rbCmdEqType.DropDownItems.Add(Me.rbBlEqTypesSimple)
        Me.rbCmdEqType.DropDownItems.Add(Me.rbLblEqTypesLogExp)
        Me.rbCmdEqType.DropDownItems.Add(Me.rbBlEqTypesLogExp)
        Me.rbCmdEqType.DropDownItems.Add(Me.rbLblEqTypesTrig)
        Me.rbCmdEqType.DropDownItems.Add(Me.rbBlEqTypesTrig)
        Me.rbCmdEqType.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSelect
        Me.rbCmdEqType.MaximumSize = New System.Drawing.Size(210, 105)
        Me.rbCmdEqType.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqType.MinimumSize = New System.Drawing.Size(9, 0)
        Me.rbCmdEqType.SmallImage = CType(resources.GetObject("rbCmdEqType.SmallImage"), System.Drawing.Image)
        Me.rbCmdEqType.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbCmdEqType.Text = " "
        '
        'rbLblEqTypesSimple
        '
        Me.rbLblEqTypesSimple.LabelWidth = 840
        Me.rbLblEqTypesSimple.Text = "       Простi:"
        '
        'rbBlEqTypesSimple
        '
        Me.rbBlEqTypesSimple.Buttons.Add(Me.rbCmdEqLinear)
        Me.rbBlEqTypesSimple.Buttons.Add(Me.rbCmdEqSquare)
        Me.rbBlEqTypesSimple.Buttons.Add(Me.rbCmdEqMod)
        Me.rbBlEqTypesSimple.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqTypesSimple.ControlButtonsWidth = 0
        Me.rbBlEqTypesSimple.FlowToBottom = False
        Me.rbBlEqTypesSimple.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 1)
        Me.rbBlEqTypesSimple.NoScroll = True
        '
        'rbCmdEqLinear
        '
        Me.rbCmdEqLinear.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqLinear.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqLinear
        Me.rbCmdEqLinear.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqLinear.SmallImage = CType(resources.GetObject("rbCmdEqLinear.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSquare
        '
        Me.rbCmdEqSquare.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSquare.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSquare
        Me.rbCmdEqSquare.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSquare.SmallImage = CType(resources.GetObject("rbCmdEqSquare.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqMod
        '
        Me.rbCmdEqMod.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqMod.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqMod
        Me.rbCmdEqMod.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqMod.SmallImage = CType(resources.GetObject("rbCmdEqMod.SmallImage"), System.Drawing.Image)
        '
        'rbLblEqTypesLogExp
        '
        Me.rbLblEqTypesLogExp.Text = "       Показникові та логарифмічні:"
        '
        'rbBlEqTypesLogExp
        '
        Me.rbBlEqTypesLogExp.Buttons.Add(Me.rbCmdEqExp)
        Me.rbBlEqTypesLogExp.Buttons.Add(Me.rbCmdEqLog)
        Me.rbBlEqTypesLogExp.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqTypesLogExp.ControlButtonsWidth = 0
        Me.rbBlEqTypesLogExp.FlowToBottom = False
        Me.rbBlEqTypesLogExp.ItemsSizeInDropwDownMode = New System.Drawing.Size(2, 1)
        Me.rbBlEqTypesLogExp.NoScroll = True
        '
        'rbCmdEqExp
        '
        Me.rbCmdEqExp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqExp.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqExp
        Me.rbCmdEqExp.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqExp.SmallImage = CType(resources.GetObject("rbCmdEqExp.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqLog
        '
        Me.rbCmdEqLog.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqLog.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqLog
        Me.rbCmdEqLog.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqLog.SmallImage = CType(resources.GetObject("rbCmdEqLog.SmallImage"), System.Drawing.Image)
        '
        'rbLblEqTypesTrig
        '
        Me.rbLblEqTypesTrig.Text = "       Тригонометрічні:"
        '
        'rbBlEqTypesTrig
        '
        Me.rbBlEqTypesTrig.Buttons.Add(Me.rbCmdEqSin)
        Me.rbBlEqTypesTrig.Buttons.Add(Me.rbCmdEqCos)
        Me.rbBlEqTypesTrig.Buttons.Add(Me.rbCmdEqTg)
        Me.rbBlEqTypesTrig.Buttons.Add(Me.rbCmdEqCtg)
        Me.rbBlEqTypesTrig.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqTypesTrig.ControlButtonsWidth = 0
        Me.rbBlEqTypesTrig.FlowToBottom = False
        Me.rbBlEqTypesTrig.ItemsSizeInDropwDownMode = New System.Drawing.Size(4, 1)
        Me.rbBlEqTypesTrig.NoScroll = True
        '
        'rbCmdEqSin
        '
        Me.rbCmdEqSin.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSin.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSin
        Me.rbCmdEqSin.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSin.SmallImage = CType(resources.GetObject("rbCmdEqSin.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqCos
        '
        Me.rbCmdEqCos.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqCos.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqCos
        Me.rbCmdEqCos.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqCos.SmallImage = CType(resources.GetObject("rbCmdEqCos.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqTg
        '
        Me.rbCmdEqTg.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqTg.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqTg
        Me.rbCmdEqTg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqTg.SmallImage = CType(resources.GetObject("rbCmdEqTg.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqCtg
        '
        Me.rbCmdEqCtg.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqCtg.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqCtg
        Me.rbCmdEqCtg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqCtg.SmallImage = CType(resources.GetObject("rbCmdEqCtg.SmallImage"), System.Drawing.Image)
        '
        'rbTxtEqA
        '
        Me.rbTxtEqA.LabelWidth = 25
        Me.rbTxtEqA.Text = "a = "
        Me.rbTxtEqA.TextBoxText = "2"
        '
        'rbTxtEqB
        '
        Me.rbTxtEqB.LabelWidth = 25
        Me.rbTxtEqB.Text = "b = "
        Me.rbTxtEqB.TextBoxText = "3"
        '
        'rbTxtEqC
        '
        Me.rbTxtEqC.LabelWidth = 25
        Me.rbTxtEqC.Text = "c = "
        Me.rbTxtEqC.TextBoxText = "4"
        '
        'rbTxtEqD
        '
        Me.rbTxtEqD.LabelWidth = 25
        Me.rbTxtEqD.Text = "d = "
        Me.rbTxtEqD.TextBoxText = "5"
        '
        'rbChkEqAutoRefresh
        '
        Me.rbChkEqAutoRefresh.Text = "Автозастосування"
        '
        'rbCmdEqRefresh
        '
        Me.rbCmdEqRefresh.Image = Global.GraphEqIneqSolver.My.Resources.Resources.RefreshArrow
        Me.rbCmdEqRefresh.MaximumSize = New System.Drawing.Size(110, 0)
        Me.rbCmdEqRefresh.SmallImage = CType(resources.GetObject("rbCmdEqRefresh.SmallImage"), System.Drawing.Image)
        Me.rbCmdEqRefresh.Text = "Застосувати параметри"
        '
        'rbpEqSolution
        '
        Me.rbpEqSolution.ButtonMoreVisible = False
        Me.rbpEqSolution.Items.Add(Me.rbLblEqXVal)
        Me.rbpEqSolution.Items.Add(Me.rbLblEqYVal)
        Me.rbpEqSolution.Text = "Розв'язки та координати"
        '
        'rbLblEqXVal
        '
        Me.rbLblEqXVal.LabelWidth = 450
        Me.rbLblEqXVal.Text = "X: ∅"
        Me.rbLblEqXVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbLblEqYVal
        '
        Me.rbLblEqYVal.LabelWidth = 450
        Me.rbLblEqYVal.Text = "Y: ∅"
        Me.rbLblEqYVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbLblEqSys1TypesSimple
        '
        Me.rbLblEqSys1TypesSimple.LabelWidth = 629
        Me.rbLblEqSys1TypesSimple.Text = "       Простi:"
        '
        'rbLblEqSys2TypesSimple
        '
        Me.rbLblEqSys2TypesSimple.LabelWidth = 629
        Me.rbLblEqSys2TypesSimple.Text = "       Простi:"
        '
        'rbBlEqSys1TypesSimple
        '
        Me.rbBlEqSys1TypesSimple.Buttons.Add(Me.rbCmdEqSys1Linear)
        Me.rbBlEqSys1TypesSimple.Buttons.Add(Me.rbCmdEqSys1Mod)
        Me.rbBlEqSys1TypesSimple.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqSys1TypesSimple.ControlButtonsWidth = 0
        Me.rbBlEqSys1TypesSimple.FlowToBottom = False
        Me.rbBlEqSys1TypesSimple.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 1)
        Me.rbBlEqSys1TypesSimple.ItemsWideInLargeMode = 3
        Me.rbBlEqSys1TypesSimple.NoScroll = True
        '
        'rbCmdEqSys1Linear
        '
        Me.rbCmdEqSys1Linear.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Linear.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemLinear
        Me.rbCmdEqSys1Linear.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Linear.SmallImage = CType(resources.GetObject("rbCmdEqSys1Linear.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys1Mod
        '
        Me.rbCmdEqSys1Mod.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Mod.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemMod
        Me.rbCmdEqSys1Mod.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Mod.SmallImage = CType(resources.GetObject("rbCmdEqSys1Mod.SmallImage"), System.Drawing.Image)
        '
        'rbBlEqSys2TypesSimple
        '
        Me.rbBlEqSys2TypesSimple.Buttons.Add(Me.rbCmdEqSys2Linear)
        Me.rbBlEqSys2TypesSimple.Buttons.Add(Me.rbCmdEqSys2Mod)
        Me.rbBlEqSys2TypesSimple.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqSys2TypesSimple.ControlButtonsWidth = 0
        Me.rbBlEqSys2TypesSimple.FlowToBottom = False
        Me.rbBlEqSys2TypesSimple.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 1)
        Me.rbBlEqSys2TypesSimple.ItemsWideInLargeMode = 3
        Me.rbBlEqSys2TypesSimple.NoScroll = True
        '
        'rbCmdEqSys2Linear
        '
        Me.rbCmdEqSys2Linear.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Linear.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemLinear
        Me.rbCmdEqSys2Linear.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Linear.SmallImage = CType(resources.GetObject("rbCmdEqSys2Linear.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys2Mod
        '
        Me.rbCmdEqSys2Mod.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Mod.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemMod
        Me.rbCmdEqSys2Mod.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Mod.SmallImage = CType(resources.GetObject("rbCmdEqSys2Mod.SmallImage"), System.Drawing.Image)
        '
        'rbLblEqSys1TypesLogExp
        '
        Me.rbLblEqSys1TypesLogExp.Text = "       Показникові та логарифмічні:"
        '
        'rbLblEqSys2TypesLogExp
        '
        Me.rbLblEqSys2TypesLogExp.Text = "       Показникові та логарифмічні:"
        '
        'rbBlEqSys1TypesLogExp
        '
        Me.rbBlEqSys1TypesLogExp.Buttons.Add(Me.rbCmdEqSys1Exp)
        Me.rbBlEqSys1TypesLogExp.Buttons.Add(Me.rbCmdEqSys1Log)
        Me.rbBlEqSys1TypesLogExp.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqSys1TypesLogExp.ControlButtonsWidth = 0
        Me.rbBlEqSys1TypesLogExp.FlowToBottom = False
        Me.rbBlEqSys1TypesLogExp.ItemsSizeInDropwDownMode = New System.Drawing.Size(2, 1)
        Me.rbBlEqSys1TypesLogExp.NoScroll = True
        '
        'rbCmdEqSys1Exp
        '
        Me.rbCmdEqSys1Exp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Exp.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemExp
        Me.rbCmdEqSys1Exp.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Exp.SmallImage = CType(resources.GetObject("rbCmdEqSys1Exp.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys1Log
        '
        Me.rbCmdEqSys1Log.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Log.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemLog
        Me.rbCmdEqSys1Log.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Log.SmallImage = CType(resources.GetObject("rbCmdEqSys1Log.SmallImage"), System.Drawing.Image)
        '
        'rbBlEqSys2TypesLogExp
        '
        Me.rbBlEqSys2TypesLogExp.Buttons.Add(Me.rbCmdEqSys2Exp)
        Me.rbBlEqSys2TypesLogExp.Buttons.Add(Me.rbCmdEqSys2Log)
        Me.rbBlEqSys2TypesLogExp.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqSys2TypesLogExp.ControlButtonsWidth = 0
        Me.rbBlEqSys2TypesLogExp.FlowToBottom = False
        Me.rbBlEqSys2TypesLogExp.ItemsSizeInDropwDownMode = New System.Drawing.Size(2, 1)
        Me.rbBlEqSys2TypesLogExp.NoScroll = True
        '
        'rbCmdEqSys2Exp
        '
        Me.rbCmdEqSys2Exp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Exp.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemExp
        Me.rbCmdEqSys2Exp.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Exp.SmallImage = CType(resources.GetObject("rbCmdEqSys2Exp.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys2Log
        '
        Me.rbCmdEqSys2Log.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Log.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemLog
        Me.rbCmdEqSys2Log.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Log.SmallImage = CType(resources.GetObject("rbCmdEqSys2Log.SmallImage"), System.Drawing.Image)
        '
        'rbLblEqSys1TypesTrig
        '
        Me.rbLblEqSys1TypesTrig.Text = "       Тригонометрічні:"
        '
        'rbLblEqSys2TypesTrig
        '
        Me.rbLblEqSys2TypesTrig.Text = "       Тригонометрічні:"
        '
        'rbBlEqSys1TypesTrig
        '
        Me.rbBlEqSys1TypesTrig.Buttons.Add(Me.rbCmdEqSys1Sin)
        Me.rbBlEqSys1TypesTrig.Buttons.Add(Me.rbCmdEqSys1Tg)
        Me.rbBlEqSys1TypesTrig.Buttons.Add(Me.rbCmdEqSys1Ctg)
        Me.rbBlEqSys1TypesTrig.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqSys1TypesTrig.ControlButtonsWidth = 0
        Me.rbBlEqSys1TypesTrig.FlowToBottom = False
        Me.rbBlEqSys1TypesTrig.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 1)
        Me.rbBlEqSys1TypesTrig.NoScroll = True
        '
        'rbCmdEqSys1Sin
        '
        Me.rbCmdEqSys1Sin.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Sin.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemSin
        Me.rbCmdEqSys1Sin.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Sin.SmallImage = CType(resources.GetObject("rbCmdEqSys1Sin.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys1Tg
        '
        Me.rbCmdEqSys1Tg.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Tg.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemTg
        Me.rbCmdEqSys1Tg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Tg.SmallImage = CType(resources.GetObject("rbCmdEqSys1Tg.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys1Ctg
        '
        Me.rbCmdEqSys1Ctg.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys1Ctg.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemCtg
        Me.rbCmdEqSys1Ctg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Ctg.SmallImage = CType(resources.GetObject("rbCmdEqSys1Ctg.SmallImage"), System.Drawing.Image)
        '
        'rbBlEqSys2TypesTrig
        '
        Me.rbBlEqSys2TypesTrig.Buttons.Add(Me.rbCmdEqSys2Sin)
        Me.rbBlEqSys2TypesTrig.Buttons.Add(Me.rbCmdEqSys2Tg)
        Me.rbBlEqSys2TypesTrig.Buttons.Add(Me.rbCmdEqSys2Ctg)
        Me.rbBlEqSys2TypesTrig.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlEqSys2TypesTrig.ControlButtonsWidth = 0
        Me.rbBlEqSys2TypesTrig.FlowToBottom = False
        Me.rbBlEqSys2TypesTrig.ItemsSizeInDropwDownMode = New System.Drawing.Size(4, 1)
        Me.rbBlEqSys2TypesTrig.NoScroll = True
        '
        'rbCmdEqSys2Sin
        '
        Me.rbCmdEqSys2Sin.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Sin.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemSin
        Me.rbCmdEqSys2Sin.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Sin.SmallImage = CType(resources.GetObject("rbCmdEqSys2Sin.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys2Tg
        '
        Me.rbCmdEqSys2Tg.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Tg.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemTg
        Me.rbCmdEqSys2Tg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Tg.SmallImage = CType(resources.GetObject("rbCmdEqSys2Tg.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys2Ctg
        '
        Me.rbCmdEqSys2Ctg.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdEqSys2Ctg.Image = Global.GraphEqIneqSolver.My.Resources.Resources.EqSystemCtg
        Me.rbCmdEqSys2Ctg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Ctg.SmallImage = CType(resources.GetObject("rbCmdEqSys2Ctg.SmallImage"), System.Drawing.Image)
        '
        'rbCmdEqSys1Type
        '
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbLblEqSys1TypesSimple)
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbBlEqSys1TypesSimple)
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbLblEqSys1TypesLogExp)
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbBlEqSys1TypesLogExp)
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbLblEqSys1TypesTrig)
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbBlEqSys1TypesTrig)
        Me.rbCmdEqSys1Type.DropDownItems.Add(Me.rbBlEqSys1TypesSq)
        Me.rbCmdEqSys1Type.Image = Global.GraphEqIneqSolver.My.Resources.Resources.Eq1Select
        Me.rbCmdEqSys1Type.MaximumSize = New System.Drawing.Size(210, 105)
        Me.rbCmdEqSys1Type.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys1Type.MinimumSize = New System.Drawing.Size(9, 0)
        Me.rbCmdEqSys1Type.SmallImage = CType(resources.GetObject("rbCmdEqSys1Type.SmallImage"), System.Drawing.Image)
        Me.rbCmdEqSys1Type.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbCmdEqSys1Type.Text = " "
        '
        'rbCmdEqSys2Type
        '
        Me.rbCmdEqSys2Type.DropDownItems.Add(Me.rbLblEqSys2TypesSimple)
        Me.rbCmdEqSys2Type.DropDownItems.Add(Me.rbBlEqSys2TypesSimple)
        Me.rbCmdEqSys2Type.DropDownItems.Add(Me.rbLblEqSys2TypesLogExp)
        Me.rbCmdEqSys2Type.DropDownItems.Add(Me.rbBlEqSys2TypesLogExp)
        Me.rbCmdEqSys2Type.DropDownItems.Add(Me.rbLblEqSys2TypesTrig)
        Me.rbCmdEqSys2Type.DropDownItems.Add(Me.rbBlEqSys2TypesTrig)
        Me.rbCmdEqSys2Type.Image = Global.GraphEqIneqSolver.My.Resources.Resources.Eq2Select
        Me.rbCmdEqSys2Type.MaximumSize = New System.Drawing.Size(210, 105)
        Me.rbCmdEqSys2Type.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdEqSys2Type.MinimumSize = New System.Drawing.Size(9, 0)
        Me.rbCmdEqSys2Type.SmallImage = CType(resources.GetObject("rbCmdEqSys2Type.SmallImage"), System.Drawing.Image)
        Me.rbCmdEqSys2Type.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbCmdEqSys2Type.Text = " "
        '
        'rbCmdInEqSys1Type
        '
        Me.rbCmdInEqSys1Type.DropDownItems.Add(Me.rbLblInEqSys1TypesSimple)
        Me.rbCmdInEqSys1Type.DropDownItems.Add(Me.rbBlInEqSys1TypesSimple)
        Me.rbCmdInEqSys1Type.DropDownItems.Add(Me.rbLblInEqSys1TypesLogExp)
        Me.rbCmdInEqSys1Type.DropDownItems.Add(Me.rbBlInEqSys1TypesLogExp)
        Me.rbCmdInEqSys1Type.DropDownItems.Add(Me.rbLblInEqSys1TypesTrig)
        Me.rbCmdInEqSys1Type.DropDownItems.Add(Me.rbBlInEqSys1TypesTrig)
        Me.rbCmdInEqSys1Type.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEq1Select
        Me.rbCmdInEqSys1Type.MaximumSize = New System.Drawing.Size(210, 105)
        Me.rbCmdInEqSys1Type.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Type.MinimumSize = New System.Drawing.Size(9, 0)
        Me.rbCmdInEqSys1Type.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Type.SmallImage"), System.Drawing.Image)
        Me.rbCmdInEqSys1Type.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbCmdInEqSys1Type.Text = " "
        '
        'rbLblInEqSys1TypesSimple
        '
        Me.rbLblInEqSys1TypesSimple.LabelWidth = 840
        Me.rbLblInEqSys1TypesSimple.Text = "       Простi:"
        '
        'rbBlInEqSys1TypesSimple
        '
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1Linear1)
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1Square1)
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1Mod1)
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1TypeSimpleDummy)
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1Linear2)
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1Square2)
        Me.rbBlInEqSys1TypesSimple.Buttons.Add(Me.rbCmdInEqSys1Mod2)
        Me.rbBlInEqSys1TypesSimple.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqSys1TypesSimple.ControlButtonsWidth = 0
        Me.rbBlInEqSys1TypesSimple.FlowToBottom = False
        Me.rbBlInEqSys1TypesSimple.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 2)
        Me.rbBlInEqSys1TypesSimple.ItemsWideInLargeMode = 3
        Me.rbBlInEqSys1TypesSimple.NoScroll = True
        '
        'rbCmdInEqSys1Linear1
        '
        Me.rbCmdInEqSys1Linear1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Linear1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLinear1
        Me.rbCmdInEqSys1Linear1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Linear1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Linear1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Square1
        '
        Me.rbCmdInEqSys1Square1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Square1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSquare1
        Me.rbCmdInEqSys1Square1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Square1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Square1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Mod1
        '
        Me.rbCmdInEqSys1Mod1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Mod1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemMod1
        Me.rbCmdInEqSys1Mod1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Mod1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Mod1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1TypeSimpleDummy
        '
        Me.rbCmdInEqSys1TypeSimpleDummy.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1TypeSimpleDummy.Enabled = False
        Me.rbCmdInEqSys1TypeSimpleDummy.Image = Global.GraphEqIneqSolver.My.Resources.Resources.Transparent
        Me.rbCmdInEqSys1TypeSimpleDummy.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1TypeSimpleDummy.SmallImage = CType(resources.GetObject("rbCmdInEqSys1TypeSimpleDummy.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Linear2
        '
        Me.rbCmdInEqSys1Linear2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Linear2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLinear2
        Me.rbCmdInEqSys1Linear2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Linear2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Linear2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Square2
        '
        Me.rbCmdInEqSys1Square2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Square2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSquare2
        Me.rbCmdInEqSys1Square2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Square2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Square2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Mod2
        '
        Me.rbCmdInEqSys1Mod2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Mod2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemMod2
        Me.rbCmdInEqSys1Mod2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Mod2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Mod2.SmallImage"), System.Drawing.Image)
        '
        'rbLblInEqSys1TypesLogExp
        '
        Me.rbLblInEqSys1TypesLogExp.Text = "       Показникові та логарифмічні:"
        '
        'rbBlInEqSys1TypesLogExp
        '
        Me.rbBlInEqSys1TypesLogExp.Buttons.Add(Me.rbCmdInEqSys1Exp1)
        Me.rbBlInEqSys1TypesLogExp.Buttons.Add(Me.rbCmdInEqSys1Exp2)
        Me.rbBlInEqSys1TypesLogExp.Buttons.Add(Me.rbCmdInEqSys1Log1)
        Me.rbBlInEqSys1TypesLogExp.Buttons.Add(Me.rbCmdInEqSys1Log2)
        Me.rbBlInEqSys1TypesLogExp.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqSys1TypesLogExp.ControlButtonsWidth = 0
        Me.rbBlInEqSys1TypesLogExp.FlowToBottom = False
        Me.rbBlInEqSys1TypesLogExp.ItemsSizeInDropwDownMode = New System.Drawing.Size(2, 1)
        Me.rbBlInEqSys1TypesLogExp.NoScroll = True
        '
        'rbCmdInEqSys1Exp1
        '
        Me.rbCmdInEqSys1Exp1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Exp1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemExp1
        Me.rbCmdInEqSys1Exp1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Exp1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Exp1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Exp2
        '
        Me.rbCmdInEqSys1Exp2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Exp2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemExp2
        Me.rbCmdInEqSys1Exp2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Exp2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Exp2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Log1
        '
        Me.rbCmdInEqSys1Log1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Log1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLog1
        Me.rbCmdInEqSys1Log1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Log1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Log1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Log2
        '
        Me.rbCmdInEqSys1Log2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Log2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLog2
        Me.rbCmdInEqSys1Log2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Log2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Log2.SmallImage"), System.Drawing.Image)
        '
        'rbLblInEqSys1TypesTrig
        '
        Me.rbLblInEqSys1TypesTrig.Text = "       Тригонометрічні:"
        '
        'rbBlInEqSys1TypesTrig
        '
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Sin1)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Cos1)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Tg1)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Ctg1)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Sin2)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Cos2)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Tg2)
        Me.rbBlInEqSys1TypesTrig.Buttons.Add(Me.rbCmdInEqSys1Ctg2)
        Me.rbBlInEqSys1TypesTrig.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqSys1TypesTrig.ControlButtonsWidth = 0
        Me.rbBlInEqSys1TypesTrig.FlowToBottom = False
        Me.rbBlInEqSys1TypesTrig.ItemsSizeInDropwDownMode = New System.Drawing.Size(4, 2)
        Me.rbBlInEqSys1TypesTrig.NoScroll = True
        '
        'rbCmdInEqSys1Sin1
        '
        Me.rbCmdInEqSys1Sin1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Sin1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSin1
        Me.rbCmdInEqSys1Sin1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Sin1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Sin1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Cos1
        '
        Me.rbCmdInEqSys1Cos1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Cos1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCos1
        Me.rbCmdInEqSys1Cos1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Cos1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Cos1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Tg1
        '
        Me.rbCmdInEqSys1Tg1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Tg1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemTg1
        Me.rbCmdInEqSys1Tg1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Tg1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Tg1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Ctg1
        '
        Me.rbCmdInEqSys1Ctg1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Ctg1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCtg1
        Me.rbCmdInEqSys1Ctg1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Ctg1.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Ctg1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Sin2
        '
        Me.rbCmdInEqSys1Sin2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Sin2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSin2
        Me.rbCmdInEqSys1Sin2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Sin2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Sin2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Cos2
        '
        Me.rbCmdInEqSys1Cos2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Cos2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCos2
        Me.rbCmdInEqSys1Cos2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Cos2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Cos2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Tg2
        '
        Me.rbCmdInEqSys1Tg2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Tg2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemTg2
        Me.rbCmdInEqSys1Tg2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Tg2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Tg2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys1Ctg2
        '
        Me.rbCmdInEqSys1Ctg2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys1Ctg2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCtg2
        Me.rbCmdInEqSys1Ctg2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys1Ctg2.SmallImage = CType(resources.GetObject("rbCmdInEqSys1Ctg2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Type
        '
        Me.rbCmdInEqSys2Type.DropDownItems.Add(Me.rbLblInEqSys2TypesSimple)
        Me.rbCmdInEqSys2Type.DropDownItems.Add(Me.rbBlInEqSys2TypesSimple)
        Me.rbCmdInEqSys2Type.DropDownItems.Add(Me.rbLblInEqSys2TypesLogExp)
        Me.rbCmdInEqSys2Type.DropDownItems.Add(Me.rbBlInEqSys2TypesLogExp)
        Me.rbCmdInEqSys2Type.DropDownItems.Add(Me.rbLblInEqSys2TypesTrig)
        Me.rbCmdInEqSys2Type.DropDownItems.Add(Me.rbBlInEqSys2TypesTrig)
        Me.rbCmdInEqSys2Type.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEq2Select
        Me.rbCmdInEqSys2Type.MaximumSize = New System.Drawing.Size(210, 105)
        Me.rbCmdInEqSys2Type.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Type.MinimumSize = New System.Drawing.Size(9, 0)
        Me.rbCmdInEqSys2Type.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Type.SmallImage"), System.Drawing.Image)
        Me.rbCmdInEqSys2Type.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbCmdInEqSys2Type.Text = " "
        '
        'rbLblInEqSys2TypesSimple
        '
        Me.rbLblInEqSys2TypesSimple.LabelWidth = 840
        Me.rbLblInEqSys2TypesSimple.Text = "       Простi:"
        '
        'rbBlInEqSys2TypesSimple
        '
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2Linear1)
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2Square1)
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2Mod1)
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2TypeSimpleDummy)
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2Linear2)
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2Square2)
        Me.rbBlInEqSys2TypesSimple.Buttons.Add(Me.rbCmdInEqSys2Mod2)
        Me.rbBlInEqSys2TypesSimple.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqSys2TypesSimple.ControlButtonsWidth = 0
        Me.rbBlInEqSys2TypesSimple.FlowToBottom = False
        Me.rbBlInEqSys2TypesSimple.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 2)
        Me.rbBlInEqSys2TypesSimple.ItemsWideInLargeMode = 3
        Me.rbBlInEqSys2TypesSimple.NoScroll = True
        '
        'rbCmdInEqSys2Linear1
        '
        Me.rbCmdInEqSys2Linear1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Linear1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLinear1
        Me.rbCmdInEqSys2Linear1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Linear1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Linear1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Square1
        '
        Me.rbCmdInEqSys2Square1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Square1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSquare1
        Me.rbCmdInEqSys2Square1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Square1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Square1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Mod1
        '
        Me.rbCmdInEqSys2Mod1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Mod1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemMod1
        Me.rbCmdInEqSys2Mod1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Mod1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Mod1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2TypeSimpleDummy
        '
        Me.rbCmdInEqSys2TypeSimpleDummy.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2TypeSimpleDummy.Enabled = False
        Me.rbCmdInEqSys2TypeSimpleDummy.Image = Global.GraphEqIneqSolver.My.Resources.Resources.Transparent
        Me.rbCmdInEqSys2TypeSimpleDummy.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2TypeSimpleDummy.SmallImage = CType(resources.GetObject("rbCmdInEqSys2TypeSimpleDummy.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Linear2
        '
        Me.rbCmdInEqSys2Linear2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Linear2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLinear2
        Me.rbCmdInEqSys2Linear2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Linear2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Linear2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Square2
        '
        Me.rbCmdInEqSys2Square2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Square2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSquare2
        Me.rbCmdInEqSys2Square2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Square2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Square2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Mod2
        '
        Me.rbCmdInEqSys2Mod2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Mod2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemMod2
        Me.rbCmdInEqSys2Mod2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Mod2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Mod2.SmallImage"), System.Drawing.Image)
        '
        'rbLblInEqSys2TypesLogExp
        '
        Me.rbLblInEqSys2TypesLogExp.Text = "       Показникові та логарифмічні:"
        '
        'rbBlInEqSys2TypesLogExp
        '
        Me.rbBlInEqSys2TypesLogExp.Buttons.Add(Me.rbCmdInEqSys2Exp1)
        Me.rbBlInEqSys2TypesLogExp.Buttons.Add(Me.rbCmdInEqSys2Exp2)
        Me.rbBlInEqSys2TypesLogExp.Buttons.Add(Me.rbCmdInEqSys2Log1)
        Me.rbBlInEqSys2TypesLogExp.Buttons.Add(Me.rbCmdInEqSys2Log2)
        Me.rbBlInEqSys2TypesLogExp.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqSys2TypesLogExp.ControlButtonsWidth = 0
        Me.rbBlInEqSys2TypesLogExp.FlowToBottom = False
        Me.rbBlInEqSys2TypesLogExp.ItemsSizeInDropwDownMode = New System.Drawing.Size(2, 1)
        Me.rbBlInEqSys2TypesLogExp.NoScroll = True
        '
        'rbCmdInEqSys2Exp1
        '
        Me.rbCmdInEqSys2Exp1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Exp1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemExp1
        Me.rbCmdInEqSys2Exp1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Exp1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Exp1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Exp2
        '
        Me.rbCmdInEqSys2Exp2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Exp2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemExp2
        Me.rbCmdInEqSys2Exp2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Exp2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Exp2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Log1
        '
        Me.rbCmdInEqSys2Log1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Log1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLog1
        Me.rbCmdInEqSys2Log1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Log1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Log1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Log2
        '
        Me.rbCmdInEqSys2Log2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Log2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemLog2
        Me.rbCmdInEqSys2Log2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Log2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Log2.SmallImage"), System.Drawing.Image)
        '
        'rbLblInEqSys2TypesTrig
        '
        Me.rbLblInEqSys2TypesTrig.Text = "       Тригонометрічні:"
        '
        'rbBlInEqSys2TypesTrig
        '
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Sin1)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Cos1)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Tg1)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Ctg1)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Sin2)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Cos2)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Tg2)
        Me.rbBlInEqSys2TypesTrig.Buttons.Add(Me.rbCmdInEqSys2Ctg2)
        Me.rbBlInEqSys2TypesTrig.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqSys2TypesTrig.ControlButtonsWidth = 0
        Me.rbBlInEqSys2TypesTrig.FlowToBottom = False
        Me.rbBlInEqSys2TypesTrig.ItemsSizeInDropwDownMode = New System.Drawing.Size(4, 2)
        Me.rbBlInEqSys2TypesTrig.NoScroll = True
        '
        'rbCmdInEqSys2Sin1
        '
        Me.rbCmdInEqSys2Sin1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Sin1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSin1
        Me.rbCmdInEqSys2Sin1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Sin1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Sin1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Cos1
        '
        Me.rbCmdInEqSys2Cos1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Cos1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCos1
        Me.rbCmdInEqSys2Cos1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Cos1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Cos1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Tg1
        '
        Me.rbCmdInEqSys2Tg1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Tg1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemTg1
        Me.rbCmdInEqSys2Tg1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Tg1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Tg1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Ctg1
        '
        Me.rbCmdInEqSys2Ctg1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Ctg1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCtg1
        Me.rbCmdInEqSys2Ctg1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Ctg1.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Ctg1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Sin2
        '
        Me.rbCmdInEqSys2Sin2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Sin2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemSin2
        Me.rbCmdInEqSys2Sin2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Sin2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Sin2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Cos2
        '
        Me.rbCmdInEqSys2Cos2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Cos2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCos2
        Me.rbCmdInEqSys2Cos2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Cos2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Cos2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Tg2
        '
        Me.rbCmdInEqSys2Tg2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Tg2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemTg2
        Me.rbCmdInEqSys2Tg2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Tg2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Tg2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSys2Ctg2
        '
        Me.rbCmdInEqSys2Ctg2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSys2Ctg2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSystemCtg2
        Me.rbCmdInEqSys2Ctg2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSys2Ctg2.SmallImage = CType(resources.GetObject("rbCmdInEqSys2Ctg2.SmallImage"), System.Drawing.Image)
        '
        'rbTxtEqSysA1
        '
        Me.rbTxtEqSysA1.LabelWidth = 25
        Me.rbTxtEqSysA1.Text = "a = "
        Me.rbTxtEqSysA1.TextBoxText = "2"
        '
        'rbTxtEqSysB1
        '
        Me.rbTxtEqSysB1.LabelWidth = 25
        Me.rbTxtEqSysB1.Text = "b = "
        Me.rbTxtEqSysB1.TextBoxText = "3"
        '
        'rbTxtEqSysC1
        '
        Me.rbTxtEqSysC1.LabelWidth = 25
        Me.rbTxtEqSysC1.Text = "c = "
        Me.rbTxtEqSysC1.TextBoxText = "4"
        '
        'rbTxtEqSysD1
        '
        Me.rbTxtEqSysD1.LabelWidth = 25
        Me.rbTxtEqSysD1.Text = "d = "
        Me.rbTxtEqSysD1.TextBoxText = "5"
        '
        'rbTxtEqSysA2
        '
        Me.rbTxtEqSysA2.LabelWidth = 25
        Me.rbTxtEqSysA2.Text = "a = "
        Me.rbTxtEqSysA2.TextBoxText = "3"
        '
        'rbTxtEqSysB2
        '
        Me.rbTxtEqSysB2.LabelWidth = 25
        Me.rbTxtEqSysB2.Text = "b = "
        Me.rbTxtEqSysB2.TextBoxText = "4"
        '
        'rbTxtEqSysC2
        '
        Me.rbTxtEqSysC2.LabelWidth = 25
        Me.rbTxtEqSysC2.Text = "c = "
        Me.rbTxtEqSysC2.TextBoxText = "5"
        '
        'rbTxtEqSysD2
        '
        Me.rbTxtEqSysD2.LabelWidth = 25
        Me.rbTxtEqSysD2.Text = "d = "
        Me.rbTxtEqSysD2.TextBoxText = "6"
        '
        'rbTxtInEqSysA1
        '
        Me.rbTxtInEqSysA1.LabelWidth = 25
        Me.rbTxtInEqSysA1.Text = "a = "
        Me.rbTxtInEqSysA1.TextBoxText = "2"
        '
        'rbTxtInEqSysB1
        '
        Me.rbTxtInEqSysB1.LabelWidth = 25
        Me.rbTxtInEqSysB1.Text = "b = "
        Me.rbTxtInEqSysB1.TextBoxText = "3"
        '
        'rbTxtInEqSysC1
        '
        Me.rbTxtInEqSysC1.LabelWidth = 25
        Me.rbTxtInEqSysC1.Text = "c = "
        Me.rbTxtInEqSysC1.TextBoxText = "4"
        '
        'rbTxtInEqSysD1
        '
        Me.rbTxtInEqSysD1.LabelWidth = 25
        Me.rbTxtInEqSysD1.Text = "d = "
        Me.rbTxtInEqSysD1.TextBoxText = "5"
        '
        'rbTxtInEqSysA2
        '
        Me.rbTxtInEqSysA2.LabelWidth = 25
        Me.rbTxtInEqSysA2.Text = "a = "
        Me.rbTxtInEqSysA2.TextBoxText = "3"
        '
        'rbTxtInEqSysB2
        '
        Me.rbTxtInEqSysB2.LabelWidth = 25
        Me.rbTxtInEqSysB2.Text = "b = "
        Me.rbTxtInEqSysB2.TextBoxText = "4"
        '
        'rbTxtInEqSysC2
        '
        Me.rbTxtInEqSysC2.LabelWidth = 25
        Me.rbTxtInEqSysC2.Text = "c = "
        Me.rbTxtInEqSysC2.TextBoxText = "5"
        '
        'rbTxtInEqSysD2
        '
        Me.rbTxtInEqSysD2.LabelWidth = 25
        Me.rbTxtInEqSysD2.Text = "d = "
        Me.rbTxtInEqSysD2.TextBoxText = "6"
        '
        'rbpEqSysConfig
        '
        Me.rbpEqSysConfig.ButtonMoreVisible = False
        Me.rbpEqSysConfig.Items.Add(Me.rbCmdEqSys1Type)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysA1)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysB1)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysC1)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysD1)
        Me.rbpEqSysConfig.Items.Add(Me.rbCmdEqSys2Type)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysA2)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysB2)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysC2)
        Me.rbpEqSysConfig.Items.Add(Me.rbTxtEqSysD2)
        Me.rbpEqSysConfig.Items.Add(Me.rbChkEqSysAutoRefresh)
        Me.rbpEqSysConfig.Items.Add(Me.rbCmdEqSysRefresh)
        Me.rbpEqSysConfig.Text = "Системи рівняннь"
        '
        'rbChkEqSysAutoRefresh
        '
        Me.rbChkEqSysAutoRefresh.Text = "Автозастосування"
        '
        'rbCmdEqSysRefresh
        '
        Me.rbCmdEqSysRefresh.Image = Global.GraphEqIneqSolver.My.Resources.Resources.RefreshArrow
        Me.rbCmdEqSysRefresh.MaximumSize = New System.Drawing.Size(110, 0)
        Me.rbCmdEqSysRefresh.SmallImage = CType(resources.GetObject("rbCmdEqSysRefresh.SmallImage"), System.Drawing.Image)
        Me.rbCmdEqSysRefresh.Text = "Застосувати параметри"
        '
        'rbpInEqSysConfig
        '
        Me.rbpInEqSysConfig.ButtonMoreVisible = False
        Me.rbpInEqSysConfig.Items.Add(Me.rbCmdInEqSys1Type)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysA1)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysB1)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysC1)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysD1)
        Me.rbpInEqSysConfig.Items.Add(Me.rbCmdInEqSys2Type)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysA2)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysB2)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysC2)
        Me.rbpInEqSysConfig.Items.Add(Me.rbTxtInEqSysD2)
        Me.rbpInEqSysConfig.Items.Add(Me.rbChkInEqSysAutoRefresh)
        Me.rbpInEqSysConfig.Items.Add(Me.rbCmdInEqSysRefresh)
        Me.rbpInEqSysConfig.Text = "Системи нерівностей"
        '
        'rbChkInEqSysAutoRefresh
        '
        Me.rbChkInEqSysAutoRefresh.Text = "Автозастосування"
        '
        'rbCmdInEqSysRefresh
        '
        Me.rbCmdInEqSysRefresh.Image = Global.GraphEqIneqSolver.My.Resources.Resources.RefreshArrow
        Me.rbCmdInEqSysRefresh.MaximumSize = New System.Drawing.Size(110, 0)
        Me.rbCmdInEqSysRefresh.SmallImage = CType(resources.GetObject("rbCmdInEqSysRefresh.SmallImage"), System.Drawing.Image)
        Me.rbCmdInEqSysRefresh.Text = "Застосувати параметри"
        '
        'rbpEqSysSolution
        '
        Me.rbpEqSysSolution.ButtonMoreVisible = False
        Me.rbpEqSysSolution.Items.Add(Me.rbLblEqSysXVal)
        Me.rbpEqSysSolution.Items.Add(Me.rbLblEqSysYVal)
        Me.rbpEqSysSolution.Text = "Координати"
        '
        'rbLblEqSysXVal
        '
        Me.rbLblEqSysXVal.LabelWidth = 150
        Me.rbLblEqSysXVal.Text = "X: ∅"
        Me.rbLblEqSysXVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbLblEqSysYVal
        '
        Me.rbLblEqSysYVal.LabelWidth = 150
        Me.rbLblEqSysYVal.Text = "Y: ∅"
        Me.rbLblEqSysYVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbpInEqSysSolution
        '
        Me.rbpInEqSysSolution.ButtonMoreVisible = False
        Me.rbpInEqSysSolution.Items.Add(Me.rbLblInEqSysXVal)
        Me.rbpInEqSysSolution.Items.Add(Me.rbLblInEqSysYVal)
        Me.rbpInEqSysSolution.Text = "Координати"
        '
        'rbLblInEqSysXVal
        '
        Me.rbLblInEqSysXVal.LabelWidth = 150
        Me.rbLblInEqSysXVal.Text = "X: ∅"
        Me.rbLblInEqSysXVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbLblInEqSysYVal
        '
        Me.rbLblInEqSysYVal.LabelWidth = 150
        Me.rbLblInEqSysYVal.Text = "Y: ∅"
        Me.rbLblInEqSysYVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbtInequalities
        '
        Me.rbtInequalities.Panels.Add(Me.rbpInEqConfig)
        Me.rbtInequalities.Panels.Add(Me.rbpInEqSolution)
        Me.rbtInequalities.Text = "Нерiвностi"
        '
        'rbpInEqConfig
        '
        Me.rbpInEqConfig.ButtonMoreVisible = False
        Me.rbpInEqConfig.Items.Add(Me.rbCmdInEqType)
        Me.rbpInEqConfig.Items.Add(Me.rbTxtInEqA)
        Me.rbpInEqConfig.Items.Add(Me.rbTxtInEqB)
        Me.rbpInEqConfig.Items.Add(Me.rbTxtInEqC)
        Me.rbpInEqConfig.Items.Add(Me.rbTxtInEqD)
        Me.rbpInEqConfig.Items.Add(Me.rbChkInEqAutoRefresh)
        Me.rbpInEqConfig.Items.Add(Me.rbCmdInEqRefresh)
        Me.rbpInEqConfig.Text = "Рiвняння"
        '
        'rbCmdInEqType
        '
        Me.rbCmdInEqType.DropDownItems.Add(Me.rbLblInEqTypesSimple)
        Me.rbCmdInEqType.DropDownItems.Add(Me.rbBlInEqTypesSimple)
        Me.rbCmdInEqType.DropDownItems.Add(Me.rbLblInEqTypesLogExp)
        Me.rbCmdInEqType.DropDownItems.Add(Me.rbBlInEqTypesLogExp)
        Me.rbCmdInEqType.DropDownItems.Add(Me.rbLblInEqTypesTrig)
        Me.rbCmdInEqType.DropDownItems.Add(Me.rbBlInEqTypesTrig)
        Me.rbCmdInEqType.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSelect
        Me.rbCmdInEqType.MaximumSize = New System.Drawing.Size(210, 105)
        Me.rbCmdInEqType.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqType.MinimumSize = New System.Drawing.Size(9, 0)
        Me.rbCmdInEqType.SmallImage = CType(resources.GetObject("rbCmdInEqType.SmallImage"), System.Drawing.Image)
        Me.rbCmdInEqType.Style = System.Windows.Forms.RibbonButtonStyle.DropDown
        Me.rbCmdInEqType.Text = " "
        '
        'rbLblInEqTypesSimple
        '
        Me.rbLblInEqTypesSimple.LabelWidth = 840
        Me.rbLblInEqTypesSimple.Text = "       Простi:"
        '
        'rbBlInEqTypesSimple
        '
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqLinear1)
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqSquare1)
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqMod1)
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqTypeSimpleDummy)
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqLinear2)
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqSquare2)
        Me.rbBlInEqTypesSimple.Buttons.Add(Me.rbCmdInEqMod2)
        Me.rbBlInEqTypesSimple.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqTypesSimple.ControlButtonsWidth = 0
        Me.rbBlInEqTypesSimple.FlowToBottom = False
        Me.rbBlInEqTypesSimple.ItemsSizeInDropwDownMode = New System.Drawing.Size(3, 2)
        Me.rbBlInEqTypesSimple.ItemsWideInLargeMode = 3
        Me.rbBlInEqTypesSimple.NoScroll = True
        '
        'rbCmdInEqLinear1
        '
        Me.rbCmdInEqLinear1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqLinear1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqLinear1
        Me.rbCmdInEqLinear1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqLinear1.SmallImage = CType(resources.GetObject("rbCmdInEqLinear1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSquare1
        '
        Me.rbCmdInEqSquare1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSquare1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSquare1
        Me.rbCmdInEqSquare1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSquare1.SmallImage = CType(resources.GetObject("rbCmdInEqSquare1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqMod1
        '
        Me.rbCmdInEqMod1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqMod1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqMod1
        Me.rbCmdInEqMod1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqMod1.SmallImage = CType(resources.GetObject("rbCmdInEqMod1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqTypeSimpleDummy
        '
        Me.rbCmdInEqTypeSimpleDummy.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqTypeSimpleDummy.Enabled = False
        Me.rbCmdInEqTypeSimpleDummy.Image = Global.GraphEqIneqSolver.My.Resources.Resources.Transparent
        Me.rbCmdInEqTypeSimpleDummy.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqTypeSimpleDummy.SmallImage = CType(resources.GetObject("rbCmdInEqTypeSimpleDummy.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqLinear2
        '
        Me.rbCmdInEqLinear2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqLinear2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqLinear2
        Me.rbCmdInEqLinear2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqLinear2.SmallImage = CType(resources.GetObject("rbCmdInEqLinear2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSquare2
        '
        Me.rbCmdInEqSquare2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSquare2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSquare2
        Me.rbCmdInEqSquare2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSquare2.SmallImage = CType(resources.GetObject("rbCmdInEqSquare2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqMod2
        '
        Me.rbCmdInEqMod2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqMod2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqMod2
        Me.rbCmdInEqMod2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqMod2.SmallImage = CType(resources.GetObject("rbCmdInEqMod2.SmallImage"), System.Drawing.Image)
        '
        'rbLblInEqTypesLogExp
        '
        Me.rbLblInEqTypesLogExp.Text = "       Показникові та логарифмічні:"
        '
        'rbBlInEqTypesLogExp
        '
        Me.rbBlInEqTypesLogExp.Buttons.Add(Me.rbCmdInEqExp1)
        Me.rbBlInEqTypesLogExp.Buttons.Add(Me.rbCmdInEqExp2)
        Me.rbBlInEqTypesLogExp.Buttons.Add(Me.rbCmdInEqLog1)
        Me.rbBlInEqTypesLogExp.Buttons.Add(Me.rbCmdInEqLog2)
        Me.rbBlInEqTypesLogExp.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqTypesLogExp.ControlButtonsWidth = 0
        Me.rbBlInEqTypesLogExp.FlowToBottom = False
        Me.rbBlInEqTypesLogExp.ItemsSizeInDropwDownMode = New System.Drawing.Size(2, 1)
        Me.rbBlInEqTypesLogExp.NoScroll = True
        '
        'rbCmdInEqExp1
        '
        Me.rbCmdInEqExp1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqExp1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqExp1
        Me.rbCmdInEqExp1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqExp1.SmallImage = CType(resources.GetObject("rbCmdInEqExp1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqExp2
        '
        Me.rbCmdInEqExp2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqExp2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqExp2
        Me.rbCmdInEqExp2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqExp2.SmallImage = CType(resources.GetObject("rbCmdInEqExp2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqLog1
        '
        Me.rbCmdInEqLog1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqLog1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqLog1
        Me.rbCmdInEqLog1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqLog1.SmallImage = CType(resources.GetObject("rbCmdInEqLog1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqLog2
        '
        Me.rbCmdInEqLog2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqLog2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqLog2
        Me.rbCmdInEqLog2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqLog2.SmallImage = CType(resources.GetObject("rbCmdInEqLog2.SmallImage"), System.Drawing.Image)
        '
        'rbLblInEqTypesTrig
        '
        Me.rbLblInEqTypesTrig.Text = "       Тригонометрічні:"
        '
        'rbBlInEqTypesTrig
        '
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqSin1)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqCos1)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqTg1)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqCtg1)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqSin2)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqCos2)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqTg2)
        Me.rbBlInEqTypesTrig.Buttons.Add(Me.rbCmdInEqCtg2)
        Me.rbBlInEqTypesTrig.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbBlInEqTypesTrig.ControlButtonsWidth = 0
        Me.rbBlInEqTypesTrig.FlowToBottom = False
        Me.rbBlInEqTypesTrig.ItemsSizeInDropwDownMode = New System.Drawing.Size(4, 2)
        Me.rbBlInEqTypesTrig.NoScroll = True
        '
        'rbCmdInEqSin1
        '
        Me.rbCmdInEqSin1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSin1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSin1
        Me.rbCmdInEqSin1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSin1.SmallImage = CType(resources.GetObject("rbCmdInEqSin1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqCos1
        '
        Me.rbCmdInEqCos1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqCos1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqCos1
        Me.rbCmdInEqCos1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqCos1.SmallImage = CType(resources.GetObject("rbCmdInEqCos1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqTg1
        '
        Me.rbCmdInEqTg1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqTg1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqTg1
        Me.rbCmdInEqTg1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqTg1.SmallImage = CType(resources.GetObject("rbCmdInEqTg1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqCtg1
        '
        Me.rbCmdInEqCtg1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqCtg1.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqCtg1
        Me.rbCmdInEqCtg1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqCtg1.SmallImage = CType(resources.GetObject("rbCmdInEqCtg1.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqSin2
        '
        Me.rbCmdInEqSin2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqSin2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqSin2
        Me.rbCmdInEqSin2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqSin2.SmallImage = CType(resources.GetObject("rbCmdInEqSin2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqCos2
        '
        Me.rbCmdInEqCos2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqCos2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqCos2
        Me.rbCmdInEqCos2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqCos2.SmallImage = CType(resources.GetObject("rbCmdInEqCos2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqTg2
        '
        Me.rbCmdInEqTg2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqTg2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqTg2
        Me.rbCmdInEqTg2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqTg2.SmallImage = CType(resources.GetObject("rbCmdInEqTg2.SmallImage"), System.Drawing.Image)
        '
        'rbCmdInEqCtg2
        '
        Me.rbCmdInEqCtg2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdInEqCtg2.Image = Global.GraphEqIneqSolver.My.Resources.Resources.InEqCtg2
        Me.rbCmdInEqCtg2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large
        Me.rbCmdInEqCtg2.SmallImage = CType(resources.GetObject("rbCmdInEqCtg2.SmallImage"), System.Drawing.Image)
        '
        'rbTxtInEqA
        '
        Me.rbTxtInEqA.LabelWidth = 25
        Me.rbTxtInEqA.Text = "a = "
        Me.rbTxtInEqA.TextBoxText = "2"
        '
        'rbTxtInEqB
        '
        Me.rbTxtInEqB.LabelWidth = 25
        Me.rbTxtInEqB.Text = "b = "
        Me.rbTxtInEqB.TextBoxText = "3"
        '
        'rbTxtInEqC
        '
        Me.rbTxtInEqC.LabelWidth = 25
        Me.rbTxtInEqC.Text = "c = "
        Me.rbTxtInEqC.TextBoxText = "4"
        '
        'rbTxtInEqD
        '
        Me.rbTxtInEqD.LabelWidth = 25
        Me.rbTxtInEqD.Text = "d = "
        Me.rbTxtInEqD.TextBoxText = "5"
        '
        'rbChkInEqAutoRefresh
        '
        Me.rbChkInEqAutoRefresh.Text = "Автозастосування"
        '
        'rbCmdInEqRefresh
        '
        Me.rbCmdInEqRefresh.Image = Global.GraphEqIneqSolver.My.Resources.Resources.RefreshArrow
        Me.rbCmdInEqRefresh.MaximumSize = New System.Drawing.Size(110, 0)
        Me.rbCmdInEqRefresh.SmallImage = CType(resources.GetObject("rbCmdInEqRefresh.SmallImage"), System.Drawing.Image)
        Me.rbCmdInEqRefresh.Text = "Застосувати параметри"
        '
        'rbpInEqSolution
        '
        Me.rbpInEqSolution.ButtonMoreVisible = False
        Me.rbpInEqSolution.Items.Add(Me.rbLblInEqXVal)
        Me.rbpInEqSolution.Items.Add(Me.rbLblInEqYVal)
        Me.rbpInEqSolution.Text = "Розв'язки та координати"
        '
        'rbLblInEqXVal
        '
        Me.rbLblInEqXVal.LabelWidth = 450
        Me.rbLblInEqXVal.Text = "X: ∅"
        Me.rbLblInEqXVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbLblInEqYVal
        '
        Me.rbLblInEqYVal.LabelWidth = 450
        Me.rbLblInEqYVal.Text = "Y: ∅"
        Me.rbLblInEqYVal.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center
        '
        'rbtEquationsSystems
        '
        Me.rbtEquationsSystems.Panels.Add(Me.rbpEqSysConfig)
        Me.rbtEquationsSystems.Panels.Add(Me.rbpEqSysSolution)
        Me.rbtEquationsSystems.Text = "Системи рівнянь"
        '
        'rbtInEqualitiesSystems
        '
        Me.rbtInEqualitiesSystems.Panels.Add(Me.rbpInEqSysConfig)
        Me.rbtInEqualitiesSystems.Panels.Add(Me.rbpInEqSysSolution)
        Me.rbtInEqualitiesSystems.Text = "Системи нерівностей"
        '
        'rbnMain
        '
        Me.rbnMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbnMain.Location = New System.Drawing.Point(0, 0)
        Me.rbnMain.Minimized = False
        Me.rbnMain.Name = "rbnMain"
        '
        '
        '
        Me.rbnMain.OrbDropDown.BorderRoundness = 8
        Me.rbnMain.OrbDropDown.Location = New System.Drawing.Point(0, 0)
        Me.rbnMain.OrbDropDown.MenuItems.Add(Me.rbCmdExit)
        Me.rbnMain.OrbDropDown.Name = ""
        Me.rbnMain.OrbDropDown.Size = New System.Drawing.Size(527, 116)
        Me.rbnMain.OrbDropDown.TabIndex = 0
        Me.rbnMain.OrbImage = Global.GraphEqIneqSolver.My.Resources.Resources.Fx
        '
        '
        '
        Me.rbnMain.QuickAcessToolbar.Visible = False
        Me.rbnMain.Size = New System.Drawing.Size(944, 189)
        Me.rbnMain.TabIndex = 15
        Me.rbnMain.Tabs.Add(Me.rbtEquations)
        Me.rbnMain.Tabs.Add(Me.rbtInequalities)
        Me.rbnMain.Tabs.Add(Me.rbtEquationsSystems)
        Me.rbnMain.Tabs.Add(Me.rbtInEqualitiesSystems)
        Me.rbnMain.TabsMargin = New System.Windows.Forms.Padding(12, 26, 20, 0)
        Me.rbnMain.Text = "rbnMain"
        '
        'rbCmdExit
        '
        Me.rbCmdExit.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbCmdExit.Image = CType(resources.GetObject("rbCmdExit.Image"), System.Drawing.Image)
        Me.rbCmdExit.SmallImage = CType(resources.GetObject("rbCmdExit.SmallImage"), System.Drawing.Image)
        Me.rbCmdExit.Text = "Завершити роботу"
        '
        'lblInvalidParameters
        '
        Me.lblInvalidParameters.AutoSize = True
        Me.lblInvalidParameters.BackColor = System.Drawing.Color.Maroon
        Me.lblInvalidParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvalidParameters.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblInvalidParameters.ForeColor = System.Drawing.Color.Yellow
        Me.lblInvalidParameters.Location = New System.Drawing.Point(220, 394)
        Me.lblInvalidParameters.Name = "lblInvalidParameters"
        Me.lblInvalidParameters.Size = New System.Drawing.Size(357, 26)
        Me.lblInvalidParameters.TabIndex = 16
        Me.lblInvalidParameters.Text = "ПАРАМЕТРИ НЕ Є КОРЕКТНИМИ"
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.BackColor = System.Drawing.Color.White
        Me.lblSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelect.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblSelect.ForeColor = System.Drawing.Color.Black
        Me.lblSelect.Location = New System.Drawing.Point(220, 305)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(536, 26)
        Me.lblSelect.TabIndex = 18
        Me.lblSelect.Text = "ВИБЕРІТЬ РІВНЯННЯ СИСТЕМУ АБО НЕРІВНІСТЬ"
        '
        'lblApply
        '
        Me.lblApply.AutoSize = True
        Me.lblApply.BackColor = System.Drawing.Color.White
        Me.lblApply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApply.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblApply.ForeColor = System.Drawing.Color.Black
        Me.lblApply.Location = New System.Drawing.Point(220, 346)
        Me.lblApply.Name = "lblApply"
        Me.lblApply.Size = New System.Drawing.Size(292, 26)
        Me.lblApply.TabIndex = 19
        Me.lblApply.Text = "ЗАСТОСУЙТЕ ПАРАМЕТРИ"
        '
        'rbBlEqSys1TypesSq
        '
        Me.rbBlEqSys1TypesSq.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.rbBlEqSys1TypesSq.Image = CType(resources.GetObject("rbBlEqSys1TypesSq.Image"), System.Drawing.Image)
        Me.rbBlEqSys1TypesSq.SmallImage = CType(resources.GetObject("rbBlEqSys1TypesSq.SmallImage"), System.Drawing.Image)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 684)
        Me.Controls.Add(Me.lblApply)
        Me.Controls.Add(Me.lblSelect)
        Me.Controls.Add(Me.lblInvalidParameters)
        Me.Controls.Add(Me.rbnMain)
        Me.Controls.Add(Me.zedMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Text = "Розв'язання рiвнянь, нерiвностей та їх систем графiчним методом"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents zedMain As ZedGraph.ZedGraphControl
    Friend WithEvents rbnMain As System.Windows.Forms.Ribbon
    Friend WithEvents rbtEquations As System.Windows.Forms.RibbonTab
    Friend WithEvents rbpEqConfig As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbpEqSysConfig As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbpInEqSysConfig As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbpInEqConfig As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbCmdEqType As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Type As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Type As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Type As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Type As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqType As System.Windows.Forms.RibbonButton
    Friend WithEvents rbBlEqTypesSimple As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlEqSys1TypesSimple As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlEqSys2TypesSimple As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqSys1TypesSimple As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqSys2TypesSimple As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbCmdEqSquare As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqLinear As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqLog As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqCos As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSin As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqTg As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqCtg As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqExp As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqMod As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Linear As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Log As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Sin As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Tg As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Ctg As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Exp As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys1Mod As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Linear As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Log As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Sin As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Tg As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Ctg As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Exp As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdEqSys2Mod As System.Windows.Forms.RibbonButton
    Friend WithEvents rbLblEqTypesSimple As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSys1TypesSimple As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSys2TypesSimple As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbCmdExit As System.Windows.Forms.RibbonOrbMenuItem
    Friend WithEvents rbtInequalities As System.Windows.Forms.RibbonTab
    Friend WithEvents rbtEquationsSystems As System.Windows.Forms.RibbonTab
    Friend WithEvents rbtInEqualitiesSystems As System.Windows.Forms.RibbonTab
    Friend WithEvents rbTxtEqA As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqB As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqC As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqD As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqA As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqB As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqC As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqD As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysA1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysB1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysC1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysD1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysA2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysB2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysC2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtEqSysD2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysA1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysB1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysC1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysD1 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysA2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysB2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysC2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbTxtInEqSysD2 As System.Windows.Forms.RibbonTextBox
    Friend WithEvents rbpEqSolution As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbpEqSysSolution As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbpInEqSysSolution As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbpInEqSolution As System.Windows.Forms.RibbonPanel
    Friend WithEvents rbLblEqTypesLogExp As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSys1TypesLogExp As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSys2TypesLogExp As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbBlEqTypesLogExp As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlEqSys1TypesLogExp As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlEqSys2TypesLogExp As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbLblEqTypesTrig As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbBlEqTypesTrig As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlEqSys1TypesTrig As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlEqSys2TypesTrig As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbChkEqAutoRefresh As System.Windows.Forms.RibbonCheckBox
    Friend WithEvents rbCmdEqRefresh As System.Windows.Forms.RibbonButton
    Friend WithEvents rbChkEqSysAutoRefresh As System.Windows.Forms.RibbonCheckBox
    Friend WithEvents rbCmdEqSysRefresh As System.Windows.Forms.RibbonButton
    Friend WithEvents rbChkInEqSysAutoRefresh As System.Windows.Forms.RibbonCheckBox
    Friend WithEvents rbCmdInEqSysRefresh As System.Windows.Forms.RibbonButton
    Friend WithEvents rbChkInEqAutoRefresh As System.Windows.Forms.RibbonCheckBox
    Friend WithEvents rbCmdInEqRefresh As System.Windows.Forms.RibbonButton
    Friend WithEvents rbLblEqXVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqYVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSysXVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSysYVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSysXVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSysYVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqXVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqYVal As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqTypesSimple As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSys1TypesSimple As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSys2TypesSimple As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqTypesLogExp As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqTypesTrig As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSys1TypesLogExp As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSys1TypesTrig As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSys2TypesLogExp As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblInEqSys2TypesTrig As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSys1TypesTrig As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbLblEqSys2TypesTrig As System.Windows.Forms.RibbonLabel
    Friend WithEvents rbBlInEqTypesSimple As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqTypesLogExp As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqTypesTrig As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqSys1TypesLogExp As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqSys1TypesTrig As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqSys2TypesLogExp As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbBlInEqSys2TypesTrig As System.Windows.Forms.RibbonButtonList
    Friend WithEvents rbCmdInEqLinear1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqLinear2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSquare1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSquare2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqMod1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqMod2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqExp1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqExp2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqLog1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqLog2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSin1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqCos1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqTg1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqCtg1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSin2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqCos2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqTg2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqCtg2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqTypeSimpleDummy As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Linear1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Linear2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Square1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Square2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Mod1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Mod2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Exp1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Exp2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Log1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Log2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Sin1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Cos1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Tg1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Ctg1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Sin2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Cos2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Tg2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1Ctg2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys1TypeSimpleDummy As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Linear1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Linear2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Square1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Square2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Mod1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Mod2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Exp1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Exp2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Log1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Log2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Sin1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Cos1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Tg1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Ctg1 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Sin2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Cos2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Tg2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2Ctg2 As System.Windows.Forms.RibbonButton
    Friend WithEvents rbCmdInEqSys2TypeSimpleDummy As System.Windows.Forms.RibbonButton
    Friend WithEvents lblInvalidParameters As System.Windows.Forms.Label
    Friend WithEvents lblSelect As System.Windows.Forms.Label
    Friend WithEvents lblApply As System.Windows.Forms.Label
    Friend WithEvents rbBlEqSys1TypesSq As System.Windows.Forms.RibbonButton

End Class
