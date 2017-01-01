<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wavConvert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(wavConvert))
        Me.btnSounds = New System.Windows.Forms.ListBox()
        Me.btnGoConvert = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textDir = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnLoadDir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblStat = New System.Windows.Forms.Label()
        Me.pbBar = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'btnSounds
        '
        Me.btnSounds.FormattingEnabled = True
        Me.btnSounds.ItemHeight = 12
        Me.btnSounds.Location = New System.Drawing.Point(16, 84)
        Me.btnSounds.Name = "btnSounds"
        Me.btnSounds.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.btnSounds.Size = New System.Drawing.Size(276, 196)
        Me.btnSounds.TabIndex = 0
        '
        'btnGoConvert
        '
        Me.btnGoConvert.Location = New System.Drawing.Point(16, 286)
        Me.btnGoConvert.Name = "btnGoConvert"
        Me.btnGoConvert.Size = New System.Drawing.Size(98, 50)
        Me.btnGoConvert.TabIndex = 1
        Me.btnGoConvert.Text = "Convert!"
        Me.btnGoConvert.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 36)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "You can convert MP3 Files to Wav File! Thanks to NAudio!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(naudio.codeplex.com)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
    "*Tip: All .wav files in folder are will be changed!"
        '
        'textDir
        '
        Me.textDir.Location = New System.Drawing.Point(14, 57)
        Me.textDir.Name = "textDir"
        Me.textDir.Size = New System.Drawing.Size(278, 21)
        Me.textDir.TabIndex = 3
        '
        'btnLoadDir
        '
        Me.btnLoadDir.Location = New System.Drawing.Point(298, 57)
        Me.btnLoadDir.Name = "btnLoadDir"
        Me.btnLoadDir.Size = New System.Drawing.Size(42, 23)
        Me.btnLoadDir.TabIndex = 4
        Me.btnLoadDir.Text = "..."
        Me.btnLoadDir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "*Tip:If a file is already Wav file," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "it will be ignored!"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(298, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 28)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Load!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblStat
        '
        Me.lblStat.AutoSize = True
        Me.lblStat.Location = New System.Drawing.Point(120, 324)
        Me.lblStat.Name = "lblStat"
        Me.lblStat.Size = New System.Drawing.Size(41, 12)
        Me.lblStat.TabIndex = 7
        Me.lblStat.Text = "Ready"
        '
        'pbBar
        '
        Me.pbBar.Location = New System.Drawing.Point(14, 57)
        Me.pbBar.Name = "pbBar"
        Me.pbBar.Size = New System.Drawing.Size(278, 23)
        Me.pbBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbBar.TabIndex = 8
        '
        'wavConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 344)
        Me.Controls.Add(Me.pbBar)
        Me.Controls.Add(Me.lblStat)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLoadDir)
        Me.Controls.Add(Me.textDir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGoConvert)
        Me.Controls.Add(Me.btnSounds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "wavConvert"
        Me.Text = "Mp32Wav Converter (NAudio)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSounds As System.Windows.Forms.ListBox
    Friend WithEvents btnGoConvert As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textDir As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnLoadDir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblStat As System.Windows.Forms.Label
    Friend WithEvents pbBar As System.Windows.Forms.ProgressBar
End Class
