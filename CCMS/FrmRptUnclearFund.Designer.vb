<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptUnclearFund
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpSchedule = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grpClient = New System.Windows.Forms.GroupBox
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.rdoDeposit = New System.Windows.Forms.RadioButton
        Me.Group1 = New System.Windows.Forms.GroupBox
        Me.rdoAll = New System.Windows.Forms.RadioButton
        Me.rdoClient = New System.Windows.Forms.RadioButton
        Me.btnReportExcel = New System.Windows.Forms.Button
        Me.txtDepositDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.txtDepositDateTo = New System.Windows.Forms.MaskedTextBox
        Me.StatusStrip1.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.grpClient.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 176)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(619, 22)
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
        Me.lblToolStatus.Size = New System.Drawing.Size(604, 17)
        Me.lblToolStatus.Spring = True
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.txtDepositDateTo)
        Me.grpSchedule.Controls.Add(Me.txtDepositDateFrom)
        Me.grpSchedule.Controls.Add(Me.Label8)
        Me.grpSchedule.Controls.Add(Me.Label10)
        Me.grpSchedule.Location = New System.Drawing.Point(3, 44)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 1
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Date"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(258, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Range To:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Range From:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpClient
        '
        Me.grpClient.Controls.Add(Me.txtClientCode)
        Me.grpClient.Controls.Add(Me.Label4)
        Me.grpClient.Location = New System.Drawing.Point(3, 87)
        Me.grpClient.Name = "grpClient"
        Me.grpClient.Size = New System.Drawing.Size(607, 42)
        Me.grpClient.TabIndex = 2
        Me.grpClient.TabStop = False
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(123, 14)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(112, 20)
        Me.txtClientCode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Client Code:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnReportExcel)
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 129)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(123, 9)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(108, 27)
        Me.btnReport.TabIndex = 0
        Me.btnReport.Text = "Generate Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(375, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'rdoDeposit
        '
        Me.rdoDeposit.AutoSize = True
        Me.rdoDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoDeposit.Location = New System.Drawing.Point(41, 15)
        Me.rdoDeposit.Name = "rdoDeposit"
        Me.rdoDeposit.Size = New System.Drawing.Size(82, 17)
        Me.rdoDeposit.TabIndex = 0
        Me.rdoDeposit.Text = "Date Range"
        Me.rdoDeposit.UseVisualStyleBackColor = True
        '
        'Group1
        '
        Me.Group1.Controls.Add(Me.rdoAll)
        Me.Group1.Controls.Add(Me.rdoClient)
        Me.Group1.Controls.Add(Me.rdoDeposit)
        Me.Group1.Location = New System.Drawing.Point(4, 2)
        Me.Group1.Name = "Group1"
        Me.Group1.Size = New System.Drawing.Size(607, 42)
        Me.Group1.TabIndex = 0
        Me.Group1.TabStop = False
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Checked = True
        Me.rdoAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoAll.Location = New System.Drawing.Point(320, 15)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(35, 17)
        Me.rdoAll.TabIndex = 2
        Me.rdoAll.TabStop = True
        Me.rdoAll.Text = "All"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'rdoClient
        '
        Me.rdoClient.AutoSize = True
        Me.rdoClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoClient.Location = New System.Drawing.Point(213, 15)
        Me.rdoClient.Name = "rdoClient"
        Me.rdoClient.Size = New System.Drawing.Size(50, 17)
        Me.rdoClient.TabIndex = 1
        Me.rdoClient.Text = "Client"
        Me.rdoClient.UseVisualStyleBackColor = True
        '
        'btnReportExcel
        '
        Me.btnReportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportExcel.Location = New System.Drawing.Point(247, 9)
        Me.btnReportExcel.Name = "btnReportExcel"
        Me.btnReportExcel.Size = New System.Drawing.Size(108, 27)
        Me.btnReportExcel.TabIndex = 1
        Me.btnReportExcel.Text = "ReportExcel"
        Me.btnReportExcel.UseVisualStyleBackColor = True
        '
        'txtDepositDateFrom
        '
        Me.txtDepositDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositDateFrom.Location = New System.Drawing.Point(123, 16)
        Me.txtDepositDateFrom.Mask = "00/00/0000"
        Me.txtDepositDateFrom.Name = "txtDepositDateFrom"
        Me.txtDepositDateFrom.Size = New System.Drawing.Size(87, 20)
        Me.txtDepositDateFrom.TabIndex = 0
        Me.txtDepositDateFrom.ValidatingType = GetType(Date)
        '
        'txtDepositDateTo
        '
        Me.txtDepositDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositDateTo.Location = New System.Drawing.Point(375, 14)
        Me.txtDepositDateTo.Mask = "00/00/0000"
        Me.txtDepositDateTo.Name = "txtDepositDateTo"
        Me.txtDepositDateTo.Size = New System.Drawing.Size(87, 20)
        Me.txtDepositDateTo.TabIndex = 1
        Me.txtDepositDateTo.ValidatingType = GetType(Date)
        '
        'FrmRptUnclearFund
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 198)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Group1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpClient)
        Me.Controls.Add(Me.grpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptUnclearFund"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Unclear Fund Report"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.grpClient.ResumeLayout(False)
        Me.grpClient.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpClient As System.Windows.Forms.GroupBox
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents rdoDeposit As System.Windows.Forms.RadioButton
    Friend WithEvents Group1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoClient As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnReportExcel As System.Windows.Forms.Button
    Friend WithEvents txtDepositDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDepositDateFrom As System.Windows.Forms.MaskedTextBox
End Class
