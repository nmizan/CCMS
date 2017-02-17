<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCitiCheckSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCitiCheckSearch))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtValueDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValueDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCitiBankRef = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtDraweeBankCode = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDraweeBranchCode = New System.Windows.Forms.TextBox
        Me.lblDraweeBankName = New System.Windows.Forms.Label
        Me.lblDraweeBranchName = New System.Windows.Forms.Label
        Me.txtDepoCode = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDLocationCode = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.lblDLocationName = New System.Windows.Forms.Label
        Me.lblAccName = New System.Windows.Forms.Label
        Me.txtSlipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSlipDateFrom = New System.Windows.Forms.MaskedTextBox
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
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.GroupBox1.TabIndex = 1
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
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column11, Me.Column5, Me.Column4, Me.Column2, Me.Column12, Me.Column13, Me.Column9, Me.Column10, Me.Column3, Me.Column1, Me.Column7, Me.Column14, Me.Column15, Me.Column8})
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
        Me.GroupBox2.Controls.Add(Me.txtValueDateTo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtValueDateFrom)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCitiBankRef)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtCheckNumber)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtDraweeBankCode)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtDraweeBranchCode)
        Me.GroupBox2.Controls.Add(Me.lblDraweeBankName)
        Me.GroupBox2.Controls.Add(Me.lblDraweeBranchName)
        Me.GroupBox2.Controls.Add(Me.txtDepoCode)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDLocationCode)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtClientCode)
        Me.GroupBox2.Controls.Add(Me.lblDLocationName)
        Me.GroupBox2.Controls.Add(Me.lblAccName)
        Me.GroupBox2.Controls.Add(Me.txtSlipDateTo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtSlipDateFrom)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(993, 189)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtValueDateTo
        '
        Me.txtValueDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueDateTo.Location = New System.Drawing.Point(366, 38)
        Me.txtValueDateTo.Mask = "00/00/0000"
        Me.txtValueDateTo.Name = "txtValueDateTo"
        Me.txtValueDateTo.Size = New System.Drawing.Size(98, 20)
        Me.txtValueDateTo.TabIndex = 3
        Me.txtValueDateTo.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(263, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Value Date To:"
        '
        'txtValueDateFrom
        '
        Me.txtValueDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueDateFrom.Location = New System.Drawing.Point(136, 38)
        Me.txtValueDateFrom.Mask = "00/00/0000"
        Me.txtValueDateFrom.Name = "txtValueDateFrom"
        Me.txtValueDateFrom.Size = New System.Drawing.Size(98, 20)
        Me.txtValueDateFrom.TabIndex = 2
        Me.txtValueDateFrom.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Value Date From:"
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(660, 156)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 27)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(740, 63)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(98, 20)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Location = New System.Drawing.Point(843, 61)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(98, 20)
        Me.txtAmount.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(499, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Citibank Ref:"
        '
        'txtCitiBankRef
        '
        Me.txtCitiBankRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitiBankRef.Location = New System.Drawing.Point(613, 85)
        Me.txtCitiBankRef.Name = "txtCitiBankRef"
        Me.txtCitiBankRef.Size = New System.Drawing.Size(98, 20)
        Me.txtCitiBankRef.TabIndex = 14
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(499, 63)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 20)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "Check No:"
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(613, 60)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(98, 20)
        Me.txtCheckNumber.TabIndex = 13
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(22, 140)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Drawee Bank:"
        '
        'txtDraweeBankCode
        '
        Me.txtDraweeBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeBankCode.Location = New System.Drawing.Point(136, 137)
        Me.txtDraweeBankCode.Name = "txtDraweeBankCode"
        Me.txtDraweeBankCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeBankCode.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(22, 163)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 20)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "Drawee Branch:"
        '
        'txtDraweeBranchCode
        '
        Me.txtDraweeBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDraweeBranchCode.Location = New System.Drawing.Point(136, 161)
        Me.txtDraweeBranchCode.Name = "txtDraweeBranchCode"
        Me.txtDraweeBranchCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDraweeBranchCode.TabIndex = 11
        '
        'lblDraweeBankName
        '
        Me.lblDraweeBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDraweeBankName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraweeBankName.Location = New System.Drawing.Point(240, 138)
        Me.lblDraweeBankName.Name = "lblDraweeBankName"
        Me.lblDraweeBankName.Size = New System.Drawing.Size(224, 20)
        Me.lblDraweeBankName.TabIndex = 35
        '
        'lblDraweeBranchName
        '
        Me.lblDraweeBranchName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDraweeBranchName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDraweeBranchName.Location = New System.Drawing.Point(240, 162)
        Me.lblDraweeBranchName.Name = "lblDraweeBranchName"
        Me.lblDraweeBranchName.Size = New System.Drawing.Size(224, 20)
        Me.lblDraweeBranchName.TabIndex = 34
        '
        'txtDepoCode
        '
        Me.txtDepoCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepoCode.Location = New System.Drawing.Point(136, 113)
        Me.txtDepoCode.Name = "txtDepoCode"
        Me.txtDepoCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDepoCode.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(22, 114)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Deposit Slip No:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Deposit Location:"
        '
        'txtDLocationCode
        '
        Me.txtDLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDLocationCode.Location = New System.Drawing.Point(136, 61)
        Me.txtDLocationCode.Name = "txtDLocationCode"
        Me.txtDLocationCode.Size = New System.Drawing.Size(98, 20)
        Me.txtDLocationCode.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 20)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Client Code:"
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(136, 88)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(98, 20)
        Me.txtClientCode.TabIndex = 6
        '
        'lblDLocationName
        '
        Me.lblDLocationName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDLocationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDLocationName.Location = New System.Drawing.Point(240, 62)
        Me.lblDLocationName.Name = "lblDLocationName"
        Me.lblDLocationName.Size = New System.Drawing.Size(224, 20)
        Me.lblDLocationName.TabIndex = 25
        '
        'lblAccName
        '
        Me.lblAccName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAccName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(240, 89)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(224, 20)
        Me.lblAccName.TabIndex = 25
        '
        'txtSlipDateTo
        '
        Me.txtSlipDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSlipDateTo.Location = New System.Drawing.Point(366, 14)
        Me.txtSlipDateTo.Mask = "00/00/0000"
        Me.txtSlipDateTo.Name = "txtSlipDateTo"
        Me.txtSlipDateTo.Size = New System.Drawing.Size(98, 20)
        Me.txtSlipDateTo.TabIndex = 1
        Me.txtSlipDateTo.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(263, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Depo. Slip Date To:"
        '
        'txtSlipDateFrom
        '
        Me.txtSlipDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSlipDateFrom.Location = New System.Drawing.Point(136, 14)
        Me.txtSlipDateFrom.Mask = "00/00/0000"
        Me.txtSlipDateFrom.Name = "txtSlipDateFrom"
        Me.txtSlipDateFrom.Size = New System.Drawing.Size(98, 20)
        Me.txtSlipDateFrom.TabIndex = 0
        Me.txtSlipDateFrom.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Depo. Slip Date From:"
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
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Deposit Slip"
        Me.Column6.Name = "Column6"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Client Code"
        Me.Column11.Name = "Column11"
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
        Me.Column2.HeaderText = "Depo Location"
        Me.Column2.Name = "Column2"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Deposit Date"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Value Date"
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
        Me.Column3.HeaderText = "Check Type"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 105
        '
        'Column1
        '
        Me.Column1.HeaderText = "Drawer Acc"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 110
        '
        'Column7
        '
        Me.Column7.HeaderText = "Drawee Bank"
        Me.Column7.Name = "Column7"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Drawee Branch"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "Citibank No"
        Me.Column15.Name = "Column15"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Status"
        Me.Column8.Name = "Column8"
        '
        'FrmCitiCheckSearch
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
        Me.Name = "FrmCitiCheckSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Citi Anywhere Check Search"
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
    Friend WithEvents txtSlipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSlipDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents txtDepoCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDraweeBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDraweeBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDraweeBankName As System.Windows.Forms.Label
    Friend WithEvents lblDraweeBranchName As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtValueDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValueDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCitiBankRef As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDLocationName As System.Windows.Forms.Label
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
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
