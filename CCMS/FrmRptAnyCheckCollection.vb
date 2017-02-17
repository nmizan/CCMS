Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmRptAnyCheckCollection

    Dim _formName As String = "ReportManifoldChecksForCollection"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim Ref_From As String = ""
        Dim Ref_To As String = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_GenPrm_GetDetail")

            commProc.Parameters.Clear()

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                Ref_From = NullHelper.ObjectToString(dt.Rows(0)("NONZONE_REF_FROM")).Trim()
                Ref_To = NullHelper.ObjectToString(dt.Rows(0)("NONZONE_REF_TO")).Trim()


            Else

                MessageBox.Show("GenPrm is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try




        Dim rd As New crCitiAnyCheckCollection()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""


        strFormula = "{V_ANY_REMINDER.REMINDER_NO}=1 AND {V_ANY_REMINDER.REF_DATE}=#" & NullHelper.StringToCrDateString(txtScheduleDateFrom.Text.Trim()) & "#"

        If Ref_From <> "" And Ref_To <> "" Then
            strFormula = strFormula & " AND {V_ANY_REMINDER.NONZONE_REF}>='" & Ref_From & "'" & _
                "AND {V_ANY_REMINDER.NONZONE_REF}<='" & Ref_To & "'"
        End If

        frmRptViewer.SetFormula(strFormula)

        frmRptViewer.Show()

    End Sub










    Private Sub FrmRptAnyCheckCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        txtScheduleDateFrom.Text = Today.ToString("dd/MM/yyyy")

    End Sub
End Class