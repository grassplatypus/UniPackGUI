Imports System.Text
Imports System.IO

Public Class keySoundEdit

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim path As String = My.Application.Info.DirectoryPath & "\Workspace\info"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.RichTextBox1.Text)
        fs.Write(info, 0, info.Length)
        fs.Close()
        Threading.ThreadPool.QueueUserWorkItem(AddressOf reloadSound)
    End Sub

    Private Sub reloadSound()
        Dim isErr As Boolean = False
        Me.Invoke(Sub()


                      Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                      Loadingfrm.Show()

                      Loadingfrm.workPgLabel.Text = "Initializing..."

                  End Sub)

        Me.Invoke(Sub()
                      Me.Enabled = False
                      Me.lblStat.Text = "Saving..."
                  End Sub)
        Try
            ReDim MainProjectLoader.soundfiles(8, 8, 8, 151)
            For t1 = 0 To 8
                For t2 = 0 To 8
                    For t3 = 0 To 8
                        For t4 = 0 To 150
                            Try
                                MainProjectLoader.Snds.Close(t1 & " " & t2 & " " & t3 & " " & t4)

                            Catch
                            End Try
                        Next

                    Next

                Next
            Next
            ReDim MainProjectLoader.soundfiles_now(9, 9, 9)
            ReDim MainProjectLoader.keysounds_max(9, 9, 9)
            MainProjectLoader.Invoke(Sub()

                                         Loadingfrm.workPgLabel.Text = "Stat: Loading Sounds... => Counting..."
                                     End Sub)
            Dim lines As New List(Of String)(IO.File.ReadAllLines("Workspace\keySound"))
            lines.RemoveAll(Function(s) s.Trim = "")
            Dim keysounds() As String = lines.ToArray
            Dim keysounds_tmp() As String
            MainProjectLoader.Invoke(Sub()
                                         Loadingfrm.LoadingPg.Style = ProgressBarStyle.Blocks
                                         Loadingfrm.LoadingPg.Maximum = keysounds.Length
                                         Loadingfrm.LoadingPg.Value = 0
                                     End Sub)
            For index = 0 To keysounds.Length - 1
                MainProjectLoader.Invoke(Sub()
                                             Loadingfrm.workPgLabel.Text = "Stat: Loading Sounds... => " & index & "/" & keysounds.Length
                                             ' Loadingfrm.Update()
                                         End Sub)
                keysounds_tmp = keysounds(index).Split(" ")
                If (keysounds_tmp.Length = 5) Then
                    Throw New AggregateException("Unsupported UniPack type: We don't support 5th parameter. (loop number)")
                ElseIf (keysounds_tmp.Length = 4) Then
                    If (keysounds_tmp(0) > MainProjectLoader.tbPackChains.Text) Then
                        Dim isChecked As Boolean
                        Me.Invoke(Sub()
                                      isChecked = Me.cbIncreaseChain.Checked
                                  End Sub)
                        If (isChecked = False) Then
                            Throw New AggregateException("Bad chain number (bigger than maximum the number of chians  on Line " & index)
                        Else
                            MainProjectLoader.tbPackChains.Text = keysounds_tmp(0)
                        End If
                    End If
                    Dim tmp As Integer = MainProjectLoader.keysounds_max(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2))

                    MainProjectLoader.soundfiles(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2), tmp) = "Workspace\sounds\" & keysounds_tmp(3)

                    MainProjectLoader.keysounds_max(keysounds_tmp(0), keysounds_tmp(1), keysounds_tmp(2)) += 1
                    MainProjectLoader.Invoke(Sub()
                                                 MainProjectLoader.Snds.AddSound(keysounds_tmp(0) & " " & keysounds_tmp(1) & " " & keysounds_tmp(2) & " " & tmp, "Workspace\sounds\" & keysounds_tmp(3))
                                             End Sub)

                Else
                    Throw New AggregateException("Invaild keySound structure on Line " & index + 1)
                    Exit For
                End If
                MainProjectLoader.Invoke(Sub()
                                             Loadingfrm.LoadingPg.Value += 1
                                         End Sub)

            Next
            MainProjectLoader.Invoke(Sub()
                                         MainProjectLoader.tbPackChains.Text = MainProjectLoader.tbPackChains.Text
                                     End Sub)
            For index As Integer = 1 To MainProjectLoader.tbPackChains.Text
                MainProjectLoader.Invoke(Sub()
                                             MainProjectLoader.listChain.Items.Add(index.ToString)
                                         End Sub)
            Next
        Catch

            Me.Invoke(Sub()
                          MessageBox.Show("Error Occured! Message:" & Err.Description & vbNewLine & "You should fix this error before closing this window.", "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                          Me.lblStat.Text = "Error"
                      End Sub)
            Exit Sub
        End Try
        Me.Invoke(Sub()
                      Me.Enabled = True
                      Me.lblStat.Text = "Saved"
                  End Sub)
        Me.Invoke(Sub()
                      Loadingfrm.Close()
                      Loadingfrm.LoadingPg.Style = ProgressBarStyle.Marquee
                      MainProjectLoader.listChain.SelectedIndex = 0
                  End Sub)

    End Sub

    Private Sub keySoundEdit_close(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (Me.lblStat.Text = "Not Saved") Then
            Dim result = MessageBox.Show("You didn't save it. Are you sure to close keySound Editor?", "Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.No) Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub keySoundEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RichTextBox1.Text = My.Computer.FileSystem.ReadAllText("Workspace\keySound")
        Me.lblStat.Text = "Saved"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Me.lblStat.Text = "Not Saved") Then
            Dim result = MessageBox.Show("You didn't save it. Are you sure to close keySound Editor?", "Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.Yes) Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Me.lblStat.Text = "Not Saved"
    End Sub
End Class