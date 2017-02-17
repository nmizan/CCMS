'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Generate CitiAnywhere Funding File for Flexcube
'Creation date      : 2-Jul-2013
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

Public Class FrmCitiAnyFunding

    Dim _formName As String = "DepositCitiAnywhereFundingFile"
    Dim opt As SecForm = New SecForm(_formName)

    Private _Seq_No As Integer
    Private _Batch_No As String = ""
    Private _Ref_No As String = ""
    Dim _FileNm As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _PathFunding = Environment.CurrentDirectory + "\CitiAnyFunding"
    Dim _strFileName As String = ""


#Region "User defined Procedures"

    Private Sub PrepareFundingData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()




                ''''''''''''''''''''''''''''''''''''''' 
                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_CitiAnyFunding")

                commProc1.Parameters.Clear()

                db.AddInParameter(commProc1, "@VALUE_DATE", DbType.DateTime, dtpDate.Value)
                db.AddOutParameter(commProc1, "@BATCH_NO", DbType.String, 4)
                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc1, trans)
                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If


                _Batch_No = db.GetParameterValue(commProc1, "@BATCH_NO")


                '''''''''''''''''''''''''''''''''''''''ok
                FlexFileGen(db, trans)

                '''''''''''''''''''''''''''''''''''''''

                If _FileSuccess = False Then
                    trans.Rollback()
                    MessageBox.Show("File Generation Aborted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                '----------------------------------------------

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_CitiAnyFundUpdateRef")

                db.AddInParameter(commProc2, "@FILENAME", DbType.String, _FileNm)
                db.AddInParameter(commProc2, "@VALUE_DATE", DbType.DateTime, dtpDate.Value)
                db.AddInParameter(commProc2, "@BATCH_NO", DbType.String, _Batch_No)

                db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                db.ExecuteNonQuery(commProc2, trans)
                result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        If Not Directory.Exists(_PathFunding) Then
            Directory.CreateDirectory(_PathFunding)
        End If


        File.Copy(Environment.CurrentDirectory + "\header.csv", _PathFunding + "\" + _FileNm, True)

        owrite = New System.IO.StreamWriter(_PathFunding + "\" + _FileNm, True)


        Dim sLine As String

        Dim ExlWS As New ArrayList()

        Try

            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CitiAnyFund_GetDetail")
            'db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, dtpDate.Value)

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
                ExlWS.Add(dt.Rows(i)("ACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add("G01")   'ACCOUNT_BRANCH
                ExlWS.Add("429")    'TXN_CODE                
                ExlWS.Add(dt.Rows(i)("DR_CR").ToString())   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Valuedate)   '"" 'VALUE_DATE
                ExlWS.Add(dt.Rows(i)("INSTRUMENT_NO").ToString())   'INSTRUMENT_NO
                ExlWS.Add(dt.Rows(i)("REL_CUST").ToString()) 'REL_CUST
                ExlWS.Add(dt.Rows(i)("ADD_TEXT").ToString())     ' 'ADDL_TEXT                
                ExlWS.Add("")  'comp_mis_1
                ExlWS.Add("")  'comp_mis_2
                ExlWS.Add("")  'txn_mis_1
                ExlWS.Add("")  'txn_mis_3
                ExlWS.Add(dt.Rows(i)("MIS_CODE4").ToString())  'txn_mis_4
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




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    Private Sub FrmReversalGen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub








    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        _ProcessSuccess = False
        _FileSuccess = False

        'btnViewReversalData.Enabled = False

        PrepareFundingData()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous


        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "File has been created for Flexcube", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathFunding & "\" & _FileNm)

        End If

        btnFundingGenerate.Enabled = True


    End Sub



    Private Sub btnReversalGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFundingGenerate.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee

        btnFundingGenerate.Enabled = False


        BackgroundWorker1.RunWorkerAsync()
    End Sub


    Private Sub FrmCitiAnyFunding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        dtpDate.Value = DateTime.Today
    End Sub
End Class