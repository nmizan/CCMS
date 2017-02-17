VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "msmask32.ocx"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "msflxgrd.ocx"
Begin VB.Form frmcspeeddetail 
   BackColor       =   &H00C0C0C0&
   Caption         =   " "
   ClientHeight    =   7995
   ClientLeft      =   60
   ClientTop       =   1350
   ClientWidth     =   11085
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   Moveable        =   0   'False
   ScaleHeight     =   7995
   ScaleWidth      =   11085
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00C0C0C0&
      Height          =   7425
      Left            =   0
      ScaleHeight     =   7365
      ScaleWidth      =   10950
      TabIndex        =   14
      Top             =   480
      Width           =   11010
      Begin VB.CommandButton bsave 
         Caption         =   "Ok"
         Height          =   255
         Left            =   10080
         TabIndex        =   47
         Top             =   2520
         Width           =   690
      End
      Begin VB.CommandButton bcancel 
         Caption         =   "Cancel"
         Height          =   255
         Left            =   10080
         TabIndex        =   46
         Top             =   2880
         Width           =   690
      End
      Begin VB.CommandButton bdelete 
         Caption         =   "Delete"
         Height          =   255
         Left            =   10080
         TabIndex        =   45
         Top             =   3240
         Width           =   690
      End
      Begin VB.CommandButton bquit 
         Caption         =   "Quit"
         CausesValidation=   0   'False
         Height          =   255
         Left            =   10080
         TabIndex        =   44
         Top             =   3600
         Width           =   690
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00C0C0C0&
         Height          =   1890
         Left            =   0
         TabIndex        =   30
         Top             =   2280
         Width           =   9960
         Begin VB.TextBox TxtcheckRef1 
            ForeColor       =   &H00C00000&
            Height          =   285
            Left            =   4800
            MaxLength       =   3
            TabIndex        =   5
            Top             =   480
            Width           =   495
         End
         Begin VB.TextBox TxtcheckRef 
            ForeColor       =   &H00C00000&
            Height          =   285
            Left            =   3840
            MaxLength       =   7
            TabIndex        =   4
            Top             =   480
            Width           =   975
         End
         Begin MSMask.MaskEdBox chkdate 
            Height          =   315
            Left            =   6240
            TabIndex        =   6
            Top             =   480
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
         Begin VB.TextBox txtbranch 
            Height          =   285
            Left            =   1200
            MaxLength       =   35
            TabIndex        =   9
            Top             =   1200
            Width           =   3255
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
            Left            =   3840
            MaxLength       =   12
            TabIndex        =   2
            Top             =   120
            Width           =   1455
         End
         Begin MSMask.MaskEdBox medate 
            Height          =   285
            Left            =   6240
            TabIndex        =   11
            Top             =   120
            Width           =   1440
            _ExtentX        =   2540
            _ExtentY        =   503
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
         Begin VB.ComboBox cmbdrawee 
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1200
            TabIndex        =   8
            Top             =   840
            Width           =   3615
         End
         Begin VB.TextBox txtamount 
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
            Left            =   1200
            TabIndex        =   10
            Top             =   1560
            Width           =   2535
         End
         Begin VB.TextBox txtdrawer 
            ForeColor       =   &H00C00000&
            Height          =   330
            Left            =   6240
            MaxLength       =   35
            TabIndex        =   7
            Top             =   840
            Width           =   3555
         End
         Begin VB.TextBox txtchno 
            ForeColor       =   &H00C00000&
            Height          =   285
            Left            =   1200
            MaxLength       =   15
            TabIndex        =   3
            Top             =   480
            Width           =   1470
         End
         Begin MSMask.MaskEdBox msdate 
            Height          =   315
            Left            =   1200
            TabIndex        =   1
            Top             =   120
            Width           =   1335
            _ExtentX        =   2355
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
         Begin VB.Label Label20 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CheckRefNo"
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
            Left            =   2760
            TabIndex        =   48
            Top             =   480
            Width           =   1050
         End
         Begin VB.Label Label18 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "ChkDate"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   255
            Left            =   5370
            TabIndex        =   43
            Top             =   480
            Width           =   855
         End
         Begin VB.Label Label17 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Dr_Branch"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   255
            Left            =   120
            TabIndex        =   42
            Top             =   1200
            Width           =   1095
         End
         Begin VB.Label Label14 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CusRef"
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
            Left            =   2760
            TabIndex        =   41
            Top             =   120
            Width           =   1095
         End
         Begin VB.Label lblslno 
            Height          =   240
            Left            =   2760
            TabIndex        =   40
            Top             =   210
            Visible         =   0   'False
            Width           =   840
         End
         Begin VB.Label lblbname 
            Height          =   345
            Left            =   2880
            TabIndex        =   39
            Top             =   240
            Visible         =   0   'False
            Width           =   1080
         End
         Begin VB.Label Label15 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Amount"
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
            Height          =   270
            Left            =   120
            TabIndex        =   37
            Top             =   1560
            Width           =   1050
         End
         Begin VB.Label Label9 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Dr_ Bank"
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
            Left            =   120
            TabIndex        =   36
            Top             =   840
            Width           =   1065
         End
         Begin VB.Label Label8 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Drawer"
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
            Height          =   255
            Left            =   5415
            TabIndex        =   35
            Top             =   840
            Width           =   810
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
            TabIndex        =   34
            Top             =   120
            Width           =   1050
         End
         Begin VB.Label Label2 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Check_No"
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
            Left            =   120
            TabIndex        =   33
            Top             =   480
            Width           =   1050
         End
         Begin VB.Label Label11 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Entry Date"
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
            Height          =   270
            Left            =   5280
            TabIndex        =   32
            Top             =   120
            Width           =   945
         End
         Begin VB.Label Label19 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Client Name"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   375
            Left            =   -1350
            TabIndex        =   31
            Top             =   780
            Width           =   1215
         End
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00C0C0C0&
         Height          =   2025
         Left            =   120
         TabIndex        =   16
         Top             =   120
         Width           =   10875
         Begin VB.TextBox txttotal 
            Enabled         =   0   'False
            Height          =   285
            Left            =   8520
            TabIndex        =   13
            Top             =   1500
            Width           =   2235
         End
         Begin VB.TextBox txttotalchkno 
            Enabled         =   0   'False
            Height          =   285
            Left            =   8520
            TabIndex        =   12
            Top             =   1200
            Width           =   915
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
            Left            =   1680
            MaxLength       =   7
            TabIndex        =   0
            Top             =   180
            Width           =   975
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
            TabIndex        =   38
            Top             =   885
            Width           =   1695
         End
         Begin VB.Label Label13 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "No of Checks"
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
            Left            =   7320
            TabIndex        =   28
            Top             =   1200
            Width           =   1170
         End
         Begin VB.Label Label10 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Total Amount"
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
            Left            =   7305
            TabIndex        =   27
            Top             =   1500
            Width           =   1170
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
            Height          =   465
            Left            =   6270
            TabIndex        =   26
            Top             =   195
            Width           =   4545
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
            Left            =   4710
            TabIndex        =   25
            Top             =   210
            Width           =   1530
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
            TabIndex        =   24
            Top             =   1245
            Width           =   3855
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
            TabIndex        =   23
            Top             =   1245
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
            TabIndex        =   22
            Top             =   1590
            Width           =   4845
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
            TabIndex        =   21
            Top             =   1575
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
            TabIndex        =   20
            Top             =   885
            Width           =   1515
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
            TabIndex        =   19
            Top             =   165
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
            Left            =   1665
            TabIndex        =   18
            Top             =   525
            Width           =   3075
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
            TabIndex        =   17
            Top             =   525
            Width           =   1515
         End
      End
      Begin MSFlexGridLib.MSFlexGrid citispeed 
         Height          =   3105
         Left            =   120
         TabIndex        =   29
         Top             =   4200
         Width           =   10635
         _ExtentX        =   18759
         _ExtentY        =   5477
         _Version        =   393216
         FixedCols       =   0
         BackColor       =   16777215
      End
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00E0E0E0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Update CitiSpeed Deposit Slip /Details"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   420
      Left            =   0
      TabIndex        =   15
      Top             =   0
      Width           =   11175
   End
