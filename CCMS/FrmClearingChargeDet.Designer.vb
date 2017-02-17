<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClearingChargeDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClearingChargeDet))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grpControlBox = New System.Windows.Forms.GroupBox
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
        Me.txtCitiVATAcc = New System.Windows.Forms.TextBox
        Me.label19 = New System.Windows.Forms.Label
        Me.txtCitiExpenseAcc = New System.Windows.Forms.TextBox
        Me.label18 = New System.Windows.Forms.Label
        Me.txtCitiIncomeAcc = New System.Windows.Forms.TextBox
        Me.txtBBKAcc = New System.Windows.Forms.TextBox
        Me.label17 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
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
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.lblRowNo = New System.Windows.Forms.Label
        Me.txtCitiVATAmt = New System.Windows.Forms.TextBox
        Me.txtMaxAmount = New System.Windows.Forms.TextBox
        Me.label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCitiExpenseAmt = New System.Windows.Forms.TextBox
        Me.txtTotalChargeable = New System.Windows.Forms.TextBox
        Me.txtClientDrAmt = New System.Windows.Forms.TextBox
        Me.txtCitiIncomeAmt = New System.Windows.Forms.TextBox
        Me.txtBBKCharge = New System.Windows.Forms.TextBox
        Me.txtMinAmount = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbValueType = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnRemoveFromGrid = New System.Windows.Forms.Button
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnAddToGrid = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpControlBox.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpControlBox
        '
        Me.grpControlBox.Controls.Add(Me.Label7)
        Me.grpControlBox.Controls.Add(Me.Label6)
        Me.grpControlBox.Controls.Add(Me.btnNew)
        Me.grpControlBox.Controls.Add(Me.btnSave)
        Me.grpControlBox.Controls.Add(Me.lblVerTot)
        Me.grpControlBox.Controls.Add(Me.lblVerNo)
        Me.grpControlBox.Controls.Add(Me.btnUnlock)
        Me.grpControlBox.Controls.Add(Me.btnNextVer)
        Me.grpControlBox.Controls.Add(Me.btnPrevVer)
        Me.grpControlBox.Controls.Add(Me.btnDelete)
        Me.grpControlBox.Controls.Add(Me.btnRefresh)
        Me.grpControlBox.Controls.Add(Me.btnClear)
        Me.grpControlBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpControlBox.Location = New System.Drawing.Point(0, 0)
        Me.grpControlBox.Name = "grpControlBox"
        Me.grpControlBox.Size = New System.Drawing.Size(973, 48)
        Me.grpControlBox.TabIndex = 0
        Me.grpControlBox.TabStop = False
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
        Me.btnNew.Enabled = False
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
        Me.btnPrevVer.Location = New System.Drawing.Point(845, 13)
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
        Me.btnClear.Enabled = False
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
        Me.GroupBox2.Controls.Add(Me.txtCitiVATAcc)
        Me.GroupBox2.Controls.Add(Me.label19)
        Me.GroupBox2.Controls.Add(Me.txtCitiExpenseAcc)
        Me.GroupBox2.Controls.Add(Me.label18)
        Me.GroupBox2.Controls.Add(Me.txtCitiIncomeAcc)
        Me.GroupBox2.Controls.Add(Me.txtBBKAcc)
        Me.GroupBox2.Controls.Add(Me.label17)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(962, 113)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Flex Accounts"
        '
        'txtCitiVATAcc
        '
        Me.txtCitiVATAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiVATAcc.Location = New System.Drawing.Point(117, 83)
        Me.txtCitiVATAcc.Name = "txtCitiVATAcc"
        Me.txtCitiVATAcc.Size = New System.Drawing.Size(269, 20)
        Me.txtCitiVATAcc.TabIndex = 3
        '
        'label19
        '
        Me.label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label19.Location = New System.Drawing.Point(6, 85)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(98, 20)
        Me.label19.TabIndex = 9
        Me.label19.Text = "Citi VAT Acc:"
        '
        'txtCitiExpenseAcc
        '
        Me.txtCitiExpenseAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiExpenseAcc.Location = New System.Drawing.Point(117, 61)
        Me.txtCitiExpenseAcc.Name = "txtCitiExpenseAcc"
        Me.txtCitiExpenseAcc.Size = New System.Drawing.Size(269, 20)
        Me.txtCitiExpenseAcc.TabIndex = 2
        '
        'label18
        '
        Me.label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.Location = New System.Drawing.Point(6, 63)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(105, 20)
        Me.label18.TabIndex = 7
        Me.label18.Text = "Citi Expense Acc:"
        '
        'txtCitiIncomeAcc
        '
        Me.txtCitiIncomeAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiIncomeAcc.Location = New System.Drawing.Point(117, 39)
        Me.txtCitiIncomeAcc.Name = "txtCitiIncomeAcc"
        Me.txtCitiIncomeAcc.Size = New System.Drawing.Size(269, 20)
        Me.txtCitiIncomeAcc.TabIndex = 1
        '
        'txtBBKAcc
        '
        Me.txtBBKAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBBKAcc.Location = New System.Drawing.Point(117, 17)
        Me.txtBBKAcc.Name = "txtBBKAcc"
        Me.txtBBKAcc.Size = New System.Drawing.Size(269, 20)
        Me.txtBBKAcc.TabIndex = 0
        '
        'label17
        '
        Me.label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label17.Location = New System.Drawing.Point(6, 41)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(105, 20)
        Me.label17.TabIndex = 5
        Me.label17.Text = "Citi Income Acc:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "BBK Acc:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 515)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(973, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 8
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
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(584, 470)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.GroupBox3.Location = New System.Drawing.Point(4, 452)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 58)
        Me.GroupBox3.TabIndex = 5
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
        Me.btnAuthorize.TabIndex = 0
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
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.lblRowNo)
        Me.GroupBox8.Controls.Add(Me.txtCitiVATAmt)
        Me.GroupBox8.Controls.Add(Me.txtMaxAmount)
        Me.GroupBox8.Controls.Add(Me.label16)
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.txtCitiExpenseAmt)
        Me.GroupBox8.Controls.Add(Me.txtTotalChargeable)
        Me.GroupBox8.Controls.Add(Me.txtClientDrAmt)
        Me.GroupBox8.Controls.Add(Me.txtCitiIncomeAmt)
        Me.GroupBox8.Controls.Add(Me.txtBBKCharge)
        Me.GroupBox8.Controls.Add(Me.txtMinAmount)
        Me.GroupBox8.Controls.Add(Me.Label20)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Controls.Add(Me.cmbValueType)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.btnRemoveFromGrid)
        Me.GroupBox8.Controls.Add(Me.dgView)
        Me.GroupBox8.Controls.Add(Me.btnAddToGrid)
        Me.GroupBox8.Controls.Add(Me.btnCancel)
        Me.GroupBox8.Location = New System.Drawing.Point(4, 162)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(964, 287)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Charge Detail"
        '
        'lblRowNo
        '
        Me.lblRowNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRowNo.Location = New System.Drawing.Point(871, 61)
        Me.lblRowNo.Name = "lblRowNo"
        Me.lblRowNo.Size = New System.Drawing.Size(87, 20)
        Me.lblRowNo.TabIndex = 23
        Me.lblRowNo.Visible = False
        '
        'txtCitiVATAmt
        '
        Me.txtCitiVATAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiVATAmt.Location = New System.Drawing.Point(396, 61)
        Me.txtCitiVATAmt.Name = "txtCitiVATAmt"
        Me.txtCitiVATAmt.Size = New System.Drawing.Size(165, 20)
        Me.txtCitiVATAmt.TabIndex = 5
        '
        'txtMaxAmount
        '
        Me.txtMaxAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxAmount.Location = New System.Drawing.Point(119, 61)
        Me.txtMaxAmount.Name = "txtMaxAmount"
        Me.txtMaxAmount.Size = New System.Drawing.Size(165, 20)
        Me.txtMaxAmount.TabIndex = 2
        '
        'label16
        '
        Me.label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label16.Location = New System.Drawing.Point(313, 63)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(80, 20)
        Me.label16.TabIndex = 25
        Me.label16.Text = "Citi VAT:"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 20)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Max Amount:"
        '
        'txtCitiExpenseAmt
        '
        Me.txtCitiExpenseAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiExpenseAmt.Enabled = False
        Me.txtCitiExpenseAmt.Location = New System.Drawing.Point(691, 61)
        Me.txtCitiExpenseAmt.Name = "txtCitiExpenseAmt"
        Me.txtCitiExpenseAmt.ReadOnly = True
        Me.txtCitiExpenseAmt.Size = New System.Drawing.Size(165, 20)
        Me.txtCitiExpenseAmt.TabIndex = 7
        '
        'txtTotalChargeable
        '
        Me.txtTotalChargeable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalChargeable.Location = New System.Drawing.Point(691, 38)
        Me.txtTotalChargeable.Name = "txtTotalChargeable"
        Me.txtTotalChargeable.Size = New System.Drawing.Size(165, 20)
        Me.txtTotalChargeable.TabIndex = 7
        '
        'txtClientDrAmt
        '
        Me.txtClientDrAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientDrAmt.Location = New System.Drawing.Point(691, 15)
        Me.txtClientDrAmt.Name = "txtClientDrAmt"
        Me.txtClientDrAmt.Size = New System.Drawing.Size(165, 20)
        Me.txtClientDrAmt.TabIndex = 6
        '
        'txtCitiIncomeAmt
        '
        Me.txtCitiIncomeAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiIncomeAmt.Location = New System.Drawing.Point(396, 38)
        Me.txtCitiIncomeAmt.Name = "txtCitiIncomeAmt"
        Me.txtCitiIncomeAmt.Size = New System.Drawing.Size(165, 20)
        Me.txtCitiIncomeAmt.TabIndex = 4
        '
        'txtBBKCharge
        '
        Me.txtBBKCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBBKCharge.Location = New System.Drawing.Point(396, 15)
        Me.txtBBKCharge.Name = "txtBBKCharge"
        Me.txtBBKCharge.Size = New System.Drawing.Size(165, 20)
        Me.txtBBKCharge.TabIndex = 3
        '
        'txtMinAmount
        '
        Me.txtMinAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinAmount.Location = New System.Drawing.Point(119, 38)
        Me.txtMinAmount.Name = "txtMinAmount"
        Me.txtMinAmount.Size = New System.Drawing.Size(165, 20)
        Me.txtMinAmount.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(588, 63)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 20)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Citi Expense Amt:"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(588, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 20)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Total Chargeable:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(588, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 20)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Client Dr Amount:"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(313, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Citi Income:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(313, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 20)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "BBK Charge:"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Min Amount:"
        '
        'cmbValueType
        '
        Me.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValueType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbValueType.FormattingEnabled = True
        Me.cmbValueType.Location = New System.Drawing.Point(119, 14)
        Me.cmbValueType.Name = "cmbValueType"
        Me.cmbValueType.Size = New System.Drawing.Size(165, 21)
        Me.cmbValueType.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Value Type:"
        '
        'btnRemoveFromGrid
        '
        Me.btnRemoveFromGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRemoveFromGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveFromGrid.Location = New System.Drawing.Point(900, 120)
        Me.btnRemoveFromGrid.Name = "btnRemoveFromGrid"
        Me.btnRemoveFromGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnRemoveFromGrid.TabIndex = 9
        Me.btnRemoveFromGrid.Text = "Remove"
        Me.btnRemoveFromGrid.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column2, Me.Column1, Me.Column4, Me.Column5, Me.Column6, Me.Column11})
        Me.dgView.Location = New System.Drawing.Point(9, 88)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.ReadOnly = True
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(885, 188)
        Me.dgView.TabIndex = 17
        '
        'Column3
        '
        Me.Column3.HeaderText = "Slno"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Value Type Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 90
        '
        'Column8
        '
        Me.Column8.HeaderText = "Value Type"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 90
        '
        'Column9
        '
        Me.Column9.HeaderText = "Min Amount"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Max Amount"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "BBK Chrg"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 85
        '
        'Column1
        '
        Me.Column1.HeaderText = "Citi Income"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 85
        '
        'Column4
        '
        Me.Column4.HeaderText = "Citi Vat"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 85
        '
        'Column5
        '
        Me.Column5.HeaderText = "Client Dr"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 85
        '
        'Column6
        '
        Me.Column6.HeaderText = "Chargeable"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 85
        '
        'Column11
        '
        Me.Column11.HeaderText = "Citi Expense"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 90
        '
        'btnAddToGrid
        '
        Me.btnAddToGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAddToGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddToGrid.Location = New System.Drawing.Point(900, 88)
        Me.btnAddToGrid.Name = "btnAddToGrid"
        Me.btnAddToGrid.Size = New System.Drawing.Size(58, 27)
        Me.btnAddToGrid.TabIndex = 8
        Me.btnAddToGrid.Text = "Add"
        Me.btnAddToGrid.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(900, 154)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(58, 27)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'FrmClearingChargeDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 537)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grpControlBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClearingChargeDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clearing Charge - Detail"
        Me.grpControlBox.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpControlBox As System.Windows.Forms.GroupBox
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
    Friend WithEvents txtBBKAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCitiIncomeAcc As System.Windows.Forms.TextBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveFromGrid As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAddToGrid As System.Windows.Forms.Button
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents txtBBKCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtMinAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbValueType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCitiVATAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRowNo As System.Windows.Forms.Label
    Friend WithEvents txtCitiExpenseAcc As System.Windows.Forms.TextBox
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtCitiVATAcc As System.Windows.Forms.TextBox
    Friend WithEvents label19 As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalChargeable As System.Windows.Forms.TextBox
    Friend WithEvents txtClientDrAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtCitiIncomeAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCitiExpenseAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
