Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClientSumm

#Region "user defined codes"

    Dim _formName As String = "MaintenanceClientSummary"
    Dim opt As SecForm = New SecForm(_formName)
    Dim log_message As String
    
    'For Update
    Dim _AccName As String = ""
    Dim _CashCrDays As String = ""
    Dim _SpeedCrDays As String = ""
    Dim _cmbCashCrType As String = ""
    Dim _cmbSpeedCrType As String = ""
    Dim _GrantAcc As String = ""
    Dim _GrantOfAcc As String = ""
    Dim _MailingAdd As String = ""
    Dim _Contact As String = ""
    Dim _Email As String = ""
    Dim _CashChrg As String = ""
    Dim _CashStandChrg As String = ""
    Dim _CashVat As String = ""
    Dim _SpeedChrg As String = ""
    Dim _SpeedStandChrg As String = ""
    Dim _SpeedVat As String = ""
    Dim _ReturnChrg As String = ""
    Dim _CitiAnyChrg As String = ""
    Dim _CitiAnyStandChrg As String = ""
    Dim _CitiAnyVat As String = ""
    Dim _cmbCustBilType As String = ""

    'For Authorize
    Dim _aAccName As String = ""
    Dim _aCashCrDays As String = ""
    Dim _aSpeedCrDays As String = ""
    Dim _acmbCachCrType As String = ""
    Dim _acmbSpeedCrType As String = ""
    Dim _aGrantAcc As String = ""
    Dim _aGrantOfAcc As String = ""
    Dim _aMailingAdd As String = ""
    Dim _aContact As String = ""
    Dim _aEmail As String = ""
    Dim _aCashChrg As String = ""
    Dim _aCashStandChrg As String = ""
    Dim _aCashVat As String = ""
    Dim _aSpeedChrg As String = ""
    Dim _aSpeedStandChrg As String = ""
    Dim _aSpeedVat As String = ""
    Dim _aReturnChrg As String = ""
    Dim _aCitiAnyChrg As String = ""
    Dim _aCitiAnyStandChrg As String = ""
    Dim _aCitiAnyVat As String = ""
    Dim _acmbCustBilType As String = ""

    '-----------For Location Charge-----------
    'For Update
    Dim _CashCreditDays As String = ""
    Dim _SpeedCreditDays As String = ""
    Dim _CashCharge As String = ""
    Dim _SpeedCharge As String = ""

    'For Auth
    Dim _aCashCreditDays As String = ""
    Dim _aSpeedCreditDays As String = ""
    Dim _aCashCharge As String = ""
    Dim _aSpeedCharge As String = ""
    '-----------For Location Charge-----------

    Dim ClientList As New List(Of String)
    Dim _clientLog As String = ""
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

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand

            If rdoClient.Checked = True Then
                commProc = db.GetStoredProcCommand("CMS_Client_GetDetailList")

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
                    dgView.Item(3, i).Value = dt.Rows(i).Item("CLIENT_CODE").ToString()
                    dgView.Item(4, i).Value = dt.Rows(i).Item("ACC_NO").ToString()

                    dgView.Item(5, i).Value = dt.Rows(i).Item("ACC_NAME").ToString()
                    dgView.Item(6, i).Value = dt.Rows(i).Item("MAIL_ADD").ToString()
                    dgView.Item(7, i).Value = dt.Rows(i).Item("CONTACT").ToString()
                    dgView.Item(8, i).Value = dt.Rows(i).Item("CASH_DAYS").ToString()
                    dgView.Item(9, i).Value = dt.Rows(i).Item("SPEED_DAYS").ToString()
                    dgView.Item(10, i).Value = dt.Rows(i).Item("CASH_CR_TYPE").ToString()
                    dgView.Item(11, i).Value = dt.Rows(i).Item("SPEED_CR_TYPE").ToString()
                    dgView.Item(12, i).Value = dt.Rows(i).Item("CASH_CHARGE").ToString()
                    dgView.Item(13, i).Value = dt.Rows(i).Item("SPEED_CHARGE").ToString()
                    dgView.Item(14, i).Value = dt.Rows(i).Item("RETURN_CHARGE").ToString()
                    dgView.Item(15, i).Value = dt.Rows(i).Item("CASH_STD_CHARGE").ToString()
                    dgView.Item(16, i).Value = dt.Rows(i).Item("SPEED_STD_CHARGE").ToString()
                    dgView.Item(17, i).Value = dt.Rows(i).Item("CASH_VAT").ToString()
                    dgView.Item(18, i).Value = dt.Rows(i).Item("SPEED_VAT").ToString()
                    dgView.Item(19, i).Value = dt.Rows(i).Item("CITIANY_CHARGE").ToString()
                    dgView.Item(20, i).Value = dt.Rows(i).Item("CITIANY_STD_CHARGE").ToString()
                    dgView.Item(21, i).Value = dt.Rows(i).Item("CITIANY_VAT").ToString()
                    dgView.Item(22, i).Value = dt.Rows(i).Item("BILLING_TYPE").ToString()

                    dgView.Item(23, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                    dgView.Item(24, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                    dgView.Item(25, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                    dgView.Item(26, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                    dgView.Item(27, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
                Next

            Else
                commProc = db.GetStoredProcCommand("CMS_ClientLocCharge_GetSummList")

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

                dgViewLoc.Rows.Clear()

                For i = 0 To dt.Rows.Count - 1
                    dgViewLoc.Rows.Add()
                    dgViewLoc.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                    dgViewLoc.Item(2, i).Value = dt.Rows(i).Item("S").ToString()
                    dgViewLoc.Item(3, i).Value = dt.Rows(i).Item("CLIENT_CODE").ToString()
                    dgViewLoc.Item(4, i).Value = dt.Rows(i).Item("ACC_NO").ToString()
                    dgViewLoc.Item(5, i).Value = dt.Rows(i).Item("ACC_NAME").ToString()
                    dgViewLoc.Item(6, i).Value = dt.Rows(i).Item("LOCATION_CODE").ToString()
                    dgViewLoc.Item(7, i).Value = dt.Rows(i).Item("LOCATION_NAME").ToString()
                    dgViewLoc.Item(8, i).Value = dt.Rows(i).Item("CASH_DAYS").ToString()
                    dgViewLoc.Item(9, i).Value = dt.Rows(i).Item("SPEED_DAYS").ToString()
                    dgViewLoc.Item(10, i).Value = dt.Rows(i).Item("CASH_CHARGE").ToString()
                    dgViewLoc.Item(11, i).Value = dt.Rows(i).Item("SPEED_CHARGE").ToString()
                    dgViewLoc.Item(12, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                    dgViewLoc.Item(13, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                    dgViewLoc.Item(14, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                    dgViewLoc.Item(15, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                    dgViewLoc.Item(16, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
                Next


            End If



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
            If rdoClient.Checked = True Then

                If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing) Then

                    Dim frmClientDet As New FrmClientDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                    frmClientDet.ShowDialog()
                End If
            Else
                If Not (dgViewLoc.SelectedRows.Item(0).Cells(3).Value Is Nothing) Then

                    Dim frmClientLocChrg As New FrmClientLocChargeDet(dgViewLoc.SelectedRows.Item(0).Cells(3).Value, dgViewLoc.SelectedRows.Item(0).Cells(6).Value, dgViewLoc.SelectedRows.Item(0).Cells(1).Value)
                    frmClientLocChrg.ShowDialog()
                End If

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmClientDet As New FrmClientDet()
        frmClientDet.ShowDialog()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If rdoClient.Checked = True Then
            If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

                Dim frmClientDet As New FrmClientDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmClientDet.ShowDialog()
            End If
        Else
            
        End If

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


    
    Private Sub FrmClientSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

        For i = 1 To dgViewLoc.Columns.Count - 1
            dgViewLoc.Columns(i).ReadOnly = True
        Next

        dgView.Visible = True
        dgViewLoc.Visible = False
    End Sub

    Private Sub rdoClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoClient.CheckedChanged
        LoadDataGrid()

        If rdoClient.Checked = True Then
            dgView.Visible = True
            dgViewLoc.Visible = False
        Else
            dgView.Visible = False
            dgViewLoc.Visible = True
        End If

    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim rowsCount, i As Integer



        If rdoClient.Checked = True Then

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

        Else

            rowsCount = dgViewLoc.Rows.Count

            If chkAll.Checked = True Then
                For i = 0 To rowsCount - 1
                    dgViewLoc(0, i).Value = True
                Next i
            ElseIf chkAll.Checked = False Then
                For i = 0 To rowsCount - 1
                    dgViewLoc(0, i).Value = False
                Next i
            End If

        End If


    End Sub

    '------------Mizan Work (18-05-2016)------------

    Private Sub LoadLocationChargeDataForAuth(ByVal strClientCode As String, ByVal strLocationCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLIENT_LOC_CHARGE Where CLIENT_CODE ='" & strClientCode & "' and LOCATION_CODE ='" & strLocationCode & "' and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _aCashCreditDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()
                _aSpeedCreditDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()
                _aCashCharge = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()
                _aSpeedCharge = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (18-05-2016)------------

    Private Sub LoadLocationChargeData(ByVal strClientCode As String, ByVal strLocationCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, strClientCode)
            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, strLocationCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _CashCreditDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()

                _SpeedCreditDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()

                _CashCharge = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()

                _SpeedCharge = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (18-05-2016)------------

    Private Sub LoadClientData(ByVal strClientCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, strClientCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


                _AccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()

                _CashCrDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()

                _cmbCashCrType = ds.Tables(0).Rows(0)("CASH_CR_TYPE").ToString()

                _SpeedCrDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()

                _cmbSpeedCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()

                _MailingAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()

                _Contact = ds.Tables(0).Rows(0)("CONTACT").ToString()

                _CashChrg = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()

                _CashStandChrg = ds.Tables(0).Rows(0)("CASH_STD_CHARGE").ToString()

                _CashVat = ds.Tables(0).Rows(0)("CASH_VAT").ToString()

                _SpeedChrg = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()

                _SpeedStandChrg = ds.Tables(0).Rows(0)("SPEED_STD_CHARGE").ToString()

                _SpeedVat = ds.Tables(0).Rows(0)("SPEED_VAT").ToString()

                _ReturnChrg = ds.Tables(0).Rows(0)("RETURN_CHARGE").ToString()

                _CitiAnyChrg = ds.Tables(0).Rows(0)("CITIANY_CHARGE").ToString()

                _CitiAnyStandChrg = ds.Tables(0).Rows(0)("CITIANY_STD_CHARGE").ToString()

                _CitiAnyVat = ds.Tables(0).Rows(0)("CITIANY_VAT").ToString()

                _cmbCustBilType = ds.Tables(0).Rows(0)("BILLING_TYPE").ToString()
               

                _Email = ds.Tables(0).Rows(0)("EMAIL").ToString()

                _GrantAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_ACC").ToString()

                _GrantOfAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_OFST_ACC").ToString()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (18-05-2016)------------

    Private Sub LoadClientDataForAuth(ByVal strClientCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLIENT Where CLIENT_CODE ='" & strClientCode & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _aAccName = ds.Tables(0).Rows(0)("ACC_NAME").ToString()

                _aCashCrDays = ds.Tables(0).Rows(0)("CASH_DAYS").ToString()

                _acmbCachCrType = ds.Tables(0).Rows(0)("CASH_CR_TYPE").ToString()

                _aSpeedCrDays = ds.Tables(0).Rows(0)("SPEED_DAYS").ToString()

                _acmbSpeedCrType = ds.Tables(0).Rows(0)("SPEED_CR_TYPE").ToString()

                _aMailingAdd = ds.Tables(0).Rows(0)("MAIL_ADD").ToString()

                _aContact = ds.Tables(0).Rows(0)("CONTACT").ToString()

                _aCashChrg = ds.Tables(0).Rows(0)("CASH_CHARGE").ToString()

                _aCashStandChrg = ds.Tables(0).Rows(0)("CASH_STD_CHARGE").ToString()

                _aCashVat = ds.Tables(0).Rows(0)("CASH_VAT").ToString()

                _aSpeedChrg = ds.Tables(0).Rows(0)("SPEED_CHARGE").ToString()

                _aSpeedStandChrg = ds.Tables(0).Rows(0)("SPEED_STD_CHARGE").ToString()

                _aSpeedVat = ds.Tables(0).Rows(0)("SPEED_VAT").ToString()

                _aReturnChrg = ds.Tables(0).Rows(0)("RETURN_CHARGE").ToString()

                _aCitiAnyChrg = ds.Tables(0).Rows(0)("CITIANY_CHARGE").ToString()

                _aCitiAnyStandChrg = ds.Tables(0).Rows(0)("CITIANY_STD_CHARGE").ToString()

                _aCitiAnyVat = ds.Tables(0).Rows(0)("CITIANY_VAT").ToString()

                _acmbCustBilType = ds.Tables(0).Rows(0)("BILLING_TYPE").ToString()

                _aEmail = ds.Tables(0).Rows(0)("EMAIL").ToString()

                _aGrantAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_ACC").ToString()

                _aGrantOfAcc = ds.Tables(0).Rows(0)("GUARANTEED_CR_OFST_ACC").ToString()


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

                If rdoClient.Checked = True Then

                    For i = 0 To dgView.Rows.Count - 1

                        If dgView.Rows(i).Cells(0).Value = True Then
                            '------------Mizan Work (18-05-2016)------------
                            LoadClientData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                            If (dgView.Rows(i).Cells(1).Value) > 1 Then
                                LoadClientDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                            End If
                            '------------Mizan Work (18-05-2016)------------

                            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_Auth")
                            commProc.Parameters.Clear()

                            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                            db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(25).Value)

                            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                            Dim result As Integer

                            db.ExecuteNonQuery(commProc)
                            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                            If result = 0 Then
                                lblToolStatus.Text = "Information Authorized Successfully !! "

                                '------------Mizan Work (18-05-2016)------------
                                If (dgView.Rows(i).Cells(1).Value) > 1 Then

                                    If _aAccName <> _AccName Then
                                        log_message = " Account Name : " + _aAccName + " " + " To " + " " + _AccName + "." + " "
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCashCrDays <> _CashCrDays Then
                                        If _aCashCrDays = "" Then
                                            log_message = " CitiCash Credit Days : " + _CashCrDays + "." + " "
                                        Else
                                            log_message = " CitiCash Credit Days : " + _aCashCrDays + " " + " To " + " " + _CashCrDays + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aSpeedCrDays <> _SpeedCrDays Then
                                        If _aSpeedCrDays = "" Then
                                            log_message = " CitiSpeed Credit Days : " + _SpeedCrDays + "." + " "
                                        Else
                                            log_message = " CitiSpeed Credit Days : " + _aSpeedCrDays + " " + " To " + " " + _SpeedCrDays + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _acmbCachCrType <> _cmbCashCrType Then
                                        If _acmbCachCrType = "" Then
                                            log_message = " Cash Credit Type : " + _cmbCashCrType + "." + " "
                                        Else
                                            log_message = " Cash Credit Type : " + _acmbCachCrType + " " + " To " + " " + _cmbCashCrType + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _acmbSpeedCrType <> _cmbSpeedCrType Then
                                        If _acmbSpeedCrType = "" Then
                                            log_message = " Speed Credit Type : " + _cmbSpeedCrType + "." + " "
                                        Else
                                            log_message = " Speed Credit Type : " + _acmbSpeedCrType + " " + " To " + " " + _cmbSpeedCrType + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aGrantAcc <> _GrantAcc Then
                                        If _aGrantAcc = "" Then
                                            log_message = " Garanteed Credit A/C : " + _GrantAcc + "." + " "
                                        Else
                                            log_message = " Garanteed Credit A/C : " + _aGrantAcc + " " + " To " + " " + _GrantAcc + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aGrantOfAcc <> _GrantOfAcc Then
                                        If _aGrantOfAcc = "" Then
                                            log_message = " Garanteed OF Credit A/C : " + _GrantOfAcc + "." + " "
                                        Else
                                            log_message = " Garanteed OF Credit A/C : " + _aGrantOfAcc + " " + " To " + " " + _GrantOfAcc + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If

                                    If _aMailingAdd <> _MailingAdd Then
                                        If _aMailingAdd = "" Then
                                            log_message = " Mailing Address : " + _MailingAdd + "." + " "
                                        Else
                                            log_message = " Mailing Address : " + _aMailingAdd + " " + " To " + " " + _MailingAdd + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aContact <> _Contact Then
                                        If _aContact = "" Then
                                            log_message = " Contact : " + _Contact + "." + " "
                                        Else
                                            log_message = " Contact : " + _aContact + " " + " To " + " " + _Contact + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aEmail <> _Email Then
                                        If _aEmail = "" Then
                                            log_message = " Email Address : " + _Email + "." + " "
                                        Else
                                            log_message = " Email Address : " + _aEmail + " " + " To " + " " + _Email + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCashChrg <> _CashChrg Then
                                        If _aCashChrg = "" Then
                                            log_message = " CitiCash Charge : " + _CashChrg + "." + " "
                                        Else
                                            log_message = " CitiCash Charge : " + _aCashChrg + " " + " To " + " " + _CashChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCashStandChrg <> _CashStandChrg Then
                                        If _aCashStandChrg = "" Then
                                            log_message = " CitiCash Standard Charge : " + _CashStandChrg + "." + " "
                                        Else
                                            log_message = " CitiCash Standard Charge : " + _aCashStandChrg + " " + " To " + " " + _CashStandChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCashVat <> _CashVat Then
                                        If _aCashVat = "" Then
                                            log_message = " CitiCash VAT  : " + _CashVat + "%" + "." + " "
                                        Else
                                            log_message = " CitiCash VAT : " + _aCashVat + "%" + " " + " To " + " " + _CashVat + "%" + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aSpeedChrg <> _SpeedChrg Then
                                        If _aSpeedChrg = "" Then
                                            log_message = " CitiSpeed Charge : " + _SpeedChrg + "." + " "
                                        Else
                                            log_message = " CitiSpeed Charge : " + _aSpeedChrg + " " + " To " + " " + _SpeedChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aSpeedStandChrg <> _SpeedStandChrg Then
                                        If _aSpeedStandChrg = "" Then
                                            log_message = " CitiSpeed Standard Charge : " + _SpeedStandChrg + "." + " "
                                        Else
                                            log_message = " CitiSpeed Standard Charge : " + _aSpeedStandChrg + " " + " To " + " " + _SpeedStandChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aSpeedVat <> _SpeedVat Then
                                        If _aSpeedVat = "" Then
                                            log_message = " CitiSpeed VAT : " + _SpeedVat + "%" + "." + " "
                                        Else
                                            log_message = " CitiSpeed VAT : " + _aSpeedVat + "%" + " " + " To " + " " + _SpeedVat + "%" + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aReturnChrg <> _ReturnChrg Then
                                        If _aReturnChrg = "" Then
                                            log_message = " Return Check Charges : " + _ReturnChrg + "." + " "
                                        Else
                                            log_message = " Return Check Charges : " + _aReturnChrg + " " + " To " + " " + _ReturnChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCitiAnyChrg <> _CitiAnyChrg Then
                                        If _aCitiAnyChrg = "" Then
                                            log_message = " Citi Anywhere Charges : " + _CitiAnyChrg + "." + " "
                                        Else
                                            log_message = " Citi Anywhere Charges : " + _aCitiAnyChrg + " " + " To " + " " + _CitiAnyChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCitiAnyStandChrg <> _CitiAnyStandChrg Then
                                        If _aCitiAnyStandChrg = "" Then
                                            log_message = " Citi Anywhere Standard Charges : " + _CitiAnyStandChrg + "." + " "
                                        Else
                                            log_message = " Citi Anywhere Standard Charges : " + _aCitiAnyStandChrg + " " + " To " + " " + _CitiAnyStandChrg + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCitiAnyVat <> _CitiAnyVat Then
                                        If _aCitiAnyVat = "" Then
                                            log_message = " Citi Anywhere VAT : " + _CitiAnyVat + "%" + "." + " "
                                        Else
                                            log_message = " Citi Anywhere VAT : " + _aCitiAnyVat + "%" + " " + " To " + " " + _CitiAnyVat + "%" + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _acmbCustBilType <> _cmbCustBilType Then
                                        If _acmbCustBilType = "" Then
                                            log_message = " Customer Billing Type : " + _cmbCustBilType + "." + " "
                                        Else
                                            log_message = " Customer Billing Type : " + _acmbCustBilType + " " + " To " + " " + _cmbCustBilType + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If

                                    For Each clientInfo As String In ClientList
                                        _clientLog += clientInfo
                                    Next
                                    _log = " Authorized : Client Code : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + " Account No : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + _clientLog

                                    Logger.system_log(_log)

                                    _clientLog = ""
                                    ClientList.Clear()

                                Else

                                    If _aAccName <> _AccName Then
                                        If _aAccName = "" Then
                                            log_message = " Account Name : " + _AccName + "." + " "
                                        Else
                                            log_message = " Account Name : " + _aAccName + " " + " To " + " " + _AccName + "." + " "
                                        End If

                                        ClientList.Add(log_message)
                                    End If
                                    
                                    For Each clientInfo As String In ClientList
                                        _clientLog += clientInfo
                                    Next
                                    _log = " Authorized : Client Code : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + " Account No : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + _clientLog

                                    Logger.system_log(_log)

                                    _clientLog = ""
                                    ClientList.Clear()

                                End If
                                '------------Mizan Work (18-05-2016)------------
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

                Else 'Charge location

                    For i = 0 To dgViewLoc.Rows.Count - 1

                        If dgViewLoc.Rows(i).Cells(0).Value = True Then

                            '------------Mizan Work (18-05-2016)------------
                            LoadLocationChargeData(dgViewLoc.Rows(i).Cells(3).Value.ToString(), dgViewLoc.Rows(i).Cells(6).Value.ToString(), dgViewLoc.Rows(i).Cells(1).Value)
                            If (dgViewLoc.Rows(i).Cells(1).Value) > 1 Then
                                LoadLocationChargeDataForAuth(dgViewLoc.Rows(i).Cells(3).Value.ToString(), dgViewLoc.Rows(i).Cells(6).Value.ToString())
                            End If
                            '------------Mizan Work (18-05-2016)------------

                            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_Auth")
                            commProc.Parameters.Clear()

                            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, dgViewLoc.Rows(i).Cells(3).Value.ToString())
                            db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, dgViewLoc.Rows(i).Cells(6).Value.ToString())
                            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgViewLoc.Rows(i).Cells(1).Value)
                            db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgViewLoc.Rows(i).Cells(14).Value)

                            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                            Dim result As Integer

                            db.ExecuteNonQuery(commProc)
                            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                            If result = 0 Then
                                lblToolStatus.Text = "Information Authorized Successfully !! "

                                '------------Mizan Work (18-05-2016)------------
                                If (dgViewLoc.Rows(i).Cells(1).Value) > 1 Then

                                    If _aCashCreditDays <> _CashCreditDays Then
                                        If _aCashCreditDays = "" Then
                                            log_message = " CitiCash Credit Days : " + _CashCreditDays + "." + " "
                                        Else
                                            log_message = " CitiCash Credit Days : " + _aCashCreditDays + " " + " To " + " " + _CashCreditDays + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aSpeedCreditDays <> _SpeedCreditDays Then
                                        If _aSpeedCreditDays = "" Then
                                            log_message = " CitiSpeed Credit Days : " + _SpeedCreditDays + "." + " "
                                        Else
                                            log_message = " CitiSpeed Credit Days : " + _aSpeedCreditDays + " " + " To " + " " + _SpeedCreditDays + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If
                                    If _aCashCharge <> _CashCharge Then
                                        If _aCashCharge = "" Then
                                            log_message = " CitiCash Charge : " + _CashCharge + "." + " "
                                        Else
                                            log_message = " CitiCash Charge : " + _aCashCharge + " " + " To " + " " + _CashCharge + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If

                                    If _aSpeedCharge <> _SpeedCharge Then
                                        If _aSpeedCharge = "" Then
                                            log_message = " CitiSpeed Charge : " + _SpeedCharge + "." + " "
                                        Else
                                            log_message = " CitiSpeed Charge : " + _aSpeedCharge + " " + " To " + " " + _SpeedCharge + "." + " "
                                        End If
                                        ClientList.Add(log_message)
                                    End If


                                    For Each clientInfo As String In ClientList
                                        _clientLog += clientInfo
                                    Next
                                    _log = " Authorized : Client Code : " + dgViewLoc.Rows(i).Cells(3).Value.ToString() + "." + " " + " Location Code : " + dgViewLoc.Rows(i).Cells(6).Value.ToString() + "." + " " + _clientLog

                                    Logger.system_log(_log)

                                    _clientLog = ""
                                    ClientList.Clear()

                                Else

                                    _log = " Authorized : Client Code : " + dgViewLoc.Rows(i).Cells(3).Value.ToString() + "." + " " + " Location Code : " + dgViewLoc.Rows(i).Cells(6).Value.ToString()

                                    Logger.system_log(_log)

                                End If
                                '------------Mizan Work (18-05-2016)------------

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

                

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        LoadDataGrid()
    End Sub

    Private Sub rdoAuthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAuthorized.CheckedChanged
        If rdoAuthorized.Checked = True Then
            'btnAuthorize.Enabled = False
            DisableAuth()
            chkAll.Visible = False


            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = False
            End If

            If dgViewLoc.Columns.Count > 0 Then
                dgViewLoc.Columns(0).Visible = False
            End If


            chkShowAll.Visible = True



        ElseIf rdoUnauthorized.Checked = True Then
            'btnAuthorize.Enabled = True
            EnableAuth()
            chkAll.Visible = True


            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If

            If dgViewLoc.Columns.Count > 0 Then
                dgViewLoc.Columns(0).Visible = True
            End If

            chkShowAll.Visible = False

        End If

        LoadDataGrid()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If rdoClient.Checked = True Then
            Dim objExp As New ExportUtil(dgView)

            objExp.ExportXl()
        Else
            Dim objExp As New ExportUtil(dgViewLoc)

            objExp.ExportXl()
        End If


    End Sub

    Private Sub dgViewLoc_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgViewLoc.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If dgViewLoc.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                dgViewLoc.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

            ElseIf dgViewLoc.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                dgViewLoc.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        End If
    End Sub

    Private Sub dgViewLoc_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewLoc.CellDoubleClick
        If rdoClient.Checked = True Then
            
        Else
            If Not (dgViewLoc.SelectedRows.Item(0).Cells(3).Value Is Nothing Or dgViewLoc.SelectedRows.Item(0).Cells(3).Value Is DBNull.Value) Then

                Dim frmClientLocChrg As New FrmClientLocChargeDet(dgViewLoc.SelectedRows.Item(0).Cells(3).Value, dgViewLoc.SelectedRows.Item(0).Cells(6).Value, dgViewLoc.SelectedRows.Item(0).Cells(1).Value)
                frmClientLocChrg.ShowDialog()
            End If
        End If
    End Sub
End Class