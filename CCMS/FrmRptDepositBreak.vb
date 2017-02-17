Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class FrmDepositBreak

    Dim _formName As String = "ReportControlsDepositBreak"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crDepositBreak()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        If rdoDeposit.Checked = True Then
            strFormula = "{V_COLLECTION_BREAK.SCHEDULE_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_COLLECTION_BREAK.SCHEDULE_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

        End If

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub

    Private Sub rdoSchedule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDeposit.CheckedChanged
        If rdoDeposit.Checked = True Then
            grpSchedule.Enabled = True




        End If
    End Sub





    Private Sub FrmDepositBreak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub
End Class