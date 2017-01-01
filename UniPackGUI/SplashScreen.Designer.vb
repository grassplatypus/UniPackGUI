<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblHomepageGo = New System.Windows.Forms.LinkLabel()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(207, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Thanks to K1A2 for icon."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 60.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(221, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 106)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unitor"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("맑은 고딕", 12.0!)
        Me.lblVersion.Location = New System.Drawing.Point(246, 141)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(117, 21)
        Me.lblVersion.TabIndex = 3
        Me.lblVersion.Text = "Unitor Version"
        '
        'lblHomepageGo
        '
        Me.lblHomepageGo.AutoSize = True
        Me.lblHomepageGo.BackColor = System.Drawing.Color.Transparent
        Me.lblHomepageGo.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.lblHomepageGo.Location = New System.Drawing.Point(207, 9)
        Me.lblHomepageGo.Name = "lblHomepageGo"
        Me.lblHomepageGo.Size = New System.Drawing.Size(138, 15)
        Me.lblHomepageGo.TabIndex = 4
        Me.lblHomepageGo.TabStop = True
        Me.lblHomepageGo.Text = "http://www.unitor.esy.es"
        '
        'pbImage
        '
        Me.pbImage.Image = Global.UniPackGUI.My.Resources.Resources.logounitor
        Me.pbImage.Location = New System.Drawing.Point(1, 1)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(200, 200)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImage.TabIndex = 0
        Me.pbImage.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(367, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "UniPad Team Official Project"
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.UniPackGUI.My.Resources.Resources.unitorBlur
        Me.ClientSize = New System.Drawing.Size(535, 200)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblHomepageGo)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.Text = "Unitor, First UniPack IDE"
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblHomepageGo As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
