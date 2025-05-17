<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEdit_Customer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddEdit_Customer))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.txtNationalID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbNationality = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbGender = New System.Windows.Forms.ComboBox()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbBloodType = New System.Windows.Forms.ComboBox()
        Me.Submitbtn = New System.Windows.Forms.Button()
        Me.Cancelbtn = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(313, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add Customer"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(69, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Full name"
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(162, 134)
        Me.txtFullName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(229, 22)
        Me.txtFullName.TabIndex = 2
        '
        'txtNationalID
        '
        Me.txtNationalID.Location = New System.Drawing.Point(162, 167)
        Me.txtNationalID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNationalID.Name = "txtNationalID"
        Me.txtNationalID.Size = New System.Drawing.Size(229, 22)
        Me.txtNationalID.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(69, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 18)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "National ID"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(162, 202)
        Me.txtPhoneNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(229, 22)
        Me.txtPhoneNumber.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(66, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 18)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Phone number"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(162, 236)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(229, 22)
        Me.txtAddress.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(69, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 18)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Address"
        '
        'cbNationality
        '
        Me.cbNationality.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbNationality.FormattingEnabled = True
        Me.cbNationality.Items.AddRange(New Object() {"Egyptian", "American", "British", "French", "German", "Italian", "Spanish", "Japanese", "Chinese", "Indian", "Brazilian", "Mexican", "Australian", "Russian", "Canadian", "South African", "Saudi", "Turkish", "Greek", "Nigerian"})
        Me.cbNationality.Location = New System.Drawing.Point(555, 131)
        Me.cbNationality.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbNationality.Name = "cbNationality"
        Me.cbNationality.Size = New System.Drawing.Size(229, 24)
        Me.cbNationality.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(462, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 18)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Nationality"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(462, 171)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 18)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Gender"
        '
        'cbGender
        '
        Me.cbGender.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGender.FormattingEnabled = True
        Me.cbGender.Items.AddRange(New Object() {"M", "F"})
        Me.cbGender.Location = New System.Drawing.Point(555, 167)
        Me.cbGender.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbGender.Name = "cbGender"
        Me.cbGender.Size = New System.Drawing.Size(229, 24)
        Me.cbGender.TabIndex = 19
        '
        'dtpDOB
        '
        Me.dtpDOB.Location = New System.Drawing.Point(555, 204)
        Me.dtpDOB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(229, 22)
        Me.dtpDOB.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(462, 204)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 18)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Date of birth"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(462, 243)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 18)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Blood type"
        '
        'cbBloodType
        '
        Me.cbBloodType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBloodType.FormattingEnabled = True
        Me.cbBloodType.Items.AddRange(New Object() {"A", "A+", "A-", "B", "B+", "B-", "O", "O+", "O-", "AB", "AB+", "AB-"})
        Me.cbBloodType.Location = New System.Drawing.Point(555, 239)
        Me.cbBloodType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbBloodType.Name = "cbBloodType"
        Me.cbBloodType.Size = New System.Drawing.Size(229, 24)
        Me.cbBloodType.TabIndex = 23
        '
        'Submitbtn
        '
        Me.Submitbtn.Location = New System.Drawing.Point(241, 305)
        Me.Submitbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Submitbtn.Name = "Submitbtn"
        Me.Submitbtn.Size = New System.Drawing.Size(116, 46)
        Me.Submitbtn.TabIndex = 25
        Me.Submitbtn.Text = "Submit"
        Me.Submitbtn.UseVisualStyleBackColor = True
        '
        'Cancelbtn
        '
        Me.Cancelbtn.Location = New System.Drawing.Point(441, 305)
        Me.Cancelbtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cancelbtn.Name = "Cancelbtn"
        Me.Cancelbtn.Size = New System.Drawing.Size(116, 46)
        Me.Cancelbtn.TabIndex = 26
        Me.Cancelbtn.Text = "Cancel"
        Me.Cancelbtn.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(162, 271)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(229, 22)
        Me.txtEmail.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(69, 274)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 18)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Email"
        '
        'AddEdit_Customer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(937, 528)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cancelbtn)
        Me.Controls.Add(Me.Submitbtn)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbBloodType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtpDOB)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbGender)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbNationality)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNationalID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "AddEdit_Customer"
        Me.Text = "Add Custome"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtNationalID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbNationality As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbGender As ComboBox
    Friend WithEvents dtpDOB As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cbBloodType As ComboBox
    Friend WithEvents Submitbtn As Button
    Friend WithEvents Cancelbtn As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
End Class