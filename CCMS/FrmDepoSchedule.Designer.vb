<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDepoSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDepoSchedule))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.btnSearchBank = New System.Windows.Forms.Button
        Me.btnSearchLocation = New System.Windows.Forms.Button
        Me.lblCorrBranchName = New System.Windows.Forms.Label
        Me.lblCorrBankName = New System.Windows.Forms.Label
        Me.lblLocationName = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtScheduleDate = New System.Windows.Forms.MaskedTextBox
        Me.txtCorrBranchCode = New System.Windows.Forms.TextBox
        Me.txtCorrBankCode = New System.Windows.Forms.TextBox
        Me.txtLocationCode = New System.Windows.Forms.TextBox
        Me.txtDepoScheCode = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTotalCheckNo = New System.Windows.Forms.TextBox
        Me.txtTotalCheckAmount = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTotalCashAmount = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblRowNo = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.chkDepositType = New System.Windows.Forms.CheckBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.btnRemoveFromGrid = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.btnAddToGrid = New System.Windows.Forms.Button
        Me.txtCitiCashAmount = New System.Windows.Forms.TextBox
        Me.btnSearchClient = New System.Windows.Forms.Button
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.txtCitiCheckAmount = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.lblAccNo = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.lblAccName = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.lblTotalCheckNo = New System.Windows.Forms.Label
        Me.lblTotalCheckAmount = New System.Windows.Forms.Label
        Me.lblTotalCashAmount = New System.Windows.Forms.Label
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 652)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(973, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(958, 17)
        Me.lblToolStatus.Spring = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(906, 608)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 12
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
        Me.GroupBox3.Location = New System.Drawing.Point(5, 590)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 58)
        Me.GroupBox3.TabIndex = 14
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
        Me.GroupBox1.Size = New System.Drawing.Size(973, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(899, 20)
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
        Me.Label6.Location = New System.Drawing.Point(781, 20)
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
        Me.lblVerTot.Location = New System.Drawing.Point(918, 18)
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
        Me.lblVerNo.Location = New System.Drawing.Point(875, 18)
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
        Me.btnNextVer.Location = New System.Drawing.Point(942, 12)
        Me.btnNextVer.Name = "btnNextVer"
        Me.btnNextVer.Size = New System.Drawing.Size(26, 28)
        Me.btnNextVer.TabIndex = 3
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
        Me.btnPrevVer.Location = New System.Drawing.Point(845, 13)
        Me.btnPrevVer.Name = "btnPrevVer"
        Me.btnPrevVer.Size = New System.Drawing.Size(27, 27)
        Me.btnPrevVer.TabIndex = 3
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
        Me.GroupBox2.Controls.Add(Me.btnSearchBank)
        Me.GroupBox2.Controls.Add(Me.btnSearchLocation)
        Me.GroupBox2.Controls.Add(Me.lblCorrBranchName)
        Me.GroupBox2.Controls.Add(Me.lblCorrBankName)
        Me.GroupBox2.Controls.Add(Me.lblLocationName)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtScheduleDate)
        Me.GroupBox2.Controls.Add(Me.txtCorrBranchCode)
        Me.GroupBox2.Controls.Add(Me.txtCorrBankCode)
        Me.GroupBox2.Controls.Add(Me.txtLocationCode)
        Me.GroupBox2.Controls.Add(Me.txtDepoScheCode)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(587, 137)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblEntryDate
        '
        Me.lblEntryDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntryDate.Location = New System.Drawing.Point(372, 14)
        Me.lblEntryDate.Name = "lblEntryDate"
        Me.lblEntryDate.Size = New System.Drawing.Size(204, 20)
        Me.lblEntryDate.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(261, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 20)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Entry Date:"
        '
        'btnSearchBank
        '
        Me.btnSearchBank.FlatAppearance.BorderSize = 0
        Me.btnSearchBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBank.Image = CType(resources.GetObject("btnSearchBank.Image"), System.Drawing.Image)
        Me.btnSearchBank.Location = New System.Drawing.Point(227, 82)
        Me.btnSearchBank.Name = "btnSearchBank"
        Me.btnSearchBank.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBank.TabIndex = 4
        Me.btnSearchBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBank.UseVisualStyleBackColor = True
        '
        'btnSearchLocation
        '
        Me.btnSearchLocation.FlatAppearance.BorderSize = 0
        Me.btnSearchLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchLocation.Image = CType(resources.GetObject("btnSearchLocation.Image"), System.Drawing.Image)
        Me.btnSearchLocation.Location = New System.Drawing.Point(227, 59)
        Me.btnSearchLocation.Name = "btnSearchLocation"
        Me.btnSearchLocation.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchLocation.TabIndex = 3
        Me.btnSearchLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchLocation.UseVisualStyleBackColor = True
        '
        'lblCorrBranchName
        '
        Me.lblCorrBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBranchName.Location = New System.Drawing.Point(372, 106)
        Me.lblCorrBranchName.Name = "lblCorrBranchName"
        Me.lblCorrBranchName.Size = New System.Drawing.Size(204, 20)
        Me.lblCorrBranchName.TabIndex = 10
        '
        'lblCorrBankName
        '
        Me.lblCorrBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBankName.Location = New System.Drawing.Point(372, 84)
        Me.lblCorrBankName.Name = "lblCorrBankName"
        Me.lblCorrBankName.Size = New System.Drawing.Size(204, 20)
        Me.lblCorrBankName.TabIndex = 10
        '
        'lblLocationName
        '
        Me.lblLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationName.Location = New System.Drawing.Point(372, 61)
        Me.lblLocationName.Name = "lblLocationName"
        Me.lblLocationName.Size = New System.Drawing.Size(204, 20)
        Me.lblLocationName.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(261, 108)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(105, 20)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Corr. Branch Name:"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(261, 86)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 20)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Corr. Bank Name:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(261, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 20)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Location Name:"
        '
        'txtScheduleDate
        '
        Me.txtScheduleDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDate.Location = New System.Drawing.Point(123, 37)
        Me.txtScheduleDate.Mask = "00/00/0000"
        Me.txtScheduleDate.Name = "txtScheduleDate"
        Me.txtScheduleDate.Size = New System.Drawing.Size(98, 20)
        Me.txtScheduleDate.TabIndex = 1
        '
        'txtCorrBranchCode
        '
        Me.txtCorrBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCorrBranchCode.Enabled = False
        Me.txtCorrBranchCode.Location = New System.Drawing.Point(123, 106)
        Me.txtCorrBranchCode.Name = "txtCorrBranchCode"
        Me.txtCorrBranchCode.ReadOnly = True
        Me.txtCorrBranchCode.Size = New System.Drawing.Size(98, 20)
        Me.txtCorrBranchCode.TabIndex = 6
        '
        'txtCorrBankCode
        '
        Me.txtCorrBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCorrBankCode.Enabled = False
        Me.txtCorrBankCode.Location = New System.Drawing.Point(123, 83)
        Me.txtCorrBankCode.Name = "txtCorrBankCode"
        Me.txtCorrBankCode.ReadOnly = True
        Me.txtCorrBankCode.Size = New System.Drawing.Size(98, 20)
        Me.txtCorrBankCode.TabIndex = 6
        '
        'txtLocationCode
        '
        Me.txtLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocationCode.Location = New System.Drawing.Point(123, 60)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.Size = New System.Drawing.Size(98, 20)
        Me.txtLocationCode.TabIndex = 2
        '
        'txtDepoScheCode
        '
        Me.txtDepoScheCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoScheCode.Location = New System.Drawing.Point(123, 14)
        Me.txtDepoScheCode.Name = "txtDepoScheCode"
        Me.txtDepoScheCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoScheCode.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Corr. Branch Code:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Corr. Bank Code:"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Location Code:"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(228, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "[ dd/mm/yyyy ]"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Schedule Date:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "DS Code:"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Total Check No:"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 20)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Total Check Amount:"
        '
        'txtTotalCheckNo
        '
        Me.txtTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCheckNo.Location = New System.Drawing.Point(126, 38)
        Me.txtTotalCheckNo.Name = "txtTotalCheckNo"
        Me.txtTotalCheckNo.Size = New System.Drawing.Size(117, 20)
        Me.txtTotalCheckNo.TabIndex = 0
        '
        'txtTotalCheckAmount
        '
        Me.txtTotalCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCheckAmount.Location = New System.Drawing.Point(126, 60)
        Me.txtTotalCheckAmount.Name = "txtTotalCheckAmount"
        Me.txtTotalCheckAmount.Size = New System.Drawing.Size(117, 20)
        Me.txtTotalCheckAmount.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.txtTotalCashAmount)
        Me.GroupBox4.Controls.Add(Me.txtTotalCheckNo)
        Me.GroupBox4.Controls.Add(Me.txtTotalCheckAmount)
        Me.GroupBox4.Location = New System.Drawing.Point(599, 48)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(369, 138)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Total Cash Amount:"
        '
        'txtTotalCashAmount
        '
        Me.txtTotalCashAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCashAmount.Location = New System.Drawing.Point(126, 82)
        Me.txtTotalCashAmount.Name = "txtTotalCashAmount"
        Me.txtTotalCashAmount.Size = New System.Drawing.Size(117, 20)
        Me.txtTotalCashAmount.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRowNo)
        Me.GroupBox5.Controls.Add(Me.btnCancel)
        Me.GroupBox5.Controls.Add(Me.chkDepositType)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.btnRemoveFromGrid)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.btnAddToGrid)
        Me.GroupBox5.Controls.Add(Me.txtCitiCashAmount)
        Me.GroupBox5.Controls.Add(Me.btnSearchClient)
        Me.GroupBox5.Controls.Add(Me.txtCheckNo)
        Me.GroupBox5.Controls.Add(Me.dgView)
        Me.GroupBox5.Controls.Add(Me.txtCitiCheckAmount)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.txtClientCode)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.txtDepoCode)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.lblAccNo)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.lblAccName)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 187)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(963, 402)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'lblRowNo
        '
        Me.lblRowNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRowNo.Location = New System.Drawing.Point(668, 85)
        Me.lblRowNo.Name = "lblRowNo"
        Me.lblRowNo.Size = New System.Drawing.Size(121, 23)
        Me.lblRowNo.TabIndex = 20
        Me.lblRowNo.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(897, 150)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(58, 27)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkDepositType
        '
        Me.chkDepositType.AutoSize = True
        Me.chkDepositType.Checked = True
        Me.chkDepositType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDepositType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDepositType.Location = New System.Drawing.Point(458, 19)
        Me.chkDepositType.Name = "chkDepositType"
        Me.chkDepositType.Size = New System.Drawing.Size(86, 17)
        Me.chkDepositType.TabIndex = 3
        Me.chkDepositType.Text = "Deposit Type"
        Me.chkDepositType.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(341, 46)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 20)
        Me.Label31.TabIndex = 5
        Me.Label31.Text = "No. of Check:"
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(341, 90)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 20)
        Me.Label30.TabIndex = 5
        Me.Label30.Text = "Citi Cash Amount:"
        '
        'btnRemoveFromGrid
        '
        Me.btnRemoveFromGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRemoveFromGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFromGrid.Location = New System.Drawing.Point(897, 183)
        Me.btnRemoveFromGrid.Name = "btnRemoveFromGrid"
        Me.btnRemoveFromGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnRemoveFromGrid.TabIndex = 18
        Me.btnRemoveFromGrid.Text = "Remove"
        Me.btnRemoveFromGrid.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(341, 68)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(107, 20)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Citi Check Amount:"
        '
        'btnAddToGrid
        '
        Me.btnAddToGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddToGrid.Location = New System.Drawing.Point(897, 117)
        Me.btnAddToGrid.Name = "btnAddToGrid"
        Me.btnAddToGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnAddToGrid.TabIndex = 7
        Me.btnAddToGrid.Text = "Add"
        Me.btnAddToGrid.UseVisualStyleBackColor = True
        '
        'txtCitiCashAmount
        '
        Me.txtCitiCashAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiCashAmount.Location = New System.Drawing.Point(458, 88)
        Me.txtCitiCashAmount.Name = "txtCitiCashAmount"
        Me.txtCitiCashAmount.Size = New System.Drawing.Size(117, 20)
        Me.txtCitiCashAmount.TabIndex = 6
        '
        'btnSearchClient
        '
        Me.btnSearchClient.FlatAppearance.BorderSize = 0
        Me.btnSearchClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchClient.Image = CType(resources.GetObject("btnSearchClient.Image"), System.Drawing.Image)
        Me.btnSearchClient.Location = New System.Drawing.Point(228, 42)
        Me.btnSearchClient.Name = "btnSearchClient"
        Me.btnSearchClient.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchClient.TabIndex = 2
        Me.btnSearchClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchClient.UseVisualStyleBackColor = True
        '
        'txtCheckNo
        '
        Me.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNo.Location = New System.Drawing.Point(458, 42)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(117, 20)
        Me.txtCheckNo.TabIndex = 4
        '
        'dgView
        '
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1, Me.Column7, Me.Column8, Me.Column4, Me.Column5, Me.Column6, Me.Column3, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16})
        Me.dgView.Location = New System.Drawing.Point(11, 117)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(881, 274)
        Me.dgView.TabIndex = 13
        '
        'txtCitiCheckAmount
        '
        Me.txtCitiCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiCheckAmount.Location = New System.Drawing.Point(458, 65)
        Me.txtCitiCheckAmount.Name = "txtCitiCheckAmount"
        Me.txtCitiCheckAmount.Size = New System.Drawing.Size(117, 20)
        Me.txtCitiCheckAmount.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 20)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Client Code:"
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(123, 42)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(98, 20)
        Me.txtClientCode.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 20)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Deposit Code:"
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(123, 19)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoCode.TabIndex = 0
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 91)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(98, 20)
        Me.Label28.TabIndex = 9
        Me.Label28.Text = "A/C No:"
        '
        'lblAccNo
        '
        Me.lblAccNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccNo.Location = New System.Drawing.Point(123, 88)
        Me.lblAccNo.Name = "lblAccNo"
        Me.lblAccNo.Size = New System.Drawing.Size(204, 20)
        Me.lblAccNo.TabIndex = 10
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 20)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "A/C Name:"
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(123, 65)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(204, 20)
        Me.lblAccName.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(566, 595)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Total Check No:"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(566, 633)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 20)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Total Cash Amount:"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(566, 614)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 20)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Total Check Amount:"
        '
        'lblTotalCheckNo
        '
        Me.lblTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckNo.Location = New System.Drawing.Point(666, 591)
        Me.lblTotalCheckNo.Name = "lblTotalCheckNo"
        Me.lblTotalCheckNo.Size = New System.Drawing.Size(99, 19)
        Me.lblTotalCheckNo.TabIndex = 21
        '
        'lblTotalCheckAmount
        '
        Me.lblTotalCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckAmount.Location = New System.Drawing.Point(666, 612)
        Me.lblTotalCheckAmount.Name = "lblTotalCheckAmount"
        Me.lblTotalCheckAmount.Size = New System.Drawing.Size(99, 19)
        Me.lblTotalCheckAmount.TabIndex = 21
        '
        'lblTotalCashAmount
        '
        Me.lblTotalCashAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCashAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCashAmount.Location = New System.Drawing.Point(666, 632)
        Me.lblTotalCashAmount.Name = "lblTotalCashAmount"
        Me.lblTotalCashAmount.Size = New System.Drawing.Size(99, 19)
        Me.lblTotalCashAmount.TabIndex = 21
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "D_CODE"
        Me.Column2.HeaderText = "Deposit Code"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "CLIENT_CODE"
        Me.Column1.HeaderText = "Client Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "A/C Name"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Acc No"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "NO_CHECK"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "No. of Check"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "CITICHECK_AMOUNT"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Citi Check Amount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "CITICASH_AMOUNT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "Citi Cash Amount"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 120
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "DEPOSIT_TYPE"
        Me.Column3.HeaderText = "Deposit Type"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Filename"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Ref no"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "File User Id"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        '
        'Column12
        '
        Me.Column12.HeaderText = "Seq No"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Check"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = "Flex Gen Date"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "SLNO"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "Is Row Chg"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'FrmDepoSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 674)
        Me.Controls.Add(Me.lblTotalCashAmount)
        Me.Controls.Add(Me.lblTotalCheckAmount)
        Me.Controls.Add(Me.lblTotalCheckNo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDepoSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit Schedule Information"
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
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtDepoScheCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtScheduleDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCorrBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblLocationName As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCorrBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSearchLocation As System.Windows.Forms.Button
    Friend WithEvents lblCorrBranchName As System.Windows.Forms.Label
    Friend WithEvents lblCorrBankName As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveFromGrid As System.Windows.Forms.Button
    Friend WithEvents btnAddToGrid As System.Windows.Forms.Button
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblAccNo As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCitiCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCitiCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents chkDepositType As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearchBank As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblRowNo As System.Windows.Forms.Label
    Friend WithEvents lblEntryDate As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckNo As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalCashAmount As System.Windows.Forms.Label
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