End
Attribute VB_Name = "frmcspeeddetail"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim allshow As New ADODB.Recordset
Dim showcheck As New ADODB.Recordset
Dim showcheck1 As New ADODB.Recordset
'Dim showcheck2 As New ADODB.Recordset
Dim saveall As New ADODB.Recordset
Dim bankcodeadd As New ADODB.Recordset
Dim checkamount As New ADODB.Recordset
Dim dssave As New ADODB.Recordset
Dim newslno As New ADODB.Recordset
Dim editchkno As Boolean
Dim appenddata As Boolean
Dim editchkamt As Boolean
Dim deldata As Boolean
Dim dschkamt As Currency
Dim editdata As Boolean
Dim gridClickSlNo As Integer
Dim gridselect As Boolean



Private Sub bcancel_Click()
deldata = False
appenddata = False
Dim Respns As Integer

Respns = MsgBox("Do you want to Clear this information?", vbQuestion + vbYesNo)
           
Select Case Respns
    Case vbYes
        init_item
    Case vbNo
       bcancel.SetFocus
End Select


End Sub

Private Sub bdelete_Click()
'If Not deldata = True Then
'kk = MsgBox("Are you sure you want to Delete?", vbQuestion + vbYesNo)
 '   If kk = vbNo Then
  '      Exit Sub
   ' End If
    
   ' oconn.Connection.Execute "delete from csd where d_code='" & Trim(txtdcode.Text) & "'"
    'init_item
 'End If

If deldata = True Then
kk = MsgBox("Are you sure you want to Delete?", vbDefaultButton3 + vbQuestion + vbYesNo)
    If kk = vbNo Then
        Exit Sub
    End If
    
    oconn.Connection.Execute "delete from csd where d_code='" & Trim(txtdcode.Text) & "' and slno=" & lblslno.Caption & ""
    dssave.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
    cleargrid
    txtchno.Text = ""
    msdate.Text = "__/__/____"
    txtdrawer.Text = ""
    cmbdrawee.Clear
    TxtCusRef.Text = ""
    TxtAmount.Text = ""
    Do While Not dssave.EOF
    With citispeed
    
                .Rows = .Rows + 1
                .row = .Rows - 1
                .col = 0: .Text = dssave!slno
                .col = 1: .Text = Trim(dssave!check_no) & ""
                .col = 2: .Text = Trim(dssave!Drawer) & ""
                .col = 3: .Text = Trim(dssave!draweebank_code) & ""
                .col = 4: .Text = Trim(dssave!drawee_branch) & ""
                .col = 5: .Text = Trim(dssave!check_date) & ""
                .col = 6: .Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
                .col = 11: .Text = Trim(dssave!CheckRef) & ""
                
            End With
        dssave.MoveNext
        Loop
        dssave.Close
        ElseIf dssave.RecordCount = 0 Then
            cleargrid
            init_item
        End If
Else
MsgBox ("You are in append mode"), vbOKCancel
End If
'deldata = False
   
End Sub

Private Sub bquit_Click()
kk = MsgBox("Are you sure you want to exit?", vbDefaultButton3 + vbYesNo + vbQuestion)
If kk = vbNo Then
    Exit Sub
Else
    Unload Me
End If

End Sub

Private Sub bsave_Click()
'' New checkref is added for Novertis,This check no will use as a unique
'' reference of checkno.

Dim I As Integer

Dim MCOUNT As String
Dim mGridTotal As Currency
Dim temp As String
'====================================
  '\ To count records sum of amount
'====================================
mGridTotal = 0#
    For I = 1 To citispeed.Rows - 1
        mGridTotal = mGridTotal + Format(citispeed.TextMatrix(I, 6), "#,##,##,##,##0.00")
    Next
        MCOUNT = citispeed.Rows - 1
    If MCOUNT = 0 Then
        Exit Sub
    End If
 ''************************----------********************
mGridTotal = Format(mGridTotal, "#,##,##,##,##0.00")
    If mGridTotal <> txttotal Then
        temp = txttotal - mGridTotal
        MsgBox "Total Amount " & temp & " is Mismatch  ", vbOKOnly, "CCMS"
          
       ' Exit Sub
    End If
    '\\\\\To check no of checks
    If MCOUNT <> txttotalchkno Then
      MsgBox "No of checks is incorrect", vbOKOnly
     ' txttotalchkno.SetFocus
     ' Exit Sub
    End If
    
        Set rs = Nothing
        Set rs = ocon.GetResultset("delete from  csd where d_code='" & Trim(txtdcode.Text) & "'")
I = 0
        Set rs = Nothing
        Set rs = ocon.GetResultset("select * from csd where d_code='" & Trim(txtdcode.Text) & "'")
    'saveall.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    
      If (rs.BOF And rs.EOF) Then
           
       With rs
         For I = 1 To citispeed.Rows - 1
            .AddNew
            rs!d_code = Trim(txtdcode.Text) 'citispeed.TextMatrix(i, 9) 'Trim(txtdcode.Text)
            !slno = citispeed.TextMatrix(I, 0) 'xx
            !check_no = citispeed.TextMatrix(I, 1) 'Trim(txtchno.Text)
            !slip_date = IIf(citispeed.TextMatrix(I, 7) = "", Format(lblsdate, "dd/mm/yyyy"), citispeed.TextMatrix(I, 7))
            !Drawer = citispeed.TextMatrix(I, 2) 'Trim(txtdrawer)
            !draweebank_code = citispeed.TextMatrix(I, 3) 'Left(cmbdrawee.Text, 3)
            !Entry_date = Format(Date, "dd/mm/yyyy")
            !customer_ref = Trim(citispeed.TextMatrix(I, 10)) 'Trim(TxtCusRef.Text)
            If citispeed.TextMatrix(I, 5) <> "" Then
            
            !check_date = citispeed.TextMatrix(I, 5) 'Format(chkdate.Text, "dd/mm/yyyy")
            End If
                 
            !drawee_branch = Trim(citispeed.TextMatrix(I, 4)) 'Trim(txtbranch.Text)
            !Amount = Format(citispeed.TextMatrix(I, 6), "#,##,##,##,##0.00") 'citispeed.TextMatrix(i, 5) Val(citispeed.TextMatrix(i, 6)) 'Val(TxtAmount)
            !CheckRef = citispeed.TextMatrix(I, 11)
            .Update
            Next I
        End With
       
