<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptClearClientWiseCharge
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
        Me.grpLocation = New System.Windows.Forms.GroupBox
        Me.cmbValueType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDepositDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.txtDepositDateTo = New System.Windows.Forms.MaskedTextBox
        Me.grpSchedule = New System.Windows.Forms.GroupBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.grpLocation.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.cmbValueType)
        Me.grpLocation.Controls.Add(Me.Label1)
        Me.grpLocation.Location = New System.Drawing.Point(3, 0)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(607, 42)
        Me.grpLocation.TabIndex = 0
        Me.grpLocation.TabStop = False
        '
        'cmbValueType
        '
        Me.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValueType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbValueType.FormattingEnabled = True
        Me.cmbValueType.Location = New System.Drawing.Point(123, 15)
        Me.cmbValueType.Name = "cmbValueType"
        Me.cmbValueType.Size = New System.Drawing.Size(101, 21)
        Me.cmbValueType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Value Type:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 96)
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
        Me.btnClose.Location = New System.Drawing.Point(422, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
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
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(305, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Range To:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'txtDepositDateTo
        '
        Me.txtDepositDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositDateTo.Location = New System.Drawing.Point(422, 14)
        Me.txtDepositDateTo.Mask = "00/00/0000"
        Me.txtDepositDateTo.Name = "txtDepositDateTo"
        Me.txtDepositDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtDepositDateTo.TabIndex = 1
        Me.txtDepositDateTo.ValidatingType = GetType(Date)
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.txtDepositDateTo)
        Me.grpSchedule.Controls.Add(Me.txtDepositDateFrom)
        Me.grpSchedule.Controls.Add(Me.Label8)
        Me.grpSchedule.Controls.Add(Me.Label10)
        Me.grpSchedule.Location = New System.Drawing.Point(3, 48)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 1
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Clearing Date"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 143)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(619, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 11
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
        Me.lblToolStatus.Size = New System.Drawing.Size(502, 17)
        Me.lblToolStatus.Spring = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'FrmRptClearClientWiseCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 165)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.grpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptClearClientWiseCharge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clearing Charge Summary Breakup"
        Me.grpLocation.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmbValueType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDepositDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDepositDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
