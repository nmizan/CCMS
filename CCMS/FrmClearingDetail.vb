
'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Maintain Clearing Check Detail
'Creation date      : 08-Jan-2013
'Stored Procedure(s):  
'
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmClearingDetail


#Region "Global Variables"

    Public Shared AddSlipText As String = ""
    Public Shared AddCheckText As String = ""
    Dim _formName As String = "ClearingCheckDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    'Dim _strDSCode As String = ""
    'Dim _strEntryLoc As String = ""
    'Dim _dtOpr As Date
    Dim _intModno As Integer = 0
    Dim _intMID As Integer = 0
    Dim _intDSL As Integer = 0

    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False

    Dim _IsResetRow As Boolean = False

    Dim log_message As String
    Dim dt1 As New DataTable()

    'For Update
    Dim _clearDate As String = ""
    Dim _custRef As String = ""
    Dim _numOfCheck As String = ""
    Dim _checkAmt As String = ""

    Dim _issueDate(1000) As String
    Dim _amount(1000) As String
    Dim _checkNo(1000) As String

    'For Auth
    Dim _aclearDate As String = ""
    Dim _acustRef As String = ""
    Dim _anumOfCheck As String = ""
    Dim _acheckAmt As String = ""

    Dim _aissueDate(1000) As String
    Dim _aamount(1000) As String
    Dim _acheckNo(1000) As String

    Dim ClerList As New List(Of String)
    Dim _clearLog As String = ""
    Dim _log As String = ""
#End Region

