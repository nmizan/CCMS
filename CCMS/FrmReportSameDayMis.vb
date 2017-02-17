'
' Same Day MIS Report
' Author: Md. Fahad Khan
' Since: 03-Nov-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Imports Microsoft.Office.Interop
Imports System
Imports Outlook = Microsoft.Office.Interop.Outlook

Imports System.Net.Mail

Imports System.Net



Public Class FrmReportSameDayMis

#Region "Global Variables"

    Inherits System.Windows.Forms.Form

    Private moApp As Outlook.Application
    Private mbKillMe As Boolean = True

    Dim _formName As String = "DepositSameDayMisReport"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String = ""

    Dim _ProcessSuccess As Boolean = False

    Dim _PathReturn = Environment.CurrentDirectory + "\EmailData"

#End Region

#Region "User Defined Function"




#End Region

    Private Sub FrmReportSameDayMis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        cmbFlag.SelectedIndex = 0

        Dim i As Integer
        For i = 0 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)



            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Report_SameDayMis")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@DATE_FROM", DbType.DateTime, NullHelper.StringToDate(txtDateFrom.Text.Trim()))
            db.AddInParameter(commProc, "@DATE_TO", DbType.DateTime, NullHelper.StringToDate(txtDateTo.Text.Trim()))
            db.AddInParameter(commProc, "@FLAG", DbType.Int32, cmbFlag.SelectedIndex)
            'db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, NullHelper.ObjectToString(txtClientCode.Text.Trim()))
            'db.AddInParameter(commProc, "@ACC_NO", DbType.String, NullHelper.ObjectToString(txtAccNo.Text.Trim()))


            'ds = db.ExecuteDataSet(commProc)



            'If ds.Tables(0).Rows.Count > 0 Then



            '    dgView.AutoGenerateColumns = True
            '    dgView.DataSource = ds
            '    dgView.DataMember = ds.Tables(0).TableName

            'Else
            '    dgView.DataSource = Nothing

            'End If


            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                'If (i = dgView.Rows.Count - 1) Then
                '    dgView.Rows.Add()
                'End If
                'AC_NO, TRANSACTION_DATE, SLIP_NO, INSTRUMENT_TYPE, INSTRUMENT_NO, ISSUE_BANK, LOCATION, AMOUNT, 
                'CLIENT_CODE, FLAG, REMARKS, INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, STATUS

                dgView.Item(0, i).Value = dt.Rows(i).Item("AC_NO").ToString()
                dgView.Item(1, i).Value = NullHelper.DateToString(dt.Rows(i).Item("TRANSACTION_DATE"))
                dgView.Item(2, i).Value = dt.Rows(i).Item("SLIP_NO").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("INSTRUMENT_TYPE").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("INSTRUMENT_NO").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("ISSUE_BANK").ToString()
                dgView.Item(6, i).Value = dt.Rows(i).Item("LOCATION").ToString()
                dgView.Item(7, i).Value = dt.Rows(i).Item("AMOUNT")
                dgView.Item(8, i).Value = dt.Rows(i).Item("CLIENT_CODE").ToString()
                dgView.Item(9, i).Value = dt.Rows(i).Item("FLAG")
                dgView.Item(10, i).Value = dt.Rows(i).Item("REMARKS").ToString()


            Next i



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



       

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()
    End Sub

    Private Sub PrepareMailData()

        Try

            If MessageBox.Show("Do you really want to Send Email?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                Dim db As New SqlDatabase(CommonAppSet.ConnStr)





                Dim ds As New DataSet

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_SamedayMis_Email")

                commProc.Parameters.Clear()

                Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

                For i = 0 To dt.Rows.Count - 1



                    If NullHelper.ObjectToString(dt.Rows(i).Item("EMAIL").ToString()) = "" Then
                        MessageBox.Show("User Email Not Found " + NullHelper.ObjectToString(dt.Rows(i).Item("AC_NO").ToString()), "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                Next i




                For i = 0 To dt.Rows.Count - 1


                    Try


                        Dim ds2 As New DataSet

                        Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_SamedayMis_Email_Setting")

                        commProc2.Parameters.Clear()

                        Dim dt2 As DataTable = db.ExecuteDataSet(commProc2).Tables(0)

                        If dt2.Rows.Count > 0 Then

                            Dim MsgBody As String = ""

                            Dim SmtpServer As New SmtpClient()
                            Dim mail As New MailMessage()

                            SmtpServer.Credentials = New Net.NetworkCredential(NullHelper.ObjectToString(dt2.Rows(0).Item("EMAIL").ToString()), NullHelper.ObjectToString(dt2.Rows(0).Item("PASSWORD").ToString()))
                            SmtpServer.Port = NullHelper.ObjectToString(dt2.Rows(0).Item("PORT").ToString())
                            SmtpServer.Host = NullHelper.ObjectToString(dt2.Rows(0).Item("HOST").ToString())

                            mail = New MailMessage()
                            mail.From = New MailAddress(NullHelper.ObjectToString(dt2.Rows(0).Item("EMAIL").ToString()))

                            mail.Subject = NullHelper.ObjectToString(dt2.Rows(0).Item("SUBJECT").ToString())

                            mail.To.Add(NullHelper.ObjectToString(dt.Rows(i).Item("EMAIL").ToString()))

                            MsgBody += NullHelper.ObjectToString(dt2.Rows(0).Item("HEADING").ToString()) + Environment.NewLine


                            ' My.Computer.FileSystem.DeleteFile(_PathReturn & "\Attachment.xls")

                            Dim ds1 As New DataSet

                            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_SamedayMis_Email_Client")

                            commProc1.Parameters.Clear()

                            db.AddInParameter(commProc1, "@ACC_NO", DbType.String, NullHelper.ObjectToString(dt.Rows(i).Item("AC_NO").ToString()))

                            'Dim dt1 As DataTable = db.ExecuteDataSet(commProc1).Tables(0)

                            ds1 = db.ExecuteDataSet(commProc1)


                            Dim xlApp As New Excel.Application
                            Dim wb As Excel.Workbook
                            Dim sheet As Excel.Worksheet


                            wb = xlApp.Workbooks.Add
                            sheet = wb.Worksheets.Add

                            sheet.Name = "Deposit Slip Information"



                            Dim k As Integer


                            For j = 0 To ds1.Tables(0).Columns.Count - 1

                                sheet.Cells(1, j + 1) = ds1.Tables(0).Columns(j).ColumnName
                            Next j

                            For k = 0 To ds1.Tables(0).Rows.Count - 1
                                For j = 0 To ds1.Tables(0).Columns.Count - 1
                                    sheet.Cells(k + 2, j + 1) = ds1.Tables(0).Rows(k)(j).ToString()
                                Next j
                            Next k

                            CType(sheet.Rows(1, Type.Missing), Excel.Range).Font.Bold = True



                            'For j = 0 To dt1.Rows.Count - 1





                            '    'sheet.Cells(2, j - 2) = NullHelper.DateToString(dt1.Rows(j).Item("TRANSACTION_DATE")).ToString()
                            '    'sheet.Cells(3, j - 2) = dt1.Rows(j).Item("SLIP_NO").ToString()
                            '    'sheet.Cells(4, j - 2) = dt1.Rows(j).Item("AMOUNT").ToString()
                            '    'sheet.Cells(5, j - 2) = dgView.Item(j, i).Value.ToString()
                            '    'sheet.Cells(6, j - 2) = dgView.Item(j, i).Value.ToString()
                            '    'sheet.Cells(7, j - 2) = dgView.Item(j, i).Value.ToString()






                            '    ' MsgBody += Environment.NewLine + "Deposit Date : " + NullHelper.DateToString(dt1.Rows(j).Item("TRANSACTION_DATE")) & Environment.NewLine + "Slip No : " + dt1.Rows(j).Item("SLIP_NO").ToString() & Environment.NewLine + "Amount : " + dt1.Rows(j).Item("AMOUNT").ToString() + Environment.NewLine + "Bank : " + dt1.Rows(j).Item("ISSUE_BANK").ToString() & Environment.NewLine + "Location : " + dt1.Rows(j).Item("LOCATION").ToString() & Environment.NewLine + "------------------------------- "

                            'Next j

                            Dim todaysdate As String = DateTime.Now.ToString("ddMMyyyy")


                            ' Dim todaysdate As String = String.Format("{yyyyMMddHHmmss}", DateTime.Now)

                            ' MessageBox.Show(todaysdate)


                            wb.SaveAs(_PathReturn & "\" + todaysdate + i.ToString() + "Attachment.xls")

                            wb.Close()
                            xlApp.Quit()


                            Dim Attach = New Attachment(_PathReturn & "\" + todaysdate + i.ToString() + "Attachment.xls")

                            mail.Attachments.Add(Attach)

                            mail.Body = MsgBody + Environment.NewLine + NullHelper.ObjectToString(dt2.Rows(0).Item("END").ToString()) + Environment.NewLine
                            'SmtpServer.EnableSsl = True
                            SmtpServer.Send(mail)

                            ' Save Data In table

                            Dim commProcadd As DbCommand = db.GetStoredProcCommand("CMS_SameDayMisEmail_Add")

                            commProcadd.Parameters.Clear()
                            db.AddInParameter(commProcadd, "@CLIENT_CODE", DbType.String, NullHelper.ObjectToString(dt.Rows(i).Item("CLIENT_CODE").ToString()))
                            db.AddInParameter(commProcadd, "@ACC_NO", DbType.String, NullHelper.ObjectToString(dt.Rows(i).Item("AC_NO").ToString()))
                            db.AddInParameter(commProcadd, "@EMAIL", DbType.String, NullHelper.ObjectToString(dt.Rows(i).Item("EMAIL").ToString()))
                            db.AddInParameter(commProcadd, "@EMAIL_CONTENT", DbType.String, MsgBody)
                            db.AddInParameter(commProcadd, "@USER_ID", DbType.String, CommonAppSet.User)


                            db.ExecuteNonQuery(commProcadd)

                            Attach = Nothing





                        Else

                            MsgBox("Please Set Email Setting ", MsgBoxStyle.Information)
                            Return

                        End If


                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try


                Next i

                log_message = " Pending Deposit Information Sent to Client "
                Logger.system_log(log_message)

                MsgBox("Mail send Successfully ", MsgBoxStyle.Information)


            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendMail.Click

        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        _ProcessSuccess = False
        PrepareMailData()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous


        If _ProcessSuccess = True Then
            MessageBox.Show("! Mail Sent Completed !", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub FrmReportSameDayMis_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub
End Class