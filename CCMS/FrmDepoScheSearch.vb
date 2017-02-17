Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmDepoScheSearch

#Region "user defined codes"

    Dim _formName As String = "DepositScheduleSearch"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        'If cmbEntryLocation.SelectedIndex = -1 Then Exit Sub

        lblToolStatus.Text = ""

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DSchedule_GetFilterData")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@SCHEDULE_DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtScheDateFrom.Text.Trim))
            db.AddInParameter(commProc, "@SCHEDULE_DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtScheDateTo.Text.Trim))
            db.AddInParameter(commProc, "@DS_CODE", DbType.String, txtDepoScheCode.Text.Trim())
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
            db.AddInParameter(commProc, "@CORR_BANK_CODE", DbType.String, txtCorrBankCode.Text.Trim())
            db.AddInParameter(commProc, "@REF_NO", DbType.String, txtRef.Text.Trim())
            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
            db.AddInParameter(commProc, "@DEPOSIT_TYPE", DbType.String, cmbDepositType.Text.Trim())
            db.AddInParameter(commProc, "@CITICASH_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtCitiCashAmt.Text.Trim()))
            db.AddInParameter(commProc, "@CITICHECK_AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtCitiCheckAmt.Text.Trim()))
            db.AddInParameter(commProc, "@IS_SEARCH_SPEED", SqlDbType.Bit, chkCitiSpeed.Checked)
            db.AddInParameter(commProc, "@DRAWEE_BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
            db.AddInParameter(commProc, "@CHECK_NO", DbType.String, txtCheckNumber.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtAmount.Text.Trim()))


            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()
            
            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = NullHelper.DateToString(dt.Rows(i).Item("SCHEDULE_DATE"))
                dgView.Item(1, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DS_CODE"))
                dgView.Item(2, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("D_CODE"))
                dgView.Item(3, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CLIENT_CODE"))
                dgView.Item(4, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("ACC_NO"))
                dgView.Item(5, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("ACC_NAME"))
                dgView.Item(6, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("LOCATION_NAME"))
                dgView.Item(7, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("BANK_NAME")) '
                dgView.Item(8, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DEPOSIT_TYPE")) '
                dgView.Item(9, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CITICASH_AMOUNT"))
                dgView.Item(10, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CITICHECK_AMOUNT"))
                dgView.Item(11, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("REF_NO"))
                If chkCitiSpeed.Checked = True Then
                    dgView.Item(12, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DRAWEE_BANK_NAME"))
                    dgView.Item(13, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CHECK_NO"))
                    dgView.Item(14, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("AMOUNT"))
                    dgView.Item(15, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("REJECT_REASON"))
                End If
                


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




  

    Private Sub chkCitiSpeed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCitiSpeed.CheckedChanged
        If chkCitiSpeed.Checked = True Then
            grpSpeed.Enabled = True

            dgView.Columns(12).Visible = True
            dgView.Columns(13).Visible = True
            dgView.Columns(14).Visible = True
            dgView.Columns(15).Visible = True

        Else
            grpSpeed.Enabled = False

            dgView.Columns(12).Visible = False
            dgView.Columns(13).Visible = False
            dgView.Columns(14).Visible = False
            dgView.Columns(15).Visible = False

        End If
    End Sub

    Private Sub FrmDepoScheSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        chkCitiSpeed_CheckedChanged(sender, e)

    End Sub

    Private Sub txtRef_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRef.Validating
        Try

            If txtRef.Text.Trim() <> "" And IsNumeric(txtRef.Text.Trim()) Then
                txtRef.Text = txtRef.Text.Trim().PadLeft(10, "0")
            End If

        Catch ex As Exception
            txtRef.Text = ""
        End Try
    End Sub

    Private Sub txtLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtLocationCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Location List"
                frmList.ProcName = "CMS_Location_GetList"
                frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                    Else
                        txtLocationCode.Clear()
                        lblLocationName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtLocationCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLocation.Click

        Dim frmList As New FrmList()
        frmList.Text = "Location List"
        frmList.ProcName = "CMS_Location_GetList"
        frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

        If txtLocationCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub btnSearchCorrBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCorrBank.Click
        Dim frmList As New FrmList()
        frmList.Text = "Corr. Bank Branch List"
        frmList.ProcName = "CMS_Branch_GetCorrBranchListByLoc"

        frmList.AddParamToDB("@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}, {"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
        frmList.colwidth = New Integer(,) {{1, 150}, {3, 150}}
        frmList.colrename = New String(,) {{"0", "Branch Code"}, {"1", "Branch Name"}, {"2", "Bank Code"}, {"3", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtCorrBankCode.Text = frmList.RowResult.Cells(2).Value.ToString()
            lblCorrBankName.Text = frmList.RowResult.Cells(3).Value.ToString()

        End If

        frmList.Dispose()

        If txtCorrBankCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        Dim frmList As New FrmList()
        frmList.Text = "Client List"
        frmList.ProcName = "CMS_Client_GetList"

        frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}, {"CLIENT_CODE", "Code"}}

        frmList.colwidth = New Integer(,) {{1, 150}, {2, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "A/C No"}, {"2", "A/C Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtClientCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblAccName.Text = "[" + frmList.RowResult.Cells(1).Value.ToString() + "]" _
                + frmList.RowResult.Cells(2).Value.ToString()

        End If

        frmList.Dispose()


        If txtClientCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtClientCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtClientCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Client List"
                frmList.ProcName = "CMS_Client_GetList"

                frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}, {"CLIENT_CODE", "Code"}}

                frmList.colwidth = New Integer(,) {{1, 150}, {2, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "A/C No"}, {"2", "A/C Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtClientCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblAccName.Text = "[" + frmList.RowResult.Cells(1).Value.ToString() + "]" _
                        + frmList.RowResult.Cells(2).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then

                        lblAccName.Text = "[" + dt.Rows(0)("ACC_NO").ToString() + "] " _
                        + dt.Rows(0)("ACC_NAME").ToString()

                    Else

                        txtClientCode.Clear()

                        lblAccName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtClientCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchDraweeBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDraweeBank.Click

        Dim frmList As New FrmList()
        frmList.Text = "Bank List"
        frmList.ProcName = "CMS_Bank_GetList"

        frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}

        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtDraweeBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblDraweeBankName.Text = frmList.RowResult.Cells(1).Value.ToString()
        End If

        frmList.Dispose()

        If txtDraweeBankCode.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub txtDraweeBankCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBankCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDraweeBankCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank List"
                frmList.ProcName = "CMS_Bank_GetList"
                frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtDraweeBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblDraweeBankName.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try



                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblDraweeBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                    Else
                        txtDraweeBankCode.Clear()
                        lblDraweeBankName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDraweeBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If
        End If
    End Sub
End Class