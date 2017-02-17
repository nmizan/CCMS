'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Delivery Schedule Detail
'Creation date      : 12-Dec-2012
'Stored Procedure(s):  
'
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmDepoSchedule


#Region "Global Variables"

    Dim _formName As String = "DepositScheduleDetail"
    Dim opt As SecForm = New SecForm(_formName)


    Dim _formMode As FormTransMode
    Dim _strDSCode As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False


    Dim _ColFileName As String
    'Dim _ColRefNo As String
    'Dim _ColFileUserId As String
    'Dim _ColSeqNo As String
    Dim _ColChecked As String
    'Dim _ColFlexGenDate As String

    Dim _isFileExist As Boolean = False
    Dim _IsResetRow As Boolean = False

    Dim log_message As String

    'For Update
    Dim _ScheduleDate As String = ""
    Dim _LocCode As String = ""
    Dim _TotalCheckNo As String = ""
    Dim _TotalCheckAmt As String = ""
    Dim _TotalCashAmt As String = ""


    Dim _clientCode(1000) As String
    Dim _NumOfCheck(1000) As String
    Dim _citiCheckAmt(1000) As String
    Dim _citiCashAmt(1000) As String
    

    'For Auth
    Dim _aScheduleDate As String = ""
    Dim _aLocCode As String = ""
    Dim _aTotalCheckNo As String = ""
    Dim _aTotalCheckAmt As String = ""
    Dim _aTotalCashAmt As String = ""

    Dim _aclientCode(1000) As String
    Dim _aNumOfCheck(1000) As String
    Dim _acitiCheckAmt(1000) As String
    Dim _acitiCashAmt(1000) As String

    Dim ScheduleList As New List(Of String)
    Dim _scheduleLog As String = ""
    Dim _log As String = ""

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

        txtDepoScheCode.ReadOnly = True
        'btnSearchDS.Enabled = False
        txtScheduleDate.ReadOnly = True
        txtLocationCode.ReadOnly = True
        btnSearchLocation.Enabled = False
        'txtCorrBankCode.ReadOnly = True
        btnSearchBank.Enabled = False
        'txtCorrBranchCode.ReadOnly = True

        txtTotalCheckNo.ReadOnly = True
        txtTotalCheckAmount.ReadOnly = True
        txtTotalCashAmount.ReadOnly = True

        txtDepoCode.ReadOnly = True
        txtClientCode.ReadOnly = True
        btnSearchClient.Enabled = False

        chkDepositType.Enabled = False

        txtCheckNo.ReadOnly = True
        txtCitiCheckAmount.ReadOnly = True
        txtCitiCashAmount.ReadOnly = True


        btnAddToGrid.Enabled = False
        btnRemoveFromGrid.Enabled = False

        btnCancel.Visible = False

        'dgView.ReadOnly = True



    End Sub

    Private Sub EnableFields()

        If _intModno = 0 Then
            txtDepoScheCode.ReadOnly = False
            'btnSearchDS.Enabled = True
        End If

        
        txtScheduleDate.ReadOnly = False
        txtLocationCode.ReadOnly = False
        btnSearchLocation.Enabled = True
        'txtCorrBankCode.ReadOnly = False
        btnSearchBank.Enabled = True
        'txtCorrBranchCode.ReadOnly = False

        txtTotalCheckNo.ReadOnly = False
        txtTotalCheckAmount.ReadOnly = False
        txtTotalCashAmount.ReadOnly = False

        txtDepoCode.ReadOnly = False
        txtClientCode.ReadOnly = False
        btnSearchClient.Enabled = True

        chkDepositType.Enabled = True

        txtCheckNo.ReadOnly = False
        txtCitiCheckAmount.ReadOnly = False
        txtCitiCashAmount.ReadOnly = False

        btnAddToGrid.Enabled = True
        btnRemoveFromGrid.Enabled = True

        btnCancel.Visible = False
        ''''''


        

        'dgView.ReadOnly = False
        'dgView.Columns(1).ReadOnly = True



    End Sub


    Private Sub ClearFields()

        txtScheduleDate.Clear()
        txtLocationCode.Clear()
        lblLocationName.Text = ""

        txtCorrBankCode.Clear()
        lblCorrBankName.Text = ""

        txtCorrBranchCode.Clear()
        lblCorrBranchName.Text = ""

        txtTotalCheckNo.Clear()
        txtTotalCheckAmount.Clear()
        txtTotalCashAmount.Clear()

        txtDepoCode.Clear()
        txtClientCode.Clear()
        lblAccName.Text = ""
        lblAccNo.Text = ""

        chkDepositType.Checked = False

        txtCheckNo.Clear()
        txtCitiCheckAmount.Clear()
        txtCitiCashAmount.Clear()


        dgView.AllowUserToAddRows = False



        'dgView.DataSource = Nothing

    End Sub

    Private Sub ClearFieldsAll()

        _ColFileName = ""
        _ColChecked = ""

        lblEntryDate.Text = ""

        txtDepoScheCode.Clear()
        txtScheduleDate.Clear()
        txtLocationCode.Clear()
        lblLocationName.Text = ""

        txtCorrBankCode.Clear()
        lblCorrBankName.Text = ""

        txtCorrBranchCode.Clear()
        lblCorrBranchName.Text = ""

        txtTotalCheckNo.Clear()
        txtTotalCheckAmount.Clear()
        txtTotalCashAmount.Clear()

        txtDepoCode.Clear()
        txtClientCode.Clear()
        lblAccName.Text = ""
        lblAccNo.Text = ""

        chkDepositType.Checked = False

        txtCheckNo.Clear()
        txtCitiCheckAmount.Clear()
        txtCitiCashAmount.Clear()

        dgView.AllowUserToAddRows = False

        dgView.DataSource = Nothing
        dgView.Rows.Clear()

        ShowGridTotal()



        _strDSCode = ""
        _intModno = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""

        _IsResetRow = False


    End Sub


    Private Sub ShowGridTotal()

        Dim CashTotal As Decimal = 0
        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0


        For Each row As DataGridViewRow In dgView.Rows

            CashTotal = CashTotal + NullHelper.ToDecNum(row.Cells(6).Value)
            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(5).Value)

            CheckNoTotal = CheckNoTotal + NullHelper.ToIntNum(row.Cells(4).Value)

        Next

        lblTotalCheckNo.Text = CheckNoTotal.ToString()
        lblTotalCheckAmount.Text = CheckTotal.ToString()
        lblTotalCashAmount.Text = CashTotal.ToString()

        If NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim()) <> CashTotal Then
            lblTotalCashAmount.ForeColor = Color.Red
        Else
            lblTotalCashAmount.ForeColor = Color.Black
        End If

        If NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()) <> CheckTotal Then
            lblTotalCheckAmount.ForeColor = Color.Red
        Else
            lblTotalCheckAmount.ForeColor = Color.Black
        End If

        If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then
            lblTotalCheckNo.ForeColor = Color.Red
        Else
            lblTotalCheckNo.ForeColor = Color.Black
        End If
        

    End Sub


    Private Sub FixSerialNo()

        Dim flagEmptySerialFound As Boolean = False

        For Each row As DataGridViewRow In dgView.Rows

            If NullHelper.ToIntNum(row.Cells(14).Value) = 0 Then
                flagEmptySerialFound = True
                Exit For
            End If

        Next

        If flagEmptySerialFound = True Then


            Dim MaxSlNo As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                If MaxSlNo <= NullHelper.ToIntNum(row.Cells(14).Value) Then
                    MaxSlNo = NullHelper.ToIntNum(row.Cells(14).Value) + 1
                End If


            Next


            For Each row As DataGridViewRow In dgView.Rows

                If NullHelper.ToIntNum(row.Cells(14).Value) = 0 Then
                    row.Cells(14).Value = MaxSlNo
                    MaxSlNo = MaxSlNo + 1
                End If

            Next

        End If

        '---------------

       

    End Sub


    Private Sub ShowOpertionStatus()

        Dim CashTotal As Decimal = 0
        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0

        Dim MsgStatus As String = ""


        For Each row As DataGridViewRow In dgView.Rows

            CashTotal = CashTotal + NullHelper.ToDecNum(row.Cells(6).Value)
            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(5).Value)

            CheckNoTotal = CheckNoTotal + NullHelper.ToIntNum(row.Cells(4).Value)

        Next

        If NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim()) <> CashTotal Then
            Dim diffCash As Decimal = CashTotal - NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim())

            'MsgStatus = "Mismatch in TotalCheck amount:  " & Format(diffCash , "#,##,##,##,##0.00")
            MsgStatus = "Mismatch in Total Cash amount:  " & diffCash.ToString() & Environment.NewLine

        End If

        If NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()) <> CheckTotal Then

            Dim diffCheck As Decimal = CheckTotal - NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim())
            MsgStatus = MsgStatus + "Mismatch in Total Check amount:  " & diffCheck.ToString() & Environment.NewLine

        End If

        If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then

            Dim diffCheckNo As Integer = CheckNoTotal - NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim())
            MsgStatus = MsgStatus + "Mismatch in Total Check No:  " & diffCheckNo.ToString() & Environment.NewLine

        End If

        If MsgStatus.Trim() <> "" Then
            MessageBox.Show(MsgStatus, "Mismatch Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If



    End Sub


    Private Sub ResetIsRowChangedValue()

        If _IsResetRow = False And chkAuthorized.Checked = True Then

            For Each row As DataGridViewRow In dgView.Rows


                row.Cells(15).Value = False

            Next

            _IsResetRow = True




        End If



    End Sub


    Private Function CheckValidData() As Boolean


        If txtDepoScheCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Schedule Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoScheCode.Focus()
            Return False
        ElseIf txtScheduleDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Schedule Date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtScheduleDate.Focus()
            Return False
        ElseIf txtLocationCode.Text.Trim() = "" Or lblLocationName.Text.Trim() = "" Then
            MessageBox.Show("Location Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocationCode.Focus()
            Return False

        ElseIf txtCorrBankCode.Text.Trim() = "" Or lblCorrBankName.Text.Trim() = "" Then
            MessageBox.Show("Bank Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCorrBankCode.Focus()
            Return False

        ElseIf txtTotalCashAmount.Text.Trim() = "" Then
            MessageBox.Show("Total cash amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCashAmount.Focus()
            Return False

        ElseIf txtTotalCheckAmount.Text.Trim() = "" Then
            MessageBox.Show("Total check amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckAmount.Focus()
            Return False

        ElseIf txtTotalCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Total check no required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckNo.Focus()
            Return False

        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("You didn't enter any record!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If


        ShowOpertionStatus()



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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDepoScheCode.Text.Trim())
                db.AddInParameter(commProc, "@TOTAL_NOCHK", DbType.Int32, NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CASHAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim()))

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

                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_Add")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, txtDepoScheCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@D_CODE", DbType.String, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@DEPOSIT_TYPE", DbType.String, dgView.Rows(i).Cells(7).Value)
                        db.AddInParameter(commProcSche, "@CITICASH_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(6).Value))
                        db.AddInParameter(commProcSche, "@CITICHECK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(5).Value))
                        db.AddInParameter(commProcSche, "@SCHEDULE_DATE", DbType.DateTime, DateTime.ParseExact(txtScheduleDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        db.AddInParameter(commProcSche, "@NO_CHECK", DbType.Int32, NullHelper.ToIntNum(dgView.Rows(i).Cells(4).Value))
                        db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BANK_CODE", DbType.String, txtCorrBankCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BRANCH_CODE", DbType.String, txtCorrBranchCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(14).Value)
                        db.AddInParameter(commProcSche, "@IS_ROW_CHG", SqlDbType.Bit, dgView.Rows(i).Cells(15).Value)

                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Add
                    _strDSCode = txtDepoScheCode.Text.Trim()
                    _intModno = 1
                    '------------Mizan Work (08-05-2016)------------

                    log_message = " Added : Deposit Schedule Code : " + txtDepoScheCode.Text.Trim()
                    Logger.system_log(log_message)

                    '------------Mizan Work (08-05-2016)------------


                End If

                trans.Commit()

               

            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@DS_CODE", DbType.String, _strDSCode)
                db.AddInParameter(commProc, "@TOTAL_NOCHK", DbType.Int32, NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CASHAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim()))
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


                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_Update")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, _strDSCode)
                        db.AddInParameter(commProcSche, "@D_CODE", DbType.String, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@DEPOSIT_TYPE", DbType.String, dgView.Rows(i).Cells(7).Value)
                        db.AddInParameter(commProcSche, "@CITICASH_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(6).Value))
                        db.AddInParameter(commProcSche, "@CITICHECK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(5).Value))
                        db.AddInParameter(commProcSche, "@SCHEDULE_DATE", DbType.DateTime, DateTime.ParseExact(txtScheduleDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        db.AddInParameter(commProcSche, "@NO_CHECK", DbType.Int32, NullHelper.ToIntNum(dgView.Rows(i).Cells(4).Value))
                        db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BANK_CODE", DbType.String, txtCorrBankCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CORR_BRANCH_CODE", DbType.String, txtCorrBranchCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intModno)

                        db.AddInParameter(commProcSche, "@FILENAME", DbType.String, dgView.Rows(i).Cells(8).Value)
                        db.AddInParameter(commProcSche, "@REF_NO", DbType.String, dgView.Rows(i).Cells(9).Value)
                        db.AddInParameter(commProcSche, "@FILE_USER_ID", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@SEQ_NO", DbType.Int32, dgView.Rows(i).Cells(11).Value)
                        db.AddInParameter(commProcSche, "@CHECKED", DbType.Int32, dgView.Rows(i).Cells(12).Value)
                        db.AddInParameter(commProcSche, "@FLEXGEN_DATE", DbType.DateTime, dgView.Rows(i).Cells(13).Value)

                        db.AddInParameter(commProcSche, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(14).Value)
                        db.AddInParameter(commProcSche, "@IS_ROW_CHG", SqlDbType.Bit, dgView.Rows(i).Cells(15).Value)

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

                    '------------Mizan Work (09-05-2016)------------
                    If _ScheduleDate <> txtScheduleDate.Text.Trim() Then
                        log_message = " Schedule Date : " + _ScheduleDate + " " + " To " + " " + txtScheduleDate.Text.Trim() + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                    If _LocCode <> txtLocationCode.Text.Trim() Then
                        log_message = " Location Code : " + _LocCode + " " + " To " + " " + txtLocationCode.Text.Trim() + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                    If _TotalCheckNo <> txtTotalCheckNo.Text.Trim() Then
                        log_message = " Total Check No : " + _TotalCheckNo + " " + " To " + " " + txtTotalCheckNo.Text.Trim() + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                    If _TotalCheckAmt <> txtTotalCheckAmount.Text.Trim() Then
                        log_message = " Total Check Amount : " + _TotalCheckAmt + " " + " To " + " " + txtTotalCheckAmount.Text.Trim() + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                    If _TotalCashAmt <> txtTotalCashAmount.Text.Trim() Then
                        log_message = " Total Cash Amount : " + _TotalCashAmt + " " + " To " + " " + txtTotalCashAmount.Text.Trim() + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                   
                    'For Gridview Data

                    For i = 0 To dgView.Rows.Count - 1

                        If _clientCode(i) <> dgView.Item(1, i).Value Then
                            log_message = " Client Code : " + _clientCode(i) + " " + " To " + " " + dgView.Item(1, i).Value.ToString + "." + " "
                            ScheduleList.Add(log_message)
                        End If

                        If _NumOfCheck(i) <> dgView.Item(4, i).Value Then
                            log_message = " No. Of Check : " + _NumOfCheck(i) + " " + " To " + " " + dgView.Item(4, i).Value.ToString + "." + " "
                            ScheduleList.Add(log_message)
                        End If
                        If _citiCheckAmt(i) <> dgView.Item(5, i).Value Then
                            log_message = " Citi Check Amount : " + _citiCheckAmt(i) + " " + " To " + " " + dgView.Item(5, i).Value.ToString + "." + " "
                            ScheduleList.Add(log_message)
                        End If
                        If _citiCashAmt(i) <> dgView.Item(6, i).Value Then
                            log_message = " Citi Cash Amount : " + _citiCashAmt(i) + " " + " To " + " " + dgView.Item(6, i).Value.ToString + "." + " "
                            ScheduleList.Add(log_message)
                        End If
                        
                    Next

                    '-----------------

                    For Each depoInfo As String In ScheduleList
                        _scheduleLog += depoInfo
                    Next
                    _log = " Updated : Deposit Schedule Code  : " + txtDepoScheCode.Text.ToString() + "." + " " + _scheduleLog

                    Logger.system_log(_log)

                    _scheduleLog = ""
                    ScheduleList.Clear()

                    '------------Mizan Work (09-05-2016)------------

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@DS_CODE", DbType.String, _strDSCode)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (15-05-2016)------------

            If _intModno > 1 Then

                If _aScheduleDate <> _ScheduleDate Then
                    log_message = " Schedule Date : " + _aScheduleDate + " " + " To " + " " + _ScheduleDate + "." + " "
                    ScheduleList.Add(log_message)
                End If
                If _aLocCode <> _LocCode Then
                    log_message = " Location Code : " + _aLocCode + " " + " To " + " " + _LocCode + "." + " "
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

                'For Gridview Data

                For i = 0 To dgView.Rows.Count - 1

                    If _aclientCode(i) <> _clientCode(i) Then
                        log_message = " Client Code : " + _aclientCode(i) + " " + " To " + " " + _clientCode(i) + "." + " "
                        ScheduleList.Add(log_message)
                    End If

                    If _aNumOfCheck(i) <> _NumOfCheck(i) Then
                        log_message = " No. Of Check : " + _aNumOfCheck(i) + " " + " To " + " " + _NumOfCheck(i) + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                    If _acitiCheckAmt(i) <> _citiCheckAmt(i) Then
                        log_message = " Citi Check Amount : " + _acitiCheckAmt(i) + " " + " To " + " " + _citiCheckAmt(i) + "." + " "
                        ScheduleList.Add(log_message)
                    End If
                    If _acitiCashAmt(i) <> _citiCashAmt(i) Then
                        log_message = " Citi Cash Amount : " + _acitiCashAmt(i) + " " + " To " + " " + _citiCashAmt(i) + "." + " "
                        ScheduleList.Add(log_message)
                    End If

                Next

                '-----------------

                For Each depoInfo As String In ScheduleList
                    _scheduleLog += depoInfo
                Next
                _log = " Authorized : Deposit Schedule Code  : " + txtDepoScheCode.Text.ToString() + "." + " " + _scheduleLog

                Logger.system_log(_log)

                _scheduleLog = ""
                ScheduleList.Clear()

            Else

                _log = " Authorized : Deposit Schedule Code  : " + txtDepoScheCode.Text.ToString()

                Logger.system_log(_log)

            End If

            '------------Mizan Work (15-05-2016)------------

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

    '------------Mizan Work (15-05-2016)------------

    Private Sub LoadMainDataForAuth(ByVal strDSCode As String)

        lblToolStatus.Text = ""

        _IsResetRow = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From DCOLLECTED Where DS_CODE ='" & strDSCode & "'  and STATUS='L'")
           
            If ds.Tables(0).Rows.Count > 0 Then

                _strDSCode = strDSCode
                

                txtDepoScheCode.Text = ds.Tables(0).Rows(0)("DS_CODE").ToString()
                lblEntryDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("ENTRY_DATE"))
                txtTotalCheckNo.Text = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_NOCHK"))
                _aTotalCheckNo = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_NOCHK")).ToString
                txtTotalCheckAmount.Text = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT"))
                _aTotalCheckAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT")).ToString
                txtTotalCashAmount.Text = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CASHAMT"))
                _aTotalCashAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CASHAMT")).ToString


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadMainData(ByVal strDSCode As String, ByVal intmod As Integer)

        lblToolStatus.Text = ""

        _IsResetRow = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DS_CODE", DbType.String, strDSCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intmod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strDSCode = strDSCode
                _intModno = intmod

                _formMode = FormTransMode.Update


                txtDepoScheCode.Text = ds.Tables(0).Rows(0)("DS_CODE").ToString()
                lblEntryDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("ENTRY_DATE"))
                txtTotalCheckNo.Text = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_NOCHK"))
                _TotalCheckNo = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_NOCHK")).ToString
                txtTotalCheckAmount.Text = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT"))
                _TotalCheckAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT")).ToString
                txtTotalCashAmount.Text = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CASHAMT"))
                _TotalCashAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CASHAMT")).ToString


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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@DS_CODE", DbType.String, strDSCode)

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

    '------------Mizan Work (15-05-2016)------------

    Private Sub LoadDetailDataForAuth(ByVal strDSCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From DSCHEDULE Where DS_CODE ='" & strDSCode & "'  and STATUS='L'").Tables(0)


            If dt.Rows.Count > 0 Then
                txtScheduleDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                _aScheduleDate = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE")).ToString
                txtLocationCode.Text = dt.Rows(0)("LOCATION_CODE").ToString()
                _aLocCode = dt.Rows(0)("LOCATION_CODE").ToString()
                

            End If

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If
                    dgView.Item(0, i).Value = dt.Rows(i)("D_CODE")
                    dgView.Item(1, i).Value = dt.Rows(i)("CLIENT_CODE")
                    _aclientCode(i) = dt.Rows(i)("CLIENT_CODE")


                    dgView.Item(4, i).Value = NullHelper.ToIntNum(dt.Rows(i)("NO_CHECK"))
                    _aNumOfCheck(i) = NullHelper.ToIntNum(dt.Rows(i)("NO_CHECK"))
                    dgView.Item(5, i).Value = NullHelper.ToDecNum(dt.Rows(i)("CITICHECK_AMOUNT"))
                    _acitiCheckAmt(i) = NullHelper.ToDecNum(dt.Rows(i)("CITICHECK_AMOUNT"))
                    dgView.Item(6, i).Value = NullHelper.ToDecNum(dt.Rows(i)("CITICASH_AMOUNT"))
                    _acitiCashAmt(i) = NullHelper.ToDecNum(dt.Rows(i)("CITICASH_AMOUNT"))
                    dgView.Item(7, i).Value = dt.Rows(i)("DEPOSIT_TYPE")

                   

                Next
                dgView.AllowUserToAddRows = False

            End If

            CheckGridFileStatus()
            ShowGridTotal()

            FixSerialNo()


            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
                txtScheduleDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                _ScheduleDate = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE")).ToString
                txtLocationCode.Text = dt.Rows(0)("LOCATION_CODE").ToString()
                _LocCode = dt.Rows(0)("LOCATION_CODE").ToString()
                lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                txtCorrBankCode.Text = dt.Rows(0)("CORR_BANK_CODE").ToString()
                lblCorrBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                txtCorrBranchCode.Text = dt.Rows(0)("CORR_BRANCH_CODE").ToString()
                lblCorrBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()


            End If

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If
                    dgView.Item(0, i).Value = dt.Rows(i)("D_CODE")
                    dgView.Item(1, i).Value = dt.Rows(i)("CLIENT_CODE")
                    _clientCode(i) = dt.Rows(i)("CLIENT_CODE")
                    dgView.Item(2, i).Value = dt.Rows(i)("ACC_NAME")
                    dgView.Item(3, i).Value = dt.Rows(i)("ACC_NO")
                    dgView.Item(4, i).Value = NullHelper.ToIntNum(dt.Rows(i)("NO_CHECK"))
                    _NumOfCheck(i) = NullHelper.ToIntNum(dt.Rows(i)("NO_CHECK"))
                    dgView.Item(5, i).Value = NullHelper.ToDecNum(dt.Rows(i)("CITICHECK_AMOUNT"))
                    _citiCheckAmt(i) = NullHelper.ToDecNum(dt.Rows(i)("CITICHECK_AMOUNT"))
                    dgView.Item(6, i).Value = NullHelper.ToDecNum(dt.Rows(i)("CITICASH_AMOUNT"))
                    _citiCashAmt(i) = NullHelper.ToDecNum(dt.Rows(i)("CITICASH_AMOUNT"))
                    dgView.Item(7, i).Value = dt.Rows(i)("DEPOSIT_TYPE")

                    dgView.Item(8, i).Value = dt.Rows(i)("FILENAME")
                    dgView.Item(9, i).Value = dt.Rows(i)("REF_NO")
                    dgView.Item(10, i).Value = dt.Rows(i)("FILE_USER_ID")
                    dgView.Item(11, i).Value = dt.Rows(i)("SEQ_NO")
                    dgView.Item(12, i).Value = dt.Rows(i)("CHECKED")
                    dgView.Item(13, i).Value = dt.Rows(i)("FLEXGEN_DATE")

                    dgView.Item(14, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(15, i).Value = dt.Rows(i)("IS_ROW_CHG")
                    
                Next
                dgView.AllowUserToAddRows = False

            End If

            CheckGridFileStatus()
            ShowGridTotal()

            FixSerialNo()


            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadDepositScheduleData(ByVal strDSCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_DCollected_GetMaxMod")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@DS_CODE", DbType.String, strDSCode)

            Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            If intModNo > 0 Then
                LoadMainData(strDSCode, intModNo)

            Else
                'ClearFieldsAll()

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DCollected_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@DS_CODE", DbType.String, _strDSCode)
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
        ElseIf result = 10 Then
            tStatus = TransState.ChildExist

        Else
            tStatus = TransState.UpdateNotPossible
        End If


        Return tStatus

    End Function

    ''' <summary>
    ''' Check grid data if any item has filename
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckGridFileStatus()

        For Each row As DataGridViewRow In dgView.Rows
            If NullHelper.ObjectToString(row.Cells(8).Value).Trim() <> "" Then
                _isFileExist = True
                Exit Sub
            End If
        Next
        _isFileExist = False

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strDSCode As String, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strDSCode = strDSCode

        _intModno = intmod

    End Sub


#End Region

    Private Sub FrmDepoSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intModno > 0 Then
            LoadMainData(_strDSCode, _intModno)
            LoadDetailData(_strDSCode, _intModno)
        End If



        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()

        DisableClear()
        DisableRefresh()

        DisableFields()

        dgView.Enabled = False
    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click

        lblToolStatus.Text = ""

        EnableNew()
        If Not (_strDSCode = "") Then

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

        dgView.Enabled = True

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        lblToolStatus.Text = ""
        _formMode = FormTransMode.Add

        EnableSave()

        ClearFieldsAll()
        EnableFields()


        DisableRefresh()
        DisableDelete()


        If txtDepoScheCode.Enabled = True Then
            txtDepoScheCode.Focus()
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

                        btnNew_Click(sender, e)

                        'LoadMainData(_strDSCode, _intModno)
                        'LoadDetailData(_strDSCode, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        '_formMode = FormTransMode.Update


                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()



                    ElseIf tState = TransState.Update Then

                        btnNew_Click(sender, e)

                        'LoadMainData(_strDSCode, _intModno)
                        'LoadDetailData(_strDSCode, _intModno)

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
        
        LoadMainData(_strDSCode, _intModno)
        LoadDetailData(_strDSCode, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadMainData(_strDSCode, _intModno)
                    LoadDetailData(_strDSCode, _intModno)

                    DisableAuth()

                    If _strDSCode = "" Then

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
                ElseIf tState = TransState.ChildExist Then
                    lblToolStatus.Text = "!! Related CitiCash or CitiSpeed Data Exist !!"
                Else
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If

                If _intModno = 0 Then
                    btnNew.Focus()
                End If

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevVer.Click

        If _intModno - 1 > 0 Then

            LoadMainData(_strDSCode, _intModno - 1)
            LoadDetailData(_strDSCode, _intModno)

        End If

    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click

        Dim strDSCode As String = _strDSCode
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_strDSCode, _intModno + 1)

            If _intModno = 0 Then
                LoadMainData(strDSCode, intModno)
            End If

            LoadDetailData(_strDSCode, _intModno)
        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        ShowOpertionStatus()

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadMainDataForAuth(_strDSCode)
                    LoadDetailDataForAuth(_strDSCode)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_strDSCode, _intModno)
                    LoadDetailData(_strDSCode, _intModno)

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

        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Exit Sub
        ElseIf lblAccNo.Text.Trim() = "" Then
            MessageBox.Show("Client data required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Exit Sub
        ElseIf chkDepositType.Checked = True And NullHelper.ToDecNum(txtCitiCheckAmount.Text) = 0 Then
            MessageBox.Show("Check Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCitiCheckAmount.Focus()
            Exit Sub
        ElseIf chkDepositType.Checked = False And NullHelper.ToDecNum(txtCitiCashAmount.Text) = 0 Then
            MessageBox.Show("Cash Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCitiCashAmount.Focus()
            Exit Sub

        End If





        For Each row As DataGridViewRow In dgView.Rows
            If row.Index.ToString() <> lblRowNo.Text Then
                If row.Cells(0).Value.ToString().Trim() = txtDepoCode.Text.Trim() Then
                    MessageBox.Show("Duplicate Deposit Slip", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

        Next

        ResetIsRowChangedValue()

        If _RowEditMode = True Then

            Dim selRow As Integer = lblRowNo.Text.Trim()

            If _ColChecked = "1" Then
                If _ColFileName.Trim() <> "" Then
                    MessageBox.Show("Item is already booked !!" + Environment.NewLine + _
                                    "If you want to change any detail after the booking" + Environment.NewLine + _
                                    "you must remove the item first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    If MessageBox.Show("Item was already checked for booking process !!" + Environment.NewLine + _
                                    "If you edit the record, checking process have to be executed before booking." + Environment.NewLine + _
                                    "Do you really want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If

                    dgView.Item(12, selRow).Value = "0"

                End If


            End If


            dgView.Item(0, selRow).Value = txtDepoCode.Text.Trim()
            dgView.Item(1, selRow).Value = txtClientCode.Text.Trim()
            dgView.Item(2, selRow).Value = lblAccName.Text
            dgView.Item(3, selRow).Value = lblAccNo.Text
            dgView.Item(4, selRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(5, selRow).Value = NullHelper.ToDecNum(txtCitiCheckAmount.Text.Trim())
            dgView.Item(6, selRow).Value = NullHelper.ToDecNum(txtCitiCashAmount.Text.Trim())
            dgView.Item(7, selRow).Value = IIf(chkDepositType.Checked = True, "Check", "Cash")

            dgView.Item(15, selRow).Value = True




            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(selRow).Selected = True


        Else

            Dim MaxSlNo As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                If MaxSlNo <= NullHelper.ToIntNum(row.Cells(14).Value) Then
                    MaxSlNo = NullHelper.ToIntNum(row.Cells(14).Value) + 1
                End If


            Next

            dgView.Rows.Add()

            Dim maxRow As Integer = dgView.Rows.Count - 1

            dgView.Item(0, maxRow).Value = txtDepoCode.Text.Trim()
            dgView.Item(1, maxRow).Value = txtClientCode.Text.Trim()
            dgView.Item(2, maxRow).Value = lblAccName.Text
            dgView.Item(3, maxRow).Value = lblAccNo.Text
            dgView.Item(4, maxRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(5, maxRow).Value = NullHelper.ToDecNum(txtCitiCheckAmount.Text.Trim())
            dgView.Item(6, maxRow).Value = NullHelper.ToDecNum(txtCitiCashAmount.Text.Trim())
            dgView.Item(7, maxRow).Value = IIf(chkDepositType.Checked = True, "Check", "Cash")

            dgView.Item(14, maxRow).Value = MaxSlNo
            dgView.Item(15, maxRow).Value = True

            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(maxRow).Selected = True

        End If

        ShowGridTotal()

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"


        txtDepoCode.Clear()
        'txtClientCode.Clear()
        'lblAccName.Text = ""
        'lblAccNo.Text = ""
        'chkDepositType.Checked = False

        txtCheckNo.Clear()
        txtCitiCheckAmount.Clear()
        txtCitiCashAmount.Clear()

        txtDepoCode.Focus()



    End Sub

    Private Sub btnRemoveFromGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromGrid.Click

        If dgView.SelectedRows.Count = 0 Then Exit Sub

        For Each row As DataGridViewRow In dgView.SelectedRows
            dgView.Rows.Remove(row)
        Next

        ShowGridTotal()


    End Sub

    
    Private Sub chkDepositType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDepositType.CheckedChanged

        If chkDepositType.Checked = True Then
            txtCheckNo.Enabled = True
            txtCitiCheckAmount.Enabled = True
            txtCitiCashAmount.Enabled = False
            txtCitiCashAmount.Text = ""

        Else
            txtCheckNo.Text = ""
            txtCitiCheckAmount.Text = ""
            txtCheckNo.Enabled = False
            txtCitiCheckAmount.Enabled = False
            txtCitiCashAmount.Enabled = True

        End If

    End Sub

    Private Sub btnSearchBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBank.Click
        Dim frmList As New FrmList()
        frmList.Text = "Corr. Bank Branch List"
        frmList.ProcName = "CMS_Branch_GetCorrBranchListByLoc"

        frmList.AddParamToDB("@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}, {"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
        frmList.colwidth = New Integer(,) {{1, 150}, {3, 150}}
        frmList.colrename = New String(,) {{"0", "Branch Code"}, {"1", "Branch Name"}, {"2", "Bank Code"}, {"3", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtCorrBankCode.Text = frmList.RowResult.Cells(2).Value.ToString()
            lblCorrBankName.Text = frmList.RowResult.Cells(3).Value.ToString()

            txtCorrBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblCorrBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()


        End If

        frmList.Dispose()

        If txtCorrBankCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub txtLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtLocationCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Location List"
                frmList.ProcName = "CMS_Location_GetList"
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

    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLocation.Click

        Dim frmList As New FrmList()
        frmList.Text = "Location List"
        frmList.ProcName = "CMS_Location_GetList"
        frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

        If txtLocationCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    
    Private Sub txtClientCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtClientCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Client List"
                frmList.ProcName = "CMS_Client_GetList"

                frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}, {"CLIENT_CODE", "Code"}}

                frmList.colwidth = New Integer(,) {{1, 150}, {2, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "A/C No"}, {"2", "A/C Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtClientCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblAccNo.Text = frmList.RowResult.Cells(1).Value.ToString()
                    lblAccName.Text = frmList.RowResult.Cells(2).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then

                        lblAccNo.Text = dt.Rows(0)("ACC_NO").ToString()
                        lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

                    Else

                        txtClientCode.Clear()
                        lblAccNo.Text = ""
                        lblAccName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtClientCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If

    End Sub

    Private Sub btnSearchClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClient.Click

        Dim frmList As New FrmList()
        frmList.Text = "Client List"
        frmList.ProcName = "CMS_Client_GetList"

        frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}, {"CLIENT_CODE", "Code"}}

        frmList.colwidth = New Integer(,) {{1, 150}, {2, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "A/C No"}, {"2", "A/C Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtClientCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblAccNo.Text = frmList.RowResult.Cells(1).Value.ToString()
            lblAccName.Text = frmList.RowResult.Cells(2).Value.ToString()

        End If

        frmList.Dispose()


        If txtClientCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    

   

    Private Sub txtDepoScheCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoScheCode.KeyDown

        If e.KeyCode = Keys.Enter And txtDepoScheCode.Text.Trim() <> "" Then

            'If txtDepoScheCode.Text.Trim().Length < 5 Then
            '    MessageBox.Show("Not less than 5 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtDepoScheCode.Focus()
            '    Exit Sub
            'End If

            'Dim depoScheCode As String = txtDepoScheCode.Text.Trim()

            'If Not (txtDepoScheCode.Text.Trim() = "") Then
            '    LoadDepositScheduleData(txtDepoScheCode.Text.Trim())
            'End If

            'If _intModno > 0 Then
            '    txtDepoScheCode.ReadOnly = True
            '    LoadDetailData(_strDSCode, _intModno)
            'Else
            '    'txtDepoScheCode.Text = depoScheCode
            'End If

            SendKeys.Send("{tab}")



        End If

    End Sub

    
    Private Sub txtScheduleDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScheduleDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCheckAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCheckAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCashAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCashAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDepoCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCitiCheckAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCitiCheckAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCitiCashAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCitiCashAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick

        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _ColFileName = NullHelper.ObjectToString(dgView.Item(8, e.RowIndex).Value)            
            _ColChecked = NullHelper.ObjectToString(dgView.Item(12, e.RowIndex).Value)
            
            If _ColChecked = "1" Then
                If _ColFileName.Trim() <> "" Then
                    MessageBox.Show("Item is already booked !!" + Environment.NewLine + _
                                    "If you really want to change any detail after the booking" + Environment.NewLine + _
                                    "you have to remove the item first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    _ColChecked = ""
                    _ColFileName = ""

                    Exit Sub

                End If

            End If




            _RowEditMode = True

            btnAddToGrid.Text = "Update"
            btnCancel.Visible = True
            btnRemoveFromGrid.Enabled = False


            lblRowNo.Text = e.RowIndex.ToString()

            txtDepoCode.Text = dgView.Item(0, e.RowIndex).Value
            txtClientCode.Text = dgView.Item(1, e.RowIndex).Value
            lblAccName.Text = dgView.Item(2, e.RowIndex).Value
            lblAccNo.Text = dgView.Item(3, e.RowIndex).Value
            txtCheckNo.Text = dgView.Item(4, e.RowIndex).Value
            txtCitiCheckAmount.Text = dgView.Item(5, e.RowIndex).Value
            txtCitiCashAmount.Text = dgView.Item(6, e.RowIndex).Value

            If dgView.Item(7, e.RowIndex).Value = "Check" Then
                chkDepositType.Checked = True
            Else
                chkDepositType.Checked = False
            End If

            '_ColFileName = NullHelper.ObjectToString(dgView.Item(8, e.RowIndex).Value)
            '_ColRefNo = NullHelper.ObjectToString(dgView.Item(9, e.RowIndex).Value)
            '_ColFileUserId = NullHelper.ObjectToString(dgView.Item(10, e.RowIndex).Value)
            '_ColSeqNo = NullHelper.ObjectToString(dgView.Item(11, e.RowIndex).Value)
            '_ColChecked = NullHelper.ObjectToString(dgView.Item(12, e.RowIndex).Value)
            '_ColFlexGenDate = NullHelper.DateToString( dgView.Item(13, e.RowIndex).Value)








        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        txtDepoCode.Clear()
        'txtClientCode.Clear()
        'lblAccName.Text = ""
        'lblAccNo.Text = ""
        txtCheckNo.Clear()
        txtCitiCheckAmount.Clear()
        txtCitiCashAmount.Clear()

        _ColFileName = ""
        _ColChecked = ""


        
    End Sub

    
    Private Sub txtScheduleDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtScheduleDate.Validating
        If CommonUtil.DateValidate(txtScheduleDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub chkDepositType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkDepositType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        '_ColFileName = NullHelper.ObjectToString(dgView.Item(8, e.RowIndex).Value)
        '_ColChecked = NullHelper.ObjectToString(dgView.Item(12, e.RowIndex).Value)


        If (e.RowIndex < dgView.Rows.Count) Then

            'If NullHelper.ObjectToString(dgView.Rows(e.RowIndex).Cells(12).Value).Trim() = "0" Or _
            '    (_isFileExist = True And NullHelper.ObjectToString(dgView.Rows(e.RowIndex).Cells(12).Value).Trim() = "") Then
            '    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            'End If

            If NullHelper.ToBool(dgView.Rows(e.RowIndex).Cells(15).Value) = True Then

                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            Else
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If

        End If

       

    End Sub

  
    Private Sub txtDepoScheCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepoScheCode.Validated

        If txtDepoScheCode.Text.Trim() <> "" And _intModno = 0 Then

            If txtDepoScheCode.Text.Trim().Length < 5 Then
                MessageBox.Show("Not less than 5 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDepoScheCode.Focus()
                Exit Sub
            End If

            Dim depoScheCode As String = txtDepoScheCode.Text.Trim()

            If Not (txtDepoScheCode.Text.Trim() = "") Then
                LoadDepositScheduleData(txtDepoScheCode.Text.Trim())
            End If

            If _intModno > 0 Then
                txtDepoScheCode.ReadOnly = True
                LoadDetailData(_strDSCode, _intModno)
            Else
                'txtDepoScheCode.Text = depoScheCode
            End If





        End If
    End Sub

    

    Private Sub txtTotalCheckNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCheckNo.Validating
        If CommonUtil.IntValidate(txtTotalCheckNo.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If

    End Sub

    Private Sub txtTotalCheckAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCheckAmount.Validating
        If CommonUtil.DecValidate(txtTotalCheckAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTotalCashAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCashAmount.Validating
        If CommonUtil.DecValidate(txtTotalCashAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCitiCheckAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCitiCheckAmount.Validating
        If CommonUtil.DecValidate(txtCitiCheckAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCitiCashAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCitiCashAmount.Validating
        If CommonUtil.DecValidate(txtCitiCashAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCheckNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCheckNo.Validating
        If CommonUtil.IntValidate(txtCheckNo.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtScheduleDate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScheduleDate.Validated

        If txtScheduleDate.Text.Trim() = "/  /" Then
            Exit Sub
        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Holiday_GetDetailByDate")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(txtScheduleDate.Text))

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                MessageBox.Show("Inputed date [" + txtScheduleDate.Text + "] is a holiday!!" + Environment.NewLine + _
                                "Check your date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'txtScheduleDate.Clear()
                txtScheduleDate.Focus()
                Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try





    End Sub

    Private Sub txtDepoCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDepoCode.Validating

        Dim strDepoSche As String = ""
        Dim flagDuplicate As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetCheckSlip")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())

            Dim dt As New DataTable()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                'ode.Text = dt.Rows(0)("D_CODE").ToString()
                strDepoSche = dt.Rows(0)("DS_CODE").ToString().Trim()
                flagDuplicate = True


            End If

            If flagDuplicate = False Then

                commProc = db.GetStoredProcCommand("CMS_DSchedule_GetCashSlip")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())

                dt = New DataTable()

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then

                    strDepoSche = dt.Rows(0)("DS_CODE").ToString().Trim()
                    flagDuplicate = True


                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        If flagDuplicate = True Then
            MessageBox.Show("Duplicate Deposit Found on DS: " + strDepoSche.Trim(), "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Clear()
            e.Cancel = True

        End If





    End Sub
End Class