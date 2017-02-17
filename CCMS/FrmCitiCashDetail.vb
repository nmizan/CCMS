'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Citi Cash Detail
'Creation date      : 06-Jan-2013
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization


Public Class FrmCitiCashDetail


#Region "Global Variables"
    Public Shared AddText As String = ""
    Dim _formName As String = "DepositCitiCashDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _strDCode As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _strId As String = ""

    Dim log_message As String

    'For Update
    Dim _slipDate As String = ""
    Dim _cashRef As String = ""
    Dim _custRef As String = ""

    'For Auth
    Dim _aslipDate As String = ""
    Dim _acashRef As String = ""
    Dim _acustRef As String = ""

    Dim CitiCashList As New List(Of String)
    Dim _cashLog As String = ""
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
        'btnSearch.Enabled = False

        'txtSlipDate.ReadOnly = True
        txtCashRef.ReadOnly = True
        txtCustomerRef.ReadOnly = True
        txtReferenceNumber.ReadOnly = True
        txtTitle.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtMiddle.ReadOnly = True
        txtLast.ReadOnly = True
        txtSSN.ReadOnly = True
        txtIDNumber.ReadOnly = True
        txtPassportNo.ReadOnly = True
        txtPhone.ReadOnly = True
        txtNationality.ReadOnly = True
        txtAddress.ReadOnly = True
        txtSourceWealth.ReadOnly = True

    End Sub

    Private Sub EnableFields()

        If _intModno = 0 Then
            txtDepoCode.ReadOnly = False
            ' btnSearch.Enabled = True
        End If

        'txtSlipDate.ReadOnly = False
        txtCashRef.ReadOnly = False
        txtCustomerRef.ReadOnly = False
        txtReferenceNumber.ReadOnly = False
        txtTitle.ReadOnly = False
        txtFirstName.ReadOnly = False
        txtMiddle.ReadOnly = False
        txtLast.ReadOnly = False
        txtSSN.ReadOnly = False
        txtIDNumber.ReadOnly = False
        txtPassportNo.ReadOnly = False
        txtPhone.ReadOnly = False
        txtNationality.ReadOnly = False
        txtAddress.ReadOnly = False
        txtSourceWealth.ReadOnly = False

    End Sub


    Private Sub ClearFields()

        'txtSlipDate.Clear()
        txtCashRef.Clear()
        txtCustomerRef.Clear()

    End Sub

    Private Sub ClearFieldsAll()

        txtDepoCode.Clear()

        AddText = ""
        lblDepoScheCode.Text = ""
        lblScheduleDate.Text = ""
        lblLocationCode.Text = ""
        lblLocationName.Text = ""
        lblCorrBankCode.Text = ""
        lblCorrBankName.Text = ""
        lblCorrBranchCode.Text = ""
        lblCorrBranchName.Text = ""
        lblClientCode.Text = ""
        lblAccName.Text = ""
        lblAmount.Text = ""


        txtSlipDate.Clear()
        txtCashRef.Clear()
        txtCustomerRef.Clear()

        txtReferenceNumber.Clear()
        txtTitle.Clear()
        txtFirstName.Clear()
        txtMiddle.Clear()
        txtLast.Clear()
        txtIDNumber.Clear()
        txtSSN.Clear()
        txtNationality.Clear()
        txtSourceWealth.Clear()
        txtId.Clear()
        txtAddress.Clear()
        txtPhone.Clear()
        txtPassportNo.Clear()

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

    Private Function CheckValidData() As Boolean

       

        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False

        ElseIf lblDepoScheCode.Text.Trim() = "" Then
            MessageBox.Show("Load Deposit Code !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False

        ElseIf txtSlipDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Slip Date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlipDate.Focus()
            Return False
        ElseIf txtFirstName.Text.Trim() = "" Then
            MessageBox.Show("First Name Required  !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFirstName.Focus()
            Return False
        ElseIf txtLast.Text.Trim() = "" Then
            MessageBox.Show("Last Name required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLast.Focus()
            Return False
        ElseIf txtSSN.Text.Trim() = "" And txtIDNumber.Text.Trim() = "" And txtPassportNo.Text.Trim() = "" Then

            MessageBox.Show(" National ID/ Birth Registration Number/ Passport Number required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSSN.Focus()
            Return False

        End If
         

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, lblClientCode.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("CASH_CR_TYPE").ToString().Trim() = "R" And txtCustomerRef.Text.Trim() = "" Then
                    MessageBox.Show("This client customer ref. cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCustomerRef.Focus()
                    Return False
                End If


                If dt.Rows(0)("CASH_CR_TYPE").ToString().Trim() = "R" And String.IsNullOrEmpty(txtCashRef.Text.Trim()) Then
                    MessageBox.Show("Cash Ref required for this client !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCashRef.Focus()
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


        Return True

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then


            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
            db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
            db.AddInParameter(commProc, "@CASH_REF", DbType.String, txtCashRef.Text.Trim())
            AddText.Replace("\n", ",")
            db.AddInParameter(commProc, "@ADD_TEXT", DbType.String, AddText)
            db.AddInParameter(commProc, "@SLIP_DATE", DbType.DateTime, DateTime.ParseExact(txtSlipDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

            If result <> 0 Then
                tStatus = TransState.Exist
                Return tStatus


            Else
                '--------------------- Mizan Work (02-June-2016)---------------------------

                Dim comProc As DbCommand = db.GetStoredProcCommand("CMS_MAX_Bearer_ID")

                comProc.Parameters.Clear()
                Dim maxid As String = db.ExecuteDataSet(comProc).Tables(0).Rows(0)(0).ToString()

                txtId.Text = maxid + 1

                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Bearer_Add")

                commProc1.Parameters.Clear()

                db.AddInParameter(commProc1, "@REFERENCE_NUMBER", DbType.String, txtReferenceNumber.Text.Trim())
                db.AddInParameter(commProc1, "@PERSON_ID", DbType.String, txtId.Text.Trim())
                db.AddInParameter(commProc1, "@TITLE", DbType.String, txtTitle.Text.Trim())
                db.AddInParameter(commProc1, "@FIRST_NAME", DbType.String, txtFirstName.Text.Trim())
                db.AddInParameter(commProc1, "@MIDDLE_NAME", DbType.String, txtMiddle.Text.Trim())
                db.AddInParameter(commProc1, "@LAST_NAME", DbType.String, txtLast.Text.Trim())
                db.AddInParameter(commProc1, "@SSN", DbType.String, txtSSN.Text.Trim())
                db.AddInParameter(commProc1, "@PASSPORT_NUMBER", DbType.String, txtPassportNo.Text.Trim())
                db.AddInParameter(commProc1, "@ID_NUMBER", DbType.String, txtIDNumber.Text.Trim())
                db.AddInParameter(commProc1, "@NATIONALITY", DbType.String, txtNationality.Text.Trim())
                db.AddInParameter(commProc1, "@SOURCE_OF_WEALTH", DbType.String, txtSourceWealth.Text.Trim())
                db.AddInParameter(commProc1, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc1, "@DS_CODE", DbType.String, lblDepoScheCode.Text.Trim())

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                db.ExecuteNonQuery(commProc1)
                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result <> 0 Then

                    tStatus = TransState.UnspecifiedError
                    Return tStatus

                End If

                'Add Phone

                Dim _phoneId As Integer = 1
                Dim _sId As String = "P"
                Dim _slNo As Integer = 1
                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_BearerPhone_Add")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@TPH_ID", DbType.Int16, _phoneId)
                db.AddInParameter(commProc2, "@PERSON_ID", DbType.String, txtId.Text.Trim())
                db.AddInParameter(commProc2, "@SID", DbType.String, _sId)
                db.AddInParameter(commProc2, "@SLNO", DbType.Int16, _slNo)
                db.AddInParameter(commProc2, "@TPH_NUMBER", DbType.String, txtPhone.Text.Trim())
                db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc2, "@DS_CODE", DbType.String, lblDepoScheCode.Text.Trim())

                db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                db.ExecuteNonQuery(commProc2)
                result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

                If result <> 0 Then
                    tStatus = TransState.UnspecifiedError
                    Return tStatus

                End If

                'Add Address

                Dim _addressId As Integer = 1
                
                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_BearerAddress_Add")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc3, "@ADDRESS_ID", DbType.Int16, _addressId)
                db.AddInParameter(commProc3, "@PERSON_ID", DbType.String, txtId.Text.Trim())
                db.AddInParameter(commProc3, "@SID", DbType.String, _sId)
                db.AddInParameter(commProc3, "@SLNO", DbType.Int16, _slNo)
                db.AddInParameter(commProc3, "@ADDRESS", DbType.String, txtAddress.Text.Trim())
                db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc3, "@DS_CODE", DbType.String, lblDepoScheCode.Text.Trim())

                db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                db.ExecuteNonQuery(commProc3)
                result = db.GetParameterValue(commProc3, "@PROC_RET_VAL")

                If result <> 0 Then
                    tStatus = TransState.UnspecifiedError
                    Return tStatus

                End If
                '--------------------- Mizan Work (02-June-2016)---------------------------

                tStatus = TransState.Add
                _strDCode = txtDepoCode.Text.Trim()
                _intModno = 1
                _strId = txtId.Text.Trim()

                '------------Mizan Work (08-05-2016)------------

                log_message = " Added : Citi Cash Deposit Code : " + txtDepoCode.Text.Trim()
                Logger.system_log(log_message)

                log_message = " Added : Bearer Person ID : " + txtId.Text.Trim() + "." + " " + " Bearer/Depositor Name : " + txtTitle.Text.ToString() + " " + txtFirstName.Text.ToString() + " " + txtMiddle.Text.ToString() + " " + txtLast.Text.ToString()
                Logger.system_log(log_message)
                '------------Mizan Work (08-05-2016)------------

                End If



        ElseIf _formMode = FormTransMode.Update Then


            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
            db.AddInParameter(commProc, "@PERSON_ID", DbType.String, _strId)
            db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
            db.AddInParameter(commProc, "@CASH_REF", DbType.String, txtCashRef.Text.Trim())
            AddText.Replace("\n", ",")
            db.AddInParameter(commProc, "@ADD_TEXT", DbType.String, AddText)
            db.AddInParameter(commProc, "@SLIP_DATE", DbType.DateTime, DateTime.ParseExact(txtSlipDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
            db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

            If result = 1 Then
                tStatus = TransState.UnspecifiedError

                Return tStatus
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

                Return tStatus
            ElseIf result = 0 Then

                intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")
            End If

            'Update Bearer Info '------------Mizan Work (04-06-2016)------------

            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Bearer_Info_Update")

            commProc1.Parameters.Clear()

            db.AddInParameter(commProc1, "@REFERENCE_NUMBER", DbType.String, txtReferenceNumber.Text.Trim())
            db.AddInParameter(commProc1, "@PERSON_ID", DbType.String, _strId)
            db.AddInParameter(commProc1, "@TITLE", DbType.String, txtTitle.Text.Trim())
            db.AddInParameter(commProc1, "@FIRST_NAME", DbType.String, txtFirstName.Text.Trim())
            db.AddInParameter(commProc1, "@MIDDLE_NAME", DbType.String, txtMiddle.Text.Trim())
            db.AddInParameter(commProc1, "@LAST_NAME", DbType.String, txtLast.Text.Trim())
            db.AddInParameter(commProc1, "@SSN", DbType.String, txtSSN.Text.Trim())
            db.AddInParameter(commProc1, "@PASSPORT_NUMBER", DbType.String, txtPassportNo.Text.Trim())
            db.AddInParameter(commProc1, "@ID_NUMBER", DbType.String, txtIDNumber.Text.Trim())
            db.AddInParameter(commProc1, "@NATIONALITY", DbType.String, txtNationality.Text.Trim())
            db.AddInParameter(commProc1, "@SOURCE_OF_WEALTH", DbType.String, txtSourceWealth.Text.Trim())
            db.AddInParameter(commProc1, "@D_CODE", DbType.String, _strDCode)
            db.AddInParameter(commProc1, "@DS_CODE", DbType.String, lblDepoScheCode.Text.Trim())
            db.AddInParameter(commProc1, "@MOD_NO", DbType.Int32, intModno)


            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
            db.ExecuteNonQuery(commProc1)
            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

            If result <> 0 Then

                tStatus = TransState.UnspecifiedError
                Return tStatus

            End If

            'Update Bearer Phone
            Dim _phoneId As Integer = 1
            Dim _sId As String = "P"
            Dim _slNo As Integer = 1

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_BearerPhone_Update")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@TPH_ID", DbType.Int16, _phoneId)
            db.AddInParameter(commProc2, "@PERSON_ID", DbType.String, _strId)
            db.AddInParameter(commProc2, "@SID", DbType.String, _sId)
            db.AddInParameter(commProc2, "@SLNO", DbType.Int16, _slNo)
            db.AddInParameter(commProc2, "@TPH_NUMBER", DbType.String, txtPhone.Text.Trim())
            db.AddInParameter(commProc2, "@D_CODE", DbType.String, _strDCode)
            db.AddInParameter(commProc2, "@DS_CODE", DbType.String, lblDepoScheCode.Text.Trim())
            db.AddInParameter(commProc2, "@MOD_NO", DbType.Int32, intModno)

            db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
            db.ExecuteNonQuery(commProc2)
            result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

            If result <> 0 Then
                tStatus = TransState.UnspecifiedError
                Return tStatus

            End If

            'Update Bearer Address

            Dim _addressId As Integer = 1
            Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_BearerAddress_Update")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc3, "@ADDRESS_ID", DbType.Int16, _addressId)
            db.AddInParameter(commProc3, "@PERSON_ID", DbType.String, _strId)
            db.AddInParameter(commProc3, "@SID", DbType.String, _sId)
            db.AddInParameter(commProc3, "@SLNO", DbType.Int16, _slNo)
            db.AddInParameter(commProc3, "@ADDRESS", DbType.String, txtAddress.Text.Trim())
            db.AddInParameter(commProc3, "@D_CODE", DbType.String, _strDCode)
            db.AddInParameter(commProc3, "@DS_CODE", DbType.String, lblDepoScheCode.Text.Trim())
            db.AddInParameter(commProc3, "@MOD_NO", DbType.Int32, intModno)

            db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
            db.ExecuteNonQuery(commProc3)
            result = db.GetParameterValue(commProc3, "@PROC_RET_VAL")

            If result <> 0 Then
                tStatus = TransState.UnspecifiedError
                Return tStatus

            End If

            tStatus = TransState.Update
            _intModno = intModno

            '------------Mizan Work (08-05-2016)------------

            If _slipDate <> txtSlipDate.Text.Trim() Then
                log_message = " Slip Date : " + _slipDate + " " + " To " + " " + txtSlipDate.Text.Trim() + "." + " "
                CitiCashList.Add(log_message)
            End If

            If _cashRef <> txtCashRef.Text.Trim() Then
                log_message = " Cash Ref. : " + _cashRef + " " + " To " + " " + txtCashRef.Text.Trim() + "." + " "
                CitiCashList.Add(log_message)
            End If
            If _custRef <> txtCustomerRef.Text.Trim() Then
                log_message = " Customer Ref. : " + _custRef + " " + " To " + " " + txtCustomerRef.Text.Trim() + "." + " "
                CitiCashList.Add(log_message)
            End If

            For Each cashInfo As String In CitiCashList
                _cashLog += cashInfo
            Next
            _log = " Updated : Citi Cash Deposit Code : " + txtDepoCode.Text.ToString() + "." + " " + _cashLog

            Logger.system_log(_log)

            _cashLog = ""
            CitiCashList.Clear()

            '------------Mizan Work (08-05-2016)------------

            Return tStatus



        End If


        Return tStatus

    End Function

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
        db.AddInParameter(commProc, "@PERSON_ID", DbType.String, _strId)
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

                If _aslipDate <> _slipDate Then
                    log_message = " Slip Date : " + _aslipDate + " " + " To " + " " + _slipDate + "." + " "
                    CitiCashList.Add(log_message)
                End If

                If _acashRef <> _cashRef Then
                    log_message = " Cash Ref. : " + _acashRef + " " + " To " + " " + _cashRef + "." + " "
                    CitiCashList.Add(log_message)
                End If
                If _acustRef <> _custRef Then
                    log_message = " Customer Ref. : " + _acustRef + " " + " To " + " " + _custRef + "." + " "
                    CitiCashList.Add(log_message)
                End If

                For Each cashInfo As String In CitiCashList
                    _cashLog += cashInfo
                Next
                _log = " Authorized : Citi Cash Deposit Code : " + txtDepoCode.Text.ToString() + "." + " " + _cashLog

                Logger.system_log(_log)

                _cashLog = ""
                CitiCashList.Clear()

            Else

                _log = " Authorized : Citi Cash Deposit Code : " + txtDepoCode.Text.ToString()
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
        ElseIf result = 11 Then
            tStatus = TransState.ParentNotExist
        Else
            tStatus = TransState.UpdateNotPossible
        End If

        Return tStatus

    End Function

    '------------Mizan Work (15-05-2016)------------

    Private Sub LoadDepositCashDataForAuth(ByVal strDCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CCASH Where D_CODE ='" & strDCode & "'  and STATUS='L'").Tables(0)

            If dt.Rows.Count > 0 Then

                _strDCode = strDCode

                AddText = dt.Rows(0)("ADD_TEXT").ToString()
                txtSlipDate.Text = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE"))
                _aslipDate = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE")).ToString
                txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
                _acustRef = dt.Rows(0)("CUSTOMER_REF").ToString()
                txtCashRef.Text = dt.Rows(0)("CASH_REF").ToString()
                _acashRef = dt.Rows(0)("CASH_REF").ToString()


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadDepositCashData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _strDCode = strDCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                AddText = dt.Rows(0)("ADD_TEXT").ToString()
                txtSlipDate.Text = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE"))
                _slipDate = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE")).ToString
                txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
                _custRef = dt.Rows(0)("CUSTOMER_REF").ToString()
                txtCashRef.Text = dt.Rows(0)("CASH_REF").ToString()
                _cashRef = dt.Rows(0)("CASH_REF").ToString()

                lblInputBy.Text = dt.Rows(0)("INPUT_BY").ToString()
                lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME").ToString()

                _mod_datetime = dt.Rows(0)("INPUT_DATETIME")

                lblAuthBy.Text = dt.Rows(0)("AUTH_BY").ToString()
                lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME").ToString()

                chkAuthorized.Checked = dt.Rows(0)("IS_AUTH")

                If dt.Rows(0)("STATUS") = "L" Or dt.Rows(0)("STATUS") = "U" Or dt.Rows(0)("STATUS") = "O" Then
                    chkOpen.Checked = True
                Else
                    chkOpen.Checked = False
                End If

                _status = dt.Rows(0)("STATUS")

                lblModNo.Text = dt.Rows(0)("MOD_NO").ToString()
                lblVerNo.Text = dt.Rows(0)("MOD_NO").ToString()

                '------------Mizan Work (04-06-2016)------------
                LoadDepositCashBearerInfoData(strDCode, intMod)
                LoadDepositCashBearerPhoneData(strDCode, intMod)
                LoadDepositCashBearerAddressData(strDCode, intMod)
                '------------Mizan Work (04-06-2016)------------

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetMaxMod")

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
    '------------Mizan Work (04-06-2016)------------
    Private Sub LoadDepositCashBearerInfoData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bearer_Info_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _strDCode = strDCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                txtId.Text = dt.Rows(0)("PERSON_ID").ToString()
                _strId = dt.Rows(0)("PERSON_ID").ToString()
                txtReferenceNumber.Text = dt.Rows(0)("REFERENCE_NUMBER").ToString()
                txtTitle.Text = dt.Rows(0)("TITLE").ToString()
                txtFirstName.Text = dt.Rows(0)("FIRST_NAME").ToString()
                txtMiddle.Text = dt.Rows(0)("MIDDLE_NAME").ToString()
                txtLast.Text = dt.Rows(0)("LAST_NAME").ToString()
                txtSSN.Text = dt.Rows(0)("SSN").ToString()
                txtPassportNo.Text = dt.Rows(0)("PASSPORT_NUMBER").ToString()
                txtIDNumber.Text = dt.Rows(0)("ID_NUMBER").ToString()
                txtNationality.Text = dt.Rows(0)("NATIONALITY").ToString()
                txtSourceWealth.Text = dt.Rows(0)("SOURCE_OF_WEALTH").ToString()



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '------------Mizan Work (04-06-2016)------------
    Private Sub LoadDepositCashBearerPhoneData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bearer_Phone_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _strDCode = strDCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                txtPhone.Text = dt.Rows(0)("TPH_NUMBER").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '------------Mizan Work (04-06-2016)------------

    Private Sub LoadDepositCashBearerAddressData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bearer_Address_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _strDCode = strDCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                txtAddress.Text = dt.Rows(0)("ADDRESS").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadDepositSlipData(ByVal strDCode As String)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetCashSlip")

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetAddText")

            commProc.Parameters.Clear()

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)

            db.AddInParameter(commProc2, "@D_CODE", DbType.String, strDCode)

            Dim dt As New DataTable()

            dt = db.ExecuteDataSet(commProc).Tables(0)


            Dim dt2 As New DataTable()

            dt2 = db.ExecuteDataSet(commProc2).Tables(0)
            
            If dt.Rows.Count > 0 Then

                txtDepoCode.Text = dt.Rows(0)("D_CODE").ToString()
                lblDepoScheCode.Text = dt.Rows(0)("DS_CODE").ToString()
                lblScheduleDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                lblLocationCode.Text = dt.Rows(0)("LOCATION_CODE").ToString()
                lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                lblCorrBankCode.Text = dt.Rows(0)("CORR_BANK_CODE").ToString()
                lblCorrBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                lblCorrBranchCode.Text = dt.Rows(0)("CORR_BRANCH_CODE").ToString()
                lblCorrBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                lblClientCode.Text = dt.Rows(0)("CLIENT_CODE").ToString()
                lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString() & " [" & dt.Rows(0)("ACC_NO").ToString() & "]"
                lblAmount.Text = dt.Rows(0)("CITICASH_AMOUNT").ToString()
                txtSlipDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                If dt2.Rows.Count > 0 Then
                    AddText = dt2.Rows(0)("Add_TEXT").ToString()
                End If                
            Else
                ClearFieldsAll()

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
        db.AddInParameter(commProc, "@PERSON_ID", DbType.String, _strId)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Delete
            _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

            log_message = " Deleted : Citi Cash Deposit Code : " + txtDepoCode.Text.Trim()
            Logger.system_log(log_message)

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




    Private Sub FrmCitiCashDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intModno > 0 Then
            LoadDepositSlipData(_strDCode)

            If Not txtDepoCode.Text = "" Then
                LoadDepositCashData(_strDCode, _intModno)
            End If

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

                        'LoadDepositCashData(_strDCode, _intModno)

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

                        'btnUnlock.Focus()



                    ElseIf tState = TransState.Update Then

                        'LoadDepositCashData(_strDCode, _intModno)

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

                        'btnUnlock.Focus()

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

        LoadDepositCashData(_strDCode, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try

            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadDepositCashData(_strDCode, _intModno)

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

            LoadDepositCashData(_strDCode, _intModno - 1)

        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strDCode As String = _strDCode
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadDepositCashData(_strDCode, _intModno + 1)

            If _intModno = 0 Then
                LoadDepositSlipData(strDCode)
                LoadDepositCashData(strDCode, intModno)
            End If

        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadDepositCashDataForAuth(_strDCode)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadDepositCashData(_strDCode, _intModno)

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
                ElseIf tState = TransState.ParentNotExist Then
                    lblToolStatus.Text = "!! Failed! Given deposit code does not exist in any authorize schedule record !!"
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
            'If _intModno - 1 > 0 Then

            '    LoadDepositCashData(_strDCode, _intModno - 1)

            'End If
            'lblToolStatus.Text = ""

            'If Not (txtDepoCode.Text.Trim() = "") Then
            '    LoadDepositSlipData(txtDepoCode.Text.Trim())
            'End If

            'If Not txtDepoCode.Text.Trim() = "" Then

            '    txtDepoCode.ReadOnly = True

            '    Try

            '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            '        Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetMaxMod")

            '        commProc2.Parameters.Clear()

            '        db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())

            '        Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            '        If intModNo > 0 Then

            '            LoadDepositCashData(txtDepoCode.Text.Trim(), intModNo)

            '        End If


            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End Try

            'Else
            '    MessageBox.Show("Invalid Deposit Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If


            If txtDepoCode.Text.Trim() <> "" Then
                txtCashRef.Focus()
                'SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If

        End If

        

    End Sub

    Private Sub txtSlipDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlipDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCashRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCashRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCustomerRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnSave.Enabled = True Then
                btnSave.Focus()
            Else
                SendKeys.Send("{tab}")
            End If


        End If
    End Sub

    Private Sub txtSlipDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSlipDate.Validating
        If CommonUtil.DateValidate(txtSlipDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDepoCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepoCode.Validated

        If txtDepoCode.Text.Trim() <> "" And _intModno = 0 Then

            lblToolStatus.Text = ""

            If Not (txtDepoCode.Text.Trim() = "") Then
                LoadDepositSlipData(txtDepoCode.Text.Trim())
            End If

            If Not txtDepoCode.Text.Trim() = "" Then

                txtDepoCode.ReadOnly = True

                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetMaxMod")

                    commProc2.Parameters.Clear()

                    db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())

                    Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

                    If intModNo > 0 Then

                        LoadDepositCashData(txtDepoCode.Text.Trim(), intModNo)

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Else
                MessageBox.Show("Invalid Deposit Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDepoCode.Focus()
            End If


            'If txtDepoCode.Text.Trim() <> "" Then
            '    SendKeys.Send("{tab}")
            '    SendKeys.Send("{tab}")
            'End If

        End If
    End Sub

    Private Sub lblInvoiceSubForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblInvoiceSubForm.Click
        Dim frmInvoice As New FrmInvoice()
        frmInvoice.frmNm = "FrmCitiCashDetail"
        frmInvoice.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Show(AddText)
    End Sub
End Class