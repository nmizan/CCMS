'
' Generate Charge file transaction for flexcube
' Author: Iftekharul Alam Khan Lodi
' Since: 23-Dec-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmClearingChargeFile

    Dim _formName As String = "ClearingFlexFileForCharge"
    Dim opt As SecForm = New SecForm(_formName)

    'Private _Seq_No As Integer
    'Private _Batch_No As String = ""
    'Private _Ref_No As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _FileNm As String = ""
    Dim _PathClearing = Environment.CurrentDirectory + "\ClearingChargeFlex"
    Dim _strFileName As String

    Dim _BBKAcc As String = ""
    Dim _CitiIncomeAcc As String = ""
    Dim _CitiExpenseAcc As String = ""
    Dim _CitiVATAcc As String = ""
    Dim _valueType As String = ""

#Region "User defined Procedures"

    Private Sub PrepareFinalData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingChargeGenerate")

                commProc1.Parameters.Clear()

                db.AddInParameter(commProc1, "@OPR_DATE_FROM", DbType.DateTime, dtpOprDateFrom.Value)
                db.AddInParameter(commProc1, "@OPR_DATE_TO", DbType.DateTime, dtpOprDateTo.Value)
                db.AddInParameter(commProc1, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc1, trans)
                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result <> 0 Then
                    MessageBox.Show("Process Error. Level 1" + Environment.NewLine + _
                                    "Error No: " + result.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'FlexFileGen()
                FlexFileGen(db, trans)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If _FileSuccess = False Then
                    MessageBox.Show("File Generation Aborted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


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

            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpChargeClearing_GetClientCharge")
            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.DateTime, dtpOprDateFrom.Value)
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.DateTime, dtpOprDateTo.Value)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)


            Dim dt As DataTable = db.ExecuteDataSet(commProc, trans).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("CHARGED"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add("G" + dt.Rows(i)("ACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add("G" + dt.Rows(i)("ACC_NO").ToString().Trim().Substring(0, 2))   'ACCOUNT_BRANCH

                ExlWS.Add("051")    'TXN_CODE

                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("CHARGED"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(Date.Now, "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ' dt.Rows(i)("VOLUME").ToString()
                ExlWS.Add(dt.Rows(i)("VOLUME").ToString())   'INSTRUMENT_NO

                ExlWS.Add("") 'REL_CUST

                ExlWS.Add("Charge calculated against " & dt.Rows(i)("VOLUME").ToString() _
                    & " no check @ Tk" & dt.Rows(i)("CHARGEABLE_AMT").ToString() & " from " & _valueType _
                    & " clearing session " & dtpOprDateFrom.Value.ToString("dd MM yyyy") & " to " _
                    & dtpOprDateTo.Value.ToString("dd MM yyyy")) 'ADDL_TEXT
                

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

            commProc = db.GetStoredProcCommand("CMS_TmpChargeClearing_GetCitiExp")
            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.DateTime, dtpOprDateFrom.Value)
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.DateTime, dtpOprDateTo.Value)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)


            dt = db.ExecuteDataSet(commProc, trans).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("CITIEXP"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(_CitiExpenseAcc.Trim())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(_CitiExpenseAcc.Trim().Substring(0, 3))   'ACCOUNT_BRANCH

                ExlWS.Add("051")    'TXN_CODE

                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("CITIEXP"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(Date.Now, "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ' dt.Rows(i)("VOLUME").ToString()
                ExlWS.Add(dt.Rows(i)("VOLUME").ToString())   'INSTRUMENT_NO

                ExlWS.Add("") 'REL_CUST

                ExlWS.Add("Expense calculated against " & dt.Rows(i)("VOLUME").ToString() _
                    & " no check from " & _valueType _
                    & " clearing session on " & NullHelper.DateToString(dt.Rows(i)("OPR_DATE"), "dd MM yyyy")) 'dt.Rows(i)("OPR_DATE").ToString("dd MM yyyy")) 'ADDL_TEXT


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


            '''''''''''''''''''''''''''''''''''''

            commProc = db.GetStoredProcCommand("CMS_TmpChargeClearing_GetBBKCharge")
            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.DateTime, dtpOprDateFrom.Value)
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.DateTime, dtpOprDateTo.Value)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)


            dt = db.ExecuteDataSet(commProc, trans).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("TOTBBKCHARGE"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(_BBKAcc.Trim())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(_BBKAcc.Trim().Substring(0, 3))   'ACCOUNT_BRANCH

                ExlWS.Add("051")    'TXN_CODE

                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("TOTBBKCHARGE"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(Date.Now, "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ' dt.Rows(i)("VOLUME").ToString()
                ExlWS.Add(dt.Rows(i)("VOLUME").ToString())   'INSTRUMENT_NO

                ExlWS.Add("") 'REL_CUST

                ExlWS.Add("Calculated charge on " & dt.Rows(i)("VOLUME").ToString() _
                    & " no check @ Tk" & dt.Rows(i)("BBK_CHARGE").ToString() & " from " & _valueType _
                    & " clearing session on " & NullHelper.DateToString(dt.Rows(i)("OPR_DATE"), "dd MM yyyy")) 'ADDL_TEXT


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


            '''''''''''''''''''''''''''''''''''''


            commProc = db.GetStoredProcCommand("CMS_TmpChargeClearing_GetCitiIncome")
            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.DateTime, dtpOprDateFrom.Value)
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.DateTime, dtpOprDateTo.Value)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)


            dt = db.ExecuteDataSet(commProc, trans).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("CITIINCOME"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(_CitiIncomeAcc.Trim())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(_CitiIncomeAcc.Trim().Substring(0, 3))   'ACCOUNT_BRANCH

                ExlWS.Add("051")    'TXN_CODE

                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("CITIINCOME"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(Date.Now, "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ' dt.Rows(i)("VOLUME").ToString()
                ExlWS.Add(dt.Rows(i)("VOLUME").ToString())   'INSTRUMENT_NO

                ExlWS.Add("") 'REL_CUST

                ExlWS.Add("Calculated income on " & dt.Rows(i)("VOLUME").ToString() _
                    & " no check from " & _valueType _
                    & " clearing session on " & NullHelper.DateToString(dt.Rows(i)("OPR_DATE"), "dd MM yyyy")) 'ADDL_TEXT


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


            '''''''''''''''''''''''''''''''''''''


            commProc = db.GetStoredProcCommand("CMS_TmpChargeClearing_GetCitiVAT")
            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.DateTime, dtpOprDateFrom.Value)
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.DateTime, dtpOprDateTo.Value)
            db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)


            dt = db.ExecuteDataSet(commProc, trans).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                ExlWS.Add(txtBatchNo.Text.Trim())  'BATCH_NO
                ExlWS.Add(txtFlexBranch.Text.Trim())   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("CITIVAT"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(_CitiIncomeAcc.Trim())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(_CitiIncomeAcc.Trim().Substring(0, 3))   'ACCOUNT_BRANCH

                ExlWS.Add("051")    'TXN_CODE

                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("CITIVAT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(Date.Now, "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ' dt.Rows(i)("VOLUME").ToString()
                ExlWS.Add(dt.Rows(i)("VOLUME").ToString())   'INSTRUMENT_NO

                ExlWS.Add("") 'REL_CUST

                ExlWS.Add("VAT Calculated @ Tk 15% against charges on " & dt.Rows(i)("VOLUME").ToString() _
                    & " no check of " & _valueType _
                    & " clearing session on " & NullHelper.DateToString(dt.Rows(i)("OPR_DATE"), "dd MM yyyy")) 'ADDL_TEXT


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

    'Private Sub LoadOutstandingData()
    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim dt As New DataTable

    '        Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetReturnOutstanding")

    '        commProcSche.Parameters.Clear()


    '        db.AddInParameter(commProcSche, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
    '        db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)


    '        dt = db.ExecuteDataSet(commProcSche).Tables(0)


    '        dgView.Rows.Clear()


    '        If dt.Rows.Count > 0 Then

    '            dgView.AllowUserToAddRows = True
    '            For i = 0 To dt.Rows.Count - 1
    '                If (i = dgView.Rows.Count - 1) Then
    '                    dgView.Rows.Add()
    '                End If


    '                dgView.Item(0, i).Value = NullHelper.DateToString(dt.Rows(i)("OPR_DATE"))
    '                dgView.Item(1, i).Value = dt.Rows(i)("CHECK_NUMBER")
    '                dgView.Item(2, i).Value = dt.Rows(i)("DS_CODE")
    '                dgView.Item(3, i).Value = dt.Rows(i)("DEBIT_CREDIT")
    '                dgView.Item(4, i).Value = NullHelper.ObjectToString(dt.Rows(i)("SEQ_NUMBER"))
    '                dgView.Item(5, i).Value = dt.Rows(i)("REMARK")


    '            Next
    '            dgView.AllowUserToAddRows = False

    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub



    Private Sub LoadComboValues()


        Dim dt1 As New DataTable()

        dt1.Columns.Add("ID")
        dt1.Columns.Add("TYPE")
        Dim dr1 As DataRow = dt1.NewRow()

        dr1 = dt1.NewRow()
        dr1(0) = "1"
        dr1(1) = "Regular"
        dt1.Rows.Add(dr1)

        dr1 = dt1.NewRow()
        dr1(0) = "2"
        dr1(1) = "High"
        dt1.Rows.Add(dr1)

        cmbValueType.DataSource = dt1
        cmbValueType.DisplayMember = "TYPE"
        cmbValueType.ValueMember = "ID"

    End Sub

    Private Function VerifyRecord() As Boolean

        Dim flagStatus As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingChargeSetMas_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@MID", DbType.Int16, 1)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _BBKAcc = NullHelper.ObjectToString(dt.Rows(0)("BBK_ACC"))
                _CitiExpenseAcc = NullHelper.ObjectToString(dt.Rows(0)("CITI_EXP_ACC"))
                _CitiIncomeAcc = NullHelper.ObjectToString(dt.Rows(0)("CITI_INC_ACC"))
                _CitiVATAcc = NullHelper.ObjectToString(dt.Rows(0)("CITI_VAT_ACC"))

                If _BBKAcc.Trim() = "" Or _CitiExpenseAcc.Trim() = "" _
                    Or _CitiIncomeAcc.Trim() = "" Or _CitiVATAcc.Trim() = "" Then

                    MessageBox.Show("Charge A/C not properly set", "Charge Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False

                End If

                flagStatus = True
            Else
                MessageBox.Show("Charge A/C settings not found", "Charge Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flagStatus = False
        End Try



        Return flagStatus



    End Function


#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub





    Private Sub FrmBooking_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BackgroundWorker2.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If


    End Sub

    Private Sub FrmClearingDepositFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try


            CommonAppSet.DebugLevel = "Form Load"
            CommonAppSet.DebugMessage = ""

            If opt.IsShow = False Then
                MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            CommonAppSet.DebugLevel = "Form Load"
            CommonAppSet.DebugMessage = "Load combo value"

            LoadComboValues()

            CommonAppSet.DebugLevel = "Form Load"
            CommonAppSet.DebugMessage = "From Date set"

            dtpOprDateFrom.Value = DateTime.Today



            'LoadOutstandingData()

        Catch ex As Exception
            MessageBox.Show("Debug Level: " + CommonAppSet.DebugLevel + _
                            Environment.NewLine + "Debug Message: " + CommonAppSet.DebugMessage + _
                            Environment.NewLine + "App Message: " + ex.Message, "Form Load Error")
        End Try
    End Sub







    Private Sub btnFinalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalData.Click

        If dtpOprDateFrom.Value > dtpOprDateTo.Value Then
            MessageBox.Show("FROM DATE cannot be higher than TO DATE!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpOprDateTo.Focus()
            Exit Sub
        End If

        If txtBatchNo.Text.Trim() = "" Then
            MessageBox.Show("Batch No required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBatchNo.Focus()
            Exit Sub
        End If

        If cmbValueType.SelectedIndex = -1 Then
            MessageBox.Show("Value Type required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbValueType.Focus()
            Exit Sub
        End If

        If txtFlexBranch.Text.Trim() = "" Then
            MessageBox.Show("Flex Branch No required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFlexBranch.Focus()
            Exit Sub
        End If

        If VerifyRecord() = False Then

            Exit Sub

        End If



        If cmbValueType.SelectedIndex = 0 Then
            _valueType = "RV"
        Else
            _valueType = "HV"

        End If

        ProgressBar1.Style = ProgressBarStyle.Marquee
        'cmbValueType.CheckForIllegalCrossThreadCalls = Debugger.IsAttached
        'ComboBox.CheckForIllegalCrossThreadCalls = false
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

    End Sub

 
End Class