'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain CitiAnywhere Check Detail
'Creation date      : 09-Jan-2013
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmCitiCheckDetail



#Region "Global Variables"

    Dim _formName As String = "DepositCitiAnywhereDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _strDCode As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False

    Dim log_message As String

    'For Update
    Dim _depSlipDate As String = ""
    Dim _depLocCode As String = ""
    Dim _valDate As String = ""
    Dim _custRef As String = ""
    Dim _checkNo As String = ""
    Dim _totalAmt As String = ""

    Dim _drBankCode(1000) As String
    Dim _drBrCode(1000) As String
    Dim _checkType(1000) As String
    Dim _chekNo(1000) As String
    Dim _checkDate(1000) As String
    Dim _checkRef(1000) As String
    Dim _amount(1000) As String
    Dim _locCode(1000) As String

    'For Auth
    Dim _adepSlipDate As String = ""
    Dim _adepLocCode As String = ""
    Dim _avalDate As String = ""
    Dim _acustRef As String = ""
    Dim _acheckNo As String = ""
    Dim _atotalAmt As String = ""

    Dim _adrBankCode(1000) As String
    Dim _adrBrCode(1000) As String
    Dim _acheckType(1000) As String
    Dim _achekNo(1000) As String
    Dim _acheckDate(1000) As String
    Dim _acheckRef(1000) As String
    Dim _aamount(1000) As String
    Dim _alocCode(1000) As String

    Dim CheckAnyList As New List(Of String)
    Dim _AnyLog As String = ""
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


        txtDepoCode.ReadOnly = True

        txtClientCode.ReadOnly = True
        'btnSearchClient.Enabled = False
        txtSlipDate.ReadOnly = True
        txtValueDate.ReadOnly = True
        txtDepoLocationCode.ReadOnly = True
        'btnSearchDepoLocation.Enabled = False
        txtCustomerRef.ReadOnly = True
        txtTotalCheckNo.ReadOnly = True
        txtTotalAmount.ReadOnly = True
        txtDrawerAccNo.ReadOnly = True
        txtDraweeBankCode.ReadOnly = True
        'btnSearchBank.Enabled = False
        txtDraweeBranchCode.ReadOnly = True
        'btnSearchBranch.Enabled = False
        txtDraweeLocationCode.ReadOnly = True
        'btnSearchDraweeLocation.Enabled = False
        cmbCheckType.Enabled = False
        txtCheckNo.ReadOnly = True
        txtCheckRef.ReadOnly = True
        txtCheckDate.ReadOnly = True
        
        txtAmount.ReadOnly = True


        btnAddToGrid.Enabled = False
        btnRemoveFromGrid.Enabled = False

        dgView.Enabled = False

        'dgView.ReadOnly = True



    End Sub

    Private Sub EnableFields()

        If _intModno = 0 Then
            txtDepoCode.ReadOnly = False

        End If


        txtClientCode.ReadOnly = False
        'btnSearchClient.Enabled = True
        txtSlipDate.ReadOnly = False
        txtValueDate.ReadOnly = False
        txtDepoLocationCode.ReadOnly = False
        'btnSearchDepoLocation.Enabled = True
        txtCustomerRef.ReadOnly = False
        txtTotalCheckNo.ReadOnly = False
        txtTotalAmount.ReadOnly = False
        txtDrawerAccNo.ReadOnly = False
        txtDraweeBankCode.ReadOnly = False
        'btnSearchBank.Enabled = True
        txtDraweeBranchCode.ReadOnly = False
        'btnSearchBranch.Enabled = True
        txtDraweeLocationCode.ReadOnly = False
        'btnSearchDraweeLocation.Enabled = True
        cmbCheckType.Enabled = True
        txtCheckNo.ReadOnly = False
        txtCheckRef.ReadOnly = False
        txtCheckDate.ReadOnly = False


        txtAmount.ReadOnly = False

        btnAddToGrid.Enabled = True
        btnRemoveFromGrid.Enabled = True

        dgView.Enabled = True

    End Sub


    Private Sub ClearFields()


        txtClientCode.Clear()
        lblAccName.Text = ""
        lblAccNo.Text = ""

        txtSlipDate.Clear()
        txtValueDate.Clear()
        txtDepoLocationCode.Clear()
        lblDepoLocationName.Text = ""

        txtCustomerRef.Clear()
        txtTotalCheckNo.Clear()
        txtTotalAmount.Clear()
        lblCheckCountStatus.Text = ""
        txtDrawerAccNo.Clear()
        txtDraweeBankCode.Clear()
        lblDraweeBankName.Text = ""

        txtDraweeBranchCode.Clear()
        lblDraweeBranchName.Text = ""

        txtDraweeLocationCode.Clear()
        lblDraweeLocationName.Text = ""
        lblClearingZone.Text = ""

        cmbCheckType.Text = ""
        txtCheckNo.Clear()
        txtCheckRef.Clear()
        txtCheckDate.Clear()
        
        txtAmount.Clear()

        dgView.AllowUserToAddRows = False

        'dgView.DataSource = Nothing

    End Sub

    Private Sub ClearFieldsAll()

        txtDepoCode.Clear()
        txtClientCode.Clear()
        lblAccName.Text = ""
        lblAccNo.Text = ""

        txtSlipDate.Clear()
        txtValueDate.Clear()
        txtDepoLocationCode.Clear()
        lblDepoLocationName.Text = ""

        txtCustomerRef.Clear()
        txtTotalCheckNo.Clear()
        txtTotalAmount.Clear()
        lblCheckCountStatus.Text = ""
        txtDrawerAccNo.Clear()
        txtDraweeBankCode.Clear()
        lblDraweeBankName.Text = ""

        txtDraweeBranchCode.Clear()
        lblDraweeBranchName.Text = ""

        txtDraweeLocationCode.Clear()
        lblDraweeLocationName.Text = ""
        lblClearingZone.Text = ""

        cmbCheckType.Text = ""
        txtCheckNo.Clear()
        txtCheckRef.Clear()
        txtCheckDate.Clear()
        
        txtAmount.Clear()



        dgView.AllowUserToAddRows = False

        dgView.DataSource = Nothing
        dgView.Rows.Clear()


        _strDCode = ""
        _intModno = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""


    End Sub

    Private Sub ShowOpertionStatus()

        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0

        Dim MsgStatus As String = ""


        For Each row As DataGridViewRow In dgView.Rows


            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(11).Value)

            CheckNoTotal = CheckNoTotal + 1


        Next


        If NullHelper.ToDecNum(txtTotalAmount.Text.Trim()) <> CheckTotal Then

            Dim diffCheck As Decimal = CheckTotal - NullHelper.ToDecNum(txtTotalAmount.Text.Trim())
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

    Private Function CheckValidData() As Boolean


        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False
        ElseIf txtClientCode.Text.Trim() = "" Then
            MessageBox.Show("Client code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Return False
        ElseIf lblAccName.Text.Trim() = "" Then
            MessageBox.Show("Client code load required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Return False
        ElseIf txtSlipDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Slip date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlipDate.Focus()
            Return False
        ElseIf txtValueDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Value date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtValueDate.Focus()
            Return False
        ElseIf txtDepoLocationCode.Text.Trim() = "" Or lblDepoLocationName.Text.Trim() = "" Then
            MessageBox.Show("Location Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoLocationCode.Focus()
            Return False
        ElseIf txtTotalAmount.Text.Trim() = "" Then
            MessageBox.Show("Total check amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalAmount.Focus()
            Return False
        ElseIf txtTotalCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Total check no required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckNo.Focus()
            Return False


        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("You didn't enter any record!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("CASH_CR_TYPE").ToString().Trim() = "R" And txtCustomerRef.Text.Trim() = "" Then
                    MessageBox.Show("This client customer ref. cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCustomerRef.Focus()
                    Return False

                End If

            Else

                MessageBox.Show("No client information found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try



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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc, "@TOTAL_CHKNO", DbType.Int32, NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalAmount.Text.Trim()))


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

                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CCheck_Add")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@SLNO", DbType.String, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@DLOCATION_CODE", DbType.String, txtDepoLocationCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
                        db.AddInParameter(commProcSche, "@SLIP_DATE", DbType.DateTime, NullHelper.StringToDate(txtSlipDate.Text.Trim()))
                        db.AddInParameter(commProcSche, "@VALUE_DATE", DbType.DateTime, NullHelper.StringToDate(txtValueDate.Text.Trim()))
                        db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(11).Value))
                        db.AddInParameter(commProcSche, "@CHECK_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(8).Value))
                        db.AddInParameter(commProcSche, "@CHECK_TYPE", DbType.String, dgView.Rows(i).Cells(9).Value)
                        db.AddInParameter(commProcSche, "@DRAWER", DbType.String, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, dgView.Rows(i).Cells(2).Value)
                        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, dgView.Rows(i).Cells(4).Value)
                        db.AddInParameter(commProcSche, "@BRANCH_CODE", DbType.String, dgView.Rows(i).Cells(6).Value)
                        db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(12).Value)


                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Add
                    _strDCode = txtDepoCode.Text.Trim()
                    _intModno = 1

                    '------------Mizan Work (09-05-2016)------------

                    log_message = " Added : Citi Anywhere Check Deposit Slip No : " + txtDepoCode.Text.Trim() + "." + " " + " Client Code : " + txtClientCode.Text.Trim() + "." + " " + " Account No : " + lblAccNo.Text.ToString()
                    Logger.system_log(log_message)

                    '------------Mizan Work (09-05-2016)------------
                End If

                trans.Commit()

                


            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
                db.AddInParameter(commProc, "@TOTAL_CHKNO", DbType.Int32, NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalAmount.Text.Trim()))
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


                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CCheck_Update")
                    Dim strRtnStatus As String = ""

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@SLNO", DbType.String, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@D_CODE", DbType.String, _strDCode)
                        db.AddInParameter(commProcSche, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@DLOCATION_CODE", DbType.String, txtDepoLocationCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
                        db.AddInParameter(commProcSche, "@SLIP_DATE", DbType.DateTime, NullHelper.StringToDate(txtSlipDate.Text.Trim()))
                        db.AddInParameter(commProcSche, "@VALUE_DATE", DbType.DateTime, NullHelper.StringToDate(txtValueDate.Text.Trim()))
                        db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(11).Value))
                        db.AddInParameter(commProcSche, "@CHECK_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(8).Value))
                        db.AddInParameter(commProcSche, "@CHECK_TYPE", DbType.String, dgView.Rows(i).Cells(9).Value)
                        db.AddInParameter(commProcSche, "@DRAWER", DbType.String, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, dgView.Rows(i).Cells(2).Value)
                        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, dgView.Rows(i).Cells(4).Value)
                        db.AddInParameter(commProcSche, "@BRANCH_CODE", DbType.String, dgView.Rows(i).Cells(6).Value)
                        db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(12).Value)
                        db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intModno)

                        strRtnStatus = "O"

                        If (dgView.Rows(i).Cells(13).Value Is Nothing) Or (dgView.Rows(i).Cells(13).Value Is DBNull.Value) Then
                            strRtnStatus = "O"
                        ElseIf (dgView.Rows(i).Cells(13).Value.ToString().Trim() = "") Then
                            strRtnStatus = "O"
                        Else
                            strRtnStatus = dgView.Rows(i).Cells(13).Value.ToString().Trim()
                        End If


                        db.AddInParameter(commProcSche, "@RTN_STATUS", DbType.String, strRtnStatus)
                        db.AddInParameter(commProcSche, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(14).Value)
                        db.AddInParameter(commProcSche, "@REMINDER_DATE", DbType.DateTime, dgView.Rows(i).Cells(15).Value)
                        db.AddInParameter(commProcSche, "@REMINDER_NO", DbType.Int32, dgView.Rows(i).Cells(16).Value)
                        db.AddInParameter(commProcSche, "@RTN_CODE", DbType.String, dgView.Rows(i).Cells(17).Value)

                        db.AddInParameter(commProcSche, "@FILENAME", DbType.String, dgView.Rows(i).Cells(18).Value)
                        db.AddInParameter(commProcSche, "@FILE_USER_ID", DbType.String, dgView.Rows(i).Cells(19).Value)
                        db.AddInParameter(commProcSche, "@FLEXGEN_DATE", DbType.DateTime, dgView.Rows(i).Cells(20).Value)

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

                    If _depSlipDate <> txtSlipDate.Text.Trim() Then
                        log_message = " Slip Date : " + _depSlipDate + " " + " To " + " " + txtSlipDate.Text.Trim() + "." + " "
                        CheckAnyList.Add(log_message)
                    End If

                    If _valDate <> txtValueDate.Text.Trim() Then
                        log_message = " Value Date : " + _valDate + " " + " To " + " " + txtValueDate.Text.Trim() + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _depLocCode <> txtDepoLocationCode.Text.Trim() Then
                        log_message = " Location Code : " + _depLocCode + " " + " To " + " " + txtDepoLocationCode.Text.Trim() + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _checkNo <> txtTotalCheckNo.Text.Trim() Then
                        log_message = " Total Check No : " + _checkNo + " " + " To " + " " + txtTotalCheckNo.Text.Trim() + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _totalAmt <> txtTotalAmount.Text.Trim() Then
                        log_message = " Total Amount : " + _totalAmt + " " + " To " + " " + txtTotalAmount.Text.Trim() + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _custRef <> txtCustomerRef.Text.Trim() Then
                        If _custRef = "" Then
                            log_message = " Customer Ref. : " + txtCustomerRef.Text.Trim() + "." + " "
                        Else
                            log_message = " Customer Ref. : " + _custRef + " " + " To " + " " + txtCustomerRef.Text.Trim() + "." + " "
                        End If
                        CheckAnyList.Add(log_message)
                    End If

                    'For Gridview Data

                    For i = 0 To dgView.Rows.Count - 1

                        If _drBankCode(i) <> dgView.Item(2, i).Value Then
                            log_message = " Drawee Bank Code : " + _drBankCode(i) + " " + " To " + " " + dgView.Item(2, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If

                        If _drBrCode(i) <> dgView.Item(6, i).Value Then
                            log_message = " Drawee Branch Code : " + _drBrCode(i) + " " + " To " + " " + dgView.Item(6, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If
                        If _locCode(i) <> dgView.Item(4, i).Value Then
                            log_message = " Location Code : " + _locCode(i) + " " + " To " + " " + dgView.Item(4, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If
                        If _checkDate(i) <> dgView.Item(8, i).Value Then
                            log_message = " Check Date : " + _checkDate(i) + " " + " To " + " " + dgView.Item(8, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If
                        If _checkType(i) <> dgView.Item(9, i).Value Then
                            log_message = " Check Type : " + _checkType(i) + " " + " To " + " " + dgView.Item(9, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If

                        If _chekNo(i) <> dgView.Item(10, i).Value Then
                            log_message = " Check No : " + _chekNo(i) + " " + " To " + " " + dgView.Item(10, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If
                        If _amount(i) <> dgView.Item(11, i).Value Then
                            log_message = "  Amount : " + _amount(i) + " " + " To " + " " + dgView.Item(11, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If
                        If _checkRef(i) <> dgView.Item(12, i).Value Then
                            log_message = " Check Ref. No : " + _checkRef(i) + " " + " To " + " " + dgView.Item(12, i).Value.ToString + "." + " "
                            CheckAnyList.Add(log_message)
                        End If
                        

                    Next

                    '-----------------

                    For Each AnyInfo As String In CheckAnyList
                        _AnyLog += AnyInfo
                    Next
                    _log = " Updated : Citi Anywhere Check Deposit Slip No : " + txtDepoCode.Text.Trim() + "." + " " + _AnyLog

                    Logger.system_log(_log)

                    _AnyLog = ""
                    CheckAnyList.Clear()

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
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

                If _adepSlipDate <> _depSlipDate Then
                    log_message = " Slip Date : " + _adepSlipDate + " " + " To " + " " + _depSlipDate + "." + " "
                    CheckAnyList.Add(log_message)
                End If

                If _avalDate <> _valDate Then
                    log_message = " Value Date : " + _avalDate + " " + " To " + " " + _valDate + "." + " "
                    CheckAnyList.Add(log_message)
                End If
                If _adepLocCode <> _depLocCode Then
                    log_message = " Location Code : " + _adepLocCode + " " + " To " + " " + _depLocCode + "." + " "
                    CheckAnyList.Add(log_message)
                End If
                If _acheckNo <> _checkNo Then
                    log_message = " Total Check No : " + _acheckNo + " " + " To " + " " + _checkNo + "." + " "
                    CheckAnyList.Add(log_message)
                End If
                If _atotalAmt <> _totalAmt Then
                    log_message = " Total Amount : " + _atotalAmt + " " + " To " + " " + _totalAmt + "." + " "
                    CheckAnyList.Add(log_message)
                End If
                If _acustRef <> _custRef Then
                    If _acustRef = "" Then
                        log_message = " Customer Ref. : " + _custRef + "." + " "
                    Else
                        log_message = " Customer Ref. : " + _acustRef + " " + " To " + " " + _custRef + "." + " "
                    End If
                    CheckAnyList.Add(log_message)
                End If

                'For Gridview Data

                For i = 0 To dgView.Rows.Count - 1

                    If _adrBankCode(i) <> _drBankCode(i) Then
                        log_message = " Drawee Bank Code : " + _adrBankCode(i) + " " + " To " + " " + _drBankCode(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If

                    If _adrBrCode(i) <> _drBrCode(i) Then
                        log_message = " Drawee Branch Code : " + _adrBrCode(i) + " " + " To " + " " + _drBrCode(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _alocCode(i) <> _locCode(i) Then
                        log_message = " Location Code : " + _alocCode(i) + " " + " To " + " " + _locCode(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _acheckDate(i) <> _checkDate(i) Then
                        log_message = " Check Date : " + _acheckDate(i) + " " + " To " + " " + _checkDate(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _acheckType(i) <> _checkType(i) Then
                        log_message = " Check Type : " + _acheckType(i) + " " + " To " + " " + _checkType(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If

                    If _achekNo(i) <> _chekNo(i) Then
                        log_message = " Check No : " + _achekNo(i) + " " + " To " + " " + _chekNo(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _aamount(i) <> _amount(i) Then
                        log_message = "  Amount : " + _aamount(i) + " " + " To " + " " + _amount(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If
                    If _acheckRef(i) <> _checkRef(i) Then
                        log_message = " Check Ref. No : " + _acheckRef(i) + " " + " To " + " " + _checkRef(i) + "." + " "
                        CheckAnyList.Add(log_message)
                    End If


                Next

                '-----------------

                For Each AnyInfo As String In CheckAnyList
                    _AnyLog += AnyInfo
                Next
                _log = " Authorized : Citi Anywhere Check Deposit Slip No : " + txtDepoCode.Text.Trim() + "." + " " + _AnyLog

                Logger.system_log(_log)

                _AnyLog = ""
                CheckAnyList.Clear()

            Else

                _log = " Authorized : Citi Anywhere Check Deposit Slip No : " + txtDepoCode.Text.Trim()

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

    Private Sub LoadMainDataForAuth(ByVal strDCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CCHECKTOTAL  Where D_CODE ='" & strDCode & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _strDCode = strDCode
               
                txtDepoCode.Text = ds.Tables(0).Rows(0)("D_CODE").ToString()
                txtTotalCheckNo.Text = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_CHKNO"))
                _checkNo = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_CHKNO")).ToString
                txtTotalAmount.Text = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT"))
                _totalAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT")).ToString

               
            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMainData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strDCode = strDCode
                _intModno = intmod

                _formMode = FormTransMode.Update

                txtDepoCode.Text = ds.Tables(0).Rows(0)("D_CODE").ToString()
                txtTotalCheckNo.Text = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_CHKNO"))
                _checkNo = NullHelper.ToIntNum(ds.Tables(0).Rows(0)("TOTAL_CHKNO")).ToString
                txtTotalAmount.Text = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT"))
                _totalAmt = NullHelper.ToDecNum(ds.Tables(0).Rows(0)("TOTAL_CHKAMT")).ToString

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@D_CODE", DbType.String, strDCode)

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

    Private Sub LoadDetailDataForAuth(ByVal strDCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CCHECK Where D_CODE ='" & strDCode & "'  and STATUS='L'").Tables(0)
            
            If dt.Rows.Count > 0 Then

                txtClientCode.Text = dt.Rows(0)("CLIENT_CODE").ToString()
                'lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()
                'lblAccNo.Text = dt.Rows(0)("ACC_NO").ToString()

                txtSlipDate.Text = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE"))
                _adepSlipDate = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE")).ToString
                txtValueDate.Text = NullHelper.DateToString(dt.Rows(0)("VALUE_DATE"))
                _avalDate = NullHelper.DateToString(dt.Rows(0)("VALUE_DATE")).ToString

                txtDepoLocationCode.Text = dt.Rows(0)("DLOCATION_CODE").ToString()
                _adepLocCode = dt.Rows(0)("DLOCATION_CODE").ToString()
                'lblDepoLocationName.Text = dt.Rows(0)("DLOCATION_NAME").ToString()
                txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
                _acustRef = dt.Rows(0)("CUSTOMER_REF").ToString()

            End If

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(1, i).Value = dt.Rows(i)("DRAWER")
                    dgView.Item(2, i).Value = dt.Rows(i)("DRAWEE_BANK_CODE")
                    _adrBankCode(i) = dt.Rows(i)("DRAWEE_BANK_CODE")
                    'dgView.Item(3, i).Value = dt.Rows(i)("DRAWEE_BANK_NAME")
                    dgView.Item(4, i).Value = dt.Rows(i)("LOCATION_CODE")
                    _alocCode(i) = dt.Rows(i)("LOCATION_CODE")
                    'dgView.Item(5, i).Value = dt.Rows(i)("LOCATION_NAME")
                    dgView.Item(6, i).Value = dt.Rows(i)("BRANCH_CODE")
                    _adrBrCode(i) = dt.Rows(i)("BRANCH_CODE")
                    ' dgView.Item(7, i).Value = dt.Rows(i)("BRANCH_NAME")
                    dgView.Item(8, i).Value = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE"))
                    _acheckDate(i) = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE")).ToString()
                    dgView.Item(9, i).Value = dt.Rows(i)("CHECK_TYPE")
                    _acheckType(i) = dt.Rows(i)("CHECK_TYPE")
                    dgView.Item(10, i).Value = dt.Rows(i)("CHECK_NO")
                    _achekNo(i) = dt.Rows(i)("CHECK_NO")
                    dgView.Item(11, i).Value = dt.Rows(i)("AMOUNT")
                    _aamount(i) = dt.Rows(i)("AMOUNT")
                    dgView.Item(12, i).Value = dt.Rows(i)("CHECK_REF")
                    _acheckRef(i) = dt.Rows(i)("CHECK_REF")

                    dgView.Item(13, i).Value = dt.Rows(i)("RTN_STATUS")
                    dgView.Item(14, i).Value = dt.Rows(i)("NONZONE_REF")
                    dgView.Item(15, i).Value = dt.Rows(i)("REMINDER_DATE")
                    dgView.Item(16, i).Value = dt.Rows(i)("REMINDER_NO")
                    dgView.Item(17, i).Value = dt.Rows(i)("RTN_CODE")

                    dgView.Item(18, i).Value = dt.Rows(i)("FILENAME")
                    dgView.Item(19, i).Value = dt.Rows(i)("FILE_USER_ID")
                    dgView.Item(20, i).Value = dt.Rows(i)("FLEXGEN_DATE")


                Next
                dgView.AllowUserToAddRows = False

            End If



            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadDetailData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetDetails")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intmod)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)

            If dt.Rows.Count > 0 Then

                txtClientCode.Text = dt.Rows(0)("CLIENT_CODE").ToString()
                lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()
                lblAccNo.Text = dt.Rows(0)("ACC_NO").ToString()

                txtSlipDate.Text = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE"))
                _depSlipDate = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE")).ToString
                txtValueDate.Text = NullHelper.DateToString(dt.Rows(0)("VALUE_DATE"))
                _valDate = NullHelper.DateToString(dt.Rows(0)("VALUE_DATE")).ToString

                txtDepoLocationCode.Text = dt.Rows(0)("DLOCATION_CODE").ToString()
                _depLocCode = dt.Rows(0)("DLOCATION_CODE").ToString()
                lblDepoLocationName.Text = dt.Rows(0)("DLOCATION_NAME").ToString()
                txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
                _custRef = dt.Rows(0)("CUSTOMER_REF").ToString()

            End If

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(1, i).Value = dt.Rows(i)("DRAWER")
                    dgView.Item(2, i).Value = dt.Rows(i)("DRAWEE_BANK_CODE")
                    _drBankCode(i) = dt.Rows(i)("DRAWEE_BANK_CODE")
                    dgView.Item(3, i).Value = dt.Rows(i)("DRAWEE_BANK_NAME")
                    dgView.Item(4, i).Value = dt.Rows(i)("LOCATION_CODE")
                    _locCode(i) = dt.Rows(i)("LOCATION_CODE")
                    dgView.Item(5, i).Value = dt.Rows(i)("LOCATION_NAME")
                    dgView.Item(6, i).Value = dt.Rows(i)("BRANCH_CODE")
                    _drBrCode(i) = dt.Rows(i)("BRANCH_CODE")
                    dgView.Item(7, i).Value = dt.Rows(i)("BRANCH_NAME")
                    dgView.Item(8, i).Value = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE"))
                    _checkDate(i) = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE")).ToString()
                    dgView.Item(9, i).Value = dt.Rows(i)("CHECK_TYPE")
                    _checkType(i) = dt.Rows(i)("CHECK_TYPE")
                    dgView.Item(10, i).Value = dt.Rows(i)("CHECK_NO")
                    _chekNo(i) = dt.Rows(i)("CHECK_NO")
                    dgView.Item(11, i).Value = dt.Rows(i)("AMOUNT")
                    _amount(i) = dt.Rows(i)("AMOUNT")
                    dgView.Item(12, i).Value = dt.Rows(i)("CHECK_REF")
                    _checkRef(i) = dt.Rows(i)("CHECK_REF")

                    dgView.Item(13, i).Value = dt.Rows(i)("RTN_STATUS")
                    dgView.Item(14, i).Value = dt.Rows(i)("NONZONE_REF")
                    dgView.Item(15, i).Value = dt.Rows(i)("REMINDER_DATE")
                    dgView.Item(16, i).Value = dt.Rows(i)("REMINDER_NO")
                    dgView.Item(17, i).Value = dt.Rows(i)("RTN_CODE")

                    dgView.Item(18, i).Value = dt.Rows(i)("FILENAME")
                    dgView.Item(19, i).Value = dt.Rows(i)("FILE_USER_ID")
                    dgView.Item(20, i).Value = dt.Rows(i)("FLEXGEN_DATE")


                Next
                dgView.AllowUserToAddRows = False

            End If



            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadDepositSlipData(ByVal strDCode As String)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_GetMaxMod")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@D_CODE", DbType.String, strDCode)

            Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            If intModNo > 0 Then
                LoadMainData(strDCode, intModNo)

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheckTotal_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
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

    Public Sub New(ByVal strDCode As String, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strDCode = strDCode

        _intModno = intmod

    End Sub


#End Region



    Private Sub FrmCitiCheckDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intModno > 0 Then
            LoadMainData(_strDCode, _intModno)
            LoadDetailData(_strDCode, _intModno)
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
        If Not (_strDCode = "") Then

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


        If txtDepoCode.Enabled = True Then
            txtDepoCode.Focus()
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

                        'LoadMainData(_strDCode, _intModno)
                        'LoadDetailData(_strDCode, _intModno)

                        btnNew_Click(sender, e)

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

                        'LoadMainData(_strDCode, _intModno)
                        'LoadDetailData(_strDCode, _intModno)

                        btnNew_Click(sender, e)

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

        LoadMainData(_strDCode, _intModno)
        LoadDetailData(_strDCode, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadMainData(_strDCode, _intModno)
                    LoadDetailData(_strDCode, _intModno)

                    DisableAuth()

                    If _strDCode = "" Then

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

            LoadMainData(_strDCode, _intModno - 1)
            LoadDetailData(_strDCode, _intModno)

        End If

    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click

        Dim strDCode As String = _strDCode
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_strDCode, _intModno + 1)

            If _intModno = 0 Then
                LoadMainData(strDCode, intModno)
            End If

            LoadDetailData(_strDCode, _intModno)
        End If


    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            ShowOpertionStatus()

            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadMainDataForAuth(_strDCode)
                    LoadDetailDataForAuth(_strDCode)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_strDCode, _intModno)
                    LoadDetailData(_strDCode, _intModno)

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

    
   
    
    Private Sub txtDepoCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoCode.KeyDown
        If e.KeyCode = Keys.Enter And txtDepoCode.Text.Trim() <> "" Then

            'If txtDepoCode.Text.Trim().Length < 7 Then
            '    MessageBox.Show("Not less than 7 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtDepoCode.Focus()
            '    Exit Sub
            'End If


            'LoadDepositSlipData(txtDepoCode.Text.Trim())

            'If _intModno > 0 Then
            '    txtDepoCode.ReadOnly = True
            '    LoadDetailData(_strDCode, _intModno)
            'Else


            'End If

            SendKeys.Send("{tab}")




        End If
    End Sub

    Private Sub txtDepoLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoLocationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDepoLocationCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Location List"
                frmList.ProcName = "CMS_Location_GetList"
                frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtDepoLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblDepoLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtDepoLocationCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblDepoLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                    Else
                        txtDepoLocationCode.Clear()
                        lblDepoLocationName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDepoLocationCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
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
                'SendKeys.Send("{tab}")
            End If

        End If

    End Sub

    Private Sub txtSlipDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlipDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtValueDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValueDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

   
    Private Sub txtCustomerRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDrawerAccNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDrawerAccNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDraweeBankCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBankCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDraweeBankCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank List"
                frmList.ProcName = "CMS_Bank_GetList"
                frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtDraweeBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblDraweeBankName.Text = frmList.RowResult.Cells(1).Value.ToString()

                    txtDraweeBranchCode.Clear()
                    lblDraweeBranchName.Text = ""

                    txtDraweeLocationCode.Clear()
                    lblDraweeLocationName.Text = ""
                End If

                frmList.Dispose()

            Else


                Try



                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblDraweeBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                    Else
                        txtDraweeBankCode.Clear()
                        lblDraweeBankName.Text = ""

                        txtDraweeBranchCode.Clear()
                        lblDraweeBranchName.Text = ""

                        txtDraweeLocationCode.Clear()
                        lblDraweeLocationName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDraweeBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
        End If
    End Sub

    Private Sub txtDraweeBranchCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBranchCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDraweeBranchCode.Text.Trim() = "" Then

                If txtDraweeLocationCode.Text.Trim() = "" Then

                    Dim frmList As New FrmList()
                    frmList.Text = "Branch List"
                    frmList.ProcName = "CMS_Branch_GetListByBank"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                    frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtDraweeBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblDraweeBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()

                Else

                    Dim frmList As New FrmList()
                    frmList.Text = "Branch List"
                    frmList.ProcName = "CMS_Branch_GetListByBankLocName"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                    frmList.AddParamToDB("@LOCATION_CODE", DbType.String, txtDraweeLocationCode.Text.Trim())
                    frmList.AddParamToDB("@LOCATION_NAME", DbType.String, lblDraweeLocationName.Text.Trim())
                    frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtDraweeBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblDraweeBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()


                End If

                
            Else


                'Try



                '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                '    Dim dt As New DataTable

                '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_GetDetailByCode")

                '    commProc.Parameters.Clear()

                '    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                '    db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, txtDraweeBranchCode.Text.Trim())

                '    dt = db.ExecuteDataSet(commProc).Tables(0)

                '    If dt.Rows.Count > 0 Then
                '        lblDraweeBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                '    Else
                '        txtDraweeBranchCode.Clear()
                '        lblDraweeBranchName.Text = ""
                '    End If


                'Catch ex As Exception
                '    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try



            End If

            If txtDraweeBranchCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
        End If
    End Sub

    Private Sub txtDraweeLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeLocationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDraweeLocationCode.Text.Trim() = "" Then

                If txtDraweeBranchCode.Text.Trim() = "" Then

                    Dim frmList As New FrmList()
                    frmList.Text = "Location List"
                    frmList.ProcName = "CMS_Location_GetListByBank"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                    frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtDraweeLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblDraweeLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()


                Else

                    Dim frmList As New FrmList()
                    frmList.Text = "Location List"
                    frmList.ProcName = "CMS_Location_GetListByBankBranchName"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                    frmList.AddParamToDB("@BRANCH_CODE", DbType.String, txtDraweeBranchCode.Text.Trim())
                    frmList.AddParamToDB("@BRANCH_NAME", DbType.String, lblDraweeBranchName.Text.Trim())
                    frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtDraweeLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblDraweeLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()



                End If

                
            Else


                Try



                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtDraweeLocationCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblDraweeLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                    Else
                        txtDraweeLocationCode.Clear()
                        lblDraweeLocationName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDraweeLocationCode.Text.Trim() <> "" Then

                'Try



                '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                '    Dim dt As New DataTable

                '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Zone_GetDetailByBankBranchLoc")

                '    commProc.Parameters.Clear()

                '    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                '    db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, txtDraweeBranchCode.Text.Trim())
                '    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtDraweeLocationCode.Text.Trim())

                '    dt = db.ExecuteDataSet(commProc).Tables(0)

                '    If dt.Rows.Count > 0 Then
                '        lblClearingZoneCode.Text = dt.Rows(0)("ZONE_CODE").ToString()
                '        lblClearingZone.Text = dt.Rows(0)("ZONE_NAME").ToString()
                '    Else
                '        lblClearingZoneCode.Text = ""
                '        lblClearingZone.Text = ""
                '    End If


                'Catch ex As Exception
                '    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try


                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
        End If
    End Sub

    Private Sub cmbCheckType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCheckType.KeyDown
        If e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{tab}")
            txtCheckNo.Focus()
        End If
    End Sub

    Private Sub txtCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click

        If txtDepoCode.Text.Trim() = "" Then

            MessageBox.Show("Deposit code required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Exit Sub
        End If

        If txtClientCode.Text.Trim() = "" Or lblAccName.Text.Trim() = "" Then

            MessageBox.Show("Client code equired !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Exit Sub
        End If

        If txtSlipDate.Text.Trim() = "/  /" Then

            MessageBox.Show("Slip date equired !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlipDate.Focus()
            Exit Sub
        End If

        If txtValueDate.Text.Trim() = "/  /" Then

            MessageBox.Show("Value date equired !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtValueDate.Focus()
            Exit Sub
        End If

        If txtDepoLocationCode.Text.Trim() = "" Or lblDepoLocationName.Text.Trim() = "" Then
            MessageBox.Show("Deopsit location code required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Exit Sub
        End If

        If txtTotalCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Total Check No. required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckNo.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtTotalAmount.Text) = 0 Then
            MessageBox.Show("Total Check amount required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalAmount.Focus()
            Exit Sub
        End If

        If txtDrawerAccNo.Text.Trim() = "" Then
            MessageBox.Show("Drawer A/C No required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDrawerAccNo.Focus()
            Exit Sub
        End If


        If txtDraweeBankCode.Text.Trim() = "" Or lblDraweeBankName.Text.Trim() = "" Then
            MessageBox.Show("Drawee Bank required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDraweeBankCode.Focus()
            Exit Sub
        End If

        If txtDraweeBranchCode.Text.Trim() = "" Or lblDraweeBranchName.Text.Trim() = "" Then
            MessageBox.Show("Drawee Branch required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDraweeBranchCode.Focus()
            Exit Sub
        End If

        If txtDraweeLocationCode.Text.Trim() = "" Or lblDraweeLocationName.Text.Trim() = "" Then
            MessageBox.Show("Drawee Location required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDraweeLocationCode.Focus()
            Exit Sub
        End If

        If txtCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Check No. required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNo.Focus()
            Exit Sub
        End If

        If txtCheckDate.Text.Trim() = "/  /" Then

            MessageBox.Show("Check date equired !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckDate.Focus()
            Exit Sub
        End If


        If NullHelper.ToDecNum(txtAmount.Text) = 0 Then
            MessageBox.Show("Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("CASH_CR_TYPE").ToString().Trim() = "R" And txtCustomerRef.Text.Trim() = "" Then
                    MessageBox.Show("This client customer ref. cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCustomerRef.Focus()
                    Exit Sub

                End If

            Else

                MessageBox.Show("No client information found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


        If _RowEditMode = True Then
            Dim selRow As Integer = lblRowNo.Text.Trim()

            dgView.Item(1, selRow).Value = txtDrawerAccNo.Text.Trim()
            dgView.Item(2, selRow).Value = txtDraweeBankCode.Text.Trim()
            dgView.Item(3, selRow).Value = lblDraweeBankName.Text.Trim()
            dgView.Item(4, selRow).Value = txtDraweeLocationCode.Text.Trim()
            dgView.Item(5, selRow).Value = lblDraweeLocationName.Text.Trim()
            dgView.Item(6, selRow).Value = txtDraweeBranchCode.Text.Trim()
            dgView.Item(7, selRow).Value = lblDraweeBranchName.Text.Trim()
            dgView.Item(8, selRow).Value = IIf(txtCheckDate.Text.Trim() = "/  /", "", txtCheckDate.Text.Trim())
            dgView.Item(9, selRow).Value = cmbCheckType.Text.Trim()
            dgView.Item(10, selRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(11, selRow).Value = NullHelper.ToDecNum(txtAmount.Text.Trim())
            dgView.Item(12, selRow).Value = txtCheckRef.Text.Trim()


            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(selRow).Selected = True


        Else

            Dim MaxSlNo As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                If MaxSlNo <= NullHelper.ToIntNum(row.Cells(0).Value) Then
                    MaxSlNo = NullHelper.ToIntNum(row.Cells(0).Value) + 1
                End If


            Next

            dgView.Rows.Add()

            Dim maxRow As Integer = dgView.Rows.Count - 1

            dgView.Item(0, maxRow).Value = MaxSlNo 'maxRow + 1
            dgView.Item(1, maxRow).Value = txtDrawerAccNo.Text.Trim()
            dgView.Item(2, maxRow).Value = txtDraweeBankCode.Text.Trim()
            dgView.Item(3, maxRow).Value = lblDraweeBankName.Text.Trim()
            dgView.Item(4, maxRow).Value = txtDraweeLocationCode.Text.Trim()
            dgView.Item(5, maxRow).Value = lblDraweeLocationName.Text.Trim()
            dgView.Item(6, maxRow).Value = txtDraweeBranchCode.Text.Trim()
            dgView.Item(7, maxRow).Value = lblDraweeBranchName.Text.Trim()
            dgView.Item(8, maxRow).Value = IIf(txtCheckDate.Text.Trim() = "/  /", "", txtCheckDate.Text.Trim())
            dgView.Item(9, maxRow).Value = cmbCheckType.Text.Trim()
            dgView.Item(10, maxRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(11, maxRow).Value = NullHelper.ToDecNum(txtAmount.Text.Trim())
            dgView.Item(12, maxRow).Value = txtCheckRef.Text.Trim()

            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(maxRow).Selected = True

        End If

        '--

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        '---


        txtDrawerAccNo.Clear()
        txtDraweeBankCode.Clear()
        lblDraweeBankName.Text = ""
        txtDraweeBranchCode.Clear()
        lblDraweeBranchName.Text = ""
        txtDraweeLocationCode.Clear()
        lblDraweeLocationName.Text = ""
        lblClearingZone.Text = ""
        cmbCheckType.Text = ""
        txtCheckNo.Clear()
        txtCheckRef.Clear()
        txtCheckDate.Clear()
        txtAmount.Text = "0"

        dgView.Enabled = True

        txtDrawerAccNo.Focus()


    End Sub

    Private Sub btnRemoveFromGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromGrid.Click
        If dgView.SelectedRows.Count = 0 Then Exit Sub

        For Each row As DataGridViewRow In dgView.SelectedRows
            dgView.Rows.Remove(row)
        Next

        'Dim rowSlno As Integer = 1

        'For Each row As DataGridViewRow In dgView.Rows
        '    row.Cells(0).Value = rowSlno
        '    rowSlno = rowSlno + 1
        'Next


        If _intModno = 0 Or (_intModno = 1 And chkAuthorized.Checked = False) Then

            Dim rowSlno As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                row.Cells(0).Value = rowSlno
                rowSlno = rowSlno + 1
            Next

        End If



    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        txtDrawerAccNo.Clear()
        txtDraweeBankCode.Clear()
        lblDraweeBankName.Text = ""
        txtDraweeBranchCode.Clear()
        lblDraweeBranchName.Text = ""
        txtDraweeLocationCode.Clear()
        lblDraweeLocationName.Text = ""
        lblClearingZone.Text = ""
        cmbCheckType.Text = ""
        txtCheckNo.Clear()
        txtCheckRef.Clear()
        txtCheckDate.Clear()
        txtAmount.Text = "0"

        dgView.Enabled = True
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _RowEditMode = True

            btnAddToGrid.Text = "Update"
            btnCancel.Visible = True
            btnRemoveFromGrid.Enabled = False


            lblRowNo.Text = e.RowIndex.ToString()

            txtDrawerAccNo.Text = dgView.Item(1, e.RowIndex).Value
            txtDraweeBankCode.Text = dgView.Item(2, e.RowIndex).Value
            lblDraweeBankName.Text = dgView.Item(3, e.RowIndex).Value
            txtDraweeLocationCode.Text = dgView.Item(4, e.RowIndex).Value
            lblDraweeLocationName.Text = dgView.Item(5, e.RowIndex).Value
            txtDraweeBranchCode.Text = NullHelper.ObjectToString(dgView.Item(6, e.RowIndex).Value)
            lblDraweeBranchName.Text = NullHelper.ObjectToString(dgView.Item(7, e.RowIndex).Value)
            txtCheckDate.Text = dgView.Item(8, e.RowIndex).Value
            cmbCheckType.Text = NullHelper.ObjectToString(dgView.Item(9, e.RowIndex).Value)
            txtCheckNo.Text = NullHelper.ObjectToString(dgView.Item(10, e.RowIndex).Value)
            txtAmount.Text = dgView.Item(11, e.RowIndex).Value
            txtCheckRef.Text = NullHelper.ObjectToString(dgView.Item(12, e.RowIndex).Value)

            dgView.Enabled = False

            
        End If
    End Sub

   
    
    

    
    
    Private Sub dgView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellValueChanged

        If e.ColumnIndex = 11 Then

            Dim CheckTotal As Decimal = 0

            For Each row As DataGridViewRow In dgView.Rows

                If Not row.Cells(11).Value Is Nothing Then
                    CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(11).Value)
                End If


            Next

            lblCheckCountStatus.Text = CheckTotal.ToString()

        End If
    End Sub

  
    Private Sub txtSlipDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSlipDate.Validating
        If CommonUtil.DateValidate(txtSlipDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtValueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtValueDate.Validating
        If CommonUtil.DateValidate(txtValueDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCheckDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCheckDate.Validating
        If CommonUtil.DateValidate(txtCheckDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    
    Private Sub txtTotalCheckNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCheckNo.Validating
        If CommonUtil.IntValidate(txtTotalCheckNo.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTotalAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalAmount.Validating
        If CommonUtil.DecValidate(txtTotalAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If CommonUtil.DecValidate(txtAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDepoCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDepoCode.Validating
        If txtDepoCode.Text.Trim() <> "" And _intModno = 0 Then

            If txtDepoCode.Text.Trim().Length < 7 Then
                MessageBox.Show("Not less than 7 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDepoCode.Focus()
                Exit Sub
            End If


            LoadDepositSlipData(txtDepoCode.Text.Trim())

            If _intModno > 0 Then
                txtDepoCode.ReadOnly = True
                LoadDetailData(_strDCode, _intModno)
            Else


            End If

            'SendKeys.Send("{tab}")




        End If
    End Sub

    
    Private Sub txtDraweeBankCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweeBankCode.Validated
        If txtDraweeBankCode.Text.Trim() = "" Then
            lblDraweeBankName.Text = ""
            txtDraweeBranchCode.Text = ""
            lblDraweeBranchName.Text = ""
            txtDraweeLocationCode.Text = ""
            lblDraweeLocationName.Text = ""
        End If
    End Sub

    Private Sub txtDraweeBranchCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweeBranchCode.Validated

        If txtDraweeBranchCode.Text.Trim() = "" Then


            lblDraweeBranchName.Text = ""
            
        End If

    End Sub

    Private Sub txtDraweeLocationCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweeLocationCode.Validated

        If txtDraweeLocationCode.Text.Trim() = "" Then

            lblDraweeLocationName.Text = ""
        End If

    End Sub

    Private Sub txtDepoLocationCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepoLocationCode.Validated
        If txtDepoLocationCode.Text.Trim() = "" Then

            lblDepoLocationName.Text = ""
        End If
    End Sub
End Class