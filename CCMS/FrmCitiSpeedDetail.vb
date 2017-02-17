'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain CitiSpeed Detail
'Creation date      : 08-Jan-2013
'Stored Procedure(s):  
'
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization


Public Class FrmCitiSpeedDetail


#Region "Global Variables"
    Public Shared AddSlipText As String = ""
    Public Shared AddCheckText As String = ""
    Dim _formName As String = "DepositCitiSpeedDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _strDCode As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False

    Dim log_message As String

    'For Update
    Dim _checkNo(1000) As String
    Dim _drBankCode(1000) As String
    Dim _drBrName(1000) As String
    Dim _amount(1000) As String
    Dim _checkRef(1000) As String
    Dim _checkDate(1000) As String
    Dim _drawer(1000) As String

    'For Auth
    Dim _acheckNo(1000) As String
    Dim _adrBankCode(1000) As String
    Dim _adrBrName(1000) As String
    Dim _aamount(1000) As String
    Dim _acheckRef(1000) As String
    Dim _acheckDate(1000) As String
    Dim _adrawer(1000) As String

    Dim SpeedList As New List(Of String)
    Dim _SpeedLog As String = ""
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

        txtDepoCode.ReadOnly = True
        'btnSearchDepo.Enabled = False

        'txtSlipDate.ReadOnly = True
        txtCheckNo.ReadOnly = True
        txtCheckRef.ReadOnly = True
        txtCheckDate.ReadOnly = True
        txtCustomerRef.ReadOnly = True

        txtDraweeBankCode.ReadOnly = True
        btnSearchBank.Enabled = False
        txtDraweeBranch.ReadOnly = True
        txtDrawer.ReadOnly = True
        txtAmount.ReadOnly = True
        

        btnAddToGrid.Enabled = False
        btnRemoveFromGrid.Enabled = False

        btnCancel.Visible = False




        'dgView.ReadOnly = True



    End Sub

    Private Sub EnableFields()

        If _intModno = 0 Then
            txtDepoCode.ReadOnly = False
            'btnSearchDepo.Enabled = True
        End If

        'txtSlipDate.ReadOnly = False
        txtCheckNo.ReadOnly = False
        txtCheckRef.ReadOnly = False
        txtCheckDate.ReadOnly = False
        txtCustomerRef.ReadOnly = False

        txtDraweeBankCode.ReadOnly = False
        btnSearchBank.Enabled = True
        txtDraweeBranch.ReadOnly = False
        txtDrawer.ReadOnly = False
        txtAmount.ReadOnly = False

        btnAddToGrid.Enabled = True
        btnRemoveFromGrid.Enabled = True

        btnCancel.Visible = False



    End Sub


    Private Sub ClearFields()

        'txtSlipDate.Clear()
        txtCheckNo.Clear()
        txtCheckRef.Clear()
        txtCheckDate.Clear()
        'txtCustomerRef.Clear()

        txtDraweeBankCode.Clear()
        lblDraweeBankName.Text = ""

        txtDraweeBranch.Clear()
        txtDrawer.Clear()
        txtAmount.Clear()

        dgView.AllowUserToAddRows = False

        'dgView.DataSource = Nothing

        

    End Sub

    Private Sub ClearFieldsAll()

        txtDepoCode.Clear()

        AddSlipText = ""
        AddCheckText = ""
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

        txtSlipDate.Clear()
        txtCheckNo.Clear()
        txtCheckRef.Clear()
        txtCheckDate.Clear()
        txtCustomerRef.Clear()

        txtDraweeBankCode.Clear()
        lblDraweeBankName.Text = ""

        txtDraweeBranch.Clear()
        txtDrawer.Clear()
        txtAmount.Clear()

        dgView.AllowUserToAddRows = False

        dgView.DataSource = Nothing
        dgView.Rows.Clear()

        ShowGridTotal()

        _strDCode = ""
        _intModno = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""

        txtRetStatus.Text = "O"
        txtRetCode.Clear()


    End Sub


    Private Sub ShowGridTotal()


        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0

        For Each row As DataGridViewRow In dgView.Rows


            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(7).Value)

            CheckNoTotal = CheckNoTotal + 1

        Next

        lblTotalCheckNo.Text = CheckNoTotal.ToString()
        lblTotalCheckAmount.Text = CheckTotal.ToString("N")


        
        If NullHelper.ToDecNum(txtTotalAmount.Text.Trim()) <> CheckTotal Then
            lblTotalCheckAmount.ForeColor = Color.Red
        Else
            lblTotalCheckAmount.ForeColor = Color.Black
        End If

        If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then
            lblTotalCheckNo.ForeColor = Color.Red
        Else
            lblTotalCheckNo.ForeColor = Color.Black
        End If


    End Sub



    Private Sub ShowOpertionStatus()

        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0

        Dim MsgStatus As String = ""

        For Each row As DataGridViewRow In dgView.Rows

            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(7).Value)

            CheckNoTotal = CheckNoTotal + 1

        Next

        If NullHelper.ToDecNum(txtTotalAmount.Text.Trim()) <> CheckTotal Then

            Dim diffCheck As Decimal = CheckTotal - NullHelper.ToDecNum(txtTotalAmount.Text.Trim())
            MsgStatus = MsgStatus + "Mismatch in Total Check amount:  " & diffCheck.ToString() & Environment.NewLine

        End If

        If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then

            Dim diffCheckNo As Integer = CheckNoTotal - NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim())
            MsgStatus = MsgStatus + "Mismatch in Total Check No:  " & diffCheckNo.ToString() & Environment.NewLine

        End If

        If MsgStatus.Trim() <> "" Then
            MessageBox.Show(MsgStatus, "Mismatch Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Function CheckValidData() As Boolean


        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False

        ElseIf lblDepoScheCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit slip load required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False
        

        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("You didn't enter any record!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        ShowOpertionStatus()



        Return True

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSD_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
                db.AddInParameter(commProc, "@AddSlipText", DbType.String, AddSlipText)


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

                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CSDDet_Add")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcSche, "@DRAWER", DbType.String, dgView.Rows(i).Cells(2).Value)
                        db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, dgView.Rows(i).Cells(3).Value)
                        db.AddInParameter(commProcSche, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(7).Value))

                        'db.AddInParameter(commProcSche, "@CUSTOMER_REF", DbType.String, dgView.Rows(i).Cells(9).Value)
                        'db.AddInParameter(commProcSche, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())

                        db.AddInParameter(commProcSche, "@SLIP_DATE", DbType.DateTime, DateTime.ParseExact(dgView.Rows(i).Cells(8).Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        db.AddInParameter(commProcSche, "@CHECK_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(6).Value.ToString()))
                        db.AddInParameter(commProcSche, "@DRAWEE_BRANCH", DbType.String, dgView.Rows(i).Cells(5).Value)
                        db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@AddCheckText", DbType.String, dgView.Rows(i).Cells(13).Value)
                        'db.AddInParameter(commProcSche, "@RTN_STATUS", DbType.String, NullHelper.ObjectToNull(dgView.Rows(i).Cells(11).Value))
                        'db.AddInParameter(commProcSche, "@RTN_CODE", DbType.String, NullHelper.ObjectToNull(dgView.Rows(i).Cells(12).Value))


                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Add
                    _strDCode = txtDepoCode.Text.Trim()
                    _intModno = 1

                    log_message = " Added : Citi Speed Deposit Code  : " + txtDepoCode.Text.ToString()
                    Logger.system_log(log_message)


                End If

                trans.Commit()

                
            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                'Dim cmd As DbCommand = db.GetSqlStringCommand("select [PPM_GenDate] from [dbo].[DSCHEDULE] where D_CODE=@D_CODE")
                'cmd.Parameters.Clear()
                'db.AddInParameter(cmd, "@D_CODE", DbType.String, _strDCode)
                'Dim dt As DataTable = db.ExecuteDataSet(cmd).Tables(0)
                'If Not (String.IsNullOrEmpty(dt.Rows(0)("PPM_GenDate").ToString)) Then
                '    cmd.CommandText = "insert into TMP_RETURN_CSD()"
                'End If

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSD_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
                db.AddInParameter(commProc, "@AddSlipText", DbType.String, AddSlipText)
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


                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CSDDet_Update")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@D_CODE", DbType.String, _strDCode)
                        db.AddInParameter(commProcSche, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProcSche, "@DRAWER", DbType.String, dgView.Rows(i).Cells(2).Value)
                        db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, dgView.Rows(i).Cells(3).Value)
                        db.AddInParameter(commProcSche, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(7).Value))

                        'db.AddInParameter(commProcSche, "@CUSTOMER_REF", DbType.String, dgView.Rows(i).Cells(9).Value)
                        'db.AddInParameter(commProcSche, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())

                        db.AddInParameter(commProcSche, "@SLIP_DATE", DbType.DateTime, DateTime.ParseExact(dgView.Rows(i).Cells(8).Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        db.AddInParameter(commProcSche, "@CHECK_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(6).Value.ToString()))
                        db.AddInParameter(commProcSche, "@DRAWEE_BRANCH", DbType.String, dgView.Rows(i).Cells(5).Value)
                        db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intModno)
                        db.AddInParameter(commProcSche, "@RTN_STATUS", DbType.String, NullHelper.ObjectToNull(dgView.Rows(i).Cells(11).Value))
                        db.AddInParameter(commProcSche, "@RTN_CODE", DbType.String, NullHelper.ObjectToNull(dgView.Rows(i).Cells(12).Value))
                        db.AddInParameter(commProcSche, "@AddCheckText", DbType.String, dgView.Rows(i).Cells(13).Value)

                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Update
                    _intModno = intModno

                    trans.Commit()

                    '------------Mizan Work (09-05-2016)------------
                    
                    'For Gridview Data

                    For i = 0 To dgView.Rows.Count - 1

                        If _checkNo(i) <> dgView.Item(1, i).Value Then
                            log_message = " Check No : " + _checkNo(i) + " " + " To " + " " + dgView.Item(1, i).Value.ToString + "." + " "
                            SpeedList.Add(log_message)
                        End If

                        If _drawer(i) <> dgView.Item(2, i).Value Then
                            If _drawer(i) = "" Then
                                log_message = " Drawer : " + dgView.Item(2, i).Value.ToString + "." + " "
                            Else
                                log_message = " Drawer : " + _drawer(i) + " " + " To " + " " + dgView.Item(2, i).Value.ToString + "." + " "
                            End If
                            SpeedList.Add(log_message)
                        End If
                        If _drBankCode(i) <> dgView.Item(3, i).Value Then
                            log_message = " Drawee Bank Code : " + _drBankCode(i) + " " + " To " + " " + dgView.Item(3, i).Value.ToString + "." + " "
                            SpeedList.Add(log_message)
                        End If
                        If _drBrName(i) <> dgView.Item(5, i).Value Then
                            If _drBrName(i) = "" Then
                                log_message = " Drawee Branch : " + dgView.Item(5, i).Value.ToString + "." + " "
                            Else
                                log_message = " Drawee Branch : " + _drBrName(i) + " " + " To " + " " + dgView.Item(5, i).Value.ToString + "." + " "
                            End If
                            SpeedList.Add(log_message)
                        End If
                        If _checkDate(i) <> dgView.Item(6, i).Value Then
                            If _checkDate(i) = "" Then
                                log_message = " Check Date : " + dgView.Item(6, i).Value.ToString + "." + " "
                            Else
                                log_message = " Check Date : " + _checkDate(i) + " " + " To " + " " + dgView.Item(6, i).Value.ToString + "." + " "
                            End If
                            SpeedList.Add(log_message)
                        End If
                        If _amount(i) <> dgView.Item(7, i).Value Then
                            log_message = " Amount : " + _amount(i) + " " + " To " + " " + dgView.Item(7, i).Value.ToString + "." + " "
                            SpeedList.Add(log_message)
                        End If
                        If _checkRef(i) <> dgView.Item(10, i).Value Then
                            If _checkRef(i) = "" Then
                                log_message = " Check Ref. : " + dgView.Item(10, i).Value.ToString + "." + " "
                            Else
                                log_message = " Check Ref. : " + _checkRef(i) + " " + " To " + " " + dgView.Item(10, i).Value.ToString + "." + " "
                            End If
                            SpeedList.Add(log_message)
                        End If

                    Next


                    For Each speedInfo As String In SpeedList
                        _SpeedLog += speedInfo
                    Next
                    _log = " Updated : Citi Speed Deposit Code  : " + txtDepoCode.Text.ToString() + "." + " " + _SpeedLog

                    Logger.system_log(_log)

                    _SpeedLog = ""
                    SpeedList.Clear()

                    '------------Mizan Work (09-05-2016)------------

                    Return tStatus

                End If

                trans.Rollback()


            End Using


        End If


        Return tStatus

    End Function

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSD_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        If (_intModno > 1) Then
            Dim cmd As DbCommand = db.GetSqlStringCommand("UPDATE CSD SET CSD.Customer_Ref=CSD_HIST.Customer_Ref" _
                                                          + " from CSD inner join CSD_HIST on" _
                                                          + " CSD.D_CODE=CSD_HIST.D_CODE where" _
                                                          + " CSD.D_CODE=@D_CODE and CSD_HIST.IS_AUTH=0" _
                                                          + " AND CSD_HIST.STATUS='U'")
            cmd.Parameters.Clear()
            db.AddInParameter(cmd, "@D_CODE", DbType.String, _strDCode)
            db.ExecuteNonQuery(cmd)
        End If
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (15-05-2016)------------

            If _intModno > 1 Then

                'For Gridview Data

                For i = 0 To dgView.Rows.Count - 1

                    If _acheckNo(i) <> _checkNo(i) Then
                        log_message = " Check No : " + _acheckNo(i) + " " + " To " + " " + _checkNo(i) + "." + " "
                        SpeedList.Add(log_message)
                    End If

                    If _adrawer(i) <> _drawer(i) Then
                        If _adrawer(i) = "" Then
                            log_message = " Drawer : " + _drawer(i) + "." + " "
                        Else
                            log_message = " Drawer : " + _adrawer(i) + " " + " To " + " " + _drawer(i) + "." + " "
                        End If
                        SpeedList.Add(log_message)
                    End If
                    If _adrBankCode(i) <> _drBankCode(i) Then
                        log_message = " Drawee Bank Code : " + _adrBankCode(i) + " " + " To " + " " + _drBankCode(i) + "." + " "
                        SpeedList.Add(log_message)
                    End If
                    If _adrBrName(i) <> _drBrName(i) Then
                        If _adrBrName(i) = "" Then
                            log_message = " Drawee Branch : " + _drBrName(i) + "." + " "
                        Else
                            log_message = " Drawee Branch : " + _adrBrName(i) + " " + " To " + " " + _drBrName(i) + "." + " "
                        End If
                        SpeedList.Add(log_message)
                    End If
                    If _acheckDate(i) <> _checkDate(i) Then
                        If _acheckDate(i) = "" Then
                            log_message = " Check Date : " + _checkDate(i) + "." + " "
                        Else
                            log_message = " Check Date : " + _acheckDate(i) + " " + " To " + " " + _checkDate(i) + "." + " "
                        End If
                        SpeedList.Add(log_message)
                    End If
                    If _aamount(i) <> _amount(i) Then
                        log_message = " Amount : " + _aamount(i) + " " + " To " + " " + _amount(i) + "." + " "
                        SpeedList.Add(log_message)
                    End If
                    If _acheckRef(i) <> _checkRef(i) Then
                        If _acheckRef(i) = "" Then
                            log_message = " Check Ref. : " + _checkRef(i) + "." + " "
                        Else
                            log_message = " Check Ref. : " + _acheckRef(i) + " " + " To " + " " + _checkRef(i) + "." + " "
                        End If
                        SpeedList.Add(log_message)
                    End If

                Next


                For Each speedInfo As String In SpeedList
                    _SpeedLog += speedInfo
                Next
                _log = " Authorized : Citi Speed Deposit Code  : " + txtDepoCode.Text.ToString() + "." + " " + _SpeedLog

                Logger.system_log(_log)

                _SpeedLog = ""
                SpeedList.Clear()


            Else

                _log = " Authorized : Citi Speed Deposit Code  : " + txtDepoCode.Text.ToString()
                Logger.system_log(_log)

            End If
            '------------Mizan Work (15-05-2016)------------

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
        ElseIf result = 11 Then
            tStatus = TransState.ParentNotExist

        Else
            tStatus = TransState.UpdateNotPossible
        End If

        
        Return tStatus

    End Function


    Private Sub LoadMainData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSD_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intmod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strDCode = strDCode
                _intModno = intMod

                _formMode = FormTransMode.Update



                txtDepoCode.Text = ds.Tables(0).Rows(0)("D_CODE").ToString()

                txtCustomerRef.Text = ds.Tables(0).Rows(0)("CUSTOMER_REF").ToString()

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CSD_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@D_CODE", DbType.String, strDCode)

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

    '------------Mizan Work (15-05-2016)------------

    Private Sub LoadDetailDataForAuth(ByVal strDCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CSD_DET Where D_CODE ='" & strDCode & "'  and STATUS='L'").Tables(0)

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                'AddCheckText = dt.Rows(i)("AddCheckText")
                'txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(1, i).Value = dt.Rows(i)("CHECK_NO")
                    _acheckNo(i) = dt.Rows(i)("CHECK_NO")
                    dgView.Item(2, i).Value = dt.Rows(i)("DRAWER")
                    _adrawer(i) = dt.Rows(i)("DRAWER")
                    dgView.Item(3, i).Value = dt.Rows(i)("DRAWEE_BANK_CODE")
                    _adrBankCode(i) = dt.Rows(i)("DRAWEE_BANK_CODE")
                    'dgView.Item(4, i).Value = dt.Rows(i)("BANK_NAME")
                    dgView.Item(5, i).Value = dt.Rows(i)("DRAWEE_BRANCH")
                    _adrBrName(i) = dt.Rows(i)("DRAWEE_BRANCH")
                    dgView.Item(6, i).Value = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE"))
                    _acheckDate(i) = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE")).ToString()
                    dgView.Item(7, i).Value = dt.Rows(i)("AMOUNT")
                    _aamount(i) = dt.Rows(i)("AMOUNT")
                    dgView.Item(8, i).Value = NullHelper.DateToString(dt.Rows(i)("SLIP_DATE"))
                    dgView.Item(9, i).Value = dt.Rows(i)("CUSTOMER_REF").ToString
                    dgView.Item(10, i).Value = dt.Rows(i)("CHECK_REF")
                    _acheckRef(i) = dt.Rows(i)("CHECK_REF")
                    dgView.Item(11, i).Value = dt.Rows(i)("RTN_STATUS")
                    dgView.Item(12, i).Value = dt.Rows(i)("RTN_CODE")
                    dgView.Item(13, i).Value = dt.Rows(i)("AddCheckText")
                Next
                dgView.AllowUserToAddRows = False

            End If

            ShowGridTotal()


            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDetailData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CSDDet_GetDetails")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intmod)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)


            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                'AddCheckText = dt.Rows(i)("AddCheckText")
                'txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(1, i).Value = dt.Rows(i)("CHECK_NO")
                    _checkNo(i) = dt.Rows(i)("CHECK_NO")
                    dgView.Item(2, i).Value = dt.Rows(i)("DRAWER")
                    _drawer(i) = dt.Rows(i)("DRAWER")
                    dgView.Item(3, i).Value = dt.Rows(i)("DRAWEE_BANK_CODE")
                    _drBankCode(i) = dt.Rows(i)("DRAWEE_BANK_CODE")
                    dgView.Item(4, i).Value = dt.Rows(i)("BANK_NAME")
                    dgView.Item(5, i).Value = dt.Rows(i)("DRAWEE_BRANCH")
                    _drBrName(i) = dt.Rows(i)("DRAWEE_BRANCH")
                    dgView.Item(6, i).Value = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE"))
                    _checkDate(i) = NullHelper.DateToString(dt.Rows(i)("CHECK_DATE")).ToString()
                    dgView.Item(7, i).Value = dt.Rows(i)("AMOUNT")
                    _amount(i) = dt.Rows(i)("AMOUNT")
                    dgView.Item(8, i).Value = NullHelper.DateToString(dt.Rows(i)("SLIP_DATE"))
                    dgView.Item(9, i).Value = dt.Rows(i)("CUSTOMER_REF").ToString
                    dgView.Item(10, i).Value = dt.Rows(i)("CHECK_REF")
                    _checkRef(i) = dt.Rows(i)("CHECK_REF")
                    dgView.Item(11, i).Value = dt.Rows(i)("RTN_STATUS")
                    dgView.Item(12, i).Value = dt.Rows(i)("RTN_CODE")
                    dgView.Item(13, i).Value = dt.Rows(i)("AddCheckText")
                Next
                dgView.AllowUserToAddRows = False

            End If

            ShowGridTotal()


            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadDepositSlipData(ByVal strDCode As String)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetCheckSlip")

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CSD_GetAddSlipText")

            commProc.Parameters.Clear()

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)

            db.AddInParameter(commProc2, "@D_CODE", DbType.String, strDCode)

            Dim dt As New DataTable()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            Dim dt2 As New DataTable()
            dt2 = db.ExecuteDataSet(commProc2).Tables(0)

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
                txtSlipDate.Text = NullHelper.DateToString(dt.Rows(0)("SCHEDULE_DATE"))
                If dt2.Rows.Count > 0 Then
                    AddSlipText = dt2.Rows(0)("AddSlipText").ToString()
                End If
            Else
                ClearFieldsAll()

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSD_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDCode)
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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strDCode As String, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strDCode = strDCode

        _intModno = intmod

    End Sub


#End Region




    
    Private Sub FrmCitiSpeedDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intModno > 0 Then
            LoadDepositSlipData(_strDCode)

            If Not txtDepoCode.Text = "" Then
                LoadMainData(_strDCode, _intModno)
                LoadDetailData(_strDCode, _intModno)
            End If

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

        lblToolStatus.Text = ""

        EnableNew()
        If Not (_strDCode = "") Then

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

        If txtDepoCode.Enabled = True Then
            txtDepoCode.Focus()
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

                        'LoadMainData(_strDCode, _intModno)
                        'LoadDetailData(_strDCode, _intModno)

                        btnNew_Click(sender, e)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        '_formMode = FormTransMode.Update

                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()



                    ElseIf tState = TransState.Update Then

                        'LoadMainData(_strDCode, _intModno)
                        'LoadDetailData(_strDCode, _intModno)

                        btnNew_Click(sender, e)

                        lblToolStatus.Text = "!! Information Updated Successfully !!"

                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()

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
        LoadDetailData(_strDCode, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try

            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then

                    _formMode = FormTransMode.Add

                    LoadMainData(_strDCode, _intModno)
                    LoadDetailData(_strDCode, _intModno)

                    DisableAuth()

                    If _strDCode = "" Then

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

            LoadMainData(_strDCode, _intModno - 1)
            LoadDetailData(_strDCode, _intModno)

        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strDCode As String = _strDCode
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_strDCode, _intModno + 1)

            If _intModno = 0 Then
                LoadDepositSlipData(strDCode)
                LoadMainData(strDCode, intModno)
                LoadDetailData(strDCode, intModno)
            Else
                LoadDetailData(_strDCode, _intModno)
            End If

        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            ShowOpertionStatus()

            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadDetailDataForAuth(_strDCode)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_strDCode, _intModno)
                    LoadDetailData(_strDCode, _intModno)

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
                ElseIf tState = TransState.ParentNotExist Then
                    lblToolStatus.Text = "!! Failed! Given deposit code does not exist in any authorize schedule record !!"
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

    

    Private Sub btnSearchBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBank.Click
        Dim frmList As New FrmList()
        frmList.Text = "Bank List"
        frmList.ProcName = "CMS_Bank_GetList"

        frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}

        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtDraweeBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblDraweeBankName.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

        If txtDraweeBankCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If


    End Sub

    Private Sub txtDraweeBankCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBankCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDraweeBankCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank List"
                frmList.ProcName = "CMS_Bank_GetList"
                frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtDraweeBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblDraweeBankName.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try



                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblDraweeBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                    Else
                        txtDraweeBankCode.Clear()
                        lblDraweeBankName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDraweeBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click

        If Trim(txtSlipDate.Text.Trim()) = "/  /" Then

            MessageBox.Show("Slip date equired !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSlipDate.Focus()
            Exit Sub
        End If

        If txtCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Check No. required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNo.Focus()
            Exit Sub
        End If

        If lblDraweeBankName.Text.Trim() = "" Then
            MessageBox.Show("Drawee Bank required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDraweeBankCode.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtAmount.Text) = 0 Then
            MessageBox.Show("Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, lblClientCode.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("CASH_CR_TYPE").ToString().Trim() = "R" And txtCustomerRef.Text.Trim() = "" Then
                    MessageBox.Show("This client customer ref. cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCustomerRef.Focus()
                    Exit Sub

                End If

            Else

                MessageBox.Show("No client information found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'For Each row As DataGridViewRow In dgView.Rows
        '    If row.Cells(0).Value.ToString().Trim() = txtDepoCode.Text.Trim() Then
        '        MessageBox.Show("Duplicate Deposit Slip", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If
        'Next

        If _RowEditMode = True Then
            Dim selRow As Integer = lblRowNo.Text.Trim()

            dgView.Item(1, selRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(2, selRow).Value = txtDrawer.Text.Trim()
            dgView.Item(3, selRow).Value = txtDraweeBankCode.Text.Trim()
            dgView.Item(4, selRow).Value = lblDraweeBankName.Text.Trim()
            dgView.Item(5, selRow).Value = txtDraweeBranch.Text.Trim()
            dgView.Item(6, selRow).Value = IIf(txtCheckDate.Text.Trim() = "/  /", "", txtCheckDate.Text.Trim())
            dgView.Item(7, selRow).Value = NullHelper.ToDecNum(txtAmount.Text.Trim())
            dgView.Item(8, selRow).Value = txtSlipDate.Text.Trim()
            'dgView.Item(9, selRow).Value = txtCustomerRef.Text.Trim()
            dgView.Item(10, selRow).Value = txtCheckRef.Text.Trim()
            dgView.Item(13, selRow).Value = AddCheckText
            'dgView.Item(11, selRow).Value = txtRetStatus.Text.Trim()
            'dgView.Item(12, selRow).Value = txtRetCode.Text.Trim()


            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(selRow).Selected = True


        Else

            Dim MaxSlNo As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                If MaxSlNo <= NullHelper.ToIntNum(row.Cells(0).Value) Then
                    MaxSlNo = NullHelper.ToIntNum(row.Cells(0).Value) + 1
                End If


            Next

            dgView.Rows.Add()

            Dim maxRow As Integer = dgView.Rows.Count - 1

            dgView.Item(0, maxRow).Value = MaxSlNo  'maxRow + 1
            dgView.Item(1, maxRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(2, maxRow).Value = txtDrawer.Text.Trim()
            dgView.Item(3, maxRow).Value = txtDraweeBankCode.Text.Trim()
            dgView.Item(4, maxRow).Value = lblDraweeBankName.Text.Trim()
            dgView.Item(5, maxRow).Value = txtDraweeBranch.Text.Trim()
            dgView.Item(6, maxRow).Value = IIf(txtCheckDate.Text.Trim() = "/  /", "", txtCheckDate.Text.Trim())
            dgView.Item(7, maxRow).Value = NullHelper.ToDecNum(txtAmount.Text.Trim())
            dgView.Item(8, maxRow).Value = txtSlipDate.Text.Trim()
            'dgView.Item(9, maxRow).Value = txtCustomerRef.Text.Trim()
            dgView.Item(10, maxRow).Value = txtCheckRef.Text.Trim()
            dgView.Item(11, maxRow).Value = "O"
            dgView.Item(12, maxRow).Value = DBNull.Value
            dgView.Item(13, maxRow).Value = AddCheckText
            'dgView.Item(11, maxRow).Value = txtRetStatus.Text.Trim()
            'dgView.Item(12, maxRow).Value = txtRetCode.Text.Trim()


            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(maxRow).Selected = True

        End If

        '--

        ShowGridTotal()

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        '---

        AddCheckText = ""

        txtCheckNo.Clear()
        txtDrawer.Clear()
        'txtDraweeBankCode.Clear()
        'lblDraweeBankName.Text = ""
        'txtDraweeBranch.Clear()
        txtCheckDate.Clear()
        txtAmount.Text = "0"
        'txtSlipDate.Clear()
        'txtCustomerRef.Clear()
        txtCheckRef.Clear()

        txtRetStatus.Text = "O"
        txtRetCode.Clear()


        txtCheckNo.Focus()



    End Sub

    Private Sub btnRemoveFromGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromGrid.Click
        If dgView.SelectedRows.Count = 0 Then Exit Sub

        For Each row As DataGridViewRow In dgView.SelectedRows
            dgView.Rows.Remove(row)
        Next

        If _intModno = 0 Or (_intModno = 1 And chkAuthorized.Checked = False) Then

            Dim rowSlno As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                row.Cells(0).Value = rowSlno
                rowSlno = rowSlno + 1
            Next

        End If
       

        ShowGridTotal()


    End Sub

    Private Sub txtDepoCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoCode.KeyDown
        If e.KeyCode = Keys.Enter And txtDepoCode.Text.Trim() <> "" Then

            'lblToolStatus.Text = ""

            'LoadDepositSlipData(txtDepoCode.Text.Trim())

            'If Not txtDepoCode.Text.Trim() = "" Then

            '    txtDepoCode.ReadOnly = True

            'txtCheckNo.Focus()
            txtCustomerRef.Focus()

            '    Try

            '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            '        Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CSD_GetMaxMod")

            '        commProc2.Parameters.Clear()

            '        db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())

            '        Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

            '        If intModNo > 0 Then

            '            LoadMainData(txtDepoCode.Text.Trim(), intModNo)
            '            LoadDetailData(txtDepoCode.Text.Trim(), intModNo)

            '        End If


            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End Try

            'Else
            '    MessageBox.Show("Invalid Deposit Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If


        End If
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick

        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _RowEditMode = True

            btnAddToGrid.Text = "Update"
            btnCancel.Visible = True
            btnRemoveFromGrid.Enabled = False


            lblRowNo.Text = e.RowIndex.ToString()
            txtCheckNo.Text = dgView.Item(1, e.RowIndex).Value
            txtDrawer.Text = dgView.Item(2, e.RowIndex).Value
            txtDraweeBankCode.Text = dgView.Item(3, e.RowIndex).Value
            lblDraweeBankName.Text = dgView.Item(4, e.RowIndex).Value
            txtDraweeBranch.Text = dgView.Item(5, e.RowIndex).Value
            txtCheckDate.Text = dgView.Item(6, e.RowIndex).Value
            txtAmount.Text = dgView.Item(7, e.RowIndex).Value
            txtSlipDate.Text = dgView.Item(8, e.RowIndex).Value
            'txtCustomerRef.Text = dgView.Item(9, e.RowIndex).Value
            txtCheckRef.Text = dgView.Item(10, e.RowIndex).Value
            AddCheckText = dgView.Item(13, e.RowIndex).Value.ToString()
            'txtRetStatus.Text = NullHelper.ObjectToString(dgView.Item(11, e.RowIndex).Value)
            'txtRetCode.Text = NullHelper.ObjectToString(dgView.Item(12, e.RowIndex).Value)




        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        txtCheckNo.Clear()
        txtDrawer.Clear()
        'txtDraweeBankCode.Clear()
        'lblDraweeBankName.Text = ""
        'txtDraweeBranch.Clear()
        txtCheckDate.Clear()
        txtAmount.Text = "0"
        'txtSlipDate.Clear()
        'txtCustomerRef.Clear()
        txtCheckRef.Clear()

    End Sub

    
    Private Sub txtSlipDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlipDate.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub txtCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCustomerRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{tab}")
            txtCheckNo.Focus()
        End If
    End Sub

    Private Sub txtCheckRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDrawer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDrawer.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDraweeBranch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtSlipDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSlipDate.Validating
        If CommonUtil.DateValidate(txtSlipDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtCheckDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCheckDate.Validating
        If CommonUtil.DateValidate(txtCheckDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTotalAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalAmount.TextChanged
        lblTotalAmountDummy.Text = NullHelper.ToDecNum(txtTotalAmount.Text).ToString("N")
    End Sub

    Private Sub txtDepoCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDepoCode.Validating

        If txtDepoCode.Text.Trim() <> "" Then

            lblToolStatus.Text = ""

            LoadDepositSlipData(txtDepoCode.Text.Trim())

            If Not txtDepoCode.Text.Trim() = "" Then

                txtDepoCode.ReadOnly = True
                'txtCheckNo.Focus()

                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CSD_GetMaxMod")

                    commProc2.Parameters.Clear()

                    db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())

                    Dim intModNo As Integer = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()

                    If intModNo > 0 Then

                        LoadMainData(txtDepoCode.Text.Trim(), intModNo)
                        LoadDetailData(txtDepoCode.Text.Trim(), intModNo)

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Else
                MessageBox.Show("Invalid Deposit Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDepoCode.Focus()
            End If


        End If
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If CommonUtil.DecValidate(txtAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub lblSlipInvoiceForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSlipInvoiceForm.Click
        'FrmInvoice.frmNm = "FrmCitiSpeedDetailSlip"
        Dim frmInvoice As New FrmInvoice
        frmInvoice.frmNm = "FrmCitiSpeedDetailSlip"
        frmInvoice.ShowDialog()
    End Sub

    Private Sub lblCheckInvoiceForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCheckInvoiceForm.Click
        Dim frmInvoice As New FrmInvoice
        frmInvoice.frmNm = "FrmCitiSpeedDetailCheck"
        frmInvoice.ShowDialog()
    End Sub
End Class