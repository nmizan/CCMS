Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.Common


Public Class FrmRptUnclearFund

    Dim _formName As String = "ReportControlsUnclearFund"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crUnclearFund()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        If rdoDeposit.Checked = True Then
            strFormula = "{V_UNCLEAR_FUND.VALUE_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_UNCLEAR_FUND.VALUE_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"


        ElseIf rdoClient.Checked = True Then
            strFormula = "{V_UNCLEAR_FUND.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"


        End If

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub

    Private Sub rdoSchedule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDeposit.CheckedChanged
        If rdoDeposit.Checked = True Then
            grpSchedule.Enabled = True
            grpClient.Enabled = False



        End If
    End Sub


    Private Sub rdoClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoClient.CheckedChanged
        If rdoClient.Checked = True Then
            grpSchedule.Enabled = False

            grpClient.Enabled = True


        End If
    End Sub


    Private Sub FrmRptUnclearFund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            strSql = "SELECT VALUE_DATE AS 'SCHEDULE DATE', REV_DATE AS 'REVERSE DATE', DS_CODE AS 'DS CODE', " & _
                        " D_CODE AS 'SLIP', DEPOSIT_TYPE,TOTAL AS 'AMOUNT',REMARKS,STATUS_NAME " & _
                " FROM V_UNCLEAR_FUND "


            If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then
                strCond = " VALUE_DATE>=@VALUE_DATE_FROM AND VALUE_DATE<=@VALUE_DATE_TO "
                strAndOr = " AND "
            End If

            If txtClientCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " CLIENT_CODE=@CLIENT_CODE "
                strAndOr = " AND "
            End If

            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            'strSql = strSql + " ORDER BY ACC_NAME+CLIENT_CODE,LOCATION_NAME"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@VALUE_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositDateFrom.Text))
                db.AddInParameter(commProcSche, "@VALUE_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositDateTo.Text))
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