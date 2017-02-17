<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptGuaranteedCreditBooking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptGuaranteedCreditBooking))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnReportExcel = New System.Windows.Forms.Button
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEntryDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.txtEntryDateTo = New System.Windows.Forms.MaskedTextBox
        Me.grpEntry = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtScheduleDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtScheduleDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grpClient = New System.Windows.Forms.GroupBox
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.grpSchedule = New System.Windows.Forms.GroupBox
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpEntry.SuspendLayout()
        Me.grpClient.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 175)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(620, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 20
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
        Me.lblToolStatus.Size = New System.Drawing.Size(605, 17)
        Me.lblToolStatus.Spring = True
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(225, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(356, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Visible = False
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(196, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(19, 21)
        Me.Button1.TabIndex = 15
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnReportExcel)
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 128)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 19
        Me.GroupBox7.TabStop = False
        '
        'btnReportExcel
        '
        Me.btnReportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportExcel.Location = New System.Drawing.Point(232, 11)
        Me.btnReportExcel.Name = "btnReportExcel"
        Me.btnReportExcel.Size = New System.Drawing.Size(108, 27)
        Me.btnReportExcel.TabIndex = 0
        Me.btnReportExcel.Text = "Report Excel"
        Me.btnReportExcel.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(100, 10)
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
        Me.btnClose.Location = New System.Drawing.Point(361, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
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
        'txtEntryDateFrom
        '
        Me.txtEntryDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryDateFrom.Location = New System.Drawing.Point(100, 14)
        Me.txtEntryDateFrom.Mask = "00/00/0000"
        Me.txtEntryDateFrom.Name = "txtEntryDateFrom"
        Me.txtEntryDateFrom.Size = New System.Drawing.Size(87, 20)
        Me.txtEntryDateFrom.TabIndex = 0
        Me.txtEntryDateFrom.ValidatingType = GetType(Date)
        '
        'txtEntryDateTo
        '
        Me.txtEntryDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryDateTo.Location = New System.Drawing.Point(375, 14)
        Me.txtEntryDateTo.Mask = "00/00/0000"
        Me.txtEntryDateTo.Name = "txtEntryDateTo"
        Me.txtEntryDateTo.Size = New System.Drawing.Size(87, 20)
        Me.txtEntryDateTo.TabIndex = 1
        Me.txtEntryDateTo.ValidatingType = GetType(Date)
        '
        'grpEntry
        '
        Me.grpEntry.Controls.Add(Me.txtEntryDateTo)
        Me.grpEntry.Controls.Add(Me.txtEntryDateFrom)
        Me.grpEntry.Controls.Add(Me.Label1)
        Me.grpEntry.Controls.Add(Me.Label5)
        Me.grpEntry.Location = New System.Drawing.Point(3, 44)
        Me.grpEntry.Name = "grpEntry"
        Me.grpEntry.Size = New System.Drawing.Size(607, 42)
        Me.grpEntry.TabIndex = 15
        Me.grpEntry.TabStop = False
        Me.grpEntry.Text = "Entry Date"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Range From:"
        '
        'txtScheduleDateTo
        '
        Me.txtScheduleDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDateTo.Location = New System.Drawing.Point(375, 15)
        Me.txtScheduleDateTo.Mask = "00/00/0000"
        Me.txtScheduleDateTo.Name = "txtScheduleDateTo"
        Me.txtScheduleDateTo.Size = New System.Drawing.Size(87, 20)
        Me.txtScheduleDateTo.TabIndex = 1
        Me.txtScheduleDateTo.ValidatingType = GetType(Date)
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
        'txtScheduleDateFrom
        '
        Me.txtScheduleDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDateFrom.Location = New System.Drawing.Point(100, 14)
        Me.txtScheduleDateFrom.Mask = "00/00/0000"
        Me.txtScheduleDateFrom.Name = "txtScheduleDateFrom"
        Me.txtScheduleDateFrom.Size = New System.Drawing.Size(87, 20)
        Me.txtScheduleDateFrom.TabIndex = 0
        Me.txtScheduleDateFrom.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Client Code:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Range From:"
        '
        'grpClient
        '
        Me.grpClient.Controls.Add(Me.Label6)
        Me.grpClient.Controls.Add(Me.Button1)
        Me.grpClient.Controls.Add(Me.txtClientCode)
        Me.grpClient.Controls.Add(Me.Label4)
        Me.grpClient.Location = New System.Drawing.Point(3, 86)
        Me.grpClient.Name = "grpClient"
        Me.grpClient.Size = New System.Drawing.Size(607, 42)
        Me.grpClient.TabIndex = 17
        Me.grpClient.TabStop = False
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(100, 14)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(87, 20)
        Me.txtClientCode.TabIndex = 1
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.txtScheduleDateTo)
        Me.grpSchedule.Controls.Add(Me.txtScheduleDateFrom)
        Me.grpSchedule.Controls.Add(Me.Label8)
        Me.grpSchedule.Controls.Add(Me.Label10)
        Me.grpSchedule.Location = New System.Drawing.Point(3, 2)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 14
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Schedule Date"
        '
        'FrmRptGuaranteedCreditBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 197)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpEntry)
        Me.Controls.Add(Me.grpClient)
        Me.Controls.Add(Me.grpSchedule)
        Me.Name = "FrmRptGuaranteedCreditBooking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guaranteed Credit Booking Report"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.grpEntry.ResumeLayout(False)
        Me.grpEntry.PerformLayout()
        Me.grpClient.ResumeLayout(False)
        Me.grpClient.PerformLayout()
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReportExcel As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEntryDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEntryDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grpEntry As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtScheduleDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtScheduleDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpClient As System.Windows.Forms.GroupBox
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
End Class
