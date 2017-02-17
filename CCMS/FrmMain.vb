Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Winforms.Components.ApplicationIdleData
Imports System.IO
Imports System.Data.OleDb

Public Class FrmMain

#Region "Global Variables"

    Private _hostForm As FrmLogin
    Dim _menuname As String
    Dim _isvisible As Boolean
    Dim _enable As Boolean
    Dim frmUpWait As New FrmUpWait
    Dim filePath As String = ""
    Dim log_mesage As String = ""
    Dim collectionUpCompleted As Boolean = False
    Dim clearingUpCompleted As Boolean = False
    Dim collectionUpErr As String = ""
    Dim clearingUpErr As String = ""
#End Region


#Region "User defined code"


    Private Sub LoadMenuSec()

        Dim user = CommonAppSet.User
        Dim db As New SqlDatabase(CommonAppSet.ConnStr)
        Dim i As Integer
        Dim ds As New DataSet
        Dim comProc As DbCommand = db.GetStoredProcCommand("CMS_Users_FunMenuPermission")
        db.AddInParameter(comProc, "@USERS_ID", DbType.String, user)

        ds = db.ExecuteDataSet(comProc)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            _menuname = ds.Tables(0).Rows(i)("MENU_NAME").ToString()
            _isvisible = ds.Tables(0).Rows(i)("IS_VISIBLE").ToString()
            _enable = ds.Tables(0).Rows(i)("IS_ENABLE").ToString
            MenuPerm()

        Next

        LoadAdminMenu()

    End Sub


    Private Sub LoadAdminMenu()
        If CommonAppSet.IsAdmin = True Then

            Me.mnuSystem.Visible = True
            Me.mnuSystem.Enabled = True
            Me.mnuSysDeptDet.Visible = True
            Me.mnuSysDeptDet.Enabled = True
            Me.mnuSysDeptSum.Visible = True
            Me.mnuSysDeptSum.Enabled = True
            Me.mnuSysUserDet.Visible = True
            Me.mnuSysUserDet.Enabled = True
            Me.mnuSysUserSum.Visible = True
            Me.mnuSysUserSum.Enabled = True
            Me.mnuSysFGDet.Visible = True
            Me.mnuSysFGDet.Enabled = True
            Me.mnuSysFGSum.Visible = True
            Me.mnuSysFGSum.Enabled = True
            Me.mnuSysFGToUserDet.Visible = True
            Me.mnuSysFGToUserDet.Enabled = True
            'Me.mnuSysFGtoUserDet.Visible = False
            Me.mnuSysFGToUserSum.Visible = True
            Me.mnuSysFGToUserSum.Enabled = True
            Me.mnuSysReportUsersRole.Visible = True
            Me.mnuSysReportUsersRole.Enabled = True
            Me.mnuSysReportActivityLog.Visible = True
            Me.mnuSysReportActivityLog.Enabled = True

            Me.mnuSysReportRolePermMenu.Visible = True
            Me.mnuSysReportRolePermMenu.Enabled = True
            Me.mnuSysReportRolePermForm.Visible = True
            Me.mnuSysReportRolePermForm.Enabled = True
            Me.mnuSysReportInactivity.Visible = True
            Me.mnuSysReportInactivity.Enabled = True

            Me.mnuSysEERSExport.Visible = True
            Me.mnuSysEERSExport.Enabled = True

        End If

    End Sub


    Private Sub MenuPerm()
        Select Case _menuname

            Case "Maintenance"
                If _isvisible = True Then
                    Me.mnuMaintenance.Visible = True
                    If _enable = True Then
                        Me.mnuMaintenance.Enabled = True
                    Else
                        Me.mnuMaintenance.Enabled = False
                    End If
                Else
                    Me.mnuMaintenance.Visible = False
                End If

            Case "MaintenanceClientDetail"
                If _isvisible = True Then
                    Me.mnuMainClientDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainClientDet.Enabled = True
                    Else
                        Me.mnuMainClientDet.Enabled = False
                    End If
                Else
                    Me.mnuMainClientDet.Visible = False
                End If

            Case "MaintenanceClientSummary"
                If _isvisible = True Then
                    Me.mnuMainClientSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainClientSum.Enabled = True
                    Else
                        Me.mnuMainClientSum.Enabled = False
                    End If
                Else
                    Me.mnuMainClientSum.Visible = False
                End If




            Case "MaintenanceBankDetail"
                If _isvisible = True Then
                    Me.mnuMainBankDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainBankDet.Enabled = True
                    Else
                        Me.mnuMainBankDet.Enabled = False
                    End If
                Else
                    Me.mnuMainBankDet.Visible = False
                End If

            Case "MaintenanceBankSummary"
                If _isvisible = True Then
                    Me.mnuMainBankSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainBankSum.Enabled = True
                    Else
                        Me.mnuMainBankSum.Enabled = False
                    End If
                Else
                    Me.mnuMainBankSum.Visible = False
                End If

            Case "MaintenanceBranchDetail"
                If _isvisible = True Then
                    Me.mnuMainBranchDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainBranchDet.Enabled = True
                    Else
                        Me.mnuMainBranchDet.Enabled = False
                    End If
                Else
                    Me.mnuMainBranchDet.Visible = False
                End If

            Case "MaintenanceBranchSummary"

                If _isvisible = True Then
                    Me.mnuMainBranchSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainBranchSum.Enabled = True
                    Else
                        Me.mnuMainBranchSum.Enabled = False
                    End If
                Else
                    Me.mnuMainBranchSum.Visible = False
                End If


            Case "MaintenanceLocationDetail"
                If _isvisible = True Then
                    Me.mnuMainLocationDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainLocationDet.Enabled = True
                    Else
                        Me.mnuMainLocationDet.Enabled = False
                    End If
                Else
                    Me.mnuMainLocationDet.Visible = False
                End If

            Case "MaintenanceLocationSummary"

                If _isvisible = True Then
                    Me.mnuMainLocationSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainLocationSum.Enabled = True
                    Else
                        Me.mnuMainLocationSum.Enabled = False
                    End If
                Else
                    Me.mnuMainLocationSum.Visible = False
                End If



            Case "MaintenanceZoneDetail"
                If _isvisible = True Then
                    Me.mnuMainZoneDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainZoneDet.Enabled = True
                    Else
                        Me.mnuMainZoneDet.Enabled = False
                    End If
                Else
                    Me.mnuMainZoneDet.Visible = False
                End If

            Case "MaintenanceZoneSummary"

                If _isvisible = True Then
                    Me.mnuMainZoneSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainZoneSum.Enabled = True
                    Else
                        Me.mnuMainZoneSum.Enabled = False
                    End If
                Else
                    Me.mnuMainZoneSum.Visible = False
                End If


            Case "MaintenanceReturnDetail"
                If _isvisible = True Then
                    Me.mnuMainRejectDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainRejectDet.Enabled = True
                    Else
                        Me.mnuMainRejectDet.Enabled = False
                    End If
                Else
                    Me.mnuMainRejectDet.Visible = False
                End If

            Case "MaintenanceReturnSummary"

                If _isvisible = True Then
                    Me.mnuMainRejectSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainRejectSum.Enabled = True
                    Else
                        Me.mnuMainRejectSum.Enabled = False
                    End If
                Else
                    Me.mnuMainRejectSum.Visible = False
                End If

            Case "MaintenanceChequeTypeDetail"
                If _isvisible = True Then
                    Me.mnuMainChequeTypeDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainChequeTypeDet.Enabled = True
                    Else
                        Me.mnuMainChequeTypeDet.Enabled = False
                    End If
                Else
                    Me.mnuMainChequeTypeDet.Visible = False
                End If

            Case "MaintenanceChequeTypeSummary"

                If _isvisible = True Then
                    Me.mnuMainChequeTypeSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainChequeTypeSum.Enabled = True
                    Else
                        Me.mnuMainChequeTypeSum.Enabled = False
                    End If
                Else
                    Me.mnuMainChequeTypeSum.Visible = False
                End If

            Case "MaintenanceHolidayDetail"
                If _isvisible = True Then
                    Me.mnuMainHolidayDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainHolidayDet.Enabled = True
                    Else
                        Me.mnuMainHolidayDet.Enabled = False
                    End If
                Else
                    Me.mnuMainHolidayDet.Visible = False
                End If

            Case "MaintenanceHolidaySummary"

                If _isvisible = True Then
                    Me.mnuMainHolidaySum.Visible = True
                    If _enable = True Then
                        Me.mnuMainHolidaySum.Enabled = True
                    Else
                        Me.mnuMainHolidaySum.Enabled = False
                    End If
                Else
                    Me.mnuMainHolidaySum.Visible = False
                End If

            Case "MaintenanceScheduleStockDetail"
                If _isvisible = True Then
                    Me.mnuMainDepositStockDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainDepositStockDet.Enabled = True
                    Else
                        Me.mnuMainDepositStockDet.Enabled = False
                    End If
                Else
                    Me.mnuMainDepositStockDet.Visible = False
                End If

            Case "MaintenanceScheduleStockSummary"

                If _isvisible = True Then
                    Me.mnuMainDepositStockSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainDepositStockSum.Enabled = True
                    Else
                        Me.mnuMainDepositStockSum.Enabled = False
                    End If
                Else
                    Me.mnuMainDepositStockSum.Visible = False
                End If


            Case "MaintenanceCitiBankBranchDetail"
                If _isvisible = True Then
                    Me.mnuMainCitiBranchDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainCitiBranchDet.Enabled = True
                    Else
                        Me.mnuMainCitiBranchDet.Enabled = False
                    End If
                Else
                    Me.mnuMainCitiBranchDet.Visible = False
                End If

            Case "MaintenanceCitiBankBranchSummary"

                If _isvisible = True Then
                    Me.mnuMainCitiBranchSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainCitiBranchSum.Enabled = True
                    Else
                        Me.mnuMainCitiBranchSum.Enabled = False
                    End If
                Else
                    Me.mnuMainCitiBranchSum.Visible = False
                End If



            Case "MaintenanceClearingClientDetail"
                If _isvisible = True Then
                    Me.mnuMainClearClientDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainClearClientDet.Enabled = True
                    Else
                        Me.mnuMainClearClientDet.Enabled = False
                    End If
                Else
                    Me.mnuMainClearClientDet.Visible = False
                End If

            Case "MaintenanceClearingClientSummary"

                If _isvisible = True Then
                    Me.mnuMainClearClientSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainClearClientSum.Enabled = True
                    Else
                        Me.mnuMainClearClientSum.Enabled = False
                    End If
                Else
                    Me.mnuMainClearClientSum.Visible = False
                End If



            Case "MaintenanceClearingBankDetail"
                If _isvisible = True Then
                    Me.mnuMainClearBankDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainClearBankDet.Enabled = True
                    Else
                        Me.mnuMainClearBankDet.Enabled = False
                    End If
                Else
                    Me.mnuMainClearBankDet.Visible = False
                End If

            Case "MaintenanceClearingBankSummary"

                If _isvisible = True Then
                    Me.mnuMainClearBankSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainClearBankSum.Enabled = True
                    Else
                        Me.mnuMainClearBankSum.Enabled = False
                    End If
                Else
                    Me.mnuMainClearBankSum.Visible = False
                End If



            Case "MaintenanceClearingBranchDetail"
                If _isvisible = True Then
                    Me.mnuMainClearBranchDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainClearBranchDet.Enabled = True
                    Else
                        Me.mnuMainClearBranchDet.Enabled = False
                    End If
                Else
                    Me.mnuMainClearBranchDet.Visible = False
                End If

            Case "MaintenanceClearingBranchSummary"

                If _isvisible = True Then
                    Me.mnuMainClearBranchSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainClearBranchSum.Enabled = True
                    Else
                        Me.mnuMainClearBranchSum.Enabled = False
                    End If
                Else
                    Me.mnuMainClearBranchSum.Visible = False
                End If


                'Case "MaintenanceClearingLocationDetail"
                '    If _isvisible = True Then
                '        Me.mnuMainClearLocationDet.Visible = True
                '        If _enable = True Then
                '            Me.mnuMainClearLocationDet.Enabled = True
                '        Else
                '            Me.mnuMainClearLocationDet.Enabled = False
                '        End If
                '    Else
                '        Me.mnuMainClearLocationDet.Visible = False
                '    End If

                'Case "MaintenanceClearingLocationSummary"

                '    If _isvisible = True Then
                '        Me.mnuMainClearLocationSum.Visible = True
                '        If _enable = True Then
                '            Me.mnuMainClearLocationSum.Enabled = True
                '        Else
                '            Me.mnuMainClearLocationSum.Enabled = False
                '        End If
                '    Else
                '        Me.mnuMainClearLocationSum.Visible = False
                '    End If

            Case "MaintenanceFlexAccountDetail"
                If _isvisible = True Then
                    Me.mnuMainFlexAccDet.Visible = True
                    If _enable = True Then
                        Me.mnuMainFlexAccDet.Enabled = True
                    Else
                        Me.mnuMainFlexAccDet.Enabled = False
                    End If
                Else
                    Me.mnuMainFlexAccDet.Visible = False
                End If

            Case "MaintenanceFlexAccountSummary"

                If _isvisible = True Then
                    Me.mnuMainFlexAccSum.Visible = True
                    If _enable = True Then
                        Me.mnuMainFlexAccSum.Enabled = True
                    Else
                        Me.mnuMainFlexAccSum.Enabled = False
                    End If
                Else
                    Me.mnuMainFlexAccSum.Visible = False
                End If

            Case "MaintenanceEmailSettingDetail"

                If _isvisible = True Then
                    Me.mnuMaintenanceEmailSettingDetail.Visible = True
                    If _enable = True Then
                        Me.mnuMaintenanceEmailSettingDetail.Enabled = True
                    Else
                        Me.mnuMaintenanceEmailSettingDetail.Enabled = False
                    End If
                Else
                    Me.mnuMaintenanceEmailSettingDetail.Visible = False
                End If

            Case "MaintenanceEmailSettingSummary"

                If _isvisible = True Then
                    Me.mnuMaintenanceEmailSettingSummary.Visible = True
                    If _enable = True Then
                        Me.mnuMaintenanceEmailSettingSummary.Enabled = True
                    Else
                        Me.mnuMaintenanceEmailSettingSummary.Enabled = False
                    End If
                Else
                    Me.mnuMaintenanceEmailSettingSummary.Visible = False
                End If


            Case "Deposit"
                If _isvisible = True Then
                    Me.mnuDeposit.Visible = True
                    If _enable = True Then
                        Me.mnuDeposit.Enabled = True
                    Else
                        Me.mnuDeposit.Enabled = False
                    End If
                Else
                    Me.mnuDeposit.Visible = False
                End If

            Case "DepositScheduleDetail"
                If _isvisible = True Then
                    Me.mnuDepoScheDet.Visible = True
                    If _enable = True Then
                        Me.mnuDepoScheDet.Enabled = True
                    Else
                        Me.mnuDepoScheDet.Enabled = False
                    End If
                Else
                    Me.mnuDepoScheDet.Visible = False
                End If

            Case "DepositScheduleSummary"

                If _isvisible = True Then
                    Me.mnuDepoScheSum.Visible = True
                    If _enable = True Then
                        Me.mnuDepoScheSum.Enabled = True
                    Else
                        Me.mnuDepoScheSum.Enabled = False
                    End If
                Else
                    Me.mnuDepoScheSum.Visible = False
                End If

            Case "DepositScheduleMismatchTotal"

                If _isvisible = True Then
                    Me.mnuDepoScheMismatchTotal.Visible = True
                    If _enable = True Then
                        Me.mnuDepoScheMismatchTotal.Enabled = True
                    Else
                        Me.mnuDepoScheMismatchTotal.Enabled = False
                    End If
                Else
                    Me.mnuDepoScheMismatchTotal.Visible = False
                End If

            Case "DepositScheduleMismatchCashSpeed"

                If _isvisible = True Then
                    Me.mnuDepoScheMissingDetail.Visible = True
                    If _enable = True Then
                        Me.mnuDepoScheMissingDetail.Enabled = True
                    Else
                        Me.mnuDepoScheMissingDetail.Enabled = False
                    End If
                Else
                    Me.mnuDepoScheMissingDetail.Visible = False
                End If

            Case "DepositCitiCashDetail"
                If _isvisible = True Then
                    Me.mnuDepositCashDet.Visible = True
                    If _enable = True Then
                        Me.mnuDepositCashDet.Enabled = True
                    Else
                        Me.mnuDepositCashDet.Enabled = False
                    End If
                Else
                    Me.mnuDepositCashDet.Visible = False
                End If

            Case "DepositCitiCashSummary"

                If _isvisible = True Then
                    Me.mnuDepositCashSum.Visible = True
                    If _enable = True Then
                        Me.mnuDepositCashSum.Enabled = True
                    Else
                        Me.mnuDepositCashSum.Enabled = False
                    End If
                Else
                    Me.mnuDepositCashSum.Visible = False
                End If

            Case "DepositCitiSpeedDetail"
                If _isvisible = True Then
                    Me.mnuDepositSpeedDet.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSpeedDet.Enabled = True
                    Else
                        Me.mnuDepositSpeedDet.Enabled = False
                    End If
                Else
                    Me.mnuDepositSpeedDet.Visible = False
                End If

            Case "DepositCitiSpeedSummary"

                If _isvisible = True Then
                    Me.mnuDepositSpeedSum.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSpeedSum.Enabled = True
                    Else
                        Me.mnuDepositSpeedSum.Enabled = False
                    End If
                Else
                    Me.mnuDepositSpeedSum.Visible = False
                End If

            Case "DepositCitiSpeedMismatchTotal"

                If _isvisible = True Then
                    Me.mnuDepositSpeedMismatchTotal.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSpeedMismatchTotal.Enabled = True
                    Else
                        Me.mnuDepositSpeedMismatchTotal.Enabled = False
                    End If
                Else
                    Me.mnuDepositSpeedMismatchTotal.Visible = False
                End If


            Case "DepositCitiAnywhereDetail"
                If _isvisible = True Then
                    Me.mnuDepositCheckDet.Visible = True
                    If _enable = True Then
                        Me.mnuDepositCheckDet.Enabled = True
                    Else
                        Me.mnuDepositCheckDet.Enabled = False
                    End If
                Else
                    Me.mnuDepositCheckDet.Visible = False
                End If

            Case "DepositCitiAnywhereSummary"

                If _isvisible = True Then
                    Me.mnuDepositCheckSum.Visible = True
                    If _enable = True Then
                        Me.mnuDepositCheckSum.Enabled = True
                    Else
                        Me.mnuDepositCheckSum.Enabled = False
                    End If
                Else
                    Me.mnuDepositCheckSum.Visible = False
                End If

            Case "DepositCitiAnywhereCollectionProc"

                If _isvisible = True Then
                    Me.mnuDepositCollectionProcess.Visible = True
                    If _enable = True Then
                        Me.mnuDepositCollectionProcess.Enabled = True
                    Else
                        Me.mnuDepositCollectionProcess.Enabled = False
                    End If
                Else
                    Me.mnuDepositCollectionProcess.Visible = False
                End If

            Case "DepositCitiAnywhereReminderProc"

                If _isvisible = True Then
                    Me.mnuDepositReminder.Visible = True
                    If _enable = True Then
                        Me.mnuDepositReminder.Enabled = True
                    Else
                        Me.mnuDepositReminder.Enabled = False
                    End If
                Else
                    Me.mnuDepositReminder.Visible = False
                End If

            Case "DepositCitiAnywhereFundingFile"

                If _isvisible = True Then
                    Me.mnuDepositCitiAnyFunding.Visible = True
                    If _enable = True Then
                        Me.mnuDepositCitiAnyFunding.Enabled = True
                    Else
                        Me.mnuDepositCitiAnyFunding.Enabled = False
                    End If
                Else
                    Me.mnuDepositCitiAnyFunding.Visible = False
                End If

            Case "DepositFlexFile"

                If _isvisible = True Then
                    Me.mnuDepositFlex.Visible = True
                    If _enable = True Then
                        Me.mnuDepositFlex.Enabled = True
                    Else
                        Me.mnuDepositFlex.Enabled = False
                    End If
                Else
                    Me.mnuDepositFlex.Visible = False
                End If

            Case "DepositOutstandingReversal"

                If _isvisible = True Then
                    Me.mnuDepositOutstanding.Visible = True
                    If _enable = True Then
                        Me.mnuDepositOutstanding.Enabled = True
                    Else
                        Me.mnuDepositOutstanding.Enabled = False
                    End If
                Else
                    Me.mnuDepositOutstanding.Visible = False
                End If
            Case "DepositFlexReversalFile"

                If _isvisible = True Then
                    Me.mnuDepositFlexRev.Visible = True
                    If _enable = True Then
                        Me.mnuDepositFlexRev.Enabled = True
                    Else
                        Me.mnuDepositFlexRev.Enabled = False
                    End If
                Else
                    Me.mnuDepositFlexRev.Visible = False
                End If

            Case "DepositExportGoAml"

                If _isvisible = True Then
                    Me.mnuDepositExportGoAml.Visible = True
                    If _enable = True Then
                        Me.mnuDepositExportGoAml.Enabled = True
                    Else
                        Me.mnuDepositExportGoAml.Enabled = False
                    End If
                Else
                    Me.mnuDepositExportGoAml.Visible = False
                End If


            Case "DepositSameDayMIS"

                If _isvisible = True Then
                    Me.mnuDepositSameDayMIS.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSameDayMIS.Enabled = True
                    Else
                        Me.mnuDepositSameDayMIS.Enabled = False
                    End If
                Else
                    Me.mnuDepositSameDayMIS.Visible = False
                End If

            Case "DepositSameDayMisDetail"

                If _isvisible = True Then
                    Me.mnuDepositSameDayMisDetail.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSameDayMisDetail.Enabled = True
                    Else
                        Me.mnuDepositSameDayMisDetail.Enabled = False
                    End If
                Else
                    Me.mnuDepositSameDayMisDetail.Visible = False
                End If

            Case "DepositSameDayMisSummary"

                If _isvisible = True Then
                    Me.mnuDepositSameDayMisSummary.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSameDayMisSummary.Enabled = True
                    Else
                        Me.mnuDepositSameDayMisSummary.Enabled = False
                    End If
                Else
                    Me.mnuDepositSameDayMisSummary.Visible = False
                End If

            Case "DepositSameDayMISUpload"

                If _isvisible = True Then
                    Me.mnuDepositSameDayMISUpload.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSameDayMISUpload.Enabled = True
                    Else
                        Me.mnuDepositSameDayMISUpload.Enabled = False
                    End If
                Else
                    Me.mnuDepositSameDayMISUpload.Visible = False
                End If

            Case "DepositSameDayMisProcess"

                If _isvisible = True Then
                    Me.mnuDepositSameDayMisProcess.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSameDayMisProcess.Enabled = True
                    Else
                        Me.mnuDepositSameDayMisProcess.Enabled = False
                    End If
                Else
                    Me.mnuDepositSameDayMisProcess.Visible = False
                End If

            Case "DepositSameDayMISReport"

                If _isvisible = True Then
                    Me.mnuDepositSameDayMISReport.Visible = True
                    If _enable = True Then
                        Me.mnuDepositSameDayMISReport.Enabled = True
                    Else
                        Me.mnuDepositSameDayMISReport.Enabled = False
                    End If
                Else
                    Me.mnuDepositSameDayMISReport.Visible = False
                End If

            Case "DepositSameDayMISEmailHistory"

                If _isvisible = True Then
                    Me.mnuMaintenanceEmailSettingSummary.Visible = True
                    If _enable = True Then
                        Me.mnuMaintenanceEmailSettingSummary.Enabled = True
                    Else
                        Me.mnuMaintenanceEmailSettingSummary.Enabled = False
                    End If
                Else
                    Me.mnuMaintenanceEmailSettingSummary.Visible = False
                End If


            Case "Collection"
                If _isvisible = True Then
                    Me.mnuCollection.Visible = True
                    If _enable = True Then
                        Me.mnuCollection.Enabled = True
                    Else
                        Me.mnuCollection.Enabled = False
                    End If
                Else
                    Me.mnuCollection.Visible = False
                End If

            Case "CollectionScheduleDetail"
                If _isvisible = True Then
                    Me.mnuCollScheduleDet.Visible = True
                    If _enable = True Then
                        Me.mnuCollScheduleDet.Enabled = True
                    Else
                        Me.mnuCollScheduleDet.Enabled = False
                    End If
                Else
                    Me.mnuCollScheduleDet.Visible = False
                End If



            Case "CollectionScheduleSummary"

                If _isvisible = True Then
                    Me.mnuCollScheduleSum.Visible = True
                    If _enable = True Then
                        Me.mnuCollScheduleSum.Enabled = True
                    Else
                        Me.mnuCollScheduleSum.Enabled = False
                    End If
                Else
                    Me.mnuCollScheduleSum.Visible = False
                End If

            Case "CollectionDDDetail"
                If _isvisible = True Then
                    Me.mnuCollDDDet.Visible = True
                    If _enable = True Then
                        Me.mnuCollDDDet.Enabled = True
                    Else
                        Me.mnuCollDDDet.Enabled = False
                    End If
                Else
                    Me.mnuCollDDDet.Visible = False
                End If

            Case "CollectionDDSummary"

                If _isvisible = True Then
                    Me.mnuCollDDSum.Visible = True
                    If _enable = True Then
                        Me.mnuCollDDSum.Enabled = True
                    Else
                        Me.mnuCollDDSum.Enabled = False
                    End If
                Else
                    Me.mnuCollDDSum.Visible = False
                End If


            Case "CollectionCitiSpeedReturnDetail"
                If _isvisible = True Then
                    Me.mnuCollSpeedReturnDet.Visible = True
                    If _enable = True Then
                        Me.mnuCollSpeedReturnDet.Enabled = True
                    Else
                        Me.mnuCollSpeedReturnDet.Enabled = False
                    End If
                Else
                    Me.mnuCollSpeedReturnDet.Visible = False
                End If

            Case "CollectionCitiSpeedReturnSummary"

                If _isvisible = True Then
                    Me.mnuCollSpeedReturnSum.Visible = True
                    If _enable = True Then
                        Me.mnuCollSpeedReturnSum.Enabled = True
                    Else
                        Me.mnuCollSpeedReturnSum.Enabled = False
                    End If
                Else
                    Me.mnuCollSpeedReturnSum.Visible = False
                End If



            Case "CollectionCitiAnywhereReturnDetail"
                If _isvisible = True Then
                    Me.mnuCollNormalDet.Visible = True
                    If _enable = True Then
                        Me.mnuCollNormalDet.Enabled = True
                    Else
                        Me.mnuCollNormalDet.Enabled = False
                    End If
                Else
                    Me.mnuCollNormalDet.Visible = False
                End If

            Case "CollectionCitiAnywhereReturnSummary"

                If _isvisible = True Then
                    Me.mnuCollNormalSum.Visible = True
                    If _enable = True Then
                        Me.mnuCollNormalSum.Enabled = True
                    Else
                        Me.mnuCollNormalSum.Enabled = False
                    End If
                Else
                    Me.mnuCollNormalSum.Visible = False
                End If


            Case "CollectionCitiSpeedReturnFile"

                If _isvisible = True Then
                    Me.mnuCollectionCitiSpeedReturnFile.Visible = True
                    If _enable = True Then
                        Me.mnuCollectionCitiSpeedReturnFile.Enabled = True
                    Else
                        Me.mnuCollectionCitiSpeedReturnFile.Enabled = False
                    End If
                Else
                    Me.mnuCollectionCitiSpeedReturnFile.Visible = False
                End If

            Case "GuaranteedCreditBooking"

                If _isvisible = True Then
                    Me.mnuGuaranteedCreditBooking.Visible = True
                    If _enable = True Then
                        Me.mnuGuaranteedCreditBooking.Enabled = True
                    Else
                        Me.mnuGuaranteedCreditBooking.Enabled = False
                    End If
                Else
                    Me.mnuGuaranteedCreditBooking.Visible = False
                End If



            Case "Clearing"
                If _isvisible = True Then
                    Me.mnuClearing.Visible = True
                    If _enable = True Then
                        Me.mnuClearing.Enabled = True
                    Else
                        Me.mnuClearing.Enabled = False
                    End If
                Else
                    Me.mnuClearing.Visible = False
                End If

            Case "ClearingCheckDetail"
                If _isvisible = True Then
                    Me.mnuClearingCheckDet.Visible = True
                    If _enable = True Then
                        Me.mnuClearingCheckDet.Enabled = True
                    Else
                        Me.mnuClearingCheckDet.Enabled = False
                    End If
                Else
                    Me.mnuClearingCheckDet.Visible = False
                End If

            Case "ClearingCheckSummary"

                If _isvisible = True Then
                    Me.mnuClearingCheckSum.Visible = True
                    If _enable = True Then
                        Me.mnuClearingCheckSum.Enabled = True
                    Else
                        Me.mnuClearingCheckSum.Enabled = False
                    End If
                Else
                    Me.mnuClearingCheckSum.Visible = False
                End If

            Case "ClearingSetClearingDate"

                If _isvisible = True Then
                    Me.mnuClearingSetDate.Visible = True
                    If _enable = True Then
                        Me.mnuClearingSetDate.Enabled = True
                    Else
                        Me.mnuClearingSetDate.Enabled = False
                    End If
                Else
                    Me.mnuClearingSetDate.Visible = False
                End If

            Case "ClearingUploadClearingCheck"

                If _isvisible = True Then
                    Me.mnuClearingUploadCheck.Visible = True
                    If _enable = True Then
                        Me.mnuClearingUploadCheck.Enabled = True
                    Else
                        Me.mnuClearingUploadCheck.Enabled = False
                    End If
                Else
                    Me.mnuClearingUploadCheck.Visible = False
                End If

            Case "ClearingFlexFile"

                If _isvisible = True Then
                    Me.mnuClearingFlex.Visible = True
                    If _enable = True Then
                        Me.mnuClearingFlex.Enabled = True
                    Else
                        Me.mnuClearingFlex.Enabled = False
                    End If
                Else
                    Me.mnuClearingFlex.Visible = False
                End If

            Case "ClearingFlexFileForReturnChecks"

                If _isvisible = True Then
                    Me.mnuClearingFlexReturn.Visible = True
                    If _enable = True Then
                        Me.mnuClearingFlexReturn.Enabled = True
                    Else
                        Me.mnuClearingFlexReturn.Enabled = False
                    End If
                Else
                    Me.mnuClearingFlexReturn.Visible = False
                End If

            Case "ClearingDDCheckProcess"

                If _isvisible = True Then
                    Me.mnuClearingDDProcess.Visible = True
                    If _enable = True Then
                        Me.mnuClearingDDProcess.Enabled = True
                    Else
                        Me.mnuClearingDDProcess.Enabled = False
                    End If
                Else
                    Me.mnuClearingDDProcess.Visible = False
                End If



            Case "ClearingPDCCheckDetail"
                If _isvisible = True Then
                    Me.mnuClearingPDCDet.Visible = True
                    If _enable = True Then
                        Me.mnuClearingPDCDet.Enabled = True
                    Else
                        Me.mnuClearingPDCDet.Enabled = False
                    End If
                Else
                    Me.mnuClearingPDCDet.Visible = False
                End If

            Case "ClearingPDCCheckSummary"

                If _isvisible = True Then
                    Me.mnuClearingPDCSum.Visible = True
                    If _enable = True Then
                        Me.mnuClearingPDCSum.Enabled = True
                    Else
                        Me.mnuClearingPDCSum.Enabled = False
                    End If
                Else
                    Me.mnuClearingPDCSum.Visible = False
                End If

            Case "ClearingPDCTransfer"

                If _isvisible = True Then
                    Me.mnuClearingPDCTrans.Visible = True
                    If _enable = True Then
                        Me.mnuClearingPDCTrans.Enabled = True
                    Else
                        Me.mnuClearingPDCTrans.Enabled = False
                    End If
                Else
                    Me.mnuClearingPDCTrans.Visible = False
                End If


            Case "ClearingCheckReturnDetail"
                If _isvisible = True Then
                    Me.mnuClearingCheckRetDet.Visible = True
                    If _enable = True Then
                        Me.mnuClearingCheckRetDet.Enabled = True
                    Else
                        Me.mnuClearingCheckRetDet.Enabled = False
                    End If
                Else
                    Me.mnuClearingCheckRetDet.Visible = False
                End If

            Case "ClearingCheckReturnSummary"

                If _isvisible = True Then
                    Me.mnuClearingCheckRetSum.Visible = True
                    If _enable = True Then
                        Me.mnuClearingCheckRetSum.Enabled = True
                    Else
                        Me.mnuClearingCheckRetSum.Enabled = False
                    End If
                Else
                    Me.mnuClearingCheckRetSum.Visible = False
                End If



            Case "ClearingReturnFileUpload"

                If _isvisible = True Then
                    Me.mnuClearingUploadRet.Visible = True
                    If _enable = True Then
                        Me.mnuClearingUploadRet.Enabled = True
                    Else
                        Me.mnuClearingUploadRet.Enabled = False
                    End If
                Else
                    Me.mnuClearingUploadRet.Visible = False
                End If


            Case "ClearingTransferDataToHistory"

                If _isvisible = True Then
                    Me.mnuClearingTransferToHist.Visible = True
                    If _enable = True Then
                        Me.mnuClearingTransferToHist.Enabled = True
                    Else
                        Me.mnuClearingTransferToHist.Enabled = False
                    End If
                Else
                    Me.mnuClearingTransferToHist.Visible = False
                End If

            Case "Report"
                If _isvisible = True Then
                    Me.mnuReport.Visible = True
                    If _enable = True Then
                        Me.mnuReport.Enabled = True
                    Else
                        Me.mnuReport.Enabled = False
                    End If
                Else
                    Me.mnuReport.Visible = False
                End If

            Case "ReportManifoldChecksForCollection"

                If _isvisible = True Then
                    Me.mnuReportManiCollection.Visible = True
                    If _enable = True Then
                        Me.mnuReportManiCollection.Enabled = True
                    Else
                        Me.mnuReportManiCollection.Enabled = False
                    End If
                Else
                    Me.mnuReportManiCollection.Visible = False
                End If


            Case "ReportManifoldChecksForReminder"

                If _isvisible = True Then
                    Me.mnuReportManiReminder.Visible = True
                    If _enable = True Then
                        Me.mnuReportManiReminder.Enabled = True
                    Else
                        Me.mnuReportManiReminder.Enabled = False
                    End If
                Else
                    Me.mnuReportManiReminder.Visible = False
                End If


            Case "ReportManifoldCitiAnywhereFundingDD"

                If _isvisible = True Then
                    Me.mnuReportManiDDDeposit.Visible = True
                    If _enable = True Then
                        Me.mnuReportManiDDDeposit.Enabled = True
                    Else
                        Me.mnuReportManiDDDeposit.Enabled = False
                    End If
                Else
                    Me.mnuReportManiDDDeposit.Visible = False
                End If


            Case "ReportManifoldCitiAnywhereReturn"

                If _isvisible = True Then
                    Me.mnuReportManiAnywhereRet.Visible = True
                    If _enable = True Then
                        Me.mnuReportManiAnywhereRet.Enabled = True
                    Else
                        Me.mnuReportManiAnywhereRet.Enabled = False
                    End If
                Else
                    Me.mnuReportManiAnywhereRet.Visible = False
                End If


            Case "ReportReportsCitiCashSpeedSummary"

                If _isvisible = True Then
                    Me.mnuReportRepCashSpeedSumm.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepCashSpeedSumm.Enabled = True
                    Else
                        Me.mnuReportRepCashSpeedSumm.Enabled = False
                    End If
                Else
                    Me.mnuReportRepCashSpeedSumm.Visible = False
                End If

            Case "ReportReportsCitiCashDeposit"

                If _isvisible = True Then
                    Me.mnuReportRepCashDeposit.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepCashDeposit.Enabled = True
                    Else
                        Me.mnuReportRepCashDeposit.Enabled = False
                    End If
                Else
                    Me.mnuReportRepCashDeposit.Visible = False
                End If

            Case "ReportReportsCitiSpeedDeposit"

                If _isvisible = True Then
                    Me.mnuReportRepSpeedDeposit.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepSpeedDeposit.Enabled = True
                    Else
                        Me.mnuReportRepSpeedDeposit.Enabled = False
                    End If
                Else
                    Me.mnuReportRepSpeedDeposit.Visible = False
                End If


            Case "ReportReportsCitiSpeedReturn"

                If _isvisible = True Then
                    Me.mnuReportRepSpeedReturn.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepSpeedReturn.Enabled = True
                    Else
                        Me.mnuReportRepSpeedReturn.Enabled = False
                    End If
                Else
                    Me.mnuReportRepSpeedReturn.Visible = False
                End If

            Case "ReportReportsGuaranteedCreditBooking"

                If _isvisible = True Then
                    Me.mnuReportsGuaranteedCreditBooking.Visible = True
                    If _enable = True Then
                        Me.mnuReportsGuaranteedCreditBooking.Enabled = True
                    Else
                        Me.mnuReportsGuaranteedCreditBooking.Enabled = False
                    End If
                Else
                    Me.mnuReportsGuaranteedCreditBooking.Visible = False
                End If



            Case "ReportReportsCitiAnywhereDepositDetail"

                If _isvisible = True Then
                    Me.mnuReportRepAnywhereDepositDet.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepAnywhereDepositDet.Enabled = True
                    Else
                        Me.mnuReportRepAnywhereDepositDet.Enabled = False
                    End If
                Else
                    Me.mnuReportRepAnywhereDepositDet.Visible = False
                End If


            Case "ReportReportsCitiAnywhereProcessing"

                If _isvisible = True Then
                    Me.mnuReportRepAnywhereProcessing.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepAnywhereProcessing.Enabled = True
                    Else
                        Me.mnuReportRepAnywhereProcessing.Enabled = False
                    End If
                Else
                    Me.mnuReportRepAnywhereProcessing.Visible = False
                End If


            Case "ReportReportsCitiAnywhereFunding"

                If _isvisible = True Then
                    Me.mnuReportRepAnywhereFunding.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepAnywhereFunding.Enabled = True
                    Else
                        Me.mnuReportRepAnywhereFunding.Enabled = False
                    End If
                Else
                    Me.mnuReportRepAnywhereFunding.Visible = False
                End If


            Case "ReportReportsCitiAnywhereOutstanding"

                If _isvisible = True Then
                    Me.mnuReportRepAnywhereOutstanding.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepAnywhereOutstanding.Enabled = True
                    Else
                        Me.mnuReportRepAnywhereOutstanding.Enabled = False
                    End If
                Else
                    Me.mnuReportRepAnywhereOutstanding.Visible = False
                End If

            Case "ReportReportsDDBreakup"

                If _isvisible = True Then
                    Me.mnuReportRepDDBreakup.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepDDBreakup.Enabled = True
                    Else
                        Me.mnuReportRepDDBreakup.Enabled = False
                    End If
                Else
                    Me.mnuReportRepDDBreakup.Visible = False
                End If

            Case "ReportReportsMonthlyBillCashManagement"

                If _isvisible = True Then
                    Me.mnuReportRepMonthlyBillCash.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepMonthlyBillCash.Enabled = True
                    Else
                        Me.mnuReportRepMonthlyBillCash.Enabled = False
                    End If
                Else
                    Me.mnuReportRepMonthlyBillCash.Visible = False
                End If


            Case "ReportReportsDayZeroCashCheck"

                If _isvisible = True Then
                    Me.mnuReportRepDayZero.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepDayZero.Enabled = True
                    Else
                        Me.mnuReportRepDayZero.Enabled = False
                    End If
                Else
                    Me.mnuReportRepDayZero.Visible = False
                End If

            Case "ReportReportsClearingCheckSummary"

                If _isvisible = True Then
                    Me.mnuReportRepClearCheckSumm.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepClearCheckSumm.Enabled = True
                    Else
                        Me.mnuReportRepClearCheckSumm.Enabled = False
                    End If
                Else
                    Me.mnuReportRepClearCheckSumm.Visible = False
                End If

            Case "ReportReportsBankwiseDeliveryCheck"

                If _isvisible = True Then
                    Me.mnuReportRepBankwiseDelivery.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepBankwiseDelivery.Enabled = True
                    Else
                        Me.mnuReportRepBankwiseDelivery.Enabled = False
                    End If
                Else
                    Me.mnuReportRepBankwiseDelivery.Visible = False
                End If


            Case "ReportReportsHighValueCheck"

                If _isvisible = True Then
                    Me.mnuReportRepHighValueCheck.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepHighValueCheck.Enabled = True
                    Else
                        Me.mnuReportRepHighValueCheck.Enabled = False
                    End If
                Else
                    Me.mnuReportRepHighValueCheck.Visible = False
                End If


            Case "ReportReportsClearingDeposit"

                If _isvisible = True Then
                    Me.mnuReportRepClearDeposit.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepClearDeposit.Enabled = True
                    Else
                        Me.mnuReportRepClearDeposit.Enabled = False
                    End If
                Else
                    Me.mnuReportRepClearDeposit.Visible = False
                End If


            Case "ReportReportsClearingDepositDetail"

                If _isvisible = True Then
                    Me.mnuReportRepClearDepositDet.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepClearDepositDet.Enabled = True
                    Else
                        Me.mnuReportRepClearDepositDet.Enabled = False
                    End If
                Else
                    Me.mnuReportRepClearDepositDet.Visible = False
                End If


            Case "ReportReportsClearingReturn"

                If _isvisible = True Then
                    Me.mnuReportRepClearReturn.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepClearReturn.Enabled = True
                    Else
                        Me.mnuReportRepClearReturn.Enabled = False
                    End If
                Else
                    Me.mnuReportRepClearReturn.Visible = False
                End If


            Case "ReportReportsPDC"

                If _isvisible = True Then
                    Me.mnuReportRepPDC.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepPDC.Enabled = True
                    Else
                        Me.mnuReportRepPDC.Enabled = False
                    End If
                Else
                    Me.mnuReportRepPDC.Visible = False
                End If


            Case "ReportReportsHoliday"

                If _isvisible = True Then
                    Me.mnuReportRepHoliday.Visible = True
                    If _enable = True Then
                        Me.mnuReportRepHoliday.Enabled = True
                    Else
                        Me.mnuReportRepHoliday.Enabled = False
                    End If
                Else
                    Me.mnuReportRepHoliday.Visible = False
                End If


            Case "ReportControlsChecksCollectionReprint"

                If _isvisible = True Then
                    Me.mnuReportContCollectionReprint.Visible = True
                    If _enable = True Then
                        Me.mnuReportContCollectionReprint.Enabled = True
                    Else
                        Me.mnuReportContCollectionReprint.Enabled = False
                    End If
                Else
                    Me.mnuReportContCollectionReprint.Visible = False
                End If


            Case "ReportControlsDepositBreak"

                If _isvisible = True Then
                    Me.mnuReportContDepositBreak.Visible = True
                    If _enable = True Then
                        Me.mnuReportContDepositBreak.Enabled = True
                    Else
                        Me.mnuReportContDepositBreak.Enabled = False
                    End If
                Else
                    Me.mnuReportContDepositBreak.Visible = False
                End If

            Case "ReportControlsUnclearFund"

                If _isvisible = True Then
                    Me.mnuReportContUnclearFund.Visible = True
                    If _enable = True Then
                        Me.mnuReportContUnclearFund.Enabled = True
                    Else
                        Me.mnuReportContUnclearFund.Enabled = False
                    End If
                Else
                    Me.mnuReportContUnclearFund.Visible = False
                End If

            Case "ReportHistoryClearingCheckDetail"

                If _isvisible = True Then
                    Me.mnuReportHistClearCheckDet.Visible = True
                    If _enable = True Then
                        Me.mnuReportHistClearCheckDet.Enabled = True
                    Else
                        Me.mnuReportHistClearCheckDet.Enabled = False
                    End If
                Else
                    Me.mnuReportHistClearCheckDet.Visible = False
                End If


            Case "ReportHistoryClearingCheckDetailOld"

                If _isvisible = True Then
                    Me.mnuReportHistClearCheckDetOld.Visible = True
                    If _enable = True Then
                        Me.mnuReportHistClearCheckDetOld.Enabled = True
                    Else
                        Me.mnuReportHistClearCheckDetOld.Enabled = False
                    End If
                Else
                    Me.mnuReportHistClearCheckDetOld.Visible = False
                End If

            Case "System"
                If _isvisible = True Then
                    Me.mnuSystem.Visible = True
                    If _enable = True Then
                        Me.mnuSystem.Enabled = True
                    Else
                        Me.mnuSystem.Enabled = False
                    End If
                Else
                    Me.mnuSystem.Visible = False
                End If

            Case "SystemDepartmentDetail"

                If _isvisible = True Then
                    Me.mnuSysDeptDet.Visible = True
                    If _enable = True Then
                        Me.mnuSysDeptDet.Enabled = True
                    Else
                        Me.mnuSysDeptDet.Enabled = False
                    End If
                Else
                    Me.mnuSysDeptDet.Visible = False
                End If

            Case "SystemDepartmentSummary"

                If _isvisible = True Then
                    Me.mnuSysDeptSum.Visible = True
                    If _enable = True Then
                        Me.mnuSysDeptSum.Enabled = True
                    Else
                        Me.mnuSysDeptSum.Enabled = False
                    End If
                Else
                    Me.mnuSysDeptSum.Visible = False
                End If


            Case "SystemUsersDetail"

                If _isvisible = True Then
                    Me.mnuSysUserDet.Visible = True
                    If _enable = True Then
                        Me.mnuSysUserDet.Enabled = True
                    Else
                        Me.mnuSysUserDet.Enabled = False
                    End If
                Else
                    Me.mnuSysUserDet.Visible = False
                End If

            Case "SystemUsersSummary"

                If _isvisible = True Then
                    Me.mnuSysUserSum.Visible = True
                    If _enable = True Then
                        Me.mnuSysUserSum.Enabled = True
                    Else
                        Me.mnuSysUserSum.Enabled = False
                    End If
                Else
                    Me.mnuSysUserSum.Visible = False
                End If


            Case "SystemFunctionalGroupDetail"

                If _isvisible = True Then
                    Me.mnuSysFGDet.Visible = True
                    If _enable = True Then
                        Me.mnuSysFGDet.Enabled = True
                    Else
                        Me.mnuSysFGDet.Enabled = False
                    End If
                Else
                    Me.mnuSysFGDet.Visible = False
                End If

            Case "SystemFunctionalGroupSummary"

                If _isvisible = True Then
                    Me.mnuSysFGSum.Visible = True
                    If _enable = True Then
                        Me.mnuSysFGSum.Enabled = True
                    Else
                        Me.mnuSysFGSum.Enabled = False
                    End If
                Else
                    Me.mnuSysFGSum.Visible = False
                End If


            Case "SystemAssignFGUserDetail"

                If _isvisible = True Then
                    Me.mnuSysFGToUserDet.Visible = True
                    If _enable = True Then
                        Me.mnuSysFGToUserDet.Enabled = True
                    Else
                        Me.mnuSysFGToUserDet.Enabled = False
                    End If
                Else
                    Me.mnuSysFGToUserDet.Visible = False
                End If

            Case "SystemAssignFGUserSummary"

                If _isvisible = True Then
                    Me.mnuSysFGToUserSum.Visible = True
                    If _enable = True Then
                        Me.mnuSysFGToUserSum.Enabled = True
                    Else
                        Me.mnuSysFGToUserSum.Enabled = False
                    End If
                Else
                    Me.mnuSysFGToUserSum.Visible = False
                End If

            Case "SystemReportUsersRole"

                If _isvisible = True Then
                    Me.mnuSysReportUsersRole.Visible = True
                    If _enable = True Then
                        Me.mnuSysReportUsersRole.Enabled = True
                    Else
                        Me.mnuSysReportUsersRole.Enabled = False
                    End If
                Else
                    Me.mnuSysReportUsersRole.Visible = False
                End If

            Case "SystemReportActivityLog"

                If _isvisible = True Then
                    Me.mnuSysReportActivityLog.Visible = True
                    If _enable = True Then
                        Me.mnuSysReportActivityLog.Enabled = True
                    Else
                        Me.mnuSysReportActivityLog.Enabled = False
                    End If
                Else
                    Me.mnuSysReportActivityLog.Visible = False
                End If

                ''---------------------------

            Case "SystemReportRolePermMenu"

                If _isvisible = True Then
                    Me.mnuSysReportRolePermMenu.Visible = True
                    If _enable = True Then
                        Me.mnuSysReportRolePermMenu.Enabled = True
                    Else
                        Me.mnuSysReportRolePermMenu.Enabled = False
                    End If
                Else
                    Me.mnuSysReportRolePermMenu.Visible = False
                End If

            Case "SystemReportRolePermForm"

                If _isvisible = True Then
                    Me.mnuSysReportRolePermForm.Visible = True
                    If _enable = True Then
                        Me.mnuSysReportRolePermForm.Enabled = True
                    Else
                        Me.mnuSysReportRolePermForm.Enabled = False
                    End If
                Else
                    Me.mnuSysReportRolePermForm.Visible = False
                End If

            Case "SystemReportUserInactivity"

                If _isvisible = True Then
                    Me.mnuSysReportInactivity.Visible = True
                    If _enable = True Then
                        Me.mnuSysReportInactivity.Enabled = True
                    Else
                        Me.mnuSysReportInactivity.Enabled = False
                    End If
                Else
                    Me.mnuSysReportInactivity.Visible = False
                End If
                ''---------------------------

            Case "SystemEERSFeedExport"

                If _isvisible = True Then
                    Me.mnuSysEERSExport.Visible = True
                    If _enable = True Then
                        Me.mnuSysEERSExport.Enabled = True
                    Else
                        Me.mnuSysEERSExport.Enabled = False
                    End If
                Else
                    Me.mnuSysEERSExport.Visible = False
                End If

            Case "Tools"

                If _isvisible = True Then
                    Me.mnuTools.Visible = True
                    If _enable = True Then
                        Me.mnuTools.Enabled = True
                    Else
                        Me.mnuTools.Enabled = False
                    End If
                Else
                    Me.mnuTools.Visible = False
                End If


            Case "ToolsPPMCollection"

                If _isvisible = True Then
                    Me.mnuToolsPPMCollection.Visible = True
                    If _enable = True Then
                        Me.mnuToolsPPMCollection.Enabled = True
                    Else
                        Me.mnuToolsPPMCollection.Enabled = False
                    End If
                Else
                    Me.mnuToolsPPMCollection.Visible = False
                End If

            Case "ToolsPPMClearing"

                If _isvisible = True Then
                    Me.mnuToolsPPMClearing.Visible = True
                    If _enable = True Then
                        Me.mnuToolsPPMClearing.Enabled = True
                    Else
                        Me.mnuToolsPPMClearing.Enabled = False
                    End If
                Else
                    Me.mnuToolsPPMClearing.Visible = False
                End If



        End Select



    End Sub


    Private Sub HideMenus()
        'Me.mnuMainBranchDet.Visible = False
        'Me.mnuMainBranchSum.Visible = False

        'Me.mnuMainClientDet.Visible = False
        'Me.mnuMainClientSum.Visible = False

        'Me.mnuMainBankDet.Visible = False
        'Me.mnuMainBankSum.Visible = False



        Me.mnuMainZoneDet.Visible = False
        Me.mnuMainZoneSum.Visible = False

        Me.mnuMainRejectDet.Visible = False
        Me.mnuMainRejectSum.Visible = False

        Me.mnuMainChequeTypeDet.Visible = False
        Me.mnuMainChequeTypeSum.Visible = False

        Me.mnuMainHolidayDet.Enabled = False
        Me.mnuMainHolidaySum.Visible = False

        'Me.mnuFileUserDet.Visible = False
        'Me.mnuFileUserSum.Visible = False

        'Me.mnuFileFormsDet.Visible = False
        'Me.mnuFileFormsSum.Visible = False

        'Me.mnuFileFGDet.Visible = False
        'Me.mnuFileFGSum.Visible = False

        'Me.mnuFGToUserDet.Visible = False
        'Me.mnuFGToUserSum.Visible = False

        'Me.mnuFileDeptDet.Visible = False
        'Me.mnuFileDetpSum.Visible = False


    End Sub






    Private Sub LogIn()

        'mnuFileLogout.Text = "&Log Out"

    End Sub

    Private Sub LogOut()

        'mnuFileLogout.Text = "&Log In"

