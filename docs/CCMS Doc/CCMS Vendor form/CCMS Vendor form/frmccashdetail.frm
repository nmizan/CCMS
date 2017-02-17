VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "MSMASK32.OCX"
Begin VB.Form frmccashdetail 
   Caption         =   "CitiCash Detail Information"
   ClientHeight    =   4875
   ClientLeft      =   1755
   ClientTop       =   2025
   ClientWidth     =   7740
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   4875
   ScaleWidth      =   7740
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00C0C0C0&
      Height          =   4095
      Left            =   0
      ScaleHeight     =   4035
      ScaleWidth      =   7500
      TabIndex        =   5
      Top             =   600
      Width           =   7560
      Begin VB.CommandButton bsave 
         Caption         =   "Save"
         Height          =   375
         Left            =   1605
         TabIndex        =   4
         Top             =   3660
         Width           =   930
      End
      Begin VB.CommandButton bcancel 
         Caption         =   "Cancel"
         Height          =   375
         Left            =   2595
         TabIndex        =   25
         Top             =   3660
         Width           =   915
      End
      Begin VB.CommandButton bdelete 
         Caption         =   "Delete"
         Height          =   390
         Left            =   3585
         TabIndex        =   24
         Top             =   3645
         Width           =   885
      End
      Begin VB.CommandButton bquit 
         Caption         =   "Quit"
         CausesValidation=   0   'False
         Height          =   375
         Left            =   4545
         TabIndex        =   23
         Top             =   3645
         Width           =   840
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00C0C0C0&
         Height          =   3420
         Left            =   120
         TabIndex        =   7
         Top             =   120
         Width           =   7275
         Begin VB.TextBox txtCashref 
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   285
            Left            =   1680
            MaxLength       =   10
            TabIndex        =   2
            Top             =   3000
            Width           =   1710
         End
         Begin VB.TextBox txtcusref 
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00FF0000&
            Height          =   285
            Left            =   5040
            MaxLength       =   10
            TabIndex        =   3
            Top             =   3000
            Width           =   1710
         End
         Begin VB.TextBox txtdcode 
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1695
            MaxLength       =   7
            TabIndex        =   0
            Top             =   195
            Width           =   1215
         End
         Begin MSMask.MaskEdBox msdate 
            Height          =   315
            Left            =   1680
            TabIndex        =   1
            Top             =   2640
            Width           =   1455
            _ExtentX        =   2566
            _ExtentY        =   556
            _Version        =   393216
            ForeColor       =   12582912
            MaxLength       =   10
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Format          =   "dd/mm/yyyy"
            Mask            =   "##/##/####"
            PromptChar      =   "_"
         End
         Begin VB.Label Label2 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Customer Ref"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Left            =   3480
            TabIndex        =   26
            Top             =   3000
            Width           =   1455
         End
         Begin VB.Label Label7 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Slip_Date"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Left            =   120
            TabIndex        =   22
            Top             =   2640
            Width           =   1440
         End
         Begin VB.Label Label14 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Cash Ref"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Left            =   120
            TabIndex        =   21
            Top             =   3000
            Width           =   1455
         End
         Begin VB.Label lbltotalcash 
            BorderStyle     =   1  'Fixed Single
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   285
            Left            =   1680
            TabIndex        =   20
            Top             =   2280
            Width           =   2175
         End
         Begin VB.Label Label4 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "DS Code"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   315
            Left            =   90
            TabIndex        =   19
            Top             =   540
            Width           =   1515
         End
         Begin VB.Label lbldscode 
            BorderStyle     =   1  'Fixed Single
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1680
            TabIndex        =   18
            Top             =   540
            Width           =   1635
         End
         Begin VB.Label Label5 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Deposit Code"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   315
            Left            =   105
            TabIndex        =   17
            Top             =   165
            Width           =   1515
         End
         Begin VB.Label Label12 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Schedule Date"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   315
            Left            =   90
            TabIndex        =   16
            Top             =   900
            Width           =   1515
         End
         Begin VB.Label Label3 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Corrbank_branch"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   315
            Left            =   105
            TabIndex        =   15
            Top             =   1590
            Width           =   1515
         End
         Begin VB.Label lblbranch 
            BorderStyle     =   1  'Fixed Single
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1665
            TabIndex        =   14
            Top             =   1605
            Width           =   5505
         End
         Begin VB.Label Label6 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Location Code"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   285
            Left            =   105
            TabIndex        =   13
            Top             =   1260
            Width           =   1515
         End
         Begin VB.Label lbllocation 
            BorderStyle     =   1  'Fixed Single
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   300
            Left            =   1665
            TabIndex        =   12
            Top             =   1260
            Width           =   5535
         End
         Begin VB.Label Label16 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "ClientCode & Name"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   315
            Left            =   75
            TabIndex        =   11
            Top             =   1950
            Width           =   1530
         End
         Begin VB.Label lblclient 
            BorderStyle     =   1  'Fixed Single
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1665
            TabIndex        =   10
            Top             =   1935
            Width           =   5520
         End
         Begin VB.Label Label10 
            BorderStyle     =   1  'Fixed Single
            Caption         =   " Amount"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   285
            Left            =   90
            TabIndex        =   9
            Top             =   2310
            Width           =   1530
         End
         Begin VB.Label lblsdate 
            BorderStyle     =   1  'Fixed Single
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1680
            TabIndex        =   8
            Top             =   900
            Width           =   1695
         End
      End
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00E0E0E0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Update CitiCash Deposit Slip"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   495
      Left            =   -120
      TabIndex        =   6
      Top             =   0
      Width           =   7740
   End
