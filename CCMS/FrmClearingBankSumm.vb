Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClearingBankSumm

#Region "user defined codes"

    Dim _formName As String = "MaintenanceClearingBankSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _bbkCode As String = ""
    Dim _bankName As String = ""
    Dim _accNo As String = ""
    Dim _HOadd1 As String = ""
    Dim _HOadd2 As String = ""
    Dim _HOadd3 As String = ""

    'For Auth
    Dim _abbkCode As String = ""
    Dim _abankName As String = ""
    Dim _aaccNo As String = ""
    Dim _aHOadd1 As String = ""
    Dim _aHOadd2 As String = ""
    Dim _aHOadd3 As String = ""


    Dim BankList As New List(Of String)
    Dim _bankLog As String = ""
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

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBank_GetDetailList")

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
                dgView.Item(3, i).Value = dt.Rows(i).Item("BANK_CODE").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("BANK_NAME").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("HEAD_ADD1").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("HEAD_ADD2").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("HEAD_ADD3").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("BANK_BBK_CODE").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("ACC_NO").ToString()
                dgView.Item(10, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(11, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(12, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(13, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(14, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
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

                Dim frmBankDet As New FrmClearingBankDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmBankDet.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmBankDet As New FrmClearingBankDet
        frmBankDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmBankDet As New FrmClearingBankDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmBankDet.Show()
        End If
    End Sub

    Private Sub FrmBankSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

    End Sub




    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

            ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        End If
    End Sub

    '------------Mizan Work (19-05-2016)------------

    Private Sub LoadBankDataForAuth(ByVal strBankCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLEARING_BANK Where BANK_CODE ='" & strBankCode & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _abankName = ds.Tables(0).Rows(0)("BANK_NAME").ToString()

                _aHOadd1 = ds.Tables(0).Rows(0)("HEAD_ADD1").ToString()

                _aHOadd2 = ds.Tables(0).Rows(0)("HEAD_ADD2").ToString()

                _aHOadd3 = ds.Tables(0).Rows(0)("HEAD_ADD3").ToString()

                _abbkCode = ds.Tables(0).Rows(0)("BANK_BBK_CODE").ToString()

                _aaccNo = ds.Tables(0).Rows(0)("ACC_NO").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (19-05-2016)------------
    Private Sub LoadBankData(ByVal strBankCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBank_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@BANK_CODE", DbType.String, strBankCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _bankName = ds.Tables(0).Rows(0)("BANK_NAME").ToString()

                _HOadd1 = ds.Tables(0).Rows(0)("HEAD_ADD1").ToString()

                _HOadd2 = ds.Tables(0).Rows(0)("HEAD_ADD2").ToString()

                _HOadd3 = ds.Tables(0).Rows(0)("HEAD_ADD3").ToString()

                _bbkCode = ds.Tables(0).Rows(0)("BANK_BBK_CODE").ToString()

                _accNo = ds.Tables(0).Rows(0)("ACC_NO").ToString()

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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBank_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (19-05-2016)------------
                        LoadBankData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                        If (dgView.Rows(i).Cells(1).Value) > 1 Then
                            LoadBankDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                        End If
                        '------------Mizan Work (19-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@BANK_CODE", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(12).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "
                            '------------Mizan Work (19-05-2016)------------

                            If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                If _aaccNo <> _accNo Then
                                    log_message = " Account No : " + _aaccNo + " " + " To " + " " + _accNo + "." + " "
                                    BankList.Add(log_message)
                                End If

                                If _abbkCode <> _bbkCode Then
                                    If _abbkCode = "" Then
                                        log_message = " BBK Code : " + _bbkCode + "." + " "
                                    Else
                                        log_message = " BBK Code : " + _abbkCode + " " + " To " + " " + _bbkCode + "." + " "
                                    End If
                                    BankList.Add(log_message)
                                End If
                                If _aHOadd1 <> _HOadd1 Then
                                    If _aHOadd1 = "" Then
                                        log_message = " Head Office Address 1 : " + _HOadd1 + "." + " "
                                    Else
                                        log_message = " Head Office Address 1 : " + _aHOadd1 + " " + " To " + " " + _HOadd1 + "." + " "
                                    End If
                                    BankList.Add(log_message)
                                End If
                                If _aHOadd2 <> _HOadd2 Then
                                    If _aHOadd2 = "" Then
                                        log_message = " Head Office Address 2 : " + _HOadd2 + "." + " "
                                    Else
                                        log_message = " Head Office Address 2 : " + _aHOadd2 + " " + " To " + " " + _HOadd2 + "." + " "
                                    End If
                                    BankList.Add(log_message)
                                End If
                                If _aHOadd3 <> _HOadd3 Then
                                    If _aHOadd3 = "" Then
                                        log_message = " Head Office Address 3 : " + _HOadd3 + "." + " "
                                    Else
                                        log_message = " Head Office Address 3 : " + _aHOadd3 + " " + " To " + " " + _HOadd3 + "." + " "
                                    End If
                                    BankList.Add(log_message)
                                End If

                                For Each bankInfo As String In BankList
                                    _bankLog += bankInfo
                                Next
                                _log = " Authorized : Bank Code : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + " Bank Name : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + _bankLog

                                Logger.system_log(_log)

                                _bankLog = ""
                                BankList.Clear()

                            Else

                                If _abankName <> _bankName Then
                                    If _abankName = "" Then
                                        log_message = " Bank Name : " + _bankName + "." + " "
                                    Else
                                        log_message = " Bank Name : " + _abankName + " " + " To " + " " + _bankName + "." + " "
                                    End If

                                    BankList.Add(log_message)
                                End If

                                If _aaccNo <> _accNo Then
                                    If _aaccNo = "" Then
                                        log_message = " Account No : " + _accNo + "." + " "
                                    Else
                                        log_message = " Account No : " + _aaccNo + " " + " To " + " " + _accNo + "." + " "
                                    End If

                                    BankList.Add(log_message)
                                End If



                                For Each bankInfo As String In BankList
                                    _bankLog += bankInfo
                                Next
                                _log = " Authorized : Bank Code : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _bankLog

                                Logger.system_log(_log)

                                _bankLog = ""
                                BankList.Clear()

                            End If
                            '------------Mizan Work (19-05-2016)------------

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


End Class