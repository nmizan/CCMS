
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmSetClearDate

    Dim _formName As String = "ClearingSetClearingDate"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    


    Private Sub btnSetDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDate.Click
        Dim Ref_From As String = ""
        Dim Ref_To As String = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_GenPrm_SetClearDate")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text))

            Dim dt As New DataTable

            If db.ExecuteNonQuery(commProc) > 0 Then
                MessageBox.Show("Clearing Date Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Not updated", "Message", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
            End If

            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub FrmSetClearDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_GenPrm_GetDetail")

            commProc.Parameters.Clear()

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            
            If dt.Rows.Count > 0 Then
                txtClearingDate.Text = NullHelper.DateToString(dt.Rows(0)("OPR_DATE"))
            Else
                MessageBox.Show("Genprm is corrupted", "Message", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub
End Class