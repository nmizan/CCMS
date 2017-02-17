'
' Maintain Client Information
' Author: Iftekharul Alam Khan Lodi
' Since: 22-Nov-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Text.RegularExpressions

Public Class FrmClientDet


#Region "Global Variables"

    Dim _formName As String = "MaintenanceClientDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strClient_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String
    Dim dt As New DataTable()
    Dim dt2 As New DataTable()
    Dim dt3 As New DataTable()

    'For Update
    Dim _AccName As String = ""
    Dim _CashCrDays As String = ""
    Dim _SpeedCrDays As String = ""
    Dim _cmbCashCrType As String = ""
    Dim _cmbSpeedCrType As String = ""
    Dim _GrantAcc As String = ""
    Dim _GrantOfAcc As String = ""
    Dim _WithMaxAmt As String = ""
    Dim _MailingAdd As String = ""
    Dim _Contact As String = ""
    Dim _Email As String = ""
    Dim _CashChrg As String = ""
    Dim _CashStandChrg As String = ""
    Dim _CashVat As String = ""
    Dim _SpeedChrg As String = ""
    Dim _SpeedStandChrg As String = ""
    Dim _SpeedVat As String = ""
    Dim _ReturnChrg As String = ""
    Dim _CitiAnyChrg As String = ""
    Dim _CitiAnyStandChrg As String = ""
    Dim _CitiAnyVat As String = ""
    Dim _cmbCustBilType As String = ""

    'For Authorize
    Dim _aAccName As String = ""
    Dim _aCashCrDays As String = ""
    Dim _aSpeedCrDays As String = ""
    Dim _acmbCachCrType As String = ""
    Dim _acmbSpeedCrType As String = ""
    Dim _aGrantAcc As String = ""
    Dim _aGrantOfAcc As String = ""
    Dim _aWithMaxAmt As String = ""
    Dim _aMailingAdd As String = ""
    Dim _aContact As String = ""
    Dim _aEmail As String = ""
    Dim _aCashChrg As String = ""
    Dim _aCashStandChrg As String = ""
    Dim _aCashVat As String = ""
    Dim _aSpeedChrg As String = ""
    Dim _aSpeedStandChrg As String = ""
    Dim _aSpeedVat As String = ""
    Dim _aReturnChrg As String = ""
    Dim _aCitiAnyChrg As String = ""
    Dim _aCitiAnyStandChrg As String = ""
    Dim _aCitiAnyVat As String = ""
    Dim _acmbCustBilType As String = ""

    Dim ClientList As New List(Of String)
    Dim _clientLog As String = ""
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
        

        txtClientCode.ReadOnly = True
        txtAccNo.ReadOnly = True
        txtAccName.ReadOnly = True
        chkDisable.Enabled = False
        txtCashDays.ReadOnly = True
        cmbCashType.Enabled = False
        txtSpeedDays.ReadOnly = True
        cmbSpeedType.Enabled = False
        txtMailingAdd.ReadOnly = True
        txtContact.ReadOnly = True
        txtCashCharge.ReadOnly = True
        txtCashStdCharge.ReadOnly = True
        txtCashVat.ReadOnly = True
        txtSpeedCharge.ReadOnly = True
        txtSpeedStdCharge.ReadOnly = True
        txtSpeedVat.ReadOnly = True
        txtReturnCharge.ReadOnly = True
        txtCitiAnyCharge.ReadOnly = True
        txtCityAnyStdCharge.ReadOnly = True
        txtCitiAnyVat.ReadOnly = True
        cmbBillingType.Enabled = False

        txtEmailAdd.ReadOnly = True
        txtGrantedCreditAC.ReadOnly = True
        txtGrantedCreditOFSTAC.ReadOnly = True



    End Sub

    Private Sub EnableFields()
        If txtClientCode.Text.Trim() = "" Then
            txtClientCode.ReadOnly = False
            btnSearch.Enabled = True
        Else
            txtClientCode.ReadOnly = True
            btnSearch.Enabled = False
        End If

        txtAccNo.ReadOnly = False
        txtAccName.ReadOnly = False
        chkDisable.Enabled = True
        txtCashDays.ReadOnly = False
        cmbCashType.Enabled = True
        txtSpeedDays.ReadOnly = False
        cmbSpeedType.Enabled = True
        txtMailingAdd.ReadOnly = False
        txtContact.ReadOnly = False
        txtCashCharge.ReadOnly = False
        txtCashStdCharge.ReadOnly = False
        txtCashVat.ReadOnly = False
        txtSpeedCharge.ReadOnly = False
        txtSpeedStdCharge.ReadOnly = False
        txtSpeedVat.ReadOnly = False
        txtReturnCharge.ReadOnly = False
        txtCitiAnyCharge.ReadOnly = False
        txtCityAnyStdCharge.ReadOnly = False
        txtCitiAnyVat.ReadOnly = False
        cmbBillingType.Enabled = True

        txtEmailAdd.ReadOnly = False
        txtGrantedCreditAC.ReadOnly = False
        txtGrantedCreditOFSTAC.ReadOnly = False



    End Sub


    Private Sub ClearFields()

        If txtClientCode.ReadOnly = False Then
            txtClientCode.Clear()
        End If

        txtAccNo.Clear()
        txtAccName.Clear()
        chkDisable.Checked = False
        txtCashDays.Clear()
        cmbCashType.Text = ""
        txtSpeedDays.Clear()
        cmbSpeedType.Text = ""
        txtMailingAdd.Clear()
        txtContact.Clear()
        txtCashCharge.Clear()
        txtCashStdCharge.Clear()
        txtCashVat.Clear()
        txtSpeedCharge.Clear()
        txtSpeedStdCharge.Clear()
        txtSpeedVat.Clear()
        txtReturnCharge.Clear()
        txtCitiAnyCharge.Clear()
        txtCityAnyStdCharge.Clear()
        txtCitiAnyVat.Clear()
        cmbBillingType.Text = ""


    End Sub

    Private Sub ClearFieldsAll()

        txtClientCode.Clear()
        txtAccNo.Clear()
        txtAccName.Clear()
        chkDisable.Checked = False
        txtCashDays.Clear()
        cmbCashType.Text = ""
        txtSpeedDays.Clear()
        cmbSpeedType.Text = ""
        txtMailingAdd.Clear()
        txtContact.Clear()
        txtCashCharge.Clear()
        txtCashStdCharge.Clear()
        txtCashVat.Clear()
        txtSpeedCharge.Clear()
        txtSpeedStdCharge.Clear()
        txtSpeedVat.Clear()
        txtReturnCharge.Clear()
        txtCitiAnyCharge.Clear()
        txtCityAnyStdCharge.Clear()
        txtCitiAnyVat.Clear()
        cmbBillingType.Text = ""




        _strClient_Code = ""
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

        If txtClientCode.Text.Trim() = "" Then
            MessageBox.Show("Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Return False
        ElseIf txtAccNo.Text.Trim() = "" Then
            MessageBox.Show("Acc No required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccNo.Focus()
            Return False
        ElseIf txtAccName.Text.Trim() = "" Then
            MessageBox.Show("Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccName.Focus()
            Return False
        End If


        Return True

    End Function

    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]" & _
        "*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True

        Else
            EmailAddressCheck = False

        End If
    End Function

    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
            db.AddInParameter(commProc, "@ACC_NAME", DbType.String, txtAccName.Text.Trim())
            db.AddInParameter(commProc, "@MAIL_ADD", DbType.String, txtMailingAdd.Text.Trim())
            db.AddInParameter(commProc, "@CONTACT", DbType.String, txtContact.Text.Trim())
            db.AddInParameter(commProc, "@CASH_DAYS", DbType.Int16, NullHelper.ToIntNum(txtCashDays.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_DAYS", DbType.Int16, NullHelper.ToIntNum(txtSpeedDays.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_CR_TYPE", DbType.String, cmbCashType.SelectedValue)
            db.AddInParameter(commProc, "@SPEED_CR_TYPE", DbType.String, cmbSpeedType.SelectedValue)
            db.AddInParameter(commProc, "@CASH_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCashCharge.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtSpeedCharge.Text.Trim()))
            db.AddInParameter(commProc, "@RETURN_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtReturnCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_STD_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCashStdCharge.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_STD_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtSpeedStdCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_VAT", DbType.Decimal, NullHelper.ToDecNum(txtCashVat.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_VAT", DbType.Decimal, NullHelper.ToDecNum(txtSpeedVat.Text.Trim()))
            db.AddInParameter(commProc, "@CITIANY_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCitiAnyCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CITIANY_STD_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCityAnyStdCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CITIANY_VAT", DbType.Decimal, NullHelper.ToDecNum(txtCitiAnyVat.Text.Trim()))
            db.AddInParameter(commProc, "@BILLING_TYPE", DbType.String, cmbBillingType.SelectedValue)
            db.AddInParameter(commProc, "@Direct_Debit_Customer", SqlDbType.Bit, chkDirectDebitCustomer.Checked)
            db.AddInParameter(commProc, "@IS_DISABLE", SqlDbType.Bit, chkDisable.Checked)
            db.AddInParameter(commProc, "@EMAIL", DbType.String, txtEmailAdd.Text.Trim())
            db.AddInParameter(commProc, "@GUARANTEED_CR_ACC", DbType.String, txtGrantedCreditAC.Text.Trim())
            db.AddInParameter(commProc, "@GUARANTEED_CR_OFST_ACC", DbType.String, txtGrantedCreditOFSTAC.Text.Trim())


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strClient_Code = txtClientCode.Text.Trim()

                _intModno = 1

                '------------Mizan Work (04-05-2016)------------
                log_message = " Added : Client Code : " + txtClientCode.Text.Trim() + "." + " " + " Account Number : " + txtAccNo.Text.Trim() + "." + " " + " Account Name : " + txtAccName.Text.ToString()
                Logger.system_log(log_message)
                '------------Mizan Work (04-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If
            

        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
            db.AddInParameter(commProc, "@ACC_NAME", DbType.String, txtAccName.Text.Trim())
            db.AddInParameter(commProc, "@MAIL_ADD", DbType.String, txtMailingAdd.Text.Trim())
            db.AddInParameter(commProc, "@CONTACT", DbType.String, txtContact.Text.Trim())
            db.AddInParameter(commProc, "@CASH_DAYS", DbType.Int16, NullHelper.ToIntNum(txtCashDays.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_DAYS", DbType.Int16, NullHelper.ToIntNum(txtSpeedDays.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_CR_TYPE", DbType.String, cmbCashType.SelectedValue)
            db.AddInParameter(commProc, "@SPEED_CR_TYPE", DbType.String, cmbSpeedType.SelectedValue)
            db.AddInParameter(commProc, "@CASH_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCashCharge.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtSpeedCharge.Text.Trim()))
            db.AddInParameter(commProc, "@RETURN_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtReturnCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_STD_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCashStdCharge.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_STD_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtSpeedStdCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_VAT", DbType.Decimal, NullHelper.ToDecNum(txtCashVat.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_VAT", DbType.Decimal, NullHelper.ToDecNum(txtSpeedVat.Text.Trim()))
            db.AddInParameter(commProc, "@CITIANY_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCitiAnyCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CITIANY_STD_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCityAnyStdCharge.Text.Trim()))
            db.AddInParameter(commProc, "@CITIANY_VAT", DbType.Decimal, NullHelper.ToDecNum(txtCitiAnyVat.Text.Trim()))
            db.AddInParameter(commProc, "@BILLING_TYPE", DbType.String, cmbBillingType.SelectedValue)
            db.AddInParameter(commProc, "@Direct_Debit_Customer", SqlDbType.Bit, chkDirectDebitCustomer.Checked)
            db.AddInParameter(commProc, "@IS_DISABLE", SqlDbType.Bit, chkDisable.Checked)

            db.AddInParameter(commProc, "@EMAIL", DbType.String, txtEmailAdd.Text.Trim())
            db.AddInParameter(commProc, "@GUARANTEED_CR_ACC", DbType.String, txtGrantedCreditAC.Text.Trim())
            db.AddInParameter(commProc, "@GUARANTEED_CR_OFST_ACC", DbType.String, txtGrantedCreditOFSTAC.Text.Trim())


            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
            db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)


            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Update
                _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

                '------------Mizan Work (04-05-2016)------------

                If _AccName <> txtAccName.Text.Trim() Then
                    log_message = " Account Name : " + _AccName + " " + " To " + " " + txtAccName.Text.Trim() + "." + " "
                    ClientList.Add(log_message)
                End If
                If _CashCrDays <> txtCashDays.Text.Trim() Then
                    If _CashCrDays = "" Then
                        log_message = " CitiCash Credit Days : " + txtCashDays.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiCash Credit Days : " + _CashCrDays + " " + " To " + " " + txtCashDays.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _SpeedCrDays <> txtSpeedDays.Text.Trim() Then
                    If _SpeedCrDays = "" Then
                        log_message = " CitiSpeed Credit Days : " + txtSpeedDays.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiSpeed Credit Days : " + _SpeedCrDays + " " + " To " + " " + txtSpeedDays.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _cmbCashCrType <> cmbCashType.Text Then
                    If _cmbCashCrType = "" Then
                        log_message = " Cash Credit Type : " + cmbCashType.Text + "." + " "
                    Else
                        log_message = " Cash Credit Type : " + _cmbCashCrType + " " + " To " + " " + cmbCashType.Text + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _cmbSpeedCrType <> cmbSpeedType.Text Then
                    If _cmbSpeedCrType = "" Then
                        log_message = " Speed Credit Type : " + cmbSpeedType.Text + "." + " "
                    Else
                        log_message = " Speed Credit Type : " + _cmbSpeedCrType + " " + " To " + " " + cmbSpeedType.Text + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _GrantAcc <> txtGrantedCreditAC.Text.Trim() Then
                    If _GrantAcc = "" Then
                        log_message = " Garanteed Credit A/C : " + txtGrantedCreditAC.Text.Trim() + "." + " "
                    Else
                        log_message = " Garanteed Credit A/C : " + _GrantAcc + " " + " To " + " " + txtGrantedCreditAC.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _GrantOfAcc <> txtGrantedCreditOFSTAC.Text.Trim() Then
                    If _GrantOfAcc = "" Then
                        log_message = " Garanteed OF Credit A/C : " + txtGrantedCreditOFSTAC.Text.Trim() + "." + " "
                    Else
                        log_message = " Garanteed OF Credit A/C : " + _GrantOfAcc + " " + " To " + " " + txtGrantedCreditOFSTAC.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If

                If _MailingAdd <> txtMailingAdd.Text.Trim() Then
                    If _MailingAdd = "" Then
                        log_message = " Mailing Address : " + txtMailingAdd.Text.Trim() + "." + " "
                    Else
                        log_message = " Mailing Address : " + _MailingAdd + " " + " To " + " " + txtMailingAdd.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _Contact <> txtContact.Text.Trim() Then
                    If _Contact = "" Then
                        log_message = " Contact : " + txtContact.Text.Trim() + "." + " "
                    Else
                        log_message = " Contact : " + _Contact + " " + " To " + " " + txtContact.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _Email <> txtEmailAdd.Text.Trim() Then
                    If _Email = "" Then
                        log_message = " Email Address : " + txtEmailAdd.Text.Trim() + "." + " "
                    Else
                        log_message = " Email Address : " + _Email + " " + " To " + " " + txtEmailAdd.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CashChrg <> txtCashCharge.Text.Trim() Then
                    If _CashChrg = "" Then
                        log_message = " CitiCash Charge : " + txtCashCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiCash Charge : " + _CashChrg + " " + " To " + " " + txtCashCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CashStandChrg <> txtCashStdCharge.Text.Trim() Then
                    If _CashStandChrg = "" Then
                        log_message = " CitiCash Standard Charge : " + txtCashStdCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiCash Standard Charge : " + _CashStandChrg + " " + " To " + " " + txtCashStdCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CashVat <> txtCashVat.Text.Trim() Then
                    If _CashVat = "" Then
                        log_message = " CitiCash VAT  : " + txtCashVat.Text.Trim() + "%" + "." + " "
                    Else
                        log_message = " CitiCash VAT : " + _CashVat + "%" + " " + " To " + " " + txtCashVat.Text.Trim() + "%" + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _SpeedChrg <> txtSpeedCharge.Text.Trim() Then
                    If _SpeedChrg = "" Then
                        log_message = " CitiSpeed Charge : " + txtSpeedCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiSpeed Charge : " + _SpeedChrg + " " + " To " + " " + txtSpeedCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _SpeedStandChrg <> txtSpeedStdCharge.Text.Trim() Then
                    If _SpeedStandChrg = "" Then
                        log_message = " CitiSpeed Standard Charge : " + txtSpeedStdCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiSpeed Standard Charge : " + _SpeedStandChrg + " " + " To " + " " + txtSpeedStdCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _SpeedVat <> txtSpeedVat.Text.Trim() Then
                    If _SpeedVat = "" Then
                        log_message = " CitiSpeed VAT : " + txtSpeedVat.Text.Trim() + "%" + "." + " "
                    Else
                        log_message = " CitiSpeed VAT : " + _SpeedVat + "%" + " " + " To " + " " + txtSpeedVat.Text.Trim() + "%" + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _ReturnChrg <> txtReturnCharge.Text.Trim() Then
                    If _ReturnChrg = "" Then
                        log_message = " Return Check Charges : " + txtReturnCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " Return Check Charges : " + _ReturnChrg + " " + " To " + " " + txtReturnCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CitiAnyChrg <> txtCitiAnyCharge.Text.Trim() Then
                    If _CitiAnyChrg = "" Then
                        log_message = " Citi Anywhere Charges : " + txtCitiAnyCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " Citi Anywhere Charges : " + _CitiAnyChrg + " " + " To " + " " + txtCitiAnyCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CitiAnyStandChrg <> txtCityAnyStdCharge.Text.Trim() Then
                    If _CitiAnyStandChrg = "" Then
                        log_message = " Citi Anywhere Standard Charges : " + txtCityAnyStdCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " Citi Anywhere Standard Charges : " + _CitiAnyStandChrg + " " + " To " + " " + txtCityAnyStdCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CitiAnyVat <> txtCitiAnyVat.Text.Trim() Then
                    If _CitiAnyVat = "" Then
                        log_message = " Citi Anywhere VAT : " + txtCitiAnyVat.Text.Trim() + "%" + "." + " "
                    Else
                        log_message = " Citi Anywhere VAT : " + _CitiAnyVat + "%" + " " + " To " + " " + txtCitiAnyVat.Text.Trim() + "%" + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _cmbCustBilType <> cmbBillingType.Text Then
                    If _cmbCustBilType = "" Then
                        log_message = " Customer Billing Type : " + cmbBillingType.Text + "." + " "
                    Else
                        log_message = " Customer Billing Type : " + _cmbCustBilType + " " + " To " + " " + cmbBillingType.Text + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If

                For Each clientInfo As String In ClientList
                    _clientLog += clientInfo
                Next
                _log = " Updated : Client Code : " + txtClientCode.Text.ToString() + "." + " " + " Account No : " + txtAccNo.Text.ToString() + "." + " " + _clientLog

                Logger.system_log(_log)

                _clientLog = ""
                ClientList.Clear()

                '------------Mizan Work (04-05-2016)------------


            ElseIf result = 1 Then
                tStatus = TransState.UnspecifiedError
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            End If


        End If

        Return tStatus

    End Function

    '------------Mizan Work (11-05-2016)------------

    Private Sub LoadClientDataForAuth(ByVal strClientCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLIENT Where CLIENT_CODE ='" & strClientCode & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _strClient_Code = strClientCode
               

                chkDirectDebitCustomer.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("Direct_Debit_Customer"))
                txtClientCode.Text = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                txtAccNo.Text = ds.Tables(0).Rows(0)("ACC_NO").ToString()
                txtAccName.Text = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                _aAccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                txtCashDays.Text = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                _aCashCrDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                cmbCashType.SelectedValue = ds.Tables(0).Rows(0)("CASH_CR_TYPE").ToString()
                _acmbCachCrType = ds.Tables(0).Rows(0)("CASH_CR_TYPE").ToString()
                txtSpeedDays.Text = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                _aSpeedCrDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                cmbSpeedType.SelectedValue = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                _acmbSpeedCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                txtMailingAdd.Text = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                _aMailingAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                txtContact.Text = ds.Tables(0).Rows(0)("CONTACT").ToString()
                _aContact = ds.Tables(0).Rows(0)("CONTACT").ToString()
                txtCashCharge.Text = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                _aCashChrg = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                txtCashStdCharge.Text = ds.Tables(0).Rows(0)("CASH_STD_CHARGE").ToString()
                _aCashStandChrg = ds.Tables(0).Rows(0)("CASH_STD_CHARGE").ToString()
                txtCashVat.Text = ds.Tables(0).Rows(0)("CASH_VAT").ToString()
                _aCashVat = ds.Tables(0).Rows(0)("CASH_VAT").ToString()
                txtSpeedCharge.Text = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()
                _aSpeedChrg = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()
                txtSpeedStdCharge.Text = ds.Tables(0).Rows(0)("SPEED_STD_CHARGE").ToString()
                _aSpeedStandChrg = ds.Tables(0).Rows(0)("SPEED_STD_CHARGE").ToString()
                txtSpeedVat.Text = ds.Tables(0).Rows(0)("SPEED_VAT").ToString()
                _aSpeedVat = ds.Tables(0).Rows(0)("SPEED_VAT").ToString()
                txtReturnCharge.Text = ds.Tables(0).Rows(0)("RETURN_CHARGE").ToString()
                _aReturnChrg = ds.Tables(0).Rows(0)("RETURN_CHARGE").ToString()
                txtCitiAnyCharge.Text = ds.Tables(0).Rows(0)("CITIANY_CHARGE").ToString()
                _aCitiAnyChrg = ds.Tables(0).Rows(0)("CITIANY_CHARGE").ToString()
                txtCityAnyStdCharge.Text = ds.Tables(0).Rows(0)("CITIANY_STD_CHARGE").ToString()
                _aCitiAnyStandChrg = ds.Tables(0).Rows(0)("CITIANY_STD_CHARGE").ToString()
                txtCitiAnyVat.Text = ds.Tables(0).Rows(0)("CITIANY_VAT").ToString()
                _aCitiAnyVat = ds.Tables(0).Rows(0)("CITIANY_VAT").ToString()
                cmbBillingType.SelectedValue = ds.Tables(0).Rows(0)("BILLING_TYPE").ToString()
                _acmbCustBilType = ds.Tables(0).Rows(0)("BILLING_TYPE").ToString()
                chkDisable.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("IS_DISABLE"))

                txtEmailAdd.Text = ds.Tables(0).Rows(0)("EMAIL").ToString()
                _aEmail = ds.Tables(0).Rows(0)("EMAIL").ToString()
                txtGrantedCreditAC.Text = ds.Tables(0).Rows(0)("GUARANTEED_CR_ACC").ToString()
                _aGrantAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_ACC").ToString()
                txtGrantedCreditOFSTAC.Text = ds.Tables(0).Rows(0)("GUARANTEED_CR_OFST_ACC").ToString()
                _aGrantOfAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_OFST_ACC").ToString()


                Dim row() As DataRow = dt.Select("ID = '" & _acmbCachCrType & "'")

                If row.Count > 0 Then
                    _acmbCachCrType = row(0).Item("TYPE")
                End If

                Dim rows() As DataRow = dt2.Select("ID = '" & _acmbSpeedCrType & "'")

                If rows.Count > 0 Then
                    _acmbSpeedCrType = rows(0).Item("TYPE")
                End If

                Dim bilrow() As DataRow = dt3.Select("ID = '" & _acmbCustBilType & "'")

                If bilrow.Count > 0 Then
                    _acmbCustBilType = bilrow(0).Item("TYPE")
                End If


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadClientData(ByVal strClientCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, strClientCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _strClient_Code = strClientCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                chkDirectDebitCustomer.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("Direct_Debit_Customer"))
                txtClientCode.Text = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                txtAccNo.Text = ds.Tables(0).Rows(0)("ACC_NO").ToString()
                txtAccName.Text = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                _AccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                txtCashDays.Text = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                _CashCrDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                cmbCashType.SelectedValue = ds.Tables(0).Rows(0)("CASH_CR_TYPE").ToString()
                _cmbCashCrType = ds.Tables(0).Rows(0)("CASH_CR_TYPE").ToString()
                txtSpeedDays.Text = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                _SpeedCrDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                cmbSpeedType.SelectedValue = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                _cmbSpeedCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                txtMailingAdd.Text = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                _MailingAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                txtContact.Text = ds.Tables(0).Rows(0)("CONTACT").ToString()
                _Contact = ds.Tables(0).Rows(0)("CONTACT").ToString()
                txtCashCharge.Text = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                _CashChrg = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                txtCashStdCharge.Text = ds.Tables(0).Rows(0)("CASH_STD_CHARGE").ToString()
                _CashStandChrg = ds.Tables(0).Rows(0)("CASH_STD_CHARGE").ToString()
                txtCashVat.Text = ds.Tables(0).Rows(0)("CASH_VAT").ToString()
                _CashVat = ds.Tables(0).Rows(0)("CASH_VAT").ToString()
                txtSpeedCharge.Text = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()
                _SpeedChrg = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()
                txtSpeedStdCharge.Text = ds.Tables(0).Rows(0)("SPEED_STD_CHARGE").ToString()
                _SpeedStandChrg = ds.Tables(0).Rows(0)("SPEED_STD_CHARGE").ToString()
                txtSpeedVat.Text = ds.Tables(0).Rows(0)("SPEED_VAT").ToString()
                _SpeedVat = ds.Tables(0).Rows(0)("SPEED_VAT").ToString()
                txtReturnCharge.Text = ds.Tables(0).Rows(0)("RETURN_CHARGE").ToString()
                _ReturnChrg = ds.Tables(0).Rows(0)("RETURN_CHARGE").ToString()
                txtCitiAnyCharge.Text = ds.Tables(0).Rows(0)("CITIANY_CHARGE").ToString()
                _CitiAnyChrg = ds.Tables(0).Rows(0)("CITIANY_CHARGE").ToString()
                txtCityAnyStdCharge.Text = ds.Tables(0).Rows(0)("CITIANY_STD_CHARGE").ToString()
                _CitiAnyStandChrg = ds.Tables(0).Rows(0)("CITIANY_STD_CHARGE").ToString()
                txtCitiAnyVat.Text = ds.Tables(0).Rows(0)("CITIANY_VAT").ToString()
                _CitiAnyVat = ds.Tables(0).Rows(0)("CITIANY_VAT").ToString()
                cmbBillingType.SelectedValue = ds.Tables(0).Rows(0)("BILLING_TYPE").ToString()
                _cmbCustBilType = ds.Tables(0).Rows(0)("BILLING_TYPE").ToString()
                chkDisable.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("IS_DISABLE"))

                txtEmailAdd.Text = ds.Tables(0).Rows(0)("EMAIL").ToString()
                _Email = ds.Tables(0).Rows(0)("EMAIL").ToString()
                txtGrantedCreditAC.Text = ds.Tables(0).Rows(0)("GUARANTEED_CR_ACC").ToString()
                _GrantAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_ACC").ToString()
                txtGrantedCreditOFSTAC.Text = ds.Tables(0).Rows(0)("GUARANTEED_CR_OFST_ACC").ToString()
                _GrantOfAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_OFST_ACC").ToString()

                '------------Mizan Work (07-05-2016)------------
                Dim row() As DataRow = dt.Select("ID = '" & _cmbCashCrType & "'")

                If row.Count > 0 Then
                    _cmbCashCrType = row(0).Item("TYPE")
                End If

                Dim rows() As DataRow = dt2.Select("ID = '" & _cmbSpeedCrType & "'")

                If rows.Count > 0 Then
                    _cmbSpeedCrType = rows(0).Item("TYPE")
                End If

                Dim bilrow() As DataRow = dt3.Select("ID = '" & _cmbCustBilType & "'")

                If bilrow.Count > 0 Then
                    _cmbCustBilType = bilrow(0).Item("TYPE")
                End If
                '------------Mizan Work (07-05-2016)------------

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Client_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@CLIENT_CODE", DbType.String, strClientCode)

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
                End If


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strClientCode As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'LoadClientData(strClientCode, intMod)

        _strClient_Code = strClientCode
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '--------------------Mizan Work (11-05-2016)--------------------
            If _intModno > 1 Then

                If _aAccName <> _AccName Then
                    log_message = " Account Name : " + _aAccName + " " + " To " + " " + _AccName + "." + " "
                    ClientList.Add(log_message)
                End If
                If _aCashCrDays <> _CashCrDays Then
                    If _aCashCrDays = "" Then
                        log_message = " CitiCash Credit Days : " + _CashCrDays + "." + " "
                    Else
                        log_message = " CitiCash Credit Days : " + _aCashCrDays + " " + " To " + " " + _CashCrDays + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aSpeedCrDays <> _SpeedCrDays Then
                    If _aSpeedCrDays = "" Then
                        log_message = " CitiSpeed Credit Days : " + _SpeedCrDays + "." + " "
                    Else
                        log_message = " CitiSpeed Credit Days : " + _aSpeedCrDays + " " + " To " + " " + _SpeedCrDays + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _acmbCachCrType <> _cmbCashCrType Then
                    If _acmbCachCrType = "" Then
                        log_message = " Cash Credit Type : " + _cmbCashCrType + "." + " "
                    Else
                        log_message = " Cash Credit Type : " + _acmbCachCrType + " " + " To " + " " + _cmbCashCrType + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _acmbSpeedCrType <> _cmbSpeedCrType Then
                    If _acmbSpeedCrType = "" Then
                        log_message = " Speed Credit Type : " + _cmbSpeedCrType + "." + " "
                    Else
                        log_message = " Speed Credit Type : " + _acmbSpeedCrType + " " + " To " + " " + _cmbSpeedCrType + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aGrantAcc <> _GrantAcc Then
                    If _aGrantAcc = "" Then
                        log_message = " Garanteed Credit A/C : " + _GrantAcc + "." + " "
                    Else
                        log_message = " Garanteed Credit A/C : " + _aGrantAcc + " " + " To " + " " + _GrantAcc + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aGrantOfAcc <> _GrantOfAcc Then
                    If _aGrantOfAcc = "" Then
                        log_message = " Garanteed OF Credit A/C : " + _GrantOfAcc + "." + " "
                    Else
                        log_message = " Garanteed OF Credit A/C : " + _aGrantOfAcc + " " + " To " + " " + _GrantOfAcc + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If

                If _aMailingAdd <> _MailingAdd Then
                    If _aMailingAdd = "" Then
                        log_message = " Mailing Address : " + _MailingAdd + "." + " "
                    Else
                        log_message = " Mailing Address : " + _aMailingAdd + " " + " To " + " " + _MailingAdd + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aContact <> _Contact Then
                    If _aContact = "" Then
                        log_message = " Contact : " + _Contact + "." + " "
                    Else
                        log_message = " Contact : " + _aContact + " " + " To " + " " + _Contact + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aEmail <> _Email Then
                    If _aEmail = "" Then
                        log_message = " Email Address : " + _Email + "." + " "
                    Else
                        log_message = " Email Address : " + _aEmail + " " + " To " + " " + _Email + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCashChrg <> _CashChrg Then
                    If _aCashChrg = "" Then
                        log_message = " CitiCash Charge : " + _CashChrg + "." + " "
                    Else
                        log_message = " CitiCash Charge : " + _aCashChrg + " " + " To " + " " + _CashChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCashStandChrg <> _CashStandChrg Then
                    If _aCashStandChrg = "" Then
                        log_message = " CitiCash Standard Charge : " + _CashStandChrg + "." + " "
                    Else
                        log_message = " CitiCash Standard Charge : " + _aCashStandChrg + " " + " To " + " " + _CashStandChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCashVat <> _CashVat Then
                    If _aCashVat = "" Then
                        log_message = " CitiCash VAT  : " + _CashVat + "%" + "." + " "
                    Else
                        log_message = " CitiCash VAT : " + _aCashVat + "%" + " " + " To " + " " + _CashVat + "%" + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aSpeedChrg <> _SpeedChrg Then
                    If _aSpeedChrg = "" Then
                        log_message = " CitiSpeed Charge : " + _SpeedChrg + "." + " "
                    Else
                        log_message = " CitiSpeed Charge : " + _aSpeedChrg + " " + " To " + " " + _SpeedChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aSpeedStandChrg <> _SpeedStandChrg Then
                    If _aSpeedStandChrg = "" Then
                        log_message = " CitiSpeed Standard Charge : " + _SpeedStandChrg + "." + " "
                    Else
                        log_message = " CitiSpeed Standard Charge : " + _aSpeedStandChrg + " " + " To " + " " + _SpeedStandChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aSpeedVat <> _SpeedVat Then
                    If _aSpeedVat = "" Then
                        log_message = " CitiSpeed VAT : " + _SpeedVat + "%" + "." + " "
                    Else
                        log_message = " CitiSpeed VAT : " + _aSpeedVat + "%" + " " + " To " + " " + _SpeedVat + "%" + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aReturnChrg <> _ReturnChrg Then
                    If _aReturnChrg = "" Then
                        log_message = " Return Check Charges : " + _ReturnChrg + "." + " "
                    Else
                        log_message = " Return Check Charges : " + _aReturnChrg + " " + " To " + " " + _ReturnChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCitiAnyChrg <> _CitiAnyChrg Then
                    If _aCitiAnyChrg = "" Then
                        log_message = " Citi Anywhere Charges : " + _CitiAnyChrg + "." + " "
                    Else
                        log_message = " Citi Anywhere Charges : " + _aCitiAnyChrg + " " + " To " + " " + _CitiAnyChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCitiAnyStandChrg <> _CitiAnyStandChrg Then
                    If _aCitiAnyStandChrg = "" Then
                        log_message = " Citi Anywhere Standard Charges : " + _CitiAnyStandChrg + "." + " "
                    Else
                        log_message = " Citi Anywhere Standard Charges : " + _aCitiAnyStandChrg + " " + " To " + " " + _CitiAnyStandChrg + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCitiAnyVat <> _CitiAnyVat Then
                    If _aCitiAnyVat = "" Then
                        log_message = " Citi Anywhere VAT : " + _CitiAnyVat + "%" + "." + " "
                    Else
                        log_message = " Citi Anywhere VAT : " + _aCitiAnyVat + "%" + " " + " To " + " " + _CitiAnyVat + "%" + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _acmbCustBilType <> _cmbCustBilType Then
                    If _acmbCustBilType = "" Then
                        log_message = " Customer Billing Type : " + _cmbCustBilType + "." + " "
                    Else
                        log_message = " Customer Billing Type : " + _acmbCustBilType + " " + " To " + " " + _cmbCustBilType + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If

                For Each clientInfo As String In ClientList
                    _clientLog += clientInfo
                Next
                _log = " Authorized : Client Code : " + txtClientCode.Text.ToString() + "." + " " + " Account No : " + txtAccNo.Text.ToString() + "." + " " + _clientLog

                Logger.system_log(_log)

                _clientLog = ""
                ClientList.Clear()

            Else

                If _aAccName <> _AccName Then
                    If _aAccName = "" Then
                        log_message = " Account Name : " + _AccName + "." + " "
                    Else
                        log_message = " Account Name : " + _aAccName + " " + " To " + " " + _AccName + "." + " "
                    End If

                    ClientList.Add(log_message)
                End If
                If _aCashCrDays <> _CashCrDays Then
                    If _aCashCrDays = "" Then
                        'log_message = " CitiCash Credit Days : " + _CashCrDays + "." + " "
                    Else
                        log_message = " CitiCash Credit Days : " + _aCashCrDays + " " + " To " + " " + _CashCrDays + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aSpeedCrDays <> _SpeedCrDays Then
                    If _aSpeedCrDays = "" Then
                        'log_message = " CitiSpeed Credit Days : " + _SpeedCrDays + "." + " "
                    Else
                        log_message = " CitiSpeed Credit Days : " + _aSpeedCrDays + " " + " To " + " " + _SpeedCrDays + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _acmbCachCrType <> _cmbCashCrType Then
                    If _acmbCachCrType = "" Then
                        'log_message = " Cash Credit Type : " + _cmbCashCrType + "." + " "
                    Else
                        log_message = " Cash Credit Type : " + _acmbCachCrType + " " + " To " + " " + _cmbCashCrType + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _acmbSpeedCrType <> _cmbSpeedCrType Then
                    If _acmbSpeedCrType = "" Then
                        ' log_message = " Speed Credit Type : " + _cmbSpeedCrType + "." + " "
                    Else
                        log_message = " Speed Credit Type : " + _acmbSpeedCrType + " " + " To " + " " + _cmbSpeedCrType + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aGrantAcc <> _GrantAcc Then
                    If _aGrantAcc = "" Then
                        'log_message = " Garanteed Credit A/C : " + _GrantAcc + "." + " "
                    Else
                        log_message = " Garanteed Credit A/C : " + _aGrantAcc + " " + " To " + " " + _GrantAcc + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aGrantOfAcc <> _GrantOfAcc Then
                    If _aGrantOfAcc = "" Then
                        'log_message = " Garanteed OF Credit A/C : " + _GrantOfAcc + "." + " "
                    Else
                        log_message = " Garanteed OF Credit A/C : " + _aGrantOfAcc + " " + " To " + " " + _GrantOfAcc + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If

                If _aMailingAdd <> _MailingAdd Then
                    If _aMailingAdd = "" Then
                        'log_message = " Mailing Address : " + _MailingAdd + "." + " "
                    Else
                        log_message = " Mailing Address : " + _aMailingAdd + " " + " To " + " " + _MailingAdd + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aContact <> _Contact Then
                    If _aContact = "" Then
                        'log_message = " Contact : " + _Contact + "." + " "
                    Else
                        log_message = " Contact : " + _aContact + " " + " To " + " " + _Contact + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aEmail <> _Email Then
                    If _aEmail = "" Then
                        'log_message = " Email Address : " + _Email + "." + " "
                    Else
                        log_message = " Email Address : " + _aEmail + " " + " To " + " " + _Email + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aCashChrg <> _CashChrg Then
                    If _aCashChrg = "" Then
                        'log_message = " CitiCash Charge : " + _CashChrg + "." + " "
                    Else
                        log_message = " CitiCash Charge : " + _aCashChrg + " " + " To " + " " + _CashChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aCashStandChrg <> _CashStandChrg Then
                    If _aCashStandChrg = "" Then
                        'log_message = " CitiCash Standard Charge : " + _CashStandChrg + "." + " "
                    Else
                        log_message = " CitiCash Standard Charge : " + _aCashStandChrg + " " + " To " + " " + _CashStandChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aCashVat <> _CashVat Then
                    If _aCashVat = "" Then
                        'log_message = " CitiCash VAT  : " + _CashVat + "%" + "." + " "
                    Else
                        log_message = " CitiCash VAT : " + _aCashVat + "%" + " " + " To " + " " + _CashVat + "%" + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aSpeedChrg <> _SpeedChrg Then
                    If _aSpeedChrg = "" Then
                        'log_message = " CitiSpeed Charge : " + _SpeedChrg + "." + " "
                    Else
                        log_message = " CitiSpeed Charge : " + _aSpeedChrg + " " + " To " + " " + _SpeedChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aSpeedStandChrg <> _SpeedStandChrg Then
                    If _aSpeedStandChrg = "" Then
                        'log_message = " CitiSpeed Standard Charge : " + _SpeedStandChrg + "." + " "
                    Else
                        log_message = " CitiSpeed Standard Charge : " + _aSpeedStandChrg + " " + " To " + " " + _SpeedStandChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aSpeedVat <> _SpeedVat Then
                    If _aSpeedVat = "" Then
                        'log_message = " CitiSpeed VAT : " + _SpeedVat + "%" + "." + " "
                    Else
                        log_message = " CitiSpeed VAT : " + _aSpeedVat + "%" + " " + " To " + " " + _SpeedVat + "%" + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aReturnChrg <> _ReturnChrg Then
                    If _aReturnChrg = "" Then
                        'log_message = " Return Check Charges : " + _ReturnChrg + "." + " "
                    Else
                        log_message = " Return Check Charges : " + _aReturnChrg + " " + " To " + " " + _ReturnChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aCitiAnyChrg <> _CitiAnyChrg Then
                    If _aCitiAnyChrg = "" Then
                        'log_message = " Citi Anywhere Charges : " + _CitiAnyChrg + "." + " "
                    Else
                        log_message = " Citi Anywhere Charges : " + _aCitiAnyChrg + " " + " To " + " " + _CitiAnyChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aCitiAnyStandChrg <> _CitiAnyStandChrg Then
                    If _aCitiAnyStandChrg = "" Then
                        'log_message = " Citi Anywhere Standard Charges : " + _CitiAnyStandChrg + "." + " "
                    Else
                        log_message = " Citi Anywhere Standard Charges : " + _aCitiAnyStandChrg + " " + " To " + " " + _CitiAnyStandChrg + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _aCitiAnyVat <> _CitiAnyVat Then
                    If _aCitiAnyVat = "" Then
                        'log_message = " Citi Anywhere VAT : " + _CitiAnyVat + "%" + "." + " "
                    Else
                        log_message = " Citi Anywhere VAT : " + _aCitiAnyVat + "%" + " " + " To " + " " + _CitiAnyVat + "%" + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If
                If _acmbCustBilType <> _cmbCustBilType Then
                    If _acmbCustBilType = "" Then
                        'log_message = " Customer Billing Type : " + _cmbCustBilType + "." + " "
                    Else
                        log_message = " Customer Billing Type : " + _acmbCustBilType + " " + " To " + " " + _cmbCustBilType + "." + " "
                        ClientList.Add(log_message)
                    End If

                End If

                For Each clientInfo As String In ClientList
                    _clientLog += clientInfo
                Next
                _log = " Authorized : Client Code : " + txtClientCode.Text.ToString() + "." + " " + " Account No : " + txtAccNo.Text.ToString() + "." + " " + _clientLog

                Logger.system_log(_log)

                _clientLog = ""
                ClientList.Clear()

            End If

            '--------------------Mizan Work (11-05-2016)--------------------

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


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
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

    Private Sub LoadClientInfo(ByVal strClientCode)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Client_GetMaxMod")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@CLIENT_CODE", DbType.String, strClientCode)

            Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            If intModNo > 0 Then
                LoadClientData(strClientCode, intModNo)

            Else
                ClearFieldsAll()

            End If


            

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadComboValues()
        'Dim dt As New DataTable()

        dt.Columns.Add("ID")
        dt.Columns.Add("TYPE")
        Dim dr As DataRow = dt.NewRow()

        dr(0) = "L"
        dr(1) = "Type L"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "T"
        dr(1) = "Type T"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "D"
        dr(1) = "Type D"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "R"
        dr(1) = "Type R"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "RD"
        dr(1) = "Type RD"
        dt.Rows.Add(dr)

        'dr = dt.NewRow()
        'dr(0) = "RC"
        'dr(1) = "Type RC"
        'dt.Rows.Add(dr)

        cmbCashType.DataSource = dt
        cmbCashType.DisplayMember = "TYPE"
        cmbCashType.ValueMember = "ID"
        ''''''''''''''''''''''''''''''''''''''''''''
        'Dim dt2 As New DataTable()

        dt2.Columns.Add("ID")
        dt2.Columns.Add("TYPE")
        Dim dr2 As DataRow = dt2.NewRow()

        dr2(0) = "L"
        dr2(1) = "Type L"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "R"
        dr2(1) = "Type R"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "C"
        dr2(1) = "Type C"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "T"
        dr2(1) = "Type T"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "D"
        dr2(1) = "Type D"
        dt2.Rows.Add(dr2)


        dr2 = dt2.NewRow()
        dr2(0) = "RD"
        dr2(1) = "Type RD"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "RC"
        dr2(1) = "Type RC"
        dt2.Rows.Add(dr2)

        cmbSpeedType.DataSource = dt2
        cmbSpeedType.DisplayMember = "TYPE"
        cmbSpeedType.ValueMember = "ID"

        ''''''''''''''''''''''''''''''''''''''''''''
        'Dim dt3 As New DataTable()

        dt3.Columns.Add("ID")
        dt3.Columns.Add("TYPE")
        Dim dr3 As DataRow = dt3.NewRow()

        dr3(0) = "1"
        dr3(1) = "Type 1"
        dt3.Rows.Add(dr3)

        dr3 = dt3.NewRow()
        dr3(0) = "2"
        dr3(1) = "Type 2"
        dt3.Rows.Add(dr3)

        dr3 = dt3.NewRow()
        dr3(0) = "3"
        dr3(1) = "Type 3"
        dt3.Rows.Add(dr3)

        dr3 = dt3.NewRow()
        dr3(0) = "4"
        dr3(1) = "Type 4"
        dt3.Rows.Add(dr3)

        'dr3 = dt3.NewRow()
        'dr3(0) = "5"
        'dr3(1) = "Type 5"
        'dt3.Rows.Add(dr3)

        cmbBillingType.DataSource = dt3
        cmbBillingType.DisplayMember = "TYPE"
        cmbBillingType.ValueMember = "ID"

    End Sub

#End Region



    Private Sub FrmClientDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        LoadComboValues()

        
        If _intModno > 0 Then
            LoadClientData(_strClient_Code, _intModno)
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
        EnableNew()



        If Not (_strClient_Code.Trim() = "") Then

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

        If txtClientCode.ReadOnly = False Then
            txtClientCode.Focus()
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

                        LoadClientData(_strClient_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadClientData(_strClient_Code, _intModno)

                        lblToolStatus.Text = "!! Information Updated Successfully !!"



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
        LoadClientData(_strClient_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadClientData(_strClient_Code, _intModno)

                    DisableAuth()

                    If _strClient_Code = "" Then

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
            LoadClientData(_strClient_Code, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strClientCode As String = _strClient_Code
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadClientData(_strClient_Code, _intModno + 1)

            If _intModno = 0 Then
                LoadClientData(strClientCode, intModno)
            End If
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadClientDataForAuth(_strClient_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadClientData(_strClient_Code, _intModno)
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not (txtClientCode.Text.Trim() = "") Then
            LoadClientInfo(txtClientCode.Text.Trim())
        End If
    End Sub

    Private Sub btnLocationCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocationCharge.Click
        If (_intModno = 1 And chkAuthorized.Checked = True) Or _intModno > 1 Then
            Dim frmLocChargeSum As New FrmClientLocChargeSumm(_strClient_Code)
            frmLocChargeSum.Show()
        Else
            MessageBox.Show("Client should have atleast one authorize record to proceed", "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub txtClientCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not (txtClientCode.Text.Trim() = "") Then
                LoadClientInfo(txtClientCode.Text.Trim())
            End If
        End If
    End Sub

    Private Sub txtEmailAdd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailAdd.Validating

        Dim email As String = txtEmailAdd.Text
        If txtEmailAdd.Text.Trim() <> "" And EmailAddressCheck(email) = False Then

            Dim result As DialogResult _
            = MessageBox.Show("The email address is not valid." _
                                       , "Invalid Email Address", _
                                       MessageBoxButtons.OK, MessageBoxIcon.Error)

            e.Cancel = True

        End If

    End Sub
End Class