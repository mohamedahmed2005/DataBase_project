<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignIn
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
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SignUp = New System.Windows.Forms.Button()
        Me.Login = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(558, 212)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(229, 22)
        Me.txtPassword.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(439, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 18)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Password"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(137, 213)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(229, 22)
        Me.txtEmail.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 18)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Email"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(364, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 46)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Sign in"
        '
        'SignUp
        '
        Me.SignUp.Location = New System.Drawing.Point(21, 413)
        Me.SignUp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SignUp.Name = "SignUp"
        Me.SignUp.Size = New System.Drawing.Size(116, 46)
        Me.SignUp.TabIndex = 28
        Me.SignUp.Text = "SignUp"
        Me.SignUp.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.Login.Location = New System.Drawing.Point(803, 413)
        Me.Login.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(116, 46)
        Me.Login.TabIndex = 27
        Me.Login.Text = "Submit"
        Me.Login.UseVisualStyleBackColor = True
        '
        'SignIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 470)
        Me.Controls.Add(Me.SignUp)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label4)
        Me.Name = "SignIn"
        Me.Text = "SignIn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SignUp As Button
    Friend WithEvents Login As Button
End Class
