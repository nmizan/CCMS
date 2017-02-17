'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Export goAML related information
'Creation date      : 23-July-2014
'Stored Procedure(s):  

Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Data
Imports System.Data.Common

Imports System.IO

Public Class FrmDepositExportGo

#Region "Global Variables"
    Dim _formName As String = "DepositExportGoAml"
    Dim opt As SecForm = New SecForm(_formName)
    'Dim log_message As String = ""
    'Dim _ReportPersonId As Integer = 0
    'Dim _ReportLoc As Integer = 0

    Dim _ProcessSuccess As Boolean = False
    Dim _FileNm As String = ""

    'Dim ErrorRow As Integer = 0

#End Region


#Region "User Define Function "

    Private Sub FileGenProcess()

        _FileNm = "CCMS_TO_CTR"
        _FileNm = _FileNm + ".csv"
        Dim owrite As System.IO.StreamWriter

        If Not Directory.Exists(txtFolderPath.Text.Trim()) Then
            Directory.CreateDirectory(txtFolderPath.Text.Trim())
        End If

        owrite = New System.IO.StreamWriter(txtFolderPath.Text.Trim() + "\" + _FileNm, False)


        Dim sLine As String = ""

        Dim ExlWS As New ArrayList()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCMSRefTabHist_GetCTRDet")

            Dim commProc As DbCommand = db.GetSqlStringCommand("SELECT CTR_REF,D_CODE, ACC_NO,AMOUNT,FLEXGEN_DATE" _
            + " FROM CCMSREF_TAB_HIST" _
 + " WHERE CTR_REF>0	AND ((FLEXGEN_DATE>=@FROM_DATE AND FLEXGEN_DATE<=@TO_DATE)" _
 + " OR CONVERT(datetime,CONVERT(varchar(12), FLEXGEN_DATE))=@TO_DATE)")

            db.AddInParameter(commProc, "@FROM_DATE", DbType.Date, NullHelper.StringToDate(txtDateFrom.Text.Trim))
            db.AddInParameter(commProc, "@TO_DATE", DbType.Date, NullHelper.StringToDate(txtDateTo.Text.Trim))

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()
                'CTR_REF,D_CODE,ACC_NO,AMOUNT,FLEXGEN_DATE

                ExlWS.Add(dt.Rows(i)("CTR_REF").ToString())
                ExlWS.Add(dt.Rows(i)("D_CODE").ToString())
                ExlWS.Add(dt.Rows(i)("ACC_NO").ToString())
                ExlWS.Add(dt.Rows(i)("AMOUNT").ToString())
                ExlWS.Add(Format(dt.Rows(i)("FLEXGEN_DATE"), "yyyyMMdd"))
                sLine = ""
                sLine = ExlWS.Item(0).ToString()
                For n = 1 To ExlWS.Count - 1
                    sLine = sLine + "," + ExlWS.Item(n).ToString()
                Next n

                owrite.WriteLine(sLine)

            Next i


            ''*****************************************************************************************
            ''End All Transaction
            ''*****************************************************************************************

            'sLine = ""
            'sLine = "~~END~~" + "," + "~~END~~"
            'owrite.WriteLine(sLine)

            owrite.Close()

            _ProcessSuccess = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not (owrite Is Nothing) Then
                owrite.Close()
            End If

        End Try


    End Sub

#End Region

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        fbdTransFile.ShowNewFolderButton = False
        fbdTransFile.ShowDialog()
        txtFolderPath.Text = fbdTransFile.SelectedPath
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If txtDateFrom.Text.Trim() = "/  /" Then
            MessageBox.Show("Date From required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDateFrom.Focus()
            Exit Sub

        End If

        If txtDateTo.Text.Trim() = "/  /" Then
            MessageBox.Show("Date To required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDateTo.Focus()
            Exit Sub
        End If

        If txtFolderPath.Text.Trim() = "" Then
            MessageBox.Show("Select folder", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnBrowse.Focus()
            Exit Sub
        End If


        ProgressBar1.Style = ProgressBarStyle.Marquee
        btnExport.Enabled = False
        btnBrowse.Enabled = False


        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        _ProcessSuccess = False

        FileGenProcess()


    End Sub

    Private Sub FrmDepositExportGo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundWorker1.IsBusy = True Then
            MessageBox.Show("Process is running.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
        End If
    End Sub

    Private Sub FrmDepositExportGo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous

        btnExport.Enabled = True
        btnBrowse.Enabled = True

        If _ProcessSuccess = True Then
            MessageBox.Show("Completed!!", "File Upload Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim frmCTRRefSearch As New FrmCTRRefSearch()
        frmCTRRefSearch.ShowDialog()
    End Sub
End Class