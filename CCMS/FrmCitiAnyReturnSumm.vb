Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmCitiAnyReturnSumm

#Region "user defined codes"

    Dim _formName As String = "CollectionCitiAnywhereReturnSummary"
    Dim opt As SecForm = New SecForm(_formName)
    Dim log_message As String = ""

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

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetDetailList")

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
                dgView.Item(3, i).Value = dt.Rows(i).Item("NONZONE_REF").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("CHECK_NO").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("CHECK_AMOUNT").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("D_CODE").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("RTN_STATUS").ToString()
                dgView.Item(8, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(9, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(10, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(11, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(12, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
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

                Dim frmAnyRetDet As New FrmCitiAnyReturnDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmAnyRetDet.Show()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmAnyRetDet As New FrmCitiAnyReturnDet()
        frmAnyRetDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmAnyRetDet As New FrmCitiAnyReturnDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmAnyRetDet.Show()
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

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Try



            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim i As Integer

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_Auth")

                Dim cmd As New System.Data.SqlClient.SqlCommand
                Dim dtNonZoneRef As New DataTable
              

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then


                        Dim cmd1 As DbCommand = db.GetSqlStringCommand("Delete from NCollection_Hist where NONZONE_REF=@NONZONE_REF" _
                                                              + " and MOD_NO=(select MOD_NO from NCOLLECTION where" _
                                                              + " NONZONE_REF=@NONZONE_REF)")
                        cmd1.Parameters.Clear()
                        db.AddInParameter(cmd1, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(cmd1, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        Try
                            db.ExecuteNonQuery(cmd1)
                        Catch
                        End Try

                        cmd.CommandText = "select NONZONE_REF from NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO"

                        cmd.Parameters.Clear()
                        db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)

                        dtNonZoneRef = db.ExecuteDataSet(cmd).Tables(0)
                        Dim dtNCollection As New DataTable
                        Dim dtDCode As New DataTable
                        Dim dtNCOLLECTION_CCHECK_HIST As New DataTable

                        If (dtNonZoneRef.Rows.Count > 0) Then
                            If dgView.Rows(i).Cells(1).Value > 1 Then

                                cmd.CommandText = "SELECT REF_DATE, DDREFNO, AMOUNT, VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, RTN_STATUS, RTN_CODE, INPUT_BY, INPUT_DATETIME,INPUT_FROM,IS_AUTH,[STATUS] FROM NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                                dtNCollection = db.ExecuteDataSet(cmd).Tables(0)
                                If (dtNCollection.Rows(0)("INPUT_BY").ToString() = CommonAppSet.User) Then
                                    MessageBox.Show("You cannot authorize the transaction", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                                cmd.CommandText = "INSERT INTO NCOLLECTION_HIST SELECT [NONZONE_REF],[REF_DATE],[DDREFNO],[AMOUNT],[VAT],[COMMISION],[POSTAGE_CHARGE],[INSTRUMENT_EXP],[RTN_STATUS],[RTN_CODE],[INPUT_BY],[INPUT_DATETIME],[INPUT_FROM],[AUTH_BY],[AUTH_DATETIME],[AUTH_FROM],[MOD_NO],[STATUS],1 FROM NCOLLECTION WHERE NONZONE_REF=@NONZONE_REF;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "UPDATE NCOLLECTION_HIST SET [STATUS] = 'O' WHERE NONZONE_REF=@NONZONE_REF AND [STATUS] = 'L';"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                db.ExecuteNonQuery(cmd)

                                cmd.CommandText = "UPDATE NCOLLECTION SET REF_DATE=@REF_DATE, DDREFNO=@DDREFNO, AMOUNT=@AMOUNT, VAT=@VAT, COMMISION=@COMMISION, POSTAGE_CHARGE=@POSTAGE_CHARGE, INSTRUMENT_EXP=@INSTRUMENT_EXP, RTN_STATUS=@RTN_STATUS, RTN_CODE=@RTN_CODE, INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,INPUT_FROM=@INPUT_FROM,AUTH_BY=@AUTH_BY,AUTH_DATETIME=GETDATE(),AUTH_FROM=@AUTH_FROM,MOD_NO=@MOD_NO,[STATUS]='L' WHERE NONZONE_REF=@NONZONE_REF;"
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("@REF_DATE", dtNCollection.Rows(0)("REF_DATE"))
                                cmd.Parameters.AddWithValue("@DDREFNO", dtNCollection.Rows(0)("DDREFNO"))
                                cmd.Parameters.AddWithValue("@AMOUNT", dtNCollection.Rows(0)("AMOUNT"))
                                cmd.Parameters.AddWithValue("@VAT", dtNCollection.Rows(0)("VAT"))
                                cmd.Parameters.AddWithValue("@COMMISION", dtNCollection.Rows(0)("COMMISION"))
                                cmd.Parameters.AddWithValue("@POSTAGE_CHARGE", dtNCollection.Rows(0)("POSTAGE_CHARGE"))
                                cmd.Parameters.AddWithValue("@INSTRUMENT_EXP", dtNCollection.Rows(0)("INSTRUMENT_EXP"))
                                cmd.Parameters.AddWithValue("@RTN_STATUS", dtNCollection.Rows(0)("RTN_STATUS"))
                                cmd.Parameters.AddWithValue("@RTN_CODE", dtNCollection.Rows(0)("RTN_CODE"))
                                cmd.Parameters.AddWithValue("@INPUT_BY", dtNCollection.Rows(0)("INPUT_BY"))
                                cmd.Parameters.AddWithValue("@INPUT_DATETIME", dtNCollection.Rows(0)("INPUT_DATETIME"))
                                cmd.Parameters.AddWithValue("@INPUT_FROM", dtNCollection.Rows(0)("INPUT_FROM"))
                                cmd.Parameters.AddWithValue("@AUTH_BY", CommonAppSet.User)
                                cmd.Parameters.AddWithValue("@AUTH_FROM", CommonAppSet.User)
                                cmd.Parameters.AddWithValue("@MOD_NO", dgView.Rows(i).Cells(1).Value)
                                cmd.Parameters.AddWithValue("@NONZONE_REF", dgView.Rows(i).Cells(3).Value.ToString())
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "DELETE NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0;"
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("@NONZONE_REF", dgView.Rows(i).Cells(3).Value.ToString())
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "	SELECT D_CODE FROM CCHECK WHERE NONZONE_REF =@NONZONE_REF"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                dtDCode = db.ExecuteDataSet(cmd).Tables(0)
                                cmd.CommandText = "DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "INSERT INTO CCHECKTOTAL_HIST SELECT D_CODE,TOTAL_CHKNO,TOTAL_CHKAMT,INPUT_BY,INPUT_DATETIME,INPUT_FROM,AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 1 FROM CCHECKTOTAL WHERE D_CODE =@D_CODE"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "UPDATE CCHECKTOTAL_HIST SET [STATUS] = 'O' WHERE D_CODE=@D_CODE AND [STATUS] = 'L';"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "UPDATE CCHECKTOTAL SET INPUT_BY=@INPUT_BY,INPUT_DATETIME=@INPUT_DATETIME,INPUT_FROM=@INPUT_FROM,AUTH_BY=@AUTH_BY,AUTH_DATETIME=GETDATE(),AUTH_FROM=@AUTH_FROM, MOD_NO=MOD_NO+1 WHERE D_CODE=@D_CODE;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.AddInParameter(cmd, "@INPUT_BY", DbType.String, dtNCollection.Rows(0)("INPUT_BY"))
                                cmd.Parameters.AddWithValue("@INPUT_DATETIME", dtNCollection.Rows(0)("INPUT_DATETIME"))
                                cmd.Parameters.AddWithValue("@INPUT_FROM", dtNCollection.Rows(0)("INPUT_FROM"))
                                cmd.Parameters.AddWithValue("@AUTH_BY", CommonAppSet.User)
                                cmd.Parameters.AddWithValue("@AUTH_FROM", CommonAppSet.User)
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "DELETE CCHECK_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE,CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH, REMINDER_DATE, REMINDER_NO, RTN_CODE) SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO,1, REMINDER_DATE, REMINDER_NO, RTN_CODE FROM CCHECK WHERE D_CODE=@D_CODE;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "UPDATE CCHECK SET MOD_NO=MOD_NO+1 WHERE D_CODE=@D_CODE;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@D_CODE", DbType.String, dtDCode.Rows(0)("D_CODE"))
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "SELECT RTN_STATUS,RTN_CODE FROM NCOLLECTION_CCHECK_HIST WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                                dtNCOLLECTION_CCHECK_HIST = db.ExecuteDataSet(cmd).Tables(0)
                                If (dtNCOLLECTION_CCHECK_HIST.Rows(0)("RTN_STATUS") = "O") Then
                                    cmd.CommandText = "UPDATE CCHECK SET RTN_STATUS='O', RTN_CODE=NULL,[FILENAME]=NULL ,FILE_USER_ID=NULL,FLEXGEN_DATE=NULL WHERE NONZONE_REF=@NONZONE_REF;"
                                    cmd.Parameters.Clear()
                                    db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                    db.ExecuteNonQuery(cmd)
                                Else
                                    cmd.CommandText = "UPDATE CCHECK SET RTN_STATUS=@CC_RTN_STATUS, RTN_CODE=@CC_RTN_CODE WHERE NONZONE_REF=@NONZONE_REF;"
                                    cmd.Parameters.Clear()
                                    db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                    db.AddInParameter(cmd, "@CC_RTN_STATUS", DbType.String, dtNCOLLECTION_CCHECK_HIST.Rows(0)("RTN_STATUS"))
                                    db.AddInParameter(cmd, "@CC_RTN_CODE", DbType.String, dtNCOLLECTION_CCHECK_HIST.Rows(0)("RTN_CODE"))
                                    db.ExecuteNonQuery(cmd)
                                End If
                                cmd.CommandText = "UPDATE NCOLLECTION_CCHECK_HIST set IS_AUTH = 1 WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                                db.ExecuteNonQuery(cmd)
                                cmd.CommandText = "Update NCOLLECTION_HIST set IS_AUTH = 1 WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                                cmd.Parameters.Clear()
                                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                                db.ExecuteNonQuery(cmd)
                            End If

                        End If

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(10).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        'db.ExecuteNonQuery(commProc)
                        'result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                        result = db.ExecuteNonQuery(cmd)

                        If result = 0 Then
                            lblToolStatus.Text = "Information Authorized Successfully !! "
                            '--------------Mizan Work (16-05-2016)------------------
                            log_message = " Authorized : Non Zone Ref No : " + dgView.Rows(i).Cells(3).Value.ToString()
                            Logger.system_log(log_message)
                            '--------------Mizan Work (16-05-2016)------------------
                        ElseIf result = 1 Then

                            'MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

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