'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Generate DD information for Sub-system
'Creation date      : 27-May-2013
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

Public Class FrmSubSysDDInfo

  

    Private _Seq_No As Integer
    Private _Batch_No As String = ""
    Private _Ref_No As String = ""
    Dim _FileNm As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _PathDD = Environment.CurrentDirectory + "\DDFile"
    Dim _strFileName As String = ""


#Region "User defined Procedures"

    Private Function CheckSpace(ByVal DataField As String, ByVal FieldLength As Integer) As String

        Dim ilength As Integer
        ilength = DataField.Length
        ilength = FieldLength - ilength
        CheckSpace = CStr(DataField) + Space(ilength)

    End Function

    Private Sub FlexFileGen()

        Dim owrite As System.IO.StreamWriter
        Dim oprdate As Date = dtpDate.Value

        Dim expseq As String
        Dim expfile As String
        Dim sDDAccno As String

        Dim sDSNO As String

        Dim exptext As String

        'Dim A, B, c, d, e, f, g, h, K, l, j, m, n, o, p, q, r, s, t, u, v, w As String

        Dim A, B, c, d, e, f, g, h, K, l, j, m, n, o, p, q, r, s, t, u, v, w As String
        Dim i As Integer



        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_GetDetailForSubsystem")
            db.AddInParameter(commProc, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
            db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDSCode.Text.Trim())

            Dim dt2 As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            If dt2.Rows.Count = 0 Then

                MessageBox.Show("No record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            expseq = Date.Today.ToString("ddMM")
            'Mid(Format(Date, "dd/mm/yyyy"), 1, 2) & Mid(Format(Date, "dd/mm/yyyy"), 4, 2)

            expfile = Date.Today.ToString("yy")
            'Right(Format(Date, "dd/mm/yyyy"), 2)

            expfile = "DD" + expseq + expfile + ".dat"

            _FileNm = expfile

            If Not Directory.Exists(_PathDD) Then
                Directory.CreateDirectory(_PathDD)
            End If

            owrite = New System.IO.StreamWriter(_PathDD + "\" + _FileNm, False)

            sDDAccno = Trim(txtAccNo.Text.Trim())

            'Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TmpReversal_GetFlexDrDetail")
            'db.AddInParameter(commProc2, "@ACC_NO", DbType.String, txtAccNo.Text.Trim())
            'db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDSCode.Text.Trim())

            'Dim dt2 As DataTable = db.ExecuteDataSet(commProc2).Tables(0)

            i = sDDAccno.Length

            For row = 0 To dt2.Rows.Count - 1

                exptext = "" : A = "" : B = "" : c = "" : d = "" : e = "" : f = "" : g = "" : h = "" : K = "" : l = "" : m = "" : n = "" : o = "" : p = "" : q = "" : r = "" : s = "" : t = ""
                A = NullHelper.ObjectToString(dt2.Rows(row)(0)).Trim().Length : B = NullHelper.ObjectToString(dt2.Rows(row)(1)).Trim().Length : c = NullHelper.ObjectToString(dt2.Rows(row)(2)).Trim().Length : d = NullHelper.ObjectToString(dt2.Rows(row)(3)).Trim().Length
                e = NullHelper.ObjectToString(dt2.Rows(row)(4)).Trim().Length : f = (NullHelper.ObjectToString(dt2.Rows(row)(5)).Trim() + Space(1)).Length : g = NullHelper.ObjectToString(dt2.Rows(row)(6)).Trim().Length : h = NullHelper.ObjectToString(dt2.Rows(row)(7)).Trim().Length
                i = sDDAccno.Trim().Length  'i = Len(Trim(dt2.Rows(row)(8)))
                : K = oprdate.ToString("MM/dd/yyyy").Trim().Length


                sDSNO = NullHelper.ObjectToString(dt2.Rows(row)("D_CODE")) + NullHelper.ObjectToString(dt2.Rows(row)("SLNO")).PadLeft(3, "0")
                '--- need review for sDSNO space size CheckSpace(sDSNO, 8)
                '------------------------------------------------------------
                '--- update by shanto [19-Jun-2013]
                '--- changing sDSNO space size from CheckSpace(sDSNO, 15) to CheckSpace(sDSNO, 8) 
                '-----------------------------------------------------------
                exptext = "003" _
                   + CheckSpace(NullHelper.ObjectToString(dt2.Rows(row)(1)), 7) + CheckSpace(NullHelper.DateToString(dt2.Rows(row)(2), "MM/dd/yyyy"), 10) + _
                   CheckSpace(oprdate.ToString("MM/dd/yyyy"), 10) + IIf(e < 15, CStr(Trim(dt2.Rows(row)(4))) + Space(15 - e), CStr(NullHelper.ObjectToString(dt2.Rows(row)(4)).Trim())) _
                   + CStr(IIf(f < 3, CStr(NullHelper.ObjectToString(dt2.Rows(row)(5)).Trim()) + Space(3 - f), CStr(dt2.Rows(row)(5)))) _
                   + CStr(IIf(g < 12, CStr(NullHelper.ObjectToString(dt2.Rows(row)(6)).Trim()) + Space(12 - g), CStr(NullHelper.ObjectToString(dt2.Rows(row)(6)).Trim()))) _
                   + CheckSpace(sDSNO, 8) _
                   + CStr(IIf(i < 16, CStr(Trim(sDDAccno)) + Space(16 - i), CStr(Trim(sDDAccno)))) _
                   + "P" + "2600001" + "0"

                owrite.WriteLine(exptext)


            Next



            Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetGroupForSubSysByNik")
            db.AddInParameter(commProc3, "@ACC_NO", DbType.String, "9275590007")
            db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDSCode.Text.Trim())

            Dim dt3 As DataTable = db.ExecuteDataSet(commProc3).Tables(0)


            For row = 0 To dt3.Rows.Count - 1

                exptext = "" : A = "" : B = "" : c = "" : d = "" : e = "" : f = "" : g = "" : h = ""
                A = Len(dt3.Rows(row)(0)) : B = Len(dt3.Rows(row)(1)) : c = NullHelper.ObjectToString(dt3.Rows(row)(2)).Trim().Length : d = Len(dt3.Rows(row)(3)) : e = Len(dt3.Rows(row)(4))
                f = Len(dt3.Rows(row)(5))
                '-- need review CStr(IIf(A < 8, CStr(dt3.Rows(row)(0)) + Space(8 - A), CStr(dt3.Rows(row)(0))))
                exptext = "004" _
                + CStr(IIf(A < 12, CStr(dt3.Rows(row)(0)) + Space(12 - A), CStr(dt3.Rows(row)(0)))) _
                + CStr(IIf(B < 35, CStr(dt3.Rows(row)(1)) + Space(35 - B), CStr(dt3.Rows(row)(1)))) _
                + CStr(IIf(c < 35, CStr(dt3.Rows(row)(2)) + Space(35 - c), CStr(dt3.Rows(row)(2)))) _
                + oprdate.ToString("MM/dd/yyyy") _
                + CStr(IIf(e < 15, CStr(dt3.Rows(row)(4)) + Space(15 - e), CStr(dt3.Rows(row)(4)))) _
                + CStr(IIf(f < 3, CStr(dt3.Rows(row)(5)) + Space(10 - f), CStr(dt3.Rows(row)(5))))


                owrite.WriteLine(exptext)

            Next

            owrite.Close()

            _FileSuccess = True



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not (owrite Is Nothing) Then
                owrite.Close()
            End If

        End Try


        '''''''''''''''''''''''''''




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

        '_ProcessSuccess = False
        _FileSuccess = False

        'btnViewReversalData.Enabled = False

        'PrepareReversalData()

        FlexFileGen()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous
        btnViewDDBreakupReport.Enabled = True

        If _FileSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "File is ready for Accumulation!!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathDD & "\" & _FileNm)

        End If



    End Sub








    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If txtAccNo.Text.Trim() = "" Then

            MessageBox.Show("Please enter A/C No.", "A/C No required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccNo.Focus()
            Exit Sub

        End If

        If txtDSCode.Text.Trim() = "" Then

            MessageBox.Show("Please enter Deposit code.", "Deposit Code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDSCode.Focus()
            Exit Sub

        End If

        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnViewDDBreakupReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDDBreakupReport.Click

        If txtDSCode.Text.Trim() = "" Then

            MessageBox.Show("Please enter deposit code.", "Deposit Code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDSCode.Focus()
            Exit Sub

        End If

        Dim rd As New crDDBreakupWithCheck

        rd.RecordSelectionFormula = "{V_DD_BREAKUP.dd_dcode}='" & txtDSCode.Text.Trim() & "'"


        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)


        frmRptViewer.Show()


    End Sub

    Private Sub FrmSubSysDDInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpDate.Value = DateTime.Today
    End Sub

    Private Sub txtDSCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDSCode.Validated
        If txtDSCode.Text.Trim() <> "" Then
            txtDSCode.Text = txtDSCode.Text.Trim().PadLeft(5, "0")
        End If
    End Sub

    Private Sub txtAccNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDSCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDSCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class