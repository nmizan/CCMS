VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomct2.ocx"
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Begin VB.Form FrmReversalNikash 
   BackColor       =   &H00E4E8DD&
   Caption         =   "Reversal Nikash"
   ClientHeight    =   8985
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   12060
   LinkTopic       =   "Form2"
   Picture         =   "FrmReversalNikash.frx":0000
   ScaleHeight     =   8985
   ScaleWidth      =   12060
   StartUpPosition =   2  'CenterScreen
   Begin MSComctlLib.ListView ListView1 
      Height          =   6705
      Left            =   0
      TabIndex        =   13
      Top             =   1440
      Width           =   12045
      _ExtentX        =   21246
      _ExtentY        =   11827
      View            =   3
      MultiSelect     =   -1  'True
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FlatScrollBar   =   -1  'True
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      HotTracking     =   -1  'True
      _Version        =   393217
      ForeColor       =   0
      BackColor       =   16777215
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00E4E8DD&
      Height          =   1575
      Left            =   0
      TabIndex        =   11
      Top             =   0
      Width           =   12015
      Begin VB.TextBox txtDR_AC 
         Height          =   285
         Left            =   3360
         TabIndex        =   5
         Top             =   1080
         Width           =   3135
      End
      Begin VB.TextBox txtFlexBranch 
         Height          =   285
         Left            =   7680
         TabIndex        =   4
         Top             =   720
         Width           =   1095
      End
      Begin VB.TextBox txtBatchNo 
         Height          =   285
         Left            =   3360
         TabIndex        =   3
         Top             =   720
         Width           =   3135
      End
      Begin VB.OptionButton OptChecking 
         BackColor       =   &H00E4E8DD&
         Caption         =   "Checking File"
         Height          =   255
         Left            =   5400
         TabIndex        =   1
         Top             =   240
         Value           =   -1  'True
         Width           =   1575
      End
      Begin VB.OptionButton OptFinal 
         BackColor       =   &H00E4E8DD&
         Caption         =   "Final File"
         Height          =   255
         Left            =   7200
         MaskColor       =   &H00C0E0FF&
         TabIndex        =   2
         Top             =   240
         Width           =   1095
      End
      Begin MSComCtl2.DTPicker DTPicker1 
         Height          =   375
         Left            =   3360
         TabIndex        =   0
         Top             =   240
         Width           =   1425
         _ExtentX        =   2514
         _ExtentY        =   661
         _Version        =   393216
         Format          =   49348609
         CurrentDate     =   39142
      End
      Begin MSComCtl2.Animation Animation1 
         Height          =   525
         Left            =   120
         TabIndex        =   14
         Top             =   360
         Width           =   735
         _ExtentX        =   1296
         _ExtentY        =   926
         _Version        =   393216
         BackColor       =   15001821
         FullWidth       =   49
         FullHeight      =   35
      End
      Begin VB.Label Label4 
         BackColor       =   &H00E4E8DD&
         Caption         =   "Debit A/C"
         Height          =   225
         Left            =   2520
         TabIndex        =   17
         Top             =   1080
         Width           =   1065
      End
      Begin VB.Label Label3 
         BackColor       =   &H00E4E8DD&
         Caption         =   "Flex Branch"
         Height          =   225
         Left            =   6720
         TabIndex        =   16
         Top             =   720
         Width           =   1065
      End
      Begin VB.Label Label2 
         BackColor       =   &H00E4E8DD&
         Caption         =   "Batchno"
         Height          =   225
         Left            =   2520
         TabIndex        =   15
         Top             =   720
         Width           =   1065
      End
      Begin VB.Label Label1 
         BackColor       =   &H00E4E8DD&
         Caption         =   "Date"
         Height          =   225
         Left            =   2520
         TabIndex        =   12
         Top             =   240
         Width           =   465
      End
   End
   Begin VB.CommandButton Command2 
      Caption         =   ">>"
      Height          =   375
      Left            =   1800
      TabIndex        =   10
      Top             =   6000
      Visible         =   0   'False
      Width           =   315
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00E4E8DD&
      Height          =   765
      Left            =   0
      TabIndex        =   9
      Top             =   8160
      Width           =   12045
      Begin VB.CommandButton CmdPrint 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Print "
         Height          =   375
         Left            =   6720
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   240
         Width           =   1155
      End
      Begin VB.CommandButton Command1 
         Appearance      =   0  'Flat
         BackColor       =   &H00F3F5F4&
         Caption         =   "Generate CSV File "
         Height          =   375
         Left            =   3360
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   240
         Width           =   2085
      End
      Begin VB.CommandButton cmdclose 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Close"
         Height          =   375
         Left            =   5520
         Style           =   1  'Graphical
         TabIndex        =   7
         Top             =   240
         Width           =   1065
      End
   End
   Begin Crystal.CrystalReport CrystalReport1 
      Left            =   4950
      Top             =   2790
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      PrintFileLinesPerPage=   60
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   0
      Top             =   570
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
End
Attribute VB_Name = "FrmReversalNikash"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim FileNm      As String       'for file
Dim batno       As String       'for batchno
Dim LV As ListView
Dim Li As ListItem
Dim aa As String
Dim sql As String
Dim a As Integer
Dim crcval As String
Dim B As Integer
Dim strpos As String
Dim seqno As String


