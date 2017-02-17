'
' Generate reversal file for flexcube
' Author: Iftekharul Alam Khan Lodi
' Since: 20-Feb-12
'

Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

'Imports Microsoft.Office.Interop

Imports System.IO.File
Imports System.IO.FileSystemInfo
Imports System.IO

Imports Microsoft.VisualBasic

Public Class FrmReversalGen

    Dim _formName As String = "DepositFlexReversalFile"
    Dim opt As SecForm = New SecForm(_formName)

    Private _Seq_No As Integer
    Private _Batch_No As String = ""
    Private _Ref_No As String = ""
    Dim _FileNm As String = ""
    Dim _ProcessSuccess As Boolean = False
    Dim _FileSuccess As Boolean = False
    Dim _PathReversal = Environment.CurrentDirectory + "\ReversalData"
    Dim _strFileName As String = ""


#Region "User defined Procedures"

    Private Sub PrepareReversalData()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Using conn As DbConnection = db.CreateConnection()

                conn.Open()

                Dim trans As DbTransaction = conn.BeginTransaction()




                ''''''''''''''''''''''''''''''''''''''' ok
                'Dim commProc1 As DbCommand = db.GetStoredProcCommand("CMS_Process_Revgenerate")

                Dim commProc1 As DbCommand = db.GetSqlStringCommand(" DECLARE @v_CASH_CR_TYPE	varchar(2)," _
  + "@v_REF_NO		varchar(10)," _
  + "@v_VALUE_DATE	datetime," _
  + "@v_REV_DATE		datetime," _
  + "@v_ACC_NO		varchar(16)," _
  + "@v_REFACC_NO	varchar(16)," _
  + "@v_CLIENT_CODE	char(15)," _
  + "@v_TOTAL		numeric(14,2)," _
  + "@v_DEPOSIT_TYPE	varchar(5)," _
  + "@v_D_CODE		varchar(15)," _
  + "@v_CHECKDS_NO	varchar(30)," _
  + "@vCTR_REF		varchar(22);" _
 + " UPDATE CCMSREF_TAB SET STATUS_ID=1, AUTHORIZE=1   " _
  + " WHERE D_CODE IN  " _
   + "(SELECT a.D_CODE    " _
    + " FROM CCMSREF_TAB a , DSCHEDULE b    " _
                + " WHERE" _
                + " A.D_CODE = B.D_CODE" _
    + " AND a.FILENAME IS NULL   " _
    + " AND b.DS_CODE IN (SELECT DS_CODE FROM CSCHEDULE)   " _
   + " )" _
 + " UPDATE CCMSREF_TAB SET STATUS_ID=1, AUTHORIZE=1   " _
  + " WHERE D_CODE IN  " _
   + " (SELECT a.D_CODE    " _
    + " FROM CCMSREF_TAB a , DSCHEDULE b " _
                + " WHERE" _
                + " A.D_CODE = B.D_CODE" _
    + " AND a.FILENAME IS NULL   " _
    + " AND Convert(date,a.REV_DATE)=Convert (date,b.SCHEDULE_DATE)" _
   + " ) " _
 + " DELETE FROM TMP_REVERSAL ;" _
 + " INSERT INTO TMP_REVERSAL(CR_TYPE,REF_NO,VALUE_DATE,LOCATION_CODE,REV_DATE," _
  + " ACC_NO,REFACC_NO,CLIENT_CODE,AMOUNT,DEPOSIT_TYPE," _
  + " DS_CODE, CHECKDS_NO, CUSTOMER_REF)" _
  + " SELECT c.CASH_CR_TYPE,a.REF_NO,a.VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.CITICASH_AMOUNT) as total,b.DEPOSIT_TYPE," _
                    + " '' as D_CODE ,'' CHECKDS_NO ,''" _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c" _
   + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND b.CITICASH_AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE" _
   + " AND a.FILENAME IS NULL" _
   + " AND c.CASH_CR_TYPE='L'" _
   + " AND (a.STATUS_ID=1)    " _
   + " AND (a.AUTHORIZE =1)     " _
   + " GROUP BY a.REV_DATE,a.REF_NO,b.LOCATION_CODE,b.CLIENT_CODE,a.VALUE_DATE,c.CASH_CR_TYPE, " _
    + " a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE  " _
  + " UNION ALL   " _
  + " SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.CITICASH_AMOUNT) as total,b.DEPOSIT_TYPE," _
   + " b.D_CODE ,isnull(b.D_CODE,'') CHECKDS_NO ,isnull(d.customer_ref,'')customer_ref" _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b" _
   + " LEFT OUTER JOIN ccash d on d.D_CODE=b.D_CODE,CLIENT c" _
   + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate())) " _
   + " AND b.CITICASH_AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE" _
   + " AND a.FILENAME IS NULL" _
   + " AND c.CASH_CR_TYPE='D' " _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1 )" _
   + " GROUP BY a.REV_DATE,a.REF_NO,b.CLIENT_CODE,a.VALUE_DATE,b.LOCATION_CODE,c.CASH_CR_TYPE," _
   + " a.ACC_NO,a.REFACC_NO ,b.D_CODE,b.DEPOSIT_TYPE,d.customer_ref " _
  + " UNION ALL " _
  + " SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,'000' as LOCATION_CODE,a.REV_DATE,a.ACC_NO,a.REFACC_NO," _
   + " b.CLIENT_CODE,b.CITICASH_AMOUNT as total,b.DEPOSIT_TYPE,left(rtrim(d.CASH_REF ),10) as D_CODE ,  d.D_CODE CHECKDS_NO ,d.customer_ref " _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c,ccash d" _
                + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate())) " _
   + " AND b.CITICASH_AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND d.D_CODE=b.D_CODE" _
   + " AND c.CASH_CR_TYPE='R'" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  )	" _
                + " UNION ALL" _
  + " SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,'000' as LOCATION_CODE,a.REV_DATE,a.ACC_NO,a.REFACC_NO," _
   + " b.CLIENT_CODE,b.CITICASH_AMOUNT as total,b.DEPOSIT_TYPE,left(rtrim(d.CASH_REF ),10) as D_CODE ,  d.D_CODE CHECKDS_NO ,d.customer_ref " _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c,ccash d" _
   + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate())) " _
   + " AND b.CITICASH_AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND d.D_CODE=b.D_CODE" _
   + " AND c.CASH_CR_TYPE='RD'" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  )	" _
 + " SELECT @vCTR_REF=CTR_REF FROM GENPRM;" _
 + " DECLARE curRev CURSOR FOR" _
  + " SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.CITICASH_AMOUNT) as TOTAL,b.DEPOSIT_TYPE," _
   + " substring(CONVERT(varchar(12), VALUE_DATE,112),3,8)as D_CODE, " _
   + " CONVERT(varchar,count(b.CITICASH_AMOUNT)) CHECKDS_NO" _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c" _
                + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND b.CITICASH_AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.CASH_CR_TYPE='T'" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  )" _
   + " GROUP BY a.REV_DATE,a.REF_NO,b.CLIENT_CODE,a.VALUE_DATE,c.CASH_CR_TYPE, " _
   + " a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE;" _
 + " OPEN curRev;" _
 + " FETCH NEXT FROM curRev " _
        + " INTO @v_CASH_CR_TYPE,@v_REF_NO,@v_VALUE_DATE,@v_REV_DATE," _
   + " @v_ACC_NO,@v_REFACC_NO,@v_CLIENT_CODE,@v_TOTAL,@v_DEPOSIT_TYPE," _
   + " @v_D_CODE," _
   + " @v_CHECKDS_NO;" _
 + " WHILE @@FETCH_STATUS=0 " _
                    + " BEGIN" _
  + " INSERT INTO TMP_REVERSAL(CR_TYPE,REF_NO,VALUE_DATE,LOCATION_CODE,REV_DATE," _
   + " ACC_NO,REFACC_NO,CLIENT_CODE,AMOUNT,DEPOSIT_TYPE," _
   + " DS_CODE, CHECKDS_NO, CUSTOMER_REF, CTR_REF)" _
   + " VALUES(@v_CASH_CR_TYPE,@v_REF_NO,@v_VALUE_DATE,'000',@v_REV_DATE," _
    + " @v_ACC_NO,@v_REFACC_NO,@v_CLIENT_CODE,@v_TOTAL,@v_DEPOSIT_TYPE," _
    + " @v_D_CODE,@v_CHECKDS_NO,'',@vCTR_REF);" _
  + " UPDATE CCMSREF_TAB SET CTR_REF=@vCTR_REF" _
   + " FROM CCMSREF_TAB a " _
   + " INNER JOIN DSCHEDULE b ON a.D_CODE=b.D_CODE" _
   + " INNER JOIN CLIENT c ON c.CLIENT_CODE=b.CLIENT_CODE " _
                    + " WHERE" _
    + " a.REV_DATE = @v_REV_DATE" _
    + " AND b.CITICASH_AMOUNT>0 " _
    + " AND a.FILENAME IS NULL " _
    + " AND c.CASH_CR_TYPE='T'" _
    + " AND ( a.STATUS_ID=1) AND ( a.AUTHORIZE =1)" _
    + " AND a.REF_NO=@v_REF_NO" _
    + " AND a.VALUE_DATE=@v_VALUE_DATE" _
    + " AND a.ACC_NO=@v_ACC_NO" _
    + " AND a.REFACC_NO= @v_REFACC_NO" _
    + " AND b.CLIENT_CODE=@v_CLIENT_CODE" _
    + " AND b.DEPOSIT_TYPE=@v_DEPOSIT_TYPE" _
+ " SELECT @vCTR_REF=@vCTR_REF+1;" _
  + " FETCH NEXT FROM curRev " _
   + " INTO @v_CASH_CR_TYPE,@v_REF_NO,@v_VALUE_DATE,@v_REV_DATE," _
    + " @v_ACC_NO,@v_REFACC_NO,@v_CLIENT_CODE,@v_TOTAL,@v_DEPOSIT_TYPE," _
    + " @v_D_CODE," _
    + " @v_CHECKDS_NO;" _
                + " End" _
 + " UPDATE GENPRM SET CTR_REF=@vCTR_REF;" _
 + " CLOSE curRev;" _
 + " DEALLOCATE curRev;" _
 + " INSERT INTO TMP_REVERSAL( CR_TYPE,REF_NO,VALUE_DATE,LOCATION_CODE,REV_DATE, " _
  + " ACC_NO,REFACC_NO,CLIENT_CODE,AMOUNT,b.DEPOSIT_TYPE," _
  + " b.DS_CODE, CHECKDS_NO, CUSTOMER_REF)" _
  + " SELECT c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.citicheck_AMOUNT) as total,b.DEPOSIT_TYPE," _
                    + " '' as D_CODE , '' CHECKDS_NO ,'' CUSTOMER_REF" _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c " _
   + " WHERE " _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))	" _
   + " AND b.citicheck_AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE       " _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.SPEED_CR_TYPE='L'" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  ) " _
   + " GROUP BY a.REV_DATE,b.LOCATION_CODE,a.REF_NO,b.CLIENT_CODE,a.VALUE_DATE,c.SPEED_CR_TYPE," _
   + " a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE " _
  + " UNION ALL " _
  + " SELECT c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(d.AMOUNT) as total,b.DEPOSIT_TYPE," _
   + " b.D_CODE , b.D_CODE CHECKDS_NO, ISNULL(cs.CUSTOMER_REF,'') customer_ref" _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,csd_det d,CLIENT c, csd cs" _
   + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND b.citicheck_AMOUNT>0 " _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND a.D_CODE=d.D_CODE " _
   + " AND d.D_CODE=cs.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND c.SPEED_CR_TYPE='D'" _
   + " AND a.FILENAME IS NULL" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  )" _
   + " GROUP BY a.REV_DATE,a.REF_NO,b.DS_CODE,b.CLIENT_CODE,a.VALUE_DATE,c.SPEED_CR_TYPE,b.LOCATION_CODE, " _
   + " a.ACC_NO,a.REFACC_NO,b.D_CODE,b.DEPOSIT_TYPE,cs.CUSTOMER_REF " _
  + " UNION ALL " _
  + " SELECT c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,'000' as LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.citicheck_AMOUNT) as total,b.DEPOSIT_TYPE," _
   + " substring(CONVERT(varchar(10), VALUE_DATE,112),3,8) , '' CHECKDS_NO ,'' " _
   + " FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c " _
   + " WHERE " _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND b.citicheck_AMOUNT>0 " _
   + " AND a.D_CODE=b.D_CODE" _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.SPEED_CR_TYPE='T'" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  ) " _
   + " GROUP BY a.REV_DATE,b.CLIENT_CODE,a.VALUE_DATE,a.REF_NO,c.SPEED_CR_TYPE, " _
   + " a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE " _
  + " UNION ALL " _
  + " SELECT  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,D.AMOUNT,b.DEPOSIT_TYPE," _
   + " d.check_no , b.D_CODE CHECKDS_NO  ,cs.Customer_Ref " _
   + " FROM CCMSREF_TAB a,CLIENT c,DSCHEDULE b,csd_det d,csd cs" _
   + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate())) " _
   + " AND d.AMOUNT>0 " _
   + " AND a.D_CODE=b.D_CODE " _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.D_CODE=d.D_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.SPEED_CR_TYPE='C'" _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  ) " _
   + " AND d.D_CODE=cs.D_CODE" _
  + " UNION ALL    " _
  + " SELECT  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,D.AMOUNT,b.DEPOSIT_TYPE," _
   + " d.CHECK_NO  ,  b.D_CODE CHECKDS_NO ,d.Customer_Ref " _
   + " FROM CCMSREF_TAB a,CLIENT c,DSCHEDULE b,csd_det d " _
   + " WHERE " _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND d.AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE " _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.D_CODE=d.D_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.SPEED_CR_TYPE='RD' " _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  ) " _
  + " UNION ALL	" _
    + " SELECT  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,D.AMOUNT,b.DEPOSIT_TYPE," _
   + " d.CHECK_NO  ,  b.D_CODE CHECKDS_NO ,d.Customer_Ref " _
   + " FROM CCMSREF_TAB a,CLIENT c,DSCHEDULE b,csd_det d " _
                + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND d.AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE " _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.D_CODE=d.D_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.SPEED_CR_TYPE='RC' " _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  ) " _
                + " UNION ALL" _
  + " SELECT  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE," _
   + " a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,D.AMOUNT,b.DEPOSIT_TYPE," _
   + " left(d.CHECK_REF,10)  ,  b.D_CODE CHECKDS_NO ,d.Customer_Ref " _
   + " FROM CCMSREF_TAB a,CLIENT c,DSCHEDULE b,csd_det d " _
                + " WHERE" _
   + " CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))" _
   + " AND d.AMOUNT>0" _
   + " AND a.D_CODE=b.D_CODE " _
   + " AND b.CLIENT_CODE=c.CLIENT_CODE " _
   + " AND a.D_CODE=d.D_CODE " _
   + " AND a.FILENAME IS NULL " _
   + " AND c.SPEED_CR_TYPE='R' " _
   + " AND ( a.STATUS_ID=1 )" _
   + " AND ( a.AUTHORIZE =1  ) " _
   + " ORDER BY a.REF_NO	")

                commProc1.Parameters.Clear()

                db.AddParameter(commProc1, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                Dim result As Integer

                commProc1.CommandTimeout = 3600
exe1:
                Try
                    db.ExecuteNonQuery(commProc1, trans)
                Catch ex As TimeoutException
                    commProc1.CommandTimeout += commProc1.CommandTimeout
                    GoTo exe1
                End Try

                result = db.GetParameterValue(commProc1, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                ''''''''''''''''''''''''''''''''''''''''

                Dim commProc12 As DbCommand = db.GetStoredProcCommand("CMS_TmpReversal_GetListInvDs")

                Dim dt As New DataTable
                commProc12.CommandTimeout = 3600
