Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmFGSumm



#Region "user defined codes"

    Private Sub LoadDataGrid()

        lblToolStatus.Text = ""

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim strSql As String

            If chkShowAll.Checked = True Then


                strSql = "select f.SLNO,f.FG_ID,f.FG_NAME,f.IS_AUTHORIZED,f.MODNO,d.DEPT_NAME, " + _
                    " 'S' = " + _
                    "	CASE  " + _
                    "	    WHEN f.IS_AUTHORIZED='1' and f.STATUS = 'D' THEN 'D' " + _
                    "	    WHEN f.IS_AUTHORIZED='1' THEN 'A' " + _
                    "       ELSE 'U' " + _
                    "	End " + _
                    " from F_GROUP f left outer join (select * from DEPARTMENT where STATUS='L') d " + _
                    " on f.DEPT_SLNO=d.SLNO " & _
                    " where (f.IS_AUTHORIZED=0 OR f.STATUS in ('L','D'))  " + _
                    " and f.DEPT_SLNO =  " & cmbDept.SelectedValue & _
                    ") order by f.IS_AUTHORIZED,f.FG_NAME"

            Else

                strSql = "select f.SLNO,f.FG_ID,f.FG_NAME,f.IS_AUTHORIZED,f.MODNO,d.DEPT_NAME, " + _
                    " 'S' = " + _
                    "	CASE  " + _
                    "	    WHEN f.IS_AUTHORIZED='1' THEN 'A' " + _
                    "       ELSE 'U' " + _
                    "	End " + _
                    " from F_GROUP f left outer join (select * from DEPARTMENT where STATUS='L') d " + _
                    " on f.DEPT_SLNO=d.SLNO " & _
                    " where (f.IS_AUTHORIZED=0 OR f.STATUS ='L')  " + _
                    " and f.DEPT_SLNO =  " & cmbDept.SelectedValue & _
                    ") order by f.IS_AUTHORIZED,f.FG_NAME"


            End If




            Dim dbCommand As DbCommand = db.GetSqlStringCommand(strSql)

            Dim ds As DataSet = db.ExecuteDataSet(dbCommand)
            If ds.Tables(0).Rows.Count = 0 Then
                lblToolStatus.Text = "!! No records !!"
            End If
            dgView.AutoGenerateColumns = False
            dgView.DataSource = ds
            dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub FrmFGSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CommonUtil.FillComboBox("select SLNO,DEPT_NAME from DEPARTMENT where STATUS='L'", cmbDept)
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try

            If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing) Then
                Dim frmFgDet As New FrmFGDet(dgView.SelectedRows.Item(0).Cells(0).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmFgDet.ShowDialog()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        lblToolStatus.Text = ""

        

        If cmbDept.Text.Trim() = "" Then
            lblToolStatus.Text = "!! Select Department !!"
            Exit Sub
        End If

        LoadDataGrid()
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then
            Dim frmFgDet As New FrmFGDet(dgView.SelectedRows.Item(0).Cells(0).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmFgDet.ShowDialog()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmFgDet As New FrmFGDet
        frmFgDet.ShowDialog()
    End Sub
End Class