'
' Generate booking file for flexcube
' Author: Iftekharul Alam Khan Lodi
' Since: 20-Feb-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmClearingDepositFile

    Dim _formName As String = "ClearingFlexFile"
    Dim opt As SecForm = New SecForm(_formName)

    'Private _Seq_No As Integer
    'Private _Batch_No As String = ""
    'Private _Ref_No As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _FileNm As String = ""
    Dim _PathClearing = Environment.CurrentDirectory + "\ClearingData"
    Dim _strFileName As String

    Dim cmbEntryLocationSelectedValue As String = ""
    Dim cmbValueTypeSelectedValue As String = ""

#Region "User defined Procedures"

    Private Sub PrepareDataForChecking()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingRevGenerate")

                commProc1.Parameters.Clear()

                db.AddInParameter(commProc1, "@REV_DATE", DbType.DateTime, dtpOprDate.Value)
                db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
                'db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
                db.AddInParameter(commProc1, "@REFACC_NO", DbType.String, txtFlexBranch.Text.Trim())
                db.AddInParameter(commProc1, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
                'db.AddInParameter(commProc1, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc1, trans)
                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingDataChecked")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
                db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
                'db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
                db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
                'db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

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

    Private Sub PrepareFinalData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingRevGenerate")

            commProc1.Parameters.Clear()

            db.AddInParameter(commProc1, "@REV_DATE", DbType.DateTime, dtpOprDate.Value)
            'db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
            db.AddInParameter(commProc1, "@REFACC_NO", DbType.String, txtFlexBranch.Text.Trim())
            db.AddInParameter(commProc1, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
            'db.AddInParameter(commProc1, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc1)
            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

            If result > 0 Then
                MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            FlexFileGen()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If _FileSuccess = False Then
                MessageBox.Show("File Generation Aborted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingDataFinalUpdate")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@REV_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
            'db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
            'db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)
            db.AddInParameter(commProc2, "@FLEX_FILENAME", DbType.String, _FileNm)


            db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            db.ExecuteNonQuery(commProc2)
            result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

            If result > 0 Then
                MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            _ProcessSuccess = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub FlexFileGen()


        Dim brcode As String       'for branch
        Dim Valuedate As String       'for date format yyyymmdd
        'Dim serial As Currency     'to count serial


        Dim sourcecode As String

        Dim j As Integer = 1

        brcode = txtFlexBranch.Text.Trim()
        sourcecode = brcode + txtBatchNo.Text.Trim()
        _FileNm = "F" + brcode + txtBatchNo.Text.Trim()

        Valuedate = Format(Date.Now, "dd- MMMM - yy") '
        'serial = 0

        _FileNm = _FileNm + ".csv"
        Dim owrite As System.IO.StreamWriter

        If Not Directory.Exists(_PathClearing) Then
            Directory.CreateDirectory(_PathClearing)
        End If

        If File.Exists(_PathClearing + "\" + _FileNm) Then
            If MessageBox.Show("File exists." + Environment.NewLine + _
                            "Do you want to replace the existing file.", "File Exist", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        File.Copy(Environment.CurrentDirectory + "\header.csv", _PathClearing + "\" + _FileNm, True)

        owrite = New System.IO.StreamWriter(_PathClearing + "\" + _FileNm, True)

        Dim sLine As String

        Dim ExlWS As New ArrayList()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpReversalClearing_GetDetail")
            db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
            'db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
            'db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add("G" + dt.Rows(i)("ACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add("G" + dt.Rows(i)("ACC_NO").ToString().Trim().Substring(0, 2))   'ACCOUNT_BRANCH

                ExlWS.Add("451")    'TXN_CODE

                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dtpOprDate.Value, "dd- MMMM - yy"))   '"" 'VALUE_DATE

                ExlWS.Add(dt.Rows(i)("CHECK_NUMBER").ToString())   'INSTRUMENT_NO
                ExlWS.Add("") 'REL_CUST
                If (dt.Rows(i)("CR_TYPE") = "RD") Then
                    ExlWS.Add(dt.Rows(i)("SEQ_NO").ToString() + " " + dt.Rows(i)("ADD_TEXT").ToString().Replace(vbNewLine, " "))  'ADDL_TEXT
                ElseIf (dt.Rows(i)("CR_TYPE") = "RC") Then
                    ExlWS.Add(dt.Rows(i)("ADD_TEXT").ToString().Replace(vbNewLine, " "))
                Else
                    ExlWS.Add(dt.Rows(i)("SEQ_NO").ToString() + " Checks Deposited on Date: " + Valuedate + " DsCode " + IIf(dt.Rows(i)("DS_CODE") Is Nothing, "", dt.Rows(i)("DS_CODE").ToString()) + " Ref:" + IIf(dt.Rows(i)("CUSTOMER_REF") Is Nothing, "", dt.Rows(i)("CUSTOMER_REF").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + " INV Code " + dt.Rows(i)("ADD_TEXT").ToString().Replace(vbNewLine, " "))) 'ADDL_TEXT
                End If

                'ExlWS.Add(dt.Rows(i)("REMARKS").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "")) '= Replace(Replace(Replace(Replace(Trim(rs!Remarks), ",", ""), "'", ""), "-", ""), ".", "") 'ADDL_TEXT
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
            Dim commProcTot As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetTotalCheck")
            db.AddInParameter(commProcTot, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProcTot, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
            'db.AddInParameter(commProcTot, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProcTot, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
            'db.AddInParameter(commProcTot, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            Dim dtTot As DataTable = db.ExecuteDataSet(commProcTot).Tables(0)

            Dim intTotCheck As Integer = 0

            If dtTot.Rows.Count > 0 Then
                intTotCheck = NullHelper.ToIntNum(dtTot.Rows(0)("TOTCHECK"))
            End If

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TmpReversalClearing_GetFlexDetail")
            db.AddInParameter(commProc2, "@REV_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocationSelectedValue)
            'db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueTypeSelectedValue)
            'db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

            dt = db.ExecuteDataSet(commProc2).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()


                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("CREDTOTAL"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(txtDebitAcc.Text.Trim())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(txtDebitAcc.Text.Trim().Substring(0, 3))   'ACCOUNT_BRANCH

                ExlWS.Add("13")    'TXN_CODE

                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("CREDTOTAL"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dtpOprDate.Value, "dd- MMMM - yy"))   '"" 'VALUE_DATE

                'If (dt.Rows(i)("CR_TYPE") = "RD" Or dt.Rows(i)("CR_TYPE") = "RC") Then
                '    ExlWS.Add(dt.Rows(i)("CHECK_NUMBER").ToString())
                'Else
                ExlWS.Add(Format(dtpOprDate.Value, "ddMMyy"))   'INSTRUMENT_NO
                'End If

                ExlWS.Add("") 'REL_CUST

                'If (dt.Rows(i)("CR_TYPE") = "RD") Then
                '    ExlWS.Add(dt.Rows(i)("SEQ_NO").ToString() + " " + dt.Rows(i)("ADD_TEXT").ToString())  'ADDL_TEXT
                'ElseIf (dt.Rows(i)("CR_TYPE") = "RC") Then
                '    ExlWS.Add(dt.Rows(i)("ADD_TEXT").ToString())
                'Else
                ExlWS.Add("OUTWARD TOTAL CHECK :" + intTotCheck.ToString())  'ADDL_TEXT
                'End If
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

    Private Sub LoadOutstandingData()
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetOutstandings")

            commProcSche.Parameters.Clear()


            db.AddInParameter(commProcSche, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)


            dt = db.ExecuteDataSet(commProcSche).Tables(0)


            dgView.Rows.Clear()


            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If


                    dgView.Item(0, i).Value = NullHelper.DateToString(dt.Rows(i)("OPR_DATE"))
                    dgView.Item(1, i).Value = dt.Rows(i)("CHECK_NUMBER")
                    dgView.Item(2, i).Value = dt.Rows(i)("DS_CODE")
                    dgView.Item(3, i).Value = dt.Rows(i)("DEBIT_CREDIT")
                    dgView.Item(4, i).Value = NullHelper.IntToValueType(dt.Rows(i)("VALUE_TYPE"))
                    dgView.Item(5, i).Value = NullHelper.ToIntNum(dt.Rows(i)("CHECKED"))


                Next
                dgView.AllowUserToAddRows = False

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadComboValues()


        Dim dt1 As New DataTable()

        dt1.Columns.Add("ID")
        dt1.Columns.Add("TYPE")
        Dim dr1 As DataRow = dt1.NewRow()

        dr1 = dt1.NewRow()
        dr1(0) = "1"
        dr1(1) = "Low"
        dt1.Rows.Add(dr1)

        dr1 = dt1.NewRow()
        dr1(0) = "2"
        dr1(1) = "High"
        dt1.Rows.Add(dr1)

        cmbValueType.DataSource = dt1
        cmbValueType.DisplayMember = "TYPE"
        cmbValueType.ValueMember = "ID"

    End Sub

    Private Function VerifyRecordBeforeFinal() As Boolean

        Dim flagStatus As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetUnchecked")

            commProc.Parameters.Clear()


            db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

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


#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub




    Private Sub btnCheckBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckData.Click

        If txtBatchNo.Text.Trim() = "" Then
            MessageBox.Show("Batch No required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBatchNo.Focus()
            Exit Sub
        End If

        If txtFlexBranch.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If txtDebitAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If cmbValueType.SelectedIndex = -1 Then
            MessageBox.Show("Value Type required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbValueType.Focus()
            Exit Sub
        End If


        ProgressBar1.Style = ProgressBarStyle.Marquee

        btnFinalData.Enabled = False

        cmbEntryLocationSelectedValue = cmbEntryLocation.SelectedValue
        cmbValueTypeSelectedValue = cmbValueType.SelectedValue

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



    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        _ProcessSuccess = False
        PrepareDataForChecking()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous

        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "You can check file data", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        btnFinalData.Enabled = True
    End Sub

    Private Sub FrmBooking_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BackgroundWorker1.IsBusy = True Or BackgroundWorker2.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If


    End Sub

    Private Sub FrmClearingDepositFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        LoadComboValues()

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

        dtpOprDate.Value = DateTime.Today



        LoadOutstandingData()


    End Sub



    Private Sub cmbEntryLocation_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEntryLocation.SelectionChangeCommitted

        If cmbEntryLocation.SelectedIndex >= 0 Then



            Try

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim dt As New DataTable

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CitiBankBranch_GetDetailByCode")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, cmbEntryLocation.SelectedValue)

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then
                    txtFlexBranch.Text = dt.Rows(0)("CLEARING_DEBIT_ACC").ToString().Trim().Substring(0, 3)
                    txtDebitAcc.Text = dt.Rows(0)("CLEARING_DEBIT_ACC").ToString().Trim()
                Else
                    txtFlexBranch.Clear()
                    txtDebitAcc.Clear()
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            LoadOutstandingData()


        End If

        
    End Sub


    Private Sub dtpOprDate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOprDate.Validated
        LoadOutstandingData()
    End Sub


    Private Sub btnFinalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalData.Click

        If txtBatchNo.Text.Trim() = "" Then
            MessageBox.Show("Batch No required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBatchNo.Focus()
            Exit Sub
        End If

        If txtFlexBranch.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If txtDebitAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If cmbValueType.SelectedIndex = -1 Then
            MessageBox.Show("Value Type required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbValueType.Focus()
            Exit Sub
        End If

        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Checking Process Runing!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VerifyRecordBeforeFinal() = False Then
            MessageBox.Show("Unchecked data exists!! " + _
                            Environment.NewLine + "Prepare checking data required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If






        btnCheckData.Enabled = False

        ProgressBar1.Style = ProgressBarStyle.Marquee

        cmbEntryLocationSelectedValue = cmbEntryLocation.SelectedValue
        cmbValueTypeSelectedValue = cmbValueType.SelectedValue

        BackgroundWorker2.RunWorkerAsync()

        'FlexFileGen()

        'Exit Sub

        'PrepareFinalData()

    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        _ProcessSuccess = False
        _FileSuccess = False
        PrepareFinalData()

    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous
        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "File has been created for Flexcube", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathClearing & "\" & _FileNm)

        End If

        btnCheckData.Enabled = True

    End Sub

    Private Sub btnViewData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewCheckData.Click
        If txtFlexBranch.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If txtDebitAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If cmbValueType.SelectedIndex = -1 Then
            MessageBox.Show("Value Type required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbValueType.Focus()
            Exit Sub
        End If




        Dim rd As New crReversalClearingCheck()


        Dim strFormula As String = ""

        strFormula = "{V_REVERSAL_CLEAR_CHECK.ENTRY_LOC}='" & cmbEntryLocation.SelectedValue.ToString() & "'" & _
            " AND {V_REVERSAL_CLEAR_CHECK.VALUE_TYPE}=" & cmbValueType.SelectedValue.ToString()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If





        frmRptViewer.Show()





    End Sub

    Private Sub btnViewFinalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewFinalData.Click

        If txtFlexBranch.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If txtDebitAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        _strFileName = InputBox("Please enter filename", "CCMS", _strFileName)

        If _strFileName.Trim() <> "" Then
            Dim rd As New crReversalClearingFinal()

            rd.SetParameterValue("paramFilename", _strFileName.Trim())
            rd.SetParameterValue("paramRevdate", dtpOprDate.Value)
            rd.SetParameterValue("paramEntryLoc", cmbEntryLocation.SelectedValue.ToString())

            Dim frmRptViewer As New FrmReportViewer()

            frmRptViewer.SetReport(rd)

            frmRptViewer.Show()

        End If


    End Sub

   
End Class