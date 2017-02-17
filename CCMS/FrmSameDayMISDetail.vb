
'
' Same Day MIS Detail
' Author: Md. Fahad Khan
' Since: 02-Nov-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmSameDayMISDetail

#Region "Global Variables"

    Dim _formName As String = "DepositSameDayMISDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strSlip_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

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

        txtAccountNo.ReadOnly = True
        txtClientCode.ReadOnly = True
        txtTransDate.ReadOnly = True
        cmbInstrumentType.Enabled = False
        txtInstrumentNo.ReadOnly = True
        txtLocation.ReadOnly = True
        txtAmount.ReadOnly = True
        txtIssueBank.ReadOnly = True
        cmbFlag.Enabled = False

        txtRemarks.ReadOnly = True

        txtSlipNo.ReadOnly = True
        

    End Sub

    Private Sub EnableFields()
        

        txtAccountNo.ReadOnly = False
        txtClientCode.ReadOnly = False
        txtTransDate.ReadOnly = False
        cmbInstrumentType.Enabled = True
        txtInstrumentNo.ReadOnly = False
        txtLocation.ReadOnly = False
        txtAmount.ReadOnly = False
        txtIssueBank.ReadOnly = False
        cmbFlag.Enabled = True

        txtRemarks.ReadOnly = False

        txtSlipNo.ReadOnly = False




    End Sub

    Private Sub EnableNewFields()


        txtAccountNo.ReadOnly = True
        txtClientCode.ReadOnly = True
        txtTransDate.ReadOnly = True
        cmbInstrumentType.Enabled = False
        txtInstrumentNo.ReadOnly = True
        txtLocation.ReadOnly = True
        txtAmount.ReadOnly = True
        txtIssueBank.ReadOnly = True
        cmbFlag.Enabled = True

        txtRemarks.ReadOnly = False

        txtSlipNo.ReadOnly = True




    End Sub


    Private Sub ClearFields()

        txtAccountNo.Clear()
        txtClientCode.Clear()
        txtTransDate.Clear()
        cmbInstrumentType.SelectedIndex = -1
        txtInstrumentNo.Clear()
        txtLocation.Clear()
        txtAmount.Clear()
        txtIssueBank.Clear()
        cmbFlag.SelectedIndex = -1

        txtRemarks.Clear()

        txtSlipNo.Clear()

    End Sub

    Private Sub ClearFieldsAll()
        txtAccountNo.Clear()
        txtClientCode.Clear()
        txtTransDate.Clear()
        cmbInstrumentType.SelectedIndex = -1
        txtInstrumentNo.Clear()
        txtLocation.Clear()
        txtAmount.Clear()
        txtIssueBank.Clear()
        cmbFlag.SelectedIndex = -1

        txtSlipNo.Clear()

        txtRemarks.Clear()
        _strSlip_Code = ""
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

        If txtAccountNo.Text.Trim() = "" Then
            MessageBox.Show("Accouunt required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccountNo.Focus()
            Return False
        ElseIf txtClientCode.Text.Trim() = "" Then
            MessageBox.Show("Client Code required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Return False

        ElseIf txtSlipNo.Text.Trim() = "" Then
            MessageBox.Show("Slip No required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlipNo.Focus()
            Return False

        ElseIf txtSlipNo.Text.Trim() <> "" And Len(txtSlipNo.Text.Trim()) > 12 Then
            MessageBox.Show("max 12 character Slip no!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlipNo.Focus()
            Return False


        ElseIf txtTransDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Transaction date required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransDate.Focus()
            Return False

        ElseIf cmbInstrumentType.Text.Trim() = "" Then
            MessageBox.Show("Instrument Type required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbInstrumentType.Focus()
            Return False


        ElseIf cmbInstrumentType.Text.Trim() = "Check" And txtInstrumentNo.Text.Trim = "" Then
            MessageBox.Show("Instrument No required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtInstrumentNo.Focus()
            Return False

        ElseIf txtAmount.Text.Trim = "" Then
            MessageBox.Show("Amount required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Return False

        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@AC_NO", DbType.String, txtAccountNo.Text.Trim())
            db.AddInParameter(commProc, "@TRANSACTION_DATE", DbType.DateTime, NullHelper.StringToDate(txtTransDate.Text.Trim()))

            db.AddInParameter(commProc, "@SLIP_NO", DbType.String, txtSlipNo.Text.Trim())
            db.AddInParameter(commProc, "@INSTRUMENT_TYPE", DbType.String, cmbInstrumentType.Text.Trim())

            db.AddInParameter(commProc, "@INSTRUMENT_NO", DbType.String, txtInstrumentNo.Text.Trim())
            db.AddInParameter(commProc, "@ISSUE_BANK", DbType.String, txtIssueBank.Text.Trim())
            db.AddInParameter(commProc, "@LOCATION", DbType.String, txtLocation.Text.Trim())

            If cmbFlag.Text.Trim() = "" Then

                db.AddInParameter(commProc, "@FLAG", DbType.String, DBNull.Value)
            Else
                db.AddInParameter(commProc, "@FLAG", DbType.Boolean, cmbFlag.SelectedIndex)

            End If

            'db.AddInParameter(commProc, "@FLAG", DbType.Boolean, txtAmount.Text.Trim())

            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtAmount.Text.Trim())
            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            db.AddInParameter(commProc, "@INPUT_BY", DbType.String, CommonAppSet.User)

            db.AddInParameter(commProc, "@REMARKS", DbType.String, txtRemarks.Text.Trim())

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strSlip_Code = txtSlipNo.Text.Trim()

                _intModno = 1

                'Logger.system_log(" Same Day MIS SLIP NO : " + txtSlipNo.Text.Trim() + ", Transaction Date :" + NullHelper.StringToDate(txtTransDate.Text.Trim()) + " Added")

                '------------Mizan Work (08-05-2016)------------

                log_message = " Added : Same Day MIS SLIP NO : " + txtSlipNo.Text.Trim() + "." + " " + " Transaction Date : " + txtTransDate.Text.Trim()
                Logger.system_log(log_message)

                '------------Mizan Work (08-05-2016)------------


            Else
                tStatus = TransState.Exist
            End If


        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SLIP_NO", DbType.String, _strSlip_Code)
            db.AddInParameter(commProc, "@AC_NO", DbType.String, txtAccountNo.Text.Trim())
            db.AddInParameter(commProc, "@TRANSACTION_DATE", DbType.DateTime, NullHelper.StringToDate(txtTransDate.Text.Trim()))
            db.AddInParameter(commProc, "@INSTRUMENT_TYPE", DbType.String, cmbInstrumentType.Text.Trim())

            db.AddInParameter(commProc, "@INSTRUMENT_NO", DbType.String, txtInstrumentNo.Text.Trim())
            db.AddInParameter(commProc, "@ISSUE_BANK", DbType.String, txtIssueBank.Text.Trim())
            db.AddInParameter(commProc, "@LOCATION", DbType.String, txtLocation.Text.Trim())

            If cmbFlag.Text.Trim() = "" Then

                db.AddInParameter(commProc, "@FLAG", DbType.String, DBNull.Value)
            Else
                db.AddInParameter(commProc, "@FLAG", DbType.Boolean, cmbFlag.SelectedIndex)

            End If

            'db.AddInParameter(commProc, "@FLAG", DbType.Boolean, txtAmount.Text.Trim())

            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtAmount.Text.Trim())
            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())


            db.AddInParameter(commProc, "@REMARKS", DbType.String, txtRemarks.Text.Trim())


            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
            db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)


            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Update
                _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

                '------------Mizan Work (08-05-2016)------------

                If _transDate <> txtTransDate.Text.Trim() Then
                    log_message = " Transaction Date : " + _transDate + " " + " To " + " " + txtTransDate.Text.Trim() + "." + " "
                    SameDayMISList.Add(log_message)
                End If
                If _cmbInsType <> cmbInstrumentType.Text Then
                    log_message = " Instrument Type : " + _cmbInsType + " " + " To " + " " + cmbInstrumentType.Text + "." + " "
                    SameDayMISList.Add(log_message)
                End If
                If _InstruNo <> txtInstrumentNo.Text.Trim() Then
                    log_message = " Instrument No : " + _InstruNo + " " + " To " + " " + txtInstrumentNo.Text.Trim() + "." + " "
                    SameDayMISList.Add(log_message)
                End If
                If _amount <> txtAmount.Text.Trim() Then
                    log_message = " Amount : " + _amount + " " + " To " + " " + txtAmount.Text.Trim() + "." + " "
                    SameDayMISList.Add(log_message)
                End If
                If _location <> txtLocation.Text.Trim() Then
                    If _location = "" Then
                        log_message = " Location : " + txtLocation.Text.Trim() + "." + " "
                    Else
                        log_message = " Location : " + _location + " " + " To " + " " + txtLocation.Text.Trim() + "." + " "
                    End If
                    SameDayMISList.Add(log_message)
                End If
                If _remarks <> txtRemarks.Text.Trim() Then
                    If _remarks = "" Then
                        log_message = " Remarks : " + txtRemarks.Text.Trim() + "." + " "
                    Else
                        log_message = " Remarks : " + _remarks + " " + " To " + " " + txtRemarks.Text.Trim() + "." + " "
                    End If
                    SameDayMISList.Add(log_message)
                End If
                If _clientcode <> txtClientCode.Text.Trim() Then
                    If _clientcode = "" Then
                        log_message = " Client Code : " + txtClientCode.Text.Trim() + "." + " "
                    Else
                        log_message = " Client Code : " + _clientcode + " " + " To " + " " + txtClientCode.Text.Trim() + "." + " "
                    End If
                    SameDayMISList.Add(log_message)
                End If
                If _issuBank <> txtIssueBank.Text.Trim() Then
                    If _issuBank = "" Then
                        log_message = " Issue Bank : " + txtIssueBank.Text.Trim() + "." + " "
                    Else
                        log_message = " Issue Bank : " + _issuBank + " " + " To " + " " + txtIssueBank.Text.Trim() + "." + " "
                    End If
                    SameDayMISList.Add(log_message)
                End If


                For Each MISInfo As String In SameDayMISList
                    _dayLog += MISInfo
                Next
                _log = " Updated : Same Day MIS SLIP NO : " + txtSlipNo.Text.Trim() + "." + " " + " Account No: " + txtAccountNo.Text.ToString() + "." + " " + _dayLog

                Logger.system_log(_log)

                _dayLog = ""
                SameDayMISList.Clear()

                '------------Mizan Work (08-05-2016)------------

                'Logger.system_log(" Same Day MIS SLIP_NO : " + txtSlipNo.Text.Trim() + ", Transaction Date :" + NullHelper.StringToDate(txtTransDate.Text.Trim()) + " Updated")

            ElseIf result = 1 Then
                tStatus = TransState.UnspecifiedError
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            End If

        End If

        Return tStatus

    End Function

    '------------Mizan Work (15-05-2016)------------
    Private Sub LoadMainDataForAuth(ByVal strSlipNo As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From IMP_SAMEDAYMIS  Where SLIP_NO ='" & strSlipNo & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _strSlip_Code = strSlipNo
               

                txtAccountNo.Text = ds.Tables(0).Rows(0)("AC_NO").ToString()
                txtClientCode.Text = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                _aclientcode = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                txtSlipNo.Text = ds.Tables(0).Rows(0)("SLIP_NO").ToString()
                _aslipNo = ds.Tables(0).Rows(0)("SLIP_NO").ToString()

                txtTransDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("TRANSACTION_DATE"))
                _atransDate = NullHelper.DateToString(ds.Tables(0).Rows(0)("TRANSACTION_DATE")).ToString

                If ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString() = "Check" Then
                    cmbInstrumentType.SelectedIndex = 0
                ElseIf ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString() = "Cash" Then
                    cmbInstrumentType.SelectedIndex = 1
                End If
                _acmbInsType = ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString()
                txtInstrumentNo.Text = ds.Tables(0).Rows(0)("INSTRUMENT_NO").ToString()
                _aInstruNo = ds.Tables(0).Rows(0)("INSTRUMENT_NO").ToString()

                txtIssueBank.Text = ds.Tables(0).Rows(0)("ISSUE_BANK").ToString()
                _aissuBank = ds.Tables(0).Rows(0)("ISSUE_BANK").ToString()

                txtLocation.Text = ds.Tables(0).Rows(0)("LOCATION").ToString()
                _alocation = ds.Tables(0).Rows(0)("LOCATION").ToString()

                txtAmount.Text = ds.Tables(0).Rows(0)("AMOUNT").ToString()
                _aamount = ds.Tables(0).Rows(0)("AMOUNT").ToString()

                txtRemarks.Text = ds.Tables(0).Rows(0)("REMARKS").ToString()
                _aremarks = ds.Tables(0).Rows(0)("REMARKS").ToString()

               
            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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


                _strSlip_Code = strSlipNo
                _intModno = intMod

                _formMode = FormTransMode.Update

                txtAccountNo.Text = ds.Tables(0).Rows(0)("AC_NO").ToString()
                txtClientCode.Text = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                _clientcode = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                txtSlipNo.Text = ds.Tables(0).Rows(0)("SLIP_NO").ToString()
                _slipNo = ds.Tables(0).Rows(0)("SLIP_NO").ToString()

                txtTransDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("TRANSACTION_DATE"))
                _transDate = NullHelper.DateToString(ds.Tables(0).Rows(0)("TRANSACTION_DATE")).ToString

                If ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString() = "Check" Then
                    cmbInstrumentType.SelectedIndex = 0
                ElseIf ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString() = "Cash" Then
                    cmbInstrumentType.SelectedIndex = 1
                End If
                _cmbInsType = ds.Tables(0).Rows(0)("INSTRUMENT_TYPE").ToString()
                txtInstrumentNo.Text = ds.Tables(0).Rows(0)("INSTRUMENT_NO").ToString()
                _InstruNo = ds.Tables(0).Rows(0)("INSTRUMENT_NO").ToString()

                txtIssueBank.Text = ds.Tables(0).Rows(0)("ISSUE_BANK").ToString()
                _issuBank = ds.Tables(0).Rows(0)("ISSUE_BANK").ToString()

                txtLocation.Text = ds.Tables(0).Rows(0)("LOCATION").ToString()
                _location = ds.Tables(0).Rows(0)("LOCATION").ToString()

                txtAmount.Text = ds.Tables(0).Rows(0)("AMOUNT").ToString()
                _amount = ds.Tables(0).Rows(0)("AMOUNT").ToString()

                txtRemarks.Text = ds.Tables(0).Rows(0)("REMARKS").ToString()
                _remarks = ds.Tables(0).Rows(0)("REMARKS").ToString()

                If ds.Tables(0).Rows(0)("FLAG").ToString() = "False" Then
                    cmbFlag.SelectedIndex = 0
                ElseIf ds.Tables(0).Rows(0)("FLAG").ToString() = "True" Then
                    cmbFlag.SelectedIndex = 1
                End If




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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@SLIP_NO", DbType.String, strSlipNo)

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

    Public Sub New(ByVal strSlipNo As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadMainData(strSlipNo, intMod)
        _strSlip_Code = strSlipNo
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@SLIP_NO", DbType.String, _strSlip_Code)
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
                _log = " Authorized : Same Day MIS SLIP NO : " + txtSlipNo.Text.Trim() + "." + " " + " Account No: " + txtAccountNo.Text.ToString() + "." + " " + _dayLog

                Logger.system_log(_log)

                _dayLog = ""
                SameDayMISList.Clear()

            Else

                _log = " Authorized : Same Day MIS SLIP NO : " + txtSlipNo.Text.Trim() + "." + " " + " Account No: " + txtAccountNo.Text.ToString()

                Logger.system_log(_log)

            End If
            '------------Mizan Work (15-05-2016)------------

            'Logger.system_log(" Same Day MIS SLIP_NO : " + _strSlip_Code + " Authorized")

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMis_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@SLIP_NO", DbType.String, _strSlip_Code)
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

#End Region


    Private Sub FrmSameDayMISDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()

        DisableClear()
        DisableRefresh()

        DisableFields()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        LoadMainData(_strSlip_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadMainData(_strSlip_Code, _intModno)

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

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        EnableNew()



        If Not (_strSlip_Code.Trim() = "") Then

            If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then
                EnableNewFields()


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

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadMainData(_strSlip_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadMainData(_strSlip_Code, _intModno)

                    DisableAuth()

                    If _strSlip_Code = "" Then

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
            LoadMainData(_strSlip_Code, _intModno - 1)

        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strSlipCode As String = _strSlip_Code
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadMainData(_strSlip_Code, _intModno + 1)

            If _intModno = 0 Then
                LoadMainData(strSlipCode, intModno)
            End If
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadMainDataForAuth(_strSlip_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadMainData(_strSlip_Code, _intModno)
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
End Class