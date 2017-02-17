Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmRptAnyOutstanding

    Dim _formName As String = "ReportReportsCitiAnywhereOutstanding"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crCitiAnyOutstanding()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_ANY_OUTSTANDING.SLIP_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_ANY_OUTSTANDING.SLIP_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtValueDateFrom.Text.Trim() <> "/  /" And txtValueDateTo.Text.Trim() <> "/  /" Then

            strFormula = strFormula + strAndOr + "{V_ANY_OUTSTANDING.VALUE_DATE}>=#" & NullHelper.StringToCrDateString(txtValueDateFrom.Text.Trim()) & _
                "# AND {V_ANY_OUTSTANDING.VALUE_DATE}<=#" & NullHelper.StringToCrDateString(txtValueDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtLocationCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_OUTSTANDING.DLOCATION_CODE}='" & txtLocationCode.Text.Trim() & "'"

            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_OUTSTANDING.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtBankCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_OUTSTANDING.DRAWEE_BANK_CODE}='" & txtBankCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If


        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub








    Private Sub FrmRptAnyOutstanding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub btnReportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportExcel.Click


        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim strSql = ""

            Dim strCond = ""

            Dim strAndOr = ""

            strSql = "SELECT ACC_NAME AS 'CLIENT', ACC_NO,'''' + NONZONE_REF AS 'CITIBANK NO',CHECK_NO,DRAWER, " & _
            "D_CODE AS 'DEPOSIT SLIP NO.', SLIP_DATE AS 'DEPOSIT DATE',DRAWEE_BANK AS 'BANK', " & _
            "DRAWEE_BRANCH AS 'BRANCH',AMOUNT,DAYS_OUTSTANDING AS 'OUTSTANDING' " & _
            "FROM V_ANY_OUTSTANDING "

            If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then
                strCond = " SLIP_DATE>=@SLIP_DATE_FROM AND SLIP_DATE<=@SLIP_DATE_TO "
                strAndOr = " AND "
            End If

            If txtClientCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " CLIENT_CODE=@CLIENT_CODE "
            End If

            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            strSql = strSql + " ORDER BY CLIENT_CODE,DAYS_OUTSTANDING DESC"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SLIP_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
                db.AddInParameter(commProcSche, "@SLIP_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            End If

            If txtClientCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            End If

            


            dt = db.ExecuteDataSet(commProcSche).Tables(0)

            If dt.Rows.Count > 0 Then

                Dim objExp As New ExportUtil("")

                objExp.ExportXl(dt)



            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class