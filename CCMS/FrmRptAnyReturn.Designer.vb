<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptAnyReturn
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
        Me.txtReturnDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtReturnDateFrom = New System.Windows.Forms.MaskedTextBox
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
        Me.txtSlipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtSlipDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnReportExcel = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.grpLocation.SuspendLayout()
        Me.grpClient.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpEntry.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 228)
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
        Me.grpSchedule.Controls.Add(Me.txtReturnDateTo)
        Me.grpSchedule.Controls.Add(Me.txtReturnDateFrom)
        Me.grpSchedule.Controls.Add(Me.Label8)
        Me.grpSchedule.Controls.Add(Me.Label10)
        Me.grpSchedule.Location = New System.Drawing.Point(3, 6)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 0
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Return Date"
        '
        'txtReturnDateTo
        '
        Me.txtReturnDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnDateTo.Location = New System.Drawing.Point(375, 14)
        Me.txtReturnDateTo.Mask = "00/00/0000"
        Me.txtReturnDateTo.Name = "txtReturnDateTo"
        Me.txtReturnDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtReturnDateTo.TabIndex = 1
        Me.txtReturnDateTo.ValidatingType = GetType(Date)
        '
        'txtReturnDateFrom
        '
        Me.txtReturnDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnDateFrom.Location = New System.Drawing.Point(123, 14)
        Me.txtReturnDateFrom.Mask = "00/00/0000"
        Me.txtReturnDateFrom.Name = "txtReturnDateFrom"
        Me.txtReturnDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtReturnDateFrom.TabIndex = 0
        Me.txtReturnDateFrom.ValidatingType = GetType(Date)
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
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.txtLocationCode)
        Me.grpLocation.Controls.Add(Me.Label2)
        Me.grpLocation.Location = New System.Drawing.Point(3, 90)
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
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Location Code:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpClient
        '
        Me.grpClient.Controls.Add(Me.txtClientCode)
        Me.grpClient.Controls.Add(Me.Label4)
        Me.grpClient.Location = New System.Drawing.Point(3, 132)
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
        Me.GroupBox7.Location = New System.Drawing.Point(3, 174)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(100, 9)
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
        Me.btnClose.Location = New System.Drawing.Point(398, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpEntry
        '
        Me.grpEntry.Controls.Add(Me.txtSlipDateTo)
        Me.grpEntry.Controls.Add(Me.txtSlipDateFrom)
        Me.grpEntry.Controls.Add(Me.Label1)
        Me.grpEntry.Controls.Add(Me.Label5)
        Me.grpEntry.Location = New System.Drawing.Point(3, 48)
        Me.grpEntry.Name = "grpEntry"
        Me.grpEntry.Size = New System.Drawing.Size(607, 42)
        Me.grpEntry.TabIndex = 1
        Me.grpEntry.TabStop = False
        Me.grpEntry.Text = "Deposit Date"
        '
        'txtSlipDateTo
        '
        Me.txtSlipDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSlipDateTo.Location = New System.Drawing.Point(375, 14)
        Me.txtSlipDateTo.Mask = "00/00/0000"
        Me.txtSlipDateTo.Name = "txtSlipDateTo"
        Me.txtSlipDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtSlipDateTo.TabIndex = 1
        Me.txtSlipDateTo.ValidatingType = GetType(Date)
        '
        'txtSlipDateFrom
        '
        Me.txtSlipDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSlipDateFrom.Location = New System.Drawing.Point(123, 14)
        Me.txtSlipDateFrom.Mask = "00/00/0000"
        Me.txtSlipDateFrom.Name = "txtSlipDateFrom"
        Me.txtSlipDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtSlipDateFrom.TabIndex = 0
        Me.txtSlipDateFrom.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(258, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Range To:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Range From:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnReportExcel
        '
        Me.btnReportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportExcel.Location = New System.Drawing.Point(248, 9)
        Me.btnReportExcel.Name = "btnReportExcel"
        Me.btnReportExcel.Size = New System.Drawing.Size(108, 27)
        Me.btnReportExcel.TabIndex = 3
        Me.btnReportExcel.Text = "Report Excel"
        Me.btnReportExcel.UseVisualStyleBackColor = True
        '
        'FrmRptAnyReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 250)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpClient)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.grpEntry)
        Me.Controls.Add(Me.grpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptAnyReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CitiAnywhere Return Report"
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
    Friend WithEvents txtReturnDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtReturnDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSlipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSlipDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnReportExcel As System.Windows.Forms.Button
End Class
