Imports System.Runtime.InteropServices
Imports System.IO

Public Class MultiSounds
    Public Snds As New Dictionary(Of String, String) '경로, 이름

    'Private sndcnt As Integer = 0

    <DllImport("winmm.dll", EntryPoint:="mciSendStringW")> _
    Private Shared Function mciSendStringW(<MarshalAs(UnmanagedType.LPTStr)> ByVal lpszCommand As String, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszReturnString As System.Text.StringBuilder, ByVal cchReturn As UInteger, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Public Function AddSound(ByVal SoundName As String, ByVal SndFilePath As String) As Integer
        If SoundName.Trim = "" Or Not IO.File.Exists(SndFilePath) Then Return False
        If mciSendStringW("open " & Chr(34) & SndFilePath & Chr(34) & " alias " & Chr(34) & SoundName & Chr(34), Nothing, 0, IntPtr.Zero) <> 0 Then Return 1
        'MsgBox(SoundName)
        'Snds.Add(SndFilePath, SoundName)
        Return 1

    End Function
    Public Function ReadyToPlay(ByVal SoundName As String)
        mciSendStringW("seek " & Chr(34) & SoundName & Chr(34) & " to start", Nothing, 0, IntPtr.Zero)
        Return 0
    End Function
    Public Function Play(ByVal SoundName As String) As Boolean

        'If Not Snds.ContainsKey(SoundName) Then Return False

        mciSendStringW("seek " & Chr(34) & SoundName & Chr(34) & " to start", Nothing, 0, IntPtr.Zero)
        If mciSendStringW("play " & Chr(34) & SoundName & Chr(34) & "", Nothing, 0, IntPtr.Zero) <> 0 Then Return False
        Return True


    End Function

    Public Function Close(ByVal SoundName As String) As Boolean '이름을 통하여 삭제

        mciSendStringW("close " & Chr(34) & SoundName & Chr(34), Nothing, 0, IntPtr.Zero)
        'RemoveByValue(Snds, SoundName)

        Return True
    End Function
    '당장 쓸 함수는 아님.
    '현재 딕셔너리 오류 ㅎ결해야함

    Public Function EndSoundPath(ByVal soundpath As String) As Boolean '경로를 통하여 삭제

        '쓰이지 않음!!!!!!!
        Dim toSearch = soundpath
        'http://stackoverflow.com/questions/9946751/get-line-number-that-contains-a-string
        Dim lineNumber = File.ReadLines("TmpSound/dictionary.txt").
                         Where(Function(l) l.Contains(toSearch)).
                         Select(Function(l, index) index)

        If lineNumber.Any Then
            Dim firstNumber = lineNumber.First

        End If

        'http://stackoverflow.com/questions/20222681/remove-a-line-from-text-file-vb-net
        Dim lines() As String
        Dim outputlines As New List(Of String)
        Dim searchString As String = soundpath
        lines = IO.File.ReadAllLines("TmpSound/dictionary.txt")
        For Each line As String In lines
            If line.Contains(searchString) = True Then
                line = ""  'Remove that line and save text file (here is my problem I think )
                Exit For
            End If
        Next

        'https://www.experts-exchange.com/questions/28535372/Dictionary-get-key-by-value.html#answer40373530
        Dim keys = Snds.Where(Function(pair) pair.Value = soundpath).Select(Function(pair) pair.Key).ToList()
        If keys.Count > 0 Then
            If mciSendStringW("close " & Chr(34) & keys(0) & Chr(34), Nothing, 0, IntPtr.Zero) <> 0 Then Return False
            Snds.Remove(keys(0))
            Return True

        End If


        Return False
    End Function
    Public Function returnKey(soundName As String) As String

        '안씀!!!!ㄱ
        Dim keys = Snds.Where(Function(pair) pair.Value = soundName).Select(Function(pair) pair.Key).ToList()
        If keys.Count > 0 Then
            If mciSendStringW("close " & Chr(34) & keys(0) & Chr(34), Nothing, 0, IntPtr.Zero) <> 0 Then Return "False"
            'Snds.Remove(keys(0))
            Return keys(0)
            'Console.WriteLine(String.Format("Value - 0, Is Keyed with {0}", keys(0)))
        End If
        Return "False"
    End Function
    'Stack Over Flow
    Sub RemoveByValue(Of TKey, TValue)(ByVal dictionary As Dictionary(Of TKey, TValue), ByVal someValue As TValue) '이름으로 삭제

        Dim itemsToRemove = (From pair In dictionary _
                            Where pair.Value.Equals(someValue) _
                            Select pair.Key).ToArray()

        For Each item As TKey In itemsToRemove
            dictionary.Remove(item)
        Next

    End Sub

    Public Function SearchByKey(key As String) As String
        Return Snds(key)
    End Function
End Class
