USE [db_citibank]
GO
/****** Object:  User [apac\bdctisvcmssqlidp01]    Script Date: 09/19/2012 13:28:14 ******/
CREATE USER [apac\bdctisvcmssqlidp01] FOR LOGIN [APAC\bdctisvcmssqlidp01] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\bdicgsvcbmcpatrolp01]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APAC\bdicgsvcbmcpatrolp01] FOR LOGIN [APAC\bdicgsvcbmcpatrolp01] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\DBAPKD10951]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APAC\DBAPKD10951] FOR LOGIN [APAC\DBAPKD10951] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\DBAPMP59378]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APAC\DBAPMP59378] FOR LOGIN [APAC\DBAPMP59378] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\dbapng67675]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APAC\dbapng67675] FOR LOGIN [APAC\dbapng67675] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\dbaprb98155]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APAC\dbaprb98155] FOR LOGIN [APAC\dbaprb98155] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APAC\inbomccdptbrdcisa]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APAC\inbomccdptbrdcisa] FOR LOGIN [APAC\inbomccdptbrdcisa]
GO
/****** Object:  User [APACBDMTJAS01\SQLServer2005MSFTEUser$APACBDMTJAS01$MSSQLSERVER]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APACBDMTJAS01\SQLServer2005MSFTEUser$APACBDMTJAS01$MSSQLSERVER] FOR LOGIN [APACBDMTJAS01\SQLServer2005MSFTEUser$APACBDMTJAS01$MSSQLSERVER]
GO
/****** Object:  User [APACBDMTJAS01\SQLServer2005MSSQLUser$APACBDMTJAS01$MSSQLSERVER]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APACBDMTJAS01\SQLServer2005MSSQLUser$APACBDMTJAS01$MSSQLSERVER] FOR LOGIN [APACBDMTJAS01\SQLServer2005MSSQLUser$APACBDMTJAS01$MSSQLSERVER]
GO
/****** Object:  User [APACBDMTJAS01\SQLServer2005SQLAgentUser$APACBDMTJAS01$MSSQLSERVER]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [APACBDMTJAS01\SQLServer2005SQLAgentUser$APACBDMTJAS01$MSSQLSERVER] FOR LOGIN [APACBDMTJAS01\SQLServer2005SQLAgentUser$APACBDMTJAS01$MSSQLSERVER]
GO
/****** Object:  User [EUCAPP]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [EUCAPP] FOR LOGIN [EUCAPP] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 09/19/2012 13:28:15 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[TmpExciseDuty]    Script Date: 09/19/2012 13:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpExciseDuty](
	[Acc_No] [varchar](16) NULL,
	[Acc_Name] [varchar](40) NULL,
	[Amount] [numeric](13, 2) NULL,
	[Remarks] [varchar](100) NULL,
	[Refno] [varchar](10) NULL,
	[ExcFileName] [varchar](50) NULL,
	[IBBSFileName] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TmpNikashtab]    Script Date: 09/19/2012 13:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpNikashtab](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [varchar](20) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[Mechine] [varchar](8) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpchecktotal]    Script Date: 09/19/2012 13:26:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpchecktotal](
	[ds_code] [varchar](8) NULL,
	[total_chkno] [numeric](18, 0) NULL,
	[total_chkamt] [numeric](18, 0) NULL,
	[oprdate] [datetime] NULL,
	[customer_ref] [varchar](15) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_no] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccInfo]    Script Date: 09/19/2012 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccInfo](
	[MainCd] [varchar](2) NULL,
	[SubCode1] [varchar](4) NULL,
	[SubCode2] [varchar](2) NULL,
	[AccName] [varchar](150) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ccash]    Script Date: 09/19/2012 13:20:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ccash](
	[d_code] [char](7) NOT NULL,
	[customer_ref] [char](15) NULL,
	[slip_date] [datetime] NULL,
	[entry_date] [datetime] NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ccash] ADD [cashref] [varchar](15) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationCharge]    Script Date: 09/19/2012 13:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationCharge](
	[Client_code] [char](6) NOT NULL,
	[Location_Code] [char](3) NOT NULL,
	[Charge] [numeric](11, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ccheck]    Script Date: 09/19/2012 13:21:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ccheck](
	[slno] [numeric](3, 0) NOT NULL,
	[d_code] [char](7) NOT NULL,
	[client_code] [char](6) NOT NULL,
	[dlocation_code] [char](3) NOT NULL,
	[customer_ref] [char](15) NOT NULL,
	[slip_date] [datetime] NOT NULL,
	[value_date] [datetime] NOT NULL,
	[check_no] [char](15) NOT NULL,
	[amount] [numeric](10, 2) NOT NULL,
	[check_date] [datetime] NOT NULL,
	[check_type] [char](7) NOT NULL,
	[drawer] [char](35) NOT NULL,
	[drawee_bankcode] [char](3) NOT NULL,
	[location_code] [char](3) NULL,
	[branch_code] [char](3) NULL,
	[rejectref] [char](7) NULL,
	[zoneref] [char](10) NULL,
	[status] [char](1) NULL,
	[nonzoneref] [char](7) NULL,
	[printflag] [char](1) NULL,
	[OutStd_Date] [datetime] NULL,
	[entry_date] [datetime] NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ccheck] ADD [checkRef] [varchar](15) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cchecktotal]    Script Date: 09/19/2012 13:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[cchecktotal](
	[d_code] [char](7) NOT NULL,
	[total_chkno] [numeric](4, 0) NULL,
	[total_chkamt] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpschedulecheck]    Script Date: 09/19/2012 13:27:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpschedulecheck](
	[scheduleId] [tinyint] NULL,
	[schedulecode] [varchar](5) NULL,
	[ScheduleDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[clientold]    Script Date: 09/19/2012 13:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[clientold](
	[Client_Code] [char](4) NOT NULL,
	[Sub_Client] [char](2) NOT NULL,
	[Acc_No] [char](15) NOT NULL,
	[Acc_Name] [char](40) NULL,
	[Mail_Add1] [char](35) NULL,
	[Mail_Add2] [char](35) NULL,
	[mail_add3] [char](20) NULL,
	[Contact] [char](35) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[clientold] ADD [Citicash] [varchar](2) NULL
ALTER TABLE [dbo].[clientold] ADD [citispeed] [varchar](2) NULL
ALTER TABLE [dbo].[clientold] ADD [CashCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[clientold] ADD [SpeedCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[clientold] ADD [Citiclear] [varchar](2) NULL
ALTER TABLE [dbo].[clientold] ADD [ClearCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[clientold] ADD [CheckCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[clientold] ADD [DumAccNo] [varchar](10) NULL
ALTER TABLE [dbo].[clientold] ADD [Flag] [varchar](1) NULL
ALTER TABLE [dbo].[clientold] ADD [Branch_Code] [varchar](3) NULL
ALTER TABLE [dbo].[clientold] ADD [EntryDate] [datetime] NULL
ALTER TABLE [dbo].[clientold] ADD [CashCharge] [numeric](11, 2) NULL
ALTER TABLE [dbo].[clientold] ADD [CheckCharge] [numeric](11, 2) NULL
ALTER TABLE [dbo].[clientold] ADD [ReturnCharge] [numeric](11, 2) NULL
ALTER TABLE [dbo].[clientold] ADD [NetAmount] [numeric](15, 2) NULL
ALTER TABLE [dbo].[clientold] ADD [CitiAnyCharge] [numeric](9, 2) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[holiday]    Script Date: 09/19/2012 13:23:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[holiday](
	[holi_day] [datetime] NOT NULL,
	[holi_type] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[creturn]    Script Date: 09/19/2012 13:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[creturn](
	[returnref] [char](10) NOT NULL,
	[return_code] [char](2) NULL,
	[return_date] [datetime] NULL,
	[cs_code] [char](5) NULL,
	[rtn_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BatchNo]    Script Date: 09/19/2012 13:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BatchNo](
	[BatFrom] [varchar](4) NULL,
	[BatTo] [varchar](4) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cschedule]    Script Date: 09/19/2012 13:22:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[cschedule](
	[cs_code] [char](5) NOT NULL,
	[Schedule_Date] [datetime] NOT NULL,
	[Entry_Date] [datetime] NOT NULL,
	[Location_code] [char](3) NOT NULL,
	[Corr_bcode] [char](3) NULL,
	[corr_brcode] [char](3) NULL,
	[ds_code] [char](5) NOT NULL,
	[citicash_amount] [numeric](10, 2) NULL,
	[citicheck_amount] [numeric](10, 2) NULL,
	[No_check] [numeric](4, 0) NOT NULL,
	[no_checksreturned] [numeric](4, 0) NULL,
	[returned_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TmpCrbooking]    Script Date: 09/19/2012 13:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpCrbooking](
	[rowid] [uniqueidentifier] NULL DEFAULT (newid()),
	[credtype] [varchar](3) NULL,
	[SunAccNo] [varchar](16) NULL,
	[Amount] [numeric](14, 2) NULL,
	[refno] [varchar](10) NULL,
	[ValueDate] [datetime] NULL,
	[revdate] [datetime] NULL,
	[days] [varchar](2) NULL,
	[Remarks] [varchar](80) NULL,
	[deptyp] [varchar](5) NULL,
	[Sundryrefaccno] [varchar](16) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[csd]    Script Date: 09/19/2012 13:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[csd](
	[d_code] [char](7) NOT NULL,
	[check_no] [char](15) NULL,
	[drawer] [char](35) NULL,
	[draweebank_code] [char](3) NULL,
	[Entry_date] [datetime] NULL,
	[slno] [numeric](3, 0) NULL,
	[amount] [numeric](10, 2) NULL,
	[customer_ref] [char](15) NULL,
	[slip_date] [datetime] NULL,
	[check_date] [datetime] NULL,
	[drawee_branch] [char](35) NULL,
	[rtnstatus] [char](1) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[csd] ADD [checkRef] [varchar](15) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dcollected]    Script Date: 09/19/2012 13:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[dcollected](
	[Ds_code] [char](5) NOT NULL,
	[total_nochk] [numeric](4, 0) NULL,
	[total_chkamt] [numeric](10, 2) NULL,
	[total_cashamt] [numeric](10, 2) NULL,
	[no_checkscleared] [numeric](4, 0) NULL,
	[cleared_amount] [numeric](10, 2) NULL,
	[No_checksreturned] [numeric](4, 0) NULL,
	[Returned_amount] [numeric](10, 2) NULL,
	[cash_cleared] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dd]    Script Date: 09/19/2012 13:23:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[dd](
	[d_code] [char](5) NOT NULL,
	[slno] [numeric](3, 0) NOT NULL,
	[dd_No] [char](18) NOT NULL,
	[dd_date] [datetime] NULL,
	[entry_date] [datetime] NULL,
	[amount] [numeric](10, 2) NULL,
	[drawer_bankcode] [char](3) NULL,
	[drawer_brcode] [char](3) NULL,
	[drawer_location] [char](3) NULL,
	[drawee_branch] [char](25) NULL,
	[status] [char](1) NULL,
	[vat] [numeric](8, 0) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[dd] ADD [nikbranch_code] [varchar](7) NULL
ALTER TABLE [dbo].[dd] ADD [oprdate] [datetime] NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dschedule]    Script Date: 09/19/2012 13:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[dschedule](
	[ds_code] [char](5) NOT NULL,
	[D_code] [char](7) NOT NULL,
	[Deposit_Type] [char](5) NOT NULL,
	[citicash_amount] [numeric](10, 2) NULL,
	[citicheck_amount] [numeric](10, 2) NULL,
	[Schedule_Date] [datetime] NOT NULL,
	[Entry_Date] [datetime] NOT NULL,
	[No_check] [numeric](4, 0) NULL,
	[Client_code] [char](6) NOT NULL,
	[Location_code] [char](3) NOT NULL,
	[Corr_bcode] [char](3) NULL,
	[corr_brcode] [char](3) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[dschedule] ADD [FileName] [varchar](15) NULL
ALTER TABLE [dbo].[dschedule] ADD [refno] [varchar](10) NULL
ALTER TABLE [dbo].[dschedule] ADD [Authorizer_id] [varchar](25) NULL
ALTER TABLE [dbo].[dschedule] ADD [seqno] [numeric](3, 0) NULL
ALTER TABLE [dbo].[dschedule] ADD [checked] [tinyint] NULL
ALTER TABLE [dbo].[dschedule] ADD [userid] [varchar](25) NULL
ALTER TABLE [dbo].[dschedule] ADD [flexgendate] [datetime] NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CitiBanBranch]    Script Date: 09/19/2012 13:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CitiBanBranch](
	[Branch_Code] [varchar](3) NOT NULL,
	[Branch_Name] [varchar](35) NOT NULL,
	[Address1] [varchar](35) NULL,
	[Address2] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[Branch_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dscollection]    Script Date: 09/19/2012 13:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[dscollection](
	[d_code] [char](7) NOT NULL,
	[no_checkscleared] [numeric](4, 0) NULL,
	[cleared_amount] [numeric](10, 2) NULL,
	[no_checksreturned] [numeric](4, 0) NULL,
	[returned_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScheduleStock]    Script Date: 09/19/2012 13:25:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduleStock](
	[Location_Code] [varchar](3) NOT NULL,
	[sche_from] [varchar](8) NULL,
	[sche_upto] [varchar](8) NULL,
	[sche_date] [datetime] NULL,
	[bank_code] [varchar](3) NULL,
	[ScheduleId] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 09/19/2012 13:24:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Location](
	[Location_Code] [char](3) NOT NULL,
	[Location_Name] [char](35) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[normalcollection]    Script Date: 09/19/2012 13:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[normalcollection](
	[nonzoneref] [char](7) NOT NULL,
	[ref_date] [datetime] NULL,
	[status] [char](1) NULL,
	[status_date] [datetime] NULL,
	[ddrefno] [char](8) NULL,
	[collectedAmount] [numeric](10, 2) NULL,
	[vat] [numeric](8, 2) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[normalcollection] ADD [checkRef] [varchar](15) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Loc_not_charge]    Script Date: 09/19/2012 13:24:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Loc_not_charge](
	[Client_code] [char](6) NOT NULL,
	[Location_Code] [char](3) NOT NULL,
	[ReturnCheck] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TmpBooking]    Script Date: 09/19/2012 13:26:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TmpBooking](
	[rowid] [uniqueidentifier] NULL DEFAULT (newid()),
	[refno] [varchar](10) NULL,
	[amount] [numeric](10, 2) NULL,
	[valueDate] [datetime] NULL,
	[Revdate] [datetime] NULL,
	[Acc_No] [varchar](16) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[days] [varchar](2) NULL,
	[d_code] [varchar](7) NULL,
	[deptyp] [varchar](15) NULL,
	[Sundryrefaccno] [varchar](16) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[normalcollrtn]    Script Date: 09/19/2012 13:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[normalcollrtn](
	[nonzoneref] [char](7) NOT NULL,
	[code] [char](2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reject]    Script Date: 09/19/2012 13:25:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[reject](
	[reject_code] [char](2) NULL,
	[rejectref] [char](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rtnrjct]    Script Date: 09/19/2012 13:25:37 ******/
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
/****** Object:  Table [dbo].[SYSTEM_LOG]    Script Date: 09/19/2012 13:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[SYSTEM_LOG](
	[LOG_DATE] [datetime] NULL,
	[LOG_TIME] [datetime] NULL,
	[LOG_USER] [char](15) NOT NULL,
	[LOG_LEVEL] [numeric](2, 0) NULL,
	[LOG_DESCRIPTION] [varchar](75) NULL,
	[LOG_TIME_TEXT] [char](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpDepSlipcheck]    Script Date: 09/19/2012 13:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpDepSlipcheck](
	[scheduleId] [tinyint] NULL,
	[schedulecode] [varchar](7) NULL,
	[ScheduleDate] [datetime] NULL,
	[client_code] [varchar](6) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IBBSTranPara]    Script Date: 09/19/2012 13:24:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IBBSTranPara](
	[Tran_Code] [varchar](6) NOT NULL,
	[Tran_Name] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Tran_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[norcolrtn]    Script Date: 09/19/2012 13:25:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[norcolrtn](
	[nonzoneref] [char](7) NOT NULL,
	[code] [char](2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpmonbill]    Script Date: 09/19/2012 13:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpmonbill](
	[ds_code] [char](5) NULL,
	[D_code] [char](7) NULL,
	[citicash_amount] [numeric](12, 2) NULL,
	[citicheck_amount] [numeric](12, 2) NULL,
	[Schedule_Date] [datetime] NULL,
	[No_check] [numeric](18, 0) NULL,
	[Client_code] [char](6) NULL,
	[Location_code] [char](3) NULL,
	[CashCharge] [numeric](9, 2) NULL,
	[CheckCharge] [numeric](9, 2) NULL,
	[ReturnCharge] [numeric](9, 2) NULL,
	[charge] [numeric](9, 2) NULL,
	[Acc_Name] [varchar](40) NULL,
	[Location_Name] [varchar](35) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tempcreturn]    Script Date: 09/19/2012 13:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tempcreturn](
	[returnref] [char](10) NOT NULL,
	[return_code] [char](2) NULL,
	[return_date] [datetime] NULL,
	[cs_code] [char](5) NULL,
	[rtn_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dschedule_hist]    Script Date: 09/19/2012 13:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dschedule_hist](
	[ds_code] [char](5) NOT NULL,
	[D_code] [char](7) NOT NULL,
	[Deposit_Type] [char](5) NOT NULL,
	[citicash_amount] [numeric](10, 2) NULL,
	[citicheck_amount] [numeric](10, 2) NULL,
	[Schedule_Date] [datetime] NOT NULL,
	[Entry_Date] [datetime] NOT NULL,
	[No_check] [numeric](4, 0) NULL,
	[Client_code] [char](6) NOT NULL,
	[Location_code] [char](3) NOT NULL,
	[Corr_bcode] [char](3) NULL,
	[corr_brcode] [char](3) NULL,
	[FileName] [varchar](15) NULL,
	[refno] [varchar](10) NULL,
	[Authorizer_id] [varchar](25) NULL,
	[seqno] [numeric](3, 0) NULL,
	[checked] [tinyint] NULL,
	[userid] [varchar](25) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tempcschedule]    Script Date: 09/19/2012 13:25:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tempcschedule](
	[cs_code] [char](5) NOT NULL,
	[Schedule_Date] [datetime] NOT NULL,
	[Entry_Date] [datetime] NOT NULL,
	[Location_code] [char](3) NOT NULL,
	[Corr_bcode] [char](3) NULL,
	[corr_brcode] [char](3) NULL,
	[ds_code] [char](5) NOT NULL,
	[citicash_amount] [numeric](10, 2) NULL,
	[citicheck_amount] [numeric](10, 2) NULL,
	[No_check] [numeric](4, 0) NOT NULL,
	[no_checksreturned] [numeric](4, 0) NULL,
	[returned_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCASH_HIST]    Script Date: 09/19/2012 13:20:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCASH_HIST](
	[d_code] [char](7) NOT NULL,
	[customer_ref] [char](15) NULL,
	[slip_date] [datetime] NULL,
	[entry_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NORCOLRTN_HIST]    Script Date: 09/19/2012 13:25:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NORCOLRTN_HIST](
	[nonzoneref] [char](7) NOT NULL,
	[code] [char](2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[genprm]    Script Date: 09/19/2012 13:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[genprm](
	[Batchno] [varchar](4) NULL,
	[refno] [varchar](10) NULL,
	[regseqno] [varchar](7) NULL,
	[batchdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cchecktotal_hist]    Script Date: 09/19/2012 13:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cchecktotal_hist](
	[d_code] [char](7) NOT NULL,
	[total_chkno] [numeric](4, 0) NULL,
	[total_chkamt] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tempdd]    Script Date: 09/19/2012 13:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tempdd](
	[d_code] [char](5) NOT NULL,
	[slno] [numeric](3, 0) NOT NULL,
	[dd_No] [char](18) NOT NULL,
	[dd_date] [datetime] NULL,
	[entry_date] [datetime] NULL,
	[amount] [numeric](10, 2) NULL,
	[drawer_bankcode] [char](3) NULL,
	[drawer_brcode] [char](3) NULL,
	[drawer_location] [char](3) NULL,
	[drawee_branch] [char](25) NULL,
	[status] [char](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ccheck_hist]    Script Date: 09/19/2012 13:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ccheck_hist](
	[slno] [numeric](3, 0) NOT NULL,
	[d_code] [char](7) NOT NULL,
	[client_code] [char](6) NOT NULL,
	[dlocation_code] [char](3) NOT NULL,
	[customer_ref] [char](15) NOT NULL,
	[slip_date] [datetime] NOT NULL,
	[value_date] [datetime] NOT NULL,
	[check_no] [char](15) NOT NULL,
	[amount] [numeric](10, 2) NOT NULL,
	[check_date] [datetime] NOT NULL,
	[check_type] [char](7) NOT NULL,
	[drawer] [char](35) NOT NULL,
	[drawee_bankcode] [char](3) NOT NULL,
	[location_code] [char](3) NULL,
	[branch_code] [char](3) NULL,
	[rejectref] [char](7) NULL,
	[zoneref] [char](10) NULL,
	[status] [char](1) NULL,
	[nonzoneref] [char](7) NULL,
	[printflag] [char](1) NULL,
	[OutStd_Date] [datetime] NULL,
	[entry_date] [datetime] NULL,
	[checkRef] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[creturn_hist]    Script Date: 09/19/2012 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[creturn_hist](
	[returnref] [char](10) NOT NULL,
	[return_code] [char](2) NULL,
	[return_date] [datetime] NULL,
	[cs_code] [char](5) NULL,
	[rtn_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tempnormalcollection]    Script Date: 09/19/2012 13:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tempnormalcollection](
	[nonzoneref] [char](7) NOT NULL,
	[ref_date] [datetime] NULL,
	[status] [char](1) NULL,
	[status_date] [datetime] NULL,
	[ddrefno] [char](8) NULL,
	[collectedAmount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cschedule_hist]    Script Date: 09/19/2012 13:22:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cschedule_hist](
	[cs_code] [char](5) NOT NULL,
	[Schedule_Date] [datetime] NOT NULL,
	[Entry_Date] [datetime] NOT NULL,
	[Location_code] [char](3) NOT NULL,
	[Corr_bcode] [char](3) NULL,
	[corr_brcode] [char](3) NULL,
	[ds_code] [char](5) NOT NULL,
	[citicash_amount] [numeric](10, 2) NULL,
	[citicheck_amount] [numeric](10, 2) NULL,
	[No_check] [numeric](4, 0) NOT NULL,
	[no_checksreturned] [numeric](4, 0) NULL,
	[returned_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[csd_hist]    Script Date: 09/19/2012 13:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[csd_hist](
	[d_code] [char](7) NOT NULL,
	[check_no] [char](15) NULL,
	[drawer] [char](35) NULL,
	[draweebank_code] [char](3) NULL,
	[Entry_date] [datetime] NULL,
	[slno] [numeric](3, 0) NULL,
	[amount] [numeric](10, 2) NULL,
	[customer_ref] [char](15) NULL,
	[slip_date] [datetime] NULL,
	[check_date] [datetime] NULL,
	[drawee_branch] [char](35) NULL,
	[rtnstatus] [char](1) NULL,
	[checkRef] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Temptotalcs]    Script Date: 09/19/2012 13:26:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Temptotalcs](
	[cs_code] [char](5) NULL,
	[total_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dcollected_hist]    Script Date: 09/19/2012 13:22:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dcollected_hist](
	[Ds_code] [char](5) NOT NULL,
	[total_nochk] [numeric](4, 0) NULL,
	[total_chkamt] [numeric](10, 2) NULL,
	[total_cashamt] [numeric](10, 2) NULL,
	[no_checkscleared] [numeric](4, 0) NULL,
	[cleared_amount] [numeric](10, 2) NULL,
	[No_checksreturned] [numeric](4, 0) NULL,
	[Returned_amount] [numeric](10, 2) NULL,
	[cash_cleared] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[totalcs]    Script Date: 09/19/2012 13:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[totalcs](
	[cs_code] [char](5) NULL,
	[total_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dd_hist]    Script Date: 09/19/2012 13:23:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dd_hist](
	[d_code] [char](5) NOT NULL,
	[slno] [numeric](3, 0) NOT NULL,
	[dd_No] [char](18) NOT NULL,
	[dd_date] [datetime] NULL,
	[entry_date] [datetime] NULL,
	[amount] [numeric](10, 2) NULL,
	[drawer_bankcode] [char](3) NULL,
	[drawer_brcode] [char](3) NULL,
	[drawer_location] [char](3) NULL,
	[drawee_branch] [char](25) NULL,
	[status] [char](1) NULL,
	[vat] [numeric](8, 0) NULL,
	[nikbranch_code] [varchar](7) NULL,
	[oprdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 09/19/2012 13:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[USERS](
	[USER_ID] [char](15) NOT NULL,
	[DESIGNATION] [char](15) NULL,
	[PASSWORD] [char](15) NOT NULL,
	[System_log] [numeric](1, 0) NULL,
	[User_maintenance] [numeric](1, 0) NULL,
	[USER_GROUP] [numeric](2, 0) NULL,
	[User_enable] [numeric](1, 0) NULL,
	[Ch_psswd] [numeric](1, 0) NULL,
	[master_access] [numeric](1, 0) NULL,
	[userlbl_report] [numeric](1, 0) NULL,
	[manifold_report] [numeric](1, 0) NULL,
	[control_report] [numeric](1, 0) NULL,
	[UserDisable_access] [numeric](2, 0) NULL,
	[maker] [numeric](2, 0) NULL,
	[author] [numeric](2, 0) NULL,
	[System_setup] [numeric](2, 0) NULL,
	[chpsswd_access] [numeric](2, 0) NULL,
	[Creation_date] [datetime] NULL,
	[Date_update] [datetime] NULL,
	[Psswdhold1] [char](15) NULL,
	[Psswdhold2] [char](15) NULL,
	[Psswdhold3] [char](15) NULL,
	[Psswdhold4] [char](15) NULL,
	[Psswdhold5] [char](15) NULL,
	[Psswdhold6] [char](15) NULL,
	[Psswdhold7] [char](15) NULL,
	[Psswdhold8] [char](15) NULL,
	[Psswdhold9] [char](15) NULL,
	[Psswdhold10] [char](15) NULL,
	[Psswdhold11] [char](15) NULL,
	[Psswdhold12] [char](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TOTALCS_HIST]    Script Date: 09/19/2012 13:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TOTALCS_HIST](
	[cs_code] [char](5) NULL,
	[total_amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[zone]    Script Date: 09/19/2012 13:28:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[zone](
	[zone_code] [char](3) NOT NULL,
	[zone_name] [char](35) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NORMALCOLLECTION_HIST]    Script Date: 09/19/2012 13:25:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[NORMALCOLLECTION_HIST](
	[nonzoneref] [char](7) NOT NULL,
	[ref_date] [datetime] NULL,
	[status] [char](1) NULL,
	[status_date] [datetime] NULL,
	[ddrefno] [char](8) NULL,
	[collectedAmount] [numeric](10, 2) NULL,
	[vat] [numeric](8, 2) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[NORMALCOLLECTION_HIST] ADD [checkRef] [varchar](15) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[client]    Script Date: 09/19/2012 13:21:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[client](
	[Client_Code] [char](4) NOT NULL,
	[Sub_Client] [char](2) NOT NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[client] ADD [Acc_No] [varchar](16) NULL
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[client] ADD [Acc_Name] [char](40) NULL
ALTER TABLE [dbo].[client] ADD [Mail_Add1] [char](35) NULL
ALTER TABLE [dbo].[client] ADD [Mail_Add2] [char](35) NULL
ALTER TABLE [dbo].[client] ADD [mail_add3] [char](20) NULL
ALTER TABLE [dbo].[client] ADD [Contact] [char](35) NULL
SET ANSI_PADDING ON
ALTER TABLE [dbo].[client] ADD [Citicash] [varchar](2) NULL
ALTER TABLE [dbo].[client] ADD [citispeed] [varchar](2) NULL
ALTER TABLE [dbo].[client] ADD [CashCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[client] ADD [SpeedCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[client] ADD [Citiclear] [varchar](2) NULL
ALTER TABLE [dbo].[client] ADD [ClearCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[client] ADD [CheckCrTyp] [varchar](25) NULL
ALTER TABLE [dbo].[client] ADD [DumAccNo] [varchar](10) NULL
ALTER TABLE [dbo].[client] ADD [Flag] [varchar](1) NULL
ALTER TABLE [dbo].[client] ADD [Branch_Code] [varchar](3) NULL
ALTER TABLE [dbo].[client] ADD [EntryDate] [datetime] NULL
ALTER TABLE [dbo].[client] ADD [CashCharge] [numeric](11, 2) NULL
ALTER TABLE [dbo].[client] ADD [CheckCharge] [numeric](11, 2) NULL
ALTER TABLE [dbo].[client] ADD [ReturnCharge] [numeric](11, 2) NULL
ALTER TABLE [dbo].[client] ADD [NetAmount] [numeric](15, 2) NULL
ALTER TABLE [dbo].[client] ADD [CitiAnyCharge] [numeric](9, 2) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReversalHist]    Script Date: 09/19/2012 13:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReversalHist](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[client_code] [char](15) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[Deposit_Type] [varchar](5) NULL,
	[Acc_no] [varchar](16) NULL,
	[location_code] [varchar](3) NULL,
	[crtyp] [varchar](2) NULL,
	[ds_code] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[Sundryrefaccno] [varchar](16) NULL,
	[flexgendate] [datetime] NULL,
	[CheckDSno] [varchar](30) NULL,
	[CustomerRef] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IBBSBOOKING1]    Script Date: 09/19/2012 13:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IBBSBOOKING1](
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
	[d_code] [varchar](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpreversal]    Script Date: 09/19/2012 13:27:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpreversal](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[client_code] [char](15) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[Deposit_Type] [varchar](5) NULL,
	[Acc_no] [varchar](16) NULL,
	[location_code] [varchar](3) NULL,
	[crtyp] [varchar](2) NULL,
	[ds_code] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[Sundryrefaccno] [varchar](16) NULL,
	[flexgendate] [datetime] NULL,
	[CheckDSno] [varchar](30) NULL,
	[CustomerRef] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikclient]    Script Date: 09/19/2012 13:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikclient](
	[Client_Code] [char](4) NULL,
	[Sub_Client] [char](2) NULL,
	[Acc_No] [char](15) NULL,
	[Acc_Name] [char](40) NULL,
	[Mail_Add1] [char](35) NULL,
	[Mail_Add2] [char](35) NULL,
	[mail_add3] [char](20) NULL,
	[Contact] [char](35) NULL,
	[Citicash] [varchar](2) NULL,
	[citispeed] [varchar](2) NULL,
	[CashCrTyp] [varchar](25) NULL,
	[SpeedCrTyp] [varchar](25) NULL,
	[Citiclear] [varchar](2) NULL,
	[ClearCrTyp] [varchar](25) NULL,
	[CheckCrTyp] [varchar](25) NULL,
	[DumAccNo] [varchar](10) NULL,
	[Flag] [varchar](1) NULL,
	[Branch_Code] [varchar](3) NULL,
	[EntryDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikbranch]    Script Date: 09/19/2012 13:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikbranch](
	[Bank_Code] [varchar](3) NOT NULL,
	[Branch_Code] [varchar](3) NULL,
	[Branch_name] [varchar](35) NULL,
	[Location_Code] [varchar](3) NULL,
	[Branch_add1] [varchar](35) NULL,
	[Branch_add2] [varchar](35) NULL,
	[Clearing_zone] [varchar](3) NULL,
	[Corrbank] [varchar](1) NULL,
	[NikBranch_Code] [varchar](7) NOT NULL,
	[Entrydate] [datetime] NULL,
	[SDClear] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 09/19/2012 13:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch](
	[Bank_Code] [char](3) NOT NULL,
	[Branch_Code] [char](3) NOT NULL,
	[Branch_Name] [char](35) NULL,
	[Location_Code] [char](3) NULL,
	[branch_add1] [char](35) NULL,
	[branch_add2] [char](35) NULL,
	[clearing_zone] [char](3) NULL,
	[corrbank] [char](1) NULL,
	[NikBranch_Code] [varchar](7) NULL,
	[Entrydate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[testtmpreversal]    Script Date: 09/19/2012 13:26:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[testtmpreversal](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[client_code] [char](15) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[Deposit_Type] [varchar](5) NULL,
	[Acc_no] [varchar](16) NULL,
	[location_code] [varchar](3) NULL,
	[crtyp] [varchar](2) NULL,
	[ds_code] [varchar](15) NULL,
	[seqno] [numeric](3, 0) NULL,
	[Sundryrefaccno] [varchar](16) NULL,
	[flexgendate] [datetime] NULL,
	[CheckDSno] [varchar](30) NULL,
	[CustomerRef] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ELocation]    Script Date: 09/19/2012 13:23:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ELocation](
	[EnLocation_Code] [varchar](5) NULL,
	[EnLocation_Name] [varchar](35) NULL,
	[BANK_CODE] [varchar](3) NULL,
	[NikBranch_Code] [varchar](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChqType]    Script Date: 09/19/2012 13:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChqType](
	[ChqTypeNo] [varchar](8) NULL,
	[ChqTypeName] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustInfo]    Script Date: 09/19/2012 13:22:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustInfo](
	[Client_Code] [char](6) NOT NULL,
	[Sub_Client] [char](2) NOT NULL,
	[Acc_No] [char](15) NOT NULL,
	[Acc_Name] [char](40) NULL,
	[Citicash] [varchar](2) NULL,
	[citispeed] [varchar](2) NULL,
	[CashCrTyp] [varchar](25) NULL,
	[SpeedCrTyp] [varchar](25) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IBBSRefTab]    Script Date: 09/19/2012 13:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IBBSRefTab](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[Acc_No] [varchar](16) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[d_code] [varchar](7) NULL,
	[Sundryrefaccno] [varchar](16) NULL,
	[flexgendate] [datetime] NULL,
	[statusid] [tinyint] NULL,
	[TranStatus] [tinyint] NULL,
	[remarks] [varchar](100) NULL,
	[Authorize] [tinyint] NULL,
	[Authorizer_id] [varchar](25) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpDrbooking]    Script Date: 09/19/2012 13:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpDrbooking](
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
/****** Object:  Table [dbo].[IBBSREFTAB2]    Script Date: 09/19/2012 13:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IBBSREFTAB2](
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
	[d_code] [varchar](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[checktotal]    Script Date: 09/19/2012 13:21:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[checktotal](
	[ds_code] [varchar](8) NULL,
	[total_chkno] [numeric](18, 0) NULL,
	[total_chkamt] [numeric](18, 2) NULL,
	[oprdate] [datetime] NULL,
	[customer_ref] [varchar](15) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_no] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CheckRegister]    Script Date: 09/19/2012 13:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CheckRegister](
	[ds_code] [varchar](8) NULL,
	[total_chkno] [numeric](18, 0) NULL,
	[total_chkamt] [numeric](18, 2) NULL,
	[oprdate] [datetime] NULL,
	[customer_ref] [varchar](15) NULL,
	[Location_code] [varchar](3) NULL,
	[Acc_no] [varchar](15) NULL,
	[EntryLoc] [varchar](5) NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL,
	[Entry_date] [datetime] NULL,
	[serial] [numeric](18, 0) NULL CONSTRAINT [DF__CheckRegi__seria__55009F39]  DEFAULT (0)
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[test1]    Script Date: 09/19/2012 13:26:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[test1](
	[ds_code] [char](5) NOT NULL,
	[SCHEDULE_DATE] [datetime] NOT NULL,
	[CORR_BCODE] [char](3) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[test1] ADD [bank_name] [char](35) NULL
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[test1] ADD [LOCATION_CODE] [char](3) NOT NULL
ALTER TABLE [dbo].[test1] ADD [location_name] [char](35) NULL
SET ANSI_PADDING ON
ALTER TABLE [dbo].[test1] ADD [Sch_break] [varchar](1) NOT NULL
ALTER TABLE [dbo].[test1] ADD [citicheck_amount] [numeric](10, 2) NULL
ALTER TABLE [dbo].[test1] ADD [citicash_amount] [numeric](10, 2) NULL
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[test1] ADD [acc_name] [char](40) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikashtab]    Script Date: 09/19/2012 13:24:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikashtab](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [numeric](9, 2) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nikashtabhist]    Script Date: 09/19/2012 13:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nikashtabhist](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [numeric](9, 2) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tmpclientdata]    Script Date: 09/19/2012 13:27:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tmpclientdata](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [numeric](9, 2) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InwardReturn]    Script Date: 09/19/2012 13:24:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InwardReturn](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [numeric](9, 2) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANK]    Script Date: 09/19/2012 13:20:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANK](
	[BANK_CODE] [char](3) NOT NULL,
	[BANK_NAME] [char](35) NULL,
	[headadd1] [char](35) NULL,
	[headadd2] [char](35) NULL,
	[headadd3] [char](20) NULL,
	[nikBank_code] [varchar](2) NULL,
	[Accno] [varchar](16) NULL,
	[Entrydate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nikreturn]    Script Date: 09/19/2012 13:25:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nikreturn](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [numeric](9, 2) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[collection]    Script Date: 09/19/2012 13:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[collection](
	[OprDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[BankFrom] [varchar](8) NULL,
	[BankTo] [varchar](8) NULL,
	[PayeeNm] [varchar](40) NULL,
	[ChqSeries] [varchar](4) NULL,
	[ChqNumber] [varchar](15) NULL,
	[ChqNo] [varchar](8) NULL,
	[BookNo] [varchar](8) NULL,
	[ChqType] [varchar](8) NULL,
	[AccntNo] [varchar](15) NULL,
	[DebtCredit] [numeric](9, 2) NULL,
	[ErrCode] [varchar](8) NULL,
	[Remark] [varchar](15) NULL,
	[BatchNo] [varchar](8) NULL,
	[Ds_slip] [varchar](8) NULL,
	[CheckRef] [varchar](20) NULL,
	[EntryLoc] [varchar](4) NULL,
	[ds_code] [varchar](8) NULL,
	[status] [varchar](1) NULL,
	[ReturnDate] [datetime] NULL,
	[FileName] [varchar](15) NULL,
	[Userid] [varchar](15) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tempreminder_ch]    Script Date: 09/19/2012 13:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tempreminder_ch](
	[bankname] [varchar](35) NULL,
	[branchname] [varchar](35) NULL,
	[branchadd1] [varchar](35) NULL,
	[branchadd2] [varchar](35) NULL,
	[locationname] [varchar](35) NULL,
	[Slno] [varchar](20) NULL,
	[check_no] [varchar](20) NULL,
	[drawer] [varchar](50) NULL,
	[amount] [varchar](20) NULL,
	[nonzoneref] [varchar](20) NULL,
	[reminder] [varchar](20) NULL,
	[uniqbranchcd] [varchar](35) NULL,
	[numnonzoneref] [numeric](20, 0) NULL,
	[ref_date] [datetime] NULL,
	[client_code] [varchar](6) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TranStatus]    Script Date: 09/19/2012 13:27:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TranStatus](
	[statusid] [tinyint] NULL,
	[StatusName] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ibbsreftabhist]    Script Date: 09/19/2012 13:24:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ibbsreftabhist](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[Acc_No] [varchar](16) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[d_code] [varchar](7) NULL,
	[Sundryrefaccno] [varchar](16) NULL,
	[flexgendate] [datetime] NULL,
	[statusid] [tinyint] NULL,
	[TranStatus] [tinyint] NULL,
	[remarks] [varchar](100) NULL,
	[Authorize] [tinyint] NULL,
	[Authorizer_id] [varchar](25) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tempibbsreftab]    Script Date: 09/19/2012 13:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tempibbsreftab](
	[refno] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
	[ValueDate] [datetime] NULL,
	[userId] [varchar](10) NULL,
	[Uploaded] [varchar](15) NULL,
	[ReverGen] [varchar](15) NULL,
	[FileName] [varchar](15) NULL,
	[RevDate] [datetime] NULL,
	[Acc_No] [varchar](16) NULL,
	[RefAcc_No] [varchar](16) NULL,
	[d_code] [varchar](7) NULL,
	[Sundryrefaccno] [varchar](16) NULL,
	[flexgendate] [datetime] NULL,
	[statusid] [tinyint] NULL,
	[TranStatus] [tinyint] NULL,
	[remarks] [varchar](100) NULL,
	[Authorize] [tinyint] NULL,
	[Authorizer_id] [varchar](25) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tempdschedule]    Script Date: 09/19/2012 13:26:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Tempdschedule](
	[ds_code] [char](5) NOT NULL,
	[D_code] [char](7) NOT NULL,
	[Deposit_Type] [char](5) NOT NULL,
	[citicash_amount] [numeric](10, 2) NULL,
	[citicheck_amount] [numeric](10, 2) NULL,
	[Schedule_Date] [datetime] NOT NULL,
	[Entry_Date] [datetime] NOT NULL,
	[No_check] [numeric](4, 0) NULL,
	[Client_code] [char](6) NOT NULL,
	[Location_code] [char](3) NOT NULL,
	[Corr_bcode] [char](3) NULL,
	[corr_brcode] [char](3) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[Tempdschedule] ADD [FileName] [varchar](15) NULL
ALTER TABLE [dbo].[Tempdschedule] ADD [refno] [varchar](10) NULL
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SpExciseDutyUpload]    Script Date: 09/19/2012 13:20:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SpExciseDutyUpload]  
  
@Acc_No  varchar(18) ,     
@Acc_Name  varchar(40),      
@Amount  numeric(13,2),  
@Remarks  varchar(100),  
@Refno   varchar(10),  
@ExcFileName    varchar(50),  
@IBBSFileName varchar(15)   
as  
  
begin tran  
  
  begin   
     
   insert into TmpExciseDuty values  
          (@Acc_No,@Acc_Name,@Amount,@Remarks,@Refno,@ExcFileName,@IBBSFileName)  
  
  end  
  
  
commit tran
GO
/****** Object:  StoredProcedure [dbo].[SP_HISTORY]    Script Date: 09/19/2012 13:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HISTORY]    
 @STARTDATE datetime, @ENDDATE   datetime  
as  
  
--TABLE NAME - DCOLLECTED  
INSERT INTO DCOLLECTED_HIST SELECT * FROM DCOLLECTED WHERE DS_CODE IN (SELECT DS_CODE FROM   
DSCHEDULE WHERE  SCHEDULE_DATE  BETWEEN  @STARTDATE AND @ENDDATE)  
   
--TABLE NAME --DSCHEDULE   
  
INSERT INTO DSCHEDULE_HIST SELECT * FROM DSCHEDULE WHERE  SCHEDULE_DATE   
BETWEEN  @STARTDATE AND @ENDDATE  
  
--TABLE NAME --CSD   
INSERT INTO CSD_HIST SELECT  * FROM CSD WHERE D_CODE IN (SELECT D_CODE FROM DSCHEDULE   
WHERE  SCHEDULE_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
  
--TABLE NAME --CCASH  
INSERT INTO CCASH_HIST SELECT * FROM CCASH WHERE  D_CODE IN (SELECT D_CODE FROM DSCHEDULE   
WHERE  SCHEDULE_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
  
--------************************------------------------  
--2nd History Query  
INSERT INTO CCHECK_HIST SELECT * FROM CCHECK WHERE STATUS<>'O'OR   
STATUS<>NULL OR STATUS<>'D'   
AND SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE  
  
INSERT INTO CCHECKTOTAL_HIST SELECT * FROM CCHECKTOTAL WHERE d_CODE IN(SELECT  D_CODE FROM CCHECK   
WHERE STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D'   
AND SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE)   
--------------------------------------------------------  
  
--3rd History Query  
-----------------------------------  
INSERT INTO CSCHEDULE_HIST SELECT  * FROM CSCHEDULE WHERE   
SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE  
  
INSERT INTO TOTALCS_HIST SELECT  * FROM  TOTALCS WHERE    
CS_CODE IN (SELECT  CS_CODE from CSCHEDULE where SCHEDULE_DATE   
BETWEEN @STARTDATE AND @ENDDATE)  
  
INSERT INTO  CRETURN_HIST SELECT * FROM CRETURN WHERE   
CS_CODE IN (SELECT CS_CODE FROM CSCHEDULE WHERE   
SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE)  
----------------------------------------------------------  
--4th Hitory Query  
--TABLE NAME--NORMALCOLLECTION   
INSERT INTO DD_HIST SELECT * FROM DD  WHERE D_CODE+CONVERT(VARCHAR(5),SLNO)  
IN(SELECT NONZONEREF FROM NORMALCOLLECTION B )  
  
INSERT INTO NORMALCOLLECTION_HIST SELECT * FROM NORMALCOLLECTION   
WHERE STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D'   
AND REF_DATE BETWEEN  
@STARTDATE AND @ENDDATE  
  
--TABLE NAME --NORCOLRTN  
INSERT  INTO NORCOLRTN_HIST SELECT * FROM  NORCOLRTN  where nonzoneref in(select nonzoneref from  
normalcollection b WHERE  STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D'  AND REF_DATE BETWEEN @STARTDATE AND @ENDDATE)  
--WHERE REF_DATE BETWEEN '2002-04-30'  AND '2002-04-30')  
  

---sp_helptext SP_MASTERDELETE
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTERDELETE]    Script Date: 09/19/2012 13:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MASTERDELETE]  @STARTDATE DATETIME, @ENDDATE DATETIME  
AS   
--TABLE NAME-DD  
----DELETE  FROM DD WHERE DD_DATE BETWEEN @STARTDATE AND @ENDDATE  
  
DELETE FROM DD WHERE D_CODE+CONVERT(VARCHAR(5),SLNO)  
IN(SELECT NONZONEREF FROM NORMALCOLLECTION B )  
  
--------------------------  
--TABLE NAME --CSD   
DELETE FROM CSD WHERE D_CODE IN (SELECT D_CODE FROM DSCHEDULE  
WHERE  SCHEDULE_DATE  BETWEEN  @STARTDATE AND @ENDDATE)  
  
--TABLE NAME --CCASH  
DELETE FROM CCASH WHERE  D_CODE IN (SELECT D_CODE FROM DSCHEDULE   
WHERE  SCHEDULE_DATE  BETWEEN  @STARTDATE AND @ENDDATE)  
  
--------************************------------------------  
--2nd History Query  
DELETE FROM CCHECKTOTAL WHERE d_CODE IN(SELECT  D_CODE FROM CCHECK   
WHERE    
STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D' AND SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE)   
--------------------------------------------------------  
DELETE FROM CCHECK  WHERE STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D'   
AND SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE  
  
--3rd History Query  
-----------------------------------  
DELETE FROM  TOTALCS WHERE    
CS_CODE IN (SELECT  CS_CODE from CSCHEDULE where SCHEDULE_DATE   
BETWEEN @STARTDATE AND @ENDDATE)  
  
DELETE FROM CRETURN WHERE CS_CODE IN (SELECT  CS_CODE FROM CSCHEDULE WHERE   
SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE)  
----------------------------------------------------------  
DELETE FROM CSCHEDULE WHERE SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE  
--4th Hitory Query  
  
  
--TABLE NAME --NORCOLRTN  
DELETE FROM  NORCOLRTN  WHERE NONZONEREF IN (SELECT  NONZONEREF FROM NORMALCOLLECTION b   
WHERE STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D'    
AND REF_DATE BETWEEN @STARTDATE AND @ENDDATE)  
--WHERE REF_DATE BETWEEN '2002-04-30'  AND '2002-04-30')  
  
--TABLE NAME--NORMALCOLLECTION   
DELETE FROM NORMALCOLLECTION WHERE REF_DATE BETWEEN  
@STARTDATE AND @ENDDATE AND   
STATUS<>'O'OR STATUS<>NULL OR STATUS<>'D'   
  
  
--TABLE NAME - DCOLLECTED  
DELETE FROM DCOLLECTED WHERE DS_CODE IN (SELECT DS_CODE FROM DSCHEDULE   
WHERE SCHEDULE_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
   
--TABLE NAME --DSCHEDULE   
  
DELETE FROM DSCHEDULE WHERE  SCHEDULE_DATE   
BETWEEN  @STARTDATE AND @ENDDATE
GO
/****** Object:  StoredProcedure [dbo].[SP_HISTORY_CALBACK]    Script Date: 09/19/2012 13:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----sp_helptext SP_HISTORY_CALBACK

CREATE PROCEDURE [dbo].[SP_HISTORY_CALBACK]    
  
 @STARTDATE datetime, @ENDDATE   datetime  
as  
  
--TABLE NAME - DCOLLECTED  
INSERT INTO DCOLLECTED SELECT * FROM DCOLLECTED_HIST WHERE DS_CODE IN (SELECT DS_CODE FROM DSCHEDULE_HIST   
WHERE SCHEDULE_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
   
--TABLE NAME --DSCHEDULE   
  
INSERT INTO DSCHEDULE SELECT * FROM DSCHEDULE_HIST WHERE  SCHEDULE_DATE   
BETWEEN  @STARTDATE AND @ENDDATE  
  
--TABLE NAME --CSD   
INSERT INTO CSD SELECT  * FROM CSD_HIST WHERE D_CODE IN (SELECT D_CODE FROM DSCHEDULE_HIST   
WHERE  SCHEDULE_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
  
--TABLE NAME --CCASH  
INSERT INTO CCASH SELECT * FROM CCASH_HIST  
WHERE  D_CODE IN (SELECT D_CODE FROM DSCHEDULE_HIST  
WHERE  SCHEDULE_DATE BETWEEN    
@STARTDATE AND @ENDDATE)  
  
--------************************------------------------  
--2nd History Query  
INSERT INTO CCHECK SELECT * FROM CCHECK_HIST   
WHERE SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE  
  
  
INSERT INTO CCHECKTOTAL SELECT * FROM CCHECKTOTAL_HIST   
WHERE d_CODE IN(SELECT d_CODE FROM CCHECK_HIST   
WHERE SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
--------------------------------------------------------  
  
--3rd History Query  
-----------------------------------  
INSERT INTO CSCHEDULE SELECT  * FROM CSCHEDULE_HIST WHERE SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE  
  
INSERT INTO TOTALCS SELECT  * FROM  TOTALCS_HIST WHERE    
CS_CODE IN (SELECT  CS_CODE from CSCHEDULE_HIST where SCHEDULE_DATE   
BETWEEN @STARTDATE AND @ENDDATE)  
  
INSERT INTO  CRETURN SELECT * FROM CRETURN_HIST WHERE CS_CODE IN (select CS_CODE from CSCHEDULE_HIST where   
SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE)  
----------------------------------------------------------  
--4th Hitory Query  
--TABLE NAME--NORMALCOLLECTION   
INSERT INTO NORMALCOLLECTION SELECT * FROM NORMALCOLLECTION_HIST WHERE REF_DATE BETWEEN  
@STARTDATE AND @ENDDATE  
  
--TABLE NAME --NORCOLRTN  
INSERT  INTO NORCOLRTN SELECT * FROM  NORCOLRTN_HIST  WHERE NONZONEREF IN(SELECT  NONZONEREF FROM NORMALCOLLECTION_HIST    
WHERE REF_DATE BETWEEN @STARTDATE AND @ENDDATE)  
--WHERE REF_DATE BETWEEN '2002-04-30'  AND '2002-04-30')  
----------------------------------------------------------------------
GO
/****** Object:  View [dbo].[cdc_check_Day_Zero]    Script Date: 09/19/2012 13:28:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[cdc_check_Day_Zero] as (    
select  a.client_code,a.location_code,a.corr_bcode,citicash_amount,acc_no,    
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))),
acc_name,c.d_code,customer_ref,slip_date,location_name from dschedule a,    
client b , ccash c,location d where substring(a.client_code,1,4) = b.client_code and    
substring(a.client_code,5,6) = b.sub_client and a.d_code=c.d_code and     
a.location_code=d.location_code   
and  b.citicash=0
and b.citispeed=0    
)
GO
/****** Object:  StoredProcedure [dbo].[revgenerate]    Script Date: 09/19/2012 13:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    procedure [dbo].[revgenerate] as      
  
update ibbsreftab set statusid=1, authorize=1   
where d_code in  
(select a.d_code  
  
from ibbsreftab a , dschedule b    
Where   
A.d_code = B.d_code   
and a.filename is null   
and b.ds_code in (select ds_code from cschedule)   
)  
  
update ibbsreftab set statusid=1, authorize=1   
where d_code in  
(select a.d_code  
  
from ibbsreftab a , dschedule b 
Where   
A.d_code = B.d_code   
and a.filename is null   
---and b.ds_code in (select ds_code from cschedule)   
and a.revdate=b.schedule_Date
--and a.revdate=a.valuedate
)  
  
  
           
delete from tmpreversal              
insert into tmpreversal( crtyp,refno,valuedate,location_code,RevDate,                  
Acc_No,RefAcc_No,client_code,amount,deposit_type,ds_code,CheckDSno,CustomerRef)                  
                  
select c.cashcrtyp,a.refno,a.valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicash_amount) as total,b.deposit_type,'' as d_code ,'' CheckDSno ,''               
from ibbsreftab a ,dschedule b,client c                  
where                   
--a.RevDate <= getdate()               
---left(a.RevDate,12) <= left(getdate(),12)                   
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                 
and a.filename is null                 
and c.cashcrtyp='L'     
  
and ( a.statusid=1 )     
and ( a.authorize =1  )     
  
  
---and (a.statusid is null or a.statusid=1 )     
---and (a.authorize is null or a.authorize =1  )     
group by a.RevDate,a.refno,b.location_code,b.client_code,a.ValueDate,c.cashcrtyp,                  
a.Acc_No,a.RefAcc_No,b.deposit_type                  
                  
union all                  
                  
--\\\\\\by deposit\\\\\\\\\\\\\                  
select c.cashcrtyp,a.refno,valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicash_amount) as total,b.deposit_type,b.d_code ,isnull(b.d_code,'') CheckDSno ,isnull(d.customer_ref,'')customer_ref                 
from ibbsreftab a ,dschedule b left outer join ccash d on d.d_code=b.d_code                   
,client c                 
where               
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                       
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                      
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client       
and a.filename is null                 
--and a.filename ='F7012.000'                  
and c.cashcrtyp='D'                  
and ( a.statusid=1 )     
and ( a.authorize =1  )                     
group by a.RevDate,a.refno,b.client_code,a.ValueDate,b.location_code,c.cashcrtyp,                  
a.Acc_No,a.RefAcc_No ,b.d_code,b.deposit_type,d.customer_ref                   
                  
----group by b.d_code,b.cli000000000000000000000000000      
--\\\\\total\\\\\\\\\\\\\\\                  
union all                  
select c.cashcrtyp,a.refno,valueDate,'000' as location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicash_amount) as total,b.deposit_type,    
substring(CONVERT(varchar(12), valuedate,112),3,8)as d_code, count(b.citicash_amount) CheckDSno,''              
from ibbsreftab a ,dschedule b,client c                  
                  
where                 
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                     
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                   
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and a.filename is null        
--and a.filename ='F7012.000'                
and c.cashcrtyp='T'        
and ( a.statusid=1 )     
and ( a.authorize =1  )                       
group by a.RevDate,a.refno,b.client_code,a.ValueDate,c.cashcrtyp,                 
a.Acc_No,a.RefAcc_No,b.deposit_type                 
---group by b.client_code,a.refno,c.cashcrtyp                  
           
----########################By Ref no ###############               
union all                 
select c.cashcrtyp,a.refno,valueDate,'000' as location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,b.citicash_amount as total,b.deposit_type,left(rtrim(d.cashref ),10) as d_code ,  d.d_code CheckDSno ,d.customer_ref              
from ibbsreftab a ,dschedule b,client c,ccash d                  
                  
where                 
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                     
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                   
and b.citicash_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and a.filename is null                  
and d.d_code=b.d_code        
--and a.filename ='F7012.000'                
and c.cashcrtyp='R'                  
and ( a.statusid=1 )     
and ( a.authorize =1  )               
---group by b.client_code,a.refno,c.cashcrtyp                  
        
                  
insert into tmpreversal( crtyp,refno,valuedate,location_code,RevDate,                  
Acc_No,RefAcc_No,client_code,amount,b.deposit_type,b.ds_code,CheckDSno,CustomerRef)                  
                  
                  
select c.speedcrtyp,a.refno,valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicheck_amount) as total,b.deposit_type,'' as d_code , '' CheckDSno ,'' CustomerRef                
from ibbsreftab a ,dschedule b,client c                  
where                   
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
---left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                    
and b.citicheck_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and a.filename is null                  
--and a.filename ='F7012.000'                  
and c.speedcrtyp='L'                  
and ( a.statusid=1 )     
and ( a.authorize =1  )                               
group by a.RevDate,b.location_code,a.refno,b.client_code,a.ValueDate,c.speedcrtyp,                  
a.Acc_No,a.RefAcc_No,b.deposit_type                  
                  
union all                  
----By Deposit                  
select c.speedcrtyp,a.refno,valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicheck_amount) as total,b.deposit_type,b.d_code , b.d_code CheckDSno,''customer_ref    
from ibbsreftab a ,dschedule b     
,client c                 
where                   
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                     
and b.citicheck_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and c.speedcrtyp='D'                  
and a.filename is null        
and ( a.statusid=1 )     
and ( a.authorize =1  )                      
----and a.filename ='F7012.000'                  
group by a.RevDate,a.refno,b.ds_code,b.client_code,a.ValueDate,c.speedcrtyp,b.location_code,                  
a.Acc_No,a.RefAcc_No,b.d_code,b.deposit_type    
                  
union all                  
                
                
------By Total                  
select c.speedcrtyp,a.refno,valueDate,'000' as location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,sum(b.citicheck_amount) as total,b.deposit_type,substring(CONVERT(varchar(10), valuedate,112),3,8) , '' CheckDSno ,''                
from ibbsreftab a ,dschedule b,client c                  
where                   
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                   
--convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                   
and b.citicheck_amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and a.filename is null                  
--and a.filename ='F7012.000'                  
and c.speedcrtyp='T'     
and ( a.statusid=1 )     
and ( a.authorize =1  )                          
--group by b.client_code,a.refno,c.speedcrtyp                  
group by a.RevDate,b.client_code,a.ValueDate,a.refno,c.speedcrtyp,                  
a.Acc_No,a.RefAcc_No,b.deposit_type                 
                  
                  
union all                  
--\\\\\\\\\\\\\\\By Check\\\\\\\\                  
-----select c.speedcrtyp,a.refno,b.client_code,d.amount                 
                
                
select  c.speedcrtyp,a.refno,valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,D.amount,b.deposit_type,d.check_no , b.d_code CheckDSno  ,d.Customer_Ref                
from ibbsreftab a,client c,dschedule b,csd d                  
where                   
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                    
and d.amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and a.d_code=d.d_code                  
and a.filename is null                 
---and a.filename ='F7012.000'                  
and c.speedcrtyp='C'     
and ( a.statusid=1 )     
and ( a.authorize =1  )                    
                
          
union all        
        
select  c.speedcrtyp,a.refno,valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,                  
b.client_code,D.amount,b.deposit_type,left(d.CheckRef,10)  ,  b.d_code CheckDSno ,d.Customer_Ref      
from ibbsreftab a,client c,dschedule b,csd d                  
where                   
convert(datetime,convert(varchar(12), a.RevDate)) <= convert(datetime,convert(varchar(12), getdate()))                   
--left(a.RevDate,12) <= left(getdate(),12)                   
---convert(varchar(10),a.RevDate,101) <= convert(varchar(10),getdate(),101)                    
and d.amount>0                  
and a.d_code=b.d_code                  
and b.client_code=c.client_code+sub_client                  
and a.d_code=d.d_code                  
and a.filename is null                  
---and a.filename ='F7012.000'                  
and c.speedcrtyp='R'                  
and ( a.statusid=1 )     
and ( a.authorize =1  )        
order by a.refno
GO
/****** Object:  View [dbo].[cdc_check]    Script Date: 09/19/2012 13:28:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------Cdc_check---------------
-------------------------------------

CREATE view [dbo].[cdc_check] as (    
select  a.client_code,a.location_code,a.corr_bcode,citicash_amount,acc_no,    
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))),
acc_name,c.d_code,customer_ref,slip_date,location_name from dschedule a,    
client b , ccash c,location d where substring(a.client_code,1,4) = b.client_code and    
substring(a.client_code,5,6) = b.sub_client and a.d_code=c.d_code and     
a.location_code=d.location_code    
)
GO
/****** Object:  StoredProcedure [dbo].[SpMonbill]    Script Date: 09/19/2012 13:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpMonbill] 
@VStart_date datetime,
@VEnd_date datetime,
@Client_code varchar(6)
as 
delete from tmpmonbill  
insert into tmpmonbill(ds_code,D_code,citicash_amount,citicheck_amount,
Schedule_Date,Client_code,Location_code,No_check,
CashCharge,  
CheckCharge, 
ReturnCharge, 
charge, 		 
Acc_Name,		
Location_Name) 
select distinct a.ds_code,a.d_code,
isnull(a.citicash_amount,0)citicash_amount,              
isnull(a.citicheck_amount,0)citicheck_amount,              
a.schedule_date,a.client_code,a.location_code,                       
a.no_check,c.cashcharge,c.checkcharge,c.returnCharge,
b.charge,  
c.acc_name ,             
---,d.check_no retcheck,  
----d.amount,          
---isnull(d.amount,0)retamt,  
e.location_name   
          
from dschedule a               
----left outer join csdrtn_check d on d.d_code=a.d_code and d.location_code=a.location_code and a.client_code=d.client_code              
left outer join location e on e.location_code=a.location_code              
left outer join locationcharge b on a.location_code=b.location_code  and b.client_code=a.client_code ,         
         
client c          
where               
--a.client_code=b.client_code              
--and          
 a.client_code=c.client_code+c.Sub_client  
-- and schedule_date   between '04/01/2005' and '04/30/2005'
 and a.schedule_date between @VStart_date and @VEnd_date
 and a.client_code=@Client_code
GO
/****** Object:  View [dbo].[collectionmanifold_check]    Script Date: 09/19/2012 13:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[collectionmanifold_check] as (    
select Slno,d_code,check_no,amount,slip_date,Drawer,  
(a.drawee_bankcode+a.location_code+a.branch_code) as struniquebranch_code,   
a.location_code,a.nonzoneref,a.printflag,a.entry_date,    
b.bank_name,c.branch_name,c.branch_add1,c.branch_add2,d.location_name from ccheck a,    
bank b,branch c,location d where a.drawee_bankcode=c.bank_code and   
b.bank_code=c.bank_code and     
a.branch_code=c.branch_code and a.location_code=c.location_code and     
c.location_code=d.location_code and a.rejectref is null and a.zoneref is null     
and a.printflag is null  
   
)
GO
/****** Object:  StoredProcedure [dbo].[SpDepositSlipCheck]    Script Date: 09/19/2012 13:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SpDepositSlipCheck]    
@ScheduleId tinyint,    
@VDateFrom datetime,    
@VDateUpto datetime,
@client_code varchar(6)    

    
    
as    
 Declare    
  
   @Vdscode  numeric,    
   @Vcount numeric ,
   @VResult numeric     
    
 Begin    
    
   delete   tmpDepSlipcheck    
--### Cursor 1     
    

           Declare ValidityCheck Cursor for    
               

			Select DISTINCT REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(a.D_CODE,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0 )d_code from Csd  a left outer join dschedule b on a.d_code =b.d_code
				where b.client_code =@client_code and
              a.slip_date between @VDateFrom and @VDateUpto         
				        
                               
              Open  ValidityCheck      
             Fetch next from ValidityCheck into @Vdscode    
                                       
             while @@fetch_status =0    
              Begin    
                 set @Vdscode =REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@Vdscode,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0)  
                 print  @Vcount     
                 print @Vdscode    
                 if (@Vcount-@Vdscode) <> 0    
                 Begin    
-- 						 set @VResult =((@Vcount-@Vdscode)-1)
--                    set @VResult=cast(@VResult as int)%50
                   if (@Vcount-@Vdscode)<=50
                   begin
	                  insert into tmpDepSlipcheck values(@ScheduleId,@Vcount,@VDateUpto,@client_code)    
	                end                       --print 'Record Break @Vdscode '    
                 End    
                 set @Vcount=@Vdscode+1    
                 --print 'After add'    
                 Fetch next from ValidityCheck into @VDscode     
              End    
           close ValidityCheck  
           deallocate ValidityCheck  
            
    
 --##End First Cursor       

---2nd cursor 
				
           Declare ValidityCheck Cursor for    
               
   
            select DISTINCT REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(D_CODE,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0) d_code from ccheck where     
            value_date between @VDateFrom and @VDateUpto  and client_code=@client_code
            order by d_code asc          
                               
              Open  ValidityCheck      
             Fetch next from ValidityCheck into @Vdscode    
                                       
             while @@fetch_status =0    
              Begin    
               set @Vdscode =REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@Vdscode,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0)  
                 print  @Vcount     
                 print @Vdscode    
                 if (@Vcount-@Vdscode) <> 0    
                 Begin    
-- 	                   set @VResult =((@Vcount-@Vdscode)-1)
-- 	                   set @VResult=cast(@VResult as int)%50
	                   if  (@Vcount-@Vdscode)<=50
	                    Begin
	                     insert into tmpDepSlipcheck values(@ScheduleId,@Vcount,@VDateUpto,@client_code)    
	                    End                       --print 'Record Break @Vdscode '    
                 End    
                 set @Vcount=@Vdscode+1  
					  --print  @VResult
                 --print 'After add'    
                 Fetch next from ValidityCheck into @VDscode     
              End    
           close ValidityCheck  
           deallocate ValidityCheck  
            
    
 --##End First Cursor       
  End
GO
/****** Object:  View [dbo].[ViewallCsdCcheck]    Script Date: 09/19/2012 13:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[ViewallCsdCcheck]  as   
  
select a.d_code,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(a.d_code,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0)  d_code1,check_no,drawer,'CitiSpeed'tblname,draweebank_code,slno,amount,  
slip_date,drawee_branch,rtnstatus,checkRef,''status,b.client_code,c.acc_name,c.acc_no,  
Addresss=rtrim(ltrim((c.Mail_Add1+','+c.Mail_Add2+','+c.mail_add3))),d.location_name  
from csd a ,dschedule b,client c,location d  
where   
a.d_code=b.d_code  
and b.client_code=c.client_code+c.sub_client  
and d.location_code=b.location_code  
  
union all  
select a.d_code,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(a.d_code,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0) d_code1,check_no,drawer,'CitiCheck'tblname,drawee_bankcode,slno,amount,  
slip_date,a.branch_code,status,checkRef,'' status,b.client_code,c.acc_name,c.acc_no,  
Addresss=rtrim(ltrim((c.Mail_Add1+','+c.Mail_Add2+','+c.mail_add3))),d.location_name   
  
from ccheck a ,dschedule b,client c,location d  
where   
a.d_code=b.d_code  
and b.client_code=c.client_code+c.sub_client  
and d.location_code=b.location_code  
union all  
select schedulecode ,schedulecode d_code1,'BREAK','BREAK',''tblname,'BREAK',0,0,scheduledate,'BREAK','BREAK','BREAK','BREAK',client_code,'BREAK','BREAK','BREAK','' status from   
tmpDepSlipcheck
GO
/****** Object:  View [dbo].[ccdd_check]    Script Date: 09/19/2012 13:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View dbo.ccdd_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[ccdd_check] as (  
select a.client_code,a.d_code,customer_ref,check_no,amount,slip_date,value_date,zoneref,nonzoneref,rejectref,  
status,a.dlocation_code,acc_no,acc_name,location_name,a.checkref,  
bank_name,Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))
 from ccheck a,client b , location c,bank d where substring(a.client_code,1,4) = b.client_code and  
substring(a.client_code,5,6) = b.sub_client and a.dlocation_code=c.location_code and  
 a.drawee_bankcode=d.bank_code and (zoneref is not null or nonzoneref is not null or rejectref is not null)  
)
GO
/****** Object:  View [dbo].[ccncolrjctad_check]    Script Date: 09/19/2012 13:28:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View dbo.ccncolrjctad_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[ccncolrjctad_check] as (  
select a.client_code,d_code,check_no,a.checkref,amount,slip_date,dlocation_code,location_name,  
a.rejectref,acc_no,acc_name,reject_code,Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))) from ccheck a,  
client b ,reject c, location d where substring(a.client_code,1,4) = b.client_code and  
substring(a.client_code,5,6) = b.sub_client and a.rejectref=c.rejectref  
and a.dlocation_code = d.location_code  
and a.rejectref is not null and a.status='J'  
)
GO
/****** Object:  View [dbo].[ncolreturn_check]    Script Date: 09/19/2012 13:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View dbo.ncolreturn_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[ncolreturn_check] as (  
select a.client_code,d_code,check_no,amount,slip_date,value_date,a.status,  
slno,a.nonzoneref,acc_no,acc_name,code,status_date,
a.checkref,Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))  
from ccheck a,client b,norcolrtn d,normalcollection e where substring(a.client_code,1,4) = b.client_code and  
substring(a.client_code,5,6) = b.sub_client   
and a.status='R' and a.nonzoneref is not null and printflag='P'   
and zoneref is null and rejectref is null and a.nonzoneref=d.nonzoneref and a.nonzoneref=e.nonzoneref   
)
GO
/****** Object:  View [dbo].[VIEWDD_BREAKUP]    Script Date: 09/19/2012 13:28:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  view [dbo].[VIEWDD_BREAKUP] as   
select a.slno,a.d_code,a.client_code,a.dlocation_code,a.customer_ref,  
a.slip_date,a.value_date,a.check_no,a.amount,a.check_date,a.check_type,  
a.drawer,a.drawee_bankcode,a.location_code,a.branch_code,a.rejectref,a.zoneref,  
a.printflag,a.OutStd_Date,a.entry_date,  
b.* from ccheck  a,  
 (  
select a.nonzoneref,a.ref_date,a.status,a.status_date,b.d_code dd_dcode,a.ddrefno,
a.collectedAmount,a.vat,a.checkRef  
,b.dd_No,b.dd_date,b.drawer_brcode,b.amount dd_amount from normalcollection a,  
dd b where a.ddrefno=(b.d_code+convert(varchar(10),b.slno))  
)b  
where a.nonzoneref=b.nonzoneref
GO
/****** Object:  View [dbo].[ncolfundingddm_check]    Script Date: 09/19/2012 13:28:20 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  View dbo.ncolfundingddm_check    Script Date: 27/04/2002 6:31:46 PM ******/
create view [dbo].[ncolfundingddm_check] as (
select a.client_code,d_code,check_no,amount,slip_date,value_date,status,
dlocation_code,slno,nonzoneref,acc_no,acc_name,location_name,bank_name,
branch_name from ccheck a,client b,location c,bank d,branch e where substring(a.client_code,1,4) = b.client_code and
substring(a.client_code,5,2) = b.sub_client and a.dlocation_code=c.location_code 
and a.drawee_bankcode=d.bank_code and a.branch_code=e.branch_code and 
a.status="P" 
)
GO
/****** Object:  View [dbo].[collectionmanifolduser_check]    Script Date: 09/19/2012 13:28:18 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  View dbo.collectionmanifolduser_check    Script Date: 27/04/2002 6:31:46 PM ******/
create view [dbo].[collectionmanifolduser_check] as (
select Slno,check_no,amount,slip_date,Drawer,(a.drawee_bankcode+a.location_code+a.branch_code) as struniquebranch_code ,a.location_code,nonzoneref,
bank_name,branch_name,branch_add1,branch_add2,location_name from ccheck a,
bank b,branch c,location d where a.drawee_bankcode=c.bank_code and c.bank_code=b.bank_code and 
a.branch_code=c.branch_code and a.location_code=c.location_code and 
c.location_code=d.location_code and a.zoneref is null and  a.rejectref is null and nonzoneref is not null and printflag="P" 
)
GO
/****** Object:  View [dbo].[ncoloutstd_check]    Script Date: 09/19/2012 13:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  view [dbo].[ncoloutstd_check] as (    
select a.client_code,a.d_code,a.check_no,a.drawer,a.amount,a.slip_date,a.zoneref,a.nonzoneref,a.checkref,    
a.rejectref,a.value_date,a.OutStd_Date,acc_no,acc_name,bank_name, branch_name, ref_date ,  
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))),d.branch_add1,d.branch_add2 from ccheck a,    
client b ,bank c,branch d,normalcollection e where substring(a.client_code,1,4) = b.client_code and    
substring(a.client_code,5,6) = b.sub_client and a.drawee_bankcode=d.bank_code     
and a.branch_code=d.branch_code and c.bank_code=d.bank_code and a.status='O'    
and a.nonzoneref is not null and a.printflag ='P' and a.nonzoneref=e.nonzoneref    
and a.zoneref is null and a.rejectref is null and a.location_code=d.location_code    
)
GO
/****** Object:  View [dbo].[conccheckdeposit_check]    Script Date: 09/19/2012 13:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------- conccheckdeposit_check
----------------------------------------

  
/****** Object:  View dbo.conccheckdeposit_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[conccheckdeposit_check] as (  
select a.client_code,d_code,check_no,amount,slip_date,value_date,dlocation_code,  
status,nonzoneref,zoneref,rejectref,acc_no,acc_name,location_name,
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))
from ccheck a,  
client b,location c where substring(a.client_code,1,4) = b.client_code and  
substring(a.client_code,5,6) = b.sub_client and a.dlocation_code=c.location_code   
)


--------------concscc_check---------
GO
/****** Object:  View [dbo].[ccrtn_check]    Script Date: 09/19/2012 13:28:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------CCrtn_check
  
/****** Object:  View dbo.ccrtn_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[ccrtn_check] as (  
select a.client_code,d_code,customer_ref,check_no,amount,slip_date,value_date,  
a.dlocation_code,a.location_code,slno,acc_no,acc_name,c.location_code as dlcode,
c.location_name as dlocation_name, d.return_code,
e.location_code as plcode,e.location_name as plocation_name ,
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))
from ccheck a,  
client b , location c, creturn d,location e where substring(a.client_code,1,4) = b.client_code and  
substring(a.client_code,5,6) = b.sub_client and a.dlocation_code=c.location_code and   
a.location_code=e.location_code and substring(d.returnref,1,7)=a.d_code   
and (substring(d.returnref,8,8)=str(a.slno,1) or substring(d.returnref,8,9)=str(a.slno,2) or substring(d.returnref,8,10)=str(a.slno,3)) and a.status='R'  
)
-------------Csdrtn_check
GO
/****** Object:  View [dbo].[ncolprocessing_check]    Script Date: 09/19/2012 13:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ncolprocessing_check] as (    
select a.client_code,d_code,check_no,amount,slip_date,value_date,status,a.checkref,    
dlocation_code,slno,nonzoneref,zoneref,rejectref,acc_no,acc_name,location_name,  
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))) ,entrydate    
from ccheck a,client b,location c where substring(a.client_code,1,4) = b.client_code and    
substring(a.client_code,5,6) = b.sub_client and a.dlocation_code=c.location_code    
and (a.rejectref is null and a.zoneref is null and nonzoneref is not null) and a.printflag ='P'    
)
GO
/****** Object:  View [dbo].[ncolfunding_check]    Script Date: 09/19/2012 13:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ncolfunding_check] as (            
select a.client_code,a.d_code,a.check_no,a.amount,a.slip_date,a.value_date,a.status,a.checkref,           
a.location_code,slno,a.nonzoneref,acc_no,acc_name,location_name,bank_name,isnull(b.CitiAnyCharge,0.00)CitiAnyCharge,  
branch_name, collectedamount, isnull(vat,0.00)vat,status_date,Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))from ccheck a,client b,location c,bank d,          
branch e, normalcollection f           
where substring(a.client_code,1,4) = b.client_code           
and substring(a.client_code,5,6) = b.sub_client           
and a.location_code=c.location_code             
and a.drawee_bankcode=e.bank_code           
and a.branch_code=e.branch_code           
and d.bank_code=e.bank_code            
and a.nonzoneref = f.nonzoneref            
and a.location_code=e.location_code and zoneref is null and rejectref is null            
and a.status='P' and a.nonzoneref is not null and printflag='P'          
)
GO
/****** Object:  View [dbo].[viewCitiCheck1]    Script Date: 09/19/2012 13:28:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewCitiCheck1] as   
select a.d_code
check_no,
drawer,'CitiCheck'tblname,drawee_bankcode,slno,amount,    
slip_date,a.branch_code,status,checkRef,a.client_code,c.acc_name,c.acc_no,    
Addresss=rtrim(ltrim((c.Mail_Add1+','+c.Mail_Add2+','+c.mail_add3))),d.location_name,e.bank_name draweebankname   

from ccheck a ,client c,location d ,bank e
where     
   
a.client_code=c.client_code+c.sub_client    
and a.dlocation_code=d.location_code    
and a.drawee_bankcode=e.bank_code
GO
/****** Object:  StoredProcedure [dbo].[preminder]    Script Date: 09/19/2012 13:20:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[preminder]
 as declare @start_day tinyint,
        @end_day tinyint,
        @last_date smalldatetime,
        @COUNTER NUMERIC, 
        @reminder numeric
if day(getdate()) > 0 and day(getdate()) < 16
--if day(getdate()) is between 1 and 15
   begin
   set @start_day = 1
   set @end_day = 15
   end
else 
   begin   
   set @start_day = 16
   set @end_day = 31
   end
print @start_day
print @end_day
set @last_date = dateadd(m,-6,getdate())
print @last_date
set @reminder=6
set @COUNTER = 0
WHILE (@COUNTER < 6)
BEGIN
 select Slno,check_no,amount,slip_date,Drawer,dlocation_code,a.nonzoneref,convert(numeric(9),a.nonzoneref)as numnonzoneref ,@reminder as reminder,
bank_name,branch_name,branch_add1,branch_add2,location_name,ref_date,(a.drawee_bankcode+a.location_code+a.branch_code) as struniquebranch_code 
from ccheck a, bank b,branch c,location d,normalcollection e where a.drawee_bankcode=c.bank_code and a.drawee_bankcode=b.bank_code and 
a.branch_code=c.branch_code and a.location_code=c.location_code and 
a.location_code=d.location_code and a.rejectref is null and a.status='O'  and 
a.zoneref is null and a.nonzoneref is not null and a.printflag ='P' and a.nonzoneref=e.nonzoneref 
and day(ref_date) between @start_day and @end_day and month(ref_date) = month(@last_date) and year(ref_date) = year(@last_date)
 print @last_date

set @last_date=dateadd(m,+1,@last_date)
set @COUNTER = @COUNTER +1
set @reminder=@reminder-1
END
GO
/****** Object:  View [dbo].[Reminder_check]    Script Date: 09/19/2012 13:28:21 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  View dbo.Reminder_check    Script Date: 27/04/2002 6:31:46 PM ******/
create view [dbo].[Reminder_check] as (
select Slno,check_no,amount,slip_date,Drawer,dlocation_code,a.nonzoneref,
bank_name,branch_name,branch_add1,branch_add2,location_name,ref_date,(a.drawee_bankcode+a.location_code+a.branch_code) as struniquebranch_code 
from ccheck a, bank b,branch c,location d,normalcollection e where a.drawee_bankcode=c.bank_code and a.drawee_bankcode=b.bank_code and 
a.branch_code=c.branch_code and a.location_code=c.location_code and 
a.location_code=d.location_code and a.rejectref is null and a.status="O" and 
a.zoneref is null and a.nonzoneref is not null and a.printflag ="P" and a.nonzoneref=e.nonzoneref
)
GO
/****** Object:  View [dbo].[checkmanifolduser_check]    Script Date: 09/19/2012 13:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[checkmanifolduser_check] as (    
select a.d_code,Slno,a.check_no,a.amount,a.slip_date,a.client_code,  
a.value_date,a.check_date,a.Drawer,a.zoneref,a.checkref ,   
d.Acc_name,Addresss=rtrim(ltrim((d.Mail_Add1+ d.Mail_Add2+d.mail_add3))),bank_name,c.zone_code,zone_name from ccheck a,bank b,  
zone c, client d where printflag = 'P' and zoneref is not null   
and substring(a.zoneref,1,3) = c.zone_code     
and a.drawee_bankcode=b.bank_code    
and d.client_code+d.sub_client= a.client_code  
)
GO
/****** Object:  View [dbo].[checkmanifold_check]    Script Date: 09/19/2012 13:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------Check Manifold
CREATE view [dbo].[checkmanifold_check] as (    
select a.d_code,a.Slno,a.check_no,a.checkRef,a.amount,a.slip_date,a.value_date,a.check_date,  
a.Drawer,a.zoneref,a.printflag,a.entry_date,    
b.bank_name,c.zone_code,c.zone_name,a.client_code,d.Acc_name,Addresss=rtrim(ltrim((d.Mail_Add1+ d.Mail_Add2+d.mail_add3)))
 from  
ccheck a,bank b,zone c,client d where substring(a.zoneref,1,3) = c.zone_code  
and a.printflag is NULL  
and  (d.Client_code+d.Sub_client)= a.client_code   
and a.drawee_bankcode=b.bank_code   
  
)  
  
----*********checkmanifolduser_check
GO
/****** Object:  View [dbo].[viewschedulebreak]    Script Date: 09/19/2012 13:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[viewschedulebreak] as   
select distinct a.ds_code,a.SCHEDULE_DATE,a.CORR_BCODE,b.bank_name, a.LOCATION_CODE,c.location_name, '' Sch_break,a.citicheck_amount,a.citicash_amount,d.acc_name from dschedule a  
left outer join bank b on b.bank_code=a.Corr_Bcode  
left outer join location c on c.location_code=a.location_code  
left outer join client d on d.client_code+d.Sub_client=a.client_code
union all  
select  schedulecode ,ScheduleDate,'','','','','BREAK',0,0 ,''from  
tmpschedulecheck
GO
/****** Object:  StoredProcedure [dbo].[SpScheduleCheck]    Script Date: 09/19/2012 13:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SpScheduleCheck]            
@ScheduleId tinyint,            
@VDateFrom datetime,            
@VDateUpto datetime            
            
            
as            
 Declare            
 @VschFrom varchar(5),             
 @VschUpto varchar(5) ,            
   @Vdscode  numeric,            
   @Vcount numeric             
            
 Begin            
            
   delete   tmpschedulecheck            
--### Cursor 1        
  IF  @ScheduleId=1      
   Begin          
      Declare StockCheck Cursor for            
      Select sche_from,sche_upto from Schedulestock             
        where scheduleid=@ScheduleId order by  sche_from asc            
               
         open  Stockcheck             
                 Fetch next from stockcheck into @VschFrom,@VschUpto            
                             
            while @@fetch_status=0            
            Begin             
               
                     -- ###2nd CursoR            
              Declare ValidityCheck Cursor for            
                          
               select DISTINCT replace(replace(REPLACE(REPLACE(DS_CODE,'O',0),'H',0),'A',0),'Z',0)ds_code from dschedule where ds_code            
               between @VschFrom and @VschUpto and schedule_date between @VDateFrom and @VDateUpto  order by ds_code asc                  
                                          
                 Open  ValidityCheck              
                Fetch next from ValidityCheck into @Vdscode            
                                                  
                while @@fetch_status =0            
                 Begin            
            set @Vdscode =replace(replace(REPLACE(REPLACE(@Vdscode,'O',0),'H',0),'A',0),'Z',0)          
                    print  @Vcount             
                    print @Vdscode            
                    if (@Vcount-@Vdscode) <> 0            
                    Begin            
                     insert into tmpschedulecheck values(@ScheduleId,@Vcount,@VDateUpto)            
                                            --print 'Record Break @Vdscode '            
                                            End            
                    set @Vcount=@Vdscode+1            
                    --print 'After add'            
                    Fetch next from ValidityCheck into @VDscode             
                 End            
              close ValidityCheck          
              deallocate ValidityCheck          
           --##End Second cursor             
         Fetch next from stockcheck into @VschFrom,@VschUpto              
         End            
                
         close stockcheck          
         deallocate stockcheck          
  end                     
   Else      
      Begin            
          ---- print 'cschedule'      
            Declare StockCheck Cursor for            
       Select sche_from,sche_upto from Schedulestock             
        where scheduleid=@ScheduleId order by  sche_from asc            
         ---print 'inside cursor'      
         open  Stockcheck             
                 Fetch next from stockcheck into @VschFrom,@VschUpto            
                             
            while @@fetch_status=0            
            Begin             
                     --- print 'inside cursor'      
                     -- ###2nd CursoR            
              Declare ValidityCheck Cursor for            
                          
               select DISTINCT replace(replace(REPLACE(REPLACE(CS_code,'O',0),'H',0),'A',0),'Z',0) cs_code from Cschedule where cs_code            
               between @VschFrom and @VschUpto and schedule_date between @VDateFrom and @VDateUpto  order by cs_code asc                  
                                          
                 Open  ValidityCheck              
                Fetch next from ValidityCheck into @Vdscode            
                                                  
                while @@fetch_status =0            
                 Begin           
         ----print 'inside validation'       
            set @Vdscode =@Vdscode      
                    print  @Vcount             
                    print @Vdscode            
                    if (@Vcount-@Vdscode) <> 0            
              Begin            
                     insert into tmpschedulecheck values(@ScheduleId,@Vcount,@VDateUpto)            
                                            --print 'Record Break @Vdscode '            
                                            End            
                    set @Vcount=@Vdscode+1            
                    --print 'After add'            
                    Fetch next from ValidityCheck into @VDscode             
                 End            
              close ValidityCheck          
              deallocate ValidityCheck          
           --##End Second cursor             
         Fetch next from stockcheck into @VschFrom,@VschUpto              
         End            
                
         close stockcheck          
         deallocate stockcheck          
      End      
      
 --##End First Cursor               
      
  End
GO
/****** Object:  View [dbo].[ViewClientDepSum]    Script Date: 09/19/2012 13:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ViewClientDepSum] as   
select  a.ds_code,a.client_code,a.d_code,a.deposit_type,a.citicash_amount,  
a.citicheck_amount,schedule_date,a.No_check,a.location_code,  
a.refno,b.Acc_name,b.acc_no,c.location_name  
from dschedule a , location c,client b  
  
where  
a.client_code=rtrim(b.client_code)+rtrim(b.sub_client)  
and c.location_code=a.location_code
GO
/****** Object:  View [dbo].[Citi_Sched_Dep]    Script Date: 09/19/2012 13:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Citi_Sched_Dep]  as (  
select a.client_code,a.d_code,a.location_code,a.citicheck_amount as amount,a.schedule_date,a.no_check,  
acc_no,acc_name,location_name from dschedule a,  
client b ,location d where substring(a.client_code,1,4) = b.client_code and   
substring(a.client_code,5,6) = b.sub_client and a.location_code=d.location_code

)
GO
/****** Object:  View [dbo].[csd_check]    Script Date: 09/19/2012 13:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------csd_check  
  
CREATE view [dbo].[csd_check] as (      
select a.client_code,a.location_code,a.corr_bcode,acc_no,acc_name,c.d_code,      
customer_ref,check_no,check_date,amount,slip_date,slno,drawer,bank_name,      
location_name,Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))) ,checkref 
from dschedule a,client b , csd c,location d,bank e where       
substring(a.client_code,1,4) = b.client_code and substring(a.client_code,5,6) = b.sub_client       
and a.d_code=c.d_code and a.location_code=d.location_code and c.draweebank_code=e.bank_code      
)
GO
/****** Object:  StoredProcedure [dbo].[SP_DEPOSITUPDT]    Script Date: 09/19/2012 13:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DEPOSITUPDT] as     
Declare     
    
       @LOCATIONCD Char(6),     
       @ClientCd numeric,    
       @DCODE VARCHAR(10),    
       @REFNO varchar(15),    
       @AMOUNT NUMERIC(12,2),    
       @DEPOSITYP VARCHAR(10),    
       @REVDATE  DATETIME    
    
          
---1    
   DECLARE GLTCURSOR CURSOR  for    
    
           
 select b.location_code,b.client_code,a.refno,a.RevDate,    
 sum(b.citicheck_amount) as total,b.deposit_type,b.D_CODE    
 from ibbsreftab a ,dschedule b,client c    
 where     
 b.citicheck_amount>0    
 and a.d_code=b.d_code    
 and b.client_code=c.client_code+sub_client    
         
 and a.filename is null    
 and c.speedcrtyp='L'    
    
 group by a.RevDate,b.location_code,a.refno,b.client_code,    
 a.Acc_No,a.RefAcc_No,b.deposit_type,b.D_CODE    
    
   OPEN GLTCURSOR     
    
   FETCH NEXT FROM GLTCURSOR INTO    
    
         
       @LOCATIONCD , @ClientCd ,@REFNO,@REVDATE, @AMOUNT ,@DEPOSITYP,@DCODE     
    
   WHILE @@FETCH_STATUS=0     
    
    BEGIN     
        update  tmpreversal set ds_code=@DCODE     
        where client_code=@ClientCd and LOCATION_CODE=@LOCATIONCD AND DEPOSIT_TYPE=@DEPOSITYP    
        and revdate=@REVDATE    
        FETCH NEXT FROM GLTCURSOR INTO    
        @LOCATIONCD , @ClientCd ,@REFNO,@REVDATE, @AMOUNT ,@DEPOSITYP,@DCODE    
       
   END    
   CLOSE GLTCURSOR    
    
   DEALLOCATE GLTCURSOR    
    
    
------2    
 DECLARE GLTCURSOR CURSOR  for    
    
           
 select b.location_code,b.client_code,a.refno,a.RevDate,    
 sum(b.citicheck_amount) as total,b.deposit_type,b.D_CODE    
 from ibbsreftab a ,dschedule b,client c    
 where     
 b.citicash_amount>0    
 and a.d_code=b.d_code    
 and b.client_code=c.client_code+sub_client    
 and a.filename is null    
 and c.speedcrtyp='L'    
    
 group by a.RevDate,b.location_code,a.refno,b.client_code,    
 a.Acc_No,a.RefAcc_No,b.deposit_type,b.D_CODE    
    
   OPEN GLTCURSOR     
    
   FETCH NEXT FROM GLTCURSOR INTO    
    
         
       @LOCATIONCD , @ClientCd ,@REFNO,@REVDATE, @AMOUNT ,@DEPOSITYP,@DCODE     
    
   WHILE @@FETCH_STATUS=0     
    
    BEGIN     
        update  tmpreversal set ds_code=@DCODE     
        where client_code=@ClientCd and LOCATION_CODE=@LOCATIONCD AND DEPOSIT_TYPE=@DEPOSITYP    
        and revdate=@REVDATE    
        FETCH NEXT FROM GLTCURSOR INTO    
        @LOCATIONCD , @ClientCd ,@REFNO,@REVDATE, @AMOUNT ,@DEPOSITYP,@DCODE    
       
   END    
   CLOSE GLTCURSOR    
    
   DEALLOCATE GLTCURSOR
GO
/****** Object:  View [dbo].[csdrtn_check]    Script Date: 09/19/2012 13:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View dbo.csdrtn_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[csdrtn_check] as (  
select a.client_code,a.location_code,acc_no,acc_name,c.d_code,customer_ref,  
check_no,check_date,amount,slip_date,slno,location_name,returnref,return_code,c.checkref, 
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))
from dschedule a,client b , csd c,location d,creturn e where substring(a.client_code,1,4) = b.client_code and  
substring(a.client_code,5,6) = b.sub_client and a.d_code=c.d_code and   
a.location_code=d.location_code and substring(e.returnref,1,7)=c.d_code   
and (substring(e.returnref,8,8)=str(c.slno,1) or substring(e.returnref,8,9)=str(c.slno,2) or substring(e.returnref,8,10)=str(c.slno,3)) and c.rtnstatus='R'  
)
GO
/****** Object:  View [dbo].[concscc_check]    Script Date: 09/19/2012 13:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View dbo.concscc_check    Script Date: 27/04/2002 6:31:46 PM ******/  
CREATE view [dbo].[concscc_check] as (  
select a.client_code,a.d_code,a.location_code,a.schedule_date,a.no_check,  
acc_no,acc_name,amount,rtnstatus,location_name,
Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3)))
from dschedule a,  
client b ,csd c,location d where substring(a.client_code,1,4) = b.client_code and   
substring(a.client_code,5,6) = b.sub_client and a.location_code=d.location_code and  
a.d_code=c.d_code   
)

