Imports System.IO
Imports Microsoft.VisualBasic
Imports UniPackGUI.MultiSounds
'Imports NAudio.Wave

Public Class editsound
    'Private Snds As New MultiSounds
    Dim chainnow As Integer
    Dim XC As Integer
    Dim YC As Integer
    Private MouseIsDown As Boolean
    Dim soundcounter As Integer
    Dim wavInfo As New WavTools


    Public Sub soundLoad(nowChain As Integer, uniX As Integer, uniY As Integer)
        MainProjectLoader.isSaved = False
        soundcounter = 0
        Me.listLoadedSounds.Items.Clear()
        Me.listAllSounds.Items.Clear()


        Me.Enabled = False
        Loadingfrm.Show()
        Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
        Loadingfrm.workPgLabel.Text = "Loading sounds data..."
        Loadingfrm.Update()
        Dim tmp() As String
        Dim tmpint As Integer
        Dim files() As String
        files = Directory.GetFiles("Workspace\sounds", "*.wav", SearchOption.TopDirectoryOnly)
        For Each FileName As String In files
            Loadingfrm.Update()
            tmp = FileName.Split("\")
            tmpint = tmp.Length

            Me.listAllSounds.Items.Add(tmp(tmpint - 1))


            'Me.listAllSounds.Items.Add(FileName)
        Next

        chainnow = nowChain
        XC = uniX
        YC = uniY
        If (nowChain = 0 And XC = 0 And YC = 0) Then
            Me.gbLoaded.Enabled = False
            Me.btnAdd.Enabled = False
            Me.btnRemove.Enabled = False
            Me.Text = "Sound Manager"
        Else
            Me.gbLoaded.Enabled = True
            Me.btnAdd.Enabled = True
            Me.btnRemove.Enabled = True
            Me.Text = "Sound Manager : " & chainnow & " Chain & Xcode " & XC & " & Ycode " & YC
            Loadingfrm.LoadingPg.Style = ProgressBarStyle.Blocks
            Loadingfrm.LoadingPg.Maximum = MainProjectLoader.keysounds_max(nowChain, uniX, uniY)
            'MsgBox(MainProjectLoader.keysounds_max(nowChain, uniX, uniY))
            'msgbox("1")

            For index = 0 To MainProjectLoader.keysounds_max(nowChain, uniX, uniY)
                'MsgBox(MainProjectLoader.keysounds_max(nowChain, uniX, uniY))
                Loadingfrm.workPgLabel.Text = "Loading sounds data... (" & index & "/" & MainProjectLoader.keysounds_max(nowChain, uniX, uniY) & ")"
                Loadingfrm.Update()
                If (index = MainProjectLoader.keysounds_max(nowChain, uniX, uniY)) Then
                    Exit For
                Else
                    tmp = MainProjectLoader.soundfiles(nowChain, uniX, uniY, index).Split("\")
                End If
                soundcounter = soundcounter + 1
                tmpint = tmp.Length

                Me.listLoadedSounds.Items.Add(tmp(tmpint - 1))

                Loadingfrm.LoadingPg.Value += 1


            Next
        End If
        Me.lblSoundLen.Text = "Sound Length: NA"
        Loadingfrm.Close()
        Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
        Me.Enabled = True
    End Sub

    Private Sub btnPlaySound_Click(sender As Object, e As EventArgs) Handles btnPlaySound.Click
        Try
            My.Computer.Audio.Play("Workspace\sounds\" & Me.listLoadedSounds.SelectedItem, AudioPlayMode.Background)
        Catch
            MessageBox.Show("Error occured during trying to play sound. Message: " & ErrorToString() & vbNewLine & "Number: " & Err.Number, "Play Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If (Err.Number = 5) Then
                MessageBox.Show("It seems not a correct Wav file. Maybe it is a Mp3 file. Unitor can't play Mp3 file. How about trying Mp3 to Wav Converter? (Powered by NAudio) You can use it by clicking File -> Mp3 to Wav Converter!")
            End If
        End Try
    End Sub

    Private Sub btnPrimUp_Click(sender As Object, e As EventArgs) Handles btnPrimUp.Click
        Try
            'MessageBox.Show(Me.listLoadedSounds.SelectedIndex)
            If (Me.listLoadedSounds.SelectedIndex - 1 >= 0) Then

                Me.listLoadedSounds.Items.Insert(Me.listLoadedSounds.SelectedIndex - 1, Me.listLoadedSounds.SelectedItem)
                Me.listLoadedSounds.Items.RemoveAt(Me.listLoadedSounds.SelectedIndex)
            Else
                MessageBox.Show("Out of Index!", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch
        End Try
    End Sub

    Private Sub btnPrimDown_Click(sender As Object, e As EventArgs) Handles btnPrimDown.Click
        Try
            If (Me.listLoadedSounds.SelectedIndex + 1 < Me.listLoadedSounds.Items.Count) Then
                Me.listLoadedSounds.Items.Insert(Me.listLoadedSounds.SelectedIndex + 1, Me.listLoadedSounds.SelectedItem)
                Me.listLoadedSounds.Items.RemoveAt(Me.listLoadedSounds.SelectedIndex)
            Else
                MessageBox.Show("Out of Index!", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (Me.listLoadedSounds.Items.Count + 1 > 40) Then
                MessageBox.Show("You can only set maximum 40 songs to a ""One"" button.", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else

                For Each nowfiles As String In Me.listAllSounds.SelectedItems
                    'Dim wavRe As New WaveFileReader("sounds\" & nowfiles)
                    'If (wavRe.TotalTime.TotalSeconds < 6) Then
                    Me.listLoadedSounds.Items.Add(nowfiles)
                    'Else
                    'MessageBox.Show("'" & nowfiles & "' is too long that Android's Soundpool can handle! (6 Seconds) We will still continue adding process for other sounds.", "Longer than 6 sec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End If
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        If (chainnow = 0 And XC = 0 And YC = 0) Then
        Else


            For i = 0 To MainProjectLoader.keysounds_max(chainnow, XC, YC)
                MainProjectLoader.Snds.Close(chainnow & " " & XC & " " & YC & " " & i)
                MainProjectLoader.soundfiles(chainnow, XC, YC, i) = ""
            Next
            MainProjectLoader.keysounds_max(chainnow, XC, YC) = Me.listLoadedSounds.Items.Count
            For i = 0 To Me.listLoadedSounds.Items.Count - 1
                MainProjectLoader.Snds.AddSound(chainnow & " " & XC & " " & YC & " " & i, "Workspace\sounds\" & Me.listLoadedSounds.Items(i).ToString)
                MainProjectLoader.soundfiles(chainnow, XC, YC, i) = "Workspace\sounds\" & Me.listLoadedSounds.Items(i).ToString
            Next
            
        End If
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            Me.listLoadedSounds.Items.RemoveAt(Me.listLoadedSounds.SelectedIndex)
        Catch
        End Try
    End Sub

    Private Sub btnPlayAll_Click(sender As Object, e As EventArgs) Handles btnPlayAll.Click
        Try
            My.Computer.Audio.Play("Workspace\sounds\" & Me.listAllSounds.SelectedItem, AudioPlayMode.Background)
        Catch
            MessageBox.Show("Please check that if the sound file you selected exists. If it exists, it may be damaged.", "Play Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddAll_Click(sender As Object, e As EventArgs) Handles btnAddAll.Click
        Me.ofdSound.Multiselect = True
        Dim dlr = Me.ofdSound.ShowDialog()
        If (dlr <> DialogResult.Cancel) Then

            Dim tmp() As String
            For Each soundname In Me.ofdSound.FileNames
                Dim tmp2() As String = soundname.Split("\")
                If (Me.listAllSounds.Items.Contains(tmp2(tmp2.Length - 1))) Then
                    Dim result = MessageBox.Show(soundname & " is already exists in list! Do want to overwrite?", "Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If result = Windows.Forms.DialogResult.Yes Then
                        Dim wavname As String = soundname
                        tmp = wavname.Split("\")

                        My.Computer.FileSystem.CopyFile(wavname, "Workspace\sounds\" & tmp(tmp.Length - 1), True)
                        'Me.listAllSounds.Items.Add(tmp(tmp.Length - 1))
                    End If
                Else
                    'MsgBox(soundname)
                    Dim wavname As String = soundname
                    tmp = wavname.Split("\")

                    My.Computer.FileSystem.CopyFile(wavname, "Workspace\sounds\" & tmp(tmp.Length - 1))
                    Me.listAllSounds.Items.Add(tmp(tmp.Length - 1))
                End If
            Next
        End If
    End Sub



    Private Sub editsound_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnRemoveReload_Click(sender As Object, e As EventArgs) Handles btnRemoveReload.Click
        soundLoad(chainnow, XC, YC)
    End Sub

    Private Sub btnRemoveAll_Click(sender As Object, e As EventArgs) Handles btnRemoveAll.Click
        My.Computer.FileSystem.DeleteFile("Workspace\sounds\" & Me.listAllSounds.SelectedItem)
        soundLoad(chainnow, XC, YC)
    End Sub

    Private Sub listAllSounds_Drop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles listAllSounds.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each filePath As String In CType(e.Data.GetData(DataFormats.FileDrop), String())
                Dim tmp2() As String = filePath.Split("\")
                Dim tmp() As String
                If (Me.listAllSounds.Items.Contains(tmp2(tmp2.Length - 1))) Then
                    Dim result = MessageBox.Show(filePath & " is already exists in list! Do want to overwrite?", "Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If result = Windows.Forms.DialogResult.Yes Then
                        Dim wavname As String = filePath
                        tmp = wavname.Split("\")

                        My.Computer.FileSystem.CopyFile(wavname, "Workspace\sounds\" & tmp(tmp.Length - 1), True)
                        'Me.listAllSounds.Items.Add(tmp(tmp.Length - 1))
                    End If
                Else
                    'MsgBox(filepath)
                    Dim wavname As String = filePath
                    tmp = wavname.Split("\")

                    My.Computer.FileSystem.CopyFile(wavname, "Workspace\sounds\" & tmp(tmp.Length - 1))
                    Me.listAllSounds.Items.Add(tmp(tmp.Length - 1))
                End If
            Next
        End If
    End Sub

    Private Sub listAllSounds_Chainge(sender As Object, e As EventArgs) Handles listAllSounds.SelectedIndexChanged
        Dim counter As Integer = 0
        For Each justvar In Me.listAllSounds.SelectedItems
            counter = counter + 1

        Next
        If (counter > 1 Or counter = 0) Then
            Me.btnPlayAll.Enabled = False
        ElseIf (counter = 1) Then
            Me.btnPlayAll.Enabled = True
            Try
                Dim ApiReader As New NAudio.Wave.AudioFileReader("Workspace\sounds\" & Me.listAllSounds.SelectedItem)
                Me.lblSoundLen.Text = ApiReader.TotalTime.ToString()
            Catch
                If (Err.Number = 5) Then
                    MessageBox.Show("Not correct Wav file! How about trying our Converter? (Mp32Wav Converter) You can use it by clicking File -> Mp32Wav Converter.")
                Else
                    MessageBox.Show("Error occured while loading wav file! Message: " & ErrorToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try
        End If
    End Sub

    Private Sub ListAllDragNDropOn(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles listAllSounds.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(chainnow & " " & XC & " " & YC & " " & Me.listLoadedSounds.SelectedIndex)
    End Sub

    Private Sub listLoadedSounds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listLoadedSounds.SelectedIndexChanged
        If (Me.listAllSounds.SelectedItems.Count = 1) Then
            Try
                Dim ApiReader As New NAudio.Wave.AudioFileReader("Workspace\sounds\" & Me.listLoadedSounds.SelectedItem)
                Me.lblLengthLoaded.Text = ApiReader.TotalTime.ToString()
            Catch
                If (Err.Number = 5) Then
                    MessageBox.Show("Not correct Wav file! How about trying our Converter? (Mp32Wav Converter) You can use it by clicking File -> Mp32Wav Converter.")
                Else
                    MessageBox.Show("Error occured while loading wav file! Message: " & ErrorToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try
        End If
    End Sub

    Private Sub lblSoundLen_Click(sender As Object, e As EventArgs) Handles lblSoundLen.Click

    End Sub
End Class