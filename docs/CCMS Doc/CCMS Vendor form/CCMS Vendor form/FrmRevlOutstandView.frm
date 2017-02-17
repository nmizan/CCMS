VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form FrmRevlOutstandView 
   ClientHeight    =   10770
   ClientLeft      =   120
   ClientTop       =   420
   ClientWidth     =   15120
   LinkTopic       =   "Form2"
   ScaleHeight     =   10770
   ScaleWidth      =   15120
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame3 
      Height          =   1815
      Left            =   1920
      TabIndex        =   12
      Top             =   840
      Width           =   5055
      Begin VB.ComboBox cmbstatus2 
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Times New Roman"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C00000&
         Height          =   345
         Left            =   1560
         TabIndex        =   16
         Top             =   840
         Width           =   2145
      End
      Begin VB.CommandButton CmdSearch 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Search"
         Height          =   375
         Left            =   3720
         Style           =   1  'Graphical
         TabIndex        =   15
         Top             =   840
         Width           =   1065
      End
      Begin MSComCtl2.DTPicker DTPicker1 
         Height          =   375
         Left            =   1560
         TabIndex        =   13
         Top             =   360
         Width           =   1665
         _ExtentX        =   2937
         _ExtentY        =   661
         _Version        =   393216
         Format          =   59506689
         CurrentDate     =   37702
      End
      Begin VB.Label lblindication 
         BackColor       =   &H80000002&
         Caption         =   "Pls wait while data is loading..........."
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   0
         TabIndex        =   19
         Top             =   1560
         Visible         =   0   'False
         Width           =   5055
      End
      Begin VB.Label Label5 
         Caption         =   "Status"
         Height          =   375
         Left            =   930
         TabIndex        =   17
         Top             =   840
         Width           =   495
      End
      Begin VB.Label Label1 
         BackColor       =   &H80000004&
         Caption         =   "Reversal Date"
         Height          =   225
         Left            =   360
         TabIndex        =   14
         Top             =   390
         Width           =   1065
      End
   End
   Begin VB.Frame Frame2 
      Height          =   1815
      Left            =   7080
      TabIndex        =   4
      Top             =   840
      Width           =   8655
      Begin VB.TextBox txtdeposittype 
         Enabled         =   0   'False
         Height          =   375
         Left            =   5880
         TabIndex        =   24
         Top             =   240
         Width           =   1815
      End
      Begin VB.CommandButton cmdAuthorize 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Authorize"
         Enabled         =   0   'False
         Height          =   375
         Left            =   6960
         Style           =   1  'Graphical
         TabIndex        =   23
         Top             =   1320
         Width           =   1065
      End
      Begin VB.CommandButton cmdSave 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Save"
         Height          =   375
         Left            =   5760
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   1320
         Width           =   1065
      End
      Begin VB.TextBox txtRemarks 
         Height          =   375
         Left            =   1680
         TabIndex        =   9
         Top             =   1320
         Width           =   3855
      End
      Begin VB.ComboBox cmbStatus1 
         Appearance      =   0  'Flat
         BeginProperty Font 
            Name            =   "Times New Roman"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C00000&
         Height          =   345
         Left            =   1680
         TabIndex        =   6
         Top             =   840
         Width           =   3825
      End
      Begin VB.TextBox txtDscode 
         Height          =   375
         Left            =   1680
         TabIndex        =   5
         Top             =   360
         Width           =   2655
      End
      Begin VB.Label lbldeptype 
         Caption         =   "DepositType"
         Height          =   375
         Left            =   4800
         TabIndex        =   25
         Top             =   240
         Width           =   1095
      End
      Begin VB.Label Label4 
         Caption         =   "Remarks"
         Height          =   375
         Left            =   720
         TabIndex        =   10
         Top             =   1320
         Width           =   855
      End
      Begin VB.Label Label3 
         Caption         =   "Status"
         Height          =   375
         Left            =   720
         TabIndex        =   8
         Top             =   840
         Width           =   495
      End
      Begin VB.Label Label2 
         Caption         =   "DSlip No"
         Height          =   375
         Left            =   720
         TabIndex        =   7
         Top             =   360
         Width           =   855
      End
   End
   Begin VB.CommandButton Command2 
      Caption         =   ">>"
      Height          =   375
      Left            =   3120
      TabIndex        =   2
      Top             =   6000
      Visible         =   0   'False
      Width           =   315
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H80000000&
      Height          =   765
      Left            =   120
      TabIndex        =   0
      Top             =   9960
      Width           =   16815
      Begin VB.CommandButton CmdRefresh 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Refresh"
         Height          =   375
         Left            =   7440
         Style           =   1  'Graphical
         TabIndex        =   18
         Top             =   240
         Width           =   1065
      End
      Begin VB.CommandButton cmdclose 
         BackColor       =   &H00F3F5F4&
         Caption         =   "Close"
         Height          =   375
         Left            =   8520
         Style           =   1  'Graphical
         TabIndex        =   1
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
   Begin MSComctlLib.ListView ListView1 
      Height          =   6705
      Left            =   240
      TabIndex        =   3
      Top             =   3000
      Width           =   16575
      _ExtentX        =   29236
      _ExtentY        =   11827
      View            =   3
      MultiSelect     =   -1  'True
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      OLEDragMode     =   1
      FlatScrollBar   =   -1  'True
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      HotTracking     =   -1  'True
      HoverSelection  =   -1  'True
      _Version        =   393217
      ForeColor       =   0
      BackColor       =   16777215
      BorderStyle     =   1
      Appearance      =   1
      OLEDragMode     =   1
      NumItems        =   0
   End
   Begin MSComCtl2.Animation Animation1 
      Height          =   525
      Left            =   360
      TabIndex        =   20
      Top             =   240
      Width           =   735
      _ExtentX        =   1296
      _ExtentY        =   926
      _Version        =   393216
      BackColor       =   -2147483644
      FullWidth       =   49
      FullHeight      =   35
   End
   Begin VB.Label lblrowcount 
      BackColor       =   &H80000002&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   11280
      TabIndex        =   22
      Top             =   2760
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.Label Label6 
      Caption         =   "Outstanding Reversal items"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   4560
      TabIndex        =   21
      Top             =   240
      Width           =   4695
   End
