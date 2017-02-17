'
' Maintain Client Information
' Author: Iftekharul Alam Khan Lodi
' Since: 31-Mar-13
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClearingClientDet


#Region "Global Variables"

    Dim _formName As String = "MaintenanceClearingClientDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strAcc_No As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False
    Dim dt2 As New DataTable()
    Dim dt3 As New DataTable()

    Dim log_message As String

    'For Update
    Dim _AccName As String = ""
    Dim _cmbSpCrType As String = ""
    Dim _MailAdd As String = ""
    Dim _Contact As String = ""

    Dim _cmbValuTypeName(1000) As String
    Dim _minAmt(1000) As String
    Dim _maxAmt(1000) As String
    Dim _bbkAmt(1000) As String
    Dim _clientDrAmt(1000) As String
    Dim _citiInc(1000) As String
    Dim _citiVat(1000) As String
    Dim _citiexp(1000) As String
    
    'For Auth
    Dim _aAccName As String = ""
    Dim _acmbSpCrType As String = ""
    Dim _aMailAdd As String = ""
    Dim _aContact As String = ""

    Dim _acmbValuTypeName(1000) As String
    Dim _aminAmt(1000) As String
    Dim _amaxAmt(1000) As String
    Dim _abbkAmt(1000) As String
    Dim _aclientDrAmt(1000) As String
    Dim _acitiInc(1000) As String
    Dim _acitiVat(1000) As String
    Dim _acitiexp(1000) As String

    Dim ClearClientList As New List(Of String)
    Dim _ClrClientLog As String = ""
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

        txtAccNo.ReadOnly = True
        txtAccName.ReadOnly = True
        chkDisable.Enabled = False

        cmbSpeedType.Enabled = False
        chkGovtAcc.Enabled = False
        chkInsuffecientFund.Enabled = False

        txtMailingAdd.ReadOnly = True
        txtContact.ReadOnly = True

        cmbValueType.Enabled = False
        txtMinAmount.ReadOnly = True
        txtMaxAmount.ReadOnly = True
        txtBBKCharge.ReadOnly = True
        txtCitiIncomeAmt.ReadOnly = True
        txtCitiVATAmt.ReadOnly = True
        txtClientDrAmt.ReadOnly = True
        txtTotalChargeable.ReadOnly = True

        btnAddToGrid.Enabled = False
        btnRemoveFromGrid.Enabled = False
        dgView.Enabled = False




    End Sub

    Private Sub EnableFields()
        If txtAccNo.Text.Trim() = "" Then
            txtAccNo.ReadOnly = False

        Else
            txtAccNo.ReadOnly = True

        End If

        txtAccName.ReadOnly = False
        chkDisable.Enabled = True

        cmbSpeedType.Enabled = True
        chkGovtAcc.Enabled = True
        chkInsuffecientFund.Enabled = True

        txtMailingAdd.ReadOnly = False
        txtContact.ReadOnly = False

        cmbValueType.Enabled = True
        txtMinAmount.ReadOnly = False
        txtMaxAmount.ReadOnly = False
        txtBBKCharge.ReadOnly = False
        txtCitiIncomeAmt.ReadOnly = False
        txtCitiVATAmt.ReadOnly = False
        txtClientDrAmt.ReadOnly = False
        txtTotalChargeable.ReadOnly = False

        btnAddToGrid.Enabled = True
        btnRemoveFromGrid.Enabled = True
        dgView.Enabled = True



    End Sub


    Private Sub ClearFields()

        If txtAccNo.ReadOnly = False Then
            txtAccNo.Clear()
        End If

        txtAccName.Clear()
        chkDisable.Checked = False

        cmbSpeedType.Text = ""
        chkGovtAcc.Checked = False
        chkInsuffecientFund.Checked = False

        txtMailingAdd.Clear()
        txtContact.Clear()

        cmbValueType.SelectedIndex = -1
        txtMinAmount.Clear()
        txtMaxAmount.Clear()
        txtBBKCharge.Clear()
        txtCitiIncomeAmt.Clear()
        txtCitiVATAmt.Clear()
        txtClientDrAmt.Clear()
        txtTotalChargeable.Clear()

        txtCitiExpenseAmt.Clear()


    End Sub

    Private Sub ClearFieldsAll()


        txtAccNo.Clear()
        txtAccName.Clear()
        chkDisable.Checked = False

        cmbSpeedType.SelectedIndex = -1
        chkGovtAcc.Checked = False
        chkInsuffecientFund.Checked = False

        txtMailingAdd.Clear()
        txtContact.Clear()

        cmbValueType.SelectedIndex = -1
        txtMinAmount.Clear()
        txtMaxAmount.Clear()
        txtBBKCharge.Clear()
        txtCitiIncomeAmt.Clear()
        txtCitiVATAmt.Clear()
        txtClientDrAmt.Clear()
        txtTotalChargeable.Clear()

        txtCitiExpenseAmt.Clear()

        dgView.AllowUserToAddRows = False

        dgView.DataSource = Nothing
        dgView.Rows.Clear()


        _strAcc_No = ""
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

        If txtAccNo.Text.Trim() = "" Then
            MessageBox.Show("Acc No required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccNo.Focus()
            Return False
        ElseIf txtAccName.Text.Trim() = "" Then
            MessageBox.Show("Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccName.Focus()
            Return False
        ElseIf cmbSpeedType.SelectedIndex = -1 Then
            MessageBox.Show("Type required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbSpeedType.Focus()
            Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim i As Integer = 0

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
                db.AddInParameter(commProc, "@ACC_NAME", DbType.String, txtAccName.Text.Trim())
                db.AddInParameter(commProc, "@MAIL_ADD", DbType.String, txtMailingAdd.Text.Trim())
                db.AddInParameter(commProc, "@CONTACT", DbType.String, txtContact.Text.Trim())
                db.AddInParameter(commProc, "@SPEED_CR_TYPE", DbType.String, cmbSpeedType.SelectedValue)
                db.AddInParameter(commProc, "@Direct_Debit_Customer", SqlDbType.Bit, chkDirectDebitCustomer.Checked)
                db.AddInParameter(commProc, "@IS_DISABLE", SqlDbType.Bit, chkDisable.Checked)
                db.AddInParameter(commProc, "@IS_GOV", SqlDbType.Bit, chkGovtAcc.Checked)
                db.AddInParameter(commProc, "@INSUFF_FUND", SqlDbType.Bit, chkInsuffecientFund.Checked)


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

                    Dim commProcCharge As DbCommand = db.GetStoredProcCommand("CMS_ClearingClientCharge_Add")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcCharge.Parameters.Clear()

                        db.AddInParameter(commProcCharge, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
                        db.AddInParameter(commProcCharge, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcCharge, "@VALUE_TYPE", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcCharge, "@MIN_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(3).Value))
                        db.AddInParameter(commProcCharge, "@MAX_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(4).Value))
                        db.AddInParameter(commProcCharge, "@BBK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(5).Value))
                        db.AddInParameter(commProcCharge, "@CITI_INC_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(6).Value))
                        db.AddInParameter(commProcCharge, "@CITI_VAT_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(7).Value))
                        db.AddInParameter(commProcCharge, "@CLIENT_DR_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(8).Value))
                        db.AddInParameter(commProcCharge, "@CHARGEABLE_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(9).Value))

                        db.AddParameter(commProcCharge, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcCharge, trans)

                        If db.GetParameterValue(commProcCharge, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If

                    Next

                    tStatus = TransState.Add
                    _strAcc_No = txtAccNo.Text.Trim()
                    _intModno = 1

                    '------------Mizan Work (07-05-2016)------------

                    log_message = " Added : Account No : " + txtAccNo.Text.Trim() + "." + " " + " Account Name : " + txtAccName.Text.Trim()
                    Logger.system_log(log_message)

                    '------------Mizan Work (07-05-2016)------------

                End If

                trans.Commit()

               

            End Using

        ElseIf _formMode = FormTransMode.Update Then

            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@ACC_NO", DbType.String, _strAcc_No)
                db.AddInParameter(commProc, "@ACC_NAME", DbType.String, txtAccName.Text.Trim())
                db.AddInParameter(commProc, "@MAIL_ADD", DbType.String, txtMailingAdd.Text.Trim())
                db.AddInParameter(commProc, "@CONTACT", DbType.String, txtContact.Text.Trim())
                db.AddInParameter(commProc, "@SPEED_CR_TYPE", DbType.String, cmbSpeedType.SelectedValue)
                db.AddInParameter(commProc, "@Direct_Debit_Customer", SqlDbType.Bit, chkDirectDebitCustomer.Checked)
                db.AddInParameter(commProc, "@IS_DISABLE", SqlDbType.Bit, chkDisable.Checked)
                db.AddInParameter(commProc, "@IS_GOV", SqlDbType.Bit, chkGovtAcc.Checked)
                db.AddInParameter(commProc, "@INSUFF_FUND", SqlDbType.Bit, chkInsuffecientFund.Checked)

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

                    Dim commProcCharge As DbCommand = db.GetStoredProcCommand("CMS_ClearingClientCharge_Update")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcCharge.Parameters.Clear()

                        db.AddInParameter(commProcCharge, "@ACC_NO", DbType.String, _strAcc_No)
                        db.AddInParameter(commProcCharge, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcCharge, "@VALUE_TYPE", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcCharge, "@MIN_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(3).Value))
                        db.AddInParameter(commProcCharge, "@MAX_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(4).Value))
                        db.AddInParameter(commProcCharge, "@BBK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(5).Value))
                        db.AddInParameter(commProcCharge, "@CITI_INC_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(6).Value))
                        db.AddInParameter(commProcCharge, "@CITI_VAT_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(7).Value))
                        db.AddInParameter(commProcCharge, "@CLIENT_DR_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(8).Value))
                        db.AddInParameter(commProcCharge, "@CHARGEABLE_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(9).Value))
                        db.AddInParameter(commProcCharge, "@MOD_NO", DbType.Int32, intModno)

                        db.AddParameter(commProcCharge, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcCharge, trans)

                        If db.GetParameterValue(commProcCharge, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Update
                    _intModno = intModno

                    trans.Commit()

                    '------------Mizan Work (07-05-2016)------------

                    If _AccName <> txtAccName.Text.Trim() Then
                        log_message = " Account Name : " + _AccName + " " + " To " + " " + txtAccName.Text.Trim() + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _cmbSpCrType <> cmbSpeedType.Text Then
                        log_message = " Speed Credit Type : " + _cmbSpCrType + " " + " To " + " " + cmbSpeedType.Text + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _MailAdd <> txtMailingAdd.Text.Trim() Then
                        If _MailAdd = "" Then
                            log_message = " Mailing Address : " + txtMailingAdd.Text.Trim() + "." + " "
                        Else
                            log_message = " Mailing Address  : " + _MailAdd + " " + " To " + " " + txtMailingAdd.Text.Trim() + "." + " "
                        End If
                        ClearClientList.Add(log_message)
                    End If
                    If _Contact <> txtContact.Text.Trim() Then
                        If _Contact = "" Then
                            log_message = " Contact : " + txtContact.Text.Trim() + "." + " "
                        Else
                            log_message = " Contact : " + _Contact + " " + " To " + " " + txtContact.Text.Trim() + "." + " "
                        End If
                        ClearClientList.Add(log_message)
                    End If

                    'For Gridview Data

                    For i = 0 To dgView.Rows.Count - 1

                        If _cmbValuTypeName(i) <> dgView.Item(2, i).Value Then
                            log_message = " Value Type : " + _cmbValuTypeName(i) + " " + " To " + " " + dgView.Item(2, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If

                        If _minAmt(i) <> dgView.Item(3, i).Value Then
                            log_message = " Minimum Amount : " + _minAmt(i) + " " + " To " + " " + dgView.Item(3, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If
                        If _maxAmt(i) <> dgView.Item(4, i).Value Then
                            log_message = " Maximum  Amount : " + _maxAmt(i) + " " + " To " + " " + dgView.Item(4, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If
                        If _bbkAmt(i) <> dgView.Item(5, i).Value Then
                            log_message = " BBK Amount : " + _bbkAmt(i) + " " + " To " + " " + dgView.Item(5, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If
                        If _citiInc(i) <> dgView.Item(6, i).Value Then
                            log_message = " Citi Income Amount : " + _citiInc(i) + " " + " To " + " " + dgView.Item(6, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If
                        If _citiVat(i) <> dgView.Item(7, i).Value Then
                            log_message = " Citi Vat Amount : " + _citiVat(i) + " " + " To " + " " + dgView.Item(7, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If
                        If _clientDrAmt(i) <> dgView.Item(8, i).Value Then
                            log_message = " Client Dr Amount : " + _clientDrAmt(i) + " " + " To " + " " + dgView.Item(8, i).Value.ToString + "." + " "
                            ClearClientList.Add(log_message)
                        End If
                    Next

                    '-----------------
                    
                    For Each clrclientInfo As String In ClearClientList
                        _ClrClientLog += clrclientInfo
                    Next
                    _log = " Updated : Account No : " + txtAccNo.Text.ToString() + "." + " " + _ClrClientLog

                    Logger.system_log(_log)

                    _ClrClientLog = ""
                    ClearClientList.Clear()

                    '------------Mizan Work (07-05-2016)------------

                    Return tStatus

                End If

                trans.Rollback()

            End Using



        End If

        Return tStatus

    End Function

    '------------Mizan Work (12-05-2016)------------

    Private Sub LoadClientDataForAuth(ByVal strAccNo As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLEARING_CLIENT Where  ACC_NO ='" & strAccNo & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _strAcc_No = strAccNo
                
                txtAccName.Text = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                _aAccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                cmbSpeedType.SelectedValue = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                _acmbSpCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
               
                txtMailingAdd.Text = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                _aMailAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                txtContact.Text = ds.Tables(0).Rows(0)("CONTACT").ToString()
                _aContact = ds.Tables(0).Rows(0)("CONTACT").ToString()


                Dim row() As DataRow = dt2.Select("ID = '" & _acmbSpCrType & "'")

                If row.Count > 0 Then
                    _acmbSpCrType = row(0).Item("TYPE")
                End If

               
            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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


                _strAcc_No = strAccNo
                _intModno = intMod

                _formMode = FormTransMode.Update
                chkDirectDebitCustomer.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("Direct_Debit_Customer"))
                txtAccNo.Text = ds.Tables(0).Rows(0)("ACC_NO").ToString()
                txtAccName.Text = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                _AccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                chkDisable.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("IS_DISABLE"))

                cmbSpeedType.SelectedValue = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                _cmbSpCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()
                chkGovtAcc.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("IS_GOV"))
                chkInsuffecientFund.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("INSUFF_FUND"))

                txtMailingAdd.Text = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                _MailAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()
                txtContact.Text = ds.Tables(0).Rows(0)("CONTACT").ToString()
                _Contact = ds.Tables(0).Rows(0)("CONTACT").ToString()

                '------------Mizan Work (07-05-2016)------------
                Dim row() As DataRow = dt2.Select("ID = '" & _cmbSpCrType & "'")

                If row.Count > 0 Then
                    _cmbSpCrType = row(0).Item("TYPE")
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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@ACC_NO", DbType.String, strAccNo)

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

    '------------Mizan Work (12-05-2016)------------

    Private Sub LoadClientChargeDataForAuth(ByVal strAccNo As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable


            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CLEARING_CLIENT_CHARGE Where  ACC_NO ='" & strAccNo & "' and STATUS='L'").Tables(0)

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(1, i).Value = dt.Rows(i)("VALUE_TYPE")
                    dgView.Item(2, i).Value = GetValueTypeName(NullHelper.ToIntNum(dt.Rows(i)("VALUE_TYPE")))
                    _acmbValuTypeName(i) = GetValueTypeName(NullHelper.ToIntNum(dt.Rows(i)("VALUE_TYPE")))
                    dgView.Item(3, i).Value = dt.Rows(i)("MIN_AMOUNT")
                    _aminAmt(i) = dt.Rows(i)("MIN_AMOUNT")
                    dgView.Item(4, i).Value = dt.Rows(i)("MAX_AMOUNT")
                    _amaxAmt(i) = dt.Rows(i)("MAX_AMOUNT")
                    dgView.Item(5, i).Value = dt.Rows(i)("BBK_AMOUNT")
                    _abbkAmt(i) = dt.Rows(i)("BBK_AMOUNT")
                    dgView.Item(6, i).Value = dt.Rows(i)("CITI_INC_AMOUNT")
                    _acitiInc(i) = dt.Rows(i)("CITI_INC_AMOUNT")
                    dgView.Item(7, i).Value = dt.Rows(i)("CITI_VAT_AMOUNT")
                    _acitiVat(i) = dt.Rows(i)("CITI_VAT_AMOUNT")
                    dgView.Item(8, i).Value = dt.Rows(i)("CLIENT_DR_AMOUNT")
                    _aclientDrAmt(i) = dt.Rows(i)("CLIENT_DR_AMOUNT")
                    dgView.Item(9, i).Value = dt.Rows(i)("CHARGEABLE_AMOUNT")
                    dgView.Item(10, i).Value = NullHelper.ToDecNum(dt.Rows(i)("BBK_AMOUNT")) _
                        + NullHelper.ToDecNum(dt.Rows(i)("CITI_INC_AMOUNT")) _
                        + NullHelper.ToDecNum(dt.Rows(i)("CITI_VAT_AMOUNT")) _
                        - NullHelper.ToDecNum(dt.Rows(i)("CLIENT_DR_AMOUNT"))


                Next
                dgView.AllowUserToAddRows = False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadClientChargeData(ByVal strAccNo As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClientCharge_GetDetails")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ACC_NO", DbType.String, strAccNo)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(1, i).Value = dt.Rows(i)("VALUE_TYPE")
                    dgView.Item(2, i).Value = GetValueTypeName(NullHelper.ToIntNum(dt.Rows(i)("VALUE_TYPE")))
                    _cmbValuTypeName(i) = GetValueTypeName(NullHelper.ToIntNum(dt.Rows(i)("VALUE_TYPE")))
                    dgView.Item(3, i).Value = dt.Rows(i)("MIN_AMOUNT")
                    _minAmt(i) = dt.Rows(i)("MIN_AMOUNT")
                    dgView.Item(4, i).Value = dt.Rows(i)("MAX_AMOUNT")
                    _maxAmt(i) = dt.Rows(i)("MAX_AMOUNT")
                    dgView.Item(5, i).Value = dt.Rows(i)("BBK_AMOUNT")
                    _bbkAmt(i) = dt.Rows(i)("BBK_AMOUNT")
                    dgView.Item(6, i).Value = dt.Rows(i)("CITI_INC_AMOUNT")
                    _citiInc(i) = dt.Rows(i)("CITI_INC_AMOUNT")
                    dgView.Item(7, i).Value = dt.Rows(i)("CITI_VAT_AMOUNT")
                    _citiVat(i) = dt.Rows(i)("CITI_VAT_AMOUNT")
                    dgView.Item(8, i).Value = dt.Rows(i)("CLIENT_DR_AMOUNT")
                    _clientDrAmt(i) = dt.Rows(i)("CLIENT_DR_AMOUNT")
                    dgView.Item(9, i).Value = dt.Rows(i)("CHARGEABLE_AMOUNT")
                    dgView.Item(10, i).Value = NullHelper.ToDecNum(dt.Rows(i)("BBK_AMOUNT")) _
                        + NullHelper.ToDecNum(dt.Rows(i)("CITI_INC_AMOUNT")) _
                        + NullHelper.ToDecNum(dt.Rows(i)("CITI_VAT_AMOUNT")) _
                        - NullHelper.ToDecNum(dt.Rows(i)("CLIENT_DR_AMOUNT"))


                Next
                dgView.AllowUserToAddRows = False

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

    Public Sub New(ByVal strAccNo As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'LoadClientData(strClientCode, intMod)

        _strAcc_No = strAccNo
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@ACC_NO", DbType.String, _strAcc_No)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (12-05-2016)------------

            If _intModno > 1 Then

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

                'For Gridview Data

                For i = 0 To dgView.Rows.Count - 1

                    If _acmbValuTypeName(i) <> _cmbValuTypeName(i) Then
                        log_message = " Value Type : " + _acmbValuTypeName(i) + " " + " To " + " " + _cmbValuTypeName(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If

                    If _aminAmt(i) <> _minAmt(i) Then
                        log_message = " Minimum Amount : " + _aminAmt(i) + " " + " To " + " " + _minAmt(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _amaxAmt(i) <> _maxAmt(i) Then
                        log_message = " Maximum  Amount : " + _amaxAmt(i) + " " + " To " + " " + _maxAmt(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _abbkAmt(i) <> _bbkAmt(i) Then
                        log_message = " BBK Amount : " + _abbkAmt(i) + " " + " To " + " " + _bbkAmt(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _acitiInc(i) <> _citiInc(i) Then
                        log_message = " Citi Income Amount : " + _acitiInc(i) + " " + " To " + " " + _citiInc(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _acitiVat(i) <> _citiVat(i) Then
                        log_message = " Citi Vat Amount : " + _acitiVat(i) + " " + " To " + " " + _citiVat(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                    If _aclientDrAmt(i) <> _clientDrAmt(i) Then
                        log_message = " Client Dr Amount : " + _aclientDrAmt(i) + " " + " To " + " " + _clientDrAmt(i) + "." + " "
                        ClearClientList.Add(log_message)
                    End If
                Next

                '-----------------

                For Each clrclientInfo As String In ClearClientList
                    _ClrClientLog += clrclientInfo
                Next
                _log = " Authorized : Account No : " + txtAccNo.Text.ToString() + "." + " " + _ClrClientLog

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
                _log = " Authorized : Account No : " + txtAccNo.Text.ToString() + "." + " " + _ClrClientLog

                Logger.system_log(_log)

                _ClrClientLog = ""
                ClearClientList.Clear()

            End If


            '------------Mizan Work (12-05-2016)------------

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@ACC_NO", DbType.String, _strAcc_No)
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

    Private Sub LoadClientInfo(ByVal strAccNo)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetMaxMod")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@ACC_NO", DbType.String, strAccNo)

            Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            If intModNo > 0 Then
                LoadClientData(strAccNo, intModNo)

            Else
                'ClearFieldsAll()

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadComboValues()

        ' Dim dt2 As New DataTable()

        dt2.Columns.Add("ID")
        dt2.Columns.Add("TYPE")
        Dim dr2 As DataRow = dt2.NewRow()



        dr2 = dt2.NewRow()
        dr2(0) = "T"
        dr2(1) = "Type T"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "D"
        dr2(1) = "Type D"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "C"
        dr2(1) = "Type C"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "R"
        dr2(1) = "Type R"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "B"
        dr2(1) = "Type B"
        dt2.Rows.Add(dr2)

        dr2 = dt2.NewRow()
        dr2(0) = "DR"
        dr2(1) = "Type DR"
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

        dr3 = dt3.NewRow()
        dr3(0) = "1"
        dr3(1) = "Regular"
        dt3.Rows.Add(dr3)

        dr3 = dt3.NewRow()
        dr3(0) = "2"
        dr3(1) = "High"
        dt3.Rows.Add(dr3)

        cmbValueType.DataSource = dt3
        cmbValueType.DisplayMember = "TYPE"
        cmbValueType.ValueMember = "ID"

    End Sub

    Private Function GetValueTypeName(ByVal val As Integer) As String
        Dim typeName As String = ""

        If val = 1 Then
            typeName = "Regular"
        ElseIf val = 2 Then
            typeName = "High"
        End If

        Return typeName

    End Function

    Private Sub PopulateCitiExpense()
        txtCitiExpenseAmt.Text = NullHelper.ToDecNum(txtBBKCharge.Text) _
                        + NullHelper.ToDecNum(txtCitiIncomeAmt.Text) _
                        + NullHelper.ToDecNum(txtCitiVATAmt.Text) _
                        - NullHelper.ToDecNum(txtClientDrAmt.Text)
    End Sub

#End Region





    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        EnableNew()



        If Not (_strAcc_No.Trim() = "") Then

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

        If txtAccNo.ReadOnly = False Then
            txtAccNo.Focus()
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

                        LoadClientData(_strAcc_No, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadClientData(_strAcc_No, _intModno)

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
        LoadClientData(_strAcc_No, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadClientData(_strAcc_No, _intModno)
                    LoadClientChargeData(_strAcc_No, _intModno)

                    DisableAuth()

                    If _strAcc_No = "" Then

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
            LoadClientData(_strAcc_No, _intModno - 1)
            LoadClientChargeData(_strAcc_No, _intModno)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strAccNo As String = _strAcc_No
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadClientData(_strAcc_No, _intModno + 1)

            If _intModno = 0 Then
                LoadClientData(strAccNo, intModno)
            End If

            LoadClientChargeData(_strAcc_No, _intModno)
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadClientDataForAuth(_strAcc_No)
                    LoadClientChargeDataForAuth(_strAcc_No)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadClientData(_strAcc_No, _intModno)
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






    Private Sub FrmClearingClientDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        LoadComboValues()

        dgView.AllowUserToAddRows = False

        If _intModno > 0 Then
            LoadClientData(_strAcc_No, _intModno)
            LoadClientChargeData(_strAcc_No, _intModno)
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

    Private Sub txtAccNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccNo.KeyDown
        If e.KeyCode = Keys.Enter And txtAccNo.Text.Trim() <> "" Then
            LoadClientInfo(txtAccNo.Text.Trim())

            If txtAccNo.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
            End If

        End If


        If e.KeyCode = Keys.Enter And txtAccNo.Text.Trim() <> "" Then

            LoadClientInfo(txtAccNo.Text.Trim())


            If _intModno > 0 Then
                txtAccNo.ReadOnly = True
                LoadClientChargeData(_strAcc_No, _intModno)
            Else


            End If

            SendKeys.Send("{tab}")

        End If
    End Sub

    Private Sub txtAccName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub chkDisable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkDisable.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cmbSpeedType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSpeedType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtContact_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContact.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{tab}")

        End If


    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click

        If cmbValueType.SelectedIndex = -1 Then

            MessageBox.Show("Select value type !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbValueType.Focus()
            Exit Sub
        End If

        If txtMinAmount.Text.Trim() = "" Then

            MessageBox.Show("Minimum amount required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMinAmount.Focus()
            Exit Sub
        End If

        If txtMaxAmount.Text.Trim() = "" Then

            MessageBox.Show("Maximum amount required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMaxAmount.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtTotalChargeable.Text) = 0 Then
            MessageBox.Show("Total chargeable amount required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalChargeable.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtMinAmount.Text.Trim()) > NullHelper.ToDecNum(txtMaxAmount.Text.Trim()) Then
            MessageBox.Show("Minmum amount cannot be higher value than maximum amount !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMaxAmount.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtCitiExpenseAmt.Text) < 0 Then
            MessageBox.Show("Citi Expense cannot be negative value !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBBKCharge.Focus()
            Exit Sub
        End If



        If _RowEditMode = True Then
            Dim selRow As Integer = lblRowNo.Text.Trim()

            dgView.Item(1, selRow).Value = cmbValueType.SelectedValue
            dgView.Item(2, selRow).Value = cmbValueType.Text
            dgView.Item(3, selRow).Value = NullHelper.ToDecNum(txtMinAmount.Text.Trim())
            dgView.Item(4, selRow).Value = NullHelper.ToDecNum(txtMaxAmount.Text.Trim())
            dgView.Item(5, selRow).Value = NullHelper.ToDecNum(txtBBKCharge.Text.Trim())
            dgView.Item(6, selRow).Value = NullHelper.ToDecNum(txtCitiIncomeAmt.Text.Trim())
            dgView.Item(7, selRow).Value = NullHelper.ToDecNum(txtCitiVATAmt.Text.Trim())
            dgView.Item(8, selRow).Value = NullHelper.ToDecNum(txtClientDrAmt.Text.Trim())
            dgView.Item(9, selRow).Value = NullHelper.ToDecNum(txtTotalChargeable.Text.Trim())
            dgView.Item(10, selRow).Value = NullHelper.ToDecNum(txtCitiExpenseAmt.Text.Trim())


            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(selRow).Selected = True

            grpControlBox.Enabled = True

        Else

            dgView.Rows.Add()

            Dim maxRow As Integer = dgView.Rows.Count - 1

            dgView.Item(0, maxRow).Value = maxRow + 1
            dgView.Item(1, maxRow).Value = cmbValueType.SelectedValue
            dgView.Item(2, maxRow).Value = cmbValueType.Text
            dgView.Item(3, maxRow).Value = NullHelper.ToDecNum(txtMinAmount.Text.Trim())
            dgView.Item(4, maxRow).Value = NullHelper.ToDecNum(txtMaxAmount.Text.Trim())
            dgView.Item(5, maxRow).Value = NullHelper.ToDecNum(txtBBKCharge.Text.Trim())
            dgView.Item(6, maxRow).Value = NullHelper.ToDecNum(txtCitiIncomeAmt.Text.Trim())
            dgView.Item(7, maxRow).Value = NullHelper.ToDecNum(txtCitiVATAmt.Text.Trim())
            dgView.Item(8, maxRow).Value = NullHelper.ToDecNum(txtClientDrAmt.Text.Trim())
            dgView.Item(9, maxRow).Value = NullHelper.ToDecNum(txtTotalChargeable.Text.Trim())
            dgView.Item(10, maxRow).Value = NullHelper.ToDecNum(txtCitiExpenseAmt.Text.Trim())

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

        txtMinAmount.Clear()
        txtMaxAmount.Clear()
        txtBBKCharge.Clear()
        txtCitiIncomeAmt.Clear()
        txtCitiVATAmt.Clear()
        txtClientDrAmt.Clear()
        txtTotalChargeable.Clear()
        txtCitiExpenseAmt.Clear()

        dgView.Enabled = True

        cmbValueType.Focus()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _RowEditMode = False
        lblRowNo.Text = ""

        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        txtMinAmount.Clear()
        txtMaxAmount.Clear()
        txtBBKCharge.Clear()
        txtCitiIncomeAmt.Clear()
        txtCitiVATAmt.Clear()
        txtClientDrAmt.Clear()
        txtTotalChargeable.Clear()
        txtCitiExpenseAmt.Clear()

        dgView.Enabled = True
        grpControlBox.Enabled = True
    End Sub

    Private Sub btnRemoveFromGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromGrid.Click
        If dgView.SelectedRows.Count = 0 Then Exit Sub

        For Each row As DataGridViewRow In dgView.SelectedRows
            dgView.Rows.Remove(row)
        Next

        Dim rowSlno As Integer = 1

        For Each row As DataGridViewRow In dgView.Rows
            row.Cells(0).Value = rowSlno
            rowSlno = rowSlno + 1
        Next

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick

        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _RowEditMode = True

            btnAddToGrid.Text = "Update"
            btnCancel.Visible = True
            btnRemoveFromGrid.Enabled = False

            lblRowNo.Text = e.RowIndex.ToString()

            cmbValueType.SelectedValue = dgView.Item(1, e.RowIndex).Value
            txtMinAmount.Text = dgView.Item(3, e.RowIndex).Value
            txtMaxAmount.Text = dgView.Item(4, e.RowIndex).Value
            txtBBKCharge.Text = dgView.Item(5, e.RowIndex).Value
            txtCitiIncomeAmt.Text = dgView.Item(6, e.RowIndex).Value
            txtCitiVATAmt.Text = dgView.Item(7, e.RowIndex).Value
            txtClientDrAmt.Text = dgView.Item(8, e.RowIndex).Value
            txtTotalChargeable.Text = dgView.Item(9, e.RowIndex).Value

            dgView.Enabled = False

            grpControlBox.Enabled = False

        End If

    End Sub

    Private Sub cmbValueType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbValueType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtMinAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMinAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtMaxAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaxAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

  

   
    Private Sub txtBBKCharge_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBBKCharge.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCitiIncomeAmt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCitiIncomeAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCitiVATAmt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCitiVATAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtClientDrAmt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientDrAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalChargeable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalChargeable.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBBKCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBBKCharge.TextChanged
        PopulateCitiExpense()
    End Sub

    Private Sub txtCitiIncomeAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCitiIncomeAmt.TextChanged
        PopulateCitiExpense()
    End Sub

    Private Sub txtCitiVATAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCitiVATAmt.TextChanged
        PopulateCitiExpense()
    End Sub

    Private Sub txtClientDrAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClientDrAmt.TextChanged
        PopulateCitiExpense()
    End Sub

    Private Sub txtCitiExpenseAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCitiExpenseAmt.TextChanged

        If NullHelper.ToDecNum(txtCitiExpenseAmt.Text) >= 0 Then
            txtCitiExpenseAmt.BackColor = System.Drawing.SystemColors.Control
        Else
            txtCitiExpenseAmt.BackColor = Color.MistyRose 'lav

        End If

    End Sub

    Private Sub chkGovtAcc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkGovtAcc.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub chkInsuffecientFund_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkInsuffecientFund.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class