---------ncolfunding_check
GO
/****** Object:  StoredProcedure [dbo].[SP_HOLIDAY]    Script Date: 09/19/2012 13:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_HOLIDAY] as 
Declare 

       @vcnt1 	int,
       @vcnt2 	int,
       @vcnt3 	int,
       @vFdt 	datetime,
       @vDelDt	datetime,
       @vDcode	varchar(8) 



	DECLARE GLTCURSOR CURSOR FOR
	select d_code,valuedate,convert(numeric(2),days) as Days,dateadd(day,convert(numeric(2),days),valuedate) as delivery
        from tmpbooking
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
	                   set @vcnt3=(select count(1) as cnt from holiday where holi_day=@vFdt)
	                     
	                   If @vcnt3>0     
	                     Begin
	                       set @vDelDt=(select dateadd(day,1,@vDelDt))
	                       set @vcnt2=@vcnt2+1     
	                       
	                     End  
	                                     
	
	                    set @vcnt1=@vcnt1+1
		  End

             
                  Update tmpbooking set revdate= @vDelDt where d_code=@VDcode           




	FETCH NEXT FROM GLTCURSOR 
	INTO @VDcode,@vFdt,@vCnt2,@vDelDt
	END
	
	CLOSE GLTCURSOR
	DEALLOCATE GLTCURSOR
GO
/****** Object:  View [dbo].[viewCollectionbreak]    Script Date: 09/19/2012 13:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewCollectionbreak] as       
    
/*        
select distinct a.cs_code,a.SCHEDULE_DATE,a.CORR_BCODE,b.bank_name,       
a.LOCATION_CODE,c.location_name, '' Sch_break,a.citicheck_amount,a.citicash_amount      
      
from cschedule a          
left outer join bank b on b.bank_code=a.Corr_Bcode          
left outer join location c on c.location_code=a.location_code          
---left outer join client d on d.client_code+d.Sub_client=a.client_code        
union all          
select  schedulecode ,ScheduleDate,'','','','','BREAK',0,0 from          
tmpschedulecheck           
*/    
    
