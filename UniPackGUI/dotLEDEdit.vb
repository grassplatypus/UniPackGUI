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
        'readLED(Me.listLEDs.SelectedIndex)
    End Sub
End Class
