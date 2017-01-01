<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adbPush
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(adbPush))
        Me.btnUpdateDevice = New System.Windows.Forms.Button()
        Me.listDevice = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.folderlist = New System.Windows.Forms.ListBox()
        Me.btnUse = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPackname = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnUpdateDevice
        '
        Me.btnUpdateDevice.Location = New System.Drawing.Point(12, 223)
        Me.btnUpdateDevice.Name = "btnUpdateDevice"
        Me.btnUpdateDevice.Size = New System.Drawing.Size(143, 23)
        Me.btnUpdateDevice.TabIndex = 0
        Me.btnUpdateDevice.Text = "Update Device List"
        Me.btnUpdateDevice.UseVisualStyleBackColor = True
        '
        'listDevice
        '
        Me.listDevice.FormattingEnabled = True
        Me.listDevice.ItemHeight = 12
        Me.listDevice.Location = New System.Drawing.Point(12, 21)
        Me.listDevice.Name = "listDevice"
        Me.listDevice.Size = New System.Drawing.Size(143, 196)
        Me.listDevice.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Powered by AndroidLib by Regaw Leinad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(161, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Do not close this window using TaskMgr!"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(337, 48)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(90, 38)
        Me.btnSend.TabIndex = 4
        Me.btnSend.Text = "Send!"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'folderlist
        '
        Me.folderlist.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.folderlist.FormattingEnabled = True
        Me.folderlist.ItemHeight = 12
        Me.folderlist.Location = New System.Drawing.Point(12, 21)
        Me.folderlist.Name = "folderlist"
        Me.folderlist.Size = New System.Drawing.Size(143, 196)
        Me.folderlist.TabIndex = 5
        Me.folderlist.Visible = False
        '
        'btnUse
        '
        Me.btnUse.Location = New System.Drawing.Point(12, 252)
        Me.btnUse.Name = "btnUse"
        Me.btnUse.Size = New System.Drawing.Size(143, 55)
        Me.btnUse.TabIndex = 6
        Me.btnUse.Text = "Use This Device"
        Me.btnUse.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(260, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(167, 21)
        Me.TextBox1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(177, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Folder name:"
        '
        'lblPackname
        '
        Me.lblPackname.AutoSize = True
        Me.lblPackname.ForeColor = System.Drawing.Color.Blue
        Me.lblPackname.Location = New System.Drawing.Point(182, 94)
        Me.lblPackname.Name = "lblPackname"
        Me.lblPackname.Size = New System.Drawing.Size(75, 12)
        Me.lblPackname.TabIndex = 9
        Me.lblPackname.Text = "Pack Name:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.ForeColor = System.Drawing.Color.LawnGreen
        Me.RichTextBox1.Location = New System.Drawing.Point(184, 121)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(257, 137)
        Me.RichTextBox1.TabIndex = 11
        Me.RichTextBox1.Text = ""
        '
        'adbPush
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 325)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.lblPackname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnUse)
        Me.Controls.Add(Me.folderlist)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listDevice)
        Me.Controls.Add(Me.btnUpdateDevice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "adbPush"
        Me.Text = "Push to Device"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpdateDevice As System.Windows.Forms.Button
    Friend WithEvents listDevice As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents folderlist As System.Windows.Forms.ListBox
    Friend WithEvents btnUse As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPackname As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
