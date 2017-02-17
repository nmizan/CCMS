Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.Calendar
'Imports CrystalDecisions.CrystalReports.Engine

Imports MigraDoc.Rendering
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes

Public Class FrmLogReport
    Dim _formName As String = "SystemReportActivityLog"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)

    Dim _document As Document

    Dim _table As Table

    Shared ReadOnly TableBorder As Color = New Color(81, 125, 192)
    Shared ReadOnly TableBlue As Color = New Color(235, 240, 249)
    Shared ReadOnly TableGray As Color = New Color(242, 242, 242)

    Dim _fileName As String = ""

    Private Sub CreateReportDocument()

        _document = New Document()
        _document.Info.Title = "Activity Log Report"
        _document.Info.Subject = "Report showing activity log."
        _document.Info.Author = "CCMS Application"

        DefineStyles()

        CreatePage()

        FillContent()
    End Sub

    Private Sub DefineStyles()

        ' Get the predefined style Normal.
        Dim style As Style = _document.Styles("Normal")
        ' Because all styles are derived from Normal, the next line changes the 
        ' font of the whole document. Or, more exactly, it changes the font of
        ' all styles and paragraphs that do not redefine the font.
        Style.Font.Name = "Verdana"

        style = _document.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right)

        style = _document.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center)

        ' Create a new style called Table based on style Normal
        style = _document.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Verdana"
        'style.Font.Name = "Times New Roman"
        style.Font.Size = 8

        ' Create a new style called Reference based on style Normal
        style = _document.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub

    Private Sub CreatePage()
        Dim section As Section = _document.AddSection()

        
        ' Create Header
        Dim paragraph As Paragraph = section.Headers.Primary.AddParagraph()
        paragraph.AddText("Activity Log Report")
        paragraph.Format.Font.Size = 9
        paragraph.Format.Font.Bold = True
        paragraph.Format.Alignment = ParagraphAlignment.Center

        paragraph = section.Headers.Primary.AddParagraph()
        paragraph.AddText("Print Date: ")
        paragraph.Format.Font.Size = 8
        'paragraph.Format.Font.Bold = true
        paragraph.Format.Alignment = ParagraphAlignment.Right
        paragraph.AddDateField("dd-MMM-yyyy")

        ' Create footer
        paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddText("Page ")
        paragraph.AddPageField()
        paragraph.AddText(" of ")
        paragraph.AddNumPagesField()
        paragraph.Format.Font.Size = 7
        'paragraph.Format.Font.Bold = True
        paragraph.Format.Alignment = ParagraphAlignment.Center


        ' Create the item table
        _table = section.AddTable()
        _table.Style = "Table"
        _table.Borders.Color = TableBorder
        _table.Borders.Width = 0.25
        _table.Borders.Left.Width = 0.5
        _table.Borders.Right.Width = 0.5
        _table.Rows.LeftIndent = 0
        'total: 16
        ' Before you can add a row, you must define the columns
        Dim column As Column = _table.AddColumn("4cm")
        column.Format.Alignment = ParagraphAlignment.Center

        column = _table.AddColumn("9cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = _table.AddColumn("3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        ' Create the header of the table
        Dim row As Row = _table.AddRow()
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Shading.Color = TableBlue
        row.Cells(0).AddParagraph("Date Time")
        'row.Cells(0).Format.Font.Bold = false
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        'row.Cells(0).VerticalAlignment = VerticalAlignment.Bottom
        'row.Cells(0).MergeDown = 1
        row.Cells(1).AddParagraph("Log Description")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        'row.Cells(1).MergeRight = 3
        row.Cells(2).AddParagraph("User")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        'row.Cells(2).VerticalAlignment = VerticalAlignment.Bottom
        'row.Cells(5).MergeDown = 1

    End Sub

    Private Sub FillContent()


        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_SystemLog_GetDetail")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtEntryDateFrom.Text.Trim()))
        db.AddInParameter(commProc, "@DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtEntryDateTo.Text.Trim()))
        db.AddInParameter(commProc, "@USER_NAME", DbType.String, NullHelper.StringToObject(txtUser.Text.Trim()))
        db.AddInParameter(commProc, "@TEXT", DbType.String, NullHelper.StringToObject(txtText.Text.Trim()))

        Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)



        Dim paragraph As Paragraph
       

        For i = 0 To dt.Rows.Count - 1

            Dim row1 As Row = _table.AddRow()

            row1.TopPadding = 1.5

            row1.Cells(0).AddParagraph(NullHelper.DateToString(dt.Rows(i)("LOG_DATETIME"), "dd/MM/yyyy h:mm:ss tt"))
            row1.Cells(0).Format.Alignment = ParagraphAlignment.Center

            paragraph = row1.Cells(1).AddParagraph()
            paragraph.AddText(dt.Rows(i)("LOG_DESCRIPTION"))
            row1.Cells(1).Format.Alignment = ParagraphAlignment.Left
            
            row1.Cells(2).AddParagraph(dt.Rows(i)("LOG_USER"))
            row1.Cells(2).Format.Alignment = ParagraphAlignment.Left
            
        Next i

    End Sub


    Private Sub ReportToPDF()

        Try

           

            CreateReportDocument()
            _document.UseCmykColor = True


            ' Create a renderer for PDF that uses Unicode font encoding
            Dim pdfRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)

            ' Set the MigraDoc document
            pdfRenderer.Document = _document

            ' Create the PDF document
            pdfRenderer.RenderDocument()

            ' Save the PDF document...
            'Dim filename As String = "Invoice.pdf"
            '#If DEBUG Then
            '        // I don't want to close the document constantly...
            '        filename = "Invoice-" + Guid.NewGuid().ToString("N").ToUpper() + ".pdf"
            '#End If
            pdfRenderer.Save(_fileName)
            ' ...and start a viewer.
            Process.Start(_fileName)

        Catch ex As Exception
            MessageBox.Show("Proc: ReportToPDF" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ReportToExcel()
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_SystemLog_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtEntryDateFrom.Text.Trim()))
            db.AddInParameter(commProc, "@DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtEntryDateTo.Text.Trim()))
            db.AddInParameter(commProc, "@USER_NAME", DbType.String, NullHelper.StringToObject(txtUser.Text.Trim()))
            db.AddInParameter(commProc, "@TEXT", DbType.String, NullHelper.StringToObject(txtText.Text.Trim()))

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim objExp As New ExportUtil("Log Report")

            objExp.ExportXl(dt)

            

        Catch ex As Exception
            MessageBox.Show("Proc: ReportToExcel" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEntryDateFrom.Focus()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        If rbtnPdf.Checked = True Then


            SaveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf"
            SaveFileDialog1.ShowDialog()
            SaveFileDialog1.CheckFileExists = True

            If SaveFileDialog1.FileName.Trim() = "" Then
                MessageBox.Show("Report destination required !!")
                Me.Close()
            End If

            _fileName = SaveFileDialog1.FileName.Trim()

            If _fileName.Trim() <> "" Then
                 ReportToPDF()
            End If




        ElseIf rbtnExcel.Checked = True Then
            ReportToExcel()
        Else
            Dim report As New FrmReportViewer()
            Dim rpt As New crSysLogReport()

            rpt.SetParameterValue("@DATE_FROM", NullHelper.StringToDate(txtEntryDateFrom.Text.Trim()))
            rpt.SetParameterValue("@DATE_TO", NullHelper.StringToDate(txtEntryDateTo.Text.Trim()))
            rpt.SetParameterValue("@USER_NAME", NullHelper.ObjectToNull(txtUser.Text.Trim()))
            rpt.SetParameterValue("@TEXT", NullHelper.ObjectToNull(txtText.Text.Trim()))

            report.SetReport(rpt)
            report.ShowDialog()

        End If



        



    End Sub


    Private Sub txtUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter And txtUser.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtText.KeyDown
        If e.KeyCode = Keys.Enter And txtText.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtEntryDateFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntryDateFrom.KeyDown
        If e.KeyCode = Keys.Enter And txtEntryDateFrom.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtEntryDateTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntryDateTo.KeyDown
        If e.KeyCode = Keys.Enter And txtEntryDateTo.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class