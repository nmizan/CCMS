﻿Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmScheduleStockSumm

#Region "user defined codes"

    Dim _formName As String = "MaintenanceScheduleStockSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _SchdFrom As String = ""
    Dim _SchdTo As String = ""

    'For Auth
    Dim _aSchdFrom As String = ""
    Dim _aSchdTo As String = ""

    Dim StockList As New List(Of String)
    Dim _StockLog As String = ""
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

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_GetDetailList")

            commProc.Parameters.Clear()

            If rdoDeposit.Checked = True Then
                db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, 2)
            End If

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
                dgView.Item(1, i).Value = dt.Rows(i).Item("SCHEDULE_ID").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("S").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("BANK_CODE").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("BANK_NAME").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("LOCATION_CODE").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("LOCATION_NAME").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("SCHE_FROM").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("SCHE_UPTO").ToString()
                dgView.Item(10, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(11, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(12, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(13, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(14, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
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

                Dim frmScheStockDet As New FrmScheduleStockDet(dgView.SelectedRows.Item(0).Cells(1).Value, dgView.SelectedRows.Item(0).Cells(4).Value, dgView.SelectedRows.Item(0).Cells(6).Value, dgView.SelectedRows.Item(0).Cells(2).Value)
                frmScheStockDet.ShowDialog()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmScheStockDet As New FrmScheduleStockDet()
        frmScheStockDet.ShowDialog()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmScheStockDet As New FrmScheduleStockDet(dgView.SelectedRows.Item(0).Cells(1).Value, dgView.SelectedRows.Item(0).Cells(4).Value, dgView.SelectedRows.Item(0).Cells(6).Value, dgView.SelectedRows.Item(0).Cells(2).Value)
            frmScheStockDet.ShowDialog()
        End If
    End Sub

    Private Sub FrmBankSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next
    End Sub




    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If dgView.Rows(e.RowIndex).Cells(3).Value.ToString() = "D" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

            ElseIf dgView.Rows(e.RowIndex).Cells(3).Value.ToString() = "U" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        End If
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

    '------------Mizan Work (19-05-2016)------------

    Private Sub LoadScheduleDataForAuth(ByVal intScheduleId As Integer, ByVal strBankCode As String, ByVal strLocationCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From SCHEDULE_STOCK Where SCHEDULE_ID ='" & intScheduleId & "' and BANK_CODE ='" & strBankCode & "' and LOCATION_CODE ='" & strLocationCode & "' and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _aSchdFrom = ds.Tables(0).Rows(0)("SCHE_FROM").ToString()
                _aSchdTo = ds.Tables(0).Rows(0)("SCHE_UPTO").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (19-05-2016)------------

    Private Sub LoadScheduleData(ByVal intScheduleId As Integer, ByVal strBankCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, intScheduleId)
            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, strBankCode)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, strLocationCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                
                _SchdFrom = ds.Tables(0).Rows(0)("SCHE_FROM").ToString()
                _SchdTo = ds.Tables(0).Rows(0)("SCHE_UPTO").ToString()

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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (19-05-2016)------------
                        LoadScheduleData(dgView.Rows(i).Cells(1).Value, dgView.Rows(i).Cells(4).Value.ToString(), dgView.Rows(i).Cells(6).Value.ToString(), dgView.Rows(i).Cells(2).Value)

                        If (dgView.Rows(i).Cells(2).Value) > 1 Then
                            LoadScheduleDataForAuth(dgView.Rows(i).Cells(1).Value, dgView.Rows(i).Cells(4).Value.ToString(), dgView.Rows(i).Cells(6).Value.ToString())
                        End If
                        '------------Mizan Work (19-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, dgView.Rows(i).Cells(4).Value.ToString())
                        db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, dgView.Rows(i).Cells(6).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(2).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(12).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (19-05-2016)------------

                            If (dgView.Rows(i).Cells(2).Value) > 1 Then

                                If _aSchdFrom <> _SchdFrom Then
                                    If _aSchdFrom = "" Then
                                        log_message = " Schedule No From : " + _SchdFrom + "." + " "
                                    Else
                                        log_message = " Schedule No From : " + _aSchdFrom + " " + " To " + " " + _SchdFrom + "." + " "
                                    End If
                                    StockList.Add(log_message)
                                End If
                                If _aSchdTo <> _SchdTo Then
                                    If _aSchdTo = "" Then
                                        log_message = " Schedule No Up To  : " + _SchdTo + "." + " "
                                    Else
                                        log_message = " Schedule No Up To  : " + _aSchdTo + " " + " To " + " " + _SchdTo + "." + " "
                                    End If
                                    StockList.Add(log_message)
                                End If


                                For Each stockInfo As String In StockList
                                    _StockLog += stockInfo
                                Next

                                _log = " Authorized : Schedule ID : " + dgView.Rows(i).Cells(1).Value + "." + " " + " Bank Code : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Location Code : " + dgView.Rows(i).Cells(6).Value.ToString() + "." + " " + _StockLog

                                Logger.system_log(_log)

                                _StockLog = ""
                                StockList.Clear()

                            Else

                                _log = " Authorized : Schedule ID : " + dgView.Rows(i).Cells(1).Value + "." + " " + " Bank Code : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Location Code : " + dgView.Rows(i).Cells(6).Value.ToString() + "." + " "

                                Logger.system_log(_log)

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
End Class