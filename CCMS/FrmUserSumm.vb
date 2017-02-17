
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmUserSumm

#Region "user defined codes"

    Dim _formName As String = "SystemUsersSummary"
    Dim opt As SecForm = New SecForm(_formName, CommonAppSet.IsAdmin)

    Dim log_message As String = ""
    'For Update
    Dim _userName As String = ""
    Dim _deptName As String = ""
    Dim _domain As String = ""
    'For Auth
    Dim _auserName As String = ""
    Dim _adeptName As String = ""
    Dim _adomain As String = ""

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

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_GetDetailList")

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
                dgView.Item(1, i).Value = dt.Rows(i).Item("SLNO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("S").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("USERS_ID").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("USERS_NAME").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("DEPT_NAME").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("USER_STAT").ToString()
                dgView.Item(8, i).Value = NullHelper.ToBool(dt.Rows(i).Item("IS_ADMIN"))
                dgView.Item(9, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(10, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(11, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(12, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(13, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
            Next


        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub FrmUserSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        'LoadDataGrid()


        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try

        
            If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing) Then
                Dim frmUserDet As New FrmUsersDet(dgView.SelectedRows.Item(0).Cells(4).Value, dgView.SelectedRows.Item(0).Cells(2).Value)
                frmUserDet.ShowDialog()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmUserDet As New FrmUsersDet
        frmUserDet.ShowDialog()

    End Sub

    
    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick

        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then
            Dim frmUserDet As New FrmUsersDet(dgView.SelectedRows.Item(0).Cells(4).Value, dgView.SelectedRows.Item(0).Cells(2).Value)
            frmUserDet.ShowDialog()
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

    '----------Mizan Work (19-05-2016)---------------

    Private Sub LoadUsersDataForAuth(ByVal strUsersCode As String)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            ds = db.ExecuteDataSet(CommandType.Text, "Select * From USERS  Where USERS_ID ='" & strUsersCode & "' and STATUS='L'")

            If ds.Tables(0).Rows.Count > 0 Then


                _
                _auserName = ds.Tables(0).Rows(0)("USERS_NAME").ToString()

                _adeptName = ds.Tables(0).Rows(0)("DEPT_SLNO")

                _adomain = ds.Tables(0).Rows(0)("DOMAIN").ToString()



                Dim ds2 As New DataSet
                ds2 = db.ExecuteDataSet(CommandType.Text, "Select *  From DEPARTMENT Where SLNO ='" & _adeptName & "' ")
                If ds2.Tables(0).Rows.Count > 0 Then

                    _adeptName = ds2.Tables(0).Rows(0)("DEPT_NAME").ToString()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '--------------Mizan Work (19-05-2016---------
    Private Sub LoadUsersData(ByVal strUsersCode As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@USERS_ID", DbType.String, strUsersCode)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then


               
                _userName = ds.Tables(0).Rows(0)("USERS_NAME").ToString()
                _deptName = ds.Tables(0).Rows(0)("DEPT_SLNO")

                _domain = ds.Tables(0).Rows(0)("DOMAIN").ToString()
                

                Dim ds2 As New DataSet
                ds2 = db.ExecuteDataSet(CommandType.Text, "Select *  From DEPARTMENT Where SLNO ='" & _deptName & "' ")
                If ds2.Tables(0).Rows.Count > 0 Then

                    _deptName = ds2.Tables(0).Rows(0)("DEPT_NAME").ToString()

                End If
                

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Try



            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim i As Integer

                Dim count As Integer = 0

                Dim userId As String = ""

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Users_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        '------------Mizan Work (19-05-2016)------------
                        LoadUsersData(dgView.Rows(i).Cells(4).Value.ToString(), dgView.Rows(i).Cells(2).Value)

                        If (dgView.Rows(i).Cells(2).Value) > 1 Then
                            LoadUsersDataForAuth(dgView.Rows(i).Cells(4).Value.ToString())
                        End If
                        '------------Mizan Work (19-05-2016)------------

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@USERS_ID", DbType.String, dgView.Rows(i).Cells(4).Value)
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(2).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(11).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then
                            count = count + 1
                            If (count = 1) Then
                                userId = dgView.Rows(i).Cells(4).Value.ToString()
                            ElseIf (count > 1) Then
                                userId = "," + dgView.Rows(i).Cells(4).Value.ToString()
                            End If
                            lblToolStatus.Text = "Information Authorized Successfully !! "

                            '----------Mizan Work (17-05-2016)---------------

                            If _auserName <> _userName And _adomain <> _domain And _adeptName <> _deptName Then
                                If _auserName = "" And _adomain = "" And _adeptName = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _userName + "." + " " + " Department : " + _deptName + "." + " " + " Domain : " + _domain
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain
                                End If
                                Logger.system_log(log_message)

                            ElseIf _auserName <> _userName And _adomain <> _domain Then
                                If _auserName = "" And _adomain = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _userName + "." + " " + " Domain : " + _domain
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain
                                End If
                                Logger.system_log(log_message)
                            ElseIf _auserName <> _userName And _adeptName <> _deptName Then
                                If _auserName = "" And _adeptName = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _userName + "." + " " + " Department : " + _deptName
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName
                                End If
                                Logger.system_log(log_message)
                            ElseIf _adomain <> _domain And _adeptName <> _deptName Then
                                If _adomain = "" And _adeptName = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Domain : " + _domain + "." + " " + " Department : " + _deptName
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName
                                End If

                                Logger.system_log(log_message)
                            ElseIf _auserName <> _userName Then
                                If _auserName = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _userName
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " User Name : " + _auserName + " " + " To " + " " + _userName
                                End If
                                Logger.system_log(log_message)
                            ElseIf _adeptName <> _deptName Then
                                If _adeptName = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Department : " + _deptName
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Department : " + _adeptName + " " + " To " + " " + _deptName
                                End If
                                Logger.system_log(log_message)
                            ElseIf _adomain <> _domain Then
                                If _adomain = "" Then
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Domain : " + _domain
                                Else
                                    log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString() + "." + " " + " Domain : " + _adomain + " " + " To " + " " + _domain
                                End If
                                Logger.system_log(log_message)
                            Else
                                log_message = " Authorized : User Id : " + dgView.Rows(i).Cells(4).Value.ToString()
                                Logger.system_log(log_message)
                            End If


                            '----------Mizan Work (17-05-2016)---------------

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
                If (count > 0) Then
                    '    Logger.system_log("User Id:" + userId + " has been Authorized")
                End If
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
End Class