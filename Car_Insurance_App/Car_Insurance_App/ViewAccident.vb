Imports System.Data.SqlClient

Public Class ViewAccident
    Private ReadOnly connectionString As String = "Server=localhost;Database=CarInsuranceSystem;Trusted_Connection=True;"

    ' Optional constructor to accept a query result table
    Public Sub New(Optional ByVal resultTable As DataTable = Nothing)
        InitializeComponent()

        If resultTable IsNot Nothing Then
            DataGridView1.DataSource = resultTable
        Else
            LoadAccidentData()
        End If

        ' Make DataGridView view-only
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
    End Sub

    Private Sub ViewAccident_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No need to call LoadAccidentData if table was already loaded in constructor
    End Sub

    Private Sub LoadAccidentData()
        Dim query As String = "SELECT * FROM Accident"
        Try
            Using conn As New SqlConnection(connectionString)
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading accident data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
