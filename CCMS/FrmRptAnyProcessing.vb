Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmRptAnyProcessing

    Dim _formName As String = "ReportReportsCitiAnywhereProcessing"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crCitiAnyProcessing()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""
        Dim strAndOr As String = ""

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_ANY_DEPOSIT.SLIP_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_ANY_DEPOSIT.SLIP_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtValueDateFrom.Text.Trim() <> "/  /" And txtValueDateTo.Text.Trim() <> "/  /" Then

            strFormula = strFormula + strAndOr + "{V_ANY_DEPOSIT.VALUE_DATE}>=#" & NullHelper.StringToCrDateString(txtValueDateFrom.Text.Trim()) & _
                "# AND {V_ANY_DEPOSIT.VALUE_DATE}<=#" & NullHelper.StringToCrDateString(txtValueDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtLocationCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_DEPOSIT.DLOCATION_CODE}='" & txtLocationCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_DEPOSIT.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtBankCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_DEPOSIT.DRAWEE_BANK_CODE}='" & txtBankCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If




        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub








    Private Sub FrmRptAnyProcessing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            
            strSql = "SELECT ACC_NAME AS 'CLIENT','''' + CLIENT_CODE AS 'CLIENT CODE',ACC_NO, " & _
                "LOCATION_NAME,NONZONE_REF AS 'CITIBANK NO.',CHECK_NO,VALUE_DATE, " & _
                "'''' +D_CODE AS 'DEPOSIT SLIP NO.', SLIP_DATE AS 'DEPOSIT DATE', AMOUNT," & _
                "'STATUS' =  CASE  WHEN RTN_STATUS  = 'O' THEN 'OutStanding' WHEN RTN_STATUS  = 'P' THEN 'Paid' WHEN RTN_STATUS  = 'D' THEN 'DD OutStanding' WHEN RTN_STATUS  = 'R' THEN 'Returned' End " & _
                " FROM dbo.V_ANY_DEPOSIT "


            If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then
                strCond = " SLIP_DATE>=@SLIP_DATE_FROM AND SLIP_DATE<=@SLIP_DATE_TO "
                strAndOr = " AND "
            End If

            If txtValueDateFrom.Text.Trim() <> "/  /" And txtValueDateTo.Text.Trim() <> "/  /" Then
                strCond = strCond + strAndOr + " VALUE_DATE>=@VALUE_DATE_FROM AND VALUE_DATE<=@VALUE_DATE_TO "
                strAndOr = " AND "
            End If

            If txtLocationCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " DLOCATION_CODE=@LOCATION_CODE "
                strAndOr = " AND "
            End If

            If txtClientCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " CLIENT_CODE=@CLIENT_CODE "
                strAndOr = " AND "
            End If

            If txtBankCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " DRAWEE_BANK_CODE=@DRAWEE_BANK_CODE "
                strAndOr = " AND "
            End If


            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            strSql = strSql + " ORDER BY ACC_NAME+CLIENT_CODE,LOCATION_NAME"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SLIP_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
                db.AddInParameter(commProcSche, "@SLIP_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
            End If

            If txtValueDateFrom.Text.Trim() <> "/  /" And txtValueDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@VALUE_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtValueDateFrom.Text))
                db.AddInParameter(commProcSche, "@VALUE_DATE_TO", DbType.Date, NullHelper.StringToDate(txtValueDateTo.Text))

            End If

            If txtLocationCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

            End If

            If txtClientCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            End If

            If txtBankCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, txtBankCode.Text.Trim())
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