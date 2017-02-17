'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : PDC Transfer to Clearing Detail
'Creation date      : 22-Jul-2013
'Stored Procedure(s):  
'


Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmPDCTransfer

    Dim _formName As String = "ClearingPDCTransfer"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _ProcessSuccess As Boolean = False
    

#Region "User defined Procedures"

    Private Sub PDCTransfer()


        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()


                ''''''''''''''''''''''''''''''''''''''' ok
                Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_PDCTransfer")

                commProc1.Parameters.Clear()

                db.AddInParameter(commProc1, "@OPR_DATE", DbType.DateTime, dtpDate.Value)
                db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc1, trans)
                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                
                trans.Commit()
                _ProcessSuccess = True

            End Using



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region




    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    Private Sub FrmReversalGen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub








    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        _ProcessSuccess = False


        'btnViewReversalData.Enabled = False

        'PrepareReversalData()

        PDCTransfer()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous


        If _ProcessSuccess = True Then
            MessageBox.Show("! Transfer Completed !" + _
                            Environment.NewLine + "", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)



        End If



    End Sub








    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

        If cmbEntryLocation.SelectedIndex = -1 Then
            MessageBox.Show("Select Entry Location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbEntryLocation.Focus()
            Exit Sub
        End If


        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    

    
    Private Sub FrmPDCTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        CommonUtil.FillComboBox("CMS_CitiBankBranch_GetList", cmbEntryLocation)

        dtpDate.Value = DateTime.Today

    End Sub
End Class