Imports System
Imports System.IO
Imports System.Text
Imports System.IO.Compression
Imports System.IO.Compression.ZipFile
Imports System.Threading

'Imports MaterialSkin '머티리얼 디자인 서포트
Public Class frmStart

    Inherits Windows.Forms.Form
    Public isFirst As Boolean = True
    'Declare Function GetWinFlags Lib "Kernel" () As Long
    Dim VersionCode = My.Application.Info.Version.ToString
    Private Sub frmStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strTmp() As String
        Dim linesInfo As New List(Of String)(IO.File.ReadAllLines("settings.txt"))
        linesInfo.RemoveAll(Function(s) s.Trim = "")
        Dim filereadbyline() As String = linesInfo.ToArray
        For index = 0 To filereadbyline.Count - 1
            strTmp = Split(filereadbyline(index), " ")
            If (strTmp(0) = "ZeroLEDSupport") Then
                MainProjectLoader.init = True
                MainProjectLoader.settings(0) = strTmp(1)
            ElseIf (strTmp(0) = "GetURLFromServer") Then
                MainProjectLoader.settings(1) = strTmp(1)
            ElseIf (strTmp(0) = "CustomURL") Then

                MainProjectLoader.settings(2) = strTmp(1)


            End If

        Next
        ThreadPool.QueueUserWorkItem(AddressOf ShowNotice)
        Me.Text = "Unitor (S channel) v" & VersionCode.ToString
        If (isFirst = True) Then
            With MainProjectLoader
                .ctrlDict.Add("11", .uni1_1)
                .ctrlDict.Add("12", .uni1_2)
                .ctrlDict.Add("13", .uni1_3)
                .ctrlDict.Add("14", .uni1_4)
                .ctrlDict.Add("15", .uni1_5)
                .ctrlDict.Add("16", .uni1_6)
                .ctrlDict.Add("17", .uni1_7)
                .ctrlDict.Add("18", .uni1_8)

                .ctrlDict.Add("21", .uni2_1)
                .ctrlDict.Add("22", .uni2_2)
                .ctrlDict.Add("23", .uni2_3)
                .ctrlDict.Add("24", .uni2_4)
                .ctrlDict.Add("25", .uni2_5)
                .ctrlDict.Add("26", .uni2_6)
                .ctrlDict.Add("27", .uni2_7)
                .ctrlDict.Add("28", .uni2_8)

                .ctrlDict.Add("31", .uni3_1)
                .ctrlDict.Add("32", .uni3_2)
                .ctrlDict.Add("33", .uni3_3)
                .ctrlDict.Add("34", .uni3_4)
                .ctrlDict.Add("35", .uni3_5)
                .ctrlDict.Add("36", .uni3_6)
                .ctrlDict.Add("37", .uni3_7)
                .ctrlDict.Add("38", .uni3_8)


                .ctrlDict.Add("41", .uni4_1)
                .ctrlDict.Add("42", .uni4_2)
                .ctrlDict.Add("43", .uni4_3)
                .ctrlDict.Add("44", .uni4_4)
                .ctrlDict.Add("45", .uni4_5)
                .ctrlDict.Add("46", .uni4_6)
                .ctrlDict.Add("47", .uni4_7)
                .ctrlDict.Add("48", .uni4_8)

                .ctrlDict.Add("51", .uni5_1)
                .ctrlDict.Add("52", .uni5_2)
                .ctrlDict.Add("53", .uni5_3)
                .ctrlDict.Add("54", .uni5_4)
                .ctrlDict.Add("55", .uni5_5)
                .ctrlDict.Add("56", .uni5_6)
                .ctrlDict.Add("57", .uni5_7)
                .ctrlDict.Add("58", .uni5_8)

                .ctrlDict.Add("61", .uni6_1)
                .ctrlDict.Add("62", .uni6_2)
                .ctrlDict.Add("63", .uni6_3)
                .ctrlDict.Add("64", .uni6_4)
                .ctrlDict.Add("65", .uni6_5)
                .ctrlDict.Add("66", .uni6_6)
                .ctrlDict.Add("67", .uni6_7)
                .ctrlDict.Add("68", .uni6_8)

                .ctrlDict.Add("71", .uni7_1)
                .ctrlDict.Add("72", .uni7_2)
                .ctrlDict.Add("73", .uni7_3)
                .ctrlDict.Add("74", .uni7_4)
                .ctrlDict.Add("75", .uni7_5)
                .ctrlDict.Add("76", .uni7_6)
                .ctrlDict.Add("77", .uni7_7)
                .ctrlDict.Add("78", .uni7_8)

                .ctrlDict.Add("81", .uni8_1)
                .ctrlDict.Add("82", .uni8_2)
                .ctrlDict.Add("83", .uni8_3)
                .ctrlDict.Add("84", .uni8_4)
                .ctrlDict.Add("85", .uni8_5)
                .ctrlDict.Add("86", .uni8_6)
                .ctrlDict.Add("87", .uni8_7)
                .ctrlDict.Add("88", .uni8_8)

            End With
            With dotLEDEdit
                .ctrlDict.Add("11", .uni1_1)
                .ctrlDict.Add("12", .uni1_2)
                .ctrlDict.Add("13", .uni1_3)
                .ctrlDict.Add("14", .uni1_4)
                .ctrlDict.Add("15", .uni1_5)
                .ctrlDict.Add("16", .uni1_6)
                .ctrlDict.Add("17", .uni1_7)
                .ctrlDict.Add("18", .uni1_8)

                .ctrlDict.Add("21", .uni2_1)
                .ctrlDict.Add("22", .uni2_2)
                .ctrlDict.Add("23", .uni2_3)
                .ctrlDict.Add("24", .uni2_4)
                .ctrlDict.Add("25", .uni2_5)
                .ctrlDict.Add("26", .uni2_6)
                .ctrlDict.Add("27", .uni2_7)
                .ctrlDict.Add("28", .uni2_8)

                .ctrlDict.Add("31", .uni3_1)
                .ctrlDict.Add("32", .uni3_2)
                .ctrlDict.Add("33", .uni3_3)
                .ctrlDict.Add("34", .uni3_4)
                .ctrlDict.Add("35", .uni3_5)
                .ctrlDict.Add("36", .uni3_6)
                .ctrlDict.Add("37", .uni3_7)
                .ctrlDict.Add("38", .uni3_8)


                .ctrlDict.Add("41", .uni4_1)
                .ctrlDict.Add("42", .uni4_2)
                .ctrlDict.Add("43", .uni4_3)
                .ctrlDict.Add("44", .uni4_4)
                .ctrlDict.Add("45", .uni4_5)
                .ctrlDict.Add("46", .uni4_6)
                .ctrlDict.Add("47", .uni4_7)
                .ctrlDict.Add("48", .uni4_8)

                .ctrlDict.Add("51", .uni5_1)
                .ctrlDict.Add("52", .uni5_2)
                .ctrlDict.Add("53", .uni5_3)
                .ctrlDict.Add("54", .uni5_4)
                .ctrlDict.Add("55", .uni5_5)
                .ctrlDict.Add("56", .uni5_6)
                .ctrlDict.Add("57", .uni5_7)
                .ctrlDict.Add("58", .uni5_8)

                .ctrlDict.Add("61", .uni6_1)
                .ctrlDict.Add("62", .uni6_2)
                .ctrlDict.Add("63", .uni6_3)
                .ctrlDict.Add("64", .uni6_4)
                .ctrlDict.Add("65", .uni6_5)
                .ctrlDict.Add("66", .uni6_6)
                .ctrlDict.Add("67", .uni6_7)
                .ctrlDict.Add("68", .uni6_8)

                .ctrlDict.Add("71", .uni7_1)
                .ctrlDict.Add("72", .uni7_2)
                .ctrlDict.Add("73", .uni7_3)
                .ctrlDict.Add("74", .uni7_4)
                .ctrlDict.Add("75", .uni7_5)
                .ctrlDict.Add("76", .uni7_6)
                .ctrlDict.Add("77", .uni7_7)
                .ctrlDict.Add("78", .uni7_8)

                .ctrlDict.Add("81", .uni8_1)
                .ctrlDict.Add("82", .uni8_2)
                .ctrlDict.Add("83", .uni8_3)
                .ctrlDict.Add("84", .uni8_4)
                .ctrlDict.Add("85", .uni8_5)
                .ctrlDict.Add("86", .uni8_6)
                .ctrlDict.Add("87", .uni8_7)
                .ctrlDict.Add("88", .uni8_8)

            End With
        End If

    End Sub


    Private Sub btnAddProject_Click(sender As Object, e As EventArgs) Handles btnAddProject.Click

        Dim dlr = Me.newProject.ShowDialog()
        If (dlr <> DialogResult.Cancel) Then '<>는 부정을 나타냄. 즉 대화상자 결과가 취소 버튼 클릭이 아닐때 조건문 성립
            MainProjectLoader.Show()
            MainProjectLoader.Hide()
            Loadingfrm.Show()
            Me.Enabled = False
            'MessageBox.Show(Me.newProject.FileName)
            ThreadPool.QueueUserWorkItem(AddressOf MakeProject_Part1, Me.newProject.FileName)

           

          
        End If
    End Sub

    Private Sub btnReadProject_Click(sender As Object, e As EventArgs) Handles btnReadProject.Click
        Dim dlr = Me.readProject.ShowDialog()
        If (dlr <> DialogResult.Cancel) Then
            MainProjectLoader.Show()
            MainProjectLoader.Update()
            MainProjectLoader.Hide()
            ThreadPool.QueueUserWorkItem(AddressOf LoadProject_Part1, Me.readProject.FileName)
            'LoadProject_Part1(Me.readProject.FileName)
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub LoadProject_Part1(ByVal FilePath As Object)
        Me.Invoke(Sub()
                      Loadingfrm.Show()
                      Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                      Loadingfrm.Update()
                  End Sub)
        Me.Invoke(Sub()
                      Me.Enabled = False
                  End Sub)

        Me.Invoke(Sub()
                      Loadingfrm.workPgLabel.Text = "Flushing Workspace directory..."
                      Loadingfrm.Update()
                  End Sub)
        If (My.Computer.FileSystem.DirectoryExists("Workspace") = True) Then
            My.Computer.FileSystem.DeleteDirectory("Workspace", FileIO.DeleteDirectoryOption.DeleteAllContents)
            'Shell("delete-worksp.bat")
        End If
        My.Computer.FileSystem.CreateDirectory("Workspace")


        Me.Invoke(Sub()
                      Loadingfrm.workPgLabel.Text = "Extracting Project Files..."
                      Loadingfrm.Update()
                  End Sub)
        Dim iserr As Boolean = False
        Try

            Dim zipPath As String = FilePath 'readProject.FileName
            Dim extractPath As String = "Workspace"

            ZipFile.ExtractToDirectory(zipPath, extractPath)
        Catch
            iserr = True
            MessageBox.Show("Failed to extract project file. Please check if project file is vaild.", "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Loadingfrm.workPgLabel.Text = "Flushing Workspace directory and initializing..."
            Loadingfrm.Update()
            'My.Computer.FileSystem.DeleteDirectory("Workspace", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Me.Enabled = True
            Loadingfrm.Close()
        End Try

        'Dim pHelp As New ProcessStartInfo
        'pHelp.FileName = My.Application.Info.DirectoryPath & "\utils\7za.exe"
        'pHelp.Arguments = "e -y -r -o""" & My.Application.Info.DirectoryPath & "\Workspace"" """ & readProject.FileName & """"
        'pHelp.UseShellExecute = True
        'pHelp.WindowStyle = ProcessWindowStyle.Hidden
        'Dim proc As Process = Process.Start(pHelp)
        If (iserr = False) Then


            Me.Invoke(Sub()
                          Loadingfrm.Close()
                          Me.Enabled = True
                          ThreadPool.QueueUserWorkItem(AddressOf MainProjectLoader.ElementLoader, Me.readProject.FileName & ";reopen")

                      End Sub)
            'MainProjectLoader.ElementLoader(Me.readProject.FileName & ";reopen")
            'MainProjectLoader.Show()
        End If
    End Sub

    Public Sub MakeProject_Part1(ByVal FilePath As Object)
        Me.Invoke(Sub()
                      Loadingfrm.Show()
                      Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                      Loadingfrm.Update()
                  End Sub)
        Me.Invoke(Sub()
                      Me.Enabled = False
                  End Sub)

        Me.Invoke(Sub()
                      Loadingfrm.workPgLabel.Text = "Flushing Workspace directory..."
                      Loadingfrm.Update()
                  End Sub)
        If (My.Computer.FileSystem.DirectoryExists("Workspace") = True) Then
            My.Computer.FileSystem.DeleteDirectory("Workspace", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("Workspace")
        Me.Invoke(Sub()
                      Loadingfrm.workPgLabel.Text = "Creating Necessary Files..."
                  End Sub)
        'Common File Stream
        Dim fs As FileStream
        Dim info As Byte()


        fs = File.Create("Workspace\info")
        info = New UTF8Encoding(True).GetBytes("title=Hello World!" & vbNewLine & "buttonX=8" & vbNewLine & "buttonY=8" & vbNewLine & "producerName=UniPackGUI Editor" & vbNewLine & "chain=1" & vbNewLine & "squareButton=true" & vbNewLine & "landscape=true")
        fs.Write(info, 0, info.Length)
        fs.Close()

        fs = File.Create("Workspace\keySound")
        info = New UTF8Encoding(True).GetBytes("")
        fs.Write(info, 0, info.Length)
        fs.Close()

        My.Computer.FileSystem.CreateDirectory("Workspace\sounds")

       
        Me.Invoke(Sub()
                      Me.Enabled = True
                      Loadingfrm.Close()
                      MainProjectLoader.Show()
                      MainProjectLoader.Hide()
                      ThreadPool.QueueUserWorkItem(AddressOf MainProjectLoader.ElementLoader, Me.newProject.FileName & ";new")

                  End Sub)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        wavConvert.LoadElement("", "Normal")
        wavConvert.ShowDialog()
    End Sub

    Private Sub btnSoundCut_Click(sender As Object, e As EventArgs) Handles btnSoundCut.Click
        SoundCutter.ShowDialog()
    End Sub

    Private Sub ShowNotice()
        Me.Invoke(Sub()
                      NoticesNAd.ShowDialog()
                  End Sub)
    End Sub

End Class
