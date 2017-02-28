Public Class Loadingfrm

    Private Sub workPgLabel_Click(sender As Object, e As EventArgs) Handles workPgLabel.Click

    End Sub

    Private Sub Loadingfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Private Sub MeClose(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Cursor = Cursors.Arrow
    End Sub
End Class