<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptDepositBreak2
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.Group1 = New System.Windows.Forms.GroupBox
        Me.txtDepositTo = New System.Windows.Forms.MaskedTextBox
        Me.txtDepositFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnReport = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.grpSchedule = New System.Windows.Forms.GroupBox
        Me.txtCollectTo = New System.Windows.Forms.MaskedTextBox
        Me.txtCollecFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbDepositType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnGenerateExcel = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpSchedule.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 207)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(616, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 17
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
        Me.lblToolStatus.Size = New System.Drawing.Size(601, 17)
        Me.lblToolStatus.Spring = True
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(431, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Group1
        '
        Me.Group1.Controls.Add(Me.txtDepositTo)
        Me.Group1.Controls.Add(Me.txtDepositFrom)
        Me.Group1.Controls.Add(Me.Label1)
        Me.Group1.Controls.Add(Me.Label2)
        Me.Group1.Location = New System.Drawing.Point(4, 6)
        Me.Group1.Name = "Group1"
        Me.Group1.Size = New System.Drawing.Size(607, 42)
        Me.Group1.TabIndex = 16
        Me.Group1.TabStop = False
        Me.Group1.Text = "Deposit Date"
        '
        'txtDepositTo
        '
        Me.txtDepositTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositTo.Location = New System.Drawing.Point(430, 15)
        Me.txtDepositTo.Mask = "00/00/0000"
        Me.txtDepositTo.Name = "txtDepositTo"
        Me.txtDepositTo.Size = New System.Drawing.Size(112, 20)
        Me.txtDepositTo.TabIndex = 7
        Me.txtDepositTo.ValidatingType = GetType(Date)
        '
        'txtDepositFrom
        '
        Me.txtDepositFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositFrom.Location = New System.Drawing.Point(134, 15)
        Me.txtDepositFrom.Mask = "00/00/0000"
        Me.txtDepositFrom.Name = "txtDepositFrom"
        Me.txtDepositFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtDepositFrom.TabIndex = 6
        Me.txtDepositFrom.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(356, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Range To:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Range From:"
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(104, 9)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(108, 27)
        Me.btnReport.TabIndex = 12
        Me.btnReport.Text = "Generate Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnGenerateExcel)
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 158)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 14
        Me.GroupBox7.TabStop = False
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.txtCollectTo)
        Me.grpSchedule.Controls.Add(Me.txtCollecFrom)
        Me.grpSchedule.Controls.Add(Me.Label8)
        Me.grpSchedule.Controls.Add(Me.Label10)
        Me.grpSchedule.Location = New System.Drawing.Point(3, 67)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(607, 42)
        Me.grpSchedule.TabIndex = 15
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Collection Date"
        '
        'txtCollectTo
        '
        Me.txtCollectTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCollectTo.Location = New System.Drawing.Point(432, 14)
        Me.txtCollectTo.Mask = "00/00/0000"
        Me.txtCollectTo.Name = "txtCollectTo"
        Me.txtCollectTo.Size = New System.Drawing.Size(112, 20)
        Me.txtCollectTo.TabIndex = 7
        Me.txtCollectTo.ValidatingType = GetType(Date)
        '
        'txtCollecFrom
        '
        Me.txtCollecFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCollecFrom.Location = New System.Drawing.Point(134, 15)
        Me.txtCollecFrom.Mask = "00/00/0000"
        Me.txtCollecFrom.Name = "txtCollecFrom"
        Me.txtCollecFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtCollecFrom.TabIndex = 6
        Me.txtCollecFrom.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(358, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 20)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Range To:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(48, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Range From:"
        '
        'cmbDepositType
        '
        Me.cmbDepositType.FormattingEnabled = True
        Me.cmbDepositType.Items.AddRange(New Object() {"Cash", "Check"})
        Me.cmbDepositType.Location = New System.Drawing.Point(132, 14)
        Me.cmbDepositType.Name = "cmbDepositType"
        Me.cmbDepositType.Size = New System.Drawing.Size(121, 21)
        Me.cmbDepositType.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Deposit Type:"
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Collection Received", "Collection Not Received"})
        Me.cmbStatus.Location = New System.Drawing.Point(430, 13)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(146, 21)
        Me.cmbStatus.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(355, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Status :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Controls.Add(Me.cmbDepositType)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'btnGenerateExcel
        '
        Me.btnGenerateExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnGenerateExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerateExcel.Location = New System.Drawing.Point(265, 9)
        Me.btnGenerateExcel.Name = "btnGenerateExcel"
        Me.btnGenerateExcel.Size = New System.Drawing.Size(108, 27)
        Me.btnGenerateExcel.TabIndex = 13
        Me.btnGenerateExcel.Text = "Generate Excel"
        Me.btnGenerateExcel.UseVisualStyleBackColor = True
        '
        'FrmRptDepositBreak2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 229)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Group1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmRptDepositBreak2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit Break Report"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Group1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents txtDepositTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDepositFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCollectTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCollecFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbDepositType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerateExcel As System.Windows.Forms.Button
End Class
