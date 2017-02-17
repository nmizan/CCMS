'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Import Clearing Excel file
'Creation date      : 18-Aug-2013
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


Public Class FrmClearCheckImport



#Region "Global Variables"

    Dim _formName As String = "ClearingUploadClearingCheck"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _ProcessSuccess As Boolean = False

    Dim _flagAccount As Boolean = False
    Dim _flagInvalidBranch As Boolean = False
#End Region


#Region "User defined Procedures"


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


    Private Sub ReadExcel()
        Dim xlApp As New Excel.Application


        Try


            Dim wb As Excel.Workbook = xlApp.Workbooks.Open(opdRetFile.FileName)




            Dim sheet As Excel.Worksheet = wb.Sheets(1)

            Dim xlRange As Excel.Range = sheet.UsedRange

            Dim rowCount As Integer = xlRange.Rows.Count
            Dim colCount As Integer = xlRange.Columns.Count


            Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

            'xlRange.Cells(0, 0)
            dgView.Rows.Clear()
            dgView.AllowUserToAddRows = True

            Dim i As Integer
            For i = 2 To rowCount

                If sheet.Range("A" & i.ToString()).Value2 Is Nothing Then
                    Exit For
                End If

                If sheet.Range("A" & i.ToString()).Value2.ToString() = "" Then
                    Exit For
                End If

                If (i = dgView.Rows.Count + 1) Then
                    dgView.Rows.Add()
                End If


                dgView.Item(0, i - 2).Value = i - 1

                dgView.Item(1, i - 2).Value = sheet.Range("B" & i.ToString()).Value2 'nikash code
                dgView.Item(2, i - 2).Value = sheet.Range("C" & i.ToString()).Value2 'routing no
                dgView.Item(6, i - 2).Value = sheet.Range("A" & i.ToString()).Value2 'account no
                dgView.Item(7, i - 2).Value = sheet.Range("F" & i.ToString()).Value2 ' reference
                dgView.Item(8, i - 2).Value = sheet.Range("D" & i.ToString()).Value2 'check no
                dgView.Item(9, i - 2).Value = sheet.Range("E" & i.ToString()).Value2 'amount


                'For j = 1 To colCount




                '    '                MessageBox.Show(sheet.Range(colCharset.Substring(j - 1, 1) & i.ToString()).Value2)
                '    'MessageBox.Show(xlRange.v)
                'Next
            Next
            dgView.AllowUserToAddRows = False









            wb.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Try
            xlApp.Quit()
        Catch ex As Exception

        End Try

        


    End Sub

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

                If Not NullHelper.ObjectToString(row.Cells(6).Value).Trim() = "" Then 'Account No

                    If tmpAccount.Trim() <> "" _
                        And tmpAccount <> NullHelper.ObjectToString(row.Cells(6).Value).Trim() Then
                        flagAccount = True
                        _flagAccount = True

                    End If

                    If tmpAccount.Trim() = "" Then
                        tmpAccount = NullHelper.ObjectToString(row.Cells(6).Value).Trim()
                    End If


                    CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(9).Value)

                    CheckNoTotal = CheckNoTotal + 1

                    If NullHelper.ToDecNum(row.Cells(9).Value) = 0 Then 'Amount
                        flagRequireField = True

                    End If

                    If NullHelper.ObjectToString(row.Cells(8).Value).Trim() = "" Then 'Check no
                        flagRequireField = True
                    End If


                    If NullHelper.ObjectToString(row.Cells(1).Value).Trim() = "" _
                        And NullHelper.ObjectToString(row.Cells(2).Value).Trim() = "" Then 'Nikbranch Code and Routing No

                        flagRequireField = True

                    Else

                        If GetBankInfo(NullHelper.ObjectToString(row.Cells(1).Value), NullHelper.ObjectToString(row.Cells(2).Value), row.Index) = False Then
                            flagInvalidBranch = True
                            _flagInvalidBranch = True
                            
                        End If

                    End If

                End If



                

                If flagRequireField = True Then
                    strErrMsg = strErrMsg & "| Require Field Missing |"
                End If

                If flagAccount = True Then
                    strErrMsg = strErrMsg & "| Different Account |"
                End If

                If flagInvalidBranch = True Then
                    strErrMsg = strErrMsg & "| Invalid Branch Code |"
                End If

                If flagRequireField = True Or flagAccount = True Or flagInvalidBranch Then
                    row.Cells(10).Value = 1
                    row.Cells(11).Value = strErrMsg
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

    Private Function GetBankInfo(ByVal strNikBranch As String, ByVal strRouting As String, ByVal intRow As Integer)

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

                    dgView.Rows(intRow).Cells(3).Value = dt.Rows(0)("BANK_NAME").ToString()
                    dgView.Rows(intRow).Cells(4).Value = dt.Rows(0)("BRANCH_NAME").ToString()

                    flagReturn = True

                End If

            ElseIf strRouting.Trim() <> "" Then
                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBranch_GetDetailByRouting")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@ROUTING_NO", DbType.String, strRouting.Trim())

                dt = db.ExecuteDataSet(commProc).Tables(0)

                If dt.Rows.Count > 0 Then
                    'lblBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                    If dt.Rows(0)("NIKBRANCH_CODE").ToString().Trim() <> "" Then

                        dgView.Rows(intRow).Cells(1).Value = dt.Rows(0)("NIKBRANCH_CODE").ToString()
                        dgView.Rows(intRow).Cells(3).Value = dt.Rows(0)("BANK_NAME").ToString()
                        dgView.Rows(intRow).Cells(4).Value = dt.Rows(0)("BRANCH_NAME").ToString()

                        flagReturn = True

                    End If

                    

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
            MessageBox.Show("Customer Account required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ACC_NO", DbType.String, lblAccNo.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("SPEED_CR_TYPE").ToString().Trim() = "R" And txtCustomerRef.Text.Trim() = "" Then
                    MessageBox.Show("This Customer ref. cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCustomerRef.Focus()
                    Return False

                End If

            Else

                MessageBox.Show("No client information found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

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
            db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddOutParameter(commProc, "@RET_MID", DbType.Int32, 10)
            db.AddInParameter(commProc, "@AddSlipText", DbType.String, "")

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
                    db.AddInParameter(commProcSche, "@ISSUE_DATE", DbType.DateTime, NullHelper.StringToDate(txtIssueDate.Text.Trim())) '
                    db.AddInParameter(commProcSche, "@NIKBRANCH_CODE", DbType.String, dgView.Rows(i).Cells(1).Value) '
                    db.AddInParameter(commProcSche, "@PAYEE_NAME", DbType.String, lblAccName.Text.Trim()) '
                    db.AddInParameter(commProcSche, "@CHECK_SERIES", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@CHECK_NUMBER", DbType.String, dgView.Rows(i).Cells(8).Value.ToString().PadLeft(7, "0")) '
                    db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@BOOK_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@CHECK_TYPE", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@ACC_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@DEBIT_CREDIT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(9).Value)) '
                    db.AddInParameter(commProcSche, "@REMARK", DbType.String, lblAccNo.Text.Trim()) '
                    db.AddInParameter(commProcSche, "@BATCH_NO", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(7).Value) '
                    db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue) '
                    db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim()) '
                    db.AddInParameter(commProcSche, "@VALUE_TYPE", DbType.Int32, cmbValueType.SelectedValue) '

                    db.AddInParameter(commProcSche, "@IS_ROW_CHG", SqlDbType.Bit, 1)

                    db.AddInParameter(commProcSche, "@GOV_CHQ", SqlDbType.Bit, 0)
                    db.AddInParameter(commProcSche, "@IQA_FAILED", SqlDbType.Bit, 0)

                    db.AddInParameter(commProcSche, "@AddCheckText", DbType.String, "") '
                    db.AddInParameter(commProcSche, "@Routing_No", DbType.String, dgView.Rows(i).Cells(2).Value) '

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


    'Private Sub UploadProcess()


    '    lblToolStatus.Text = ""

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Using conn As DbConnection = db.CreateConnection()

    '            conn.Open()

    '            Dim trans As DbTransaction = conn.BeginTransaction()


    '            ''''''''''''''''''''''''''''''''''''''' ok
    '            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_PDCTransfer")

    '            commProc1.Parameters.Clear()

    '            db.AddInParameter(commProc1, "@OPR_DATE", DbType.DateTime, dtpDate.Value)
    '            db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

    '            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '            Dim result As Integer

    '            db.ExecuteNonQuery(commProc1, trans)
    '            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

    '            If result > 0 Then
    '                trans.Rollback()
    '                MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub

    '            End If


    '            trans.Commit()
    '            _ProcessSuccess = True

    '        End Using



    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try


    'End Sub

    'Private Function AddIRE(ByVal ChequeSec As String, ByVal ItemAmt As String, ByVal RetReason As String) As Boolean

    '    Dim l As Integer = ItemAmt.Length
    '    Dim AmtFirst As String = ItemAmt.Substring(0, l - 2)
    '    Dim AmtLast As String = ItemAmt.Substring(l - 2)

    '    ItemAmt = AmtFirst & "." & AmtLast

    '    Dim dItemAmt As Decimal = NullHelper.ToDecNum(ItemAmt)

    '    'MessageBox.Show(ChequeSec & Environment.NewLine & ItemAmt & Environment.NewLine & RetReason _
    '    '                & Environment.NewLine & dItemAmt.ToString())

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IRERet_Add")

    '        commProc.Parameters.Clear()

    '        db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue.ToString())
    '        db.AddInParameter(commProc, "@ChequeSequenceNumber", DbType.String, ChequeSec.Trim())
    '        db.AddInParameter(commProc, "@ItemAmount", DbType.Decimal, dItemAmt)
    '        db.AddInParameter(commProc, "@ReturnReason", DbType.String, RetReason.Trim())

    '        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '        Dim result As Integer

    '        db.ExecuteNonQuery(commProc)
    '        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
    '        If result <> 0 Then
    '            Return False
    '        End If

    '    Catch ex As Exception

    '        Return False


    '    End Try


    '    Return True


    'End Function



    'Private Sub ImportReturn()


    '    lblToolStatus.Text = ""



    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IRERet_Remove")

    '        commProc.Parameters.Clear()

    '        db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue.ToString())

    '        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '        Dim result As Integer

    '        db.ExecuteNonQuery(commProc)
    '        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
    '        If result <> 0 Then

    '            MessageBox.Show("Table Clear Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            Exit Sub

    '        End If


    '        Using reader As XmlTextReader = New XmlTextReader(txtFilename.Text)

    '            Dim ChequeSecNo As String = ""
    '            Dim ItemAmt As String = ""
    '            Dim RetReason As String = ""
    '            Dim FlagStart As Boolean = False

    '            Do While (reader.Read())
    '                If reader.NodeType = XmlNodeType.Element And reader.Name = "ChequeSequenceNumber" Then
    '                    FlagStart = True
    '                    reader.Read()
    '                    ChequeSecNo = reader.Value

    '                    'MessageBox.Show(reader.Value)
    '                End If

    '                If reader.NodeType = XmlNodeType.Element And reader.Name = "ItemAmount" Then
    '                    reader.Read()
    '                    ItemAmt = reader.Value
    '                    'MessageBox.Show(reader.Value)
    '                End If

    '                If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "ReturnReason" Then
    '                    FlagStart = False
    '                    reader.Read()
    '                    RetReason = reader.Value

    '                    If AddIRE(ChequeSecNo, ItemAmt, RetReason) = False Then
    '                        MessageBox.Show("XML to table Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        Exit Sub

    '                    End If

    '                    ChequeSecNo = ""
    '                    ItemAmt = ""
    '                    RetReason = ""
    '                    'MessageBox.Show(reader.Value)
    '                End If

    '            Loop

    '            reader.Close()

    '        End Using

    '        _ProcessSuccess = True


    '    Catch ex As Exception


    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)


    '    End Try


    'End Sub

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
        txtFilename.ReadOnly = False
        btnBrowse.Enabled = True
        btnImportProcess.Enabled = True




    End Sub








   


    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        opdRetFile.Multiselect = False
        'opdRetFile.Filter() = "XML Files (*.XML)|(*.XML)"
        opdRetFile.FileName = txtFilename.Text

        opdRetFile.ShowDialog()
        txtFilename.Text = opdRetFile.FileName()
    End Sub

    Private Sub FrmClearCheckImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        LoadComboValues()

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

        GetClearingDate()

        txtIssueDate.Text = Date.Today.ToString("dd/MM/yyyy")


        btnPrepareChecks.Enabled = False

    End Sub

    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count) Then
            If NullHelper.ObjectToString(dgView.Rows(e.RowIndex).Cells(10).Value) = "1" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato
            End If
        End If
    End Sub

    Private Sub btnImportProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportProcess.Click
        'If cmbEntryLocation.SelectedIndex = -1 Then
        '    MessageBox.Show("Select Entry Location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbEntryLocation.Focus()
        '    Exit Sub
        'End If

        If Not File.Exists(txtFilename.Text) Then
            MessageBox.Show("Select File", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnBrowse.Focus()
            Exit Sub
        End If

        _flagAccount = False
        _flagInvalidBranch = False
        lblAccName.Text = ""
        lblAccNo.Text = ""
        lblTotalCheckAmount.Text = ""
        lblTotalCheckNo.Text = ""
        btnPrepareChecks.Enabled = False

        ReadExcel()
        CheckValidation()

        If _flagAccount = True Then
            MessageBox.Show("All Account no must be same", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf GetAccountName() = False Then
            MessageBox.Show("Account no is not valid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf _flagInvalidBranch = True Then
            MessageBox.Show("Invalid Branch code found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("No valid record found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            btnPrepareChecks.Enabled = True
        End If



        Exit Sub


        'dtpDate.Enabled = False
        cmbEntryLocation.Enabled = False
        txtFilename.ReadOnly = True
        btnBrowse.Enabled = False
        btnImportProcess.Enabled = False

        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()

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