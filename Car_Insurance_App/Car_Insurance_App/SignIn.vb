Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class SignIn

    Private Sub SignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mask password by default and set eye-slash image
        Passwordtxt.UseSystemPasswordChar = True
        ShowPassword.Appearance = Appearance.Button
        ShowPassword.Image = My.Resources.eye_slash

        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle ' Or FixedDialog
    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim username As String = txtUsername.Text.Trim().ToLower()
        Dim password As String = Passwordtxt.Text.Trim()

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.")
            Exit Sub
        End If

        If username = "admin" Then
            If password = "Admin@12345" Then
                MessageBox.Show("Login successful as Admin!")
                Dim dashboard As New Dashboard("admin")
                dashboard.Show()
                Me.Hide()
            Else
                MessageBox.Show("Incorrect admin password.")
            End If
        Else
            MessageBox.Show("Only admin login is allowed.")
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPassword.CheckedChanged
        If ShowPassword.Checked Then
            Passwordtxt.UseSystemPasswordChar = False
            ShowPassword.Image = My.Resources.eye ' show eye icon when visible
        Else
            Passwordtxt.UseSystemPasswordChar = True
            ShowPassword.Image = My.Resources.eye_slash ' show eye-slash when hidden
        End If
    End Sub
    Private Sub SignIn_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class
