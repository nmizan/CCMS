
INSERT INTO CLEARING_BRANCH(BANK_CODE, BRANCH_CODE, BRANCH_NAME, LOCATION_CODE, 
BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, NIKBRANCH_CODE, 
INPUT_BY, INPUT_DATETIME,  AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Bank_Code, RIGHT(NikBranch_Code,4), Branch_name, Location_Code, 
Branch_add1, Branch_add2, Clearing_zone, NikBranch_Code, 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_CCMSSubSys.dbo.NikBranch

--


INSERT INTO Old_checktotal(ds_code, total_chkno, total_chkamt, oprdate, customer_ref,
Location_code, Acc_No, EntryLoc, [FileName], Userid)
SELECT ds_code, total_chkno, total_chkamt, oprdate, customer_ref, 
Location_code, Acc_No, '196', [FileName], Userid
FROM db_CCMSSubSys.dbo.Checktotalhist


INSERT INTO Old_Nikashtab(OprDate, IssueDate, BankFrom, BankTo, PayeeNm, ChqSeries,
ChqNumber, ChqNo, BookNo, ChqType, AccntNo, DebtCredit, ErrCode, Remark, BatchNo, 
Ds_slip, CheckRef, EntryLoc, ds_code, [status], ReturnDate, [FileName], Userid, 
seqno, checked, Authorizer_id, refno, IBBSFileName, Is_PDC, PDC_Loation)
SELECT OprDate, IssueDate, BankFrom, BankTo, PayeeNm, ChqSeries, 
ChqNumber, ChqNo,BookNo, ChqType, AccntNo, DebtCredit, ErrCode, Remark, BatchNo, 
Ds_slip, CheckRef,'196', ds_code, [status], ReturnDate, [FileName], Userid, 
seqno, checked, Authorizer_id, refno, IBBSFileName, Is_PDC, PDC_Loation
FROM db_CCMSSubSys.dbo.nikashtabhist

--


DECLARE @v_DS_CODE varchar(8),
		@v_MID numeric(10,0),
		@v_DSL numeric(4,0),
		@v_OprDate datetime,
		@v_BankFrom varchar(7),
		@v_ChqNumber varchar(15), 
		@v_DebtCredit money,
		@v_Remark varchar(15);

DECLARE tmpcursorMain CURSOR FOR
	SELECT distinct ds_code FROM db_CCMSSubSys.dbo.checktotal;

OPEN tmpcursorMain;
FETCH NEXT FROM tmpcursorMain 
    INTO @v_DS_CODE;

--SELECT @v_MID=1;        
SELECT @v_MID=ISNULL(CLEAR_MAX_MID,0)+1 FROM GENPRM;

WHILE @@FETCH_STATUS=0 
BEGIN

	UPDATE GENPRM SET CLEAR_MAX_MID=@v_MID;
	
	INSERT INTO CHECKTOTAL(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
		CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
		INPUT_BY, INPUT_DATETIME,AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
		SELECT @v_MID,@v_DS_CODE, total_chkno, total_chkamt, oprdate, 
		customer_ref, '196', CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
		'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
		FROM db_CCMSSubSys.dbo.checktotal ct
		WHERE ct.ds_code=@v_DS_CODE;
		
		
	--- nikashtab 
	
	SELECT @v_DSL=1;
		
	DECLARE tmpcursorDet CURSOR FOR
		SELECT OprDate,BankFrom ,ChqNumber , DebtCredit,Remark 
			FROM db_CCMSSubSys.dbo.nikashtab 
			WHERE ds_code=@v_DS_CODE;

	OPEN tmpcursorDet;
	FETCH NEXT FROM tmpcursorDet 
		INTO @v_OprDate,@v_BankFrom ,@v_ChqNumber , @v_DebtCredit,@v_Remark;
		
	WHILE @@FETCH_STATUS=0 
	BEGIN	
		
		INSERT INTO CLEARINGTAB(MID, DSL, OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
			PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, 
			ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 
			RTN_STATUS, RTN_CODE, RETURN_DATE, CHECKED, FLEX_FILENAME, IS_PDC, 
			MOD_NO, VALUE_TYPE, IS_ROW_CHG)
			SELECT @v_MID,@v_DSL,OprDate, IssueDate, BankTo, 
			PayeeNm, ChqSeries, ChqNumber, ChqNo, BookNo, ChqType, 
			AccntNo, DebtCredit, Remark,  BatchNo, CheckRef, '196', ds_code,
			[status], ErrCode, ReturnDate,  checked, [FileName],  Is_PDC,
			1,1,1
			FROM db_CCMSSubSys.dbo.nikashtab
			
		SELECT @v_DSL=@v_DSL+1;
		
		FETCH NEXT FROM tmpcursorDet 
			INTO @v_OprDate,@v_BankFrom ,@v_ChqNumber , @v_DebtCredit,@v_Remark; 
	END

	CLOSE tmpcursorDet;	
	DEALLOCATE tmpcursorDet;
		
	--- 	
		
		
	
	SELECT @v_MID=@v_MID+1;
	
	FETCH NEXT FROM tmpcursorMain 
		INTO @v_DS_CODE;
	
 
END

CLOSE tmpcursorMain;	
DEALLOCATE tmpcursorMain;




