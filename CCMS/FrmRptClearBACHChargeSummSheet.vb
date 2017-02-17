Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Office.Interop

Public Class FrmRptClearBACHChargeSummSheet

    Dim _formName As String = "ReportClearingChargeBACHChargeSummarySheet"
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

    Private Sub ExportRVToXl()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable
            Dim strSql As String = ""

            'Dim volTotal As Decimal=0
            Dim volLess50 As Decimal = 0
            Dim volL50To500 As Decimal = 0
            Dim volUp500 As Decimal = 0

            Dim xlApp As New Excel.Application

            Dim wb As Excel.Workbook = xlApp.Workbooks.Add

            Dim sheet As Excel.Worksheet = wb.Worksheets.Add

            '-----------Row: Total Presentment of Cheque of the Month ----------------

            '-----------Row: Total Presentment of Cheque of Amt<50K ----------------

            strSql = "SELECT COUNT(ACC_NO) AS 'VOLUME' " & _
                           "FROM V_CLEAR_CHECKS WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND AMOUNT<50000"

            Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                volLess50 = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            End If

            sheet.Cells(7, 2) = volLess50

            sheet.Cells(7, 3) = 0
            sheet.Cells(7, 4) = 0
            sheet.Cells(7, 5) = 0
            sheet.Cells(7, 6) = 0
            sheet.Cells(7, 7) = 0

            '-----------Row: Total Presentment of Cheque of 50K≤Amt<500K ----------------

            strSql = "SELECT COUNT(ACC_NO) AS 'VOLUME' " & _
                           "FROM V_CLEAR_CHECKS WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND AMOUNT>=50000 AND AMOUNT<500000"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                volL50To500 = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            End If

            sheet.Cells(8, 2) = volL50To500

            strSql = "SELECT VALUE_TYPE, SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND AMOUNT>=50000 AND AMOUNT<500000 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(8, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(8, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(8, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(8, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(8, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            End If

            '-----------Row: Total Presentment of Cheque of Amt≥500K ----------------

            strSql = "SELECT COUNT(ACC_NO) AS 'VOLUME' " & _
                           "FROM V_CLEAR_CHECKS WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND AMOUNT>=500000"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                volUp500 = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            End If

            sheet.Cells(9, 2) = volL50To500

            strSql = "SELECT VALUE_TYPE, SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND AMOUNT>=50000 AND AMOUNT<500000 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(9, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(9, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(9, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(9, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(9, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            End If

            '-----------Row: Total G2P Cheque of 50K≤Amt<500K ----------------

            strSql = "SELECT COUNT(REMARK) AS 'VOLUME' " & _
                           "FROM V_CLEAR_CHECK_G2P WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND DEBIT_CREDIT>=50000 AND DEBIT_CREDIT<500000"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(10, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            Else
                sheet.Cells(10, 2) = 0
            End If

            sheet.Cells(10, 3) = 0
            sheet.Cells(10, 4) = 0
            sheet.Cells(10, 5) = 0
            sheet.Cells(10, 6) = 0
            sheet.Cells(10, 7) = 0

            '-----------Row: Total G2P Cheque of Amt≥500K ----------------

            strSql = "SELECT COUNT(REMARK) AS 'VOLUME' " & _
                           "FROM V_CLEAR_CHECK_G2P WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND DEBIT_CREDIT>=500000"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(11, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            Else
                sheet.Cells(11, 2) = 0
            End If

            sheet.Cells(11, 3) = 0
            sheet.Cells(11, 4) = 0
            sheet.Cells(11, 5) = 0
            sheet.Cells(11, 6) = 0
            sheet.Cells(11, 7) = 0

            '-----------Row: Waived Cheque of 50K≤Amt<500K ----------------

            strSql = "SELECT COUNT(ACC_NO) AS 'VOLUME' " & _
                           "FROM dbo.V_CLEAR_CHECKS_WAIVED WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND AMOUNT>=50000 AND AMOUNT<500000"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(12, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            Else
                sheet.Cells(12, 2) = 0
            End If

            sheet.Cells(12, 3) = 0
            sheet.Cells(12, 4) = 0
            sheet.Cells(12, 5) = 0
            sheet.Cells(12, 6) = 0
            sheet.Cells(12, 7) = 0

            '-----------Row: Waived Cheque of Amt≥500K ----------------

            strSql = "SELECT COUNT(ACC_NO) AS 'VOLUME' " & _
                           "FROM dbo.V_CLEAR_CHECKS_WAIVED WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " & _
                           "AND AMOUNT>=500000"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(13, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            Else
                sheet.Cells(13, 2) = 0
            End If

            sheet.Cells(13, 3) = 0
            sheet.Cells(13, 4) = 0
            sheet.Cells(13, 5) = 0
            sheet.Cells(13, 6) = 0
            sheet.Cells(13, 7) = 0

            '-----------Row: Cheque of 50K≤Amt<500K With Generel Charge (10 Tk) ----------------

            strSql = "SELECT VALUE_TYPE, COUNT(ACC_NO) AS 'VOLUME', " & _
                        "SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND AMOUNT>=50000 AND AMOUNT<500000 " & _
                        "AND CONSOL_CHARGE=10 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(14, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
                sheet.Cells(14, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(14, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(14, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(14, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(14, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            End If

            '-----------Row: Cheque of Amt≥500K With Generel Charge (25 Tk) ----------------

            strSql = "SELECT VALUE_TYPE, COUNT(ACC_NO) AS 'VOLUME', " & _
                        "SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND AMOUNT>=500000 " & _
                        "AND CONSOL_CHARGE=25 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(15, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
                sheet.Cells(15, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(15, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(15, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(15, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(15, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            End If

            '-----------Row: Cheque of 50K≤Amt<500K With BBK Charge (8 Tk) ----------------

            strSql = "SELECT VALUE_TYPE, COUNT(ACC_NO) AS 'VOLUME', " & _
                        "SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND AMOUNT>=50000 AND AMOUNT<500000 " & _
                        "AND CONSOL_CHARGE=8 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(16, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
                sheet.Cells(16, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(16, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(16, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(16, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(16, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            End If


            '-----------Row: Cheque of Amt≥500K With BBK Charge (20 Tk) ----------------

            strSql = "SELECT VALUE_TYPE, COUNT(ACC_NO) AS 'VOLUME', " & _
                        "SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND AMOUNT>=500000 " & _
                        "AND CONSOL_CHARGE=20 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(17, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
                sheet.Cells(17, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(17, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(17, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(17, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(17, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            End If

            '---------Formatting Cells --------------------
           
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(20, 7)).EntireColumn.ColumnWidth = 17

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 7)).Merge()
            sheet.Range(sheet.Cells(2, 1), sheet.Cells(2, 7)).Merge()
            sheet.Range(sheet.Cells(3, 1), sheet.Cells(3, 7)).Merge()
            sheet.Range(sheet.Cells(5, 1), sheet.Cells(19, 1)).EntireColumn.ColumnWidth = 50

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(5, 7)).EntireRow.Font.Bold = True
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(5, 7)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            sheet.Cells(1, 1) = "BACH Charge Summary Sheet"
            sheet.Cells(2, 1) = "Clearing Session: Regular Value"
            sheet.Cells(3, 1) = NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateFrom.Text), "dd-MMM-yy") + " To " + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateTo.Text), "dd-MMM-yy")

            sheet.Range(sheet.Cells(5, 2), sheet.Cells(5, 7)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)

            sheet.Cells(5, 2) = "Volume"
            sheet.Cells(5, 3) = "Client Chargeable"
            sheet.Cells(5, 4) = "Cilent Charged"
            sheet.Cells(5, 5) = "BBK Charge"
            sheet.Cells(5, 6) = "Citi Income"
            sheet.Cells(5, 7) = "Citi VAT"

            sheet.Range(sheet.Cells(6, 1), sheet.Cells(17, 1)).EntireColumn.Font.Bold = True
            sheet.Range(sheet.Cells(6, 1), sheet.Cells(19, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            sheet.Cells(6, 1) = "Total Presentment of Cheque of the Month"
            sheet.Cells(7, 1) = "Total Presentment of Cheque of Amt<50K"
            sheet.Cells(8, 1) = "Total Presentment of Cheque of 50K≤Amt<500K"
            sheet.Cells(9, 1) = "Total Presentment of Cheque of Amt≥500K"
            sheet.Cells(10, 1) = "Total G2P Cheque of 50K≤Amt<500K"
            sheet.Cells(11, 1) = "Total G2P Cheque of Amt≥500K"
            sheet.Cells(12, 1) = "Waived Cheque of 50K≤Amt<500K"
            sheet.Cells(13, 1) = "Waived Cheque of Amt≥500K"
            sheet.Cells(14, 1) = "Cheque of 50K≤Amt<500K With Generel Charge (10 Tk)"
            sheet.Cells(15, 1) = "Cheque of Amt≥500K With Generel Charge (25 Tk)"
            sheet.Cells(16, 1) = "Cheque of 50K≤Amt<500K With BBK Charge (8 Tk)"
            sheet.Cells(17, 1) = "Cheque of Amt≥500K With BBK Charge (20 Tk)"

            sheet.Range(sheet.Cells(5, 2), sheet.Cells(5, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Range(sheet.Cells(6, 1), sheet.Cells(17, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Range(sheet.Cells(7, 1), sheet.Cells(9, 7)).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(13, 7)).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            sheet.Range(sheet.Cells(16, 1), sheet.Cells(17, 7)).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

            sheet.Range(sheet.Cells(6, 1), sheet.Cells(17, 1)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            sheet.Range(sheet.Cells(5, 2), sheet.Cells(17, 7)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

            sheet.Range(sheet.Cells(19, 1), sheet.Cells(19, 7)).EntireRow.Font.Bold = True
            sheet.Cells(19, 1) = "Client Charge Consolidation"
            sheet.Range(sheet.Cells(19, 1), sheet.Cells(19, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(19, 1), sheet.Cells(19, 7)).Borders.Weight = Excel.XlBorderWeight.xlMedium

            sheet.Range(sheet.Cells(6, 3), sheet.Cells(17, 7)).NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)"
            sheet.Range(sheet.Cells(6, 2), sheet.Cells(17, 2)).NumberFormat = "_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)"
            sheet.Range(sheet.Cells(19, 3), sheet.Cells(19, 7)).NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)"
            sheet.Range(sheet.Cells(19, 2), sheet.Cells(19, 2)).NumberFormat = "_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)"


            '-- Formula 

            sheet.Cells(6, 2) = "=B7+B8+B9"
            sheet.Cells(6, 3) = "=C7+C8+C9"
            sheet.Cells(6, 4) = "=D7+D8+D9"
            sheet.Cells(6, 5) = "=E7+E8+E9"
            sheet.Cells(6, 6) = "=F7+F8+F9"
            sheet.Cells(6, 7) = "=G7+G8+G9"
            '----------
            sheet.Cells(19, 2) = "=SUM(B14:B17)"
            sheet.Cells(19, 3) = "=SUM(C14:C17)"
            sheet.Cells(19, 4) = "=SUM(D14:D17)"
            sheet.Cells(19, 5) = "=SUM(E14:E17)"
            sheet.Cells(19, 6) = "=SUM(F14:F17)"
            sheet.Cells(19, 7) = "=SUM(G14:G17)"

            '---------

            sheet.Name = "RV Calc"


            '''''


10:

            xlApp.Visible = True
            wb.Activate()



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub


    Private Sub ExportHVToXl()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable
            Dim strSql As String = ""

            'Dim volTotal As Decimal=0
            Dim volLess50 As Decimal = 0
            Dim volL50To500 As Decimal = 0
            Dim volUp500 As Decimal = 0

            Dim xlApp As New Excel.Application

            Dim wb As Excel.Workbook = xlApp.Workbooks.Add

            Dim sheet As Excel.Worksheet = wb.Worksheets.Add

            '-----------Row: Total Presentment of Cheque of the Month ----------------

            '-----------Row: Total G2P Cheque ----------------

            strSql = "SELECT COUNT(REMARK) AS 'VOLUME' " & _
                           "FROM V_CLEAR_CHECK_G2P WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO " 

            Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(7, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            Else
                sheet.Cells(7, 2) = 0
            End If

            sheet.Cells(7, 3) = 0
            sheet.Cells(7, 4) = 0
            sheet.Cells(7, 5) = 0
            sheet.Cells(7, 6) = 0
            sheet.Cells(7, 7) = 0

            
            '-----------Row: Total Waived Cheque ----------------

            strSql = "SELECT COUNT(ACC_NO) AS 'VOLUME' " & _
                           "FROM dbo.V_CLEAR_CHECKS_WAIVED WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO "

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(8, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
            Else
                sheet.Cells(8, 2) = 0
            End If

            sheet.Cells(8, 3) = 0
            sheet.Cells(8, 4) = 0
            sheet.Cells(8, 5) = 0
            sheet.Cells(8, 6) = 0
            sheet.Cells(8, 7) = 0

            
            '-----------Row: Cheque With Generel Charge (60 Tk) ----------------

            strSql = "SELECT VALUE_TYPE, COUNT(ACC_NO) AS 'VOLUME', " & _
                        "SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND CONSOL_CHARGE=60 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(9, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
                sheet.Cells(9, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(9, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(9, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(9, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(9, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            Else
                sheet.Cells(9, 2) = 0
                sheet.Cells(9, 3) = 0
                sheet.Cells(9, 4) = 0
                sheet.Cells(9, 5) = 0
                sheet.Cells(9, 6) = 0
                sheet.Cells(9, 7) = 0

            End If

            '-----------Row: Cheque With BBK Charge (50 Tk) ----------------

            strSql = "SELECT VALUE_TYPE, COUNT(ACC_NO) AS 'VOLUME', " & _
                        "SUM(CHARGEABLE_AMT) CHARGEABLE_AMT, SUM(BBK_CHARGE) BBK_CHARGE, " & _
                        "SUM(CITI_INCOME) CITI_INCOME, SUM(CITI_VAT) CITI_VAT, SUM(CONSOL_CHARGE) CHARGED " & _
                        "FROM V_CLEAR_CHECK_CHARGE WHERE VALUE_TYPE=@VALUE_TYPE AND OPR_DATE>=@OPR_DATE_FROM " & _
                        "AND OPR_DATE<=@OPR_DATE_TO " & _
                        "AND CONSOL_CHARGE=50 " & _
                        "GROUP BY VALUE_TYPE"

            commProc = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                sheet.Cells(10, 2) = NullHelper.ToDecNum(dt.Rows(0)("VOLUME"))
                sheet.Cells(10, 3) = NullHelper.ToDecNum(dt.Rows(0)("CHARGEABLE_AMT"))
                sheet.Cells(10, 4) = NullHelper.ToDecNum(dt.Rows(0)("CHARGED"))
                sheet.Cells(10, 5) = NullHelper.ToDecNum(dt.Rows(0)("BBK_CHARGE"))
                sheet.Cells(10, 6) = NullHelper.ToDecNum(dt.Rows(0)("CITI_INCOME"))
                sheet.Cells(10, 7) = NullHelper.ToDecNum(dt.Rows(0)("CITI_VAT"))
            Else
                sheet.Cells(10, 2) = 0
                sheet.Cells(10, 3) = 0
                sheet.Cells(10, 4) = 0
                sheet.Cells(10, 5) = 0
                sheet.Cells(10, 6) = 0
                sheet.Cells(10, 7) = 0
            End If


            '---------Formatting Cells --------------------

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(20, 7)).EntireColumn.ColumnWidth = 17

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(1, 7)).Merge()
            sheet.Range(sheet.Cells(2, 1), sheet.Cells(2, 7)).Merge()
            sheet.Range(sheet.Cells(3, 1), sheet.Cells(3, 7)).Merge()
            sheet.Range(sheet.Cells(5, 1), sheet.Cells(19, 1)).EntireColumn.ColumnWidth = 50

            sheet.Range(sheet.Cells(1, 1), sheet.Cells(5, 7)).EntireRow.Font.Bold = True
            sheet.Range(sheet.Cells(1, 1), sheet.Cells(5, 7)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            sheet.Cells(1, 1) = "BACH Charge Summary Sheet"
            sheet.Cells(2, 1) = "Clearing Session: High Value"
            sheet.Cells(3, 1) = NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateFrom.Text), "dd-MMM-yy") + " To " + _
                NullHelper.DateToString(NullHelper.StringToDate(txtDepositDateTo.Text), "dd-MMM-yy")

            sheet.Range(sheet.Cells(5, 2), sheet.Cells(5, 7)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)

            sheet.Cells(5, 2) = "Volume"
            sheet.Cells(5, 3) = "Client Chargeable"
            sheet.Cells(5, 4) = "Cilent Charged"
            sheet.Cells(5, 5) = "BBK Charge"
            sheet.Cells(5, 6) = "Citi Income"
            sheet.Cells(5, 7) = "Citi VAT"

            sheet.Range(sheet.Cells(6, 1), sheet.Cells(11, 1)).EntireColumn.Font.Bold = True
            sheet.Range(sheet.Cells(6, 1), sheet.Cells(11, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            sheet.Cells(6, 1) = "Total Presentment of Cheque of the Month"
            sheet.Cells(7, 1) = "Total G2P Cheque"
            sheet.Cells(8, 1) = "Total Waived Cheque"
            sheet.Cells(9, 1) = "Cheque with Generel Charge (60 Tk)"
            sheet.Cells(10, 1) = "Cheque with Generel Charge (50 Tk)"

            sheet.Range(sheet.Cells(5, 2), sheet.Cells(5, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Range(sheet.Cells(6, 1), sheet.Cells(10, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

            'sheet.Range(sheet.Cells(7, 1), sheet.Cells(9, 7)).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            'sheet.Range(sheet.Cells(12, 1), sheet.Cells(13, 7)).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            'sheet.Range(sheet.Cells(16, 1), sheet.Cells(17, 7)).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

            sheet.Range(sheet.Cells(6, 1), sheet.Cells(10, 1)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)
            sheet.Range(sheet.Cells(5, 2), sheet.Cells(10, 7)).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 7)).EntireRow.Font.Bold = True
            sheet.Cells(12, 1) = "Client Charge Consolidation"
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 7)).Borders.Weight = Excel.XlBorderWeight.xlMedium

            sheet.Range(sheet.Cells(6, 3), sheet.Cells(10, 7)).NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)"
            sheet.Range(sheet.Cells(6, 2), sheet.Cells(10, 2)).NumberFormat = "_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)"
            sheet.Range(sheet.Cells(12, 3), sheet.Cells(12, 7)).NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)"
            sheet.Range(sheet.Cells(12, 2), sheet.Cells(12, 2)).NumberFormat = "_(* #,##0_);_(* (#,##0);_(* "" - ""??_);_(@_)"

            '-- Formula 

            sheet.Cells(6, 2) = "=SUM(B7:B10)"
            sheet.Cells(6, 3) = "=SUM(C7:C10)"
            sheet.Cells(6, 4) = "=SUM(D7:D10)"
            sheet.Cells(6, 5) = "=SUM(E7:E10)"
            sheet.Cells(6, 6) = "=SUM(F7:F10)"
            sheet.Cells(6, 7) = "=SUM(G7:G10)"
            '----------
            sheet.Cells(12, 2) = "=SUM(B9:B10)"
            sheet.Cells(12, 3) = "=SUM(C9:C10)"
            sheet.Cells(12, 4) = "=SUM(D9:D10)"
            sheet.Cells(12, 5) = "=SUM(E9:E10)"
            sheet.Cells(12, 6) = "=SUM(F9:F10)"
            sheet.Cells(12, 7) = "=SUM(G9:G10)"

            '---------

            sheet.Name = "HV Calc"


            '''''


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

        cmbValueType.SelectedIndex = 1
        txtDepositDateFrom.Text = "04/09/2013"

    End Sub

    Private Sub txtDepositDateFrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepositDateFrom.Validated

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() = "/  /" Then
            If CommonUtil.DateValidate(txtDepositDateFrom.Text) = True Then
                txtDepositDateTo.Text = txtDepositDateFrom.Text
            End If
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If cmbValueType.SelectedValue = 1 Then
            ExportRVToXl()
        Else
            ExportHVToXl()
        End If

    End Sub


    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous
        btnReport.Text = "Generate Report"
    End Sub
End Class