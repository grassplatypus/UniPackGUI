Imports System.Drawing.Drawing2D

Class ButtonModified
    Inherits System.Windows.Forms.Button
    'we can use this to modify the color of the border 
    Public BorderColor As Color = Color.LightGray
    'we can use this to modify the border size
    Public BorderSize As Integer = 5
    Public Sub New()
        FlatStyle = FlatStyle.Flat
        BackColor = Color.White
        FlatAppearance.BorderColor = BorderColor
        FlatAppearance.BorderSize = BorderSize
        Font = New System.Drawing.Font("VAGRounded-Light", 30.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CByte(0))
        ForeColor = System.Drawing.Color.FromArgb(CInt(CByte(84)), CInt(CByte(33)), CInt(CByte(107)))

        AddHandler Me.MouseDown, New MouseEventHandler(AddressOf ButtonLastest_MouseDown)
        AddHandler Me.MouseUp, New MouseEventHandler(AddressOf ButtonLastest_MouseUp)
    End Sub

    Private Sub ButtonLastest_MouseUp(sender As Object, e As MouseEventArgs)
        ForeColor = System.Drawing.Color.FromArgb(CInt(CByte(84)), CInt(CByte(33)), CInt(CByte(107)))
        BackColor = Color.White
    End Sub

    Private Sub ButtonLastest_MouseDown(sender As Object, e As MouseEventArgs)
        BackColor = System.Drawing.Color.FromArgb(CInt(CByte(84)), CInt(CByte(33)), CInt(CByte(107)))
        ForeColor = System.Drawing.Color.White

    End Sub
    Private top As Integer
    Private left As Integer
    Private right As Integer
    Private bottom As Integer

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        ' to draw the control using base OnPaint
        MyBase.OnPaint(pevent)
        'to modify the corner radius
        Dim CornerRadius As Integer = 18

        Dim DrawPen As New Pen(BorderColor)
        Dim gfxPath_mod As New GraphicsPath()

        top = 0
        left = 0
        right = Width
        bottom = Height

        gfxPath_mod.AddArc(left, top, CornerRadius, CornerRadius, 180, 90)
        gfxPath_mod.AddArc(right - CornerRadius, top, CornerRadius, CornerRadius, 270, 90)
        gfxPath_mod.AddArc(right - CornerRadius, bottom - CornerRadius, CornerRadius, CornerRadius, 0, 90)
        gfxPath_mod.AddArc(left, bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90)

        gfxPath_mod.CloseAllFigures()

        pevent.Graphics.DrawPath(DrawPen, gfxPath_mod)

        Dim inside As Integer = 1

        Dim newPen As New Pen(BorderColor, BorderSize)
        Dim gfxPath As New GraphicsPath()
        gfxPath.AddArc(left + inside + 1, top + inside, CornerRadius, CornerRadius, 180, 100)

        gfxPath.AddArc(right - CornerRadius - inside - 2, top + inside, CornerRadius, CornerRadius, 270, 90)
        gfxPath.AddArc(right - CornerRadius - inside - 2, bottom - CornerRadius - inside - 1, CornerRadius, CornerRadius, 0, 90)

        gfxPath.AddArc(left + inside + 1, bottom - CornerRadius - inside, CornerRadius, CornerRadius, 95, 95)
        pevent.Graphics.DrawPath(newPen, gfxPath)

        Me.Region = New System.Drawing.Region(gfxPath_mod)
    End Sub
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
