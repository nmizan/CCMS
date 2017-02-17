'
' Import Same Day MIS Data
' Author: Md. Fahad Khan
' Since: 29-Oct-14
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic
Imports System.Xml

Imports Microsoft.Office.Interop


Public Class FrmImportSameDayMis

#Region "Global Variables"

    Dim _formName As String = "DepositSameDayMisUpload"
    Dim opt As SecForm = New SecForm(_formName)

    Dim log_message As String = ""

    Dim flagRequireField As Boolean = False


    Dim flagWarning As Boolean = False
    Dim _debugRow As Integer = 0
    Dim _ToTRecordNo As Integer = 0

    Dim MakerImport As Boolean = False
    Dim ChakerImport As Boolean = False


    Public Delegate Sub ChangeTextOfLabelDelegate( _
                           ByVal ToLabel As Label, _
                           ByVal AddText As String)


    'Private Sub EnableAuth()
    '    If opt.IsAuth = True Then
    '        btnAuthorizer.Enabled = True
    '    Else
    '        DisableAuth()
    '    End If
    'End Sub

    'Private Sub DisableAuth()
    '    btnAuthorizer.Enabled = False
    'End Sub

#End Region

    Private Sub FrmImportSameDayMis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If


        If opt.IsAuth = True Then
            btnAuthorizer.Enabled = True
        Else
            btnAuthorizer.Enabled = False
        End If






    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub ReadExcel()
        Dim xlApp As New Excel.Application

        Try

            Dim wb As Excel.Workbook = xlApp.Workbooks.Open(opdRetFile.FileName)

            Dim sheet As Excel.Worksheet = wb.Sheets(1)

            Dim xlRange As Excel.Range = sheet.UsedRange

            Dim rowCount As Integer = xlRange.Rows.Count
            Dim colCount As Integer = xlRange.Columns.Count

            dgView.Rows.Clear()
            dgView.AllowUserToAddRows = True

          
            flagRequireField = False



            Dim i As Integer
            _ToTRecordNo = 0
            For i = 2 To rowCount

                If sheet.Range("B" & i.ToString()).Value Is Nothing Then
                    Exit For
                End If

                If sheet.Range("C" & i.ToString()).Value2.ToString() = "" Then
                    Exit For
                End If

                If sheet.Range("D" & i.ToString()).Value2.ToString() = "" Then
                    Exit For
                End If

                If sheet.Range("H" & i.ToString()).Value2.ToString() = "" Then
                    Exit For
                End If

                If sheet.Range("I" & i.ToString()).Value2.ToString() = "" Then
                    Exit For
                End If


                If (i = dgView.Rows.Count + 1) Then
                    dgView.Rows.Add()
                End If



                dgView.Item(0, i - 2).Value = sheet.Range("A" & i.ToString()).Value2  ' Accno
                dgView.Item(1, i - 2).Value = sheet.Range("B" & i.ToString()).Value  ' date

                If dgView.Item(1, 0).Value <> dgView.Item(1, i - 2).Value Then
                    MessageBox.Show("Date Not Same : " + sheet.Range("B" & i.ToString()).Value, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For
                End If


                dgView.Item(2, i - 2).Value = sheet.Range("C" & i.ToString()).Value2  ' slip no
                dgView.Item(3, i - 2).Value = sheet.Range("D" & i.ToString()).Value2  ' instrument
                dgView.Item(4, i - 2).Value = sheet.Range("E" & i.ToString()).Value2  ' instrument no
                dgView.Item(5, i - 2).Value = sheet.Range("F" & i.ToString()).Value2  ' issuing bank
                dgView.Item(6, i - 2).Value = sheet.Range("G" & i.ToString()).Value2  ' Location
                dgView.Item(7, i - 2).Value = sheet.Range("H" & i.ToString()).Value2  ' Amount
                dgView.Item(8, i - 2).Value = sheet.Range("I" & i.ToString()).Value2  ' client

                If MakerImport = True And ChakerImport = False Then
                    dgView.Item(9, i - 2).Value = CommonAppSet.User
                End If

                If ChakerImport = True And MakerImport = False Then

                    dgView.Item(10, i - 2).Value = CommonAppSet.User
                End If




                _ToTRecordNo = _ToTRecordNo + 1
                SetLabelText(lblTotRecNo, _ToTRecordNo.ToString())



            Next
            dgView.AllowUserToAddRows = False









            wb.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Try
            xlApp.Quit()
        Catch ex As Exception

        End Try




    End Sub


    Private Sub CheckValidation()


        Dim tmpAccount As String = ""
        Dim strErrMsg As String = ""

        Dim dtAccountInfo As DataTable

        Dim strSql = ""



        Try



            For Each row As DataGridViewRow In dgView.Rows

                strErrMsg = ""
                flagRequireField = False



                If NullHelper.ObjectToString(row.Cells(8).Value).Trim() <> "" Then ' Accno NO


                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Using conn As DbConnection = db.CreateConnection()

                        conn.Open()

                        Dim commProc As DbCommand

                        ' strSql = "SELECT CLIENT_CODE FROM CLIENT WHERE ACC_NO='" & NullHelper.ObjectToString(row.Cells(0).Value).Trim() & "' AND STATUS='L' "


                        strSql = "SELECT ACC_NO FROM CLIENT WHERE  CLIENT_CODE='" & NullHelper.ObjectToString(row.Cells(8).Value).Trim() & "' AND STATUS='L' "

                        commProc = db.GetSqlStringCommand(strSql)

                        commProc.Parameters.Clear()

                        dtAccountInfo = db.ExecuteDataSet(commProc).Tables(0)

                        If dtAccountInfo.Rows.Count > 0 Then

                            row.Cells(0).Value = dtAccountInfo.Rows(0)("ACC_NO")

                        Else


                            flagRequireField = True
                            strErrMsg = strErrMsg + " | Account no : " + NullHelper.ObjectToString(row.Cells(8).Value).Trim() + " Not Found " + """"


                        End If


                        conn.Close()

                    End Using


                End If




               


                If row.Cells(1).Value.ToString = "" Then ' Date

                    flagRequireField = True

                    strErrMsg = strErrMsg + " | Transaction Date Missing " + """"


                End If

                If NullHelper.ObjectToString(row.Cells(2).Value).Trim() = "" Then ' Slip NO

                    flagRequireField = True
                    strErrMsg = strErrMsg + " | Slip No Missing " + """"

                End If

                If NullHelper.ObjectToString(row.Cells(2).Value).Trim() <> "" And Len(NullHelper.ObjectToString(row.Cells(2).Value).Trim()) > 12 Then ' Slip NO

                    flagRequireField = True
                    strErrMsg = strErrMsg + " | Slip No Length is greater than system slip no " + """"

                End If


                If NullHelper.ObjectToString(row.Cells(3).Value).Trim() = "" Then ' Instrument Type

                    flagRequireField = True

                    strErrMsg = strErrMsg + " | Instrument Type Missing " + """"

                End If

                If NullHelper.ObjectToString(row.Cells(3).Value).Trim() <> "" Then ' Instrument Type

                    If NullHelper.ObjectToString(row.Cells(3).Value).ToUpper() <> "CASH" And NullHelper.ObjectToString(row.Cells(3).Value).ToUpper() <> "CHECK" Then


                        flagRequireField = True

                        strErrMsg = strErrMsg + " | Instrument Type Mismatched it should be Cash or Check " + """"

                    End If

                End If


                If NullHelper.ObjectToString(row.Cells(3).Value).ToUpper() = "CHECK" Then

                    If NullHelper.ObjectToString(row.Cells(4).Value).Trim() = "" Then ' Instrument No

                        flagRequireField = True

                        strErrMsg = strErrMsg + " | Instrument No Missing " + """"

                    End If

                    If NullHelper.ObjectToString(row.Cells(4).Value).Trim() <> "" And Len(NullHelper.ObjectToString(row.Cells(4).Value).Trim()) > 12 Then ' Instrument No

                        flagRequireField = True

                        strErrMsg = strErrMsg + " | Instrument No Length is greater than system " + """"

                    End If






                End If




                If NullHelper.ObjectToString(row.Cells(7).Value).Trim() = "" Then ' Amount

                    flagRequireField = True

                    strErrMsg = strErrMsg + " | Amount Missing " + """"


                End If


                If flagRequireField = True Then
                    strErrMsg = strErrMsg & "| Require Field Missing |"
                End If

                If flagWarning = True Then

                    row.Cells(12).Value = strErrMsg
                    'row.DefaultCellStyle.BackColor = Color.Yellow
                End If


                If flagRequireField = True Then

                    row.Cells(11).Value = 1
                    row.DefaultCellStyle.BackColor = Color.Red
                    row.Cells(12).Value = strErrMsg
                    btnSave.Enabled = False

                End If




            Next

            ' lblTotalCheckAmount.Text = CheckTotal.ToString()
            ' lblTotalCheckNo.Text = CheckNoTotal.ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function CheckValidData() As Boolean


        Return True

    End Function

    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0
        Dim intMod As Integer = 0
        Dim _intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Using conn As DbConnection = db.CreateConnection()

            conn.Open()

            Dim trans As DbTransaction = conn.BeginTransaction()

            Dim strSql = ""

            'For i = 0 To dgView.Rows.Count

            '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_Delete")

            '    commProc.Parameters.Clear()

            '    db.AddInParameter(commProc, "@TRANSACTION_DATE", DbType.Date, dgView.Rows(i).Cells(1).Value)

            '    db.ExecuteNonQuery(commProc, trans)


            'Next

            For i = 0 To dgView.Rows.Count - 1

                _debugRow = i + 1

                If i = 0 Then


                    Dim commProcc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_Delete")

                    commProcc.Parameters.Clear()

                    db.AddInParameter(commProcc, "@TRANSACTION_DATE", DbType.Date, dgView.Rows(i).Cells(1).Value)

                    db.ExecuteNonQuery(commProcc, trans)

                End If


                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_Add")

                commProc.Parameters.Clear()


                db.AddInParameter(commProc, "@AC_NO", DbType.String, dgView.Rows(i).Cells(0).Value)
                db.AddInParameter(commProc, "@TRANSACTION_DATE", DbType.DateTime, dgView.Rows(i).Cells(1).Value)

                db.AddInParameter(commProc, "@SLIP_NO", DbType.String, dgView.Rows(i).Cells(2).Value)
                db.AddInParameter(commProc, "@INSTRUMENT_TYPE", DbType.String, dgView.Rows(i).Cells(3).Value)

                db.AddInParameter(commProc, "@INSTRUMENT_NO", DbType.String, dgView.Rows(i).Cells(4).Value)
                db.AddInParameter(commProc, "@ISSUE_BANK", DbType.String, dgView.Rows(i).Cells(5).Value)
                db.AddInParameter(commProc, "@LOCATION", DbType.String, dgView.Rows(i).Cells(6).Value)

                db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, dgView.Rows(i).Cells(7).Value)
                db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, dgView.Rows(i).Cells(8).Value)
                db.AddInParameter(commProc, "@INPUT_BY", DbType.String, CommonAppSet.User)


                db.ExecuteNonQuery(commProc, trans)



            Next


            tStatus = TransState.Add


            log_message = " Uploaded : Same Day MIS Data "
            Logger.system_log(log_message)

            trans.Commit()


        End Using

        Return tStatus

    End Function



    Private Function AuthData() As TransState

        Dim tStatus As TransState

        'Dim intModno As Integer = 0
        'Dim intMod As Integer = 0
        'Dim _intModno As Integer = 0

        Dim dt As New DataTable

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Using conn As DbConnection = db.CreateConnection()

            conn.Open()

            Dim trans As DbTransaction = conn.BeginTransaction()

            Dim strSql = ""

            For i = 0 To dgView.Rows.Count - 1



                If i = 0 Then


                    Dim ds As New DataSet
                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_GET_User")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@TRANSACTION_DATE", DbType.Date, dgView.Rows(i).Cells(1).Value)

                    ds = db.ExecuteDataSet(commProc, trans)

                    If ds.Tables(0).Rows.Count > 0 Then

                        If ds.Tables(0).Rows(0)("INPUT_BY").ToString().ToUpper() = CommonAppSet.User.Trim().ToUpper() Then
                            Return TransState.MakerCheckerSame
                            'Exit Function

                        End If

                    Else

                        Return TransState.NoRecord
                    End If



                    commProc = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_Count")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@TRANSACTION_DATE", DbType.Date, dgView.Rows(i).Cells(1).Value)

                    ds = db.ExecuteDataSet(commProc, trans)

                    If ds.Tables(0).Rows.Count > 0 Then


                        If ds.Tables(0).Rows(0)("SLNO").ToString() <> dgView.Rows.Count Then
                            Return TransState.ParentNotExist
                            'Exit Function

                        End If

                    Else

                        Return TransState.NoRecord
                    End If

                End If

                ' Compare Record



                Dim commProcc As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_GET_Details")

                commProcc.Parameters.Clear()

                db.AddInParameter(commProcc, "@TRANSACTION_DATE", DbType.DateTime, dgView.Rows(i).Cells(1).Value)
               
                dt = db.ExecuteDataSet(commProcc, trans).Tables(0)

                If dt.Rows.Count > 0 Then

                    If dt.Rows(i)("AC_NO") <> dgView.Rows(i).Cells(0).Value Then

                        Return TransState.UpdateNotPossible
                    End If

                    If dt.Rows(i)("TRANSACTION_DATE") <> dgView.Rows(i).Cells(1).Value Then

                        Return TransState.UpdateNotPossible
                    End If


                    If dt.Rows(i)("SLIP_NO") <> dgView.Rows(i).Cells(2).Value Then

                        Return TransState.UpdateNotPossible
                    End If

                    If dt.Rows(i)("INSTRUMENT_TYPE") <> dgView.Rows(i).Cells(3).Value Then

                        Return TransState.UpdateNotPossible
                    End If

                    If NullHelper.ObjectToString(dt.Rows(i)("INSTRUMENT_NO")) <> NullHelper.ObjectToString(dgView.Rows(i).Cells(4).Value) Then

                        Return TransState.UpdateNotPossible
                    End If


                    If NullHelper.ObjectToString(dt.Rows(i)("ISSUE_BANK")) <> NullHelper.ObjectToString(dgView.Rows(i).Cells(5).Value) Then

                        Return TransState.UpdateNotPossible
                    End If


                    If NullHelper.ObjectToString(dt.Rows(i)("LOCATION")) <> NullHelper.ObjectToString(dgView.Rows(i).Cells(6).Value) Then

                        Return TransState.UpdateNotPossible
                    End If


                    If dt.Rows(i)("AMOUNT") <> dgView.Rows(i).Cells(7).Value Then

                        Return TransState.UpdateNotPossible
                    End If

                    If dt.Rows(i)("CLIENT_CODE") <> dgView.Rows(i).Cells(8).Value Then

                        Return TransState.UpdateNotPossible
                    End If

                End If



                ' Add data to SameDayMis table

                Dim commProcM As DbCommand = db.GetStoredProcCommand("CMS_IMP_SameDayMisM_To_SameDayMis_Add")

                commProcM.Parameters.Clear()

                db.AddInParameter(commProcM, "@TRANSACTION_DATE", DbType.DateTime, dgView.Rows(i).Cells(1).Value)
                db.AddInParameter(commProcM, "@SLIP_NO", DbType.String, dgView.Rows(i).Cells(2).Value)
                db.AddInParameter(commProcM, "@INPUT_BY", DbType.String, CommonAppSet.User)


                db.ExecuteNonQuery(commProcM, trans)



            Next


            tStatus = TransState.Update

            log_message = " Authorized : Same Day MIS Data  "
            Logger.system_log(log_message)


            trans.Commit()


        End Using

        Return tStatus

    End Function

    Private Sub SetLabelText(ByVal lblName As System.Windows.Forms.Label, ByVal strMsg As String)


        If lblName.InvokeRequired Then
            lblName.Invoke(New ChangeTextOfLabelDelegate(AddressOf SetLabelText), New Object() {lblName, strMsg})
        Else
            lblName.Text = strMsg
        End If

    End Sub

    
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        opdRetFile.Multiselect = False
        'opdRetFile.Filter() = "XML Files (*.XML)|(*.XML)"
        opdRetFile.FileName = txtFileName.Text

        opdRetFile.ShowDialog()
        txtFileName.Text = opdRetFile.FileName()
    End Sub

    Private Sub btnMakerImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakerImport.Click
        If Not File.Exists(txtFileName.Text) Then
            MessageBox.Show("Select File", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnBrowse.Focus()
            Exit Sub
        End If

        MakerImport = True
        ChakerImport = False
        ReadExcel()
        CheckValidation()



    End Sub

    Private Sub btnAuthorizer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorizer.Click


        If Not File.Exists(txtFileName.Text) Then
            MessageBox.Show("Select File", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnBrowse.Focus()
            Exit Sub
        End If

        MakerImport = False
        ChakerImport = True
        ReadExcel()
        CheckValidation()


    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try

            If MakerImport = True And ChakerImport = False Then

            
                If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If CheckValidData() Then

                        tState = SaveData()

                        If tState = TransState.Add Then

                            lblToolStatus.Text = "!! Information Updated Successfully !!"

                            MessageBox.Show("Information Updated Successfull.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf tState = TransState.Exist Then
                            lblToolStatus.Text = "!! Already Exist !!"
                        ElseIf tState = TransState.NoRecord Then
                            lblToolStatus.Text = "!! Nothing to Update !!"
                        ElseIf tState = TransState.DBError Then
                            lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                        ElseIf tState = TransState.UnspecifiedError Then
                            lblToolStatus.Text = "!! Unpecified Error Occured !!"
                        End If

                    End If

                End If

            End If

            If ChakerImport = True And MakerImport = False Then


                If MessageBox.Show("Do you really want to Authorized ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If CheckValidData() Then

                        tState = AuthData()

                        If tState = TransState.Update Then

                            lblToolStatus.Text = "!! Information Authorized Successfully !!"

                            MessageBox.Show("Information Authorized Successfull.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ElseIf tState = TransState.MakerCheckerSame Then
                            lblToolStatus.Text = "!! Maker Can't verify Data !!"
                            MessageBox.Show(" Maker Can't Verify Data .", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf tState = TransState.UpdateNotPossible Then
                            lblToolStatus.Text = "!! Record Mismatch !!"

                        ElseIf tState = TransState.NoRecord Then
                            lblToolStatus.Text = "!! Nothing to Authorized !!"
                        ElseIf tState = TransState.ParentNotExist Then
                            lblToolStatus.Text = "!! Number of record Mismatch !!"
                        ElseIf tState = TransState.UnspecifiedError Then
                            lblToolStatus.Text = "!! Unpecified Error Occured !!"
                        End If

                    End If

                End If


            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message + Environment.NewLine + "Error Row: " + _debugRow.ToString(), "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class