End
Attribute VB_Name = "FrmRevlOutstandView"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


'**********************************************
'Form name              :FrmRevlOutstandView
'Form Description       :To track outstanding reversal data
'Creation date          :27/06/2011
'Design & Developed by  :Dewan Ahsanullah
'**********************************************

'--**0=not authorized
'--**1=Authorize

'*****Show all outstandig reversal data which does not have any collection schedule

Private Sub LoadListView(LV As ListView, sql As String)

    ListView1.HotTracking = False
'    ListView1.Sorted = False
     ListView1.SortKey = False
     ListView1.LabelEdit = lvwManual
     ListView1.View = lvwReport
'    ListView1.CheckBoxes = False
     ListView1.FlatScrollBar = False
    ListView1.TabStop = False
 
      ' Clear the contents of the ListView control.
    LV.ListItems.Clear
    LV.ColumnHeaders.Clear
  LV.ColumnHeaders.Add , , " deposit code", 1000, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Deposit Schedule ", 1000, lvwColumnLeft
  LV.ColumnHeaders.Add , , " ReversalDate", 1100, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Cash Amount", 1300, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Check Amount", 1300, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Deposit date", 1300, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Deposit Type", 1000, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Status", 1000, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Remarks", 1000, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Client Name", 3000, lvwColumnLeft
  LV.ColumnHeaders.Add , , " statusid", 0, lvwColumnLeft
  LV.ColumnHeaders.Add , , " Authorize", 1000, lvwColumnLeft
  
  '  LV.ColumnHeaders.Add , , " Client Name", 3000, lvwColumnLeft
  'LV.ColumnHeaders.Add , , " Credit Type", 150, lvwColumnLeft
  
  LV.Appearance = cc3D
  
  LV.SortOrder = lvwAscending
  LV.View = lvwReport
  LV.FlatScrollBar = False
  LV.Sorted = False
  Set rs = Nothing
  
  Set rs = ocon.GetResultset(sql)
  lblrowcount.Visible = True
  lblrowcount = "Total rows: " + CStr(rs.RecordCount)
    If Not (rs.BOF And rs.EOF) Then
      Do Until rs.EOF
        Set Li = LV.ListItems.Add(, , rs!d_code)
        Li.ListSubItems.Add , , IIf(IsNull(rs!ds_code) = True, "NULL", rs!ds_code)
        Li.ListSubItems.Add , , rs!revdate
        Li.ListSubItems.Add , , IIf(IsNull(rs!citicash_amount) = True, 0, rs!citicash_amount)
        Li.ListSubItems.Add , , IIf(IsNull(rs!citicheck_amount) = True, 0, rs!citicheck_amount)
        Li.ListSubItems.Add , , rs!Valuedate
        Li.ListSubItems.Add , , rs!Deposit_Type
        Li.ListSubItems.Add , , IIf(IsNull(rs!StatusName) = True, "", rs!StatusName)
        Li.ListSubItems.Add , , IIf(IsNull(rs!Remarks) = True, "", rs!Remarks)
        Li.ListSubItems.Add , , IIf(IsNull(rs!Acc_Name) = True, "", rs!Acc_Name)
        Li.ListSubItems.Add , , IIf(IsNull(rs!statusid) = True, "", rs!statusid)
       If rs!authorize = 0 Then
         Li.ListSubItems.Add , , "NO"
       ElseIf rs!authorize = 1 Then
         Li.ListSubItems.Add , , "YES"
       End If
        
        
       ' Li.ListSubItems.Add , , rs!crtyp
        
        
        
        rs.MoveNext
        ', , rs!refno
        
      Loop
    End If
