Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data.Common
Imports System.IO

Public Class FrmPPMFeedExport
    Dim TotalExecutedProc As Integer = 0
    Dim db As New SqlDatabase(CommonAppSet.ConnStr) '
    Dim owrite As System.IO.StreamWriter
    Dim rowCount As Integer = 0
    Dim _BankCodeBranchCode As String = "07527000"
    Dim _formName As String = "SystemPPMFeedExport"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)
    Dim _FileNm As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _StartFileOK As Boolean = False
    Dim _EndFileOK As Boolean = False
    Dim _MandatoryFieldsOK As Boolean = False
    Dim _PathPPM = Environment.CurrentDirectory + "\PPM_File" '  
    Private Sub disableAll()
        btnReturn.Enabled = False
        btnCollection.Enabled = False
        btnClearing.Enabled = False
    End Sub
    Private Sub enableAll()
        btnReturn.Enabled = True
        btnCollection.Enabled = True
        btnClearing.Enabled = True
    End Sub
    Private Sub btnCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollection.Click
        Dim UD As String = DateTime.Now
        disableAll()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee      
        rowCount = 0
        _PathPPM = _PathPPM + "\Collection"
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub ExecProc(ByVal storedProc As String)
        Dim commProc As DbCommand = db.GetStoredProcCommand(storedProc)
        db.ExecuteDataSet(commProc)
    End Sub
    Private Sub ExecProcAndWrite(ByVal storedProc As String)

        _MandatoryFieldsOK = False

        Dim exptext As String = ""

        Dim UCN As String = ""

        Try

            Dim commProc As DbCommand = db.GetStoredProcCommand(storedProc) '

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
                        exptext = exptext + Format(dt2.Rows(row)(col), "ddMMyyyy").PadRight(length(col))

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

                        UCN = UCN.PadRight(length(col))
                        exptext = exptext + UCN

                        If (storedProc = "CMS_Process_GenPPMDepositCash") Then
                            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoCash")
                            Dim D_CODE As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@D_CODE", DbType.String, D_CODE)
                            db.ExecuteNonQuery(commProc4)


                        ElseIf (storedProc = "CMS_Process_GenPPMDepositCheck") Then
                            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNo")
                            Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
                            db.ExecuteNonQuery(commProc4)

                        ElseIf (storedProc = "CMS_Process_GenPPMDepositCityAny") Then
                            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoCitiAny")
                            Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
                            db.ExecuteNonQuery(commProc4)
                        ElseIf (storedProc = "CMS_Process_GenPPMClearing") Then
                            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_UpdateUniqueCollectionNoClearingTab")
                            Dim Check_No As String = dt2.Rows(row)(3).ToString().PadRight(length(col - 1))
                            db.AddInParameter(commProc4, "@UNIQUE_COLLECTION_NO", DbType.String, UCN)
                            db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, Check_No)
                            db.ExecuteNonQuery(commProc4)

                        End If


                    Else
                        exptext = exptext + dt2.Rows(row)(col).ToString().PadRight(length(col))
                        exptext = exptext.Replace(vbNewLine, "")
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
    Private Sub ShowCompleted()
        ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
      
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

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork       
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                ExecProcAndWrite("CMS_Process_GenPPMDepositCash")
                If (_MandatoryFieldsOK = True) Then
                    ExecProcAndWrite("CMS_Process_GenPPMDepositCheck")              
                End If
                If (_MandatoryFieldsOK = True) Then
                    ExecProcAndWrite("CMS_Process_GenPPMDepositCityAny")
                End If

                'ExecProcAndWrite("CMS_Process_GenPPMClearing")

                If (TotalExecutedProc = 3) Then
                    ExecProc("CMS_Process_UpdatePPMGenDateDepositCash")
                    ExecProc("CMS_Process_UpdatePPMGenDateDepositCheck")
                    ExecProc("CMS_Process_UpdatePPMGenDateDepositCityAny")
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

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'If (_EndFileOK = True) Then
        ShowCompleted()
       
        'End If
    End Sub
    Private Sub FrmPPMFeedExport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (BackgroundWorker1.IsBusy = True Or BackgroundWorker2.IsBusy = True Or BackgroundWorker3.IsBusy = True) Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub

    Private Sub FrmPPMFeedExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        disableAll()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee     
        rowCount = 0
        _PathPPM = _PathPPM + "\Return"
        BackgroundWorker2.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                Dim exptext As String = ""

                Try

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Process_GenPPMReturnClearing") '

                    Dim dt2 As DataTable = db.ExecuteDataSet(commProc).Tables(0) '

                    'If dt2.Rows.Count = 0 Then '

                    '    MessageBox.Show("No record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub

                    'End If

                    rowCount = rowCount + dt2.Rows.Count

                    Dim length As Integer() = New Integer() {9, 7, 12, 6, 13, 9, 1, 1, 4, 1, 22, 14, 30, 32}
                    For row As Integer = 0 To dt2.Rows.Count - 1
                        For col As Integer = 0 To 12
                            exptext = exptext + dt2.Rows(row)(col).ToString().PadRight(length(col))
                        Next
                        exptext = exptext.Replace(vbNewLine, "")
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

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        'If (_EndFileOK = True) Then
        ShowCompleted()
        'End If
    End Sub

    Private Sub btnClearing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearing.Click
        disableAll()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        rowCount = 0
        _PathPPM = _PathPPM + "\Clearing"
        BackgroundWorker3.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        StartFile()
        _FileSuccess = False
        If (_StartFileOK = True) Then
            Try
                ExecProcAndWrite("CMS_Process_GenPPMClearing")

                If (TotalExecutedProc = 1) Then
                    ExecProc("CMS_Process_UpdatePPMGenDateClearing")
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

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        'If (_EndFileOK = True) Then
        ShowCompleted()
        'End If
    End Sub
End Class