Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmDepoScheSumm

#Region "user defined codes"

    Dim _formName As String = "DepositScheduleSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _ScheduleDate As String = ""
    Dim _TotalCheckNo As String = ""
    Dim _TotalCheckAmt As String = ""
    Dim _TotalCashAmt As String = ""

    'For Auth
    Dim _aScheduleDate As String = ""
    Dim _aTotalCheckNo As String = ""
    Dim _aTotalCheckAmt As String = ""
    Dim _aTotalCashAmt As String = ""

    Dim ScheduleList As New List(Of String)
    Dim _scheduleLog As String = ""
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

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetDetailList")

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

            db.AddInParameter(commProc, "@ENTRY_DATE", DbType.DateTime, dtpEntryDate.Value)

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("S").ToString()

                dgView.Item(3, i).Value = dt.Rows(i).Item("DS_CODE").ToString()
                dgView.Item(4, i).Value = NullHelper.DateToString(dt.Rows(i).Item("SCHEDULE_DATE"))
                dgView.Item(5, i).Value = dt.Rows(i).Item("TOTAL_NOCHK").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("TOTAL_CHKAMT").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("TOTAL_CASHAMT").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(9, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(10, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(11, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(12, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
                dgView.Item(13, i).Value = dt.Rows(i).Item("STATUS").ToString()
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

                Dim frmDepoScheDet As New FrmDepoSchedule(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmDepoScheDet.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmDepoSchedule As New FrmDepoSchedule
        frmDepoSchedule.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmDepoScheDet As New FrmDepoSchedule(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmDepoScheDet.Show()
        End If
    End Sub

    Private Sub FrmBankSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        dtpEntryDate.Value = DateTime.Today

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

        If rdoUnauthorized.Checked = True Then
            chkAll.Visible = True
            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If
        End If

    End Sub




    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count) Then
            'If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
            '    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

            'ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
            '    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            'End If

            If dgView.Rows(e.RowIndex).Cells(13).Value.ToString() = "D" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red

            End If

        End If
    End Sub


    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadMainDataForAuth(ByVal strDSCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From DCOLLECTED Where DS_CODE ='" & strDSCode & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _aTotalCheckNo = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_NOCHK")).ToString

                _aTotalCheckAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT")).ToString

                _aTotalCashAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CASHAMT")).ToString

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadMainData(ByVal strDSCode As String, ByVal intmod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DS_CODE", DbType.String, strDSCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intmod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _TotalCheckNo = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_NOCHK")).ToString

                _TotalCheckAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT")).ToString

                _TotalCashAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CASHAMT")).ToString


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadDetailDataForAuth(ByVal strDSCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From DSCHEDULE Where DS_CODE ='" & strDSCode & "'  and STATUS='L'").Tables(0)


            If dt.Rows.Count > 0 Then

                _aScheduleDate = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE")).ToString
                
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadDetailData(ByVal strDSCode As String, ByVal intmod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetDetails")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, strDSCode)
            db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intmod)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)


            If dt.Rows.Count > 0 Then

                _ScheduleDate = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE")).ToString

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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (22-05-2016)------------
                        LoadMainData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)
                        LoadDetailData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                        If (dgView.Rows(i).Cells(1).Value) > 1 Then
                            LoadMainDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                            LoadDetailDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                        End If
                        '------------Mizan Work (22-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@DS_CODE", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(10).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (22-05-2016)------------

                            If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                If _aScheduleDate <> _ScheduleDate Then
                                    log_message = " Schedule Date : " + _aScheduleDate + " " + " To " + " " + _ScheduleDate + "." + " "
                                    ScheduleList.Add(log_message)
                                End If
                               
                                If _aTotalCheckNo <> _TotalCheckNo Then
                                    log_message = " Total Check No : " + _aTotalCheckNo + " " + " To " + " " + _TotalCheckNo + "." + " "
                                    ScheduleList.Add(log_message)
                                End If
                                If _aTotalCheckAmt <> _TotalCheckAmt Then
                                    log_message = " Total Check Amount : " + _aTotalCheckAmt + " " + " To " + " " + _TotalCheckAmt + "." + " "
                                    ScheduleList.Add(log_message)
                                End If
                                If _aTotalCashAmt <> _TotalCashAmt Then
                                    log_message = " Total Cash Amount : " + _aTotalCashAmt + " " + " To " + " " + _TotalCashAmt + "." + " "
                                    ScheduleList.Add(log_message)
                                End If

                                For Each depoInfo As String In ScheduleList
                                    _scheduleLog += depoInfo
                                Next
                                _log = " Authorized : Deposit Schedule Code  : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _scheduleLog

                                Logger.system_log(_log)

                                _scheduleLog = ""
                                ScheduleList.Clear()

                            Else

                                _log = " Authorized : Deposit Schedule Code  : " + dgView.Rows(i).Cells(3).Value.ToString()

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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

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

            dtpEntryDate.Enabled = True



        ElseIf rdoUnauthorized.Checked = True Then
            'btnAuthorize.Enabled = True
            EnableAuth()
            chkAll.Visible = True

            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If
            chkShowAll.Visible = False

            dtpEntryDate.Enabled = False

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


    Private Sub dtpEntryDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEntryDate.ValueChanged
        LoadDataGrid()
    End Sub

  
End Class