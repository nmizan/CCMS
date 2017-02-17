VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmCRC 
   BackColor       =   &H8000000B&
   Caption         =   "IBBS Booking File Generation"
   ClientHeight    =   3480
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7245
   Icon            =   "FrmCRC.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   3480
   ScaleWidth      =   7245
   StartUpPosition =   2  'CenterScreen
   Begin VB.OptionButton OptFlexCube 
      BackColor       =   &H8000000B&
      Caption         =   "FlexCube Format"
      Height          =   255
      Left            =   2160
      TabIndex        =   13
      Top             =   360
      Value           =   -1  'True
      Width           =   1935
   End
   Begin VB.OptionButton OptIBBS 
      BackColor       =   &H8000000B&
      Caption         =   "IBBS File Format"
      Height          =   255
      Left            =   1680
      MaskColor       =   &H00C0E0FF&
      TabIndex        =   12
      Top             =   360
      Visible         =   0   'False
      Width           =   1815
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H8000000B&
      Height          =   855
      Left            =   120
      TabIndex        =   7
      Top             =   2280
      Width           =   7035
      Begin VB.CommandButton CmdPrint 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Print "
         Height          =   465
         Left            =   1320
         Style           =   1  'Graphical
         TabIndex        =   10
         Top             =   120
         Width           =   1095
      End
      Begin VB.CommandButton Command3 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Close"
         Height          =   465
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   9
         Top             =   120
         Width           =   1035
      End
      Begin VB.CommandButton CmdSearch 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Search"
         Height          =   465
         Left            =   2490
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   120
         Width           =   1095
      End
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H8000000B&
      Height          =   915
      Left            =   120
      TabIndex        =   4
      Top             =   600
      Width           =   7035
      Begin MSComCtl2.DTPicker DTPicker1 
         Height          =   315
         Left            =   1890
         TabIndex        =   5
         Top             =   360
         Width           =   1425
         _ExtentX        =   2514
         _ExtentY        =   556
         _Version        =   393216
         Format          =   77201409
         CurrentDate     =   37702
      End
      Begin VB.Label Label1 
         BackColor       =   &H8000000B&
         Caption         =   "Booking Date"
         Height          =   225
         Left            =   360
         TabIndex        =   6
         Top             =   360
         Width           =   1395
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H8000000B&
      Height          =   915
      Left            =   120
      TabIndex        =   2
      Top             =   1440
      Width           =   7035
      Begin VB.CommandButton CmdCheckBookData 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Check Data For Booking File"
         Height          =   465
         Left            =   720
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   240
         Width           =   2355
      End
      Begin VB.CommandButton Command2 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Generate  Booking File"
         Height          =   465
         Left            =   3600
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   240
         Width           =   2115
      End
   End
   Begin Crystal.CrystalReport CrystalReport1 
      Left            =   1440
      Top             =   0
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      PrintFileLinesPerPage=   60
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   135
      Left            =   1380
      TabIndex        =   0
      Top             =   2670
      Width           =   1245
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   390
      Top             =   780
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin MSComCtl2.Animation Animation1 
      Height          =   465
      Left            =   360
      TabIndex        =   1
      Top             =   0
      Width           =   825
      _ExtentX        =   1455
      _ExtentY        =   820
      _Version        =   393216
      BackColor       =   -2147483648
      FullWidth       =   55
      FullHeight      =   31
   End
End
Attribute VB_Name = "FrmCRC"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'**********************************************
'Form name              :FrmCRC
'Form Description       :IBBS Booking File Generation
'Creation date          :starting date 21/12/2004
'Design & Developed by  :Dewan Ahsanullah
'Modification history   :26/10/2011
'Modification details   :System will accept day 0 checks & cash
'***************************************************************
'***************************************************************
' Process Booking:
'**********************************************
'1)  Every thousand file generation the filename will be initialized and stats from '"7000"
'2)  All the clients must maintain their Cash credit day ,Check credit day, Cash Credit type ,Speed Credit type
'3)  Get max Seq no from dschedule .
'4)  Get Batch no for filename
'5)  Generate refno starts from "0000000001"
'6)  Prepare Credit  Data
'7)  Prepare Booking Data
'8)  Separate citicheck amount which value date will be less than todate
'9)  And Citicash amount of today.
'10) And check holiday and make revarsal date of each record .
'11) Next step is to select data for tmpbooking and group all data according "cash" and "check" wise.
'12) Update refno for each record.
'13)  9 and 10 is for credit datatype
'14) Now  select all data which are check  and prepare data for debit
'15) Prepare debit data for cash it like preparing check
'16) After prepare all data generate booking file
'17) Execute SP_UPDTREFERENCE to Update reference no and dschedule data.
'**********************************************
 'CRC using Xor Gate
 '**********************************************
 ''The result of Xor gate is
 '**********************************************
'If two expression1  And expression2 Then result is
'True  | True =False
'True  | False= True
'False | True =True
'False | False =False
'**********************************************
Option Explicit
'Decalre all Variables

Dim Refno As Currency
Dim A As Integer
Dim hexstrpos As Boolean
Dim strpos As String
Dim myhex As String
Dim yy As String
Dim c As String
Dim B As String
Dim crcval As String
Dim batno       As String       'for batchno
Dim FileNm      As String       'for file
Dim seqno As String
'Dim strconnect As String

Private Sub CmdCheckBookData_Click()
''#######Start Booking data preparation and insert booking data to tmpbooking table
''#######but no booking file is generated only report getting data from tmpbooking table
  If Authorized = False Then
  Command2.Enabled = True
     Exit Sub
  Else
     CheckbookingFile
     Command2.Enabled = True
  End If
End Sub

Private Sub CmdPrint_Click()
IBBSRptPrint
End Sub

Private Sub CmdSearch_Click()
Load FrmIBBSSearch
FrmIBBSSearch.Show
End Sub

Private Sub Command2_Click()

 '####Check for authorization
    ' Authorized
    Dim RecordName As String
    If Authorized = False Then
       Exit Sub
    End If
    RecordName = ""
    Set rs = ocon.GetResultset("select * from dschedule where userid='" & s_user & "'  and filename is null and refno is null ")
    If Not (rs.BOF And rs.EOF) Then
            RecordName = "DepositSchedule " + Space(2) + rs!ds_code + Space(2) + "Deposit Code " + rs!d_code
            MsgBox "Record exist which  " & RecordName & " given by an Authorizer,Another authorizer is needed to run booking", vbOKOnly, "CCMS"
        Exit Sub
     End If
    
    Set rs = ocon.GetResultset("select * from dschedule where filename is null and refno is null and Checked=0")
    If rs.RecordCount > 1 Then
          MsgBox "More than one record found Please Run checking file", vbOKOnly, "CCMS"
        Exit Sub
    End If
    
    If Not (rs.BOF And rs.EOF) Then
     If rs.RecordCount = 1 Then
         RecordName = "DepositSchedule " + rs!ds_code + Space(2) + "Deposit Code " + Space(2) + rs!d_code
         MsgBox "Record  " & RecordName & "  Not checked for booking you need to run PrepareBooking file", vbOKOnly, "CCMS"
        Exit Sub
    End If
    End If
    
    Set rs = ocon.GetResultset("select * from dschedule where filename is null and refno is null and Checked is null")
    If rs.RecordCount > 1 Then
          MsgBox "More than one record found Please Run checking file", vbOKOnly, "CCMS"
        Exit Sub
    End If
 ''#############################
          ''#####Start avi
                   PlayAvi
          ''#####Data Prepare for booking
                   PrepareBookingData
          ''#####Debit Data Preparation
                   If debit = "False" Then ''Procedure call
                   StopAvi
                   MsgBox "File generation is cancelled ", vbOKOnly, "CCMS"
                   StopAvi
                   Exit Sub
                   End If
          ''#####After all data has been prepared for booking then generate file
            '**********************checking if any account is blank
