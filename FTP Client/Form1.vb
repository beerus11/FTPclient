Imports System.Net

Public Class Form1

    Private WithEvents myFtpUploadWebClient As New WebClient
    'here you track what happened when upload completes
    Private Sub myFtpUploadWebClient_UploadFileCompleted(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs) Handles myFtpUploadWebClient.UploadFileCompleted
        'If we didn't succeed, we want to know what went wrong
        If e.Error IsNot Nothing Then
            MessageBox.Show(e.Error.Message)

        Else

            Label1.Text = "File Uploaded!"
        End If
    End Sub
    'and here we listen to WebClient's event when UL progress changes
    Private Sub myFtpUploadWebClient_UploadProgressChanged(ByVal sender As Object, ByVal e As System.Net.UploadProgressChangedEventArgs) Handles myFtpUploadWebClient.UploadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label2.Text = e.ProgressPercentage & "%"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
        OpenFileDialog1.Title = "Choose File To Upload"
        TextBox3.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myUri As New Uri("ftp://" & TextBox4.Text.Trim & "/" & OpenFileDialog1.SafeFileName)
        Label1.Text = "Uploading....."
        myFtpUploadWebClient.Credentials = New System.Net.NetworkCredential(TextBox1.Text.Trim, TextBox2.Text.Trim)

        myFtpUploadWebClient.UploadFileAsync(myUri, OpenFileDialog1.FileName)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
