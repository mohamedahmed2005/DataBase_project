Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Dashboard
    Private _username As String
    ' Connection string should be defined once and reused
    Private ReadOnly connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
    'Private ReadOnly connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"

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

        Dim confirmResult As DialogResult = MessageBox.Show($"Are you sure you want to delete customer '{customerID}'? This will also delete all ownership records and accidents associated with this customer.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmResult = DialogResult.No Then
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                ' Begin a transaction to ensure all operations succeed or fail together
                Using transaction As SqlTransaction = conn.BeginTransaction()
                    Try
                        ' First delete related accident records
                        Dim deleteAccidentsQuery As String = "DELETE FROM Accident WHERE CustomerID = @CustomerID"
                        Using cmdDeleteAccidents As New SqlCommand(deleteAccidentsQuery, conn, transaction)
                            cmdDeleteAccidents.Parameters.AddWithValue("@CustomerID", customerID)
                            cmdDeleteAccidents.ExecuteNonQuery()
                        End Using

                        ' Next delete ownership records
                        Dim deleteOwnershipQuery As String = "DELETE FROM Ownership WHERE CustomerID = @CustomerID"
                        Using cmdDeleteOwnership As New SqlCommand(deleteOwnershipQuery, conn, transaction)
                            cmdDeleteOwnership.Parameters.AddWithValue("@CustomerID", customerID)
                            cmdDeleteOwnership.ExecuteNonQuery()
                        End Using

                        ' Finally delete the customer
                        Dim deleteCustomerQuery As String = "DELETE FROM Customer WHERE CustomerID = @CustomerID"
                        Using cmdDeleteCustomer As New SqlCommand(deleteCustomerQuery, conn, transaction)
                            cmdDeleteCustomer.Parameters.AddWithValue("@CustomerID", customerID)
                            Dim rowsAffected As Integer = cmdDeleteCustomer.ExecuteNonQuery()
                            If rowsAffected > 0 Then
                                transaction.Commit()
                                MessageBox.Show("Customer and all related records deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                transaction.Rollback()
                                MessageBox.Show("Delete failed: Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
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

            ' Associate existing car with the customer
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
        Dim customerID As String = InputBox("Enter the Customer ID:", "Add Accident")

        If String.IsNullOrWhiteSpace(customerID) Then
            MessageBox.Show("Customer ID is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not CustomerExists(customerID) Then
            MessageBox.Show($"Customer with ID '{customerID}' does not exist.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Prompt for Car ID
        Dim carIDInput As String = InputBox("Enter the Car ID:", "Add Accident")
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

        ' Check if car belongs to customer
        If Not CarExistsForCustomer(carID, customerID) Then
            MessageBox.Show($"Car ID '{carID}' is not assigned to Customer ID '{customerID}'.", "Ownership Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Dim accidentIDInt As Integer
        If Not Integer.TryParse(accidentID, accidentIDInt) Then
            MessageBox.Show("Accident ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not AccidentExists(accidentIDInt) Then
            MessageBox.Show($"Accident with ID '{accidentID}' does not exist.", "Invalid Accident ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub View_accident_Click(sender As Object, e As EventArgs) Handles View_accident.Click
        Me.Hide()
        Dim accidentForm As New ViewAccident()
        accidentForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub ExportToPDF_Click(sender As Object, e As EventArgs) Handles ExportToPDF.Click
        Try
            ' Prompt user for year and month
            Dim inputYear As String = InputBox("Enter the year (e.g., 2024):", "Select Year")
            If String.IsNullOrWhiteSpace(inputYear) OrElse Not Integer.TryParse(inputYear, Nothing) Then
                MessageBox.Show("Invalid year entered.")
                Return
            End If

            Dim inputMonth As String = InputBox("Enter the month number (1-12):", "Select Month")
            If String.IsNullOrWhiteSpace(inputMonth) OrElse Not Integer.TryParse(inputMonth, Nothing) OrElse CInt(inputMonth) < 1 OrElse CInt(inputMonth) > 12 Then
                MessageBox.Show("Invalid month entered.")
                Return
            End If

            Dim year As Integer = CInt(inputYear)
            Dim month As Integer = CInt(inputMonth)

            Dim dtSummary As New DataTable()
            Dim dtDetails As New DataTable()

            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Total accidents for that month
                Dim countQuery As String = "
                SELECT COUNT(*) AS TotalAccidents
                FROM Accident
                WHERE YEAR(AccidentDate) = @Year AND MONTH(AccidentDate) = @Month"
                Using cmd1 As New SqlCommand(countQuery, conn)
                    cmd1.Parameters.AddWithValue("@Year", year)
                    cmd1.Parameters.AddWithValue("@Month", month)
                    Dim adapter1 As New SqlDataAdapter(cmd1)
                    adapter1.Fill(dtSummary)
                End Using

                ' Detailed accident list
                Dim detailQuery As String = "
                SELECT AccidentID, PoliceReportNumber, IsNatural, AccidentType, DamageCost,
                       Description, [Time], AccidentDate, Location, CustomerID, CarID
                FROM Accident
                WHERE YEAR(AccidentDate) = @Year AND MONTH(AccidentDate) = @Month"
                Using cmd2 As New SqlCommand(detailQuery, conn)
                    cmd2.Parameters.AddWithValue("@Year", year)
                    cmd2.Parameters.AddWithValue("@Month", month)
                    Dim adapter2 As New SqlDataAdapter(cmd2)
                    adapter2.Fill(dtDetails)
                End Using
            End Using

            If dtSummary.Rows.Count = 0 OrElse Convert.ToInt32(dtSummary.Rows(0)("TotalAccidents")) = 0 Then
                MessageBox.Show("No accident records found for the selected month.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Ask user where to save the PDF
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf"
            saveFileDialog.FileName = $"Accident_Report_{year}_{month.ToString("D2")}.pdf"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim baseFont As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
                Dim titleFont As New Font(baseFont, 16, Font.Bold)
                Dim headerFont As New Font(baseFont, 10, Font.Bold)
                Dim dataFont As New Font(baseFont, 10)

                Using stream As New FileStream(saveFileDialog.FileName, FileMode.Create)
                    Dim document As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10) ' Landscape for wide table
                    PdfWriter.GetInstance(document, stream)
                    document.Open()

                    ' Title and summary
                    Dim monthName As String = New DateTime(1, month, 1).ToString("MMMM")
                    document.Add(New Paragraph($"Accident Report for {monthName} {year}", titleFont))
                    document.Add(New Paragraph("Generated on: " & DateTime.Now.ToString("dd MMMM yyyy HH:mm"), dataFont))
                    document.Add(New Paragraph("Total Accidents: " & dtSummary.Rows(0)("TotalAccidents").ToString(), dataFont))
                    document.Add(New Paragraph(" "))

                    ' Create PDF table with 11 columns
                    Dim detailTable As New PdfPTable(11)
                    detailTable.WidthPercentage = 100

                    ' Set relative column widths for better readability
                    Dim columnWidths() As Single = {5, 7, 5, 8, 6, 15, 5, 7, 12, 6, 4} ' Adjusted column widths
                    detailTable.SetWidths(columnWidths)

                    ' Column headers
                    Dim headers As String() = {"Accident ID", "Police Report #", "Is Natural", "Accident Type", "Damage Cost",
                                               "Description", "Time", "Accident Date", "Location", "Customer ID", "Car ID"}

                    For Each header In headers
                        detailTable.AddCell(New PdfPCell(New Phrase(header, headerFont)) With {.BackgroundColor = BaseColor.LIGHT_GRAY})
                    Next

                    ' Rows
                    For Each row As DataRow In dtDetails.Rows
                        detailTable.AddCell(New Phrase(row("AccidentID").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(row("PoliceReportNumber").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(If(CBool(row("IsNatural")), "Yes", "No"), dataFont))
                        detailTable.AddCell(New Phrase(row("AccidentType").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(FormatCurrency(row("DamageCost")), dataFont))
                        detailTable.AddCell(New Phrase(row("Description").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(row("Time").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(Convert.ToDateTime(row("AccidentDate")).ToString("yyyy-MM-dd"), dataFont))
                        detailTable.AddCell(New Phrase(row("Location").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(row("CustomerID").ToString(), dataFont))
                        detailTable.AddCell(New Phrase(row("CarID").ToString(), dataFont))
                    Next

                    document.Add(detailTable)
                    document.Close()
                End Using

                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteCar_Click(sender As Object, e As EventArgs) Handles DeleteCar.Click
        ' Prompt for Car ID
        Dim carIDInput As String = InputBox("Enter the Car ID to delete:", "Delete Car")
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

        Dim confirmResult As DialogResult = MessageBox.Show($"Are you sure you want to delete car with ID '{carID}'? This will also delete all ownership records and accidents associated with this car.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmResult = DialogResult.No Then
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                ' Begin a transaction to ensure all operations succeed or fail together
                Using transaction As SqlTransaction = conn.BeginTransaction()
                    Try
                        ' First delete related accident records
                        Dim deleteAccidentsQuery As String = "DELETE FROM Accident WHERE CarID = @CarID"
                        Using cmdDeleteAccidents As New SqlCommand(deleteAccidentsQuery, conn, transaction)
                            cmdDeleteAccidents.Parameters.AddWithValue("@CarID", carID)
                            cmdDeleteAccidents.ExecuteNonQuery()
                        End Using

                        ' Next delete ownership records
                        Dim deleteOwnershipQuery As String = "DELETE FROM Ownership WHERE CarID = @CarID"
                        Using cmdDeleteOwnership As New SqlCommand(deleteOwnershipQuery, conn, transaction)
                            cmdDeleteOwnership.Parameters.AddWithValue("@CarID", carID)
                            cmdDeleteOwnership.ExecuteNonQuery()
                        End Using

                        ' Finally delete the car
                        Dim deleteCarQuery As String = "DELETE FROM Car WHERE CarID = @CarID"
                        Using cmdDeleteCar As New SqlCommand(deleteCarQuery, conn, transaction)
                            cmdDeleteCar.Parameters.AddWithValue("@CarID", carID)
                            Dim rowsAffected As Integer = cmdDeleteCar.ExecuteNonQuery()
                            If rowsAffected > 0 Then
                                transaction.Commit()
                                MessageBox.Show("Car and all related records deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                transaction.Rollback()
                                MessageBox.Show("Delete failed: Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class