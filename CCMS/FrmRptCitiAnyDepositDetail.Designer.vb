<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCitiAnyDepositDetail
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
        Me.txtDepositDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtDepositDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grpLocation = New System.Windows.Forms.GroupBox
        Me.txtLocationCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpClient = New System.Windows.Forms.GroupBox
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpEntry = New System.Windows.Forms.GroupBox
        Me.txtValueDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtValueDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtBankCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnGenerateExcel = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.grpLocation.SuspendLayout()
        Me.grpClient.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpEntry.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 263)
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
        Me.grpSchedule.Location = New System.Drawing.Point(3, 4)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 0
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Deposit Date"
        '
        'txtDepositDateTo
        '
        Me.txtDepositDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositDateTo.Location = New System.Drawing.Point(375, 14)
        Me.txtDepositDateTo.Mask = "00/00/0000"
        Me.txtDepositDateTo.Name = "txtDepositDateTo"
        Me.txtDepositDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtDepositDateTo.TabIndex = 1
        Me.txtDepositDateTo.ValidatingType = GetType(Date)
        '
        'txtDepositDateFrom
        '
        Me.txtDepositDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositDateFrom.Location = New System.Drawing.Point(123, 14)
        Me.txtDepositDateFrom.Mask = "00/00/0000"
        Me.txtDepositDateFrom.Name = "txtDepositDateFrom"
        Me.txtDepositDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtDepositDateFrom.TabIndex = 0
        Me.txtDepositDateFrom.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(268, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Range To:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Range From:"
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.txtLocationCode)
        Me.grpLocation.Controls.Add(Me.Label2)
        Me.grpLocation.Location = New System.Drawing.Point(3, 88)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(607, 42)
        Me.grpLocation.TabIndex = 2
        Me.grpLocation.TabStop = False
        '
        'txtLocationCode
        '
        Me.txtLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocationCode.Location = New System.Drawing.Point(123, 14)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.Size = New System.Drawing.Size(112, 20)
        Me.txtLocationCode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Location Code:"
        '
        'grpClient
        '
        Me.grpClient.Controls.Add(Me.txtClientCode)
        Me.grpClient.Controls.Add(Me.Label4)
        Me.grpClient.Location = New System.Drawing.Point(3, 130)
        Me.grpClient.Name = "grpClient"
        Me.grpClient.Size = New System.Drawing.Size(607, 42)
        Me.grpClient.TabIndex = 3
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
        Me.Label4.Location = New System.Drawing.Point(7, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Client Code:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnGenerateExcel)
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 215)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(38, 9)
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
        Me.btnClose.Location = New System.Drawing.Point(361, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpEntry
        '
        Me.grpEntry.Controls.Add(Me.txtValueDateTo)
        Me.grpEntry.Controls.Add(Me.txtValueDateFrom)
        Me.grpEntry.Controls.Add(Me.Label1)
        Me.grpEntry.Controls.Add(Me.Label5)
        Me.grpEntry.Location = New System.Drawing.Point(3, 46)
        Me.grpEntry.Name = "grpEntry"
        Me.grpEntry.Size = New System.Drawing.Size(607, 42)
        Me.grpEntry.TabIndex = 1
        Me.grpEntry.TabStop = False
        Me.grpEntry.Text = "Value Date"
        '
        'txtValueDateTo
        '
        Me.txtValueDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueDateTo.Location = New System.Drawing.Point(375, 14)
        Me.txtValueDateTo.Mask = "00/00/0000"
        Me.txtValueDateTo.Name = "txtValueDateTo"
        Me.txtValueDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtValueDateTo.TabIndex = 1
        Me.txtValueDateTo.ValidatingType = GetType(Date)
        '
        'txtValueDateFrom
        '
        Me.txtValueDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueDateFrom.Location = New System.Drawing.Point(123, 14)
        Me.txtValueDateFrom.Mask = "00/00/0000"
        Me.txtValueDateFrom.Name = "txtValueDateFrom"
        Me.txtValueDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtValueDateFrom.TabIndex = 0
        Me.txtValueDateFrom.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(268, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Range To:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Range From:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBankCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtBankCode
        '
        Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBankCode.Location = New System.Drawing.Point(123, 14)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(112, 20)
        Me.txtBankCode.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Bank Code:"
        '
        'btnGenerateExcel
        '
        Me.btnGenerateExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnGenerateExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerateExcel.Location = New System.Drawing.Point(190, 9)
        Me.btnGenerateExcel.Name = "btnGenerateExcel"
        Me.btnGenerateExcel.Size = New System.Drawing.Size(108, 27)
        Me.btnGenerateExcel.TabIndex = 14
        Me.btnGenerateExcel.Text = "Generate Excel"
        Me.btnGenerateExcel.UseVisualStyleBackColor = True
        '
        'FrmRptCitiAnyDepositDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 285)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpClient)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.grpEntry)
        Me.Controls.Add(Me.grpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptCitiAnyDepositDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CitiAnywhere Check Deposit Details Report"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.grpLocation.ResumeLayout(False)
        Me.grpLocation.PerformLayout()
        Me.grpClient.ResumeLayout(False)
        Me.grpClient.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.grpEntry.ResumeLayout(False)
        Me.grpEntry.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpClient As System.Windows.Forms.GroupBox
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpEntry As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDepositDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDepositDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtValueDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtValueDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnGenerateExcel As System.Windows.Forms.Button
End Class
