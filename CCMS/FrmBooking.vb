
'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Generate booking file for flexcube
'Creation date      : 20-Feb-2013
'Stored Procedure(s):  
'


Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmBooking

    Private _Seq_No As Integer
    Private _Batch_No As String = ""
    Private _Ref_No As String = ""
    Dim _FileNm As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False

    Dim _PathBooking = Environment.CurrentDirectory + "\BookingData"

    Dim _strFileName As String


#Region "User defined Procedures"

    Dim _formName As String = "DepositFlexFile"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub PrepareDataForChecking()

        lblToolStatus.Text = ""


        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_BeforeBookingCheck")

                commProc1.Parameters.Clear()

                db.AddOutParameter(commProc1, "@SEQ_NO", DbType.Int32, 4)
                db.AddOutParameter(commProc1, "@BATCH_NO", DbType.String, 4)
                db.AddOutParameter(commProc1, "@REF_NO", DbType.String, 10)

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer
                commProc1.CommandTimeout = 3600
exe1:
                Try
                    db.ExecuteNonQuery(commProc1, trans)
                Catch ex As TimeoutException
                    commProc1.CommandTimeout += commProc1.CommandTimeout
                    GoTo exe1
                End Try


                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                _Seq_No = db.GetParameterValue(commProc1, "@SEQ_NO")
                _Batch_No = db.GetParameterValue(commProc1, "@BATCH_NO")
                _Ref_No = db.GetParameterValue(commProc1, "@REF_NO")



                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingCheckByBank")

                Dim i As Integer

                For i = 0 To dgView.Rows.Count - 1
                    If dgView(0, i).Value = True Then

                        commProc2.Parameters.Clear()

                        db.AddInParameter(commProc2, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())

                        db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        commProc2.CommandTimeout = 3600
exe2:
                        Try
                            db.ExecuteNonQuery(commProc2, trans)
                        Catch ex As TimeoutException
                            commProc2.CommandTimeout += commProc2.CommandTimeout
                            GoTo exe2
                        End Try


                        result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

                        If result > 0 Then
                            trans.Rollback()
                            MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                    End If
                Next i

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_Process_AfterBookingCheck")

                commProc3.Parameters.Clear()

                db.AddParameter(commProc3, "@REF_NO", DbType.String, ParameterDirection.InputOutput, DBNull.Value.ToString(), DataRowVersion.Default, _Ref_No)


                db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                commProc3.CommandTimeout = 3600