Private Sub CmdClose_Click()
Unload Me
End Sub

Private Sub CmdPrint_Click()
IBBSReversalRpt
End Sub

Private Sub Command1_Click()
If txtBatchNo.Text = "" Then
    MsgBox "Plz enter Batch No", vbInformation, "CCMS SubSystem"
    Exit Sub
End If
If txtFlexBranch.Text = "" Then
    MsgBox "Plz enter Branch No", vbInformation, "CCMS SubSystem"
    Exit Sub
End If
If txtDR_AC.Text = "" Then
    MsgBox "Plz enter Debit A/C", vbInformation, "CCMS SubSystem"
    Exit Sub
End If
PlayAvi
Set rs = Nothing
Set rs = ocon.GetResultset("execute revgenerate_Nikash")
'Set rs = Nothing
'Set rs = ocon.GetResultset("execute  SP_DEPOSITUPDT_Nikash ")
 FlexFileGen




End Sub

Private Sub Command2_Click()
'ListView42.ListItems.Clear
'sql = "select * from TMPREVERSAL_Nikash where revdate='" & Format(DTPicker1, "mm/dd/yyyy") & "'order by refno"
'LoadListView ListView2, sql
End Sub
Private Sub DTPicker1_LostFocus()
'sql = "select * from ibbsreftab where revdate > date"
'LoadListView ListView1, sql
sql = "select * from Nikashtab where ibbsfilename is null and oprdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'order by oprdate,ds_code,chqnumber "
LoadListView ListView1, sql

'con.Execute ("exec Spclientupd '" & Format(DTPicker1, "mm/dd/yyyy") & "'")
End Sub

Private Sub Form_Load()
ListView1.HotTracking = False
ListView1.LabelEdit = lvwManual
ListView1.View = lvwReport
ListView1.CheckBoxes = False
ListView1.MultiSelect = False
ListView1.FlatScrollBar = False
DTPicker1.Value = Date

CrystalReport1.Connect = strconnect
'CrystalReport1.Connect = "dsn=TID-122;uid=sa;pwd=;dsq=db_citibank;"
'sql = "select * from ibbsreftab where filename ='F7012.000'"
'sql = "select * from ibbsreftab where filename is null and revdate='" & Format(DTPicker1, "mm/dd/yyyy") & "' order by revdate"
sql = "select * from Nikashtab where ibbsfilename is null and oprdate<='" & Format(Date, "mm/dd/yyyy") & "'order by oprdate,ds_code,chqnumber "
LoadListView ListView1, sql

Set rs = Nothing
 Set rs = ocon.GetResultset("select * from genprm")
 If Not (rs.BOF And rs.EOF) Then
   txtFlexBranch.Text = rs!ACCBRANCH
   txtDR_AC.Text = rs!DebitACC
 End If
 

'ListViewAdjustColumnWidth ListView1, True
End Sub

