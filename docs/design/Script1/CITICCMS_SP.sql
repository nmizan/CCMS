SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Nov-12
-- Description:	Get detail of bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetDetail]	
	@BANK_CODE		varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT BANK_CODE 
			   FROM BANK WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM BANK 
			WHERE BANK_CODE=@BANK_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM BANK_HIST
			WHERE BANK_CODE=@BANK_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Nov-12
-- Description:	Get Total # of modification of bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetMaxMod]	
	@BANK_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM BANK_HIST 
		WHERE BANK_CODE=@BANK_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM BANK 
				WHERE BANK_CODE=@BANK_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetCorrBankListByLoc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Dec-12
-- Description:	get list records of corr. bank by location
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetCorrBankListByLoc]
	@LOCATION_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT b.BANK_CODE,b.BANK_NAME 
	FROM BANK b
	INNER JOIN BRANCH br ON b.BANK_CODE=br.BANK_CODE
	WHERE b.STATUS=''L'' 
	AND br.CORRBANK=1 AND br.LOCATION_CODE=@LOCATION_CODE
	ORDER BY BANK_NAME;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetCorrBranchListByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Dec-12
-- Description:	get list records of corr. branch by bank
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetCorrBranchListByBank]
	@BANK_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT BRANCH_CODE,BRANCH_NAME
	FROM BRANCH		
	WHERE STATUS=''L'' 
	AND CORRBANK=1 AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Dec-12
-- Description:	Get detail of branch by branch code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetailByCode]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM BRANCH 
	WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetCorrBranchListByLoc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Dec-12
-- Description:	get list records of corr. Bank branch by Location
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetCorrBranchListByLoc]
	@LOCATION_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT br.BRANCH_CODE,br.BRANCH_NAME,br.BANK_CODE,b.BANK_NAME
	FROM BRANCH br
	INNER JOIN BANK b ON b.BANK_CODE=br.BANK_CODE
	WHERE br.STATUS=''L''
	AND br.CORRBANK=1 AND br.LOCATION_CODE=@LOCATION_CODE
	ORDER BY BANK_NAME,BRANCH_NAME
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_CodeVerify]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Dec-12
-- Description:	Check schedule code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_CodeVerify]
	@SCHEDULE_ID	tinyint,	
	@BANK_CODE		varchar(4),		
	@LOCATION_CODE	varchar(4),	
	@SCHE_CODE		varchar(12)	
AS
BEGIN	
	DECLARE @ErrorVar	int;
	DECLARE @CountRec	int;
	
	SET NOCOUNT ON;
	
	SELECT @CountRec=0;

	SELECT @CountRec=COUNT(SCHEDULE_ID) FROM SCHDEULE_STOCK
	WHERE SCHEDULE_ID=@SCHEDULE_ID
	AND BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
	AND SCHE_FROM >= @SCHE_CODE AND SCHE_UPTO <=@SCHE_CODE
	AND STATUS=''L'';

	IF @ErrorVar <> 0
		BEGIN		
			RETURN 1;
		END

	IF @CountRec > 0
		BEGIN
			RETURN 0
		END
	ELSE
		BEGIN
			RETURN 4 --not exist
		END

	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_OldCheckTotal_GetFilterData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Sep-13
-- Description:	get detail of old checktotal and nikashtab table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_OldCheckTotal_GetFilterData]		
	@ENTRY_LOC		varchar(3),
	@OPR_DATE_FROM	datetime,
	@OPR_DATE_TO	datetime,
	@REMARK			varchar(15),
	@DS_CODE		varchar(8),
	@BANK_CODE		varchar(4),
	@NIKBRANCH_CODE	varchar(7),
	@CHECK_NUMBER	varchar(15),
	@AMOUNT			numeric(14,2)
AS
BEGIN	
		
	SET NOCOUNT ON;
	
	DECLARE @query as nvarchar(2000);
		
	SET @query = ''SELECT * from  [V_OLD_CLEARING] where EntryLoc=@ENTRY_LOC'';
	
	IF (@OPR_DATE_FROM IS NOT NULL) AND (@OPR_DATE_TO IS NOT NULL)
		BEGIN
			SET @query=@query + '' AND oprdate>=@OPR_DATE_FROM AND oprdate<=@OPR_DATE_TO '';
		END
		
	IF @REMARK<>'''' 
	BEGIN
		SET @query=@query + '' AND remark=@REMARK '';
	END
	
	IF @DS_CODE<>'''' 
	BEGIN
		SET @query=@query + '' AND ds_code=@DS_CODE '';
	END
	
	IF @BANK_CODE<>'''' 
	BEGIN
		SET @query=@query + '' AND BANK_CODE=@BANK_CODE '';
	END
	
	IF @NIKBRANCH_CODE<>'''' 
	BEGIN
		SET @query=@query + '' AND BankTo=@NIKBRANCH_CODE '';
	END
	
	IF @CHECK_NUMBER<>'''' 
	BEGIN
		SET @query=@query + '' AND ChqNumber=@CHECK_NUMBER '';
	END
	
	IF @AMOUNT<>0 
	BEGIN
		SET @query=@query + '' AND debtcredit=@AMOUNT '';
	END

	EXEC sp_executesql @query,N''@ENTRY_LOC		varchar(3),
	@OPR_DATE_FROM	datetime,
	@OPR_DATE_TO	datetime,
	@REMARK			varchar(15),
	@DS_CODE		varchar(8),
	@BANK_CODE		varchar(4),
	@NIKBRANCH_CODE	varchar(7),
	@CHECK_NUMBER	varchar(15),
	@AMOUNT			numeric(14,2)'' ,                    
                   @ENTRY_LOC=@ENTRY_LOC,@OPR_DATE_FROM=@OPR_DATE_FROM,
	@OPR_DATE_TO=@OPR_DATE_TO,
	@REMARK	=@REMARK,
	@DS_CODE=@DS_CODE,
	@BANK_CODE=@BANK_CODE,
	@NIKBRANCH_CODE	=@NIKBRANCH_CODE,
	@CHECK_NUMBER	=@CHECK_NUMBER,@AMOUNT = @AMOUNT

	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_IRERet_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Jul-13
-- Description:	Remove record from IRE_RET
-- =============================================
CREATE PROCEDURE [dbo].[CMS_IRERet_Remove]	
AS
BEGIN	
			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	DELETE FROM IRE_RET;

	SELECT @ErrorVar = @@ERROR;	

	IF @ErrorVar <> 0				
		BEGIN			
			RETURN 1;
		END

	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSDDet_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jan-13
-- Description:	Get detail of CSD_DET
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSDDet_GetDetails]	
	@D_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM CSD_DET WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT cd.*,''IS_AUTH''=1,b.BANK_NAME
			FROM CSD_DET cd				
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=cd.DRAWEE_BANK_CODE				
			WHERE cd.D_CODE=@D_CODE AND cd.MOD_NO = @MOD_NO
			ORDER BY SLNO
		END	
	ELSE
		BEGIN
			SELECT cdh.* ,b.BANK_NAME
			FROM CSD_DET_HIST cdh				
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=cdh.DRAWEE_BANK_CODE				
			WHERE cdh.D_CODE=@D_CODE AND cdh.MOD_NO = @MOD_NO
			ORDER BY D_CODE
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetOutstandings]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Get outstanding of ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetOutstandings]		
	@OPR_DATE	datetime,
	@ENTRY_LOC	varchar(3)	
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT * 
	FROM CLEARINGTAB 
	WHERE FLEX_FILENAME IS NULL
	AND OPR_DATE <=@OPR_DATE AND ENTRY_LOC=@ENTRY_LOC
	ORDER BY OPR_DATE,DS_CODE,CHECK_NUMBER
	
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_ClearingDataChecked]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Apr-13
-- Description: Process for making Clearing data checked
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_ClearingDataChecked]
	@OPR_DATE	datetime,	
	@ENTRY_LOC	varchar(3),
	@VALUE_TYPE	numeric(1,0)
AS
BEGIN	
	
	UPDATE CLEARINGTAB
		SET CHECKED=1
		WHERE (CHECKED IS NULL OR CHECKED=0)
			AND OPR_DATE<=OPR_DATE AND ENTRY_LOC=@ENTRY_LOC
			AND VALUE_TYPE=@VALUE_TYPE
	         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClientCharge_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Apr-13
-- Description:	Get detail of ClearingClientCharge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClientCharge_GetDetails]	
	@ACC_NO		varchar(15),	
	@MOD_NO		int
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT ACC_NO
			   FROM CLEARING_CLIENT_CHARGE 
				WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT cc.*,''VALUE_TYPE_NAME''=
					CASE
						WHEN VALUE_TYPE=1 THEN ''LOW''
						WHEN VALUE_TYPE=2 THEN ''HIGH''
					END 
			FROM CLEARING_CLIENT_CHARGE cc
			WHERE cc.ACC_NO=@ACC_NO AND cc.MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT cch.*,''VALUE_TYPE_NAME''=
					CASE
						WHEN VALUE_TYPE=1 THEN ''LOW''
						WHEN VALUE_TYPE=2 THEN ''HIGH''
					END  
			FROM CLEARING_CLIENT_CHARGE_HIST cch
			WHERE cch.ACC_NO=@ACC_NO  AND cch.MOD_NO = @MOD_NO
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Get Total # of modification of branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetMaxMod]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM BRANCH_HIST 
		WHERE BANK_CODE=@BANK_CODE 
		AND BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetListByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	get list records of branch by bank
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetListByBank]
	@BANK_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT BRANCH_CODE,BRANCH_NAME
	FROM BRANCH		
	WHERE STATUS=''L'' 
	AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetUnchecked]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Apr-13
-- Description: Get unchecked clearingtab records
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetUnchecked]
	@OPR_DATE	datetime,	
	@ENTRY_LOC	varchar(3),
	@VALUE_TYPE	numeric(1,0)
AS
BEGIN	
	
	SELECT * FROM CLEARINGTAB		
		WHERE (CHECKED IS NULL OR CHECKED=0)
			AND OPR_DATE<=OPR_DATE AND ENTRY_LOC=@ENTRY_LOC
			AND VALUE_TYPE=@VALUE_TYPE
	         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Get Total # of modification of CCheckTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckTotal_GetMaxMod]
	@D_CODE			varchar(12)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CCHECKTOTAL_HIST 
		WHERE D_CODE=@D_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CCHECKTOTAL
				WHERE D_CODE=@D_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	get list records of bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT BANK_CODE,BANK_NAME FROM BANK WHERE STATUS=''L''
	ORDER BY BANK_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	Get detail of bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetDetailByCode]	
	@BANK_CODE		varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM BANK 
	WHERE BANK_CODE=@BANK_CODE
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetNikBranchListByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-May-13
-- Description:	get list records of Nikash Branch from Branch by bank
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetNikBranchListByBank]
	@BANK_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;
	
	SELECT NIKBRANCH_CODE,BRANCH_NAME
	FROM BRANCH		
	WHERE [STATUS]=''L'' 
	AND (NIKBRANCH_CODE IS NOT NULL) 
	AND LTRIM(RTRIM(NIKBRANCH_CODE))<>''''
	AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Nov-12
-- Description:	Get detail of client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetDetail]	
	@CLIENT_CODE	varchar(6),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT CLIENT_CODE 
			   FROM CLIENT WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CLIENT 
			WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CLIENT_HIST
			WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Nov-12
-- Description:	Get Total # of modification of CLIENT table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetMaxMod]	
	@CLIENT_CODE	varchar(6)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLIENT_HIST 
		WHERE CLIENT_CODE=@CLIENT_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLIENT 
				WHERE CLIENT_CODE=@CLIENT_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Remove record from client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_Remove]	
	@CLIENT_CODE	varchar(6),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@ACC_NO				varchar(16),  
			@ACC_NAME			varchar(50),
			@MAIL_ADD			varchar(256), 
			@CONTACT			varchar(50), 
			@CASH_DAYS			numeric(2,0), 
			@SPEED_DAYS			numeric(2,0), 
			@CASH_CR_TYPE		varchar(25),
			@SPEED_CR_TYPE		varchar(25),
			@CASH_CHARGE		numeric(12,2), 
			@SPEED_CHARGE		numeric(12,2), 
			@RETURN_CHARGE		numeric(12,2), 
			@CASH_STD_CHARGE	numeric(12,2), 
			@SPEED_STD_CHARGE	numeric(12,2), 
			@CASH_VAT			numeric(8,2), 
			@SPEED_VAT			numeric(8,2), 
			@CITIANY_CHARGE		numeric(12,2), 
			@CITIANY_STD_CHARGE numeric(12,2), 
			@CITIANY_VAT		numeric(8,2), 
			@BILLING_TYPE		varchar(25),
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),			
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CLIENT_CODE from CLIENT 
			  WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CLIENT_CODE=CLIENT_CODE, @ACC_NO=ACC_NO, 
				@ACC_NAME=ACC_NAME,@MAIL_ADD=MAIL_ADD,@CONTACT=CONTACT,
				@CASH_DAYS=CASH_DAYS, @SPEED_DAYS=SPEED_DAYS, 
				@CASH_CR_TYPE=CASH_CR_TYPE, @SPEED_CR_TYPE=SPEED_CR_TYPE,
				@CASH_CHARGE=CASH_CHARGE, @SPEED_CHARGE=SPEED_CHARGE, 
				@RETURN_CHARGE=RETURN_CHARGE, @CASH_STD_CHARGE=CASH_STD_CHARGE,
				@SPEED_STD_CHARGE=SPEED_STD_CHARGE, @CASH_VAT=CASH_VAT, 
				@SPEED_VAT=SPEED_VAT, @CITIANY_CHARGE=CITIANY_CHARGE, 
				@CITIANY_STD_CHARGE=CITIANY_STD_CHARGE, 
				@CITIANY_VAT=CITIANY_VAT, @BILLING_TYPE=BILLING_TYPE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLIENT 
				WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLIENT_HIST WHERE CLIENT_CODE=@CLIENT_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLIENT_HIST (CLIENT_CODE, ACC_NO, ACC_NAME,MAIL_ADD,
				CONTACT, CASH_DAYS, SPEED_DAYS, CASH_CR_TYPE, SPEED_CR_TYPE,
				CASH_CHARGE, SPEED_CHARGE, RETURN_CHARGE, CASH_STD_CHARGE,
				SPEED_STD_CHARGE, CASH_VAT, SPEED_VAT, CITIANY_CHARGE, 
				CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
				@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
				@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
				@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
				@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT CLIENT_CODE from CLIENT_HIST 
					  WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLIENT_HIST
						WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetDetailByNikBranch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 20-FEB-13
-- Description:	Get detail of branch by NikBranch code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetailByNikBranch]	
	@BANK_CODE		varchar(4),
	@NIKBRANCH_CODE	varchar(7)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM BRANCH 
	WHERE BANK_CODE=@BANK_CODE AND NIKBRANCH_CODE=@NIKBRANCH_CODE;
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetCorrNikBranchListByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Fahad Khan
-- Create date: 20-FEB-13
-- Description:	get list records of corr. Branch and NIKBRANCH by bank
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetCorrNikBranchListByBank]
	@BANK_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;
	
	SELECT NIKBRANCH_CODE,BRANCH_NAME
	FROM BRANCH		
	WHERE STATUS=''L'' 
	AND CORRBANK=1 AND (NIKBRANCH_CODE IS NOT NULL) 
	AND LTRIM(RTRIM(NIKBRANCH_CODE))<>''''
	AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Add detail to clearing_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_Add]
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@BRANCH_NAME	varchar(35),
	@ROUTING_NO		varchar(8),
	@LOCATION_CODE	varchar(4),
	@BRANCH_ADD1	varchar(35),
	@BRANCH_ADD2	varchar(35),
	@CLEARING_ZONE	varchar(4),	
	@NIKBRANCH_CODE	varchar(7)
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BRANCH_CODE from CLEARING_BRANCH 
				WHERE BANK_CODE=@BANK_CODE
				AND BRANCH_CODE=@BRANCH_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CLEARING_BRANCH_HIST WHERE 
		BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CLEARING_BRANCH_HIST(BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO,
		LOCATION_CODE,BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, 
		NIKBRANCH_CODE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
		@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE,
		@NIKBRANCH_CODE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnClearing_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Aug-13
-- Description:	Get detail from ReturnClearing table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnClearing_GetDetailList]		
	@AUTH_FLAG	bit,
	@OPR_DATE	datetime
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT rc.*,''S'' = ''U''
				FROM RETURN_CLEARING rc
				WHERE rc.STATUS=''U''			
		END;
	ELSE
		BEGIN
			
			SELECT rc.*,''S'' = ''A''
				FROM RETURN_CLEARING rc
				WHERE rc.STATUS=''L'' AND rc.OPR_DATE=@OPR_DATE	
		
	
				
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Authorize record to Clearing_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_Auth]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BRANCH_NAME	varchar(35),
			@ROUTING_NO		varchar(8),
			@LOCATION_CODE	varchar(4),
			@BRANCH_ADD1	varchar(35),
			@BRANCH_ADD2	varchar(35),
			@CLEARING_ZONE	varchar(4),			
			@NIKBRANCH_CODE	varchar(7),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 


	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from CLEARING_BRANCH_HIST 
			  WHERE BANK_CODE=@BANK_CODE 
			  AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME = BRANCH_NAME,
				@ROUTING_NO=ROUTING_NO,@LOCATION_CODE=LOCATION_CODE,
				@BRANCH_ADD1=BRANCH_ADD1,@BRANCH_ADD2=BRANCH_ADD2,
				@CLEARING_ZONE=CLEARING_ZONE,
				@NIKBRANCH_CODE=NIKBRANCH_CODE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLEARING_BRANCH_HIST 
				WHERE BANK_CODE=@BANK_CODE AND
					BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLEARING_BRANCH_HIST 
				SELECT *,1 FROM CLEARING_BRANCH
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLEARING_BRANCH_HIST
				SET [STATUS] = ''O'' 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLEARING_BRANCH
				SET BRANCH_NAME = @BRANCH_NAME,ROUTING_NO=@ROUTING_NO,
				LOCATION_CODE=@LOCATION_CODE,
				BRANCH_ADD1=@BRANCH_ADD1,BRANCH_ADD2=@BRANCH_ADD2,
				CLEARING_ZONE=@CLEARING_ZONE,
				NIKBRANCH_CODE=@NIKBRANCH_CODE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLEARING_BRANCH_HIST WHERE BANK_CODE=@BANK_CODE 
				AND BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLEARING_BRANCH	 
				SELECT BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO, LOCATION_CODE, 
					BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE,  NIKBRANCH_CODE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLEARING_BRANCH_HIST
					WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
					AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLEARING_BRANCH_HIST 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get Total # of modification of clearing_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_GetMaxMod]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLEARING_BRANCH_HIST 
		WHERE BANK_CODE=@BANK_CODE 
		AND BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLEARING_BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Remove record from clearing_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_Remove]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BRANCH_NAME	varchar(35),
			@ROUTING_NO		varchar(8),
			@LOCATION_CODE	varchar(4),
			@BRANCH_ADD1	varchar(35),
			@BRANCH_ADD2	varchar(35),
			@CLEARING_ZONE	varchar(4),			
			@NIKBRANCH_CODE	varchar(7),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from CLEARING_BRANCH 
			  WHERE BANK_CODE=@BANK_CODE AND
			  BRANCH_CODE = @BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME = BRANCH_NAME,
				@ROUTING_NO=ROUTING_NO,@LOCATION_CODE=LOCATION_CODE,
				@BRANCH_ADD1=BRANCH_ADD1,@BRANCH_ADD2=BRANCH_ADD2,
				@CLEARING_ZONE=CLEARING_ZONE,
				@NIKBRANCH_CODE=NIKBRANCH_CODE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLEARING_BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE = @BRANCH_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLEARING_BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE = @BRANCH_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLEARING_BRANCH_HIST (BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO,
				LOCATION_CODE,BRANCH_ADD1, BRANCH_ADD2,CLEARING_ZONE, 
				NIKBRANCH_CODE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
				@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE,
				@NIKBRANCH_CODE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT BRANCH_CODE from CLEARING_BRANCH_HIST 
					  WHERE BANK_CODE=@BANK_CODE AND 
					  BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLEARING_BRANCH_HIST
						WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
						AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	update detail to clearing_branch table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClearingBranch_Update]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@BRANCH_NAME	varchar(35),
	@ROUTING_NO		varchar(8),
	@LOCATION_CODE	varchar(4),
	@BRANCH_ADD1	varchar(35),
	@BRANCH_ADD2	varchar(35),
	@CLEARING_ZONE	varchar(4),	
	@NIKBRANCH_CODE	varchar(7),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BRANCH_CODE FROM CLEARING_BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CLEARING_BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND
				BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CLEARING_BRANCH_HIST(BANK_CODE,BRANCH_CODE,BRANCH_NAME,ROUTING_NO,
				LOCATION_CODE,BRANCH_ADD1,BRANCH_ADD2,CLEARING_ZONE,
				NIKBRANCH_CODE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
				@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE,
				@NIKBRANCH_CODE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT BRANCH_CODE from CLEARING_BRANCH_HIST 
						WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE 
						AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CLEARING_BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND 
						BRANCH_CODE = @BRANCH_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CLEARING_BRANCH_HIST(BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO,
						LOCATION_CODE,BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, 
						NIKBRANCH_CODE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME,@ROUTING_NO,
						@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE,
						@NIKBRANCH_CODE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	get detail of clearing_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;



	IF @AUTH_FLAG=0
		BEGIN						
			SELECT brh.*,CLEARING_BANK.BANK_NAME,
				CLEARING_LOCATION.LOCATION_NAME,
				CLEARING_ZONE.ZONE_NAME,''S'' = ''U''				 
				FROM CLEARING_BRANCH_HIST brh
				LEFT OUTER JOIN CLEARING_BANK ON CLEARING_BANK.BANK_CODE=brh.BANK_CODE
				LEFT OUTER JOIN CLEARING_LOCATION ON CLEARING_LOCATION.LOCATION_CODE=brh.LOCATION_CODE
				LEFT OUTER JOIN CLEARING_ZONE ON CLEARING_ZONE.ZONE_CODE=brh.CLEARING_ZONE
				WHERE IS_AUTH=0
				ORDER BY BANK_CODE,BRANCH_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT br.*,1,CLEARING_BANK.BANK_NAME,
						CLEARING_LOCATION.LOCATION_NAME,
						CLEARING_ZONE.ZONE_NAME,''S'' = ''A''				
						FROM CLEARING_BRANCH br
						LEFT OUTER JOIN CLEARING_BANK ON CLEARING_BANK.BANK_CODE=br.BANK_CODE
						LEFT OUTER JOIN CLEARING_LOCATION ON CLEARING_LOCATION.LOCATION_CODE=br.LOCATION_CODE
						LEFT OUTER JOIN CLEARING_ZONE ON CLEARING_ZONE.ZONE_CODE=br.CLEARING_ZONE
						WHERE br.STATUS =''L''					
						ORDER BY BANK_CODE,BRANCH_CODE
				END;
			ELSE
				BEGIN
					SELECT br.*,1,CLEARING_BANK.BANK_NAME,
						CLEARING_LOCATION.LOCATION_NAME,
						CLEARING_ZONE.ZONE_NAME,''S'' = 
						CASE  
							WHEN br.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CLEARING_BRANCH br
						LEFT OUTER JOIN CLEARING_BANK ON CLEARING_BANK.BANK_CODE=br.BANK_CODE
						LEFT OUTER JOIN CLEARING_LOCATION ON CLEARING_LOCATION.LOCATION_CODE=br.LOCATION_CODE
						LEFT OUTER JOIN CLEARING_ZONE ON CLEARING_ZONE.ZONE_CODE=br.CLEARING_ZONE
						WHERE br.STATUS in (''L'',''D'')					
						ORDER BY BANK_CODE,BRANCH_CODE
				END;
		END;	

	
	   
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_MonthBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 29-May-13
-- Description: Process for Monthly Bill
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_MonthBill]			
	@START_DATE	DATETIME,
	@END_DATE	DATETIME
AS
BEGIN	
				
	SET NOCOUNT ON;

	DELETE FROM TMP_MON_BILL;

	INSERT INTO TMP_MON_BILL(DS_CODE, D_CODE, CITICASH_AMOUNT, CITICHECK_AMOUNT, 
		SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, LOCATION_CODE, LOCATION_NAME, 
		ACC_NAME, CASH_CHARGE, SPEED_CHARGE, RETURN_CHARGE, CASH_STD_CHARGE, 
		SPEED_STD_CHARGE, CASH_VAT, SPEED_VAT, RETURN_AMOUNT, NO_OF_RETURN)
		SELECT ds.DS_CODE,ds.D_CODE,ISNULL(ds.CITICASH_AMOUNT,0) AS CITICASH_AMOUNT,
			ISNULL(ds.CITICHECK_AMOUNT,0) AS CITICHECK_AMOUNT,ds.SCHEDULE_DATE,
			ds.NO_CHECK,ds.CLIENT_CODE,ds.LOCATION_CODE,lo.LOCATION_NAME,
			cl.ACC_NAME,ISNULL(clc.CASH_CHARGE,cl.CASH_CHARGE) AS CASH_CHARGE,
			ISNULL(clc.SPEED_CHARGE,cl.SPEED_CHARGE) AS SPEED_CHARGE,cl.RETURN_CHARGE,
			cl.CASH_STD_CHARGE,cl.SPEED_STD_CHARGE,cl.CASH_VAT,cl.SPEED_VAT,
			ISNULL(rt.RETURN_AMOUNT,0) AS RETURN_AMOUNT,ISNULL(rt.NO_OF_RETURN,0) AS NO_OF_RETURN
			FROM DSCHEDULE ds
			INNER JOIN LOCATION lo ON lo.LOCATION_CODE=ds.LOCATION_CODE
			INNER JOIN CLIENT cl ON cl.CLIENT_CODE=ds.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE WHERE [STATUS]=''L'') clc 
			ON clc.LOCATION_CODE=ds.LOCATION_CODE AND clc.CLIENT_CODE=ds.CLIENT_CODE
			LEFT OUTER JOIN (SELECT D_CODE,SUM(AMOUNT) AS RETURN_AMOUNT, COUNT(D_CODE) AS NO_OF_RETURN
			FROM CSD_DET WHERE RTN_STATUS=''R''
			GROUP BY D_CODE) rt
			ON rt.D_CODE=ds.D_CODE
			WHERE SCHEDULE_DATE BETWEEN @START_DATE AND @END_DATE;

	         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_GetMismatchDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-May-13
-- Description:	Get CSD for mismatch total check no/check amount
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_GetMismatchDetail]			
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT a.*,b.* FROM
		CSD a INNER JOIN
		(SELECT ds.DS_CODE,ds.D_CODE,ds.CITICHECK_AMOUNT,ds.NO_CHECK ,
		COUNT(cdt.D_CODE) AS TOTCHECK, SUM(cdt.AMOUNT) TOTAMOUNT
		FROM DSCHEDULE ds 
		INNER JOIN CSD_DET cdt on cdt.D_CODE=ds.D_CODE
		WHERE ds.FILENAME IS NULL AND (DS.CHECKED=0 OR DS.CHECKED IS NULL) AND
		ds.DEPOSIT_TYPE=''Check''
		GROUP BY ds.DS_CODE,ds.D_CODE,ds.CITICHECK_AMOUNT,ds.NO_CHECK
		HAVING COUNT(cdt.D_CODE)<>ds.NO_CHECK OR SUM(cdt.AMOUNT)<>ds.CITICHECK_AMOUNT) b
		ON a.D_CODE=b.D_CODE
		WHERE a.STATUS=''L'';
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetMissingDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-May-13
-- Description:	Get dschedule for missing citicash/citispeed entry
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetMissingDetail]			
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT a.* FROM
		(SELECT ds.* FROM DSCHEDULE ds			
			LEFT OUTER JOIN CCASH cc ON ds.D_CODE=cc.D_CODE
			WHERE ds.[FILENAME] IS NULL AND ds.DEPOSIT_TYPE=''Cash'' and cc.D_CODE IS NULL
		UNION ALL
		SELECT ds.* FROM DSCHEDULE ds
			LEFT OUTER JOIN CSD_DET cs ON ds.D_CODE=cs.D_CODE
			WHERE ds.[FILENAME] IS NULL AND ds.DEPOSIT_TYPE=''Check'' and cs.D_CODE IS NULL)a
		INNER JOIN DCOLLECTED dc
		ON dc.DS_CODE=a.DS_CODE 
		WHERE dc.[STATUS]=''L''
			
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_Revgenerate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for reversal
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_Revgenerate]	
AS
BEGIN	

	UPDATE CCMSREF_TAB SET STATUS_ID=1, AUTHORIZE=1   
		WHERE D_CODE IN  
			(SELECT a.D_CODE    
				FROM CCMSREF_TAB a , DSCHEDULE b    
				WHERE   
				A.D_CODE = B.D_CODE   
				AND a.FILENAME IS NULL   
				AND b.DS_CODE IN (SELECT DS_CODE FROM CSCHEDULE)   
			) 
  
	UPDATE CCMSREF_TAB SET STATUS_ID=1, AUTHORIZE=1   
		WHERE D_CODE IN  
			(SELECT a.D_CODE    
				FROM CCMSREF_TAB a , DSCHEDULE b 
				WHERE
				A.D_CODE = B.D_CODE
				AND a.FILENAME IS NULL   
				AND a.REV_DATE=b.SCHEDULE_DATE
			) 
 
 ----- che

	DELETE FROM TMP_REVERSAL ;
	INSERT INTO TMP_REVERSAL(CR_TYPE,REF_NO,VALUE_DATE,LOCATION_CODE,REV_DATE,
		ACC_NO,REFACC_NO,CLIENT_CODE,AMOUNT,DEPOSIT_TYPE,
		DS_CODE,CHECKDS_NO,CUSTOMER_REF)                  
		SELECT c.CASH_CR_TYPE,a.REF_NO,a.VALUE_DATE,b.LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.CITICASH_AMOUNT) as total,b.DEPOSIT_TYPE,
			'''' as D_CODE ,'''' CHECKDS_NO ,''''
			FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c
			WHERE
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))
			AND b.CITICASH_AMOUNT>0
			AND a.D_CODE=b.D_CODE
			AND b.CLIENT_CODE=c.CLIENT_CODE
			AND a.FILENAME IS NULL
			AND c.CASH_CR_TYPE=''L''
			AND (a.STATUS_ID=1)    
			AND (a.AUTHORIZE =1)     
			GROUP BY a.REV_DATE,a.REF_NO,b.LOCATION_CODE,b.CLIENT_CODE,a.VALUE_DATE,c.CASH_CR_TYPE,                  
				a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE                  
		UNION ALL                  
--\\\\\\by deposit\\\\\\\\\\\\\                  
		SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.CITICASH_AMOUNT) as total,b.DEPOSIT_TYPE,
			b.D_CODE ,isnull(b.D_CODE,'''') CHECKDS_NO ,isnull(d.customer_ref,'''')customer_ref
			FROM CCMSREF_TAB a ,DSCHEDULE b
			LEFT OUTER JOIN ccash d on d.D_CODE=b.D_CODE,CLIENT c
			WHERE
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))                     
			AND b.CITICASH_AMOUNT>0
			AND a.D_CODE=b.D_CODE
			AND b.CLIENT_CODE=c.CLIENT_CODE
			AND a.FILENAME IS NULL
			AND c.CASH_CR_TYPE=''D''                  
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1 )
			GROUP BY a.REV_DATE,a.REF_NO,b.CLIENT_CODE,a.VALUE_DATE,b.LOCATION_CODE,c.CASH_CR_TYPE,
			a.ACC_NO,a.REFACC_NO ,b.D_CODE,b.DEPOSIT_TYPE,d.customer_ref      
--\\\\\total\\\\\\\\\\\\\\\                  
		UNION ALL
		SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,''000'' as LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.CITICASH_AMOUNT) as total,b.DEPOSIT_TYPE,
			substring(CONVERT(varchar(12), VALUE_DATE,112),3,8)as D_CODE, CONVERT(varchar,count(b.CITICASH_AMOUNT)) CHECKDS_NO,''''
			FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c
			WHERE
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))
			AND b.CITICASH_AMOUNT>0
			AND a.D_CODE=b.D_CODE
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND a.FILENAME IS NULL 
			AND c.CASH_CR_TYPE=''T''
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  )
			GROUP BY a.REV_DATE,a.REF_NO,b.CLIENT_CODE,a.VALUE_DATE,c.CASH_CR_TYPE, 
			a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE           
----########################By Ref no ###############               
		UNION ALL                 
		SELECT c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,''000'' as LOCATION_CODE,a.REV_DATE,a.ACC_NO,a.REFACC_NO,
			b.CLIENT_CODE,b.CITICASH_AMOUNT as total,b.DEPOSIT_TYPE,left(rtrim(d.CASH_REF ),10) as D_CODE ,  d.D_CODE CHECKDS_NO ,d.customer_ref 
			FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c,ccash d
			WHERE
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate())) 
			AND b.CITICASH_AMOUNT>0
			AND a.D_CODE=b.D_CODE
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND a.FILENAME IS NULL 
			AND d.D_CODE=b.D_CODE
			AND c.CASH_CR_TYPE=''R''
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  )			  
----------------                  
	INSERT INTO TMP_REVERSAL( CR_TYPE,REF_NO,VALUE_DATE,LOCATION_CODE,REV_DATE, 
		ACC_NO,REFACC_NO,CLIENT_CODE,AMOUNT,b.DEPOSIT_TYPE,
		b.DS_CODE,CHECKDS_NO,CUSTOMER_REF)
		SELECT c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.citicheck_AMOUNT) as total,b.DEPOSIT_TYPE,
			'''' as D_CODE , '''' CHECKDS_NO ,'''' CUSTOMER_REF
			FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c 
			WHERE 
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))			                   
			AND b.citicheck_AMOUNT>0
			AND a.D_CODE=b.D_CODE       
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND a.FILENAME IS NULL			                 
			AND c.SPEED_CR_TYPE=''L''
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  ) 
			GROUP BY a.REV_DATE,b.LOCATION_CODE,a.REF_NO,b.CLIENT_CODE,a.VALUE_DATE,c.SPEED_CR_TYPE,
			a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE                
		UNION ALL 
----By Deposit  
		SELECT c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.citicheck_AMOUNT) as total,b.DEPOSIT_TYPE,
			b.D_CODE , b.D_CODE CHECKDS_NO,''''customer_ref
			FROM CCMSREF_TAB a ,DSCHEDULE b
			,CLIENT c
			WHERE
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))
			AND b.citicheck_AMOUNT>0 
			AND a.D_CODE=b.D_CODE 
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND c.SPEED_CR_TYPE=''D''
			AND a.FILENAME IS NULL
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  )
			GROUP BY a.REV_DATE,a.REF_NO,b.DS_CODE,b.CLIENT_CODE,a.VALUE_DATE,c.SPEED_CR_TYPE,b.LOCATION_CODE,                  
			a.ACC_NO,a.REFACC_NO,b.D_CODE,b.DEPOSIT_TYPE                      
		UNION ALL                
------By Total                  
		SELECT c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,''000'' as LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,SUM(b.citicheck_AMOUNT) as total,b.DEPOSIT_TYPE,
			substring(CONVERT(varchar(10), VALUE_DATE,112),3,8) , '''' CHECKDS_NO ,''''
			FROM CCMSREF_TAB a ,DSCHEDULE b,CLIENT c 
			WHERE 
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))
			AND b.citicheck_AMOUNT>0 
			AND a.D_CODE=b.D_CODE
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND a.FILENAME IS NULL 
			AND c.SPEED_CR_TYPE=''T''
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  ) 
			GROUP BY a.REV_DATE,b.CLIENT_CODE,a.VALUE_DATE,a.REF_NO,c.SPEED_CR_TYPE, 
			a.ACC_NO,a.REFACC_NO,b.DEPOSIT_TYPE 
		UNION ALL 
--\\\\\\\\\\\\\\\By Check\\\\\\\\ 
		SELECT  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,D.AMOUNT,b.DEPOSIT_TYPE,
			d.check_no , b.D_CODE CHECKDS_NO  ,d.Customer_Ref 
			FROM CCMSREF_TAB a,CLIENT c,DSCHEDULE b,csd_det d 
			WHERE
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate())) 
			AND d.AMOUNT>0 
			AND a.D_CODE=b.D_CODE 
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND a.D_CODE=d.D_CODE 
			AND a.FILENAME IS NULL 
			AND c.SPEED_CR_TYPE=''C''
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  ) 
		UNION ALL         
		SELECT  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.LOCATION_CODE,a.REV_DATE,
			a.ACC_NO,a.REFACC_NO,b.CLIENT_CODE,D.AMOUNT,b.DEPOSIT_TYPE,
			left(d.CHECK_REF,10)  ,  b.D_CODE CHECKDS_NO ,d.Customer_Ref 
			FROM CCMSREF_TAB a,CLIENT c,DSCHEDULE b,csd_det d 
			WHERE 
			CONVERT(datetime,CONVERT(varchar(12), a.REV_DATE)) <= CONVERT(datetime,CONVERT(varchar(12), getdate()))
			AND d.AMOUNT>0
			AND a.D_CODE=b.D_CODE 
			AND b.CLIENT_CODE=c.CLIENT_CODE 
			AND a.D_CODE=d.D_CODE 
			AND a.FILENAME IS NULL 
			AND c.SPEED_CR_TYPE=''R'' 
			AND ( a.STATUS_ID=1 )
			AND ( a.AUTHORIZE =1  ) 
			ORDER BY a.REF_NO
         
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Jan-13
-- Description:	Remove record from CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_Remove]	
	@D_CODE		varchar(12),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from CSD
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CSD
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CSD_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CSD_HIST (D_CODE,				
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@D_CODE,				
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE CSD_DET_HIST
				WHERE D_CODE=@D_CODE AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO CSD_DET_HIST(D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
					AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, 
					DRAWEE_BRANCH, CHECK_REF, RTN_STATUS, 
					MOD_NO, IS_AUTH, RTN_CODE)
				SELECT D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
					AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, 
					DRAWEE_BRANCH, CHECK_REF, RTN_STATUS,
					@RET_MOD_NO,0, RTN_CODE
				FROM CSD_DET
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT D_CODE from CSD_HIST 
					  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CSD_HIST
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE CSD_DET_HIST 
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Jan-13
-- Description:	Authorize record to CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_Auth]	
	@D_CODE			varchar(12),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),		
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),
			@LAST_MOD_NO		int,
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from CSD_HIST 
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],	
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CSD_HIST 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CSD_HIST 
				SELECT *,1 FROM CSD
				WHERE D_CODE=@D_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CSD_HIST
				SET [STATUS] = ''O'' 
				WHERE D_CODE=@D_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CSD
				SET				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE D_CODE=@D_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CSD_HIST WHERE D_CODE=@D_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN

			IF NOT EXISTS(SELECT D_CODE FROM DSCHEDULE
				WHERE D_CODE=@D_CODE)
			BEGIN
				-- parent not exist
				ROLLBACK TRANSACTION;
				RETURN 11;
			END
			
			INSERT INTO CSD
				SELECT D_CODE, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CSD_HIST
					WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CSD_HIST WHERE D_CODE=@D_CODE
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update CSD_DET

	INSERT INTO CSD_DET_HIST(D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
		AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, DRAWEE_BRANCH, CHECK_REF, 
		RTN_STATUS, MOD_NO, IS_AUTH, RTN_CODE)
		SELECT D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
		AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, DRAWEE_BRANCH, CHECK_REF, 
		RTN_STATUS, MOD_NO, 1, RTN_CODE
		FROM CSD_DET
		WHERE D_CODE=@D_CODE;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE CSD_DET WHERE D_CODE=@D_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO CSD_DET(D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
		AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, DRAWEE_BRANCH, CHECK_REF, 
		RTN_STATUS, MOD_NO, RTN_CODE)
		SELECT D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
		AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, DRAWEE_BRANCH, CHECK_REF, 
		RTN_STATUS, MOD_NO, RTN_CODE
		FROM CSD_DET_HIST 
		WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE CSD_DET_HIST WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jan-13
-- Description:	Authorize record to DCollected
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_Auth]	
	@DS_CODE		varchar(12),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@TOTAL_NOCHK	numeric(4,0), 
			@TOTAL_CHKAMT	numeric(12,2), 
			@TOTAL_CASHAMT	numeric(12,2),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit,
			@vSlipDate		datetime,
			@vDCode			varchar(12);			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT DS_CODE from DCOLLECTED_HIST 
			  WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_NOCHK=TOTAL_NOCHK, 
				@TOTAL_CHKAMT=TOTAL_CHKAMT, @TOTAL_CASHAMT=TOTAL_CASHAMT,	
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM DCOLLECTED_HIST 
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO DCOLLECTED_HIST(DS_CODE, TOTAL_NOCHK, TOTAL_CHKAMT, 
				TOTAL_CASHAMT, INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], IS_AUTH, ENTRY_DATE) 
				SELECT DS_CODE, TOTAL_NOCHK, TOTAL_CHKAMT, 
					TOTAL_CASHAMT, INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, 
					AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 1,ENTRY_DATE 
					FROM DCOLLECTED
					WHERE DS_CODE=@DS_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE DCOLLECTED_HIST
				SET [STATUS] = ''O'' 
				WHERE DS_CODE=@DS_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE DCOLLECTED
				SET
				TOTAL_NOCHK=@TOTAL_NOCHK,
				TOTAL_CHKAMT=@TOTAL_CHKAMT, TOTAL_CASHAMT=@TOTAL_CASHAMT,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE DS_CODE=@DS_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO DCOLLECTED
				SELECT DS_CODE,TOTAL_NOCHK, TOTAL_CHKAMT, TOTAL_CASHAMT, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'', ENTRY_DATE 
					FROM DCOLLECTED_HIST
					WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update DSCHEDULE

	INSERT INTO DSCHEDULE_HIST(DS_CODE, D_CODE, DEPOSIT_TYPE, 
		CITICASH_AMOUNT, CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, 
		CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
		MOD_NO, IS_AUTH, [FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, 
		CHECKED, FLEXGEN_DATE,
		SLNO,IS_ROW_CHG)
		SELECT DS_CODE, D_CODE, DEPOSIT_TYPE, 
		CITICASH_AMOUNT, CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, 
		CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
		MOD_NO, 1, [FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, 
		CHECKED, FLEXGEN_DATE,
		SLNO,IS_ROW_CHG
		FROM DSCHEDULE
		WHERE DS_CODE=@DS_CODE;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE DSCHEDULE WHERE DS_CODE=@DS_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO DSCHEDULE(DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT, 
		CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, 
		LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, MOD_NO, 
		[FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, CHECKED, 
		FLEXGEN_DATE, SLNO, IS_ROW_CHG)
		SELECT DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT, 
		CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, 
		LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, MOD_NO, 
		[FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, CHECKED, 
		FLEXGEN_DATE, SLNO, IS_ROW_CHG
		FROM DSCHEDULE_HIST 
		WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE DSCHEDULE_HIST WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	---------------- update slip_date of ccash and csd_det -----------

	DECLARE tmpCursor1 CURSOR FOR
		SELECT D_CODE,SCHEDULE_DATE
        FROM DSCHEDULE WHERE DS_CODE=@DS_CODE ;

	OPEN tmpCursor1;
	FETCH NEXT FROM tmpCursor1 
        INTO @vDCode,@vSlipDate;
	
	WHILE @@FETCH_STATUS=0 
 	BEGIN
		UPDATE CCASH SET SLIP_DATE=@vSlipDate
			WHERE D_CODE=@vDCode;
		
		UPDATE CCASH_HIST SET SLIP_DATE=@vSlipDate
			WHERE D_CODE=@vDCode AND IS_AUTH=0;

		UPDATE CSD_DET SET SLIP_DATE=@vSlipDate
			WHERE D_CODE=@vDCode;
		
		UPDATE CSD_DET_HIST SET SLIP_DATE=@vSlipDate
			WHERE D_CODE=@vDCode AND IS_AUTH=0;
		
		FETCH NEXT FROM tmpCursor1 
			INTO @vDCode,@vSlipDate;

	END

	CLOSE tmpCursor1;
	DEALLOCATE tmpCursor1;

	-------------------------------
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Authorize record to RETURN_CSD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnCSD_Auth]	
	@D_CODE				varchar(12), 
	@SLNO				numeric(3,0),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@RTN_STATUS 	char(1),
			@RTN_CODE 		varchar(2),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from RETURN_CSD_HIST 
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@RTN_STATUS=RTN_STATUS,@RTN_CODE=RTN_CODE,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM RETURN_CSD_HIST 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO RETURN_CSD_HIST(D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], IS_AUTH)
				SELECT D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS],1 
				FROM RETURN_CSD
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE RETURN_CSD_HIST
				SET [STATUS] = ''O'' 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE RETURN_CSD
				SET RTN_STATUS=@RTN_STATUS,RTN_CODE=@RTN_CODE,			
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE RETURN_CSD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO RETURN_CSD(D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS])
				SELECT D_CODE, SLNO, RTN_STATUS, RTN_CODE, 					 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM RETURN_CSD_HIST
					WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE RETURN_CSD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

	DELETE CSD_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;
	DELETE CSD_DET_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

	UPDATE CSD_DET SET RTN_STATUS=@RTN_STATUS,RTN_CODE=@RTN_CODE
		WHERE D_CODE=@D_CODE AND SLNO=@SLNO;

	COMMIT TRANSACTION
	
	SELECT @ErrorVar1 = @@error;
	
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Get detail to RETURN_CSD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnCSD_GetDetailList]		
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT rch.*,''S'' = ''U'',cdh.CHECK_NO,cdh.AMOUNT,d.DS_CODE			 
				FROM RETURN_CSD_HIST rch
				INNER JOIN CSD_DET cdh 
				ON cdh.D_CODE = rch.D_CODE AND cdh.SLNO=rch.SLNO
				INNER JOIN DSCHEDULE d ON d.D_CODE=cdh.D_CODE
				WHERE rch.IS_AUTH=0
				ORDER BY rch.D_CODE,rch.SLNO;			
		END;
	ELSE
		BEGIN
			
				SELECT rc.*,1,''S'' = ''U'',cdh.CHECK_NO,cdh.AMOUNT,d.DS_CODE			 
				FROM RETURN_CSD rc
				INNER JOIN CSD_DET cdh 
				ON cdh.D_CODE = rc.D_CODE AND cdh.SLNO=rc.SLNO
				INNER JOIN DSCHEDULE d ON d.D_CODE=cdh.D_CODE
				ORDER BY rc.D_CODE,rc.SLNO;
			
				
		END;	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSDDet_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Get detail of CSDDet by d_code,slno
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSDDet_GetDetailByCode]	
	@D_CODE	varchar(12)	,
	@SLNO numeric(3,0)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT csd.D_CODE,csd.SLNO,csd.CHECK_NO,csd.AMOUNT,b.BANK_NAME AS DRAWEE_BANK_NAME,
		csd.RTN_STATUS
	FROM CSD_DET csd 
	LEFT OUTER JOIN BANK b on b.BANK_CODE=csd.DRAWEE_BANK_CODE
	WHERE csd.D_CODE=@D_CODE AND csd.SLNO=@SLNO
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_UpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 12-Feb-13
-- Description:	Update return status of CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_UpdateStatus]
	@D_CODE		varchar(12),
	@SLNO		int,
	@RTN_STATUS char(1)
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@MOD_NO			numeric(3,0);			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from CSD_DET
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO)
		BEGIN
			SELECT @STATUS=[STATUS],				
				@MOD_NO=MOD_NO
				FROM CSD
				WHERE D_CODE=@D_CODE;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CSD_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			--SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CSD_HIST (D_CODE,				
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@D_CODE,				
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @MOD_NO + 1, 
				''U'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE CSD_DET_HIST
				WHERE D_CODE=@D_CODE AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO CSD_DET_HIST
				SELECT D_CODE, SLNO, CHECK_NO, DRAWER, DRAWEE_BANK_CODE, 
					AMOUNT, CUSTOMER_REF, SLIP_DATE, CHECK_DATE, 
					DRAWEE_BRANCH, CHECK_REF,RTN_STATUS,
					@MOD_NO + 1,0
				FROM CSD_DET
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			UPDATE CSD_DET_HIST
				SET RTN_STATUS=@RTN_STATUS
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO+1 AND SLNO=@SLNO

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;

		ROLLBACK TRANSACTION;
		RETURN 4; -- not exist
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Get detail of RETURN_CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnCSD_GetDetail]	
	@D_CODE		varchar(12),
	@SLNO		numeric(3,0), 	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM RETURN_CSD WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT rc.*,''IS_AUTH''=1 ,rr.REJECT_REASON, cd.CHECK_NO,cd.AMOUNT
			FROM RETURN_CSD rc
			INNER JOIN CSD_DET cd ON cd.D_CODE = rc.D_CODE AND cd.SLNO=rc.SLNO 
			LEFT OUTER JOIN RETURN_REJECT rr ON rr.REJECT_CODE=rc.RTN_CODE
			WHERE rc.D_CODE=@D_CODE AND rc.SLNO=@SLNO AND rc.MOD_NO = @MOD_NO

		END	
	ELSE
		BEGIN
			SELECT rch.* ,rr.REJECT_REASON, cd.CHECK_NO,cd.AMOUNT
			FROM RETURN_CSD_HIST rch
			INNER JOIN CSD_DET cd ON cd.D_CODE = rch.D_CODE AND cd.SLNO=rch.SLNO 
			LEFT OUTER JOIN RETURN_REJECT rr ON rr.REJECT_CODE=rch.RTN_CODE
			WHERE rch.D_CODE=@D_CODE AND rch.SLNO=@SLNO AND rch.MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSDDet_GetDetailsByDCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Get detail of CSDDet by d_code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSDDet_GetDetailsByDCode]	
	@D_CODE	varchar(12)	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT csd.D_CODE,csd.SLNO,csd.CHECK_NO,csd.AMOUNT,b.BANK_NAME AS DRAWEE_BANK_NAME,
		csd.RTN_STATUS
	FROM CSD_DET csd 
	LEFT OUTER JOIN BANK b on b.BANK_CODE=csd.DRAWEE_BANK_CODE
	WHERE csd.D_CODE=@D_CODE
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSDDet_GetDetailsByAmount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Jan-13
-- Description:	Get detail of CSDDet by ds_code and amount
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSDDet_GetDetailsByAmount]	
	@DS_CODE	varchar(12),	
	@AMOUNT		numeric(12,2)	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT csd.*,b.BANK_NAME AS DRAWEE_BANK_NAME
	FROM CSD_DET csd 
	INNER JOIN DSCHEDULE ds ON csd.D_CODE=ds.D_CODE
	LEFT OUTER JOIN BANK b on b.BANK_CODE=csd.DRAWEE_BANK_CODE
	WHERE ds.DS_CODE=@DS_CODE AND csd.AMOUNT=@AMOUNT
	AND ds.CLIENT_CODE<>''999999''

	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 10-Dec-12
-- Description:	Get Total # of modification of Schedule Stock
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_GetMaxMod]	
	@SCHEDULE_ID	tinyint,
	@BANK_CODE		varchar(4),
	@LOCATION_CODE	varchar(4)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM SCHEDULE_STOCK_HIST 
		WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
		AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM SCHEDULE_STOCK 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 10-Dec-12
-- Description:	Remove record from schedule stock
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_Remove]	
	@SCHEDULE_ID	tinyint,
	@BANK_CODE		varchar(4),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@SCHE_FROM		varchar(12),
			@SCHE_UPTO		varchar(12),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SCHEDULE_ID from SCHEDULE_STOCK 
				WHERE SCHEDULE_ID=@SCHEDULE_ID 
				AND BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@SCHE_FROM=SCHE_FROM,@SCHE_UPTO=SCHE_UPTO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM SCHEDULE_STOCK 
				WHERE SCHEDULE_ID=@SCHEDULE_ID 
				AND BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE SCHEDULE_STOCK_HIST 
				WHERE SCHEDULE_ID=@SCHEDULE_ID
				AND BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				SCHEDULE_STOCK_HIST (SCHEDULE_ID, BANK_CODE, LOCATION_CODE, 
				SCHE_FROM, SCHE_UPTO,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@SCHEDULE_ID, @BANK_CODE, @LOCATION_CODE, 
				@SCHE_FROM, @SCHE_UPTO,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT SCHEDULE_ID from SCHEDULE_STOCK_HIST 
						WHERE SCHEDULE_ID=@SCHEDULE_ID 
						AND BANK_CODE=@BANK_CODE 
						AND LOCATION_CODE=@LOCATION_CODE 
						AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE SCHEDULE_STOCK_HIST
						WHERE SCHEDULE_ID=@SCHEDULE_ID 
						AND BANK_CODE=@BANK_CODE 
						AND LOCATION_CODE=@LOCATION_CODE 
						AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 10-Dec-12
-- Description:	Get detail of Schedule Stock
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_GetDetail]	
	@SCHEDULE_ID	tinyint,
	@BANK_CODE		varchar(4),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT SCHEDULE_ID 
				FROM SCHEDULE_STOCK 
				WHERE SCHEDULE_ID=@SCHEDULE_ID 
				AND BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT s.*,''IS_AUTH''=1 ,b.BANK_NAME,l.LOCATION_NAME
			FROM SCHEDULE_STOCK s
			LEFT OUTER JOIN BANK b
			ON b.BANK_CODE=s.BANK_CODE
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=s.LOCATION_CODE
			WHERE s.SCHEDULE_ID=@SCHEDULE_ID 
			AND s.BANK_CODE=@BANK_CODE AND s.LOCATION_CODE=@LOCATION_CODE
			AND s.MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * ,b.BANK_NAME,l.LOCATION_NAME
			FROM SCHEDULE_STOCK_HIST sh
			LEFT OUTER JOIN BANK b
			ON b.BANK_CODE=sh.BANK_CODE
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=sh.LOCATION_CODE
			WHERE sh.SCHEDULE_ID=@SCHEDULE_ID 
			AND sh.BANK_CODE=@BANK_CODE AND sh.LOCATION_CODE=@LOCATION_CODE
			AND sh.MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 29-Nov-12
-- Description:	Get detail to Schedule Stock
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_GetDetailList]		
	@SCHEDULE_ID	tinyint,
	@DEL_FLAG		int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;
	
	IF @AUTH_FLAG=0
		BEGIN			
			
			SELECT sh.*,b.BANK_NAME,l.LOCATION_NAME,''S'' = ''U''				 
				FROM SCHEDULE_STOCK_HIST sh
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=sh.BANK_CODE
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=sh.LOCATION_CODE
				WHERE sh.IS_AUTH=0 AND sh.SCHEDULE_ID=@SCHEDULE_ID
				ORDER BY BANK_CODE,LOCATION_CODE
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN					

					SELECT s.*,1,b.BANK_NAME,l.LOCATION_NAME,''S'' = ''A''				
						FROM SCHEDULE_STOCK s
						LEFT OUTER JOIN BANK b
						ON b.BANK_CODE=s.BANK_CODE
						LEFT OUTER JOIN LOCATION l
						ON l.LOCATION_CODE=s.LOCATION_CODE
						WHERE s.STATUS =''L''	AND s.SCHEDULE_ID=@SCHEDULE_ID
						ORDER BY BANK_CODE,LOCATION_CODE;

				END;
			ELSE
				BEGIN					

					SELECT s.*,1,b.BANK_NAME,l.LOCATION_NAME,''S'' = 
							CASE  
								WHEN s.STATUS = ''D'' THEN ''D''                    
								ELSE ''A''
							END 
						FROM SCHEDULE_STOCK s
						LEFT OUTER JOIN BANK b
						ON b.BANK_CODE=s.BANK_CODE
						LEFT OUTER JOIN LOCATION l
						ON l.LOCATION_CODE=s.LOCATION_CODE
						WHERE s.STATUS in (''L'',''D'') AND s.SCHEDULE_ID=@SCHEDULE_ID				
						ORDER BY BANK_CODE,LOCATION_CODE
				END;
		END;

	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 29-Nov-12
-- Description:	Authorize record to Schedule Stock table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_Auth]
	@SCHEDULE_ID	tinyint,
	@BANK_CODE		varchar(4),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@SCHE_FROM		varchar(12),
			@SCHE_UPTO		varchar(12),	
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 


	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BANK_CODE from SCHEDULE_STOCK_HIST 
			  WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
			  AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@SCHE_FROM=SCHE_FROM, @SCHE_UPTO=SCHE_UPTO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM SCHEDULE_STOCK_HIST 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO SCHEDULE_STOCK_HIST 
				SELECT *,1 FROM SCHEDULE_STOCK
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE SCHEDULE_STOCK_HIST
				SET [STATUS] = ''O'' 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE SCHEDULE_STOCK
				SET SCHE_FROM=@SCHE_FROM,SCHE_UPTO=@SCHE_UPTO,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE SCHEDULE_STOCK_HIST 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO SCHEDULE_STOCK	 
				SELECT SCHEDULE_ID, BANK_CODE, 
					LOCATION_CODE, SCHE_FROM, SCHE_UPTO,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM SCHEDULE_STOCK_HIST
					WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
					AND LOCATION_CODE=@LOCATION_CODE 
					AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE SCHEDULE_STOCK_HIST 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Nov-12
-- Description:	update detail to schedule stock
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ScheduleStock_Update]	
	@SCHEDULE_ID	tinyint,	
	@BANK_CODE		varchar(4),		
	@LOCATION_CODE	varchar(4),
	@SCHE_FROM		varchar(12),
	@SCHE_UPTO		varchar(12),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BANK_CODE FROM SCHEDULE_STOCK 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE SCHEDULE_STOCK_HIST 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO SCHEDULE_STOCK_HIST(SCHEDULE_ID,BANK_CODE,
				LOCATION_CODE,SCHE_FROM,SCHE_UPTO,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@SCHEDULE_ID,@BANK_CODE,
				@LOCATION_CODE,@SCHE_FROM,@SCHE_UPTO,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT BANK_CODE from SCHEDULE_STOCK_HIST 
						WHERE SCHEDULE_ID=@SCHEDULE_ID 
						AND BANK_CODE=@BANK_CODE
						AND LOCATION_CODE=@LOCATION_CODE 
						AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE SCHEDULE_STOCK_HIST 
						WHERE SCHEDULE_ID=@SCHEDULE_ID 
						AND BANK_CODE=@BANK_CODE
						AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO SCHEDULE_STOCK_HIST(SCHEDULE_ID,BANK_CODE,
						LOCATION_CODE,SCHE_FROM,SCHE_UPTO,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@SCHEDULE_ID,@BANK_CODE,
						@LOCATION_CODE,@SCHE_FROM,@SCHE_UPTO,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ScheduleStock_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Nov-12
-- Description:	Add detail to Schedule Stock
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_Add]
	@SCHEDULE_ID	tinyint,	
	@BANK_CODE		varchar(4),		
	@LOCATION_CODE	varchar(4),
	@SCHE_FROM		varchar(12),
	@SCHE_UPTO		varchar(12)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BANK_CODE from SCHEDULE_STOCK 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE
				AND LOCATION_CODE=@LOCATION_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE SCHEDULE_STOCK_HIST WHERE 
		SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO SCHEDULE_STOCK_HIST(SCHEDULE_ID,BANK_CODE,LOCATION_CODE,
		SCHE_FROM,SCHE_UPTO,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@SCHEDULE_ID,@BANK_CODE, @LOCATION_CODE,
		@SCHE_FROM,@SCHE_UPTO,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSDDet_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Jan-13
-- Description:	update detail to CSD det
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CSDDet_Update]
	@D_CODE				varchar(12), 
	@SLNO				numeric(3,0), 
	@CHECK_NO			varchar(15), 
	@DRAWER				varchar(50), 
	@DRAWEE_BANK_CODE	varchar(4), 
	@AMOUNT				numeric(12,2), 
	@CUSTOMER_REF		varchar(15), 
	@SLIP_DATE			datetime, 
	@CHECK_DATE			datetime, 
	@DRAWEE_BRANCH		varchar(50),
	@CHECK_REF			varchar(15),
	@MOD_NO				int	,
	@RTN_STATUS			char(1),
	@RTN_CODE			varchar(2)
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO CSD_DET_HIST(D_CODE, SLNO, CHECK_NO, DRAWER, 
		DRAWEE_BANK_CODE, AMOUNT,CUSTOMER_REF, SLIP_DATE, CHECK_DATE,
		DRAWEE_BRANCH, CHECK_REF,RTN_STATUS,
		MOD_NO, IS_AUTH, RTN_CODE)
		VALUES(@D_CODE, @SLNO, @CHECK_NO, @DRAWER, 
		@DRAWEE_BANK_CODE, @AMOUNT,@CUSTOMER_REF, @SLIP_DATE, @CHECK_DATE,
		@DRAWEE_BRANCH, @CHECK_REF,@RTN_STATUS,
		@MOD_NO, 0, @RTN_CODE)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSDDet_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Jan-13
-- Description:	Add detail to CSD_DET
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSDDet_Add]	
	@D_CODE				varchar(12), 
	@SLNO				numeric(3,0), 
	@CHECK_NO			varchar(15), 
	@DRAWER				varchar(50), 
	@DRAWEE_BANK_CODE	varchar(4), 
	@AMOUNT				numeric(12,2), 
	@CUSTOMER_REF		varchar(15), 
	@SLIP_DATE			datetime, 
	@CHECK_DATE			datetime, 
	@DRAWEE_BRANCH		varchar(50),
	@CHECK_REF			varchar(15)	
AS
BEGIN	
	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CSD_DET_HIST(D_CODE, SLNO, CHECK_NO, DRAWER, 
		DRAWEE_BANK_CODE, AMOUNT,CUSTOMER_REF, SLIP_DATE, CHECK_DATE,
		DRAWEE_BRANCH, CHECK_REF,RTN_STATUS,
		MOD_NO,IS_AUTH)
		VALUES(@D_CODE, @SLNO, @CHECK_NO, @DRAWER, 
		@DRAWEE_BANK_CODE, @AMOUNT,@CUSTOMER_REF, @SLIP_DATE, @CHECK_DATE,
		@DRAWEE_BRANCH, @CHECK_REF,''O'',
		1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_ClearingDataReturnUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Aug-13
-- Description: Update Clearing Return  Final
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_ClearingDataReturnUpdate]
	@OPR_DATE		datetime,	
	@ENTRY_LOC		varchar(3),
	@FLEX_FILENAME	varchar(15),
	@REFACC_NO		varchar(16)
AS
BEGIN

	INSERT INTO REVERSAL_HIST_CLEARING_RET(AMOUNT, VALUE_DATE, 
		USERID, 
		FLEX_FILENAME, REFACC_NO, ACC_NO, ENTRY_LOC, DS_CODE, CHECK_NUMBER)
		SELECT rc.AMOUNT,@OPR_DATE,
			substring(suser_name(),charindex(''\'',suser_name())+1,20),
			@FLEX_FILENAME,@REFACC_NO,ct.REMARK,@ENTRY_LOC,ct.DS_CODE,rc.CHECK_NUMBER
			FROM CLEARINGTAB ct
			INNER JOIN RETURN_CLEARING rc
			ON ct.MID=rc.MID AND ct.DSL=rc.DSL
			WHERE rc.RTN_FILENAME IS NULL
			AND ct.OPR_DATE <=@OPR_DATE AND ct.ENTRY_LOC=@ENTRY_LOC;

	UPDATE RETURN_CLEARING 
		SET RTN_FILENAME=@FLEX_FILENAME,
		RTN_FILE_USERID=substring(suser_name(),charindex(''\'',suser_name())+1,20)	
		WHERE RTN_FILENAME IS NULL
		AND MID IN 
			(SELECT ct.MID 
			FROM CLEARINGTAB ct
			WHERE ct.RTN_STATUS=''R'' AND 
			ct.OPR_DATE<=@OPR_DATE AND
			ct.ENTRY_LOC=@ENTRY_LOC
		)
	
		
	

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Remove record from RETURN_CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnCSD_Remove]	
	@D_CODE				varchar(12), 
	@SLNO				numeric(3,0),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@RTN_STATUS 	char(1),
			@RTN_CODE 		varchar(2);			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from RETURN_CSD 
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@RTN_STATUS=RTN_STATUS,
				@RTN_CODE=RTN_CODE
				FROM RETURN_CSD 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE RETURN_CSD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				RETURN_CSD_HIST (D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@D_CODE, @SLNO, @RTN_STATUS, @RTN_CODE, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT D_CODE from RETURN_CSD_HIST 
					  WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE RETURN_CSD_HIST
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	update detail to Return_CSD table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ReturnCSD_Update]	
	@D_CODE				varchar(12), 
	@SLNO				numeric(3,0), 
	@RTN_STATUS			char(1), 
	@RTN_CODE			varchar(2),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE FROM RETURN_CSD 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE RETURN_CSD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO RETURN_CSD_HIST(D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
				INPUT_BY, 
				INPUT_DATETIME,INPUT_FROM,  
				MOD_NO, [STATUS], IS_AUTH)
				VALUES(@D_CODE, @SLNO, @RTN_STATUS, @RTN_CODE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),
				@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT D_CODE from RETURN_CSD_HIST 
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE RETURN_CSD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO RETURN_CSD_HIST(D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
						INPUT_BY, 
						INPUT_DATETIME,INPUT_FROM,  
						MOD_NO, [STATUS], IS_AUTH)
						VALUES(@D_CODE, @SLNO, @RTN_STATUS, @RTN_CODE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),
						@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Get Total # of modification of RETURN_CSD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnCSD_GetMaxMod]	
	@D_CODE		varchar(12),
	@SLNO		numeric(3,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM RETURN_CSD_HIST 
		WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM RETURN_CSD 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Add detail to Menu table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Menu_Add]	
	@MENU_NAME		varchar(60),
	@RET_SLNO		numeric(3,0) output	
AS
BEGIN	
	DECLARE @ErrorVar	int,
			@MaxS1		int,
			@MaxS2		int;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO FROM MENU_LIST WHERE MENU_NAME=@MENU_NAME)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE MENU_LIST_HIST WHERE 
		MENU_NAME=@MENU_NAME AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
		
	SELECT @MaxS1=ISNULL(MAX(SLNO),0) FROM MENU_LIST;
	SELECT @MaxS2=ISNULL(MAX(SLNO),0) FROM MENU_LIST_HIST;

	IF @MaxS1>@MaxS2
		BEGIN
			SELECT @RET_SLNO = @MaxS1 + 1;
		END
	ELSE
		BEGIN
			SELECT @RET_SLNO = @MaxS2 + 1;
		END
		

	INSERT INTO MENU_LIST_HIST(SLNO,MENU_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@RET_SLNO,@MENU_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Authorize record to menu_list table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Menu_Auth]	
	@SLNO			numeric(6,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@MENU_NAME		varchar(60),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO from MENU_LIST_HIST 
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@MENU_NAME=MENU_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM MENU_LIST_HIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO MENU_LIST_HIST 
				SELECT *,1 FROM MENU_LIST
				WHERE SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE MENU_LIST_HIST
				SET [STATUS] = ''O'' 
				WHERE SLNO=@SLNO
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE MENU_LIST
				SET MENU_NAME=@MENU_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE MENU_LIST_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO MENU_LIST
				SELECT SLNO,MENU_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM MENU_LIST_HIST
					WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE MENU_LIST_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION;
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Get detail of menu_list table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Menu_GetDetail]	
	@SLNO		numeric(6,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT SLNO 
			   FROM MENU_LIST WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM MENU_LIST 
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM MENU_LIST_HIST
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	update detail to menu_list table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Menu_Update]	
	@SLNO			numeric(6,0),
	@MENU_NAME 	varchar(60),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO FROM MENU_LIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE MENU_LIST_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO MENU_LIST_HIST(SLNO,MENU_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@SLNO,@MENU_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT SLNO from MENU_LIST_HIST 
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE MENU_LIST_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO MENU_LIST_HIST(SLNO,MENU_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@SLNO,@MENU_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Remove record from menu_list table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Menu_Remove]	
	@SLNO			numeric(6,0),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@MENU_NAME 		varchar(60),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SLNO from MENU_LIST
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@MENU_NAME=MENU_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM MENU_LIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE MENU_LIST_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				MENU_LIST_HIST (SLNO,MENU_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@SLNO,@MENU_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT SLNO from MENU_LIST_HIST 
					  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE MENU_LIST_HIST
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Get Total # of modification of menu_hist table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Menu_GetMaxMod]	
	@SLNO		numeric(3,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM MENU_LIST_HIST 
		WHERE SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM MENU_LIST
				WHERE SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Menu_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Get detail of menu_list  table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Menu_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,''S'' = ''U''				 
			FROM MENU_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,''S'' = ''A''				
			FROM MENU_LIST
			WHERE STATUS =''L''					
			ORDER BY IS_AUTH,MENU_NAME

		END
	ELSE
		BEGIN	

			SELECT *,''S'' = ''U''				 
			FROM MENU_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,''S'' = 
				CASE  
					WHEN STATUS = ''D'' THEN ''D''                    
					ELSE ''A''
                END 
			FROM MENU_LIST
			WHERE STATUS in (''L'',''D'')					
			ORDER BY IS_AUTH,MENU_NAME

		END
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Fahad Khan
-- Create date: 02-Mar-13
-- Description:	Authorize record to DD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_Auth]	
	@D_CODE			varchar(12),	
	@MOD_NO			int,
    @SLNO           numeric(3,0),
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@RTN_STATUS			char(1),
			@CC_RTN_STATUS		char(1),
			@DD_DATE			datetime,					
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),
			@LAST_MOD_NO		int,
			@NONZONE_REF		varchar(7),
			@CLIENT_CODE		varchar(6),
			@DLOCATION_CODE		varchar(4),
			@CUSTOMER_REF		varchar(15),
			@SLIP_DATE			datetime,
			@VALUE_DATE			datetime,
			@CHECK_NO			varchar(15),
			@AMOUNT				numeric(12, 2),
			@CHECK_DATE			datetime,
			@CHECK_TYPE			varchar(7),
			@DRAWER				varchar(50),
			@DRAWER_BANKCODE	varchar(4),
			@DRAWEE_BANK_CODE	varchar(4),
			@DRAWER_BRANCHCODE	varchar(4),
			@LOCATION_CODE		varchar(4),
			@DRAWER_LOCATION	varchar(4),
			@NIKBRANCH_CODE		varchar(7),
			@DRAWEE_BRANCH		varchar(25),
			@BRANCH_CODE		varchar(4),
			@CHECK_REF			varchar(15),
			@VAT				numeric(12, 2),
			@COMMISION			numeric(12, 2),
			@POSTAGE_CHARGE		numeric(12, 2),
			@INSTRUMENT_EXP		numeric(12, 2),
			@CHECKREF			varchar(15),
			@IS_AUTH			bit,	
			@DEPO_CODE			varchar(12)	,
			@CC_MOD_NO			int,
			@DN_CODE			varchar(12),
			@DN_SLNO			int,
			--@DD_MOD				int,
			@REF_DATE			datetime
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from DD_HIST 
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND SLNO=@SLNO)
		BEGIN
			SELECT @DD_DATE=DD_DATE,@AMOUNT=AMOUNT,@DRAWER_BANKCODE=DRAWER_BANKCODE,
                @DRAWER_BRANCHCODE=DRAWER_BRANCHCODE,@DRAWER_LOCATION=DRAWER_LOCATION,
                @DRAWEE_BRANCH=DRAWEE_BRANCH,@NIKBRANCH_CODE=NIKBRANCH_CODE,@VAT=VAT,
                @COMMISION=COMMISION,@POSTAGE_CHARGE=POSTAGE_CHARGE,@INSTRUMENT_EXP=INSTRUMENT_EXP,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH, @RTN_STATUS=RTN_STATUS, @STATUS=[STATUS]
				FROM DD_HIST 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND SLNO=@SLNO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO DD_HIST 
				SELECT *,1 FROM DD
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE DD_HIST
				SET [STATUS] = ''O'' 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE DD
				SET	DD_DATE=@DD_DATE,AMOUNT=@AMOUNT,DRAWER_BANKCODE=@DRAWER_BANKCODE,
                DRAWER_BRANCHCODE=@DRAWER_BRANCHCODE,DRAWER_LOCATION=@DRAWER_LOCATION,
                DRAWEE_BRANCH=@DRAWEE_BRANCH,NIKBRANCH_CODE=@NIKBRANCH_CODE,VAT=@VAT,
                COMMISION=@COMMISION,POSTAGE_CHARGE=@POSTAGE_CHARGE,INSTRUMENT_EXP=@INSTRUMENT_EXP,			
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,RTN_STATUS =@RTN_STATUS,[STATUS]=@STATUS
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE DD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO
				AND IS_AUTH=0;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO DD
			    SELECT D_CODE,SLNO,DD_NO,DD_DATE,AMOUNT,DRAWER_BANKCODE,
					DRAWER_BRANCHCODE, DRAWER_LOCATION,DRAWEE_BRANCH,
					NIKBRANCH_CODE,VAT,COMMISION,POSTAGE_CHARGE,INSTRUMENT_EXP,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, RTN_STATUS, ''L'' 
				FROM DD_HIST
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND SLNO=@SLNO;
		
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE DD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END;

    -- Update CCHECK TOTAL AND CCHECK record

	DECLARE tempRows CURSOR FOR
        SELECT DISTINCT D_CODE 
		FROM CCHECK 
		WHERE NONZONE_REF IN 
			(SELECT NONZONE_REF 
			FROM DD_CCHECK_HIST 
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
 
	OPEN tempRows;
	
	FETCH NEXT FROM tempRows
		INTO @DEPO_CODE ;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		DELETE CCHECKTOTAL_HIST
			WHERE D_CODE=@DEPO_CODE AND IS_AUTH=0;
                
		INSERT INTO CCHECKTOTAL_HIST 
			SELECT D_CODE,TOTAL_CHKNO,TOTAL_CHKAMT,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,
				AUTH_BY,AUTH_DATETIME,AUTH_FROM,MOD_NO,[STATUS],1
				FROM CCHECKTOTAL
				WHERE D_CODE =@DEPO_CODE

		IF @ErrorVar1 <> 0
			BEGIN
				ROLLBACK TRANSACTION;
				RETURN 1;
			END

		UPDATE CCHECKTOTAL_HIST 
			SET [STATUS] = ''O'' 
			WHERE D_CODE=@DEPO_CODE AND [STATUS] = ''L'';

		SELECT @ErrorVar1 = @@error;

		IF @ErrorVar1 <> 0
			BEGIN
				ROLLBACK TRANSACTION;
				RETURN 1;
			END

		UPDATE CCHECKTOTAL 
			SET INPUT_BY=@INPUT_BY,INPUT_DATETIME=@INPUT_DATETIME,
			INPUT_FROM=@INPUT_FROM,
			AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
			AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(), MOD_NO=MOD_NO+1 
			WHERE D_CODE=@DEPO_CODE;

		SELECT @ErrorVar1 = @@error;

		IF @ErrorVar1 <> 0
			BEGIN
				ROLLBACK TRANSACTION;
				RETURN 1;
			END
            
		INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
			CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE,
			CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
			CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH, 
			REMINDER_DATE, REMINDER_NO, RTN_CODE)
		    SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
			CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
			CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
			CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO,1, 
			REMINDER_DATE, REMINDER_NO, RTN_CODE 
			FROM CCHECK
			WHERE D_CODE=@DEPO_CODE;

		SELECT @ErrorVar1 = @@error;

		IF @ErrorVar1 <> 0
			BEGIN
				ROLLBACK TRANSACTION;
				RETURN 1;
			END

		UPDATE CCHECK SET MOD_NO=MOD_NO+1 
			WHERE D_CODE=@DEPO_CODE;

		SELECT @ErrorVar1 = @@error;

		IF @ErrorVar1 <> 0
			BEGIN
				ROLLBACK TRANSACTION;
				RETURN 1;
			END

		FETCH NEXT FROM tempRows
			INTO @DEPO_CODE;
            
	END

    CLOSE tempRows;     
    DEALLOCATE tempRows;
   
   --UPDATE CCHECK RECORD

	DECLARE tempRows1 CURSOR FOR
		SELECT NONZONE_REF,RTN_STATUS 
			FROM DD_CCHECK_HIST 
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
 
	OPEN tempRows1;

	FETCH NEXT FROM tempRows1
		INTO @NONZONE_REF,@CC_RTN_STATUS;
 
	WHILE @@FETCH_STATUS = 0
	BEGIN

		UPDATE CCHECK SET RTN_STATUS=@CC_RTN_STATUS WHERE NONZONE_REF=@NONZONE_REF;

		UPDATE DD_CCHECK_HIST 
			SET AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
			AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(), STATUS=''O'',IS_AUTH=1 
			WHERE NONZONE_REF=@NONZONE_REF AND SLNO=@SLNO AND MOD_NO=@MOD_NO;

		FETCH NEXT FROM tempRows1
			INTO @NONZONE_REF,@CC_RTN_STATUS;
            
	END

	CLOSE tempRows1;
	DEALLOCATE tempRows1;

      -- Update Normal Collection Table
	DECLARE newRows CURSOR FOR
		SELECT NONZONE_REF, AMOUNT, VAT, COMMISION, POSTAGE_CHARGE, 
			INSTRUMENT_EXP, INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
			RTN_STATUS
			FROM DD_NCOLLECTION_HIST 
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
 
	OPEN newRows;
	
	FETCH NEXT FROM newRows
		INTO @NONZONE_REF, @AMOUNT, @VAT, @COMMISION, @POSTAGE_CHARGE, 
			@INSTRUMENT_EXP, @INPUT_BY, @INPUT_DATETIME, @INPUT_FROM, 
			@RTN_STATUS;
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO NCOLLECTION_HIST
			SELECT NONZONE_REF, REF_DATE, DDREFNO, AMOUNT, VAT, COMMISION, 
			POSTAGE_CHARGE, INSTRUMENT_EXP, RTN_STATUS, RTN_CODE, INPUT_BY, 
			INPUT_DATETIME, INPUT_FROM, AUTH_BY, AUTH_DATETIME, AUTH_FROM, 
			MOD_NO, [STATUS], 1
			FROM NCOLLECTION
			WHERE NONZONE_REF=@NONZONE_REF;	

		UPDATE NCOLLECTION 
			SET DDREFNO=@D_CODE+ RIGHT((''000'' + CONVERT(VARCHAR,@SLNO)),3),
			AMOUNT=@AMOUNT,VAT=@VAT,COMMISION=@COMMISION,
			POSTAGE_CHARGE=@POSTAGE_CHARGE,INSTRUMENT_EXP=@INSTRUMENT_EXP,
			INPUT_BY=@INPUT_BY,INPUT_DATETIME=@INPUT_DATETIME,INPUT_FROM=@INPUT_FROM,
			AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
			AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
			MOD_NO=MOD_NO+1,RTN_STATUS = @RTN_STATUS, [STATUS]=''L''
			WHERE NONZONE_REF=@NONZONE_REF; 

		UPDATE NCOLLECTION_HIST SET [STATUS] = ''O'' 
			WHERE NONZONE_REF=@NONZONE_REF 
			AND [STATUS] = ''L''; 

		UPDATE DD_NCOLLECTION_HIST 
			SET AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
			AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(), [STATUS]=''O'',IS_AUTH=1 
			WHERE NONZONE_REF=@NONZONE_REF AND SLNO=@SLNO AND MOD_NO=@MOD_NO;

		FETCH NEXT FROM newRows
			INTO @NONZONE_REF, @AMOUNT, @VAT, @COMMISION, @POSTAGE_CHARGE, 
				@INSTRUMENT_EXP, @INPUT_BY, @INPUT_DATETIME, @INPUT_FROM, 
				@RTN_STATUS;
            
	END

	CLOSE newRows;
	DEALLOCATE newRows;

	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Mar-13
-- Description:	Remove detail from DD 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_Remove]	
	@D_CODE		varchar(12),
	@SLNO		numeric(3,0),
	@MOD_NO		int,
	@RET_MOD_NO	int output
AS
BEGIN
	DECLARE	
		@STATUS				char(1),		
		@DD_NO 			    varchar(18), 
		@DD_DATE            datetime,
		@AMOUNT			    numeric(12, 2), 
		@DRAWER_BANKCODE	varchar(4), 
		@DRAWER_BRANCHCODE	varchar(4), 
		@DRAWER_LOCATION	varchar(4), 
		@DRAWEE_BRANCH		varchar(25), 
		@NIKBRANCH_CODE		varchar(7),
		@VAT			    numeric(12, 2),
		@COMMISION          numeric(12, 2),
		@POSTAGE_CHARGE     numeric(12, 2),
		@INSTRUMENT_EXP     numeric(12, 2),
		@RTN_STATUS			char(1);

	DECLARE 
		@ErrorVar	int;

	SET NOCOUNT ON;
  	
	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from DD
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@DD_NO=DD_NO, @DD_DATE=DD_DATE, @AMOUNT=AMOUNT, @DRAWER_BANKCODE=DRAWER_BANKCODE, 
				@DRAWER_BRANCHCODE=DRAWER_BRANCHCODE, @DRAWER_LOCATION=DRAWER_LOCATION, @DRAWEE_BRANCH=DRAWEE_BRANCH, 
				@NIKBRANCH_CODE=NIKBRANCH_CODE, @VAT=VAT, @COMMISION=COMMISION, @POSTAGE_CHARGE=POSTAGE_CHARGE, 
				@INSTRUMENT_EXP=INSTRUMENT_EXP,  @RTN_STATUS=RTN_STATUS				
				FROM DD
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE DD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				DD_HIST (D_CODE, SLNO, DD_NO, DD_DATE, AMOUNT, DRAWER_BANKCODE, 
				DRAWER_BRANCHCODE, DRAWER_LOCATION, DRAWEE_BRANCH, NIKBRANCH_CODE, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
				VALUES(@D_CODE, @SLNO, @DD_NO, @DD_DATE, @AMOUNT, @DRAWER_BANKCODE, 
				@DRAWER_BRANCHCODE, @DRAWER_LOCATION, @DRAWEE_BRANCH, @NIKBRANCH_CODE, 
				@VAT, @COMMISION, @POSTAGE_CHARGE, @INSTRUMENT_EXP,				
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO,''R'',''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE DD_CCHECK_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO DD_CCHECK_HIST(D_CODE, SLNO, NONZONE_REF, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
				SELECT D_CODE, SLNO, NONZONE_REF, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, ''O'', ''U'', 0
				FROM DD_CCHECK_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------

			DELETE DD_NCOLLECTION_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO DD_NCOLLECTION_HIST(D_CODE, SLNO, NONZONE_REF, AMOUNT, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
				SELECT D_CODE, SLNO, NONZONE_REF, AMOUNT, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, ''O'', ''U'', 0
				FROM DD_NCOLLECTION_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

-------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT D_CODE from DD_HIST 
					  WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE DD_HIST
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE DD_CCHECK_HIST
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0 ;
										
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					DELETE DD_NCOLLECTION_HIST
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0 ;

					SELECT @ErrorVar = @@error;

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		

  
	   
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_Paid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Mar-13
-- Description:	update DD status to paid 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_Paid]	
	@D_CODE		varchar(12),
	@SLNO		numeric(3,0),
	@MOD_NO		int,
	@RET_MOD_NO	int output
AS
BEGIN
	DECLARE	
		@STATUS				char(1),		
		@DD_NO 			    varchar(18), 
		@DD_DATE            datetime,
		@AMOUNT			    numeric(12, 2), 
		@DRAWER_BANKCODE	varchar(4), 
		@DRAWER_BRANCHCODE	varchar(4), 
		@DRAWER_LOCATION	varchar(4), 
		@DRAWEE_BRANCH		varchar(25), 
		@NIKBRANCH_CODE		varchar(7),
		@VAT			    numeric(12, 2),
		@COMMISION          numeric(12, 2),
		@POSTAGE_CHARGE     numeric(12, 2),
		@INSTRUMENT_EXP     numeric(12, 2),
		@RTN_STATUS			char(1);

	DECLARE 
		@ErrorVar	int;

	SET NOCOUNT ON;
  	
	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from DD
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@DD_NO=DD_NO, @DD_DATE=DD_DATE, @AMOUNT=AMOUNT, @DRAWER_BANKCODE=DRAWER_BANKCODE, 
				@DRAWER_BRANCHCODE=DRAWER_BRANCHCODE, @DRAWER_LOCATION=DRAWER_LOCATION, @DRAWEE_BRANCH=DRAWEE_BRANCH, 
				@NIKBRANCH_CODE=NIKBRANCH_CODE, @VAT=VAT, @COMMISION=COMMISION, @POSTAGE_CHARGE=POSTAGE_CHARGE, 
				@INSTRUMENT_EXP=INSTRUMENT_EXP,  @RTN_STATUS=RTN_STATUS				
				FROM DD
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
				

			IF (@RTN_STATUS = ''P'')
				BEGIN
					-- already paid
					ROLLBACK TRANSACTION;
					RETURN 9;
				END;
		

			DELETE DD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				DD_HIST (D_CODE, SLNO, DD_NO, DD_DATE, AMOUNT, DRAWER_BANKCODE, 
				DRAWER_BRANCHCODE, DRAWER_LOCATION, DRAWEE_BRANCH, NIKBRANCH_CODE, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
				VALUES(@D_CODE, @SLNO, @DD_NO, @DD_DATE, @AMOUNT, @DRAWER_BANKCODE, 
				@DRAWER_BRANCHCODE, @DRAWER_LOCATION, @DRAWEE_BRANCH, @NIKBRANCH_CODE, 
				@VAT, @COMMISION, @POSTAGE_CHARGE, @INSTRUMENT_EXP,				
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO,''P'',''U'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE DD_CCHECK_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO DD_CCHECK_HIST(D_CODE, SLNO, NONZONE_REF, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
				SELECT D_CODE, SLNO, NONZONE_REF, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, ''P'', ''U'', 0
				FROM DD_CCHECK_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------

			DELETE DD_NCOLLECTION_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO DD_NCOLLECTION_HIST(D_CODE, SLNO, NONZONE_REF, AMOUNT, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
				SELECT D_CODE, SLNO, NONZONE_REF, AMOUNT, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, ''P'', ''U'', 0
				FROM DD_NCOLLECTION_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

-------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	
	ROLLBACK TRANSACTION;
	RETURN 4; 
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 07-March-13
-- Description:	Add detail to DD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_Update]	
	@D_CODE				varchar(12),
    @SLNO               numeric(3,0),
    @MOD_NO             int,
	@DD_NO 			    varchar(18), 
    @DD_DATE            datetime,
	@AMOUNT			    numeric(12, 2), 
	@DRAWER_BANKCODE	varchar(4), 
	@DRAWER_BRANCHCODE	varchar(4), 
	@DRAWER_LOCATION	varchar(4), 
	@DRAWEE_BRANCH		varchar(25), 
	@NIKBRANCH_CODE		varchar(7),
	@VAT			    numeric(12, 2),
    @COMMISION          numeric(12, 2),
    @POSTAGE_CHARGE     numeric(12, 2),
    @INSTRUMENT_EXP     numeric(12, 2),
	@RET_MOD_NO			int output
AS
BEGIN	
	DECLARE @ErrorVar	int;

	SET NOCOUNT ON;

IF EXISTS(SELECT D_CODE FROM DD 
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE DD_HIST WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO DD_HIST(D_CODE, SLNO, DD_NO, DD_DATE, 
				AMOUNT,DRAWER_BANKCODE, DRAWER_BRANCHCODE, DRAWER_LOCATION,
				DRAWEE_BRANCH, NIKBRANCH_CODE,VAT,COMMISION,POSTAGE_CHARGE,
				INSTRUMENT_EXP,
				INPUT_BY,
				INPUT_DATETIME,INPUT_FROM,MOD_NO,RTN_STATUS,[STATUS],IS_AUTH)
				VALUES(@D_CODE, @SLNO, @DD_NO, @DD_DATE, 
				@AMOUNT, @DRAWER_BANKCODE,@DRAWER_BRANCHCODE, @DRAWER_LOCATION, 
				@DRAWEE_BRANCH,	@NIKBRANCH_CODE, @VAT,@COMMISION,@POSTAGE_CHARGE,
				@INSTRUMENT_EXP,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''D'',''U'',0);
    
			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE DD_CCHECK_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END

			DELETE DD_NCOLLECTION_HIST
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT D_CODE from DD_HIST 
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO 
						AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE DD_HIST WHERE D_CODE=@D_CODE 
						AND SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
				

					INSERT INTO DD_HIST(D_CODE, SLNO, DD_NO, DD_DATE, 
						AMOUNT,DRAWER_BANKCODE, DRAWER_BRANCHCODE, DRAWER_LOCATION,
						DRAWEE_BRANCH, NIKBRANCH_CODE,VAT,COMMISION,POSTAGE_CHARGE,
						INSTRUMENT_EXP,
						INPUT_BY,
						INPUT_DATETIME,INPUT_FROM,MOD_NO,RTN_STATUS,[STATUS],IS_AUTH)
						VALUES(@D_CODE, @SLNO, @DD_NO, @DD_DATE, 
						@AMOUNT, @DRAWER_BANKCODE,@DRAWER_BRANCHCODE, @DRAWER_LOCATION, 
						@DRAWEE_BRANCH,	@NIKBRANCH_CODE, @VAT,@COMMISION,@POSTAGE_CHARGE,
						@INSTRUMENT_EXP,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''D'',''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE DD_CCHECK_HIST
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END

					DELETE DD_NCOLLECTION_HIST
						WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END

  
    -----------
----------------
----------------

		   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_CCheck_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 28-02-13
-- Description:	Get detail of CCheck by DD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_CCheck_GetDetail]	
	@D_CODE	        varchar(12),	
	@SLNO	        numeric(3,0),
    @MOD_NO         int
AS
BEGIN	
	
	SET NOCOUNT ON;

		SELECT d.*,c.CHECK_NO,c.AMOUNT,c.CHECK_REF,cl.ACC_NAME,	cl.ACC_NO,
			cl.CITIANY_CHARGE,cl.CITIANY_STD_CHARGE,cl.CITIANY_VAT,IS_AUTH 
			FROM DD_CCHECK_HIST d
			INNER JOIN CCHECK c ON d.NONZONE_REF = c.NONZONE_REF 
			INNER JOIN CLIENT cl ON c.CLIENT_CODE=cl.CLIENT_CODE
			WHERE d.D_CODE=@D_CODE AND d.SLNO=@SLNO AND d.MOD_NO=@MOD_NO
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckAddedByDD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Author:		Fahad Khan
-- Create date: 25-Feb-13
-- Description:	CCheck table Added by DD Details
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckAddedByDD]
    @D_CODE				varchar(12),
    @SLNO               int,
	@NONZONE_REF	    varchar(7)
AS
BEGIN	
		
	SET NOCOUNT ON;

	INSERT INTO DD_CCHECK_HIST(D_CODE,SLNO,NONZONE_REF,
		INPUT_BY,
		INPUT_DATETIME,INPUT_FROM,MOD_NO,RTN_STATUS,[STATUS],IS_AUTH)
		VALUES(@D_CODE,@SLNO,@NONZONE_REF,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''D'',''U'',0);
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_GetOutstanding]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Get outstanind Checks by Bank, Branch 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_GetOutstanding]	
	@DRAWEE_BANK_CODE	varchar(4),
    @LOCATION_CODE    	varchar(4),
    @BRANCH_CODE    	varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT cs.*,cl.ACC_NAME,cl.ACC_NO,cl.CITIANY_CHARGE,cl.CITIANY_STD_CHARGE,CITIANY_VAT
		FROM CCHECK cs
		INNER JOIN CLIENT cl ON cs.CLIENT_CODE=cl.CLIENT_CODE
		WHERE cs.DRAWEE_BANK_CODE = @DRAWEE_BANK_CODE AND cs.LOCATION_CODE = @LOCATION_CODE
		AND cs.BRANCH_CODE= @BRANCH_CODE AND cs.RTN_STATUS=''O'' AND cs.NONZONE_REF > ''0''
		AND cs.NONZONE_REF NOT IN (SELECT NONZONE_REF FROM DD_CCHECK_HIST WHERE
			IS_AUTH=0 )
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckUpdateByDD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 07-Mar-13
-- Description:	CCheck table Update by DD Details
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckUpdateByDD]
	@D_CODE			varchar(12),
	@SLNO			numeric(3,0),
	@MOD_NO			int,
	@NONZONE_REF	varchar(7)
AS
BEGIN	
		
	SET NOCOUNT ON;

	INSERT INTO DD_CCHECK_HIST(D_CODE,SLNO,NONZONE_REF,
		INPUT_BY,
		INPUT_DATETIME,INPUT_FROM,MOD_NO,RTN_STATUS,[STATUS],IS_AUTH)
		VALUES(@D_CODE,@SLNO,@NONZONE_REF,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),@MOD_NO,''D'',''U'',0);	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnCSD_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Aug-13
-- Description:	Add detail to RETURN_CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnCSD_Add]	
	@D_CODE				varchar(12), 
	@SLNO				numeric(3,0), 
	@RTN_STATUS			char(1), 
	@RTN_CODE			varchar(2)
AS
BEGIN	
	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO RETURN_CSD_HIST(D_CODE, SLNO, RTN_STATUS, RTN_CODE, 
		INPUT_BY, 
		INPUT_DATETIME, INPUT_FROM, MOD_NO, [STATUS], IS_AUTH)
		VALUES(@D_CODE, @SLNO, @RTN_STATUS, @RTN_CODE, 
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermMenus_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get details of Perm_Menus table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PermMenus_GetDetails]	
	@FG_SLNO	numeric(6,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT FG_ID 
			   FROM F_GROUP WHERE SLNO=@FG_SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT * FROM
			(SELECT SLNO M_SLNO,MENU_NAME FROM MENU_LIST WHERE STATUS=''L'') ml
			left outer join 
			(SELECT F_GROUP.*,''IS_AUTH''=1,
			pm.MENU_SLNO,pm.IS_VISIBLE,pm.IS_ENABLE
			FROM F_GROUP
			LEFT OUTER JOIN PERM_MENUS pm
			ON FG_SLNO=SLNO AND F_GROUP.MOD_NO=pm.MOD_NO
			WHERE SLNO=@FG_SLNO AND F_GROUP.MOD_NO=@MOD_NO) g
			on ml.M_SLNO=g.MENU_SLNO


		END	
	ELSE
		BEGIN
			SELECT * FROM
			(SELECT SLNO M_SLNO,MENU_NAME FROM MENU_LIST WHERE STATUS=''L'') ml
			left outer join 
			(SELECT F_GROUP_HIST.*,
			pmh.MENU_SLNO,pmh.IS_VISIBLE,pmh.IS_ENABLE 
			FROM F_GROUP_HIST
			LEFT OUTER JOIN PERM_MENUS_HIST pmh
			ON FG_SLNO=SLNO AND F_GROUP_HIST.MOD_NO=pmh.MOD_NO
			WHERE F_GROUP_HIST.SLNO=@FG_SLNO AND F_GROUP_HIST.MOD_NO=@MOD_NO) g
			on ml.M_SLNO=g.MENU_SLNO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Version_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 30-Jan-13
-- Description:	Get detail of version table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Version_GetDetail]		
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT * FROM VERSION;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_GetDetailsByAmount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Jan-13
-- Description:	Get detail of CCheck by ds_code and amount
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_GetDetailsByAmount]	
	@DS_CODE	varchar(12),	
	@AMOUNT		numeric(12,2)	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT chk.*,b.BANK_NAME AS DRAWEE_BANK_NAME
	FROM CCHECK chk 
	INNER JOIN DSCHEDULE ds ON chk.D_CODE=ds.D_CODE
	LEFT OUTER JOIN BANK b on b.BANK_CODE=chk.DRAWEE_BANK_CODE
	WHERE ds.DS_CODE=@DS_CODE AND chk.AMOUNT=@AMOUNT
	AND ds.CLIENT_CODE=''999999''
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jan-13
-- Description:	Remove record from DCollected
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_Remove]	
	@DS_CODE		varchar(12),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@TOTAL_NOCHK	numeric(4,0), 
			@TOTAL_CHKAMT	numeric(12,2), 
			@TOTAL_CASHAMT	numeric(12,2),						
			@IS_AUTH		bit,
			@ENTRY_DATE		datetime;	
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT DS_CODE from DCOLLECTED
			  WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_NOCHK=TOTAL_NOCHK, 
				@TOTAL_CHKAMT=TOTAL_CHKAMT, @TOTAL_CASHAMT=TOTAL_CASHAMT,
				@ENTRY_DATE=ENTRY_DATE				
				FROM DCOLLECTED
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				DCOLLECTED_HIST (DS_CODE,
				TOTAL_NOCHK, TOTAL_CHKAMT, TOTAL_CASHAMT, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH, ENTRY_DATE)
				VALUES(@DS_CODE,
				@TOTAL_NOCHK, @TOTAL_CHKAMT, @TOTAL_CASHAMT, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0, @ENTRY_DATE)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE DSCHEDULE_HIST
				WHERE DS_CODE=@DS_CODE AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO DSCHEDULE_HIST(DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT, 
				CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, 
				LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
				MOD_NO, IS_AUTH, [FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, 
				CHECKED, FLEXGEN_DATE,SLNO,IS_ROW_CHG)
				SELECT DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT,
					CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, 
					LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
					@RET_MOD_NO,0, [FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, 
					CHECKED, FLEXGEN_DATE,SLNO,1
				FROM DSCHEDULE
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT DS_CODE from DCOLLECTED_HIST 
					  WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO )
				BEGIN

------------------
					IF @MOD_NO=1
						BEGIN
							IF EXISTS(SELECT ds.DS_CODE,ds.D_CODE,ds.MOD_NO 
										FROM DSCHEDULE_HIST ds 
										INNER JOIN CCASH_HIST cc ON cc.D_CODE=ds.D_CODE
										WHERE ds.IS_AUTH=0 AND ds.MOD_NO=1 
										AND DS_CODE=@DS_CODE)
								BEGIN
									-- child exist
									ROLLBACK TRANSACTION;
									RETURN 10;
								END

							IF EXISTS(SELECT ds.DS_CODE,ds.D_CODE,ds.MOD_NO 
										FROM DSCHEDULE_HIST ds 
										INNER JOIN CSD_HIST cd ON cd.D_CODE=ds.D_CODE
										WHERE ds.IS_AUTH=0 AND ds.MOD_NO=1 
										AND DS_CODE=@DS_CODE)
								BEGIN
									-- child exist
									ROLLBACK TRANSACTION;
									RETURN 10;
								END

						END

--------------------


					DELETE DCOLLECTED_HIST
						WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE DSCHEDULE_HIST 
						WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jan-13
-- Description:	Get detail of Dschedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetDetails]	
	@DS_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
			   FROM DSCHEDULE WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT ds.*,''IS_AUTH''=1,
				l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME,cl.ACC_NO,cl.ACC_NAME
			FROM DSCHEDULE ds
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=ds.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=ds.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=ds.CORR_BRANCH_CODE
				LEFT OUTER JOIN CLIENT cl
				ON cl.CLIENT_CODE=ds.CLIENT_CODE
			WHERE ds.DS_CODE=@DS_CODE AND ds.MOD_NO = @MOD_NO
			ORDER BY ds.SLNO
		END	
	ELSE
		BEGIN
			SELECT dsh.* ,
				l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME,cl.ACC_NO,cl.ACC_NAME
			FROM DSCHEDULE_HIST dsh
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=dsh.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=dsh.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=dsh.CORR_BRANCH_CODE
				LEFT OUTER JOIN CLIENT cl
				ON cl.CLIENT_CODE=dsh.CLIENT_CODE
			WHERE dsh.DS_CODE=@DS_CODE AND dsh.MOD_NO = @MOD_NO
			ORDER BY dsh.SLNO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BeforeBookingCheck]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BeforeBookingCheck]		
	@SEQ_NO		NUMERIC(4,0) output,
	@BATCH_NO	VARCHAR(4) output,
	@REF_NO		VARCHAR(10) output
AS
BEGIN	
	DECLARE @ErrorVar INT;
			
	
	SET NOCOUNT ON;

	SELECT @SEQ_NO = isnull(max(SEQ_NO),0) from DSCHEDULE;
	
	SELECT @BATCH_NO = ISNULL(MAX(BATCH_NO),''5600'')+1		
		FROM GENPRM
		WHERE DATEDIFF(d,GETDATE(),BATCH_DATE)=0;

	SELECT @REF_NO = ISNULL(MAX(REF_NO),0)+1 FROM GENPRM;
	--SELECT @RefNo =  RIGHT(''0000000000'' + @RefNo, 10)

	DELETE TMP_BOOKING;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END

	
         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetCheckSlip]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Jan-13
-- Description:	Get check slip detail of DSchedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetCheckSlip]	
	@D_CODE	varchar(12)
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT D_CODE 
			FROM DSCHEDULE ds 
			WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE=''Check'' )
		BEGIN
			SELECT ds.*,l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME,
				c.ACC_NAME,C.ACC_NO
			FROM DSCHEDULE ds
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=ds.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				on b.BANK_CODE=ds.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				on br.BRANCH_CODE=ds.CORR_BRANCH_CODE
				LEFT OUTER JOIN CLIENT c
				on c.CLIENT_CODE=ds.CLIENT_CODE
			WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE=''Check'';
		END;
	ELSE
		BEGIN
			SELECT ds.*,l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME,
				c.ACC_NAME,C.ACC_NO
			FROM DSCHEDULE_HIST ds
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=ds.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				on b.BANK_CODE=ds.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				on br.BRANCH_CODE=ds.CORR_BRANCH_CODE
				LEFT OUTER JOIN CLIENT c
				on c.CLIENT_CODE=ds.CLIENT_CODE
			WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE=''Check'' AND IS_AUTH=0;
		END;


END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingByBank]	
	@BANK_CODE		varchar(4)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;
--1
              
--2            
	INSERT INTO TMP_BOOKING (REF_NO, AMOUNT, VALUE_DATE, REV_DATE, ACC_NO, DAYS,
		D_CODE,DEP_TYP)            
		SELECT ds.REF_NO,ds.CITICASH_AMOUNT as amt,ds.SCHEDULE_DATE,            
			DATEADD(day,convert(int,ISNULL(clc.CASH_DAYS,cl.CASH_DAYS)),ds.SCHEDULE_DATE )REVDATE,cl.ACC_NO,
			ISNULL(clc.CASH_DAYS,cl.CASH_DAYS) as CASH_DAYS,ds.D_CODE,
			ds.DEPOSIT_TYPE 
			FROM CLIENT  cl 
			INNER JOIN  DSCHEDULE ds
			on DS.CLIENT_CODE=CL.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]=''L'') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			INNER JOIN DCOLLECTED dc 
			ON dc.DS_CODE=ds.DS_CODE
			WHERE cl.STATUS=''L'' AND dc.STATUS=''L'' AND
			ds.CITICASH_AMOUNT>0 and ds.REF_NO is null
			AND ds.CORR_BANK_CODE=@BANK_CODE            
		UNION ALL          
			SELECT ds.REF_NO,ds.CITICHECK_AMOUNT as amt,ds.SCHEDULE_DATE,            
			DATEADD(day,convert(int,ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS)),ds.SCHEDULE_DATE )REVDATE,cl.ACC_NO,
			ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS) as SPEED_DAYS,ds.D_CODE,
			ds.DEPOSIT_TYPE
			FROM CLIENT  cl 
			INNER JOIN  DSCHEDULE ds
			on DS.CLIENT_CODE=CL.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]=''L'') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			INNER JOIN DCOLLECTED dc 
			ON dc.DS_CODE=ds.DS_CODE
			where cl.STATUS=''L'' AND dc.STATUS=''L'' AND
			ds.CITICHECK_AMOUNT>0 and ds.REF_NO is null 
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND CONVERT(datetime,CONVERT(varchar(10),ds.schedule_date,101))             
			<= CONVERT(datetime,CONVERT(varchar(10),GETDATE(),101)) ;       
            
	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingDrCheckByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingDrCheckByBank]	
	@BANK_CODE		varchar(4),
	@SCHEDULE_DATE	datetime
AS
BEGIN	
	DECLARE @ErrorVar		INT,
			@vDS_CODE		varchar(12),
			@vSCHEDULE_DATE	datetime,
			@vAmount		numeric(14,2),
			@vLOCATION_NAME	varchar(35),
			@vACC_NO		varchar(16);

	
	SET NOCOUNT ON;

	DECLARE CURSORCASH CURSOR FOR
		SELECT ds.DS_CODE,ds.SCHEDULE_DATE,
			SUM(ds.CITICASH_AMOUNT) as total,l.LOCATION_NAME,b.ACC_NO
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b, DCOLLECTED dc 
			WHERE cl.CLIENT_CODE = ds.CLIENT_CODE
			AND cl.STATUS=''L''
			AND ds.CITICASH_AMOUNT>0 
			AND ds.REF_NO IS NULL 
			AND (ds.CHECKED IS NULL OR ds.CHECKED=0)
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND dc.DS_CODE=ds.DS_CODE
			AND dc.STATUS=''L''
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORCASH;
	FETCH NEXT FROM CURSORCASH 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES(''0'',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'''',@vLOCATION_NAME,''Cash'');
		
		FETCH NEXT FROM CURSORCASH 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORCASH;
	DEALLOCATE CURSORCASH;
--2

	DECLARE CURSORSPEED CURSOR FOR
		SELECT ds.DS_CODE,ds.SCHEDULE_DATE,
			SUM(ds.CITICHECK_AMOUNT) as total,l.LOCATION_NAME,b.ACC_NO
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b,DCOLLECTED dc
			WHERE cl.CLIENT_CODE = ds.CLIENT_CODE
			AND cl.STATUS=''L''
			AND ds.CITICHECK_AMOUNT>0 
			AND ds.REF_NO IS NULL
			AND (ds.checked IS NULL OR ds.CHECKED=0)
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND ds.SCHEDULE_DATE<=@SCHEDULE_DATE
			AND dc.DS_CODE=ds.DS_CODE
			AND dc.STATUS=''L''
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORSPEED;
	FETCH NEXT FROM CURSORSPEED 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES(''0'',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'''',@vLOCATION_NAME,''Check'');
			

		FETCH NEXT FROM CURSORSPEED 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORSPEED;
	DEALLOCATE CURSORSPEED;

	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	Authorize record to CCash table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCash_Auth]	
	@D_CODE			varchar(12),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@CUSTOMER_REF 	varchar(15),
			@CASH_REF 		varchar(15),
			@SLIP_DATE 		datetime,
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from CCASH_HIST 
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CUSTOMER_REF=CUSTOMER_REF,
				@CASH_REF=CASH_REF,@SLIP_DATE=SLIP_DATE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CCASH_HIST 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CCASH_HIST 
				SELECT *,1 FROM CCASH
				WHERE D_CODE=@D_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CCASH_HIST
				SET [STATUS] = ''O'' 
				WHERE D_CODE=@D_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CCASH
				SET CUSTOMER_REF=@CUSTOMER_REF,
				CASH_REF=@CASH_REF,SLIP_DATE=@SLIP_DATE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE D_CODE=@D_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CCASH_HIST WHERE D_CODE=@D_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN

			IF NOT EXISTS(SELECT D_CODE FROM DSCHEDULE
				WHERE D_CODE=@D_CODE)
			BEGIN
				-- parent not exist
				ROLLBACK TRANSACTION;
				RETURN 11;
			END


			INSERT INTO CCASH
				SELECT D_CODE, CUSTOMER_REF,
					CASH_REF,SLIP_DATE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CCASH_HIST
					WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CCASH_HIST WHERE D_CODE=@D_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingCheckByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingCheckByBank]	
	@BANK_CODE		varchar(4)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;
--1     
              
--2            
	INSERT INTO TMP_BOOKING (REF_NO, AMOUNT, VALUE_DATE, REV_DATE, ACC_NO, DAYS,
		D_CODE,DEP_TYP)            
		SELECT ds.REF_NO,ds.CITICASH_AMOUNT as amt,ds.SCHEDULE_DATE,            
			DATEADD(day,convert(int,ISNULL(clc.CASH_DAYS,cl.CASH_DAYS)),ds.SCHEDULE_DATE )REVDATE,cl.ACC_NO,
			ISNULL(clc.CASH_DAYS,cl.CASH_DAYS) as CASH_DAYS,ds.D_CODE,
			ds.DEPOSIT_TYPE 
			FROM CLIENT  cl 
			INNER JOIN  DSCHEDULE ds
			on DS.CLIENT_CODE=CL.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]=''L'') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			INNER JOIN DCOLLECTED dc 
			ON dc.DS_CODE=ds.DS_CODE
			WHERE cl.STATUS=''L'' AND dc.STATUS=''L''
			AND	ds.CITICASH_AMOUNT>0 and ds.REF_NO is null 
			AND (ds.CHECKED IS NULL OR ds.CHECKED=0)
			AND ds.CORR_BANK_CODE=@BANK_CODE            
		UNION ALL          
		SELECT ds.REF_NO,ds.CITICHECK_AMOUNT as amt,ds.SCHEDULE_DATE,            
			DATEADD(day,convert(int,ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS)),ds.SCHEDULE_DATE )REVDATE,cl.ACC_NO,
			ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS) as SPEED_DAYS,ds.D_CODE,
			ds.DEPOSIT_TYPE
			FROM CLIENT  cl 
			INNER JOIN  DSCHEDULE ds
			on DS.CLIENT_CODE=CL.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]=''L'') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			INNER JOIN DCOLLECTED dc 
			ON dc.DS_CODE=ds.DS_CODE
			WHERE cl.STATUS=''L'' AND dc.STATUS=''L''
			AND ds.CITICHECK_AMOUNT>0 and ds.REF_NO is null 
			AND (ds.CHECKED IS NULL OR ds.CHECKED=0)
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND CONVERT(datetime,CONVERT(varchar(10),ds.schedule_date,101))             
			<= CONVERT(datetime,CONVERT(varchar(10),GETDATE(),101)) ;       
            
	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetCashSlip]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	Get cash slip detail of DSchedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetCashSlip]	
	@D_CODE	varchar(12)
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT D_CODE 
			FROM DSCHEDULE ds 
			WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE=''Cash'' )
		BEGIN
			SELECT ds.*,l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME,
				c.ACC_NAME,C.ACC_NO
			FROM DSCHEDULE ds
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=ds.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				on b.BANK_CODE=ds.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				on br.BRANCH_CODE=ds.CORR_BRANCH_CODE
				LEFT OUTER JOIN CLIENT c
				on c.CLIENT_CODE=ds.CLIENT_CODE
			WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE=''Cash'';
		END;
	ELSE
		BEGIN
			SELECT ds.*,l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME,
				c.ACC_NAME,C.ACC_NO
			FROM DSCHEDULE_HIST ds
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=ds.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				on b.BANK_CODE=ds.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				on br.BRANCH_CODE=ds.CORR_BRANCH_CODE
				LEFT OUTER JOIN CLIENT c
				on c.CLIENT_CODE=ds.CLIENT_CODE
			WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE=''Cash'' AND IS_AUTH=0;
		END;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_UpdateRef]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_UpdateRef]
	@FILENAME		varchar(15),	
	@GENPRMREF_NO	varchar(10), --Last refno for genprm table      
	@BATCH_NO		varchar(10)
AS
BEGIN	
	DECLARE @ErrorVar	int,			
			@vrefno		varchar(10), 			
			@DCODE		varchar(12),        
			@VREVDATE	datetime,          
			@REFACCNO	varchar(15),        
			@deptype	varchar(15);
	
	SET NOCOUNT ON;
              
    ---1        
	DECLARE GLTCURSOR CURSOR FOR 
		SELECT REF_NO,REV_DATE,SUNACC_NO,DEP_TYP FROM TMP_CR_BOOKING;       

	OPEN GLTCURSOR;        

	FETCH NEXT FROM GLTCURSOR INTO
		@vrefno,@VREVDATE,@REFACCNO, @deptype;       

	WHILE @@FETCH_STATUS=0
	BEGIN         
		UPDATE TMP_BOOKING SET REF_NO=@VREFNO, REFACC_NO=@REFACCNO 
			WHERE REV_DATE=@VREVDATE        
			AND DEP_TYP= @deptype;
        
		FETCH NEXT FROM GLTCURSOR INTO        
			@VREFNO,@VREVDATE,@REFACCNO,@deptype;
	END  
      
	CLOSE GLTCURSOR;
	DEALLOCATE GLTCURSOR;        
          
            
    ---2        
    DECLARE GLTCURSOR CURSOR FOR
		SELECT REF_NO,D_CODE FROM TMP_BOOKING;       
            
    OPEN  GLTCURSOR;         
            
    FETCH NEXT FROM GLTCURSOR
		INTO @VREFNO,@DCODE;        
             
    WHILE @@FETCH_STATUS=0                 
	BEGIN        
		UPDATE DSCHEDULE 
			SET REF_NO=@VREFNO WHERE D_CODE=@DCODE;           
		
		FETCH NEXT FROM GLTCURSOR
			INTO @VREFNO,@DCODE;        
	END        
            
    CLOSE GLTCURSOR;         
    DEALLOCATE GLTCURSOR;       
            
    ---3        
              
    INSERT INTO CCMSREF_TAB(REF_NO,AMOUNT,VALUE_DATE,REV_DATE,ACC_NO,REFACC_NO,D_CODE,REVERGEN)        
		SELECT REF_NO,AMOUNT,VALUE_DATE,REV_DATE,ACC_NO,REFACC_NO,D_CODE,@FILENAME FROM TMP_BOOKING         
            
     --4 update genprm after generate files.      
    UPDATE GENPRM
		SET BATCH_NO=@BATCH_NO, REF_NO=@GENPRMREF_NO, BATCH_DATE=GETDATE();     
    
	                             
	IF @@ERROR<>0 GOTO ErrorHandler              
               
               
	RETURN 0;            
                         
    ErrorHandler:              
	PRINT ''Record Does not Inserted/Updated:'' ;             
	             
	RETURN 1;
	
	
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingDrByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingDrByBank]	
	@BANK_CODE		varchar(4),
	@SCHEDULE_DATE	datetime
AS
BEGIN	
	DECLARE @ErrorVar		INT,
			@vDS_CODE		varchar(12),
			@vSCHEDULE_DATE	datetime,
			@vAmount		numeric(14,2),
			@vLOCATION_NAME	varchar(35),
			@vACC_NO		varchar(16);

	
	SET NOCOUNT ON;

	DECLARE CURSORCASH CURSOR FOR
		SELECT ds.DS_CODE,ds.SCHEDULE_DATE,
			SUM(ds.CITICASH_AMOUNT) as total,l.LOCATION_NAME,b.ACC_NO
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b,DCOLLECTED dc 
			WHERE cl.CLIENT_CODE = ds.CLIENT_CODE
			AND cl.STATUS=''L'' 
			AND ds.CITICASH_AMOUNT>0	 
			AND ds.REF_NO IS NULL			
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND dc.DS_CODE=ds.DS_CODE
			AND dc.STATUS=''L''
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORCASH;
	FETCH NEXT FROM CURSORCASH 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES(''0'',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'''',@vLOCATION_NAME,''Cash'');
		
		FETCH NEXT FROM CURSORCASH 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORCASH;
	DEALLOCATE CURSORCASH;
--2

	DECLARE CURSORSPEED CURSOR FOR
		SELECT ds.DS_CODE,ds.SCHEDULE_DATE,
			SUM(ds.CITICHECK_AMOUNT) as total,l.LOCATION_NAME,b.ACC_NO
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b,DCOLLECTED dc 
			WHERE cl.CLIENT_CODE = ds.CLIENT_CODE
			AND cl.STATUS=''L''
			AND ds.CITICHECK_AMOUNT>0 
			AND ds.REF_NO IS NULL
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE= @BANK_CODE
			AND ds.SCHEDULE_DATE<=@SCHEDULE_DATE
			AND dc.DS_CODE=ds.DS_CODE
			AND dc.STATUS=''L''
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORSPEED;
	FETCH NEXT FROM CURSORSPEED 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES(''0'',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'''',@vLOCATION_NAME,''Check'');
			

		FETCH NEXT FROM CURSORSPEED 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORSPEED;
	DEALLOCATE CURSORSPEED;

	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingUpdtScheRefByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingUpdtScheRefByBank]
	@BANK_CODE	varchar(4),
	@FILENAME	varchar(15),      
	@SEQ_NO		varchar(20),      
	@VALUE_DATE	datetime          
	
AS
BEGIN

--- Update Schedule table Check wise and cash wise      
     UPDATE DSCHEDULE
		SET [FILENAME]=@FILENAME,SEQ_NO=@SEQ_NO,FLEXGEN_DATE=getdate(),
		FILE_USER_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20) 
		WHERE REF_NO IS NULL AND [FILENAME] IS NULL AND DEPOSIT_TYPE=''Cash''
		AND CORR_BANK_CODE=@BANK_CODE;      
     UPDATE DSCHEDULE
		SET [FILENAME]=@FILENAME,SEQ_NO=@SEQ_NO,FLEXGEN_DATE=getdate(),
		FILE_USER_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20)
		WHERE REF_NO IS NULL AND [FILENAME] IS NULL AND DEPOSIT_TYPE=''Check'' 
		AND SCHEDULE_DATE <= @VALUE_DATE
		AND CORR_BANK_CODE=@BANK_CODE;     
END      ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetMismatchDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-May-13
-- Description:	Get dschedule for mismatch total check no/check amount/cash Amount
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetMismatchDetail]			
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT dc.*
		FROM DCOLLECTED dc INNER JOIN
		(SELECT DS_CODE,SUM(CITICASH_AMOUNT) AS TOTCASH,SUM(CITICHECK_AMOUNT) AS TOTCHECK,
		SUM(NO_CHECK) AS TOTCHECKNO
		FROM DSCHEDULE ds
		WHERE ds.DS_CODE IN (SELECT DISTINCT DS_CODE FROM DSCHEDULE a 
		WHERE a.FILENAME IS NULL AND (a.CHECKED=0 OR a.CHECKED IS NULL))
		GROUP BY DS_CODE) b
		ON dc.DS_CODE=b.DS_CODE
		WHERE dc.STATUS=''L'' 
		AND (dc.TOTAL_NOCHK<>b.TOTCHECKNO OR dc.TOTAL_CHKAMT<>TOTCHECK OR dc.TOTAL_CASHAMT<>b.TOTCASH);
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetDetailsByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Get detail of Dschedule by code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetDetailsByCode]	
	@DS_CODE	varchar(12)	
AS
BEGIN	
	
	SET NOCOUNT ON;

	
	SELECT ds.*,
		l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME
	FROM DSCHEDULE ds
		LEFT OUTER JOIN LOCATION l
		ON l.LOCATION_CODE=ds.LOCATION_CODE
		LEFT OUTER JOIN BANK b
		ON b.BANK_CODE=ds.CORR_BANK_CODE
		LEFT OUTER JOIN BRANCH br
		ON br.BRANCH_CODE=ds.CORR_BRANCH_CODE
	WHERE ds.DS_CODE=@DS_CODE
	ORDER BY ds.SLNO
	
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetDetailsByRefNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-Jun-13
-- Description:	Get detail of Dschedule by refno
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetDetailsByRefNo]	
	@REF_NO			varchar(10),
	@CLIENT_CODE	varchar(6)
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF @CLIENT_CODE=''''
		BEGIN
			
			SELECT ds.*,
				cl.ACC_NO,cl.ACC_NAME,lc.LOCATION_NAME 
			FROM DSCHEDULE ds
				LEFT OUTER JOIN CLIENT cl
				ON cl.CLIENT_CODE=ds.CLIENT_CODE
				LEFT OUTER JOIN LOCATION lc
				ON lc.LOCATION_CODE=ds.LOCATION_CODE
			WHERE REF_NO=@REF_NO 
				

		END
	ELSE
		BEGIN
			
			SELECT ds.*,
				cl.ACC_NO,cl.ACC_NAME,lc.LOCATION_NAME 
			FROM DSCHEDULE ds
				LEFT OUTER JOIN CLIENT cl
				ON cl.CLIENT_CODE=ds.CLIENT_CODE
				LEFT OUTER JOIN LOCATION lc
				ON lc.LOCATION_CODE=ds.LOCATION_CODE
			WHERE REF_NO=@REF_NO 
				AND ds.CLIENT_CODE=@CLIENT_CODE

		END
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Reversal_Outstanding]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-12
-- Description:	get reversal outstanding items
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Reversal_Outstanding]	
	@STATUS_ID		tinyint,
	@REV_DATE		datetime,
	@AUTHORIZE		tinyint			
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;
	
	if @STATUS_ID=1
		BEGIN
			if @AUTHORIZE=1
				BEGIN
						select * from 
					( select c.cash_cr_type,a.ref_no,a.value_Date,b.location_code,a.Rev_Date,
					a.Acc_No,a.RefAcc_No, b.client_code,b.citicash_amount,
					b.citicheck_amount,b.deposit_type,a.d_code ,a.status_id,
					a.remarks ,b.ds_code ,c.Acc_Name,d.Status_Name,a.Authorize,
					a.USERID,a.AUTHORIZER_ID  
					 from CCMSREF_TAB a  
					left outer join tran_status d on  a.status_id=d.status_id  ,dschedule b,client c  
					 Where 
					 A.d_code = B.d_code 
					 and b.client_code=c.client_code 
					and a.filename is null 
					and b.ds_code not in
					(select ds_code from cschedule) and rev_date <=@REV_DATE
					and a.status_id=1 and (a.AUTHORIZE IS NULL OR a.AUTHORIZE=1)) a
					--where a.value_date <> a.rev_date 
					order by a.ds_code,a.rev_date,a.acc_name asc;
				END;
			ELSE
				BEGIN
					select * from 
					( select c.cash_cr_type,a.ref_no,a.value_Date,b.location_code,a.Rev_Date,
					a.Acc_No,a.RefAcc_No, b.client_code,b.citicash_amount,
					b.citicheck_amount,b.deposit_type,a.d_code ,a.status_id,
					a.remarks ,b.ds_code ,c.Acc_Name,d.Status_Name,a.Authorize,
					a.USERID,a.AUTHORIZER_ID  
					 from CCMSREF_TAB a  
					left outer join tran_status d on  a.status_id=d.status_id  ,dschedule b,client c  
					 Where 
					 A.d_code = B.d_code 
					 and b.client_code=c.client_code 
					and a.filename is null 
					and b.ds_code not in
					(select ds_code from cschedule) and rev_date <=@REV_DATE
					and a.status_id=1 and a.AUTHORIZE=0) a
					--where a.value_date <> a.rev_date 
					order by a.ds_code,a.rev_date,a.acc_name asc;
				END ;
		END;
	ELSE
		BEGIN
			if @AUTHORIZE=1
				BEGIN
						select * from 
					( select c.cash_cr_type,a.ref_no,a.value_Date,b.location_code,a.Rev_Date,
					a.Acc_No,a.RefAcc_No, b.client_code,b.citicash_amount,
					b.citicheck_amount,b.deposit_type,a.d_code ,a.status_id,
					a.remarks ,b.ds_code ,c.Acc_Name,d.Status_Name,a.Authorize,
					a.USERID,a.AUTHORIZER_ID  
					 from CCMSREF_TAB a  
					left outer join tran_status d on  a.status_id=d.status_id  ,dschedule b,client c  
					 Where 
					 A.d_code = B.d_code 
					 and b.client_code=c.client_code 
					and a.filename is null 
					and b.ds_code not in
					(select ds_code from cschedule) and rev_date <=@REV_DATE
					and (a.status_id is null or a.status_id=2) 
					and (a.AUTHORIZE IS NULL OR a.AUTHORIZE=1) ) a
					--where a.value_date <> a.rev_date 
					order by a.ds_code,a.rev_date,a.acc_name asc ;
				END;
			ELSE
				BEGIN
					select * from 
					( select c.cash_cr_type,a.ref_no,a.value_Date,b.location_code,a.Rev_Date,
					a.Acc_No,a.RefAcc_No, b.client_code,b.citicash_amount,
					b.citicheck_amount,b.deposit_type,a.d_code ,a.status_id,
					a.remarks ,b.ds_code ,c.Acc_Name,d.Status_Name,a.Authorize ,
					a.USERID,a.AUTHORIZER_ID 
					 from CCMSREF_TAB a  
					left outer join tran_status d on  a.status_id=d.status_id  ,dschedule b,client c  
					 Where 
					 A.d_code = B.d_code 
					 and b.client_code=c.client_code 
					and a.filename is null 
					and b.ds_code not in
					(select ds_code from cschedule) and rev_date <=@REV_DATE
					and (a.status_id is null or a.status_id=2) 
					and a.AUTHORIZE=0 ) a
					--where a.value_date <> a.rev_date 
					order by a.ds_code,a.rev_date,a.acc_name asc ;

				END;

		END;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_DepositUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for reversal deposit update
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_DepositUpdate]	
AS
BEGIN	

Declare     
    
       @LOCATIONCD Char(6),     
       @ClientCd numeric,    
       @DCODE VARCHAR(10),    
       @REF_NO varchar(15),    
       @AMOUNT NUMERIC(12,2),    
       @DEPOSITYP VARCHAR(10),    
       @REV_DATE  DATETIME    
    
          
---1    
   DECLARE GLTCURSOR CURSOR  for    
    
           
 select b.location_code,b.client_code,a.REF_NO,a.REV_DATE,    
 sum(b.citicheck_amount) as total,b.deposit_type,b.D_CODE    
 from CCMSREF_TAB a ,dschedule b,client c    
 where     
 b.citicheck_amount>0    
 and a.d_code=b.d_code    
 and b.client_code=c.client_code    
         
 and a.filename is null    
 and c.SPEED_CR_TYPE=''L''    
    
 group by a.REV_DATE,b.location_code,a.REF_NO,b.client_code,    
 a.Acc_No,a.RefAcc_No,b.deposit_type,b.D_CODE    
    
   OPEN GLTCURSOR     
    
   FETCH NEXT FROM GLTCURSOR INTO    
    
         
       @LOCATIONCD , @ClientCd ,@REF_NO,@REV_DATE, @AMOUNT ,@DEPOSITYP,@DCODE     
    
   WHILE @@FETCH_STATUS=0     
    
    BEGIN     
        update  TMP_REVERSAL set ds_code=@DCODE     
        where client_code=@ClientCd and LOCATION_CODE=@LOCATIONCD AND DEPOSIT_TYPE=@DEPOSITYP    
        and REV_DATE=@REV_DATE    
        FETCH NEXT FROM GLTCURSOR INTO    
        @LOCATIONCD , @ClientCd ,@REF_NO,@REV_DATE, @AMOUNT ,@DEPOSITYP,@DCODE    
       
   END    
   CLOSE GLTCURSOR    
    
   DEALLOCATE GLTCURSOR    
    
    
------2    
 DECLARE GLTCURSOR CURSOR  for    
    
           
 select b.location_code,b.client_code,a.REF_NO,a.REV_DATE,    
 sum(b.citicheck_amount) as total,b.deposit_type,b.D_CODE    
 from CCMSREF_TAB a ,dschedule b,client c    
 where     
 b.citicash_amount>0    
 and a.d_code=b.d_code    
 and b.client_code=c.client_code    
 and a.filename is null    
 and c.SPEED_CR_TYPE=''L''    
    
 group by a.REV_DATE,b.location_code,a.REF_NO,b.client_code,    
 a.Acc_No,a.RefAcc_No,b.deposit_type,b.D_CODE    
    
   OPEN GLTCURSOR     
    
   FETCH NEXT FROM GLTCURSOR INTO    
    
         
       @LOCATIONCD , @ClientCd ,@REF_NO,@REV_DATE, @AMOUNT ,@DEPOSITYP,@DCODE     
    
   WHILE @@FETCH_STATUS=0     
    
    BEGIN     
        update  TMP_REVERSAL set ds_code=@DCODE     
        where client_code=@ClientCd and LOCATION_CODE=@LOCATIONCD AND DEPOSIT_TYPE=@DEPOSITYP    
        and REV_DATE=@REV_DATE    
        FETCH NEXT FROM GLTCURSOR INTO    
        @LOCATIONCD , @ClientCd ,@REF_NO,@REV_DATE, @AMOUNT ,@DEPOSITYP,@DCODE    
       
   END    
   CLOSE GLTCURSOR    
    
   DEALLOCATE GLTCURSOR





         
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingCheckStatusByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-May-13
-- Description: Process booking check update status by bank
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingCheckStatusByBank]	
	@BANK_CODE		varchar(4)	
AS
BEGIN	
	DECLARE @ErrorVar		INT;

	SET NOCOUNT ON;

	UPDATE DSCHEDULE SET CHECKED=1 
		WHERE FILENAME IS NULL AND REF_NO IS NULL 
		AND (CHECKED IS NULL OR CHECKED =0) 
		AND CORR_BANK_CODE=@BANK_CODE;

		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_GetUncheckedByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-May-13
-- Description: Get unchecked dschedule records
-- =============================================

CREATE PROCEDURE [dbo].[CMS_DSchedule_GetUncheckedByBank]	
	@BANK_CODE	varchar(4)	
AS
BEGIN	
	
	SELECT * FROM DSCHEDULE		
		WHERE (CHECKED IS NULL OR CHECKED=0)
			AND CORR_BANK_CODE=@BANK_CODE
	         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollection_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Jun-13
-- Description:	Get detail from ncollection table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollection_GetDetailList]	
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN						
			SELECT nch.*,''S'' = ''U'',cc.CHECK_NO, cc.AMOUNT AS CHECK_AMOUNT,cc.D_CODE			 
				FROM NCOLLECTION_HIST nch
				LEFT OUTER JOIN CCHECK cc
				ON cc.NONZONE_REF=nch.NONZONE_REF
				WHERE nch.IS_AUTH=0
				ORDER BY nch.NONZONE_REF;
		END;
	ELSE
		BEGIN
			
			SELECT nc.*,''S'' = ''A'',cc.CHECK_NO, cc.AMOUNT AS CHECK_AMOUNT,cc.D_CODE	
				FROM NCOLLECTION_HIST nc
				LEFT OUTER JOIN CCHECK cc
				ON cc.NONZONE_REF=nc.NONZONE_REF
				WHERE nc.IS_AUTH=0
				ORDER BY nc.NONZONE_REF;
									
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollection_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 02-Mar-13
-- Description:	Authorize record to NCollection
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollection_Auth]	
	@NONZONE_REF	varchar(7),	
	@MOD_NO			int,    
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@RTN_STATUS			char(1),
			@RTN_CODE			varchar(2),
			@CC_RTN_STATUS		char(1),
			@CC_RTN_CODE		varchar(2),	
			@REF_DATE			datetime,
			@AMOUNT				numeric(12,2),
			@DDREFNO			varchar(15),
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),			
			@VAT				numeric(12, 2),
			@COMMISION			numeric(12, 2),
			@POSTAGE_CHARGE		numeric(12, 2),
			@INSTRUMENT_EXP		numeric(12, 2),				
			@IS_AUTH			bit,
			@D_CODE				varchar(12);
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT NONZONE_REF from NCOLLECTION_HIST 
			  WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @REF_DATE=REF_DATE, @DDREFNO=DDREFNO, @AMOUNT=AMOUNT, @VAT=VAT, 
				@COMMISION=COMMISION, @POSTAGE_CHARGE=POSTAGE_CHARGE, 
				@INSTRUMENT_EXP=INSTRUMENT_EXP, @RTN_STATUS=RTN_STATUS, 
				@RTN_CODE=RTN_CODE, 
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH,@STATUS=[STATUS]
				FROM NCOLLECTION_HIST 
				WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO NCOLLECTION_HIST 
				SELECT *,1 FROM NCOLLECTION
				WHERE NONZONE_REF=@NONZONE_REF;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE NCOLLECTION_HIST
				SET [STATUS] = ''O'' 
				WHERE NONZONE_REF=@NONZONE_REF 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE NCOLLECTION
				SET	REF_DATE=@REF_DATE, DDREFNO=@DDREFNO, AMOUNT=@AMOUNT, VAT=@VAT, 
				COMMISION=@COMMISION, POSTAGE_CHARGE=@POSTAGE_CHARGE, 
				INSTRUMENT_EXP=@INSTRUMENT_EXP, RTN_STATUS=@RTN_STATUS, 
				RTN_CODE=@RTN_CODE, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE NONZONE_REF=@NONZONE_REF;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END;
	
		

    -- Update CCHECK TOTAL AND CCHECK record

	SELECT @D_CODE = D_CODE 
		FROM CCHECK 
		WHERE NONZONE_REF =@NONZONE_REF
 	
	DELETE CCHECKTOTAL_HIST
		WHERE D_CODE=@D_CODE AND IS_AUTH=0;
            
	INSERT INTO CCHECKTOTAL_HIST 
		SELECT D_CODE,TOTAL_CHKNO,TOTAL_CHKAMT,
			INPUT_BY,INPUT_DATETIME,INPUT_FROM,
			AUTH_BY,AUTH_DATETIME,AUTH_FROM,MOD_NO,[STATUS],1
			FROM CCHECKTOTAL
			WHERE D_CODE =@D_CODE

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	UPDATE CCHECKTOTAL_HIST 
		SET [STATUS] = ''O'' 
		WHERE D_CODE=@D_CODE AND [STATUS] = ''L'';

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	UPDATE CCHECKTOTAL 
		SET INPUT_BY=@INPUT_BY,INPUT_DATETIME=@INPUT_DATETIME,
		INPUT_FROM=@INPUT_FROM,
		AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
		AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(), MOD_NO=MOD_NO+1 
		WHERE D_CODE=@D_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
            
	DELETE CCHECK_HIST
		WHERE D_CODE=@D_CODE AND IS_AUTH=0;

	INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE,
		CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
		CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH, 
		REMINDER_DATE, REMINDER_NO, RTN_CODE)
	    SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
		CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
		CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO,1, 
		REMINDER_DATE, REMINDER_NO, RTN_CODE 
		FROM CCHECK
		WHERE D_CODE=@D_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	UPDATE CCHECK SET MOD_NO=MOD_NO+1 
		WHERE D_CODE=@D_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

  
   
   --UPDATE CCHECK RECORD

	
	SELECT @CC_RTN_STATUS=RTN_STATUS,@CC_RTN_CODE=RTN_CODE 
			FROM NCOLLECTION_CCHECK_HIST 
			WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;
 
		
	UPDATE CCHECK SET RTN_STATUS=@CC_RTN_STATUS, 
		RTN_CODE=@CC_RTN_CODE 
		WHERE NONZONE_REF=@NONZONE_REF;

	UPDATE NCOLLECTION_CCHECK_HIST 
		SET IS_AUTH=1 
		WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO;

	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollection_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Mar-13
-- Description:	Remove detail from NCOLLECTION 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollection_Remove]	
	@NONZONE_REF	varchar(7),	
	@MOD_NO		int,
	@RET_MOD_NO	int output
AS
BEGIN
	
	DECLARE 
		@ErrorVar	int;

	SET NOCOUNT ON;
  	
	BEGIN TRANSACTION

		IF EXISTS(SELECT @NONZONE_REF from NCOLLECTION_HIST 
				  WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO AND IS_AUTH=0 )
			BEGIN
				DELETE NCOLLECTION_HIST
					WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO AND IS_AUTH=0;

				SELECT @ErrorVar = @@ERROR;		

				IF @ErrorVar <> 0				
					BEGIN
						ROLLBACK TRANSACTION;
						RETURN 1;
					END
				
				DELETE NCOLLECTION_CCHECK_HIST
					WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0 ;
									
				SELECT @ErrorVar = @@ERROR;		

				IF @ErrorVar <> 0				
					BEGIN
						ROLLBACK TRANSACTION;
						RETURN 1;
					END
		

				SELECT @RET_MOD_NO = @MOD_NO-1;

				COMMIT TRANSACTION;
				RETURN 0;			


			END
		ELSE
			BEGIN
				-- not exist
				ROLLBACK TRANSACTION;
				RETURN 4;
			END
		  
	   
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollection_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 10-Mar-13
-- Description:	Update return Of Ncollection 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollection_Update]	
	@NONZONE_REF	varchar(7),
	@MOD_NO			int,
	@RTN_STATUS		char(1),
	@RTN_CODE		varchar(2),
	@RET_MOD_NO		int output    
AS
BEGIN	
	DECLARE @ErrorVar	int,	
    @AMOUNT			    numeric(12, 2), 
	@REF_DATE	        datetime,
    @VAT			    numeric(12, 2), 
	@COMMISION	        numeric(12, 2), 
    @POSTAGE_CHARGE	    numeric(12, 2),
    @INSTRUMENT_EXP	    numeric(12, 2),
    @DDREFNO            varchar(15);
	

	SET NOCOUNT ON;

-------------

	IF EXISTS(SELECT NONZONE_REF FROM NCOLLECTION 
				WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @REF_DATE=REF_DATE,@DDREFNO=DDREFNO,@AMOUNT=AMOUNT,
				@VAT=VAT,@COMMISION=COMMISION,@POSTAGE_CHARGE=POSTAGE_CHARGE,
				@INSTRUMENT_EXP=INSTRUMENT_EXP
				FROM NCOLLECTION
				WHERE NONZONE_REF =@NONZONE_REF

--			IF @RTN_STATUS<>''O''
--				BEGIN
--					RETURN 1;
--				END

			DELETE NCOLLECTION_HIST WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN			
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO NCOLLECTION_HIST(NONZONE_REF, REF_DATE, DDREFNO, AMOUNT, 
				VAT, COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, RTN_STATUS, 
				RTN_CODE, 
				INPUT_BY, 
				INPUT_DATETIME, INPUT_FROM, MOD_NO, [STATUS], IS_AUTH)				
				VALUES(@NONZONE_REF, @REF_DATE, @DDREFNO, @AMOUNT, 
				@VAT, @COMMISION, @POSTAGE_CHARGE, @INSTRUMENT_EXP, @RTN_STATUS, 
				@RTN_CODE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END				

			DELETE NCOLLECTION_CCHECK_HIST
				WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END

			
			RETURN 0;

				
		END
	
	RETURN 1;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollection_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 10-Mar-13
-- Description:	Get Total # of modification of Normal Collection Table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollection_GetMaxMod]	
	@NONZONE_REF	varchar(7)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM NCOLLECTION_HIST 
		WHERE NONZONE_REF=@NONZONE_REF AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM NCOLLECTION 
				WHERE NONZONE_REF=@NONZONE_REF;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollection_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 10-Mar-13
-- Description:	Get detail of NCollection table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollection_GetDetail]	
	@NONZONE_REF	varchar(7),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT NONZONE_REF 
			   FROM NCOLLECTION WHERE NONZONE_REF=@NONZONE_REF AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT n.*,''IS_AUTH''=1,r.REJECT_REASON
			FROM NCOLLECTION n
			LEFT OUTER JOIN RETURN_REJECT r
			ON r.REJECT_CODE=n.RTN_CODE
			WHERE n.NONZONE_REF=@NONZONE_REF AND n.MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT nh.*,r.REJECT_REASON 
			FROM NCOLLECTION_HIST nh
			LEFT OUTER JOIN RETURN_REJECT r
			ON r.REJECT_CODE=nh.RTN_CODE
			WHERE nh.NONZONE_REF=@NONZONE_REF AND nh.MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	update detail to form_list table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Form_Update]	
	@SLNO			numeric(6,0),
	@FORMS_NAME 	varchar(60),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO FROM FORM_LIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE FORM_LIST_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO FORM_LIST_HIST(SLNO,FORMS_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@SLNO,@FORMS_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT SLNO from FORM_LIST_HIST 
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE FORM_LIST_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO FORM_LIST_HIST(SLNO,FORMS_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@SLNO,@FORMS_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Get detail of form_list  table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Form_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,''S'' = ''U''				 
			FROM FORM_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,''S'' = ''A''				
			FROM FORM_LIST
			WHERE STATUS =''L''					
			ORDER BY IS_AUTH,FORMS_NAME

		END
	ELSE
		BEGIN	

			SELECT *,''S'' = ''U''				 
			FROM FORM_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,''S'' = 
				CASE  
					WHEN STATUS = ''D'' THEN ''D''                    
					ELSE ''A''
                END 
			FROM FORM_LIST
			WHERE STATUS in (''L'',''D'')					
			ORDER BY IS_AUTH,FORMS_NAME

		END
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Get Total # of modification of form_hist table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Form_GetMaxMod]	
	@SLNO		numeric(3,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM FORM_LIST_HIST 
		WHERE SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM FORM_LIST
				WHERE SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Remove record from form_list table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Form_Remove]	
	@SLNO			numeric(6,0),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@FORMS_NAME 	varchar(60),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SLNO from FORM_LIST
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@FORMS_NAME=FORMS_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM FORM_LIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE FORM_LIST_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				FORM_LIST_HIST (SLNO,FORMS_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@SLNO,@FORMS_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT SLNO from FORM_LIST_HIST 
					  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE FORM_LIST_HIST
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Add detail to Form table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Form_Add]	
	@FORMS_NAME		varchar(60),
	@RET_SLNO		numeric(3,0) output	
AS
BEGIN	
	DECLARE @ErrorVar	int,
			@MaxS1		int,
			@MaxS2		int;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO FROM FORM_LIST WHERE FORMS_NAME=@FORMS_NAME)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE FORM_LIST_HIST WHERE 
		FORMS_NAME=@FORMS_NAME AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
		
	SELECT @MaxS1=ISNULL(MAX(SLNO),0) FROM FORM_LIST;
	SELECT @MaxS2=ISNULL(MAX(SLNO),0) FROM FORM_LIST_HIST;

	IF @MaxS1>@MaxS2
		BEGIN
			SELECT @RET_SLNO = @MaxS1 + 1;
		END
	ELSE
		BEGIN
			SELECT @RET_SLNO = @MaxS2 + 1;
		END
		

	INSERT INTO FORM_LIST_HIST(SLNO,FORMS_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@RET_SLNO,@FORMS_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Get detail of form_list table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Form_GetDetail]	
	@SLNO		numeric(6,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT SLNO 
			   FROM FORM_LIST WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM FORM_LIST 
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM FORM_LIST_HIST
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Form_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	Authorize record to forms table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Form_Auth]	
	@SLNO			numeric(6,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@FORMS_NAME		varchar(60),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO from FORM_LIST_HIST 
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@FORMS_NAME=FORMS_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM FORM_LIST_HIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO FORM_LIST_HIST 
				SELECT *,1 FROM FORM_LIST
				WHERE SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE FORM_LIST_HIST
				SET [STATUS] = ''O'' 
				WHERE SLNO=@SLNO
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE FORM_LIST
				SET FORMS_NAME=@FORMS_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE FORM_LIST_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO FORM_LIST
				SELECT SLNO,FORMS_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM FORM_LIST_HIST
					WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE FORM_LIST_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION;
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_CollectionCitiAny]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 02-June-13
-- Description: Collection Process for CitiAnywhere Check
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_CollectionCitiAny]	
AS
BEGIN	
	DECLARE 
		@ErrorVar		INT,
		@v_D_CODE		varchar(12),
		@v_SLNO			numeric(3,0),
		@maxNONZONE_REF	numeric(7,0),
		@v_Ref_From		numeric(7,0),
		@v_Flag_Ref		bit;
		
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	SET @v_Flag_Ref=0;

	DECLARE tmpcursor1 CURSOR FOR
		SELECT DISTINCT ct.D_CODE FROM CCHECKTOTAL as ct INNER JOIN CCHECK as cc 
			ON ct.D_CODE=cc.D_CODE AND ct.MOD_NO=cc.MOD_NO
			WHERE cc.RTN_STATUS =''O'' AND cc.REMINDER_DATE is null
			AND (cc.NONZONE_REF IS NULL) AND  ct.[STATUS]=''L'';

	OPEN tmpcursor1;
	FETCH NEXT FROM tmpcursor1 
        INTO @v_D_CODE;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		SET @v_Flag_Ref=1;

		DELETE CCHECKTOTAL_HIST
			WHERE D_CODE=@v_D_CODE AND IS_AUTH=0;

		INSERT INTO CCHECKTOTAL_HIST
			SELECT *,1 FROM CCHECKTOTAL WHERE D_CODE=@v_D_CODE;

		UPDATE CCHECKTOTAL_HIST
			SET [STATUS]=''O''
			WHERE D_CODE=@v_D_CODE AND [STATUS]=''L'';

		UPDATE CCHECKTOTAL
			SET MOD_NO=MOD_NO+1,
				INPUT_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),	
				INPUT_DATETIME=GETDATE(),INPUT_FROM=HOST_NAME(),
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME()
			WHERE D_CODE=@v_D_CODE;
		
		DELETE CCHECK_HIST
			WHERE D_CODE=@v_D_CODE AND IS_AUTH=0;

		INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
			CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
			CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
			CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH, REMINDER_DATE, 
			REMINDER_NO, RTN_CODE)
			SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
			CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
			CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
			CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO,1, REMINDER_DATE, 
			REMINDER_NO , RTN_CODE
			FROM CCHECK	
			WHERE D_CODE=@v_D_CODE
		
		UPDATE CCHECK
			SET MOD_NO=MOD_NO+1 
			WHERE D_CODE=@v_D_CODE

		FETCH NEXT FROM tmpcursor1 
				INTO @v_D_CODE;

	END

	CLOSE tmpcursor1;	
	DEALLOCATE tmpcursor1;
----2----------------------
	SELECT @maxNONZONE_REF=ISNULL(MAX(NONZONE_REF),0) FROM CCHECK
		WHERE NONZONE_REF IS NOT NULL;
	
	SELECT @v_Ref_From=@maxNONZONE_REF+1;
		
	DECLARE tmpcursor2 CURSOR FOR
		SELECT DISTINCT ct.D_CODE,cc.SLNO
			FROM CCHECKTOTAL as ct INNER JOIN CCHECK as cc 
			ON ct.D_CODE=cc.D_CODE AND ct.MOD_NO=cc.MOD_NO
			WHERE cc.RTN_STATUS =''O'' AND cc.REMINDER_DATE is null
			AND (cc.NONZONE_REF IS NULL) AND ct.[STATUS]=''L'';

	OPEN tmpcursor2;
	FETCH NEXT FROM tmpcursor2 
        INTO @v_D_CODE,@v_SLNO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		SELECT @maxNONZONE_REF=@maxNONZONE_REF+1;

		UPDATE CCHECK
			SET NONZONE_REF=RIGHT(''0000000'' + convert(varchar,@maxNONZONE_REF), 7),
			REMINDER_DATE=CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
			REMINDER_NO=1
			WHERE D_CODE=@v_D_CODE AND SLNO=@v_SLNO;

		INSERT NCOLLECTION(NONZONE_REF, 
			REF_DATE, 
			INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
			AUTH_BY, AUTH_DATETIME, AUTH_FROM, 
			MOD_NO, RTN_STATUS, [STATUS])
			VALUES(RIGHT(''0000000'' + convert(varchar,@maxNONZONE_REF), 7),
			CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
			substring(suser_name(),charindex(''\'',suser_name())+1,20),
			GETDATE(),HOST_NAME(),
			substring(suser_name(),charindex(''\'',suser_name())+1,20),
			GETDATE(),HOST_NAME(),
			1,''O'',''L'');


		FETCH NEXT FROM tmpcursor2 
        INTO @v_D_CODE,@v_SLNO;

	END

	CLOSE tmpcursor2;	
	DEALLOCATE tmpcursor2;

-----------------------------------
	IF @v_Flag_Ref=1
	BEGIN
		UPDATE GENPRM 
			SET  NONZONE_REF_FROM=RIGHT(''0000000'' + convert(varchar,@v_Ref_From), 7),
			NONZONE_REF_TO=RIGHT(''0000000'' + convert(varchar,@maxNONZONE_REF), 7);

	END

	SELECT @ErrorVar = @@error;			

	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	COMMIT TRANSACTION;
         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_CitiAnyFunding]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jul-13
-- Description: Process for CitiAny Funding
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_CitiAnyFunding]
	@VALUE_DATE	datetime ,        	
	@BATCH_NO	varchar(4) output	
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@v_CURR_NO		numeric(5,0),
		@v_AMOUNT		numeric(12,2),		
		@v_CNT			numeric(5),
		@v_ACC_NO		varchar(16),
		@v_VALUE_DATE	varchar(20),
		@v_CHECK_NO		varchar(15),
		@v_CHARGE		numeric(12,2),
		@v_VATPER		numeric(12,2),
		@v_VAT			numeric(12,2),
		@v_COMM_ACC		varchar(16),--
		@v_VAT_ACC		varchar(16),--
		@v_SUS_ACC		varchar(16), --
		@v_TotSuspence	numeric(12,2),
		@v_DR_CHRG_VAT	numeric(12,2),
		@v_D_CODE		varchar(12),
		@v_T_DR_CHRG_VAT	numeric(12,2),
		@v_T_CHARGE			numeric(12,2),
		@v_T_VAT			numeric(12,2),
		@v_T_CNT			numeric(5),
		@v_T_VATPER			numeric(12,2),
		@v_T2_CHARGE		numeric(12,2);
		
	SELECT @v_CURR_NO=1;
	
	SELECT @v_TotSuspence=0;
	
	SELECT @BATCH_NO = ISNULL(MAX(BATCH_NO),''5600'')+1		
		FROM GENPRM
		WHERE DATEDIFF(d,GETDATE(),BATCH_DATE)=0;

	SELECT @v_COMM_ACC = ACC_NO	
		FROM FLEX_ACC
		WHERE SLNO=1;

	SELECT @v_VAT_ACC = ACC_NO	
		FROM FLEX_ACC
		WHERE SLNO=2;

	SELECT @v_SUS_ACC = ACC_NO	
		FROM FLEX_ACC
		WHERE SLNO=3;

	SELECT @v_VALUE_DATE= SUBSTRING(CONVERT(VARCHAR,@VALUE_DATE,3),1,2) + 
		SUBSTRING(CONVERT(VARCHAR,@VALUE_DATE,3),4,2) +
		SUBSTRING(CONVERT(VARCHAR,@VALUE_DATE,3),7,2);

	DELETE FROM CITIANY_FUND;

------ type 1

	DECLARE tmpcursor1 CURSOR FOR
		SELECT sum(nc.AMOUNT) AS COLLECTED_AMOUNT,  
			COUNT(cc.NONZONE_REF) as CNT,cl.ACC_NO
			FROM NCOLLECTION nc
			INNER JOIN CCHECK cc
			ON cc.NONZONE_REF=nc.NONZONE_REF
			INNER JOIN CLIENT cl
			ON cl.CLIENT_CODE=cc.CLIENT_CODE
			WHERE cc.RTN_STATUS=''P'' AND cl.BILLING_TYPE=''1''
			AND cc.FILENAME IS NULL	
			GROUP BY cl.ACC_NO;

	OPEN tmpcursor1;
	FETCH NEXT FROM tmpcursor1 
        INTO @v_AMOUNT,@v_CNT,@v_ACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
			INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
			VALUES(@v_CURR_NO,@VALUE_DATE,@v_AMOUNT,@v_ACC_NO,''C'',
			@v_VALUE_DATE,'''',
			''CITIANYWHERE FUNDING AGAINST ''+ CONVERT(varchar,@v_CNT)
			+'' COLLECTED OUTSTATION CHECKS'',''''
			)

		SELECT @v_TotSuspence=@v_TotSuspence+@v_AMOUNT;

		SELECT @v_CURR_NO=@v_CURR_NO+1;

		FETCH NEXT FROM tmpcursor1 
			INTO @v_AMOUNT,@v_CNT,@v_ACC_NO;

	END

	CLOSE tmpcursor1;	
	DEALLOCATE tmpcursor1;

------------- type 2
	
	DECLARE tmpcursor2 CURSOR FOR
		SELECT cl.acc_no,
			nc.AMOUNT-cl.CITIANY_CHARGE-(cl.CITIANY_STD_CHARGE*cl.CITIANY_VAT/100) AS PAYED_AMOUNT,
			cc.CHECK_NO,cl.CITIANY_CHARGE,cl.CITIANY_VAT AS CITIVATPER,
			(cl.CITIANY_STD_CHARGE*cl.CITIANY_VAT/100) AS CITIVAT
			FROM NCOLLECTION nc
			INNER JOIN CCHECK cc
			ON cc.NONZONE_REF=nc.NONZONE_REF
			INNER JOIN CLIENT cl
			ON cl.CLIENT_CODE=cc.CLIENT_CODE
			WHERE cc.RTN_STATUS=''P'' AND cl.BILLING_TYPE=''2''
			AND cc.FILENAME IS NULL	
			ORDER BY cl.CLIENT_CODE;

	OPEN tmpcursor2;
	FETCH NEXT FROM tmpcursor2 
        INTO @v_ACC_NO,@v_AMOUNT,@v_CHECK_NO,@v_CHARGE,@v_VATPER,@v_VAT;

	WHILE @@FETCH_STATUS=0 
 	BEGIN

		INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
			INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
			VALUES(@v_CURR_NO,@VALUE_DATE,@v_AMOUNT,@v_ACC_NO,''C'',
			@v_CHECK_NO,'''',
			''CITIANYWHERE FUNDING LESS DRAWEE BANK CHARGES VAT AND OUR COLLECTION COMMISSION @ TK. ''+ CONVERT(varchar,@v_CHARGE) 
			+ '' INCLUDING '' + CONVERT(varchar,@v_VATPER) +''% VAT ON COMMISSION.'',''''
			);		

		SELECT @v_CURR_NO=@v_CURR_NO+1;
		SELECT @v_TotSuspence=@v_TotSuspence+@v_AMOUNT;

		IF @v_CHARGE<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_CHARGE,@v_COMM_ACC,''C'',
				@v_CHECK_NO,''BD0''+ SUBSTRING(@v_ACC_NO,8,6),@v_ACC_NO,''1056''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence+@v_CHARGE;
		END

		IF @v_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_VAT,@v_VAT_ACC,''C'',
				@v_CHECK_NO,''BD0''+ SUBSTRING(@v_ACC_NO,8,6),@v_ACC_NO,''1602''
				);
			
			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence+@v_VAT;
		END

		FETCH NEXT FROM tmpcursor2 
			INTO @v_ACC_NO,@v_AMOUNT,@v_CHECK_NO,@v_CHARGE,@v_VATPER,@v_VAT;

	END

	CLOSE tmpcursor2;	
	DEALLOCATE tmpcursor2;
	
------------- type 3

	DECLARE tmpcursor3 CURSOR FOR
		SELECT DISTINCT cl.ACC_NO
			FROM  CCHECK cc
			INNER JOIN CLIENT cl
			ON cl.CLIENT_CODE=cc.CLIENT_CODE
			WHERE cc.RTN_STATUS=''P'' AND cl.BILLING_TYPE=''3''
			AND cc.FILENAME IS NULL	


	OPEN tmpcursor3;
	FETCH NEXT FROM tmpcursor3 
        INTO @v_ACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		DECLARE tmpcursor3_1 CURSOR FOR
			SELECT 
				cc.AMOUNT AS CHECKAMOUNT,(cc.AMOUNT-nc.AMOUNT) AS DRAWEE_CRG_VAT,
				cl.CITIANY_CHARGE,
				(cl.CITIANY_STD_CHARGE*cl.CITIANY_VAT/100) AS CITIVAT,
				cc.CHECK_NO,cc.D_CODE,
				cl.CITIANY_VAT AS CITIVATPER
				FROM NCOLLECTION nc
				INNER JOIN CCHECK cc
				ON cc.NONZONE_REF=nc.NONZONE_REF
				INNER JOIN CLIENT cl
				ON cl.CLIENT_CODE=cc.CLIENT_CODE
				WHERE cc.RTN_STATUS=''P'' AND cl.BILLING_TYPE=''3''
				AND cc.FILENAME IS NULL	
				AND cl.ACC_NO=@v_ACC_NO
			
		SELECT @v_T_DR_CHRG_VAT=0;
		SELECT @v_T_CHARGE=0;
		SELECT @v_T_VAT=0;
		SELECT @v_T_CNT=0;
		SELECT @v_T_VATPER=0;
		SELECT @v_T2_CHARGE=0;

		OPEN tmpcursor3_1;
		FETCH NEXT FROM tmpcursor3_1 
			INTO @v_AMOUNT,@v_DR_CHRG_VAT,
			@v_CHARGE,@v_VAT,@v_CHECK_NO,@v_D_CODE,@v_VATPER;

		WHILE @@FETCH_STATUS=0 
 		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_AMOUNT,@v_ACC_NO,''C'',
				@v_CHECK_NO,'''',
				''1 OUTSTATION CHECK   CHECK NO  '' + @v_CHECK_NO 
				+''   DS NO  ''+ @v_D_CODE ,''''
				);

			SELECT @v_T_DR_CHRG_VAT=@v_T_DR_CHRG_VAT+@v_DR_CHRG_VAT;
			SELECT @v_T_CHARGE=@v_T_CHARGE+@v_CHARGE;
			SELECT @v_T_VAT=@v_T_VAT+@v_VAT;
			SELECT @v_T_CNT=@v_T_CNT+1;
			SELECT @v_T_VATPER=@v_VATPER;
			SELECT @v_T2_CHARGE=@v_CHARGE;
	
			
			SELECT @v_TotSuspence=@v_TotSuspence+@v_AMOUNT;
			SELECT @v_CURR_NO=@v_CURR_NO+1;


			FETCH NEXT FROM tmpcursor3_1 
				INTO @v_AMOUNT,@v_DR_CHRG_VAT,
				@v_CHARGE,@v_VAT,@v_CHECK_NO,@v_D_CODE,@v_VATPER;
		END

		IF @v_T_DR_CHRG_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_T_DR_CHRG_VAT,@v_ACC_NO,''D'',
				@v_VALUE_DATE,'''',
				''DEDUCTION FOR DRAWEE BANK CHARGES AND VAT FOR''+CONVERT(varchar,@v_T_CNT)
				+'' COLLECTION CHECKS'' ,''''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence-@v_T_DR_CHRG_VAT;
		END

		IF @v_T_CHARGE + @v_T_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_T_CHARGE + @v_T_VAT,@v_ACC_NO,''D'',
				@v_VALUE_DATE,'''',
				''DEDUCTION FOR OUR COLLECTION COMMISSION @ TK. ''+ CONVERT(varchar,@v_T2_CHARGE) 
				+'' PER  CHECK INCLUDING ''+CONVERT(varchar,@v_T_VATPER)+''% VAT FOR''+CONVERT(varchar,@v_T_CNT)
				+''COLLECTION CHECKS'' ,''''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence-@v_T_CHARGE-@v_T_VAT;
		END

		IF @v_T_CHARGE<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_T_CHARGE,@v_COMM_ACC,''C'',
				@v_VALUE_DATE,''BD0''+ SUBSTRING(@v_ACC_NO,8,6),@v_ACC_NO,''1056''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence+@v_T_CHARGE;
		END

		IF @v_T_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_T_VAT,@v_VAT_ACC,''C'',
				@v_VALUE_DATE,''BD0''+ SUBSTRING(@v_ACC_NO,8,6),@v_ACC_NO,''1602''
				);
			
			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence+@v_T_VAT;
		END

		CLOSE tmpcursor3_1;	
		DEALLOCATE tmpcursor3_1;


		FETCH NEXT FROM tmpcursor3 
			INTO @v_ACC_NO;
	END

	CLOSE tmpcursor3;	
	DEALLOCATE tmpcursor3;




------------- type 4
	
	DECLARE tmpcursor4 CURSOR FOR
		SELECT cl.acc_no,
			cc.AMOUNT AS CHECKAMOUNT,(cc.AMOUNT-nc.AMOUNT)AS DRAWEE_CRG_VAT,
			cl.CITIANY_CHARGE,(cl.CITIANY_STD_CHARGE*cl.CITIANY_VAT/100) AS CITIVAT,
			cc.CHECK_NO,cc.D_CODE,
			cl.CITIANY_VAT AS CITIVATPER
			FROM NCOLLECTION nc
			INNER JOIN CCHECK cc
			ON cc.NONZONE_REF=nc.NONZONE_REF
			INNER JOIN CLIENT cl
			ON cl.CLIENT_CODE=cc.CLIENT_CODE
			WHERE cc.RTN_STATUS=''P'' AND cl.BILLING_TYPE=''4''
			AND cc.FILENAME IS NULL	
			ORDER BY cl.CLIENT_CODE


	OPEN tmpcursor4;
	FETCH NEXT FROM tmpcursor4 
        INTO @v_ACC_NO,@v_AMOUNT,@v_DR_CHRG_VAT,
			@v_CHARGE,@v_VAT,@v_CHECK_NO,@v_D_CODE,@v_VATPER;

	WHILE @@FETCH_STATUS=0 
 	BEGIN

		INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
			INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
			VALUES(@v_CURR_NO,@VALUE_DATE,@v_AMOUNT,@v_ACC_NO,''C'',
			@v_CHECK_NO,'''',
			''1 OUTSTATION CHECK   CHECK NO  '' + @v_CHECK_NO 
			+''   DS NO  ''+ @v_D_CODE ,''''
			);

		SELECT @v_CURR_NO=@v_CURR_NO+1;
		SELECT @v_TotSuspence=@v_TotSuspence+@v_AMOUNT;

-----------
		IF @v_DR_CHRG_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_DR_CHRG_VAT,@v_ACC_NO,''D'',
				@v_CHECK_NO,'''',
				''DEDUCTION FOR DRAWEE BANK CHARGES AND VAT'' ,''''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence-@v_DR_CHRG_VAT;
		END


--------------
		IF @v_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_CHARGE + @v_VAT,@v_ACC_NO,''D'',
				@v_CHECK_NO,'''',
				''DEDUCTION FOR OUR COLLECTION COMMISSION OF TK. ''+ CONVERT(varchar,@v_CHARGE) 
				+'' AND ''+ CONVERT(varchar,@v_VATPER) +''% VAT ON CHARGES'' ,''''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence-@v_CHARGE-@v_VAT;
		END

---------
		
		IF @v_CHARGE<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_CHARGE,@v_COMM_ACC,''C'',
				@v_CHECK_NO,''BD0''+ SUBSTRING(@v_ACC_NO,8,6),@v_ACC_NO,''1056''
				);

			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence+@v_CHARGE;
		END

		IF @v_VAT<>0 
		BEGIN
			INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
				INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
				VALUES(@v_CURR_NO,@VALUE_DATE,@v_VAT,@v_VAT_ACC,''C'',
				@v_CHECK_NO,''BD0''+ SUBSTRING(@v_ACC_NO,8,6),@v_ACC_NO,''1602''
				);
			
			SELECT @v_CURR_NO=@v_CURR_NO+1;
			SELECT @v_TotSuspence=@v_TotSuspence+@v_VAT;
		END

		FETCH NEXT FROM tmpcursor4 
			INTO @v_ACC_NO,@v_AMOUNT,@v_DR_CHRG_VAT,
				@v_CHARGE,@v_VAT,@v_CHECK_NO,@v_D_CODE,@v_VATPER;

	END

	CLOSE tmpcursor4;	
	DEALLOCATE tmpcursor4;


	IF @v_TotSuspence<>0
	BEGIN
		INSERT INTO CITIANY_FUND(CURR_NO, VALUE_DATE, AMOUNT, ACC_NO, DR_CR, 
			INSTRUMENT_NO, REL_CUST, ADD_TEXT, MIS_CODE4)
			VALUES(@v_CURR_NO,@VALUE_DATE,@v_TotSuspence,@v_SUS_ACC,''D'',
			'''','''',''CITIANYWHERE FUNDING'',''''
			);
	END

	RETURN 0;
	
    
END   

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Get detail of DCollected by code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_GetDetailByCode]	
	@DS_CODE	varchar(12)	
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT * 
	FROM DCOLLECTED
	WHERE DS_CODE=@DS_CODE

	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Mar-12
-- Description:	Get detail to DCollected table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit,
	@ENTRY_DATE	datetime
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM DCOLLECTED_HIST 
				WHERE IS_AUTH=0
				ORDER BY DS_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM DCOLLECTED
						WHERE [STATUS] =''L''
						AND ENTRY_DATE=@ENTRY_DATE
						ORDER BY DS_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM DCOLLECTED
						WHERE [STATUS] IN (''L'',''D'')
						AND ENTRY_DATE=@ENTRY_DATE
						ORDER BY DS_CODE;
				END;
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 02-Jan-13
-- Description:	Get detail of DCollected
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_GetDetail]	
	@DS_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
			   FROM DCOLLECTED WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM DCOLLECTED 
			WHERE DS_CODE=@DS_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM DCOLLECTED_HIST
			WHERE DS_CODE=@DS_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jan-13
-- Description:	update detail to DCollected
-- =============================================

CREATE PROCEDURE [dbo].[CMS_DCollected_Update]	
	@DS_CODE		varchar(12), 
	@TOTAL_NOCHK	numeric(4,0), 
	@TOTAL_CHKAMT	numeric(12,2), 
	@TOTAL_CASHAMT	numeric(12,2),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ENTRY_DATE datetime;
	DECLARE @ErrorVar	INT;	
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT DS_CODE FROM DCOLLECTED 
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			SELECT @ENTRY_DATE=ENTRY_DATE FROM DCOLLECTED 
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;

			DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO DCOLLECTED_HIST(DS_CODE, TOTAL_NOCHK, 
				TOTAL_CHKAMT, TOTAL_CASHAMT,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH,
				ENTRY_DATE)
				VALUES(@DS_CODE, @TOTAL_NOCHK, 
				@TOTAL_CHKAMT, @TOTAL_CASHAMT,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0,
				@ENTRY_DATE);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE DSCHEDULE_HIST
				WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT DS_CODE from DCOLLECTED_HIST 
						WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					SELECT @ENTRY_DATE=ENTRY_DATE from DCOLLECTED_HIST 
						WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO DCOLLECTED_HIST(DS_CODE, TOTAL_NOCHK, 
						TOTAL_CHKAMT, TOTAL_CASHAMT,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH,
						ENTRY_DATE)
						VALUES(@DS_CODE, @TOTAL_NOCHK, 
						@TOTAL_CHKAMT, @TOTAL_CASHAMT,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0,
						@ENTRY_DATE);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE DSCHEDULE_HIST
						WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 02-Jan-13
-- Description:	Get Total # of modification of DCollected
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_GetMaxMod]
	@DS_CODE			varchar(12)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM DCOLLECTED_HIST 
		WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM DCOLLECTED
				WHERE DS_CODE=@DS_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DCollected_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 02-Jan-13
-- Description:	Add detail to Deposit Schedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DCollected_Add]	
	@DS_CODE		varchar(12), 
	@TOTAL_NOCHK	numeric(4,0), 
	@TOTAL_CHKAMT	numeric(12,2), 
	@TOTAL_CASHAMT	numeric(12,2)
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT DS_CODE FROM DCOLLECTED
				WHERE DS_CODE=@DS_CODE)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE DCOLLECTED_HIST WHERE 
		DS_CODE=@DS_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO DCOLLECTED_HIST(DS_CODE, TOTAL_NOCHK, 
		TOTAL_CHKAMT, TOTAL_CASHAMT,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH,ENTRY_DATE)
		VALUES(@DS_CODE, @TOTAL_NOCHK, 
		@TOTAL_CHKAMT, @TOTAL_CASHAMT,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0,CONVERT(datetime,CONVERT(varchar(12), GETDATE())));

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE DSCHEDULE_HIST WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollectionAddedByDD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- Author:		Fahad Khan
-- Create date: 25-Feb-13
-- Description:	CCheck table ADD by DD Details
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollectionAddedByDD]
    @D_CODE				varchar(12),
    @SLNO               numeric(3,0),
	@NONZONE_REF	    varchar(7),
    @AMOUNT			    numeric(12, 2), 	
    @VAT			    numeric(12, 2), 
	@COMMISION	        numeric(12, 2), 
    @POSTAGE_CHARGE	    numeric(12, 2),
    @INSTRUMENT_EXP	    numeric(12, 2) 
    
AS
BEGIN	
		
	SET NOCOUNT ON;

	INSERT INTO DD_NCOLLECTION_HIST(D_CODE, SLNO, NONZONE_REF, AMOUNT, VAT, 
		COMMISION, POSTAGE_CHARGE, INSTRUMENT_EXP, 
		INPUT_BY, 
		INPUT_DATETIME, INPUT_FROM, MOD_NO, RTN_STATUS, [STATUS], IS_AUTH)
        VALUES(@D_CODE,@SLNO,@NONZONE_REF,@AMOUNT,@VAT,
		@COMMISION,@POSTAGE_CHARGE,@INSTRUMENT_EXP,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
        GETDATE(),HOST_NAME(),1,''D'',''U'',0);
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_NCollectionUpdateByDD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 07-Mar-13
-- Description:	CCheck table Update by DD Details
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollectionUpdateByDD]
    @D_CODE				varchar(12),
    @SLNO               numeric(3,0),
    @MOD_NO             int,
	@NONZONE_REF	    varchar(7),
    @AMOUNT			    numeric(12, 2), 	
    @VAT			    numeric(12, 2), 
	@COMMISION	        numeric(12, 2), 
    @POSTAGE_CHARGE	    numeric(12, 2),
    @INSTRUMENT_EXP	    numeric(12, 2)    
AS
BEGIN	
		
	SET NOCOUNT ON;

	INSERT INTO DD_NCOLLECTION_HIST(D_CODE,SLNO,NONZONE_REF,AMOUNT,VAT,
		COMMISION,POSTAGE_CHARGE,INSTRUMENT_EXP,
		INPUT_BY,
		INPUT_DATETIME,
        INPUT_FROM,MOD_NO,RTN_STATUS,[STATUS],IS_AUTH)
		VALUES(@D_CODE,@SLNO,@NONZONE_REF,@AMOUNT,@VAT,
		@COMMISION,@POSTAGE_CHARGE,@INSTRUMENT_EXP,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),@MOD_NO,''D'',''U'',0);
		   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Nov-12
-- Description:	Authorize record to client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_Auth]	
	@CLIENT_CODE	varchar(6),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@ACC_NO				varchar(16),  
			@ACC_NAME			varchar(50),
			@MAIL_ADD			varchar(256), 
			@CONTACT			varchar(50), 
			@CASH_DAYS			numeric(2,0), 
			@SPEED_DAYS			numeric(2,0), 
			@CASH_CR_TYPE		varchar(25),
			@SPEED_CR_TYPE		varchar(25),
			@CASH_CHARGE		numeric(12,2), 
			@SPEED_CHARGE		numeric(12,2), 
			@RETURN_CHARGE		numeric(12,2), 
			@CASH_STD_CHARGE	numeric(12,2), 
			@SPEED_STD_CHARGE	numeric(12,2), 
			@CASH_VAT			numeric(8,2), 
			@SPEED_VAT			numeric(8,2), 
			@CITIANY_CHARGE		numeric(12,2), 
			@CITIANY_STD_CHARGE numeric(12,2), 
			@CITIANY_VAT		numeric(8,2), 
			@BILLING_TYPE		varchar(25),
			@IS_DISABLE			bit,
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),
			@AUTH_BY			varchar(20),
			@AUTH_DATETIME		datetime,
			@AUTH_FROM			varchar(30),
			@LAST_MOD_NO		int,
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CLIENT_CODE from CLIENT_HIST 
			  WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CLIENT_CODE=CLIENT_CODE, @ACC_NO=ACC_NO, 
				@ACC_NAME=ACC_NAME,@MAIL_ADD=MAIL_ADD,@CONTACT=CONTACT,
				@CASH_DAYS=CASH_DAYS, @SPEED_DAYS=SPEED_DAYS, 
				@CASH_CR_TYPE=CASH_CR_TYPE, @SPEED_CR_TYPE=SPEED_CR_TYPE,
				@CASH_CHARGE=CASH_CHARGE, @SPEED_CHARGE=SPEED_CHARGE, 
				@RETURN_CHARGE=RETURN_CHARGE, @CASH_STD_CHARGE=CASH_STD_CHARGE,
				@SPEED_STD_CHARGE=SPEED_STD_CHARGE, @CASH_VAT=CASH_VAT, 
				@SPEED_VAT=SPEED_VAT, @CITIANY_CHARGE=CITIANY_CHARGE, 
				@CITIANY_STD_CHARGE=CITIANY_STD_CHARGE, 
				@CITIANY_VAT=CITIANY_VAT, @BILLING_TYPE=BILLING_TYPE,
				@IS_DISABLE=IS_DISABLE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLIENT_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLIENT_HIST 
				SELECT *,1 FROM CLIENT
				WHERE CLIENT_CODE=@CLIENT_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLIENT_HIST
				SET [STATUS] = ''O'' 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLIENT
				SET ACC_NO=@ACC_NO, 
				ACC_NAME=@ACC_NAME,MAIL_ADD=@MAIL_ADD,CONTACT=@CONTACT,
				CASH_DAYS=@CASH_DAYS, SPEED_DAYS=@SPEED_DAYS, 
				CASH_CR_TYPE=@CASH_CR_TYPE, SPEED_CR_TYPE=@SPEED_CR_TYPE,
				CASH_CHARGE=@CASH_CHARGE, SPEED_CHARGE=@SPEED_CHARGE, 
				RETURN_CHARGE=@RETURN_CHARGE, CASH_STD_CHARGE=@CASH_STD_CHARGE,
				SPEED_STD_CHARGE=@SPEED_STD_CHARGE, CASH_VAT=@CASH_VAT, 
				SPEED_VAT=@SPEED_VAT, CITIANY_CHARGE=@CITIANY_CHARGE, 
				CITIANY_STD_CHARGE=@CITIANY_STD_CHARGE, 
				CITIANY_VAT=@CITIANY_VAT, BILLING_TYPE=@BILLING_TYPE,
				IS_DISABLE=@IS_DISABLE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE CLIENT_CODE=@CLIENT_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLIENT_HIST WHERE CLIENT_CODE=@CLIENT_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLIENT
				SELECT CLIENT_CODE, ACC_NO, ACC_NAME,MAIL_ADD,
					CONTACT, CASH_DAYS, SPEED_DAYS, CASH_CR_TYPE, SPEED_CR_TYPE,
					CASH_CHARGE, SPEED_CHARGE, RETURN_CHARGE, CASH_STD_CHARGE,
					SPEED_STD_CHARGE, CASH_VAT, SPEED_VAT, CITIANY_CHARGE, 
					CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE,IS_DISABLE, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM,
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLIENT_HIST
					WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLIENT_HIST WHERE CLIENT_CODE=@CLIENT_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Nov-12
-- Description:	Add detail to Client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_Add]	
	@CLIENT_CODE		varchar(6), 
	@ACC_NO				varchar(16),  
	@ACC_NAME			varchar(50),
	@MAIL_ADD			varchar(256), 
	@CONTACT			varchar(50), 
	@CASH_DAYS			numeric(2,0), 
	@SPEED_DAYS			numeric(2,0), 
	@CASH_CR_TYPE		varchar(25),
	@SPEED_CR_TYPE		varchar(25),
	@CASH_CHARGE		numeric(12,2), 
	@SPEED_CHARGE		numeric(12,2), 
	@RETURN_CHARGE		numeric(12,2), 
	@CASH_STD_CHARGE	numeric(12,2), 
	@SPEED_STD_CHARGE	numeric(12,2), 
	@CASH_VAT			numeric(8,2), 
	@SPEED_VAT			numeric(8,2), 
	@CITIANY_CHARGE		numeric(12,2), 
	@CITIANY_STD_CHARGE numeric(12,2), 
	@CITIANY_VAT		numeric(8,2), 
	@BILLING_TYPE		varchar(25),
	@IS_DISABLE			bit
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CLIENT_CODE FROM CLIENT WHERE CLIENT_CODE=@CLIENT_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CLIENT_HIST WHERE 
		CLIENT_CODE=@CLIENT_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CLIENT_HIST(CLIENT_CODE, ACC_NO, ACC_NAME,MAIL_ADD,
		CONTACT, CASH_DAYS, SPEED_DAYS, CASH_CR_TYPE, SPEED_CR_TYPE,
		CASH_CHARGE, SPEED_CHARGE, RETURN_CHARGE, CASH_STD_CHARGE,
		SPEED_STD_CHARGE, CASH_VAT, SPEED_VAT, CITIANY_CHARGE, 
		CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE, IS_DISABLE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
		@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
		@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
		@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
		@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE, @IS_DISABLE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Nov-12
-- Description:	get detail of client table
--				by client_code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetDetailByCode]	
	@CLIENT_CODE	varchar(6)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT *
		FROM CLIENT 		
		WHERE CLIENT_CODE=@CLIENT_CODE	
		AND IS_DISABLE=0
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail to Client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM CLIENT_HIST 
				WHERE IS_AUTH=0			
				ORDER BY CLIENT_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CLIENT
						WHERE [STATUS] =''L''					
						ORDER BY CLIENT_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CLIENT
						WHERE [STATUS] in (''L'',''D'')					
						ORDER BY CLIENT_CODE
				END;
		END;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Nov-12
-- Description:	update detail to client table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Client_Update]	
	@CLIENT_CODE		varchar(6),
	@ACC_NO				varchar(16),  
	@ACC_NAME			varchar(50),
	@MAIL_ADD			varchar(256), 
	@CONTACT			varchar(50), 
	@CASH_DAYS			numeric(2,0), 
	@SPEED_DAYS			numeric(2,0), 
	@CASH_CR_TYPE		varchar(25),
	@SPEED_CR_TYPE		varchar(25),
	@CASH_CHARGE		numeric(12,2), 
	@SPEED_CHARGE		numeric(12,2), 
	@RETURN_CHARGE		numeric(12,2), 
	@CASH_STD_CHARGE	numeric(12,2), 
	@SPEED_STD_CHARGE	numeric(12,2), 
	@CASH_VAT			numeric(8,2), 
	@SPEED_VAT			numeric(8,2), 
	@CITIANY_CHARGE		numeric(12,2), 
	@CITIANY_STD_CHARGE numeric(12,2), 
	@CITIANY_VAT		numeric(8,2), 
	@BILLING_TYPE		varchar(25),
	@IS_DISABLE			bit,
	@MOD_NO				int,
	@RET_MOD_NO			int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CLIENT_CODE FROM CLIENT 
				WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CLIENT_HIST WHERE CLIENT_CODE=@CLIENT_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CLIENT_HIST(CLIENT_CODE, ACC_NO, ACC_NAME,MAIL_ADD,
				CONTACT, CASH_DAYS, SPEED_DAYS, CASH_CR_TYPE, SPEED_CR_TYPE,
				CASH_CHARGE, SPEED_CHARGE, RETURN_CHARGE, CASH_STD_CHARGE,
				SPEED_STD_CHARGE, CASH_VAT, SPEED_VAT, CITIANY_CHARGE, 
				CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE, IS_DISABLE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
				@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
				@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
				@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
				@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE, @IS_DISABLE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT CLIENT_CODE from CLIENT_HIST 
						WHERE CLIENT_CODE=@CLIENT_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CLIENT_HIST WHERE CLIENT_CODE=@CLIENT_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CLIENT_HIST(CLIENT_CODE, ACC_NO, ACC_NAME,MAIL_ADD,
						CONTACT, CASH_DAYS, SPEED_DAYS, CASH_CR_TYPE, SPEED_CR_TYPE,
						CASH_CHARGE, SPEED_CHARGE, RETURN_CHARGE, CASH_STD_CHARGE,
						SPEED_STD_CHARGE, CASH_VAT, SPEED_VAT, CITIANY_CHARGE, 
						CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE, IS_DISABLE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
						@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
						@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
						@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
						@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE, @IS_DISABLE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Get detail of CCHECK
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_GetDetails]	
	@D_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM CCHECK WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT cc.*,''IS_AUTH''=1,
				c.ACC_NAME,c.ACC_NO,l1.LOCATION_NAME as DLOCATION_NAME,
				b.BANK_NAME as DRAWEE_BANK_NAME,br.BRANCH_NAME,
				l2.LOCATION_NAME
			FROM CCHECK cc
				LEFT OUTER JOIN CLIENT c
				ON c.CLIENT_CODE=cc.CLIENT_CODE
				LEFT OUTER JOIN LOCATION l1
				ON l1.LOCATION_CODE=cc.DLOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=cc.DRAWEE_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=cc.BRANCH_CODE AND br.BANK_CODE=cc.DRAWEE_BANK_CODE
				AND br.LOCATION_CODE=cc.LOCATION_CODE
				LEFT OUTER JOIN LOCATION l2
				ON l2.LOCATION_CODE=cc.LOCATION_CODE
			WHERE cc.D_CODE=@D_CODE AND cc.MOD_NO = @MOD_NO
			ORDER BY D_CODE
		END	
	ELSE
		BEGIN
			SELECT cch.* ,
				c.ACC_NAME,c.ACC_NO,l1.LOCATION_NAME as DLOCATION_NAME,
				b.BANK_NAME as DRAWEE_BANK_NAME,br.BRANCH_NAME,
				l2.LOCATION_NAME
			FROM CCHECK_HIST cch
				LEFT OUTER JOIN CLIENT c
				ON c.CLIENT_CODE=cch.CLIENT_CODE
				LEFT OUTER JOIN LOCATION l1
				ON l1.LOCATION_CODE=cch.DLOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=cch.DRAWEE_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=cch.BRANCH_CODE AND br.BANK_CODE=cch.DRAWEE_BANK_CODE
				AND br.LOCATION_CODE=cch.LOCATION_CODE
				LEFT OUTER JOIN LOCATION l2
				ON l2.LOCATION_CODE=cch.LOCATION_CODE
			WHERE cch.D_CODE=@D_CODE AND cch.MOD_NO = @MOD_NO
			ORDER BY D_CODE
		END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_GetListInvCredit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-May-13
-- Description:	Get clients of invalid credit entry
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetListInvCredit]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT * FROM CLIENT
		WHERE CASH_DAYS IS NULL 
			OR SPEED_DAYS IS NULL
			OR CASH_CR_TYPE IS NULL OR CASH_CR_TYPE=''''
			OR SPEED_CR_TYPE IS NULL OR SPEED_CR_TYPE=''''
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_GetSummList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Nov-12
-- Description:	Get Summary to Client location charge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_GetSummList]
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U'',cl.ACC_NAME,cl.ACC_NO,lc.LOCATION_NAME				 
				FROM CLIENT_LOC_CHARGE_HIST as clch
				LEFT OUTER JOIN CLIENT as cl ON cl.CLIENT_CODE=clch.CLIENT_CODE
				LEFT OUTER JOIN LOCATION as lc ON lc.LOCATION_CODE=clch.LOCATION_CODE				 
				WHERE clch.IS_AUTH=0			
				ORDER BY clch.CLIENT_CODE,clch.LOCATION_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A'',cl.ACC_NAME,cl.ACC_NO,lc.LOCATION_NAME				
						FROM CLIENT_LOC_CHARGE as clc
						LEFT OUTER JOIN CLIENT as cl ON cl.CLIENT_CODE=clc.CLIENT_CODE
						LEFT OUTER JOIN LOCATION as lc ON lc.LOCATION_CODE=clc.LOCATION_CODE
						WHERE clc.STATUS =''L''					
						ORDER BY clc.CLIENT_CODE,clc.LOCATION_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN clc.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END, cl.ACC_NAME,cl.ACC_NO,lc.LOCATION_NAME 
						FROM CLIENT_LOC_CHARGE as clc
						LEFT OUTER JOIN CLIENT as cl ON cl.CLIENT_CODE=clc.CLIENT_CODE
						LEFT OUTER JOIN LOCATION as lc ON lc.LOCATION_CODE=clc.LOCATION_CODE
						WHERE clc.STATUS in (''L'',''D'')					
						ORDER BY clc.CLIENT_CODE,clc.LOCATION_CODE
				END;
		END;


		   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Client_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Dec-12
-- Description:	get list records of client
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetList]	
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT CLIENT_CODE, ACC_NO, ACC_NAME
	FROM CLIENT		
	WHERE STATUS=''L''
	AND IS_DISABLE=0	
	ORDER BY ACC_NAME;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_GetDetailsByAmntStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 22-FEB-13
-- Description:	Get detail of CCheck by amount, Status, Drawee bank, branch
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_GetDetailsByAmntStatus]	
	@DRAWEE_BANK_CODE	varchar(4),
    @LOCATION_CODE    	varchar(4),
    @BRANCH_CODE    	varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	 SELECT cs.*,cl.ACC_NAME,cl.ACC_NO,cl.CITIANY_CHARGE,cl.CITIANY_STD_CHARGE,CITIANY_VAT
     FROM CCHECK cs
     INNER JOIN CLIENT cl ON cs.CLIENT_CODE=cl.CLIENT_CODE
     WHERE cs.DRAWEE_BANK_CODE = @DRAWEE_BANK_CODE AND cs.LOCATION_CODE = @LOCATION_CODE
     AND cs.BRANCH_CODE= @BRANCH_CODE AND cs.RTN_STATUS=''O'' AND cs.NONZONE_REF > ''0''
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_CitiAnyFundUpdateRef]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 4-Jul-13
-- Description: Update CCHECK with CITYANY_FUND
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_CitiAnyFundUpdateRef]
	@FILENAME		varchar(15),	
	@VALUE_DATE		datetime, 
	@BATCH_NO		varchar(10)
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
      
    UPDATE CCHECK SET [FILENAME]=@FILENAME,
		FILE_USER_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20),
		FLEXGEN_DATE=@VALUE_DATE 		
		WHERE RTN_STATUS=''P'' 
		AND [FILENAME] IS NULL;
		
	UPDATE CCHECK SET [FILENAME]=@FILENAME,
		FILE_USER_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20),
		FLEXGEN_DATE=@VALUE_DATE
		FROM CCHECK cc
		INNER JOIN CLIENT cl ON cc.CLIENT_CODE=cl.CLIENT_CODE		
		WHERE cc.RTN_STATUS=''P''	AND cc.[FILENAME] IS NULL
		AND cl.BILLING_TYPE in (''1'',''2'',''3'',''4'');

	UPDATE GENPRM
		SET BATCH_NO=@BATCH_NO, BATCH_DATE=GETDATE();     
    
	    
                         
	IF @@ERROR<>0 GOTO ErrorHandler              
               
               
	RETURN 0;            
                         
    ErrorHandler:              
	            
	             
	RETURN 1;
	
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_GetDetailByCheckNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Get detail of CCHECK by check no
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_GetDetailByCheckNo]	
	@CHECK_NO	varchar(15)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT cc.* ,
		cl.ACC_NAME,cl.ACC_NO,
		b.BANK_NAME,br.BRANCH_NAME
	FROM CCHECK cc
		LEFT OUTER JOIN CLIENT cl
		ON cl.CLIENT_CODE=cc.CLIENT_CODE		
		LEFT OUTER JOIN BANK b
		ON b.BANK_CODE=cc.DRAWEE_BANK_CODE
		LEFT OUTER JOIN BRANCH br
		ON br.BRANCH_CODE=cc.BRANCH_CODE		
	WHERE cc.CHECK_NO=@CHECK_NO
	ORDER BY D_CODE

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_GetDetailByRefNo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Get detail of CCHECK by nonzone_ref
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_GetDetailByRefNo]	
	@NONZONE_REF	varchar(7)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT cc.* ,
		cl.ACC_NAME,cl.ACC_NO,
		b.BANK_NAME,br.BRANCH_NAME
	FROM CCHECK cc
		LEFT OUTER JOIN CLIENT cl
		ON cl.CLIENT_CODE=cc.CLIENT_CODE		
		LEFT OUTER JOIN BANK b
		ON b.BANK_CODE=cc.DRAWEE_BANK_CODE
		LEFT OUTER JOIN BRANCH br
		ON br.BRANCH_CODE=cc.BRANCH_CODE		
	WHERE cc.NONZONE_REF=@NONZONE_REF

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	get list records of location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT LOCATION_CODE,LOCATION_NAME FROM LOCATION WHERE STATUS=''L''
	ORDER BY LOCATION_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Fahad Khan
-- Create date: 25-Feb-13
-- Description:	Get detail of DD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetDetail]	
	@D_CODE	varchar(12)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT dm.*,bn.BANK_NAME,br.BRANCH_NAME,lc.LOCATION_NAME FROM 
	(SELECT d.* FROM 
		(SELECT *,''IS_AUTH''=1 FROM DD WHERE D_CODE=@D_CODE
		UNION
		SELECT *  FROM DD_HIST WHERE D_CODE=@D_CODE
		) as d
		WHERE d.MOD_NO=(SELECT MAX(MOD_NO) FROM (
			SELECT SLNO,MOD_NO FROM DD WHERE D_CODE=@D_CODE
			UNION
			SELECT SLNO,MOD_NO FROM DD_HIST where D_CODE=@D_CODE) as m
			WHERE m.SLNO=d.SLNO)
		) as dm
	LEFT OUTER JOIN BANK as bn ON dm.DRAWER_BANKCODE=bn.BANK_CODE 
    LEFT OUTER JOIN BRANCH as br ON br.BRANCH_CODE= dm.DRAWER_BRANCHCODE
	AND br.BANK_CODE=dm.DRAWER_BANKCODE AND br.LOCATION_CODE=dm.DRAWER_LOCATION
    LEFT OUTER JOIN LOCATION as lc ON lc.LOCATION_CODE= dm.DRAWER_LOCATION
	ORDER BY dm.SLNO	

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	Get detail of location table by location code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetDetailByCode]	
	@LOCATION_CODE		varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM LOCATION 
	WHERE LOCATION_CODE=@LOCATION_CODE
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetListByBranch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CMS_Location_GetListByBranch]
	@BRANCH_CODE	varchar(4)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT l.LOCATION_CODE,l.LOCATION_NAME 
	FROM BRANCH b
	INNER JOIN LOCATION l on l.LOCATION_CODE=b.LOCATION_CODE
	WHERE b.BRANCH_CODE=@BRANCH_CODE AND l.STATUS=''L''
	ORDER BY LOCATION_NAME;
	
	   
END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-May-13
-- Description:	Get detail from DD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetDetailList]	
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN						
			SELECT DD.*,''S'' = ''U'',b.BANK_NAME AS DRAWER_BANKNAME,
				br.BRANCH_NAME AS DRAWER_BRANCHNAME,
				l.LOCATION_NAME AS DRAWER_LOCATIONNAME,nbr.BRANCH_NAME AS DRAWEE			 
				FROM DD_HIST DD
				LEFT OUTER JOIN BANK b 
				ON b.BANK_CODE=dd.DRAWER_BANKCODE
				LEFT OUTER JOIN BRANCH br 
				ON br.BANK_CODE=dd.DRAWER_BANKCODE AND br.BRANCH_CODE=dd.DRAWER_BRANCHCODE
				AND br.LOCATION_CODE=dd.DRAWER_LOCATION
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=dd.DRAWER_LOCATION
				LEFT OUTER JOIN (SELECT * FROM BRANCH WHERE NIKBRANCH_CODE IS NOT NULL 
					AND LTRIM(RTRIM(NIKBRANCH_CODE))<>'''') nbr
				ON nbr.BANK_CODE=dd.DRAWER_BANKCODE AND nbr.NIKBRANCH_CODE=dd.NIKBRANCH_CODE 
				WHERE DD.IS_AUTH=0
				ORDER BY DD.D_CODE,DD.SLNO;
		END;
	ELSE
		BEGIN
			
			SELECT DD.*,''S'' = ''A'',b.BANK_NAME AS DRAWER_BANKNAME,
				br.BRANCH_NAME AS DRAWER_BRANCHNAME,
				l.LOCATION_NAME AS DRAWER_LOCATIONNAME,nbr.BRANCH_NAME AS DRAWEE			 
				FROM DD DD
				LEFT OUTER JOIN BANK b 
				ON b.BANK_CODE=dd.DRAWER_BANKCODE
				LEFT OUTER JOIN BRANCH br 
				ON br.BANK_CODE=dd.DRAWER_BANKCODE AND br.BRANCH_CODE=dd.DRAWER_BRANCHCODE
				AND br.LOCATION_CODE=dd.DRAWER_LOCATION
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=dd.DRAWER_LOCATION
				LEFT OUTER JOIN (SELECT * FROM BRANCH WHERE NIKBRANCH_CODE IS NOT NULL 
					AND LTRIM(RTRIM(NIKBRANCH_CODE))<>'''') nbr
				ON nbr.BANK_CODE=dd.DRAWER_BANKCODE AND nbr.NIKBRANCH_CODE=dd.NIKBRANCH_CODE 
				ORDER BY DD.D_CODE,DD.SLNO;
									
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Nov-12
-- Description:	Get detail to Client_Loc_Charge table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_GetDetailList]		
	@CLIENT_CODE	varchar(6),
	@DEL_FLAG		int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT clh.*,l.LOCATION_NAME,''S'' = ''U''				 
			FROM CLIENT_LOC_CHARGE_HIST clh
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=clh.LOCATION_CODE
			WHERE clh.IS_AUTH=0 AND clh.CLIENT_CODE=@CLIENT_CODE
			UNION
			SELECT cl.*,1,l.LOCATION_NAME,''S'' = ''A''				
			FROM CLIENT_LOC_CHARGE cl
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=cl.LOCATION_CODE
			WHERE cl.STATUS =''L'' AND cl.CLIENT_CODE=@CLIENT_CODE				
			ORDER BY IS_AUTH,CLIENT_CODE

		END
	ELSE
		BEGIN	

			SELECT clh.*,l.LOCATION_NAME,''S'' = ''U''				 
			FROM CLIENT_LOC_CHARGE_HIST clh
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=clh.LOCATION_CODE
			WHERE clh.IS_AUTH=0 AND clh.CLIENT_CODE=@CLIENT_CODE
			UNION
			SELECT cl.*,1,l.LOCATION_NAME,''S'' = 
				CASE  
					WHEN cl.STATUS = ''D'' THEN ''D''                    
					ELSE ''A''
                END 
			FROM CLIENT_LOC_CHARGE cl
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=cl.LOCATION_CODE
			WHERE cl.STATUS in (''L'',''D'') AND cl.CLIENT_CODE=@CLIENT_CODE
			ORDER BY IS_AUTH,CLIENT_CODE

		END
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Get detail of branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetail]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT BRANCH_CODE 
				FROM BRANCH WHERE BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 ,BANK.BANK_NAME,LOCATION.LOCATION_NAME
			FROM BRANCH br
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=br.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=br.LOCATION_CODE			
			WHERE br.BANK_CODE=@BANK_CODE AND br.LOCATION_CODE=@LOCATION_CODE
			AND br.BRANCH_CODE=@BRANCH_CODE AND br.MOD_NO=@MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * ,BANK.BANK_NAME,LOCATION.LOCATION_NAME
			FROM BRANCH_HIST brh
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=brh.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=brh.LOCATION_CODE			
			WHERE brh.BANK_CODE=@BANK_CODE AND brh.LOCATION_CODE=@LOCATION_CODE
			AND brh.BRANCH_CODE=@BRANCH_CODE AND brh.MOD_NO=@MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	get detail of branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;



	IF @AUTH_FLAG=0
		BEGIN						
			SELECT brh.*,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,''S'' = ''U''				 
				FROM BRANCH_HIST brh
				LEFT OUTER JOIN BANK ON BANK.BANK_CODE=brh.BANK_CODE
				LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=brh.LOCATION_CODE
				LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=brh.CLEARING_ZONE
				WHERE IS_AUTH=0
				ORDER BY BANK_CODE,BRANCH_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT br.*,1,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,''S'' = ''A''				
						FROM BRANCH br
						LEFT OUTER JOIN BANK ON BANK.BANK_CODE=br.BANK_CODE
						LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=br.LOCATION_CODE
						LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=br.CLEARING_ZONE
						WHERE br.STATUS =''L''					
						ORDER BY BANK_CODE,BRANCH_CODE
				END;
			ELSE
				BEGIN
					SELECT br.*,1,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,''S'' = 
						CASE  
							WHEN br.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM BRANCH br
						LEFT OUTER JOIN BANK ON BANK.BANK_CODE=br.BANK_CODE
						LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=br.LOCATION_CODE
						LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=br.CLEARING_ZONE
						WHERE br.STATUS in (''L'',''D'')					
						ORDER BY BANK_CODE,BRANCH_CODE
				END;
		END;	

	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpReversal_GetFlexCrDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-13
-- Description:	Get detail of TMP_Reversal Credit Flex Data
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TmpReversal_GetFlexCrDetail]	
	@REV_DATE	datetime
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT a.*,b.* 
		FROM TMP_REVERSAL a
		LEFT OUTER JOIN LOCATION b 
		ON a.LOCATION_CODE=b.LOCATION_CODE 
		WHERE REV_DATE<=@REV_DATE

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetListByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	get list records of location by bank code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetListByBank]
	@BANK_CODE	varchar(4)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT distinct l.LOCATION_CODE,l.LOCATION_NAME 
	FROM BANK b
	INNER JOIN BRANCH br on br.BANK_CODE=b.BANK_CODE
	INNER JOIN LOCATION l on l.LOCATION_CODE=br.LOCATION_CODE
	WHERE b.BANK_CODE=@BANK_CODE AND l.STATUS=''L''
	ORDER BY LOCATION_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSchedule_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Jan-13
-- Description:	Get detail of CSchedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSchedule_GetDetails]	
	@CS_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT CS_CODE 
			   FROM CSCHEDULE WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT cs.*,''IS_AUTH''=1,
				l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME
			FROM CSCHEDULE cs
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=cs.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=cs.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=cs.CORR_BRANCH_CODE
			WHERE cs.CS_CODE=@CS_CODE AND cs.MOD_NO = @MOD_NO
			ORDER BY DS_CODE
		END	
	ELSE
		BEGIN
			SELECT csh.* ,
				l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME
			FROM CSCHEDULE_HIST csh
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=csh.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=csh.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=csh.CORR_BRANCH_CODE
			WHERE csh.CS_CODE=@CS_CODE AND csh.MOD_NO = @MOD_NO
			ORDER BY DS_CODE
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Nov-12
-- Description:	Get detail of client locatin charge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_GetDetail]	
	@CLIENT_CODE	varchar(6),
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT CLIENT_CODE 
				FROM CLIENT_LOC_CHARGE 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT cc.*,''IS_AUTH''=1,c.ACC_NO,c.ACC_NAME,l.LOCATION_NAME
				FROM CLIENT_LOC_CHARGE cc
				LEFT OUTER JOIN CLIENT c
				ON c.CLIENT_CODE =cc.CLIENT_CODE
				LEFT OUTER JOIN LOCATION l 
				ON l.LOCATION_CODE=cc.LOCATION_CODE
				WHERE cc.CLIENT_CODE=@CLIENT_CODE 
				AND cc.LOCATION_CODE=@LOCATION_CODE AND cc.MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT cch.*,c.ACC_NO,c.ACC_NAME,l.LOCATION_NAME 
				FROM CLIENT_LOC_CHARGE_HIST cch
				LEFT OUTER JOIN CLIENT c
				ON c.CLIENT_CODE =cch.CLIENT_CODE
				LEFT OUTER JOIN LOCATION l 
				ON l.LOCATION_CODE=cch.LOCATION_CODE
				WHERE cch.CLIENT_CODE=@CLIENT_CODE 
				AND cch.LOCATION_CODE=@LOCATION_CODE AND cch.MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Remove record from location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_Remove]	
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@LOCATION_NAME 	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT LOCATION_CODE from LOCATION 
			  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@LOCATION_NAME=LOCATION_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				LOCATION_HIST (LOCATION_CODE, LOCATION_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@LOCATION_CODE, @LOCATION_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT LOCATION_CODE from LOCATION_HIST 
					  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE LOCATION_HIST
						WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get Total # of modification of location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetMaxMod]	
	@LOCATION_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM LOCATION_HIST 
		WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	update detail to location table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Location_Update]	
	@LOCATION_CODE	varchar(4),
	@LOCATION_NAME 	varchar(35),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT LOCATION_CODE FROM LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO LOCATION_HIST(LOCATION_CODE, LOCATION_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@LOCATION_CODE, @LOCATION_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT LOCATION_CODE from LOCATION_HIST 
						WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO LOCATION_HIST(LOCATION_CODE, LOCATION_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@LOCATION_CODE, @LOCATION_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to Location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM LOCATION_HIST 
				WHERE IS_AUTH=0			
				ORDER BY IS_AUTH,LOCATION_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM LOCATION
						WHERE STATUS =''L''					
						ORDER BY LOCATION_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM LOCATION
						WHERE STATUS in (''L'',''D'')					
						ORDER BY LOCATION_CODE
				END;
		END;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Authorize record to location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_Auth]	
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@LOCATION_NAME	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT LOCATION_CODE from LOCATION_HIST 
			  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@LOCATION_NAME=LOCATION_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM LOCATION_HIST 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO LOCATION_HIST 
				SELECT *,1 FROM LOCATION
				WHERE LOCATION_CODE=@LOCATION_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE LOCATION_HIST
				SET [STATUS] = ''O'' 
				WHERE LOCATION_CODE=@LOCATION_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE LOCATION
				SET LOCATION_NAME=@LOCATION_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE LOCATION_CODE=@LOCATION_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO LOCATION
				SELECT LOCATION_CODE, LOCATION_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM LOCATION_HIST
					WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail of location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetDetail]	
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT LOCATION_CODE 
			   FROM LOCATION WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM LOCATION 
			WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM LOCATION_HIST
			WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to Location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_Add]	
	@LOCATION_CODE		varchar(4),
	@LOCATION_NAME 		varchar(35)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT LOCATION_CODE FROM LOCATION WHERE LOCATION_CODE=@LOCATION_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE LOCATION_HIST WHERE 
		LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO LOCATION_HIST(LOCATION_CODE, LOCATION_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@LOCATION_CODE, @LOCATION_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetCorrLocList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Sep-13
-- Description:	Get detail of location table for corr branch
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetCorrLocList]	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT DISTINCT a.LOCATION_CODE,a.LOCATION_NAME
	FROM LOCATION a
	INNER JOIN BRANCH b ON a.LOCATION_CODE=b.LOCATION_CODE
	WHERE a.[STATUS]=''L'' AND b.[STATUS]=''L'' AND CORRBANK=1
	ORDER BY a.LOCATION_CODE
	
	      
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Location_GetListByBankBranch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Sep-13
-- Description:	get list records of location by bank Branch COde
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetListByBankBranch]
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT distinct l.LOCATION_CODE,l.LOCATION_NAME 
	FROM BANK b
	INNER JOIN BRANCH br on br.BANK_CODE=b.BANK_CODE
	INNER JOIN LOCATION l on l.LOCATION_CODE=br.LOCATION_CODE
	WHERE b.BANK_CODE=@BANK_CODE AND br.BRANCH_CODE=@BRANCH_CODE 
	AND l.STATUS=''L''
	ORDER BY LOCATION_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Mar-13
-- Description:	Remove record from CCheckTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckTotal_Remove]	
	@D_CODE		varchar(12),
	@MOD_NO		int,
	@RET_MOD_NO	int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@TOTAL_CHKNO	numeric(4,0), 
			@TOTAL_CHKAMT	numeric(12,2), 
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from CCHECKTOTAL
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_CHKNO=TOTAL_CHKNO,@TOTAL_CHKAMT=TOTAL_CHKAMT,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CCHECKTOTAL
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CCHECKTOTAL_HIST (D_CODE,TOTAL_CHKNO,TOTAL_CHKAMT,				
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@D_CODE,	@TOTAL_CHKNO,@TOTAL_CHKAMT,			
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE CCHECK_HIST
				WHERE D_CODE=@D_CODE AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, 
				DLOCATION_CODE, CUSTOMER_REF, SLIP_DATE, VALUE_DATE, 
				CHECK_NO, AMOUNT,CHECK_DATE, CHECK_TYPE, DRAWER, 
				DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, CHECK_REF, 
				RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH, REMINDER_DATE, 
				REMINDER_NO, RTN_CODE)
				SELECT SLNO, D_CODE, CLIENT_CODE, 
				DLOCATION_CODE, CUSTOMER_REF, SLIP_DATE, VALUE_DATE, 
				CHECK_NO, AMOUNT,CHECK_DATE, CHECK_TYPE, DRAWER, 
				DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, CHECK_REF, 
				RTN_STATUS, NONZONE_REF, @RET_MOD_NO, 0, REMINDER_DATE, 
				REMINDER_NO, RTN_CODE				
				FROM CCHECK
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT D_CODE from CCHECKTOTAL_HIST 
					  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CCHECKTOTAL_HIST
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE CCHECK_HIST 
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_UpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Feb-13
-- Description:	Update return status of CCheck
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_UpdateStatus]
	@D_CODE		varchar(12),
	@SLNO		int,
	@RTN_STATUS char(1)
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@TOTAL_CHKNO	numeric(4,0),
			@TOTAL_CHKAMT	numeric(12,2),
			@MOD_NO			numeric(3,0);			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from CCHECK
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_CHKNO=TOTAL_CHKNO, @TOTAL_CHKAMT=TOTAL_CHKAMT,
				@MOD_NO=MOD_NO
				FROM CCHECKTOTAL
				WHERE D_CODE=@D_CODE;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			--SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CCHECKTOTAL_HIST (D_CODE,
				TOTAL_CHKNO,TOTAL_CHKAMT,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@D_CODE,
				@TOTAL_CHKNO,@TOTAL_CHKAMT,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(), HOST_NAME(), @MOD_NO + 1,
				''U'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE CCHECK_HIST
				WHERE D_CODE=@D_CODE AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF, 
				SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
				CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
				BRANCH_CODE, CHECK_REF, RTN_STATUS,	NONZONE_REF, MOD_NO, 
				IS_AUTH, REMINDER_DATE, REMINDER_NO, RTN_CODE, 
				[FILENAME], FILE_USER_ID, FLEXGEN_DATE)
				SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF, 
					SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
					CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
					BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF,@MOD_NO + 1,
					0,REMINDER_DATE, REMINDER_NO, RTN_CODE, 
					[FILENAME], FILE_USER_ID, FLEXGEN_DATE
				FROM CCHECK
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			UPDATE CCHECK_HIST
				SET RTN_STATUS=@RTN_STATUS
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO+1 AND SLNO=@SLNO

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
		
		ROLLBACK TRANSACTION;
		RETURN 4; -- not exist
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Authorize record to CCHECKTOTAL
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckTotal_Auth]	
	@D_CODE		varchar(12),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@TOTAL_CHKNO	numeric(4,0), 
			@TOTAL_CHKAMT	numeric(12,2), 			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from CCHECKTOTAL_HIST 
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_CHKNO=TOTAL_CHKNO, 
				@TOTAL_CHKAMT=TOTAL_CHKAMT,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CCHECKTOTAL_HIST 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CCHECKTOTAL_HIST 
				SELECT *,1 FROM CCHECKTOTAL
				WHERE D_CODE=@D_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CCHECKTOTAL_HIST
				SET [STATUS] = ''O'' 
				WHERE D_CODE=@D_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CCHECKTOTAL
				SET
				TOTAL_CHKNO=@TOTAL_CHKNO,
				TOTAL_CHKAMT=@TOTAL_CHKAMT, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE D_CODE=@D_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CCHECKTOTAL
				SELECT D_CODE,TOTAL_CHKNO, TOTAL_CHKAMT, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CCHECKTOTAL_HIST
					WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update CCHECK

	INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
		BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH,
		REMINDER_DATE, REMINDER_NO, RTN_CODE,[FILENAME],FILE_USER_ID,FLEXGEN_DATE)
		SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
		BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, 1,
		REMINDER_DATE, REMINDER_NO, RTN_CODE,[FILENAME],FILE_USER_ID,FLEXGEN_DATE
		FROM CCHECK
		WHERE D_CODE=@D_CODE;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE CCHECK WHERE D_CODE=@D_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO CCHECK(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
		BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, 
		REMINDER_DATE, REMINDER_NO, RTN_CODE,[FILENAME],FILE_USER_ID,FLEXGEN_DATE)
		SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
		BRANCH_CODE, CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, 
		REMINDER_DATE, REMINDER_NO, RTN_CODE,[FILENAME],FILE_USER_ID,FLEXGEN_DATE
		FROM CCHECK_HIST 
		WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE CCHECK_HIST WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_ReminderCitiAny]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 06-Mar-13
-- Description: Reminder Process for CitiAnywhere Check
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_ReminderCitiAny]	
AS
BEGIN	
	DECLARE 
		@ErrorVar		INT,
		@v_D_CODE		varchar(12),
		@v_SLNO			numeric(3,0),
		@maxNONZONE_REF	numeric(7,0);
		
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;


--3--------------------------------

	DECLARE tmpcursor3 CURSOR FOR
		SELECT DISTINCT ct.D_CODE FROM CCHECKTOTAL as ct INNER JOIN CCHECK as cc 
			ON ct.D_CODE=cc.D_CODE AND ct.MOD_NO=cc.MOD_NO
			WHERE cc.RTN_STATUS =''O'' AND DATEDIFF(dd,cc.REMINDER_DATE,GETDATE())>30
			AND ct.[STATUS]=''L'' AND cc.REMINDER_NO<7;

	OPEN tmpcursor3;
	FETCH NEXT FROM tmpcursor3 
        INTO @v_D_CODE;

	WHILE @@FETCH_STATUS=0 
 	BEGIN

		DELETE CCHECKTOTAL_HIST
			WHERE D_CODE=@v_D_CODE AND IS_AUTH=0;

		INSERT INTO CCHECKTOTAL_HIST
			SELECT *,1 FROM CCHECKTOTAL WHERE D_CODE=@v_D_CODE;

		UPDATE CCHECKTOTAL_HIST
			SET [STATUS]=''O''
			WHERE D_CODE=@v_D_CODE AND [STATUS]=''L'';

		UPDATE CCHECKTOTAL
			SET MOD_NO=MOD_NO+1,
				INPUT_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),	
				INPUT_DATETIME=GETDATE(),INPUT_FROM=HOST_NAME(),
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME()
			WHERE D_CODE=@v_D_CODE;
		
		DELETE CCHECK_HIST
			WHERE D_CODE=@v_D_CODE AND IS_AUTH=0;

		INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
			CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
			CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
			CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO, IS_AUTH, REMINDER_DATE, 
			REMINDER_NO, RTN_CODE)
			SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
			CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
			CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, BRANCH_CODE, 
			CHECK_REF, RTN_STATUS, NONZONE_REF, MOD_NO,1, REMINDER_DATE, 
			REMINDER_NO, RTN_CODE 
			FROM CCHECK	
			WHERE D_CODE=@v_D_CODE
		
		UPDATE CCHECK
			SET MOD_NO=MOD_NO+1 
			WHERE D_CODE=@v_D_CODE

		FETCH NEXT FROM tmpcursor3 
				INTO @v_D_CODE;

	END

	CLOSE tmpcursor3;	
	DEALLOCATE tmpcursor3;

-----4------------------------------

			
	DECLARE tmpcursor4 CURSOR FOR
		SELECT DISTINCT ct.D_CODE,cc.SLNO
			FROM CCHECKTOTAL as ct INNER JOIN CCHECK as cc 
			ON ct.D_CODE=cc.D_CODE AND ct.MOD_NO=cc.MOD_NO
			WHERE cc.RTN_STATUS =''O'' AND DATEDIFF(dd,cc.REMINDER_DATE,GETDATE())>30
			AND ct.[STATUS]=''L'' AND cc.REMINDER_NO<7 ;

	OPEN tmpcursor4;
	FETCH NEXT FROM tmpcursor4 
        INTO @v_D_CODE,@v_SLNO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		UPDATE CCHECK
			SET REMINDER_DATE=CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
			REMINDER_NO=ISNULL(REMINDER_NO,0)+1
			WHERE D_CODE=@v_D_CODE AND SLNO=@v_SLNO;
		
		FETCH NEXT FROM tmpcursor4 
        INTO @v_D_CODE,@v_SLNO;

	END

	CLOSE tmpcursor4;	
	DEALLOCATE tmpcursor4;

-----------------------------------

	SELECT @ErrorVar = @@error;			

	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	COMMIT TRANSACTION;

	
         
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_TryLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 9-May-13
-- Description:	try login
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_TryLogin]	
AS
BEGIN	
	
	DECLARE @USERS_ID		varchar(20),
			@USERS_NAME		varchar(50),
			@DEPT_SLNO		numeric(3,0) ,
			@DOMAIN			varchar(30),
			@USER_STAT		char(1),
			@v_UserId		varchar(20); 	

	DECLARE @ErrorVar INT;
			
	SET NOCOUNT ON;

	SELECT @DOMAIN=substring(suser_name(),1,charindex(''\'',suser_name())-1);

	SELECT @USERS_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20);

	IF NOT EXISTS(SELECT USERS_ID FROM USERS WHERE USERS_ID=@USERS_ID AND
		DOMAIN=@DOMAIN)
		BEGIN
			-- Not Exists
				
			RETURN 4;
		END

	DECLARE tmpcursor1 CURSOR FOR
		SELECT USERS_ID FROM USERS
			WHERE (IS_ADMIN IS NULL OR IS_ADMIN=0) 
			AND USER_STAT=''E''
			AND DATEDIFF(d,LAST_LOGIN_DATE,GETDATE())>100;

	OPEN tmpcursor1;
	FETCH NEXT FROM tmpcursor1 
        INTO @v_UserId;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
 		
 		UPDATE USERS SET USER_STAT=''D''
 			WHERE USERS_ID=@v_UserId;
 			
 		INSERT INTO SYSTEM_LOG(LOG_DATETIME, LOG_DESCRIPTION, LOG_USER)
			VALUES(GETDATE(), @v_UserId + '' is locked due to inactivity of 100 days'',
			substring(suser_name(),charindex(''\'',suser_name())+1,20));
 	
 		FETCH NEXT FROM tmpcursor1 
				INTO @v_UserId;

	END

	CLOSE tmpcursor1;	
	DEALLOCATE tmpcursor1;

	SELECT @USER_STAT=USER_STAT FROM USERS WHERE USERS_ID=@USERS_ID;
	
	IF @USER_STAT =''D''
		BEGIN
			
			RETURN 8;
		END
	ELSE

	UPDATE USERS SET LAST_LOGIN_DATE=GETDATE(),INV_ATTEMPT=0
		WHERE USERS_ID=@USERS_ID;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			
			RETURN 1;
		END
	

	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_InvalidLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 9-May-13
-- Description:	Invalid Login
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_InvalidLogin]	
AS
BEGIN	
	
	DECLARE @USERS_ID		varchar(20),
			@USERS_NAME		varchar(50),
			@DEPT_SLNO		numeric(3,0) ,
			@DOMAIN			varchar(30),
			@USER_STAT		char(1),
			@INV_ATTEMPT	numeric(1,0),
			@v_UserId		varchar(20); 	

	DECLARE @ErrorVar INT;
			
	SET NOCOUNT ON;

	SELECT @DOMAIN=substring(suser_name(),1,charindex(''\'',suser_name())-1);

	SELECT @USERS_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20);

	IF NOT EXISTS(SELECT USERS_ID FROM USERS WHERE USERS_ID=@USERS_ID AND
		DOMAIN=@DOMAIN)
		BEGIN
			-- Not Exists
				
			RETURN 4;
		END

	DECLARE tmpcursor1 CURSOR FOR
		SELECT USERS_ID FROM USERS
			WHERE (IS_ADMIN IS NULL OR IS_ADMIN=0) 
			AND USER_STAT=''E''
			AND DATEDIFF(d,LAST_LOGIN_DATE,GETDATE())>100;

	OPEN tmpcursor1;
	FETCH NEXT FROM tmpcursor1 
        INTO @v_UserId;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
 		
 		UPDATE USERS SET USER_STAT=''D'',LAST_LOGIN_DATE=NULL
 			WHERE USERS_ID=@v_UserId;
 			
 		INSERT INTO SYSTEM_LOG(LOG_DATETIME, LOG_DESCRIPTION, LOG_USER)
			VALUES(GETDATE(), @v_UserId + '' is locked due to inactivity of 100 days'',
			substring(suser_name(),charindex(''\'',suser_name())+1,20));
 	
 		FETCH NEXT FROM tmpcursor1 
				INTO @v_UserId;

	END

	CLOSE tmpcursor1;	
	DEALLOCATE tmpcursor1;

	SELECT @USER_STAT=USER_STAT,@INV_ATTEMPT=ISNULL(INV_ATTEMPT,0) 
		FROM USERS WHERE USERS_ID=@USERS_ID;
	
	IF @USER_STAT =''D''
		BEGIN
			
			RETURN 8;
		END
	ELSE
	
	IF @INV_ATTEMPT >4
		BEGIN
		
			UPDATE USERS SET USER_STAT=''D''
				WHERE USERS_ID=@USERS_ID;
			
			INSERT INTO SYSTEM_LOG(LOG_DATETIME, LOG_DESCRIPTION, LOG_USER)
				VALUES(GETDATE(), @USERS_ID + '' is locked due to multiple failed attempt'',
				substring(suser_name(),charindex(''\'',suser_name())+1,20));
			
			RETURN 8;
		END
	ELSE
	

	UPDATE USERS SET INV_ATTEMPT=ISNULL(INV_ATTEMPT,0)+1
		WHERE USERS_ID=@USERS_ID;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			
			RETURN 1;
		END
	

	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_SystemLog_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Feb-13
-- Description:	Add to system log
-- =============================================
CREATE PROCEDURE [dbo].[CMS_SystemLog_Add]		
	@LOG_DESCRIPTION 		varchar(2000)	
AS 
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO SYSTEM_LOG(LOG_DATETIME, LOG_DESCRIPTION, LOG_USER)
		VALUES(GETDATE(), @LOG_DESCRIPTION,
		substring(suser_name(),charindex(''\'',suser_name())+1,20));

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_SystemLog_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 29-Aug-13
-- Description:	Get detail of System Log
-- =============================================
CREATE PROCEDURE [dbo].[CMS_SystemLog_GetDetail]	
	@DATE_FROM	DateTime,	
	@DATE_TO	DateTime,
	@USER_NAME	varchar(20),
	@TEXT	varchar(100)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT @TEXT = ''%''+@TEXT+''%''
    
	IF  (@DATE_FROM is NULL) AND (@DATE_TO is NULL) 
		AND (@USER_NAME is NULL) AND (@TEXT is NULL)
		BEGIN
			SELECT * FROM SYSTEM_LOG ORDER BY LOG_DATETIME DESC;
		END
	ELSE IF (@DATE_FROM is NULL) AND (@DATE_TO is NULL) 
		AND (@TEXT is NULL) AND (@USER_NAME is Not NULL)
		BEGIN
			SELECT * FROM SYSTEM_LOG 
				WHERE LOG_USER = @USER_NAME ORDER BY LOG_DATETIME DESC;
		END
	Else IF  (@DATE_FROM is not NULL) AND (@DATE_TO is not NULL) AND (@TEXT is NULL) AND (@USER_NAME is not NULL) 
		BEGIN
			SELECT * FROM SYSTEM_LOG 
				WHERE LOG_DATETIME >= @DATE_FROM AND LOG_DATETIME <= @DATE_TO 
				AND LOG_USER = @USER_NAME ORDER BY LOG_DATETIME DESC;
		END
	Else IF  (@DATE_FROM is not NULL) AND (@DATE_TO is not NULL) AND (@USER_NAME is NULL)  AND (@TEXT is not NULL)
		BEGIN
			  SELECT * FROM SYSTEM_LOG WHERE LOG_DATETIME >= @DATE_FROM AND 
					   LOG_DATETIME <= @DATE_TO AND LOG_DESCRIPTION like @TEXT ORDER BY LOG_DATETIME DESC;
		END
	ELSE IF (@DATE_FROM is NULL) AND (@DATE_TO is NULL) AND (@USER_NAME is NULL) AND (@TEXT is not NULL)
		BEGIN
			  SELECT * FROM SYSTEM_LOG WHERE LOG_DESCRIPTION like @TEXT ORDER BY LOG_DATETIME DESC;
		END
	Else IF  (@DATE_FROM is  NULL) AND (@DATE_TO is  NULL) AND (@USER_NAME is not NULL) AND  (@TEXT is not NULL) 
		BEGIN
			  SELECT * FROM SYSTEM_LOG WHERE  LOG_USER = @USER_NAME AND LOG_DESCRIPTION like @TEXT ORDER BY LOG_DATETIME DESC; 
		END
	Else IF  (@DATE_FROM is not NULL) AND (@DATE_TO is not NULL) AND (@TEXT is NULL) AND (@USER_NAME is NULL)
		BEGIN
			  SELECT * FROM SYSTEM_LOG WHERE LOG_DATETIME >= @DATE_FROM AND LOG_DATETIME <= @DATE_TO ORDER BY LOG_DATETIME DESC;
		END
	ELSE   
		BEGIN
			  SELECT * FROM SYSTEM_LOG WHERE LOG_USER = @USER_NAME 
					AND LOG_DESCRIPTION like @TEXT
					AND  LOG_DATETIME >= @DATE_FROM and LOG_DATETIME <= @DATE_TO ORDER BY LOG_DATETIME DESC;
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Add detail to CCheck
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheck_Add]
	@SLNO				numeric(3,0),
	@D_CODE				varchar(12), 
	@CLIENT_CODE		varchar(6), 
	@DLOCATION_CODE		varchar(4), 
	@CUSTOMER_REF		varchar(15), 
	@SLIP_DATE			datetime, 
	@VALUE_DATE			datetime, 
	@CHECK_NO			varchar(15), 
	@AMOUNT				numeric(12,2), 
	@CHECK_DATE			datetime, 
	@CHECK_TYPE			varchar(7),
	@DRAWER				varchar(50),
	@DRAWEE_BANK_CODE	varchar(4),
	@LOCATION_CODE		varchar(4),
	@BRANCH_CODE		varchar(4),
	@CHECK_REF			varchar(14)
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, 
		LOCATION_CODE, BRANCH_CODE, CHECK_REF, RTN_STATUS,
		MOD_NO,IS_AUTH)
		VALUES(@SLNO, @D_CODE, @CLIENT_CODE, @DLOCATION_CODE, 
		@CUSTOMER_REF, @SLIP_DATE, @VALUE_DATE, @CHECK_NO, @AMOUNT, 
		@CHECK_DATE, @CHECK_TYPE, @DRAWER, @DRAWEE_BANK_CODE, 
		@LOCATION_CODE, @BRANCH_CODE, @CHECK_REF,''O'',
		1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheck_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	update detail to CCHECK
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CCheck_Update]
	@SLNO				numeric(3,0),
	@D_CODE				varchar(12), 
	@CLIENT_CODE		varchar(6), 
	@DLOCATION_CODE		varchar(4), 
	@CUSTOMER_REF		varchar(15), 
	@SLIP_DATE			datetime, 
	@VALUE_DATE			datetime, 
	@CHECK_NO			varchar(15), 
	@AMOUNT				numeric(12,2), 
	@CHECK_DATE			datetime, 
	@CHECK_TYPE			varchar(7),
	@DRAWER				varchar(50),
	@DRAWEE_BANK_CODE	varchar(4),
	@LOCATION_CODE		varchar(4),
	@BRANCH_CODE		varchar(4),
	@CHECK_REF			varchar(14),
	@MOD_NO				int,
	@RTN_STATUS			char(1), 
	@NONZONE_REF		varchar(7), 
	@REMINDER_DATE		datetime, 
	@REMINDER_NO		numeric(3,0), 
	@RTN_CODE			varchar(2),
	@FILENAME			varchar(15),
	@FILE_USER_ID		varchar(20),
	@FLEXGEN_DATE		datetime	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, 
		LOCATION_CODE, BRANCH_CODE, CHECK_REF,
		MOD_NO, IS_AUTH,RTN_STATUS, NONZONE_REF, REMINDER_DATE, 
		REMINDER_NO, RTN_CODE,[FILENAME],FILE_USER_ID,FLEXGEN_DATE)
		VALUES(@SLNO, @D_CODE, @CLIENT_CODE, @DLOCATION_CODE, 
		@CUSTOMER_REF, @SLIP_DATE, @VALUE_DATE, @CHECK_NO, @AMOUNT, 
		@CHECK_DATE, @CHECK_TYPE, @DRAWER, @DRAWEE_BANK_CODE, 
		@LOCATION_CODE, @BRANCH_CODE, @CHECK_REF,
		@MOD_NO, 0, @RTN_STATUS, @NONZONE_REF, @REMINDER_DATE, 
		@REMINDER_NO, @RTN_CODE,@FILENAME,@FILE_USER_ID,@FLEXGEN_DATE)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	update detail to branch table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Branch_Update]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@BRANCH_NAME	varchar(35),
	@ROUTING_NO		varchar(8),
	@LOCATION_CODE	varchar(4),
	@BRANCH_ADD1	varchar(35),
	@BRANCH_ADD2	varchar(35),
	@CLEARING_ZONE	varchar(4),
	@CORRBANK		bit,
	@NIKBRANCH_CODE	varchar(7),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BRANCH_CODE FROM BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO BRANCH_HIST(BANK_CODE,BRANCH_CODE,BRANCH_NAME,ROUTING_NO,
				LOCATION_CODE,BRANCH_ADD1,BRANCH_ADD2,CLEARING_ZONE, CORRBANK,
				NIKBRANCH_CODE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
				@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE,@CORRBANK,
				@NIKBRANCH_CODE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT BRANCH_CODE from BRANCH_HIST 
						WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE 
						AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE = @BRANCH_CODE 
						AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO BRANCH_HIST(BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO,
						LOCATION_CODE,BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, CORRBANK,
						NIKBRANCH_CODE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME,@ROUTING_NO,
						@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE, @CORRBANK,
						@NIKBRANCH_CODE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Remove record from branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_Remove]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BRANCH_NAME	varchar(35),
			@ROUTING_NO		varchar(8),
			@BRANCH_ADD1	varchar(35),
			@BRANCH_ADD2	varchar(35),
			@CLEARING_ZONE	varchar(4),
			@CORRBANK		bit,
			@NIKBRANCH_CODE	varchar(7),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from BRANCH 
			  WHERE BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
			  AND BRANCH_CODE = @BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME = BRANCH_NAME,
				@ROUTING_NO=ROUTING_NO,
				@BRANCH_ADD1=BRANCH_ADD1,@BRANCH_ADD2=BRANCH_ADD2,
				@CLEARING_ZONE=CLEARING_ZONE,@CORRBANK=CORRBANK,
				@NIKBRANCH_CODE=NIKBRANCH_CODE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE = @BRANCH_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE = @BRANCH_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				BRANCH_HIST (BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO,
				LOCATION_CODE,BRANCH_ADD1, BRANCH_ADD2,CLEARING_ZONE, CORRBANK,
				NIKBRANCH_CODE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
				@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE, @CORRBANK,
				@NIKBRANCH_CODE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT BRANCH_CODE from BRANCH_HIST 
					  WHERE BANK_CODE=@BANK_CODE AND 
					  BRANCH_CODE=@BRANCH_CODE 
					  AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE BRANCH_HIST
						WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
						AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Authorize record to branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_Auth]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BRANCH_NAME	varchar(35),
			@ROUTING_NO		varchar(8),
			@BRANCH_ADD1	varchar(35),
			@BRANCH_ADD2	varchar(35),
			@CLEARING_ZONE	varchar(4),
			@CORRBANK		bit,
			@NIKBRANCH_CODE	varchar(7),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 


	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from BRANCH_HIST 
			  WHERE BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
			  AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME = BRANCH_NAME,
				@ROUTING_NO=ROUTING_NO,
				@BRANCH_ADD1=BRANCH_ADD1,@BRANCH_ADD2=BRANCH_ADD2,
				@CLEARING_ZONE=CLEARING_ZONE,@CORRBANK=CORRBANK,
				@NIKBRANCH_CODE=NIKBRANCH_CODE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM BRANCH_HIST 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO BRANCH_HIST 
				SELECT *,1 FROM BRANCH
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND LOCATION_CODE=@LOCATION_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE BRANCH_HIST
				SET [STATUS] = ''O'' 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND LOCATION_CODE=@LOCATION_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE BRANCH
				SET BRANCH_NAME = @BRANCH_NAME,ROUTING_NO=@ROUTING_NO,
				BRANCH_ADD1=@BRANCH_ADD1,BRANCH_ADD2=@BRANCH_ADD2,
				CLEARING_ZONE=@CLEARING_ZONE,CORRBANK=@CORRBANK,
				NIKBRANCH_CODE=@NIKBRANCH_CODE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND LOCATION_CODE=@LOCATION_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO BRANCH	 
				SELECT BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO, LOCATION_CODE, 
					BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, CORRBANK, NIKBRANCH_CODE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM BRANCH_HIST
					WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
					AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE BRANCH_HIST 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Add detail to branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_Add]
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@BRANCH_NAME	varchar(35),
	@ROUTING_NO		varchar(8),
	@LOCATION_CODE	varchar(4),
	@BRANCH_ADD1	varchar(35),
	@BRANCH_ADD2	varchar(35),
	@CLEARING_ZONE	varchar(4),
	@CORRBANK		bit,
	@NIKBRANCH_CODE	varchar(7)
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BRANCH_CODE from BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
				AND BRANCH_CODE=@BRANCH_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE BRANCH_HIST WHERE 
		BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE AND LOCATION_CODE=@LOCATION_CODE
		AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO BRANCH_HIST(BANK_CODE, BRANCH_CODE, BRANCH_NAME, ROUTING_NO,
		LOCATION_CODE,BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, CORRBANK,
		NIKBRANCH_CODE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
		@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE, @CORRBANK,
		@NIKBRANCH_CODE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 02-Jan-13
-- Description:	Add detail to Deposit Schedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_Add]
	@DS_CODE			varchar(12),
	@D_CODE				varchar(12), 
	@DEPOSIT_TYPE		varchar(5), 
	@CITICASH_AMOUNT	numeric(12,2), 
	@CITICHECK_AMOUNT	numeric(12,2), 
	@SCHEDULE_DATE		datetime, 
	@NO_CHECK			numeric(4,0), 
	@CLIENT_CODE		varchar(6), 
	@LOCATION_CODE		varchar(4), 
	@CORR_BANK_CODE		varchar(4), 
	@CORR_BRANCH_CODE	varchar(4),
	@SLNO				numeric(4,0),
	@IS_ROW_CHG			bit
AS
BEGIN	
	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO DSCHEDULE_HIST(DS_CODE, D_CODE, DEPOSIT_TYPE, 
		CITICASH_AMOUNT, CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, 
		CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
		MOD_NO,IS_AUTH,
		SLNO,IS_ROW_CHG)
		VALUES(@DS_CODE, @D_CODE, @DEPOSIT_TYPE, 
		@CITICASH_AMOUNT, @CITICHECK_AMOUNT, @SCHEDULE_DATE, @NO_CHECK, 
		@CLIENT_CODE, @LOCATION_CODE, @CORR_BANK_CODE, @CORR_BRANCH_CODE,
		1,0,
		@SLNO,@IS_ROW_CHG);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DSchedule_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Jan-13
-- Description:	update detail to DSchedule
-- =============================================

CREATE PROCEDURE [dbo].[CMS_DSchedule_Update]
	@DS_CODE			varchar(12),
	@D_CODE				varchar(12), 
	@DEPOSIT_TYPE		varchar(5), 
	@CITICASH_AMOUNT	numeric(12,2), 
	@CITICHECK_AMOUNT	numeric(12,2), 
	@SCHEDULE_DATE		datetime, 
	@NO_CHECK			numeric(4,0), 
	@CLIENT_CODE		varchar(6), 
	@LOCATION_CODE		varchar(4), 
	@CORR_BANK_CODE		varchar(4), 
	@CORR_BRANCH_CODE	varchar(4),
	@MOD_NO				int	,
	@FILENAME			varchar(15), 
	@REF_NO				varchar(10), 
	@FILE_USER_ID		varchar(20), 
	@SEQ_NO				numeric(4,0), 
	@CHECKED			tinyint,
	@FLEXGEN_DATE		datetime,
	@SLNO				numeric(4,0),
	@IS_ROW_CHG			bit
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO DSCHEDULE_HIST(DS_CODE, D_CODE, DEPOSIT_TYPE, 
		CITICASH_AMOUNT, CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, 
		CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE,
		MOD_NO, IS_AUTH,[FILENAME], REF_NO, FILE_USER_ID, SEQ_NO, 
		CHECKED, FLEXGEN_DATE,
		SLNO,IS_ROW_CHG)
		VALUES(@DS_CODE, @D_CODE, @DEPOSIT_TYPE, 
		@CITICASH_AMOUNT, @CITICHECK_AMOUNT, @SCHEDULE_DATE, @NO_CHECK, 
		@CLIENT_CODE, @LOCATION_CODE, @CORR_BANK_CODE, @CORR_BRANCH_CODE,
		@MOD_NO, 0,@FILENAME, @REF_NO, @FILE_USER_ID, @SEQ_NO, 
		@CHECKED, @FLEXGEN_DATE,
		@SLNO,@IS_ROW_CHG)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpFormList_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CMS_TmpFormList_GetDetail]	
AS
BEGIN	
	SELECT * FROM TMP_FORM_LIST ORDER BY ID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_GetEERSDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 01-Aug-13
-- Description:	Get Users detail for EERS
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_GetEERSDetail]	
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT u.USERS_ID,u.USERS_NAME, u.DOMAIN, u.USER_STAT,
	fg.FG_ID,fg.FG_NAME
	FROM USERS u
	LEFT OUTER JOIN USERS_FG_DET ufg 
	ON ufg.USERS_ID=u.USERS_ID
	LEFT OUTER JOIN F_GROUP fg 
	ON fg.SLNO=ufg.FG_SLNO
	WHERE u.STATUS=''L'' AND FG_ID IS NOT NULL
	ORDER BY USERS_ID

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	update detail to F_Group table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_FGroup_Update]	
	@SLNO			numeric(6,0),
	@FG_ID			varchar(70),
	@FG_NAME 		varchar(256),
	@DEPT_SLNO		numeric(3,0),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT FG_ID FROM F_GROUP 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE F_GROUP_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO F_GROUP_HIST(SLNO,FG_ID, FG_NAME,DEPT_SLNO,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@SLNO,@FG_ID, @FG_NAME,@DEPT_SLNO,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE PERM_FORMS_HIST
				WHERE FG_SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END

			DELETE PERM_MENUS_HIST
				WHERE FG_SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT FG_ID from F_GROUP_HIST 
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE F_GROUP_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO F_GROUP_HIST(SLNO,FG_ID,FG_NAME,DEPT_SLNO,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@SLNO,@FG_ID, @FG_NAME,@DEPT_SLNO,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE PERM_FORMS_HIST
						WHERE FG_SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END

					DELETE PERM_MENUS_HIST
						WHERE FG_SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END
							
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermForms_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get details of Perm_Forms table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PermForms_GetDetails]	
	@FG_SLNO	numeric(6,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT FG_ID 
			   FROM F_GROUP WHERE SLNO=@FG_SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT * FROM
			(SELECT SLNO F_SLNO,FORMS_NAME FROM FORM_LIST WHERE STATUS=''L'') fl
			left outer join 
			(SELECT F_GROUP.*,''IS_AUTH''=1,pf.FORM_SLNO,pf.IS_SHOW,pf.IS_NEW,
			pf.IS_UNLOCK,pf.IS_AUTHORIZER,pf.IS_DELETE,pf.IS_SAVE FROM F_GROUP
			LEFT OUTER JOIN PERM_FORMS pf
			ON FG_SLNO=SLNO AND F_GROUP.MOD_NO=pf.MOD_NO
			WHERE SLNO=@FG_SLNO AND F_GROUP.MOD_NO=@MOD_NO) g
			on fl.F_SLNO=g.FORM_SLNO


		END	
	ELSE
		BEGIN
			SELECT * FROM
			(SELECT SLNO F_SLNO,FORMS_NAME FROM FORM_LIST WHERE STATUS=''L'') fl
			left outer join 
			(SELECT F_GROUP_HIST.*,pfh.FORM_SLNO,pfh.IS_SHOW,pfh.IS_NEW,
			pfh.IS_UNLOCK,pfh.IS_AUTHORIZER,pfh.IS_DELETE,pfh.IS_SAVE FROM F_GROUP_HIST
			LEFT OUTER JOIN PERM_FORMS_HIST pfh
			ON FG_SLNO=SLNO AND F_GROUP_HIST.MOD_NO=pfh.MOD_NO
			WHERE F_GROUP_HIST.SLNO=@FG_SLNO AND F_GROUP_HIST.MOD_NO=@MOD_NO) g
			on fl.F_SLNO=g.FORM_SLNO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get detail of F_Group table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_GetDetail]	
	@SLNO		numeric(6,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT FG_ID 
			   FROM F_GROUP WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM F_GROUP 
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM F_GROUP_HIST
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get Total # of modification of F_Group table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_GetMaxMod]	
	@SLNO		numeric(6,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM F_GROUP_HIST 
		WHERE SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM F_GROUP
				WHERE SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get detail of Department  table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN						
			SELECT gh.*,d.DEPT_NAME,''S'' = ''U''				 
				FROM F_GROUP_HIST gh
				LEFT OUTER JOIN DEPARTMENT d
				ON gh.DEPT_SLNO=d.SLNO   
				WHERE IS_AUTH=0
				ORDER BY FG_ID;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,d.DEPT_NAME,''S'' = ''A''				
						FROM F_GROUP g
						LEFT OUTER JOIN DEPARTMENT d
						ON g.DEPT_SLNO=d.SLNO
						WHERE g.STATUS =''L''					
						ORDER BY FG_ID;
				END;
			ELSE
				BEGIN
					SELECT *,1,d.DEPT_NAME,''S'' = 
						CASE  
							WHEN g.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM F_GROUP g
						LEFT OUTER JOIN DEPARTMENT d
						ON g.DEPT_SLNO=d.SLNO
						WHERE g.STATUS IN (''L'',''D'')					
						ORDER BY FG_ID;
				END;
		END;	

	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Authorize record to F_Group table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_Auth]	
	@SLNO			numeric(3,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@FG_ID			varchar(50),
			@FG_NAME		varchar(50),
			@DEPT_SLNO		numeric(3,0),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT FG_ID from F_GROUP_HIST 
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@FG_ID=FG_ID,@FG_NAME=FG_NAME,
				@DEPT_SLNO=DEPT_SLNO,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM F_GROUP_HIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO F_GROUP_HIST 
				SELECT *,1 FROM F_GROUP
				WHERE SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE F_GROUP_HIST
				SET [STATUS] = ''O'' 
				WHERE SLNO=@SLNO
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE F_GROUP
				SET FG_ID=@FG_ID,FG_NAME=@FG_NAME,DEPT_SLNO=@DEPT_SLNO,		
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE F_GROUP_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO F_GROUP
				SELECT SLNO,FG_ID,FG_NAME,DEPT_SLNO,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM F_GROUP_HIST
					WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE F_GROUP_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update PERM_FORMS and PERM_MENUS

	INSERT INTO PERM_FORMS_HIST
		SELECT *,1
		FROM PERM_FORMS
		WHERE FG_SLNO=@SLNO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE PERM_FORMS WHERE FG_SLNO=@SLNO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO PERM_FORMS
		SELECT FG_SLNO, FORM_SLNO, IS_SHOW, 
		IS_NEW, IS_UNLOCK, IS_AUTHORIZER, 
		IS_DELETE, IS_SAVE, MOD_NO
		FROM PERM_FORMS_HIST 
		WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE PERM_FORMS_HIST WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	
	INSERT INTO PERM_MENUS_HIST
		SELECT *,1
		FROM PERM_MENUS
		WHERE FG_SLNO=@SLNO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	DELETE PERM_MENUS WHERE FG_SLNO=@SLNO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	INSERT INTO PERM_MENUS
		SELECT FG_SLNO, MENU_SLNO, 
		IS_VISIBLE, IS_ENABLE, MOD_NO
		FROM PERM_MENUS_HIST 
		WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE PERM_MENUS_HIST WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Nov-12
-- Description:	Add detail to F_Group
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_Add]	
	@FG_ID		varchar(70),
	@FG_NAME 	varchar(256),
	@DEPT_SLNO	numeric(3,0),
	@RET_SLNO	numeric(3,0) output	
AS
BEGIN	
	DECLARE @ErrorVar	int,
			@MaxS1		int,
			@MaxS2		int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT FG_ID FROM F_GROUP WHERE FG_ID=@FG_ID
				AND DEPT_SLNO=@DEPT_SLNO)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE F_GROUP_HIST WHERE 
		FG_ID=@FG_ID AND DEPT_SLNO=@DEPT_SLNO AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	SELECT @MaxS1=ISNULL(MAX(SLNO),0) FROM F_GROUP;
	SELECT @MaxS2=ISNULL(MAX(SLNO),0) FROM F_GROUP_HIST;

	IF @MaxS1>@MaxS2
		BEGIN
			SELECT @RET_SLNO = @MaxS1 + 1;
		END
	ELSE
		BEGIN
			SELECT @RET_SLNO = @MaxS2 + 1;
		END
		

	INSERT INTO F_GROUP_HIST(SLNO,FG_ID,FG_NAME,DEPT_SLNO,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@RET_SLNO,@FG_ID,@FG_NAME,@DEPT_SLNO,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Remove record from F_Group
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_Remove]	
	@SLNO			numeric(6,0),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@FG_ID			varchar(50),
			@FG_NAME 		varchar(50),
			@DEPT_SLNO		numeric(3,0),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT FG_ID from F_GROUP
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@FG_ID=FG_ID,@FG_NAME=FG_NAME,				
				@DEPT_SLNO=DEPT_SLNO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM F_GROUP 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE F_GROUP_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				F_GROUP_HIST (SLNO,FG_ID,FG_NAME,DEPT_SLNO,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@SLNO,@FG_ID,@FG_NAME,@DEPT_SLNO, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE PERM_FORMS_HIST 
				WHERE FG_SLNO=@SLNO AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO PERM_FORMS_HIST
				SELECT FG_SLNO, FORM_SLNO, IS_SHOW, 
				IS_NEW, IS_UNLOCK, IS_AUTHORIZER, 
				IS_DELETE, IS_SAVE, @RET_MOD_NO,0
				FROM PERM_FORMS
				WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE PERM_MENUS_HIST 
				WHERE FG_SLNO=@SLNO AND IS_AUTH=0;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			INSERT INTO PERM_MENUS_HIST
				SELECT FG_SLNO, MENU_SLNO, 
				IS_VISIBLE, IS_ENABLE, @RET_MOD_NO, 0
				FROM PERM_MENUS 
				WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
				

-----------
			


			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT FG_ID from F_GROUP_HIST 
					  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE F_GROUP_HIST
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE PERM_FORMS_HIST 
						WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					DELETE PERM_MENUS_HIST 
						WHERE FG_SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_GetAvailFG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get available FG of a user
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_GetAvailFG]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @DEPT_SLNO	numeric(3,0);
	
	SET NOCOUNT ON;

	SELECT @DEPT_SLNO=DEPT_SLNO 
		FROM USERS
		WHERE USERS_ID = @USERS_ID;

	IF EXISTS( SELECT FG_SLNO
			   FROM USERS_FG_DET WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT fg.SLNO,fg.FG_ID
				FROM F_GROUP fg
				WHERE fg.STATUS=''L''
				AND fg.DEPT_SLNO=@DEPT_SLNO 
				AND SLNO NOT IN (SELECT FG_SLNO FROM USERS_FG_DET
									WHERE USERS_ID=@USERS_ID
									AND MOD_NO=@MOD_NO);
		END
	ELSE
		BEGIN

			SELECT fg.SLNO,fg.FG_ID
				FROM F_GROUP fg
				WHERE fg.STATUS=''L''
				AND fg.DEPT_SLNO=@DEPT_SLNO  
				AND SLNO NOT IN (SELECT FG_SLNO FROM USERS_FG_DET_HIST
									WHERE USERS_ID=@USERS_ID
									AND MOD_NO=@MOD_NO);
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FGroup_GetListByDeptCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	get list records of F_Group table
--				by dept_slno
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_GetListByDeptCode]	
	@DEPT_SLNO	numeric(3,0)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT * FROM F_GROUP 
		WHERE DEPT_SLNO = @DEPT_SLNO
		AND STATUS=''L''		
		ORDER BY FG_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_GetSelFG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get Selected FG of a user
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_GetSelFG]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;
	IF EXISTS( SELECT FG_SLNO
			   FROM USERS_FG_DET WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT fg.SLNO,fg.FG_ID
				FROM F_GROUP fg
				WHERE SLNO IN (SELECT FG_SLNO FROM USERS_FG_DET
									WHERE USERS_ID=@USERS_ID
									AND MOD_NO=@MOD_NO);
		END
	ELSE
		BEGIN

			SELECT fg.SLNO,fg.FG_ID
				FROM F_GROUP fg
				WHERE SLNO IN (SELECT FG_SLNO FROM USERS_FG_DET_HIST
									WHERE USERS_ID=@USERS_ID
									AND MOD_NO=@MOD_NO);
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	get list records of zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT ZONE_CODE,ZONE_NAME FROM ZONE WHERE STATUS=''L''
	ORDER BY ZONE_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_GetDetailByBankBranchLoc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	get detail of zone by bank branch location code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetDetailByBankBranchLoc]
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@LOCATION_CODE	varchar(4)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT z.*
	FROM BRANCH as br	
	INNER JOIN ZONE as z ON z.ZONE_CODE=br.CLEARING_ZONE
	WHERE br.BANK_CODE=@BANK_CODE AND br.BRANCH_CODE=@BRANCH_CODE 
	AND br.LOCATION_CODE=@LOCATION_CODE AND z.STATUS=''L'';	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	update detail to zone table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Zone_Update]	
	@ZONE_CODE	varchar(4),
	@ZONE_NAME 	varchar(35),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT ZONE_CODE FROM ZONE 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO ZONE_HIST(ZONE_CODE, ZONE_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@ZONE_CODE, @ZONE_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT ZONE_CODE from ZONE_HIST 
						WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO ZONE_HIST(ZONE_CODE, ZONE_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@ZONE_CODE, @ZONE_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Authorize record to zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_Auth]	
	@ZONE_CODE	varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@ZONE_NAME	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ZONE_CODE from ZONE_HIST 
			  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ZONE_NAME=ZONE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM ZONE_HIST 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO ZONE_HIST 
				SELECT *,1 FROM ZONE
				WHERE ZONE_CODE=@ZONE_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE ZONE_HIST
				SET [STATUS] = ''O'' 
				WHERE ZONE_CODE=@ZONE_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE ZONE
				SET ZONE_NAME=@ZONE_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE ZONE_CODE=@ZONE_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO ZONE
				SELECT ZONE_CODE, ZONE_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM ZONE_HIST
					WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to Zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_Add]	
	@ZONE_CODE		varchar(4),
	@ZONE_NAME 		varchar(35)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT ZONE_CODE FROM ZONE WHERE ZONE_CODE=@ZONE_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE ZONE_HIST WHERE 
		ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO ZONE_HIST(ZONE_CODE, ZONE_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@ZONE_CODE, @ZONE_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail to zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM ZONE_HIST 
				WHERE IS_AUTH=0			
				ORDER BY ZONE_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM ZONE
						WHERE [STATUS] =''L''					
						ORDER BY ZONE_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM ZONE
						WHERE [STATUS] in (''L'',''D'')					
						ORDER BY ZONE_CODE
				END;
		END;
	   
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Remove record from zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_Remove]	
	@ZONE_CODE	varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@ZONE_NAME 	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ZONE_CODE from ZONE 
			  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ZONE_NAME=ZONE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM ZONE 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				ZONE_HIST (ZONE_CODE, ZONE_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@ZONE_CODE, @ZONE_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT ZONE_CODE from ZONE_HIST 
					  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE ZONE_HIST
						WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail of zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetDetail]	
	@ZONE_CODE	varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT ZONE_CODE 
			   FROM ZONE WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM ZONE 
			WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM ZONE_HIST
			WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Zone_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get Total # of modification of zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetMaxMod]	
	@ZONE_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM ZONE_HIST 
		WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM ZONE 
				WHERE ZONE_CODE=@ZONE_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpMenuList_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[CMS_TmpMenuList_GetDetail]	
AS
BEGIN	
	SELECT * FROM TMP_MENU_LIST ORDER BY ID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckUpdateByNCollection]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 10-Mar-13
-- Description:	Update Status Of Ncollection Ccheck table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckUpdateByNCollection]		
	@NONZONE_REF 	varchar(7),
	@MOD_NO			int,
	@RTN_STATUS		char(1),
	@RTN_CODE		varchar(2)
AS
BEGIN	
	DECLARE @ErrorVar	int;

	SET NOCOUNT ON;

	INSERT INTO NCOLLECTION_CCHECK_HIST(NONZONE_REF, MOD_NO, RTN_STATUS, 
		RTN_CODE, IS_AUTH)
		VALUES(@NONZONE_REF, @MOD_NO, @RTN_STATUS, @RTN_CODE, 0);
    

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermForms_GetDetailsAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CMS_PermForms_GetDetailsAll]
AS
BEGIN	
	SELECT * FROM PERM_FORMS
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Mar-12
-- Description:	Get detail to CCash table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCash_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM CCASH_HIST 
				WHERE IS_AUTH=0
				ORDER BY D_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CCASH
						WHERE [STATUS] =''L''				
	
						ORDER BY D_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''            
        
							ELSE ''A''
						END 
						FROM CCASH
						WHERE [STATUS] IN (''L'',''D'')			
		
						ORDER BY D_CODE;
				END;
		END;	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	Add detail to CCash
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCash_Add]	
	@D_CODE			varchar(12),
	@CUSTOMER_REF 	varchar(15),
	@CASH_REF 		varchar(15),
	@SLIP_DATE 		datetime
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE FROM CCASH WHERE D_CODE=@D_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CCASH_HIST WHERE 
		D_CODE=@D_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CCASH_HIST(D_CODE, CUSTOMER_REF, CASH_REF, SLIP_DATE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@D_CODE, @CUSTOMER_REF, @CASH_REF, @SLIP_DATE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	Get Total # of modification of CCash table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCash_GetMaxMod]	
	@D_CODE		varchar(12)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CCASH_HIST 
		WHERE D_CODE=@D_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CCASH
				WHERE D_CODE=@D_CODE;
			
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	update detail to CCash table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CCash_Update]	
	@D_CODE			varchar(12),
	@CUSTOMER_REF 	varchar(15),
	@CASH_REF 		varchar(15),
	@SLIP_DATE 		datetime,
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE FROM CCASH 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CCASH_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CCASH_HIST(D_CODE, CUSTOMER_REF,
				CASH_REF,SLIP_DATE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@D_CODE, @CUSTOMER_REF,
				@CASH_REF,@SLIP_DATE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT D_CODE from CCASH_HIST 
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CCASH_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CCASH_HIST(D_CODE, CUSTOMER_REF,
						CASH_REF,SLIP_DATE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@D_CODE, @CUSTOMER_REF,
						@CASH_REF,@SLIP_DATE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	Remove record from CCash table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCash_Remove]	
	@D_CODE			varchar(12),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@CUSTOMER_REF 	varchar(15),
			@CASH_REF 		varchar(15),
			@SLIP_DATE 		datetime,
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
		
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from CCASH 
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CUSTOMER_REF=CUSTOMER_REF,
				@CASH_REF=CASH_REF,@SLIP_DATE=SLIP_DATE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CCASH 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CCASH_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CCASH_HIST (D_CODE, CUSTOMER_REF,
				CASH_REF,SLIP_DATE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@D_CODE, @CUSTOMER_REF, 
				@CASH_REF,@SLIP_DATE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT D_CODE from CCASH_HIST 
					  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CCASH_HIST
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCash_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Jan-13
-- Description:	Get detail of CCash table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCash_GetDetail]	
	@D_CODE		varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM CCASH WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CCASH 
			WHERE D_CODE=@D_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CCASH_HIST
			WHERE D_CODE=@D_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermMenus_GetDetailsAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[CMS_PermMenus_GetDetailsAll]	
AS
BEGIN	
	SELECT * FROM PERM_MENUS 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Apr-13
-- Description:	Add detail to CheckTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_Add]		
	@DS_CODE		varchar(8), 
	@TOTAL_CHKNO	int, 
	@TOTAL_CHKAMT	numeric(14,2), 
	@OPR_DATE		datetime, 
	@CUSTOMER_REF	varchar(50), 
	@ENTRY_LOC		varchar(3),
	@RET_MID		numeric(10,0) output
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;

	
	IF EXISTS(SELECT DS_CODE FROM CHECKTOTAL
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE CHECKTOTAL_HIST WHERE 
		DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
		AND ENTRY_LOC=@ENTRY_LOC AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	SELECT @RET_MID=ISNULL(CLEAR_MAX_MID,0)+1 FROM GENPRM;

	UPDATE GENPRM SET CLEAR_MAX_MID=@RET_MID;
	
	INSERT INTO CHECKTOTAL_HIST(MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
		OPR_DATE, CUSTOMER_REF, ENTRY_LOC,
		ENTRY_DATE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@RET_MID,@DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, 
		@OPR_DATE, @CUSTOMER_REF, @ENTRY_LOC, 
		CONVERT(datetime,CONVERT(varchar(12), GETDATE())),
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE CLEARINGTAB_HIST WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
		AND ENTRY_LOC=@ENTRY_LOC AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_GenPrm_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Jul-12
-- Description:	Get detail of GENPRM table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_GenPrm_GetDetail]	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM GENPRM;
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Add detail to PDCTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_Add]		
	@DS_CODE		varchar(8), 
	@TOTAL_CHKNO	int, 
	@TOTAL_CHKAMT	numeric(14,2), 
	@OPR_DATE		datetime, 
	@CUSTOMER_REF	varchar(50), 
	@ENTRY_LOC		varchar(3),
	@RET_MID		numeric(10,0) output
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT DS_CODE FROM PDCTOTAL
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE PDCTOTAL_HIST WHERE 
		DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
		AND ENTRY_LOC=@ENTRY_LOC AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	SELECT @RET_MID=ISNULL(CLEAR_MAX_MID,0)+1 FROM GENPRM;

	UPDATE GENPRM SET CLEAR_MAX_MID=@RET_MID;
	
	INSERT INTO PDCTOTAL_HIST(MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
		OPR_DATE, CUSTOMER_REF, ENTRY_LOC,
		ENTRY_DATE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@RET_MID,@DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, 
		@OPR_DATE, @CUSTOMER_REF, @ENTRY_LOC,
		CONVERT(datetime,CONVERT(varchar(12), GETDATE())), 
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE PDCTAB_HIST WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
		AND ENTRY_LOC=@ENTRY_LOC AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_GenPrm_SetClearDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Aug-13
-- Description:	Get detail of GENPRM table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_GenPrm_SetClearDate]	
	@OPR_DATE	datetime
AS
BEGIN	

	UPDATE	GENPRM SET OPR_DATE=@OPR_DATE;
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_RevBatch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_RevBatch]	
	@BATCH_NO	VARCHAR(4) output	
AS
BEGIN	
	DECLARE @ErrorVar INT;
			
	SET NOCOUNT ON;
		
	SELECT @BATCH_NO = ISNULL(MAX(BATCH_NO),''5600'')+1		
		FROM GENPRM
		WHERE DATEDIFF(d,GETDATE(),BATCH_DATE)=0;
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_ReversalUpdateRef]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for reversal update reference
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_ReversalUpdateRef]
	@FILENAME		varchar(15),	      
	@REV_DATE		datetime ,	      
	@BATCH_NO		varchar(10) 
AS
BEGIN	
	DECLARE @ErrorVar		INT;			 
	
	SET NOCOUNT ON;

	UPDATE GENPRM
		SET BATCH_NO=@BATCH_NO, BATCH_DATE=GETDATE(); 

	UPDATE CCMSREF_TAB 
		SET [Filename]=@FILENAME,FLEXGEN_DATE=GETDATE() 
		WHERE [FILENAME] IS NULL AND REV_DATE<=@REV_DATE 
		AND (STATUS_ID=1 ) AND (AUTHORIZE=1);
    
	DELETE FROM CCMSREF_TAB_HIST;

	INSERT INTO CCMSREF_TAB_HIST 
		SELECT * FROM CCMSREF_TAB 
		WHERE [FILENAME] IS NOT NULL ;

	DELETE FROM CCMSREF_TAB
		WHERE [FILENAME] IS NOT NULL;

	UPDATE TMP_REVERSAL
		SET [FILENAME]=@FILENAME,FLEXGEN_DATE=@REV_DATE 
		WHERE [FILENAME] IS NULL AND REV_DATE<=@REV_DATE;

	INSERT INTO REVERSAL_HIST
		SELECT * FROM TMP_REVERSAL;

	DELETE FROM TMP_REVERSAL;

	RETURN 0;
	
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermMenus_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Nov-12
-- Description:	Add detail to Perm_Menus
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PermMenus_Add]	
	@FG_SLNO		numeric(6,0),
	@MENU_SLNO		numeric(6,0),
	@IS_VISIBLE		bit,
	@IS_ENABLE		bit
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
			
	DELETE PERM_MENUS_HIST WHERE 
		FG_SLNO=@FG_SLNO AND MENU_SLNO=@MENU_SLNO AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO PERM_MENUS_HIST(FG_SLNO, MENU_SLNO, IS_VISIBLE, 
		IS_ENABLE, MOD_NO, IS_AUTH)
		VALUES(@FG_SLNO, @MENU_SLNO, @IS_VISIBLE, 
		@IS_ENABLE, 1, 0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermMenus_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	update detail to Perm_Menus table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_PermMenus_Update]	
	@FG_SLNO		numeric(6,0),
	@MENU_SLNO		numeric(6,0),
	@IS_VISIBLE		bit,
	@IS_ENABLE		bit,	
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO PERM_MENUS_HIST(FG_SLNO, MENU_SLNO, IS_VISIBLE, 
		IS_ENABLE, MOD_NO, IS_AUTH)
		VALUES(@FG_SLNO, @MENU_SLNO, @IS_VISIBLE, 
		@IS_ENABLE, @MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_BookingCheckUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_BookingCheckUpdate]	
AS
BEGIN	
	DECLARE @ErrorVar		INT,
			@vCcode Char(6),     
			@vrefno varchar(10),    
			@vdays varchar(2),    
			@vcnt numeric,    
			@DCODE VARCHAR(12),    
			@VREVDATE DATETIME  ,      
			@REFACCNO varchar(15),    
			@deptype  varchar(15)  
	
	SET NOCOUNT ON;
                    
	DECLARE GLTCURSOR CURSOR FOR
        SELECT REF_NO,REV_DATE,SUNACC_NO,DEP_TYP 
			FROM TMP_CR_BOOKING;    
		
	OPEN GLTCURSOR;
    
	FETCH NEXT FROM GLTCURSOR 
		INTO  @vrefno,@VREVDATE,@REFACCNO, @deptype;    
    
	WHILE @@FETCH_STATUS=0        
    BEGIN
		UPDATE TMP_BOOKING SET REF_NO=@VREFNO, REFACC_NO=@REFACCNO WHERE REV_DATE=@VREVDATE    
			and DEP_TYP= @deptype    
		
		FETCH NEXT FROM GLTCURSOR INTO    
			@VREFNO,@VREVDATE,@REFACCNO,@deptype
	END 

	CLOSE GLTCURSOR    
    
	DEALLOCATE GLTCURSOR          
    	

	IF @@ERROR<>0 GOTO ErrorHandler          
          

	RETURN 0;           
                     
    ErrorHandler:          
	PRINT ''Record Does not Inserted/Updated:'';          

	RETURN 1;       
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_Holiday]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Feb-13
-- Description: Process for holiday
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_Holiday]		
AS
BEGIN	
	DECLARE @ErrorVar INT,
			@vcnt1 	int,
			@vcnt2 	int,
			@vcnt3 	int,
			@vFdt 	datetime,
			@vDelDt	datetime,
			@vDcode	varchar(12);
	
	SET NOCOUNT ON;
--1

	DECLARE GLTCURSOR CURSOR FOR
		SELECT D_CODE,VALUE_DATE,CONVERT(numeric(2),days) as DAYS,
		DATEADD(DAY,CONVERT(numeric(2),DAYS),VALUE_DATE) as DELIVERY
        FROM TMP_BOOKING;

	OPEN GLTCURSOR;
	FETCH NEXT FROM GLTCURSOR 
        INTO @VDcode,@vFdt,@vCnt2,@vDelDt;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		SET @vcnt1=1;
		
		WHILE @vcnt1<=@vcnt2
		BEGIN                    
			SET @vFdt=(SELECT DATEADD(DAY,1,@vFdt));
			SET @vcnt3=0;
			SET @vcnt3=(SELECT COUNT(1) AS cnt FROM HOLIDAY WHERE HOLI_DAY=@vFdt
				AND [STATUS]=''L''
				);
	                     
			IF @vcnt3>0     
			BEGIN
				SET @vDelDt=(SELECT DATEADD(DAY,1,@vDelDt));
				SET @vcnt2=@vcnt2+1;
			END
			
			SET @vcnt1=@vcnt1+1;
		END
		--print @vDelDt
		
		UPDATE TMP_BOOKING set REV_DATE = @vDelDt where D_CODE=@VDcode           

		FETCH NEXT FROM GLTCURSOR 
		INTO @VDcode,@vFdt,@vCnt2,@vDelDt
	END
	
	CLOSE GLTCURSOR;
	DEALLOCATE GLTCURSOR;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END

	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to returnreject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_Add]	
	@REJECT_CODE		varchar(4),
	@REJECT_REASON 		varchar(100)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT REJECT_CODE FROM RETURN_REJECT WHERE REJECT_CODE=@REJECT_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE RETURN_REJECT_HIST WHERE 
		REJECT_CODE=@REJECT_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO RETURN_REJECT_HIST(REJECT_CODE, REJECT_REASON,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@REJECT_CODE, @REJECT_REASON,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Authorize record to return_reject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_Auth]	
	@REJECT_CODE	varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@REJECT_REASON	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT REJECT_CODE from RETURN_REJECT_HIST 
			  WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@REJECT_REASON=REJECT_REASON,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM RETURN_REJECT_HIST 
				WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO RETURN_REJECT_HIST 
				SELECT *,1 FROM RETURN_REJECT
				WHERE REJECT_CODE=@REJECT_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE RETURN_REJECT_HIST
				SET [STATUS] = ''O'' 
				WHERE REJECT_CODE=@REJECT_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE RETURN_REJECT
				SET REJECT_REASON=@REJECT_REASON,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE REJECT_CODE=@REJECT_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE RETURN_REJECT_HIST WHERE REJECT_CODE=@REJECT_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO RETURN_REJECT
				SELECT REJECT_CODE, REJECT_REASON,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM RETURN_REJECT_HIST
					WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE RETURN_REJECT_HIST WHERE REJECT_CODE=@REJECT_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	update detail to return_reject table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ReturnReject_Update]	
	@REJECT_CODE	varchar(4),
	@REJECT_REASON 	varchar(100),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT REJECT_CODE FROM RETURN_REJECT 
				WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE RETURN_REJECT_HIST WHERE REJECT_CODE=@REJECT_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO RETURN_REJECT_HIST(REJECT_CODE, REJECT_REASON,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@REJECT_CODE, @REJECT_REASON,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT REJECT_CODE from RETURN_REJECT_HIST 
						WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE RETURN_REJECT_HIST WHERE REJECT_CODE=@REJECT_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO RETURN_REJECT_HIST(REJECT_CODE, REJECT_REASON,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@REJECT_CODE, @REJECT_REASON,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail of Return_Reject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_GetDetail]	
	@REJECT_CODE	varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT REJECT_CODE 
			   FROM RETURN_REJECT WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM RETURN_REJECT 
			WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM RETURN_REJECT_HIST
			WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail to Return_Reject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM RETURN_REJECT_HIST 
				WHERE IS_AUTH=0			
				ORDER BY REJECT_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM RETURN_REJECT
						WHERE [STATUS] =''L''					
						ORDER BY REJECT_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM RETURN_REJECT
						WHERE [STATUS] in (''L'',''D'')					
						ORDER BY REJECT_CODE
				END;
		END;

	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Remove record from return_reject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_Remove]	
	@REJECT_CODE	varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@REJECT_REASON 	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT REJECT_CODE from RETURN_REJECT 
			  WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@REJECT_REASON=REJECT_REASON,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM RETURN_REJECT 
				WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE RETURN_REJECT_HIST WHERE REJECT_CODE=@REJECT_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				RETURN_REJECT_HIST (REJECT_CODE, REJECT_REASON,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@REJECT_CODE, @REJECT_REASON, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT REJECT_CODE from RETURN_REJECT_HIST 
					  WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE RETURN_REJECT_HIST
						WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get Total # of modification of return_reject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_GetMaxMod]	
	@REJECT_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM RETURN_REJECT_HIST 
		WHERE REJECT_CODE=@REJECT_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM RETURN_REJECT 
				WHERE REJECT_CODE=@REJECT_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnReject_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Jan-13
-- Description:	Get detail of Return_Reject by code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_GetDetailByCode]	
	@REJECT_CODE	varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT *
	FROM RETURN_REJECT 
	WHERE REJECT_CODE=@REJECT_CODE 
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermForms_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Nov-12
-- Description:	Add detail to Perm_Forms
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PermForms_Add]	
	@FG_SLNO		numeric(6,0),
	@FORM_SLNO		numeric(6,0),
	@IS_SHOW		bit,
	@IS_NEW			bit,
	@IS_UNLOCK		bit,
	@IS_AUTHORIZER	bit,
	@IS_DELETE		bit,
	@IS_SAVE		bit		
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
			
	DELETE PERM_FORMS_HIST WHERE 
		FG_SLNO=@FG_SLNO AND FORM_SLNO=@FORM_SLNO AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO PERM_FORMS_HIST(FG_SLNO, FORM_SLNO, IS_SHOW, IS_NEW, 
		IS_UNLOCK, IS_AUTHORIZER, IS_DELETE, IS_SAVE, MOD_NO,IS_AUTH)
		VALUES(@FG_SLNO, @FORM_SLNO, @IS_SHOW, @IS_NEW, 
		@IS_UNLOCK, @IS_AUTHORIZER, @IS_DELETE, @IS_SAVE, 1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PermForms_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	update detail to Perm_Forms table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_PermForms_Update]	
	@FG_SLNO		numeric(6,0),
	@FORM_SLNO		numeric(6,0),
	@IS_SHOW		bit,
	@IS_NEW			bit,
	@IS_UNLOCK		bit,
	@IS_AUTHORIZER	bit,
	@IS_DELETE		bit,
	@IS_SAVE		bit,	
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO PERM_FORMS_HIST(FG_SLNO, FORM_SLNO, IS_SHOW, 
		IS_NEW, IS_UNLOCK, IS_AUTHORIZER, IS_DELETE, IS_SAVE, 
		MOD_NO, IS_AUTH)
		VALUES(@FG_SLNO, @FORM_SLNO, @IS_SHOW, 
		@IS_NEW, @IS_UNLOCK, @IS_AUTHORIZER, @IS_DELETE, @IS_SAVE, 
		@MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpCrBooking_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-13
-- Description:	Get detail of TMP_CR_BOOKING
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TmpCrBooking_GetDetail]	
	
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT * 
	FROM TMP_CR_BOOKING
	

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Branch_GetListByBankLoc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Sep-13
-- Description:	get list records of branch by bank,Location
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetListByBankLoc]
	@BANK_CODE		varchar(4),
	@LOCATION_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT BRANCH_CODE,BRANCH_NAME
	FROM BRANCH		
	WHERE STATUS=''L'' 
	AND BANK_CODE=@BANK_CODE AND LOCATION_CODE=@LOCATION_CODE
	ORDER BY BRANCH_NAME;	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpDrBooking_GetFlexDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-13
-- Description:	Get detail of TMP_DR_BOOKING
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TmpDrBooking_GetFlexDetail]	
	
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT CRED_TYPE,SUNACC_NO,SUM(AMOUNT) as AMOUNT, VALUE_DATE, DEP_TYP, REF_NO, REMARKS
		FROM TMP_DR_BOOKING
		GROUP BY CRED_TYPE,SUNACC_NO,VALUE_DATE,DEP_TYP,REF_NO,REMARKS
	

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Jan-13
-- Description:	update detail to CSD
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CSD_Update]	
	@D_CODE		varchar(12), 
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT D_CODE FROM CSD 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CSD_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CSD_HIST(D_CODE, 
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@D_CODE, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE CSD_DET_HIST
				WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT D_CODE from CSD_HIST 
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CSD_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO CSD_HIST(D_CODE, 
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@D_CODE, 
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE CSD_DET_HIST
						WHERE D_CODE=@D_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Jan-13
-- Description:	Get Total # of modification of CSD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_GetMaxMod]	
	@D_CODE		varchar(12)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CSD_HIST 
		WHERE D_CODE=@D_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CSD 
				WHERE D_CODE=@D_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Jan-13
-- Description:	Add detail to CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_Add]	
	@D_CODE		varchar(12)
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT D_CODE FROM CSD
				WHERE D_CODE=@D_CODE)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE CSD_HIST WHERE 
		D_CODE=@D_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO CSD_HIST(D_CODE, 
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@D_CODE, 
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE CSD_DET_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Mar-12
-- Description:	Get detail to CSD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM CSD_HIST 
				WHERE IS_AUTH=0
				ORDER BY D_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CSD
						WHERE [STATUS] =''L''				
						ORDER BY D_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''            
        
							ELSE ''A''
						END 
						FROM CSD
						WHERE [STATUS] IN (''L'',''D'')			
						ORDER BY D_CODE;
				END;
		END;	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSD_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 09-Jan-13
-- Description:	Get detail of CSD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSD_GetDetail]	
	@D_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM CSD WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CSD 
			WHERE D_CODE=@D_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CSD_HIST
			WHERE D_CODE=@D_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get Total # of modification of checkType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_GetMaxMod]	
	@CHECKTYPE_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CHECKTYPE_HIST 
		WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CHECKTYPE 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail of CheckType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_GetDetail]	
	@CHECKTYPE_CODE	varchar(8),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT CHECKTYPE_CODE 
			   FROM CHECKTYPE WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CHECKTYPE 
			WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CHECKTYPE_HIST
			WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	get detail to CheckType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM CHECKTYPE_HIST 
				WHERE IS_AUTH=0			
				ORDER BY CHECKTYPE_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CHECKTYPE
						WHERE [STATUS] =''L''					
						ORDER BY CHECKTYPE_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CHECKTYPE
						WHERE [STATUS] in (''L'',''D'')					
						ORDER BY CHECKTYPE_CODE;
				END;
		END;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Authorize record to CheckType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_Auth]	
	@CHECKTYPE_CODE	varchar(8),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@CHECKTYPE_NAME	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CHECKTYPE_CODE from CHECKTYPE_HIST 
			  WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CHECKTYPE_NAME=CHECKTYPE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CHECKTYPE_HIST 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CHECKTYPE_HIST 
				SELECT *,1 FROM CHECKTYPE
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CHECKTYPE_HIST
				SET [STATUS] = ''O'' 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CHECKTYPE
				SET CHECKTYPE_NAME=@CHECKTYPE_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CHECKTYPE_HIST WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CHECKTYPE
				SELECT CHECKTYPE_CODE, CHECKTYPE_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CHECKTYPE_HIST
					WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CHECKTYPE_HIST WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Remove record from CheckType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_Remove]	
	@CHECKTYPE_CODE	varchar(8),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@CHECKTYPE_NAME 	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CHECKTYPE_CODE from CHECKTYPE 
			  WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CHECKTYPE_NAME=CHECKTYPE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CHECKTYPE 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CHECKTYPE_HIST WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CHECKTYPE_HIST (CHECKTYPE_CODE, CHECKTYPE_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@CHECKTYPE_CODE, @CHECKTYPE_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT CHECKTYPE_CODE from CHECKTYPE_HIST 
					  WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CHECKTYPE_HIST
						WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Apr-13
-- Description:	Get detail of ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetDetails]	
	@MID		numeric(10,0),
	@MOD_NO		int
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
			   FROM CLEARINGTAB WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT ct.*,''IS_AUTH''=1,
				cb.BRANCH_NAME AS ''ENTRY_LOC_NAME'',br.BRANCH_NAME,
				b.BANK_CODE,b.BANK_NAME,cl.ACC_NAME, ctp.CHECKTYPE_NAME
			FROM CLEARINGTAB ct
				LEFT OUTER JOIN CITIBANK_BRANCH cb
				ON cb.BRANCH_CODE=ct.ENTRY_LOC				
				LEFT OUTER JOIN CLEARING_BRANCH br
				ON br.NIKBRANCH_CODE=ct.NIKBRANCH_CODE
				LEFT OUTER JOIN CLEARING_BANK b
				ON b.BANK_CODE=br.BANK_CODE
				LEFT OUTER JOIN CLEARING_CLIENT cl
				ON cl.ACC_NO=ct.REMARK
				LEFT OUTER JOIN CHECKTYPE ctp
				ON ctp.CHECKTYPE_CODE=ct.CHECK_TYPE
			WHERE ct.MID=@MID AND ct.MOD_NO = @MOD_NO			
		END	
	ELSE
		BEGIN
			SELECT cth.* ,
				cb.BRANCH_NAME AS ''ENTRY_LOC_NAME'',br.BRANCH_NAME,
				b.BANK_CODE,b.BANK_NAME,cl.ACC_NAME, ctp.CHECKTYPE_NAME
			FROM CLEARINGTAB_HIST cth
				LEFT OUTER JOIN CITIBANK_BRANCH cb
				ON cb.BRANCH_CODE=cth.ENTRY_LOC				
				LEFT OUTER JOIN CLEARING_BRANCH br
				ON br.NIKBRANCH_CODE=cth.NIKBRANCH_CODE
				LEFT OUTER JOIN CLEARING_BANK b
				ON b.BANK_CODE=br.BANK_CODE
				LEFT OUTER JOIN CLEARING_CLIENT cl
				ON cl.ACC_NO=cth.REMARK
				LEFT OUTER JOIN CHECKTYPE ctp
				ON ctp.CHECKTYPE_CODE=cth.CHECK_TYPE
			WHERE cth.MID=@MID AND cth.MOD_NO = @MOD_NO			
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	update detail to CheckType table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CheckType_Update]	
	@CHECKTYPE_CODE	varchar(8),
	@CHECKTYPE_NAME varchar(100),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CHECKTYPE_CODE FROM CHECKTYPE 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CHECKTYPE_HIST WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CHECKTYPE_HIST(CHECKTYPE_CODE, CHECKTYPE_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@CHECKTYPE_CODE, @CHECKTYPE_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT CHECKTYPE_CODE from CHECKTYPE_HIST 
						WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CHECKTYPE_HIST WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CHECKTYPE_HIST(CHECKTYPE_CODE, CHECKTYPE_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@CHECKTYPE_CODE, @CHECKTYPE_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to CheckType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_Add]	
	@CHECKTYPE_CODE		varchar(8),
	@CHECKTYPE_NAME 	varchar(50)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CHECKTYPE_CODE FROM CHECKTYPE WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CHECKTYPE_HIST WHERE 
		CHECKTYPE_CODE=@CHECKTYPE_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CHECKTYPE_HIST(CHECKTYPE_CODE, CHECKTYPE_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@CHECKTYPE_CODE, @CHECKTYPE_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	get detail of CheckType table
--				by CheckType_Code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_GetDetailByCode]	
	@CHECKTYPE_CODE	varchar(8)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT *
		FROM CHECKTYPE
		WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE;		
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckType_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	get list records of CheckType
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_GetList]	
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT CHECKTYPE_CODE, CHECKTYPE_NAME
	FROM CHECKTYPE
	WHERE STATUS=''L''	
	ORDER BY CHECKTYPE_NAME;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTab_GetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Get detail of PDCTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTab_GetDetails]	
	@MID		numeric(10,0),
	@MOD_NO		int
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
			   FROM PDCTAB WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT ct.*,''IS_AUTH''=1,
				cb.BRANCH_NAME AS ''ENTRY_LOC_NAME'',br.BRANCH_NAME,
				b.BANK_CODE,b.BANK_NAME,cl.ACC_NAME, ctp.CHECKTYPE_NAME
			FROM PDCTAB ct
				LEFT OUTER JOIN CITIBANK_BRANCH cb
				ON cb.BRANCH_CODE=ct.ENTRY_LOC				
				LEFT OUTER JOIN CLEARING_BRANCH br
				ON br.NIKBRANCH_CODE=ct.NIKBRANCH_CODE
				LEFT OUTER JOIN CLEARING_BANK b
				ON b.BANK_CODE=br.BANK_CODE
				LEFT OUTER JOIN CLEARING_CLIENT cl
				ON cl.ACC_NO=ct.REMARK
				LEFT OUTER JOIN CHECKTYPE ctp
				ON ctp.CHECKTYPE_CODE=ct.CHECK_TYPE
			WHERE ct.MID=@MID AND ct.MOD_NO = @MOD_NO			
		END	
	ELSE
		BEGIN
			SELECT cth.* ,
				cb.BRANCH_NAME AS ''ENTRY_LOC_NAME'',br.BRANCH_NAME,
				b.BANK_CODE,b.BANK_NAME,cl.ACC_NAME, ctp.CHECKTYPE_NAME
			FROM PDCTAB_HIST cth
				LEFT OUTER JOIN CITIBANK_BRANCH cb
				ON cb.BRANCH_CODE=cth.ENTRY_LOC				
				LEFT OUTER JOIN CLEARING_BRANCH br
				ON br.NIKBRANCH_CODE=cth.NIKBRANCH_CODE
				LEFT OUTER JOIN CLEARING_BANK b
				ON b.BANK_CODE=br.BANK_CODE
				LEFT OUTER JOIN CLEARING_CLIENT cl
				ON cl.ACC_NO=cth.REMARK
				LEFT OUTER JOIN CHECKTYPE ctp
				ON ctp.CHECKTYPE_CODE=cth.CHECK_TYPE
			WHERE cth.MID=@MID AND cth.MOD_NO = @MOD_NO			
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingReturnReject_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Sep-13
-- Description:	Get detail of CLEARING_Return_Reject by code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingReturnReject_GetDetailByCode]	
	@REJECT_CODE	varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT *
	FROM CLEARING_RETURN_REJECT 
	WHERE REJECT_CODE=@REJECT_CODE 
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnClearing_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Aug-13
-- Description:	Get detail of ReturnClearing
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnClearing_GetDetail]	
	@MID	numeric(10,0),
	@DSL	numeric(4,0)	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
		SELECT rc.*,rr.REJECT_REASON
			FROM RETURN_CLEARING rc
			LEFT OUTER JOIN CLEARING_RETURN_REJECT rr
			ON rr.REJECT_CODE=rc.RTN_CODE
			WHERE MID=@MID AND DSL=@DSL	
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Nov-12
-- Description:	Add detail to Users Functionional Group
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_Add]	
	@USERS_ID	varchar(20)	
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT USERS_ID FROM USERS_FG 
				WHERE USERS_ID=@USERS_ID)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE USERS_FG_HIST WHERE 
		USERS_ID=@USERS_ID AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO USERS_FG_HIST(USERS_ID,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@USERS_ID,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE USERS_FG_DET_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Nov-12
-- Description:	update detail to Users FG
-- =============================================

CREATE PROCEDURE [dbo].[CMS_UsersFG_Update]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT USERS_ID FROM USERS_FG 
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE USERS_FG_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO USERS_FG_HIST(USERS_ID,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@USERS_ID,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE USERS_FG_DET_HIST
				WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT USERS_ID from USERS_FG_HIST 
						WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE USERS_FG_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO USERS_FG_HIST(USERS_ID,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@USERS_ID,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE USERS_FG_DET_HIST
						WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Nov-12
-- Description:	Get Total # of modification of USERS FG
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_GetMaxMod]	
	@USERS_ID	varchar(20)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM USERS_FG_HIST 
		WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM USERS_FG
				WHERE USERS_ID=@USERS_ID;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Nov-12
-- Description:	Authorize record to Users FG
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_Auth]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT USERS_ID from USERS_FG_HIST 
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM USERS_FG_HIST 
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO USERS_FG_HIST 
				SELECT *,1 FROM USERS_FG
				WHERE USERS_ID=@USERS_ID;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE USERS_FG_HIST
				SET [STATUS] = ''O'' 
				WHERE USERS_ID=@USERS_ID
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE USERS_FG
				SET 		
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE USERS_ID=@USERS_ID;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE USERS_FG_HIST WHERE USERS_ID=@USERS_ID
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO USERS_FG
				SELECT USERS_ID,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM USERS_FG_HIST
					WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE USERS_FG_HIST WHERE USERS_ID=@USERS_ID
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update USERS_FG_DET

	INSERT INTO USERS_FG_DET_HIST
		SELECT *,1
		FROM USERS_FG_DET
		WHERE USERS_ID=@USERS_ID;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE USERS_FG_DET WHERE USERS_ID=@USERS_ID;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO USERS_FG_DET
		SELECT USERS_ID,FG_SLNO, MOD_NO
		FROM USERS_FG_DET_HIST 
		WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE USERS_FG_DET_HIST WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Nov-12
-- Description:	Remove record from Users FG
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_Remove]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT USERS_ID from USERS_FG
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM USERS_FG
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE USERS_FG_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				USERS_FG_HIST (USERS_ID,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@USERS_ID,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE USERS_FG_DET_HIST
				WHERE USERS_ID=@USERS_ID AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO USERS_FG_DET_HIST
				SELECT USERS_ID,FG_SLNO, @RET_MOD_NO,0
				FROM USERS_FG_DET
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT USERS_ID from USERS_FG_HIST 
					  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE USERS_FG_HIST
						WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE USERS_FG_DET_HIST 
						WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Nov-12
-- Description:	Get detail of Users FG
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT ugh.*,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,''S'' = ''U''				 
			FROM USERS_FG_HIST ugh
			INNER JOIN USERS u
			ON u.USERS_ID=ugh.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE IS_AUTH=0
			UNION
			SELECT ug.*,1,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,''S'' = ''A''				
			FROM USERS_FG ug
			INNER JOIN USERS u
			ON u.USERS_ID=ug.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE ug.STATUS =''L''					
			ORDER BY IS_AUTH,DEPT_ID,USERS_ID

		END
	ELSE
		BEGIN	

			SELECT ugh.*,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,''S'' = ''U''				 
			FROM USERS_FG_HIST ugh
			INNER JOIN USERS u
			ON u.USERS_ID=ugh.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE IS_AUTH=0
			UNION
			SELECT ug.*,1,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,''S'' = 
				CASE  
					WHEN ug.STATUS = ''D'' THEN ''D''                    
					ELSE ''A''
                END 			
			FROM USERS_FG ug
			INNER JOIN USERS u
			ON u.USERS_ID=ug.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE ug.STATUS in (''L'',''D'')					
			ORDER BY IS_AUTH,DEPT_ID,USERS_ID

		END
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFG_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get detail of Users_FG 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFG_GetDetail]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT USERS_ID 
				FROM USERS_FG WHERE USERS_ID=@USERS_ID 
				AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT ufg.*,''IS_AUTH''=1,u.USERS_NAME,d.DEPT_NAME
				FROM USERS_FG ufg				
				INNER JOIN USERS u ON u.USERS_ID=ufg.USERS_ID
				INNER JOIN DEPARTMENT d ON d.SLNO=u.DEPT_SLNO
				WHERE ufg.USERS_ID=@USERS_ID AND ufg.MOD_NO=@MOD_NO
		END	
	ELSE
		BEGIN
			SELECT ufgh.*,u.USERS_NAME,d.DEPT_NAME
				FROM USERS_FG_HIST ufgh				
				INNER JOIN USERS u ON u.USERS_ID=ufgh.USERS_ID
				INNER JOIN DEPARTMENT d ON d.SLNO=u.DEPT_SLNO
				WHERE ufgh.USERS_ID=@USERS_ID AND ufgh.MOD_NO=@MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	update detail to Citibank_branch table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_Update]	
	@BRANCH_CODE		varchar(3),
	@BRANCH_NAME 		varchar(35),
	@ADDRESS1 			varchar(35),
	@ADDRESS2 			varchar(35),	
	@CLEARING_DEBIT_ACC varchar(20),
	@MOD_NO				int,
	@RET_MOD_NO			int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BRANCH_CODE FROM CITIBANK_BRANCH 
				WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CITIBANK_BRANCH_HIST WHERE BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME,	
				ADDRESS1,ADDRESS2,CLEARING_DEBIT_ACC,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BRANCH_CODE, @BRANCH_NAME,
				@ADDRESS1,@ADDRESS2,@CLEARING_DEBIT_ACC,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT BRANCH_CODE from CITIBANK_BRANCH_HIST 
						WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CITIBANK_BRANCH_HIST WHERE BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME,	
						ADDRESS1,ADDRESS2,CLEARING_DEBIT_ACC,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BRANCH_CODE, @BRANCH_NAME,
						@ADDRESS1,@ADDRESS2,@CLEARING_DEBIT_ACC,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Add detail to Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_Add]	
	@BRANCH_CODE	varchar(3),
	@BRANCH_NAME 	varchar(35),
	@ADDRESS1 		varchar(35),
	@ADDRESS2 		varchar(35),	
	@CLEARING_DEBIT_ACC varchar(20)
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BRANCH_CODE from CITIBANK_BRANCH WHERE BRANCH_CODE=@BRANCH_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CITIBANK_BRANCH_HIST WHERE 
		BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME,	
		ADDRESS1,ADDRESS2,CLEARING_DEBIT_ACC,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BRANCH_CODE, @BRANCH_NAME,
		@ADDRESS1,@ADDRESS2,@CLEARING_DEBIT_ACC,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Remove record from Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_Remove]	
	@BRANCH_CODE	varchar(3),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BRANCH_NAME 	varchar(35),
			@ADDRESS1 		varchar(35),
			@ADDRESS2 		varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from CITIBANK_BRANCH 
			  WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME=BRANCH_NAME,
				@ADDRESS1=ADDRESS1,@ADDRESS2=ADDRESS2,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CITIBANK_BRANCH 
				WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CITIBANK_BRANCH_HIST WHERE BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CITIBANK_BRANCH_HIST (BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BRANCH_CODE, @BRANCH_NAME, @ADDRESS1, @ADDRESS2,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT BRANCH_CODE from CITIBANK_BRANCH_HIST 
					  WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CITIBANK_BRANCH_HIST
						WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Get Total # of modification of Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_GetMaxMod]	
	@BRANCH_CODE		varchar(3)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CITIBANK_BRANCH_HIST 
		WHERE BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CITIBANK_BRANCH 
				WHERE BRANCH_CODE=@BRANCH_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Add detail to Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 
				IS_AUTH, CLEARING_DEBIT_ACC,''S'' = ''U''				 
			FROM CITIBANK_BRANCH_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 
				1, CLEARING_DEBIT_ACC,''S'' = ''A''				
			FROM CITIBANK_BRANCH
			WHERE STATUS =''L''					
			ORDER BY IS_AUTH,BRANCH_CODE

		END
	ELSE
		BEGIN	

			SELECT BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 
				IS_AUTH, CLEARING_DEBIT_ACC,''S'' = ''U''				 
			FROM CITIBANK_BRANCH_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 
				1, CLEARING_DEBIT_ACC,''S'' = 
				CASE  
					WHEN STATUS = ''D'' THEN ''D''                    
					ELSE ''A''
                END 
			FROM CITIBANK_BRANCH
			WHERE STATUS in (''L'',''D'')					
			ORDER BY IS_AUTH,BRANCH_CODE

		END
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Get detail of Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_GetDetail]	
	@BRANCH_CODE	varchar(3),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT BRANCH_CODE 
			   FROM CITIBANK_BRANCH WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CITIBANK_BRANCH 
			WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CITIBANK_BRANCH_HIST
			WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Authorize record to Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_Auth]	
	@BRANCH_CODE	varchar(3),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BRANCH_NAME	varchar(35),
			@ADDRESS1 		varchar(35),
			@ADDRESS2 		varchar(35),
			@CLEARING_DEBIT_ACC varchar(20),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from CITIBANK_BRANCH_HIST 
			  WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME=BRANCH_NAME,
				@ADDRESS1=ADDRESS1,@ADDRESS2=ADDRESS2,
				@CLEARING_DEBIT_ACC=CLEARING_DEBIT_ACC,		
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CITIBANK_BRANCH_HIST 
				WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME, 
				ADDRESS1, ADDRESS2, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, 
				[STATUS], IS_AUTH, CLEARING_DEBIT_ACC) 
				SELECT BRANCH_CODE, BRANCH_NAME, 
				ADDRESS1, ADDRESS2, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, 
				[STATUS], 1, CLEARING_DEBIT_ACC FROM CITIBANK_BRANCH
				WHERE BRANCH_CODE=@BRANCH_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CITIBANK_BRANCH_HIST
				SET [STATUS] = ''O'' 
				WHERE BRANCH_CODE=@BRANCH_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CITIBANK_BRANCH
				SET BRANCH_NAME=@BRANCH_NAME,
				ADDRESS1=@ADDRESS1,ADDRESS2=@ADDRESS2,
				CLEARING_DEBIT_ACC=@CLEARING_DEBIT_ACC,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE BRANCH_CODE=@BRANCH_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CITIBANK_BRANCH_HIST WHERE BRANCH_CODE=@BRANCH_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CITIBANK_BRANCH(BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], CLEARING_DEBIT_ACC)
				SELECT BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' ,CLEARING_DEBIT_ACC
					FROM CITIBANK_BRANCH_HIST
					WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CITIBANK_BRANCH_HIST WHERE BRANCH_CODE=@BRANCH_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	Get detail of Citibank branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_GetDetailByCode]	
	@BRANCH_CODE	varchar(3)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM CITIBANK_BRANCH
	WHERE BRANCH_CODE=@BRANCH_CODE
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiBankBranch_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-14
-- Description:	get list records of Citibank Branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT BRANCH_CODE,BRANCH_NAME FROM CITIBANK_BRANCH WHERE STATUS=''L''
	ORDER BY BRANCH_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Get detail to PDCTotal table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit,
	@ENTRY_DATE	datetime,
	@ENTRY_LOC	varchar(3)
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT ch.*,''S'' = ''U'',cb.BRANCH_NAME
				FROM PDCTOTAL_HIST ch
				LEFT OUTER JOIN CITIBANK_BRANCH cb
				ON cb.BRANCH_CODE=ch.ENTRY_LOC
				WHERE ch.IS_AUTH=0 AND ch.ENTRY_LOC=@ENTRY_LOC
				ORDER BY ch.DS_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A'',cb.BRANCH_NAME				
						FROM PDCTOTAL ct
						LEFT OUTER JOIN CITIBANK_BRANCH cb
						ON cb.BRANCH_CODE=ct.ENTRY_LOC
						WHERE ct.STATUS =''L'' AND ct.ENTRY_LOC=@ENTRY_LOC
						AND ct.ENTRY_DATE=@ENTRY_DATE
						ORDER BY ct.DS_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN ct.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END ,cb.BRANCH_NAME	
						FROM PDCTOTAL ct
						LEFT OUTER JOIN CITIBANK_BRANCH cb
						ON cb.BRANCH_CODE=ct.ENTRY_LOC
						WHERE ct.STATUS IN (''L'',''D'')
						AND ct.ENTRY_LOC=@ENTRY_LOC
						AND ct.ENTRY_DATE=@ENTRY_DATE
						ORDER BY DS_CODE;
				END;
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Jul-13
-- Description:	Get detail to CheckTotal table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit,
	@ENTRY_DATE	datetime,
	@ENTRY_LOC	varchar(3)
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT ch.*,''S'' = ''U'',cb.BRANCH_NAME
				FROM CHECKTOTAL_HIST ch
				LEFT OUTER JOIN CITIBANK_BRANCH cb
				ON cb.BRANCH_CODE=ch.ENTRY_LOC
				WHERE ch.IS_AUTH=0 AND ch.ENTRY_LOC=@ENTRY_LOC
				ORDER BY ch.DS_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A'',cb.BRANCH_NAME				
						FROM CHECKTOTAL ct
						LEFT OUTER JOIN CITIBANK_BRANCH cb
						ON cb.BRANCH_CODE=ct.ENTRY_LOC
						WHERE ct.STATUS =''L'' AND ct.ENTRY_LOC=@ENTRY_LOC
						AND ct.ENTRY_DATE=@ENTRY_DATE
						ORDER BY ct.DS_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN ct.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END ,cb.BRANCH_NAME	
						FROM CHECKTOTAL ct
						LEFT OUTER JOIN CITIBANK_BRANCH cb
						ON cb.BRANCH_CODE=ct.ENTRY_LOC
						WHERE ct.STATUS IN (''L'',''D'')
						AND ct.ENTRY_LOC=@ENTRY_LOC
						AND ct.ENTRY_DATE=@ENTRY_DATE
						ORDER BY DS_CODE;
				END;
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	get list records of clearing_client
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_GetList]	
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT ACC_NO, ACC_NAME
	FROM CLEARING_CLIENT		
	WHERE STATUS=''L''
	AND IS_DISABLE=0	
	ORDER BY ACC_NAME;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	get detail of clearing client table
--				by acc_no
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_GetDetailByCode]	
	@ACC_NO	varchar(15)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT *
		FROM CLEARING_CLIENT 		
		WHERE ACC_NO=@ACC_NO
		AND IS_DISABLE=0
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Add detail to ClearingClient table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_Add]		
	@ACC_NO				varchar(15),  
	@ACC_NAME			varchar(50),
	@MAIL_ADD			varchar(256), 
	@CONTACT			varchar(50), 		
	@SPEED_CR_TYPE		varchar(25),	
	@IS_DISABLE			bit
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	

	IF EXISTS(SELECT ACC_NO FROM CLEARING_CLIENT WHERE ACC_NO=@ACC_NO)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE CLEARING_CLIENT_HIST WHERE 
		ACC_NO=@ACC_NO AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	ELSE

	INSERT INTO CLEARING_CLIENT_HIST(ACC_NO, ACC_NAME,MAIL_ADD,
		CONTACT, SPEED_CR_TYPE,IS_DISABLE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@ACC_NO, @ACC_NAME,@MAIL_ADD,
		@CONTACT, @SPEED_CR_TYPE, @IS_DISABLE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE CLEARING_CLIENT_CHARGE_HIST 
		WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	
	
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Authorize record to Clearing_Client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_Auth]	
	@ACC_NO			varchar(15),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),			
			@ACC_NAME			varchar(50),
			@MAIL_ADD			varchar(256), 
			@CONTACT			varchar(50), 			
			@SPEED_CR_TYPE		varchar(25),			
			@IS_DISABLE			bit,
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar1		int; 
	
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ACC_NO from CLEARING_CLIENT_HIST 
			  WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS], 
				@ACC_NAME=ACC_NAME,@MAIL_ADD=MAIL_ADD,@CONTACT=CONTACT,
				@SPEED_CR_TYPE=SPEED_CR_TYPE,@IS_DISABLE=IS_DISABLE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLEARING_CLIENT_HIST 
				WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLEARING_CLIENT_HIST 
				SELECT *,1 FROM CLEARING_CLIENT
				WHERE ACC_NO=@ACC_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLEARING_CLIENT_HIST
				SET [STATUS] = ''O'' 
				WHERE ACC_NO=@ACC_NO 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLEARING_CLIENT
				SET ACC_NAME=@ACC_NAME,MAIL_ADD=@MAIL_ADD,CONTACT=@CONTACT,
				SPEED_CR_TYPE=@SPEED_CR_TYPE, IS_DISABLE=@IS_DISABLE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE ACC_NO=@ACC_NO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLEARING_CLIENT_HIST WHERE ACC_NO=@ACC_NO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLEARING_CLIENT
				SELECT ACC_NO, ACC_NAME,MAIL_ADD,
					CONTACT, SPEED_CR_TYPE,IS_DISABLE, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM,
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLEARING_CLIENT_HIST
					WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLEARING_CLIENT_HIST WHERE ACC_NO=@ACC_NO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

	-- Now update CLEARING_CLIENT_CHARGE

	INSERT INTO CLEARING_CLIENT_CHARGE_HIST(ACC_NO, SLNO, VALUE_TYPE, 
		MIN_AMOUNT, MAX_AMOUNT, BACH_CHARGE, BANK_CHARGE, MOD_NO, IS_AUTH)
		SELECT ACC_NO, SLNO, VALUE_TYPE, 
		MIN_AMOUNT, MAX_AMOUNT, BACH_CHARGE, BANK_CHARGE, MOD_NO, 1
		FROM CLEARING_CLIENT_CHARGE
		WHERE ACC_NO=@ACC_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE CLEARING_CLIENT_CHARGE WHERE ACC_NO=@ACC_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO CLEARING_CLIENT_CHARGE(ACC_NO, SLNO, VALUE_TYPE, 
		MIN_AMOUNT, MAX_AMOUNT, BACH_CHARGE, BANK_CHARGE, MOD_NO)
		SELECT ACC_NO, SLNO, VALUE_TYPE, 
		MIN_AMOUNT, MAX_AMOUNT, BACH_CHARGE, BANK_CHARGE, MOD_NO
		FROM CLEARING_CLIENT_CHARGE_HIST 
		WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE CLEARING_CLIENT_CHARGE_HIST WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Get detail of Clearing_client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_GetDetail]	
	@ACC_NO	varchar(15),	
	@MOD_NO	int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT ACC_NO 
			   FROM CLEARING_CLIENT WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CLEARING_CLIENT 
			WHERE ACC_NO=@ACC_NO AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CLEARING_CLIENT_HIST
			WHERE ACC_NO=@ACC_NO AND MOD_NO = @MOD_NO
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Get Total # of modification of CLEARING_CLIENT table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_GetMaxMod]	
	@ACC_NO	varchar(15)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLEARING_CLIENT_HIST 
		WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLEARING_CLIENT 
				WHERE ACC_NO=@ACC_NO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Remove record from Clearing_Client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_Remove]	
	@ACC_NO		varchar(15),	
	@MOD_NO		int,
	@RET_MOD_NO	int output
AS
BEGIN	
	DECLARE @STATUS				char(1),			
			@ACC_NAME			varchar(50),
			@MAIL_ADD			varchar(256), 
			@CONTACT			varchar(50), 			
			@SPEED_CR_TYPE		varchar(25),			
			@IS_DISABLE			bit,
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),			
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ACC_NO from CLEARING_CLIENT 
			  WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@ACC_NAME=ACC_NAME,@MAIL_ADD=MAIL_ADD,@CONTACT=CONTACT,
				@SPEED_CR_TYPE=SPEED_CR_TYPE,@IS_DISABLE=IS_DISABLE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLEARING_CLIENT 
				WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLEARING_CLIENT_HIST WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLEARING_CLIENT_HIST (ACC_NO, ACC_NAME,MAIL_ADD,
				CONTACT, SPEED_CR_TYPE, IS_DISABLE,				
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@ACC_NO, @ACC_NAME,@MAIL_ADD,
				@CONTACT, @SPEED_CR_TYPE,@IS_DISABLE, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT ACC_NO from CLEARING_CLIENT_HIST 
					  WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLEARING_CLIENT_HIST
						WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	update detail to Clearing_client table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClearingClient_Update]		
	@ACC_NO				varchar(15),  
	@ACC_NAME			varchar(50),
	@MAIL_ADD			varchar(256), 
	@CONTACT			varchar(50), 	
	@SPEED_CR_TYPE		varchar(25),	
	@IS_DISABLE			bit,
	@MOD_NO				int,
	@RET_MOD_NO			int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT ACC_NO FROM CLEARING_CLIENT 
				WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CLEARING_CLIENT_HIST WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CLEARING_CLIENT_HIST(ACC_NO, ACC_NAME, MAIL_ADD,
				CONTACT, SPEED_CR_TYPE, IS_DISABLE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@ACC_NO, @ACC_NAME,@MAIL_ADD,
				@CONTACT, @SPEED_CR_TYPE, @IS_DISABLE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END

			DELETE CLEARING_CLIENT_CHARGE_HIST 
				WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT ACC_NO from CLEARING_CLIENT_HIST 
						WHERE ACC_NO=@ACC_NO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CLEARING_CLIENT_HIST WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END

					INSERT INTO CLEARING_CLIENT_HIST(ACC_NO, ACC_NAME,MAIL_ADD,
						CONTACT, SPEED_CR_TYPE, IS_DISABLE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@ACC_NO, @ACC_NAME,@MAIL_ADD,
						@CONTACT, @SPEED_CR_TYPE, @IS_DISABLE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;	

					DELETE CLEARING_CLIENT_CHARGE_HIST 
						WHERE ACC_NO=@ACC_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_ClearingRevGenerate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Apr-13
-- Description: Process for reversal deposit update
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_ClearingRevGenerate]
	@REV_DATE	datetime,	
	@ENTRY_LOC	varchar(3),
	@REFACC_NO	varchar(16),
	@VALUE_TYPE	numeric(1,0)
AS
BEGIN	
	
	DELETE FROM TMP_REVERSAL_CLEARING 
		WHERE REV_DATE=@REV_DATE AND ENTRY_LOC=@ENTRY_LOC AND VALUE_TYPE=@VALUE_TYPE;


	INSERT INTO TMP_REVERSAL_CLEARING( CR_TYPE,VALUE_DATE,ENTRY_LOC,REV_DATE,
		ACC_NO,REFACC_NO,CLIENT_CODE,AMOUNT,
		DS_CODE,
		CHECK_NUMBER,
		SEQ_NO,ADD_TEXT,VALUE_TYPE)
                          
------By Total                                  
	SELECT c.SPEED_CR_TYPE,a.OPR_DATE VALUE_DATE, a.ENTRY_LOC,a.OPR_DATE,
		c.ACC_NO,@REFACC_NO AS REFACC_NO,a.REMARK,sum(a.DEBIT_CREDIT) as total,
		substring(CONVERT(varchar(12), a.OPR_DATE,112),3,8) as DS_CODE,
		substring(CONVERT(varchar(12), a.OPR_DATE,112),3,8) CHECK_NUMBER,
		COUNT(a.REMARK),'''' ADD_TEXT,@VALUE_TYPE
	FROM CLEARINGTAB a, CHECKTOTAL ct, CLEARING_CLIENT c                                  
	WHERE 
		a.MID=ct.MID AND ct.[STATUS]=''L''
		AND a.DEBIT_CREDIT>0                                  
		AND a.OPR_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC
		AND a.VALUE_TYPE=@VALUE_TYPE
		AND a.REMARK=c.ACC_NO
		AND a.FLEX_FILENAME IS NULL
		AND c.SPEED_CR_TYPE=''T''
	GROUP BY 
		a.OPR_DATE,a.ENTRY_LOC,c.SPEED_CR_TYPE,                                  
		c.ACC_NO ,a.REMARK                

	UNION ALL
            
------By Deposit code
	SELECT c.SPEED_CR_TYPE,a.OPR_DATE valueDate,a.ENTRY_LOC,a.OPR_DATE,
		c.ACC_NO,@REFACC_NO AS REFACC_NO,a.REMARK,sum(a.DEBIT_CREDIT) as total,
		a.DS_CODE ,
		a.DS_CODE CHECK_NUMBER,
		count(a.REMARK),'''' ADD_TEXT,@VALUE_TYPE
	FROM CLEARINGTAB a, CHECKTOTAL ct, CLEARING_CLIENT c
	WHERE
		a.MID=ct.MID AND ct.[STATUS]=''L''
		AND a.DEBIT_CREDIT>0 
		AND a.OPR_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC
		AND a.VALUE_TYPE=@VALUE_TYPE
		AND a.REMARK=c.ACC_NO
		AND a.FLEX_FILENAME IS NULL
		AND c.SPEED_CR_TYPE=''D''
	GROUP BY a.OPR_DATE,a.ENTRY_LOC,c.SPEED_CR_TYPE,
		c.ACC_NO ,a.REMARK,a.DS_CODE
	                                  
                                  
	UNION ALL
--\\\\\\\\\\\\\\\By Check\\\\\\\\                                  
                                
                                
	SELECT  c.SPEED_CR_TYPE,a.OPR_DATE,a.ENTRY_LOC,a.OPR_DATE,
		a.REMARK,@REFACC_NO REFACC_NO,a.REMARK,a.DEBIT_CREDIT,
		a.DS_CODE,
		a.CHECK_NUMBER,
		1  ,'''' ADD_TEXT,@VALUE_TYPE
	FROM CLEARINGTAB a, CHECKTOTAL ct, CLEARING_CLIENT c
	WHERE                    
		a.MID=ct.MID AND ct.[STATUS]=''L''
		AND a.DEBIT_CREDIT>0
		AND a.OPR_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC
		AND a.VALUE_TYPE=@VALUE_TYPE
		AND a.REMARK=c.ACC_NO
		AND a.FLEX_FILENAME IS NULL
		AND c.SPEED_CR_TYPE=''C''
                      
	UNION ALL                
                
	SELECT  c.SPEED_CR_TYPE,a.OPR_DATE,a.ENTRY_LOC,a.OPR_DATE,
		a.REMARK,@REFACC_NO REFACC_NO,a.REMARK,a.DEBIT_CREDIT,
		b.CUSTOMER_REF , 
		a.CHECK_NUMBER,
		1 ,'''' ADD_TEXT,@VALUE_TYPE
		FROM CLEARINGTAB a, CHECKTOTAL b, CLEARING_CLIENT c
	WHERE 
		a.MID=b.MID AND b.[STATUS]=''L''
		AND a.DS_CODE=b.DS_CODE AND a.ENTRY_LOC=b.ENTRY_LOC AND a.OPR_DATE=b.OPR_DATE
		AND a.VALUE_TYPE=@VALUE_TYPE
		AND a.DEBIT_CREDIT>0
		AND a.OPR_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC
		AND c.ACC_NO=a.REMARK
		AND a.FLEX_FILENAME IS NULL
		AND c.SPEED_CR_TYPE=''R''
        
	UNION ALL                
                
	SELECT  c.SPEED_CR_TYPE,a.OPR_DATE,a.ENTRY_LOC,a.OPR_DATE,
		a.REMARK,@REFACC_NO REFACC_NO,a.REMARK,a.DEBIT_CREDIT,
		b.CUSTOMER_REF , 
		a.DS_CODE ,
		1  ,''Chq:''+ a.CHECK_NUMBER +''  '' + e.BANK_NAME +space(2)+ '' '' + d.BRANCH_NAME ADD_TEXT,@VALUE_TYPE
	FROM CLEARINGTAB a,CHECKTOTAL b, CLEARING_CLIENT c, CLEARING_BRANCH d ,CLEARING_BANK e                    
	WHERE
		a.MID=b.MID AND b.[STATUS]=''L''
		AND a.DS_CODE=b.DS_CODE AND a.ENTRY_LOC=b.ENTRY_LOC AND a.OPR_DATE=b.OPR_DATE
		AND a.VALUE_TYPE=@VALUE_TYPE
		AND a.DEBIT_CREDIT>0
		AND a.OPR_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC   
		AND c.ACC_NO=a.REMARK                        
		AND a.FLEX_FILENAME IS NULL                                  
		AND c.SPEED_CR_TYPE=''B''        
		AND a.NIKBRANCH_CODE=d.NIKBRANCH_CODE        
		AND d.BANK_CODE=e.BANK_CODE 

	UNION ALL

------By DepositRef
	SELECT c.SPEED_CR_TYPE,a.OPR_DATE valueDate,a.ENTRY_LOC,a.OPR_DATE,
		c.ACC_NO ,@REFACC_NO REFACC_NO,a.REMARK,sum(a.DEBIT_CREDIT) as total,
		a.DS_CODE ,
		b.CUSTOMER_REF,
		count(a.REMARK),'''' Add_text,@VALUE_TYPE
	FROM CLEARINGTAB a, CLEARING_CLIENT c  , checktotal  b
	WHERE
		a.MID=b.MID AND b.[STATUS]=''L''
		AND a.DS_CODE=b.DS_CODE AND a.ENTRY_LOC=b.ENTRY_LOC AND a.OPR_DATE=b.OPR_DATE
		AND a.VALUE_TYPE=@VALUE_TYPE
		AND a.DEBIT_CREDIT>0
		AND a.OPR_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC
		AND a.REMARK=c.ACC_NO
		AND a.FLEX_FILENAME IS NULL		
		AND c.SPEED_CR_TYPE=''DR''
	GROUP BY a.OPR_DATE,a.ENTRY_LOC,c.SPEED_CR_TYPE,
		c.ACC_NO ,a.REMARK,a.DS_CODE ,b.CUSTOMER_REF
         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClient_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Apr-13
-- Description:	Get detail to Clearing_Client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClient_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM CLEARING_CLIENT_HIST 
				WHERE IS_AUTH=0			
				ORDER BY ACC_NO;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CLEARING_CLIENT
						WHERE [STATUS] =''L''					
						ORDER BY ACC_NO;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CLEARING_CLIENT
						WHERE [STATUS] in (''L'',''D'')					
						ORDER BY ACC_NO;
				END;
		END;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_ClearingDataFinalUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Apr-13
-- Description: Update Clearing Data Final
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_ClearingDataFinalUpdate]
	@REV_DATE		datetime,	
	@ENTRY_LOC		varchar(3),
	@VALUE_TYPE		numeric(1,0),
	@FLEX_FILENAME	varchar(15)
AS
BEGIN

	UPDATE CLEARINGTAB 
		SET FLEX_FILENAME=@FLEX_FILENAME
	WHERE FLEX_FILENAME IS NULL 
		AND OPR_DATE<=@REV_DATE AND ENTRY_LOC=@ENTRY_LOC
		AND VALUE_TYPE=@VALUE_TYPE;

	UPDATE TMP_REVERSAL_CLEARING
		SET FLEX_FILENAME=@FLEX_FILENAME,
			USERID=substring(suser_name(),charindex(''\'',suser_name())+1,20)
	WHERE FLEX_FILENAME IS NULL 
		AND REV_DATE<=@REV_DATE AND ENTRY_LOC=@ENTRY_LOC
		AND VALUE_TYPE=@VALUE_TYPE;

	INSERT INTO REVERSAL_HIST_CLEARING
		SELECT * FROM TMP_REVERSAL_CLEARING
			WHERE FLEX_FILENAME IS NOT NULL 
			AND REV_DATE<=@REV_DATE AND ENTRY_LOC=@ENTRY_LOC
			AND VALUE_TYPE=@VALUE_TYPE;

	DELETE FROM TMP_REVERSAL_CLEARING
		WHERE FLEX_FILENAME IS NOT NULL 
			AND REV_DATE<=@REV_DATE AND ENTRY_LOC=@ENTRY_LOC
			AND VALUE_TYPE=@VALUE_TYPE;

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpReversalClearing_GetFlexDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Apr-13
-- Description: Get detail for flex from tmp_reversal_clearing
-- =============================================

CREATE PROCEDURE [dbo].[CMS_TmpReversalClearing_GetFlexDetail]
	@REV_DATE	datetime,	
	@ENTRY_LOC	varchar(3),
	@VALUE_TYPE	numeric(1,0)
AS
BEGIN

	SELECT REV_DATE,SUM(AMOUNT)as CREDTOTAL,
		COUNT(REFACC_NO) TOTCHECK,REFACC_NO
	FROM TMP_REVERSAL_CLEARING 
	WHERE REV_DATE<=@REV_DATE AND ENTRY_LOC=@ENTRY_LOC
		AND VALUE_TYPE=@VALUE_TYPE
	GROUP BY REV_DATE, REFACC_NO
		         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpReversalClearing_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Apr-13
-- Description: Get detail of tmp_reversal_clearing
-- =============================================

CREATE PROCEDURE [dbo].[CMS_TmpReversalClearing_GetDetail]
	@REV_DATE	datetime,	
	@ENTRY_LOC	varchar(3),
	@VALUE_TYPE	numeric(1,0)
AS
BEGIN	
	
	SELECT a.*,ISNULL(b.CUSTOMER_REF,'''') CUSTOMER_REF
	FROM TMP_REVERSAL_CLEARING a
	LEFT OUTER JOIN 
	(SELECT DS_CODE,ENTRY_LOC,OPR_DATE,CUSTOMER_REF FROM CHECKTOTAL WHERE [STATUS]=''L'') b 
		ON a.DS_CODE=b.DS_CODE AND a.ENTRY_LOC=b.ENTRY_LOC
		AND a.REV_DATE=b.OPR_DATE
	WHERE a.REV_DATE=@REV_DATE AND a.ENTRY_LOC=@ENTRY_LOC
		AND a.VALUE_TYPE=@VALUE_TYPE
	ORDER BY a.ACC_NO,a.DS_CODE asc
	         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TranStatus_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-13
-- Description:	get list records of tran_status table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TranStatus_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT STATUS_ID,STATUS_NAME FROM TRAN_STATUS;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_FunFormPermission]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Md.Fahad Khan
-- Create date: 08-01-13
-- Description:	User Form Permission table
--				by USER_ID
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_FunFormPermission]	
	@USERS_ID	varchar(20),
    @FORMS_NAME varchar(60)
AS
BEGIN	
    Declare @FG_SLNO numeric(6,0)
	SET NOCOUNT ON;
    CREATE TABLE #Temp 
	(
        FG_SLNO numeric(6,0),
        FORMS_NAME varchar(60),
		IS_SHOW bit,
		IS_NEW bit,
        IS_UNLOCK bit,
        IS_AUTHORIZER bit,
        IS_DELETE bit,
        IS_SAVE bit
       
	)
        DECLARE tempRows CURSOR FOR

            SELECT FG_SLNO FROM USERS_FG_DET
                   WHERE USERS_ID=@USERS_ID
 
        OPEN tempRows

        FETCH NEXT FROM tempRows

                   INTO @FG_SLNO
 

        WHILE @@FETCH_STATUS = 0

		   BEGIN
       
             BEGIN                

     		INSERT INTO #Temp(FG_SLNO,FORMS_NAME,IS_SHOW,IS_NEW,IS_UNLOCK,IS_AUTHORIZER,IS_DELETE,IS_SAVE)
				SELECT pf.FG_SLNO,f.FORMS_NAME,pf.IS_SHOW,pf.IS_NEW,pf.IS_UNLOCK,
                       pf.IS_AUTHORIZER,pf.IS_DELETE,pf.IS_SAVE
                       FROM PERM_FORMS pf
                       LEFT JOIN FORM_LIST f ON f.SLNO = pf.FORM_SLNO
					WHERE pf.FG_SLNO=@FG_SLNO AND f.FORMS_NAME =@FORMS_NAME 

				     
             END

			 FETCH NEXT FROM tempRows

					INTO @FG_SLNO 
            
		 END

     CLOSE tempRows
     
     DEALLOCATE tempRows

      SELECT t1.FORMS_NAME,
       IS_SHOW =REPLACE( (SELECT IS_SHOW AS [data()]
           FROM #Temp t2
           WHERE t2.FORMS_NAME = t1.FORMS_NAME
           ORDER BY FORMS_NAME
           FOR XML PATH('''')), '' '', '',''),
       IS_NEW =REPLACE( (SELECT IS_NEW AS [data()]
           FROM #Temp t2
           WHERE t2.FORMS_NAME = t1.FORMS_NAME
           ORDER BY FORMS_NAME
           FOR XML PATH('''')), '' '', '',''),
       IS_UNLOCK =REPLACE( (SELECT IS_UNLOCK AS [data()]
           FROM #Temp t2
           WHERE t2.FORMS_NAME = t1.FORMS_NAME
           ORDER BY FORMS_NAME
           FOR XML PATH('''')), '' '', '',''),
       IS_AUTHORIZER =REPLACE( (SELECT IS_AUTHORIZER AS [data()]
           FROM #Temp t2
           WHERE t2.FORMS_NAME = t1.FORMS_NAME
           ORDER BY FORMS_NAME
           FOR XML PATH('''')), '' '', '',''),
       IS_DELETE =REPLACE( (SELECT IS_DELETE AS [data()]
           FROM #Temp t2
           WHERE t2.FORMS_NAME = t1.FORMS_NAME
           ORDER BY FORMS_NAME
           FOR XML PATH('''')), '' '', '',''),
       IS_SAVE =REPLACE( (SELECT IS_SAVE AS [data()]
           FROM #Temp t2
           WHERE t2.FORMS_NAME = t1.FORMS_NAME
           ORDER BY FORMS_NAME
           FOR XML PATH('''')), '' '', '','')

      FROM #Temp t1
      GROUP BY FORMS_NAME ;
             
            
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_FunMenuPermission]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Md.Fahad Khan
-- Create date: 31-DEC-12
-- Description:	User Menu Permission table
--				by USER_ID
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_FunMenuPermission]	
	@USERS_ID	varchar(20)
AS
BEGIN	

	Declare @FG_SLNO numeric(6,0)
    Declare @IS_VISIBLE bit 
    Declare @IS_ENABLE bit
    Declare @MENU_NAME varchar(60) 
	SET NOCOUNT ON;
    CREATE TABLE #Temp 
	(
        FG_SLNO numeric(6,0),
        MENU_NAME varchar(60),
		IS_VISIBLE bit,
		IS_ENABLE bit
       
	)
    

     DECLARE tempRows CURSOR FOR

            SELECT FG_SLNO FROM USERS_FG_DET
                   WHERE USERS_ID=@USERS_ID 

     
     OPEN tempRows

     FETCH NEXT FROM tempRows

            INTO @FG_SLNO
 

     WHILE @@FETCH_STATUS = 0

		 BEGIN
       
           BEGIN                

			INSERT INTO #Temp(FG_SLNO,MENU_NAME,IS_VISIBLE,IS_ENABLE)
				SELECT pm.FG_SLNO,m.MENU_NAME,pm.IS_VISIBLE,pm.IS_ENABLE
					FROM PERM_MENUS pm
					LEFT JOIN MENU_LIST m ON m.SLNO=pm.MENU_SLNO
					WHERE pm.FG_SLNO=@FG_SLNO
				     
           END

			 FETCH NEXT FROM tempRows

					INTO @FG_SLNO 
            
		 END

     CLOSE tempRows
     
     DEALLOCATE tempRows


     SELECT t1.MENU_NAME,
       IS_VISIBLE =REPLACE( (SELECT IS_VISIBLE AS [data()]
           FROM #Temp t2
           WHERE t2.MENU_NAME = t1.MENU_NAME
           ORDER BY MENU_NAME
           FOR XML PATH('''')), '' '', '',''),
       IS_ENABLE =REPLACE( (SELECT IS_ENABLE AS [data()]
           FROM #Temp t2
           WHERE t2.MENU_NAME = t1.MENU_NAME
           ORDER BY MENU_NAME
           FOR XML PATH('''')), '' '', '','')
      FROM #Temp t1
      GROUP BY MENU_NAME ;
             
            
END














' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Add detail to CCheckTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckTotal_Add]	
	@D_CODE			varchar(12), 
	@TOTAL_CHKNO	numeric(4,0), 
	@TOTAL_CHKAMT	numeric(12,2)	
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT D_CODE FROM CCHECKTOTAL
				WHERE D_CODE=@D_CODE)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE CCHECKTOTAL_HIST WHERE 
		D_CODE=@D_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO CCHECKTOTAL_HIST(D_CODE, TOTAL_CHKNO,TOTAL_CHKAMT, 
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@D_CODE, @TOTAL_CHKNO,@TOTAL_CHKAMT, 		
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE CCHECK_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	Get detail of CCHECKTOTAL
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckTotal_GetDetail]	
	@D_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM CCHECKTOTAL WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CCHECKTOTAL 
			WHERE D_CODE=@D_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CCHECKTOTAL_HIST
			WHERE D_CODE=@D_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Jan-13
-- Description:	update detail to CCHECKTOTAL
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CCheckTotal_Update]	
	@D_CODE			varchar(12), 
	@TOTAL_CHKNO	numeric(4,0), 
	@TOTAL_CHKAMT	numeric(12,2),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT D_CODE FROM CCHECKTOTAL 
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CCHECKTOTAL_HIST(D_CODE, TOTAL_CHKNO,TOTAL_CHKAMT,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@D_CODE, @TOTAL_CHKNO,@TOTAL_CHKAMT,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE CCHECK_HIST
				WHERE D_CODE=@D_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT D_CODE from CCHECKTOTAL_HIST 
						WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CCHECKTOTAL_HIST WHERE D_CODE=@D_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO CCHECKTOTAL_HIST(D_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@D_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE CCHECK_HIST
						WHERE D_CODE=@D_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCheckTotal_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Mar-12
-- Description:	Get detail to CCheckTotal table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckTotal_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM CCHECKTOTAL_HIST 
				WHERE IS_AUTH=0
				ORDER BY D_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CCHECKTOTAL
						WHERE [STATUS] =''L''				
	
						ORDER BY D_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''            
        
							ELSE ''A''
						END 
						FROM CCHECKTOTAL
						WHERE [STATUS] IN (''L'',''D'')			
		
						ORDER BY D_CODE;
				END;
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFGDet_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Nov-12
-- Description:	Add detail to Users Functional Group
-- =============================================
CREATE PROCEDURE [dbo].[CMS_UsersFGDet_Add]	
	@USERS_ID		varchar(20),
	@FG_SLNO		numeric(6,0)	
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
			
	INSERT INTO USERS_FG_DET_HIST(USERS_ID,FG_SLNO, MOD_NO,IS_AUTH)
		VALUES(@USERS_ID,@FG_SLNO, 1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_UsersFGDet_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Nov-12
-- Description:	update detail to Users FG
-- =============================================

CREATE PROCEDURE [dbo].[CMS_UsersFGDet_Update]	
	@USERS_ID		varchar(20),
	@FG_SLNO		numeric(6,0),	
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO USERS_FG_DET_HIST(USERS_ID,FG_SLNO,
		MOD_NO, IS_AUTH)
		VALUES(@USERS_ID,@FG_SLNO,
		@MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnClearing_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Aug-13
-- Description:	Authorize record to RETURN_CLEARING
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnClearing_Auth]	
	@MID	numeric(10,0),
	@DSL	numeric(4,0)
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@RTN_CODE		varchar(2),		
			@INPUT_BY		varchar(20);			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT MID from RETURN_CLEARING 
			  WHERE MID=@MID AND DSL=@DSL)
		BEGIN
			SELECT @STATUS=[STATUS],@RTN_CODE=RTN_CODE,
				@INPUT_BY=INPUT_BY
				FROM RETURN_CLEARING 
				WHERE MID=@MID AND DSL=@DSL;
			IF (@STATUS = ''L'')
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			

		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;
	
	DELETE CHECKTOTAL_HIST WHERE MID=@MID AND IS_AUTH=0;
	DELETE CLEARINGTAB_HIST WHERE MID=@MID AND IS_AUTH=0;

	UPDATE CLEARINGTAB
		SET RTN_STATUS=''R'',RTN_CODE=@RTN_CODE,
			RETURN_DATE=CONVERT(datetime,CONVERT(varchar(12), GETDATE()))
		WHERE MID=@MID AND DSL=@DSL;

	UPDATE RETURN_CLEARING
		SET [STATUS]=''L'',
			AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
			AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME()
		WHERE MID=@MID AND DSL=@DSL;

	COMMIT TRANSACTION;

	RETURN 0;


    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetReturnMatch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Aug-13
-- Description:	Get detail of ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetReturnMatch]	
	@CHECK_NUMBER	varchar(15),
	@AMOUNT			numeric(14,2),
	@OPR_DATE		datetime	
AS
BEGIN	
	
	SET NOCOUNT ON;

	
		SELECT ct.*,
			br.BRANCH_NAME,
			b.BANK_CODE,b.BANK_NAME
			FROM CLEARINGTAB ct							
			LEFT OUTER JOIN CLEARING_BRANCH br
			ON br.NIKBRANCH_CODE=ct.NIKBRANCH_CODE
			LEFT OUTER JOIN CLEARING_BANK b
			ON b.BANK_CODE=br.BANK_CODE					
			WHERE ct.CHECK_NUMBER=@CHECK_NUMBER AND ct.DEBIT_CREDIT=@AMOUNT
			AND OPR_DATE=@OPR_DATE;	
		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnClearing_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Aug-13
-- Description:	Return Check add
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnClearing_Add]	
	@CHECK_NUMBER	varchar(15),
	@AMOUNT			numeric(14,2),
	@RTN_CODE		varchar(2),
	@OPR_DATE		datetime,
	@SEQ_NUMBER		varchar(50),
	@RET_MID		numeric(10,0) output,
	@RET_DSL		numeric(4,0) output	
AS
BEGIN	
	
	DECLARE
		@v_cnt	int;
	
		SELECT @v_cnt=COUNT(*)
			FROM CLEARINGTAB ct											
			WHERE ct.CHECK_NUMBER=@CHECK_NUMBER AND ct.DEBIT_CREDIT=@AMOUNT
			AND OPR_DATE=@OPR_DATE;
		
		IF @v_cnt=0
		BEGIN
			RETURN 4;			
		END

		IF @v_cnt>1
		BEGIN
			RETURN 1;			
		END

		SELECT @RET_MID=MID,@RET_DSL=DSL
			FROM CLEARINGTAB ct											
			WHERE ct.CHECK_NUMBER=@CHECK_NUMBER AND ct.DEBIT_CREDIT=@AMOUNT
			AND OPR_DATE=@OPR_DATE;
	
		INSERT INTO RETURN_CLEARING(MID, DSL, CHECK_NUMBER, AMOUNT, RTN_CODE, 
			OPR_DATE, SEQ_NUMBER,
			INPUT_BY, 
			INPUT_DATETIME, INPUT_FROM, [STATUS])
			VALUES(@RET_MID, @RET_DSL, @CHECK_NUMBER, @AMOUNT, @RTN_CODE, 
			@OPR_DATE,@SEQ_NUMBER,  
			substring(suser_name(),charindex(''\'',suser_name())+1,20),
			GETDATE(),HOST_NAME(), ''U'')

		RETURN 0;

		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Apr-13
-- Description:	Authorize record to CHECKTOTAL
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_Auth]	
	@MID			numeric(10,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@DS_CODE		varchar(8),
			@OPR_DATE		datetime,
			@ENTRY_LOC		varchar(3),
			@TOTAL_CHKNO	int, 
			@TOTAL_CHKAMT	numeric(14,2), 
			@CUSTOMER_REF	varchar(50),		
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT DS_CODE from CHECKTOTAL_HIST 
			  WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@DS_CODE=DS_CODE,@OPR_DATE=OPR_DATE,@ENTRY_LOC=ENTRY_LOC,
				@TOTAL_CHKNO=TOTAL_CHKNO, 
				@TOTAL_CHKAMT=TOTAL_CHKAMT,@CUSTOMER_REF=CUSTOMER_REF,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CHECKTOTAL_HIST 
				WHERE MID=@MID AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CHECKTOTAL_HIST(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
				OPR_DATE,CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, AUTH_DATETIME, AUTH_FROM, 
				MOD_NO, [STATUS], IS_AUTH)
				SELECT MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
				OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, AUTH_BY, AUTH_DATETIME, AUTH_FROM, 
				MOD_NO, [STATUS],1 FROM CHECKTOTAL
				WHERE MID=@MID;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CHECKTOTAL_HIST
				SET [STATUS] = ''O'' 
				WHERE MID=@MID
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CHECKTOTAL
				SET
				DS_CODE=@DS_CODE,OPR_DATE=@OPR_DATE,ENTRY_LOC=@ENTRY_LOC,
				TOTAL_CHKNO=@TOTAL_CHKNO,
				TOTAL_CHKAMT=@TOTAL_CHKAMT,CUSTOMER_REF=@CUSTOMER_REF, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE MID=@MID;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CHECKTOTAL_HIST WHERE MID=@MID
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN  
			INSERT INTO CHECKTOTAL(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
				CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS])
				SELECT MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
					CUSTOMER_REF, ENTRY_LOC,ENTRY_DATE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CHECKTOTAL_HIST
					WHERE MID=@MID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CHECKTOTAL_HIST WHERE MID=@MID
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update CLEARINGTAB

	INSERT INTO CLEARINGTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, RTN_STATUS, RTN_CODE, RETURN_DATE, CHECKED, 
		FLEX_FILENAME, IS_PDC, MOD_NO, IS_AUTH,VALUE_TYPE,IS_ROW_CHG)
		SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, RTN_STATUS, RTN_CODE, RETURN_DATE, CHECKED, 
		FLEX_FILENAME, IS_PDC, MOD_NO, 1,VALUE_TYPE,IS_ROW_CHG
		FROM CLEARINGTAB
		WHERE MID=@MID;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE CLEARINGTAB WHERE MID=@MID;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO CLEARINGTAB(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, RTN_STATUS, RTN_CODE, RETURN_DATE, CHECKED, 
		FLEX_FILENAME, IS_PDC, MOD_NO,VALUE_TYPE,IS_ROW_CHG)
		SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, RTN_STATUS, RTN_CODE, RETURN_DATE, CHECKED, 
		FLEX_FILENAME, IS_PDC, MOD_NO,VALUE_TYPE,IS_ROW_CHG
		FROM CLEARINGTAB_HIST 
		WHERE MID=@MID AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE CLEARINGTAB_HIST WHERE MID=@MID AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Apr-13
-- Description:	Remove record from CheckTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_Remove]
	@MID		numeric(10,0),
	@MOD_NO		int,	
	@RET_MOD_NO	int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@DS_CODE		varchar(8),
			@OPR_DATE		datetime,
			@ENTRY_LOC		varchar(3),
			@TOTAL_CHKNO	int, 
			@TOTAL_CHKAMT	numeric(14,2), 
			@CUSTOMER_REF	varchar(50),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@ENTRY_DATE		datetime;
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT DS_CODE from CHECKTOTAL
			  WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@DS_CODE=DS_CODE,@OPR_DATE=OPR_DATE,@ENTRY_LOC=ENTRY_LOC,
				@TOTAL_CHKNO=TOTAL_CHKNO,@TOTAL_CHKAMT=TOTAL_CHKAMT,
				@CUSTOMER_REF=CUSTOMER_REF,@ENTRY_DATE=ENTRY_DATE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CHECKTOTAL
				WHERE MID=@MID AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CHECKTOTAL_HIST WHERE MID=@MID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CHECKTOTAL_HIST (MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
				CUSTOMER_REF, ENTRY_LOC,ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@MID, @DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, @OPR_DATE, 
				@CUSTOMER_REF, @ENTRY_LOC, @ENTRY_DATE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE CLEARINGTAB_HIST
				WHERE MID=@MID AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO CLEARINGTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
				PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
				CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF,
				ENTRY_LOC, DS_CODE, RTN_STATUS, RTN_CODE, RETURN_DATE, 
				CHECKED, FLEX_FILENAME, IS_PDC, MOD_NO, IS_AUTH,VALUE_TYPE,IS_ROW_CHG)
				SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
				PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
				CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF,
				ENTRY_LOC, DS_CODE, RTN_STATUS, RTN_CODE, RETURN_DATE, 
				CHECKED, FLEX_FILENAME, IS_PDC, @RET_MOD_NO, 0,VALUE_TYPE,IS_ROW_CHG
				FROM CLEARINGTAB
				WHERE MID=@MID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT DS_CODE from CHECKTOTAL_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CHECKTOTAL_HIST
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE CLEARINGTAB_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_PDCTransfer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Jul-13
-- Description: Process for PDC Transfer
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_PDCTransfer]
	@OPR_DATE	datetime,
	@ENTRY_LOC	varchar(3)	
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE 
		@v_MID		numeric(10,0);
	

	DECLARE tmpcursor1 CURSOR FOR
		SELECT MID
			FROM PDCTotal 
			WHERE OPR_DATE=@OPR_DATE AND ENTRY_LOC=@ENTRY_LOC
			AND (PDC_TRANS IS NULL OR PDC_TRANS=0) AND [STATUS]=''L'';

	OPEN tmpcursor1;
	FETCH NEXT FROM tmpcursor1 
        INTO @v_MID;

	WHILE @@FETCH_STATUS=0 
 	BEGIN

		INSERT INTO CHECKTOTAL(MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
			CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
			INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
			AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS])
			SELECT MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
			CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
			INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
			AUTH_BY, AUTH_DATETIME, AUTH_FROM, 1, [STATUS]
			FROM PDCTOTAL
			WHERE MID=@v_MID;


		INSERT INTO CLEARINGTAB(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, PAYEE_NAME, 
			CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, ACC_NO, 
			DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 
			RTN_STATUS, IS_PDC,	MOD_NO, VALUE_TYPE)
			SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, PAYEE_NAME, 
			CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, ACC_NO, 
			DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 
			''O'', 1,1, VALUE_TYPE
			FROM PDCTAB
			WHERE MID=@v_MID;

		UPDATE PDCTOTAL SET PDC_TRANS=1
			WHERE MID=@v_MID;		

		FETCH NEXT FROM tmpcursor1 
			INTO @v_MID;

	END

	CLOSE tmpcursor1;	
	DEALLOCATE tmpcursor1;


	RETURN 0;
	
    
END   

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetTotalCheck]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 22-Sep-13
-- Description:	Get total check count of ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetTotalCheck]		
	@OPR_DATE	datetime,
	@ENTRY_LOC	varchar(3),
	@VALUE_TYPE	numeric(1,0)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT a.OPR_DATE, COUNT(CHECK_NUMBER) TOTCHECK 
	FROM CLEARINGTAB a
	INNER JOIN CHECKTOTAL b ON a.MID=b.MID
	WHERE b.[STATUS]=''L'' AND a.OPR_DATE=@OPR_DATE
	AND a.ENTRY_LOC=@ENTRY_LOC AND a.VALUE_TYPE=@VALUE_TYPE
	GROUP by a.OPR_DATE
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetReturnOutstanding]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Aug-13
-- Description:	Get return outstanding of ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetReturnOutstanding]		
	@OPR_DATE	datetime,
	@ENTRY_LOC	varchar(3)	
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT * 
		FROM CLEARINGTAB ct
		INNER JOIN RETURN_CLEARING rc
		ON ct.MID=rc.MID AND ct.DSL=rc.DSL
		WHERE rc.RTN_FILENAME IS NULL
		AND ct.OPR_DATE <=@OPR_DATE AND ct.ENTRY_LOC=@ENTRY_LOC
		ORDER BY ct.OPR_DATE,ct.DS_CODE,ct.CHECK_NUMBER
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_GetFlexReturn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Aug-13
-- Description: Get detail for clearing return flexfile
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClearingTab_GetFlexReturn]
	@OPR_DATE	datetime,	
	@ENTRY_LOC	varchar(3)
AS
BEGIN

	SELECT rc.OPR_DATE,SUM(rc.AMOUNT) AS AMOUNT, COUNT(rc.CHECK_NUMBER) AS TOTCHECK
		FROM CLEARINGTAB ct
		INNER JOIN RETURN_CLEARING rc
		ON ct.MID=rc.MID AND ct.DSL=rc.DSL
		WHERE rc.OPR_DATE<=@OPR_DATE AND ct.ENTRY_LOC=@ENTRY_LOC
		AND rc.RTN_FILENAME IS NULL
		GROUP BY rc.OPR_DATE

			         
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_GetDetailByNikBranch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	Get detail of clearing_branch by NikBranch code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_GetDetailByNikBranch]	
	@NIKBRANCH_CODE		varchar(7)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT br.*,b.BANK_NAME FROM CLEARING_BRANCH br
		LEFT OUTER JOIN CLEARING_BANK b
		ON b.BANK_CODE=br.BANK_CODE
		WHERE NIKBRANCH_CODE=@NIKBRANCH_CODE;
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_GetDetailByRouting]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Aug-13
-- Description:	Get detail of clearing_branch by Routing No
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_GetDetailByRouting]	
	@ROUTING_NO	varchar(9)
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT br.*,b.BANK_NAME FROM CLEARING_BRANCH br
		LEFT OUTER JOIN CLEARING_BANK b
		ON b.BANK_CODE=br.BANK_CODE
		WHERE ROUTING_NO=@ROUTING_NO;

	
 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get detail of clearing_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_GetDetail]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT BRANCH_CODE 
				FROM CLEARING_BRANCH WHERE BANK_CODE=@BANK_CODE 
				AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 ,CLEARING_BANK.BANK_NAME,CLEARING_LOCATION.LOCATION_NAME
			FROM CLEARING_BRANCH br
			LEFT OUTER JOIN CLEARING_BANK ON CLEARING_BANK.BANK_CODE=br.BANK_CODE
			LEFT OUTER JOIN CLEARING_LOCATION ON CLEARING_LOCATION.LOCATION_CODE=br.LOCATION_CODE			
			WHERE br.BANK_CODE=@BANK_CODE
			AND br.BRANCH_CODE=@BRANCH_CODE AND br.MOD_NO=@MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * ,CLEARING_BANK.BANK_NAME,CLEARING_LOCATION.LOCATION_NAME
			FROM CLEARING_BRANCH_HIST brh
			LEFT OUTER JOIN CLEARING_BANK ON CLEARING_BANK.BANK_CODE=brh.BANK_CODE
			LEFT OUTER JOIN CLEARING_LOCATION ON CLEARING_LOCATION.LOCATION_CODE=brh.LOCATION_CODE			
			WHERE brh.BANK_CODE=@BANK_CODE
			AND brh.BRANCH_CODE=@BRANCH_CODE AND brh.MOD_NO=@MOD_NO
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get detail of clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_GetDetailByCode]	
	@BANK_CODE		varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM CLEARING_BANK 
	WHERE BANK_CODE=@BANK_CODE
 
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	get list records of clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT BANK_CODE,BANK_NAME FROM CLEARING_BANK WHERE STATUS=''L''
	ORDER BY BANK_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Get detail to Clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM CLEARING_BANK_HIST 
				WHERE IS_AUTH=0
				ORDER BY BANK_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CLEARING_BANK
						WHERE [STATUS] =''L''					
						ORDER BY BANK_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CLEARING_BANK
						WHERE [STATUS] IN (''L'',''D'')					
						ORDER BY BANK_CODE;
				END;
		END;	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Get Total # of modification of Clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_GetMaxMod]	
	@BANK_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLEARING_BANK_HIST 
		WHERE BANK_CODE=@BANK_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLEARING_BANK 
				WHERE BANK_CODE=@BANK_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Remove record from clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_Remove]	
	@BANK_CODE		varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BANK_NAME 		varchar(100),
			@HEAD_ADD1 		varchar(35),
			@HEAD_ADD2 		varchar(35),
			@HEAD_ADD3		varchar(20),
			@BANK_BBK_CODE	varchar(9),
			@ACC_NO			varchar(16),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BANK_CODE from CLEARING_BANK
			  WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BANK_NAME=BANK_NAME,
				@HEAD_ADD1=HEAD_ADD1,@HEAD_ADD2=HEAD_ADD2,
				@HEAD_ADD3=HEAD_ADD3,@BANK_BBK_CODE=BANK_BBK_CODE,@ACC_NO=ACC_NO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLEARING_BANK
				WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLEARING_BANK_HIST WHERE BANK_CODE=@BANK_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLEARING_BANK_HIST (BANK_CODE, BANK_NAME, HEAD_ADD1, HEAD_ADD2, HEAD_ADD3, 
				BANK_BBK_CODE, ACC_NO,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BANK_CODE, @BANK_NAME, @HEAD_ADD1, @HEAD_ADD2, @HEAD_ADD3, 
				@BANK_BBK_CODE, @ACC_NO,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT BANK_CODE from CLEARING_BANK_HIST 
					  WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLEARING_BANK_HIST
						WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Get detail of clearing bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_GetDetail]	
	@BANK_CODE		varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT BANK_CODE 
			   FROM CLEARING_BANK WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CLEARING_BANK 
			WHERE BANK_CODE=@BANK_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CLEARING_BANK_HIST
			WHERE BANK_CODE=@BANK_CODE AND MOD_NO = @MOD_NO
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Add detail to clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_Add]	
	@BANK_CODE		varchar(4),
	@BANK_NAME 		varchar(100),
	@HEAD_ADD1 		varchar(35),
	@HEAD_ADD2 		varchar(35),
	@HEAD_ADD3		varchar(35),
	@BANK_BBK_CODE	varchar(9),
	@ACC_NO			varchar(16)		
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BANK_CODE from CLEARING_BANK WHERE BANK_CODE=@BANK_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CLEARING_BANK_HIST WHERE 
		BANK_CODE=@BANK_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CLEARING_BANK_HIST(BANK_CODE, BANK_NAME,	HEAD_ADD1,HEAD_ADD2,HEAD_ADD3,
		BANK_BBK_CODE,ACC_NO,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
		@BANK_BBK_CODE,@ACC_NO,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBank_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 31-Mar-13
-- Description:	Authorize record to clearing_bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBank_Auth]	
	@BANK_CODE		varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BANK_NAME 		varchar(100),
			@HEAD_ADD1 		varchar(35),
			@HEAD_ADD2 		varchar(35),
			@HEAD_ADD3		varchar(35),
			@BANK_BBK_CODE	varchar(9),
			@ACC_NO			varchar(16),	
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BANK_CODE from CLEARING_BANK_HIST 
			  WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BANK_NAME=BANK_NAME,
				@HEAD_ADD1=HEAD_ADD1,@HEAD_ADD2=HEAD_ADD2,
				@HEAD_ADD3=HEAD_ADD3,@BANK_BBK_CODE=BANK_BBK_CODE,@ACC_NO=ACC_NO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLEARING_BANK_HIST 
				WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLEARING_BANK_HIST 
				SELECT *,1 FROM CLEARING_BANK
				WHERE BANK_CODE=@BANK_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLEARING_BANK_HIST
				SET [STATUS] = ''O'' 
				WHERE BANK_CODE=@BANK_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLEARING_BANK
				SET BANK_NAME=@BANK_NAME,
				HEAD_ADD1=@HEAD_ADD1,HEAD_ADD2=@HEAD_ADD2,
				HEAD_ADD3=@HEAD_ADD3,BANK_BBK_CODE=@BANK_BBK_CODE,ACC_NO=@ACC_NO,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE BANK_CODE=@BANK_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLEARING_BANK_HIST WHERE BANK_CODE=@BANK_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLEARING_BANK
				SELECT BANK_CODE, BANK_NAME, HEAD_ADD1, HEAD_ADD2, HEAD_ADD3, 
					BANK_BBK_CODE,ACC_NO, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLEARING_BANK_HIST
					WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLEARING_BANK_HIST WHERE BANK_CODE=@BANK_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	update detail to CheckTotal
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CheckTotal_Update]
	@MID			numeric(10,0),
	@DS_CODE		varchar(8), 
	@TOTAL_CHKNO	int, 
	@TOTAL_CHKAMT	numeric(14,2), 
	@OPR_DATE		datetime, 
	@CUSTOMER_REF	varchar(50), 
	@ENTRY_LOC		varchar(3),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	DECLARE @ENTRY_DATE datetime;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT DS_CODE FROM CHECKTOTAL 
				WHERE  MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN

			SELECT @ENTRY_DATE=ENTRY_DATE FROM CHECKTOTAL 
				WHERE MID=@MID AND MOD_NO=@MOD_NO;

			DELETE CHECKTOTAL_HIST WHERE MID=@MID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CHECKTOTAL_HIST(MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
				OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@MID,@DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, 
				@OPR_DATE, @CUSTOMER_REF, @ENTRY_LOC, @ENTRY_DATE, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE CLEARINGTAB_HIST
				WHERE MID=@MID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT DS_CODE from CHECKTOTAL_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					SELECT @ENTRY_DATE=ENTRY_DATE FROM CHECKTOTAL_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					DELETE CHECKTOTAL_HIST WHERE 
						MID=@MID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO CHECKTOTAL_HIST(MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
						OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@MID,@DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, 
						@OPR_DATE, @CUSTOMER_REF, @ENTRY_LOC, @ENTRY_DATE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE CLEARINGTAB_HIST
						WHERE MID=@MID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	update detail to ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_Update]
	@MID			numeric(10,0),
	@DSL			numeric(4,0),		
	@OPR_DATE		datetime, 
	@ISSUE_DATE		datetime, 
	@NIKBRANCH_CODE	varchar(7), 
	@PAYEE_NAME		varchar(40), 
	@CHECK_SERIES	varchar(4), 
	@CHECK_NUMBER	varchar(15), 
	@CHECK_NO		varchar(8), 
	@BOOK_NO		varchar(8), 
	@CHECK_TYPE		varchar(8), 
	@ACC_NO			varchar(15), 
	@DEBIT_CREDIT	numeric(14,2), 
	@REMARK			varchar(15), 
	@BATCH_NO		varchar(8), 
	@CHECK_REF		varchar(40), 
	@ENTRY_LOC		varchar(3), 
	@DS_CODE		varchar(8),
	@RTN_STATUS		char(1), 
	@RTN_CODE		varchar(2), 
	@RETURN_DATE	datetime, 
	@CHECKED		tinyint, 
	@FLEX_FILENAME	varchar(15), 
	@IS_PDC			bit,
	@VALUE_TYPE		numeric(1,0), 
	@IS_ROW_CHG		bit,
	@MOD_NO			numeric(3,0) 
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CLEARINGTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, PAYEE_NAME, 
		CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, ACC_NO, 
		DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 
		RTN_STATUS, RTN_CODE, RETURN_DATE, CHECKED, FLEX_FILENAME, IS_PDC,
		MOD_NO,IS_AUTH,VALUE_TYPE,IS_ROW_CHG)
		VALUES(@MID,@DSL,@OPR_DATE, @ISSUE_DATE, @NIKBRANCH_CODE, @PAYEE_NAME, 
		@CHECK_SERIES, @CHECK_NUMBER, @CHECK_NO, @BOOK_NO, @CHECK_TYPE, @ACC_NO, 
		@DEBIT_CREDIT, @REMARK, @BATCH_NO, @CHECK_REF, @ENTRY_LOC, @DS_CODE, 
		@RTN_STATUS, @RTN_CODE, @RETURN_DATE, @CHECKED, @FLEX_FILENAME, @IS_PDC,
		@MOD_NO,0,@VALUE_TYPE,@IS_ROW_CHG);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingTab_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	Add detail to ClearingTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingTab_Add]	
	@MID			numeric(10,0),
	@DSL			numeric(4,0),	
	@OPR_DATE		datetime, 
	@ISSUE_DATE		datetime, 
	@NIKBRANCH_CODE	varchar(7), 
	@PAYEE_NAME		varchar(40), 
	@CHECK_SERIES	varchar(4), 
	@CHECK_NUMBER	varchar(15), 
	@CHECK_NO		varchar(8), 
	@BOOK_NO		varchar(8), 
	@CHECK_TYPE		varchar(8), 
	@ACC_NO			varchar(15), 
	@DEBIT_CREDIT	numeric(14,2), 
	@REMARK			varchar(15), 
	@BATCH_NO		varchar(8), 
	@CHECK_REF		varchar(40), 
	@ENTRY_LOC		varchar(3), 
	@DS_CODE		varchar(8),
	@VALUE_TYPE		numeric(1,0),
	@IS_ROW_CHG		bit
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CLEARINGTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, PAYEE_NAME, 
		CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, ACC_NO, 
		DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 
		RTN_STATUS, IS_PDC,
		MOD_NO,IS_AUTH,VALUE_TYPE,IS_ROW_CHG)
		VALUES(@MID,@DSL,@OPR_DATE, @ISSUE_DATE, @NIKBRANCH_CODE, @PAYEE_NAME, 
		@CHECK_SERIES, @CHECK_NUMBER, @CHECK_NO, @BOOK_NO, @CHECK_TYPE, @ACC_NO, 
		@DEBIT_CREDIT, @REMARK, @BATCH_NO, @CHECK_REF, @ENTRY_LOC, @DS_CODE, 
		''O'', 0,
		1,0,@VALUE_TYPE,@IS_ROW_CHG);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Outstanding_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-12
-- Description:	auth reversal outstanding items
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Outstanding_Auth]	
	@D_CODE		varchar(12),	
	@REV_DATE	datetime,
	@REF_NO		varchar(10)			
AS
BEGIN	
	DECLARE @ErrorVar	int,
			@USERID		varchar(20),
			@AUTHORIZE	tinyint;
	
	SET NOCOUNT ON;
	
	SELECT @USERID=USERID,@AUTHORIZE=AUTHORIZE
		FROM  CCMSREF_TAB		
		WHERE D_CODE=@D_CODE AND REV_DATE=@REV_DATE AND REF_NO=@REF_NO;

	IF (@USERID = substring(suser_name(),charindex(''\'',suser_name())+1,20))
		BEGIN
			-- maker and checker same person			
			RETURN 5;
		END;

	IF (@AUTHORIZE = 1)
		BEGIN
			-- already authorized			
			RETURN 3;
		END;

	UPDATE CCMSREF_TAB
		SET AUTHORIZE=1,
		AUTHORIZER_ID=substring(suser_name(),charindex(''\'',suser_name())+1,20)
		WHERE D_CODE=@D_CODE AND REV_DATE=@REV_DATE AND REF_NO=@REF_NO;

	RETURN 0;
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Outstanding_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-12
-- Description:	get reversal outstanding items
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Outstanding_Update]	
	@D_CODE		varchar(12),
	@STATUS_ID	tinyint,
	@REMARKS	varchar(100),
	@REV_DATE	datetime			
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;
	
	UPDATE CCMSREF_TAB
		SET STATUS_ID=@STATUS_ID,REMARKS=@REMARKS,AUTHORIZE=0,
		USERID=substring(suser_name(),charindex(''\'',suser_name())+1,20)
		WHERE D_CODE=@D_CODE AND REV_DATE=@REV_DATE
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CCMSRefTab_GetReversalData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-May-13
-- Description:	Get reversal data from CCMSRef_tab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCMSRefTab_GetReversalData]		
	@REV_DATE	datetime
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT a.*,'''' as ACC_NAME 
	FROM CCMSREF_TAB a 	
	WHERE [FILENAME] IS NULL and REV_DATE<=@REV_DATE 
	ORDER BY REV_DATE asc
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Aug-13
-- Description:	Get detail of CHECKTOTAL by code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_GetDetailByCode]	
	@DS_CODE	varchar(8),
	@OPR_DATE	datetime,
	@ENTRY_LOC	varchar(3)
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
				FROM CHECKTOTAL 
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC)
		BEGIN
			SELECT *,''IS_AUTH''=1 
				FROM CHECKTOTAL 
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC;
		END	
	ELSE
		BEGIN
			SELECT * 
				FROM CHECKTOTAL_HIST
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC AND IS_AUTH=0;
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Apr-13
-- Description:	Get detail of CHECKTOTAL
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_GetDetail]	
	@MID		numeric(10,0),
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
				FROM CHECKTOTAL 
				WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
				FROM CHECKTOTAL 
				WHERE MID=@MID AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
				FROM CHECKTOTAL_HIST
				WHERE MID=@MID AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CheckTotal_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Apr-13
-- Description:	Get Total # of modification of CheckTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckTotal_GetMaxMod]
	@MID	numeric(10,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CHECKTOTAL_HIST 
		WHERE MID=@MID AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CHECKTOTAL
				WHERE MID=@MID;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpReversal_GetFlexDrDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-13
-- Description:	Get detail of TMP_Reversal Debit Flex Data
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TmpReversal_GetFlexDrDetail]	
	@REV_DATE	datetime
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT REV_DATE,DEPOSIT_TYPE,sum(AMOUNT)as credtotal,
		REF_NO, REFACC_NO 
		FROM TMP_REVERSAL
		WHERE REV_DATE<=@REV_DATE 
		GROUP BY  REV_DATE,REF_NO,REFACC_NO,DEPOSIT_TYPE

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TmpReversal_GetListInvDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-May-13
-- Description:	Get invalid dscode entry of TMP_Reversal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TmpReversal_GetListInvDs]	
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM TMP_REVERSAL 
		WHERE DS_CODE IS NULL;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClientCharge_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Apr-13
-- Description:	Add detail to ClearingClientCharge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClientCharge_Add]		
	@ACC_NO			varchar(15),
	@SLNO			numeric(2,0),
	@VALUE_TYPE		numeric(1,0), 
	@MIN_AMOUNT		numeric(14,2), 
	@MAX_AMOUNT		numeric(14,2), 
	@BACH_CHARGE	numeric(8,2), 
	@BANK_CHARGE	numeric(8,2)	
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CLEARING_CLIENT_CHARGE_HIST(ACC_NO, SLNO, VALUE_TYPE, 
		MIN_AMOUNT, MAX_AMOUNT, 
		BACH_CHARGE, BANK_CHARGE, MOD_NO,IS_AUTH)
		VALUES(@ACC_NO, @SLNO, @VALUE_TYPE, 
		@MIN_AMOUNT, @MAX_AMOUNT, 
		@BACH_CHARGE, @BANK_CHARGE, 1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingClientCharge_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Apr-13
-- Description:	update detail to ClearingClientCharge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingClientCharge_Update]
	@ACC_NO			varchar(15),
	@SLNO			numeric(2,0),
	@VALUE_TYPE		numeric(1,0), 
	@MIN_AMOUNT		numeric(14,2), 
	@MAX_AMOUNT		numeric(14,2), 
	@BACH_CHARGE	numeric(8,2), 
	@BANK_CHARGE	numeric(8,2),
	@MOD_NO			numeric(3,0)
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CLEARING_CLIENT_CHARGE_HIST(ACC_NO, SLNO, VALUE_TYPE, 
		MIN_AMOUNT, MAX_AMOUNT, 
		BACH_CHARGE, BANK_CHARGE, MOD_NO,IS_AUTH)
		VALUES(@ACC_NO, @SLNO, @VALUE_TYPE, 
		@MIN_AMOUNT, @MAX_AMOUNT, 
		@BACH_CHARGE, @BANK_CHARGE, @MOD_NO,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get detail of Clearing_location table by location code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_GetDetailByCode]	
	@LOCATION_CODE		varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM CLEARING_LOCATION 
	WHERE LOCATION_CODE=@LOCATION_CODE
 
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	get detail from Clearing_Location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM CLEARING_LOCATION_HIST 
				WHERE IS_AUTH=0			
				ORDER BY IS_AUTH,LOCATION_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CLEARING_LOCATION
						WHERE STATUS =''L''					
						ORDER BY LOCATION_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CLEARING_LOCATION
						WHERE STATUS in (''L'',''D'')					
						ORDER BY LOCATION_CODE
				END;
		END;
	   
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	get list records of Clearing_location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT LOCATION_CODE,LOCATION_NAME FROM CLEARING_LOCATION WHERE STATUS=''L''
	ORDER BY LOCATION_NAME;
	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get Total # of modification of Clearing_location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_GetMaxMod]	
	@LOCATION_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLEARING_LOCATION_HIST 
		WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLEARING_LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Add detail to Clearing_Location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_Add]	
	@LOCATION_CODE		varchar(4),
	@LOCATION_NAME 		varchar(35)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT LOCATION_CODE FROM CLEARING_LOCATION WHERE LOCATION_CODE=@LOCATION_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CLEARING_LOCATION_HIST WHERE 
		LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CLEARING_LOCATION_HIST(LOCATION_CODE, LOCATION_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@LOCATION_CODE, @LOCATION_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get detail of location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_GetDetail]	
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT LOCATION_CODE 
			   FROM CLEARING_LOCATION WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CLEARING_LOCATION 
			WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CLEARING_LOCATION_HIST
			WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO = @MOD_NO
		END
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Authorize record to Clearing_location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_Auth]	
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@LOCATION_NAME	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT LOCATION_CODE from CLEARING_LOCATION_HIST 
			  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@LOCATION_NAME=LOCATION_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLEARING_LOCATION_HIST 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLEARING_LOCATION_HIST 
				SELECT *,1 FROM CLEARING_LOCATION
				WHERE LOCATION_CODE=@LOCATION_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLEARING_LOCATION_HIST
				SET [STATUS] = ''O'' 
				WHERE LOCATION_CODE=@LOCATION_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLEARING_LOCATION
				SET LOCATION_NAME=@LOCATION_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE LOCATION_CODE=@LOCATION_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLEARING_LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLEARING_LOCATION
				SELECT LOCATION_CODE, LOCATION_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLEARING_LOCATION_HIST
					WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLEARING_LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
	
    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Remove record from Clearing_location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingLocation_Remove]	
	@LOCATION_CODE	varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@LOCATION_NAME 	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT LOCATION_CODE from CLEARING_LOCATION 
			  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@LOCATION_NAME=LOCATION_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLEARING_LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLEARING_LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLEARING_LOCATION_HIST (LOCATION_CODE, LOCATION_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@LOCATION_CODE, @LOCATION_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT LOCATION_CODE from CLEARING_LOCATION_HIST 
					  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLEARING_LOCATION_HIST
						WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingLocation_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	update detail to Clearing_location table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClearingLocation_Update]	
	@LOCATION_CODE	varchar(4),
	@LOCATION_NAME 	varchar(35),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT LOCATION_CODE FROM CLEARING_LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CLEARING_LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CLEARING_LOCATION_HIST(LOCATION_CODE, LOCATION_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@LOCATION_CODE, @LOCATION_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT LOCATION_CODE from CLEARING_LOCATION_HIST 
						WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CLEARING_LOCATION_HIST WHERE LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CLEARING_LOCATION_HIST(LOCATION_CODE, LOCATION_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@LOCATION_CODE, @LOCATION_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Aug-13
-- Description:	Get detail of PDCTOTAL by code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_GetDetailByCode]	
	@DS_CODE	varchar(8),
	@OPR_DATE	datetime,
	@ENTRY_LOC	varchar(3)
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
				FROM PDCTOTAL 
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC)
		BEGIN
			SELECT *,''IS_AUTH''=1 
				FROM PDCTOTAL 
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC;
		END	
	ELSE
		BEGIN
			SELECT * 
				FROM PDCTOTAL_HIST
				WHERE DS_CODE=@DS_CODE AND OPR_DATE=@OPR_DATE
				AND ENTRY_LOC=@ENTRY_LOC AND IS_AUTH=0;
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	update detail to PDCTotal
-- =============================================

CREATE PROCEDURE [dbo].[CMS_PDCTotal_Update]	
	@MID			numeric(10,0),
	@DS_CODE		varchar(8), 
	@TOTAL_CHKNO	int, 
	@TOTAL_CHKAMT	numeric(14,2), 
	@OPR_DATE		datetime, 
	@CUSTOMER_REF	varchar(50), 
	@ENTRY_LOC		varchar(3),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	DECLARE @ENTRY_DATE datetime;

	SET NOCOUNT ON;

	IF EXISTS(SELECT DS_CODE FROM PDCTOTAL 
				WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN

			SELECT @ENTRY_DATE=ENTRY_DATE FROM PDCTOTAL 
				WHERE MID=@MID AND MOD_NO=@MOD_NO;

			DELETE PDCTOTAL_HIST WHERE MID=@MID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO PDCTOTAL_HIST(MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
				OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@MID,@DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, 
				@OPR_DATE, @CUSTOMER_REF, @ENTRY_LOC, @ENTRY_DATE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE PDCTAB_HIST
				WHERE MID=@MID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT DS_CODE from PDCTOTAL_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					SELECT @ENTRY_DATE=ENTRY_DATE FROM PDCTOTAL_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					DELETE PDCTOTAL_HIST WHERE MID=@MID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN						
	
							RETURN 1;
						END

					INSERT INTO PDCTOTAL_HIST(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
						OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@MID, @DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, 
						@OPR_DATE, @CUSTOMER_REF, @ENTRY_LOC, @ENTRY_DATE,
						substring(suser_name(),charindex
(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN						
	
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE PDCTAB_HIST
						WHERE MID=@MID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Get Total # of modification of PDCTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_GetMaxMod]
	@MID	numeric(10,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM PDCTOTAL_HIST 
		WHERE MID=@MID AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM PDCTOTAL
				WHERE MID=@MID;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Get detail of PDCTOTAL
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_GetDetail]	
	@MID		numeric(10,0),
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DS_CODE 
				FROM PDCTOTAL 
				WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
				FROM PDCTOTAL 
				WHERE MID=@MID AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
				FROM PDCTOTAL_HIST
				WHERE MID=@MID AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Remove record from PDCTotal
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_Remove]
	@MID		numeric(10,0),
	@MOD_NO		int,	
	@RET_MOD_NO	int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@DS_CODE		varchar(8),
			@OPR_DATE		datetime,
			@ENTRY_LOC		varchar(3),
			@TOTAL_CHKNO	int, 
			@TOTAL_CHKAMT	numeric(14,2), 
			@CUSTOMER_REF	varchar(50),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@ENTRY_DATE		datetime,
			@PDC_TRANS		bit;
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT DS_CODE from PDCTOTAL
			  WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@DS_CODE=DS_CODE,@OPR_DATE=OPR_DATE,@ENTRY_LOC=ENTRY_LOC,
				@TOTAL_CHKNO=TOTAL_CHKNO,@TOTAL_CHKAMT=TOTAL_CHKAMT,
				@CUSTOMER_REF=CUSTOMER_REF,@ENTRY_DATE=ENTRY_DATE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@PDC_TRANS=PDC_TRANS
				FROM PDCTOTAL
				WHERE MID=@MID AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			IF (@PDC_TRANS = 1)
				BEGIN
					-- transferred item 
					ROLLBACK TRANSACTION;
					RETURN 12;
				END;

			DELETE PDCTOTAL_HIST WHERE MID=@MID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				PDCTOTAL_HIST (MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
				CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH,PDC_TRANS)
				VALUES(@MID,@DS_CODE, @TOTAL_CHKNO, @TOTAL_CHKAMT, @OPR_DATE, 
				@CUSTOMER_REF, @ENTRY_LOC, @ENTRY_DATE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0,@PDC_TRANS)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE PDCTAB_HIST
				WHERE MID=@MID AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO PDCTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
				PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
				CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF,
				ENTRY_LOC, DS_CODE, MOD_NO, IS_AUTH, VALUE_TYPE,IS_ROW_CHG)
				SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
				PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
				CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF,
				ENTRY_LOC, DS_CODE, @RET_MOD_NO, 0, VALUE_TYPE,IS_ROW_CHG
				FROM PDCTAB
				WHERE MID=@MID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT DS_CODE from PDCTOTAL_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE PDCTOTAL_HIST
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE PDCTAB_HIST 
						WHERE MID=@MID AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTotal_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Authorize record to PDCTOTAL
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTotal_Auth]	
	@MID			numeric(10,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@DS_CODE		varchar(8),
			@OPR_DATE		datetime,
			@ENTRY_LOC		varchar(3),
			@TOTAL_CHKNO	int, 
			@TOTAL_CHKAMT	numeric(14,2), 
			@CUSTOMER_REF	varchar(50),		
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT DS_CODE from PDCTOTAL_HIST 
			  WHERE MID=@MID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@DS_CODE=DS_CODE,@OPR_DATE=OPR_DATE,@ENTRY_LOC=ENTRY_LOC,
				@TOTAL_CHKNO=TOTAL_CHKNO, 
				@TOTAL_CHKAMT=TOTAL_CHKAMT,@CUSTOMER_REF=CUSTOMER_REF,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM PDCTOTAL_HIST 
				WHERE MID=@MID AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO PDCTOTAL_HIST(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
				OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, 
				MOD_NO, [STATUS], IS_AUTH, PDC_TRANS)
				SELECT MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, 
				OPR_DATE, CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, 
				MOD_NO, [STATUS],1, PDC_TRANS FROM PDCTOTAL
				WHERE MID=@MID;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE PDCTOTAL_HIST
				SET [STATUS] = ''O'' 
				WHERE MID=@MID
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE PDCTOTAL
				SET
				DS_CODE=@DS_CODE,OPR_DATE=@OPR_DATE,ENTRY_LOC=@ENTRY_LOC,
				TOTAL_CHKNO=@TOTAL_CHKNO,
				TOTAL_CHKAMT=@TOTAL_CHKAMT,CUSTOMER_REF=@CUSTOMER_REF, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE MID=@MID;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE PDCTOTAL_HIST WHERE MID=@MID
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN  
			INSERT INTO PDCTOTAL(MID, DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE,
				CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], PDC_TRANS)
				SELECT MID,DS_CODE, TOTAL_CHKNO, TOTAL_CHKAMT, OPR_DATE, 
					CUSTOMER_REF, ENTRY_LOC, ENTRY_DATE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'', PDC_TRANS
					FROM PDCTOTAL_HIST
					WHERE MID=@MID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE PDCTOTAL_HIST WHERE MID=@MID
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update PDCTAB

	INSERT INTO PDCTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, MOD_NO, IS_AUTH, VALUE_TYPE,IS_ROW_CHG)
		SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, MOD_NO, 1, VALUE_TYPE,IS_ROW_CHG
		FROM PDCTAB
		WHERE MID=@MID;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE PDCTAB WHERE MID=@MID;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO PDCTAB(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, MOD_NO,VALUE_TYPE,IS_ROW_CHG)
		SELECT MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, 
		PAYEE_NAME, CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, 
		CHECK_TYPE, ACC_NO, DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, 
		ENTRY_LOC, DS_CODE, MOD_NO, VALUE_TYPE,IS_ROW_CHG
		FROM PDCTAB_HIST 
		WHERE MID=@MID AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE PDCTAB_HIST WHERE MID=@MID AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTab_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	Add detail to PDCTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTab_Add]
	@MID			numeric(10,0),
	@DSL			numeric(4,0),		
	@OPR_DATE		datetime, 
	@ISSUE_DATE		datetime, 
	@NIKBRANCH_CODE	varchar(7), 
	@PAYEE_NAME		varchar(40), 
	@CHECK_SERIES	varchar(4), 
	@CHECK_NUMBER	varchar(15), 
	@CHECK_NO		varchar(8), 
	@BOOK_NO		varchar(8), 
	@CHECK_TYPE		varchar(8), 
	@ACC_NO			varchar(15), 
	@DEBIT_CREDIT	numeric(14,2), 
	@REMARK			varchar(15), 
	@BATCH_NO		varchar(8), 
	@CHECK_REF		varchar(40), 
	@ENTRY_LOC		varchar(3), 
	@DS_CODE		varchar(8),
	@VALUE_TYPE		numeric(1,0),
	@IS_ROW_CHG		bit
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO PDCTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, PAYEE_NAME, 
		CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, ACC_NO, 
		DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 		
		MOD_NO,IS_AUTH,VALUE_TYPE,IS_ROW_CHG)
		VALUES(@MID,@DSL,@OPR_DATE, @ISSUE_DATE, @NIKBRANCH_CODE, @PAYEE_NAME, 
		@CHECK_SERIES, @CHECK_NUMBER, @CHECK_NO, @BOOK_NO, @CHECK_TYPE, @ACC_NO, 
		@DEBIT_CREDIT, @REMARK, @BATCH_NO, @CHECK_REF, @ENTRY_LOC, @DS_CODE, 
		1,0,@VALUE_TYPE,@IS_ROW_CHG);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_PDCTab_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Jul-13
-- Description:	update detail to PDCTab
-- =============================================
CREATE PROCEDURE [dbo].[CMS_PDCTab_Update]
	@MID			numeric(10,0),
	@DSL			numeric(4,0),		
	@OPR_DATE		datetime, 
	@ISSUE_DATE		datetime, 
	@NIKBRANCH_CODE	varchar(7), 
	@PAYEE_NAME		varchar(40), 
	@CHECK_SERIES	varchar(4), 
	@CHECK_NUMBER	varchar(15), 
	@CHECK_NO		varchar(8), 
	@BOOK_NO		varchar(8), 
	@CHECK_TYPE		varchar(8), 
	@ACC_NO			varchar(15), 
	@DEBIT_CREDIT	numeric(14,2), 
	@REMARK			varchar(15), 
	@BATCH_NO		varchar(8), 
	@CHECK_REF		varchar(40), 
	@ENTRY_LOC		varchar(3), 
	@DS_CODE		varchar(8),	
	@MOD_NO			numeric(3,0),
	@VALUE_TYPE		numeric(1,0),
	@IS_ROW_CHG		bit
AS
BEGIN	

	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO PDCTAB_HIST(MID,DSL,OPR_DATE, ISSUE_DATE, NIKBRANCH_CODE, PAYEE_NAME, 
		CHECK_SERIES, CHECK_NUMBER, CHECK_NO, BOOK_NO, CHECK_TYPE, ACC_NO, 
		DEBIT_CREDIT, REMARK, BATCH_NO, CHECK_REF, ENTRY_LOC, DS_CODE, 		
		MOD_NO,IS_AUTH,VALUE_TYPE,IS_ROW_CHG)
		VALUES(@MID,@DSL,@OPR_DATE, @ISSUE_DATE, @NIKBRANCH_CODE, @PAYEE_NAME, 
		@CHECK_SERIES, @CHECK_NUMBER, @CHECK_NO, @BOOK_NO, @CHECK_TYPE, @ACC_NO, 
		@DEBIT_CREDIT, @REMARK, @BATCH_NO, @CHECK_REF, @ENTRY_LOC, @DS_CODE,		
		@MOD_NO,0,@VALUE_TYPE,@IS_ROW_CHG);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 02-Mar-13
-- Description:	Get detail of DD by Code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetDetailByCode]	
	@D_CODE		varchar(12),
    @SLNO		numeric(3,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM DD WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM DD 
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM DD_HIST
			WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND MOD_NO=@MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Fahad Khan
-- Create date: 2-Mar-13
-- Description:	Get Total # of modification of DD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetMaxMod]
	@D_CODE			varchar(12),
	@SLNO			numeric(3,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM DD_HIST 
		WHERE D_CODE=@D_CODE AND SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM DD
				WHERE D_CODE=@D_CODE AND SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetDetailForSubsystem]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-May-13
-- Description:	get detail of DD for subsystem
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetDetailForSubsystem]
	@ACC_NO	varchar(16),
	@D_CODE	varchar(12)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT ISNULL(drawer_bankcode,0) BANK_CODE,
	ISNULL(NIKBRANCH_CODE,0) NIKBRANCH_CODE, DD_DATE, 
	''01/01/1900'' OPR_DATE, DD_NO,
    ''14'' CHQTYPE, AMOUNT, D_CODE,@ACC_NO ACC_NO ,SLNO 
    FROM DD
	WHERE D_CODE =@D_CODE;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetGroupForSubSysByNik]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 27-May-13
-- Description:	get group data of DD for subsystem by Nikbranch
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetGroupForSubSysByNik]
	@ACC_NO	varchar(16),
	@D_CODE	varchar(12)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT ISNULL(D_CODE,0) D_CODE, COUNT(D_CODE) TOTAL_CHKNO, 
	SUM(AMOUNT) TOTAL_CHKAMT, ''01/01/1900'' OPRDATE, 
	ISNULL(NIKBRANCH_CODE,0) NIKBRANCH_CODE, @ACC_NO ACC_NO
	FROM DD 
	WHERE D_CODE =@D_CODE
	GROUP BY D_CODE,NIKBRANCH_CODE	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_GetMaxSlno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- Author:		Fahad Khan
-- Create date: 25-02-13
-- Description:	Get Total # of Serial of DD table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetMaxSlno]	
	@D_CODE		varchar(12)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(SLNO),0) FROM DD_HIST 
		WHERE D_CODE=@D_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(SLNO),0) FROM DD 
				WHERE D_CODE=@D_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_DD_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Fahad Khan
-- Create date: 19-Feb-13
-- Description:	Add detail to DD_DET
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_Add]	
	@D_CODE				varchar(12),
    @SLNO               numeric(3,0),
	@DD_NO 			    varchar(18), 
    @DD_DATE            datetime,
	@AMOUNT			    numeric(12, 2), 
	@DRAWER_BANKCODE	varchar(4), 
	@DRAWER_BRANCHCODE	varchar(4), 
	@DRAWER_LOCATION	varchar(4), 
	@DRAWEE_BRANCH		varchar(25), 
	@NIKBRANCH_CODE		varchar(7),
	@VAT			    numeric(12, 2),
    @COMMISION          numeric(12, 2),
    @POSTAGE_CHARGE     numeric(12, 2),
    @INSTRUMENT_EXP     numeric(12, 2)
AS
BEGIN	
	DECLARE @ErrorVar	int;
--    DECLARE @SLNO		int;
	SET NOCOUNT ON;

--    SELECT @SLNO =(COUNT(D_CODE) + 1) FROM DD_HIST WHERE D_CODE=@D_CODE;
  	
  
    SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	

	INSERT INTO DD_HIST(D_CODE, SLNO, DD_NO, DD_DATE, 
		AMOUNT,DRAWER_BANKCODE, DRAWER_BRANCHCODE, DRAWER_LOCATION,
		DRAWEE_BRANCH, NIKBRANCH_CODE,VAT,COMMISION,POSTAGE_CHARGE,INSTRUMENT_EXP,
		INPUT_BY,
		INPUT_DATETIME,	INPUT_FROM,MOD_NO, RTN_STATUS,[STATUS],IS_AUTH)
		VALUES(@D_CODE, @SLNO, @DD_NO, @DD_DATE, 
		@AMOUNT, @DRAWER_BANKCODE,@DRAWER_BRANCHCODE, @DRAWER_LOCATION, 
		@DRAWEE_BRANCH,	@NIKBRANCH_CODE, @VAT,@COMMISION,@POSTAGE_CHARGE,@INSTRUMENT_EXP,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''D'',''U'',0);
    

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	get list records of department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT SLNO,DEPT_NAME FROM DEPARTMENT WHERE STATUS=''L''
	ORDER BY DEPT_NAME;
	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	update detail to department table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Department_Update]	
	@SLNO			numeric(3,0),
	@DEPT_ID		varchar(5),
	@DEPT_NAME 		varchar(50),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT DEPT_ID FROM DEPARTMENT 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE DEPARTMENT_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO DEPARTMENT_HIST(SLNO,DEPT_ID, DEPT_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@SLNO,@DEPT_ID, @DEPT_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT DEPT_ID from DEPARTMENT_HIST 
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE DEPARTMENT_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO DEPARTMENT_HIST(SLNO,DEPT_ID,DEPT_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@SLNO,@DEPT_ID, @DEPT_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Get detail of department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_GetDetail]	
	@SLNO		numeric(3,0),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT DEPT_ID 
			   FROM DEPARTMENT WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM DEPARTMENT 
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM DEPARTMENT_HIST
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Add detail to Department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_Add]	
	@DEPT_ID		varchar(5),
	@DEPT_NAME 		varchar(50),
	@RET_SLNO		numeric(3,0) output	
AS
BEGIN	
	DECLARE @ErrorVar	int,
			@MaxS1		int,
			@MaxS2		int;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT DEPT_ID FROM DEPARTMENT WHERE DEPT_ID=@DEPT_ID)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE DEPARTMENT_HIST WHERE 
		DEPT_ID=@DEPT_ID AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
		
	SELECT @MaxS1=ISNULL(MAX(SLNO),0) FROM DEPARTMENT;
	SELECT @MaxS2=ISNULL(MAX(SLNO),0) FROM DEPARTMENT_HIST;

	IF @MaxS1>@MaxS2
		BEGIN
			SELECT @RET_SLNO = @MaxS1 + 1;
		END
	ELSE
		BEGIN
			SELECT @RET_SLNO = @MaxS2 + 1;
		END
		

	INSERT INTO DEPARTMENT_HIST(SLNO,DEPT_ID, DEPT_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@RET_SLNO,@DEPT_ID, @DEPT_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Authorize record to department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_Auth]	
	@SLNO			numeric(3,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@DEPT_ID		varchar(5),
			@DEPT_NAME		varchar(50),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT DEPT_ID from DEPARTMENT_HIST 
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@DEPT_ID=DEPT_ID,@DEPT_NAME=DEPT_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM DEPARTMENT_HIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO DEPARTMENT_HIST 
				SELECT *,1 FROM DEPARTMENT
				WHERE SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE DEPARTMENT_HIST
				SET [STATUS] = ''O'' 
				WHERE SLNO=@SLNO
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE DEPARTMENT
				SET DEPT_ID=@DEPT_ID,DEPT_NAME=@DEPT_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE DEPARTMENT_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO DEPARTMENT
				SELECT SLNO,DEPT_ID,DEPT_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM DEPARTMENT_HIST
					WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE DEPARTMENT_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION;
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Get Total # of modification of department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_GetMaxMod]	
	@SLNO		numeric(3,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM DEPARTMENT_HIST 
		WHERE SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM DEPARTMENT
				WHERE SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Get detail of Department  table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;
	
	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM DEPARTMENT_HIST  
				WHERE IS_AUTH=0
				ORDER BY DEPT_ID;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM DEPARTMENT
						WHERE [STATUS] =''L''					
						ORDER BY DEPT_ID;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM DEPARTMENT
						WHERE [STATUS] IN (''L'',''D'')					
						ORDER BY DEPT_ID;
				END;
		END;	



	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Department_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Remove record from department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_Remove]	
	@SLNO			numeric(3,0),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@DEPT_ID		varchar(5),
			@DEPT_NAME 		varchar(50),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT DEPT_ID from DEPARTMENT
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@DEPT_ID=DEPT_ID,@DEPT_NAME=DEPT_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM DEPARTMENT 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE DEPARTMENT_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				DEPARTMENT_HIST (SLNO,DEPT_ID,DEPT_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@SLNO,@DEPT_ID,@DEPT_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT DEPT_ID from DEPARTMENT_HIST 
					  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE DEPARTMENT_HIST
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_GetDetailByCode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Nov-12
-- Description:	get detail of users F_Group table
--				by dept_slno
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_GetDetailByCode]	
	@USERS_ID	varchar(20)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT u.*,d.DEPT_NAME
		FROM USERS u
		INNER JOIN DEPARTMENT d
		ON d.SLNO=u.DEPT_SLNO
		WHERE u.USERS_ID=@USERS_ID	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Nov-12
-- Description:	Get detail of Users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,d.DEPT_NAME,''S'' = ''U''				 
				FROM USERS_HIST uh
				LEFT OUTER JOIN DEPARTMENT d
				ON uh.DEPT_SLNO=d.SLNO   
				WHERE IS_AUTH=0
				ORDER BY USERS_ID;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,d.DEPT_NAME,''S'' = ''A''				
						FROM USERS u
						LEFT OUTER JOIN DEPARTMENT d
						ON u.DEPT_SLNO=d.SLNO
						WHERE u.STATUS =''L''					
						ORDER BY USERS_ID;
				END;
			ELSE
				BEGIN
					SELECT *,1,d.DEPT_NAME,''S'' = 
						CASE  
							WHEN u.STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM USERS u
						LEFT OUTER JOIN DEPARTMENT d
						ON u.DEPT_SLNO=d.SLNO
						WHERE u.STATUS IN (''L'',''D'')					
						ORDER BY USERS_ID;
				END;
		END;	


		   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get detail to clearing_zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM CLEARING_ZONE_HIST 
				WHERE IS_AUTH=0			
				ORDER BY ZONE_CODE;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM CLEARING_ZONE
						WHERE [STATUS] =''L''					
						ORDER BY ZONE_CODE
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM CLEARING_ZONE
						WHERE [STATUS] in (''L'',''D'')					
						ORDER BY ZONE_CODE
				END;
		END;
	   
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_GetList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Mar-13
-- Description:	get list records of clearing_zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT ZONE_CODE,ZONE_NAME FROM CLEARING_ZONE WHERE STATUS=''L''
	ORDER BY ZONE_NAME;
	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get Total # of modification of clearing_zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_GetMaxMod]	
	@ZONE_CODE		varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLEARING_ZONE_HIST 
		WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLEARING_ZONE 
				WHERE ZONE_CODE=@ZONE_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Get detail of zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_GetDetail]	
	@ZONE_CODE	varchar(4),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT ZONE_CODE 
			   FROM CLEARING_ZONE WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM CLEARING_ZONE 
			WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM CLEARING_ZONE_HIST
			WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Add detail to Zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_Add]	
	@ZONE_CODE		varchar(4),
	@ZONE_NAME 		varchar(35)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT ZONE_CODE FROM CLEARING_ZONE WHERE ZONE_CODE=@ZONE_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CLEARING_ZONE_HIST WHERE 
		ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CLEARING_ZONE_HIST(ZONE_CODE, ZONE_NAME,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@ZONE_CODE, @ZONE_NAME,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Authorize record to Clearing_zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_Auth]	
	@ZONE_CODE	varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@ZONE_NAME		varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ZONE_CODE from CLEARING_ZONE_HIST 
			  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ZONE_NAME=ZONE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLEARING_ZONE_HIST 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLEARING_ZONE_HIST 
				SELECT *,1 FROM CLEARING_ZONE
				WHERE ZONE_CODE=@ZONE_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLEARING_ZONE_HIST
				SET [STATUS] = ''O'' 
				WHERE ZONE_CODE=@ZONE_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLEARING_ZONE
				SET ZONE_NAME=@ZONE_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE ZONE_CODE=@ZONE_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLEARING_ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLEARING_ZONE
				SELECT ZONE_CODE, ZONE_NAME,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLEARING_ZONE_HIST
					WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLEARING_ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END

    
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	update detail to clearing_zone table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClearingZone_Update]	
	@ZONE_CODE	varchar(4),
	@ZONE_NAME 	varchar(35),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT ZONE_CODE FROM CLEARING_ZONE 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CLEARING_ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CLEARING_ZONE_HIST(ZONE_CODE, ZONE_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@ZONE_CODE, @ZONE_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT ZONE_CODE from CLEARING_ZONE_HIST 
						WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CLEARING_ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CLEARING_ZONE_HIST(ZONE_CODE, ZONE_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@ZONE_CODE, @ZONE_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingZone_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 1-Apr-13
-- Description:	Remove record from clearing_zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingZone_Remove]	
	@ZONE_CODE	varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@ZONE_NAME 	varchar(35),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ZONE_CODE from CLEARING_ZONE 
			  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ZONE_NAME=ZONE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLEARING_ZONE 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLEARING_ZONE_HIST WHERE ZONE_CODE=@ZONE_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLEARING_ZONE_HIST (ZONE_CODE, ZONE_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@ZONE_CODE, @ZONE_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT ZONE_CODE from CLEARING_ZONE_HIST 
					  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLEARING_ZONE_HIST
						WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetCorrBankList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Feb-13
-- Description:	get list records of corr. bank 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetCorrBankList]	
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT DISTINCT b.BANK_CODE,b.BANK_NAME 
	FROM BANK b
	INNER JOIN BRANCH br ON b.BANK_CODE=br.BANK_CODE
	WHERE b.STATUS=''L'' 
	AND br.CORRBANK=1
	ORDER BY BANK_NAME;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail to bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM BANK_HIST 
				WHERE IS_AUTH=0
				ORDER BY BANK_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM BANK
						WHERE [STATUS] =''L''					
						ORDER BY BANK_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM BANK
						WHERE [STATUS] IN (''L'',''D'')					
						ORDER BY BANK_CODE;
				END;
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Nov-12
-- Description:	Remove record from bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_Remove]	
	@BANK_CODE		varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BANK_NAME 		varchar(100),
			@HEAD_ADD1 		varchar(35),
			@HEAD_ADD2 		varchar(35),
			@HEAD_ADD3		varchar(20),
			@BANK_BBK_CODE	varchar(9),
			@ACC_NO			varchar(16),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BANK_CODE from BANK 
			  WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BANK_NAME=BANK_NAME,
				@HEAD_ADD1=HEAD_ADD1,@HEAD_ADD2=HEAD_ADD2,
				@HEAD_ADD3=HEAD_ADD3,@BANK_BBK_CODE=BANK_BBK_CODE,@ACC_NO=ACC_NO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM BANK 
				WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE BANK_HIST WHERE BANK_CODE=@BANK_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				BANK_HIST (BANK_CODE, BANK_NAME, HEAD_ADD1, HEAD_ADD2, HEAD_ADD3, 
				BANK_BBK_CODE, ACC_NO,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BANK_CODE, @BANK_NAME, @HEAD_ADD1, @HEAD_ADD2, @HEAD_ADD3, 
				@BANK_BBK_CODE, @ACC_NO,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT BANK_CODE from BANK_HIST 
					  WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE BANK_HIST
						WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Nov-12
-- Description:	update detail to bank table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Bank_Update]	
	@BANK_CODE		varchar(4),
	@BANK_NAME 		varchar(100),
	@HEAD_ADD1 		varchar(35),
	@HEAD_ADD2 		varchar(35),
	@HEAD_ADD3		varchar(20),
	@BANK_BBK_CODE	varchar(9),
	@ACC_NO			varchar(16),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BANK_CODE FROM BANK 
				WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE BANK_HIST WHERE BANK_CODE=@BANK_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO BANK_HIST(BANK_CODE, BANK_NAME,	HEAD_ADD1,HEAD_ADD2,HEAD_ADD3,
				BANK_BBK_CODE,ACC_NO,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
				@BANK_BBK_CODE,@ACC_NO,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT BANK_CODE from BANK_HIST 
						WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE BANK_HIST WHERE BANK_CODE=@BANK_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO BANK_HIST(BANK_CODE, BANK_NAME,	HEAD_ADD1,HEAD_ADD2,HEAD_ADD3,
						BANK_BBK_CODE,ACC_NO,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
						@BANK_BBK_CODE,@ACC_NO,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Nov-12
-- Description:	Add detail to bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_Add]	
	@BANK_CODE		varchar(4),
	@BANK_NAME 		varchar(100),
	@HEAD_ADD1 		varchar(35),
	@HEAD_ADD2 		varchar(35),
	@HEAD_ADD3		varchar(20),
	@BANK_BBK_CODE	varchar(9),
	@ACC_NO			varchar(16)		
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT BANK_CODE from BANK WHERE BANK_CODE=@BANK_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE BANK_HIST WHERE 
		BANK_CODE=@BANK_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO BANK_HIST(BANK_CODE, BANK_NAME,	HEAD_ADD1,HEAD_ADD2,HEAD_ADD3,
		BANK_BBK_CODE,ACC_NO,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
		@BANK_BBK_CODE,@ACC_NO,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Bank_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Nov-12
-- Description:	Authorize record to bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_Auth]	
	@BANK_CODE		varchar(4),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@BANK_NAME 		varchar(100),
			@HEAD_ADD1 		varchar(35),
			@HEAD_ADD2 		varchar(35),
			@HEAD_ADD3		varchar(20),
			@BANK_BBK_CODE	varchar(9),
			@ACC_NO			varchar(16),	
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BANK_CODE from BANK_HIST 
			  WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BANK_NAME=BANK_NAME,
				@HEAD_ADD1=HEAD_ADD1,@HEAD_ADD2=HEAD_ADD2,
				@HEAD_ADD3=HEAD_ADD3,@BANK_BBK_CODE=BANK_BBK_CODE,@ACC_NO=ACC_NO,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM BANK_HIST 
				WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO BANK_HIST 
				SELECT *,1 FROM BANK
				WHERE BANK_CODE=@BANK_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE BANK_HIST
				SET [STATUS] = ''O'' 
				WHERE BANK_CODE=@BANK_CODE 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE BANK
				SET BANK_NAME=@BANK_NAME,
				HEAD_ADD1=@HEAD_ADD1,HEAD_ADD2=@HEAD_ADD2,
				HEAD_ADD3=@HEAD_ADD3,BANK_BBK_CODE=@BANK_BBK_CODE,ACC_NO=@ACC_NO,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE BANK_CODE=@BANK_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE BANK_HIST WHERE BANK_CODE=@BANK_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO BANK
				SELECT BANK_CODE, BANK_NAME, HEAD_ADD1, HEAD_ADD2, HEAD_ADD3, 
					BANK_BBK_CODE,ACC_NO, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM BANK_HIST
					WHERE BANK_CODE=@BANK_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE BANK_HIST WHERE BANK_CODE=@BANK_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Mar-13
-- Description:	Get detail of holiday
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_GetDetailList]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM HOLIDAY_HIST 
				WHERE IS_AUTH=0			
				ORDER BY IS_AUTH,HOLI_DAY;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM HOLIDAY
						WHERE STATUS =''L''					
						ORDER BY HOLI_DAY
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM HOLIDAY
						WHERE STATUS in (''L'',''D'')					
						ORDER BY HOLI_DAY
				END;
		END;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_GetDetailListByMonth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Mar-13
-- Description:	Get detail of holiday by month year
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_GetDetailListByMonth]		
	@DEL_FLAG	int,
	@AUTH_FLAG	bit,
	@P_MONTH	numeric(2,0),
	@P_YEAR		numeric(4,0)
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM HOLIDAY_HIST 
				WHERE IS_AUTH=0
				AND MONTH(HOLI_DAY)= @P_MONTH AND YEAR(HOLI_DAY) =@P_YEAR
				ORDER BY IS_AUTH,HOLI_DAY;
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM HOLIDAY
						WHERE STATUS =''L''
						AND MONTH(HOLI_DAY)= @P_MONTH AND YEAR(HOLI_DAY) =@P_YEAR
						ORDER BY HOLI_DAY
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN STATUS = ''D'' THEN ''D''                    
							ELSE ''A''
						END 
						FROM HOLIDAY
						WHERE STATUS in (''L'',''D'')
						AND MONTH(HOLI_DAY)= @P_MONTH AND YEAR(HOLI_DAY) =@P_YEAR
						ORDER BY HOLI_DAY
				END;
		END;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_GetDetailByDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 05-June-13
-- Description:	Get detail of holiday by date
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_GetDetailByDate]		
	@HOLI_DAY	datetime
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT * 
	FROM HOLIDAY
	WHERE HOLI_DAY=@HOLI_DAY AND [STATUS]=''L'';
	
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Mar-13
-- Description:	Get detail of Holiday table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_GetDetail]	
	@HOLI_DAY	datetime,	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT HOLI_DAY 
			   FROM HOLIDAY WHERE HOLI_DAY=@HOLI_DAY AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM HOLIDAY 
			WHERE HOLI_DAY=@HOLI_DAY AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM HOLIDAY_HIST
			WHERE HOLI_DAY=@HOLI_DAY AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Mar-13
-- Description:	Authorize record to holiday table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_Auth]	
	@HOLI_DAY		datetime,	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@HOLI_TYPE		varchar(20),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT HOLI_DAY from HOLIDAY_HIST 
			  WHERE HOLI_DAY=@HOLI_DAY AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@HOLI_TYPE=HOLI_TYPE,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM HOLIDAY_HIST 
				WHERE HOLI_DAY=@HOLI_DAY AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO HOLIDAY_HIST 
				SELECT *,1 FROM HOLIDAY
				WHERE HOLI_DAY=@HOLI_DAY;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE HOLIDAY_HIST
				SET [STATUS] = ''O'' 
				WHERE HOLI_DAY=@HOLI_DAY 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE HOLIDAY
				SET HOLI_TYPE=@HOLI_TYPE,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE HOLI_DAY=@HOLI_DAY;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE HOLIDAY_HIST WHERE HOLI_DAY=@HOLI_DAY
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO HOLIDAY
				SELECT HOLI_DAY, HOLI_TYPE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM HOLIDAY_HIST
					WHERE HOLI_DAY=@HOLI_DAY AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE HOLIDAY_HIST WHERE HOLI_DAY=@HOLI_DAY
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-Mar-13
-- Description:	Get Total # of modification of holiday table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_GetMaxMod]	
	@HOLI_DAY	datetime
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM HOLIDAY_HIST 
		WHERE HOLI_DAY=@HOLI_DAY AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM HOLIDAY 
				WHERE HOLI_DAY=@HOLI_DAY;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Holiday_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Jan-13
-- Description:	Add detail to Holiday table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Holiday_Add]	
	@HOLI_DAY	datetime,
	@HOLI_TYPE	varchar(20)	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT HOLI_DAY FROM HOLIDAY WHERE HOLI_DAY=@HOLI_DAY)
		BEGIN
			-- Duplicate Entry
		
			RETURN 2	
		END
	
	DELETE HOLIDAY_HIST WHERE 
		HOLI_DAY=@HOLI_DAY AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			
			RETURN 1;
		END
	ELSE

	INSERT INTO HOLIDAY_HIST(HOLI_DAY,HOLI_TYPE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@HOLI_DAY, @HOLI_TYPE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			
			RETURN 1;
		END
	
	
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 03-May-13
-- Description:	Get detail from TOTALCS table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TotalCS_GetDetailList]		
	@DEL_FLAG	int	,
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;


	IF @AUTH_FLAG=0
		BEGIN						
			SELECT *,''S'' = ''U''				 
				FROM TOTALCS_HIST 
				WHERE IS_AUTH=0
				ORDER BY CS_CODE;			
		END;
	ELSE
		BEGIN
			IF @DEL_FLAG=0
				BEGIN
					SELECT *,1,''S'' = ''A''				
						FROM TOTALCS
						WHERE [STATUS] =''L''				
						ORDER BY CS_CODE;
				END;
			ELSE
				BEGIN
					SELECT *,1,''S'' = 
						CASE  
							WHEN [STATUS] = ''D'' THEN ''D''        
							ELSE ''A''
						END 
						FROM TOTALCS
						WHERE [STATUS] IN (''L'',''D'')			
						ORDER BY CS_CODE;
				END;
		END;	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Add detail to TotalCS
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TotalCS_Add]	
	@CS_CODE		varchar(12), 	
	@TOTAL_AMOUNT	numeric(12,2)
AS
BEGIN	
	DECLARE @ErrorVar	int;
	
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT CS_CODE FROM TOTALCS
				WHERE CS_CODE=@CS_CODE)
		BEGIN
			-- Duplicate Entry				
			RETURN 2	
		END
	
	DELETE TOTALCS_HIST WHERE 
		CS_CODE=@CS_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
	
	INSERT INTO TOTALCS_HIST(CS_CODE, TOTAL_AMOUNT, 		
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@CS_CODE, @TOTAL_AMOUNT, 		
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END

	DELETE CSCHEDULE_HIST WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;
	
	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END	

	RETURN 0;
	
   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	update detail to TotalCS
-- =============================================

CREATE PROCEDURE [dbo].[CMS_TotalCS_Update]	
	@CS_CODE		varchar(12), 	
	@TOTAL_AMOUNT	numeric(12,2),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT CS_CODE FROM TOTALCS 
				WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE TOTALCS_HIST WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO TOTALCS_HIST(CS_CODE, TOTAL_AMOUNT, 				
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@CS_CODE, @TOTAL_AMOUNT,				
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END				
			
			DELETE CSCHEDULE_HIST
				WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					RETURN 1;
				END
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT CS_CODE from TOTALCS_HIST 
						WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE TOTALCS_HIST WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO TOTALCS_HIST(CS_CODE, TOTAL_AMOUNT,						
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@CS_CODE, @TOTAL_AMOUNT, 						
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;

					DELETE CSCHEDULE_HIST
						WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;

					IF @ErrorVar <> 0
						BEGIN
							RETURN 1;
						END			
					
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Get Total # of modification of TotalCS
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TotalCS_GetMaxMod]
	@CS_CODE			varchar(12)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM TOTALCS_HIST 
		WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM TOTALCS
				WHERE CS_CODE=@CS_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Remove record from TotalCS
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TotalCS_Remove]	
	@CS_CODE		varchar(12),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@TOTAL_AMOUNT	numeric(12,2), 			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CS_CODE from TOTALCS
			  WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_AMOUNT=TOTAL_AMOUNT, 				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM TOTALCS
				WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE TOTALCS_HIST WHERE CS_CODE=@CS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				TOTALCS_HIST (CS_CODE,
				TOTAL_AMOUNT, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@CS_CODE,
				@TOTAL_AMOUNT, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


-----------

			DELETE CSCHEDULE_HIST
				WHERE CS_CODE=@CS_CODE AND IS_AUTH=0 ;

			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			INSERT INTO CSCHEDULE_HIST
				SELECT CS_CODE, SCHEDULE_DATE, LOCATION_CODE, CORR_BANK_CODE, 
					CORR_BRANCH_CODE, DS_CODE, CITICASH_AMOUNT, CITICHECK_AMOUNT, 
					NO_CHECK,
					@RET_MOD_NO,0
				FROM CSCHEDULE
				WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar = @@error;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			
-----------
			

			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT CS_CODE from TOTALCS_HIST 
					  WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE TOTALCS_HIST
						WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					DELETE CSCHEDULE_HIST 
						WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO AND IS_AUTH=0 ;
					
					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
	
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Get detail of TotalCS
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TotalCS_GetDetail]	
	@CS_CODE	varchar(12),	
	@MOD_NO		int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT CS_CODE 
			   FROM TOTALCS WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM TOTALCS 
			WHERE CS_CODE=@CS_CODE AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM TOTALCS_HIST
			WHERE CS_CODE=@CS_CODE AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_TotalCS_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Authorize record to TotalCS
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TotalCS_Auth]	
	@CS_CODE		varchar(12),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),			
			@TOTAL_AMOUNT	numeric(12,2), 			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CS_CODE from TOTALCS_HIST 
			  WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_AMOUNT=TOTAL_AMOUNT, 				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM TOTALCS_HIST 
				WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO TOTALCS_HIST 
				SELECT *,1 FROM TOTALCS
				WHERE CS_CODE=@CS_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE TOTALCS_HIST
				SET [STATUS] = ''O'' 
				WHERE CS_CODE=@CS_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE TOTALCS
				SET
				TOTAL_AMOUNT=@TOTAL_AMOUNT,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE CS_CODE=@CS_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE TOTALCS_HIST WHERE CS_CODE=@CS_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO TOTALCS
				SELECT CS_CODE,TOTAL_AMOUNT,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM TOTALCS_HIST
					WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE TOTALCS_HIST WHERE CS_CODE=@CS_CODE
				AND IS_AUTH=0;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END
	
	-- Now update CSCHEDULE

	INSERT INTO CSCHEDULE_HIST
		SELECT *,1
		FROM CSCHEDULE
		WHERE CS_CODE=@CS_CODE;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	DELETE CSCHEDULE WHERE CS_CODE=@CS_CODE;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END

	INSERT INTO CSCHEDULE
		SELECT CS_CODE, SCHEDULE_DATE, LOCATION_CODE, CORR_BANK_CODE, 
		CORR_BRANCH_CODE, DS_CODE, CITICASH_AMOUNT, CITICHECK_AMOUNT, 
		NO_CHECK, MOD_NO
		FROM CSCHEDULE_HIST 
		WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO;
	
	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END	

	DELETE CSCHEDULE_HIST WHERE CS_CODE=@CS_CODE AND MOD_NO=@MOD_NO;

	SELECT @ErrorVar1 = @@error;

	IF @ErrorVar1 <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
		
	SELECT @ErrorVar1 = @@error;
		
	IF @ErrorVar1 = 0
		BEGIN		
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END

    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Nov-12
-- Description:	update detail to client location charge
-- =============================================

CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_Update]	
	@CLIENT_CODE		varchar(6),
	@LOCATION_CODE		varchar(4),
	@CASH_DAYS			numeric(2,0), 
	@SPEED_DAYS			numeric(2,0), 
	@CASH_CHARGE		numeric(12,2), 
	@SPEED_CHARGE		numeric(12,2), 
	@MOD_NO				int,
	@RET_MOD_NO			int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CLIENT_CODE FROM CLIENT_LOC_CHARGE 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE CLIENT_LOC_CHARGE_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO CLIENT_LOC_CHARGE_HIST(CLIENT_CODE, LOCATION_CODE,
				CASH_DAYS, SPEED_DAYS,
				CASH_CHARGE, SPEED_CHARGE,				
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@CLIENT_CODE, @LOCATION_CODE,
				@CASH_DAYS, @SPEED_DAYS,
				@CASH_CHARGE, @SPEED_CHARGE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT CLIENT_CODE from CLIENT_LOC_CHARGE_HIST 
						WHERE CLIENT_CODE=@CLIENT_CODE 
						AND LOCATION_CODE=@LOCATION_CODE 
						AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE CLIENT_LOC_CHARGE_HIST 
						WHERE CLIENT_CODE=@CLIENT_CODE 
						AND LOCATION_CODE=@LOCATION_CODE 
						AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO CLIENT_LOC_CHARGE_HIST(CLIENT_CODE,LOCATION_CODE,
						CASH_DAYS, SPEED_DAYS,
						CASH_CHARGE, SPEED_CHARGE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@CLIENT_CODE, @LOCATION_CODE,
						@CASH_DAYS, @SPEED_DAYS, 
						@CASH_CHARGE, @SPEED_CHARGE,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Nov-12
-- Description:	Remove record from Client Location Charge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_Remove]	
	@CLIENT_CODE	varchar(6),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS				char(1),			
			@CASH_DAYS			numeric(2,0), 
			@SPEED_DAYS			numeric(2,0),			
			@CASH_CHARGE		numeric(12,2), 
			@SPEED_CHARGE		numeric(12,2),			
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),			
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CLIENT_CODE from CLIENT_LOC_CHARGE 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@CASH_DAYS=CASH_DAYS, @SPEED_DAYS=SPEED_DAYS, 
				@CASH_CHARGE=CASH_CHARGE, @SPEED_CHARGE=SPEED_CHARGE, 
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CLIENT_LOC_CHARGE 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE CLIENT_LOC_CHARGE_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				CLIENT_LOC_CHARGE_HIST (CLIENT_CODE, LOCATION_CODE,
				CASH_DAYS, SPEED_DAYS,
				CASH_CHARGE, SPEED_CHARGE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@CLIENT_CODE, @LOCATION_CODE,
				@CASH_DAYS, @SPEED_DAYS,
				@CASH_CHARGE, @SPEED_CHARGE,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT CLIENT_CODE from CLIENT_LOC_CHARGE_HIST 
					  WHERE CLIENT_CODE=@CLIENT_CODE 
						AND LOCATION_CODE=@LOCATION_CODE 
						AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE CLIENT_LOC_CHARGE_HIST
						WHERE CLIENT_CODE=@CLIENT_CODE 
						AND LOCATION_CODE=@LOCATION_CODE 
						AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Nov-12
-- Description:	Authorize record to client location charge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_Auth]	
	@CLIENT_CODE	varchar(6),
	@LOCATION_CODE	varchar(4),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@CASH_DAYS			numeric(2,0), 
			@SPEED_DAYS			numeric(2,0),
			@CASH_CHARGE		numeric(12,2), 
			@SPEED_CHARGE		numeric(12,2),
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),
			@AUTH_BY			varchar(20),
			@AUTH_DATETIME		datetime,
			@AUTH_FROM			varchar(30),
			@LAST_MOD_NO		int,
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CLIENT_CODE from CLIENT_LOC_CHARGE_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],				
				@CASH_DAYS=CASH_DAYS, @SPEED_DAYS=SPEED_DAYS, 
				@CASH_CHARGE=CASH_CHARGE, @SPEED_CHARGE=SPEED_CHARGE, 
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM CLIENT_LOC_CHARGE_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE AND 
				LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO CLIENT_LOC_CHARGE_HIST 
				SELECT *,1 FROM CLIENT_LOC_CHARGE
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CLIENT_LOC_CHARGE_HIST
				SET [STATUS] = ''O'' 
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE CLIENT_LOC_CHARGE
				SET CASH_DAYS=@CASH_DAYS, SPEED_DAYS=@SPEED_DAYS, 
				CASH_CHARGE=@CASH_CHARGE, SPEED_CHARGE=@SPEED_CHARGE, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE ;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE CLIENT_LOC_CHARGE_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO CLIENT_LOC_CHARGE
				SELECT CLIENT_CODE, LOCATION_CODE,
					CASH_DAYS, SPEED_DAYS,
					CASH_CHARGE, SPEED_CHARGE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM CLIENT_LOC_CHARGE_HIST
					WHERE CLIENT_CODE=@CLIENT_CODE AND 
					LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE CLIENT_LOC_CHARGE_HIST 
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Nov-12
-- Description:	Add detail to Client Location Charge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_Add]	
	@CLIENT_CODE		varchar(6),
	@LOCATION_CODE		varchar(4),
	@CASH_DAYS			numeric(2,0), 
	@SPEED_DAYS			numeric(2,0), 
	@CASH_CHARGE		numeric(12,2), 
	@SPEED_CHARGE		numeric(12,2) 
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT CLIENT_CODE 
				FROM CLIENT_LOC_CHARGE 
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE CLIENT_LOC_CHARGE_HIST WHERE 
		CLIENT_CODE=@CLIENT_CODE
		AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO CLIENT_LOC_CHARGE_HIST(CLIENT_CODE, LOCATION_CODE,
		CASH_DAYS, SPEED_DAYS,
		CASH_CHARGE, SPEED_CHARGE, 
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@CLIENT_CODE, @LOCATION_CODE,
		@CASH_DAYS, @SPEED_DAYS, 
		@CASH_CHARGE, @SPEED_CHARGE,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClientLocCharge_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Nov-12
-- Description:	Get Total # of modification of CLIENT table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_GetMaxMod]	
	@CLIENT_CODE	varchar(6),
	@LOCATION_CODE	varchar(4)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM CLIENT_LOC_CHARGE_HIST 
		WHERE CLIENT_CODE=@CLIENT_CODE 
		AND LOCATION_CODE=@LOCATION_CODE AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM CLIENT_LOC_CHARGE 
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSchedule_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 24-Jan-13
-- Description:	Add detail to Collection Schedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CSchedule_Add]
	@CS_CODE			varchar(12),
	@SCHEDULE_DATE		datetime, 
	@LOCATION_CODE		varchar(4), 
	@CORR_BANK_CODE		varchar(4), 
	@CORR_BRANCH_CODE	varchar(4), 
	@DS_CODE			varchar(12), 
	@CITICASH_AMOUNT	numeric(12,2), 
	@CITICHECK_AMOUNT	numeric(12,2), 
	@NO_CHECK			numeric(4,0)	
AS
BEGIN	
	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO CSCHEDULE_HIST(CS_CODE, SCHEDULE_DATE, LOCATION_CODE, CORR_BANK_CODE, 
		CORR_BRANCH_CODE, DS_CODE, CITICASH_AMOUNT, CITICHECK_AMOUNT, NO_CHECK, 
		MOD_NO,IS_AUTH)
		VALUES(@CS_CODE, @SCHEDULE_DATE, @LOCATION_CODE, @CORR_BANK_CODE, 
		@CORR_BRANCH_CODE, @DS_CODE, @CITICASH_AMOUNT, @CITICHECK_AMOUNT, @NO_CHECK, 
		1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CSchedule_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 28-Jan-13
-- Description:	update detail to CSchedule
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CSchedule_Update]
	@CS_CODE			varchar(12),
	@SCHEDULE_DATE		datetime, 
	@LOCATION_CODE		varchar(4), 
	@CORR_BANK_CODE		varchar(4), 
	@CORR_BRANCH_CODE	varchar(4), 
	@DS_CODE			varchar(12), 
	@CITICASH_AMOUNT	numeric(12,2), 
	@CITICHECK_AMOUNT	numeric(12,2), 
	@NO_CHECK			numeric(4,0),
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO CSCHEDULE_HIST(CS_CODE, SCHEDULE_DATE, LOCATION_CODE, 
		CORR_BANK_CODE,	CORR_BRANCH_CODE, DS_CODE, CITICASH_AMOUNT, 
		CITICHECK_AMOUNT, NO_CHECK,		
		MOD_NO, IS_AUTH)
		VALUES(@CS_CODE, @SCHEDULE_DATE, @LOCATION_CODE, 
		@CORR_BANK_CODE,@CORR_BRANCH_CODE, @DS_CODE, @CITICASH_AMOUNT,
		@CITICHECK_AMOUNT, @NO_CHECK,		
		@MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Nov-12
-- Description:	update detail to Users table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Users_Update]	
	@USERS_ID		varchar(20),
	@USERS_NAME		varchar(50),
	@DEPT_SLNO		numeric(3,0) ,
	@DOMAIN			varchar(30),
	@USER_STAT		char(1),
	@IS_ADMIN		bit,
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;

	DECLARE	@LAST_LOGIN_DATE	datetime,
			@INV_ATTEMPT		numeric(1,0);
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	SELECT @LAST_LOGIN_DATE=LAST_LOGIN_DATE,@INV_ATTEMPT=INV_ATTEMPT 
		FROM USERS 
		WHERE USERS_ID=@USERS_ID;

	IF EXISTS(SELECT USERS_ID FROM USERS 
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE USERS_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO USERS_HIST(USERS_ID, USERS_NAME,DEPT_SLNO,DOMAIN,USER_STAT,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH,
				LAST_LOGIN_DATE,INV_ATTEMPT,IS_ADMIN)
				VALUES(@USERS_ID, @USERS_NAME,@DEPT_SLNO,@DOMAIN,@USER_STAT,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0,
				@LAST_LOGIN_DATE,@INV_ATTEMPT,@IS_ADMIN);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT USERS_ID from USERS_HIST 
						WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE USERS_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO USERS_HIST(USERS_ID, USERS_NAME,DEPT_SLNO,DOMAIN,USER_STAT,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH,
						LAST_LOGIN_DATE,INV_ATTEMPT,IS_ADMIN)
						VALUES(@USERS_ID, @USERS_NAME,@DEPT_SLNO,@DOMAIN,@USER_STAT,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0,
						@LAST_LOGIN_DATE,@INV_ATTEMPT,@IS_ADMIN);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Nov-12
-- Description:	Get Total # of modification of Users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_GetMaxMod]	
	@USERS_ID		varchar(20)	
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM USERS_HIST 
		WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM USERS 
				WHERE USERS_ID=@USERS_ID;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Remove record from Users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_Remove]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@USERS_NAME			varchar(50),
			@DEPT_SLNO			numeric(3,0) ,
			@DOMAIN				varchar(30),
			@USER_STAT			char(1),
			@LAST_LOGIN_DATE	datetime,
			@IS_ADMIN			bit,			
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),			
			@IS_AUTH			bit,
			@INV_ATTEMPT		numeric(1,0);			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	SELECT @LAST_LOGIN_DATE=LAST_LOGIN_DATE,@INV_ATTEMPT=INV_ATTEMPT 
		FROM USERS 
		WHERE USERS_ID=@USERS_ID;

	IF EXISTS(SELECT USERS_ID from USERS 
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@USERS_NAME=USERS_NAME,
				@DEPT_SLNO=DEPT_SLNO,@DOMAIN=DOMAIN,@USER_STAT=USER_STAT,
				@IS_ADMIN=IS_ADMIN,							
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM USERS 
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE USERS_HIST WHERE USERS_ID=@USERS_ID AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				USERS_HIST (USERS_ID, USERS_NAME,
				DEPT_SLNO,DOMAIN,USER_STAT,
				LAST_LOGIN_DATE,INV_ATTEMPT,IS_ADMIN,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@USERS_ID, @USERS_NAME,
				@DEPT_SLNO,@DOMAIN,@USER_STAT,
				@LAST_LOGIN_DATE, @INV_ATTEMPT,@IS_ADMIN,
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT USERS_ID from USERS_HIST 
					  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE USERS_HIST
						WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Nov-12
-- Description:	Get detail of users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_GetDetail]	
	@USERS_ID		varchar(20),	
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT USERS_ID 
			   FROM USERS WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM USERS 
			WHERE USERS_ID=@USERS_ID AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM USERS_HIST
			WHERE USERS_ID=@USERS_ID AND MOD_NO = @MOD_NO
		END
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Authorize record to users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_Auth]	
	@USERS_ID		varchar(20),
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS				char(1),
			@USERS_NAME			varchar(50),
			@DEPT_SLNO			numeric(3,0) ,
			@DOMAIN				varchar(30),
			@USER_STAT			char(1),
			@LAST_LOGIN_DATE	datetime,
			@IS_ADMIN			bit,
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),
			@AUTH_BY			varchar(20),
			@AUTH_DATETIME		datetime,
			@AUTH_FROM			varchar(30),
			@LAST_MOD_NO		int,
			@IS_AUTH			bit,
			@INV_ATTEMPT		numeric(1,0);
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT USERS_ID from USERS_HIST 
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@USERS_NAME=USERS_NAME,
				@DEPT_SLNO=DEPT_SLNO,@DOMAIN=DOMAIN,@USER_STAT=USER_STAT,
				@IS_ADMIN=IS_ADMIN,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM USERS_HIST 
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;

			SELECT @LAST_LOGIN_DATE=LAST_LOGIN_DATE,@INV_ATTEMPT=INV_ATTEMPT 
				FROM USERS 
				WHERE USERS_ID=@USERS_ID;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO USERS_HIST(USERS_ID, USERS_NAME, DEPT_SLNO, DOMAIN, 
				USER_STAT, LAST_LOGIN_DATE, INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], IS_AUTH, 
				INV_ATTEMPT,IS_ADMIN)
				SELECT USERS_ID, USERS_NAME, DEPT_SLNO, DOMAIN, 
					USER_STAT, LAST_LOGIN_DATE, INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], 1, 
					INV_ATTEMPT,IS_ADMIN FROM USERS
					WHERE USERS_ID=@USERS_ID;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE USERS_HIST
				SET [STATUS] = ''O'' 
				WHERE USERS_ID=@USERS_ID 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE USERS
				SET USERS_NAME=@USERS_NAME,
				DEPT_SLNO=@DEPT_SLNO,DOMAIN=@DOMAIN,USER_STAT=@USER_STAT,
				LAST_LOGIN_DATE=@LAST_LOGIN_DATE,INV_ATTEMPT=@INV_ATTEMPT,
				IS_ADMIN=@IS_ADMIN,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE USERS_ID=@USERS_ID;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE USERS_HIST WHERE USERS_ID=@USERS_ID
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO USERS(USERS_ID, USERS_NAME,
				DEPT_SLNO, DOMAIN, USER_STAT, 
				LAST_LOGIN_DATE, 
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
				AUTH_BY, 
				AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS], INV_ATTEMPT,
				IS_ADMIN)
				SELECT USERS_ID, USERS_NAME,
					DEPT_SLNO,DOMAIN,USER_STAT,
					LAST_LOGIN_DATE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'', INV_ATTEMPT,
					IS_ADMIN
					FROM USERS_HIST
					WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE USERS_HIST WHERE USERS_ID=@USERS_ID
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Users_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Add detail to Users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_Add]		
	@USERS_ID		varchar(20),
	@USERS_NAME		varchar(50),
	@DEPT_SLNO		numeric(3,0) ,
	@DOMAIN			varchar(30),
	@USER_STAT		char(1),
	@IS_ADMIN		bit
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT USERS_ID FROM USERS WHERE USERS_ID=@USERS_ID)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE USERS_HIST WHERE 
		USERS_ID=@USERS_ID AND IS_AUTH=0;

	SELECT @ErrorVar = @@ERROR;
		
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	ELSE

	INSERT INTO USERS_HIST(USERS_ID, USERS_NAME,DEPT_SLNO,DOMAIN,USER_STAT,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH,IS_ADMIN)
		VALUES(@USERS_ID, @USERS_NAME,@DEPT_SLNO,@DOMAIN,@USER_STAT,
		substring(suser_name(),charindex(''\'',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,''U'',0,@IS_ADMIN);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_IRERet_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Aug-13
-- Description:	Get detail from IRE_RET table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_IRERet_GetDetailList]		
AS
BEGIN	
		
	SET NOCOUNT ON;


	SELECT * FROM IRE_RET	
	   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_IRERet_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Jul-13
-- Description:	Add record to IRE_RET
-- =============================================
CREATE PROCEDURE [dbo].[CMS_IRERet_Add]	
	@ChequeSequenceNumber	varchar(50), 
	@ItemAmount				float, 
	@ReturnReason			varchar(50),
	@SEQ_NUMBER				varchar(50)
AS
BEGIN	
			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	INSERT INTO IRE_RET(ChequeSequenceNumber, ItemAmount, ReturnReason,
		ECEInstitutionItemSequenceNumber)
		VALUES(@ChequeSequenceNumber,@ItemAmount,@ReturnReason,@SEQ_NUMBER)

	SELECT @ErrorVar = @@ERROR;	

	IF @ErrorVar <> 0				
		BEGIN			
			RETURN 1;
		END
	
	RETURN 0;

	
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_CitiAnyFund_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 4-Jul-13
-- Description:	Get detail of CITIANY_FUND
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiAnyFund_GetDetail]		
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT * 
	FROM CITIANY_FUND
	ORDER BY CURR_NO;

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ClearingBranch_GetNikBranchListByBank]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Apr-13
-- Description:	get list records of Clearing Branch  by bank
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClearingBranch_GetNikBranchListByBank]
	@BANK_CODE	varchar(4)
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT NIKBRANCH_CODE,BRANCH_NAME
	FROM CLEARING_BRANCH		
	WHERE STATUS=''L'' 
	AND NIKBRANCH_CODE IS NOT NULL AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnMismatchClear_Add]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 20-Aug-13
-- Description:	RETURN_MISMATCH_CLEAR add
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnMismatchClear_Add]	
	@CHECK_NUMBER	varchar(15),
	@AMOUNT			numeric(14,2),
	@RTN_CODE		varchar(2),
	@OPR_DATE		datetime,
	@SEQ_NUMBER		varchar(50)
AS
BEGIN	
	
		INSERT INTO RETURN_MISMATCH_CLEAR(CHECK_NUMBER, AMOUNT, 
			RTN_CODE, OPR_DATE, SEQ_NUMBER)
			VALUES(@CHECK_NUMBER,@AMOUNT,
			@RTN_CODE,@OPR_DATE,@SEQ_NUMBER)

		RETURN 0;

		
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_ReturnMismatchClear_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 21-Aug-13
-- Description:	Remove record from RETURN_MISMATCH_CLEAR
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnMismatchClear_Remove]	
AS
BEGIN	
			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	DELETE FROM RETURN_MISMATCH_CLEAR;

	SELECT @ErrorVar = @@ERROR;	

	IF @ErrorVar <> 0				
		BEGIN			
			RETURN 1;
		END

	RETURN 0;

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FlexAcc_Auth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 04-Jul-13
-- Description:	Authorize record to FlexAcc table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FlexAcc_Auth]	
	@SLNO			numeric(3,0),	
	@MOD_NO			int,
	@MOD_DATETIME	datetime
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@ACC_NO 		varchar(16),
			@ACC_NAME 		varchar(50),			
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),
			@AUTH_BY		varchar(20),
			@AUTH_DATETIME	datetime,
			@AUTH_FROM		varchar(30),
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			

	SET NOCOUNT ON;

	SELECT @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SLNO from FLEX_ACC_HIST 
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ACC_NO=ACC_NO,@ACC_NAME=ACC_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM FLEX_ACC_HIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex(''\'',suser_name())+1,20))
				BEGIN
					-- maker and checker same person
					ROLLBACK TRANSACTION;
					RETURN 5;
				END;
			IF (@INPUT_DATETIME <> @MOD_DATETIME)
				BEGIN
					-- Data hase been changed. Need notification
					ROLLBACK TRANSACTION;
					RETURN 7;
				END;			
		END;
	ELSE
		BEGIN			
			-- not exist
			ROLLBACK TRANSACTION;
			RETURN 4;
		END	;

	IF @MOD_NO > 1
		BEGIN	
		
			INSERT INTO FLEX_ACC_HIST 
				SELECT *,1 FROM FLEX_ACC
				WHERE SLNO=@SLNO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE FLEX_ACC_HIST
				SET [STATUS] = ''O'' 
				WHERE SLNO=@SLNO 
				AND [STATUS] = ''L'';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS=''U''
				BEGIN
					SELECT @STATUS=''L'';
				END

			UPDATE FLEX_ACC
				SET ACC_NO=@ACC_NO,ACC_NAME=@ACC_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex(''\'',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE SLNO=@SLNO;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE FLEX_ACC_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END	

		END
	ELSE -- first record
		BEGIN
			INSERT INTO FLEX_ACC
				SELECT SLNO, ACC_NO,ACC_NAME, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex(''\'',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, ''L'' 
					FROM FLEX_ACC_HIST
					WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE FLEX_ACC_HIST WHERE SLNO=@SLNO
				AND IS_AUTH=0;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END			
					
		END

		COMMIT TRANSACTION
		
		SELECT @ErrorVar1 = @@error;
		
		IF @ErrorVar1 = 0
			BEGIN		
				RETURN 0;
			END
		ELSE
			BEGIN
				RETURN 1;
			END


	
    
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FlexAcc_GetDetailList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 4-Jul-13
-- Description:	Get detail to FlexAcc table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FlexAcc_GetDetailList]			
	@AUTH_FLAG	bit
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @AUTH_FLAG=0
		BEGIN
			SELECT *,''S'' = ''U''				 
				FROM FLEX_ACC_HIST 
				WHERE IS_AUTH=0			
				ORDER BY SLNO;
		END;
	ELSE
		BEGIN
							
			SELECT *,1,''S'' = ''A''				
				FROM FLEX_ACC
				WHERE [STATUS] =''L''					
				ORDER BY SLNO
							
		END;
	   
	   
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FlexAcc_GetMaxMod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- ===========================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 04-Jul-13
-- Description:	Get Total # of modification of FlexAcc table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FlexAcc_GetMaxMod]	
	@SLNO	numeric(3,0)
AS
BEGIN	

	DECLARE @Max1	int,
			@Max2	int;

	SET NOCOUNT ON;
	
	SELECT @Max1=0,@Max2=0;

	SELECT @Max1=ISNULL(MAX(MOD_NO),0) FROM FLEX_ACC_HIST 
		WHERE SLNO=@SLNO AND IS_AUTH=0;
		
	IF @Max1=0
		BEGIN
			SELECT @Max2=ISNULL(MAX(MOD_NO),0) FROM FLEX_ACC 
				WHERE SLNO=@SLNO;
			SELECT @Max2;
			RETURN 0;			
		END
	
	SELECT @Max1;
	RETURN 0;

END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FlexAcc_Remove]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Jul-13
-- Description:	Remove record from FlexAcc table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FlexAcc_Remove]	
	@SLNO	varchar(4),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @STATUS			char(1),
			@ACC_NO		 	varchar(16),
			@ACC_NAME 		varchar(50),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '''';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SLNO from FLEX_ACC 
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ACC_NO=ACC_NO,@ACC_NAME=ACC_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM FLEX_ACC 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = ''D'')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE FLEX_ACC_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			SELECT @RET_MOD_NO = @MOD_NO + 1;

			INSERT INTO 
				FLEX_ACC_HIST (SLNO, ACC_NO, ACC_NAME,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@SLNO, @ACC_NO, @ACC_NAME, 
				substring(suser_name(),charindex(''\'',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				''D'', 0)

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0				
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			COMMIT TRANSACTION;
			RETURN 0;
				
		END;
	ELSE 
		BEGIN			
			-- item might exist in hist table
			IF EXISTS(SELECT SLNO from FLEX_ACC_HIST 
					  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE FLEX_ACC_HIST
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0				
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO = @MOD_NO-1;

					COMMIT TRANSACTION;
					RETURN 0;			


				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END
			
		END		
    
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FlexAcc_GetDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 04-Jul-13
-- Description:	Get detail of FlexAcc table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FlexAcc_GetDetail]	
	@SLNO	numeric(3,0),	
	@MOD_NO	int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT SLNO 
			   FROM FLEX_ACC WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,''IS_AUTH''=1 
			FROM FLEX_ACC 
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * 
			FROM FLEX_ACC_HIST
			WHERE SLNO=@SLNO AND MOD_NO = @MOD_NO
		END
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_FlexAcc_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 04-Jul-13
-- Description:	update detail to FlexAcc table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_FlexAcc_Update]	
	@SLNO		numeric(3,0),
	@ACC_NO 	varchar(16),
	@ACC_NAME 	varchar(50),	
	@MOD_NO		int,
	@RET_MOD_NO	int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	IF EXISTS(SELECT SLNO FROM FLEX_ACC 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE FLEX_ACC_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO FLEX_ACC_HIST(SLNO, ACC_NO,ACC_NAME,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@SLNO, @ACC_NO,@ACC_NAME,
				substring(suser_name(),charindex(''\'',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,''U'',0);

			SELECT @ErrorVar = @@ERROR;

			IF @ErrorVar <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END				

			COMMIT TRANSACTION;
			
			RETURN 0;

				
		END
	ELSE -- might be in hist table
		BEGIN

			IF EXISTS(SELECT SLNO from FLEX_ACC_HIST 
						WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE FLEX_ACC_HIST WHERE SLNO=@SLNO AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END

					INSERT INTO FLEX_ACC_HIST(SLNO, ACC_NO,ACC_NAME,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@SLNO, @ACC_NO,@ACC_NAME,
						substring(suser_name(),charindex(''\'',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,''U'',0);

					SELECT @ErrorVar = @@ERROR;
		
					IF @ErrorVar <> 0
						BEGIN
							ROLLBACK TRANSACTION;
							RETURN 1;
						END
					
					SELECT @RET_MOD_NO=@MOD_NO;
					
					COMMIT TRANSACTION;
					RETURN 0;
			
				END
			ELSE
				BEGIN
					-- not exist
					ROLLBACK TRANSACTION;
					RETURN 4;
				END

		END
    
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Process_AfterBookingCheck]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_AfterBookingCheck]			
	@REF_NO		VARCHAR(10) output
AS
BEGIN	
	DECLARE @ErrorVar INT,
		@vRevDate datetime,
		@vAmount numeric(14,2);
			
	
	SET NOCOUNT ON;

	exec CMS_Process_Holiday;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END

	DELETE TMP_CR_BOOKING;
	DELETE TMP_DR_BOOKING;

	DECLARE CURSORCASH CURSOR FOR
		SELECT REV_DATE,sum(AMOUNT) as total FROM
			TMP_BOOKING 
			WHERE DEP_TYP=''CASH'' 
			GROUP by REV_DATE order by REV_DATE;
		

	OPEN CURSORCASH;
	FETCH NEXT FROM CURSORCASH 
        INTO @vRevDate,@vAmount;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_CR_BOOKING(CRED_TYPE, SUNACC_NO,SUNDRY_REFACC_NO, AMOUNT, REF_NO, VALUE_DATE, REV_DATE, DAYS, REMARKS, DEP_TYP)
			VALUES(''1'',''G010009275600005'',''G010009275600005'',@vAmount,RIGHT(''0000000000'' + @REF_NO, 10),
			CONVERT(datetime,convert(varchar(12), GETDATE())),
			@vRevDate,'''',''Cash'',''CASH'');
		
		SELECT @REF_NO =  @REF_NO + 1;

		FETCH NEXT FROM CURSORCASH 
		INTO @vRevDate,@vAmount;
	END

	CLOSE CURSORCASH;
	DEALLOCATE CURSORCASH;
--2

	DECLARE CURSORSPEED CURSOR FOR
		SELECT REV_DATE,sum(AMOUNT) as total FROM
			TMP_BOOKING 
			WHERE DEP_TYP=''CHECK'' 
			GROUP by REV_DATE order by REV_DATE;	

	OPEN CURSORSPEED;
	FETCH NEXT FROM CURSORSPEED 
        INTO @vRevDate,@vAmount;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_CR_BOOKING(CRED_TYPE, SUNACC_NO,SUNDRY_REFACC_NO, AMOUNT, REF_NO, VALUE_DATE, REV_DATE, DAYS, REMARKS, DEP_TYP)
			VALUES(''1'',''G010009275570009'',''G010009275570009'',@vAmount,RIGHT(''0000000000'' + @REF_NO, 10),
			CONVERT(datetime,convert(varchar(12), GETDATE())),
			@vRevDate,'''',''Speed'',''CHECK'');
		
		SELECT @REF_NO =  @REF_NO + 1;

		FETCH NEXT FROM CURSORSPEED 
		INTO @vRevDate,@vAmount;
	END

	CLOSE CURSORSPEED;
	DEALLOCATE CURSORSPEED;
         
END

' 
END
