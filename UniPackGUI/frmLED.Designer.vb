<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLED
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLED))
        Me.rtbLED = New System.Windows.Forms.RichTextBox()
        Me.tipHelper = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtOn_X = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tabHelper = New System.Windows.Forms.TabControl()
        Me.tabOn = New System.Windows.Forms.TabPage()
        Me.btnColorTest = New System.Windows.Forms.PictureBox()
        Me.btnAddTurnOn = New System.Windows.Forms.Button()
        Me.btnPickColor = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtColorMsg = New System.Windows.Forms.Label()
        Me.checkUseLaunchColor = New System.Windows.Forms.CheckBox()
        Me.textColor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOn_Y = New System.Windows.Forms.TextBox()
        Me.tabOff = New System.Windows.Forms.TabPage()
        Me.btnAddTurnOff = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbTurnOffY = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbTurnOffX = New System.Windows.Forms.TextBox()
        Me.tabWait = New System.Windows.Forms.TabPage()
        Me.btnAddWait = New System.Windows.Forms.Button()
        Me.labelJust = New System.Windows.Forms.Label()
        Me.tbWaitMSec = New System.Windows.Forms.TextBox()
        Me.colorPick = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.uni1_1 = New System.Windows.Forms.Button()
        Me.uni1_2 = New System.Windows.Forms.Button()
        Me.uni1_3 = New System.Windows.Forms.Button()
        Me.uni1_4 = New System.Windows.Forms.Button()
        Me.uni1_5 = New System.Windows.Forms.Button()
        Me.uni1_6 = New System.Windows.Forms.Button()
        Me.uni1_7 = New System.Windows.Forms.Button()
        Me.uni1_8 = New System.Windows.Forms.Button()
        Me.uni2_1 = New System.Windows.Forms.Button()
        Me.uni2_2 = New System.Windows.Forms.Button()
        Me.uni2_3 = New System.Windows.Forms.Button()
        Me.uni2_4 = New System.Windows.Forms.Button()
        Me.uni2_5 = New System.Windows.Forms.Button()
        Me.uni2_6 = New System.Windows.Forms.Button()
        Me.uni2_7 = New System.Windows.Forms.Button()
        Me.uni2_8 = New System.Windows.Forms.Button()
        Me.uni3_1 = New System.Windows.Forms.Button()
        Me.uni3_2 = New System.Windows.Forms.Button()
        Me.uni3_3 = New System.Windows.Forms.Button()
        Me.uni3_4 = New System.Windows.Forms.Button()
        Me.uni3_5 = New System.Windows.Forms.Button()
        Me.uni3_6 = New System.Windows.Forms.Button()
        Me.uni3_7 = New System.Windows.Forms.Button()
        Me.uni3_8 = New System.Windows.Forms.Button()
        Me.uni4_1 = New System.Windows.Forms.Button()
        Me.uni4_2 = New System.Windows.Forms.Button()
        Me.uni4_3 = New System.Windows.Forms.Button()
        Me.uni4_4 = New System.Windows.Forms.Button()
        Me.uni4_5 = New System.Windows.Forms.Button()
        Me.uni4_6 = New System.Windows.Forms.Button()
        Me.uni4_7 = New System.Windows.Forms.Button()
        Me.uni4_8 = New System.Windows.Forms.Button()
        Me.uni5_1 = New System.Windows.Forms.Button()
        Me.uni5_2 = New System.Windows.Forms.Button()
        Me.uni5_3 = New System.Windows.Forms.Button()
        Me.uni5_4 = New System.Windows.Forms.Button()
        Me.uni5_5 = New System.Windows.Forms.Button()
        Me.uni5_6 = New System.Windows.Forms.Button()
        Me.uni5_7 = New System.Windows.Forms.Button()
        Me.uni5_8 = New System.Windows.Forms.Button()
        Me.uni6_1 = New System.Windows.Forms.Button()
        Me.uni6_2 = New System.Windows.Forms.Button()
        Me.uni6_3 = New System.Windows.Forms.Button()
        Me.uni6_4 = New System.Windows.Forms.Button()
        Me.uni6_5 = New System.Windows.Forms.Button()
        Me.uni6_6 = New System.Windows.Forms.Button()
        Me.uni6_7 = New System.Windows.Forms.Button()
        Me.uni6_8 = New System.Windows.Forms.Button()
        Me.uni7_1 = New System.Windows.Forms.Button()
        Me.uni7_2 = New System.Windows.Forms.Button()
        Me.uni7_3 = New System.Windows.Forms.Button()
        Me.uni7_4 = New System.Windows.Forms.Button()
        Me.uni7_5 = New System.Windows.Forms.Button()
        Me.uni7_6 = New System.Windows.Forms.Button()
        Me.uni7_7 = New System.Windows.Forms.Button()
        Me.uni7_8 = New System.Windows.Forms.Button()
        Me.uni8_1 = New System.Windows.Forms.Button()
        Me.uni8_2 = New System.Windows.Forms.Button()
        Me.uni8_3 = New System.Windows.Forms.Button()
        Me.uni8_4 = New System.Windows.Forms.Button()
        Me.uni8_5 = New System.Windows.Forms.Button()
        Me.uni8_6 = New System.Windows.Forms.Button()
        Me.uni8_7 = New System.Windows.Forms.Button()
        Me.uni8_8 = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLEDtest = New System.Windows.Forms.Button()
        Me.listMultiMaps = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTIP = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTimePassed = New System.Windows.Forms.Label()
        Me.pbLNum = New System.Windows.Forms.PictureBox()
        Me.cbLaunchPadColor = New UniPackGUI.ColorComboBox()
        Me.tabHelper.SuspendLayout()
        Me.tabOn.SuspendLayout()
        CType(Me.btnColorTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOff.SuspendLayout()
        Me.tabWait.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbLNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtbLED
        '
        Me.rtbLED.Location = New System.Drawing.Point(48, 12)
        Me.rtbLED.Name = "rtbLED"
        Me.rtbLED.Size = New System.Drawing.Size(305, 295)
        Me.rtbLED.TabIndex = 0
        Me.rtbLED.Text = ""
        '
        'txtOn_X
        '
        Me.txtOn_X.Location = New System.Drawing.Point(24, 11)
        Me.txtOn_X.Name = "txtOn_X"
        Me.txtOn_X.Size = New System.Drawing.Size(40, 21)
        Me.txtOn_X.TabIndex = 0
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 14)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(13, 12)
        Me.label2.TabIndex = 4
        Me.label2.Text = "X"
        '
        'tabHelper
        '
        Me.tabHelper.Controls.Add(Me.tabOn)
        Me.tabHelper.Controls.Add(Me.tabOff)
        Me.tabHelper.Controls.Add(Me.tabWait)
        Me.tabHelper.Location = New System.Drawing.Point(359, 12)
        Me.tabHelper.Name = "tabHelper"
        Me.tabHelper.SelectedIndex = 0
        Me.tabHelper.Size = New System.Drawing.Size(199, 295)
        Me.tabHelper.TabIndex = 8
        '
        'tabOn
        '
        Me.tabOn.Controls.Add(Me.cbLaunchPadColor)
        Me.tabOn.Controls.Add(Me.btnColorTest)
        Me.tabOn.Controls.Add(Me.btnAddTurnOn)
        Me.tabOn.Controls.Add(Me.btnPickColor)
        Me.tabOn.Controls.Add(Me.Label3)
        Me.tabOn.Controls.Add(Me.txtColorMsg)
        Me.tabOn.Controls.Add(Me.checkUseLaunchColor)
        Me.tabOn.Controls.Add(Me.textColor)
        Me.tabOn.Controls.Add(Me.Label1)
        Me.tabOn.Controls.Add(Me.txtOn_Y)
        Me.tabOn.Controls.Add(Me.label2)
        Me.tabOn.Controls.Add(Me.txtOn_X)
        Me.tabOn.Location = New System.Drawing.Point(4, 22)
        Me.tabOn.Name = "tabOn"
        Me.tabOn.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOn.Size = New System.Drawing.Size(191, 269)
        Me.tabOn.TabIndex = 0
        Me.tabOn.Text = "Turn On"
        Me.tabOn.UseVisualStyleBackColor = True
        '
        'btnColorTest
        '
        Me.btnColorTest.Location = New System.Drawing.Point(96, 171)
        Me.btnColorTest.Name = "btnColorTest"
        Me.btnColorTest.Size = New System.Drawing.Size(64, 37)
        Me.btnColorTest.TabIndex = 15
        Me.btnColorTest.TabStop = False
        '
        'btnAddTurnOn
        '
        Me.btnAddTurnOn.Location = New System.Drawing.Point(96, 226)
        Me.btnAddTurnOn.Name = "btnAddTurnOn"
        Me.btnAddTurnOn.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTurnOn.TabIndex = 10
        Me.btnAddTurnOn.Text = "Add Line"
        Me.btnAddTurnOn.UseVisualStyleBackColor = True
        '
        'btnPickColor
        '
        Me.btnPickColor.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.btnPickColor.Location = New System.Drawing.Point(5, 85)
        Me.btnPickColor.Name = "btnPickColor"
        Me.btnPickColor.Size = New System.Drawing.Size(112, 19)
        Me.btnPickColor.TabIndex = 9
        Me.btnPickColor.Text = "Pick HTML Color"
        Me.btnPickColor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Color Preview"
        '
        'txtColorMsg
        '
        Me.txtColorMsg.AutoSize = True
        Me.txtColorMsg.Location = New System.Drawing.Point(6, 129)
        Me.txtColorMsg.Name = "txtColorMsg"
        Me.txtColorMsg.Size = New System.Drawing.Size(111, 12)
        Me.txtColorMsg.TabIndex = 8
        Me.txtColorMsg.Text = "HTML Color Code:"
        '
        'checkUseLaunchColor
        '
        Me.checkUseLaunchColor.AutoSize = True
        Me.checkUseLaunchColor.Location = New System.Drawing.Point(5, 110)
        Me.checkUseLaunchColor.Name = "checkUseLaunchColor"
        Me.checkUseLaunchColor.Size = New System.Drawing.Size(181, 16)
        Me.checkUseLaunchColor.TabIndex = 6
        Me.checkUseLaunchColor.Text = "Use Launchpad Color Code"
        Me.checkUseLaunchColor.UseVisualStyleBackColor = True
        '
        'textColor
        '
        Me.textColor.Location = New System.Drawing.Point(8, 144)
        Me.textColor.Name = "textColor"
        Me.textColor.Size = New System.Drawing.Size(122, 21)
        Me.textColor.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Y"
        '
        'txtOn_Y
        '
        Me.txtOn_Y.Location = New System.Drawing.Point(24, 38)
        Me.txtOn_Y.Name = "txtOn_Y"
        Me.txtOn_Y.Size = New System.Drawing.Size(40, 21)
        Me.txtOn_Y.TabIndex = 0
        '
        'tabOff
        '
        Me.tabOff.Controls.Add(Me.btnAddTurnOff)
        Me.tabOff.Controls.Add(Me.Label5)
        Me.tabOff.Controls.Add(Me.tbTurnOffY)
        Me.tabOff.Controls.Add(Me.Label6)
        Me.tabOff.Controls.Add(Me.tbTurnOffX)
        Me.tabOff.Location = New System.Drawing.Point(4, 22)
        Me.tabOff.Name = "tabOff"
        Me.tabOff.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOff.Size = New System.Drawing.Size(191, 269)
        Me.tabOff.TabIndex = 1
        Me.tabOff.Text = "Turn Off"
        Me.tabOff.UseVisualStyleBackColor = True
        '
        'btnAddTurnOff
        '
        Me.btnAddTurnOff.Location = New System.Drawing.Point(96, 226)
        Me.btnAddTurnOff.Name = "btnAddTurnOff"
        Me.btnAddTurnOff.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTurnOff.TabIndex = 11
        Me.btnAddTurnOff.Text = "Add Line"
        Me.btnAddTurnOff.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Y"
        '
        'tbTurnOffY
        '
        Me.tbTurnOffY.Location = New System.Drawing.Point(24, 38)
        Me.tbTurnOffY.Name = "tbTurnOffY"
        Me.tbTurnOffY.Size = New System.Drawing.Size(40, 21)
        Me.tbTurnOffY.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "X"
        '
        'tbTurnOffX
        '
        Me.tbTurnOffX.Location = New System.Drawing.Point(24, 11)
        Me.tbTurnOffX.Name = "tbTurnOffX"
        Me.tbTurnOffX.Size = New System.Drawing.Size(40, 21)
        Me.tbTurnOffX.TabIndex = 6
        '
        'tabWait
        '
        Me.tabWait.Controls.Add(Me.btnAddWait)
        Me.tabWait.Controls.Add(Me.labelJust)
        Me.tabWait.Controls.Add(Me.tbWaitMSec)
        Me.tabWait.Location = New System.Drawing.Point(4, 22)
        Me.tabWait.Name = "tabWait"
        Me.tabWait.Size = New System.Drawing.Size(191, 269)
        Me.tabWait.TabIndex = 2
        Me.tabWait.Text = "Wait"
        Me.tabWait.UseVisualStyleBackColor = True
        '
        'btnAddWait
        '
        Me.btnAddWait.Location = New System.Drawing.Point(96, 226)
        Me.btnAddWait.Name = "btnAddWait"
        Me.btnAddWait.Size = New System.Drawing.Size(75, 23)
        Me.btnAddWait.TabIndex = 11
        Me.btnAddWait.Text = "Add Line"
        Me.btnAddWait.UseVisualStyleBackColor = True
        '
        'labelJust
        '
        Me.labelJust.AutoSize = True
        Me.labelJust.Location = New System.Drawing.Point(17, 30)
        Me.labelJust.Name = "labelJust"
        Me.labelJust.Size = New System.Drawing.Size(67, 12)
        Me.labelJust.TabIndex = 10
        Me.labelJust.Text = "Milisecond"
        '
        'tbWaitMSec
        '
        Me.tbWaitMSec.Location = New System.Drawing.Point(90, 27)
        Me.tbWaitMSec.Name = "tbWaitMSec"
        Me.tbWaitMSec.Size = New System.Drawing.Size(66, 21)
        Me.tbWaitMSec.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.LightGray
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_6, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_7, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni1_8, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_5, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_6, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_7, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni2_8, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_4, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_5, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_6, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_7, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni3_8, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_2, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_3, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_4, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_5, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_6, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_7, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni4_8, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_1, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_2, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_3, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_4, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_5, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_6, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_7, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni5_8, 7, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_1, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_2, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_3, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_4, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_5, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_6, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_7, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni6_8, 7, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_1, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_2, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_3, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_4, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_5, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_6, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_7, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni7_8, 7, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_1, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_2, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_3, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_4, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_5, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_6, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_7, 6, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.uni8_8, 7, 7)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(577, 23)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(280, 258)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'uni1_1
        '
        Me.uni1_1.BackColor = System.Drawing.Color.Gray
        Me.uni1_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_1.Location = New System.Drawing.Point(3, 3)
        Me.uni1_1.Name = "uni1_1"
        Me.uni1_1.Size = New System.Drawing.Size(29, 26)
        Me.uni1_1.TabIndex = 0
        Me.uni1_1.UseVisualStyleBackColor = False
        '
        'uni1_2
        '
        Me.uni1_2.BackColor = System.Drawing.Color.Gray
        Me.uni1_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_2.ForeColor = System.Drawing.Color.Black
        Me.uni1_2.Location = New System.Drawing.Point(38, 3)
        Me.uni1_2.Name = "uni1_2"
        Me.uni1_2.Size = New System.Drawing.Size(29, 26)
        Me.uni1_2.TabIndex = 1
        Me.uni1_2.UseVisualStyleBackColor = False
        '
        'uni1_3
        '
        Me.uni1_3.BackColor = System.Drawing.Color.Gray
        Me.uni1_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_3.ForeColor = System.Drawing.Color.Black
        Me.uni1_3.Location = New System.Drawing.Point(73, 3)
        Me.uni1_3.Name = "uni1_3"
        Me.uni1_3.Size = New System.Drawing.Size(29, 26)
        Me.uni1_3.TabIndex = 1
        Me.uni1_3.UseVisualStyleBackColor = False
        '
        'uni1_4
        '
        Me.uni1_4.BackColor = System.Drawing.Color.Gray
        Me.uni1_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_4.ForeColor = System.Drawing.Color.Black
        Me.uni1_4.Location = New System.Drawing.Point(108, 3)
        Me.uni1_4.Name = "uni1_4"
        Me.uni1_4.Size = New System.Drawing.Size(29, 26)
        Me.uni1_4.TabIndex = 1
        Me.uni1_4.UseVisualStyleBackColor = False
        '
        'uni1_5
        '
        Me.uni1_5.BackColor = System.Drawing.Color.Gray
        Me.uni1_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_5.ForeColor = System.Drawing.Color.Black
        Me.uni1_5.Location = New System.Drawing.Point(143, 3)
        Me.uni1_5.Name = "uni1_5"
        Me.uni1_5.Size = New System.Drawing.Size(29, 26)
        Me.uni1_5.TabIndex = 1
        Me.uni1_5.UseVisualStyleBackColor = False
        '
        'uni1_6
        '
        Me.uni1_6.BackColor = System.Drawing.Color.Gray
        Me.uni1_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_6.ForeColor = System.Drawing.Color.Black
        Me.uni1_6.Location = New System.Drawing.Point(178, 3)
        Me.uni1_6.Name = "uni1_6"
        Me.uni1_6.Size = New System.Drawing.Size(29, 26)
        Me.uni1_6.TabIndex = 1
        Me.uni1_6.UseVisualStyleBackColor = False
        '
        'uni1_7
        '
        Me.uni1_7.BackColor = System.Drawing.Color.Gray
        Me.uni1_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_7.ForeColor = System.Drawing.Color.Black
        Me.uni1_7.Location = New System.Drawing.Point(213, 3)
        Me.uni1_7.Name = "uni1_7"
        Me.uni1_7.Size = New System.Drawing.Size(29, 26)
        Me.uni1_7.TabIndex = 1
        Me.uni1_7.UseVisualStyleBackColor = False
        '
        'uni1_8
        '
        Me.uni1_8.BackColor = System.Drawing.Color.Gray
        Me.uni1_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni1_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni1_8.ForeColor = System.Drawing.Color.Black
        Me.uni1_8.Location = New System.Drawing.Point(248, 3)
        Me.uni1_8.Name = "uni1_8"
        Me.uni1_8.Size = New System.Drawing.Size(29, 26)
        Me.uni1_8.TabIndex = 1
        Me.uni1_8.UseVisualStyleBackColor = False
        '
        'uni2_1
        '
        Me.uni2_1.BackColor = System.Drawing.Color.Gray
        Me.uni2_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_1.ForeColor = System.Drawing.Color.Black
        Me.uni2_1.Location = New System.Drawing.Point(3, 35)
        Me.uni2_1.Name = "uni2_1"
        Me.uni2_1.Size = New System.Drawing.Size(29, 26)
        Me.uni2_1.TabIndex = 1
        Me.uni2_1.UseVisualStyleBackColor = False
        '
        'uni2_2
        '
        Me.uni2_2.BackColor = System.Drawing.Color.Gray
        Me.uni2_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_2.ForeColor = System.Drawing.Color.Black
        Me.uni2_2.Location = New System.Drawing.Point(38, 35)
        Me.uni2_2.Name = "uni2_2"
        Me.uni2_2.Size = New System.Drawing.Size(29, 26)
        Me.uni2_2.TabIndex = 1
        Me.uni2_2.UseVisualStyleBackColor = False
        '
        'uni2_3
        '
        Me.uni2_3.BackColor = System.Drawing.Color.Gray
        Me.uni2_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_3.ForeColor = System.Drawing.Color.Black
        Me.uni2_3.Location = New System.Drawing.Point(73, 35)
        Me.uni2_3.Name = "uni2_3"
        Me.uni2_3.Size = New System.Drawing.Size(29, 26)
        Me.uni2_3.TabIndex = 1
        Me.uni2_3.UseVisualStyleBackColor = False
        '
        'uni2_4
        '
        Me.uni2_4.BackColor = System.Drawing.Color.Gray
        Me.uni2_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_4.ForeColor = System.Drawing.Color.Black
        Me.uni2_4.Location = New System.Drawing.Point(108, 35)
        Me.uni2_4.Name = "uni2_4"
        Me.uni2_4.Size = New System.Drawing.Size(29, 26)
        Me.uni2_4.TabIndex = 1
        Me.uni2_4.UseVisualStyleBackColor = False
        '
        'uni2_5
        '
        Me.uni2_5.BackColor = System.Drawing.Color.Gray
        Me.uni2_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_5.ForeColor = System.Drawing.Color.Black
        Me.uni2_5.Location = New System.Drawing.Point(143, 35)
        Me.uni2_5.Name = "uni2_5"
        Me.uni2_5.Size = New System.Drawing.Size(29, 26)
        Me.uni2_5.TabIndex = 1
        Me.uni2_5.UseVisualStyleBackColor = False
        '
        'uni2_6
        '
        Me.uni2_6.BackColor = System.Drawing.Color.Gray
        Me.uni2_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_6.ForeColor = System.Drawing.Color.Black
        Me.uni2_6.Location = New System.Drawing.Point(178, 35)
        Me.uni2_6.Name = "uni2_6"
        Me.uni2_6.Size = New System.Drawing.Size(29, 26)
        Me.uni2_6.TabIndex = 1
        Me.uni2_6.UseVisualStyleBackColor = False
        '
        'uni2_7
        '
        Me.uni2_7.BackColor = System.Drawing.Color.Gray
        Me.uni2_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_7.ForeColor = System.Drawing.Color.Black
        Me.uni2_7.Location = New System.Drawing.Point(213, 35)
        Me.uni2_7.Name = "uni2_7"
        Me.uni2_7.Size = New System.Drawing.Size(29, 26)
        Me.uni2_7.TabIndex = 1
        Me.uni2_7.UseVisualStyleBackColor = False
        '
        'uni2_8
        '
        Me.uni2_8.BackColor = System.Drawing.Color.Gray
        Me.uni2_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni2_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni2_8.ForeColor = System.Drawing.Color.Black
        Me.uni2_8.Location = New System.Drawing.Point(248, 35)
        Me.uni2_8.Name = "uni2_8"
        Me.uni2_8.Size = New System.Drawing.Size(29, 26)
        Me.uni2_8.TabIndex = 1
        Me.uni2_8.UseVisualStyleBackColor = False
        '
        'uni3_1
        '
        Me.uni3_1.BackColor = System.Drawing.Color.Gray
        Me.uni3_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_1.ForeColor = System.Drawing.Color.Black
        Me.uni3_1.Location = New System.Drawing.Point(3, 67)
        Me.uni3_1.Name = "uni3_1"
        Me.uni3_1.Size = New System.Drawing.Size(29, 26)
        Me.uni3_1.TabIndex = 1
        Me.uni3_1.UseVisualStyleBackColor = False
        '
        'uni3_2
        '
        Me.uni3_2.BackColor = System.Drawing.Color.Gray
        Me.uni3_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_2.ForeColor = System.Drawing.Color.Black
        Me.uni3_2.Location = New System.Drawing.Point(38, 67)
        Me.uni3_2.Name = "uni3_2"
        Me.uni3_2.Size = New System.Drawing.Size(29, 26)
        Me.uni3_2.TabIndex = 1
        Me.uni3_2.UseVisualStyleBackColor = False
        '
        'uni3_3
        '
        Me.uni3_3.BackColor = System.Drawing.Color.Gray
        Me.uni3_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_3.ForeColor = System.Drawing.Color.Black
        Me.uni3_3.Location = New System.Drawing.Point(73, 67)
        Me.uni3_3.Name = "uni3_3"
        Me.uni3_3.Size = New System.Drawing.Size(29, 26)
        Me.uni3_3.TabIndex = 1
        Me.uni3_3.UseVisualStyleBackColor = False
        '
        'uni3_4
        '
        Me.uni3_4.BackColor = System.Drawing.Color.Gray
        Me.uni3_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_4.ForeColor = System.Drawing.Color.Black
        Me.uni3_4.Location = New System.Drawing.Point(108, 67)
        Me.uni3_4.Name = "uni3_4"
        Me.uni3_4.Size = New System.Drawing.Size(29, 26)
        Me.uni3_4.TabIndex = 1
        Me.uni3_4.UseVisualStyleBackColor = False
        '
        'uni3_5
        '
        Me.uni3_5.BackColor = System.Drawing.Color.Gray
        Me.uni3_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_5.ForeColor = System.Drawing.Color.Black
        Me.uni3_5.Location = New System.Drawing.Point(143, 67)
        Me.uni3_5.Name = "uni3_5"
        Me.uni3_5.Size = New System.Drawing.Size(29, 26)
        Me.uni3_5.TabIndex = 1
        Me.uni3_5.UseVisualStyleBackColor = False
        '
        'uni3_6
        '
        Me.uni3_6.BackColor = System.Drawing.Color.Gray
        Me.uni3_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_6.ForeColor = System.Drawing.Color.Black
        Me.uni3_6.Location = New System.Drawing.Point(178, 67)
        Me.uni3_6.Name = "uni3_6"
        Me.uni3_6.Size = New System.Drawing.Size(29, 26)
        Me.uni3_6.TabIndex = 1
        Me.uni3_6.UseVisualStyleBackColor = False
        '
        'uni3_7
        '
        Me.uni3_7.BackColor = System.Drawing.Color.Gray
        Me.uni3_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_7.ForeColor = System.Drawing.Color.Black
        Me.uni3_7.Location = New System.Drawing.Point(213, 67)
        Me.uni3_7.Name = "uni3_7"
        Me.uni3_7.Size = New System.Drawing.Size(29, 26)
        Me.uni3_7.TabIndex = 1
        Me.uni3_7.UseVisualStyleBackColor = False
        '
        'uni3_8
        '
        Me.uni3_8.BackColor = System.Drawing.Color.Gray
        Me.uni3_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni3_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni3_8.ForeColor = System.Drawing.Color.Black
        Me.uni3_8.Location = New System.Drawing.Point(248, 67)
        Me.uni3_8.Name = "uni3_8"
        Me.uni3_8.Size = New System.Drawing.Size(29, 26)
        Me.uni3_8.TabIndex = 1
        Me.uni3_8.UseVisualStyleBackColor = False
        '
        'uni4_1
        '
        Me.uni4_1.BackColor = System.Drawing.Color.Gray
        Me.uni4_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_1.ForeColor = System.Drawing.Color.Black
        Me.uni4_1.Location = New System.Drawing.Point(3, 99)
        Me.uni4_1.Name = "uni4_1"
        Me.uni4_1.Size = New System.Drawing.Size(29, 26)
        Me.uni4_1.TabIndex = 1
        Me.uni4_1.UseVisualStyleBackColor = False
        '
        'uni4_2
        '
        Me.uni4_2.BackColor = System.Drawing.Color.Gray
        Me.uni4_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_2.ForeColor = System.Drawing.Color.Black
        Me.uni4_2.Location = New System.Drawing.Point(38, 99)
        Me.uni4_2.Name = "uni4_2"
        Me.uni4_2.Size = New System.Drawing.Size(29, 26)
        Me.uni4_2.TabIndex = 1
        Me.uni4_2.UseVisualStyleBackColor = False
        '
        'uni4_3
        '
        Me.uni4_3.BackColor = System.Drawing.Color.Gray
        Me.uni4_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_3.ForeColor = System.Drawing.Color.Black
        Me.uni4_3.Location = New System.Drawing.Point(73, 99)
        Me.uni4_3.Name = "uni4_3"
        Me.uni4_3.Size = New System.Drawing.Size(29, 26)
        Me.uni4_3.TabIndex = 1
        Me.uni4_3.UseVisualStyleBackColor = False
        '
        'uni4_4
        '
        Me.uni4_4.BackColor = System.Drawing.Color.Gray
        Me.uni4_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_4.ForeColor = System.Drawing.Color.Black
        Me.uni4_4.Location = New System.Drawing.Point(108, 99)
        Me.uni4_4.Name = "uni4_4"
        Me.uni4_4.Size = New System.Drawing.Size(29, 26)
        Me.uni4_4.TabIndex = 1
        Me.uni4_4.UseVisualStyleBackColor = False
        '
        'uni4_5
        '
        Me.uni4_5.BackColor = System.Drawing.Color.Gray
        Me.uni4_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_5.ForeColor = System.Drawing.Color.Black
        Me.uni4_5.Location = New System.Drawing.Point(143, 99)
        Me.uni4_5.Name = "uni4_5"
        Me.uni4_5.Size = New System.Drawing.Size(29, 26)
        Me.uni4_5.TabIndex = 1
        Me.uni4_5.UseVisualStyleBackColor = False
        '
        'uni4_6
        '
        Me.uni4_6.BackColor = System.Drawing.Color.Gray
        Me.uni4_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_6.ForeColor = System.Drawing.Color.Black
        Me.uni4_6.Location = New System.Drawing.Point(178, 99)
        Me.uni4_6.Name = "uni4_6"
        Me.uni4_6.Size = New System.Drawing.Size(29, 26)
        Me.uni4_6.TabIndex = 1
        Me.uni4_6.UseVisualStyleBackColor = False
        '
        'uni4_7
        '
        Me.uni4_7.BackColor = System.Drawing.Color.Gray
        Me.uni4_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_7.ForeColor = System.Drawing.Color.Black
        Me.uni4_7.Location = New System.Drawing.Point(213, 99)
        Me.uni4_7.Name = "uni4_7"
        Me.uni4_7.Size = New System.Drawing.Size(29, 26)
        Me.uni4_7.TabIndex = 1
        Me.uni4_7.UseVisualStyleBackColor = False
        '
        'uni4_8
        '
        Me.uni4_8.BackColor = System.Drawing.Color.Gray
        Me.uni4_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni4_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni4_8.ForeColor = System.Drawing.Color.Black
        Me.uni4_8.Location = New System.Drawing.Point(248, 99)
        Me.uni4_8.Name = "uni4_8"
        Me.uni4_8.Size = New System.Drawing.Size(29, 26)
        Me.uni4_8.TabIndex = 1
        Me.uni4_8.UseVisualStyleBackColor = False
        '
        'uni5_1
        '
        Me.uni5_1.BackColor = System.Drawing.Color.Gray
        Me.uni5_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_1.ForeColor = System.Drawing.Color.Black
        Me.uni5_1.Location = New System.Drawing.Point(3, 131)
        Me.uni5_1.Name = "uni5_1"
        Me.uni5_1.Size = New System.Drawing.Size(29, 26)
        Me.uni5_1.TabIndex = 1
        Me.uni5_1.UseVisualStyleBackColor = False
        '
        'uni5_2
        '
        Me.uni5_2.BackColor = System.Drawing.Color.Gray
        Me.uni5_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_2.ForeColor = System.Drawing.Color.Black
        Me.uni5_2.Location = New System.Drawing.Point(38, 131)
        Me.uni5_2.Name = "uni5_2"
        Me.uni5_2.Size = New System.Drawing.Size(29, 26)
        Me.uni5_2.TabIndex = 1
        Me.uni5_2.UseVisualStyleBackColor = False
        '
        'uni5_3
        '
        Me.uni5_3.BackColor = System.Drawing.Color.Gray
        Me.uni5_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_3.ForeColor = System.Drawing.Color.Black
        Me.uni5_3.Location = New System.Drawing.Point(73, 131)
        Me.uni5_3.Name = "uni5_3"
        Me.uni5_3.Size = New System.Drawing.Size(29, 26)
        Me.uni5_3.TabIndex = 1
        Me.uni5_3.UseVisualStyleBackColor = False
        '
        'uni5_4
        '
        Me.uni5_4.BackColor = System.Drawing.Color.Gray
        Me.uni5_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_4.ForeColor = System.Drawing.Color.Black
        Me.uni5_4.Location = New System.Drawing.Point(108, 131)
        Me.uni5_4.Name = "uni5_4"
        Me.uni5_4.Size = New System.Drawing.Size(29, 26)
        Me.uni5_4.TabIndex = 1
        Me.uni5_4.UseVisualStyleBackColor = False
        '
        'uni5_5
        '
        Me.uni5_5.BackColor = System.Drawing.Color.Gray
        Me.uni5_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_5.ForeColor = System.Drawing.Color.Black
        Me.uni5_5.Location = New System.Drawing.Point(143, 131)
        Me.uni5_5.Name = "uni5_5"
        Me.uni5_5.Size = New System.Drawing.Size(29, 26)
        Me.uni5_5.TabIndex = 1
        Me.uni5_5.UseVisualStyleBackColor = False
        '
        'uni5_6
        '
        Me.uni5_6.BackColor = System.Drawing.Color.Gray
        Me.uni5_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_6.ForeColor = System.Drawing.Color.Black
        Me.uni5_6.Location = New System.Drawing.Point(178, 131)
        Me.uni5_6.Name = "uni5_6"
        Me.uni5_6.Size = New System.Drawing.Size(29, 26)
        Me.uni5_6.TabIndex = 1
        Me.uni5_6.UseVisualStyleBackColor = False
        '
        'uni5_7
        '
        Me.uni5_7.BackColor = System.Drawing.Color.Gray
        Me.uni5_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_7.ForeColor = System.Drawing.Color.Black
        Me.uni5_7.Location = New System.Drawing.Point(213, 131)
        Me.uni5_7.Name = "uni5_7"
        Me.uni5_7.Size = New System.Drawing.Size(29, 26)
        Me.uni5_7.TabIndex = 1
        Me.uni5_7.UseVisualStyleBackColor = False
        '
        'uni5_8
        '
        Me.uni5_8.BackColor = System.Drawing.Color.Gray
        Me.uni5_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni5_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni5_8.ForeColor = System.Drawing.Color.Black
        Me.uni5_8.Location = New System.Drawing.Point(248, 131)
        Me.uni5_8.Name = "uni5_8"
        Me.uni5_8.Size = New System.Drawing.Size(29, 26)
        Me.uni5_8.TabIndex = 1
        Me.uni5_8.UseVisualStyleBackColor = False
        '
        'uni6_1
        '
        Me.uni6_1.BackColor = System.Drawing.Color.Gray
        Me.uni6_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_1.ForeColor = System.Drawing.Color.Black
        Me.uni6_1.Location = New System.Drawing.Point(3, 163)
        Me.uni6_1.Name = "uni6_1"
        Me.uni6_1.Size = New System.Drawing.Size(29, 26)
        Me.uni6_1.TabIndex = 1
        Me.uni6_1.UseVisualStyleBackColor = False
        '
        'uni6_2
        '
        Me.uni6_2.BackColor = System.Drawing.Color.Gray
        Me.uni6_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_2.ForeColor = System.Drawing.Color.Black
        Me.uni6_2.Location = New System.Drawing.Point(38, 163)
        Me.uni6_2.Name = "uni6_2"
        Me.uni6_2.Size = New System.Drawing.Size(29, 26)
        Me.uni6_2.TabIndex = 1
        Me.uni6_2.UseVisualStyleBackColor = False
        '
        'uni6_3
        '
        Me.uni6_3.BackColor = System.Drawing.Color.Gray
        Me.uni6_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_3.ForeColor = System.Drawing.Color.Black
        Me.uni6_3.Location = New System.Drawing.Point(73, 163)
        Me.uni6_3.Name = "uni6_3"
        Me.uni6_3.Size = New System.Drawing.Size(29, 26)
        Me.uni6_3.TabIndex = 1
        Me.uni6_3.UseVisualStyleBackColor = False
        '
        'uni6_4
        '
        Me.uni6_4.BackColor = System.Drawing.Color.Gray
        Me.uni6_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_4.ForeColor = System.Drawing.Color.Black
        Me.uni6_4.Location = New System.Drawing.Point(108, 163)
        Me.uni6_4.Name = "uni6_4"
        Me.uni6_4.Size = New System.Drawing.Size(29, 26)
        Me.uni6_4.TabIndex = 1
        Me.uni6_4.UseVisualStyleBackColor = False
        '
        'uni6_5
        '
        Me.uni6_5.BackColor = System.Drawing.Color.Gray
        Me.uni6_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_5.ForeColor = System.Drawing.Color.Black
        Me.uni6_5.Location = New System.Drawing.Point(143, 163)
        Me.uni6_5.Name = "uni6_5"
        Me.uni6_5.Size = New System.Drawing.Size(29, 26)
        Me.uni6_5.TabIndex = 1
        Me.uni6_5.UseVisualStyleBackColor = False
        '
        'uni6_6
        '
        Me.uni6_6.BackColor = System.Drawing.Color.Gray
        Me.uni6_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_6.ForeColor = System.Drawing.Color.Black
        Me.uni6_6.Location = New System.Drawing.Point(178, 163)
        Me.uni6_6.Name = "uni6_6"
        Me.uni6_6.Size = New System.Drawing.Size(29, 26)
        Me.uni6_6.TabIndex = 1
        Me.uni6_6.UseVisualStyleBackColor = False
        '
        'uni6_7
        '
        Me.uni6_7.BackColor = System.Drawing.Color.Gray
        Me.uni6_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_7.ForeColor = System.Drawing.Color.Black
        Me.uni6_7.Location = New System.Drawing.Point(213, 163)
        Me.uni6_7.Name = "uni6_7"
        Me.uni6_7.Size = New System.Drawing.Size(29, 26)
        Me.uni6_7.TabIndex = 1
        Me.uni6_7.UseVisualStyleBackColor = False
        '
        'uni6_8
        '
        Me.uni6_8.BackColor = System.Drawing.Color.Gray
        Me.uni6_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni6_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni6_8.ForeColor = System.Drawing.Color.Black
        Me.uni6_8.Location = New System.Drawing.Point(248, 163)
        Me.uni6_8.Name = "uni6_8"
        Me.uni6_8.Size = New System.Drawing.Size(29, 26)
        Me.uni6_8.TabIndex = 1
        Me.uni6_8.UseVisualStyleBackColor = False
        '
        'uni7_1
        '
        Me.uni7_1.BackColor = System.Drawing.Color.Gray
        Me.uni7_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_1.ForeColor = System.Drawing.Color.Black
        Me.uni7_1.Location = New System.Drawing.Point(3, 195)
        Me.uni7_1.Name = "uni7_1"
        Me.uni7_1.Size = New System.Drawing.Size(29, 26)
        Me.uni7_1.TabIndex = 1
        Me.uni7_1.UseVisualStyleBackColor = False
        '
        'uni7_2
        '
        Me.uni7_2.BackColor = System.Drawing.Color.Gray
        Me.uni7_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_2.ForeColor = System.Drawing.Color.Black
        Me.uni7_2.Location = New System.Drawing.Point(38, 195)
        Me.uni7_2.Name = "uni7_2"
        Me.uni7_2.Size = New System.Drawing.Size(29, 26)
        Me.uni7_2.TabIndex = 1
        Me.uni7_2.UseVisualStyleBackColor = False
        '
        'uni7_3
        '
        Me.uni7_3.BackColor = System.Drawing.Color.Gray
        Me.uni7_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_3.ForeColor = System.Drawing.Color.Black
        Me.uni7_3.Location = New System.Drawing.Point(73, 195)
        Me.uni7_3.Name = "uni7_3"
        Me.uni7_3.Size = New System.Drawing.Size(29, 26)
        Me.uni7_3.TabIndex = 1
        Me.uni7_3.UseVisualStyleBackColor = False
        '
        'uni7_4
        '
        Me.uni7_4.BackColor = System.Drawing.Color.Gray
        Me.uni7_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_4.ForeColor = System.Drawing.Color.Black
        Me.uni7_4.Location = New System.Drawing.Point(108, 195)
        Me.uni7_4.Name = "uni7_4"
        Me.uni7_4.Size = New System.Drawing.Size(29, 26)
        Me.uni7_4.TabIndex = 1
        Me.uni7_4.UseVisualStyleBackColor = False
        '
        'uni7_5
        '
        Me.uni7_5.BackColor = System.Drawing.Color.Gray
        Me.uni7_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_5.ForeColor = System.Drawing.Color.Black
        Me.uni7_5.Location = New System.Drawing.Point(143, 195)
        Me.uni7_5.Name = "uni7_5"
        Me.uni7_5.Size = New System.Drawing.Size(29, 26)
        Me.uni7_5.TabIndex = 1
        Me.uni7_5.UseVisualStyleBackColor = False
        '
        'uni7_6
        '
        Me.uni7_6.BackColor = System.Drawing.Color.Gray
        Me.uni7_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_6.ForeColor = System.Drawing.Color.Black
        Me.uni7_6.Location = New System.Drawing.Point(178, 195)
        Me.uni7_6.Name = "uni7_6"
        Me.uni7_6.Size = New System.Drawing.Size(29, 26)
        Me.uni7_6.TabIndex = 1
        Me.uni7_6.UseVisualStyleBackColor = False
        '
        'uni7_7
        '
        Me.uni7_7.BackColor = System.Drawing.Color.Gray
        Me.uni7_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_7.ForeColor = System.Drawing.Color.Black
        Me.uni7_7.Location = New System.Drawing.Point(213, 195)
        Me.uni7_7.Name = "uni7_7"
        Me.uni7_7.Size = New System.Drawing.Size(29, 26)
        Me.uni7_7.TabIndex = 1
        Me.uni7_7.UseVisualStyleBackColor = False
        '
        'uni7_8
        '
        Me.uni7_8.BackColor = System.Drawing.Color.Gray
        Me.uni7_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni7_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni7_8.ForeColor = System.Drawing.Color.Black
        Me.uni7_8.Location = New System.Drawing.Point(248, 195)
        Me.uni7_8.Name = "uni7_8"
        Me.uni7_8.Size = New System.Drawing.Size(29, 26)
        Me.uni7_8.TabIndex = 1
        Me.uni7_8.UseVisualStyleBackColor = False
        '
        'uni8_1
        '
        Me.uni8_1.BackColor = System.Drawing.Color.Gray
        Me.uni8_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_1.ForeColor = System.Drawing.Color.Black
        Me.uni8_1.Location = New System.Drawing.Point(3, 227)
        Me.uni8_1.Name = "uni8_1"
        Me.uni8_1.Size = New System.Drawing.Size(29, 28)
        Me.uni8_1.TabIndex = 1
        Me.uni8_1.UseVisualStyleBackColor = False
        '
        'uni8_2
        '
        Me.uni8_2.BackColor = System.Drawing.Color.Gray
        Me.uni8_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_2.ForeColor = System.Drawing.Color.Black
        Me.uni8_2.Location = New System.Drawing.Point(38, 227)
        Me.uni8_2.Name = "uni8_2"
        Me.uni8_2.Size = New System.Drawing.Size(29, 28)
        Me.uni8_2.TabIndex = 1
        Me.uni8_2.UseVisualStyleBackColor = False
        '
        'uni8_3
        '
        Me.uni8_3.BackColor = System.Drawing.Color.Gray
        Me.uni8_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_3.ForeColor = System.Drawing.Color.Black
        Me.uni8_3.Location = New System.Drawing.Point(73, 227)
        Me.uni8_3.Name = "uni8_3"
        Me.uni8_3.Size = New System.Drawing.Size(29, 28)
        Me.uni8_3.TabIndex = 1
        Me.uni8_3.UseVisualStyleBackColor = False
        '
        'uni8_4
        '
        Me.uni8_4.BackColor = System.Drawing.Color.Gray
        Me.uni8_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_4.ForeColor = System.Drawing.Color.Black
        Me.uni8_4.Location = New System.Drawing.Point(108, 227)
        Me.uni8_4.Name = "uni8_4"
        Me.uni8_4.Size = New System.Drawing.Size(29, 28)
        Me.uni8_4.TabIndex = 1
        Me.uni8_4.UseVisualStyleBackColor = False
        '
        'uni8_5
        '
        Me.uni8_5.BackColor = System.Drawing.Color.Gray
        Me.uni8_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_5.ForeColor = System.Drawing.Color.Black
        Me.uni8_5.Location = New System.Drawing.Point(143, 227)
        Me.uni8_5.Name = "uni8_5"
        Me.uni8_5.Size = New System.Drawing.Size(29, 28)
        Me.uni8_5.TabIndex = 1
        Me.uni8_5.UseVisualStyleBackColor = False
        '
        'uni8_6
        '
        Me.uni8_6.BackColor = System.Drawing.Color.Gray
        Me.uni8_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_6.ForeColor = System.Drawing.Color.Black
        Me.uni8_6.Location = New System.Drawing.Point(178, 227)
        Me.uni8_6.Name = "uni8_6"
        Me.uni8_6.Size = New System.Drawing.Size(29, 28)
        Me.uni8_6.TabIndex = 1
        Me.uni8_6.UseVisualStyleBackColor = False
        '
        'uni8_7
        '
        Me.uni8_7.BackColor = System.Drawing.Color.Gray
        Me.uni8_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_7.ForeColor = System.Drawing.Color.Black
        Me.uni8_7.Location = New System.Drawing.Point(213, 227)
        Me.uni8_7.Name = "uni8_7"
        Me.uni8_7.Size = New System.Drawing.Size(29, 28)
        Me.uni8_7.TabIndex = 1
        Me.uni8_7.UseVisualStyleBackColor = False
        '
        'uni8_8
        '
        Me.uni8_8.BackColor = System.Drawing.Color.Gray
        Me.uni8_8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uni8_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uni8_8.ForeColor = System.Drawing.Color.Black
        Me.uni8_8.Location = New System.Drawing.Point(248, 227)
        Me.uni8_8.Name = "uni8_8"
        Me.uni8_8.Size = New System.Drawing.Size(29, 28)
        Me.uni8_8.TabIndex = 1
        Me.uni8_8.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(479, 309)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 53)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "OK"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(577, 314)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(254, 22)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "*Tip:Click the button and check button code" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "with ease!"
        '
        'btnLEDtest
        '
        Me.btnLEDtest.Location = New System.Drawing.Point(580, 339)
        Me.btnLEDtest.Name = "btnLEDtest"
        Me.btnLEDtest.Size = New System.Drawing.Size(99, 23)
        Me.btnLEDtest.TabIndex = 12
        Me.btnLEDtest.Text = "Test LED"
        Me.btnLEDtest.UseVisualStyleBackColor = True
        '
        'listMultiMaps
        '
        Me.listMultiMaps.FormattingEnabled = True
        Me.listMultiMaps.ItemHeight = 12
        Me.listMultiMaps.Location = New System.Drawing.Point(12, 314)
        Me.listMultiMaps.Name = "listMultiMaps"
        Me.listMultiMaps.Size = New System.Drawing.Size(191, 52)
        Me.listMultiMaps.TabIndex = 13
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(209, 314)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(63, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add (1)"
        Me.ToolTIP.SetToolTip(Me.btnAdd, "Normal LED. like 1 4 5 1 or 1 4 6 1. You should turn off code for yourself.")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(387, 345)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(63, 23)
        Me.btnRemove.TabIndex = 14
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 7.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(787, 352)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "What the hell" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is this Text Editor?"
        Me.ToolTIP.SetToolTip(Me.Label7, "We're Developing Dot based LED Editor. (Like Pixel Art!)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "We know that this ""Text" & _
        " Editor"" is really trash! But Please wait..")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(278, 318)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 24)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "*Tip:It automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "saves changes!"
        '
        'lblTimePassed
        '
        Me.lblTimePassed.AutoSize = True
        Me.lblTimePassed.Location = New System.Drawing.Point(682, 344)
        Me.lblTimePassed.Name = "lblTimePassed"
        Me.lblTimePassed.Size = New System.Drawing.Size(67, 12)
        Me.lblTimePassed.TabIndex = 16
        Me.lblTimePassed.Text = "Test Time:"
        '
        'pbLNum
        '
        Me.pbLNum.Location = New System.Drawing.Point(6, 12)
        Me.pbLNum.Name = "pbLNum"
        Me.pbLNum.Size = New System.Drawing.Size(36, 295)
        Me.pbLNum.TabIndex = 17
        Me.pbLNum.TabStop = False
        Me.pbLNum.Visible = False
        '
        'cbLaunchPadColor
        '
        Me.cbLaunchPadColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbLaunchPadColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLaunchPadColor.FormattingEnabled = True
        Me.cbLaunchPadColor.Location = New System.Drawing.Point(8, 137)
        Me.cbLaunchPadColor.Name = "cbLaunchPadColor"
        Me.cbLaunchPadColor.Size = New System.Drawing.Size(122, 22)
        Me.cbLaunchPadColor.TabIndex = 16
        Me.cbLaunchPadColor.Visible = False
        '
        'frmLED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 378)
        Me.Controls.Add(Me.pbLNum)
        Me.Controls.Add(Me.lblTimePassed)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.listMultiMaps)
        Me.Controls.Add(Me.btnLEDtest)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tabHelper)
        Me.Controls.Add(Me.rtbLED)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLED"
        Me.Text = "LED Editor"
        Me.tabHelper.ResumeLayout(False)
        Me.tabOn.ResumeLayout(False)
        Me.tabOn.PerformLayout()
        CType(Me.btnColorTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOff.ResumeLayout(False)
        Me.tabOff.PerformLayout()
        Me.tabWait.ResumeLayout(False)
        Me.tabWait.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.pbLNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbLED As System.Windows.Forms.RichTextBox
    Friend WithEvents tipHelper As System.Windows.Forms.ToolTip
    Friend WithEvents txtOn_X As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents tabHelper As System.Windows.Forms.TabControl
    Friend WithEvents tabOn As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOn_Y As System.Windows.Forms.TextBox
    Friend WithEvents tabOff As System.Windows.Forms.TabPage
    Friend WithEvents tabWait As System.Windows.Forms.TabPage
    Friend WithEvents txtColorMsg As System.Windows.Forms.Label
    Friend WithEvents checkUseLaunchColor As System.Windows.Forms.CheckBox
    Friend WithEvents textColor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPickColor As System.Windows.Forms.Button
    Friend WithEvents colorPick As System.Windows.Forms.ColorDialog
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents uni1_1 As System.Windows.Forms.Button
    Friend WithEvents uni1_2 As System.Windows.Forms.Button
    Friend WithEvents uni1_3 As System.Windows.Forms.Button
    Friend WithEvents uni1_4 As System.Windows.Forms.Button
    Friend WithEvents uni1_5 As System.Windows.Forms.Button
    Friend WithEvents uni1_6 As System.Windows.Forms.Button
    Friend WithEvents uni1_7 As System.Windows.Forms.Button
    Friend WithEvents uni1_8 As System.Windows.Forms.Button
    Friend WithEvents uni2_1 As System.Windows.Forms.Button
    Friend WithEvents uni2_2 As System.Windows.Forms.Button
    Friend WithEvents uni2_3 As System.Windows.Forms.Button
    Friend WithEvents uni2_4 As System.Windows.Forms.Button
    Friend WithEvents uni2_5 As System.Windows.Forms.Button
    Friend WithEvents uni2_6 As System.Windows.Forms.Button
    Friend WithEvents uni2_7 As System.Windows.Forms.Button
    Friend WithEvents uni2_8 As System.Windows.Forms.Button
    Friend WithEvents uni3_1 As System.Windows.Forms.Button
    Friend WithEvents uni3_2 As System.Windows.Forms.Button
    Friend WithEvents uni3_3 As System.Windows.Forms.Button
    Friend WithEvents uni3_4 As System.Windows.Forms.Button
    Friend WithEvents uni3_5 As System.Windows.Forms.Button
    Friend WithEvents uni3_6 As System.Windows.Forms.Button
    Friend WithEvents uni3_7 As System.Windows.Forms.Button
    Friend WithEvents uni3_8 As System.Windows.Forms.Button
    Friend WithEvents uni4_1 As System.Windows.Forms.Button
    Friend WithEvents uni4_2 As System.Windows.Forms.Button
    Friend WithEvents uni4_3 As System.Windows.Forms.Button
    Friend WithEvents uni4_4 As System.Windows.Forms.Button
    Friend WithEvents uni4_5 As System.Windows.Forms.Button
    Friend WithEvents uni4_6 As System.Windows.Forms.Button
    Friend WithEvents uni4_7 As System.Windows.Forms.Button
    Friend WithEvents uni4_8 As System.Windows.Forms.Button
    Friend WithEvents uni5_1 As System.Windows.Forms.Button
    Friend WithEvents uni5_2 As System.Windows.Forms.Button
    Friend WithEvents uni5_3 As System.Windows.Forms.Button
    Friend WithEvents uni5_4 As System.Windows.Forms.Button
    Friend WithEvents uni5_5 As System.Windows.Forms.Button
    Friend WithEvents uni5_6 As System.Windows.Forms.Button
    Friend WithEvents uni5_7 As System.Windows.Forms.Button
    Friend WithEvents uni5_8 As System.Windows.Forms.Button
    Friend WithEvents uni6_1 As System.Windows.Forms.Button
    Friend WithEvents uni6_2 As System.Windows.Forms.Button
    Friend WithEvents uni6_3 As System.Windows.Forms.Button
    Friend WithEvents uni6_4 As System.Windows.Forms.Button
    Friend WithEvents uni6_5 As System.Windows.Forms.Button
    Friend WithEvents uni6_6 As System.Windows.Forms.Button
    Friend WithEvents uni6_7 As System.Windows.Forms.Button
    Friend WithEvents uni6_8 As System.Windows.Forms.Button
    Friend WithEvents uni7_1 As System.Windows.Forms.Button
    Friend WithEvents uni7_2 As System.Windows.Forms.Button
    Friend WithEvents uni7_3 As System.Windows.Forms.Button
    Friend WithEvents uni7_4 As System.Windows.Forms.Button
    Friend WithEvents uni7_5 As System.Windows.Forms.Button
    Friend WithEvents uni7_6 As System.Windows.Forms.Button
    Friend WithEvents uni7_7 As System.Windows.Forms.Button
    Friend WithEvents uni7_8 As System.Windows.Forms.Button
    Friend WithEvents uni8_1 As System.Windows.Forms.Button
    Friend WithEvents uni8_2 As System.Windows.Forms.Button
    Friend WithEvents uni8_3 As System.Windows.Forms.Button
    Friend WithEvents uni8_4 As System.Windows.Forms.Button
    Friend WithEvents uni8_5 As System.Windows.Forms.Button
    Friend WithEvents uni8_6 As System.Windows.Forms.Button
    Friend WithEvents uni8_7 As System.Windows.Forms.Button
    Friend WithEvents uni8_8 As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLEDtest As System.Windows.Forms.Button
    Friend WithEvents listMultiMaps As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbTurnOffY As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbTurnOffX As System.Windows.Forms.TextBox
    Friend WithEvents labelJust As System.Windows.Forms.Label
    Friend WithEvents tbWaitMSec As System.Windows.Forms.TextBox
    Friend WithEvents btnAddTurnOn As System.Windows.Forms.Button
    Friend WithEvents btnColorTest As System.Windows.Forms.PictureBox
    Friend WithEvents btnAddTurnOff As System.Windows.Forms.Button
    Friend WithEvents btnAddWait As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolTIP As System.Windows.Forms.ToolTip
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbLaunchPadColor As UniPackGUI.ColorComboBox
    Friend WithEvents lblTimePassed As System.Windows.Forms.Label
    Friend WithEvents pbLNum As System.Windows.Forms.PictureBox
End Class
