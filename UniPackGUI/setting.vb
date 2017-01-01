Public Class setting

    
    Private Sub cbAutoPlay_Hover(sender As Object, e As EventArgs)
        Me.rtbHelp.Text = "Auto Player helps you to test(or play!) UniPack. It is similar to Official UniPad's auto play function, but it doesn't mind f (off) command because it is 'useless'. This program just click the button programmatically."
    End Sub

    Private Sub cbCheckError_Hover(sender As Object, e As EventArgs)
        Me.rtbHelp.Text = "For user experiment, Unitor do not show errors while playing (clicking) button of main screen. But if you want to find errors, check this. (Default is not checked.)"
    End Sub
End Class