VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "MSMASK32.OCX"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Begin VB.Form frmccheckdetail 
   Caption         =   "CitiCheck Detail Information"
   ClientHeight    =   8100
   ClientLeft      =   60
   ClientTop       =   90
   ClientWidth     =   11355
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   8100
   ScaleWidth      =   11355
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00C0C0C0&
      Height          =   7260
      Left            =   105
      ScaleHeight     =   7200
      ScaleWidth      =   11115
      TabIndex        =   20
      Top             =   765
      Width           =   11175
      Begin VB.CommandButton bsave 
         Caption         =   "Ok"
         Height          =   270
         Left            =   10095
         TabIndex        =   52
         Top             =   2280
         Width           =   870
      End
      Begin VB.CommandButton bcancel 
         Caption         =   "Cancel"
         Height          =   285
         Left            =   10095
         TabIndex        =   51
         Top             =   2595
         Width           =   840
      End
      Begin VB.CommandButton bquit 
         Caption         =   "Quit"
         CausesValidation=   0   'False
         Height          =   270
         Left            =   10095
         TabIndex        =   50
         Top             =   3225
         Width           =   885
      End
      Begin VB.CommandButton bdelete 
         Caption         =   "Delete"
         Height          =   285
         Left            =   10095
         TabIndex        =   49
         Top             =   2925
         Width           =   840
      End
      Begin VB.Frame Frame2 
         Height          =   1935
         Left            =   120
         TabIndex        =   36
         Top             =   0
         Width           =   10935
         Begin VB.TextBox txtdcode 
            Height          =   310
            Left            =   1620
            MaxLength       =   7
            TabIndex        =   0
            Top             =   240
            Width           =   1470
         End
         Begin VB.ComboBox cmbclient 
            Height          =   315
            Left            =   1620
            TabIndex        =   1
            Top             =   600
            Width           =   4215
         End
         Begin VB.ComboBox cmbdlocation 
            Height          =   315
            Left            =   7410
            TabIndex        =   4
            Top             =   225
            Width           =   3390
         End
         Begin VB.TextBox txtref 
            Height          =   310
            Left            =   7470
            MaxLength       =   10
            TabIndex        =   5
            Top             =   585
            Width           =   1830
         End
         Begin VB.TextBox txttamount 
            Height          =   310
            Left            =   7485
            TabIndex        =   7
            Top             =   1245
            Width           =   1470
         End
         Begin VB.TextBox txttcheck 
            Height          =   285
            Left            =   7470
            TabIndex        =   6
            Top             =   930
            Width           =   1305
         End
         Begin VB.CommandButton bedit 
            Caption         =   "Edit"
            Height          =   375
            Left            =   9375
            TabIndex        =   37
            Top             =   960
            Width           =   1215
         End
         Begin MSMask.MaskEdBox cvaluedate 
            Height          =   315
            Left            =   1620
            TabIndex        =   3
            Top             =   1530
            Width           =   1470
            _ExtentX        =   2593
            _ExtentY        =   556
            _Version        =   393216
            MaxLength       =   10
            Format          =   "dd/mm/yyyy"
            Mask            =   "##/##/####"
            PromptChar      =   "_"
         End
         Begin MSMask.MaskEdBox cslipdate 
            Height          =   315
            Left            =   1620
            TabIndex        =   2
            Top             =   1200
            Width           =   1470
            _ExtentX        =   2593
            _ExtentY        =   556
            _Version        =   393216
            MaxLength       =   10
            Format          =   "dd/mm/yyyy"
            Mask            =   "##/##/####"
            PromptChar      =   "_"
         End
         Begin VB.Label lblAcno 
            BackColor       =   &H80000013&
            ForeColor       =   &H000000FF&
            Height          =   255
            Left            =   1620
            TabIndex        =   56
            Top             =   960
            Width           =   2775
         End
         Begin VB.Label Label24 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "A/C No"
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
            Height          =   285
            Left            =   120
            TabIndex        =   55
            Top             =   960
            Width           =   1470
         End
         Begin VB.Label Label2 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "DSlip No"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   315
            Left            =   120
            TabIndex        =   48
            Top             =   240
            Width           =   1470
         End
         Begin VB.Label Label3 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "ClientCode"
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
            Height          =   315
            Left            =   120
            TabIndex        =   47
            Top             =   570
            Width           =   1470
         End
         Begin VB.Label Label4 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "DSlip Date"
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
            Height          =   315
            Left            =   120
            TabIndex        =   46
            Top             =   1260
            Width           =   1470
         End
         Begin VB.Label Label5 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "TotalChecks No."
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
            Height          =   315
            Left            =   5955
            TabIndex        =   45
            Top             =   915
            Width           =   1470
         End
         Begin VB.Label Label6 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "DepositLocation"
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
            Height          =   315
            Left            =   5955
            TabIndex        =   44
            Top             =   240
            Width           =   1470
         End
         Begin VB.Label Label7 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CustomerRef."
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
            Height          =   315
            Left            =   5955
            TabIndex        =   43
            Top             =   570
            Width           =   1470
         End
         Begin VB.Label Label8 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "ValueDate"
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
            Height          =   315
            Left            =   120
            TabIndex        =   42
            Top             =   1590
            Width           =   1470
         End
         Begin VB.Label Label9 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "TotalAmount"
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
            Height          =   300
            Left            =   5955
            TabIndex        =   41
            Top             =   1245
            Width           =   1470
         End
         Begin VB.Label Label10 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "chkCount status"
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
            Height          =   300
            Left            =   5940
            TabIndex        =   40
            Top             =   1560
            Width           =   1485
         End
         Begin VB.Label lblchkstatus 
            BorderStyle     =   1  'Fixed Single
            Height          =   300
            Left            =   7485
            TabIndex        =   39
            Top             =   1590
            Width           =   1515
         End
         Begin VB.Label lblrjref 
            BorderStyle     =   1  'Fixed Single
            Height          =   255
            Left            =   9120
            TabIndex        =   38
            Top             =   1560
            Visible         =   0   'False
            Width           =   1095
         End
      End
      Begin MSFlexGridLib.MSFlexGrid citicheck 
         Height          =   2685
         Left            =   120
         TabIndex        =   27
         Top             =   4440
         Width           =   10890
         _ExtentX        =   19209
         _ExtentY        =   4736
         _Version        =   393216
         FixedCols       =   0
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00C0C0C0&
         Height          =   2445
         Left            =   120
         TabIndex        =   21
         Top             =   1920
         Width           =   9855
         Begin VB.TextBox TxtCheckRef1 
            Height          =   300
            Left            =   7920
            MaxLength       =   3
            TabIndex        =   15
            Top             =   960
            Width           =   465
         End
         Begin VB.TextBox TxtCheckRef 
            Height          =   300
            Left            =   7200
            MaxLength       =   7
            TabIndex        =   14
            Top             =   960
            Width           =   825
         End
         Begin VB.ComboBox cmbbranch 
            Height          =   315
            Left            =   1320
            TabIndex        =   10
            Top             =   840
            Width           =   4455
         End
         Begin VB.TextBox txtrjcode 
            Height          =   285
            Left            =   7200
            MaxLength       =   2
            TabIndex        =   17
            Top             =   1680
            Width           =   1215
         End
         Begin VB.ComboBox cmbchktype 
            Height          =   315
            Left            =   7200
            TabIndex        =   12
            Top             =   240
            Width           =   1185
         End
         Begin VB.TextBox txtamount 
            Height          =   300
            Left            =   7200
            TabIndex        =   18
            Top             =   2040
            Width           =   2370
         End
         Begin VB.TextBox txtchkno 
            Height          =   300
            Left            =   7200
            MaxLength       =   15
            TabIndex        =   13
            Top             =   600
            Width           =   2385
         End
         Begin VB.ComboBox cmblocation 
            Height          =   315
            Left            =   1320
            TabIndex        =   11
            Top             =   1200
            Width           =   4440
         End
         Begin VB.ComboBox cmbdrbank 
            Height          =   315
            Left            =   1320
            TabIndex        =   9
            Top             =   525
            Width           =   4515
         End
         Begin VB.TextBox txtdrawer 
            Height          =   300
            Left            =   1320
            TabIndex        =   8
            Top             =   210
            Width           =   2325
         End
         Begin MSMask.MaskEdBox ccheckdate 
            Height          =   300
            Left            =   7200
            TabIndex        =   16
            Top             =   1320
            Width           =   1185
            _ExtentX        =   2090
            _ExtentY        =   529
            _Version        =   393216
            MaxLength       =   10
            Format          =   "dd/mm/yyyy"
            Mask            =   "##/##/####"
            PromptChar      =   "_"
         End
         Begin VB.Label Label23 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CheckRefNo"
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
            Height          =   300
            Left            =   6000
            TabIndex        =   54
            Top             =   960
            Width           =   1185
         End
         Begin VB.Label Label22 
            Caption         =   "dd/mm/yyyy"
            Height          =   255
            Left            =   8520
            TabIndex        =   53
            Top             =   1320
            Width           =   975
         End
         Begin VB.Label Label21 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "ClearingZone"
            BeginProperty Font 
               Name            =   "Times New Roman"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   285
            Left            =   120
            TabIndex        =   35
            Top             =   1560
            Width           =   1215
         End
         Begin VB.Label lblzone 
            BorderStyle     =   1  'Fixed Single
            Height          =   285
            Left            =   1335
            TabIndex        =   34
            Top             =   1560
            Width           =   4200
         End
         Begin VB.Label Label14 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CheckType"
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
            Height          =   330
            Left            =   6000
            TabIndex        =   33
            Top             =   210
            Width           =   1185
         End
         Begin VB.Label Label12 
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
            ForeColor       =   &H000000C0&
            Height          =   300
            Left            =   6000
            TabIndex        =   32
            Top             =   2040
            Width           =   1185
         End
         Begin VB.Label Label11 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CheckNo"
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
            Height          =   300
            Left            =   6000
            TabIndex        =   31
            Top             =   600
            Width           =   1185
         End
         Begin VB.Label Label20 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "RejectCode"
            Height          =   300
            Left            =   6000
            TabIndex        =   30
            Top             =   1680
            Width           =   1185
         End
         Begin VB.Label lblslno 
            BorderStyle     =   1  'Fixed Single
            Height          =   270
            Left            =   4320
            TabIndex        =   28
            Top             =   180
            Visible         =   0   'False
            Width           =   1185
         End
         Begin VB.Label Label18 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Branch"
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
            Height          =   300
            Left            =   120
            TabIndex        =   26
            Top             =   840
            Width           =   1185
         End
         Begin VB.Label Label17 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Location"
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
            Height          =   300
            Left            =   120
            TabIndex        =   25
            Top             =   1200
            Width           =   1185
         End
         Begin VB.Label Label16 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "DraweeBank"
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
            Height          =   300
            Left            =   105
            TabIndex        =   24
            Top             =   540
            Width           =   1185
         End
         Begin VB.Label Label15 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Drawer"
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
            Height          =   300
            Left            =   105
            TabIndex        =   23
            Top             =   210
            Width           =   1185
         End
         Begin VB.Label Label13 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CheckDate"
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
            Height          =   300
            Left            =   6000
            TabIndex        =   22
            Top             =   1320
            Width           =   1185
         End
      End
   End
   Begin VB.Label Label19 
      Caption         =   "Label19"
      Height          =   495
      Left            =   4785
      TabIndex        =   29
      Top             =   3615
      Width           =   1215
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00E0E0E0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Update CITICheck "
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   20.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   630
      Left            =   45
      TabIndex        =   19
      Top             =   105
      Width           =   11055
   End
