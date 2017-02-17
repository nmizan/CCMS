Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmDDSumm

#Region "user defined codes"
    Dim _formName As String = "CollectionDDSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _DDNo(1000) As String
    Dim _DDDate(1000) As String
    Dim _DDAmt(1000) As String
    Dim _BranchCode(1000) As String
    Dim _LocCode(1000) As String
    Dim _BankCode(1000) As String
    Dim _DraweeBankComm(1000) As String
    Dim _DraweeBankVat(1000) As String
    Dim _DrawBankPostChrg(1000) As String
    Dim _DrawBankInstrExp(1000) As String

    'For Auth
    Dim _aDDNo(1000) As String
    Dim _aDDDate(1000) As String
    Dim _aDDAmt(1000) As String
    Dim _aBranchCode(1000) As String
    Dim _aLocCode(1000) As String
    Dim _aBankCode(1000) As String
    Dim _aDraweeBankComm(1000) As String
    Dim _aDraweeBankVat(1000) As String
    Dim _aDrawBankPostChrg(1000) As String
    Dim _aDrawBankInstrExp(1000) As String

    Dim DDList As New List(Of String)
    Dim _ddLog As String = ""
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

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_GetDetailList")

            commProc.Parameters.Clear()

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
                dgView.Item(4, i).Value = dt.Rows(i).Item("SLNO").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("DD_NO").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("DD_DATE").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("AMOUNT").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("DRAWER_BANKNAME").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("DRAWER_BRANCHNAME").ToString()
                dgView.Item(10, i).Value = dt.Rows(i).Item("DRAWER_LOCATIONNAME").ToString()
                dgView.Item(11, i).Value = dt.Rows(i).Item("DRAWEE").ToString()
                dgView.Item(12, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(13, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(14, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(15, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(16, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
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

                Dim frmDDDet As New FrmDDDetail(dgView.SelectedRows.Item(0).Cells(3).Value)
                frmDDDet.Show()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()
       
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmDDDet As New FrmDDDetail()
        frmDDDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmDDDet As New FrmDDDetail(dgView.SelectedRows.Item(0).Cells(3).Value)
            frmDDDet.Show()
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

    Private Sub LoadDDDataForAuth(ByVal DepoCode As String)

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From DD  Where D_CODE ='" & DepoCode & "' and STATUS='L'").Tables(0)



            If dt.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count - 1
                   
                    _aDDNo(i) = dt.Rows(i)("DD_NO")

                    _aDDDate(i) = NullHelper.DateToString(dt.Rows(i)("DD_DATE")).ToString()
                    
                    _aDDAmt(i) = dt.Rows(i)("AMOUNT")

                    _aDraweeBankVat(i) = NullHelper.ToDecNum(dt.Rows(i)("VAT")).ToString

                    _aDraweeBankComm(i) = dt.Rows(i)("COMMISION").ToString

                    _aDrawBankPostChrg(i) = dt.Rows(i)("POSTAGE_CHARGE")

                    _aDrawBankInstrExp(i) = dt.Rows(i)("INSTRUMENT_EXP")

                    _aBankCode(i) = dt.Rows(i)("DRAWER_BANKCODE")

                    _aBranchCode(i) = dt.Rows(i)("DRAWER_BRANCHCODE")

                    _aLocCode(i) = dt.Rows(i)("DRAWER_LOCATION")


                Next


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '------------Mizan Work (22-05-2016)------------

    Private Sub LoadDDData(ByVal DepoCode As String)

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_DD_GetDetail")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@D_CODE", DbType.String, DepoCode)


            dt = db.ExecuteDataSet(commProcSche).Tables(0)

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then


                For i = 0 To dt.Rows.Count - 1

                    _DDNo(i) = dt.Rows(i)("DD_NO")

                    _DDDate(i) = NullHelper.DateToString(dt.Rows(i)("DD_DATE")).ToString()

                    _DDAmt(i) = dt.Rows(i)("AMOUNT")

                    _DraweeBankVat(i) = NullHelper.ToDecNum(dt.Rows(i)("VAT")).ToString

                    _DraweeBankComm(i) = dt.Rows(i)("COMMISION").ToString

                    _DrawBankPostChrg(i) = dt.Rows(i)("POSTAGE_CHARGE")

                    _DrawBankInstrExp(i) = dt.Rows(i)("INSTRUMENT_EXP")

                    _BankCode(i) = dt.Rows(i)("DRAWER_BANKCODE")

                    _BranchCode(i) = dt.Rows(i)("DRAWER_BRANCHCODE")

                    _LocCode(i) = dt.Rows(i)("DRAWER_LOCATION")


                Next
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

                For i = 0 To dgView.Rows.Count - 1



                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (22-05-2016)------------

                        'LoadDDData(dgView.Rows(i).Cells(3).Value.ToString())

                        'If (dgView.Rows(i).Cells(1).Value) > 1 Then
                        '    LoadDDDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                        'End If

                        '------------Mizan Work (22-05-2016)------------

                        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Auth")
                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@D_CODE", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(4).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(14).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '------------Mizan Work (22-05-2016)------------


                            'If (dgView.Rows(i).Cells(1).Value) > 1 Then


                            '    If _aDDNo(i) <> _DDNo(i) Then
                            '        log_message = " DD No : " + _aDDNo(i) + " " + " To " + " " + _DDNo(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aDDDate(i) <> _DDDate(i) Then
                            '        log_message = " DD Date : " + _aDDDate(i) + " " + " To " + " " + _DDDate(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If

                            '    If _aDDAmt(i) <> _DDAmt(i) Then
                            '        log_message = " DD Amount : " + _aDDAmt(i) + " " + " To " + " " + _DDAmt(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aDraweeBankVat(i) <> _DraweeBankVat(i) Then
                            '        log_message = " Drawee Bank Vat : " + _aDraweeBankVat(i) + " " + " To " + " " + _DraweeBankVat(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aDraweeBankComm(i) <> _DraweeBankComm(i) Then
                            '        log_message = " Drawee Bank Comm : " + _aDraweeBankComm(i) + " " + " To " + " " + _DraweeBankComm(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aDrawBankInstrExp(i) <> _DrawBankInstrExp(i) Then
                            '        log_message = " Drawee Bank Instruement Exp : " + _aDrawBankInstrExp(i) + " " + " To " + " " + _DrawBankInstrExp(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aDrawBankPostChrg(i) <> _DrawBankPostChrg(i) Then
                            '        log_message = " Drawee Bank Postage Charge : " + _aDrawBankPostChrg(i) + " " + " To " + " " + _DrawBankPostChrg(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aBankCode(i) <> _BankCode(i) Then
                            '        log_message = "  Bank Code : " + _aBankCode(i) + " " + " To " + " " + _BankCode(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If

                            '    If _aBranchCode(i) <> _BranchCode(i) Then
                            '        log_message = "  Branch Code : " + _aBranchCode(i) + " " + " To " + " " + _BranchCode(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If
                            '    If _aLocCode(i) <> _LocCode(i) Then
                            '        log_message = " Location Code : " + _aLocCode(i) + " " + " To " + " " + _LocCode(i) + "." + " "
                            '        DDList.Add(log_message)
                            '    End If

                            '    For Each ddInfo As String In DDList
                            '        _ddLog += ddInfo
                            '    Next
                            '    _log = " Authorized : DD Deposit Code : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _ddLog

                            '    Logger.system_log(_log)

                            '    _ddLog = ""
                            '    DDList.Clear()

                            'Else

                            _log = " Authorized : DD Deposit Code : " + dgView.Rows(i).Cells(3).Value.ToString()

                            Logger.system_log(_log)

                            'End If

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
                            MessageBox.Show("Failed! Given deposit code does not exist in any authorize schedule record", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

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




        ElseIf rdoUnauthorized.Checked = True Then
            'btnAuthorize.Enabled = True
            EnableAuth()
            chkAll.Visible = True

            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If


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



   
    Private Sub FrmDDSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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