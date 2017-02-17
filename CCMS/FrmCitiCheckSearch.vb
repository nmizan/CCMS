Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmCitiCheckSearch

#Region "user defined codes"

    Dim _formName As String = "DepositCitiAnywhereSearch"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        'If cmbEntryLocation.SelectedIndex = -1 Then Exit Sub

        lblToolStatus.Text = ""

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetFilterData")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text.Trim())
            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())
            db.AddInParameter(commProc, "@DLOCATION_CODE", DbType.String, txtDLocationCode.Text.Trim())
            db.AddInParameter(commProc, "@SLIP_DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtSlipDateFrom.Text.Trim))
            db.AddInParameter(commProc, "@SLIP_DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtSlipDateTo.Text.Trim))
            db.AddInParameter(commProc, "@VALUE_DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtValueDateFrom.Text.Trim))
            db.AddInParameter(commProc, "@VALUE_DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtValueDateTo.Text.Trim))
            db.AddInParameter(commProc, "@CHECK_NO", DbType.String, txtCheckNumber.Text.Trim())
            db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(txtAmount.Text.Trim()))
            db.AddInParameter(commProc, "@DRAWEE_BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
            db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, txtDraweeBranchCode.Text.Trim())
            db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, txtCitiBankRef.Text.Trim())


            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()
            ',,,,,
            ',,,,,,
            ', , 
            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(0, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("D_CODE"))
                dgView.Item(1, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CLIENT_CODE"))
                dgView.Item(2, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("ACC_NO"))
                dgView.Item(3, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("ACC_NAME"))
                dgView.Item(4, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("LOCATION_NAME"))
                dgView.Item(5, i).Value = NullHelper.DateToString(dt.Rows(i).Item("SLIP_DATE"))
                dgView.Item(6, i).Value = NullHelper.DateToString(dt.Rows(i).Item("VALUE_DATE"))
                dgView.Item(7, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CHECK_NO"))
                dgView.Item(8, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("AMOUNT"))
                dgView.Item(9, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CHECK_TYPE"))
                dgView.Item(10, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DRAWER"))
                dgView.Item(11, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("BANK_NAME"))
                dgView.Item(12, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("BRANCH_NAME"))
                dgView.Item(13, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("NONZONE_REF"))
                dgView.Item(14, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("RTN_STATUS"))


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
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

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




    Private Sub txtDLocationCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDLocationCode.Validated
        If txtDLocationCode.Text.Trim() = "" Then

            lblDLocationName.Text = ""
        End If
    End Sub

    Private Sub txtDLocationCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDLocationCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtDLocationCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Location List"
                frmList.ProcName = "CMS_Location_GetList"
                frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtDLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblDLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtDLocationCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblDLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                    Else
                        txtDLocationCode.Clear()
                        lblDLocationName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDLocationCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
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
                    lblAccName.Text = "[" + frmList.RowResult.Cells(1).Value.ToString() + "] " _
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
                'SendKeys.Send("{tab}")
            End If

        End If

    End Sub

    Private Sub txtClientCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClientCode.Validated
        If txtClientCode.Text.Trim() = "" Then

            lblAccName.Text = ""
        End If
    End Sub

    Private Sub txtBankCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBankCode.KeyDown
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

                    txtDraweeBranchCode.Clear()
                    lblDraweeBranchName.Text = ""
                   
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

                        txtDraweeBranchCode.Clear()
                        lblDraweeBranchName.Text = ""
                      

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            If txtDraweeBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
        End If
    End Sub

    Private Sub txtDraweeBranchCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeBranchCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtDraweeBranchCode.Text.Trim() = "" Then

                If txtDraweeBankCode.Text.Trim() <> "" Then

                    Dim frmList As New FrmList()
                    frmList.Text = "Branch List"
                    frmList.ProcName = "CMS_Branch_GetListByBank"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtDraweeBankCode.Text.Trim())
                    frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtDraweeBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblDraweeBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()

                End If

            End If

            If txtDraweeBranchCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                'SendKeys.Send("{tab}")
            End If
        End If

    End Sub
End Class