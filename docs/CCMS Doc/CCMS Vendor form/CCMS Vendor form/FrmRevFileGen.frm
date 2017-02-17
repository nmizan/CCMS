VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmRevFileGen 
   BackColor       =   &H80000000&
   Caption         =   "Reversal Generate "
   ClientHeight    =   6870
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   12075
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   6870
   ScaleWidth      =   12075
   StartUpPosition =   2  'CenterScreen
   Begin VB.OptionButton OptFlexCube 
      BackColor       =   &H80000000&
      Caption         =   "FlexCube Format"
      Height          =   255
      Left            =   2880
      TabIndex        =   11
      Top             =   240
      Value           =   -1  'True
      Width           =   1935
   End
   Begin VB.OptionButton OptIBBS 
      BackColor       =   &H80000000&
      Caption         =   "IBBS File Format"
      Height          =   255
      Left            =   1080
      MaskColor       =   &H00C0E0FF&
      TabIndex        =   10
      Top             =   240
      Visible         =   0   'False
      Width           =   1815
   End
   Begin Crystal.CrystalReport CrystalReport1 
      Left            =   5040
      Top             =   2880
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      PrintFileLinesPerPage=   60
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H80000000&
      Height          =   885
      Left            =   180
      TabIndex        =   6
      Top             =   5850
      Width           =   11805
      Begin VB.CommandButton CmdViewAllReversalData 
         BackColor       =   &H00F3F5F4&
         Caption         =   "View All Reversal Data"
         Height          =   375
         Left            =   8760
         Style           =   1  'Graphical
         TabIndex        =   12
         Top             =   180
         Width           =   1875
      End
      Begin VB.CommandButton CmdPrint 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Print "
         Height          =   375
         Left            =   7560
         Style           =   1  'Graphical
         TabIndex        =   9
         Top             =   180
         Width           =   1155
      End
      Begin VB.CommandButton Command1 
         Appearance      =   0  'Flat
         BackColor       =   &H00F3F5F4&
         Caption         =   "REVERSAL GENERATE"
         Height          =   375
         Left            =   4380
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   180
         Width           =   2085
      End
      Begin VB.CommandButton cmdclose 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Close"
         Height          =   375
         Left            =   6450
         Style           =   1  'Graphical
         TabIndex        =   7
         Top             =   180
         Width           =   1065
      End
   End
   Begin MSComCtl2.DTPicker DTPicker1 
      Height          =   255
      Left            =   6450
      TabIndex        =   3
      Top             =   150
      Width           =   1425
      _ExtentX        =   2514
      _ExtentY        =   450
      _Version        =   393216
      Format          =   78184449
      CurrentDate     =   37702
   End
   Begin VB.CommandButton Command2 
      Caption         =   ">>"
      Height          =   375
      Left            =   3480
      TabIndex        =   2
      Top             =   6000
      Visible         =   0   'False
      Width           =   315
   End
   Begin MSComctlLib.ListView ListView1 
      Height          =   5205
      Left            =   180
      TabIndex        =   0
      Top             =   660
      Width           =   11805
      _ExtentX        =   20823
      _ExtentY        =   9181
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      OLEDragMode     =   1
      FlatScrollBar   =   -1  'True
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   0
      OLEDragMode     =   1
      NumItems        =   0
   End
   Begin MSComctlLib.ListView ListView2 
      Height          =   5205
      Left            =   5970
      TabIndex        =   1
      Top             =   750
      Visible         =   0   'False
      Width           =   5505
      _ExtentX        =   9710
      _ExtentY        =   9181
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FlatScrollBar   =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   0
      NumItems        =   0
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   90
      Top             =   660
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin MSComCtl2.Animation Animation1 
      Height          =   525
      Left            =   180
      TabIndex        =   5
      Top             =   90
      Width           =   735
      _ExtentX        =   1296
      _ExtentY        =   926
      _Version        =   393216
      BackColor       =   -2147483648
      FullWidth       =   49
      FullHeight      =   35
   End
   Begin VB.Label Label1 
      BackColor       =   &H80000000&
      Caption         =   "Date"
      Height          =   225
      Left            =   5850
      TabIndex        =   4
      Top             =   180
      Width           =   465
   End
