Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmRptClearingCheckHistOld

#Region "user defined codes"

    Dim _formName As String = "ReportHistoryClearingCheckDetailOld"
    Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        If cmbEntryLocation.SelectedIndex = -1 Then Exit Sub


        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_OldCheckTotal_GetFilterData")

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
                dgView.Item(0, i).Value = NullHelper.DateToString(dt.Rows(i).Item("OPRDATE"))
                dgView.Item(1, i).Value = NullHelper.DateToString(dt.Rows(i).Item("ISSUEDATE"))
                dgView.Item(2, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("REMARK"))
                dgView.Item(3, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("ACC_NAME"))
                dgView.Item(4, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("DS_CODE"))
                dgView.Item(5, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("BANK_NAME"))
                dgView.Item(6, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("NIKBRANCH_NAME"))
                dgView.Item(7, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("CHQNUMBER"))
                dgView.Item(8, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("debtcredit"))
                dgView.Item(9, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("status"))
                dgView.Item(10, i).Value = NullHelper.DateToString(dt.Rows(i).Item("Returndate"))
                dgView.Item(11, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("entrylocname"))
                dgView.Item(12, i).Value = NullHelper.ObjectToString(dt.Rows(i).Item("reject_reason"))

            Next

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
        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Entry location required!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub

        End If
        LoadDataGrid()
    End Sub

    
End Class