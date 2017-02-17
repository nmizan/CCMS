<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDepoScheSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDepoScheSearch))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbDepositType = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDepoScheCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCitiCheckAmt = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCitiCashAmt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRef = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtCorrBankCode = New System.Windows.Forms.TextBox
        Me.btnSearchCorrBank = New System.Windows.Forms.Button
        Me.lblCorrBankName = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLocationCode = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnSearchLocation = New System.Windows.Forms.Button
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.lblLocationName = New System.Windows.Forms.Label
        Me.btnSearchCustomer = New System.Windows.Forms.Button
        Me.lblAccName = New System.Windows.Forms.Label
        Me.txtScheDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtScheDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDraweeBankCode = New System.Windows.Forms.TextBox
        Me.btnSearchDraweeBank = New System.Windows.Forms.Button
        Me.lblDraweeBankName = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.grpSpeed = New System.Windows.Forms.GroupBox
        Me.chkCitiSpeed = New System.Windows.Forms.CheckBox
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpSpeed.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Controls.Add(Me.dgView)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 266)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(987, 369)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'btnExport
        '
        Me.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(788, 9)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(77, 27)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column11, Me.Column14, Me.Column16, Me.Column5, Me.Column4, Me.Column2, Me.Column1, Me.Column3, Me.Column12, Me.Column13, Me.Column15, Me.Column7, Me.Column9, Me.Column10, Me.Column8})
        Me.dgView.Location = New System.Drawing.Point(6, 42)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(975, 321)
        Me.dgView.TabIndex = 0
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
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmbDepositType)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtDepoCode)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtDepoScheCode)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtCitiCheckAmt)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtCitiCashAmt)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtRef)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtCorrBankCode)
        Me.GroupBox2.Controls.Add(Me.btnSearchCorrBank)
        Me.GroupBox2.Controls.Add(Me.lblCorrBankName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtLocationCode)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.btnSearchLocation)
        Me.GroupBox2.Controls.Add(Me.txtClientCode)
        Me.GroupBox2.Controls.Add(Me.lblLocationName)
        Me.GroupBox2.Controls.Add(Me.btnSearchCustomer)
        Me.GroupBox2.Controls.Add(Me.lblAccName)
        Me.GroupBox2.Controls.Add(Me.txtScheDateTo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtScheDateFrom)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(993, 139)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Schedule"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(475, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 20)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Deposit Type :"
        '
        'cmbDepositType
        '
        Me.cmbDepositType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositType.FormattingEnabled = True
        Me.cmbDepositType.Items.AddRange(New Object() {"", "Cash", "Check"})
        Me.cmbDepositType.Location = New System.Drawing.Point(581, 66)
        Me.cmbDepositType.Name = "cmbDepositType"
        Me.cmbDepositType.Size = New System.Drawing.Size(98, 21)
        Me.cmbDepositType.TabIndex = 10
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(475, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 20)
        Me.Label23.TabIndex = 47
        Me.Label23.Text = "Deposit Code:"
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(581, 43)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoCode.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 20)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "DS Code:"
        '
        'txtDepoScheCode
        '
        Me.txtDepoScheCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoScheCode.Location = New System.Drawing.Point(120, 43)
        Me.txtDepoScheCode.Name = "txtDepoScheCode"
        Me.txtDepoScheCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoScheCode.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(475, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Citi Cash Amount:"
        '
        'txtCitiCheckAmt
        '
        Me.txtCitiCheckAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiCheckAmt.Location = New System.Drawing.Point(581, 113)
        Me.txtCitiCheckAmt.Name = "txtCitiCheckAmt"
        Me.txtCitiCheckAmt.Size = New System.Drawing.Size(98, 20)
        Me.txtCitiCheckAmt.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(475, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Citi Check Amount:"
        '
        'txtCitiCashAmt
        '
        Me.txtCitiCashAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiCashAmt.Location = New System.Drawing.Point(581, 90)
        Me.txtCitiCashAmt.Name = "txtCitiCashAmt"
        Me.txtCitiCashAmt.Size = New System.Drawing.Size(98, 20)
        Me.txtCitiCashAmt.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Ref:"
        '
        'txtRef
        '
        Me.txtRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRef.Location = New System.Drawing.Point(120, 112)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(98, 20)
        Me.txtRef.TabIndex = 6
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 92)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Corr. Bank Code:"
        '
        'txtCorrBankCode
        '
        Me.txtCorrBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCorrBankCode.Enabled = False
        Me.txtCorrBankCode.Location = New System.Drawing.Point(120, 89)
        Me.txtCorrBankCode.Name = "txtCorrBankCode"
        Me.txtCorrBankCode.ReadOnly = True
        Me.txtCorrBankCode.Size = New System.Drawing.Size(98, 20)
        Me.txtCorrBankCode.TabIndex = 28
        '
        'btnSearchCorrBank
        '
        Me.btnSearchCorrBank.FlatAppearance.BorderSize = 0
        Me.btnSearchCorrBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchCorrBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCorrBank.Image = CType(resources.GetObject("btnSearchCorrBank.Image"), System.Drawing.Image)
        Me.btnSearchCorrBank.Location = New System.Drawing.Point(222, 88)
        Me.btnSearchCorrBank.Name = "btnSearchCorrBank"
        Me.btnSearchCorrBank.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchCorrBank.TabIndex = 5
        Me.btnSearchCorrBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchCorrBank.UseVisualStyleBackColor = True
        '
        'lblCorrBankName
        '
        Me.lblCorrBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorrBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrBankName.Location = New System.Drawing.Point(250, 90)
        Me.lblCorrBankName.Name = "lblCorrBankName"
        Me.lblCorrBankName.Size = New System.Drawing.Size(198, 20)
        Me.lblCorrBankName.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Location Code:"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocationCode.Location = New System.Drawing.Point(120, 66)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.Size = New System.Drawing.Size(98, 20)
        Me.txtLocationCode.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(475, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Client Code:"
        '
        'btnSearchLocation
        '
        Me.btnSearchLocation.FlatAppearance.BorderSize = 0
        Me.btnSearchLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchLocation.Image = CType(resources.GetObject("btnSearchLocation.Image"), System.Drawing.Image)
        Me.btnSearchLocation.Location = New System.Drawing.Point(222, 66)
        Me.btnSearchLocation.Name = "btnSearchLocation"
        Me.btnSearchLocation.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchLocation.TabIndex = 4
        Me.btnSearchLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchLocation.UseVisualStyleBackColor = True
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(581, 20)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(98, 20)
        Me.txtClientCode.TabIndex = 7
        '
        'lblLocationName
        '
        Me.lblLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationName.Location = New System.Drawing.Point(250, 67)
        Me.lblLocationName.Name = "lblLocationName"
        Me.lblLocationName.Size = New System.Drawing.Size(198, 20)
        Me.lblLocationName.TabIndex = 25
        '
        'btnSearchCustomer
        '
        Me.btnSearchCustomer.FlatAppearance.BorderSize = 0
        Me.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCustomer.Image = CType(resources.GetObject("btnSearchCustomer.Image"), System.Drawing.Image)
        Me.btnSearchCustomer.Location = New System.Drawing.Point(683, 20)
        Me.btnSearchCustomer.Name = "btnSearchCustomer"
        Me.btnSearchCustomer.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchCustomer.TabIndex = 8
        Me.btnSearchCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchCustomer.UseVisualStyleBackColor = True
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(711, 20)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(198, 20)
        Me.lblAccName.TabIndex = 25
        '
        'txtScheDateTo
        '
        Me.txtScheDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheDateTo.Location = New System.Drawing.Point(350, 20)
        Me.txtScheDateTo.Mask = "00/00/0000"
        Me.txtScheDateTo.Name = "txtScheDateTo"
        Me.txtScheDateTo.Size = New System.Drawing.Size(98, 20)
        Me.txtScheDateTo.TabIndex = 1
        Me.txtScheDateTo.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(247, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Schedule Date To:"
        '
        'txtScheDateFrom
        '
        Me.txtScheDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheDateFrom.Location = New System.Drawing.Point(120, 20)
        Me.txtScheDateFrom.Mask = "00/00/0000"
        Me.txtScheDateFrom.Name = "txtScheDateFrom"
        Me.txtScheDateFrom.Size = New System.Drawing.Size(98, 20)
        Me.txtScheDateFrom.TabIndex = 0
        Me.txtScheDateFrom.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Schedule Date From:"
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(581, 196)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 27)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 20)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Check Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Location = New System.Drawing.Point(120, 65)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(98, 20)
        Me.txtAmount.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 20)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "Check No:"
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(120, 42)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(98, 20)
        Me.txtCheckNumber.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 20)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "Drawee Bank :"
        '
        'txtDraweeBankCode
        '
        Me.txtDraweeBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeBankCode.Location = New System.Drawing.Point(120, 19)
        Me.txtDraweeBankCode.Name = "txtDraweeBankCode"
        Me.txtDraweeBankCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeBankCode.TabIndex = 0
        '
        'btnSearchDraweeBank
        '
        Me.btnSearchDraweeBank.FlatAppearance.BorderSize = 0
        Me.btnSearchDraweeBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchDraweeBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchDraweeBank.Image = CType(resources.GetObject("btnSearchDraweeBank.Image"), System.Drawing.Image)
        Me.btnSearchDraweeBank.Location = New System.Drawing.Point(222, 17)
        Me.btnSearchDraweeBank.Name = "btnSearchDraweeBank"
        Me.btnSearchDraweeBank.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchDraweeBank.TabIndex = 1
        Me.btnSearchDraweeBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchDraweeBank.UseVisualStyleBackColor = True
        '
        'lblDraweeBankName
        '
        Me.lblDraweeBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDraweeBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraweeBankName.Location = New System.Drawing.Point(250, 19)
        Me.lblDraweeBankName.Name = "lblDraweeBankName"
        Me.lblDraweeBankName.Size = New System.Drawing.Size(198, 20)
        Me.lblDraweeBankName.TabIndex = 34
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(721, 196)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 27)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'grpSpeed
        '
        Me.grpSpeed.Controls.Add(Me.Label24)
        Me.grpSpeed.Controls.Add(Me.txtAmount)
        Me.grpSpeed.Controls.Add(Me.Label26)
        Me.grpSpeed.Controls.Add(Me.txtCheckNumber)
        Me.grpSpeed.Controls.Add(Me.Label19)
        Me.grpSpeed.Controls.Add(Me.lblDraweeBankName)
        Me.grpSpeed.Controls.Add(Me.btnSearchDraweeBank)
        Me.grpSpeed.Controls.Add(Me.txtDraweeBankCode)
        Me.grpSpeed.Location = New System.Drawing.Point(0, 161)
        Me.grpSpeed.Name = "grpSpeed"
        Me.grpSpeed.Size = New System.Drawing.Size(491, 99)
        Me.grpSpeed.TabIndex = 2
        Me.grpSpeed.TabStop = False
        Me.grpSpeed.Text = "Citi Speed"
        '
        'chkCitiSpeed
        '
        Me.chkCitiSpeed.AutoSize = True
        Me.chkCitiSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCitiSpeed.Location = New System.Drawing.Point(9, 145)
        Me.chkCitiSpeed.Name = "chkCitiSpeed"
        Me.chkCitiSpeed.Size = New System.Drawing.Size(109, 17)
        Me.chkCitiSpeed.TabIndex = 1
        Me.chkCitiSpeed.Text = "Include Citi Speed"
        Me.chkCitiSpeed.UseVisualStyleBackColor = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Sche Date"
        Me.Column6.Name = "Column6"
        '
        'Column11
        '
        Me.Column11.HeaderText = "DS Code"
        Me.Column11.Name = "Column11"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Depo Code"
        Me.Column14.Name = "Column14"
        '
        'Column16
        '
        Me.Column16.HeaderText = "Client Code"
        Me.Column16.Name = "Column16"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "MOD_NO"
        Me.Column5.HeaderText = "Client Acc"
        Me.Column5.Name = "Column5"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "S"
        Me.Column4.HeaderText = "Client Name"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "Location"
        Me.Column2.Name = "Column2"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Corr Bank"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 110
        '
        'Column3
        '
        Me.Column3.HeaderText = "Deposit Type"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 105
        '
        'Column12
        '
        Me.Column12.HeaderText = "Citi Cash Amt"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Citi Check Amt"
        Me.Column13.Name = "Column13"
        '
        'Column15
        '
        Me.Column15.HeaderText = "Ref No"
        Me.Column15.Name = "Column15"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Drawee Bank"
        Me.Column7.Name = "Column7"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Check No"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 110
        '
        'Column10
        '
        Me.Column10.HeaderText = "Amount"
        Me.Column10.Name = "Column10"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Status"
        Me.Column8.Name = "Column8"
        '
        'FrmDepoScheSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 660)
        Me.Controls.Add(Me.chkCitiSpeed)
        Me.Controls.Add(Me.grpSpeed)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDepoScheSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit Schedule Search"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpSpeed.ResumeLayout(False)
        Me.grpSpeed.PerformLayout()
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
    Friend WithEvents txtScheDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtScheDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchCustomer As System.Windows.Forms.Button
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCorrBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnSearchCorrBank As System.Windows.Forms.Button
    Friend WithEvents txtDraweeBankCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCorrBankName As System.Windows.Forms.Label
    Friend WithEvents btnSearchDraweeBank As System.Windows.Forms.Button
    Friend WithEvents lblDraweeBankName As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchLocation As System.Windows.Forms.Button
    Friend WithEvents lblLocationName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCitiCheckAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCitiCashAmt As System.Windows.Forms.TextBox
    Friend WithEvents grpSpeed As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDepoScheCode As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbDepositType As System.Windows.Forms.ComboBox
    Friend WithEvents chkCitiSpeed As System.Windows.Forms.CheckBox
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
