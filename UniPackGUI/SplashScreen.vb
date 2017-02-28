Imports System.Drawing.Imaging

Public Class SplashScreen

    Private Sub lblHomepageGo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim process As New Process
        process.StartInfo.FileName = "http://www.unitor.esy.es"
        process.Start()
    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(My.Computer.Screen.Bounds.X / 2 + 125 + 62.5, My.Computer.Screen.Bounds.Y / 2 + 125 - 31.25)
        Threading.ThreadPool.QueueUserWorkItem(AddressOf OpUp)
        'OpUp()
        Me.lblVersion.Text = My.Application.Info.Version.ToString
        'ChangeOP_UP()
    End Sub

    Private Sub OpUp()

       
        Threading.Thread.Sleep(3000)
        Me.Invoke(Sub()
                      frmStart.Show()
                      Me.Close()
                  End Sub)
    End Sub

    Private Sub ChangeOP_UP()


    End Sub

    Public Shared Function ChangeOpacity(ByVal img As Image, ByVal opacityvalue As Single) As Bitmap
        Dim bmp As New Bitmap(img.Width, img.Height)
        Dim graphics__1 As Graphics = Graphics.FromImage(bmp)
        Dim colormatrix As New ColorMatrix
        colormatrix.Matrix33 = opacityvalue
        Dim imgAttribute As New ImageAttributes
        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        graphics__1.DrawImage(img, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, _
         GraphicsUnit.Pixel, imgAttribute)
        graphics__1.Dispose()
        Return bmp
    End Function
End Class