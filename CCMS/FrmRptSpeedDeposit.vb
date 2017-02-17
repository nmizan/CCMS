Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmRptSpeedDeposit

    Dim _formName As String = "ReportReportsCitiSpeedDeposit"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crSpeedDeposit()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_SPEED_DEPOSIT.SCHEDULE_DATE}>=#" & NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & _
                            "# AND {V_SPEED_DEPOSIT.SCHEDULE_DATE}<=#" & NullHelper.StringToCrDateString(txtScheduleDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If


        If txtLocationCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_SPEED_DEPOSIT.LOCATION_CODE}='" & txtLocationCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_SPEED_DEPOSIT.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub





    Private Sub FrmRptSpeedDeposit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            strSql = "SELECT ACC_NAME AS CLIENT,'''' + CLIENT_CODE AS 'CLIENT CODE',MAIL_ADD AS 'ADDRESS',ACC_NO, " & _
                "BANK_NAME AS 'CORR BANK NAME',LOCATION_NAME AS LOCATION,SCHEDULE_DATE AS 'DATE', " & _
                "'''' + D_CODE AS 'DEPOSIT NO.','''' + REF_NO AS 'DEPOSIT REFERENCE',SLNO, " & _
                "'''' + CHECK_NO AS 'CHECK NO',CHECK_REF,CUSTOMER_REF,DRAWER, " & _
                "DRAWEE_BANK_NAME AS DRAWEE,AMOUNT " & _
                "FROM V_SPEED_DEPOSIT "




            If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then
                strCond = " SCHEDULE_DATE>=@SCHEDULE_DATE_FROM AND SCHEDULE_DATE<=@SCHEDULE_DATE_TO "
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

            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            strSql = strSql + " ORDER BY ACC_NAME + CLIENT_CODE,LOCATION_NAME"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtScheduleDateFrom.Text))
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_TO", DbType.Date, NullHelper.StringToDate(txtScheduleDateTo.Text))
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