End
Attribute VB_Name = "frmccheckdetail"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'**********************************************
'Form name              :frmCCheckDetail
'Form Description       :Citicashdetail
'Creation date          :06/02/2000
'Design & Developed by  :
'**********************************************
Dim saveall As New ADODB.Recordset
Dim clientadd As New ADODB.Recordset
Dim locationadd As New ADODB.Recordset
Dim bankcodeadd As New ADODB.Recordset
Dim branchadd As New ADODB.Recordset
Dim checkamount As New ADODB.Recordset
Dim showcheck As New ADODB.Recordset
Dim dssave As New ADODB.Recordset
Dim chknocount As New ADODB.Recordset
Dim rejectdata As New ADODB.Recordset
Dim rejectcheck As New ADODB.Recordset
Dim newslno As New ADODB.Recordset
Dim savereject As New ADODB.Recordset
Dim acceptdata As New ADODB.Recordset
Dim showcheck1 As New ADODB.Recordset
Dim zonechk As New ADODB.Recordset
Dim zonechk1 As New ADODB.Recordset
Dim txttchk As Currency
Dim txtchk1 As Currency
Dim lblamt As Currency
Dim appendcheck As Boolean
Dim deldata As Boolean
Dim selectgrid As Boolean
Dim xx As Integer
Dim cz As Currency
Dim pp As Currency
Dim xx1 As Integer
Dim open_flag As Boolean
Dim appenddata As Boolean
Dim editchkamt As Boolean
Dim lblreason As String
Dim reject As Boolean


Private Sub bcancel_Click()
Dim Respns As Integer
If Trim(txtdcode.Text) = "" Then
    Exit Sub
End If
Respns = MsgBox("Do you want to Clear this information?", vbQuestion + vbYesNo)
           
Select Case Respns
    Case vbYes
        init_item
    Case vbNo
       bcancel.SetFocus
End Select
End Sub

Private Sub bdelete_Click()


If Not selectgrid Then
    MsgBox "Must select Record from grid"
    Exit Sub
End If
bdelete.Enabled = False
If deldata = True Then
    kk = MsgBox("Are you sure you want to Delete?", vbDefaultButton3 + vbQuestion + vbYesNo)
    If kk = vbNo Then
        Exit Sub
    End If
    Set rs = Nothing
    Set rs = ocon.GetResultset("select *  from ccheck where d_code='" & Trim(txtdcode.Text) & "' and slno=" & lblslno.Caption & " and  printflag='P'")
    If Not (rs.BOF And rs.EOF) Then
    '''For Authorization
      If Authorized = False Then
          Exit Sub
       Else
       End If
    End If
    oconn.Connection.Execute "delete from ccheck where d_code='" & Trim(txtdcode.Text) & "' and slno=" & lblslno.Caption & ""
    showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If showcheck.RecordCount > 0 Then
        cleargrid
        Do While Not showcheck.EOF
                With citicheck
                .Rows = .Rows + 1
                .row = .Rows - 1
               .col = 0: .Text = showcheck!slno
                .col = 1: .Text = Trim(showcheck!check_no) & ""
                .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                .col = 3: .Text = showcheck!location_code & ""
                .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                .col = 6: .Text = Trim(showcheck!check_type) & ""
                .col = 7: .Text = Trim(showcheck!drawer) & ""
                .col = 8: .Text = Val(showcheck!Amount)
                .col = 9: .Text = Trim(showcheck!rejectref) & ""
                .col = 10: .Text = IIf(IsNull(Trim(showcheck!Checkref)) = True, 0, Trim(showcheck!Checkref)) & ""
                End With
               showcheck.MoveNext
                Loop
                txtdrawer.Text = ""
                cmbdrbank.Clear
                cmbbranch.Clear
                cmblocation.Clear
                cmbchktype.Clear
                txtchkno.Text = ""
                ccheckdate.Text = "__/__/____"
                txtamount.Text = ""
                
    ElseIf showcheck.RecordCount = 0 Then
        oconn.Connection.Execute "delete from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"
        init_item
    End If
 End If
showcheck.Close

End Sub

Private Sub bedit_Click()

    Set rs = Nothing
    Set rs = ocon.GetResultset("select *  from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  printflag='P'")
    If Not (rs.BOF And rs.EOF) Then
    '''For Authorization
      If Authorized = False Then
          Exit Sub
       Else
       End If
    End If
selectgrid = False
If deldata = True Then
If txttcheck.Text = "" Or txttamount.Text = "" Or txtdcode.Text = "" Or cmbclient.Text = "" Or cslipdate.Text = "__/__/____" Or cvaluedate.Text = "__/__/____" Or cmbdlocation.Text = "" Then
    MsgBox "Must Fill Up all data"
    Exit Sub
End If

dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If dssave.RecordCount = 0 Then
    dssave.AddNew
    dssave!d_code = Trim(txtdcode)
    dssave!TOTAL_CHKNO = Val(txttcheck.Text)
    dssave!TOTAL_CHKAMT = txttchk
    dssave.Update
  
ElseIf dssave.RecordCount > 0 Then
    oconn.Connection.Execute "update cchecktotal set total_chkno=" & txttcheck.Text & ", total_chkamt=" & txttchk & "  where d_code='" & Trim(txtdcode.Text) & "'"
End If
dssave.Close

dssave.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If dssave.RecordCount > 0 Then
    Do While Not dssave.EOF
        
        'oconn.Connection.Execute "update ccheck set client_code='" & Left(cmbclient.Text, 6) & "',slip_date='" & Format(cslipdate.Text, "mm/dd/yyyy") & "',value_date='" & Format(cvaluedate.Text, "mm/dd/yyyy") & "',dlocation_code='" & Left(cmbdlocation.Text, 3) & "',customer_ref='" & Trim(txtref.Text) & "' where d_code = '" & Trim(txtdcode.Text) & "'"
                
    '********* new add entry_date ******* 22-02-2000**************
        oconn.Connection.Execute "update ccheck set client_code='" & Trim(Left(cmbclient.Text, 6)) & "',slip_date='" & Format(cslipdate.Text, "mm/dd/yyyy") & "',value_date='" & Format(cvaluedate.Text, "mm/dd/yyyy") & "',dlocation_code='" & Left(cmbdlocation.Text, 3) & "',customer_ref='" & Trim(txtref.Text) & "',entry_date='" & Format(Date, "mm/dd/yyyy") & "'where d_code = '" & Trim(txtdcode.Text) & "'"
        
        dssave.MoveNext
            Loop
End If
dssave.Close
 End If
End Sub

Private Sub bquit_Click()

kk = MsgBox("Are you sure you want to exit?", vbDefaultButton3 + vbYesNo + vbQuestion)
If kk = vbNo Then
    txtdcode.SetFocus
    Exit Sub
Else
    Unload Me
End If

End Sub

Private Sub bsave_Click()


''New requirement for novartis check refno is used as unique refno
Dim pp As Currency

If citicheck.Rows = 0 Then
    MsgBox "You did not enter any record !", vbCritical
    Exit Sub
End If
    

