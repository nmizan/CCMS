<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptAnyReminder
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
        Me.grpRef = New System.Windows.Forms.GroupBox
        Me.txtDaysTo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDaysFrom = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNonzoneRefFrom = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtScheduleDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtScheduleDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnReport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNonzoneRefTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.btnReminderHistory = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.grpRef.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 239)
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
        'grpRef
        '
        Me.grpRef.Controls.Add(Me.btnReport)
        Me.grpRef.Controls.Add(Me.Label5)
        Me.grpRef.Controls.Add(Me.txtDaysTo)
        Me.grpRef.Controls.Add(Me.Label6)
        Me.grpRef.Controls.Add(Me.Label3)
        Me.grpRef.Controls.Add(Me.txtDaysFrom)
        Me.grpRef.Controls.Add(Me.Label2)
        Me.grpRef.Controls.Add(Me.txtNonzoneRefTo)
        Me.grpRef.Controls.Add(Me.txtNonzoneRefFrom)
        Me.grpRef.Controls.Add(Me.Label1)
        Me.grpRef.Controls.Add(Me.txtClientCode)
        Me.grpRef.Controls.Add(Me.Label4)
        Me.grpRef.Controls.Add(Me.txtScheduleDateTo)
        Me.grpRef.Controls.Add(Me.txtScheduleDateFrom)
        Me.grpRef.Controls.Add(Me.Label10)
        Me.grpRef.Location = New System.Drawing.Point(3, 5)
        Me.grpRef.Name = "grpRef"
        Me.grpRef.Size = New System.Drawing.Size(607, 143)
        Me.grpRef.TabIndex = 0
        Me.grpRef.TabStop = False
        Me.grpRef.Text = "Reminder Report"
        '
        'txtDaysTo
        '
        Me.txtDaysTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDaysTo.Location = New System.Drawing.Point(332, 37)
        Me.txtDaysTo.Name = "txtDaysTo"
        Me.txtDaysTo.Size = New System.Drawing.Size(112, 20)
        Me.txtDaysTo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(274, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "To:"
        '
        'txtDaysFrom
        '
        Me.txtDaysFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDaysFrom.Location = New System.Drawing.Point(135, 37)
        Me.txtDaysFrom.Name = "txtDaysFrom"
        Me.txtDaysFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtDaysFrom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 20)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Outstanding Days From:"
        '
        'txtNonzoneRefFrom
        '
        Me.txtNonzoneRefFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNonzoneRefFrom.Location = New System.Drawing.Point(135, 83)
        Me.txtNonzoneRefFrom.Name = "txtNonzoneRefFrom"
        Me.txtNonzoneRefFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtNonzoneRefFrom.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Citibank Ref From:"
        '
        'txtClientCode
        '
        Me.txtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClientCode.Location = New System.Drawing.Point(135, 60)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(112, 20)
        Me.txtClientCode.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Client Code:"
        '
        'txtScheduleDateTo
        '
        Me.txtScheduleDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDateTo.Location = New System.Drawing.Point(332, 14)
        Me.txtScheduleDateTo.Mask = "00/00/0000"
        Me.txtScheduleDateTo.Name = "txtScheduleDateTo"
        Me.txtScheduleDateTo.Size = New System.Drawing.Size(112, 20)
        Me.txtScheduleDateTo.TabIndex = 1
        Me.txtScheduleDateTo.ValidatingType = GetType(Date)
        '
        'txtScheduleDateFrom
        '
        Me.txtScheduleDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScheduleDateFrom.Location = New System.Drawing.Point(135, 14)
        Me.txtScheduleDateFrom.Mask = "00/00/0000"
        Me.txtScheduleDateFrom.Name = "txtScheduleDateFrom"
        Me.txtScheduleDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.txtScheduleDateFrom.TabIndex = 0
        Me.txtScheduleDateFrom.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Reminder Date From:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtCheckNo)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.btnReminderHistory)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 154)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(444, 76)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Reminder History Report"
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(135, 109)
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
        Me.btnClose.Location = New System.Drawing.Point(485, 181)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(274, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "To:"
        '
        'txtNonzoneRefTo
        '
        Me.txtNonzoneRefTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNonzoneRefTo.Location = New System.Drawing.Point(332, 83)
        Me.txtNonzoneRefTo.Name = "txtNonzoneRefTo"
        Me.txtNonzoneRefTo.Size = New System.Drawing.Size(112, 20)
        Me.txtNonzoneRefTo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(274, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "To:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Check No:"
        '
        'txtCheckNo
        '
        Me.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNo.Location = New System.Drawing.Point(135, 14)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(112, 20)
        Me.txtCheckNo.TabIndex = 4
        '
        'btnReminderHistory
        '
        Me.btnReminderHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnReminderHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReminderHistory.Location = New System.Drawing.Point(135, 40)
        Me.btnReminderHistory.Name = "btnReminderHistory"
        Me.btnReminderHistory.Size = New System.Drawing.Size(108, 27)
        Me.btnReminderHistory.TabIndex = 0
        Me.btnReminderHistory.Text = "Reminder History"
        Me.btnReminderHistory.UseVisualStyleBackColor = True
        '
        'FrmRptAnyReminder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 261)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpRef)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptAnyReminder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CitiAnywhere Reminder Report"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpRef.ResumeLayout(False)
        Me.grpRef.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpRef As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtScheduleDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDaysTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDaysFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNonzoneRefFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtScheduleDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNonzoneRefTo As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnReminderHistory As System.Windows.Forms.Button
End Class
