Public Class AutoPlayControler

    Private Sub waitgo_Click(sender As Object, e As EventArgs) Handles btnWaitGo.Click
        If (MainProjectLoader.autoplay_stat = "Go") Then
            MainProjectLoader.autoplay_stat = "Wait"
            Me.btnWaitGo.Text = "Play"
        ElseIf (MainProjectLoader.autoplay_stat = "Wait") Then
            MainProjectLoader.autoplay_stat = "Go"
            Me.btnWaitGo.Text = "Pause"
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        MainProjectLoader.autoplay_stat = "End"
        Me.Close()
    End Sub
End Class