#Region "User defined Codes"


    Private Sub EnableUnlock()
        If opt.IsUnlock = True Then
            btnUnlock.Enabled = True
        Else
            DisableUnlock()
        End If
    End Sub

    Private Sub DisableUnlock()
        btnUnlock.Enabled = False
    End Sub

    Private Sub EnableNew()
        If opt.IsNew = True Then
            btnNew.Enabled = True
        Else
            DisableNew()
        End If
    End Sub

    Private Sub DisableNew()
        btnNew.Enabled = False
    End Sub

    Private Sub EnableSave()
        If opt.IsSave = True Then
            btnSave.Enabled = True
        Else
            DisableSave()
        End If
    End Sub

    Private Sub DisableSave()
        btnSave.Enabled = False
    End Sub

    Private Sub EnableDelete()
        If opt.IsDelete = True Then
            btnDelete.Enabled = True
        Else
            DisableDelete()
        End If
    End Sub

    Private Sub DisableDelete()
        btnDelete.Enabled = False
    End Sub

    Private Sub EnableAuth()
        If opt.IsAuth = True Then
            btnAuthorize.Enabled = True
        Else
            DisableAuth()
        End If
    End Sub

    Private Sub DisableAuth()
        btnAuthorize.Enabled = False
    End Sub


    Private Sub EnableRefresh()
        btnRefresh.Enabled = True
    End Sub

    Private Sub DisableRefresh()
        btnRefresh.Enabled = False
    End Sub

    Private Sub DisableFields()

        txtClearingDate.ReadOnly = True
        txtEntryLocation.ReadOnly = True
        btnSearchLocation.Enabled = False
        txtCustomerAcc.ReadOnly = True
        btnSearchCustomer.Enabled = False
        txtDepoCode.ReadOnly = True
        txtCustomerRef.ReadOnly = True
        txtTotalCheckNo.ReadOnly = True
        txtTotalCheckAmount.ReadOnly = True

        txtRoutingNo.ReadOnly = True
        btnSearchRouting.Enabled = False
        txtBankCode.ReadOnly = True
        btnSearchBank.Enabled = False
        txtBranchCode.ReadOnly = True
        btnSearchBranch.Enabled = False

        chkG2P.Enabled = False
        chkIQA.Enabled = False

        txtCheckSeries.ReadOnly = True
        txtBookNo.ReadOnly = True
        txtCheckNo.ReadOnly = True
        txtBatchNo.ReadOnly = True

        txtIssueDate.ReadOnly = True
        txtCheckRef.ReadOnly = True
        'chkPdc.Enabled = False
        txtCheckNumber.ReadOnly = True
        txtCheckTypeCode.ReadOnly = True
        btnSearchCheckType.Enabled = False
        txtAccNo.ReadOnly = True
        txtAmount.ReadOnly = True

        cmbValueType.Enabled = False

     

        btnAddToGrid.Enabled = False
        btnRemoveFromGrid.Enabled = False

        dgView.Enabled = False

        'dgView.ReadOnly = True



    End Sub

    Private Sub EnableFields()

        If _intModno = 0 Then

            txtEntryLocation.ReadOnly = False
            btnSearchLocation.Enabled = True
            
        End If

        txtDepoCode.ReadOnly = False

        txtClearingDate.ReadOnly = False

        
        txtCustomerAcc.ReadOnly = False
        btnSearchCustomer.Enabled = True

        txtCustomerRef.ReadOnly = False
        txtTotalCheckNo.ReadOnly = False
        txtTotalCheckAmount.ReadOnly = False

        txtRoutingNo.ReadOnly = False
        btnSearchRouting.Enabled = True
        txtBankCode.ReadOnly = False
        btnSearchBank.Enabled = True
        txtBranchCode.ReadOnly = False
        btnSearchBranch.Enabled = True

        chkG2P.Enabled = True
        chkIQA.Enabled = True


        txtCheckSeries.ReadOnly = False
        txtBookNo.ReadOnly = False
        txtCheckNo.ReadOnly = False
        txtBatchNo.ReadOnly = False

        txtIssueDate.ReadOnly = False
        txtCheckRef.ReadOnly = False
        'txtCheckRef.Enabled = True
        'chkPdc.Enabled = True
        txtCheckNumber.ReadOnly = False
        txtCheckTypeCode.ReadOnly = False
        btnSearchCheckType.Enabled = True
        txtAccNo.ReadOnly = False
        txtAmount.ReadOnly = False
        cmbValueType.Enabled = True

        btnAddToGrid.Enabled = True
        btnRemoveFromGrid.Enabled = True

        dgView.Enabled = True

    End Sub


    Private Sub ClearFields()

        txtClearingDate.Clear()

        txtCustomerAcc.Clear()
        lblAccName.Text = ""

        txtCustomerRef.Clear()
        txtTotalCheckNo.Clear()
        txtTotalCheckAmount.Clear()

        txtRoutingNo.Clear()
        txtBankCode.Clear()
        lblBankName.Text = ""
        txtBranchCode.Clear()
        lblBranchName.Text = ""

        chkG2P.Checked = False
        chkIQA.Checked = False

        txtCheckSeries.Clear()
        txtBookNo.Clear()
        txtCheckNo.Clear()
        txtBatchNo.Clear()

        txtIssueDate.Clear()
        txtCheckRef.Clear()
        chkPdc.Checked = False
        txtCheckNumber.Clear()
        txtCheckTypeCode.Clear()
        lblCheckTypeName.Text = ""

        txtAccNo.Clear()
        txtAmount.Clear()

        
        

        'dgView.AllowUserToAddRows = False

        'dgView.DataSource = Nothing

    End Sub

    Private Sub ClearFieldsAll()

        AddSlipText = ""
        AddCheckText = ""

        lblEntryDate.Text = ""

        txtClearingDate.Clear()
        txtEntryLocation.Clear()
        lblEntryLocation.Text = ""

        txtCustomerAcc.Clear()
        lblAccName.Text = ""
        txtDepoCode.Clear()
        txtCustomerRef.Clear()
        txtTotalCheckNo.Clear()
        txtTotalCheckAmount.Clear()

        txtRoutingNo.Clear()
        txtBankCode.Clear()
        lblBankName.Text = ""
        txtBranchCode.Clear()
        lblBranchName.Text = ""

        chkG2P.Checked = False
        chkIQA.Checked = False


        txtCheckSeries.Clear()
        txtBookNo.Clear()
        txtCheckNo.Clear()
        txtBatchNo.Clear()

        txtIssueDate.Clear()
        txtCheckRef.Clear()
        chkPdc.Checked = False
        txtCheckNumber.Clear()
        txtCheckTypeCode.Clear()
        lblCheckTypeName.Text = ""

        txtAccNo.Clear()
        txtAmount.Clear()


        dgView.AllowUserToAddRows = False

        dgView.DataSource = Nothing
        dgView.Rows.Clear()

        '_strDSCode = ""
        '_strEntryLoc = ""
        _intModno = 0
        _intMID = 0

        lblVerNo.Text = ""
        lblVerTot.Text = ""

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""

        ShowGridTotal()

        _IsResetRow = False



    End Sub


    Private Sub ShowGridTotal()

        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0


        For Each row As DataGridViewRow In dgView.Rows


            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(16).Value)

            CheckNoTotal = CheckNoTotal + 1

        Next

        lblTotalCheckNo.Text = CheckNoTotal.ToString()
        lblTotalCheckAmount.Text = CheckTotal.ToString()


        If NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()) <> CheckTotal Then
            lblTotalCheckAmount.ForeColor = Color.Red
        Else
            lblTotalCheckAmount.ForeColor = Color.Black
        End If

        If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then
            lblTotalCheckNo.ForeColor = Color.Red
        Else
            lblTotalCheckNo.ForeColor = Color.Black
        End If


    End Sub


    ''' <summary>
    ''' Show validation status and return true if mismatch found
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ShowOpertionStatus() As Boolean

        Dim flagMismatch = False

        Dim CheckTotal As Decimal = 0
        Dim CheckNoTotal As Integer = 0

        Dim MsgStatus As String = ""


        For Each row As DataGridViewRow In dgView.Rows


            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(16).Value)

            CheckNoTotal = CheckNoTotal + 1


        Next


        If NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()) <> CheckTotal Then

            Dim diffCheck As Decimal = CheckTotal - NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim())
            MsgStatus = MsgStatus + "Mismatch in Total Check amount:  " & diffCheck.ToString() & Environment.NewLine

        End If

        If NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()) <> CheckNoTotal Then

            Dim diffCheckNo As Integer = CheckNoTotal - NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim())
            MsgStatus = MsgStatus + "Mismatch in Total Check No:  " & diffCheckNo.ToString() & Environment.NewLine

        End If

        If MsgStatus.Trim() <> "" Then
            flagMismatch = True
            MessageBox.Show(MsgStatus, "Mismatch Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Return flagMismatch


    End Function

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

    Private Sub ResetIsRowChangedValue()

        If _IsResetRow = False And chkAuthorized.Checked = True Then

            For Each row As DataGridViewRow In dgView.Rows


                row.Cells(24).Value = False

            Next

            _IsResetRow = True




        End If



    End Sub

    Private Function CheckValidData() As Boolean


        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False
        ElseIf txtCustomerAcc.Text.Trim() = "" Or lblAccName.Text.Trim() = "" Then
            MessageBox.Show("Customer Account required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCustomerAcc.Focus()
            Return False
        ElseIf txtClearingDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Clearing date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClearingDate.Focus()
            Return False
        ElseIf txtEntryLocation.Text.Trim() = "" Or lblEntryLocation.Text.Trim() = "" Then
            MessageBox.Show("Entry Location Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEntryLocation.Focus()
            Return False
        ElseIf txtTotalCheckAmount.Text.Trim() = "" Then
            MessageBox.Show("Total check amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckAmount.Focus()
            Return False
        ElseIf txtTotalCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Total check no required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalCheckNo.Focus()
            Return False


        ElseIf dgView.Rows.Count = 0 Then
            MessageBox.Show("You didn't enter any record!!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtCustomerAcc.Text.Trim())

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



        If ShowOpertionStatus() = True Then
            Return False
        End If



        Return True

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_Add")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc, "@TOTAL_CHKNO", DbType.Int32, NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()))
                db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text.Trim()))
                db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
                db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, txtEntryLocation.Text.Trim())
                db.AddInParameter(commProc, "@AddSlipText", DbType.String, AddSlipText)

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

                    _intMID = db.GetParameterValue(commProc, "@RET_MID")

                    intModno = 1

                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_Add")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()

                        db.AddInParameter(commProcSche, "@MID", DbType.Int32, _intMID)
                        db.AddInParameter(commProcSche, "@DSL", DbType.Int32, dgView.Rows(i).Cells(0).Value)

                        db.AddInParameter(commProcSche, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text.Trim()))
                        db.AddInParameter(commProcSche, "@ISSUE_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(11).Value))
                        db.AddInParameter(commProcSche, "@NIKBRANCH_CODE", DbType.String, dgView.Rows(i).Cells(3).Value)
                        db.AddInParameter(commProcSche, "@PAYEE_NAME", DbType.String, dgView.Rows(i).Cells(5).Value)
                        db.AddInParameter(commProcSche, "@CHECK_SERIES", DbType.String, dgView.Rows(i).Cells(7).Value)
                        db.AddInParameter(commProcSche, "@CHECK_NUMBER", DbType.String, dgView.Rows(i).Cells(13).Value)
                        db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, dgView.Rows(i).Cells(9).Value)
                        db.AddInParameter(commProcSche, "@BOOK_NO", DbType.String, dgView.Rows(i).Cells(8).Value)
                        db.AddInParameter(commProcSche, "@CHECK_TYPE", DbType.String, dgView.Rows(i).Cells(14).Value)
                        db.AddInParameter(commProcSche, "@ACC_NO", DbType.String, dgView.Rows(i).Cells(6).Value)
                        db.AddInParameter(commProcSche, "@DEBIT_CREDIT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(16).Value))
                        db.AddInParameter(commProcSche, "@REMARK", DbType.String, txtCustomerAcc.Text.Trim())
                        db.AddInParameter(commProcSche, "@BATCH_NO", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(12).Value)
                        db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, txtEntryLocation.Text.Trim())
                        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@VALUE_TYPE", DbType.Int32, dgView.Rows(i).Cells(23).Value)

                        db.AddInParameter(commProcSche, "@IS_ROW_CHG", SqlDbType.Bit, dgView.Rows(i).Cells(24).Value)

                        db.AddInParameter(commProcSche, "@GOV_CHQ", SqlDbType.Bit, dgView.Rows(i).Cells(25).Value)
                        db.AddInParameter(commProcSche, "@IQA_FAILED", SqlDbType.Bit, dgView.Rows(i).Cells(26).Value)

                        db.AddInParameter(commProcSche, "@Routing_No", DbType.String, dgView.Rows(i).Cells(27).Value)

                        db.AddInParameter(commProcSche, "@AddCheckText", DbType.String, dgView.Rows(i).Cells(28).Value)

                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Add
                    '_strDSCode = txtDepoCode.Text.Trim()
                    '_strEntryLoc = txtEntryLocation.Text.Trim()
                    '_dtOpr = NullHelper.StringToDate(txtClearingDate.Text.Trim())
                    _intModno = 1

                End If

                trans.Commit()

            End Using

        ElseIf _formMode = FormTransMode.Update Then


            Using conn As DbConnection = db.CreateConnection()


                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_Update")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@MID", DbType.Int32, _intMID)
                db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim())
                db.AddInParameter(commProc, "@TOTAL_CHKNO", DbType.Int32, NullHelper.ToIntNum(txtTotalCheckNo.Text.Trim()))
                db.AddInParameter(commProc, "@TOTAL_CHKAMT", DbType.Decimal, NullHelper.ToDecNum(txtTotalCheckAmount.Text.Trim()))
                db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text.Trim()))
                db.AddInParameter(commProc, "@CUSTOMER_REF", DbType.String, txtCustomerRef.Text.Trim())
                db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, txtEntryLocation.Text.Trim())
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)
                db.AddInParameter(commProc, "@AddSlipText", DbType.String, AddSlipText)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result = 1 Then
                    tStatus = TransState.UnspecifiedError
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 4 Then
                    tStatus = TransState.NoRecord
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 0 Then

                    intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")


                    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_Update")

                    For i = 0 To dgView.Rows.Count - 1

                        commProcSche.Parameters.Clear()
                        db.AddInParameter(commProcSche, "@MID", DbType.Int32, _intMID)
                        db.AddInParameter(commProcSche, "@DSL", DbType.Int32, dgView.Rows(i).Cells(0).Value)

                        db.AddInParameter(commProcSche, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text.Trim()))
                        db.AddInParameter(commProcSche, "@ISSUE_DATE", DbType.DateTime, NullHelper.StringToDate(dgView.Rows(i).Cells(11).Value))
                        db.AddInParameter(commProcSche, "@NIKBRANCH_CODE", DbType.String, dgView.Rows(i).Cells(3).Value)
                        db.AddInParameter(commProcSche, "@PAYEE_NAME", DbType.String, dgView.Rows(i).Cells(5).Value)
                        db.AddInParameter(commProcSche, "@CHECK_SERIES", DbType.String, dgView.Rows(i).Cells(7).Value)
                        db.AddInParameter(commProcSche, "@CHECK_NUMBER", DbType.String, dgView.Rows(i).Cells(13).Value)
                        db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, dgView.Rows(i).Cells(9).Value)
                        db.AddInParameter(commProcSche, "@BOOK_NO", DbType.String, dgView.Rows(i).Cells(8).Value)
                        db.AddInParameter(commProcSche, "@CHECK_TYPE", DbType.String, dgView.Rows(i).Cells(14).Value)
                        db.AddInParameter(commProcSche, "@ACC_NO", DbType.String, dgView.Rows(i).Cells(6).Value)
                        db.AddInParameter(commProcSche, "@DEBIT_CREDIT", DbType.Decimal, NullHelper.ToDecNum(dgView.Rows(i).Cells(16).Value))
                        db.AddInParameter(commProcSche, "@REMARK", DbType.String, txtCustomerAcc.Text.Trim())
                        db.AddInParameter(commProcSche, "@BATCH_NO", DbType.String, dgView.Rows(i).Cells(10).Value)
                        db.AddInParameter(commProcSche, "@CHECK_REF", DbType.String, dgView.Rows(i).Cells(12).Value)
                        db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, txtEntryLocation.Text.Trim())
                        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim())
                        db.AddInParameter(commProcSche, "@RTN_STATUS", DbType.String, dgView.Rows(i).Cells(17).Value)
                        db.AddInParameter(commProcSche, "@RTN_CODE", DbType.String, dgView.Rows(i).Cells(18).Value)
                        db.AddInParameter(commProcSche, "@RETURN_DATE", DbType.DateTime, dgView.Rows(i).Cells(19).Value)
                        db.AddInParameter(commProcSche, "@CHECKED", DbType.Int32, dgView.Rows(i).Cells(20).Value)
                        db.AddInParameter(commProcSche, "@FLEX_FILENAME", DbType.String, dgView.Rows(i).Cells(21).Value)
                        db.AddInParameter(commProcSche, "@IS_PDC", SqlDbType.Bit, dgView.Rows(i).Cells(22).Value)
                        db.AddInParameter(commProcSche, "@VALUE_TYPE", DbType.Int32, dgView.Rows(i).Cells(23).Value)
                        db.AddInParameter(commProcSche, "@IS_ROW_CHG", SqlDbType.Bit, dgView.Rows(i).Cells(24).Value)
                        db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intModno)
                        db.AddInParameter(commProcSche, "@GOV_CHQ", SqlDbType.Bit, dgView.Rows(i).Cells(25).Value)
                        db.AddInParameter(commProcSche, "@IQA_FAILED", SqlDbType.Bit, dgView.Rows(i).Cells(26).Value)
                        db.AddInParameter(commProcSche, "@Routing_No", DbType.String, dgView.Rows(i).Cells(27).Value)
                        db.AddInParameter(commProcSche, "@AddCheckText", DbType.String, dgView.Rows(i).Cells(28).Value)

                        db.AddParameter(commProcSche, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProcSche, trans)

                        If db.GetParameterValue(commProcSche, "@PROC_RET_VAL") <> 0 Then

                            trans.Rollback()
                            Return TransState.UnspecifiedError

                        End If


                    Next


                    tStatus = TransState.Update
                    _intModno = intModno

                    trans.Commit()

                    '------------Mizan Work (09-05-2016)------------

                    If _clearDate <> txtClearingDate.Text.Trim() Then
                        log_message = " Clearing Date : " + _clearDate + " " + " To " + " " + txtClearingDate.Text.Trim() + "." + " "
                        ClerList.Add(log_message)
                    End If

                    If _checkAmt <> txtTotalCheckAmount.Text.Trim() Then
                        log_message = " Check Amount : " + _checkAmt + " " + " To " + " " + txtTotalCheckAmount.Text.Trim() + "." + " "
                        ClerList.Add(log_message)
                    End If
                    If _custRef <> txtCustomerRef.Text.Trim() Then
                        log_message = " Customer Ref. : " + _custRef + " " + " To " + " " + txtCustomerRef.Text.Trim() + "." + " "
                        ClerList.Add(log_message)
                    End If
                    If _numOfCheck <> txtTotalCheckNo.Text.Trim() Then
                        log_message = " Total Check No : " + _numOfCheck + " " + " To " + " " + txtTotalCheckNo.Text.Trim() + "." + " "
                        ClerList.Add(log_message)
                    End If
                   

                    'For Gridview Data

                    For i = 0 To dgView.Rows.Count - 1

                        If _issueDate(i) <> dgView.Item(11, i).Value Then
                            log_message = " Issue Date : " + _issueDate(i) + " " + " To " + " " + dgView.Item(11, i).Value.ToString + "." + " "
                            ClerList.Add(log_message)
                        End If

                        If _checkNo(i) <> dgView.Item(13, i).Value Then
                            log_message = " Check No : " + _checkNo(i) + " " + " To " + " " + dgView.Item(13, i).Value.ToString + "." + " "
                            ClerList.Add(log_message)
                        End If
                        If _amount(i) <> dgView.Item(16, i).Value Then
                            log_message = " Amount  : " + _amount(i) + " " + " To " + " " + dgView.Item(16, i).Value.ToString + "." + " "
                            ClerList.Add(log_message)
                        End If
                        
                    Next

                    '-----------------

                    For Each clrInfo As String In ClerList
                        _clearLog += clrInfo
                    Next
                    _log = " Updated : Clearing Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + _clearLog

                    Logger.system_log(_log)

                    _clearLog = ""
                    ClerList.Clear()

                    '------------Mizan Work (09-05-2016)------------

                    Return tStatus

                End If

                trans.Rollback()


            End Using


        End If


        Return tStatus

    End Function


    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@MID", DbType.Int32, _intMID)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (16-05-2016)------------
            If _intModno > 1 Then

                If _aclearDate <> _clearDate Then
                    log_message = " Clearing Date : " + _aclearDate + " " + " To " + " " + _clearDate + "." + " "
                    ClerList.Add(log_message)
                End If

                If _acheckAmt <> _checkAmt Then
                    log_message = " Check Amount : " + _acheckAmt + " " + " To " + " " + _checkAmt + "." + " "
                    ClerList.Add(log_message)
                End If
                If _acustRef <> _custRef Then
                    log_message = " Customer Ref. : " + _acustRef + " " + " To " + " " + _custRef + "." + " "
                    ClerList.Add(log_message)
                End If
                If _anumOfCheck <> _numOfCheck Then
                    log_message = " Total Check No : " + _anumOfCheck + " " + " To " + " " + _numOfCheck + "." + " "
                    ClerList.Add(log_message)
                End If


                'For Gridview Data

                For i = 0 To dgView.Rows.Count - 1

                    If _aissueDate(i) <> _issueDate(i) Then
                        log_message = " Issue Date : " + _aissueDate(i) + " " + " To " + " " + _issueDate(i) + "." + " "
                        ClerList.Add(log_message)
                    End If

                    If _acheckNo(i) <> _checkNo(i) Then
                        log_message = " Check No : " + _acheckNo(i) + " " + " To " + " " + _checkNo(i) + "." + " "
                        ClerList.Add(log_message)
                    End If
                    If _aamount(i) <> _amount(i) Then
                        log_message = " Amount  : " + _aamount(i) + " " + " To " + " " + _amount(i) + "." + " "
                        ClerList.Add(log_message)
                    End If

                Next

                '-----------------

                For Each clrInfo As String In ClerList
                    _clearLog += clrInfo
                Next
                _log = " Authorized : Clearing Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + _clearLog

                Logger.system_log(_log)

                _clearLog = ""
                ClerList.Clear()


            Else
                _log = " Authorized : Clearing Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + _clearLog
                Logger.system_log(_log)

            End If

            '------------Mizan Work (16-05-2016)------------

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.AlreadyAuthorized

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.MakerCheckerSame
        ElseIf result = 7 Then
            tStatus = TransState.ModifiedOutside

        Else
            tStatus = TransState.UpdateNotPossible
        End If

    Return tStatus

    End Function

    '------------Mizan Work (16-05-2016)------------

    Private Sub LoadMainDataForAuth(ByVal intMID As Integer)

        lblToolStatus.Text = ""

        _IsResetRow = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CHECKTOTAL  Where MID ='" & intMID & "'  and STATUS='L'").Tables(0)

            If dt.Rows.Count > 0 Then

                _intMID = intMID
               

                txtClearingDate.Text = NullHelper.DateToString(dt.Rows(0)("OPR_DATE"))
                _aclearDate = NullHelper.DateToString(dt.Rows(0)("OPR_DATE")).ToString()

                txtDepoCode.Text = dt.Rows(0)("DS_CODE").ToString()
                txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
                _acustRef = dt.Rows(0)("CUSTOMER_REF").ToString()
                txtTotalCheckNo.Text = dt.Rows(0)("TOTAL_CHKNO").ToString()
                _anumOfCheck = dt.Rows(0)("TOTAL_CHKNO").ToString()
                txtTotalCheckAmount.Text = dt.Rows(0)("TOTAL_CHKAMT").ToString()
                _acheckAmt = dt.Rows(0)("TOTAL_CHKAMT").ToString()



            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Private Sub LoadMainData(ByVal strDSCode As String, ByVal dtOpr As Date, ByVal strLocCode As String, ByVal intMod As Integer)

    '    lblToolStatus.Text = ""

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim dt As New DataTable

    '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetDetail")

    '        commProc.Parameters.Clear()

    '        db.AddInParameter(commProc, "@DS_CODE", DbType.String, strDSCode)
    '        db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, dtOpr)
    '        db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, strLocCode)
    '        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

    '        dt = db.ExecuteDataSet(commProc).Tables(0)

    '        If dt.Rows.Count > 0 Then


    '            _strDSCode = strDSCode
    '            _dtOpr = dtOpr
    '            _strEntryLoc = strLocCode
    '            _intModno = intMod

    '            _formMode = FormTransMode.Update

    '            lblEntryDate.Text = NullHelper.DateToString(dt.Rows(0)("ENTRY_DATE"))

    '            txtClearingDate.Text = NullHelper.DateToString(dt.Rows(0)("OPR_DATE"))

    '            txtDepoCode.Text = dt.Rows(0)("DS_CODE").ToString()
    '            txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
    '            txtTotalCheckNo.Text = dt.Rows(0)("TOTAL_CHKNO").ToString()
    '            txtTotalCheckAmount.Text = dt.Rows(0)("TOTAL_CHKAMT").ToString()

    '            lblInputBy.Text = dt.Rows(0)("INPUT_BY").ToString()
    '            lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME").ToString()

    '            _mod_datetime = dt.Rows(0)("INPUT_DATETIME")

    '            lblAuthBy.Text = dt.Rows(0)("AUTH_BY").ToString()
    '            lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME").ToString()

    '            chkAuthorized.Checked = dt.Rows(0)("IS_AUTH")

    '            If dt.Rows(0)("STATUS") = "L" Or dt.Rows(0)("STATUS") = "U" Or dt.Rows(0)("STATUS") = "O" Then
    '                chkOpen.Checked = True
    '            Else
    '                chkOpen.Checked = False
    '            End If

    '            _status = dt.Rows(0)("STATUS")

    '            lblModNo.Text = dt.Rows(0)("MOD_NO").ToString()
    '            lblVerNo.Text = dt.Rows(0)("MOD_NO").ToString()

    '            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetMaxMod")

    '            commProc2.Parameters.Clear()

    '            db.AddInParameter(commProc2, "@DS_CODE", DbType.String, strDSCode)
    '            db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, dtOpr)
    '            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, strLocCode)

    '            lblVerTot.Text = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()


    '            If _status = "L" Or _status = "U" _
    '                Or (_status = "D" And chkAuthorized.Checked = False) Then


    '                If btnUnlock.Enabled = False Then
    '                    EnableFields()
    '                    EnableClear()
    '                    EnableDelete()
    '                    EnableNew()
    '                    EnableRefresh()
    '                    EnableSave()

    '                End If
    '            Else
    '                DisableAuth()
    '                DisableClear()
    '                DisableDelete()
    '                DisableRefresh()
    '                DisableSave()

    '                DisableFields()
    '            End If

    '            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim = CommonAppSet.User) Then
    '                EnableAuth()
    '            Else
    '                DisableAuth()
    '            End If


    '        Else

    '            ClearFieldsAll()

    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub LoadMainData(ByVal intMID As Integer, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        _IsResetRow = False

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@MID", DbType.Int32, intMID)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _intMID = intMID
                '_strDSCode = strDSCode
                '_dtOpr = dtOpr
                '_strEntryLoc = strLocCode
                _intModno = intMod

                _formMode = FormTransMode.Update

                AddSlipText = dt.Rows(0)("AddSlipText").ToString()

                lblEntryDate.Text = NullHelper.DateToString(dt.Rows(0)("ENTRY_DATE"))

                txtClearingDate.Text = NullHelper.DateToString(dt.Rows(0)("OPR_DATE"))
                _clearDate = NullHelper.DateToString(dt.Rows(0)("OPR_DATE")).ToString()

                txtDepoCode.Text = dt.Rows(0)("DS_CODE").ToString()
                txtCustomerRef.Text = dt.Rows(0)("CUSTOMER_REF").ToString()
                _custRef = dt.Rows(0)("CUSTOMER_REF").ToString()
                txtTotalCheckNo.Text = dt.Rows(0)("TOTAL_CHKNO").ToString()
                _numOfCheck = dt.Rows(0)("TOTAL_CHKNO").ToString()
                txtTotalCheckAmount.Text = dt.Rows(0)("TOTAL_CHKAMT").ToString()
                _checkAmt = dt.Rows(0)("TOTAL_CHKAMT").ToString()

                lblInputBy.Text = dt.Rows(0)("INPUT_BY").ToString()
                lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME").ToString()

                _mod_datetime = dt.Rows(0)("INPUT_DATETIME")

                lblAuthBy.Text = dt.Rows(0)("AUTH_BY").ToString()
                lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME").ToString()

                chkAuthorized.Checked = dt.Rows(0)("IS_AUTH")

                If dt.Rows(0)("STATUS") = "L" Or dt.Rows(0)("STATUS") = "U" Or dt.Rows(0)("STATUS") = "O" Then
                    chkOpen.Checked = True
                Else
                    chkOpen.Checked = False
                End If

                _status = dt.Rows(0)("STATUS")

                lblModNo.Text = dt.Rows(0)("MOD_NO").ToString()
                lblVerNo.Text = dt.Rows(0)("MOD_NO").ToString()

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@MID", DbType.String, intMID)

                lblVerTot.Text = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()


                If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then


                    If btnUnlock.Enabled = False Then
                        EnableFields()
                        'EnableClear()
                        EnableDelete()
                        EnableNew()
                        EnableRefresh()
                        EnableSave()

                    End If
                Else
                    DisableAuth()
                    'DisableClear()
                    DisableDelete()
                    DisableRefresh()
                    DisableSave()

                    DisableFields()
                End If

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim.ToUpper() = CommonAppSet.User.ToUpper()) Then
                    EnableAuth()
                Else
                    DisableAuth()
                End If


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (16-05-2016)------------

    Private Sub LoadDetailDataForAuth(ByVal intMID As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CLEARINGTAB  Where MID ='" & intMID & "'  and STATUS='L'").Tables(0)
            
            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(11, i).Value = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE"))
                    _aissueDate(i) = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE")).ToString()

                    dgView.Item(13, i).Value = dt.Rows(i)("CHECK_NUMBER")
                    _acheckNo(i) = dt.Rows(i)("CHECK_NUMBER")

                    dgView.Item(16, i).Value = dt.Rows(i)("DEBIT_CREDIT")
                    _aamount(i) = dt.Rows(i)("DEBIT_CREDIT")


                Next
                dgView.AllowUserToAddRows = False

            End If


            ShowGridTotal()

            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub LoadDetailData(ByVal strDSCode As String, ByVal dtOpr As Date, ByVal strLocCode As String, ByVal intMod As Integer)

    '    lblToolStatus.Text = ""

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim dt As New DataTable

    '        Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetDetails")

    '        commProcSche.Parameters.Clear()

    '        db.AddInParameter(commProcSche, "@DS_CODE", DbType.String, strDSCode)
    '        db.AddInParameter(commProcSche, "@OPR_DATE", DbType.DateTime, dtOpr)
    '        db.AddInParameter(commProcSche, "@ENTRY_LOC", DbType.String, strLocCode)
    '        db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intMod)

    '        dt = db.ExecuteDataSet(commProcSche).Tables(0)


    '        If dt.Rows.Count > 0 Then

    '            txtEntryLocation.Text = dt.Rows(0)("ENTRY_LOC").ToString()
    '            lblEntryLocation.Text = dt.Rows(0)("ENTRY_LOC_NAME").ToString()

    '            txtCustomerAcc.Text = dt.Rows(0)("REMARK").ToString()
    '            lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

    '        End If

    '        dgView.Rows.Clear()


    '        If dt.Rows.Count > 0 Then

    '            dgView.AllowUserToAddRows = True
    '            For i = 0 To dt.Rows.Count - 1
    '                If (i = dgView.Rows.Count - 1) Then
    '                    dgView.Rows.Add()
    '                End If

    '                dgView.Item(0, i).Value = dt.Rows(i)("DSL")
    '                dgView.Item(1, i).Value = dt.Rows(i)("BANK_CODE")
    '                dgView.Item(2, i).Value = dt.Rows(i)("BANK_NAME")
    '                dgView.Item(3, i).Value = dt.Rows(i)("NIKBRANCH_CODE")
    '                dgView.Item(4, i).Value = dt.Rows(i)("BRANCH_NAME")
    '                dgView.Item(5, i).Value = dt.Rows(i)("PAYEE_NAME")
    '                dgView.Item(6, i).Value = dt.Rows(i)("ACC_NO")
    '                dgView.Item(7, i).Value = dt.Rows(i)("CHECK_SERIES")
    '                dgView.Item(8, i).Value = dt.Rows(i)("BOOK_NO")
    '                dgView.Item(9, i).Value = dt.Rows(i)("CHECK_NO")
    '                dgView.Item(10, i).Value = dt.Rows(i)("BATCH_NO")
    '                dgView.Item(11, i).Value = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE"))
    '                dgView.Item(12, i).Value = dt.Rows(i)("CHECK_REF")
    '                dgView.Item(13, i).Value = dt.Rows(i)("CHECK_NUMBER")
    '                dgView.Item(14, i).Value = dt.Rows(i)("CHECK_TYPE")
    '                dgView.Item(15, i).Value = dt.Rows(i)("CHECKTYPE_NAME")
    '                dgView.Item(16, i).Value = dt.Rows(i)("DEBIT_CREDIT")
    '                dgView.Item(17, i).Value = dt.Rows(i)("RTN_STATUS")
    '                dgView.Item(18, i).Value = dt.Rows(i)("RTN_CODE")
    '                dgView.Item(19, i).Value = dt.Rows(i)("RETURN_DATE")
    '                dgView.Item(20, i).Value = dt.Rows(i)("CHECKED")
    '                dgView.Item(21, i).Value = dt.Rows(i)("FLEX_FILENAME")
    '                dgView.Item(22, i).Value = dt.Rows(i)("IS_PDC")
    '                dgView.Item(23, i).Value = dt.Rows(i)("VALUE_TYPE")
    '                dgView.Item(24, i).Value = dt.Rows(i)("IS_ROW_CHG")


    '            Next
    '            dgView.AllowUserToAddRows = False

    '        End If


    '        ShowGridTotal()

    '        'dgView.AutoGenerateColumns = False
    '        'dgView.DataSource = ds
    '        'dgView.DataMember = ds.Tables(0).TableName

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub LoadDetailData(ByVal intMID As Integer, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetDetails")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@MID", DbType.String, intMID)
            db.AddInParameter(commProcSche, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)


            If dt.Rows.Count > 0 Then

                txtEntryLocation.Text = dt.Rows(0)("ENTRY_LOC").ToString()
                lblEntryLocation.Text = dt.Rows(0)("ENTRY_LOC_NAME").ToString()

                txtCustomerAcc.Text = dt.Rows(0)("REMARK").ToString()
                lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

            End If

            dgView.Rows.Clear()


            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    dgView.Item(0, i).Value = dt.Rows(i)("DSL")
                    dgView.Item(1, i).Value = dt.Rows(i)("BANK_CODE")
                    dgView.Item(2, i).Value = dt.Rows(i)("BANK_NAME")
                    dgView.Item(3, i).Value = dt.Rows(i)("NIKBRANCH_CODE")
                    dgView.Item(4, i).Value = dt.Rows(i)("BRANCH_NAME")
                    dgView.Item(5, i).Value = dt.Rows(i)("PAYEE_NAME")
                    dgView.Item(6, i).Value = dt.Rows(i)("ACC_NO")
                    dgView.Item(7, i).Value = dt.Rows(i)("CHECK_SERIES")
                    dgView.Item(8, i).Value = dt.Rows(i)("BOOK_NO")
                    dgView.Item(9, i).Value = dt.Rows(i)("CHECK_NO")
                    dgView.Item(10, i).Value = dt.Rows(i)("BATCH_NO")
                    dgView.Item(11, i).Value = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE"))
                    _issueDate(i) = NullHelper.DateToString(dt.Rows(i)("ISSUE_DATE")).ToString()
                    dgView.Item(12, i).Value = dt.Rows(i)("CHECK_REF")
                    dgView.Item(13, i).Value = dt.Rows(i)("CHECK_NUMBER")
                    _checkNo(i) = dt.Rows(i)("CHECK_NUMBER")
                    dgView.Item(14, i).Value = dt.Rows(i)("CHECK_TYPE")
                    dgView.Item(15, i).Value = dt.Rows(i)("CHECKTYPE_NAME")
                    dgView.Item(16, i).Value = dt.Rows(i)("DEBIT_CREDIT")
                    _amount(i) = dt.Rows(i)("DEBIT_CREDIT")
                    dgView.Item(17, i).Value = dt.Rows(i)("RTN_STATUS")
                    dgView.Item(18, i).Value = dt.Rows(i)("RTN_CODE")
                    dgView.Item(19, i).Value = dt.Rows(i)("RETURN_DATE")
                    dgView.Item(20, i).Value = dt.Rows(i)("CHECKED")
                    dgView.Item(21, i).Value = dt.Rows(i)("FLEX_FILENAME")
                    dgView.Item(22, i).Value = dt.Rows(i)("IS_PDC")
                    dgView.Item(23, i).Value = dt.Rows(i)("VALUE_TYPE")
                    dgView.Item(24, i).Value = dt.Rows(i)("IS_ROW_CHG")
                    dgView.Item(25, i).Value = dt.Rows(i)("GOV_CHQ")
                    dgView.Item(26, i).Value = dt.Rows(i)("IQA_FAILED")
                    dgView.Item(27, i).Value = dt.Rows(i)("ROUTING_NO")
                    dgView.Item(28, i).Value = dt.Rows(i)("AddCheckText").ToString()

                    
                Next
                dgView.AllowUserToAddRows = False

            End If


            ShowGridTotal()

            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub LoadDepositSlipData(ByVal strDSCode As String, ByVal dtOpr As Date, ByVal strLocCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_GetDetailByCode")

            commProc2.Parameters.Clear()

            db.AddInParameter(commProc2, "@DS_CODE", DbType.String, strDSCode)
            db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, dtOpr)
            db.AddInParameter(commProc2, "@ENTRY_LOC", DbType.String, strLocCode)

            Dim dt As DataTable = db.ExecuteDataSet(commProc2).Tables(0)

            If dt.Rows.Count > 0 Then
                LoadMainData(dt.Rows(0)("MID"), dt.Rows(0)("MOD_NO"))
            End If


            'If intModNo > 0 Then
            '    LoadMainData(strDSCode, dtOpr, strLocCode, intModNo)

            'End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckTotal_Remove")

        commProc.Parameters.Clear()


        db.AddInParameter(commProc, "@MID", DbType.Int32, _intMID)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Delete
            _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.UpdateNotPossible

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.UpdateNotPossible
        ElseIf result = 6 Then
            tStatus = TransState.AlreadyDeleted

        Else
            tStatus = TransState.UpdateNotPossible
        End If


        Return tStatus

    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal intMID As Integer, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _intMID = intMID

        _intModno = intmod

    End Sub

    Public Sub New(ByVal intMID As Integer, ByVal intDSL As Integer, ByVal intmod As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _intMID = intMID

        _intDSL = intDSL

        _intModno = intmod



    End Sub


    Private Sub LoadComboValues()

        'Dim dt1 As New DataTable()

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

    Private Sub SetEnableDisable()


        If chkAccNo.Checked = True Then
            txtAccNo.Enabled = True
        Else
            txtAccNo.Enabled = False
        End If



        If chkChqType.Checked = True Then
            txtCheckTypeCode.Enabled = True
            btnSearchCheckType.Enabled = True
        Else
            txtCheckTypeCode.Enabled = False
            btnSearchCheckType.Enabled = False
        End If


        If chkChqRef.Checked = True Then
            txtCheckRef.Enabled = True
        Else
            txtCheckRef.Enabled = False
        End If



        If chkBBK.Checked = True Then
            grpBBK.Enabled = True
        Else
            grpBBK.Enabled = False
        End If

    End Sub

    Private Sub LoadDataFromGrid(ByVal intDSL As Integer)

        For Each row As DataGridViewRow In dgView.Rows

            If NullHelper.ToIntNum(row.Cells(0).Value) = intDSL Then

                'dgView_CellDoubleClick(dgView, New DataGridViewCellEventArgs(0, row.Index))
                'dgView.Columns[0].Selected = true;
                dgView.Rows(row.Index).Selected = True
                dgView.FirstDisplayedScrollingRowIndex = row.Index
                Exit Sub
            End If


        Next

    End Sub
#End Region


    Private Sub FrmClearingDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        LoadComboValues()

        

        If _intModno > 0 Then
            LoadMainData(_intMID, _intModno)
            LoadDetailData(_intMID, _intModno)
        End If

        If _intDSL > 0 Then
            LoadDataFromGrid(_intDSL)
        End If


        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()

        'DisableClear()
        DisableRefresh()

        DisableFields()



    End Sub


    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click

        lblToolStatus.Text = ""

        EnableNew()
        If Not (_intMID = 0) Then

            If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then
                EnableFields()

                'EnableClear()
                EnableDelete()
                EnableNew()
                EnableRefresh()
                EnableSave()

            Else
                DisableAuth()
                'DisableClear()
                DisableDelete()
                DisableRefresh()
                DisableSave()

                DisableFields()
            End If

            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim.ToUpper() = CommonAppSet.User.ToUpper) Then
                EnableAuth()
            Else
                DisableAuth()
            End If

        Else

            DisableFields()

        End If

        DisableUnlock()

        If btnNew.Enabled = True Then
            btnNew.Focus()
        End If

        SetEnableDisable()



    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        lblToolStatus.Text = ""
        _formMode = FormTransMode.Add

        EnableSave()

        Dim strLocCode As String = txtEntryLocation.Text.Trim()
        Dim strLocName As String = lblEntryLocation.Text.Trim()

        Dim strCustAcc As String = txtCustomerAcc.Text.Trim()
        Dim strCustAccName As String = lblAccName.Text.Trim()

        ClearFieldsAll()

        

        txtEntryLocation.Text = strLocCode
        lblEntryLocation.Text = strLocName

        txtCustomerAcc.Text = strCustAcc
        lblAccName.Text = strCustAccName

        EnableFields()


        DisableRefresh()
        DisableDelete()

        'txtClearingDate.Text = Date.Today.ToString("dd/MM/yyyy")
        GetClearingDate()

        txtClearingDate.Focus()
        txtClearingDate.SelectAll()

        txtIssueDate.Text = Date.Today.ToString("dd/MM/yyyy")

        SetEnableDisable()

        If txtCustomerAcc.Text.Trim() <> "" Then
            txtCustomerAcc.Focus()
        End If




    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    If tState = TransState.Add Then

                        'LoadMainData(_intMID, _intModno)
                        'LoadDetailData(_intMID, _intModno)
                        btnNew_Click(sender, e)

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        '_formMode = FormTransMode.Update

                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()

                    ElseIf tState = TransState.Update Then

                        'LoadMainData(_intMID, _intModno)
                        'LoadDetailData(_intMID, _intModno)

                        btnNew_Click(sender, e)

                        lblToolStatus.Text = "!! Information Updated Successfully !!"

                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()




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

    

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        LoadMainData(_intMID, _intModno)
        LoadDetailData(_intMID, _intModno)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then


                    _formMode = FormTransMode.Add

                    LoadMainData(_intMID, _intModno)
                    LoadDetailData(_intMID, _intModno)

                    DisableAuth()

                    If _intmid=0 Then

                        DisableDelete()
                        DisableSave()
                        DisableRefresh()
                        DisableFields()



                    End If

                    lblToolStatus.Text = "!! Information Deleted Successfully !!"

                ElseIf tState = TransState.AlreadyDeleted Then
                    lblToolStatus.Text = "!! Failed. Data is already deleted !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Delete Not Possible !!"

                ElseIf tState = TransState.Exist Then
                    lblToolStatus.Text = "!! New Delete status insertion failed !!"

                ElseIf tState = TransState.NoRecord Then
                    lblToolStatus.Text = "!! Nothing to Delete !!"
                Else
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevVer.Click
        If _intModno - 1 > 0 Then

            LoadMainData(_intMID, _intModno - 1)
            LoadDetailData(_intMID, _intModno)

        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click


        Dim intMID As Integer = _intMID
      
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_intMID, _intModno + 1)

            If _intModno = 0 Then
                LoadMainData(intMID, intModno)
            End If

            LoadDetailData(_intMID, _intModno)
        End If

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadMainDataForAuth(_intMID)
                    LoadDetailDataForAuth(_intMID)
                End If

                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_intMID, _intModno)
                    LoadDetailData(_intMID, _intModno)

                    lblToolStatus.Text = "!! Authorized Successfully !!"
                    EnableUnlock()

                    DisableNew()
                    DisableSave()
                    DisableDelete()
                    DisableAuth()

                    'DisableClear()
                    DisableRefresh()

                    DisableFields()
                ElseIf tState = TransState.AlreadyAuthorized Then
                    lblToolStatus.Text = "!! Authorized Data cannot be authorized again !!"
                ElseIf tState = TransState.MakerCheckerSame Then
                    lblToolStatus.Text = "!! You cannot authorize the transaction !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Failed! Authorization Failed !!"
                ElseIf tState = TransState.ModifiedOutside Then
                    lblToolStatus.Text = "!! Failed! Data Mismatch. Reload, Check and Authorise again !!"
                ElseIf tState = TransState.DBError Then
                    lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                ElseIf tState = TransState.UnspecifiedError Then
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtEntryLocation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntryLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtEntryLocation.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Citibank Location List"
                frmList.ProcName = "CMS_CitiBankBranch_GetList"
                frmList.filter = New String(,) {{"BRANCH_NAME", "Location Name"}, {"BRANCH_CODE", "Location Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtEntryLocation.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblEntryLocation.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CitiBankBranch_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, txtEntryLocation.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblEntryLocation.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                    Else
                        txtEntryLocation.Clear()
                        lblEntryLocation.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtEntryLocation.Text.Trim() <> "" Then
                txtCustomerAcc.Focus()
                'SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLocation.Click

        Dim frmList As New FrmList()
        frmList.Text = "Citibank Location List"
        frmList.ProcName = "CMS_CitiBankBranch_GetList"
        frmList.filter = New String(,) {{"BRANCH_NAME", "Location Name"}, {"BRANCH_CODE", "Location Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtEntryLocation.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblEntryLocation.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

        If txtEntryLocation.Text.Trim() <> "" Then
            txtCustomerAcc.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCustomerAcc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerAcc.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtCustomerAcc.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Client List"
                frmList.ProcName = "CMS_ClearingClient_GetList"

                frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}}

                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "A/C No"}, {"1", "A/C Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtCustomerAcc.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblAccName.Text = frmList.RowResult.Cells(1).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtCustomerAcc.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then

                        lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

                    Else

                        txtCustomerAcc.Clear()

                        lblAccName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtCustomerAcc.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If

    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        Dim frmList As New FrmList()
        frmList.Text = "Client List"
        frmList.ProcName = "CMS_ClearingClient_GetList"

        frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}}

        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "A/C No"}, {"1", "A/C Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtCustomerAcc.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblAccName.Text = frmList.RowResult.Cells(1).Value.ToString()

        End If

        frmList.Dispose()


        If txtCustomerAcc.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub txtDepoCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoCode.KeyDown

        If e.KeyCode = Keys.Enter And txtDepoCode.Text.Trim() <> "" Then

            'If txtDepoCode.Text.Trim().Length < 7 Then
            '    MessageBox.Show("Not less than 7 digit", "Validation Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtDepoCode.Focus()
            '    Exit Sub
            'End If


            LoadDepositSlipData(txtDepoCode.Text.Trim(), NullHelper.StringToDate(txtClearingDate.Text), txtEntryLocation.Text.Trim())

            If _intModno > 0 Then
                'txtClearingDate.ReadOnly = True
                txtEntryLocation.ReadOnly = True
                btnSearchLocation.Enabled = False
                'txtDepoCode.ReadOnly = True
                LoadDetailData(_intMID, _intModno)
            Else


            End If

            SendKeys.Send("{tab}")

        End If

    End Sub

    Private Sub txtClearingDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClearingDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCustomerRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCheckAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalCheckAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBankCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBankCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBankCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank List"
                frmList.ProcName = "CMS_ClearingBank_GetList"
                frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblBankName.Text = frmList.RowResult.Cells(1).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBank_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                    Else
                        txtBankCode.Clear()
                        lblBankName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If

            If txtBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBank.Click
        Dim frmList As New FrmList()
        frmList.Text = "Bank List"
        frmList.ProcName = "CMS_ClearingBank_GetList"
        frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblBankName.Text = frmList.RowResult.Cells(1).Value.ToString()
            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()


    End Sub

    Private Sub txtBranchCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBranchCode.KeyDown

        If e.KeyCode = Keys.Enter Then
          
            If txtBranchCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Branch List"
                frmList.ProcName = "CMS_ClearingBranch_GetNikBranchListByBank"
                frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "NikBranch Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBranch_GetDetailByNikBranch")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                    Else
                        'txtRoutingNo.Clear()
                        'txtBankCode.Clear()
                        'lblBranchName.Text = ""
                        txtBranchCode.Clear()
                        lblBranchName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtBranchCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBranch.Click
        Dim frmList As New FrmList()
        frmList.Text = "Branch List"
        frmList.ProcName = "CMS_ClearingBranch_GetNikBranchListByBank"
        frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "NikBranch Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()
    End Sub

    Private Sub txtCheckSeries_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckSeries.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBookNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBookNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBatchNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBatchNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtIssueDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIssueDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckRef_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckTypeCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckTypeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCheckTypeCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Check Type List"
                frmList.ProcName = "CMS_CheckType_GetList"
                frmList.filter = New String(,) {{"CHECKTYPE_NAME", "CheckType Name"}, {"CHECKTYPE_CODE", "Type Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Check Type"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtCheckTypeCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblCheckTypeName.Text = frmList.RowResult.Cells(1).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CheckType_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@CHECKTYPE_CODE", DbType.String, txtCheckTypeCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblCheckTypeName.Text = dt.Rows(0)("CHECKTYPE_NAME").ToString()
                    Else
                        txtCheckTypeCode.Clear()
                        lblCheckTypeName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If

            If txtCheckTypeCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchCheckType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCheckType.Click
        Dim frmList As New FrmList()
        frmList.Text = "Check Type List"
        frmList.ProcName = "CMS_CheckType_GetList"
        frmList.filter = New String(,) {{"CHECKTYPE_NAME", "Type Name"}, {"CHECKTYPE_CODE", "Type Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Check Type"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtCheckTypeCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblCheckTypeName.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

        If txtCheckTypeCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAccNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub btnAddToGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToGrid.Click

        If txtCustomerAcc.Text.Trim() = "" Or lblAccName.Text.Trim() = "" Then

            MessageBox.Show("Customer A/C required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCustomerAcc.Focus()
            Exit Sub
        End If

        If txtRoutingNo.Text.Trim() = "" Then

            MessageBox.Show("Routing No required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRoutingNo.Focus()
            Exit Sub
        End If

        If txtBankCode.Text.Trim() = "" Or lblBankName.Text.Trim() = "" Then

            MessageBox.Show("Bank Code required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBankCode.Focus()
            Exit Sub
        End If

        If txtBranchCode.Text.Trim() = "" Or lblBranchName.Text.Trim() = "" Then

            MessageBox.Show("Branch Code required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBranchCode.Focus()
            Exit Sub
        End If

        If txtIssueDate.Text.Trim() = "/  /" Then

            MessageBox.Show("Issue date equired !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtIssueDate.Focus()
            Exit Sub
        End If

       

        If txtCheckNumber.Text.Trim() = "" Then
            MessageBox.Show("Check Number required !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNumber.Focus()
            Exit Sub
        End If

        If txtCheckNumber.Text.Trim().Length <> 7 Then
            MessageBox.Show("Check Number must be of 7 digit !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNumber.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtAmount.Text) = 0 Then
            MessageBox.Show("Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If

        If cmbValueType.SelectedIndex = -1 Then
            MessageBox.Show("Value type required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbValueType.Focus()
            Exit Sub
        End If

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingClient_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtCustomerAcc.Text.Trim())

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("SPEED_CR_TYPE").ToString().Trim() = "R" And txtCustomerRef.Text.Trim() = "" Then
                    MessageBox.Show("This client customer ref. cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCustomerRef.Focus()
                    Exit Sub

                End If

            Else

                MessageBox.Show("No client information found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ResetIsRowChangedValue()

        If _RowEditMode = True Then
            Dim selRow As Integer = lblRowNo.Text.Trim()

            dgView.Item(1, selRow).Value = txtBankCode.Text.Trim()
            dgView.Item(2, selRow).Value = lblBankName.Text
            dgView.Item(3, selRow).Value = txtBranchCode.Text.Trim()
            dgView.Item(4, selRow).Value = lblBranchName.Text
            dgView.Item(5, selRow).Value = lblAccName.Text.Trim()
            dgView.Item(6, selRow).Value = txtAccNo.Text.Trim()
            dgView.Item(7, selRow).Value = txtCheckSeries.Text.Trim()
            dgView.Item(8, selRow).Value = txtBookNo.Text.Trim()
            dgView.Item(9, selRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(10, selRow).Value = txtBatchNo.Text.Trim()
            dgView.Item(11, selRow).Value = txtIssueDate.Text
            dgView.Item(12, selRow).Value = txtCheckRef.Text.Trim()
            dgView.Item(13, selRow).Value = txtCheckNumber.Text.Trim()
            dgView.Item(14, selRow).Value = txtCheckTypeCode.Text.Trim()
            dgView.Item(15, selRow).Value = lblCheckTypeName.Text
            dgView.Item(16, selRow).Value = NullHelper.ToDecNum(txtAmount.Text.Trim())
            dgView.Item(23, selRow).Value = cmbValueType.SelectedValue
            dgView.Item(24, selRow).Value = True

            dgView.Item(25, selRow).Value = chkG2P.Checked
            dgView.Item(26, selRow).Value = chkIQA.Checked
            dgView.Item(27, selRow).Value = txtRoutingNo.Text.Trim()
            dgView.Item(28, selRow).Value = AddCheckText

            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(selRow).Selected = True

        Else

            Dim MaxSlNo As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                If MaxSlNo <= NullHelper.ToIntNum(row.Cells(0).Value) Then
                    MaxSlNo = NullHelper.ToIntNum(row.Cells(0).Value) + 1
                End If


            Next

            dgView.Rows.Add()

            Dim maxRow As Integer = dgView.Rows.Count - 1

            dgView.Item(0, maxRow).Value = MaxSlNo 'maxRow + 1
            dgView.Item(1, maxRow).Value = txtBankCode.Text.Trim()
            dgView.Item(2, maxRow).Value = lblBankName.Text
            dgView.Item(3, maxRow).Value = txtBranchCode.Text.Trim()
            dgView.Item(4, maxRow).Value = lblBranchName.Text
            dgView.Item(5, maxRow).Value = lblAccName.Text.Trim()
            dgView.Item(6, maxRow).Value = txtAccNo.Text.Trim()
            dgView.Item(7, maxRow).Value = txtCheckSeries.Text.Trim()
            dgView.Item(8, maxRow).Value = txtBookNo.Text.Trim()
            dgView.Item(9, maxRow).Value = txtCheckNo.Text.Trim()
            dgView.Item(10, maxRow).Value = txtBatchNo.Text.Trim()
            dgView.Item(11, maxRow).Value = txtIssueDate.Text
            dgView.Item(12, maxRow).Value = txtCheckRef.Text.Trim()
            dgView.Item(13, maxRow).Value = txtCheckNumber.Text.Trim()
            dgView.Item(14, maxRow).Value = txtCheckTypeCode.Text.Trim()
            dgView.Item(15, maxRow).Value = lblCheckTypeName.Text
            dgView.Item(16, maxRow).Value = NullHelper.ToDecNum(txtAmount.Text.Trim())
            dgView.Item(17, maxRow).Value = "O"
            dgView.Item(23, maxRow).Value = cmbValueType.SelectedValue
            dgView.Item(24, maxRow).Value = True

            dgView.Item(25, maxRow).Value = chkG2P.Checked
            dgView.Item(26, maxRow).Value = chkIQA.Checked
            dgView.Item(27, maxRow).Value = txtRoutingNo.Text.Trim()
            dgView.Item(28, maxRow).Value = AddCheckText


            dgView.Rows(0).Selected = True
            dgView.Rows(0).Selected = False
            dgView.Rows(maxRow).Selected = True

        End If

        ShowGridTotal()

        '--

        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        '---
        AddCheckText = ""
        txtRoutingNo.Clear()
        txtBankCode.Clear()
        lblBankName.Text = ""
        txtBranchCode.Clear()
        lblBranchName.Text = ""

        chkG2P.Checked = False
        chkIQA.Checked = False

        txtCheckSeries.Clear()
        txtBookNo.Clear()
        txtCheckNo.Clear()
        txtBatchNo.Clear()

        'txtIssueDate.Clear()
        txtCheckRef.Clear()
        chkPdc.Checked = False
        txtCheckNumber.Clear()
        txtCheckTypeCode.Clear()
        lblCheckTypeName.Text = ""

        txtAccNo.Clear()
        txtAmount.Text = "0"

        dgView.Enabled = True

        If dgView.Rows.Count = NullHelper.ToIntNum(txtTotalCheckNo.Text) Then
            btnSave.Focus()
        Else
            'txtBankCode.Focus()
            txtRoutingNo.Focus()
        End If





    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        _RowEditMode = False
        lblRowNo.Text = ""
        btnCancel.Visible = False
        btnRemoveFromGrid.Enabled = True
        btnAddToGrid.Text = "Add"

        txtRoutingNo.Clear()
        txtBankCode.Clear()
        lblBankName.Text = ""
        txtBranchCode.Clear()
        lblBranchName.Text = ""

        chkG2P.Checked = False
        chkIQA.Checked = False

        txtCheckSeries.Clear()
        txtBookNo.Clear()
        txtCheckNo.Clear()
        txtBatchNo.Clear()

        'txtIssueDate.Clear()
        txtCheckRef.Clear()
        chkPdc.Checked = False
        txtCheckNumber.Clear()
        txtCheckTypeCode.Clear()
        lblCheckTypeName.Text = ""

        txtAccNo.Clear()
        txtAmount.Text = "0"

        dgView.Enabled = True
    End Sub

    Private Sub btnRemoveFromGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromGrid.Click
        If dgView.SelectedRows.Count = 0 Then Exit Sub

        For Each row As DataGridViewRow In dgView.SelectedRows
            dgView.Rows.Remove(row)
        Next


        If _intModno = 0 Or (_intModno = 1 And chkAuthorized.Checked = False) Then

            Dim rowSlno As Integer = 1

            For Each row As DataGridViewRow In dgView.Rows
                row.Cells(0).Value = rowSlno
                rowSlno = rowSlno + 1
            Next

        End If

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick

        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _RowEditMode = True

            btnAddToGrid.Text = "Update"
            btnCancel.Visible = True
            btnRemoveFromGrid.Enabled = False


            lblRowNo.Text = e.RowIndex.ToString()
            txtRoutingNo.Text = NullHelper.ObjectToString(dgView.Item(27, e.RowIndex).Value)
            txtBankCode.Text = NullHelper.ObjectToString(dgView.Item(1, e.RowIndex).Value)
            lblBankName.Text = NullHelper.ObjectToString(dgView.Item(2, e.RowIndex).Value)
            txtBranchCode.Text = NullHelper.ObjectToString(dgView.Item(3, e.RowIndex).Value)
            lblBranchName.Text = NullHelper.ObjectToString(dgView.Item(4, e.RowIndex).Value)
            'lbla.Text = dgView.Item(4, e.RowIndex).Value
            txtAccNo.Text = dgView.Item(6, e.RowIndex).Value
            txtCheckSeries.Text = dgView.Item(7, e.RowIndex).Value
            txtBookNo.Text = dgView.Item(8, e.RowIndex).Value
            txtCheckNo.Text = dgView.Item(9, e.RowIndex).Value '
            txtBatchNo.Text = dgView.Item(10, e.RowIndex).Value
            txtIssueDate.Text = NullHelper.ObjectToString(dgView.Item(11, e.RowIndex).Value)
            txtCheckRef.Text = NullHelper.ObjectToString(dgView.Item(12, e.RowIndex).Value) '
            txtCheckNumber.Text = dgView.Item(13, e.RowIndex).Value
            txtCheckTypeCode.Text = dgView.Item(14, e.RowIndex).Value
            lblCheckTypeName.Text = NullHelper.ObjectToString(dgView.Item(15, e.RowIndex).Value)
            txtAmount.Text = dgView.Item(16, e.RowIndex).Value
            chkPdc.Checked = NullHelper.ToBool(dgView.Item(22, e.RowIndex).Value)
            cmbValueType.SelectedValue = dgView.Item(23, e.RowIndex).Value

            chkG2P.Checked = NullHelper.ToBool(dgView.Item(25, e.RowIndex).Value)
            chkIQA.Checked = NullHelper.ToBool(dgView.Item(26, e.RowIndex).Value)

            AddCheckText = dgView.Item(28, e.RowIndex).Value.ToString()

            dgView.Enabled = False


        End If
    End Sub


    Private Sub chkAccNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAccNo.CheckedChanged
        If chkAccNo.Checked = True Then
            txtAccNo.Enabled = True
        Else
            txtAccNo.Enabled = False
        End If
    End Sub

    Private Sub chkChqType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChqType.CheckedChanged
        If chkChqType.Checked = True Then
            txtCheckTypeCode.Enabled = True
            btnSearchCheckType.Enabled = True
        Else
            txtCheckTypeCode.Enabled = False
            btnSearchCheckType.Enabled = False
        End If
    End Sub

    Private Sub chkChqRef_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChqRef.CheckedChanged
        If chkChqRef.Checked = True Then
            txtCheckRef.Enabled = True
        Else
            txtCheckRef.Enabled = False
        End If
    End Sub

    Private Sub chkBBK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBBK.CheckedChanged
        If chkBBK.Checked = True Then
            grpBBK.Enabled = True
        Else
            grpBBK.Enabled = False
        End If
    End Sub

    Private Sub cmbValueType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbValueType.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddToGrid.Focus()
        End If
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If CommonUtil.DecValidate(txtAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtClearingDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClearingDate.Validating
        If CommonUtil.DateValidate(txtClearingDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtIssueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIssueDate.Validating
        If CommonUtil.DateValidate(txtIssueDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTotalCheckNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCheckNo.Validating
        If CommonUtil.IntValidate(txtTotalCheckNo.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTotalCheckAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalCheckAmount.Validating
        If CommonUtil.DecValidate(txtTotalCheckAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count) Then
            If NullHelper.ToBool(dgView.Rows(e.RowIndex).Cells(24).Value) = True Then

                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            Else
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub txtCheckNumber_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCheckNumber.Validated
        If txtCheckNumber.Text.Trim() <> "" Then
            txtCheckNumber.Text = txtCheckNumber.Text.Trim().PadLeft(7, "0")
        End If
    End Sub

    Private Sub chkG2P_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkG2P.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub chkIQA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkIQA.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtRoutingNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRoutingNo.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtRoutingNo.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank Branch List"
                frmList.ProcName = "CMS_ClearingBranch_GetRoutingBranchList"
                frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BANK_NAME", "Bank Name"}}
                frmList.colwidth = New Integer(,) {{0, 200}, {1, 100}, {2, 100}, {3, 200}}
                frmList.colrename = New String(,) {{"0", "Branch Name"}, {"1", "Nikash Code"}, {"2", "Routing"}, {"3", "Bank Name"}, {"4", "Bank Code"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtRoutingNo.Text = frmList.RowResult.Cells(2).Value.ToString()
                    txtBankCode.Text = frmList.RowResult.Cells(4).Value.ToString()
                    lblBankName.Text = frmList.RowResult.Cells(3).Value.ToString()
                    txtBranchCode.Text = frmList.RowResult.Cells(1).Value.ToString()
                    lblBranchName.Text = frmList.RowResult.Cells(0).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBranch_GetDetailByRouting")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@ROUTING_NO", DbType.String, txtRoutingNo.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        txtBankCode.Text = dt.Rows(0)("BANK_CODE").ToString()
                        lblBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                        txtBranchCode.Text = dt.Rows(0)("NIKBRANCH_CODE").ToString()
                        lblBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()

                    Else
                        txtRoutingNo.Clear()
                        txtBankCode.Clear()
                        lblBankName.Text = ""
                        txtBranchCode.Clear()
                        lblBranchName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If

            If txtRoutingNo.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If

    End Sub

    Private Sub btnSearchRouting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchRouting.Click

        Dim frmList As New FrmList()
        frmList.Text = "Bank Branch List"
        frmList.ProcName = "CMS_ClearingBranch_GetRoutingBranchList"
        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BANK_NAME", "Bank Name"}}
        frmList.colwidth = New Integer(,) {{0, 200}, {1, 100}, {2, 100}, {3, 200}}
        frmList.colrename = New String(,) {{"0", "Branch Name"}, {"1", "Nikash Code"}, {"2", "Routing"}, {"3", "Bank Name"}, {"4", "Bank Code"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtRoutingNo.Text = frmList.RowResult.Cells(2).Value.ToString()
            txtBankCode.Text = frmList.RowResult.Cells(4).Value.ToString()
            lblBankName.Text = frmList.RowResult.Cells(3).Value.ToString()
            txtBranchCode.Text = frmList.RowResult.Cells(1).Value.ToString()
            lblBranchName.Text = frmList.RowResult.Cells(0).Value.ToString()

        End If


        frmList.Dispose()

    End Sub

    Private Sub lblSlipInvoiceForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSlipInvoiceForm.Click
        Dim frmInvoice As New FrmInvoice
        frmInvoice.frmNm = "FrmClearingDetailSlip"
        frmInvoice.ShowDialog()
    End Sub

    Private Sub lblCheckInvoiceForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCheckInvoiceForm.Click
        Dim frmInvoice As New FrmInvoice
        frmInvoice.frmNm = "FrmClearingDetailCheck"
        frmInvoice.ShowDialog()
    End Sub
End Class