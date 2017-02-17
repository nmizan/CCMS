Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmClearingReturnDet


#Region "Global Variables"

    Dim _formName As String = "ClearingCheckReturnDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    
    Dim _intMID As Integer = 0
    Dim _intDSL As Integer = 0

    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String = ""

    Dim _IsMultiRecord As Boolean = False
    'Dim _RowEditMode As Boolean = False

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



    Private Sub DisableFields()



        txtClearingDate.ReadOnly = True
        

        txtCheckNumber.ReadOnly = True

        txtAmount.ReadOnly = True
        txtSeqNo.ReadOnly = True
        txtReturnCode.ReadOnly = True


        btnGetCheck.Enabled = False



        dgView.Enabled = False

        'dgView.ReadOnly = True



    End Sub

    Private Sub EnableFields()

        txtClearingDate.ReadOnly = False
        

        txtCheckNumber.ReadOnly = False

        txtAmount.ReadOnly = False
        txtSeqNo.ReadOnly = False
        txtReturnCode.ReadOnly = False


        btnGetCheck.Enabled = True

        dgView.Enabled = True

    End Sub


    Private Sub ClearFieldsAll()


        txtClearingDate.Clear()
      

        txtCheckNumber.Clear()

        txtAmount.Clear()
        txtSeqNo.Clear()
        txtReturnCode.Clear()
        lblReason.Text = ""

        lblBankBranch.Text = ""

        dgView.AllowUserToAddRows = False

        dgView.DataSource = Nothing
        dgView.Rows.Clear()


        _intMID = 0
        _intDSL = 0
        _IsMultiRecord = False



        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""



    End Sub

    Private Function GetClearingCheck() As Boolean

        Dim flagFound As Boolean = False


        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetReturnMatch")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CHECK_NUMBER", DbType.String, txtCheckNumber.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtAmount.Text))
            db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text))

            dt = db.ExecuteDataSet(commProc).Tables(0)

            dgView.Rows.Clear()


            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If


                    dgView.Item(0, i).Value = dt.Rows(i)("BANK_NAME")
                    dgView.Item(1, i).Value = dt.Rows(i)("BRANCH_NAME")
                    dgView.Item(2, i).Value = dt.Rows(i)("PAYEE_NAME")
                    dgView.Item(3, i).Value = NullHelper.DateToString(dt.Rows(i)("OPR_DATE"))
                    dgView.Item(4, i).Value = dt.Rows(i)("CHECK_NUMBER")
                    dgView.Item(5, i).Value = dt.Rows(i)("DEBIT_CREDIT")
                    dgView.Item(6, i).Value = dt.Rows(i)("RTN_STATUS")
                    dgView.Item(7, i).Value = dt.Rows(i)("MID")
                    dgView.Item(8, i).Value = dt.Rows(i)("DSL")



                Next
                dgView.AllowUserToAddRows = False

                flagFound = True

            End If

            If dt.Rows.Count = 1 Then
                lblBankBranch.Text = NullHelper.ObjectToString(dt.Rows(0)("BANK_NAME")) & _
                " (" & NullHelper.ObjectToString(dt.Rows(0)("BRANCH_NAME")) & ")"
            End If

            If dt.Rows.Count > 1 Then
                _IsMultiRecord = True
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try






        Return flagFound

    End Function



    Private Function SaveData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _IsMultiRecord = True Then

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnClearing_AddDup")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@MID", DbType.Int32, _intMID)
            db.AddInParameter(commProc, "@DSL", DbType.Int32, _intDSL)
            db.AddInParameter(commProc, "@CHECK_NUMBER", DbType.String, txtCheckNumber.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtAmount.Text))
            db.AddInParameter(commProc, "@RTN_CODE", DbType.String, txtReturnCode.Text.Trim())
            db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text))
            db.AddInParameter(commProc, "@SEQ_NUMBER", DbType.String, txtSeqNo.Text.Trim())


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then

                tStatus = TransState.Add

                log_message = " Added : Return Check : " + " " + txtCheckNumber.Text.Trim()
                Logger.system_log(log_message)

            ElseIf result = 1 Then

                tStatus = TransState.UpdateNotPossible
            ElseIf result = 2 Then
                tStatus = TransState.Exist

            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            Else
                tStatus = TransState.UpdateNotPossible
            End If


        Else

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnClearing_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CHECK_NUMBER", DbType.String, txtCheckNumber.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtAmount.Text))
            db.AddInParameter(commProc, "@RTN_CODE", DbType.String, txtReturnCode.Text.Trim())
            db.AddInParameter(commProc, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text))
            db.AddInParameter(commProc, "@SEQ_NUMBER", DbType.String, txtSeqNo.Text.Trim())
            db.AddOutParameter(commProc, "@RET_MID", DbType.Int32, 10)
            db.AddOutParameter(commProc, "@RET_DSL", DbType.Int32, 4)


            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result = 0 Then

                tStatus = TransState.Add

                log_message = " Added : Return Check : " + " " + txtCheckNumber.Text.Trim()
                Logger.system_log(log_message)

            ElseIf result = 1 Then

                tStatus = TransState.UpdateNotPossible
            ElseIf result = 2 Then
                tStatus = TransState.Exist

            ElseIf result = 4 Then
                tStatus = TransState.NoRecord

            Else
                tStatus = TransState.UpdateNotPossible
            End If

        End If


        Return tStatus

    End Function


    Private Sub LoadMainData(ByVal intMID As Integer, ByVal intDSL As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnClearing_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@MID", DbType.Int32, intMID)
            db.AddInParameter(commProc, "@DSL", DbType.Int32, intDSL)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _intMID = intMID

                _intDSL = intDSL

                _formMode = FormTransMode.Update

                txtClearingDate.Text = NullHelper.DateToString(dt.Rows(0)("OPR_DATE"))
                
                txtCheckNumber.Text = dt.Rows(0)("CHECK_NUMBER").ToString()
                txtAmount.Text = dt.Rows(0)("AMOUNT").ToString()
                txtSeqNo.Text = dt.Rows(0)("SEQ_NUMBER").ToString()
                txtReturnCode.Text = dt.Rows(0)("RTN_CODE").ToString()
                lblReason.Text = dt.Rows(0)("REJECT_REASON").ToString()

                lblInputBy.Text = dt.Rows(0)("INPUT_BY").ToString()
                lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME").ToString()

                lblAuthBy.Text = dt.Rows(0)("AUTH_BY").ToString()
                lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME").ToString()

                If dt.Rows(0)("STATUS") = "L" Then
                    chkAuthorized.Checked = True
                Else
                    chkAuthorized.Checked = False
                End If


                _status = dt.Rows(0)("STATUS")


                If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then


                    If btnUnlock.Enabled = False Then
                        EnableFields()

                        EnableDelete()
                        EnableNew()

                        EnableSave()

                    End If
                Else
                    DisableAuth()

                    DisableDelete()

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


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnClearing_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@MID", DbType.Int32, _intMID)
        db.AddInParameter(commProc, "@DSL", DbType.Int32, _intDSL)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Delete


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



    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnClearing_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@MID", DbType.Int32, _intMID)
        db.AddInParameter(commProc, "@DSL", DbType.Int32, _intDSL)


        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            log_message = " Authorized : Clearing Return Check : " + " " + txtCheckNumber.Text.Trim()
            Logger.system_log(log_message)

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






#End Region


    Private Sub FrmClearingReturnDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _intMID > 0 Then
            LoadMainData(_intMID, _intDSL)

        End If

        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()

        DisableFields()

    End Sub


    Private Sub btnGetCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCheck.Click

        If txtClearingDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Return date required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClearingDate.Focus()
            Exit Sub
        End If


        If txtCheckNumber.Text.Trim() = "" Then
            MessageBox.Show("Check number required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNumber.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtAmount.Text) = 0 Then
            MessageBox.Show("Amount required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If

        If GetClearingCheck() = True Then

            If _IsMultiRecord = False Then
                EnableSave()

            Else
                MessageBox.Show("Multiple record found." + Environment.NewLine + _
                                "Select from the grid below", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)



            End If

            btnGetCheck.Enabled = False
            txtClearingDate.ReadOnly = True
            txtCheckNumber.ReadOnly = True
            txtAmount.ReadOnly = True

        Else
            MessageBox.Show("No check found!!", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub

        End If


    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click

        lblToolStatus.Text = ""

        EnableNew()



        If Not (_intMID = 0) Then
            EnableNew()
            EnableDelete()

            'If _status = "L" Or _status = "U" _
            '        Or (_status = "D" And chkAuthorized.Checked = False) Then
            '    EnableFields()


            '    EnableDelete()
            '    EnableNew()



            'Else
            '    DisableAuth()

            '    DisableDelete()



            '    DisableFields()
            'End If

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





    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        lblToolStatus.Text = ""
        _formMode = FormTransMode.Add

        DisableSave()

        ClearFieldsAll()
        EnableFields()



        DisableDelete()

        txtClearingDate.Focus()



    End Sub

    Private Sub txtReturnDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClearingDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCheckNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtReturnCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnCode.KeyDown

        If e.KeyCode = Keys.Enter And txtReturnCode.Text.Trim() <> "" Then


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable
            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingReturnReject_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, txtReturnCode.Text)

            dt = db.ExecuteDataSet(commProc).Tables(0)
            If dt.Rows.Count > 0 Then

                txtReturnCode.Text = dt.Rows(0)("REJECT_CODE")
                lblReason.Text = dt.Rows(0)("REJECT_REASON")

            Else
                MessageBox.Show("Invalid Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtReturnCode.Clear()
                lblReason.Text = ""
                txtReturnCode.Focus()

            End If


            If txtReturnCode.Text.Trim() <> "" Then
                btnSave.Focus()
            End If


        End If


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtClearingDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Return date required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClearingDate.Focus()
            Exit Sub
        End If

        

        If txtCheckNumber.Text.Trim() = "" Then
            MessageBox.Show("Check number required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNumber.Focus()
            Exit Sub
        End If

        If NullHelper.ToDecNum(txtAmount.Text) = 0 Then
            MessageBox.Show("Amount required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.Focus()
            Exit Sub
        End If

        If txtReturnCode.Text.Trim() = "" Or lblReason.Text.Trim() = "" Then
            MessageBox.Show("Return code required!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReturnCode.Focus()
            Exit Sub
        End If

        If _IsMultiRecord = True Then

            If _intMID = 0 Or _intDSL = 0 Or lblBankBranch.Text.Trim() = "" Then

                MessageBox.Show("Check is not properly selected!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

        End If

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Return Check?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = SaveData()

                If tState = TransState.Add Then

                    Dim intMID As Integer = _intMID
                    Dim intDSL As Integer = _intDSL

                    ClearFieldsAll()

                    LoadMainData(intMID, intDSL)
                    'LoadDetailData(_intMID, _intModno)

                    lblToolStatus.Text = "!! Information Added Successfully !!"


                    '_formMode = FormTransMode.Update

                    'EnableUnlock()
                    'DisableNew()
                    DisableSave()
                    'DisableDelete()
                    DisableAuth()
                    DisableFields()


                    'DisableClear()
                    'DisableRefresh()
                    'DisableFields()


                ElseIf tState = TransState.Exist Then
                    lblToolStatus.Text = "!! Already Exist !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Update Not Possible !!"
                ElseIf tState = TransState.NoRecord Then
                    lblToolStatus.Text = "!! Nothing to Update !!"
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

    Private Sub txtReturnDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClearingDate.Validating
        If CommonUtil.DateValidate(txtClearingDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If CommonUtil.DecValidate(txtAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal intMID As Integer, ByVal intDSL As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _intMID = intMID
        _intDSL = intDSL

    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                tState = AuthorizeData()

                If tState = TransState.Update Then

                    LoadMainData(_intMID, _intDSL)


                    lblToolStatus.Text = "!! Authorized Successfully !!"
                    EnableUnlock()

                    DisableNew()
                    DisableSave()
                    DisableDelete()
                    DisableAuth()


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

    Private Sub txtSeqNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSeqNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

   
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then

                    ClearFieldsAll()
                    DisableFields()
                    DisableAuth()


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

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick

        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            _intMID = NullHelper.ToIntNum(dgView.Item(7, e.RowIndex).Value)
            _intDSL = NullHelper.ToIntNum(dgView.Item(8, e.RowIndex).Value)

            'EnableSave()

            lblBankBranch.Text = "" & dgView.Item(0, e.RowIndex).Value.ToString() & _
                " (" & dgView.Item(1, e.RowIndex).Value.ToString() & ")"


            btnSave.Enabled = True

        End If

    End Sub

    Private Sub txtSeqNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeqNo.TextChanged

    End Sub
End Class