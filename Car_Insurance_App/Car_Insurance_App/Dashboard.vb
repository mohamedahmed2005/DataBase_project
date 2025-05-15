Imports System.Data.SqlClient

Public Class Dashboard
    Private _username As String

    ' Constructor that accepts the username
    Public Sub New(username As String)
        InitializeComponent()
        _username = username
    End Sub

    ' On load, update the Welcome label
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Welcome.Text = "Welcome " & _username
    End Sub

    ' Exit application on form close
    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    ' Open Add Customer form
    Private Sub AddCustomer_Click(sender As Object, e As EventArgs) Handles AddCustomer.Click
        Dim addEditForm As New AddEdit_Customer()
        addEditForm.Show()
        Me.Hide()
    End Sub

    ' Open Edit Customer form after checking existence
    Private Sub UpdateCustomer_Click(sender As Object, e As EventArgs) Handles UpdateCustomer.Click
        Dim input = InputBox("Enter Customer ID of customer to update:", "Edit Customer")
        Dim customerId As Integer
        If Integer.TryParse(input, customerId) Then
            If CustomerExists(customerId) Then
                Dim addEditForm As New AddEdit_Customer()
                addEditForm.SetModeToEdit()
                addEditForm.LoadCustomerData(customerId)
                addEditForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Customer with Customer ID " & customerId & " does not exist.")
            End If
        Else
            MessageBox.Show("Invalid Customer ID entered.")
        End If
    End Sub

    ' Check if customer exists in database
    Private Function CustomerExists(customerID As Integer) As Boolean
        Dim exists As Boolean = False

        'For Mohamed Connection'
        'Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        'For Mostafa Connection'
        Dim connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Customer WHERE CustomerID = @CustomerID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CustomerID", customerID)

            Try
                conn.Open()
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                exists = (count > 0)
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        End Using
        Return exists
    End Function

End Class
