﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPDCSumm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPDCSumm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbEntryLocation = New System.Windows.Forms.ComboBox
        Me.dtpEntryDate = New System.Windows.Forms.DateTimePicker
        Me.btnAuthorize = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExport = New System.Windows.Forms.Button
        Me.rdoUnauthorized = New System.Windows.Forms.RadioButton
        Me.rdoAuthorized = New System.Windows.Forms.RadioButton
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkShowAll = New System.Windows.Forms.CheckBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnDetail = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Column15 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEntryLocation)
        Me.GroupBox1.Controls.Add(Me.dtpEntryDate)
        Me.GroupBox1.Controls.Add(Me.btnAuthorize)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Controls.Add(Me.rdoUnauthorized)
        Me.GroupBox1.Controls.Add(Me.rdoAuthorized)
        Me.GroupBox1.Controls.Add(Me.chkAll)
        Me.GroupBox1.Controls.Add(Me.dgView)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(975, 626)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbEntryLocation
        '
        Me.cmbEntryLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntryLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEntryLocation.FormattingEnabled = True
        Me.cmbEntryLocation.Location = New System.Drawing.Point(162, 14)
        Me.cmbEntryLocation.Name = "cmbEntryLocation"
        Me.cmbEntryLocation.Size = New System.Drawing.Size(158, 21)
        Me.cmbEntryLocation.TabIndex = 16
        '
        'dtpEntryDate
        '
        Me.dtpEntryDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEntryDate.Enabled = False
        Me.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEntryDate.Location = New System.Drawing.Point(510, 16)
        Me.dtpEntryDate.Name = "dtpEntryDate"
        Me.dtpEntryDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpEntryDate.TabIndex = 15
        '
        'btnAuthorize
        '
        Me.btnAuthorize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnAuthorize.Image = CType(resources.GetObject("btnAuthorize.Image"), System.Drawing.Image)
        Me.btnAuthorize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAuthorize.Location = New System.Drawing.Point(776, 11)
        Me.btnAuthorize.Name = "btnAuthorize"
        Me.btnAuthorize.Size = New System.Drawing.Size(77, 27)
        Me.btnAuthorize.TabIndex = 6
        Me.btnAuthorize.Text = "Authorize"
        Me.btnAuthorize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAuthorize.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(77, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Entry Location:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(431, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Entry Date:"
        '
        'btnExport
        '
        Me.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(877, 11)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(77, 27)
        Me.btnExport.TabIndex = 10
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'rdoUnauthorized
        '
        Me.rdoUnauthorized.AutoSize = True
        Me.rdoUnauthorized.Checked = True
        Me.rdoUnauthorized.Location = New System.Drawing.Point(671, 16)
        Me.rdoUnauthorized.Name = "rdoUnauthorized"
        Me.rdoUnauthorized.Size = New System.Drawing.Size(88, 17)
        Me.rdoUnauthorized.TabIndex = 7
        Me.rdoUnauthorized.TabStop = True
        Me.rdoUnauthorized.Text = "Unauthorized"
        Me.rdoUnauthorized.UseVisualStyleBackColor = True
        '
        'rdoAuthorized
        '
        Me.rdoAuthorized.AutoSize = True
        Me.rdoAuthorized.Location = New System.Drawing.Point(338, 16)
        Me.rdoAuthorized.Name = "rdoAuthorized"
        Me.rdoAuthorized.Size = New System.Drawing.Size(75, 17)
        Me.rdoAuthorized.TabIndex = 9
        Me.rdoAuthorized.Text = "Authorized"
        Me.rdoAuthorized.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(25, 17)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(37, 17)
        Me.chkAll.TabIndex = 6
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.dgView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column5, Me.Column4, Me.Column9, Me.Column2, Me.Column3, Me.Column1, Me.Column6, Me.Column8, Me.Column7, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14})
        Me.dgView.Location = New System.Drawing.Point(6, 42)
        Me.dgView.MultiSelect = False
        Me.dgView.Name = "dgView"
        Me.dgView.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.dgView.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgView.Size = New System.Drawing.Size(963, 578)
        Me.dgView.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 683)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(981, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(966, 17)
        Me.lblToolStatus.Spring = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkShowAll)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnNew)
        Me.GroupBox2.Controls.Add(Me.btnDetail)
        Me.GroupBox2.Controls.Add(Me.btnRefresh)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(981, 48)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'chkShowAll
        '
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(245, 20)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkShowAll.TabIndex = 3
        Me.chkShowAll.Text = "Show All"
        Me.chkShowAll.UseVisualStyleBackColor = True
        Me.chkShowAll.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(925, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(50, 27)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(6, 13)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(68, 27)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnDetail
        '
        Me.btnDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnDetail.Image = CType(resources.GetObject("btnDetail.Image"), System.Drawing.Image)
        Me.btnDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetail.Location = New System.Drawing.Point(80, 13)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(68, 27)
        Me.btnDetail.TabIndex = 1
        Me.btnDetail.Text = "Detail"
        Me.btnDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(154, 13)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(68, 27)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Column15
        '
        Me.Column15.HeaderText = ""
        Me.Column15.Name = "Column15"
        Me.Column15.Visible = False
        Me.Column15.Width = 50
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "MOD_NO"
        Me.Column5.HeaderText = "Mod No"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "S"
        Me.Column4.HeaderText = "S"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.Width = 25
        '
        'Column9
        '
        Me.Column9.HeaderText = "MID"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "DS Code"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Total Check No"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 105
        '
        'Column1
        '
        Me.Column1.HeaderText = "Total Check Amt"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 110
        '
        'Column6
        '
        Me.Column6.HeaderText = "Clearing Date"
        Me.Column6.Name = "Column6"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Entry Loc Code"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Entry Location"
        Me.Column7.Name = "Column7"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Input By"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Input Date"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Input Datetime"
        Me.Column12.Name = "Column12"
        Me.Column12.Visible = False
        '
        'Column13
        '
        Me.Column13.HeaderText = "Auth By"
        Me.Column13.Name = "Column13"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Auth Date"
        Me.Column14.Name = "Column14"
        '
        'FrmPDCSumm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 705)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPDCSumm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDC Check - Summary"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents chkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnAuthorize As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents rdoUnauthorized As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAuthorized As System.Windows.Forms.RadioButton
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpEntryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbEntryLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
