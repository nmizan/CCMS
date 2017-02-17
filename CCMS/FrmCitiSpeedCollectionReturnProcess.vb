

'
' Collection Return Process
' Author: Md. Fahad Khan
' Since: 05-Nov-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmCitiSpeedCollectionReturnProcess

#Region "Global Variables"

    Dim _formName As String = "CollectionCitiSpeedRetunProcess"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String = ""

    Dim _status As String = ""

#End Region

    Private Sub FrmCitiSpeedCollectionReturnProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)

        txtTransDate.Text = todaysdate.ToString()

    End Sub

    Private Function CheckValidData() As Boolean

        If txtTransDate.Text.Trim() = "/  /" Then
            MessageBox.Show("date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransDate.Focus()
            Return False
        End If


        Return True

    End Function

    Private Function ProcessData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Process_ReturnGenerate")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@RTN_DATE", DbType.DateTime, NullHelper.StringToDate(txtTransDate.Text.Trim()))

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Add

            Logger.system_log(" Collection Return Process : " + txtTransDate.Text.Trim() + " Completed Successfully")

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.AlreadyAuthorized

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.MakerCheckerSame
        ElseIf result = 7 Then
            tStatus = TransState.ModifiedOutside

        Else
            tStatus = TransState.UpdateNotPossible
        End If



        Return tStatus






    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Run Process?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = ProcessData()

                    If tState = TransState.Add Then

                        lblToolStatus.Text = "!! Process Done Successfully !!"



                    ElseIf tState = TransState.Exist Then
                        lblToolStatus.Text = "!! Already Exist !!"
                    ElseIf tState = TransState.NoRecord Then
                        lblToolStatus.Text = "!! Nothing to Found !!"
                    ElseIf tState = TransState.DBError Then
                        lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                    ElseIf tState = TransState.UnspecifiedError Then
                        lblToolStatus.Text = "!! Unpecified Error Occured !!"
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class