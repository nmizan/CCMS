Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmFGDet


#Region "Global Variables"

    Dim _formMode As FormTransMode
    Dim _intSlno As Integer = 0
    Dim _intModno As Integer = 0
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


        cmbDept.Enabled = False

    End Sub

    Private Sub EnableFields()


        txtId.ReadOnly = False


        txtName.ReadOnly = False

        cmbDept.Enabled = True


    End Sub


    Private Sub ClearFields()
        txtId.Clear()
        txtName.Clear()



    End Sub

    Private Sub ClearFieldsAll()
        txtId.Clear()
        txtName.Clear()


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

        If txtId.Text.Trim() = "" Then
            MessageBox.Show("Id required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtId.Focus()
            Return False
        ElseIf txtName.Text.Trim() = "" Then
            MessageBox.Show("Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtName.Focus()
            Return False
        ElseIf cmbDept.Text.Trim() = "" Then
            MessageBox.Show("Department required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbDept.Focus()
            Return False
        End If


        Return True

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim strSql As String

        Dim intSlno As Integer = 0

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)



        If _formMode = FormTransMode.Add Then

            intSlno = db.ExecuteDataSet(CommandType.Text, "select ISNULL(max(SLNO),0)+1 maxslno from F_GROUP").Tables(0).Rows(0)(0)


            strSql = "insert into F_GROUP(SLNO, FG_ID,FG_NAME,APP_SLNO,DEPT_SLNO,MODNO, " + _
                " INPUT_BY, INPUT_DATETIME, IS_AUTHORIZED,  " + _
                " STATUS) values(@P_Slno, @P_Fg_Id, @P_Fg_Name,@P_App_Slno,@P_Dept_Slno, " + _
                " 1, @P_Input_By, getdate(), 0, 'U')"


            Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)

            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@P_Slno", DbType.Int64, intSlno)
            db.AddInParameter(commProc, "@P_Fg_Id", DbType.String, txtId.Text.Trim())
            db.AddInParameter(commProc, "@P_Fg_Name", DbType.String, txtName.Text.Trim())
            'db.AddInParameter(commProc, "@P_App_Slno", DbType.Int16, cmbApp.SelectedValue)
            db.AddInParameter(commProc, "@P_Dept_Slno", DbType.Int16, cmbDept.SelectedValue)
            db.AddInParameter(commProc, "@P_Input_By", DbType.String, CommonAppSet.User)




            Dim result As Integer
            result = db.ExecuteNonQuery(commProc)
            If result < 0 Then
                tStatus = TransState.Exist

            Else
                tStatus = TransState.Add
                _intSlno = intSlno
                _intModno = 1
            End If



        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                db.ExecuteNonQuery(trans, CommandType.Text, "delete F_GROUP where SLNO=" & _intSlno.ToString() & " and IS_AUTHORIZED=0")
                Dim ds As New DataSet


                strSql = "select isnull(max(MODNO),0)+1 maxmodno from F_GROUP where SLNO=" & _intSlno.ToString()


                intModno = db.ExecuteDataSet(trans, CommandType.Text, strSql).Tables(0).Rows(0)(0)

                strSql = "insert into F_GROUP(SLNO,FG_ID,FG_NAME,APP_SLNO,DEPT_SLNO, MODNO, " & _
                " INPUT_BY, INPUT_DATETIME, IS_AUTHORIZED,  " & _
                " STATUS) values(@P_Slno, @P_Fg_Id,@P_Fg_Name, @P_App_Slno,@P_Dept_Slno, " _
                & intModno.ToString() & ", @P_Input_By, getdate(), 0, 'U')"


                Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)


                commProc.Parameters.Clear()
                db.AddInParameter(commProc, "@P_Slno", DbType.Int64, _intSlno)
                db.AddInParameter(commProc, "@P_Fg_Id", DbType.String, txtId.Text.Trim())
                db.AddInParameter(commProc, "@P_Fg_Name", DbType.String, txtName.Text.Trim())
                'db.AddInParameter(commProc, "@P_App_Slno", DbType.Int16, cmbApp.SelectedValue)
                db.AddInParameter(commProc, "@P_Dept_Slno", DbType.Int16, cmbDept.SelectedValue)
                db.AddInParameter(commProc, "@P_Input_By", DbType.String, CommonAppSet.User)

                Dim result As Integer
                result = db.ExecuteNonQuery(commProc, trans)
                If result < 0 Then
                    tStatus = TransState.Exist

                Else
                    tStatus = TransState.Update
                    _intModno = intModno
                End If

                trans.Commit()

            End Using


        End If


        Return tStatus

    End Function

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState

        Dim strSql As String

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Using conn As DbConnection = db.CreateConnection()

            conn.Open()

            Dim trans As DbTransaction = conn.BeginTransaction()

            strSql = "select IS_AUTHORIZED,STATUS from F_GROUP where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString()

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(trans, CommandType.Text, strSql)

            If ds.Tables(0).Rows(0)("IS_AUTHORIZED") = 0 Then

                If ds.Tables(0).Rows(0)("STATUS") = "U" Then
                    strSql = "update F_GROUP set AUTH_BY='" & CommonAppSet.User.Trim() & _
                    "', AUTH_DATETIME=getdate(), IS_AUTHORIZED=1, STATUS = 'L' " & _
                    " where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString()

                ElseIf ds.Tables(0).Rows(0)("STATUS") = "D" Then
                    strSql = "update F_GROUP set AUTH_BY='" & CommonAppSet.User.Trim() & _
                    "', AUTH_DATETIME=getdate(), IS_AUTHORIZED=1 " & _
                    " where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString()

                End If



                Dim result As Integer
                result = db.ExecuteNonQuery(trans, CommandType.Text, strSql)

                If result <= 0 Then

                    tStatus = TransState.NoRecord

                ElseIf result > 0 Then

                    If _intModno > 1 Then

                        'if previous modification status is D(Deleted) then make it C(Closed)
                        strSql = "update F_GROUP set STATUS = 'C' " & _
                            " where SLNO=" & _intSlno & " and MODNO=" & (_intModno - 1).ToString() & _
                            " and STATUS ='D'"

                        db.ExecuteNonQuery(trans, CommandType.Text, strSql)

                        'if previous modification status is L(Deleted) then make it O(Open)
                        strSql = "update F_GROUP set STATUS = 'O' " & _
                            " where SLNO=" & _intSlno & " and MODNO=" & (_intModno - 1).ToString() & _
                            " and STATUS ='L'"

                        db.ExecuteNonQuery(trans, CommandType.Text, strSql)



                    End If
                    tStatus = TransState.Update
                End If
            Else
                tStatus = TransState.UpdateNotPossible
            End If

            trans.Commit()

        End Using

        Return tStatus


    End Function



    Private Sub LoadGroupData(ByVal intSlno As Integer, ByVal intmod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet
            ds = db.ExecuteDataSet(CommandType.Text, "select * from F_GROUP where SLNO=" & intSlno.ToString() & " and MODNO=" & intmod.ToString())

            If ds.Tables(0).Rows.Count > 0 Then

                _intModno = intmod
                _intSlno = intSlno

                _formMode = FormTransMode.Update

                txtId.Text = ds.Tables(0).Rows(0)("FG_ID").ToString()
                txtName.Text = ds.Tables(0).Rows(0)("FG_NAME").ToString()

                cmbDept.SelectedValue = ds.Tables(0).Rows(0)("DEPT_SLNO")


                lblInputBy.Text = ds.Tables(0).Rows(0)("INPUT_BY").ToString()
                lblInputDate.Text = ds.Tables(0).Rows(0)("INPUT_DATETIME").ToString()
                lblAuthBy.Text = ds.Tables(0).Rows(0)("AUTH_BY").ToString()
                lblAuthDate.Text = ds.Tables(0).Rows(0)("AUTH_DATETIME").ToString()

                chkAuthorized.Checked = ds.Tables(0).Rows(0)("IS_AUTHORIZED")

                If ds.Tables(0).Rows(0)("STATUS") = "L" Or ds.Tables(0).Rows(0)("STATUS") = "U" Or ds.Tables(0).Rows(0)("STATUS") = "O" Then
                    chkOpen.Checked = True
                Else
                    chkOpen.Checked = False
                End If
                lblModNo.Text = ds.Tables(0).Rows(0)("MODNO").ToString()

                lblVerNo.Text = ds.Tables(0).Rows(0)("MODNO").ToString()

                lblVerTot.Text = db.ExecuteDataSet(CommandType.Text, "select count(MODNO) 'totver' from F_GROUP where SLNO=" & intSlno.ToString()).Tables(0).Rows(0)(0).ToString()


            Else
                '_intModno = 0
                '_intSlno = 0

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

        Dim strSql As String = ""

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Using conn As DbConnection = db.CreateConnection()

            conn.Open()

            Dim trans As DbTransaction = conn.BeginTransaction()


            strSql = "select IS_AUTHORIZED,STATUS from F_GROUP where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString()

            Dim ds As New DataSet
            ds = db.ExecuteDataSet(trans, CommandType.Text, strSql)

            If ds.Tables(0).Rows.Count > 0 Then

                If ds.Tables(0).Rows(0)(0) = False Then 'if not authorized

                    strSql = "delete F_GROUP where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString() & " and IS_AUTHORIZED=0"

                    db.ExecuteNonQuery(trans, CommandType.Text, strSql)

                    _intModno = _intModno - 1

                    tStatus = TransState.Delete


                ElseIf ds.Tables(0).Rows(0)(0) = True Then 'if authorized

                    If ds.Tables(0).Rows(0)("STATUS") = "L" Then 'if this is the last modified data

                        strSql = "delete F_GROUP where SLNO=" & _intSlno.ToString() & " and IS_AUTHORIZED=0"

                        db.ExecuteNonQuery(trans, CommandType.Text, strSql)

                        strSql = "select * from F_GROUP where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString()

                        Dim dsKeeper As New DataSet
                        dsKeeper = db.ExecuteDataSet(trans, CommandType.Text, strSql)


                        strSql = "select isnull(max(MODNO),0)+1 maxmodno from F_GROUP where SLNO=" & _intSlno.ToString()


                        intModno = db.ExecuteDataSet(trans, CommandType.Text, strSql).Tables(0).Rows(0)(0)

                        strSql = "insert into F_GROUP(SLNO,FG_ID,FG_NAME,APP_SLNO,DEPT_SLNO, MODNO, " & _
                            " INPUT_BY, INPUT_DATETIME, IS_AUTHORIZED,  " & _
                            " STATUS) values(@P_Slno, @P_Fg_Id, @P_Fg_Name, @P_App_Slno,@P_Dept_Slno, " _
                            & intModno.ToString() & ", @P_Input_By, getdate(), 0, 'D')"

                        Dim commProc As DbCommand = db.GetSqlStringCommand(strSql)


                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@P_Slno", DbType.Int64, _intSlno)
                        db.AddInParameter(commProc, "@P_Fg_Id", DbType.String, dsKeeper.Tables(0).Rows(0)("USERS_ID").ToString())
                        db.AddInParameter(commProc, "@P_Fg_Name", DbType.String, dsKeeper.Tables(0).Rows(0)("USERNAME").ToString())
                        db.AddInParameter(commProc, "@P_App_Slno", DbType.Int16, dsKeeper.Tables(0).Rows(0)("APP_SLNO"))
                        db.AddInParameter(commProc, "@P_Dept_Slno", DbType.Int16, dsKeeper.Tables(0).Rows(0)("DEPT_SLNO"))
                        db.AddInParameter(commProc, "@P_Input_By", DbType.String, CommonAppSet.User)

                        Dim result As Integer
                        result = db.ExecuteNonQuery(commProc, trans)
                        If result < 0 Then
                            tStatus = TransState.Exist

                        Else
                            tStatus = TransState.Delete
                            _intModno = intModno
                        End If

                    Else

                        tStatus = TransState.UpdateNotPossible



                    End If





                End If


            Else
                tStatus = TransState.NoRecord
            End If

            trans.Commit()


        End Using



        Return tStatus

    End Function

    Private Function CheckForDelete() As Boolean

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim strSql As String = ""

        strSql = "select IS_AUTHORIZED,STATUS from F_GROUP where SLNO=" & _intSlno.ToString() & " and MODNO=" & _intModno.ToString()

        Dim ds As New DataSet

        ds = db.ExecuteDataSet(CommandType.Text, strSql)

        If ds.Tables(0).Rows(0)("STATUS") = "O" Then
            MessageBox.Show("You can only delete last authorized and modified data", "!! STOP Delet !!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        ElseIf ds.Tables(0).Rows(0)("STATUS") = "C" Then
            MessageBox.Show("You can only delete last authorized and modified data", "!! STOP Delet !!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If





        Return True
    End Function

#End Region






    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmDept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'txtAuthBy.ForeColor = Color.Maroon
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmFGDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        CommonUtil.FillComboBox("select SLNO,DEPT_ID from DEPARTMENT where STATUS='L'", cmbDept)

        If _intModno > 0 Then
            LoadGroupData(_intSlno, _intModno)
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

    Public Sub New(ByVal intSlno As Integer, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _intSlno = intSlno

        _intModno = intmod

        'LoadUserData(strUserId, intmod)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        EnableNew()

        EnableClear()

        If _intSlno > 0 Then

            EnableFields()

            EnableSave()

            EnableRefresh()

            EnableDelete()

            If chkAuthorized.Checked = False Then
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

                        LoadGroupData(_intSlno, _intModno)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Update


                        EnableDelete()

                        EnableRefresh()


                    ElseIf tState = TransState.Update Then

                        LoadGroupData(_intSlno, _intModno)

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
        LoadGroupData(_intSlno, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try

            If CheckForDelete() = True Then

                If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    tState = DeleteData()

                    If tState = TransState.Delete Then


                        _formMode = FormTransMode.Add

                        LoadGroupData(_intSlno, _intModno)

                        DisableAuth()

                        If _intSlno = 0 Then

                            DisableDelete()
                            DisableSave()
                            DisableRefresh()
                            DisableFields()



                        End If

                        lblToolStatus.Text = "!! Information Deleted Successfully !!"

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

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevVer.Click
        If _intModno - 1 > 0 Then
            LoadGroupData(_intSlno, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim intSlno As Integer = _intSlno
        Dim intModno As Integer = _intModno

        LoadGroupData(_intSlno, _intModno + 1)

        If _intModno = 0 Then
            LoadGroupData(intSlno, intModno)
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadGroupData(_intSlno, _intModno)
                    lblToolStatus.Text = "!! Authorized Successfully !!"
                    DisableAuth()

                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Failed! Authorized info can't be authorized again !!"
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
End Class