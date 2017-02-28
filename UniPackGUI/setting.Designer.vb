<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setting_unitor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setting_unitor))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPlay = New System.Windows.Forms.TabPage()
        Me.cbStrictLength = New System.Windows.Forms.CheckBox()
        Me.cb0LoopSound = New System.Windows.Forms.CheckBox()
        Me.cb0LoopLED = New System.Windows.Forms.CheckBox()
        Me.tabGen = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbRetrieveURL = New System.Windows.Forms.CheckBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.tabLoad = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rtbHelp = New System.Windows.Forms.RichTextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabPlay.SuspendLayout()
        Me.tabGen.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabLoad.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabPlay)
        Me.TabControl1.Controls.Add(Me.tabGen)
        Me.TabControl1.Controls.Add(Me.tabLoad)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(453, 358)
        Me.TabControl1.TabIndex = 0
        '
        'tabPlay
        '
        Me.tabPlay.Controls.Add(Me.cbStrictLength)
        Me.tabPlay.Controls.Add(Me.cb0LoopSound)
        Me.tabPlay.Controls.Add(Me.cb0LoopLED)
        Me.tabPlay.Location = New System.Drawing.Point(4, 22)
        Me.tabPlay.Name = "tabPlay"
        Me.tabPlay.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPlay.Size = New System.Drawing.Size(445, 332)
        Me.tabPlay.TabIndex = 1
        Me.tabPlay.Text = "Player Setting"
        Me.tabPlay.UseVisualStyleBackColor = True
        '
        'cbStrictLength
        '
        Me.cbStrictLength.AutoSize = True
        Me.cbStrictLength.Location = New System.Drawing.Point(23, 104)
        Me.cbStrictLength.Name = "cbStrictLength"
        Me.cbStrictLength.Size = New System.Drawing.Size(185, 16)
        Me.cbStrictLength.TabIndex = 1
        Me.cbStrictLength.Text = "Strict policy for sound length"
        Me.cbStrictLength.UseVisualStyleBackColor = True
        '
        'cb0LoopSound
        '
        Me.cb0LoopSound.AutoSize = True
        Me.cb0LoopSound.Location = New System.Drawing.Point(23, 73)
        Me.cb0LoopSound.Name = "cb0LoopSound"
        Me.cb0LoopSound.Size = New System.Drawing.Size(234, 16)
        Me.cb0LoopSound.TabIndex = 1
        Me.cb0LoopSound.Text = "Full Support for 0 loop number Sound"
        Me.cb0LoopSound.UseVisualStyleBackColor = True
        '
        'cb0LoopLED
        '
        Me.cb0LoopLED.AutoSize = True
        Me.cb0LoopLED.Location = New System.Drawing.Point(23, 40)
        Me.cb0LoopLED.Name = "cb0LoopLED"
        Me.cb0LoopLED.Size = New System.Drawing.Size(221, 16)
        Me.cb0LoopLED.TabIndex = 1
        Me.cb0LoopLED.Text = "Full Support for 0 loop number LED"
        Me.cb0LoopLED.UseVisualStyleBackColor = True
        '
        'tabGen
        '
        Me.tabGen.Controls.Add(Me.Label1)
        Me.tabGen.Controls.Add(Me.GroupBox1)
        Me.tabGen.Location = New System.Drawing.Point(4, 22)
        Me.tabGen.Name = "tabGen"
        Me.tabGen.Size = New System.Drawing.Size(445, 332)
        Me.tabGen.TabIndex = 3
        Me.tabGen.Text = "General Setting"
        Me.tabGen.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbRetrieveURL)
        Me.GroupBox1.Controls.Add(Me.txtURL)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 138)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "UniPackWW UniPack Uploader"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(368, 24)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Unitor will try to send POST request to specified URL. Check the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Custom UniPackW" & _
    "W Server document from Unitor Homepage"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "URL:"
        '
        'cbRetrieveURL
        '
        Me.cbRetrieveURL.AutoSize = True
        Me.cbRetrieveURL.Checked = True
        Me.cbRetrieveURL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRetrieveURL.Location = New System.Drawing.Point(19, 20)
        Me.cbRetrieveURL.Name = "cbRetrieveURL"
        Me.cbRetrieveURL.Size = New System.Drawing.Size(323, 16)
        Me.cbRetrieveURL.TabIndex = 0
        Me.cbRetrieveURL.Text = "Get URL from Unitor Server (Use Official UniPackWW)"
        Me.cbRetrieveURL.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Enabled = False
        Me.txtURL.Location = New System.Drawing.Point(55, 42)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(330, 21)
        Me.txtURL.TabIndex = 0
        Me.txtURL.Text = "http://example.com/unipackww/"
        '
        'tabLoad
        '
        Me.tabLoad.Controls.Add(Me.Label4)
        Me.tabLoad.Location = New System.Drawing.Point(4, 22)
        Me.tabLoad.Name = "tabLoad"
        Me.tabLoad.Size = New System.Drawing.Size(445, 332)
        Me.tabLoad.TabIndex = 2
        Me.tabLoad.Text = "UniPack Loader Setting"
        Me.tabLoad.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Not Available Yet..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please request your feature!"
        '
        'rtbHelp
        '
        Me.rtbHelp.Location = New System.Drawing.Point(459, 22)
        Me.rtbHelp.Name = "rtbHelp"
        Me.rtbHelp.ReadOnly = True
        Me.rtbHelp.Size = New System.Drawing.Size(180, 294)
        Me.rtbHelp.TabIndex = 1
        Me.rtbHelp.Text = "Unitor, the best UniPack IDE"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(459, 325)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 29)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(549, 325)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 29)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(358, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "*Tip: This function may will be removed when Official UniPad " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UnOfficial-UniPack" & _
    " Sharing Website completed."
        '
        'setting_unitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 360)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.rtbHelp)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "setting_unitor"
        Me.Text = "Unitor Setting"
        Me.TabControl1.ResumeLayout(False)
        Me.tabPlay.ResumeLayout(False)
        Me.tabPlay.PerformLayout()
        Me.tabGen.ResumeLayout(False)
        Me.tabGen.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabLoad.ResumeLayout(False)
        Me.tabLoad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabPlay As System.Windows.Forms.TabPage
    Friend WithEvents tabLoad As System.Windows.Forms.TabPage
    Friend WithEvents tabGen As System.Windows.Forms.TabPage
    Friend WithEvents rtbHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb0LoopLED As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbRetrieveURL As System.Windows.Forms.CheckBox
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbStrictLength As System.Windows.Forms.CheckBox
    Friend WithEvents cb0LoopSound As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