exe12:
                Try
                    dt = db.ExecuteDataSet(commProc12, trans).Tables(0)
                Catch ex As TimeoutException
                    commProc12.CommandTimeout += commProc12.CommandTimeout
                    GoTo exe12
                End Try


                If dt.Rows.Count > 0 Then
                    'Dim commProcRefNo As DbCommand = db.GetStoredProcCommand("GetRefNoWithNo_DS_Code")
                    'Dim dtRefNo = db.ExecuteDataSet(commProcRefNo, trans).Tables(0)
                    'MessageBox.Show("No Deposit Code found for Ref No:" + dtRefNo.Rows(0)(0).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    trans.Rollback()
                    MessageBox.Show("Please check refno which is blank for some customers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If


                '''''''''''''''''''''''''''''''''''''''ok

                Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_Process_DepositUpdate")

                commProc2.Parameters.Clear()

                db.AddParameter(commProc2, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                commProc2.CommandTimeout = 3600
exe2:
                Try
                    db.ExecuteNonQuery(commProc2, trans)
                Catch ex As TimeoutException
                    commProc2.CommandTimeout += commProc2.CommandTimeout
                    GoTo exe2
                End Try

                result = db.GetParameterValue(commProc2, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                ''''''''''''''''''''''''''''''''ok


                Dim commProc3 As DbCommand = db.GetStoredProcCommand("CMS_Process_RevBatch")

                commProc3.Parameters.Clear()


                db.AddOutParameter(commProc3, "@BATCH_NO", DbType.String, 4)

                db.AddParameter(commProc3, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                commProc3.CommandTimeout = 3600
exe3:
                Try
                    db.ExecuteNonQuery(commProc3, trans)
                Catch ex As TimeoutException
                    commProc3.CommandTimeout += commProc3.CommandTimeout
                    GoTo exe3
                End Try

                result = db.GetParameterValue(commProc3, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If


                _Batch_No = db.GetParameterValue(commProc3, "@BATCH_NO")


                '''''''''''''''''''''''''''''''''''''''ok
                FlexFileGen(db, trans)

                '''''''''''''''''''''''''''''''''''''''

                If _FileSuccess = False Then
                    trans.Rollback()
                    MessageBox.Show("File Generation Aborted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                '----------------------------------------------

                Dim commProc4 As DbCommand = db.GetStoredProcCommand("CMS_Process_ReversalUpdateRef")

                db.AddInParameter(commProc4, "@FILENAME", DbType.String, _FileNm)
                db.AddInParameter(commProc4, "@REV_DATE", DbType.DateTime, dtpDate.Value)
                db.AddInParameter(commProc4, "@BATCH_NO", DbType.String, _Batch_No)

                db.AddParameter(commProc4, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)
                commProc4.CommandTimeout = 3600
exe4:
                Try
                    db.ExecuteNonQuery(commProc4, trans)
                Catch ex As TimeoutException
                    commProc4.CommandTimeout += commProc4.CommandTimeout
                    GoTo exe4
                End Try

                result = db.GetParameterValue(commProc4, "@PROC_RET_VAL")

                If result > 0 Then
                    trans.Rollback()
                    MessageBox.Show("Process Error. Level 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                trans.Commit()
                _ProcessSuccess = True

            End Using



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub FlexFileGen(ByRef db As SqlDatabase, ByRef trans As DbTransaction)


        Dim brcode As String       'for branch
        Dim Valuedate As String       'for date format yyyymmdd
        'Dim serial As Currency     'to count serial

        Dim sourcecode As String

        Dim j As Integer = 1

        brcode = "G01"
        sourcecode = brcode + _Batch_No
        _FileNm = "F" + brcode + _Batch_No

        Valuedate = Format(Date.Now, "dd- MMMM - yy")
        'serial = 0

        _FileNm = _FileNm + ".csv"
        Dim owrite As System.IO.StreamWriter

        If Not Directory.Exists(_PathReversal) Then
            Directory.CreateDirectory(_PathReversal)
        End If


        File.Copy(Environment.CurrentDirectory + "\header.csv", _PathReversal + "\" + _FileNm, True)

        owrite = New System.IO.StreamWriter(_PathReversal + "\" + _FileNm, True)


        Dim sLine As String

        Dim ExlWS As New ArrayList()

        Dim checkNo As String = ""
        Dim checkRef As String = ""
        Dim addTextCCASH As String = ""
        Dim addSlipTextCSD As String = ""
        Dim addCheckTextCSD_Det As String = ""
        Dim locationName As String = ""

        Try

            'Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            'Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpReversal_GetFlexDrDetail")

            Dim commProc As DbCommand = db.GetSqlStringCommand(" SELECT REV_DATE,DEPOSIT_TYPE,sum(AMOUNT)as credtotal," _
            + "REF_NO, REFACC_NO" _
            + " FROM TMP_REVERSAL" _
    + " WHERE REV_DATE<=@REV_DATE" _
  + " GROUP BY  REV_DATE,REF_NO,REFACC_NO,DEPOSIT_TYPE")

            db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, dtpDate.Value)

            Dim dt As DataTable = New DataTable
            commProc.CommandTimeout = 3600
exe1:
            Try
                dt = db.ExecuteDataSet(commProc, trans).Tables(0)
            Catch ex As TimeoutException
                commProc.CommandTimeout += commProc.CommandTimeout
                GoTo exe1
            End Try

            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                'Dim checkCount As Integer = 0

                'Dim dtCheckNoCheckRef As DataTable = New DataTable()

                'If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) <> "Cash" And _
                '        (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                '        dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                '    Dim commProcCheckNoCheckRef As DbCommand = db.GetStoredProcCommand("CMS_GetCheckNoCheckRef")

                'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                'db.AddInParameter(commProcCheckNoCheckRef, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))

                'Else
                '    db.AddInParameter(commProcCheckNoCheckRef, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                'End If

                'dtCheckNoCheckRef = db.ExecuteDataSet(commProcCheckNoCheckRef, trans).Tables(0)

                'If (dtCheckNoCheckRef.Rows.Count > 0) Then
                '    checkCount = dtCheckNoCheckRef.Rows.Count - 1
                'End If
                'End If

                'Dim commProcAddTextCCASH As DbCommand = db.GetStoredProcCommand("CMS_GetAddTextCCASH")
                'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then

                'db.AddInParameter(commProcAddTextCCASH, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))

                'Else
                '    db.AddInParameter(commProcAddTextCCASH, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                'End If

                'Dim dtAddTextCCASH As DataTable = New DataTable()
                'If (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                '        dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                '    dtAddTextCCASH = db.ExecuteDataSet(commProcAddTextCCASH, trans).Tables(0)

                '    If (dtAddTextCCASH.Rows.Count > 0) Then
                '        addTextCCASH = dtAddTextCCASH.Rows(0)(0).ToString
                '        addTextCCASH = addTextCCASH.Replace(vbNewLine, " ")
                '    Else
                '        addTextCCASH = ""
                '    End If
                'End If

                'Dim dtAddSlipTextCSD As DataTable

                'If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) <> "Cash" And _
                '        (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                '        dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                '    Dim commProcAddSlipTextCSD As DbCommand = db.GetStoredProcCommand("CMS_GetAddSlipTextCSD")
                '    'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                '    db.AddInParameter(commProcAddSlipTextCSD, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))
                '    'Else
                '    '    db.AddInParameter(commProcAddSlipTextCSD, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                '    'End If
                '    dtAddSlipTextCSD = db.ExecuteDataSet(commProcAddSlipTextCSD, trans).Tables(0)

                '    If (dtAddSlipTextCSD.Rows.Count > 0) Then
                '        addSlipTextCSD = dtAddSlipTextCSD.Rows(0)(0).ToString
                '        addSlipTextCSD = addSlipTextCSD.Replace(vbNewLine, " ")
                '    Else
                '        addSlipTextCSD = ""
                '    End If

                'End If

                'Dim commProcGetLocationName As DbCommand = db.GetStoredProcCommand("CMS_GetLocationName")
                'db.AddInParameter(commProcGetLocationName, "@Location_Code", DbType.String, dt.Rows(i)("Location_Code"))

                'Dim dtGetLocationName As DataTable = db.ExecuteDataSet(commProcGetLocationName, trans).Tables(0)
                'If (dtGetLocationName.Rows.Count > 0) Then
                '    locationName = dtGetLocationName.Rows(0)(0).ToString()
                'Else
                '    locationName = ""
                'End If

                'Dim cCount As Integer = Convert.ToInt32(dt2.Rows(0)(0).ToString())

                'For k = 0 To checkCount

                '    Dim dtAddCheckTextCSD_Det As DataTable

                '    If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) <> "Cash" And checkCount >= 0 And _
                '        (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                '        dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then
                '        Dim commProcAddCheckTextCSD_Det As DbCommand = db.GetStoredProcCommand("CMS_GetAddCheckTextCSD_Det")

                'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                'db.AddInParameter(commProcAddCheckTextCSD_Det, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))
                'Else
                '    db.AddInParameter(commProcAddCheckTextCSD_Det, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                'End If

                'db.AddInParameter(commProcAddCheckTextCSD_Det, "@CHECK_NO", DbType.String, dtCheckNoCheckRef.Rows(k)(0).ToString())

                'dtAddCheckTextCSD_Det = db.ExecuteDataSet(commProcAddCheckTextCSD_Det, trans).Tables(0)
                'If (dtAddCheckTextCSD_Det.Rows.Count > 0) Then
                '    addCheckTextCSD_Det = dtAddCheckTextCSD_Det.Rows(0)(0).ToString()
                '    addCheckTextCSD_Det = addCheckTextCSD_Det.Replace(vbNewLine, " ")
                'Else
                '    addCheckTextCSD_Det = ""
                'End If

                'checkNo = dtCheckNoCheckRef.Rows(k)(0).ToString
                'checkRef = dtCheckNoCheckRef.Rows(k)(1).ToString

                '    End If

                ExlWS.Add(_Batch_No)  'BATCH_NO
                ExlWS.Add("G01")   'BRANCH_CODE
                ExlWS.Add("056")  'DEPARTMENT_CODE
                ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                ExlWS.Add(j.ToString("000000"))    'CURR_NO
                ExlWS.Add("BDT")   'CCY_CD
                ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                ExlWS.Add(Format(dt.Rows(i)("credtotal"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                ExlWS.Add("G010009198080001")   '"G010009155160001" '"Acc_Name '""
                ExlWS.Add(dt.Rows(i)("REFACC_NO").ToString().Trim().Substring(0, 3))   'ACCOUNT_BRANCH
                If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                    ExlWS.Add("355")    'TXN_CODE
                Else
                    ExlWS.Add("063")  'TXN_CODE
                End If
                ExlWS.Add("D")   'DR_CR
                ExlWS.Add(Format(dt.Rows(i)("credtotal"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                ExlWS.Add("1")  'EXCH_RATE
                ExlWS.Add(Format(dt.Rows(i)("REV_DATE"), "dd- MMMM - yy"))   '"" 'VALUE_DATE

                'If Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RD" Then

                '    ExlWS.Add(dt.Rows(i)("CUSTOMER_REF").ToString())

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RC" Then

                '    ExlWS.Add(checkRef)

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "D" Then

                '    ExlWS.Add(dt.Rows(i)("DS_CODE").ToString())

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "C" Then

                '    ExlWS.Add(checkNo)
                'Else
                ExlWS.Add(dt.Rows(i)("REF_NO").ToString())   'INSTRUMENT_NO
                'End If
                ExlWS.Add("") 'REL_CUST
                'If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                '    ExlWS.Add("Cash")     ' 'ADDL_TEXT
                'Else
                '    ExlWS.Add("Check")  ' 'ADDL_TEXT
                'End If

                If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                    ExlWS.Add("Cash")
                Else
                    ExlWS.Add("Check")
                End If

                'If Trim(dt.Rows(i)("CR_TYPE").ToString()) = "C" Then
                '    ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString()) + " INV Code " + addCheckTextCSD_Det) ' 'ADDL_TEXT

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RC" Then
                '    ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " Check No " + checkNo + " INV Code " + addCheckTextCSD_Det)

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "R" Then
                '    ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString())) ' 'ADDL_TEXT

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "D" Then

                '    If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                '        ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + "" + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString()) + " INV Code " + addTextCCASH) ' 'ADDL_TEXT
                '    Else
                '        ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + "" + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString()) + " INV Code " + addSlipTextCSD) ' 'ADDL_TEXT
                '    End If

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RD" Then

                '    If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                '        ExlWS.Add("Deposit On " + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " INV Code " + addTextCCASH) ' 'ADDL_TEXT
                '    Else
                '        ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " INV Code " + addSlipTextCSD) ' 'ADDL_TEXT
                '    End If

                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "L" Then
                '    ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy")) ' 'ADDL_TEXT
                'ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "T" Then

                '    If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                '        ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + Space(1) + "SLIPCOUNT " + dt.Rows(i)("CHECKDS_NO").ToString()) ' 'ADDL_TEXT
                '    Else
                '        ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy")) ' 'ADDL_TEXT
                '    End If

                'Else
                '    ExlWS.Add(locationName.Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + IIf(dt.Rows(i)("CHECKDS_NO") Is DBNull.Value, "", dt.Rows(i)("DS_CODE").ToString())) ' 'ADDL_TEXT
                'End If

                ExlWS.Add("")  'comp_mis_1
                ExlWS.Add("")  'comp_mis_2
                ExlWS.Add("")  'txn_mis_1
                ExlWS.Add("")  'txn_mis_3
                ExlWS.Add("")  'txn_mis_4
                ExlWS.Add("")  'txn_mis_6
                ExlWS.Add("~~END~~")
                'Next k
                'increament of variables for row and currno
                'i = i + 1
                j = j + 1

                sLine = ""
                sLine = ExlWS.Item(0).ToString()
                For n = 1 To 24
                    sLine = sLine + "," + ExlWS.Item(n).ToString()
                Next n

                owrite.WriteLine(sLine)

            Next i

            ''''''''''''''''''''''''''''''''''''

            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_TmpReversal_GetFlexCrDetail")

            db.AddInParameter(commProc2, "@REV_DATE", DbType.DateTime, dtpDate.Value)
            commProc2.CommandTimeout = 3600
exe2:
            Try
                dt = db.ExecuteDataSet(commProc2, trans).Tables(0)
            Catch ex As TimeoutException
                commProc2.CommandTimeout += commProc2.CommandTimeout
                GoTo exe2
            End Try




            For i = 0 To dt.Rows.Count - 1
                ExlWS.Clear()

                Dim checkCount As Integer = 0

                Dim dtCheckNoCheckRef As DataTable = New DataTable

                If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Check" And _
                (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                 dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                    'Dim commProcCheckNoCheckRef As DbCommand = db.GetStoredProcCommand("CMS_GetCheckNoCheckRef")
                    Dim commProcCheckNoCheckRef As DbCommand = db.GetSqlStringCommand("select check_No,CHECK_REF from CSD_DET where D_CODE=@D_CODE and check_No=@check_no")
                    'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                    db.AddInParameter(commProcCheckNoCheckRef, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))
                    db.AddInParameter(commProcCheckNoCheckRef, "@check_no", DbType.String, dt.Rows(i)("DS_CODE"))
                    'Else
                    '    db.AddInParameter(commProcCheckNoCheckRef, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                    'End If
                    dtCheckNoCheckRef = db.ExecuteDataSet(commProcCheckNoCheckRef, trans).Tables(0)
                    If (dtCheckNoCheckRef.Rows.Count > 0) Then
                        checkCount = dtCheckNoCheckRef.Rows.Count - 1
                    End If
                    'End If

                ElseIf (dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" And _
                (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                 dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                    Dim commProcAddTextCCASH As DbCommand = db.GetStoredProcCommand("CMS_GetAddTextCCASH")
                    'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                    db.AddInParameter(commProcAddTextCCASH, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))
                    'Else
                    '    db.AddInParameter(commProcAddTextCCASH, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                    'End If

                    Dim dtAddTextCCASH As DataTable = db.ExecuteDataSet(commProcAddTextCCASH, trans).Tables(0)

                    If (dtAddTextCCASH.Rows.Count > 0) Then
                        addTextCCASH = dtAddTextCCASH.Rows(0)(0).ToString
                        addTextCCASH = addTextCCASH.Replace(vbNewLine, " ")
                    Else
                        addTextCCASH = ""
                    End If
                End If

                Dim dtAddSlipTextCSD As DataTable

                If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Check" And _
                (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                 dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                    Dim commProcAddSlipTextCSD As DbCommand = db.GetStoredProcCommand("CMS_GetAddSlipTextCSD")
                    'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                    db.AddInParameter(commProcAddSlipTextCSD, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))
                    'Else
                    '    db.AddInParameter(commProcAddSlipTextCSD, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                    'End If
                    dtAddSlipTextCSD = db.ExecuteDataSet(commProcAddSlipTextCSD, trans).Tables(0)

                    If (dtAddSlipTextCSD.Rows.Count > 0) Then
                        addSlipTextCSD = dtAddSlipTextCSD.Rows(0)(0).ToString
                        addSlipTextCSD = addSlipTextCSD.Replace(vbNewLine, " ")
                    Else
                        addSlipTextCSD = ""
                    End If

                End If


                'Dim cCount As Integer = Convert.ToInt32(dt2.Rows(0)(0).ToString())

                For k = 0 To checkCount

                    Dim dtAddCheckTextCSD_Det As DataTable = New DataTable

                    If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Check" And checkCount >= 0 And _
                (dt.Rows(i)("CR_TYPE").ToString() = "D" Or dt.Rows(i)("CR_TYPE").ToString() = "C" Or _
                 dt.Rows(i)("CR_TYPE").ToString() = "RD" Or dt.Rows(i)("CR_TYPE").ToString() = "RC") Then

                        Dim commProcAddCheckTextCSD_Det As DbCommand = db.GetStoredProcCommand("CMS_GetAddCheckTextCSD_Det")
                        'If Trim(dt.Rows(i)("CR_TYPE").ToString()) <> "D" Then
                        db.AddInParameter(commProcAddCheckTextCSD_Det, "@D_CODE", DbType.String, dt.Rows(i)("CHECKDS_NO"))
                        'Else
                        '    db.AddInParameter(commProcAddCheckTextCSD_Det, "@D_CODE", DbType.String, dt.Rows(i)("DS_CODE"))
                        'End If
                        If (dtCheckNoCheckRef.Rows.Count > 0) Then
                            db.AddInParameter(commProcAddCheckTextCSD_Det, "@CHECK_NO", DbType.String, dtCheckNoCheckRef.Rows(k)(0).ToString())

                            dtAddCheckTextCSD_Det = db.ExecuteDataSet(commProcAddCheckTextCSD_Det, trans).Tables(0)
                        End If

                        If (dtAddCheckTextCSD_Det.Rows.Count > 0) Then
                            addCheckTextCSD_Det = dtAddCheckTextCSD_Det.Rows(0)(0).ToString()
                            addCheckTextCSD_Det = addCheckTextCSD_Det.Replace(vbNewLine, " ")
                        Else
                            addCheckTextCSD_Det = ""
                        End If                  

                        If (dtCheckNoCheckRef.Rows.Count > 0) Then
                            checkNo = dtCheckNoCheckRef.Rows(k)(0).ToString
                            checkRef = dtCheckNoCheckRef.Rows(k)(1).ToString
                        End If

                    End If

                    ExlWS.Add(_Batch_No)  'BATCH_NO
                    ExlWS.Add("G01")   'BRANCH_CODE
                    ExlWS.Add("056")  'DEPARTMENT_CODE
                    ExlWS.Add(sourcecode)   'FileNm 'SOURCE_CODE
                    ExlWS.Add(j.ToString("000000"))    'CURR_NO
                    ExlWS.Add("BDT")   'CCY_CD
                    ExlWS.Add(Valuedate)  '"" 'INITIATION_DATE
                    ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))    'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
                    ExlWS.Add(dt.Rows(i)("ACC_NO").ToString())   '"G010009155160001" '"Acc_Name '""
                    ExlWS.Add(dt.Rows(i)("ACC_NO").ToString().Trim().Substring(0, 3))   'ACCOUNT_BRANCH
                    If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                        ExlWS.Add("355")    'TXN_CODE
                    Else
                        ExlWS.Add("063")  'TXN_CODE
                    End If
                    ExlWS.Add("C")   'DR_CR
                    ExlWS.Add(Format(dt.Rows(i)("AMOUNT"), "###########.####"))   'Trim(rs!Amount) 'LCY_EQUIVALENT
                    ExlWS.Add("1")  'EXCH_RATE
                    ExlWS.Add(Format(dt.Rows(i)("REV_DATE"), "dd- MMMM - yy"))   '"" 'VALUE_DATE

                    If Trim(dt.Rows(i)("CR_TYPE").ToString()) = "T" _
                        And Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then

                        ExlWS.Add(dt.Rows(i)("CTR_REF").ToString())   'INSTRUMENT_NO

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RD" Then

                        ExlWS.Add(dt.Rows(i)("CUSTOMER_REF").ToString())

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RC" Then

                        ExlWS.Add(checkRef)

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "D" Then

                        ExlWS.Add(dt.Rows(i)("DS_CODE").ToString())

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "C" Then
                        'If (checkNo.Substring(0, 1) = "0") Then
                        '    ExlWS.Add("'" + checkNo)
                        'Else
                        ExlWS.Add(checkNo)
                        'End If

                    Else
                        ExlWS.Add(dt.Rows(i)("DS_CODE").ToString())   'INSTRUMENT_NO

                    End If



                    ExlWS.Add("") 'REL_CUST
                    If Trim(dt.Rows(i)("CR_TYPE").ToString()) = "C" Then
                        ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString()) + " INV Code " + addCheckTextCSD_Det) ' 'ADDL_TEXT

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RC" Then
                        ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + "Check No " + checkNo + " INV Code " + addCheckTextCSD_Det)

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "R" Then
                        ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString())) ' 'ADDL_TEXT
                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "D" Then

                        If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                            ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + "" + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString()) + " INV Code " + addTextCCASH) ' 'ADDL_TEXT
                        Else
                            ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + "" + " REF " + IIf(dt.Rows(i)("CUSTOMER_REF") Is DBNull.Value, "", dt.Rows(i)("CUSTOMER_REF").ToString()) + " INV Code " + addSlipTextCSD) ' 'ADDL_TEXT
                        End If

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "RD" Then

                        If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                            ExlWS.Add("Deposit On " + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " INV Code " + addTextCCASH) ' 'ADDL_TEXT
                        Else
                            ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + dt.Rows(i)("CHECKDS_NO").ToString() + " INV Code " + addSlipTextCSD) ' 'ADDL_TEXT
                        End If

                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "L" Then
                        ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy")) ' 'ADDL_TEXT
                    ElseIf Trim(dt.Rows(i)("CR_TYPE").ToString()) = "T" Then

                        If Trim(dt.Rows(i)("DEPOSIT_TYPE").ToString()) = "Cash" Then
                            ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + Space(1) + "SLIPCOUNT " + dt.Rows(i)("CHECKDS_NO").ToString()) ' 'ADDL_TEXT
                        Else
                            ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy")) ' 'ADDL_TEXT
                        End If

                    Else
                        ExlWS.Add(dt.Rows(i)("LOCATION_NAME").ToString().Replace(",", "").Replace("'", "").Replace("-", "").Replace(".", "") + Space(2) + Format(dt.Rows(i)("VALUE_DATE"), "ddMMMMyy") + " DS NO " + IIf(dt.Rows(i)("CHECKDS_NO") Is DBNull.Value, "", dt.Rows(i)("DS_CODE").ToString())) ' 'ADDL_TEXT
                    End If
                    ExlWS.Add("")  'comp_mis_1
                    ExlWS.Add("")  'comp_mis_2
                    ExlWS.Add("")  'txn_mis_1
                    ExlWS.Add("")  'txn_mis_3
                    ExlWS.Add("")  'txn_mis_4
                    ExlWS.Add("")  'txn_mis_6
                    ExlWS.Add("~~END~~")
                Next k



                'increament of variables for row and currno
                'i = i + 1
                j = j + 1

                sLine = ""
                sLine = ExlWS.Item(0).ToString()
                For n = 1 To 24
                    sLine = sLine + "," + ExlWS.Item(n).ToString()
                Next n

                owrite.WriteLine(sLine)

            Next i

            ''*****************************************************************************************
            ''End All Transaction
            ''*****************************************************************************************

            sLine = ""
            sLine = "~~END~~" + "," + "~~END~~"
            owrite.WriteLine(sLine)

            owrite.Close()

            _FileSuccess = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            If Not (owrite Is Nothing) Then
                owrite.Close()
            End If

        End Try


    End Sub


    Private Sub LoadReversalData()
        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_CCMSRefTab_GetReversalData")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@REV_DATE", DbType.DateTime, dtpDate.Value)
            commProc.CommandTimeout = 3600
exe1:
            Try
                dt = db.ExecuteDataSet(commProc).Tables(0)
            Catch ex As TimeoutException
                commProc.CommandTimeout += commProc.CommandTimeout
                GoTo exe1
            End Try


            dgView.Rows.Clear()

            If dt.Rows.Count > 0 Then

                dgView.AllowUserToAddRows = True
                For i = 0 To dt.Rows.Count - 1
                    If (i = dgView.Rows.Count - 1) Then
                        dgView.Rows.Add()
                    End If


                    dgView.Item(0, i).Value = dt.Rows(i)("REF_NO")
                    dgView.Item(1, i).Value = NullHelper.DateToString(dt.Rows(i)("REV_DATE"))
                    dgView.Item(2, i).Value = dt.Rows(i)("AMOUNT")
                    dgView.Item(3, i).Value = NullHelper.DateToString(dt.Rows(i)("VALUE_DATE"))
                    dgView.Item(4, i).Value = dt.Rows(i)("D_CODE")
                    dgView.Item(5, i).Value = dt.Rows(i)("ACC_NAME")


                Next
                dgView.AllowUserToAddRows = False

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        _FileSuccess = False

        'btnViewReversalData.Enabled = False

        PrepareReversalData()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Style = ProgressBarStyle.Continuous
        btnViewReversalData.Enabled = True

        If _ProcessSuccess = True Then
            MessageBox.Show("! Process Completed !" + _
                            Environment.NewLine + "File has been created for Flexcube", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Process.Start("explorer.exe", "/select," & _PathReversal & "\" & _FileNm)

        End If

        LoadReversalData()

    End Sub



    Private Sub btnReversalGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReversalGenerate.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub FrmReversalGen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        dtpDate.Value = DateTime.Today
        LoadReversalData()
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        LoadReversalData()
    End Sub

    Private Sub btnViewReversalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReversalData.Click

        _strFileName = InputBox("Please enter filename", "CCMS", _strFileName)
        If _strFileName.Trim() <> "" Then
            Dim rd As New crReversal()


            rd.SetParameterValue("paramFileName", _strFileName)
            rd.SetParameterValue("paramFlexGenDate", dtpDate.Value)

            Dim frmRptViewer As New FrmReportViewer()

            frmRptViewer.SetReport(rd)


            frmRptViewer.Show()
        End If


    End Sub
End Class