
'
' Generate Return file for flexcube
' Author: Fahad Khan
' Since: 05-Nov-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic



Public Class FrmCitiSpeedReturnFile

    Dim _formName As String = "CollectionCitiSpeedReturnFile"
    Dim opt As SecForm = New SecForm(_formName)

    Private _Seq_No As Integer
    Private _Batch_No As String = ""
    Private _Ref_No As String = ""
    Dim _FileNm As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _PathReturn = Environment.CurrentDirectory + "\CollectionReturnData"
    Dim _strFileName As String = ""

#Region "User defined Procedures"

    Private Sub PrepareReversalData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()




                ''''''''''''''''''''''''''''''''''''''' ok
                'Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ReturnGenerate")

                Dim commProc1 As DbCommand = db.GetSqlStringCommand("SET NOCOUNT ON;" _
+ "	DECLARE @D_CODE	varchar(12),@SLNO numeric(3,0),@RTN_CODE varchar(2) ;" _
    + " DELETE FROM TMP_RETURN_CSD WHERE RTN_DATE = @RTN_DATE ;" _
    + " DECLARE @ErrorVar	int;" _
 + " SELECT @ErrorVar = @@ERROR;" _
 + " DECLARE tmpcursor1 CURSOR FOR" _
  + " SELECT D_CODE, SLNO, RTN_CODE FROM RETURN_CSD WHERE RTN_STATUS ='R' AND RTN_DATE = @RTN_DATE AND [STATUS]='L';" _
 + " OPEN tmpcursor1;" _
 + " FETCH NEXT FROM tmpcursor1 INTO @D_CODE,@SLNO , @RTN_CODE;" _
 + " WHILE @@FETCH_STATUS=0 " _
                    + " BEGIN" _
      + " INSERT INTO TMP_RETURN_CSD( RTN_DATE, CLIENT_CODE, AC_NO, LOCATION_CODE, " _
      + " LOCATION_NAME, AMOUNT, DS_CODE, D_CODE, SLNO, BANK_ACC_NO, INSTRUMENT_NO, " _
      + " SCHEDULE_DATE, CS_CODE, REASON )  " _
  + " SELECT @RTN_DATE ,ds.CLIENT_CODE,c.ACC_NO , ds.LOCATION_CODE, l.LOCATION_NAME, " _
  + " csd.AMOUNT ,ds.DS_CODE, csd.D_CODE, csd.SLNO, b.ACC_NO , csd.CHECK_NO , " _
  + " ds.SCHEDULE_DATE,csc.CS_CODE , rr.REJECT_REASON FROM CSD_DET csd " _
  + " INNER JOIN DSCHEDULE ds ON csd.D_CODE = ds.D_CODE AND ds.[STATUS]='L'" _
  + " INNER JOIN CLIENT c ON c.CLIENT_CODE = ds.CLIENT_CODE " _
  + " INNER JOIN LOCATION l ON ds.LOCATION_CODE = l.LOCATION_CODE " _
  + " INNER JOIN BANK b ON b.BANK_CODE = csd.DRAWEE_BANK_CODE " _
  + " INNER JOIN RETURN_REJECT rr ON rr.REJECT_CODE = @RTN_CODE  " _
  + " INNER JOIN CSCHEDULE csc ON csc.DS_CODE = ds.DS_CODE AND csc.[STATUS]='L'" _
  + " WHERE csd.[STATUS]='L' AND csd.RTN_STATUS ='R' AND csd.D_CODE = @D_CODE " _
  + " AND csd.SLNO = @SLNO AND csd.RTN_CODE = @RTN_CODE ;" _
  + " FETCH NEXT FROM tmpcursor1 " _
   + " INTO @D_CODE,@SLNO , @RTN_CODE;" _
                + "End" _
 + " CLOSE tmpcursor1;	" _
 + " DEALLOCATE tmpcursor1; " _
 + " SELECT @ErrorVar = @@ERROR;")

                '              Dim cmd As DbCommand = db.GetSqlStringCommand("DELETE FROM TMP_RETURN_CSD WHERE RTN_DATE = @RTN_DATE ;")

                '              cmd.Parameters.Clear()

                '              db.AddInParameter(cmd, "@RTN_DATE", DbType.DateTime, dtpDate.Value)

                '              db.ExecuteNonQuery(cmd, trans)


                '              cmd = db.GetSqlStringCommand("SELECT D_CODE, SLNO, RTN_CODE FROM RETURN_CSD WHERE RTN_STATUS ='R' AND Convert(date,INPUT_DATETIME) = Convert(date,@RTN_DATE) AND [STATUS]='L';")

                '              cmd.Parameters.Clear()

                '              db.AddInParameter(cmd, "@RTN_DATE", DbType.DateTime, dtpDate.Value)

                '              Dim dt As DataTable = db.ExecuteDataSet(cmd, trans).Tables(0)

                '              For i As Integer = 0 To dt.Rows.Count - 1
                '                  cmd = db.GetSqlStringCommand(" INSERT INTO TMP_RETURN_CSD( RTN_DATE, CLIENT_CODE, AC_NO, LOCATION_CODE, " _
                '    + " LOCATION_NAME, AMOUNT, DS_CODE, D_CODE, SLNO, BANK_ACC_NO, INSTRUMENT_NO, " _
                '    + " SCHEDULE_DATE, CS_CODE, REASON)" _
                '+ " SELECT @RTN_DATE ,ds.CLIENT_CODE,c.ACC_NO , ds.LOCATION_CODE, l.LOCATION_NAME, " _
                '+ " csd.AMOUNT ,ds.DS_CODE, csd.D_CODE, csd.SLNO, b.ACC_NO , csd.CHECK_NO , " _
                '+ " ds.SCHEDULE_DATE,csc.CS_CODE , rr.REJECT_REASON FROM CSD_DET csd " _
                '+ " INNER JOIN DSCHEDULE ds ON csd.D_CODE = ds.D_CODE AND ds.[STATUS]='L'" _
                '+ " INNER JOIN CLIENT c ON c.CLIENT_CODE = ds.CLIENT_CODE " _
                '+ " INNER JOIN LOCATION l ON ds.LOCATION_CODE = l.LOCATION_CODE " _
                '+ " INNER JOIN BANK b ON b.BANK_CODE = csd.DRAWEE_BANK_CODE " _
                '+ " INNER JOIN RETURN_REJECT rr ON rr.REJECT_CODE = @RTN_CODE  " _
                '+ " INNER JOIN CSCHEDULE csc ON csc.DS_CODE = ds.DS_CODE AND csc.[STATUS]='L'" _
                '+ " WHERE csd.[STATUS]='L' AND csd.RTN_STATUS ='R' AND csd.D_CODE = @D_CODE " _
                '+ " AND csd.SLNO = @SLNO AND csd.RTN_CODE = @RTN_CODE ;")
                '                  cmd.Parameters.Clear()
                '                  db.AddInParameter(cmd, "@RTN_DATE", DbType.DateTime, dtpDate.Value)
                '                  db.AddInParameter(cmd, "@D_CODE", DbType.String, dt.Rows(i)("D_CODE"))
                '                  db.AddInParameter(cmd, "@SLNO", DbType.Int32, dt.Rows(i)("SLNO"))
                '                  db.AddInParameter(cmd, "@RTN_CODE", DbType.String, dt.Rows(i)("RTN_CODE"))
                '                  db.ExecuteNonQuery(cmd, trans)
                '              Next i

                commProc1.Parameters.Clear()

                db.AddInParameter(commProc1, "@RTN_DATE", DbType.DateTime, dtpDate.Value)

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc1, trans)
                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If



                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_Process_ReturnBatch")

                commProc3.Parameters.Clear()


                db.AddOutParameter(commProc3, "@BATCH_NO", DbType.String, 4)

                db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)


                db.ExecuteNonQuery(commProc3, trans)
                result = db.GetParameterValue(commProc3, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If


                _Batch_No = db.GetParameterValue(commProc3, "@BATCH_NO")


                '''''''''''''''''''''''''''''''''''''''ok
                FlexFileGen(db, trans)

                '''''''''''''''''''''''''''''''''''''''

                If _FileSuccess = False Then
                    trans.Rollback()
                    MessageBox.Show("File Generation Aborted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                '----------------------------------------------

                'Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_ReturnUpdateRef")

                Dim commProc4 As DbCommand = db.GetSqlStringCommand("UPDATE GENPRM SET BATCH_NO=@BATCH_NO, BATCH_DATE=GETDATE(); " _
                + " Update RETURN_CSD SET RTN_FILENAME=@FILENAME,RTN_FILE_USERID=@RTN_FILE_USERID" _
  + " WHERE  Convert(date,INPUT_DATETIME) = Convert(date,@RTN_DATE) AND [STATUS]='L';")

                db.AddInParameter(commProc4, "@FILENAME", DbType.String, _FileNm)
                db.AddInParameter(commProc4, "@RTN_DATE", DbType.DateTime, dtpDate.Value)
                db.AddInParameter(commProc4, "@BATCH_NO", DbType.String, _Batch_No)
                db.AddInParameter(commProc4, "@RTN_FILE_USERID", DbType.String, CommonAppSet.User)

                'db.AddParameter(commProc4, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                db.ExecuteNonQuery(commProc4, trans)
                'result = db.GetParameterValue(commProc4, "@PROC_RET_VAL")

                'If result > 0 Then
                '    trans.Rollback()
                '    MessageBox.Show("Process Error. Level 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub

                'End If

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

        If Not Directory.Exists(_PathReturn) Then
            Directory.CreateDirectory(_PathReturn)
        End If


        File.Copy(Environment.CurrentDirectory + "\header.csv", _PathReturn + "\" + _FileNm, True)

        owrite = New System.IO.StreamWriter(_PathReturn + "\" + _FileNm, True)


        Dim sLine As String

        Dim ExlWS As New ArrayList()

        Try

            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpReturnCSD_GetFlexDrDetail")
            db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, dtpDate.Value)

            Dim dt As DataTable = db.ExecuteDataSet(commProc, trans).Tables(0)

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
                ExlWS.Add(dt.Rows(i)("AC_NO").ToString())    '"Acc_Name '""
                If (dt.Rows(i)("AC_NO").ToString().Trim().Length >= 3) Then
                    ExlWS.Add(dt.Rows(i)("AC_NO").ToString().Trim().Substring(0, 3))   'ACCOUNT_BRANCH
                Else
                    ExlWS.Add("")
                End If
                ExlWS.Add("065")    'TXN_CODE

                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dt.Rows(i)("RTN_DATE"), "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ExlWS.Add(dt.Rows(i)("INSTRUMENT_NO").ToString())   'INSTRUMENT_NO
                'ExlWS.Add("'" + dt.Rows(i)("INSTRUMENT_NO").ToString())   'INSTRUMENT_NO
                ExlWS.Add("") 'REL_CUST

                ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", " ") + "-" + Format(dt.Rows(i)("RTN_DATE"), "dd/MM/yyyy") + " DS-" + dt.Rows(i)("D_CODE").ToString() + " REASON " + dt.Rows(i)("REASON").ToString())     ' 'ADDL_TEXT

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

            'Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TmpReturnCSD_GetFlexCrDetail")
            '' Commented on 13 Dec 2015 by Yasir
            '       Dim commProc2 As DbCommand = db.GetSqlStringCommand("SELECT BANK_ACC_NO , LOCATION_NAME, SCHEDULE_DATE," _
            '                                                           + "sum(AMOUNT)as credtotal," _
            '       + "INSTRUMENT_NO,CS_CODE, RTN_DATE" _
            '       + " FROM TMP_RETURN_CSD" _
            '+ " WHERE RTN_DATE=@RTN_DATE" _
            '+ " GROUP BY INSTRUMENT_NO,BANK_ACC_NO,LOCATION_NAME,SCHEDULE_DATE,CS_CODE,RTN_DATE")
            ' on 13 Dec 2015 by Yasir
            Dim commProc2 As DbCommand = db.GetSqlStringCommand("SELECT BANK_ACC_NO , LOCATION_NAME, SCHEDULE_DATE," _
                                                               + "sum(AMOUNT)as credtotal," _
           + "INSTRUMENT_NO,RTN_DATE,CS_CODE" _
           + " FROM TMP_RETURN_CSD" _
    + " WHERE RTN_DATE=@RTN_DATE" _
    + " GROUP BY BANK_ACC_NO,LOCATION_NAME,SCHEDULE_DATE, INSTRUMENT_NO,RTN_DATE, CS_CODE")

            db.AddInParameter(commProc2, "@RTN_DATE", DbType.DateTime, dtpDate.Value)

            dt = db.ExecuteDataSet(commProc2, trans).Tables(0)



            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()


                ExlWS.Add(_Batch_No)  'BATCH_NO
                ExlWS.Add("G01")   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("credtotal"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(dt.Rows(i)("BANK_ACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                If (dt.Rows(i)("BANK_ACC_NO").ToString().Trim().Length >= 3) Then
                    ExlWS.Add(dt.Rows(i)("BANK_ACC_NO").ToString().Trim().Substring(0, 3))   'ACCOUNT_BRANCH
                Else
                    ExlWS.Add("")
                End If
                ExlWS.Add("065")  'TXN_CODE

                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("credtotal"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dtpDate.Value, "dd- MMMM - yy"))   '"" 'VALUE_DATE

                ExlWS.Add(dt.Rows(i)("CS_CODE").ToString())   'INSTRUMENT_NO

                'ExlWS.Add("'" + dt.Rows(i)("CS_CODE").ToString())   'INSTRUMENT_NO

                ExlWS.Add("") 'REL_CUST

                ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", " ") + "-" + Format(dt.Rows(i)("RTN_DATE"), "dd/MM/yyyy"))     ' 'ADDL_TEXT


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
            MessageBox.Show(ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not (owrite Is Nothing) Then
                owrite.Close()
            End If

        End Try


    End Sub



#End Region

    Private Sub FrmCitiSpeedReturnFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        dtpDate.Value = DateTime.Today
    End Sub

    Private Sub FrmCitiSpeedReturnFile_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub

    Private Sub btnReturnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnGenerate.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous


        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "File has been created for Flexcube", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathReturn & "\" & _FileNm)

        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        _ProcessSuccess = False
        _FileSuccess = False

        PrepareReversalData()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class