'                    Set rs = Nothing
'                    Set rs = ocon.GetResultset("select sum(cast(sunaccno as numeric(14))) as cracctot,sum( amount) " & _
'                    "as credtotal from tmpcrbooking  ")
'                    If IsNull(rs!cracctot) = True Then
'                      MsgBox "Account no is not defined for the bank ", vbOKOnly, "CCMS"
'                      StopAvi
'                      Exit Sub
'                    End If
            '*******************************************************************
     
                  
                   If OptFlexCube.Value = True Then
                    FLEXFileGen
                   Else
                    FileGen 'File generation Procedure Call
                   End If
          ''######Make ZipFile Password Protected
                   'MakeZipPasswdfile
          ''######After Generate file  all master file will be updated by calling Stored Procedure
                  ' Set rs = Nothing
                   'Set rs = ocon.GetResultset("update dschedule set filename='" & FileNm & "',seqno='" & seqno & "' where refno is null and filename is null and deposit_type='Cash' ")
                   'Set rs = Nothing
                   'Set rs = ocon.GetResultset("update dschedule set filename='" & FileNm & "' ,seqno='" & seqno & "' where refno is null and filename is null and deposit_type='Check' and schedule_date <'" & Format(DTPicker1, "mm/dd/yyyy") & "'")
        '           Set rs = Nothing
         '           Set rs = ocon.GetResultset("execute Spclientupd '" & Format(DTPicker1, "yyyy/mm/dd") & "'")
                        Set rs = Nothing
                   Set rs = ocon.GetResultset("Execute SP_UPDTREFERENCE @FileNm='" & FileNm & "',@Seqno='" & seqno & "' ,@ValueDate='" & Format(DTPicker1, "mm/dd/yyyy") & "',@GenPrmRefno='" & Format(Refno, "0000000000") & "',@batno='" & batno & "'")
                   Set rs = Nothing
                   Set rs = ocon.GetResultset("update dschedule set Authorizer_id='" & s_user & "' where filename ='" & FileNm & "'")
                 
                           
                   StopAvi
                   MsgBox "New File   " & FileNm & "   is created for FlexCube", vbOKOnly, "CCMS"
                   'Set rs = Nothing
                   'Set rs = ocon.GetResultset("Update genprm set batchno='" & batno & "',refno='" & Format(refno, "0000000000") & "'")
                   Exit Sub
     
    
    StopAvi
    MsgBox "Record Not found", vbOKOnly, "CCMS"
   
 
End Sub
''\\\\\\\\\Booking for Debit
Private Function debit() As String
'Dim refno As Currency
'refno = 0
            Set rs = Nothing
            'Set rs = ocon.GetResultset(" select b.ds_code,a.citispeed,b.Location_code,sum(b.citicash_amount) as total from client a,dschedule b where " & _
            '"a.client_code+a.sub_client = B.client_code " & _
            '"and b.citicash_amount is not null " & _
            '"and b.schedule_date='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
            '"group by b.location_code,b.ds_code,a.citispeed ")
            
            Set rs = ocon.GetResultset("select b.ds_code,b.schedule_date,b.corr_bcode ,b.Location_code,  " & _
            " sum(b.citicash_amount) as total,c.location_name,d.accno,d.bank_name " & _
            " from client a,dschedule b ,location c ,bank d where " & _
            " (a.client_code + a.sub_client) = B.client_code " & _
            " and b.citicash_amount is not null and (b.citicash_amount <>.00) " & _
            " and b.refno is null " & _
            " and c.location_code=b.location_code  " & _
            " and b.corr_bcode=d.bank_code " & _
            " group by b.location_code,b.schedule_date,b.ds_code,c.location_name, " & _
            " b.corr_bcode,d.accno,d.bank_name,b.corr_bcode")
            
            Set rs1 = Nothing
            Set rs1 = ocon.GetResultset("select * from tmpdrbooking")
             Do Until rs.EOF
              'If Not (rs1.BOF And rs1.EOF) Then
                rs1.AddNew
                    rs1!credtype = "0"
                    rs1!sunaccno = rs!accno
                    rs1!Amount = rs!Total
                    rs1!Refno = rs!ds_code
                    rs1!Valuedate = rs!Schedule_date
                    rs1!deptyp = "Cash"
                    rs1!days = "" 'rs!citispeed
                    rs1!Remarks = rs!location_name
                    
                rs1.Update
               
               'End If
                rs.MoveNext
               'refno = refno + 1
            Loop
            
            
            '-----Query for check
            ''---Changed in query **b.schedule_date <'" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _

            Set rs = Nothing
            Set rs = ocon.GetResultset("select b.ds_code,b.schedule_date,a.citispeed,b.corr_bcode ,b.Location_code, " & _
            " sum(b.citicheck_amount) as total,c.location_name,d.accno,d.bank_name " & _
            " from client a,dschedule b ,location c ,BANK D where " & _
            "(a.client_code + a.sub_client) = B.client_code " & _
            " and (b.citicheck_amount is not null) and (b.citicheck_amount <>.00)" & _
            " and b.refno is null " & _
            " and b.schedule_date <='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
            " and c.location_code=b.location_code " & _
            " and b.corr_bcode=d.bank_code " & _
            " group by b.location_code,b.schedule_date,b.ds_code,a.citispeed,c.location_name, " & _
            " b.corr_bcode,d.accno,d.bank_name,b.corr_bcode")
            
            ''#####If bank account no is blank
            If Not (rs.BOF And rs.EOF) Then
               If rs!accno = "" Then
                 MsgBox "Bank Account Field is blank Please update Bank table and generate booking file again", vbOKOnly
                 debit = "False"
                 Exit Function
               End If
            End If
            
                        
            Set rs1 = Nothing
            Set rs1 = ocon.GetResultset("select * from tmpdrbooking")
             Do Until rs.EOF
              'If Not (rs1.BOF And rs1.EOF) Then
                rs1.AddNew
                    rs1!credtype = "0"
                    rs1!sunaccno = rs!accno
                    rs1!Amount = rs!Total
                    rs1!Refno = rs!ds_code
                    rs1!deptyp = "Check"
                    rs1!Valuedate = rs!Schedule_date
                    rs1!days = "" 'rs!citispeed
                    rs1!Remarks = rs!location_name
                rs1.Update
               
               'End If
                rs.MoveNext
              ' refno = refno + 1
            Loop
            debit = "True"
