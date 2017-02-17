Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql



Public Class FrmRptMonthBillCashCheck

    Dim _formName As String = "ReportReportsMonthlyBillCashManagement"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _ProcessSuccess As Boolean = False


    Private Sub PrepareBillData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)


            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_MonthBill")

            commProc1.Parameters.Clear()
            db.AddInParameter(commProc1, "@START_DATE", DbType.DateTime, dtpScheduleFrom.Value)
            db.AddInParameter(commProc1, "@END_DATE", DbType.DateTime, dtpScheduleTo.Value)

            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc1)
            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

            If result > 0 Then

                MessageBox.Show("Process Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If


            _ProcessSuccess = True



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        If (dtpScheduleFrom.Value > dtpScheduleTo.Value) Then
            MessageBox.Show("Ending date must not be lower than the Starting date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Dim rd As New crMonthBillCashCheck()

        rd.SetParameterValue("paramDateFrom", dtpScheduleFrom.Value)
        rd.SetParameterValue("paramDateTo", dtpScheduleTo.Value)

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        Dim strFormula As String = ""

        If txtClientCode.Text.Trim() = "" Then
            strFormula = "{V_MONTH_BILL.SCHEDULE_DATE}>=#" & dtpScheduleFrom.Value.ToString("MM/dd/yyyy") & _
                "# AND {V_MONTH_BILL.SCHEDULE_DATE}<=#" & dtpScheduleTo.Value.ToString("MM/dd/yyyy") & "#"



        Else
            strFormula = "{V_MONTH_BILL.SCHEDULE_DATE}>=#" & dtpScheduleFrom.Value.ToString("MM/dd/yyyy") & _
                "# AND {V_MONTH_BILL.SCHEDULE_DATE}<=#" & dtpScheduleTo.Value.ToString("MM/dd/yyyy") & _
                "# AND {V_MONTH_BILL.CLIENT_CODE}='" & txtClientCode.Text.Trim() & "'"





        End If

        If strFormula.Trim() <> "" Then
            frmRptViewer.SetFormula(strFormula)
        End If

        frmRptViewer.Show()

    End Sub











    Private Sub btnProcessBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessBill.Click
        If (dtpScheduleFrom.Value > dtpScheduleTo.Value) Then
            MessageBox.Show("Ending date must not be lower than the Starting date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ProgressBar1.Style = ProgressBarStyle.Marquee

        btnReport.Enabled = False

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub FrmRptMonthBillCashCheck_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub

    Private Sub FrmRptMonthBillCashCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        dtpScheduleFrom.Value = Date.Today
        dtpScheduleFrom.Value = Date.Today

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        _ProcessSuccess = False

        PrepareBillData()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous
        btnReport.Enabled = True

        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed for All Client!" + _
                            Environment.NewLine + "Now you can view report for all/single client", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)



        End If


    End Sub

    Private Sub txtClientCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClientCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtClientCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Client List"
                frmList.ProcName = "CMS_Client_GetList"

                frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}, {"CLIENT_CODE", "Code"}}

                frmList.colwidth = New Integer(,) {{1, 150}, {2, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "A/C No"}, {"2", "A/C Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtClientCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    txtAccName.Text = frmList.RowResult.Cells(2).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, txtClientCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then


                        txtAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

                    Else

                        txtClientCode.Clear()
                        txtAccName.Text = ""

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End If

            'If txtClientCode.Text.Trim() <> "" Then
            '    SendKeys.Send("{tab}")
            '    SendKeys.Send("{tab}")
            'End If

        End If
    End Sub

    Private Sub btnSearchClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClient.Click


        Dim frmList As New FrmList()
        frmList.Text = "Client List"
        frmList.ProcName = "CMS_Client_GetList"

        frmList.filter = New String(,) {{"ACC_NAME", "A/C Name"}, {"ACC_NO", "A/C No"}, {"CLIENT_CODE", "Code"}}

        frmList.colwidth = New Integer(,) {{1, 150}, {2, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "A/C No"}, {"2", "A/C Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtClientCode.Text = frmList.RowResult.Cells(0).Value.ToString()

            txtAccName.Text = frmList.RowResult.Cells(2).Value.ToString()

        End If

        frmList.Dispose()

    End Sub

End Class