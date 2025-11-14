Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    Dim cnsq As String = "server=DESKTOP-2EHS2ET\MSSQLSERVER01;database=signup;integrated security=true"
    Dim con As New SqlConnection(cnsq)
    Dim dt As New DataTable
    Dim adp As New SqlDataAdapter
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form2.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usr As String = TextBox1.Text.Trim
        Dim pas As String = TextBox2.Text.Trim
        If usr = "" Or pas = "" Then
            Label4.Text = "Please Enter Values !"
            Label4.ForeColor = Color.Red
            Exit Sub
        End If
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim rq As String = "select count(*) from signup_a where username=@user and pass=@mot"
        Dim cmd As New SqlCommand(rq, con)
        cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = usr
        cmd.Parameters.Add("@mot", SqlDbType.VarChar).Value = pas
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        If count > 0 Then
            Label4.Text = "Password Sucssefly"
            Label4.ForeColor = Color.Green
        Else
            Label4.Text = "Passowrd Invalide !"
            Label4.ForeColor = Color.Red
        End If



        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If TextBox2.UseSystemPasswordChar = True Then
            TextBox2.UseSystemPasswordChar = False
            PictureBox3.ImageLocation = "C:\Users\Admin\Desktop\vbapp\opeye.png"
        Else
            TextBox2.UseSystemPasswordChar = True
            PictureBox3.ImageLocation = "C:\Users\Admin\Desktop\vbapp\cleyes.png"
        End If
    End Sub
End Class
