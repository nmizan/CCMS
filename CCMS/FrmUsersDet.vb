'
' Maintain User Information
' Author: Iftekharul Alam Khan Lodi
' Since: 15-Nov-12
'
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmUsersDet


#Region "Global Variables"

    Dim _formName As String = "SystemUsersDetail"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strUser_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""

    ' -- capture change detail
    Dim _IsUserEnabled As Boolean = False
    Dim _IsAdmin As Boolean = False

    ' --

    Dim log_message As String = ""
    'For Update
    Dim _userName As String = ""
    Dim _deptName As String = ""
    Dim _domain As String = ""
    'For Auth
    Dim _auserName As String = ""
    Dim _adeptName As String = ""
    Dim _adomain As String = ""

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
        txtId.ReadOnly = True
        txtName.ReadOnly = True

        txtDomain.ReadOnly = True

        cmbDept.Enabled = False
        cmbStatus.Enabled = False

    End Sub

    Private Sub EnableFields()
        If txtId.Text.Trim() = "" Then
            txtId.ReadOnly = False
        End If

        txtName.ReadOnly = False

        txtDomain.ReadOnly = False

        cmbDept.Enabled = True
        cmbStatus.Enabled = True


    End Sub


    Private Sub ClearFields()
        If txtId.ReadOnly = False Then
            txtId.Clear()
        End If

        txtName.Clear()

        txtDomain.Clear()
        cmbStatus.Text = ""
        cmbDept.Text = ""

    End Sub

    Private Sub ClearFieldsAll()
        txtId.Clear()
        txtName.Clear()

        txtDomain.Clear()

        cmbDept.Text = ""
        cmbStatus.Text = ""

        chkAdmin.Checked = False


        lblLastLogin.Text = ""


        _strUser_Code = ""
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

        If txtId.Text.Trim() = "" Then
            MessageBox.Show("User Id required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtId.Focus()
            Return False
        ElseIf txtName.Text.Trim() = "" Then
            MessageBox.Show("Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtName.Focus()
            Return False
        ElseIf cmbDept.SelectedIndex = -1 Then
            MessageBox.Show("Department required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbDept.Focus()
            Return False
        ElseIf txtDomain.Text.Trim() = "" Then
            MessageBox.Show("Domain required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDomain.Focus()
            Return False
        ElseIf cmbStatus.Text.Trim() = "" Then
            MessageBox.Show("Status required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStatus.Focus()
            Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@USERS_ID", DbType.String, txtId.Text.Trim())
            db.AddInParameter(commProc, "@USERS_NAME", DbType.String, txtName.Text.Trim())
            db.AddInParameter(commProc, "@DEPT_SLNO", DbType.Int32, cmbDept.SelectedValue)
            db.AddInParameter(commProc, "@DOMAIN", DbType.String, txtDomain.Text.Trim())
            db.AddInParameter(commProc, "@USER_STAT", DbType.String, cmbStatus.Text.First)
            db.AddInParameter(commProc, "@IS_ADMIN", SqlDbType.Bit, chkAdmin.Checked)


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strUser_Code = txtId.Text.Trim()

                _intModno = 1

                'Dim extraLog As String = ""
                'If _IsAdmin = True Then
                '    extraLog = "[Admin]"
                'End If
                'Logger.system_log("User Id:" + txtId.Text.ToString() + ", User Name:" + txtName.Text.ToString() + " Added")

                '------------Mizan Work (08-05-2016)------------

                log_message = " Added : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + txtName.Text.ToString() + "." + " " + " Department : " + cmbDept.Text()
                Logger.system_log(log_message)

                '------------Mizan Work (08-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If


        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@USERS_ID", DbType.String, txtId.Text.Trim())
            db.AddInParameter(commProc, "@USERS_NAME", DbType.String, txtName.Text.Trim())
            db.AddInParameter(commProc, "@DEPT_SLNO", DbType.Int32, cmbDept.SelectedValue)
            db.AddInParameter(commProc, "@DOMAIN", DbType.String, txtDomain.Text.Trim())
            db.AddInParameter(commProc, "@USER_STAT", DbType.String, cmbStatus.Text.First)
            db.AddInParameter(commProc, "@IS_ADMIN", SqlDbType.Bit, chkAdmin.Checked)

            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
            db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)


            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Update
                _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

                '----------Mizan Work (08-05-2016)---------------

                If _userName <> txtName.Text.Trim() And _domain <> txtDomain.Text.Trim() And _deptName <> cmbDept.Text Then
                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + " " + " To " + " " + txtName.Text.ToString() + "." + " " + " Department : " + _deptName + " " + " To " + " " + cmbDept.Text + "." + " " + " Domain : " + _domain + " " + " To " + " " + txtDomain.Text.ToString()

                ElseIf _userName <> txtName.Text.Trim() And _domain <> txtDomain.Text.Trim() Then
                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + " " + " To " + " " + txtName.Text.ToString() + "." + " " + " Domain : " + _domain + " " + " To " + " " + txtDomain.Text.ToString()

                ElseIf _userName <> txtName.Text.Trim() And _deptName <> cmbDept.Text Then
                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + " " + " To " + " " + txtName.Text.ToString() + "." + " " + " Department : " + _deptName + " " + " To " + " " + cmbDept.Text

                ElseIf _domain <> txtDomain.Text.Trim() And _deptName <> cmbDept.Text Then
                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " Domain : " + _domain + " " + " To " + " " + txtDomain.Text.ToString() + "." + " " + " Department : " + _deptName + " " + " To " + " " + cmbDept.Text

                ElseIf _userName <> txtName.Text.Trim() Then
                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + " " + " To " + " " + txtName.Text.ToString()

                ElseIf _deptName <> cmbDept.Text Then

                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " Department : " + _deptName + " " + " To " + " " + cmbDept.Text

                ElseIf _domain <> txtDomain.Text.Trim() Then
                    log_message = " Updated : User Id : " + txtId.Text.ToString() + "." + " " + " Domain : " + _domain + " " + " To " + " " + txtDomain.Text.ToString()

                Else
                    log_message = " Updated : User Id : " + txtId.Text.ToString()

                End If

                Logger.system_log(log_message)

                '----------Mizan Work (08-05-2016)---------------

                ' Logger.system_log("Update User Id:" + txtId.Text.ToString() + ", User Name:" + txtName.Text.ToString() + " Updated")

            ElseIf result = 1 Then
                tStatus = TransState.UnspecifiedError
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            End If

        End If

        Return tStatus

    End Function

    '----------Mizan Work (17-05-2016)---------------

    Private Sub LoadUsersDataForAuth(ByVal strUsersCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From USERS  Where USERS_ID ='" & strUsersCode & "' and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _strUser_Code = strUsersCode

                txtId.Text = ds.Tables(0).Rows(0)("USERS_ID").ToString()
                txtName.Text = ds.Tables(0).Rows(0)("USERS_NAME").ToString()
                _auserName = ds.Tables(0).Rows(0)("USERS_NAME").ToString()

                cmbDept.SelectedValue = ds.Tables(0).Rows(0)("DEPT_SLNO")
                _adeptName = ds.Tables(0).Rows(0)("DEPT_SLNO")

                txtDomain.Text = ds.Tables(0).Rows(0)("DOMAIN").ToString()
                _adomain = ds.Tables(0).Rows(0)("DOMAIN").ToString()


                '--------------Mizan Work (17-05-2016---------
                Dim ds2 As New DataSet
                ds2 = db.ExecuteDataSet(CommandType.Text, "Select *  From DEPARTMENT Where SLNO ='" & _adeptName & "' ")
                If ds2.Tables(0).Rows.Count > 0 Then

                    _adeptName = ds2.Tables(0).Rows(0)("DEPT_NAME").ToString()

                End If
                '--------------Mizan Work (17-05-2016---------


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadUsersData(ByVal strUsersCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@USERS_ID", DbType.String, strUsersCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _strUser_Code = strUsersCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                '---- capture change detail ---

                _IsAdmin = NullHelper.ToBool(ds.Tables(0).Rows(0)("IS_ADMIN"))

                If ds.Tables(0).Rows(0)("USER_STAT") = "D" Then
                    _IsUserEnabled = False
                ElseIf ds.Tables(0).Rows(0)("USER_STAT") = "E" Then
                    _IsUserEnabled = True
                End If



                '-----------------------------


                txtId.Text = ds.Tables(0).Rows(0)("USERS_ID").ToString()
                txtName.Text = ds.Tables(0).Rows(0)("USERS_NAME").ToString()
                _userName = ds.Tables(0).Rows(0)("USERS_NAME").ToString()

                cmbDept.SelectedValue = ds.Tables(0).Rows(0)("DEPT_SLNO")
                _deptName = ds.Tables(0).Rows(0)("DEPT_SLNO")

                If ds.Tables(0).Rows(0)("USER_STAT") = "D" Then
                    cmbStatus.Text = "Disable"
                ElseIf ds.Tables(0).Rows(0)("USER_STAT") = "E" Then
                    cmbStatus.Text = "Enable"
                End If

                txtDomain.Text = ds.Tables(0).Rows(0)("DOMAIN").ToString()
                _domain = ds.Tables(0).Rows(0)("DOMAIN").ToString()
                lblLastLogin.Text = ds.Tables(0).Rows(0)("LAST_LOGIN_DATE").ToString()
                chkAdmin.Checked = NullHelper.ToBool(ds.Tables(0).Rows(0)("IS_ADMIN"))


                '--------------Mizan Work (08-05-2016---------
                Dim ds2 As New DataSet
                ds2 = db.ExecuteDataSet(CommandType.Text, "Select *  From DEPARTMENT Where SLNO ='" & _deptName & "' ")
                If ds2.Tables(0).Rows.Count > 0 Then

                    _deptName = ds2.Tables(0).Rows(0)("DEPT_NAME").ToString()

                End If
                '--------------Mizan Work (08-05-2016---------

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Users_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@USERS_ID", DbType.String, strUsersCode)

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


                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim.ToUpper() = CommonAppSet.User.ToUpper()) Then
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

    Public Sub New(ByVal strUsersCode As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadUsersData(strUsersCode, intMod)
        _strUser_Code = strUsersCode
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@USERS_ID", DbType.String, _strUser_Code)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '----------Mizan Work (17-05-2016)---------------

            If _auserName <> _userName And _adomain <> _domain And _adeptName <> _deptName Then
                If _auserName = "" And _adomain = "" And _adeptName = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + "." + " " + " Department : " + _deptName + "." + " " + " Domain : " + _domain
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain
                End If
                Logger.system_log(log_message)

            ElseIf _auserName <> _userName And _adomain <> _domain Then
                If _auserName = "" And _adomain = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + "." + " " + " Domain : " + _domain
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain
                End If
                Logger.system_log(log_message)
            ElseIf _auserName <> _userName And _adeptName <> _deptName Then
                If _auserName = "" And _adeptName = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName + "." + " " + " Department : " + _deptName
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName
                End If
                Logger.system_log(log_message)
            ElseIf _adomain <> _domain And _adeptName <> _deptName Then
                If _adomain = "" And _adeptName = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " Domain : " + _domain + "." + " " + " Department : " + _deptName
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName
                End If

                Logger.system_log(log_message)
            ElseIf _auserName <> _userName Then
                If _auserName = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _userName
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName
                End If
                Logger.system_log(log_message)
            ElseIf _adeptName <> _deptName Then
                If _adeptName = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " Department : " + _deptName
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName
                End If
                Logger.system_log(log_message)
            ElseIf _adomain <> _domain Then
                If _adomain = "" Then
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " Domain : " + _domain
                Else
                    log_message = " Authorized : User Id : " + txtId.Text.ToString() + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain
                End If
                Logger.system_log(log_message)
            Else
                log_message = " Authorized : User Id : " + txtId.Text.ToString()
                Logger.system_log(log_message)
            End If



            '----------Mizan Work (17-05-2016)---------------

            'Logger.system_log("User Id:" + txtId.Text.ToString() + " Authorized")


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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@USERS_ID", DbType.String, _strUser_Code)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Delete
            _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

            Logger.system_log("User Id:" + txtId.Text.ToString() + " mark as deleted")


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



    Private Sub FrmUsersDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        CommonUtil.FillComboBox("CMS_Department_GetList", cmbDept)



        If _intModno > 0 Then
            LoadUsersData(_strUser_Code, _intModno)
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



        If Not (_strUser_Code.Trim() = "") Then

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


            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim.ToUpper() = CommonAppSet.User.ToUpper()) Then
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

        If txtId.Enabled = True Then
            txtId.Focus()
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

                        LoadUsersData(_strUser_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadUsersData(_strUser_Code, _intModno)

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
        LoadUsersData(_strUser_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadUsersData(_strUser_Code, _intModno)

                    DisableAuth()

                    If _strUser_Code = "" Then

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
            LoadUsersData(_strUser_Code, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strUsersCode As String = _strUser_Code
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadUsersData(_strUser_Code, _intModno + 1)

            If _intModno = 0 Then
                LoadUsersData(strUsersCode, intModno)
            End If
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadUsersDataForAuth(_strUser_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadUsersData(_strUser_Code, _intModno)
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