End Sub

Private Sub cmblcode_Change()

End Sub

Private Sub cmdAuthorize_Click()
Dim i As Integer
Dim sql As String
'Login_User = "Leadsc"
sql = "select a.ds_code,a.d_code,b.revdate,b.remarks,b.statusid ,b.Authorize ,b.Authorizer_id from dschedule a,ibbsreftab b " & _
      " where a.d_code=b.d_code and a.ds_code='" & Trim(txtDscode.Text) & "' and a.deposit_type='" & Trim(txtdeposittype.Text) & "' and b.userid <> '" & Login_User & "' and b.revdate <='" & Format(DTPicker1, "mm/dd/yyyy") & "'"

Set rs = ocon.GetResultset(sql)

If (rs.BOF And rs.EOF) Then
 
 MsgBox ("Maker and Authorizer id can not be same"), vbOKOnly
  Exit Sub
End If
 
For i = 0 To rs.RecordCount - 1
    
    rs!authorize = 1
    rs!Authorizer_id = Trim(Login_User)
    rs.Update
    
    rs.MoveNext
oData.UpdateSystemLog ("" & cmbStatus1.Text & " User: " & Login_User & " ")
Next
MsgBox " Transaction has been authorized ", vbOKOnly
Search
End Sub

Private Sub cmdClose_Click()
Unload Me
End Sub

Private Sub cmdRefresh_Click()
txtDscode.Text = ""
txtRemarks.Text = ""
cmbStatus1.Text = ""
lblrowcount.Visible = False
txtdeposittype.Text = ""
  
End Sub

Private Sub cmdSave_Click()
Dim i As Integer
Dim sql As String

sql = "select a.ds_code,a.d_code,b.revdate,b.UserId,b.remarks,b.Authorize ,b.statusid from dschedule a,ibbsreftab b " & _
      " where a.d_code=b.d_code and a.ds_code='" & Trim(txtDscode.Text) & "' and a.deposit_type='" & Trim(txtdeposittype.Text) & "' and b.revdate <='" & Format(DTPicker1, "mm/dd/yyyy") & "'"

Set rs = ocon.GetResultset(sql)
 
For i = 0 To rs.RecordCount - 1
    
    rs!statusid = Left(cmbStatus1.Text, 1)
    rs!Remarks = txtRemarks.Text
    rs!UserId = Trim(Login_User)
    rs!authorize = 0
    rs.Update
    
    rs.MoveNext
oData.UpdateSystemLog ("" & cmbStatus1.Text & " User: " & Login_User & " ")
Next
MsgBox " Data Saved successfuly ", vbOKOnly
''**********
'Load value
''**********
cmdRefresh_Click
Search



End Sub

Private Sub CmdSearch_Click()

Search
'ListViewAdjustColumnWidth ListView1, True
End Sub


Private Sub Search()

On Error GoTo err:
PlayAvi
Dim sql As String
sql = ""
If Left(cmbstatus2.Text, 1) = 1 Then

