Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Office.Interop

Public Class FrmRptClearGovtCheck

    Dim _formName As String = "ReportClearingChargeBBKReport"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub LoadComboValues()


        Dim dt1 As New DataTable()

        dt1.Columns.Add("ID")
        dt1.Columns.Add("TYPE")
        Dim dr1 As DataRow = dt1.NewRow()

        dr1 = dt1.NewRow()
        dr1(0) = "1"
        dr1(1) = "Regular"
        dt1.Rows.Add(dr1)

        dr1 = dt1.NewRow()
        dr1(0) = "2"
        dr1(1) = "High"
        dt1.Rows.Add(dr1)

        cmbValueType.DataSource = dt1
        cmbValueType.DisplayMember = "TYPE"
        cmbValueType.ValueMember = "ID"

        cmbValueType.SelectedIndex = -1

    End Sub

    Private Sub ExportToXl()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable
            Dim strSql As String = ""

            strSql = "SELECT OPR_DATE As 'Clearing Date',CHECK_NUMBER as 'Check No', " & _
                                "DEBIT_CREDIT as 'Check Amount' " & _
                            "FROM V_CLEAR_CHECK_G2P WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                            "AND OPR_DATE<=@OPR_DATE_TO"

            If cmbValueType.SelectedIndex = 0 Then
                strSql = strSql + " AND DEBIT_CREDIT>=50000 AND DEBIT_CREDIT<500000"

            ElseIf cmbValueType.SelectedIndex = 1 Then
                strSql = strSql + " AND DEBIT_CREDIT>=500000"
            End If


            Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)


            'If dt.Rows.Count > 0 Then

            Dim xlApp As New Excel.Application

            Dim wb As Excel.Workbook = xlApp.Workbooks.Add

            Dim sheet As Excel.Worksheet = wb.Worksheets.Add



            Dim i, j As Integer

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 3)).Merge()
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 1)).EntireRow.RowHeight = 85
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 1)).Font.Size = 16
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 1)).WrapText = True
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 1)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PeachPuff)

            sheet.Range(sheet.Cells(2, 1), sheet.Cells(2, 1)).EntireColumn.ColumnWidth = 23
            sheet.Range(sheet.Cells(2, 2), sheet.Cells(2, 2)).EntireColumn.ColumnWidth = 23
            sheet.Range(sheet.Cells(2, 3), sheet.Cells(2, 3)).EntireColumn.ColumnWidth = 23

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(2, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(2, 3)).EntireRow.Font.Bold = True
            sheet.Range(sheet.Cells(2, 1), sheet.Cells(2, 3)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue)

            sheet.Range(sheet.Cells(3, 1), sheet.Cells(3 + dt.Rows.Count, 1)).NumberFormat = "dd-MMM-yy"
            sheet.Range(sheet.Cells(3, 2), sheet.Cells(3 + dt.Rows.Count, 2)).NumberFormat = "0000000"
            sheet.Range(sheet.Cells(3, 3), sheet.Cells(3 + dt.Rows.Count, 3)).NumberFormat = "###,###,###,###.00"

            'sheet.Range(excelRange, Type.Missing).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop

            If cmbValueType.SelectedIndex = 0 Then

                sheet.Name = "RV Clearing"

                sheet.Cells(1, 1) = "Govt. Transaction for " + Environment.NewLine + _
                "50,000<=Cheque Amount<500,000 " + Environment.NewLine + "From Regular Value " + _
                "Clearing Session of " + Environment.NewLine + NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateFrom.Text), "dd-MMM-yy") + " To " + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateTo.Text), "dd-MMM-yy")

            ElseIf cmbValueType.SelectedIndex = 1 Then

                sheet.Name = "HV Clearing"

                sheet.Cells(1, 1) = "Govt. Transaction Cheque Amount≥500,000 " + Environment.NewLine + "From High Value " + _
                "Clearing Session of " + Environment.NewLine + NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateFrom.Text), "dd-MMM-yy") + " To " + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateTo.Text), "dd-MMM-yy")

            End If


            'excelApp.get_Range("A1:A360,B1:E1", Type.Missing).Merge(Type.Missing);
            'dim range As  Excel.Range  = sheet.get_Range(ws.Cells[1,1],ws.Cells[1,2])

            'range.Merge(True)

            'range.Interior.ColorIndex = 36



            For j = 0 To dt.Columns.Count - 1
                sheet.Cells(2, j + 1) = dt.Columns(j).ColumnName
            Next j


            For i = 0 To dt.Rows.Count - 1


                sheet.Cells(i + 3, 1) = NullHelper.DateToString(dt.Rows(i)(0), "dd-MMM-yy")
                sheet.Cells(i + 3, 2) = dt.Rows(i)(1).ToString()
                sheet.Cells(i + 3, 3) = dt.Rows(i)(2).ToString()

                'For j = 0 To dt.Columns.Count - 1

                '    sheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString()

                If BackgroundWorker1.CancellationPending = True Then
                    GoTo 10
                End If
                'Next j
            Next i
            'sheet.Range(sheet.Cells(2, 1), sheet.Cells(i + 2, 3)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            sheet.Range(sheet.Cells(2, 1), sheet.Cells(i + 2, 3)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(i + 3, 1), sheet.Cells(i + 3, 2)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(i + 3, 1), sheet.Cells(i + 3, 2)).EntireRow.Font.Bold = True
            sheet.Range(sheet.Cells(i + 3, 1), sheet.Cells(i + 3, 2)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
            sheet.Range(sheet.Cells(i + 3, 2), sheet.Cells(i + 3, 2)).NumberFormat = "###,###,###,##0"
            sheet.Cells(i + 3, 1) = "Total No of Cheque"
            sheet.Cells(i + 3, 2) = dt.Rows.Count.ToString()


            If cmbValueType.SelectedIndex = 0 Then


                strSql = "SELECT OPR_DATE As 'Clearing Date',CHECK_NUMBER as 'Check No', " & _
                                "DEBIT_CREDIT as 'Check Amount' " & _
                            "FROM V_CLEAR_CHECK_G2P WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                            "AND OPR_DATE<=@OPR_DATE_TO AND DEBIT_CREDIT>=500000"

                commProc = db.GetSqlStringCommand(strSql)

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
                db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
                db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

                dt = db.ExecuteDataSet(commProc).Tables(0)

                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 6, 3)).Merge()
                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 6, 1)).EntireRow.RowHeight = 75
                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 6, 1)).Font.Size = 16
                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 6, 1)).WrapText = True
                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 6, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 6, 1)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PeachPuff)

                sheet.Range(sheet.Cells(i + 7, 1), sheet.Cells(i + 7, 1)).EntireColumn.ColumnWidth = 23
                sheet.Range(sheet.Cells(i + 7, 2), sheet.Cells(i + 7, 2)).EntireColumn.ColumnWidth = 23
                sheet.Range(sheet.Cells(i + 7, 3), sheet.Cells(i + 7, 3)).EntireColumn.ColumnWidth = 23

                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 7, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                sheet.Range(sheet.Cells(i + 6, 1), sheet.Cells(i + 7, 3)).EntireRow.Font.Bold = True
                sheet.Range(sheet.Cells(i + 7, 1), sheet.Cells(i + 7, 3)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue)

                sheet.Range(sheet.Cells(i + 8, 1), sheet.Cells(i + 8 + dt.Rows.Count, 1)).NumberFormat = "dd-MMM-yy"
                sheet.Range(sheet.Cells(i + 8, 2), sheet.Cells(i + 8 + dt.Rows.Count, 2)).NumberFormat = "0000000"
                sheet.Range(sheet.Cells(i + 8, 3), sheet.Cells(i + 8 + dt.Rows.Count, 3)).NumberFormat = "###,###,###,###.00"

                'sheet.Range(excelRange, Type.Missing).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop


                sheet.Cells(i + 6, 1) = "Govt. Transaction for Cheque Amount>=500,000 " + Environment.NewLine + _
                "From Regular Value Clearing Session of " + Environment.NewLine + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateFrom.Text), "dd-MMM-yy") + " To " + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateTo.Text), "dd-MMM-yy")


                For j = 0 To dt.Columns.Count - 1
                    sheet.Cells(i + 7, j + 1) = dt.Columns(j).ColumnName
                Next j

                Dim oi = i + 3 + 2
                For i = 0 To dt.Rows.Count - 1


                    sheet.Cells(i + 3 + oi, 1) = NullHelper.DateToString(dt.Rows(i)(0), "dd-MMM-yy")
                    sheet.Cells(i + 3 + oi, 2) = dt.Rows(i)(1).ToString()
                    sheet.Cells(i + 3 + oi, 3) = dt.Rows(i)(2).ToString()

                    'For j = 0 To dt.Columns.Count - 1

                    '    sheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString()

                    If BackgroundWorker1.CancellationPending = True Then
                        GoTo 10
                    End If
                    'Next j
                Next i
                'sheet.Range(sheet.Cells(2, 1), sheet.Cells(i + 2, 3)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
                ''''
                sheet.Range(sheet.Cells(2 + oi, 1), sheet.Cells(i + 2 + oi, 3)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Range(sheet.Cells(i + 3 + oi, 1), sheet.Cells(i + 3 + oi, 2)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Range(sheet.Cells(i + 3 + oi, 1), sheet.Cells(i + 3 + oi, 2)).EntireRow.Font.Bold = True
                sheet.Range(sheet.Cells(i + 3 + oi, 1), sheet.Cells(i + 3 + oi, 2)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
                sheet.Range(sheet.Cells(i + 3 + oi, 2), sheet.Cells(i + 3 + oi, 2)).NumberFormat = "###,###,###,##0"
                sheet.Cells(i + 3 + oi, 1) = "Total No of Cheque"
                sheet.Cells(i + 3 + oi, 2) = dt.Rows.Count.ToString()






            End If




10:

            xlApp.Visible = True
            wb.Activate()

            'Dim totCol As Integer = dt.Columns.Count
            'Dim totRow As Integer = dt.Rows.Count

            ''--------------

            '' Copy the DataTable to an object array
            ''Dim rawData(dgView.Rows.Count, dgView.Columns.Count - 1) As Object
            'Dim rawData(totRow, totCol - 1) As Object

            '' Copy the column names to the first row of the object array
            'Dim relCol As Integer = 0

            'For col = 0 To totCol - 1


            '    rawData(0, relCol) = dt.Columns(col).Caption
            '    relCol = relCol + 1



            'Next


            'For row = 0 To totRow - 1
            '    relCol = 0
            '    For col = 0 To totCol - 1
            '        If dt.Rows(row)(col) Is Nothing Or dt.Rows(row)(col) Is DBNull.Value Then
            '            rawData(row + 1, relCol) = ""
            '        Else
            '            rawData(row + 1, relCol) = NullHelper.StringToObject(dt.Rows(row)(col)) 'dt.Rows(row).ItemArray(col)
            '        End If

            '        relCol = relCol + 1



            '    Next

            'Next


            '' Calculate the final column letter
            'Dim finalColLetter As String = String.Empty
            'Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            'Dim colCharsetLen As Integer = colCharset.Length

            'If totCol > colCharsetLen Then
            '    finalColLetter = colCharset.Substring( _
            '     (totCol - 1) \ colCharsetLen - 1, 1)
            'End If

            'finalColLetter += colCharset.Substring( _
            '  (totCol - 1) Mod colCharsetLen, 1)

            'Dim xlApp As New Excel.Application

            'Dim wb As Excel.Workbook = xlApp.Workbooks.Add

            'Dim sheet As Excel.Worksheet = wb.Worksheets.Add

            'sheet.Name = "Return Data"

            'Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dt.Rows.Count + 1)

            'sheet.Range(excelRange, Type.Missing).Value2 = rawData
            'sheet.Range(excelRange, Type.Missing).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
            ''CType(sheet.Rows(1, Type.Missing), Excel.Range).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop

            'CType(sheet.Rows(1, Type.Missing), Excel.Range).Font.Bold = True


            'xlApp.Visible = True
            'wb.Activate()



            'End If



            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click


        If btnReport.Text = "Generate Report" Then

            If cmbValueType.SelectedIndex = -1 Then
                MessageBox.Show("Select value type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbValueType.Focus()
                Exit Sub
            End If


            btnReport.Text = "Cancel"
            ProgressBar1.Style = ProgressBarStyle.Marquee

            BackgroundWorker1.RunWorkerAsync()
        Else
            BackgroundWorker1.CancelAsync()

        End If


    End Sub





    Private Sub FrmRptClearCheckSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        LoadComboValues()

    End Sub

    Private Sub txtDepositDateFrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepositDateFrom.Validated

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() = "/  /" Then
            If CommonUtil.DateValidate(txtDepositDateFrom.Text) = True Then
                txtDepositDateTo.Text = txtDepositDateFrom.Text
            End If
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ExportToXl()

    End Sub

    
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous
        btnReport.Text = "Generate Report"
    End Sub
End Class