End Function
'Private Sub FLEXFileGen()
'  ''*****Variables
'  Dim sFileHeader As String
'  Dim sFileTrailer As String
'  Dim iSeqNo As Integer
'  Dim sSeqno As String
'  Dim ClsexpFile As New clsExportFile
'
'''Generate file header
'    '                         length
'    '____________Name_____________________
'    'file header indicator      3
'    '            Date           8
'    '            File Name      30
'    '            serial No      3
'
'    '*************Prepare File header
'
'    ''Record count =Total record including which includes header and trailor record
'    sFileHeader = "HDR" + Format(Date, "YYYYMMDD") + "IEG01INF.DAT" + Space(18) + "001"
'
'
'
'    sFileTrailer = "TRL" + Format(Date, "YYYYMMDD") + "0000000001"
'
'
'
'    '******************************Record Append
'
'            Dim exptext     As String       'for text file context
'            Dim brcode      As String       'for branch
'            Dim Valuedate   As String       'for date format yyyymmdd
'            Dim serial      As Currency     'to count serial
'            Dim crctext     As String       'text file content with CRC value
'            Dim convert     As String       '
'            Dim TotDebtAmt  As String       'Total Debit    Amount
'            Dim TotCrAmt    As String       'Total Credit   Amount
'            Dim TotDebtAcc  As String       'Total Debit    Account
'            Dim TotCrACC    As String       'Total Credit   Account
'
'            ''\\\\\\\\\\\\\\\
'            brcode = "G01"         'Branch Code
'            FileNm = "IE" + brcode + "INF" + ".DAT"
'            serial = 0
'
'            Valuedate = Mid(Format(Date, "dd/mm/yyyy"), 7, 10) _
'            + Mid(Format(Date, "dd/mm/yyyy"), 4, 2) + _
'            Mid(Format(Date, "dd/mm/yyyy"), 1, 2)
'            fso.CreateTextFile App.path & "\IBBSFile\" & FileNm & ""
'
'            '\\\\file generation Procedure
'            ''Header record
'
'             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine sFileHeader
'            ''Trandsaction Record
'
'             Set rs = Nothing
'             Set rs = ocon.GetResultset("select * from tmpcrbooking")
'             If Not (rs.BOF And rs.EOF) Then
'             Do Until rs.EOF
'
'               sSeqno = Format("000000", iSeqNo)
'               exptext = brcode + "INF" + Space(12) + "000001" + "0056" + "056" + "BDT" + _
'               Format(Date, "YYYYMMDD") + ClsexpFile.CheckSpace((rs!Amount), 22) + _
'               ClsexpFile.CheckSpace(CStr(rs!sunaccno), 20) _
'               + ClsexpFile.CheckSpace(brcode, 3) + "001" _
'               + "C" + ClsexpFile.CheckSpace((rs!Amount), 22) + _
'               Space(14) + Format(Date, "YYYYMMDD") + _
'               Space(16) + Space(9) + Space(255) + Space(27) + "ProductMI" + Space(126) + Space(20) _
'               + Space(16) + Space(16) + "YYYY"
'
'               iSeqNo = iSeqNo + 1
'             rs.MoveNext
'             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine exptext
'
'
'             Loop
'
'             End If
'
'            ''debit data append
'
'             Set rs = Nothing
'             Set rs = ocon.GetResultset("select  credtype,sunaccno,sum(amount)as amount,valuedate,deptyp,refno,remarks from tmpdrbooking " & _
'             "group by credtype,sunaccno,valuedate,deptyp,refno,remarks")
'             If Not (rs.BOF And rs.EOF) Then
'             Do Until rs.EOF
'
'               sSeqno = Format("000000", iSeqNo)
'               exptext = brcode + "INF" + Space(12) + "000001" + "0056" + "056" + "BDT" + _
'               Format(Date, "YYYYMMDD") + ClsexpFile.CheckSpace((rs!Amount), 22) + _
'               ClsexpFile.CheckSpace(CStr(rs!sunaccno), 20) _
'               + ClsexpFile.CheckSpace(brcode, 3) + "001" _
'               + "D" + ClsexpFile.CheckSpace((rs!Amount), 22) + _
'               Space(14) + Format(Date, "YYYYMMDD") + _
'               Space(16) + Space(9) + Space(255) + Space(27) + "ProductMI" + Space(126) + Space(18) + Space(45) + Space(20) _
'               + Space(16) + Space(16) + "YYYY"
'
'             rs.MoveNext
'             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine exptext
'
'             iSeqNo = iSeqNo + 1
'
'             Loop
'
'             End If
'            ''Trailor record
'              fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine sFileTrailer
'
'
'
'End Sub
Private Sub FileGen()
            Dim exptext     As String       'for text file context
            Dim brcode      As String       'for branch
            Dim Valuedate   As String       'for date format yyyymmdd
            Dim serial      As Currency     'to count serial
            Dim crctext     As String       'text file content with CRC value
            Dim convert     As String       '
            Dim TotDebtAmt  As String       'Total Debit    Amount
            Dim TotCrAmt    As String       'Total Credit   Amount
            Dim TotDebtAcc  As String       'Total Debit    Account
            Dim TotCrACC    As String       'Total Credit   Account
            
            ''\\\\\\\\\\\\\\\
            brcode = "000"
            FileNm = "F" + batno + ".000"
            serial = 0
            
            Valuedate = Mid(Format(Date, "dd/mm/yyyy"), 7, 10) _
            + Mid(Format(Date, "dd/mm/yyyy"), 4, 2) + _
            Mid(Format(Date, "dd/mm/yyyy"), 1, 2)
            ''\\\To get total CreditAmount
            Set rs = Nothing
            Set rs = ocon.GetResultset("select sum(cast(sunaccno as numeric(14))) as cracctot,sum( amount) " & _
            "as credtotal from tmpcrbooking  ")
            
            If Not (rs.BOF And rs.EOF) Then
              TotCrAmt = rs!credtotal
              TotCrACC = rs!cracctot
            End If
            Set rs = Nothing
            Set rs = ocon.GetResultset(" select sum(cast(sunaccno as numeric(14))) as debacctot,sum( amount)" & _
            "as debtotal from tmpdrbooking")
            fso.CreateTextFile App.path & "\IBBSFile\" & FileNm & ""
            If Not (rs.BOF And rs.EOF) Then
              TotDebtAmt = rs!debtotal
              TotDebtAcc = rs!debacctot
            End If
            
            '\\\\file generation Procedure
            ''Header record
                crctext = "1" + "^" + Valuedate + "^" + Left(FileNm, 5) + "^" + brcode + "^" + batno + "^"
             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine crctext
            ''Trandsaction Record
            
             Set rs = Nothing
             Set rs = ocon.GetResultset("select * from tmpcrbooking")
             If Not (rs.BOF And rs.EOF) Then
             Do Until rs.EOF
               
               exptext = "2" + "^" + "000" + "^" + CStr(serial) + "^" + CStr(rs!sunaccno) + "^" + "000" + "^" + _
               "^" + "^" + CStr(rs!Amount) + "^" + CStr(Valuedate) + "^" + IIf(Trim(rs!deptyp) = "Cash", "908", "907") + "^" + CStr(rs!Refno) + "^" + "^" + "^" + CStr(rs!credtype) + _
               "^" + CStr(Trim(rs!Remarks))
               crctext = exptext
               convert = crc(exptext)
               crctext = crctext + "^" + exptext + "^"
              
             rs.MoveNext
             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine crctext
            
             serial = serial + 1
             Loop
             
             End If
             
            ''debit data append
                    
             Set rs = Nothing
             Set rs = ocon.GetResultset("select  credtype,sunaccno,sum(amount)as amount,valuedate,deptyp,refno,remarks from tmpdrbooking " & _
             "group by credtype,sunaccno,valuedate,deptyp,refno,remarks")
             If Not (rs.BOF And rs.EOF) Then
             Do Until rs.EOF
               
               exptext = "2" + "^" + "000" + "^" + CStr(serial) + "^" + CStr(rs!sunaccno) + "^" + "000" + "^" + _
               "^" + "^" + CStr(rs!Amount) + "^" + CStr(Valuedate) + "^" + IIf(Trim(rs!deptyp) = "Cash", "908", "907") + "^" + CStr(rs!Refno) + "^" + "^" + "^" + CStr(rs!credtype) + _
               "^" + (CStr(Left(Trim(rs!Remarks), 18)) + Space(1) + CStr(Format(rs!Valuedate, "dd/MM")))
               crctext = exptext
               convert = crc(exptext)
               crctext = crctext + "^" + exptext + "^"
              
             rs.MoveNext
             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine crctext
            
             serial = serial + 1
            
             Loop
             
             End If
            ''Trailor record
             crctext = "3" + "^" + brcode + "^" + CStr(serial) + "^" + batno + _
             "^" + TotDebtAmt + "^" + TotCrAmt + "^" + TotDebtAcc + "^" + TotCrACC + "^"
             fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine crctext

End Sub

Function crc(textval As String)
            Dim i As Integer
            Dim j As Integer
            Dim fixhex As String
            'yy = "2000091983000010001345558.73200301120001CQ: -0"
            'yy = "2^000^0^9198300001^000^^^1345558.73^20030112^000^^^^1^CQ: -0"
            'yy = "200019260050009000253.002003011200037275102210CQ:902-100195"
            'yy = "2^000^1^9260050009^000^^^253.00^20030112^000^3727510221^^^0^CQ:902-100195"
            'yy = "2^000^2^9260050009^000^^^3524.00^20030112^000^3700414065^^^0^CQ:902-102278"
            'yy = "Hello"
            crcval = Hex2Dec("0001")
            'a = Asc(" ")
            
            B = 0
            'myCheck = B Xor B
            For i = 1 To Len(textval)
               strpos = Mid(textval, i, 1)
               crcval = Format(Dec2Bin(crcval Xor Asc(strpos)), "0000000000000000")
            
             For j = 1 To 8
              
             ''\\\\shift one value to the right
                   
                B = Right(crcval, 1)
                crcval = Format(Left(crcval, 15), "0000000000000000")
                
              '\\Check if the value of b is 1 if it is true than
              '\\CrcVal will be added to Hex value "A001"
             If B = 1 Then
                 crcval = Dec2Bin(Hex2Dec(Bin2Hex(crcval)) Xor Hex2Dec(Hex(Hex2Dec("A001"))))
              End If
             Next j
                crcval = Hex2Dec(Bin2Hex(crcval))
             Next i
               crcval = Hex(crcval)
               'MsgBox "The hex value = " & crcval
            textval = crcval


End Function
Private Sub Command3_Click()
Unload Me
End Sub
Private Sub PlayAvi()
    Animation1.Visible = True
    Animation1.Enabled = True
    Animation1.Open App.path & "\Dependency files\Filecopy.avi"
    Animation1.Play
End Sub
Private Sub StopAvi()
    Animation1.Stop
    Animation1.Visible = False
    Animation1.Enabled = False
    Animation1.Close
End Sub

Private Sub IBBSRptPrint()
    Dim A  As String
    Dim seqno As String
    
    Set rs = Nothing
    Set rs = ocon.GetResultset("select max(seqno)as seqno from dschedule")
    seqno = rs!seqno
    
    'FileNm = "F7018.000"
    A = InputBox("Please Enter File  Name ", "CCMS", vbInformation, vbOK)
    CrystalReport1.Formulas(0) = "Maker ='" & Trim(oLoginUser.UserId) & "'"
    CrystalReport1.SelectionFormula = "{viewbooking.filename} = '" & A & "' and {viewbooking.seqno} = " & seqno & " and {viewbooking.flexgendate} in date (" & Mid(DTPicker1.Value, 7, 4) _
                 & "," & Mid(DTPicker1.Value, 4, 2) & "," & Mid(DTPicker1.Value, 1, 2) & ")"
    
    CrystalReport1.WindowTitle = "IBBS Booking Report"
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\RptBooking.rpt"
    CrystalReport1.Action = 1
End Sub

Private Sub Form_Load()
DTPicker1.Value = Date
'StrConnect = ocon.ConnectStr("dewan", "sa", "", "db_citibank")
CrystalReport1.Connect = strconnect
End Sub

Private Sub MakeZipPasswdfile()
    Dim rsgenprmmst As New ADODB.Recordset
  '/To Zip the acknowlegment file
        Dim expzcounter, expdotpos As Integer
        Dim expzip, expsourcefile, expzipfile, expzpsswd, exps1 As String
        Dim expsh As String
        Dim crctext As String
        Dim exptext
        Set rs = Nothing
        Set rs = ocon.GetResultset("select * from genprm ")
        ''************For Test Purpose
       ' FileNm = "Test"
'        fso.CreateTextFile App.path & "\IBBSFile\" & FileNm & ""
'        exptext = "2" + "^" + "000"
'        crctext = exptext + "^"
'
'
       ' fso.OpenTextFile(App.path & "\IBBSFile\" & FileNm, ForAppending).WriteLine crctext
'
        expzpsswd = rs!zip_passwd     'zip password
        
        expzip = App.path & "\pkzip.exe"    'pkzip
        
        expsourcefile = App.path & "\IBBSFile\" & FileNm   'DAT file location
        
        expdotpos = InStr(1, FileNm, ".")
        
'        If expdotpos = 9 Then
'            FileNm = Left(FileNm, 8) & ".Zip"
'        Else
'            FileNm = Left(FileNm, (expdotpos - 1)) & ".Y2Z"
'        End If
        
        expzipfile = App.path & "\IBBSFile\" & FileNm      'file keep here after ZIP
        
        exps1 = "-s"
        
        expsh = Shell(expzip & " " & exps1 & expzpsswd & " " & expzipfile & " " & expsourcefile)
        MsgBox "Exported File " & FileNm, vbInformation, "CRMS"
        '/systemlog comments
        'oconn.UpdateSystemLog "Exported File " & FileNm
        '/
     '   fso.DeleteFile expsourcefile, True        'delete file from app.apth
  '/
End Sub
Private Sub PrepareBookingData()
    
        Set rs = Nothing
        Set rs = ocon.GetResultset("select * from client where citicash is null or citispeed is null")
        If Not (rs.BOF And rs.EOF) Then
            MsgBox "client credit type is not defined ,Please update credit type of clients", vbOKOnly, "CCMS"
            Exit Sub
        End If
        ''#################
         'To select batch and reference number
         '#######################
          
         Set rs = Nothing
         Set rs = ocon.GetResultset("select isnull(max(seqno),0)seqno from dschedule")
         If Not (rs.BOF And rs.EOF) Then
           'If rs!BatchNo = "8000" Then
            'seqno = rs!seqno + 1
          ' Else
            seqno = rs!seqno
          ' End If
         End If
''*******************************************
'''---For flex cube
''***************************************************************
''Check batchno because daily 12 batch can be used
'ex from -5601-5612
''***************************************************************
                Set rs = Nothing
                Set rs = ocon.GetResultset("select batchno,refno,datediff(d,getdate(),batchdate) daterange from genprm")
                If Not (rs.BOF And rs.EOF) Then
                  If rs!daterange = 0 Then
                     batno = rs!BatchNo + 1
                  Else
                       batno = "5601"
                  End If
                End If
