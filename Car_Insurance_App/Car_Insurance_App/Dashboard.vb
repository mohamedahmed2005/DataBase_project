Imports System.Data.SqlClient

Public Class Dashboard
    Private _username As String

    ' Constructor accepting username
    Public Sub New(username As String)
        InitializeComponent()
        _username = username
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Welcome.Text = "Welcome " & _username
    End Sub

    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    ' -------------------- CUSTOMER BUTTONS --------------------

    Private Sub AddCustomer_Click(sender As Object, e As EventArgs) Handles AddCustomer.Click
        Dim addEditCustomerForm As New AddEdit_Customer()
        addEditCustomerForm.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateCustomer_Click(sender As Object, e As EventArgs) Handles UpdateCustomer.Click
        Dim customerID As String = InputBox("Enter the Customer ID:", "Update Customer")
        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim addEditCustomerForm As New AddEdit_Customer()
        addEditCustomerForm.LoadCustomerData(customerID)
        addEditCustomerForm.Show()
        Me.Hide()
    End Sub

    Private Sub DeleteCustomer_Click(sender As Object, e As EventArgs) Handles DeleteCustomer.Click
        Dim customerID As String = InputBox("Enter the Customer ID to delete:", "Delete Customer")
        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim confirmResult As DialogResult = MessageBox.Show($"Are you sure you want to delete customer '{customerID}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmResult = DialogResult.No Then
            Return
        End If

        Try
            Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim deleteQuery As String = "DELETE FROM Customer WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(deleteQuery, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Delete failed: Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' -------------------- CAR BUTTONS --------------------

    Private Sub AddCar_Click(sender As Object, e As EventArgs) Handles AddCar.Click
        Dim customerID As String = InputBox("Enter the Customer ID for this car:", "Add Car")

        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim addEditCarForm As New AddEdit_Car()
        addEditCarForm.SetCustomerID(customerID)
        addEditCarForm.Show()
    End Sub

    Private Sub EditCar_Click(sender As Object, e As EventArgs) Handles EditCar.Click
        Dim customerID As String = InputBox("Enter the Customer ID:", "Edit Car")

        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim CarID As String = InputBox("Enter the Car ID of the car to edit:", "Edit Car")

        If String.IsNullOrWhiteSpace(CarID) Then
            MessageBox.Show("Car ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim carIDInt As Integer
        If Not Integer.TryParse(CarID, carIDInt) Then
            MessageBox.Show("Car ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CarExistsForCustomer(carIDInt, customerID) Then
            MessageBox.Show($"Car with Car ID '{carIDInt}' does not exist for Customer ID '{customerID}'.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim addEditCarForm As New AddEdit_Car()
        addEditCarForm.SetCustomerID(customerID)
        addEditCarForm.SetEditMode()
        addEditCarForm.LoadCarData(CarID)
        addEditCarForm.Show()
        Me.Hide()
    End Sub

    ' -------------------- HELPER METHODS --------------------

    Private Function CarExists(carID As Integer) As Boolean
        Dim exists As Boolean = False
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Car WHERE CarID = @CarID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CarID", carID)

            Try
                conn.Open()
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                exists = (count > 0)
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return exists
    End Function

    Private Function CarExistsForCustomer(carID As Integer, customerID As String) As Boolean
        Dim exists As Boolean = False
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Ownership WHERE CarID = @CarID AND CustomerID = @CustomerID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CarID", carID)
            cmd.Parameters.AddWithValue("@CustomerID", customerID.Trim())

            Try
                conn.Open()
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                exists = (count > 0)
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return exists
    End Function

    Private Function CustomerExists(customerID As String) As Boolean
        Dim exists As Boolean = False
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Customer WHERE CustomerID = @CustomerID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CustomerID", customerID.Trim())

            Try
                conn.Open()
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                exists = (count > 0)
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return exists
    End Function

End Class
