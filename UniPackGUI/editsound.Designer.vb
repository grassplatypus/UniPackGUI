<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editsound
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
        Me.listAllSounds = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.listLoadedSounds = New System.Windows.Forms.ListBox()
        Me.gbLoaded = New System.Windows.Forms.GroupBox()
        Me.lblLengthLoaded = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnPlaySound = New System.Windows.Forms.Button()
        Me.btnPrimDown = New System.Windows.Forms.Button()
        Me.btnPrimUp = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSoundLen = New System.Windows.Forms.Label()
        Me.btnRemoveReload = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.btnPlayAll = New System.Windows.Forms.Button()
        Me.ofdSound = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gbLoaded.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'listAllSounds
        '
        Me.listAllSounds.AllowDrop = True
        Me.listAllSounds.FormattingEnabled = True
        Me.listAllSounds.ItemHeight = 12
        Me.listAllSounds.Location = New System.Drawing.Point(3, 17)
        Me.listAllSounds.Name = "listAllSounds"
        Me.listAllSounds.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.listAllSounds.Size = New System.Drawing.Size(285, 232)
        Me.listAllSounds.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(470, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "You can select sounds for your UniPack here. (Only .wav files)"
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(529, 268)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(75, 40)
        Me.btnSet.TabIndex = 2
        Me.btnSet.Text = "Okay"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'listLoadedSounds
        '
        Me.listLoadedSounds.FormattingEnabled = True
        Me.listLoadedSounds.ItemHeight = 12
        Me.listLoadedSounds.Location = New System.Drawing.Point(20, 20)
        Me.listLoadedSounds.Name = "listLoadedSounds"
        Me.listLoadedSounds.Size = New System.Drawing.Size(136, 172)
        Me.listLoadedSounds.TabIndex = 4
        '
        'gbLoaded
        '
        Me.gbLoaded.Controls.Add(Me.lblLengthLoaded)
        Me.gbLoaded.Controls.Add(Me.Button2)
        Me.gbLoaded.Controls.Add(Me.btnPlaySound)
        Me.gbLoaded.Controls.Add(Me.btnPrimDown)
        Me.gbLoaded.Controls.Add(Me.btnPrimUp)
        Me.gbLoaded.Controls.Add(Me.listLoadedSounds)
        Me.gbLoaded.Location = New System.Drawing.Point(349, 32)
        Me.gbLoaded.Name = "gbLoaded"
        Me.gbLoaded.Size = New System.Drawing.Size(255, 230)
        Me.gbLoaded.TabIndex = 6
        Me.gbLoaded.TabStop = False
        Me.gbLoaded.Text = "Loaded Sounds (Button Sound)"
        '
        'lblLengthLoaded
        '
        Me.lblLengthLoaded.AutoSize = True
        Me.lblLengthLoaded.Location = New System.Drawing.Point(18, 195)
        Me.lblLengthLoaded.Name = "lblLengthLoaded"
        Me.lblLengthLoaded.Size = New System.Drawing.Size(108, 12)
        Me.lblLengthLoaded.TabIndex = 12
        Me.lblLengthLoaded.Text = "Sound Length: NA"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("굴림", 7.0!)
        Me.Button2.Location = New System.Drawing.Point(162, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Sound Code"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btnPlaySound
        '
        Me.btnPlaySound.Location = New System.Drawing.Point(162, 118)
        Me.btnPlaySound.Name = "btnPlaySound"
        Me.btnPlaySound.Size = New System.Drawing.Size(75, 23)
        Me.btnPlaySound.TabIndex = 10
        Me.btnPlaySound.Text = "Play"
        Me.btnPlaySound.UseVisualStyleBackColor = True
        '
        'btnPrimDown
        '
        Me.btnPrimDown.Location = New System.Drawing.Point(162, 49)
        Me.btnPrimDown.Name = "btnPrimDown"
        Me.btnPrimDown.Size = New System.Drawing.Size(68, 23)
        Me.btnPrimDown.TabIndex = 5
        Me.btnPrimDown.Text = "Down"
        Me.btnPrimDown.UseVisualStyleBackColor = True
        '
        'btnPrimUp
        '
        Me.btnPrimUp.Location = New System.Drawing.Point(162, 20)
        Me.btnPrimUp.Name = "btnPrimUp"
        Me.btnPrimUp.Size = New System.Drawing.Size(68, 23)
        Me.btnPrimUp.TabIndex = 5
        Me.btnPrimUp.Text = "Up"
        Me.btnPrimUp.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(306, 306)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tip: Maximum of songs in a button is 40"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(309, 82)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(34, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = ">>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(309, 111)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(34, 23)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.Text = "<<"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSoundLen)
        Me.GroupBox1.Controls.Add(Me.btnRemoveReload)
        Me.GroupBox1.Controls.Add(Me.btnRemoveAll)
        Me.GroupBox1.Controls.Add(Me.btnAddAll)
        Me.GroupBox1.Controls.Add(Me.btnPlayAll)
        Me.GroupBox1.Controls.Add(Me.listAllSounds)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(291, 310)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "All Sounds"
        '
        'lblSoundLen
        '
        Me.lblSoundLen.AutoSize = True
        Me.lblSoundLen.Location = New System.Drawing.Point(6, 252)
        Me.lblSoundLen.Name = "lblSoundLen"
        Me.lblSoundLen.Size = New System.Drawing.Size(108, 12)
        Me.lblSoundLen.TabIndex = 11
        Me.lblSoundLen.Text = "Sound Length: NA"
        '
        'btnRemoveReload
        '
        Me.btnRemoveReload.Location = New System.Drawing.Point(228, 279)
        Me.btnRemoveReload.Name = "btnRemoveReload"
        Me.btnRemoveReload.Size = New System.Drawing.Size(57, 23)
        Me.btnRemoveReload.TabIndex = 4
        Me.btnRemoveReload.Text = "Reload"
        Me.btnRemoveReload.UseVisualStyleBackColor = True
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(120, 279)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(64, 23)
        Me.btnRemoveAll.TabIndex = 3
        Me.btnRemoveAll.Text = "Remove"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnAddAll
        '
        Me.btnAddAll.Location = New System.Drawing.Point(72, 279)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(42, 23)
        Me.btnAddAll.TabIndex = 2
        Me.btnAddAll.Text = "Add"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'btnPlayAll
        '
        Me.btnPlayAll.Location = New System.Drawing.Point(3, 279)
        Me.btnPlayAll.Name = "btnPlayAll"
        Me.btnPlayAll.Size = New System.Drawing.Size(63, 23)
        Me.btnPlayAll.TabIndex = 1
        Me.btnPlayAll.Text = "Play"
        Me.btnPlayAll.UseVisualStyleBackColor = True
        '
        'ofdSound
        '
        Me.ofdSound.Filter = "Wav Files|*.wav"
        Me.ofdSound.Multiselect = True
        Me.ofdSound.Title = "Select Sound Files.. (Multiple)"
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(306, 319)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tip: You can drag and drop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       multiple files."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(529, 314)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'editsound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 354)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbLoaded)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "editsound"
        Me.ShowInTaskbar = False
        Me.Text = "Sound Manager"
        Me.gbLoaded.ResumeLayout(False)
        Me.gbLoaded.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listAllSounds As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents listLoadedSounds As System.Windows.Forms.ListBox
    Friend WithEvents gbLoaded As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrimDown As System.Windows.Forms.Button
    Friend WithEvents btnPrimUp As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPlaySound As System.Windows.Forms.Button
    Friend WithEvents btnRemoveReload As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents btnPlayAll As System.Windows.Forms.Button
    Friend WithEvents ofdSound As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblSoundLen As System.Windows.Forms.Label
    Friend WithEvents lblLengthLoaded As System.Windows.Forms.Label
End Class
