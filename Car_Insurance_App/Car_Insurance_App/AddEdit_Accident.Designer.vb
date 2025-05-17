<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEdit_Accident
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
        Me.title_lable = New System.Windows.Forms.Label()
        Me.Police_report_number = New System.Windows.Forms.TextBox()
        Me.Damage_cost = New System.Windows.Forms.NumericUpDown()
        Me.Description = New System.Windows.Forms.TextBox()
        Me.Accident_date = New System.Windows.Forms.DateTimePicker()
        Me.Accident_location = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Accident_type = New System.Windows.Forms.ComboBox()
        Me.Natural = New System.Windows.Forms.RadioButton()
        Me.Not_Natural = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Accident_time = New System.Windows.Forms.DomainUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.submit = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        CType(Me.Damage_cost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'title_lable
        '
        Me.title_lable.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title_lable.Location = New System.Drawing.Point(315, 37)
        Me.title_lable.Name = "title_lable"
        Me.title_lable.Size = New System.Drawing.Size(369, 101)
        Me.title_lable.TabIndex = 0
        Me.title_lable.Text = "Add Accident"
        Me.title_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Police_report_number
        '
        Me.Police_report_number.Location = New System.Drawing.Point(207, 200)
        Me.Police_report_number.Name = "Police_report_number"
        Me.Police_report_number.Size = New System.Drawing.Size(254, 26)
        Me.Police_report_number.TabIndex = 1
        '
        'Damage_cost
        '
        Me.Damage_cost.Location = New System.Drawing.Point(212, 379)
        Me.Damage_cost.Maximum = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.Damage_cost.Name = "Damage_cost"
        Me.Damage_cost.Size = New System.Drawing.Size(249, 26)
        Me.Damage_cost.TabIndex = 3
        '
        'Description
        '
        Me.Description.Location = New System.Drawing.Point(212, 430)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(249, 26)
        Me.Description.TabIndex = 4
        '
        'Accident_date
        '
        Me.Accident_date.Location = New System.Drawing.Point(642, 200)
        Me.Accident_date.Name = "Accident_date"
        Me.Accident_date.Size = New System.Drawing.Size(251, 26)
        Me.Accident_date.TabIndex = 5
        '
        'Accident_location
        '
        Me.Accident_location.Location = New System.Drawing.Point(642, 317)
        Me.Accident_location.Name = "Accident_location"
        Me.Accident_location.Size = New System.Drawing.Size(251, 26)
        Me.Accident_location.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Police report number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 269)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Is natural"
        '
        'Accident_type
        '
        Me.Accident_type.FormattingEnabled = True
        Me.Accident_type.Location = New System.Drawing.Point(212, 320)
        Me.Accident_type.Name = "Accident_type"
        Me.Accident_type.Size = New System.Drawing.Size(249, 28)
        Me.Accident_type.TabIndex = 10
        '
        'Natural
        '
        Me.Natural.AutoSize = True
        Me.Natural.Location = New System.Drawing.Point(212, 269)
        Me.Natural.Name = "Natural"
        Me.Natural.Size = New System.Drawing.Size(85, 24)
        Me.Natural.TabIndex = 2
        Me.Natural.TabStop = True
        Me.Natural.Text = "Natural"
        Me.Natural.UseVisualStyleBackColor = True
        '
        'Not_Natural
        '
        Me.Not_Natural.AutoSize = True
        Me.Not_Natural.Location = New System.Drawing.Point(349, 269)
        Me.Not_Natural.Name = "Not_Natural"
        Me.Not_Natural.Size = New System.Drawing.Size(112, 24)
        Me.Not_Natural.TabIndex = 11
        Me.Not_Natural.TabStop = True
        Me.Not_Natural.Text = "Not natural"
        Me.Not_Natural.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 323)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Accident type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 381)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Damage cost"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 436)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(557, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(557, 320)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Location"
        '
        'Accident_time
        '
        Me.Accident_time.Items.Add("00:00")
        Me.Accident_time.Items.Add("01:00")
        Me.Accident_time.Items.Add("02:00")
        Me.Accident_time.Items.Add("03:00")
        Me.Accident_time.Items.Add("04:00")
        Me.Accident_time.Items.Add("05:00")
        Me.Accident_time.Items.Add("06:00")
        Me.Accident_time.Items.Add("07:00")
        Me.Accident_time.Items.Add("08:00")
        Me.Accident_time.Items.Add("09:00")
        Me.Accident_time.Items.Add("10:00")
        Me.Accident_time.Items.Add("11:00")
        Me.Accident_time.Items.Add("12:00")
        Me.Accident_time.Items.Add("13:00")
        Me.Accident_time.Items.Add("14:00")
        Me.Accident_time.Items.Add("15:00")
        Me.Accident_time.Items.Add("16:00")
        Me.Accident_time.Items.Add("17:00")
        Me.Accident_time.Items.Add("18:00")
        Me.Accident_time.Items.Add("19:00")
        Me.Accident_time.Items.Add("20:00")
        Me.Accident_time.Items.Add("21:00")
        Me.Accident_time.Items.Add("22:00")
        Me.Accident_time.Items.Add("23:00")
        Me.Accident_time.Location = New System.Drawing.Point(642, 263)
        Me.Accident_time.Name = "Accident_time"
        Me.Accident_time.Size = New System.Drawing.Size(251, 26)
        Me.Accident_time.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(557, 265)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Time"
        '
        'submit
        '
        Me.submit.Location = New System.Drawing.Point(349, 501)
        Me.submit.Name = "submit"
        Me.submit.Size = New System.Drawing.Size(132, 56)
        Me.submit.TabIndex = 19
        Me.submit.Text = "Submit"
        Me.submit.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(592, 501)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(115, 56)
        Me.cancel.TabIndex = 20
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'AddEdit_Accident
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 592)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.submit)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Accident_time)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Not_Natural)
        Me.Controls.Add(Me.Natural)
        Me.Controls.Add(Me.Accident_type)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Accident_location)
        Me.Controls.Add(Me.Accident_date)
        Me.Controls.Add(Me.Description)
        Me.Controls.Add(Me.Damage_cost)
        Me.Controls.Add(Me.Police_report_number)
        Me.Controls.Add(Me.title_lable)
        Me.Name = "AddEdit_Accident"
        Me.Text = "AddEdit_Accident"
        CType(Me.Damage_cost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents title_lable As Label
    Friend WithEvents Police_report_number As TextBox
    Friend WithEvents Damage_cost As NumericUpDown
    Friend WithEvents Description As TextBox
    Friend WithEvents Accident_date As DateTimePicker
    Friend WithEvents Accident_location As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Accident_type As ComboBox
    Friend WithEvents Natural As RadioButton
    Friend WithEvents Not_Natural As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Accident_time As DomainUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents submit As Button
    Friend WithEvents cancel As Button
End Class