''*******************************************
         Set rs = Nothing
         Set rs = ocon.GetResultset("select * from genprm")
            If Not (rs.BOF And rs.EOF) Then
'                 If rs!BatchNo = "8000" Then
'                     batno = "7001"
'                     seqno = seqno + 1
'                Else
'                    batno = rs!BatchNo + 1
'                End If
                Refno = Format(rs!Refno + 1, "0000000000")
        
            End If
 
        'Dim refno As Currency
            Set rs = Nothing
            Set rs = ocon.GetResultset("delete from tmpCRbooking")
            Set rs = Nothing
            Set rs = ocon.GetResultset("delete from tmpDRbooking")
            'refno = "0000001000"
         
            Set rs = Nothing
        '    Set rs = ocon.GetResultset("select a.Citicash,sum(b.citicash_amount) as total from " & _
        '    "client a,dschedule b where " & _
        '    "a.client_code + a.sub_client = B.client_code " & _
        '  '  "and b.schedule_date='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
        '    '"and b.citicash_amount is not null  group by a.Citicash ")
        '   Set rs = ocon.GetResultset("select Citicash,sum(b.citicash_amount) as total from " & _
        '    "tmpbooking where " & _
        '    "and deptyp='Cash'  group by a.Citicash ")
          Set rs = Nothing
          Set rs = ocon.GetResultset("execute SP_BOOKING")
          Set rs = ocon.GetResultset("select * from tmpbooking")
          If rs.RecordCount > 0 Then
                  Set rs = ocon.GetResultset("select revdate,sum(amount) as total,deptyp from " & _
                            "tmpbooking Where " & _
                            "deptyp='CASH' group by revdate,deptyp order by revdate")
                            
                    If rs.RecordCount > 0 Then
                        Do Until rs.EOF
                          '\\\For booking Credit(cash)
                          Set rs1 = Nothing
                          Set rs1 = ocon.GetResultset("select * from tmpcrbooking")
                             'If Not (rs1.BOF And rs1.EOF) Then
                               rs1.AddNew
                                 rs1!credtype = "1"
                                 'If OptFlexCube.Value = True Then
                                    rs1!sunaccno = "G010009275600005"
                                    rs1!Sundryrefaccno = "G010009275600005"
                                 'Else
                                 '   rs1!sunaccno = "9275600005" 'rs!SunAccNo
                                ' End If
                                 rs1!Amount = rs!Total
                               '  rs1!refno = Format(refno, "0000000000")
                                 rs1!Valuedate = Format(Date, "yyyy/mm/dd") & ""
                                 rs1!revdate = Format(rs!revdate, "yyyy/mm/dd") & ""
                                 rs1!days = "" 'Trim(rs!days)
                                 rs1!deptyp = rs!deptyp
                                 rs1!Remarks = "Cash"
                               rs1.Update
                            
                            'End If
                             rs.MoveNext
                             'refno = Format(refno, "0000000000") + 1
                            ' ocon.Execute ("update updateref set refno='" & refno & "'where refno='' ")
                         Loop
                      End If
                      Set rs1 = Nothing
                      Set rs1 = ocon.GetResultset("select refno,revdate,days from tmpcrbooking where refno is null and deptyp='CASH' group by revdate,refno,days order by revdate asc")
                         If rs1.RecordCount > 0 Then
                            Do Until rs1.EOF
                               rs1!Refno = Format(Refno, "0000000000")
                               rs1.Update
                               rs1.MoveNext
                              Refno = Format(Refno, "0000000000") + 1
                            Loop
                            
                         End If
                        '\\\For booking Credit(check)
                        
                        
                '        Set rs = ocon.GetResultset("select a.Citispeed,sum(b.citicheck_amount) as total from client a,dschedule b where " & _
                '        "a.client_code+ a.sub_client = B.client_code " & _
                '        "and b.citicheck_amount is not null " & _
                '        "and b.schedule_date='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
                '        "group by a.citispeed order by a.citispeed")
                        Set rs = Nothing
                        Set rs = ocon.GetResultset("select deptyp,revdate,sum(amount) as total from " & _
                        "tmpbooking Where " & _
                        "deptyp='CHECK'  group by revdate,deptyp order by revdate ")
                       If rs.RecordCount > 0 Then
                             Set rs1 = Nothing
                             Set rs1 = ocon.GetResultset("select * from tmpcrbooking")
                             Do Until rs.EOF
                              'If Not (rs1.BOF And rs1.EOF) Then
                                rs1.AddNew
                                    rs1!credtype = "1"
                                    If OptFlexCube.Value = True Then
                                       rs1!sunaccno = "G010009275570009" 'rs!SunAccNo
                                       rs1!Sundryrefaccno = "G010009275570009"  'rs!SunAccNo = "G010009275570009" 'rs!SunAccNo
                                    Else
                                       rs1!sunaccno = "9275570009" 'rs!SunAccNo
                                    End If
                                    rs1!Amount = rs!Total
                                   ' rs1!refno = Format(refno, "0000000000")
                                    rs1!Valuedate = Format(Date, "yyyy/mm/dd") & ""
                                    rs1!revdate = Format(rs!revdate, "yyyy/mm/dd") & ""
                                    rs1!days = "" 'Trim(rs!days)
                                    rs1!deptyp = rs!deptyp
                                    rs1!Remarks = "Speed"
                                rs1.Update
                               
                            
                                rs.MoveNext
                               'refno = refno + 1
                             Loop
                        End If
                        
                         Set rs1 = Nothing
                         Set rs1 = ocon.GetResultset("select refno,revdate,days from tmpcrbooking where refno is null and deptyp='CHECK' group by revdate,refno,days order by revdate asc")
                         If rs1.RecordCount > 0 Then
                                Do Until rs1.EOF
                                   rs1!Refno = Format(Refno, "0000000000")
                                   rs1.Update
                                   rs1.MoveNext
                                  Refno = Format(Refno, "0000000000") + 1
                                Loop
                            
                         End If
            End If
                
