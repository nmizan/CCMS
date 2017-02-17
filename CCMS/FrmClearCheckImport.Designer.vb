<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClearCheckImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClearCheckImport))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCustomerRef = New System.Windows.Forms.TextBox
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbValueType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnPrepareChecks = New System.Windows.Forms.Button
        Me.txtIssueDate = New System.Windows.Forms.MaskedTextBox
        Me.txtClearingDate = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbEntryLocation = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnImportProcess = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.opdRetFile = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblTotalCheckAmount = New System.Windows.Forms.Label
        Me.lblTotalCheckNo = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblAccNo = New System.Windows.Forms.Label
        Me.lblAccName = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(995, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 10
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
        Me.lblToolStatus.Size = New System.Drawing.Size(878, 17)
        Me.lblToolStatus.Spring = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(903, 18)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(68, 27)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Clearing Date:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtCustomerRef)
        Me.GroupBox3.Controls.Add(Me.txtDepoCode)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.cmbValueType)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.btnPrepareChecks)
        Me.GroupBox3.Controls.Add(Me.txtIssueDate)
        Me.GroupBox3.Controls.Add(Me.txtClearingDate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cmbEntryLocation)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(508, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(475, 146)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Clearing Check Process "
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 20)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Customer Ref:"
        '
        'txtCustomerRef
        '
        Me.txtCustomerRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerRef.Location = New System.Drawing.Point(100, 67)
        Me.txtCustomerRef.Name = "txtCustomerRef"
        Me.txtCustomerRef.Size = New System.Drawing.Size(98, 20)
        Me.txtCustomerRef.TabIndex = 4
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(100, 43)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoCode.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 20)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "DS Code:"
        '
        'cmbValueType
        '
        Me.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValueType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbValueType.FormattingEnabled = True
        Me.cmbValueType.Location = New System.Drawing.Point(99, 91)
        Me.cmbValueType.Name = "cmbValueType"
        Me.cmbValueType.Size = New System.Drawing.Size(101, 21)
        Me.cmbValueType.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 20)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Value Type:"
        '
        'btnPrepareChecks
        '
        Me.btnPrepareChecks.Location = New System.Drawing.Point(296, 113)
        Me.btnPrepareChecks.Name = "btnPrepareChecks"
        Me.btnPrepareChecks.Size = New System.Drawing.Size(145, 27)
        Me.btnPrepareChecks.TabIndex = 6
        Me.btnPrepareChecks.Text = "Prepare Checks"
        Me.btnPrepareChecks.UseVisualStyleBackColor = True
        '
        'txtIssueDate
        '
        Me.txtIssueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssueDate.Location = New System.Drawing.Point(296, 43)
        Me.txtIssueDate.Mask = "00/00/0000"
        Me.txtIssueDate.Name = "txtIssueDate"
        Me.txtIssueDate.Size = New System.Drawing.Size(98, 20)
        Me.txtIssueDate.TabIndex = 3
        Me.txtIssueDate.ValidatingType = GetType(Date)
        '
        'txtClearingDate
        '
        Me.txtClearingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClearingDate.Location = New System.Drawing.Point(100, 19)
        Me.txtClearingDate.Mask = "00/00/0000"
        Me.txtClearingDate.Name = "txtClearingDate"
        Me.txtClearingDate.Size = New System.Drawing.Size(98, 20)
        Me.txtClearingDate.TabIndex = 0
        Me.txtClearingDate.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(205, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Issue Date:"
        '
        'cmbEntryLocation
        '
        Me.cmbEntryLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntryLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEntryLocation.FormattingEnabled = True
        Me.cmbEntryLocation.Location = New System.Drawing.Point(296, 18)
        Me.cmbEntryLocation.Name = "cmbEntryLocation"
        Me.cmbEntryLocation.Size = New System.Drawing.Size(173, 21)
        Me.cmbEntryLocation.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(205, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 20)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Entry Location:"
        '
        'btnImportProcess
        '
        Me.btnImportProcess.Location = New System.Drawing.Point(337, 43)
        Me.btnImportProcess.Name = "btnImportProcess"
        Me.btnImportProcess.Size = New System.Drawing.Size(145, 27)
        Me.btnImportProcess.TabIndex = 1
        Me.btnImportProcess.Text = "Import Process"
        Me.btnImportProcess.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 445)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(977, 51)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnImportProcess)
        Me.GroupBox2.Controls.Add(Me.txtFilename)
        Me.GroupBox2.Controls.Add(Me.btnBrowse)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(497, 77)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Import File"
        '
        'txtFilename
        '
        Me.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilename.Location = New System.Drawing.Point(9, 19)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(473, 20)
        Me.txtFilename.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(165, 43)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(145, 27)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'opdRetFile
        '
        Me.opdRetFile.FileName = "OpenFileDialog1"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.dgView)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 154)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(977, 285)
        Me.GroupBox8.TabIndex = 11
        Me.GroupBox8.TabStop = False
        '
        'dgView
        '
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column17, Me.Column6, Me.Column11, Me.Column8, Me.Column10, Me.Column2, Me.Column1, Me.Column3, Me.Column5, Me.Column4, Me.Column7, Me.Column9})
        Me.dgView.Location = New System.Drawing.Point(6, 15)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(965, 264)
        Me.dgView.TabIndex = 17
        '
        'Column17
        '
        Me.Column17.HeaderText = "DSL"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 60
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nik Branch Code"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 115
        '
        'Column11
        '
        Me.Column11.HeaderText = "Routing No"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 90
        '
        'Column8
        '
        Me.Column8.HeaderText = "Bank Name"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 110
        '
        'Column10
        '
        Me.Column10.HeaderText = "Branch Name"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "Payee Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 110
        '
        'Column1
        '
        Me.Column1.HeaderText = "A/C No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Check Ref"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Check Num"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Is Error"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Error Message"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 200
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblTotalCheckAmount)
        Me.GroupBox4.Controls.Add(Me.lblTotalCheckNo)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.lblAccNo)
        Me.GroupBox4.Controls.Add(Me.lblAccName)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 79)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(496, 69)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        '
        'lblTotalCheckAmount
        '
        Me.lblTotalCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckAmount.Location = New System.Drawing.Point(336, 37)
        Me.lblTotalCheckAmount.Name = "lblTotalCheckAmount"
        Me.lblTotalCheckAmount.Size = New System.Drawing.Size(146, 20)
        Me.lblTotalCheckAmount.TabIndex = 15
        '
        'lblTotalCheckNo
        '
        Me.lblTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckNo.Location = New System.Drawing.Point(93, 37)
        Me.lblTotalCheckNo.Name = "lblTotalCheckNo"
        Me.lblTotalCheckNo.Size = New System.Drawing.Size(146, 20)
        Me.lblTotalCheckNo.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "No. of Check:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(252, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 20)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Check Amount:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Customer A/C:"
        '
        'lblAccNo
        '
        Me.lblAccNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccNo.Location = New System.Drawing.Point(93, 13)
        Me.lblAccNo.Name = "lblAccNo"
        Me.lblAccNo.Size = New System.Drawing.Size(146, 20)
        Me.lblAccNo.TabIndex = 12
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(255, 13)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(226, 20)
        Me.lblAccName.TabIndex = 12
        '
        'FrmClearCheckImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 519)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClearCheckImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clearing Check Upload"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportProcess As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEntryLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents opdRetFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPrepareChecks As System.Windows.Forms.Button
    Friend WithEvents txtIssueDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtClearingDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmbValueType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckNo As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblAccNo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerRef As System.Windows.Forms.TextBox
End Class
