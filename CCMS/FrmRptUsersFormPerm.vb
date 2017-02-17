Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Globalization.Calendar

Imports MigraDoc.Rendering
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes

Public Class FrmRptUsersFormPerm

    Dim _document As Document

    Dim _table As Table

    Shared ReadOnly TableBorder As Color = New Color(81, 125, 192)
    Shared ReadOnly TableBlue As Color = New Color(235, 240, 249)
    Shared ReadOnly TableGray As Color = New Color(242, 242, 242)

    Dim _fileName As String = ""


    Private Sub CreateReportDocument()

        _document = New Document()
        _document.Info.Title = "Users Form Permission Report"
        _document.Info.Subject = "Report showing users menu permission."
        _document.Info.Author = "CCMS Application"

        _document.DefaultPageSetup.LeftMargin = "0.5cm"
        _document.DefaultPageSetup.RightMargin = "0.5cm"
        '21 (total page width) - 2.5 2.5
        'MessageBox.Show(_document.DefaultPageSetup.LeftMargin.ToString())
        'MessageBox.Show(_document.DefaultPageSetup.RightMargin.ToString())
        'MessageBox.Show(_document.DefaultPageSetup.PageWidth.ToString())
        '_document.DefaultPageSetup.Orientation = Orientation.Landscape

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
        style.Font.Name = "Verdana"

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
        paragraph.AddText("Users Menu Permission")
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


        ''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub CreateTable()

        ' Create the item table

        _table = _document.LastSection.AddTable()
        _table.Style = "Table"
        _table.Borders.Color = TableBorder
        _table.Borders.Width = 0.25
        _table.Borders.Left.Width = 0.5
        _table.Borders.Right.Width = 0.5
        _table.Rows.LeftIndent = 0

        ' Before you can add a row, you must define the columns
        Dim column As Column = _table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("4cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = _table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        ' Create the header of the table
        Dim row As Row = _table.AddRow()
        row.HeadingFormat = True
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Shading.Color = TableBlue

        row.Cells(0).AddParagraph("User ID")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left

        row.Cells(1).AddParagraph("FG Name")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left

        row.Cells(2).AddParagraph("Form Name")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left

        row.Cells(3).AddParagraph("Show")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left

        row.Cells(4).AddParagraph("New")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left

        row.Cells(5).AddParagraph("Unlock")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left

        row.Cells(6).AddParagraph("Authorizer")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left

        row.Cells(7).AddParagraph("Delete")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left

        row.Cells(8).AddParagraph("Save")
        row.Cells(8).Format.Alignment = ParagraphAlignment.Left





    End Sub

    Private Sub FillContent()


        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim strSql As String
        strSql = "SELECT * FROM V_USERS_ROLE_FORM_PERMISSION " & _
                    "  "

        Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)

        Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

        Dim paragraph As Paragraph

        'Dim deptSlno As Integer = 0
        'Dim domain As String = ""
        CreateTable()
        For i = 0 To dt.Rows.Count - 1

            Dim row1 As Row = _table.AddRow()

            row1.TopPadding = 1.5

            row1.Cells(0).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("USERS_ID")))
            row1.Cells(0).Format.Alignment = ParagraphAlignment.Left

            paragraph = row1.Cells(1).AddParagraph()
            paragraph.AddText(NullHelper.ObjectToString(dt.Rows(i)("FG_NAME")))
            row1.Cells(1).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(2).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("FORMS_NAME")))
            row1.Cells(2).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(3).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("IS_SHOW")))
            row1.Cells(3).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(4).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("IS_NEW")))
            row1.Cells(4).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(5).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("IS_UNLOCK")))
            row1.Cells(5).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(6).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("IS_AUTHORIZER")))
            row1.Cells(6).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(7).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("IS_DELETE")))
            row1.Cells(7).Format.Alignment = ParagraphAlignment.Left

            row1.Cells(8).AddParagraph(NullHelper.ObjectToString(dt.Rows(i)("IS_SAVE")))
            row1.Cells(8).Format.Alignment = ParagraphAlignment.Left



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
            'Dim filename As String = "ReporUsersRole.pdf"
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



    Private Sub FrmRptUsersRole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'SaveFileDialog1.FileName = "ReportUsersRole.pdf"

        SaveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf"
        SaveFileDialog1.ShowDialog()
        SaveFileDialog1.CheckFileExists = True

        If SaveFileDialog1.FileName.Trim() = "" Then
            MessageBox.Show("Report destination required !!")
            Me.Close()
        End If

        _fileName = SaveFileDialog1.FileName.Trim()

        If _fileName.Trim() <> "" Then
            ProgressBar1.Style = ProgressBarStyle.Marquee
            BackgroundWorker1.RunWorkerAsync()
        End If



    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ReportToPDF()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub
End Class