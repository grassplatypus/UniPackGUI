Imports System.IO

Public Class dotLEDEdit
    Dim isfirst As Boolean = True
    Dim chain As Integer
    Dim xc As Integer
    Dim yc As Integer
    'Dim loop_num As Integer
    Dim led As New ledReturn

    Public ctrlDict As New Dictionary(Of String, Button) 'ObjectCallusingString
    'Dim ColorDic(27, 10000, 9, 9) As Color
    'Dim before As Integer

    Private Sub LoadElement(a As Integer, b As Integer, c As Integer)
        chain = a
        xc = b
        yc = c
        If (MainProjectLoader.ledfiles_max(a, b, c) > 1) Then
            For index = 0 To MainProjectLoader.ledfiles_max(a, b, c) - 1
                Me.listorder.Items.Add(Chr(97 + index))
            Next
        End If
    End Sub

    Private Function TakeScreenShot(ByVal Control As Control) As Bitmap
        Dim tmpImg As New Bitmap(Control.Width, Control.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(Control.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Control.Width, Control.Height))
        End Using
        Return tmpImg
    End Function


    Private Function readLED(order As Integer)
        For Each filename In Directory.GetFiles("LEDWorkspace\", "*", SearchOption.TopDirectoryOnly)
            IO.File.Delete(filename)
        Next
        'Dim lines As New List(Of String)(IO.File.ReadAllLines("Workspace\keyLED\" & chain & " " & xc & " " & yc & " " & loop_num & " " & Chr(96 + order)))
        ' lines.RemoveAll(Function(s) s.Trim = "")
        ' Dim str() As String = lines.ToArray
        ' Dim ctr As Integer = str.Length
        Dim splited() As String
        Dim ledCtr As Integer = 0
        Dim endLED As Boolean = False
        Dim LEDtxt As String = ""
        For i = 0 To MainProjectLoader.LEDlinesCtr(chain, xc, yc, order) - 1
            splited = MainProjectLoader.LEDloads(chain, xc, yc, order, i).Split(" ")
            If (splited(0) = "o" Or splited(0) = "on") Then
                If endLED = False Then

                    Me.listLEDs.Items.Add("LED(on):" & ledCtr)
                    endLED = True

                End If
                If (splited(3) = "a" Or splited(3) = "auto") Then
                    'ctrlDict(splited(1)&splited(2)).BackColor = 
                    'ColorDic(order, ledCtr, splited(1), splited(2)) = Drawing.ColorTranslator.FromHtml(led.returnLED(splited(4)))
                    If (My.Computer.FileSystem.FileExists("LEDWorkspace\" & order & " on " & ledCtr) = False) Then
                        LEDtxt = vbNewLine & splited(1) & splited(2) & ":auto:" & splited(4)
                    Else
                        LEDtxt = splited(1) & splited(2) & ":auto:" & splited(4)
                    End If

                    IO.File.AppendAllText("LEDWorkspace\" & order & " on " & ledCtr, LEDtxt)
                Else
                    If (My.Computer.FileSystem.FileExists("LEDWorkspace\" & order & " on " & ledCtr) = False) Then
                        LEDtxt = vbNewLine & splited(1) & splited(2) & ":html:" & splited(3)
                    Else
                        LEDtxt = splited(1) & splited(2) & ":html:" & splited(3)
                    End If
                    IO.File.AppendAllText("LEDWorkspace\" & order & " on " & ledCtr, LEDtxt)
                End If
            ElseIf (splited(0) = "f" Or splited(0) = "off") Then
                If endLED = True Then

                    Me.listLEDs.Items.Add("LED(on):" & ledCtr)
                    endLED = True

                End If
                endLED = False
                Me.listLEDs.Items.Add("LED(off):" & ledCtr)
                ledCtr += 1
            ElseIf (splited(0) = "d" Or splited(0) = "delay") Then
                endLED = False
                ledCtr += 1
                Me.listLEDs.Items.Add("WAIT(ms):" & splited(1))
            End If

        Next
        Me.listorder.SelectedIndex = 0
    End Function

    Private Sub FlushLED()
        For i = 1 To 8
            For q = 1 To 8
                ctrlDict(i & q).BackColor = Color.Gray
                ctrlDict(i & q).Tag = ""
            Next

        Next

    End Sub

    Private Sub dotLEDEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub listorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listorder.SelectedIndexChanged
        'readLED(Asc(Me.listorder.SelectedIndex))
        Dim str() As String = Me.listorder.SelectedItem.ToString.Split(":")
        Dim fReader() As String
        If (str(0) = "LED(on)") Then
            fReader = IO.File.ReadAllLines("LED\Workspace\" & Me.listLEDs.SelectedItem & " on " & str(1))
            For i = 0 To fReader.Length
                Dim sp() As String = fReader(i).Split(":")
                If (sp(1) = "auto") Then
                    ctrlDict(sp(0)).BackColor = ColorTranslator.FromHtml(led.returnLED(sp(2)))
                    ctrlDict(sp(0)).Tag = "auto:" & sp(2)
                ElseIf (sp(1) = "html") Then
                    ctrlDict(sp(0)).BackColor = ColorTranslator.FromHtml(sp(2))
                    ctrlDict(sp(0)).Tag = "html:" & sp(2)
                Else
                    MessageBox.Show("Invaild Temp LED Figuration File! We can't sure the file integration.")
                    Exit Sub
                End If
            Next
        ElseIf (str(0) = "LED(off)") Then
        End If
    End Sub

    Private Sub listLEDs_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles listLEDs.SelectedIndexChanged
        FlushLED()
        readLED(Me.listLEDs.SelectedIndex)
    End Sub
End Class
