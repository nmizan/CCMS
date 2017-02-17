
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class SecForm
    Private _IsAuth As Boolean = False
    Private _IsShow As Boolean = False
    Private _IsNew As Boolean = False
    Private _IsSave As Boolean = False
    Private _IsDelete As Boolean = False
    Private _IsUnlock As Boolean = False

    Public Sub New(ByVal FormName As String)
        CommonAppSet.DebugLevel = "Secuity Class"
        CommonAppSet.DebugMessage = "Class Entry, Formname val: " + FormName

        Try

            Dim user = CommonAppSet.User
            Dim db As New SqlDatabase(CommonAppSet.ConnStr)
            Dim ds As New DataSet
            Dim comProc As DbCommand = db.GetStoredProcCommand("CMS_Users_FunFormPermission")
            db.AddInParameter(comProc, "@USERS_ID", DbType.String, user)
            db.AddInParameter(comProc, "@FORMS_NAME", DbType.String, FormName)

            'db.AddInParameter(comProc, "@USERS_ID", DbType.String, "fahad")
            'db.AddInParameter(comProc, "@FORMS_NAME", DbType.String, "rere")

            CommonAppSet.DebugMessage = "Perm Proc, Formname val: " + FormName + _
                ", User: " + user

            ds = db.ExecuteDataSet(comProc)
            

            If ds.Tables(0).Rows.Count > 0 Then
                'FormName = ds.Tables(0).Rows(0)("FORMS_NAME").ToString()

                CommonAppSet.DebugMessage = CommonAppSet.DebugMessage + _
                    Environment.NewLine + ", show: " + NullHelper.ObjectToString(ds.Tables(0).Rows(0)("IS_SHOW"))
                _IsShow = ds.Tables(0).Rows(0)("IS_SHOW").ToString()

                CommonAppSet.DebugMessage = CommonAppSet.DebugMessage + _
                    Environment.NewLine + ", new: " + NullHelper.ObjectToString(ds.Tables(0).Rows(0)("IS_NEW"))
                _IsNew = ds.Tables(0).Rows(0)("IS_NEW").ToString()

                CommonAppSet.DebugMessage = CommonAppSet.DebugMessage + _
                    Environment.NewLine + ", unlock: " + NullHelper.ObjectToString(ds.Tables(0).Rows(0)("IS_UNLOCK"))
                _IsUnlock = ds.Tables(0).Rows(0)("IS_UNLOCK").ToString()

                CommonAppSet.DebugMessage = CommonAppSet.DebugMessage + _
                    Environment.NewLine + ", auth: " + NullHelper.ObjectToString(ds.Tables(0).Rows(0)("IS_AUTHORIZER"))
                _IsAuth = ds.Tables(0).Rows(0)("IS_AUTHORIZER").ToString()

                CommonAppSet.DebugMessage = CommonAppSet.DebugMessage + _
                    Environment.NewLine + ", delete: " + NullHelper.ObjectToString(ds.Tables(0).Rows(0)("IS_DELETE"))
                _IsDelete = ds.Tables(0).Rows(0)("IS_DELETE").ToString()

                CommonAppSet.DebugMessage = CommonAppSet.DebugMessage + _
                    Environment.NewLine + ", save: " + NullHelper.ObjectToString(ds.Tables(0).Rows(0)("IS_SAVE"))
                _IsSave = ds.Tables(0).Rows(0)("IS_SAVE").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show("Debug Level: " + CommonAppSet.DebugLevel + _
                            Environment.NewLine + "Debug Message: " + CommonAppSet.DebugMessage + _
                            Environment.NewLine + "App Message: " + ex.Message, "Security Class Error")
        End Try

        

        'MessageBox.Show("Authorization: " + _IsShow.ToString())

        If CommonAppSet.IsByPass = True Then
            _IsShow = True
            _IsNew = True
            _IsUnlock = True
            _IsAuth = True
            _IsDelete = True
            _IsSave = True
        End If




    End Sub



    Public Sub New(ByVal FormName As String, ByVal IsAdmin As Boolean)
        

        If IsAdmin = True Then

            _IsShow = True
            _IsNew = True
            _IsUnlock = True
            _IsAuth = True
            _IsDelete = True
            _IsSave = True
        Else

            Dim user = CommonAppSet.User
            Dim db As New SqlDatabase(CommonAppSet.ConnStr)
            Dim ds As New DataSet
            Dim comProc As DbCommand = db.GetStoredProcCommand("CMS_Users_FunFormPermission")
            db.AddInParameter(comProc, "@USERS_ID", DbType.String, user)
            db.AddInParameter(comProc, "@FORMS_NAME", DbType.String, FormName)

            ds = db.ExecuteDataSet(comProc)
            If ds.Tables(0).Rows.Count > 0 Then
                'FormName = ds.Tables(0).Rows(0)("FORMS_NAME").ToString()
                _IsShow = ds.Tables(0).Rows(0)("IS_SHOW").ToString()
                _IsNew = ds.Tables(0).Rows(0)("IS_NEW").ToString()
                _IsUnlock = ds.Tables(0).Rows(0)("IS_UNLOCK").ToString()
                _IsAuth = ds.Tables(0).Rows(0)("IS_AUTHORIZER").ToString()
                _IsDelete = ds.Tables(0).Rows(0)("IS_DELETE").ToString()
                _IsSave = ds.Tables(0).Rows(0)("IS_SAVE").ToString()
            End If

        End If

        If CommonAppSet.IsByPass = True Then
            _IsShow = True
            _IsNew = True
            _IsUnlock = True
            _IsAuth = True
            _IsDelete = True
            _IsSave = True
        End If


    End Sub

    Public ReadOnly Property IsAuth() As Boolean
        Get
            Return _IsAuth
        End Get

    End Property

    Public ReadOnly Property IsShow() As Boolean
        Get
            Return _IsShow
        End Get

    End Property

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return _IsNew
        End Get

    End Property

    Public ReadOnly Property IsUnlock() As Boolean
        Get
            Return _IsUnlock
        End Get

    End Property

    Public ReadOnly Property IsSave() As Boolean
        Get
            Return _IsSave
        End Get

    End Property

    Public ReadOnly Property IsDelete() As Boolean
        Get
            Return _IsDelete
        End Get

    End Property


End Class
