'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : CitiCash Summary
'Creation date      : 
'Stored Procedure(s):  
'

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmCitiCashSumm

#Region "user defined codes"

    Dim _formName As String = "DepositCitiCashSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String
    Dim _strId As String = ""

    'For Update
    Dim _slipDate As String = ""
    Dim _cashRef As String = ""
    Dim _custRef As String = ""

    'For Auth
    Dim _aslipDate As String = ""
    Dim _acashRef As String = ""
    Dim _acustRef As String = ""

    Dim CitiCashList As New List(Of String)
    Dim _cashLog As String = ""
    Dim _log As String = ""

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

    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetDetailList")

            commProc.Parameters.Clear()

            If chkShowAll.Checked = True Then
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            End If

            If rdoAuthorized.Checked = True Then
                db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)
            End If

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("S").ToString()

                dgView.Item(3, i).Value = dt.Rows(i).Item("D_CODE").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("CUSTOMER_REF").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("CASH_REF").ToString()
                dgView.Item(6, i).Value = NullHelper.DateToString(dt.Rows(i).Item("SLIP_DATE").ToString())
                dgView.Item(7, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(8, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(9, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(10, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(11, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub



    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try


            If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing) Then

                Dim frmCashDet As New FrmCitiCashDetail(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmCashDet.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmCashDet As New FrmCitiCashDetail
        frmCashDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmCashDet As New FrmCitiCashDetail(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmCashDet.Show()
        End If
    End Sub






    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count) Then
            If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

                'ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                '    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        End If
    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadDepositCashDataForAuth(ByVal strDCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From CCASH Where D_CODE ='" & strDCode & "'  and STATUS='L'").Tables(0)

            If dt.Rows.Count > 0 Then

                _aslipDate = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE")).ToString

                _acustRef = dt.Rows(0)("CUSTOMER_REF").ToString()

                _acashRef = dt.Rows(0)("CASH_REF").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadDepositCashData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

              
                _slipDate = NullHelper.DateToString(dt.Rows(0)("SLIP_DATE")).ToString

                _custRef = dt.Rows(0)("CUSTOMER_REF").ToString()

                _cashRef = dt.Rows(0)("CASH_REF").ToString()

                LoadDepositCashBearerInfoData(strDCode, intMod)

              
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (06-June-2016)------------
    Private Sub LoadDepositCashBearerInfoData(ByVal strDCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bearer_Info_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, strDCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                _strId = dt.Rows(0)("PERSON_ID").ToString()
               
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Try

            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim i As Integer

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCash_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (22-05-2016)------------
                        LoadDepositCashData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                        If (dgView.Rows(i).Cells(1).Value) > 1 Then
                            LoadDepositCashDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                        End If
                        '------------Mizan Work (22-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@D_CODE", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@PERSON_ID", DbType.String, _strId) '-----------Added By Mizan(06-June-2016)----
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(9).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (22-05-2016)------------
                            If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                If _aslipDate <> _slipDate Then
                                    log_message = " Slip Date : " + _aslipDate + " " + " To " + " " + _slipDate + "." + " "
                                    CitiCashList.Add(log_message)
                                End If

                                If _acashRef <> _cashRef Then
                                    log_message = " Cash Ref. : " + _acashRef + " " + " To " + " " + _cashRef + "." + " "
                                    CitiCashList.Add(log_message)
                                End If
                                If _acustRef <> _custRef Then
                                    log_message = " Customer Ref. : " + _acustRef + " " + " To " + " " + _custRef + "." + " "
                                    CitiCashList.Add(log_message)
                                End If

                                For Each cashInfo As String In CitiCashList
                                    _cashLog += cashInfo
                                Next
                                _log = " Authorized : Citi Cash Deposit Code : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _cashLog

                                Logger.system_log(_log)

                                _cashLog = ""
                                CitiCashList.Clear()

                            Else

                                _log = " Authorized : Citi Cash Deposit Code : " + dgView.Rows(i).Cells(3).Value.ToString()
                                Logger.system_log(_log)

                            End If
                            '------------Mizan Work (22-05-2016)------------

                        ElseIf result = 1 Then

                            MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 3 Then
                            MessageBox.Show("Already authorized", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 4 Then
                            MessageBox.Show("Record not found", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 5 Then
                            MessageBox.Show("You cannot authorize the transaction", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf result = 7 Then
                            MessageBox.Show("Data mismatch! Reload records", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf result = 11 Then
                            MessageBox.Show("Failed! Given deposit code not exist in any authorize schedule record", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else
                            MessageBox.Show("Auth Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If


                Next i

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        LoadDataGrid()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

    End Sub

    Private Sub rdoAuthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAuthorized.CheckedChanged
        If rdoAuthorized.Checked = True Then
            'btnAuthorize.Enabled = False
            DisableAuth()
            chkAll.Visible = False
            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = False
            End If
            chkShowAll.Visible = True



        ElseIf rdoUnauthorized.Checked = True Then
            'btnAuthorize.Enabled = True
            EnableAuth()
            chkAll.Visible = True

            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If
            chkShowAll.Visible = False

        End If

        LoadDataGrid()
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim rowsCount, i As Integer
        rowsCount = dgView.Rows.Count

        If chkAll.Checked = True Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = True
            Next i
        ElseIf chkAll.Checked = False Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = False
            Next i
        End If
    End Sub


    Private Sub FrmCitiCashSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

        If rdoUnauthorized.Checked = True Then
            chkAll.Visible = True
            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If
        End If

    End Sub
End Class