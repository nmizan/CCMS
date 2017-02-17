Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class FrmRptClearDeposit

    Dim _formName As String = "ReportReportsClearingDeposit"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadComboValues()


        Dim dt1 As New DataTable()

        dt1.Columns.Add("ID")
        dt1.Columns.Add("TYPE")
        Dim dr1 As DataRow = dt1.NewRow()

        dr1 = dt1.NewRow()
        dr1(0) = "1"
        dr1(1) = "Low"
        dt1.Rows.Add(dr1)

        dr1 = dt1.NewRow()
        dr1(0) = "2"
        dr1(1) = "High"
        dt1.Rows.Add(dr1)

        cmbValueType.DataSource = dt1
        cmbValueType.DisplayMember = "TYPE"
        cmbValueType.ValueMember = "ID"

        cmbValueType.SelectedIndex = -1

    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click


        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Select entry location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        Dim rd As New crCitiClearDeposit()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() <> "/  /" Then

            strFormula = "{V_CLEAR_DEPOSIT.OPR_DATE}>=#" & NullHelper.StringToCrDateString(txtDepositDateFrom.Text.Trim()) & _
                "# AND {V_CLEAR_DEPOSIT.OPR_DATE}<=#" & NullHelper.StringToCrDateString(txtDepositDateTo.Text.Trim()) & "#"

            strAndOr = " AND "

        End If


        If cmbEntryLocation.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.ENTRY_LOC}='" & cmbEntryLocation.SelectedValue & "'"
            strAndOr = " AND "

        End If

        If cmbValueType.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.VALUE_TYPE}=" & cmbValueType.SelectedValue & ""
            strAndOr = " AND "

        End If

        If txtClientCode.Text.Trim() <> "" Then

            strFormula = strFormula + strAndOr + "{V_CLEAR_DEPOSIT.REMARK}='" & txtClientCode.Text.Trim() & "'"
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

        LoadComboValues()

    End Sub


    Private Sub txtDepositDateFrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepositDateFrom.Validated

        If txtDepositDateFrom.Text.Trim() <> "/  /" And txtDepositDateTo.Text.Trim() = "/  /" Then
            If CommonUtil.DateValidate(txtDepositDateFrom.Text) = True Then
                txtDepositDateTo.Text = txtDepositDateFrom.Text
            End If
        End If

    End Sub
End Class