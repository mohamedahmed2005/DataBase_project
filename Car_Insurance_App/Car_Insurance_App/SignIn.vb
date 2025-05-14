Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class SignIn

    Private Sub SignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim username As String = txtUsername.Text.Trim().ToLower()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.")
            Exit Sub
        End If

        If username = "admin" Then
            If password = "Admin@12345" Then
                MessageBox.Show("Login successful as Admin!")
                'Dim dashboard As New DashboardForm()
                'dashboard.Show()
                'Me.Close()
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

End Class