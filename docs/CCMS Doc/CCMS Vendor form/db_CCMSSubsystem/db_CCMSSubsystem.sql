USE [db_CCMSSubSystem]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [EUCAPP]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [EUCAPP] FOR LOGIN [EUCAPP] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [CCMSSubSystem_User]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [CCMSSubSystem_User] FOR LOGIN [CCMSSubSystem_User] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APACBDMTJAS01\SQLServer2005SQLAgentUser$APACBDMTJAS01$MSSQLSERVER]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APACBDMTJAS01\SQLServer2005SQLAgentUser$APACBDMTJAS01$MSSQLSERVER] FOR LOGIN [APACBDMTJAS01\SQLServer2005SQLAgentUser$APACBDMTJAS01$MSSQLSERVER]
GO
/****** Object:  User [APACBDMTJAS01\SQLServer2005MSSQLUser$APACBDMTJAS01$MSSQLSERVER]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APACBDMTJAS01\SQLServer2005MSSQLUser$APACBDMTJAS01$MSSQLSERVER] FOR LOGIN [APACBDMTJAS01\SQLServer2005MSSQLUser$APACBDMTJAS01$MSSQLSERVER]
GO
/****** Object:  User [APACBDMTJAS01\SQLServer2005MSFTEUser$APACBDMTJAS01$MSSQLSERVER]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APACBDMTJAS01\SQLServer2005MSFTEUser$APACBDMTJAS01$MSSQLSERVER] FOR LOGIN [APACBDMTJAS01\SQLServer2005MSFTEUser$APACBDMTJAS01$MSSQLSERVER]
GO
/****** Object:  User [APACBDMTJAS01\H_EUC_CCMSSubSystem]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APACBDMTJAS01\H_EUC_CCMSSubSystem] FOR LOGIN [APACBDMTJAS01\App_CCMSSubSystem]
GO
/****** Object:  User [APAC\inmrdcappntsqldba]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APAC\inmrdcappntsqldba] FOR LOGIN [APAC\inmrdcappntsqldba]
GO
/****** Object:  User [APAC\inbomccdptbrdcisa]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APAC\inbomccdptbrdcisa] FOR LOGIN [APAC\inbomccdptbrdcisa]
GO
/****** Object:  User [APAC\dbaprb98155]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APAC\dbaprb98155] FOR LOGIN [APAC\dbaprb98155] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\dbapng67675]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APAC\dbapng67675] FOR LOGIN [APAC\dbapng67675] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\DBAPKD10951]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APAC\DBAPKD10951] FOR LOGIN [APAC\DBAPKD10951] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\bdicgsvcbmcpatrolp01]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [APAC\bdicgsvcbmcpatrolp01] FOR LOGIN [APAC\bdicgsvcbmcpatrolp01] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [apac\bdctisvcmssqlidp01]    Script Date: 02/27/2013 16:31:58 ******/
CREATE USER [apac\bdctisvcmssqlidp01] FOR LOGIN [APAC\bdctisvcmssqlidp01] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[SameDayInwardReturn]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SameDayInwardReturn](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikashtemp]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikashtemp](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Return]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Return](
	[OprDate] [smalldatetime] NULL,
	[IssueDate] [smalldatetime] NULL,
	[BankFrom] [nvarchar](8) NULL,
	[BankTo] [nvarchar](8) NULL,
	[PayeeNm] [nvarchar](40) NULL,
	[ChqSeries] [nvarchar](4) NULL,
	[ChqNumber] [nvarchar](15) NULL,
	[ChqNo] [nvarchar](8) NULL,
	[BookNo] [nvarchar](8) NULL,
	[ChqType] [nvarchar](8) NULL,
	[AccntNo] [nvarchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [nvarchar](8) NULL,
	[Remark] [nvarchar](15) NULL,
	[BatchNo] [nvarchar](8) NULL,
	[Ds_slip] [nvarchar](8) NULL,
	[CheckRef] [nvarchar](20) NULL,
	[EntryLoc] [nvarchar](4) NULL,
	[ds_code] [nvarchar](5) NULL,
	[status] [nvarchar](1) NULL,
	[FileName] [nvarchar](15) NULL,
	[flag] [bit] NOT NULL,
	[ReturnDate] [smalldatetime] NULL,
	[Expr1000] [nvarchar](3) NULL,
	[Bank_name] [nvarchar](35) NULL,
	[Branch_Code] [nvarchar](3) NULL,
	[Branch_name] [nvarchar](35) NULL,
	[NikBank_Code] [nvarchar](2) NULL,
	[Location_Code] [nvarchar](3) NULL,
	[NikBranch_Code] [nvarchar](7) NULL,
	[Bank_Code] [nvarchar](3) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tmpclientdata]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpclientdata](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChqType]    Script Date: 02/27/2013 16:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChqType](
	[ChqTypeNo] [nvarchar](8) NOT NULL,
	[ChqTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChqType] PRIMARY KEY CLUSTERED 
(
	[ChqTypeNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zone]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zone](
	[zone_code] [nvarchar](3) NOT NULL,
	[zone_name] [nvarchar](35) NULL,
 CONSTRAINT [PK_zone] PRIMARY KEY CLUSTERED 
(
	[zone_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[collection]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[collection](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Location_Code] [varchar](3) NULL,
	[Location_Name] [varchar](35) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TmpChecktotal]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpChecktotal](
	[ds_code] [varchar](8) NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NULL,
	[customer_ref] [varchar](15) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Results]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Acc_no] [nvarchar](15) NULL,
	[Bank_Code] [nvarchar](3) NULL,
	[Bank_name] [nvarchar](35) NULL,
	[Entrydate] [smalldatetime] NULL,
	[headadd1] [nvarchar](35) NULL,
	[headadd2] [nvarchar](35) NULL,
	[headadd3] [nvarchar](35) NULL,
	[NikBank_Code] [nvarchar](2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rtnrjct]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[rtnrjct](
	[reject_code] [char](2) NULL,
	[reject_reason] [char](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormsReport]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormsReport](
	[MCd] [decimal](2, 0) NOT NULL,
	[FRCd] [varchar](5) NOT NULL,
	[PCd] [varchar](6) NULL,
	[FRNm] [varchar](50) NULL,
	[Tp] [char](1) NULL,
	[FRSrc] [varchar](50) NULL,
	[FRTp] [char](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupPermission]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupPermission](
	[GROUPID] [char](2) NOT NULL,
	[PERID] [decimal](2, 0) NOT NULL,
	[RECADD] [bit] NOT NULL,
	[RECDEL] [bit] NOT NULL,
	[RECUP] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UGROUP]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UGROUP](
	[GROUPID] [varchar](2) NOT NULL,
	[GROUPNM] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserPermission](
	[USERID] [varchar](10) NOT NULL,
	[PERID] [decimal](2, 0) NOT NULL,
	[RECADD] [bit] NOT NULL,
	[RECDEL] [bit] NOT NULL,
	[RECUP] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PDC]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PDC](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PDCchecktotal]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PDCchecktotal](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Module]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[mcd] [decimal](5, 0) NOT NULL,
	[mnm] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikbranch1]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikbranch1](
	[Bank_Code] [varchar](3) NOT NULL,
	[Branch_Code] [varchar](3) NULL,
	[Branch_name] [varchar](35) NULL,
	[Location_Code] [varchar](3) NULL,
	[Branch_add1] [varchar](35) NULL,
	[Branch_add2] [varchar](35) NULL,
	[Clearing_zone] [varchar](3) NULL,
	[Corrbank] [varchar](1) NULL,
	[NikBranch_Code] [varchar](7) NOT NULL,
	[Entrydate] [smalldatetime] NULL,
	[SDClear] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NikBank]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NikBank](
	[Bank_Code] [varchar](3) NOT NULL,
	[Bank_name] [varchar](100) NULL,
	[headadd1] [varchar](35) NULL,
	[headadd2] [varchar](35) NULL,
	[headadd3] [varchar](35) NULL,
	[NikBank_Code] [varchar](2) NOT NULL,
	[Acc_no] [varchar](16) NULL,
	[Entrydate] [smalldatetime] NULL,
	[Bank_shname] [varchar](15) NULL,
 CONSTRAINT [Bank_key] PRIMARY KEY CLUSTERED 
(
	[Bank_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nikashtab]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL,
 CONSTRAINT [PkOprBankFChecknum] PRIMARY KEY CLUSTERED 
(
	[OprDate] ASC,
	[BankFrom] ASC,
	[ChqNumber] ASC,
	[DebtCredit] ASC,
	[Remark] ASC,
	[ds_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpnikclient]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpnikclient](
	[Client_Code] [nvarchar](6) NULL,
	[Sub_Client] [nvarchar](2) NULL,
	[Acc_No] [nvarchar](15) NULL,
	[Acc_Name] [nvarchar](40) NULL,
	[Mail_Add1] [nvarchar](35) NULL,
	[Mail_Add2] [nvarchar](35) NULL,
	[mail_add3] [nvarchar](20) NULL,
	[Contact] [nvarchar](35) NULL,
	[DumAccNo] [nvarchar](10) NULL,
	[Flag] [bit] NOT NULL,
	[Branch_Code] [nvarchar](3) NULL,
	[Entrydate] [smalldatetime] NULL,
	[Citicash] [varchar](2) NULL,
	[citispeed] [varchar](2) NULL,
	[CashCrTyp] [varchar](25) NULL,
	[SpeedCrTyp] [varchar](25) NULL,
	[Citiclear] [varchar](2) NULL,
	[ClearCrTyp] [varchar](25) NULL,
	[CheckCrTyp] [varchar](25) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nikclient]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nikclient](
	[Client_Code] [varchar](6) NULL,
	[Sub_Client] [varchar](2) NULL,
	[Acc_No] [varchar](15) NOT NULL,
	[Acc_Name] [varchar](40) NULL,
	[Mail_Add1] [varchar](35) NULL,
	[Mail_Add2] [varchar](35) NULL,
	[mail_add3] [varchar](20) NULL,
	[Contact] [varchar](35) NULL,
	[DumAccNo] [varchar](10) NULL,
	[Flag] [bit] NOT NULL,
	[Branch_Code] [varchar](3) NULL,
	[Entrydate] [smalldatetime] NULL,
	[Citicash] [varchar](2) NULL,
	[citispeed] [varchar](2) NULL,
	[CashCrTyp] [varchar](25) NULL,
	[SpeedCrTyp] [varchar](25) NULL,
	[Citiclear] [varchar](2) NULL,
	[ClearCrTyp] [varchar](25) NULL,
	[CheckCrTyp] [varchar](25) NULL,
 CONSTRAINT [pkacc] PRIMARY KEY CLUSTERED 
(
	[Acc_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[inkashtbakup]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[inkashtbakup](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS](
	[USERID] [varchar](50) NULL,
	[User_Id] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
	[GROUPID] [varchar](2) NOT NULL,
	[ACSTAT] [bit] NOT NULL,
	[PWDCHANGE] [bit] NOT NULL,
	[User_Designation] [varchar](20) NULL,
	[location] [varchar](10) NULL,
	[Creation_Date] [datetime] NULL,
	[Date_Update ] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rtnrjct1]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[rtnrjct1](
	[reject_code] [char](2) NULL,
	[reject_reason] [char](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikashtab2]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikashtab2](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[checktotal2]    Script Date: 02/27/2013 16:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[checktotal2](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OCEBBK_org]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OCEBBK_org](
	[ECESettlementDate] [nvarchar](50) NULL,
	[ECESessionTime] [nvarchar](50) NULL,
	[ECESettlementTime] [nvarchar](50) NULL,
	[ECEItemType] [nvarchar](50) NULL,
	[ExternalProcessingCode] [nvarchar](50) NULL,
	[IssuingBranchRoutingNumber] [nvarchar](50) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[ItemAmount] [money] NULL,
	[ECEInstitutionItemSeqNumber] [nvarchar](50) NULL,
	[DocumentationTypeIndicator] [nvarchar](50) NULL,
	[ReturnAcceptanceIndicator] [nvarchar](50) NULL,
	[TranCode] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OCECITI]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OCECITI](
	[ECESettlementDate] [nvarchar](50) NULL,
	[ECESessionTime] [nvarchar](50) NULL,
	[ECESettlementTime] [nvarchar](50) NULL,
	[ECEItemType] [nvarchar](50) NULL,
	[ExternalProcessingCode] [nvarchar](50) NULL,
	[IssuingBranchRoutingNumber] [nvarchar](50) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[ItemAmount] [money] NULL,
	[ECEInstitutionItemSeqNumber] [nvarchar](50) NULL,
	[DocumentationTypeIndicator] [nvarchar](50) NULL,
	[ReturnAcceptanceIndicator] [nvarchar](50) NULL,
	[TranCode] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OCEBBK_ORG2]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OCEBBK_ORG2](
	[ECESettlementDate] [nvarchar](50) NULL,
	[ECESessionTime] [nvarchar](50) NULL,
	[ECESettlementTime] [nvarchar](50) NULL,
	[ECEItemType] [nvarchar](50) NULL,
	[ExternalProcessingCode] [nvarchar](50) NULL,
	[IssuingBranchRoutingNumber] [nvarchar](50) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[ItemAmount] [money] NULL,
	[ECEInstitutionItemSeqNumber] [nvarchar](50) NULL,
	[DocumentationTypeIndicator] [nvarchar](50) NULL,
	[ReturnAcceptanceIndicator] [nvarchar](50) NULL,
	[TranCode] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InwardReturn]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InwardReturn](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpcheck]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpcheck](
	[chqnumber] [varchar](15) NOT NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[debtcredit] [money] NULL,
	[itemamount] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[QueryInwret]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[QueryInwret]
as
SELECT Nikashtab.*, bankbranchQuery.*
FROM Nikashtab INNER JOIN bankbranchQuery ON Nikashtab.BankTo=bankbranchQuery.NikBranch_Code
WHERE Nikashtab.status='R'
GO
/****** Object:  Table [dbo].[tmpcheck1]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpcheck1](
	[chqnumber] [varchar](15) NOT NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[debtcredit] [money] NULL,
	[itemamount] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewNikReturn]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[ViewNikReturn]
as
SELECT NikReturn.*, bankbranchQuery.*
FROM NikReturn INNER JOIN bankbranchQuery ON NikReturn.BankFROM=bankbranchQuery.NikBranch_Code
WHERE NikReturn.status='R'
GO
/****** Object:  Table [dbo].[OCECITI1]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OCECITI1](
	[IssuingBranchRoutingNumber] [nvarchar](50) NULL,
	[ItemAmount] [money] NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IRE]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IRE](
	[PayorBankRoutingNumber] [nvarchar](50) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[BOFDRepresentmentIndicator] [nvarchar](50) NULL,
	[ItemAmount] [float] NULL,
	[ReturnReason] [nvarchar](50) NULL,
	[ReturnReasonAddendumCount] [nvarchar](50) NULL,
	[ReturnDocumentationTypeIndicator] [nvarchar](50) NULL,
	[ForwardBundleDate] [nvarchar](50) NULL,
	[ECEInstitutionItemSequenceNumber] [nvarchar](50) NULL,
	[ExternalProcessingCode] [nvarchar](50) NULL,
	[ReturnNotificationIndicator] [nvarchar](50) NULL,
	[ReturnArchiveTypeIndicator] [nvarchar](50) NULL,
	[OffsetofDigitalSignature] [nvarchar](50) NULL,
	[TranCode] [nvarchar](50) NULL,
	[Item_Id] [nvarchar](50) NULL,
	[~~END~~] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ire1]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ire1](
	[PayorBankRoutingNumber] [nvarchar](50) NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[ChequeSequenceNumber] [nvarchar](50) NULL,
	[BOFDRepresentmentIndicator] [nvarchar](50) NULL,
	[ItemAmount] [float] NULL,
	[ReturnReason] [nvarchar](50) NULL,
	[ReturnReasonAddendumCount] [nvarchar](50) NULL,
	[ReturnDocumentationTypeIndicator] [nvarchar](50) NULL,
	[ForwardBundleDate] [nvarchar](50) NULL,
	[ECEInstitutionItemSequenceNumber] [nvarchar](50) NULL,
	[ExternalProcessingCode] [nvarchar](50) NULL,
	[ReturnNotificationIndicator] [nvarchar](50) NULL,
	[ReturnArchiveTypeIndicator] [nvarchar](50) NULL,
	[OffsetofDigitalSignature] [nvarchar](50) NULL,
	[TranCode] [nvarchar](50) NULL,
	[Item_Id] [nvarchar](50) NULL,
	[~~END~~] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SameDayNikashtab]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SameDayNikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
 CONSTRAINT [Pk_SDOprBnkchqRem] PRIMARY KEY CLUSTERED 
(
	[OprDate] ASC,
	[BankFrom] ASC,
	[ChqNumber] ASC,
	[Remark] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TMPCRBOOKING_NIKASH]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMPCRBOOKING_NIKASH](
	[rowid] [uniqueidentifier] NULL,
	[credtype] [varchar](3) NULL,
	[SunAccNo] [varchar](15) NULL,
	[Amount] [numeric](14, 2) NULL,
	[refno] [varchar](10) NULL,
	[ValueDate] [datetime] NULL,
	[revdate] [datetime] NULL,
	[days] [varchar](2) NULL,
	[Remarks] [varchar](80) NULL,
	[deptyp] [varchar](5) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpDrbooking_Nikash]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpDrbooking_Nikash](
	[rowid] [uniqueidentifier] NULL DEFAULT (newid()),
	[credtype] [varchar](3) NULL,
	[SunAccNo] [varchar](16) NULL,
	[Amount] [numeric](14, 2) NULL,
	[refno] [varchar](10) NULL,
	[ValueDate] [datetime] NULL,
	[revdate] [datetime] NULL,
	[days] [varchar](2) NULL,
	[Remarks] [varchar](80) NULL,
	[deptyp] [varchar](5) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SameDayNikashtabhist]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SameDayNikashtabhist](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikbank1]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikbank1](
	[Bank_Code] [varchar](3) NULL,
	[Bank_name] [varchar](100) NULL,
	[headadd1] [varchar](35) NULL,
	[headadd2] [varchar](35) NULL,
	[headadd3] [varchar](35) NULL,
	[NikBank_Code] [varchar](2) NULL,
	[Acc_no] [varchar](16) NULL,
	[Entrydate] [smalldatetime] NULL,
	[Bank_shname] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SameDayNikReturn]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SameDayNikReturn](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
 CONSTRAINT [PK_SameDayNikReturn] PRIMARY KEY CLUSTERED 
(
	[OprDate] ASC,
	[BankFrom] ASC,
	[ChqNumber] ASC,
	[Remark] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tynikashtab]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tynikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tchecktotal]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tchecktotal](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpnikashtabselect]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpnikashtabselect](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](10) NOT NULL,
	[BankTo] [varchar](10) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SameDayNikReturnhist]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SameDayNikReturnhist](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmp1nikashtab]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmp1nikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NOT NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NikReturnhist]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NikReturnhist](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmp1checktotal]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmp1checktotal](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikreturn]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikreturn](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikashtabhist]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikashtabhist](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
	[PDC_Loation] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[system_log]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[system_log](
	[log_date] [datetime] NULL,
	[log_time] [datetime] NULL,
	[log_time_text] [nvarchar](20) NULL,
	[log_user] [nvarchar](20) NULL,
	[log_level] [smallint] NULL,
	[log_description] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TmpNikashtab]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpNikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Holiday](
	[holi_day] [datetime] NOT NULL,
	[holi_type] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpSameDayclientdata]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpSameDayclientdata](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TmpSameDayNikashtab]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpSameDayNikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpreversal_Nikash]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpreversal_Nikash](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](18, 5) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[client_code] [char](16) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[Deposit_Type] [varchar](5) NULL,
	[Acc_no] [varchar](16) NULL,
	[location_code] [varchar](3) NULL,
	[crtyp] [varchar](2) NULL,
	[ds_code] [varchar](16) NULL,
	[seqno] [numeric](5, 0) NULL,
	[chqnumber] [varchar](30) NULL,
	[Add_text] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reversalhist_Nikash]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reversalhist_Nikash](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](20, 5) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[client_code] [char](16) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[Deposit_Type] [varchar](5) NULL,
	[Acc_no] [varchar](16) NULL,
	[location_code] [varchar](3) NULL,
	[crtyp] [varchar](2) NULL,
	[ds_code] [varchar](10) NULL,
	[seqno] [numeric](5, 0) NULL,
	[chqnumber] [varchar](30) NULL,
	[Add_text] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SameDaychecktotal]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SameDaychecktotal](
	[ds_code] [nvarchar](8) NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NULL,
	[customer_ref] [nvarchar](15) NULL,
	[Location_code] [nvarchar](3) NULL,
	[Acc_No] [nvarchar](15) NULL,
	[EntryLoc] [nvarchar](5) NULL,
	[FileName] [nvarchar](15) NULL,
	[Userid] [nvarchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TmpSameDayChecktotal]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TmpSameDayChecktotal](
	[ds_code] [nvarchar](8) NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NULL,
	[customer_ref] [nvarchar](15) NULL,
	[Location_code] [nvarchar](3) NULL,
	[Acc_No] [nvarchar](15) NULL,
	[EntryLoc] [nvarchar](5) NULL,
	[FileName] [nvarchar](15) NULL,
	[Userid] [nvarchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SameDaychecktotalhist]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SameDaychecktotalhist](
	[ds_code] [nvarchar](8) NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NULL,
	[customer_ref] [nvarchar](15) NULL,
	[Location_code] [nvarchar](3) NULL,
	[Acc_No] [nvarchar](15) NULL,
	[EntryLoc] [nvarchar](5) NULL,
	[FileName] [nvarchar](15) NULL,
	[Userid] [nvarchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewSDNikReturn]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[ViewSDNikReturn]
as
SELECT SameDayNikReturn.*, bankbranchQuery.*
FROM SameDayNikReturn INNER JOIN bankbranchQuery ON SameDayNikReturn.BankFROM=bankbranchQuery.NikBranch_Code
WHERE SameDayNikReturn.status='R'
GO
/****** Object:  View [dbo].[SDQueryInwret]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[SDQueryInwret]
as
SELECT SameDayNikashtab.*, bankbranchQuery.*
FROM SameDayNikashtab INNER JOIN bankbranchQuery ON SameDayNikashtab.BankTo=bankbranchQuery.NikBranch_Code
WHERE SameDayNikashtab.status='R'
GO
/****** Object:  Table [dbo].[TMPBOOKING_NIKASH]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMPBOOKING_NIKASH](
	[rowid] [uniqueidentifier] NULL,
	[refno] [varchar](10) NULL,
	[amount] [numeric](10, 2) NULL,
	[valueDate] [datetime] NULL,
	[Revdate] [datetime] NULL,
	[Acc_No] [char](15) NULL,
	[RefAcc_No] [varchar](15) NULL,
	[days] [varchar](2) NULL,
	[d_code] [varchar](15) NULL,
	[deptyp] [varchar](15) NULL,
	[chqnumber] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IBBSreftab_nikash]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IBBSreftab_nikash](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[Acc_No] [char](15) NULL,
	[RefAcc_No] [varchar](15) NULL,
	[d_code] [varchar](16) NULL,
	[chqnumber] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Checktotalhist]    Script Date: 02/27/2013 16:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Checktotalhist](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
 CONSTRAINT [PK_checktotalhist] PRIMARY KEY CLUSTERED 
(
	[ds_code] ASC,
	[oprdate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IBBSReturnhist_Nikash]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IBBSReturnhist_Nikash](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[client_code] [char](15) NULL,
	[RefAcc_No] [varchar](15) NULL,
	[Deposit_Type] [varchar](5) NULL,
	[Acc_no] [varchar](15) NULL,
	[location_code] [varchar](3) NULL,
	[crtyp] [varchar](2) NULL,
	[ds_code] [varchar](16) NULL,
	[seqno] [numeric](3, 0) NULL,
	[chqnumber] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[checktotal]    Script Date: 02/27/2013 16:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[checktotal](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
 CONSTRAINT [PK_checktotal] PRIMARY KEY CLUSTERED 
(
	[ds_code] ASC,
	[oprdate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewNikReturnhist]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[ViewNikReturnhist] 
as  
SELECT NikReturnhist.*, bankbranchQuery.*  
FROM NikReturnhist INNER JOIN bankbranchQuery ON NikReturnhist.BankFROM=bankbranchQuery.NikBranch_Code  
WHERE NikReturnhist.status='R'
GO
/****** Object:  View [dbo].[QueryInwrethist]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[QueryInwrethist]  
as  
SELECT Nikashtabhist.*, bankbranchQuery.*  
FROM Nikashtabhist INNER JOIN bankbranchQuery ON Nikashtabhist.BankTo=bankbranchQuery.NikBranch_Code  
WHERE Nikashtabhist.status='R'
GO
/****** Object:  Table [dbo].[AccInfo]    Script Date: 02/27/2013 16:31:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccInfo](
	[MainCd] [nvarchar](2) NULL,
	[SubCode1] [nvarchar](4) NULL,
	[SubCode2] [nvarchar](2) NULL,
	[AccName] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CitiBranches]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitiBranches](
	[NikBranch_Code] [nvarchar](7) NULL,
	[Branch_name] [nvarchar](35) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tmpchecktotal1]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpchecktotal1](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpnikbranch]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpnikbranch](
	[Bank_Code] [nvarchar](3) NULL,
	[Branch_Code] [nvarchar](3) NULL,
	[Branch_name] [nvarchar](35) NULL,
	[Location_Code] [nvarchar](3) NULL,
	[Branch_add1] [nvarchar](35) NULL,
	[Branch_add2] [nvarchar](35) NULL,
	[Clearing_zone] [nvarchar](3) NULL,
	[Corrbank] [nvarchar](1) NULL,
	[NikBranch_Code] [nvarchar](7) NULL,
	[Entrydate] [smalldatetime] NULL,
	[SDClear] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tmp_nikashtab]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmp_nikashtab](
	[OprDate] [datetime] NOT NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](7) NOT NULL,
	[BankTo] [varchar](7) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NOT NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [money] NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NOT NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](40) NULL,
	[EntryLoc] [varchar](5) NULL,
	[ds_code] [varchar](8) NOT NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[Authorizer_id] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[IBBSFileName] [varchar](15) NULL,
	[Is_PDC] [bit] NULL,
 CONSTRAINT [PK_tmp_nikashtab] PRIMARY KEY CLUSTERED 
(
	[OprDate] ASC,
	[BankFrom] ASC,
	[ChqNumber] ASC,
	[Remark] ASC,
	[ds_code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpnikbank]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpnikbank](
	[Bank_Code] [nvarchar](3) NULL,
	[Bank_name] [nvarchar](35) NULL,
	[headadd1] [nvarchar](35) NULL,
	[headadd2] [nvarchar](35) NULL,
	[headadd3] [nvarchar](35) NULL,
	[NikBank_Code] [nvarchar](2) NULL,
	[Acc_no] [nvarchar](15) NULL,
	[Entrydate] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ELocation]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELocation](
	[EnLocation_Code] [nvarchar](5) NOT NULL,
	[EnLocation_Name] [nvarchar](35) NULL,
	[BANK_CODE] [nvarchar](3) NULL,
	[NikBranch_Code] [nvarchar](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genprm]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[genprm](
	[Batchno] [varchar](10) NULL,
	[Refno] [nvarchar](10) NULL,
	[Seqno] [nvarchar](7) NULL,
	[batchdate] [datetime] NULL,
	[oprdate] [datetime] NULL,
	[DebitACC] [varchar](20) NULL,
	[ACCBRANCH] [varchar](3) NULL,
	[BankFrom] [varchar](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NikBranch]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NikBranch](
	[Bank_Code] [varchar](3) NOT NULL,
	[Branch_Code] [varchar](3) NULL,
	[Branch_name] [varchar](35) NULL,
	[Location_Code] [varchar](3) NULL,
	[Branch_add1] [varchar](35) NULL,
	[Branch_add2] [varchar](35) NULL,
	[Clearing_zone] [varchar](3) NULL,
	[Corrbank] [varchar](1) NULL,
	[NikBranch_Code] [varchar](7) NOT NULL,
	[Entrydate] [smalldatetime] NULL,
	[SDClear] [bit] NULL,
 CONSTRAINT [pk_NikBranch] PRIMARY KEY CLUSTERED 
(
	[NikBranch_Code] ASC,
	[Bank_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReturnReason$]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnReason$](
	[DRAWER’S SIGNATURE DIFFER] [nvarchar](255) NULL,
	[F2] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tmp24checktotal]    Script Date: 02/27/2013 16:31:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmp24checktotal](
	[ds_code] [varchar](8) NOT NULL,
	[total_chkno] [int] NULL,
	[total_chkamt] [money] NULL,
	[oprdate] [smalldatetime] NOT NULL,
	[customer_ref] [varchar](50) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_No] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[revgenerate_Nikash]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[revgenerate_Nikash] as                               
delete from tmpreversal_Nikash                              
                                
                                  
insert into tmpreversal_Nikash( crtyp,refno,valuedate,location_code,RevDate,                                  
Acc_No,RefAcc_No,client_code,amount,deposit_type,ds_code,chqnumber,seqno,Add_text)                                  
                                  
                          
------By Total                                  
select c.speedcrtyp,a.refno,oprdate valueDate,'000' as location_code,a.oprdate,c.acc_no Acc_No,'G010009198050161' RefAcc_No,                                  
a.remark,sum(a.debtcredit) as total,'Check',substring(CONVERT(varchar(12), oprdate,112),3,8)as ds_code,substring(CONVERT(varchar(12), oprdate,112),3,8) chqnumber,count(a.remark),'' Add_text                               
from Nikashtab a, Nikclient c                                  
where                                   
--convert(datetime,convert(varchar(12), a.oprdate))<= convert(datetime,convert(varchar(12), getdate()))                                   
--left(a.RevDate,12) <= left(getdate(),12)                                   
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                                   
a.debtcredit>0                                  
and a.remark=c.acc_no                        
and a.ibbsfilename is null                                  
--and a.filename ='F7012.000'                                  
and c.speedcrtyp='T'                              
--group by b.client_code,a.refno,c.speedcrtyp                                  
group by a.oprdate,a.refno,c.speedcrtyp,                                  
c.Acc_No ,a.remark                
union all            
            
------By Deposit code                                  
select c.speedcrtyp,a.refno,oprdate valueDate,'000' as location_code,a.oprdate,c.acc_no Acc_No,'G010009198050161' RefAcc_No,                                  
a.remark,sum(a.debtcredit) as total,'Check',a.ds_code ,a.ds_code chqnumber,count(a.remark),'' Add_text                               
from Nikashtab a, Nikclient c                                  
where                                   
---convert(datetime,convert(varchar(12), a.oprdate))<= convert(datetime,convert(varchar(12), getdate()))                                   
--left(a.RevDate,12) <= left(getdate(),12)                                   
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                                   
 a.debtcredit>0                                  
and a.remark=c.acc_no                        
and a.ibbsfilename is null                                  
--and a.filename ='F7012.000'                                  
and c.speedcrtyp='D'                              
--group by b.client_code,a.refno,c.speedcrtyp                                  
group by a.oprdate,a.refno,c.speedcrtyp,                                  
c.Acc_No ,a.remark,a.ds_code               
                                  
                                  
union all                                  
--\\\\\\\\\\\\\\\By Check\\\\\\\\                                  
                                
                                
select  c.speedcrtyp,a.refno,a.oprdate,'000',a.oprdate,a.remark,'G010009198050161' RefAcc_No,                                  
a.remark,a.debtcredit,'Check',ds_code,a.chqnumber,1  ,'' Add_text                               
from Nikashtab a,Nikclient c                       
where                                   
--convert(datetime,convert(varchar(12), a.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                                   
--left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                                    
 a.debtcredit>0                                  
and a.remark=c.acc_no          
and a.ibbsfilename is null                                  
and c.speedcrtyp='C'                     
                      
union all                
                
select  c.speedcrtyp,a.refno,a.oprdate,'000',a.oprdate,a.remark,'G010009198050161' RefAcc_No,                                  
a.remark,a.debtcredit,'Check',a.refno , a.chqnumber ,1 ,'' Add_text                              
from Nikashtab a,Nikclient c                       
where                                   
---convert(datetime,convert(varchar(12), a.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                                   
--left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                                    
 a.debtcredit>0                                  
and c.Acc_no=a.remark                        
and a.ibbsfilename is null                                  
and c.speedcrtyp='R'                                  
        
union all                
                
select  c.speedcrtyp,a.refno,a.oprdate,'000',a.oprdate,a.remark,'G010009198050161' RefAcc_No,                                  
a.remark,a.debtcredit,'Check',a.refno , a.ds_code ,1  ,'Chq:'+ a.chqnumber +'  ' + e.bank_name +space(2)+ ' ' + d.branch_name Add_text                             
from Nikashtab a,Nikclient c, NikBranch d ,nikbank e                    
where                                   
---convert(datetime,convert(varchar(12), a.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                                   
--left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                                    
 a.debtcredit>0                                  
and c.Acc_no=a.remark                        
and a.ibbsfilename is null                                  
and c.speedcrtyp='B'        
and a.bankto=d.nikbranch_code        
and d.bank_code=e.bank_code        

union all  
------By DepositRef                                 
select c.speedcrtyp,a.refno,a.oprdate valueDate,'000' as location_code,a.oprdate,c.acc_no Acc_No,'G010009198050161' RefAcc_No,                                  
a.remark,sum(a.debtcredit) as total,'Check',a.ds_code ,d.Customer_ref chqnumber,count(a.remark),'' Add_text                               
from Nikashtab a, Nikclient c  , checktotal  d                              
where                                   
---convert(datetime,convert(varchar(12), a.oprdate))<= convert(datetime,convert(varchar(12), getdate()))                                   
--left(a.RevDate,12) <= left(getdate(),12)                                   
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                                   
 a.debtcredit>0                                  
and a.remark=c.acc_no                        
and a.ibbsfilename is null   
and a.ds_code=d.ds_code                               
--and a.filename ='F7012.000'                                  
and c.speedcrtyp='DR'                              
--group by b.client_code,a.refno,c.speedcrtyp                                  
group by a.oprdate,a.refno,c.speedcrtyp,                                  
c.Acc_No ,a.remark,a.ds_code ,d.Customer_ref
GO
/****** Object:  StoredProcedure [dbo].[SpHistCallBack]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpHistCallBack]      
@StartDate datetime,      
@EndDate   datetime      
 /*===============================================================================                            
 Object         :         
 Description    :  Generates comment headers for SQL scripts                            
 Usage Table    :                       
 Workfile       :  SpHistCallBack                      
 Author         :  Dewan Ahsanullah Designation: Analyst Programemr                            
 Created Date   :  21-03-05.           
 Revision by    :        
 Revision Date  :       
*/--============================================================================        
      
as      
Declare      
      
 @OprDate  smalldatetime,         
 @BankTo   nvarchar (8),        
 @ChqNumber  nvarchar (15),         
 @Remark   nvarchar (15),        
 @ds_code  nvarchar (8) ,       
 @Count  smallint          
  
        delete from Nikashtab where oprdate  between @StartDate and @EndDate  
  
 insert into Nikashtab  select *        
 from nikashtabhist      
 where oprdate between @StartDate and @EndDate  
  
 delete from Nikashtabhist where oprdate  between @StartDate and @EndDate  
  
  
         --First delete from check table and then insert into checktotal table  
        delete from checktotal where oprdate between @StartDate and @EndDate  
  
 insert into checktotal  select * from Checktotalhist      
 where oprdate between @StartDate and @EndDate  
  
        delete from checktotalhist where oprdate between @StartDate and @EndDate     
 --now   
        delete from Nikreturn where oprdate between @StartDate and @EndDate  
 ---Delete from Nikreturnhist  
  
 insert into Nikreturn(OprDate,IssueDate,BankFrom,BankTo,      
 PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,      
 DebtCredit,ErrCode,Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,      
 status,ReturnDate,FileName,seqno,checked,Authorizer_id,refno,IBBSFileName   )       
  
 select OprDate,IssueDate,BankFrom,BankTo,      
 PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,      
 Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName      
 ,seqno,checked,Authorizer_id,refno,IBBSFileName       
 from Nikreturnhist      
 where oprdate between @StartDate and @EndDate  
        
        delete from Nikreturnhist where oprdate between @StartDate and @EndDate
GO
/****** Object:  StoredProcedure [dbo].[pdctransfer]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[pdctransfer] @pissudate  datetime as 
insert into Nikashtab (OprDate,IssueDate,BankFrom,BankTo,PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit, 
          errcode , Remark, BatchNo, Ds_slip, CheckRef, EntryLoc, ds_code, Status, ReturnDate, FileName, UserId, seqno, Checked,
          Authorizer_id , Refno, IBBSFileName, Is_PDC,PDC_Loation) 
          select IssueDate,oprdate,BankFrom,BankTo,PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,
          errcode , Remark, BatchNo, Ds_slip, CheckRef, EntryLoc, ds_code, Status, ReturnDate, FileName, UserId, seqno, Checked, 
           Authorizer_id,refno,IBBSFileName,1,PDC_Loation from PDC where issuedate = @pissudate
              
           
insert into checktotal ( total_chkno,total_chkamt,ds_code,acc_no,oprdate,entryloc,filename,userid,customer_ref,Location_code ) 
select count(chqnumber)total_chkno,sum(debtcredit)total_chkamt,  ds_code,remark,issuedate,'01'entryloc,''filename,''userid,''customer_ref,''Location_code from pdc 
 Where issuedate = @pissudate group by ds_code,remark,issuedate 
delete from PDC where issuedate = @pissudate
GO
/****** Object:  StoredProcedure [dbo].[SpReturn_Nikash]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SpReturn_Nikash] as                     
delete from tmpreversal_Nikash                    
                      
                        
insert into tmpreversal_Nikash( crtyp,refno,valuedate,location_code,RevDate,                        
Acc_No,RefAcc_No,client_code,amount,b.deposit_type,b.ds_code)                        
                        
                
------By Total                        
select c.speedcrtyp,'',b.oprdate,'000' as location_code,getdate(),                      
b.remark,'','',sum(b.debtcredit) as total,'Check',substring(CONVERT(varchar(10), oprdate,112),3,8)                       
from Nikashtab b,Nikclient c                        
where                         
convert(datetime,convert(varchar(12), b.oprdate))<= convert(datetime,convert(varchar(12), getdate()))                         
--left(a.RevDate,12) <= left(getdate(),12)                         
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                         
and b.debtcredit>0                        
and b.Remark=c.acc_no              
--and a.filename is null                        
--and a.filename ='F7012.000'                        
and c.speedcrtyp='T'                    
and b.bankfrom ='2600001'                    
and b.status='R'          
--group by b.client_code,a.refno,c.speedcrtyp                        
group by b.Remark,b.oprdate,c.speedcrtyp                        
        
                        
                        
union all                        
--\\\\\\\\\\\\\\\By Check\\\\\\\\                        
-----select c.speedcrtyp,a.refno,b.client_code,d.amount                       
                      
                      
select  c.speedcrtyp,'',b.oprdate,'000',getdate(),      
b.Remark,'','',b.debtcredit,'Check',b.chqnumber                        
from Nikclient c,Nikashtab b              
where                         
convert(datetime,convert(varchar(12), b.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                         
--left(a.RevDate,12) <= left(getdate(),12)                         
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                          
and b.debtcredit>0                        
and b.Remark=c.Acc_No               
---and a.filename is null                        
and b.bankfrom ='2600001'                        
and c.speedcrtyp='C'                        
and b.status='R'          
     


union all

---For novartis check reference wise credit

select  c.speedcrtyp,'',b.oprdate,'000',getdate(),      
b.Remark,'','',b.debtcredit,'Check',b.chqnumber                        
from Nikclient c,Nikashtab b              
where                         
convert(datetime,convert(varchar(12), b.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                         
--left(a.RevDate,12) <= left(getdate(),12)                         
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                          
and b.debtcredit>0                        
and b.Remark=c.Acc_No               
---and a.filename is null                        
and b.bankfrom ='2600001'                        
and c.speedcrtyp='R'                        
and b.status='R'               
          
                        
insert into tmpreversal_Nikash( crtyp,refno,valuedate,location_code,RevDate,                        
Acc_No,RefAcc_No,client_code,amount,b.deposit_type,b.ds_code)                        
  
-----For SameDay Clearing Data    
    
------By Total                        
select c.speedcrtyp,'',b.oprdate,'000' as location_code,getdate(),                      
b.remark,'','',sum(b.debtcredit) as total,'Check',substring(CONVERT(varchar(10), oprdate,112),3,8)                       
from SameDayNikashtab b,Nikclient c                        
where                         
convert(datetime,convert(varchar(12), b.oprdate))<= convert(datetime,convert(varchar(12), getdate()))                         
--left(a.RevDate,12) <= left(getdate(),12)                         
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                         
and b.debtcredit>0                        
and b.Remark=c.acc_no              
--and a.filename is null                        
--and a.filename ='F7012.000'                        
and c.speedcrtyp='T'                    
and b.bankfrom ='2600001'                    
and b.status='R'          
--group by b.client_code,a.refno,c.speedcrtyp                        
group by b.Remark,b.oprdate,c.speedcrtyp                        
        
                        
                        
union all                        
--\\\\\\\\\\\\\\\By Check\\\\\\\\                        
-----select c.speedcrtyp,a.refno,b.client_code,d.amount                       
                      
                 
select  c.speedcrtyp,'',b.oprdate,'000',getdate(),      
b.Remark,'','',b.debtcredit,'Check',b.chqnumber                        
from Nikclient c,SameDayNikashtab b              
where                         
convert(datetime,convert(varchar(12), b.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                         
--left(a.RevDate,12) <= left(getdate(),12)                         
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                          
and b.debtcredit>0                        
and b.Remark=c.Acc_No               
---and a.filename is null                        
and b.bankfrom ='2600001'                        
and c.speedcrtyp='C'                        
and b.status='R'          
            
  
------CheckRef wise credit

select  c.speedcrtyp,'',b.oprdate,'000',getdate(),      
b.Remark,'','',b.debtcredit,'Check',b.chqnumber                        
from Nikclient c,SameDayNikashtab b              
where                         
convert(datetime,convert(varchar(12), b.oprdate)) <= convert(datetime,convert(varchar(12), getdate()))                         
--left(a.RevDate,12) <= left(getdate(),12)                         
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                          
and b.debtcredit>0                        
and b.Remark=c.Acc_No               
---and a.filename is null                        
and b.bankfrom ='2600001'                        
and c.speedcrtyp='R'                        
and b.status='R'
GO
/****** Object:  StoredProcedure [dbo].[UpdateIREReturn]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateIREReturn] as 

update nikashtabhist  set status='R',errcode=b.returnreason  
from nikashtabhist a,IRE b where b.ChequeSequenceNumber=a.chqnumber
and b.itemamount=a.debtcredit
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDTREFERENCE_Nikash]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UPDTREFERENCE_Nikash]        
@FileNm varchar(15),        
@Seqno varchar(20),        
@ValueDate datetime ,              
@GenPrmRefno varchar(10), --Last refno for genprm table        
@batno  varchar(10)        
        
 as           
Declare           
          
       @vCcode Char(6),           
       @vrefno varchar(10),          
       @vdays varchar(2),          
       @vcnt numeric,          
       @DCODE VARCHAR(10),          
       @VREVDATE DATETIME  ,            
       @REFACCNO varchar(15),          
       @deptype  varchar(15)        
          
---1          
---Start Begin Transaction        
        
BEGIN TRAN              
           
    BEGIN                
    --****Update Nikashtab table Check wise       
     Update NIKASHTAB set IBBSfilename=@FileNm,seqno=@Seqno where refno is null and IBBSfilename is null  and oprdate <= @ValueDate        
        and bankfrom ='2600001'                   
      
   ---*****Update SameDayNikashtab     
        --****Update Nikashtab table Check wise       
     Update SameDayNIKASHTAB set IBBSfilename=@FileNm,seqno=@Seqno where refno is null and IBBSfilename is null  and oprdate <= @ValueDate        
        and bankfrom ='2600001'        
        
    ---1          
       DECLARE GLTCURSOR CURSOR  for          
              
            SELECT REFNO,revdate,SunAccNO,deptyp FROM TMPCRBOOKING_NIKASH      
              
       OPEN GLTCURSOR           
              
       FETCH NEXT FROM GLTCURSOR INTO          
              
         @vrefno,@VREVDATE,@REFACCNO, @deptype          
              
       WHILE @@FETCH_STATUS=0           
              
        BEGIN           
         UPDATE TMPBOOKING_NIKASH SET REFNO=@VREFNO, RefAcc_No=@REFACCNO WHERE REVDATE=@VREVDATE          
            and deptyp= @deptype          
            FETCH NEXT FROM GLTCURSOR INTO          
            @VREFNO,@VREVDATE,@REFACCNO,@deptype            
                 
       END          
       CLOSE GLTCURSOR          
              
       DEALLOCATE GLTCURSOR          
              
              
    ---2          
    DECLARE GLTCURSOR CURSOR  FOR                    
                     
            SELECT REFNO,D_CODE FROM TMPBOOKING_NIKASH          
              
    OPEN  GLTCURSOR           
              
    FETCH NEXT FROM GLTCURSOR           
              
    INTO @VREFNO,@DCODE          
               
    WHILE @@FETCH_STATUS=0                   
      BEGIN          
         UPDATE NIKASHTAB SET REFNO=@VREFNO WHERE DS_CODE=@DCODE       
         UPDATE SAMEDAYNIKASHTAB SET REFNO=@VREFNO WHERE DS_CODE=@DCODE       
      FETCH NEXT FROM GLTCURSOR INTO           
        @VREFNO,@DCODE          
     END          
              
              
              
    CLOSE GLTCURSOR           
    DEALLOCATE GLTCURSOR          
              
    ---3          
                
        insert into IBBSREFTab_NIKASH(refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code,revergen,chqnumber)          
          select refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code,@FileNm fname,chqnumber from TMPBOOKING_NIKASH      
              
     --4 update genprm after generate files.        
    Update db_citibank..genprm set batchno=@batno ,refno=@GenPrmRefno        
            
        
    END              
               
  IF @@ERROR<>0 GOTO ErrorHandler                
                 
   COMMIT TRAN                    
   RETURN 0                 
                           
    ErrorHandler:                
  PRINT 'Record Does not Inserted/Updated:'                
  ROLLBACK TRAN                
  RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[SpDatainitialize]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpDatainitialize] @Startdate datetime   

 /*===============================================================================                          
 Object         :       
 Description    :  Generates comment headers for SQL scripts                          
 Usage Table    :                     
 Workfile       :  SpDatainitialize                    
 Author         :  Dewan Ahsanullah Designation: Analyst Programemr                          
 Created Date   :  21-03-05.         
 Revision by    :      
 Revision Date  :     
*/--============================================================================      
    
as    
Declare    
    
 @OprDate  smalldatetime,       
 @BankTo   nvarchar (8),      
 @ChqNumber  nvarchar (15),       
 @Remark   nvarchar (15),      
 @ds_code  nvarchar (8) ,     
 @Count  smallint        
    
    
Declare CurDatainit Cursor for    
Select ds_code,oprdate,Remark,ChqNumber,BankTo from nikashtab  where oprdate 
=@Startdate
           
Open CurDatainit     
fetch next from  CurDatainit    
into @ds_code,@oprdate,@Remark,@ChqNumber,@BankTo    
    
while @@Fetch_status =0    
    Begin       
    set @count=(select Count(ds_code)from nikashtabhist     
       where ds_code=@ds_code and Oprdate=@oprdate and     
       Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo)     
      If @count=0     
         Begin      
              ----Insert Data from nakashtable to nikashtablehist    
      insert into Nikashtabhist  select OprDate,IssueDate,BankFrom,BankTo,    
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,    
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,Userid  
  ,seqno,checked,Authorizer_id,refno,IBBSFileName    
      from nikashtab    
      where ds_code=@ds_code and Oprdate=@oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo     
          
                  ----Insert Data from Nireturn table to nikreturnhist    
      insert into Nikreturnhist(OprDate,IssueDate,BankFrom,BankTo,    
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,    
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,seqno,checked,Authorizer_id,refno,IBBSFileName  )    
                  select OprDate,IssueDate,BankFrom,BankTo,    
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,    
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName    
  ,seqno,checked,Authorizer_id,refno,IBBSFileName    
              from Nikreturn    
      where ds_code=@ds_code and Oprdate=@oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo     
                  
      ---After insert data into history table Delete data from Nikash table data    
      Delete from nikashtab where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo     
    
      Delete from Nikreturn where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo     
      
         End        
         Else    
     Begin    
      Delete from nikashtab where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo     
          
      Delete from Nikreturn where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo    
      End    
         
     --@2nd check for checktotal    
    set @count=(select Count(ds_code)from checktotal     
       where ds_code=@ds_code and Oprdate=@oprdate)     
      If @count=0     
    Begin    
      -----Insert Data from Checktotal to Checktotalhist    
     insert into checktotalhist  select ds_code,total_chkno,total_chkamt,oprdate,    
     customer_ref,Location_code,Acc_No,EntryLoc,FileName,Userid from Checktotal    
         
               ---After insert data into hitory table delete data from checktotal    
     Delete from Checktotal where ds_code=@ds_code and Oprdate=@Oprdate     
         
    End    
   Else    
    Begin    
             
     Delete from checktotal where ds_code=@ds_code and Oprdate=@Oprdate     
    
    End    
           
    
       
  Fetch next from CurDatainit     
  into @ds_code,@oprdate,@Remark,@ChqNumber,@BankTo    
  End    
Close CurDatainit    
Deallocate CurDatainit
GO
/****** Object:  StoredProcedure [dbo].[SpDatainitializeParam]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROCEDURE [dbo].[SpDatainitializeParam]          
 /*===============================================================================                                
 Object         :             
 Description    :  Generates comment headers for SQL scripts                                
 Usage Table    :                           
 Workfile       :  SpDatainitialize                          
 Author         :  Dewan Ahsanullah Designation: Analyst Programemr                                
 Created Date   :  21-03-05.               
 Revision by    :            
 Revision Date  :           
*/--============================================================================            
@StartDate datetime,          
@EndDate   datetime          
as          
Declare          
          
 @OprDate  smalldatetime,             
 @BankTo   nvarchar (8),            
 @ChqNumber  nvarchar (15),             
 @Remark   nvarchar (15),            
 @ds_code  nvarchar (8) ,           
 @Count  smallint              
          
/*          
Declare CurDatainit Cursor for          
Select ds_code,oprdate,Remark,ChqNumber,BankTo from nikashtab           
                 
Open CurDatainit           
fetch next from  CurDatainit          
into @ds_code,@oprdate,@Remark,@ChqNumber,@BankTo          
          
while @@Fetch_status =0          
    Begin             
    set @count=(select Count(ds_code)from nikashtabhist           
       where ds_code=@ds_code and Oprdate=@oprdate and           
       Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo)           
      If @count=0           
         Begin            
              ----Insert Data from nakashtable to nikashtablehist          
      insert into Nikashtabhist  select OprDate,IssueDate,BankFrom,BankTo,          
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,          
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,Userid         
     ,seqno,checked,Authorizer_id,refno,IBBSFileName         
              from nikashtab          
      where ds_code=@ds_code and Oprdate=@oprdate and           
      Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo           
                
                  ----Insert Data from Nireturn table to nikreturnhist          
      insert into Nikreturnhist(OprDate,IssueDate,BankFrom,BankTo,          
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,          
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,seqno,checked,Authorizer_id,refno,IBBSFileName)          
                  select OprDate,IssueDate,BankFrom,BankTo,          
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,          
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName         
      ,seqno,checked,Authorizer_id,refno,IBBSFileName         
              from Nikreturn          
      where ds_code=@ds_code and Oprdate=@oprdate and           
      Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo           
                        
      ---After insert data into history table Delete data from Nikash table data          
      Delete from nikashtab where ds_code=@ds_code and Oprdate=@Oprdate and           
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo           
          
      Delete from Nikreturn where ds_code=@ds_code and Oprdate=@Oprdate and           
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo           
            
         End              
         Else          
     Begin          
      Delete from nikashtab where ds_code=@ds_code and Oprdate=@Oprdate and           
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo           
                
      Delete from Nikreturn where ds_code=@ds_code and Oprdate=@Oprdate and           
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo          
      End          
               
     --@2nd check for checktotal          
    set @count=(select Count(ds_code)from checktotal           
       where ds_code=@ds_code and Oprdate=@oprdate)           
If @count=0           
    Begin          
      -----Insert Data from Checktotal to Checktotalhist          
     insert into checktotalhist  select ds_code,total_chkno,total_chkamt,oprdate,          
     customer_ref,Location_code,Acc_No,EntryLoc,FileName,Userid from Checktotal          
               
               ---After insert data into hitory table delete data from checktotal          
     Delete from Checktotal where ds_code=@ds_code and Oprdate=@Oprdate           
               
    End          
   Else          
    Begin          
                   
     Delete from checktotal where ds_code=@ds_code and Oprdate=@Oprdate           
          
    End          
                 
          
             
  Fetch next from CurDatainit           
  into @ds_code,@oprdate,@Remark,@ChqNumber,@BankTo          
  End          
Close CurDatainit          
Deallocate CurDatainit          
*/      
        
  /*          
    set @count=(select Count(ds_code)from nikashtabhist where oprdate  between @StartDate and @EndDate )           
    If @count>0       
    Begin  
        delete from Nikashtabhist where oprdate  between @StartDate and @EndDate      
    end  
      
 insert into Nikashtabhist       
        select OprDate,IssueDate,BankFrom,BankTo,          
 PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,          
 Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,Userid          
 ,seqno,checked,Authorizer_id,refno,IBBSFileName,IS_PDC,PDC_Loation           
 from nikashtab          
 where oprdate between @StartDate and @EndDate      
           
        delete from Nikashtab where oprdate  between @StartDate and @EndDate      
      
  */     
        --First delete from check table and then insert into checktotal table      
        delete from checktotalhist where oprdate between @StartDate and @EndDate      
      
 insert into checktotalhist  select ds_code,total_chkno,total_chkamt,oprdate,          
 customer_ref,Location_code,Acc_No,EntryLoc,FileName,Userid from Checktotal      
 where oprdate between @StartDate and @EndDate      
      
        delete from checktotal where oprdate between @StartDate and @EndDate        
 --now       
        delete from Nikreturnhist where oprdate between @StartDate and @EndDate      
 ---Delete from Nikreturnhist      
   
 insert into Nikreturnhist(OprDate,IssueDate,BankFrom,BankTo,          
 PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,          
 DebtCredit,ErrCode,Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,          
 status,ReturnDate,FileName,seqno,checked,Authorizer_id,refno,IBBSFileName,IS_PDC   )           
      
 select OprDate,IssueDate,BankFrom,BankTo,          
 PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,          
 Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName          
 ,seqno,checked,Authorizer_id,refno,IBBSFileName, IS_PDC         
 from Nikreturn      
 where oprdate between @StartDate and @EndDate           
       
        delete from Nikreturn where oprdate between @StartDate and @EndDate           

--Update PDC check status
update nikashtabhist set status='P' where is_PDC=1 and oprdate between @StartDate and @EndDate
GO
/****** Object:  View [dbo].[nikashqry]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[nikashqry] as (
select * from nikashtabhist where oprdate
between '2009-02-10' and  '2009-02-10'
)
GO
/****** Object:  StoredProcedure [dbo].[SP_HOLIDAY_Nikash]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_HOLIDAY_Nikash] as   
Declare   
  
       @vcnt1  int,  
       @vcnt2  int,  
       @vcnt3  int,  
       @vFdt  datetime,  
       @vDelDt datetime,  
       @vDcode varchar(8)   
  
  
  
 DECLARE GLTCURSOR CURSOR FOR  
 select d_code,valuedate,convert(numeric(2),days) as Days,dateadd(day,convert(numeric(2),days),valuedate) as delivery  
        from tmpbooking_Nikash  
        --where d_code='8008556'  
  
  
 OPEN GLTCURSOR   
 FETCH NEXT FROM GLTCURSOR   
        INTO @VDcode,@vFdt,@vCnt2,@vDelDt  
  
  
 WHILE @@FETCH_STATUS=0   
  BEGIN  
  
          set @vcnt1=1  
  
            While @vcnt1<=@vcnt2  
  
  Begin  
                      
                    set @vFdt=(select dateadd(day,1,@vFdt))  
      set @vcnt3=0    
                    set @vcnt3=(select count(1) as cnt from holiday_Nikash where holi_day=@vFdt)  
                        
                    If @vcnt3>0       
                      Begin  
                        set @vDelDt=(select dateadd(day,1,@vDelDt))  
                        set @vcnt2=@vcnt2+1       
                          
                      End    
                                        
   
                     set @vcnt1=@vcnt1+1  
    End  
  
               
                  Update tmpbooking_nikash set revdate= @vDelDt where d_code=@VDcode             
  
  
  
  
 FETCH NEXT FROM GLTCURSOR   
 INTO @VDcode,@vFdt,@vCnt2,@vDelDt  
 END  
   
 CLOSE GLTCURSOR  
 DEALLOCATE GLTCURSOR
GO
/****** Object:  StoredProcedure [dbo].[SpSDayDatainitialize]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpSDayDatainitialize]    
 /*===============================================================================                          
 Object         :       
 Description    :  Generates comment headers for SQL scripts                          
 Usage Table    :                     
 Workfile       :  SpDatainitialize                    
 Author         :  Dewan Ahsanullah Designation: Analyst Programemr                          
 Created Date   :  21-03-05.         
 Revision by    :      
 Revision Date  :     
*/--============================================================================      
    
as    
Declare    
    
 @OprDate  smalldatetime,       
 @BankTo   nvarchar (8),      
 @ChqNumber  nvarchar (15),       
 @Remark   nvarchar (15),      
 @ds_code  nvarchar (8) ,     
 @Count  smallint        
    
    
Declare CurDatainit Cursor for    
Select ds_code,oprdate,Remark,ChqNumber,BankTo from SameDaynikashtab     
           
Open CurDatainit     
fetch next from  CurDatainit    
into @ds_code,@oprdate,@Remark,@ChqNumber,@BankTo    
    
while @@Fetch_status =0    
    Begin       
    set @count=(select Count(ds_code)from nikashtabhist     
       where ds_code=@ds_code and Oprdate=@oprdate and     
       Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo)     
      If @count=0     
         Begin      
              ----Insert Data from nakashtable to nikashtablehist    
      insert into Nikashtabhist  select OprDate,IssueDate,BankFrom,BankTo,    
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,    
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,Userid 
		,seqno,checked,Authorizer_id,refno,IBBSFileName   
              from SameDaynikashtab    
      where ds_code=@ds_code and Oprdate=@oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo     
          
                  ----Insert Data from Nireturn table to nikreturnhist    
      insert into Nikreturnhist(OprDate,IssueDate,BankFrom,BankTo,    
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,    
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName,seqno,checked,Authorizer_id,refno,IBBSFileName)    
                  select OprDate,IssueDate,BankFrom,BankTo,    
        PayeeNm,ChqSeries,ChqNumber,ChqNo,BookNo,ChqType,AccntNo,DebtCredit,ErrCode,    
      Remark,BatchNo,Ds_slip,CheckRef,EntryLoc,ds_code,status,ReturnDate,FileName
     ,seqno,checked,Authorizer_id,refno,IBBSFileName   
              from SameDayNikreturn    
      where ds_code=@ds_code and Oprdate=@oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and BankTo=@BankTo     
                  
      ---After insert data into history table Delete data from Nikash table data    
      Delete from SameDaynikashtab where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo     
    
      Delete from SameDayNikreturn where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo     
      
         End        
         Else    
     Begin    
      Delete from SameDaynikashtab where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo     
          
      Delete from SameDayNikreturn where ds_code=@ds_code and Oprdate=@Oprdate and     
      Remark=@Remark and ChqNumber=@ChqNumber and  BankTo=@BankTo    
      End    
         
     --@2nd check for checktotal    
    set @count=(select Count(ds_code)from SameDaychecktotal     
       where ds_code=@ds_code and Oprdate=@oprdate)     
      If @count=0     
    Begin    
      -----Insert Data from Checktotal to Checktotalhist    
     insert into checktotalhist  select ds_code,total_chkno,total_chkamt,oprdate,    
     customer_ref,Location_code,Acc_No,EntryLoc,FileName,Userid from Checktotal    
         
               ---After insert data into hitory table delete data from checktotal    
     Delete from SameDayChecktotal where ds_code=@ds_code and Oprdate=@Oprdate     
         
    End    
   Else    
    Begin    
             
     Delete from SameDaychecktotal where ds_code=@ds_code and Oprdate=@Oprdate     
    
    End    
           
    
       
  Fetch next from CurDatainit     
  into @ds_code,@oprdate,@Remark,@ChqNumber,@BankTo    
  End    
Close CurDatainit    
Deallocate CurDatainit
GO
/****** Object:  View [dbo].[viewSDCitispeedDeposit]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[viewSDCitispeedDeposit]
as
SELECT 
SameDaychecktotal.total_chkno,
SameDaychecktotal.total_chkamt,
SameDaychecktotal.customer_ref,
SameDaychecktotal.Acc_No
, SameDayNikashtab.*, bankbranchQuery.*
FROM (SameDaychecktotal RIGHT JOIN SameDayNikashtab ON SameDaychecktotal.ds_code = SameDayNikashtab.ds_code)
INNER JOIN bankbranchQuery ON SameDayNikashtab.BankTo = bankbranchQuery.NikBranch_Code
GO
/****** Object:  View [dbo].[bankbranchQuery]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[bankbranchQuery]  
as  
SELECT NikBANK.Bank_Code, isnull(NikBANK.Bank_name,'')Bank_name, NikBranch.Branch_Code,   
isnull(NikBranch.Branch_name,'')Branch_name, NikBANK.NikBank_Code, NikBranch.Location_Code,   
NikBranch.NikBranch_Code  
FROM NikBranch LEFT JOIN NikBANK ON NikBranch.Bank_Code = NikBANK.Bank_Code
GO
/****** Object:  View [dbo].[viewdormnatAccount]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewdormnatAccount] as 
select * from nikashtab 
left JOIN bankbranchQuery ON nikashtab.BankTo = bankbranchQuery.NikBranch_Code 
where remark not in 
(select remark from nikashtabhist where  datediff(day,oprdate,getdate())<=360)
GO
/****** Object:  View [dbo].[viewCitispeedDeposit]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    view [dbo].[viewCitispeedDeposit]  
as  
SELECT   
checktotal.total_chkno,  
checktotal.total_chkamt,  
isnull(checktotal.customer_ref,'')customer_ref,  
checktotal.Acc_No  
, Nikashtab.*, bankbranchQuery.*  
FROM (checktotal RIGHT JOIN Nikashtab ON checktotal.ds_code = Nikashtab.ds_code  
and checktotal.oprdate=Nikashtab.oprdate )  
left JOIN bankbranchQuery ON Nikashtab.BankTo = bankbranchQuery.NikBranch_Code
GO
/****** Object:  StoredProcedure [dbo].[SP_BOOKING_NIKASH]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[SP_BOOKING_NIKASH] as               
Declare               
              
       @vCcode Char(6),               
       @vrefno varchar(10),              
       @vdays varchar(2),              
       @vcnt numeric,              
       @DCODE VARCHAR(10)              
--1              
              
DELETE TMPBOOKING_nikash             
                
--2              
INSERT INTO tmpbooking_nikash (refno,amount,valuedate,revdate,acc_no,DAYS,D_code, deptyp,chqnumber)              
 select D.refno,D.debtcredit as amt,D.oprdate,              
 DATEADD(day,convert(int,C.citicash),D.oprdate)REVDATE,c.acc_no,C.citicash,D.ds_code,              
 'Check',chqnumber           
 From NikClient  C, Nikashtab D              
 where D.remark=(C.acc_no)              
 and  debtcredit>0 and refno is null               
 and bankfrom ='2600001'      
    
/*    
INSERT INTO tmpbooking_nikash (refno,amount,valuedate,revdate,acc_no,DAYS,D_code, deptyp,chqnumber)              
 select D.refno,D.debtcredit as amt,D.oprdate,              
 DATEADD(day,convert(int,C.citicash),D.oprdate)REVDATE,c.acc_no,C.citicash,D.ds_code,              
 'Check',chqnumber           
 From NikClient  C, SameDayNikashtab D              
 where D.remark=(C.acc_no)              
 and  debtcredit>0 and refno is null               
 and bankfrom ='2600001'      
*/
    
--Union ALL            
 --select D.refno,D.debtcredit as amt,D.oprdate,              
 ---DATEADD(day,convert(int,C.citispeed),D.oprdate )REVDATE,c.acc_no,C.citispeed,D.d_code,              
 --'Check'      
 ---From NikClient C, Nikashtab D              
 ---where D.remark=(C.acc_no)              
 ---and  debtcredit>0 and refno is null           
-- and convert(datetime,convert(varchar(10),D.optdate,101))               
----       < convert(datetime,convert(varchar(10),getdate(),101))          
--3              
exec SP_HOLIDAY_Nikash
GO
/****** Object:  View [dbo].[viewCitispeedDepositPDC]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   view [dbo].[viewCitispeedDepositPDC]  
as  
SELECT   
PDCchecktotal.total_chkno,  
PDCchecktotal.total_chkamt,  
isnull(PDCchecktotal.customer_ref,'')customer_ref,  
PDCchecktotal.Acc_No  
, PDC.*, bankbranchQuery.*  
FROM (PDCchecktotal RIGHT JOIN PDC ON PDCchecktotal.ds_code = PDC.ds_code  
and PDCchecktotal.oprdate=PDC.oprdate )  
left JOIN bankbranchQuery ON PDC.BankTo = bankbranchQuery.NikBranch_Code
GO
/****** Object:  View [dbo].[viewCitispeedDeposithist]    Script Date: 02/27/2013 16:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   view [dbo].[viewCitispeedDeposithist]              
as              
SELECT         
checktotalhist.total_chkno,        
checktotalhist.total_chkamt,        
isnull(checktotalhist.customer_ref,'')customer_ref,        
checktotalhist.Acc_No        
, Nikashtabhist.*      
,bankbranchQuery.Bank_Code, isnull(bankbranchQuery.Bank_name,'')Bank_name, bankbranchQuery.Branch_Code,         
isnull(bankbranchQuery.Branch_name,'')Branch_name, bankbranchQuery.NikBank_Code, bankbranchQuery.Location_Code,         
bankbranchQuery.NikBranch_Code        
FROM (checktotalhist RIGHT JOIN Nikashtabhist ON checktotalhist.ds_code = Nikashtabhist.ds_code     
and checktotalhist.oprdate=Nikashtabhist.oprdate )        
left JOIN bankbranchQuery ON Nikashtabhist.BankTo = bankbranchQuery.NikBranch_Code
GO
