﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPM_Clearing
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
        Me.stsPPM = New System.Windows.Forms.StatusStrip
        Me.tspPPM = New System.Windows.Forms.ToolStripProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnGenPPMRetFile = New System.Windows.Forms.Button
        Me.btnGenPPMFile = New System.Windows.Forms.Button
        Me.dtpPPM = New System.Windows.Forms.DateTimePicker
        Me.bgWorkerPPM_Return = New System.ComponentModel.BackgroundWorker
        Me.bgWorkerPPM_File = New System.ComponentModel.BackgroundWorker
        Me.btnServiceControl = New System.Windows.Forms.Button
        Me.chkAllReturn = New System.Windows.Forms.CheckBox
        Me.chkAllPPM = New System.Windows.Forms.CheckBox
        Me.stsPPM.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsPPM
        '
        Me.stsPPM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspPPM})
        Me.stsPPM.Location = New System.Drawing.Point(0, 106)
        Me.stsPPM.Name = "stsPPM"
        Me.stsPPM.Size = New System.Drawing.Size(408, 22)
        Me.stsPPM.TabIndex = 9
        Me.stsPPM.Text = "StatusStrip1"
        '
        'tspPPM
        '
        Me.tspPPM.Name = "tspPPM"
        Me.tspPPM.Size = New System.Drawing.Size(390, 16)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "File Generation Date:"
        '
        'btnGenPPMRetFile
        '
        Me.btnGenPPMRetFile.Location = New System.Drawing.Point(226, 50)
        Me.btnGenPPMRetFile.Name = "btnGenPPMRetFile"
        Me.btnGenPPMRetFile.Size = New System.Drawing.Size(145, 27)
        Me.btnGenPPMRetFile.TabIndex = 7
        Me.btnGenPPMRetFile.Text = "Generate PPM Return File"
        Me.btnGenPPMRetFile.UseVisualStyleBackColor = True
        '
        'btnGenPPMFile
        '
        Me.btnGenPPMFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenPPMFile.Location = New System.Drawing.Point(37, 50)
        Me.btnGenPPMFile.Name = "btnGenPPMFile"
        Me.btnGenPPMFile.Size = New System.Drawing.Size(145, 27)
        Me.btnGenPPMFile.TabIndex = 6
        Me.btnGenPPMFile.Text = "Generate PPM File"
        Me.btnGenPPMFile.UseVisualStyleBackColor = True
        '
        'dtpPPM
        '
        Me.dtpPPM.Location = New System.Drawing.Point(159, 11)
        Me.dtpPPM.Name = "dtpPPM"
        Me.dtpPPM.Size = New System.Drawing.Size(212, 20)
        Me.dtpPPM.TabIndex = 5
        '
        'bgWorkerPPM_Return
        '
        '
        'bgWorkerPPM_File
        '
        '
        'btnServiceControl
        '
        Me.btnServiceControl.Location = New System.Drawing.Point(135, 31)
        Me.btnServiceControl.Name = "btnServiceControl"
        Me.btnServiceControl.Size = New System.Drawing.Size(145, 27)
        Me.btnServiceControl.TabIndex = 10
        Me.btnServiceControl.Text = "Service Control"
        Me.btnServiceControl.UseVisualStyleBackColor = True
        Me.btnServiceControl.Visible = False
        '
        'chkAllReturn
        '
        Me.chkAllReturn.AutoSize = True
        Me.chkAllReturn.Location = New System.Drawing.Point(227, 84)
        Me.chkAllReturn.Name = "chkAllReturn"
        Me.chkAllReturn.Size = New System.Drawing.Size(72, 17)
        Me.chkAllReturn.TabIndex = 11
        Me.chkAllReturn.Text = "All Return"
        Me.chkAllReturn.UseVisualStyleBackColor = True
        '
        'chkAllPPM
        '
        Me.chkAllPPM.AutoSize = True
        Me.chkAllPPM.Location = New System.Drawing.Point(40, 86)
        Me.chkAllPPM.Name = "chkAllPPM"
        Me.chkAllPPM.Size = New System.Drawing.Size(63, 17)
        Me.chkAllPPM.TabIndex = 12
        Me.chkAllPPM.Text = "All PPM"
        Me.chkAllPPM.UseVisualStyleBackColor = True
        '
        'FrmPPM_Clearing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 128)
        Me.Controls.Add(Me.chkAllPPM)
        Me.Controls.Add(Me.chkAllReturn)
        Me.Controls.Add(Me.btnServiceControl)
        Me.Controls.Add(Me.stsPPM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGenPPMRetFile)
        Me.Controls.Add(Me.btnGenPPMFile)
        Me.Controls.Add(Me.dtpPPM)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPPM_Clearing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PPM Clearing File"
        Me.stsPPM.ResumeLayout(False)
        Me.stsPPM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stsPPM As System.Windows.Forms.StatusStrip
    Friend WithEvents tspPPM As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenPPMRetFile As System.Windows.Forms.Button
    Friend WithEvents btnGenPPMFile As System.Windows.Forms.Button
    Friend WithEvents dtpPPM As System.Windows.Forms.DateTimePicker
    Friend WithEvents bgWorkerPPM_Return As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgWorkerPPM_File As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnServiceControl As System.Windows.Forms.Button
    Friend WithEvents chkAllReturn As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllPPM As System.Windows.Forms.CheckBox
End Class
