Imports System.Text
Imports System.IO
Imports System.Threading

Public Class frmLED
    Dim xc As Integer
    Dim yc As Integer
    Dim nowchain As Integer
    Dim recent As Integer
    Dim isFirst As Boolean
    Private changed As Boolean

    '다중매핑지원용
    Dim multimap As Integer
    Dim nowmap As Integer
    Dim led As New ledReturn

    '2-1 = Red
    '2-2 = Yellow
    '2-5 = Aqua
    '2-8 = Fuchsia
    '3-3 = Lime
    '3-4 = Teal
    '4-1 = Maroon
    '4-3 = Green
    '4-5 = Blue
    '4-7 = Purple
    '5-5 = Navy
    '6-1 = Black
    '6-2 = Olive
    '6-4 = Gray
    '6-6 = Silver
    '6-8 = White
    Dim WrongColors() As String = {"Red", "Yellow", "Aqua", "Fuchsia", "Lime", "Teal", "Maroon", "Green", "Blue", "Purple", "Navy", "Black", "Olive", "Gray", "Silver", "White"}

    Public Sub LoadLED(chain As Integer, xcode As Integer, ycode As Integer)
        MainProjectLoader.isSaved = False
        Me.rtbLED.Enabled = True
        Me.tabHelper.Enabled = True
        Me.btnLEDtest.Enabled = True
        uni1_1.BackColor = Color.Gray
        uni1_2.BackColor = Color.Gray
        uni1_3.BackColor = Color.Gray
        uni1_4.BackColor = Color.Gray
        uni1_5.BackColor = Color.Gray
        uni1_6.BackColor = Color.Gray
        uni1_7.BackColor = Color.Gray
        uni1_8.BackColor = Color.Gray
        uni2_1.BackColor = Color.Gray
        uni2_2.BackColor = Color.Gray
        uni2_3.BackColor = Color.Gray
        uni2_4.BackColor = Color.Gray
        uni2_5.BackColor = Color.Gray
        uni2_6.BackColor = Color.Gray
        uni2_7.BackColor = Color.Gray
        uni2_8.BackColor = Color.Gray
        uni3_1.BackColor = Color.Gray
        uni3_2.BackColor = Color.Gray
        uni3_3.BackColor = Color.Gray
        uni3_4.BackColor = Color.Gray
        uni3_5.BackColor = Color.Gray
        uni3_6.BackColor = Color.Gray
        uni3_7.BackColor = Color.Gray
        uni3_8.BackColor = Color.Gray
        uni4_1.BackColor = Color.Gray
        uni4_2.BackColor = Color.Gray
        uni4_3.BackColor = Color.Gray
        uni4_4.BackColor = Color.Gray
        uni4_5.BackColor = Color.Gray
        uni4_6.BackColor = Color.Gray
        uni4_7.BackColor = Color.Gray
        uni4_8.BackColor = Color.Gray
        uni5_1.BackColor = Color.Gray
        uni5_2.BackColor = Color.Gray
        uni5_3.BackColor = Color.Gray
        uni5_4.BackColor = Color.Gray
        uni5_5.BackColor = Color.Gray
        uni5_6.BackColor = Color.Gray
        uni5_7.BackColor = Color.Gray
        uni5_8.BackColor = Color.Gray
        uni6_1.BackColor = Color.Gray
        uni6_2.BackColor = Color.Gray
        uni6_3.BackColor = Color.Gray
        uni6_4.BackColor = Color.Gray
        uni6_5.BackColor = Color.Gray
        uni6_6.BackColor = Color.Gray
        uni6_7.BackColor = Color.Gray
        uni6_8.BackColor = Color.Gray
        uni7_1.BackColor = Color.Gray
        uni7_2.BackColor = Color.Gray
        uni7_3.BackColor = Color.Gray
        uni7_4.BackColor = Color.Gray
        uni7_5.BackColor = Color.Gray
        uni7_6.BackColor = Color.Gray
        uni7_7.BackColor = Color.Gray
        uni7_8.BackColor = Color.Gray
        uni8_1.BackColor = Color.Gray
        uni8_2.BackColor = Color.Gray
        uni8_3.BackColor = Color.Gray
        uni8_4.BackColor = Color.Gray
        uni8_5.BackColor = Color.Gray
        uni8_6.BackColor = Color.Gray
        uni8_7.BackColor = Color.Gray
        uni8_8.BackColor = Color.Gray
        Me.rtbLED.Clear()
        changed = False

        nowchain = chain
        xc = xcode
        yc = ycode
        Me.listMultiMaps.Items.Clear()
        Me.rtbLED.Text = ""
        multimap = 0
        nowmap = 97
        Dim fileReader As String
        If (MainProjectLoader.ledfiles_max(chain, xcode, ycode) > 1) Then '다중 매핑 지원
            For index = 0 To MainProjectLoader.ledfiles_max(chain, xcode, ycode) - 1
                Dim a = MainProjectLoader.ledfiles(chain, xcode, ycode, index).Split("\").Last.Split(" ")


                If (a.Count = 4) Then
                    Me.listMultiMaps.Items.Add("SIngle;" & a.Last)
                ElseIf (a.Count = 5) Then
                    Me.listMultiMaps.Items.Add(a(a.Count - 1) & ";" & a(a.Count - 2))
                End If
            Next
            isFirst = True
            Me.listMultiMaps.SelectedIndex = 0
            fileReader = My.Computer.FileSystem.ReadAllText(MainProjectLoader.ledfiles(chain, xcode, ycode, 0))
            'MsgBox(fileReader)
            Me.rtbLED.Text = fileReader
            recent = 0
        ElseIf (MainProjectLoader.ledfiles_max(chain, xcode, ycode) = 1) Then

            If (MainProjectLoader.ledfiles(chain, xcode, ycode, 0).Split("\").Last.Split(" ").Last = 0) Then
                Me.listMultiMaps.Items.Add("Single;0")
            ElseIf (MainProjectLoader.ledfiles(chain, xcode, ycode, 0).Split("\").Last.Split(" ").Last = 1) Then
                Me.listMultiMaps.Items.Add("Single;1")
            Else
                Me.Invoke(Sub()
                              MessageBox.Show("Wrong Loop number '" & MainProjectLoader.ledfiles(chain, xcode, ycode, 0).Split("\").Last.Split(" ").Last & "'! If you want to do Multi Mapping, add like 1 1 1 0 a, 1 1 2 b!", "Loop number error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                          End Sub)
                Exit Sub
            End If
            fileReader = My.Computer.FileSystem.ReadAllText(MainProjectLoader.ledfiles(chain, xcode, ycode, 0))
            'MsgBox(fileReader)
            Me.rtbLED.Text = fileReader
            isFirst = True
            Me.listMultiMaps.SelectedIndex = 0
        Else
            Me.rtbLED.Enabled = False
            Me.tabHelper.Enabled = False
            Me.btnLEDtest.Enabled = False
        End If
        If (Me.listMultiMaps.Items.Count > 0) Then
            Me.listMultiMaps.Enabled = True
        End If

    End Sub

    Private Sub checkUseLaunchColor_CheckedChanged(sender As Object, e As EventArgs) Handles checkUseLaunchColor.CheckedChanged
        If (Me.checkUseLaunchColor.CheckState = CheckState.Checked) Then
            Me.btnPickColor.Enabled = False
            Me.cbLaunchPadColor.Visible = True
        Else
            Me.btnPickColor.Enabled = True
            Me.cbLaunchPadColor.Visible = False
        End If
    End Sub
    'uni1_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & 
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles textColor.TextChanged
        Try
            Dim htmlcode As String = Me.textColor.Text
            If (Me.checkUseLaunchColor.CheckState = CheckState.Checked) Then
                If (IsNumeric(Me.textColor.Text) = False) Then
                    If (Me.textColor.Text = Not "") Then
                        MessageBox.Show("Only numbers available when enabled 'Use Launchpad Colors'! (0~128)", "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'Me.textColor.Undo()
                        Exit Sub
                    End If
                End If

            ElseIf (Me.checkUseLaunchColor.CheckState = CheckState.Unchecked) Then
                MessageBox.Show("Launchpad color is 0~128!!", "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.textColor.Undo()
                Exit Sub
            End If

            Me.btnColorTest.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & htmlcode)

        Catch
        End Try
    End Sub

    Private Sub btnPickColor_Click(sender As Object, e As EventArgs) Handles btnPickColor.Click
        Dim result = Me.colorPick.ShowDialog()
        If (result = Windows.Forms.DialogResult.OK) Then
            'Me.textColor.Text = System.Drawing.ColorTranslator.ToHtml(Me.colorPick.Color)

            If (ColorTranslator.ToHtml(Me.colorPick.Color) = "Red") Then
                Me.textColor.Text = "ff0000"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Yellow") Then
                Me.textColor.Text = "ffff00"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Aqua") Then
                Me.textColor.Text = "00ffff"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Fuchsia") Then
                Me.textColor.Text = "ff0080"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Lime") Then
                Me.textColor.Text = "99ff00"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Teal") Then
                Me.textColor.Text = "008080"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Maroon") Then
                Me.textColor.Text = "800000"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Green") Then
                Me.textColor.Text = "00ff00"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Blue") Then
                Me.textColor.Text = "0000ff"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Purple") Then
                Me.textColor.Text = "800080"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Navy") Then
                Me.textColor.Text = "000080"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Black") Then
                Me.textColor.Text = "000000"
                MessageBox.Show("Color 'Black' is not recommended color!")
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Olive") Then
                Me.textColor.Text = "808000"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Grey") Then
                Me.textColor.Text = "d3d3d3"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Gray") Then
                Me.textColor.Text = "d3d3d3"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "Sliver") Then
                Me.textColor.Text = "cccccc"
            ElseIf (ColorTranslator.ToHtml(Me.colorPick.Color) = "White") Then
                Me.textColor.Text = "ffffff"
            Else
                '2-1 = Red
                '2-2 = Yellow
                '2-5 = Aqua
                '2-8 = Fuchsia
                '3-3 = Lime
                '3-4 = Teal
                '4-1 = Maroon
                '4-3 = Green
                '4-5 = Blue
                '4-7 = Purple
                '5-5 = Navy
                '6-1 = Black
                '6-2 = Olive
                '6-4 = Gray
                '6-6 = Silver
                '6-8 = White
                Me.textColor.Text = ColorTranslator.ToHtml(Me.colorPick.Color)
            End If

        End If
    End Sub
#Region "XY"

    Private Sub uni1_1_Click(sender As Object, e As EventArgs) Handles uni1_1.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni1_2_Click(sender As Object, e As EventArgs) Handles uni1_2.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni1_3_Click(sender As Object, e As EventArgs) Handles uni1_3.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni1_4_Click(sender As Object, e As EventArgs) Handles uni1_4.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni1_5_Click(sender As Object, e As EventArgs) Handles uni1_5.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni1_6_Click(sender As Object, e As EventArgs) Handles uni1_6.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni1_7_Click(sender As Object, e As EventArgs) Handles uni1_7.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni1_8_Click(sender As Object, e As EventArgs) Handles uni1_8.Click
        Me.txtOn_X.Text = 1
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 1
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni2_1_Click(sender As Object, e As EventArgs) Handles uni2_1.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni2_2_Click(sender As Object, e As EventArgs) Handles uni2_2.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni2_3_Click(sender As Object, e As EventArgs) Handles uni2_3.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni2_4_Click(sender As Object, e As EventArgs) Handles uni2_4.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni2_5_Click(sender As Object, e As EventArgs) Handles uni2_5.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni2_6_Click(sender As Object, e As EventArgs) Handles uni2_6.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni2_7_Click(sender As Object, e As EventArgs) Handles uni2_7.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni2_8_Click(sender As Object, e As EventArgs) Handles uni2_8.Click
        Me.txtOn_X.Text = 2
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 2
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni3_1_Click(sender As Object, e As EventArgs) Handles uni3_1.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni3_2_Click(sender As Object, e As EventArgs) Handles uni3_2.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni3_3_Click(sender As Object, e As EventArgs) Handles uni3_3.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni3_4_Click(sender As Object, e As EventArgs) Handles uni3_4.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni3_5_Click(sender As Object, e As EventArgs) Handles uni3_5.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni3_6_Click(sender As Object, e As EventArgs) Handles uni3_6.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni3_7_Click(sender As Object, e As EventArgs) Handles uni3_7.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni3_8_Click(sender As Object, e As EventArgs) Handles uni3_8.Click
        Me.txtOn_X.Text = 3
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 3
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni4_1_Click(sender As Object, e As EventArgs) Handles uni4_1.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni4_2_Click(sender As Object, e As EventArgs) Handles uni4_2.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni4_3_Click(sender As Object, e As EventArgs) Handles uni4_3.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni4_4_Click(sender As Object, e As EventArgs) Handles uni4_4.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni4_5_Click(sender As Object, e As EventArgs) Handles uni4_5.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni4_6_Click(sender As Object, e As EventArgs) Handles uni4_6.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni4_7_Click(sender As Object, e As EventArgs) Handles uni4_7.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni4_8_Click(sender As Object, e As EventArgs) Handles uni4_8.Click
        Me.txtOn_X.Text = 4
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 4
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni5_1_Click(sender As Object, e As EventArgs) Handles uni5_1.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni5_2_Click(sender As Object, e As EventArgs) Handles uni5_2.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni5_3_Click(sender As Object, e As EventArgs) Handles uni5_3.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni5_4_Click(sender As Object, e As EventArgs) Handles uni5_4.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni5_5_Click(sender As Object, e As EventArgs) Handles uni5_5.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni5_6_Click(sender As Object, e As EventArgs) Handles uni5_6.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni5_7_Click(sender As Object, e As EventArgs) Handles uni5_7.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni5_8_Click(sender As Object, e As EventArgs) Handles uni5_8.Click
        Me.txtOn_X.Text = 5
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 5
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni6_1_Click(sender As Object, e As EventArgs) Handles uni6_1.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni6_2_Click(sender As Object, e As EventArgs) Handles uni6_2.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni6_3_Click(sender As Object, e As EventArgs) Handles uni6_3.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni6_4_Click(sender As Object, e As EventArgs) Handles uni6_4.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni6_5_Click(sender As Object, e As EventArgs) Handles uni6_5.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni6_6_Click(sender As Object, e As EventArgs) Handles uni6_6.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni6_7_Click(sender As Object, e As EventArgs) Handles uni6_7.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni6_8_Click(sender As Object, e As EventArgs) Handles uni6_8.Click
        Me.txtOn_X.Text = 6
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 6
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni7_1_Click(sender As Object, e As EventArgs) Handles uni7_1.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni7_2_Click(sender As Object, e As EventArgs) Handles uni7_2.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni7_3_Click(sender As Object, e As EventArgs) Handles uni7_3.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni7_4_Click(sender As Object, e As EventArgs) Handles uni7_4.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni7_5_Click(sender As Object, e As EventArgs) Handles uni7_5.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni7_6_Click(sender As Object, e As EventArgs) Handles uni7_6.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni7_7_Click(sender As Object, e As EventArgs) Handles uni7_7.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni7_8_Click(sender As Object, e As EventArgs) Handles uni7_8.Click
        Me.txtOn_X.Text = 7
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 7
        Me.tbTurnOffY.Text = 8
    End Sub

    Private Sub uni8_1_Click(sender As Object, e As EventArgs) Handles uni8_1.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 1
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 1
    End Sub

    Private Sub uni8_2_Click(sender As Object, e As EventArgs) Handles uni8_2.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 2
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 2
    End Sub

    Private Sub uni8_3_Click(sender As Object, e As EventArgs) Handles uni8_3.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 3
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 3
    End Sub

    Private Sub uni8_4_Click(sender As Object, e As EventArgs) Handles uni8_4.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 4
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 4
    End Sub

    Private Sub uni8_5_Click(sender As Object, e As EventArgs) Handles uni8_5.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 5
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 5
    End Sub

    Private Sub uni8_6_Click(sender As Object, e As EventArgs) Handles uni8_6.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 6
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 6
    End Sub

    Private Sub uni8_7_Click(sender As Object, e As EventArgs) Handles uni8_7.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 7
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 7
    End Sub

    Private Sub uni8_8_Click(sender As Object, e As EventArgs) Handles uni8_8.Click
        Me.txtOn_X.Text = 8
        Me.txtOn_Y.Text = 8
        Me.tbTurnOffX.Text = 8
        Me.tbTurnOffY.Text = 8
    End Sub
#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If changed = True Then
            Dim result = MessageBox.Show("You didn't save this opened LED script. Do you want to save?", "Not Saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If (result = Windows.Forms.DialogResult.Yes) Then
                Dim path As String
                path = MainProjectLoader.ledfiles(nowchain, xc, yc, recent)

                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(path)

                ' Add text to the file.
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.rtbLED.Text)
                fs.Write(info, 0, info.Length)
                fs.Close()
                MainProjectLoader.ledfiles_now(nowchain, xc, yc) = 0
                MainProjectLoader.soundfiles_now(nowchain, xc, yc) = 0
                MainProjectLoader.ledfiles_max(nowchain, xc, yc) = Me.listMultiMaps.Items.Count
            ElseIf (result = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If
        End If
        
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) ' Handles btnOk.Click
        Dim path As String = MainProjectLoader.ledfiles(nowchain, xc, yc, recent)

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.rtbLED.Text)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnLEDtest.Click
        uni1_1.BackColor = Color.Gray
        uni1_2.BackColor = Color.Gray
        uni1_3.BackColor = Color.Gray
        uni1_4.BackColor = Color.Gray
        uni1_5.BackColor = Color.Gray
        uni1_6.BackColor = Color.Gray
        uni1_7.BackColor = Color.Gray
        uni1_8.BackColor = Color.Gray
        uni2_1.BackColor = Color.Gray
        uni2_2.BackColor = Color.Gray
        uni2_3.BackColor = Color.Gray
        uni2_4.BackColor = Color.Gray
        uni2_5.BackColor = Color.Gray
        uni2_6.BackColor = Color.Gray
        uni2_7.BackColor = Color.Gray
        uni2_8.BackColor = Color.Gray
        uni3_1.BackColor = Color.Gray
        uni3_2.BackColor = Color.Gray
        uni3_3.BackColor = Color.Gray
        uni3_4.BackColor = Color.Gray
        uni3_5.BackColor = Color.Gray
        uni3_6.BackColor = Color.Gray
        uni3_7.BackColor = Color.Gray
        uni3_8.BackColor = Color.Gray
        uni4_1.BackColor = Color.Gray
        uni4_2.BackColor = Color.Gray
        uni4_3.BackColor = Color.Gray
        uni4_4.BackColor = Color.Gray
        uni4_5.BackColor = Color.Gray
        uni4_6.BackColor = Color.Gray
        uni4_7.BackColor = Color.Gray
        uni4_8.BackColor = Color.Gray
        uni5_1.BackColor = Color.Gray
        uni5_2.BackColor = Color.Gray
        uni5_3.BackColor = Color.Gray
        uni5_4.BackColor = Color.Gray
        uni5_5.BackColor = Color.Gray
        uni5_6.BackColor = Color.Gray
        uni5_7.BackColor = Color.Gray
        uni5_8.BackColor = Color.Gray
        uni6_1.BackColor = Color.Gray
        uni6_2.BackColor = Color.Gray
        uni6_3.BackColor = Color.Gray
        uni6_4.BackColor = Color.Gray
        uni6_5.BackColor = Color.Gray
        uni6_6.BackColor = Color.Gray
        uni6_7.BackColor = Color.Gray
        uni6_8.BackColor = Color.Gray
        uni7_1.BackColor = Color.Gray
        uni7_2.BackColor = Color.Gray
        uni7_3.BackColor = Color.Gray
        uni7_4.BackColor = Color.Gray
        uni7_5.BackColor = Color.Gray
        uni7_6.BackColor = Color.Gray
        uni7_7.BackColor = Color.Gray
        uni7_8.BackColor = Color.Gray
        uni8_1.BackColor = Color.Gray
        uni8_2.BackColor = Color.Gray
        uni8_3.BackColor = Color.Gray
        uni8_4.BackColor = Color.Gray
        uni8_5.BackColor = Color.Gray
        uni8_6.BackColor = Color.Gray
        uni8_7.BackColor = Color.Gray
        uni8_8.BackColor = Color.Gray

        Try
            Dim path As String
            path = "TmpLED\tmp"

            ' Create or overwrite the file.
            Dim fs As FileStream = File.Create(path)

            ' Add text to the file.
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.rtbLED.Text)
            fs.Write(info, 0, info.Length)
            fs.Close()
            'LEDHandler()
            ThreadPool.QueueUserWorkItem(AddressOf LEDHandler)
        Catch
            MessageBox.Show("Error Occured! : " & ErrorToString(), "Error Occured while trying LED Test", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LEDHandler()
        Try
             Dim linesInfo As New List(Of String)(IO.File.ReadAllLines("TmpLED\tmp"))
            linesInfo.RemoveAll(Function(s) s.Trim = "")
            Dim Lines() As String = linesInfo.ToArray
            Dim linescounter As Integer = Lines.Length
            Dim stopwatch__1 As Stopwatch = Stopwatch.StartNew()
           
            Dim sp() As String
            For i = 0 To linescounter - 1

                sp = (Lines(i).Split(" "))
                If (sp(0) = "o" Or sp(0) = "on") Then

                    If (sp(3) = "a" Or sp(3) = "auto") Then
                        sp(3) = sp(4)
                        If (IsNumeric(sp(3)) = False) Then
                            MessageBox.Show("Wrong UniPad button code on line " & i + 1 & "!", "Wrong o(n) command", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Invoke(Sub()
                                          'Me.rtbLED.SelectedText = (Lines(i))
                                      End Sub)
                            Exit For
                        End If
                        sp(3) = led.returnLED(sp(3))
                    End If


                    'MsgBox(System.Drawing.ColorTranslator.FromHtml("#" & sp(3)).ToString & vbNewLine & System.Drawing.ColorTranslator.FromHtml("#" & sp(3)).ToArgb)
                    Try
                        Select Case sp(1)
                            Case 1
                                Select Case sp(2)

                                    Case 1
                                        uni1_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni1_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni1_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni1_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni1_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni1_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni1_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni1_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 2
                                Select Case sp(2)

                                    Case 1
                                        uni2_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni2_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni2_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni2_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni2_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni2_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni2_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni2_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 3
                                Select Case sp(2)

                                    Case 1
                                        uni3_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni3_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni3_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni3_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni3_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni3_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni3_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni3_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 4
                                Select Case sp(2)

                                    Case 1
                                        uni4_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni4_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni4_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni4_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni4_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni4_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni4_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni4_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 5
                                Select Case sp(2)

                                    Case 1
                                        uni5_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni5_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni5_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni5_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni5_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni5_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni5_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni5_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 6
                                Select Case sp(2)

                                    Case 1
                                        uni6_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni6_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni6_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni6_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni6_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni6_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni6_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni6_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 7
                                Select Case sp(2)

                                    Case 1
                                        uni7_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni7_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni7_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni7_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni7_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni7_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni7_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni7_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 8
                                Select Case sp(2)

                                    Case 1
                                        uni8_1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 2
                                        uni8_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 3
                                        uni8_3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 4
                                        uni8_4.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 5
                                        uni8_5.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 6
                                        uni8_6.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 7
                                        uni8_7.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case 8
                                        uni8_8.BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case Else
                                MessageBox.Show("There is no Button X Code " & sp(1) & " on Line " & i + 1 & "!", "Wrong X Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Select
                    Catch
                        MessageBox.Show("Wrong UniPad button code on line " & i + 1 & "! Or maybe you didn't pointed the button code! Or maybe you typed wrong HTML color code!", "Wrong o(n) command", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Invoke(Sub()
                                      'Me.rtbLED.Find(Lines(i))
                                      'Me.rtbLED.SelectedText = Lines(i)
                                  End Sub)
                        Exit For
                    End Try
                ElseIf (sp(0) = "f" Or sp(0) = "off") Then
                    Try
                        Select Case sp(1)
                            Case 1
                                Select Case sp(2)

                                    Case 1
                                        uni1_1.BackColor = Color.Gray
                                    Case 2
                                        uni1_2.BackColor = Color.Gray
                                    Case 3
                                        uni1_3.BackColor = Color.Gray
                                    Case 4
                                        uni1_4.BackColor = Color.Gray
                                    Case 5
                                        uni1_5.BackColor = Color.Gray
                                    Case 6
                                        uni1_6.BackColor = Color.Gray
                                    Case 7
                                        uni1_7.BackColor = Color.Gray
                                    Case 8
                                        uni1_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 2
                                Select Case sp(2)

                                    Case 1
                                        uni2_1.BackColor = Color.Gray
                                    Case 2
                                        uni2_2.BackColor = Color.Gray
                                    Case 3
                                        uni2_3.BackColor = Color.Gray
                                    Case 4
                                        uni2_4.BackColor = Color.Gray
                                    Case 5
                                        uni2_5.BackColor = Color.Gray
                                    Case 6
                                        uni2_6.BackColor = Color.Gray
                                    Case 7
                                        uni2_7.BackColor = Color.Gray
                                    Case 8
                                        uni2_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 3
                                Select Case sp(2)

                                    Case 1
                                        uni3_1.BackColor = Color.Gray
                                    Case 2
                                        uni3_2.BackColor = Color.Gray
                                    Case 3
                                        uni3_3.BackColor = Color.Gray
                                    Case 4
                                        uni3_4.BackColor = Color.Gray
                                    Case 5
                                        uni3_5.BackColor = Color.Gray
                                    Case 6
                                        uni3_6.BackColor = Color.Gray
                                    Case 7
                                        uni3_7.BackColor = Color.Gray
                                    Case 8
                                        uni3_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 4
                                Select Case sp(2)

                                    Case 1
                                        uni4_1.BackColor = Color.Gray
                                    Case 2
                                        uni4_2.BackColor = Color.Gray
                                    Case 3
                                        uni4_3.BackColor = Color.Gray
                                    Case 4
                                        uni4_4.BackColor = Color.Gray
                                    Case 5
                                        uni4_5.BackColor = Color.Gray
                                    Case 6
                                        uni4_6.BackColor = Color.Gray
                                    Case 7
                                        uni4_7.BackColor = Color.Gray
                                    Case 8
                                        uni4_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 5
                                Select Case sp(2)

                                    Case 1
                                        uni5_1.BackColor = Color.Gray
                                    Case 2
                                        uni5_2.BackColor = Color.Gray
                                    Case 3
                                        uni5_3.BackColor = Color.Gray
                                    Case 4
                                        uni5_4.BackColor = Color.Gray
                                    Case 5
                                        uni5_5.BackColor = Color.Gray
                                    Case 6
                                        uni5_6.BackColor = Color.Gray
                                    Case 7
                                        uni5_7.BackColor = Color.Gray
                                    Case 8
                                        uni5_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 6
                                Select Case sp(2)

                                    Case 1
                                        uni6_1.BackColor = Color.Gray
                                    Case 2
                                        uni6_2.BackColor = Color.Gray
                                    Case 3
                                        uni6_3.BackColor = Color.Gray
                                    Case 4
                                        uni6_4.BackColor = Color.Gray
                                    Case 5
                                        uni6_5.BackColor = Color.Gray
                                    Case 6
                                        uni6_6.BackColor = Color.Gray
                                    Case 7
                                        uni6_7.BackColor = Color.Gray
                                    Case 8
                                        uni6_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 7
                                Select Case sp(2)

                                    Case 1
                                        uni7_1.BackColor = Color.Gray
                                    Case 2
                                        uni7_2.BackColor = Color.Gray
                                    Case 3
                                        uni7_3.BackColor = Color.Gray
                                    Case 4
                                        uni7_4.BackColor = Color.Gray
                                    Case 5
                                        uni7_5.BackColor = Color.Gray
                                    Case 6
                                        uni7_6.BackColor = Color.Gray
                                    Case 7
                                        uni7_7.BackColor = Color.Gray
                                    Case 8
                                        uni7_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case 8
                                Select Case sp(2)

                                    Case 1
                                        uni8_1.BackColor = Color.Gray
                                    Case 2
                                        uni8_2.BackColor = Color.Gray
                                    Case 3
                                        uni8_3.BackColor = Color.Gray
                                    Case 4
                                        uni8_4.BackColor = Color.Gray
                                    Case 5
                                        uni8_5.BackColor = Color.Gray
                                    Case 6
                                        uni8_6.BackColor = Color.Gray
                                    Case 7
                                        uni8_7.BackColor = Color.Gray
                                    Case 8
                                        uni8_8.BackColor = Color.Gray
                                    Case Else
                                        MessageBox.Show("There is no Button Y Code " & sp(2) & " on Line " & i + 1 & "!", "Wrong Y Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Select
                            Case Else
                                MessageBox.Show("There is no Button X Code " & sp(1) & " on Line " & i + 1 & "!", "Wrong X Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Select
                        'Me.Update()
                    Catch
                        MessageBox.Show("Wrong UniPad button code on line" & i + 1 & "! Or maybe you didn't pointed the button code!", "Wrong (of)f command", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Invoke(Sub()
                                      Me.rtbLED.Find(Lines(i))
                                  End Sub)
                        Exit For
                    End Try
                ElseIf (sp(0) = "d" Or sp(0) = "delay") Then
                    If (IsNumeric(sp(1)) = False) Then
                        MessageBox.Show("Wrong millisecond code on line " & i + 1 & "!", "Wrong d(elay) command", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.rtbLED.Find(Lines(i))
                        Exit For
                    End If
                    Thread.Sleep(sp(1))
                Else
                    MessageBox.Show("Wrong LED command " & Lines(i) & " on line" & i, "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit For
                End If
            Next
            'ledfiles_now(chain, xcode, ycode) += 1
            stopwatch__1.[Stop]()
            Me.Invoke(Sub()
                          Me.lblTimePassed.Text = "Test Time:" & stopwatch__1.Elapsed.ToString()
                      End Sub)
        Catch

        End Try
    End Sub

    Private Sub listMultiMaps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listMultiMaps.SelectedIndexChanged
        MsgBox(MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.SelectedIndex))
        If (isFirst = False) Then
            If (changed = True) Then
                Dim result = MessageBox.Show("Save recent data?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (result = Windows.Forms.DialogResult.Yes) Then
                    Dim path As String
                    path = MainProjectLoader.ledfiles(nowchain, xc, yc, recent)

                    ' Create or overwrite the file.
                    Dim fs As FileStream = File.Create(path)

                    ' Add text to the file.
                    Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.rtbLED.Text)
                    fs.Write(info, 0, info.Length)
                    fs.Close()

                End If
            End If
        Else
            isFirst = False
        End If
        Dim filereader As String
        Try



            fileReader = My.Computer.FileSystem.ReadAllText(MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.SelectedIndex))
            Me.rtbLED.Text = fileReader

        Catch
        End Try

        'End If
        'MsgBox(fileReader)



        recent = Me.listMultiMaps.SelectedIndex
        changed = False
    End Sub


    Private Sub btnRemove_Click_1(sender As Object, e As EventArgs) Handles btnRemove.Click
        If (Me.listMultiMaps.Items.Count = 0) Then
            MessageBox.Show("You can't delete more! Add any LED file first!", "Counter Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        isFirst = True
        changed = True

        IO.File.Delete(MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.SelectedIndex))
        Dim files = Directory.GetFiles("Workspace\keyLED", nowchain & " " & xc & " " & yc & " *", SearchOption.TopDirectoryOnly)
        For q = 0 To MainProjectLoader.ledfiles_max(nowchain, xc, yc)
            MainProjectLoader.ledfiles(nowchain, xc, yc, q) = ""
        Next
        'Dim lastIndex As Integer = 97

        Me.listMultiMaps.Items.Clear()
        For q = 0 To files.Count - 1
            Dim strAdd As String
            Dim sp() As String = files(q).Split("\").Last.Split(" ")
            If sp.Count = 4 Then
                My.Computer.FileSystem.RenameFile(files(q), sp(0) & " " & sp(1) & " " & sp(2) & " " & sp(3))
            ElseIf sp.Count = 5 Then

                If (q = 0) Then strAdd = "" Else strAdd = " " & Chr(96 + q)
                My.Computer.FileSystem.RenameFile(files(q), sp(0) & " " & sp(1) & " " & sp(2) & " " & sp(3) & strAdd)
            End If

            'If (q = 0 And sp.Last = "a") Then
            '    isFirstFromA = True
            '    lastIndex = 97
            'End If
            'If (q = 0 And sp.Last = "0") Then
            '    lastIndex = 97
            '    My.Computer.FileSystem.RenameFile(files(q), sp(0) & " " & sp(1) & " " & sp(2) & " " & lastIndex)
            'End If

            'If (Asc(sp.Last) > lastIndex And IsNumeric(sp.Last) = False) Then
            '    My.Computer.FileSystem.RenameFile(files(q), sp(0) & " " & sp(1) & " " & sp(2) & " " & lastIndex)
            'End If
            'MainProjectLoader.ledfiles(nowchain, xc, yc, q) = files(q)


            Me.listMultiMaps.Items.Add(Chr(96 + q) & ";" & sp(3))
            If (Me.listMultiMaps.Items.Count = 1) Then Me.listMultiMaps.Items(0) = "Single;" & sp(3)

            MainProjectLoader.ledfiles(nowchain, xc, yc, q) = "Workspace\keyLED\" & sp(0) & " " & sp(1) & " " & sp(2) & " " & sp(3) & strAdd
        Next
       
        'IO.File.Delete(MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.Items.Count - 1))
        Me.rtbLED.Clear()
        If (Me.listMultiMaps.Items.Count = 0) Then

            Me.rtbLED.ReadOnly = True
            Me.btnLEDtest.Enabled = False
            Me.tabHelper.Enabled = False
            Me.rtbLED.Text = ""

        ElseIf (Me.listMultiMaps.Items.Count = 1) Then


            'My.Computer.FileSystem.RenameFile(MainProjectLoader.ledfiles(nowchain, xc, yc, 0), nowchain & " " & xc & " " & yc & " " & Me.listMultiMaps.Items(0).ToString.Split(";").Last)
            Me.listMultiMaps.Items(0) = "Single;" & Me.listMultiMaps.Items(0).ToString.Split(";").Last
        Else
            isFirst = True
            Me.listMultiMaps.SelectedIndex = 0
        End If
        MainProjectLoader.ledfiles_max(nowchain, xc, yc) = Me.listMultiMaps.Items.Count
    End Sub



    Private Sub btnAddTurnOff_Click(sender As Object, e As EventArgs) Handles btnAddTurnOff.Click
        Me.rtbLED.AppendText(vbNewLine & "f " & Me.tbTurnOffY.Text & " " & Me.tbTurnOffX.Text)

    End Sub

    Private Sub btnAddWait_Click(sender As Object, e As EventArgs) Handles btnAddWait.Click
        Me.rtbLED.AppendText(vbNewLine & "d " & Me.tbWaitMSec.Text)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (Me.listMultiMaps.Items.Count > 27) Then
            MessageBox.Show("You reached maximum size of Multi Mapper!", "Maximum exceed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (Me.listMultiMaps.Items.Count = 0) Then
            Me.listMultiMaps.Items.Add("Single;1")
            Dim a = IO.File.Create("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1")
            a.Close()
            MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.Items.Count - 1) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1"
            isFirst = True
            Me.listMultiMaps.SelectedIndex = 0
            Me.rtbLED.Enabled = True

            Me.rtbLED.ReadOnly = False
            Me.btnLEDtest.Enabled = True
            Me.tabHelper.Enabled = True
        Else
            Me.listMultiMaps.Items.Add(Chr(96 + Me.listMultiMaps.Items.Count) & ";1")
            Dim a = IO.File.Create("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1 " & Chr(96 + Me.listMultiMaps.Items.Count))
            a.Close()
            MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.Items.Count - 1) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1 " & Chr(95 + Me.listMultiMaps.Items.Count)

        End If
        MainProjectLoader.ledfiles_max(nowchain, xc, yc) = Me.listMultiMaps.Items.Count
        If (Me.listMultiMaps.Items.Count = 2) Then
            MainProjectLoader.ledfiles_max(nowchain, xc, yc) = 2
            Dim sp As String = MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\")(MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\").Count - 1).Split(" ")(MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\")(MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\").Count - 1).Split(" ").Count - 1)
            Me.listMultiMaps.Items(0) = "Single" & ";1"
            If (sp = 1) Then
                MainProjectLoader.ledfiles(nowchain, xc, yc, 0) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1"
                'My.Computer.FileSystem.RenameFile("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1", nowchain & " " & xc & " " & yc & " 1")
            Else
                MainProjectLoader.ledfiles(nowchain, xc, yc, 0) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0"
                ' My.Computer.FileSystem.RenameFile("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0", nowchain & " " & xc & " " & yc & " 0")
                Me.listMultiMaps.Items(0) = "Single" & ";0"
            End If

        End If

        'MainProjectLoader.soundfiles_now(nowchain, xc, yc) = 0

    End Sub

    Private Sub btnAdd0_Click(sender As Object, e As EventArgs) Handles btnAdd0.Click
        If (Me.listMultiMaps.Items.Count > 27) Then
            MessageBox.Show("You reached maximum size of Multi Mapper!", "Maximum exceed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If (Me.listMultiMaps.Items.Count = 0) Then
            Me.listMultiMaps.Items.Add("Single;0")
            Dim a = IO.File.Create("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0")
            a.Close()
            MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.Items.Count - 1) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0"
            isFirst = True
            Me.listMultiMaps.SelectedIndex = 0
            Me.rtbLED.Enabled = True

            Me.rtbLED.ReadOnly = False
            Me.btnLEDtest.Enabled = True
            Me.tabHelper.Enabled = True
        Else
            Me.listMultiMaps.Items.Add(Chr(96 + Me.listMultiMaps.Items.Count) & ";0")
            Dim a = IO.File.Create("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0 " & Chr(96 + Me.listMultiMaps.Items.Count))
            a.Close()
            MainProjectLoader.ledfiles(nowchain, xc, yc, Me.listMultiMaps.Items.Count - 1) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0 " & Chr(95 + Me.listMultiMaps.Items.Count)

        End If
        MainProjectLoader.ledfiles_max(nowchain, xc, yc) = Me.listMultiMaps.Items.Count
        If (Me.listMultiMaps.Items.Count = 2) Then
            MainProjectLoader.ledfiles_max(nowchain, xc, yc) = 2
            Dim sp As String = MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\")(MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\").Count - 1).Split(" ")(MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\")(MainProjectLoader.ledfiles(nowchain, xc, yc, 0).Split("\").Count - 1).Split(" ").Count - 1)
            Me.listMultiMaps.Items(0) = "Single" & ";1"
            If (sp = 1) Then
                MainProjectLoader.ledfiles(nowchain, xc, yc, 0) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1"
                'My.Computer.FileSystem.RenameFile("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 1", nowchain & " " & xc & " " & yc & " 1")
            Else
                MainProjectLoader.ledfiles(nowchain, xc, yc, 0) = "Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0"
                ' My.Computer.FileSystem.RenameFile("Workspace\keyLED\" & nowchain & " " & xc & " " & yc & " 0", nowchain & " " & xc & " " & yc & " 0")
                Me.listMultiMaps.Items(0) = "Single" & ";0"
            End If

        End If

        'MainProjectLoader.soundfiles_now(nowchain, xc, yc) = 0

    End Sub

    Private Sub cbLaunchPadColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLaunchPadColor.SelectedIndexChanged

    End Sub

    Private Sub btnAddTurnOn_Click(sender As Object, e As EventArgs) Handles btnAddTurnOn.Click
        If (Me.checkUseLaunchColor.Checked = True) Then
            If (Me.cbLaunchPadColor.SelectedItem.ToString <> "Not Set") Then
                Me.rtbLED.AppendText(vbNewLine & "o " & Me.tbTurnOffY.Text & " " & Me.tbTurnOffX.Text & " " & "auto " & Me.cbLaunchPadColor.SelectedItem)
            End If
        Else

            Me.rtbLED.AppendText(vbNewLine & "o " & Me.tbTurnOffY.Text & " " & Me.tbTurnOffX.Text & " " & Me.textColor.Text)
        End If
    End Sub

    'Support for Line Numbers
    'https://www.codeproject.com/Articles/14566/Line-Numbering-of-RichTextBox-in-NET
    Private Sub rtbLED_Resize(sender As Object, e As EventArgs) Handles rtbLED.Resize
        Me.rtbLED.Invalidate
    End Sub

    Private Sub rtbLED_VsCroll(sender As Object, e As EventArgs) Handles rtbLED.VScroll
        Me.rtbLED.Invalidate()
    End Sub

    Private Sub p_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbLNum.Paint
        DrawRichTextBoxLineNumbers(e.Graphics)
    End Sub

    Private Sub rtbLED_TextChanged(sender As Object, e As EventArgs) Handles rtbLED.TextChanged
        Me.rtbLED.Invalidate()
        changed = True
        'Try
        '    If (Me.listMultiMaps.Items.Count > 0) Then
        '        Dim path As String = MainProjectLoader.ledfiles(nowchain, xc, yc, recent)

        '        ' Create or overwrite the file.
        '        Dim fs As FileStream = File.Create(path)

        '        ' Add text to the file.
        '        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Me.rtbLED.Text)
        '        fs.Write(info, 0, info.Length)
        '        fs.Close()
        '    End If
        'Catch
        'End Try

    End Sub


    Private Sub DrawRichTextBoxLineNumbers(ByRef g As Graphics)
        'calculate font heigth as the difference in Y coordinate between line 2 and line 1
        'note that the RichTextBox text must have at least two lines. So the initial Text property of the RichTextBox should not be an empty string. It could be something like vbcrlf & vbcrlf & vbcrlf 
        Dim font_height As Single = rtbLED.GetPositionFromCharIndex(rtbLED.GetFirstCharIndexFromLine(2)).Y - rtbLED.GetPositionFromCharIndex(rtbLED.GetFirstCharIndexFromLine(1)).Y
        If font_height = 0 Then Exit Sub

        'Get the first line index and location
        Dim firstIndex As Integer = rtbLED.GetCharIndexFromPosition(New Point(0, g.VisibleClipBounds.Y + font_height / 3))
        Dim firstLine As Integer = rtbLED.GetLineFromCharIndex(firstIndex)
        Dim firstLineY As Integer = rtbLED.GetPositionFromCharIndex(firstIndex).Y

        'Print on the PictureBox the visible line numbers of the RichTextBox
        g.Clear(Control.DefaultBackColor)
        Dim i As Integer = firstLine
        Dim y As Single
        Do While y < g.VisibleClipBounds.Y + g.VisibleClipBounds.Height
            y = firstLineY + 2 + font_height * (i - firstLine - 1)
            g.DrawString((i).ToString, rtbLED.Font, Brushes.DarkBlue, pbLNum.Width - g.MeasureString((i).ToString, rtbLED.Font).Width, y)
            i += 1
        Loop
        'Debug.WriteLine("Finished: " & firstLine + 1 & " " & i - 1)
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        MsgBox(changed)
    End Sub

    Private Sub frmLED_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (MainProjectLoader.ishaveLED = False) Then
            Dim result = MessageBox.Show("LED is not enabled in this project. Do you want to enable?", "LED Not enabled", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If (result = Windows.Forms.DialogResult.Yes) Then
                MainProjectLoader.ishaveLED = True
            Else
                Me.Close()
            End If
        End If
    End Sub
End Class