Else
    With rs
         For I = 1 To citispeed.Rows - 1
            .AddNew
            rs!d_code = Trim(txtdcode.Text) 'citispeed.TextMatrix(i, 9) 'Trim(txtdcode.Text)
            !slno = citispeed.TextMatrix(I, 0) 'xx
            !check_no = citispeed.TextMatrix(I, 1) 'Trim(txtchno.Text)
            !slip_date = IIf(citispeed.TextMatrix(I, 7) = "", Format(lblsdate, "dd/mm/yyyy"), citispeed.TextMatrix(I, 7))
            !Drawer = citispeed.TextMatrix(I, 2) 'Trim(txtdrawer)
            !draweebank_code = citispeed.TextMatrix(I, 3) 'Left(cmbdrawee.Text, 3)
            !Entry_date = Format(Date, "dd/mm/yyyy")
            !customer_ref = citispeed.TextMatrix(I, 10) 'Trim(TxtCusRef.Text)
             If citispeed.TextMatrix(I, 5) <> "" Then
            !check_date = citispeed.TextMatrix(I, 5) 'Format(chkdate.Text, "dd/mm/yyyy")
            End If
            !drawee_branch = Trim(citispeed.TextMatrix(I, 4)) 'Trim(txtbranch.Text)
            !Amount = Format(citispeed.TextMatrix(I, 6), "#,##,##,##,##0.00")  'Val(TxtAmount)
            !CheckRef = citispeed.TextMatrix(I, 11)
            .Update
            Next I
        End With
       
 End If

'\\\\

Dim chkcount As Currency
If citispeed.Rows = 0 Then
    MsgBox "You did not enter any record !", vbCritical
    Exit Sub