select h.ds_code,h.Deposit_Type,h.dciticheck_amount, h.Schedule_Date  ,  
h.dciticash_amount,h.No_check ,h.bank_name,h.location_name 
 ,b.cs_code,b.Schedule_Date as c_shedule_date,b.Location_code,b.Corr_bcode,b.corr_brcode,    
b.ds_code as c_ds_code,b.citicash_amount as c_citicash_amount,   
b.citicheck_amount as c_citicheck_amount,    
b.No_check as c_No_check ,b.no_checksreturned as c_no_checksreturned,    
---b.returned_amount as c_returned_amount,
--- h.d_code ,h.Check_no,h.amount
isnull(f.R_Check_no,0)R_Check_no,isnull(f.R_amount,0)R_amount
from      
cschedule b left outer join 


(select distinct a.ds_code,a.d_code,a.Deposit_Type,a.citicheck_amount dciticheck_amount, a.Schedule_Date as dsheduledate ,  
a.citicash_amount dciticash_amount,a.No_check ,a.corr_brcode,a.SCHEDULE_DATE,a.CORR_BCODE,b.bank_name,       
a.LOCATION_CODE,c.location_name, '' Sch_break,a.citicheck_amount,a.citicash_amount 
----,d.d_code,d.Check_no,d.amount     
      
from dschedule a        
left outer join bank b on b.bank_code=a.Corr_Bcode          
left outer join location c on c.location_code=a.location_code          
----left outer join csd d on a.d_code=d.d_code 
where 
 a.deposit_type='Check'
)h on h.ds_code=b.ds_code 

