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
        Me.AddCustomer = New System.Windows.Forms.Button()
        Me.UpdateCustomer = New System.Windows.Forms.Button()
        Me.Welcome = New System.Windows.Forms.Label()
        Me.DeleteCustomer = New System.Windows.Forms.Button()
        Me.AddCar = New System.Windows.Forms.Button()
        Me.EditCar = New System.Windows.Forms.Button()
        Me.AddAccidentbtn = New System.Windows.Forms.Button()
        Me.EditAccidentbtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AddCustomer
        '
        Me.AddCustomer.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.AddCustomer.Location = New System.Drawing.Point(14, 136)
        Me.AddCustomer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AddCustomer.Name = "AddCustomer"
        Me.AddCustomer.Size = New System.Drawing.Size(152, 29)
        Me.AddCustomer.TabIndex = 0
        Me.AddCustomer.Text = "Add Customer"
        Me.AddCustomer.UseVisualStyleBackColor = True
        '
        'UpdateCustomer
        '
        Me.UpdateCustomer.Location = New System.Drawing.Point(14, 199)
        Me.UpdateCustomer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UpdateCustomer.Name = "UpdateCustomer"
        Me.UpdateCustomer.Size = New System.Drawing.Size(152, 29)
        Me.UpdateCustomer.TabIndex = 1
        Me.UpdateCustomer.Text = "Update Customer"
        Me.UpdateCustomer.UseVisualStyleBackColor = True
        '
        'Welcome
        '
        Me.Welcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Welcome.Location = New System.Drawing.Point(307, 29)
        Me.Welcome.Name = "Welcome"
        Me.Welcome.Size = New System.Drawing.Size(338, 76)
        Me.Welcome.TabIndex = 2
        Me.Welcome.Text = "Welcome ""Username"""
        '
        'DeleteCustomer
        '
        Me.DeleteCustomer.Location = New System.Drawing.Point(14, 258)
        Me.DeleteCustomer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DeleteCustomer.Name = "DeleteCustomer"
        Me.DeleteCustomer.Size = New System.Drawing.Size(152, 29)
        Me.DeleteCustomer.TabIndex = 3
        Me.DeleteCustomer.Text = "Delete Customer"
        Me.DeleteCustomer.UseVisualStyleBackColor = True
        '
        'AddCar
        '
        Me.AddCar.Location = New System.Drawing.Point(315, 136)
        Me.AddCar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AddCar.Name = "AddCar"
        Me.AddCar.Size = New System.Drawing.Size(150, 29)
        Me.AddCar.TabIndex = 4
        Me.AddCar.Text = "Add Car"
        Me.AddCar.UseVisualStyleBackColor = True
        '
        'EditCar
        '
        Me.EditCar.Location = New System.Drawing.Point(315, 199)
        Me.EditCar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EditCar.Name = "EditCar"
        Me.EditCar.Size = New System.Drawing.Size(150, 29)
        Me.EditCar.TabIndex = 5
        Me.EditCar.Text = "Edit car"
        Me.EditCar.UseVisualStyleBackColor = True
        '
        'AddAccidentbtn
        '
        Me.AddAccidentbtn.Location = New System.Drawing.Point(569, 136)
        Me.AddAccidentbtn.Name = "AddAccidentbtn"
        Me.AddAccidentbtn.Size = New System.Drawing.Size(150, 29)
        Me.AddAccidentbtn.TabIndex = 6
        Me.AddAccidentbtn.Text = "Add accident"
        Me.AddAccidentbtn.UseVisualStyleBackColor = True
        '
        'EditAccidentbtn
        '
        Me.EditAccidentbtn.Location = New System.Drawing.Point(569, 199)
        Me.EditAccidentbtn.Name = "EditAccidentbtn"
        Me.EditAccidentbtn.Size = New System.Drawing.Size(150, 29)
        Me.EditAccidentbtn.TabIndex = 7
        Me.EditAccidentbtn.Text = "Edit accident"
        Me.EditAccidentbtn.UseVisualStyleBackColor = True
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 562)
        Me.Controls.Add(Me.EditAccidentbtn)
        Me.Controls.Add(Me.AddAccidentbtn)
        Me.Controls.Add(Me.EditCar)
        Me.Controls.Add(Me.AddCar)
        Me.Controls.Add(Me.DeleteCustomer)
        Me.Controls.Add(Me.Welcome)
        Me.Controls.Add(Me.UpdateCustomer)
        Me.Controls.Add(Me.AddCustomer)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
End Class
