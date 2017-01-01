<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setting))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabHome = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabPlay = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabLoad = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabGen = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbHelp = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.tabHome.SuspendLayout()
        Me.tabPlay.SuspendLayout()
        Me.tabLoad.SuspendLayout()
        Me.tabGen.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabHome)
        Me.TabControl1.Controls.Add(Me.tabPlay)
        Me.TabControl1.Controls.Add(Me.tabLoad)
        Me.TabControl1.Controls.Add(Me.tabGen)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(453, 358)
        Me.TabControl1.TabIndex = 0
        '
        'tabHome
        '
        Me.tabHome.Controls.Add(Me.Label3)
        Me.tabHome.Controls.Add(Me.Label1)
        Me.tabHome.Location = New System.Drawing.Point(4, 22)
        Me.tabHome.Name = "tabHome"
        Me.tabHome.Padding = New System.Windows.Forms.Padding(3)
        Me.tabHome.Size = New System.Drawing.Size(445, 332)
        Me.tabHome.TabIndex = 0
        Me.tabHome.Text = "Main"
        Me.tabHome.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Unitor, UniPack IDE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 20.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "The Best UniPack IDE"
        '
        'tabPlay
        '
        Me.tabPlay.Controls.Add(Me.Label5)
        Me.tabPlay.Location = New System.Drawing.Point(4, 22)
        Me.tabPlay.Name = "tabPlay"
        Me.tabPlay.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPlay.Size = New System.Drawing.Size(445, 332)
        Me.tabPlay.TabIndex = 1
        Me.tabPlay.Text = "Player Setting"
        Me.tabPlay.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Not Available Yet..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please request your feature!"
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
        'tabGen
        '
        Me.tabGen.Controls.Add(Me.Label2)
        Me.tabGen.Location = New System.Drawing.Point(4, 22)
        Me.tabGen.Name = "tabGen"
        Me.tabGen.Size = New System.Drawing.Size(445, 332)
        Me.tabGen.TabIndex = 3
        Me.tabGen.Text = "General Setting"
        Me.tabGen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Not Available Yet..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please request your feature!"
        '
        'rtbHelp
        '
        Me.rtbHelp.Location = New System.Drawing.Point(459, 22)
        Me.rtbHelp.Name = "rtbHelp"
        Me.rtbHelp.ReadOnly = True
        Me.rtbHelp.Size = New System.Drawing.Size(180, 332)
        Me.rtbHelp.TabIndex = 1
        Me.rtbHelp.Text = "We don't have any settings, yet." & Global.Microsoft.VisualBasic.ChrW(10) & "Please request features!"
        '
        'setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 360)
        Me.Controls.Add(Me.rtbHelp)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "setting"
        Me.Text = "Unitor Setting"
        Me.TabControl1.ResumeLayout(False)
        Me.tabHome.ResumeLayout(False)
        Me.tabHome.PerformLayout()
        Me.tabPlay.ResumeLayout(False)
        Me.tabPlay.PerformLayout()
        Me.tabLoad.ResumeLayout(False)
        Me.tabLoad.PerformLayout()
        Me.tabGen.ResumeLayout(False)
        Me.tabGen.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabHome As System.Windows.Forms.TabPage
    Friend WithEvents tabPlay As System.Windows.Forms.TabPage
    Friend WithEvents tabLoad As System.Windows.Forms.TabPage
    Friend WithEvents tabGen As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rtbHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
