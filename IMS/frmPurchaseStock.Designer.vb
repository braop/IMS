<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseStock
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnStockExel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStockTotal = New System.Windows.Forms.Label()
        Me.stockDataGridView = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.searchDatepicker = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExportPurchas = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.purchaseDataGridView = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.stockDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.purchaseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(687, 463)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Available Stock"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnStockExel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblStockTotal)
        Me.Panel1.Controls.Add(Me.stockDataGridView)
        Me.Panel1.Location = New System.Drawing.Point(-229, -129)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1096, 667)
        Me.Panel1.TabIndex = 3
        '
        'btnStockExel
        '
        Me.btnStockExel.BackColor = System.Drawing.Color.DarkViolet
        Me.btnStockExel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockExel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockExel.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockExel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStockExel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockExel.Location = New System.Drawing.Point(786, 555)
        Me.btnStockExel.Name = "btnStockExel"
        Me.btnStockExel.Size = New System.Drawing.Size(123, 29)
        Me.btnStockExel.TabIndex = 396
        Me.btnStockExel.Text = "&Exel Report"
        Me.btnStockExel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockExel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(237, 555)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 20)
        Me.Label1.TabIndex = 393
        Me.Label1.Text = "Available Stock Cost:"
        '
        'lblStockTotal
        '
        Me.lblStockTotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStockTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockTotal.ForeColor = System.Drawing.Color.White
        Me.lblStockTotal.Location = New System.Drawing.Point(398, 552)
        Me.lblStockTotal.Name = "lblStockTotal"
        Me.lblStockTotal.Size = New System.Drawing.Size(175, 29)
        Me.lblStockTotal.TabIndex = 392
        Me.lblStockTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stockDataGridView
        '
        Me.stockDataGridView.AllowUserToAddRows = False
        Me.stockDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.stockDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.stockDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.stockDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.stockDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.stockDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stockDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.stockDataGridView.ColumnHeadersHeight = 24
        Me.stockDataGridView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.stockDataGridView.EnableHeadersVisualStyles = False
        Me.stockDataGridView.GridColor = System.Drawing.Color.White
        Me.stockDataGridView.Location = New System.Drawing.Point(234, 134)
        Me.stockDataGridView.MultiSelect = False
        Me.stockDataGridView.Name = "stockDataGridView"
        Me.stockDataGridView.ReadOnly = True
        Me.stockDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stockDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.stockDataGridView.RowHeadersWidth = 25
        Me.stockDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.stockDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.stockDataGridView.RowTemplate.Height = 26
        Me.stockDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.stockDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stockDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.stockDataGridView.Size = New System.Drawing.Size(675, 417)
        Me.stockDataGridView.TabIndex = 377
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.searchDatepicker)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btnExportPurchas)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.lblTotal)
        Me.TabPage1.Controls.Add(Me.purchaseDataGridView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(687, 463)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Purchases"
        '
        'searchDatepicker
        '
        Me.searchDatepicker.CustomFormat = "dd/MM/yyyy"
        Me.searchDatepicker.Font = New System.Drawing.Font("Palatino Linotype", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchDatepicker.Location = New System.Drawing.Point(452, 6)
        Me.searchDatepicker.Name = "searchDatepicker"
        Me.searchDatepicker.Size = New System.Drawing.Size(227, 25)
        Me.searchDatepicker.TabIndex = 398
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(362, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 19)
        Me.Label3.TabIndex = 397
        Me.Label3.Text = "Select Date:"
        '
        'btnExportPurchas
        '
        Me.btnExportPurchas.BackColor = System.Drawing.Color.DarkViolet
        Me.btnExportPurchas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportPurchas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportPurchas.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportPurchas.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExportPurchas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportPurchas.Location = New System.Drawing.Point(556, 424)
        Me.btnExportPurchas.Name = "btnExportPurchas"
        Me.btnExportPurchas.Size = New System.Drawing.Size(123, 29)
        Me.btnExportPurchas.TabIndex = 395
        Me.btnExportPurchas.Text = "&Exel Report"
        Me.btnExportPurchas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportPurchas.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 20)
        Me.Label2.TabIndex = 394
        Me.Label2.Text = "Total Purchase Cost:"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(173, 421)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(175, 29)
        Me.lblTotal.TabIndex = 391
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'purchaseDataGridView
        '
        Me.purchaseDataGridView.AllowUserToAddRows = False
        Me.purchaseDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.purchaseDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.purchaseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.purchaseDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.purchaseDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.purchaseDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.purchaseDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.purchaseDataGridView.ColumnHeadersHeight = 24
        Me.purchaseDataGridView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.purchaseDataGridView.EnableHeadersVisualStyles = False
        Me.purchaseDataGridView.GridColor = System.Drawing.Color.White
        Me.purchaseDataGridView.Location = New System.Drawing.Point(6, 35)
        Me.purchaseDataGridView.MultiSelect = False
        Me.purchaseDataGridView.Name = "purchaseDataGridView"
        Me.purchaseDataGridView.ReadOnly = True
        Me.purchaseDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.purchaseDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.purchaseDataGridView.RowHeadersWidth = 25
        Me.purchaseDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.purchaseDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.purchaseDataGridView.RowTemplate.Height = 26
        Me.purchaseDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.purchaseDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.purchaseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.purchaseDataGridView.Size = New System.Drawing.Size(675, 386)
        Me.purchaseDataGridView.TabIndex = 372
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(5, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(695, 496)
        Me.TabControl1.TabIndex = 0
        '
        'frmPurchaseStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 509)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPurchaseStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.stockDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.purchaseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents purchaseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents stockDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblStockTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExportPurchas As System.Windows.Forms.Button
    Friend WithEvents btnStockExel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents searchDatepicker As System.Windows.Forms.DateTimePicker
End Class
