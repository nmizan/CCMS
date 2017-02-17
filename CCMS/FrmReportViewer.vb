Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmReportViewer

    Public _rpt As New ReportDocument

    Public _reportFormula As String = ""

    Public Sub SetReport(ByRef rptReport As ReportDocument)

        _rpt = rptReport

    End Sub

    Public Sub SetFormula(ByVal strFormula As String)

        _reportFormula = strFormula

    End Sub

    Private Sub FrmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CommonUtil.LogonReport(_rpt)
        crViewer.ReportSource = _rpt

        If _reportFormula.Trim() <> "" Then
            crViewer.SelectionFormula = _reportFormula
        End If
        '_rpt.ExportToDisk(ExportFormatType.NoFormat, "c:\test.txt")

    End Sub

    
    Private Sub crViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crViewer.Load

    End Sub
End Class