End
Attribute VB_Name = "frmccashdetail"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim allshow As New ADODB.Recordset
Dim saveall As New ADODB.Recordset
Dim dscodeadd As New ADODB.Recordset
Dim checkamount As New ADODB.Recordset
Dim oDate As New clsDate


Private Sub bcancel_Click()
init_item1
End Sub

Private Sub bdelete_Click()
kk = MsgBox("Are you sure you want to Delete?", vbQuestion + vbYesNo)
    If kk = vbNo Then
        Exit Sub
    End If
    
    oconn.Connection.Execute "delete from ccash where d_code='" & Trim(txtdcode.Text) & "'"
    init_item1
 
End Sub

Private Sub bquit_Click()
kk = MsgBox("Are you sure you want to exit?", vbYesNo + vbQuestion)
If kk = vbNo Then
    Exit Sub
Else
    Unload Me
End If
End Sub

Private Sub bsave_Click()
'*****************check for customer ref no
     Set rs = ocon.GetResultset("select  b.client_code+b.sub_client,b.cashcrtyp " & _
     " from dschedule a,client b Where B.client_code + B.sub_client = A.client_code " & _
     "  and  d_code='" & (txtdcode.Text) & "' and b.cashcrtyp='R' ")
     If Not rs.BOF And rs.EOF Then
        If Trim(TxtCusRef.Text) = "" Then
          MsgBox "This client customer refno can not be blank", vbOKOnly
          Exit Sub
        End If
        
     End If
     
'********************************************************
     