End If
If Not deldata Or appenddata Then
    checkamount.Open ("select sum(amount)as tchkamt from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If checkamount.RecordCount > 0 Then
        If checkamount!tchkamt <> dschkamt Then
         chkcount = checkamount!tchkamt - dschkamt
            MsgBox "Mismatch in TotalCheck amount:   " & Format(chkcount, "#,##,##,##,##0.00")
        End If
    End If
    checkamount.Close

    
    
    showcheck.Open ("select count(check_no)as countchkno from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    'Dim i As Integer
    I = Val(txttotalchkno.Text)
    If showcheck!countchkno <> I Then
        MsgBox "Mismatch in TotalCheckNo"
        bsave.Enabled = False
        bcancel.Enabled = True
        bquit.Enabled = False
        showcheck.Close
        Exit Sub
    End If
    showcheck.Close

End If
init_item
cleargrid

End Sub

Private Sub chkdate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub chkdate_Validate(Cancel As Boolean)
'    If chkdate.Text = "__/__/____" Then
'        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
'     If oDate.Validate(chkdate) = False Then
'        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
End Sub

Private Sub citispeed_Click()
'If deldata = True Then
    bdelete.Enabled = True
    bsave.Enabled = False
    bcancel.Enabled = True
    bquit.Enabled = False
    Dim I As Integer
Dim lbltotal As Currency
Dim A As Integer

A = citispeed.Rows - 1
 If A = 0 Then
   Exit Sub
 Else
 lbltotal = Val(TxtTotAmt)
    If A <= 1 Then
        'startgrid
        mGridTotal = 0
    '
        With citispeed
            '.Col = 0: CboBankFrom = mBankFrom
                  .col = 0: lblslno = .Text
                  gridselect = True
                  .col = 0: gridClickSlNo = .Text
                  .col = 1: txtchno.Text = citispeed.Text
                  .col = 2: txtdrawer = .Text
                  .col = 3:  cmbdrawee.Text = .Text
                  .col = 4: txtbranch = .Text
                  .col = 5:
                 If (.Text = "__/__/____") Or (Trim(.Text) <> "") Then
                     .col = 5: chkdate.Text = Format(.Text, "dd/mm/yyyy")
                    'ElseIf chkdate.Text = "__/__/____" Then
                        '!check_date =
                    End If
                
                 .col = 6: TxtAmount = .Text
                 .col = 10: TxtCusRef.Text = .Text
                 .col = 11: TxtCheckRef = Left(.Text, 7)
                 .col = 11: TxtCheckRef1 = Right(.Text, 3)
                 
                 

                 
            End With
           cleargrid
    
    Else  'startgrid
        mGridTotal = 0
    '
        With citispeed
            '.Col = 0: CboBankFrom = mBankFrom
                    .col = 0: lblslno = .Text
                    gridselect = True
                    .col = 0: gridClickSlNo = .Text
                    .col = 1: txtchno.Text = citispeed.Text
                    .col = 2: txtdrawer = .Text
                    .col = 3:  cmbdrawee.Text = .Text
                    .col = 4: txtbranch = .Text
                    .col = 5:
                 If (.Text = "__/__/____") Or (Trim(.Text) <> "") Then
                     .col = 5: chkdate.Text = Format(.Text, "dd/mm/yyyy")
                    End If
                
                .col = 6: TxtAmount = .Text
                .col = 10: TxtCusRef.Text = .Text
                .col = 11: TxtCheckRef = Left(.Text, 7) + Right(.Text, 3)

         .RemoveItem (.row)
         End With
 
'startgrid
End If
End If
'End If
'''\\\\\\\\\\\\\\\\\ To count total check and total amount

   ''\\\\\\\\
            ''// To match no of check
               
              '  Exit Sub
     
'''''    If citispeed.Rows > 1 Then
'''''        With citispeed
'''''        .Col = 0
'''''        '.Col = 0:  lbldcode.Caption = .Text
'''''        dssave.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "' and slno=" & Trim(.Text) & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
'''''        If dssave.RecordCount > 0 Then
'''''            .Col = 0:  lblslno.Caption = .Text
'''''            txtchno.Text = dssave!check_no & ""
'''''            txtdrawer.Text = dssave!drawer & ""
'''''            cmbdrawee.Text = dssave!draweebank_code & ""
'''''            txtbranch.Text = dssave!drawee_branch & ""
'''''            'If (dssave!check_date) <> "" Then
'''''                'chkdate.Text = Format(dssave!check_date, "dd/mm/yyyy")
'''''            'Else
'''''                'chkdate.Text = "__/__/____"
'''''            'End If
'''''
'''''            If IsNull(dssave!check_date) Then
'''''                chkdate.Text = "__/__/____"
'''''
'''''            Else
'''''                chkdate.Text = Format(dssave!check_date, "dd/mm/yyyy")
'''''            End If
'''''            txtamount.Text = dssave!amount & ""
'''''            End If
'''''        dssave.Close
'''''        End With
'''''    End If
'''''End If


''If deldata = True Then
''    bsave.Enabled = True
''    bcancel.Enabled = True
''    bquit.Enabled = False
''    'bdelete.Enabled = True
''    If citispeed.Rows > 1 Then
''
''        With citispeed
''            .Col = 0:  lblslno.Caption = Trim(.Text)
''            .Col = 1:  txtchno.Text = Trim(.Text)
''            .Col = 2:  txtdrawer.Text = Trim(.Text)
''            .Col = 3:  cmbdrawee.Text = Trim(.Text)
''            .Col = 4:  txtbranch.Text = Trim(.Text)
''            If .Col = 5 <>  then
''             'If .Col = 5 <> "__/__/____" Then
''                .Col = 5:  chkdate.Text = Trim(.Text)
''            End If
''            .Col = 6: txtamount.Text = Trim(.Text)
''        End With
''End If
''End If
End Sub

Private Sub cmbdrawee_Change()
lblbname.Caption = cmbdrawee.Text
End Sub

Private Sub cmbdrawee_DropDown()
bankcodeadd.Open ("select distinct bank_code,bank_name from bank where bank_name like '" & lblbname.Caption & "%' order by bank_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
cmbdrawee.Clear
If bankcodeadd.RecordCount > 0 Then
  
    Do While Not bankcodeadd.EOF
        cmbdrawee.AddItem bankcodeadd!bank_code + Space(2) + ":" + Space(2) + bankcodeadd!bank_name
        bankcodeadd.MoveNext
    Loop
End If
bankcodeadd.Close
End Sub

Private Sub cmbdrawee_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub Command1_Click()
'''If Not editdata = True And Not editchkamt = True And Not editchkno = True Then
'''If Trim(txtdcode.Text) = "" Then
'''    MsgBox "Must enter DepositCode"
'''    txtdcode.SetFocus
'''    Exit Sub
'''End If
'''If Trim(txttotalchkno.Text) = "" Then
'''    MsgBox "Must enter TotalCheckNo"
'''    txttotalchkno.SetFocus
'''    Exit Sub
'''End If
'''If Trim(txttotal.Text) = "" Then
'''    MsgBox "Must enter TotalAmount"
'''    txttotal.SetFocus
'''    Exit Sub
'''End If
'''End If
'''If editdata Or editchkamt Then
'''    If Trim(txtchno.Text) = "" Then
'''        MsgBox "Must Enter Check_No"
'''        txtchno.SetFocus
'''        Exit Sub
'''    End If
'''    If Trim(msdate.Text) = "__/__/____" Then
'''        MsgBox "Must enter scheduledate"
'''        msdate.SetFocus
'''        Exit Sub
'''    End If
'''    If Trim(txtdrawer.Text) = "" Then
'''        MsgBox "Must enter drawer"
'''        txtdrawer.SetFocus
'''        Exit Sub
'''    End If
'''    If cmbdrawee.Text = "" Then
'''        MsgBox "Must select draweebank"
'''        cmbdrawee.SetFocus
'''        Exit Sub
'''    End If
'''    If Trim(txtcusref.Text) = "" Then
'''        MsgBox "Must Enter CustomerRef"
'''        txtcusref.SetFocus
'''        Exit Sub
'''    End If
'''    If Trim(medate.Text) = "__/__/____" Then
'''        MsgBox "Must enter entrydate"
'''        medate.SetFocus
'''        Exit Sub
'''    End If
'''    If Trim(txtamount.Text) = "" Then
'''        MsgBox "Must enter Amount"
'''        txtamount.SetFocus
'''        Exit Sub
'''    End If
'''End If
'''
'''Dim intcounter As Integer
'''If Not editdata And Not editchkamt And Not editchkno Then
'''
'''If citispeed.Rows > 1 Then
'''    saveall.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''     If saveall.RecordCount = 0 Then
'''
'''    For intcounter = 1 To citispeed.Rows - 1
'''        With saveall
'''            .AddNew
'''            saveall!D_Code = Trim(txtdcode.Text)
'''            citispeed.Row = intcounter
'''            citispeed.Col = 0
'''            !slno = Trim(citispeed.Text)
'''            citispeed.Col = 1
'''            !check_no = Trim(citispeed.Text)
'''            citispeed.Col = 2
'''            !slip_date = Format(citispeed.Text, "dd/mm/yyyy")
'''            citispeed.Col = 3
'''            !drawer = Trim(citispeed.Text)
'''            citispeed.Col = 4
'''            !draweebank_code = Trim(citispeed.Text)
'''            citispeed.Col = 5
'''            !entry_date = Format(citispeed.Text, "dd/mm/yyyy")
'''            citispeed.Col = 6
'''            !customer_ref = Trim(citispeed.Text)
'''            citispeed.Col = 7
'''            !amount = Val(citispeed.Text)
'''            .Update
'''        End With
'''    Next
'''    saveall.Close
'''End If
'''End If
'''End If
'''bsave.Enabled = False
'''bcancel.Enabled = True
'''bquit.Enabled = False
''''init_item
'''If Not editdata Then
'''If Not editchkamt And Not editchkno Then
'''Dim dd As Integer
'''    dd = Val(txttotal.Text)
'''    checkamount.Open ("select sum(amount)as tchkamt from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    If checkamount!tchkamt <> dd Then
'''            msg = "Mismatch in TotalCheck amount,Want to edit?"
'''            style = vbInformation + vbDefaultButton2 + vbYesNo
'''            title = "Mismatch"
'''            response = MsgBox(msg, style, title)
'''            If response = vbYes Then
'''                editchkamt = True
'''                'editdata = True
'''                checkamount.Close
'''                Exit Sub
'''            ElseIf response = vbNo Then
'''                init_item
'''            End If
'''    End If
'''    checkamount.Close
'''End If
'''End If
'''
'''If editchkamt = True Then
'''editdata = False
''''editchkamt = False
''' oconn.Connection.Execute "update csd set amount = " & Val(txtamount.Text) & " where d_code = '" & Trim(txtdcode.Text) & "' and slno= " & lblslno.Caption & ""
'''cleargrid
'''dssave.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    Do While Not dssave.EOF
'''    With citispeed
'''                .Rows = .Rows + 1
'''                .Row = .Rows - 1
'''                .Col = 0: .Text = dssave!slno
'''                .Col = 1: .Text = Trim(dssave!check_no) & ""
'''                .Col = 2: .Text = Format(dssave!slip_date, "dd/mm/yyyy") & ""
'''                .Col = 3: .Text = dssave!drawer & ""
'''                .Col = 4: .Text = Trim(dssave!draweebank_code) & ""
'''                .Col = 5: .Text = Format(dssave!entry_date, "dd/mm/yyyy") & ""
'''                .Col = 6: .Text = Trim(dssave!customer_ref) & ""
'''                .Col = 7: .Text = Trim(dssave!amount) & ""
'''        End With
'''        dssave.MoveNext
'''    Loop
'''dssave.Close
'''bsave.Enabled = False
'''bcancel.Enabled = True
'''bquit.Enabled = False
'''
'''End If
'''editchkamt = False
'''
'''If Not editdata Then
'''If Not editchkamt And Not editchkno Then
'''
'''    dd = Val(txttotal.Text)
'''    checkamount.Open ("select sum(amount)as tchkamt from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    If checkamount!tchkamt <> dd Then
'''            msg = "Mismatch in TotalCheck amount,Want to edit?"
'''            style = vbInformation + vbDefaultButton2 + vbYesNo
'''            title = "Mismatch"
'''            response = MsgBox(msg, style, title)
'''            If response = vbYes Then
'''
'''                editchkamt = True
'''                editdata = False
'''                checkamount.Close
'''                Exit Sub
'''            ElseIf response = vbNo Then
'''                init_item
'''            End If
'''    End If
'''    checkamount.Close
'''End If
'''End If
'''
'''''If editchkamt = True Then
''''If Not editdata And Not editchkno Then
'''
''' 'oconn.Connection.Execute "update csd set amount = " & Val(txtamount.Text) & " where d_code = '" & Trim(txtdcode.Text) & "' and slno=" & Trim(lblslno.Caption) & ""
''''cleargrid
''''dssave.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''' '   Do While Not dssave.EOF
'''  '  With citispeed
'''   '             .Rows = .Rows + 1
'''    '            .Row = .Rows - 1
'''
'''     '           .Col = 0: .Text = dssave!slno
'''      '          .Col = 1: .Text = Trim(dssave!check_no) & ""
'''       '         .Col = 2: .Text = Format(dssave!slip_date, "dd/mm/yyyy") & ""
'''        '        .Col = 3: .Text = dssave!drawer & ""
'''         '       .Col = 4: .Text = Trim(dssave!draweebank_code) & ""
'''          '      .Col = 5: .Text = Format(dssave!Entry_date, "dd/mm/yyyy") & ""
'''           '     .Col = 6: .Text = Trim(dssave!customer_ref) & ""
'''            '    .Col = 7: .Text = Trim(dssave!amount) & ""
'''        'End With
'''        'dssave.MoveNext
'''    'Loop
''''dssave.Close
''''End If
'''''End If
''''editchkamt = False
'''
'''
'''
'''
'''If editdata Then
'''    oconn.Connection.Execute "update csd set check_no='" & Trim(txtchno.Text) & "',slip_date='" & Format(msdate.Text, "dd/mm/yyyy") & "',drawer='" & Trim(txtdrawer.Text) & "',draweebank_code='" & Left(cmbdrawee.Text, 3) & "',customer_ref='" & Trim(txtcusref.Text) & "',entry_date='" & Format(medate.Text, "dd/mm/yyyy") & "' where d_code = '" & Trim(txtdcode.Text) & "' and slno=" & lblslno.Caption & ""
'''    cleargrid
'''
'''
'''    showcheck1.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    If showcheck1.RecordCount > 0 Then
'''           Do While Not showcheck1.EOF
'''            With citispeed
'''                .Rows = .Rows + 1
'''                .Row = .Rows - 1
'''
'''                .Col = 0: .Text = showcheck1!slno
'''                .Col = 1: .Text = Trim(showcheck1!check_no) & ""
'''                .Col = 2: .Text = Format(showcheck1!slip_date, "dd/mm/yyyy") & ""
'''                .Col = 3: .Text = showcheck1!drawer & ""
'''                .Col = 4: .Text = Trim(showcheck1!draweebank_code) & ""
'''                .Col = 5: .Text = Format(showcheck1!entry_date, "dd/mm/yyyy") & ""
'''                .Col = 6: .Text = Trim(showcheck1!customer_ref) & ""
'''                .Col = 7: .Text = Trim(showcheck1!amount) & ""
'''                End With
'''                showcheck1.MoveNext
'''                Loop
'''
'''
'''     bsave.Enabled = False
'''    bcancel.Enabled = True
'''    bquit.Enabled = False
'''showcheck1.Close
'''End If
'''End If
'''
'''editdata = False
''''If Not editdata Then
'''showcheck.Open ("select count(check_no)as countchkno from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''Dim i As Integer
'''i = Val(txttotalchkno.Text)
'''If showcheck!countchkno <> i Then
'''    MsgBox "Mismatch in TotalCheckNo"
'''    bsave.Enabled = False
'''    bcancel.Enabled = True
'''    bquit.Enabled = False
'''
'''    showcheck.Close
'''    Exit Sub
'''Else
'''    showcheck.Close
'''    Exit Sub
'''End If
''''End If
'''

End Sub

Private Sub Command2_Click()
''Dim introwcounter As Integer
'''checkamount.Open ("select citicheck_amount from dschedule where ds_code='" & lblds.Caption & "' and d_code='" & Trim(txtdcode.Text) & "' and citicheck_amount=" & Val(txtamount.Text) & ""), oconn.Connection, adOpenKeyset, adLockPessimistic
'''If checkamount.RecordCount = 0 Then
'' '   MsgBox "Mismatch in Amount"
''  '  checkamount.Close
''   ' Exit Sub
'''End If
'''\\
''If Not editdata And Not editchkamt Then
''If Trim(txtchno.Text) <> "" And Trim(txtamount.Text) <> "" Then
''With citispeed
''    .Rows = .Rows + 1
''    .Row = .Rows - 1
''    .Col = 1: .Text = Trim(txtchno.Text)
''    .Col = 2: .Text = Format(msdate.Text, "dd/mm/yyyy")
''    .Col = 3: .Text = Trim(txtdrawer.Text)
''    .Col = 4: .Text = Left(cmbdrawee.Text, 3)
''    .Col = 5: .Text = Format(medate.Text, "dd/mm/yyyy")
''    .Col = 6: .Text = Trim(txtcusref.Text)
''    .Col = 7: .Text = Val(txtamount.Text)
''
''End With
''Dim intserialnumber As Integer
''Dim icounter As Integer
''    With citispeed
''        For icounter = 1 To .Rows - 1
''            .Row = icounter
''            .Col = 0: .Text = icounter
''        Next
''        intserialnumber = icounter - 1
''    End With
''txtchno.Text = ""
''txtamount.Text = ""
''bsave.Enabled = True
''bcancel.Enabled = True
''bquit.Enabled = False
''bdelete.Enabled = False
''txtchno.SetFocus
''End If
''End If
''
End Sub

Private Sub Command3_Click()
'''If Trim(txtdcode.Text) = "" Then
'''    MsgBox "Must enter DepositCode"
'''    Cancel = True
'''    Exit Sub
'''End If
'''If Len(txtdcode.Text) < 7 Then
'''    MsgBox "Must enter 7 digits"
'''    txtdcode.Text = ""
'''    Cancel = True
'''    Exit Sub
'''End If
'''
'''editdata = False
'''allshow.Open ("select e.*,a.acc_name,b.bank_name,c.location_name,d.branch_name  from client as a,bank as b,location as c,branch as d,dschedule as e where e.d_code='" & Trim(txtdcode.Text) & "' and e.client_code=(a.client_code)+(a.sub_client) and e.corr_bcode=b.bank_code and e.location_code=c.location_code  and e.corr_brcode=d.branch_code and e.deposit_type='Check'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''If allshow.RecordCount > 0 Then
'''
'''    lbldscode = Trim(allshow!ds_code)
'''    txttotalchkno.Text = Trim(allshow!No_check)
'''    txttotal.Text = Trim(Format(allshow!citicheck_amount, "#########0.00"))
'''    dschkamt = Trim(allshow!citicheck_amount)
'''    lblclient = Trim(allshow!Client_Code) + Space(2) + ":" + Space(2) + Trim(allshow!acc_name)
'''    lbllocation = Trim(allshow!location_code) + Space(2) + ":" + Space(2) + Trim(allshow!location_name)
'''    lblbranch = Trim(allshow!Corr_BCode) + Trim(allshow!Corr_BrCode) + Space(2) + ":" + Space(2) + Trim(allshow!bank_name) + Space(2) + ":" + Space(2) + Trim(allshow!branch_name)
'''    lblsdate = Format(allshow!Schedule_date, "dd/mm/yyyy")
'''    lblnochk = Trim(allshow!No_check)
'''ElseIf allshow.RecordCount = 0 Then
'''    MsgBox "Invalid Deposit Code"
'''    txtdcode.Text = ""
'''    Cancel = True
'''    allshow.Close
'''    Exit Sub
'''End If
'''allshow.Close
'''msdate.SetFocus
'''showcheck.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''If showcheck.RecordCount > 0 Then
'''    msg = "Duplicate Data,Do you want to edit or delete?"
'''    style = vbYesNo + vbDefaultButton2 + vbInformation
'''    title = "Duplicate Data"
'''    response = MsgBox(msg, style, title)
'''    If response = vbYes Then
'''        bsave.Enabled = False
'''        bcancel.Enabled = True
'''        bdelete.Enabled = True
'''        bquit.Enabled = False
'''        msdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy") & ""
'''        txtcusref.Text = Trim(showcheck!customer_ref) & ""
'''        medate.Text = Format(showcheck!entry_date, "dd/mm/yyyy") & ""
'''        Do While Not showcheck.EOF
'''            With citispeed
'''                .Rows = .Rows + 1
'''                .Row = .Rows - 1
'''
'''                .Col = 0: .Text = showcheck!slno
'''                .Col = 1: .Text = Trim(showcheck!check_no) & ""
'''                .Col = 2: .Text = Trim(showcheck!drawer) & ""
'''                .Col = 3: .Text = Trim(showcheck!draweebank_code) & ""
'''                .Col = 4: .Text = Trim(showcheck!drawee_branch) & ""
'''                .Col = 5: .Text = Trim(showcheck!check_date) & ""
'''                .Col = 6: .Text = Format(showcheck!amount, "#,##,##,##,##0.00") & ""
'''                End With
'''                showcheck.MoveNext
'''                Loop
'''    ElseIf response = vbNo Then
'''        init_item
'''        Cancel = True
'''        showcheck.Close
'''        Exit Sub
'''    End If
'''End If
'''showcheck.Close
'''
End Sub

Private Sub Form_Load()

Move (frmMain.Height - Height) / 2, (frmMain.width - width) / 2
lbllocation.Caption = ""
lblClient.Caption = ""
lblbranch.Caption = ""
txttotalchkno.Text = ""
medate.Text = Format(Date, "dd/mm/yyyy")
TxtAmount.Text = ""
bsave.Enabled = False
bcancel.Enabled = False
bdelete.Enabled = False
bquit.Enabled = True
'Me.Width = 11355
'Me.Height = 7935
cleargrid



End Sub

Private Sub medate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub medate_Validate(Cancel As Boolean)
'    If medate.Text = "" Then
'        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
'     If oDate.Validate(medate) = False Then
'        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
End Sub

Private Sub msdate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
Private Sub msdate_Validate(Cancel As Boolean)
'    If msdate.Text = "__/__/____" Then
'        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
'     If oDate.Validate(msdate) = False Then
'        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
End Sub

Private Sub TxtAmount_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtamount_LostFocus()
If Not deldata Or appenddata Then
    Dim introwcounter As Integer
    Dim intcounter As Integer
    If Trim(msdate.Text) = "__/__/____" Then
        MsgBox "Must enter slipdate"
        msdate.SetFocus
        Exit Sub
    End If
    If Trim(txtchno.Text) = "" Then
        MsgBox "Must enter checkno"
        txtchno.SetFocus
        Exit Sub
    End If
    If cmbdrawee.Text = "" Then
        MsgBox "Must enter Drawee Bank"
        cmbdrawee.SetFocus
        Exit Sub
    End If
    If Trim(TxtAmount.Text) = "" Then
      MsgBox "Must enter amount"
      TxtAmount.SetFocus
      Exit Sub
    End If
    If Trim(TxtAmount.Text) = "" Then
        MsgBox "Must enter Amount"
        TxtAmount.SetFocus
    End If
    
    
    ''Validation for new customer refno which is must entry field for those client
    ''whose credit type is "R"
    
    ''********************************
    '*****************check for customer ref no
     Set rs = ocon.GetResultset("select  b.client_code+b.sub_client,b.cashcrtyp " & _
     " from dschedule a,client b Where B.client_code + B.sub_client = A.client_code " & _
     "  and  d_code='" & (txtdcode.Text) & "' and b.cashcrtyp='R' ")
     If Not (rs.BOF And rs.EOF) Then
        If Trim(TxtCheckRef.Text) = "" Then
          MsgBox "This client customer refno can not be blank", vbOKOnly
          Exit Sub
        End If
        
     End If
     
'********************************************************
    
    
    
    
    
    
    
    ''''''\\\\Modified by dewan on 31/12/2003''
        'newslno.Open ("select *  from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    'If newslno.RecordCount = 0 Then
       ' xx = 1
    'ElseIf newslno.RecordCount <> 0 Then
     '   newslno.MoveLast
        'xx = newslno!slno + 1
    'End If
   ' newslno.Close
   '' ////////////////////////////////////////////
If citispeed.Rows - 1 = 0 Then
 xx = 1
  Else
  With citispeed
  
   If gridselect = True Then
            xx = gridClickSlNo
   Else
        For I = 1 To citispeed.Rows - 1
           If xx <= citispeed.TextMatrix(I, 0) Then
            xx = 1 + citispeed.TextMatrix(I, 0)
           End If
           
        Next
    End If
  End With
  End If
  With citispeed
        .Rows = .Rows + 1
        .row = .Rows - 1
        .Cols = 12
            
        .col = 0: .Text = xx
        .col = 1: .Text = Trim(txtchno.Text)
        .col = 2: .Text = Trim(txtdrawer)
        .col = 3: .Text = Left(cmbdrawee.Text, 3)
        .col = 4: .Text = Trim(txtbranch)
         If chkdate.Text <> "__/__/____" Then
            .col = 5: .Text = Format(chkdate.Text, "dd/mm/yyyy")
            'ElseIf chkdate.Text = "__/__/____" Then
                '!check_date =
            End If
        
        .col = 6: .Text = Format(TxtAmount, "#,##,##,##,##0.00") & ""
        .col = 7: .Text = Format(msdate.Text, "dd/mm/yyyy")
        .col = 8: .Text = Format(medate.Text, "dd/mm/yyyy")
        .col = 9: .Text = Trim(txtdcode.Text)
        .col = 10: .Text = Trim(TxtCusRef.Text)
        ''New requirement 23-04-2005
        Dim sRefno As String
        sRefno = (TxtCheckRef.Text + TxtCheckRef1.Text)
        .col = 11: .Text = Trim(sRefno)
        
    End With
    
 ''/////////////////////////////////////////////////
    
'''    newslno.Open ("select *  from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    If newslno.RecordCount = 0 Then
'''        xx = 1
'''    ElseIf newslno.RecordCount <> 0 Then
'''        newslno.MoveLast
'''        xx = newslno!slno + 1
'''    End If
'''    newslno.Close

'''    saveall.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''     If saveall.RecordCount = 0 Or saveall.RecordCount > 0 Then
'''            With saveall
'''            .AddNew
'''            saveall!d_code = Trim(txtdcode.Text)
'''            !slno = xx
'''            !check_no = Trim(txtchno.Text)
'''            !slip_date = Format(msdate.Text, "dd/mm/yyyy")
'''            !drawer = Trim(txtdrawer)
'''            !draweebank_code = Left(cmbdrawee.Text, 3)
'''            !Entry_date = Format(medate.Text, "dd/mm/yyyy")
'''            !customer_ref = Trim(txtcusref.Text)
'''            If chkdate.Text <> "__/__/____" Then
'''                !check_date = Format(chkdate.Text, "dd/mm/yyyy")
'''            'ElseIf chkdate.Text = "__/__/____" Then
'''                '!check_date =
'''            End If
'''            !drawee_branch = Trim(txtbranch.Text)
'''            !amount = Val(txtamount)
'''            .Update
'''        End With
'''        saveall.Close
'''    End If

   ' cleargrid
'''    dssave.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''        Do While Not dssave.EOF
'''            With citispeed
'''                .Rows = .Rows + 1
'''                .Row = .Rows - 1
'''                .Col = 0: .Text = dssave!slno
'''                .Col = 1: .Text = Trim(dssave!check_no) & ""
'''                .Col = 2: .Text = dssave!drawer & ""
'''                .Col = 3: .Text = Trim(dssave!draweebank_code) & ""
'''                .Col = 4: .Text = Trim(dssave!drawee_branch) & ""
'''                .Col = 5: .Text = Trim(dssave!check_date) & ""
'''                '.Col = 5: .Text = IIf(dssave!check_date = Null, "__/__/____", dssave!check_date)
'''                .Col = 6: .Text = Format(dssave!amount, "#,##,##,##,##0.00") & ""
'''
'''            End With
'''            dssave.MoveNext
'''        Loop
'''        dssave.Close
        txtchno.Text = ""
        chkdate.Text = "__/__/____"
        txtdrawer.Text = ""
        txtbranch.Text = ""
        TxtAmount.Text = ""
        TxtCheckRef1.Text = ""
        txtchno.SetFocus
        bsave.Enabled = True
        bdelete.Enabled = False
        bcancel.Enabled = True
        bquit.Enabled = False
        gridselect = False
        gridClickSlNo = 0
    End If
    gridClickSlNo = 0
    gridselect = False
End Sub



Private Sub txtbranch_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub



Private Sub TxtCheckRef_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub


Private Sub TxtCheckRef1_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtchno_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtcusref_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtdcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
chkdate.Text = "__/__/____"
txtbranch.Text = ""
TxtCusRef.Text = ""
lblsdate.Caption = ""
lbllocation.Caption = ""
lblbranch.Caption = ""
lblClient.Caption = ""
txttotalchkno.Text = ""
Frame1.Enabled = True
txttotal.Text = ""
txtchno.Text = ""
msdate.Text = "__/__/____"
medate.Text = Format(Date, "dd/mm/yyyy")
TxtAmount.Text = ""
txtdrawer.Text = ""
cmbdrawee.Clear
lbldscode.Caption = ""
TxtCheckRef.Text = ""
lblsdate.Caption = ""
lblClient.Caption = ""
lbllocation.Caption = ""
lblbranch.Caption = ""
txttotalchkno.Text = ""
txttotal.Text = ""
cleargrid
     
End Sub

Public Sub cleargrid()
With citispeed
        .Rows = 1
        .Cols = 12
        .row = 0
            
        .ColWidth(0) = 600
        .ColWidth(1) = 1600
        .ColWidth(2) = 2000
        .ColWidth(3) = 1200
        .ColWidth(4) = 2000
        .ColWidth(5) = 1200
        .ColWidth(6) = 2000
        .ColWidth(7) = 0
        .ColWidth(8) = 0
        .ColWidth(9) = 0
        .ColWidth(10) = 1500
        .ColWidth(11) = 1500
        
        .col = 0: .Text = " SlNo"
        .col = 1: .Text = "Check No   "
        .col = 2: .Text = " Drawer"
        .col = 3: .Text = "Dr_Bank\Br"
        .col = 4: .Text = "  Dr_Branch"
        .col = 5: .Text = "Check_date"
        .col = 6: .Text = "Amount"
        .col = 7: .Text = "slip_date"
        .col = 8: .Text = "EntryDate"
        .col = 9: .Text = "DCode"
        .col = 10: .Text = "Customer Reference"
        .col = 11: .Text = "Check Reference"
        
        
    End With

End Sub



Private Sub txtdcode_LostFocus()
'If Trim(txtdcode.Text) = "" Then
 '   MsgBox "Must enter DepositCode"
  '  Cancel = True
   ' Exit Sub
'End If
cleargrid
appenddata = False
deldata = False
If Trim(txtdcode.Text) <> "" Then
If Len(txtdcode.Text) < 7 Then
    MsgBox "Must enter 7 digits"
    txtdcode.Text = ""
    txtdcode.SetFocus
    Exit Sub
End If

lbldscode.Caption = ""
lblsdate.Caption = ""
lblClient.Caption = ""
lbllocation.Caption = ""
lblbranch.Caption = ""
txttotalchkno.Text = ""
txttotal.Text = ""
chkdate.Text = "__/__/____"
txtbranch.Text = ""
TxtCusRef.Text = ""
lblsdate.Caption = ""
lbllocation.Caption = ""
lblbranch.Caption = ""
lblClient.Caption = ""
txttotalchkno.Text = ""
txttotal.Text = ""
TxtCheckRef.Text = ""
txtchno.Text = ""
msdate.Text = "__/__/____"
medate.Text = Format(Date, "dd/mm/yyyy")
TxtAmount.Text = ""
txtdrawer.Text = ""
cmbdrawee.Clear

allshow.Open ("select e.*,a.acc_name,b.bank_name,c.location_name,d.branch_name  from client as a,bank as b,location as c,branch as d,dschedule as e where e.d_code='" & Trim(txtdcode.Text) & "' and e.client_code=(a.client_code)+(a.sub_client) and e.corr_bcode=b.bank_code and e.location_code=c.location_code  and e.corr_brcode=d.branch_code and e.deposit_type='Check'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If allshow.RecordCount > 0 Then

    lbldscode = Trim(allshow!ds_code)
    txttotalchkno.Text = Trim(allshow!No_check)
    txttotal.Text = Trim(Format(allshow!citicheck_amount, "#,##,##,##,##0.00"))
    dschkamt = Trim(allshow!citicheck_amount)
    lblClient = Trim(allshow!client_code) + Space(2) + ":" + Space(2) + Trim(allshow!Acc_Name)
    lbllocation = Trim(allshow!location_code) + Space(2) + ":" + Space(2) + Trim(allshow!Location_Name)
    lblbranch = Trim(allshow!Corr_BCode) + Trim(allshow!Corr_BrCode) + Space(2) + ":" + Space(2) + Trim(allshow!bank_name) + Space(2) + ":" + Space(2) + Trim(allshow!branch_name)
    lblsdate = Format(allshow!Schedule_date, "dd/mm/yyyy")
    msdate.Text = Format(allshow!Schedule_date, "dd/mm/yyyy")
    lblnochk = Trim(allshow!No_check)
ElseIf allshow.RecordCount = 0 Then
    MsgBox "Invalid Deposit Code"
    txtdcode.Text = ""
    txtdcode.SetFocus
    allshow.Close
    Exit Sub
End If
allshow.Close
'msdate.SetFocus
showcheck.Open ("select * from csd where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
If showcheck.RecordCount > 0 Then
        msg = "Duplicate Data,Do you want to Delete?"
        style = vbYesNo + vbDefaultButton3 + vbInformation
        title = "Duplicate Data"
        response = MsgBox(msg, style, title)
        If response = vbYes Then
            deldata = True
            appenddata = False
            bsave.Enabled = False
            bcancel.Enabled = True
            bdelete.Enabled = True
            Frame1.Enabled = False
            bquit.Enabled = False
            msdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy") & ""
            TxtCusRef.Text = Trim(showcheck!customer_ref) & ""
            medate.Text = Format(showcheck!Entry_date, "dd/mm/yyyy") & ""
            Do While Not showcheck.EOF
                With citispeed
                .Rows = .Rows + 1
                .row = .Rows - 1

                .col = 0: .Text = showcheck!slno
                .col = 1: .Text = Trim(showcheck!check_no) & ""
                .col = 2: .Text = Trim(showcheck!Drawer) & ""
                .col = 3: .Text = Trim(showcheck!draweebank_code) & ""
                .col = 4: .Text = Trim(showcheck!drawee_branch) & ""
                .col = 5: .Text = Trim(showcheck!check_date) & ""
                .col = 6: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00") & ""
                .col = 10: .Text = Format(showcheck!customer_ref)
                .col = 11: .Text = Format(showcheck!CheckRef) & ""
                End With
                showcheck.MoveNext
                Loop
        ElseIf response = vbNo Then

             msg = "Duplicate Data,Do you want to Append?"
             style = vbYesNo + vbDefaultButton3 + vbInformation
             title = "Duplicate Data"
             response = MsgBox(msg, style, title)
             If response = vbYes Then
                    appenddata = True
                    deldata = False
                    bsave.Enabled = True
                    bcancel.Enabled = True
                    bdelete.Enabled = False
                    bquit.Enabled = False
                    Frame1.Enabled = True
                    msdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy") & ""
                    TxtCusRef.Text = Trim(showcheck!customer_ref) & ""
                    medate.Text = Format(showcheck!Entry_date, "dd/mm/yyyy") & ""
                    Do While Not showcheck.EOF
                        With citispeed
                        .Rows = .Rows + 1
                        .row = .Rows - 1

                        .col = 0: .Text = showcheck!slno
                        .col = 1: .Text = Trim(showcheck!check_no) & ""
                        .col = 2: .Text = Trim(showcheck!Drawer) & ""
                        .col = 3: .Text = Trim(showcheck!draweebank_code) & ""
                        .col = 4: .Text = Trim(showcheck!drawee_branch) & ""
                        .col = 5: .Text = Trim(showcheck!check_date) & ""
                        .col = 6: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00") & ""
                        .col = 10: .Text = Trim(showcheck!customer_ref) & ""
                        .col = 11: .Text = Trim(showcheck!CheckRef) & ""
                        End With
                        showcheck.MoveNext
                     Loop
                     txtchno.SetFocus
                ElseIf response = vbNo Then
                    bsave.Enabled = False
                    bdelete.Enabled = False
                    bcancel.Enabled = False
                    bquit.Enabled = True
                    lbldscode.Caption = ""
                    lblsdate.Caption = ""
                    txtdcode.Text = ""
                    lblClient.Caption = ""
                    lbllocation.Caption = ""
                    lblbranch.Caption = ""
                    txttotalchkno.Text = ""
                    txttotal.Text = ""
                    txtdcode.SetFocus
                    showcheck.Close
                    Exit Sub
                End If
End If
End If
showcheck.Close
End If


End Sub



Private Sub txtdrawer_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txttotal_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txttotal_LostFocus()
txttotal.Text = Format(txttotal.Text, "#,##,##,##,##0,00")


End Sub

Private Sub txttotalchkno_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Public Sub init_item()
txtdcode.Text = ""
lbldscode.Caption = ""
chkdate.Text = "__/__/____"
txtbranch.Text = ""
TxtCusRef.Text = ""
lblsdate.Caption = ""
lbllocation.Caption = ""
lblbranch.Caption = ""
lblClient.Caption = ""
txttotalchkno.Text = ""
TxtCheckRef.Text = ""
txttotal.Text = ""
txtchno.Text = ""
msdate.Text = "__/__/____"
medate.Text = Format(Date, "dd/mm/yyyy")
TxtAmount.Text = ""
txtdrawer.Text = ""
cmbdrawee.Clear
Frame1.Enabled = True
bsave.Enabled = False
bcancel.Enabled = False
bdelete.Enabled = False
bquit.Enabled = True

cleargrid
txtdcode.SetFocus




End Sub

