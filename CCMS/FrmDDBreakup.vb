'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Generate DD Break report
'Creation date      : 02-Oct-2013
'Stored Procedure(s):  
'


Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmDDBreakup


#Region "Global Variables"

    Dim _formName As String = "ReportReportsDDBreakup"
    Dim opt As SecForm = New SecForm(_formName)

#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub


    Private Sub btnViewDDBreakupReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDDBreakupReport.Click

        If txtDSCode.Text.Trim() = "" Then

            MessageBox.Show("Please enter deposit code.", "Deposit Code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDSCode.Focus()
            Exit Sub

        End If

        Dim rd As New crDDBreakupWithCheck

        rd.RecordSelectionFormula = "{V_DD_BREAKUP.dd_dcode}='" & txtDSCode.Text.Trim() & "'"


        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)


        frmRptViewer.Show()


    End Sub

    Private Sub FrmSubSysDDInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

    End Sub

    Private Sub txtDSCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDSCode.Validated
        If txtDSCode.Text.Trim() <> "" Then
            txtDSCode.Text = txtDSCode.Text.Trim().PadLeft(5, "0")
        End If
    End Sub

    Private Sub txtAccNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDSCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDSCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub btnReportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportExcel.Click

        If txtDSCode.Text.Trim() = "" Then

            MessageBox.Show("Please enter deposit code.", "Deposit Code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDSCode.Focus()
            Exit Sub

        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim strSql = ""

            Dim strCond = ""

            Dim strAndOr = ""

            strSql = "SELECT * FROM V_DD_BREAKUP "


            If txtDSCode.Text.Trim() <> "" Then
                strCond = strCond + strAndOr + " dd_dcode=@dd_dcode "
                strAndOr = " AND "
            End If

            If strCond.Trim() <> "" Then

                strSql = strSql + " WHERE " + strCond

            End If

            ' strSql = strSql + " ORDER BY ACC_NAME+CLIENT_CODE,LOCATION_NAME"

            Dim commProcSche As DbCommand = db.GetSqlStringCommand(strSql)

            commProcSche.Parameters.Clear()



            If txtDSCode.Text.Trim() <> "" Then
                db.AddInParameter(commProcSche, "@dd_dcode", DbType.String, txtDSCode.Text.Trim())
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