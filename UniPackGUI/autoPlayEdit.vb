Imports System.IO
Imports System.Text

Public Class autoPlayEdit
    Private Sub form_close(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (Me.lblStat.Text = "Not Saved") Then
            Dim result = MessageBox.Show("You didn't save it. Are you sure to close autoPlay Editor?", "Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.No) Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub autoPlayEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (My.Computer.FileSystem.FileExists("Workspace\autoPlay") = False) Then
            Me.lblStat.Text = "Not Exists"
            Me.btnRemoveautoPlay.Enabled = False
        Else
            Me.RichTextBox1.Text = My.Computer.FileSystem.ReadAllText("Workspace\autoPlay")
            Me.lblStat.Text = "Saved"
            Me.btnRemoveautoPlay.Enabled = True
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Me.lblStat.Text = "Not Saved"
    End Sub

    Private Sub btnRemoveautoPlay_Click(sender As Object, e As EventArgs) Handles btnRemoveautoPlay.Click
        My.Computer.FileSystem.DeleteFile("Workspace\autoPlay")
        Me.lblStat.Text = "Not Exists"
        Me.btnRemoveautoPlay.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim path As String = "Workspace\autoPlay"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.RichTextBox1.Text)
        fs.Write(info, 0, info.Length)
        fs.Close()
        Me.lblStat.Text = "Saved"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If (Me.lblStat.Text = "Not Saved") Then
            Dim result = MessageBox.Show("You didn't save it. Are you sure to close keySound Editor?", "Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.Yes) Then
                Me.Close()
            End If
        End If
    End Sub
End Class