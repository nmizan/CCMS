<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClearRetImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClearRetImport))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtClearingDate = New System.Windows.Forms.MaskedTextBox
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnProcess = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtFolderPath = New System.Windows.Forms.TextBox
        Me.btnSetFolder = New System.Windows.Forms.Button
        Me.opdRetFile = New System.Windows.Forms.OpenFileDialog
        Me.fbdRetFile = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnClearMismatchData = New System.Windows.Forms.Button
        Me.btnReportMismatch = New System.Windows.Forms.Button
        Me.lblTotalMismatch = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblTotRecNo = New System.Windows.Forms.Label
        Me.lblFaileFileNo = New System.Windows.Forms.Label
        Me.lblTotFile = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFileImpStatus = New System.Windows.Forms.TextBox
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus, Me.ProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 371)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(708, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 10
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
        Me.lblToolStatus.Size = New System.Drawing.Size(591, 17)
        Me.lblToolStatus.Spring = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'btnExit
        '
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(602, 15)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(68, 27)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Clearing Date:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtClearingDate)
        Me.GroupBox3.Controls.Add(Me.txtFilename)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.btnBrowse)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(695, 51)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'txtClearingDate
        '
        Me.txtClearingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClearingDate.Location = New System.Drawing.Point(109, 17)
        Me.txtClearingDate.Mask = "00/00/0000"
        Me.txtClearingDate.Name = "txtClearingDate"
        Me.txtClearingDate.Size = New System.Drawing.Size(98, 20)
        Me.txtClearingDate.TabIndex = 6
        Me.txtClearingDate.ValidatingType = GetType(Date)
        '
        'txtFilename
        '
        Me.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilename.Location = New System.Drawing.Point(274, 17)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(208, 20)
        Me.txtFilename.TabIndex = 1
        Me.txtFilename.Visible = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(488, 13)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(145, 27)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        Me.btnBrowse.Visible = False
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(536, 45)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(145, 27)
        Me.btnProcess.TabIndex = 0
        Me.btnProcess.Text = "Transfer Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 314)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(695, 51)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFolderPath)
        Me.GroupBox2.Controls.Add(Me.btnProcess)
        Me.GroupBox2.Controls.Add(Me.btnSetFolder)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(695, 83)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Return File Location"
        '
        'txtFolderPath
        '
        Me.txtFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolderPath.Location = New System.Drawing.Point(10, 19)
        Me.txtFolderPath.Name = "txtFolderPath"
        Me.txtFolderPath.Size = New System.Drawing.Size(671, 20)
        Me.txtFolderPath.TabIndex = 2
        '
        'btnSetFolder
        '
        Me.btnSetFolder.Location = New System.Drawing.Point(365, 45)
        Me.btnSetFolder.Name = "btnSetFolder"
        Me.btnSetFolder.Size = New System.Drawing.Size(145, 27)
        Me.btnSetFolder.TabIndex = 0
        Me.btnSetFolder.Text = "Set Folder"
        Me.btnSetFolder.UseVisualStyleBackColor = True
        '
        'opdRetFile
        '
        Me.opdRetFile.FileName = "OpenFileDialog1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnClearMismatchData)
        Me.GroupBox4.Controls.Add(Me.btnReportMismatch)
        Me.GroupBox4.Controls.Add(Me.lblTotalMismatch)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.lblTotRecNo)
        Me.GroupBox4.Controls.Add(Me.lblFaileFileNo)
        Me.GroupBox4.Controls.Add(Me.lblTotFile)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtFileImpStatus)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 136)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(695, 172)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "File Import Status"
        '
        'btnClearMismatchData
        '
        Me.btnClearMismatchData.Location = New System.Drawing.Point(308, 137)
        Me.btnClearMismatchData.Name = "btnClearMismatchData"
        Me.btnClearMismatchData.Size = New System.Drawing.Size(145, 27)
        Me.btnClearMismatchData.TabIndex = 23
        Me.btnClearMismatchData.Text = "Clear Mismatch Data"
        Me.btnClearMismatchData.UseVisualStyleBackColor = True
        '
        'btnReportMismatch
        '
        Me.btnReportMismatch.Location = New System.Drawing.Point(533, 138)
        Me.btnReportMismatch.Name = "btnReportMismatch"
        Me.btnReportMismatch.Size = New System.Drawing.Size(145, 27)
        Me.btnReportMismatch.TabIndex = 22
        Me.btnReportMismatch.Text = "Mismatch Report"
        Me.btnReportMismatch.UseVisualStyleBackColor = True
        '
        'lblTotalMismatch
        '
        Me.lblTotalMismatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalMismatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMismatch.Location = New System.Drawing.Point(599, 21)
        Me.lblTotalMismatch.Name = "lblTotalMismatch"
        Me.lblTotalMismatch.Size = New System.Drawing.Size(82, 20)
        Me.lblTotalMismatch.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(511, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Total Mismatch:"
        '
        'lblTotRecNo
        '
        Me.lblTotRecNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotRecNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRecNo.Location = New System.Drawing.Point(415, 20)
        Me.lblTotRecNo.Name = "lblTotRecNo"
        Me.lblTotRecNo.Size = New System.Drawing.Size(82, 20)
        Me.lblTotRecNo.TabIndex = 19
        '
        'lblFaileFileNo
        '
        Me.lblFaileFileNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFaileFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaileFileNo.Location = New System.Drawing.Point(231, 20)
        Me.lblFaileFileNo.Name = "lblFaileFileNo"
        Me.lblFaileFileNo.Size = New System.Drawing.Size(82, 20)
        Me.lblFaileFileNo.TabIndex = 19
        '
        'lblTotFile
        '
        Me.lblTotFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotFile.Location = New System.Drawing.Point(65, 20)
        Me.lblTotFile.Name = "lblTotFile"
        Me.lblTotFile.Size = New System.Drawing.Size(82, 20)
        Me.lblTotFile.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Total Rec No:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(163, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Err File No:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Total File:"
        '
        'txtFileImpStatus
        '
        Me.txtFileImpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFileImpStatus.Location = New System.Drawing.Point(9, 51)
        Me.txtFileImpStatus.Multiline = True
        Me.txtFileImpStatus.Name = "txtFileImpStatus"
        Me.txtFileImpStatus.ReadOnly = True
        Me.txtFileImpStatus.Size = New System.Drawing.Size(669, 81)
        Me.txtFileImpStatus.TabIndex = 3
        '
        'FrmClearRetImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 393)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClearRetImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return XML File upload"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents opdRetFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtClearingDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents fbdRetFile As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtFolderPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSetFolder As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFileImpStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotFile As System.Windows.Forms.Label
    Friend WithEvents lblTotRecNo As System.Windows.Forms.Label
    Friend WithEvents lblFaileFileNo As System.Windows.Forms.Label
    Friend WithEvents lblTotalMismatch As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnReportMismatch As System.Windows.Forms.Button
    Friend WithEvents btnClearMismatchData As System.Windows.Forms.Button
End Class
