Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql



Public Class FrmRptDepositBreak2


    Dim _formName As String = "ReportControlsDepositBreak"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub FrmRptDepositBreak2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click


        Dim rd As New crDepositBreak2()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtDepositFrom.Text.Trim() <> "/  /" And txtDepositTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_DEPOSIT_BREAK.dScheduleDate}>=#" & NullHelper.StringToCrDateString(txtDepositFrom.Text.Trim()) & _
                "# AND {V_DEPOSIT_BREAK.dScheduleDate}<=#" & NullHelper.StringToCrDateString(txtDepositTo.Text.Trim()) & "#"

            strAndOr = " AND "
        End If

        If txtCollecFrom.Text.Trim() <> "/  /" And txtCollectTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_DEPOSIT_BREAK.cScheduleDate}>=#" & NullHelper.StringToCrDateString(txtCollecFrom.Text.Trim()) & _
                "# AND {V_DEPOSIT_BREAK.cScheduleDate}<=#" & NullHelper.StringToCrDateString(txtCollectTo.Text.Trim()) & "#"

            strAndOr = " AND "
        End If


        If cmbDepositType.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_DEPOSIT_BREAK.DEPOSIT_TYPE}='" & cmbDepositType.Text.Trim() & "'"


        End If

        If cmbStatus.SelectedIndex > -1 Then

            If cmbStatus.SelectedIndex = 0 Then

                strFormula = strFormula + strAndOr + " Not IsNull({V_DEPOSIT_BREAK.CS_CODE})"
                strAndOr = " AND "
            Else
                strFormula = strFormula + strAndOr + " IsNull({V_DEPOSIT_BREAK.CS_CODE})"
                strAndOr = " AND "

            End If




        End If


        ' frmRptViewer.SetFormula(strFormula)


        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()




    End Sub

    Private Sub btnGenerateExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateExcel.Click
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim strSql = ""

            Dim strCond = ""

            Dim strAndOr = ""

            strSql = "SELECT * FROM V_DEPOSIT_BREAK "


            If txtDepositFrom.Text.Trim() <> "/  /" And txtDepositTo.Text.Trim() <> "/  /" Then

                strCond = " dScheduleDate>=@SCHEDULE_DATE_FROM AND dScheduleDate<=@SCHEDULE_DATE_TO "
                strAndOr = " AND "
            End If

            If txtCollecFrom.Text.Trim() <> "/  /" And txtCollectTo.Text.Trim() <> "/  /" Then

                strCond = strCond + strAndOr + " cScheduleDate>=@ENTRY_DATE_FROM AND cScheduleDate<=@ENTRY_DATE_TO "
                strAndOr = " AND "
            End If


            If cmbDepositType.Text.Trim() <> "" Then

                strCond = strCond + strAndOr + " DEPOSIT_TYPE=@DEPOSIT_TYPE "
                strAndOr = " AND "

            End If

            If cmbStatus.SelectedIndex > -1 Then

                If cmbStatus.SelectedIndex = 0 Then

                    strCond = strCond + strAndOr + "  CS_CODE is Not Null "
                    strAndOr = " AND "

                Else

                    strCond = strCond + strAndOr + " CS_CODE is Null "
                    strAndOr = " AND "
                   
                End If




            End If

            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            ' strSql = strSql + " ORDER BY ACC_NAME+CLIENT_CODE"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()

            If txtDepositFrom.Text.Trim() <> "/  /" And txtDepositTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtDepositFrom.Text))
                db.AddInParameter(commProcSche, "@SCHEDULE_DATE_TO", DbType.Date, NullHelper.StringToDate(txtDepositTo.Text))
            End If

            If txtCollecFrom.Text.Trim() <> "/  /" And txtCollectTo.Text.Trim() <> "/  /" Then
                db.AddInParameter(commProcSche, "@ENTRY_DATE_FROM", DbType.Date, NullHelper.StringToDate(txtCollecFrom.Text))
                db.AddInParameter(commProcSche, "@ENTRY_DATE_TO", DbType.Date, NullHelper.StringToDate(txtCollectTo.Text))

            End If

            If cmbDepositType.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@DEPOSIT_TYPE", DbType.String, cmbDepositType.Text.Trim())

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