<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SoundCutter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SoundCutter))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTargetDir = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelectSource = New System.Windows.Forms.Button()
        Me.ofdFile = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fbdFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnSelectdir = New System.Windows.Forms.Button()
        Me.lblstat = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSoundLength = New System.Windows.Forms.Label()
        Me.SoundCutControl = New System.Windows.Forms.DataGridView()
        Me.colStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colisAuto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTest = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.doubleTrack = New UniPackGUI.DoubleTrackBar()
        Me.DoubleTrackBar1 = New UniPackGUI.DoubleTrackBar()
        CType(Me.SoundCutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(291, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 56)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cut!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(87, 86)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(246, 21)
        Me.txtSource.TabIndex = 4
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 162)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(354, 248)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = "[Start of Sound (format ex: 0:0:0.0)] [Start of Sound (format ex: 0:0:1.1000) OR " & _
    "(second)s] [file name OR auto (if you select auto, soundname will be saved to tr" & _
    "_(LINENUMBER).wav)]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 413)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(331, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "*Tip: sound extension will be automatically added (.wav)"
        '
        'txtTargetDir
        '
        Me.txtTargetDir.Location = New System.Drawing.Point(87, 113)
        Me.txtTargetDir.Name = "txtTargetDir"
        Me.txtTargetDir.Size = New System.Drawing.Size(246, 21)
        Me.txtTargetDir.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(271, 23)
        Me.ProgressBar1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Source File"
        '
        'btnSelectSource
        '
        Me.btnSelectSource.Location = New System.Drawing.Point(339, 84)
        Me.btnSelectSource.Name = "btnSelectSource"
        Me.btnSelectSource.Size = New System.Drawing.Size(27, 23)
        Me.btnSelectSource.TabIndex = 9
        Me.btnSelectSource.Text = "..."
        Me.btnSelectSource.UseVisualStyleBackColor = True
        '
        'ofdFile
        '
        Me.ofdFile.Filter = "Mp3 File|*.mp3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Target Dir"
        '
        'btnSelectdir
        '
        Me.btnSelectdir.Location = New System.Drawing.Point(339, 113)
        Me.btnSelectdir.Name = "btnSelectdir"
        Me.btnSelectdir.Size = New System.Drawing.Size(27, 23)
        Me.btnSelectdir.TabIndex = 10
        Me.btnSelectdir.Text = "..."
        Me.btnSelectdir.UseVisualStyleBackColor = True
        '
        'lblstat
        '
        Me.lblstat.AutoSize = True
        Me.lblstat.Location = New System.Drawing.Point(12, 56)
        Me.lblstat.Name = "lblstat"
        Me.lblstat.Size = New System.Drawing.Size(41, 12)
        Me.lblstat.TabIndex = 11
        Me.lblstat.Text = "Ready"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Script"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 427)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(235, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "*Tip: Do not add ""space"" in file name! "" """
        '
        'lblSoundLength
        '
        Me.lblSoundLength.AutoSize = True
        Me.lblSoundLength.Location = New System.Drawing.Point(166, 147)
        Me.lblSoundLength.Name = "lblSoundLength"
        Me.lblSoundLength.Size = New System.Drawing.Size(47, 12)
        Me.lblSoundLength.TabIndex = 12
        Me.lblSoundLength.Text = "Length:"
        '
        'SoundCutControl
        '
        Me.SoundCutControl.AllowUserToAddRows = False
        Me.SoundCutControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SoundCutControl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStart, Me.colEnd, Me.colFileName, Me.colisAuto, Me.colTest})
        Me.SoundCutControl.Location = New System.Drawing.Point(14, 162)
        Me.SoundCutControl.Name = "SoundCutControl"
        Me.SoundCutControl.RowTemplate.Height = 23
        Me.SoundCutControl.Size = New System.Drawing.Size(499, 248)
        Me.SoundCutControl.TabIndex = 15
        '
        'colStart
        '
        Me.colStart.HeaderText = "Start Pos"
        Me.colStart.MaxInputLength = 17
        Me.colStart.Name = "colStart"
        Me.colStart.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colEnd
        '
        Me.colEnd.HeaderText = "End Pos (or Length)"
        Me.colEnd.MaxInputLength = 17
        Me.colEnd.Name = "colEnd"
        '
        'colFileName
        '
        Me.colFileName.HeaderText = "FileName"
        Me.colFileName.MaxInputLength = 4000
        Me.colFileName.Name = "colFileName"
        '
        'colisAuto
        '
        Me.colisAuto.HeaderText = "Auto Naming"
        Me.colisAuto.Name = "colisAuto"
        '
        'colTest
        '
        Me.colTest.HeaderText = "Test"
        Me.colTest.Name = "colTest"
        Me.colTest.Width = 50
        '
        'btnAddRow
        '
        Me.btnAddRow.Location = New System.Drawing.Point(519, 188)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(75, 23)
        Me.btnAddRow.TabIndex = 16
        Me.btnAddRow.Text = "Add Row"
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'doubleTrack
        '
        Me.doubleTrack.Location = New System.Drawing.Point(415, 12)
        Me.doubleTrack.Maximum = 20
        Me.doubleTrack.Minimum = 0
        Me.doubleTrack.Name = "doubleTrack"
        Me.doubleTrack.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.doubleTrack.Size = New System.Drawing.Size(150, 150)
        Me.doubleTrack.SmallChange = 1
        Me.doubleTrack.TabIndex = 14
        Me.doubleTrack.ValueLeft = 5
        Me.doubleTrack.ValueRight = 9
        '
        'DoubleTrackBar1
        '
        Me.DoubleTrackBar1.Location = New System.Drawing.Point(375, 427)
        Me.DoubleTrackBar1.Maximum = 10
        Me.DoubleTrackBar1.Minimum = 0
        Me.DoubleTrackBar1.Name = "DoubleTrackBar1"
        Me.DoubleTrackBar1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.DoubleTrackBar1.Size = New System.Drawing.Size(296, 25)
        Me.DoubleTrackBar1.SmallChange = 1
        Me.DoubleTrackBar1.TabIndex = 17
        Me.DoubleTrackBar1.ValueLeft = 3
        Me.DoubleTrackBar1.ValueRight = 6
        '
        'SoundCutter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 625)
        Me.Controls.Add(Me.DoubleTrackBar1)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.SoundCutControl)
        Me.Controls.Add(Me.lblSoundLength)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblstat)
        Me.Controls.Add(Me.btnSelectdir)
        Me.Controls.Add(Me.btnSelectSource)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.txtTargetDir)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SoundCutter"
        Me.ShowInTaskbar = False
        Me.Text = "Sound Cutter (Scripting)"
        CType(Me.SoundCutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTargetDir As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelectSource As System.Windows.Forms.Button
    Friend WithEvents ofdFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fbdFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnSelectdir As System.Windows.Forms.Button
    Friend WithEvents lblstat As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSoundLength As System.Windows.Forms.Label
    Friend WithEvents doubleTrack As UniPackGUI.DoubleTrackBar
    Friend WithEvents SoundCutControl As System.Windows.Forms.DataGridView
    Friend WithEvents colStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colisAuto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTest As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents DoubleTrackBar1 As UniPackGUI.DoubleTrackBar
End Class