left outer join (select d_code R_dcode ,count(Check_no) R_Check_no,sum(amount)R_amount from csd 
where rtnstatus='R'
group by d_code ) f  on h.d_code=f.R_dcode
GO
/****** Object:  View [dbo].[viewCS_vs_DS]    Script Date: 09/19/2012 13:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[viewCS_vs_DS] as   
  
select distinct a.ds_code,a.d_code,a.Deposit_Type,a.citicheck_amount dciticheck_amount, a.Schedule_Date as dsheduledate ,      
a.citicash_amount dciticash_amount,a.No_check ,a.corr_brcode,a.SCHEDULE_DATE,a.CORR_BCODE,b.bank_name,           
a.LOCATION_CODE,c.location_name, '' Sch_break,a.citicheck_amount,a.citicash_amount,a.client_code,
d.Acc_Name ,d.citispeed,d.citicash    
----,d.d_code,d.Check_no,d.amount         
          
from dschedule a            
left outer join bank b on b.bank_code=a.Corr_Bcode              
left outer join location c on c.location_code=a.location_code   
left outer join client d on d.Client_Code +d.Sub_Client  = a.client_code    
----left outer join csd d on a.d_code=d.d_code     
  
Where   
a.ds_code not in   
(select ds_code from cschedule)
GO
/****** Object:  View [dbo].[viewunclearfund]    Script Date: 09/19/2012 13:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewunclearfund] as   
select c.cashcrtyp,a.refno,a.valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No,  
 b.client_code,b.citicash_amount+b.citicheck_amount as total,b.deposit_type,a.d_code ,a.statusid,a.remarks ,b.ds_code ,c.Acc_Name,d.StatusName, b.bank_name,b.location_name  
 from ibbsreftab a  left outer join transtatus d on  a.statusid=d.statusid  ,client c  ,  
  
  
(select distinct a.ds_code,a.d_code,a.Deposit_Type,a.citicheck_amount dciticheck_amount, a.Schedule_Date as dsheduledate ,      
a.citicash_amount dciticash_amount,a.No_check ,a.corr_brcode,a.SCHEDULE_DATE,a.CORR_BCODE,b.bank_name,           
a.LOCATION_CODE,c.location_name, '' Sch_break,isnull(a.citicheck_amount,0)citicheck_amount,
isnull(a.citicash_amount,0)citicash_amount,a.client_code     
----,d.d_code,d.Check_no,d.amount         
          
from dschedule a            
left outer join bank b on b.bank_code=a.Corr_Bcode              
left outer join location c on c.location_code=a.location_code              
----left outer join csd d on a.d_code=d.d_code     
   
)b  
  
  
 Where   
 A.d_code = B.d_code   
 and b.client_code=c.client_code+c.sub_client   
and a.filename is null   
and b.ds_code not in   
(select ds_code from cschedule)
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDTREF]    Script Date: 09/19/2012 13:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UPDTREF] as 
Declare 

       @vCcode Char(6), 
       @vrefno varchar(10),
       @vdays varchar(2),
       @vcnt numeric,
       @DCODE VARCHAR(10),
       @VREVDATE DATETIME  , 	
       @REFACCNO varchar(15),
       @deptype 	varchar(15)
      
---1
   DECLARE GLTCURSOR CURSOR  for

        SELECT REFNO,revdate,SunAccNO,deptyp FROM TMPCRBOOKING

   OPEN GLTCURSOR 

   FETCH NEXT FROM GLTCURSOR INTO

     @vrefno,@VREVDATE,@REFACCNO, @deptype

   WHILE @@FETCH_STATUS=0 

    BEGIN 
    	UPDATE TMPBOOKING SET REFNO=@VREFNO, RefAcc_No=@REFACCNO WHERE REVDATE=@VREVDATE
        and deptyp= @deptype
        FETCH NEXT FROM GLTCURSOR INTO
        @VREFNO,@VREVDATE,@REFACCNO,@deptype  
   
   END
   CLOSE GLTCURSOR

   DEALLOCATE GLTCURSOR


---2
DECLARE GLTCURSOR CURSOR  FOR          
       
	       SELECT REFNO,D_CODE FROM TMPBOOKING

OPEN  GLTCURSOR 

FETCH NEXT FROM GLTCURSOR 

INTO @VREFNO,@DCODE
	
WHILE @@FETCH_STATUS=0         
  BEGIN
	    UPDATE DSCHEDULE SET REFNO=@VREFNO WHERE D_CODE=@DCODE				
		FETCH NEXT FROM GLTCURSOR INTO 
  		@VREFNO,@DCODE
 END



CLOSE GLTCURSOR 
DEALLOCATE GLTCURSOR

---3

      insert into IBBSREFTab(refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code)
      select refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code from tmpbooking
GO
/****** Object:  StoredProcedure [dbo].[SPCheckBooking]    Script Date: 09/19/2012 13:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPCheckBooking]
  
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
    --****Update Schedule table Check wise and cash wise  
        
              
    ---1    
       DECLARE GLTCURSOR CURSOR  for    
        
            SELECT REFNO,revdate,SunAccNO,deptyp FROM TMPCRBOOKING    
        
       OPEN GLTCURSOR     
        
       FETCH NEXT FROM GLTCURSOR INTO    
        
         @vrefno,@VREVDATE,@REFACCNO, @deptype    
        
       WHILE @@FETCH_STATUS=0     
        
        BEGIN     
         UPDATE TMPBOOKING SET REFNO=@VREFNO, RefAcc_No=@REFACCNO WHERE REVDATE=@VREVDATE    
            and deptyp= @deptype    
            FETCH NEXT FROM GLTCURSOR INTO    
            @VREFNO,@VREVDATE,@REFACCNO,@deptype      
           
       END    
       CLOSE GLTCURSOR    
        
       DEALLOCATE GLTCURSOR    
        
        
    ---2    
   --- DECLARE GLTCURSOR CURSOR  FOR              
               
      ---      SELECT REFNO,D_CODE FROM TMPBOOKING    
        
    ----OPEN  GLTCURSOR     
        
    ---FETCH NEXT FROM GLTCURSOR     
        
    -----INTO @VREFNO,@DCODE    
         
    ----WHILE @@FETCH_STATUS=0             
      ---BEGIN    
         ---UPDATE DSCHEDULE SET REFNO=@VREFNO WHERE D_CODE=@DCODE        
      ---FETCH NEXT FROM GLTCURSOR INTO     
       --- @VREFNO,@DCODE    
     -----END    
        
        
        
    ---CLOSE GLTCURSOR     
    ----DEALLOCATE GLTCURSOR    
        
    ---3    
          
     --   insert into IBBSREFTab(refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code,revergen)    
      ---    select refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code,@FileNm fname from tmpbooking     
        
     --4 update genprm after generate files.  
    ---Update genprm set batchno=@batno ,refno=@GenPrmRefno  
      
  
    END        
         
  IF @@ERROR<>0 GOTO ErrorHandler          
           
   COMMIT TRAN              
   RETURN 0           
                     
    ErrorHandler:          
  PRINT 'Record Does not Inserted/Updated:'          
  ROLLBACK TRAN          
  RETURN 1          
  
------------------------------
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDTREFERENCE]    Script Date: 09/19/2012 13:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UPDTREFERENCE]      
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
    --****Update Schedule table Check wise and cash wise      
     Update dschedule set filename=@FileNm,seqno=@Seqno,flexgendate=getdate() where refno is null and filename is null and deposit_type='Cash'      
     Update dschedule set filename=@FileNm,seqno=@Seqno,flexgendate=getdate() where refno is null and filename is null and deposit_type='Check' and schedule_date <= @ValueDate      
            
          
                  
    ---1        
       DECLARE GLTCURSOR CURSOR  for        
            
            SELECT REFNO,revdate,SunAccNO,deptyp FROM TMPCRBOOKING        
            
       OPEN GLTCURSOR         
            
       FETCH NEXT FROM GLTCURSOR INTO        
            
         @vrefno,@VREVDATE,@REFACCNO, @deptype        
            
       WHILE @@FETCH_STATUS=0         
            
        BEGIN         
         UPDATE TMPBOOKING SET REFNO=@VREFNO, RefAcc_No=@REFACCNO WHERE REVDATE=@VREVDATE        
            and deptyp= @deptype        
            FETCH NEXT FROM GLTCURSOR INTO        
            @VREFNO,@VREVDATE,@REFACCNO,@deptype          
               
       END        
       CLOSE GLTCURSOR        
            
       DEALLOCATE GLTCURSOR        
            
            
    ---2        
    DECLARE GLTCURSOR CURSOR  FOR                  
                   
            SELECT REFNO,D_CODE FROM TMPBOOKING        
            
    OPEN  GLTCURSOR         
            
    FETCH NEXT FROM GLTCURSOR         
            
    INTO @VREFNO,@DCODE        
             
    WHILE @@FETCH_STATUS=0                 
      BEGIN        
         UPDATE DSCHEDULE SET REFNO=@VREFNO WHERE D_CODE=@DCODE            
      FETCH NEXT FROM GLTCURSOR INTO         
        @VREFNO,@DCODE        
     END        
            
            
            
    CLOSE GLTCURSOR         
    DEALLOCATE GLTCURSOR        
            
    ---3        
              
        insert into IBBSREFTab(refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code,revergen)        
          select refno,amount,valuedate,revdate,acc_no,RefAcc_no,d_code,@FileNm fname from tmpbooking         
            
     --4 update genprm after generate files.      
    Update genprm set batchno=@batno ,refno=@GenPrmRefno      
          
      
    END            
             
  IF @@ERROR<>0 GOTO ErrorHandler              
               
   COMMIT TRAN                  
   RETURN 0               
                         
    ErrorHandler:              
  PRINT 'Record Does not Inserted/Updated:'              
  ROLLBACK TRAN              
  RETURN 1
GO
/****** Object:  View [dbo].[csd_check_Day_Zero]    Script Date: 09/19/2012 13:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[csd_check_Day_Zero] as (        
select a.client_code,a.location_code,a.corr_bcode,acc_no,acc_name,c.d_code,        
customer_ref,check_no,check_date,amount,slip_date,slno,drawer,bank_name,        
location_name,Addresss=rtrim(ltrim((b.Mail_Add1+','+b.Mail_Add2+','+b.mail_add3))) ,checkref   
from dschedule a,client b , csd c,location d,bank e where         
substring(a.client_code,1,4) = b.client_code and substring(a.client_code,5,6) = b.sub_client         
and a.d_code=c.d_code and a.location_code=d.location_code and c.draweebank_code=e.bank_code   
and  b.citicash=0
and b.citispeed=0     
)
GO
/****** Object:  View [dbo].[ViewCitiSpeed1]    Script Date: 09/19/2012 13:28:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[ViewCitiSpeed1]   as
select a.d_code,REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(a.d_code,'O',0),'H',0),'R',0),'',0 ),'/',0 ),'f',0)  d_code1,
check_no,drawer,'CitiSpeed'tblname,draweebank_code,slno,amount,    
slip_date,drawee_branch,rtnstatus,checkRef,''status,b.client_code,c.acc_name,c.acc_no,    
Addresss=rtrim(ltrim((c.Mail_Add1+','+c.Mail_Add2+','+c.mail_add3))),d.location_name ,e.bank_name 
 
from csd a ,dschedule b,client c,location d ,bank e
where     
a.d_code=b.d_code    
and b.client_code=c.client_code+c.sub_client    
and d.location_code=b.location_code    
and a.draweebank_code=e.bank_code
GO
/****** Object:  View [dbo].[dd_check]    Script Date: 09/19/2012 13:28:19 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  View dbo.dd_check    Script Date: 27/04/2002 6:31:46 PM ******/
create view [dbo].[dd_check] as(
select d_code,slno,dd_no,drawer_bankcode,drawee_branch,drawer_brcode,drawer_location,amount,status,entry_date,dd_date from dd   
)
GO
/****** Object:  View [dbo].[ViewReversalAllData]    Script Date: 09/19/2012 13:28:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ViewReversalAllData] as   
select a.Acc_Name,b.* from client a,  
(select a.*,b.Deposit_Type,b.client_code from ibbsreftab a,dschedule b  
where   
a.d_code=b.d_code  
)b  
where   
a.CLIENT_CODE+a.sub_client=b.client_code  
and a.acc_no=b.Acc_no
GO
/****** Object:  View [dbo].[viewschedulebreak1]    Script Date: 09/19/2012 13:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewschedulebreak1]
 as 
select distinct a.ds_code,a.SCHEDULE_DATE,a.CORR_BCODE,b.bank_name, 
a.LOCATION_CODE,c.location_name, '' Sch_break,a.citicheck_amount,
a.citicash_amount,d.acc_name from dschedule a    
left outer join bank b on b.bank_code=a.Corr_Bcode    
left outer join location c on c.location_code=a.location_code    
left outer join client d on d.client_code+d.Sub_client=a.client_code
GO
/****** Object:  View [dbo].[ViewClientZeroDepSum]    Script Date: 09/19/2012 13:28:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ViewClientZeroDepSum] as       
select  a.ds_code,a.client_code,a.d_code,a.deposit_type,a.citicash_amount,      
a.citicheck_amount,schedule_date,a.No_check,a.Entry_Date,a.location_code,b.citicash,b.citispeed  ,    
a.refno,b.Acc_name,b.acc_no,c.location_name      
from dschedule a , location c,client b     
      
where      
a.client_code=rtrim(b.client_code)+rtrim(b.sub_client)      
and c.location_code=a.location_code     
and b.citicash=0  
and b.citispeed=0
GO
/****** Object:  View [dbo].[viewbooking]    Script Date: 09/19/2012 13:28:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewbooking]      
as      
SELECT  dschedule.D_code, dschedule.citicash_amount,    
dschedule.citicheck_amount,isnull(dschedule.citicash_amount,0)+isnull(dschedule.citicheck_amount,0) as totalAmount,    
dschedule.Schedule_Date, dschedule.FileName,    
dschedule.refno, dschedule.seqno,dschedule.Client_code,dschedule.Authorizer_id,dschedule.flexgendate,      
Location.Location_Code, Location.Location_Name,      
client.Acc_Name      
FROM      
    db_citibank.dbo.dschedule dschedule,      
    db_citibank.dbo.Location Location,      
     db_citibank.dbo.Client Client       
WHERE      
    dschedule.Location_code = Location.Location_Code AND      
    dschedule.Client_code=Client.Client_code+client.Sub_client      
  
  
  
-----update  dschedule set flexgendate=getdate()
GO
/****** Object:  StoredProcedure [dbo].[regenCheckingfileFLEX]    Script Date: 09/19/2012 13:20:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[regenCheckingfileFLEX] as 

update dschedule set checked=null where checked=1 and refno is null and filename is null
GO
/****** Object:  StoredProcedure [dbo].[SP_HISTORYDELETE]    Script Date: 09/19/2012 13:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---sp_helptext SP_HISTORYDELETE

CREATE PROCEDURE [dbo].[SP_HISTORYDELETE]  
 @STARTDATE datetime, @ENDDATE   datetime  
as  
--TABLE NAME-DD  
  
DELETE  FROM DD_HIST WHERE DD_DATE BETWEEN @STARTDATE AND @ENDDATE  
--------------------------  
---Now delete data from main table   
  
--TABLE NAME --CSD   
DELETE FROM CSD_HIST WHERE D_CODE IN (SELECT D_CODE FROM DSCHEDULE_HIST  
WHERE  SCHEDULE_DATE  BETWEEN  @STARTDATE AND @ENDDATE)  
  
--TABLE NAME --CCASH  
DELETE FROM CCASH_HIST WHERE  D_CODE IN (SELECT D_CODE FROM DSCHEDULE_HIST   
WHERE  SCHEDULE_DATE  BETWEEN  @STARTDATE AND @ENDDATE)  
  
--------************************------------------------  
--2nd History Query  
DELETE FROM CCHECKTOTAL_HIST WHERE d_CODE IN(SELECT d_CODE FROM CCHECK_HIST   
WHERE SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
--------------------------------------------------------  
DELETE FROM CCHECK_HIST  
WHERE SLIP_DATE BETWEEN  @STARTDATE AND @ENDDATE  
--3rd History Query  
-----------------------------------  
DELETE FROM  TOTALCS_HIST WHERE    
CS_CODE IN (SELECT  CS_CODE from CSCHEDULE_HIST where SCHEDULE_DATE   
BETWEEN @STARTDATE AND @ENDDATE)  
  
DELETE FROM CRETURN_HIST WHERE CS_CODE IN (SELECT  CS_CODE FROM CSCHEDULE_HIST WHERE   
SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE)  
----------------------------------------------------------  
DELETE FROM CSCHEDULE_HIST WHERE SCHEDULE_DATE BETWEEN @STARTDATE AND @ENDDATE  
--4th Hitory Query  
  
  
--TABLE NAME --NORCOLRTN  
DELETE FROM  NORCOLRTN_HIST  WHERE NONZONEREF IN  
(SELECT  NONZONEREF from NORMALCOLLECTION_HIST b   
WHERE REF_DATE BETWEEN @STARTDATE AND @ENDDATE)  
--WHERE REF_DATE BETWEEN '2002-04-30'  AND '2002-04-30')  
  
--TABLE NAME--NORMALCOLLECTION   
DELETE FROM NORMALCOLLECTION_HIST WHERE REF_DATE BETWEEN  
@STARTDATE AND @ENDDATE  
  
--TABLE NAME-DD  
  
DELETE FROM DD_HIST WHERE DD_DATE BETWEEN @STARTDATE AND @ENDDATE  
  
--TABLE NAME - DCOLLECTED  
DELETE FROM DCOLLECTED_HIST WHERE DS_CODE IN (SELECT DS_CODE FROM DSCHEDULE_HIST   
WHERE SCHEDULE_DATE BETWEEN  @STARTDATE AND @ENDDATE)  
   
--TABLE NAME --DSCHEDULE   
  
DELETE FROM DSCHEDULE_HIST WHERE  SCHEDULE_DATE   
BETWEEN  @STARTDATE AND @ENDDATE
GO
/****** Object:  StoredProcedure [dbo].[SP_BOOKING]    Script Date: 09/19/2012 13:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_BOOKING] as         
Declare         
        
       @vCcode Char(6),         
       @vrefno varchar(10),        
       @vdays varchar(2),        
       @vcnt numeric,        
       @DCODE VARCHAR(10)        
--1        
        
DELETE TMPBOOKING        
          
--2        
INSERT INTO tmpbooking (refno,amount,valuedate,revdate,acc_no,DAYS,D_code,deptyp)        
 select D.refno,D.citicash_amount as amt,D.schedule_date,        
 DATEADD(day,convert(int,C.citicash),D.schedule_date )REVDATE,c.acc_no,C.citicash,D.d_code,        
 D.deposit_type        
 From Client  C, dschedule D        
 where D.client_code=(C.client_code+ C.sub_client)        
 and  citicash_amount>0 and refno is null         
Union ALL      
 select D.refno,D.citicheck_amount as amt,D.schedule_date,        
 DATEADD(day,convert(int,C.citispeed),D.schedule_date )REVDATE,c.acc_no,C.citispeed,D.d_code,        
 d.deposit_type    
 From Client C, dschedule D        
 where D.client_code=(C.client_code+ C.sub_client)        
 and  citicheck_amount>0 and refno is null     
 and convert(datetime,convert(varchar(10),D.schedule_date,101))         
         < =convert(datetime,convert(varchar(10),getdate(),101))    
--3        
exec SP_HOLIDAY
GO
/****** Object:  StoredProcedure [dbo].[SP_BOOKINGFORDATACHECK]    Script Date: 09/19/2012 13:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_BOOKINGFORDATACHECK] as             
Declare             
            
       @vCcode Char(6),             
       @vrefno varchar(10),            
       @vdays varchar(2),            
       @vcnt numeric,            
       @DCODE VARCHAR(10)            
--1            
            
DELETE TMPBOOKING            
              
--2            
INSERT INTO tmpbooking (refno,amount,valuedate,revdate,acc_no,DAYS,D_code,deptyp)            
 select D.refno,D.citicash_amount as amt,D.schedule_date,            
 DATEADD(day,convert(int,C.citicash),D.schedule_date )REVDATE,c.acc_no,C.citicash,D.d_code,            
 D.deposit_type            
 From Client  C, dschedule D            
 where D.client_code=(C.client_code+ C.sub_client)            
 and  D.citicash_amount>0 and D.refno is null and D.checked is null             
Union ALL          
 select D.refno,D.citicheck_amount as amt,D.schedule_date,            
 DATEADD(day,convert(int,C.citispeed),D.schedule_date )REVDATE,c.acc_no,C.citispeed,D.d_code,            
 d.deposit_type        
 From Client C, dschedule D            
 where D.client_code=(C.client_code+ C.sub_client)            
 and  D.citicheck_amount>0 and D.refno is null and D.checked is null        
 and convert(datetime,convert(varchar(10),D.schedule_date,101))             
         <= convert(datetime,convert(varchar(10),getdate(),101))        
--3            
exec SP_HOLIDAY
GO
/****** Object:  View [dbo].[viewMonBill]    Script Date: 09/19/2012 13:28:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewMonBill] as    
              
select distinct i.*,x.*,t.*,w.* from             
(select distinct * from tmpmonbill        
 --and a.d_code='4030769'             
)as i left outer join              
    
(select distinct ds.ds_code as ds_code2 , ds.d_code d_code2, ds.client_code client_code2,            
 ds.location_code location_code2,isnull(ds.citicheck_amount,0) nonlocationchargeamountCHECK,
 isnull(ds.citiCASH_amount,0)nonlocationchargeamountCASH     
 from dschedule ds,loc_not_charge lc    
 where     
 ds.location_code=lc.location_code      
 and ds.client_code=lc.client_code and     
 lc.returncheck=0 )as t     
on    
 i.ds_code=t.ds_code2           
and i.d_code=t.d_code2       
and t.client_code2=i.client_code          
and t.location_code2=i.location_code      
left outer join           
    
(            
    
select distinct         
e.ds_code as ds1,e.d_code d_code1  ,            
             
0 nonLoc_cha_Check,            
0 nonLoc_cha_Cash,             
sum(isnull(b.amount,0))nonRet_cha_Check ,            
0 nonRet_cha_Cash ,e.location_code location_code1,e.client_code client_code1 ,Count(isnull(b.amount,0)) noOfretcheck     
--b.slno,    
---Count(b.amount) retsummerycheck    
from loc_not_charge a , csdrtn_check b           
,dschedule e          
          
where e.d_code=b.d_code           
and e.client_code=b.client_code          
and e.location_code=b.location_code          
          
and e.location_code=a.location_Code          
and e.client_code=a.client_code          
and a.location_code=b.location_code            
and a.client_code=b.client_code          
and a.returncheck=1             
---and e.d_code='4138057'          
 group by e.ds_code,e.d_code ,      
    
e.location_code,e.client_code     
         
          
 ) as x on i.ds_code=x.ds1           
and i.d_code=x.d_code1           
----and i.slno1=x.slno      
and x.client_code1=i.client_code           
and x.location_code1=i.location_code       
        
left outer join    
(            
    
select distinct         
e.ds_code as ds4,e.d_code d_code4  ,            
             
----0 nonLoc_cha_Check,            
---0 nonLoc_cha_Cash,             
sum(isnull(b.amount,0))retamt ,            
-----0 nonRet_cha_Cash ,    
e.location_code location_code4,e.client_code client_code4 ,Count(isnull(b.amount,0)) AllnoOfretcheck     
--b.slno,    
---Count(b.amount) retsummerycheck    
from  csdrtn_check b           
,dschedule e          
          
where e.d_code=b.d_code           
and e.client_code=b.client_code          
and e.location_code=b.location_code          
and e.client_code=b.client_code          
---and e.d_code='4138057'          
 group by e.ds_code,e.d_code ,      
    
e.location_code,e.client_code     
         
          
 ) as w on w.ds4=i.ds_code           
and w.d_code4=i.d_code           
----and i.slno1=x.slno      
and w.client_code4=i.client_code           
and w.location_code4=i.location_code
GO