End
Attribute VB_Name = "FrmRevFileGen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'**********************************************
'Form name              :frmRevFileGen
'Form Description       :Reversal Generation
'Creation date          :06/10/2004
'Design & Developed by  :Dewan Ahsanullah
'**********************************************
Option Explicit
Dim FileNm      As String       'for file
Dim batno       As String       'for batchno
Dim LV As ListView
Dim Li As ListItem
Dim aa As String
Dim sql As String
Dim A As Integer
Dim crcval As String
Dim B As Integer
Dim strpos As String
Dim seqno As String


Private Sub cmdClose_Click()
Unload Me
End Sub

Private Sub CmdPrint_Click()
On Error GoTo err
IBBSReversalRpt
err:
End Sub

Private Sub CmdViewAllReversalData_Click()
On Error GoTo err
Dim rptSelection As String
'    rptSelection = "{viewreversalalldata.valuedate}  in date (" & Mid(DTPicker1, 7, 4) _
'                 & "," & Mid(DTPicker1, 4, 2) & "," & Mid(DTPicker1, 1, 2) _
'                 & ") to date (" & Mid(DTPicker1, 7, 4) _
'                 & "," & Mid(DTPicker1, 4, 2) & "," & Mid(DTPicker1, 1, 2) & ")"
        
    rptSelection = ""
    CrystalReport1.SelectionFormula = rptSelection
    CrystalReport1.WindowTitle = "FLEX Reversal Report"
    CrystalReport1.WindowState = crptMaximized
    
    CrystalReport1.ReportFileName = App.path & "\Reports\RptReversalAllData.rpt"
    CrystalReport1.Action = 1
    Exit Sub
err:
MsgBox (err.Description)

End Sub

Private Sub Command1_Click()
 '***For authorization
 If Authorized = False Then
   Exit Sub
 End If
On Error GoTo err
PlayAvi
Set rs = Nothing
Set rs = ocon.GetResultset("execute revgenerate")
Set rs = Nothing
Set rs = ocon.GetResultset("select * from tmpreversal where ds_code is null")
  If Not (rs.BOF And rs.EOF) Then
    MsgBox "Please check refno which is blank for some customers", vbOKOnly, "CCMS"
    StopAvi
    Exit Sub
  End If
Set rs = Nothing
Set rs = ocon.GetResultset("execute  SP_DEPOSITUPDT ")
If OptFlexCube = True Then
    FLEXFileGen
Else
    FileGen
End If
    StopAvi
MsgBox "Reverse File  " & FileNm & "  is generated for Flexcube", vbOKOnly, "CCMS"
'--Set rs = Nothing
'--Set rs = ocon.GetResultset("Update genprm set batchno='" & batno & "'")

