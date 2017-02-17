Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.Common

Public Class FrmPPMServiceControl


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (MessageBox.Show("Do you really want to save ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Try
                Dim db As New SqlDatabase(CommonAppSet.ConnStr)
                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_PPM_Service_Control")
                commProc.Parameters.Clear()
                If (rdoHour.Checked = True) Then
                    db.AddInParameter(commProc, "@Interval", DbType.Decimal, txtHour.Text.Trim())
                    db.AddInParameter(commProc, "@Time", DbType.Time, DBNull.Value)
                Else
                    db.AddInParameter(commProc, "@Interval", DbType.Decimal, DBNull.Value)
                    db.AddInParameter(commProc, "@Time", DbType.Time, dtpTime.Value.ToShortTimeString)
                End If
                db.ExecuteNonQuery(commProc)
                lblToolStatus.Text = "Information Saved Successfully !"
            Catch ex As Exception
                MessageBox.Show("Saving failed ! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub FrmPPMServiceControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim db As New SqlDatabase(CommonAppSet.ConnStr)
            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Get_PPM_Service_Detail")
            Dim ds As New DataSet()
            ds = db.ExecuteDataSet(commProc)
            If (ds.Tables(0).Rows.Count >= 1) Then
                If (String.IsNullOrEmpty(ds.Tables(0).Rows(0)("Time").ToString())) Then
                    rdoHour.Checked = True
                    txtHour.Text = ds.Tables(0).Rows(0)("Interval").ToString()
                Else
                    rdoTime.Checked = True
                    dtpTime.Value = Convert.ToDateTime(ds.Tables(0).Rows(0)("Time").ToString())
                End If
            End If
        Catch ex As Exception
            lblToolStatus.Text = ex.Message
        End Try

    End Sub
End Class