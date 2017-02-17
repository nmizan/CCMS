'
'Author             : Iftekharul Alam Khan Lodi
'Purpose            : Import Return XML file
'Creation date      : 24-Jul-2013
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
Imports System.Xml


Public Class FrmClearRetImport

    Dim _formName As String = "ClearingReturnFileUpload"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _ProcessSuccess As Boolean = False

    Dim _ToTRecordNo As Integer = 0
    Dim _TotMismatchRec As Integer = 0


#Region "User defined Procedures"

    'Private Sub PDCTransfer()


    '    lblToolStatus.Text = ""

    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Using conn As DbConnection = db.CreateConnection()

    '            conn.Open()

    '            Dim trans As DbTransaction = conn.BeginTransaction()


    '            ''''''''''''''''''''''''''''''''''''''' ok
    '            Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_PDCTransfer")

    '            commProc1.Parameters.Clear()

    '            db.AddInParameter(commProc1, "@OPR_DATE", DbType.DateTime, dtpDate.Value)
    '            db.AddInParameter(commProc1, "@ENTRY_LOC", DbType.String, cmbEntryLocation.SelectedValue)

    '            db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '            Dim result As Integer

    '            db.ExecuteNonQuery(commProc1, trans)
    '            result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

    '            If result > 0 Then
    '                trans.Rollback()
    '                MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub

    '            End If


    '            trans.Commit()
    '            _ProcessSuccess = True

    '        End Using



    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try


    'End Sub

    Private Function AddIRE(ByVal RoutingNo As String, ByVal ChequeSec As String, ByVal ItemAmt As String, ByVal SeqNo As String, ByVal RetReason As String) As Boolean

        Dim l As Integer = ItemAmt.Length
        Dim AmtFirst As String = ItemAmt.Substring(0, l - 2)
        Dim AmtLast As String = ItemAmt.Substring(l - 2)

        ItemAmt = AmtFirst & "." & AmtLast

        Dim dItemAmt As Decimal = NullHelper.ToDecNum(ItemAmt)

        'MessageBox.Show(ChequeSec & Environment.NewLine & ItemAmt & Environment.NewLine & RetReason _
        '                & Environment.NewLine & dItemAmt.ToString())

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IRERet_Add")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@PayorBankRoutingNumber", DbType.String, RoutingNo.Trim())
            db.AddInParameter(commProc, "@ChequeSequenceNumber", DbType.String, ChequeSec.Trim())
            db.AddInParameter(commProc, "@ItemAmount", DbType.Decimal, dItemAmt)
            db.AddInParameter(commProc, "@ReturnReason", DbType.String, RetReason.Trim())
            db.AddInParameter(commProc, "@SEQ_NUMBER", DbType.String, SeqNo.Trim())

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result <> 0 Then
                Return False
            End If

        Catch ex As Exception

            Return False


        End Try


        Return True


    End Function



    'Private Sub ImportReturn()


    '    lblToolStatus.Text = ""



    '    Try

    '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IRERet_Remove")

    '        commProc.Parameters.Clear()

    '        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

    '        Dim result As Integer

    '        db.ExecuteNonQuery(commProc)
    '        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
    '        If result <> 0 Then

    '            MessageBox.Show("Table Clear Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            Exit Sub

    '        End If


    '        Using reader As XmlTextReader = New XmlTextReader(txtFilename.Text)

    '            Dim ChequeSecNo As String = ""
    '            Dim ItemAmt As String = ""
    '            Dim RetReason As String = ""
    '            Dim FlagStart As Boolean = False

    '            Do While (reader.Read())
    '                If reader.NodeType = XmlNodeType.Element And reader.Name = "ChequeSequenceNumber" Then
    '                    FlagStart = True
    '                    reader.Read()
    '                    ChequeSecNo = reader.Value

    '                    'MessageBox.Show(reader.Value)
    '                End If

    '                If reader.NodeType = XmlNodeType.Element And reader.Name = "ItemAmount" Then
    '                    reader.Read()
    '                    ItemAmt = reader.Value
    '                    'MessageBox.Show(reader.Value)
    '                End If

    '                If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "ReturnReason" Then
    '                    FlagStart = False
    '                    reader.Read()
    '                    RetReason = reader.Value

    '                    If AddIRE(ChequeSecNo, ItemAmt, RetReason) = False Then
    '                        MessageBox.Show("XML to table Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        Exit Sub

    '                    End If

    '                    ChequeSecNo = ""
    '                    ItemAmt = ""
    '                    RetReason = ""
    '                    'MessageBox.Show(reader.Value)
    '                End If

    '            Loop

    '            reader.Close()

    '        End Using

    '        _ProcessSuccess = True


    '    Catch ex As Exception


    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)


    '    End Try


    'End Sub



    Private Sub ImportReturnFiles()


        lblToolStatus.Text = ""

        Dim intTotFile As Integer = 0
        Dim intFailed As Integer = 0

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IRERet_Remove")

            commProc.Parameters.Clear()

            db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

            Dim result As Integer

            db.ExecuteNonQuery(commProc)
            result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
            If result <> 0 Then

                MessageBox.Show("Table Clear Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Exit Sub

            End If

            _ToTRecordNo = 0
            intFailed = 0


            'Dim strFiles() = Directory.GetFiles(txtFolderPath.Text)
            'Dim i As Integer
            ''MessageBox.Show(strFiles.Count.ToString())
            'intTotFile = strFiles.Count()
            'For i = 0 To intTotFile - 1
            '    'MessageBox.Show(strFiles(i))
            '    If ReadXMLFile(strFiles(i)) = False Then
            '        txtFileImpStatus.AppendText(Environment.NewLine + "Failed: " + strFiles(i))
            '        intFailed = intFailed + 1
            '    End If
            'Next

            '-----------
            Dim fileNames = My.Computer.FileSystem.GetFiles(txtFolderPath.Text, _
                                                            FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
            intTotFile = fileNames.Count()

            For Each fileName As String In fileNames
                'filesListBox.Items.Add(fileName)
                If ReadXMLFile(fileName) = False Then
                    txtFileImpStatus.AppendText(Environment.NewLine + "Failed: " + fileName)
                    intFailed = intFailed + 1
                End If
            Next
            '-------

            _ProcessSuccess = True


        Catch ex As Exception


            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try

        lblFaileFileNo.Text = intFailed.ToString()
        lblTotRecNo.Text = _ToTRecordNo.ToString()
        lblTotFile.Text = intTotFile.ToString()


    End Sub

    Private Function ReadXMLFile(ByVal strFilename As String) As Boolean

        Dim retVal As Boolean = False

        Try

            Using reader As XmlTextReader = New XmlTextReader(strFilename)

                Dim RoutingNo As String = ""
                Dim ChequeSecNo As String = ""
                Dim ItemAmt As String = ""
                Dim RetReason As String = ""
                Dim SeqNo As String = ""
                Dim FlagStart As Boolean = False

                Do While (reader.Read())

                    If reader.NodeType = XmlNodeType.Element And reader.Name = "ReturnRecord" Then
                        FlagStart = True
                    End If

                    If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "PayorBankRoutingNumber" Then

                        reader.Read()
                        RoutingNo = reader.Value

                    End If

                    If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "ChequeSequenceNumber" Then
                        'FlagStart = True
                        reader.Read()
                        ChequeSecNo = reader.Value

                        'MessageBox.Show(reader.Value)
                    End If

                    If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "ItemAmount" Then
                        reader.Read()
                        ItemAmt = reader.Value
                        'MessageBox.Show(reader.Value)
                    End If

                    If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "ReturnReason" Then

                        reader.Read()
                        RetReason = reader.Value

                        'MessageBox.Show(reader.Value)
                    End If

                    If FlagStart = True And reader.NodeType = XmlNodeType.Element And reader.Name = "ECEInstitutionItemSequenceNumber" Then

                        reader.Read()
                        SeqNo = reader.Value

                        'MessageBox.Show(reader.Value)
                    End If

                    If reader.NodeType = XmlNodeType.EndElement And reader.Name = "ReturnRecord" Then
                        FlagStart = False

                        If AddIRE(RoutingNo, ChequeSecNo, ItemAmt, SeqNo, RetReason) = False Then
                            'MessageBox.Show("XML to table Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                            'Exit Function

                        End If

                        _ToTRecordNo = _ToTRecordNo + 1
                        ChequeSecNo = ""
                        ItemAmt = ""
                        RetReason = ""
                        SeqNo = ""
                        'MessageBox.Show(reader.Value)
                    End If


                Loop

                reader.Close()

                retVal = True

            End Using


        Catch ex As Exception


            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End Try

        Return retVal

    End Function


    Private Sub ProcIREtoReturn()

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)


            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IRERet_GetDetailList")

            commProc.Parameters.Clear()

            dt = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer = 0

            _TotMismatchRec = 0

            If dt.Rows.Count > 0 Then

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_ReturnClearing_Add")

                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_ReturnMismatchClear_Add")

                Dim result As Integer

                For i = 0 To dt.Rows.Count - 1

                    commProc2.Parameters.Clear()

                    db.AddInParameter(commProc2, "@CHECK_NUMBER", DbType.String, dt.Rows(i)("ChequeSequenceNumber"))
                    db.AddInParameter(commProc2, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dt.Rows(i)("ItemAmount")))
                    db.AddInParameter(commProc2, "@RTN_CODE", DbType.String, dt.Rows(i)("ReturnReason"))
                    db.AddInParameter(commProc2, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text))
                    db.AddInParameter(commProc2, "@SEQ_NUMBER", DbType.String, dt.Rows(i)("ECEInstitutionItemSequenceNumber"))
                    db.AddOutParameter(commProc2, "@RET_MID", DbType.Int32, 10)
                    db.AddOutParameter(commProc2, "@RET_DSL", DbType.Int32, 4)

                    db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc2)
                    result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

                    If result = 0 Then

                        'Debug.Print(dt.Rows(i)("ChequeSequenceNumber")
                    Else
                        _TotMismatchRec = _TotMismatchRec + 1

                        commProc3.Parameters.Clear()

                        db.AddInParameter(commProc3, "@CHECK_NUMBER", DbType.String, dt.Rows(i)("ChequeSequenceNumber"))
                        db.AddInParameter(commProc3, "@AMOUNT", DbType.Decimal, NullHelper.ToDecNum(dt.Rows(i)("ItemAmount")))
                        db.AddInParameter(commProc3, "@RTN_CODE", DbType.String, dt.Rows(i)("ReturnReason"))
                        db.AddInParameter(commProc3, "@OPR_DATE", DbType.DateTime, NullHelper.StringToDate(txtClearingDate.Text))
                        db.AddInParameter(commProc3, "@SEQ_NUMBER", DbType.String, dt.Rows(i)("ECEInstitutionItemSequenceNumber"))
                        db.AddInParameter(commProc3, "@ROUTING_NO", DbType.String, dt.Rows(i)("PayorBankRoutingNumber"))

                        db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        db.ExecuteNonQuery(commProc3)

                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        lblTotalMismatch.Text = _TotMismatchRec.ToString()


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

        'ImportReturn()
        ImportReturnFiles()

        If _ProcessSuccess = True Then
            ProcIREtoReturn()

        End If

        'PDCTransfer()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Style = ProgressBarStyle.Continuous


        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)



        End If

        'txtClearingDate.ReadOnly = False

        'txtFilename.ReadOnly = False
        'btnBrowse.Enabled = True
        'btnProcess.Enabled = True


        txtClearingDate.ReadOnly = False
        txtFilename.ReadOnly = False
        txtFolderPath.ReadOnly = False
        btnSetFolder.Enabled = True
        btnBrowse.Enabled = True
        btnProcess.Enabled = True




    End Sub








    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        txtFileImpStatus.Clear()
        'If Not File.Exists(txtFilename.Text) Then
        '    MessageBox.Show("Select File", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    btnBrowse.Focus()
        '    Exit Sub
        'End If
        If txtClearingDate.Text.Trim() = "/  /" Then
            MessageBox.Show("Clearing date required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClearingDate.Focus()
            Exit Sub
        End If

        If Not Directory.Exists(fbdRetFile.SelectedPath) Or txtFolderPath.Text.Trim() = "" Then
            MessageBox.Show("Select Path", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnBrowse.Focus()
            Exit Sub
        End If

        txtClearingDate.ReadOnly = True
        txtFilename.ReadOnly = True
        txtFolderPath.ReadOnly = True
        btnSetFolder.Enabled = False
        btnBrowse.Enabled = False
        btnProcess.Enabled = False

        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()

    End Sub




    Private Sub FrmPDCTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load





    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        opdRetFile.Multiselect = False
        'opdRetFile.Filter() = "XML Files (*.XML)|(*.XML)"
        opdRetFile.FileName = txtFilename.Text

        opdRetFile.ShowDialog()
        txtFilename.Text = opdRetFile.FileName()




    End Sub

    Private Sub btnSetFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFolder.Click
        'opdRetFile.Multiselect = False
        ''opdRetFile.Filter() = "XML Files (*.XML)|(*.XML)"
        'opdRetFile.FileName = txtFilename.Text

        'opdRetFile.ShowDialog()
        'txtFilename.Text = opdRetFile.FileName()
        fbdRetFile.ShowNewFolderButton = False
        fbdRetFile.ShowDialog()
        txtFolderPath.Text = fbdRetFile.SelectedPath
        



    End Sub

    Private Sub txtClearingDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClearingDate.Validating
        If CommonUtil.DateValidate(txtClearingDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnClearMismatchData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMismatchData.Click
        If MessageBox.Show("Do you want to clear all mismatch records", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)


                Dim commProcRem As DbCommand = db.GetStoredProcCommand("CMS_ReturnMismatchClear_Remove")
                db.AddParameter(commProcRem, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                db.ExecuteNonQuery(commProcRem)

                Dim result As Integer

                result = db.GetParameterValue(commProcRem, "@PROC_RET_VAL")

                If result = 0 Then
                    MessageBox.Show("Cleared mismatch records", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to clear mismatch records", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnReportMismatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportMismatch.Click

        Dim rd As New crClearReturnMismatch()

        Dim frmRptViewer As New FrmReportViewer()

        frmRptViewer.SetReport(rd)

        frmRptViewer.Show()

    End Sub
End Class