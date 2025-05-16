<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEdit_Car
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
        Me.LicensePlateNumber = New System.Windows.Forms.Label()
        Me.LicensePlateNumber_input = New System.Windows.Forms.TextBox()
        Me.ChassisNumber_input = New System.Windows.Forms.TextBox()
        Me.ChassisNumber = New System.Windows.Forms.Label()
        Me.LicenseStartDate = New System.Windows.Forms.Label()
        Me.CarStart = New System.Windows.Forms.DateTimePicker()
        Me.CarEnd = New System.Windows.Forms.DateTimePicker()
        Me.LicenseEndDate = New System.Windows.Forms.Label()
        Me.GlassKind = New System.Windows.Forms.Label()
        Me.GlassKind_combo = New System.Windows.Forms.ComboBox()
        Me.car_color = New System.Windows.Forms.ColorDialog()
        Me.MotorNumber = New System.Windows.Forms.Label()
        Me.MotorNumber_input = New System.Windows.Forms.TextBox()
        Me.MotorType = New System.Windows.Forms.Label()
        Me.Type_combo = New System.Windows.Forms.ComboBox()
        Me.AddEditCarLabel = New System.Windows.Forms.Label()
        Me.CarType = New System.Windows.Forms.Label()
        Me.CarTypes_combo = New System.Windows.Forms.ComboBox()
        Me.CarModel_txt = New System.Windows.Forms.TextBox()
        Me.CarModel = New System.Windows.Forms.Label()
        Me.Man_txt = New System.Windows.Forms.TextBox()
        Me.Manufacture = New System.Windows.Forms.Label()
        Me.ModelYear = New System.Windows.Forms.Label()
        Me.ModelYearDate = New System.Windows.Forms.DateTimePicker()
        Me.IsDisabledCar = New System.Windows.Forms.Label()
        Me.Disable_radio = New System.Windows.Forms.RadioButton()
        Me.NonDisabled_radio = New System.Windows.Forms.RadioButton()
        Me.NotAvailable_radio = New System.Windows.Forms.RadioButton()
        Me.Available_radio = New System.Windows.Forms.RadioButton()
        Me.IsAvailable = New System.Windows.Forms.Label()
        Me.TrafficUnit_txt = New System.Windows.Forms.TextBox()
        Me.TrafficUnit_label = New System.Windows.Forms.Label()
        Me.TrafficDepartment_txt = New System.Windows.Forms.TextBox()
        Me.TrafficDepartment_label = New System.Windows.Forms.Label()
        Me.Submit_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Color = New System.Windows.Forms.Label()
        Me.Color_combo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LicensePlateNumber
        '
        Me.LicensePlateNumber.AutoSize = True
        Me.LicensePlateNumber.Location = New System.Drawing.Point(19, 83)
        Me.LicensePlateNumber.Name = "LicensePlateNumber"
        Me.LicensePlateNumber.Size = New System.Drawing.Size(133, 16)
        Me.LicensePlateNumber.TabIndex = 0
        Me.LicensePlateNumber.Text = "LicensePlateNumber"
        Me.LicensePlateNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LicensePlateNumber_input
        '
        Me.LicensePlateNumber_input.Location = New System.Drawing.Point(169, 80)
        Me.LicensePlateNumber_input.Name = "LicensePlateNumber_input"
        Me.LicensePlateNumber_input.Size = New System.Drawing.Size(229, 22)
        Me.LicensePlateNumber_input.TabIndex = 1
        '
        'ChassisNumber_input
        '
        Me.ChassisNumber_input.Location = New System.Drawing.Point(169, 125)
        Me.ChassisNumber_input.Name = "ChassisNumber_input"
        Me.ChassisNumber_input.Size = New System.Drawing.Size(229, 22)
        Me.ChassisNumber_input.TabIndex = 3
        '
        'ChassisNumber
        '
        Me.ChassisNumber.AutoSize = True
        Me.ChassisNumber.Location = New System.Drawing.Point(19, 128)
        Me.ChassisNumber.Name = "ChassisNumber"
        Me.ChassisNumber.Size = New System.Drawing.Size(106, 16)
        Me.ChassisNumber.TabIndex = 2
        Me.ChassisNumber.Text = "Chassis Number"
        Me.ChassisNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LicenseStartDate
        '
        Me.LicenseStartDate.AutoSize = True
        Me.LicenseStartDate.Location = New System.Drawing.Point(19, 176)
        Me.LicenseStartDate.Name = "LicenseStartDate"
        Me.LicenseStartDate.Size = New System.Drawing.Size(110, 16)
        Me.LicenseStartDate.TabIndex = 4
        Me.LicenseStartDate.Text = "LicenseStartDate"
        Me.LicenseStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CarStart
        '
        Me.CarStart.Location = New System.Drawing.Point(169, 176)
        Me.CarStart.Name = "CarStart"
        Me.CarStart.Size = New System.Drawing.Size(229, 22)
        Me.CarStart.TabIndex = 5
        '
        'CarEnd
        '
        Me.CarEnd.Location = New System.Drawing.Point(169, 223)
        Me.CarEnd.Name = "CarEnd"
        Me.CarEnd.Size = New System.Drawing.Size(229, 22)
        Me.CarEnd.TabIndex = 7
        '
        'LicenseEndDate
        '
        Me.LicenseEndDate.AutoSize = True
        Me.LicenseEndDate.Location = New System.Drawing.Point(19, 228)
        Me.LicenseEndDate.Name = "LicenseEndDate"
        Me.LicenseEndDate.Size = New System.Drawing.Size(107, 16)
        Me.LicenseEndDate.TabIndex = 6
        Me.LicenseEndDate.Text = "LicenseEndDate"
        Me.LicenseEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GlassKind
        '
        Me.GlassKind.AutoSize = True
        Me.GlassKind.Location = New System.Drawing.Point(19, 278)
        Me.GlassKind.Name = "GlassKind"
        Me.GlassKind.Size = New System.Drawing.Size(68, 16)
        Me.GlassKind.TabIndex = 8
        Me.GlassKind.Text = "GlassKind"
        Me.GlassKind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GlassKind_combo
        '
        Me.GlassKind_combo.FormattingEnabled = True
        Me.GlassKind_combo.Items.AddRange(New Object() {"Tempered Glass", "Laminated Glass", "Tinted Glass", "Clear Glass", "Frosted Glass", "Privacy Glass", "Bulletproof Glass", "Solar Control Glass"})
        Me.GlassKind_combo.Location = New System.Drawing.Point(169, 278)
        Me.GlassKind_combo.Name = "GlassKind_combo"
        Me.GlassKind_combo.Size = New System.Drawing.Size(229, 24)
        Me.GlassKind_combo.TabIndex = 9
        '
        'MotorNumber
        '
        Me.MotorNumber.AutoSize = True
        Me.MotorNumber.Location = New System.Drawing.Point(19, 358)
        Me.MotorNumber.Name = "MotorNumber"
        Me.MotorNumber.Size = New System.Drawing.Size(92, 16)
        Me.MotorNumber.TabIndex = 12
        Me.MotorNumber.Text = "Motor Number"
        Me.MotorNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MotorNumber_input
        '
        Me.MotorNumber_input.Location = New System.Drawing.Point(169, 358)
        Me.MotorNumber_input.Name = "MotorNumber_input"
        Me.MotorNumber_input.Size = New System.Drawing.Size(229, 22)
        Me.MotorNumber_input.TabIndex = 13
        '
        'MotorType
        '
        Me.MotorType.AutoSize = True
        Me.MotorType.Location = New System.Drawing.Point(22, 392)
        Me.MotorType.Name = "MotorType"
        Me.MotorType.Size = New System.Drawing.Size(70, 16)
        Me.MotorType.TabIndex = 14
        Me.MotorType.Text = "Motor type"
        '
        'Type_combo
        '
        Me.Type_combo.FormattingEnabled = True
        Me.Type_combo.Items.AddRange(New Object() {"Gasoline", "Diesel", "Electric", "Hybrid (Gasoline-Electric)", "Hybrid (Diesel-Electric)", ""})
        Me.Type_combo.Location = New System.Drawing.Point(169, 392)
        Me.Type_combo.Name = "Type_combo"
        Me.Type_combo.Size = New System.Drawing.Size(229, 24)
        Me.Type_combo.TabIndex = 15
        '
        'AddEditCarLabel
        '
        Me.AddEditCarLabel.AutoSize = True
        Me.AddEditCarLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddEditCarLabel.Location = New System.Drawing.Point(301, 13)
        Me.AddEditCarLabel.Name = "AddEditCarLabel"
        Me.AddEditCarLabel.Size = New System.Drawing.Size(0, 46)
        Me.AddEditCarLabel.TabIndex = 16
        '
        'CarType
        '
        Me.CarType.Location = New System.Drawing.Point(502, 80)
        Me.CarType.Name = "CarType"
        Me.CarType.Size = New System.Drawing.Size(109, 16)
        Me.CarType.TabIndex = 17
        Me.CarType.Text = "CarType"
        Me.CarType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CarTypes_combo
        '
        Me.CarTypes_combo.FormattingEnabled = True
        Me.CarTypes_combo.Items.AddRange(New Object() {"Sports Car", "Van", "MotorCycle", "Electric Vehicle (EV)", "Minivan"})
        Me.CarTypes_combo.Location = New System.Drawing.Point(732, 69)
        Me.CarTypes_combo.Name = "CarTypes_combo"
        Me.CarTypes_combo.Size = New System.Drawing.Size(248, 24)
        Me.CarTypes_combo.TabIndex = 18
        '
        'CarModel_txt
        '
        Me.CarModel_txt.Location = New System.Drawing.Point(732, 116)
        Me.CarModel_txt.Name = "CarModel_txt"
        Me.CarModel_txt.Size = New System.Drawing.Size(248, 22)
        Me.CarModel_txt.TabIndex = 20
        '
        'CarModel
        '
        Me.CarModel.Location = New System.Drawing.Point(510, 119)
        Me.CarModel.Name = "CarModel"
        Me.CarModel.Size = New System.Drawing.Size(101, 16)
        Me.CarModel.TabIndex = 19
        Me.CarModel.Text = "Car Model"
        Me.CarModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Man_txt
        '
        Me.Man_txt.Location = New System.Drawing.Point(732, 164)
        Me.Man_txt.Name = "Man_txt"
        Me.Man_txt.Size = New System.Drawing.Size(248, 22)
        Me.Man_txt.TabIndex = 21
        '
        'Manufacture
        '
        Me.Manufacture.Location = New System.Drawing.Point(510, 170)
        Me.Manufacture.Name = "Manufacture"
        Me.Manufacture.Size = New System.Drawing.Size(101, 16)
        Me.Manufacture.TabIndex = 22
        Me.Manufacture.Text = "Manufacture"
        Me.Manufacture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ModelYear
        '
        Me.ModelYear.Location = New System.Drawing.Point(514, 215)
        Me.ModelYear.Name = "ModelYear"
        Me.ModelYear.Size = New System.Drawing.Size(109, 23)
        Me.ModelYear.TabIndex = 23
        Me.ModelYear.Text = "Model Year"
        '
        'ModelYearDate
        '
        Me.ModelYearDate.Location = New System.Drawing.Point(732, 210)
        Me.ModelYearDate.Name = "ModelYearDate"
        Me.ModelYearDate.Size = New System.Drawing.Size(248, 22)
        Me.ModelYearDate.TabIndex = 24
        Me.ModelYearDate.TabStop = False
        '
        'IsDisabledCar
        '
        Me.IsDisabledCar.Location = New System.Drawing.Point(502, 260)
        Me.IsDisabledCar.Name = "IsDisabledCar"
        Me.IsDisabledCar.Size = New System.Drawing.Size(121, 23)
        Me.IsDisabledCar.TabIndex = 25
        Me.IsDisabledCar.Text = "Is Disabled Car"
        '
        'Disable_radio
        '
        Me.Disable_radio.AutoSize = True
        Me.Disable_radio.Location = New System.Drawing.Point(2, 12)
        Me.Disable_radio.Name = "Disable_radio"
        Me.Disable_radio.Size = New System.Drawing.Size(83, 20)
        Me.Disable_radio.TabIndex = 26
        Me.Disable_radio.TabStop = True
        Me.Disable_radio.Text = "Disabled"
        Me.Disable_radio.UseVisualStyleBackColor = True
        '
        'NonDisabled_radio
        '
        Me.NonDisabled_radio.AutoSize = True
        Me.NonDisabled_radio.Location = New System.Drawing.Point(89, 12)
        Me.NonDisabled_radio.Name = "NonDisabled_radio"
        Me.NonDisabled_radio.Size = New System.Drawing.Size(111, 20)
        Me.NonDisabled_radio.TabIndex = 27
        Me.NonDisabled_radio.TabStop = True
        Me.NonDisabled_radio.Text = "Non Disabled"
        Me.NonDisabled_radio.UseVisualStyleBackColor = True
        '
        'NotAvailable_radio
        '
        Me.NotAvailable_radio.AutoSize = True
        Me.NotAvailable_radio.Location = New System.Drawing.Point(91, 12)
        Me.NotAvailable_radio.Name = "NotAvailable_radio"
        Me.NotAvailable_radio.Size = New System.Drawing.Size(106, 20)
        Me.NotAvailable_radio.TabIndex = 30
        Me.NotAvailable_radio.TabStop = True
        Me.NotAvailable_radio.Text = "NotAvailable"
        Me.NotAvailable_radio.UseVisualStyleBackColor = True
        '
        'Available_radio
        '
        Me.Available_radio.AutoSize = True
        Me.Available_radio.Location = New System.Drawing.Point(0, 12)
        Me.Available_radio.Name = "Available_radio"
        Me.Available_radio.Size = New System.Drawing.Size(85, 20)
        Me.Available_radio.TabIndex = 29
        Me.Available_radio.TabStop = True
        Me.Available_radio.Text = "Available"
        Me.Available_radio.UseVisualStyleBackColor = True
        '
        'IsAvailable
        '
        Me.IsAvailable.Location = New System.Drawing.Point(502, 304)
        Me.IsAvailable.Name = "IsAvailable"
        Me.IsAvailable.Size = New System.Drawing.Size(121, 23)
        Me.IsAvailable.TabIndex = 28
        Me.IsAvailable.Text = "Is Available Car"
        '
        'TrafficUnit_txt
        '
        Me.TrafficUnit_txt.Location = New System.Drawing.Point(732, 346)
        Me.TrafficUnit_txt.Name = "TrafficUnit_txt"
        Me.TrafficUnit_txt.Size = New System.Drawing.Size(248, 22)
        Me.TrafficUnit_txt.TabIndex = 32
        '
        'TrafficUnit_label
        '
        Me.TrafficUnit_label.Location = New System.Drawing.Point(502, 352)
        Me.TrafficUnit_label.Name = "TrafficUnit_label"
        Me.TrafficUnit_label.Size = New System.Drawing.Size(96, 16)
        Me.TrafficUnit_label.TabIndex = 31
        Me.TrafficUnit_label.Text = "TrafficUnit"
        Me.TrafficUnit_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TrafficDepartment_txt
        '
        Me.TrafficDepartment_txt.Location = New System.Drawing.Point(732, 386)
        Me.TrafficDepartment_txt.Name = "TrafficDepartment_txt"
        Me.TrafficDepartment_txt.Size = New System.Drawing.Size(248, 22)
        Me.TrafficDepartment_txt.TabIndex = 34
        '
        'TrafficDepartment_label
        '
        Me.TrafficDepartment_label.Location = New System.Drawing.Point(502, 394)
        Me.TrafficDepartment_label.Name = "TrafficDepartment_label"
        Me.TrafficDepartment_label.Size = New System.Drawing.Size(121, 16)
        Me.TrafficDepartment_label.TabIndex = 33
        Me.TrafficDepartment_label.Text = "TrafficDepartment"
        Me.TrafficDepartment_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Submit_btn
        '
        Me.Submit_btn.Location = New System.Drawing.Point(169, 464)
        Me.Submit_btn.Name = "Submit_btn"
        Me.Submit_btn.Size = New System.Drawing.Size(117, 40)
        Me.Submit_btn.TabIndex = 35
        Me.Submit_btn.Text = "Submit"
        Me.Submit_btn.UseVisualStyleBackColor = True
        '
        'Cancel_btn
        '
        Me.Cancel_btn.Location = New System.Drawing.Point(676, 474)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(117, 40)
        Me.Cancel_btn.TabIndex = 37
        Me.Cancel_btn.Text = "Cancel"
        Me.Cancel_btn.UseVisualStyleBackColor = True
        '
        'Color
        '
        Me.Color.AutoSize = True
        Me.Color.Location = New System.Drawing.Point(19, 317)
        Me.Color.Name = "Color"
        Me.Color.Size = New System.Drawing.Size(39, 16)
        Me.Color.TabIndex = 10
        Me.Color.Text = "Color"
        Me.Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Color_combo
        '
        Me.Color_combo.FormattingEnabled = True
        Me.Color_combo.Items.AddRange(New Object() {"Red", "Blue", "Green", "White", "Yellow", "Black", "Purble", "Gray", "Silver"})
        Me.Color_combo.Location = New System.Drawing.Point(169, 317)
        Me.Color_combo.Name = "Color_combo"
        Me.Color_combo.Size = New System.Drawing.Size(229, 24)
        Me.Color_combo.TabIndex = 38
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Disable_radio)
        Me.GroupBox2.Controls.Add(Me.NonDisabled_radio)
        Me.GroupBox2.Location = New System.Drawing.Point(742, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 38)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Available_radio)
        Me.GroupBox3.Controls.Add(Me.NotAvailable_radio)
        Me.GroupBox3.Location = New System.Drawing.Point(744, 300)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(222, 38)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        '
        'AddEdit_Car
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 546)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Color_combo)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.Submit_btn)
        Me.Controls.Add(Me.TrafficDepartment_txt)
        Me.Controls.Add(Me.TrafficDepartment_label)
        Me.Controls.Add(Me.TrafficUnit_txt)
        Me.Controls.Add(Me.TrafficUnit_label)
        Me.Controls.Add(Me.IsAvailable)
        Me.Controls.Add(Me.IsDisabledCar)
        Me.Controls.Add(Me.ModelYearDate)
        Me.Controls.Add(Me.ModelYear)
        Me.Controls.Add(Me.Manufacture)
        Me.Controls.Add(Me.Man_txt)
        Me.Controls.Add(Me.CarModel_txt)
        Me.Controls.Add(Me.CarModel)
        Me.Controls.Add(Me.CarTypes_combo)
        Me.Controls.Add(Me.CarType)
        Me.Controls.Add(Me.AddEditCarLabel)
        Me.Controls.Add(Me.Type_combo)
        Me.Controls.Add(Me.MotorType)
        Me.Controls.Add(Me.MotorNumber_input)
        Me.Controls.Add(Me.MotorNumber)
        Me.Controls.Add(Me.Color)
        Me.Controls.Add(Me.GlassKind_combo)
        Me.Controls.Add(Me.GlassKind)
        Me.Controls.Add(Me.CarEnd)
        Me.Controls.Add(Me.LicenseEndDate)
        Me.Controls.Add(Me.CarStart)
        Me.Controls.Add(Me.LicenseStartDate)
        Me.Controls.Add(Me.ChassisNumber_input)
        Me.Controls.Add(Me.ChassisNumber)
        Me.Controls.Add(Me.LicensePlateNumber_input)
        Me.Controls.Add(Me.LicensePlateNumber)
        Me.Name = "AddEdit_Car"
        Me.Text = "AddEdit_Car"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LicensePlateNumber As Label
    Friend WithEvents LicensePlateNumber_input As TextBox
    Friend WithEvents ChassisNumber_input As TextBox
    Friend WithEvents ChassisNumber As Label
    Friend WithEvents LicenseStartDate As Label
    Friend WithEvents CarStart As DateTimePicker
    Friend WithEvents CarEnd As DateTimePicker
    Friend WithEvents LicenseEndDate As Label
    Friend WithEvents GlassKind As Label
    Friend WithEvents GlassKind_combo As ComboBox
    Friend WithEvents car_color As ColorDialog
    Friend WithEvents MotorNumber As Label
    Friend WithEvents MotorNumber_input As TextBox
    Friend WithEvents MotorType As Label
    Friend WithEvents Type_combo As ComboBox
    Friend WithEvents AddEditCarLabel As Label
    Friend WithEvents CarType As Label
    Friend WithEvents CarTypes_combo As ComboBox
    Friend WithEvents CarModel_txt As TextBox
    Friend WithEvents CarModel As Label
    Friend WithEvents Man_txt As TextBox
    Friend WithEvents Manufacture As Label
    Friend WithEvents ModelYear As Label
    Friend WithEvents ModelYearDate As DateTimePicker
    Friend WithEvents IsDisabledCar As Label
    Friend WithEvents Disable_radio As RadioButton
    Friend WithEvents NonDisabled_radio As RadioButton
    Friend WithEvents NotAvailable_radio As RadioButton
    Friend WithEvents Available_radio As RadioButton
    Friend WithEvents IsAvailable As Label
    Friend WithEvents TrafficUnit_txt As TextBox
    Friend WithEvents TrafficUnit_label As Label
    Friend WithEvents TrafficDepartment_txt As TextBox
    Friend WithEvents TrafficDepartment_label As Label
    Friend WithEvents Submit_btn As Button
    Friend WithEvents Cancel_btn As Button
    Friend WithEvents Color As Label
    Friend WithEvents Color_combo As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
