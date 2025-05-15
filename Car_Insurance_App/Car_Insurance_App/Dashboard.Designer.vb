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
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Welcome)
        Me.Controls.Add(Me.UpdateCustomer)
        Me.Controls.Add(Me.AddCustomer)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AddCustomer As Button
    Friend WithEvents UpdateCustomer As Button
    Friend WithEvents Welcome As Label
End Class
