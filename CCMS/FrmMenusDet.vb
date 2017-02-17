﻿' 
' Maintain Form and Menu list
' Author: Iftekharul Alam Khan Lodi
' Since: 18-Nov-12   
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmMenusDet

#Region "Global Variables"

    Dim _formMode As FormTransMode
    Dim _intSlno As Integer = 0
    Dim _intModno As Integer = 0
    Dim _boolIsForm As Boolean = True
    Dim _mod_datetime As Date
    Dim _status As String = ""
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
        txtName.ReadOnly = True
        chkForm.Enabled = False
        chkMenu.Enabled = False
    End Sub

    Private Sub EnableFields()

        txtName.ReadOnly = False

        If _intSlno = 0 Then
            chkForm.Enabled = True
            chkMenu.Enabled = True
        End If


    End Sub


    Private Sub ClearFields()

        txtName.Clear()

    End Sub

    Private Sub ClearFieldsAll()

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

        If txtName.Text.Trim() = "" Then
            MessageBox.Show("Name required!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtName.Focus()
            Return False
        End If


        Return True

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            If chkForm.Checked = True Then

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Form_Add")

                commProc.Parameters.Clear()


                db.AddInParameter(commProc, "@FORMS_NAME", DbType.String, txtName.Text.Trim())
                db.AddOutParameter(commProc, "@RET_SLNO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                If result = 0 Then
                    tStatus = TransState.Add

                    _intSlno = db.GetParameterValue(commProc, "@RET_SLNO")

                    _intModno = 1

                    _boolIsForm = True
                Else
                    tStatus = TransState.Exist
                End If

            ElseIf chkMenu.Checked = True Then

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Menu_Add")

                commProc.Parameters.Clear()


                db.AddInParameter(commProc, "@MENU_NAME", DbType.String, txtName.Text.Trim())
                db.AddOutParameter(commProc, "@RET_SLNO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                If result = 0 Then
                    tStatus = TransState.Add

                    _intSlno = db.GetParameterValue(commProc, "@RET_SLNO")

                    _intModno = 1

                    _boolIsForm = False
                Else
                    tStatus = TransState.Exist
                End If


            End If


        ElseIf _formMode = FormTransMode.Update Then

            If chkForm.Checked = True Then

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Form_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
                db.AddInParameter(commProc, "@FORMS_NAME", DbType.String, txtName.Text.Trim())
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                If result = 0 Then
                    tStatus = TransState.Update
                    _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")
                ElseIf result = 1 Then
                    tStatus = TransState.UnspecifiedError
                ElseIf result = 4 Then
                    tStatus = TransState.NoRecord
                End If


            ElseIf chkMenu.Checked = True Then

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Menu_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
                db.AddInParameter(commProc, "@MENU_NAME", DbType.String, txtName.Text.Trim())
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                If result = 0 Then
                    tStatus = TransState.Update
                    _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")
                ElseIf result = 1 Then
                    tStatus = TransState.UnspecifiedError
                ElseIf result = 4 Then
                    tStatus = TransState.NoRecord
                End If



            End If



        End If

        Return tStatus

    End Function

    Private Sub LoadFormMenuData(ByVal intSlno As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            If _boolIsForm = True Then

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Form_GetDetail")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@SLNO", DbType.Int32, intSlno)
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

                ds = db.ExecuteDataSet(commProc)

                If ds.Tables(0).Rows.Count > 0 Then

                    _intSlno = intSlno
                    _intModno = intMod

                    _formMode = FormTransMode.Update

                    txtName.Text = ds.Tables(0).Rows(0)("FORMS_NAME").ToString()

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

                    Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Form_GetMaxMod")

                    commProc2.Parameters.Clear()

                    db.AddInParameter(commProc2, "@SLNO", DbType.Int32, intSlno)

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

            Else 'Menu

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Menu_GetDetail")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@SLNO", DbType.Int32, intSlno)
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

                ds = db.ExecuteDataSet(commProc)

                If ds.Tables(0).Rows.Count > 0 Then

                    _intSlno = intSlno
                    _intModno = intMod

                    _formMode = FormTransMode.Update

                    txtName.Text = ds.Tables(0).Rows(0)("MENU_NAME").ToString()

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

                    Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Menu_GetMaxMod")

                    commProc2.Parameters.Clear()

                    db.AddInParameter(commProc2, "@SLNO", DbType.Int32, intSlno)

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

    Public Sub New(ByVal intSlno As Integer, ByVal intMod As Integer, ByVal boolIsForm As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _boolIsForm = boolIsForm

        LoadFormMenuData(intSlno, intMod)
        _intSlno = intSlno
        _intModno = intMod


    End Sub

    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _boolIsForm = True Then
            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Form_Auth")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
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

        Else 'menu

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Menu_Auth")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SLNO", DbType.Int32, _intSlno)
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


        End If

        
        Return tStatus

    End Function


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _boolIsForm = True Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Form_Remove")

            commProc.Parameters.Clear()

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

        Else 'menu

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Menu_Remove")

            commProc.Parameters.Clear()

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


        End If

        

        Return tStatus

    End Function


#End Region




    Private Sub FrmMenusDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _intModno > 0 Then
            LoadFormMenuData(_intSlno, _intModno)
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



        If Not (_intSlno = 0) Then

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

        If txtName.ReadOnly = False Then
            txtName.Focus()
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

                        LoadFormMenuData(_intSlno, _intModno)

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

                        LoadFormMenuData(_intSlno, _intModno)

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
        LoadFormMenuData(_intSlno, _intModno)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadFormMenuData(_intSlno, _intModno)

                    DisableAuth()

                    If _intSlno = 0 Then

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
            LoadFormMenuData(_intSlno, _intModno - 1)
        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click
        Dim strBankCode As String = _intSlno
        Dim intModno As Integer = _intModno
        If intModno > 0 Then
            LoadFormMenuData(_intSlno, _intModno + 1)

            If _intModno = 0 Then
                LoadFormMenuData(strBankCode, intModno)
            End If
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                tState = AuthorizeData()

                If tState = TransState.Update Then
                    LoadFormMenuData(_intSlno, _intModno)
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