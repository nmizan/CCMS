Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClearingSearch

#Region "user defined codes"

    Dim _formName As String = "ClearingCheckSearch"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        'If cmbEntryLocation.SelectedIndex = -1 Then Exit Sub

        lblToolStatus.Text = ""

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingTab_GetFilterData")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)
            db.AddInParameter(commProc, "@OPR_DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtClearingDateFrom.Text.Trim))
            db.AddInParameter(commProc, "@OPR_DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtClearingDateTo.Text.Trim))
            db.AddInParameter(commProc, "@REMARK", DbType.String, txtCustomerAcc.Text.Trim())
            db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDepoCode.Text.Trim())
            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
            db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())
            db.AddInParameter(commProc, "@CHECK_NUMBER", DbType.String, txtCheckNumber.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtAmount.Text.Trim()))


            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = NullHelper.DateToString(dt.Rows(i).Item("OPR_DATE"))
                dgView.Item(1, i).Value = NullHelper.DateToString(dt.Rows(i).Item("ISSUE_DATE"))
                dgView.Item(2, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("REMARK"))
                dgView.Item(3, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("PAYEE_NAME"))
                dgView.Item(4, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DS_CODE"))
                dgView.Item(5, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("BANK_NAME"))
                dgView.Item(6, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("BRANCH_NAME"))
                dgView.Item(7, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CHECK_NUMBER"))
                dgView.Item(8, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DEBIT_CREDIT"))
                dgView.Item(9, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("STATUS"))
                dgView.Item(10, i).Value = NullHelper.DateToString(dt.Rows(i).Item("RETURN_DATE"))
                dgView.Item(11, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("ENTRY_LOC_NAME"))
                dgView.Item(12, i).Value = dt.Rows(i).Item("MID")
                dgView.Item(13, i).Value = dt.Rows(i).Item("DSL")
                dgView.Item(14, i).Value = dt.Rows(i).Item("MOD_NO")

            Next

            lblToolStatus.Text = "Record(s): " + dt.Rows.Count.ToString()


        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub


    Private Sub FrmBankSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        'dtpEntryDate.Value = DateTime.Today

        'Dim i As Integer
        'For i = 1 To dgView.Columns.Count - 1
        '    dgView.Columns(i).ReadOnly = True
        'Next

        'If rdoUnauthorized.Checked = True Then
        '    chkAll.Visible = True
        '    If dgView.Columns.Count > 0 Then
        '        dgView.Columns(0).Visible = True
        '    End If
        'End If

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

    End Sub


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'If cmbEntryLocation.SelectedIndex = -1 Then
        '    MessageBox.Show("Entry location required!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbEntryLocation.Focus()
        '    Exit Sub

        'End If
        LoadDataGrid()
    End Sub


    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            Dim frmClearDet As New FrmClearingDetail(dgView.SelectedRows.Item(0).Cells(12).Value, dgView.SelectedRows.Item(0).Cells(13).Value, dgView.SelectedRows.Item(0).Cells(14).Value)
            frmClearDet.Show()
        End If
    End Sub

    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint

        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If dgView.Rows(e.RowIndex).Cells(9).Value.ToString() = "U" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
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
                frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "NikBranch Code"}, {"ROUTING_NO", "Routing No"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}, {"2", "Routing Name"}}
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
        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "NikBranch Code"}, {"ROUTING_NO", "Routing No"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}, {"2", "Routing Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()

    End Sub
End Class