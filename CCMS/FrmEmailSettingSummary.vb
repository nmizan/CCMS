﻿
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmEmailSettingSummary

#Region "user defined codes"

    Dim _formName As String = "MaintenanceEmailSettingSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String

    'For Update
    Dim _Host As String = ""
    Dim _Port As String = ""
    Dim _Email As String = ""
    Dim _Pass As String = ""
    Dim _Sub As String = ""
    Dim _Heading As String = ""
    Dim _Footer As String = ""

    'For Auth
    Dim _aHost As String = ""
    Dim _aPort As String = ""
    Dim _aEmail As String = ""
    Dim _aPass As String = ""
    Dim _aSub As String = ""
    Dim _aHeading As String = ""
    Dim _aFooter As String = ""


    Dim EmailList As New List(Of String)
    Dim _emailLog As String = ""
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

        lblToolStatus.Text = ""

        Try
            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_GetDetailList")

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
            'ID, HOST, EMAIL, PASSWORD, PORT, SUBJECT, HEADING, END, EMAIL_GROUP, DEFAULT, 
            'INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, STATUS

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("S").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("ID").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("HOST").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("EMAIL").ToString()

                dgView.Item(6, i).Value = dt.Rows(i).Item("PORT").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("SUBJECT").ToString()

                dgView.Item(8, i).Value = dt.Rows(i).Item("HEADING").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("END").ToString()

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

    Private Sub FrmEmailSettingSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        lblToolStatus.Text = ""

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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()

    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try


            If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

                Dim frmEmailSetDet As New FrmEmailSettingDetail(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmEmailSetDet.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    '------------Mizan Work (19-05-2016)------------
    Private Sub LoadEmailDataForAuth(ByVal strId As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From CLIENT_MAIL_SETTING Where ID ='" & strId & "'  and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then

                _aHost = ds.Tables(0).Rows(0)("HOST").ToString()

                _aPort = ds.Tables(0).Rows(0)("PORT").ToString()

                _aEmail = ds.Tables(0).Rows(0)("EMAIL").ToString()

                _aPass = SecurePassword.Decrypt(ds.Tables(0).Rows(0)("PASSWORD").ToString())

                _aSub = ds.Tables(0).Rows(0)("SUBJECT").ToString()

                _aHeading = ds.Tables(0).Rows(0)("HEADING").ToString()

                _aFooter = ds.Tables(0).Rows(0)("END").ToString()


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------Mizan Work (19-05-2016)------------
    Private Sub LoadEmailData(ByVal strId As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@ID", DbType.Int32, strId)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _Host = ds.Tables(0).Rows(0)("HOST").ToString()

                _Port = ds.Tables(0).Rows(0)("PORT").ToString()

                _Email = ds.Tables(0).Rows(0)("EMAIL").ToString()

                _Pass = SecurePassword.Decrypt(ds.Tables(0).Rows(0)("PASSWORD").ToString())

                _Sub = ds.Tables(0).Rows(0)("SUBJECT").ToString()

                _Heading = ds.Tables(0).Rows(0)("HEADING").ToString()

                _Footer = ds.Tables(0).Rows(0)("END").ToString()

                
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

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientMailSetting_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then


                        '------------Mizan Work (19-05-2016)------------
                        LoadEmailData(dgView.Rows(i).Cells(3).Value.ToString(), dgView.Rows(i).Cells(1).Value)

                        If (dgView.Rows(i).Cells(1).Value) > 1 Then
                            LoadEmailDataForAuth(dgView.Rows(i).Cells(3).Value.ToString())
                        End If
                        '------------Mizan Work (19-05-2016)------------


                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@ID", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
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

                                If _aHost <> _Host Then
                                    log_message = " Host : " + _aHost + " " + " To " + " " + _Host + "." + " "
                                    EmailList.Add(log_message)
                                End If
                                If _aPort <> _Port Then
                                    log_message = " Port No : " + _aPort + " " + " To " + " " + _Port + "." + " "
                                    EmailList.Add(log_message)
                                End If
                                If _aSub <> _Sub Then
                                    log_message = " Email Subject : " + _aSub + " " + " To " + " " + _Sub + "." + " "
                                    EmailList.Add(log_message)
                                End If
                                If _aEmail <> _Email Then
                                    log_message = " Email : " + _aEmail + " " + " To " + " " + _Email + "." + " "
                                    EmailList.Add(log_message)
                                End If
                                If _aPass <> _Pass Then
                                    log_message = " Password : " + _aPass + " " + " To " + " " + _Pass + "." + " "
                                    EmailList.Add(log_message)
                                End If
                                If _aHeading <> _Heading Then
                                    log_message = " Email Heading : " + _aHeading + " " + " To " + " " + _Heading + "." + " "
                                    EmailList.Add(log_message)
                                End If
                                If _aFooter <> _Footer Then
                                    log_message = " Email Footer : " + _aFooter + " " + " To " + " " + _Footer + "." + " "
                                    EmailList.Add(log_message)
                                End If

                                For Each emailInfo As String In EmailList
                                    _emailLog += emailInfo
                                Next
                                _log = " Authorized :  Email ID : " + dgView.Rows(i).Cells(3).Value.ToString() + "." + " " + _emailLog

                                Logger.system_log(_log)

                                _emailLog = ""
                                EmailList.Clear()

                            Else

                                _log = " Authorized :  Email ID : " + dgView.Rows(i).Cells(3).Value.ToString()

                                Logger.system_log(_log)

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


    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If Not dgView.Rows(e.RowIndex).Cells(2).Value Is Nothing Then


                If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

                ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                End If
            End If

        End If
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmEmailSetDet As New FrmEmailSettingDetail(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmEmailSetDet.Show()
        End If
    End Sub



End Class