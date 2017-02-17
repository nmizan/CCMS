Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class FrmRptAnyCheckCollectionReprint

    Dim _formName As String = "ReportControlsChecksCollectionReprint"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        'If txtRefDateFrom.Text.Trim() = "/  /" Then
        '    MessageBox.Show("Referance date required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub

        'End If

        If NullHelper.ToIntNum(txtRefCodeFrom.Text) > NullHelper.ToIntNum(txtRefCodeTo.Text) Then

            MessageBox.Show("[Reference Code From] must not be higher than the [Refence Code To]", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        Dim rd As New crCitiAnyCheckCollection()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        'strFormula = "{V_ANY_REMINDER.REMINDER_NO}=1 AND {V_ANY_REMINDER.REF_DATE}=#" & NullHelper.StringToCrDateString(txtRefDateFrom.Text.Trim()) & "#"

        'strFormula = "{V_ANY_REMINDER.REMINDER_NO}=1 "

        If txtRefCodeFrom.Text.Trim() <> "" Then
            'strFormula = strFormula + " AND {V_ANY_REMINDER.NONZONE_REF}>='" & txtRefCodeFrom.Text & "'" & _
            '    "AND {V_ANY_REMINDER.NONZONE_REF}<='" & txtRefCodeTo.Text & "'"
            strFormula = strFormula + " VAL({V_ANY_REMINDER.NONZONE_REF})>=" & txtRefCodeFrom.Text & "" & _
                " AND VAL({V_ANY_REMINDER.NONZONE_REF})<=" & txtRefCodeTo.Text & ""
        End If

        frmRptViewer.SetFormula(strFormula)

        frmRptViewer.Show()

    End Sub





    Private Sub FrmRptAnyCheckCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        'txtRefDateFrom.Text = Today.ToString("dd/MM/yyyy")

    End Sub

    Private Sub txtRefCodeFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRefCodeFrom.Validating
        If CommonUtil.IntValidate(txtRefCodeFrom.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtRefCodeTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRefCodeTo.Validating
        If CommonUtil.IntValidate(txtRefCodeTo.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtRefCodeFrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefCodeFrom.Validated

        If txtRefCodeFrom.Text.Trim() <> "" Then

            txtRefCodeFrom.Text = txtRefCodeFrom.Text.Trim().PadLeft(7, "0")

        End If

    End Sub

    Private Sub txtRefCodeTo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefCodeTo.Validated
        If txtRefCodeTo.Text.Trim() <> "" Then

            txtRefCodeTo.Text = txtRefCodeTo.Text.Trim().PadLeft(7, "0")

        End If
    End Sub
End Class