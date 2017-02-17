Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.Common


Public Class FrmRptCashSpeedDayZero

    Dim _formName As String = "ReportReportsDayZeroCashCheck"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crCashSpeedDayZero()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_SPEEDCASH_DAYZERO.SCHEDULE_DATE}>=#" & NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & _
                "# AND {V_SPEEDCASH_DAYZERO.SCHEDULE_DATE}<=#" & NullHelper.StringToCrDateString(txtScheduleDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtEntryDateFrom.Text.Trim() <> "/  /" And txtEntryDateTo.Text.Trim() <> "/  /" Then

            strFormula = strFormula + strAndOr + "{V_SPEEDCASH_DAYZERO.ENTRY_DATE}>=#" & NullHelper.StringToCrDateString(txtEntryDateFrom.Text.Trim()) & _
                "# AND {V_SPEEDCASH_DAYZERO.ENTRY_DATE}<=#" & NullHelper.StringToCrDateString(txtEntryDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtLocationCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_SPEEDCASH_DAYZERO.LOCATION_CODE}='" & txtLocationCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_SPEEDCASH_DAYZERO.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtBankCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_SPEEDCASH_DAYZERO.CORR_BANK_CODE}='" & txtBankCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If




        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub







    Private Sub FrmRptCashSpeedDayZero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                "SCHEDULE_DATE,ENTRY_DATE,'''' + D_CODE AS 'DEPOSIT No.',DEPOSIT_TYPE,LOCATION_NAME, " & _
                "CITICASH_AMOUNT,CITICHECK_AMOUNT " & _
                " FROM dbo.V_SPEEDCASH_DAYZERO "


            If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then
                strCond = " SCHEDULE_DATE>=@SCHEDULE_DATE_FROM AND SCHEDULE_DATE<=@SCHEDULE_DATE_TO "
                strAndOr = " AND "
            End If

            If txtEntryDateFrom.Text.Trim() <> "/  /" And txtEntryDateTo.Text.Trim() <> "/  /" Then
                strCond = strCond + strAndOr + " ENTRY_DATE>=@ENTRY_DATE_FROM AND ENTRY_DATE<=@ENTRY_DATE_TO "
                strAndOr = " AND "
            End If

            If txtLocationCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " LOCATION_CODE=@LOCATION_CODE "
                strAndOr = " AND "
            End If

            If txtClientCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " CLIENT_CODE=@CLIENT_CODE "
                strAndOr = " AND "
            End If

            If txtBankCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " CORR_BANK_CODE=@CORR_BANK_CODE "
                strAndOr = " AND "
            End If


            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            strSql = strSql + " ORDER BY ACC_NAME+CLIENT_CODE,LOCATION_NAME"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtScheduleDateFrom.Text))
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_TO", DbType.Date, NullHelper.StringToDate(txtScheduleDateTo.Text))
            End If

            If txtEntryDateFrom.Text.Trim() <> "/  /" And txtEntryDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@ENTRY_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtEntryDateFrom.Text))
                db.AddInParameter(commProcSche, "@ENTRY_DATE_TO", DbType.Date, NullHelper.StringToDate(txtEntryDateTo.Text))

            End If

            If txtLocationCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

            End If

            If txtClientCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            End If

            If txtBankCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@CORR_BANK_CODE", DbType.String, txtBankCode.Text.Trim())
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