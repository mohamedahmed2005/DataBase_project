Public Class ResultsForm
    Public Sub New(data As DataTable)
        InitializeComponent()
        dgvResults.DataSource = data
    End Sub
End Class
