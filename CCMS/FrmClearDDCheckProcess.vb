'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : DD Check Process
'Creation date      : 29-Aug-2013
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
Imports System.Xml

Imports Microsoft.Office.Interop


Public Class FrmClearDDCheckProcess



#Region "Global Variables"

    Dim _formName As String = "ClearingDDCheckProcess"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _ProcessSuccess As Boolean = False

    Dim _flagAccount As Boolean = False
    Dim _flagInvalidBranch As Boolean = False
#End Region


#Region "User defined Procedures"



    Private Sub GetClearingDate()
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_GenPrm_GetDetail")

            commProc.Parameters.Clear()

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)


            If dt.Rows.Count > 0 Then
                txtClearingDate.Text = NullHelper.DateToString(dt.Rows(0)("OPR_DATE"))
            Else
                MessageBox.Show("Genprm is corrupted", "Message", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub


    'Private Sub ReadExcel()
    '    Dim xlApp As New Excel.Application


    '    Try


    '        Dim wb As Excel.Workbook = xlApp.Workbooks.Open(opdRetFile.FileName)




    '        Dim sheet As Excel.Worksheet = wb.Sheets(1)

    '        Dim xlRange As Excel.Range = sheet.UsedRange

    '        Dim rowCount As Integer = xlRange.Rows.Count
    '        Dim colCount As Integer = xlRange.Columns.Count


    '        Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    '        'xlRange.Cells(0, 0)
    '        dgView.Rows.Clear()
    '        dgView.AllowUserToAddRows = True

    '        Dim i As Integer
    '        For i = 2 To rowCount

    '            If sheet.Range("A" & i.ToString()).Value2 Is Nothing Then
    '                Exit For
    '            End If

    '            If sheet.Range("A" & i.ToString()).Value2.ToString() = "" Then
    '                Exit For
    '            End If

    '            If (i = dgView.Rows.Count + 1) Then
    '                dgView.Rows.Add()
    '            End If


    '            dgView.Item(0, i - 2).Value = i - 1

    '            dgView.Item(1, i - 2).Value = sheet.Range("B" & i.ToString()).Value2 'nikash code
    '            dgView.Item(2, i - 2).Value = sheet.Range("C" & i.ToString()).Value2 'routing no
    '            dgView.Item(6, i - 2).Value = sheet.Range("A" & i.ToString()).Value2 'account no
    '            dgView.Item(7, i - 2).Value = sheet.Range("F" & i.ToString()).Value2 ' reference
    '            dgView.Item(8, i - 2).Value = sheet.Range("D" & i.ToString()).Value2 'check no
    '            dgView.Item(9, i - 2).Value = sheet.Range("E" & i.ToString()).Value2 'amount


    '            'For j = 1 To colCount




    '            '    '                MessageBox.Show(sheet.Range(colCharset.Substring(j - 1, 1) & i.ToString()).Value2)
    '            '    'MessageBox.Show(xlRange.v)
    '            'Next
    '        Next
    '        dgView.AllowUserToAddRows = False









    '        wb.Close()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try

    '    Try
    '        xlApp.Quit()
    '    Catch ex As Exception

    '    End Try




    'End Sub

    Private Sub CheckValidation()

        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0

        Dim flagRequireField As Boolean = False
        Dim flagAccount As Boolean = False
        Dim flagInvalidBranch As Boolean = False

        Dim tmpAccount As String = ""

        Dim strErrMsg As String = ""

        'Dim MsgStatus As String = ""

        Try



            For Each row As DataGridViewRow In dgView.Rows

                strErrMsg = ""
                flagRequireField = False
                flagAccount = False
                flagInvalidBranch = False

                If Not NullHelper.ObjectToString(row.Cells(0).Value).Trim() = "" Then


                    CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(6).Value)

                    CheckNoTotal = CheckNoTotal + 1

                    If NullHelper.ToDecNum(row.Cells(6).Value) = 0 Then 'Amount
                        flagRequireField = True

                    End If

                    If NullHelper.ObjectToString(row.Cells(5).Value).Trim() = "" Then 'Check no
                        flagRequireField = True
                    End If


                    If NullHelper.ObjectToString(row.Cells(1).Value).Trim() = "" Then 'Nikbranch Code 

                        flagRequireField = True

                    Else

                        If GetBankInfo(NullHelper.ObjectToString(row.Cells(1).Value), row.Index) = False Then
                            flagInvalidBranch = True
                            _flagInvalidBranch = True

                        End If

                    End If

                End If





                If flagRequireField = True Then
                    strErrMsg = strErrMsg & "| Require Field Missing |"
                End If

                If flagInvalidBranch = True Then
                    strErrMsg = strErrMsg & "| Invalid Branch Code |"
                End If

                If flagRequireField = True Or flagInvalidBranch Then
                    row.Cells(8).Value = 1
                    row.Cells(9).Value = strErrMsg
                End If


            Next

            lblTotalCheckAmount.Text = CheckTotal.ToString()
            lblTotalCheckNo.Text = CheckNoTotal.ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function GetAccountName() As Boolean

        Dim flagAccFound As Boolean = False

        Try



            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ACC_NO", DbType.String, NullHelper.ObjectToString(dgView.Item(6, 0).Value).Trim())

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then
                lblAccNo.Text = NullHelper.ObjectToString(dgView.Item(6, 0).Value).Trim()
                lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()
                flagAccFound = True

            Else

                lblAccNo.Text = ""
                lblAccName.Text = ""

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return flagAccFound

    End Function

    Private Function GetBankInfo(ByVal strNikBranch As String, ByVal intRow As Integer)

        Dim flagReturn As Boolean = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            If strNikBranch.Trim() <> "" Then
                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBranch_GetDetailByNikBranch")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, strNikBranch.Trim())

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then
                    'lblBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()

                    dgView.Rows(intRow).Cells(2).Value = dt.Rows(0)("BANK_NAME").ToString()
                    dgView.Rows(intRow).Cells(3).Value = dt.Rows(0)("BRANCH_NAME").ToString()

                    flagReturn = True

                End If



            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return flagReturn


    End Function


    Private Function CheckValidData() As Boolean


        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False
        ElseIf lblAccNo.Text.Trim() = "" Then
            MessageBox.Show("Account required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf txtClearingDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Clearing date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClearingDate.Focus()
            Return False
        ElseIf cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Entry Location Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Return False

        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("Grid empty!! No record found!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If


        Return True

    End Function


    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0
        Dim intMID As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Using conn As DbConnection = db.CreateConnection()

            conn.Open()

            Dim trans As DbTransaction = conn.BeginTransaction()

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim())
            db.AddInParameter(commProc, "@TOTAL_CHKNO", DbType.Int32, NullHelper.ToIntNum(lblTotalCheckNo.Text))
            db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(lblTotalCheckAmount.Text))
            db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text.Trim()))
            db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, "")
            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddOutParameter(commProc, "@RET_MID", DbType.Int32, 10)

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer


            db.ExecuteNonQuery(commProc, trans)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

            If result <> 0 Then
                tStatus = TransState.Exist
                trans.Rollback()
                Return tStatus

            Else

                intMID = db.GetParameterValue(commProc, "@RET_MID")

                intModno = 1

                Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_Add")

                For i = 0 To dgView.Rows.Count - 1

                    commProcSche.Parameters.Clear()

                    db.AddInParameter(commProcSche, "@MID", DbType.Int32, intMID) '
                    db.AddInParameter(commProcSche, "@DSL", DbType.Int32, dgView.Rows(i).Cells(0).Value) '

                    db.AddInParameter(commProcSche, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text.Trim())) '
                    db.AddInParameter(commProcSche, "@ISSUE_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(7).Value)) '
                    db.AddInParameter(commProcSche, "@NIKBRANCH_CODE", DbType.String, dgView.Rows(i).Cells(1).Value) '
                    db.AddInParameter(commProcSche, "@PAYEE_NAME", DbType.String, dgView.Rows(i).Cells(4).Value) '
                    db.AddInParameter(commProcSche, "@CHECK_SERIES", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@CHECK_NUMBER", DbType.String, dgView.Rows(i).Cells(5).Value) '
                    db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@BOOK_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@CHECK_TYPE", DbType.String, "14") '
                    db.AddInParameter(commProcSche, "@ACC_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@DEBIT_CREDIT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(6).Value)) '
                    db.AddInParameter(commProcSche, "@REMARK", DbType.String, lblAccNo.Text.Trim()) '
                    db.AddInParameter(commProcSche, "@BATCH_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue) '
                    db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim()) '
                    db.AddInParameter(commProcSche, "@VALUE_TYPE", DbType.Int32, 1)

                    db.AddInParameter(commProcSche, "@IS_ROW_CHG", SqlDbType.Bit, 1)

                    db.AddInParameter(commProcSche, "@GOV_CHQ", SqlDbType.Bit, 0)
                    db.AddInParameter(commProcSche, "@IQA_FAILED", SqlDbType.Bit, 0)

                    db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProcSche, trans)

                    If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                        trans.Rollback()
                        Return TransState.UnspecifiedError

                    End If


                Next


                tStatus = TransState.Add


            End If

            trans.Commit()

        End Using





        Return tStatus

    End Function


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


        'btnViewReversalData.Enabled = False

        'PrepareReversalData()

        'UploadProcess()

        'PDCTransfer()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous


        If _ProcessSuccess = True Then
            MessageBox.Show("! Upload Completed !" + _
                            Environment.NewLine + "", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)



        End If

        'dtpDate.Enabled = True

        cmbEntryLocation.Enabled = True
        txtDDDepoCode.ReadOnly = False
        'btnBrowse.Enabled = True
        btnImportProcess.Enabled = True




    End Sub











    Private Sub FrmClearCheckImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If



        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

        GetClearingDate()

        btnPrepareChecks.Enabled = False

    End Sub

    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count) Then
            If NullHelper.ObjectToString(dgView.Rows(e.RowIndex).Cells(8).Value) = "1" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato
            Else
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub btnImportProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportProcess.Click
        If txtAccNo.Text.Trim() = "" Then

            MessageBox.Show("Please enter A/C No.", "A/C No required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccNo.Focus()
            Exit Sub

        End If

        If txtDDDepoCode.Text.Trim() = "" Then

            MessageBox.Show("Please enter Deposit code.", "Deposit Code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDDDepoCode.Focus()
            Exit Sub

        End If

        lblAccNo.Text = txtAccNo.Text.Trim()
        txtDepoCode.Text = txtDDDepoCode.Text.Trim()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_GetDetailForSubsystem")
            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDDDepoCode.Text.Trim())

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count = 0 Then

                MessageBox.Show("No record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If


            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = i + 1
                    dgView.Item(1, i).Value = dt.Rows(i)("NIKBRANCH_CODE")
                    'dgView.Item(2, i).Value = dt.Rows(i)("BANK_NAME")
                    'dgView.Item(3, i).Value = dt.Rows(i)("BRANCH_NAME")
                    dgView.Item(4, i).Value = "ACCOUNT PAYABLE(C.MGT)-COLLECTN."
                    dgView.Item(5, i).Value = dt.Rows(i)("DD_NO")
                    dgView.Item(6, i).Value = dt.Rows(i)("AMOUNT")
                    dgView.Item(7, i).Value = NullHelper.DateToString(dt.Rows(i)("DD_DATE"))


                Next
                dgView.AllowUserToAddRows = False

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


        _flagAccount = False
        _flagInvalidBranch = False
        'lblAccName.Text = ""
        'lblAccNo.Text = ""
        lblTotalCheckAmount.Text = ""
        lblTotalCheckNo.Text = ""
        'btnPrepareChecks.Enabled = False

        'ReadExcel()
        CheckValidation()

       If _flagInvalidBranch = True Then
            MessageBox.Show("Invalid Branch code found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("No valid record found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            btnPrepareChecks.Enabled = True
        End If



        Exit Sub


        'dtpDate.Enabled = False
        'cmbEntryLocation.Enabled = False
        'txtDDDepoCode.ReadOnly = True

        'btnImportProcess.Enabled = False

        'ProgressBar1.Style = ProgressBarStyle.Marquee

        'BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub btnPrepareChecks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrepareChecks.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        MessageBox.Show("Clearing Checks Preparing Successfull." & Environment.NewLine & _
                                        "** Authorization needed from Clearing Check Detail/Summary Form", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ElseIf tState = TransState.Exist Then
                        lblToolStatus.Text = "!! Already Exist !!"
                    ElseIf tState = TransState.NoRecord Then
                        lblToolStatus.Text = "!! Nothing to Update !!"
                    ElseIf tState = TransState.DBError Then
                        lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                    ElseIf tState = TransState.UnspecifiedError Then
                        lblToolStatus.Text = "!! Unpecified Error Occured !!"
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class