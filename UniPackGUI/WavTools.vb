Imports System.Text
Imports System.Runtime.InteropServices

'Namespace Sound
Public NotInheritable Class WavTools
    'Private Sub New()
    'End Sub
    <DllImport("winmm.dll")> _
    Private Shared Function mciSendString(command As String, returnValue As StringBuilder, returnLength As Integer, winHandle As IntPtr) As UInteger
    End Function

    Public Shared Function GetSoundLength(fileName As String) As Integer

        Dim lengthBuf As New StringBuilder(32)

        mciSendString(String.Format("open ""{0}"" type waveaudio alias wave", fileName), Nothing, 0, IntPtr.Zero)
        mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero)
        mciSendString("close wave", Nothing, 0, IntPtr.Zero)

        Dim length As Integer = 0
        Integer.TryParse(lengthBuf.ToString(), length)

        Return length
    End Function
End Class
'End Namespace

