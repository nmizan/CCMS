'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain CitiSpeed Return Detail
'Creation date      : 27-Aug-2013
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmCitiSpeedReturnDet

#Region "Global Variables"

    Dim _formName As String = "CollectionCitiSpeedReturnDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _intModno As Integer = 0
    Dim _strDCode As String = ""
    Dim _intSlno As Integer = 0

    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

    'For Update
    Dim _RetumDate As String = ""
    Dim _Retumcode As String = ""
    'For Auth
    Dim _aRetumDate As String = ""
    Dim _aRetumcode As String = ""


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

   

   

    Private Sub DisableFields()
        txtDepoCode.ReadOnly = True
        txtReturnCode.ReadOnly = True
        txtSlno.ReadOnly = True

        txtReturnDate.ReadOnly = True


      
    End Sub

    Private Sub EnableFields()
        If txtDepoCode.Text.Trim() = "" Then
            txtDepoCode.ReadOnly = False
            txtSlno.ReadOnly = False

        End If

        txtReturnDate.ReadOnly = False

        txtReturnCode.ReadOnly = False


    End Sub


    'Private Sub ClearFields()
    '    If txtId.ReadOnly = False Then
    '        txtId.Clear()
    '    End If

    '    txtName.Clear()
    '    txtBBKCode.Clear()
    '    txtAccNo.Clear()
    '    txtAdd1.Clear()
    '    txtAdd2.Clear()
    '    txtAdd3.Clear()
    'End Sub

    Private Sub ClearFieldsAll()

        txtDepoCode.Clear()
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

        txtTotalAmount.Clear()
        txtTotalCheckNo.Clear()



        txtSlno.Text = ""
        lblCheckNo.Text = ""
        lblAmount.Text = ""
        lblStatus.Text = ""
        txtReturnCode.Clear()
        lblReason.Text = ""


       


        _strDCode = ""
        _intSlno = 0
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

        If lblDepoScheCode.Text.Trim() = "" Then
            MessageBox.Show("Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False
        ElseIf txtSlno.Text.Trim() = "" Or lblCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Sl required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlno.Focus()
            Return False

        ElseIf txtReturnDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Return date required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReturnDate.Focus()
            Return False


        ElseIf txtReturnCode.Text.Trim() = "" Or lblReason.Text.Trim() <> "" Then
            MessageBox.Show("Return code required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReturnCode.Focus()
            Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
            db.AddInParameter(commProc, "@SLNO", DbType.Int32, txtSlno.Text.Trim())
            db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "R")
            db.AddInParameter(commProc, "@RTN_CODE", DbType.String, txtReturnCode.Text.Trim())

            db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, NullHelper.StringToDate(txtReturnDate.Text.Trim()))

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then
                tStatus = TransState.Add

                _strDCode = txtDepoCode.Text.Trim()
                _intSlno = NullHelper.ToIntNum(txtSlno.Text.Trim())

                _intModno = 1

                '------------Mizan Work (08-05-2016)------------

                log_message = " Added : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim()
                Logger.system_log(log_message)

                '------------Mizan Work (08-05-2016)------------

            Else
                tStatus = TransState.Exist
            End If
            
        ElseIf _formMode = FormTransMode.Update Then



            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_Update")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode.Trim())
            db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
            db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "R")
            db.AddInParameter(commProc, "@RTN_CODE", DbType.String, txtReturnCode.Text.Trim())

            db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, NullHelper.StringToDate(txtReturnDate.Text.Trim()))

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
                If _RetumDate <> txtReturnDate.Text.Trim() And _Retumcode <> txtReturnCode.Text.Trim() Then
                    log_message = " Updated : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Date : " + _RetumDate + " " + " To " + " " + txtReturnDate.Text.Trim() + "." + " " + " Retum Code : " + _Retumcode + " " + " To " + " " + txtReturnCode.Text.Trim()
                    Logger.system_log(log_message)
                ElseIf _RetumDate <> txtReturnDate.Text.Trim() Then
                    log_message = " Updated : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Date : " + _RetumDate + " " + " To " + " " + txtReturnDate.Text.Trim()
                    Logger.system_log(log_message)
                ElseIf _Retumcode <> txtReturnCode.Text.Trim() Then
                    log_message = " Updated : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Code : " + _Retumcode + " " + " To " + " " + txtReturnCode.Text.Trim()
                    Logger.system_log(log_message)
                Else
                    log_message = " Updated : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim()
                    Logger.system_log(log_message)
                End If
                '------------Mizan Work (08-05-2016)------------

            ElseIf result = 1 Then
                tStatus = TransState.UnspecifiedError
            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            End If

           


        End If

        Return tStatus

    End Function



    Private Function ClearReturnStatus() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Update Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_Update")

                db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode.Trim())
                db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
                db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "O")
                db.AddInParameter(commProc, "@RTN_CODE", DbType.String, DBNull.Value)

                'db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, NullHelper.StringToDate(txtReturnDate.Text.Trim()))
                db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, DBNull.Value)

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
                ElseIf result = 0 Then

                    _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")
                Else
                    trans.Rollback()
                    Return tStatus
                End If


                tStatus = TransState.Update

                trans.Commit()



                Return tStatus

            End Using

        End If

    End Function

    '------------Mizan Work (16-05-2016)------------

    Private Sub LoadReturnDataForAuth(ByVal strDCode As String, ByVal intSlno As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From RETURN_CSD  Where D_CODE ='" & strDCode & "' and SLNO ='" & intSlno & "' and STATUS='L'")
          
            If ds.Tables(0).Rows.Count > 0 Then


                _strDCode = strDCode
                _intSlno = intSlno



                txtSlno.Text = ds.Tables(0).Rows(0)("SLNO").ToString()
                'lblCheckNo.Text = ds.Tables(0).Rows(0)("CHECK_NO").ToString()
                'lblAmount.Text = ds.Tables(0).Rows(0)("AMOUNT").ToString()
                txtReturnCode.Text = ds.Tables(0).Rows(0)("RTN_CODE").ToString()
                _aRetumcode = ds.Tables(0).Rows(0)("RTN_CODE").ToString()
                'lblReason.Text = ds.Tables(0).Rows(0)("REJECT_REASON").ToString()
                lblStatus.Text = ds.Tables(0).Rows(0)("RTN_STATUS").ToString()

                txtReturnDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("RTN_DATE"))
                _aRetumDate = NullHelper.DateToString(ds.Tables(0).Rows(0)("RTN_DATE")).ToString


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadReturnData(ByVal strDCode As String, ByVal intSlno As Integer, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode.Trim())
            db.AddInParameter(commProc, "@SLNO", DbType.Int32, intSlno)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _strDCode = strDCode
                _intSlno = intSlno

                _intModno = intMod

                _formMode = FormTransMode.Update

                txtSlno.Text = ds.Tables(0).Rows(0)("SLNO").ToString()
                lblCheckNo.Text = ds.Tables(0).Rows(0)("CHECK_NO").ToString()
                lblAmount.Text = ds.Tables(0).Rows(0)("AMOUNT").ToString()
                txtReturnCode.Text = ds.Tables(0).Rows(0)("RTN_CODE").ToString()
                _Retumcode = ds.Tables(0).Rows(0)("RTN_CODE").ToString()
                lblReason.Text = ds.Tables(0).Rows(0)("REJECT_REASON").ToString()
                lblStatus.Text = ds.Tables(0).Rows(0)("RTN_STATUS").ToString()

                txtReturnDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("RTN_DATE"))
                _RetumDate = NullHelper.DateToString(ds.Tables(0).Rows(0)("RTN_DATE")).ToString
                

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@D_CODE", DbType.String, strDCode.Trim())
                db.AddInParameter(commProc2, "@SLNO", DbType.Int32, intSlno)

                lblVerTot.Text = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()


                If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then


                    If btnUnlock.Enabled = False Then
                        EnableFields()

                        EnableDelete()
                        EnableNew()

                        EnableSave()

                    End If
                Else
                    DisableAuth()

                    DisableDelete()

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

            If lblStatus.Text.Trim() = "R" And chkAuthorized.Checked = True Then
                btnClearReturn.Enabled = True
            Else
                btnClearReturn.Enabled = False
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

    Public Sub New(ByVal strDCode As String, ByVal intSlno As Integer, ByVal intMod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strDCode = strDCode
        _intSlno = intSlno
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
        db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (16-05-2016)------------

            If _aRetumDate <> _RetumDate And _aRetumcode <> _Retumcode Then
                If _aRetumDate = "" And _aRetumcode = "" Then
                    log_message = " Authorized : Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Date : " + _RetumDate + "." + " " + " Retum Code : " + _Retumcode
                    Logger.system_log(log_message)
                Else
                    log_message = " Authorized : Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Date : " + _aRetumDate + " " + " To " + " " + _RetumDate + "." + " " + " Retum Code : " + _aRetumcode + " " + " To " + " " + _Retumcode
                    Logger.system_log(log_message)
                End If

            ElseIf _aRetumDate <> _RetumDate Then
                If _aRetumDate = "" Then
                    log_message = " Authorized : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Date : " + _RetumDate
                    Logger.system_log(log_message)
                Else
                    log_message = " Authorized : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Date : " + _aRetumDate + " " + " To " + " " + _RetumDate
                    Logger.system_log(log_message)
                End If

            ElseIf _aRetumcode <> _Retumcode Then
                If _aRetumcode = "" Then
                    log_message = " Authorized : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Code : " + _Retumcode
                    Logger.system_log(log_message)
                Else
                    log_message = " Authorized : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + " Retum Code : " + _aRetumcode + " " + " To " + " " + _Retumcode
                    Logger.system_log(log_message)
                End If

            Else
                log_message = " Authorized : Citi Speed Return Deposit Code : " + txtDepoCode.Text.Trim()
                Logger.system_log(log_message)
            End If
            '------------Mizan Work (16-05-2016)------------

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
        db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
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



    Private Sub LoadDepositSlipData(ByVal strDCode As String)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetCheckSlip")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)

            Dim dt As New DataTable()

            dt = db.ExecuteDataSet(commProc).Tables(0)

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
                txtTotalAmount.Text = dt.Rows(0)("CITICHECK_AMOUNT").ToString()
                txtTotalCheckNo.Text = dt.Rows(0)("NO_CHECK").ToString()


            Else
                ClearFieldsAll()

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


#End Region



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then
                        LoadReturnData(_strDCode, _intSlno, _intModno)


                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()




                    ElseIf tState = TransState.Update Then

                        LoadReturnData(_strDCode, _intSlno, _intModno)


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



        If Not (_intModno = 0) Then

            If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then
                EnableFields()


                EnableDelete()
                EnableNew()

                EnableSave()


            Else
                DisableAuth()

                DisableDelete()

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


        DisableDelete()

        txtDepoCode.Focus()

        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)

        txtReturnDate.Text = todaysdate.ToString()

    End Sub

   


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadReturnData(_strDCode, _intSlno, _intModno)

                    DisableAuth()

                    If _strDCode = "" Then

                        DisableDelete()
                        DisableSave()

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

            LoadReturnData(_strDCode, _intSlno, _intModno - 1)

        End If


    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strDCode As String = _strDCode
        Dim intSlno As Integer = _intSlno
        Dim intModno As Integer = _intModno

        If intModno > 0 Then


            LoadReturnData(_strDCode, _intSlno, _intModno + 1)


            If _intModno = 0 Then
                LoadReturnData(strDCode, intSlno, intModno)

            End If
        End If




    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadReturnDataForAuth(_strDCode, _intSlno)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadReturnData(_strDCode, _intSlno, _intModno)

                    lblToolStatus.Text = "!! Authorized Successfully !!"
                    EnableUnlock()

                    DisableNew()
                    DisableSave()
                    DisableDelete()
                    DisableAuth()


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

  
    Private Sub txtDepoCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoCode.KeyDown
        If e.KeyCode = Keys.Enter And txtDepoCode.Text.Trim() <> "" Then

           
            txtSlno.Focus()

            
        End If
    End Sub

    Private Sub txtDepoCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDepoCode.Validating


        If txtDepoCode.Text.Trim() <> "" Then

            lblToolStatus.Text = ""

            LoadDepositSlipData(txtDepoCode.Text.Trim())

            If Not txtDepoCode.Text.Trim() = "" Then

                txtDepoCode.ReadOnly = True
                'txtCheckNo.Focus()

                
            Else
                MessageBox.Show("Invalid Deposit Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDepoCode.Focus()
            End If


        End If

    End Sub

    Private Sub txtSlno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlno.KeyDown


        If e.KeyCode = Keys.Enter Then
            If txtSlno.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "CitiSpeed Check List"
                frmList.ProcName = "CMS_CSDDet_GetDetailsByDCode"
                frmList.AddParamToDB("@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                frmList.filter = New String(,) {{"CHECK_NO", "Check No"}, {"AMOUNT", "Amount"}}
                frmList.colwidth = New Integer(,) {{4, 220}}
                frmList.colrename = New String(,) {{"2", "Check No"}, {"4", "Bank Name"}, {"5", "Ret Stat"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then
                    txtSlno.Text = frmList.RowResult.Cells(1).Value.ToString()
                    lblCheckNo.Text = frmList.RowResult.Cells(2).Value.ToString()
                    lblAmount.Text = frmList.RowResult.Cells(3).Value.ToString()
                    lblStatus.Text = frmList.RowResult.Cells(5).Value.ToString()

                Else
                    txtSlno.Clear()
                    lblCheckNo.Text = ""
                    lblAmount.Text = ""
                    lblStatus.Text = ""

                End If

                frmList.Dispose()

            Else


                Try



                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSDDet_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                    db.AddInParameter(commProc, "@SLNO", DbType.Int32, NullHelper.ToIntNum(txtSlno.Text))

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblCheckNo.Text = dt.Rows(0)("CHECK_NO").ToString()
                        lblAmount.Text = dt.Rows(0)("AMOUNT").ToString()
                        lblStatus.Text = dt.Rows(0)("RTN_STATUS").ToString()

                        Try

                            '-------

                            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                            'Dim dt As New DataTable

                            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_ReturnCSD_GetMaxMod")

                            commProc1.Parameters.Clear()

                            db.AddInParameter(commProc1, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                            db.AddInParameter(commProc1, "@SLNO", DbType.Int32, NullHelper.ToIntNum(txtSlno.Text))

                            Dim maxMod As Integer = NullHelper.ToIntNum(db.ExecuteDataSet(commProc1).Tables(0).Rows(0)(0))

                            If maxMod > 0 Then
                                LoadReturnData(txtDepoCode.Text, txtSlno.Text, maxMod)
                            End If



                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                    Else
                        txtSlno.Clear()
                        lblCheckNo.Text = ""
                        lblAmount.Text = ""
                        lblStatus.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                If txtSlno.Text.Trim() <> "" Then
                    txtReturnCode.Focus()
                End If

            End If

            
        End If


    End Sub

    Private Sub FrmCitiSpeedReturnDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        If _intModno > 0 Then
            LoadDepositSlipData(_strDCode)
            LoadReturnData(_strDCode, _intSlno, _intModno)
        End If

       



        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()


        DisableFields()

    End Sub

    
    Private Sub txtReturnCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnCode.KeyDown

        If e.KeyCode = Keys.Enter And txtReturnCode.Text.Trim() <> "" Then


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable
            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnReject_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, txtReturnCode.Text)

            dt = db.ExecuteDataSet(commProc).Tables(0)
            If dt.Rows.Count > 0 Then

                txtReturnCode.Text = dt.Rows(0)("REJECT_CODE")
                lblReason.Text = dt.Rows(0)("REJECT_REASON")

            Else
                MessageBox.Show("Invalid Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtReturnCode.Clear()
                lblReason.Text = ""
                txtReturnCode.Focus()

            End If


            If txtReturnCode.Text.Trim() <> "" Then
                btnSave.Focus()
            End If


        End If

    End Sub

    Private Sub btnClearReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearReturn.Click



        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you want to update check status to outstanding?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                tState = ClearReturnStatus()
                

                If tState = TransState.Update Then

                    LoadReturnData(_strDCode, _intSlno, _intModno)

                    'EnableUnlock()
                    'DisableNew()
                    DisableSave()
                    'DisableDelete()
                    DisableAuth()
                    DisableFields()

                    btnClearReturn.Enabled = False


                    lblToolStatus.Text = "!! Status updated successfully !!"

                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Status update Not Possible !!"

                ElseIf tState = TransState.NoRecord Then
                    lblToolStatus.Text = "!! Nothing to update !!"
                Else
                    lblToolStatus.Text = "!! Unspecified Error Occured !!"
                End If




            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
End Class