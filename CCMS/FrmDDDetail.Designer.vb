<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDDDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDDDetail))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnExit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
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
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnUnlock = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtDraweePostageCharge = New System.Windows.Forms.TextBox
        Me.txtDraweeInstrumentCharge = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnSearchBranch = New System.Windows.Forms.Button
        Me.btnSearchNikas = New System.Windows.Forms.Button
        Me.btnSearchLocation = New System.Windows.Forms.Button
        Me.btnSearchBank = New System.Windows.Forms.Button
        Me.lblBranchName = New System.Windows.Forms.Label
        Me.lblTotalCheckAmount = New System.Windows.Forms.Label
        Me.lblNikashBranchName = New System.Windows.Forms.Label
        Me.lblBankName = New System.Windows.Forms.Label
        Me.lblLocationName = New System.Windows.Forms.Label
        Me.txtDDDate = New System.Windows.Forms.MaskedTextBox
        Me.txtDDNo = New System.Windows.Forms.TextBox
        Me.txtBranchCode = New System.Windows.Forms.TextBox
        Me.txtBankCode = New System.Windows.Forms.TextBox
        Me.txtDDAmount = New System.Windows.Forms.TextBox
        Me.txtDraweeComm = New System.Windows.Forms.TextBox
        Me.txtDraweeVat = New System.Windows.Forms.TextBox
        Me.txtNikashBranch = New System.Windows.Forms.TextBox
        Me.txtLocationCode = New System.Windows.Forms.TextBox
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.dgViewNotPaid = New System.Windows.Forms.DataGridView
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.city_charge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.str_charge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dr_vat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Check_Ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgViewPaid = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Check_rf = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPaid = New System.Windows.Forms.Button
        Me.btnRem = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnPaidSelected = New System.Windows.Forms.Button
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.Column19 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vat_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Instru = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Postage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bank_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Branch_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nikbranch = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.modno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rtn_status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnAdd = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgViewNotPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgViewPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 710)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(988, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(973, 17)
        Me.lblToolStatus.Spring = True
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(738, 667)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label16)
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
        Me.GroupBox3.Location = New System.Drawing.Point(5, 649)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 58)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status"
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(573, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 18)
        Me.Label16.TabIndex = 5
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.btnAuthorize.Location = New System.Drawing.Point(465, 17)
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
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnUnlock)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(988, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
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
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(156, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(68, 27)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(438, 284)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 27)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Update Status"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(438, 317)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 27)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDraweePostageCharge)
        Me.GroupBox2.Controls.Add(Me.txtDraweeInstrumentCharge)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.btnSearchBranch)
        Me.GroupBox2.Controls.Add(Me.btnSearchNikas)
        Me.GroupBox2.Controls.Add(Me.btnSearchLocation)
        Me.GroupBox2.Controls.Add(Me.btnSearchBank)
        Me.GroupBox2.Controls.Add(Me.lblBranchName)
        Me.GroupBox2.Controls.Add(Me.lblTotalCheckAmount)
        Me.GroupBox2.Controls.Add(Me.lblNikashBranchName)
        Me.GroupBox2.Controls.Add(Me.lblBankName)
        Me.GroupBox2.Controls.Add(Me.lblLocationName)
        Me.GroupBox2.Controls.Add(Me.txtDDDate)
        Me.GroupBox2.Controls.Add(Me.txtDDNo)
        Me.GroupBox2.Controls.Add(Me.txtBranchCode)
        Me.GroupBox2.Controls.Add(Me.txtBankCode)
        Me.GroupBox2.Controls.Add(Me.txtDDAmount)
        Me.GroupBox2.Controls.Add(Me.txtDraweeComm)
        Me.GroupBox2.Controls.Add(Me.txtDraweeVat)
        Me.GroupBox2.Controls.Add(Me.txtNikashBranch)
        Me.GroupBox2.Controls.Add(Me.txtLocationCode)
        Me.GroupBox2.Controls.Add(Me.txtDepoCode)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(980, 227)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtDraweePostageCharge
        '
        Me.txtDraweePostageCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweePostageCharge.Location = New System.Drawing.Point(520, 152)
        Me.txtDraweePostageCharge.Name = "txtDraweePostageCharge"
        Me.txtDraweePostageCharge.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweePostageCharge.TabIndex = 13
        '
        'txtDraweeInstrumentCharge
        '
        Me.txtDraweeInstrumentCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeInstrumentCharge.Location = New System.Drawing.Point(520, 175)
        Me.txtDraweeInstrumentCharge.Name = "txtDraweeInstrumentCharge"
        Me.txtDraweeInstrumentCharge.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeInstrumentCharge.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(340, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(174, 20)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Drawee Bank Postage Charge:"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(340, 178)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(177, 20)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Drawee Bank Instrument Expense:"
        '
        'btnSearchBranch
        '
        Me.btnSearchBranch.FlatAppearance.BorderSize = 0
        Me.btnSearchBranch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBranch.Image = CType(resources.GetObject("btnSearchBranch.Image"), System.Drawing.Image)
        Me.btnSearchBranch.Location = New System.Drawing.Point(624, 36)
        Me.btnSearchBranch.Name = "btnSearchBranch"
        Me.btnSearchBranch.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBranch.TabIndex = 6
        Me.btnSearchBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBranch.UseVisualStyleBackColor = True
        '
        'btnSearchNikas
        '
        Me.btnSearchNikas.FlatAppearance.BorderSize = 0
        Me.btnSearchNikas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchNikas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchNikas.Image = CType(resources.GetObject("btnSearchNikas.Image"), System.Drawing.Image)
        Me.btnSearchNikas.Location = New System.Drawing.Point(624, 82)
        Me.btnSearchNikas.Name = "btnSearchNikas"
        Me.btnSearchNikas.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchNikas.TabIndex = 10
        Me.btnSearchNikas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchNikas.UseVisualStyleBackColor = True
        '
        'btnSearchLocation
        '
        Me.btnSearchLocation.FlatAppearance.BorderSize = 0
        Me.btnSearchLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchLocation.Image = CType(resources.GetObject("btnSearchLocation.Image"), System.Drawing.Image)
        Me.btnSearchLocation.Location = New System.Drawing.Point(624, 60)
        Me.btnSearchLocation.Name = "btnSearchLocation"
        Me.btnSearchLocation.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchLocation.TabIndex = 8
        Me.btnSearchLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchLocation.UseVisualStyleBackColor = True
        '
        'btnSearchBank
        '
        Me.btnSearchBank.FlatAppearance.BorderSize = 0
        Me.btnSearchBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchBank.Image = CType(resources.GetObject("btnSearchBank.Image"), System.Drawing.Image)
        Me.btnSearchBank.Location = New System.Drawing.Point(624, 13)
        Me.btnSearchBank.Name = "btnSearchBank"
        Me.btnSearchBank.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchBank.TabIndex = 4
        Me.btnSearchBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchBank.UseVisualStyleBackColor = True
        '
        'lblBranchName
        '
        Me.lblBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchName.Location = New System.Drawing.Point(649, 37)
        Me.lblBranchName.Name = "lblBranchName"
        Me.lblBranchName.Size = New System.Drawing.Size(204, 20)
        Me.lblBranchName.TabIndex = 10
        '
        'lblTotalCheckAmount
        '
        Me.lblTotalCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheckAmount.Location = New System.Drawing.Point(738, 198)
        Me.lblTotalCheckAmount.Name = "lblTotalCheckAmount"
        Me.lblTotalCheckAmount.Size = New System.Drawing.Size(115, 20)
        Me.lblTotalCheckAmount.TabIndex = 10
        '
        'lblNikashBranchName
        '
        Me.lblNikashBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNikashBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNikashBranchName.Location = New System.Drawing.Point(649, 83)
        Me.lblNikashBranchName.Name = "lblNikashBranchName"
        Me.lblNikashBranchName.Size = New System.Drawing.Size(204, 20)
        Me.lblNikashBranchName.TabIndex = 10
        '
        'lblBankName
        '
        Me.lblBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankName.Location = New System.Drawing.Point(649, 15)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(204, 20)
        Me.lblBankName.TabIndex = 10
        '
        'lblLocationName
        '
        Me.lblLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationName.Location = New System.Drawing.Point(649, 61)
        Me.lblLocationName.Name = "lblLocationName"
        Me.lblLocationName.Size = New System.Drawing.Size(204, 20)
        Me.lblLocationName.TabIndex = 10
        '
        'txtDDDate
        '
        Me.txtDDDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDDDate.Location = New System.Drawing.Point(113, 60)
        Me.txtDDDate.Mask = "00/00/0000"
        Me.txtDDDate.Name = "txtDDDate"
        Me.txtDDDate.Size = New System.Drawing.Size(134, 20)
        Me.txtDDDate.TabIndex = 2
        Me.txtDDDate.ValidatingType = GetType(Date)
        '
        'txtDDNo
        '
        Me.txtDDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDDNo.Location = New System.Drawing.Point(113, 37)
        Me.txtDDNo.Name = "txtDDNo"
        Me.txtDDNo.Size = New System.Drawing.Size(134, 20)
        Me.txtDDNo.TabIndex = 1
        '
        'txtBranchCode
        '
        Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchCode.Location = New System.Drawing.Point(520, 37)
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.Size = New System.Drawing.Size(98, 20)
        Me.txtBranchCode.TabIndex = 5
        '
        'txtBankCode
        '
        Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankCode.Location = New System.Drawing.Point(520, 14)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(98, 20)
        Me.txtBankCode.TabIndex = 3
        '
        'txtDDAmount
        '
        Me.txtDDAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDDAmount.Location = New System.Drawing.Point(520, 198)
        Me.txtDDAmount.Name = "txtDDAmount"
        Me.txtDDAmount.Size = New System.Drawing.Size(98, 20)
        Me.txtDDAmount.TabIndex = 15
        '
        'txtDraweeComm
        '
        Me.txtDraweeComm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeComm.Location = New System.Drawing.Point(520, 107)
        Me.txtDraweeComm.Name = "txtDraweeComm"
        Me.txtDraweeComm.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeComm.TabIndex = 11
        '
        'txtDraweeVat
        '
        Me.txtDraweeVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeVat.Location = New System.Drawing.Point(520, 130)
        Me.txtDraweeVat.Name = "txtDraweeVat"
        Me.txtDraweeVat.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeVat.TabIndex = 12
        '
        'txtNikashBranch
        '
        Me.txtNikashBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNikashBranch.Location = New System.Drawing.Point(520, 83)
        Me.txtNikashBranch.Name = "txtNikashBranch"
        Me.txtNikashBranch.Size = New System.Drawing.Size(98, 20)
        Me.txtNikashBranch.TabIndex = 9
        '
        'txtLocationCode
        '
        Me.txtLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocationCode.Location = New System.Drawing.Point(520, 60)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.Size = New System.Drawing.Size(98, 20)
        Me.txtLocationCode.TabIndex = 7
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(113, 14)
        Me.txtDepoCode.MaxLength = 12
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(134, 20)
        Me.txtDepoCode.TabIndex = 0
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(15, 39)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 20)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "DD No:"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(340, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Branch Code:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(340, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Bank Code:"
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(340, 86)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 20)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Drawee:"
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(624, 200)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 20)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Total Check Amount:"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(340, 200)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(98, 20)
        Me.Label28.TabIndex = 5
        Me.Label28.Text = "DD Amount:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(340, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Drawee Bank Comm:"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(340, 133)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(113, 20)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Drawee Bank VAT:"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(340, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Location Code:"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(247, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 20)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "[ dd/mm/yyyy ]"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "DD Date:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Deposit Code:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgViewNotPaid)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 275)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(429, 173)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'dgViewNotPaid
        '
        Me.dgViewNotPaid.AllowUserToAddRows = False
        Me.dgViewNotPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewNotPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column4, Me.Column5, Me.Column9, Me.Column10, Me.city_charge, Me.str_charge, Me.dr_vat, Me.Check_Ref, Me.Column20})
        Me.dgViewNotPaid.Location = New System.Drawing.Point(6, 19)
        Me.dgViewNotPaid.Name = "dgViewNotPaid"
        Me.dgViewNotPaid.ReadOnly = True
        Me.dgViewNotPaid.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgViewNotPaid.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgViewNotPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewNotPaid.Size = New System.Drawing.Size(413, 148)
        Me.dgViewNotPaid.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "DEPT_ID"
        Me.Column2.HeaderText = "Ref No"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 75
        '
        'Column4
        '
        Me.Column4.HeaderText = "Check No"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 95
        '
        'Column5
        '
        Me.Column5.HeaderText = "Amount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column9
        '
        Me.Column9.HeaderText = "Client Name"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Acc No"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'city_charge
        '
        Me.city_charge.HeaderText = "City Charge"
        Me.city_charge.Name = "city_charge"
        Me.city_charge.ReadOnly = True
        '
        'str_charge
        '
        Me.str_charge.HeaderText = "Std Charge"
        Me.str_charge.Name = "str_charge"
        Me.str_charge.ReadOnly = True
        '
        'dr_vat
        '
        Me.dr_vat.HeaderText = "Vat"
        Me.dr_vat.Name = "dr_vat"
        Me.dr_vat.ReadOnly = True
        '
        'Check_Ref
        '
        Me.Check_Ref.HeaderText = "Check Ref"
        Me.Check_Ref.Name = "Check_Ref"
        Me.Check_Ref.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.HeaderText = "Drawer Ac"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgViewPaid)
        Me.GroupBox4.Location = New System.Drawing.Point(532, 275)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(453, 173)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selected"
        '
        'dgViewPaid
        '
        Me.dgViewPaid.AllowUserToAddRows = False
        Me.dgViewPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Check_rf, Me.Column16})
        Me.dgViewPaid.Location = New System.Drawing.Point(6, 19)
        Me.dgViewPaid.Name = "dgViewPaid"
        Me.dgViewPaid.ReadOnly = True
        Me.dgViewPaid.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgViewPaid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgViewPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgViewPaid.Size = New System.Drawing.Size(441, 149)
        Me.dgViewPaid.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DEPT_ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Ref No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Check No"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 95
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'Column11
        '
        Me.Column11.HeaderText = "Client Name"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Acc No"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Citibank Chrg"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Std Charge"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "Citibank VAT"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Check_rf
        '
        Me.Check_rf.HeaderText = "Check Ref"
        Me.Check_rf.Name = "Check_rf"
        Me.Check_rf.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "Pay to Client"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'btnPaid
        '
        Me.btnPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPaid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnPaid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPaid.Location = New System.Drawing.Point(438, 350)
        Me.btnPaid.Name = "btnPaid"
        Me.btnPaid.Size = New System.Drawing.Size(88, 27)
        Me.btnPaid.TabIndex = 5
        Me.btnPaid.Text = "Paid"
        Me.btnPaid.UseVisualStyleBackColor = True
        '
        'btnRem
        '
        Me.btnRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRem.Image = CType(resources.GetObject("btnRem.Image"), System.Drawing.Image)
        Me.btnRem.Location = New System.Drawing.Point(465, 416)
        Me.btnRem.Name = "btnRem"
        Me.btnRem.Size = New System.Drawing.Size(31, 27)
        Me.btnRem.TabIndex = 7
        Me.btnRem.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnPaidSelected)
        Me.GroupBox6.Controls.Add(Me.chkAll)
        Me.GroupBox6.Controls.Add(Me.dgView)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 449)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(980, 200)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        '
        'btnPaidSelected
        '
        Me.btnPaidSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPaidSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnPaidSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPaidSelected.Location = New System.Drawing.Point(77, 11)
        Me.btnPaidSelected.Name = "btnPaidSelected"
        Me.btnPaidSelected.Size = New System.Drawing.Size(91, 23)
        Me.btnPaidSelected.TabIndex = 15
        Me.btnPaidSelected.Text = "Paid Selected"
        Me.btnPaidSelected.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(24, 15)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(37, 17)
        Me.chkAll.TabIndex = 14
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column19, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.Column1, Me.Column3, Me.Column6, Me.Column7, Me.Column8, Me.Vat_2, Me.Comm, Me.Instru, Me.Postage, Me.Bank_code, Me.Branch_code, Me.Column18, Me.nikbranch, Me.D_code, Me.modno, Me.rtn_status, Me.Column17})
        Me.dgView.Location = New System.Drawing.Point(15, 36)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(968, 158)
        Me.dgView.TabIndex = 13
        '
        'Column19
        '
        Me.Column19.HeaderText = ""
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DEPT_ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Slno"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "DD No"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 95
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "DD Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 120
        '
        'Column1
        '
        Me.Column1.HeaderText = "Bank"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Branch"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Location"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Drawee"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "DD Amount"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Vat_2
        '
        Me.Vat_2.HeaderText = "Vat"
        Me.Vat_2.Name = "Vat_2"
        Me.Vat_2.ReadOnly = True
        Me.Vat_2.Visible = False
        '
        'Comm
        '
        Me.Comm.HeaderText = "Comm"
        Me.Comm.Name = "Comm"
        Me.Comm.ReadOnly = True
        Me.Comm.Visible = False
        '
        'Instru
        '
        Me.Instru.HeaderText = "Instru"
        Me.Instru.Name = "Instru"
        Me.Instru.ReadOnly = True
        Me.Instru.Visible = False
        '
        'Postage
        '
        Me.Postage.HeaderText = "Postage"
        Me.Postage.Name = "Postage"
        Me.Postage.ReadOnly = True
        Me.Postage.Visible = False
        '
        'Bank_code
        '
        Me.Bank_code.HeaderText = "Bank Code"
        Me.Bank_code.Name = "Bank_code"
        Me.Bank_code.ReadOnly = True
        Me.Bank_code.Visible = False
        '
        'Branch_code
        '
        Me.Branch_code.HeaderText = "Branch Code"
        Me.Branch_code.Name = "Branch_code"
        Me.Branch_code.ReadOnly = True
        Me.Branch_code.Visible = False
        '
        'Column18
        '
        Me.Column18.HeaderText = "Location"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Visible = False
        '
        'nikbranch
        '
        Me.nikbranch.HeaderText = "Nikbranch"
        Me.nikbranch.Name = "nikbranch"
        Me.nikbranch.ReadOnly = True
        Me.nikbranch.Visible = False
        '
        'D_code
        '
        Me.D_code.HeaderText = "D_CODE"
        Me.D_code.Name = "D_code"
        Me.D_code.ReadOnly = True
        Me.D_code.Visible = False
        '
        'modno
        '
        Me.modno.HeaderText = "MOD_NO"
        Me.modno.Name = "modno"
        Me.modno.ReadOnly = True
        Me.modno.Visible = False
        '
        'rtn_status
        '
        Me.rtn_status.HeaderText = "DD STATUS"
        Me.rtn_status.Name = "rtn_status"
        Me.rtn_status.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.HeaderText = "Status"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 70
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(465, 383)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(31, 27)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'FrmDDDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 732)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnRem)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPaid)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDDDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DD Detail"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgViewNotPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgViewPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
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
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUnlock As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDDDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblLocationName As System.Windows.Forms.Label
    Friend WithEvents txtBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSearchBranch As System.Windows.Forms.Button
    Friend WithEvents btnSearchBank As System.Windows.Forms.Button
    Friend WithEvents lblBranchName As System.Windows.Forms.Label
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dgViewNotPaid As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearchLocation As System.Windows.Forms.Button
    Friend WithEvents txtDDNo As System.Windows.Forms.TextBox
    Friend WithEvents txtDDAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDraweeVat As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgViewPaid As System.Windows.Forms.DataGridView
    Friend WithEvents btnPaid As System.Windows.Forms.Button
    Friend WithEvents btnRem As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents txtDraweeComm As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDraweePostageCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtDraweeInstrumentCharge As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnSearchNikas As System.Windows.Forms.Button
    Friend WithEvents lblNikashBranchName As System.Windows.Forms.Label
    Friend WithEvents txtNikashBranch As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCheckAmount As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Check_rf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vat_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Instru As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Postage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bank_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Branch_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nikbranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rtn_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPaidSelected As System.Windows.Forms.Button
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents city_charge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents str_charge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dr_vat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Check_Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
