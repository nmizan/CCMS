

DELETE CHECKTOTAL;
DELETE CHECKTOTAL_HIST;
DELETE CLEARINGTAB;
DELETE CLEARINGTAB_HIST;

DECLARE @v_DS_CODE varchar(8),
		@v_MID numeric(10,0),
		@v_DSL numeric(4,0),
		@v_OprDate datetime,
		@v_BankFrom varchar(7),
		@v_ChqNumber varchar(15), 
		@v_DebtCredit money,
		@v_Remark varchar(15);

DECLARE tmpcursorMain CURSOR FOR
	SELECT distinct ds_code FROM db_CCMSSubSystem.dbo.checktotal;

OPEN tmpcursorMain;
FETCH NEXT FROM tmpcursorMain 
    INTO @v_DS_CODE;
        
SELECT @v_MID=1;

WHILE @@FETCH_STATUS=0 
BEGIN

	UPDATE GENPRM SET CLEAR_MAX_MID=@v_MID;
	
	INSERT INTO CHECKTOTAL(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
		CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
		INPUT_BY, INPUT_DATETIME,AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
		SELECT @v_MID,@v_DS_CODE, total_chkno, total_chkamt, oprdate, 
		customer_ref, 'code for dhaka', CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
		'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
		FROM db_CCMSSubSystem.dbo.checktotal ct
		WHERE ct.ds_code=@v_DS_CODE;
		
		
	--- nikashtab 
	
	SELECT @v_DSL=1;
		
	DECLARE tmpcursorDet CURSOR FOR
		SELECT OprDate,BankFrom ,ChqNumber , DebtCredit,Remark 
			FROM db_CCMSSubSystem.dbo.nikashtab 
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
			AccntNo, DebtCredit, Remark,  BatchNo, CheckRef, EntryLoc, ds_code,
			[status], ErrCode, ReturnDate,  checked, [FileName],  Is_PDC,
			1,1,1
			FROM db_CCMSSubSystem.dbo.nikashtab
			
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


 	
 			