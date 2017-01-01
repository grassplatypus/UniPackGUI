<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NoticesNAd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NoticesNAd))
        Me.webAd = New System.Windows.Forms.WebBrowser()
        Me.webInfo = New System.Windows.Forms.WebBrowser()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'webAd
        '
        Me.webAd.Location = New System.Drawing.Point(0, 1)
        Me.webAd.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAd.Name = "webAd"
        Me.webAd.Size = New System.Drawing.Size(395, 169)
        Me.webAd.TabIndex = 0
        Me.webAd.Url = New System.Uri("http://unitor.esy.es/UnitorConfig/info.html", System.UriKind.Absolute)
        '
        'webInfo
        '
        Me.webInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webInfo.Location = New System.Drawing.Point(0, 194)
        Me.webInfo.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webInfo.Name = "webInfo"
        Me.webInfo.Size = New System.Drawing.Size(395, 87)
        Me.webInfo.TabIndex = 1
        Me.webInfo.Url = New System.Uri("http://unitor.esy.es/UnitorConfig/GoogleAds.html", System.UriKind.Absolute)
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(269, 287)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 34)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(177, 287)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 34)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NoticesNAd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 329)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.webInfo)
        Me.Controls.Add(Me.webAd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NoticesNAd"
        Me.ShowInTaskbar = False
        Me.Text = "Unitor Information"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents webAd As System.Windows.Forms.WebBrowser
    Friend WithEvents webInfo As System.Windows.Forms.WebBrowser
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
