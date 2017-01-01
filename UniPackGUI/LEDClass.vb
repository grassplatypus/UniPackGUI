'Imports UniPackGUI.MainProjectLoader
Imports System.Threading


Public Class LEDClass
    Dim LEDPath As String

    Public Sub New()

    End Sub
    Public Sub doLED(Data As Object)
        Try
            'Dim counter As Integer = ledfiles_now(chain, xcode, ycode)
            Dim spliter_parm() As String = Data.ToString.Split(";")
            Dim chain As Integer = spliter_parm(0)
            Dim xcode As Integer = spliter_parm(1)
            Dim ycode As Integer = spliter_parm(2)

            MsgBox(MainProjectLoader.ledfiles(chain, xcode, ycode, MainProjectLoader.ledfiles_now(chain, xcode, ycode)))


            Dim Lines() As String = IO.File.ReadAllLines(MainProjectLoader.ledfiles(chain, xcode, ycode, MainProjectLoader.ledfiles_now(chain, xcode, ycode)))
            Dim sp() As String

            Dim spliter_tmp() As String = MainProjectLoader.ledfiles(chain, xcode, ycode, MainProjectLoader.ledfiles_now(chain, xcode, ycode)).Split("\")
            Dim spliter_name() As String = spliter_tmp(spliter_tmp.Length - 1).Split(" ")
            If (spliter_name(3) = 1) Then
                'Dim order As String = ledfiles_now(chain, xcode, ycode)





                ' MsgBox(Chr(order + 96))
                For i = 0 To Lines.Length - 1
                    sp = Lines(i).Split(" ")
                    If (sp(0) = "o" Or sp(0) = "on") Then

                        If (sp(3) = "a" Or sp(3) = "auto") Then
                            sp(3) = sp(4)
                            sp(3) = MainProjectLoader.led.returnLED(sp(3))
                        End If

                        MainProjectLoader.Invoke(Sub()
                                                     Try
                                                         MainProjectLoader.ctrlDict(sp(1) & sp(2)).BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                                     Catch
                                                     End Try
                                                 End Sub)


                    ElseIf (sp(0) = "f" Or sp(0) = "off") Then
                        MainProjectLoader.Invoke(Sub()
                                                     Try
                                                         MainProjectLoader.ctrlDict(sp(1) & sp(2)).BackColor = Color.Gray
                                                     Catch
                                                     End Try
                                                 End Sub)

                    ElseIf (sp(0) = "d" Or sp(0) = "delay") Then
                        Thread.Sleep(sp(1))
                    End If
                Next
            Else
                Dim turnOffDict As New List(Of String)
                For i = 0 To Lines.Length - 1
                    sp = Lines(i).Split(" ")
                    If (sp(0) = "o" Or sp(0) = "on") Then
                        turnOffDict.Add(sp(1) & sp(2))
                        If (sp(3) = "a" Or sp(3) = "auto") Then
                            sp(3) = sp(4)
                            sp(3) = MainProjectLoader.led.returnLED(sp(3))
                        End If
                        MainProjectLoader.Invoke(Sub()
                                                     MainProjectLoader.ctrlDict(sp(1) & sp(2)).BackColor = System.Drawing.ColorTranslator.FromHtml("#" & sp(3))
                                                 End Sub)
                    ElseIf (sp(0) = "f" Or sp(0) = "off") Then
                        MainProjectLoader.Invoke(Sub()
                                                     MainProjectLoader.ctrlDict(sp(1) & sp(2)).BackColor = Color.Gray
                                                 End Sub)

                    ElseIf (sp(0) = "d" Or sp(0) = "delay") Then
                        Thread.Sleep(sp(1))
                    End If

                    'Me.Invoke(Sub()
                    '              Me.Update()
                    '          End Sub)
                Next
                Thread.Sleep(50)
                For i = 0 To turnOffDict.Count - 1
                    MainProjectLoader.Invoke(Sub()
                                                 MainProjectLoader.ctrlDict(turnOffDict(i)).BackColor = Color.Gray
                                             End Sub)
                Next
            End If

            If (MainProjectLoader.ledfiles_now(chain, xcode, ycode) + 1 >= MainProjectLoader.ledfiles_max(chain, xcode, ycode)) Then

                MainProjectLoader.ledfiles_now(chain, xcode, ycode) = 0
            Else
                MainProjectLoader.ledfiles_now(chain, xcode, ycode) += 1
            End If
        Catch
        End Try
    End Sub
End Class
