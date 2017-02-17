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


