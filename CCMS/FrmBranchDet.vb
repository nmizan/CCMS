'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Branch Information
'Creation date      : 14-Nov-2012
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmBranchDet



#Region "Global Variables"

    Dim _formName As String = "MaintenanceBranchDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strBank_Code As String = ""
    Dim _strBranch_Code As String = ""
    Dim _strLocation_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

    'For Update
    Dim _BankName As String = ""
    Dim _LocCode As String = ""
    Dim _BranchCode As String = ""
    Dim _BranchName As String = ""
    Dim _LocName As String = ""
    Dim _RouteNo As String = ""
    Dim _NikBrCode As String = ""
    Dim _BrAdd1 As String = ""
    Dim _BrAdd2 As String = ""
    Dim _cmbClearZone As String = ""

    'For Auth
    Dim _aLocCode As String = ""
    Dim _aBranchCode As String = ""
    Dim _aBranchName As String = ""
    Dim _aRouteNo As String = ""
    Dim _aNikBrCode As String = ""
    Dim _aBrAdd1 As String = ""
    Dim _aBrAdd2 As String = ""
    Dim _acmbClearZone As String = ""

    Dim BranchList As New List(Of String)
    Dim _branchLog As String = ""
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
        txtBankCode.ReadOnly = True
        btnSearchBank.Enabled = False
        txtBranchCode.ReadOnly = True
        txtRoutingNo.ReadOnly = True
        txtNikBranchCode.ReadOnly = True
        txtBranchName.ReadOnly = True
        txtLocationCode.ReadOnly = True
        btnSearchLocation.Enabled = False
        txtAdd1.ReadOnly = True
        txtAdd2.ReadOnly = True

        cmbClearingZone.Enabled = False
        chkCorrBranch.Enabled = False


    End Sub

    Private Sub EnableFields()

        If txtBranchCode.Text.Trim() = "" Then
            txtBranchCode.ReadOnly = False
            txtBankCode.ReadOnly = False
            btnSearchBank.Enabled = True
            txtLocationCode.ReadOnly = False
            btnSearchLocation.Enabled = True
        End If

        txtRoutingNo.ReadOnly = False
        txtNikBranchCode.ReadOnly = False
        txtBranchName.ReadOnly = False
        'txtLocationCode.ReadOnly = False
        'btnSearchLocation.Enabled = True
        txtAdd1.ReadOnly = False
        txtAdd2.ReadOnly = False

        cmbClearingZone.Enabled = True
        chkCorrBranch.Enabled = True


    End Sub


    Private Sub ClearFields()
        If txtBranchCode.ReadOnly = False Then
            txtBankCode.Clear()
            lblBankName.Text = ""
            txtBranchCode.Clear()
            txtLocationCode.Clear()
            lblLocationName.Text = ""
        End If

        txtRoutingNo.Clear()
        txtNikBranchCode.Clear()
        txtBranchName.Clear()
        
        cmbClearingZone.Text = ""
        chkCorrBranch.Checked = False





    End Sub

    Private Sub ClearFieldsAll()
        txtBankCode.Clear()
        lblBankName.Text = ""
        txtBranchCode.Clear()

        txtRoutingNo.Clear()
        txtNikBranchCode.Clear()
        txtBranchName.Clear()
        txtLocationCode.Clear()
        lblLocationName.Text = ""
        'cmbClearingZone.Text = ""
        cmbClearingZone.SelectedIndex = -1

        chkCorrBranch.Checked = False


        _strBank_Code = ""
        _strBranch_Code = ""
        _strLocation_Code = ""
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

        If txtBankCode.Text.Trim() = "" Or lblBankName.Text.Trim() = "" Then
            MessageBox.Show("Bank Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBankCode.Focus()
            Return False
        ElseIf txtLocationCode.Text.Trim() = "" Or lblLocationName.Text.Trim() = "" Then
            MessageBox.Show("Location Code required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocationCode.Focus()
            Return False
        ElseIf txtBranchCode.Text.Trim() = "" Then
            MessageBox.Show("Branch Code required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBranchCode.Focus()
            Return False
            'ElseIf txtBranchName.Text.Trim() = "" Then
            '    MessageBox.Show("Branch Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtBranchName.Focus()
            '    Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
            db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())
            db.AddInParameter(commProc, "@BRANCH_NAME", DbType.String, txtBranchName.Text.Trim())
            db.AddInParameter(commProc, "@ROUTING_NO", DbType.String, txtRoutingNo.Text.Trim())
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
            db.AddInParameter(commProc, "@BRANCH_ADD1", DbType.String, txtAdd1.Text.Trim())
            db.AddInParameter(commProc, "@BRANCH_ADD2", DbType.String, txtAdd2.Text.Trim())
            db.AddInParameter(commProc, "@CLEARING_ZONE", DbType.String, cmbClearingZone.SelectedValue)
            db.AddInParameter(commProc, "@CORRBANK", SqlDbType.Bit, chkCorrBranch.Checked)
            db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, NullHelper.ObjectToNull(txtNikBranchCode.Text.Trim()))


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strBank_Code = txtBankCode.Text.Trim()

                _strBranch_Code = txtBranchCode.Text.Trim()

                _strLocation_Code = txtLocationCode.Text.Trim()

                _intModno = 1

                '------------Mizan Work (07-05-2016)------------

                log_message = " Added : Bank Code : " + txtBankCode.Text.Trim() + "." + " " + " Branch Code : " + txtBranchCode.Text.Trim() + "." + " " + " Location Code : " + txtLocationCode.Text.ToString()
                Logger.system_log(log_message)

                '------------Mizan Work (07-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If

            

        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
            db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, _strBranch_Code)
            db.AddInParameter(commProc, "@BRANCH_NAME", DbType.String, txtBranchName.Text.Trim())
            db.AddInParameter(commProc, "@ROUTING_NO", DbType.String, txtRoutingNo.Text.Trim())
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
            db.AddInParameter(commProc, "@BRANCH_ADD1", DbType.String, txtAdd1.Text.Trim())
            db.AddInParameter(commProc, "@BRANCH_ADD2", DbType.String, txtAdd2.Text.Trim())
            db.AddInParameter(commProc, "@CLEARING_ZONE", DbType.String, cmbClearingZone.SelectedValue)
            db.AddInParameter(commProc, "@CORRBANK", SqlDbType.Bit, chkCorrBranch.Checked)
            db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, NullHelper.ObjectToNull(txtNikBranchCode.Text.Trim()))

            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
            db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)


            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Update
                _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

                '------------Mizan Work (07-05-2016)------------

                If _LocCode <> txtLocationCode.Text.Trim() Then
                    log_message = " Location Code : " + _LocCode + " " + " To " + " " + txtLocationCode.Text.Trim() + "." + " "
                    BranchList.Add(log_message)
                End If
                If _BankName <> lblBankName.Text.Trim() Then
                    If _BankName = "" Then
                        log_message = " Bank Name : " + lblBankName.Text.Trim() + "." + " "
                    Else
                        log_message = " Bank Name : " + _BankName + " " + " To " + " " + lblBankName.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _BranchName <> txtBranchName.Text.Trim() Then
                    If _BranchName = "" Then
                        log_message = " Branch Name : " + txtBranchName.Text.Trim() + "." + " "
                    Else
                        log_message = " Branch Name : " + _BranchName + " " + " To " + " " + txtBranchName.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _LocName <> lblLocationName.Text.Trim() Then
                    If _LocName = "" Then
                        log_message = " Location Name : " + lblLocationName.Text.Trim() + "." + " "
                    Else
                        log_message = " Location Name : " + _LocName + " " + " To " + " " + lblLocationName.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _RouteNo <> txtRoutingNo.Text.Trim() Then
                    If _RouteNo = "" Then
                        log_message = " Routing No : " + txtRoutingNo.Text.Trim() + "." + " "
                    Else
                        log_message = " Routing No : " + _RouteNo + " " + " To " + " " + txtRoutingNo.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _NikBrCode <> txtNikBranchCode.Text.Trim() Then
                    If _NikBrCode = "" Then
                        log_message = " Nik Branch Code : " + txtNikBranchCode.Text.Trim() + "." + " "
                    Else
                        log_message = " Nik Branch Code : " + _NikBrCode + " " + " To " + " " + txtNikBranchCode.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _BrAdd1 <> txtAdd1.Text.Trim() Then
                    If _BrAdd1 = "" Then
                        log_message = " Branch Address 1 : " + txtAdd1.Text.Trim() + "." + " "
                    Else
                        log_message = " Branch Address 1 : " + _BrAdd1 + " " + " To " + " " + txtAdd1.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _BrAdd2 <> txtAdd2.Text.Trim() Then
                    If _BrAdd2 = "" Then
                        log_message = " Branch Address 2 : " + txtAdd2.Text.Trim() + "." + " "
                    Else
                        log_message = " Branch Address 2 : " + _BrAdd2 + " " + " To " + " " + txtAdd2.Text.Trim() + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _cmbClearZone <> cmbClearingZone.Text Then
                    If _cmbClearZone = "" Then
                        log_message = " Clearing Zone : " + cmbClearingZone.Text + "." + " "
                    Else
                        log_message = " Clearing Zone : " + _cmbClearZone + " " + " To " + " " + cmbClearingZone.Text + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If

                For Each branchInfo As String In BranchList
                    _branchLog += branchInfo
                Next
                _log = " Updated : Bank Code : " + txtBankCode.Text.ToString() + "." + " " + " Branch Code : " + txtBranchCode.Text.ToString() + "." + " " + _branchLog

                Logger.system_log(_log)

                _branchLog = ""
                BranchList.Clear()

                '------------Mizan Work (07-05-2016)------------

            ElseIf result = 1 Then
                tStatus = TransState.UnspecifiedError
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            End If

            

        End If

        Return tStatus

    End Function

    '------------Mizan Work (11-05-2016)------------

    Private Sub LoadBranchDataForAuth(ByVal strBankCode As String, ByVal strBranchCode As String, ByVal strLocationCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From BRANCH Where BANK_CODE ='" & strBankCode & "' and BRANCH_CODE ='" & strBranchCode & "' and LOCATION_CODE ='" & strLocationCode & "'   and STATUS='L'")
            
            If ds.Tables(0).Rows.Count > 0 Then

                _strBank_Code = strBankCode
                _strBranch_Code = strBranchCode
                _strLocation_Code = strLocationCode

                txtBankCode.Text = ds.Tables(0).Rows(0)("BANK_CODE").ToString()
                
                txtBranchCode.Text = ds.Tables(0).Rows(0)("BRANCH_CODE").ToString()
                _aBranchCode = ds.Tables(0).Rows(0)("BRANCH_CODE").ToString()
                txtBranchName.Text = ds.Tables(0).Rows(0)("BRANCH_NAME").ToString()
                _aBranchName = ds.Tables(0).Rows(0)("BRANCH_NAME").ToString()
                txtRoutingNo.Text = ds.Tables(0).Rows(0)("ROUTING_NO").ToString()
                _aRouteNo = ds.Tables(0).Rows(0)("ROUTING_NO").ToString()
                txtNikBranchCode.Text = ds.Tables(0).Rows(0)("NIKBRANCH_CODE").ToString()
                _aNikBrCode = ds.Tables(0).Rows(0)("NIKBRANCH_CODE").ToString()
                txtLocationCode.Text = ds.Tables(0).Rows(0)("LOCATION_CODE").ToString()
                _aLocCode = ds.Tables(0).Rows(0)("LOCATION_CODE").ToString()
                txtAdd1.Text = ds.Tables(0).Rows(0)("BRANCH_ADD1").ToString()
                _aBrAdd1 = ds.Tables(0).Rows(0)("BRANCH_ADD1").ToString()
                txtAdd2.Text = ds.Tables(0).Rows(0)("BRANCH_ADD2").ToString()
                _aBrAdd2 = ds.Tables(0).Rows(0)("BRANCH_ADD2").ToString()
                cmbClearingZone.SelectedValue = ds.Tables(0).Rows(0)("CLEARING_ZONE").ToString()
                _acmbClearZone = ds.Tables(0).Rows(0)("CLEARING_ZONE").ToString()




                Dim ds2 As New DataSet
                ds2 = db.ExecuteDataSet(CommandType.Text, "Select *  From ZONE Where ZONE_CODE = '" & _acmbClearZone & "' ")
                If ds2.Tables(0).Rows.Count > 0 Then
                    _acmbClearZone = ds2.Tables(0).Rows(0)("ZONE_NAME").ToString()

                End If

            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBranchData(ByVal strBankCode As String, ByVal strBranchCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, strBankCode)
            db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, strBranchCode)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, strLocationCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strBank_Code = strBankCode
                _strBranch_Code = strBranchCode
                _strLocation_Code = strLocationCode
                _intModno = intMod

                _formMode = FormTransMode.Update


                txtBankCode.Text = ds.Tables(0).Rows(0)("BANK_CODE").ToString()
                lblBankName.Text = ds.Tables(0).Rows(0)("BANK_NAME").ToString()
                _BankName = ds.Tables(0).Rows(0)("BANK_NAME").ToString()

                txtBranchCode.Text = ds.Tables(0).Rows(0)("BRANCH_CODE").ToString()
                _BranchCode = ds.Tables(0).Rows(0)("BRANCH_CODE").ToString()
                txtBranchName.Text = ds.Tables(0).Rows(0)("BRANCH_NAME").ToString()
                _BranchName = ds.Tables(0).Rows(0)("BRANCH_NAME").ToString()

                txtRoutingNo.Text = ds.Tables(0).Rows(0)("ROUTING_NO").ToString()
                _RouteNo = ds.Tables(0).Rows(0)("ROUTING_NO").ToString()
                txtNikBranchCode.Text = ds.Tables(0).Rows(0)("NIKBRANCH_CODE").ToString()
                _NikBrCode = ds.Tables(0).Rows(0)("NIKBRANCH_CODE").ToString()
                txtLocationCode.Text = ds.Tables(0).Rows(0)("LOCATION_CODE").ToString()
                _LocCode = ds.Tables(0).Rows(0)("LOCATION_CODE").ToString()
                lblLocationName.Text = ds.Tables(0).Rows(0)("LOCATION_NAME").ToString()
                _LocName = ds.Tables(0).Rows(0)("LOCATION_NAME").ToString()
                txtAdd1.Text = ds.Tables(0).Rows(0)("BRANCH_ADD1").ToString()
                _BrAdd1 = ds.Tables(0).Rows(0)("BRANCH_ADD1").ToString()
                txtAdd2.Text = ds.Tables(0).Rows(0)("BRANCH_ADD2").ToString()
                _BrAdd2 = ds.Tables(0).Rows(0)("BRANCH_ADD2").ToString()
                cmbClearingZone.SelectedValue = ds.Tables(0).Rows(0)("CLEARING_ZONE").ToString()
                _cmbClearZone = ds.Tables(0).Rows(0)("CLEARING_ZONE").ToString()
                chkCorrBranch.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("CORRBANK"))

                '------------Mizan Work (07-05-2016)------------

                Dim ds2 As New DataSet
                ds2 = db.ExecuteDataSet(CommandType.Text, "Select *  From ZONE Where ZONE_CODE = '" & _cmbClearZone & "' ")
                If ds2.Tables(0).Rows.Count > 0 Then
                    _cmbClearZone = ds2.Tables(0).Rows(0)("ZONE_NAME").ToString()

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Branch_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@BANK_CODE", DbType.String, strBankCode)
                db.AddInParameter(commProc2, "@BRANCH_CODE", DbType.String, strBranchCode)
                db.AddInParameter(commProc2, "@LOCATION_CODE", DbType.String, strLocationCode)

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

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim().ToUpper() = CommonAppSet.User.ToUpper()) Then
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


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strBankCode As String, ByVal strBranchCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'LoadBranchData(strBankCode, strBranchCode, strLocationCode, intMod)
        _strBank_Code = strBankCode
        _strBranch_Code = strBranchCode
        _strLocation_Code = strLocationCode
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
        db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, _strBranch_Code)
        db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (11-05-2016)------------

            If _intModno > 1 Then

                If _aLocCode <> _LocCode Then
                    log_message = " Location Code : " + _aLocCode + " " + " To " + " " + _LocCode + "." + " "
                    BranchList.Add(log_message)
                End If

                If _aBranchName <> _BranchName Then
                    If _aBranchName = "" Then
                        log_message = " Branch Name : " + _BranchName + "." + " "
                    Else
                        log_message = " Branch Name : " + _aBranchName + " " + " To " + " " + _BranchName + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If

                If _aRouteNo <> _RouteNo Then
                    If _aRouteNo = "" Then
                        log_message = " Routing No : " + _RouteNo + "." + " "
                    Else
                        log_message = " Routing No : " + _aRouteNo + " " + " To " + " " + _RouteNo + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _aNikBrCode <> _NikBrCode Then
                    If _aNikBrCode = "" Then
                        log_message = " Nik Branch Code : " + _NikBrCode + "." + " "
                    Else
                        log_message = " Nik Branch Code : " + _aNikBrCode + " " + " To " + " " + _NikBrCode + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _aBrAdd1 <> _BrAdd1 Then
                    If _aBrAdd1 = "" Then
                        log_message = " Branch Address 1 : " + _BrAdd1 + "." + " "
                    Else
                        log_message = " Branch Address 1 : " + _aBrAdd1 + " " + " To " + " " + _BrAdd1 + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _aBrAdd2 <> _BrAdd2 Then
                    If _aBrAdd2 = "" Then
                        log_message = " Branch Address 2 : " + _BrAdd2 + "." + " "
                    Else
                        log_message = " Branch Address 2 : " + _aBrAdd2 + " " + " To " + " " + _BrAdd2 + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If
                If _acmbClearZone <> _cmbClearZone Then
                    If _acmbClearZone = "" Then
                        log_message = " Clearing Zone : " + _cmbClearZone + "." + " "
                    Else
                        log_message = " Clearing Zone : " + _acmbClearZone + " " + " To " + " " + _cmbClearZone + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If

                For Each branchInfo As String In BranchList
                    _branchLog += branchInfo
                Next
                _log = " Authorized : Bank Code : " + txtBankCode.Text.ToString() + "." + " " + " Branch Code : " + txtBranchCode.Text.ToString() + "." + " " + _branchLog

                Logger.system_log(_log)

                _branchLog = ""
                BranchList.Clear()

            Else

                If _aLocCode <> _LocCode Then
                    If _aLocCode = "" Then
                        log_message = " Location Code : " + _LocCode + "." + " "
                    Else
                        log_message = " Location Code : " + _aLocCode + " " + " To " + " " + _LocCode + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If

                If _aBranchName <> _BranchName Then
                    If _aBranchName = "" Then
                        log_message = " Branch Name : " + _BranchName + "." + " "
                    Else
                        log_message = " Branch Name : " + _aBranchName + " " + " To " + " " + _BranchName + "." + " "
                    End If
                    BranchList.Add(log_message)
                End If

                If _aRouteNo <> _RouteNo Then
                    If _aRouteNo = "" Then
                        'log_message = " Routing No : " + _RouteNo + "." + " "
                    Else
                        log_message = " Routing No : " + _aRouteNo + " " + " To " + " " + _RouteNo + "." + " "
                        BranchList.Add(log_message)
                    End If

                End If
                If _aNikBrCode <> _NikBrCode Then
                    If _aNikBrCode = "" Then
                        'log_message = " Nik Branch Code : " + _NikBrCode + "." + " "
                    Else
                        log_message = " Nik Branch Code : " + _aNikBrCode + " " + " To " + " " + _NikBrCode + "." + " "
                        BranchList.Add(log_message)
                    End If

                End If
                If _aBrAdd1 <> _BrAdd1 Then
                    If _aBrAdd1 = "" Then
                        ' log_message = " Branch Address 1 : " + _BrAdd1 + "." + " "
                    Else
                        log_message = " Branch Address 1 : " + _aBrAdd1 + " " + " To " + " " + _BrAdd1 + "." + " "
                        BranchList.Add(log_message)
                    End If

                End If
                If _aBrAdd2 <> _BrAdd2 Then
                    If _aBrAdd2 = "" Then
                        'log_message = " Branch Address 2 : " + _BrAdd2 + "." + " "
                    Else
                        log_message = " Branch Address 2 : " + _aBrAdd2 + " " + " To " + " " + _BrAdd2 + "." + " "
                        BranchList.Add(log_message)
                    End If

                End If
                If _acmbClearZone <> _cmbClearZone Then
                    If _acmbClearZone = "" Then
                        'log_message = " Clearing Zone : " + _cmbClearZone + "." + " "
                    Else
                        log_message = " Clearing Zone : " + _acmbClearZone + " " + " To " + " " + _cmbClearZone + "." + " "
                        BranchList.Add(log_message)
                    End If

                End If

                For Each branchInfo As String In BranchList
                    _branchLog += branchInfo
                Next
                _log = " Authorized : Bank Code : " + txtBankCode.Text.ToString() + "." + " " + " Branch Code : " + txtBranchCode.Text.ToString() + "." + " " + _branchLog

                Logger.system_log(_log)

                _branchLog = ""
                BranchList.Clear()

            End If
            '------------Mizan Work (11-05-2016)------------


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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
        db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, _strBranch_Code)
        db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
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




    Private Sub FrmBranchDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        CommonUtil.FillComboBox("CMS_Zone_GetList", cmbClearingZone)

        If _intModno > 0 Then
            LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno)
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



        If Not (_strBranch_Code.Trim() = "") Then

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


            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim().ToUpper() = CommonAppSet.User.ToUpper()) Then
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

        If txtBankCode.Enabled = True Then
            txtBankCode.Focus()
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

                        LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno)

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
        LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno)

                    DisableAuth()

                    If _strBranch_Code = "" Then

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
            LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strBankCode As String = _strBank_Code
        Dim strBranchCode As String = _strBranch_Code
        Dim strLocationCode As String = _strLocation_Code 
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno + 1)

            If _intModno = 0 Then
                LoadBranchData(strBankCode, strBranchCode, strLocationCode, intModno)
            End If
        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadBranchDataForAuth(_strBank_Code, _strBranch_Code, _strLocation_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadBranchData(_strBank_Code, _strBranch_Code, _strLocation_Code, _intModno)
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

   
    Private Sub btnSearchBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBank.Click
        Dim frmList As New FrmList()
        frmList.Text = "Bank List"
        frmList.ProcName = "CMS_Bank_GetList"

        frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}

        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblBankName.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

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

    End Sub

    Private Sub txtBankCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBankCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBankCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank List"
                frmList.ProcName = "CMS_Bank_GetList"
                frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblBankName.Text = frmList.RowResult.Cells(1).Value.ToString()

                    SendKeys.Send("{tab}")
                    SendKeys.Send("{tab}")
                End If

                frmList.Dispose()

            Else


                Try



                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                        SendKeys.Send("{tab}")
                        SendKeys.Send("{tab}")
                    Else
                        txtBankCode.Clear()
                        lblBankName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If
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

                    SendKeys.Send("{tab}")
                    SendKeys.Send("{tab}")
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
                        SendKeys.Send("{tab}")
                        SendKeys.Send("{tab}")
                    Else
                        txtLocationCode.Clear()
                        lblLocationName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If
        End If
    End Sub

    Private Sub txtBranchCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBranchCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBranchName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBranchName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtRoutingNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRoutingNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtNikBranchCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNikBranchCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAdd1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdd1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAdd2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdd2.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class