End Sub
''For checking booking data before generate any booking file
Private Sub CheckbookingFile()
 ''#####Start avi
               
                  
                   PlayAvi
          ''#####Data Prepare for booking
                   'PrepareBookingData
                   PrepareDataForChecking
          ''#####Debit Data Preparation
                   'debit   ''Procedure call
                   CheckDataFordebit
          ''#####After all data has been prepared for booking then generate file
                   
          ''######Make ZipFile Password Protected
                   
          ''######After Generate file  all master file will be updated by calling Stored Procedure
                  ' Set rs = Nothing
                   'Set rs = ocon.GetResultset("update dschedule set filename='" & FileNm & "',seqno='" & seqno & "' where refno is null and filename is null and deposit_type='Cash' ")
                   'Set rs = Nothing
                   'Set rs = ocon.GetResultset("update dschedule set filename='" & FileNm & "' ,seqno='" & seqno & "' where refno is null and filename is null and deposit_type='Check' and schedule_date <'" & Format(DTPicker1, "mm/dd/yyyy") & "'")
        '           Set rs = Nothing
        '           Set rs = ocon.GetResultset("execute Spclientupd '" & Format(DTPicker1, "yyyy/mm/dd") & "'")
        
                   Set rs = Nothing
                   Set rs = ocon.GetResultset("Execute SPCheckBooking")
                 
                   Set rs = Nothing
                   Set rs = ocon.GetResultset("update dschedule set checked=1 where filename is null and refno is null and checked is null or checked=0 ")
                           
                   StopAvi
                   '###Call Report
                   IBBSRptCheckingPrint
                   'MsgBox "New File   " & FileNm & "   is created for IBBS", vbOKOnly, "CCMS"
                   'Set rs = Nothing
                   'Set rs = ocon.GetResultset("Update genprm set batchno='" & batno & "',refno='" & Format(refno, "0000000000") & "'")
                 '  Exit Function
     
    
    StopAvi
   
   
