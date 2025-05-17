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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignIn))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lable1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Login = New System.Windows.Forms.Button()
        Me.Passwordtxt = New System.Windows.Forms.MaskedTextBox()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(92, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 18)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(211, 130)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(229, 22)
        Me.txtUsername.TabIndex = 13
        '
        'lable1
        '
        Me.lable1.Location = New System.Drawing.Point(92, 134)
        Me.lable1.Name = "lable1"
        Me.lable1.Size = New System.Drawing.Size(82, 18)
        Me.lable1.TabIndex = 12
        Me.lable1.Text = "Username"
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
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(476, 258)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(116, 46)
        Me.Cancel.TabIndex = 28
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.Login.Location = New System.Drawing.Point(274, 258)
        Me.Login.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(116, 46)
        Me.Login.TabIndex = 27
        Me.Login.Text = "Submit"
        Me.Login.UseVisualStyleBackColor = True
        '
        'Passwordtxt
        '
        Me.Passwordtxt.Location = New System.Drawing.Point(211, 173)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(229, 22)
        Me.Passwordtxt.TabIndex = 29
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Location = New System.Drawing.Point(446, 178)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(18, 17)
        Me.ShowPassword.TabIndex = 30
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'SignIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 470)
        Me.Controls.Add(Me.ShowPassword)
        Me.Controls.Add(Me.Passwordtxt)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lable1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SignIn"
        Me.Text = "SignIn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lable1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Cancel As Button
    Friend WithEvents Login As Button
    Friend WithEvents Passwordtxt As MaskedTextBox
    Friend WithEvents ShowPassword As CheckBox
End Class
