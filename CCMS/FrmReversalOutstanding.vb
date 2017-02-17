'
' Manage outstanding reversal item
' Author: Iftekharul Alam Khan Lodi
' Since: 20-Feb-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmReversalOutstanding

    Private _Seq_No As Integer
    Private _Batch_No As String = ""
    Private _Ref_No As String = ""
    Dim _FileNm As String = ""

#Region "User defined Procedures"

    Dim _formName As String = "DepositOutstandingReversal"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub EnableAuth()
        If opt.IsAuth = True Then
            btnAuthorize.Enabled = True
        Else
            DisableAuth()
        End If
    End Sub

    Private Sub DisableAuth()
        btnAuthorize.Enabled = False
    End Sub


    Private Sub LoadSearchData()

        If cmbStatusSearch.Text.Trim() = "" Then
            Exit Sub
        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Reversal_Outstanding")

            db.AddInParameter(commProc, "@STATUS_ID", DbType.Int16, cmbStatusSearch.SelectedValue)
            db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, dtpReversalDate.Value)
            db.AddInParameter(commProc, "@AUTHORIZE", DbType.Int16, IIf(rdoAuthorized.Checked = True, 1, 0))

            db.AddInParameter(commProc, "@DEPOSIT_TYPE", DbType.String, NullHelper.ObjectToNull(cmbDepositType.Text.Trim()))

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                'If (i = dgView.Rows.Count - 1) Then
                '    dgView.Rows.Add()
                'End If

                dgView.Item(1, i).Value = dt.Rows(i).Item("D_CODE").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("DS_CODE").ToString()
                dgView.Item(3, i).Value = NullHelper.DateToString(dt.Rows(i).Item("REV_DATE"))
                dgView.Item(4, i).Value = dt.Rows(i).Item("CITICASH_AMOUNT").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("CITICHECK_AMOUNT").ToString()
                dgView.Item(6, i).Value = NullHelper.DateToString(dt.Rows(i).Item("VALUE_DATE"))
                dgView.Item(7, i).Value = dt.Rows(i).Item("DEPOSIT_TYPE").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("REMARKS").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("ACC_NAME").ToString()
                dgView.Item(10, i).Value = dt.Rows(i).Item("USERID").ToString()
                dgView.Item(11, i).Value = dt.Rows(i).Item("AUTHORIZER_ID").ToString()
                dgView.Item(12, i).Value = dt.Rows(i).Item("REF_NO").ToString()

            Next i

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

   

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim rowsCount, i As Integer
        rowsCount = dgView.Rows.Count

        If chkAll.Checked = True Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = True
            Next i
        ElseIf chkAll.Checked = False Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = False
            Next i
        End If
    End Sub

    
   

    

   

   
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadSearchData()

        'Dim strBank As String = ""
        'Dim i As Integer

        'For i = 0 To dgView.Rows.Count - 1
        '    If dgView(0, i).Value = False Then
        '        If strBank = "" Then
        '            strBank = "'" + dgView(1, i).Value + "'"
        '        Else
        '            strBank = strBank + ",'" + dgView(1, i).Value + "'"
        '        End If

        '    End If
        'Next i

        'MessageBox.Show(strBank)
    End Sub

    Private Sub FrmReversalOutstanding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        dtpReversalDate.Value = DateTime.Today

        lblToolStatus.Text = ""

        CommonUtil.FillComboBox("CMS_TranStatus_GetList", cmbStatusSearch)

        CommonUtil.FillComboBox("CMS_TranStatus_GetList", cmbStatusUpdate)


        Try

            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetCorrBankList")

            'Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)



            'For i = 0 To dt.Rows.Count - 1
            '    dgView.Rows.Add()
            '    'If (i = dgView.Rows.Count - 1) Then
            '    '    dgView.Rows.Add()
            '    'End If

            '    dgView.Item(1, i).Value = dt.Rows(i).Item("BANK_CODE").ToString()
            '    dgView.Item(2, i).Value = dt.Rows(i).Item("BANK_NAME").ToString()

            'Next i






        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rdoAuthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAuthorized.CheckedChanged
        If rdoAuthorized.Checked = True Then
            btnAuthorize.Enabled = False
        Else
            btnAuthorize.Enabled = True
        End If
        LoadSearchData()

    End Sub

    Private Sub rdoUnauthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUnauthorized.CheckedChanged
        'If rdoAuthorized.Checked = True Then
        '    btnAuthorize.Enabled = False
        'Else
        '    btnAuthorize.Enabled = True
        'End If
        'LoadSearchData()

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Outstanding_Update")

            Dim i, result As Integer

            For i = 0 To dgView.Rows.Count - 1
                If dgView(0, i).Value = True Then

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@D_CODE", DbType.String, dgView(1, i).Value.ToString())
                    db.AddInParameter(commProc, "@STATUS_ID", DbType.Int16, cmbStatusUpdate.SelectedValue)
                    db.AddInParameter(commProc, "@REMARKS", DbType.String, txtRemarks.Text.Trim())
                    db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, NullHelper.StringToDate(dgView(3, i).Value))

                    'db.AddInParameter(commProc, "@DEPOSIT_TYPE", DbType.String, NullHelper.ObjectToNull(cmbDepositType2.Text.Trim()))

                    db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc)
                    result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                    If result > 0 Then
                        MessageBox.Show("Update Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        LoadSearchData()

                        Exit Sub

                    End If

                End If
            Next i

            MessageBox.Show("Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


         

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadSearchData()

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Outstanding_Auth")

            Dim i, result As Integer

            For i = 0 To dgView.Rows.Count - 1
                If dgView(0, i).Value = True Then
                    'MessageBox.Show(dgView(1, i).Value.ToString() + Environment.NewLine + NullHelper.StringToDate(dgView(3, i).Value))

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@D_CODE", DbType.String, dgView(1, i).Value.ToString())
                    db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, NullHelper.StringToDate(dgView(3, i).Value))
                    db.AddInParameter(commProc, "@REF_NO", DbType.String, dgView(12, i).Value.ToString())

                    db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc)
                    result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                    If result = 3 Then

                        MessageBox.Show("Item already authorized" + Environment.NewLine + _
                                        "Deposit Code:" + dgView(1, i).Value.ToString() + Environment.NewLine + _
                                        "Schedule Code: " + dgView(2, i).Value.ToString(), _
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        LoadSearchData()

                        Exit Sub
                    ElseIf result = 5 Then

                        MessageBox.Show("You cannot authorize the transaction" + Environment.NewLine + _
                                        "Deposit Code:" + dgView(1, i).Value.ToString() + Environment.NewLine + _
                                        "Schedule Code: " + dgView(2, i).Value.ToString(), _
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        LoadSearchData()

                        Exit Sub
                    ElseIf result > 0 Then
                        MessageBox.Show("AUTH Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        LoadSearchData()

                        Exit Sub

                    End If

                End If
            Next i

            MessageBox.Show("Authorized", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadSearchData()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

    End Sub
End Class