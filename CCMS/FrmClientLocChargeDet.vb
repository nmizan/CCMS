'
' Maintain Client Location wise charge Information
' Author: Iftekharul Alam Khan Lodi
' Since: 22-Nov-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClientLocChargeDet


#Region "Global Variables"

    'Dim _formName As String = "MaintenanceClientLocationChargeDetail"
    'Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strClient_Code As String = ""
    Dim _strLocation_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _flagClientLock As Boolean = False
    Dim log_message As String = ""

    'For Update
    Dim _CashCreditDays As String = ""
    Dim _SpeedCreditDays As String = ""
    Dim _CashCharge As String = ""
    Dim _SpeedCharge As String = ""

    'For Auth
    Dim _aCashCreditDays As String = ""
    Dim _aSpeedCreditDays As String = ""
    Dim _aCashCharge As String = ""
    Dim _aSpeedCharge As String = ""

    Dim ClientList As New List(Of String)
    Dim _clientLog As String = ""
    Dim _log As String = ""

#End Region

#Region "User defined Codes"


    Private Sub EnableUnlock()
        btnUnlock.Enabled = True
    End Sub

    Private Sub DisableUnlock()
        btnUnlock.Enabled = False
    End Sub

    Private Sub EnableNew()
         btnNew.Enabled = True
    End Sub

    Private Sub DisableNew()
        btnNew.Enabled = False
    End Sub

    Private Sub EnableSave()
        btnSave.Enabled = True
    End Sub

    Private Sub DisableSave()
        btnSave.Enabled = False
    End Sub

    Private Sub EnableDelete()
         btnDelete.Enabled = True
    End Sub

    Private Sub DisableDelete()
        btnDelete.Enabled = False
    End Sub

    Private Sub EnableAuth()
        btnAuthorize.Enabled = True
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
        btnSearchClient.Enabled = False
        txtLocationCode.ReadOnly = True
        btnSearchLocation.Enabled = False
        txtCashDays.ReadOnly = True
        txtSpeedDays.ReadOnly = True
        txtCashCharge.ReadOnly = True
        txtSpeedCharge.ReadOnly = True
        

    End Sub

    Private Sub EnableFields()

        If _flagClientLock = False Then
            txtClientCode.ReadOnly = False
            btnSearchClient.Enabled = True
        End If

        If txtLocationCode.Text.Trim() = "" Then
            txtLocationCode.ReadOnly = False
            btnSearchLocation.Enabled = True

        End If

        txtCashDays.ReadOnly = False
        txtSpeedDays.ReadOnly = False
        txtCashCharge.ReadOnly = False
        txtSpeedCharge.ReadOnly = False



    End Sub


    Private Sub ClearFields()

        If txtClientCode.ReadOnly = False Then
            txtClientCode.Clear()
            lblAccName.Text = ""
            lblAccNo.Text = ""

        End If

        If txtLocationCode.ReadOnly = False Then
            txtLocationCode.Clear()
            lblLocationName.Text = ""
           
        End If

        
        txtCashDays.Clear()
        txtSpeedDays.Clear()
        txtCashCharge.Clear()
        txtSpeedCharge.Clear()
        

    End Sub

    Private Sub ClearFieldsAll()
        If (_flagClientLock = False) Then
            txtClientCode.Clear()
            lblAccNo.Text = ""
            lblAccName.Text = ""

            _strClient_Code = ""
        End If
        
        txtLocationCode.Clear()
        lblLocationName.Text = ""

        txtCashDays.Clear()
        txtSpeedDays.Clear()
        txtCashCharge.Clear()
        txtSpeedCharge.Clear()
        


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

    Private Sub ClearLocation()
        txtLocationCode.Clear()
        lblLocationName.Text = ""
        _strLocation_Code = ""
    End Sub

    Private Function CheckValidData() As Boolean

        If txtClientCode.Text.Trim() = "" Then
            MessageBox.Show("Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClientCode.Focus()
            Return False
        ElseIf txtLocationCode.Text.Trim() = "" Then
            MessageBox.Show("Location Code required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocationCode.Focus()
            Return False
        
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
            db.AddInParameter(commProc, "@CASH_DAYS", DbType.Int16, NullHelper.ToIntNum(txtCashDays.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_DAYS", DbType.Int16, NullHelper.ToIntNum(txtSpeedDays.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCashCharge.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtSpeedCharge.Text.Trim()))
            

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strClient_Code = txtClientCode.Text.Trim()

                _intModno = 1

                '------------Mizan Work (04-05-2016)------------
                log_message = " Added : Client Code : " + txtClientCode.Text.Trim() + "." + " " + " Location Code : " + txtLocationCode.Text.Trim() + "." + " " + " Account No : " + lblAccNo.Text.ToString()
                Logger.system_log(log_message)
                '------------Mizan Work (04-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If


        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
            db.AddInParameter(commProc, "@CASH_DAYS", DbType.Int16, NullHelper.ToIntNum(txtCashDays.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_DAYS", DbType.Int16, NullHelper.ToIntNum(txtSpeedDays.Text.Trim()))
            db.AddInParameter(commProc, "@CASH_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtCashCharge.Text.Trim()))
            db.AddInParameter(commProc, "@SPEED_CHARGE", DbType.Decimal, NullHelper.ToDecNum(txtSpeedCharge.Text.Trim()))

            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
            db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Update
                _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

                '------------Mizan Work (18-05-2016)------------

                If _CashCreditDays <> txtCashDays.Text.Trim() Then
                    If _CashCreditDays = "" Then
                        log_message = " CitiCash Credit Days : " + txtCashDays.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiCash Credit Days : " + _CashCreditDays + " " + " To " + " " + txtCashDays.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _SpeedCreditDays <> txtSpeedDays.Text.Trim() Then
                    If _SpeedCreditDays = "" Then
                        log_message = " CitiSpeed Credit Days : " + txtSpeedDays.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiSpeed Credit Days : " + _SpeedCreditDays + " " + " To " + " " + txtSpeedDays.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _CashCharge <> txtCashCharge.Text.Trim() Then
                    If _CashCharge = "" Then
                        log_message = " CitiCash Charge : " + txtCashCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiCash Charge : " + _CashCharge + " " + " To " + " " + txtCashCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
               
                If _SpeedCharge <> txtSpeedCharge.Text.Trim() Then
                    If _SpeedCharge = "" Then
                        log_message = " CitiSpeed Charge : " + txtSpeedCharge.Text.Trim() + "." + " "
                    Else
                        log_message = " CitiSpeed Charge : " + _SpeedCharge + " " + " To " + " " + txtSpeedCharge.Text.Trim() + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
               

                For Each clientInfo As String In ClientList
                    _clientLog += clientInfo
                Next
                _log = " Updated : Client Code : " + txtClientCode.Text.ToString() + "." + " " + " Location Code : " + txtLocationCode.Text.ToString() + "." + " " + _clientLog

                Logger.system_log(_log)

                _clientLog = ""
                ClientList.Clear()

                '------------Mizan Work (18-05-2016)------------

        ElseIf result = 1 Then
            tStatus = TransState.UnspecifiedError
        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        End If

        End If

        Return tStatus

    End Function

    '------------Mizan Work (18-05-2016)------------

    Private Sub LoadLocationChargeDataForAuth(ByVal strClientCode As String, ByVal strLocationCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLIENT_LOC_CHARGE Where CLIENT_CODE ='" & strClientCode & "' and LOCATION_CODE ='" & strLocationCode & "' and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _strClient_Code = strClientCode
                _strLocation_Code = strLocationCode
               

              
                txtCashDays.Text = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                _aCashCreditDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()

                txtSpeedDays.Text = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                _aSpeedCreditDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                txtCashCharge.Text = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                _aCashCharge = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                txtSpeedCharge.Text = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()
                _aSpeedCharge = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadLocationChargeData(ByVal strClientCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, strClientCode)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, strLocationCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _strClient_Code = strClientCode
                _strLocation_Code = strLocationCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                txtClientCode.Text = ds.Tables(0).Rows(0)("CLIENT_CODE").ToString()
                lblAccNo.Text = ds.Tables(0).Rows(0)("ACC_NO").ToString()
                lblAccName.Text = ds.Tables(0).Rows(0)("ACC_NAME").ToString()
                txtLocationCode.Text = ds.Tables(0).Rows(0)("LOCATION_CODE").ToString()
                lblLocationName.Text = ds.Tables(0).Rows(0)("LOCATION_NAME").ToString()
                txtCashDays.Text = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                _CashCreditDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()

                txtSpeedDays.Text = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                _SpeedCreditDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                txtCashCharge.Text = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                _CashCharge = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                txtSpeedCharge.Text = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()
                _SpeedCharge = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@CLIENT_CODE", DbType.String, strClientCode)
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

    Public Sub New(ByVal strClientCode As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        _strClient_Code = strClientCode
        _flagClientLock = True


    End Sub

    Public Sub New(ByVal strClientCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'LoadClientData(strClientCode, intMod)

        _strClient_Code = strClientCode
        _strLocation_Code = strLocationCode
        _intModno = intMod
        _flagClientLock = True


    End Sub

   

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
        db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (18-05-2016)------------

            If _intModno > 1 Then

                If _aCashCreditDays <> _CashCreditDays Then
                    If _aCashCreditDays = "" Then
                        log_message = " CitiCash Credit Days : " + _CashCreditDays + "." + " "
                    Else
                        log_message = " CitiCash Credit Days : " + _aCashCreditDays + " " + " To " + " " + _CashCreditDays + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aSpeedCreditDays <> _SpeedCreditDays Then
                    If _aSpeedCreditDays = "" Then
                        log_message = " CitiSpeed Credit Days : " + _SpeedCreditDays + "." + " "
                    Else
                        log_message = " CitiSpeed Credit Days : " + _aSpeedCreditDays + " " + " To " + " " + _SpeedCreditDays + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If
                If _aCashCharge <> _CashCharge Then
                    If _aCashCharge = "" Then
                        log_message = " CitiCash Charge : " + _CashCharge + "." + " "
                    Else
                        log_message = " CitiCash Charge : " + _aCashCharge + " " + " To " + " " + _CashCharge + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If

                If _aSpeedCharge <> _SpeedCharge Then
                    If _aSpeedCharge = "" Then
                        log_message = " CitiSpeed Charge : " + _SpeedCharge + "." + " "
                    Else
                        log_message = " CitiSpeed Charge : " + _aSpeedCharge + " " + " To " + " " + _SpeedCharge + "." + " "
                    End If
                    ClientList.Add(log_message)
                End If


                For Each clientInfo As String In ClientList
                    _clientLog += clientInfo
                Next
                _log = " Authorized : Client Code : " + txtClientCode.Text.ToString() + "." + " " + " Location Code : " + txtLocationCode.Text.ToString() + "." + " " + _clientLog

                Logger.system_log(_log)

                _clientLog = ""
                ClientList.Clear()

            Else

                _log = " Authorized : Client Code : " + txtClientCode.Text.ToString() + "." + " " + " Location Code : " + txtLocationCode.Text.ToString()

                Logger.system_log(_log)

            End If
            '------------Mizan Work (18-05-2016)------------

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)
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

    Private Sub LoadClientInfo(ByVal strClientCode)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, strClientCode)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                txtClientCode.Text = dt.Rows(0)("CLIENT_CODE").ToString()
                lblAccNo.Text = dt.Rows(0)("ACC_NO").ToString()
                lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

            Else

                ClearFieldsAll()

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadLocationInfo(ByVal strClientCode As String, ByVal strLocationCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, strLocationCode)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            ClearFieldsAll()

            If dt.Rows.Count > 0 Then

                _formMode = FormTransMode.Add

                txtLocationCode.Text = dt.Rows(0)("LOCATION_CODE").ToString()
                lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()

                _strLocation_Code = dt.Rows(0)("LOCATION_CODE").ToString()

                Dim commProcMax As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_GetMaxMod")

                commProcMax.Parameters.Clear()

                db.AddInParameter(commProcMax, "@CLIENT_CODE", DbType.String, strClientCode)
                db.AddInParameter(commProcMax, "@LOCATION_CODE", DbType.String, strLocationCode)
                Dim intMod As Integer = db.ExecuteDataSet(commProcMax).Tables(0).Rows(0)(0)
                If intMod > 0 Then
                    LoadLocationChargeData(_strClient_Code, _strLocation_Code, intMod)
                Else
                    'ClearFieldsAll()


                    'ClearFields()

                    'LoadGroupList(dt.Rows(0)("DEPT_SLNO"))
                End If

            Else

                'ClearLocation()
                'ClearFieldsAll()


            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub



#End Region



    Private Sub FrmClientDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        If _intModno > 0 Then
            LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno)
        End If

        If _intModno = 0 Then
            LoadClientInfo(_strClient_Code)
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

                        LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno)

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
        LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno)

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
            LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strClientCode As String = _strClient_Code
        Dim strLocationCode As String = _strLocation_Code
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno + 1)

            If _intModno = 0 Then
                LoadLocationChargeData(strClientCode, strLocationCode, intModno)
            End If
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadLocationChargeDataForAuth(_strClient_Code, _strLocation_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadLocationChargeData(_strClient_Code, _strLocation_Code, _intModno)
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

   
    Private Sub btnSearchClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClient.Click
        If Not (txtClientCode.Text.Trim() = "") Then
            LoadClientInfo(txtClientCode.Text.Trim())
        End If
    End Sub

    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLocation.Click

        If Not (txtLocationCode.Text.Trim() = "" Or _strClient_Code = "") Then
            LoadLocationInfo(_strClient_Code, txtLocationCode.Text.Trim())

        ElseIf Not _strClient_Code = "" Then
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

                LoadLocationInfo(_strClient_Code, txtLocationCode.Text.Trim())
            End If

            frmList.Dispose()


        End If


        
    End Sub

    Private Sub txtLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not (txtLocationCode.Text.Trim() = "" Or _strClient_Code = "") Then
                LoadLocationInfo(_strClient_Code, txtLocationCode.Text.Trim())

            ElseIf Not _strClient_Code = "" Then
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

                    LoadLocationInfo(_strClient_Code, txtLocationCode.Text.Trim())
                End If

                frmList.Dispose()


            End If


        End If
    End Sub
End Class