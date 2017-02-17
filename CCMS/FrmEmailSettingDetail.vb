'
'Author             : fahad Khan
'Purpose            : Maintain Email Setting
'Creation date      : 20-Nov-2014
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmEmailSettingDetail

#Region "Global Variables"

    Dim _formName As String = "MaintenanceEmailSettingDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strId As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

    'For Update
    Dim _Host As String = ""
    Dim _Port As String = ""
    Dim _Email As String = ""
    Dim _Pass As String = ""
    Dim _Sub As String = ""
    Dim _Heading As String = ""
    Dim _Footer As String = ""
   
    'For Auth
    Dim _aHost As String = ""
    Dim _aPort As String = ""
    Dim _aEmail As String = ""
    Dim _aPass As String = ""
    Dim _aSub As String = ""
    Dim _aHeading As String = ""
    Dim _aFooter As String = ""


    Dim EmailList As New List(Of String)
    Dim _emailLog As String = ""
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
       

        txtEmail.ReadOnly = True
        txtFooter.ReadOnly = True
        txtHeading.ReadOnly = True
        txthost.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPortNo.ReadOnly = True
        txtSubject.ReadOnly = True


    End Sub

    Private Sub EnableFields()

        txtEmail.ReadOnly = False
        txtFooter.ReadOnly = False
        txtHeading.ReadOnly = False
        txthost.ReadOnly = False
        txtPassword.ReadOnly = False
        txtPortNo.ReadOnly = False
        txtSubject.ReadOnly = False

    End Sub


    Private Sub ClearFields()
       
        txtEmail.Clear()
        txtFooter.Clear()
        txtHeading.Clear()
        txthost.Clear()
        txtPassword.Clear()
        txtPortNo.Clear()
        txtSubject.Clear()
    End Sub

    Private Sub ClearFieldsAll()
        txtEmail.Clear()
        txtFooter.Clear()
        txtHeading.Clear()
        txthost.Clear()
        txtPassword.Clear()
        txtPortNo.Clear()
        txtSubject.Clear()


        _strId = ""
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

        If txtEmail.Text.Trim() = "" Then
            MessageBox.Show("Email required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmail.Focus()
            Return False
        ElseIf txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Password required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
            Return False

        ElseIf txthost.Text.Trim() = "" Then
            MessageBox.Show("Email Host required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txthost.Focus()
            Return False


        ElseIf txtPortNo.Text.Trim() = "" Then
            MessageBox.Show("Email Port required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPortNo.Focus()
            Return False

        ElseIf txtSubject.Text.Trim() = "" Then
            MessageBox.Show("Email Subject required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSubject.Focus()
            Return False

        ElseIf txtHeading.Text.Trim() = "" Then
            MessageBox.Show("Email Heading required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHeading.Focus()
            Return False

        ElseIf txtFooter.Text.Trim() = "" Then
            MessageBox.Show("Email Footer required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFooter.Focus()
            Return False

        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_Add")

            commProc.Parameters.Clear()

            'HOST, EMAIL, PASSWORD, PORT, SUBJECT, HEADING, END, EMAIL_GROUP, DEFAULT


            db.AddInParameter(commProc, "@HOST", DbType.String, txthost.Text.Trim())
            db.AddInParameter(commProc, "@EMAIL", DbType.String, txtEmail.Text.Trim())
            db.AddInParameter(commProc, "@PASSWORD", DbType.String, SecurePassword.Encrypt(txtPassword.Text.Trim()))
            db.AddInParameter(commProc, "@PORT", DbType.Int32, txtPortNo.Text.Trim())
            db.AddInParameter(commProc, "@SUBJECT", DbType.String, txtSubject.Text.Trim())
            db.AddInParameter(commProc, "@HEADING", DbType.String, txtHeading.Text.Trim())
            db.AddInParameter(commProc, "@END", DbType.String, txtFooter.Text.Trim())
            db.AddInParameter(commProc, "@EMAIL_GROUP", DbType.Int32, 1)

            If chkDefault.Checked = True Then
                db.AddInParameter(commProc, "@DEFAULT", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@DEFAULT", DbType.String, 0)
            End If


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                '_strBank_Code = txtId.Text.Trim()

                _intModno = 1

                '------------Mizan Work (07-05-2016)------------

                log_message = " Added : Email : " + txtEmail.Text.Trim() + "." + " " + " Host : " + txthost.Text.Trim()
                Logger.system_log(log_message)

                '------------Mizan Work (07-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If

           


        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_Update")

            commProc.Parameters.Clear()
            'HOST, EMAIL, PASSWORD, PORT, SUBJECT, HEADING, END, EMAIL_GROUP, DEFAULT
            db.AddInParameter(commProc, "@ID", DbType.Int32, _strId)

            db.AddInParameter(commProc, "@HOST", DbType.String, txthost.Text.Trim())
            db.AddInParameter(commProc, "@EMAIL", DbType.String, txtEmail.Text.Trim())
            db.AddInParameter(commProc, "@PASSWORD", DbType.String, SecurePassword.Encrypt(txtPassword.Text.Trim()))
            db.AddInParameter(commProc, "@PORT", DbType.Int32, txtPortNo.Text.Trim())
            db.AddInParameter(commProc, "@SUBJECT", DbType.String, txtSubject.Text.Trim())
            db.AddInParameter(commProc, "@HEADING", DbType.String, txtHeading.Text.Trim())
            db.AddInParameter(commProc, "@END", DbType.String, txtFooter.Text.Trim())
            db.AddInParameter(commProc, "@EMAIL_GROUP", DbType.Int32, 1)

            If chkDefault.Checked = True Then
                db.AddInParameter(commProc, "@DEFAULT", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@DEFAULT", DbType.String, 0)
            End If

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

                If _Host <> txthost.Text.Trim() Then
                    log_message = " Host : " + _Host + " " + " To " + " " + txthost.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If
                If _Port <> txtPortNo.Text.Trim() Then
                    log_message = " Port No : " + _Port + " " + " To " + " " + txtPortNo.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If
                If _Sub <> txtSubject.Text.Trim() Then
                    log_message = " Email Subject : " + _Sub + " " + " To " + " " + txtSubject.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If
                If _Email <> txtEmail.Text.Trim() Then
                    log_message = " Email : " + _Email + " " + " To " + " " + txtEmail.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If
                If _Pass <> txtPassword.Text.Trim() Then
                    log_message = " Password : " + _Pass + " " + " To " + " " + txtPassword.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If
                If _Heading <> txtHeading.Text.Trim() Then
                    log_message = " Email Heading : " + _Heading + " " + " To " + " " + txtHeading.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If
                If _Footer <> txtFooter.Text.Trim() Then
                    log_message = " Email Footer : " + _Footer + " " + " To " + " " + txtFooter.Text.Trim() + "." + " "
                    EmailList.Add(log_message)
                End If

                For Each emailInfo As String In EmailList
                    _emailLog += emailInfo
                Next
                _log = " Updated : Email ID : " + _strId + "." + " " + _emailLog

                Logger.system_log(_log)

                _emailLog = ""
                EmailList.Clear()
                '------------Mizan Work (07-05-2016)------------
            ElseIf result = 1 Then
                tStatus = TransState.UnspecifiedError
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            End If

            

            End If

            Return tStatus

    End Function

    '------------Mizan Work (14-05-2016)------------
    Private Sub LoadEmailDataForAuth(ByVal strId As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLIENT_MAIL_SETTING Where ID ='" & strId & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _strId = strId
                
                txthost.Text = ds.Tables(0).Rows(0)("HOST").ToString()
                _aHost = ds.Tables(0).Rows(0)("HOST").ToString()
                txtPortNo.Text = ds.Tables(0).Rows(0)("PORT").ToString()
                _aPort = ds.Tables(0).Rows(0)("PORT").ToString()
                txtEmail.Text = ds.Tables(0).Rows(0)("EMAIL").ToString()
                _aEmail = ds.Tables(0).Rows(0)("EMAIL").ToString()
                txtPassword.Text = SecurePassword.Decrypt(ds.Tables(0).Rows(0)("PASSWORD").ToString())
                _aPass = SecurePassword.Decrypt(ds.Tables(0).Rows(0)("PASSWORD").ToString())
                txtSubject.Text = ds.Tables(0).Rows(0)("SUBJECT").ToString()
                _aSub = ds.Tables(0).Rows(0)("SUBJECT").ToString()
                txtHeading.Text = ds.Tables(0).Rows(0)("HEADING").ToString()
                _aHeading = ds.Tables(0).Rows(0)("HEADING").ToString()
                txtFooter.Text = ds.Tables(0).Rows(0)("END").ToString()
                _aFooter = ds.Tables(0).Rows(0)("END").ToString()

                
            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadEmailData(ByVal strId As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ID", DbType.Int32, strId)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _strId = strId
                _intModno = intMod

                _formMode = FormTransMode.Update

                txthost.Text = ds.Tables(0).Rows(0)("HOST").ToString()
                _Host = ds.Tables(0).Rows(0)("HOST").ToString()
                txtPortNo.Text = ds.Tables(0).Rows(0)("PORT").ToString()
                _Port = ds.Tables(0).Rows(0)("PORT").ToString()
                txtEmail.Text = ds.Tables(0).Rows(0)("EMAIL").ToString()
                _Email = ds.Tables(0).Rows(0)("EMAIL").ToString()
                txtPassword.Text = SecurePassword.Decrypt(ds.Tables(0).Rows(0)("PASSWORD").ToString())
                _Pass = SecurePassword.Decrypt(ds.Tables(0).Rows(0)("PASSWORD").ToString())
                txtSubject.Text = ds.Tables(0).Rows(0)("SUBJECT").ToString()
                _Sub = ds.Tables(0).Rows(0)("SUBJECT").ToString()
                txtHeading.Text = ds.Tables(0).Rows(0)("HEADING").ToString()
                _Heading = ds.Tables(0).Rows(0)("HEADING").ToString()
                txtFooter.Text = ds.Tables(0).Rows(0)("END").ToString()
                _Footer = ds.Tables(0).Rows(0)("END").ToString()

                If ds.Tables(0).Rows(0)("DEFAULT").ToString() = "1" Then
                    chkDefault.Checked = True
                Else
                    chkDefault.Checked = False
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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@ID", DbType.String, strId)

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

    Public Sub New(ByVal strId As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadEmailData(strId, intMod)
        _strId = strId
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@ID", DbType.Int32, _strId)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (14-05-2016)------------
            If _intModno > 1 Then

                If _aHost <> _Host Then
                    log_message = " Host : " + _aHost + " " + " To " + " " + _Host + "." + " "
                    EmailList.Add(log_message)
                End If
                If _aPort <> _Port Then
                    log_message = " Port No : " + _aPort + " " + " To " + " " + _Port + "." + " "
                    EmailList.Add(log_message)
                End If
                If _aSub <> _Sub Then
                    log_message = " Email Subject : " + _aSub + " " + " To " + " " + _Sub + "." + " "
                    EmailList.Add(log_message)
                End If
                If _aEmail <> _Email Then
                    log_message = " Email : " + _aEmail + " " + " To " + " " + _Email + "." + " "
                    EmailList.Add(log_message)
                End If
                If _aPass <> _Pass Then
                    log_message = " Password : " + _aPass + " " + " To " + " " + _Pass + "." + " "
                    EmailList.Add(log_message)
                End If
                If _aHeading <> _Heading Then
                    log_message = " Email Heading : " + _aHeading + " " + " To " + " " + _Heading + "." + " "
                    EmailList.Add(log_message)
                End If
                If _aFooter <> _Footer Then
                    log_message = " Email Footer : " + _aFooter + " " + " To " + " " + _Footer + "." + " "
                    EmailList.Add(log_message)
                End If

                For Each emailInfo As String In EmailList
                    _emailLog += emailInfo
                Next
                _log = " Authorized :  Email ID : " + _strId + "." + " " + _emailLog

                Logger.system_log(_log)

                _emailLog = ""
                EmailList.Clear()

            Else

                _log = " Authorized :  Email ID : " + _strId

                Logger.system_log(_log)

            End If
            '------------Mizan Work (14-05-2016)------------

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_Remove")

        commProc.Parameters.Clear()

        'db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
        'db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        'db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

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


    Private Sub FrmEmailSettingDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
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



        If Not (_strId.Trim() = "") Then

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

        txthost.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        'LoadBankData(_strId, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadEmailData(_strId, _intModno)

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
        LoadEmailData(_strId, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click


        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadEmailDataForAuth(_strId)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadEmailData(_strId, _intModno)

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

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevVer.Click
        If _intModno - 1 > 0 Then
            LoadEmailData(_strId, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strId As String = _strId
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadEmailData(_strId, _intModno + 1)

            If _intModno = 0 Then
                LoadEmailData(strId, intModno)
            End If
        End If
    End Sub
End Class