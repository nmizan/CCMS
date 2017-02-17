Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Globalization
Imports System.Reflection

Public Class CommonUtil

    'Public Shared Sub FillComboBox(ByVal strSql As String, ByVal cmbVal As System.Windows.Forms.ComboBox)

    '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '    Dim dbCommand As DbCommand = db.GetSqlStringCommand(strSql)

    '    Dim ds As DataSet = db.ExecuteDataSet(dbCommand)

    '    cmbVal.DataSource = ds.Tables(0)
    '    cmbVal.DisplayMember = ds.Tables(0).Columns(1).ToString()
    '    cmbVal.ValueMember = ds.Tables(0).Columns(0).ToString()
    '    'cmbVal.Text = ""
    '    cmbVal.SelectedIndex = -1
    'End Sub

    Public Shared Sub FillComboBox(ByVal nameSP As String, ByVal cmbVal As System.Windows.Forms.ComboBox)

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim dbCommand As DbCommand = db.GetStoredProcCommand(nameSP)

        Dim dt As DataTable = db.ExecuteDataSet(dbCommand).Tables(0)

        cmbVal.DataSource = dt
        cmbVal.DisplayMember = dt.Columns(1).ToString()
        cmbVal.ValueMember = dt.Columns(0).ToString()
        'cmbVal.Text = ""
        cmbVal.SelectedIndex = -1
    End Sub


    Public Shared Sub LogonReport(ByVal rptReport As ReportDocument)
        Dim strServer As String = ""
        Dim strDBase As String = ""
        Dim strUID As String = ""
        Dim strPWD As String = ""
        Dim strIsTrustedConn As String = ""

        Dim crReportDocument As New ReportDocument()
        Dim crTableLogonInfos As New TableLogOnInfos()
        Dim crTableLogonInfo As New TableLogOnInfo()
        Dim crTables As Tables
        Dim crTable As Table
        Dim crSections As Sections
        Dim crSection As Section
        Dim crReportObjects As ReportObjects
        Dim crReportObject As ReportObject
        Dim crSubreportObject As SubreportObject
        Dim crDataBase As Database
        Dim crConnInfo As New ConnectionInfo()
        Dim subRepDoc As New ReportDocument()





        strServer = CommonAppSet.Server
        strDBase = CommonAppSet.Database

        strUID = CommonAppSet.UserId
        strPWD = CommonAppSet.UserPwd
        strIsTrustedConn = CommonAppSet.TrustedConn


        'Logs into the tables in the report
        crReportDocument = rptReport
        crDataBase = crReportDocument.Database
        crTables = crDataBase.Tables

        For Each crTable In crTables
            With crConnInfo
                .ServerName = strServer
                .DatabaseName = strDBase

                If strIsTrustedConn = "y" Then
                    crReportDocument.DataSourceConnections.Item(0).IntegratedSecurity = True
                    .IntegratedSecurity = True
                ElseIf strIsTrustedConn = "n" Then
                    .UserID = strUID
                    .Password = strPWD
                Else
                    Throw New Exception("Invalid value in Configuration File")
                End If

            End With

            crTableLogonInfo = crTable.LogOnInfo
            crTableLogonInfo.ConnectionInfo = crConnInfo
            crTable.ApplyLogOnInfo(crTableLogonInfo)

        Next

        'Logs into the tables in the Sub-reports
        crSections = crReportDocument.ReportDefinition.Sections
        For Each crSection In crSections
            crReportObjects = crSection.ReportObjects
            For Each crReportObject In crReportObjects
                If crReportObject.Kind = ReportObjectKind.SubreportObject Then
                    crSubreportObject = CType(crReportObject, SubreportObject)
                    subRepDoc = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)
                    crDataBase = subRepDoc.Database
                    crTables = crDataBase.Tables
                    For Each crTable In crTables
                        With crConnInfo
                            .ServerName = strServer
                            .DatabaseName = strDBase

                            If strIsTrustedConn = "y" Then
                                crReportDocument.DataSourceConnections.Item(0).IntegratedSecurity = True

                            ElseIf strIsTrustedConn = "n" Then
                                .UserID = strUID
                                .Password = strPWD
                            Else
                                Throw New Exception("Invalid value in Configuration File")
                            End If


                        End With

                        crTableLogonInfo = crTable.LogOnInfo
                        crTableLogonInfo.ConnectionInfo = crConnInfo
                        crTable.ApplyLogOnInfo(crTableLogonInfo)

                    Next
                End If
            Next
        Next
    End Sub


    Public Shared Function DateValidate(ByVal dt As String) As Boolean


        If dt.Trim() = "" Or dt.Trim() = "/  /" Then
            Return True
        Else

            Try
                DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            Catch ex As Exception
                Return False
            End Try

            Return True

        End If

    End Function

    Public Shared Function DecValidate(ByVal num As String) As Boolean


        If num.Trim() = "" Then
            Return True
        Else

            Try
                Convert.ToDecimal(num.Trim())
            Catch ex As Exception
                Return False
            End Try

            Return True

        End If

    End Function

    Public Shared Function IntValidate(ByVal num As String) As Boolean


        If num.Trim() = "" Then
            Return True
        Else

            Try
                Convert.ToInt64(num.Trim())
            Catch ex As Exception
                Return False
            End Try

            Return True

        End If

    End Function


    Public Shared Function CreateObjectInstance(ByVal objectName As String) As Object
        ' Creates and returns an instance of any object in the assembly by its type name.

        Dim obj As Object

        Try
            If objectName.LastIndexOf(".") = -1 Then
                'Appends the root namespace if not specified.
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj

    End Function

    Public Shared Function CreateForm(ByVal formName As String) As Form
        ' Return the instance of the form by specifying its name.
        Return DirectCast(CreateObjectInstance(formName), Form)
    End Function



End Class
