' 
' Maintain Users Function Group
' Author: Iftekharul Alam Khan Lodi
' Since: 19-Nov-12   
'


Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports CCMS.Common


Public Class FrmUsersFGDet

#Region "Global Variables"

    Dim _formName As String = "SystemAssignFGUserDetail"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)

    Dim _formMode As FormTransMode
    'Dim _intSlno As Integer = 0
    Dim _strUsersId As String = ""
    Dim _intModno As Integer = 0

    Dim _mod_datetime As Date
    Dim _status As String = ""

    Dim _intDeptSlno As Integer = 0

    Dim _intSelectedRowIndexOfAv = -1
    Dim _intSelectedRowIndexOfSl = -1

    Dim fg_prev(100) As String    
    Dim fg_new(100) As String
    Dim fg_removed As String = ""
    Dim fg_added As String = ""

#End Region


#Region "User Defined Code"

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

        btnSearch.Enabled = False



        btnAdd.Enabled = False
        btnRemove.Enabled = False




    End Sub

    Private Sub EnableFields()
        

        txtId.ReadOnly = False

        btnSearch.Enabled = True

        btnAdd.Enabled = True
        btnRemove.Enabled = True

    End Sub

    Private Sub ClearFields()

        dgAvailable.AllowUserToAddRows = False
        dgSelected.AllowUserToAddRows = False

        dgSelected.Rows.Clear()


    End Sub

    Private Sub ClearFieldsAll()

        txtId.Clear()


        lblUserName.Text = ""
        lblDept.Text = ""

        _intDeptSlno = 0

        _strUsersId = ""
        _intModno = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""

        dgAvailable.Rows.Clear()
        dgSelected.Rows.Clear()

        dgAvailable.AllowUserToAddRows = False
        dgSelected.AllowUserToAddRows = False

    End Sub

    Private Function CheckValidData() As Boolean

        If txtId.Text.Trim() = "" Or _strUsersId = "" Then
            MessageBox.Show("ID required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtId.Focus()
            Return False
        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim strUserId As String = ""

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)


        If _formMode = FormTransMode.Add Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@USERS_ID", DbType.String, _strUsersId)

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

                    Dim commProcForm As DbCommand = db.GetStoredProcCommand("CMS_UsersFGDet_Add")

                    For i = 0 To dgSelected.Rows.Count - 1

                        commProcForm.Parameters.Clear()

                        db.AddInParameter(commProcForm, "@USERS_ID", DbType.String, _strUsersId)
                        db.AddInParameter(commProcForm, "@FG_SLNO", DbType.Int64, dgSelected.Rows(i).Cells(0).Value)
                        
                        db.AddParameter(commProcForm, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcForm, trans)

                        If db.GetParameterValue(commProcForm, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Add

                    _intModno = 1

                End If

                trans.Commit()

            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@USERS_ID", DbType.String, _strUsersId)
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

                    Dim commProcForm As DbCommand = db.GetStoredProcCommand("CMS_UsersFGDet_Update")

                    For i = 0 To dgSelected.Rows.Count - 1

                        commProcForm.Parameters.Clear()

                        db.AddInParameter(commProcForm, "@USERS_ID", DbType.String, _strUsersId)
                        db.AddInParameter(commProcForm, "@FG_SLNO", DbType.Int64, dgSelected.Rows(i).Cells(0).Value)
                        db.AddInParameter(commProcForm, "@MOD_NO", DbType.Int32, intModno)

                        db.AddParameter(commProcForm, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcForm, trans)

                        If db.GetParameterValue(commProcForm, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next




                    tStatus = TransState.Update
                    _intModno = intModno

                    trans.Commit()

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@USERS_ID", DbType.String, _strUsersId)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

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




    Private Sub LoadGroupList(ByVal intDeptSlno As Integer)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_FGroup_GetListByDeptCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DEPT_SLNO", DbType.Int32, intDeptSlno)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            dgAvailable.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgAvailable.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgAvailable.Rows.Count - 1) Then
                        dgAvailable.Rows.Add()
                    End If
                    dgAvailable.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgAvailable.Item(1, i).Value = dt.Rows(i)("FG_ID")
                Next
                dgAvailable.AllowUserToAddRows = False

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadUserInfo(ByVal strUserId As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@USERS_ID", DbType.String, strUserId)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            ClearFieldsAll()

            If dt.Rows.Count > 0 Then

                _formMode = FormTransMode.Add

                txtId.Text = dt.Rows(0)("USERS_ID").ToString()
                lblUserName.Text = dt.Rows(0)("USERS_NAME").ToString()
                lblDept.Text = dt.Rows(0)("DEPT_NAME").ToString()

                _strUsersId = dt.Rows(0)("USERS_ID").ToString()

                Dim commProcMax As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_GetMaxMod")

                commProcMax.Parameters.Clear()

                db.AddInParameter(commProcMax, "@USERS_ID", DbType.String, strUserId)

                Dim intMod As Integer = db.ExecuteDataSet(commProcMax).Tables(0).Rows(0)(0)
                If intMod > 0 Then
                    LoadUserGroupInfo(strUserId, intMod)
                Else
                    ClearFields()

                    LoadGroupList(dt.Rows(0)("DEPT_SLNO"))
                End If

            Else
                ClearFieldsAll()


            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub LoadUserGroupInfo(ByVal strUserId As String, ByVal intmod As Integer)


        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@USERS_ID", DbType.String, strUserId)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intmod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strUsersId = strUserId
                _intModno = intmod

                _formMode = FormTransMode.Update

                txtId.Text = ds.Tables(0).Rows(0)("USERS_ID").ToString()
                lblUserName.Text = ds.Tables(0).Rows(0)("USERS_NAME").ToString()
                lblDept.Text = ds.Tables(0).Rows(0)("DEPT_NAME")

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

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@USERS_ID", DbType.String, strUserId)

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

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim = CommonAppSet.User) _
                    And btnUnlock.Enabled = False Then
                    EnableAuth()
                Else
                    DisableAuth()
                End If

                Dim dt As New DataTable

                Dim commProcSel As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_GetSelFG")

                commProcSel.Parameters.Clear()

                db.AddInParameter(commProcSel, "@USERS_ID", DbType.String, strUserId)
                db.AddInParameter(commProcSel, "@MOD_NO", DbType.Int32, intmod)

                dt = db.ExecuteDataSet(commProcSel).Tables(0)

                dgSelected.Rows.Clear()

                dgSelected.AllowUserToAddRows = True
                'fg_prev = Nothing
                For i = 0 To fg_prev.Length - 1
                    fg_prev(i) = Nothing
                Next
                fg_prev(0) = "Yasir"
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgSelected.Rows.Count - 1) Then
                        dgSelected.Rows.Add()
                    End If
                    dgSelected.Item(0, i).Value = dt.Rows(i)("SLNO")
                    dgSelected.Item(1, i).Value = dt.Rows(i)("FG_ID")
                    fg_prev(i) = dgSelected.Item(1, i).Value.ToString
                    fg_prev(i + 1) = "Yasir"
                Next
                dgSelected.AllowUserToAddRows = False

                '''''''''''''''''''''''''''''''''''''''

                Dim commProcAvail As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_GetAvailFG")

                commProcAvail.Parameters.Clear()

                db.AddInParameter(commProcAvail, "@USERS_ID", DbType.String, strUserId)
                db.AddInParameter(commProcAvail, "@MOD_NO", DbType.Int32, intmod)

                dt = db.ExecuteDataSet(commProcAvail).Tables(0)

                dgAvailable.Rows.Clear()

                dgAvailable.AllowUserToAddRows = True
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        If (i = dgAvailable.Rows.Count - 1) Then
                            dgAvailable.Rows.Add()
                        End If
                        dgAvailable.Item(0, i).Value = dt.Rows(i)("SLNO")
                        dgAvailable.Item(1, i).Value = dt.Rows(i)("FG_ID")
                    Next


                End If
                dgAvailable.AllowUserToAddRows = False

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

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_UsersFG_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@USERS_ID", DbType.String, _strUsersId)
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

    Public Sub New(ByVal strUserId As String, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'LoadGroupData(intSlno, intmod)
        'LoadFormMenuData(intSlno, intmod)

        _strUsersId = strUserId

        _intModno = intmod
    End Sub





#End Region


    Private Sub FrmUsersFGDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intModno > 0 Then

            LoadUserGroupInfo(_strUsersId, _intModno)
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
        If Not (_strUsersId = "") Then

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

        If txtId.ReadOnly = False Then
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

                        genAddLog()

                        If (fg_added <> "Arafat") Then
                            Logger.system_log(" Added : Functional Group (s) For User ID  " + " " + txtId.Text.ToString() + " : " + " " + fg_added)
                        End If

                        LoadUserGroupInfo(_strUsersId, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        'EnableDelete()

                        'EnableRefresh()



                        EnableUnlock()
                        DisableNew()
                        DisableSave()
                        DisableDelete()
                        DisableAuth()
                        DisableClear()
                        DisableRefresh()
                        DisableFields()


                    ElseIf tState = TransState.Update Then

                        genLog()

                        If (fg_added <> "Arafat" And fg_removed = "Arafat") Then
                            Logger.system_log(" Added : Functional Group (s) For User ID  " + " " + txtId.Text.ToString() + " " + " : " + " " + fg_added)
                        ElseIf (fg_added = "Arafat" And fg_removed <> "Arafat") Then
                            Logger.system_log(" Removed : Functional Group (s) From User ID  " + " " + txtId.Text.ToString() + " " + " : " + " " + fg_removed)
                        ElseIf (fg_added <> "Arafat" And fg_removed <> "Arafat") Then
                            Logger.system_log(" Added : Functional Group(s) : " + fg_added + " " + " and  Removed : Functional Group (s) : " + " " + fg_removed + " " + " For User ID : " + txtId.Text.ToString())
                        End If

                        LoadUserGroupInfo(_strUsersId, _intModno)

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
    Private Sub genLog()
        Dim j As Int32 = 0
        genAddLog()
        fg_removed = "Arafat"
        While fg_prev(j) <> "Yasir"
            If (Not fg_new.Contains(fg_prev(j))) Then
                If (fg_removed = "Arafat") Then
                    fg_removed = fg_prev(j)
                Else
                    fg_removed = fg_removed + ", " + fg_prev(j)
                End If
            End If
            j = j + 1
        End While
    End Sub
    Private Sub genAddLog()
        Dim j As Int32 = 0
        For i = 0 To fg_new.Length - 1
            fg_new(i) = Nothing
        Next
        fg_new(0) = "Yasir"
        For i = 0 To dgSelected.Rows.Count - 1
            fg_new(i) = dgSelected.Item(1, i).Value
            fg_new(i + 1) = "Yasir"
        Next
        fg_added = "Arafat"
        While fg_new(j) <> "Yasir"
            If (Not fg_prev.Contains(fg_new(j))) Then
                If (fg_added = "Arafat") Then
                    fg_added = fg_new(j)
                Else
                    fg_added = fg_added + ", " + fg_new(j)
                End If
            End If
            j = j + 1
        End While
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadUserGroupInfo(_strUsersId, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then

                    Logger.system_log("Roles for User Id :" + txtId.Text.ToString() + " Deleted")

                    _formMode = FormTransMode.Add

                    LoadUserGroupInfo(_strUsersId, _intModno)

                    DisableAuth()

                    If _strUsersId = "" Then

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
            LoadUserGroupInfo(_strUsersId, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strUserId As String = _strUsersId
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadUserGroupInfo(_strUsersId, _intModno + 1)

            If _intModno = 0 Then
                LoadUserGroupInfo(strUserId, intModno)
            End If
        End If
    End Sub
    

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not txtId.Text.Trim() = "" Then
            LoadUserInfo(txtId.Text.Trim())

        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If dgAvailable.SelectedRows.Count = 0 Then Exit Sub

        dgSelected.Rows.Add()
        Dim maxSelRow As Integer = dgSelected.Rows.Count - 1
        dgSelected.Item(0, maxSelRow).Value = dgAvailable.SelectedRows.Item(0).Cells(0).Value
        dgSelected.Item(1, maxSelRow).Value = dgAvailable.SelectedRows.Item(0).Cells(1).Value
        'dgSelected.Item(2, maxSelRow).Value = dgAvailable.SelectedRows.Item(0).Cells(2).Value
        dgSelected.Rows(0).Selected = True
        dgSelected.Rows(0).Selected = False
        dgSelected.Rows(maxSelRow).Selected = True

        For Each row As DataGridViewRow In dgAvailable.SelectedRows
            dgAvailable.Rows.Remove(row)
        Next


        'If Not _intSelectedRowIndexOfAv = -1 Then
        '    dgSelected.Rows.Add()
        '    dgSelected.Item(0, 1).Value = dgAvailable.Rows(_intSelectedRowIndexOfAv).Ce
        '    dgSelected.Item(1, 1).Value = dgAvailable.SelectedCells(1).Value
        '    dgSelected.Item(2, 1).Value = dgAvailable.SelectedCells(2).Value
        'End If


    End Sub

    
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        If dgSelected.SelectedRows.Count = 0 Then Exit Sub

        dgAvailable.Rows.Add()
        Dim maxAvlRow As Integer = dgAvailable.Rows.Count - 1
        dgAvailable.Item(0, maxAvlRow).Value = dgSelected.SelectedRows.Item(0).Cells(0).Value
        dgAvailable.Item(1, maxAvlRow).Value = dgSelected.SelectedRows.Item(0).Cells(1).Value
        'dgAvailable.Item(2, maxAvlRow).Value = dgSelected.SelectedRows.Item(0).Cells(2).Value
        dgAvailable.Rows(0).Selected = True
        dgAvailable.Rows(0).Selected = False
        dgAvailable.Rows(maxAvlRow).Selected = True

        For Each row As DataGridViewRow In dgSelected.SelectedRows
            dgSelected.Rows.Remove(row)
        Next
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    fg_added = "Arafat"
                    For i = 0 To dgSelected.Rows.Count - 1                      
                        If (fg_added = "Arafat") Then
                            fg_added = dgSelected.Item(1, i).Value
                        Else
                            fg_added = fg_added + ", " + dgSelected.Item(1, i).Value
                        End If
                    Next

                    If (fg_added = "Arafat") Then
                        Logger.system_log(" Authorized : Functional Group(s) for User ID : " + txtId.Text.ToString() + ", with no selected Functional Group(s).")
                    Else
                        Logger.system_log(" Authorized : Functional Group(s) for User ID : " + txtId.Text.ToString() + ", with selected Functional Group(s) : " + fg_added)
                    End If

                    LoadUserGroupInfo(_strUsersId, _intModno)
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

    
    
   
   
    Private Sub txtId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not txtId.Text.Trim() = "" Then
                LoadUserInfo(txtId.Text.Trim())

            End If
        End If
    End Sub
End Class