Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmDepoScheMismatchTotal

    Dim _formName As String = "DepositScheduleMismatchTotal"
    Dim opt As SecForm = New SecForm(_formName)

#Region "user defined codes"

    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetMismatchDetail")

            commProc.Parameters.Clear()

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(1, i).Value = dt.Rows(i).Item("DS_CODE").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("TOTAL_NOCHK").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("TOTAL_CHKAMT").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("TOTAL_CASHAMT").ToString()
                dgView.Item(5, i).Value = NullHelper.DateToString(dt.Rows(i).Item("ENTRY_DATE"))
                dgView.Item(6, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(7, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(8, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(9, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))

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

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try


            If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing) Then

                Dim frmDepoScheDet As New FrmDepoSchedule(dgView.SelectedRows.Item(0).Cells(1).Value, dgView.SelectedRows.Item(0).Cells(0).Value)
                frmDepoScheDet.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            Dim frmDepoScheDet As New FrmDepoSchedule(dgView.SelectedRows.Item(0).Cells(1).Value, dgView.SelectedRows.Item(0).Cells(0).Value)
            frmDepoScheDet.Show()
        End If
    End Sub
End Class