<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetClearDate
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
        Me.txtClearingDate = New System.Windows.Forms.MaskedTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.btnSetDate = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.grpRef.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 97)
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
        Me.grpRef.Controls.Add(Me.txtClearingDate)
        Me.grpRef.Controls.Add(Me.Label10)
        Me.grpRef.Location = New System.Drawing.Point(3, 6)
        Me.grpRef.Name = "grpRef"
        Me.grpRef.Size = New System.Drawing.Size(607, 42)
        Me.grpRef.TabIndex = 11
        Me.grpRef.TabStop = False
        '
        'txtClearingDate
        '
        Me.txtClearingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClearingDate.Location = New System.Drawing.Point(100, 15)
        Me.txtClearingDate.Mask = "00/00/0000"
        Me.txtClearingDate.Name = "txtClearingDate"
        Me.txtClearingDate.Size = New System.Drawing.Size(98, 20)
        Me.txtClearingDate.TabIndex = 6
        Me.txtClearingDate.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Clearing Date:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnSetDate)
        Me.GroupBox7.Controls.Add(Me.btnClose)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 48)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(607, 42)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        '
        'btnSetDate
        '
        Me.btnSetDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSetDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetDate.Location = New System.Drawing.Point(100, 9)
        Me.btnSetDate.Name = "btnSetDate"
        Me.btnSetDate.Size = New System.Drawing.Size(108, 27)
        Me.btnSetDate.TabIndex = 12
        Me.btnSetDate.Text = "Set Clearing Date"
        Me.btnSetDate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(379, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 27)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FrmSetClearDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 119)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grpRef)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSetClearDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Clearing Date"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpRef.ResumeLayout(False)
        Me.grpRef.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpRef As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetDate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtClearingDate As System.Windows.Forms.MaskedTextBox
End Class
