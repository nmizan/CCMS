﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptSpeedDeposit
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
        Me.txtScheduleDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtScheduleDateFrom = New System.Windows.Forms.MaskedTextBox
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
        Me.btnReportExcel = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.grpLocation.SuspendLayout()
        Me.grpClient.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 177)
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
        Me.grpSchedule.Controls.Add(Me.txtScheduleDateTo)
        Me.grpSchedule.Controls.Add(Me.txtScheduleDateFrom)
        Me.grpSchedule.Controls.Add(Me.Label8)
        Me.grpSchedule.Controls.Add(Me.Label10)
        Me.grpSchedule.Location = New System.Drawing.Point(3, 4)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 11
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Schedule Date"
        '
        'txtScheduleDateTo
        '
        Me.txtScheduleDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDateTo.Location = New System.Drawing.Point(362, 14)
        Me.txtScheduleDateTo.Mask = "00/00/0000"
        Me.txtScheduleDateTo.Name = "txtScheduleDateTo"
        Me.txtScheduleDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtScheduleDateTo.TabIndex = 8
        Me.txtScheduleDateTo.ValidatingType = GetType(Date)
        '
        'txtScheduleDateFrom
        '
        Me.txtScheduleDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDateFrom.Location = New System.Drawing.Point(123, 14)
        Me.txtScheduleDateFrom.Mask = "00/00/0000"
        Me.txtScheduleDateFrom.Name = "txtScheduleDateFrom"
        Me.txtScheduleDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtScheduleDateFrom.TabIndex = 7
        Me.txtScheduleDateFrom.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(262, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 20)
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
        Me.grpLocation.Location = New System.Drawing.Point(3, 46)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(607, 42)
        Me.grpLocation.TabIndex = 11
        Me.grpLocation.TabStop = False
        '
        'txtLocationCode
        '
        Me.txtLocationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocationCode.Location = New System.Drawing.Point(123, 14)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.Size = New System.Drawing.Size(112, 20)
        Me.txtLocationCode.TabIndex = 6
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
        Me.grpClient.Location = New System.Drawing.Point(3, 89)
        Me.grpClient.Name = "grpClient"
        Me.grpClient.Size = New System.Drawing.Size(607, 42)
        Me.grpClient.TabIndex = 11
        Me.grpClient.TabStop = False
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(123, 14)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(112, 20)
        Me.txtClientCode.TabIndex = 6
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
        Me.GroupBox7.Controls.Add(Me.btnReportExcel)
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 131)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(123, 10)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(108, 27)
        Me.btnReport.TabIndex = 12
        Me.btnReport.Text = "Generate Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(366, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReportExcel
        '
        Me.btnReportExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportExcel.Location = New System.Drawing.Point(246, 10)
        Me.btnReportExcel.Name = "btnReportExcel"
        Me.btnReportExcel.Size = New System.Drawing.Size(108, 27)
        Me.btnReportExcel.TabIndex = 13
        Me.btnReportExcel.Text = "Report Excel"
        Me.btnReportExcel.UseVisualStyleBackColor = True
        '
        'FrmRptSpeedDeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 199)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpClient)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.grpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptSpeedDeposit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CitiSpeed Deposit Report"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.grpLocation.ResumeLayout(False)
        Me.grpLocation.PerformLayout()
        Me.grpClient.ResumeLayout(False)
        Me.grpClient.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
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
    Friend WithEvents txtScheduleDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtScheduleDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnReportExcel As System.Windows.Forms.Button
End Class