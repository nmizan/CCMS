Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmRptDDFunding

    Dim _formName As String = "ReportManifoldCitiAnywhereFundingDD"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crDDFunding()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""


        Dim strAndOr As String = ""

        If txtDDDateFrom.Text.Trim() <> "/  /" And txtDDDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_DD_FUNDING.DD_DATE}>=#" & NullHelper.StringToCrDateString(txtDDDateFrom.Text.Trim()) & _
                "# AND {V_DD_FUNDING.DD_DATE}<=#" & NullHelper.StringToCrDateString(txtDDDateTo.Text.Trim()) & "#"
            strAndOr = " AND "

        End If

        If txtDepositCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_DD_FUNDING.DEPOSIT_NO}='" & txtDepositCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub

  


    


    Private Sub FrmRptDDFunding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            strSql = "SELECT '''' + DEPOSIT_NO AS DEPOSIT_NO,DD_NO,DD_DATE,DRAWEE_BANK AS BANK,DRAWEE_BRANCH AS BRANCH,AMOUNT " & _
                " FROM dbo.V_DD_FUNDING "


            If txtDDDateFrom.Text.Trim() <> "/  /" And txtDDDateTo.Text.Trim() <> "/  /" Then
                strCond = " DD_DATE>=@DD_DATE_FROM AND DD_DATE<=@DD_DATE_TO "
                strAndOr = " AND "
            End If

            If txtDepositCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " DEPOSIT_NO=@DEPOSIT_NO "
                strAndOr = " AND "
            End If
            

            If strCond.Trim() <> "" Then
                strSql = strSql + " WHERE " + strCond
            End If

            strSql = strSql + " ORDER BY DEPOSIT_NO,DD_NO"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtDDDateFrom.Text.Trim() <> "/  /" And txtDDDateTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@DD_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDDDateFrom.Text))
                db.AddInParameter(commProcSche, "@DD_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDDDateTo.Text))
            End If

            If txtDepositCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@DEPOSIT_NO", DbType.String, txtDepositCode.Text.Trim())

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