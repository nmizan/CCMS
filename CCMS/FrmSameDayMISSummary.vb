'
' Same Day MIS Summary
' Author: Md. Fahad Khan
' Since: 02-Nov-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmSameDayMISSummary

#Region "Global Variables"

    Dim _formName As String = "DepositSameDayMisSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String = ""

    'For Update
    Dim _transDate As String = ""
    Dim _cmbInsType As String = ""
    Dim _location As String = ""
    Dim _amount As String = ""
    Dim _remarks As String = ""
    Dim _clientcode As String = ""
    Dim _slipNo As String = ""
    Dim _InstruNo As String = ""
    Dim _issuBank As String = ""

    'For Auth
    Dim _atransDate As String = ""
    Dim _acmbInsType As String = ""
    Dim _alocation As String = ""
    Dim _aamount As String = ""
    Dim _aremarks As String = ""
    Dim _aclientcode As String = ""
    Dim _aslipNo As String = ""
    Dim _aInstruNo As String = ""
    Dim _aissuBank As String = ""

    Dim SameDayMISList As New List(Of String)
    Dim _dayLog As String = ""
    Dim _log As String = ""


#End Region


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

#Region "User Defined procedure"

    Private Sub LoadDataGrid()

        Try

            If dgView.Columns.Count = 0 Then Exit Sub

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMIS_GetDetailList")

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
                dgView.Item(3, i).Value = dt.Rows(i).Item("AC_NO").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("TRANSACTION_DATE").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("SLIP_NO").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("INSTRUMENT_TYPE").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("INSTRUMENT_NO").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("ISSUE_BANK").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("LOCATION").ToString()
                dgView.Item(10, i).Value = dt.Rows(i).Item("AMOUNT").ToString()
                dgView.Item(11, i).Value = dt.Rows(i).Item("CLIENT_CODE").ToString()
                dgView.Item(12, i).Value = dt.Rows(i).Item("FLAG").ToString()

                dgView.Item(13, i).Value = dt.Rows(i).Item("REMARKS").ToString()

                dgView.Item(14, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(15, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(16, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(17, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(18, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region


    Private Sub FrmSameDayMISSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmSaDay As New FrmSameDayMISDetail()
        frmSaDay.Show()
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmSaDay As New FrmSameDayMISDetail(dgView.SelectedRows.Item(0).Cells(5).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmSaDay.ShowDialog()
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

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmSaDay As New FrmSameDayMISDetail(dgView.SelectedRows.Item(0).Cells(5).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmSaDay.ShowDialog()
        End If
    End Sub

    '------------Mizan Work (22-05-2016)------------
    Private Sub LoadMainDataForAuth(ByVal strSlipNo As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From IMP_SAMEDAYMIS  Where SLIP_NO ='" & strSlipNo & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _aclientcode = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                _aslipNo = ds.Tables(0).Rows(0)("SLIP_NO").ToString()
                _atransDate = NullHelper.DateToString(ds.Tables(0).Rows(0)("TRANSACTION_DATE")).ToString
                _acmbInsType = ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString()
                _aInstruNo = ds.Tables(0).Rows(0)("INSTRUMENT_NO").ToString()
                _aissuBank = ds.Tables(0).Rows(0)("ISSUE_BANK").ToString()
                _alocation = ds.Tables(0).Rows(0)("LOCATION").ToString()
                _aamount = ds.Tables(0).Rows(0)("AMOUNT").ToString()
                _aremarks = ds.Tables(0).Rows(0)("REMARKS").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadMainData(ByVal strSlipNo As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SLIP_NO", DbType.String, strSlipNo)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _clientcode = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                _slipNo = ds.Tables(0).Rows(0)("SLIP_NO").ToString()
                _transDate = NullHelper.DateToString(ds.Tables(0).Rows(0)("TRANSACTION_DATE")).ToString
                _cmbInsType = ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString()
                _InstruNo = ds.Tables(0).Rows(0)("INSTRUMENT_NO").ToString()
                _issuBank = ds.Tables(0).Rows(0)("ISSUE_BANK").ToString()
                _location = ds.Tables(0).Rows(0)("LOCATION").ToString()
                _amount = ds.Tables(0).Rows(0)("AMOUNT").ToString()
                _remarks = ds.Tables(0).Rows(0)("REMARKS").ToString()

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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (22-05-2016)------------
                        LoadMainData(dgView.Rows(i).Cells(5).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                        If (dgView.Rows(i).Cells(1).Value) > 1 Then
                            LoadMainDataForAuth(dgView.Rows(i).Cells(5).Value.ToString())
                        End If
                        '------------Mizan Work (22-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@SLIP_NO", DbType.String, dgView.Rows(i).Cells(5).Value)
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(16).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (15-05-2016)------------

                            If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                If _atransDate <> _transDate Then
                                    log_message = " Transaction Date : " + _atransDate + " " + " To " + " " + _transDate + "." + " "
                                    SameDayMISList.Add(log_message)
                                End If
                                If _acmbInsType <> _cmbInsType Then
                                    log_message = " Instrument Type : " + _acmbInsType + " " + " To " + " " + _cmbInsType + "." + " "
                                    SameDayMISList.Add(log_message)
                                End If
                                If _aInstruNo <> _InstruNo Then
                                    log_message = " Instrument No : " + _aInstruNo + " " + " To " + " " + _InstruNo + "." + " "
                                    SameDayMISList.Add(log_message)
                                End If
                                If _aamount <> _amount Then
                                    log_message = " Amount : " + _aamount + " " + " To " + " " + _amount + "." + " "
                                    SameDayMISList.Add(log_message)
                                End If
                                If _alocation <> _location Then
                                    If _alocation = "" Then
                                        log_message = " Location : " + _location + "." + " "
                                    Else
                                        log_message = " Location : " + _alocation + " " + " To " + " " + _location + "." + " "
                                    End If
                                    SameDayMISList.Add(log_message)
                                End If
                                If _aremarks <> _remarks Then
                                    If _aremarks = "" Then
                                        log_message = " Remarks : " + _remarks + "." + " "
                                    Else
                                        log_message = " Remarks : " + _aremarks + " " + " To " + " " + _remarks + "." + " "
                                    End If
                                    SameDayMISList.Add(log_message)
                                End If
                                If _aclientcode <> _clientcode Then
                                    If _aclientcode = "" Then
                                        log_message = " Client Code : " + _clientcode + "." + " "
                                    Else
                                        log_message = " Client Code : " + _aclientcode + " " + " To " + " " + _clientcode + "." + " "
                                    End If
                                    SameDayMISList.Add(log_message)
                                End If
                                If _aissuBank <> _issuBank Then
                                    If _aissuBank = "" Then
                                        log_message = " Issue Bank : " + _issuBank + "." + " "
                                    Else
                                        log_message = " Issue Bank : " + _aissuBank + " " + " To " + " " + _issuBank + "." + " "
                                    End If
                                    SameDayMISList.Add(log_message)
                                End If


                                For Each MISInfo As String In SameDayMISList
                                    _dayLog += MISInfo
                                Next
                                _log = " Authorized : Same Day MIS SLIP NO : " + dgView.Rows(i).Cells(5).Value.ToString() + "." + " " + " Account No: " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _dayLog

                                Logger.system_log(_log)

                                _dayLog = ""
                                SameDayMISList.Clear()

                            Else

                                _log = " Authorized : Same Day MIS SLIP NO : " + dgView.Rows(i).Cells(5).Value.ToString() + "." + " " + " Account No: " + dgView.Rows(i).Cells(3).Value.ToString()

                                Logger.system_log(_log)

                            End If
                            '------------Mizan Work (22-05-2016)------------

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
End Class