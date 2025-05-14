Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class AddEdit_Customer
    Private Sub AddEdit_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub RegisterUser()
        Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Customer 
                            (FullName, NationalID, PhoneNumber, Address, Nationality, Gender, DateOfBirth, BloodType, MaritalStatus, CustomerStatus, AccountCreationDate, AccountUpdateDate)
                            VALUES
                            (@FullName, @NationalID, @PhoneNumber, @Address, @Nationality, @Gender, @DateOfBirth, @BloodType, @MaritalStatus, @CustomerStatus, @CreationDate, @UpdateDate)"

            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@NationalID", Convert.ToInt32(txtNationalID.Text.Trim()))
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@Nationality", cbNationality.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value)
            cmd.Parameters.AddWithValue("@BloodType", cbBloodType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@MaritalStatus", "Single")
            cmd.Parameters.AddWithValue("@CustomerStatus", "Active")
            cmd.Parameters.AddWithValue("@CreationDate", DateTime.Now)
            cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now)

            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Registration successful!")
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Submitbtn.Click
        If String.IsNullOrWhiteSpace(txtFullName.Text) OrElse
        String.IsNullOrWhiteSpace(txtNationalID.Text) OrElse
        cbGender.SelectedIndex = -1 OrElse
        cbNationality.SelectedIndex = -1 OrElse
        cbBloodType.SelectedIndex = -1 Then

            MessageBox.Show("Please fill in all required fields.")
            Exit Sub
        End If


        ' National ID numeric
        Dim nationalId As Integer
        If Not Integer.TryParse(txtNationalID.Text, nationalId) Then
            MessageBox.Show("National ID must be a number.")
            Exit Sub
        End If

        ' Date of Birth check
        If dtpDOB.Value >= DateTime.Today Then
            MessageBox.Show("Date of Birth must be in the past.")
            Exit Sub
        End If

        ' Insert into DB
        RegisterUser()

        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Dim signInForm As New SignIn()
        signInForm.Show()
        Me.Hide() ' Optional: hides the current form
    End Sub



End Class