Imports System.IO
Imports System.Text

Public Class setting_unitor

    'Items for Settings
    '- Support for 0 loop number LED
    '- UniPackWW URL Setting (Auto Retrieve from Server)
    '- UniPackWW URL Setting (URL)


    Private Sub cbAutoPlay_Hover(sender As Object, e As EventArgs)
        Me.rtbHelp.Text = "Auto Player helps you to test(or play!) UniPack. It is similar to Official UniPad's auto play function, but it doesn't mind f (off) command because it is 'useless'. This program just click the button programmatically."
    End Sub

    Private Sub cbCheckError_Hover(sender As Object, e As EventArgs)
        Me.rtbHelp.Text = "For user experiment, Unitor do not show errors while playing (clicking) button of main screen. But if you want to find errors, check this. (Default is not checked.)"
    End Sub

    Private Sub cb0LoopLED_CheckedChanged(sender As Object, e As EventArgs) Handles cb0LoopLED.MouseHover, cbStrictLength.MouseHover, cb0LoopSound.MouseHover
        Me.rtbHelp.Text = "Enable support for LEDs which loop number is 0. (ex: 1 4 5 0 and 1 3 5 0 b) But be carful! It uses too much CPU usage! When I tested, it used 80% of CPU! This may cause a lot of lags!"
    End Sub

    Private Sub cb0LoopLED_CheckedChanged_1(sender As Object, e As EventArgs) Handles cb0LoopLED.CheckedChanged
        If (MainProjectLoader.init = False) Then
            If (cb0LoopLED.Checked = True) Then
                Dim result = MessageBox.Show("Warning! Enabling this can cause a lot of CPU usage especially during AutoPlay process! You should know what you are doing! If your computer is 'nice' and understood everything, you can continue. Do you want to enable this option?", "CPU usage warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    MainProjectLoader.setting_list_tmp(0) = 1
                Else
                    Me.cb0LoopLED.Checked = False
                End If
            Else
                MainProjectLoader.setting_list_tmp(0) = 0

            End If
        Else
            MainProjectLoader.init = False
            MainProjectLoader.setting_list_tmp(0) = 1
        End If
    End Sub

    Private Sub cbRetrieveURL_CheckedChanged(sender As Object, e As EventArgs) Handles cbRetrieveURL.CheckedChanged
        If (cb0LoopLED.Checked = True) Then
            MainProjectLoader.setting_list_tmp(1) = 1
            Me.txtURL.Enabled = False
        Else
            MainProjectLoader.setting_list_tmp(1) = 0
            Me.txtURL.Enabled = True
        End If
    End Sub

    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged


        MainProjectLoader.setting_list_tmp(2) = Me.txtURL.Text
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_BackColorChanged(sender As Object, e As EventArgs) Handles btnSave.BackColorChanged

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'MsgBox(settings(0) & vbNewLine & settings(1) & vbNewLine & settings(2))

        If (MainProjectLoader.setting_list_tmp(2).Contains(" ") = True) Then
            MessageBox.Show("You can't contain space (' ') in UniPackWW Custom Server URL!", "Blank not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        MainProjectLoader.settings(0) = CInt(Me.cb0LoopLED.Checked) * (-1)
        MainProjectLoader.settings(1) = CInt(Me.cbRetrieveURL.Checked) * (-1)
        MainProjectLoader.settings(2) = Me.txtURL.Text
        MainProjectLoader.settings(3) = CInt(Me.cb0LoopSound.Checked) * (-1)
        MainProjectLoader.settings(4) = CInt(Me.cbStrictLength.Checked) * (-1)


        Dim fs As FileStream = File.Create("settings.txt")
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("ZeroLEDSupport " & MainProjectLoader.settings(0) & vbNewLine & "GetURLFromServer " & MainProjectLoader.settings(1) & vbNewLine & "CustomURL " & MainProjectLoader.settings(2) & vbNewLine & "ZeroSoundSupport " & MainProjectLoader.settings(3) & vbNewLine & "StrictSoundLen " & MainProjectLoader.settings(4))
        fs.Write(info, 0, info.Length)
        fs.Close()
        Me.Close()

    End Sub

    Private Sub setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cb0LoopLED.Checked = CBool(MainProjectLoader.settings(0))

        Me.cbRetrieveURL.Checked = CBool(MainProjectLoader.settings(1))
        Me.txtURL.Text = MainProjectLoader.settings(2)
        Me.cb0LoopSound.Checked = CBool(MainProjectLoader.settings(3))
        Me.cbStrictLength.Checked = CBool(MainProjectLoader.settings(4))

    End Sub

  

    Private Sub cbStrictLength_Hover(sender As Object, e As EventArgs) Handles cbStrictLength.MouseHover
        Me.rtbHelp.Text = "Strict Sound Length of Sound to 6 seconds during playing. If your sound length is 7 seconds, Unitor will play only until 6 seconds. Sound part from 6.0001 to 7.0000 will not be played. This is due to Android SoundPool Library's limit."
    End Sub

    Private Sub cb0LoopSound_Hover(sender As Object, e As EventArgs) Handles cb0LoopSound.MouseHover
        Me.rtbHelp.Text = "Enable Full Support for Sound Loop Code 0. (eg: 1 3 5 mywav.wav 0)"

    End Sub
End Class