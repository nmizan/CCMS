USE [CCMS]
GO
/****** Object:  Role [ccms_sp_only]    Script Date: 03/03/2013 11:52:02 ******/
EXEC dbo.sp_addrole @rolename = N'ccms_sp_only'
GO
/****** Object:  User [SHANTO-PC\shanto]    Script Date: 03/03/2013 11:52:02 ******/
EXEC dbo.sp_grantdbaccess @loginame = N'', @name_in_db = N'SHANTO-PC\shanto'
GO
/****** Object:  User [SHANTOLODI-PC\Shanto]    Script Date: 03/03/2013 11:52:02 ******/
EXEC dbo.sp_grantdbaccess @loginame = N'SHANTOLODI-PC\Shanto', @name_in_db = N'SHANTOLODI-PC\Shanto'
GO
/****** Object:  User [CCL-PC\ccl]    Script Date: 03/03/2013 11:52:02 ******/
EXEC dbo.sp_grantdbaccess @loginame = N'', @name_in_db = N'CCL-PC\ccl'
GO
/****** Object:  Table [dbo].[CSD_DET]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSD_DET](
	[D_CODE] [varchar](12) NOT NULL,
	[SLNO] [numeric](3, 0) NOT NULL,
	[CHECK_NO] [varchar](15) NULL,
	[DRAWER] [varchar](50) NULL,
	[DRAWEE_BANK_CODE] [varchar](4) NULL,
	[AMOUNT] [numeric](12, 2) NULL,
	[CUSTOMER_REF] [varchar](15) NULL,
	[SLIP_DATE] [datetime] NULL,
	[CHECK_DATE] [datetime] NULL,
	[DRAWEE_BRANCH] [varchar](50) NULL,
	[CHECK_REF] [varchar](15) NULL,
	[RTN_STATUS] [char](1) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK__CSD_DET__373B3228] PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SCHEDULE_STOCK]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SCHEDULE_STOCK](
	[SCHEDULE_ID] [tinyint] NOT NULL,
	[BANK_CODE] [varchar](4) NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[SCHE_FROM] [varchar](12) NULL,
	[SCHE_UPTO] [varchar](12) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SCHEDULE_ID] ASC,
	[BANK_CODE] ASC,
	[LOCATION_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSD_DET_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSD_DET_HIST](
	[D_CODE] [varchar](12) NOT NULL,
	[SLNO] [numeric](3, 0) NOT NULL,
	[CHECK_NO] [varchar](15) NULL,
	[DRAWER] [varchar](50) NULL,
	[DRAWEE_BANK_CODE] [varchar](4) NULL,
	[AMOUNT] [numeric](12, 2) NULL,
	[CUSTOMER_REF] [varchar](15) NULL,
	[SLIP_DATE] [datetime] NULL,
	[CHECK_DATE] [datetime] NULL,
	[DRAWEE_BRANCH] [varchar](50) NULL,
	[CHECK_REF] [varchar](15) NULL,
	[RTN_STATUS] [char](1) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__CSD_DET_HIST__39237A9A] PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SCHEDULE_STOCK_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SCHEDULE_STOCK_HIST](
	[SCHEDULE_ID] [tinyint] NOT NULL,
	[BANK_CODE] [varchar](4) NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[SCHE_FROM] [varchar](12) NULL,
	[SCHE_UPTO] [varchar](12) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SCHEDULE_ID] ASC,
	[BANK_CODE] ASC,
	[LOCATION_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MENU_LIST_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MENU_LIST_HIST](
	[SLNO] [numeric](6, 0) NOT NULL,
	[MENU_NAME] [varchar](60) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__MENU_LIST_HIST__09A971A2] PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetail]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  Table [dbo].[MENU_LIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MENU_LIST](
	[SLNO] [numeric](6, 0) NOT NULL,
	[MENU_NAME] [varchar](60) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__MENU_LIST__07C12930] PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VERSION]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VERSION](
	[MIN_MAJOR] [int] NOT NULL,
	[MIN_MINOR] [int] NOT NULL,
	[MIN_BUILD] [int] NOT NULL,
	[MAX_MAJOR] [int] NOT NULL,
	[MAX_MINOR] [int] NOT NULL,
	[MAX_BUILD] [int] NOT NULL,
	[CHK] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSCHEDULE]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DSCHEDULE](
	[DS_CODE] [varchar](12) NOT NULL,
	[D_CODE] [varchar](12) NOT NULL,
	[DEPOSIT_TYPE] [varchar](5) NOT NULL,
	[CITICASH_AMOUNT] [numeric](12, 2) NULL,
	[CITICHECK_AMOUNT] [numeric](12, 2) NULL,
	[SCHEDULE_DATE] [datetime] NOT NULL,
	[NO_CHECK] [numeric](4, 0) NULL,
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[CORR_BANK_CODE] [varchar](4) NULL,
	[CORR_BRANCH_CODE] [varchar](4) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[FILENAME] [varchar](15) NULL,
	[REF_NO] [varchar](10) NULL,
	[FILE_USER_ID] [varchar](20) NULL,
	[SEQ_NO] [numeric](4, 0) NULL,
	[CHECKED] [tinyint] NULL,
	[FLEXGEN_DATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DS_CODE] ASC,
	[D_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FORM_LIST_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FORM_LIST_HIST](
	[SLNO] [numeric](6, 0) NOT NULL,
	[FORMS_NAME] [varchar](60) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__FORM_LIST_HIST__05D8E0BE] PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYSTEM_LOG]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYSTEM_LOG](
	[LOG_DATETIME] [datetime] NOT NULL,
	[LOG_DESCRIPTION] [varchar](256) NOT NULL,
	[LOG_USER] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FORM_LIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FORM_LIST](
	[SLNO] [numeric](6, 0) NOT NULL,
	[FORMS_NAME] [varchar](60) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__FORM_LIST__03F0984C] PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DCOLLECTED]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DCOLLECTED](
	[DS_CODE] [varchar](12) NOT NULL,
	[TOTAL_NOCHK] [numeric](4, 0) NULL,
	[TOTAL_CHKAMT] [numeric](12, 2) NULL,
	[TOTAL_CASHAMT] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DS_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetMaxMod]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  Table [dbo].[CLIENT]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENT](
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[ACC_NO] [varchar](16) NOT NULL,
	[ACC_NAME] [varchar](50) NOT NULL,
	[MAIL_ADD] [varchar](256) NULL,
	[CONTACT] [varchar](50) NULL,
	[CASH_DAYS] [numeric](2, 0) NULL,
	[SPEED_DAYS] [numeric](2, 0) NULL,
	[CASH_CR_TYPE] [varchar](25) NULL,
	[SPEED_CR_TYPE] [varchar](25) NULL,
	[CASH_CHARGE] [numeric](12, 2) NULL,
	[SPEED_CHARGE] [numeric](12, 2) NULL,
	[RETURN_CHARGE] [numeric](12, 2) NULL,
	[CASH_STD_CHARGE] [numeric](12, 2) NULL,
	[SPEED_STD_CHARGE] [numeric](12, 2) NULL,
	[CASH_VAT] [numeric](8, 2) NULL,
	[SPEED_VAT] [numeric](8, 2) NULL,
	[CITIANY_CHARGE] [numeric](12, 2) NULL,
	[CITIANY_STD_CHARGE] [numeric](12, 2) NULL,
	[CITIANY_VAT] [numeric](8, 2) NULL,
	[BILLING_TYPE] [varchar](25) NULL,
	[IS_DISABLE] [bit] NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__CLIENT__5F7E2DAC] PRIMARY KEY CLUSTERED 
(
	[CLIENT_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DCOLLECTED_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DCOLLECTED_HIST](
	[DS_CODE] [varchar](12) NOT NULL,
	[TOTAL_NOCHK] [numeric](4, 0) NULL,
	[TOTAL_CHKAMT] [numeric](12, 2) NULL,
	[TOTAL_CASHAMT] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DS_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENT_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENT_HIST](
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[ACC_NO] [varchar](16) NOT NULL,
	[ACC_NAME] [varchar](50) NOT NULL,
	[MAIL_ADD] [varchar](256) NULL,
	[CONTACT] [varchar](50) NULL,
	[CASH_DAYS] [numeric](2, 0) NULL,
	[SPEED_DAYS] [numeric](2, 0) NULL,
	[CASH_CR_TYPE] [varchar](25) NULL,
	[SPEED_CR_TYPE] [varchar](25) NULL,
	[CASH_CHARGE] [numeric](12, 2) NULL,
	[SPEED_CHARGE] [numeric](12, 2) NULL,
	[RETURN_CHARGE] [numeric](12, 2) NULL,
	[CASH_STD_CHARGE] [numeric](12, 2) NULL,
	[SPEED_STD_CHARGE] [numeric](12, 2) NULL,
	[CASH_VAT] [numeric](8, 2) NULL,
	[SPEED_VAT] [numeric](8, 2) NULL,
	[CITIANY_CHARGE] [numeric](12, 2) NULL,
	[CITIANY_STD_CHARGE] [numeric](12, 2) NULL,
	[CITIANY_VAT] [numeric](8, 2) NULL,
	[BILLING_TYPE] [varchar](25) NULL,
	[IS_DISABLE] [bit] NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__CLIENT_HIST__6166761E] PRIMARY KEY CLUSTERED 
(
	[CLIENT_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetailList]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM BANK_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM BANK
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,BANK_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM BANK_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM BANK
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,BANK_CODE

		END
	
	   
END
GO
/****** Object:  Table [dbo].[LOCATION]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOCATION](
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[LOCATION_NAME] [varchar](35) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LOCATION_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCHECK]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCHECK](
	[SLNO] [numeric](3, 0) NOT NULL,
	[D_CODE] [varchar](12) NOT NULL,
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[DLOCATION_CODE] [varchar](4) NOT NULL,
	[CUSTOMER_REF] [varchar](15) NOT NULL,
	[SLIP_DATE] [datetime] NOT NULL,
	[VALUE_DATE] [datetime] NOT NULL,
	[CHECK_NO] [varchar](15) NOT NULL,
	[AMOUNT] [numeric](12, 2) NOT NULL,
	[CHECK_DATE] [datetime] NOT NULL,
	[CHECK_TYPE] [varchar](7) NOT NULL,
	[DRAWER] [varchar](50) NOT NULL,
	[DRAWEE_BANK_CODE] [varchar](4) NOT NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[BRANCH_CODE] [varchar](4) NULL,
	[CHECK_REF] [varchar](15) NULL,
	[RTN_STATUS] [char](1) NULL,
	[NONZONE_REF] [varchar](7) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK__CCHECK__52E34C9D] PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetCorrBankListByLoc]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	WHERE b.STATUS='L' 
	AND br.CORRBANK=1 AND br.LOCATION_CODE=@LOCATION_CODE
	ORDER BY BANK_NAME;	
	   
END
GO
/****** Object:  Table [dbo].[LOCATION_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOCATION_HIST](
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[LOCATION_NAME] [varchar](35) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LOCATION_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCHECK_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCHECK_HIST](
	[SLNO] [numeric](3, 0) NOT NULL,
	[D_CODE] [varchar](12) NOT NULL,
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[DLOCATION_CODE] [varchar](4) NOT NULL,
	[CUSTOMER_REF] [varchar](15) NOT NULL,
	[SLIP_DATE] [datetime] NOT NULL,
	[VALUE_DATE] [datetime] NOT NULL,
	[CHECK_NO] [varchar](15) NOT NULL,
	[AMOUNT] [numeric](12, 2) NOT NULL,
	[CHECK_DATE] [datetime] NOT NULL,
	[CHECK_TYPE] [varchar](7) NOT NULL,
	[DRAWER] [varchar](50) NOT NULL,
	[DRAWEE_BANK_CODE] [varchar](4) NOT NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[BRANCH_CODE] [varchar](4) NULL,
	[CHECK_REF] [varchar](15) NULL,
	[RTN_STATUS] [char](1) NULL,
	[NONZONE_REF] [varchar](7) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__CCHECK_HIST__589C25F3] PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[MOD_NO] ASC,
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_GetList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	WHERE STATUS='L' 	
	ORDER BY ACC_NAME;
	   
END
GO
/****** Object:  Table [dbo].[BRANCH]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BRANCH](
	[BANK_CODE] [varchar](4) NOT NULL,
	[BRANCH_CODE] [varchar](4) NOT NULL,
	[BRANCH_NAME] [varchar](35) NULL,
	[ROUTING_NO] [varchar](9) NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[BRANCH_ADD1] [varchar](35) NULL,
	[BRANCH_ADD2] [varchar](35) NULL,
	[CLEARING_ZONE] [varchar](4) NULL,
	[CORRBANK] [bit] NULL,
	[NIKBRANCH_CODE] [varchar](7) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__BRANCH__4D94879B] PRIMARY KEY CLUSTERED 
(
	[BANK_CODE] ASC,
	[BRANCH_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetDetailByCode]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Dec-12
-- Description:	Get detail of branch by branch code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetailByCode]	
	@BRANCH_CODE		varchar(4)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM BRANCH 
	WHERE BRANCH_CODE=@BRANCH_CODE
 
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetCorrBranchListByLoc]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	WHERE br.STATUS='L'
	AND br.CORRBANK=1 AND br.LOCATION_CODE=@LOCATION_CODE
	ORDER BY BANK_NAME,BRANCH_NAME
	   
END
GO
/****** Object:  Table [dbo].[BRANCH_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BRANCH_HIST](
	[BANK_CODE] [varchar](4) NOT NULL,
	[BRANCH_CODE] [varchar](4) NOT NULL,
	[BRANCH_NAME] [varchar](35) NULL,
	[ROUTING_NO] [varchar](9) NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[BRANCH_ADD1] [varchar](35) NULL,
	[BRANCH_ADD2] [varchar](35) NULL,
	[CLEARING_ZONE] [varchar](4) NULL,
	[CORRBANK] [bit] NULL,
	[NIKBRANCH_CODE] [varchar](7) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__BRANCH_HIST__4F7CD00D] PRIMARY KEY CLUSTERED 
(
	[BANK_CODE] ASC,
	[BRANCH_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_CodeVerify]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	AND STATUS='L';

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetCorrBranchListByBank]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	WHERE STATUS='L' 
	AND CORRBANK=1 AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END
GO
/****** Object:  Table [dbo].[DSCHEDULE_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DSCHEDULE_HIST](
	[DS_CODE] [varchar](12) NOT NULL,
	[D_CODE] [varchar](12) NOT NULL,
	[DEPOSIT_TYPE] [varchar](5) NOT NULL,
	[CITICASH_AMOUNT] [numeric](12, 2) NULL,
	[CITICHECK_AMOUNT] [numeric](12, 2) NULL,
	[SCHEDULE_DATE] [datetime] NOT NULL,
	[NO_CHECK] [numeric](4, 0) NULL,
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[CORR_BANK_CODE] [varchar](4) NULL,
	[CORR_BRANCH_CODE] [varchar](4) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__DSCHEDULE_HIST__10216507] PRIMARY KEY CLUSTERED 
(
	[DS_CODE] ASC,
	[D_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[F_GROUP]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[F_GROUP](
	[SLNO] [numeric](6, 0) NOT NULL,
	[FG_ID] [varchar](50) NOT NULL,
	[FG_NAME] [varchar](50) NOT NULL,
	[DEPT_SLNO] [numeric](3, 0) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZONE]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ZONE](
	[ZONE_CODE] [varchar](4) NOT NULL,
	[ZONE_NAME] [varchar](35) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ZONE_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZONE_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ZONE_HIST](
	[ZONE_CODE] [varchar](4) NOT NULL,
	[ZONE_NAME] [varchar](35) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__ZONE_HIST__239E4DCF] PRIMARY KEY CLUSTERED 
(
	[ZONE_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[F_GROUP_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[F_GROUP_HIST](
	[SLNO] [numeric](6, 0) NOT NULL,
	[FG_ID] [varchar](50) NOT NULL,
	[FG_NAME] [varchar](50) NOT NULL,
	[DEPT_SLNO] [numeric](3, 0) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERM_FORMS]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERM_FORMS](
	[FG_SLNO] [numeric](6, 0) NOT NULL,
	[FORM_SLNO] [numeric](6, 0) NOT NULL,
	[IS_SHOW] [bit] NULL,
	[IS_NEW] [bit] NULL,
	[IS_UNLOCK] [bit] NULL,
	[IS_AUTHORIZER] [bit] NULL,
	[IS_DELETE] [bit] NULL,
	[IS_SAVE] [bit] NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FG_SLNO] ASC,
	[FORM_SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CCASH]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCASH](
	[D_CODE] [varchar](12) NOT NULL,
	[CUSTOMER_REF] [varchar](15) NULL,
	[CASH_REF] [varchar](15) NULL,
	[SLIP_DATE] [datetime] NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GENPRM]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GENPRM](
	[BATCH_NO] [varchar](4) NULL,
	[REF_NO] [varchar](10) NULL,
	[REGSEQ_NO] [varchar](7) NULL,
	[BATCH_DATE] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCASH_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCASH_HIST](
	[D_CODE] [varchar](12) NOT NULL,
	[CUSTOMER_REF] [varchar](15) NULL,
	[CASH_REF] [varchar](15) NULL,
	[SLIP_DATE] [datetime] NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERM_MENUS]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERM_MENUS](
	[FG_SLNO] [numeric](6, 0) NOT NULL,
	[MENU_SLNO] [numeric](6, 0) NOT NULL,
	[IS_VISIBLE] [bit] NULL,
	[IS_ENABLE] [bit] NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FG_SLNO] ASC,
	[MENU_SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERM_MENUS_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERM_MENUS_HIST](
	[FG_SLNO] [numeric](6, 0) NOT NULL,
	[MENU_SLNO] [numeric](6, 0) NOT NULL,
	[IS_VISIBLE] [bit] NULL,
	[IS_ENABLE] [bit] NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FG_SLNO] ASC,
	[MENU_SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TMP_BOOKING]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMP_BOOKING](
	[ROW_ID] [uniqueidentifier] NULL DEFAULT (newid()),
	[REF_NO] [varchar](10) NULL,
	[AMOUNT] [numeric](12, 2) NULL,
	[VALUE_DATE] [datetime] NULL,
	[REV_DATE] [datetime] NULL,
	[ACC_NO] [varchar](16) NULL,
	[REFACC_NO] [varchar](16) NULL,
	[DAYS] [varchar](2) NULL,
	[D_CODE] [varchar](12) NULL,
	[DEP_TYP] [varchar](15) NULL,
	[SUNDRY_REFACC_NO] [varchar](16) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RETURN_REJECT]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RETURN_REJECT](
	[REJECT_CODE] [varchar](2) NOT NULL,
	[REJECT_REASON] [varchar](100) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[REJECT_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERM_FORMS_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERM_FORMS_HIST](
	[FG_SLNO] [numeric](6, 0) NOT NULL,
	[FORM_SLNO] [numeric](6, 0) NOT NULL,
	[IS_SHOW] [bit] NULL,
	[IS_NEW] [bit] NULL,
	[IS_UNLOCK] [bit] NULL,
	[IS_AUTHORIZER] [bit] NULL,
	[IS_DELETE] [bit] NULL,
	[IS_SAVE] [bit] NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__PERM_FORMS_HIST__282DF8C2] PRIMARY KEY CLUSTERED 
(
	[FG_SLNO] ASC,
	[FORM_SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RETURN_REJECT_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RETURN_REJECT_HIST](
	[REJECT_CODE] [varchar](2) NOT NULL,
	[REJECT_REASON] [varchar](100) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[REJECT_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TMP_CR_BOOKING]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMP_CR_BOOKING](
	[ROW_ID] [uniqueidentifier] NULL DEFAULT (newid()),
	[CRED_TYPE] [varchar](3) NULL,
	[SUNACC_NO] [varchar](16) NULL,
	[AMOUNT] [numeric](14, 2) NULL,
	[REF_NO] [varchar](10) NULL,
	[VALUE_DATE] [datetime] NULL,
	[REV_DATE] [datetime] NULL,
	[DAYS] [varchar](2) NULL,
	[REMARKS] [varchar](80) NULL,
	[DEP_TYP] [varchar](5) NULL,
	[SUNDRY_REFACC_NO] [varchar](16) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TMP_DR_BOOKING]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMP_DR_BOOKING](
	[ROW_ID] [uniqueidentifier] NULL DEFAULT (newid()),
	[CRED_TYPE] [varchar](3) NULL,
	[SUNACC_NO] [varchar](16) NULL,
	[AMOUNT] [numeric](14, 2) NULL,
	[REF_NO] [varchar](10) NULL,
	[VALUE_DATE] [datetime] NULL,
	[REV_DATE] [datetime] NULL,
	[DAYS] [varchar](2) NULL,
	[REMARKS] [varchar](80) NULL,
	[DEP_TYP] [varchar](5) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSD]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSD](
	[D_CODE] [varchar](12) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSD_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSD_HIST](
	[D_CODE] [varchar](12) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHECKTYPE]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHECKTYPE](
	[CHECKTYPE_CODE] [varchar](8) NOT NULL,
	[CHECKTYPE_NAME] [varchar](50) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CHECKTYPE_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHECKTYPE_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHECKTYPE_HIST](
	[CHECKTYPE_CODE] [varchar](8) NOT NULL,
	[CHECKTYPE_NAME] [varchar](50) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CHECKTYPE_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSDDet_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		DRAWEE_BRANCH, CHECK_REF,
		MOD_NO,IS_AUTH)
		VALUES(@D_CODE, @SLNO, @CHECK_NO, @DRAWER, 
		@DRAWEE_BANK_CODE, @AMOUNT,@CUSTOMER_REF, @SLIP_DATE, @CHECK_DATE,
		@DRAWEE_BRANCH, @CHECK_REF,
		1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
GO
/****** Object:  Table [dbo].[USERS_FG]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS_FG](
	[USERS_ID] [varchar](20) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK_USERS_FG] PRIMARY KEY CLUSTERED 
(
	[USERS_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSDDet_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@MOD_NO				int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO CSD_DET_HIST(D_CODE, SLNO, CHECK_NO, DRAWER, 
		DRAWEE_BANK_CODE, AMOUNT,CUSTOMER_REF, SLIP_DATE, CHECK_DATE,
		DRAWEE_BRANCH, CHECK_REF,
		MOD_NO, IS_AUTH)
		VALUES(@D_CODE, @SLNO, @CHECK_NO, @DRAWER, 
		@DRAWEE_BANK_CODE, @AMOUNT,@CUSTOMER_REF, @SLIP_DATE, @CHECK_DATE,
		@DRAWEE_BRANCH, @CHECK_REF,
		@MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END
GO
/****** Object:  Table [dbo].[USERS_FG_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS_FG_HIST](
	[USERS_ID] [varchar](20) NOT NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK_USERS_FG_HIST] PRIMARY KEY CLUSTERED 
(
	[USERS_ID] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CITIBANK_BRANCH]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CITIBANK_BRANCH](
	[BRANCH_CODE] [varchar](3) NOT NULL,
	[BRANCH_NAME] [varchar](35) NOT NULL,
	[ADDRESS1] [varchar](35) NULL,
	[ADDRESS2] [varchar](35) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BRANCH_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSDDet_GetDetails]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT cd.*,'IS_AUTH'=1,b.BANK_NAME
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
GO
/****** Object:  Table [dbo].[CITIBANK_BRANCH_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CITIBANK_BRANCH_HIST](
	[BRANCH_CODE] [varchar](3) NOT NULL,
	[BRANCH_NAME] [varchar](35) NOT NULL,
	[ADDRESS1] [varchar](35) NULL,
	[ADDRESS2] [varchar](35) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BRANCH_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRAN_STATUS]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRAN_STATUS](
	[STATUS_ID] [tinyint] NOT NULL,
	[STATUS_NAME] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[STATUS_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_FG_DET]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS_FG_DET](
	[USERS_ID] [varchar](20) NOT NULL,
	[FG_SLNO] [numeric](6, 0) NOT NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[USERS_ID] ASC,
	[FG_SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCHECKTOTAL]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCHECKTOTAL](
	[D_CODE] [varchar](12) NOT NULL,
	[TOTAL_CHKNO] [numeric](4, 0) NULL,
	[TOTAL_CHKAMT] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_FG_DET_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS_FG_DET_HIST](
	[USERS_ID] [varchar](20) NOT NULL,
	[FG_SLNO] [numeric](6, 0) NOT NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[USERS_ID] ASC,
	[FG_SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCMSREF_TAB]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCMSREF_TAB](
	[REF_NO] [varchar](10) NOT NULL,
	[AMOUNT] [numeric](14, 2) NULL,
	[VALUE_DATE] [datetime] NULL,
	[USERID] [varchar](20) NULL,
	[UPLOADED] [varchar](15) NULL,
	[REVERGEN] [varchar](15) NULL,
	[FILENAME] [varchar](15) NULL,
	[REV_DATE] [datetime] NULL,
	[ACC_NO] [varchar](16) NULL,
	[REFACC_NO] [varchar](16) NULL,
	[D_CODE] [varchar](12) NULL,
	[SUNDRY_REFACC_NO] [varchar](16) NULL,
	[FLEXGEN_DATE] [datetime] NULL,
	[STATUS_ID] [tinyint] NULL,
	[REMARKS] [varchar](100) NULL,
	[AUTHORIZE] [tinyint] NULL,
	[AUTHORIZER_ID] [varchar](20) NULL,
 CONSTRAINT [PK__CCMSREF_TAB__4277DAAA] PRIMARY KEY CLUSTERED 
(
	[REF_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCHECKTOTAL_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCHECKTOTAL_HIST](
	[D_CODE] [varchar](12) NOT NULL,
	[TOTAL_CHKNO] [numeric](4, 0) NULL,
	[TOTAL_CHKAMT] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TMP_REVERSAL]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMP_REVERSAL](
	[REF_NO] [varchar](10) NOT NULL,
	[AMOUNT] [numeric](14, 2) NULL,
	[VALUE_DATE] [datetime] NULL,
	[USERID] [varchar](20) NULL,
	[UPLOADED] [varchar](15) NULL,
	[REVERGEN] [varchar](15) NULL,
	[FILENAME] [varchar](15) NULL,
	[REV_DATE] [datetime] NULL,
	[CLIENT_CODE] [char](15) NULL,
	[REFACC_NO] [varchar](16) NULL,
	[DEPOSIT_TYPE] [varchar](5) NULL,
	[ACC_NO] [varchar](16) NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[CR_TYPE] [varchar](2) NULL,
	[DS_CODE] [varchar](15) NULL,
	[SEQ_NO] [numeric](3, 0) NULL,
	[SUNDRY_REFACC_NO] [varchar](16) NULL,
	[FLEXGEN_DATE] [datetime] NULL,
	[CHECKDS_NO] [varchar](30) NULL,
	[CUSTOMER_REF] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[REF_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetListByBank]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	WHERE STATUS='L' 
	AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END
GO
/****** Object:  Table [dbo].[CCMSREF_TAB_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCMSREF_TAB_HIST](
	[REF_NO] [varchar](10) NOT NULL,
	[AMOUNT] [numeric](14, 2) NULL,
	[VALUE_DATE] [datetime] NULL,
	[USERID] [varchar](20) NULL,
	[UPLOADED] [varchar](15) NULL,
	[REVERGEN] [varchar](15) NULL,
	[FILENAME] [varchar](15) NULL,
	[REV_DATE] [datetime] NULL,
	[ACC_NO] [varchar](16) NULL,
	[REFACC_NO] [varchar](16) NULL,
	[D_CODE] [varchar](12) NULL,
	[SUNDRY_REFACC_NO] [varchar](16) NULL,
	[FLEXGEN_DATE] [datetime] NULL,
	[STATUS_ID] [tinyint] NULL,
	[REMARKS] [varchar](100) NULL,
	[AUTHORIZE] [tinyint] NULL,
	[AUTHORIZER_ID] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[REF_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheckTotal_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[REVERSAL_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[REVERSAL_HIST](
	[REF_NO] [varchar](10) NOT NULL,
	[AMOUNT] [numeric](14, 2) NULL,
	[VALUE_DATE] [datetime] NULL,
	[USERID] [varchar](20) NULL,
	[UPLOADED] [varchar](15) NULL,
	[REVERGEN] [varchar](15) NULL,
	[FILENAME] [varchar](15) NULL,
	[REV_DATE] [datetime] NULL,
	[CLIENT_CODE] [char](15) NULL,
	[REFACC_NO] [varchar](16) NULL,
	[DEPOSIT_TYPE] [varchar](5) NULL,
	[ACC_NO] [varchar](16) NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[CR_TYPE] [varchar](2) NULL,
	[DS_CODE] [varchar](15) NULL,
	[SEQ_NO] [numeric](3, 0) NULL,
	[SUNDRY_REFACC_NO] [varchar](16) NULL,
	[FLEXGEN_DATE] [datetime] NULL,
	[CHECKDS_NO] [varchar](30) NULL,
	[CUSTOMER_REF] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[REF_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheck_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		LOCATION_CODE, BRANCH_CODE, CHECK_REF,
		MOD_NO,IS_AUTH)
		VALUES(@SLNO, @D_CODE, @CLIENT_CODE, @DLOCATION_CODE, 
		@CUSTOMER_REF, @SLIP_DATE, @VALUE_DATE, @CHECK_NO, @AMOUNT, 
		@CHECK_DATE, @CHECK_TYPE, @DRAWER, @DRAWEE_BANK_CODE, 
		@LOCATION_CODE, @BRANCH_CODE, @CHECK_REF,
		1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheck_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO CCHECK_HIST(SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, 
		LOCATION_CODE, BRANCH_CODE, CHECK_REF,
		MOD_NO, IS_AUTH)
		VALUES(@SLNO, @D_CODE, @CLIENT_CODE, @DLOCATION_CODE, 
		@CUSTOMER_REF, @SLIP_DATE, @VALUE_DATE, @CHECK_NO, @AMOUNT, 
		@CHECK_DATE, @CHECK_TYPE, @DRAWER, @DRAWEE_BANK_CODE, 
		@LOCATION_CODE, @BRANCH_CODE, @CHECK_REF,
		@MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetList]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	get list records of bank table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT BANK_CODE,BANK_NAME FROM BANK WHERE STATUS='L'
	ORDER BY BANK_NAME;
	
	   
END
GO
/****** Object:  Table [dbo].[DD]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DD](
	[D_CODE] [varchar](12) NOT NULL,
	[SLNO] [int] NOT NULL,
	[DD_NO] [varchar](18) NOT NULL,
	[DD_DATE] [datetime] NULL,
	[AMOUNT] [numeric](12, 2) NULL,
	[DRAWER_BANKCODE] [varchar](4) NULL,
	[DRAWER_BRANCHCODE] [varchar](4) NULL,
	[DRAWER_LOCATION] [varchar](4) NULL,
	[DRAWEE_BRANCH] [varchar](25) NULL,
	[NIKBRANCH_CODE] [varchar](7) NULL,
	[VAT] [numeric](12, 2) NULL,
	[COMMISION] [numeric](12, 2) NULL,
	[POSTAGE_CHARGE] [numeric](12, 2) NULL,
	[INSTRUMENT_EXP] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[RTN_STATUS] [char](1) NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__DD__1F2E9E6D] PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DD_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DD_HIST](
	[D_CODE] [varchar](12) NOT NULL,
	[SLNO] [int] NOT NULL,
	[DD_NO] [varchar](18) NOT NULL,
	[DD_DATE] [datetime] NULL,
	[AMOUNT] [numeric](12, 2) NULL,
	[DRAWER_BANKCODE] [varchar](4) NULL,
	[DRAWER_BRANCHCODE] [varchar](4) NULL,
	[DRAWER_LOCATION] [varchar](4) NULL,
	[DRAWEE_BRANCH] [varchar](25) NULL,
	[NIKBRANCH_CODE] [varchar](7) NULL,
	[VAT] [numeric](12, 2) NULL,
	[COMMISION] [numeric](12, 2) NULL,
	[POSTAGE_CHARGE] [numeric](12, 2) NULL,
	[INSTRUMENT_EXP] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[RTN_STATUS] [char](1) NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[D_CODE] ASC,
	[MOD_NO] ASC,
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENT]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEPARTMENT](
	[SLNO] [numeric](3, 0) NOT NULL,
	[DEPT_ID] [varchar](5) NOT NULL,
	[DEPT_NAME] [varchar](50) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DD_NCOLLECTION_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DD_NCOLLECTION_HIST](
	[DDREFNO] [varchar](20) NOT NULL,
	[NONZONE_REF] [varchar](7) NOT NULL,
	[AMOUNT] [numeric](12, 2) NULL,
	[CHECKREF] [varchar](15) NULL,
	[VAT] [numeric](12, 2) NULL,
	[COMMISION] [numeric](12, 2) NULL,
	[POSTAGE_CHARGE] [numeric](12, 2) NULL,
	[INSTRUMENT_EXP] [numeric](12, 2) NULL,
	[RTN_STATUS] [char](1) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NONZONE_REF] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANK]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANK](
	[BANK_CODE] [varchar](4) NOT NULL,
	[BANK_NAME] [varchar](100) NOT NULL,
	[HEAD_ADD1] [varchar](35) NULL,
	[HEAD_ADD2] [varchar](35) NULL,
	[HEAD_ADD3] [varchar](20) NULL,
	[BANK_BBK_CODE] [varchar](9) NULL,
	[ACC_NO] [varchar](16) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__BANK__7E6CC920] PRIMARY KEY CLUSTERED 
(
	[BANK_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENT_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEPARTMENT_HIST](
	[SLNO] [numeric](3, 0) NOT NULL,
	[DEPT_ID] [varchar](5) NOT NULL,
	[DEPT_NAME] [varchar](50) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SLNO] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DD_CCHECK_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DD_CCHECK_HIST](
	[DEPOSIT_SLNO] [varchar](12) NOT NULL,
	[NONZONE_REF] [varchar](7) NOT NULL,
	[RTN_STATUS] [char](1) NULL,
	[STATUS] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[NONZONE_REF] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANK_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANK_HIST](
	[BANK_CODE] [varchar](4) NOT NULL,
	[BANK_NAME] [varchar](100) NOT NULL,
	[HEAD_ADD1] [varchar](35) NULL,
	[HEAD_ADD2] [varchar](35) NULL,
	[HEAD_ADD3] [varchar](20) NULL,
	[BANK_BBK_CODE] [varchar](9) NULL,
	[ACC_NO] [varchar](16) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__BANK_HIST__00551192] PRIMARY KEY CLUSTERED 
(
	[BANK_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetailByCode]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  Table [dbo].[HOLIDAY]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOLIDAY](
	[HOLI_DAY] [datetime] NOT NULL,
	[HOLI_TYPE] [varchar](20) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HOLI_DAY] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@BILLING_TYPE		varchar(25)
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
		CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
		@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
		@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
		@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
		@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE,
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE CLIENT_CODE=@CLIENT_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
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
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  Table [dbo].[HOLIDAY_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOLIDAY_HIST](
	[HOLI_DAY] [datetime] NOT NULL,
	[HOLI_TYPE] [varchar](20) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[HOLI_DAY] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  Table [dbo].[TOTALCS]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TOTALCS](
	[CS_CODE] [varchar](12) NOT NULL,
	[TOTAL_AMOUNT] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CS_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
				@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
				@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
				@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
				@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE,
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						CITIANY_STD_CHARGE, CITIANY_VAT, BILLING_TYPE,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@CLIENT_CODE, @ACC_NO, @ACC_NAME,@MAIL_ADD,
						@CONTACT, @CASH_DAYS, @SPEED_DAYS, @CASH_CR_TYPE, @SPEED_CR_TYPE,
						@CASH_CHARGE, @SPEED_CHARGE, @RETURN_CHARGE, @CASH_STD_CHARGE,
						@SPEED_STD_CHARGE, @CASH_VAT, @SPEED_VAT, @CITIANY_CHARGE, 
						@CITIANY_STD_CHARGE, @CITIANY_VAT, @BILLING_TYPE,
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_GetDetailList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail to Client table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Client_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM CLIENT_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM CLIENT
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,CLIENT_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM CLIENT_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM CLIENT
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,CLIENT_CODE

		END
	
	   
END
GO
/****** Object:  Table [dbo].[TOTALCS_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TOTALCS_HIST](
	[CS_CODE] [varchar](12) NOT NULL,
	[TOTAL_AMOUNT] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CS_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENT_LOC_CHARGE]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENT_LOC_CHARGE](
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[CASH_DAYS] [numeric](2, 0) NULL,
	[SPEED_DAYS] [numeric](2, 0) NULL,
	[CASH_CHARGE] [numeric](12, 2) NULL,
	[SPEED_CHARGE] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CLIENT_CODE] ASC,
	[LOCATION_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSCHEDULE]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSCHEDULE](
	[CS_CODE] [varchar](12) NOT NULL,
	[SCHEDULE_DATE] [datetime] NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[CORR_BANK_CODE] [varchar](4) NULL,
	[CORR_BRANCH_CODE] [varchar](4) NULL,
	[DS_CODE] [varchar](12) NOT NULL,
	[CITICASH_AMOUNT] [numeric](12, 2) NULL,
	[CITICHECK_AMOUNT] [numeric](12, 2) NULL,
	[NO_CHECK] [numeric](4, 0) NOT NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CS_CODE] ASC,
	[DS_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENT_LOC_CHARGE_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENT_LOC_CHARGE_HIST](
	[CLIENT_CODE] [varchar](6) NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[CASH_DAYS] [numeric](2, 0) NULL,
	[SPEED_DAYS] [numeric](2, 0) NULL,
	[CASH_CHARGE] [numeric](12, 2) NULL,
	[SPEED_CHARGE] [numeric](12, 2) NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CLIENT_CODE] ASC,
	[LOCATION_CODE] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSCHEDULE_HIST]    Script Date: 03/03/2013 11:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSCHEDULE_HIST](
	[CS_CODE] [varchar](12) NOT NULL,
	[SCHEDULE_DATE] [datetime] NOT NULL,
	[LOCATION_CODE] [varchar](4) NOT NULL,
	[CORR_BANK_CODE] [varchar](4) NULL,
	[CORR_BRANCH_CODE] [varchar](4) NULL,
	[DS_CODE] [varchar](12) NOT NULL,
	[CITICASH_AMOUNT] [numeric](12, 2) NULL,
	[CITICHECK_AMOUNT] [numeric](12, 2) NULL,
	[NO_CHECK] [numeric](4, 0) NOT NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CS_CODE] ASC,
	[MOD_NO] ASC,
	[DS_CODE] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_HIST]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS_HIST](
	[USERS_ID] [varchar](20) NOT NULL,
	[USERS_NAME] [varchar](50) NULL,
	[DEPT_SLNO] [numeric](3, 0) NOT NULL,
	[DOMAIN] [varchar](30) NOT NULL,
	[USER_STAT] [char](1) NOT NULL,
	[LAST_LOGIN_DATE] [datetime] NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
	[IS_AUTH] [bit] NOT NULL,
 CONSTRAINT [PK__USERS_HIST__71D1E811] PRIMARY KEY CLUSTERED 
(
	[USERS_ID] ASC,
	[MOD_NO] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Client_GetDetailByCode]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	   
END
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS](
	[USERS_ID] [varchar](20) NOT NULL,
	[USERS_NAME] [varchar](50) NULL,
	[DEPT_SLNO] [numeric](3, 0) NOT NULL,
	[DOMAIN] [varchar](30) NOT NULL,
	[USER_STAT] [char](1) NOT NULL,
	[LAST_LOGIN_DATE] [datetime] NULL,
	[INPUT_BY] [varchar](20) NULL,
	[INPUT_DATETIME] [datetime] NULL,
	[INPUT_FROM] [varchar](30) NULL,
	[AUTH_BY] [varchar](20) NULL,
	[AUTH_DATETIME] [datetime] NULL,
	[AUTH_FROM] [varchar](30) NULL,
	[MOD_NO] [numeric](3, 0) NOT NULL,
	[STATUS] [char](1) NOT NULL,
 CONSTRAINT [PK__USERS__6FE99F9F] PRIMARY KEY CLUSTERED 
(
	[USERS_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_Revgenerate]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for reversal
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_Revgenerate]	
AS
BEGIN	

update CCMSREF_TAB set status_id=1, authorize=1   
where d_code in  
(select a.d_code  
  
from CCMSREF_TAB a , dschedule b    
Where   
A.d_code = B.d_code   
and a.filename is null   
and b.ds_code in (select ds_code from cschedule)   
) 
  
update CCMSREF_TAB set status_id=1, authorize=1   
where d_code in  
(select a.d_code  
  
from CCMSREF_TAB a , dschedule b 
Where   
A.d_code = B.d_code   
and a.filename is null   
   
and a.rev_date=b.schedule_Date

) 
  
 ----- che
           
delete from tmp_reversal ;             
insert into tmp_reversal( CR_TYPE,REF_NO,VALUE_DATE,location_code,REV_DATE,                  
Acc_No,RefAcc_No,client_code,amount,deposit_type,ds_code,CHECKDS_NO,CUSTOMER_REF)                  
                  
select c.CASH_CR_TYPE,a.REF_NO,a.VALUE_DATE,b.location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicash_amount) as total,b.deposit_type,'' as d_code ,'' CHECKDS_NO ,''               
from CCMSREF_TAB a ,dschedule b,client c                  
where                   
                  
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                
and a.filename is null                 
and c.CASH_CR_TYPE='L'     
  
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )     
  
  
     
group by a.REV_DATE,a.REF_NO,b.location_code,b.client_code,a.VALUE_DATE,c.CASH_CR_TYPE,                  
a.Acc_No,a.RefAcc_No,b.deposit_type                  
                  
union all                  
                  
--\\\\\\by deposit\\\\\\\\\\\\\                  
select c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,b.location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicash_amount) as total,b.deposit_type,b.d_code ,isnull(b.d_code,'') CHECKDS_NO ,isnull(d.customer_ref,'')customer_ref                 
from CCMSREF_TAB a ,dschedule b left outer join ccash d on d.d_code=b.d_code                   
,client c                 
where               
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                     
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code       
and a.filename is null                 
--and a.filename ='F7012.000'                  
and c.CASH_CR_TYPE='D'                  
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )                     
group by a.REV_DATE,a.REF_NO,b.client_code,a.VALUE_DATE,b.location_code,c.CASH_CR_TYPE,                  
a.Acc_No,a.RefAcc_No ,b.d_code,b.deposit_type,d.customer_ref                   
                  
     
--\\\\\total\\\\\\\\\\\\\\\                  
union all                  
select c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,'000' as location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicash_amount) as total,b.deposit_type,    
substring(CONVERT(varchar(12), VALUE_DATE,112),3,8)as d_code, count(b.citicash_amount) CHECKDS_NO,''              
from CCMSREF_TAB a ,dschedule b,client c                  
                  
where                 
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                   
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                  
and a.filename is null        
               
and c.CASH_CR_TYPE='T'        
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )                       
group by a.REV_DATE,a.REF_NO,b.client_code,a.VALUE_DATE,c.CASH_CR_TYPE,                 
a.Acc_No,a.RefAcc_No,b.deposit_type                 
                 
           
----########################By Ref no ###############               
union all                 
select c.CASH_CR_TYPE,a.REF_NO,VALUE_DATE,'000' as location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,b.citicash_amount as total,b.deposit_type,left(rtrim(d.CASH_REF ),10) as d_code ,  d.d_code CHECKDS_NO ,d.customer_ref              
from CCMSREF_TAB a ,dschedule b,client c,ccash d                  
                  
where                 
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                  
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                  
and a.filename is null                  
and d.d_code=b.d_code        
               
and c.CASH_CR_TYPE='R'                  
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )               
  -------------------
------------------------
------------------------
---------------------   
                  
insert into TMP_REVERSAL( CR_TYPE,REF_NO,VALUE_DATE,location_code,REV_DATE,                  
Acc_No,RefAcc_No,client_code,amount,b.deposit_type,b.ds_code,CHECKDS_NO,CUSTOMER_REF)                  
                  
                  
select c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicheck_amount) as total,b.deposit_type,'' as d_code , '' CHECKDS_NO ,'' CUSTOMER_REF                
from CCMSREF_TAB a ,dschedule b,client c                  
where                   
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                   
and b.citicheck_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                 
and a.filename is null                  
                 
and c.SPEED_CR_TYPE='L'                  
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )                               
group by a.REV_DATE,b.location_code,a.REF_NO,b.client_code,a.VALUE_DATE,c.SPEED_CR_TYPE,                  
a.Acc_No,a.RefAcc_No,b.deposit_type                  
                  
union all                  
----By Deposit                  
select c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicheck_amount) as total,b.deposit_type,b.d_code , b.d_code CHECKDS_NO,''customer_ref    
from CCMSREF_TAB a ,dschedule b     
,client c                 
where                   
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                    
and b.citicheck_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                  
and c.SPEED_CR_TYPE='D'                  
and a.filename is null        
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )                      
                
group by a.REV_DATE,a.REF_NO,b.ds_code,b.client_code,a.VALUE_DATE,c.SPEED_CR_TYPE,b.location_code,                  
a.Acc_No,a.RefAcc_No,b.d_code,b.deposit_type    
                  
union all                  
                
                
------By Total                  
select c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,'000' as location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicheck_amount) as total,b.deposit_type,substring(CONVERT(varchar(10), VALUE_DATE,112),3,8) , '' CHECKDS_NO ,''                
from CCMSREF_TAB a ,dschedule b,client c                  
where                   
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                  
and b.citicheck_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                  
and a.filename is null                  
                
and c.SPEED_CR_TYPE='T'     
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )                          
                  
group by a.REV_DATE,b.client_code,a.VALUE_DATE,a.REF_NO,c.SPEED_CR_TYPE,                  
a.Acc_No,a.RefAcc_No,b.deposit_type                 
                  
                  
union all                  
--\\\\\\\\\\\\\\\By Check\\\\\\\\                  
                
                
                
select  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,D.amount,b.deposit_type,d.check_no , b.d_code CHECKDS_NO  ,d.Customer_Ref                
from CCMSREF_TAB a,client c,dschedule b,csd_det d                  
where                   
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                   
and d.amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                  
and a.d_code=d.d_code                  
and a.filename is null                 
                  
and c.SPEED_CR_TYPE='C'     
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )                    
                
          
union all        
        
select  c.SPEED_CR_TYPE,a.REF_NO,VALUE_DATE,b.location_code,a.REV_DATE,a.Acc_No,a.RefAcc_No,                  
b.client_code,D.amount,b.deposit_type,left(d.CHECK_REF,10)  ,  b.d_code CHECKDS_NO ,d.Customer_Ref      
from CCMSREF_TAB a,client c,dschedule b,csd_det d                  
where                   
convert(datetime,convert(varchar(12), a.REV_DATE)) <= convert(datetime,convert(varchar(12), getdate()))                   
                 
and d.amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code                  
and a.d_code=d.d_code                  
and a.filename is null                  
                 
and c.SPEED_CR_TYPE='R'                  
and ( a.STATUS_ID=1 )     
and ( a.authorize =1  )        
order by a.REF_NO






         
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE D_CODE=@D_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE CSD
				SET				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
			INSERT INTO CSD
				SELECT D_CODE, 
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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

	INSERT INTO CSD_DET_HIST
		SELECT *,1
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

	INSERT INTO CSD_DET
		SELECT D_CODE, SLNO, CHECK_NO, DRAWER, 
		DRAWEE_BANK_CODE, AMOUNT,CUSTOMER_REF, SLIP_DATE, CHECK_DATE,
		DRAWEE_BRANCH, CHECK_REF, RTN_STATUS, MOD_NO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_UpdateStatus]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SET @STATUS = '';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from CSD_DET
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO)
		BEGIN
			SELECT @STATUS=[STATUS],				
				@MOD_NO=MOD_NO
				FROM CSD
				WHERE D_CODE=@D_CODE;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @MOD_NO + 1, 
				'U', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSDDet_GetDetailsByAmount]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	AND ds.CLIENT_CODE<>'999999'

	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_GetDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT s.*,'IS_AUTH'=1 ,b.BANK_NAME,l.LOCATION_NAME
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_GetMaxMod]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_Auth]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE SCHEDULE_ID=@SCHEDULE_ID AND BANK_CODE=@BANK_CODE 
				AND LOCATION_CODE=@LOCATION_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE SCHEDULE_STOCK
				SET SCHE_FROM=@SCHE_FROM,SCHE_UPTO=@SCHE_UPTO,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_GetDetailList]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 29-Nov-12
-- Description:	Get detail to Schedule Stock
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ScheduleStock_GetDetailList]		
	@SCHEDULE_ID	tinyint,
	@DEL_FLAG		int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT sh.*,b.BANK_NAME,l.LOCATION_NAME,'S' = 'U'				 
			FROM SCHEDULE_STOCK_HIST sh
			LEFT OUTER JOIN BANK b
			ON b.BANK_CODE=sh.BANK_CODE
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=sh.LOCATION_CODE
			WHERE sh.IS_AUTH=0 AND sh.SCHEDULE_ID=@SCHEDULE_ID
			UNION
			SELECT s.*,1,b.BANK_NAME,l.LOCATION_NAME,'S' = 'A'				
			FROM SCHEDULE_STOCK s
			LEFT OUTER JOIN BANK b
			ON b.BANK_CODE=s.BANK_CODE
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=s.LOCATION_CODE
			WHERE s.STATUS ='L'	AND s.SCHEDULE_ID=@SCHEDULE_ID
			ORDER BY IS_AUTH,BANK_CODE,LOCATION_CODE

		END
	ELSE
		BEGIN	

			SELECT sh.*,b.BANK_NAME,l.LOCATION_NAME,'S' = 'U'				 
			FROM SCHEDULE_STOCK_HIST sh
			LEFT OUTER JOIN BANK b
			ON b.BANK_CODE=sh.BANK_CODE
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=sh.LOCATION_CODE
			WHERE IS_AUTH=0 AND sh.SCHEDULE_ID=@SCHEDULE_ID
			UNION
			SELECT s.*,1,b.BANK_NAME,l.LOCATION_NAME,'S' = 
				CASE  
					WHEN s.STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM SCHEDULE_STOCK s
			LEFT OUTER JOIN BANK b
			ON b.BANK_CODE=s.BANK_CODE
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=s.LOCATION_CODE
			WHERE s.STATUS in ('L','D') AND s.SCHEDULE_ID=@SCHEDULE_ID				
			ORDER BY IS_AUTH,BANK_CODE,LOCATION_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ScheduleStock_Remove]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Auth]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE SLNO=@SLNO
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE MENU_LIST
				SET MENU_NAME=@MENU_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Remove]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SLNO from MENU_LIST
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@MENU_NAME=MENU_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM MENU_LIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_GetMaxMod]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_GetDetailList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

			SELECT *,'S' = 'U'				 
			FROM MENU_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM MENU_LIST
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,MENU_NAME

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM MENU_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM MENU_LIST
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,MENU_NAME

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_PermMenus_GetDetails]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			(SELECT SLNO M_SLNO,MENU_NAME FROM MENU_LIST WHERE STATUS='L') ml
			left outer join 
			(SELECT F_GROUP.*,'IS_AUTH'=1,
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
			(SELECT SLNO M_SLNO,MENU_NAME FROM MENU_LIST WHERE STATUS='L') ml
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Version_GetDetail]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheck_GetDetailsByAmount]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	AND ds.CLIENT_CODE='999999'
	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_Auth]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 
			
	SET NOCOUNT ON;

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
		
			INSERT INTO DCOLLECTED_HIST 
				SELECT *,1 FROM DCOLLECTED
				WHERE DS_CODE=@DS_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE DCOLLECTED_HIST
				SET [STATUS] = 'O' 
				WHERE DS_CODE=@DS_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE DCOLLECTED
				SET
				TOTAL_NOCHK=@TOTAL_NOCHK,
				TOTAL_CHKAMT=@TOTAL_CHKAMT, TOTAL_CASHAMT=@TOTAL_CASHAMT,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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

	INSERT INTO DSCHEDULE_HIST
		SELECT *,1
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

	INSERT INTO DSCHEDULE
		SELECT DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT, 
		CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, 
		LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, MOD_NO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_Remove]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 
			
	SET NOCOUNT ON;

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT DS_CODE from DCOLLECTED
			  WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_NOCHK=TOTAL_NOCHK, 
				@TOTAL_CHKAMT=TOTAL_CHKAMT, @TOTAL_CASHAMT=TOTAL_CASHAMT,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM DCOLLECTED
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				[STATUS], IS_AUTH)
				VALUES(@DS_CODE,
				@TOTAL_NOCHK, @TOTAL_CHKAMT, @TOTAL_CASHAMT, 
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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

			INSERT INTO DSCHEDULE_HIST
				SELECT DS_CODE, D_CODE, DEPOSIT_TYPE, CITICASH_AMOUNT, 
					CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, CLIENT_CODE, 
					LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE,
					@RET_MOD_NO,0
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DSchedule_GetDetails]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT ds.*,'IS_AUTH'=1,
				l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME
			FROM DSCHEDULE ds
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=ds.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=ds.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=ds.CORR_BRANCH_CODE
			WHERE ds.DS_CODE=@DS_CODE AND ds.MOD_NO = @MOD_NO
			ORDER BY D_CODE
		END	
	ELSE
		BEGIN
			SELECT dsh.* ,
				l.LOCATION_NAME,b.BANK_NAME,br.BRANCH_NAME
			FROM DSCHEDULE_HIST dsh
				LEFT OUTER JOIN LOCATION l
				ON l.LOCATION_CODE=dsh.LOCATION_CODE
				LEFT OUTER JOIN BANK b
				ON b.BANK_CODE=dsh.CORR_BANK_CODE
				LEFT OUTER JOIN BRANCH br
				ON br.BRANCH_CODE=dsh.CORR_BRANCH_CODE
			WHERE dsh.DS_CODE=@DS_CODE AND dsh.MOD_NO = @MOD_NO
			ORDER BY D_CODE
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BeforeBookingCheck]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	
	SELECT @BATCH_NO = ISNULL(MAX(BATCH_NO),'5600')+1		
		FROM GENPRM
		WHERE DATEDIFF(d,GETDATE(),BATCH_DATE)=0;

	SELECT @REF_NO = ISNULL(MAX(REF_NO),0)+1 FROM GENPRM;
	--SELECT @RefNo =  RIGHT('0000000000' + @RefNo, 10)

	
         
END
GO
/****** Object:  View [dbo].[V_SPPEDCASH_DETAIL]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_SPPEDCASH_DETAIL]
as
(
SELECT ds.*, cl.ACC_NO,cl.ACC_NAME,l.LOCATION_NAME,b.BANK_NAME
FROM DSCHEDULE ds
LEFT OUTER JOIN CLIENT cl
ON ds.CLIENT_CODE=cl.CLIENT_CODE
LEFT OUTER JOIN LOCATION l
ON l.LOCATION_CODE=ds.LOCATION_CODE
LEFT OUTER JOIN BANK b
ON b.BANK_CODE = ds.CORR_BANK_CODE
)
GO
/****** Object:  StoredProcedure [dbo].[CMS_DSchedule_GetCashSlip]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE='Cash';


END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BookingUpdtScheRefByBank]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

--****Update Schedule table Check wise and cash wise      
     UPDATE DSCHEDULE
		SET [FILENAME]=@FILENAME,SEQ_NO=@SEQ_NO,FLEXGEN_DATE=getdate() 
		WHERE REF_NO IS NULL AND [FILENAME] IS NULL AND DEPOSIT_TYPE='Cash'
		AND CORR_BANK_CODE=@BANK_CODE;      
     UPDATE DSCHEDULE
		SET [FILENAME]=@FILENAME,SEQ_NO=@SEQ_NO,FLEXGEN_DATE=getdate() 
		WHERE REF_NO IS NULL AND [FILENAME] IS NULL AND DEPOSIT_TYPE='Check' 
		AND SCHEDULE_DATE <= @VALUE_DATE
		AND CORR_BANK_CODE=@BANK_CODE;     
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BookingCheckUpdate]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			@DCODE VARCHAR(10),    
			@VREVDATE DATETIME  ,      
			@REFACCNO varchar(15),    
			@deptype  varchar(15)  
	
	SET NOCOUNT ON;
	
	BEGIN TRAN; 
                    
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
    
	UPDATE DSCHEDULE SET CHECKED=1 
		WHERE FILENAME IS NULL AND REF_NO IS NULL 
		AND (CHECKED IS NULL OR CHECKED =0) 
	IF @@ERROR<>0 GOTO ErrorHandler          
           
	COMMIT TRAN;              
	RETURN 0;           
                     
    ErrorHandler:          
	PRINT 'Record Does not Inserted/Updated:';          
	ROLLBACK TRAN;         
	RETURN 1;       


	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DSchedule_GetCheckSlip]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 08-Jan-13
-- Description:	Get check slip detail of DSchedule
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DSchedule_GetCheckSlip]	
	@D_CODE	varchar(12)
AS
BEGIN	
	
	SET NOCOUNT ON;

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
	WHERE ds.D_CODE=@D_CODE AND ds.DEPOSIT_TYPE='Check';


END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BookingDrByBank]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b WHERE 
			cl.CLIENT_CODE = ds.CLIENT_CODE
			AND ds.CITICASH_AMOUNT>0 
			AND ds.REF_NO IS NULL
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORCASH;
	FETCH NEXT FROM CURSORCASH 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES('0',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'',@vLOCATION_NAME,'Cash');
		
		FETCH NEXT FROM CURSORCASH 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORCASH;
	DEALLOCATE CURSORCASH;
--2

	DECLARE CURSORSPEED CURSOR FOR
		SELECT ds.DS_CODE,ds.SCHEDULE_DATE,
			SUM(ds.CITICHECK_AMOUNT) as total,l.LOCATION_NAME,b.ACC_NO
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b WHERE 
			cl.CLIENT_CODE = ds.CLIENT_CODE
			AND ds.CITICHECK_AMOUNT>0 
			AND ds.REF_NO IS NULL
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND ds.SCHEDULE_DATE<=@SCHEDULE_DATE
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORSPEED;
	FETCH NEXT FROM CURSORSPEED 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES('0',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'',@vLOCATION_NAME,'Check');
			

		FETCH NEXT FROM CURSORSPEED 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORSPEED;
	DEALLOCATE CURSORSPEED;

	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BookingDrCheckByBank]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b WHERE 
			cl.CLIENT_CODE = ds.CLIENT_CODE
			AND ds.CITICASH_AMOUNT>0 
			AND ds.REF_NO IS NULL AND ds.checked IS NULL
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORCASH;
	FETCH NEXT FROM CURSORCASH 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES('0',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'',@vLOCATION_NAME,'Cash');
		
		FETCH NEXT FROM CURSORCASH 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORCASH;
	DEALLOCATE CURSORCASH;
--2

	DECLARE CURSORSPEED CURSOR FOR
		SELECT ds.DS_CODE,ds.SCHEDULE_DATE,
			SUM(ds.CITICHECK_AMOUNT) as total,l.LOCATION_NAME,b.ACC_NO
			FROM CLIENT cl,DSCHEDULE ds ,LOCATION l ,BANK b WHERE 
			cl.CLIENT_CODE = ds.CLIENT_CODE
			AND ds.CITICHECK_AMOUNT>0 
			AND ds.REF_NO IS NULL AND ds.checked IS NULL
			AND l.LOCATION_CODE=ds.LOCATION_CODE 
			AND ds.CORR_BANK_CODE=b.bank_code
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND ds.SCHEDULE_DATE<=@SCHEDULE_DATE
			GROUP BY ds.LOCATION_CODE,ds.SCHEDULE_DATE,ds.DS_CODE,l.LOCATION_NAME, 
			ds.CORR_BANK_CODE,b.ACC_NO,b.BANK_NAME,ds.CORR_BANK_CODE
		

	OPEN CURSORSPEED;
	FETCH NEXT FROM CURSORSPEED 
        INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_DR_BOOKING(CRED_TYPE, SUNACC_NO, AMOUNT, REF_NO, VALUE_DATE,DAYS, REMARKS, DEP_TYP)
			VALUES('0',@vACC_NO,@vAmount,@vDS_CODE,
			@vSCHEDULE_DATE,
			'',@vLOCATION_NAME,'Check');
			

		FETCH NEXT FROM CURSORSPEED 
			INTO @vDS_CODE,@vSCHEDULE_DATE,@vAmount,@vLOCATION_NAME,@vACC_NO;
	END

	CLOSE CURSORSPEED;
	DEALLOCATE CURSORSPEED;

	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_DepositUpdate]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
 and c.SPEED_CR_TYPE='L'    
    
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
 and c.SPEED_CR_TYPE='L'    
    
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Reversal_Outstanding]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
					where a.value_date <> a.rev_date 
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
					where a.value_date <> a.rev_date 
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
					where a.value_date <> a.rev_date 
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
					where a.value_date <> a.rev_date 
					order by a.ds_code,a.rev_date,a.acc_name asc ;

				END;

		END;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_UpdateRef]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 25-Feb-13
-- Description: Process for booking check by bank code
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_UpdateRef]
	@FILENAME		varchar(15),      
	@SEQ_NO			varchar(20),      
	@VALUE_DATE		datetime ,            
	@GENPRMREF_NO	varchar(10), --Last refno for genprm table      
	@BATCH_NO		varchar(10) 
AS
BEGIN	
	DECLARE @ErrorVar		INT,
			@vCcode Char(6),         
       @vrefno varchar(10),        
       @vdays varchar(2),        
       @vcnt numeric,        
       @DCODE VARCHAR(10),        
       @VREVDATE DATETIME  ,          
       @REFACCNO varchar(15),        
       @deptype  varchar(15)  
	
	SET NOCOUNT ON;

	BEGIN TRAN ;           
         
                  
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
    
	UPDATE DSCHEDULE
		SET FILE_USER_ID=substring(suser_name(),charindex('\',suser_name())+1,20)
		WHERE [FILENAME]=@FILENAME;
                             
	IF @@ERROR<>0 GOTO ErrorHandler              
               
	COMMIT TRAN;                
	RETURN 0;            
                         
    ErrorHandler:              
	PRINT 'Record Does not Inserted/Updated:' ;             
	ROLLBACK TRAN ;             
	RETURN 1;
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DSchedule_GetDetailsByCode]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	ORDER BY D_CODE
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_Remove]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT SLNO from FORM_LIST
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@FORMS_NAME=FORMS_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM FORM_LIST 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_GetMaxMod]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_Auth]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE SLNO=@SLNO
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE FORM_LIST
				SET FORMS_NAME=@FORMS_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_GetDetailList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

			SELECT *,'S' = 'U'				 
			FROM FORM_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM FORM_LIST
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,FORMS_NAME

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM FORM_LIST_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM FORM_LIST
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,FORMS_NAME

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Form_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_SystemLog_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 07-Feb-13
-- Description:	Add to system log
-- =============================================
CREATE PROCEDURE [dbo].[CMS_SystemLog_Add]		
	@LOG_DESCRIPTION 		varchar(256)	
AS 
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO SYSTEM_LOG(LOG_DATETIME, LOG_DESCRIPTION, LOG_USER)
		VALUES(GETDATE(), @LOG_DESCRIPTION,
		substring(suser_name(),charindex('\',suser_name())+1,20));

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_PermForms_GetDetails]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			(SELECT SLNO F_SLNO,FORMS_NAME FROM FORM_LIST WHERE STATUS='L') fl
			left outer join 
			(SELECT F_GROUP.*,'IS_AUTH'=1,pf.FORM_SLNO,pf.IS_SHOW,pf.IS_NEW,
			pf.IS_UNLOCK,pf.IS_AUTHORIZER,pf.IS_DELETE,pf.IS_SAVE FROM F_GROUP
			LEFT OUTER JOIN PERM_FORMS pf
			ON FG_SLNO=SLNO AND F_GROUP.MOD_NO=pf.MOD_NO
			WHERE SLNO=@FG_SLNO AND F_GROUP.MOD_NO=@MOD_NO) g
			on fl.F_SLNO=g.FORM_SLNO


		END	
	ELSE
		BEGIN
			SELECT * FROM
			(SELECT SLNO F_SLNO,FORMS_NAME FROM FORM_LIST WHERE STATUS='L') fl
			left outer join 
			(SELECT F_GROUP_HIST.*,pfh.FORM_SLNO,pfh.IS_SHOW,pfh.IS_NEW,
			pfh.IS_UNLOCK,pfh.IS_AUTHORIZER,pfh.IS_DELETE,pfh.IS_SAVE FROM F_GROUP_HIST
			LEFT OUTER JOIN PERM_FORMS_HIST pfh
			ON FG_SLNO=SLNO AND F_GROUP_HIST.MOD_NO=pfh.MOD_NO
			WHERE F_GROUP_HIST.SLNO=@FG_SLNO AND F_GROUP_HIST.MOD_NO=@MOD_NO) g
			on fl.F_SLNO=g.FORM_SLNO
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@DS_CODE, @TOTAL_NOCHK, 
		@TOTAL_CHKAMT, @TOTAL_CASHAMT,
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_GetMaxMod]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	IF EXISTS(SELECT DS_CODE FROM DCOLLECTED 
				WHERE DS_CODE=@DS_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

			SELECT @ErrorVar = @@ERROR;		

			IF @ErrorVar <> 0
				BEGIN					
					RETURN 1;
				END
			
			SELECT @RET_MOD_NO = @MOD_NO +1;
			
			INSERT INTO DCOLLECTED_HIST(DS_CODE, TOTAL_NOCHK, 
				TOTAL_CHKAMT, TOTAL_CASHAMT,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@DS_CODE, @TOTAL_NOCHK, 
				@TOTAL_CHKAMT, @TOTAL_CASHAMT,
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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

					DELETE DCOLLECTED_HIST WHERE DS_CODE=@DS_CODE AND IS_AUTH=0;

					SELECT @ErrorVar = @@ERROR;		

					IF @ErrorVar <> 0
						BEGIN							
							RETURN 1;
						END

					INSERT INTO DCOLLECTED_HIST(DS_CODE, TOTAL_NOCHK, 
						TOTAL_CHKAMT, TOTAL_CASHAMT,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@DS_CODE, @TOTAL_NOCHK, 
						@TOTAL_CHKAMT, @TOTAL_CASHAMT,
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DCollected_GetDetailByCode]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetMaxMod]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_Remove]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT LOCATION_CODE from LOCATION 
			  WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@LOCATION_NAME=LOCATION_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM LOCATION 
				WHERE LOCATION_CODE=@LOCATION_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetailList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to Location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM LOCATION_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM LOCATION
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,LOCATION_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM LOCATION_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM LOCATION
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,LOCATION_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_Auth]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE LOCATION_CODE=@LOCATION_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE LOCATION
				SET LOCATION_NAME=@LOCATION_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetDetailList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	get detail of branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	
			SELECT brh.*,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,'S' = 'U'				 
			FROM BRANCH_HIST brh
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=brh.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=brh.LOCATION_CODE
			LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=brh.CLEARING_ZONE
			WHERE IS_AUTH=0
			UNION
			SELECT br.*,1,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,'S' = 'A'				
			FROM BRANCH br
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=br.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=br.LOCATION_CODE
			LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=br.CLEARING_ZONE
			WHERE br.STATUS ='L'					
			ORDER BY IS_AUTH,BANK_CODE,BRANCH_CODE

		END
	ELSE
		BEGIN	

			SELECT brh.*,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,'S' = 'U'				 
			FROM BRANCH_HIST brh
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=brh.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=brh.LOCATION_CODE
			LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=brh.CLEARING_ZONE
			WHERE IS_AUTH=0
			UNION
			SELECT br.*,1,BANK.BANK_NAME,LOCATION.LOCATION_NAME,ZONE.ZONE_NAME,'S' = 
				CASE  
					WHEN br.STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM BRANCH br
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=br.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=br.LOCATION_CODE
			LEFT OUTER JOIN ZONE ON ZONE.ZONE_CODE=br.CLEARING_ZONE
			WHERE br.STATUS in ('L','D')					
			ORDER BY IS_AUTH,BANK_CODE,BRANCH_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheck_GetDetails]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT cc.*,'IS_AUTH'=1,
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
				ON br.BRANCH_CODE=cc.BRANCH_CODE
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
				ON br.BRANCH_CODE=cch.BRANCH_CODE
				LEFT OUTER JOIN LOCATION l2
				ON l2.LOCATION_CODE=cch.LOCATION_CODE
			WHERE cch.D_CODE=@D_CODE AND cch.MOD_NO = @MOD_NO
			ORDER BY D_CODE
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetailByCode]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DD_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Fahad Khan
-- Create date: 25-Feb-13
-- Description:	Get detail of DD
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_GetDetail]	
	@D_CODE	varchar(12)
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT D_CODE 
			   FROM DD WHERE D_CODE=@D_CODE)
		BEGIN
			SELECT *,'IS_AUTH'=1 
			FROM DD 
			WHERE D_CODE=@D_CODE
		END	
	ELSE
		BEGIN
			SELECT dd.*,b.BANK_NAME,br.BRANCH_NAME,l.LOCATION_NAME
			FROM DD_HIST dd
            INNER JOIN BANK b ON dd.DRAWER_BANKCODE=b.BANK_CODE 
            INNER JOIN BRANCH br ON br.BRANCH_CODE= dd.DRAWER_BRANCHCODE
            INNER JOIN LOCATION l ON l.LOCATION_CODE= dd.DRAWER_LOCATION
			WHERE D_CODE=@D_CODE
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	get list records of location table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Location_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT LOCATION_CODE,LOCATION_NAME FROM LOCATION WHERE STATUS='L'
	ORDER BY LOCATION_NAME;
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_TmpReversal_GetFlexCrDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-13
-- Description:	Get detail of TMP_Reversal Credit Flex Data
-- =============================================
CREATE PROCEDURE [dbo].[CMS_TmpReversal_GetFlexCrDetail]	
	@REV_DATE	datetime
AS
BEGIN	
	
	SET NOCOUNT ON;

	SELECT a.*,b.* FROM TMP_REVERSAL a,LOCATION b 
		WHERE a.LOCATION_CODE=b.LOCATION_CODE 
        AND REV_DATE<=@REV_DATE

END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetDetail]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Get detail of branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetail]	
	@BANK_CODE		varchar(4),
	@BRANCH_CODE	varchar(4),
	@MOD_NO			int	
AS
BEGIN	
	
	SET NOCOUNT ON;

	IF EXISTS( SELECT BRANCH_CODE 
				FROM BRANCH WHERE BANK_CODE=@BANK_CODE 
				AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT *,'IS_AUTH'=1 ,BANK.BANK_NAME,LOCATION.LOCATION_NAME
			FROM BRANCH br
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=br.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=br.LOCATION_CODE			
			WHERE br.BANK_CODE=@BANK_CODE
			AND br.BRANCH_CODE=@BRANCH_CODE AND br.MOD_NO=@MOD_NO
		END	
	ELSE
		BEGIN
			SELECT * ,BANK.BANK_NAME,LOCATION.LOCATION_NAME
			FROM BRANCH_HIST brh
			LEFT OUTER JOIN BANK ON BANK.BANK_CODE=brh.BANK_CODE
			LEFT OUTER JOIN LOCATION ON LOCATION.LOCATION_CODE=brh.LOCATION_CODE			
			WHERE brh.BANK_CODE=@BANK_CODE
			AND brh.BRANCH_CODE=@BRANCH_CODE AND brh.MOD_NO=@MOD_NO
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetListByBank]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT l.LOCATION_CODE,l.LOCATION_NAME 
	FROM BANK b
	INNER JOIN BRANCH br on br.BANK_CODE=b.BANK_CODE
	INNER JOIN LOCATION l on l.LOCATION_CODE=br.LOCATION_CODE
	WHERE b.BANK_CODE=@BANK_CODE AND l.STATUS='L'
	ORDER BY LOCATION_NAME;
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetListByBranch]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CMS_Location_GetListByBranch]
	@BRANCH_CODE	varchar(4)
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT l.LOCATION_CODE,l.LOCATION_NAME 
	FROM BRANCH b
	INNER JOIN LOCATION l on l.LOCATION_CODE=b.LOCATION_CODE
	WHERE b.BRANCH_CODE=@BRANCH_CODE AND l.STATUS='L'
	ORDER BY LOCATION_NAME;
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_GetDetailList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

			SELECT clh.*,l.LOCATION_NAME,'S' = 'U'				 
			FROM CLIENT_LOC_CHARGE_HIST clh
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=clh.LOCATION_CODE
			WHERE clh.IS_AUTH=0 AND clh.CLIENT_CODE=@CLIENT_CODE
			UNION
			SELECT cl.*,1,l.LOCATION_NAME,'S' = 'A'				
			FROM CLIENT_LOC_CHARGE cl
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=cl.LOCATION_CODE
			WHERE cl.STATUS ='L' AND cl.CLIENT_CODE=@CLIENT_CODE				
			ORDER BY IS_AUTH,CLIENT_CODE

		END
	ELSE
		BEGIN	

			SELECT clh.*,l.LOCATION_NAME,'S' = 'U'				 
			FROM CLIENT_LOC_CHARGE_HIST clh
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=clh.LOCATION_CODE
			WHERE clh.IS_AUTH=0 AND clh.CLIENT_CODE=@CLIENT_CODE
			UNION
			SELECT cl.*,1,l.LOCATION_NAME,'S' = 
				CASE  
					WHEN cl.STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM CLIENT_LOC_CHARGE cl
			LEFT OUTER JOIN LOCATION l
			ON l.LOCATION_CODE=cl.LOCATION_CODE
			WHERE cl.STATUS in ('L','D') AND cl.CLIENT_CODE=@CLIENT_CODE
			ORDER BY IS_AUTH,CLIENT_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT cc.*,'IS_AUTH'=1,c.ACC_NO,c.ACC_NAME,l.LOCATION_NAME
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSchedule_GetDetails]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT cs.*,'IS_AUTH'=1,
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetCorrBankList]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Feb-13
-- Description:	get list records of corr. bank 
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Bank_GetCorrBankList]	
AS
BEGIN		
	SET NOCOUNT ON;

	SELECT b.BANK_CODE,b.BANK_NAME 
	FROM BANK b
	INNER JOIN BRANCH br ON b.BANK_CODE=br.BANK_CODE
	WHERE b.STATUS='L' 
	AND br.CORRBANK=1
	ORDER BY BANK_NAME;	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetCorrNikBranchListByBank]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	WHERE STATUS='L' 
	AND CORRBANK=1 AND NIKBRANCH_CODE!='NULL' AND BANK_CODE=@BANK_CODE
	ORDER BY BRANCH_NAME;	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetDetailByNikBranch]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Fahad Khan
-- Create date: 20-FEB-13
-- Description:	Get detail of branch by NikBranch code
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_GetDetailByNikBranch]	
	@NIKBRANCH_CODE		varchar(7)
AS
BEGIN	
	
	SET NOCOUNT ON;
	
	SELECT * FROM BRANCH 
	WHERE NIKBRANCH_CODE=@NIKBRANCH_CODE
 
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN

			DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND
				BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						AND MOD_NO=@MOD_NO AND IS_AUTH=0)
				BEGIN

					DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND 
						BRANCH_CODE = @BRANCH_CODE AND IS_AUTH=0;

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Remove record from branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_Remove]	
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
			@CORRBANK		bit,
			@NIKBRANCH_CODE	varchar(7),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar		int; 

	SET NOCOUNT ON;

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from BRANCH 
			  WHERE BANK_CODE=@BANK_CODE AND
			  BRANCH_CODE = @BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME = BRANCH_NAME,
				@ROUTING_NO=ROUTING_NO,@LOCATION_CODE=LOCATION_CODE,
				@BRANCH_ADD1=BRANCH_ADD1,@BRANCH_ADD2=BRANCH_ADD2,
				@CLEARING_ZONE=CLEARING_ZONE,@CORRBANK=CORRBANK,
				@NIKBRANCH_CODE=NIKBRANCH_CODE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM BRANCH 
				WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE = @BRANCH_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
				BEGIN
					-- already deleted
					ROLLBACK TRANSACTION;
					RETURN 6;
				END;

			DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE AND 
				BRANCH_CODE = @BRANCH_CODE AND IS_AUTH=0;

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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
					  BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO )
				BEGIN
					DELETE BRANCH_HIST
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Auth]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Authorize record to branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Branch_Auth]	
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
			@CORRBANK		bit,
			@NIKBRANCH_CODE	varchar(7),
			@INPUT_BY		varchar(20),
			@INPUT_DATETIME datetime,
			@INPUT_FROM		varchar(30),			
			@LAST_MOD_NO	int,
			@IS_AUTH		bit;			
	
	DECLARE @ErrorVar1		int; 


	SET NOCOUNT ON;

	SELECT @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from BRANCH_HIST 
			  WHERE BANK_CODE=@BANK_CODE 
			  AND BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME = BRANCH_NAME,
				@ROUTING_NO=ROUTING_NO,@LOCATION_CODE=LOCATION_CODE,
				@BRANCH_ADD1=BRANCH_ADD1,@BRANCH_ADD2=BRANCH_ADD2,
				@CLEARING_ZONE=CLEARING_ZONE,@CORRBANK=CORRBANK,
				@NIKBRANCH_CODE=NIKBRANCH_CODE,
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM,@IS_AUTH=IS_AUTH
				FROM BRANCH_HIST 
				WHERE BANK_CODE=@BANK_CODE AND
					BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO;
			IF (@IS_AUTH = 1)
				BEGIN
					-- already authorized
					ROLLBACK TRANSACTION;
					RETURN 3;
				END;
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE BRANCH_HIST
				SET [STATUS] = 'O' 
				WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE BRANCH
				SET BRANCH_NAME = @BRANCH_NAME,ROUTING_NO=@ROUTING_NO,
				LOCATION_CODE=@LOCATION_CODE,
				BRANCH_ADD1=@BRANCH_ADD1,BRANCH_ADD2=@BRANCH_ADD2,
				CLEARING_ZONE=@CLEARING_ZONE,CORRBANK=@CORRBANK,
				NIKBRANCH_CODE=@NIKBRANCH_CODE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
				AUTH_DATETIME=GETDATE(),AUTH_FROM=HOST_NAME(),
				MOD_NO=@MOD_NO,[STATUS]=@STATUS
			WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE;

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END
			
			DELETE BRANCH_HIST WHERE BANK_CODE=@BANK_CODE 
				AND BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
					FROM BRANCH_HIST
					WHERE BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE
					AND MOD_NO=@MOD_NO;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			DELETE BRANCH_HIST 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Add]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				WHERE BANK_CODE=@BANK_CODE
				AND BRANCH_CODE=@BRANCH_CODE)
		BEGIN
			-- Duplicate Entry
			ROLLBACK TRANSACTION;		
			RETURN 2	
		END
	
	DELETE BRANCH_HIST WHERE 
		BANK_CODE=@BANK_CODE AND BRANCH_CODE=@BRANCH_CODE AND IS_AUTH=0;

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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DSchedule_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@CORR_BRANCH_CODE	varchar(4)
AS
BEGIN	
	DECLARE @ErrorVar	int;
		
	SET NOCOUNT ON;
			
	INSERT INTO DSCHEDULE_HIST(DS_CODE, D_CODE, DEPOSIT_TYPE, 
		CITICASH_AMOUNT, CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, 
		CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE, 
		MOD_NO,IS_AUTH)
		VALUES(@DS_CODE, @D_CODE, @DEPOSIT_TYPE, 
		@CITICASH_AMOUNT, @CITICHECK_AMOUNT, @SCHEDULE_DATE, @NO_CHECK, 
		@CLIENT_CODE, @LOCATION_CODE, @CORR_BANK_CODE, @CORR_BRANCH_CODE,
		1,0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DSchedule_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@MOD_NO			int	
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	INSERT INTO DSCHEDULE_HIST(DS_CODE, D_CODE, DEPOSIT_TYPE, 
		CITICASH_AMOUNT, CITICHECK_AMOUNT, SCHEDULE_DATE, NO_CHECK, 
		CLIENT_CODE, LOCATION_CODE, CORR_BANK_CODE, CORR_BRANCH_CODE,
		MOD_NO, IS_AUTH)
		VALUES(@DS_CODE, @D_CODE, @DEPOSIT_TYPE, 
		@CITICASH_AMOUNT, @CITICHECK_AMOUNT, @SCHEDULE_DATE, @NO_CHECK, 
		@CLIENT_CODE, @LOCATION_CODE, @CORR_BANK_CODE, @CORR_BRANCH_CODE,
		@MOD_NO, 0)

	SELECT @ErrorVar = @@ERROR;

	IF @ErrorVar <> 0
		BEGIN
			RETURN 1;
		END	
	
	RETURN 0;			
	    
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 18-Nov-12
-- Description:	Add detail to F_Group
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_Add]	
	@FG_ID		varchar(50),
	@FG_NAME 	varchar(50),
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetMaxMod]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Auth]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE SLNO=@SLNO
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE F_GROUP
				SET FG_ID=@FG_ID,FG_NAME=@FG_NAME,DEPT_SLNO=@DEPT_SLNO,		
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	update detail to F_Group table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_FGroup_Update]	
	@SLNO			numeric(6,0),
	@FG_ID			varchar(50),
	@FG_NAME 		varchar(50),
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetDetailList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 19-Nov-12
-- Description:	Get detail of Department  table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_FGroup_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT gh.*,d.DEPT_ID,d.DEPT_NAME,'S' = 'U'				 
			FROM F_GROUP_HIST gh
			LEFT OUTER JOIN DEPARTMENT d
			ON gh.DEPT_SLNO=d.SLNO			 
			WHERE IS_AUTH=0
			UNION
			SELECT g.*,1,d.DEPT_ID,d.DEPT_NAME,'S' = 'A'				
			FROM F_GROUP g
			LEFT OUTER JOIN DEPARTMENT d
			ON g.DEPT_SLNO=d.SLNO
			WHERE g.STATUS ='L'					
			ORDER BY IS_AUTH,DEPT_ID,FG_ID

		END
	ELSE
		BEGIN	

			SELECT gh.*,d.DEPT_ID,d.DEPT_NAME,'S' = 'U'				 
			FROM F_GROUP_HIST gh
			LEFT OUTER JOIN DEPARTMENT d
			ON gh.DEPT_SLNO=d.SLNO
			WHERE IS_AUTH=0
			UNION
			SELECT g.*,1,d.DEPT_ID,d.DEPT_NAME,'S' = 
				CASE  
					WHEN g.STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 			
			FROM F_GROUP g
			LEFT OUTER JOIN DEPARTMENT d
			ON g.DEPT_SLNO=d.SLNO
			WHERE g.STATUS in ('L','D')					
			ORDER BY IS_AUTH,DEPT_ID,FG_ID

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Remove]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetListByDeptCode]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		AND STATUS='L'		
		ORDER BY FG_NAME;
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetSelFG]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetAvailFG]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				WHERE fg.STATUS='L'
				AND fg.DEPT_SLNO=@DEPT_SLNO 
				AND SLNO NOT IN (SELECT FG_SLNO FROM USERS_FG_DET
									WHERE USERS_ID=@USERS_ID
									AND MOD_NO=@MOD_NO);
		END
	ELSE
		BEGIN

			SELECT fg.SLNO,fg.FG_ID
				FROM F_GROUP fg
				WHERE fg.STATUS='L'
				AND fg.DEPT_SLNO=@DEPT_SLNO  
				AND SLNO NOT IN (SELECT FG_SLNO FROM USERS_FG_DET_HIST
									WHERE USERS_ID=@USERS_ID
									AND MOD_NO=@MOD_NO);
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetList]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 14-Nov-12
-- Description:	get list records of zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT ZONE_CODE,ZONE_NAME FROM ZONE WHERE STATUS='L'
	ORDER BY ZONE_NAME;
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetailByBankBranchLoc]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
	AND br.LOCATION_CODE=@LOCATION_CODE AND z.STATUS='L';	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Remove]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT ZONE_CODE from ZONE 
			  WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@ZONE_NAME=ZONE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM ZONE 
				WHERE ZONE_CODE=@ZONE_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetail]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetailList]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Get detail to zone table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Zone_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM ZONE_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM ZONE
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,ZONE_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM ZONE_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM ZONE
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,ZONE_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Update]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetMaxMod]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Auth]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE ZONE_CODE=@ZONE_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE ZONE
				SET ZONE_NAME=@ZONE_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Add]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCash_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCash_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCash_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCash_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCash_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE D_CODE=@D_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE CCASH
				SET CUSTOMER_REF=@CUSTOMER_REF,
				CASH_REF=@CASH_REF,SLIP_DATE=@SLIP_DATE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
			INSERT INTO CCASH
				SELECT D_CODE, CUSTOMER_REF,
					CASH_REF,SLIP_DATE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCash_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_RevBatch]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		
	SELECT @BATCH_NO = ISNULL(MAX(BATCH_NO),'5600')+1		
		FROM GENPRM
		WHERE DATEDIFF(d,GETDATE(),BATCH_DATE)=0;
    
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_ReversalUpdateRef]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_PermMenus_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_PermMenus_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_AfterBookingCheck]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	DELETE TMP_CR_BOOKING;
	DELETE TMP_DR_BOOKING;

	DECLARE CURSORCASH CURSOR FOR
		SELECT REV_DATE,sum(AMOUNT) as total FROM
			TMP_BOOKING 
			WHERE DEP_TYP='CASH' 
			GROUP by REV_DATE order by REV_DATE;
		

	OPEN CURSORCASH;
	FETCH NEXT FROM CURSORCASH 
        INTO @vRevDate,@vAmount;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_CR_BOOKING(CRED_TYPE, SUNACC_NO,SUNDRY_REFACC_NO, AMOUNT, REF_NO, VALUE_DATE, REV_DATE, DAYS, REMARKS, DEP_TYP)
			VALUES('1','G010009275600005','G010009275600005',@vAmount,RIGHT('0000000000' + @REF_NO, 10),
			CONVERT(datetime,convert(varchar(12), GETDATE())),
			@vRevDate,'','Cash','CASH');
		
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
			WHERE DEP_TYP='CHECK' 
			GROUP by REV_DATE order by REV_DATE;	

	OPEN CURSORSPEED;
	FETCH NEXT FROM CURSORSPEED 
        INTO @vRevDate,@vAmount;

	WHILE @@FETCH_STATUS=0 
 	BEGIN
		
		INSERT INTO TMP_CR_BOOKING(CRED_TYPE, SUNACC_NO,SUNDRY_REFACC_NO, AMOUNT, REF_NO, VALUE_DATE, REV_DATE, DAYS, REMARKS, DEP_TYP)
			VALUES('1','G010009275570009','G010009275570009',@vAmount,RIGHT('0000000000' + @REF_NO, 10),
			CONVERT(datetime,convert(varchar(12), GETDATE())),
			@vRevDate,'','Speed','CHECK');
		
		SELECT @REF_NO =  @REF_NO + 1;

		FETCH NEXT FROM CURSORSPEED 
		INTO @vRevDate,@vAmount;
	END

	CLOSE CURSORSPEED;
	DEALLOCATE CURSORSPEED;
         
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_Holiday]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 23-Feb-13
-- Description: Process for holiday
-- =============================================

CREATE PROCEDURE [dbo].[CMS_Process_Holiday]	
	@BANK_CODE		varchar(4)	
AS
BEGIN	
	DECLARE @ErrorVar INT,
			@vcnt1 	int,
			@vcnt2 	int,
			@vcnt3 	int,
			@vFdt 	datetime,
			@vDelDt	datetime,
			@vDcode	varchar(8);
	
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
				AND [STATUS]='L');
	                     
			IF @vcnt3>0     
			BEGIN
				SET @vDelDt=(SELECT DATEADD(DAY,1,@vDelDt));
				SET @vcnt2=@vcnt2+1;
			END
			
			SET @vcnt1=@vcnt1+1;
		END
		
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Auth]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE REJECT_CODE=@REJECT_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE RETURN_REJECT
				SET REJECT_REASON=@REJECT_REASON,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetailList]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to Return_Reject table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ReturnReject_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM RETURN_REJECT_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM RETURN_REJECT
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,REJECT_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM RETURN_REJECT_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM RETURN_REJECT
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,REJECT_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Remove]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT REJECT_CODE from RETURN_REJECT 
			  WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@REJECT_REASON=REJECT_REASON,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM RETURN_REJECT 
				WHERE REJECT_CODE=@REJECT_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetMaxMod]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetailByCode]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_PermForms_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_PermForms_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TmpCrBooking_GetDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TmpDrBooking_GetFlexDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSD_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT D_CODE from CSD
			  WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CSD
				WHERE D_CODE=@D_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
					DRAWEE_BRANCH, CHECK_REF,
					@RET_MOD_NO,0
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT CHECKTYPE_CODE from CHECKTYPE 
			  WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@CHECKTYPE_NAME=CHECKTYPE_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM CHECKTYPE 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetDetailList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to CheckType table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CheckType_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM CHECKTYPE_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM CHECKTYPE
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,CHECKTYPE_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM CHECKTYPE_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM CHECKTYPE
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,CHECKTYPE_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE CHECKTYPE_CODE=@CHECKTYPE_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE CHECKTYPE
				SET CHECKTYPE_NAME=@CHECKTYPE_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT ufg.*,'IS_AUTH'=1,u.USERS_NAME,d.DEPT_NAME
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetMaxMod]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Update]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetDetailList]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

			SELECT ugh.*,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,'S' = 'U'				 
			FROM USERS_FG_HIST ugh
			INNER JOIN USERS u
			ON u.USERS_ID=ugh.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE IS_AUTH=0
			UNION
			SELECT ug.*,1,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,'S' = 'A'				
			FROM USERS_FG ug
			INNER JOIN USERS u
			ON u.USERS_ID=ug.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE ug.STATUS ='L'					
			ORDER BY IS_AUTH,DEPT_ID,USERS_ID

		END
	ELSE
		BEGIN	

			SELECT ugh.*,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,'S' = 'U'				 
			FROM USERS_FG_HIST ugh
			INNER JOIN USERS u
			ON u.USERS_ID=ugh.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE IS_AUTH=0
			UNION
			SELECT ug.*,1,u.USERS_NAME,d.DEPT_ID,d.DEPT_NAME,'S' = 
				CASE  
					WHEN ug.STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 			
			FROM USERS_FG ug
			INNER JOIN USERS u
			ON u.USERS_ID=ug.USERS_ID
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE ug.STATUS in ('L','D')					
			ORDER BY IS_AUTH,DEPT_ID,USERS_ID

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Remove]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT USERS_ID from USERS_FG
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM USERS_FG
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Auth]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE USERS_ID=@USERS_ID
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE USERS_FG
				SET 		
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	update detail to Citibank_branch table
-- =============================================

CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_Update]	
	@BRANCH_CODE	varchar(3),
	@BRANCH_NAME 	varchar(35),
	@ADDRESS1 		varchar(35),
	@ADDRESS2 		varchar(35),	
	@MOD_NO			int,
	@RET_MOD_NO		int output
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
			
			INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME,	ADDRESS1,ADDRESS2,
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BRANCH_CODE, @BRANCH_NAME,@ADDRESS1,@ADDRESS2,
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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

					INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME,	ADDRESS1,ADDRESS2,
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BRANCH_CODE, @BRANCH_NAME,@ADDRESS1,@ADDRESS2,
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_GetDetailList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

			SELECT *,'S' = 'U'				 
			FROM CITIBANK_BRANCH_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM CITIBANK_BRANCH
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,BRANCH_CODE

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM CITIBANK_BRANCH_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM CITIBANK_BRANCH
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,BRANCH_CODE

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 13-Nov-12
-- Description:	Add detail to Citibank_branch table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CitiBankBranch_Add]	
	@BRANCH_CODE	varchar(3),
	@BRANCH_NAME 	varchar(35),
	@ADDRESS1 		varchar(35),
	@ADDRESS2 		varchar(35)	
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

	INSERT INTO CITIBANK_BRANCH_HIST(BRANCH_CODE, BRANCH_NAME,	ADDRESS1,ADDRESS2,
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BRANCH_CODE, @BRANCH_NAME,@ADDRESS1,@ADDRESS2,
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT BRANCH_CODE from CITIBANK_BRANCH_HIST 
			  WHERE BRANCH_CODE=@BRANCH_CODE AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@BRANCH_NAME=BRANCH_NAME,
				@ADDRESS1=ADDRESS1,@ADDRESS2=ADDRESS2,				
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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
		
			INSERT INTO CITIBANK_BRANCH_HIST 
				SELECT *,1 FROM CITIBANK_BRANCH
				WHERE BRANCH_CODE=@BRANCH_CODE;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE CITIBANK_BRANCH_HIST
				SET [STATUS] = 'O' 
				WHERE BRANCH_CODE=@BRANCH_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE CITIBANK_BRANCH
				SET BRANCH_NAME=@BRANCH_NAME,
				ADDRESS1=@ADDRESS1,ADDRESS2=@ADDRESS2,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
			INSERT INTO CITIBANK_BRANCH
				SELECT BRANCH_CODE, BRANCH_NAME, ADDRESS1, ADDRESS2,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TranStatus_GetList]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheckTotal_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheckTotal_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheckTotal_GetDetail]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheckTotal_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE D_CODE=@D_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE CCHECKTOTAL
				SET
				TOTAL_CHKNO=@TOTAL_CHKNO,
				TOTAL_CHKAMT=@TOTAL_CHKAMT, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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

	INSERT INTO CCHECK_HIST
		SELECT *,1
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

	INSERT INTO CCHECK
		SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, 
		CUSTOMER_REF, SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, 
		CHECK_DATE, CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, 
		LOCATION_CODE, BRANCH_CODE, CHECK_REF, RTN_STATUS,
		MOD_NO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheck_UpdateStatus]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SET @STATUS = '';

	BEGIN TRANSACTION;

	IF EXISTS(SELECT D_CODE from CCHECK
			  WHERE D_CODE=@D_CODE AND SLNO=@SLNO)
		BEGIN
			SELECT @STATUS=[STATUS],
				@TOTAL_CHKNO=TOTAL_CHKNO, @TOTAL_CHKAMT=TOTAL_CHKAMT,
				@MOD_NO=MOD_NO
				FROM CCHECKTOTAL
				WHERE D_CODE=@D_CODE;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(), HOST_NAME(), @MOD_NO + 1,
				'U', 0)

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

			INSERT INTO CCHECK_HIST
				SELECT SLNO, D_CODE, CLIENT_CODE, DLOCATION_CODE, CUSTOMER_REF, 
					SLIP_DATE, VALUE_DATE, CHECK_NO, AMOUNT, CHECK_DATE, 
					CHECK_TYPE, DRAWER, DRAWEE_BANK_CODE, LOCATION_CODE, 
					BRANCH_CODE, CHECK_REF, RTN_STATUS,
					@MOD_NO + 1,0
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFGDet_Update]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_UsersFGDet_Add]    Script Date: 03/03/2013 11:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Outstanding_Auth]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Feb-12
-- Description:	auth reversal outstanding items
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Outstanding_Auth]	
	@D_CODE		varchar(12),	
	@REV_DATE	datetime			
AS
BEGIN	
	DECLARE @ErrorVar INT,
		@USERID varchar(20),
		@AUTHORIZE tinyint;
	
	SET NOCOUNT ON;
	
	SELECT @USERID=USERID,@AUTHORIZE=AUTHORIZE
		FROM  CCMSREF_TAB		
		WHERE D_CODE=@D_CODE AND REV_DATE=@REV_DATE

	IF (@USERID = substring(suser_name(),charindex('\',suser_name())+1,20))
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
		AUTHORIZER_ID=substring(suser_name(),charindex('\',suser_name())+1,20)
		WHERE D_CODE=@D_CODE AND REV_DATE=@REV_DATE
	RETURN 0;
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Outstanding_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		USERID=substring(suser_name(),charindex('\',suser_name())+1,20)
		WHERE D_CODE=@D_CODE AND REV_DATE=@REV_DATE
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_TmpReversal_GetFlexDrDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_DD_GetMaxSlno]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Fahad Khan
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

END
GO
/****** Object:  StoredProcedure [dbo].[CMS_DD_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fahad Khan
-- Create date: 19-Feb-13
-- Description:	Add detail to DD_DET
-- =============================================
CREATE PROCEDURE [dbo].[CMS_DD_Add]	
	@D_CODE				varchar(12),
    @SLNO               int,
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
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,
        RTN_STATUS,STATUS,IS_AUTH)
		VALUES(@D_CODE, @SLNO, @DD_NO, @DD_DATE, 
		@AMOUNT, @DRAWER_BANKCODE,@DRAWER_BRANCHCODE, @DRAWER_LOCATION, @DRAWEE_BRANCH,
		@NIKBRANCH_CODE, @VAT,@COMMISION,@POSTAGE_CHARGE,@INSTRUMENT_EXP,
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U','U',0);
    

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN			
			RETURN 1;
		END
		
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetDetailList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 15-Nov-12
-- Description:	Get detail of Department  table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM DEPARTMENT_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 'A'				
			FROM DEPARTMENT
			WHERE STATUS ='L'					
			ORDER BY IS_AUTH,DEPT_ID

		END
	ELSE
		BEGIN	

			SELECT *,'S' = 'U'				 
			FROM DEPARTMENT_HIST 
			WHERE IS_AUTH=0
			UNION
			SELECT *,1,'S' = 
				CASE  
					WHEN STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM DEPARTMENT
			WHERE STATUS in ('L','D')					
			ORDER BY IS_AUTH,DEPT_ID

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_Remove]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT DEPT_ID from DEPARTMENT
			  WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@DEPT_ID=DEPT_ID,@DEPT_NAME=DEPT_NAME,				
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM DEPARTMENT 
				WHERE SLNO=@SLNO AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_Auth]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE SLNO=@SLNO
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE DEPARTMENT
				SET DEPT_ID=@DEPT_ID,DEPT_NAME=@DEPT_NAME,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetDetailList]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 16-Nov-12
-- Description:	Get detail of Users table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Users_GetDetailList]		
	@DEL_FLAG	int	
AS
BEGIN	
		
	SET NOCOUNT ON;

	IF @DEL_FLAG=0
		BEGIN	

			SELECT uh.*,d.DEPT_NAME,'S' = 'U'				 
			FROM USERS_HIST uh
			LEFT OUTER JOIN DEPARTMENT d
			ON uh.DEPT_SLNO=d.SLNO
			WHERE IS_AUTH=0
			UNION
			SELECT u.*,1,d.DEPT_NAME,'S' = 'A'				
			FROM USERS u
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE u.STATUS ='L'					
			ORDER BY IS_AUTH,USERS_ID

		END
	ELSE
		BEGIN	

			SELECT uh.*,d.DEPT_NAME,'S' = 'U'				 
			FROM USERS_HIST uh
			LEFT OUTER JOIN DEPARTMENT d
			ON uh.DEPT_SLNO=d.SLNO 
			WHERE IS_AUTH=0
			UNION
			SELECT u.*,1,d.DEPT_NAME,'S' = 
				CASE  
					WHEN u.STATUS = 'D' THEN 'D'                    
					ELSE 'A'
                END 
			FROM USERS u
			LEFT OUTER JOIN DEPARTMENT d
			ON u.DEPT_SLNO=d.SLNO
			WHERE u.STATUS in ('L','D')					
			ORDER BY IS_AUTH,USERS_ID

		END
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_Update]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetMaxMod]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetDetail]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetDetailByCode]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetList]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 17-Nov-12
-- Description:	get list records of department table
-- =============================================
CREATE PROCEDURE [dbo].[CMS_Department_GetList]	
AS
BEGIN	
		
	SET NOCOUNT ON;

	SELECT DEPT_ID,DEPT_NAME FROM DEPARTMENT WHERE STATUS='L'
	ORDER BY DEPT_NAME;
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_NCollectionUpdateByDD]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Fahad Khan
-- Create date: 25-Feb-13
-- Description:	CCheck table update by DD Details
-- =============================================
CREATE PROCEDURE [dbo].[CMS_NCollectionUpdateByDD]
    @DDREFNO			varchar(20), 
	@NONZONE_REF	    varchar(7),
    @AMOUNT			    numeric(12, 2), 
	@CHECKREF	        varchar(15),
    @VAT			    numeric(12, 2), 
	@COMMISION	        numeric(12, 2), 
    @POSTAGE_CHARGE	    numeric(12, 2),
    @INSTRUMENT_EXP	    numeric(12, 2)
    
AS
BEGIN	
		
	SET NOCOUNT ON;

	INSERT INTO DD_NCOLLECTION_HIST(DDREFNO,NONZONE_REF,AMOUNT,CHECKREF,VAT,COMMISION,
                              POSTAGE_CHARGE,INSTRUMENT_EXP,RTN_STATUS,STATUS)
		                      VALUES(@DDREFNO,@NONZONE_REF,@AMOUNT,@CHECKREF,@VAT,@COMMISION,
                                     @POSTAGE_CHARGE,@INSTRUMENT_EXP,'O','D');
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Add]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Auth]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE BANK_CODE=@BANK_CODE 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE BANK
				SET BANK_NAME=@BANK_NAME,
				HEAD_ADD1=@HEAD_ADD1,HEAD_ADD2=@HEAD_ADD2,
				HEAD_ADD3=@HEAD_ADD3,BANK_BBK_CODE=@BANK_BBK_CODE,ACC_NO=@ACC_NO,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Remove]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Update]    Script Date: 03/03/2013 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CCheckUpdateByDD]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Fahad Khan
-- Create date: 25-Feb-13
-- Description:	CCheck table update by DD Details
-- =============================================
CREATE PROCEDURE [dbo].[CMS_CCheckUpdateByDD]
    @DEPOSIT_SLNO			varchar(12), 
	@NONZONE_REF	        varchar(7)
AS
BEGIN	
		
	SET NOCOUNT ON;

	INSERT INTO DD_CCHECK_HIST(DEPOSIT_SLNO,NONZONE_REF,RTN_STATUS,STATUS)
		       VALUES(@DEPOSIT_SLNO,@NONZONE_REF,'O','D');
	
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Holiday_Add]    Script Date: 03/03/2013 11:52:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			
			RETURN 1;
		END
	
	
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_TotalCS_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TotalCS_GetMaxMod]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TotalCS_Remove]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TotalCS_GetDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TotalCS_Auth]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE CS_CODE=@CS_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE TOTALCS
				SET
				TOTAL_AMOUNT=@TOTAL_AMOUNT,				
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_TotalCS_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_Remove]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SET @STATUS = '';

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
			
			IF (@STATUS = 'D')
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
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_GetMaxMod]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_Auth]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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

	SELECT @STATUS = '';

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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
				SET [STATUS] = 'O' 
				WHERE CLIENT_CODE=@CLIENT_CODE
				AND LOCATION_CODE=@LOCATION_CODE
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE CLIENT_LOC_CHARGE
				SET CASH_DAYS=@CASH_DAYS, SPEED_DAYS=@SPEED_DAYS, 
				CASH_CHARGE=@CASH_CHARGE, SPEED_CHARGE=@SPEED_CHARGE, 
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_ClientLocCharge_GetSummList]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 26-Nov-12
-- Description:	Get Summary to Client location charge
-- =============================================
CREATE PROCEDURE [dbo].[CMS_ClientLocCharge_GetSummList]
AS
BEGIN	
		
	SET NOCOUNT ON;

	
			SELECT DISTINCT clh.CLIENT_CODE,c.ACC_NO,c.ACC_NAME,'S' = 'U'				 
			FROM CLIENT_LOC_CHARGE_HIST clh
			LEFT OUTER JOIN CLIENT c
			ON c.CLIENT_CODE=clh.CLIENT_CODE
			WHERE clh.IS_AUTH=0							
			ORDER BY CLIENT_CODE

		   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSchedule_Add]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_CSchedule_Update]    Script Date: 03/03/2013 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_Update]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@MOD_NO			int,
	@RET_MOD_NO		int output
AS
BEGIN	
	DECLARE @ErrorVar INT;
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

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
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@USERS_ID, @USERS_NAME,@DEPT_SLNO,@DOMAIN,@USER_STAT,
				substring(suser_name(),charindex('\',suser_name())+1,20),
				GETDATE(),HOST_NAME(),@RET_MOD_NO,'U',0);

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
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@USERS_ID, @USERS_NAME,@DEPT_SLNO,@DOMAIN,@USER_STAT,
						substring(suser_name(),charindex('\',suser_name())+1,20),
						GETDATE(),HOST_NAME(),@MOD_NO,'U',0);

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetDetail]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
			SELECT *,'IS_AUTH'=1 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetMaxMod]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_Add]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	@USER_STAT		char(1) 
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
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@USERS_ID, @USERS_NAME,@DEPT_SLNO,@DOMAIN,@USER_STAT,
		substring(suser_name(),charindex('\',suser_name())+1,20),
		GETDATE(),HOST_NAME(),1,'U',0);

	SELECT @ErrorVar = @@ERROR;
	
	IF @ErrorVar <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN 1;
		END
	
	COMMIT TRANSACTION;
	RETURN 0;
	   
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_Auth]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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

	SELECT @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT USERS_ID from USERS_HIST 
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@USERS_NAME=USERS_NAME,
				@DEPT_SLNO=DEPT_SLNO,@DOMAIN=DOMAIN,@USER_STAT=USER_STAT,
				@LAST_LOGIN_DATE=LAST_LOGIN_DATE,
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
			IF (@INPUT_BY = substring(suser_name(),charindex('\',suser_name())+1,20))
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
		
			INSERT INTO USERS_HIST 
				SELECT *,1 FROM USERS
				WHERE USERS_ID=@USERS_ID;
			
			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END


			UPDATE USERS_HIST
				SET [STATUS] = 'O' 
				WHERE USERS_ID=@USERS_ID 
				AND [STATUS] = 'L';

			SELECT @ErrorVar1 = @@error;

			IF @ErrorVar1 <> 0
				BEGIN
					ROLLBACK TRANSACTION;
					RETURN 1;
				END

			IF @STATUS='U'
				BEGIN
					SELECT @STATUS='L';
				END

			UPDATE USERS
				SET USERS_NAME=@USERS_NAME,
				DEPT_SLNO=@DEPT_SLNO,DOMAIN=@DOMAIN,USER_STAT=@USER_STAT,
				LAST_LOGIN_DATE=@LAST_LOGIN_DATE,
				INPUT_BY=@INPUT_BY,	INPUT_DATETIME=@INPUT_DATETIME,
				INPUT_FROM=@INPUT_FROM,
				AUTH_BY=substring(suser_name(),charindex('\',suser_name())+1,20),
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
			INSERT INTO USERS
				SELECT USERS_ID, USERS_NAME,
					DEPT_SLNO,DOMAIN,USER_STAT,
					LAST_LOGIN_DATE,
					INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
					substring(suser_name(),charindex('\',suser_name())+1,20), 
					GETDATE(), HOST_NAME(), MOD_NO, 'L' 
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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Users_Remove]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
			@INPUT_BY			varchar(20),
			@INPUT_DATETIME		datetime,
			@INPUT_FROM			varchar(30),			
			@IS_AUTH			bit;			
	
	DECLARE @ErrorVar		int; 
			

	SET NOCOUNT ON;

	SET @STATUS = '';

	BEGIN TRANSACTION

	IF EXISTS(SELECT USERS_ID from USERS 
			  WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO)
		BEGIN
			SELECT @STATUS=[STATUS],@USERS_NAME=USERS_NAME,
				@DEPT_SLNO=DEPT_SLNO,@DOMAIN=DOMAIN,@USER_STAT=USER_STAT,
				@LAST_LOGIN_DATE=LAST_LOGIN_DATE,			
				@INPUT_BY=INPUT_BY,	@INPUT_DATETIME=INPUT_DATETIME,
				@INPUT_FROM=INPUT_FROM
				FROM USERS 
				WHERE USERS_ID=@USERS_ID AND MOD_NO=@MOD_NO;
			
			IF (@STATUS = 'D')
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
				LAST_LOGIN_DATE,
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@USERS_ID, @USERS_NAME,
				@DEPT_SLNO,@DOMAIN,@USER_STAT,
				@LAST_LOGIN_DATE, 
				substring(suser_name(),charindex('\',suser_name())+1,20), 
				GETDATE(), HOST_NAME(), @RET_MOD_NO, 
				'D', 0)

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
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BookingCheckByBank]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	DELETE TMP_BOOKING;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END            
              
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
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]='L') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			WHERE ds.CITICASH_AMOUNT>0 and ds.REF_NO is null and ds.CHECKED is null
			AND ds.CORR_BANK_CODE=@BANK_CODE            
		UNION ALL          
		SELECT ds.REF_NO,ds.CITICHECK_AMOUNT as amt,ds.SCHEDULE_DATE,            
			DATEADD(day,convert(int,ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS)),ds.SCHEDULE_DATE )REVDATE,cl.ACC_NO,
			ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS) as SPEED_DAYS,ds.D_CODE,
			ds.DEPOSIT_TYPE
			FROM CLIENT  cl 
			INNER JOIN  DSCHEDULE ds
			on DS.CLIENT_CODE=CL.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]='L') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			where ds.CITICHECK_AMOUNT>0 and ds.REF_NO is null and ds.CHECKED is null
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND CONVERT(datetime,CONVERT(varchar(10),ds.schedule_date,101))             
			<= CONVERT(datetime,CONVERT(varchar(10),GETDATE(),101)) ;       
            
	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END		

--3
	exec CMS_Process_Holiday;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END

    
END
GO
/****** Object:  StoredProcedure [dbo].[CMS_Process_BookingByBank]    Script Date: 03/03/2013 11:52:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	DELETE TMP_BOOKING;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END            
              
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
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]='L') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			WHERE ds.CITICASH_AMOUNT>0 and ds.REF_NO is null
			AND ds.CORR_BANK_CODE=@BANK_CODE            
		UNION ALL          
		SELECT ds.REF_NO,ds.CITICHECK_AMOUNT as amt,ds.SCHEDULE_DATE,            
			DATEADD(day,convert(int,ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS)),ds.SCHEDULE_DATE )REVDATE,cl.ACC_NO,
			ISNULL(clc.SPEED_DAYS,cl.SPEED_DAYS) as SPEED_DAYS,ds.D_CODE,
			ds.DEPOSIT_TYPE
			FROM CLIENT  cl 
			INNER JOIN  DSCHEDULE ds
			on DS.CLIENT_CODE=CL.CLIENT_CODE
			LEFT OUTER JOIN (SELECT * FROM CLIENT_LOC_CHARGE where [STATUS]='L') clc
			ON clc.CLIENT_CODE=cl.CLIENT_CODE and clc.LOCATION_CODE=ds.LOCATION_CODE
			where ds.CITICHECK_AMOUNT>0 and ds.REF_NO is null 
			AND ds.CORR_BANK_CODE=@BANK_CODE
			AND CONVERT(datetime,CONVERT(varchar(10),ds.schedule_date,101))             
			<= CONVERT(datetime,CONVERT(varchar(10),GETDATE(),101)) ;       
            
	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END		

--3
	exec CMS_Process_Holiday;

	SELECT @ErrorVar = @@ERROR;		

	IF @ErrorVar <> 0
		BEGIN	
			RETURN 1;
		END

    
END
GO