Private Sub LoadListView(LV As ListView, sql As String)

  LV.ListItems.Clear
  LV.ColumnHeaders.Clear
    
  LV.ColumnHeaders.Add , , " Refno", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " ReversalDate", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Check Number", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " DS Code", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Amount", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " ValueDate", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " RevGenerate", 1500, lvwColumnLeft

 ' LV.FlatScrollBar = True
  If LV.ColumnHeaders.count = 0 Then Exit Sub
  Set rs = Nothing
  Set rs = ocon.GetResultset(sql)
    If Not (rs.BOF And rs.EOF) Then
      Do Until rs.EOF
        Set Li = LV.ListItems.Add(, , IIf(IsNull(rs!Refno) = True, 0, rs!Refno))
        Li.ListSubItems.Add , , rs!OprDate
        Li.ListSubItems.Add , , rs!chqnumber
        Li.ListSubItems.Add , , rs!ds_code
        Li.ListSubItems.Add , , rs!DebtCredit
        Li.ListSubItems.Add , , rs!OprDate
        rs.MoveNext
        ', , rs!refno
      Loop
    End If
End Sub
Private Sub FileGen()
Dim exptext     As String       'for text file context
Dim brcode      As String       'for branch
Dim revdate   As String         'for date format yyyymmdd
Dim serial      As Currency     'to count serial
Dim crctext     As String       'text file content with CRC value
Dim convert     As String       '
Dim TotDebtAmt  As Currency     'Total Debit    Amount
Dim TotCrAmt    As Currency     'Total Credit   Amount
Dim TotDebtAcc  As String       'Total Debit    Account
Dim TotCrACC    As String       'Total Credit   Account

''\\\\\\\\\\\\\\\
 'To select batch and reference number
 '\
 Set rs = Nothing
 Set rs = ocon.GetResultset("select isnull(max(seqno),0)seqno from Nikashtab")
 If Not (rs.BOF And rs.EOF) Then
    seqno = rs!seqno
 End If

''\\\\\\\\\\\\\\\
 'To select batch and reference number
 
 Set rs = Nothing
 Set rs = ocon.GetResultset("select * from genprm")
 If Not (rs.BOF And rs.EOF) Then
   If rs!BatchNo = "8000" Then
     batno = "7001"
   Else
    batno = rs!BatchNo + 1
    seqno = seqno + 1
   End If
 End If
' If Not (rs.BOF And rs.EOF) Then
'   batno = rs!batchno + 1
' End If
'''\\\\\\\\\\\\\\\
'batno = "7015"

brcode = "000"
FileNm = "F" + batno + ".000"
'batno = "7001"
serial = 0
 TotDebtAmt = 0
 TotDebtAcc = ""
 TotCrAmt = 0
 TotCrACC = 0
revdate = Mid(Format(DTPicker1, "dd/mm/yyyy"), 7, 10) _
+ Mid(Format(DTPicker1, "dd/mm/yyyy"), 4, 2) + _
Mid(Format(DTPicker1, "dd/mm/yyyy"), 1, 2)
''\\\To get total CreditAmount

Set rs = Nothing
Set rs = ocon.GetResultset(" select sum(cast(acc_no as numeric(14))) as debacctot,sum(amount)as debtotal,REFACC_no " & _
" from tmpreversal_Nikash where  revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
"group by refacc_no")
fso.CreateTextFile App.path & "\ReverseFile\" & FileNm & ""
If Not (rs.BOF And rs.EOF) Then
  Do Until rs.EOF
   TotDebtAmt = TotDebtAmt + rs!debtotal
   TotDebtAcc = rs!refacc_no
   rs.MoveNext
  Loop
  
End If

Set rs = Nothing
TotCrAmt = 0
TotCrACC = 0
Set rs = ocon.GetResultset("select sum(cast(acc_no as numeric(14))) as credacctot,sum(amount) " & _
"as credtotal from tmpreversal_Nikash where " & _
"revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "' Group By revdate ")
If Not (rs.BOF And rs.EOF) Then
Do Until rs.EOF
  TotCrAmt = TotCrAmt + rs!credtotal
  TotCrACC = TotCrACC + rs!credacctot
rs.MoveNext
Loop
End If


'\\\\file generation Procedure
''Header record
 crctext = "1" + "^" + revdate + "^" + Left(FileNm, 5) + "^" + brcode + "^" + batno + "^"
 fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine crctext
''Trandsaction Record
''Credit Data Append

Set rs = Nothing
Set rs = ocon.GetResultset("select revdate,sum(amount)as credtotal,refno,refacc_no " & _
" from tmpreversal_Nikash where revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
" group by revdate,refno,refacc_no")
If Not (rs.BOF And rs.EOF) Then
  Do Until rs.EOF
   
    exptext = "2" + "^" + "000" + "^" + CStr(serial) + "^" + CStr(rs!refacc_no) + "^" + "000" + "^" + _
    "^" + "^" + CStr(rs!credtotal) + "^" + CStr(revdate) + "^" + "914" + "^" + CStr(rs!Refno) + "^" + "^" + "^" + "1" + _
    "^" + CStr((Format(rs!revdate, "dd/MM/yyyy")))
    crctext = exptext
    convert = crc(exptext)
    crctext = crctext + "^" + exptext + "^"
   
    rs.MoveNext
    fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine crctext

    serial = serial + 1
    Loop
End If
 


''debit data append
'        Set rs = Nothing
'         Set rs = ocon.GetResultset("select * from tmpreversal " & _
'            "where revdate='" & Format(DTPicker1, "mm/dd/yyyy") & "'")

'        If Not rs.BOF And rs.EOF Then
'            a = rs.RecordCount
'            ProgressBar1.Visible = True
'            ProgressBar1.Max = a
'        End If
  Set rs = ocon.GetResultset("select * from tmpreversal_Nikash  Where " & _
            "   revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")

 If Not (rs.BOF And rs.EOF) Then
 Do Until rs.EOF
   'CStr(rs!refno)
   exptext = "2" + "^" + "000" + "^" + CStr(serial) + "^" + CStr(Trim(rs!Acc_no)) + "^" + "000" + "^" + _
   "^" + "^" + CStr(rs!amount) + "^" + CStr(revdate) + "^" + "914" + "^" + CStr(Replace(Replace(Replace(rs!ds_code, "O", "0"), "o", "0"), "Q", "0")) + "^" + "^" + "^" + "0" + _
   "^" + CStr(Format(rs!Valuedate, "dd/MM")) 'CStr(rs!ds_code) ''''CStr(rs!remarks)
   crctext = exptext
   convert = crc(exptext)
   crctext = crctext + "^" + exptext + "^"
  
 rs.MoveNext
 fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine crctext

 serial = serial + 1
