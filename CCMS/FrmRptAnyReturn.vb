Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.Common

Public Class FrmRptAnyReturn

    Dim _formName As String = "ReportManifoldCitiAnywhereReturn"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crCitiAnyReturn()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtReturnDateFrom.Text.Trim() <> "/  /" And txtReturnDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_ANY_RETURN.RET_DATE}>=#" & NullHelper.StringToCrDateString(txtReturnDateFrom.Text.Trim()) & _
                "# AND {V_ANY_RETURN.RET_DATE}<=#" & NullHelper.StringToCrDateString(txtReturnDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtSlipDateFrom.Text.Trim() <> "/  /" And txtSlipDateTo.Text.Trim() <> "/  /" Then
            strFormula = strFormula + strAndOr + "{V_ANY_RETURN.SLIP_DATE}>=#" & NullHelper.StringToCrDateString(txtSlipDateFrom.Text.Trim()) & _
               "# AND {V_ANY_RETURN.SLIP_DATE}<=#" & NullHelper.StringToCrDateString(txtSlipDateTo.Text.Trim()) & "#"

            strAndOr = " AND "
        End If


        If txtLocationCode.Text.Trim() <> "" Then
            strFormula = strFormula + strAndOr + "{V_ANY_RETURN.DLOCATION_CODE}='" & txtLocationCode.Text.Trim() & "'"

            strAndOr = " AND "
        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_RETURN.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"

        End If

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub







    Private Sub FrmRptAnyReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'SLNO, DLOCATION_CODE, CUSTOMER_REF, VALUE_DATE, AMOUNT, CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, , RTN_STATUS, REMINDER_DATE, REMINDER_NO, RTN_CODE, FILENAME, FILE_USER_ID, FLEXGEN_DATE,  MAIL_ADD, LOCATION_NAME, REJECT_REASON, BANK_NAME, BRANCH_NAME, RET_DATE
            'deposit slipno,check no,bank, branch, amount,reason
            strSql = "SELECT ACC_NAME AS 'CLIENT','''' + CLIENT_CODE AS 'CLIENT CODE',ACC_NO, " & _
                "NONZONE_REF AS 'CITIBANK NO',CHECK_REF AS 'CHECK REF',SLIP_DATE AS 'DEPOSIT DATE', " & _
                "'''' + D_CODE AS 'DEPOSIT SLIP NO',CHECK_NO,BANK_NAME, BRANCH_NAME,AMOUNT,REJECT_REASON" & _
                " FROM dbo.V_ANY_RETURN "


            If txtReturnDateFrom.Text.Trim() <> "/  /" And txtReturnDateTo.Text.Trim() <> "/  /" Then
                strCond = " RET_DATE>=@RET_DATE_FROM AND RET_DATE<=@RET_DATE_TO "
                strAndOr = " AND "
            End If

            If txtSlipDateFrom.Text.Trim() <> "/  /" And txtSlipDateTo.Text.Trim() <> "/  /" Then
                strCond = strCond + strAndOr + " SLIP_DATE>=@SLIP_DATE_FROM AND SLIP_DATE<=@SLIP_DATE_TO "
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


            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            strSql = strSql + " ORDER BY ACC_NAME+CLIENT_CODE,LOCATION_NAME"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtReturnDateFrom.Text.Trim() <> "/  /" And txtReturnDateTo.Text.Trim() <> "/  /" Then              
                db.AddInParameter(commProcSche, "@RET_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtReturnDateFrom.Text))
                db.AddInParameter(commProcSche, "@RET_DATE_TO", DbType.Date, NullHelper.StringToDate(txtReturnDateTo.Text))
            End If

            If txtSlipDateFrom.Text.Trim() <> "/  /" And txtSlipDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SLIP_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtSlipDateFrom.Text))
                db.AddInParameter(commProcSche, "@SLIP_DATE_TO", DbType.Date, NullHelper.StringToDate(txtSlipDateTo.Text))

            End If

            If txtLocationCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

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