'''**********New update for flex cube
Set rs = Nothing
Set rs = ocon.GetResultset("update genprm set batchno='" & batno & "',batchdate='" & Format(Date, "yyyy/mm/dd") & "'")



Set rs = Nothing
Set rs = ocon.GetResultset("update ibbsreftab set Filename='" & FileNm & "',flexgendate='" & Format(Date, "yyyy/mm/dd") & "' where filename is null and revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "' and (statusid=1 )and (authorize =1)")
Set rs = Nothing
Set rs = ocon.GetResultset("delete from ibbsreftabhist")
Set rs = Nothing
Set rs = ocon.GetResultset("insert into ibbsreftabhist select * from ibbsreftab where filename is not null")
Set rs = Nothing
Set rs = ocon.GetResultset("delete from ibbsreftab  where filename is not null ")
Set rs = Nothing
Set rs = ocon.GetResultset("update tmpreversal set Filename='" & FileNm & "',flexgendate='" & Format(DTPicker1, "mm/dd/yyyy") & "' where filename is null and revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")

''\\Update tmpreversal table
'Set rs = Nothing
'Set rs = ocon.GetResultset("update tmpreversal set seqno='" & seqno & "'")
''\\
Set rs = Nothing
Set rs = ocon.GetResultset("insert into reversalhist select * from tmpreversal")
Set rs = Nothing
Set rs = ocon.GetResultset("delete from tmpreversal ")
Exit Sub
err:
MsgBox (err.Description), vbOKOnly
End Sub

Private Sub Command2_Click()
ListView2.ListItems.Clear
sql = "select * from TMPREVERSAL where revdate='" & Format(DTPicker1, "mm/dd/yyyy") & "'order by refno"
LoadListView ListView2, sql
End Sub

Private Sub Command3_Click()

End Sub

Private Sub DTPicker1_LostFocus()
'sql = "select * from ibbsreftab where revdate > date"
'LoadListView ListView1, sql
'sql = "select * from ibbsreftab where filename is null and  revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "' order by revdate"
sql = " select a.*,b.acc_name from ibbsreftab a left outer join client b " & _
" on b.acc_no=a.acc_no where filename is null and revdate <='" & Format(DTPicker1, "mm/dd/yyyy") & "' order by revdate,b.acc_name asc "

LoadListView ListView1, sql

'con.Execute ("exec Spclientupd '" & Format(DTPicker1, "mm/dd/yyyy") & "'")
End Sub

Private Sub Form_Load()

DTPicker1.Value = Date
CrystalReport1.Connect = strconnect
'CrystalReport1.Connect = "dsn=TID-122;uid=sa;pwd=;dsq=db_citibank;"
'sql = "select * from ibbsreftab where filename ='F7012.000'"
'sql = "select * from ibbsreftab where filename is null and revdate='" & Format(DTPicker1, "mm/dd/yyyy") & "' order by revdate"
'Set rs = Nothing
'Set rs = ocon.GetResultset("execute revgenerate")
'Set rs = Nothing
'Set rs = ocon.GetResultset("select * from tmpreversal where ds_code is null")
'  If Not (rs.BOF And rs.EOF) Then
'    MsgBox "Please check refno which is blank for some customers", vbOKOnly, "CCMS"
'    Exit Sub
'  End If
'Set rs = Nothing
'Set rs = ocon.GetResultset("execute  SP_DEPOSITUPDT")
'Set rs = Nothing
sql = " select a.*,b.acc_name from ibbsreftab a left outer join client b " & _
" on b.acc_no=a.acc_no where filename is null and revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "' order by revdate,b.acc_name asc "

'sql = "select * from ibbsreftab where filename is null and revdate<='" & Format(Date, "mm/dd/yyyy") & "'order by revdate "
LoadListView ListView1, sql
End Sub

Private Sub LoadListView(LV As ListView, sql As String)
   LV.ListItems.Clear
  LV.ColumnHeaders.Add , , " Refno", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " ReversalDate", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Amount", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " ValueDate", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " RevGenerate", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " DepositCode", 1500, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Client Name", 3000, lvwColumnLeft
  'LV.ColumnHeaders.Add , , " Credit Type", 150, lvwColumnLeft
  
  LV.FlatScrollBar = False
  
  Set rs = Nothing
  Set rs = ocon.GetResultset(sql)
    If Not (rs.BOF And rs.EOF) Then
      Do Until rs.EOF
        Set Li = LV.ListItems.Add(, , rs!Refno)
        Li.ListSubItems.Add , , rs!revdate
        Li.ListSubItems.Add , , rs!Amount
        Li.ListSubItems.Add , , rs!Valuedate
        Li.ListSubItems.Add , , ""
        Li.ListSubItems.Add , , IIf(IsNull(rs!d_code) = True, "NULL", rs!d_code)
        Li.ListSubItems.Add , , IIf(IsNull(rs!Acc_Name) = True, "", rs!Acc_Name)
       ' Li.ListSubItems.Add , , rs!crtyp
        
        
        
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
 Set rs = ocon.GetResultset("select isnull(max(seqno),0)seqno from dschedule")
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
Set rs = ocon.GetResultset(" select sum(amount)as debtotal,REFACC_no " & _
" from tmpreversal where  revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
"group by refacc_no")
'fso.CreateTextFile App.path & "\ReverseFile\" & FileNm & ""
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
Set rs = ocon.GetResultset("select sum(amount) " & _
"as credtotal from tmpreversal where " & _
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
" from tmpreversal where revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
" group by revdate,refno,refacc_no")
If Not (rs.BOF And rs.EOF) Then
  Do Until rs.EOF
   
    exptext = "2" + "^" + "000" + "^" + CStr(serial) + "^" + CStr(rs!refacc_no) + "^" + "000" + "^" + _
    "^" + "^" + CStr(rs!credtotal) + "^" + CStr(revdate) + "^" + "99" + "^" + CStr(rs!Refno) + "^" + "^" + "^" + "0" + _
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
  Set rs = ocon.GetResultset("select a.*,b.* from tmpreversal a,location b Where " & _
            " a.location_code=b.location_code " & _
            " and revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")

 If Not (rs.BOF And rs.EOF) Then
 Do Until rs.EOF
   'CStr(rs!refno)
   exptext = "2" + "^" + "000" + "^" + CStr(serial) + "^" + CStr(Trim(rs!Acc_No)) + "^" + "000" + "^" + _
   "^" + "^" + CStr(rs!Amount) + "^" + CStr(revdate) + "^" + IIf(Trim(rs!Deposit_Type) = "Cash", "908", "907") + "^" + CStr(Replace(Replace(Replace(rs!ds_code, "O", "0"), "o", "0"), "Q", "0")) + "^" + "^" + "^" + "1" + _
   "^" + (CStr(Left(Trim(rs!location_name), 18)) + Space(1) + CStr(Format(rs!Valuedate, "dd/MM"))) 'CStr(rs!ds_code) ''''CStr(rs!remarks)
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
Dim A  As String
 Dim seqno  As String
    Set rs = Nothing
    Set rs = ocon.GetResultset("select max(seqno)as seqno from reversalhist")
    If Not (rs.BOF And rs.EOF) Then
     seqno = IIf(IsNull(rs!seqno) = True, 0, rs!seqno)
    Else
    seqno = 1
    End If

    'FileNm = "F7018.000"
    A = InputBox("Please Enter File  Name ", "CCMS", vbInformation, vbOK)
    
    CrystalReport1.SelectionFormula = "{reversalhist.filename} = '" & A & "' and {reversalhist.flexgendate} in date (" & Mid(DTPicker1.Value, 7, 4) _
                 & "," & Mid(DTPicker1.Value, 4, 2) & "," & Mid(DTPicker1.Value, 1, 2) & ")"
    CrystalReport1.WindowTitle = "FLEX Reversal Report"
    CrystalReport1.WindowState = crptMaximized
    
    CrystalReport1.ReportFileName = App.path & "\Reports\RptReversal.rpt"
    CrystalReport1.Action = 1