exe3:
                Try
                    db.ExecuteNonQuery(commProc3, trans)
                Catch ex As TimeoutException
                    commProc3.CommandTimeout += commProc3.CommandTimeout
                    GoTo exe3
                End Try

                result = db.GetParameterValue(commProc3, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                _Ref_No = db.GetParameterValue(commProc3, "@REF_NO")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingDrCheckByBank")

                For i = 0 To dgView.Rows.Count - 1
                    If dgView(0, i).Value = True Then

                        commProc4.Parameters.Clear()

                        db.AddInParameter(commProc4, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())
                        db.AddInParameter(commProc4, "@SCHEDULE_DATE", DbType.DateTime, dtpBookingDate.Value)

                        db.AddParameter(commProc4, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        commProc4.CommandTimeout = 3600
exe4:
                        Try
                            db.ExecuteNonQuery(commProc4, trans)
                        Catch ex As TimeoutException
                            commProc4.CommandTimeout += commProc4.CommandTimeout
                            GoTo exe4
                        End Try

                        result = db.GetParameterValue(commProc4, "@PROC_RET_VAL")

                        If result > 0 Then
                            trans.Rollback()
                            MessageBox.Show("Process Error. Level 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                    End If
                Next i

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingCheckUpdate")


                db.AddParameter(commProc5, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                commProc5.CommandTimeout = 3600
exe5:
                Try
                    db.ExecuteNonQuery(commProc5, trans)
                Catch ex As TimeoutException
                    commProc5.CommandTimeout += commProc5.CommandTimeout
                    GoTo exe5
                End Try

                result = db.GetParameterValue(commProc5, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim commProc6 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingCheckStatusByBank")

                For i = 0 To dgView.Rows.Count - 1
                    If dgView(0, i).Value = True Then

                        commProc6.Parameters.Clear()

                        db.AddInParameter(commProc6, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())

                        db.AddParameter(commProc6, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                        commProc6.CommandTimeout = 3600
exe6:
                        Try
                            db.ExecuteNonQuery(commProc6, trans)
                        Catch ex As TimeoutException
                            commProc6.CommandTimeout += commProc6.CommandTimeout
                            GoTo exe6
                        End Try


                        result = db.GetParameterValue(commProc6, "@PROC_RET_VAL")

                        If result > 0 Then
                            trans.Rollback()
                            MessageBox.Show("Process Error. Level 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                    End If
                Next i


                trans.Commit()
                _ProcessSuccess = True

            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub



    Private Sub PrepareBookingData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''ok


                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_BeforeBookingCheck")

                commProc1.Parameters.Clear()

                db.AddOutParameter(commProc1, "@SEQ_NO", DbType.Int32, 4)
                db.AddOutParameter(commProc1, "@BATCH_NO", DbType.String, 4)
                db.AddOutParameter(commProc1, "@REF_NO", DbType.String, 10)

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                commProc1.CommandTimeout = 3600
exe1:
                Try
                    db.ExecuteNonQuery(commProc1, trans)
                Catch ex As TimeoutException
                    commProc1.CommandTimeout += commProc1.CommandTimeout
                    GoTo exe1
                End Try

                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                _Seq_No = db.GetParameterValue(commProc1, "@SEQ_NO")
                _Batch_No = db.GetParameterValue(commProc1, "@BATCH_NO")
                _Ref_No = db.GetParameterValue(commProc1, "@REF_NO")

                

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ok


                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingByBank")

                Dim i As Integer

                For i = 0 To dgView.Rows.Count - 1
                    If dgView(0, i).Value = True Then

                        commProc2.Parameters.Clear()

                        db.AddInParameter(commProc2, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())

                        db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                        commProc2.CommandTimeout = 3600
exe2:
                        Try
                            db.ExecuteNonQuery(commProc2, trans)
                        Catch ex As TimeoutException
                            commProc2.CommandTimeout += commProc2.CommandTimeout
                            GoTo exe2
                        End Try


                        result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

                        If result > 0 Then
                            trans.Rollback()
                            MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                    End If
                Next i

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ok

                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_Process_AfterBookingCheck")

                commProc3.Parameters.Clear()

                db.AddParameter(commProc3, "@REF_NO", DbType.String, ParameterDirection.InputOutput, DBNull.Value.ToString(), DataRowVersion.Default, _Ref_No)
                db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                commProc3.CommandTimeout = 3600
exe3:
                Try
                    db.ExecuteNonQuery(commProc3, trans)
                Catch ex As TimeoutException
                    commProc3.CommandTimeout += commProc3.CommandTimeout
                    GoTo exe3
                End Try

                result = db.GetParameterValue(commProc3, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                _Ref_No = db.GetParameterValue(commProc3, "@REF_NO")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ok

                Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingDrByBank")

                For i = 0 To dgView.Rows.Count - 1
                    If dgView(0, i).Value = True Then

                        commProc4.Parameters.Clear()

                        db.AddInParameter(commProc4, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())


                        db.AddInParameter(commProc4, "@SCHEDULE_DATE", DbType.DateTime, dtpBookingDate.Value)

                        db.AddParameter(commProc4, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        commProc4.CommandTimeout = 3600
exe4:
                        Try
                            db.ExecuteNonQuery(commProc4, trans)
                        Catch ex As TimeoutException
                            commProc4.CommandTimeout += commProc4.CommandTimeout
                            GoTo exe4
                        End Try

                        result = db.GetParameterValue(commProc4, "@PROC_RET_VAL")

                        If result > 0 Then
                            trans.Rollback()
                            MessageBox.Show("Process Error. Level 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                    End If
                Next i

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ok

                FlexFileGen(db, trans)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ok

                If _FileSuccess = False Then
                    trans.Rollback()
                    MessageBox.Show("File Generation Aborted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_Process_BookingUpdtScheRefByBank")

                For i = 0 To dgView.Rows.Count - 1
                    If dgView(0, i).Value = True Then

                        commProc5.Parameters.Clear()

                        db.AddInParameter(commProc5, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())
                        db.AddInParameter(commProc5, "@FILENAME", DbType.String, _FileNm)
                        db.AddInParameter(commProc5, "@SEQ_NO", DbType.String, _Seq_No)
                        db.AddInParameter(commProc5, "@VALUE_DATE", DbType.DateTime, dtpBookingDate.Value)

                        db.AddParameter(commProc5, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                        commProc5.CommandTimeout = 3600
exe5:
                        Try
                            db.ExecuteNonQuery(commProc5, trans)
                        Catch ex As TimeoutException
                            commProc5.CommandTimeout += commProc5.CommandTimeout
                            GoTo exe5
                        End Try


                        result = db.GetParameterValue(commProc5, "@PROC_RET_VAL")

                        If result > 0 Then
                            trans.Rollback()
                            MessageBox.Show("Process Error. Level 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                    End If
                Next i

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim commProc6 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateRef")

                db.AddInParameter(commProc6, "@FILENAME", DbType.String, _FileNm)
                db.AddInParameter(commProc6, "@GENPRMREF_NO", DbType.String, _Ref_No.PadLeft(10, "0"))
                db.AddInParameter(commProc6, "@BATCH_NO", DbType.String, _Batch_No)

                db.AddParameter(commProc6, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                commProc6.CommandTimeout = 3600
exe6:
                Try
                    db.ExecuteNonQuery(commProc6, trans)
                Catch ex As TimeoutException
                    commProc6.CommandTimeout += commProc6.CommandTimeout
                    GoTo exe6
                End Try

                result = db.GetParameterValue(commProc6, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                trans.Commit()
                _ProcessSuccess = True

            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub FlexFileGen(ByRef db As SqlDatabase, ByRef trans As DbTransaction)


        Dim brcode As String       'for branch
        Dim Valuedate As String       'for date format yyyymmdd
        'Dim serial As Currency     'to count serial


        Dim sourcecode As String

        Dim j As Integer = 1

        brcode = "G01"
        sourcecode = brcode + _Batch_No
        _FileNm = "F" + brcode + _Batch_No

        Valuedate = Format(Date.Now, "dd- MMMM - yy")
        'serial = 0

        _FileNm = _FileNm + ".csv"
        Dim owrite As System.IO.StreamWriter

        If Not Directory.Exists(_PathBooking) Then
            Directory.CreateDirectory(_PathBooking)
        End If


        File.Copy(Environment.CurrentDirectory + "\header.csv", _PathBooking + "\" + _FileNm, True)

        owrite = New System.IO.StreamWriter(_PathBooking + "\" + _FileNm, True)


        Dim sLine As String

        Dim ExlWS As New ArrayList()

        Try

            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpCrBooking_GetDetail")

            Dim dt As DataTable = New DataTable
            commProc.CommandTimeout = 3600
exe1:
            Try
                dt = db.ExecuteDataSet(commProc, trans).Tables(0)
            Catch ex As TimeoutException
                commProc.CommandTimeout += commProc.CommandTimeout
                GoTo exe1
            End Try

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()


                ExlWS.Add(_Batch_No)  'BATCH_NO
                ExlWS.Add("G01")   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(dt.Rows(i)("SUNACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(dt.Rows(i)("SUNACC_NO").ToString().Trim().Substring(0, 3))   'ACCOUNT_BRANCH
                If Trim(dt.Rows(i)("DEP_TYP").ToString()) = "Cash" Then
                    ExlWS.Add("355")    'TXN_CODE
                Else
                    ExlWS.Add("063")  'TXN_CODE
                End If
                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Valuedate)   '"" 'VALUE_DATE
                ExlWS.Add(dt.Rows(i)("REF_NO").ToString())   'INSTRUMENT_NO
                ExlWS.Add("") 'REL_CUST
                ExlWS.Add(dt.Rows(i)("REMARKS").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "")) '= Replace(Replace(Replace(Replace(Trim(rs!Remarks), ",", ""), "'", ""), "-", ""), ".", "") 'ADDL_TEXT
                ExlWS.Add("")  'comp_mis_1
                ExlWS.Add("")  'comp_mis_2
                ExlWS.Add("")  'txn_mis_1
                ExlWS.Add("")  'txn_mis_3
                ExlWS.Add("")  'txn_mis_4
                ExlWS.Add("")  'txn_mis_6
                ExlWS.Add("~~END~~")

                'increament of variables for row and currno
                'i = i + 1
                j = j + 1

                sLine = ""
                sLine = ExlWS.Item(0).ToString()
                For n = 1 To ExlWS.Count - 1
                    sLine = sLine + "," + ExlWS.Item(n).ToString()
                Next n

                owrite.WriteLine(sLine)

            Next i

            ''''''''''''''''''''''''''''''''''''

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TmpDrBooking_GetFlexDetail")

            commProc2.CommandTimeout = 3600
exe2:
            Try
                dt = db.ExecuteDataSet(commProc2, trans).Tables(0)
            Catch ex As TimeoutException
                commProc2.CommandTimeout += commProc2.CommandTimeout
                GoTo exe2
            End Try


            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()


                ExlWS.Add(_Batch_No)  'BATCH_NO
                ExlWS.Add("G01")   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(dt.Rows(i)("SUNACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(dt.Rows(i)("SUNACC_NO").ToString().Trim().Substring(0, 3))   'ACCOUNT_BRANCH
                If Trim(dt.Rows(i)("DEP_TYP").ToString()) = "Cash" Then
                    ExlWS.Add("355")    'TXN_CODE
                Else
                    ExlWS.Add("063")  'TXN_CODE
                End If
                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Valuedate)   '"" 'VALUE_DATE
                ExlWS.Add(dt.Rows(i)("REF_NO").ToString())   'INSTRUMENT_NO
                ExlWS.Add("") 'REL_CUST
                ExlWS.Add(dt.Rows(i)("REMARKS").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + " " + Format(dt.Rows(i)("VALUE_DATE"), "dd-MMM-yy")) 'ADDL_TEXT   
                ExlWS.Add("")  'comp_mis_1
                ExlWS.Add("")  'comp_mis_2
                ExlWS.Add("")  'txn_mis_1
                ExlWS.Add("")  'txn_mis_3
                ExlWS.Add("")  'txn_mis_4
                ExlWS.Add("")  'txn_mis_6
                ExlWS.Add("~~END~~")

                'increament of variables for row and currno
                'i = i + 1
                j = j + 1

                sLine = ""
                sLine = ExlWS.Item(0).ToString()
                For n = 1 To ExlWS.Count - 1
                    sLine = sLine + "," + ExlWS.Item(n).ToString()
                Next n

                owrite.WriteLine(sLine)

            Next i

            ''*****************************************************************************************
            ''End All Transaction
            ''*****************************************************************************************

            sLine = ""
            sLine = "~~END~~" + "," + "~~END~~"
            owrite.WriteLine(sLine)

            owrite.Close()

            _FileSuccess = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not (owrite Is Nothing) Then
                owrite.Close()
            End If

        End Try


    End Sub


    Private Function VerifyClientRecords() As Boolean

        Dim flagStatus As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetListInvCredit")

            commProc.Parameters.Clear()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                flagStatus = False
            Else
                flagStatus = True
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        Return flagStatus



    End Function


    Private Function VerifyMissingDeposit() As Boolean

        Dim flagStatus As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetMissingDetail")

            commProc.Parameters.Clear()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                flagStatus = False
            Else
                flagStatus = True
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        Return flagStatus



    End Function

    Private Function VerifyScheduleMismatch() As Boolean

        Dim flagStatus As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetMismatchDetail")

            commProc.Parameters.Clear()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                flagStatus = False
            Else
                flagStatus = True
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        Return flagStatus



    End Function

    Private Function VerifyDepositMismatch() As Boolean

        Dim flagStatus As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CSD_GetMismatchDetailF")

            commProc.Parameters.Clear()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                flagStatus = False
            Else
                flagStatus = True
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        Return flagStatus



    End Function

    Private Function VerifyRecordBeforeFinal() As Boolean

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetUncheckedByBank")

            ''''''''''''''

            For i = 0 To dgView.Rows.Count - 1
                If dgView(0, i).Value = True Then

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, dgView(1, i).Value.ToString())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        Return False
                    End If

                End If
            Next i
            ''''''''''''''

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Return True

    End Function

    Private Function GridItemCheck() As Boolean


        Dim i As Integer

        For i = 0 To dgView.Rows.Count - 1
            If dgView(0, i).Value = True Then
                Return True
            End If
        Next i

        Return False


    End Function

#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        dtpBookingDate.Value = DateTime.Today

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetCorrBankList")

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                'If (i = dgView.Rows.Count - 1) Then
                '    dgView.Rows.Add()
                'End If

                dgView.Item(1, i).Value = dt.Rows(i).Item("BANK_CODE").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("BANK_NAME").ToString()

            Next i






        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim rowsCount, i As Integer
        rowsCount = dgView.Rows.Count

        If chkAll.Checked = True Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = True
            Next i
        ElseIf chkAll.Checked = False Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = False
            Next i
        End If
    End Sub

    Private Sub btnCheckBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckBooking.Click

        
        btnGenBooking.Enabled = False
        btnViewBookedData.Enabled = False
        btnViewCheckedData.Enabled = False

        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()



        'Dim strBank As String = ""
        'Dim i As Integer

        'For i = 0 To dgView.Rows.Count - 1
        '    If dgView(0, i).Value = False Then
        '        If strBank = "" Then
        '            strBank = "'" + dgView(1, i).Value + "'"
        '        Else
        '            strBank = strBank + ",'" + dgView(1, i).Value + "'"
        '        End If

        '    End If
        'Next i

        'MessageBox.Show(strBank)

    End Sub

    Private Sub btnGenBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenBooking.Click

        'If GridItemCheck() = False Then
        '    MessageBox.Show("No bank is selected!! " + _
        '                    Environment.NewLine + "Please select atleast one bank to run a process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If


        'If VerifyRecordBeforeFinal() = False Then
        '    MessageBox.Show("Unchecked data exists!! " + _
        '                    Environment.NewLine + "Prepare checking data required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If


        'If VerifyClientRecords() = False Then
        '    MessageBox.Show("Client credit type is not defined!! " + _
        '                    Environment.NewLine + "Please update credit type of clients", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If


        ''''




        btnCheckBooking.Enabled = False
        btnViewBookedData.Enabled = False
        btnViewCheckedData.Enabled = False


        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker2.RunWorkerAsync()


        'FlexFileGen()

        'Exit Sub

        'PrepareBookingData()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        _ProcessSuccess = False


        If GridItemCheck() = False Then
            MessageBox.Show("No Bank is selected!! " + _
                            Environment.NewLine + "Please select atleast one Bank to run a process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyClientRecords() = False Then
            MessageBox.Show("Client Credit Type is not defined!! " + _
                            Environment.NewLine + "Please update Credit type of clients", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyScheduleMismatch() = False Then
            MessageBox.Show("Deposit Schedule Total Check No./Total Check Amount/Cash Amount mismatch found!! " + _
                            Environment.NewLine + "Please review deposit schedule entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyMissingDeposit() = False Then
            MessageBox.Show("Missing Citicash/CitiSpeed record found for Deposit Schedule!! " + _
                            Environment.NewLine + "Please add Citicash/CitiSpeed data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyDepositMismatch() = False Then
            MessageBox.Show("CitiSpeed Total Check No./Amount mismatch found!! " + _
                            Environment.NewLine + "Please review CitiSpeed entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        PrepareDataForChecking()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous

        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "You can generate booking file data", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        btnGenBooking.Enabled = True
        btnViewBookedData.Enabled = True
        btnViewCheckedData.Enabled = True

    End Sub


    Private Sub FrmBooking_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BackgroundWorker1.IsBusy = True Or BackgroundWorker2.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        _ProcessSuccess = False
        _FileSuccess = False


        If GridItemCheck() = False Then
            MessageBox.Show("No Bank is selected!! " + _
                            Environment.NewLine + "Please select atleast one Bank to run a process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyClientRecords() = False Then
            MessageBox.Show("Client Credit Type is not defined!! " + _
                            Environment.NewLine + "Please update Credit type of clients", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyScheduleMismatch() = False Then
            MessageBox.Show("Deposit Schedule Total Check No./Total Check Amount/Cash Amount mismatch found!! " + _
                            Environment.NewLine + "Please review deposit schedule entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyMissingDeposit() = False Then
            MessageBox.Show("Missing Citicash/CitiSpeed record found for Deposit Schedule!! " + _
                            Environment.NewLine + "Please add Citicash/CitiSpeed data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyDepositMismatch() = False Then
            MessageBox.Show("CitiSpeed Total Check No./Amount mismatch found!! " + _
                            Environment.NewLine + "Please review CitiSpeed entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If




        PrepareBookingData()


    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous
        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "File has been created for Flexcube", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathBooking & "\" & _FileNm)

        End If

        btnCheckBooking.Enabled = True
        btnViewBookedData.Enabled = True
        btnViewCheckedData.Enabled = True

    End Sub

    
    Private Sub btnViewCheckedData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewCheckedData.Click

        Dim rd As New crBookingCheck()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        frmRptViewer.Show()

    End Sub

    Private Sub btnViewBookedData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewBookedData.Click
        _strFileName = InputBox("Please enter filename", "CCMS", _strFileName)
        If _strFileName.Trim() <> "" Then
            Dim rd As New crBooking()


            rd.SetParameterValue("paramFileName", _strFileName)
            rd.SetParameterValue("paramFlexGenDate", dtpBookingDate.Value)

            Dim frmRptViewer As New FrmReportViewer()

            frmRptViewer.SetReport(rd)


            frmRptViewer.Show()
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim frmSearchRef As New FrmCCMSRefSearch()
        frmSearchRef.Show()
    End Sub
End Class