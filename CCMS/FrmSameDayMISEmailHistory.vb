
'
' Same Day MIS Email History
' Author: Md. Fahad Khan
' Since: 20-Nov-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmSameDayMISEmailHistory

#Region "User Defined Function"

    Dim _formName As String = "DepositSameDayMISEmailHistory"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String = ""

    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_SameDayMis_GetEmailDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@MAIL_DATE", DbType.DateTime, dtpEmailDate.Value)

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = dt.Rows(i).Item("CLIENT_CODE").ToString()
                dgView.Item(1, i).Value = dt.Rows(i).Item("AC_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("MAIL_DATE")
                dgView.Item(3, i).Value = dt.Rows(i).Item("EMAIL").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("CONTENT").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("USER_ID").ToString()

            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub


#End Region

    Private Sub dtpEmailDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEmailDate.ValueChanged

    End Sub

    Private Sub FrmSameDayMISEmailHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If


        Dim i As Integer
        For i = 0 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click


        LoadDataGrid()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class