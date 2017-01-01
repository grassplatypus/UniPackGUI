Public Class SplashScreen

    Private Sub lblHomepageGo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblHomepageGo.LinkClicked
        Dim process As New Process
        process.StartInfo.FileName = "http://www.unitor.esy.es"
        process.Start()
    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Threading.ThreadPool.QueueUserWorkItem(AddressOf OpUp)
        OpUp()
        Me.lblVersion.Text = My.Application.Info.Version.ToString
    End Sub

    Private Sub OpUp()

        Me.Opacity = 0
        Dim tmr As New Timer
        tmr.Interval = 100
        tmr.Start()
        AddHandler tmr.Tick, Sub()
                                 Me.Opacity += 0.1
                                 If Me.Opacity = 1 Then
                                     tmr.Stop()
                                     Threading.Thread.Sleep(500)
                                     frmStart.Show()
                                     Me.Close()
                                 End If

                             End Sub

    End Sub
End Class