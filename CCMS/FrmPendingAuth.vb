'
' List of pending unauthorized item
' Author: Iftekharul Alam Khan Lodi
' Since: 03-May-13
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Threading

Public Class FrmPendingAuth

    Dim _linkForm As System.Windows.Forms.LinkLabel
    Dim _db As New SqlDatabase(CommonAppSet.ConnStr)
    Public Delegate Sub LoadFormListDelegate()

    Private trd As Thread





    Private Sub LoadFormList()
        'Dim x As String = "FrmBankDet"
        ''Dim frmPeople As New (Form)x

        'Dim frm As Form
        'frm = CommonUtil.CreateForm(x)
        'frm.ShowDialog()
        '  holiday, deposit stock,
        'deposit, cash, speed, citianywhere, outstanding reversal, collection, dd
        BuildPendingLink1("FrmClientSumm", "Client", "CMS_Client_GetDetailList")
        BuildPendingLink1("FrmClientSumm", "Client Location Charge", "CMS_ClientLocCharge_GetSummList")
        BuildPendingLink1("FrmBankSumm", "Bank", "CMS_Bank_GetDetailList")
        BuildPendingLink1("FrmBranchSumm", "Branch", "CMS_Branch_GetDetailList")
        BuildPendingLink1("FrmLocationSumm", "Location", "CMS_Location_GetDetailList")
        BuildPendingLink1("FrmZoneSumm", "Zone", "CMS_Zone_GetDetailList")
        BuildPendingLink1("FrmReturnSumm", "Reject/Return", "CMS_ReturnReject_GetDetailList")
        BuildPendingLink1("FrmCheckTypeSumm", "Cheque Type", "CMS_CheckType_GetDetailList")
        BuildPendingLink1("FrmHolidaySumm", "Holiday", "CMS_Holiday_GetDetailList")
        'BuildPendingLink1("FrmScheduleStockSumm", "Schedule Stock", "CMS_ScheduleStock_GetDetailList")
        BuildScheduleStockPendingLink()

        BuildPendingLink1("FrmClearingClientSumm", "Clearing Client", "CMS_ClearingClient_GetDetailList")
        BuildPendingLink1("FrmClearingBankSumm", "Clearing Bank", "CMS_ClearingBank_GetDetailList")
        BuildPendingLink1("FrmClearingBranchSumm", "Clearing Branch", "CMS_ClearingBranch_GetDetailList")
        BuildPendingLink2("FrmFlexAccSumm", "Flex Account", "CMS_FlexAcc_GetDetailList") '

        'BuildPendingLink1("FrmDepoScheSumm", "Deposit Schedule", "CMS_DCollected_GetDetailList")
        BuildDepositSchedulePendingLink()
        BuildPendingLink1("FrmCitiCashSumm", "CitiCash", "CMS_CCash_GetDetailList")
        BuildPendingLink1("FrmCitiSpeedSumm", "CitiSpeed", "CMS_CSD_GetDetailList")
        BuildPendingLink1("FrmCitiCheckSumm", "CitiAnywhere", "CMS_CCheckTotal_GetDetailList")

        BuildOutstandingReversalPendingLink()
        'BuildPendingLink1("FrmBankSumm", "Outstanding Reversal", "CMS_Bank_GetDetailList")
        BuildPendingLink1("FrmCollScheduleSumm", "Collection Schedule", "CMS_TotalCS_GetDetailList")
        'BuildPendingLink1("FrmDDSumm", "DD", "CMS_DD_GetDetailList")
        BuildDDPendingLink()

        BuildPendingLink2("FrmCitiSpeedReturnSumm", "CitiSpeed Return", "CMS_ReturnCSD_GetDetailList")

        BuildPendingLink2("FrmCitiAnyReturnSumm", "CitiAnywhere Return", "CMS_NCollection_GetDetailList")

    End Sub
    

    Public Sub LinkLabelClickHandler(ByVal sender As Object, ByVal e As System.EventArgs)



        Dim formName As String = CType(sender, LinkLabel).Tag

        Dim frm As Form
        frm = CommonUtil.CreateForm(formName)
        frm.ShowDialog()

    End Sub

    Private Sub FrmPendingAuth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadFormList()

       
        'btnLoadList.Enabled = False
       



    End Sub

    ''' <summary>
    ''' Pending Link from procedure that need del_flag,auth_flag
    ''' </summary>
    ''' <param name="formSysName"></param>
    ''' <param name="formName"></param>
    ''' <param name="procName"></param>
    ''' <remarks></remarks>

    Private Sub BuildPendingLink1(ByVal formSysName As String, ByVal formName As String, ByVal procName As String)


        Try


            Dim commProc As DbCommand = _db.GetStoredProcCommand(procName)

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            _db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)

            Dim totRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

            If totRows > 0 Then

                _linkForm = New System.Windows.Forms.LinkLabel()
                _linkForm.Text = formName + " Pending: " + totRows.ToString()
                _linkForm.Tag = formSysName
                _linkForm.AutoSize = True
                _linkForm.Padding = New Padding(0, 8, 0, 0)
                _linkForm.Font=New Font(_linkForm.Font,FontStyle.Bold)



                AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                SetLinkLable(_linkForm)
                'flpPending.Controls.Add(_linkForm)
                'tlpPending.RowCount = tlpPending.RowCount + 1
                'tlpPending.Controls.Add(_linkForm)

                'If tlpPending.InvokeRequired = True Then
                '    'tlpPending.Invoke(
                'Else

                'End If

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    ''' <summary>
    ''' Pending Link from procedure that need auth_flag
    ''' </summary>
    ''' <param name="formSysName"></param>
    ''' <param name="formName"></param>
    ''' <param name="procName"></param>
    ''' <remarks></remarks>
    Private Sub BuildPendingLink2(ByVal formSysName As String, ByVal formName As String, ByVal procName As String)


        Try


            Dim commProc As DbCommand = _db.GetStoredProcCommand(procName)

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)

            Dim totRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

            If totRows > 0 Then

                _linkForm = New System.Windows.Forms.LinkLabel()
                _linkForm.Text = formName + " Pending: " + totRows.ToString()
                _linkForm.Tag = formSysName
                _linkForm.AutoSize = True
                _linkForm.Padding = New Padding(0, 8, 0, 0)
                _linkForm.Font = New Font(_linkForm.Font, FontStyle.Bold)


                AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                SetLinkLable(_linkForm)
                'flpPending.Controls.Add(_linkForm)
                'tlpPending.RowCount = tlpPending.RowCount + 1
                'tlpPending.Controls.Add(_linkForm)

                'If tlpPending.InvokeRequired = True Then
                '    'tlpPending.Invoke(
                'Else

                'End If

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub SetLinkLable(ByVal link As System.Windows.Forms.LinkLabel)


        If tlpPending.InvokeRequired Then
            tlpPending.Invoke(New Action(Of System.Windows.Forms.LinkLabel)(AddressOf SetLinkLable), link)
        Else
            tlpPending.Controls.Add(link)
        End If
    End Sub


    Private Sub BuildScheduleStockPendingLink()

        Try

            Dim commProc As DbCommand = _db.GetStoredProcCommand("CMS_ScheduleStock_GetDetailList")

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            _db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)

            _db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, 1)

            Dim totDepoRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

            If totDepoRows > 0 Then



                _linkForm = New System.Windows.Forms.LinkLabel()

                _linkForm.Text = "Schedule Stock"
                _linkForm.Tag = "FrmScheduleStockSumm"

                _linkForm.AutoSize = True
                _linkForm.Padding = New Padding(0, 8, 0, 0)
                _linkForm.Font = New Font(_linkForm.Font, FontStyle.Bold)

                AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                'flpPending.Controls.Add(_linkForm)
                'tlpPending.Controls.Add(_linkForm)
                SetLinkLable(_linkForm)
            Else

                commProc.Parameters.Clear()

                _db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

                _db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)

                _db.AddInParameter(commProc, "@SCHEDULE_ID", DbType.Int32, 2)

                Dim totCollRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

                If totCollRows > 0 Then



                    _linkForm = New System.Windows.Forms.LinkLabel()
                    _linkForm.Text = "Schedule Stock"
                    _linkForm.Tag = "FrmScheduleStockSumm"
                    _linkForm.Font = New Font(_linkForm.Font, FontStyle.Bold)

                    AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                    'flpPending.Controls.Add(_linkForm)
                    'tlpPending.Controls.Add(_linkForm)
                    SetLinkLable(_linkForm)
                End If



            End If



        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    Private Sub BuildDepositSchedulePendingLink()

        Try

            Dim commProc As DbCommand = _db.GetStoredProcCommand("CMS_DCollected_GetDetailList")

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            _db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)

            _db.AddInParameter(commProc, "@ENTRY_DATE", DbType.DateTime, Date.Today) '-- no use here



            Dim totDepoRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

            If totDepoRows > 0 Then



                _linkForm = New System.Windows.Forms.LinkLabel()
                _linkForm.Text = "Deposit Schedule" + " Pending: " + totDepoRows.ToString()
                _linkForm.Tag = "FrmDepoScheSumm"

                _linkForm.AutoSize = True
                _linkForm.Padding = New Padding(0, 8, 0, 0)
                _linkForm.Font = New Font(_linkForm.Font, FontStyle.Bold)

                AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                'flpPending.Controls.Add(_linkForm)
                'tlpPending.Controls.Add(_linkForm)
                SetLinkLable(_linkForm)

            End If



        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub BuildOutstandingReversalPendingLink()

        Try

            Dim commProc As DbCommand = _db.GetStoredProcCommand("CMS_Reversal_Outstanding")

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@STATUS_ID", DbType.Int16, 1)

            _db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, NullHelper.StringToDate(Date.Today.ToString("dd/MM/yyyy")))

            _db.AddInParameter(commProc, "@AUTHORIZE", DbType.Int16, 0)

            _db.AddInParameter(commProc, "@DEPOSIT_TYPE", DbType.String, DBNull.Value)

            Dim totOpenRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@STATUS_ID", DbType.Int16, 2)

            _db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, NullHelper.StringToDate(Date.Today.ToString("dd/MM/yyyy")))

            _db.AddInParameter(commProc, "@AUTHORIZE", DbType.Int16, 0)

            _db.AddInParameter(commProc, "@DEPOSIT_TYPE", DbType.String, DBNull.Value)

            Dim totOutRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count


            If totOpenRows + totOutRows > 0 Then



                _linkForm = New System.Windows.Forms.LinkLabel()
                _linkForm.Text = "Outstanding Reversal" + " Pending: " + (totOpenRows + totOutRows).ToString()
                _linkForm.Tag = "FrmReversalOutstanding"

                _linkForm.AutoSize = True
                _linkForm.Padding = New Padding(0, 8, 0, 0)
                _linkForm.Font = New Font(_linkForm.Font, FontStyle.Bold)

                AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                'flpPending.Controls.Add(_linkForm)
                'tlpPending.Controls.Add(_linkForm)
                SetLinkLable(_linkForm)

            End If



        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BuildDDPendingLink()

        Try

            Dim commProc As DbCommand = _db.GetStoredProcCommand("CMS_DD_GetDetailList")

            commProc.Parameters.Clear()

            _db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)

            Dim totRows As Integer = _db.ExecuteDataSet(commProc).Tables(0).Rows.Count

            If totRows > 0 Then


                _linkForm = New System.Windows.Forms.LinkLabel()
                _linkForm.Text = "DD" + " Pending: " + totRows.ToString()
                _linkForm.Tag = "FrmDDSumm"

                _linkForm.AutoSize = True
                _linkForm.Padding = New Padding(0, 8, 0, 0)
                _linkForm.Font = New Font(_linkForm.Font, FontStyle.Bold)

                AddHandler _linkForm.Click, AddressOf LinkLabelClickHandler

                'flpPending.Controls.Add(_linkForm)

                'tlpPending.Controls.Add(_linkForm)
                SetLinkLable(_linkForm)

            End If



        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub





    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub


    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadList.Click
        'LoadFormList()


        BackgroundWorker1.RunWorkerAsync()
        ProgressBar1.Style = ProgressBarStyle.Marquee
        btnLoadList.Enabled = False

        'trd = New Thread(AddressOf LoadFormList)
        'trd.IsBackground = True
        'trd.Start()
        'ProgressBar1.Style = ProgressBarStyle.Marquee

        'tlpPending.


        ' Defined in the declarations section of frmMain
        'Private mobjFileSearch As FileSearch
        ' Code omitted for clarity
        'mobjFileSearch = New FileSearch(Me.cboLookIn.Text, Me.txtFileName.Text)
        'Dim cb As New AsyncCallback(AddressOf Me.OnFindComplete)
        'Dim del As New LoadFormListDelegate(AddressOf LoadFormList)
        'del.BeginInvoke(cb, del)

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        LoadFormList()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous
        'btnLoadList.Enabled = True

    End Sub


End Class