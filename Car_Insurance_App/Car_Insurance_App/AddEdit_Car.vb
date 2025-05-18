Imports System.Data.SqlClient

Public Class AddEdit_Car

    Private ReadOnly connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
    'Private ReadOnly connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"
    Private _isEditMode As Boolean = False
    Private _carID As String = "" ' Using LicensePlateNumber as PK (string)

    ' Call this method before showing the form to enable Edit mode and load data

    Private _customerID As String = ""

    Public Sub SetCustomerID(customerID As String)
        _customerID = customerID
    End Sub
    Public Sub SetEditMode()
        _isEditMode = True
    End Sub

    Private Sub AddEdit_Car_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set year picker to show only year
        ModelYearDate.Format = DateTimePickerFormat.Custom
        ModelYearDate.CustomFormat = "yyyy"
        ModelYearDate.ShowUpDown = True

        ' Update label and submit button text depending on mode
        If _isEditMode Then
            AddEditCarLabel.Text = "Edit Car"
            Submit_btn.Text = "Update"
            LicensePlateNumber_input.ReadOnly = True
        Else
            AddEditCarLabel.Text = "Add Car"
            Submit_btn.Text = "Add"
            LicensePlateNumber_input.ReadOnly = False
        End If

        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle ' Or FixedDialog
    End Sub

    ' Load car data into form fields for editing
    Public Sub LoadCarData(CarID)
        Using conn As New SqlConnection(connectionString)
            _isEditMode = True
            Dim query As String = "SELECT * FROM Car WHERE CarID = @CarID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CarID", CarID)

            Try
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    LicensePlateNumber_input.Text = reader("LicensePlateNumber").ToString()
                    ChassisNumber_input.Text = reader("ChassisNumber").ToString()
                    CarStart.Value = Convert.ToDateTime(reader("LicenseStartDate"))
                    CarEnd.Value = Convert.ToDateTime(reader("LicenseEndDate"))
                    GlassKind_combo.SelectedItem = reader("GlassKind").ToString()
                    Color_combo.SelectedItem = reader("Color").ToString()
                    MotorNumber_input.Text = reader("MotorNumber").ToString()
                    Type_combo.SelectedItem = reader("MotorType").ToString()
                    CarTypes_combo.SelectedItem = reader("Type").ToString()
                    CarModel_txt.Text = reader("Model").ToString()
                    Man_txt.Text = reader("Manufacture").ToString()
                    Dim year As Integer = Convert.ToInt32(reader("ModelYear"))
                    ModelYearDate.Value = New DateTime(year, 1, 1)
                    Dim isDisabled As Boolean = Convert.ToBoolean(reader("IsDisabledCar"))
                    Disable_radio.Checked = isDisabled
                    NonDisabled_radio.Checked = Not isDisabled

                    Dim isAvailable As Boolean = Convert.ToBoolean(reader("IsAvailable"))
                    Available_radio.Checked = isAvailable
                    NotAvailable_radio.Checked = Not isAvailable

                    TrafficUnit_txt.Text = reader("TrafficUnit").ToString()
                    TrafficDepartment_txt.Text = reader("TrafficDepartment").ToString()
                Else
                    MessageBox.Show("Car not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End Try
        End Using
    End Sub


    Private Sub Submit_btn_Click(sender As Object, e As EventArgs) Handles Submit_btn.Click
        Dim licensePlate = LicensePlateNumber_input.Text.Trim()
        Dim customerId = _customerID ' You must set this before calling Submit
        Dim ownershipStart = CarStart.Value
        Dim ownershipEnd = CarEnd.Value

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()

            Try
                ' --- INSERT or UPDATE Car ---
                Dim carQuery As String
                If _isEditMode Then
                    carQuery = "UPDATE Car SET 
                    ChassisNumber = @ChassisNumber,
                    LicenseStartDate = @LicenseStartDate,
                    LicenseEndDate = @LicenseEndDate,
                    GlassKind = @GlassKind,
                    Color = @Color,
                    MotorNumber = @MotorNumber,
                    MotorType = @MotorType,
                    Type = @Type,
                    Model = @Model,
                    Manufacture = @Manufacture,
                    ModelYear = @ModelYear,
                    IsDisabledCar = @IsDisabledCar,
                    IsAvailable = @IsAvailable,
                    TrafficUnit = @TrafficUnit,
                    TrafficDepartment = @TrafficDepartment
                    WHERE LicensePlateNumber = @LicensePlateNumber"
                Else
                    carQuery = "INSERT INTO Car 
                    (LicensePlateNumber, ChassisNumber, LicenseStartDate, LicenseEndDate, GlassKind, Color, MotorNumber, MotorType, Type, Model, Manufacture, ModelYear, IsDisabledCar, IsAvailable, TrafficUnit, TrafficDepartment) 
                    VALUES 
                    (@LicensePlateNumber, @ChassisNumber, @LicenseStartDate, @LicenseEndDate, @GlassKind, @Color, @MotorNumber, @MotorType, @Type, @Model, @Manufacture, @ModelYear, @IsDisabledCar, @IsAvailable, @TrafficUnit, @TrafficDepartment)"
                End If

                Using carCmd As New SqlCommand(carQuery, conn, transaction)
                    carCmd.Parameters.AddWithValue("@LicensePlateNumber", licensePlate)
                    carCmd.Parameters.AddWithValue("@ChassisNumber", ChassisNumber_input.Text.Trim())
                    carCmd.Parameters.AddWithValue("@LicenseStartDate", CarStart.Value)
                    carCmd.Parameters.AddWithValue("@LicenseEndDate", CarEnd.Value)
                    carCmd.Parameters.AddWithValue("@GlassKind", GlassKind_combo.SelectedItem?.ToString())
                    carCmd.Parameters.AddWithValue("@Color", Color_combo.SelectedItem?.ToString())
                    carCmd.Parameters.AddWithValue("@MotorNumber", MotorNumber_input.Text.Trim())
                    carCmd.Parameters.AddWithValue("@MotorType", Type_combo.SelectedItem?.ToString())
                    carCmd.Parameters.AddWithValue("@Type", CarTypes_combo.SelectedItem?.ToString())
                    carCmd.Parameters.AddWithValue("@Model", CarModel_txt.Text.Trim())
                    carCmd.Parameters.AddWithValue("@Manufacture", Man_txt.Text.Trim())
                    carCmd.Parameters.AddWithValue("@ModelYear", ModelYearDate.Value.Year)
                    carCmd.Parameters.AddWithValue("@IsDisabledCar", Disable_radio.Checked)
                    carCmd.Parameters.AddWithValue("@IsAvailable", Available_radio.Checked)
                    carCmd.Parameters.AddWithValue("@TrafficUnit", TrafficUnit_txt.Text.Trim())
                    carCmd.Parameters.AddWithValue("@TrafficDepartment", TrafficDepartment_txt.Text.Trim())

                    carCmd.ExecuteNonQuery()
                End Using

                ' --- Get CarID from database ---
                Dim getCarIdQuery As String = "SELECT CarID FROM Car WHERE LicensePlateNumber = @LicensePlateNumber"
                Dim carId As Integer = 0
                Using getCarIdCmd As New SqlCommand(getCarIdQuery, conn, transaction)
                    getCarIdCmd.Parameters.AddWithValue("@LicensePlateNumber", licensePlate)
                    Dim result = getCarIdCmd.ExecuteScalar()
                    If result Is Nothing OrElse IsDBNull(result) Then
                        Throw New Exception("Failed to retrieve CarID after insert/update.")
                    End If
                    carId = Convert.ToInt32(result)
                End Using

                ' --- INSERT or UPDATE Ownership ---
                Dim ownershipExistsQuery As String = "SELECT COUNT(*) FROM Ownership WHERE CarID = @CarID"
                Dim ownershipQuery As String

                Using checkCmd As New SqlCommand(ownershipExistsQuery, conn, transaction)
                    checkCmd.Parameters.AddWithValue("@CarID", carId)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        ownershipQuery = "UPDATE Ownership SET CustomerID = @CustomerID, StartDate = @StartDate, EndDate = @EndDate WHERE CarID = @CarID"
                    Else
                        ownershipQuery = "INSERT INTO Ownership (CustomerID, CarID, StartDate, EndDate) VALUES (@CustomerID, @CarID, @StartDate, @EndDate)"
                    End If
                End Using

                Using ownCmd As New SqlCommand(ownershipQuery, conn, transaction)
                    ownCmd.Parameters.AddWithValue("@CustomerID", customerId)
                    ownCmd.Parameters.AddWithValue("@CarID", carId)
                    ownCmd.Parameters.AddWithValue("@StartDate", ownershipStart)
                    ownCmd.Parameters.AddWithValue("@EndDate", ownershipEnd)

                    ownCmd.ExecuteNonQuery()
                End Using

                transaction.Commit()

                MessageBox.Show(If(_isEditMode, "Car and Ownership updated successfully!", "Car and Ownership added successfully!"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Close()
                Dim dashboardForm As New Dashboard("admin") ' Change username as needed
                dashboardForm.Show()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Dim dashboardForm As New Dashboard("admin") ' Replace with actual username if dynamic
        dashboardForm.Show()
        Me.Hide()
    End Sub

End Class