Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class AddEdit_Customer

    Private _isEditMode As Boolean = False

    Private Sub AddEdit_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isEditMode Then
            Label1.Text = "Edit Customer"
            Submitbtn.Text = "Update"
            txtNationalID.ReadOnly = True ' Prevent NationalID editing in edit mode
        Else
            Label1.Text = "Add Customer"
            Submitbtn.Text = "Register"
            txtNationalID.ReadOnly = False
        End If
    End Sub

    ' Call this method to switch the form to Edit mode and load data
    Public Sub LoadCustomerData(nationalId As Integer)
        _isEditMode = True
        'For Mohamed Connection'
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        'For Mostafa Connection'
        'Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Customer WHERE NationalID = @NationalID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@NationalID", nationalId)

            Try
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtNationalID.Text = reader("NationalID").ToString()

                        ' Check for NULL values before assigning to controls
                        txtFullName.Text = If(reader("FullName") Is DBNull.Value, "", reader("FullName").ToString())
                        txtPhoneNumber.Text = If(reader("PhoneNumber") Is DBNull.Value, "", reader("PhoneNumber").ToString())
                        txtAddress.Text = If(reader("Address") Is DBNull.Value, "", reader("Address").ToString())

                        ' For ComboBoxes, only set if value is not null
                        If reader("Nationality") IsNot DBNull.Value Then
                            cbNationality.SelectedItem = reader("Nationality").ToString()
                        End If

                        If reader("Gender") IsNot DBNull.Value Then
                            cbGender.SelectedItem = reader("Gender").ToString()
                        End If

                        ' For DateTimePicker, only set if value is not null
                        If reader("DateOfBirth") IsNot DBNull.Value Then
                            dtpDOB.Value = Convert.ToDateTime(reader("DateOfBirth"))
                        End If

                        If reader("BloodType") IsNot DBNull.Value Then
                            cbBloodType.SelectedItem = reader("BloodType").ToString()
                        End If
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
        'For Mohamed Connection'
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        'For Mostafa Connection'
        'Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
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

    Private Sub UpdateCustomer()
        'For Mohamed Connection'
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        'For Mostafa Connection'
        'Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Customer SET 
                                FullName = @FullName, 
                                PhoneNumber = @PhoneNumber, 
                                Address = @Address, 
                                Nationality = @Nationality, 
                                Gender = @Gender, 
                                DateOfBirth = @DateOfBirth, 
                                BloodType = @BloodType, 
                                AccountUpdateDate = @UpdateDate
                             WHERE NationalID = @NationalID"

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
            cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
            cmd.Parameters.AddWithValue("@Nationality", cbNationality.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value)
            cmd.Parameters.AddWithValue("@BloodType", cbBloodType.SelectedItem.ToString())
            cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now)
            cmd.Parameters.AddWithValue("@NationalID", Convert.ToInt32(txtNationalID.Text.Trim()))

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

        ' NationalID numeric check
        Dim nationalId As Integer
        If Not Integer.TryParse(txtNationalID.Text, nationalId) Then
            MessageBox.Show("National ID must be a number.")
            Return
        End If

        ' Date of Birth check
        If dtpDOB.Value >= DateTime.Today Then
            MessageBox.Show("Date of Birth must be in the past.")
            Return
        End If

        If _isEditMode Then
            UpdateCustomer()
        Else
            RegisterUser()
        End If

        ' After operation, return to Dashboard
        Dim dashboardForm As New Dashboard("admin") ' Replace with actual username
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Dim dashboardForm As New Dashboard("admin") ' Replace with actual username
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Public Sub SetModeToEdit()
        _isEditMode = True
    End Sub

End Class