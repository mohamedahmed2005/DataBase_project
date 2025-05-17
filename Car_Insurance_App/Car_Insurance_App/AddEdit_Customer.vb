Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class AddEdit_Customer

    Private ReadOnly connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
    'Private ReadOnly connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"

    Private _isEditMode As Boolean = False
    Private _customerID As Integer = -1

    Private Sub AddEdit_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isEditMode Then
            Label1.Text = "Edit Customer"
            Submitbtn.Text = "Update"
            txtNationalID.ReadOnly = True
        Else
            Label1.Text = "Add Customer"
            Submitbtn.Text = "Add"
            txtNationalID.ReadOnly = False
        End If
    End Sub

    Public Sub LoadCustomerData(customerId As Integer)
        _isEditMode = True
        _customerID = customerId

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Customer WHERE CustomerID = @CustomerID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CustomerID", customerId)

            Try
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtNationalID.Text = If(IsDBNull(reader("NationalID")), "", reader("NationalID").ToString())
                        txtFullName.Text = If(IsDBNull(reader("FullName")), "", reader("FullName").ToString())
                        txtPhoneNumber.Text = If(IsDBNull(reader("PhoneNumber")), "", reader("PhoneNumber").ToString())
                        txtAddress.Text = If(IsDBNull(reader("Address")), "", reader("Address").ToString())
                        txtEmail.Text = If(IsDBNull(reader("Email")), "", reader("Email").ToString())
                        cbNationality.SelectedItem = If(IsDBNull(reader("Nationality")), "", reader("Nationality").ToString())
                        cbGender.SelectedItem = If(IsDBNull(reader("Gender")), "", reader("Gender").ToString())

                        If Not IsDBNull(reader("DateOfBirth")) Then
                            dtpDOB.Value = Convert.ToDateTime(reader("DateOfBirth"))
                        End If

                        cbBloodType.SelectedItem = If(IsDBNull(reader("BloodType")), "", reader("BloodType").ToString())

                    Else
                        MessageBox.Show("Customer not found.")
                        Me.Close()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
                Me.Close()
            End Try
        End Using
    End Sub

    Private Sub RegisterUser()
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Customer 
                (FullName, NationalID, PhoneNumber, Address, Email, Nationality, Gender, DateOfBirth, BloodType, CustomerStatus, AccountCreationDate, AccountUpdateDate)
                VALUES
                (@FullName, @NationalID, @PhoneNumber, @Address, @Email, @Nationality, @Gender, @DateOfBirth, @BloodType, @CustomerStatus, @CreationDate, @UpdateDate)"

            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@NationalID", Convert.ToInt32(txtNationalID.Text.Trim()))
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
            cmd.Parameters.AddWithValue("@Nationality", cbNationality.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value)
            cmd.Parameters.AddWithValue("@BloodType", cbBloodType.SelectedItem.ToString())
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

    Private Sub UpdateCustomer()
        If _customerID = -1 Then
            MessageBox.Show("Customer ID is missing.")
            Return
        End If
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Customer SET 
                FullName = @FullName, 
                PhoneNumber = @PhoneNumber, 
                Address = @Address, 
                Email = @Email,
                Nationality = @Nationality, 
                Gender = @Gender, 
                DateOfBirth = @DateOfBirth, 
                BloodType = @BloodType, 
                AccountUpdateDate = @UpdateDate
                WHERE CustomerID = @CustomerID"

            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
            cmd.Parameters.AddWithValue("@Nationality", cbNationality.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value)
            cmd.Parameters.AddWithValue("@BloodType", cbBloodType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now)
            cmd.Parameters.AddWithValue("@CustomerID", _customerID)

            Try
                conn.Open()
                Dim rowsAffected = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Customer updated successfully!")
                Else
                    MessageBox.Show("Update failed. Customer not found.")
                End If
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Submitbtn_Click(sender As Object, e As EventArgs) Handles Submitbtn.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtFullName.Text) OrElse
           String.IsNullOrWhiteSpace(txtNationalID.Text) OrElse
           cbGender.SelectedIndex = -1 OrElse
           cbNationality.SelectedIndex = -1 OrElse
           cbBloodType.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all required fields.")
            Return
        End If

        ' National ID check
        Dim nationalId As Integer
        If Not Integer.TryParse(txtNationalID.Text.Trim(), nationalId) Then
            MessageBox.Show("National ID must be a number.")
            Return
        End If

        ' Date of Birth check
        If dtpDOB.Value >= DateTime.Today Then
            MessageBox.Show("Date of Birth must be in the past.")
            Return
        End If

        ' Email format check
        Dim email As String = txtEmail.Text.Trim()
        Dim emailPattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        If Not Regex.IsMatch(email, emailPattern) Then
            MessageBox.Show("Please enter a valid email address.")
            Return
        End If

        ' Register or Update
        If _isEditMode Then
            UpdateCustomer()
        Else
            RegisterUser()
        End If

        ' Return to Dashboard
        Dim dashboardForm As New Dashboard("admin") ' Replace with actual username if dynamic
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Dim dashboardForm As New Dashboard("admin") ' Replace with actual username if dynamic
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Public Sub SetModeToEdit()
        _isEditMode = True
    End Sub

End Class
