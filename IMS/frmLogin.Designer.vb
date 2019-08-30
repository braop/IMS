<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.passwordcheckLabel = New System.Windows.Forms.Label()
        Me.rBtnAdmin1 = New System.Windows.Forms.RadioButton()
        Me.rBtnAdmin2 = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(158, 74)
        Me.PictureBox1.TabIndex = 159
        Me.PictureBox1.TabStop = False
        '
        'txtPwd
        '
        Me.txtPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Location = New System.Drawing.Point(181, 84)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(181, 23)
        Me.txtPwd.TabIndex = 157
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkViolet
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(375, 34)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "Inventory Management System"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.DarkViolet
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogin.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogin.Location = New System.Drawing.Point(275, 116)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(87, 29)
        Me.btnLogin.TabIndex = 341
        Me.btnLogin.Text = "&Login"
        Me.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'passwordcheckLabel
        '
        Me.passwordcheckLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.passwordcheckLabel.Font = New System.Drawing.Font("Wingdings 2", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordcheckLabel.ForeColor = System.Drawing.Color.Red
        Me.passwordcheckLabel.Location = New System.Drawing.Point(12, 154)
        Me.passwordcheckLabel.Name = "passwordcheckLabel"
        Me.passwordcheckLabel.Size = New System.Drawing.Size(350, 29)
        Me.passwordcheckLabel.TabIndex = 343
        Me.passwordcheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rBtnAdmin1
        '
        Me.rBtnAdmin1.AutoSize = True
        Me.rBtnAdmin1.Checked = True
        Me.rBtnAdmin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rBtnAdmin1.ForeColor = System.Drawing.Color.Green
        Me.rBtnAdmin1.Location = New System.Drawing.Point(182, 55)
        Me.rBtnAdmin1.Name = "rBtnAdmin1"
        Me.rBtnAdmin1.Size = New System.Drawing.Size(84, 21)
        Me.rBtnAdmin1.TabIndex = 344
        Me.rBtnAdmin1.TabStop = True
        Me.rBtnAdmin1.Text = "Admin 1"
        Me.rBtnAdmin1.UseVisualStyleBackColor = True
        '
        'rBtnAdmin2
        '
        Me.rBtnAdmin2.AutoSize = True
        Me.rBtnAdmin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rBtnAdmin2.ForeColor = System.Drawing.Color.DarkBlue
        Me.rBtnAdmin2.Location = New System.Drawing.Point(275, 55)
        Me.rBtnAdmin2.Name = "rBtnAdmin2"
        Me.rBtnAdmin2.Size = New System.Drawing.Size(84, 21)
        Me.rBtnAdmin2.TabIndex = 345
        Me.rBtnAdmin2.Text = "Admin 2"
        Me.rBtnAdmin2.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(374, 190)
        Me.Controls.Add(Me.rBtnAdmin2)
        Me.Controls.Add(Me.rBtnAdmin1)
        Me.Controls.Add(Me.passwordcheckLabel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtPwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents passwordcheckLabel As System.Windows.Forms.Label
    Friend WithEvents rBtnAdmin1 As System.Windows.Forms.RadioButton
    Friend WithEvents rBtnAdmin2 As System.Windows.Forms.RadioButton

End Class