If Not deldata Or appenddata Then
Set checkamount = Nothing
    checkamount.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If checkamount.RecordCount = 0 Then
        checkamount.AddNew
        checkamount!d_code = Trim(txtdcode.Text)
        checkamount!TOTAL_CHKNO = Val(txttcheck.Text)
        checkamount!TOTAL_CHKAMT = txttchk
        checkamount.Update
    End If
    checkamount.Close

    checkamount.Open ("select sum(amount)as tchkamt from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If checkamount.RecordCount > 0 Then
        If checkamount!tchkamt <> txttchk Then
                pp = Val(checkamount!tchkamt) - (txttchk)
                MsgBox "Mismatch in TotalCheck amount :    " & Format(pp, "#,##,##,##,##0.00")
                
        End If
    End If
    checkamount.Close
    
    showcheck.Open ("select count(check_no)as countchkno from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If showcheck.RecordCount > 0 Then
        Dim i As Integer
        i = Val(txttcheck.Text)
        If showcheck!countchkno <> i Then
            MsgBox "Mismatch in TotalCheck No"
        End If
    End If
    showcheck.Close
End If


'''If editdata Then
'''    If Trim(txtdcode.Text) = "" Then
'''        MsgBox "Must enter Deposit_Code"
'''        txtdcode.SetFocus
'''        Exit Sub
'''    End If
'''    If cmbclient.Text = "" Then
'''        MsgBox "Must select client_code"
'''        cmbclient.SetFocus
'''        Exit Sub
'''    End If
'''    If cslipdate.Text = "__/__/____" Then
'''        MsgBox "Must enter SlipDate"
'''        cslipdate.SetFocus
'''        Exit Sub
'''    End If
'''    If cvaluedate.Text = "__/__/____" Then
'''        MsgBox "Must enter valueDate"
'''        cslipdate.SetFocus
'''        Exit Sub
'''    End If
'''    If cmbdlocation.Text = "" Then
'''        MsgBox "Must select location_Code"
'''        cmbdlocation.SetFocus
'''        Exit Sub
'''    End If
'''    If cmbdrbank.Text = "" Then
'''        MsgBox "Must select Drbank_Code"
'''        cmbdrbank.SetFocus
'''        Exit Sub
'''    End If
'''    'If cmblocation.Text = "" Then
'''        'MsgBox "Must select Drlocation_Code"
'''        'cmblocation.SetFocus
'''        'Exit Sub
'''    'End If
'''    'If cmbbranch.Text = "" Then
'''        'MsgBox "Must select Drbranch_Code"
'''        'cmbbranch.SetFocus
'''        'Exit Sub
'''    'End If
'''
'''    dssave.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    If dssave.RecordCount > 0 Then
'''        Do While Not dssave.EOF
'''        oconn.Connection.Execute "update ccheck set client_code='" & trim(Left(cmbclient.Text, 6)) & "',slip_date='" & Format(cslipdate.Text, "dd/mm/yyyy") & "',value_date='" & Format(cvaluedate.Text, "dd/mm/yyyy") & "',dlocation_code='" & Left(cmbdlocation.Text, 3) & "',customer_ref='" & Trim(txtref.Text) & "' where d_code = '" & Trim(txtdcode.Text) & "'"
'''        dssave.MoveNext
'''        Loop
'''    End If
'''    dssave.Close
''''If lblrjref.Caption = "" Then
'''    oconn.Connection.Execute "update ccheck set check_no='" & Trim(txtchkno.Text) & "',drawer='" & Trim(txtdrawer.Text) & "',drawee_bankcode='" & Left(cmbdrbank.Text, 3) & "',branch_code='" & Left(cmbbranch.Text, 3) & "',location_code='" & Left(cmblocation.Text, 3) & "',check_type='" & cmbchktype.Text & "',check_date='" & Format(ccheckdate.Text, "dd/mm/yyyy") & "',amount=" & txtamount.Text & " where d_code = '" & Trim(txtdcode.Text) & "' and slno=" & lblslno.Caption & ""
'''    cleargrid
''''ElseIf lblrjref.Caption <> "" Then
'''
'''    showcheck1.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''    If showcheck1.RecordCount > 0 Then
'''           Do While Not showcheck1.EOF
'''            With citicheck
'''                .Rows = .Rows + 1
'''                .Row = .Rows - 1
'''
'''                .Col = 0: .Text = showcheck1!slno
'''                .Col = 1: .Text = Trim(showcheck1!drawer) & ""
'''                .Col = 2: .Text = Format(showcheck1!drawee_bankcode) & ""
'''                .Col = 3: .Text = showcheck1!location_code & ""
'''                .Col = 4: .Text = Trim(showcheck1!branch_code) & ""
'''                .Col = 5: .Text = Format(showcheck1!check_date, "dd/mm/yyyy") & ""
'''                .Col = 6: .Text = Trim(showcheck1!check_type) & ""
'''                .Col = 7: .Text = Trim(showcheck1!check_no) & ""
'''                .Col = 8: .Text = Val(showcheck1!amount)
'''                .Col = 9: .Text = Trim(showcheck1!rejectref) & ""
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
'''
''''End If
'''
cleargrid
init_item

End Sub
Private Sub ccheckdate_GotFocus()
'If cmbchktype.Text = "" Then
 '   MsgBox "Must select CheckType"
  '  cmbchktype.SetFocus
'End If

End Sub

Private Sub ccheckdate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub ccheckdate_LostFocus()

If ccheckdate.Text = "__/__/____" Then
    MsgBox "Must enter check date"
    ccheckdate.SetFocus
    Exit Sub
End If

Dim inputdate As Date
Dim result As Integer
inputdate = ccheckdate.Text
result = DateDiff("m", Format(Date, "dd/mm/yyyy"), Format(inputdate, "dd/mm/yyyy"))
If result <= -6 Or inputdate > Format(Date, "dd/mm/yyyy") Then
    msg = "Invalid date,Do you want to Reject it?"
    style = vbYesNo + vbDefaultButton3 + vbInformation
    title = "Invalid Date"
    response = MsgBox(msg, style, title)
    If response = vbYes Then
        txtrjcode.Enabled = True
        reject = True
        txtrjcode.SetFocus
        If txtamount.Text = "" Then
         Exit Sub
        End If
        Exit Sub
    ElseIf response = vbNo Then
        txtrjcode.Enabled = False
        reject = False
        Exit Sub
    End If
Else
    txtrjcode.Enabled = False
    reject = False
    Exit Sub
End If

End Sub

Private Sub ccheckdate_Validate(Cancel As Boolean)
    If ccheckdate.Text = "__/__/____" Then
        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(ccheckdate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        Cancel = True
        Exit Sub
     End If
End Sub

Private Sub citicheck_Click()
selectgrid = True
If deldata = True Then
    bsave.Enabled = False
    bcancel.Enabled = True
    bquit.Enabled = False
    bdelete.Enabled = True
    If citicheck.Rows > 1 Then
        With citicheck
        .col = 0:  lblslno.Caption = Trim(.Text)
        saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and slno=" & lblslno.Caption & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
        If saveall.RecordCount > 0 Then
            txtdrawer.Text = Trim(saveall!drawer) & ""
            cmbdrbank.Text = Trim(saveall!drawee_bankcode) & ""
            cmbbranch.Text = Trim(saveall!Branch_Code) & ""
            cmblocation.Text = Trim(saveall!location_code) & ""
            cmbchktype.Text = Trim(saveall!check_type) & ""
            txtchkno.Text = Trim(saveall!check_no) & ""
            txtamount.Text = saveall!Amount
            ccheckdate.Text = Format(saveall!check_date, "dd/mm/yyyy") & ""
            TxtCheckRef.Text = IIf(IsNull(Left(Trim(saveall!Checkref), 7)) = True, 0, Left(Trim(saveall!Checkref), 7))
            TxtCheckRef1.Text = IIf(IsNull(Right(Trim(saveall!Checkref), 3)) = True, 0, Right(Trim(saveall!Checkref), 3))
            
        End If
        saveall.Close
        End With
    End If
End If
End Sub
Private Sub cmbbranch_DropDown()
If cmblocation.Text = "" Then
    branchadd.Open ("select branch_code,branch_name from branch where bank_code='" & Left(cmbdrbank.Text, 3) & "' and branch_name like '" & cmbbranch.Text & "%' order by branch_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
    cmbbranch.Clear
    If branchadd.RecordCount > 0 Then
        Do While Not branchadd.EOF
        cmbbranch.AddItem Trim(branchadd!Branch_Code) + Space(2) + ":" + Trim(branchadd!Branch_name)
        branchadd.MoveNext
        Loop
    End If
branchadd.Close
End If
If cmblocation.Text <> "" Then
Dim pp As String
pp = Trim(Mid(cmblocation.Text, 7))
    branchadd.Open ("select a.branch_code,a.branch_name,b.location_code from branch as a,location as b where a.bank_code='" & Left(cmbdrbank.Text, 3) & "' and a.location_code ='" & Left(cmblocation.Text, 3) & "' and a.location_code=b.location_code and b.location_name ='" & pp & "' and branch_name like '" & cmbbranch.Text & "%' order by branch_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
    cmbbranch.Clear
    If branchadd.RecordCount > 0 Then
        Do While Not branchadd.EOF
        cmbbranch.AddItem Trim(branchadd!Branch_Code) + Space(2) + ":" + Trim(branchadd!Branch_name)
        branchadd.MoveNext
        Loop
    End If
    branchadd.Close
End If
'branchadd.Open ("select branch_code,branch_name from branch where bank_code='" & Left(cmbdrbank.Text, 3) & "' and branch_name like '" & cmbbranch.Text & "%' order by branch_code"), oconn.Connection, adOpenKeyset, adLockOptimistic

'If branchadd.RecordCount > 0 Then
'cmbbranch.Clear
'  Do While Not branchadd.EOF
 '       cmbbranch.AddItem Trim(branchadd!branch_code) + Space(2) + ":" + Trim(branchadd!branch_name)
  '      branchadd.MoveNext
   '     Loop
'End If
'branchadd.Close
End Sub

Private Sub cmbbranch_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
Private Sub cmbchktype_DropDown()
cmbchktype.Clear
cmbchktype.AddItem "Savings"
cmbchktype.AddItem "Current"
cmbchktype.AddItem "DD"
cmbchktype.AddItem "MC"
cmbchktype.AddItem "CC"
cmbchktype.AddItem "STD"
End Sub

Private Sub cmbchktype_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub cmbclient_DropDown()
If clientadd.State = 1 Then clientadd.Close
clientadd.Open ("select distinct client_code,sub_client,acc_no,acc_name from client where acc_name like '" & cmbclient.Text & "%' order by client_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
open_flag = True
cmbclient.Clear
If clientadd.RecordCount > 0 Then

    Do While Not clientadd.EOF
        cmbclient.AddItem Trim(clientadd!client_code) + Trim(clientadd!sub_client) + Space(2) + ":" + Space(2) + Trim(clientadd!Acc_Name)
        clientadd.MoveNext
        Loop
End If
'clientadd.Close
End Sub
Private Sub cmbclient_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
Private Sub CmbClient_Validate(Cancel As Boolean)
If Not open_flag = True Then
   If clientadd.State = 1 Then clientadd.Close
   clientadd.Open ("select distinct client_code,sub_client,Acc_No,acc_name from client where client_code like substring('" & cmbclient.Text & "',1,4) and sub_client like substring('" & cmbclient.Text & "',5,6) order by client_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
End If
If clientadd.RecordCount > 0 Then
    clientadd.MoveFirst
  Do While Not clientadd.EOF
     If Left(cmbclient.Text, 6) = Trim(clientadd!client_code) + Trim(clientadd!sub_client) Then
        open_flag = False
          lblAcno = clientadd!Acc_No
        clientadd.Close
      
        Exit Sub
     End If
        clientadd.MoveNext
  Loop
  open_flag = False
  MsgBox "Invalid code", vbCritical
  Cancel = True
  clientadd.Close
Else
  open_flag = False
  MsgBox "Invalid code", vbCritical
  Cancel = True
  clientadd.Close
   
End If
End Sub

Private Sub cmbdlocation_DropDown()
If locationadd.State = 1 Then locationadd.Close
locationadd.Open ("select distinct location_code,location_name from location  where location_name like '" & cmbdlocation.Text & "%' order by location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
'locationadd.Open ("select distinct location_code,location_name from location  where location_code like substring ('" & cmbdlocation.Text & "',1,3) order by location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
open_flag = True
cmbdlocation.Clear
If locationadd.RecordCount > 0 Then
  Do While Not locationadd.EOF
        cmbdlocation.AddItem locationadd!location_code + Space(2) + ":" + Space(2) + locationadd!location_name
        locationadd.MoveNext
    Loop
End If
'locationadd.Close
End Sub
Private Sub cmbdlocation_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
Private Sub cmbdlocation_Validate(Cancel As Boolean)
If Not open_flag = True Then
   If locationadd.State = 1 Then locationadd.Close
'   locationadd.Open ("select distinct location_code,location_name from location   where location_name like '" & cmbdlocation.Text & "%' order by location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
   locationadd.Open ("select distinct location_code,location_name from location  where location_code like substring ('" & cmbdlocation.Text & "',1,3) order by location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
End If
If locationadd.RecordCount > 0 Then
    locationadd.MoveFirst
  Do While Not locationadd.EOF
     If Mid(cmbdlocation.Text, 1, 3) = locationadd!location_code Then
        open_flag = False
        locationadd.Close
        Exit Sub
     End If
        locationadd.MoveNext
  Loop
  open_flag = False
  MsgBox "Invalid location code", vbCritical
  Cancel = True
  locationadd.Close
Else
  open_flag = False
  MsgBox "Invalid location code", vbCritical
  Cancel = True
  locationadd.Close
   
End If
End Sub

Private Sub cmbdrbank_DropDown()
'bankcodeadd.Open ("select distinct a.bank_code,b.bank_name from branch as a,bank as b where a.bank_code=b.bank_code and b.bank_name like '" & cmbdrbank.Text & "%' order by a.bank_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
lblzone.Caption = ""
cmbbranch.Text = ""
cmblocation.Text = ""
If bankcodeadd.State = 1 Then bankcodeadd.Close
bankcodeadd.Open ("select distinct a.bank_code,b.bank_name from branch as a,bank as b where a.bank_code=b.bank_code and b.bank_name like '" & cmbdrbank.Text & "%' order by a.bank_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
open_flag = True
cmbdrbank.Clear
If bankcodeadd.RecordCount > 0 Then
  
    Do While Not bankcodeadd.EOF
        cmbdrbank.AddItem bankcodeadd!Bank_code + Space(2) + ":" + Space(2) + bankcodeadd!Bank_name
        bankcodeadd.MoveNext
    Loop
End If
'bankcodeadd.Close
End Sub

Private Sub cmbdrbank_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
cmbbranch.Text = ""
cmblocation.Text = ""
End Sub

Private Sub cmbdrbank_Validate(Cancel As Boolean)
    If Not open_flag = True Then
   If bankcodeadd.State = 1 Then bankcodeadd.Close
'   locationadd.Open ("select distinct location_code,location_name from location   where location_name like '" & cmbdlocation.Text & "%' order by location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
   bankcodeadd.Open ("select distinct a.bank_code,b.bank_name from branch as a,bank as b where a.bank_code=b.bank_code and b.bank_code like substring('" & cmbdrbank.Text & "',1,3) order by a.bank_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
End If
If bankcodeadd.RecordCount > 0 Then
    bankcodeadd.MoveFirst
  Do While Not bankcodeadd.EOF
     If Mid(cmbdrbank.Text, 1, 3) = bankcodeadd!Bank_code Then
        open_flag = False
        bankcodeadd.Close
        Exit Sub
     End If
        bankcodeadd.MoveNext
  Loop
  open_flag = False
  MsgBox "Invalid  code", vbCritical
  Cancel = True
  bankcodeadd.Close
Else
  open_flag = False
  MsgBox "Invalid  code", vbCritical
  Cancel = True
  bankcodeadd.Close
End If
End Sub
Private Sub cmblocation_Click()
zonechk.Open ("select a.clearing_zone,b.zone_name from branch as a,zone as b where a.clearing_zone=b.zone_code and a.bank_code='" & Left(cmbdrbank.Text, 3) & "' and a.branch_code='" & Left(cmbbranch.Text, 3) & "' and a.location_code='" & Left(cmblocation.Text, 3) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If zonechk.RecordCount > 0 Then
    lblzone.Caption = zonechk!clearing_zone + ":" + Space(2) + zonechk!zone_name
ElseIf zonechk.RecordCount = 0 Then
    lblzone.Caption = ""
End If
zonechk.Close


End Sub

Private Sub cmblocation_DropDown()

If cmbbranch.Text <> "" Then
    Dim kk As String
    kk = Mid(cmbbranch.Text, 7)
    locationadd.Open ("select distinct a.location_code,b.location_name from branch as a,location as b  where a.location_code=b.location_code and a.bank_code='" & Left(cmbdrbank.Text, 3) & "' and a.branch_code='" & Left(cmbbranch.Text, 3) & "' and a.branch_name='" & kk & "' and b.location_name like '" & cmblocation.Text & "%' order by a.location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
    cmblocation.Clear
    If locationadd.RecordCount > 0 Then
        Do While Not locationadd.EOF
        cmblocation.AddItem locationadd!location_code + Space(2) + ":" + Space(2) + locationadd!location_name
        locationadd.MoveNext
    Loop
    End If
    locationadd.Close
End If
If cmbbranch.Text = "" Then
    locationadd.Open ("select distinct a.location_code,b.location_name from branch as a,location as b  where a.location_code=b.location_code and a.bank_code='" & Left(cmbdrbank.Text, 3) & "' and b.location_name like '" & cmblocation.Text & "%' order by a.location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
    cmblocation.Clear
    If locationadd.RecordCount > 0 Then
        Do While Not locationadd.EOF
        cmblocation.AddItem locationadd!location_code + Space(2) + ":" + Space(2) + locationadd!location_name
        locationadd.MoveNext
    Loop
    End If
    locationadd.Close
End If

End Sub

Private Sub cmblocation_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub cmblocation_Validate(Cancel As Boolean)
zonechk.Open ("select a.clearing_zone,b.zone_name from branch as a,zone as b where a.clearing_zone=b.zone_code and a.bank_code='" & Left(cmbdrbank.Text, 3) & "' and a.branch_code='" & Left(cmbbranch.Text, 3) & "' and a.location_code='" & Left(cmblocation.Text, 3) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If zonechk.RecordCount > 0 Then
    lblzone.Caption = zonechk!clearing_zone + ":" + Space(2) + zonechk!zone_name
ElseIf zonechk.RecordCount = 0 Then
    lblzone.Caption = ""
End If
zonechk.Close
End Sub

Private Sub Command1_Click()
''If Not editdata Then
''If Trim(txtamount.Text) = "" Then
''    MsgBox "Must enter amount"
''    txtamount.SetFocus
''    Exit Sub
''End If
''newslno.Open ("select *  from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If newslno.RecordCount = 0 Then
''        xx = "0000001"
''    ElseIf newslno.RecordCount <> 0 Then
''        newslno.MoveLast
''        xx = CInt(newslno!slno) + 1
''    End If
''newslno.Close
''If reject = True Then
''    'Set rs = mydb.OpenRecordset("select * from signcard where branchcode='" & lblbcode & "' and Acc_No ='" & TnAccountNo & "'", dbOpenDynaset)
''    savereject.Open ("select * from reject"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    'If savereject.RecordCount = 0 Then
''        savereject.AddNew
''        savereject!reject_code = Trim(txtrjcode.Text)
''        savereject!rejectref = xx1
''        savereject.Update
''    'End If
''    savereject.Close
''    Dim intcounter As Integer
''    'If Not editdata And Not editchkamt And Not editchkno Then
''
''
''    saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
''     If saveall.RecordCount = 0 Then
''        With saveall
''        .AddNew
''        !D_Code = Trim(txtdcode.Text)
''        !Client_Code = Left(cmbclient.Text, 6)
''        !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
''        !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
''        !dlocation_code = Left(cmbdlocation.Text, 3)
''        !customer_ref = Trim(txtref.Text)
''        !slno = xx
''        !rejectref = CStr(xx1)
''        !check_no = Trim(txtchkno.Text)
''        !drawee_bankcode = Left(cmbdrbank.Text, 3)
''        !location_code = Left(cmblocation.Text, 3)
''        !branch_code = Left(cmbbranch.Text, 3)
''        !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
''        !check_type = cmbchktype.Text
''        !drawer = Trim(txtdrawer.Text)
''        !amount = Val(txtamount.Text)
''        .Update
''        End With
''
''        End If
''        saveall.Close
''
''    cleargrid
''    showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If showcheck.RecordCount > 0 Then
''            Do While Not showcheck.EOF
''                With citicheck
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''               .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!drawer) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!check_no) & ""
''                .Col = 8: .Text = Val(showcheck!amount)
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                ccheckdate.Text = "__/__/____"
''                txtrjcode.Text = ""
''                txtchkno.Text = ""
''                txtamount.Text = ""
''                ccheckdate.SetFocus
''End If
''showcheck.Close
''End If
'''reject = False
''If Not reject Then
''    saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
''     If saveall.RecordCount = 0 Then
''        With saveall
''        .AddNew
''        !D_Code = Trim(txtdcode.Text)
''        !Client_Code = Left(cmbclient.Text, 6)
''        !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
''        !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
''        !dlocation_code = Left(cmbdlocation.Text, 3)
''        !customer_ref = Trim(txtref.Text)
''        !slno = xx
''        !check_no = Trim(txtchkno.Text)
''        !drawee_bankcode = Left(cmbdrbank.Text, 3)
''        !location_code = Left(cmblocation.Text, 3)
''        !branch_code = Left(cmbbranch.Text, 3)
''        !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
''        !check_type = cmbchktype.Text
''        !drawer = Trim(txtdrawer.Text)
''        !amount = Val(txtamount.Text)
''        .Update
''        End With
''        End If
''        saveall.Close
''
''    cleargrid
''    showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If showcheck.RecordCount > 0 Then
''        Do While Not showcheck.EOF
''                With citicheck
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''               .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!check_no) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!drawer) & ""
''                .Col = 8: .Text = Val(showcheck!amount)
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                ccheckdate.Text = "__/__/____"
''
''                txtrjcode.Text = ""
''                txtchkno.Text = ""
''                txtamount.Text = ""
''                ccheckdate.SetFocus
''End If
''showcheck.Close
''End If
''reject = False
''End If
End Sub

