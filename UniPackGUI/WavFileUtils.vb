Imports NAudio.Wave

Public NotInheritable Class WavFileUtils
    Private Sub New()
    End Sub
    Public Shared Sub TrimWavFile(inPath As String, outPath As String, cutFromStart As TimeSpan, cutFromEnd As TimeSpan)
        Using reader As New WaveFileReader(inPath)
            Using writer As New WaveFileWriter(outPath, reader.WaveFormat)
                Dim bytesPerMillisecond As Integer = reader.WaveFormat.AverageBytesPerSecond / 1000

                Dim startPos As Integer = CInt(cutFromStart.TotalMilliseconds) * bytesPerMillisecond
                startPos = startPos - startPos Mod reader.WaveFormat.BlockAlign

                Dim endBytes As Integer = CInt(cutFromEnd.TotalMilliseconds) * bytesPerMillisecond
                endBytes = endBytes - endBytes Mod reader.WaveFormat.BlockAlign
                Dim endPos As Integer = CInt(reader.Length) - endBytes

                TrimWavFile(reader, writer, startPos, endPos)
            End Using
        End Using
    End Sub

    Private Shared Sub TrimWavFile(reader As WaveFileReader, writer As WaveFileWriter, startPos As Integer, endPos As Integer)
        reader.Position = startPos
        Dim buffer As Byte() = New Byte(1023) {}
        While reader.Position < endPos
            Dim bytesRequired As Integer = CInt(endPos - reader.Position)
            If bytesRequired > 0 Then
                Dim bytesToRead As Integer = Math.Min(bytesRequired, buffer.Length)
                Dim bytesRead As Integer = reader.Read(buffer, 0, bytesToRead)
                If bytesRead > 0 Then
                    writer.Write(buffer, 0, bytesRead)
                End If
            End If
        End While
    End Sub
End Class