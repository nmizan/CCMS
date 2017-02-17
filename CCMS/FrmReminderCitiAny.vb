'
' Reminder Process for CitiAnywhere Check
' Author: Iftekharul Alam Khan Lodi
' Since: 20-Feb-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql



Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmReminderCitiAny

#Region "Global Variables"
    Dim _formName As String = "DepositCitiAnywhereReminderProc"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _procStatus As Boolean = False
#End Region


#Region "User defined Procedures"

    Private Sub ReminderProcess()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_ReminderCitiAny")

            commProc1.Parameters.Clear()

            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc1)
            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

            If result > 0 Then
                MessageBox.Show("Process Error. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            _procStatus = True
            

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    








    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        ReminderProcess()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous
        If _procStatus = True Then
            lblToolStatus.Text = "Process completed."
            MessageBox.Show("! Process Completed !", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            lblToolStatus.Text = "Process failed."
            MessageBox.Show("! Process Failed !", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        btnReminderProcess.Enabled = True

    End Sub



    

    Private Sub btnReminderProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderProcess.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        btnReminderProcess.Enabled = False

        lblToolStatus.Text = "Process is running.."

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub FrmReminderCitiAny_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub

    Private Sub FrmReminderCitiAny_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub
End Class