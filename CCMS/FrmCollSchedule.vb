'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Collection Schedule Detail
'Creation date      : 18-Oct-2012
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization


Public Class FrmCollSchedule


#Region "Global Variables"

    Dim _formName As String = "CollectionScheduleDetail"
    Dim opt As SecForm = New SecForm(_formName)


    Dim _formMode As FormTransMode
    Dim _strCSCode As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False

    Dim log_message As String

    'For Update
    Dim _sheduleDate As String = ""
    Dim _LocCode As String = ""
    'For Auth
    Dim _asheduleDate As String = ""
    Dim _aLocCode As String = ""

#End Region

#Region "User defined Codes"


    Private Sub EnableUnlock()
        If opt.IsUnlock = True Then
            btnUnlock.Enabled = True
        Else
            DisableUnlock()
        End If
    End Sub

    Private Sub DisableUnlock()
        btnUnlock.Enabled = False
    End Sub

    Private Sub EnableNew()
        If opt.IsNew = True Then
            btnNew.Enabled = True
        Else
            DisableNew()
        End If
    End Sub

    Private Sub DisableNew()
        btnNew.Enabled = False
    End Sub

    Private Sub EnableSave()
        If opt.IsSave = True Then
            btnSave.Enabled = True
        Else
            DisableSave()
        End If
    End Sub

    Private Sub DisableSave()
        btnSave.Enabled = False
    End Sub

    Private Sub EnableDelete()
        If opt.IsDelete = True Then
            btnDelete.Enabled = True
        Else
            DisableDelete()
        End If
    End Sub

    Private Sub DisableDelete()
        btnDelete.Enabled = False
    End Sub

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

    Private Sub EnableClear()
        btnClear.Enabled = True
    End Sub

    Private Sub DisableClear()
        btnClear.Enabled = False
    End Sub

    Private Sub EnableRefresh()
        btnRefresh.Enabled = True
    End Sub

    Private Sub DisableRefresh()
        btnRefresh.Enabled = False
    End Sub

    Private Sub DisableFields()

        txtCSCode.ReadOnly = True
        btnSearchCS.Enabled = False
        txtScheduleDate.ReadOnly = True
        txtLocationCode.ReadOnly = True
        btnSearchLoc.Enabled = False

        btnSearchBankBranch.Enabled = False
        txtTotalCollected.ReadOnly = True
        txtDSCode.ReadOnly = True
        txtCashAmount.ReadOnly = True
        txtTotalCheckNo.ReadOnly = True
        txtCheckAmount.ReadOnly = True
        txtReturnAmount.ReadOnly = True
        txtReturnCode.ReadOnly = True

        btnAddToGrid.Enabled = False
        btnRemoveFromGrid.Enabled = False


    End Sub

    Private Sub EnableFields()

        If _intModno = 0 Then
            txtCSCode.ReadOnly = False
            btnSearchCS.Enabled = True
        End If



        txtScheduleDate.ReadOnly = False
        txtLocationCode.ReadOnly = False
        btnSearchLoc.Enabled = True

        btnSearchBankBranch.Enabled = True
        txtTotalCollected.ReadOnly = False
        txtDSCode.ReadOnly = False
        txtCashAmount.ReadOnly = False
        txtTotalCheckNo.ReadOnly = False
        txtCheckAmount.ReadOnly = False
        txtReturnAmount.ReadOnly = False
        txtReturnCode.ReadOnly = False

        btnAddToGrid.Enabled = True
        btnRemoveFromGrid.Enabled = True

    End Sub


    Private Sub ClearFields()

        'txtCSCode.Clear()
        txtScheduleDate.Clear()
        txtLocationCode.Clear()
        lblLocationName.Text = ""
        lblCorrBankCode.Text = ""
        lblCorrBankName.Text = ""
        lblCorrBranchCode.Text = ""
        lblCorrBranchName.Text = ""
        txtTotalCollected.Clear()
        txtDSCode.Clear()
        lblDLocationName.Text = ""
        txtCashAmount.Clear()
        txtTotalCheckNo.Clear()
        txtCheckAmount.Clear()
        txtReturnAmount.Clear()
        txtReturnCode.Clear()

        dgViewAll.AllowUserToAddRows = False
        dgViewReturn.AllowUserToAddRows = False

        dgViewAll.DataSource = Nothing
        dgViewReturn.DataSource = Nothing

    End Sub

    Private Sub ClearFieldsAll()

        txtCSCode.Clear()
        txtScheduleDate.Clear()
        txtLocationCode.Clear()
        lblLocationName.Text = ""
        lblCorrBankCode.Text = ""
        lblCorrBankName.Text = ""
        lblCorrBranchCode.Text = ""
        lblCorrBranchName.Text = ""
        txtTotalCollected.Clear()
        txtDSCode.Clear()
        lblDLocationName.Text = ""
        txtCashAmount.Clear()
        txtTotalCheckNo.Clear()
        txtCheckAmount.Clear()
        txtReturnAmount.Clear()
        txtReturnCode.Clear()

        dgViewAll.AllowUserToAddRows = False
        dgViewReturn.AllowUserToAddRows = False

        dgViewAll.DataSource = Nothing
        dgViewAll.Rows.Clear()

        dgViewReturn.DataSource = Nothing
        dgViewReturn.Rows.Clear()


        _strCSCode = ""
        _intModno = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""


    End Sub

    'Private Sub ShowOpertionStatus()

    '    Dim CashTotal As Decimal = 0
    '    Dim CheckTotal As Decimal = 0
    '    Dim CheckNoTotal As Integer = 0

    '    Dim MsgStatus As String = ""


    '    For Each row As DataGridViewRow In dgViewAll.Rows

    '        CashTotal = CashTotal + NullHelper.ToDecNum(row.Cells(4).Value)
    '        CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(3).Value)

    '        CheckNoTotal = CheckNoTotal + NullHelper.ToIntNum(row.Cells(2).Value)

    '    Next

    '    If NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim()) <> CashTotal Then
    '        Dim diffCash As Decimal = CashTotal - NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim())

    '        'MsgStatus = "Mismatch in TotalCheck amount:  " & Format(diffCash , "#,##,##,##,##0.00")
    '        MsgStatus = "Mismatch in Total Cash amount:  " & diffCash.ToString() & Environment.NewLine

    '    End If

    '    If NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()) <> CheckTotal Then

    '        Dim diffCheck As Decimal = CheckTotal - NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim())
    '        MsgStatus = MsgStatus + "Mismatch in Total Check amount:  " & diffCheck.ToString() & Environment.NewLine

    '    End If

    '    If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then

    '        Dim diffCheckNo As Integer = CheckNoTotal - NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim())
    '        MsgStatus = MsgStatus + "Mismatch in Total Check No:  " & diffCheckNo.ToString() & Environment.NewLine

    '    End If

    '    If MsgStatus.Trim() <> "" Then
    '        MessageBox.Show(MsgStatus, "Mismatch Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If



    'End Sub

    Private Function CheckValidData() As Boolean


        If txtCSCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Schedule Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCSCode.Focus()
            Return False
        ElseIf txtScheduleDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Schedule Date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtScheduleDate.Focus()
            Return False
        ElseIf txtLocationCode.Text.Trim() = "" Or lblLocationName.Text.Trim() = "" Then
            MessageBox.Show("Location Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocationCode.Focus()
            Return False

        ElseIf lblCorrBankCode.Text.Trim() = "" Or lblCorrBankName.Text.Trim() = "" Then
            MessageBox.Show("Bank Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnSearchBankBranch.Focus()
            Return False

        ElseIf lblCorrBranchCode.Text.Trim() = "" Then
            MessageBox.Show("Branch Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnSearchBankBranch.Focus()
            Return False

        ElseIf txtTotalCollected.Text.Trim() = "" Then
            MessageBox.Show("Total collected amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCollected.Focus()
            Return False

            'ElseIf txtTotalCheckAmount.Text.Trim() = "" Then
            '    MessageBox.Show("Total check amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTotalCheckAmount.Focus()
            '    Return False

            'ElseIf txtTotalCheckNo.Text.Trim() = "" Then
            '    MessageBox.Show("Total check no required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTotalCheckNo.Focus()
            '    Return False

        ElseIf dgViewAll.Rows.Count = 0 Then
            MessageBox.Show("You didn't enter any record!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Dim CashTotal As Decimal = 0
        Dim CheckTotal As Decimal = 0

        For Each row As DataGridViewRow In dgViewAll.Rows

            CashTotal = CashTotal + NullHelper.ToDecNum(row.Cells(3).Value)
            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(2).Value)

        Next

        If NullHelper.ToDecNum(txtTotalCollected.Text.Trim()) <> (CashTotal + CheckTotal) Then
            Dim diffTotal As Decimal = NullHelper.ToDecNum(txtTotalCollected.Text.Trim()) - (CashTotal + CheckTotal)

            MessageBox.Show("Mismatch amount:  " & diffTotal.ToString(), "Mismatch Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Return False

        End If

        'ShowOpertionStatus()

        Return True

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@CS_CODE", DbType.String, txtCSCode.Text.Trim())
                db.AddInParameter(commProc, "@TOTAL_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCollected.Text.Trim()))

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer


                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result <> 0 Then
                    tStatus = TransState.Exist
                    trans.Rollback()
                    Return tStatus

                Else

                    intModno = 1

                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CSchedule_Add")

                    For i = 0 To dgViewAll.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@CS_CODE", DbType.String, txtCSCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@SCHEDULE_DATE", DbType.DateTime, DateTime.ParseExact(txtScheduleDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BANK_CODE", DbType.String, lblCorrBankCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BRANCH_CODE", DbType.String, lblCorrBranchCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, dgViewAll.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@CITICASH_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgViewAll.Rows(i).Cells(3).Value))
                        db.AddInParameter(commProcSche, "@CITICHECK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgViewAll.Rows(i).Cells(2).Value))
                        db.AddInParameter(commProcSche, "@NO_CHECK", DbType.Int32, NullHelper.ToIntNum(dgViewAll.Rows(i).Cells(1).Value))

                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Add
                    _strCSCode = txtCSCode.Text.Trim()
                    _intModno = 1

                    '------------Mizan Work (08-05-2016)------------

                    log_message = " Added : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + txtScheduleDate.Text.ToString()
                    Logger.system_log(log_message)

                    '------------Mizan Work (08-05-2016)------------

                End If

                trans.Commit()
                
            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@CS_CODE", DbType.String, _strCSCode)
                db.AddInParameter(commProc, "@TOTAL_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCollected.Text.Trim()))
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result = 1 Then
                    tStatus = TransState.UnspecifiedError
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 4 Then
                    tStatus = TransState.NoRecord
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 0 Then

                    intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")


                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CSchedule_Update")

                    For i = 0 To dgViewAll.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@CS_CODE", DbType.String, _strCSCode)
                        db.AddInParameter(commProcSche, "@SCHEDULE_DATE", DbType.DateTime, DateTime.ParseExact(txtScheduleDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BANK_CODE", DbType.String, lblCorrBankCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BRANCH_CODE", DbType.String, lblCorrBranchCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, dgViewAll.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@CITICASH_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgViewAll.Rows(i).Cells(3).Value))
                        db.AddInParameter(commProcSche, "@CITICHECK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgViewAll.Rows(i).Cells(2).Value))
                        db.AddInParameter(commProcSche, "@NO_CHECK", DbType.Int32, NullHelper.ToIntNum(dgViewAll.Rows(i).Cells(1).Value))
                        db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intModno)

                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Update
                    _intModno = intModno

                    trans.Commit()

                    '------------Mizan Work (08-05-2016)------------
                    If _sheduleDate <> txtScheduleDate.Text.Trim() And _LocCode <> txtLocationCode.Text.Trim() Then
                        log_message = " Updated : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + _sheduleDate + " " + " To " + " " + txtScheduleDate.Text.Trim() + "." + " " + " Location Code : " + _LocCode + " " + " To " + " " + txtLocationCode.Text.Trim()
                        Logger.system_log(log_message)
                    ElseIf _sheduleDate <> txtScheduleDate.Text.Trim() Then
                        log_message = " Updated : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + _sheduleDate + " " + " To " + " " + txtScheduleDate.Text.Trim()
                        Logger.system_log(log_message)
                    ElseIf _LocCode <> txtLocationCode.Text.Trim() Then
                        log_message = " Updated : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Location Code : " + _LocCode + " " + " To " + " " + txtLocationCode.Text.Trim()
                        Logger.system_log(log_message)
                    Else
                        log_message = " Updated : Collection Schedule Code : " + txtCSCode.Text.Trim()
                        Logger.system_log(log_message)
                    End If
                    '------------Mizan Work (08-05-2016)------------

                    Return tStatus

                End If

                trans.Rollback()


            End Using


        End If


        Return tStatus

    End Function

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@CS_CODE", DbType.String, _strCSCode)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (16-05-2016)------------
            If _asheduleDate <> _sheduleDate And _aLocCode <> _LocCode Then
                If _asheduleDate = "" And _aLocCode = "" Then
                    log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + _sheduleDate + "." + " " + " Location Code : " + _LocCode
                    Logger.system_log(log_message)
                Else
                    log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + _asheduleDate + " " + " To " + " " + _sheduleDate + "." + " " + " Location Code : " + _aLocCode + " " + " To " + " " + _LocCode
                    Logger.system_log(log_message)
                End If

            ElseIf _asheduleDate <> _sheduleDate Then
                If _asheduleDate = "" Then
                    log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + _sheduleDate
                    Logger.system_log(log_message)
                Else
                    log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Schedule Date : " + _asheduleDate + " " + " To " + " " + _sheduleDate
                    Logger.system_log(log_message)
                End If

            ElseIf _aLocCode <> _LocCode Then
                If _aLocCode = "" Then
                    log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Location Code : " + _LocCode
                    Logger.system_log(log_message)
                Else
                    log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim() + "." + " " + " Location Code : " + _aLocCode + " " + " To " + " " + _LocCode
                    Logger.system_log(log_message)
                End If

            Else

                log_message = " Authorized : Collection Schedule Code : " + txtCSCode.Text.Trim()
                Logger.system_log(log_message)
            End If
            '------------Mizan Work (16-05-2016)------------

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.AlreadyAuthorized

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.MakerCheckerSame
        ElseIf result = 7 Then
            tStatus = TransState.ModifiedOutside

        Else
            tStatus = TransState.UpdateNotPossible
        End If

        Return tStatus

    End Function

    Private Sub LoadMainData(ByVal strCSCode As String, ByVal intmod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CS_CODE", DbType.String, strCSCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intmod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strCSCode = strCSCode
                _intModno = intmod

                _formMode = FormTransMode.Update



                txtCSCode.Text = ds.Tables(0).Rows(0)("CS_CODE").ToString()
                txtTotalCollected.Text = ds.Tables(0).Rows(0)("TOTAL_AMOUNT").ToString()


                lblInputBy.Text = ds.Tables(0).Rows(0)("INPUT_BY").ToString()
                lblInputDate.Text = ds.Tables(0).Rows(0)("INPUT_DATETIME").ToString()

                _mod_datetime = ds.Tables(0).Rows(0)("INPUT_DATETIME")

                lblAuthBy.Text = ds.Tables(0).Rows(0)("AUTH_BY").ToString()
                lblAuthDate.Text = ds.Tables(0).Rows(0)("AUTH_DATETIME").ToString()

                chkAuthorized.Checked = ds.Tables(0).Rows(0)("IS_AUTH")

                If ds.Tables(0).Rows(0)("STATUS") = "L" Or ds.Tables(0).Rows(0)("STATUS") = "U" Or ds.Tables(0).Rows(0)("STATUS") = "O" Then
                    chkOpen.Checked = True
                Else
                    chkOpen.Checked = False
                End If

                _status = ds.Tables(0).Rows(0)("STATUS")

                lblModNo.Text = ds.Tables(0).Rows(0)("MOD_NO").ToString()
                lblVerNo.Text = ds.Tables(0).Rows(0)("MOD_NO").ToString()

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@CS_CODE", DbType.String, strCSCode)

                lblVerTot.Text = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()


                If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then


                    If btnUnlock.Enabled = False Then
                        EnableFields()
                        EnableClear()
                        EnableDelete()
                        EnableNew()
                        EnableRefresh()
                        EnableSave()

                    End If
                Else
                    DisableAuth()
                    DisableClear()
                    DisableDelete()
                    DisableRefresh()
                    DisableSave()

                    DisableFields()
                End If

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim = CommonAppSet.User) Then
                    EnableAuth()
                Else
                    DisableAuth()
                End If


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (16-05-2016)------------

    Private Sub LoadDetailDataForAuth(ByVal strCSCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CSCHEDULE  Where CS_CODE ='" & strCSCode & "'and STATUS='L'").Tables(0)

            If dt.Rows.Count > 0 Then
                txtScheduleDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                _asheduleDate = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE")).ToString
                txtLocationCode.Text = dt.Rows(0)("LOCATION_CODE").ToString()
                _aLocCode = dt.Rows(0)("LOCATION_CODE").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDetailData(ByVal strCSCode As String, ByVal intmod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CSchedule_GetDetails")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@CS_CODE", DbType.String, strCSCode)
            db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intmod)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)


            If dt.Rows.Count > 0 Then
                txtScheduleDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                _sheduleDate = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE")).ToString
                txtLocationCode.Text = dt.Rows(0)("LOCATION_CODE").ToString()
                _LocCode = dt.Rows(0)("LOCATION_CODE").ToString()
                lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                lblCorrBankCode.Text = dt.Rows(0)("CORR_BANK_CODE").ToString()
                lblCorrBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                lblCorrBranchCode.Text = dt.Rows(0)("CORR_BRANCH_CODE").ToString()
                lblCorrBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()

            End If

            dgViewAll.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgViewAll.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgViewAll.Rows.Count - 1) Then
                        dgViewAll.Rows.Add()
                    End If
                    dgViewAll.Item(0, i).Value = dt.Rows(i)("DS_CODE")
                    dgViewAll.Item(1, i).Value = dt.Rows(i)("NO_CHECK")
                    dgViewAll.Item(2, i).Value = dt.Rows(i)("CITICHECK_AMOUNT")
                    dgViewAll.Item(3, i).Value = dt.Rows(i)("CITICASH_AMOUNT")

                Next
                dgViewAll.AllowUserToAddRows = False

            End If



            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadCollectionScheduleData(ByVal strCSCode As String)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_GetMaxMod")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@CS_CODE", DbType.String, strCSCode)

            Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            If intModNo > 0 Then
                LoadMainData(strCSCode, intModNo)

            Else


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TotalCS_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@CS_CODE", DbType.String, _strCSCode)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Delete
            _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.UpdateNotPossible

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.UpdateNotPossible
        ElseIf result = 6 Then
            tStatus = TransState.AlreadyDeleted

        Else
            tStatus = TransState.UpdateNotPossible
        End If


        Return tStatus

    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCSCode As String, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strCSCode = strCSCode

        _intModno = intmod

    End Sub


#End Region


    Private Sub FrmCollSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intModno > 0 Then
            LoadMainData(_strCSCode, _intModno)
            LoadDetailData(_strCSCode, _intModno)
        End If



        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()

        DisableClear()
        DisableRefresh()

        DisableFields()
    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click


        lblToolStatus.Text = ""

        EnableNew()
        If Not (_strCSCode = "") Then

            If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then
                EnableFields()


                EnableClear()
                EnableDelete()
                EnableNew()
                EnableRefresh()
                EnableSave()


            Else
                DisableAuth()
                DisableClear()
                DisableDelete()
                DisableRefresh()
                DisableSave()

                DisableFields()
            End If


            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim = CommonAppSet.User) Then
                EnableAuth()
            Else
                DisableAuth()
            End If

        Else

            DisableFields()





        End If



        DisableUnlock()

        If btnNew.Enabled = True Then
            btnNew.Focus()
        End If

    End Sub

    
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        lblToolStatus.Text = ""
        _formMode = FormTransMode.Add

        EnableSave()

        ClearFieldsAll()
        EnableFields()


        DisableRefresh()
        DisableDelete()


        If txtCSCode.Enabled = True Then
            txtCSCode.Focus()
        End If


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        LoadMainData(_strCSCode, _intModno)
                        LoadDetailData(_strCSCode, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()



                    ElseIf tState = TransState.Update Then

                        LoadMainData(_strCSCode, _intModno)
                        LoadDetailData(_strCSCode, _intModno)

                        lblToolStatus.Text = "!! Information Updated Successfully !!"

                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()




                    ElseIf tState = TransState.Exist Then
                        lblToolStatus.Text = "!! Already Exist !!"
                    ElseIf tState = TransState.NoRecord Then
                        lblToolStatus.Text = "!! Nothing to Update !!"
                    ElseIf tState = TransState.DBError Then
                        lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                    ElseIf tState = TransState.UnspecifiedError Then
                        lblToolStatus.Text = "!! Unpecified Error Occured !!"
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        ClearFields()

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        LoadMainData(_strCSCode, _intModno)
        LoadDetailData(_strCSCode, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadMainData(_strCSCode, _intModno)
                    LoadDetailData(_strCSCode, _intModno)

                    DisableAuth()

                    If _strCSCode = "" Then

                        DisableDelete()
                        DisableSave()
                        DisableRefresh()
                        DisableFields()



                    End If

                    lblToolStatus.Text = "!! Information Deleted Successfully !!"

                ElseIf tState = TransState.AlreadyDeleted Then
                    lblToolStatus.Text = "!! Failed. Data is already deleted !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Delete Not Possible !!"

                ElseIf tState = TransState.Exist Then
                    lblToolStatus.Text = "!! New Delete status insertion failed !!"

                ElseIf tState = TransState.NoRecord Then
                    lblToolStatus.Text = "!! Nothing to Delete !!"
                Else
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try



    End Sub

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevVer.Click

        If _intModno - 1 > 0 Then

            LoadMainData(_strCSCode, _intModno - 1)
            LoadDetailData(_strCSCode, _intModno)

        End If

    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click

        Dim strCSCode As String = _strCSCode
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_strCSCode, _intModno + 1)

            If _intModno = 0 Then
                LoadMainData(strCSCode, intModno)
            End If

            LoadDetailData(_strCSCode, _intModno)
        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadDetailDataForAuth(_strCSCode)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_strCSCode, _intModno)
                    LoadDetailData(_strCSCode, _intModno)

                    lblToolStatus.Text = "!! Authorized Successfully !!"
                    EnableUnlock()

                    DisableNew()
                    DisableSave()
                    DisableDelete()
                    DisableAuth()

                    DisableClear()
                    DisableRefresh()

                    DisableFields()
                ElseIf tState = TransState.AlreadyAuthorized Then
                    lblToolStatus.Text = "!! Authorized Data cannot be authorized again !!"
                ElseIf tState = TransState.MakerCheckerSame Then
                    lblToolStatus.Text = "!! You cannot authorize the transaction !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Failed! Authorization Failed !!"
                ElseIf tState = TransState.ModifiedOutside Then
                    lblToolStatus.Text = "!! Failed! Data Mismatch. Reload, Check and Authorise again !!"
                ElseIf tState = TransState.DBError Then
                    lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                ElseIf tState = TransState.UnspecifiedError Then
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click
        If txtCSCode.Text.Trim() = "" Then

            MessageBox.Show("Collection schedule code required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCSCode.Focus()
            Exit Sub
        End If

        If txtScheduleDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Schedule Date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtScheduleDate.Focus()
            Exit Sub
        End If

        If txtLocationCode.Text.Trim() = "" Or lblLocationName.Text.Trim() = "" Then
            MessageBox.Show("Location Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocationCode.Focus()
            Exit Sub
        End If

        If lblCorrBankCode.Text.Trim() = "" Or lblCorrBankName.Text.Trim() = "" Then
            MessageBox.Show("Bank Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnSearchBankBranch.Focus()
            Exit Sub
        End If

        If lblCorrBranchCode.Text.Trim() = "" Then
            MessageBox.Show("Branch Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnSearchBankBranch.Focus()
            Exit Sub
        End If


        If txtDSCode.Text.Trim() = "" Then

            MessageBox.Show("Deposit schedule code required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDSCode.Focus()
            Exit Sub
        End If

        If txtCashAmount.Text.Trim() = "" Then
            MessageBox.Show("Cash amount required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCashAmount.Focus()
            Exit Sub
        End If

        If txtTotalCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Total Check No. required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckNo.Focus()
            Exit Sub
        End If

        If txtCheckAmount.Text.Trim() = "" Then
            MessageBox.Show("Check Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckAmount.Focus()
            Exit Sub
        End If



        If _RowEditMode = True Then
            Dim selRow As Integer = lblRowNo.Text.Trim()


            dgViewAll.Item(0, selRow).Value = txtDSCode.Text.Trim()
            dgViewAll.Item(1, selRow).Value = NullHelper.ToIntNum(txtTotalCheckNo.Text)
            dgViewAll.Item(2, selRow).Value = NullHelper.ToDecNum(txtCheckAmount.Text.Trim())
            dgViewAll.Item(3, selRow).Value = NullHelper.ToDecNum(txtCashAmount.Text.Trim())


            dgViewAll.Rows(0).Selected = True
            dgViewAll.Rows(0).Selected = False
            dgViewAll.Rows(selRow).Selected = True


        Else


            For Each row As DataGridViewRow In dgViewAll.Rows
                If row.Cells(0).Value.ToString().Trim() = txtDSCode.Text.Trim() Then
                    MessageBox.Show("Duplicate schedule code", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next


            dgViewAll.Rows.Add()

            Dim maxRow As Integer = dgViewAll.Rows.Count - 1

            dgViewAll.Item(0, maxRow).Value = txtDSCode.Text.Trim()
            dgViewAll.Item(1, maxRow).Value = NullHelper.ToIntNum(txtTotalCheckNo.Text)
            dgViewAll.Item(2, maxRow).Value = NullHelper.ToDecNum(txtCheckAmount.Text.Trim())
            dgViewAll.Item(3, maxRow).Value = NullHelper.ToDecNum(txtCashAmount.Text.Trim())

            dgViewAll.Rows(0).Selected = True
            dgViewAll.Rows(0).Selected = False
            dgViewAll.Rows(maxRow).Selected = True

        End If

        '--

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        '---

        Dim flagReturnAmount As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                Dim diffTotal As Decimal
                'NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CHKAMT"))

                If NullHelper.ToDecNum(txtCheckAmount.Text.Trim()) > NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CHKAMT")) Then

                    diffTotal = NullHelper.ToDecNum(txtCheckAmount.Text.Trim()) - NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CHKAMT"))

                    MessageBox.Show("Excess Check Amount: " & diffTotal.ToString(), "Mismatch Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ElseIf NullHelper.ToDecNum(txtCheckAmount.Text.Trim()) < NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CHKAMT")) Then

                    diffTotal = NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CHKAMT")) - NullHelper.ToDecNum(txtCheckAmount.Text.Trim())

                    If MessageBox.Show("Less Check Amount: " & diffTotal.ToString() & ". Return?", "Mismatch Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        flagReturnAmount = True
                    Else
                        flagReturnAmount = False
                    End If



                End If

            Else

                MessageBox.Show("No deposit schedule information found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



        '-------------

        If flagReturnAmount = True Then
            txtReturnAmount.Focus()
        Else
            txtDSCode.Clear()
            lblDLocationName.Text = ""
            txtTotalCheckNo.Clear()
            txtCheckAmount.Clear()
            txtCashAmount.Clear()
            lblRowNo.Text = ""

            txtDSCode.Focus()

        End If


        dgViewAll.Enabled = True





    End Sub

    Private Sub btnRemoveFromGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromGrid.Click

        If dgViewAll.SelectedRows.Count = 0 Then Exit Sub

        For Each row As DataGridViewRow In dgViewAll.SelectedRows
            dgViewAll.Rows.Remove(row)
        Next

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        txtDSCode.Clear()
        lblDLocationName.Text = ""
        txtTotalCheckNo.Clear()
        txtCheckAmount.Clear()
        txtCashAmount.Clear()
        lblRowNo.Text = ""


        dgViewAll.Enabled = True

    End Sub

    Private Sub txtLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtLocationCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Location List"
                frmList.ProcName = "CMS_Location_GetCorrLocList"
                frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                    Else
                        txtLocationCode.Clear()
                        lblLocationName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtLocationCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If


        End If

    End Sub

    Private Sub btnSearchBankBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBankBranch.Click

        Dim frmList As New FrmList()
        frmList.Text = "Corr. Bank Branch List"
        frmList.ProcName = "CMS_Branch_GetCorrBranchListByLoc"

        frmList.AddParamToDB("@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}, {"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
        frmList.colwidth = New Integer(,) {{1, 150}, {3, 150}}
        frmList.colrename = New String(,) {{"0", "Branch Code"}, {"1", "Branch Name"}, {"2", "Bank Code"}, {"3", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            lblCorrBankCode.Text = frmList.RowResult.Cells(2).Value.ToString()
            lblCorrBankName.Text = frmList.RowResult.Cells(3).Value.ToString()

            lblCorrBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblCorrBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()

            SendKeys.Send("{tab}")

        End If

        frmList.Dispose()


    End Sub

    Private Sub txtDSCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDSCode.Validated
       

        If txtDSCode.Text.Trim() = "" Then
            Exit Sub
        End If

        If txtDSCode.Text.Trim().Length < 5 Then
            MessageBox.Show("Not Less than 5 digit", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDSCode.Focus()
            Exit Sub

        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetDetailsByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                lblDLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
            Else
                MessageBox.Show("Invalid DS Code", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDSCode.Clear()
                txtDSCode.Focus()
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub

    
    Private Sub txtCSCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCSCode.KeyDown
        

        If e.KeyCode = Keys.Enter And txtCSCode.Text.Trim() <> "" Then

            'If txtCSCode.Text.Trim().Length < 5 Then
            '    MessageBox.Show("Not less than 5 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtCSCode.Focus()
            '    Exit Sub
            'End If


            'LoadCollectionScheduleData(txtCSCode.Text.Trim())

            'If _intModno > 0 Then
            '    txtCSCode.ReadOnly = True
            '    LoadDetailData(_strCSCode, _intModno)
            'Else


            'End If

            txtScheduleDate.Focus()
            'SendKeys.Send("{tab}")
            'SendKeys.Send("{tab}")



        End If

    End Sub

    Private Sub txtScheduleDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScheduleDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCollected_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCollected.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDSCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDSCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCashAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCashAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub dgViewAll_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewAll.CellDoubleClick

        If Not (dgViewAll.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgViewAll.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _RowEditMode = True

            btnAddToGrid.Text = "Update"
            btnCancel.Visible = True
            btnRemoveFromGrid.Enabled = False


            lblRowNo.Text = e.RowIndex.ToString()

            txtDSCode.Text = dgViewAll.Item(0, e.RowIndex).Value
            txtTotalCheckNo.Text = dgViewAll.Item(1, e.RowIndex).Value
            txtCheckAmount.Text = dgViewAll.Item(2, e.RowIndex).Value
            txtCashAmount.Text = dgViewAll.Item(3, e.RowIndex).Value
            
            dgViewAll.Enabled = False


        End If

    End Sub

    

    Private Sub txtScheduleDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtScheduleDate.Validating

        If CommonUtil.DateValidate(txtScheduleDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If


        
    End Sub

    Private Sub txtReturnAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnAmount.KeyDown

        If e.KeyCode = Keys.Enter Then
            dgViewReturn.Focus()
        End If


        'If txtReturnAmount.Text.Trim() = "" Or e.KeyCode <> Keys.Enter Then

        '    Exit Sub

        'End If



        'Try

        '    dgViewReturn.Rows.Clear()

        '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        '    Dim dt As New DataTable

        '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSDDet_GetDetailsByAmount")

        '    commProc.Parameters.Clear()

        '    db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())
        '    db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtReturnAmount.Text.Trim()))

        '    dt = db.ExecuteDataSet(commProc).Tables(0)

        '    If dt.Rows.Count > 0 Then

        '        dgViewReturn.AllowUserToAddRows = True
        '        For i = 0 To dt.Rows.Count - 1
        '            If (i = dgViewReturn.Rows.Count - 1) Then
        '                dgViewReturn.Rows.Add()
        '            End If
        '            dgViewReturn.Item(0, i).Value = "CSD"
        '            dgViewReturn.Item(1, i).Value = dt.Rows(i)("D_CODE")
        '            dgViewReturn.Item(2, i).Value = dt.Rows(i)("SLNO")
        '            dgViewReturn.Item(3, i).Value = dt.Rows(i)("CHECK_NO")
        '            dgViewReturn.Item(4, i).Value = dt.Rows(i)("DRAWEE_BANK_NAME")
        '            dgViewReturn.Item(5, i).Value = dt.Rows(i)("RTN_STATUS")

        '        Next
        '        dgViewReturn.AllowUserToAddRows = False

        '    End If

        '    Dim j As Integer = dt.Rows.Count

        '    commProc = db.GetStoredProcCommand("CMS_CCheck_GetDetailsByAmount")

        '    commProc.Parameters.Clear()

        '    db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())
        '    db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtReturnAmount.Text.Trim()))

        '    dt = db.ExecuteDataSet(commProc).Tables(0)

        '    If dt.Rows.Count > 0 Then

        '        dgViewReturn.AllowUserToAddRows = True
        '        For i = 0 To dt.Rows.Count - 1
        '            If (i + j = dgViewReturn.Rows.Count - 1) Then
        '                dgViewReturn.Rows.Add()
        '            End If
        '            dgViewReturn.Item(0, j + i).Value = "CCHECK"
        '            dgViewReturn.Item(1, j + i).Value = dt.Rows(i)("D_CODE")
        '            dgViewReturn.Item(2, j + i).Value = dt.Rows(i)("SLNO")
        '            dgViewReturn.Item(3, j + i).Value = dt.Rows(i)("CHECK_NO")
        '            dgViewReturn.Item(4, j + i).Value = dt.Rows(i)("DRAWEE_BANK_NAME")
        '            dgViewReturn.Item(5, j + i).Value = dt.Rows(i)("RTN_STATUS")

        '        Next

        '        dgViewReturn.AllowUserToAddRows = False

        '    End If


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub


    Private Sub txtReturnCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnCode.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{tab}")

        End If


        'If txtReturnCode.Text.Trim() = "" Or e.KeyCode <> Keys.Enter Then

        '    Exit Sub

        'End If

        'Dim intSlno As Integer = 0
        'Dim strDCode As String = ""
        'Dim strCSDorCCheck As String = ""

        'If Not (dgViewReturn.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgViewReturn.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

        '    intSlno = dgViewReturn.SelectedRows.Item(0).Cells(2).Value
        '    strDCode = dgViewReturn.SelectedRows.Item(0).Cells(1).Value
        '    strCSDorCCheck = dgViewReturn.SelectedRows.Item(0).Cells(0).Value
        'Else
        '    MessageBox.Show("Select item from grid and try again", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    dgViewReturn.Focus()
        'End If



        'Try


        '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        '    Dim dt As New DataTable

        '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnReject_GetDetailByCode")

        '    commProc.Parameters.Clear()

        '    db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, txtReturnCode.Text.Trim())

        '    dt = db.ExecuteDataSet(commProc).Tables(0)

        '    If dt.Rows.Count = 0 Then
        '        MessageBox.Show("Invalid Code", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtReturnCode.Clear()
        '        txtReturnCode.Focus()
        '        Exit Sub

        '    End If

        '    If MessageBox.Show(dt.Rows(0)("REJECT_REASON").ToString(), "Change Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '        If strCSDorCCheck = "CSD" Then
        '            commProc = db.GetStoredProcCommand("CMS_CSD_UpdateStatus")
        '        ElseIf strCSDorCCheck = "CCHECK" Then
        '            commProc = db.GetStoredProcCommand("CMS_CCheck_UpdateStatus")
        '        End If

        '        commProc.Parameters.Clear()

        '        db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
        '        db.AddInParameter(commProc, "@SLNO", DbType.String, intSlno)
        '        db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "R")

        '        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        '        Dim result As Integer

        '        db.ExecuteNonQuery(commProc)
        '        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        '        If result = 0 Then
        '            'success
        '            MessageBox.Show("Updated Successfull." & Environment.NewLine & _
        '                            "** Separate authorization needed for CitiSpeed/CitiCheck record", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ElseIf result = 1 Then
        '            MessageBox.Show("Error Occured", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ElseIf result = 4 Then
        '            MessageBox.Show("Record not exist", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ElseIf result = 6 Then
        '            MessageBox.Show("You can't update on a deleted record", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '        End If

        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


    End Sub

    
    Private Sub txtTotalCollected_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCollected.Validating
        If CommonUtil.DecValidate(txtTotalCollected.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCashAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCashAmount.Validating
        If CommonUtil.DecValidate(txtCashAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
            Exit Sub
        End If


        If txtDSCode.Text.Trim() <> "" Then

            Try

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetDetailByCode")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())

                Dim dt As New DataTable

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then

                    Dim diffTotal As Decimal


                    If NullHelper.ToDecNum(txtCashAmount.Text.Trim()) <> NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CASHAMT")) Then

                        diffTotal = NullHelper.ToDecNum(txtCashAmount.Text.Trim()) - NullHelper.ToDecNum(dt.Rows(0)("TOTAL_CASHAMT"))

                        If MessageBox.Show("Amount Mismatch: " & diffTotal.ToString() + Environment.NewLine + _
                                           "Want to change?", "Mismatch Data", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                            e.Cancel = True
                            txtCashAmount.Clear()
                            Exit Sub


                        Else
                            txtTotalCheckNo.Focus()

                        End If

                    End If

                Else

                    MessageBox.Show("No deposit schedule information found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Exit Sub

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub txtCheckAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCheckAmount.Validating
        If CommonUtil.DecValidate(txtCheckAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
            Exit Sub

        End If


    End Sub

    Private Sub txtTotalCheckNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCheckNo.Validating
        If CommonUtil.IntValidate(txtTotalCheckNo.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
            Exit Sub
        End If


        If txtDSCode.Text.Trim() <> "" Then

            Try

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetDetailByCode")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())

                Dim dt As New DataTable

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then

                    Dim diffTotal As Integer


                    If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> NullHelper.ToIntNum(dt.Rows(0)("TOTAL_NOCHK")) Then

                        diffTotal = NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) - NullHelper.ToIntNum(dt.Rows(0)("TOTAL_NOCHK"))

                        If MessageBox.Show("Mismatch: " & diffTotal.ToString() + Environment.NewLine + _
                                           "Want to change?", "Mismatch Data", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                            e.Cancel = True
                            txtTotalCheckNo.Clear()
                            Exit Sub


                        Else
                            txtCheckAmount.Focus()

                        End If

                    End If

                Else

                    MessageBox.Show("No deposit schedule information found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Exit Sub

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub txtCSCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCSCode.Validated

        If txtCSCode.Text.Trim() <> "" And _intModno = 0 Then

            If txtCSCode.Text.Trim().Length < 5 Then
                MessageBox.Show("Not less than 5 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCSCode.Focus()
                Exit Sub
            End If


            LoadCollectionScheduleData(txtCSCode.Text.Trim())

            If _intModno > 0 Then
                txtCSCode.ReadOnly = True
                LoadDetailData(_strCSCode, _intModno)
            Else


            End If

            'SendKeys.Send("{tab}")
            'SendKeys.Send("{tab}")



        End If

    End Sub

    Private Sub txtReturnAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtReturnAmount.Validating
        If CommonUtil.DecValidate(txtReturnAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtReturnAmount_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnAmount.Validated

        If NullHelper.ToDecNum(txtReturnAmount.Text) = 0 Then

            Exit Sub

        End If



        Try

            dgViewReturn.Rows.Clear()

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSDDet_GetDetailsByAmount")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtReturnAmount.Text.Trim()))

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                dgViewReturn.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgViewReturn.Rows.Count - 1) Then
                        dgViewReturn.Rows.Add()
                    End If
                    dgViewReturn.Item(0, i).Value = "CSD"
                    dgViewReturn.Item(1, i).Value = dt.Rows(i)("D_CODE")
                    dgViewReturn.Item(2, i).Value = dt.Rows(i)("SLNO")
                    dgViewReturn.Item(3, i).Value = dt.Rows(i)("CHECK_NO")
                    dgViewReturn.Item(4, i).Value = dt.Rows(i)("DRAWEE_BANK_NAME")
                    dgViewReturn.Item(5, i).Value = dt.Rows(i)("RTN_STATUS")

                Next
                dgViewReturn.AllowUserToAddRows = False

            End If

            'Dim j As Integer = dt.Rows.Count

            'commProc = db.GetStoredProcCommand("CMS_CCheck_GetDetailsByAmount")

            'commProc.Parameters.Clear()

            'db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDSCode.Text.Trim())
            'db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtReturnAmount.Text.Trim()))

            'dt = db.ExecuteDataSet(commProc).Tables(0)

            'If dt.Rows.Count > 0 Then

            '    dgViewReturn.AllowUserToAddRows = True
            '    For i = 0 To dt.Rows.Count - 1
            '        If (i + j = dgViewReturn.Rows.Count - 1) Then
            '            dgViewReturn.Rows.Add()
            '        End If
            '        dgViewReturn.Item(0, j + i).Value = "CCHECK"
            '        dgViewReturn.Item(1, j + i).Value = dt.Rows(i)("D_CODE")
            '        dgViewReturn.Item(2, j + i).Value = dt.Rows(i)("SLNO")
            '        dgViewReturn.Item(3, j + i).Value = dt.Rows(i)("CHECK_NO")
            '        dgViewReturn.Item(4, j + i).Value = dt.Rows(i)("DRAWEE_BANK_NAME")
            '        dgViewReturn.Item(5, j + i).Value = dt.Rows(i)("RTN_STATUS")

            '    Next

            '    dgViewReturn.AllowUserToAddRows = False

            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtReturnCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnCode.Validated

        If txtReturnCode.Text.Trim() = "" Then

            Exit Sub

        End If

        Dim intSlno As Integer = 0
        Dim strDCode As String = ""
        Dim strCSDorCCheck As String = ""

        If Not (dgViewReturn.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgViewReturn.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            intSlno = dgViewReturn.SelectedRows.Item(0).Cells(2).Value
            strDCode = dgViewReturn.SelectedRows.Item(0).Cells(1).Value
            strCSDorCCheck = dgViewReturn.SelectedRows.Item(0).Cells(0).Value
        Else
            MessageBox.Show("Select item from grid and try again", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgViewReturn.Focus()
        End If



        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnReject_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, txtReturnCode.Text.Trim())

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Invalid Code", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtReturnCode.Clear()
                txtReturnCode.Focus()
                Exit Sub

            End If

            If MessageBox.Show(dt.Rows(0)("REJECT_REASON").ToString(), "Change Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If strCSDorCCheck = "CSD" Then
                    commProc = db.GetStoredProcCommand("CMS_ReturnCSD_Add")
                    'ElseIf strCSDorCCheck = "CCHECK" Then
                    '    commProc = db.GetStoredProcCommand("CMS_CCheck_UpdateStatus")
                End If

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
                db.AddInParameter(commProc, "@SLNO", DbType.Int32, intSlno)
                db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "R")
                db.AddInParameter(commProc, "@RTN_CODE", DbType.String, txtReturnCode.Text.Trim())

                db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, DateTime.ParseExact(txtScheduleDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))



                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                If result = 0 Then
                    'success
                    MessageBox.Show("Updated Successfull." & Environment.NewLine & _
                                    "** Separate authorization needed for CitiSpeed Return record", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf result = 1 Then
                    MessageBox.Show("Error Occured", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf result = 4 Then
                    MessageBox.Show("Record not exist", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf result = 6 Then
                    MessageBox.Show("You can't update on a deleted record", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else

                    MessageBox.Show("Error Occured", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub dgViewReturn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewReturn.CellDoubleClick
        If Not (dgViewReturn.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgViewReturn.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            Dim strCode As String = InputBox("Please enter return code", "CCMS")

            If strCode.Trim() <> "" Then

                Dim intSlno As Integer = 0
                Dim strDCode As String = ""
                Dim strCSDorCCheck As String = ""

                intSlno = dgViewReturn.SelectedRows.Item(0).Cells(2).Value
                strDCode = dgViewReturn.SelectedRows.Item(0).Cells(1).Value
                strCSDorCCheck = dgViewReturn.SelectedRows.Item(0).Cells(0).Value

                Try


                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnReject_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, strCode.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Invalid Code", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'txtReturnCode.Clear()
                        'txtReturnCode.Focus()
                        Exit Sub

                    End If

                    If MessageBox.Show(dt.Rows(0)("REJECT_REASON").ToString(), "Change Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        If strCSDorCCheck = "CSD" Then
                            commProc = db.GetStoredProcCommand("CMS_ReturnCSD_Add")
                            'ElseIf strCSDorCCheck = "CCHECK" Then
                            '    commProc = db.GetStoredProcCommand("CMS_CCheck_UpdateStatus")
                        End If

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
                        db.AddInParameter(commProc, "@SLNO", DbType.Int32, intSlno)
                        db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "R")
                        db.AddInParameter(commProc, "@RTN_CODE", DbType.String, strCode.Trim())

                        db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, DateTime.ParseExact(txtScheduleDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))



                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            'success
                            MessageBox.Show("Updated Successfull." & Environment.NewLine & _
                                            "** Separate authorization needed for CitiSpeed Return record", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ElseIf result = 1 Then
                            MessageBox.Show("Error Occured", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf result = 4 Then
                            MessageBox.Show("Record not exist", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf result = 6 Then
                            MessageBox.Show("You can't update on a deleted record", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else

                            MessageBox.Show("Error Occured", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If



        End If

    End Sub

    Private Sub btnSearchLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLoc.Click

    End Sub
End Class