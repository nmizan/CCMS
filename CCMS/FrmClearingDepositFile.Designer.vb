<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClearingDepositFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClearingDepositFile))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnViewFinalData = New System.Windows.Forms.Button
        Me.cmbValueType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnFinalData = New System.Windows.Forms.Button
        Me.btnViewCheckData = New System.Windows.Forms.Button
        Me.btnCheckData = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpOprDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmbEntryLocation = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtDebitAcc = New System.Windows.Forms.TextBox
        Me.txtFlexBranch = New System.Windows.Forms.TextBox
        Me.txtBatchNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 535)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(718, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(601, 17)
        Me.lblToolStatus.Spring = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnViewFinalData)
        Me.GroupBox2.Controls.Add(Me.cmbValueType)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnFinalData)
        Me.GroupBox2.Controls.Add(Me.btnViewCheckData)
        Me.GroupBox2.Controls.Add(Me.btnCheckData)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(707, 78)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'btnViewFinalData
        '
        Me.btnViewFinalData.Location = New System.Drawing.Point(502, 45)
        Me.btnViewFinalData.Name = "btnViewFinalData"
        Me.btnViewFinalData.Size = New System.Drawing.Size(145, 27)
        Me.btnViewFinalData.TabIndex = 27
        Me.btnViewFinalData.Text = "View Final Data"
        Me.btnViewFinalData.UseVisualStyleBackColor = True
        '
        'cmbValueType
        '
        Me.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValueType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbValueType.FormattingEnabled = True
        Me.cmbValueType.Location = New System.Drawing.Point(76, 17)
        Me.cmbValueType.Name = "cmbValueType"
        Me.cmbValueType.Size = New System.Drawing.Size(101, 21)
        Me.cmbValueType.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Value Type:"
        '
        'btnFinalData
        '
        Me.btnFinalData.Location = New System.Drawing.Point(502, 13)
        Me.btnFinalData.Name = "btnFinalData"
        Me.btnFinalData.Size = New System.Drawing.Size(145, 27)
        Me.btnFinalData.TabIndex = 7
        Me.btnFinalData.Text = "Generate Final File"
        Me.btnFinalData.UseVisualStyleBackColor = True
        '
        'btnViewCheckData
        '
        Me.btnViewCheckData.Location = New System.Drawing.Point(199, 45)
        Me.btnViewCheckData.Name = "btnViewCheckData"
        Me.btnViewCheckData.Size = New System.Drawing.Size(145, 27)
        Me.btnViewCheckData.TabIndex = 7
        Me.btnViewCheckData.Text = "View Checking Data"
        Me.btnViewCheckData.UseVisualStyleBackColor = True
        '
        'btnCheckData
        '
        Me.btnCheckData.Location = New System.Drawing.Point(199, 14)
        Me.btnCheckData.Name = "btnCheckData"
        Me.btnCheckData.Size = New System.Drawing.Size(145, 27)
        Me.btnCheckData.TabIndex = 7
        Me.btnCheckData.Text = "Prepare Checking Data"
        Me.btnCheckData.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(649, 17)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Date:"
        '
        'dtpOprDate
        '
        Me.dtpOprDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpOprDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOprDate.Location = New System.Drawing.Point(76, 19)
        Me.dtpOprDate.Name = "dtpOprDate"
        Me.dtpOprDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpOprDate.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgView)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 188)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(707, 344)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column3, Me.Column1, Me.Column4, Me.Column6, Me.Column2})
        Me.dgView.Location = New System.Drawing.Point(9, 16)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(685, 355)
        Me.dgView.TabIndex = 0
        '
        'Column5
        '
        Me.Column5.HeaderText = "Value Date"
        Me.Column5.Name = "Column5"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Check Number"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column1
        '
        Me.Column1.HeaderText = "DS Code"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "Value Type"
        Me.Column6.Name = "Column6"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Is Checked"
        Me.Column2.Name = "Column2"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpOprDate)
        Me.GroupBox3.Controls.Add(Me.cmbEntryLocation)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(620, 51)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'cmbEntryLocation
        '
        Me.cmbEntryLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntryLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEntryLocation.FormattingEnabled = True
        Me.cmbEntryLocation.Location = New System.Drawing.Point(289, 19)
        Me.cmbEntryLocation.Name = "cmbEntryLocation"
        Me.cmbEntryLocation.Size = New System.Drawing.Size(310, 21)
        Me.cmbEntryLocation.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(196, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Entry Location:"
        '
        'BackgroundWorker1
        '
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtDebitAcc)
        Me.GroupBox4.Controls.Add(Me.txtFlexBranch)
        Me.GroupBox4.Controls.Add(Me.txtBatchNo)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 53)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(707, 51)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        '
        'txtDebitAcc
        '
        Me.txtDebitAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitAcc.Location = New System.Drawing.Point(502, 17)
        Me.txtDebitAcc.Name = "txtDebitAcc"
        Me.txtDebitAcc.ReadOnly = True
        Me.txtDebitAcc.Size = New System.Drawing.Size(192, 20)
        Me.txtDebitAcc.TabIndex = 14
        '
        'txtFlexBranch
        '
        Me.txtFlexBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFlexBranch.Location = New System.Drawing.Point(289, 17)
        Me.txtFlexBranch.Name = "txtFlexBranch"
        Me.txtFlexBranch.ReadOnly = True
        Me.txtFlexBranch.Size = New System.Drawing.Size(97, 20)
        Me.txtFlexBranch.TabIndex = 14
        '
        'txtBatchNo
        '
        Me.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNo.Location = New System.Drawing.Point(76, 17)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.Size = New System.Drawing.Size(101, 20)
        Me.txtBatchNo.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Batch No:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(409, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Debit A/C:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Flex Branch:"
        '
        'BackgroundWorker2
        '
        '
        'FrmClearingDepositFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 557)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClearingDepositFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clearing Deposit File Generation"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents dtpOprDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFinalData As System.Windows.Forms.Button
    Friend WithEvents btnCheckData As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbEntryLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDebitAcc As System.Windows.Forms.TextBox
    Friend WithEvents txtFlexBranch As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbValueType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnViewCheckData As System.Windows.Forms.Button
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnViewFinalData As System.Windows.Forms.Button
End Class
