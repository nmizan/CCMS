Imports System.IO
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmPPM_Collection
    Dim rowCount As Integer = 0
    Dim _PathPPM = Environment.CurrentDirectory + "\PPM_File" '  
    Dim _StartFileOK As Boolean = False
    Dim TotalExecutedProc As Integer = 0
    Dim _FileSuccess As Boolean = False
    Dim _FileNm As String = ""
    Dim owrite As System.IO.StreamWriter
    Dim _MandatoryFieldsOK As Boolean = False
    Dim db As New SqlDatabase(CommonAppSet.ConnStr)
    Dim _BankCodeBranchCode As String = "07527000"
    Dim _EndFileOK As Boolean = False
    Dim _formName As String = "ToolsPPMCollection"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)

    Private Sub enableAll()
        btnGenPPM_CollectionFile.Enabled = True
        btnGenPPMRetCollectionFile.Enabled = True
    End Sub
    Private Sub disableAll()
        btnGenPPM_CollectionFile.Enabled = False
        btnGenPPMRetCollectionFile.Enabled = False
    End Sub

    Private Sub FrmPPM_Collection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If
    End Sub

    Private Sub btnGenPPM_CollectionFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenPPM_CollectionFile.Click
        disableAll()
        tspPPM.Style = ProgressBarStyle.Marquee
        rowCount = 0
        _PathPPM = _PathPPM + "\Collection"
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

            'Dim commProc As DbCommand = db.GetStoredProcCommand(storedProc) '
            Dim commProc As DbCommand = db.GetSqlStringCommand(storedProc)
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

                        Dim commProc_UCN As DbCommand = db.GetStoredProcCommand("CMS_GetLastUCN")
                        Dim dt_UCN As DataTable = db.ExecuteDataSet(commProc_UCN).Tables(0)
                        If (dt_UCN.Rows.Count > 0 And Not (String.IsNullOrEmpty(dt_UCN.Rows(0)("Last_UCN_No").ToString()))) Then
                            If (dt_UCN.Rows(0)("Last_UCN_No").ToString().Substring(0, 6) = Format(Date.Today, "yyMMdd")) Then
                                Dim Last_UCN_N As Integer = Convert.ToInt32(dt_UCN.Rows(0)("Last_UCN_No").ToString().Substring(6, 8))
                                UCN = Format(Date.Today, "yyMMdd") + Convert.ToString(Last_UCN_N + 1).PadLeft(8, "0")
                            Else
                                UCN = Format(Date.Today, "yyMMdd") + "00000001"
                            End If
                        Else
                            UCN = Format(Date.Today, "yyMMdd") + "00000001"
                        End If

                        Dim commProc_up_UCN As DbCommand = db.GetStoredProcCommand("CMS_Process_Update_Last_UCN")
                        db.AddInParameter(commProc_up_UCN, "@Last_UCN_No", DbType.String, UCN)
                        db.ExecuteNonQuery(commProc_up_UCN)

                        UCN = UCN.Trim().Replace(vbNewLine, "").PadRight(length(col))
                        exptext = exptext + UCN

                        If ((storedProc = "CMS_Process_GenPPMDepositCash" Or storedProc.Contains("CCASH")) And chkAllPPM.Checked = False) Then
                            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoCash")
                            Dim D_CODE As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@D_CODE", DbType.String, D_CODE)
                            db.ExecuteNonQuery(commProc4)


                        ElseIf ((storedProc = "CMS_Process_GenPPMDepositCheck" Or storedProc.Contains("CSD")) And chkAllPPM.Checked = False) Then
                            'Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNo")
                            Dim commProc4 As DbCommand = db.GetSqlStringCommand("UPDATE CSD_DET" _
 + " set UNIQUE_COLLECTION_NO=@UNIQUE_COLLECTION_NO where D_CODE=@D_CODE and SLNO=@SLNO")
                            'Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            'db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
                            db.AddInParameter(commProc4, "@D_CODE", DbType.String, dt2.Rows(row)("D_CODE").ToString())
                            db.AddInParameter(commProc4, "@SLNO", DbType.Int32, dt2.Rows(row)("SLNO"))
                            db.ExecuteNonQuery(commProc4)

                        ElseIf ((storedProc = "CMS_Process_GenPPMDepositCityAny" Or storedProc.Contains("CCHECK")) And chkAllPPM.Checked = False) Then
                            'Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoCitiAny")
                            Dim commProc4 As DbCommand = db.GetSqlStringCommand("UPDATE CCHECK" _
 + " set UNIQUE_COLLECTION_NO=@UNIQUE_COLLECTION_NO where D_CODE=@D_CODE and SLNO=@SLNO")
                            'Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            'db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
                            db.AddInParameter(commProc4, "@D_CODE", DbType.String, dt2.Rows(row)("D_CODE").ToString())
                            db.AddInParameter(commProc4, "@SLNO", DbType.Int32, dt2.Rows(row)("SLNO"))
                            db.ExecuteNonQuery(commProc4)
                        ElseIf (storedProc = "CMS_Process_GenPPMClearing") Then
                            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoClearingTab")
                            Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not (owrite Is Nothing) Then
                'owrite.Close()
            End If

        End Try
    End Sub
    Private Sub ExecProc(ByVal storedProc As String)
        Dim commProc As DbCommand = db.GetStoredProcCommand(storedProc)
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
    Private Sub bgWorkerPPM_File_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerPPM_File.DoWork
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                If (chkAllPPM.Checked = False) Then
                    'ExecProcAndWrite("CMS_Process_GenPPMDepositCash")
                    ExecProcAndWrite("SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, DSCHEDULE.D_CODE Instrument_No,'CASH' Instrument_Type,DSCHEDULE.CITICASH_AMOUNT," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Instrument_Date," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Deposit_Date," _
                    + "'' Customer_Code," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Pickup_Date," _
                    + "'CPCS' Deposit_Channel_Pickup_Location_Code," _
                    + "'' Deposit_Channel_Point_Pickup_Point_Code," _
                    + "'BDT' Currency_Code,'CTC' Clearing_Type_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 3) Drawee_Bank_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 8) Drawee_Bank_Branch_Code," _
                    + "'' Clearing_Location_Code,'',''," _
       + "case Client.Direct_Debit_Customer" _
       + " when 0 then SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 2, 15)" _
       + " else SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 7, 10) end," _
                    + "'',CCASH.CUSTOMER_REF,CCASH.CUSTOMER_REF,'','','','',''," _
       + "getdate() collection_Number,CCASH.CUSTOMER_REF,CCASH.CUSTOMER_REF," _
       + "DSCHEDULE.D_CODE," _
                    + "'','','','','','','','','',CCASH.ADD_TEXT,'','','',CCASH.CUSTOMER_REF,'','','','','','','','','',''" _
                    + " from DSCHEDULE, CCASH, BANK, BRANCH, Client" _
       + " where DSCHEDULE.D_CODE=CCASH.D_CODE and" _
                    + " DSCHEDULE.CORR_BANK_CODE = BANK.BANK_CODE And DSCHEDULE.CORR_BRANCH_CODE = BRANCH.BRANCH_CODE" _
       + " and BRANCH.BANK_CODE=DSCHEDULE.CORR_BANK_CODE and DSCHEDULE.FLEXGEN_DATE is not NULL" _
        + " and DSCHEDULE.CLIENT_CODE=CLIENT.CLIENT_CODE and DSCHEDULE.PPM_GenDate is null" _
        + " and convert(date,CCASH.INPUT_DATETIME) = convert(date, @FileGenDate)" _
        + " and CCASH.STATUS='L'" _
        + " and DSCHEDULE.STATUS='L'" _
        + " and DSCHEDULE.LOCATION_CODE=BRANCH.LOCATION_CODE")

                    If (_MandatoryFieldsOK = True) Then
                        'ExecProcAndWrite("CMS_Process_GenPPMDepositCheck")
                        ExecProcAndWrite(" SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, CSD_DET.CHECK_NO Instrument_No," _
                        + "'CHK' Instrument_Type,CSD_DET.AMOUNT," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Instrument_Date," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Deposit_Date," _
                        + "'' Customer_Code," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Pickup_Date," _
                        + "'CPCS' Deposit_Channel_Pickup_Location_Code," _
                        + "'' Deposit_Channel_Point_Pickup_Point_Code," _
                        + "'BDT' Currency_Code,'CTS' Clearing_Type_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 3) Drawee_Bank_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 8) Drawee_Bank_Branch_Code," _
                        + "'' Clearing_Location_Code,'',''," _
       + "case Client.Direct_Debit_Customer" _
       + " when 0 then SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 2, 15)" _
       + " else SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 7, 10) end," _
                        + "'','','','','','','',''," _
       + "getdate() collection_Number,CSD_DET.CUSTOMER_REF,CSD_DET.CHECK_REF," _
       + "DSCHEDULE.D_CODE," _
                        + "'','','','','','','','','',CSD_DET.AddCheckText,'','','',CSD_DET.CUSTOMER_REF,'','','','','','','','','','',CSD_DET.SLNO" _
                        + " from DSCHEDULE, BANK, BRANCH, CSD, CSD_DET, Client" _
       + " where DSCHEDULE.D_CODE=CSD.D_CODE and" _
                        + " DSCHEDULE.CORR_BANK_CODE = BANK.BANK_CODE And DSCHEDULE.CORR_BRANCH_CODE = BRANCH.BRANCH_CODE" _
        + " and BRANCH.BANK_CODE=DSCHEDULE.CORR_BANK_CODE and CSD.D_CODE=CSD_DET.D_CODE" _
         + " and DSCHEDULE.FLEXGEN_DATE is not NULL and DSCHEDULE.CLIENT_CODE=client.CLIENT_CODE" _
           + " and DSCHEDULE.PPM_GenDate is null" _
         + " and convert(date,CSD.INPUT_DATETIME) = convert(date, @FileGenDate)" _
           + " and DSCHEDULE.STATUS='L'" _
             + " and CSD.STATUS='L'" _
               + " and CSD_DET.STATUS='L'" _
         + " and DSCHEDULE.LOCATION_CODE=BRANCH.LOCATION_CODE")
                    End If
                    If (_MandatoryFieldsOK = True) Then
                        'ExecProcAndWrite("CMS_Process_GenPPMDepositCityAny")
                        ExecProcAndWrite("SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, CCHECK.CHECK_NO Instrument_No,'CHK' Instrument_Type,CCHECK.AMOUNT," _
       + "CONVERT(date,CCHECK.SLIP_DATE) Instrument_Date," _
       + "CONVERT(date,CCHECK.SLIP_DATE) Deposit_Date," _
                        + "'' Customer_Code," _
       + "CONVERT(date,CCHECK.SLIP_DATE) Pickup_Date," _
                        + "'CPCS' Deposit_Channel_Pickup_Location_Code," _
                        + "'' Deposit_Channel_Point_Pickup_Point_Code," _
                        + "'BDT' Currency_Code,'CTA' Clearing_Type_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 3) Drawee_Bank_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 8) Drawee_Bank_Branch_Code," _
                        + "'' Clearing_Location_Code,'',''," _
       + "case Client.Direct_Debit_Customer" _
       + " when 0 then SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 2, 15)" _
       + " else SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 7, 10) end," _
                        + "'','','','','','','',''," _
       + "getdate() collection_Number,CCHECK.Customer_Ref,CCHECK.CHECK_REF," _
       + "CCHECK.D_CODE," _
                        + "'','','','','','','','','','','','','',CCHECK.Customer_Ref,'','','','','','','','','','',CCHECK.SLNO" _
                        + " from BANK, BRANCH, CCHECK, CLIENT, CCHECKTOTAL" _
       + " where CCHECK.DRAWEE_BANK_CODE=BANK.BANK_CODE and" _
        + " CCHECK.BRANCH_CODE=BRANCH.BRANCH_CODE and" _
        + " CCHECK.D_CODE=CCHECKTOTAL.D_CODE and" _
        + " BRANCH.BANK_CODE=CCHECK.DRAWEE_BANK_CODE and CCHECK.REMINDER_NO='1' AND convert(date,CCHECK.REMINDER_DATE)= convert(date, @FileGenDate)" _
        + " and CCHECK.CLIENT_CODE=Client.CLIENT_CODE and CCHECK.PPM_GenDate is null" _
         + " and CCHECK.STATUS='L'" _
               + " and CCHECKTOTAL.STATUS='L'" _
         + " and CCHECK.LOCATION_CODE=BRANCH.LOCATION_CODE")
                    End If

                ElseIf (chkAllPPM.Checked = True) Then
                    'ExecProcAndWrite("CMS_Process_GenPPMDepositCash")
                    ExecProcAndWrite("SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, DSCHEDULE.D_CODE Instrument_No,'CASH' Instrument_Type,DSCHEDULE.CITICASH_AMOUNT," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Instrument_Date," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Deposit_Date," _
                    + "'' Customer_Code," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Pickup_Date," _
                    + "'CPCS' Deposit_Channel_Pickup_Location_Code," _
                    + "'' Deposit_Channel_Point_Pickup_Point_Code," _
                    + "'BDT' Currency_Code,'CTC' Clearing_Type_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 3) Drawee_Bank_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 8) Drawee_Bank_Branch_Code," _
                    + "'' Clearing_Location_Code,'',''," _
       + "case Client.Direct_Debit_Customer" _
       + " when 0 then SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 2, 15)" _
       + " else SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 7, 10) end," _
                    + "'',CCASH.CUSTOMER_REF,CCASH.CUSTOMER_REF,'','','','',''," _
       + "getdate() collection_Number,CCASH.CUSTOMER_REF,CCASH.CUSTOMER_REF," _
       + "DSCHEDULE.D_CODE," _
                    + "'','','','','','','','','',CCASH.ADD_TEXT,'','','',CCASH.CUSTOMER_REF,'','','','','','','','','',''" _
                    + " from DSCHEDULE, CCASH, BANK, BRANCH, Client" _
       + " where DSCHEDULE.D_CODE=CCASH.D_CODE and" _
                    + " DSCHEDULE.CORR_BANK_CODE = BANK.BANK_CODE And DSCHEDULE.CORR_BRANCH_CODE = BRANCH.BRANCH_CODE" _
       + " and BRANCH.BANK_CODE=DSCHEDULE.CORR_BANK_CODE and DSCHEDULE.FLEXGEN_DATE is not NULL" _
        + " and DSCHEDULE.CLIENT_CODE=CLIENT.CLIENT_CODE" _
        + " and convert(date,CCASH.INPUT_DATETIME) = convert(date, @FileGenDate)" _
        + " and CCASH.STATUS='L'" _
        + " and DSCHEDULE.STATUS='L'" _
        + " and DSCHEDULE.LOCATION_CODE=BRANCH.LOCATION_CODE")

                    If (_MandatoryFieldsOK = True) Then
                        'ExecProcAndWrite("CMS_Process_GenPPMDepositCheck")
                        ExecProcAndWrite(" SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, CSD_DET.CHECK_NO Instrument_No," _
                        + "'CHK' Instrument_Type,CSD_DET.AMOUNT," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Instrument_Date," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Deposit_Date," _
                        + "'' Customer_Code," _
       + "CONVERT(date,DSCHEDULE.SCHEDULE_DATE) Pickup_Date," _
                        + "'CPCS' Deposit_Channel_Pickup_Location_Code," _
                        + "'' Deposit_Channel_Point_Pickup_Point_Code," _
                        + "'BDT' Currency_Code,'CTS' Clearing_Type_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 3) Drawee_Bank_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 8) Drawee_Bank_Branch_Code," _
                        + "'' Clearing_Location_Code,'',''," _
       + "case Client.Direct_Debit_Customer" _
       + " when 0 then SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 2, 15)" _
       + " else SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 7, 10) end," _
                        + "'','','','','','','',''," _
       + "getdate() collection_Number,CSD_DET.CUSTOMER_REF,CSD_DET.CHECK_REF," _
       + "DSCHEDULE.D_CODE," _
                        + "'','','','','','','','','',CSD_DET.AddCheckText,'','','',CSD_DET.CUSTOMER_REF,'','','','','','','','','','',CSD_DET.SLNO" _
                        + " from DSCHEDULE, BANK, BRANCH, CSD, CSD_DET, Client" _
       + " where DSCHEDULE.D_CODE=CSD.D_CODE and" _
                        + " DSCHEDULE.CORR_BANK_CODE = BANK.BANK_CODE And DSCHEDULE.CORR_BRANCH_CODE = BRANCH.BRANCH_CODE" _
        + " and BRANCH.BANK_CODE=DSCHEDULE.CORR_BANK_CODE and CSD.D_CODE=CSD_DET.D_CODE" _
         + " and DSCHEDULE.FLEXGEN_DATE is not NULL and DSCHEDULE.CLIENT_CODE=client.CLIENT_CODE" _
         + " and convert(date,CSD.INPUT_DATETIME) = convert(date, @FileGenDate)" _
          + " and DSCHEDULE.STATUS='L'" _
             + " and CSD.STATUS='L'" _
               + " and CSD_DET.STATUS='L'" _
         + " and DSCHEDULE.LOCATION_CODE=BRANCH.LOCATION_CODE")
                    End If
                    If (_MandatoryFieldsOK = True) Then
                        'ExecProcAndWrite("CMS_Process_GenPPMDepositCityAny")
                        ExecProcAndWrite("SELECT  distinct '1' Record_Type, '' Indicator, '' Serial_No, CCHECK.CHECK_NO Instrument_No,'CHK' Instrument_Type,CCHECK.AMOUNT," _
       + "CONVERT(date,CCHECK.SLIP_DATE) Instrument_Date," _
       + "CONVERT(date,CCHECK.SLIP_DATE) Deposit_Date," _
                        + "'' Customer_Code," _
       + "CONVERT(date,CCHECK.SLIP_DATE) Pickup_Date," _
                        + "'CPCS' Deposit_Channel_Pickup_Location_Code," _
                        + "'' Deposit_Channel_Point_Pickup_Point_Code," _
                        + "'BDT' Currency_Code,'CTA' Clearing_Type_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 3) Drawee_Bank_Code," _
       + "SUBSTRING(CAST(BRANCH.ROUTING_NO AS VARCHAR(50)), 1, 8) Drawee_Bank_Branch_Code," _
                        + "'' Clearing_Location_Code,'',''," _
       + "case Client.Direct_Debit_Customer" _
       + " when 0 then SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 2, 15)" _
       + " else SUBSTRING(CAST(Client.ACC_NO AS VARCHAR(50)), 7, 10) end," _
                        + "'','','','','','','',''," _
       + "getdate() collection_Number,CCHECK.Customer_Ref,CCHECK.CHECK_REF," _
       + "CCHECK.D_CODE," _
                        + "'','','','','','','','','','','','','',CCHECK.Customer_Ref,'','','','','','','','','','',CCHECK.SLNO" _
                        + " from BANK, BRANCH, CCHECK, CLIENT, CCHECKTOTAL" _
       + " where CCHECK.DRAWEE_BANK_CODE=BANK.BANK_CODE and" _
        + " CCHECK.BRANCH_CODE=BRANCH.BRANCH_CODE and" _
        + " CCHECK.D_CODE=CCHECKTOTAL.D_CODE and" _
        + " BRANCH.BANK_CODE=CCHECK.DRAWEE_BANK_CODE and CCHECK.REMINDER_NO='1' AND convert(date,CCHECK.REMINDER_DATE)= convert(date, @FileGenDate)" _
        + " and CCHECK.CLIENT_CODE=Client.CLIENT_CODE" _
          + " and CCHECK.STATUS='L'" _
               + " and CCHECKTOTAL.STATUS='L'" _
         + " and CCHECK.LOCATION_CODE=BRANCH.LOCATION_CODE")
                    End If
                End If
                'ExecProcAndWrite("CMS_Process_GenPPMClearing")

                If (TotalExecutedProc = 3 And chkAllPPM.Checked = False) Then
                    ExecProc("CMS_Process_UpdatePPMGenDateDepositCash")
                    ExecProc("CMS_Process_UpdatePPMGenDateDepositCheck")
                    ExecProc("CMS_Process_UpdatePPMGenDateDepositCityAny")
                    '                 Dim commProc As DbCommand = db.GetSqlStringCommand("update CCHECK set PPM_GenDate=getdate()" _
                    '                 + " from BANK, BRANCH, CCHECK, CLIENT,CCHECKTOTAL" _
                    '+ " where CCHECK.DRAWEE_BANK_CODE=BANK.BANK_CODE and" _
                    '     + " CCHECK.BRANCH_CODE=BRANCH.BRANCH_CODE and" _
                    '     + " CCHECK.D_CODE=CCHECKTOTAL.D_CODE and" _
                    '     + " BRANCH.BANK_CODE=CCHECK.DRAWEE_BANK_CODE and CCHECK.REMINDER_NO='1' AND convert(date,CCHECK.REMINDER_DATE)= convert(date, @FileGenDate)" _
                    '     + " and CCHECK.CLIENT_CODE=Client.CLIENT_CODE and CCHECK.PPM_GenDate is null" _
                    '      + " and CCHECK.LOCATION_CODE=BRANCH.LOCATION_CODE")
                    '                 db.AddInParameter(commProc, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
                    '                 db.ExecuteDataSet(commProc)
                    _FileSuccess = True
                ElseIf (TotalExecutedProc = 3 And chkAllPPM.Checked = True) Then
                    _FileSuccess = True
                End If

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
            If _MandatoryFieldsOK = False Then
                MessageBox.Show("! Process Failed ! Mandatory Fields cannot be empty !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("! Process Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        rowCount = 0
        _PathPPM = Environment.CurrentDirectory + "\PPM_File"
    End Sub

    Private Sub bgWorkerPPM_File_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerPPM_File.RunWorkerCompleted
        ShowCompleted()
    End Sub

    Private Sub FrmPPM_Collection_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (bgWorkerPPM_File.IsBusy = True Or bgWorkerPPM_Return.IsBusy = True) Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnGenPPMRetCollectionFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenPPMRetCollectionFile.Click
        disableAll()
        tspPPM.Style = ProgressBarStyle.Marquee
        rowCount = 0
        _PathPPM = _PathPPM + "\Collection\Return"
        bgWorkerPPM_Return.RunWorkerAsync()
    End Sub

    Private Sub bgWorkerPPM_Return_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerPPM_Return.DoWork
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                Dim exptext As String = ""
                Dim dt2 As DataTable
                Try

                    'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Process_GenPPMReturnCollection") '
                    Dim commProc As DbCommand
                    If (chkAllReturn.Checked = False) Then
                        commProc = db.GetSqlStringCommand("(select '', '', '', ''," _
                        + "'', '', '', 'R', '', '', '', CSD_DET.UNIQUE_COLLECTION_NO, RETURN_CSD.RTN_CODE, '',RETURN_CSD.D_CODE,RETURN_CSD.SLNO,'' NONZONE_REF" _
                        + " from RETURN_CSD, CSD_DET" _
     + " where RETURN_CSD.D_CODE = CSD_DET.D_CODE AND RETURN_CSD.SLNO=CSD_DET.SLNO AND convert(date,RETURN_CSD.INPUT_DATETIME)=convert(date,@FileGenDate) AND RETURN_CSD.PPM_GenDate is null AND RETURN_CSD.RTN_STATUS='R' AND CSD_DET.UNIQUE_COLLECTION_NO is not null and RETURN_CSD.STATUS='L' and CSD_DET.STATUS='L') " _
                        + " union all" _
      + "(select '', '', '', '', " _
                        + "'', '', '', 'R', '', '', '', CCHECK.UNIQUE_COLLECTION_NO, NCOLLECTION.RTN_CODE, '', '',0000,NCOLLECTION.NONZONE_REF" _
                        + " from NCOLLECTION, CCHECK" _
     + " where NCOLLECTION.NONZONE_REF = CCHECK.NONZONE_REF AND convert(date,NCOLLECTION.INPUT_DATETIME)=convert(date,@FileGenDate) AND NCOLLECTION.PPM_GenDate is null AND NCOLLECTION.RTN_STATUS='R' AND CCHECK.UNIQUE_COLLECTION_NO is not null and NCOLLECTION.STATUS='L' and CCHECK.STATUS='L')")
                    ElseIf (chkAllReturn.Checked = True) Then
                        commProc = db.GetSqlStringCommand("(select '', '', '', ''," _
                        + "'', '', '', 'R', '', '', '', CSD_DET.UNIQUE_COLLECTION_NO, RETURN_CSD.RTN_CODE, '',RETURN_CSD.D_CODE,RETURN_CSD.SLNO,'' NONZONE_REF" _
                        + " from RETURN_CSD, CSD_DET" _
     + " where RETURN_CSD.D_CODE = CSD_DET.D_CODE AND RETURN_CSD.SLNO=CSD_DET.SLNO AND convert(date,RETURN_CSD.INPUT_DATETIME)=convert(date,@FileGenDate) AND RETURN_CSD.RTN_STATUS='R' AND CSD_DET.UNIQUE_COLLECTION_NO is not null and RETURN_CSD.STATUS='L' and CSD_DET.STATUS='L') " _
                        + " union all" _
      + "(select '', '', '', '', " _
                        + "'', '', '', 'R', '', '', '', CCHECK.UNIQUE_COLLECTION_NO, NCOLLECTION.RTN_CODE, '', '',0000,NCOLLECTION.NONZONE_REF" _
                        + " from NCOLLECTION, CCHECK" _
     + " where NCOLLECTION.NONZONE_REF = CCHECK.NONZONE_REF AND convert(date,NCOLLECTION.INPUT_DATETIME)=convert(date,@FileGenDate) AND NCOLLECTION.RTN_STATUS='R' AND CCHECK.UNIQUE_COLLECTION_NO is not null and NCOLLECTION.STATUS='L' and CCHECK.STATUS='L')")
                    End If
                    db.AddInParameter(commProc, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
                    dt2 = db.ExecuteDataSet(commProc).Tables(0) '

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
                            If (dt2.Rows(row)("NONZONE_REF").ToString() = "") Then

                                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Update_PPM_GenDate_ReturnCSD") '
                                db.AddInParameter(commProc2, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
                                db.ExecuteDataSet(commProc2)
                            Else
                                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_Update_PPM_GenDate_NCOLLECTION")
                                db.AddInParameter(commProc3, "@FileGenDate", DbType.DateTime, dtpPPM.Value)
                                db.ExecuteDataSet(commProc3)
                            End If
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

    Private Sub bgWorkerPPM_Return_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorkerPPM_Return.RunWorkerCompleted
        ShowCompleted()
    End Sub

    Private Sub btnServiceControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServiceControl.Click
        Dim frmPPMServiceCollection As New FrmPPMServiceCollection
        frmPPMServiceCollection.ShowDialog()
    End Sub
End Class