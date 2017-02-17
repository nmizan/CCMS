<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCitiCheckDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCitiCheckDetail))
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
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCustomerRef = New System.Windows.Forms.TextBox
        Me.lblCheckCountStatus = New System.Windows.Forms.Label
        Me.txtTotalCheckNo = New System.Windows.Forms.TextBox
        Me.txtValueDate = New System.Windows.Forms.MaskedTextBox
        Me.txtSlipDate = New System.Windows.Forms.MaskedTextBox
        Me.lblDepoLocationName = New System.Windows.Forms.Label
        Me.lblAccName = New System.Windows.Forms.Label
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.lblAccNo = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDepoLocationCode = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblClearingZone = New System.Windows.Forms.Label
        Me.txtDraweeLocationCode = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblRowNo = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cmbCheckType = New System.Windows.Forms.ComboBox
        Me.btnRemoveFromGrid = New System.Windows.Forms.Button
        Me.btnAddToGrid = New System.Windows.Forms.Button
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblClearingZoneCode = New System.Windows.Forms.Label
        Me.txtCheckDate = New System.Windows.Forms.MaskedTextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtCheckRef = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDrawerAccNo = New System.Windows.Forms.TextBox
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.lblDraweeLocationName = New System.Windows.Forms.Label
        Me.lblDraweeBranchName = New System.Windows.Forms.Label
        Me.lblDraweeBankName = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtDraweeBranchCode = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtDraweeBankCode = New System.Windows.Forms.TextBox
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 658)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(871, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(856, 17)
        Me.lblToolStatus.Spring = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(800, 611)
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
        Me.GroupBox3.Location = New System.Drawing.Point(5, 593)
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
        Me.GroupBox1.Size = New System.Drawing.Size(871, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(797, 20)
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
        Me.Label6.Location = New System.Drawing.Point(679, 20)
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
        Me.lblVerTot.Location = New System.Drawing.Point(816, 18)
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
        Me.lblVerNo.Location = New System.Drawing.Point(773, 18)
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
        Me.btnNextVer.Location = New System.Drawing.Point(840, 12)
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
        Me.btnPrevVer.Location = New System.Drawing.Point(743, 13)
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
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtCustomerRef)
        Me.GroupBox2.Controls.Add(Me.lblCheckCountStatus)
        Me.GroupBox2.Controls.Add(Me.txtTotalCheckNo)
        Me.GroupBox2.Controls.Add(Me.txtValueDate)
        Me.GroupBox2.Controls.Add(Me.txtSlipDate)
        Me.GroupBox2.Controls.Add(Me.lblDepoLocationName)
        Me.GroupBox2.Controls.Add(Me.lblAccName)
        Me.GroupBox2.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox2.Controls.Add(Me.lblAccNo)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtDepoCode)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtDepoLocationCode)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtClientCode)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(861, 137)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(431, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Customer Ref:"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(431, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Total Check No:"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(431, 86)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 20)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Total Amount:"
        '
        'txtCustomerRef
        '
        Me.txtCustomerRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerRef.Location = New System.Drawing.Point(551, 37)
        Me.txtCustomerRef.Name = "txtCustomerRef"
        Me.txtCustomerRef.Size = New System.Drawing.Size(117, 20)
        Me.txtCustomerRef.TabIndex = 8
        '
        'lblCheckCountStatus
        '
        Me.lblCheckCountStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCheckCountStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckCountStatus.Location = New System.Drawing.Point(551, 106)
        Me.lblCheckCountStatus.Name = "lblCheckCountStatus"
        Me.lblCheckCountStatus.Size = New System.Drawing.Size(117, 20)
        Me.lblCheckCountStatus.TabIndex = 10
        '
        'txtTotalCheckNo
        '
        Me.txtTotalCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCheckNo.Location = New System.Drawing.Point(551, 60)
        Me.txtTotalCheckNo.Name = "txtTotalCheckNo"
        Me.txtTotalCheckNo.Size = New System.Drawing.Size(117, 20)
        Me.txtTotalCheckNo.TabIndex = 9
        '
        'txtValueDate
        '
        Me.txtValueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueDate.Location = New System.Drawing.Point(119, 106)
        Me.txtValueDate.Mask = "00/00/0000"
        Me.txtValueDate.Name = "txtValueDate"
        Me.txtValueDate.Size = New System.Drawing.Size(98, 20)
        Me.txtValueDate.TabIndex = 5
        Me.txtValueDate.ValidatingType = GetType(Date)
        '
        'txtSlipDate
        '
        Me.txtSlipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSlipDate.Location = New System.Drawing.Point(119, 83)
        Me.txtSlipDate.Mask = "00/00/0000"
        Me.txtSlipDate.Name = "txtSlipDate"
        Me.txtSlipDate.Size = New System.Drawing.Size(98, 20)
        Me.txtSlipDate.TabIndex = 4
        Me.txtSlipDate.ValidatingType = GetType(Date)
        '
        'lblDepoLocationName
        '
        Me.lblDepoLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDepoLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepoLocationName.Location = New System.Drawing.Point(680, 13)
        Me.lblDepoLocationName.Name = "lblDepoLocationName"
        Me.lblDepoLocationName.Size = New System.Drawing.Size(170, 20)
        Me.lblDepoLocationName.TabIndex = 10
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(225, 37)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(195, 20)
        Me.lblAccName.TabIndex = 10
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmount.Location = New System.Drawing.Point(551, 83)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(117, 20)
        Me.txtTotalAmount.TabIndex = 10
        '
        'lblAccNo
        '
        Me.lblAccNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccNo.Location = New System.Drawing.Point(119, 60)
        Me.lblAccNo.Name = "lblAccNo"
        Me.lblAccNo.Size = New System.Drawing.Size(301, 20)
        Me.lblAccNo.TabIndex = 10
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(431, 108)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(111, 20)
        Me.Label36.TabIndex = 9
        Me.Label36.Text = "Check Count Status:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "A/C No:"
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(119, 14)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoCode.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Deposit Slip No:"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(431, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 20)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Deposit Location:"
        '
        'txtDepoLocationCode
        '
        Me.txtDepoLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoLocationCode.Location = New System.Drawing.Point(551, 14)
        Me.txtDepoLocationCode.Name = "txtDepoLocationCode"
        Me.txtDepoLocationCode.Size = New System.Drawing.Size(117, 20)
        Me.txtDepoLocationCode.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Client Code:"
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(119, 37)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(98, 20)
        Me.txtClientCode.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 106)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 20)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Value Date:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Deposit Slip Date:"
        '
        'lblClearingZone
        '
        Me.lblClearingZone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClearingZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClearingZone.Location = New System.Drawing.Point(225, 111)
        Me.lblClearingZone.Name = "lblClearingZone"
        Me.lblClearingZone.Size = New System.Drawing.Size(195, 20)
        Me.lblClearingZone.TabIndex = 10
        '
        'txtDraweeLocationCode
        '
        Me.txtDraweeLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeLocationCode.Location = New System.Drawing.Point(119, 88)
        Me.txtDraweeLocationCode.Name = "txtDraweeLocationCode"
        Me.txtDraweeLocationCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeLocationCode.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 20)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Location:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRowNo)
        Me.GroupBox5.Controls.Add(Me.btnCancel)
        Me.GroupBox5.Controls.Add(Me.cmbCheckType)
        Me.GroupBox5.Controls.Add(Me.btnRemoveFromGrid)
        Me.GroupBox5.Controls.Add(Me.btnAddToGrid)
        Me.GroupBox5.Controls.Add(Me.dgView)
        Me.GroupBox5.Controls.Add(Me.lblClearingZoneCode)
        Me.GroupBox5.Controls.Add(Me.lblClearingZone)
        Me.GroupBox5.Controls.Add(Me.txtCheckDate)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.txtAmount)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.txtCheckRef)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.txtDrawerAccNo)
        Me.GroupBox5.Controls.Add(Me.txtCheckNo)
        Me.GroupBox5.Controls.Add(Me.lblDraweeLocationName)
        Me.GroupBox5.Controls.Add(Me.lblDraweeBranchName)
        Me.GroupBox5.Controls.Add(Me.lblDraweeBankName)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.txtDraweeBranchCode)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.txtDraweeBankCode)
        Me.GroupBox5.Controls.Add(Me.txtDraweeLocationCode)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 185)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(861, 408)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'lblRowNo
        '
        Me.lblRowNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRowNo.Location = New System.Drawing.Point(687, 111)
        Me.lblRowNo.Name = "lblRowNo"
        Me.lblRowNo.Size = New System.Drawing.Size(121, 20)
        Me.lblRowNo.TabIndex = 21
        Me.lblRowNo.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(793, 203)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(58, 27)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'cmbCheckType
        '
        Me.cmbCheckType.FormattingEnabled = True
        Me.cmbCheckType.Items.AddRange(New Object() {"Savings", "Current", "DD", "MC", "CC", "STD"})
        Me.cmbCheckType.Location = New System.Drawing.Point(551, 19)
        Me.cmbCheckType.Name = "cmbCheckType"
        Me.cmbCheckType.Size = New System.Drawing.Size(118, 21)
        Me.cmbCheckType.TabIndex = 7
        '
        'btnRemoveFromGrid
        '
        Me.btnRemoveFromGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRemoveFromGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFromGrid.Location = New System.Drawing.Point(793, 170)
        Me.btnRemoveFromGrid.Name = "btnRemoveFromGrid"
        Me.btnRemoveFromGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnRemoveFromGrid.TabIndex = 18
        Me.btnRemoveFromGrid.Text = "Remove"
        Me.btnRemoveFromGrid.UseVisualStyleBackColor = True
        '
        'btnAddToGrid
        '
        Me.btnAddToGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddToGrid.Location = New System.Drawing.Point(793, 135)
        Me.btnAddToGrid.Name = "btnAddToGrid"
        Me.btnAddToGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnAddToGrid.TabIndex = 12
        Me.btnAddToGrid.Text = "Add"
        Me.btnAddToGrid.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column4, Me.Column12, Me.Column5, Me.Column13, Me.Column9, Me.Column14, Me.Column6, Me.Column3, Me.Column8, Me.Column1, Me.Column7, Me.Column11, Me.Column10, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21})
        Me.dgView.Location = New System.Drawing.Point(7, 137)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(782, 262)
        Me.dgView.TabIndex = 13
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "DEPT_ID"
        Me.Column2.HeaderText = "Slno"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column4
        '
        Me.Column4.HeaderText = "Drawer A/C No"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 120
        '
        'Column12
        '
        Me.Column12.HeaderText = "Drawee Bank Code"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Drawee Bank"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column13
        '
        Me.Column13.HeaderText = "Location Code"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Location"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Drawee Branch Code"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Drawee Branch"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 120
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "DEPT_NAME"
        Me.Column3.HeaderText = "Check Date"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 90
        '
        'Column8
        '
        Me.Column8.HeaderText = "Check Type"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 90
        '
        'Column1
        '
        Me.Column1.HeaderText = "Check No"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Check Ref"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Rtn Status"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "NonZone Ref"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Visible = False
        '
        'Column16
        '
        Me.Column16.HeaderText = "Reminder Date"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Visible = False
        '
        'Column17
        '
        Me.Column17.HeaderText = "Reminder No"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Visible = False
        '
        'Column18
        '
        Me.Column18.HeaderText = "Rtn Code"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Visible = False
        '
        'Column19
        '
        Me.Column19.HeaderText = "File name"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Visible = False
        '
        'Column20
        '
        Me.Column20.HeaderText = "File User Id"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        Me.Column20.Visible = False
        '
        'Column21
        '
        Me.Column21.HeaderText = "FlexGen Date"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.Visible = False
        '
        'lblClearingZoneCode
        '
        Me.lblClearingZoneCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClearingZoneCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClearingZoneCode.Location = New System.Drawing.Point(119, 111)
        Me.lblClearingZoneCode.Name = "lblClearingZoneCode"
        Me.lblClearingZoneCode.Size = New System.Drawing.Size(99, 20)
        Me.lblClearingZoneCode.TabIndex = 10
        '
        'txtCheckDate
        '
        Me.txtCheckDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckDate.Location = New System.Drawing.Point(551, 89)
        Me.txtCheckDate.Mask = "00/00/0000"
        Me.txtCheckDate.Name = "txtCheckDate"
        Me.txtCheckDate.Size = New System.Drawing.Size(118, 20)
        Me.txtCheckDate.TabIndex = 10
        Me.txtCheckDate.ValidatingType = GetType(Date)
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(431, 114)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(98, 20)
        Me.Label32.TabIndex = 5
        Me.Label32.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Location = New System.Drawing.Point(551, 111)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(118, 20)
        Me.txtAmount.TabIndex = 11
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(431, 67)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(98, 20)
        Me.Label34.TabIndex = 5
        Me.Label34.Text = "Check Ref No:"
        '
        'txtCheckRef
        '
        Me.txtCheckRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckRef.Location = New System.Drawing.Point(551, 65)
        Me.txtCheckRef.Name = "txtCheckRef"
        Me.txtCheckRef.Size = New System.Drawing.Size(299, 20)
        Me.txtCheckRef.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 20)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Drawer A/C No:"
        '
        'txtDrawerAccNo
        '
        Me.txtDrawerAccNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDrawerAccNo.Location = New System.Drawing.Point(119, 19)
        Me.txtDrawerAccNo.Name = "txtDrawerAccNo"
        Me.txtDrawerAccNo.Size = New System.Drawing.Size(301, 20)
        Me.txtDrawerAccNo.TabIndex = 0
        '
        'txtCheckNo
        '
        Me.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNo.Location = New System.Drawing.Point(551, 42)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(299, 20)
        Me.txtCheckNo.TabIndex = 8
        '
        'lblDraweeLocationName
        '
        Me.lblDraweeLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDraweeLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraweeLocationName.Location = New System.Drawing.Point(225, 87)
        Me.lblDraweeLocationName.Name = "lblDraweeLocationName"
        Me.lblDraweeLocationName.Size = New System.Drawing.Size(195, 20)
        Me.lblDraweeLocationName.TabIndex = 10
        '
        'lblDraweeBranchName
        '
        Me.lblDraweeBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDraweeBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraweeBranchName.Location = New System.Drawing.Point(225, 65)
        Me.lblDraweeBranchName.Name = "lblDraweeBranchName"
        Me.lblDraweeBranchName.Size = New System.Drawing.Size(195, 20)
        Me.lblDraweeBranchName.TabIndex = 10
        '
        'lblDraweeBankName
        '
        Me.lblDraweeBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDraweeBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraweeBankName.Location = New System.Drawing.Point(225, 42)
        Me.lblDraweeBankName.Name = "lblDraweeBankName"
        Me.lblDraweeBankName.Size = New System.Drawing.Size(195, 20)
        Me.lblDraweeBankName.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(431, 90)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(71, 20)
        Me.Label30.TabIndex = 5
        Me.Label30.Text = "Check Date:"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(431, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 20)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Check No:"
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(431, 21)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 20)
        Me.Label39.TabIndex = 5
        Me.Label39.Text = "Check Type:"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 114)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 20)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Clearing Zone:"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 67)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 20)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Drawee Branch:"
        '
        'txtDraweeBranchCode
        '
        Me.txtDraweeBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeBranchCode.Location = New System.Drawing.Point(119, 65)
        Me.txtDraweeBranchCode.Name = "txtDraweeBranchCode"
        Me.txtDraweeBranchCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeBranchCode.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(105, 20)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Drawee Bank:"
        '
        'txtDraweeBankCode
        '
        Me.txtDraweeBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeBankCode.Location = New System.Drawing.Point(119, 42)
        Me.txtDraweeBankCode.Name = "txtDraweeBankCode"
        Me.txtDraweeBankCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeBankCode.TabIndex = 1
        '
        'FrmCitiCheckDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 680)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCitiCheckDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CitiAnywhere Check Detail Information"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDraweeLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblClearingZone As System.Windows.Forms.Label
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveFromGrid As System.Windows.Forms.Button
    Friend WithEvents btnAddToGrid As System.Windows.Forms.Button
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtCheckRef As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblAccNo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCheckCountStatus As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtValueDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSlipDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDepoLocationName As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDepoLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerRef As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDrawerAccNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDraweeBranchName As System.Windows.Forms.Label
    Friend WithEvents lblDraweeBankName As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDraweeBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDraweeBankCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblDraweeLocationName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblRowNo As System.Windows.Forms.Label
    Friend WithEvents lblClearingZoneCode As System.Windows.Forms.Label
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
