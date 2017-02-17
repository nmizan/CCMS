Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Office.Interop

Public Class FrmRptClearClientWiseCharge

    Dim _formName As String = "ReportClearingChargeClientWiseBreakup"
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
            'OPR_DATE,CHECK_NUMBER,ACC_NO,AMOUNT,VALUE_TYPE,
            'BBK_CHARGE+CITI_INCOME+CITI_VAT AS CONSOL_CHARGE 
            strSql = "SELECT ACC_NO AS 'Dr. A/C No' ,COUNT(ACC_NO) as 'Cheque Volume', " & _
                                "SUM(CONSOL_CHARGE) as 'Consolidated Charge' " & _
                            "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                            "AND OPR_DATE<=@OPR_DATE_TO " & _
                            "GROUP BY ACC_NO"

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

            'sheet.Range(sheet.Cells(3, 1), sheet.Cells(3 + dt.Rows.Count, 1)).NumberFormat = "dd-MMM-yy"
            sheet.Range(sheet.Cells(3, 2), sheet.Cells(3 + dt.Rows.Count, 2)).NumberFormat = "###,###,###,##0"
            sheet.Range(sheet.Cells(3, 3), sheet.Cells(3 + dt.Rows.Count, 3)).NumberFormat = "###,###,###,###.00"

            'sheet.Range(excelRange, Type.Missing).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop

            If cmbValueType.SelectedIndex = 0 Then

                sheet.Name = "RV"

                sheet.Cells(1, 1) = "Client Wise Charge Breakup " + Environment.NewLine + _
                "From Regular Value " + _
                "Clearing Session of " + Environment.NewLine + NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateFrom.Text), "dd-MMM-yy") + " To " + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateTo.Text), "dd-MMM-yy")

            ElseIf cmbValueType.SelectedIndex = 1 Then

                sheet.Name = "HV"

                sheet.Cells(1, 1) = "Client Wise Charge Breakup " + Environment.NewLine + _
                "From High Value " + _
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

                sheet.Cells(i + 3, 1) = "G" + dt.Rows(i)(0).ToString()
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
            sheet.Range(sheet.Cells(i + 3, 1), sheet.Cells(i + 3, 3)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(i + 3, 1), sheet.Cells(i + 3, 3)).EntireRow.Font.Bold = True
            sheet.Range(sheet.Cells(i + 3, 1), sheet.Cells(i + 3, 3)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
            sheet.Range(sheet.Cells(i + 3, 2), sheet.Cells(i + 3, 2)).NumberFormat = "###,###,###,##0"
            sheet.Range(sheet.Cells(i + 3, 3), sheet.Cells(i + 3, 3)).NumberFormat = "###,###,###,###.00"
            sheet.Cells(i + 3, 1) = "Total"
            'sheet.Cells(i + 3, 2) = dt.Rows.Count.ToString()
            If i = 0 Then
                sheet.Cells(i + 3, 2) = "0"
                sheet.Cells(i + 3, 3) = "0"
            Else
                sheet.Cells(i + 3, 2) = "=SUM(B3:B" + (i + 2).ToString() + ")"
                sheet.Cells(i + 3, 3) = "=SUM(C3:C" + (i + 2).ToString() + ")"
            End If

            '=SUM(B7:B75)

            




10:

            xlApp.Visible = True
            wb.Activate()

           

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