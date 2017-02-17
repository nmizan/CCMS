<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPDCDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPDCDet))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnExit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkAuthorized = New System.Windows.Forms.CheckBox
        Me.chkOpen = New System.Windows.Forms.CheckBox
        Me.lblAuthDate = New System.Windows.Forms.Label
        Me.lblInputDate = New System.Windows.Forms.Label
        Me.lblModNo = New System.Windows.Forms.Label
        Me.lblAuthBy = New System.Windows.Forms.Label
        Me.lblInputBy = New System.Windows.Forms.Label
        Me.btnAuthorize = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblVerTot = New System.Windows.Forms.Label
        Me.lblVerNo = New System.Windows.Forms.Label
        Me.btnUnlock = New System.Windows.Forms.Button
        Me.btnNextVer = New System.Windows.Forms.Button
        Me.btnPrevVer = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblEntryDate = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.chkBBK = New System.Windows.Forms.CheckBox
        Me.chkChqRef = New System.Windows.Forms.CheckBox
        Me.chkChqType = New System.Windows.Forms.CheckBox
        Me.chkAccNo = New System.Windows.Forms.CheckBox
        Me.btnSearchLocation = New System.Windows.Forms.Button
        Me.lblEntryLocation = New System.Windows.Forms.Label
        Me.txtClearingDate = New System.Windows.Forms.MaskedTextBox
        Me.txtEntryLocation = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnSearchCustomer = New System.Windows.Forms.Button
        Me.lblAccName = New System.Windows.Forms.Label
        Me.txtCustomerAcc = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblPDCStatus = New System.Windows.Forms.Label
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCustomerRef = New System.Windows.Forms.TextBox
        Me.txtTotalCheckNo = New System.Windows.Forms.TextBox
        Me.txtTotalCheckAmount = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmbValueType = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblRowNo = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.txtCheckTypeCode = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.btnSearchCheckType = New System.Windows.Forms.Button
        Me.txtIssueDate = New System.Windows.Forms.MaskedTextBox
        Me.lblCheckTypeName = New System.Windows.Forms.Label
        Me.txtCheckRef = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtAccNo = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtBankCode = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnSearchBank = New System.Windows.Forms.Button
        Me.txtBranchCode = New System.Windows.Forms.TextBox
        Me.lblBankName = New System.Windows.Forms.Label
        Me.btnSearchBranch = New System.Windows.Forms.Button
        Me.lblBranchName = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btnRemoveFromGrid = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAddToGrid = New System.Windows.Forms.Button
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpBBK = New System.Windows.Forms.GroupBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtBatchNo = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtBookNo = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCheckSeries = New System.Windows.Forms.TextBox
        Me.lblTotalCheckAmount = New System.Windows.Forms.Label
        Me.lblTotalCheckNo = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBBK.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 681)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(873, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 13
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
        Me.lblToolStatus.Size = New System.Drawing.Size(858, 17)
        Me.lblToolStatus.Spring = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(801, 637)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkAuthorized)
        Me.GroupBox3.Controls.Add(Me.chkOpen)
        Me.GroupBox3.Controls.Add(Me.lblAuthDate)
        Me.GroupBox3.Controls.Add(Me.lblInputDate)
        Me.GroupBox3.Controls.Add(Me.lblModNo)
        Me.GroupBox3.Controls.Add(Me.lblAuthBy)
        Me.GroupBox3.Controls.Add(Me.lblInputBy)
        Me.GroupBox3.Controls.Add(Me.btnAuthorize)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 619)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 58)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status"
        '
        'chkAuthorized
        '
        Me.chkAuthorized.AutoSize = True
        Me.chkAuthorized.Enabled = False
        Me.chkAuthorized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAuthorized.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAuthorized.Location = New System.Drawing.Point(396, 34)
        Me.chkAuthorized.Name = "chkAuthorized"
        Me.chkAuthorized.Size = New System.Drawing.Size(66, 16)
        Me.chkAuthorized.TabIndex = 4
        Me.chkAuthorized.Text = "Authorized"
        Me.chkAuthorized.UseVisualStyleBackColor = True
        '
        'chkOpen
        '
        Me.chkOpen.AutoSize = True
        Me.chkOpen.Enabled = False
        Me.chkOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOpen.Location = New System.Drawing.Point(396, 13)
        Me.chkOpen.Name = "chkOpen"
        Me.chkOpen.Size = New System.Drawing.Size(43, 16)
        Me.chkOpen.TabIndex = 4
        Me.chkOpen.Text = "Open"
        Me.chkOpen.UseVisualStyleBackColor = True
        '
        'lblAuthDate
        '
        Me.lblAuthDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuthDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthDate.ForeColor = System.Drawing.Color.Maroon
        Me.lblAuthDate.Location = New System.Drawing.Point(238, 29)
        Me.lblAuthDate.Name = "lblAuthDate"
        Me.lblAuthDate.Size = New System.Drawing.Size(115, 18)
        Me.lblAuthDate.TabIndex = 0
        Me.lblAuthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInputDate
        '
        Me.lblInputDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInputDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputDate.ForeColor = System.Drawing.Color.Maroon
        Me.lblInputDate.Location = New System.Drawing.Point(64, 29)
        Me.lblInputDate.Name = "lblInputDate"
        Me.lblInputDate.Size = New System.Drawing.Size(115, 18)
        Me.lblInputDate.TabIndex = 0
        Me.lblInputDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModNo
        '
        Me.lblModNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModNo.ForeColor = System.Drawing.Color.Maroon
        Me.lblModNo.Location = New System.Drawing.Point(355, 29)
        Me.lblModNo.Name = "lblModNo"
        Me.lblModNo.Size = New System.Drawing.Size(35, 18)
        Me.lblModNo.TabIndex = 0
        Me.lblModNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAuthBy
        '
        Me.lblAuthBy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuthBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthBy.ForeColor = System.Drawing.Color.Maroon
        Me.lblAuthBy.Location = New System.Drawing.Point(181, 29)
        Me.lblAuthBy.Name = "lblAuthBy"
        Me.lblAuthBy.Size = New System.Drawing.Size(55, 18)
        Me.lblAuthBy.TabIndex = 0
        Me.lblAuthBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInputBy
        '
        Me.lblInputBy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInputBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputBy.ForeColor = System.Drawing.Color.Maroon
        Me.lblInputBy.Location = New System.Drawing.Point(7, 29)
        Me.lblInputBy.Name = "lblInputBy"
        Me.lblInputBy.Size = New System.Drawing.Size(55, 18)
        Me.lblInputBy.TabIndex = 0
        Me.lblInputBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAuthorize
        '
        Me.btnAuthorize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAuthorize.Image = CType(resources.GetObject("btnAuthorize.Image"), System.Drawing.Image)
        Me.btnAuthorize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAuthorize.Location = New System.Drawing.Point(465, 18)
        Me.btnAuthorize.Name = "btnAuthorize"
        Me.btnAuthorize.Size = New System.Drawing.Size(77, 27)
        Me.btnAuthorize.TabIndex = 3
        Me.btnAuthorize.Text = "Authorize"
        Me.btnAuthorize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAuthorize.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(355, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Mod No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(270, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Date Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(191, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Auth By"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(100, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date Time"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Input By"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.lblVerTot)
        Me.GroupBox1.Controls.Add(Me.lblVerNo)
        Me.GroupBox1.Controls.Add(Me.btnUnlock)
        Me.GroupBox1.Controls.Add(Me.btnNextVer)
        Me.GroupBox1.Controls.Add(Me.btnPrevVer)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(873, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(799, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 17)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Of"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(681, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Version No:"
        '
        'btnNew
        '
        Me.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(82, 13)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(68, 27)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(156, 13)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 27)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblVerTot
        '
        Me.lblVerTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVerTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerTot.ForeColor = System.Drawing.Color.Maroon
        Me.lblVerTot.Location = New System.Drawing.Point(818, 18)
        Me.lblVerTot.Name = "lblVerTot"
        Me.lblVerTot.Size = New System.Drawing.Size(21, 18)
        Me.lblVerTot.TabIndex = 0
        Me.lblVerTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVerNo
        '
        Me.lblVerNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVerNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerNo.ForeColor = System.Drawing.Color.Maroon
        Me.lblVerNo.Location = New System.Drawing.Point(775, 18)
        Me.lblVerNo.Name = "lblVerNo"
        Me.lblVerNo.Size = New System.Drawing.Size(21, 18)
        Me.lblVerNo.TabIndex = 0
        Me.lblVerNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUnlock
        '
        Me.btnUnlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnUnlock.Image = CType(resources.GetObject("btnUnlock.Image"), System.Drawing.Image)
        Me.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUnlock.Location = New System.Drawing.Point(8, 13)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(68, 27)
        Me.btnUnlock.TabIndex = 0
        Me.btnUnlock.Text = "Unlock"
        Me.btnUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnlock.UseVisualStyleBackColor = True
        '
        'btnNextVer
        '
        Me.btnNextVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextVer.FlatAppearance.BorderSize = 0
        Me.btnNextVer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnNextVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextVer.Image = CType(resources.GetObject("btnNextVer.Image"), System.Drawing.Image)
        Me.btnNextVer.Location = New System.Drawing.Point(842, 12)
        Me.btnNextVer.Name = "btnNextVer"
        Me.btnNextVer.Size = New System.Drawing.Size(26, 28)
        Me.btnNextVer.TabIndex = 7
        Me.btnNextVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNextVer.UseVisualStyleBackColor = True
        '
        'btnPrevVer
        '
        Me.btnPrevVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrevVer.FlatAppearance.BorderSize = 0
        Me.btnPrevVer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnPrevVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevVer.Image = CType(resources.GetObject("btnPrevVer.Image"), System.Drawing.Image)
        Me.btnPrevVer.Location = New System.Drawing.Point(745, 13)
        Me.btnPrevVer.Name = "btnPrevVer"
        Me.btnPrevVer.Size = New System.Drawing.Size(27, 27)
        Me.btnPrevVer.TabIndex = 6
        Me.btnPrevVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrevVer.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(378, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(68, 27)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(304, 13)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(68, 27)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(230, 13)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 27)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblEntryDate)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.chkBBK)
        Me.GroupBox2.Controls.Add(Me.chkChqRef)
        Me.GroupBox2.Controls.Add(Me.chkChqType)
        Me.GroupBox2.Controls.Add(Me.chkAccNo)
        Me.GroupBox2.Controls.Add(Me.btnSearchLocation)
        Me.GroupBox2.Controls.Add(Me.lblEntryLocation)
        Me.GroupBox2.Controls.Add(Me.txtClearingDate)
        Me.GroupBox2.Controls.Add(Me.txtEntryLocation)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(861, 62)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblEntryDate
        '
        Me.lblEntryDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntryDate.Location = New System.Drawing.Point(108, 9)
        Me.lblEntryDate.Name = "lblEntryDate"
        Me.lblEntryDate.Size = New System.Drawing.Size(98, 20)
        Me.lblEntryDate.TabIndex = 32
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 20)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Entry Date:"
        '
        'chkBBK
        '
        Me.chkBBK.AutoSize = True
        Me.chkBBK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBBK.Location = New System.Drawing.Point(631, 11)
        Me.chkBBK.Name = "chkBBK"
        Me.chkBBK.Size = New System.Drawing.Size(44, 17)
        Me.chkBBK.TabIndex = 30
        Me.chkBBK.Text = "BBK"
        Me.chkBBK.UseVisualStyleBackColor = True
        '
        'chkChqRef
        '
        Me.chkChqRef.AutoSize = True
        Me.chkChqRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkChqRef.Location = New System.Drawing.Point(563, 11)
        Me.chkChqRef.Name = "chkChqRef"
        Me.chkChqRef.Size = New System.Drawing.Size(62, 17)
        Me.chkChqRef.TabIndex = 29
        Me.chkChqRef.Text = "Chq Ref"
        Me.chkChqRef.UseVisualStyleBackColor = True
        '
        'chkChqType
        '
        Me.chkChqType.AutoSize = True
        Me.chkChqType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkChqType.Location = New System.Drawing.Point(481, 11)
        Me.chkChqType.Name = "chkChqType"
        Me.chkChqType.Size = New System.Drawing.Size(66, 17)
        Me.chkChqType.TabIndex = 27
        Me.chkChqType.Text = "ChqType"
        Me.chkChqType.UseVisualStyleBackColor = True
        '
        'chkAccNo
        '
        Me.chkAccNo.AutoSize = True
        Me.chkAccNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAccNo.Location = New System.Drawing.Point(415, 11)
        Me.chkAccNo.Name = "chkAccNo"
        Me.chkAccNo.Size = New System.Drawing.Size(56, 17)
        Me.chkAccNo.TabIndex = 28
        Me.chkAccNo.Text = "AccNo"
        Me.chkAccNo.UseVisualStyleBackColor = True
        '
        'btnSearchLocation
        '
        Me.btnSearchLocation.FlatAppearance.BorderSize = 0
        Me.btnSearchLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchLocation.Image = CType(resources.GetObject("btnSearchLocation.Image"), System.Drawing.Image)
        Me.btnSearchLocation.Location = New System.Drawing.Point(589, 32)
        Me.btnSearchLocation.Name = "btnSearchLocation"
        Me.btnSearchLocation.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchLocation.TabIndex = 12
        Me.btnSearchLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchLocation.UseVisualStyleBackColor = True
        '
        'lblEntryLocation
        '
        Me.lblEntryLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntryLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntryLocation.Location = New System.Drawing.Point(616, 32)
        Me.lblEntryLocation.Name = "lblEntryLocation"
        Me.lblEntryLocation.Size = New System.Drawing.Size(231, 20)
        Me.lblEntryLocation.TabIndex = 10
        '
        'txtClearingDate
        '
        Me.txtClearingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClearingDate.Location = New System.Drawing.Point(108, 32)
        Me.txtClearingDate.Mask = "00/00/0000"
        Me.txtClearingDate.Name = "txtClearingDate"
        Me.txtClearingDate.Size = New System.Drawing.Size(98, 20)
        Me.txtClearingDate.TabIndex = 0
        Me.txtClearingDate.ValidatingType = GetType(Date)
        '
        'txtEntryLocation
        '
        Me.txtEntryLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryLocation.Location = New System.Drawing.Point(415, 33)
        Me.txtEntryLocation.Name = "txtEntryLocation"
        Me.txtEntryLocation.Size = New System.Drawing.Size(168, 20)
        Me.txtEntryLocation.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(309, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Entry Location:"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(207, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "[dd/mm/yyyy]"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Clearing Date:"
        '
        'btnSearchCustomer
        '
        Me.btnSearchCustomer.FlatAppearance.BorderSize = 0
        Me.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCustomer.Image = CType(resources.GetObject("btnSearchCustomer.Image"), System.Drawing.Image)
        Me.btnSearchCustomer.Location = New System.Drawing.Point(284, 12)
        Me.btnSearchCustomer.Name = "btnSearchCustomer"
        Me.btnSearchCustomer.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchCustomer.TabIndex = 1
        Me.btnSearchCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchCustomer.UseVisualStyleBackColor = True
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(312, 13)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(271, 20)
        Me.lblAccName.TabIndex = 10
        '
        'txtCustomerAcc
        '
        Me.txtCustomerAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerAcc.Location = New System.Drawing.Point(108, 14)
        Me.txtCustomerAcc.Name = "txtCustomerAcc"
        Me.txtCustomerAcc.Size = New System.Drawing.Size(170, 20)
        Me.txtCustomerAcc.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "DS Code:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Customer A/C:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblPDCStatus)
        Me.GroupBox4.Controls.Add(Me.txtDepoCode)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtCustomerRef)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txtTotalCheckNo)
        Me.GroupBox4.Controls.Add(Me.txtCustomerAcc)
        Me.GroupBox4.Controls.Add(Me.btnSearchCustomer)
        Me.GroupBox4.Controls.Add(Me.txtTotalCheckAmount)
        Me.GroupBox4.Controls.Add(Me.lblAccName)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 110)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(861, 94)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'lblPDCStatus
        '
        Me.lblPDCStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPDCStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPDCStatus.Location = New System.Drawing.Point(666, 25)
        Me.lblPDCStatus.Name = "lblPDCStatus"
        Me.lblPDCStatus.Size = New System.Drawing.Size(168, 42)
        Me.lblPDCStatus.TabIndex = 13
        Me.lblPDCStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(108, 38)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(170, 20)
        Me.txtDepoCode.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "No. of Check:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(309, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Customer Ref:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(309, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 20)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Check Amount:"
        '
        'txtCustomerRef
        '
        Me.txtCustomerRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerRef.Location = New System.Drawing.Point(415, 38)
        Me.txtCustomerRef.Name = "txtCustomerRef"
        Me.txtCustomerRef.Size = New System.Drawing.Size(168, 20)
        Me.txtCustomerRef.TabIndex = 3
        '
        'txtTotalCheckNo
        '
        Me.txtTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCheckNo.Location = New System.Drawing.Point(108, 62)
        Me.txtTotalCheckNo.Name = "txtTotalCheckNo"
        Me.txtTotalCheckNo.Size = New System.Drawing.Size(170, 20)
        Me.txtTotalCheckNo.TabIndex = 4
        '
        'txtTotalCheckAmount
        '
        Me.txtTotalCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCheckAmount.Location = New System.Drawing.Point(415, 62)
        Me.txtTotalCheckAmount.Name = "txtTotalCheckAmount"
        Me.txtTotalCheckAmount.Size = New System.Drawing.Size(168, 20)
        Me.txtTotalCheckAmount.TabIndex = 5
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbValueType)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.lblRowNo)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtAmount)
        Me.GroupBox5.Controls.Add(Me.txtCheckTypeCode)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.btnSearchCheckType)
        Me.GroupBox5.Controls.Add(Me.txtIssueDate)
        Me.GroupBox5.Controls.Add(Me.lblCheckTypeName)
        Me.GroupBox5.Controls.Add(Me.txtCheckRef)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.txtAccNo)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.txtCheckNumber)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 313)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(861, 91)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        '
        'cmbValueType
        '
        Me.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValueType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbValueType.FormattingEnabled = True
        Me.cmbValueType.Location = New System.Drawing.Point(710, 64)
        Me.cmbValueType.Name = "cmbValueType"
        Me.cmbValueType.Size = New System.Drawing.Size(137, 21)
        Me.cmbValueType.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(614, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Value Type:"
        '
        'lblRowNo
        '
        Me.lblRowNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRowNo.Location = New System.Drawing.Point(691, 16)
        Me.lblRowNo.Name = "lblRowNo"
        Me.lblRowNo.Size = New System.Drawing.Size(121, 20)
        Me.lblRowNo.TabIndex = 22
        Me.lblRowNo.Visible = False
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(309, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 20)
        Me.Label31.TabIndex = 5
        Me.Label31.Text = "Check Reference:"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(309, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 20)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Amount:"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(309, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 20)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Check Type:"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Location = New System.Drawing.Point(415, 64)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(168, 20)
        Me.txtAmount.TabIndex = 6
        '
        'txtCheckTypeCode
        '
        Me.txtCheckTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckTypeCode.Location = New System.Drawing.Point(415, 40)
        Me.txtCheckTypeCode.Name = "txtCheckTypeCode"
        Me.txtCheckTypeCode.Size = New System.Drawing.Size(168, 20)
        Me.txtCheckTypeCode.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(6, 67)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(98, 20)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "A/C No:"
        '
        'btnSearchCheckType
        '
        Me.btnSearchCheckType.FlatAppearance.BorderSize = 0
        Me.btnSearchCheckType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchCheckType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCheckType.Image = CType(resources.GetObject("btnSearchCheckType.Image"), System.Drawing.Image)
        Me.btnSearchCheckType.Location = New System.Drawing.Point(589, 39)
        Me.btnSearchCheckType.Name = "btnSearchCheckType"
        Me.btnSearchCheckType.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchCheckType.TabIndex = 5
        Me.btnSearchCheckType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchCheckType.UseVisualStyleBackColor = True
        '
        'txtIssueDate
        '
        Me.txtIssueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssueDate.Location = New System.Drawing.Point(108, 17)
        Me.txtIssueDate.Mask = "00/00/0000"
        Me.txtIssueDate.Name = "txtIssueDate"
        Me.txtIssueDate.Size = New System.Drawing.Size(98, 20)
        Me.txtIssueDate.TabIndex = 0
        Me.txtIssueDate.ValidatingType = GetType(Date)
        '
        'lblCheckTypeName
        '
        Me.lblCheckTypeName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCheckTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckTypeName.Location = New System.Drawing.Point(616, 39)
        Me.lblCheckTypeName.Name = "lblCheckTypeName"
        Me.lblCheckTypeName.Size = New System.Drawing.Size(231, 20)
        Me.lblCheckTypeName.TabIndex = 10
        '
        'txtCheckRef
        '
        Me.txtCheckRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckRef.Location = New System.Drawing.Point(415, 16)
        Me.txtCheckRef.Name = "txtCheckRef"
        Me.txtCheckRef.Size = New System.Drawing.Size(168, 20)
        Me.txtCheckRef.TabIndex = 3
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(209, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(84, 20)
        Me.Label35.TabIndex = 5
        Me.Label35.Text = "[dd/mm/yyyy]"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 20)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Issue Date:"
        '
        'txtAccNo
        '
        Me.txtAccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccNo.Location = New System.Drawing.Point(108, 65)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(170, 20)
        Me.txtAccNo.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 43)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 20)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Check Number:"
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(108, 41)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(170, 20)
        Me.txtCheckNumber.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.txtBankCode)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.btnSearchBank)
        Me.GroupBox6.Controls.Add(Me.txtBranchCode)
        Me.GroupBox6.Controls.Add(Me.lblBankName)
        Me.GroupBox6.Controls.Add(Me.btnSearchBranch)
        Me.GroupBox6.Controls.Add(Me.lblBranchName)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 204)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(861, 67)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Drawee"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Bank:"
        '
        'txtBankCode
        '
        Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankCode.Location = New System.Drawing.Point(108, 14)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(170, 20)
        Me.txtBankCode.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 20)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Nik Branch:"
        '
        'btnSearchBank
        '
        Me.btnSearchBank.FlatAppearance.BorderSize = 0
        Me.btnSearchBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBank.Image = CType(resources.GetObject("btnSearchBank.Image"), System.Drawing.Image)
        Me.btnSearchBank.Location = New System.Drawing.Point(284, 12)
        Me.btnSearchBank.Name = "btnSearchBank"
        Me.btnSearchBank.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBank.TabIndex = 1
        Me.btnSearchBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBank.UseVisualStyleBackColor = True
        '
        'txtBranchCode
        '
        Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchCode.Location = New System.Drawing.Point(108, 37)
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.Size = New System.Drawing.Size(170, 20)
        Me.txtBranchCode.TabIndex = 2
        '
        'lblBankName
        '
        Me.lblBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankName.Location = New System.Drawing.Point(312, 13)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(271, 20)
        Me.lblBankName.TabIndex = 10
        '
        'btnSearchBranch
        '
        Me.btnSearchBranch.FlatAppearance.BorderSize = 0
        Me.btnSearchBranch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBranch.Image = CType(resources.GetObject("btnSearchBranch.Image"), System.Drawing.Image)
        Me.btnSearchBranch.Location = New System.Drawing.Point(284, 35)
        Me.btnSearchBranch.Name = "btnSearchBranch"
        Me.btnSearchBranch.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBranch.TabIndex = 3
        Me.btnSearchBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBranch.UseVisualStyleBackColor = True
        '
        'lblBranchName
        '
        Me.lblBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchName.Location = New System.Drawing.Point(312, 36)
        Me.lblBranchName.Name = "lblBranchName"
        Me.lblBranchName.Size = New System.Drawing.Size(271, 20)
        Me.lblBranchName.TabIndex = 10
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnRemoveFromGrid)
        Me.GroupBox8.Controls.Add(Me.btnCancel)
        Me.GroupBox8.Controls.Add(Me.btnAddToGrid)
        Me.GroupBox8.Controls.Add(Me.dgView)
        Me.GroupBox8.Location = New System.Drawing.Point(5, 404)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(861, 215)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        '
        'btnRemoveFromGrid
        '
        Me.btnRemoveFromGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRemoveFromGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFromGrid.Location = New System.Drawing.Point(796, 79)
        Me.btnRemoveFromGrid.Name = "btnRemoveFromGrid"
        Me.btnRemoveFromGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnRemoveFromGrid.TabIndex = 1
        Me.btnRemoveFromGrid.Text = "Remove"
        Me.btnRemoveFromGrid.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(796, 48)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(58, 27)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'btnAddToGrid
        '
        Me.btnAddToGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddToGrid.Location = New System.Drawing.Point(796, 15)
        Me.btnAddToGrid.Name = "btnAddToGrid"
        Me.btnAddToGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnAddToGrid.TabIndex = 0
        Me.btnAddToGrid.Text = "Add"
        Me.btnAddToGrid.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column17, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column2, Me.Column1, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column23, Me.Column3, Me.Column5, Me.Column15, Me.Column16, Me.Column4, Me.Column6, Me.Column18})
        Me.dgView.Location = New System.Drawing.Point(7, 15)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(781, 194)
        Me.dgView.TabIndex = 17
        '
        'Column17
        '
        Me.Column17.HeaderText = "DSL"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Bank Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 90
        '
        'Column8
        '
        Me.Column8.HeaderText = "Bank Name"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 90
        '
        'Column9
        '
        Me.Column9.HeaderText = "Branch Code"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "Branch Name"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Payee Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "A/C No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Check Series"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Book No"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Check No"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Batch No"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column23
        '
        Me.Column23.HeaderText = "Issue Date"
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
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
        'Column15
        '
        Me.Column15.HeaderText = "Check Tp Cd"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Visible = False
        '
        'Column16
        '
        Me.Column16.HeaderText = "Check Type"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Value Type"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.HeaderText = "Is Row Changed"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Visible = False
        '
        'grpBBK
        '
        Me.grpBBK.Controls.Add(Me.Label34)
        Me.grpBBK.Controls.Add(Me.txtBatchNo)
        Me.grpBBK.Controls.Add(Me.Label33)
        Me.grpBBK.Controls.Add(Me.txtCheckNo)
        Me.grpBBK.Controls.Add(Me.Label21)
        Me.grpBBK.Controls.Add(Me.txtBookNo)
        Me.grpBBK.Controls.Add(Me.Label22)
        Me.grpBBK.Controls.Add(Me.txtCheckSeries)
        Me.grpBBK.Location = New System.Drawing.Point(6, 271)
        Me.grpBBK.Name = "grpBBK"
        Me.grpBBK.Size = New System.Drawing.Size(861, 42)
        Me.grpBBK.TabIndex = 4
        Me.grpBBK.TabStop = False
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(645, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 20)
        Me.Label34.TabIndex = 5
        Me.Label34.Text = "Batch No:"
        '
        'txtBatchNo
        '
        Me.txtBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNo.Location = New System.Drawing.Point(736, 14)
        Me.txtBatchNo.Name = "txtBatchNo"
        Me.txtBatchNo.Size = New System.Drawing.Size(98, 20)
        Me.txtBatchNo.TabIndex = 3
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(423, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 20)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "Check No:"
        '
        'txtCheckNo
        '
        Me.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNo.Location = New System.Drawing.Point(524, 14)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(98, 20)
        Me.txtCheckNo.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(235, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 20)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Book No:"
        '
        'txtBookNo
        '
        Me.txtBookNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBookNo.Location = New System.Drawing.Point(309, 14)
        Me.txtBookNo.Name = "txtBookNo"
        Me.txtBookNo.Size = New System.Drawing.Size(98, 20)
        Me.txtBookNo.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 20)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Check Series:"
        '
        'txtCheckSeries
        '
        Me.txtCheckSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckSeries.Location = New System.Drawing.Point(108, 14)
        Me.txtCheckSeries.Name = "txtCheckSeries"
        Me.txtCheckSeries.Size = New System.Drawing.Size(98, 20)
        Me.txtCheckSeries.TabIndex = 0
        '
        'lblTotalCheckAmount
        '
        Me.lblTotalCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckAmount.Location = New System.Drawing.Point(669, 651)
        Me.lblTotalCheckAmount.Name = "lblTotalCheckAmount"
        Me.lblTotalCheckAmount.Size = New System.Drawing.Size(99, 19)
        Me.lblTotalCheckAmount.TabIndex = 30
        '
        'lblTotalCheckNo
        '
        Me.lblTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckNo.Location = New System.Drawing.Point(669, 630)
        Me.lblTotalCheckNo.Name = "lblTotalCheckNo"
        Me.lblTotalCheckNo.Size = New System.Drawing.Size(99, 19)
        Me.lblTotalCheckNo.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(569, 634)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Total Check No:"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(569, 653)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 20)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "Total Check Amount:"
        '
        'FrmPDCDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 703)
        Me.Controls.Add(Me.lblTotalCheckAmount)
        Me.Controls.Add(Me.lblTotalCheckNo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.grpBBK)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPDCDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDC Check Detail"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBBK.ResumeLayout(False)
        Me.grpBBK.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAuthorized As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpen As System.Windows.Forms.CheckBox
    Friend WithEvents lblAuthDate As System.Windows.Forms.Label
    Friend WithEvents lblInputDate As System.Windows.Forms.Label
    Friend WithEvents lblModNo As System.Windows.Forms.Label
    Friend WithEvents lblAuthBy As System.Windows.Forms.Label
    Friend WithEvents lblInputBy As System.Windows.Forms.Label
    Friend WithEvents btnAuthorize As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblVerTot As System.Windows.Forms.Label
    Friend WithEvents lblVerNo As System.Windows.Forms.Label
    Friend WithEvents btnUnlock As System.Windows.Forms.Button
    Friend WithEvents btnNextVer As System.Windows.Forms.Button
    Friend WithEvents btnPrevVer As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEntryLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtClearingDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCustomerAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblEntryLocation As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSearchCustomer As System.Windows.Forms.Button
    Friend WithEvents btnSearchLocation As System.Windows.Forms.Button
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCheckRef As System.Windows.Forms.TextBox
    Friend WithEvents txtAccNo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerRef As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSearchBranch As System.Windows.Forms.Button
    Friend WithEvents txtCheckTypeCode As System.Windows.Forms.TextBox
    Friend WithEvents lblBranchName As System.Windows.Forms.Label
    Friend WithEvents btnSearchCheckType As System.Windows.Forms.Button
    Friend WithEvents lblCheckTypeName As System.Windows.Forms.Label
    Friend WithEvents txtIssueDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchBank As System.Windows.Forms.Button
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveFromGrid As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAddToGrid As System.Windows.Forms.Button
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents lblRowNo As System.Windows.Forms.Label
    Friend WithEvents cmbValueType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblPDCStatus As System.Windows.Forms.Label
    Friend WithEvents grpBBK As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtBatchNo As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtBookNo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCheckSeries As System.Windows.Forms.TextBox
    Friend WithEvents chkBBK As System.Windows.Forms.CheckBox
    Friend WithEvents chkChqRef As System.Windows.Forms.CheckBox
    Friend WithEvents chkChqType As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccNo As System.Windows.Forms.CheckBox
    Friend WithEvents lblEntryDate As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotalCheckAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckNo As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
End Class
