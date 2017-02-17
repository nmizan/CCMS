Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClearingSumm

#Region "user defined codes"

    Dim _formName As String = "ClearingCheckSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _clearDate As String = ""
    Dim _custRef As String = ""
    Dim _numOfCheck As String = ""
    Dim _checkAmt As String = ""

    Dim _issueDate(1000) As String
    Dim _amount(1000) As String
    Dim _checkNo(1000) As String


    'For Auth
    Dim _aclearDate As String = ""
    Dim _acustRef As String = ""
    Dim _anumOfCheck As String = ""
    Dim _acheckAmt As String = ""

    Dim _aissueDate(1000) As String
    Dim _aamount(1000) As String
    Dim _acheckNo(1000) As String


    Dim ClerList As New List(Of String)
    Dim _clearLog As String = ""
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

        If cmbEntryLocation.SelectedIndex = -1 Then Exit Sub


        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetDetailList")

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
            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("S").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("MID")
                dgView.Item(4, i).Value = dt.Rows(i).Item("DS_CODE").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("TOTAL_CHKNO").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("TOTAL_CHKAMT").ToString()
                dgView.Item(7, i).Value = NullHelper.DateToString(dt.Rows(i).Item("OPR_DATE"))
                dgView.Item(8, i).Value = dt.Rows(i).Item("ENTRY_LOC").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("BRANCH_NAME").ToString()
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

                Dim frmClearDet As New FrmClearingDetail(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmClearDet.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmClearDet As New FrmClearingDetail
        frmClearDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmClearDet As New FrmClearingDetail(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmClearDet.Show()
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

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

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


    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadMainDataForAuth(ByVal intMID As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CHECKTOTAL  Where MID ='" & intMID & "'  and STATUS='L'").Tables(0)

            If dt.Rows.Count > 0 Then


                _aclearDate = NullHelper.DateToString(dt.Rows(0)("OPR_DATE")).ToString()

                _acustRef = dt.Rows(0)("CUSTOMER_REF").ToString()

                _anumOfCheck = dt.Rows(0)("TOTAL_CHKNO").ToString()

                _acheckAmt = dt.Rows(0)("TOTAL_CHKAMT").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------
    Private Sub LoadMainData(ByVal intMID As Integer, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@MID", DbType.Int32, intMID)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _clearDate = NullHelper.DateToString(dt.Rows(0)("OPR_DATE")).ToString()

                _custRef = dt.Rows(0)("CUSTOMER_REF").ToString()

                _numOfCheck = dt.Rows(0)("TOTAL_CHKNO").ToString()

                _checkAmt = dt.Rows(0)("TOTAL_CHKAMT").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work 22-05-2016)------------

    Private Sub LoadDetailDataForAuth(ByVal intMID As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CLEARINGTAB  Where MID ='" & intMID & "'  and STATUS='L'").Tables(0)



            If dt.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count - 1
                   
                    _aissueDate(i) = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE")).ToString()
                    _acheckNo(i) = dt.Rows(i)("CHECK_NUMBER")
                    _aamount(i) = dt.Rows(i)("DEBIT_CREDIT")

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------
    Private Sub LoadDetailData(ByVal intMID As Integer, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetDetails")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@MID", DbType.String, intMID)
            db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)

            If dt.Rows.Count > 0 Then


                For i = 0 To dt.Rows.Count - 1

                    _issueDate(i) = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE")).ToString()
                    
                    _checkNo(i) = dt.Rows(i)("CHECK_NUMBER")
                   
                    _amount(i) = dt.Rows(i)("DEBIT_CREDIT")
                    

                Next


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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_Auth")

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

                        db.AddInParameter(commProc, "@MID", DbType.Int32, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(12).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (22-05-2016)------------
                            If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                If _aclearDate <> _clearDate Then
                                    log_message = " Clearing Date : " + _aclearDate + " " + " To " + " " + _clearDate + "." + " "
                                    ClerList.Add(log_message)
                                End If

                                If _acheckAmt <> _checkAmt Then
                                    log_message = " Check Amount : " + _acheckAmt + " " + " To " + " " + _checkAmt + "." + " "
                                    ClerList.Add(log_message)
                                End If
                                If _acustRef <> _custRef Then
                                    log_message = " Customer Ref. : " + _acustRef + " " + " To " + " " + _custRef + "." + " "
                                    ClerList.Add(log_message)
                                End If
                                If _anumOfCheck <> _numOfCheck Then
                                    log_message = " Total Check No : " + _anumOfCheck + " " + " To " + " " + _numOfCheck + "." + " "
                                    ClerList.Add(log_message)
                                End If

                                'For Gridview Data

                                If _aissueDate(i) <> _issueDate(i) Then
                                    log_message = " Issue Date : " + _aissueDate(i) + " " + " To " + " " + _issueDate(i) + "." + " "
                                    ClerList.Add(log_message)
                                End If

                                If _acheckNo(i) <> _checkNo(i) Then
                                    log_message = " Check No : " + _acheckNo(i) + " " + " To " + " " + _checkNo(i) + "." + " "
                                    ClerList.Add(log_message)
                                End If
                                If _aamount(i) <> _amount(i) Then
                                    log_message = " Amount  : " + _aamount(i) + " " + " To " + " " + _amount(i) + "." + " "
                                    ClerList.Add(log_message)
                                End If

                                For Each clrInfo As String In ClerList
                                    _clearLog += clrInfo
                                Next
                                _log = " Authorized : Clearing Deposit Code : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + _clearLog

                                Logger.system_log(_log)

                                _clearLog = ""
                                ClerList.Clear()


                            Else
                                _log = " Authorized : Clearing Deposit Code : " + dgView.Rows(i).Cells(4).Value.ToString()
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