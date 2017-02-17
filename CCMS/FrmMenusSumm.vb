Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmMenusSumm


#Region "user defined codes"


    Private Sub LoadDataGrid()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            If chkForm.Checked = True Then

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Form_GetDetailList")

                commProc.Parameters.Clear()

                If chkShowAll.Checked = True Then
                    db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 1)
                Else
                    db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

                End If

                Dim ds As DataSet = db.ExecuteDataSet(commProc)

                dgView.Columns(3).DataPropertyName = "FORMS_NAME"

                dgView.AutoGenerateColumns = False
                dgView.DataSource = ds
                dgView.DataMember = ds.Tables(0).TableName

            ElseIf chkMenu.Checked = True Then
                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Menu_GetDetailList")

                commProc.Parameters.Clear()

                If chkShowAll.Checked = True Then
                    db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 1)
                Else
                    db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

                End If

                Dim ds As DataSet = db.ExecuteDataSet(commProc)

                dgView.Columns(3).DataPropertyName = "MENU_NAME"

                dgView.AutoGenerateColumns = False
                dgView.DataSource = ds
                dgView.DataMember = ds.Tables(0).TableName
            End If
            

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub



#End Region


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub FrmMenusSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        lblToolStatus.Text = ""

        

        LoadDataGrid()

    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try

            If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing) Then
                'dgView.SelectedRows.Item(0).Cells(0).Value 
                Dim frmMenuDet As New FrmMenusDet(dgView.SelectedRows.Item(0).Cells(0).Value, dgView.SelectedRows.Item(0).Cells(1).Value, chkForm.Checked)
                frmMenuDet.ShowDialog()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkForm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkForm.CheckedChanged

        LoadDataGrid()


    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmMenuDet As New FrmMenusDet
        frmMenuDet.ShowDialog()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then
            'dgView.SelectedRows.Item(0).Cells(0).Value 
            Dim frmMenuDet As New FrmMenusDet(dgView.SelectedRows.Item(0).Cells(0).Value, dgView.SelectedRows.Item(0).Cells(1).Value, chkForm.Checked)
            frmMenuDet.ShowDialog()
        End If
    End Sub

    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

            ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        End If
    End Sub
End Class