End Sub
Private Sub IBBSRptCheckingPrint()
    Dim A  As String
    Dim seqno As String
    
    Set rs = Nothing
    Set rs = ocon.GetResultset("select max(seqno)as seqno from dschedule")
    seqno = rs!seqno
           ''\\\\\\\\\\\\\\\
            'brcode = "000"
            FileNm = "F" + batno + ".000"
           ' serial = 0
    'FileNm = "F7018.000"
   ' A = InputBox("Please Enter File  Name ", "CCMS", vbInformation, vbOK)
    CrystalReport1.Formulas(0) = "FileNm ='" & FileNm & "'"
    'CrystalReport1.Formulas(1) = "Authorizer ='" & s_user & "'"
    CrystalReport1.Formulas(1) = "Maker ='" & Trim(oLoginUser.UserId) & "'"
    
    CrystalReport1.WindowTitle = "IBBS Report checking "
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\RptCheckBooking.rpt"
    CrystalReport1.Action = 1
End Sub
Public Function Authorized() As Boolean
    On Error GoTo ErrorCode
    
    Authorized = False
    sup_user = False
    
    frmsuplogin.Show 1
    
    If sup_user = True Then
        Authorized = True
    Else
        Authorized = False
    End If
    
Exit Function
ErrorCode:
    Authorized = False
    Exit Function
    
End Function
Private Sub PrepareDataForChecking()
    rs = Nothing
        Set rs = ocon.GetResultset("select * from client where citicash is null or citispeed is null")
        If Not (rs.BOF And rs.EOF) Then
            MsgBox "client credit type is not defined ,Please update credit type of clients", vbOKOnly, "CCMS"
            Exit Sub
        End If
        ''#################
         'To select batch and reference number
         '#######################
          
         Set rs = Nothing
         Set rs = ocon.GetResultset("select isnull(max(seqno),0)seqno from dschedule")
         If Not (rs.BOF And rs.EOF) Then
           'If rs!BatchNo = "8000" Then
            'seqno = rs!seqno + 1
          ' Else
            seqno = rs!seqno
          ' End If
         End If
 
    rs = Nothing
    rs = ocon.GetResultset("select batchno,refno,datediff(d,getdate(),batchdate) daterange from genprm")
    If Not (rs.BOF And rs.EOF) Then
        If rs!daterange = 0 Then
            batno = rs!BatchNo + 1
        Else
            batno = "5601"
        End If
    End If
 
         Set rs = Nothing
         Set rs = ocon.GetResultset("select * from genprm")
            If Not (rs.BOF And rs.EOF) Then
                 'If rs!BatchNo = "5601" Then
                   '  batno = "7001"
                   '  seqno = seqno + 1
               ' Else
                 '   batno = rs!BatchNo + 1
                'End If
                Refno = Format(rs!Refno + 1, "0000000000")
        
            End If
 
        'Dim refno As Currency
            Set rs = Nothing
            Set rs = ocon.GetResultset("delete from tmpCRbooking")
            Set rs = Nothing
            Set rs = ocon.GetResultset("delete from tmpDRbooking")
            'refno = "0000001000"
         
            Set rs = Nothing
        '    Set rs = ocon.GetResultset("select a.Citicash,sum(b.citicash_amount) as total from " & _
        '    "client a,dschedule b where " & _
        '    "a.client_code + a.sub_client = B.client_code " & _
        '  '  "and b.schedule_date='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
        '    '"and b.citicash_amount is not null  group by a.Citicash ")
        '   Set rs = ocon.GetResultset("select Citicash,sum(b.citicash_amount) as total from " & _
        '    "tmpbooking where " & _
        '    "and deptyp='Cash'  group by a.Citicash ")
          Set rs = Nothing
          Set rs = ocon.GetResultset("execute SP_BOOKINGFORDATACHECK")
          Set rs = ocon.GetResultset("select * from tmpbooking")
          If rs.RecordCount > 0 Then
                  Set rs = ocon.GetResultset("select revdate,sum(amount) as total,deptyp from " & _
                            "tmpbooking Where " & _
                            "deptyp='CASH' group by revdate,deptyp order by revdate")
                            
                    If rs.RecordCount > 0 Then
                        Do Until rs.EOF
                          '\\\For booking Credit(cash)
                          Set rs1 = Nothing
                          Set rs1 = ocon.GetResultset("select * from tmpcrbooking")
                             'If Not (rs1.BOF And rs1.EOF) Then
                               rs1.AddNew
                                 rs1!credtype = "1"
                                 rs1!sunaccno = "G010009275600005" 'rs!SunAccNo"
                                 rs1!Amount = rs!Total
                               '  rs1!refno = Format(refno, "0000000000")
                                 rs1!Valuedate = Format(Date, "yyyy/mm/dd") & ""
                                 rs1!revdate = Format(rs!revdate, "yyyy/mm/dd") & ""
                                 rs1!days = "" 'Trim(rs!days)
                                 rs1!deptyp = rs!deptyp
                                 rs1!Remarks = "Cash"
                               rs1.Update
                            
                            'End If
                             rs.MoveNext
                             'refno = Format(refno, "0000000000") + 1
                            ' ocon.Execute ("update updateref set refno='" & refno & "'where refno='' ")
                         Loop
                      End If
                      Set rs1 = Nothing
                      Set rs1 = ocon.GetResultset("select refno,revdate,days from tmpcrbooking where refno is null and deptyp='CASH' group by revdate,refno,days order by revdate asc")
                         If rs1.RecordCount > 0 Then
                            Do Until rs1.EOF
                               rs1!Refno = Format(Refno, "0000000000")
                               rs1.Update
                               rs1.MoveNext
                              Refno = Format(Refno, "0000000000") + 1
                            Loop
                            
                         End If
                        '\\\For booking Credit(check)
                        
                        
                '        Set rs = ocon.GetResultset("select a.Citispeed,sum(b.citicheck_amount) as total from client a,dschedule b where " & _
                '        "a.client_code+ a.sub_client = B.client_code " & _
                '        "and b.citicheck_amount is not null " & _
                '        "and b.schedule_date='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
                '        "group by a.citispeed order by a.citispeed")
                        Set rs = Nothing
                        Set rs = ocon.GetResultset("select deptyp,revdate,sum(amount) as total from " & _
                        "tmpbooking Where " & _
                        "deptyp='CHECK'  group by revdate,deptyp order by revdate ")
                       If rs.RecordCount > 0 Then
                             Set rs1 = Nothing
                             Set rs1 = ocon.GetResultset("select * from tmpcrbooking")
                             Do Until rs.EOF
                              'If Not (rs1.BOF And rs1.EOF) Then
                                rs1.AddNew
                                    rs1!credtype = "1"
                                    rs1!sunaccno = "G010009275570009" 'rs!SunAccNo"
                                    rs1!Amount = rs!Total
                                   ' rs1!refno = Format(refno, "0000000000")
                                    rs1!Valuedate = Format(Date, "yyyy/mm/dd") & ""
                                    rs1!revdate = Format(rs!revdate, "yyyy/mm/dd") & ""
                                    rs1!days = "" 'Trim(rs!days)
                                    rs1!deptyp = rs!deptyp
                                    rs1!Remarks = "Speed"
                                rs1.Update
                               
                            
                                rs.MoveNext
                               'refno = refno + 1
                             Loop
                        End If
                        
                         Set rs1 = Nothing
                         Set rs1 = ocon.GetResultset("select refno,revdate,days from tmpcrbooking where refno is null and deptyp='CHECK' group by revdate,refno,days order by revdate asc")
                         If rs1.RecordCount > 0 Then
                                Do Until rs1.EOF
                                   rs1!Refno = Format(Refno, "0000000000")
                                   rs1.Update
                                   rs1.MoveNext
                                  Refno = Format(Refno, "0000000000") + 1
                                Loop
                            
                         End If
            End If
      
