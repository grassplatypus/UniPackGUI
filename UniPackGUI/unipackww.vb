Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Net
Imports System.IO

Public Class unipackww


    'http://stackoverflow.com/questions/566462/upload-files-with-httpwebrequest-multipart-form-data
    Public Async Sub HttpUploadFile(url As String, file As String, paramName As String, contentType As String, nvc As NameValueCollection)


        Dim result As String
        'Diagnostics.log.Debug(String.Format("Uploading {0} to {1}", file, url))
        Dim boundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
        Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes((Convert.ToString(vbCr & vbLf & "--") & boundary) + vbCr & vbLf)

        Dim wr As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        wr.ContentType = Convert.ToString("multipart/form-data; boundary=") & boundary
        wr.Method = "POST"
        wr.KeepAlive = True
        wr.Credentials = System.Net.CredentialCache.DefaultCredentials
        wr.Timeout = "600000" '10 Minutes

        Dim rs As Stream = wr.GetRequestStream()

        Dim formdataTemplate As String = "Content-Disposition: form-data; name=""{0}""" & vbCr & vbLf & vbCr & vbLf & "{1}"
        For Each key As String In nvc.Keys
            rs.Write(boundarybytes, 0, boundarybytes.Length)
            Dim formitem As String = String.Format(formdataTemplate, key, nvc(key))
            Dim formitembytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formitem)
            rs.Write(formitembytes, 0, formitembytes.Length)
        Next
        rs.Write(boundarybytes, 0, boundarybytes.Length)

        Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCr & vbLf & "Content-Type: {2}" & vbCr & vbLf & vbCr & vbLf
        Dim header As String = String.Format(headerTemplate, paramName, file, contentType)
        Dim headerbytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
        rs.Write(headerbytes, 0, headerbytes.Length)

        Dim fileStream As New FileStream(file, FileMode.Open, FileAccess.Read)
        Dim buffer As Byte() = New Byte(4095) {}
        Dim bytesRead As Integer = 0
        While (InlineAssignHelper(bytesRead, fileStream.Read(buffer, 0, buffer.Length))) <> 0
            rs.Write(buffer, 0, bytesRead)
        End While
        fileStream.Close()

        Dim trailer As Byte() = System.Text.Encoding.ASCII.GetBytes((Convert.ToString(vbCr & vbLf & "--") & boundary) + "--" & vbCr & vbLf)
        rs.Write(trailer, 0, trailer.Length)
        rs.Close()

        Dim wresp As WebResponse = Nothing
        Try
            wresp = Await wr.GetResponseAsync()
            Dim stream2 As Stream = wresp.GetResponseStream()
            Dim reader2 As New StreamReader(stream2)
            'log.Debug(String.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()))
            'Return reader2.ReadToEnd
            result = reader2.ReadToEnd
        Catch ex As Exception
            'log.[Error]("Error uploading file", ex)
            If wresp IsNot Nothing Then
                wresp.Close()
                wresp = Nothing

            End If
            wr = Nothing
            Me.notifyUpload.BalloonTipText = "Uploading Failed!"
            Me.notifyUpload.BalloonTipTitle = "Failed to upload your UniPack. Please try again."
            Me.notifyUpload.ShowBalloonTip(300)
            'MsgBox(result)
            Me.pbUpload.Visible = False
            Me.btnSend.Enabled = True
            Me.txtDescription.Enabled = True
            Me.txttitle.Enabled = True
            MessageBox.Show("Error Occured! Reason: " & ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Finally
            wr = Nothing
        End Try
        If (result.Split(";").First = "success") Then
            Me.notifyUpload.BalloonTipText = "Uploading Finished!"
            Me.notifyUpload.BalloonTipTitle = "Upload Finished"
            Me.notifyUpload.ShowBalloonTip(300)
            'MsgBox(result.Split(";").Last)
            Me.txtDescription.Enabled = True
            Me.txttitle.Enabled = True
            Me.pbUpload.Visible = False
            Me.btnSend.Enabled = True
            Me.txtLink.Visible = True
            Me.txtLink.Text = "http://share.akaksr.xyz/getdown.php?c=" & result.Split(";").Last
        Else
            MessageBox.Show("Failed to Upload! Message from server: " & result.Split(";").Last, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.notifyUpload.BalloonTipText = "Uploading Failed!"
            Me.notifyUpload.BalloonTipTitle = "Failed to upload your UniPack. Please try again."
            Me.notifyUpload.ShowBalloonTip(300)
            'MsgBox(result)
            Me.pbUpload.Visible = False
            Me.btnSend.Enabled = True
            Me.txtDescription.Enabled = True
            Me.txttitle.Enabled = True
        End If
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As t, value As t) As t
        target = value
        Return value
    End Function

    Private Sub unipackww_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.tipDirInfo.SetToolTip(Me.lblDir, MainProjectLoader.tbPackDirInfo.Text)
        Me.lblDir.Text = MainProjectLoader.tbPackDirInfo.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Me.txtLink.Visible = False
        If (Me.txttitle.Text.Trim = "") Then
            MessageBox.Show("Please fill the title!", "No title", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.txttitle.Focus()
            Exit Sub
        ElseIf (Me.txtDescription.Text.Trim = "") Then
            MessageBox.Show("Please fill the description!", "No description", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.txtDescription.Focus()
            Exit Sub
        End If
        Me.txtDescription.Enabled = False
        Me.txttitle.Enabled = False
        Me.pbUpload.Visible = True
        Me.btnSend.Enabled = False
        Me.notifyUpload.BalloonTipText = "Uploading is started! We will notify you when the upload complete. It will take about maximum 10 minutes."
        Me.notifyUpload.BalloonTipTitle = "Upload Started"
        Me.notifyUpload.ShowBalloonTip(5000)

        Dim VersionCode = My.Application.Info.Version.ToString
        Dim nvc As New NameValueCollection()
        nvc.Add("pack_name", Me.txttitle.Text)
        nvc.Add("pack_description", Me.txtDescription.Text)
        HttpUploadFile("http://share.akaksr.xyz/upload_processing.php?unitor-mode=UnitorPCbyFollowJB-" & VersionCode.ToString, MainProjectLoader.tbPackDirInfo.Text, "pack_upload", "application/zip", nvc)
        'MsgBox(result)
    End Sub
End Class