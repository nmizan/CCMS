Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Office.Interop

Public Class FrmClearingClientSumm

#Region "user defined codes"

    Dim _formName As String = "MaintenanceClearingClientSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _AccName As String = ""
    Dim _cmbSpCrType As String = ""
    Dim _MailAdd As String = ""
    Dim _Contact As String = ""

    

    'For Auth
    Dim _aAccName As String = ""
    Dim _acmbSpCrType As String = ""
    Dim _aMailAdd As String = ""
    Dim _aContact As String = ""

   

    Dim ClearClientList As New List(Of String)
    Dim _ClrClientLog As String = ""
    Dim _log As String = ""

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


    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetailList")

            commProc.Parameters.Clear()

            If chkShowAll.Checked = True Then
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            End If

            If rdoAuthorized.Checked = True Then
                db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)
            End If

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("S").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("ACC_NO").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("ACC_NAME").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("MAIL_ADD").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("CONTACT").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("SPEED_CR_TYPE").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(9, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(10, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(11, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(12, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub



    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try


            If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing) Then

                Dim frmClientDet As New FrmClearingClientDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmClientDet.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmClientDet As New FrmClearingClientDet
        frmClientDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmClientDet As New FrmClearingClientDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmClientDet.Show()
        End If
    End Sub





    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If Not dgView.Rows(e.RowIndex).Cells(2).Value Is Nothing Then


                If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

                ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                End If
            End If

        End If
    End Sub

  

    Private Sub rdoAuthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAuthorized.CheckedChanged

        If rdoAuthorized.Checked = True Then
            'btnAuthorize.Enabled = False
            DisableAuth()
            chkAll.Visible = False
            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = False
            End If
            chkShowAll.Visible = True



        ElseIf rdoUnauthorized.Checked = True Then
            'btnAuthorize.Enabled = True
            EnableAuth()
            chkAll.Visible = True

            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If
            chkShowAll.Visible = False

        End If

        LoadDataGrid()

    End Sub

    Private Sub rdoUnauthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUnauthorized.CheckedChanged

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


    '------------Mizan Work (19-05-2016)------------

    Private Sub LoadClientDataForAuth(ByVal strAccNo As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLEARING_CLIENT Where  ACC_NO ='" & strAccNo & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


               
                _aAccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                _acmbSpCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()

                _aMailAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                _aContact = ds.Tables(0).Rows(0)("CONTACT").ToString()


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (19-05-2016)------------
    Private Sub LoadClientData(ByVal strAccNo As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ACC_NO", DbType.String, strAccNo)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _AccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
               
                _cmbSpCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
              
                _MailAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()

                _Contact = ds.Tables(0).Rows(0)("CONTACT").ToString()

               
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   
    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Try

            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim i As Integer

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (19-05-2016)------------
                        LoadClientData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                        If (dgView.Rows(i).Cells(1).Value) > 1 Then
                            LoadClientDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                        End If
                        '------------Mizan Work (19-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@ACC_NO", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(10).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (19-05-2016)------------

                            If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                If _aAccName <> _AccName Then
                                    log_message = " Account Name : " + _aAccName + " " + " To " + " " + _AccName + "." + " "
                                    ClearClientList.Add(log_message)
                                End If
                                If _acmbSpCrType <> _cmbSpCrType Then
                                    log_message = " Speed Credit Type : " + _acmbSpCrType + " " + " To " + " " + _cmbSpCrType + "." + " "
                                    ClearClientList.Add(log_message)
                                End If
                                If _aMailAdd <> _MailAdd Then
                                    If _aMailAdd = "" Then
                                        log_message = " Mailing Address : " + _MailAdd + "." + " "
                                    Else
                                        log_message = " Mailing Address  : " + _aMailAdd + " " + " To " + " " + _MailAdd + "." + " "
                                    End If
                                    ClearClientList.Add(log_message)
                                End If
                                If _aContact <> _Contact Then
                                    If _aContact = "" Then
                                        log_message = " Contact : " + _Contact + "." + " "
                                    Else
                                        log_message = " Contact : " + _aContact + " " + " To " + " " + _Contact + "." + " "
                                    End If
                                    ClearClientList.Add(log_message)
                                End If



                                For Each clrclientInfo As String In ClearClientList
                                    _ClrClientLog += clrclientInfo
                                Next
                                _log = " Authorized : Account No : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _ClrClientLog

                                Logger.system_log(_log)

                                _ClrClientLog = ""
                                ClearClientList.Clear()
                            Else

                                If _aAccName <> _AccName Then
                                    If _aAccName = "" Then
                                        log_message = " Account Name : " + _AccName + "." + " "
                                    Else
                                        log_message = " Account Name : " + _aAccName + " " + " To " + " " + _AccName + "." + " "
                                    End If

                                    ClearClientList.Add(log_message)
                                End If


                                For Each clrclientInfo As String In ClearClientList
                                    _ClrClientLog += clrclientInfo
                                Next
                                _log = " Authorized : Account No : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _ClrClientLog

                                Logger.system_log(_log)

                                _ClrClientLog = ""
                                ClearClientList.Clear()

                            End If

                            '------------Mizan Work (19-05-2016)------------

                        ElseIf result = 1 Then

                            MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 3 Then
                            MessageBox.Show("Already authorized", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 4 Then
                            MessageBox.Show("Record not found", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 5 Then
                            MessageBox.Show("You cannot authorize the transaction", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf result = 7 Then
                            MessageBox.Show("Data mismatch! Reload records", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else
                            MessageBox.Show("Auth Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If


                Next i

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        LoadDataGrid()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

    End Sub

    Private Sub FrmClearingClientSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next
        'LoadDataGrid()
    End Sub
End Class