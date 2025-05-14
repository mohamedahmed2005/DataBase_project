Imports System.Data.SqlClient

Public Class SignIn

    Private Sub SignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: Initialize anything on load
    End Sub

    ' Login Button Click
    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Input validation
        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both email and password.")
            Exit Sub
        End If

        ' DB connection
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Customer WHERE Email = @Email AND Password = @Password"
            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@Email", email)
            cmd.Parameters.AddWithValue("@Password", password) ' NOTE: For real apps, hash passwords.

            Try
                conn.Open()
                Dim result As Integer = CInt(cmd.ExecuteScalar())

                If result > 0 Then
                    MessageBox.Show("Login successful!")

                    ' Go to dashboard or next form
                    'Dim dashboard As New Dashboard()
                    'dashboard.Show()
                    Me.Hide()
                    Application.Exit()
                Else
                    MessageBox.Show("Invalid email or password.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Sign Up Redirect Button Click
    Private Sub SignUp_Click(sender As Object, e As EventArgs) Handles SignUp.Click
        Dim signUpForm As New SignUp()
        signUpForm.Show()
        Me.Hide()
    End Sub


End Class