' ProgressBar1.Value = ProgressBar1.Value + 1
 Loop
 
 End If
''Trailor record
 crctext = "3" + "^" + brcode + "^" + CStr(serial) + "^" + batno + _
 "^" + CStr(TotDebtAmt) + "^" + CStr(TotCrAmt) + "^" + TotDebtAcc + "^" + TotCrACC + "^"
 fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine crctext
 

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
Private Sub IBBSReversalRpt()
Dim a  As String
 Dim seqno  As String
    Set rs = Nothing
    Set rs = ocon.GetResultset("select max(seqno)as seqno from reversalhist_Nikash")
    seqno = rs!seqno

    'FileNm = "F7018.000"
    a = InputBox("Please Enter File  Name ", "CCMS", vbInformation, vbOK)
    
    CrystalReport1.SelectionFormula = "{reversalhist_Nikash.filename} = '" & a & "'and {reversalhist_Nikash.seqno} = " & seqno & ""
    CrystalReport1.WindowTitle = "IBBS Reversal Report"
    CrystalReport1.WindowState = crptMaximized
    
    CrystalReport1.ReportFileName = App.path & "\reports\RptReversal.rpt"
    CrystalReport1.Action = 1
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
        
        expsourcefile = App.path & "\ReverseFile\" & FileNm   'DAT file location
        
        expdotpos = InStr(1, FileNm, ".")
        
'        If expdotpos = 9 Then
'            FileNm = Left(FileNm, 8) & ".Zip"
'        Else
'            FileNm = Left(FileNm, (expdotpos - 1)) & ".Y2Z"
'        End If
        
        expzipfile = App.path & "\ReverseFile\" & FileNm      'file keep here after ZIP
        
        exps1 = "-s"
        
        expsh = Shell(expzip & " " & exps1 & expzpsswd & " " & expzipfile & " " & expsourcefile)
        MsgBox "Exported File " & FileNm, vbInformation, "CRMS"
        '/systemlog comments
        'oconn.UpdateSystemLog "Exported File " & FileNm
        '/
     '   fso.DeleteFile expsourcefile, True        'delete file from app.apth
  '/
End Sub

