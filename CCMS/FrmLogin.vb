Imports System.Data.Common
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Configuration

Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
'Imports System.DirectoryServices

Imports System.DirectoryServices.AccountManagement
Imports System.Reflection

Imports System.DirectoryServices
Imports System.Security.Principal





Public Class FrmLogin

#Region "Global Variables"

    Dim dbSetting As DBConnSection

    Dim log_mesage As String = ""

    Private _ExitMdi As Boolean = False

#End Region

#Region "User Defined Codes"

    ''' <summary>
    ''' Load Configuration Settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadConfSettings()

        Dim appSettings As NameValueCollection = ConfigurationManager.AppSettings

        CommonAppSet.Server = appSettings("SERVER")
        CommonAppSet.Database = appSettings("DATABASE")
        CommonAppSet.Domain = appSettings("DOMAIN")
        CommonAppSet.ConnStr = appSettings("ConnectionString")

    End Sub


    Private Sub LoadConfSettings(ByVal defaultConn As String)

        If defaultConn = "UAT" Then

            CommonAppSet.Server = dbSetting.UATConfig.Server
            CommonAppSet.Database = dbSetting.UATConfig.Database
            CommonAppSet.Domain = dbSetting.UATConfig.Domain
            CommonAppSet.ConnStr = dbSetting.UATConfig.ConnectionString
            CommonAppSet.ServerConfigName = "UAT"

        ElseIf defaultConn = "PROD" Then

            CommonAppSet.Server = dbSetting.PRODConfig.Server
            CommonAppSet.Database = dbSetting.PRODConfig.Database
            CommonAppSet.Domain = dbSetting.PRODConfig.Domain
            CommonAppSet.ConnStr = dbSetting.PRODConfig.ConnectionString
            CommonAppSet.ServerConfigName = "PROD"

        ElseIf defaultConn = "DEV" Then

            CommonAppSet.Server = dbSetting.DEVConfig.Server
            CommonAppSet.Database = dbSetting.DEVConfig.Database
            CommonAppSet.Domain = dbSetting.DEVConfig.Domain
            CommonAppSet.ConnStr = dbSetting.DEVConfig.ConnectionString
            CommonAppSet.ServerConfigName = "DEV"
        Else

            CommonAppSet.Server = ""
            CommonAppSet.Database = ""
            CommonAppSet.Domain = ""
            CommonAppSet.ConnStr = ""

        End If




    End Sub


    WriteOnly Property Status()
        Set(ByVal value)
            lblStatus.Text = value
        End Set
    End Property

    Property IsMdiExit() As Boolean
        Get
            Return _ExitMdi
        End Get
        Set(ByVal value As Boolean)
            _ExitMdi = value
        End Set
    End Property

    Private Function CheckLogin() As Boolean

        Try

            Dim x As System.Security.Principal.WindowsIdentity
            x = System.Security.Principal.WindowsIdentity.GetCurrent()

            If x.IsAuthenticated Then

                If x.Name.Trim() <> "" Then
                    Dim intSepPos As Integer
                    intSepPos = x.Name.IndexOf("\")
                    CommonAppSet.Domain = x.Name.Substring(0, intSepPos)
                    CommonAppSet.User = x.Name.Substring(intSepPos + 1, x.Name.Length - 1 - intSepPos)
                End If


                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim strSql As String = "select * from users where USERS_ID='" + CommonAppSet.User + "' and DOMAIN='" + CommonAppSet.Domain + "'"

                Dim ds As DataSet = db.ExecuteDataSet(CommandType.Text, strSql)

                If ds.Tables(0).Rows.Count() > 0 Then
                    If ds.Tables(0).Rows(0)("USER_STAT").ToString() = "D" Then
                        MessageBox.Show("User is disabled." + vbCrLf + "Please contact with your administrator.", "!!Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If

                    Return True
                End If

                MessageBox.Show("You are not authorized to use the application!", "!!Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If


        Catch ex As Exception

            'MessageBox.Show("Internal Error !" + vbCrLf + "Access is denied", "!!Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        MessageBox.Show("Internal Error !" + vbCrLf + "Access is denied", "!!Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Return False

    End Function


    Private Sub LoginWithCredential()
        'LoadConfSettings()
        'PrepareConnString()

        lblVersion.Text = "Ver: " & Application.ProductVersion
        lblAppName.Text = CommonAppSet.ModuleName & " (" & CommonAppSet.ModuleShortName & ")"

    End Sub

   
    Private Function IsUserAuthenticated() As Boolean
        ' disable account after 6 failed attempt
        ' disable account for inactivity of 100 days
        ' session sign out for inactivity of 30 miniutes:

        Dim flagLoginSuccess As Boolean = False

        CommonAppSet.User = txtUser.Text.Trim()

        '-----------
        Dim winIdent As WindowsIdentity = WindowsIdentity.GetCurrent()

        Dim ident As WindowsIdentity = WindowsIdentity.GetCurrent()


        Dim entry As New DirectoryEntry

        'Dim str As String = "/" + txtUser.Text.Trim()

        entry.Username = ident.Name


        entry.Password = txtPass.Text.Trim()


        Try

            'Bind to the native AdsObject to force authentication. 

            If CommonAppSet.IsByPass = False Then

                Dim obj As Object = entry.NativeObject

            End If



            flagLoginSuccess = True

        Catch ex As Exception

            'MsgBox(ex.Message)

            ' If Exception is Raised, Authentication is Failed, If Failure Details are Required , Un-Comment the line below

            'Throw New Exception("Authentication failed with following Error : " & ex.Message)


        End Try
        '----------

        If CommonAppSet.IsByPass = True Then
            flagLoginSuccess = True
        End If



        If CheckVersion() = False Then
            Application.Exit()
        End If

        'Return True

        '  Using pc As PrincipalContext = New PrincipalContext(ContextType.Domain, CommonAppSet.Domain)
        If flagLoginSuccess = True Then
            'If pc.ValidateCredentials(txtUser.Text.Trim(), txtPass.Text.Trim()) Then

            'If CheckVersion() = False Then
            '    Application.Exit()
            'End If


            'Return True

            Try

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_GetDetailByCode")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@USERS_ID", DbType.String, CommonAppSet.User)

                Dim dt As New DataTable

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then

                    If (dt.Rows(0)("USER_STAT").ToString() = "E") Then

                        commProc = db.GetStoredProcCommand("CMS_Users_TryLogin")
                        commProc.Parameters.Clear()

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                        If result = 0 Then
                            If NullHelper.ToBool(dt.Rows(0)("IS_ADMIN")) = True Then
                                CommonAppSet.IsAdmin = True
                            Else
                                CommonAppSet.IsAdmin = False
                            End If

                            Logger.system_log("Successful login: " + CommonAppSet.User)

                            Return True
                        ElseIf result = 1 Then
                            MessageBox.Show("System Error. Login Denied!!", "Systen Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Logger.system_log("User: " + CommonAppSet.User + " Login Failed. System Error")

                        ElseIf result = 4 Then
                            
                            MessageBox.Show("! Account not exist !" + Environment.NewLine + _
                               "Contact with your administrator", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Logger.system_log("User: " + CommonAppSet.User + " not exists. Login Failed.")

                        ElseIf result = 8 Then
                            MessageBox.Show("You acccunt has been disabled. Login Denied!!", "Systen Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Logger.system_log("User: " + CommonAppSet.User + " Login Failed. Account is locked.")

                        Else
                            MessageBox.Show("System Error. Login Denied!!", "Systen Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Logger.system_log("User: " + CommonAppSet.User + " Login Failed. System Error")

                        End If



                    ElseIf (dt.Rows(0)("USER_STAT").ToString() = "D") Then

                        MessageBox.Show("Your ID is locked!!", "Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Logger.system_log("User: " + CommonAppSet.User + " Login Failed. Your ID is locked.")

                    Else

                        MessageBox.Show("Your ID is corrupted!!", "Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Logger.system_log("User: " + CommonAppSet.User + " Login Failed. ID record corrupted")

                    End If

                Else

                    MessageBox.Show("You are not authorized!!", "Login Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Logger.system_log("User: " + CommonAppSet.User + " Login Failed. ID is not maintained.")


                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


        Else   '--- invalid password

            Try

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_InvalidLogin")

                commProc.Parameters.Clear()

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                If result = 0 Then
                    MessageBox.Show("Invalid User/Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Logger.system_log("User: " + CommonAppSet.User + " Login Failed. Invalid user/password.")
                    txtPass.SelectAll()
                    txtPass.Focus()

                ElseIf result = 4 Then
                    MessageBox.Show("! Account not exist !" + Environment.NewLine + _
                               "Contact with your administrator", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Logger.system_log("User: " + CommonAppSet.User + " not exists. Login Failed.")
                    txtPass.SelectAll()
                    txtPass.Focus()
                ElseIf result = 8 Then

                    MessageBox.Show("! Account is locked !" + Environment.NewLine + _
                                "Contact with your administrator", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPass.SelectAll()
                    txtPass.Focus()
                Else
                    MessageBox.Show("Unspecified error occured" + Environment.NewLine + _
                                "Contact with your administrator", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Logger.system_log("User: " + CommonAppSet.User + " Login Failed. Unspecififed Error Occured.")
                    txtPass.SelectAll()
                    txtPass.Focus()

                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


            'MessageBox.Show("Invalid User/Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'txtPass.SelectAll()
            'txtPass.Focus()
        End If

        ' End Using

        Return False

    End Function

    Private Function CheckVersion() As Boolean

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Version_GetDetail")

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If (dt.Rows(0)("CHK").ToString() = "1") Then


                    Dim dbMinMajor As Integer = dt.Rows(0)("MIN_MAJOR")
                    Dim dbMinMinor As Integer = dt.Rows(0)("MIN_MINOR")
                    Dim dbMinBuild As Integer = dt.Rows(0)("MIN_BUILD")
                    Dim dbMaxMajor As Integer = dt.Rows(0)("MAX_MAJOR")
                    Dim dbMaxMinor As Integer = dt.Rows(0)("MAX_MINOR")
                    Dim dbMaxBuild As Integer = dt.Rows(0)("MAX_BUILD")

                    Dim verApp As Version = Assembly.GetExecutingAssembly().GetName().Version

                    Dim verMin As New Version(dbMinMajor, dbMinMinor, dbMinBuild, 0)
                    Dim verMax As New Version(dbMaxMajor, dbMaxMinor, dbMaxBuild, 0)

                    If (verMin <= verApp And verMax >= verApp) Then

                        Return True
                    End If

                    MessageBox.Show("Application version incompatible." + Environment.NewLine + _
                        "Your app ver: " + Application.ProductVersion + Environment.NewLine + _
                        "Please contact with your administrator to continue.", "Version Incompatible!!", MessageBoxButtons.OK, MessageBoxIcon.Error)


                Else 'no version check needed

                    ' so the check is ok.
                    Return True
                End If

            Else

                MessageBox.Show("No version information found", "Version Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)


            End If

        Catch ex As SqlClient.SqlException

            If ex.ErrorCode = -2146232060 Then
                MessageBox.Show("You are not authorized!!", "Version Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Exit Function

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try



        Return False



    End Function





#End Region



    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoginWithoutCredential()

        MessageBox.Show("You are authorized to use this system for approved business purposes only." + Environment.NewLine + _
                        "Use for any other purpose is prohibited. All transactional records, reports, " + Environment.NewLine + _
                        "e-mail, software and other data generated by or residing upon this system are " + Environment.NewLine + _
                        "the property of the company and may be used by the company for any purpose." + Environment.NewLine + _
                        "Authorized and unauthorized activities may be monitored", CommonAppSet.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.None)



        'txtPass.Text = "123"

        txtUser.Text = Environment.UserName
        lblDomain.Text = Environment.UserDomainName

        LoginWithCredential()

        dbSetting = DBConnSection.Open()

        cmbServer.SelectedIndex = cmbServer.Items.IndexOf(dbSetting.DefaultConfig.Name)

        'If lblDomain.Text.Trim().ToUpper() <> CommonAppSet.Domain.Trim().ToUpper() Then
        '    lblStatus.Text = "Mismatch domain name"
        'End If

        

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click


        'Using pc As PrincipalContext = New PrincipalContext(ContextType.Domain, "CCLDOMAIN")

        '    If pc.ValidateCredentials(txtUser.Text.Trim(), txtPass.Text.Trim()) Then
        '        MessageBox.Show("Successs")
        '    Else
        '        MessageBox.Show("failed")
        '    End If
        'End Using



       

        lblStatus.Text = ""

        If cmbServer.SelectedIndex = -1 Or cmbServer.Text.Trim() = "" Then
            MessageBox.Show("Select Server", "Server selection required!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "Select Server"
            Exit Sub
        End If

        If lblDomain.Text.Trim().ToUpper() <> CommonAppSet.Domain.Trim().ToUpper() Then
            MessageBox.Show("Update your domain name", "Domain Name Mismatch!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "Mismatch domain name"
            Exit Sub
        End If

        If txtUser.Text.Trim().ToUpper() <> Environment.UserName.Trim().ToUpper() Then
            MessageBox.Show("No USER other than the USER currently logged on the WINDOWS OS are allowed", "Invalid Login!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "Invalid login"
            Exit Sub
        End If

        If txtPass.Text.Trim() = "" Then
            MessageBox.Show("Empty password not allowed", "Invalid Login!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "Empty password not allowed"
            txtPass.Focus()
            Exit Sub
        End If

        Try
            If IsUserAuthenticated() = True Then
                txtPass.Clear()
                Me.Hide()

                IsMdiExit = True

                Dim frmMain As New FrmMain(Me)
                frmMain.ShowDialog()

                Logger.system_log("User: " + CommonAppSet.User + " Logged Out.")

                If IsMdiExit = True Then
                    Me.Dispose()
                Else
                    Me.Show()
                End If


                'Me.Dispose()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        lblStatus.Text = ""

        Dim frmSetting As New FrmAppSettting()
        frmSetting.ShowDialog()

        dbSetting = DBConnSection.Open()
        LoadConfSettings(cmbServer.Text)
        'PrepareConnString()

    End Sub

    Private Sub txtUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter And txtUser.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPass_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter And txtPass.Text.Trim() <> "" Then
            btnLogin_Click(sender, e)
        End If
    End Sub

  
    Private Sub cmbServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServer.SelectedIndexChanged

        If cmbServer.Text.Trim() <> "" Then
            LoadConfSettings(cmbServer.Text)
        End If

        If lblDomain.Text.Trim().ToUpper() <> CommonAppSet.Domain.Trim().ToUpper() Then
            lblStatus.Text = "Mismatch domain name"
        Else
            lblStatus.Text = ""
        End If

    End Sub
End Class
