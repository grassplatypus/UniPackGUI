<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class unipackww
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(unipackww))
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txttitle = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDir = New System.Windows.Forms.Label()
        Me.notifyUpload = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.pbUpload = New System.Windows.Forms.ProgressBar()
        Me.txtLink = New System.Windows.Forms.TextBox()
        Me.tipDirInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(239, 294)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(90, 52)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "Upload"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txttitle
        '
        Me.txttitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttitle.Location = New System.Drawing.Point(107, 44)
        Me.txttitle.Name = "txttitle"
        Me.txttitle.Size = New System.Drawing.Size(212, 21)
        Me.txttitle.TabIndex = 1
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(107, 71)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(222, 216)
        Me.txtDescription.TabIndex = 2
        Me.txtDescription.Text = ""
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "UniPack Path: "
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Description:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Title:"
        '
        'lblDir
        '
        Me.lblDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDir.AutoSize = True
        Me.lblDir.Location = New System.Drawing.Point(106, 22)
        Me.lblDir.Name = "lblDir"
        Me.lblDir.Size = New System.Drawing.Size(88, 12)
        Me.lblDir.TabIndex = 6
        Me.lblDir.Text = "PathOfUniPack"
        '
        'notifyUpload
        '
        Me.notifyUpload.Icon = CType(resources.GetObject("notifyUpload.Icon"), System.Drawing.Icon)
        Me.notifyUpload.Text = "Unitor Pack Uploader"
        Me.notifyUpload.Visible = True
        '
        'pbUpload
        '
        Me.pbUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbUpload.Location = New System.Drawing.Point(0, 310)
        Me.pbUpload.Name = "pbUpload"
        Me.pbUpload.Size = New System.Drawing.Size(233, 23)
        Me.pbUpload.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbUpload.TabIndex = 8
        Me.pbUpload.Visible = False
        '
        'txtLink
        '
        Me.txtLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLink.Location = New System.Drawing.Point(2, 310)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(231, 21)
        Me.txtLink.TabIndex = 9
        Me.txtLink.Visible = False
        '
        'unipackww
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 364)
        Me.Controls.Add(Me.txtLink)
        Me.Controls.Add(Me.pbUpload)
        Me.Controls.Add(Me.lblDir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txttitle)
        Me.Controls.Add(Me.btnSend)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "unipackww"
        Me.Text = "Unitor UniPack Uploader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txttitle As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDir As System.Windows.Forms.Label
    Friend WithEvents notifyUpload As System.Windows.Forms.NotifyIcon
    Friend WithEvents pbUpload As System.Windows.Forms.ProgressBar
    Friend WithEvents txtLink As System.Windows.Forms.TextBox
    Friend WithEvents tipDirInfo As System.Windows.Forms.ToolTip
End Class
