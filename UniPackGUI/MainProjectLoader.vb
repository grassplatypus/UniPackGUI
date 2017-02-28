Imports System.IO
Imports System.Text
Imports System.IO.Compression
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Media.SoundPlayer
Imports System.Windows
Imports NAudio
Imports System.Net.NetworkInformation
Imports System.Net
Imports System.Drawing.Drawing2D



Public Class MainProjectLoader
    Custom Event ehandler As ErrorEventHandler
        AddHandler(value As ErrorEventHandler)

        End AddHandler

        RemoveHandler(value As ErrorEventHandler)

        End RemoveHandler

        RaiseEvent(sender As Object, e As ErrorEventArgs)

        End RaiseEvent
    End Event

    Private Sub MainProjectLoader_close(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If isSaved = False Then
            Dim result = MessageBox.Show("You didn't save yet. Save " & Me.tbPackName.Text & "?", "Save Warning", MessageBoxButtons.YesNoCancel)
            If result = Forms.DialogResult.Yes Then
                SaveProjectToolStripMenuItem.PerformClick()
            ElseIf result = Forms.DialogResult.No Then
                Application.ExitThread()
            ElseIf result = Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub MainProjectLoader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SmallProfileImage As New System.Drawing.Drawing2D.GraphicsPath
        SmallProfileImage.AddEllipse(New Rectangle(0, 0, 70, 70))
        Me.pbUserProfile.Region = New Region(SmallProfileImage)


        Dim bigProfileImage As New System.Drawing.Drawing2D.GraphicsPath
        bigProfileImage.AddEllipse(New Rectangle(0, 0, 100, 100))
        Me.pbProfImgBig.Region = New Region(bigProfileImage)

        Dim dashboard_logout As New System.Drawing.Drawing2D.GraphicsPath
        dashboard_logout.AddEllipse(New Rectangle(0, 0, 40, 40))
        Me.pb_dashboard_logout.Region = New Region(dashboard_logout)

        '그리기 모양(후에 지원)(노가다)

        '50,0  62,312

        For i = 1 To 8
            For q = 1 To 8
                'ctrlDict("uni" & i & "_" & q).Region()
            Next

        Next

    End Sub

#Region "Vars"
    'Setting Part
    Public init As Boolean 'For preventing LED Zero support Warning during first launch.
    Public setting_list_tmp(5) As String 'In the setting part
    Public settings(5) As String 'In the setting part

    'Pack Open Mode
    Public PackOpenMode = "reopen"

    Dim button_affected(9, 9) As String
    'LED on, record chain, x, y to button (like: c;x;y)
    'LED Off, if directly off, check if same chain and axis. If false, do not turnoff.
    Public ctrlDict As New Dictionary(Of String, Button)  'Button List (8 x 8)
    Public led As New ledReturn 'To get HTML Color Code

    Public soundfiles(9, 9, 9, 151) As String 'Chain, X, Y, MultiMapping => for sound path
    Public soundfiles_now(9, 9, 9) As Integer 'Chain, X, Y
    Public keysounds_max(9, 9, 9) As Integer 'Chain, X, Y
    Public soundLoop(9, 9, 9, 151) As Integer 'Chain, X, Y, Multimappin g => For support about Zero  loop number Sound
    Private cancelToken_Sound(9, 9, 9, 151) As Boolean

    Public ledfiles(9, 9, 9, 27) As String 'Chain, X, Y, MultiMapping => for LED path
    Public ledfiles_now(9, 9, 9) As String 'Chain, X, Y => Show now mapping
    Public ledfiles_max(9, 9, 9) As Integer
    Public ledfiles_loop(9, 9, 9, 27) As Integer
    Private cancelToken(9, 9, 9, 27) As Boolean


    'Pack Information
    Public ishaveLED As Boolean = True
    Dim chain As Integer = 1
    Dim Pack_author As String
    Dim Pack_title As String
    Dim Pack_chains As Integer
    '필요한 변수 선언
    Dim pack_bx, pack_by As Integer
    Dim pack_squarebtn, pack_landscape As String


    Public autoplay_stat As String 'Go Wait End
    Dim autoplay_length As Integer

    Public isSaved As Boolean 'is saved


    '''''info파일 에시'''''
    'title= - puzzle 
    'producerName=puzzle
    'buttonX=8
    'buttonY=8
    'chain=3
    'squareButton=true
    'landscape=true
#End Region

    Public Sub ElementLoader(parm As Object)
        isSaved = True
        ThreadPool.SetMaxThreads(64, 64)
        Me.BeginInvoke(Sub()
                           Me.Show()
                           Me.Hide()
                       End Sub)
        Dim tmp_parm() As String = parm.ToString.Split(";")
        Dim projectpath = tmp_parm(0)
        Dim projectType = tmp_parm(1)
        PackOpenMode = projectType
        Dim isErr As Boolean = False
        Me.Invoke(Sub()
                      frmStart.Enabled = False
                      ' Loadingfrm.Close()
                      Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                      Loadingfrm.Show()
                      Loadingfrm.Update()
                      Loadingfrm.workPgLabel.Text = "Initializing..."
                      Loadingfrm.Update()
                      Me.listChain.Items.Clear()
                  End Sub)



        ishaveLED = True

        Me.Invoke(Sub()
                      Me.AutoPlayBetaToolStripMenuItem.Enabled = False
                  End Sub)
        ReDim soundfiles(8, 8, 8, 151)
        For t1 = 0 To 8
            For t2 = 0 To 8
                For t3 = 0 To 8
                    For t4 = 0 To 150
                        Try
                            CloseSound(t1 & " " & t2 & " " & t3 & " " & t4)

                        Catch
                        End Try
                        soundLoop(t1, t2, t3, t4) = 1
                    Next

                Next

            Next
        Next



        ReDim soundfiles_now(9, 9, 9)
        ReDim keysounds_max(9, 9, 9)
        ReDim ledfiles_max(9, 9, 9)
        ReDim ledfiles_now(9, 9, 9)

        For t1 = 0 To 8
            For t2 = 0 To 8
                For t3 = 0 To 8
                    For t4 = 0 To 26
                        Try
                            ledfiles_loop(t1, t2, t3, t4) = 1

                        Catch
                        End Try

                    Next

                Next

            Next
        Next


        'Converted Sound
        If (tmp_parm.Count > 2) Then
            For Each filename In Directory.GetFiles("TmpSound\", "*")
                Try
                    My.Computer.FileSystem.CopyFile(filename, "Workspace\sounds\" & filename.Split("\")(filename.Split("\").Count - 1), True)
                Catch
                End Try
            Next


            Me.Invoke(Sub()
                          wavConvert.pbBar.Visible = False
                          wavConvert.lblStat.Text = "Ready"
                      End Sub)
        End If


        Me.Invoke(Sub()
                      Me.Enabled = False
                      Me.tbPackChains.Text = "1"
                      Me.tbPackDirInfo.Text = projectpath
                  End Sub)
        If (projectType = "reopen") Then
            Try
                Me.Invoke(Sub()
                              Loadingfrm.workPgLabel.Text = "Checking for Auto Play Existence..."
                              Loadingfrm.Update()
                          End Sub)
                If (My.Computer.FileSystem.FileExists("Workspace\autoPlay") = True) Then
                    Me.Invoke(Sub()
                                  Me.AutoPlayBetaToolStripMenuItem.Enabled = True
                                  Loadingfrm.workPgLabel.Text = "Auto Play Found! Continuing..."
                                  Loadingfrm.Update()
                              End Sub)
                Else
                    Me.Invoke(Sub()
                                  Loadingfrm.workPgLabel.Text = "Auto Play Not Found! Continuing..."
                                  Loadingfrm.Update()
                              End Sub)
                End If
                Me.Invoke(Sub()
                              Loadingfrm.workPgLabel.Text = "Stat: Reading info file"
                          End Sub)


                Me.Invoke(Sub()
                              Loadingfrm.workPgLabel.Text = "Stat: Reading Info file... => Counting and Setting..."
                          End Sub)




                Dim strTmp() As String
                Dim linesInfo As New List(Of String)(IO.File.ReadAllLines("Workspace\info"))
                linesInfo.RemoveAll(Function(s) s.Trim = "")
                Dim filereadbyline() As String = linesInfo.ToArray
                For index = 0 To filereadbyline.Count - 1
                    strTmp = Split(filereadbyline(index), "=")
                    If (strTmp(0) = "title") Then
                        Me.Invoke(Sub()
                                      Me.tbPackName.Text = strTmp(1)
                                  End Sub)
                        Pack_title = strTmp(1)
                    ElseIf (strTmp(0) = "producerName") Then
                        Me.Invoke(Sub()
                                      Me.tbPackAuthor.Text = strTmp(1)
                                  End Sub)
                        Pack_author = strTmp(1)
                    ElseIf (strTmp(0) = "buttonX") Then
                        pack_bx = strTmp(1)
                    ElseIf (strTmp(0) = "buttonY") Then
                        pack_by = strTmp(1)
                    ElseIf (strTmp(0) = "chain") Then
                        Pack_chains = strTmp(1)
                    ElseIf (strTmp(0) = "squareButton") Then
                        pack_squarebtn = strTmp(1)
                    ElseIf (strTmp(0) = "landscape") Then
                        pack_landscape = strTmp(1)

                    End If

                Next
                'SOUND
                Me.Invoke(Sub()
                              Loadingfrm.workPgLabel.Text = "Stat: Checking UniPack info Requirement.."
                              'Loadingfrm.Update()
                          End Sub)
                If (pack_bx <> 8 Or pack_by <> 8 Or pack_squarebtn <> "true" Or pack_landscape <> "true") Then
                    Throw New AggregateException("Not supported UniPack type! Only support 8 x 8 & Squarebutton & Landscape mode!")
                End If
                Me.Invoke(Sub()
                              Loadingfrm.workPgLabel.Text = "Stat: Loading Sounds... => Counting..."
                              'Loadingfrm.Update()
                          End Sub)
                Dim lines As New List(Of String)(IO.File.ReadAllLines("Workspace\keySound"))
                lines.RemoveAll(Function(s) s.Trim = "")
                Dim keysounds() As String = lines.ToArray
                Dim keysounds_tmp() As String
                Me.Invoke(Sub()
                              Loadingfrm.LoadingPg.Style = ProgressBarStyle.Blocks
                              Loadingfrm.LoadingPg.Maximum = keysounds.Length
                              Loadingfrm.LoadingPg.Value = 0
                          End Sub)
                For index = 0 To keysounds.Length - 1
                    Dim index_tmp = index
                    Me.Invoke(Sub()
                                  Loadingfrm.workPgLabel.Text = "Stat: Loading Sounds... => " & index_tmp & "/" & keysounds.Length
                                  ' Loadingfrm.Update()
                              End Sub)
                    keysounds_tmp = keysounds(index).Trim.Split(" ")
                    If (keysounds_tmp.Length = 5) Then
                        'Throw New AggregateException("Unsupported UniPack type: We don't support 5th parameter. (loop number)")
                        If (keysounds_tmp(0) > Pack_chains) Then
                            Throw New AggregateException("Bad chain number (bigger than maximum the number of chians  on Line " & (index + 1))
                        End If
                        Dim tmp As Integer = keysounds_max(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2))
                        If (My.Computer.FileSystem.FileExists("Workspace\sounds\" & keysounds_tmp(3)) = True) Then
                            soundfiles(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2), tmp) = keysounds_tmp(3) 'save sound name
                            soundLoop(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2), tmp) = keysounds_tmp(4) 'Set loop number

                            keysounds_max(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2)) += 1
                            Me.Invoke(Sub()
                                          AddSound(keysounds_tmp(0) & " " & keysounds_tmp(1) & " " & keysounds_tmp(2) & " " & tmp, "Workspace\sounds\" & keysounds_tmp(3))
                                      End Sub)
                        Else
                            Throw New AggregateException(keysounds_tmp(3) & " doesn't exists on Line " & (index + 1))
                            Exit For
                        End If
                    ElseIf (keysounds_tmp.Length = 4) Then
                        If (keysounds_tmp(0) > Pack_chains) Then
                            Throw New AggregateException("Bad chain number (bigger than maximum the number of chians  on Line " & (index + 1))
                        End If
                        Dim tmp As Integer = keysounds_max(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2))
                        If (My.Computer.FileSystem.FileExists("Workspace\sounds\" & keysounds_tmp(3)) = True) Then
                            soundfiles(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2), tmp) = keysounds_tmp(3)
                            soundLoop(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2), tmp) = 1 'Set loop number

                            keysounds_max(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2)) += 1
                            Me.Invoke(Sub()
                                          AddSound(keysounds_tmp(0) & " " & keysounds_tmp(1) & " " & keysounds_tmp(2) & " " & tmp, "Workspace\sounds\" & keysounds_tmp(3))
                                          'The last 1 menas it is normal sound (Do not need to stop the sound
                                      End Sub)
                        Else
                            Throw New AggregateException(keysounds_tmp(3) & " doesn't exists on Line " & (index + 1))
                            Exit For
                        End If
                    Else
                        Throw New AggregateException("Invaild keySound structure on Line " & index + 1)
                        Exit For
                    End If
                    Me.Invoke(Sub()
                                  Loadingfrm.LoadingPg.Value += 1
                              End Sub)

                Next
                Me.Invoke(Sub()
                              Me.tbPackChains.Text = Pack_chains
                          End Sub)
                For index = 1 To Pack_chains
                    Me.Invoke(Sub()
                                  Me.listChain.Items.Add(index.ToString)
                              End Sub)
                Next
            Catch
                MessageBox.Show("Error Occured! For stability, loading process will be terminated. Message:" & Err.Description, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Invoke(Sub()
                              frmStart.Show()

                              Loadingfrm.Close()
                              frmStart.Enabled = True
                              Me.Close()
                          End Sub)
                Exit Sub
            End Try

            Me.Invoke(Sub()
                          'NOW...LED!!
                          Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                          Loadingfrm.workPgLabel.Text = "Stat: Loading LED Data..."
                          Loadingfrm.Update()
                      End Sub)

            If (My.Computer.FileSystem.DirectoryExists("Workspace\keyLED")) Then
                ishaveLED = True
                Dim tmp2() As String
                Dim tmpint As Integer
                Dim files() As String
                Dim counter As Integer = 1
                files = Directory.GetFiles("Workspace\keyLED", "*", SearchOption.TopDirectoryOnly)
                Me.Invoke(Sub()
                              Loadingfrm.LoadingPg.Style = ProgressBarStyle.Blocks
                              Loadingfrm.LoadingPg.Maximum = files.Length
                              Loadingfrm.LoadingPg.Value = 0
                          End Sub)
                For Each FileName As String In files
                    Me.Invoke(Sub()
                                  Loadingfrm.workPgLabel.Text = "Stat: Loading LED Data... => " & counter & "/" & files.Length
                                  Loadingfrm.Update()
                              End Sub)
                    Try
                        tmp2 = FileName.Split("\")
                        tmpint = tmp2.Length
                        Dim pos() = tmp2(tmpint - 1).Split(" ")
                        counter += 1
                        Me.Invoke(Sub()
                                      Loadingfrm.LoadingPg.Value += 1
                                  End Sub)
                        ''''시작
                        If (pos(3) > 1) Then
                            'Throw New ArgumentException("We don't support multi-loop LED. (Not Multi-Map LED) We only support LED File such as 1 1 1 1, not 1 1 1 2 or 1 1 1 3.")
                        End If
                        If (pos.Length > 4) Then
                            Dim multiled As Integer
                            Select Case pos(4) 'Change to Int
                                Case "a"
                                    multiled = 0
                                Case "b"
                                    multiled = 1
                                Case "c"
                                    multiled = 2
                                Case "d"
                                    multiled = 3
                                Case "e"
                                    multiled = 4
                                Case "f"
                                    multiled = 5
                                Case "g"
                                    multiled = 6
                                Case "h"
                                    multiled = 7
                                Case "i"
                                    multiled = 8
                                Case "j"
                                    multiled = 9
                                Case "k"
                                    multiled = 10
                                Case "l"
                                    multiled = 11
                                Case "m"
                                    multiled = 12
                                Case "n"
                                    multiled = 13
                                Case "o"
                                    multiled = 14
                                Case "p"
                                    multiled = 15
                                Case "q"
                                    multiled = 16
                                Case "r"
                                    multiled = 17
                                Case "s"
                                    multiled = 18
                                Case "t"
                                    multiled = 19
                                Case "u"
                                    multiled = 20
                                Case "v"
                                    multiled = 21
                                Case "w"
                                    multiled = 22
                                Case "x"
                                    multiled = 23
                                Case "y"
                                    multiled = 24
                                Case "z"
                                    multiled = 25
                                Case Else
                                    Throw New ArgumentException("Not Invaild Multi-LED Character")
                            End Select
                            ledfiles(pos(0), pos(1), pos(2), ledfiles_max(pos(0), pos(1), pos(2))) = FileName
                            ledfiles_loop(pos(0), pos(1), pos(2), ledfiles_max(pos(0), pos(1), pos(2))) = pos(3)
                            ledfiles_max(pos(0), pos(1), pos(2)) += 1

                        Else
                            ledfiles(pos(0), pos(1), pos(2), ledfiles_max(pos(0), pos(1), pos(2))) = FileName
                            ledfiles_loop(pos(0), pos(1), pos(2), ledfiles_max(pos(0), pos(1), pos(2))) = pos(3)

                            ledfiles_max(pos(0), pos(1), pos(2)) += 1
                        End If

                        'Me.listAllSounds.Items.Add(tmp(tmpint - 1))


                        'Me.listAllSounds.Items.Add(FileName)
                    Catch ex As IndexOutOfRangeException
                        Dim r = MessageBox.Show("Sorry but there is something wrong on file " & FileName & ". Unitor can't determine its pad axis! This file is not loaded to Unitor. Do want to continue loading?", "Error Occured", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If (r = Forms.DialogResult.No) Then

                            Me.Invoke(Sub()
                                          frmStart.Show()
                                          Me.Close()
                                      End Sub)
                            Exit Sub
                        End If
                    Catch ex1 As ArgumentException
                        MessageBox.Show("We have some error! For stability, loading process will be terminated. Message: " & ErrorToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        Me.Invoke(Sub()
                                      frmStart.Show()
                                      Me.Close()
                                  End Sub)
                        Exit Sub
                    End Try
                Next
            Else
                ishaveLED = False
                Me.Invoke(Sub()
                              Loadingfrm.workPgLabel.Text = "LED Data Not Found. Finishing Project Loading..."
                              Loadingfrm.Update()
                          End Sub)
            End If


        Else
            ishaveLED = False 'LED 없음


            'Common File Stream Requirement



            Me.Invoke(Sub()
                          Me.listChain.Items.Add(1)
                          Me.tbPackAuthor.Text = "UniPackGUI Editor"
                          Me.tbPackChains.Text = "1"
                          Me.tbPackName.Text = "Hello World!"
                          Me.tbPackDirInfo.Text = projectpath
                          Loadingfrm.workPgLabel.Text = "Saving Initial project..."
                          MsgBox(projectpath)
                      End Sub)
            isSaved = True

            ZipFile.CreateFromDirectory("Workspace\", Me.tbPackDirInfo.Text, CompressionLevel.Fastest, False)

        End If
        If (isErr = True) Then
            Me.Invoke(Sub()
                          frmStart.Show()
                          Loadingfrm.Close()
                          Me.Enabled = True
                          Me.Close()
                      End Sub)
            Exit Sub
        End If

        Me.Invoke(Sub()
                      Loadingfrm.Close()
                      Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                      Me.Show()

                      frmStart.Close()
                  End Sub)
        chain = 1 '기본 체인 설정
        Me.Invoke(Sub()
                      Me.Enabled = True
                      Me.listChain.SelectedIndex = 0
                      Me.Text = Me.tbPackName.Text & " - Unitor v" & My.Application.Info.Version.ToString
                      frmStart.Enabled = True
                      Me.Enabled = True
                      If (ishaveLED = True) Then
                          Me.ledisableenable.Text = "Disable LED"
                      Else
                          Me.ledisableenable.Text = "Enable LED"
                      End If
                  End Sub)


        Exit Sub
    End Sub





#Region "X Code 1"

    Private Sub uni1_1_Click(sender As Object, e As EventArgs) Handles uni1_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 1 " & soundfiles_now(chain, 1, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;1")
                End If
                If (soundfiles_now(chain, 1, 1) + 1 >= keysounds_max(chain, 1, 1)) Then
                    soundfiles_now(chain, 1, 1) = 0
                Else
                    soundfiles_now(chain, 1, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_2_Click(sender As Object, e As EventArgs) Handles uni1_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 2 " & soundfiles_now(chain, 1, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;2")
                End If
                If (soundfiles_now(chain, 1, 2) + 1 >= keysounds_max(chain, 1, 2)) Then
                    soundfiles_now(chain, 1, 2) = 0
                Else
                    soundfiles_now(chain, 1, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_3_Click(sender As Object, e As EventArgs) Handles uni1_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 3 " & soundfiles_now(chain, 1, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;3")
                End If
                If (soundfiles_now(chain, 1, 3) + 1 >= keysounds_max(chain, 1, 3)) Then
                    soundfiles_now(chain, 1, 3) = 0
                Else
                    soundfiles_now(chain, 1, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_4_Click(sender As Object, e As EventArgs) Handles uni1_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 4 " & soundfiles_now(chain, 1, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;4")
                End If
                If (soundfiles_now(chain, 1, 4) + 1 >= keysounds_max(chain, 1, 4)) Then
                    soundfiles_now(chain, 1, 4) = 0
                Else
                    soundfiles_now(chain, 1, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_5_Click(sender As Object, e As EventArgs) Handles uni1_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 5 " & soundfiles_now(chain, 1, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;5")
                End If
                If (soundfiles_now(chain, 1, 5) + 1 >= keysounds_max(chain, 1, 5)) Then
                    soundfiles_now(chain, 1, 5) = 0
                Else
                    soundfiles_now(chain, 1, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_6_Click(sender As Object, e As EventArgs) Handles uni1_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 6 " & soundfiles_now(chain, 1, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;6")
                End If
                If (soundfiles_now(chain, 1, 6) + 1 >= keysounds_max(chain, 1, 6)) Then
                    soundfiles_now(chain, 1, 6) = 0
                Else
                    soundfiles_now(chain, 1, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_7_Click(sender As Object, e As EventArgs) Handles uni1_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 7 " & soundfiles_now(chain, 1, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;7")
                End If
                If (soundfiles_now(chain, 1, 7) + 1 >= keysounds_max(chain, 1, 7)) Then
                    soundfiles_now(chain, 1, 7) = 0
                Else
                    soundfiles_now(chain, 1, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni1_8_Click(sender As Object, e As EventArgs) Handles uni1_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 1 8 " & soundfiles_now(chain, 1, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";1;8")
                End If
                If (soundfiles_now(chain, 1, 8) + 1 >= keysounds_max(chain, 1, 8)) Then
                    soundfiles_now(chain, 1, 8) = 0
                Else
                    soundfiles_now(chain, 1, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 1, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 1, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 2"

    Private Sub uni2_1_Click(sender As Object, e As EventArgs) Handles uni2_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 1 " & soundfiles_now(chain, 2, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;1")
                End If
                If (soundfiles_now(chain, 2, 1) + 1 >= keysounds_max(chain, 2, 1)) Then
                    soundfiles_now(chain, 2, 1) = 0
                Else
                    soundfiles_now(chain, 2, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_2_Click(sender As Object, e As EventArgs) Handles uni2_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 2 " & soundfiles_now(chain, 2, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;2")
                End If
                If (soundfiles_now(chain, 2, 2) + 1 >= keysounds_max(chain, 2, 2)) Then
                    soundfiles_now(chain, 2, 2) = 0
                Else
                    soundfiles_now(chain, 2, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_3_Click(sender As Object, e As EventArgs) Handles uni2_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 3 " & soundfiles_now(chain, 2, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;3")
                End If
                If (soundfiles_now(chain, 2, 3) + 1 >= keysounds_max(chain, 2, 3)) Then
                    soundfiles_now(chain, 2, 3) = 0
                Else
                    soundfiles_now(chain, 2, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_4_Click(sender As Object, e As EventArgs) Handles uni2_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 4 " & soundfiles_now(chain, 2, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;4")
                End If
                If (soundfiles_now(chain, 2, 4) + 1 >= keysounds_max(chain, 2, 4)) Then
                    soundfiles_now(chain, 2, 4) = 0
                Else
                    soundfiles_now(chain, 2, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_5_Click(sender As Object, e As EventArgs) Handles uni2_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 5 " & soundfiles_now(chain, 2, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;5")
                End If
                If (soundfiles_now(chain, 2, 5) + 1 >= keysounds_max(chain, 2, 5)) Then
                    soundfiles_now(chain, 2, 5) = 0
                Else
                    soundfiles_now(chain, 2, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_6_Click(sender As Object, e As EventArgs) Handles uni2_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 6 " & soundfiles_now(chain, 2, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;6")
                End If
                If (soundfiles_now(chain, 2, 6) + 1 >= keysounds_max(chain, 2, 6)) Then
                    soundfiles_now(chain, 2, 6) = 0
                Else
                    soundfiles_now(chain, 2, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_7_Click(sender As Object, e As EventArgs) Handles uni2_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 7 " & soundfiles_now(chain, 2, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;7")
                End If
                If (soundfiles_now(chain, 2, 7) + 1 >= keysounds_max(chain, 2, 7)) Then
                    soundfiles_now(chain, 2, 7) = 0
                Else
                    soundfiles_now(chain, 2, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni2_8_Click(sender As Object, e As EventArgs) Handles uni2_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 2 8 " & soundfiles_now(chain, 2, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";2;8")
                End If
                If (soundfiles_now(chain, 2, 8) + 1 >= keysounds_max(chain, 2, 8)) Then
                    soundfiles_now(chain, 2, 8) = 0
                Else
                    soundfiles_now(chain, 2, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 2, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 2, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 3"

    Private Sub uni3_1_Click(sender As Object, e As EventArgs) Handles uni3_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 1 " & soundfiles_now(chain, 3, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;1")
                End If
                If (soundfiles_now(chain, 3, 1) + 1 >= keysounds_max(chain, 3, 1)) Then
                    soundfiles_now(chain, 3, 1) = 0
                Else
                    soundfiles_now(chain, 3, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_2_Click(sender As Object, e As EventArgs) Handles uni3_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 2 " & soundfiles_now(chain, 3, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;2")
                End If
                If (soundfiles_now(chain, 3, 2) + 1 >= keysounds_max(chain, 3, 2)) Then
                    soundfiles_now(chain, 3, 2) = 0
                Else
                    soundfiles_now(chain, 3, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_3_Click(sender As Object, e As EventArgs) Handles uni3_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 3 " & soundfiles_now(chain, 3, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;3")
                End If
                If (soundfiles_now(chain, 3, 3) + 1 >= keysounds_max(chain, 3, 3)) Then
                    soundfiles_now(chain, 3, 3) = 0
                Else
                    soundfiles_now(chain, 3, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_4_Click(sender As Object, e As EventArgs) Handles uni3_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then

                PlaySound(chain & " 3 4 " & soundfiles_now(chain, 3, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;4")
                End If
                If (soundfiles_now(chain, 3, 4) + 1 >= keysounds_max(chain, 3, 4)) Then
                    soundfiles_now(chain, 3, 4) = 0
                Else
                    soundfiles_now(chain, 3, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_5_Click(sender As Object, e As EventArgs) Handles uni3_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 5 " & soundfiles_now(chain, 3, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;5")
                End If
                If (soundfiles_now(chain, 3, 5) + 1 >= keysounds_max(chain, 3, 5)) Then
                    soundfiles_now(chain, 3, 5) = 0
                Else
                    soundfiles_now(chain, 3, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_6_Click(sender As Object, e As EventArgs) Handles uni3_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 6 " & soundfiles_now(chain, 3, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;6")
                End If
                If (soundfiles_now(chain, 3, 6) + 1 >= keysounds_max(chain, 3, 6)) Then
                    soundfiles_now(chain, 3, 6) = 0
                Else
                    soundfiles_now(chain, 3, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_7_Click(sender As Object, e As EventArgs) Handles uni3_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 7 " & soundfiles_now(chain, 3, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;7")
                End If
                If (soundfiles_now(chain, 3, 7) + 1 >= keysounds_max(chain, 3, 7)) Then
                    soundfiles_now(chain, 3, 7) = 0
                Else
                    soundfiles_now(chain, 3, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni3_8_Click(sender As Object, e As EventArgs) Handles uni3_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 3 8 " & soundfiles_now(chain, 3, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";3;8")
                End If
                If (soundfiles_now(chain, 3, 8) + 1 >= keysounds_max(chain, 3, 8)) Then
                    soundfiles_now(chain, 3, 8) = 0
                Else
                    soundfiles_now(chain, 3, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 3, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 3, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 4"

    Private Sub uni4_1_Click(sender As Object, e As EventArgs) Handles uni4_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 1 " & soundfiles_now(chain, 4, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;1")
                End If
                If (soundfiles_now(chain, 4, 1) + 1 >= keysounds_max(chain, 4, 1)) Then
                    soundfiles_now(chain, 4, 1) = 0
                Else
                    soundfiles_now(chain, 4, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_2_Click(sender As Object, e As EventArgs) Handles uni4_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 2 " & soundfiles_now(chain, 4, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;2")
                End If
                If (soundfiles_now(chain, 4, 2) + 1 >= keysounds_max(chain, 4, 2)) Then
                    soundfiles_now(chain, 4, 2) = 0
                Else
                    soundfiles_now(chain, 4, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_3_Click(sender As Object, e As EventArgs) Handles uni4_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 3 " & soundfiles_now(chain, 4, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;3")
                End If
                If (soundfiles_now(chain, 4, 3) + 1 >= keysounds_max(chain, 4, 3)) Then
                    soundfiles_now(chain, 4, 3) = 0
                Else
                    soundfiles_now(chain, 4, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_4_Click(sender As Object, e As EventArgs) Handles uni4_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 4 " & soundfiles_now(chain, 4, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;4")
                End If
                If (soundfiles_now(chain, 4, 4) + 1 >= keysounds_max(chain, 4, 4)) Then
                    soundfiles_now(chain, 4, 4) = 0
                Else
                    soundfiles_now(chain, 4, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_5_Click(sender As Object, e As EventArgs) Handles uni4_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 5 " & soundfiles_now(chain, 4, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;5")
                End If
                If (soundfiles_now(chain, 4, 5) + 1 >= keysounds_max(chain, 4, 5)) Then
                    soundfiles_now(chain, 4, 5) = 0
                Else
                    soundfiles_now(chain, 4, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_6_Click(sender As Object, e As EventArgs) Handles uni4_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 6 " & soundfiles_now(chain, 4, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;6")
                End If
                If (soundfiles_now(chain, 4, 6) + 1 >= keysounds_max(chain, 4, 6)) Then
                    soundfiles_now(chain, 4, 6) = 0
                Else
                    soundfiles_now(chain, 4, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_7_Click(sender As Object, e As EventArgs) Handles uni4_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 7 " & soundfiles_now(chain, 4, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;7")
                End If
                If (soundfiles_now(chain, 4, 7) + 1 >= keysounds_max(chain, 4, 7)) Then
                    soundfiles_now(chain, 4, 7) = 0
                Else
                    soundfiles_now(chain, 4, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni4_8_Click(sender As Object, e As EventArgs) Handles uni4_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 4 8 " & soundfiles_now(chain, 4, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";4;8")
                End If
                If (soundfiles_now(chain, 4, 8) + 1 >= keysounds_max(chain, 4, 8)) Then
                    soundfiles_now(chain, 4, 8) = 0
                Else
                    soundfiles_now(chain, 4, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 4, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 4, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 5"

    Private Sub uni5_1_Click(sender As Object, e As EventArgs) Handles uni5_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 1 " & soundfiles_now(chain, 5, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;1")
                End If
                If (soundfiles_now(chain, 5, 1) + 1 >= keysounds_max(chain, 5, 1)) Then
                    soundfiles_now(chain, 5, 1) = 0
                Else
                    soundfiles_now(chain, 5, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_2_Click(sender As Object, e As EventArgs) Handles uni5_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 2 " & soundfiles_now(chain, 5, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;2")
                End If
                If (soundfiles_now(chain, 5, 2) + 1 >= keysounds_max(chain, 5, 2)) Then
                    soundfiles_now(chain, 5, 2) = 0
                Else
                    soundfiles_now(chain, 5, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_3_Click(sender As Object, e As EventArgs) Handles uni5_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 3 " & soundfiles_now(chain, 5, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;3")
                End If
                If (soundfiles_now(chain, 5, 3) + 1 >= keysounds_max(chain, 5, 3)) Then
                    soundfiles_now(chain, 5, 3) = 0
                Else
                    soundfiles_now(chain, 5, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_4_Click(sender As Object, e As EventArgs) Handles uni5_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 4 " & soundfiles_now(chain, 5, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;4")
                End If
                If (soundfiles_now(chain, 5, 4) + 1 >= keysounds_max(chain, 5, 4)) Then
                    soundfiles_now(chain, 5, 4) = 0
                Else
                    soundfiles_now(chain, 5, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_5_Click(sender As Object, e As EventArgs) Handles uni5_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 5 " & soundfiles_now(chain, 5, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;5")
                End If
                If (soundfiles_now(chain, 5, 5) + 1 >= keysounds_max(chain, 5, 5)) Then
                    soundfiles_now(chain, 5, 5) = 0
                Else
                    soundfiles_now(chain, 5, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_6_Click(sender As Object, e As EventArgs) Handles uni5_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 6 " & soundfiles_now(chain, 5, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;6")
                End If
                If (soundfiles_now(chain, 5, 6) + 1 >= keysounds_max(chain, 5, 6)) Then
                    soundfiles_now(chain, 5, 6) = 0
                Else
                    soundfiles_now(chain, 5, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_7_Click(sender As Object, e As EventArgs) Handles uni5_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 7 " & soundfiles_now(chain, 5, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;7")
                End If
                If (soundfiles_now(chain, 5, 7) + 1 >= keysounds_max(chain, 5, 7)) Then
                    soundfiles_now(chain, 5, 7) = 0
                Else
                    soundfiles_now(chain, 5, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni5_8_Click(sender As Object, e As EventArgs) Handles uni5_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 5 8 " & soundfiles_now(chain, 5, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";5;8")
                End If
                If (soundfiles_now(chain, 5, 8) + 1 >= keysounds_max(chain, 5, 8)) Then
                    soundfiles_now(chain, 5, 8) = 0
                Else
                    soundfiles_now(chain, 5, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 5, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 5, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 6"

    Private Sub uni6_1_Click(sender As Object, e As EventArgs) Handles uni6_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 1 " & soundfiles_now(chain, 6, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;1")
                End If
                If (soundfiles_now(chain, 6, 1) + 1 >= keysounds_max(chain, 6, 1)) Then
                    soundfiles_now(chain, 6, 1) = 0
                Else
                    soundfiles_now(chain, 6, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_2_Click(sender As Object, e As EventArgs) Handles uni6_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 2 " & soundfiles_now(chain, 6, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;2")
                End If
                If (soundfiles_now(chain, 6, 2) + 1 >= keysounds_max(chain, 6, 2)) Then
                    soundfiles_now(chain, 6, 2) = 0
                Else
                    soundfiles_now(chain, 6, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_3_Click(sender As Object, e As EventArgs) Handles uni6_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 3 " & soundfiles_now(chain, 6, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;3")
                End If
                If (soundfiles_now(chain, 6, 3) + 1 >= keysounds_max(chain, 6, 3)) Then
                    soundfiles_now(chain, 6, 3) = 0
                Else
                    soundfiles_now(chain, 6, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_4_Click(sender As Object, e As EventArgs) Handles uni6_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 4 " & soundfiles_now(chain, 6, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;4")
                End If
                If (soundfiles_now(chain, 6, 4) + 1 >= keysounds_max(chain, 6, 4)) Then
                    soundfiles_now(chain, 6, 4) = 0
                Else
                    soundfiles_now(chain, 6, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_5_Click(sender As Object, e As EventArgs) Handles uni6_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 5 " & soundfiles_now(chain, 6, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;5")
                End If
                If (soundfiles_now(chain, 6, 5) + 1 >= keysounds_max(chain, 6, 5)) Then
                    soundfiles_now(chain, 6, 5) = 0
                Else
                    soundfiles_now(chain, 6, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_6_Click(sender As Object, e As EventArgs) Handles uni6_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 6 " & soundfiles_now(chain, 6, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;6")
                End If
                If (soundfiles_now(chain, 6, 6) + 1 >= keysounds_max(chain, 6, 6)) Then
                    soundfiles_now(chain, 6, 6) = 0
                Else
                    soundfiles_now(chain, 6, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_7_Click(sender As Object, e As EventArgs) Handles uni6_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 7 " & soundfiles_now(chain, 6, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;7")
                End If
                If (soundfiles_now(chain, 6, 7) + 1 >= keysounds_max(chain, 6, 7)) Then
                    soundfiles_now(chain, 6, 7) = 0
                Else
                    soundfiles_now(chain, 6, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni6_8_Click(sender As Object, e As EventArgs) Handles uni6_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 6 8 " & soundfiles_now(chain, 6, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";6;8")
                End If
                If (soundfiles_now(chain, 6, 8) + 1 >= keysounds_max(chain, 6, 8)) Then
                    soundfiles_now(chain, 6, 8) = 0
                Else
                    soundfiles_now(chain, 6, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 6, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 6, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 7"

    Private Sub uni7_1_Click(sender As Object, e As EventArgs) Handles uni7_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 1 " & soundfiles_now(chain, 7, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;1")
                End If
                If (soundfiles_now(chain, 7, 1) + 1 >= keysounds_max(chain, 7, 1)) Then
                    soundfiles_now(chain, 7, 1) = 0
                Else
                    soundfiles_now(chain, 7, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_2_Click(sender As Object, e As EventArgs) Handles uni7_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 2 " & soundfiles_now(chain, 7, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;2")
                End If
                If (soundfiles_now(chain, 7, 2) + 1 >= keysounds_max(chain, 7, 2)) Then
                    soundfiles_now(chain, 7, 2) = 0
                Else
                    soundfiles_now(chain, 7, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_3_Click(sender As Object, e As EventArgs) Handles uni7_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 3 " & soundfiles_now(chain, 7, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;3")
                End If
                If (soundfiles_now(chain, 7, 3) + 1 >= keysounds_max(chain, 7, 3)) Then
                    soundfiles_now(chain, 7, 3) = 0
                Else
                    soundfiles_now(chain, 7, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_4_Click(sender As Object, e As EventArgs) Handles uni7_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 4 " & soundfiles_now(chain, 7, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;4")
                End If
                If (soundfiles_now(chain, 7, 4) + 1 >= keysounds_max(chain, 7, 4)) Then
                    soundfiles_now(chain, 7, 4) = 0
                Else
                    soundfiles_now(chain, 7, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_5_Click(sender As Object, e As EventArgs) Handles uni7_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 5 " & soundfiles_now(chain, 7, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;5")
                End If
                If (soundfiles_now(chain, 7, 5) + 1 >= keysounds_max(chain, 7, 5)) Then
                    soundfiles_now(chain, 7, 5) = 0
                Else
                    soundfiles_now(chain, 7, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_6_Click(sender As Object, e As EventArgs) Handles uni7_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 6 " & soundfiles_now(chain, 7, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;6")
                End If
                If (soundfiles_now(chain, 7, 6) + 1 >= keysounds_max(chain, 7, 6)) Then
                    soundfiles_now(chain, 7, 6) = 0
                Else
                    soundfiles_now(chain, 7, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_7_Click(sender As Object, e As EventArgs) Handles uni7_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 7 " & soundfiles_now(chain, 7, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;7")
                End If
                If (soundfiles_now(chain, 7, 7) + 1 >= keysounds_max(chain, 7, 7)) Then
                    soundfiles_now(chain, 7, 7) = 0
                Else
                    soundfiles_now(chain, 7, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni7_8_Click(sender As Object, e As EventArgs) Handles uni7_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 7 8 " & soundfiles_now(chain, 7, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";7;8")
                End If
                If (soundfiles_now(chain, 7, 8) + 1 >= keysounds_max(chain, 7, 8)) Then
                    soundfiles_now(chain, 7, 8) = 0
                Else
                    soundfiles_now(chain, 7, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 7, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 7, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "X Code 8"

    Private Sub uni8_1_Click(sender As Object, e As EventArgs) Handles uni8_1.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 1 " & soundfiles_now(chain, 8, 1))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;1")
                End If
                If (soundfiles_now(chain, 8, 1) + 1 >= keysounds_max(chain, 8, 1)) Then
                    soundfiles_now(chain, 8, 1) = 0
                Else
                    soundfiles_now(chain, 8, 1) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 1)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 1)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_2_Click(sender As Object, e As EventArgs) Handles uni8_2.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 2 " & soundfiles_now(chain, 8, 2))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;2")
                End If
                If (soundfiles_now(chain, 8, 2) + 1 >= keysounds_max(chain, 8, 2)) Then
                    soundfiles_now(chain, 8, 2) = 0
                Else
                    soundfiles_now(chain, 8, 2) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 2)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 2)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_3_Click(sender As Object, e As EventArgs) Handles uni8_3.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 3 " & soundfiles_now(chain, 8, 3))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;3")
                End If
                If (soundfiles_now(chain, 8, 3) + 1 >= keysounds_max(chain, 8, 3)) Then
                    soundfiles_now(chain, 8, 3) = 0
                Else
                    soundfiles_now(chain, 8, 3) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 3)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 3)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_4_Click(sender As Object, e As EventArgs) Handles uni8_4.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 4 " & soundfiles_now(chain, 8, 4))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;4")
                End If
                If (soundfiles_now(chain, 8, 4) + 1 >= keysounds_max(chain, 8, 4)) Then
                    soundfiles_now(chain, 8, 4) = 0
                Else
                    soundfiles_now(chain, 8, 4) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 4)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 4)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_5_Click(sender As Object, e As EventArgs) Handles uni8_5.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 5 " & soundfiles_now(chain, 8, 5))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;5")
                End If
                If (soundfiles_now(chain, 8, 5) + 1 >= keysounds_max(chain, 8, 5)) Then
                    soundfiles_now(chain, 8, 5) = 0
                Else
                    soundfiles_now(chain, 8, 5) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 5)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 5)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_6_Click(sender As Object, e As EventArgs) Handles uni8_6.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 6 " & soundfiles_now(chain, 8, 6))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;6")
                End If
                If (soundfiles_now(chain, 8, 6) + 1 >= keysounds_max(chain, 8, 6)) Then
                    soundfiles_now(chain, 8, 6) = 0
                Else
                    soundfiles_now(chain, 8, 6) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 6)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 6)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_7_Click(sender As Object, e As EventArgs) Handles uni8_7.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 7 " & soundfiles_now(chain, 8, 7))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;7")
                End If
                If (soundfiles_now(chain, 8, 7) + 1 >= keysounds_max(chain, 8, 7)) Then
                    soundfiles_now(chain, 8, 7) = 0
                Else
                    soundfiles_now(chain, 8, 7) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 7)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 7)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub

    Private Sub uni8_8_Click(sender As Object, e As EventArgs) Handles uni8_8.MouseDown
        Try
            If (rbPlaymode.Checked = True) Then
                PlaySound(chain & " 8 8 " & soundfiles_now(chain, 8, 8))
                If (ishaveLED = True) Then
                    ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";8;8")
                End If
                If (soundfiles_now(chain, 8, 8) + 1 >= keysounds_max(chain, 8, 8)) Then
                    soundfiles_now(chain, 8, 8) = 0
                Else
                    soundfiles_now(chain, 8, 8) += 1
                End If
            ElseIf (rblededit.Checked = True) Then
                frmLED.LoadLED(chain, 8, 8)
                frmLED.ShowDialog()
            Else
                editsound.soundLoad(chain, 8, 8)
                editsound.ShowDialog()
            End If
        Catch
        End Try
    End Sub
#End Region
    '체인 변경
    Private Sub listChain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listChain.SelectedIndexChanged
        chain = Me.listChain.SelectedItem

        For t3 = 0 To 8
            For t4 = 0 To 8
                soundfiles_now(chain, t3, t4) = 0
                ledfiles_now(chain, t3, t4) = 0
            Next
        Next


    End Sub

    Private Sub btnSavePackInfo_Click(sender As Object, e As EventArgs) Handles btnSavePackInfo.Click
        Me.labelInfSave.Visible = True
        Me.groupUniPackInfo.Enabled = False

        Me.tbPackName.Text.TrimEnd() '공백이 남으면 오류가 발생한다 카더라 (후행 공백)
        Me.tbPackAuthor.Text.TrimEnd()

        Dim path As String = My.Application.Info.DirectoryPath & "\Workspace\info"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(vbNewLine & "title=" & tbPackName.Text.TrimEnd & vbNewLine & "buttonX=8" & vbNewLine & "buttonY=8" & vbNewLine & "producerName=" & tbPackAuthor.Text.TrimEnd & vbNewLine & "chain=" & listChain.Items.Count & vbNewLine & "squareButton=true" & vbNewLine & "landscape=true")
        fs.Write(info, 0, info.Length)
        fs.Close()
        Me.labelInfSave.Visible = False
        Me.groupUniPackInfo.Enabled = True
        Me.Text = Me.tbPackName.Text.Trim & " - Unitor v" & My.Application.Info.Version.ToString
        Me.tbPackName.Text.Trim()
    End Sub



    Private Sub SaveProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProjectToolStripMenuItem.Click
        Try
            If (My.Computer.FileSystem.FileExists(Me.tbPackDirInfo.Text) = True) Then
                My.Computer.FileSystem.DeleteFile(Me.tbPackDirInfo.Text)
            End If
            Dim streams As String = ""
            Loadingfrm.Show()
            Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
            Me.Enabled = False

            For i = 1 To Pack_chains
                For q = 1 To 8
                    For p = 1 To 8
                        For k = 0 To keysounds_max(i, q, p) - 1

                            streams = streams & i & " " & q & " " & p & " " & soundfiles(i, q, p, k) & vbNewLine

                        Next

                    Next

                Next
                streams = streams & vbNewLine
            Next
            Dim path As String = "Workspace/keySound"

            ' Create or overwrite the file.
            Dim fs As FileStream = File.Create(path)

            ' Add text to the file.
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(streams)
            fs.Write(info, 0, info.Length)
            fs.Close()



            Loadingfrm.workPgLabel.Text = "Zipping (Releasing) UniPack..."
            Loadingfrm.Update()
            'Dim pHelp As New ProcessStartInfo
            'pHelp.FileName = "7z.exe"
            'pHelp.Arguments = ""
            'pHelp.UseShellExecute = True
            'pHelp.WindowStyle = ProcessWindowStyle.Normal
            'Dim proc As Process = Process.Start(pHelp)
            ZipFile.CreateFromDirectory("Workspace/", Me.tbPackDirInfo.Text, CompressionLevel.Fastest, False)
        Catch ex As Exception
            MessageBox.Show("There was a problem creating project file. Error message from system: " & ex.Message, "Project Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Enabled = True
        Loadingfrm.Close()
        isSaved = True
    End Sub

    Private Sub SaveProjectAnotherNameToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim dlr = Me.saveAnothername.ShowDialog()
        If (dlr <> DialogResult.Cancel) Then '<>는 부정을 나타냄. 즉 대화상자 결과가 취소 버튼 클릭이 아닐때 조건문 성립
            Try
                If (My.Computer.FileSystem.FileExists(Me.saveAnothername.FileName) = True) Then
                    My.Computer.FileSystem.DeleteFile(Me.saveAnothername.FileName)
                End If
                Dim streams As String = ""
                Loadingfrm.Show()
                Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                Me.Enabled = False

                For i = 1 To Pack_chains
                    For q = 1 To 8
                        For p = 1 To 8
                            For k = 0 To keysounds_max(i, q, p) - 1
                                streams = streams & i & " " & q & " " & p & " " & soundfiles(i, q, p, k) & vbNewLine

                            Next

                        Next

                    Next

                Next
                Dim path As String = "Workspace/keySound"

                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(path)

                ' Add text to the file.
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(streams)
                fs.Write(info, 0, info.Length)
                fs.Close()



                Loadingfrm.workPgLabel.Text = "Zipping (Releasing) UniPack..."
                Loadingfrm.Update()
                ZipFile.CreateFromDirectory("Workspace/", Me.saveAnothername.FileName, CompressionLevel.Fastest, False)
            Catch ex As Exception
                MessageBox.Show("There was a problem creating project file. Error message from system: " & ex.Message, "Project Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Me.Enabled = True
            Loadingfrm.Close()
        End If
    End Sub

    Private Sub DeleteProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProjectToolStripMenuItem.Click
        Dim ans = MessageBox.Show("Are you sure? Do want to delete your project?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If (ans = Windows.Forms.DialogResult.Yes) Then
            Try
                Loadingfrm.Show()
                Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                Me.Enabled = False
                Loadingfrm.workPgLabel.Text = "Deleting your project... :("
                Loadingfrm.Update()
                My.Computer.FileSystem.DeleteFile(Me.tbPackDirInfo.Text)
                'My.Computer.FileSystem.DeleteDirectory("Workspace\", FileIO.DeleteDirectoryOption.DeleteAllContents)

                'My.Computer.FileSystem.CreateDirectory("Workspace")
                Me.Enabled = True
                Loadingfrm.Close()
                MessageBox.Show("It's time to say goodbye to your project. Your project has been completely deleted. We need to flush the project. We will back to start menu.", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmStart.Show()
                Me.Close()
            Catch ex As Exception

                MessageBox.Show("Error occured while deleting project. Error message: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Me.listChain.Items.Count + 1 <= 8) Then
            Me.listChain.Items.Add(Me.listChain.Items.Count + 1)
            Me.tbPackChains.Text = Me.listChain.Items.Count
            Pack_chains = Me.listChain.Items.Count
        Else
            MessageBox.Show("You exceed maximum amount of chains! (8)", "Chain level exceed", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Me.listChain.Items.Count = 1) Then
            MessageBox.Show("Must at least 1 chain!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            Dim tmp As Integer = Me.listChain.SelectedIndex
            Me.listChain.Items.Remove(Me.listChain.SelectedItem)
            Me.tbPackChains.Text = Me.listChain.Items.Count
            Pack_chains = Me.listChain.Items.Count
            Me.listChain.SelectedIndex = 0
            For index = 0 To Me.listChain.Items.Count - 1
                Me.listChain.Items.Insert(index, index + 1)
                Me.listChain.Items.RemoveAt(index + 1)
            Next

        Catch
        End Try
    End Sub

    Private Sub SoundsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoundsToolStripMenuItem.Click
        editsound.soundLoad(0, 0, 0)
        editsound.ShowDialog()
        Dim t As New Thread(AddressOf LEDHandler)
        t.Start(chain & ";" & 1 & ";" & 1)

    End Sub
    'ByVal chain As Integer, ByVal xcode As Integer, ByVal ycode As Integer
    Private Sub LEDHandler(ByVal data As Object)

        Dim ifZeroLoopWorked As Boolean = False 'check if led file that loop number is 0 finished all task
        Dim turnOffDict As New List(Of String) 'Add button turned on

        Try


            'Dim counter As Integer = ledfiles_now(chain, xcode, ycode)
            Dim spliter_parm() As String = data.ToString.Split(";")
            Dim chain As Integer = spliter_parm(0)
            Dim xcode As Integer = spliter_parm(1)
            Dim ycode As Integer = spliter_parm(2)

            'Initialize Cancel Token
            cancelToken(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode)) = False

            'Read LED files
            Dim Lines() As String = IO.File.ReadAllLines(ledfiles(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode)))

            Dim sp() As String
            Dim spliter_tmp() As String = ledfiles(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode)).Split("\")
            Dim spliter_name() As String = spliter_tmp(spliter_tmp.Length - 1).Split(" ")

            If (ledfiles_now(chain, xcode, ycode) + 1 >= ledfiles_max(chain, xcode, ycode)) Then
                ledfiles_now(chain, xcode, ycode) = 0
            Else
                ledfiles_now(chain, xcode, ycode) += 1
            End If

            If (spliter_name(3) > 0) Then
                For loopnum As Integer = 1 To ledfiles_loop(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode))
                    'Perform script
                    For i = 0 To Lines.Length - 1
                        Try
                            sp = Lines(i).Split(" ")
                            If (sp(0) = "o" Or sp(0) = "on") Then

                                If (sp(3) = "a" Or sp(3) = "auto") Then
                                    sp(3) = sp(4)
                                    sp(3) = led.returnLED(sp(3))
                                End If

                                Me.Invoke(Sub()
                                              Try
                                                  Me.ctrlDict(sp(1) & sp(2)).BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                                  If (sp.Length = 5 And sp(4) = 0) Then

                                                      If (DebugTable.cblogInfo.Checked = True) Then
                                                          DebugTable.listLog.Items.Add(New ListViewItem({"Info", "Succeed to initialize button LED which code is " & sp(1) & ";" & sp(2) & ", which was turned on by " & button_affected(sp(1), sp(2)) & "."}))
                                                          button_affected(sp(1), sp(2)) = ""
                                                      End If
                                                  Else
                                                      button_affected(sp(1), sp(2)) = chain & ";" & xcode & ";" & ycode
                                                  End If
                                              Catch
                                              End Try
                                          End Sub)


                            ElseIf (sp(0) = "f" Or sp(0) = "off") Then
                                Me.Invoke(Sub()
                                              Try
                                                  If (button_affected(sp(1), sp(2)) = chain & ";" & xcode & ";" & ycode Or button_affected(sp(1), sp(2)) = "") Then
                                                      Me.ctrlDict(sp(1) & sp(2)).BackColor = Color.Gray
                                                  Else
                                                      'Not turned off by original button.
                                                      DebugTable.listLog.Items.Add(New ListViewItem({"Warning", "Tried to turn off LED of button code " & sp(1) & ";" & sp(2) & ", which was turned on by " & button_affected(sp(1), sp(2)) & " but not allowed."}))

                                                  End If
                                              Catch
                                              End Try
                                          End Sub)

                            ElseIf (sp(0) = "d" Or sp(0) = "delay") Then
                                Thread.Sleep(sp(1))
                            End If
                        Catch
                        End Try
                    Next
                Next
            Else
                If (settings(0) = 1) Then 'When Full supprot for LED which loop number is 0
                    'Support for Un-Pressing the Button

                    Try
                        For i = 0 To Lines.Length - 1
                            If (cancelToken(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode)) = True) Then
                                Throw New OperationCanceledException
                            End If

                            sp = Lines(i).Split(" ")
                            If (sp(0) = "o" Or sp(0) = "on") Then
                                turnOffDict.Add(sp(1) & sp(2))
                                If (sp(3) = "a" Or sp(3) = "auto") Then
                                    sp(3) = sp(4)
                                    sp(3) = led.returnLED(sp(3))
                                End If
                                Me.Invoke(Sub()
                                              Me.ctrlDict(sp(1) & sp(2)).BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                          End Sub)
                            ElseIf (sp(0) = "f" Or sp(0) = "off") Then
                                Me.Invoke(Sub()
                                              Try
                                                  ctrlDict(sp(1) & sp(2)).BackColor = Color.Gray
                                              Catch
                                              End Try
                                          End Sub)

                            ElseIf (sp(0) = "d" Or sp(0) = "delay") Then
                                For d_index As Integer = 1 To sp(1)
                                    If (cancelToken(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode)) = True) Then
                                        Throw New OperationCanceledException
                                    End If
                                    Thread.Sleep(1)
                                Next
                            End If
                        Next
                        While (True)
                            If (cancelToken(chain, xcode, ycode, ledfiles_now(chain, xcode, ycode)) = True) Then
                                Throw New OperationCanceledException
                            End If
                        End While
                    Catch ex As OperationCanceledException
                        For i = 0 To turnOffDict.Count - 1
                            Dim index = i
                            Me.Invoke(Sub()
                                          ctrlDict(turnOffDict(index)).BackColor = Color.Gray
                                      End Sub)
                        Next

                        Exit Sub
                    Catch
                    End Try
                Else
                    For i = 0 To Lines.Length - 1
                        sp = Lines(i).Split(" ")
                        If (sp(0) = "o" Or sp(0) = "on") Then
                            turnOffDict.Add(sp(1) & sp(2))
                            If (sp(3) = "a" Or sp(3) = "auto") Then
                                sp(3) = sp(4)
                                sp(3) = led.returnLED(sp(3))
                            End If
                            Me.Invoke(Sub()
                                          Me.ctrlDict(sp(1) & sp(2)).BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                      End Sub)
                        ElseIf (sp(0) = "f" Or sp(0) = "off") Then
                            Me.Invoke(Sub()
                                          ctrlDict(sp(1) & sp(2)).BackColor = Color.Gray
                                      End Sub)

                        ElseIf (sp(0) = "d" Or sp(0) = "delay") Then
                            Thread.Sleep(sp(1))
                        End If

                        'Me.Invoke(Sub()
                        '              Me.Update()
                        '          End Sub)
                    Next
                    Thread.Sleep(50)
                    For i = 0 To turnOffDict.Count - 1
                        Me.Invoke(Sub()
                                      ctrlDict(turnOffDict(i)).BackColor = Color.Gray
                                  End Sub)
                    Next
                End If
            End If



        Catch

        End Try
    End Sub

    Private Sub VirtualClick_AutoPlay(ByVal Parm As Object)
        Dim str() As String = Parm.ToString.Split(";") 'X좌표, Y좌표
        'Dim str(0) = str(0)
        'Dim str(1) = str(1)

        ' Snds.Play(chain & " 1 6 " & soundfiles_now(chain, 1, 6))

        Try
            If (ishaveLED = True) Then
                ThreadPool.QueueUserWorkItem(AddressOf LEDHandler, chain & ";" & str(0) & ";" & str(1))
            End If

        Catch
        End Try
        Try
            PlaySNDS(chain & " " & str(0) & " " & str(1) & " " & soundfiles_now(chain, str(0), str(1)))
        Catch

        End Try
        If (soundfiles_now(chain, str(0), str(1)) + 1 >= keysounds_max(chain, str(0), str(1))) Then
            soundfiles_now(chain, str(0), str(1)) = 0
        Else
            soundfiles_now(chain, str(0), str(1)) += 1
        End If
        'Catch ex As Exception


    End Sub
    Private Sub PlaySNDS(ByVal code As Object)
        Me.Invoke(Sub()
                      PlaySound(code.ToString)
                  End Sub)
    End Sub
    Private Sub AutoPlayHandler(ByVal autoplay_path As Object)

        Me.Invoke(Sub()
                      AutoPlayControler.Enabled = True
                      Me.AutoPlayBetaToolStripMenuItem.Enabled = False
                      Me.GroupBox1.Enabled = False
                  End Sub)
        autoplay_stat = "Go"



        Dim lines As New List(Of String)(IO.File.ReadAllLines(autoplay_path.ToString))
        lines.RemoveAll(Function(s) s.Trim = "")
        Dim spliter(3) As String
        'Dim counter As Integer = lines.Count
        Dim SplitedAUTO(lines.Count, 3) As String '0: 명령어(c,o,d)
        Dim index As Integer = 0
        For index = 0 To lines.Count - 1
            spliter = lines(index).Split(" ")

            For q = 0 To spliter.Count - 1
                SplitedAUTO(index, q) = spliter(q)
            Next


        Next
        index = 0
        Me.Invoke(Sub()
                      AutoPlayControler.pgSong.Value = 0
                      AutoPlayControler.pgSong.Maximum = lines.Count
                  End Sub)
        While index < lines.Count
            If (SplitedAUTO(index, 0) = "c" Or SplitedAUTO(index, 0) = "chain") Then
                Me.Invoke(Sub()
                              listChain.SelectedIndex = SplitedAUTO(index, 1) - 1
                          End Sub)
            ElseIf (SplitedAUTO(index, 0) = "d" Or SplitedAUTO(index, 0) = "delay") Then
                Thread.Sleep(SplitedAUTO(index, 1))
            ElseIf (SplitedAUTO(index, 0) = "o" Or SplitedAUTO(index, 0) = "on") Then
                Me.Invoke(Sub()
                              ctrlDict(SplitedAUTO(index, 1) & SplitedAUTO(index, 2)).ForeColor = Color.Blue

                          End Sub)
                ThreadPool.QueueUserWorkItem(AddressOf VirtualClick_AutoPlay, SplitedAUTO(index, 1) & ";" & SplitedAUTO(index, 2))
            ElseIf (SplitedAUTO(index, 0) = "f" Or SplitedAUTO(index, 0) = "off") Then
                cancelToken(chain, SplitedAUTO(index, 1), SplitedAUTO(index, 2), ledfiles_now(chain, SplitedAUTO(index, 1), SplitedAUTO(index, 2))) = True
                cancelToken_Sound(chain, SplitedAUTO(index, 1), SplitedAUTO(index, 2), soundfiles_now(chain, SplitedAUTO(index, 1), SplitedAUTO(index, 2))) = True
                Me.Invoke(Sub()
                              ctrlDict(SplitedAUTO(index, 1) & SplitedAUTO(index, 2)).ForeColor = Color.Black

                          End Sub)
            End If
            If (autoplay_stat <> "Go") Then
                If (autoplay_stat = "End") Then
                    Me.Invoke(Sub()
                                  AutoPlayControler.pgSong.Value = 0
                                  AutoPlayControler.Enabled = False
                                  Me.GroupBox1.Enabled = True
                                  Me.AutoPlayBetaToolStripMenuItem.Enabled = True
                                  AutoPlayControler.btnWaitGo.Text = "Pause"
                              End Sub)
                    autoplay_stat = "End"
                    Exit Sub
                ElseIf (autoplay_stat = "Wait") Then
                    Do Until autoplay_stat = "Go"
                    Loop
                End If
            End If
            index += 1
            Me.Invoke(Sub()
                          Try
                              AutoPlayControler.pgSong.Maximum = lines.Count
                              AutoPlayControler.pgSong.Value = index
                          Catch
                          End Try
                      End Sub)
        End While





        Me.Invoke(Sub()
                      AutoPlayControler.pgSong.Value = 0
                      AutoPlayControler.Enabled = False
                      Me.GroupBox1.Enabled = True
                      Me.AutoPlayBetaToolStripMenuItem.Enabled = True
                      AutoPlayControler.btnWaitGo.Text = "Pause"
                  End Sub)
    End Sub



    Private Sub AutoPlayBetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoPlayBetaToolStripMenuItem.Click

        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf AutoPlayHandler), "Workspace\autoPlay")
        'AutoPlayHandler("Workspace\autoPlay")
    End Sub

    Private Sub btnFlushSound_Click(sender As Object, e As EventArgs) Handles btnFlushSound.Click
        For i = 1 To CType(Me.tbPackChains.Text, Integer)
            For q = 1 To 8
                For k = 1 To 8
                    soundfiles_now(i, q, k) = 0
                    ledfiles_now(i, q, k) = 0
                Next

            Next

        Next

    End Sub

    Private Sub btnFlushLEDColor_Click(sender As Object, e As EventArgs) Handles btnFlushLEDColor.Click


        uni1_1.BackColor = Color.Gray
        uni1_2.BackColor = Color.Gray
        uni1_3.BackColor = Color.Gray
        uni1_4.BackColor = Color.Gray
        uni1_5.BackColor = Color.Gray
        uni1_6.BackColor = Color.Gray
        uni1_7.BackColor = Color.Gray
        uni1_8.BackColor = Color.Gray

        uni2_1.BackColor = Color.Gray
        uni2_2.BackColor = Color.Gray
        uni2_3.BackColor = Color.Gray
        uni2_4.BackColor = Color.Gray
        uni2_5.BackColor = Color.Gray
        uni2_6.BackColor = Color.Gray
        uni2_7.BackColor = Color.Gray
        uni2_8.BackColor = Color.Gray

        uni3_1.BackColor = Color.Gray
        uni3_2.BackColor = Color.Gray
        uni3_3.BackColor = Color.Gray
        uni3_4.BackColor = Color.Gray
        uni3_5.BackColor = Color.Gray
        uni3_6.BackColor = Color.Gray
        uni3_7.BackColor = Color.Gray
        uni3_8.BackColor = Color.Gray

        uni4_1.BackColor = Color.Gray
        uni4_2.BackColor = Color.Gray
        uni4_3.BackColor = Color.Gray
        uni4_4.BackColor = Color.Gray
        uni4_5.BackColor = Color.Gray
        uni4_6.BackColor = Color.Gray
        uni4_7.BackColor = Color.Gray
        uni4_8.BackColor = Color.Gray

        uni5_1.BackColor = Color.Gray
        uni5_2.BackColor = Color.Gray
        uni5_3.BackColor = Color.Gray
        uni5_4.BackColor = Color.Gray
        uni5_5.BackColor = Color.Gray
        uni5_6.BackColor = Color.Gray
        uni5_7.BackColor = Color.Gray
        uni5_8.BackColor = Color.Gray

        uni6_1.BackColor = Color.Gray
        uni6_2.BackColor = Color.Gray
        uni6_3.BackColor = Color.Gray
        uni6_4.BackColor = Color.Gray
        uni6_5.BackColor = Color.Gray
        uni6_6.BackColor = Color.Gray
        uni6_7.BackColor = Color.Gray
        uni6_8.BackColor = Color.Gray

        uni7_1.BackColor = Color.Gray
        uni7_2.BackColor = Color.Gray
        uni7_3.BackColor = Color.Gray
        uni7_4.BackColor = Color.Gray
        uni7_5.BackColor = Color.Gray
        uni7_6.BackColor = Color.Gray
        uni7_7.BackColor = Color.Gray
        uni7_8.BackColor = Color.Gray

        uni8_1.BackColor = Color.Gray
        uni8_2.BackColor = Color.Gray
        uni8_3.BackColor = Color.Gray
        uni8_4.BackColor = Color.Gray
        uni8_5.BackColor = Color.Gray
        uni8_6.BackColor = Color.Gray
        uni8_7.BackColor = Color.Gray
        uni8_8.BackColor = Color.Gray
    End Sub

    Private Sub AutoPlayControlerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoPlayControlerToolStripMenuItem.Click
        AutoPlayControler.Show()
    End Sub

    Private Sub PushToDeviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PushToDeviceToolStripMenuItem.Click
        adbPush.ShowDialog()

    End Sub





    Private Sub OpenSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSettingToolStripMenuItem.Click
        setting_unitor.ShowDialog()
    End Sub

    Private Sub RestoreDefaultWindowSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreDefaultWindowSizeToolStripMenuItem.Click
        Me.Size = New System.Drawing.Size(923, 678)

    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Dim result = Me.ofdOpenAgain.ShowDialog
        If (result = Forms.DialogResult.OK) Then
            Me.btnFlushLEDColor.PerformClick() 'Flush LED Board

            Loadingfrm.Show()
            Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
            Loadingfrm.Update()
            Me.Enabled = False
            Loadingfrm.workPgLabel.Text = "Flusing Sound File Loader..."
            Loadingfrm.Update()
            Me.listChain.Items.Clear()
            For t1 = 0 To 8
                For t2 = 0 To 8
                    For t3 = 0 To 8
                        For t4 = 0 To 150
                            soundfiles(t1, t2, t3, t4) = ""
                            CloseSound(t1 & " " & t2 & " " & t3 & " " & t4)
                        Next

                    Next

                Next
            Next
            Loadingfrm.workPgLabel.Text = "Flushing Workspace directory..."
            Loadingfrm.Update()
            If (My.Computer.FileSystem.DirectoryExists("Workspace") = True) Then
                Try
                    My.Computer.FileSystem.DeleteDirectory("Workspace\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch
                    For Each filename In Directory.GetFiles("*")
                        My.Computer.FileSystem.DeleteFile(filename)
                    Next
                End Try
            End If
            My.Computer.FileSystem.CreateDirectory("Workspace")

            Loadingfrm.workPgLabel.Text = "Extracting Project Files..."
            Loadingfrm.Update()
            Dim iserr As Boolean = False
            Try
                'Dim startPath As String = "c:\example\start"
                Dim zipPath As String = Me.ofdOpenAgain.FileName
                Dim extractPath As String = "Workspace"

                'ZipFile.CreateFromDirectory(startPath, zipPath)

                ZipFile.ExtractToDirectory(zipPath, extractPath)

            Catch
                iserr = True
                MessageBox.Show("Failed to extract project file. Please check if project file is vaild.", "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Loadingfrm.workPgLabel.Text = "Flushing Workspace directory and initializing..."
                Loadingfrm.Update()
                My.Computer.FileSystem.DeleteDirectory("Workspace", FileIO.DeleteDirectoryOption.DeleteAllContents, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End Try



            If (iserr = False) Then
                Loadingfrm.Close()
                Me.Enabled = True
                ThreadPool.QueueUserWorkItem(AddressOf Me.ElementLoader, Me.ofdOpenAgain.FileName & ";reopen")
            End If
        End If
    End Sub

    Private Sub Mp3ToWavConverterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mp3ToWavConverterToolStripMenuItem.Click
        If (isSaved = False) Then
            MessageBox.Show("You must save your project first!", "Save First!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            wavConvert.LoadElement(My.Application.Info.DirectoryPath & "Workspace\sounds", "UniPackLoaded Mode")
            wavConvert.ShowDialog()
        End If
    End Sub

    Private Sub SoundCutterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoundCutterToolStripMenuItem.Click
        SoundCutter.ShowDialog()
    End Sub


    Private Sub KeySoundTextEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeySoundTextEditorToolStripMenuItem.Click
        keySoundEdit.ShowDialog()
    End Sub

    Private Sub AutoPlayTextEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoPlayTextEditorToolStripMenuItem.Click
        autoPlayEdit.ShowDialog()
    End Sub

    Private Sub TestMakeCrashToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Throw New Exception("")
    End Sub


    Private Sub UploadToUniPackWWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToUniPackWWToolStripMenuItem.Click
        If (isSaved = False) Then
            MessageBox.Show("You must save your project first!", "Save First!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            unipackww.ShowDialog()
        End If
    End Sub

    Private Sub CreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditToolStripMenuItem.Click
        MsgBox("Unitor" & vbNewLine & "Unitor, the best UniPack IDE." & vbNewLine & "Developer: FollowJB" & vbNewLine & "Icon: K1A2" & vbNewLine & "Unitor is the official project of UniPad.")
    End Sub

    Private Sub ledisableenable_AvailableChanged(sender As Object, e As EventArgs) Handles ledisableenable.AvailableChanged

    End Sub

    Private Sub ledisableenable_Click(sender As Object, e As EventArgs) Handles ledisableenable.Click
        If (ishaveLED = True) Then
            Dim result = MessageBox.Show("Do you want to REMOVE ALL LED FILES in this project? You should know what you are doing!", "LED Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If (result = Windows.Forms.DialogResult.Yes) Then
                ishaveLED = False
                Try
                    My.Computer.FileSystem.DeleteDirectory("Workspace\keyLED", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch
                    MessageBox.Show("Error occured while deleting directory: " & Err.Description)
                End Try
                ReDim ledfiles(9, 9, 9, 27)
                ReDim ledfiles_max(9, 9, 9)
                ReDim ledfiles_now(9, 9, 9)
                Me.ledisableenable.Text = "Enable LED"
            Else

            End If
        Else
            Dim result = MessageBox.Show("Do you want to enable LED for this project?", "Enable LED", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If (result = Windows.Forms.DialogResult.Yes) Then
                ishaveLED = True
                If (My.Computer.FileSystem.DirectoryExists("Workspace/keyLED") = False) Then
                    My.Computer.FileSystem.CreateDirectory("Workspace/keyLED")
                End If
                Me.ledisableenable.Text = "Disable LED"
            End If

        End If
    End Sub

    Private Sub ConnectMidiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectMidiToolStripMenuItem.Click
        midiConnect.ShowDialog()

    End Sub



#Region "X Code 1"

    Private Sub uni1_1_MouseOn(sender As Object, e As EventArgs) Handles uni1_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 1, ledfiles_now(chain, 1, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 1, soundfiles_now(chain, 1, 1)) = True
        If (soundLoop(chain, 1, 1, soundfiles_now(chain, 1, 1)) = 0) Then StopPlay(chain & " " & 1 & " " & 1 & " " & soundfiles_now(chain, 1, 1))


    End Sub

    Private Sub uni1_2_MouseOn(sender As Object, e As EventArgs) Handles uni1_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 2, ledfiles_now(chain, 1, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 2, soundfiles_now(chain, 1, 2)) = True
        If (soundLoop(chain, 1, 2, soundfiles_now(chain, 1, 2)) = 0) Then StopPlay(chain & " " & 1 & " " & 2 & " " & soundfiles_now(chain, 1, 2))

    End Sub

    Private Sub uni1_3_MouseOn(sender As Object, e As EventArgs) Handles uni1_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 3, ledfiles_now(chain, 1, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 3, soundfiles_now(chain, 1, 3)) = True
        If (soundLoop(chain, 1, 3, soundfiles_now(chain, 1, 3)) = 0) Then StopPlay(chain & " " & 1 & " " & 3 & " " & soundfiles_now(chain, 1, 3))


    End Sub

    Private Sub uni1_4_MouseOn(sender As Object, e As EventArgs) Handles uni1_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 4, ledfiles_now(chain, 1, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 4, soundfiles_now(chain, 1, 4)) = True
        If (soundLoop(chain, 1, 4, soundfiles_now(chain, 1, 4)) = 0) Then StopPlay(chain & " " & 1 & " " & 4 & " " & soundfiles_now(chain, 1, 4))


    End Sub

    Private Sub uni1_5_MouseOn(sender As Object, e As EventArgs) Handles uni1_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 5, ledfiles_now(chain, 1, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 5, soundfiles_now(chain, 1, 5)) = True
        If (soundLoop(chain, 1, 5, soundfiles_now(chain, 1, 5)) = 0) Then StopPlay(chain & " " & 1 & " " & 5 & " " & soundfiles_now(chain, 1, 5))

    End Sub

    Private Sub uni1_6_MouseOn(sender As Object, e As EventArgs) Handles uni1_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 6, ledfiles_now(chain, 1, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 6, soundfiles_now(chain, 1, 6)) = True
        If (soundLoop(chain, 1, 6, soundfiles_now(chain, 1, 6)) = 0) Then StopPlay(chain & " " & 1 & " " & 6 & " " & soundfiles_now(chain, 1, 6))

    End Sub

    Private Sub uni1_7_MouseOn(sender As Object, e As EventArgs) Handles uni1_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 7, ledfiles_now(chain, 1, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 7, soundfiles_now(chain, 1, 7)) = True
        If (soundLoop(chain, 1, 7, soundfiles_now(chain, 1, 7)) = 0) Then StopPlay(chain & " " & 1 & " " & 7 & " " & soundfiles_now(chain, 1, 7))

    End Sub

    Private Sub uni1_8_MouseOn(sender As Object, e As EventArgs) Handles uni1_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 1, 8, ledfiles_now(chain, 1, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 1, 8, soundfiles_now(chain, 1, 8)) = True
        If (soundLoop(chain, 1, 8, soundfiles_now(chain, 1, 8)) = 0) Then StopPlay(chain & " " & 1 & " " & 8 & " " & soundfiles_now(chain, 1, 8))

    End Sub
#End Region
#Region "X Code 2"

    Private Sub uni2_1_MouseOn(sender As Object, e As EventArgs) Handles uni2_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 1, ledfiles_now(chain, 2, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 1, soundfiles_now(chain, 2, 1)) = True
        If (soundLoop(chain, 2, 1, soundfiles_now(chain, 2, 1)) = 0) Then StopPlay(chain & " " & 2 & " " & 1 & " " & soundfiles_now(chain, 2, 1))

    End Sub

    Private Sub uni2_2_MouseOn(sender As Object, e As EventArgs) Handles uni2_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 2, ledfiles_now(chain, 2, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 2, soundfiles_now(chain, 2, 2)) = True
        If (soundLoop(chain, 2, 2, soundfiles_now(chain, 2, 2)) = 0) Then StopPlay(chain & " " & 2 & " " & 2 & " " & soundfiles_now(chain, 2, 2))

    End Sub

    Private Sub uni2_3_MouseOn(sender As Object, e As EventArgs) Handles uni2_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 3, ledfiles_now(chain, 2, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 3, soundfiles_now(chain, 2, 3)) = True
        If (soundLoop(chain, 2, 3, soundfiles_now(chain, 2, 3)) = 0) Then StopPlay(chain & " " & 2 & " " & 3 & " " & soundfiles_now(chain, 2, 3))

    End Sub

    Private Sub uni2_4_MouseOn(sender As Object, e As EventArgs) Handles uni2_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 4, ledfiles_now(chain, 2, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 4, soundfiles_now(chain, 2, 4)) = True
        If (soundLoop(chain, 2, 4, soundfiles_now(chain, 2, 4)) = 0) Then StopPlay(chain & " " & 2 & " " & 4 & " " & soundfiles_now(chain, 2, 4))

    End Sub

    Private Sub uni2_5_MouseOn(sender As Object, e As EventArgs) Handles uni2_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 5, ledfiles_now(chain, 2, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 5, soundfiles_now(chain, 2, 4)) = True
        If (soundLoop(chain, 2, 5, soundfiles_now(chain, 2, 5)) = 0) Then StopPlay(chain & " " & 2 & " " & 5 & " " & soundfiles_now(chain, 2, 5))

    End Sub

    Private Sub uni2_6_MouseOn(sender As Object, e As EventArgs) Handles uni2_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 6, ledfiles_now(chain, 2, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 6, soundfiles_now(chain, 2, 6)) = True
        If (soundLoop(chain, 2, 6, soundfiles_now(chain, 2, 6)) = 0) Then StopPlay(chain & " " & 2 & " " & 6 & " " & soundfiles_now(chain, 2, 6))

    End Sub

    Private Sub uni2_7_MouseOn(sender As Object, e As EventArgs) Handles uni2_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 7, ledfiles_now(chain, 2, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 7, soundfiles_now(chain, 2, 7)) = True
        If (soundLoop(chain, 2, 7, soundfiles_now(chain, 2, 7)) = 0) Then StopPlay(chain & " " & 2 & " " & 7 & " " & soundfiles_now(chain, 2, 7))

    End Sub

    Private Sub uni2_8_MouseOn(sender As Object, e As EventArgs) Handles uni2_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 2, 8, ledfiles_now(chain, 2, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 2, 8, soundfiles_now(chain, 2, 8)) = True
        If (soundLoop(chain, 2, 8, soundfiles_now(chain, 2, 8)) = 0) Then StopPlay(chain & " " & 2 & " " & 8 & " " & soundfiles_now(chain, 2, 8))

    End Sub
#End Region
#Region "X Code 3"

    Private Sub uni3_1_MouseOn(sender As Object, e As EventArgs) Handles uni3_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 1, ledfiles_now(chain, 3, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 3, 1, soundfiles_now(chain, 3, 1)) = True
        If (soundLoop(chain, 3, 1, soundfiles_now(chain, 3, 1)) = 0) Then StopPlay(chain & " " & 3 & " " & 1 & " " & soundfiles_now(chain, 3, 1))

    End Sub

    Private Sub uni3_2_MouseOn(sender As Object, e As EventArgs) Handles uni3_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 2, ledfiles_now(chain, 3, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 3, 2, soundfiles_now(chain, 3, 2)) = True
        If (soundLoop(chain, 3, 2, soundfiles_now(chain, 3, 2)) = 0) Then StopPlay(chain & " " & 3 & " " & 2 & " " & soundfiles_now(chain, 3, 2))

    End Sub

    Private Sub uni3_3_MouseOn(sender As Object, e As EventArgs) Handles uni3_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 3, ledfiles_now(chain, 3, 3)) = True
        If (soundLoop(chain, 3, 3, soundfiles_now(chain, 3, 3)) = 0) Then StopPlay(chain & " " & 3 & " " & 3 & " " & soundfiles_now(chain, 3, 3))

    End Sub

    Private Sub uni3_4_MouseOn(sender As Object, e As EventArgs) Handles uni3_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 4, ledfiles_now(chain, 3, 4)) = True
        If (soundLoop(chain, 3, 4, soundfiles_now(chain, 3, 4)) = 0) Then StopPlay(chain & " " & 3 & " " & 4 & " " & soundfiles_now(chain, 3, 4))

    End Sub

    Private Sub uni3_5_MouseOn(sender As Object, e As EventArgs) Handles uni3_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 5, ledfiles_now(chain, 3, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 3, 5, soundfiles_now(chain, 3, 5)) = True
        If (soundLoop(chain, 3, 5, soundfiles_now(chain, 3, 5)) = 0) Then StopPlay(chain & " " & 3 & " " & 5 & " " & soundfiles_now(chain, 3, 5))

    End Sub

    Private Sub uni3_6_MouseOn(sender As Object, e As EventArgs) Handles uni3_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 6, ledfiles_now(chain, 3, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 3, 6, soundfiles_now(chain, 3, 6)) = True
        If (soundLoop(chain, 3, 6, soundfiles_now(chain, 3, 6)) = 0) Then StopPlay(chain & " " & 3 & " " & 6 & " " & soundfiles_now(chain, 3, 6))

    End Sub

    Private Sub uni3_7_MouseOn(sender As Object, e As EventArgs) Handles uni3_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 7, ledfiles_now(chain, 3, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 3, 7, soundfiles_now(chain, 3, 7)) = True
        If (soundLoop(chain, 3, 7, soundfiles_now(chain, 3, 7)) = 0) Then StopPlay(chain & " " & 3 & " " & 7 & " " & soundfiles_now(chain, 3, 7))

    End Sub

    Private Sub uni3_8_MouseOn(sender As Object, e As EventArgs) Handles uni3_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 3, 8, ledfiles_now(chain, 3, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 3, 8, soundfiles_now(chain, 3, 8)) = True
        If (soundLoop(chain, 3, 8, soundfiles_now(chain, 3, 8)) = 0) Then StopPlay(chain & " " & 3 & " " & 8 & " " & soundfiles_now(chain, 3, 8))

    End Sub
#End Region
#Region "X Code 4"

    Private Sub uni4_1_MouseOn(sender As Object, e As EventArgs) Handles uni4_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 1, ledfiles_now(chain, 4, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 1, soundfiles_now(chain, 4, 1)) = True
        If (soundLoop(chain, 4, 1, soundfiles_now(chain, 4, 1)) = 0) Then StopPlay(chain & " " & 4 & " " & 1 & " " & soundfiles_now(chain, 4, 1))

    End Sub

    Private Sub uni4_2_MouseOn(sender As Object, e As EventArgs) Handles uni4_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 2, ledfiles_now(chain, 4, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 2, soundfiles_now(chain, 4, 2)) = True
        If (soundLoop(chain, 4, 2, soundfiles_now(chain, 4, 2)) = 0) Then StopPlay(chain & " " & 4 & " " & 2 & " " & soundfiles_now(chain, 4, 2))

    End Sub

    Private Sub uni4_3_MouseOn(sender As Object, e As EventArgs) Handles uni4_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 3, ledfiles_now(chain, 4, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 3, soundfiles_now(chain, 4, 3)) = True
        If (soundLoop(chain, 4, 3, soundfiles_now(chain, 4, 3)) = 0) Then StopPlay(chain & " " & 4 & " " & 3 & " " & soundfiles_now(chain, 4, 3))

    End Sub

    Private Sub uni4_4_MouseOn(sender As Object, e As EventArgs) Handles uni4_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 4, ledfiles_now(chain, 4, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 4, soundfiles_now(chain, 4, 4)) = True
        If (soundLoop(chain, 4, 4, soundfiles_now(chain, 4, 4)) = 0) Then StopPlay(chain & " " & 4 & " " & 4 & " " & soundfiles_now(chain, 4, 4))

    End Sub

    Private Sub uni4_5_MouseOn(sender As Object, e As EventArgs) Handles uni4_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 5, ledfiles_now(chain, 4, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 5, soundfiles_now(chain, 4, 5)) = True
        If (soundLoop(chain, 4, 5, soundfiles_now(chain, 4, 5)) = 0) Then StopPlay(chain & " " & 4 & " " & 5 & " " & soundfiles_now(chain, 4, 5))

    End Sub

    Private Sub uni4_6_MouseOn(sender As Object, e As EventArgs) Handles uni4_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 6, ledfiles_now(chain, 4, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 6, soundfiles_now(chain, 4, 6)) = True
        If (soundLoop(chain, 4, 6, soundfiles_now(chain, 4, 6)) = 0) Then StopPlay(chain & " " & 4 & " " & 6 & " " & soundfiles_now(chain, 4, 6))

    End Sub

    Private Sub uni4_7_MouseOn(sender As Object, e As EventArgs) Handles uni4_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 7, ledfiles_now(chain, 4, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 7, soundfiles_now(chain, 4, 7)) = True
        If (soundLoop(chain, 4, 7, soundfiles_now(chain, 4, 7)) = 0) Then StopPlay(chain & " " & 4 & " " & 7 & " " & soundfiles_now(chain, 4, 7))

    End Sub

    Private Sub uni4_8_MouseOn(sender As Object, e As EventArgs) Handles uni4_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 4, 8, ledfiles_now(chain, 4, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 4, 8, soundfiles_now(chain, 4, 8)) = True
        If (soundLoop(chain, 4, 8, soundfiles_now(chain, 4, 8)) = 0) Then StopPlay(chain & " " & 4 & " " & 8 & " " & soundfiles_now(chain, 4, 8))

    End Sub
#End Region
#Region "X Code 5"

    Private Sub uni5_1_MouseOn(sender As Object, e As EventArgs) Handles uni5_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 1, ledfiles_now(chain, 5, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 1, soundfiles_now(chain, 5, 1)) = True
        If (soundLoop(chain, 5, 1, soundfiles_now(chain, 5, 1)) = 0) Then StopPlay(chain & " " & 5 & " " & 1 & " " & soundfiles_now(chain, 5, 1))

    End Sub

    Private Sub uni5_2_MouseOn(sender As Object, e As EventArgs) Handles uni5_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 2, ledfiles_now(chain, 5, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 2, soundfiles_now(chain, 5, 2)) = True
        If (soundLoop(chain, 5, 2, soundfiles_now(chain, 5, 2)) = 0) Then StopPlay(chain & " " & 5 & " " & 2 & " " & soundfiles_now(chain, 5, 2))

    End Sub

    Private Sub uni5_3_MouseOn(sender As Object, e As EventArgs) Handles uni5_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 3, ledfiles_now(chain, 5, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 3, soundfiles_now(chain, 5, 3)) = True
        If (soundLoop(chain, 5, 3, soundfiles_now(chain, 5, 3)) = 0) Then StopPlay(chain & " " & 5 & " " & 3 & " " & soundfiles_now(chain, 5, 3))

    End Sub

    Private Sub uni5_4_MouseOn(sender As Object, e As EventArgs) Handles uni5_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 4, ledfiles_now(chain, 5, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 4, soundfiles_now(chain, 5, 4)) = True
        If (soundLoop(chain, 5, 4, soundfiles_now(chain, 5, 4)) = 0) Then StopPlay(chain & " " & 5 & " " & 4 & " " & soundfiles_now(chain, 5, 4))

    End Sub

    Private Sub uni5_5_MouseOn(sender As Object, e As EventArgs) Handles uni5_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 5, ledfiles_now(chain, 5, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 5, soundfiles_now(chain, 5, 5)) = True
        If (soundLoop(chain, 5, 5, soundfiles_now(chain, 5, 5)) = 0) Then StopPlay(chain & " " & 5 & " " & 5 & " " & soundfiles_now(chain, 5, 5))

    End Sub

    Private Sub uni5_6_MouseOn(sender As Object, e As EventArgs) Handles uni5_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 6, ledfiles_now(chain, 5, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 6, soundfiles_now(chain, 5, 6)) = True
        If (soundLoop(chain, 5, 6, soundfiles_now(chain, 5, 6)) = 0) Then StopPlay(chain & " " & 5 & " " & 6 & " " & soundfiles_now(chain, 5, 6))

    End Sub

    Private Sub uni5_7_MouseOn(sender As Object, e As EventArgs) Handles uni5_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 7, ledfiles_now(chain, 5, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 7, soundfiles_now(chain, 5, 7)) = True
        If (soundLoop(chain, 5, 7, soundfiles_now(chain, 5, 7)) = 0) Then StopPlay(chain & " " & 5 & " " & 7 & " " & soundfiles_now(chain, 5, 7))

    End Sub

    Private Sub uni5_8_MouseOn(sender As Object, e As EventArgs) Handles uni5_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 5, 8, ledfiles_now(chain, 5, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 5, 8, soundfiles_now(chain, 5, 8)) = True
        If (soundLoop(chain, 5, 8, soundfiles_now(chain, 5, 8)) = 0) Then StopPlay(chain & " " & 5 & " " & 8 & " " & soundfiles_now(chain, 5, 8))

    End Sub
#End Region
#Region "X Code 6"

    Private Sub uni6_1_MouseOn(sender As Object, e As EventArgs) Handles uni6_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 1, ledfiles_now(chain, 6, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 1, soundfiles_now(chain, 6, 1)) = True
        If (soundLoop(chain, 6, 1, soundfiles_now(chain, 6, 1)) = 0) Then StopPlay(chain & " " & 6 & " " & 1 & " " & soundfiles_now(chain, 6, 1))

    End Sub

    Private Sub uni6_2_MouseOn(sender As Object, e As EventArgs) Handles uni6_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 2, ledfiles_now(chain, 6, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 2, soundfiles_now(chain, 6, 2)) = True
        If (soundLoop(chain, 6, 2, soundfiles_now(chain, 6, 2)) = 0) Then StopPlay(chain & " " & 6 & " " & 2 & " " & soundfiles_now(chain, 6, 2))

    End Sub

    Private Sub uni6_3_MouseOn(sender As Object, e As EventArgs) Handles uni6_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 3, ledfiles_now(chain, 6, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 3, soundfiles_now(chain, 6, 3)) = True
        If (soundLoop(chain, 6, 3, soundfiles_now(chain, 6, 3)) = 0) Then StopPlay(chain & " " & 6 & " " & 3 & " " & soundfiles_now(chain, 6, 3))

    End Sub

    Private Sub uni6_4_MouseOn(sender As Object, e As EventArgs) Handles uni6_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 4, ledfiles_now(chain, 6, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 4, soundfiles_now(chain, 6, 4)) = True
        If (soundLoop(chain, 6, 4, soundfiles_now(chain, 6, 4)) = 0) Then StopPlay(chain & " " & 6 & " " & 4 & " " & soundfiles_now(chain, 6, 4))

    End Sub

    Private Sub uni6_5_MouseOn(sender As Object, e As EventArgs) Handles uni6_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 5, ledfiles_now(chain, 6, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 5, soundfiles_now(chain, 6, 5)) = True
        If (soundLoop(chain, 6, 5, soundfiles_now(chain, 6, 5)) = 0) Then StopPlay(chain & " " & 6 & " " & 5 & " " & soundfiles_now(chain, 6, 5))

    End Sub

    Private Sub uni6_6_MouseOn(sender As Object, e As EventArgs) Handles uni6_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 6, ledfiles_now(chain, 6, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 6, soundfiles_now(chain, 6, 6)) = True
        If (soundLoop(chain, 6, 6, soundfiles_now(chain, 6, 6)) = 0) Then StopPlay(chain & " " & 6 & " " & 6 & " " & soundfiles_now(chain, 6, 6))

    End Sub

    Private Sub uni6_7_MouseOn(sender As Object, e As EventArgs) Handles uni6_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 7, ledfiles_now(chain, 6, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 7, soundfiles_now(chain, 6, 7)) = True
        If (soundLoop(chain, 6, 7, soundfiles_now(chain, 6, 7)) = 0) Then StopPlay(chain & " " & 6 & " " & 7 & " " & soundfiles_now(chain, 6, 7))

    End Sub

    Private Sub uni6_8_MouseOn(sender As Object, e As EventArgs) Handles uni6_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 6, 8, ledfiles_now(chain, 6, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 6, 8, soundfiles_now(chain, 6, 8)) = True
        If (soundLoop(chain, 6, 8, soundfiles_now(chain, 6, 8)) = 0) Then StopPlay(chain & " " & 6 & " " & 8 & " " & soundfiles_now(chain, 6, 8))

    End Sub
#End Region
#Region "X Code 7"

    Private Sub uni7_1_MouseOn(sender As Object, e As EventArgs) Handles uni7_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 1, ledfiles_now(chain, 7, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 1, soundfiles_now(chain, 7, 1)) = True
        If (soundLoop(chain, 7, 1, soundfiles_now(chain, 7, 1)) = 0) Then StopPlay(chain & " " & 7 & " " & 1 & " " & soundfiles_now(chain, 7, 1))

    End Sub

    Private Sub uni7_2_MouseOn(sender As Object, e As EventArgs) Handles uni7_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 2, ledfiles_now(chain, 7, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 2, soundfiles_now(chain, 7, 2)) = True
        If (soundLoop(chain, 7, 2, soundfiles_now(chain, 7, 2)) = 0) Then StopPlay(chain & " " & 7 & " " & 2 & " " & soundfiles_now(chain, 7, 2))

    End Sub

    Private Sub uni7_3_MouseOn(sender As Object, e As EventArgs) Handles uni7_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 3, ledfiles_now(chain, 7, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 3, soundfiles_now(chain, 7, 3)) = True
        If (soundLoop(chain, 7, 3, soundfiles_now(chain, 7, 3)) = 0) Then StopPlay(chain & " " & 7 & " " & 3 & " " & soundfiles_now(chain, 7, 3))

    End Sub

    Private Sub uni7_4_MouseOn(sender As Object, e As EventArgs) Handles uni7_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 4, ledfiles_now(chain, 7, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 4, soundfiles_now(chain, 7, 4)) = True
        If (soundLoop(chain, 7, 4, soundfiles_now(chain, 7, 4)) = 0) Then StopPlay(chain & " " & 7 & " " & 4 & " " & soundfiles_now(chain, 7, 4))

    End Sub

    Private Sub uni7_5_MouseOn(sender As Object, e As EventArgs) Handles uni7_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 5, ledfiles_now(chain, 7, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 5, soundfiles_now(chain, 7, 5)) = True
        If (soundLoop(chain, 7, 5, soundfiles_now(chain, 7, 5)) = 0) Then StopPlay(chain & " " & 7 & " " & 5 & " " & soundfiles_now(chain, 7, 5))

    End Sub

    Private Sub uni7_6_MouseOn(sender As Object, e As EventArgs) Handles uni7_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 6, ledfiles_now(chain, 7, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 6, soundfiles_now(chain, 7, 6)) = True
        If (soundLoop(chain, 7, 6, soundfiles_now(chain, 7, 6)) = 0) Then StopPlay(chain & " " & 7 & " " & 6 & " " & soundfiles_now(chain, 7, 6))

    End Sub

    Private Sub uni7_7_MouseOn(sender As Object, e As EventArgs) Handles uni7_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 7, ledfiles_now(chain, 7, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 7, soundfiles_now(chain, 7, 7)) = True
        If (soundLoop(chain, 7, 7, soundfiles_now(chain, 7, 7)) = 0) Then StopPlay(chain & " " & 7 & " " & 7 & " " & soundfiles_now(chain, 7, 7))

    End Sub

    Private Sub uni7_8_MouseOn(sender As Object, e As EventArgs) Handles uni7_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 7, 8, ledfiles_now(chain, 7, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 7, 8, soundfiles_now(chain, 7, 8)) = True
        If (soundLoop(chain, 7, 8, soundfiles_now(chain, 7, 8)) = 0) Then StopPlay(chain & " " & 7 & " " & 8 & " " & soundfiles_now(chain, 7, 8))

    End Sub
#End Region
#Region "X Code 8"

    Private Sub uni8_1_MouseOn(sender As Object, e As EventArgs) Handles uni8_1.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 1, ledfiles_now(chain, 8, 1)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 1, soundfiles_now(chain, 8, 1)) = True
        If (soundLoop(chain, 8, 1, soundfiles_now(chain, 8, 1)) = 0) Then StopPlay(chain & " " & 8 & " " & 1 & " " & soundfiles_now(chain, 8, 1))

    End Sub

    Private Sub uni8_2_MouseOn(sender As Object, e As EventArgs) Handles uni8_2.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 2, ledfiles_now(chain, 8, 2)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 2, soundfiles_now(chain, 8, 2)) = True
        If (soundLoop(chain, 8, 2, soundfiles_now(chain, 8, 2)) = 0) Then StopPlay(chain & " " & 8 & " " & 2 & " " & soundfiles_now(chain, 8, 2))

    End Sub

    Private Sub uni8_3_MouseOn(sender As Object, e As EventArgs) Handles uni8_3.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 3, ledfiles_now(chain, 8, 3)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 3, soundfiles_now(chain, 8, 3)) = True
        If (soundLoop(chain, 8, 3, soundfiles_now(chain, 8, 3)) = 0) Then StopPlay(chain & " " & 8 & " " & 3 & " " & soundfiles_now(chain, 8, 3))

    End Sub

    Private Sub uni8_4_MouseOn(sender As Object, e As EventArgs) Handles uni8_4.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 4, ledfiles_now(chain, 8, 4)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 4, soundfiles_now(chain, 8, 4)) = True
        If (soundLoop(chain, 8, 4, soundfiles_now(chain, 8, 4)) = 0) Then StopPlay(chain & " " & 8 & " " & 4 & " " & soundfiles_now(chain, 8, 4))

    End Sub

    Private Sub uni8_5_MouseOn(sender As Object, e As EventArgs) Handles uni8_5.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 5, ledfiles_now(chain, 8, 5)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 5, soundfiles_now(chain, 8, 5)) = True
        If (soundLoop(chain, 8, 5, soundfiles_now(chain, 8, 5)) = 0) Then StopPlay(chain & " " & 8 & " " & 5 & " " & soundfiles_now(chain, 8, 5))

    End Sub

    Private Sub uni8_6_MouseOn(sender As Object, e As EventArgs) Handles uni8_6.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 6, ledfiles_now(chain, 8, 6)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 6, soundfiles_now(chain, 8, 6)) = True
        If (soundLoop(chain, 8, 6, soundfiles_now(chain, 8, 6)) = 0) Then StopPlay(chain & " " & 8 & " " & 6 & " " & soundfiles_now(chain, 8, 6))

    End Sub

    Private Sub uni8_7_MouseOn(sender As Object, e As EventArgs) Handles uni8_7.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 7, ledfiles_now(chain, 8, 7)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 7, soundfiles_now(chain, 8, 7)) = True
        If (soundLoop(chain, 8, 7, soundfiles_now(chain, 8, 7)) = 0) Then StopPlay(chain & " " & 8 & " " & 7 & " " & soundfiles_now(chain, 8, 7))

    End Sub

    Private Sub uni8_8_MouseOn(sender As Object, e As EventArgs) Handles uni8_8.MouseUp

        If (settings(0) = 1) Then cancelToken(chain, 8, 8, ledfiles_now(chain, 8, 8)) = True
        If (settings(3) = 1) Then cancelToken_Sound(chain, 8, 8, soundfiles_now(chain, 8, 8)) = True
        If (soundLoop(chain, 8, 8, soundfiles_now(chain, 8, 8)) = 0) Then StopPlay(chain & " " & 8 & " " & 8 & " " & soundfiles_now(chain, 8, 8))

    End Sub
#End Region

#Region "MCISEndString"

    'MIDI
    <DllImport("winmm.dll", EntryPoint:="mciSendStringW")> _
    Private Shared Function mciSendStringW(<MarshalAs(UnmanagedType.LPTStr)> ByVal lpszCommand As String, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszReturnString As System.Text.StringBuilder, ByVal cchReturn As UInteger, ByVal hwndCallback As IntPtr) As Integer
    End Function
    Public Const MM_MCINOTIFY As Integer = 953
    ' Override the WndProc function which is called when the play function ends

    Public Function AddSound(ByVal SoundName As String, ByVal SndFilePath As String) As Integer
        If SoundName.Trim = "" Or Not IO.File.Exists(SndFilePath) Then Return False
        If mciSendStringW("open " & Chr(34) & SndFilePath & Chr(34) & " alias " & Chr(34) & SoundName & Chr(34), Nothing, 0, IntPtr.Zero) <> 0 Then Return 1
        'MsgBox(SoundName)
        'Snds.Add(SndFilePath, SoundName)
        Return 1

    End Function

    Public Function PlaySound(ByVal SoundName As String)
        Dim c() As String = SoundName.Split(" ")
        Try

            If (Me.soundLoop(c(0), c(1), c(2), c(3)) = 1) Then
                If mciSendStringW("seek " & Chr(34) & SoundName & Chr(34) & " to start", Nothing, 0, IntPtr.Zero) <> 0 Then Return False

                If mciSendStringW("play " & Chr(34) & SoundName & Chr(34) & "", Nothing, 0, IntPtr.Zero) <> 0 Then Return False


            ElseIf (Me.soundLoop(c(0), c(1), c(2), c(3)) = 0) Then
                ThreadPool.QueueUserWorkItem(AddressOf loopPlay, SoundName)
            Else
                For play_index As Integer = 1 To Me.soundLoop(c(0), c(1), c(2), c(3))
                    If mciSendStringW("seek " & Chr(34) & SoundName & Chr(34) & " to start", Nothing, 0, IntPtr.Zero) <> 0 Then Return False
                    mciSendStringW("play " & Chr(34) & SoundName & Chr(34) & "", Nothing, 0, IntPtr.Zero)
                    Thread.Sleep(GetSoundLength(SoundName))
                Next

            End If
        Catch
            Return False
        End Try
        Return True

    End Function
    Public Function CloseSound(ByVal SoundName As String) As Boolean '이름을 통하여 삭제

        mciSendStringW("close " & Chr(34) & SoundName & Chr(34), Nothing, 0, IntPtr.Zero)

        Return True
    End Function

    Public Function StopPlay(ByVal SoundName As String) As Boolean
        Dim c() As String = SoundName.Split(" ")
        Me.cancelToken_Sound(c(0), c(1), c(2), c(3)) = True

        'If mciSendStringW("stop " & Chr(34) & SoundName & Chr(34), Nothing, 0, IntPtr.Zero) <> 0 Then Return False
        Return True

    End Function

    'Stack Over Flow
    Sub RemoveByValue(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal someValue As TValue) '이름으로 삭제

        Dim itemsToRemove = (From pair In dictionary _
                            Where pair.Value.Equals(someValue) _
                            Select pair.Key).ToArray()

        For Each item As TKey In itemsToRemove
            dictionary.Remove(item)
        Next

    End Sub

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    If m.Msg = MM_MCINOTIFY Then
    '        ' The file is done playing, do whatever is necessary at this point
    '        MsgBox("Done playing.")
    '    End If
    '    MyBase.WndProc(m)
    'End Sub


    Public Shared Function GetSoundLength(SoundName As String) As Integer
        Dim lengthBuf As New StringBuilder(32)

        mciSendStringW("status " & Chr(34) & SoundName & Chr(34) & " length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero)

        Dim length As Integer = 0
        Integer.TryParse(lengthBuf.ToString(), length)

        Return length
    End Function

#End Region

    Private Sub loopPlay(SoundName As String)
        Dim c() As String = SoundName.Split(" ")
        Me.cancelToken_Sound(c(0), c(1), c(2), c(3)) = False
        Dim waittime As Integer
        Me.Invoke(Sub()
                      waittime = GetSoundLength(SoundName)
                  End Sub)
        Do While (Me.cancelToken_Sound(c(0), c(1), c(2), c(3)) = False)

            Me.Invoke(Sub()
                          If mciSendStringW("seek " & Chr(34) & SoundName & Chr(34) & " to start", Nothing, 0, IntPtr.Zero) <> 0 Then Return

                          mciSendStringW("play " & Chr(34) & SoundName & Chr(34) & "", Nothing, 0, IntPtr.Zero)

                      End Sub)
            Thread.Sleep(waittime)

        Loop
        Return
    End Sub


    Private Sub TabMenu_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim g As Graphics
        Dim sText As String
        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF
        Dim ctlTab As TabControl

        ctlTab = CType(sender, TabControl)

        g = e.Graphics

        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)
        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2
        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    End Sub

    Dim dashboard_activity_friendact_items_count As Integer = 0 'Size of each item is 833, 50 and start point is 0,5
    Private Sub btnTTTTEEEESSSSTTTT_Click(sender As Object, e As EventArgs) Handles btnTTTTEEEESSSSTTTT.Click

        Dim BasePB As New Panel
        With BasePB
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count
            .AutoSize = True
            .Location = New System.Drawing.Point(0, 5 + 50 * dashboard_activity_friendact_items_count)
            .Size = New System.Drawing.Size(833, 50)
            .TabIndex = 48
            .TabStop = True
            .Visible = True
            .BackColor = Color.White

        End With


        Dim ThumbNailPB As New PictureBox
        With ThumbNailPB
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_thumbnail"
            .AutoSize = True
            .Location = New System.Drawing.Point(20, 10)
            .Size = New System.Drawing.Size(40, 40)
            .TabIndex = 48
            .TabStop = True
            .Visible = True
        End With
        Dim roundThumb As New System.Drawing.Drawing2D.GraphicsPath
        roundThumb.AddEllipse(New Rectangle(0, 0, 40, 40))
        ThumbNailPB.Region = New Region(roundThumb)
        ThumbNailPB.BackColor = Color.Gray


        Dim SenderName As New Label
        With SenderName
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_sender"
            .AutoSize = True
            .Location = New System.Drawing.Point(70, 18)
            .Font = New System.Drawing.Font("맑은 고딕", 15.0!)
            .TabIndex = 0
            .TabStop = True
            .Visible = True
            .Text = "Admin " & dashboard_activity_friendact_items_count
            .ForeColor = Color.LightBlue
        End With

        Dim msg As New Label
        With msg
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_msg"
            .AutoSize = True
            .Location = New System.Drawing.Point(180, 15)
            .Font = New System.Drawing.Font("맑은 고딕", 13.0!)
            .TabIndex = 48
            .TabStop = True
            .Visible = True
            .Text = "OK. Checking Process Finished,"
            .ForeColor = Color.Gray
            .Anchor = AnchorStyles.Left
        End With

        Dim UnreadPB As New PictureBox
        With UnreadPB
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_unread"
            .AutoSize = True
            .Location = New System.Drawing.Point(0, 5)
            .Size = New System.Drawing.Size(5, 50)
            .TabIndex = 48
            .TabStop = True
            .BackColor = Color.Purple
            .Visible = True
        End With

        Dim SeperateLine As New PictureBox
        With SeperateLine
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_sepline"
            .AutoSize = True
            .Dock = DockStyle.Bottom
            .Size = New System.Drawing.Size(776, 2)
            .TabIndex = 48
            .TabStop = True
            .Visible = True
            .BackColor = Color.Black
        End With

        Dim clockimg As New PictureBox
        With clockimg
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_clock"
            .AutoSize = True
            .Location = New System.Drawing.Point(720, 18)
            .Size = New System.Drawing.Size(20, 20)
            .TabIndex = 48
            .TabStop = True
            .Image = My.Resources.ic_access_time_black_36dp
            .Visible = True
            .SizeMode = PictureBoxSizeMode.StretchImage
        End With

        Dim alarmTime As New Label
        With alarmTime
            .Name = "pb_dash_act_friend_base" & dashboard_activity_friendact_items_count & "_time"
            .AutoSize = True
            .Location = New System.Drawing.Point(746, 22)
            .Text = "4:50 PM " & dashboard_activity_friendact_items_count
            .TabIndex = 48
            .TabStop = True
            .Visible = True
        End With

        AddHandler BasePB.MouseMove, Sub()
                                         BasePB.BackColor = ColorTranslator.FromHtml("#b3b3b3")
                                     End Sub
        AddHandler BasePB.MouseLeave, Sub()
                                          BasePB.BackColor = Color.White
                                      End Sub
        AddHandler ThumbNailPB.MouseMove, Sub()
                                              BasePB.BackColor = ColorTranslator.FromHtml("#b3b3b3")
                                          End Sub
        AddHandler SenderName.MouseMove, Sub()
                                             BasePB.BackColor = ColorTranslator.FromHtml("#b3b3b3")
                                         End Sub

        AddHandler clockimg.MouseMove, Sub()
                                           BasePB.BackColor = ColorTranslator.FromHtml("#b3b3b3")
                                       End Sub

        AddHandler msg.MouseMove, Sub()
                                      BasePB.BackColor = ColorTranslator.FromHtml("#b3b3b3")
                                  End Sub

        AddHandler alarmTime.MouseMove, Sub()
                                            BasePB.BackColor = ColorTranslator.FromHtml("#b3b3b3")
                                        End Sub




        With BasePB
            .Controls.Add(UnreadPB)
            .Controls.Add(ThumbNailPB)
            .Controls.Add(SeperateLine)
            .Controls.Add(clockimg)
            .Controls.Add(alarmTime)
            .Controls.Add(SenderName)
            .Controls.Add(msg)
        End With
        Me.panel_dashboard_activity_friend.Controls.Add(BasePB)


        dashboard_activity_friendact_items_count += 1

    End Sub

End Class

'x: 아래에서 위로 몇번?
'y: 왼쪽에서 오른쪽으로 몇번?

'info 파일 구조

'title= - puzzle 
'producerName=puzzle
'buttonX=8
'buttonY=8
'chain=3
'squareButton=true
'landscape=true



'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
