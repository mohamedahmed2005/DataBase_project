Imports System.Data.SqlClient
Imports System.Reflection.Emit

Public Class AddEdit_Accident

    Private _isEditMode As Boolean = False
    Private _accidentID As Integer = -1
    Private CustomerID
    Private CarID

    Private ReadOnly connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
    'Private ReadOnly connectionString As String = "Data Source=DESKTOP-77C0VCL\SQLEXPRESS;Initial Catalog=Car_Insurance_DB;Integrated Security=True;Encrypt=false;"

    Private Sub AddEdit_Accident_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isEditMode Then
            title_lable.Text = "Edit Accident"
            submit.Text = "Update"
        Else
            title_lable.Text = "Add Accident"
            submit.Text = "Add"
        End If

        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle ' Or FixedDialog
    End Sub

    Public Sub SetModeToEdit()
        _isEditMode = True
    End Sub

    Public Sub LoadAccidentData(accidentId As Integer)
        _accidentID = accidentId

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Accident WHERE AccidentID = @AccidentID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@AccidentID", accidentId)

            Try
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Police_report_number.Text = reader("PoliceReportNumber").ToString()
                        Natural.Checked = Convert.ToBoolean(reader("IsNatural"))
                        Not_Natural.Checked = Not Natural.Checked
                        Accident_type.SelectedItem = reader("AccidentType").ToString()
                        Damage_cost.Value = Convert.ToDecimal(reader("DamageCost"))
                        Description.Text = reader("Description").ToString()
                        Accident_date.Value = Convert.ToDateTime(reader("AccidentDate"))
                        Accident_time.Text = reader("Time").ToString
                        Accident_location.Text = reader("Location").ToString()
                    Else
                        MessageBox.Show("Accident not found.")
                        Me.Close()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
                Me.Close()
            End Try
        End Using
    End Sub

    Private Sub RegisterAccident(CustomerID, CarID)
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Accident 
                (PoliceReportNumber, IsNatural, AccidentType, DamageCost, Description, AccidentDate, Time, Location, CustomerID, CarID) 
                VALUES 
                (@ReportNumber, @IsNatural, @AccidentType, @DamageCost, @Description, @AccidentDate, @Time, @Location, @CustomerID, @CarID)"

            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ReportNumber", Police_report_number.Text.Trim())
            cmd.Parameters.AddWithValue("@IsNatural", If(Natural.Checked, 1, 0))
            cmd.Parameters.AddWithValue("@AccidentType", Accident_type.Text)
            cmd.Parameters.AddWithValue("@DamageCost", Damage_cost.Value)
            cmd.Parameters.AddWithValue("@Description", Description.Text.Trim())
            cmd.Parameters.AddWithValue("@AccidentDate", Accident_date.Value.Date)
            cmd.Parameters.AddWithValue("@Time", Accident_time.Text)
            cmd.Parameters.AddWithValue("@Location", Accident_location.Text.Trim())
            cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(CustomerID))
            cmd.Parameters.AddWithValue("@CarID", Convert.ToInt32(CarID))

            Try
                conn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Accident registered successfully!")
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub UpdateAccident()
        If _accidentID = -1 Then
            MessageBox.Show("Accident ID is missing.")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Accident SET 
                PoliceReportNumber = @ReportNumber, 
                IsNatural = @IsNatural, 
                AccidentType = @AccidentType, 
                DamageCost = @DamageCost, 
                Description = @Description, 
                AccidentDate = @AccidentDate, 
                Time = @Time, 
                Location = @Location
                WHERE AccidentID = @AccidentID"

            Dim cmd As New SqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@ReportNumber", Police_report_number.Text.Trim())
            cmd.Parameters.AddWithValue("@IsNatural", If(Natural.Checked, 1, 0))
            cmd.Parameters.AddWithValue("@AccidentType", Accident_type.Text)
            cmd.Parameters.AddWithValue("@DamageCost", Damage_cost.Value)
            cmd.Parameters.AddWithValue("@Description", Description.Text.Trim())
            cmd.Parameters.AddWithValue("@AccidentDate", Accident_date.Value.Date)
            cmd.Parameters.AddWithValue("@Time", Accident_time.Text)
            cmd.Parameters.AddWithValue("@Location", Accident_location.Text.Trim())
            cmd.Parameters.AddWithValue("@AccidentID", _accidentID)

            Try
                conn.Open()
                Dim rowsAffected = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Accident updated successfully!")
                Else
                    MessageBox.Show("Update failed. Accident not found.")
                End If
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Submitbtn_Click(sender As Object, e As EventArgs) Handles submit.Click

        If _isEditMode Then
            UpdateAccident()
        Else
            RegisterAccident(CustomerID, CarID)
        End If

        ' Return to dashboard
        Dim dashboardForm As New Dashboard("admin")
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles cancel.Click
        Dim dashboardForm As New Dashboard("admin")
        dashboardForm.Show()
        Me.Hide()
    End Sub

    Public Sub Set_IDs(CustomerID, CarID)
        Me.CustomerID = CustomerID
        Me.CarID = CarID
    End Sub

    'Public Sub Set_Accident(AccidentID)
    '    Me.CustomerID = CustomerID
    '    Me.CarID = CarID
    'End Sub
End Class
