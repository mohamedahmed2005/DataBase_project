Imports System.Data.SqlClient

Public Class ViewAccident

    Private Sub ViewAccident_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccidentData()
    End Sub

    Private Sub LoadAccidentData()
        Dim connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"
        Dim query As String = "SELECT * FROM Accident"

        Try
            Using conn As New SqlConnection(connectionString)
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt

                ' Make DataGridView view-only
                DataGridView1.ReadOnly = True
                DataGridView1.AllowUserToAddRows = False
                DataGridView1.AllowUserToDeleteRows = False
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DataGridView1.MultiSelect = False
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading accident data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
