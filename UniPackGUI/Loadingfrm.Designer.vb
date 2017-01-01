<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loadingfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loadingfrm))
        Me.LoadingPg = New System.Windows.Forms.ProgressBar()
        Me.workPgLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LoadingPg
        '
        Me.LoadingPg.Location = New System.Drawing.Point(14, 43)
        Me.LoadingPg.MarqueeAnimationSpeed = 20
        Me.LoadingPg.Name = "LoadingPg"
        Me.LoadingPg.Size = New System.Drawing.Size(345, 23)
        Me.LoadingPg.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.LoadingPg.TabIndex = 0
        '
        'workPgLabel
        '
        Me.workPgLabel.AutoSize = True
        Me.workPgLabel.Location = New System.Drawing.Point(19, 80)
        Me.workPgLabel.Name = "workPgLabel"
        Me.workPgLabel.Size = New System.Drawing.Size(135, 12)
        Me.workPgLabel.TabIndex = 1
        Me.workPgLabel.Text = "Working... Please wait!"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(357, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Unitor, the best UniPack IDE. (Official Project of UniPad Team)"
        '
        'Loadingfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 116)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.workPgLabel)
        Me.Controls.Add(Me.LoadingPg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Loadingfrm"
        Me.ShowIcon = False
        Me.Text = "Loading... Please wait!"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LoadingPg As System.Windows.Forms.ProgressBar
    Friend WithEvents workPgLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
