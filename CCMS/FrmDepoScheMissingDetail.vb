Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmDepoScheMissingDetail

    Dim _formName As String = "DepositScheduleMismatchCashSpeed"
    Dim opt As SecForm = New SecForm(_formName)

#Region "user defined codes"

    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetMissingDetail")

            commProc.Parameters.Clear()

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = dt.Rows(i).Item("DS_CODE")
                dgView.Item(1, i).Value = dt.Rows(i).Item("D_CODE")
                dgView.Item(2, i).Value = dt.Rows(i).Item("DEPOSIT_TYPE")
                dgView.Item(2, i).Value = dt.Rows(i).Item("CLIENT_CODE")
                dgView.Item(3, i).Value = dt.Rows(i).Item("CITICHECK_AMOUNT")
                dgView.Item(4, i).Value = dt.Rows(i).Item("CITICASH_AMOUNT")
                

                'dgView.Item(0, i).Value = dt.Rows(i).Item("DS_CODE").ToString()
                'dgView.Item(1, i).Value = dt.Rows(i).Item("D_CODE").ToString()
                'dgView.Item(2, i).Value = dt.Rows(i).Item("DEPOSIT_TYPE").ToString()
                'dgView.Item(3, i).Value = dt.Rows(i).Item("ACC_NAME").ToString()
                'dgView.Item(4, i).Value = dt.Rows(i).Item("ACC_NO").ToString()
                'dgView.Item(5, i).Value = dt.Rows(i).Item("CITICHECK_AMOUNT").ToString()
                'dgView.Item(6, i).Value = dt.Rows(i).Item("CITICASH_AMOUNT").ToString()
                'dgView.Item(7, i).Value = dt.Rows(i).Item("LOCATION_NAME").ToString()
                'dgView.Item(8, i).Value = dt.Rows(i).Item("BANK_NAME").ToString()
                'dgView.Item(9, i).Value = dt.Rows(i).Item("BRANCH_NAME").ToString()
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub




    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub











    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

    End Sub


    Private Sub FrmDepoScheMissingDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        'LoadDataGrid()
    End Sub
End Class