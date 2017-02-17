<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptMonthBillCashCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptMonthBillCashCheck))
        Me.grpRef = New System.Windows.Forms.GroupBox
        Me.dtpScheduleTo = New System.Windows.Forms.DateTimePicker
        Me.dtpScheduleFrom = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grpLocation = New System.Windows.Forms.GroupBox
        Me.btnSearchClient = New System.Windows.Forms.Button
        Me.txtAccName = New System.Windows.Forms.TextBox
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnProcessBill = New System.Windows.Forms.Button
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.grpRef.SuspendLayout()
        Me.grpLocation.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRef
        '
        Me.grpRef.Controls.Add(Me.dtpScheduleTo)
        Me.grpRef.Controls.Add(Me.dtpScheduleFrom)
        Me.grpRef.Controls.Add(Me.Label8)
        Me.grpRef.Controls.Add(Me.Label10)
        Me.grpRef.Location = New System.Drawing.Point(3, 9)
        Me.grpRef.Name = "grpRef"
        Me.grpRef.Size = New System.Drawing.Size(607, 42)
        Me.grpRef.TabIndex = 11
        Me.grpRef.TabStop = False
        Me.grpRef.Text = "Schedule Date"
        '
        'dtpScheduleTo
        '
        Me.dtpScheduleTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpScheduleTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpScheduleTo.Location = New System.Drawing.Point(374, 13)
        Me.dtpScheduleTo.Name = "dtpScheduleTo"
        Me.dtpScheduleTo.Size = New System.Drawing.Size(101, 20)
        Me.dtpScheduleTo.TabIndex = 8
        '
        'dtpScheduleFrom
        '
        Me.dtpScheduleFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpScheduleFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpScheduleFrom.Location = New System.Drawing.Point(100, 13)
        Me.dtpScheduleFrom.Name = "dtpScheduleFrom"
        Me.dtpScheduleFrom.Size = New System.Drawing.Size(101, 20)
        Me.dtpScheduleFrom.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(258, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Ending Date:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Starting Date:"
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.btnSearchClient)
        Me.grpLocation.Controls.Add(Me.txtAccName)
        Me.grpLocation.Controls.Add(Me.txtClientCode)
        Me.grpLocation.Controls.Add(Me.Label2)
        Me.grpLocation.Location = New System.Drawing.Point(3, 52)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(607, 42)
        Me.grpLocation.TabIndex = 11
        Me.grpLocation.TabStop = False
        '
        'btnSearchClient
        '
        Me.btnSearchClient.FlatAppearance.BorderSize = 0
        Me.btnSearchClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchClient.Image = CType(resources.GetObject("btnSearchClient.Image"), System.Drawing.Image)
        Me.btnSearchClient.Location = New System.Drawing.Point(196, 13)
        Me.btnSearchClient.Name = "btnSearchClient"
        Me.btnSearchClient.Size = New System.Drawing.Size(19, 21)
        Me.btnSearchClient.TabIndex = 15
        Me.btnSearchClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchClient.UseVisualStyleBackColor = True
        '
        'txtAccName
        '
        Me.txtAccName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccName.Location = New System.Drawing.Point(225, 14)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.ReadOnly = True
        Me.txtAccName.Size = New System.Drawing.Size(356, 20)
        Me.txtAccName.TabIndex = 15
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(100, 14)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(87, 20)
        Me.txtClientCode.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Client Code:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnProcessBill)
        Me.GroupBox7.Controls.Add(Me.btnReport)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 94)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        '
        'btnProcessBill
        '
        Me.btnProcessBill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnProcessBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcessBill.Location = New System.Drawing.Point(100, 9)
        Me.btnProcessBill.Name = "btnProcessBill"
        Me.btnProcessBill.Size = New System.Drawing.Size(108, 27)
        Me.btnProcessBill.TabIndex = 13
        Me.btnProcessBill.Text = "Bill Process"
        Me.btnProcessBill.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(261, 10)
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
        Me.btnClose.Location = New System.Drawing.Point(439, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 141)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(619, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 12
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
        'FrmRptMonthBillCashCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 163)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.grpRef)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptMonthBillCashCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monthly Bill for Cash Management Service"
        Me.grpRef.ResumeLayout(False)
        Me.grpLocation.ResumeLayout(False)
        Me.grpLocation.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpRef As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents txtAccName As System.Windows.Forms.TextBox
    Friend WithEvents dtpScheduleTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpScheduleFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnProcessBill As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
End Class
