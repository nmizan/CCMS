USE [CCMS]
GO
/****** Object:  Role [ccms_sp_only]    Script Date: 11/12/2012 09:30:27 ******/
CREATE ROLE [ccms_sp_only]
GO
/****** Object:  User [SHANTO-PC\shanto]    Script Date: 11/12/2012 09:30:27 ******/
CREATE USER [SHANTO-PC\shanto] FOR LOGIN [SHANTO-PC\shanto] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[BANK]    Script Date: 11/12/2012 09:30:27 ******/
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
	[BANK_BBK_CODE] [varchar](4) NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANK_HIST]    Script Date: 11/12/2012 09:30:27 ******/
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
	[BANK_BBK_CODE] [varchar](4) NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOCATION]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOCATION_HIST]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZONE]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZONE_HIST]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RETURN_REJECT]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RETURN_REJECT_HIST]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHECKTYPE]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHECKTYPE_HIST]    Script Date: 11/12/2012 09:30:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetMaxMod]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Add]    Script Date: 11/12/2012 09:30:27 ******/
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
	@BANK_BBK_CODE	varchar(4)	
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
		BANK_BBK_CODE,INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
		@BANK_BBK_CODE,substring(suser_name(),charindex('\',suser_name())+1,20),
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Auth]    Script Date: 11/12/2012 09:30:27 ******/
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
			@BANK_BBK_CODE	varchar(4),
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
				@HEAD_ADD3=HEAD_ADD3,@BANK_BBK_CODE=BANK_BBK_CODE,
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
				HEAD_ADD3=@HEAD_ADD3,BANK_BBK_CODE=@BANK_BBK_CODE,
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
					BANK_BBK_CODE, INPUT_BY, INPUT_DATETIME, INPUT_FROM, 
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetail]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Remove]    Script Date: 11/12/2012 09:30:28 ******/
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
			@BANK_BBK_CODE	varchar(4),
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
				@HEAD_ADD3=HEAD_ADD3,@BANK_BBK_CODE=BANK_BBK_CODE,
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
				BANK_BBK_CODE, INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BANK_CODE, @BANK_NAME, @HEAD_ADD1, @HEAD_ADD2, @HEAD_ADD3, 
				@BANK_BBK_CODE, substring(suser_name(),charindex('\',suser_name())+1,20), 
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Update]    Script Date: 11/12/2012 09:30:28 ******/
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
	@BANK_BBK_CODE	varchar(4),
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
				BANK_BBK_CODE,INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
				@BANK_BBK_CODE,substring(suser_name(),charindex('\',suser_name())+1,20),
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
						BANK_BBK_CODE,INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BANK_CODE, @BANK_NAME,@HEAD_ADD1,@HEAD_ADD2,@HEAD_ADD3,
						@BANK_BBK_CODE,substring(suser_name(),charindex('\',suser_name())+1,20),
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetailList]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Add]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Auth]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetail]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetailList]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetMaxMod]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Remove]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Update]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Add]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Auth]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetail]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetailList]    Script Date: 11/12/2012 09:30:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Iftekharul Alam Khan Lodi
-- Create date: 11-Nov-12
-- Description:	Add detail to zone table
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetMaxMod]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Remove]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Update]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Add]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Auth]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Update]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Remove]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetMaxMod]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetailList]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetail]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Add]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Auth]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetDetail]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetDetailList]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetMaxMod]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Remove]    Script Date: 11/12/2012 09:30:28 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Update]    Script Date: 11/12/2012 09:30:28 ******/
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
