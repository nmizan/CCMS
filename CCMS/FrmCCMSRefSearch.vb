Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmCCMSRefSearch

#Region "user defined codes"

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub





    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblToolStatus.Text = ""

        If txtRefNo.Text.Trim() = "" Then
            MessageBox.Show("Ref No required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRefNo.Focus()
            Exit Sub
        End If


        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetDetailsByRefNo")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@REF_NO", DbType.String, txtRefNo.Text.Trim())

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            If dt.Rows.Count = 0 Then
                lblToolStatus.Text = "!!! No Record Found !!!"

            End If



            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = dt.Rows(i).Item("REF_NO").ToString()
                dgView.Item(1, i).Value = dt.Rows(i).Item("DS_CODE").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("D_CODE").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("CLIENT_CODE").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("ACC_NO").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("ACC_NAME").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("LOCATION_CODE").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("LOCATION_NAME").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("CITICASH_AMOUNT").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("CITICHECK_AMOUNT").ToString()
                dgView.Item(10, i).Value = NullHelper.DateToString(dt.Rows(i).Item("SCHEDULE_DATE"))
            Next


        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()
    End Sub
End Class