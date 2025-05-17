Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

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
            Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
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

        ' Ask user if they want to add an existing car or a new car
        Dim choice As DialogResult = MessageBox.Show("Do you want to assign an existing car from the database to this customer?", "Car Choice", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If choice = DialogResult.Cancel Then
            Return
        ElseIf choice = DialogResult.Yes Then
            ' Existing car
            Dim carIDInput As String = InputBox("Enter the Car ID to assign:", "Assign Existing Car")
            If String.IsNullOrWhiteSpace(carIDInput) Then
                MessageBox.Show("Car ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim carIDInt As Integer
            If Not Integer.TryParse(carIDInput, carIDInt) Then
                MessageBox.Show("Car ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not CarExists(carIDInt) Then
                MessageBox.Show($"Car with ID '{carIDInt}' does not exist in the database.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Associate existing car with the customer (you need to implement this method)
            If AssignCarToCustomer(carIDInt, customerID) Then
                MessageBox.Show($"Car ID '{carIDInt}' assigned to Customer ID '{customerID}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to assign the car to the customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf choice = DialogResult.No Then
            ' New car
            Dim addEditCarForm As New AddEdit_Car()
            addEditCarForm.SetCustomerID(customerID)
            addEditCarForm.Show()
            Me.Hide()
        End If
    End Sub
    Private Sub EditCar_Click(sender As Object, e As EventArgs) Handles EditCar.Click
        ' Prompt for Customer ID
        Dim customerID As String = InputBox("Enter the Customer ID:", "Edit Car")

        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Prompt for Car ID
        Dim carIDInput As String = InputBox("Enter the Car ID to edit:", "Edit Car")
        If String.IsNullOrWhiteSpace(carIDInput) Then
            MessageBox.Show("Car ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim carID As Integer
        If Not Integer.TryParse(carIDInput, carID) Then
            MessageBox.Show("Car ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CarExists(carID) Then
            MessageBox.Show($"Car with ID '{carID}' does not exist.", "Invalid Car", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not CarExistsForCustomer(carID, customerID) Then
            MessageBox.Show($"Car ID '{carID}' is not assigned to Customer ID '{customerID}'.", "Ownership Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open the car form with the existing car data
        Dim editCarForm As New AddEdit_Car()
        editCarForm.LoadCarData(carID) ' This method must be implemented in AddEdit_Car form
        editCarForm.SetCustomerID(customerID)
        editCarForm.Show()
        Me.Hide()
    End Sub

    Private Function AssignCarToCustomer(carID As Integer, customerID As String) As Boolean
        Try
            Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"

            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim checkQuery As String = "SELECT COUNT(*) FROM Ownership WHERE CarID = @CarID AND CustomerID = @CustomerID"
                Using checkCmd As New SqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@CarID", carID)
                    checkCmd.Parameters.AddWithValue("@CustomerID", customerID)

                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("This car is already assigned to the selected customer.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End Using

                Dim startDate As Date = Date.Today.AddDays(-2)
                Dim endDate As Date = startDate.AddYears(3)

                Dim insertQuery As String = "INSERT INTO Ownership (CustomerID, CarID, StartDate, EndDate) VALUES (@CustomerID, @CarID, @StartDate, @EndDate)"
                Using insertCmd As New SqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@CustomerID", customerID)
                    insertCmd.Parameters.AddWithValue("@CarID", carID)
                    insertCmd.Parameters.AddWithValue("@StartDate", startDate)
                    insertCmd.Parameters.AddWithValue("@EndDate", endDate)

                    Dim result As Integer = insertCmd.ExecuteNonQuery()
                    Return result > 0
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error assigning car to customer: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' -------------------- Accident BUTTONS --------------------
    Private Sub AddAccidentbtn_Click(sender As Object, e As EventArgs) Handles AddAccidentbtn.Click
        Dim customerID As String = InputBox("Enter the Customer ID:", "Edit Car")

        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Prompt for Car ID
        Dim carIDInput As String = InputBox("Enter the Car ID to edit:", "Edit Car")
        If String.IsNullOrWhiteSpace(carIDInput) Then
            MessageBox.Show("Car ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim carID As Integer
        If Not Integer.TryParse(carIDInput, carID) Then
            MessageBox.Show("Car ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CarExists(carID) Then
            MessageBox.Show($"Car with ID '{carID}' does not exist.", "Invalid Car", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim addEditAccidentForm As New AddEdit_Accident()
        addEditAccidentForm.Set_IDs(customerID, carID)
        addEditAccidentForm.Show()
        Me.Hide()
    End Sub

    Private Sub EditAccidentbtn_Click(sender As Object, e As EventArgs) Handles EditAccidentbtn.Click
        Dim accidentID As String = InputBox("Enter the Accident ID:", "Edit Accident")

        If String.IsNullOrWhiteSpace(accidentID) Then
            MessageBox.Show("Accident ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not AccidentExists(accidentID) Then
            MessageBox.Show($"Accident with ID '{accidentID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim addEditAccidentForm As New AddEdit_Accident()
        addEditAccidentForm.SetModeToEdit()
        addEditAccidentForm.LoadAccidentData(accidentID)
        addEditAccidentForm.Show()
        Me.Hide()
    End Sub

    ' -------------------- HELPER METHODS --------------------

    Private Function CarExists(carID As Integer) As Boolean
        Dim exists As Boolean = False
        Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
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
        Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
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
        Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
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

    Private Function AccidentExists(accidentID As Integer) As Boolean
        Dim exists As Boolean = False
        Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Accident WHERE AccidentID = @AccidentID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@AccidentID", accidentID)

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
