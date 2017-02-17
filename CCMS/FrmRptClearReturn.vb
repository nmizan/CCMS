Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Imports Microsoft.Office.Interop


Public Class FrmRptClearReturn

    Dim _formName As String = "ReportReportsClearingReturn"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click


        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Select entry location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        Dim rd As New crCitiClearReturn()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_CLEAR_RETURN.OPR_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_CLEAR_RETURN.OPR_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If


        If cmbEntryLocation.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_RETURN.ENTRY_LOC}='" & cmbEntryLocation.SelectedValue & "'"
            strAndOr = " AND "

        End If

       


        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_RETURN.REMARK}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtBankCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_RETURN.BANK_CODE}='" & txtBankCode.Text.Trim() & "'"
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



        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)
    End Sub

    Private Sub btnReportSequence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportSequence.Click

        If txtDepositDateFrom.Text.Trim() = "/  /" Or txtDepositDateTo.Text.Trim() = "/  /" Then
            MessageBox.Show("Clearing date required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepositDateFrom.Focus()
            Exit Sub

        End If

        Dim rd As New crClearReturnSeq()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""


        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_RETURN_SEQ_CLEAR.OPR_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_RETURN_SEQ_CLEAR.OPR_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"



        End If


     

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()


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

            Dim strSql As String = "SELECT OPR_DATE As 'CLEARING DATE',PAYEE_NAME as CUSTOMER,REMARK as 'A/C', " & _
                                "DS_CODE as SLIP,CHECK_NUMBER as 'CHQ NO', REJECT_REASON as REASON, " & _
                                "ISNULL(BANK_NAME,'') + '(' + ISNULL(BRANCH_NAME,'') + ')' as BANK, " & _
                                "DEBIT_CREDIT as AMOUNT " & _
                            "FROM V_CLEAR_RETURN WHERE ENTRY_LOC=@ENTRY_LOC AND OPR_DATE>=@OPR_DATE_FROM " & _
                            "AND OPR_DATE<=@OPR_DATE_TO"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@OPR_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
            db.AddInParameter(commProcSche, "@OPR_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

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

                sheet.Name = "Return Data"

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