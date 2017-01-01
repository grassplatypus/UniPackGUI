<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoPlayControler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoPlayControler))
        Me.pgSong = New System.Windows.Forms.ProgressBar()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnWaitGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pgSong
        '
        Me.pgSong.Location = New System.Drawing.Point(12, 12)
        Me.pgSong.Name = "pgSong"
        Me.pgSong.Size = New System.Drawing.Size(260, 29)
        Me.pgSong.TabIndex = 0
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("맑은 고딕", 17.0!)
        Me.btnStop.Location = New System.Drawing.Point(52, 56)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 52)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnWaitGo
        '
        Me.btnWaitGo.Font = New System.Drawing.Font("맑은 고딕", 14.0!)
        Me.btnWaitGo.Location = New System.Drawing.Point(133, 56)
        Me.btnWaitGo.Name = "btnWaitGo"
        Me.btnWaitGo.Size = New System.Drawing.Size(75, 52)
        Me.btnWaitGo.TabIndex = 3
        Me.btnWaitGo.Text = "Pause"
        Me.btnWaitGo.UseVisualStyleBackColor = True
        '
        'AutoPlayControler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnWaitGo)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.pgSong)
        Me.Enabled = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoPlayControler"
        Me.Text = "Auto Play Controler"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgSong As System.Windows.Forms.ProgressBar
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnWaitGo As System.Windows.Forms.Button
End Class