Private Sub Command2_Click()
''If Not editdata Then
''If Trim(txtamount.Text) = "" Then
''    MsgBox "Must enter amount"
''    'Cancel = True
''    txtamount.SetFocus
''    Exit Sub
''End If
''newslno.Open ("select *  from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If newslno.RecordCount = 0 Then
''        xx = 1
''    ElseIf newslno.RecordCount <> 0 Then
''        newslno.MoveLast
''        xx = newslno!slno + 1
''    End If
''newslno.Close
''
''If reject = True Then
''
''
''    'Set rs = mydb.OpenRecordset("select * from signcard where branchcode='" & lblbcode & "' and Acc_No ='" & TnAccountNo & "'", dbOpenDynaset)
''
''
''    savereject.Open ("select * from reject"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    'If savereject.RecordCount = 0 Then
''        savereject.AddNew
''        savereject!reject_code = Trim(txtrjcode.Text)
''        savereject!rejectref = xx1
''        savereject.Update
''    'End If
''    savereject.Close
''    Dim intcounter As Integer
''    'If Not editdata And Not editchkamt And Not editchkno Then
''
''
''    saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
''     If saveall.RecordCount = 0 Then
''        With saveall
''        .AddNew
''        !D_Code = Trim(txtdcode.Text)
''        !Client_Code = Left(cmbclient.Text, 6)
''        !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
''        !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
''        !dlocation_code = Left(cmbdlocation.Text, 3)
''        !customer_ref = Trim(txtref.Text)
''        !slno = xx
''        !rejectref = xx1
''        !check_no = Trim(txtchkno.Text)
''        !drawee_bankcode = Left(cmbdrbank.Text, 3)
''        !location_code = Left(cmblocation.Text, 3)
''        !branch_code = Left(cmbbranch.Text, 3)
''        !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
''        !check_type = cmbchktype.Text
''        !drawer = Trim(txtdrawer.Text)
''        !amount = Val(txtamount.Text)
''        .Update
''        End With
''
''        End If
''        saveall.Close
''
''cleargrid
''showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
''If showcheck.RecordCount > 0 Then
''    Do While Not showcheck.EOF
''                With citicheck
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''               .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!drawer) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!check_no) & ""
''                .Col = 8: .Text = Val(showcheck!amount)
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                ccheckdate.Text = "__/__/____"
''                txtrjcode.Text = ""
''                txtchkno.Text = ""
''                txtamount.Text = ""
''                ccheckdate.SetFocus
''End If
''showcheck.Close
''End If
'''reject = False
''If Not reject Then
''
'''zonechk.Open "select a.* from ccheck as a ,branch as b where a.drawee_bankcode=b.bank_code and a.branch_code=b.branch_code and a.location_code=b.location_code and  b.clearing_zone ="" select a.* from ccheck as a ,branch as b where a.drawee_bankcode=b.bank_code and a.branch_code=b.branch_code and a.location_code=b.location_code and  b.clearing_zone ="" and a.rejectref is null"
''
'''zonechk.Open ("select a.rejectref,b.clearing_zone from ccheck as a,branch as b where a.drawee_bankcode=b.bank_code and a.branch_code=b.branch_code and a.location_code=b.location_code and b.clearing_zone='" & Left(lblzone.Caption, 3) & "' and a.rejectref is null"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''zonechk.Open ("select zoneref  from ccheck where drawee_bankcode='" & Left(cmbdrbank.Text, 3) & "' and branch_code='" & Left(cmbbranch.Text, 3) & "' and location_code='" & Left(cmblocation.Text, 3) & "' and zoneref='" & Left(lblzone.Caption, 3) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If lblzone.Caption <> "" Then
''        zonechk.Open ("select a.zoneref,b.clearing_zone  from ccheck as a,branch as b where a.drawee_bankcode='" & Left(cmbdrbank.Text, 3) & "' and a.branch_code='" & Left(cmbbranch.Text, 3) & "' and a.location_code='" & Left(cmblocation.Text, 3) & "' and b.clearing_zone='" & Left(lblzone.Caption, 3) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''        Dim cz1 As Integer
''        Dim cz2 As String
''
''        If zonechk.RecordCount = 0 Then
''            cz = "C000000001"
''        ElseIf zonechk.RecordCount <> 0 Then
''            zonechk.MoveLast
''            cz1 = CInt(Mid(Trim(zonechk!zoneref), 8, 3)) + 1
''            If Len(CStr(cz1)) = 1 Then
''                cz = Mid(zonechk!zoneref, 1, 9) & CStr(cz1)
''            ElseIf Len(CStr(cz1)) = 2 Then
''                cz = Mid(zonechk!zoneref, 1, 8) & CStr(cz1)
''            ElseIf Len(CStr(cz1)) = 3 Then
''                cz = Mid(zonechk!zoneref, 1, 7) & CStr(cz1)
''            End If
''
''        End If
''        zonechk.Close
''
''        saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
''        If saveall.RecordCount = 0 Then
''            With saveall
''            .AddNew
''            !D_Code = Trim(txtdcode.Text)
''            !Client_Code = Left(cmbclient.Text, 6)
''            !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
''            !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
''            !dlocation_code = Left(cmbdlocation.Text, 3)
''            !customer_ref = Trim(txtref.Text)
''            !slno = xx
''            !check_no = Trim(txtchkno.Text)
''            !drawee_bankcode = Left(cmbdrbank.Text, 3)
''            !location_code = Left(cmblocation.Text, 3)
''            !branch_code = Left(cmbbranch.Text, 3)
''            !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
''            !check_type = cmbchktype.Text
''            !drawer = Trim(txtdrawer.Text)
''            !amount = Val(txtamount.Text)
''            !zoneref = cz
''            .Update
''            End With
''        End If
''        saveall.Close
''
''    cleargrid
''    showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If showcheck.RecordCount > 0 Then
''        Do While Not showcheck.EOF
''                With citicheck
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''               .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!check_no) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!drawer) & ""
''                .Col = 8: .Text = Val(showcheck!amount)
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                ccheckdate.Text = "__/__/____"
''
''                txtrjcode.Text = ""
''                txtchkno.Text = ""
''                txtamount.Text = ""
''                ccheckdate.SetFocus
''        End If
''        showcheck.Close
''    End If
''
''    If lblzone.Caption = "" Then
''    Dim tt As String
''    Dim tt1 As String
''    tt = Format(Date, "dd/mm/yyyy")
''    tt1 = Right(tt, 2)
''
''        zonechk.Open ("select nonzoneref from ccheck"), oconn.Connection, adOpenKeyset, adLockOptimistic
''        If zonechk.RecordCount = 0 Then
''          pp = tt1 + "00001"
''        ElseIf zonechk.RecordCount <> 0 Then
''            zonechk.MoveLast
''           pp = (zonechk!nonzoneref) + 1
''        End If
''       zonechk.Close
''
''
''
''
''        saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
''        If saveall.RecordCount = 0 Then
''            With saveall
''            .AddNew
''            !D_Code = Trim(txtdcode.Text)
''            !Client_Code = Left(cmbclient.Text, 6)
''            !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
''            !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
''            !dlocation_code = Left(cmbdlocation.Text, 3)
''            !customer_ref = Trim(txtref.Text)
''            !slno = xx
''            !check_no = Trim(txtchkno.Text)
''            !drawee_bankcode = Left(cmbdrbank.Text, 3)
''            !location_code = Left(cmblocation.Text, 3)
''            !branch_code = Left(cmbbranch.Text, 3)
''            !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
''            !check_type = cmbchktype.Text
''            !drawer = Trim(txtdrawer.Text)
''            !nonzoneref = pp
''            !amount = Val(txtamount.Text)
''            .Update
''            End With
''        End If
''        saveall.Close
''
''    cleargrid
''    showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
''    If showcheck.RecordCount > 0 Then
''        Do While Not showcheck.EOF
''                With citicheck
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''               .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!check_no) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!drawer) & ""
''                .Col = 8: .Text = Val(showcheck!amount)
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                ccheckdate.Text = "__/__/____"
''
''                txtrjcode.Text = ""
''                txtchkno.Text = ""
''                txtamount.Text = ""
''                ccheckdate.SetFocus
''        End If
''        showcheck.Close
''End If
''End If
''End If
''reject = False
''
End Sub

Private Sub Command3_Click()
''If Len(txtdcode.Text) < 7 Then
''    MsgBox "Must enter 7 digits"
''    txtdcode.Text = ""
''    Cancel = True
''    Exit Sub
''End If
''cleargrid
''editdata = False
''editchno = False
''
''showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'  order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
''If showcheck.RecordCount > 0 Then
''    msg = "Duplicate Data,Do you want to edit or delete?"
''    style = vbYesNo + vbDefaultButton2 + vbInformation
''    title = "Duplicate Data"
''    response = MsgBox(msg, style, title)
''    If response = vbYes Then
''        dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''        If dssave.RecordCount > 0 Then
''            txttcheck.Text = Trim(dssave!total_chkno) & ""
''            txttamount.Text = dssave!total_chkamt & ""
''            'txttchk1 = dssave!total_chkamt
''        End If
''
''        dssave.Close
''        editdata = True
''        newsave = True
''        deldata = True
''        bsave.Enabled = False
''        bcancel.Enabled = True
''        bdelete.Enabled = True
''        bquit.Enabled = False
''        appendcheck = True
''        cmbclient.Text = Trim(showcheck!Client_Code)
''        cslipdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy")
''        cvaluedate.Text = Format(showcheck!value_date, "dd/mm/yyyy")
''        cmbdlocation.Text = Trim(showcheck!dlocation_code)
''        txtref.Text = Trim(showcheck!customer_ref)
''
''
''        Do While Not showcheck.EOF
''            With citicheck
''
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''
''                .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!drawer) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!check_no) & ""
''                .Col = 8: .Text = Format(showcheck!amount, "#,##,##,##,##0.00")
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                txttamount.SetFocus
''    ElseIf response = vbNo Then
''        editdata = False
''        deldata = False
''        msg = "Duplicate Data,Want to Append?"
''        style = vbYesNo + vbDefaultButton2 + vbInformation
''        title = "Duplicate Data"
''        response = MsgBox(msg, style, title)
''        If response = vbYes Then
''            appenddata = True
''            cmbclient.SetFocus
''            dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''            If dssave.RecordCount > 0 Then
''                txttcheck.Text = Trim(dssave!total_chkno) & ""
''                txttamount.Text = dssave!total_chkamt & ""
''                'txttchk1 = dssave!total_chkamt
''            End If
''            dssave.Close
''            cmbclient.Text = Trim(showcheck!Client_Code)
''            cslipdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy")
''            cvaluedate.Text = Format(showcheck!value_date, "dd/mm/yyyy")
''            cmbdlocation.Text = Trim(showcheck!dlocation_code)
''            txtref.Text = Trim(showcheck!customer_ref)
''
''
''            Do While Not showcheck.EOF
''            With citicheck
''
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''
''                .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!drawer) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!check_no) & ""
''                .Col = 8: .Text = Format(showcheck!amount, "#,##,##,##,##0.00")
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''
''        End If
''Else
''    bsave.Enabled = True
''    bcancel.Enabled = True
''    bquit.Enabled = False
''    bdelete.Enabled = False
''End If
''End If
''showcheck.Close
''
End Sub

Private Sub Command4_Click()
''If Trim(txtdcode.Text) <> "" Then
''    If Len(txtdcode.Text) < 7 Then
''        MsgBox "Must enter 7 digits"
''        txtdcode.Text = ""
''        txtdcode.SetFocus
''        Exit Sub
''    End If
''End If
''cleargrid
''deldata = False
''appenddata = False
''
''showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'  order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
''If showcheck.RecordCount > 0 Then
''    msg = "Duplicate Data,Do you want to  delete?"
''    style = vbYesNo + vbDefaultButton2 + vbInformation
''    title = "Duplicate Data"
''    response = MsgBox(msg, style, title)
''    If response = vbYes Then
''        dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''        If dssave.RecordCount > 0 Then
''            txttcheck.Text = Trim(dssave!total_chkno) & ""
''            txttamount.Text = dssave!total_chkamt & ""
''            'txttchk1 = dssave!total_chkamt
''        End If
''
''        dssave.Close
''        'editdata = True
''        newsave = True
''        deldata = True
''        bsave.Enabled = False
''        bcancel.Enabled = True
''        bdelete.Enabled = True
''        bquit.Enabled = False
''        'appendcheck = True
''        cmbclient.Text = Trim(showcheck!Client_Code)
''        cslipdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy")
''        cvaluedate.Text = Format(showcheck!value_date, "dd/mm/yyyy")
''        cmbdlocation.Text = Trim(showcheck!dlocation_code)
''        txtref.Text = Trim(showcheck!customer_ref)
''
''
''        Do While Not showcheck.EOF
''            With citicheck
''
''                .Rows = .Rows + 1
''                .Row = .Rows - 1
''
''                .Col = 0: .Text = showcheck!slno
''                .Col = 1: .Text = Trim(showcheck!drawer) & ""
''                .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                .Col = 3: .Text = showcheck!location_code & ""
''                .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                .Col = 7: .Text = Trim(showcheck!check_no) & ""
''                .Col = 8: .Text = Format(showcheck!amount, "#,##,##,##,##0.00")
''                .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                End With
''                showcheck.MoveNext
''                Loop
''                txttamount.SetFocus
''        ElseIf response = vbNo Then
''            appenddata = False
''            deldata = False
''            msg = "Duplicate Data,Want to Append?"
''            style = vbYesNo + vbDefaultButton2 + vbInformation
''            title = "Duplicate Data"
''            response = MsgBox(msg, style, title)
''            If response = vbYes Then
''                appenddata = True
''                cmbclient.SetFocus
''                dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
''                If dssave.RecordCount > 0 Then
''                    txttcheck.Text = Trim(dssave!total_chkno) & ""
''                    txttamount.Text = dssave!total_chkamt & ""
''                    'txttchk1 = dssave!total_chkamt
''                End If
''                dssave.Close
''                cmbclient.Text = Trim(showcheck!Client_Code)
''                cslipdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy")
''                cvaluedate.Text = Format(showcheck!value_date, "dd/mm/yyyy")
''                cmbdlocation.Text = Trim(showcheck!dlocation_code)
''                txtref.Text = Trim(showcheck!customer_ref)
''
''
''                Do While Not showcheck.EOF
''                With citicheck
''
''                    .Rows = .Rows + 1
''                    .Row = .Rows - 1
''
''                    .Col = 0: .Text = showcheck!slno
''                    .Col = 1: .Text = Trim(showcheck!drawer) & ""
''                    .Col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
''                    .Col = 3: .Text = showcheck!location_code & ""
''                    .Col = 4: .Text = Trim(showcheck!branch_code) & ""
''                    .Col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
''                    .Col = 6: .Text = Trim(showcheck!check_type) & ""
''                    .Col = 7: .Text = Trim(showcheck!check_no) & ""
''                    .Col = 8: .Text = Format(showcheck!amount, "#,##,##,##,##0.00")
''                    .Col = 9: .Text = Trim(showcheck!rejectref) & ""
''                    End With
''                showcheck.MoveNext
''                Loop
''             ElseIf response = vbNo Then
''
''        End If
''Else
''    bsave.Enabled = True
''    bcancel.Enabled = True
''    bquit.Enabled = False
''    bdelete.Enabled = False
''End If
''End If
''showcheck.Close
''
''
''
End Sub

Private Sub cslipdate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub cslipdate_Validate(Cancel As Boolean)
''    If cslipdate.Text = "__/__/____" Then
''        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
''        Cancel = True
''        Exit Sub
''     End If
'     If oDate.Validate(cslipdate) = False Then
'        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
End Sub

Private Sub cvaluedate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub cvaluedate_Validate(Cancel As Boolean)
''    If cvaluedate.Text = "__/__/____" Then
''        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
''        Cancel = True
''        Exit Sub
''     End If
'     If oDate.Validate(cvaluedate) = False Then
'        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
End Sub

Private Sub Form_Load()
Move (frmMain.Height - Height) / 2, (frmMain.width - width) / 2
cleargrid
txtrjcode.Enabled = False
bsave.Enabled = False
bcancel.Enabled = False
bdelete.Enabled = False
bquit.Enabled = True
bedit.Enabled = False

End Sub



Private Sub TxtAmount_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtamount_LostFocus()
Dim Flag As String
bsave.Enabled = True
    ''Validation for new customer refno which is must entry field for those client
    ''whose credit type is "R"
    
    ''********************************
    '*****************check for customer ref no
     Set rs = ocon.GetResultset("select distinct b.client_code+b.sub_client,b.cashcrtyp " & _
     " from dschedule a,client b Where B.client_code + B.sub_client = A.client_code " & _
     "  and  d_code='" & (txtdcode.Text) & "' and b.cashcrtyp='R' ")
     If Not (rs.BOF And rs.EOF) Then
        If Trim(TxtCheckRef.Text) = "" Then
          MsgBox "This client customer refno can not be blank", vbOKOnly
          Exit Sub
        End If
        
     End If
     
'********************************************************
If Not deldata Or appenddata Then
    If Trim(txtdcode.Text) = "" Then
        MsgBox "Must enter Deposit_Code"
        txtdcode.SetFocus
        Exit Sub
    End If
    
    If cmbclient.Text = "" Then
        MsgBox "Must select client_code"
        cmbclient.SetFocus
        Exit Sub
    End If
    If cslipdate.Text = "__/__/____" Then
        MsgBox "Must enter SlipDate"
        cslipdate.SetFocus
        Exit Sub
    End If
    If oDate.Validate(cslipdate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        cslipdate.SetFocus
        Exit Sub
    End If

    If cvaluedate.Text = "__/__/____" Then
        MsgBox "Must enter valueDate"
        cvaluedate.SetFocus
        Exit Sub
    End If
    If oDate.Validate(cvaluedate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        cvaluedate.SetFocus
        Exit Sub
    End If
    If cmbdlocation.Text = "" Then
        MsgBox "Must select Deposit location"
        cmbdlocation.SetFocus
        Exit Sub
    End If
    If Trim(txttcheck.Text) = "" Then
       MsgBox "Must enter total checkno"
       txttcheck.SetFocus
       Exit Sub
    End If
    If Trim(txttamount.Text) = "" Then
        MsgBox "Must enter total checkamount"
        txttamount.SetFocus
        Exit Sub
    End If
    If Trim(txtdrawer.Text) = "" Then
        MsgBox "Must enter Drawer"
        txtdrawer.SetFocus
        Exit Sub
    End If
    If cmbdrbank.Text = "" Then
        MsgBox "Must select Drawee bank"
        cmbdrbank.SetFocus
        Exit Sub
    End If
    If cmbbranch.Text = "" Then
        MsgBox "Must select Drawee branch"
        cmbbranch.SetFocus
        Exit Sub
    End If
    If cmblocation.Text = "" Then
        MsgBox "Must select Drawee location"
        cmblocation.SetFocus
        Exit Sub
    End If
    
    
    If Trim(txtchkno.Text) = "" Then
        MsgBox "Must enter Check No"
        txtchkno.SetFocus
        Exit Sub
    End If
    
    If ccheckdate.Text = "__/__/____" Then
    MsgBox "Must enter check date"
    ccheckdate.SetFocus
    Exit Sub
    End If
    
    If oDate.Validate(ccheckdate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        ccheckdate.SetFocus
        Exit Sub
    End If

If reject = True Then
 If Trim(txtamount.Text) = "" Then
   txtrjcode.SetFocus
    Exit Sub
 End If
End If
If Not reject Then
If Trim(txtamount.Text) = "" Then
    MsgBox "Must enter amount"
    'Cancel = True
    txtamount.SetFocus
    Exit Sub
End If
End If
newslno.Open ("select isnull(max(slno),0)slno  from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If newslno.RecordCount = 0 Then
        xx = 1
    ElseIf newslno.RecordCount <> 0 Then
        newslno.MoveLast
        xx = newslno!slno + 1
    End If
newslno.Close

If reject = True Then

            savereject.Open ("select * from reject"), oconn.Connection, adOpenKeyset, adLockOptimistic
            
                savereject.AddNew
                savereject!reject_code = Trim(txtrjcode.Text)
                savereject!rejectref = CStr(xx1)
                savereject.Update
            
            savereject.Close
            
            saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
             If saveall.RecordCount = 0 Or saveall.RecordCount > 0 Then
                With saveall
                .AddNew
                !d_code = Trim(txtdcode.Text)
                !client_code = Trim(Left(cmbclient.Text, 6))
                !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
                !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
                !dlocation_code = Left(cmbdlocation.Text, 3)
                !customer_ref = Trim(txtref.Text)
                !slno = xx
                !rejectref = xx1
                !check_no = Trim(txtchkno.Text)
                !drawee_bankcode = Left(cmbdrbank.Text, 3)
                !location_code = Left(cmblocation.Text, 3)
                !Branch_Code = Left(cmbbranch.Text, 3)
                !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
                !check_type = cmbchktype.Text
                !drawer = Trim(txtdrawer.Text)
                !Status = "J"
                !Amount = Val(txtamount.Text)
                                
             '********** new add entry_date *****22-02-2000**********
                !Entry_date = Format(Date, "dd/mm/yyyy")
                ''******New field added 23-04-2005
                Dim sRefno As String
                sRefno = Trim(TxtCheckRef) + Trim(TxtCheckRef1)
                !Checkref = Trim(sRefno)
                
                .Update
                End With
                
                End If
                saveall.Close
                saveall.Open ("select sum(amount) as tamt from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                    If saveall.RecordCount > 0 Then
                        lblchkstatus.Caption = Format(saveall!tamt, "#,##,##,##,##0.00")
                    End If
                saveall.Close
        cleargrid
        showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
        If showcheck.RecordCount > 0 Then
            Do While Not showcheck.EOF
                        With citicheck
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                       .col = 0: .Text = showcheck!slno
                        .col = 1: .Text = Trim(showcheck!drawer) & ""
                        .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                        .col = 3: .Text = showcheck!location_code & ""
                        .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                        .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                        .col = 6: .Text = Trim(showcheck!check_type) & ""
                        .col = 7: .Text = Trim(showcheck!check_no) & ""
                        .col = 8: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00")
                        .col = 9: .Text = Trim(showcheck!rejectref) & ""
                        .col = 10: .Text = Trim(showcheck!Checkref) & ""
                        End With
                        showcheck.MoveNext
                        Loop
                        txtdrawer.Text = ""
                        cmbbranch.Clear
                        cmblocation.Clear
                        lblzone.Caption = ""
                        ccheckdate.Text = "__/__/____"
                        txtrjcode.Text = ""
                        txtchkno.Text = ""
                        txtamount.Text = ""
                        TxtCheckRef1.Text = ""
                      
                        txtdrawer.SetFocus
        End If
        showcheck.Close
End If

'****/Some clients such as Berger may deposit check which can be drawn on bank which is under
'clearing zone.But due to the client interest the check will not be treated as
'citispeed and the check will be cleared as normal collection.The modification date
'December 02,2003.
Set rs = Nothing
Set rs = ocon.GetResultset("select * from client where client_code+sub_client='" & Trim(Left(cmbclient.Text, 6)) & "'")
If Not (rs.BOF And rs.EOF) Then
    Flag = IIf(IsNull(rs!CheckCrTyp) = True, 0, 1)
End If

If Not reject Then
  If Flag = "1" Then
   CheckClient
  Else
          If lblzone.Caption <> "" Then
              saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If saveall.RecordCount = 0 Or saveall.RecordCount > 0 Then
                    With saveall
                    .AddNew
                    !d_code = Trim(txtdcode.Text)
                    !client_code = Trim(Left(cmbclient.Text, 6))
                    !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
                    !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
                    !dlocation_code = Left(cmbdlocation.Text, 3)
                    !customer_ref = Trim(txtref.Text)
                    !slno = xx
                    !check_no = Trim(txtchkno.Text)
                    !drawee_bankcode = Left(cmbdrbank.Text, 3)
                    !location_code = Left(cmblocation.Text, 3)
                    !Branch_Code = Left(cmbbranch.Text, 3)
                    !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
                    !check_type = cmbchktype.Text
                    !drawer = Trim(txtdrawer.Text)
                    !Amount = Val(txtamount.Text)
                    !zoneref = Left(lblzone.Caption, 3)
                    !Status = "O"
                    'Dim sRefno As String
                    sRefno = (TxtCheckRef.Text + TxtCheckRef1.Text)
                    !Checkref = Trim(sRefno)
                '***************new add entry_date ******* 22-02-2000**************
                    !Entry_date = Format(Date, "dd/mm/yyyy")
                    
                    .Update
                    End With
                End If
       
                saveall.Close
                
                saveall.Open ("select sum(amount) as tamt from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                    If saveall.RecordCount > 0 Then
                        lblchkstatus.Caption = Format(saveall!tamt, "#,##,##,##,##0.00")
                    End If
                saveall.Close
    
               cleargrid
               showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If showcheck.RecordCount > 0 Then
                    Do While Not showcheck.EOF
                            With citicheck
                            .Rows = .Rows + 1
                            .row = .Rows - 1
                           .col = 0: .Text = showcheck!slno
                            .col = 1: .Text = Trim(showcheck!drawer) & ""
                            .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                            .col = 3: .Text = showcheck!location_code & ""
                            .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                            .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                            .col = 6: .Text = Trim(showcheck!check_type) & ""
                            .col = 7: .Text = Trim(showcheck!check_no) & ""
                            .col = 8: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00")
                            .col = 9: .Text = Trim(showcheck!rejectref) & ""
                            End With
                            showcheck.MoveNext
                            Loop
                            txtdrawer.Text = ""
                            cmbbranch.Clear
                            cmblocation.Clear
                            lblzone.Caption = ""
                            ccheckdate.Text = "__/__/____"
                            txtrjcode.Text = ""
                            txtchkno.Text = ""
                            TxtCheckRef1.Text = ""
                            txtamount.Text = ""
                            txtdrawer.SetFocus
                    End If
        showcheck.Close
    End If
   
     If lblzone.Caption = "" Then

        Dim tt As String
        Dim tt1 As String

        tt = Format(Date, "dd/mm/yyyy")
        tt1 = Right(tt, 2)
        
        saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
             If saveall.RecordCount = 0 Then
                 With saveall
                 .AddNew
                 !d_code = Trim(txtdcode.Text)
                 !client_code = Trim(Left(cmbclient.Text, 6))
                 !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
                 !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
                 !dlocation_code = Left(cmbdlocation.Text, 3)
                 !customer_ref = Trim(txtref.Text)
                 !slno = xx
                 !check_no = Trim(txtchkno.Text)
                 !drawee_bankcode = Left(cmbdrbank.Text, 3)
                 !location_code = Left(cmblocation.Text, 3)
                 !Branch_Code = Left(cmbbranch.Text, 3)
                 !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
                 !check_type = cmbchktype.Text
                 !drawer = Trim(txtdrawer.Text)
                 !Amount = Val(txtamount.Text)
                 !Status = "O"
                 '''New Field
                   'Dim sRefno As String
                    sRefno = (TxtCheckRef.Text + TxtCheckRef1.Text)
                    !Checkref = Trim(sRefno)
                 
             '***************new add entry_date ******* 22-02-2000**************
                 !Entry_date = Format(Date, "dd/mm/yyyy")
             
                .Update
                 End With
             End If
            
                saveall.Close
                saveall.Open ("select sum(amount) as tamt from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                    If saveall.RecordCount > 0 Then
                        lblchkstatus.Caption = Format(saveall!tamt, "#,##,##,##,##0.00")
                    End If
                saveall.Close
    
         cleargrid
            showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
                  If showcheck.RecordCount > 0 Then
                        Do While Not showcheck.EOF
                                With citicheck
                                .Rows = .Rows + 1
                                .row = .Rows - 1
                               .col = 0: .Text = showcheck!slno
                                .col = 1: .Text = Trim(showcheck!drawer) & ""
                                .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                                .col = 3: .Text = showcheck!location_code & ""
                                .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                                .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                                .col = 6: .Text = Trim(showcheck!check_type) & ""
                                .col = 7: .Text = Trim(showcheck!check_no) & ""
                                .col = 8: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00")
                                .col = 9: .Text = Trim(showcheck!rejectref) & ""
                                .col = 10: .Text = Left(Trim(showcheck!Checkref), 7) + Right(Trim(showcheck!Checkref), 3) & ""
                                End With
                                showcheck.MoveNext
                                Loop
                                ccheckdate.Text = "__/__/____"
                                txtdrawer.Text = ""
                                cmbbranch.Clear
                                cmblocation.Clear
                                lblzone.Caption = ""
                                txtrjcode.Text = ""
                                txtchkno.Text = ""
                                txtamount.Text = ""
                                TxtCheckRef1.Text = ""
                                txtdrawer.SetFocus
                    End If
        showcheck.Close

End If
End If
End If 'For clearing zone check block
End If 'For reject if block
reject = False

End Sub



Private Sub TxtCheckRef_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub TxtCheckRef1_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
Private Sub txtchkno_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtdcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
bcancel.Enabled = True
bquit.Enabled = False
cmbclient.Clear
cslipdate.Text = "__/__/____"
cvaluedate = "__/__/____"
txtref.Text = ""
txttcheck.Text = ""
txttamount.Text = ""
txtdrawer.Text = ""
lblzone.Caption = ""
cmbdrbank.Clear
cmblocation.Clear
cmbdlocation.Clear
cmbbranch.Clear
lblchkstatus.Caption = ""
ccheckdate.Text = "__/__/____"
cmbchktype.Clear
txtchkno.Text = ""
txtamount.Text = ""
txtrjcode.Text = ""
TxtCheckRef = ""
TxtCheckRef1 = ""
cleargrid

End Sub

Private Sub txtdcode_LostFocus()
    


If Trim(txtdcode.Text) <> "" Then
    If Len(txtdcode.Text) < 7 Then
        MsgBox "Must enter 7 digits"
        txtdcode.Text = ""
        txtdcode.SetFocus
        Exit Sub
    End If
cleargrid
reject = False
deldata = False
appenddata = False
selectgrid = False

showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "'  order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
If showcheck.RecordCount > 0 Then
    msg = "Duplicate Data,Do you want delete?"
    style = vbYesNo + vbDefaultButton3 + vbInformation
    title = "Duplicate Data"
    response = MsgBox(msg, style, title)
    If response = vbYes Then
        dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
        If dssave.RecordCount > 0 Then
            txttcheck.Text = Trim(dssave!TOTAL_CHKNO) & ""
            txttamount.Text = Format(dssave!TOTAL_CHKAMT, "#,##,##,##,##0.00") & ""
            txttchk = dssave!TOTAL_CHKAMT
        End If
        
        dssave.Close
        editdata = True
        newsave = True
        deldata = True
        appenddate = False
        bsave.Enabled = False
        bcancel.Enabled = True
        bdelete.Enabled = True
        bedit.Enabled = True
        bquit.Enabled = False
        Frame2.Enabled = True
        Frame1.Enabled = False
        appendcheck = True
        cmbclient.Text = Trim(showcheck!client_code)
        cslipdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy")
        cvaluedate.Text = Format(showcheck!value_date, "dd/mm/yyyy")
        cmbdlocation.Text = Trim(showcheck!dlocation_code)
        txtref.Text = Trim(showcheck!customer_ref)
        
      
        Do While Not showcheck.EOF
            With citicheck
             
                .Rows = .Rows + 1
                .row = .Rows - 1
               
                .col = 0: .Text = showcheck!slno
                .col = 1: .Text = Trim(showcheck!drawer) & ""
                .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                .col = 3: .Text = showcheck!location_code & ""
                .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                .col = 6: .Text = Trim(showcheck!check_type) & ""
                .col = 7: .Text = Trim(showcheck!check_no) & ""
                .col = 8: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00")
                .col = 9: .Text = Trim(showcheck!rejectref) & ""
                If IsNull(showcheck!Checkref) = True Then
                .col = 10: .Text = Left(Trim(showcheck!Checkref), 7) + Right(Trim(showcheck!Checkref), 3) & ""
                Else
                .col = 10: .Text = 0
                End If
                End With
                showcheck.MoveNext
                Loop
                bedit.SetFocus
                showcheck.Close
                Exit Sub
        ElseIf response = vbNo Then
            
            msg = "Duplicate Data,Want to Append?"
            style = vbYesNo + vbDefaultButton3 + vbInformation
            title = "Duplicate Data"
            response = MsgBox(msg, style, title)
            If response = vbYes Then
                deldata = False
                appenddata = True
                Frame2.Enabled = False
                Frame1.Enabled = True
                bedit.Enabled = False
                'cmbclient.SetFocus
                txtdrawer.SetFocus
                dssave.Open ("select * from cchecktotal where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If dssave.RecordCount > 0 Then
                    txttcheck.Text = Trim(dssave!TOTAL_CHKNO) & ""
                    txttamount.Text = Format(dssave!TOTAL_CHKAMT, "#,##,##,##,##0.00") & ""
                    txttchk = dssave!TOTAL_CHKAMT
                End If
                dssave.Close
                cmbclient.Text = Trim(showcheck!client_code)
                cslipdate.Text = Format(showcheck!slip_date, "dd/mm/yyyy")
                cvaluedate.Text = Format(showcheck!value_date, "dd/mm/yyyy")
                cmbdlocation.Text = Trim(showcheck!dlocation_code)
                txtref.Text = Trim(showcheck!customer_ref)
                Do While Not showcheck.EOF
                With citicheck
             
                    .Rows = .Rows + 1
                    .row = .Rows - 1
               
                    .col = 0: .Text = showcheck!slno
                    .col = 1: .Text = Trim(showcheck!drawer) & ""
                    .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                    .col = 3: .Text = showcheck!location_code & ""
                    .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                    .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                    .col = 6: .Text = Trim(showcheck!check_type) & ""
                    .col = 7: .Text = Trim(showcheck!check_no) & ""
                    .col = 8: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00")
                    .col = 9: .Text = Trim(showcheck!rejectref) & ""
                   ' .col = 10: .Text = Trim(showcheck!CheckRef) & ""
                    If IsNull(showcheck!Checkref) = True Then
                        .col = 10: .Text = Left(Trim(showcheck!Checkref), 7) + Right(Trim(showcheck!Checkref), 3) & ""
                        Else
                        .col = 10: .Text = 0
                        End If
                    End With
                showcheck.MoveNext
                Loop
                dssave.Open ("select sum(amount) as tchk from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If dssave.RecordCount > 0 Then
                    lblchkstatus.Caption = Format(dssave!tchk, "#,##,##,##,##0.00")
                    lblamt = dssave!tchk
                End If
                dssave.Close
                showcheck.Close
                Exit Sub
            ElseIf response = vbNo Then
                    bsave.Enabled = False
                    bdelete.Enabled = False
                    bcancel.Enabled = False
                    bquit.Enabled = True
                    cmbclient.Clear
                    cslipdate.Text = "__/__/____"
                    cvaluedate = "__/__/____"
                    txtref.Text = ""
                    txttcheck.Text = ""
                    txttamount.Text = ""
                    txtdrawer.Text = ""
                    lblzone.Caption = ""
                    cmbdrbank.Clear
                    cmblocation.Clear
                    cmbdlocation.Clear
                    cmbbranch.Clear
                    ccheckdate.Text = "__/__/____"
                    cmbchktype.Clear
                    txtchkno.Text = ""
                    txtamount.Text = ""
                    txtrjcode.Text = ""
                    TxtCheckRef.Text = ""
                    cleargrid
                    bsave.Enabled = False
                    bquit.Enabled = True
                    bcancel.Enabled = False
                    bdelete.Enabled = False
                    txtdcode.Text = ""
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

Private Sub txtref_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtrjcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtrjcode_LostFocus()
'If txtrjcode.Text = "" Then
'    MsgBox "Must enter Reject Code"
'    txtrjcode.SetFocus
'    Exit Sub
'End If



rejectcheck.Open ("select reject_code,reject_reason from rtnrjct where reject_code='" & Trim(txtrjcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If rejectcheck.RecordCount = 0 Then
        MsgBox "Invalid RejectCode"
        txtrjcode.Text = ""
        txtrjcode.SetFocus
        rejectcheck.Close
        Exit Sub
    
ElseIf rejectcheck.RecordCount > 0 Then
    lblreason = rejectcheck!reject_reason
    
    style = vbYesNo + vbDefaultButton2 + vbInformation
    title = "Change Data"
    response = MsgBox(lblreason, style, title)
    If response = vbYes Then
        reject = True
        txtamount.SetFocus
        
    ElseIf response = vbNo Then
        txtrjcode.SetFocus
        rejectcheck.Close
        Exit Sub
    End If
End If
rejectcheck.Close
rejectcheck.Open ("select rejectref from reject"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If rejectcheck.RecordCount = 0 Then
        xx1 = Format("000000001")
    ElseIf rejectcheck.RecordCount <> 0 Then
        rejectcheck.MoveLast
        xx1 = Val(rejectcheck!rejectref) + 1
    End If
    rejectcheck.Close



End Sub

Private Sub txtrjcode_Validate(Cancel As Boolean)
'If Trim(txtrjcode.Text) = "" Then
 '   MsgBox "Must enter RejectCode"
  '  Cancel = True
   ' Exit Sub
'End If


End Sub

Private Sub txttamount_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txttamount_LostFocus()
txttchk = Val(txttamount.Text)
txttamount.Text = Format(txttamount.Text, "#,##,##,##,##0.00")
End Sub

Private Sub txttcheck_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
Public Sub cleargrid()
With citicheck
    .Clear
    .Rows = 1
    .Cols = 11
    .row = 0
    .ColWidth(0) = 800
    .ColWidth(1) = 1700
    .ColWidth(2) = 1000
    .ColWidth(3) = 1000
    .ColWidth(4) = 1000
    .ColWidth(5) = 1200
    .ColWidth(6) = 1000
    .ColWidth(7) = 1400
    .ColWidth(8) = 1200
    .ColWidth(9) = 1000
    .ColWidth(10) = 1000

    
    .col = 0: .Text = "Slno"
    .col = 1: .Text = "Drawer"
    .col = 2: .Text = "DraweeBank"
    .col = 3: .Text = "Location"
    .col = 4: .Text = "Branch"
    .col = 5: .Text = "CheckDate"
    .col = 6: .Text = "CheckType"
    .col = 7: .Text = "CheckNo"
    .col = 8: .Text = "Amount"
    .col = 9: .Text = "RejectRef"
    .col = 10:  Text = "CheckRef"
    
    
End With
    
    
End Sub

Public Sub init_item()
appenddata = False
deldata = False
selectgrid = False
Frame1.Enabled = True
Frame2.Enabled = True
txtdcode.Text = ""
cmbclient.Clear
lblchkstatus.Caption = ""
cslipdate.Text = "__/__/____"
cvaluedate = "__/__/____"
txtref.Text = ""
txttcheck.Text = ""
txttamount.Text = ""
txtdrawer.Text = ""
lblzone.Caption = ""
cmbdrbank.Clear
cmblocation.Clear
cmbdlocation.Clear
cmbbranch.Clear
ccheckdate.Text = "__/__/____"
cmbchktype.Clear
txtchkno.Text = ""
txtamount.Text = ""
txtrjcode.Text = ""
TxtCheckRef = ""
 TxtCheckRef1.Text = ""
cleargrid
bsave.Enabled = False
bquit.Enabled = True
bcancel.Enabled = False
bdelete.Enabled = False
bedit.Enabled = False
txtdcode.SetFocus
lblAcno = ""
End Sub

Private Sub CheckClient()
'****/Some clients such as Berger may deposit check which can be drawn on bank which is under
'clearing zone.But due to the client interest the check will not be treated as
'citispeed and the check will be cleared as normal collection.The modification date
'December 02,2003.
Set rs = Nothing
Set rs = ocon.GetResultset("select * from client where client_code+sub_client='" & Trim(Left(cmbclient.Text, 6)) & "'")
If Not (rs.BOF And rs.EOF) Then
    Flag = IIf(IsNull(rs!CheckCrTyp = ture), "0", "1")
End If

     If Flag = "1" Then
          
        Dim tt As String
        Dim tt1 As String

        tt = Format(Date, "dd/mm/yyyy")
        tt1 = Right(tt, 2)
        
        saveall.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' and  slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
             If saveall.RecordCount = 0 Then
                 With saveall
                 .AddNew
                 !d_code = Trim(txtdcode.Text)
                 !client_code = Trim(Left(cmbclient.Text, 6))
                 !slip_date = Format(cslipdate.Text, "dd/mm/yyyy")
                 !value_date = Format(cvaluedate.Text, "dd/mm/yyyy")
                 !dlocation_code = Left(cmbdlocation.Text, 3)
                 !customer_ref = Trim(txtref.Text)
                 !slno = xx
                 !check_no = Trim(txtchkno.Text)
                 !drawee_bankcode = Left(cmbdrbank.Text, 3)
                 !location_code = Left(cmblocation.Text, 3)
                 !Branch_Code = Left(cmbbranch.Text, 3)
                 !check_date = Format(ccheckdate.Text, "dd/mm/yyyy")
                 !check_type = cmbchktype.Text
                 !drawer = Trim(txtdrawer.Text)
                 !Amount = Val(txtamount.Text)
                 !Status = "O"
                 
             '***************new add entry_date ******* 22-02-2000**************
                 !Entry_date = Format(Date, "dd/mm/yyyy")
                 ''New requirement 23-04-2005
                     Dim sRefno As String
                    sRefno = (TxtCheckRef.Text + TxtCheckRef1.Text)
                    !Checkref = Trim(sRefno)
             
                .Update
                 End With
             End If
            
                saveall.Close
                saveall.Open ("select sum(amount) as tamt from ccheck where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                    If saveall.RecordCount > 0 Then
                        lblchkstatus.Caption = Format(saveall!tamt, "#,##,##,##,##0.00")
                    End If
                saveall.Close
    
         cleargrid
            showcheck.Open ("select * from ccheck where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
                  If showcheck.RecordCount > 0 Then
                        Do While Not showcheck.EOF
                                With citicheck
                                .Rows = .Rows + 1
                                .row = .Rows - 1
                               .col = 0: .Text = showcheck!slno
                                .col = 1: .Text = Trim(showcheck!drawer) & ""
                                .col = 2: .Text = Format(showcheck!drawee_bankcode) & ""
                                .col = 3: .Text = showcheck!location_code & ""
                                .col = 4: .Text = Trim(showcheck!Branch_Code) & ""
                                .col = 5: .Text = Format(showcheck!check_date, "dd/mm/yyyy") & ""
                                .col = 6: .Text = Trim(showcheck!check_type) & ""
                                .col = 7: .Text = Trim(showcheck!check_no) & ""
                                .col = 8: .Text = Format(showcheck!Amount, "#,##,##,##,##0.00")
                                .col = 9: .Text = Trim(showcheck!rejectref) & ""
                                If IsNull(showcheck!Checkref) = True Then
                                .col = 10: .Text = Left(Trim(showcheck!Checkref), 7) + Right(Trim(showcheck!Checkref), 3) & ""
                                Else
                                .col = 10: .Text = 0
                                End If
                                End With
                                showcheck.MoveNext
                                Loop
                                ccheckdate.Text = "__/__/____"
                                txtdrawer.Text = ""
                                cmbbranch.Clear
                                cmblocation.Clear
                                lblzone.Caption = ""
                                txtrjcode.Text = ""
                                txtchkno.Text = ""
                                txtamount.Text = ""
                                 TxtCheckRef1.Text = ""
                                txtdrawer.SetFocus
                    End If
        showcheck.Close

End If 'For reject if block

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
