Imports NAudio
Imports NAudio.Wave
Imports System.IO
'Imports UniPackGUI.MultiSounds

Public Class wavConvert
    Public ToBeFixed As New List(Of String)
    Public tobefixed_Path As New List(Of String)
    Dim mode As String
    Private Sub wavConvert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pbBar.Visible = False
    End Sub

    Private Sub Convert()

        For Each filename In Directory.GetFiles("TmpSound", "*")
            My.Computer.FileSystem.DeleteFile(filename)
        Next
        ToBeFixed.Clear()
        tobefixed_Path.Clear()
        Try
            If (Me.btnSounds.Items.Count = 0) Then
                MessageBox.Show("No directory loaded!", "Directory Not Loaded", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            Dim index As Integer = 0
            Me.Invoke(Sub()
                          Me.Button1.Enabled = False
                          Me.pbBar.Value = 0
                          Me.pbBar.Maximum = Me.btnSounds.Items.Count
                          Me.pbBar.Visible = True
                      End Sub)
            For Each filename As String In Me.btnSounds.Items
                Me.Invoke(Sub()
                              Me.lblStat.Text = "Converting... (" & index & "/" & Me.btnSounds.Items.Count - 1 & ")=>" & filename
                              Me.pbBar.Value += 1
                          End Sub)
                If (filename.Split(".")(filename.Split(".").Count - 1)) = "wav" Then

                    If (GetHeader(Me.textDir.Text & "\" & filename).ToUpper = "RIFF") Then
                    Else

                        If (mode = "UniPackLoaded Mode") Then
                            'Dim soundName As String = MainProjectLoader.Snds.SearchByKey(Me.textDir.Text & "\" & filename) '경로key, 이름value
                            'MainProjectLoader.Snds.EndSoundPath(Me.textDir.Text & "\" & filename)


                            wavConvert.Mp3ToWav(Me.textDir.Text & "\" & filename, "TmpSound\" & filename)

                            'MainProjectLoader.Snds.AddSound(soundName, Me.textDir.Text & "\" & filename)

                        Else
                            Mp3ToWav(Me.textDir.Text & "\" & filename, "tmpSound\" & filename)
                        End If
                    End If
                End If
                index += 1
            Next
            Me.Invoke(Sub()
                          Me.lblStat.Text = "Now moving Files to path..."
                          Me.Update()
                      End Sub)
            If (mode <> "UniPackLoaded Mode") Then
                Me.Invoke(Sub()
                              Me.pbBar.Value = 0
                              Me.pbBar.Maximum = 1
                              Me.pbBar.Visible = False
                              Me.lblStat.Text = "Ready"
                              Me.Button1.Enabled = True
                          End Sub)
                MessageBox.Show("Completed! Now you can play with Unitor!", "Convert Succeed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.Invoke(Sub()
                              Me.pbBar.Value = 0
                              Me.pbBar.Maximum = 1
                              Me.pbBar.Visible = False
                              Me.lblStat.Text = "Ready"
                              Me.Button1.Enabled = True
                          End Sub)
                Me.Invoke(Sub()
                              MessageBox.Show("For stability, Unitor will reload the pack. Please wait...", "Convert Succeed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                              Me.Close()
                              Me.Update()
                              'MainProjectLoader.ElementLoader(MainProjectLoader.tbPackDirInfo.Text & ";reopen;WavConvert")
                              Threading.ThreadPool.QueueUserWorkItem(AddressOf MainProjectLoader.ElementLoader, MainProjectLoader.tbPackDirInfo.Text & ";reopen;WavConvert")

                          End Sub)
            End If
        Catch
            MessageBox.Show("Failed to convert! Exiting Process... Message: " & ErrorToString(), "Converting Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Invoke(Sub()
                          Me.lblStat.Text = "Error Occured!"
                          Me.pbBar.Value = 0
                          Me.pbBar.Maximum = 1
                          Me.pbBar.Visible = False
                          Me.Button1.Enabled = False
                      End Sub)
            Exit Sub
        End Try
        
    End Sub

    Public Shared Sub Mp3ToWav(mp3File As String, outputFile As String)
        Try
            Using reader As New Mp3FileReader(mp3File)
                Using pcmStream As WaveStream = WaveFormatConversionStream.CreatePcmStream(reader)
                    WaveFileWriter.CreateWaveFile(outputFile, pcmStream)
                    pcmStream.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGoConvert.Click

        Threading.ThreadPool.QueueUserWorkItem(AddressOf Convert)
        'Convert()
    End Sub

    Public Sub LoadElement(p1 As String, p2 As String)
        Me.textDir.Text = ""
        Me.btnSounds.Items.Clear()
        mode = p2
        Me.btnLoadDir.Enabled = True
        Me.textDir.ReadOnly = False
        'Me.textDir.Text = p1

        If (p2 = "UniPackLoaded Mode") Then
            Me.textDir.Text = "Workspace\sounds"
            Me.btnLoadDir.Enabled = False
            Me.textDir.ReadOnly = True
        End If
    End Sub

    Private Sub btnLoadDir_Click(sender As Object, e As EventArgs) Handles btnLoadDir.Click
        If (Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.textDir.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.btnGoConvert.Enabled = False
        Try
            Dim files() As String = Directory.GetFiles(Me.textDir.Text, "*", SearchOption.TopDirectoryOnly)
            For Each filename In files
                Dim tmp() As String = filename.Split("\")
                Me.btnSounds.Items.Add(tmp(tmp.Count - 1))
            Next
        Catch
            MessageBox.Show("Error Occured during sound loading process! Message: " & ErrorToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.btnGoConvert.Enabled = True
    End Sub

    'http://stackoverflow.com/questions/9071581/how-to-read-tiff-header-file-c
    Public Function GetHeader(Path As String) As String
        Const HEADER_SIZE As Integer = 4

        Dim bytesFile As Byte() = New Byte(HEADER_SIZE - 1) {}

        Using fs As FileStream = File.OpenRead(Path)
            fs.Read(bytesFile, 0, HEADER_SIZE)
            fs.Close()
        End Using

        Dim hex As String = BitConverter.ToString(bytesFile)

        Dim header As String() = hex.Split(New [Char]() {"-"c}).ToArray()
        Return System.[String].Join("", header)
        'Console.WriteLine(System.[String].Join("", header))

        'Console.ReadLine()
    End Function
End Class