Private Sub FlexFileGen_OLD()
  ''*****Variables
  Dim sFileHeader As String
  Dim sFileTrailer As String
  Dim iSeqNo As Integer
  Dim sSeqno As String
  Dim ClsexpFile As New clsExportFile
  
''Generate file header
    '                         length
    '____________Name_____________________
    'file header indicator      3
    '            Date           8
    '            File Name      30
    '            serial No      3
    
    '*************Prepare File header
    
    ''Record count =Total record including which includes header and trailor record
    sFileHeader = "HDR" + Format(Date, "YYYYMMDD") + "IE000INF.DAT" + Space(18) + "001"
     
       
       
    sFileTrailer = "TRL" + Format(Date, "YYYYMMDD") + "0000000001"
    
    
    
    '******************************Record Append
    
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
            FileNm = "IE" + brcode + "INF" + ".DAT"
            serial = 0
            
            Valuedate = Mid(Format(Date, "dd/mm/yyyy"), 7, 10) _
            + Mid(Format(Date, "dd/mm/yyyy"), 4, 2) + _
            Mid(Format(Date, "dd/mm/yyyy"), 1, 2)
            fso.CreateTextFile App.path & "\ReverseFile\" & FileNm & ""
            
            '\\\\file generation Procedure
            ''Header record
               
              fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine sFileHeader
            ''Trandsaction Record
         'Credit Data Append
            Set rs = Nothing
             Set rs = ocon.GetResultset("select revdate,sum(amount)as credtotal,refno,refacc_no " & _
            " from tmpreversal_Nikash where revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
            " group by revdate,refno,refacc_no")
             If Not (rs.BOF And rs.EOF) Then
             Do Until rs.EOF
             
               sSeqno = Format("000000", iSeqNo)
               exptext = "B00" + "INF" + Space(12) + "000001" + "0056" + "006" + "USD" + _
               Format(Date, "YYYYMMDD") + ClsexpFile.CheckSpace((rs!credtotal), 22) + _
               ClsexpFile.CheckSpace(CStr(rs!refacc_no), 20) _
               + ClsexpFile.CheckSpace("B00", 3) + "001" _
               + "C" + ClsexpFile.CheckSpace((rs!credtotal), 22) + _
               Space(14) + Format(Date, "YYYYMMDD") + _
               Space(16) + Space(9) + Space(255) + Space(27) + "ProductMI" + Space(126) + Space(20) _
               + Space(16) + Space(16) + "YYYY"
               
               iSeqNo = iSeqNo + 1
             rs.MoveNext
             fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine exptext
          
                         
             Loop
             
             End If
             
            ''debit data append
                    
             Set rs = Nothing
              Set rs = ocon.GetResultset("select * from tmpreversal_Nikash  Where " & _
             "   revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")
             If Not (rs.BOF And rs.EOF) Then
             Do Until rs.EOF
               
               sSeqno = Format("000000", iSeqNo)
               exptext = "B00" + "INF" + Space(12) + "000001" + "0056" + "006" + "USD" + _
               Format(Date, "YYYYMMDD") + ClsexpFile.CheckSpace((rs!amount), 22) + _
               ClsexpFile.CheckSpace(CStr(rs!Acc_no), 20) _
               + ClsexpFile.CheckSpace("B00", 3) + "001" _
               + "D" + ClsexpFile.CheckSpace((rs!amount), 22) + _
               Space(14) + Format(Date, "YYYYMMDD") + _
               Space(16) + Space(9) + Space(255) + Space(27) + "ProductMI" + Space(126) + Space(18) + Space(45) + Space(20) _
               + Space(16) + Space(16) + "YYYY"
              
             rs.MoveNext
             fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine exptext
            
             iSeqNo = iSeqNo + 1
            
             Loop
             
             End If
            ''Trailor record
              fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine sFileTrailer
   
  End Sub
  
