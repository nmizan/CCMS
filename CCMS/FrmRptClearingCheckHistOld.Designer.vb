<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptClearingCheckHistOld
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptClearingCheckHistOld))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.cmbEntryLocation = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtBankCode = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnSearchBank = New System.Windows.Forms.Button
        Me.txtBranchCode = New System.Windows.Forms.TextBox
        Me.lblBankName = New System.Windows.Forms.Label
        Me.btnSearchBranch = New System.Windows.Forms.Button
        Me.lblBranchName = New System.Windows.Forms.Label
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCustomerAcc = New System.Windows.Forms.TextBox
        Me.btnSearchCustomer = New System.Windows.Forms.Button
        Me.lblAccName = New System.Windows.Forms.Label
        Me.txtClearingDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtClearingDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Controls.Add(Me.dgView)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 189)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(987, 442)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnExport
        '
        Me.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(788, 9)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(77, 27)
        Me.btnExport.TabIndex = 10
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column11, Me.Column5, Me.Column4, Me.Column2, Me.Column12, Me.Column13, Me.Column9, Me.Column10, Me.Column3, Me.Column1, Me.Column7, Me.Column14})
        Me.dgView.Location = New System.Drawing.Point(6, 42)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(975, 394)
        Me.dgView.TabIndex = 0
        '
        'cmbEntryLocation
        '
        Me.cmbEntryLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntryLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEntryLocation.FormattingEnabled = True
        Me.cmbEntryLocation.Location = New System.Drawing.Point(136, 13)
        Me.cmbEntryLocation.Name = "cmbEntryLocation"
        Me.cmbEntryLocation.Size = New System.Drawing.Size(158, 21)
        Me.cmbEntryLocation.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(22, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Entry Location:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 638)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(993, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblToolStatus
        '
        Me.lblToolStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblToolStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblToolStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblToolStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToolStatus.Name = "lblToolStatus"
        Me.lblToolStatus.Size = New System.Drawing.Size(978, 17)
        Me.lblToolStatus.Spring = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtCheckNumber)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtBankCode)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.btnSearchBank)
        Me.GroupBox2.Controls.Add(Me.txtBranchCode)
        Me.GroupBox2.Controls.Add(Me.lblBankName)
        Me.GroupBox2.Controls.Add(Me.btnSearchBranch)
        Me.GroupBox2.Controls.Add(Me.lblBranchName)
        Me.GroupBox2.Controls.Add(Me.txtDepoCode)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCustomerAcc)
        Me.GroupBox2.Controls.Add(Me.btnSearchCustomer)
        Me.GroupBox2.Controls.Add(Me.lblAccName)
        Me.GroupBox2.Controls.Add(Me.txtClearingDateTo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtClearingDateFrom)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbEntryLocation)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(993, 189)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(660, 156)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 27)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(337, 163)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 20)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Location = New System.Drawing.Point(440, 161)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(171, 20)
        Me.txtAmount.TabIndex = 39
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(22, 163)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 20)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "Check Number:"
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(136, 160)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(170, 20)
        Me.txtCheckNumber.TabIndex = 36
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(22, 115)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Bank:"
        '
        'txtBankCode
        '
        Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankCode.Location = New System.Drawing.Point(136, 112)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(170, 20)
        Me.txtBankCode.TabIndex = 28
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(22, 138)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 20)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "Nik Branch:"
        '
        'btnSearchBank
        '
        Me.btnSearchBank.FlatAppearance.BorderSize = 0
        Me.btnSearchBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBank.Image = CType(resources.GetObject("btnSearchBank.Image"), System.Drawing.Image)
        Me.btnSearchBank.Location = New System.Drawing.Point(312, 110)
        Me.btnSearchBank.Name = "btnSearchBank"
        Me.btnSearchBank.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBank.TabIndex = 29
        Me.btnSearchBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBank.UseVisualStyleBackColor = True
        '
        'txtBranchCode
        '
        Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchCode.Location = New System.Drawing.Point(136, 136)
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.Size = New System.Drawing.Size(170, 20)
        Me.txtBranchCode.TabIndex = 30
        '
        'lblBankName
        '
        Me.lblBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankName.Location = New System.Drawing.Point(340, 111)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(271, 20)
        Me.lblBankName.TabIndex = 35
        '
        'btnSearchBranch
        '
        Me.btnSearchBranch.FlatAppearance.BorderSize = 0
        Me.btnSearchBranch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBranch.Image = CType(resources.GetObject("btnSearchBranch.Image"), System.Drawing.Image)
        Me.btnSearchBranch.Location = New System.Drawing.Point(312, 134)
        Me.btnSearchBranch.Name = "btnSearchBranch"
        Me.btnSearchBranch.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBranch.TabIndex = 31
        Me.btnSearchBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBranch.UseVisualStyleBackColor = True
        '
        'lblBranchName
        '
        Me.lblBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchName.Location = New System.Drawing.Point(340, 135)
        Me.lblBranchName.Name = "lblBranchName"
        Me.lblBranchName.Size = New System.Drawing.Size(271, 20)
        Me.lblBranchName.TabIndex = 34
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(136, 88)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(170, 20)
        Me.txtDepoCode.TabIndex = 26
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(22, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "DS Code:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Customer A/C:"
        '
        'txtCustomerAcc
        '
        Me.txtCustomerAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerAcc.Location = New System.Drawing.Point(136, 63)
        Me.txtCustomerAcc.Name = "txtCustomerAcc"
        Me.txtCustomerAcc.Size = New System.Drawing.Size(170, 20)
        Me.txtCustomerAcc.TabIndex = 22
        '
        'btnSearchCustomer
        '
        Me.btnSearchCustomer.FlatAppearance.BorderSize = 0
        Me.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCustomer.Image = CType(resources.GetObject("btnSearchCustomer.Image"), System.Drawing.Image)
        Me.btnSearchCustomer.Location = New System.Drawing.Point(312, 61)
        Me.btnSearchCustomer.Name = "btnSearchCustomer"
        Me.btnSearchCustomer.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchCustomer.TabIndex = 23
        Me.btnSearchCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchCustomer.UseVisualStyleBackColor = True
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(340, 62)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(271, 20)
        Me.lblAccName.TabIndex = 25
        '
        'txtClearingDateTo
        '
        Me.txtClearingDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClearingDateTo.Location = New System.Drawing.Point(440, 36)
        Me.txtClearingDateTo.Mask = "00/00/0000"
        Me.txtClearingDateTo.Name = "txtClearingDateTo"
        Me.txtClearingDateTo.Size = New System.Drawing.Size(98, 20)
        Me.txtClearingDateTo.TabIndex = 20
        Me.txtClearingDateTo.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(337, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Clearing Date To:"
        '
        'txtClearingDateFrom
        '
        Me.txtClearingDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClearingDateFrom.Location = New System.Drawing.Point(136, 38)
        Me.txtClearingDateFrom.Mask = "00/00/0000"
        Me.txtClearingDateFrom.Name = "txtClearingDateFrom"
        Me.txtClearingDateFrom.Size = New System.Drawing.Size(98, 20)
        Me.txtClearingDateFrom.TabIndex = 18
        Me.txtClearingDateFrom.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Clearing Date From:"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(800, 156)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 27)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Clearing Date"
        Me.Column6.Name = "Column6"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Issue Date"
        Me.Column11.Name = "Column11"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "MOD_NO"
        Me.Column5.HeaderText = "Customer Acc"
        Me.Column5.Name = "Column5"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "S"
        Me.Column4.HeaderText = "Customer Name"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "DS Code"
        Me.Column2.Name = "Column2"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Bank"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Branch"
        Me.Column13.Name = "Column13"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Check Number"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 110
        '
        'Column10
        '
        Me.Column10.HeaderText = "Amount"
        Me.Column10.Name = "Column10"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Status"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 105
        '
        'Column1
        '
        Me.Column1.HeaderText = "Return Date"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 110
        '
        'Column7
        '
        Me.Column7.HeaderText = "Entry Location"
        Me.Column7.Name = "Column7"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Reason"
        Me.Column14.Name = "Column14"
        '
        'FrmRptClearingCheckHistOld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 660)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptClearingCheckHistOld"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clearing Check History [Old Data]"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbEntryLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtClearingDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClearingDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerAcc As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchCustomer As System.Windows.Forms.Button
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnSearchBank As System.Windows.Forms.Button
    Friend WithEvents txtBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents btnSearchBranch As System.Windows.Forms.Button
    Friend WithEvents lblBranchName As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
