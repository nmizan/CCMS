'
' Generate Return file transaction for flexcube
' Author: Iftekharul Alam Khan Lodi
' Since: 21-Aug-13
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmClearingReturnFile

    Dim _formName As String = "ClearingFlexFileForReturnChecks"
    Dim opt As SecForm = New SecForm(_formName)

    'Private _Seq_No As Integer
    'Private _Batch_No As String = ""
    'Private _Ref_No As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _FileNm As String = ""
    Dim _PathClearing = Environment.CurrentDirectory + "\ClearingReturnFlex"
    Dim _strFileName As String

#Region "User defined Procedures"

    'Private Sub PrepareDataForChecking()

    '    lblToolStatus.Text = ""

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Using conn As DbConnection = db.CreateConnection()

    '            conn.Open()

    '            Dim trans As DbTransaction = conn.BeginTransaction()

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingRevGenerate")

    '            commProc1.Parameters.Clear()

    '            db.AddInParameter(commProc1, "@REV_DATE", DbType.DateTime, dtpOprDate.Value)
    '            db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
    '            db.AddInParameter(commProc1, "@REFACC_NO", DbType.String, txtFlexBranch.Text.Trim())
    '            db.AddInParameter(commProc1, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

    '            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '            Dim result As Integer

    '            db.ExecuteNonQuery(commProc1, trans)
    '            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

    '            If result > 0 Then
    '                trans.Rollback()
    '                MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub

    '            End If

    '            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingDataChecked")

    '            commProc2.Parameters.Clear()

    '            db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
    '            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
    '            db.AddInParameter(commProc2, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

    '            db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '            db.ExecuteNonQuery(commProc2, trans)
    '            result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

    '            If result > 0 Then
    '                trans.Rollback()
    '                MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If


    '            trans.Commit()
    '            _ProcessSuccess = True

    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    'End Sub

    Private Sub PrepareFinalData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingRetGenerate")

            commProc1.Parameters.Clear()

            db.AddInParameter(commProc1, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc1)
            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

            If result <> 0 Then
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

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_ClearingDataReturnUpdate")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc2, "@FLEX_FILENAME", DbType.String, _FileNm)
            'db.AddInParameter(commProc2, "@REFACC_NO", DbType.String, txtCreditAcc.Text.Trim())



            db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            db.ExecuteNonQuery(commProc2)
            result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

            If result <> 0 Then
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

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpReturnClearing_GetDetail")
            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)


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

                ExlWS.Add("051")    'TXN_CODE

                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dtpOprDate.Value, "dd- MMMM - yy"))   '"" 'VALUE_DATE

                If dt.Rows(i)("RULETYPE") = "1" Then

                    ExlWS.Add(dtpOprDate.Value.ToString("ddMMyyyy"))   'INSTRUMENT_NO

                ElseIf dt.Rows(i)("RULETYPE") = "2" Then

                    'dtpOprDate.Value.ToString("ddMMyyyy") & dt.Rows(i)("ACC_NO").ToString().Trim().Substring(dt.Rows(i)("ACC_NO").ToString().Trim().Length - 4, 3)
                    ExlWS.Add(dtpOprDate.Value.ToString("ddMMyyyy") & dt.Rows(i)("ACC_NO").ToString().Trim().Substring(dt.Rows(i)("ACC_NO").ToString().Trim().Length - 3, 3))   'INSTRUMENT_NO

                Else

                    ExlWS.Add(dt.Rows(i)("INSTRUMENT").ToString())   'INSTRUMENT_NO

                End If



                ExlWS.Add("") 'REL_CUST

                If dt.Rows(i)("RULETYPE") = "1" Then
                    ExlWS.Add(dt.Rows(i)("ADDTEXT").ToString() & " CQS RTN FM CLEARING HOUSE ON " & dtpOprDate.Value.ToString("dd MM yyyy")) 'ADDL_TEXT
                ElseIf dt.Rows(i)("RULETYPE") = "2" Then
                    ExlWS.Add(dt.Rows(i)("ADDTEXT").ToString() & " CQS RTN FM CLEARING HOUSE ON " & dtpOprDate.Value.ToString("dd MM yyyy")) 'ADDL_TEXT
                Else
                    ExlWS.Add(dt.Rows(i)("ADDTEXT").ToString())
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


            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetFlexReturn")
            db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            
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
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add(txtCreditAcc.Text.Trim())   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(txtCreditAcc.Text.Trim().Substring(0, 3))   'ACCOUNT_BRANCH

                ExlWS.Add("13")    'TXN_CODE

                ExlWS.Add("C")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dtpOprDate.Value, "dd- MMMM - yy"))   '"" 'VALUE_DATE
                ExlWS.Add(Format(dtpOprDate.Value, "ddMMyy"))   'INSTRUMENT_NO
                ExlWS.Add("") 'REL_CUST
                ExlWS.Add(dt.Rows(i)("TOTCHECK").ToString() + " CQS RTN")  'ADDL_TEXT
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



    'Private Sub LoadComboValues()


    '    Dim dt1 As New DataTable()

    '    dt1.Columns.Add("ID")
    '    dt1.Columns.Add("TYPE")
    '    Dim dr1 As DataRow = dt1.NewRow()

    '    dr1 = dt1.NewRow()
    '    dr1(0) = "1"
    '    dr1(1) = "Low"
    '    dt1.Rows.Add(dr1)

    '    dr1 = dt1.NewRow()
    '    dr1(0) = "2"
    '    dr1(1) = "High"
    '    dt1.Rows.Add(dr1)

    '    cmbValueType.DataSource = dt1
    '    cmbValueType.DisplayMember = "TYPE"
    '    cmbValueType.ValueMember = "ID"

    'End Sub

    'Private Function VerifyRecordBeforeFinal() As Boolean

    '    Dim flagStatus As Boolean = False

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim dt As New DataTable

    '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetUnchecked")

    '        commProc.Parameters.Clear()


    '        db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, dtpOprDate.Value)
    '        db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
    '        db.AddInParameter(commProc, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue)

    '        dt = db.ExecuteDataSet(commProc).Tables(0)

    '        If dt.Rows.Count > 0 Then
    '            flagStatus = False
    '        Else
    '            flagStatus = True
    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try



    '    Return flagStatus



    'End Function


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
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        'LoadComboValues()

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

        dtpOprDate.Value = DateTime.Today



        'LoadOutstandingData()


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
                    txtCreditAcc.Text = dt.Rows(0)("CLEARING_DEBIT_ACC").ToString().Trim()
                Else
                    txtFlexBranch.Clear()
                    txtCreditAcc.Clear()
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            'LoadOutstandingData()


        End If

    End Sub


    Private Sub dtpOprDate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOprDate.Validated
        'LoadOutstandingData()
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

        If txtCreditAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If


        ProgressBar1.Style = ProgressBarStyle.Marquee


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

    Private Sub btnViewData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewCheckData.Click
        If txtFlexBranch.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        If txtCreditAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If


        Dim rd As New crClearReturnHistCheck()


        Dim strFormula As String = ""

        strFormula = "{V_RETURN_HIST_CLEAR_CHECK.ENTRY_LOC}='" & cmbEntryLocation.SelectedValue.ToString() & "'" & _
            " AND {V_RETURN_HIST_CLEAR_CHECK.OPR_DATE}<=#" & NullHelper.StringToCrDateString(NullHelper.DateToString(dtpOprDate.Value)) & "#"

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

        If txtCreditAcc.Text.Trim() = "" Then
            MessageBox.Show("Entry location required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If

        _strFileName = InputBox("Please enter filename", "CCMS", _strFileName)

        If _strFileName.Trim() <> "" Then
            Dim rd As New crClearReturnHistFinal()

            rd.SetParameterValue("paramFilename", _strFileName.Trim())
            rd.SetParameterValue("paramValueDate", dtpOprDate.Value)
            rd.SetParameterValue("paramEntryLoc", cmbEntryLocation.SelectedValue.ToString())

            Dim frmRptViewer As New FrmReportViewer()

            frmRptViewer.SetReport(rd)

            frmRptViewer.Show()

        End If


    End Sub

End Class