Private Sub FlexFileGen()
On Error GoTo err:
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
'If Not (rs.BOF And rs.EOF) Then
'  If rs!daterange = 0 Then
'     batno = rs!BatchNo + 1
'  Else
'       batno = "5601"
'  End If
'End If
    
    batno = Trim(txtBatchNo.Text)
  ' batno = "5601"
    brcode = "G01"
    sourcecode = brcode + batno
    FileNm = "F" + brcode + batno
    
    serial = 0
    'Assign values
   ' TranCode = Trim(TxtTrCode.Text)
    'AccountNo = Trim(TxtBAccount.Text)
    'Remarks = TxtRemrks.Text

    Valuedate = Format(Date, "dd- MMMM - yy")'
    ''\\\To get total CreditAmount
    Set rs = Nothing
    Set rs = ocon.GetResultset("select sum( amount) " & _
    "as credtotal from tmpcrbooking_nikash ")
        If Not (rs.BOF And rs.EOF) Then
          'TotCrAmt = rs!credtotal
          'TotCrACC = rs!cracctot
        End If

        Set ExlWB = GetObject(Trim(App.path & "\User files\FLEXORG.csv"))
               
        Set ExlWS = ExlWB.Worksheets(1)

    'Starts from third row
    i = 3
    j = 1
       
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

