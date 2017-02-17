Imports System.Globalization


Public Class NullHelper
    Public Shared Function ToBool(ByVal objVal As Object) As Boolean

        If (objVal Is Nothing) Or (objVal Is DBNull.Value) Then
            Return False
        End If


        Return Convert.ToBoolean(objVal)

    End Function

    Public Shared Function ToIntNum(ByVal objVal As Object) As Integer

        If (objVal Is Nothing) Or (objVal Is DBNull.Value) Then
            Return 0
        End If

        If (objVal.ToString().Trim() = "") Then
            Return 0
        End If


        Return Convert.ToInt64(objVal)

    End Function

    Public Shared Function ToDecNum(ByVal objVal As Object) As Decimal

        If (objVal Is Nothing) Or (objVal Is DBNull.Value) Then
            Return 0
        End If

        If (objVal.ToString().Trim() = "") Then
            Return 0
        End If

        Return Convert.ToDecimal(objVal)

    End Function

    Public Shared Function DateToString(ByVal obj As Object) As String
        If obj Is DBNull.Value Then
            Return ""
        Else
            Return Convert.ToDateTime(obj).ToString("dd/MM/yyyy")

        End If


    End Function
    Public Shared Function DateToString(ByVal obj As Object, ByVal format As String) As String
        If obj Is DBNull.Value Then
            Return ""
        Else
            Return Convert.ToDateTime(obj).ToString(format)

        End If


    End Function

    Public Shared Function StringToDate(ByVal str As String) As Object
        If str.Trim() = "" Or str.Trim() = "/  /" Then
            Return DBNull.Value
        Else
            Return DateTime.ParseExact(str.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
        End If

    End Function

    Public Shared Function StringToObject(ByVal str As String) As Object
        Try


            'If str.Trim() = "" Or str Is Nothing Then
            'Return DBNull.Value

            If str.Trim() = "" Or str Is Nothing Then
                Return DBNull.Value

            Else
                Dim dt As New DateTime

                dt = DateTime.ParseExact(str.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)

                Return dt.ToString("dd-MMM-yyyy")


            End If

        Catch ex As Exception
            Return str
        End Try

    End Function


    Public Shared Function ObjectToNull(ByVal objVal As Object) As Object

        If (objVal Is Nothing) Or (objVal Is DBNull.Value) Or (objVal.ToString().Trim() = "") Then
            Return DBNull.Value
        End If

        Return objVal


    End Function


    Public Shared Function ObjectToString(ByVal objVal As Object) As String

        If (objVal Is Nothing) Or (objVal Is DBNull.Value) Then
            Return ""
        End If

        Return objVal.ToString()


    End Function

    Public Shared Function StringToCrDateString(ByVal str As String) As String
        Try




            If str.Trim() = "" Or str Is Nothing Then
                Return ""

            Else
                Dim dt As New DateTime

                dt = DateTime.ParseExact(str.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)

                Return dt.ToString("MM/dd/yyyy")


            End If

        Catch ex As Exception
            Return str
        End Try

    End Function

    Public Shared Function IntToValueType(ByVal objVal As Object) As String

        If (objVal Is Nothing) Or (objVal Is DBNull.Value) Then
            Return ""
        End If

        If objVal = 1 Then
            Return "Low"

        ElseIf objVal = 2 Then
            Return "High"

        End If

        Return ""



    End Function




End Class