End Sub
Private Sub ReversalAllRpt()
Dim A  As String
 Dim seqno  As String
 
   
    CrystalReport1.SelectionFormula = ""
    CrystalReport1.WindowTitle = "FLEX Reversal Report"
    CrystalReport1.WindowState = crptMaximized
    
    CrystalReport1.ReportFileName = App.path & "\Reports\RptReversal.rpt"
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
'            brcode = "G01"
'            FileNm = "IE" + brcode + "INF" + ".DAT"
'            serial = 0
'
'            Valuedate = Mid(Format(Date, "dd/mm/yyyy"), 7, 10) _
'            + Mid(Format(Date, "dd/mm/yyyy"), 4, 2) + _
'            Mid(Format(Date, "dd/mm/yyyy"), 1, 2)
'            fso.CreateTextFile App.path & "\ReverseFile\" & FileNm & ""
'
'            '\\\\file generation Procedure
'            ''Header record
'
'              fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine sFileHeader
'            ''Trandsaction Record
'         'Credit Data Append
'            Set rs = Nothing
'             Set rs = ocon.GetResultset("select revdate,sum(amount)as credtotal,refno,refacc_no " & _
'            " from tmpreversal where revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
'            " group by revdate,refno,refacc_no")
'             If Not (rs.BOF And rs.EOF) Then
'             Do Until rs.EOF
'
'               sSeqno = Format("000000", iSeqNo)
'               exptext = brcode + "INF" + Space(12) + "000001" + "0056" + "056" + "BDT" + _
'               Format(Date, "YYYYMMDD") + ClsexpFile.CheckSpace((rs!credtotal), 22) + _
'               ClsexpFile.CheckSpace(CStr(rs!refacc_no), 20) _
'               + ClsexpFile.CheckSpace(brcode, 3) + "001" _
'               + "C" + ClsexpFile.CheckSpace((rs!credtotal), 22) + _
'               Space(14) + Format(Date, "YYYYMMDD") + _
'               Space(16) + Space(9) + Space(255) + Space(27) + "ProductMI" + Space(126) + Space(20) _
'               + Space(16) + Space(16) + "YYYY"
'
'               iSeqNo = iSeqNo + 1
'             rs.MoveNext
'             fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine exptext
'
'
'             Loop
'
'             End If
'
'            ''debit data append
'
'             Set rs = Nothing
'              Set rs = ocon.GetResultset("select * from tmpreversal  Where " & _
'             "   revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")
'             If Not (rs.BOF And rs.EOF) Then
'             Do Until rs.EOF
'
'               sSeqno = Format("000000", iSeqNo)
'               exptext = brcode + "INF" + Space(12) + "000001" + "0056" + "056" + "BDT" + _
'               Format(Date, "YYYYMMDD") + ClsexpFile.CheckSpace((rs!Amount), 22) + _
'               ClsexpFile.CheckSpace(CStr(rs!Acc_No), 20) _
'               + ClsexpFile.CheckSpace(brcode, 3) + "001" _
'               + "D" + ClsexpFile.CheckSpace((rs!Amount), 22) + _
'               Space(14) + Format(Date, "YYYYMMDD") + _
'               Space(16) + Space(9) + Space(255) + Space(27) + "ProductMI" + Space(126) + Space(18) + Space(45) + Space(20) _
'               + Space(16) + Space(16) + "YYYY"
'
'             rs.MoveNext
'             fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine exptext
'
'             iSeqNo = iSeqNo + 1
'
'             Loop
'
'             End If
'            ''Trailor record
'              fso.OpenTextFile(App.path & "\ReverseFile\" & FileNm, ForAppending).WriteLine sFileTrailer
'
'
'
'End Sub
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
        TotCrAmt = IIf(IsNull(rs!credtotal) = True, 0, rs!credtotal)
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
    '***************************** Starts from third row
    '*********************Acount Debited data
    i = 3
    j = 1
    Set rs = ocon.GetResultset("select revdate,deposit_type,sum(amount)as credtotal,refno,refacc_no " & _
       " from tmpreversal where revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
       " group by revdate,refno,refacc_no,deposit_type")
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
            ExlWS.Cells(i, 8) = CStr(Format(Trim(rs!credtotal), "##,##,##,##,###.####")) 'Trim(rs!credtotal) 'CStr(TotCrAmt)
            ''**********Replace account for sundry,
            ''**********Instead of debit sundry it will debit this following account
            ExlWS.Cells(i, 9) = "G010009198080001" 'CStr(rs!sunaccno) '"G010009155160001" '"Acc_Name '""
            ExlWS.Cells(i, 10) = Left(CStr(rs!refacc_no), 3) 'ACCOUNT_BRANCH
            
             If Trim(rs!Deposit_Type) = "Cash" Then
              ExlWS.Cells(i, 11) = "355"
             Else
               ExlWS.Cells(i, 11) = "63" 'TXN_CODE
             End If
             
            ExlWS.Cells(i, 12) = "D" 'DR_CR
            ExlWS.Cells(i, 13) = CStr(Format(Trim(rs!credtotal), "##,##,##,##,###.####"))     'LCY_EQUIVALENT
            ExlWS.Cells(i, 14) = "1" 'EXCH_RATE
            ExlWS.Cells(i, 15) = Format(rs!revdate, "dd- MMMM - yy") '"" 'VALUE_DATE
            ExlWS.Cells(i, 16) = CStr(rs!Refno) 'INSTRUMENT_NO
            ExlWS.Cells(i, 17) = "" 'REL_CUST
            If (Trim(rs!Deposit_Type)) = "Cash" Then
                  ExlWS.Cells(i, 18) = "Cash" 'IIf(rs!Deposit_Type = "Cash", "Cash", "Check")  'ADDL_TEXT
            Else
                  ExlWS.Cells(i, 18) = "Check" 'IIf(rs!Deposit_Type = "Cash", "Cash", "Check")  'ADDL_TEXT
            End If
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
 
