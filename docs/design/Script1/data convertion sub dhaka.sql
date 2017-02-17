
DELETE FROM CHECKTOTAL;
DELETE FROM CHECKTOTAL_HIST;

--

DELETE FROM CLEARING_BANK;
DELETE FROM CLEARING_BANK_HIST;

INSERT INTO CLEARING_BANK(BANK_CODE, BANK_NAME, HEAD_ADD1, HEAD_ADD2, HEAD_ADD3, BANK_BBK_CODE, ACC_NO, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Bank_Code, Bank_name, headadd1, headadd2, headadd3, NikBank_Code, Acc_no,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_CCMSSubSystem.dbo.NikBank;

--

DELETE FROM CLEARING_BRANCH;
DELETE FROM CLEARING_BRANCH_HIST;

INSERT INTO CLEARING_BRANCH(BANK_CODE, BRANCH_CODE, BRANCH_NAME, LOCATION_CODE, 
BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, NIKBRANCH_CODE, 
INPUT_BY, INPUT_DATETIME,  AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Bank_Code, RIGHT(NikBranch_Code,4), Branch_name, Location_Code, 
Branch_add1, Branch_add2, Clearing_zone, NikBranch_Code, 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_CCMSSubSystem.dbo.NikBranch

--

DELETE FROM dbo.CLEARING_CLIENT;
DELETE FROM dbo.CLEARING_CLIENT_HIST;

INSERT INTO dbo.CLEARING_CLIENT(ACC_NO, ACC_NAME, 
MAIL_ADD, 
CONTACT, SPEED_CR_TYPE, IS_DISABLE, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT  Acc_No, Acc_Name, 
ISNULL(Mail_Add1,'') + char(13) + char(10) + ISNULL(Mail_Add2,'') + char(13) + char(10) + ISNULL(mail_add3,''), 
Contact, SpeedCrTyp, Flag, 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_CCMSSubSystem.dbo.Nikclient

--

DELETE FROM CLEARING_CLIENT_CHARGE;
DELETE FROM CLEARING_CLIENT_CHARGE_HIST;

--

DELETE FROM CLEARING_LOCATION;
DELETE FROM CLEARING_LOCATION_HIST;

INSERT INTO CLEARING_LOCATION(LOCATION_CODE, LOCATION_NAME, 
INPUT_BY, INPUT_DATETIME,  AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Location_Code, Location_Name,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_CCMSSubSystem.dbo.Location;

--

DELETE FROM CLEARINGTAB;
DELETE FROM CLEARINGTAB_HIST;

--

DELETE FROM Old_checktotal;
DELETE FROM Old_Nikashtab;

INSERT INTO Old_checktotal(ds_code, total_chkno, total_chkamt, oprdate, customer_ref,
Location_code, Acc_No, EntryLoc, [FileName], Userid)
SELECT ds_code, total_chkno, total_chkamt, oprdate, customer_ref, 
Location_code, Acc_No, '422', [FileName], Userid
FROM db_CCMSSubSystem.dbo.Checktotalhist


INSERT INTO Old_Nikashtab(OprDate, IssueDate, BankFrom, BankTo, PayeeNm, ChqSeries,
ChqNumber, ChqNo, BookNo, ChqType, AccntNo, DebtCredit, ErrCode, Remark, BatchNo, 
Ds_slip, CheckRef, EntryLoc, ds_code, [status], ReturnDate, [FileName], Userid, 
seqno, checked, Authorizer_id, refno, IBBSFileName, Is_PDC, PDC_Loation)
SELECT OprDate, IssueDate, BankFrom, BankTo, PayeeNm, ChqSeries, 
ChqNumber, ChqNo,BookNo, ChqType, AccntNo, DebtCredit, ErrCode, Remark, BatchNo, 
Ds_slip, CheckRef,'422', ds_code, [status], ReturnDate, [FileName], Userid, 
seqno, checked, Authorizer_id, refno, IBBSFileName, Is_PDC, PDC_Loation
FROM db_CCMSSubSystem.dbo.nikashtabhist

--

DELETE FROM PDCTAB;
DELETE FROM PDCTAB_HIST;
DELETE FROM PDCTOTAL;
DELETE FROM PDCTOTAL_HIST;

--

DELETE FROM RETURN_CLEARING;
DELETE FROM RETURN_MISMATCH_CLEAR;

--

DELETE FROM dbo.REVERSAL_HIST_CLEARING;
DELETE FROM dbo.REVERSAL_HIST_CLEARING_RET;

--

DELETE FROM TMP_REVERSAL_CLEARING;

--




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
--SELECT @v_MID=ISNULL(CLEAR_MAX_MID,0)+1 FROM GENPRM;

WHILE @@FETCH_STATUS=0 
BEGIN

	UPDATE GENPRM SET CLEAR_MAX_MID=@v_MID;
	
	INSERT INTO CHECKTOTAL(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
		CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
		INPUT_BY, INPUT_DATETIME,AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
		SELECT @v_MID,@v_DS_CODE, total_chkno, total_chkamt, oprdate, 
		customer_ref, '422', CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
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
			AccntNo, DebtCredit, Remark,  BatchNo, CheckRef, '422', ds_code,
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


 	
 			


