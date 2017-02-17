

Public Class CommonAppSet

    Public Const ModuleShortName As String = "CCMS"
    Public Const ModuleName As String = "Citi Cash Mangement System"
    Public Const ModuleId As String = "1"
    Public Const AppId As String = "165294"

    Public Shared Server As String
    Public Shared Database As String
    Public Const TrustedConn As String = "y"
    Public Shared UserId As String
    Public Shared UserPwd As String

    
    Public Shared ConnStr As String

    Public Shared LogedIn As Boolean = False

    Public Shared User As String
    Public Shared Domain As String
    Public Shared ServerConfigName As String
    Public Shared Terminal As String
    Public Shared Port As String
    Public Shared SessionTimeOut As Boolean = False

    Public Shared IsAdmin As Boolean = False

    Public Shared IsByPass As Boolean = True

    Public Shared DebugLevel As String = ""
    Public Shared DebugMessage As String = ""


End Class
