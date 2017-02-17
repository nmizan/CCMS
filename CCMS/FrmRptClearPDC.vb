Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class FrmRptClearPDC

    Dim _formName As String = "ReportReportsPDC"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click


        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Select entry location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        Dim rd As New crClearDepositDetPDC()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_CLEAR_PDC.OPR_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_CLEAR_PDC.OPR_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If


        If cmbEntryLocation.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_PDC.ENTRY_LOC}='" & cmbEntryLocation.SelectedValue & "'"
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_PDC.REMARK}='" & txtClientCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If

        If txtBankCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_PDC.BANK_CODE}='" & txtBankCode.Text.Trim() & "'"
            strAndOr = " AND "

        End If


        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub





    Private Sub FrmRptClearCheckSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)
    End Sub
End Class