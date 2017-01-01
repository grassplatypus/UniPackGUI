<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart))
        Me.newProject = New System.Windows.Forms.SaveFileDialog()
        Me.readProject = New System.Windows.Forms.OpenFileDialog()
        Me.rtbInfoMain = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReadProject = New System.Windows.Forms.Button()
        Me.btnAddProject = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSoundCut = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'newProject
        '
        Me.newProject.AddExtension = False
        Me.newProject.Filter = "UniPack Archive File|*.zip|UniPack Files|*.uni"
        Me.newProject.Title = "Path and Name for New Project"
        '
        'readProject
        '
        Me.readProject.Filter = "UniPack Archive File|*.zip|UniPack Files|*.uni"
        Me.readProject.Title = "Select a Project File"
        '
        'rtbInfoMain
        '
        Me.rtbInfoMain.Location = New System.Drawing.Point(16, 48)
        Me.rtbInfoMain.Name = "rtbInfoMain"
        Me.rtbInfoMain.ReadOnly = True
        Me.rtbInfoMain.Size = New System.Drawing.Size(305, 126)
        Me.rtbInfoMain.TabIndex = 4
        Me.rtbInfoMain.Text = resources.GetString("rtbInfoMain.Text")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(223, 277)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Bye Bye!(&E)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReadProject
        '
        Me.btnReadProject.Location = New System.Drawing.Point(173, 180)
        Me.btnReadProject.Name = "btnReadProject"
        Me.btnReadProject.Size = New System.Drawing.Size(148, 55)
        Me.btnReadProject.TabIndex = 2
        Me.btnReadProject.Text = "Read A Project"
        Me.btnReadProject.UseVisualStyleBackColor = True
        '
        'btnAddProject
        '
        Me.btnAddProject.Location = New System.Drawing.Point(19, 180)
        Me.btnAddProject.Name = "btnAddProject"
        Me.btnAddProject.Size = New System.Drawing.Size(148, 55)
        Me.btnAddProject.TabIndex = 1
        Me.btnAddProject.Text = "Make A Project"
        Me.btnAddProject.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 13.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome to UniPack IDE, Unitor!"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 7.9!)
        Me.Label2.ForeColor = System.Drawing.Color.Coral
        Me.Label2.Location = New System.Drawing.Point(1, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 22)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Copyright 2016~ UniPad Team (Unitor)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright 2015~ Kim JS (UniPad)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Mp32Wav Converter"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnSoundCut
        '
        Me.btnSoundCut.Location = New System.Drawing.Point(173, 241)
        Me.btnSoundCut.Name = "btnSoundCut"
        Me.btnSoundCut.Size = New System.Drawing.Size(148, 23)
        Me.btnSoundCut.TabIndex = 6
        Me.btnSoundCut.Text = "Sound Cutter"
        Me.btnSoundCut.UseVisualStyleBackColor = True
        Me.btnSoundCut.Visible = False
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 310)
        Me.Controls.Add(Me.btnSoundCut)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rtbInfoMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnReadProject)
        Me.Controls.Add(Me.btnAddProject)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStart"
        Me.Text = "UniPackGUI Editor by FollowJanbab"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents newProject As System.Windows.Forms.SaveFileDialog
    Friend WithEvents readProject As System.Windows.Forms.OpenFileDialog
    Friend WithEvents rtbInfoMain As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReadProject As System.Windows.Forms.Button
    Friend WithEvents btnAddProject As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnSoundCut As System.Windows.Forms.Button

End Class