End Sub
Private Function CheckDataFordebit() As String
'Dim refno As Currency
'refno = 0
            Set rs = Nothing
            'Set rs = ocon.GetResultset(" select b.ds_code,a.citispeed,b.Location_code,sum(b.citicash_amount) as total from client a,dschedule b where " & _
            '"a.client_code+a.sub_client = B.client_code " & _
            '"and b.citicash_amount is not null " & _
            '"and b.schedule_date='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
            '"group by b.location_code,b.ds_code,a.citispeed ")
            
            Set rs = ocon.GetResultset("select b.ds_code,b.schedule_date,b.corr_bcode ,b.Location_code,  " & _
            " sum(b.citicash_amount) as total,c.location_name,d.accno,d.bank_name " & _
            " from client a,dschedule b ,location c ,bank d where " & _
            " (a.client_code + a.sub_client) = B.client_code " & _
            " and b.citicash_amount is not null " & _
            " and b.refno is null and b.checked is null" & _
            " and c.location_code=b.location_code  " & _
            " and b.corr_bcode=d.bank_code " & _
            " group by b.location_code,b.schedule_date,b.ds_code,c.location_name, " & _
            " b.corr_bcode,d.accno,d.bank_name,b.corr_bcode")
            
            Set rs1 = Nothing
            Set rs1 = ocon.GetResultset("select * from tmpdrbooking")
             Do Until rs.EOF
              'If Not (rs1.BOF And rs1.EOF) Then
                rs1.AddNew
                    rs1!credtype = "0"
                    rs1!sunaccno = rs!accno
                    rs1!Amount = rs!Total
                    rs1!Refno = rs!ds_code
                    rs1!Valuedate = rs!Schedule_date
                    rs1!deptyp = "Cash"
                    rs1!days = "" 'rs!citispeed
                    rs1!Remarks = rs!location_name
                    
                rs1.Update
               
               'End If
                rs.MoveNext
               'refno = refno + 1
            Loop
            
            
            '-----Query for check
            '---Changes for day 0 credit 26/10/2011
            '---and b.schedule_date <'" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _

            Set rs = Nothing
            Set rs = ocon.GetResultset("select b.ds_code,b.schedule_date,a.citispeed,b.corr_bcode ,b.Location_code, " & _
            " sum(b.citicheck_amount) as total,c.location_name,d.accno,d.bank_name " & _
            " from client a,dschedule b ,location c ,BANK D where " & _
            "(a.client_code + a.sub_client) = B.client_code " & _
            " and b.citicheck_amount is not null and b.checked is null " & _
            " and b.refno is null " & _
            " and b.schedule_date <='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
            " and c.location_code=b.location_code " & _
            " and b.corr_bcode=d.bank_code " & _
            " group by b.location_code,b.schedule_date,b.ds_code,a.citispeed,c.location_name, " & _
            " b.corr_bcode,d.accno,d.bank_name,b.corr_bcode")
            
            ''#####If bank account no is blank
            If Not (rs.BOF And rs.EOF) Then
               If rs!accno = "" Then
                 MsgBox "Bank Account Field is blank Please update Bank table and generate booking file again", vbOKOnly
                 CheckDataFordebit = "False"
                 Exit Function
               End If
            End If
            
                        
            Set rs1 = Nothing
            Set rs1 = ocon.GetResultset("select * from tmpdrbooking")
             Do Until rs.EOF
              'If Not (rs1.BOF And rs1.EOF) Then
                rs1.AddNew
                    rs1!credtype = "0"
                    rs1!sunaccno = rs!accno
                    rs1!Amount = rs!Total
                    rs1!Refno = rs!ds_code
                    rs1!deptyp = "Check"
                    rs1!Valuedate = rs!Schedule_date
                    rs1!days = "" 'rs!citispeed
                    rs1!Remarks = rs!location_name
                rs1.Update
               
               'End If
                rs.MoveNext
              ' refno = refno + 1
            Loop
            CheckDataFordebit = "True"
End Function
Private Sub FLEXFileGen()
Dim exptext     As String       'for text file context
Dim brcode      As String       'for branch
Dim Valuedate   As String       'for date format yyyymmdd
Dim serial      As Currency     'to count serial
Dim crctext     As String       'text file content with CRC value
Dim convert     As String       '
Dim TotDebtAmt  As String       'Total Debit    Amount
Dim TotCrAmt    As String       'Total Credit   Amount
Dim TotDebtAcc  As String       'Total Debit    Account
Dim TotCrACC    As String       'Total Credit   Account
Dim TranCode As String          'Transaction code
Dim AccountNo As String         'AccountNo
Dim Remarks As String
Dim sourcecode As String
Dim j As String
Dim ExlWB As New Excel.Workbook
Dim ExlWS As New Excel.Worksheet
Dim i As Integer
    'prgProcess.Value = 0
    'prgProcess.Min = 0
''***************************************************************
''Check batchno because daily 12 batch can be used
'ex from -5601-5612
''***************************************************************
Set rs = Nothing
Set rs = ocon.GetResultset("select batchno,refno,datediff(d,getdate(),batchdate) daterange from genprm")
If Not (rs.BOF And rs.EOF) Then
  If rs!daterange = 0 Then
     batno = rs!BatchNo + 1
  Else
       batno = "5601"
  End If
End If

  ' batno = "5601"
    brcode = "G01"
    sourcecode = brcode + batno
    FileNm = "F" + brcode + batno
    
    serial = 0
    'Assign values
   ' TranCode = Trim(TxtTrCode.Text)
    'AccountNo = Trim(TxtBAccount.Text)
    'Remarks = TxtRemrks.Text

    Valuedate = Format(Date, "dd- MMMM - yy")
    ''\\\To get total CreditAmount
    Set rs = Nothing
    Set rs = ocon.GetResultset("select sum( amount) " & _
    "as credtotal from tmpcrbooking ")
        If Not (rs.BOF And rs.EOF) Then
          TotCrAmt = IIf(IsNull(Trim(rs!credtotal)) = True, 0, Trim(rs!credtotal))
          'TotCrACC = rs!cracctot
        End If
'        Set rs = Nothing
'        Set rs = ocon.GetResultset("select sum(cast(Acc_No as numeric(14))) as cracctot,sum( amount) " & _
'        "as debtotal from TmpExciseDuty ")
'        If fso.FolderExists(App.path & "\ExciseDuty\") = False Then
'            fso.CreateFolder (App.path & "\ExciseDuty\")
'        End If
'
        
       ' FileName = Trim(txtFileName.Text)
        'FileName = "FLEXORG"
        Set ExlWB = GetObject(Trim(App.path & "\FLEXORG.csv"))
               
        Set ExlWS = ExlWB.Worksheets(1)
        ''To visible worksheet
       ' ExlWS.Visible = True
        'ExlWB.Application.Visible = True
        