' prgProcess.Value = 0
' prgProcess.Visible = True
'
'    Set rs = Nothing
'    Set rs = ocon.GetResultset("select  credtype,sunaccno,sum(amount)as amount,valuedate,deptyp,refno,remarks from tmpdrbooking_nikash " & _
'    "group by credtype,sunaccno,valuedate,deptyp,refno,remarks")
'    If Not (rs.BOF And rs.EOF) Then
'        Do Until rs.EOF
        
             Set rs = Nothing
             Set rs = ocon.GetResultset("select a.*,isnull(b.customer_ref,'')customer_ref from tmpreversal_Nikash a left outer join " & _
             " checktotal b on a.ds_code=b.ds_code  Where " & _
             "   a.revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "' order by a.Acc_No,a.ds_code asc ")
             If Not (rs.BOF And rs.EOF) Then
             Do Until rs.EOF
        
      
            ExlWS.Cells(i, 1) = batno 'BATCH_NO
            ExlWS.Cells(i, 2) = Trim(txtFlexBranch.Text) 'BRANCH_CODE
            ExlWS.Cells(i, 3) = "056" 'DEPARTMENT_CODE
            ExlWS.Cells(i, 4) = sourcecode 'FileNm 'SOURCE_CODE
            ExlWS.Cells(i, 5) = Format(j, "000000") 'CURR_NO
            ExlWS.Cells(i, 6) = "BDT" 'CCY_CD
            ExlWS.Cells(i, 7) = Format(Date, "dd- MMMM - yy")  '"" 'INITIATION_DATE
            ExlWS.Cells(i, 8) = CStr(Format(rs!amount, "###########.####")) 'Amount
            ExlWS.Cells(i, 9) = "G" + Trim(rs!Acc_no) '"" 'ACCOUNT
            ExlWS.Cells(i, 10) = "G" + Left(Trim(rs!Acc_no), 2) 'ACCOUNT_BRANCH
            'If Trim(rs!deptyp) = "Check" Then
            ExlWS.Cells(i, 11) = "451"  'TXN_CODE
            'Else
            'ExlWS.Cells(i, 11) = "451" 'TXN_CODE
            'End If
            ExlWS.Cells(i, 12) = "C" 'DR_CR
            ExlWS.Cells(i, 13) = CStr(Format(rs!amount, "###########.####")) 'LCY_EQUIVALENT
            ExlWS.Cells(i, 14) = "1" 'EXCH_RATE
            ExlWS.Cells(i, 15) = Format(DTPicker1.Value, "dd- MMMM - yy") '"" 'VALUE_DATE
            ExlWS.Cells(i, 16) = CStr(Trim(rs!chqnumber)) 'INSTRUMENT_NO
            ExlWS.Cells(i, 17) = "" 'REL_CUST
            ExlWS.Cells(i, 18) = CStr(rs!seqno) + " " + "Checks Deposited " + " " + "on " + " " + "Date :" + Valuedate + " " + "DsCode" + CStr(Trim(IIf(IsNull(rs!ds_code) = True, "", rs!ds_code))) + "Ref:" + Replace(Replace(Replace(Replace(Trim(IIf(IsNull(rs!customer_ref) = True, "", rs!customer_ref)), ",", ""), "'", ""), "-", ""), ".", "") + CStr(rs!add_text) 'ADDL_TEXT
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
   ' fso.OpenTextFile(App.path & "\User files\ExciseDuty\" & FileNm, ForAppending).WriteLine crctext
 
 'serial = serial + 1
' prgProcess = prgProcess.Value + 1
 Loop
 
             Set rs = Nothing
             Set rs = ocon.GetResultset("select oprdate,sum(debtcredit)as credtotal,count(chqnumber)totcheck " & _
                                        " from nikashtab  where oprdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
                                        " group by oprdate")
            If Not (rs.BOF And rs.EOF) Then
              'TotCrAmt = rs!credtotal
              TotCrACC = rs!totcheck
            End If
 
             
    'Credit Data Append
             Set rs = Nothing
             Set rs = ocon.GetResultset("select revdate,sum(amount)as credtotal,refno,count(refacc_no)totcheck,refacc_no " & _
                                        " from tmpreversal_Nikash where revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
                                        " group by revdate,refno,refacc_no")
             If Not (rs.BOF And rs.EOF) Then
             Do Until rs.EOF
    
                       
            'ExlWS.Cells(I, 1) = "" 'DETB_UPLOAD_DETAIL
                    
                      ExlWS.Cells(i, 1) = batno 'BATCH_NO
                      ExlWS.Cells(i, 2) = Trim(txtFlexBranch.Text) 'BRANCH_CODE
                      ExlWS.Cells(i, 3) = "056" 'DEPARTMENT_CODE
                      ExlWS.Cells(i, 4) = sourcecode 'FileNm 'SOURCE_CODE
                      ExlWS.Cells(i, 5) = Format(j, "000000")  'CURR_NO
                      ExlWS.Cells(i, 6) = "BDT" 'CCY_CD
                      ExlWS.Cells(i, 7) = Format(Date, "dd- MMMM - yy") '"" 'INITIATION_DATE
                      ExlWS.Cells(i, 8) = CStr(Format(Trim(rs!credtotal), "##,##,##,##,###.####")) 'CStr(TotCrAmt)
                      ExlWS.Cells(i, 9) = CStr(Trim(txtDR_AC.Text))  '"G010009155160001" '"Acc_Name '""
                      ExlWS.Cells(i, 10) = Left(CStr(Trim(txtDR_AC.Text)), 3)  'ACCOUNT_BRANCH
                      'If Trim(rs!deptyp) = "Check" Then
                      ExlWS.Cells(i, 11) = "13"  'TXN_CODE
                      'Else
                      'ExlWS.Cells(i, 11) = "13" 'TXN_CODE
                      'End If
                      ExlWS.Cells(i, 12) = "D" 'DR_CR
                      ExlWS.Cells(i, 13) = CStr(Format(Trim(rs!credtotal), "##,##,##,##,###.####")) 'LCY_EQUIVALENT
                      ExlWS.Cells(i, 14) = "1" 'EXCH_RATE
                      ExlWS.Cells(i, 15) = Format(DTPicker1.Value, "dd- MMMM - yy") '"" 'VALUE_DATE
                      ExlWS.Cells(i, 16) = Format(DTPicker1.Value, "ddMMyy") 'CStr(rs!refacc_no) 'INSTRUMENT_NO
                      ExlWS.Cells(i, 17) = "" 'REL_CUST
                      ExlWS.Cells(i, 18) = "OUTWARD " + "" + "Total Check :" + CStr(TotCrACC) 'Replace(Replace(Replace(Replace(Trim(rs!Remarks), ",", ""), "'", ""), "-", ""), ".", "") 'ADDL_TEXT
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
 
    'i = i + 1
    ExlWS.Cells(i, 1) = "~~END~~"
    ExlWS.Cells(i, 2) = "~~END~~"
' prgProcess.Visible = False

    ExlWS.Visible = True


    ExlWB.Application.Visible = True
    FileNm = FileNm + ".csv"
    ExlWB.SaveAs (App.path & "\User files\FlexcubeFile\" & FileNm & "")
 



 
 ExlWB.Close
 

 End If
' '****************************************************
'''Trailor record
''*****************************************************
' crctext = "3" + "^" + brcode + "^" + CStr(serial) + "^" + batno + _
' "^" + TotDebtAmt + "^" + TotCrAmt + "^" + TotDebtAcc + "^" + TotCrACC + "^"
' fso.OpenTextFile(App.path & "\ExciseDuty\" & FileNm, ForAppending).WriteLine crctext
 If OptFinal.Value = True Then
        
 
        Set rs = Nothing
        Set rs = ocon.GetResultset("update genprm set batchno='" & batno & "',batchdate='" & Format(Date, "yyyy/mm/dd") & "'")
        'Exit Sub
        'MsgBox "FLEX File Has been Created", vbOKOnly, "CCCMS"
        
        StopAvi
        MsgBox "File  " & FileNm & "  has been created for FlexCube", vbOKOnly, "CCMS SubSystem"
        Set rs = Nothing
        Set rs = ocon.GetResultset("Update genprm set batchno='" & batno & "'")
        Set rs = Nothing
        Set rs = ocon.GetResultset("update nikashtab set ibbsfilename='" & FileNm & "' where ibbsfilename is null and oprdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")
        'Set rs = Nothing
        'Set rs = ocon.GetResultset("insert into reversalhist( select * from ibbsreftab where  Filename='" & FileNm & "' and revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")
        'Set rs = Nothing
        'Set rs = ocon.GetResultset("delete from ibbsreftab_Nikash  where filename is not null ")
        Set rs = Nothing
        Set rs = ocon.GetResultset("update tmpreversal_Nikash set Filename='" & FileNm & "' where filename is null and oprdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")
        
        ''\\Update tmpreversal table
        Set rs = Nothing
        Set rs = ocon.GetResultset("update genprm set seqno='" & Val(seqno) & "'")
        ''\\
        Set rs = Nothing
        Set rs = ocon.GetResultset("insert into reversalhist_Nikash select * from tmpreversal_Nikash")
        Set rs = Nothing
        Set rs = ocon.GetResultset("delete from tmpreversal_Nikash ")

Else
    StopAvi
    MsgBox "File  " & FileNm & "  has been created for FlexCube", vbOKOnly, "CCMS SubSystem"
    Exit Sub
End If
 
err:
 
MsgBox (err.Description), vbInformation, "CCMS SubSystem"
 
End Sub


Sub ListViewAdjustColumnWidth(LV As ListView, _
    Optional AccountForHeaders As Boolean)
    Dim row As Long, col As Long
    Dim width As Single, maxWidth As Single
    Dim saveFont As StdFont, saveScaleMode As Integer, cellText As String
    ' Exit if there aren't any items.
    If LV.ListItems.count = 0 Then Exit Sub
    
    ' Save the font used by the parent form, and enforce ListView's
    ' font. (We need this in order to use the form's TextWidth
    ' method.)
    Set saveFont = LV.Parent.Font
    Set LV.Parent.Font = LV.Font
    ' Enforce ScaleMode = vbTwips for the parent.
    saveScaleMode = LV.Parent.ScaleMode
    LV.Parent.ScaleMode = vbTwips
    
    For col = 1 To LV.ColumnHeaders.count
        maxWidth = 0
        If AccountForHeaders Then
            maxWidth = LV.Parent.TextWidth(LV.ColumnHeaders(col).Text) + 200
        End If
        For row = 1 To LV.ListItems.count
            ' Retrieve the text string from ListItems or ListSubItems.
            If col = 1 Then
                cellText = LV.ListItems(row).Text
            Else
                cellText = LV.ListItems(row).ListSubItems(col - 1).Text
            End If
            ' Calculate its width, and account for margins.
            ' Note: doesn't account for multiple-line text fields.
            width = LV.Parent.TextWidth(cellText) + 200
            ' Update maxWidth if we've found a larger string.
            If width > maxWidth Then maxWidth = width
        Next
        ' Change the column's width.
        LV.ColumnHeaders(col).width = maxWidth
    Next
    ' Restore parent form's properties.
    Set LV.Parent.Font = saveFont
    LV.Parent.ScaleMode = saveScaleMode
End Sub



Private Sub ListView1_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    ' Sort according to data in this column.
    If ListView1.Sorted And _
        ColumnHeader.Index - 1 = ListView1.SortKey Then
        ' Already sorted on this column, just invert the sort order.
        ListView1.SortOrder = 1 - ListView1.SortOrder
    Else
        ListView1.SortOrder = lvwAscending
        ListView1.SortKey = ColumnHeader.Index - 1
    End If
    ListView1.Sorted = True

End Sub


