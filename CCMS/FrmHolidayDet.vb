'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Delivery Schedule Detail
'Creation date      : 16-Jan-2013
'Stored Procedure(s):  
'
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmHolidayDet



#Region "Global Variables"

    Dim _formName As String = "MaintenanceHolidayDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    Dim _strHoliDay As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String

    'For Update
    Dim _cmbholidayType As String = ""
    'For Auth
    Dim _acmbholidayType As String = ""

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

        rdoAnnual.Enabled = False
        txtUpto.ReadOnly = True
        cmbWeekDay.Enabled = False
        rdoSingle.Enabled = False
        txtSingleDay.ReadOnly = True
        cmbHoliType.Enabled = False

    End Sub

    Private Sub EnableFields()


        If _intModno = 0 Then

            rdoAnnual.Enabled = True

            rdoAnnual.Checked = True

            txtUpto.ReadOnly = False
            cmbWeekDay.Enabled = True

            rdoSingle.Enabled = True

            txtSingleDay.ReadOnly = True
            cmbHoliType.Enabled = False
        Else
            rdoSingle.Checked = True
        End If



        If rdoSingle.Checked = True Then

            txtSingleDay.ReadOnly = True
            cmbHoliType.Enabled = True
        End If
        

    End Sub


    Private Sub ClearFields()

        

    End Sub

    Private Sub ClearFieldsAll()


        txtUpto.Clear()
        txtSingleDay.Clear()

        _strHoliDay = ""
        _intModno = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""


    End Sub

    'Private Sub ShowOpertionStatus()

    '    Dim CashTotal As Decimal = 0
    '    Dim CheckTotal As Decimal = 0
    '    Dim CheckNoTotal As Integer = 0

    '    Dim MsgStatus As String = ""


    '    For Each row As DataGridViewRow In dgView.Rows

    '        CashTotal = CashTotal + NullHelper.ToDecNum(row.Cells(4).Value)
    '        CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(3).Value)

    '        CheckNoTotal = CheckNoTotal + NullHelper.ToIntNum(row.Cells(2).Value)

    '    Next

    '    If NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim()) <> CashTotal Then
    '        Dim diffCash As Decimal = CashTotal - NullHelper.ToDecNum(txtTotalCashAmount.Text.Trim())

    '        'MsgStatus = "Mismatch in TotalCheck amount:  " & Format(diffCash , "#,##,##,##,##0.00")
    '        MsgStatus = "Mismatch in Total Cash amount:  " & diffCash.ToString() & Environment.NewLine

    '    End If

    '    If NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()) <> CheckTotal Then

    '        Dim diffCheck As Decimal = CheckTotal - NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim())
    '        MsgStatus = MsgStatus + "Mismatch in Total Check amount:  " & diffCheck.ToString() & Environment.NewLine

    '    End If

    '    If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then

    '        Dim diffCheckNo As Integer = CheckNoTotal - NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim())
    '        MsgStatus = MsgStatus + "Mismatch in Total Check No:  " & diffCheckNo.ToString() & Environment.NewLine

    '    End If

    '    If MsgStatus.Trim() <> "" Then
    '        MessageBox.Show(MsgStatus, "Mismatch Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If



    'End Sub

    Private Function CheckValidData() As Boolean

        If rdoAnnual.Checked = True Then

            If txtUpto.Text.Trim() = "/  /" Then
                MessageBox.Show("Upto date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUpto.Focus()
                Return False
            ElseIf cmbWeekDay.Text.Trim() = "" Or cmbWeekDay.SelectedIndex = -1 Then
                MessageBox.Show("Select week day !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbWeekDay.Focus()
                Return False

            Else

                Dim dt1 As New DateTime()
                dt1 = NullHelper.StringToDate(txtUpto.Text)

                Dim dt2 As New DateTime()
                dt2 = DateTime.Now()

                If dt1 <= dt2 Then
                    MessageBox.Show("Use date higher than today")
                    txtUpto.Focus()
                    Return False
                End If

            End If

        Else

            If txtSingleDay.Text.Trim() = "/  /" Then
                MessageBox.Show("Date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSingleDay.Focus()
                Return False
            ElseIf cmbHoliType.Text.Trim() = "" Or cmbHoliType.SelectedIndex = -1 Then
                MessageBox.Show("Select Holiday Type !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbHoliType.Focus()
                Return False
            
            End If

        End If

       


        'ShowOpertionStatus()



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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Holiday_Add")

                Dim result As Integer

                If rdoAnnual.Checked = True Then

                    Dim dt1 As New DateTime()
                    dt1 = NullHelper.StringToDate(txtUpto.Text)

                    Dim dt2 As New DateTime()

                    dt2 = DateTime.Today()

                    'dt2 = NullHelper.StringToDate(DateTime.Now().ToString("dd/MM/yyyy"))


                    Dim weekday As DayOfWeek

                    If cmbWeekDay.SelectedIndex = 0 Then
                        weekday = DayOfWeek.Sunday
                    ElseIf cmbWeekDay.SelectedIndex = 1 Then
                        weekday = DayOfWeek.Monday
                    ElseIf cmbWeekDay.SelectedIndex = 2 Then
                        weekday = DayOfWeek.Tuesday
                    ElseIf cmbWeekDay.SelectedIndex = 3 Then
                        weekday = DayOfWeek.Wednesday
                    ElseIf cmbWeekDay.SelectedIndex = 4 Then
                        weekday = DayOfWeek.Thursday
                    ElseIf cmbWeekDay.SelectedIndex = 5 Then
                        weekday = DayOfWeek.Friday
                    ElseIf cmbWeekDay.SelectedIndex = 6 Then
                        weekday = DayOfWeek.Saturday
                    End If

                    Dim myCal As Calendar = CultureInfo.InvariantCulture.Calendar

                    While dt2 <= dt1

                        If myCal.GetDayOfWeek(dt2) = weekday Then

                            commProc.Parameters.Clear()

                            db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, dt2)
                            db.AddInParameter(commProc, "@HOLI_TYPE", DbType.String, "Weekly Holiday")

                            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                            db.ExecuteNonQuery(commProc, trans)
                            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                            If result <> 0 Then
                                tStatus = TransState.Exist
                                trans.Rollback()
                                Return tStatus

                            End If


                        End If

                        dt2 = myCal.AddDays(dt2, 1)


                    End While

                    tStatus = TransState.Add

                    _intModno = 1



                Else

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(txtSingleDay.Text.Trim()))
                    db.AddInParameter(commProc, "@HOLI_TYPE", DbType.String, cmbHoliType.Text.Trim())

                    db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc, trans)
                    result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                    If result <> 0 Then
                        tStatus = TransState.Exist
                        trans.Rollback()
                        Return tStatus

                    End If

                    tStatus = TransState.Add
                    _strHoliDay = txtSingleDay.Text.Trim()
                    _intModno = 1


                End If


                trans.Commit()

            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Holiday_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(_strHoliDay))
                db.AddInParameter(commProc, "@HOLI_TYPE", DbType.String, cmbHoliType.Text)

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

                    tStatus = TransState.Update
                    _intModno = intModno

                    trans.Commit()
                    '------------Mizan Work (09-05-2016)------------

                   If _cmbholidayType <> cmbHoliType.Text Then
                        log_message = " Updated :  Holiday Type : " + _cmbholidayType + " " + " To " + " " + cmbHoliType.Text
                        Logger.system_log(log_message)
                    End If

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Holiday_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(_strHoliDay))
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (11-05-2016)------------

            If _acmbholidayType <> _cmbholidayType Then
                If _acmbholidayType = "" Then
                    log_message = " Authorized : Holiday Day : " + txtSingleDay.Text + "." + " " + " Holiday Type : " + _cmbholidayType
                Else
                    log_message = " Authorized : Holiday Day : " + txtSingleDay.Text + "." + " " + " Holiday Type : " + _acmbholidayType + " " + " To " + " " + _cmbholidayType
                End If
            Else
                log_message = " Authorized : Holiday Day : " + txtSingleDay.Text + "." + " " + " Holiday Type : " + cmbHoliType.Text
                Logger.system_log(log_message)
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

    '------------Mizan Work (11-05-2016)------------

    Private Sub LoadMainDataForAuth(ByVal strHoliday As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From HOLIDAY Where HOLI_DAY ='" & strHoliday & "' and STATUS='L'")
            
            If ds.Tables(0).Rows.Count > 0 Then

                _strHoliDay = strHoliday
                
                txtSingleDay.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("HOLI_DAY"))

                cmbHoliType.Text = ds.Tables(0).Rows(0)("HOLI_TYPE").ToString()
                _acmbholidayType = ds.Tables(0).Rows(0)("HOLI_TYPE").ToString()


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadMainData(ByVal strHoliday As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Holiday_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(strHoliday))
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intmod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strHoliDay = strHoliday
                _intModno = intmod

                _formMode = FormTransMode.Update



                txtSingleDay.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("HOLI_DAY"))

                cmbHoliType.Text = ds.Tables(0).Rows(0)("HOLI_TYPE").ToString()
                _cmbholidayType = ds.Tables(0).Rows(0)("HOLI_TYPE").ToString()
                

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Holiday_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(strHoliday))

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

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim().ToUpper() = CommonAppSet.User.Trim().ToUpper()) Then
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


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Holiday_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@HOLI_DAY", DbType.DateTime, NullHelper.StringToDate(_strHoliDay))
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

    Public Sub New(ByVal strHoliday As String, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strHoliDay = strHoliday

        _intModno = intmod

    End Sub


#End Region

    Private Sub FrmHolidayDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        If _intModno > 0 Then
            LoadMainData(_strHoliDay, _intModno)

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
        If Not (_strHoliDay = "") Then

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


            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim().ToUpper() = CommonAppSet.User.Trim().ToUpper()) Then
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



        txtUpto.Focus()



    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        LoadMainData(_strHoliDay, _intModno)


                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableUnlock()
                        DisableNew()
                        DisableSave()
                        DisableDelete()
                        DisableAuth()
                        DisableClear()
                        DisableRefresh()
                        DisableFields()



                    ElseIf tState = TransState.Update Then

                        LoadMainData(_strHoliDay, _intModno)

                        lblToolStatus.Text = "!! Information Updated Successfully !!"

                        EnableUnlock()
                        DisableNew()
                        DisableSave()
                        DisableDelete()
                        DisableAuth()
                        DisableClear()
                        DisableRefresh()
                        DisableFields()




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
        LoadMainData(_strHoliDay, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click


        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadMainData(_strHoliDay, _intModno)


                    DisableAuth()

                    If _strHoliDay = "" Then

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

            LoadMainData(_strHoliDay, _intModno - 1)


        End If


    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click

        Dim strHoliday As String = _strHoliDay
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_strHoliDay, _intModno + 1)

            If _intModno = 0 Then
                LoadMainData(strHoliday, intModno)
            End If

        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click


        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadMainDataForAuth(_strHoliDay)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_strHoliDay, _intModno)


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

    Private Sub rdoAnnual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAnnual.CheckedChanged

        If rdoAnnual.Checked = True Then
            txtUpto.ReadOnly = False
            cmbWeekDay.Enabled = True

            txtSingleDay.ReadOnly = True
            cmbHoliType.Enabled = False

        Else
            txtUpto.ReadOnly = True
            cmbWeekDay.Enabled = False

            If _intModno = 0 Then
                txtSingleDay.ReadOnly = False
            End If

            cmbHoliType.Enabled = True

            End If

    End Sub

    Private Sub txtUpto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUpto.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub txtSingleDay_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSingleDay.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class