'        If Not (rs.BOF And rs.EOF) Then
'          TotDebtAmt = rs!debtotal
'          TotDebtAcc = AccountNo
'        End If
    'Starts from third row
    i = 3
    j = 1
    Set rs = Nothing
    Set rs = ocon.GetResultset("select * from tmpcrbooking")
     If Not (rs.BOF And rs.EOF) Then
      Do Until rs.EOF
             
         '\\\\file generation Procedure
  
            'j = Format(j + "000000")
                       
            'ExlWS.Cells(I, 1) = "" 'DETB_UPLOAD_DETAIL
          
            ExlWS.Cells(i, 1) = batno 'BATCH_NO
            ExlWS.Cells(i, 2) = "G01" 'BRANCH_CODE
            ExlWS.Cells(i, 3) = "056" 'DEPARTMENT_CODE
            ExlWS.Cells(i, 4) = sourcecode 'FileNm 'SOURCE_CODE
            ExlWS.Cells(i, 5) = Format(j, "000000")  'CURR_NO
            ExlWS.Cells(i, 6) = "BDT" 'CCY_CD
            ExlWS.Cells(i, 7) = Valuedate '"" 'INITIATION_DATE
            ExlWS.Cells(i, 8) = CStr(Format(Trim(rs!Amount), "##,##,##,##,###.####"))  'CStr(Format(Trim(rs!Amount), "###########.####")) 'Trim(rs!Amount) 'CStr(TotCrAmt)
            ExlWS.Cells(i, 9) = CStr(rs!sunaccno) '"G010009155160001" '"Acc_Name '""
            ExlWS.Cells(i, 10) = Left(Trim(rs!sunaccno), 3) 'ACCOUNT_BRANCH
            If Trim(rs!deptyp) = "Cash" Then
            ExlWS.Cells(i, 11) = "355"  'TXN_CODE
            Else
            ExlWS.Cells(i, 11) = "063" 'TXN_CODE
            End If
            ExlWS.Cells(i, 12) = "C" 'DR_CR
            ExlWS.Cells(i, 13) = CStr(Format(Trim(rs!Amount), "##,##,##,##,###.####")) 'Trim(rs!Amount) 'LCY_EQUIVALENT
            ExlWS.Cells(i, 14) = "1" 'EXCH_RATE
            ExlWS.Cells(i, 15) = Format(Valuedate, "dd- MMMM - yy") '"" 'VALUE_DATE
            ExlWS.Cells(i, 16) = CStr(rs!Refno) 'INSTRUMENT_NO
            ExlWS.Cells(i, 17) = "" 'REL_CUST
            ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!Remarks), ",", ""), "'", ""), "-", ""), ".", "") 'ADDL_TEXT
            ExlWS.Cells(i, 19) = "" 'comp_mis_1
            ExlWS.Cells(i, 20) = "" 'comp_mis_2
            ExlWS.Cells(i, 21) = "" 'txn_mis_1
            ExlWS.Cells(i, 22) = "" 'txn_mis_3
            ExlWS.Cells(i, 23) = "" 'txn_mis_4
            ExlWS.Cells(i, 24) = "" 'txn_mis_6
            ExlWS.Cells(i, 25) = "~~END~~"

    'increament of variables for row and currno
    i = i + 1
    j = j + 1
     rs.MoveNext
    Loop
End If
            '******************************************************************
''Header record
'******************************************************************

''Trandsaction Record
 '/*********************************************************************************
 'For Credit Record we put fixed Record as their will be only one account to be credited
  '**********************************************************************************
   
  ''**********************************************************************************
  ''**********************************************************************************
  'Now start Debit  amount preparation which will deduct charges from client account
  '***********************************************************************************
 Set rs = Nothing
' prgProcess.Value = 0
' prgProcess.Visible = True
    
Set rs = Nothing
Set rs = ocon.GetResultset("select  credtype,sunaccno,sum(amount)as amount,valuedate,deptyp,refno,remarks from tmpdrbooking " & _
             "group by credtype,sunaccno,valuedate,deptyp,refno,remarks")
             
 If Not (rs.BOF And rs.EOF) Then
  '  prgProcess.Max = rs.RecordCount
    Do Until rs.EOF
      
       ExlWS.Cells(i, 1) = batno 'BATCH_NO
            ExlWS.Cells(i, 2) = "G01" 'BRANCH_CODE
            ExlWS.Cells(i, 3) = "056" 'DEPARTMENT_CODE
            ExlWS.Cells(i, 4) = sourcecode 'FileNm 'SOURCE_CODE
            ExlWS.Cells(i, 5) = Format(j, "000000") 'CURR_NO
            ExlWS.Cells(i, 6) = "BDT" 'CCY_CD
            ExlWS.Cells(i, 7) = Format(Valuedate, "dd- MMMM - yy")  '"" 'INITIATION_DATE
            ExlWS.Cells(i, 8) = CStr(Format(Trim(rs!Amount), "##,##,##,##,###.####")) 'CStr(rs!Amount) 'Amount
            ExlWS.Cells(i, 9) = Trim(rs!sunaccno) '"" 'ACCOUNT
            ExlWS.Cells(i, 10) = Left(Trim(rs!sunaccno), 3) 'ACCOUNT_BRANCH
            If Trim(rs!deptyp) = "Cash" Then
            ExlWS.Cells(i, 11) = "355"  'TXN_CODE
            Else
            ExlWS.Cells(i, 11) = "063" 'TXN_CODE
            End If
            ExlWS.Cells(i, 12) = "D" 'DR_CR
            ExlWS.Cells(i, 13) = CStr(Format(Trim(rs!Amount), "##,##,##,##,###.####")) 'CStr(rs!Amount) 'LCY_EQUIVALENT
            ExlWS.Cells(i, 14) = "1" 'EXCH_RATE
            ExlWS.Cells(i, 15) = CStr(Format(Valuedate, "dd-MMM-YY"))  '"" 'VALUE_DATE
            ExlWS.Cells(i, 16) = CStr(rs!Refno) 'INSTRUMENT_NO
            ExlWS.Cells(i, 17) = "" 'REL_CUST
            ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!Remarks), ",", ""), "'", ""), "-", ""), ".", "") + CStr(Format(rs!Valuedate, "dd-MMM-YY")) 'ADDL_TEXT
            ExlWS.Cells(i, 19) = "" 'comp_mis_1
            ExlWS.Cells(i, 20) = "" 'comp_mis_2
            ExlWS.Cells(i, 21) = "" 'txn_mis_1
            ExlWS.Cells(i, 22) = "" 'txn_mis_3
            ExlWS.Cells(i, 23) = "" 'txn_mis_4
            ExlWS.Cells(i, 24) = "" 'txn_mis_6
            ExlWS.Cells(i, 25) = "~~END~~"
            
            
        i = i + 1
        j = j + 1
     rs.MoveNext
   ' fso.OpenTextFile(App.path & "\ExciseDuty\" & FileNm, ForAppending).WriteLine crctext
 
 'serial = serial + 1
' prgProcess = prgProcess.Value + 1
 Loop
    'i = i + 1
    ExlWS.Cells(i, 1) = "~~END~~"
    ExlWS.Cells(i, 2) = "~~END~~"
' prgProcess.Visible = False

    ExlWS.Visible = True


    ExlWB.Application.Visible = True
    FileNm = FileNm + ".csv"
    ExlWB.SaveAs (App.path & "\IBBSFile\" & FileNm & "")
 



 
 ExlWB.Close
 

 End If
' '****************************************************
'''Trailor record
''*****************************************************
' crctext = "3" + "^" + brcode + "^" + CStr(serial) + "^" + batno + _
' "^" + TotDebtAmt + "^" + TotCrAmt + "^" + TotDebtAcc + "^" + TotCrACC + "^"
' fso.OpenTextFile(App.path & "\ExciseDuty\" & FileNm, ForAppending).WriteLine crctext
 
 Set rs = Nothing
 Set rs = ocon.GetResultset("update genprm set batchno='" & batno & "',batchdate='" & Format(Date, "yyyy/mm/dd") & "'")
 'MsgBox "FLEX File Has been Created", vbOKOnly, "CCCMS"
 
 
 
End Sub




