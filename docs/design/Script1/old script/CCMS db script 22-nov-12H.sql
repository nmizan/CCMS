USE [CCMS]
GO
/****** Object:  Role [ccms_sp_only]    Script Date: 11/22/2012 08:54:07 ******/
CREATE ROLE [ccms_sp_only]
GO
/****** Object:  User [SHANTO-PC\shanto]    Script Date: 11/22/2012 08:54:07 ******/
CREATE USER [SHANTO-PC\shanto] FOR LOGIN [SHANTO-PC\shanto] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[MENU_LIST_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANK]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[MENU_LIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANK_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[FORM_LIST_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FORM_LIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOCATION]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[F_GROUP]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ZONE]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[ZONE_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[F_GROUP_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOCATION_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[PERM_FORMS]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERM_MENUS]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERM_MENUS_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RETURN_REJECT]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[PERM_FORMS_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RETURN_REJECT_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[CHECKTYPE]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[CHECKTYPE_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
/****** Object:  Table [dbo].[USERS_FG]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_FG_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CITIBANK_BRANCH]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CITIBANK_BRANCH_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_FG_DET]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_FG_DET_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  Table [dbo].[BRANCH]    Script Date: 11/22/2012 08:54:07 ******/
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
	[ROUTING_NO] [varchar](8) NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[BRANCH_ADD1] [varchar](35) NULL,
	[BRANCH_ADD2] [varchar](35) NULL,
	[CLEARING_ZONE] [varchar](4) NULL,
	[CORRBANK] [bit] NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BRANCH_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
	[ROUTING_NO] [varchar](8) NULL,
	[LOCATION_CODE] [varchar](4) NULL,
	[BRANCH_ADD1] [varchar](35) NULL,
	[BRANCH_ADD2] [varchar](35) NULL,
	[CLEARING_ZONE] [varchar](4) NULL,
	[CORRBANK] [bit] NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENT]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENT_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS_HIST]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 11/22/2012 08:54:07 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Menu_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Menu_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Menu_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Menu_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetDetailByCode]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Bank_GetList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Branch_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_PermMenus_GetDetails]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Form_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_PermForms_GetDetails]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Location_GetDetailByCode]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetSelFG]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetListByDeptCode]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetAvailFG]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_FGroup_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetList]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Update]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Remove]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetMaxMod]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Auth]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetail]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_GetDetailList]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Zone_Add]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_PermMenus_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_PermMenus_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_ReturnReject_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_PermForms_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_PermForms_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CheckType_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetDetail]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Update]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetMaxMod]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Auth]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_Remove]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFG_GetDetailList]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_CitiBankBranch_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFGDet_Update]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_UsersFGDet_Add]    Script Date: 11/22/2012 08:54:09 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
	@CORRBANK		bit	
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
		INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
		VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
		@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE, @CORRBANK,
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
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
					BRANCH_ADD1, BRANCH_ADD2, CLEARING_ZONE, CORRBANK,
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
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
				INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
				VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
				@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE,@CORRBANK,
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
						INPUT_BY,INPUT_DATETIME,INPUT_FROM,MOD_NO,[STATUS],IS_AUTH)
						VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME,@ROUTING_NO,
						@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE, @CORRBANK,
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
/****** Object:  StoredProcedure [dbo].[CMS_Branch_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
				INPUT_BY, INPUT_DATETIME, INPUT_FROM, MOD_NO, 
				[STATUS], IS_AUTH)
				VALUES(@BANK_CODE, @BRANCH_CODE, @BRANCH_NAME, @ROUTING_NO,
				@LOCATION_CODE,@BRANCH_ADD1, @BRANCH_ADD2, @CLEARING_ZONE, @CORRBANK,
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetDetailByCode]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Department_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetDetailList]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_Add]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_Auth]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetDetail]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_GetMaxMod]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_Remove]    Script Date: 11/22/2012 08:54:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CMS_Users_Update]    Script Date: 11/22/2012 08:54:08 ******/
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
