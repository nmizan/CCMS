
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmRptGuaranteedCreditBooking

    Dim _formName As String = "ReportReportsGuaranteedCreditBooking"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub FrmRptGuaranteedCreditBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crGuaranteedCreditBooking()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_GUARANTEED_CREDIT_BOOKING.SCHEDULE_DATE}>=#" & NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & _
                "# AND {V_GUARANTEED_CREDIT_BOOKING.SCHEDULE_DATE}<=#" & NullHelper.StringToCrDateString(txtScheduleDateTo.Text.Trim()) & "#"

            strAndOr = " AND "
        End If

        If txtEntryDateFrom.Text.Trim() <> "/  /" And txtEntryDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_GUARANTEED_CREDIT_BOOKING.ENTRY_DATE}>=#" & NullHelper.StringToCrDateString(txtEntryDateFrom.Text.Trim()) & _
                "# AND {V_GUARANTEED_CREDIT_BOOKING.ENTRY_DATE}<=#" & NullHelper.StringToCrDateString(txtEntryDateTo.Text.Trim()) & "#"

            strAndOr = " AND "
        End If


        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_GUARANTEED_CREDIT_BOOKING.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"


        End If



        ' frmRptViewer.SetFormula(strFormula)


        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()


    End Sub

    Private Sub btnReportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportExcel.Click
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim strSql = ""

            Dim strCond = ""

            Dim strAndOr = ""

            strSql = "SELECT * FROM V_GUARANTEED_CREDIT_BOOKING "


            If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then
                strCond = " SCHEDULE_DATE>=@SCHEDULE_DATE_FROM AND SCHEDULE_DATE<=@SCHEDULE_DATE_TO "
                strAndOr = " AND "
            End If

            If txtEntryDateFrom.Text.Trim() <> "/  /" And txtEntryDateTo.Text.Trim() <> "/  /" Then
                strCond = strCond + strAndOr + " ENTRY_DATE>=@ENTRY_DATE_FROM AND ENTRY_DATE<=@ENTRY_DATE_TO "
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

            If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtScheduleDateFrom.Text))
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_TO", DbType.Date, NullHelper.StringToDate(txtScheduleDateTo.Text))
            End If

            If txtEntryDateFrom.Text.Trim() <> "/  /" And txtEntryDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@ENTRY_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtEntryDateFrom.Text))
                db.AddInParameter(commProcSche, "@ENTRY_DATE_TO", DbType.Date, NullHelper.StringToDate(txtEntryDateTo.Text))

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