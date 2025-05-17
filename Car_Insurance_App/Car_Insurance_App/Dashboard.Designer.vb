<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.AddCustomer = New System.Windows.Forms.Button()
        Me.UpdateCustomer = New System.Windows.Forms.Button()
        Me.Welcome = New System.Windows.Forms.Label()
        Me.DeleteCustomer = New System.Windows.Forms.Button()
        Me.AddCar = New System.Windows.Forms.Button()
        Me.EditCar = New System.Windows.Forms.Button()
        Me.AddAccidentbtn = New System.Windows.Forms.Button()
        Me.EditAccidentbtn = New System.Windows.Forms.Button()
        Me.View_accident = New System.Windows.Forms.Button()
        Me.ExportToPDF = New System.Windows.Forms.Button()
        Me.DeleteCar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AddCustomer
        '
        Me.AddCustomer.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.AddCustomer.Location = New System.Drawing.Point(12, 109)
        Me.AddCustomer.Name = "AddCustomer"
        Me.AddCustomer.Size = New System.Drawing.Size(135, 23)
        Me.AddCustomer.TabIndex = 0
        Me.AddCustomer.Text = "Add Customer"
        Me.AddCustomer.UseVisualStyleBackColor = True
        '
        'UpdateCustomer
        '
        Me.UpdateCustomer.Location = New System.Drawing.Point(12, 159)
        Me.UpdateCustomer.Name = "UpdateCustomer"
        Me.UpdateCustomer.Size = New System.Drawing.Size(135, 23)
        Me.UpdateCustomer.TabIndex = 1
        Me.UpdateCustomer.Text = "Update Customer"
        Me.UpdateCustomer.UseVisualStyleBackColor = True
        '
        'Welcome
        '
        Me.Welcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Welcome.Location = New System.Drawing.Point(273, 23)
        Me.Welcome.Name = "Welcome"
        Me.Welcome.Size = New System.Drawing.Size(300, 61)
        Me.Welcome.TabIndex = 2
        Me.Welcome.Text = "Welcome ""Username"""
        '
        'DeleteCustomer
        '
        Me.DeleteCustomer.Location = New System.Drawing.Point(12, 206)
        Me.DeleteCustomer.Name = "DeleteCustomer"
        Me.DeleteCustomer.Size = New System.Drawing.Size(135, 23)
        Me.DeleteCustomer.TabIndex = 3
        Me.DeleteCustomer.Text = "Delete Customer"
        Me.DeleteCustomer.UseVisualStyleBackColor = True
        '
        'AddCar
        '
        Me.AddCar.Location = New System.Drawing.Point(280, 109)
        Me.AddCar.Name = "AddCar"
        Me.AddCar.Size = New System.Drawing.Size(133, 23)
        Me.AddCar.TabIndex = 4
        Me.AddCar.Text = "Add Car"
        Me.AddCar.UseVisualStyleBackColor = True
        '
        'EditCar
        '
        Me.EditCar.Location = New System.Drawing.Point(280, 159)
        Me.EditCar.Name = "EditCar"
        Me.EditCar.Size = New System.Drawing.Size(133, 23)
        Me.EditCar.TabIndex = 5
        Me.EditCar.Text = "Edit car"
        Me.EditCar.UseVisualStyleBackColor = True
        '
        'AddAccidentbtn
        '
        Me.AddAccidentbtn.Location = New System.Drawing.Point(506, 109)
        Me.AddAccidentbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AddAccidentbtn.Name = "AddAccidentbtn"
        Me.AddAccidentbtn.Size = New System.Drawing.Size(133, 23)
        Me.AddAccidentbtn.TabIndex = 6
        Me.AddAccidentbtn.Text = "Add accident"
        Me.AddAccidentbtn.UseVisualStyleBackColor = True
        '
        'EditAccidentbtn
        '
        Me.EditAccidentbtn.Location = New System.Drawing.Point(506, 159)
        Me.EditAccidentbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EditAccidentbtn.Name = "EditAccidentbtn"
        Me.EditAccidentbtn.Size = New System.Drawing.Size(133, 23)
        Me.EditAccidentbtn.TabIndex = 7
        Me.EditAccidentbtn.Text = "Edit accident"
        Me.EditAccidentbtn.UseVisualStyleBackColor = True
        '
        'View_accident
        '
        Me.View_accident.Location = New System.Drawing.Point(506, 206)
        Me.View_accident.Name = "View_accident"
        Me.View_accident.Size = New System.Drawing.Size(133, 23)
        Me.View_accident.TabIndex = 8
        Me.View_accident.Text = "View Accident"
        Me.View_accident.UseVisualStyleBackColor = True
        '
        'ExportToPDF
        '
        Me.ExportToPDF.Location = New System.Drawing.Point(506, 250)
        Me.ExportToPDF.Name = "ExportToPDF"
        Me.ExportToPDF.Size = New System.Drawing.Size(133, 23)
        Me.ExportToPDF.TabIndex = 9
        Me.ExportToPDF.Text = "Export to PDF"
        Me.ExportToPDF.UseVisualStyleBackColor = True
        '
        'DeleteCar
        '
        Me.DeleteCar.Location = New System.Drawing.Point(280, 206)
        Me.DeleteCar.Name = "DeleteCar"
        Me.DeleteCar.Size = New System.Drawing.Size(133, 23)
        Me.DeleteCar.TabIndex = 11
        Me.DeleteCar.Text = "Delete Car"
        Me.DeleteCar.UseVisualStyleBackColor = True
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DeleteCar)
        Me.Controls.Add(Me.ExportToPDF)
        Me.Controls.Add(Me.View_accident)
        Me.Controls.Add(Me.EditAccidentbtn)
        Me.Controls.Add(Me.AddAccidentbtn)
        Me.Controls.Add(Me.EditCar)
        Me.Controls.Add(Me.AddCar)
        Me.Controls.Add(Me.DeleteCustomer)
        Me.Controls.Add(Me.Welcome)
        Me.Controls.Add(Me.UpdateCustomer)
        Me.Controls.Add(Me.AddCustomer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AddCustomer As Button
    Friend WithEvents UpdateCustomer As Button
    Friend WithEvents Welcome As Label
    Friend WithEvents DeleteCustomer As Button
    Friend WithEvents AddCar As Button
    Friend WithEvents EditCar As Button
    Friend WithEvents AddAccidentbtn As Button
    Friend WithEvents EditAccidentbtn As Button
    Friend WithEvents View_accident As Button
    Friend WithEvents ExportToPDF As Button
    Friend WithEvents DeleteCar As Button
End Class