saveall.Open ("select * from ccash where d_code='" & (txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If saveall.RecordCount = 0 Then
    saveall.AddNew
    saveall!d_code = Trim(txtdcode.Text)
    saveall!slip_date = Format(msdate.Text, "dd/mm/yyyy")
    saveall!customer_ref = Trim(TxtCusRef.Text)
    saveall!cashref = Trim(txtCashref.Text)
'**********new add entry_date***********22-02-2000******
    saveall!Entry_date = Format(Date, "dd/mm/yyyy")
    
    saveall.Update
End If
If saveall.RecordCount > 0 Then
   ' oconn.Connection.Execute "update ccash set slip_date ='" & Format((msdate.Text), "mm/dd/yyyy") & "',customer_ref='" & Trim(TxtCusRef.Text) & "',entry_date='" & Format(Date, "mm/dd/yyyy") & "',cashref ='" & Trim(txtCashref.Text) & "' where d_code='" & Trim(txtdcode.Text) & "'"
   oconn.Connection.Execute "update ccash set slip_date ='" & Format((msdate.Text), "yyyy/mm/dd") & "',customer_ref='" & Trim(TxtCusRef.Text) & "',entry_date='" & Format(Date, "mm/dd/yyyy") & "',cashref ='" & Trim(txtCashref.Text) & "' where d_code='" & Trim(txtdcode.Text) & "'"
End If
saveall.Close
txtdcode.Text = ""
TxtCusRef.Text = ""
msdate.Text = "__/__/____"
lbldscode.Caption = ""
lblsdate.Caption = ""
lbllocation.Caption = ""
lblbranch.Caption = ""
lblClient.Caption = ""
lbltotalcash.Caption = ""
txtCashref = ""
txtdcode.SetFocus
bsave.Enabled = False
bquit.Enabled = True
bcancel.Enabled = False
bdelete.Enabled = False
End Sub



Private Sub Command3_Click()

End Sub

Private Sub Form_Load()
'Move (MDIForm1.Height - Height) / 2, (MDIForm1.Width - Width) / 2
Move (Screen.Height - Height) / 2, (Screen.width - width) / 2
'edate.Text = Format(Date, "dd/mm/yyyy")
msdate.Text = "__/__/____"
bsave.Enabled = False
bquit.Enabled = True
bcancel.Enabled = False
bdelete.Enabled = False

End Sub

Private Sub MaskEdBox1_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub MaskEdBox2_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub medate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub msdate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub TxtAmount_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtamount_Validate(Cancel As Boolean)

checkamount.Open ("select citicash_amount from dschedule where ds_code='" & lbldscode.Caption & "' and d_code='" & Trim(txtdcode.Text) & "' and citicash_amount=" & Val(TxtAmount.Text) & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
If checkamount.RecordCount = 0 Then
    MsgBox "Mismatch in Amount"
    checkamount.Close
    Exit Sub
End If
checkamount.Close
End Sub

Private Sub msdate_Validate(Cancel As Boolean)
   If oDate.Validate(msdate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        Cancel = True
        Exit Sub
     End If
End Sub





Private Sub txtCashref_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtcusref_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtdcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"

End Sub

Private Sub txtdcode_Validate(Cancel As Boolean)
If Trim(txtdcode.Text) = "" Then
    MsgBox "Invalid DepositCode"
    Cancel = True
End If
If Len(txtdcode.Text) < 7 Then
    MsgBox "Must enter 7 digits"
    txtdcode.Text = ""
    Cancel = True
    Exit Sub
End If
'allshow.Open ("select a.acc_name,b.bank_name,c.location_name,d.branch_name,e.client_code,e.corr_bcode,e.corr_brcode,e.location_code,e.client_code,e.ds_code,e.schedule_date,e.d_code,e.no_check,e.deposit_type,e.citicash_amount  from client as a,bank as b,location as c,branch as d,dschedule as e where e.d_code='" & Trim(txtdcode.Text) & "' and b.bank_code=e.corr_bcode and c.location_code=e.location_code and d.branch_code=e.corr_brcode and e.deposit_type='Cash'"), oconn.Connection, adOpenKeyset, adLockOptimistic
allshow.Open ("select e.*,a.acc_name,b.bank_name,c.location_name,d.branch_name  from client as a,bank as b,location as c,branch as d,dschedule as e where e.d_code='" & Trim(txtdcode.Text) & "' and e.client_code=(a.client_code)+(a.sub_client) and e.corr_bcode=b.bank_code and e.location_code=c.location_code  and e.corr_brcode=d.branch_code and e.deposit_type='Cash'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If allshow.RecordCount > 0 Then
   lbldscode = Trim(allshow!ds_code)
    lblClient = Trim(allshow!client_code) + Space(2) + ":" + Space(2) + Trim(allshow!Acc_Name)
    lbllocation = Trim(allshow!location_code) + Space(2) + ":" + Space(2) + Trim(allshow!location_name)
    lblbranch = Trim(allshow!Corr_BCode) + Trim(allshow!Corr_BrCode) + Space(2) + ":" + Space(2) + Trim(allshow!Bank_name) + Space(2) + ":" + Space(2) + Trim(allshow!Branch_name)
    'txtCashref.Text = allshow!cashref
    lblsdate = Format(allshow!Schedule_date, "dd/mm/yyyy")
    msdate.Text = Format(allshow!Schedule_date, "dd/mm/yyyy")
    lblnochk = Trim(allshow!No_check)
    lbltotalcash.Caption = Format(allshow!citicash_amount, "#,##,##,##,##0.00")
    
ElseIf allshow.RecordCount = 0 Then
     MsgBox "Invalid DepositCode"
     init_item1
     Cancel = True
     allshow.Close
     Exit Sub
End If
allshow.Close
dscodeadd.Open ("select * from ccash where d_code='" & Trim(txtdcode.Text) & "' order by d_code"), oconn.Connection, adOpenKeyset, adLockPessimistic
If dscodeadd.RecordCount > 0 Then
    msg = "Duplicate Data,Want to Delete?"
    style = vbInformation + vbDefaultButton2 + vbYesNo
    title = "Duplicate Data"
    response = MsgBox(msg, style, title)
    If response = vbYes Then
        bsave.Enabled = False
        bcancel.Enabled = True
        bquit.Enabled = False
        'bedit.Enabled = True
        bdelete.Enabled = True
        'editdata = True
        'chkdtype.Value = 0
         msdate = Format(dscodeadd!slip_date, "dd/mm/yyyy") & ""
         TxtCusRef = Trim(dscodeadd!customer_ref) & ""
         txtCashref.Text = Trim(dscodeadd!cashref)
         
         ElseIf response = vbNo Then
            txtdcode.Text = ""
            init_item1
            bsave.Enabled = False
            bcancel.Enabled = False
            bquit.Enabled = True
            'bedit.Enabled = False
            bdelete.Enabled = False
            Cancel = True
            dscodeadd.Close
            Exit Sub
   
        End If

Else
       
        bsave.Enabled = True
        bcancel.Enabled = True
        bquit.Enabled = False
       ' bedit.Enabled = False
        bdelete.Enabled = False
        TxtCusRef.SetFocus
End If

dscodeadd.Close



End Sub

Public Sub init_item1()
txtdcode.Text = ""
msdate.Text = "__/__/____"
TxtCusRef.Text = ""
lbldscode.Caption = ""
lblClient.Caption = ""
lblsdate.Caption = "__/__/____"
lbllocation.Caption = ""
lbltotalcash.Caption = ""
lblbranch.Caption = ""
txtCashref = ""
bsave.Enabled = False
bquit.Enabled = True
bcancel.Enabled = False
bdelete.Enabled = False
txtdcode.SetFocus
End Sub
