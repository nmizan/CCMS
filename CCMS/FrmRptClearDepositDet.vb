Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Imports Microsoft.Office.Interop



Public Class FrmRptClearDepositDet

    Dim _formName As String = "ReportReportsClearingDepositDetail"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadComboValues()


        Dim dt1 As New DataTable()

        dt1.Columns.Add("ID")
        dt1.Columns.Add("TYPE")
        Dim dr1 As DataRow = dt1.NewRow()

        dr1 = dt1.NewRow()
        dr1(0) = "1"
        dr1(1) = "Low"
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



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click


        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Select entry location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        Dim rd As New crCitiClearDepositDet()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_CLEAR_DEPOSIT.OPR_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_CLEAR_DEPOSIT.OPR_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If


        If cmbEntryLocation.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.ENTRY_LOC}='" & cmbEntryLocation.SelectedValue & "'"
            strAndOr = " AND "

        End If

        If cmbValueType.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.VALUE_TYPE}=" & cmbValueType.SelectedValue & ""
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.REMARK}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtBankCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.BANK_CODE}='" & txtBankCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If


        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub





    Private Sub FrmRptClearCheckSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        LoadComboValues()

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)
    End Sub

    Private Sub btnReportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportExcel.Click

        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Select entry location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If txtDepositDateFrom.Text.Trim() = "/  /" Then
            MessageBox.Show("Clearing From Date Required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepositDateFrom.Focus()
            Exit Sub
        End If


        If txtDepositDateTo.Text.Trim() = "/  /" Then
            MessageBox.Show("Clearing To Date Required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepositDateTo.Focus()
            Exit Sub
        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim strSql = ""

            strSql = "SELECT PAYEE_NAME as 'Acc Name', REMARK as 'Acc No', OPR_DATE 'Clearing Date', " & _
                            "DS_CODE,CHECK_REF, CUSTOMER_REF, CHECK_NUMBER, " & _
                            "BANK_NAME, BRANCH_NAME, DEBIT_CREDIT as AMOUNT " & _
                            "FROM V_CLEAR_DEPOSIT WHERE ENTRY_LOC=@ENTRY_LOC AND OPR_DATE>=@OPR_DATE_FROM " & _
                            "AND OPR_DATE<=@OPR_DATE_TO"

            If cmbValueType.SelectedIndex > -1 Then

                strSql = "SELECT PAYEE_NAME as 'Acc Name', REMARK as 'Acc No', OPR_DATE 'Clearing Date', " & _
                           "DS_CODE,CHECK_REF, CUSTOMER_REF, CHECK_NUMBER, " & _
                           "BANK_NAME, BRANCH_NAME, DEBIT_CREDIT as AMOUNT " & _
                           "FROM V_CLEAR_DEPOSIT WHERE ENTRY_LOC=@ENTRY_LOC AND OPR_DATE>=@OPR_DATE_FROM " & _
                           "AND OPR_DATE<=@OPR_DATE_TO AND VALUE_TYPE=@VALUE_TYPE"

            End If


            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProcSche, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

            If cmbValueType.SelectedIndex > -1 Then
                db.AddInParameter(commProcSche, "@VALUE_TYPE", DbType.Int16, cmbValueType.SelectedValue)
            End If


            dt = db.ExecuteDataSet(commProcSche).Tables(0)


            If dt.Rows.Count > 0 Then



                Dim totCol As Integer = dt.Columns.Count
                Dim totRow As Integer = dt.Rows.Count

                '--------------

                ' Copy the DataTable to an object array
                'Dim rawData(dgView.Rows.Count, dgView.Columns.Count - 1) As Object
                Dim rawData(totRow, totCol - 1) As Object

                ' Copy the column names to the first row of the object array
                Dim relCol As Integer = 0

                For col = 0 To totCol - 1


                    rawData(0, relCol) = dt.Columns(col).Caption
                    relCol = relCol + 1



                Next


                For row = 0 To totRow - 1
                    relCol = 0
                    For col = 0 To totCol - 1
                        If dt.Rows(row)(col) Is Nothing Or dt.Rows(row)(col) Is DBNull.Value Then
                            rawData(row + 1, relCol) = ""
                        Else
                            rawData(row + 1, relCol) = NullHelper.StringToObject(dt.Rows(row)(col)) 'dt.Rows(row).ItemArray(col)
                        End If

                        relCol = relCol + 1



                    Next

                Next


                ' Calculate the final column letter
                Dim finalColLetter As String = String.Empty
                Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                Dim colCharsetLen As Integer = colCharset.Length

                If totCol > colCharsetLen Then
                    finalColLetter = colCharset.Substring( _
                     (totCol - 1) \ colCharsetLen - 1, 1)
                End If

                finalColLetter += colCharset.Substring( _
                  (totCol - 1) Mod colCharsetLen, 1)

                Dim xlApp As New Excel.Application

                Dim wb As Excel.Workbook = xlApp.Workbooks.Add

                Dim sheet As Excel.Worksheet = wb.Worksheets.Add

                sheet.Name = "Clearing Data"

                Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dt.Rows.Count + 1)

                sheet.Range(excelRange, Type.Missing).Value2 = rawData
                sheet.Range(excelRange, Type.Missing).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
                'CType(sheet.Rows(1, Type.Missing), Excel.Range).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop

                CType(sheet.Rows(1, Type.Missing), Excel.Range).Font.Bold = True


                xlApp.Visible = True
                wb.Activate()



            End If



            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDepositDateFrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepositDateFrom.Validated
        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() = "/  /" Then
            If CommonUtil.DateValidate(txtDepositDateFrom.Text) = True Then
                txtDepositDateTo.Text = txtDepositDateFrom.Text
            End If
        End If
    End Sub
End Class