' 
' Collection Normal Collection
' Author: Md. fahad Khan
' Since: 09-Mar-2013   
'
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmCitiAnyReturnDet

#Region "Global Variables"

    Dim _formName As String = "CollectionCitiAnywhereReturnDetail"
    Dim opt As SecForm = New SecForm(_formName)

    'Dim intModno As Integer
    Dim _formMode As FormTransMode
    'Dim strCheckNo As String = ""
    'Dim _strCheckNo As String = ""
    Dim _strRefNo As String = ""
    Dim _intModno As Integer = 0
    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim log_message As String = ""

#End Region

#Region "User defined Codes"


    Private Sub EnableUnlock()
        If opt.IsUnlock = True Then
            btnUnlock.Enabled = True
        Else
            DisableUnlock()
        End If
    End Sub

    Private Sub DisableUnlock()
        btnUnlock.Enabled = False
    End Sub

    Private Sub EnableNew()
        If opt.IsNew = True Then
            btnNew.Enabled = True
        Else
            DisableNew()
        End If
    End Sub

    Private Sub DisableNew()
        btnNew.Enabled = False
    End Sub

    Private Sub EnableSave()
        If opt.IsSave = True Then
            btnSave.Enabled = True
        Else
            DisableSave()
        End If
    End Sub

    Private Sub DisableSave()
        btnSave.Enabled = False
    End Sub

    Private Sub EnableDelete()
        If opt.IsDelete = True Then
            btnDelete.Enabled = True
        Else
            DisableDelete()
        End If
    End Sub

    Private Sub DisableDelete()
        btnDelete.Enabled = False
    End Sub

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









    Private Sub DisableFields()
        txtCheckNo.ReadOnly = True
        txtRefNo.ReadOnly = True
        txtReturnCode.ReadOnly = True


    End Sub

    Private Sub EnableFields()
        txtCheckNo.ReadOnly = False
        txtRefNo.ReadOnly = False
        'txtReturnCode.ReadOnly = False


    End Sub
    Private Sub ClearFieldsAll()

        _intModno = 0
        _strRefNo = ""


        txtCheckNo.Clear()
        txtRefNo.Clear()
        txtReturnCode.Clear()
        lblAccount.Text = ""
        lblAmount.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""
        lblCheckNo.Text = ""
        lblCheckRef.Text = ""
        lblClientCode.Text = ""
        lblClientName.Text = ""
        lblDepoCode.Text = ""
        lblSlno.Text = ""
        lblDraBankCode.Text = ""
        lblDraBankName.Text = ""
        lblDraBranchCode.Text = ""
        lblDraBranchName.Text = ""
        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblStatus.Text = ""
        lblModNo.Text = ""
        lblVerNo.Text = ""
        lblVerTot.Text = ""
        lblReason.Text = ""
        lblStatusDate.Text = ""
        lblDepoCode.Text = ""
        lblReason.Text = ""







    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        'DisableUnlock()

        'lblToolStatus.Text = ""


        'EnableNew()

        'If btnNew.Enabled = True Then
        '    btnNew.Focus()
        'End If

        '''''''''''''''''''''''''


        lblToolStatus.Text = ""

        EnableNew()
        If Not (_strRefNo = "") Then

            If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then
                EnableFields()

                'EnableClear()
                EnableDelete()
                EnableNew()
                'EnableRefresh()
                EnableSave()

            Else
                DisableAuth()
                'DisableClear()
                DisableDelete()
                'DisableRefresh()
                DisableSave()

                DisableFields()
            End If

            If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim.ToUpper() = CommonAppSet.User.ToUpper()) Then
                EnableAuth()
            Else
                DisableAuth()
            End If

        Else

            DisableFields()

        End If

        DisableUnlock()

        If btnNew.Enabled = True Then
            btnNew.Focus()
        End If


    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'EnableSave()

        ClearFieldsAll()
        EnableFields()

        DisableDelete()

        txtReturnCode.ReadOnly = True
        btnUpdateStatus.Enabled = False

        Dim regDate As Date = Date.Now()

        lblDate.Text = regDate.ToString("dd/MM/yyyy")

        If txtRefNo.Enabled = True Then
            txtRefNo.Focus()
        End If

    End Sub


    Private Sub LoadCheckDataByCheckNo(ByVal strCheckNo As String)

        Try


            Dim frmList As New FrmList()
            frmList.Text = "CitiAnywhere Check List"
            frmList.ProcName = "CMS_CCheck_GetDetailByCheckNo"
            frmList.AddParamToDB("@CHECK_NO", DbType.String, strCheckNo.Trim())
            frmList.filter = New String(,) {{"ACC_NAME", "Account Name"}, {"ACC_NO", "Account No"}}
            frmList.colwidth = New Integer(,) {{1, 300}}
            'frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
            frmList.ShowDialog()

            If (frmList.RowResult.Cells.Count > 0) Then

                'txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                'lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()


                _strRefNo = frmList.RowResult.Cells(17).Value.ToString() 'dt.Rows(0)("NONZONE_REF").ToString()

                lblDepoCode.Text = frmList.RowResult.Cells(1).Value.ToString() 'dt.Rows(0)("D_CODE")
                lblSlno.Text = frmList.RowResult.Cells(0).Value.ToString() 'dt.Rows(0)("SLNO")
                txtRefNo.Text = frmList.RowResult.Cells(17).Value.ToString() 'dt.Rows(0)("NONZONE_REF")
                lblCheckNo.Text = frmList.RowResult.Cells(7).Value.ToString() 'dt.Rows(0)("CHECK_NO")
                lblCheckRef.Text = frmList.RowResult.Cells(15).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("CHECK_REF"))
                lblAmount.Text = frmList.RowResult.Cells(8).Value.ToString() 'dt.Rows(0)("AMOUNT")
                lblDraBankCode.Text = frmList.RowResult.Cells(12).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("DRAWEE_BANK_CODE"))
                lblDraBankName.Text = frmList.RowResult.Cells(27).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("BANK_NAME"))

                lblDrawerAc.Text = frmList.RowResult.Cells(11).Value.ToString()
                ' lblDrawerAc.Text = NullHelper.ObjectToString(dt.Rows(0)("DRAWER"))

                lblDraBranchCode.Text = frmList.RowResult.Cells(14).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("BRANCH_CODE"))
                lblDraBranchName.Text = frmList.RowResult.Cells(28).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("BRANCH_NAME"))

                lblClientCode.Text = frmList.RowResult.Cells(2).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("CLIENT_CODE"))
                lblClientName.Text = frmList.RowResult.Cells(25).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("ACC_NAME"))
                lblAccount.Text = frmList.RowResult.Cells(26).Value.ToString() 'NullHelper.ObjectToString(dt.Rows(0)("ACC_NO"))


            End If

            frmList.Dispose()





            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            'Dim dt As New DataTable

            'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetDetailByCheckNo")

            'commProc.Parameters.Clear()

            'db.AddInParameter(commProc, "@CHECK_NO", DbType.String, strCheckNo.Trim())

            'dt = db.ExecuteDataSet(commProc).Tables(0)
            'If dt.Rows.Count > 0 Then

            '    '_txtCheckNo = txtCheckNo
            '    '_intModno = intModno
            '    _strRefNo = dt.Rows(0)("NONZONE_REF").ToString()

            '    lblDepoCode.Text = dt.Rows(0)("D_CODE")
            '    lblSlno.Text = dt.Rows(0)("SLNO")
            '    txtRefNo.Text = dt.Rows(0)("NONZONE_REF")
            '    lblCheckNo.Text = dt.Rows(0)("CHECK_NO")
            '    lblCheckRef.Text = NullHelper.ObjectToString(dt.Rows(0)("CHECK_REF"))
            '    lblAmount.Text = dt.Rows(0)("AMOUNT")
            '    lblDraBankCode.Text = NullHelper.ObjectToString(dt.Rows(0)("DRAWEE_BANK_CODE"))
            '    lblDraBankName.Text = NullHelper.ObjectToString(dt.Rows(0)("BANK_NAME"))
            '    'lblStatusDate.Text = dt.Rows(0)("REF_DATE")
            '    lblDraBranchCode.Text = NullHelper.ObjectToString(dt.Rows(0)("BRANCH_CODE"))
            '    lblDraBranchName.Text = NullHelper.ObjectToString(dt.Rows(0)("BRANCH_NAME"))
            '    'lblModNo.Text = dt.Rows(0)("MOD_NO")
            '    lblClientCode.Text = NullHelper.ObjectToString(dt.Rows(0)("CLIENT_CODE"))
            '    LblClientName.Text = NullHelper.ObjectToString(dt.Rows(0)("ACC_NAME"))
            '    lblAccount.Text = NullHelper.ObjectToString(dt.Rows(0)("ACC_NO"))
            '    'lblVerNo.Text = dt.Rows(0)("MOD_NO")
            '    'lblInputBy.Text = dt.Rows(0)("INPUT_BY")
            '    'lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME")
            '    'lblAuthBy.Text = dt.Rows(0)("AUTH_BY")
            '    'lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME")
            '    'lblVerTot.Text = dt.Rows(0)("MOD_NO")
            '    'intModno = dt.Rows(0)("MOD_NO")

            '    'If dt.Rows(0)("RTN_STATUS") = "O" Then
            '    '    lblStatus.Text = "OutStanding"
            '    'End If
            '    'If dt.Rows(0)("RTN_STATUS") = "P" Then
            '    '    lblStatus.Text = "DD Paid"
            '    'End If
            '    'If dt.Rows(0)("RTN_STATUS") = "D" Then
            '    '    lblStatus.Text = "DD Outstanding"
            '    'End If
            '    'If dt.Rows(0)("RTN_STATUS") = "T" Then
            '    '    lblStatus.Text = "DD Return"
            '    'End If
            '    'If dt.Rows(0)("RTN_STATUS") = "R" Then
            '    '    lblStatus.Text = "Returned"
            '    'End If

            '    'lblStatus.Text = dt.Rows(0)("RTN_STATUS")
            'Else
            '    MessageBox.Show("Invalid check no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub LoadCheckDataByRefNo(ByVal strRefNo As String)

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetDetailByRefNo")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, strRefNo.Trim())

            dt = db.ExecuteDataSet(commProc).Tables(0)
            If dt.Rows.Count > 0 Then

                '_txtCheckNo = txtCheckNo
                '_intModno = intModno
                _strRefNo = dt.Rows(0)("NONZONE_REF").ToString()

                lblDepoCode.Text = dt.Rows(0)("D_CODE")
                lblSlno.Text = dt.Rows(0)("SLNO")
                txtRefNo.Text = dt.Rows(0)("NONZONE_REF")
                txtCheckNo.Text = dt.Rows(0)("CHECK_NO")
                lblCheckNo.Text = dt.Rows(0)("CHECK_NO")

                lblDrawerAc.Text = NullHelper.ObjectToString(dt.Rows(0)("DRAWER"))

                lblCheckRef.Text = NullHelper.ObjectToString(dt.Rows(0)("CHECK_REF"))
                lblAmount.Text = dt.Rows(0)("AMOUNT")
                lblDraBankCode.Text = NullHelper.ObjectToString(dt.Rows(0)("DRAWEE_BANK_CODE"))
                lblDraBankName.Text = NullHelper.ObjectToString(dt.Rows(0)("BANK_NAME"))
                'lblStatusDate.Text = dt.Rows(0)("REF_DATE")
                lblDraBranchCode.Text = NullHelper.ObjectToString(dt.Rows(0)("BRANCH_CODE"))
                lblDraBranchName.Text = NullHelper.ObjectToString(dt.Rows(0)("BRANCH_NAME"))
                'lblModNo.Text = dt.Rows(0)("MOD_NO")
                lblClientCode.Text = NullHelper.ObjectToString(dt.Rows(0)("CLIENT_CODE"))
                lblClientName.Text = NullHelper.ObjectToString(dt.Rows(0)("ACC_NAME"))
                lblAccount.Text = NullHelper.ObjectToString(dt.Rows(0)("ACC_NO"))
                'lblVerNo.Text = dt.Rows(0)("MOD_NO")
                'lblInputBy.Text = dt.Rows(0)("INPUT_BY")
                'lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME")
                'lblAuthBy.Text = dt.Rows(0)("AUTH_BY")
                'lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME")
                'lblVerTot.Text = dt.Rows(0)("MOD_NO")
                'intModno = dt.Rows(0)("MOD_NO")

                'If dt.Rows(0)("RTN_STATUS") = "O" Then
                '    lblStatus.Text = "OutStanding"
                'End If
                'If dt.Rows(0)("RTN_STATUS") = "P" Then
                '    lblStatus.Text = "DD Paid"
                'End If
                'If dt.Rows(0)("RTN_STATUS") = "D" Then
                '    lblStatus.Text = "DD Outstanding"
                'End If
                'If dt.Rows(0)("RTN_STATUS") = "T" Then
                '    lblStatus.Text = "DD Return"
                'End If
                'If dt.Rows(0)("RTN_STATUS") = "R" Then
                '    lblStatus.Text = "Returned"
                'End If

                'lblStatus.Text = dt.Rows(0)("RTN_STATUS")
            Else
                MessageBox.Show("Invalid reference no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub LoadCollectionData(ByVal strRefNo As String)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetMaxMod")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, strRefNo)

            Dim intModNo As Integer = db.ExecuteDataSet(commProc).Tables(0).Rows(0)(0).ToString()

            If intModNo > 0 Then
                LoadMainData(strRefNo, intModNo)

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadMainData(ByVal strRefNo As String, ByVal intMod As Integer)

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetDetail")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, strRefNo)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intMod)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                _strRefNo = strRefNo
                _intModno = intMod

                _formMode = FormTransMode.Update

                txtRefNo.Text = ds.Tables(0).Rows(0)("NONZONE_REF").ToString()

                Dim rtnStatus As String = ds.Tables(0).Rows(0)("RTN_STATUS").ToString()

                If rtnStatus = "O" Then
                    lblStatus.Text = "Outstanding"
                ElseIf rtnStatus = "R" Then
                    lblStatus.Text = "Returned"
                ElseIf rtnStatus = "D" Then
                    lblStatus.Text = "DD Outstanding"
                ElseIf rtnStatus = "T" Then
                    lblStatus.Text = "DD Returned"
                ElseIf rtnStatus = "P" Then
                    lblStatus.Text = "DD Paid"
                End If
                'lblStatus.Text = ds.Tables(0).Rows(0)("RTN_STATUS").ToString()

                lblStatusDate.Text = NullHelper.DateToString(ds.Tables(0).Rows(0)("INPUT_DATETIME"))

                txtReturnCode.Text = NullHelper.ObjectToString(ds.Tables(0).Rows(0)("RTN_CODE"))
                lblReason.Text = NullHelper.ObjectToString(ds.Tables(0).Rows(0)("REJECT_REASON"))

                lblInputBy.Text = ds.Tables(0).Rows(0)("INPUT_BY").ToString()
                lblInputDate.Text = ds.Tables(0).Rows(0)("INPUT_DATETIME").ToString()

                _mod_datetime = ds.Tables(0).Rows(0)("INPUT_DATETIME")

                lblAuthBy.Text = ds.Tables(0).Rows(0)("AUTH_BY").ToString()
                lblAuthDate.Text = ds.Tables(0).Rows(0)("AUTH_DATETIME").ToString()

                chkAuthorized.Checked = ds.Tables(0).Rows(0)("IS_AUTH")

                If ds.Tables(0).Rows(0)("STATUS") = "L" Or ds.Tables(0).Rows(0)("STATUS") = "U" Or ds.Tables(0).Rows(0)("STATUS") = "O" Then
                    chkOpen.Checked = True
                Else
                    chkOpen.Checked = False
                End If

                _status = ds.Tables(0).Rows(0)("STATUS")

                lblModNo.Text = ds.Tables(0).Rows(0)("MOD_NO").ToString()
                lblVerNo.Text = ds.Tables(0).Rows(0)("MOD_NO").ToString()

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@NONZONE_REF", DbType.String, strRefNo)

                lblVerTot.Text = db.ExecuteDataSet(commProc2).Tables(0).Rows(0)(0).ToString()




                If _status = "U" Then


                    If btnUnlock.Enabled = False Then
                        'EnableFields()

                        EnableDelete()
                        EnableNew()

                        'EnableSave()
                    Else

                    End If

                    DisableSave()

                    txtReturnCode.ReadOnly = True
                    btnUpdateStatus.Enabled = False

                Else

                    If lblStatus.Text.Substring(0, 1) = "O" Then
                        If btnUnlock.Enabled = False Then
                            EnableSave()
                            txtReturnCode.ReadOnly = False
                        Else
                            txtReturnCode.ReadOnly = True
                            DisableSave()
                        End If

                        btnUpdateStatus.Enabled = False

                    ElseIf lblStatus.Text.Substring(0, 1) <> "O" And chkAuthorized.Checked = True Then

                        If btnUnlock.Enabled = False Then
                            btnUpdateStatus.Enabled = True
                        End If

                        txtReturnCode.ReadOnly = True
                        DisableSave()

                    End If

                    'DisableFields()
                End If

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim().ToUpper() = CommonAppSet.User.ToUpper()) Then
                    EnableAuth()
                Else
                    DisableAuth()
                End If


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    'Private Sub LoadMainData(ByVal txtCheckNo As String)

    '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '    Dim dt As New DataTable

    '    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetDetail")

    '    commProcSche.Parameters.Clear()

    '    db.AddInParameter(commProcSche, "@CHECK_NO", DbType.String, txtCheckNo)
    '    db.AddInParameter(commProcSche, "@MOD_NO", DbType.String, intModno)

    '    dt = db.ExecuteDataSet(commProcSche).Tables(0)
    '    If dt.Rows.Count > 0 Then

    '        '_txtCheckNo = txtCheckNo
    '        '_intModno = intModno

    '        lblDepoCode.Text = dt.Rows(0)("D_CODE")
    '        txtRefNo.Text = dt.Rows(0)("NONZONE_REF")
    '        lblCheckNo.Text = dt.Rows(0)("CHECK_NO")
    '        lblCheckRef.Text = dt.Rows(0)("CHECK_REF")
    '        lblAmount.Text = dt.Rows(0)("AMOUNT")
    '        lblDraBankCode.Text = dt.Rows(0)("DRAWEE_BANK_CODE")
    '        lblDraBankName.Text = dt.Rows(0)("BANK_NAME")
    '        lblStatusDate.Text = dt.Rows(0)("REF_DATE")
    '        lblDraBranchCode.Text = dt.Rows(0)("BRANCH_CODE")
    '        lblDraBranchName.Text = dt.Rows(0)("BRANCH_NAME")
    '        lblModNo.Text = dt.Rows(0)("MOD_NO")
    '        lblClientCode.Text = dt.Rows(0)("CLIENT_CODE")
    '        LblClientName.Text = dt.Rows(0)("ACC_NAME")
    '        lblAccount.Text = dt.Rows(0)("ACC_NO")
    '        lblVerNo.Text = dt.Rows(0)("MOD_NO")
    '        lblInputBy.Text = dt.Rows(0)("INPUT_BY")
    '        lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME")
    '        lblAuthBy.Text = dt.Rows(0)("AUTH_BY")
    '        lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME")
    '        lblVerTot.Text = dt.Rows(0)("MOD_NO")
    '        intModno = dt.Rows(0)("MOD_NO")

    '        If dt.Rows(0)("RTN_STATUS") = "O" Then
    '            lblStatus.Text = "OutStanding"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "P" Then
    '            lblStatus.Text = "DD Paid"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "D" Then
    '            lblStatus.Text = "DD Outstanding"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "T" Then
    '            lblStatus.Text = "DD Return"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "R" Then
    '            lblStatus.Text = "Returned"
    '        End If

    '        'lblStatus.Text = dt.Rows(0)("RTN_STATUS")

    '    End If


    'End Sub

    'Private Sub LoadFocusData(ByVal txtRefNo As String)

    '    If txtRefNo = "" Then
    '        Exit Sub
    '    End If
    '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '    Dim dt As New DataTable

    '    Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetMaxMod")

    '    commProc5.Parameters.Clear()

    '    db.AddInParameter(commProc5, "@NONZONE_REF", DbType.String, txtRefNo)

    '    Dim ckeckMod As Integer = db.ExecuteDataSet(commProc5).Tables(0).Rows(0)(0).ToString()


    '    Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_NCollection_GetDetailByNonZoneRef")

    '    commProcSche.Parameters.Clear()

    '    db.AddInParameter(commProcSche, "@NONZONE_REF", DbType.String, txtRefNo)
    '    db.AddInParameter(commProcSche, "@MOD_NO", DbType.String, ckeckMod)

    '    dt = db.ExecuteDataSet(commProcSche).Tables(0)
    '    If dt.Rows.Count > 0 Then

    '        lblDepoCode.Text = dt.Rows(0)("D_CODE")
    '        txtCheckNo.Text = dt.Rows(0)("CHECK_NO")
    '        lblCheckNo.Text = dt.Rows(0)("CHECK_NO")
    '        lblCheckRef.Text = dt.Rows(0)("CHECK_REF")
    '        lblAmount.Text = dt.Rows(0)("AMOUNT")
    '        lblDraBankCode.Text = dt.Rows(0)("DRAWEE_BANK_CODE")
    '        lblDraBankName.Text = dt.Rows(0)("BANK_NAME")
    '        lblStatusDate.Text = dt.Rows(0)("REF_DATE")
    '        lblDraBranchCode.Text = dt.Rows(0)("BRANCH_CODE")
    '        lblDraBranchName.Text = dt.Rows(0)("BRANCH_NAME")

    '        lblClientCode.Text = dt.Rows(0)("CLIENT_CODE")
    '        LblClientName.Text = dt.Rows(0)("ACC_NAME")
    '        lblAccount.Text = dt.Rows(0)("ACC_NO")
    '        lblVerNo.Text = dt.Rows(0)("MOD_NO")
    '        lblInputBy.Text = dt.Rows(0)("INPUT_BY")
    '        lblInputDate.Text = dt.Rows(0)("INPUT_DATETIME")
    '        lblAuthBy.Text = dt.Rows(0)("AUTH_BY")
    '        lblAuthDate.Text = dt.Rows(0)("AUTH_DATETIME")
    '        lblVerTot.Text = dt.Rows(0)("MOD_NO")
    '        lblModNo.Text = dt.Rows(0)("MOD_NO")


    '        If dt.Rows(0)("RTN_STATUS") = "O" Then
    '            lblStatus.Text = "OutStanding"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "P" Then
    '            lblStatus.Text = "DD Paid"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "D" Then
    '            lblStatus.Text = "DD Outstanding"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "T" Then
    '            lblStatus.Text = "DD Return"
    '        End If
    '        If dt.Rows(0)("RTN_STATUS") = "R" Then
    '            lblStatus.Text = "Returned"
    '        End If
    '        ' lblStatus.Text = dt.Rows(0)("RTN_STATUS")

    '    End If


    'End Sub

    Private Function CheckValidData() As Boolean


        If txtRefNo.Text.Trim() = "" Then
            MessageBox.Show("Reference Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRefNo.Focus()
            Return False

        ElseIf txtCheckNo.Text.Trim() = "" Then
            MessageBox.Show("Check No required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCheckNo.Focus()
            Return False

        ElseIf txtReturnCode.Text.Trim() = "" Or lblReason.Text.Trim() = "" Then
            MessageBox.Show("Return code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReturnCode.Focus()
            Return False

        End If

        If (lblStatus.Text.Trim().Substring(0, 1) <> "O") Then
            MessageBox.Show("Current status is not outstanding !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            txtReturnCode.Text = ""
            btnExit.Focus()
            Return False
        End If


        Return True

    End Function

    Private Function SaveData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Update Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_Update")

                db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "R")
                db.AddInParameter(commProc, "@RTN_CODE", DbType.String, txtReturnCode.Text)

                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result = 1 Then
                    tStatus = TransState.UnspecifiedError
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 0 Then

                    intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")
                Else
                    trans.Rollback()
                    Return tStatus
                End If


                ''''''''''''''''''''''


                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCheckUpdateByNCollection")

                db.AddInParameter(commProc2, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(commProc2, "@MOD_NO", DbType.Int32, intModno)
                db.AddInParameter(commProc2, "@RTN_STATUS", DbType.String, "R")
                db.AddInParameter(commProc2, "@RTN_CODE", DbType.String, txtReturnCode.Text.Trim())

                db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                db.ExecuteNonQuery(commProc2, trans)

                If db.GetParameterValue(commProc2, "@PROC_RET_VAL") <> 0 Then

                    trans.Rollback()
                    Return TransState.UnspecifiedError

                End If



                '''''''''''''''''''''''

                tStatus = TransState.Update

                trans.Commit()

                '--------------Mizan Work (16-05-2016)------------------
                log_message = " Updated : Non Zone Ref No : " + txtRefNo.Text.Trim()
                Logger.system_log(log_message)
                '--------------Mizan Work (16-05-2016)------------------
                _intModno = intModno

                Return tStatus


            End Using

        End If

    End Function



    Private Function CheckUpdateStatus() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Update Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_Update")

                db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "O")
                db.AddInParameter(commProc, "@RTN_CODE", DbType.String, DBNull.Value)

                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result = 1 Then
                    tStatus = TransState.UnspecifiedError
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 0 Then

                    intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")
                Else
                    trans.Rollback()
                    Return tStatus
                End If


                ''''''''''''''''''''''


                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_CCheckUpdateByNCollection")

                db.AddInParameter(commProc2, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(commProc2, "@MOD_NO", DbType.Int32, intModno)
                db.AddInParameter(commProc2, "@RTN_STATUS", DbType.String, "O")
                db.AddInParameter(commProc2, "@RTN_CODE", DbType.String, DBNull.Value)

                db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                db.ExecuteNonQuery(commProc2, trans)

                If db.GetParameterValue(commProc2, "@PROC_RET_VAL") <> 0 Then

                    trans.Rollback()
                    Return TransState.UnspecifiedError

                End If



                '''''''''''''''''''''''

                tStatus = TransState.Update

                trans.Commit()

                '--------------Mizan Work (16-05-2016)------------------
                log_message = " Updated : Non Zone Ref No : " + txtRefNo.Text.Trim() + "." + " " + " Status : " + lblStatus.Text
                Logger.system_log(log_message)
                '--------------Mizan Work (16-05-2016)------------------

                _intModno = intModno

                Return tStatus

            End Using

        End If

    End Function


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, _strRefNo)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Delete
            _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.UpdateNotPossible

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.UpdateNotPossible
        ElseIf result = 6 Then
            tStatus = TransState.AlreadyDeleted

        Else
            tStatus = TransState.UpdateNotPossible
        End If


        Return tStatus


    End Function



    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_NCollection_Auth")

        Dim cmd As New System.Data.SqlClient.SqlCommand
        'If _formMode = FormTransMode.Add Then
        '    MessageBox.Show("add")
        'ElseIf _formMode = FormTransMode.Update Then
        '    MessageBox.Show("update")
        'End If
        'cmd.CommandText = "select Input_By from CCHECKTOTAL"

        Dim dtNonZoneRef As New DataTable


        'If (dtE.Rows(0)(0).ToString() = CommonAppSet.User) Then
        '    MessageBox.Show("You cannot authorize this record !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'else
        cmd.CommandText = "select NONZONE_REF from NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO"

        cmd.Parameters.Clear()
        db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
        db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, _intModno)

        dtNonZoneRef = db.ExecuteDataSet(cmd).Tables(0)
        Dim dtNCollection As New DataTable
        Dim dtDCode As New DataTable
        Dim dtNCOLLECTION_CCHECK_HIST As New DataTable
        If (dtNonZoneRef.Rows.Count > 0) Then
            If _intModno > 1 Then
                cmd.CommandText = "INSERT INTO NCOLLECTION_HIST SELECT [NONZONE_REF],[REF_DATE],[DDREFNO],[AMOUNT],[VAT],[COMMISION],[POSTAGE_CHARGE],[INSTRUMENT_EXP],[RTN_STATUS],[RTN_CODE],[INPUT_BY],[INPUT_DATETIME],[INPUT_FROM],[AUTH_BY],[AUTH_DATETIME],[AUTH_FROM],[MOD_NO],[STATUS],1 FROM NCOLLECTION WHERE NONZONE_REF=@NONZONE_REF;"
                cmd.Parameters.Clear()
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                db.ExecuteNonQuery(cmd)
                cmd.CommandText = "UPDATE NCOLLECTION_HIST SET [STATUS] = 'O' WHERE NONZONE_REF=@NONZONE_REF AND [STATUS] = 'L';"
                cmd.Parameters.Clear()
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                db.ExecuteNonQuery(cmd)
                cmd.CommandText = "SELECT REF_DATE, DDREFNO, AMOUNT, VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, RTN_STATUS, RTN_CODE, INPUT_BY, INPUT_DATETIME,INPUT_FROM,IS_AUTH,[STATUS] FROM NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                cmd.Parameters.Clear()
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, _intModno)
                dtNCollection = db.ExecuteDataSet(cmd).Tables(0)
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
                cmd.Parameters.AddWithValue("@MOD_NO", _intModno)               
                cmd.Parameters.AddWithValue("@NONZONE_REF", _strRefNo)
                db.ExecuteNonQuery(cmd)
                cmd.CommandText = "DELETE NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0;"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@NONZONE_REF", _strRefNo)
                db.ExecuteNonQuery(cmd)
                cmd.CommandText = "	SELECT D_CODE FROM CCHECK WHERE NONZONE_REF =@NONZONE_REF"
                cmd.Parameters.Clear()
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
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
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, _intModno)
                dtNCOLLECTION_CCHECK_HIST = db.ExecuteDataSet(cmd).Tables(0)
                If (dtNCOLLECTION_CCHECK_HIST.Rows(0)("RTN_STATUS") = "O") Then
                    cmd.CommandText = "UPDATE CCHECK SET RTN_STATUS='O', RTN_CODE=NULL,[FILENAME]=NULL ,FILE_USER_ID=NULL,FLEXGEN_DATE=NULL WHERE NONZONE_REF=@NONZONE_REF;"
                    cmd.Parameters.Clear()
                    db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                    db.ExecuteNonQuery(cmd)
                Else
                    cmd.CommandText = "UPDATE CCHECK SET RTN_STATUS=@CC_RTN_STATUS, RTN_CODE=@CC_RTN_CODE WHERE NONZONE_REF=@NONZONE_REF;"
                    cmd.Parameters.Clear()
                    db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                    db.AddInParameter(cmd, "@CC_RTN_STATUS", DbType.String, dtNCOLLECTION_CCHECK_HIST.Rows(0)("RTN_STATUS"))
                    db.AddInParameter(cmd, "@CC_RTN_CODE", DbType.String, dtNCOLLECTION_CCHECK_HIST.Rows(0)("RTN_CODE"))
                    db.ExecuteNonQuery(cmd)
                End If
                cmd.CommandText = "UPDATE NCOLLECTION_CCHECK_HIST set IS_AUTH = 1 WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                cmd.Parameters.Clear()
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, _intModno)
                db.ExecuteNonQuery(cmd)
                cmd.CommandText = "Update NCOLLECTION_HIST set IS_AUTH = 1 WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;"
                cmd.Parameters.Clear()
                db.AddInParameter(cmd, "@NONZONE_REF", DbType.String, _strRefNo)
                db.AddInParameter(cmd, "@MOD_NO", DbType.Int32, _intModno)
                db.ExecuteNonQuery(cmd)
            End If

        End If

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@NONZONE_REF", DbType.String, _strRefNo)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        ' new 


        db.AddParameter(cmd, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        'db.ExecuteNonQuery(commProc)
        'result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

        result = db.ExecuteNonQuery(cmd)
        'result = db.GetParameterValue(cmd)


        If result = 0 Then

            tStatus = TransState.Update

            '--------------Mizan Work (16-05-2016)------------------
            log_message = " Authorized : Non Zone Ref No : " + txtRefNo.Text.Trim() + "." + " " + " Status : " + lblStatus.Text
            Logger.system_log(log_message)
            '--------------Mizan Work (16-05-2016)------------------

        ElseIf result = 1 Then

            'tStatus = TransState.UpdateNotPossible
            tStatus = TransState.Update
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


#End Region

    Private Sub FrmNormalCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If


        EnableUnlock()


        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()


        DisableFields()

        btnUpdateStatus.Enabled = False

        If _intModno > 0 Then

            LoadCheckDataByRefNo(_strRefNo)
            LoadMainData(_strRefNo, _intModno)
        End If
        

    End Sub



    Private Sub txtCheckNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheckNo.KeyDown
        If e.KeyCode = Keys.Enter And txtCheckNo.Text.Trim <> "" Then
            'LoadMainData(txtCheckNo.Text.Trim())
            LoadCheckDataByCheckNo(txtCheckNo.Text.Trim())
            If _strRefNo.Trim() = "" Then
                txtCheckNo.Clear()
                txtCheckNo.Focus()
            Else
                LoadCollectionData(_strRefNo)
                If _intModno > 0 Then
                    txtRefNo.ReadOnly = True
                    txtCheckNo.ReadOnly = True
                    If lblStatus.Text.Substring(0, 1) = "O" Then
                        EnableSave()
                        txtReturnCode.ReadOnly = False
                        txtReturnCode.Focus()
                    Else
                        btnUpdateStatus.Enabled = True
                        btnUpdateStatus.Focus()
                    End If

                Else
                    MessageBox.Show("Collection table doesn't have related data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If


        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            txtRefNo.Focus()
        End If


    End Sub

    'Private Sub txtRefNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefNo.LostFocus

    '    LoadFocusData(txtRefNo.Text.Trim())
    'End Sub

    Private Sub txtReturnCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturnCode.LostFocus
        'If txtReturnCode.Text = "" Then
        '    Exit Sub
        'End If
        'Dim S As String
        'S = lblStatus.Text
        'Dim lblSts As Char
        'lblSts = S.Substring(0, 1)

        'If (lblSts <> "O") Then
        '    MsgBox("Current status is not outstanding")
        '    txtReturnCode.Text = ""
        '    btnExit.Focus()
        '    Exit Sub
        'Else

        '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        '    Dim dt As New DataTable
        '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnReject_GetDetailByCode")

        '    commProc.Parameters.Clear()

        '    db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, txtReturnCode.Text)

        '    dt = db.ExecuteDataSet(commProc).Tables(0)
        '    If dt.Rows.Count > 0 Then

        '        txtReturnCode.Text = dt.Rows(0)("REJECT_CODE")
        '        lblReason.Text = dt.Rows(0)("REJECT_REASON")

        '    Else
        '        MessageBox.Show("Invalid Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtReturnCode.Clear()
        '        lblReason.Text = ""

        '    End If
        'End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()
                    'EnableUnlock()
                    'DisableNew()
                    'DisableSave()
                    ''DisableDelete()
                    'DisableAuth()
                    'DisableFields()

                    If tState = TransState.Update Then

                        LoadMainData(_strRefNo, _intModno)

                        'EnableUnlock()
                        'DisableNew()
                        DisableSave()
                        'DisableDelete()
                        DisableAuth()
                        DisableFields()

                        btnUpdateStatus.Enabled = False


                        lblToolStatus.Text = "!! Status updated successfully !!"

                    ElseIf tState = TransState.UpdateNotPossible Then
                        lblToolStatus.Text = "!! Status update Not Possible !!"

                    ElseIf tState = TransState.NoRecord Then
                        lblToolStatus.Text = "!! Nothing to update !!"
                    Else
                        lblToolStatus.Text = "!! Unpecified Error Occured !!"
                    End If


                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                tState = AuthorizeData()

                If tState = TransState.Update Then


                    LoadMainData(_strRefNo, _intModno)

                    _formMode = FormTransMode.Add

                    DisableAuth()

                    lblToolStatus.Text = "!! Authorized Successfully !!"
                ElseIf tState = TransState.AlreadyAuthorized Then
                    lblToolStatus.Text = "!! Authorized Data cannot be authorized again !!"
                ElseIf tState = TransState.MakerCheckerSame Then
                    lblToolStatus.Text = "!! You cannot authorize the transaction !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Failed! Authorization Failed !!"
                ElseIf tState = TransState.ModifiedOutside Then
                    lblToolStatus.Text = "!! Failed! Data Mismatch. Reload, Check and Authorise again !!"
                ElseIf tState = TransState.DBError Then
                    lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                ElseIf tState = TransState.UnspecifiedError Then
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtRefNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefNo.KeyDown

        If e.KeyCode = Keys.Enter And txtRefNo.Text.Trim <> "" Then
            txtRefNo.Text = txtRefNo.Text.PadLeft(7, "0")
            'LoadMainData(txtCheckNo.Text.Trim())
            LoadCheckDataByRefNo(txtRefNo.Text.Trim())
            If _strRefNo.Trim() = "" Then
                txtRefNo.Clear()
                txtRefNo.Focus()
            Else
                LoadCollectionData(_strRefNo)
                If _intModno > 0 Then
                    txtRefNo.ReadOnly = True
                    txtCheckNo.ReadOnly = True
                    If lblStatus.Text.Substring(0, 1) = "O" Then
                        'txtReturnCode.ReadOnly = False
                        txtReturnCode.Focus()

                        EnableSave()
                    ElseIf lblStatus.Text.Substring(0, 1) <> "O" And chkAuthorized.Checked = True Then
                        'btnUpdateStatus.Enabled = True
                        btnUpdateStatus.Focus()
                    End If

                Else
                    MessageBox.Show("Collection table doesn't have related data", "Critical Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        ElseIf e.KeyCode = Keys.Enter And txtRefNo.Text.Trim() = "" Then
            SendKeys.Send("{tab}")

        End If


    End Sub


    Private Sub txtReturnCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnCode.KeyDown

        If e.KeyCode = Keys.Enter And txtReturnCode.Text.Trim() <> "" Then

            If (lblStatus.Text.Trim().Substring(0, 1) <> "O") Then
                MsgBox("Current status is not outstanding")
                txtReturnCode.Text = ""
                btnExit.Focus()
                Exit Sub
            Else

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim dt As New DataTable
                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ReturnReject_GetDetailByCode")

                commProc.Parameters.Clear()

                db.AddInParameter(commProc, "@REJECT_CODE", DbType.String, txtReturnCode.Text)

                dt = db.ExecuteDataSet(commProc).Tables(0)
                If dt.Rows.Count > 0 Then

                    txtReturnCode.Text = dt.Rows(0)("REJECT_CODE")
                    lblReason.Text = dt.Rows(0)("REJECT_REASON")

                Else
                    MessageBox.Show("Invalid Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtReturnCode.Clear()
                    lblReason.Text = ""
                    txtReturnCode.Focus()

                End If
            End If

            If txtReturnCode.Text.Trim() <> "" Then
                btnSave.Focus()
            End If


        End If


    End Sub

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevVer.Click
        If _intModno - 1 > 0 Then

            LoadMainData(_strRefNo, _intModno - 1)

        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextVer.Click

        Dim strRefNo As String = _strRefNo
        Dim intModno As Integer = _intModno

        If intModno > 0 Then
            LoadMainData(_strRefNo, _intModno + 1)

            If _intModno = 0 Then
                LoadCheckDataByRefNo(strRefNo)
                LoadMainData(strRefNo, intModno)
            End If

        End If

       

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then

                    LoadMainData(_strRefNo, _intModno)


                    DisableDelete()
                    'DisableSave()




                    lblToolStatus.Text = "!! Information Deleted Successfully !!"

                ElseIf tState = TransState.AlreadyDeleted Then
                    lblToolStatus.Text = "!! Failed. Data is already deleted !!"
                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Delete Not Possible !!"

                ElseIf tState = TransState.Exist Then
                    lblToolStatus.Text = "!! New Delete status insertion failed !!"

                ElseIf tState = TransState.NoRecord Then
                    lblToolStatus.Text = "!! Nothing to Delete !!"
                Else
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If

            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnUpdateStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateStatus.Click


        'lblToolStatus.Text = ""

        'Try
        '    If MessageBox.Show("Do you want to update check status to outstanding?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCheck_UpdateStatus")


        '        commProc.Parameters.Clear()

        '        db.AddInParameter(commProc, "@D_CODE", DbType.String, lblDepoCode.Text.Trim())
        '        db.AddInParameter(commProc, "@SLNO", DbType.Int32, lblSlno.Text.Trim())
        '        db.AddInParameter(commProc, "@RTN_STATUS", DbType.String, "O")

        '        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        '        Dim result As Integer

        '        db.ExecuteNonQuery(commProc)
        '        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        '        If result = 0 Then
        '            'success
        '            MessageBox.Show("Updated Successfull." & Environment.NewLine & _
        '                            "** Separate authorization needed for CitiAnywhere Check record", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ElseIf result = 1 Then
        '            MessageBox.Show("Error Occured", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ElseIf result = 4 Then
        '            MessageBox.Show("Record not exist", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ElseIf result = 6 Then
        '            MessageBox.Show("You can't update on a deleted record", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        '        End If




        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try


        ''''''''''''''''''''''''''''''''''''''''''''''''''''



        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you want to update check status to outstanding?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                tState = CheckUpdateStatus()
                'EnableUnlock()
                'DisableNew()
                'DisableSave()
                ''DisableDelete()
                'DisableAuth()
                'DisableFields()

                If tState = TransState.Update Then

                    LoadMainData(_strRefNo, _intModno)

                    'EnableUnlock()
                    'DisableNew()
                    DisableSave()
                    'DisableDelete()
                    DisableAuth()
                    DisableFields()

                    btnUpdateStatus.Enabled = False


                    lblToolStatus.Text = "!! Status updated successfully !!"

                ElseIf tState = TransState.UpdateNotPossible Then
                    lblToolStatus.Text = "!! Status update Not Possible !!"

                ElseIf tState = TransState.NoRecord Then
                    lblToolStatus.Text = "!! Nothing to update !!"
                Else
                    lblToolStatus.Text = "!! Unpecified Error Occured !!"
                End If




            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strRefNo As String, ByVal intModNo As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strRefNo = strRefNo
        _intModno = intModNo


    End Sub
End Class