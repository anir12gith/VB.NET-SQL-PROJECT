Imports System.Data.SqlClient
Public Class Form2
    Dim cnsq As String = "server=DESKTOP-2EHS2ET\MSSQLSERVER01;database=signup;integrated security=true"
    Dim con As New SqlConnection(cnsq)
    Dim dt As New DataTable
    Dim adp As New SqlDataAdapter
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ps As String = TextBox2.Text.Trim
        Dim user As String = TextBox1.Text.Trim
        Dim cfmps As String = TextBox3.Text.Trim

        If ps = "" Or ps <> cfmps Or TextBox1.Text = "" Then
            Label5.Text = "Please Check Password"
            Exit Sub
        End If
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim checkuser As New SqlCommand("SELECT COUNT(*) FROM signup_a WHERE username = @user", con)
        checkuser.Parameters.AddWithValue("@user", user)
        Dim count As Integer = Convert.ToInt32(checkuser.ExecuteScalar())
        If count > 0 Then
            Label5.Text = "This User Already Used"
            Label5.ForeColor = Color.Red
            Exit Sub
        End If
        Dim rq As String = "insert into signup_a(username,pass) values(@user,@ps)"
        Dim cmd As New SqlCommand(rq, con)
        cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user
        cmd.Parameters.Add("@ps", SqlDbType.VarChar).Value = ps
        cmd.ExecuteNonQuery()



        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Label5.Text = "Account Created ✅ (Go to Login)"
        Label5.ForeColor = Color.Green
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
        TextBox3.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

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

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If TextBox3.UseSystemPasswordChar = True Then
            TextBox3.UseSystemPasswordChar = False
            PictureBox5.ImageLocation = "C:\Users\Admin\Desktop\vbapp\opeye.png"
        Else
            TextBox3.UseSystemPasswordChar = True
            PictureBox5.ImageLocation = "C:\Users\Admin\Desktop\vbapp\cleyes.png"
        End If
    End Sub
End Class