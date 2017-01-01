Public Class NoticesNAd

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub NoticesNAd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If (MainProjectLoader.AdsenseHandler <> "NotYet") Then
        '    Me.webAd.Navigate("http://unitor.esy.es/UnitorConfig/info.html")
        'End If
        Me.webInfo.Refresh()
        Me.webAd.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.webInfo.Refresh()
        Me.webAd.Refresh()
    End Sub
End Class