sql = " select * from ( select c.cashcrtyp,a.refno,a.valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No," & _
" b.client_code,b.citicash_amount,b.citicheck_amount,b.deposit_type,a.d_code ,a.statusid,a.remarks ,b.ds_code ,c.Acc_Name,d.StatusName,a.Authorize " & _
" from ibbsreftab a  left outer join transtatus d on  a.statusid=d.statusid  ,dschedule b,client c  " & _
" Where " & _
" A.d_code = B.d_code " & _
" and b.client_code=c.client_code+sub_client " & _
"and a.filename is null " & _
"and b.ds_code not in " & _
"(select ds_code from cschedule) and revdate <='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
" and a.statusid='" & Left(cmbstatus2.Text, 1) & "' ) a where a.valuedate <> a.revdate order by a.ds_code,a.revdate,a.acc_name asc  "




Else

sql = "  select * from (select c.cashcrtyp,a.refno,a.valueDate,b.location_code,a.RevDate,a.Acc_No,a.RefAcc_No," & _
" b.client_code,b.citicash_amount,b.citicheck_amount,b.deposit_type,a.d_code ,a.statusid,a.remarks ,b.ds_code ,c.Acc_Name,d.StatusName,a.Authorize " & _
" from ibbsreftab a  left outer join transtatus d on  a.statusid=d.statusid  ,dschedule b,client c  " & _
" Where " & _
" A.d_code = B.d_code " & _
" and b.client_code=c.client_code+sub_client " & _
"and a.filename is null " & _
"and b.ds_code not in " & _
"(select ds_code from cschedule) and revdate <='" & Format(DTPicker1, "mm/dd/yyyy") & "'" & _
" and (a.statusid is null or a.statusid='" & Left(cmbstatus2.Text, 1) & "'))a where a.valuedate <> a.revdate order by a.ds_code,a.revdate,a.acc_name asc  "


End If

LoadListView ListView1, sql
StopAvi
lblindication.Visible = False

Exit Sub
err:
MsgBox (err.Description), vbOKOnly

End Sub


Private Sub Form_Load()
DTPicker1.Value = Date
loadcombo
sql = "select * from users where USER_ID ='" & Login_User & "' and author='-1'"

Set rs = ocon.GetResultset(sql)
If Not (rs.BOF And rs.EOF) Then
 cmdAuthorize.Enabled = True
Else
 cmdAuthorize.Enabled = False
End If



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
    ListView1.Sorted = False

End Sub
Private Sub ListViewAdjustColumnWidth(LV As ListView,  Optional AccountForHeaders As Boolean)
    Dim row As Long, col As Long
    Dim width As Single, maxWidth As Single
    Dim saveFont As StdFont, saveScaleMode As Integer, cellText As String
    ' Exit if there aren't any items.
    If LV.ListItems.count = 0 Then Exit Sub

    ' Save the font used by the parent form, and enforce ListView's
    ' font. (We need this in order to use the form's TextWidth
    ' method.)
    saveFont = LV.Parent.Font
    LV.Parent.Font = LV.Font
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
    LV.Parent.Font = saveFont
    LV.Parent.ScaleMode = saveScaleMode
End Sub
Private Sub ListView1_Click()
    Dim i As Integer
    
      For i = 1 To ListView1.ListItems.count
        If ListView1.ListItems(i).Selected = True Then
          '  txt = ListView1.ListItems.Item(i)
            txtDscode.Text = ListView1.ListItems.Item(i).SubItems(1)
            txtRemarks.Text = ListView1.ListItems.Item(i).SubItems(8)
            If ListView1.ListItems.Item(i).SubItems(10) = "" Then
              cmbStatus1.Text = ""
            Else
              cmbStatus1.Text = ListView1.ListItems.Item(i).SubItems(10) + "-" + ListView1.ListItems.Item(i).SubItems(7)
            End If
            txtdeposittype.Text = ListView1.ListItems.Item(i).SubItems(6)
            
            'TxtAmount.Text = ListView1.ListItems.Item(i).SubItems(5)
            '// Now check if this is an A/C payee Cheque or not
           
            ItemSelected = i
            '// No need to check anymore, we have our selection and we are done with it so...
            Exit Sub
        End If
    Next
End Sub

Private Sub loadcombo()
cmbStatus1.Clear
cmbstatus2.Clear

Dim sql As String
sql = "select statusid,statusname from transtatus"
Set rs = ocon.GetResultset(sql)

Do Until rs.EOF = True
    cmbStatus1.AddItem Trim(rs!statusid) + "-" + Trim(rs!StatusName)
    cmbstatus2.AddItem Trim(rs!statusid) + "-" + Trim(rs!StatusName)
    rs.MoveNext
Loop
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
