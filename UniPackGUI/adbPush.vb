Imports RegawMOD.Android
Imports System.Security.Cryptography
Imports System.Threading

Public Class adbPush
    Dim device As Device
    Dim android As AndroidController


    'https://github.com/regaw-leinad/AndroidLib-Samples-VB
    'http://forum.xda-developers.com/showthread.php?t=1512685
    'https://github.com/regaw-leinad/AndroidLib

    Private Sub btnUpdateDevice_Click(sender As Object, e As EventArgs) Handles btnUpdateDevice.Click
        '기기목록 업데이트
        Me.listDevice.Items.Clear()


        Dim serial As String

        'Always call UpdateDeviceList() before using AndroidController on devices to get the most updated list
        android.UpdateDeviceList()

        If (android.HasConnectedDevices) Then
            For i = 0 To android.ConnectedDevices.Count - 1
                serial = android.ConnectedDevices(0)
                Device = android.GetConnectedDevice(serial)
                If (Device.State = DeviceState.ONLINE) Then
                    Me.listDevice.Items.Add(Device.BuildProp.GetProp("ro.product.model") & ";" & Device.SerialNumber)
                Else
                    Me.listDevice.Items.Add(Device.BuildProp.GetProp("[NOT ONLINE];" & Device.SerialNumber))
                End If
            Next
            Me.btnUse.Enabled = True
        Else
            MessageBox.Show("Please connect your device!")
            Me.btnUse.Enabled = False
        End If

    End Sub

    Private Sub adbPush_close(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        android.Dispose()
    End Sub

    'Public cmd As AdbCommand
    Private Sub listDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listDevice.SelectedIndexChanged


    End Sub

    Private Sub doSend()
        Me.Invoke(Sub()
                      Me.btnSend.Enabled = False
                  End Sub)
        If (MainProjectLoader.isSaved = False) Then
            Dim result = MessageBox.Show("You didn't saved your UniPack. Do you want to continue ADB sending with unsaved UniPack?", "Not saved", MessageBoxButtons.YesNo)
            If (result = Windows.Forms.DialogResult.No) Then
                Me.Invoke(Sub()
                              Me.btnSend.Enabled = True
                          End Sub)
                Exit Sub

            End If
        End If
        If (Me.folderlist.Items.Contains(Me.TextBox1.Text) = True) Then
            MessageBox.Show(Me.TextBox1.Text & " already exists! Can't continue sending!", "Already Exists!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Invoke(Sub()
                          Me.btnSend.Enabled = True
                      End Sub)
            Exit Sub
        End If
        Dim device2 As Device
        Me.Invoke(Sub()
                      device2 = android.GetConnectedDevice(Me.listDevice.SelectedItem.ToString.Split(";").Last)
                  End Sub)
        If (device2.State <> DeviceState.ONLINE) Then
            MessageBox.Show("Please check if device " & Me.listDevice.SelectedItem.ToString.Split(";").Last & " is online! You can re-check it by pressing Update Device List. Device must be turned on. But sideload or recovery is not allowed!")
            Me.Invoke(Sub()
                          Me.btnSend.Enabled = True
                      End Sub)
            Exit Sub
        End If
        'Adb.ExecuteAdbCommandReturnExitCode(cmd)


        Adb.FormAdbShellCommand(device2, False, "mkdir /mnt/sdcard/Unipad/" & Me.TextBox1.Text)


        If (device.PushFile("Workspace/.", "/mnt/sdcard/Unipad/" & Me.TextBox1.Text) = False) Then
            MessageBox.Show("Failed to send to device!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Succeed! You can enjoy your pack in your device's UniPad right now!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Me.rtbInfoPush.Text = Me.rtbInfoPush.Text & vbNewLine & vbNewLine & "Path: /mnt/sdcard/Unipad/" & strResult

        End If
        Me.Invoke(Sub()
                      Me.btnSend.Enabled = True
                      Me.btnUpdateDevice.Enabled = True
                      Me.TextBox1.Enabled = True
                  End Sub)
    End Sub


    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Me.btnUpdateDevice.Enabled = False
        Me.TextBox1.Enabled = False
        ThreadPool.QueueUserWorkItem(AddressOf doSend)
    End Sub

    Private Sub adbPush_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.btnUse.Enabled = False
        Me.btnSend.Enabled = False
        android = AndroidController.Instance
        Me.lblPackname.Text = "Pack Name: " & MainProjectLoader.tbPackName.Text
        Me.folderlist.Visible = False
        Dim strToHash As String
        strToHash = Now.ToString

        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Me.TextBox1.Text = strResult
    End Sub

    Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        If (Me.btnUse.Text = "Use This Device") Then
            Me.Invoke(Sub()
                          Me.RichTextBox1.Clear()
                      End Sub)
            If (Me.listDevice.SelectedItems.Count = 0) Then
                MessageBox.Show("Please select any device!", "Device not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Invoke(Sub()
                              Me.RichTextBox1.AppendText("[Error] Device is offline." & vbNewLine)
                          End Sub)
                Exit Sub
            End If
            If (Me.listDevice.SelectedItem.ToString.Split(";").First = "[NOT ONLINE]") Then
                MessageBox.Show("Please check if device " & Me.listDevice.SelectedItem.ToString.Split(";").Last & " is online! You can re-check it by pressing Update Device List.")
                Me.Invoke(Sub()
                              Me.RichTextBox1.AppendText("[Error] Device is offline." & vbNewLine)
                          End Sub)
                Exit Sub
            End If
            Me.Invoke(Sub()
                          Me.RichTextBox1.AppendText("[Info] Connecting to Device" & vbNewLine)
                      End Sub)
            Dim device2 As Device = android.GetConnectedDevice(Me.listDevice.SelectedItem.ToString.Split(";").Last)
            Me.Invoke(Sub()
                          Me.folderlist.Visible = True
                          Me.btnUse.Text = "Select Other Device"
                          Me.listDevice.Enabled = False
                      End Sub)
            Me.Invoke(Sub()
                          Me.RichTextBox1.AppendText("[Info] Getting /mnt/sdcard/Unipad directory files & folders..." & vbNewLine)
                      End Sub)

            Adb.FormAdbShellCommand(device2, False, "ls /mnt/sdcard/Unipad > /mnt/sdcard/Unipad/folders.txt")
            device2.PullFile("/mnt/sdcard/Unipad/folders.txt", "TmpLED/folders.txt")
            Me.Invoke(Sub()
                          Me.RichTextBox1.AppendText("[Info] Deleting cache file in your device..." & vbNewLine)
                      End Sub)
            Adb.FormAdbShellCommand(device2, False, "rm -f /mnt/sdcard/Unipad/folders.txt")
            Me.Invoke(Sub()
                          Me.RichTextBox1.AppendText("[Info] Reading cache file..." & vbNewLine)
                      End Sub)
            If (My.Computer.FileSystem.FileExists("TmpLED/folders.txt") = True) Then
                Dim reader() As String = IO.File.ReadAllLines("TmpLED/folders.txt")
                For Each dataname In reader
                    Me.Invoke(Sub()
                                  Me.folderlist.Items.Add(dataname)

                              End Sub)
                Next
                Me.Invoke(Sub()
                              Me.btnUse.Enabled = True
                              Me.btnSend.Enabled = True
                              Me.RichTextBox1.AppendText("[Info] Listed files & folders in your Unipad Folder." & vbNewLine)
                          End Sub)
            Else
                Me.Invoke(Sub()
                              Me.btnUse.Enabled = True
                              Me.btnSend.Enabled = True
                              Me.RichTextBox1.AppendText("[Error] Failed to read cache file. Maybe your device doesn't compabitable with ADB." & vbNewLine)
                          End Sub)
            End If
        Else
            Me.Invoke(Sub()
                          Me.btnUse.Text = "Use This Device"
                          Me.listDevice.Enabled = True
                          Me.folderlist.Items.Clear()
                          Me.folderlist.Visible = False
                          Me.btnSend.Enabled = False
                      End Sub)
        End If
    End Sub
End Class