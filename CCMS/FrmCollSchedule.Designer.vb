<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCollSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCollSchedule))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.lblCorrBankCode = New System.Windows.Forms.Label
        Me.btnSearchLoc = New System.Windows.Forms.Button
        Me.btnSearchBankBranch = New System.Windows.Forms.Button
        Me.btnSearchCS = New System.Windows.Forms.Button
        Me.lblCorrBranchCode = New System.Windows.Forms.Label
        Me.lblCorrBranchName = New System.Windows.Forms.Label
        Me.lblCorrBankName = New System.Windows.Forms.Label
        Me.lblLocationName = New System.Windows.Forms.Label
        Me.txtScheduleDate = New System.Windows.Forms.MaskedTextBox
        Me.txtTotalCollected = New System.Windows.Forms.TextBox
        Me.txtLocationCode = New System.Windows.Forms.TextBox
        Me.txtCSCode = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTotalCheckNo = New System.Windows.Forms.TextBox
        Me.txtCheckAmount = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRowNo = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAddToGrid = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDSCode = New System.Windows.Forms.TextBox
        Me.lblDLocationName = New System.Windows.Forms.Label
        Me.txtCashAmount = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btnRemoveFromGrid = New System.Windows.Forms.Button
        Me.dgViewAll = New System.Windows.Forms.DataGridView
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.dgViewReturn = New System.Windows.Forms.DataGridView
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtReturnCode = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtReturnAmount = New System.Windows.Forms.TextBox
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgViewAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgViewReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 605)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(951, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(936, 17)
        Me.lblToolStatus.Spring = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(787, 560)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 5
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
        Me.GroupBox3.Location = New System.Drawing.Point(5, 542)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 58)
        Me.GroupBox3.TabIndex = 4
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
        Me.GroupBox1.Size = New System.Drawing.Size(951, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(877, 20)
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
        Me.Label6.Location = New System.Drawing.Point(759, 20)
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
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "&New"
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
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblVerTot
        '
        Me.lblVerTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVerTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerTot.ForeColor = System.Drawing.Color.Maroon
        Me.lblVerTot.Location = New System.Drawing.Point(896, 18)
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
        Me.lblVerNo.Location = New System.Drawing.Point(853, 18)
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
        Me.btnUnlock.TabIndex = 3
        Me.btnUnlock.Text = "&Unlock"
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
        Me.btnNextVer.Location = New System.Drawing.Point(920, 12)
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
        Me.btnPrevVer.Location = New System.Drawing.Point(823, 13)
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
        Me.btnDelete.TabIndex = 3
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
        Me.btnRefresh.TabIndex = 3
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
        Me.GroupBox2.Controls.Add(Me.lblCorrBankCode)
        Me.GroupBox2.Controls.Add(Me.btnSearchLoc)
        Me.GroupBox2.Controls.Add(Me.btnSearchBankBranch)
        Me.GroupBox2.Controls.Add(Me.btnSearchCS)
        Me.GroupBox2.Controls.Add(Me.lblCorrBranchCode)
        Me.GroupBox2.Controls.Add(Me.lblCorrBranchName)
        Me.GroupBox2.Controls.Add(Me.lblCorrBankName)
        Me.GroupBox2.Controls.Add(Me.lblLocationName)
        Me.GroupBox2.Controls.Add(Me.txtScheduleDate)
        Me.GroupBox2.Controls.Add(Me.txtTotalCollected)
        Me.GroupBox2.Controls.Add(Me.txtLocationCode)
        Me.GroupBox2.Controls.Add(Me.txtCSCode)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(491, 161)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblCorrBankCode
        '
        Me.lblCorrBankCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBankCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBankCode.Location = New System.Drawing.Point(123, 82)
        Me.lblCorrBankCode.Name = "lblCorrBankCode"
        Me.lblCorrBankCode.Size = New System.Drawing.Size(98, 20)
        Me.lblCorrBankCode.TabIndex = 13
        '
        'btnSearchLoc
        '
        Me.btnSearchLoc.FlatAppearance.BorderSize = 0
        Me.btnSearchLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchLoc.Image = CType(resources.GetObject("btnSearchLoc.Image"), System.Drawing.Image)
        Me.btnSearchLoc.Location = New System.Drawing.Point(227, 59)
        Me.btnSearchLoc.Name = "btnSearchLoc"
        Me.btnSearchLoc.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchLoc.TabIndex = 4
        Me.btnSearchLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchLoc.UseVisualStyleBackColor = True
        '
        'btnSearchBankBranch
        '
        Me.btnSearchBankBranch.FlatAppearance.BorderSize = 0
        Me.btnSearchBankBranch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBankBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBankBranch.Image = CType(resources.GetObject("btnSearchBankBranch.Image"), System.Drawing.Image)
        Me.btnSearchBankBranch.Location = New System.Drawing.Point(227, 82)
        Me.btnSearchBankBranch.Name = "btnSearchBankBranch"
        Me.btnSearchBankBranch.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBankBranch.TabIndex = 5
        Me.btnSearchBankBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBankBranch.UseVisualStyleBackColor = True
        '
        'btnSearchCS
        '
        Me.btnSearchCS.FlatAppearance.BorderSize = 0
        Me.btnSearchCS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCS.Image = CType(resources.GetObject("btnSearchCS.Image"), System.Drawing.Image)
        Me.btnSearchCS.Location = New System.Drawing.Point(227, 14)
        Me.btnSearchCS.Name = "btnSearchCS"
        Me.btnSearchCS.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchCS.TabIndex = 1
        Me.btnSearchCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchCS.UseVisualStyleBackColor = True
        '
        'lblCorrBranchCode
        '
        Me.lblCorrBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBranchCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBranchCode.Location = New System.Drawing.Point(123, 106)
        Me.lblCorrBranchCode.Name = "lblCorrBranchCode"
        Me.lblCorrBranchCode.Size = New System.Drawing.Size(98, 20)
        Me.lblCorrBranchCode.TabIndex = 10
        '
        'lblCorrBranchName
        '
        Me.lblCorrBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBranchName.Location = New System.Drawing.Point(252, 106)
        Me.lblCorrBranchName.Name = "lblCorrBranchName"
        Me.lblCorrBranchName.Size = New System.Drawing.Size(204, 20)
        Me.lblCorrBranchName.TabIndex = 10
        '
        'lblCorrBankName
        '
        Me.lblCorrBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBankName.Location = New System.Drawing.Point(252, 84)
        Me.lblCorrBankName.Name = "lblCorrBankName"
        Me.lblCorrBankName.Size = New System.Drawing.Size(204, 20)
        Me.lblCorrBankName.TabIndex = 10
        '
        'lblLocationName
        '
        Me.lblLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationName.Location = New System.Drawing.Point(252, 61)
        Me.lblLocationName.Name = "lblLocationName"
        Me.lblLocationName.Size = New System.Drawing.Size(204, 20)
        Me.lblLocationName.TabIndex = 10
        '
        'txtScheduleDate
        '
        Me.txtScheduleDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDate.Location = New System.Drawing.Point(123, 37)
        Me.txtScheduleDate.Mask = "00/00/0000"
        Me.txtScheduleDate.Name = "txtScheduleDate"
        Me.txtScheduleDate.Size = New System.Drawing.Size(98, 20)
        Me.txtScheduleDate.TabIndex = 2
        Me.txtScheduleDate.ValidatingType = GetType(Date)
        '
        'txtTotalCollected
        '
        Me.txtTotalCollected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCollected.Location = New System.Drawing.Point(123, 129)
        Me.txtTotalCollected.Name = "txtTotalCollected"
        Me.txtTotalCollected.Size = New System.Drawing.Size(98, 20)
        Me.txtTotalCollected.TabIndex = 6
        '
        'txtLocationCode
        '
        Me.txtLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocationCode.Location = New System.Drawing.Point(123, 60)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.Size = New System.Drawing.Size(98, 20)
        Me.txtLocationCode.TabIndex = 3
        '
        'txtCSCode
        '
        Me.txtCSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCSCode.Location = New System.Drawing.Point(123, 14)
        Me.txtCSCode.Name = "txtCSCode"
        Me.txtCSCode.Size = New System.Drawing.Size(98, 20)
        Me.txtCSCode.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(7, 131)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 20)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Total Collected:"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Corr. Branch Code:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Corr. Bank Code:"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Location Code:"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(226, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 20)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "[dd/mm/yyyy]"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Schedule Date:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "CS Code:"
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(203, 36)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(19, 21)
        Me.Button3.TabIndex = 12
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 20)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "No. of Check:"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 108)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 20)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Check Amount:"
        '
        'txtTotalCheckNo
        '
        Me.txtTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCheckNo.Location = New System.Drawing.Point(93, 84)
        Me.txtTotalCheckNo.Name = "txtTotalCheckNo"
        Me.txtTotalCheckNo.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalCheckNo.TabIndex = 2
        '
        'txtCheckAmount
        '
        Me.txtCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckAmount.Location = New System.Drawing.Point(93, 107)
        Me.txtCheckAmount.Name = "txtCheckAmount"
        Me.txtCheckAmount.Size = New System.Drawing.Size(106, 20)
        Me.txtCheckAmount.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRowNo)
        Me.GroupBox4.Controls.Add(Me.btnCancel)
        Me.GroupBox4.Controls.Add(Me.btnAddToGrid)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.txtDSCode)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.lblDLocationName)
        Me.GroupBox4.Controls.Add(Me.txtCashAmount)
        Me.GroupBox4.Controls.Add(Me.txtTotalCheckNo)
        Me.GroupBox4.Controls.Add(Me.txtCheckAmount)
        Me.GroupBox4.Location = New System.Drawing.Point(502, 48)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(443, 162)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'lblRowNo
        '
        Me.lblRowNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRowNo.Location = New System.Drawing.Point(228, 63)
        Me.lblRowNo.Name = "lblRowNo"
        Me.lblRowNo.Size = New System.Drawing.Size(121, 23)
        Me.lblRowNo.TabIndex = 22
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(218, 129)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(58, 27)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddToGrid
        '
        Me.btnAddToGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddToGrid.Location = New System.Drawing.Point(141, 130)
        Me.btnAddToGrid.Name = "btnAddToGrid"
        Me.btnAddToGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnAddToGrid.TabIndex = 4
        Me.btnAddToGrid.Text = "Add"
        Me.btnAddToGrid.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 40)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 20)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "DS Code:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Cash Amount:"
        '
        'txtDSCode
        '
        Me.txtDSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDSCode.Location = New System.Drawing.Point(93, 38)
        Me.txtDSCode.Name = "txtDSCode"
        Me.txtDSCode.Size = New System.Drawing.Size(106, 20)
        Me.txtDSCode.TabIndex = 0
        '
        'lblDLocationName
        '
        Me.lblDLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDLocationName.Location = New System.Drawing.Point(228, 37)
        Me.lblDLocationName.Name = "lblDLocationName"
        Me.lblDLocationName.Size = New System.Drawing.Size(152, 20)
        Me.lblDLocationName.TabIndex = 10
        '
        'txtCashAmount
        '
        Me.txtCashAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCashAmount.Location = New System.Drawing.Point(93, 61)
        Me.txtCashAmount.Name = "txtCashAmount"
        Me.txtCashAmount.Size = New System.Drawing.Size(106, 20)
        Me.txtCashAmount.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnRemoveFromGrid)
        Me.GroupBox5.Controls.Add(Me.dgViewAll)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 211)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(491, 330)
        Me.GroupBox5.TabIndex = 17
        Me.GroupBox5.TabStop = False
        '
        'btnRemoveFromGrid
        '
        Me.btnRemoveFromGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRemoveFromGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFromGrid.Location = New System.Drawing.Point(427, 96)
        Me.btnRemoveFromGrid.Name = "btnRemoveFromGrid"
        Me.btnRemoveFromGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnRemoveFromGrid.TabIndex = 19
        Me.btnRemoveFromGrid.Text = "Remove"
        Me.btnRemoveFromGrid.UseVisualStyleBackColor = True
        '
        'dgViewAll
        '
        Me.dgViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column4, Me.Column5, Me.Column6})
        Me.dgViewAll.Location = New System.Drawing.Point(8, 16)
        Me.dgViewAll.MultiSelect = False
        Me.dgViewAll.Name = "dgViewAll"
        Me.dgViewAll.ReadOnly = True
        Me.dgViewAll.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgViewAll.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgViewAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewAll.Size = New System.Drawing.Size(413, 308)
        Me.dgViewAll.TabIndex = 13
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "DEPT_ID"
        Me.Column2.HeaderText = "DS Code"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 75
        '
        'Column4
        '
        Me.Column4.HeaderText = "No. of Check"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 95
        '
        'Column5
        '
        Me.Column5.HeaderText = "CitiCheck Amount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column6
        '
        Me.Column6.HeaderText = "CitiCash Amount"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 110
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgViewReturn)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.txtReturnCode)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.txtReturnAmount)
        Me.GroupBox6.Location = New System.Drawing.Point(502, 211)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(443, 330)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Return Detail"
        '
        'dgViewReturn
        '
        Me.dgViewReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewReturn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column1})
        Me.dgViewReturn.Location = New System.Drawing.Point(8, 44)
        Me.dgViewReturn.MultiSelect = False
        Me.dgViewReturn.Name = "dgViewReturn"
        Me.dgViewReturn.ReadOnly = True
        Me.dgViewReturn.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgViewReturn.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgViewReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewReturn.Size = New System.Drawing.Size(424, 280)
        Me.dgViewReturn.TabIndex = 13
        '
        'Column3
        '
        Me.Column3.HeaderText = "CSD or CCheck"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DEPT_ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "D Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Slno"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Check No"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Drawee Bank"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Status"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(205, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 20)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Return Code:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label21.Visible = False
        '
        'txtReturnCode
        '
        Me.txtReturnCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnCode.Enabled = False
        Me.txtReturnCode.Location = New System.Drawing.Point(282, 18)
        Me.txtReturnCode.Name = "txtReturnCode"
        Me.txtReturnCode.Size = New System.Drawing.Size(98, 20)
        Me.txtReturnCode.TabIndex = 6
        Me.txtReturnCode.Visible = False
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 20)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Return Amount:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtReturnAmount
        '
        Me.txtReturnAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnAmount.Location = New System.Drawing.Point(93, 18)
        Me.txtReturnAmount.Name = "txtReturnAmount"
        Me.txtReturnAmount.Size = New System.Drawing.Size(106, 20)
        Me.txtReturnAmount.TabIndex = 6
        '
        'FrmCollSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 627)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCollSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection Schedule Information"
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
        CType(Me.dgViewAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.dgViewReturn, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtCSCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtScheduleDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblLocationName As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSearchBankBranch As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnSearchCS As System.Windows.Forms.Button
    Friend WithEvents lblCorrBranchName As System.Windows.Forms.Label
    Friend WithEvents lblCorrBankName As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dgViewAll As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalCollected As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtDSCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDLocationName As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgViewReturn As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtReturnCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtReturnAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchLoc As System.Windows.Forms.Button
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddToGrid As System.Windows.Forms.Button
    Friend WithEvents btnRemoveFromGrid As System.Windows.Forms.Button
    Friend WithEvents lblCorrBranchCode As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblRowNo As System.Windows.Forms.Label
    Friend WithEvents lblCorrBankCode As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
