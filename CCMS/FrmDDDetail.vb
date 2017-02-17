'
'Author             : Md. fahad Khan
'Purpose            : Collection DD Detail
'Creation date      : 19-Feb-2013 
'Stored Procedure(s):  
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Globalization

Public Class FrmDDDetail

#Region "User decleration"

    'Dim nonzero As String
    'Dim checkno As String
    'Dim amount As Decimal
    'Dim accountname As String
    'Dim accno As String
    'Dim citycharge As Decimal
    'Dim citystd As Decimal
    'Dim cityvat As Decimal
    'Dim intModno As Integer
    'Dim paidslno As Integer

#End Region
#Region "Global Variables"

    Dim _formName As String = "CollectionDDDetail"
    Dim opt As SecForm = New SecForm(_formName)

    Dim _formMode As FormTransMode
    'Dim strBankCode As String = ""
    Dim _strBankCode As String = ""

    Dim _intModno As Integer = 0
    Dim _ddSlno As Integer = 0

    Dim _strDepoCode As String = ""
    Dim _intSlno As Integer = 0


    Dim _mod_datetime As Date
    Dim _status As String = ""
    Dim _RowEditMode As Boolean = False
    Dim log_message As String

    'For Update
    Dim _DDNo(1000) As String
    Dim _DDDate(1000) As String
    Dim _DDAmt(1000) As String
    Dim _BranchCode(1000) As String
    Dim _LocCode(1000) As String
    Dim _BankCode(1000) As String
    Dim _DraweeBankComm(1000) As String
    Dim _DraweeBankVat(1000) As String
    Dim _DrawBankPostChrg(1000) As String
    Dim _DrawBankInstrExp(1000) As String

    'For Auth
    Dim _aDDNo(1000) As String
    Dim _aDDDate(1000) As String
    Dim _aDDAmt(1000) As String
    Dim _aBranchCode(1000) As String
    Dim _aLocCode(1000) As String
    Dim _aBankCode(1000) As String
    Dim _aDraweeBankComm(1000) As String
    Dim _aDraweeBankVat(1000) As String
    Dim _aDrawBankPostChrg(1000) As String
    Dim _aDrawBankInstrExp(1000) As String

    Dim DDList As New List(Of String)
    Dim _ddLog As String = ""
    Dim _log As String = ""

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

    Private Sub EnableClear()
        btnClear.Enabled = True
    End Sub

    Private Sub DisableClear()
        btnClear.Enabled = False
    End Sub

    
    Private Sub DisablePaid()
        btnPaid.Enabled = False
    End Sub
    Private Sub EnablePaid()
        btnPaid.Enabled = True
    End Sub
    

    Private Sub DisableFields()
        txtDepoCode.ReadOnly = True
        txtDDNo.ReadOnly = True
        txtDDDate.ReadOnly = True
        txtBankCode.ReadOnly = True
        btnSearchBank.Enabled = False
        txtBranchCode.ReadOnly = True
        btnSearchBranch.Enabled = False
        txtLocationCode.ReadOnly = True
        btnSearchLocation.Enabled = False
        txtNikashBranch.ReadOnly = True
        btnSearchNikas.Enabled = False
        txtDraweeComm.ReadOnly = True
        txtDraweeVat.ReadOnly = True
        txtDraweePostageCharge.ReadOnly = True
        txtDraweeInstrumentCharge.ReadOnly = True
        txtDDAmount.ReadOnly = True
    End Sub

    Private Sub EnableFields()

        If _strDepoCode.Trim() = "" Then
            txtDepoCode.ReadOnly = False
        End If


        txtDDNo.ReadOnly = False
        txtDDDate.ReadOnly = False
        txtBankCode.ReadOnly = False
        btnSearchBank.Enabled = True
        txtBranchCode.ReadOnly = False
        btnSearchBranch.Enabled = True
        txtLocationCode.ReadOnly = False
        btnSearchLocation.Enabled = True
        txtNikashBranch.ReadOnly = False
        btnSearchNikas.Enabled = True
        txtDraweeComm.ReadOnly = False
        txtDraweeVat.ReadOnly = False
        txtDraweePostageCharge.ReadOnly = False
        txtDraweeInstrumentCharge.ReadOnly = False
        txtDDAmount.ReadOnly = False

    End Sub

    Private Sub ClearFields()


        If _strDepoCode = "" Then
            txtDepoCode.Clear()
        End If

        txtDDNo.Clear()
        txtDDDate.Clear()
        txtBankCode.Clear()

        txtBranchCode.Clear()

        txtLocationCode.Clear()

        txtNikashBranch.Clear()
        txtDraweeComm.Clear()
        txtDraweeVat.Clear()
        txtDraweePostageCharge.Clear()
        txtDraweeInstrumentCharge.Clear()
        txtDDAmount.Clear()
        lblBankName.Text = ""
        lblLocationName.Text = ""
        lblBranchName.Text = ""
        lblNikashBranchName.Text = ""

        'dgView.Rows.Clear()
        dgViewNotPaid.Rows.Clear()
        dgViewPaid.Rows.Clear()

        lblTotalCheckAmount.Text = ""


        '_strDepoCode = ""
        _intModno = 0
        _ddSlno = 0

        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""




    End Sub


    Private Sub ClearFieldsAll()



        txtDepoCode.Clear()
        txtDDNo.Clear()
        txtDDDate.Clear()
        txtBankCode.Clear()

        txtBranchCode.Clear()

        txtLocationCode.Clear()

        txtNikashBranch.Clear()
        txtDraweeComm.Clear()
        txtDraweeVat.Clear()
        txtDraweePostageCharge.Clear()
        txtDraweeInstrumentCharge.Clear()
        txtDDAmount.Clear()
        lblBankName.Text = ""
        lblLocationName.Text = ""
        lblBranchName.Text = ""
        lblNikashBranchName.Text = ""

        dgView.Rows.Clear()
        dgViewNotPaid.Rows.Clear()
        dgViewPaid.Rows.Clear()


        _strDepoCode = ""
        _intModno = 0
        _ddSlno = 0

        
        lblInputBy.Text = ""
        lblInputDate.Text = ""
        lblAuthBy.Text = ""
        lblAuthDate.Text = ""

        lblModNo.Text = ""

        lblToolStatus.Text = ""
        lblTotalCheckAmount.Text = ""


    End Sub

    Private Function SaveData() As TransState

        Dim tStatus As TransState

        'Dim strUserId As String = ""

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        If _formMode = FormTransMode.Add Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetMaxSlno")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@D_CODE", DbType.String, txtDepoCode.Text)

                Dim slno As Integer = db.ExecuteDataSet(commProc2, trans).Tables(0).Rows(0)(0).ToString()
                Dim new_slno As Integer = slno + 1

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Add")

                db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text)
                db.AddInParameter(commProc, "@SLNO", DbType.Int32, new_slno)
                db.AddInParameter(commProc, "@DD_NO", DbType.String, txtDDNo.Text)
                db.AddInParameter(commProc, "@DD_DATE", DbType.DateTime, DateTime.ParseExact(txtDDDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtDDAmount.Text)
                db.AddInParameter(commProc, "@DRAWER_BANKCODE", DbType.String, txtBankCode.Text)
                db.AddInParameter(commProc, "@DRAWER_BRANCHCODE", DbType.String, txtBranchCode.Text)

                db.AddInParameter(commProc, "@DRAWER_LOCATION", DbType.String, txtLocationCode.Text)
                db.AddInParameter(commProc, "@DRAWEE_BRANCH", DbType.String, lblNikashBranchName.Text)
                db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text)
                db.AddInParameter(commProc, "@VAT", DbType.Decimal, txtDraweeVat.Text)
                db.AddInParameter(commProc, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
                db.AddInParameter(commProc, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
                db.AddInParameter(commProc, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result <> 0 Then
                    tStatus = TransState.Exist
                    trans.Rollback()
                    Return tStatus
                End If


                'DD CCHECK 

                For i = 0 To dgViewPaid.Rows.Count - 1
                    Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_CCheckAddedByDD")
                    db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDepoCode.Text)
                    db.AddInParameter(commProc3, "@SLNO", DbType.String, new_slno)
                    db.AddInParameter(commProc3, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)


                    db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc3, trans)

                    If db.GetParameterValue(commProc3, "@PROC_RET_VAL") <> 0 Then

                        trans.Rollback()
                        Return TransState.UnspecifiedError

                    End If

                Next
                'DD NORMAL COLLECTION  

                Dim amount, vat, commision, post_charge, ins_charge As Decimal


                For i = 0 To dgViewPaid.Rows.Count - 1

                    amount = (NullHelper.ToDecNum(txtDDAmount.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    vat = (NullHelper.ToDecNum(txtDraweeVat.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    commision = (NullHelper.ToDecNum(txtDraweeComm.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    post_charge = (NullHelper.ToDecNum(txtDraweePostageCharge.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    ins_charge = (NullHelper.ToDecNum(txtDraweeInstrumentCharge.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)

                    Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_NCollectionAddedByDD")
                    db.AddInParameter(commProc4, "@D_CODE", DbType.String, txtDepoCode.Text)
                    db.AddInParameter(commProc4, "@SLNO", DbType.String, new_slno)
                    db.AddInParameter(commProc4, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)
                    db.AddInParameter(commProc4, "@AMOUNT", DbType.Decimal, amount)
                    db.AddInParameter(commProc4, "@VAT", DbType.Decimal, vat)
                    db.AddInParameter(commProc4, "@COMMISION", DbType.Decimal, commision)
                    db.AddInParameter(commProc4, "@POSTAGE_CHARGE", DbType.Decimal, post_charge)
                    db.AddInParameter(commProc4, "@INSTRUMENT_EXP", DbType.Decimal, ins_charge)


                    db.AddParameter(commProc4, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc4, trans)

                    If db.GetParameterValue(commProc4, "@PROC_RET_VAL") <> 0 Then

                        trans.Rollback()
                        Return TransState.UnspecifiedError

                    End If

                Next

                tStatus = TransState.Add

                trans.Commit()

                Return tStatus

            End Using



        ElseIf _formMode = FormTransMode.Update Then

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()

                'Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetMaxMod")

                'commProc3.Parameters.Clear()

                'db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDepoCode.Text)

                'Dim maxMod As Integer = db.ExecuteDataSet(commProc3).Tables(0).Rows(0)(0).ToString()
                'Dim new_maxMod As Integer = maxMod + 1

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Update")

                db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDepoCode)
                db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
                db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
                db.AddInParameter(commProc, "@DD_NO", DbType.String, txtDDNo.Text)
                db.AddInParameter(commProc, "@DD_DATE", DbType.DateTime, DateTime.ParseExact(txtDDDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtDDAmount.Text)
                db.AddInParameter(commProc, "@DRAWER_BANKCODE", DbType.String, txtBankCode.Text)
                db.AddInParameter(commProc, "@DRAWER_BRANCHCODE", DbType.String, txtBranchCode.Text)

                db.AddInParameter(commProc, "@DRAWER_LOCATION", DbType.String, txtLocationCode.Text)
                db.AddInParameter(commProc, "@DRAWEE_BRANCH", DbType.String, lblNikashBranchName.Text)
                db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text)
                db.AddInParameter(commProc, "@VAT", DbType.Decimal, txtDraweeVat.Text)
                db.AddInParameter(commProc, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
                db.AddInParameter(commProc, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
                db.AddInParameter(commProc, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)
                db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                db.ExecuteNonQuery(commProc, trans)
                result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                If result = 1 Then
                    tStatus = TransState.UnspecifiedError
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 4 Then
                    tStatus = TransState.NoRecord
                    trans.Rollback()
                    Return tStatus
                ElseIf result = 0 Then

                    intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

                End If


                'DD_C CHECK
                'Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_DD_CCHECK_GetMaxMod")

                'commProc5.Parameters.Clear()

                'db.AddInParameter(commProc5, "@D_CODE", DbType.String, txtDepoCode.Text)

                'Dim ckeckMod As Integer = db.ExecuteDataSet(commProc5).Tables(0).Rows(0)(0).ToString()
                'Dim new_ckeckMod As Integer = ckeckMod + 1

                Dim commProc7 As DbCommand = db.GetStoredProcCommand("CMS_CCheckUpdateByDD")

                For i = 0 To dgViewPaid.Rows.Count - 1

                    commProc7.Parameters.Clear()

                    db.AddInParameter(commProc7, "@D_CODE", DbType.String, _strDepoCode)
                    db.AddInParameter(commProc7, "@SLNO", DbType.Int32, _ddSlno)
                    db.AddInParameter(commProc7, "@MOD_NO", DbType.Int32, intModno)
                    db.AddInParameter(commProc7, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)

                    db.AddParameter(commProc7, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc7, trans)

                    If db.GetParameterValue(commProc7, "@PROC_RET_VAL") <> 0 Then

                        trans.Rollback()
                        Return TransState.UnspecifiedError

                    End If

                Next

                'DD N NORMAL
                'Dim commProc6 As DbCommand = db.GetStoredProcCommand("CMS_DD_NCOLLECTION_GetMaxMod")

                'commProc6.Parameters.Clear()

                'db.AddInParameter(commProc6, "@D_CODE", DbType.String, txtDepoCode.Text)

                'Dim normalMod As Integer = db.ExecuteDataSet(commProc6).Tables(0).Rows(0)(0).ToString()
                'Dim new_normalMod As Integer = normalMod + 1

                Dim amount, vat, commision, post_charge, ins_charge As Decimal

                Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_NCollectionUpdateByDD")

                For i = 0 To dgViewPaid.Rows.Count - 1

                    amount = (NullHelper.ToDecNum(txtDDAmount.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    vat = (NullHelper.ToDecNum(txtDraweeVat.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    commision = (NullHelper.ToDecNum(txtDraweeComm.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    post_charge = (NullHelper.ToDecNum(txtDraweePostageCharge.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)
                    ins_charge = (NullHelper.ToDecNum(txtDraweeInstrumentCharge.Text) / NullHelper.ToDecNum(lblTotalCheckAmount.Text)) * NullHelper.ToDecNum(dgViewPaid.Rows(i).Cells(2).Value)

                    commProc4.Parameters.Clear()

                    db.AddInParameter(commProc4, "@D_CODE", DbType.String, _strDepoCode)
                    db.AddInParameter(commProc4, "@SLNO", DbType.Int32, _ddSlno)
                    db.AddInParameter(commProc4, "@MOD_NO", DbType.Int32, intModno)
                    db.AddInParameter(commProc4, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)
                    db.AddInParameter(commProc4, "@AMOUNT", DbType.Decimal, amount)
                    db.AddInParameter(commProc4, "@VAT", DbType.Decimal, vat)
                    db.AddInParameter(commProc4, "@COMMISION", DbType.Decimal, commision)
                    db.AddInParameter(commProc4, "@POSTAGE_CHARGE", DbType.Decimal, post_charge)
                    db.AddInParameter(commProc4, "@INSTRUMENT_EXP", DbType.Decimal, ins_charge)
                    'db.AddInParameter(commProc4, "@AMOUNT", DbType.Decimal, dgViewPaid.Rows(i).Cells(2).Value)
                    'db.AddInParameter(commProc4, "@VAT", DbType.Decimal, txtDraweeVat.Text)
                    'db.AddInParameter(commProc4, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
                    'db.AddInParameter(commProc4, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
                    'db.AddInParameter(commProc4, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)

                    db.AddParameter(commProc4, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                    db.ExecuteNonQuery(commProc4, trans)

                    If db.GetParameterValue(commProc4, "@PROC_RET_VAL") <> 0 Then

                        trans.Rollback()
                        Return TransState.UnspecifiedError

                    End If

                Next


                tStatus = TransState.Update

                trans.Commit()

                '------------Mizan Work (09-05-2016)------------

                For i = 0 To dgView.Rows.Count - 1

                    
                    If _DDNo(i) <> dgView.Item(2, i).Value Then
                        log_message = " DD No : " + _DDNo(i) + " " + " To " + " " + dgView.Item(2, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _DDDate(i) <> dgView.Item(3, i).Value Then
                        log_message = " DD Date : " + _DDDate(i) + " " + " To " + " " + dgView.Item(3, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If

                    If _DDAmt(i) <> dgView.Item(8, i).Value Then
                        log_message = " DD Amount : " + _DDAmt(i) + " " + " To " + " " + dgView.Item(8, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _DraweeBankVat(i) <> dgView.Item(9, i).Value Then
                        log_message = "  Drawee Bank Vat : " + _DraweeBankVat(i) + " " + " To " + " " + dgView.Item(9, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _DraweeBankComm(i) <> dgView.Item(10, i).Value Then
                        log_message = " Drawee Bank Comm : " + _DraweeBankComm(i) + " " + " To " + " " + dgView.Item(10, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _DrawBankInstrExp(i) <> dgView.Item(12, i).Value Then
                        log_message = " Drawee Bank Instruement Exp : " + _DrawBankInstrExp(i) + " " + " To " + " " + dgView.Item(12, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _DrawBankPostChrg(i) <> dgView.Item(11, i).Value Then
                        log_message = " Drawee Bank Postage Charge : " + _DrawBankPostChrg(i) + " " + " To " + " " + dgView.Item(11, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _BankCode(i) <> dgView.Item(13, i).Value Then
                        log_message = "  Bank Code : " + _BankCode(i) + " " + " To " + " " + dgView.Item(13, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If

                    If _BranchCode(i) <> dgView.Item(14, i).Value Then
                        log_message = "  Branch Code : " + _BranchCode(i) + " " + " To " + " " + dgView.Item(14, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _LocCode(i) <> dgView.Item(15, i).Value Then
                        log_message = " Location Code : " + _LocCode(i) + " " + " To " + " " + dgView.Item(15, i).Value.ToString + "." + " "
                        DDList.Add(log_message)
                    End If

                Next

                '-----------------

                For Each ddInfo As String In DDList
                    _ddLog += ddInfo
                Next
                _log = " Updated : DD Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + _ddLog

                Logger.system_log(_log)

                _ddLog = ""
                DDList.Clear()

                '------------Mizan Work (09-05-2016)------------

                Return tStatus

            End Using

        End If


    End Function

    'Private Function UpdateData() As TransState
    '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

    '    Using conn As DbConnection = db.CreateConnection()

    '        conn.Open()

    '        Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetMaxMod")

    '        commProc3.Parameters.Clear()

    '        db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDepoCode.Text)

    '        Dim maxMod As Integer = db.ExecuteDataSet(commProc3).Tables(0).Rows(0)(0).ToString()
    '        Dim new_maxMod As Integer = maxMod + 1

    '        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Update")

    '        db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text)
    '        db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
    '        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, new_maxMod)
    '        db.AddInParameter(commProc, "@DD_NO", DbType.String, txtDDNo.Text)
    '        db.AddInParameter(commProc, "@DD_DATE", DbType.DateTime, DateTime.ParseExact(txtDDDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
    '        db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtDDAmount.Text)
    '        db.AddInParameter(commProc, "@DRAWER_BANKCODE", DbType.String, txtBankCode.Text)
    '        db.AddInParameter(commProc, "@DRAWER_BRANCHCODE", DbType.String, txtBranchCode.Text)

    '        db.AddInParameter(commProc, "@DRAWER_LOCATION", DbType.String, txtLocationCode.Text)
    '        db.AddInParameter(commProc, "@DRAWEE_BRANCH", DbType.String, lblNikashBranchName.Text)
    '        db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text)
    '        db.AddInParameter(commProc, "@VAT", DbType.Decimal, txtDraweeVat.Text)
    '        db.AddInParameter(commProc, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
    '        db.AddInParameter(commProc, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
    '        db.AddInParameter(commProc, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)


    '        db.ExecuteNonQuery(commProc)

    '        'DD_C CHECK
    '        Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_DD_CCHECK_GetMaxMod")

    '        commProc5.Parameters.Clear()

    '        db.AddInParameter(commProc5, "@D_CODE", DbType.String, txtDepoCode.Text)

    '        Dim ckeckMod As Integer = db.ExecuteDataSet(commProc5).Tables(0).Rows(0)(0).ToString()
    '        Dim new_ckeckMod As Integer = ckeckMod + 1

    '        For i = 0 To dgViewPaid.Rows.Count - 1
    '            Dim commProc7 As DbCommand = db.GetStoredProcCommand("CMS_CCheckUpdateByDD")
    '            db.AddInParameter(commProc7, "@D_CODE", DbType.String, txtDepoCode.Text)
    '            db.AddInParameter(commProc7, "@SLNO", DbType.Int32, _ddSlno)
    '            db.AddInParameter(commProc7, "@MOD_NO", DbType.Int32, new_ckeckMod)
    '            db.AddInParameter(commProc7, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)

    '            db.ExecuteNonQuery(commProc7)
    '        Next
    '        'DD N NORMAL
    '        Dim commProc6 As DbCommand = db.GetStoredProcCommand("CMS_DD_NCOLLECTION_GetMaxMod")

    '        commProc6.Parameters.Clear()

    '        db.AddInParameter(commProc6, "@D_CODE", DbType.String, txtDepoCode.Text)

    '        Dim normalMod As Integer = db.ExecuteDataSet(commProc6).Tables(0).Rows(0)(0).ToString()
    '        Dim new_normalMod As Integer = normalMod + 1


    '        For i = 0 To dgViewPaid.Rows.Count - 1
    '            Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_NCollectionUpdateByDD")
    '            db.AddInParameter(commProc4, "@D_CODE", DbType.String, txtDepoCode.Text)
    '            db.AddInParameter(commProc4, "@SLNO", DbType.Int32, _ddSlno)
    '            db.AddInParameter(commProc4, "@MOD_NO", DbType.Int32, new_normalMod)
    '            db.AddInParameter(commProc4, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)
    '            db.AddInParameter(commProc4, "@AMOUNT", DbType.Decimal, dgViewPaid.Rows(i).Cells(2).Value)
    '            db.AddInParameter(commProc4, "@CHECKREF", DbType.Decimal, dgViewPaid.Rows(i).Cells(8).Value)
    '            db.AddInParameter(commProc4, "@VAT", DbType.Decimal, txtDraweeVat.Text)
    '            db.AddInParameter(commProc4, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
    '            db.AddInParameter(commProc4, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
    '            db.AddInParameter(commProc4, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)
    '            db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, dgViewPaid.Rows(i).Cells(1).Value)
    '            db.ExecuteNonQuery(commProc4)
    '        Next

    '    End Using
    'End Function

    Private Function PaidData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Paid")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDepoCode)
        db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update
            _intModno = db.GetParameterValue(commProc, "@RET_MOD_NO")

        ElseIf result = 1 Then

            tStatus = TransState.UpdateNotPossible

        ElseIf result = 3 Then
            tStatus = TransState.UpdateNotPossible

        ElseIf result = 4 Then
            tStatus = TransState.NoRecord

        ElseIf result = 5 Then
            tStatus = TransState.UpdateNotPossible

        ElseIf result = 9 Then
            tStatus = TransState.AlreadyPaid

        Else
            tStatus = TransState.UpdateNotPossible
        End If


        Return tStatus

        'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        'Using conn As DbConnection = db.CreateConnection()

        '    conn.Open()

        '    Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetPaidMod")

        '    commProc3.Parameters.Clear()

        '    db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDepoCode.Text)

        '    Dim newMod As Integer = db.ExecuteDataSet(commProc3).Tables(0).Rows(0)(0).ToString()
        '    Dim new_newMod As Integer = newMod + 1

        '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Paid")

        '    db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text)
        '    db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
        '    db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, new_newMod)
        '    db.AddInParameter(commProc, "@DD_NO", DbType.String, txtDDNo.Text)
        '    db.AddInParameter(commProc, "@DD_DATE", DbType.DateTime, DateTime.ParseExact(txtDDDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
        '    db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtDDAmount.Text)
        '    db.AddInParameter(commProc, "@DRAWER_BANKCODE", DbType.String, txtBankCode.Text)
        '    db.AddInParameter(commProc, "@DRAWER_BRANCHCODE", DbType.String, txtBranchCode.Text)

        '    db.AddInParameter(commProc, "@DRAWER_LOCATION", DbType.String, txtLocationCode.Text)
        '    db.AddInParameter(commProc, "@DRAWEE_BRANCH", DbType.String, lblNikashBranchName.Text)
        '    db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text)
        '    db.AddInParameter(commProc, "@VAT", DbType.Decimal, txtDraweeVat.Text)
        '    db.AddInParameter(commProc, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
        '    db.AddInParameter(commProc, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
        '    db.AddInParameter(commProc, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)


        '    db.ExecuteNonQuery(commProc)

        '    'DD_C CHECK
        '    Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_DD_CCHECK_GetMaxMod")

        '    commProc5.Parameters.Clear()

        '    db.AddInParameter(commProc5, "@D_CODE", DbType.String, txtDepoCode.Text)

        '    Dim ckeckMod As Integer = db.ExecuteDataSet(commProc5).Tables(0).Rows(0)(0).ToString()
        '    Dim new_ckeckMod As Integer = ckeckMod + 1

        '    For i = 0 To dgViewPaid.Rows.Count - 1
        '        Dim commProc7 As DbCommand = db.GetStoredProcCommand("CMS_CCheckPaidByDD")
        '        db.AddInParameter(commProc7, "@D_CODE", DbType.String, txtDepoCode.Text)
        '        db.AddInParameter(commProc7, "@SLNO", DbType.Int32, _ddSlno)
        '        db.AddInParameter(commProc7, "@MOD_NO", DbType.Int32, new_ckeckMod)
        '        db.AddInParameter(commProc7, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)

        '        db.ExecuteNonQuery(commProc7)
        '    Next
        '    'DD N NORMAL 
        '    Dim commProc6 As DbCommand = db.GetStoredProcCommand("CMS_DD_NCOLLECTION_GetMaxMod")

        '    commProc6.Parameters.Clear()

        '    db.AddInParameter(commProc6, "@D_CODE", DbType.String, txtDepoCode.Text)

        '    Dim normalMod As Integer = db.ExecuteDataSet(commProc6).Tables(0).Rows(0)(0).ToString()
        '    Dim new_normalMod As Integer = normalMod + 1


        '    For i = 0 To dgViewPaid.Rows.Count - 1
        '        Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_NCollectionPaidByDD")
        '        db.AddInParameter(commProc4, "@D_CODE", DbType.String, txtDepoCode.Text)
        '        db.AddInParameter(commProc4, "@SLNO", DbType.Int32, _ddSlno)
        '        db.AddInParameter(commProc4, "@MOD_NO", DbType.Int32, new_normalMod)
        '        db.AddInParameter(commProc4, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)
        '        db.AddInParameter(commProc4, "@AMOUNT", DbType.Decimal, dgViewPaid.Rows(i).Cells(2).Value)
        '        db.AddInParameter(commProc4, "@CHECKREF", DbType.Decimal, dgViewPaid.Rows(i).Cells(8).Value)
        '        db.AddInParameter(commProc4, "@VAT", DbType.Decimal, txtDraweeVat.Text)
        '        db.AddInParameter(commProc4, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
        '        db.AddInParameter(commProc4, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
        '        db.AddInParameter(commProc4, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)
        '        db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, dgViewPaid.Rows(i).Cells(1).Value)
        '        db.ExecuteNonQuery(commProc4)
        '    Next
        'End Using

    End Function
   
    Private Function AuthorizeData() As TransState

        Dim tStatus As TransState


        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Auth")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDepoCode)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, _intModno)
        db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, _mod_datetime)

        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

        Dim result As Integer

        db.ExecuteNonQuery(commProc)
        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
        If result = 0 Then

            tStatus = TransState.Update

            '------------Mizan Work (16-05-2016)------------

            If _intModno > 1 Then

                For i = 0 To dgView.Rows.Count - 1


                    If _aDDNo(i) <> _DDNo(i) Then
                        log_message = " DD No : " + _aDDNo(i) + " " + " To " + " " + _DDNo(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aDDDate(i) <> _DDDate(i) Then
                        log_message = " DD Date : " + _aDDDate(i) + " " + " To " + " " + _DDDate(i) + "." + " "
                        DDList.Add(log_message)
                    End If

                    If _aDDAmt(i) <> _DDAmt(i) Then
                        log_message = " DD Amount : " + _aDDAmt(i) + " " + " To " + " " + _DDAmt(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aDraweeBankVat(i) <> _DraweeBankVat(i) Then
                        log_message = "  Drawee Bank Vat : " + _aDraweeBankVat(i) + " " + " To " + " " + _DraweeBankVat(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aDraweeBankComm(i) <> _DraweeBankComm(i) Then
                        log_message = " Drawee Bank Comm : " + _aDraweeBankComm(i) + " " + " To " + " " + _DraweeBankComm(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aDrawBankInstrExp(i) <> _DrawBankInstrExp(i) Then
                        log_message = " Drawee Bank Instruement Exp : " + _aDrawBankInstrExp(i) + " " + " To " + " " + _DrawBankInstrExp(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aDrawBankPostChrg(i) <> _DrawBankPostChrg(i) Then
                        log_message = " Drawee Bank Postage Charge : " + _aDrawBankPostChrg(i) + " " + " To " + " " + _DrawBankPostChrg(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aBankCode(i) <> _BankCode(i) Then
                        log_message = "  Bank Code : " + _aBankCode(i) + " " + " To " + " " + _BankCode(i) + "." + " "
                        DDList.Add(log_message)
                    End If

                    If _aBranchCode(i) <> _BranchCode(i) Then
                        log_message = "  Branch Code : " + _aBranchCode(i) + " " + " To " + " " + _BranchCode(i) + "." + " "
                        DDList.Add(log_message)
                    End If
                    If _aLocCode(i) <> _LocCode(i) Then
                        log_message = " Location Code : " + _aLocCode(i) + " " + " To " + " " + _LocCode(i) + "." + " "
                        DDList.Add(log_message)
                    End If

                Next

                '-----------------

                For Each ddInfo As String In DDList
                    _ddLog += ddInfo
                Next

                _log = " Authorized : DD Deposit Code : " + txtDepoCode.Text.Trim() + "." + " " + _ddLog
                Logger.system_log(_log)

                _ddLog = ""
                DDList.Clear()

            Else
                _log = " Authorized : DD Deposit Code : " + txtDepoCode.Text.Trim()
                Logger.system_log(_log)

            End If

            '------------Mizan Work (16-05-2016)------------

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


    Private Function DeleteData() As TransState

        Dim tStatus As TransState

        Dim intModno As Integer = 0

        tStatus = TransState.UnspecifiedError

        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Remove")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDepoCode)
        db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
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

        'Using conn As DbConnection = db.CreateConnection()

        '    conn.Open()

        'Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetPaidMod")

        'commProc3.Parameters.Clear()

        'db.AddInParameter(commProc3, "@D_CODE", DbType.String, txtDepoCode.Text)

        'Dim newMod As Integer = db.ExecuteDataSet(commProc3).Tables(0).Rows(0)(0).ToString()
        'Dim new_newMod As Integer = newMod + 1

        'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Remove")

        'db.AddInParameter(commProc, "@D_CODE", DbType.String, txtDepoCode.Text)
        'db.AddInParameter(commProc, "@SLNO", DbType.Int32, _ddSlno)
        'db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, new_newMod)
        'db.AddInParameter(commProc, "@DD_NO", DbType.String, txtDDNo.Text)
        'db.AddInParameter(commProc, "@DD_DATE", DbType.DateTime, DateTime.ParseExact(txtDDDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
        'db.AddInParameter(commProc, "@AMOUNT", DbType.Decimal, txtDDAmount.Text)
        'db.AddInParameter(commProc, "@DRAWER_BANKCODE", DbType.String, txtBankCode.Text)
        'db.AddInParameter(commProc, "@DRAWER_BRANCHCODE", DbType.String, txtBranchCode.Text)

        'db.AddInParameter(commProc, "@DRAWER_LOCATION", DbType.String, txtLocationCode.Text)
        'db.AddInParameter(commProc, "@DRAWEE_BRANCH", DbType.String, lblNikashBranchName.Text)
        'db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text)
        'db.AddInParameter(commProc, "@VAT", DbType.Decimal, txtDraweeVat.Text)
        'db.AddInParameter(commProc, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
        'db.AddInParameter(commProc, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
        'db.AddInParameter(commProc, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)


        'db.ExecuteNonQuery(commProc)

        ''DD_C CHECK
        'Dim commProc5 As DbCommand = db.GetStoredProcCommand("CMS_DD_CCHECK_GetMaxMod")

        'commProc5.Parameters.Clear()

        'db.AddInParameter(commProc5, "@D_CODE", DbType.String, txtDepoCode.Text)

        'Dim ckeckMod As Integer = db.ExecuteDataSet(commProc5).Tables(0).Rows(0)(0).ToString()
        'Dim new_ckeckMod As Integer = ckeckMod + 1

        'For i = 0 To dgViewPaid.Rows.Count - 1
        '    Dim commProc7 As DbCommand = db.GetStoredProcCommand("CMS_CCheckRemoveByDD")
        '    db.AddInParameter(commProc7, "@D_CODE", DbType.String, txtDepoCode.Text)
        '    db.AddInParameter(commProc7, "@SLNO", DbType.Int32, _ddSlno)
        '    db.AddInParameter(commProc7, "@MOD_NO", DbType.Int32, new_ckeckMod)
        '    db.AddInParameter(commProc7, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)

        '    db.ExecuteNonQuery(commProc7)
        'Next
        ''DD N NORMAL 
        'Dim commProc6 As DbCommand = db.GetStoredProcCommand("CMS_DD_NCOLLECTION_GetMaxMod")

        'commProc6.Parameters.Clear()

        'db.AddInParameter(commProc6, "@D_CODE", DbType.String, txtDepoCode.Text)

        'Dim normalMod As Integer = db.ExecuteDataSet(commProc6).Tables(0).Rows(0)(0).ToString()
        'Dim new_normalMod As Integer = normalMod + 1


        'For i = 0 To dgViewPaid.Rows.Count - 1
        '    Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_NCollectionRemoveByDD")
        '    db.AddInParameter(commProc4, "@D_CODE", DbType.String, txtDepoCode.Text)
        '    db.AddInParameter(commProc4, "@SLNO", DbType.Int32, _ddSlno)
        '    db.AddInParameter(commProc4, "@MOD_NO", DbType.Int32, new_normalMod)
        '    db.AddInParameter(commProc4, "@NONZONE_REF", DbType.String, dgViewPaid.Rows(i).Cells(0).Value)
        '    db.AddInParameter(commProc4, "@AMOUNT", DbType.Decimal, dgViewPaid.Rows(i).Cells(2).Value)
        '    db.AddInParameter(commProc4, "@CHECKREF", DbType.Decimal, dgViewPaid.Rows(i).Cells(8).Value)
        '    db.AddInParameter(commProc4, "@VAT", DbType.Decimal, txtDraweeVat.Text)
        '    db.AddInParameter(commProc4, "@COMMISION", DbType.Decimal, txtDraweeComm.Text)
        '    db.AddInParameter(commProc4, "@POSTAGE_CHARGE", DbType.Decimal, txtDraweePostageCharge.Text)
        '    db.AddInParameter(commProc4, "@INSTRUMENT_EXP", DbType.Decimal, txtDraweeInstrumentCharge.Text)
        '    db.AddInParameter(commProc4, "@CHECK_NO", DbType.String, dgViewPaid.Rows(i).Cells(1).Value)
        '    db.ExecuteNonQuery(commProc4)
        'Next
        'End Using
    End Function


    Private Sub PopulateCheckTotal()

        Dim CheckTotal As Decimal = 0



        For Each row As DataGridViewRow In dgViewPaid.Rows


            CheckTotal = CheckTotal + NullHelper.ToDecNum(row.Cells(2).Value)


        Next

        lblTotalCheckAmount.Text = CheckTotal.ToString()


        
    End Sub


    Private Sub LoadOutstandingCheck(ByVal txtBankCode As String, ByVal txtBranchCode As String, ByVal txtLocationCode As String)
        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim dt As New DataTable

        Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetOutstanding")

        commProcSche.Parameters.Clear()

        db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, txtBankCode)
        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode)
        db.AddInParameter(commProcSche, "@BRANCH_CODE", DbType.String, txtBranchCode)

        dt = db.ExecuteDataSet(commProcSche).Tables(0)

        ''modified by shanto
        'If dt.Rows.Count > 0 Then
        '    nonzero = dt.Rows(0)("NONZONE_REF")
        '    checkno = dt.Rows(0)("CHECK_NO")
        '    amount = dt.Rows(0)("AMOUNT")
        '    accountname = dt.Rows(0)("ACC_NAME")
        '    accno = dt.Rows(0)("ACC_NO")
        '    citycharge = dt.Rows(0)("CITIANY_CHARGE")
        '    citystd = dt.Rows(0)("CITIANY_STD_CHARGE")
        '    cityvat = dt.Rows(0)("CITIANY_VAT")

        'End If

        dgViewNotPaid.Rows.Clear()

        If dt.Rows.Count > 0 Then

            dgViewNotPaid.AllowUserToAddRows = True
            For i = 0 To dt.Rows.Count - 1
                If (i = dgViewNotPaid.Rows.Count - 1) Then
                    dgViewNotPaid.Rows.Add()
                End If
                dgViewNotPaid.Item(0, i).Value = dt.Rows(i)("NONZONE_REF")
                dgViewNotPaid.Item(1, i).Value = dt.Rows(i)("CHECK_NO")
                dgViewNotPaid.Item(2, i).Value = dt.Rows(i)("AMOUNT")
                dgViewNotPaid.Item(3, i).Value = dt.Rows(i)("ACC_NAME")
                dgViewNotPaid.Item(4, i).Value = dt.Rows(i)("ACC_NO")
                dgViewNotPaid.Item(5, i).Value = dt.Rows(i)("CITIANY_CHARGE")
                dgViewNotPaid.Item(6, i).Value = dt.Rows(i)("CITIANY_STD_CHARGE")
                dgViewNotPaid.Item(7, i).Value = dt.Rows(i)("CITIANY_VAT")
                dgViewNotPaid.Item(8, i).Value = dt.Rows(i)("CHECK_REF")
                dgViewNotPaid.Item(9, i).Value = dt.Rows(i)("DRAWER")

            Next
            dgViewNotPaid.AllowUserToAddRows = False

        End If
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Public Sub New(ByVal strBankCode As String, ByVal intModno As Integer, ByVal paidslno As Integer)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    '    _strBankCode = strBankCode

    '    _intModno = intModno
    '    _ddSlno = paidslno

    'End Sub

    Public Sub New(ByVal strDepoCode As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _strDepoCode = strDepoCode


    End Sub

#End Region


    Private Sub FrmDDDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If _strDepoCode.Trim() <> "" Then
            LoadDDData(_strDepoCode)

        End If

        EnableUnlock()

        DisableNew()
        DisableSave()
        DisableDelete()
        DisableAuth()

        DisableClear()


        DisableFields()

        btnPaid.Enabled = False
        btnAdd.Enabled = False
        btnRem.Enabled = False

        dgView.Enabled = False




    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        'EnableNew()

        lblToolStatus.Text = ""

        EnableNew()

        If Not (_strDepoCode  = "") Then

            EnableFields()

            EnableClear()
            'EnableDelete()
            EnableNew()

            EnableSave()

            dgView.Enabled = True

            'If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim = CommonAppSet.User) Then
            '    EnableAuth()

            'Else
            '    DisableAuth()

            'End If

        Else
            DisableAuth()
            DisableClear()
            DisableDelete()

            DisableSave()

            DisableFields()





        End If



        DisableUnlock()

        If txtDepoCode.Text.Trim() <> "" Then
            txtDDNo.Focus()
        ElseIf btnNew.Enabled = True Then
            btnNew.Focus()
        End If

       
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        _formMode = FormTransMode.Add

        EnableSave()

        ClearFieldsAll()
        EnableFields()
        EnableClear()
        'dgViewPaid.Rows.Clear()
        'dgViewNotPaid.Rows.Clear()
        'dgView.Rows.Clear()

        DisableDelete()

        btnPaid.Enabled = False
        btnAdd.Enabled = True
        btnRem.Enabled = True

        dgView.Enabled = True

        txtDepoCode.Focus()



    End Sub


    Private Function CheckValidData() As Boolean


        If txtDepoCode.Text.Trim() = "" Then
            MessageBox.Show("Deposit Code required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepoCode.Focus()
            Return False

        ElseIf txtDDNo.Text.Trim() = "" Then
            MessageBox.Show("DD Number required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDDNo.Focus()
            Return False
        ElseIf txtDDDate.Text.Trim() = "/  /" Then
            MessageBox.Show("DD Date required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDDDate.Focus()
            Return False

        ElseIf NullHelper.ToDecNum(txtDDAmount.Text) = 0 Then
            MessageBox.Show("DD Amount required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDDAmount.Focus()
            Return False


        End If

        Return True

    End Function

    Private Function CheckAmountMessage() As String
        Dim retVal As String = ""

        Dim totDDAmount As Decimal = 0

        'totDDAmount = NullHelper.ToDecNum(txtDraweeComm.Text) + NullHelper.ToDecNum(txtDraweeVat.Text) _
        '    + NullHelper.ToDecNum(txtDraweePostageCharge.Text) + NullHelper.ToDecNum(txtDraweeInstrumentCharge.Text) _
        '    + NullHelper.ToDecNum(txtDDAmount.Text)

        totDDAmount = NullHelper.ToDecNum(txtDDAmount.Text)

        If totDDAmount > NullHelper.ToDecNum(lblTotalCheckAmount.Text) Then

            retVal = "DD amount is excess " + (totDDAmount - NullHelper.ToDecNum(lblTotalCheckAmount.Text)).ToString() + Environment.NewLine

        ElseIf totDDAmount < NullHelper.ToDecNum(lblTotalCheckAmount.Text) Then

            retVal = "DD amount is less " + (NullHelper.ToDecNum(lblTotalCheckAmount.Text) - totDDAmount).ToString() + Environment.NewLine


        End If

        Return retVal

    End Function

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        _formMode = FormTransMode.Add

        ClearFields()

        btnClear.Enabled = False
        If txtDepoCode.Text.Trim() = "" Then
            txtDepoCode.Focus()
        Else
            txtDDNo.Focus()
        End If
    End Sub


    Private Sub btnSearchBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBank.Click
        Dim frmList As New FrmList()
        frmList.Text = "Bank List"
        frmList.ProcName = "CMS_Bank_GetList"
        frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblBankName.Text = frmList.RowResult.Cells(1).Value.ToString()

            txtBranchCode.Text = ""
            lblBranchName.Text = ""

            txtLocationCode.Text = ""
            lblLocationName.Text = ""

            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()


    End Sub

    Private Sub txtBankCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBankCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBankCode.Text.Trim() = "" Then

                Dim frmList As New FrmList()
                frmList.Text = "Bank List"
                frmList.ProcName = "CMS_Bank_GetList"
                frmList.filter = New String(,) {{"BANK_NAME", "Bank Name"}, {"BANK_CODE", "Bank Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Bank Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtBankCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblBankName.Text = frmList.RowResult.Cells(1).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Bank_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblBankName.Text = dt.Rows(0)("BANK_NAME").ToString()
                    Else
                        txtBankCode.Clear()
                        lblBankName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            End If

            If txtBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBranch.Click
        Dim frmList As New FrmList()
        frmList.Text = "Branch List"
        frmList.ProcName = "CMS_Branch_GetCorrBranchListByBank"
        frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()
    End Sub
    Private Sub txtBranchCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBranchCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBranchCode.Text.Trim() = "" Then


                If txtLocationCode.Text.Trim() = "" Then

                    Dim frmList As New FrmList()
                    frmList.Text = "Branch List"
                    frmList.ProcName = "CMS_Branch_GetListByBank"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                    frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()

                    End If

                    frmList.Dispose()


                Else

                    Dim frmList As New FrmList()
                    frmList.Text = "Branch List"
                    frmList.ProcName = "CMS_Branch_GetListByBankLocName"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                    frmList.AddParamToDB("@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())
                    frmList.AddParamToDB("@LOCATION_NAME", DbType.String, lblLocationName.Text.Trim())
                    frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"BRANCH_CODE", "Branch Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtBranchCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()

                    End If

                    frmList.Dispose()

                End If


                
            Else


                'Try

                '    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                '    Dim dt As New DataTable

                '    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_GetDetailByCode")

                '    commProc.Parameters.Clear()

                '    db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                '    db.AddInParameter(commProc, "@BRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())

                '    dt = db.ExecuteDataSet(commProc).Tables(0)

                '    If dt.Rows.Count > 0 Then
                '        lblLocationName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                '    Else
                '        txtBranchCode.Clear()
                '        lblBranchName.Text = ""
                '    End If


                'Catch ex As Exception
                '    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try



            End If

            If txtBranchCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If

        End If
    End Sub

    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLocation.Click
        Dim frmList As New FrmList()
        frmList.Text = "Location List"
        frmList.ProcName = "CMS_Location_GetListByBranch"
        frmList.AddParamToDB("@BRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())
        frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()
    End Sub

    Private Sub txtLocationCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtLocationCode.Text.Trim() = "" Then

                If txtBranchCode.Text.Trim() = "" Then

                    Dim frmList As New FrmList()
                    frmList.Text = "Location List"
                    frmList.ProcName = "CMS_Location_GetListByBank"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                    frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()

                Else

                    Dim frmList As New FrmList()
                    frmList.Text = "Location List"
                    frmList.ProcName = "CMS_Location_GetListByBankBranchName"
                    frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                    frmList.AddParamToDB("@BRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())
                    frmList.AddParamToDB("@BRANCH_NAME", DbType.String, lblBranchName.Text.Trim())
                    frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                    frmList.colwidth = New Integer(,) {{1, 300}}
                    frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                    frmList.ShowDialog()

                    If (frmList.RowResult.Cells.Count > 0) Then

                        txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                        lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()
                    End If

                    frmList.Dispose()


                End If

                'Dim frmList As New FrmList()
                'frmList.Text = "Location List"
                'frmList.ProcName = "CMS_Location_GetListByBranch"
                'frmList.AddParamToDB("@BRANCH_CODE", DbType.String, txtBranchCode.Text.Trim())
                'frmList.filter = New String(,) {{"LOCATION_NAME", "Location Name"}, {"LOCATION_CODE", "Location Code"}}
                'frmList.colwidth = New Integer(,) {{1, 300}}
                'frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Location Name"}}
                'frmList.ShowDialog()

                'If (frmList.RowResult.Cells.Count > 0) Then

                '    txtLocationCode.Text = frmList.RowResult.Cells(0).Value.ToString()
                '    lblLocationName.Text = frmList.RowResult.Cells(1).Value.ToString()

                'End If

                'frmList.Dispose()

            Else


                Try

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Location_GetDetailByCode")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, txtLocationCode.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblLocationName.Text = dt.Rows(0)("LOCATION_NAME").ToString()
                    Else
                        txtLocationCode.Clear()
                        lblLocationName.Text = ""
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

            If txtLocationCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If


        End If
    End Sub


    Private Sub btnSearchNikas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchNikas.Click
        Dim frmList As New FrmList()
        frmList.Text = "Drawee List"
        frmList.ProcName = "CMS_Branch_GetNikBranchListByBank"
        frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
        frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "Nikbranch Code"}}
        frmList.colwidth = New Integer(,) {{1, 300}}
        frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
        frmList.ShowDialog()

        If (frmList.RowResult.Cells.Count > 0) Then

            txtNikashBranch.Text = frmList.RowResult.Cells(0).Value.ToString()
            lblNikashBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()
            SendKeys.Send("{tab}")
        End If

        frmList.Dispose()
    End Sub

    Private Sub txtNikashBranch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNikashBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNikashBranch.Text.Trim() = "" Then

                'Dim frmList As New FrmList()
                'frmList.Text = "Drawee List"
                'frmList.ProcName = "CMS_Branch_GetNikBranchListByBank"
                'frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                'frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "Nikbranch Code"}}
                'frmList.colwidth = New Integer(,) {{1, 300}}
                'frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                'frmList.ShowDialog()

                'If (frmList.RowResult.Cells.Count > 0) Then

                '    txtNikashBranch.Text = frmList.RowResult.Cells(0).Value.ToString()
                '    lblNikashBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()

                'End If

                'frmList.Dispose()

                Dim frmList As New FrmList()
                frmList.Text = "Drawee List"
                frmList.ProcName = "CMS_ClearingBranch_GetNikBranchListByBank"
                frmList.AddParamToDB("@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                frmList.filter = New String(,) {{"BRANCH_NAME", "Branch Name"}, {"NIKBRANCH_CODE", "NikBranch Code"}}
                frmList.colwidth = New Integer(,) {{1, 300}}
                frmList.colrename = New String(,) {{"0", "Code"}, {"1", "Branch Name"}}
                frmList.ShowDialog()

                If (frmList.RowResult.Cells.Count > 0) Then

                    txtNikashBranch.Text = frmList.RowResult.Cells(0).Value.ToString()
                    lblNikashBranchName.Text = frmList.RowResult.Cells(1).Value.ToString()

                End If

                frmList.Dispose()

            Else


                Try

                    'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    'Dim dt As New DataTable

                    'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Branch_GetDetailByNikBranch")

                    'commProc.Parameters.Clear()

                    'db.AddInParameter(commProc, "@BANK_CODE", DbType.String, txtBankCode.Text.Trim())
                    'db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text.Trim())

                    'dt = db.ExecuteDataSet(commProc).Tables(0)

                    'If dt.Rows.Count > 0 Then
                    '    lblNikashBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                    'Else
                    '    txtNikashBranch.Clear()
                    '    lblNikashBranchName.Text = ""
                    'End If

                    Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                    Dim dt As New DataTable

                    Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingBranch_GetDetailByNikBranch")

                    commProc.Parameters.Clear()

                    db.AddInParameter(commProc, "@NIKBRANCH_CODE", DbType.String, txtNikashBranch.Text.Trim())

                    dt = db.ExecuteDataSet(commProc).Tables(0)

                    If dt.Rows.Count > 0 Then
                        lblNikashBranchName.Text = dt.Rows(0)("BRANCH_NAME").ToString()
                    Else
                        txtNikashBranch.Clear()
                        lblNikashBranchName.Text = ""
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

            If txtBankCode.Text.Trim() <> "" Then
                SendKeys.Send("{tab}")
                SendKeys.Send("{tab}")
            End If


        End If
    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Dim strCheckAmountMessage As String = CheckAmountMessage()

        Try
            If MessageBox.Show(strCheckAmountMessage + "Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = SaveData()

                    Dim strDepoCode As String = txtDepoCode.Text.Trim()

                    If tState = TransState.Add Then

                        ClearFieldsAll()
                        LoadDDData(strDepoCode)

                        If _strDepoCode <> "" Then
                            txtDepoCode.ReadOnly = True
                        End If

                        lblToolStatus.Text = "!! Information Added Successfully !!"

                        _formMode = FormTransMode.Add


                        'EnableDelete()

                        'EnableRefresh()

                        'EnableUnlock()

                        'EnableNew()
                        'DisableSave()
                        'DisableDelete()
                        'DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()

                        txtDDNo.Focus()

                    ElseIf tState = TransState.Update Then
                        ClearFieldsAll()
                        LoadDDData(strDepoCode)

                        _formMode = FormTransMode.Add

                        lblToolStatus.Text = "!! Information Updated Successfully !!"

                        'EnableUnlock()
                        'DisableNew()
                        'DisableSave()
                        'DisableDelete()
                        'DisableAuth()
                        'DisableClear()
                        'DisableRefresh()
                        'DisableFields()

                        txtDDNo.Focus()

                    ElseIf tState = TransState.Exist Then
                        lblToolStatus.Text = "!! Already Exist !!"
                    ElseIf tState = TransState.NoRecord Then
                        lblToolStatus.Text = "!! Nothing to Update !!"
                    ElseIf tState = TransState.DBError Then
                        lblToolStatus.Text = "!! Database error occured. Please, Try Again !!"
                    ElseIf tState = TransState.UnspecifiedError Then
                        lblToolStatus.Text = "!! Unpecified Error Occured !!"
                    End If

                    'LoadDDData(_strDepoCode)

                    'EnableUnlock()
                    'DisableNew()
                    'DisableSave()
                    'DisableDelete()
                    'DisableAuth()
                    'DisableClear()
                    'DisableRefresh()
                    'DisableFields()
                    'DisableUpdate()

                End If
                'lblToolStatus.Text = "!! Information Saved Successfully !!"

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub txtDDAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDDAmount.LostFocus
        'LoadDetailData(txtBankCode.Text.Trim(), txtBranchCode.Text.Trim(), txtLocationCode.Text.Trim())

        LoadOutstandingCheck(txtBankCode.Text.Trim(), txtBranchCode.Text.Trim(), txtLocationCode.Text.Trim())

    End Sub

    Private Sub LoadDetailData(ByVal txtBankCode As String, ByVal txtBranchCode As String, ByVal txtLocationCode As String)
        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim dt As New DataTable

        Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_CCheck_GetDetailsByAmntStatus")

        commProcSche.Parameters.Clear()

        db.AddInParameter(commProcSche, "@DRAWEE_BANK_CODE", DbType.String, txtBankCode)
        db.AddInParameter(commProcSche, "@LOCATION_CODE", DbType.String, txtLocationCode)
        db.AddInParameter(commProcSche, "@BRANCH_CODE", DbType.String, txtBranchCode)

        dt = db.ExecuteDataSet(commProcSche).Tables(0)

        ''modified by shanto
        'If dt.Rows.Count > 0 Then
        '    nonzero = dt.Rows(0)("NONZONE_REF")
        '    checkno = dt.Rows(0)("CHECK_NO")
        '    amount = dt.Rows(0)("AMOUNT")
        '    accountname = dt.Rows(0)("ACC_NAME")
        '    accno = dt.Rows(0)("ACC_NO")
        '    citycharge = dt.Rows(0)("CITIANY_CHARGE")
        '    citystd = dt.Rows(0)("CITIANY_STD_CHARGE")
        '    cityvat = dt.Rows(0)("CITIANY_VAT")

        'End If

        dgViewNotPaid.Rows.Clear()

        If dt.Rows.Count > 0 Then

            dgViewNotPaid.AllowUserToAddRows = True
            For i = 0 To dt.Rows.Count - 1
                If (i = dgViewNotPaid.Rows.Count - 1) Then
                    dgViewNotPaid.Rows.Add()
                End If
                dgViewNotPaid.Item(0, i).Value = dt.Rows(i)("NONZONE_REF")
                dgViewNotPaid.Item(1, i).Value = dt.Rows(i)("CHECK_NO")
                dgViewNotPaid.Item(2, i).Value = dt.Rows(i)("AMOUNT")
                dgViewNotPaid.Item(3, i).Value = dt.Rows(i)("ACC_NAME")
                dgViewNotPaid.Item(4, i).Value = dt.Rows(i)("ACC_NO")
                dgViewNotPaid.Item(5, i).Value = dt.Rows(i)("CITIANY_CHARGE")
                dgViewNotPaid.Item(6, i).Value = dt.Rows(i)("CITIANY_STD_CHARGE")
                dgViewNotPaid.Item(7, i).Value = dt.Rows(i)("CITIANY_VAT")
                dgViewNotPaid.Item(8, i).Value = dt.Rows(i)("CHECK_REF")
                dgViewNotPaid.Item(9, i).Value = dt.Rows(i)("DRAWER")


            Next
            dgViewNotPaid.AllowUserToAddRows = False

        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If dgViewNotPaid.SelectedRows.Count = 0 Then Exit Sub
        'dgViewPaid.AllowUserToAddRows = True

        'If (maxSelRow = dgViewNotPaid.Rows.Count - 1) Then



        ' --------------------------

        Dim flagDup As Boolean = False

        Dim citicharge As Decimal

        Dim citivat As Decimal

        Dim maxSelRow As Integer

        For Each nrow As DataGridViewRow In dgViewNotPaid.SelectedRows

            flagDup = False

            For Each prow As DataGridViewRow In dgViewPaid.Rows
                If prow.Cells(0).Value.ToString().Trim() = nrow.Cells(0).Value.ToString().Trim() Then
                    MessageBox.Show("Item already selected!!" + Environment.NewLine + _
                                    "Ref: " + nrow.Cells(0).Value.ToString() + Environment.NewLine + _
                                    "Check No: " + nrow.Cells(1).Value.ToString(), "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    flagDup = True
                    Exit For
                End If

            Next

            If flagDup = True Then
                Continue For
            End If


            dgViewPaid.Rows.Add()

            maxSelRow = dgViewPaid.Rows.Count - 1

            citicharge = NullHelper.ToDecNum(nrow.Cells(5).Value) / 1000 * NullHelper.ToDecNum(nrow.Cells(2).Value)

            citivat = NullHelper.ToDecNum(nrow.Cells(6).Value) / 1000 * NullHelper.ToDecNum(nrow.Cells(2).Value) * (NullHelper.ToDecNum(nrow.Cells(2).Value) / 100)

            dgViewPaid.Item(0, maxSelRow).Value = nrow.Cells(0).Value
            dgViewPaid.Item(1, maxSelRow).Value = nrow.Cells(1).Value
            dgViewPaid.Item(2, maxSelRow).Value = nrow.Cells(2).Value 'amount
            dgViewPaid.Item(3, maxSelRow).Value = nrow.Cells(3).Value
            dgViewPaid.Item(4, maxSelRow).Value = nrow.Cells(4).Value
            dgViewPaid.Item(5, maxSelRow).Value = nrow.Cells(5).Value 'Citibank Charge
            dgViewPaid.Item(6, maxSelRow).Value = nrow.Cells(6).Value 'Standard Charge
            dgViewPaid.Item(7, maxSelRow).Value = nrow.Cells(7).Value 'Citibank VAT
            dgViewPaid.Item(8, maxSelRow).Value = nrow.Cells(8).Value
            'dgViewPaid.Item(9, maxSelRow).Value = (dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value - (dgViewNotPaid.SelectedRows.Item(0).Cells(5).Value + dgViewNotPaid.SelectedRows.Item(0).Cells(6).Value + dgViewNotPaid.SelectedRows.Item(0).Cells(7).Value))

            dgViewPaid.Item(9, maxSelRow).Value = NullHelper.ToDecNum(nrow.Cells(2).Value) - citicharge - citivat

           

            dgViewNotPaid.Rows.Remove(nrow)
        Next

        'dgViewPaid.Rows(0).Selected = True
        'dgViewPaid.Rows(0).Selected = True
        'dgViewPaid.Rows(maxSelRow).Selected = False


        ' -------------------------











        'dgViewPaid.Rows.Add()
        ''End If
        ''dgViewPaid.Rows.Add()

        'Dim citicharge As Decimal

        'Dim citivat As Decimal

        'Dim maxSelRow As Integer = dgViewPaid.Rows.Count - 1

        'citicharge = NullHelper.ToDecNum(dgViewNotPaid.SelectedRows.Item(0).Cells(5).Value) / 1000 * NullHelper.ToDecNum(dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value)

        'citivat = NullHelper.ToDecNum(dgViewNotPaid.SelectedRows.Item(0).Cells(6).Value) / 1000 * NullHelper.ToDecNum(dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value) * (NullHelper.ToDecNum(dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value) / 100)

        'dgViewPaid.Item(0, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(0).Value
        'dgViewPaid.Item(1, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(1).Value
        'dgViewPaid.Item(2, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value 'amount
        'dgViewPaid.Item(3, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(3).Value
        'dgViewPaid.Item(4, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(4).Value
        'dgViewPaid.Item(5, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(5).Value 'Citibank Charge
        'dgViewPaid.Item(6, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(6).Value 'Standard Charge
        'dgViewPaid.Item(7, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(7).Value 'Citibank VAT
        'dgViewPaid.Item(8, maxSelRow).Value = dgViewNotPaid.SelectedRows.Item(0).Cells(8).Value
        ''dgViewPaid.Item(9, maxSelRow).Value = (dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value - (dgViewNotPaid.SelectedRows.Item(0).Cells(5).Value + dgViewNotPaid.SelectedRows.Item(0).Cells(6).Value + dgViewNotPaid.SelectedRows.Item(0).Cells(7).Value))

        'dgViewPaid.Item(9, maxSelRow).Value = NullHelper.ToDecNum(dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value) - citicharge - citivat


        'dgViewPaid.Rows(0).Selected = True
        'dgViewPaid.Rows(0).Selected = True
        'dgViewPaid.Rows(maxSelRow).Selected = False

        'For Each row As DataGridViewRow In dgViewNotPaid.SelectedRows

        '    dgViewNotPaid.Rows.Remove(row)
        'Next

        PopulateCheckTotal()

    End Sub

    Private Sub btnRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRem.Click
        If dgViewPaid.SelectedRows.Count = 0 Then Exit Sub

        'dgViewNotPaid.Rows.Add()
        'Dim maxAvlRow As Integer = dgViewNotPaid.Rows.Count - 1
        'dgViewNotPaid.Item(0, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(0).Value
        'dgViewNotPaid.Item(1, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(1).Value
        'dgViewNotPaid.Item(2, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(2).Value
        'dgViewNotPaid.Item(3, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(3).Value
        'dgViewNotPaid.Item(4, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(4).Value
        'dgViewNotPaid.Item(5, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(5).Value
        'dgViewNotPaid.Item(6, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(6).Value
        'dgViewNotPaid.Item(7, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(7).Value
        'dgViewNotPaid.Item(8, maxAvlRow).Value = dgViewPaid.SelectedRows.Item(0).Cells(8).Value
        'dgViewNotPaid.Rows(0).Selected = True
        'dgViewNotPaid.Rows(0).Selected = False
        'dgViewNotPaid.Rows(maxAvlRow).Selected = True

        For Each row As DataGridViewRow In dgViewPaid.SelectedRows


            'dgViewNotPaid.Rows.Add()
            'Dim maxAvlRow As Integer = dgViewNotPaid.Rows.Count - 1
            'dgViewNotPaid.Item(0, maxAvlRow).Value = row.Cells(0).Value
            'dgViewNotPaid.Item(1, maxAvlRow).Value = row.Cells(1).Value
            'dgViewNotPaid.Item(2, maxAvlRow).Value = row.Cells(2).Value
            'dgViewNotPaid.Item(3, maxAvlRow).Value = row.Cells(3).Value
            'dgViewNotPaid.Item(4, maxAvlRow).Value = row.Cells(4).Value
            'dgViewNotPaid.Item(5, maxAvlRow).Value = row.Cells(5).Value
            'dgViewNotPaid.Item(6, maxAvlRow).Value = row.Cells(6).Value
            'dgViewNotPaid.Item(7, maxAvlRow).Value = row.Cells(7).Value
            'dgViewNotPaid.Item(8, maxAvlRow).Value = row.Cells(8).Value
            'dgViewNotPaid.Rows(0).Selected = True
            'dgViewNotPaid.Rows(0).Selected = False
            'dgViewNotPaid.Rows(maxAvlRow).Selected = True

            dgViewPaid.Rows.Remove(row)

        Next

        PopulateCheckTotal()

    End Sub

    Private Sub txtDepoCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepoCode.KeyDown
        If e.KeyCode = Keys.Enter And txtDepoCode.Text.Trim() <> "" Then

            'txtDepoCode.Text = txtDepoCode.Text.Trim().PadLeft(12, "0")

            'LoadDDData(txtDepoCode.Text.Trim())

            'If _strDepoCode <> "" Then

            '    txtDepoCode.ReadOnly = True

            'End If

            SendKeys.Send("{tab}")


            'DisableSave()
        End If

    End Sub

    '------------Mizan Work (16-05-2016)------------

    Private Sub LoadDDDataForAuth(ByVal DepoCode As String)

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            dt = db.ExecuteDataSet(CommandType.Text, "Select * From DD  Where D_CODE ='" & DepoCode & "'  and   STATUS='L'").Tables(0)

            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                _strDepoCode = DepoCode
                txtDepoCode.Text = DepoCode

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    '---------
                    'dgview col no shifted by 1 as a new check box col added in the first col
                    ' Shanto [22-Jun-13]

                    dgView.Item(1, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(2, i).Value = dt.Rows(i)("DD_NO")
                    _aDDNo(i) = dt.Rows(i)("DD_NO")
                    dgView.Item(3, i).Value = NullHelper.DateToString(dt.Rows(i)("DD_DATE"))
                    _aDDDate(i) = NullHelper.DateToString(dt.Rows(i)("DD_DATE")).ToString()
                    'dgView.Item(4, i).Value = dt.Rows(i)("BANK_NAME")
                    'dgView.Item(5, i).Value = dt.Rows(i)("BRANCH_NAME")
                    'dgView.Item(6, i).Value = dt.Rows(i)("LOCATION_NAME")
                    dgView.Item(7, i).Value = dt.Rows(i)("DRAWEE_BRANCH")
                    dgView.Item(8, i).Value = dt.Rows(i)("AMOUNT")
                    _aDDAmt(i) = dt.Rows(i)("AMOUNT")
                    dgView.Item(9, i).Value = NullHelper.ToDecNum(dt.Rows(i)("VAT"))
                    _aDraweeBankVat(i) = NullHelper.ToDecNum(dt.Rows(i)("VAT")).ToString
                    dgView.Item(10, i).Value = dt.Rows(i)("COMMISION")
                    _aDraweeBankComm(i) = dt.Rows(i)("COMMISION").ToString
                    dgView.Item(11, i).Value = dt.Rows(i)("POSTAGE_CHARGE")
                    _aDrawBankPostChrg(i) = dt.Rows(i)("POSTAGE_CHARGE")
                    dgView.Item(12, i).Value = dt.Rows(i)("INSTRUMENT_EXP")
                    _aDrawBankInstrExp(i) = dt.Rows(i)("INSTRUMENT_EXP")
                    dgView.Item(13, i).Value = dt.Rows(i)("DRAWER_BANKCODE")
                    _aBankCode(i) = dt.Rows(i)("DRAWER_BANKCODE")
                    dgView.Item(14, i).Value = dt.Rows(i)("DRAWER_BRANCHCODE")
                    _aBranchCode(i) = dt.Rows(i)("DRAWER_BRANCHCODE")
                    dgView.Item(15, i).Value = dt.Rows(i)("DRAWER_LOCATION")
                    _aLocCode(i) = dt.Rows(i)("DRAWER_LOCATION")
                    dgView.Item(16, i).Value = dt.Rows(i)("NIKBRANCH_CODE")
                    dgView.Item(17, i).Value = dt.Rows(i)("D_CODE")
                    dgView.Item(18, i).Value = dt.Rows(i)("MOD_NO")

                    dgView.Item(19, i).Value = dt.Rows(i)("RTN_STATUS")

                    'dgView.Item(20, i).Value = IIf(dt.Rows(i)("IS_AUTH") = 1, "A", "U")



                Next
                dgView.AllowUserToAddRows = False

            Else
                _strDepoCode = ""

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub LoadDDData(ByVal DepoCode As String)

        Try

        
            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProcSche As DbCommand = db.GetStoredProcCommand("CMS_DD_GetDetail")

            commProcSche.Parameters.Clear()

            db.AddInParameter(commProcSche, "@D_CODE", DbType.String, DepoCode)

            dt = db.ExecuteDataSet(commProcSche).Tables(0)

                dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                _strDepoCode = DepoCode
                txtDepoCode.Text = DepoCode

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If

                    '---------
                    'dgview col no shifted by 1 as a new check box col added in the first col
                    ' Shanto [22-Jun-13]

                    dgView.Item(1, i).Value = dt.Rows(i)("SLNO")
                    dgView.Item(2, i).Value = dt.Rows(i)("DD_NO")
                    _DDNo(i) = dt.Rows(i)("DD_NO")
                    dgView.Item(3, i).Value = NullHelper.DateToString(dt.Rows(i)("DD_DATE"))
                    _DDDate(i) = NullHelper.DateToString(dt.Rows(i)("DD_DATE")).ToString()
                    dgView.Item(4, i).Value = dt.Rows(i)("BANK_NAME")
                    dgView.Item(5, i).Value = dt.Rows(i)("BRANCH_NAME")
                    dgView.Item(6, i).Value = dt.Rows(i)("LOCATION_NAME")
                    dgView.Item(7, i).Value = dt.Rows(i)("DRAWEE_BRANCH")
                    dgView.Item(8, i).Value = dt.Rows(i)("AMOUNT")
                    _DDAmt(i) = dt.Rows(i)("AMOUNT")
                    dgView.Item(9, i).Value = NullHelper.ToDecNum(dt.Rows(i)("VAT"))
                    _DraweeBankVat(i) = NullHelper.ToDecNum(dt.Rows(i)("VAT")).ToString
                    dgView.Item(10, i).Value = dt.Rows(i)("COMMISION")
                    _DraweeBankComm(i) = dt.Rows(i)("COMMISION").ToString
                    dgView.Item(11, i).Value = dt.Rows(i)("POSTAGE_CHARGE")
                    _DrawBankPostChrg(i) = dt.Rows(i)("POSTAGE_CHARGE")
                    dgView.Item(12, i).Value = dt.Rows(i)("INSTRUMENT_EXP")
                    _DrawBankInstrExp(i) = dt.Rows(i)("INSTRUMENT_EXP")
                    dgView.Item(13, i).Value = dt.Rows(i)("DRAWER_BANKCODE")
                    _BankCode(i) = dt.Rows(i)("DRAWER_BANKCODE")
                    dgView.Item(14, i).Value = dt.Rows(i)("DRAWER_BRANCHCODE")
                    _BranchCode(i) = dt.Rows(i)("DRAWER_BRANCHCODE")
                    dgView.Item(15, i).Value = dt.Rows(i)("DRAWER_LOCATION")
                    _LocCode(i) = dt.Rows(i)("DRAWER_LOCATION")
                    dgView.Item(16, i).Value = dt.Rows(i)("NIKBRANCH_CODE")
                    dgView.Item(17, i).Value = dt.Rows(i)("D_CODE")
                    dgView.Item(18, i).Value = dt.Rows(i)("MOD_NO")

                    dgView.Item(19, i).Value = dt.Rows(i)("RTN_STATUS")

                    dgView.Item(20, i).Value = IIf(dt.Rows(i)("IS_AUTH") = 1, "A", "U")



                Next
                dgView.AllowUserToAddRows = False

            Else
                _strDepoCode = ""

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

   
    Private Sub LoadAuthdata(ByVal DepoCode As String, ByVal ddSlno As Integer, ByVal intModno As Integer)
        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@D_CODE", DbType.String, DepoCode)
            db.AddInParameter(commProc, "@SLNO", DbType.String, ddSlno)
            db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intModno)

            ds = db.ExecuteDataSet(commProc)

            If ds.Tables(0).Rows.Count > 0 Then

                '_strBankCode = strBankCode
                _strDepoCode = DepoCode
                _intModno = intModno
                _ddSlno = ddSlno

                'strBankCode = ds.Tables(0).Rows(0)("D_CODE").ToString()
                'paidslno = ds.Tables(0).Rows(0)("SLNO").ToString()
                Dim rtnStatus As String = ds.Tables(0).Rows(0)("RTN_STATUS").ToString()

                If rtnStatus = "D" And ds.Tables(0).Rows(0)("STATUS") = "L" Then
                    btnPaid.Enabled = True
                Else
                    btnPaid.Enabled = False

                End If

                If rtnStatus = "P" And ds.Tables(0).Rows(0)("STATUS") = "L" Then
                    btnAdd.Enabled = False
                    btnRem.Enabled = False
                Else
                    btnAdd.Enabled = True
                    btnRem.Enabled = True
                End If
                

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
                
                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_DD_GetMaxMod")

                commProc2.Parameters.Clear()

                db.AddInParameter(commProc2, "@D_CODE", DbType.String, _strDepoCode)
                db.AddInParameter(commProc2, "@SLNO", DbType.Int32, _ddSlno)

                

                If _status = "L" Or _status = "U" _
                    Or (_status = "D" And chkAuthorized.Checked = False) Then


                    If btnUnlock.Enabled = False Then
                        EnableFields()
                        EnableClear()
                        EnableDelete()
                        EnableNew()
                        
                        If rtnStatus = "D" Then
                            EnableSave()
                        Else
                            DisableSave()
                        End If


                    End If
                Else
                    DisableAuth()
                    DisableClear()
                    DisableDelete()

                    EnableSave()


                    DisableFields()
                End If

                If chkAuthorized.Checked = False And (Not lblInputBy.Text.Trim().ToUpper() = CommonAppSet.User.Trim().ToUpper()) Then
                    EnableAuth()
                    'DisablePaid()
                Else
                    DisableAuth()
                    'EnablePaid()
                End If


            Else

                ClearFieldsAll()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoaddgViewPaidData(ByVal depoCode As String, ByVal paidslno As Integer, ByVal intModno As Integer)
        Dim db As New SqlDatabase(CommonAppSet.ConnStr)

        Dim dt As New DataTable

        Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_CCheck_GetDetail")

        commProc.Parameters.Clear()

        db.AddInParameter(commProc, "@D_CODE", DbType.String, depoCode)
        db.AddInParameter(commProc, "@SLNO", DbType.Int32, paidslno)
        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, intModno)
        dt = db.ExecuteDataSet(commProc).Tables(0)


        'If dt.Rows.Count > 0 Then
        '    nonzero = dt.Rows(0)("NONZONE_REF")
        '    checkno = dt.Rows(0)("CHECK_NO")
        '    amount = dt.Rows(0)("AMOUNT")
        '    accountname = dt.Rows(0)("ACC_NAME")
        '    accno = dt.Rows(0)("ACC_NO")
        '    citycharge = dt.Rows(0)("CITIANY_CHARGE")
        '    citystd = dt.Rows(0)("CITIANY_STD_CHARGE")
        '    cityvat = dt.Rows(0)("CITIANY_VAT")

        'End If
        dgViewPaid.Rows.Clear()

        If dt.Rows.Count > 0 Then

            dgViewPaid.AllowUserToAddRows = True
            For i = 0 To dt.Rows.Count - 1
                If (i = dgViewPaid.Rows.Count - 1) Then
                    dgViewPaid.Rows.Add()
                End If
                dgViewPaid.Item(0, i).Value = dt.Rows(i)("NONZONE_REF")
                dgViewPaid.Item(1, i).Value = dt.Rows(i)("CHECK_NO")
                dgViewPaid.Item(2, i).Value = dt.Rows(i)("AMOUNT")
                dgViewPaid.Item(3, i).Value = dt.Rows(i)("ACC_NAME")
                dgViewPaid.Item(4, i).Value = dt.Rows(i)("ACC_NO")
                dgViewPaid.Item(5, i).Value = dt.Rows(i)("CITIANY_CHARGE")
                dgViewPaid.Item(6, i).Value = dt.Rows(i)("CITIANY_STD_CHARGE")
                dgViewPaid.Item(7, i).Value = dt.Rows(i)("CITIANY_VAT")
                dgViewPaid.Item(8, i).Value = dt.Rows(i)("CHECK_REF")
                dgViewPaid.Item(9, i).Value = (dt.Rows(i)("AMOUNT") - (dt.Rows(i)("CITIANY_CHARGE") + dt.Rows(i)("CITIANY_STD_CHARGE") + dt.Rows(i)("CITIANY_VAT")))

            Next
            dgViewPaid.AllowUserToAddRows = False

        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _intModno > 1 Then
                    LoadDDDataForAuth(_strDepoCode)
                End If

                tState = AuthorizeData()

                Dim DepoCode As String = txtDepoCode.Text.Trim()

                If tState = TransState.Update Then


                    ClearFieldsAll()

                    LoadDDData(DepoCode)

                    _formMode = FormTransMode.Add

                    DisableAuth()


                    'LoadMainData(_strCSCode, _intModno)
                    'LoadDetailData(_strCSCode, _intModno)
                    'LoaddgViewPaidData(_strBankCode, _ddSlno, _intModno)
                    'LoadAuthdata(_strBankCode, _ddSlno, _intModno)

                    lblToolStatus.Text = "!! Authorized Successfully !!"
                    'EnableUnlock()

                    'DisableNew()
                    'DisableSave()
                    'DisableDelete()
                    'DisableAuth()

                    'DisableClear()
                    'DisableRefresh()

                    'DisableFields()
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

    Private Sub btnPaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaid.Click

        Dim tState As TransState

        lblToolStatus.Text = ""

        Try
            If MessageBox.Show("Do you really want update the dd status as paid?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If CheckValidData() Then

                    tState = PaidData()

                    If tState = TransState.Update Then

                        Dim strDepoCode As String = txtDepoCode.Text

                        ClearFieldsAll()

                        LoadDDData(strDepoCode)

                        _formMode = FormTransMode.Add

                        DisableAuth()
                        btnPaid.Enabled = False
                        DisableDelete()

                        lblToolStatus.Text = "!! DD Marked as paid successfully !!"

                    
                    ElseIf tState = TransState.UpdateNotPossible Then
                        lblToolStatus.Text = "!! Status update Not Possible !!"

                    ElseIf tState = TransState.AlreadyPaid Then
                        lblToolStatus.Text = "!! Already paid !!"

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

    'Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    '    Dim tState As TransState

    '    lblToolStatus.Text = ""

    '    Try
    '        If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            If CheckValidData() Then

    '                tState = UpdateData()
    '                EnableUnlock()
    '                DisableNew()
    '                DisableSave()
    '                DisableDelete()
    '                DisableAuth()
    '                DisableClear()
    '                DisableRefresh()
    '                DisableFields()
    '                DisableUpdate()

    '            End If
    '            lblToolStatus.Text = "!! Information Updated Successfully !!"

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub

    Private Sub btnPrevVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _intModno - 1 > 0 Then

            LoaddgViewPaidData(_strBankCode, _ddSlno, _intModno)
            LoadAuthdata(_strBankCode, _ddSlno, _intModno - 1)


        End If
    End Sub

    Private Sub btnNextVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strBankCode As String = _strBankCode
        Dim intModno As Integer = _intModno
        Dim paidslno As Integer = _ddSlno

        If intModno > 0 Then
            LoadAuthdata(_strBankCode, _ddSlno, _intModno + 1)

            If _intModno = 0 Then
                LoadAuthdata(strBankCode, paidslno, intModno)
            End If

            LoaddgViewPaidData(_strBankCode, _ddSlno, _intModno)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim tState As TransState

        lblToolStatus.Text = ""

        Try


            If MessageBox.Show("Do you really want to delete?" + Environment.NewLine + _
                               "DD No: " + txtDDNo.Text.Trim(), "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                tState = DeleteData()

                If tState = TransState.Delete Then

                    'LoaddgViewPaidData(_strBankCode, _ddSlno, _intModno)
                    'LoadAuthdata(_strBankCode, _ddSlno, _intModno)

                    Dim strDepoCode As String = txtDepoCode.Text

                    ClearFieldsAll()

                    LoadDDData(strDepoCode)

                    _formMode = FormTransMode.Add

                    DisableAuth()
                    btnPaid.Enabled = False
                    DisableDelete()

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

   

   

    Private Sub txtDepoCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepoCode.Validated
        If txtDepoCode.Text.Trim() <> "" Then
            txtDepoCode.Text = txtDepoCode.Text.Trim().PadLeft(5, "0")
        End If

        If txtDepoCode.Text.Trim() <> "" And _intModno = 0 Then

            'txtDepoCode.Text = txtDepoCode.Text.Trim().PadLeft(12, "0")

            LoadDDData(txtDepoCode.Text.Trim())

            If _strDepoCode <> "" Then

                txtDepoCode.ReadOnly = True

            End If

            'SendKeys.Send("{tab}")


            'DisableSave()
        End If
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        '---------
        'dgview col no shifted by 1 as a new check box col added in the first col
        ' Shanto [22-Jun-13]

        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            _formMode = FormTransMode.Update

            _ddSlno = dgView.Item(1, e.RowIndex).Value
            _intModno = dgView.Item(18, e.RowIndex).Value

            txtDDNo.Text = dgView.Item(2, e.RowIndex).Value
            txtDDDate.Text = dgView.Item(3, e.RowIndex).Value
            lblBankName.Text = NullHelper.ObjectToString(dgView.Item(4, e.RowIndex).Value)
            lblBranchName.Text = NullHelper.ObjectToString(dgView.Item(5, e.RowIndex).Value)
            lblLocationName.Text = dgView.Item(6, e.RowIndex).Value
            lblNikashBranchName.Text = dgView.Item(7, e.RowIndex).Value

            txtDDAmount.Text = dgView.Item(8, e.RowIndex).Value
            txtDraweeVat.Text = dgView.Item(9, e.RowIndex).Value
            txtDraweeComm.Text = dgView.Item(10, e.RowIndex).Value
            txtDraweePostageCharge.Text = dgView.Item(11, e.RowIndex).Value
            txtDraweeInstrumentCharge.Text = dgView.Item(12, e.RowIndex).Value
            txtBankCode.Text = dgView.Item(13, e.RowIndex).Value
            txtBranchCode.Text = dgView.Item(14, e.RowIndex).Value
            txtLocationCode.Text = dgView.Item(15, e.RowIndex).Value
            txtNikashBranch.Text = dgView.Item(16, e.RowIndex).Value
            'strBankCode = dgView.Item(16, e.RowIndex).Value
            'intModno = dgView.Item(17, e.RowIndex).Value

            'LoaddgViewPaidData(strBankCode, paidslno, intModno)
            LoaddgViewPaidData(_strDepoCode, _ddSlno, _intModno)

            LoadAuthdata(_strDepoCode, _ddSlno, _intModno)

            'LoadAuthdata(strBankCode, paidslno, intModno)
            'dgView.Enabled = True

            PopulateCheckTotal()

            'DisableClear()

        End If
    End Sub

    Private Sub txtDDNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDDNo.KeyDown
        If e.KeyCode = Keys.Enter And txtDDNo.Text.Trim() <> "" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDDDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDDDate.KeyDown
        If e.KeyCode = Keys.Enter And txtDDNo.Text.Trim() <> "/  /" Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    
    Private Sub txtDraweeComm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweeComm.Validated
        If txtDraweeComm.Text.Trim() = "" Then
            txtDraweeComm.Text = "0"
        End If
    End Sub

   
    Private Sub txtDraweeVat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweeVat.Validated
        If txtDraweeVat.Text.Trim() = "" Then
            txtDraweeVat.Text = "0"
        End If
    End Sub

    Private Sub txtDraweePostageCharge_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweePostageCharge.Validated
        If txtDraweePostageCharge.Text.Trim() = "" Then
            txtDraweePostageCharge.Text = "0"
        End If
    End Sub

    Private Sub txtDraweeInstrumentCharge_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDraweeInstrumentCharge.Validated
        If txtDraweeInstrumentCharge.Text.Trim() = "" Then
            txtDraweeInstrumentCharge.Text = "0"
        End If
    End Sub

    Private Sub txtDraweeComm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeComm.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDraweeVat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeVat.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDraweePostageCharge_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweePostageCharge.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDraweeInstrumentCharge_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDraweeInstrumentCharge.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDDAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDDAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDDDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDDDate.Validating
        If CommonUtil.DateValidate(txtDDDate.Text) = False Then
            MessageBox.Show("Please enter valid date." + Environment.NewLine + "Valid date format: dd/mm/yyyy", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDraweeComm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDraweeComm.Validating
        If CommonUtil.DecValidate(txtDraweeComm.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDraweeVat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDraweeVat.Validating
        If CommonUtil.DecValidate(txtDraweeVat.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDraweePostageCharge_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDraweePostageCharge.Validating
        If CommonUtil.DecValidate(txtDraweePostageCharge.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDraweeInstrumentCharge_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDraweeInstrumentCharge.Validating
        If CommonUtil.DecValidate(txtDraweeInstrumentCharge.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtDDAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDDAmount.Validating
        If CommonUtil.DecValidate(txtDDAmount.Text) = False Then
            MessageBox.Show("Please enter valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub dgViewNotPaid_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewNotPaid.CellDoubleClick

        If btnAdd.Enabled = False Then
            Exit Sub
        End If

        If dgViewNotPaid.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgViewNotPaid.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value Then
            Exit Sub
        End If

        If dgViewNotPaid.SelectedRows.Count = 0 Then Exit Sub

        'dgViewPaid.AllowUserToAddRows = True

        'If (maxSelRow = dgViewNotPaid.Rows.Count - 1) Then



        ' --------------------------

        Dim flagDup As Boolean = False

        Dim citicharge As Decimal

        Dim citivat As Decimal

        Dim maxSelRow As Integer

        For Each nrow As DataGridViewRow In dgViewNotPaid.SelectedRows

            flagDup = False

            For Each prow As DataGridViewRow In dgViewPaid.Rows
                If prow.Cells(0).Value.ToString().Trim() = nrow.Cells(0).Value.ToString().Trim() Then
                    MessageBox.Show("Item already selected!!" + Environment.NewLine + _
                                    "Ref: " + nrow.Cells(0).Value.ToString() + Environment.NewLine + _
                                    "Check No: " + nrow.Cells(1).Value.ToString(), "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    flagDup = True
                    Exit For
                End If

            Next

            If flagDup = True Then
                Continue For
            End If


            dgViewPaid.Rows.Add()

            maxSelRow = dgViewPaid.Rows.Count - 1

            citicharge = NullHelper.ToDecNum(nrow.Cells(5).Value) / 1000 * NullHelper.ToDecNum(nrow.Cells(2).Value)

            citivat = NullHelper.ToDecNum(nrow.Cells(6).Value) / 1000 * NullHelper.ToDecNum(nrow.Cells(2).Value) * (NullHelper.ToDecNum(nrow.Cells(2).Value) / 100)

            dgViewPaid.Item(0, maxSelRow).Value = nrow.Cells(0).Value
            dgViewPaid.Item(1, maxSelRow).Value = nrow.Cells(1).Value
            dgViewPaid.Item(2, maxSelRow).Value = nrow.Cells(2).Value 'amount
            dgViewPaid.Item(3, maxSelRow).Value = nrow.Cells(3).Value
            dgViewPaid.Item(4, maxSelRow).Value = nrow.Cells(4).Value
            dgViewPaid.Item(5, maxSelRow).Value = nrow.Cells(5).Value 'Citibank Charge
            dgViewPaid.Item(6, maxSelRow).Value = nrow.Cells(6).Value 'Standard Charge
            dgViewPaid.Item(7, maxSelRow).Value = nrow.Cells(7).Value 'Citibank VAT
            dgViewPaid.Item(8, maxSelRow).Value = nrow.Cells(8).Value
            'dgViewPaid.Item(9, maxSelRow).Value = (dgViewNotPaid.SelectedRows.Item(0).Cells(2).Value - (dgViewNotPaid.SelectedRows.Item(0).Cells(5).Value + dgViewNotPaid.SelectedRows.Item(0).Cells(6).Value + dgViewNotPaid.SelectedRows.Item(0).Cells(7).Value))

            dgViewPaid.Item(9, maxSelRow).Value = NullHelper.ToDecNum(nrow.Cells(2).Value) - citicharge - citivat



            'dgViewNotPaid.Rows.Remove(nrow)
        Next

        'dgViewPaid.Rows(0).Selected = True
        'dgViewPaid.Rows(0).Selected = True
        'dgViewPaid.Rows(maxSelRow).Selected = False


        ' -------------------------

   
        PopulateCheckTotal()


    End Sub

    Private Sub txtDepoCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDepoCode.Validating
        If txtDepoCode.Text.Trim.Length > 5 Then
            MessageBox.Show("Not more than 5 digit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True

        End If
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim rowsCount, i As Integer

        rowsCount = dgView.Rows.Count

        If chkAll.Checked = True Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = True
            Next i
        ElseIf chkAll.Checked = False Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = False
            Next i
        End If

    End Sub

    Private Sub btnPaidSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaidSelected.Click
        Try

            If MessageBox.Show("Do you really want update all the selected dd status as paid?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim i As Integer

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_DD_Paid")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        If dgView.Rows(i).Cells(20).Value.ToString() = "U" Then
                            MessageBox.Show("Sl: " + dgView.Rows(i).Cells(1).Value.ToString() + Environment.NewLine + _
                                            "DD No: " + dgView.Rows(i).Cells(2).Value.ToString() + Environment.NewLine + _
                                            "Item Unauthorized.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Continue For

                        End If

                        If dgView.Rows(i).Cells(19).Value.ToString() = "P" Then
                            MessageBox.Show("Sl: " + dgView.Rows(i).Cells(1).Value.ToString() + Environment.NewLine + _
                                            "DD No: " + dgView.Rows(i).Cells(2).Value.ToString() + Environment.NewLine + _
                                            "Item already marked as paid.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Continue For

                        End If


                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@D_CODE", DbType.String, _strDepoCode)
                        db.AddInParameter(commProc, "@SLNO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(18).Value)
                        db.AddOutParameter(commProc, "@RET_MOD_NO", DbType.Int32, 5)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")

                        If result = 0 Then


                        ElseIf result = 1 Then

                            MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 3 Then
                            MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 4 Then
                            MessageBox.Show("Record not found", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 5 Then
                            MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 9 Then
                            MessageBox.Show("Already Paid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else
                            MessageBox.Show("Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If


                    End If


                Next i

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Dim strDepoCode As String = txtDepoCode.Text

        ClearFieldsAll()

        LoadDDData(strDepoCode)

        _formMode = FormTransMode.Add

        DisableAuth()
        btnPaid.Enabled = False
        DisableDelete()

    End Sub

    Private Sub txtBankCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankCode.Validated

        If txtBankCode.Text.Trim() = "" Then
            lblBankName.Text = ""
            txtBranchCode.Text = ""
            lblBranchName.Text = ""
            txtLocationCode.Text = ""
            lblLocationName.Text = ""

        End If

    End Sub

    Private Sub txtBranchCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBranchCode.Validated

        If txtBranchCode.Text.Trim() = "" Then
           
            lblBranchName.Text = ""
            

        End If

    End Sub

    Private Sub txtLocationCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocationCode.Validated

        If txtLocationCode.Text.Trim() = "" Then
           
            lblLocationName.Text = ""

        End If

    End Sub

    Private Sub txtNikashBranch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNikashBranch.Validated
        If txtNikashBranch.Text.Trim() = "" Then
            lblNikashBranchName.Text = ""
        End If
    End Sub
End Class