' prgProcess.Value = 0
' prgProcess.Visible = True
  Set rs = Nothing
  Set rs = ocon.GetResultset("select a.*,b.* from tmpreversal a,location b Where " & _
            " a.location_code=b.location_code " & _
            " and revdate<='" & Format(DTPicker1, "mm/dd/yyyy") & "'")
             
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
            ExlWS.Cells(i, 8) = CStr(Format(Trim(rs!Amount), "##,##,##,##,###.####"))    'CStr(rs!Amount) 'Amount
            ExlWS.Cells(i, 9) = Trim(rs!Acc_No) '"" 'ACCOUNT
            ExlWS.Cells(i, 10) = Left(CStr(rs!Acc_No), 3) 'ACCOUNT_BRANCH
           If Trim(rs!Deposit_Type) = "Cash" Then
              ExlWS.Cells(i, 11) = "355"
             Else
               ExlWS.Cells(i, 11) = "63" 'TXN_CODE
            End If
            ExlWS.Cells(i, 12) = "C" 'DR_CR
            ExlWS.Cells(i, 13) = CStr(Format(Trim(rs!Amount), "##,##,##,##,###.####"))  'CStr(rs!Amount) 'LCY_EQUIVALENT
            ExlWS.Cells(i, 14) = "1" 'EXCH_RATE
            ExlWS.Cells(i, 15) = Format(rs!revdate, "dd- MMMM - yy")  '"" 'VALUE_DATE
            ExlWS.Cells(i, 16) = CStr(rs!ds_code) 'INSTRUMENT_NO
            ExlWS.Cells(i, 17) = "" 'REL_CUST
            If rs!crtyp = "C" Then
            ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") + " DS NO " + CStr(rs!CheckDSno) + " REF " + CStr(IIf(IsNull(rs!CustomerRef) = True, "", rs!CustomerRef)) 'ADDL_TEXT
            ElseIf rs!crtyp = "R" Then
            ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") + " DS NO " + CStr(rs!CheckDSno) + " REF " + CStr(IIf(IsNull(rs!CustomerRef) = True, "", rs!CustomerRef)) 'ADDL_TEXT
            ElseIf rs!crtyp = "D" Then
                If Trim(rs!Deposit_Type) = "Cash" Then
                  ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") + " DS NO " + CStr(rs!CheckDSno) + " REF " + CStr(IIf(IsNull(rs!CustomerRef) = True, "", rs!CustomerRef)) 'ADDL_TEXT
                Else
                  ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") + " DS NO " + CStr(rs!CheckDSno)  'ADDL_TEXT
                End If
            ElseIf rs!crtyp = "L" Then
            ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy")  'ADDL_TEXT
            ElseIf rs!crtyp = "T" Then
                If Trim(rs!Deposit_Type) = "Cash" Then
                    ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") + Space(1) + "SLIPCOUNT " + rs!CheckDSno + "" 'ADDL_TEXT1
                Else
                    ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") 'ADDL_TEXT1
                End If
            Else
            ExlWS.Cells(i, 18) = Replace(Replace(Replace(Replace(Trim(rs!location_name), ",", ""), "'", ""), "-", ""), ".", "") + Space(2) + Format(rs!Valuedate, "ddMMMMyy") + " DS NO " + CStr(IIf(IsNull(rs!ds_code) = True, "", rs!ds_code))  'ADDL_TEXT
            End If
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
    ExlWB.SaveAs (App.path & "\ReverseFile\" & FileNm & "")
 



 
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
 MsgBox "FLEX File Has been Created", vbOKOnly, "CCCMS"



End Sub
