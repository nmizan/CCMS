Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.Common

Public Class FrmRptAnyReminder

    Dim _formName As String = "ReportManifoldChecksForReminder"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        'If txtScheduleDateFrom.Text.Trim() = "/  /" Then
        '    MessageBox.Show("Date required!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtScheduleDateFrom.Focus()
        '    Exit Sub

        'End If

        Dim rd As New crCitiAnyReminder()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        strFormula = "{V_ANY_REMINDER.REMINDER_NO}>1 "

        strAndOr = " AND "

        If txtScheduleDateFrom.Text.Trim() <> "/  /" And txtScheduleDateTo.Text.Trim() <> "/  /" Then

            strFormula = strFormula + strAndOr + "{V_ANY_REMINDER.REMINDER_DATE}>=#" & NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & _
                "# AND {V_ANY_REMINDER.REMINDER_DATE}<=#" & NullHelper.StringToCrDateString(txtScheduleDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If

        If txtDaysFrom.Text.Trim() <> "" And txtDaysTo.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_REMINDER.DAYS_OUTSTANDING}>=" & txtDaysFrom.Text.Trim() _
                + " AND {V_ANY_REMINDER.DAYS_OUTSTANDING}<=" & txtDaysTo.Text.Trim()
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_ANY_REMINDER.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtNonzoneRefFrom.Text.Trim() <> "" And txtNonzoneRefTo.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "VAL({V_ANY_REMINDER.NONZONE_REF})>=" & txtNonzoneRefFrom.Text.Trim() _
                + " AND VAL({V_ANY_REMINDER.NONZONE_REF})<=" & txtNonzoneRefTo.Text.Trim()

            strAndOr = " AND "

        End If


        'strFormula = "{V_ANY_REMINDER.REMINDER_NO}>1 AND {V_ANY_REMINDER.REMINDER_DATE}=#" & _
        'NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & "#"
        'strFormula = "{V_ANY_REMINDER.REMINDER_NO}>1 AND {V_ANY_REMINDER.REMINDER_DATE}>=#" & NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & _
        '            "# AND {V_ANY_REMINDER.REMINDER_DATE}<=#" & NullHelper.StringToCrDateString(txtScheduleDateTo.Text.Trim()) & "#"

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        'frmRptViewer.SetFormula(strFormula)


        frmRptViewer.Show()

    End Sub





    Private Sub FrmRptAnyCheckCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        txtScheduleDateFrom.Text = Today.ToString("dd/MM/yyyy")
        txtScheduleDateTo.Text = Today.ToString("dd/MM/yyyy")

    End Sub


    Private Sub txtNonzoneRef_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNonzoneRefFrom.Validated
        If txtNonzoneRefFrom.Text.Trim() <> "" Then
            txtNonzoneRefFrom.Text = txtNonzoneRefFrom.Text.Trim().PadLeft(7, "0")
        End If
    End Sub

    Private Sub txtNonzoneRefTo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNonzoneRefTo.Validated
        If txtNonzoneRefTo.Text.Trim() <> "" Then
            txtNonzoneRefTo.Text = txtNonzoneRefTo.Text.Trim().PadLeft(7, "0")
        End If
    End Sub

    Private Sub btnReminderHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderHistory.Click

        If txtCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Check No required!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtScheduleDateFrom.Focus()
            Exit Sub
        End If


        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetReminderHistByCheckNo")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CHECK_NO", DbType.String, txtCheckNo.Text.Trim())

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                Dim objExp As New ExportUtil("")

                objExp.ExportXl(dt)
            Else
                MessageBox.Show("No record found", "No record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
End Class