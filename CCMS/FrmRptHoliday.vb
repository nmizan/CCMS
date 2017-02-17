Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class FrmRptHoliday

    Dim _formName As String = "ReportReportsHoliday"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim rd As New crHoilday

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        Dim strAndOr As String = ""

        If txtYear.Text.Trim() <> "" Then

            strFormula = "Year ({V_HOLIDAY.HOLI_DAY})=" & txtYear.Text.Trim()

            strAndOr = " AND "

        End If

        If cmbMonth.SelectedIndex > -1 Then

            strFormula = strFormula + strAndOr + "Month ({V_HOLIDAY.HOLI_DAY})=" & (cmbMonth.SelectedIndex + 1).ToString()


        End If

        

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub




    Private Sub FrmRptHoliday_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub
End Class