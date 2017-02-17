<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPMServiceControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPPMServiceControl))
        Me.grpSchedule = New System.Windows.Forms.GroupBox
        Me.rdoHour = New System.Windows.Forms.RadioButton
        Me.rdoTime = New System.Windows.Forms.RadioButton
        Me.lblHour = New System.Windows.Forms.Label
        Me.txtHour = New System.Windows.Forms.TextBox
        Me.dtpTime = New System.Windows.Forms.DateTimePicker
        Me.btnSave = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpSchedule.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSchedule
        '
        Me.grpSchedule.Controls.Add(Me.rdoHour)
        Me.grpSchedule.Controls.Add(Me.rdoTime)
        Me.grpSchedule.Controls.Add(Me.lblHour)
        Me.grpSchedule.Controls.Add(Me.txtHour)
        Me.grpSchedule.Controls.Add(Me.dtpTime)
        Me.grpSchedule.Location = New System.Drawing.Point(12, 12)
        Me.grpSchedule.Name = "grpSchedule"
        Me.grpSchedule.Size = New System.Drawing.Size(344, 87)
        Me.grpSchedule.TabIndex = 12
        Me.grpSchedule.TabStop = False
        Me.grpSchedule.Text = "Generate PPM Files:"
        '
        'rdoHour
        '
        Me.rdoHour.AutoSize = True
        Me.rdoHour.Location = New System.Drawing.Point(93, 19)
        Me.rdoHour.Name = "rdoHour"
        Me.rdoHour.Size = New System.Drawing.Size(80, 17)
        Me.rdoHour.TabIndex = 0
        Me.rdoHour.Text = "After Every:"
        Me.rdoHour.UseVisualStyleBackColor = True
        '
        'rdoTime
        '
        Me.rdoTime.AutoSize = True
        Me.rdoTime.Checked = True
        Me.rdoTime.Location = New System.Drawing.Point(93, 54)
        Me.rdoTime.Name = "rdoTime"
        Me.rdoTime.Size = New System.Drawing.Size(92, 17)
        Me.rdoTime.TabIndex = 1
        Me.rdoTime.TabStop = True
        Me.rdoTime.Text = "Once Daily at:"
        Me.rdoTime.UseVisualStyleBackColor = True
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(265, 23)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(39, 13)
        Me.lblHour.TabIndex = 4
        Me.lblHour.Text = "hour(s)"
        '
        'txtHour
        '
        Me.txtHour.Location = New System.Drawing.Point(191, 20)
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(68, 20)
        Me.txtHour.TabIndex = 2
        Me.txtHour.Text = "0.5"
        '
        'dtpTime
        '
        Me.dtpTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.dtpTime.CustomFormat = "hh:mm tt"
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTime.Location = New System.Drawing.Point(191, 51)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(68, 20)
        Me.dtpTime.TabIndex = 3
        Me.dtpTime.Value = New Date(2015, 9, 21, 18, 30, 0, 0)
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(288, 105)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 27)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 137)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(369, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 14
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
        Me.lblToolStatus.Size = New System.Drawing.Size(354, 17)
        Me.lblToolStatus.Spring = True
        '
        'FrmPPMServiceControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 159)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grpSchedule)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmPPMServiceControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CCMS-PPM Service Control"
        Me.grpSchedule.ResumeLayout(False)
        Me.grpSchedule.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents rdoHour As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTime As System.Windows.Forms.RadioButton
    Friend WithEvents lblHour As System.Windows.Forms.Label
    Friend WithEvents txtHour As System.Windows.Forms.TextBox
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
End Class
