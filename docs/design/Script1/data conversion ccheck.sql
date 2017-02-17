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


	
		
		


 	
 			