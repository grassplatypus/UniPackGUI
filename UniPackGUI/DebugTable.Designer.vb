<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugTable
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.listLog = New System.Windows.Forms.ListView()
        Me.logKind = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.logmsg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cblogInfo = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(423, 371)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cblogInfo)
        Me.TabPage1.Controls.Add(Me.listLog)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(415, 345)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'listLog
        '
        Me.listLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.logKind, Me.logmsg})
        Me.listLog.Location = New System.Drawing.Point(0, 0)
        Me.listLog.Name = "listLog"
        Me.listLog.Size = New System.Drawing.Size(382, 302)
        Me.listLog.TabIndex = 0
        Me.listLog.UseCompatibleStateImageBehavior = False
        '
        'logKind
        '
        Me.logKind.Text = "Kind"
        Me.logKind.Width = 40
        '
        'logmsg
        '
        Me.logmsg.Width = 200
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(415, 345)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cblogInfo
        '
        Me.cblogInfo.AutoSize = True
        Me.cblogInfo.Location = New System.Drawing.Point(119, 308)
        Me.cblogInfo.Name = "cblogInfo"
        Me.cblogInfo.Size = New System.Drawing.Size(81, 17)
        Me.cblogInfo.TabIndex = 1
        Me.cblogInfo.Text = "CheckBox1"
        Me.cblogInfo.UseVisualStyleBackColor = True
        '
        'DebugTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 515)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "DebugTable"
        Me.Text = "DebugTable"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents listLog As System.Windows.Forms.ListView
    Friend WithEvents logKind As System.Windows.Forms.ColumnHeader
    Friend WithEvents logmsg As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cblogInfo As System.Windows.Forms.CheckBox
End Class
