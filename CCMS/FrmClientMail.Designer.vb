<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientMail))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblToolStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtBody = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 364)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(693, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 15
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
        Me.lblToolStatus.Size = New System.Drawing.Size(678, 17)
        Me.lblToolStatus.Spring = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnSend)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTo)
        Me.GroupBox2.Controls.Add(Me.txtSubject)
        Me.GroupBox2.Controls.Add(Me.txtBody)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(693, 351)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information"
        '
        'txtBody
        '
        Me.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBody.Location = New System.Drawing.Point(156, 99)
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Size = New System.Drawing.Size(476, 172)
        Me.txtBody.TabIndex = 2
        '
        'txtSubject
        '
        Me.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubject.Location = New System.Drawing.Point(156, 69)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(401, 20)
        Me.txtSubject.TabIndex = 3
        '
        'txtTo
        '
        Me.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTo.Location = New System.Drawing.Point(156, 43)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(401, 20)
        Me.txtTo.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(79, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Client Email:"
        '
        'btnSend
        '
        Me.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(156, 287)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(78, 27)
        Me.btnSend.TabIndex = 12
        Me.btnSend.Text = "Send"
        Me.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Subject :"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Message :"
        '
        'FrmClientMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 386)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmClientMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sent Email  To Client"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBody As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
