'
' Maintain Branch Information
' Author: Iftekharul Alam Khan Lodi
' Since: 27-Nov-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmScheduleStockDet


#Region "Global Variables"

    Dim _formName As String = "MaintenanceScheduleStockDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _intSchedule As Integer = 0
    Dim _strBank_Code As String = ""
    Dim _strLocation_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

    'For Update
    Dim _SchdFrom As String = ""
    Dim _SchdTo As String = ""
    
    'For Auth
    Dim _aSchdFrom As String = ""
    Dim _aSchdTo As String = ""

    Dim StockList As New List(Of String)
    Dim _StockLog As String = ""
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
        cmbSchedule.Enabled = False
        txtBankCode.ReadOnly = True
        btnSearchBank.Enabled = False
        txtLocationCode.ReadOnly = True
        btnSearchLocation.Enabled = False
        txtScheduleFrom.ReadOnly = True
        txtScheduleTo.ReadOnly = True
        
        

    End Sub

    Private Sub EnableFields()

        If txtBankCode.Text.Trim() = "" Then
            cmbSchedule.Enabled = True
            txtBankCode.ReadOnly = False
            btnSearchBank.Enabled = True
            txtLocationCode.ReadOnly = False
            btnSearchLocation.Enabled = True

        End If

        txtScheduleFrom.ReadOnly = False
        txtScheduleTo.ReadOnly = False
    

    End Sub


    Private Sub ClearFields()
        If txtBankCode.ReadOnly = False Then
            txtBankCode.Clear()
            lblBankName.Text = ""
            txtLocationCode.Clear()
            lblLocationName.Text = ""
        End If

        txtScheduleFrom.Clear()
        txtScheduleTo.Clear()




    End Sub

    Private Sub ClearFieldsAll()


        txtBankCode.Clear()
        lblBankName.Text = ""
        txtLocationCode.Clear()
        lblLocationName.Text = ""


        txtScheduleFrom.Clear()
        txtScheduleTo.Clear()

        _intSchedule = 0
        _strBank_Code = ""
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

        If cmbSchedule.SelectedIndex = -1 Then
            MessageBox.Show("Schedule required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbSchedule.Focus()
            Return False
        ElseIf txtBankCode.Text.Trim() = "" Or _strBank_Code = "" Then
            MessageBox.Show("Bank Code required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBankCode.Focus()
            Return False
        ElseIf txtLocationCode.Text.Trim() = "" Or _strLocation_Code = "" Then
            MessageBox.Show("Location required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLocationCode.Focus()
            Return False
        ElseIf txtScheduleFrom.Text.Trim() = "" Then
            MessageBox.Show("Schedule From required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtScheduleFrom.Focus()
            Return False
        ElseIf txtScheduleTo.Text.Trim() = "" Then
            MessageBox.Show("Schedule To required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtScheduleTo.Focus()
            Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, cmbSchedule.SelectedValue)
            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
            db.AddInParameter(commProc, "@SCHE_FROM", DbType.String, txtScheduleFrom.Text.Trim())
            db.AddInParameter(commProc, "@SCHE_UPTO", DbType.String, txtScheduleTo.Text.Trim())

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _intSchedule = cmbSchedule.SelectedValue

                '_strBank_Code = txtBankCode.Text.Trim()

                '_strLocation_Code = txtLocationCode.Text.Trim()

                _intModno = 1

                '------------Mizan Work (07-05-2016)------------

                log_message = " Added : Bank Code : " + txtBankCode.Text.Trim() + "." + " " + " Location Code : " + txtLocationCode.Text.Trim() + "." + " " + " Schedule For : " + cmbSchedule.Text
                Logger.system_log(log_message)

                '------------Mizan Work (07-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If

           

        ElseIf _formMode = FormTransMode.Update Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, _intSchedule)
            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, _strLocation_Code)
            db.AddInParameter(commProc, "@SCHE_FROM", DbType.String, txtScheduleFrom.Text.Trim())
            db.AddInParameter(commProc, "@SCHE_UPTO", DbType.String, txtScheduleTo.Text.Trim())

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


                If _SchdFrom <> txtScheduleFrom.Text.Trim() Then
                    log_message = " Schedule No From : " + _SchdFrom + " " + " To " + " " + txtScheduleFrom.Text.Trim() + "." + " "
                    StockList.Add(log_message)
                End If
                If _SchdTo <> txtScheduleTo.Text.Trim() Then
                    log_message = " Schedule No Up To  : " + _SchdTo + " " + " To " + " " + txtScheduleTo.Text.Trim() + "." + " "
                    StockList.Add(log_message)
                End If


                For Each stockInfo As String In StockList
                    _StockLog += stockInfo
                Next
                _log = " Updated : Bank Code : " + txtBankCode.Text.Trim() + "." + " " + " Location Code : " + txtLocationCode.Text.Trim() + "." + " " + " Schedule For : " + cmbSchedule.Text + "." + " " + _StockLog

                Logger.system_log(_log)

                _StockLog = ""
                StockList.Clear()

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

    Private Sub LoadScheduleDataForAuth(ByVal intScheduleId As Integer, ByVal strBankCode As String, ByVal strLocationCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From SCHEDULE_STOCK Where SCHEDULE_ID ='" & intScheduleId & "' and BANK_CODE ='" & strBankCode & "' and LOCATION_CODE ='" & strLocationCode & "' and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _intSchedule = intScheduleId
                _strBank_Code = strBankCode
                _strLocation_Code = strLocationCode


                txtScheduleFrom.Text = ds.Tables(0).Rows(0)("SCHE_FROM").ToString()
                _aSchdFrom = ds.Tables(0).Rows(0)("SCHE_FROM").ToString()
                txtScheduleTo.Text = ds.Tables(0).Rows(0)("SCHE_UPTO").ToString()
                _aSchdTo = ds.Tables(0).Rows(0)("SCHE_UPTO").ToString()

            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadScheduleData(ByVal intScheduleId As Integer, ByVal strBankCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, intScheduleId)
            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, strBankCode)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, strLocationCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _intSchedule = intScheduleId
                _strBank_Code = strBankCode
                _strLocation_Code = strLocationCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                cmbSchedule.SelectedValue = ds.Tables(0).Rows(0)("SCHEDULE_ID").ToString()

                txtBankCode.Text = ds.Tables(0).Rows(0)("BANK_CODE").ToString()

                lblBankName.Text = ds.Tables(0).Rows(0)("BANK_NAME").ToString()

                txtLocationCode.Text = ds.Tables(0).Rows(0)("LOCATION_CODE").ToString()

                lblLocationName.Text = ds.Tables(0).Rows(0)("LOCATION_NAME").ToString()

                txtScheduleFrom.Text = ds.Tables(0).Rows(0)("SCHE_FROM").ToString()
                _SchdFrom = ds.Tables(0).Rows(0)("SCHE_FROM").ToString()
                txtScheduleTo.Text = ds.Tables(0).Rows(0)("SCHE_UPTO").ToString()
                _SchdTo = ds.Tables(0).Rows(0)("SCHE_UPTO").ToString()

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@SCHEDULE_ID", DbType.Int32, intScheduleId)
                db.AddInParameter(commProc2, "@BANK_CODE", DbType.String, strBankCode)
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

    Public Sub New(ByVal intScheduleId As Integer, ByVal strBankCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _intSchedule = intScheduleId
        _strBank_Code = strBankCode
        _strLocation_Code = strLocationCode
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, _intSchedule)
        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
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


            If _aSchdFrom <> _SchdFrom Then
                If _aSchdFrom = "" Then
                    log_message = " Schedule No From : " + _SchdFrom + "." + " "
                Else
                    log_message = " Schedule No From : " + _aSchdFrom + " " + " To " + " " + _SchdFrom + "." + " "
                End If
                StockList.Add(log_message)
            End If
            If _aSchdTo <> _SchdTo Then
                If _aSchdTo = "" Then
                    log_message = " Schedule No Up To  : " + _SchdTo + "." + " "
                Else
                    log_message = " Schedule No Up To  : " + _aSchdTo + " " + " To " + " " + _SchdTo + "." + " "
                End If
                StockList.Add(log_message)
            End If


            For Each stockInfo As String In StockList
                _StockLog += stockInfo
            Next
            _log = " Authorized : Schedule ID : " + _intSchedule + "." + " " + " Bank Code : " + txtBankCode.Text.Trim() + "." + " " + " Location Code : " + txtLocationCode.Text.Trim() + "." + " " + " Schedule For : " + cmbSchedule.Text + "." + " " + _StockLog

            Logger.system_log(_log)

            _StockLog = ""
            StockList.Clear()

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ScheduleStock_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, _intSchedule)
        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
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




    Private Sub FrmScheduleStockDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim dt As New DataTable()

        dt.Columns.Add("ID")
        dt.Columns.Add("TYPE")
        Dim dr As DataRow = dt.NewRow()

        dr(0) = "1"
        dr(1) = "Deposit"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "2"
        dr(1) = "Collection"
        dt.Rows.Add(dr)

        cmbSchedule.DataSource = dt
        cmbSchedule.DisplayMember = "TYPE"
        cmbSchedule.ValueMember = "ID"

        If _intModno > 0 Then
            LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno)
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



        If Not (_intModno = 0) Then

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

                        LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno)

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
        LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno)

                    DisableAuth()

                    If _intSchedule = 0 Then

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
            LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno - 1)

        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim intScheduleId As Integer = _intSchedule
        Dim strBankCode As String = _strBank_Code
        Dim strLocationCode As String = _strLocation_Code
        Dim intModno As Integer = _intModno
        If intModno > 0 Then

            LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno + 1)


            If _intModno = 0 Then

                LoadScheduleData(intScheduleId, strBankCode, strLocationCode, intModno)

            End If
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadScheduleDataForAuth(_intSchedule, _strBank_Code, _strLocation_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadScheduleData(_intSchedule, _strBank_Code, _strLocation_Code, _intModno)
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
            _strBank_Code = frmList.RowResult.Cells(0).Value.ToString()
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
                    _strBank_Code = frmList.RowResult.Cells(0).Value.ToString()
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
                        _strBank_Code = dt.Rows(0)("BANK_CODE").ToString()
                    Else
                        txtBankCode.Clear()
                        lblBankName.Text = ""
                        _strBank_Code = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



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
            _strLocation_Code = frmList.RowResult.Cells(0).Value.ToString()
        End If

        frmList.Dispose()

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
                    _strLocation_Code = frmList.RowResult.Cells(0).Value.ToString()
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
                        _strLocation_Code = dt.Rows(0)("LOCATION_CODE")
                    Else
                        txtLocationCode.Clear()
                        lblLocationName.Text = ""
                        _strLocation_Code = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If
        End If
    End Sub
End Class