StartLoop:

        For Each f As Form In My.Application.OpenForms
            'If f.Name = "FrmCitiCheckDetail" Or f.Name = "FrmDDDetail" Then
            '    f.Close()
            '    GoTo StartLoop
            'End If

            If Not (f.Name = "FrmLogin" Or f.Name = "FrmMain") Then
                f.Close()
                GoTo StartLoop
            End If
        Next

        log_mesage = "User " + CommonAppSet.User + " Logged Out"
        Logger.system_log(log_mesage)

        Me.Dispose()

        '_hostForm.Show()

    End Sub


    Private Sub LogOutAuto()

        CommonAppSet.SessionTimeOut = True

        Logger.system_log("Session has expired for user: " + CommonAppSet.User)

        Dim frmLoginSess As New FrmLoginSession()
        frmLoginSess.Status = "Your session has expired. Please Login again."
        frmLoginSess.ShowDialog()

        If CommonAppSet.SessionTimeOut = True Then

            'mnuFileLogout.Text = "&Log In"

StartLoop:

            For Each f As Form In My.Application.OpenForms
                'If f.Name = "FrmCitiCheckDetail" Or f.Name = "FrmDDDetail" Then
                '    f.Close()
                '    GoTo StartLoop
                'End If

                If Not (f.Name = "FrmLogin" Or f.Name = "FrmMain") Then
                    f.Close()
                    GoTo StartLoop
                End If
            Next
            Me.Dispose()

        Else

            If applicationIdle.IsRunning = False Then

                applicationIdle.Start()
                LogIn()

            End If


            Me.Show()

        End If


        '_hostForm.Show()

    End Sub


    Private Sub applicationIdle_Idle(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '_hostForm.IsMdiExit = True
        ''_hostForm.Status = "Your You have been automatically logged out."
        ''_hostForm.Status = "Your session has expired. Please Login again."

        'LogOutAuto()

        _hostForm.IsMdiExit = False
        '_hostForm.Status = "Your You have been automatically logged out."
        _hostForm.Status = "Your session has expired. Please Login again."
        log_mesage = CommonAppSet.User + " Logout For InActivity"
        Logger.system_log(log_mesage)
        LogOut()

    End Sub

    Delegate Sub IdleDelegate(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Private Sub applicationIdle_IdleAsync(ByVal sender As System.Object, ByVal e As System.EventArgs)

        BeginInvoke(New IdleDelegate(AddressOf applicationIdle_Idle), sender, e)

    End Sub

    Private Sub applicationIdle_WarnAsync(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Console.Beep()

    End Sub



#End Region

    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub





    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''LoadMenuSec()
        ''HideMenus()



        Me.Text = CommonAppSet.ModuleShortName + " - " + CommonAppSet.ModuleName

        lblAppName.Text = CommonAppSet.ModuleName + " (" + CommonAppSet.ModuleShortName + ")"
        lblVersion.Text = "Ver: " + Application.ProductVersion

        lblUser.Text = "User: " + CommonAppSet.Domain + "\" + CommonAppSet.User
        lblServerName.Text = "Server: " + CommonAppSet.ServerConfigName & " [" & CommonAppSet.Server & "]"

        lblLoginDt.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        lblLoginTime.Text = "Logged at: " & DateTime.Now.ToShortTimeString()


        If CommonAppSet.IsByPass = False Then
            LoadMenuSec()
        End If


        AddHandler applicationIdle.WarnAsync, AddressOf applicationIdle_WarnAsync
        AddHandler applicationIdle.IdleAsync, AddressOf applicationIdle_IdleAsync

        If applicationIdle.IsRunning = False Then

            applicationIdle.Start()
            LogIn()

        End If

    End Sub



    Private Sub mnuFileDetpSumm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysDeptSum.Click
        Dim frmDeptSum As New FrmDeptSumm
        frmDeptSum.ShowDialog()
    End Sub

    Private Sub mnuFileDeptDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysDeptDet.Click
        Dim frmDeptDet As New FrmDeptDet
        frmDeptDet.ShowDialog()
    End Sub

    Private Sub mnuFileUserDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysUserDet.Click
        Dim frmUserSum As New FrmUsersDet
        frmUserSum.ShowDialog()
    End Sub

    Private Sub mnuFileUserSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysUserSum.Click
        Dim frmUserSum As New FrmUserSumm
        frmUserSum.ShowDialog()

    End Sub







    Private Sub mnuFileRolesDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysFGDet.Click
        'Dim frmFGDet As New FrmFGDet
        'frmFGDet.Show()
        Dim frmPermFgDet As New FrmPermFGDet
        frmPermFgDet.ShowDialog()


    End Sub

    Private Sub mnuFileRolesSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysFGSum.Click
        'Dim frmRolesSum As New FrmFGSumm
        'frmRolesSum.Show()

        Dim frmFgPermSum As New FrmFGPermSumm
        frmFgPermSum.ShowDialog()



    End Sub





    Private Sub mnuRoleToUserDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysFGToUserDet.Click
        Dim frmUserRoleDet As New FrmUsersFGDet
        frmUserRoleDet.ShowDialog()

    End Sub

    Private Sub mnuRoleToUserSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysFGToUserSum.Click
        Dim frmUsersFGSum As New FrmUsersFGSumm
        frmUsersFGSum.ShowDialog()

    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        _hostForm.IsMdiExit = True
        Me.Close()
    End Sub


    Private Sub mnuMainClientDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClientDet.Click

        Dim frmClient As New FrmClientDet()
        frmClient.Show()

    End Sub

    Private Sub mnuMainLocationDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainLocationDet.Click
        Dim frmLocation As New FrmLocationDet()
        frmLocation.Show()
    End Sub

    Private Sub mnuMainBranchDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBranchDet.Click
        Dim frmBranch As New FrmBranchDet()
        frmBranch.Show()
    End Sub

    Private Sub mnuMainHolidayDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainHolidayDet.Click
        Dim frmHoliday As New FrmHolidayDet()
        frmHoliday.Show()
    End Sub

    Private Sub mnuMainBankDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBankDet.Click
        Dim frmBank As New FrmBankDet()
        frmBank.Show()
    End Sub

    Private Sub mnuMainRejectDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainRejectDet.Click
        Dim frmReturn As New FrmReturnDet()
        frmReturn.Show()
    End Sub

    Private Sub mnuMainChequeTypeDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainChequeTypeDet.Click
        Dim frmCheckType As New FrmCheckTypeDet()
        frmCheckType.Show()
    End Sub



    Private Sub mnuMainZoneDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainZoneDet.Click
        Dim frmZone As New FrmZoneDet()
        frmZone.Show()
    End Sub

    Private Sub mnuMainDepositStockDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainDepositStockDet.Click
        Dim frmSchStock As New FrmScheduleStockDet()
        frmSchStock.Show()
    End Sub

    Private Sub mnuMainCitiBranchDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainCitiBranchDet.Click
        Dim frmCitiBranch As New FrmCitiBankBranchDet()
        frmCitiBranch.Show()
    End Sub











    Private Sub mnuMainBankSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBankSum.Click
        Dim frmBankSum As New FrmBankSumm()
        frmBankSum.Show()
    End Sub

    Private Sub mnuMainLocationSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainLocationSum.Click
        Dim frmLocSum As New FrmLocationSumm()
        frmLocSum.Show()
    End Sub

    Private Sub mnuMainZoneSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainZoneSum.Click
        Dim frmZoneSum As New FrmZoneSumm()
        frmZoneSum.Show()
    End Sub

    Private Sub mnuMainChequeTypeSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainChequeTypeSum.Click

        Dim frmCheckTypeSum As New FrmCheckTypeSumm()
        frmCheckTypeSum.Show()

    End Sub

    Private Sub mnuMainRejectSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainRejectSum.Click
        Dim frmRetSum As New FrmReturnSumm()
        frmRetSum.Show()

    End Sub

    Private Sub mnuMainCitiBranchSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainCitiBranchSum.Click
        Dim frmCitiBranchSum As New FrmCitibankBranchSumm()
        frmCitiBranchSum.Show()
    End Sub

    Private Sub mnuMainBranchSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBranchSum.Click
        Dim frmBranchSum As New FrmBranchSumm()
        frmBranchSum.Show()
    End Sub

    Private Sub mnuSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSystem.Click

    End Sub

    Private Sub mnuMainClientSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClientSum.Click
        Dim frmClientSum As New FrmClientSumm()
        frmClientSum.Show()

    End Sub

    Private Sub mnuMainDepositStockSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainDepositStockSum.Click
        Dim frmScheStockSum As New FrmScheduleStockSumm()
        frmScheStockSum.Show()
    End Sub

    Private Sub mnuFileLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileLogout.Click

        'You have been automatically logged out.
        'If applicationIdle.IsRunning = True Then
        '    applicationIdle.Stop()
        '    LogOut()

        'Else
        '    applicationIdle.Start()
        '    LogIn()

        'End If

        If applicationIdle.IsRunning = True Then
            applicationIdle.Stop()
            _hostForm.Status = "You have been logged out."
            _hostForm.IsMdiExit = False
            LogOut()
        End If



    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef hostForm As Windows.Forms.Form)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _hostForm = hostForm

    End Sub

    Private Sub mnuDepositFlex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositFlex.Click
        Dim frmBooking As New FrmBooking()
        frmBooking.Show()
    End Sub

    Private Sub CitiCashAndToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepCashSpeedSumm.Click
        Dim frmRptCashCitiSum As New FrmRptCashSpeedSummary()
        frmRptCashCitiSum.Show()
    End Sub

    Private Sub mnuDepositOutstanding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositOutstanding.Click
        Dim frmOutstanding As New FrmReversalOutstanding()
        frmOutstanding.Show()

    End Sub

    Private Sub mnuDepositFlexRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositFlexRev.Click
        Dim frmReversalGen As New FrmReversalGen()
        frmReversalGen.Show()
    End Sub

    Private Sub mnuMainHolidaySum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainHolidaySum.Click
        Dim frmHoliSum As New FrmHolidaySumm()
        frmHoliSum.Show()

    End Sub


    Private Sub mnuDepositReminder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositReminder.Click
        Dim frmReminder As New FrmReminderCitiAny()
        frmReminder.Show()
    End Sub

    Private Sub mnuDepoScheDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepoScheDet.Click

        Dim frmDepoSch As New FrmDepoSchedule()
        frmDepoSch.Show()

    End Sub

    Private Sub mnuReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReport.Click

    End Sub

    Private Sub CitiCashDepositReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepCashDeposit.Click
        Dim frmCashDeposit As New FrmRptCashDeposit()
        frmCashDeposit.Show()
    End Sub

    Private Sub CitiSpeedDepositReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepSpeedDeposit.Click
        Dim frmCitiSpeed As New FrmRptSpeedDeposit()
        frmCitiSpeed.Show()
    End Sub

    Private Sub CitiSpeedReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepSpeedReturn.Click
        Dim frmSpeedRet As New FrmRptSpeedReturn()
        frmSpeedRet.Show()
    End Sub

    Private Sub CitiCheckDepositDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepAnywhereDepositDet.Click
        Dim frmCitiAny As New FrmRptCitiAnyDepositDetail()
        frmCitiAny.Show()
    End Sub

    Private Sub CitiAnywhereToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepAnywhereProcessing.Click
        Dim frmCitiAnyPro As New FrmRptAnyProcessing()
        frmCitiAnyPro.Show()
    End Sub

    Private Sub CitiAnywhereFundingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepAnywhereFunding.Click
        Dim frmcitAnyFund As New FrmRptAnyFunding()
        frmcitAnyFund.Show()
    End Sub

    Private Sub CitiAnywhereOutstandingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepAnywhereOutstanding.Click
        Dim frmCitiAnyOut As New FrmRptAnyOutstanding()
        frmCitiAnyOut.Show()
    End Sub

    Private Sub DayZeroCashAndCheckReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepDayZero.Click
        Dim frmCitiDayZero As New FrmRptCashSpeedDayZero()
        frmCitiDayZero.Show()
    End Sub

    Private Sub CitiAnywhereReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportManiAnywhereRet.Click
        Dim frmCitiAnyReturn As New FrmRptAnyReturn()
        frmCitiAnyReturn.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportManiDDDeposit.Click
        Dim frmDDFunding As New FrmRptDDFunding()
        frmDDFunding.Show()
    End Sub


    Private Sub UnclearFundReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportContUnclearFund.Click
        Dim frmUnclearFund As New FrmRptUnclearFund()
        frmUnclearFund.Show()
    End Sub

    Private Sub DepositBreakReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportContDepositBreak.Click

        Dim frmDeposit As New FrmRptDepositBreak2()
        frmDeposit.Show()


        'Dim frmDepositBreak As New FrmDepositBreak()
        'frmDepositBreak.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportManiCollection.Click
        Dim frmAnyCollection As New FrmRptAnyCheckCollection()
        frmAnyCollection.Show()
    End Sub

    Private Sub ReminderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportManiReminder.Click
        Dim frmCitiReminder As New FrmRptAnyReminder()
        frmCitiReminder.Show()
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        Dim frmAbout As New FrmAbout()
        frmAbout.ShowDialog()
    End Sub

    Private Sub mnuDepoScheSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepoScheSum.Click
        Dim frmDepoSumm As New FrmDepoScheSumm()
        frmDepoSumm.Show()
    End Sub

    Private Sub mnuDepositCashDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCashDet.Click
        Dim frmCashDet As New FrmCitiCashDetail()
        frmCashDet.Show()
    End Sub

    Private Sub mnuDepositCashSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCashSum.Click
        Dim frmCashSum As New FrmCitiCashSumm()
        frmCashSum.Show()
    End Sub

    Private Sub mnuDepositSpeedDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSpeedDet.Click
        Dim frmCitiSpeed As New FrmCitiSpeedDetail()
        frmCitiSpeed.Show()
    End Sub

    Private Sub mnuDepositSpeedSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSpeedSum.Click
        Dim frmSpeedSum As New FrmCitiSpeedSumm()
        frmSpeedSum.Show()
    End Sub

    Private Sub mnuDepositCheckDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCheckDet.Click
        Dim frmCheckDet As New FrmCitiCheckDetail()
        'frmCheckDet.Show()
        frmCheckDet.Show()
    End Sub

    Private Sub mnuDepositCheckSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCheckSum.Click
        Dim frmCheckSum As New FrmCitiCheckSumm()
        frmCheckSum.Show()
    End Sub

    Private Sub mnuMainClearClientDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearClientDet.Click
        Dim frmClearingClient As New FrmClearingClientDet()
        frmClearingClient.Show()
    End Sub

    Private Sub mnuMainClearBankDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearBankDet.Click
        Dim frmClearingBank As New FrmClearingBankDet()
        frmClearingBank.Show()
    End Sub

    Private Sub mnuMainClearBankSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearBankSum.Click
        Dim frmClearingBankSum As New FrmClearingBankSumm()
        frmClearingBankSum.Show()
    End Sub

    Private Sub mnuMainClearBranchDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearBranchDet.Click
        Dim frmClearBranchDet As New FrmClearingBranchDet()
        frmClearBranchDet.Show()
    End Sub

    Private Sub mnuMainClearBranchSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearBranchSum.Click
        Dim frmClearBranchSum As New FrmClearingBranchSumm()
        frmClearBranchSum.Show()
    End Sub

    Private Sub mnuMainClearLocationDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearLocationDet.Click
        Dim frmClearLocationDet As New FrmClearingLocationDet()
        frmClearLocationDet.Show()
    End Sub

    Private Sub mnuMainClearLocationSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearLocationSum.Click
        Dim frmClearLocationSum As New FrmClearingLocationSumm()
        frmClearLocationSum.Show()
    End Sub

    Private Sub mnuClearingCheckDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingCheckDet.Click
        Dim frmClearingDet As New FrmClearingDetail()
        frmClearingDet.Show()
    End Sub

    Private Sub mnuClearingFlex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingFlex.Click
        Dim frmClearingDepoFile As New FrmClearingDepositFile()
        frmClearingDepoFile.Show()
    End Sub

    Private Sub mnuMainClearClientSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearClientSum.Click
        Dim frmClearingClientSum As New FrmClearingClientSumm()
        frmClearingClientSum.Show()
    End Sub


    Private Sub mnuDepoScheMissingDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepoScheMissingDetail.Click
        Dim frmDschMissing As New FrmDepoScheMissingDetail()
        frmDschMissing.Show()

    End Sub

    Private Sub mnuDepoScheMismatchTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepoScheMismatchTotal.Click
        Dim frmDschMismatch As New FrmDepoScheMismatchTotal()
        frmDschMismatch.Show()

    End Sub

    Private Sub mnuDepositSpeedMismatchTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSpeedMismatchTotal.Click
        Dim frmSpeedMismatch As New FrmCitiSpeedMismatchTotal()
        frmSpeedMismatch.Show()
    End Sub

    Private Sub mnuCollDDForSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollDDForSubSystem.Click
        Dim frmDDSub As New FrmSubSysDDInfo()
        frmDDSub.Show()

    End Sub

    Private Sub MonthlyBillForCashManagementServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepMonthlyBillCash.Click
        Dim frmMonBill As New FrmRptMonthBillCashCheck()
        frmMonBill.Show()
    End Sub

    Private Sub mnuDepositCollectionProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCollectionProcess.Click

        Dim frmCollProcess As New FrmCollectionProcessCitiAny()
        frmCollProcess.Show()

    End Sub

    Private Sub mnuReportContCollectionReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportContCollectionReprint.Click
        Dim frmCollReprint As New FrmRptAnyCheckCollectionReprint()
        frmCollReprint.Show()
    End Sub

    Private Sub mnuCollScheduleDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollScheduleDet.Click

        Dim frmCollSche As New FrmCollSchedule()
        frmCollSche.Show()

    End Sub

    Private Sub mnuCollScheduleSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollScheduleSum.Click
        Dim frmCollScheSum As New FrmCollScheduleSumm()
        frmCollScheSum.Show()
    End Sub

    Private Sub mnuCollDDDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollDDDet.Click


        Dim frmDD As New FrmDDDetail()
        'frmDD.Show()
        frmDD.Show()


    End Sub

    Private Sub mnuCollDDSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollDDSum.Click
        Dim frmDDSum As New FrmDDSumm()
        frmDDSum.Show()
    End Sub

    Private Sub mnuFilePending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFilePending.Click
        Dim frmPending As New FrmPendingAuth()
        frmPending.Show()
    End Sub

    Private Sub mnuCollNormalDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollNormalDet.Click
        Dim frmNormalColl As New FrmCitiAnyReturnDet()
        frmNormalColl.Show()
    End Sub

    Private Sub mnuCollNormalSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollNormalSum.Click
        Dim frmCitiAnyRetSum As New FrmCitiAnyReturnSumm()
        frmCitiAnyRetSum.Show()
    End Sub

    Private Sub mnuDepositCitiAnyFunding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCitiAnyFunding.Click
        Dim frmFunding As New FrmCitiAnyFunding()
        frmFunding.Show()
    End Sub

    Private Sub mnuMainFlexAccDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainFlexAccDet.Click
        Dim frmFlexAcc As New FrmFlexAccDet()
        frmFlexAcc.Show()
    End Sub

    Private Sub mnuMainFlexAccSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainFlexAccSum.Click
        Dim frmFlexSum As New FrmFlexAccSumm()
        frmFlexSum.Show()
    End Sub

    Private Sub mnuClearingCheckSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingCheckSum.Click
        Dim frmClearingSum As New FrmClearingSumm()
        frmClearingSum.Show()
    End Sub

    Private Sub mnuReportRepHoliday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepHoliday.Click

        Dim frmRptHoli As New FrmRptHoliday()
        frmRptHoli.Show()

    End Sub


    Private Sub mnuClearingPDCDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingPDCDet.Click
        Dim frmPDCdet As New FrmPDCDet()
        frmPDCdet.Show()
    End Sub

    Private Sub mnuClearingPDCSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingPDCSum.Click
        Dim frmPDCsum As New FrmPDCSumm()
        frmPDCsum.Show()
    End Sub

    Private Sub mnuClearingPDCTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingPDCTrans.Click
        Dim frmPDCTrans As New FrmPDCTransfer()
        frmPDCTrans.Show()
    End Sub

    Private Sub ClearingCheckSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepClearCheckSumm.Click
        Dim frmClearCheckSum As New FrmRptClearCheckSumm()
        frmClearCheckSum.Show()
    End Sub

    Private Sub BankWiseDeliveryCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepBankwiseDelivery.Click
        Dim frmRptBranchwise As New FrmRptClearBranchwise()
        frmRptBranchwise.Show()
    End Sub

    Private Sub HighValueCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepHighValueCheck.Click
        Dim frmRptHighvalue As New FrmRptClearHighValue()
        frmRptHighvalue.Show()
    End Sub

    Private Sub CitiClearClearingDepositReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepClearDeposit.Click
        Dim frmRptClearDeposit As New FrmRptClearDeposit()
        frmRptClearDeposit.Show()
    End Sub

    Private Sub CitiClearClearingDepositDetailReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepClearDepositDet.Click
        Dim frmRprtClearDepDet As New FrmRptClearDepositDet()
        frmRprtClearDepDet.Show()
    End Sub





    Private Sub mnuClearingUploadRet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingUploadRet.Click
        Dim frmClearRetImp As New FrmClearRetImport()
        frmClearRetImp.Show()
    End Sub


    Private Sub mnuSysReportUsersRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysReportUsersRole.Click

        'Dim rd As New crUsersRole()

        'Dim frmRptViewer As New FrmReportViewer()

        'frmRptViewer.SetReport(rd)

        'frmRptViewer.Show()

        'Dim crReport As New CReportUsersRole()
        'crReport.ReportToPDF()

        Dim frmRprtUserRole As New FrmRptUsersRole()
        frmRprtUserRole.ShowDialog()


    End Sub

    Private Sub mnuSysEERSExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysEERSExport.Click
        Dim frmEERS As New FrmEERSFeedExport()
        frmEERS.Show()
    End Sub

    Private Sub mnuClearingSetDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingSetDate.Click
        Dim frmSetClearDate As New FrmSetClearDate()
        frmSetClearDate.Show()
    End Sub

    Private Sub mnuClearingCheckRetDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingCheckRetDet.Click
        Dim frmCheckRetDet As New FrmClearingReturnDet()
        frmCheckRetDet.Show()
    End Sub

    Private Sub mnuClearingUploadCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingUploadCheck.Click
        Dim frmUploadClearCheck As New FrmClearCheckImport
        frmUploadClearCheck.Show()
    End Sub

    Private Sub mnuClearingCheckRetSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingCheckRetSum.Click
        Dim frmCheckRetSum As New FrmClearingReturnSumm()
        frmCheckRetSum.Show()
    End Sub


    Private Sub mnuClearingFlexReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingFlexReturn.Click
        Dim frmClearRet As New FrmClearingReturnFile()
        frmClearRet.Show()
    End Sub

    Private Sub mnuCollSpeedReturnDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollSpeedReturnDet.Click
        Dim frmCitiSpeedRetDet As New FrmCitiSpeedReturnDet()
        frmCitiSpeedRetDet.Show()
    End Sub

    Private Sub mnuCollSpeedReturnSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollSpeedReturnSum.Click
        Dim frmSpeedRetSum As New FrmCitiSpeedReturnSumm()
        frmSpeedRetSum.ShowDialog()
    End Sub

    Private Sub mnuClearingDDProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingDDProcess.Click
        Dim frmDDCheckProc As New FrmClearDDCheckProcess()
        frmDDCheckProc.Show()
    End Sub

    Private Sub mnuSysReportActivityLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysReportActivityLog.Click
        Dim frmAcitivityLog As New FrmLogReport()
        frmAcitivityLog.Show()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Double = 100000
        Dim m As Double = a
        Dim rate As Double = 8 / 100 / 12

        'm = m + (m * rate)
        'For i = 1 To 1 'year

        '    For j = 2 To 12 'month
        '        m = m + ((m + a) * rate) + a
        '    Next j

        'Next i

        m = m + (m * rate)
        For i = 1 To 1 'year

            For j = 2 To 12 'month
                m = m + (m * rate)
            Next j

        Next i

        MessageBox.Show(m.ToString())


        'Dim strTest = "010009275590007"

        'MessageBox.Show(strTest.Trim().Substring(strTest.Trim().Length - 3, 3))

        'Dim tempform As New FrmTempTest()
        'tempform.ShowDialog()
    End Sub

    Private Sub mnuReportCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportCont.Click

    End Sub

    Private Sub mnuReportHistClearCheckDetOld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportHistClearCheckDetOld.Click
        Dim frmRptClearingCheckHistOld As New FrmRptClearingCheckHistOld()
        frmRptClearingCheckHistOld.Show()
    End Sub




    Private Sub mnuReportRepDDBreakup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepDDBreakup.Click

        Dim frmDDBreakup As New FrmDDBreakup
        frmDDBreakup.Show()

    End Sub

    Private Sub mnuReportRepClearReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepClearReturn.Click
        Dim frmRptClearRet As New FrmRptClearReturn()
        frmRptClearRet.Show()
    End Sub

    Private Sub mnuReportRepPDC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportRepPDC.Click
        Dim frmRptPDC As New FrmRptClearPDC()
        frmRptPDC.Show()
    End Sub

    Private Sub mnuDepositExportGoAml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositExportGoAml.Click
        Dim frmExportGoAml As New FrmDepositExportGo()
        frmExportGoAml.ShowDialog()

    End Sub

    Private Sub mnuDepositSameDayMISUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSameDayMISUpload.Click
        Dim frmSameDay As New FrmImportSameDayMis()
        frmSameDay.Show()
    End Sub

    Private Sub mnuDepositSameDayMisSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSameDayMisSummary.Click
        Dim FrmSameDaySummary As New FrmSameDayMISSummary()
        FrmSameDaySummary.Show()
    End Sub

    Private Sub mnuDepositSameDayMisDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSameDayMisDetail.Click
        Dim FrmSamedayDet As New FrmSameDayMISDetail()
        FrmSamedayDet.Show()
    End Sub

    Private Sub mnuDepositSameDayMisProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSameDayMisProcess.Click
        Dim FrmSameDay As New FrmProcessSameDayMis()
        FrmSameDay.Show()
    End Sub

    Private Sub mnuDepositSameDayMISReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSameDayMISReport.Click
        Dim FrmReport As New FrmReportSameDayMis()
        FrmReport.Show()
    End Sub

    'Private Sub mnuCollectionCitiSpeedReturnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollectionCitiSpeedReturnProcess.Click
    '    Dim FrmCProcess As New FrmCitiSpeedCollectionReturnProcess()
    '    FrmCProcess.Show()
    'End Sub

    'Private Sub mnuCollectionCitiSpeedReturnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim FrmCProcess As New FrmCitiSpeedCollectionReturnProcess()
    '    FrmCProcess.Show()
    'End Sub

    Private Sub mnuCollectionCitiSpeedReturnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollectionCitiSpeedReturnFile.Click
        Dim FrmReturnFelx As New FrmCitiSpeedReturnFile()
        FrmReturnFelx.Show()
    End Sub

    Private Sub mnuGuaranteedCreditBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGuaranteedCreditBooking.Click
        Dim FrmCredit As New FrmGuaranteedCreditBooking()
        FrmCredit.ShowDialog()
    End Sub

    Private Sub mnuReportMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frmmail As New FrmClientMail()
        'frmmail.Show()
    End Sub

    Private Sub mnuDepositSameDayMISEmailHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositSameDayMISEmailHistory.Click
        Dim FrmEmail As New FrmSameDayMISEmailHistory()
        FrmEmail.Show()
    End Sub

    Private Sub mnuMaintenanceEmailSettingDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenanceEmailSettingDetail.Click
        Dim FrmEMailSet As New FrmEmailSettingDetail()
        FrmEMailSet.ShowDialog()
    End Sub

    Private Sub mnuMaintenanceEmailSettingSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaintenanceEmailSettingSummary.Click
        Dim FrmEmailSumm As New FrmEmailSettingSummary()
        FrmEmailSumm.ShowDialog()
    End Sub

    Private Sub mnuReportsGuaranteedCreditBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsGuaranteedCreditBooking.Click
        Dim FrmCredit As New FrmRptGuaranteedCreditBooking()
        FrmCredit.ShowDialog()
    End Sub

    Private Sub mnuReportClearChargeBBK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportClearChargeBBK.Click
        Dim frmRptClearBbk As New FrmRptClearGovtCheck()
        frmRptClearBbk.Show()
    End Sub

    Private Sub mnuReportClearChargeClientWiseBreakup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportClearChargeClientWiseBreakup.Click
        Dim frmRptClearClientCharge As New FrmRptClearClientWiseCharge()
        frmRptClearClientCharge.Show()
    End Sub

    Private Sub mnuReportClearChargeClientWiseSumm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportClearChargeClientWiseSumm.Click
        Dim frmRptClearClientWiseChargeSum As New FrmRptClearClientWiseChargeSumm()
        frmRptClearClientWiseChargeSum.Show()
    End Sub

    Private Sub mnuReportClearChargeSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportClearChargeSummary.Click
        Dim frmRptClearChargeSum As New FrmRptClearChargeSumm()
        frmRptClearChargeSum.Show()
    End Sub

    Private Sub mnuReportClearChargeBACHSummSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportClearChargeBACHSummSheet.Click
        Dim frmClearChargeBACHSumm As New FrmRptClearBACHChargeSummSheet()
        frmClearChargeBACHSumm.Show()
    End Sub

    Private Sub mnuMainClearChargeDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearChargeDet.Click
        Dim frmClearCharge As New FrmClearingChargeDet()
        frmClearCharge.Show()
    End Sub

    Private Sub mnuClearingCheckSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingCheckSearch.Click
        Dim frmClearingSearch As New FrmClearingSearch()
        frmClearingSearch.Show()
    End Sub

    Private Sub mnuClearingFlexCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearingFlexCharge.Click
        CommonAppSet.DebugLevel = "Clearing Charge File Entry"
        CommonAppSet.DebugMessage = ""


        Try
            Dim frmClearingCharg As New FrmClearingChargeFile()

            frmClearingCharg.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Debug Level: " + CommonAppSet.DebugLevel + _
                            Environment.NewLine + "Debug Message: " + CommonAppSet.DebugMessage + _
                            Environment.NewLine + "App Message: " + ex.Message, "Clearing Charge File Error")
        End Try


    End Sub

    Private Sub mnuDepositCheckSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepositCheckSearch.Click
        Dim frmCitiAnySearch As New FrmCitiCheckSearch()
        frmCitiAnySearch.Show()

    End Sub

    Private Sub mnuDepoScheSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepoScheSearch.Click
        Dim frmDepoSearch As New FrmDepoScheSearch()
        frmDepoSearch.Show()
    End Sub

    Private Sub mnuSysReportInactivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysReportInactivity.Click
        Dim frmRptInactivity As New FrmRptUsersInactivity()
        frmRptInactivity.ShowDialog()
    End Sub

    Private Sub mnuSysReportRolePermMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysReportRolePermMenu.Click
        Dim frmRptUserMenu As New FrmRptUsersMenuPerm()
        frmRptUserMenu.ShowDialog()
    End Sub

    Private Sub mnuSysReportRolePermForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSysReportRolePermForm.Click
        Dim frmRptFormPerm As New FrmRptUsersFormPerm()
        frmRptFormPerm.ShowDialog()
    End Sub

    Private Sub btnTestGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestGen.Click

        Dim _FileNm As String
        _FileNm = "TestBank_Test_Yasir"

        _FileNm = _FileNm + ".csv"
        Dim owrite As System.IO.StreamWriter
        Dim _Path As String = Environment.CurrentDirectory
        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Using conn As DbConnection = db.CreateConnection()

            conn.Open()

            Dim trans As DbTransaction = conn.BeginTransaction()
            If Not Directory.Exists(_Path) Then
                Directory.CreateDirectory(_Path)
            End If

            File.Copy(Environment.CurrentDirectory + "\Bank_Header.csv", _Path + "\" + _FileNm, True)

            owrite = New System.IO.StreamWriter(_Path + "\" + _FileNm, True)


            Dim sLine As String

            Dim ExlWS As New ArrayList()

            Try

                'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_A_Test_GetBankDetail")

                Dim dt As DataTable = db.ExecuteDataSet(commProc, trans).Tables(0)


                For i = 0 To dt.Rows.Count - 1
                    ExlWS.Clear()

                    ExlWS.Add(dt.Rows(i)("BANK_CODE").ToString())    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                    ExlWS.Add(dt.Rows(i)("BANK_NAME").ToString())   '"G010009155160001" '"Acc_Name '""
                    ExlWS.Add(dt.Rows(i)("HEAD_ADD1").ToString())   'ACCOUNT_BRANCH                 
                    ExlWS.Add(dt.Rows(i)("HEAD_ADD2").ToString())   'INSTRUMENT_NO
                    ExlWS.Add(dt.Rows(i)("HEAD_ADD3").ToString())
                    ExlWS.Add("~~END~~")

                    'increament of variables for row and currno
                    'i = i + 1
                    'j = j + 1

                    sLine = ""
                    sLine = ExlWS.Item(0).ToString()
                    For n = 1 To ExlWS.Count - 1
                        sLine = sLine + "," + ExlWS.Item(n).ToString()
                    Next n

                    owrite.WriteLine(sLine)

                Next i

                sLine = "~~END~~" + "," + "~~END~~"
                owrite.WriteLine(sLine)

                owrite.Close()

                '_FileSuccess = True



            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        If Not (owrite Is Nothing) Then
            owrite.Close()
        End If



    End Sub

    Private Sub mnuGeneratePPMFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGeneratePPMFile.Click
        Dim frmPPMFeedExport As New FrmPPMFeedExport()
        frmPPMFeedExport.ShowDialog()
    End Sub

    Private Sub PPMCollectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsPPMCollection.Click
        Dim frmPPMCollection As New FrmPPM_Collection()
        frmPPMCollection.ShowDialog()
    End Sub

    Private Sub PPMClearingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsPPMClearing.Click
        Dim frmPPMClearing As New FrmPPM_Clearing()
        frmPPMClearing.ShowDialog()
    End Sub

    Private Sub PPMServiceControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPMServiceControlToolStripMenuItem.Click
        'Dim FrmPPMServiceCollection As New FrmPPMServiceCollection()
        'frmPPMService.ShowDialog()
        Dim frmPPMServiceControl As New FrmPPMServiceControl
        frmPPMServiceControl.ShowDialog()
    End Sub

    Private Sub mnuMainBranchUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBranchUp.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Exit Sub
        filePath = ofd.FileName
        bgwCollectionBranchUp.RunWorkerAsync()
        frmUpWait.ShowDialog()
    End Sub

    Private Sub bgwCollectionBranchUp_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwCollectionBranchUp.DoWork
        Try

            Dim conStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;"
            Dim dt As New DataTable
            Dim conn As New OleDb.OleDbConnection(conStr)

            conn.Open()

            Dim dtSheets As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim listSheet As New List(Of String)
            Dim drSheet As DataRow

            For Each drSheet In dtSheets.Rows
                listSheet.Add(drSheet("TABLE_NAME").ToString())
            Next
            For Each sheet As String In listSheet
                'If (sheet.Contains("Filter")) Then
                'sheet = sheet.Replace("$", "")
                Dim da As New OleDb.OleDbDataAdapter("select * from [" + sheet + "]", conn)
                da.Fill(dt)
                Dim db As New SqlDatabase(CommonAppSet.ConnStr)
                Dim cmd As New System.Data.SqlClient.SqlCommand
                Dim dtE As New DataTable

                Using con As DbConnection = db.CreateConnection()
                    con.Open()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        cmd.CommandText = "select Branch_Code from Branch where Bank_Code='" _
                        + dt.Rows(i)("Bank Code").ToString() + "' and Branch_Code='" _
                        + dt.Rows(i)("Branch Code").ToString() + "' and Location_Code='" _
                        + dt.Rows(i)("Location Code").ToString() + "'"
                        dtE = db.ExecuteDataSet(cmd).Tables(0)
                        If (dtE.Rows.Count > 0) Then
                            cmd.CommandText = "update Branch set Branch_Name='" _
                            + dt.Rows(i)("Branch Name").ToString().Replace("'", "") + "',Routing_No='" _
                            + dt.Rows(i)("Routing No") + "'," _
                            + "Input_By='" _
                            + CommonAppSet.User + "',Input_DateTime=GETDATE()" _
                            + " where Bank_Code='" _
                            + dt.Rows(i)("Bank Code").ToString() + "' and Branch_Code='" _
                            + dt.Rows(i)("Branch Code").ToString() + "' and Location_Code='" _
                            + dt.Rows(i)("Location Code").ToString() + "'"
                        Else
                            cmd.CommandText = "insert into Branch(Bank_Code,Branch_Code," _
                            + "Branch_Name,Routing_No,Location_Code,Mod_No,Status,Input_By,Input_DateTime)" _
                            + " values('" + dt.Rows(i)("Bank Code").ToString() + "','" _
                            + dt.Rows(i)("Branch Code").ToString() _
                            + "','" + dt.Rows(i)("Branch Name").ToString().Replace("'", "") + "','" _
                            + dt.Rows(i)("Routing No").ToString() + "','" _
                            + dt.Rows(i)("Location Code").ToString() + "',1,'L','" _
                            + CommonAppSet.User + "',GETDATE())"
                        End If
                        cmd.Connection = con
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            Dim errMsg As String = ""
                            If (ex.Message.Contains("Cannot insert duplicate key in object 'dbo.BRANCH'. The duplicate ")) Then
                                errMsg = "Same Bank_Code and Branch_Code exists for this routing no. Duplicate Bank_Code and Branch_Code not Allowed ! "
                            ElseIf (ex.Message.Contains("String or binary data would be truncated")) Then
                                errMsg = "Branch_Name cannot contain more than 35 characters !"
                            Else
                                errMsg = ex.Message
                            End If
                            collectionUpErr = collectionUpErr + "Branch with Routing No: " + dt.Rows(i)("Routing_No").ToString() + " cannot be uploaded. Error: " + errMsg + vbNewLine
                            Using outputFile As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & Convert.ToString("\CCMS_BankBranchUploadErrorLog.txt"))
                                outputFile.WriteLine(clearingUpErr)
                            End Using
                        End Try

                    Next

                End Using
                'End If
            Next
            collectionUpCompleted = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            collectionUpCompleted = False
        End Try
    End Sub

    Private Sub bgwCollectionBranchUp_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCollectionBranchUp.RunWorkerCompleted
        frmUpWait.Close()
        If (collectionUpCompleted = True) Then
            If Not (String.IsNullOrEmpty(collectionUpErr)) Then
                'MessageBox.Show("The following branch(s) cannot be uploaded:(Routing numbers):" + collectionUpErr)
                MessageBox.Show("Upload completed with some errors !", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & Convert.ToString("\CCMS_BankBranchUploadErrorLog.txt"))
            Else
                MessageBox.Show("Upload Completed !", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub mnuMainClearBranchUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainClearBranchUp.Click
        Dim ofd As New OpenFileDialog
        If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Exit Sub
        filePath = ofd.FileName
        bgwClearingBranchUp.RunWorkerAsync()
        frmUpWait.ShowDialog()
    End Sub

    Private Sub bgwClearingBranchUp_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwClearingBranchUp.DoWork
        Try

            Dim conStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;"
            Dim dt As New DataTable
            Dim conn As New OleDb.OleDbConnection(conStr)

            conn.Open()

            Dim dtSheets As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim listSheet As New List(Of String)
            Dim drSheet As DataRow

            For Each drSheet In dtSheets.Rows
                listSheet.Add(drSheet("TABLE_NAME").ToString())
            Next
            For Each sheet As String In listSheet
                'If (sheet.Contains("Filter")) Then
                'sheet = sheet.Replace("$", "")
                Dim da As New OleDb.OleDbDataAdapter("select * from [" + sheet + "]", conn)
                da.Fill(dt)
                Dim db As New SqlDatabase(CommonAppSet.ConnStr)
                Dim cmd As New System.Data.SqlClient.SqlCommand
                Dim dtE As New DataTable

                Using con As DbConnection = db.CreateConnection()
                    con.Open()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        cmd.CommandText = "select Branch_Code from Clearing_Branch where " _
                        + "Routing_No='" + dt.Rows(i)("Routing_No").ToString() + "'"
                        dtE = db.ExecuteDataSet(cmd).Tables(0)
                        If (dtE.Rows.Count > 0) Then
                            cmd.CommandText = "update Clearing_Branch set Bank_Code='" _
                            + dt.Rows(i)("Bank_Code").ToString() + "',Branch_Code='" _
                            + dt.Rows(i)("Branch_Code").ToString() + "',Branch_Name='" _
                            + dt.Rows(i)("Branch_Name").ToString().Replace("'", "") + "',NIKBRANCH_CODE='" _
                            + dt.Rows(i)("Nik_Code_No").ToString() + "',Input_By='" _
                            + CommonAppSet.User + "',Input_DateTime=GETDATE()" _
                            + " where Routing_No='" _
                            + dt.Rows(i)("Routing_No").ToString() + "'"
                        Else
                            cmd.CommandText = "insert into Clearing_Branch(Bank_Code,Branch_Code," _
                            + "Branch_Name,Routing_No,Mod_No,Status,Input_By,Input_DateTime,NIKBRANCH_CODE)" _
                            + " values('" + dt.Rows(i)("Bank_Code").ToString() + "','" _
                            + dt.Rows(i)("Branch_Code").ToString() _
                            + "','" + dt.Rows(i)("Branch_Name").ToString().Replace("'", "") + "','" _
                            + dt.Rows(i)("Routing_No").ToString() + "'" _
                            + ",1,'L','" _
                            + CommonAppSet.User + "',GETDATE(),'" + dt.Rows(i)("Nik_Code_No").ToString() + "')"
                        End If
                        cmd.Connection = con
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            Dim errMsg As String = ""
                            If (ex.Message.Contains("Violation of PRIMARY KEY constraint 'PK__CLEARING_BRANCH__7B7B4DDC'. Cannot insert duplicate key in object 'dbo.CLEARING_BRANCH'. The duplicate ")) Then
                                errMsg = "Same Bank_Code and Branch_Code exists for this routing no. Duplicate Bank_Code and Branch_Code not Allowed ! "
                            ElseIf (ex.Message.Contains("String or binary data would be truncated")) Then
                                errMsg = "Branch_Name cannot contain more than 35 characters !"
                            Else
                                errMsg = ex.Message
                            End If
                            clearingUpErr = clearingUpErr + "Branch with Routing No: " + dt.Rows(i)("Routing_No").ToString() + " cannot be uploaded. Error: " + errMsg + vbNewLine
                            Using outputFile As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & Convert.ToString("\CCMS_BankBranchUploadErrorLog.txt"))
                                outputFile.WriteLine(clearingUpErr)
                            End Using
                        End Try

                    Next

                End Using
                'End If
            Next
            clearingUpCompleted = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            clearingUpCompleted = False
        End Try
    End Sub

    Private Sub bgwClearingBranchUp_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwClearingBranchUp.RunWorkerCompleted
        frmUpWait.Close()
        If (clearingUpCompleted = True) Then
            If Not (String.IsNullOrEmpty(clearingUpErr)) Then
                'MessageBox.Show("The following branch(s) cannot be uploaded:(Routing numbers):" + collectionUpErr)
                MessageBox.Show("Upload completed with some errors !", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & Convert.ToString("\CCMS_BankBranchUploadErrorLog.txt"))
            Else
                MessageBox.Show("Upload Completed !", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub mnuCollSpeedReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollSpeedReturn.Click

    End Sub

    Private Sub SummaryWithBearerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryWithBearerToolStripMenuItem.Click
        Dim frmCashWithBearerSum As New FrmCitiCashWithBearerSumm()
        frmCashWithBearerSum.Show()
    End Sub
End Class