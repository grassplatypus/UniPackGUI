
Imports Midi
Public Class midiConnect

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim outputDevice As OutputDevice = outputDevice.InstalledDevices(0)
            outputDevice.Open()

            outputDevice.SendNoteOn(Channel.Channel1, Pitch.C4, 80)  'Mddle C, velocity 80
            outputDevice.SendPitchBend(Channel.Channel1, 7000)  '8192 is centered, so 7000 is bent down

        Catch
            MsgBox(Err.Description)
        End Try

    End Sub
End Class