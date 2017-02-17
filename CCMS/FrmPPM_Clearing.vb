Imports System.IO
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmPPM_Clearing
    Dim rowCount As Integer = 0
    Dim _PathPPM = Environment.CurrentDirectory + "\PPM_File" '
    Dim _StartFileOK As Boolean = False
    Dim TotalExecutedProc As Integer = 0
    Dim _FileSuccess As Boolean = False
    Dim _FileNm As String = ""
    Dim owrite As System.IO.StreamWriter
    Dim db As New SqlDatabase(CommonAppSet.ConnStr)
    Dim _BankCodeBranchCode As String = "07527000"
    Dim _MandatoryFieldsOK As Boolean = False
    Dim _EndFileOK As Boolean = False
    Dim _formName As String = "ToolsPPMClearing"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)
    Dim ppm_clearing_err_msg As String = ""
    Private Sub enableAll()
        btnGenPPMFile.Enabled = True
        btnGenPPMRetFile.Enabled = True
    End Sub
    Private Sub disableAll()
        btnGenPPMFile.Enabled = False
        btnGenPPMRetFile.Enabled = False
    End Sub

    Private Sub btnGenPPMFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenPPMFile.Click
        ppm_clearing_err_msg = ""
        disableAll()
        tspPPM.Style = ProgressBarStyle.Marquee
        rowCount = 0
        _PathPPM = _PathPPM + "\Clearing"
        bgWorkerPPM_File.RunWorkerAsync()
    End Sub
    Private Sub StartFile()
        _StartFileOK = False
        TotalExecutedProc = 0
        _FileSuccess = False
        _FileNm = "PPM" & CommonAppSet.AppId & Format(Date.Now, "yymmddhhmmssms") & ".dep" '
        Try
            If Not Directory.Exists(_PathPPM) Then
                Directory.CreateDirectory(_PathPPM)
            End If
            owrite = New System.IO.StreamWriter(_PathPPM + "\" + _FileNm, False)
            owrite.WriteLine("HDR" + Format(Date.Now, "ddMMyyyy") + _FileNm.PadRight(30) + _BankCodeBranchCode.PadRight(30))
            _StartFileOK = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExecProcAndWrite(ByVal storedProc As String)

        _MandatoryFieldsOK = False

        Dim exptext As String = ""

        Dim UCN As String = ""

        Try
            Dim commProc As DbCommand
            If (storedProc = "CMS_Process_GenPPMClearing") Then
                commProc = db.GetStoredProcCommand(storedProc) '
            Else
                commProc = db.GetSqlStringCommand(storedProc)
            End If
            commProc.CommandTimeout = 0
            db.AddInParameter(commProc, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
            Dim dt2 As DataTable = db.ExecuteDataSet(commProc).Tables(0) '

            Dim mandatoryFields As Integer() = New Integer() {0, 3, 4, 5, 6, 7, 9, 14, 15, 19, 31}
            If (dt2.Rows.Count > 0) Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    For j As Integer = 0 To 31
                        If Not Array.IndexOf(mandatoryFields, j) = -1 Then
                            If (String.IsNullOrEmpty(dt2.Rows(i)(j).ToString())) Then
                                'MessageBox.Show("Mandatory field(s) cannot be empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                _MandatoryFieldsOK = False
                                'Exit Sub
                            End If
                        End If
                    Next
                Next
            Else
                _MandatoryFieldsOK = False
                'Exit Sub
            End If
            _MandatoryFieldsOK = True

            rowCount = rowCount + dt2.Rows.Count

            Dim length As Integer() = New Integer() {1, 1, 8, 20, 10, 20, 8, 8, 30, 8, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 150, 30, 1, 1, 8, 8, 14, 20, 30, 30, 10, 8, 30, 120, 20, 35, 50, 15, 15, 140, 140, 140, 3, 20, 1, 1, 20, 20, 20, 20, 32, 1, 30, 20}
            For row As Integer = 0 To dt2.Rows.Count - 1
                For col As Integer = 0 To 55
                    If (col = 6 Or col = 7 Or col = 9) Then
                        exptext = exptext + Format(dt2.Rows(row)(col), "ddMMyyyy").Trim().Replace(vbNewLine, "").PadRight(length(col))

                    ElseIf (col = 28) Then

                        Dim commProc_UCN As DbCommand = db.GetStoredProcCommand("CMS_GetLastUCN_Clearing")
                        Dim dt_UCN As DataTable = db.ExecuteDataSet(commProc_UCN).Tables(0)
                        If (dt_UCN.Rows.Count > 0 And Not (String.IsNullOrEmpty(dt_UCN.Rows(0)("Last_UCN_No_Clearing").ToString()))) Then
                            If (dt_UCN.Rows(0)("Last_UCN_No_Clearing").ToString().Substring(0, 6) = Format(Date.Today, "yyMMdd")) Then
                                Dim Last_UCN_N As Integer = Convert.ToInt32(dt_UCN.Rows(0)("Last_UCN_No_Clearing").ToString().Substring(6, 8))
                                UCN = Format(Date.Today, "yyMMdd") + Convert.ToString(Last_UCN_N + 1).PadLeft(8, "0")
                            Else
                                UCN = Format(Date.Today, "yyMMdd") + "10000001"
                            End If
                        Else
                            UCN = Format(Date.Today, "yyMMdd") + "10000001"
                        End If

                        Dim commProc_up_UCN As DbCommand = db.GetStoredProcCommand("CMS_Process_Update_Last_UCN_Clearing")
                        db.AddInParameter(commProc_up_UCN, "@Last_UCN_No_Clearing", DbType.String, UCN)
                        db.ExecuteNonQuery(commProc_up_UCN)

                        UCN = UCN.Trim().Replace(vbNewLine, "").PadRight(length(col))
                        exptext = exptext + UCN


                        If ((storedProc = "CMS_Process_GenPPMClearing" Or storedProc.Contains("ClearingTab")) And chkAllPPM.Checked = False) Then
                            'Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoClearingTab")
                            Dim commProc4 As DbCommand = db.GetSqlStringCommand("UPDATE CLEARINGTAB" _
 + " set UNIQUE_COLLECTION_NO=@UNIQUE_COLLECTION_NO where MID=@MID and DSL=@DSL")
                            'Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@MID", DbType.Int32, dt2.Rows(row)("MID"))
                            db.AddInParameter(commProc4, "@DSL", DbType.Int32, dt2.Rows(row)("DSL"))
                            'db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
                            db.ExecuteNonQuery(commProc4)

                        End If


                    Else
                        exptext = exptext + dt2.Rows(row)(col).ToString().Trim().Replace(vbNewLine, "").PadRight(length(col))
                        'exptext = exptext.Replace(vbNewLine, "")
                    End If
                Next
                owrite.WriteLine(exptext)
                exptext = ""
            Next
            TotalExecutedProc = TotalExecutedProc + 1

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ppm_clearing_err_msg = ppm_clearing_err_msg + ex.Message
            If Not (owrite Is Nothing) Then
                'owrite.Close()
            End If

        End Try
    End Sub
    Private Sub ExecProc(ByVal storedProc As String)
        Dim commProc As DbCommand = db.GetStoredProcCommand(storedProc)
        commProc.CommandTimeout = 0
        db.AddInParameter(commProc, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
        db.ExecuteDataSet(commProc)
    End Sub
    Private Sub EndFile()
        _EndFileOK = False
        If (_FileSuccess = True) Then
            Try
                owrite.WriteLine("TRL" + Format(Date.Now, "ddMMyyyy") + (rowCount + 2).ToString().PadRight(8))
                owrite.Close()
                _EndFileOK = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub bgWorkerPPM_Return_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerPPM_Return.DoWork
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                Dim exptext As String = ""

                Try
                    Dim commProc As DbCommand
                    If (chkAllReturn.Checked = False) Then
                        'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Process_GenPPMReturnClearing") '
                        commProc = db.GetSqlStringCommand("select distinct '', '', '', '', " _
                        + "'', '', '', 'R', '', '', '', CLEARINGTAB.UNIQUE_COLLECTION_NO, RETURN_CLEARING.RTN_CODE, ''" _
                        + " from RETURN_CLEARING, CLEARINGTAB" _
     + " where RETURN_CLEARING.MID = CLEARINGTAB.MID and RETURN_CLEARING.DSL = CLEARINGTAB.DSL AND convert(date,CLEARINGTAB.OPR_DATE)=CONVERT(date,@FileGenDate) and RETURN_CLEARING.PPM_GenDate is null and CLEARINGTAB.RTN_STATUS='R' and clearingtab.UNIQUE_COLLECTION_NO is not null and RETURN_CLEARING.STATUS='L' and clearingtab.Status='L'") '
                    ElseIf (chkAllReturn.Checked = True) Then
                        commProc = db.GetSqlStringCommand("select distinct '', '', '', '', " _
                        + "'', '', '', 'R', '', '', '', CLEARINGTAB.UNIQUE_COLLECTION_NO, RETURN_CLEARING.RTN_CODE, ''" _
                        + " from RETURN_CLEARING, CLEARINGTAB" _
     + " where RETURN_CLEARING.MID = CLEARINGTAB.MID and RETURN_CLEARING.DSL = CLEARINGTAB.DSL AND convert(date,CLEARINGTAB.OPR_DATE)=CONVERT(date,@FileGenDate) and CLEARINGTAB.RTN_STATUS='R' and clearingtab.UNIQUE_COLLECTION_NO is not null and RETURN_CLEARING.STATUS='L' and clearingtab.Status='L'") '
                    End If
                    db.AddInParameter(commProc, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
                    Dim dt2 As DataTable = db.ExecuteDataSet(commProc).Tables(0) '

                    'If dt2.Rows.Count = 0 Then '

                    '    MessageBox.Show("No record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub

                    'End If

                    rowCount = rowCount + dt2.Rows.Count

                    Dim length As Integer() = New Integer() {9, 7, 12, 6, 13, 12, 1, 1, 4, 1, 22, 14, 30, 32}
                    For row As Integer = 0 To dt2.Rows.Count - 1
                        For col As Integer = 0 To 13
                            exptext = exptext + dt2.Rows(row)(col).ToString().Trim().Replace(vbNewLine, "").PadRight(length(col))
                            'exptext = exptext.Replace(vbNewLine, "")
                        Next
                        owrite.WriteLine(exptext)
                        exptext = ""
                        If (chkAllReturn.Checked = False) Then
                            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Update_PPM_GenDate_ReturnClearing") '
                            'Dim commProc2 As DbCommand = db.GetSqlStringCommand("update RETURN_CLEARING set PPM_GenDate=GETDATE()  from RETURN_CLEARING,CLEARINGTAB" _
                            '+ " where RETURN_CLEARING.MID = CLEARINGTAB.MID and RETURN_CLEARING.DSL = CLEARINGTAB.DSL AND convert(date,CLEARINGTAB.OPR_DATE)=CONVERT(date,@FileGenDate) and RETURN_CLEARING.PPM_GenDate is null") '
                            db.AddInParameter(commProc2, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
                            db.ExecuteDataSet(commProc2)
                        End If
                    Next
                    TotalExecutedProc = TotalExecutedProc + 1

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    If Not (owrite Is Nothing) Then
                        'owrite.Close()
                    End If

                End Try
                _FileSuccess = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                If Not (owrite Is Nothing) Then
                    owrite.Close()
                    Exit Sub
                End If

            End Try
            EndFile()
        End If

       
    End Sub
    Private Sub ShowCompleted()
        tspPPM.Style = ProgressBarStyle.Continuous

        enableAll()

        If Not Directory.Exists(_PathPPM) Then
            Directory.CreateDirectory(_PathPPM)
        End If

        If _FileSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "PPM Feed ready!!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathPPM & "\" & _FileNm)
        Else
            'If _MandatoryFieldsOK = False Then
            '    MessageBox.Show("! Process Failed ! Mandatory Fields cannot be empty !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Else
            MessageBox.Show("! Process Failed !" + ppm_clearing_err_msg, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        End If
        rowCount = 0
        _PathPPM = Environment.CurrentDirectory + "\PPM_File"
    End Sub

    Private Sub bgWorkerPPM_Return_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerPPM_Return.RunWorkerCompleted
        ShowCompleted()
    End Sub

    Private Sub FrmPPM_Clearing_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (bgWorkerPPM_File.IsBusy = True Or bgWorkerPPM_Return.IsBusy = True) Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnGenPPMRetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenPPMRetFile.Click
        ppm_clearing_err_msg = ""
        disableAll()
        tspPPM.Style = ProgressBarStyle.Marquee
        rowCount = 0
        _PathPPM = _PathPPM + "\Clearing\Return"
        bgWorkerPPM_Return.RunWorkerAsync()
    End Sub

    Private Sub bgWorkerPPM_File_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerPPM_File.DoWork
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                If (chkAllPPM.Checked = False) Then
                    'ExecProcAndWrite("CMS_Process_GenPPMClearing")
                    ExecProcAndWrite("	Select t.* from (SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, CLEARINGTAB.CHECK_NUMBER Instrument_No,'CHK' Instrument_Type,CLEARINGTAB.DEBIT_CREDIT," _
   + " CONVERT(date,CLEARINGTAB.ISSUE_DATE) Instrument_Date," _
   + " CONVERT(date,CLEARINGTAB.ISSUE_DATE) Deposit_Date," _
                    + " '' Customer_Code," _
   + " CONVERT(date,CLEARINGTAB.ISSUE_DATE) Pickup_Date," _
   + " CITIBANK_BRANCH.Short_Name Deposit_Channel_Pickup_Location_Code," _
                    + " '' Deposit_Channel_Point_Pickup_Point_Code," _
                    + " 'BDT' Currency_Code," _
   + " case CLEARINGTAB.VALUE_TYPE" _
   + " when 1 then 'RV'" _
                + " Else 'HV' end Clearing_Type_Code," _
   + " SUBSTRING(CAST(ClearingTab.ROUTING_NO AS VARCHAR(9)), 1, 3) Drawee_Bank_Code," _
   + " SUBSTRING(CAST(ClearingTab.ROUTING_NO AS VARCHAR(9)), 1, 8) Drawee_Bank_Branch_Code," _
                    + " '' Clearing_Location_Code,'' Pref_Bank_Code,'' Product_Code," _
   + " case CLEARING_CLIENT.Direct_Debit_Customer" _
   + " when 0 then SUBSTRING(CAST(CLEARING_CLIENT.ACC_NO AS VARCHAR(50)), 1, 15)" _
   + " else SUBSTRING(CAST(CLEARING_CLIENT.ACC_NO AS VARCHAR(50)), 6, 10) end Credit_Acc_No," _
                    + " '' Debit_Acc_No,'' Drawer_Code,'' Drawer_Name,'' Drawer_Acc_No,'' Discounting_Flag,'' Discounting_Till,'' Discounting_Start_Date,'' Discounting_End_Date," _
   + " getdate() collection_Number,CheckTotal.Customer_Ref Dealer_Code,CLEARINGTAB.CHECK_REF," _
   + " CLEARINGTAB.DS_CODE," _
                    + " '' c33,'' c34,'' c35,'' c36,'' c37,'' c38,'' c39,'' c40,'' c41, CLEARINGTAB.AddCheckText, '' c43,'' c44,'' c45,'' c46,'' c47,'' c48,'' c49,'' c50,'' c51,'' c52,'' c53,'' c54,'' c55,'' c56,CLEARINGTAB.MID,CLEARINGTAB.DSL," _
   + " row_number() over (partition by CLEARINGTAB.CHECK_NUMBER order by CLEARINGTAB.CHECK_NUMBER) as RowNumber	" _
                    + " from CLEARINGTAB, CLEARING_CLIENT, CHECKTOTAL, CITIBANK_BRANCH" _
                    + " where" _
   + " CLEARINGTAB.FLEX_FILENAME is not NULL" _
    + " and CLEARING_CLIENT.ACC_NO=CLEARINGTAB.REMARK and CheckTotal.DS_CODE = CLEARINGTAB.DS_CODE" _
    + " and CLEARINGTAB.PPM_GenDate is null	" _
     + " and CITIBANK_BRANCH.BRANCH_CODE = CHECKTOTAL.ENTRY_LOC" _
     + " and CLEARINGTAB.STATUS='L'" _
    + " and convert(date,CLEARINGTAB.OPR_DATE)=convert(date, @FileGenDate)" _
    + ")" _
      + " AS t" _
    + " where t.RowNumber = 1; ")
                ElseIf (chkAllPPM.Checked = True) Then
                    ExecProcAndWrite("	Select t.* from (SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, CLEARINGTAB.CHECK_NUMBER Instrument_No,'CHK' Instrument_Type,CLEARINGTAB.DEBIT_CREDIT," _
   + " CONVERT(date,CLEARINGTAB.ISSUE_DATE) Instrument_Date," _
   + " CONVERT(date,CLEARINGTAB.ISSUE_DATE) Deposit_Date," _
                    + " '' Customer_Code," _
   + " CONVERT(date,CLEARINGTAB.ISSUE_DATE) Pickup_Date," _
   + " CITIBANK_BRANCH.Short_Name Deposit_Channel_Pickup_Location_Code," _
                    + " '' Deposit_Channel_Point_Pickup_Point_Code," _
                    + " 'BDT' Currency_Code," _
   + " case CLEARINGTAB.VALUE_TYPE" _
   + " when 1 then 'RV'" _
                + " Else 'HV' end Clearing_Type_Code," _
   + " SUBSTRING(CAST(ClearingTab.ROUTING_NO AS VARCHAR(9)), 1, 3) Drawee_Bank_Code," _
   + " SUBSTRING(CAST(ClearingTab.ROUTING_NO AS VARCHAR(9)), 1, 8) Drawee_Bank_Branch_Code," _
                    + " '' Clearing_Location_Code,'' Pref_Bank_Code,'' Product_Code," _
   + " case CLEARING_CLIENT.Direct_Debit_Customer" _
   + " when 0 then SUBSTRING(CAST(CLEARING_CLIENT.ACC_NO AS VARCHAR(50)), 1, 15)" _
   + " else SUBSTRING(CAST(CLEARING_CLIENT.ACC_NO AS VARCHAR(50)), 6, 10) end Credit_Acc_No," _
                    + " '' Debit_Acc_No,'' Drawer_Code,'' Drawer_Name,'' Drawer_Acc_No,'' Discounting_Flag,'' Discounting_Till,'' Discounting_Start_Date,'' Discounting_End_Date," _
   + " getdate() collection_Number,CheckTotal.Customer_Ref Dealer_Code,CLEARINGTAB.CHECK_REF," _
   + " CLEARINGTAB.DS_CODE," _
                    + " '' c33,'' c34,'' c35,'' c36,'' c37,'' c38,'' c39,'' c40,'' c41, CLEARINGTAB.AddCheckText, '' c43,'' c44,'' c45,'' c46,'' c47,'' c48,'' c49,'' c50,'' c51,'' c52,'' c53,'' c54,'' c55,'' c56,CLEARINGTAB.MID,CLEARINGTAB.DSL," _
   + " row_number() over (partition by CLEARINGTAB.CHECK_NUMBER order by CLEARINGTAB.CHECK_NUMBER) as RowNumber	" _
                    + " from CLEARINGTAB, CLEARING_CLIENT, CHECKTOTAL, CITIBANK_BRANCH" _
                    + " where" _
   + " CLEARINGTAB.FLEX_FILENAME is not NULL" _
    + " and CLEARING_CLIENT.ACC_NO=CLEARINGTAB.REMARK and CheckTotal.DS_CODE = CLEARINGTAB.DS_CODE" _
     + " and CITIBANK_BRANCH.BRANCH_CODE = CHECKTOTAL.ENTRY_LOC" _
      + " and CLEARINGTAB.STATUS='L'" _
    + " and convert(date,CLEARINGTAB.OPR_DATE)=convert(date, @FileGenDate)" _
    + ")" _
      + " AS t" _
    + " where t.RowNumber = 1; ")
                End If
                If (TotalExecutedProc = 1 And chkAllPPM.Checked = False) Then
                    ExecProc("CMS_Process_UpdatePPMGenDateClearing")
                    _FileSuccess = True
                ElseIf (TotalExecutedProc = 1 And chkAllPPM.Checked = True) Then
                    _FileSuccess = True
                End If

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ppm_clearing_err_msg = ppm_clearing_err_msg + ex.Message
                If Not (owrite Is Nothing) Then
                    owrite.Close()
                    Exit Sub
                End If

            End Try
            EndFile()
        End If
    End Sub

    Private Sub bgWorkerPPM_File_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerPPM_File.RunWorkerCompleted
        ShowCompleted()
    End Sub

    Private Sub btnServiceControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServiceControl.Click
        Dim frmPPMServiceClearing As New FrmPPMServiceClearing()
        frmPPMServiceClearing.ShowDialog()
    End Sub

    Private Sub FrmPPM_Clearing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If
    End Sub
End Class