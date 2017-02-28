
Imports Midi
Public Class midiConnect

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            For i = 0 To Midi.InputDevice.InstalledDevices.Count - 1
                Me.listmidis.Items.Add(Midi.InputDevice.InstalledDevices(i))
            Next

            Dim outputDevice As OutputDevice = outputDevice.InstalledDevices(0)



        Catch
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub midiConnect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class