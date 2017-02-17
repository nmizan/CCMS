'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Bank Detail
'Creation date      : 11-Nov-2012
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmBankDet

#Region "Global Variables"

    Dim _formName As String = "MaintenanceBankDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strBank_Code As String = ""
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

    'For Update
    Dim _bbkCode As String = ""
    Dim _bankName As String = ""
    Dim _accNo As String = ""
    Dim _HOadd1 As String = ""
    Dim _HOadd2 As String = ""
    Dim _HOadd3 As String = ""

    'For Auth
    Dim _abbkCode As String = ""
    Dim _abankName As String = ""
    Dim _aaccNo As String = ""
    Dim _aHOadd1 As String = ""
    Dim _aHOadd2 As String = ""
    Dim _aHOadd3 As String = ""


    Dim BankList As New List(Of String)
    Dim _bankLog As String = ""
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
        txtId.ReadOnly = True
        txtName.ReadOnly = True
        txtBBKCode.ReadOnly = True
        txtAccNo.ReadOnly = True
        txtAdd1.ReadOnly = True
        txtAdd2.ReadOnly = True
        txtAdd3.ReadOnly = True
    End Sub

    Private Sub EnableFields()
        If txtId.Text.Trim() = "" Then
            txtId.ReadOnly = False
        End If

        txtName.ReadOnly = False
        txtBBKCode.ReadOnly = False
        txtAccNo.ReadOnly = False
        txtAdd1.ReadOnly = False
        txtAdd2.ReadOnly = False
        txtAdd3.ReadOnly = False

    End Sub


    Private Sub ClearFields()
        If txtId.ReadOnly = False Then
            txtId.Clear()
        End If

        txtName.Clear()
        txtBBKCode.Clear()
        txtAccNo.Clear()
        txtAdd1.Clear()
        txtAdd2.Clear()
        txtAdd3.Clear()
    End Sub

    Private Sub ClearFieldsAll()
        txtId.Clear()
        txtName.Clear()
        txtBBKCode.Clear()
        txtAccNo.Clear()
        txtAdd1.Clear()
        txtAdd2.Clear()
        txtAdd3.Clear()


        _strBank_Code = ""
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
            MessageBox.Show("Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtId.Focus()
            Return False
        ElseIf txtName.Text.Trim() = "" Then
            MessageBox.Show("Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtName.Focus()
            Return False
        ElseIf txtAccNo.Text.Trim() = "" Then
            MessageBox.Show("ACC No required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccNo.Focus()
            Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState

        
        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_Add")

            commProc.Parameters.Clear()
            
            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtId.Text.Trim())
            db.AddInParameter(commProc, "@BANK_NAME", DbType.String, txtName.Text.Trim())
            db.AddInParameter(commProc, "@HEAD_ADD1", DbType.String, txtAdd1.Text.Trim())
            db.AddInParameter(commProc, "@HEAD_ADD2", DbType.String, txtAdd2.Text.Trim())
            db.AddInParameter(commProc, "@HEAD_ADD3", DbType.String, txtAdd3.Text.Trim())
            db.AddInParameter(commProc, "@BANK_BBK_CODE", DbType.String, txtBBKCode.Text.Trim())
            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strBank_Code = txtId.Text.Trim()

                _intModno = 1

                '------------Mizan Work (07-05-2016)------------
                log_message = " Added : Bank Code : " + txtId.Text.Trim() + "." + " " + " Bank Name : " + txtName.Text.ToString()
                Logger.system_log(log_message)
                '------------Mizan Work (07-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If

           

        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtId.Text.Trim())
            db.AddInParameter(commProc, "@BANK_NAME", DbType.String, txtName.Text.Trim())
            db.AddInParameter(commProc, "@HEAD_ADD1", DbType.String, txtAdd1.Text.Trim())
            db.AddInParameter(commProc, "@HEAD_ADD2", DbType.String, txtAdd2.Text.Trim())
            db.AddInParameter(commProc, "@HEAD_ADD3", DbType.String, txtAdd3.Text.Trim())
            db.AddInParameter(commProc, "@BANK_BBK_CODE", DbType.String, txtBBKCode.Text.Trim())
            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
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
                If _bankName <> txtName.Text.Trim() Then
                    log_message = " Bank Name : " + _bankName + " " + " To " + " " + txtName.Text.Trim() + "." + " "
                    BankList.Add(log_message)
                End If

                If _accNo <> txtAccNo.Text.Trim() Then
                    log_message = " Account No : " + _accNo + " " + " To " + " " + txtAccNo.Text.Trim() + "." + " "
                    BankList.Add(log_message)
                End If

                If _bbkCode <> txtBBKCode.Text.Trim() Then
                    If _bbkCode = "" Then
                        log_message = " BBK Code : " + txtBBKCode.Text.Trim() + "." + " "
                    Else
                        log_message = " BBK Code : " + _bbkCode + " " + " To " + " " + txtBBKCode.Text.Trim() + "." + " "
                    End If
                    BankList.Add(log_message)
                End If
                If _HOadd1 <> txtAdd1.Text.Trim() Then
                    If _HOadd1 = "" Then
                        log_message = " Head Office Address 1 : " + txtAdd1.Text.Trim() + "." + " "
                    Else
                        log_message = " Head Office Address 1 : " + _HOadd1 + " " + " To " + " " + txtAdd1.Text.Trim() + "." + " "
                    End If
                    BankList.Add(log_message)
                End If
                If _HOadd2 <> txtAdd2.Text.Trim() Then
                    If _HOadd2 = "" Then
                        log_message = " Head Office Address 2 : " + txtAdd2.Text.Trim() + "." + " "
                    Else
                        log_message = " Head Office Address 2 : " + _HOadd2 + " " + " To " + " " + txtAdd2.Text.Trim() + "." + " "
                    End If
                    BankList.Add(log_message)
                End If
                If _HOadd3 <> txtAdd3.Text.Trim() Then
                    If _HOadd3 = "" Then
                        log_message = " Head Office Address 3 : " + txtAdd3.Text.Trim() + "." + " "
                    Else
                        log_message = " Head Office Address 3 : " + _HOadd3 + " " + " To " + " " + txtAdd3.Text.Trim() + "." + " "
                    End If
                    BankList.Add(log_message)
                End If

                For Each bankInfo As String In BankList
                    _bankLog += bankInfo
                Next
                _log = " Updated : Bank Code : " + txtId.Text.ToString() + "." + " " + _bankLog

                Logger.system_log(_log)

                _bankLog = ""
                BankList.Clear()

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

    Private Sub LoadBankDataForAuth(ByVal strBankCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From BANK Where BANK_CODE ='" & strBankCode & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _strBank_Code = strBankCode
               
                txtId.Text = ds.Tables(0).Rows(0)("BANK_CODE").ToString()
                txtName.Text = ds.Tables(0).Rows(0)("BANK_NAME").ToString()
                _abankName = ds.Tables(0).Rows(0)("BANK_NAME").ToString()
                txtAdd1.Text = ds.Tables(0).Rows(0)("HEAD_ADD1").ToString()
                _aHOadd1 = ds.Tables(0).Rows(0)("HEAD_ADD1").ToString()
                txtAdd2.Text = ds.Tables(0).Rows(0)("HEAD_ADD2").ToString()
                _aHOadd2 = ds.Tables(0).Rows(0)("HEAD_ADD2").ToString()
                txtAdd3.Text = ds.Tables(0).Rows(0)("HEAD_ADD3").ToString()
                _aHOadd3 = ds.Tables(0).Rows(0)("HEAD_ADD3").ToString()
                txtBBKCode.Text = ds.Tables(0).Rows(0)("BANK_BBK_CODE").ToString()
                _abbkCode = ds.Tables(0).Rows(0)("BANK_BBK_CODE").ToString()
                txtAccNo.Text = ds.Tables(0).Rows(0)("ACC_NO").ToString()
                _aaccNo = ds.Tables(0).Rows(0)("ACC_NO").ToString()

              
              
            Else

            ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadBankData(ByVal strBankCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, strBankCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _strBank_Code = strBankCode
                _intModno = intMod

                _formMode = FormTransMode.Update


                txtId.Text = ds.Tables(0).Rows(0)("BANK_CODE").ToString()
                txtName.Text = ds.Tables(0).Rows(0)("BANK_NAME").ToString()
                _bankName = ds.Tables(0).Rows(0)("BANK_NAME").ToString()
                txtAdd1.Text = ds.Tables(0).Rows(0)("HEAD_ADD1").ToString()
                _HOadd1 = ds.Tables(0).Rows(0)("HEAD_ADD1").ToString()
                txtAdd2.Text = ds.Tables(0).Rows(0)("HEAD_ADD2").ToString()
                _HOadd2 = ds.Tables(0).Rows(0)("HEAD_ADD2").ToString()
                txtAdd3.Text = ds.Tables(0).Rows(0)("HEAD_ADD3").ToString()
                _HOadd3 = ds.Tables(0).Rows(0)("HEAD_ADD3").ToString()
                txtBBKCode.Text = ds.Tables(0).Rows(0)("BANK_BBK_CODE").ToString()
                _bbkCode = ds.Tables(0).Rows(0)("BANK_BBK_CODE").ToString()
                txtAccNo.Text = ds.Tables(0).Rows(0)("ACC_NO").ToString()
                _accNo = ds.Tables(0).Rows(0)("ACC_NO").ToString()

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@BANK_CODE", DbType.String, strBankCode)

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

    Public Sub New(ByVal strBankCode As String, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadBankData(strBankCode, intMod)
        _strBank_Code = strBankCode
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
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

                If _abankName <> _bankName Then
                    log_message = " Bank Name : " + _abankName + " " + " To " + " " + _bankName + "." + " "
                    BankList.Add(log_message)
                End If

                If _aaccNo <> _accNo Then
                    log_message = " Account No : " + _aaccNo + " " + " To " + " " + _accNo + "." + " "
                    BankList.Add(log_message)
                End If

                If _abbkCode <> _bbkCode Then
                    If _abbkCode = "" Then
                        log_message = " BBK Code : " + _bbkCode + "." + " "
                    Else
                        log_message = " BBK Code : " + _abbkCode + " " + " To " + " " + _bbkCode + "." + " "
                    End If
                    BankList.Add(log_message)
                End If
                If _aHOadd1 <> _HOadd1 Then
                    If _aHOadd1 = "" Then
                        log_message = " Head Office Address 1 : " + _HOadd1 + "." + " "
                    Else
                        log_message = " Head Office Address 1 : " + _aHOadd1 + " " + " To " + " " + _HOadd1 + "." + " "
                    End If
                    BankList.Add(log_message)
                End If
                If _aHOadd2 <> _HOadd2 Then
                    If _aHOadd2 = "" Then
                        log_message = " Head Office Address 2 : " + _HOadd2 + "." + " "
                    Else
                        log_message = " Head Office Address 2 : " + _aHOadd2 + " " + " To " + " " + _HOadd2 + "." + " "
                    End If
                    BankList.Add(log_message)
                End If
                If _aHOadd3 <> _HOadd3 Then
                    If _aHOadd3 = "" Then
                        log_message = " Head Office Address 3 : " + _HOadd3 + "." + " "
                    Else
                        log_message = " Head Office Address 3 : " + _aHOadd3 + " " + " To " + " " + _HOadd3 + "." + " "
                    End If
                    BankList.Add(log_message)
                End If

                For Each bankInfo As String In BankList
                    _bankLog += bankInfo
                Next
                _log = " Authorized : Bank Code : " + txtId.Text.ToString() + "." + " " + _bankLog

                Logger.system_log(_log)

                _bankLog = ""
                BankList.Clear()

            Else

                If _abankName <> _bankName Then
                    If _abankName = "" Then
                        log_message = " Bank Name : " + _bankName + "." + " "
                    Else
                        log_message = " Bank Name : " + _abankName + " " + " To " + " " + _bankName + "." + " "
                    End If

                    BankList.Add(log_message)
                End If

                If _aaccNo <> _accNo Then
                    If _aaccNo = "" Then
                        log_message = " Account No : " + _accNo + "." + " "
                    Else
                        log_message = " Account No : " + _aaccNo + " " + " To " + " " + _accNo + "." + " "
                    End If

                    BankList.Add(log_message)
                End If

                For Each bankInfo As String In BankList
                    _bankLog += bankInfo
                Next
                _log = " Authorized : Bank Code : " + txtId.Text.ToString() + "." + " " + _bankLog

                Logger.system_log(_log)

                _bankLog = ""
                BankList.Clear()

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, _strBank_Code)
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



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        LoadBankData(_strBank_Code, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadBankData(_strBank_Code, _intModno)

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

    Private Sub FrmBankDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        If _intModno > 0 Then
            LoadBankData(_strBank_Code, _intModno)
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



        If Not (_strBank_Code.Trim() = "") Then

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

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadBankData(_strBank_Code, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadBankData(_strBank_Code, _intModno)

                    DisableAuth()

                    If _strBank_Code = "" Then

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
            LoadBankData(_strBank_Code, _intModno - 1)
        End If

      
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strBankCode As String = _strBank_Code
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadBankData(_strBank_Code, _intModno + 1)

            If _intModno = 0 Then
                LoadBankData(strBankCode, intModno)
            End If
        End If




    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadBankDataForAuth(_strBank_Code)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadBankData(_strBank_Code, _intModno)
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