
--
DELETE FROM BANK;
DELETE FROM BANK_HIST;

INSERT INTO BANK(BANK_CODE, BANK_NAME, HEAD_ADD1, HEAD_ADD2, HEAD_ADD3, 
BANK_BBK_CODE, ACC_NO, INPUT_BY, INPUT_DATETIME, 
AUTH_BY, AUTH_DATETIME,  MOD_NO, [STATUS])
SELECT BANK_CODE, BANK_NAME, headadd1, headadd2, headadd3, 
nikBank_code, Accno, 'SYSTEM',GETDATE(),
'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.BANK;

--

DELETE FROM BRANCH;
DELETE FROM BRANCH_HIST;

INSERT INTO BRANCH(BANK_CODE, BRANCH_CODE, BRANCH_NAME, LOCATION_CODE, 
BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, CORRBANK, NIKBRANCH_CODE, 
INPUT_BY, INPUT_DATETIME,AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Bank_Code, Branch_Code, Branch_Name, Location_Code, 
branch_add1, branch_add2, clearing_zone, 1, NikBranch_Code, 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.Branch where corrbank ='Y'

INSERT INTO BRANCH(BANK_CODE, BRANCH_CODE, BRANCH_NAME, LOCATION_CODE, 
BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, CORRBANK, NIKBRANCH_CODE, 
INPUT_BY, INPUT_DATETIME,AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
--for corrbank y
SELECT Bank_Code, Branch_Code, Branch_Name, Location_Code, 
branch_add1, branch_add2, clearing_zone, 0, NikBranch_Code, 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.Branch where corrbank ='N';




--
DELETE FROM CCASH;
DELETE FROM CCASH_HIST;

INSERT INTO CCASH(D_CODE, CUSTOMER_REF, CASH_REF, SLIP_DATE, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT d_code, customer_ref, cashref, slip_date,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.ccash;

--

DELETE FROM CCHECK;
DELETE FROM CCHECK_HIST;


--

DELETE FROM CCHECKTOTAL;
DELETE FROM CCHECKTOTAL_HIST;

INSERT INTO dbo.CCHECKTOTAL(D_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME,MOD_NO, [STATUS])
SELECT d_code, total_chkno, total_chkamt,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.cchecktotal;

--

DELETE FROM CCMSREF_TAB;
DELETE FROM CCMSREF_TAB_HIST;

INSERT INTO CCMSREF_TAB(REF_NO, AMOUNT, VALUE_DATE, USERID, UPLOADED, REVERGEN,
[FILENAME], REV_DATE, ACC_NO, REFACC_NO, D_CODE, SUNDRY_REFACC_NO, FLEXGEN_DATE, 
STATUS_ID, REMARKS, AUTHORIZE, AUTHORIZER_ID)
SELECT refno, Amount, ValueDate, userId, Uploaded, ReverGen, 
[FileName], RevDate, Acc_No, RefAcc_No, d_code, Sundryrefaccno, flexgendate, 
statusid,  remarks, Authorize, Authorizer_id
FROM db_citibank.dbo.IBBSRefTab;

--

DELETE FROM CHECKTYPE;
DELETE FROM CHECKTYPE_HIST;


INSERT INTO CHECKTYPE(CHECKTYPE_CODE, CHECKTYPE_NAME, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT ChqTypeNo, ChqTypeName,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.ChqType;

--

DELETE FROM CITIANY_FUND;

--

DELETE FROM CLIENT;
DELETE FROM CLIENT_HIST;
DELETE FROM CLIENT_LOC_CHARGE;
DELETE FROM CLIENT_LOC_CHARGE_HIST;

INSERT INTO CLIENT(CLIENT_CODE, ACC_NO, ACC_NAME, 
MAIL_ADD, 
CONTACT, CASH_DAYS, SPEED_DAYS, CASH_CR_TYPE, SPEED_CR_TYPE, CASH_CHARGE, 
SPEED_CHARGE, RETURN_CHARGE,  CITIANY_CHARGE, IS_DISABLE, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME,  MOD_NO, [STATUS])
SELECT Client_Code + ISNULL(Sub_Client,''), Acc_No, Acc_Name, 
ISNULL(Mail_Add1,'') + char(13) + char(10) + ISNULL(Mail_Add2,'') + char(13) + char(10) + ISNULL(mail_add3,''), 
Contact, Citicash, citispeed, CashCrTyp, SpeedCrTyp,  CashCharge,
CheckCharge,ReturnCharge,  CitiAnyCharge, Flag,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.client;

---

DELETE FROM CSCHEDULE;
DELETE FROM CSCHEDULE_HIST;

INSERT INTO CSCHEDULE(CS_CODE, SCHEDULE_DATE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE,
DS_CODE, CITICASH_AMOUNT, CITICHECK_AMOUNT, NO_CHECK, MOD_NO)
SELECT cs_code, Schedule_Date,  Location_code, Corr_bcode, corr_brcode, 
ds_code, citicash_amount, citicheck_amount, No_check, 1
FROM db_citibank.dbo.cschedule;

--

DELETE FROM CSD;
DELETE FROM CSD_HIST;
DELETE FROM CSD_DET;
DELETE FROM CSD_DET_HIST;

INSERT INTO CSD(D_CODE, INPUT_BY, INPUT_DATETIME,  AUTH_BY, AUTH_DATETIME,MOD_NO, [STATUS])
SELECT DISTINCT d_code,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L' 
FROM db_citibank.dbo.csd;

--

DELETE FROM DCOLLECTED;
DELETE FROM DCOLLECTED_HIST;

INSERT INTO DCOLLECTED(DS_CODE, TOTAL_NOCHK, TOTAL_CHKAMT, TOTAL_CASHAMT, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Ds_code, total_nochk, total_chkamt, total_cashamt, 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.dcollected;

--

DELETE FROM DD;
DELETE FROM DD_CCHECK_HIST;
DELETE FROM DD_HIST;
DELETE FROM DD_NCOLLECTION_HIST; 

INSERT INTO DD(D_CODE, SLNO, DD_NO, DD_DATE, AMOUNT, DRAWER_BANKCODE, DRAWER_BRANCHCODE,
DRAWER_LOCATION, DRAWEE_BRANCH, NIKBRANCH_CODE, VAT, COMMISION, POSTAGE_CHARGE, 
INSTRUMENT_EXP, INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, RTN_STATUS, [STATUS])
SELECT d_code, slno, dd_No, dd_date, amount, drawer_bankcode, drawer_brcode, 
drawer_location, drawee_branch,nikbranch_code,  vat, 0,0,
0,'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,[status],'L'
FROM db_citibank.dbo.dd;

--

DELETE FROM DSCHEDULE;
DELETE FROM DSCHEDULE_HIST;

INSERT INTO DSCHEDULE(DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT, CITICHECK_AMOUNT,
SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
MOD_NO, [FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, CHECKED, FLEXGEN_DATE, IS_ROW_CHG)
SELECT ds_code, D_code, Deposit_Type, citicash_amount, citicheck_amount,
Schedule_Date, No_check,  Client_code, Location_code, Corr_bcode, corr_brcode, 
1,[FileName], refno, userid,  seqno, checked,  flexgendate,1
FROM db_citibank.dbo.dschedule;


UPDATE DCOLLECTED SET ENTRY_DATE=a.Entry_Date
FROM DCOLLECTED b INNER JOIN
(SELECT ds_code,MAX(Entry_Date) Entry_Date
FROM db_citibank.dbo.dschedule
GROUP BY ds_code) a 
ON a.ds_code=b.DS_CODE

--

DELETE FROM GENPRM;

INSERT INTO GENPRM(BATCH_NO, REF_NO, REGSEQ_NO, BATCH_DATE, CLEAR_MAX_MID)
SELECT Batchno, refno, regseqno, batchdate,1
FROM db_citibank.dbo.genprm;

--
 
DELETE FROM HOLIDAY;
DELETE FROM HOLIDAY_HIST;

INSERT INTO HOLIDAY(HOLI_DAY, HOLI_TYPE, 
INPUT_BY, INPUT_DATETIME,  AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT holi_day, holi_type,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.holiday;

--

DELETE FROM IRE_RET;

--

DELETE FROM LOCATION;
DELETE FROM LOCATION_HIST;

INSERT INTO LOCATION(LOCATION_CODE, LOCATION_NAME, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT Location_Code, Location_Name,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.Location;

--

DELETE FROM NCOLLECTION;
DELETE FROM NCOLLECTION_CCHECK_HIST;
DELETE FROM NCOLLECTION_HIST;

INSERT INTO NCOLLECTION (NONZONE_REF, REF_DATE, DDREFNO, AMOUNT, VAT, COMMISION, 
POSTAGE_CHARGE, INSTRUMENT_EXP, RTN_STATUS, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT nonzoneref, ref_date, ddrefno, collectedAmount,  vat,0, 
0,0,[status], 
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.normalcollection

--

DELETE FROM RETURN_REJECT;
DELETE FROM RETURN_REJECT_HIST;

INSERT INTO RETURN_REJECT(REJECT_CODE, REJECT_REASON, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT reject_code, reject_reason,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.rtnrjct;

--

DELETE FROM REVERSAL_HIST;

INSERT INTO REVERSAL_HIST(REF_NO, AMOUNT, VALUE_DATE, USERID, UPLOADED, REVERGEN, 
[FILENAME], REV_DATE, CLIENT_CODE, REFACC_NO, DEPOSIT_TYPE, ACC_NO, LOCATION_CODE, 
CR_TYPE, DS_CODE, SEQ_NO, SUNDRY_REFACC_NO, FLEXGEN_DATE, CHECKDS_NO, CUSTOMER_REF)
SELECT refno, Amount, ValueDate, userId, Uploaded, ReverGen, 
[FileName], RevDate, client_code, RefAcc_No, Deposit_Type, Acc_no, location_code, 
crtyp, ds_code, seqno, Sundryrefaccno, flexgendate, CheckDSno, CustomerRef
FROM db_citibank.dbo.ReversalHist;

--

DELETE FROM SCHEDULE_STOCK;
DELETE FROM SCHEDULE_STOCK_HIST;

INSERT INTO SCHEDULE_STOCK(SCHEDULE_ID, BANK_CODE, LOCATION_CODE, SCHE_FROM, SCHE_UPTO, 
INPUT_BY, INPUT_DATETIME,  AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT ScheduleId,bank_code,Location_Code, sche_from, sche_upto,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.ScheduleStock;

--

DELETE FROM SYSTEM_LOG;

--

DELETE FROM TMP_BOOKING;
DELETE FROM TMP_CR_BOOKING;
DELETE FROM TMP_DR_BOOKING;
DELETE FROM TMP_MON_BILL;
DELETE FROM TMP_REVERSAL;

--

DELETE FROM TOTALCS;
DELETE FROM TOTALCS_HIST;

INSERT INTO TOTALCS(CS_CODE, TOTAL_AMOUNT, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME, MOD_NO, [STATUS])
SELECT cs_code, total_amount,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.totalcs

--

DELETE FROM ZONE;
DELETE FROM ZONE_HIST;

INSERT INTO ZONE(ZONE_CODE, ZONE_NAME, 
INPUT_BY, INPUT_DATETIME, AUTH_BY, AUTH_DATETIME,  MOD_NO, [STATUS])
SELECT zone_code, zone_name,
'SYSTEM',GETDATE(),'SYSTEM',GETDATE(),1,'L'
FROM db_citibank.dbo.zone;

--

GO

-- csd_det
-- insert non duplicate data
INSERT INTO CSD_DET(D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, DRAWEE_BRANCH, CHECK_REF, 
RTN_STATUS, MOD_NO)
SELECT d_code, slno,check_no, drawer, draweebank_code,
amount, customer_ref, slip_date, check_date, drawee_branch,  checkRef, 
rtnstatus,1
 FROM db_citibank.dbo.csd a
WHERE a.D_CODE NOT IN
(SELECT d_code FROM db_citibank.dbo.csd b
where b.d_code=a.d_code and b.slno=a.slno
group by b.d_code,b.slno
having count(b.slno)>1)
AND a.SLNO NOT IN
(SELECT slno FROM db_citibank.dbo.csd c
where c.d_code=a.d_code and c.slno=a.slno
group by c.d_code,c.slno
having count(c.slno)>1);
------


-- update return

UPDATE CSD_DET SET RTN_CODE=r.return_code
FROM CSD_DET c
INNER JOIN db_citibank.dbo.creturn r
ON SUBSTRING(r.returnref,1,7)=c.D_CODE AND SUBSTRING(r.returnref,8,3)=c.SLNO
AND c.RTN_STATUS='R'

--


-- insert duplicate data

DECLARE @v_D_CODE varchar(7),
		@v_SLNO	numeric(3,0),
		@v_check_no varchar(15),
		@v_amount numeric(10,2),
		@v_tmp_SLNO numeric(3,0),
		@v_tmp_D_CODE varchar(7),
		@v_tmp_return_code varchar(2);

DECLARE tmpcursorDup CURSOR FOR
	SELECT d_code,slno,check_no,amount FROM db_citibank.dbo.csd a
		WHERE a.D_CODE =
		(SELECT d_code FROM db_citibank.dbo.csd b
		where b.d_code=a.d_code and b.slno=a.slno
		group by b.d_code,b.slno
		having count(b.slno)>1)
		AND a.SLNO =
		(SELECT slno FROM db_citibank.dbo.csd c
		where c.d_code=a.d_code and c.slno=a.slno
		group by c.d_code,c.slno
		having count(c.slno)>1);

OPEN tmpcursorDup;
FETCH NEXT FROM tmpcursorDup 
    INTO @v_D_CODE,@v_SLNO,@v_check_no,@v_amount;
 

SELECT @v_tmp_D_CODE=@v_D_CODE;

SELECT @v_tmp_SLNO=ISNULL(MAX(SLNO),0)+1 
			FROM csd_det
			WHERE D_CODE=@v_D_CODE
			

WHILE @@FETCH_STATUS=0 
BEGIN
	
	IF @v_tmp_D_CODE<>@v_D_CODE
	BEGIN
		SELECT @v_tmp_SLNO=ISNULL(MAX(SLNO),0)+1 
			FROM csd_det
			WHERE D_CODE=@v_D_CODE;
			
		SELECT @v_tmp_D_CODE=@v_D_CODE;
	END
		
	SELECT @v_tmp_return_code=return_code 
		FROM db_citibank.dbo.creturn
		WHERE SUBSTRING(returnref,1,7)=@v_D_CODE AND SUBSTRING(returnref,8,3)=@v_SLNO
	
	
	INSERT INTO CSD_DET(D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
		AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, DRAWEE_BRANCH, CHECK_REF, 
		RTN_STATUS, MOD_NO,RTN_CODE)
		SELECT d_code, @v_tmp_SLNO,check_no, drawer, draweebank_code,
		amount, customer_ref, slip_date, check_date, drawee_branch,  checkRef, 
		rtnstatus,1,@v_tmp_return_code
		FROM db_citibank.dbo.csd
		WHERE d_code=@v_D_CODE AND slno=@v_SLNO AND check_no=@v_check_no AND amount=@v_amount
 
	SELECT @v_tmp_SLNO=@v_tmp_SLNO+1;

	FETCH NEXT FROM tmpcursorDup 
		INTO @v_D_CODE,@v_SLNO,@v_check_no,@v_amount;
	

 
END

CLOSE tmpcursorDup;	
DEALLOCATE tmpcursorDup;


GO


-- ccheck 
-- insert non duplicate data
INSERT INTO CCHECK(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF,
SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, CHECK_TYPE, DRAWER, 
DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, CHECK_REF, RTN_STATUS, 
NONZONE_REF, MOD_NO)
SELECT slno, d_code, client_code, dlocation_code, customer_ref, 
slip_date, value_date, check_no, amount, check_date, check_type, drawer, 
drawee_bankcode, location_code, branch_code, checkRef,  [status],
nonzoneref, 1 
 FROM db_citibank.dbo.ccheck a
WHERE a.D_CODE NOT IN
(SELECT d_code FROM db_citibank.dbo.ccheck b
where b.d_code=a.d_code and b.slno=a.slno
group by b.d_code,b.slno
having count(b.slno)>1)
AND a.SLNO NOT IN
(SELECT slno FROM db_citibank.dbo.ccheck c
where c.d_code=a.d_code and c.slno=a.slno
group by c.d_code,c.slno
having count(c.slno)>1);
------

-- insert duplicate data

DECLARE @v_D_CODE varchar(7),
		@v_SLNO	numeric(3,0),
		@v_check_no varchar(15),
		@v_amount numeric(10,2),
		@v_tmp_SLNO numeric(3,0),
		@v_tmp_D_CODE varchar(7);

DECLARE tmpcursorDup CURSOR FOR
	SELECT d_code,slno,check_no,amount FROM db_citibank.dbo.ccheck a
		WHERE a.D_CODE =
		(SELECT d_code FROM db_citibank.dbo.ccheck b
		where b.d_code=a.d_code and b.slno=a.slno
		group by b.d_code,b.slno
		having count(b.slno)>1)
		AND a.SLNO =
		(SELECT slno FROM db_citibank.dbo.ccheck c
		where c.d_code=a.d_code and c.slno=a.slno
		group by c.d_code,c.slno
		having count(c.slno)>1);

OPEN tmpcursorDup;
FETCH NEXT FROM tmpcursorDup 
    INTO @v_D_CODE,@v_SLNO,@v_check_no,@v_amount;
 

SELECT @v_tmp_D_CODE=@v_D_CODE;

SELECT @v_tmp_SLNO=ISNULL(MAX(SLNO),0)+1 
			FROM CCHECK 
			WHERE D_CODE=@v_D_CODE
			

WHILE @@FETCH_STATUS=0 
BEGIN
	
	IF @v_tmp_D_CODE<>@v_D_CODE
	BEGIN
		SELECT @v_tmp_SLNO=ISNULL(MAX(SLNO),0)+1 
			FROM CCHECK 
			WHERE D_CODE=@v_D_CODE
			
		SELECT @v_tmp_D_CODE=@v_D_CODE;
	END
		
	
	INSERT INTO CCHECK(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF,
		SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, CHECK_TYPE, DRAWER, 
		DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, CHECK_REF, RTN_STATUS, 
		NONZONE_REF, MOD_NO)
		SELECT @v_tmp_SLNO, d_code, client_code, dlocation_code, customer_ref, 
		slip_date, value_date, check_no, amount, check_date, check_type, drawer, 
		drawee_bankcode, location_code, branch_code, checkRef,  [status],
		nonzoneref, 1 
		FROM db_citibank.dbo.ccheck
		WHERE d_code=@v_D_CODE AND slno=@v_SLNO AND check_no=@v_check_no AND amount=@v_amount
 
 
	SELECT @v_tmp_SLNO=@v_tmp_SLNO+1;

	FETCH NEXT FROM tmpcursorDup 
		INTO @v_D_CODE,@v_SLNO,@v_check_no,@v_amount;
	

 
END

CLOSE tmpcursorDup;	
DEALLOCATE tmpcursorDup;

-- update return
UPDATE CCHECK SET RTN_CODE=n.code
FROM CCHECK c
INNER JOIN db_citibank.dbo.norcolrtn n
ON c.NONZONE_REF=n.nonzoneref
WHERE c.RTN_STATUS='R'
--


	
		
		


 	
 			












