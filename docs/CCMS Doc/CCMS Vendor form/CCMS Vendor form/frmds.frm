VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "MSMASK32.OCX"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Begin VB.Form frmds 
   Caption         =   "Deposit Schedule Information"
   ClientHeight    =   8475
   ClientLeft      =   165
   ClientTop       =   450
   ClientWidth     =   11340
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   8475
   ScaleWidth      =   11340
   WindowState     =   2  'Maximized
   Begin VB.PictureBox Picture1 
      BackColor       =   &H00C0C0C0&
      Height          =   7575
      Left            =   45
      ScaleHeight     =   7515
      ScaleWidth      =   11220
      TabIndex        =   15
      Top             =   825
      Width           =   11280
      Begin VB.CommandButton bquit 
         Caption         =   "Quit"
         CausesValidation=   0   'False
         Height          =   315
         Left            =   10320
         TabIndex        =   39
         Top             =   3480
         Width           =   780
      End
      Begin VB.CommandButton bcancel 
         Caption         =   "Cancel"
         CausesValidation=   0   'False
         Height          =   315
         Left            =   10320
         TabIndex        =   38
         Top             =   3120
         Width           =   780
      End
      Begin VB.CommandButton bsave 
         Caption         =   "Ok"
         Height          =   315
         Left            =   10320
         TabIndex        =   37
         Top             =   2400
         Width           =   780
      End
      Begin VB.CommandButton bdelete 
         Caption         =   "Delete"
         Height          =   315
         Left            =   10320
         TabIndex        =   36
         Top             =   2745
         Width           =   780
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00C0C0C0&
         Height          =   1740
         Left            =   120
         TabIndex        =   17
         Top             =   2280
         Width           =   9885
         Begin VB.CheckBox chkdtype 
            BackColor       =   &H008080FF&
            Caption         =   "Deposit Type"
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
            Left            =   5820
            TabIndex        =   9
            Top             =   120
            Width           =   1425
         End
         Begin VB.ComboBox cmbclient 
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   1440
            TabIndex        =   8
            Top             =   720
            Width           =   4740
         End
         Begin VB.TextBox txtdcode 
            ForeColor       =   &H00C00000&
            Height          =   330
            Left            =   1440
            MaxLength       =   7
            TabIndex        =   7
            Top             =   360
            Width           =   1770
         End
         Begin VB.TextBox txtcheck 
            ForeColor       =   &H00C00000&
            Height          =   315
            Left            =   7920
            MaxLength       =   17
            TabIndex        =   11
            Top             =   840
            Width           =   1935
         End
         Begin VB.TextBox txtcash 
            ForeColor       =   &H00C00000&
            Height          =   330
            Left            =   7920
            MaxLength       =   17
            TabIndex        =   12
            Top             =   1200
            Width           =   1830
         End
         Begin VB.TextBox txtchno 
            ForeColor       =   &H00C00000&
            Height          =   330
            Left            =   7920
            MaxLength       =   4
            TabIndex        =   10
            Top             =   480
            Width           =   975
         End
         Begin VB.Label Label17 
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
            TabIndex        =   42
            Top             =   1080
            Width           =   1230
         End
         Begin VB.Label lblAcno 
            BackColor       =   &H80000013&
            ForeColor       =   &H000000FF&
            Height          =   255
            Left            =   1440
            TabIndex        =   41
            Top             =   1080
            Width           =   2775
         End
         Begin VB.Label lbldcode 
            Height          =   135
            Left            =   3345
            TabIndex        =   34
            Top             =   405
            Visible         =   0   'False
            Width           =   825
         End
         Begin VB.Label lblbcode 
            Height          =   180
            Left            =   5160
            TabIndex        =   33
            Top             =   1200
            Visible         =   0   'False
            Width           =   570
         End
         Begin VB.Label Label6 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Client Code"
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
            Height          =   330
            Left            =   120
            TabIndex        =   32
            Top             =   720
            Width           =   1230
         End
         Begin VB.Label lbllcode 
            Height          =   165
            Left            =   4320
            TabIndex        =   31
            Top             =   1200
            Visible         =   0   'False
            Width           =   675
         End
         Begin VB.Label Label5 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Deposit Code"
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
            Left            =   120
            TabIndex        =   27
            Top             =   390
            Width           =   1230
         End
         Begin VB.Label Label11 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "No of Check"
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
            Height          =   330
            Left            =   6165
            TabIndex        =   26
            Top             =   480
            Width           =   1620
         End
         Begin VB.Label Label12 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CitiCash Amount"
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
            Left            =   6165
            TabIndex        =   25
            Top             =   1200
            Width           =   1635
         End
         Begin VB.Label Label13 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "CitiCheck Amount"
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
            Height          =   330
            Left            =   6180
            TabIndex        =   24
            Top             =   825
            Width           =   1620
         End
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00C0C0C0&
         Height          =   2055
         Left            =   360
         TabIndex        =   16
         Top             =   105
         Width           =   10710
         Begin VB.CommandButton bedit 
            Caption         =   "Edit"
            Height          =   375
            Left            =   6240
            TabIndex        =   35
            Top             =   1560
            Width           =   975
         End
         Begin VB.TextBox txtchkno 
            Height          =   285
            Left            =   8400
            MaxLength       =   4
            TabIndex        =   4
            Top             =   360
            Width           =   1215
         End
         Begin VB.TextBox txtchkamt 
            Height          =   285
            Left            =   8400
            MaxLength       =   17
            TabIndex        =   5
            Top             =   720
            Width           =   1455
         End
         Begin VB.TextBox txtcashamt 
            Height          =   330
            Left            =   8415
            MaxLength       =   17
            TabIndex        =   6
            Top             =   1035
            Width           =   2190
         End
         Begin VB.ComboBox cmblcode 
            Height          =   315
            Left            =   1770
            TabIndex        =   2
            Top             =   855
            Width           =   4785
         End
         Begin VB.ComboBox cmbbcode 
            Height          =   315
            Left            =   1770
            TabIndex        =   3
            Top             =   1200
            Width           =   4785
         End
         Begin VB.TextBox txtds 
            Height          =   330
            Left            =   1770
            MaxLength       =   5
            TabIndex        =   0
            Top             =   240
            Width           =   1695
         End
         Begin MSMask.MaskEdBox msdate 
            Height          =   300
            Left            =   1770
            TabIndex        =   1
            Top             =   555
            Width           =   1320
            _ExtentX        =   2328
            _ExtentY        =   529
            _Version        =   393216
            MaxLength       =   10
            Format          =   "dd/mm/yyyy"
            Mask            =   "##/##/####"
            PromptChar      =   "_"
         End
         Begin MSMask.MaskEdBox medate 
            Height          =   300
            Left            =   5070
            TabIndex        =   13
            Top             =   570
            Width           =   1320
            _ExtentX        =   2328
            _ExtentY        =   529
            _Version        =   393216
            Enabled         =   0   'False
            MaxLength       =   10
            Format          =   "dd/mm/yyyy"
            Mask            =   "##/##/####"
            PromptChar      =   "_"
         End
         Begin VB.Label Label10 
            Caption         =   "dd/mm/yyyy"
            Height          =   255
            Left            =   5160
            TabIndex        =   40
            Top             =   240
            Width           =   975
         End
         Begin VB.Line Line1 
            X1              =   6720
            X2              =   6720
            Y1              =   150
            Y2              =   1440
         End
         Begin VB.Label Label9 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Total CashAmt"
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
            Height          =   330
            Left            =   6900
            TabIndex        =   30
            Top             =   1020
            Width           =   1440
         End
         Begin VB.Label Label3 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Total CheckAmt."
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
            Height          =   330
            Left            =   6900
            TabIndex        =   29
            Top             =   675
            Width           =   1455
         End
         Begin VB.Label Label15 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Total CheckNo"
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
            Height          =   330
            Left            =   6900
            TabIndex        =   28
            Top             =   315
            Width           =   1440
         End
         Begin VB.Label Label1 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Corr Bk_Br Code"
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
            Height          =   330
            Left            =   120
            TabIndex        =   23
            Top             =   1230
            Width           =   1575
         End
         Begin VB.Label Label2 
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
            Height          =   330
            Left            =   135
            TabIndex        =   22
            Top             =   885
            Width           =   1575
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
            Height          =   285
            Left            =   120
            TabIndex        =   21
            Top             =   240
            Width           =   1575
         End
         Begin VB.Label Label7 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Schedule Date"
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
            Height          =   330
            Left            =   120
            TabIndex        =   20
            Top             =   525
            Width           =   1575
         End
         Begin VB.Label Label8 
            BorderStyle     =   1  'Fixed Single
            Caption         =   "Entry Date"
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
            Height          =   330
            Left            =   3465
            TabIndex        =   19
            Top             =   540
            Width           =   1575
         End
      End
      Begin MSFlexGridLib.MSFlexGrid allshow 
         Height          =   3360
         Left            =   870
         TabIndex        =   18
         Top             =   4080
         Width           =   9405
         _ExtentX        =   16589
         _ExtentY        =   5927
         _Version        =   393216
         FixedCols       =   0
      End
      Begin VB.Line Line2 
         BorderColor     =   &H00E0E0E0&
         X1              =   20160
         X2              =   20160
         Y1              =   2520
         Y2              =   4275
      End
   End
   Begin VB.Label Label14 
      Alignment       =   2  'Center
      BackColor       =   &H00E0E0E0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Update  Deposit Schedule"
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
      Height          =   615
      Left            =   60
      TabIndex        =   14
      Top             =   210
      Width           =   11310
   End
End
Attribute VB_Name = "frmds"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim locationadd As New ADODB.Recordset
Dim corrbankadd As New ADODB.Recordset
Dim corrbankname As New ADODB.Recordset
Dim branchcode As New ADODB.Recordset
Dim branchname As New ADODB.Recordset
Dim clientcode As New ADODB.Recordset
Dim dssave As New ADODB.Recordset
Dim dscodeadd As New ADODB.Recordset
Dim chkdcode As New ADODB.Recordset
Dim clientadd As New ADODB.Recordset
Dim showall As New ADODB.Recordset
Dim tcheckamt As New ADODB.Recordset
Dim appendcash As Currency
Dim appendcheck As Currency
Dim appendchk As Boolean
Dim deldata As Boolean
Dim appenddata As Boolean
Dim canceldata As Boolean
Dim editchkamt As Boolean
Dim editchkno As New ADODB.Recordset
Dim editchkamt1 As Boolean
Dim selectgrid As Boolean
Dim editcashamt As Boolean
Dim intcount As Integer
Dim txttchk As Currency
Dim txttcash As Currency
Dim mschk As Currency
Dim mscash As Currency
Dim ss As String

Private Sub allshow_Click()
selectgrid = True

If deldata = True Then
    bdelete.Enabled = True
    bsave.Enabled = False
    bcancel.Enabled = True
    bquit.Enabled = False
    If allshow.Rows > 1 Then
        With allshow
        .col = 0:  lbldcode.Caption = .Text
        showall.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' and d_code='" & lbldcode.Caption & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
        If showall.RecordCount > 0 Then
            txtdcode.Text = Trim(showall!d_code) & ""
            cmbclient.Text = Trim(showall!client_code) & ""
            txtchno.Text = Trim(showall!No_check) & ""
            txtcheck.Text = Trim(showall!citicheck_amount) & ""
            txtcash.Text = Trim(showall!citicash_amount) & ""
            If Trim(showall!Deposit_Type) = "Cash" Then
                chkdtype.Value = 0
                
            ElseIf Trim(showall!Deposit_Type) = "Check" Then
                chkdtype.Value = 1
                
            End If
            
        End If
        showall.Close
        End With
    End If
End If

End Sub

Private Sub bcancel_Click()

Dim Respns As Integer
If txtds.Text = "" Or txtcash.Text = "" Or txtcheck.Text = "" Then
    Respns = MsgBox("Do you want to Clear this " & vbCr _
           & "information?", vbQuestion + vbYesNo)
    Select Case Respns
    Case vbYes
        init_item
        
    Case vbNo
       bcancel.SetFocus
    End Select
End If

End Sub

Private Sub bdelete_Click()
Dim rs As New ADODB.Recordset
If Not selectgrid Then
    MsgBox "Must select Record from grid"
    Exit Sub
End If
bsave.Enabled = False
appenddata = False

'''New Authorization is added on 17/03/2005
Set rs = Nothing
Set rs = ocon.GetResultset("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' and d_code='" & Trim(txtdcode.Text) & "' and filename is null and refno is null")
If Not (rs.BOF And rs.EOF) Then
  If rs!Checked = 1 Then
    MsgBox "File is already checked for booking you need authorization to delete this file", vbOKOnly, "CCMS"
     If Authorized = False Then
       Exit Sub
     End If
  End If
Else
  MsgBox "File is already Booked you need authorization to delete this file", vbOKOnly, "CCMS"
  If Authorized = False Then
       Exit Sub
  End If
  Set rs = ocon.GetResultset("select * from dschedule where userid='" & s_user & "'  and filename is null and refno is null ")
  If Not (rs.BOF And rs.EOF) Then
            RecordName = "DepositSchedule " + Space(2) + rs!ds_code + Space(2) + "Deposit Code " + rs!d_code
            MsgBox "Record exist which  " & RecordName & " given by an Authorizer,Another authorizer is needed to run booking", vbOKOnly, "CCMS"
        Exit Sub
  End If
  
End If

If deldata = True Then
kk = MsgBox("Are you sure you want to Delete?", vbDefaultButton3 + vbQuestion + vbYesNo)
    If kk = vbNo Then
        Exit Sub
    End If
    
    Set rs = ocon.GetResultset("delete from dschedule where ds_code='" & Trim(txtds.Text) & "' and d_code='" & Trim(txtdcode.Text) & "'")
    Set dssave = Nothing
    Set dssave = ocon.GetResultset("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc")
    If dssave.RecordCount > 0 Then
        cleargrid
        Do While Not dssave.EOF
        With allshow
            .Rows = .Rows + 1
            .row = .Rows - 1
            allshow.col = 0
            allshow.Text = Trim(dssave!d_code) & ""
            allshow.col = 1
            allshow.Text = Trim(dssave!client_code) & ""
            allshow.col = 2
            allshow.Text = (dssave!No_check) & ""
            allshow.col = 3
            allshow.Text = (dssave!citicheck_amount) & ""
            allshow.col = 4
            allshow.Text = (dssave!citicash_amount) & ""
            allshow.col = 5
            allshow.Text = Trim(dssave!Deposit_Type)
            
        End With
        dssave.MoveNext
        Loop
        Set dssave = Nothing
        txtdcode.Text = ""
        cmbclient.Clear
        txtchno.Text = ""
        txtcheck.Text = ""
        txtcash.Text = ""
        bcancel.SetFocus
    ElseIf dssave.RecordCount = 0 Then
        oconn.Connection.Execute "delete from dcollected where ds_code='" & Trim(txtds.Text) & "'"
        init_item
    End If
 End If
bdelete.Enabled = False

   
End Sub



Private Sub bedit_Click()
selectgrid = False
If deldata = True Then
If txtds.Text = "" Or msdate.Text = "__/__/____" Or cmblcode.Text = "" Or cmbbcode.Text = "" Then
    MsgBox "Must Fill Up all data"
    Exit Sub
End If
dssave.Open ("select * from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If dssave.RecordCount = 0 Then
    dssave.AddNew
    dssave!ds_code = Trim(txtds.Text)
    dssave!total_nochk = Val(txtchkno.Text)
    dssave!TOTAL_CHKAMT = txttchk
    dssave!total_cashamt = txttcash
    dssave.Update
  
ElseIf dssave.RecordCount > 0 Then
   oconn.Connection.Execute "update dcollected set total_nochk=" & Val(txtchkno.Text) & ", total_chkamt=" & txttchk & ",total_cashamt=" & txttcash & "  where ds_code='" & Trim(txtds.Text) & "'"
End If
dssave.Close

dssave.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
        Do While Not dssave.EOF
        'oconn.Connection.Execute "update dschedule set schedule_date='" & Format(msdate.Text, "dd/mmmm/yyyy") & "',location_code='" & Left(cmblcode.Text, 3) & "',corr_bcode='" & Left(cmbbcode.Text, 3) & "',corr_brcode='" & Mid(cmbbcode.Text, 4, 3) & "' where ds_code = '" & Trim(txtds.Text) & "'"
     'new update entry_date *********27-02-2000**************
        oconn.Connection.Execute "update dschedule set schedule_date='" & Format(msdate.Text, "dd/mmmm/yyyy") & "',location_code='" & Left(cmblcode.Text, 3) & "',corr_bcode='" & Left(cmbbcode.Text, 3) & "',corr_brcode='" & Mid(cmbbcode.Text, 4, 3) & "',Entry_date='" & Format(Date, "mm/dd/yyyy") & "' where ds_code = '" & Trim(txtds.Text) & "'"
        dssave.MoveNext
        Loop
    End If
    dssave.Close
End If
MsgBox "Edited"
End Sub

Private Sub bquit_Click()
If Trim(txtds.Text) = "" Then
 kk = MsgBox("Are you sure you want to exit?", vbDefaultButton3 + vbYesNo + vbQuestion)
If kk = vbNo Then
    Exit Sub
Else
    Unload Me
    'frmMain.Show
End If
End If
End Sub

Private Sub bsave_Click()
Dim K As Integer
Dim i As Currency
Dim kk As Currency
Dim kk1 As Currency
Dim kk2 As Integer

If allshow.Rows = 0 Then
    MsgBox "You did not enter any record !", vbCritical
    Exit Sub
End If
If Not deldata Or appenddata Then

   

   
    dssave.Open ("select * from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount = 0 Then
        dssave.AddNew
        dssave!ds_code = Trim(txtds.Text)
        dssave!total_nochk = Val(txtchkno.Text)
        dssave!TOTAL_CHKAMT = txttchk
        dssave!total_cashamt = txttcash
        dssave.Update
    End If
    dssave.Close
    
   
    
   '*********************************************
       
   '*********************************************
    tcheckamt.Open ("select isnull(sum(citicheck_amount),0)as tchkamt from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If tcheckamt.RecordCount > 0 Then
            If tcheckamt!tchkamt <> txttchk Then
            kk = tcheckamt!tchkamt - txttchk
                MsgBox "Mismatch in TotalCheck amount:  " & Format(kk, "#,##,##,##,##0.00")
            End If
    End If
    tcheckamt.Close
'--------------------------------
  
    tcheckamt.Open ("select sum(citicash_amount)as tcashamt from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If tcheckamt.RecordCount > 0 Then
        If tcheckamt!tcashamt <> txttcash Then
            kk1 = tcheckamt!tcashamt - txttcash
            MsgBox "Mismatch in TotalCash amount:  " & Format(kk1, "#,##,##,##,##0.00")
        End If
    End If
    tcheckamt.Close


'------------------------------------------


''********New checking for deposit Schedule 07/05/2005
    Dim cTotalamtValid As Currency
    Set rs = Nothing
    Set rs = ocon.GetResultset("select sum(citicash_amount)as tcashamt,sum(citicheck_amount)as tchkamt from " & _
    " dschedule  where ds_code='" & Trim(txtds.Text) & "'group by ds_code ")
    If Not (rs.BOF And rs.EOF) Then
      cTotalamtValid = Val(Trim(txttcash)) + Val(Trim(txttchk))
      If (rs!tcashamt + rs!tchkamt <> cTotalamtValid) Then
         MsgBox "Total amount mismatch", vbOKOnly
      End If
    End If
    
''---------------------------------------------------
    editchkno.Open ("select sum(no_check)as totalchkno from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic

    i = Val(txtchkno.Text)
    If editchkno!totalchkno <> i Then
        kk2 = editchkno!totalchkno - i
        MsgBox "Mismatch in TotalCheck No: " & kk2
    End If
    editchkno.Close
init_item
cleargrid
End If

'End If
'appendchk = False
'---------------
'If editdata Then
 '   If txtcash.Text = "" Then
  '      If Trim(txtds.Text) = "" Then
   '         MsgBox "Must enter DSCode"
    '        txtds.SetFocus
     '       Exit Sub
      '  End If
       ' If Trim(msdate.Text) = "__/__/____" Then
        '    MsgBox "Must enter Schedule date"
         '   msdate.SetFocus
          '  Exit Sub
        'End If
        'If cmblcode.Text = "" Then
         '   MsgBox "Must enter LocationCode"
          '  cmblcode.SetFocus
           ' Exit Sub
        'End If
        'If Trim(cmbbcode.Text) = "" Then
         '   MsgBox "Must enter BankCode"
          '  cmbbcode.SetFocus
           ' Exit Sub
        'End 'If
        'If Trim(txtdcode.Text) = "" Then
         '   MsgBox "Must enter Depost Code"
          '  txtdcode.SetFocus
           ' Exit Sub
        'End If
        'If cmbclient.Text = "" Then
        '    MsgBox "Must enter Client Code"
         '   cmbclient.SetFocus
          '  Exit Sub
        'End' If
        'If Trim(txtchkno.Text) = "" Then
        '    MsgBox "Must enter total checkno"
        '    txtchkno.SetFocus
         '   Exit Sub
       ' End If
       ' If Trim(txtchkamt.Text) = "" Then
       '     MsgBox "Must enter Total Check Amount"
       '     txtchkamt.SetFocus
       '     Exit Sub
       ' End If
       ' If txtchno.Text = "" Then
       '     MsgBox "Must enter chkno"
        '    txtchno.SetFocus
         '   Exit Sub
        'End If
        'If Trim(txtcheck.Text) = "" Then
        '    MsgBox "Must enter CheckAmount"
        '    txtcheck.SetFocus
        '    Exit Sub
        'End If
'End If
'If txtcheck.Text = "" Then
 '       If Trim(txtds.Text) = "" Then
  '      MsgBox "Must enter DSCode"
   '     txtds.SetFocus
    '    Exit Sub
   ' End If
   ' If Trim(msdate.Text) = "__/__/____" Then
   '     MsgBox "Must enter Schedule date"
    '    msdate.SetFocus
     '   Exit Sub
   ' End If
   ' If cmblcode.Text = "" Then
    '    MsgBox "Must enter LocationCode"
     '   cmblcode.SetFocus
      '  Exit Sub
    'End If
    'If Trim(cmbbcode.Text) = "" Then
    '    MsgBox "Must enter BankCode"
     '   cmbbcode.SetFocus
      '  Exit Sub
    'End' If
    'If Trim(txtdcode.Text) = "" Then
        MsgBox "Must enter Depost Code"
     '   txtdcode.SetFocus
      '  Exit Sub
    'End If
    'If cmbclient.Text = "" Then
    '    MsgBox "Must enter Client Code"
     '   cmbclient.SetFocus
     '   Exit Sub
    'End If
    'If Trim(txtcashamt.Text) = "" Then
    '    MsgBox "Must enter totalcash amount"
     '   txtcashamt.SetFocus
      '  Exit Sub
    'End If
'E'nd If
 '   dssave.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
  '  If dssave.RecordCount > 0 Then
   '     Do While Not dssave.EOF
    '    oconn.Connection.Execute "update dschedule set schedule_date='" & Format(msdate.Text, "dd/mm/yyyy") & "',location_code='" & Left(cmblcode.Text, 3) & "',corr_bcode='" & Left(cmbbcode.Text, 3) & "',corr_brcode='" & Mid(cmbbcode.Text, 4, 3) & "' where ds_code = '" & Trim(txtds.Text) & "'"
     '   dssave.MoveNext
      '  Loop
    'End' If
    'dssave.Close
    'If txtcash.Text = "" And txtdcode.Text <> "" Then
    '    oconn.Connection.Execute "update dschedule set client_code='" & Left(cmbclient.Text, 6) & "',no_check=" & txtchno.Text & ",CITICHECK_AMOUNT=" & txtcheck.Text & " where ds_code = '" & Trim(txtds.Text) & "' and d_code='" & Trim(lbldcode.Caption) & "'"
    'End If
    'If txtcheck.Text = "" And txtdcode.Text <> "" Then
    '    oconn.Connection.Execute "update dschedule set client_code='" & Left(cmbclient.Text, 6) & "',citicash_amount=" & txtcash.Text & " where ds_code = '" & Trim(txtds.Text) & "' and d_code='" & Trim(lbldcode.Caption) & "'"
    'End If
    
    
  '  dssave.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
  '  If dssave.RecordCount > 0 Then
   '     cleargrid
    '    Do While Not dssave.EOF
     '       With allshow
       '     .Rows = .Rows + 1
      '      .Row = .Rows - 1
      '      allshow.Col = 0
       '     allshow.Text = Trim(dssave!D_Code)
        '    allshow.Col = 1
         '   allshow.Text = Trim(dssave!Client_Code)
          '  allshow.Col = 2
           ' allshow.Text = (dssave!No_check) & ""
            'allshow.Col = 3
            'allshow.Text = (dssave!citicheck_amount) & ""
            'allshow.Col = 4
            'allshow.Text = (dssave!citicash_amount) & ""
            'allshow.Col = 5
            'allshow.Text = Trim(dssave!Deposit_Type) & ""
        'End With
        'dssave.MoveNext
       ' Loop
       ' dssave.Close
    'Else
    '    dssave.Close
    'End If
'End If
  '  tcheckamt.Open ("select sum(citicheck_amount)as tchkamt from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
   ' If tcheckamt.RecordCount > 0 Then
    '        If tcheckamt!tchkamt <> txttchk Then
     '       msg = "Mismatch in TotalCheck amount,Want to edit?"
      '      style = vbInformation + vbDefaultButton2 + vbYesNo
            title = "Mismatch"
       '     response = MsgBox(msg, style, title)
        '    If response = vbYes Then
                'editchkamt = True
         ''       editdata = True
           '     tcheckamt.Close
            '    Exit Sub
            'E 'lseIf response = vbNo Then
             '   bcancel.SetFocus
              '
            'End If
        'End If
        'tcheckamt.Close
    'End If

    'tcheckamt.Open ("select sum(citicash_amount)as tcashamt from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    'If tcheckamt.RecordCount > 0 Then
    'If tcheckamt!tcashamt <> txttcash Then
    '    msg = "Mismatch in TotalCash amount,Want to edit?"
     '       style = vbInformation + vbDefaultButton2 + vbYesNo
        '    title = "Mismatch"
      '      response = MsgBox(msg, style, title)
       '     If response = vbYes Then
         '       editcashamt = True
                'editdata = True
            '    tcheckamt.Close
          ''      Exit Sub
           ' ElseIf response = vbNo Then
            '    bcancel.SetFocus
            'E'nd If
    'End If
    'End If
    'tcheckamt.Close



    'editchkno.Open ("select sum(no_check)as totalchkno from dschedule where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic

    'i = Val(txtchkno.Text)
    'If editchkno!totalchkno <> i Then
     '   MsgBox "Mismatch in TotalCheckNo"
      '  bsave.Enabled = True
       ' bcancel.Enabled = True
        'bquit.Enabled = False
        'bdelete.Enabled = False
        
        'Exit Sub
   ' End If
    'editchkno.Close
    'bsave.Enabled = False
    'bcancel.Enabled = True
    'bquit.Enabled = False
    'bdelete.Enabled = False
    'txtdcode.Text = ""
    'cmbclient.Clear
    'txtchno.Text = ""
    'txtcheck.Text = ""
    'txtcash.Text = ""
'End If
'txtdcode.SetFocus
'editdata = False
End Sub

Private Sub chkdtype_Click()
If chkdtype.Value = 1 Then
    txtchno.Enabled = True
    txtcheck.Enabled = True
    txtcash.Enabled = False
    txtcash.Text = ""
    
ElseIf chkdtype.Value = 0 Then
    txtchno.Text = ""
    txtcheck.Text = ""
    txtchno.Enabled = False
    txtcheck.Enabled = False
    txtcash.Enabled = True
    
End If
End Sub

Private Sub chkdtype_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
'If KeyAscii = 13 And txtchno.Enabled = True Then
 '   txtchno.SetFocus
'End If
'If KeyAscii = 13 And txtcash.Enabled = True Then
 '   txtcash.SetFocus
'End If
End Sub

Private Sub cmbbcode_DropDown()
corrbankadd.Open ("select a.bank_code,a.branch_code,a.branch_name,b.bank_name from branch as a,bank as b where a.bank_code=b.bank_code and a.location_code='" & Left(cmblcode.Text, 3) & "' and a.corrbank='Y'"), oconn.Connection, adOpenKeyset, adLockOptimistic
cmbbcode.Clear
If corrbankadd.RecordCount > 0 Then

  Do While Not corrbankadd.EOF
        cmbbcode.AddItem corrbankadd!Bank_code + corrbankadd!Branch_Code + Space(2) + ":" + Trim(corrbankadd!Bank_name) + ":" + Trim(corrbankadd!Branch_name)
        corrbankadd.MoveNext
        Loop
End If
corrbankadd.Close

End Sub

Private Sub cmbbcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub cmbbcode_Validate(Cancel As Boolean)
Dim bRangeExist As Boolean
Set rs = Nothing
Set rs = ocon.GetResultset("select * from schedulestock ")

'''New modification

''//Select all the schedule stock and check with given no.
bRangeExist = False
If Not (rs.BOF And rs.EOF) Then
  Do Until rs.EOF
    If Not (Val(Trim(txtds.Text)) >= Val(Trim(rs!sche_from)) And Val(Trim(txtds.Text)) <= Val(Trim(rs!sche_upto))) Then
          'MsgBox "Schedule is not in the range", vbOKOnly, "CCMS"
         ' Exit Sub
    Else
         bRangeExist = True
    End If
        rs.MoveNext
    Loop
Else
  
    MsgBox "Not in the schedule list", vbOKOnly, "CCMS"
End If

'// Now that no bRangeExist is not true we can understand no record in the table
'// matched with given no
If bRangeExist = False Then
   MsgBox "Given No is Not in the Stock", vbOKOnly, "CCMS"
   Exit Sub
End If

End Sub

Private Sub cmbclient_Change()
lblbcode.Caption = cmbclient.Text
End Sub

Private Sub cmbclient_DropDown()
clientadd.Open ("select distinct client_code,sub_client,acc_no,acc_name from client where acc_name like '" & lblbcode.Caption & "%' order by client_code"), oconn.Connection, adOpenKeyset, adLockOptimistic

If clientadd.RecordCount > 0 Then
cmbclient.Clear
    Do While Not clientadd.EOF
        cmbclient.AddItem Trim(clientadd!client_code) + Trim(clientadd!sub_client) + Space(2) + ":" + Space(2) + Trim(clientadd!Acc_Name)
        clientadd.MoveNext
        Loop
End If
clientadd.Close

End Sub

Private Sub cmbclient_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub CmbClient_Validate(Cancel As Boolean)
Set rs = Nothing
Set rs = ocon.GetResultset("select * from client where client_code+sub_client='" & Trim(Left(cmbclient, 6)) & "'")
  If (rs.BOF And rs.EOF) Then
     MsgBox "Please enter valid Code", vbOKOnly, "CCMS"
     Cancel = True
  Else
  lblAcno = rs!Acc_No
  End If

End Sub


Private Sub cmblcode_Change()
lbllcode.Caption = cmblcode.Text
End Sub

Private Sub cmblcode_DropDown()
cmbbcode.Clear
locationadd.Open ("select distinct a.location_code,b.location_name from branch as a,location as b  where a.location_code=b.location_code and a.corrbank='Y' and b.location_name like '" & lbllcode.Caption & "%' order by a.location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
cmblcode.Clear
If locationadd.RecordCount > 0 Then
  Do While Not locationadd.EOF
        cmblcode.AddItem locationadd!location_code + Space(2) + ":" + Space(2) + locationadd!location_name
        locationadd.MoveNext
    Loop
End If
'If locationadd.RecordCount = 0 Then
 '   MsgBox "No data found"
  '  cmblcode.Clear
   ' locationadd.Close
    'Exit Sub
'End If

locationadd.Close
End Sub

Private Sub cmblcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub Command1_Click()
'If Trim(txtds.Text) <> "" Then
'    If Len(txtds.Text) < 5 Then
'        MsgBox "Must enter 5 digits"
'        txtds.Text = ""
'        txtds.SetFocus
'        Exit Sub
'    End If
'End If
'
'cmblcode.Clear
'cmbbcode.Clear
'cleargrid
'editdata = False
'
'dscodeadd.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc"), oconn.Connection, adOpenKeyset, adLockPessimistic
'If dscodeadd.RecordCount > 0 Then
'    msg = "Duplicate Data,Want to Delete?"
'    style = vbInformation + vbDefaultButton2 + vbYesNo
'    title = "Duplicate Data"
'    response = MsgBox(msg, style, title)
'    If response = vbYes Then
'
'        dssave.Open ("select * from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'        If dssave.RecordCount > 0 Then
'            txtchkno.Text = Trim(dssave!total_nochk) & ""
'            txtchkamt.Text = dssave!total_chkamt & ""
'            txtcashamt.Text = dssave!total_cashamt & ""
'        End If
'        dssave.Close
'        appendchk = True
'        bsave.Enabled = False
'        bcancel.Enabled = True
'        bquit.Enabled = False
'        'bedit.Enabled = True
'        bdelete.Enabled = True
'        chkdtype.Value = 1
'         msdate = Format(dscodeadd!Schedule_date, "dd/mm/yyyy")
'         medate = Format(dscodeadd!entry_date, "dd/mm/yyyy") & ""
'         cmblcode.Text = Trim(dscodeadd!location_code) & ""
'         cmbbcode.Text = Trim(dscodeadd!Corr_BCode) & "" + Trim(dscodeadd!Corr_BrCode) & ""
'        With dscodeadd
'        Do While Not dscodeadd.EOF
'            With allshow
'                .Rows = .Rows + 1
'                .Row = .Rows - 1
'                .Col = 0: .Text = dscodeadd!D_Code
'                .Col = 1: .Text = dscodeadd!Client_Code & ""
'                .Col = 2: .Text = dscodeadd!No_check & ""
'                .Col = 3: .Text = Format(dscodeadd!citicheck_amount, "#,##,##,##,##0.00") & ""
'                .Col = 4: .Text = Format(dscodeadd!citicash_amount, "#,##,##,##,##0.00") & ""
'                .Col = 5: .Text = dscodeadd!Deposit_Type & ""
'
'                End With
'                .MoveNext
'                Loop
'                dscodeadd.Close
'                txtchkamt.SetFocus
'          End With
'        ElseIf response = vbNo Then
'            msg = "Duplicate Data,Want to Append?"
'            style = vbInformation + vbDefaultButton2 + vbYesNo
'            title = "Duplicate Data"
'            response = MsgBox(msg, style, title)
'            If response = vbYes Then
'                appenddata = True
'                dssave.Open ("select * from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'                If dssave.RecordCount > 0 Then
'                    txtchkno.Text = Trim(dssave!total_nochk) & ""
'                    txtchkamt.Text = dssave!total_chkamt & ""
'                    txtcashamt.Text = dssave!total_cashamt & ""
'                End If
'                dssave.Close
'
'                chkdtype.Value = 1
'                 msdate = Format(dscodeadd!Schedule_date, "dd/mm/yyyy")
'                medate = Format(dscodeadd!entry_date, "dd/mm/yyyy") & ""
'                cmblcode.Text = Trim(dscodeadd!location_code) & ""
'                cmbbcode.Text = Trim(dscodeadd!Corr_BCode) & "" + Trim(dscodeadd!Corr_BrCode) & ""
'                With dscodeadd
'                Do While Not dscodeadd.EOF
'                With allshow
'                    .Rows = .Rows + 1
'                    .Row = .Rows - 1
'                    .Col = 0: .Text = dscodeadd!D_Code
'                    .Col = 1: .Text = dscodeadd!Client_Code & ""
'                    .Col = 2: .Text = dscodeadd!No_check & ""
'                    .Col = 3: .Text = Format(dscodeadd!citicheck_amount, "#,##,##,##,##0.00") & ""
'                    .Col = 4: .Text = Format(dscodeadd!citicash_amount, "#,##,##,##,##0.00") & ""
'                    .Col = 5: .Text = dscodeadd!Deposit_Type & ""
'                End With
'                .MoveNext
'                Loop
'                dscodeadd.Close
'                txtchkamt.SetFocus
'                bsave.Enabled = False
'                bcancel.Enabled = False
'                bquit.Enabled = True
'                editdata = False
'                bdelete.Enabled = False
'                txtdcode.SetFocus
'   Else
'        bsave.Enabled = True
'        bcancel.Enabled = True
'        bquit.Enabled = False
'        bdelete.Enabled = False
'
'End If
'dscodeadd.Close
'End If
'
'
'
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

Private Sub msdate_Validate(Cancel As Boolean)
'    If msdate.Text = "__/__/____" Then
'        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
     If oDate.Validate(msdate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        Cancel = True
        Exit Sub
     End If
End Sub

Private Sub txtcheck_LostFocus()
On Error GoTo err
If Not deldata Or appenddata Then
    If Trim(txtds.Text) = "" Then
        MsgBox "Must enter DSCode"
        txtds.SetFocus
        Exit Sub
    End If
    If Trim(msdate.Text) = "__/__/____" Then
        MsgBox "Must enter Schedule date"
        msdate.SetFocus
        Exit Sub
    End If
    If cmblcode.Text = "" Then
        MsgBox "Must enter LocationCode"
        cmblcode.SetFocus
        Exit Sub
    End If
    If Trim(cmbbcode.Text) = "" Then
        MsgBox "Must enter BankCode"
        cmbbcode.SetFocus
        Exit Sub
    End If
    If Trim(txtdcode.Text) = "" Then
        MsgBox "Must enter Depost Code"
        txtdcode.SetFocus
        Exit Sub
    End If
    If cmbclient.Text = "" Then
        MsgBox "Must enter Client Code"
        cmbclient.SetFocus
        Exit Sub
    End If
    If Trim(txtchkno.Text) = "" Then
        MsgBox "Must enter total checkno"
        txtchkno.SetFocus
        Exit Sub
    End If
    If Trim(txtchkamt.Text) = "" Then
      MsgBox "Must enter Total Check Amount"
      txtchkamt.SetFocus
      Exit Sub
    End If
    If txtchno.Text = "" Then
        MsgBox "Must enter chkno"
        txtchno.SetFocus
        Exit Sub
    End If
    If Trim(txtcheck.Text) = "" Then
        MsgBox "Must enter CheckAmount"
        txtcheck.SetFocus
        Exit Sub
    End If
    Set dssave = Nothing
    dssave.Open ("select * from dschedule where ds_code = '" & Trim(txtds.Text) & "' and d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
     If dssave.RecordCount = 0 Or dssave.RecordCount > 0 Then
         With dssave
            .AddNew
            !ds_code = Trim(txtds.Text)
            !Schedule_date = Format(msdate.Text, "dd/mm/yyyy")
            !Entry_date = Format(medate.Text, "dd/mm/yyyy")
            !location_code = Left(cmblcode.Text, 3)
            !Corr_BCode = Left(cmbbcode.Text, 3)
            !Corr_BrCode = Mid(cmbbcode.Text, 4, 3)
            !d_code = Trim(txtdcode.Text)
            !client_code = Trim(Left(cmbclient.Text, 6))
            !No_check = Val(txtchno.Text)
            
            !citicheck_amount = Val(txtcheck.Text)
            '!citicheck_amount = (mschk)
            If chkdtype.Value = 1 Then
                !Deposit_Type = "Check"
            End If
            If chkdtype.Value = 0 Then
                !Deposit_Type = "Cash"
            End If
            !Checked = Null
            !UserId = Trim(oLoginUser.UserId)
            .Update
        End With
        'dssave.Close
    End If
    dssave.Close

    dssave.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
        cleargrid
        Do While Not dssave.EOF
            With allshow
            .Rows = .Rows + 1
            .row = .Rows - 1
            allshow.col = 0
            allshow.Text = Trim(dssave!d_code)
            allshow.col = 1
            allshow.Text = Trim(dssave!client_code)
            allshow.col = 2
            allshow.Text = (dssave!No_check) & ""
            allshow.col = 3
            'allshow.Text = Val(dssave!citicheck_amount)
            allshow.Text = Format(dssave!citicheck_amount, "#,##,##,##,##0.00") & ""
            allshow.col = 4
            'allshow.Text = Val(dssave!citicash_amount)
            allshow.Text = Format(dssave!citicash_amount, "#,##,##,##,##0.00") & ""
            allshow.col = 5
            allshow.Text = Trim(dssave!Deposit_Type) & ""
            
        End With
        dssave.MoveNext
        Loop
        dssave.Close
        txtdcode.Text = ""
        txtcheck.Text = ""
        txtchno.Text = ""
        txtdcode.SetFocus
    Else
        dssave.Close
    End If
End If

If txtcheck.Text = "" Then
    Exit Sub
End If


'-----------------------------------
err:

End Sub

Private Sub txtchkamt_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtchkamt_LostFocus()
txttchk = Val(txtchkamt.Text)
txtchkamt.Text = Format(txtchkamt.Text, "#,##,##,##,##0.00")
End Sub



Private Sub txtchkno_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtchno_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub Form_Load()
Move (Screen.Height - Height) / 2, (Screen.width - width) / 2
txtds.Text = ""
txtdcode.Text = ""
txtchno.Text = ""
txtcash.Text = ""
txtcheck.Text = ""
txtchkno.Text = ""
txtchkamt.Text = ""
txtcashamt.Text = ""
chkdtype.Value = 1
txtchkno.Enabled = True
txtchkamt.Enabled = True
txtcash.Enabled = False
bsave.Enabled = False
bcancel.Enabled = False
bedit.Enabled = False
bdelete.Enabled = False
bquit.Enabled = True
cmbclient.Clear
msdate.Text = "__/__/____"
medate.Text = Format(Date, "dd/mm/YYYY")
'Me.Width = 11460
'Me.Height = 9000
cleargrid


End Sub

Private Sub medate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub msdate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub


Private Sub txtcash_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtcash_LostFocus()

If Not deldata Or appenddata Then
    'If Len(txtcash.Text) > 13 Then
     '   txtcash.Text = ""
      '  txtcash.SetFocus
       ' MsgBox "kk"
       ' Exit Sub
    'End If
        

    If Trim(txtds.Text) = "" Then
        MsgBox "Must enter DSCode"
        txtds.SetFocus
        Exit Sub
    End If
    If Trim(msdate.Text) = "__/__/____" Then
        MsgBox "Must enter Schedule date"
        msdate.SetFocus
        Exit Sub
    End If
    If cmblcode.Text = "" Then
        MsgBox "Must enter LocationCode"
        cmblcode.SetFocus
        Exit Sub
    End If
    If Trim(cmbbcode.Text) = "" Then
        MsgBox "Must enter BankCode"
        cmbbcode.SetFocus
        Exit Sub
    End If
    If Trim(txtdcode.Text) = "" Then
        MsgBox "Must enter Depost Code"
        txtdcode.SetFocus
        Exit Sub
    End If
    If cmbclient.Text = "" Then
        MsgBox "Must enter Client Code"
        cmbclient.SetFocus
        Exit Sub
    End If
    If Trim(txtcashamt.Text) = "" Then
        MsgBox "Must enter totalcash amount"
        txtcashamt.SetFocus
        Exit Sub
    End If
    If Trim(txtcash.Text) = "" Then
        msg = "Want to Change Deposit type?"
        style = vbInformation + vbDefaultButton2 + vbYesNo
        title = "DType Change"
        response = MsgBox(msg, style, title)
        If response = vbYes Then
            chkdtype.SetFocus
        Exit Sub
        ElseIf response = vbNo Then
            txtcash.SetFocus
            Exit Sub
        End If
    End If

    
    dssave.Open ("select * from dschedule where ds_code = '" & Trim(txtds.Text) & "' and d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
     If dssave.RecordCount = 0 Then
            With dssave
            .AddNew
            !ds_code = Trim(txtds.Text)
            !Schedule_date = Format(msdate.Text, "dd/mm/yyyy")
            !Entry_date = Format(medate.Text, "dd/mm/yyyy")
            !location_code = Left(cmblcode.Text, 3)
            !Corr_BCode = Left(cmbbcode.Text, 3)
            !Corr_BrCode = Mid(cmbbcode.Text, 4, 3)
            !d_code = Trim(txtdcode.Text)
            !client_code = Trim(Left(cmbclient.Text, 6))
            !citicash_amount = Val(txtcash.Text)
            If chkdtype.Value = 1 Then
                !Deposit_Type = "Check"
            End If
            If chkdtype.Value = 0 Then
                !Deposit_Type = "Cash"
            End If
             !Checked = Null
             !UserId = Trim(oLoginUser.UserId)
            .Update
        End With
    dssave.Close
    End If


    dssave.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
        cleargrid
        Do While Not dssave.EOF
        With allshow
            .Rows = .Rows + 1
            .row = .Rows - 1
            allshow.col = 0
            allshow.Text = Trim(dssave!d_code)
            allshow.col = 1
            allshow.Text = Trim(dssave!client_code)
            allshow.col = 2
            allshow.Text = (dssave!No_check) & ""
            allshow.col = 3
            'allshow.Text = Val(dssave!citicheck_amount)
            allshow.Text = Format(dssave!citicheck_amount, "#,##,##,##,##0.00") & ""
            allshow.col = 4
            'allshow.Text = Val(dssave!citicash_amount)
            allshow.Text = Format(dssave!citicash_amount, "#,##,##,##,##0.00") & ""
            allshow.col = 5
            allshow.Text = Trim(dssave!Deposit_Type) & ""
            
            End With
        dssave.MoveNext
        Loop
        dssave.Close
        txtdcode.Text = ""
        txtcheck.Text = ""
        txtchno.Text = ""
        txtcash.Text = ""
        txtdcode.SetFocus
    Else
        dssave.Close
    End If
    End If

    If txtcash.Text = "" Then
        Exit Sub
    End If


End Sub

Private Sub txtcashamt_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtcashamt_LostFocus()
txttcash = Val(txtcashamt.Text)
txtcashamt.Text = Format(txtcashamt.Text, "#,##,##,##,##0.00")
End Sub

Private Sub txtcheck_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtdcode_KeyPress(KeyAscii As Integer)
bsave.Enabled = True
If KeyAscii = 13 Then SendKeys "{tab}"


End Sub

Private Sub txtdcode_LostFocus()
If txtdcode.Text = "" Then
    Exit Sub
End If

If Len(txtdcode.Text) < 7 Then
    MsgBox "Must Enter 7 digits"
    txtdcode.Text = ""
    txtdcode.SetFocus
    Exit Sub
End If

chkdcode.Open ("select d_code from dschedule where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If chkdcode.RecordCount > 0 Then
    MsgBox "Duplicate Deposit Code"
    txtdcode.Text = ""
    txtdcode.SetFocus
    chkdcode.Close
    Exit Sub
End If
chkdcode.Close

If allshow.Rows > 1 Then
    For drec = 1 To allshow.Rows - 1
        allshow.row = drec
        allshow.col = 0
        If Trim(allshow.Text) = Trim(txtdcode.Text) Then
            MsgBox "You have already entered this Item !", vbCritical
            txtdcode.Text = ""
            Cancel = True
            Exit Sub
        End If
    Next
End If

End Sub

Private Sub txtdcode_Validate(Cancel As Boolean)
'`Dim drec As Integer
'If Not editdata Then
'If Trim(txtdcode.Text) = "" Then
 '  MsgBox "Invalid Deposit Code"
  ' Cancel = True
  ' Exit Sub
'End If
'End If
End Sub

Private Sub txtds_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
bcancel.Enabled = True
bquit.Enabled = False
bsave.Enabled = False
bdelete.Enabled = False
bedit.Enabled = False
msdate.Text = "__/__/____"
cmblcode.Clear
cmbbcode.Clear
txtchkno.Text = ""
txtchkamt.Text = ""
txtcashamt.Text = ""
txtdcode.Text = ""
cmbclient.Clear
txtchno.Text = ""
txtcheck.Text = ""
txtcash.Text = ""
txtchkno.Text = ""
txtchkamt.Text = ""
txtcashamt.Text = ""
Frame1.Enabled = True
Frame2.Enabled = True
chkdtype.Value = 1
cleargrid
End Sub

Private Sub txtds_LostFocus()
Dim bRangeExist As Boolean
Dim iDSprev As Integer
Dim ScheduleFrom As String
Dim ScheduleTo As String
appenddata = False
deldata = False
selectgrid = False
If Trim(txtds.Text) <> "" Then
    If Len(txtds.Text) < 5 Then
        MsgBox "Must enter 5 digits"
        txtds.Text = ""
        txtds.SetFocus
        Exit Sub
    End If
End If

cmblcode.Clear
cmbbcode.Clear
msdate.Text = "__/__/____"
cmblcode.Clear
cmbbcode.Clear
txtchkno.Text = ""
txtchkamt.Text = ""
txtcashamt.Text = ""
txtdcode.Text = ""
cmbclient.Clear
txtchno.Text = ""
txtcheck.Text = ""
txtcash.Text = ""
txtchkno.Text = ""
txtchkamt.Text = ""
txtcashamt.Text = ""
chkdtype.Value = 1

cleargrid
editdata = False

'*******************Check if data exists or not


Set rs = Nothing
Set rs = ocon.GetResultset("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc")
If (rs.BOF And rs.EOF) Then


''**********************
            Set rs = Nothing
            Set rs = ocon.GetResultset("select * from schedulestock ")
            
            '''New modification
            
            ''//Select all the schedule stock and check with given no.
            bRangeExist = False
            If Not (rs.BOF And rs.EOF) Then
              Do Until rs.EOF
              
              ''**********New addition June 15 2008
              
              If IsNumeric(txtds.Text) = False Then
                ScheduleFrom = Right(txtds.Text, 4)
                If Not (Val(Trim(ScheduleFrom)) >= Val(Trim(rs!sche_from)) And Val(Trim(ScheduleFrom)) <= Val(Trim(rs!sche_upto))) Then
                      'MsgBox "Schedule is not in the range", vbOKOnly, "CCMS"
                     ' Exit Sub
                Else
                     bRangeExist = True
                End If
              End If
              
              
              
              If IsNumeric(txtds.Text) = True Then
                If Not (Val(Trim(txtds.Text)) >= Val(Trim(rs!sche_from)) And Val(Trim(txtds.Text)) <= Val(Trim(rs!sche_upto))) Then
                      'MsgBox "Schedule is not in the range", vbOKOnly, "CCMS"
                     ' Exit Sub
                Else
                     bRangeExist = True
                End If
             End If
                    rs.MoveNext
                Loop
            Else
              
                MsgBox "Not in the schedule list", vbOKOnly, "CCMS"
            End If
            
            '// Now that no bRangeExist is not true we can understand no record in the table
            '// matched with given no
            If bRangeExist = False Then
               If txtds.Text <> "" Then
                MsgBox "Given No is Not in the Stock", vbOKOnly, "CCMS"
                Exit Sub
               End If
            End If
            
  End If
dscodeadd.Open ("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc"), oconn.Connection, adOpenKeyset, adLockPessimistic
If dscodeadd.RecordCount > 0 Then
    msg = "Duplicate Data,Want to Delete?"
    style = vbInformation + vbDefaultButton3 + vbYesNo
    title = "Duplicate Data"
    response = MsgBox(msg, style, title)
    If response = vbYes Then
        
            dssave.Open ("select * from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount > 0 Then
                txtchkno.Text = Trim(dssave!total_nochk) & ""
                txtchkamt.Text = Format(dssave!TOTAL_CHKAMT, "#,##,##,##,##0.00") & ""
                txtcashamt.Text = Format(dssave!total_cashamt, "#,##,##,##,##0.00") & ""
                txttchk = dssave!TOTAL_CHKAMT
                txttcash = dssave!total_cashamt
            End If
            dssave.Close
            deldata = True
            appendchk = True
            bsave.Enabled = False
            bcancel.Enabled = True
            bquit.Enabled = False
            bedit.Enabled = True
            bdelete.Enabled = True
            bedit.Enabled = True
            Frame1.Enabled = False
            Frame2.Enabled = True
            chkdtype.Value = 1
            msdate = Format(dscodeadd!Schedule_date, "dd/mm/yyyy")
            medate = Format(dscodeadd!Entry_date, "dd/mm/yyyy") & ""
            cmblcode.Text = Trim(dscodeadd!location_code) & ""
            cmbbcode.Text = Trim(dscodeadd!Corr_BCode) & "" + Trim(dscodeadd!Corr_BrCode) & ""
            With dscodeadd
                Do While Not dscodeadd.EOF
                With allshow
                .Rows = .Rows + 1
                .row = .Rows - 1
                .col = 0: .Text = dscodeadd!d_code
                .col = 1: .Text = dscodeadd!client_code & ""
                .col = 2: .Text = dscodeadd!No_check & ""
                .col = 3: .Text = Format(dscodeadd!citicheck_amount, "#,##,##,##,##0.00") & ""
                .col = 4: .Text = Format(dscodeadd!citicash_amount, "#,##,##,##,##0.00") & ""
                .col = 5: .Text = dscodeadd!Deposit_Type & ""
                
                End With
                .MoveNext
                Loop
                End With
                dscodeadd.Close
                bedit.SetFocus
                Exit Sub
          
    ElseIf response = vbNo Then
            deldata = False
            msg = "Duplicate Data,Want to Append?"
            style = vbInformation + vbDefaultButton3 + vbYesNo
            title = "Duplicate Data"
            response = MsgBox(msg, style, title)
            If response = vbYes Then
                appenddata = True
                dssave.Open ("select * from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If dssave.RecordCount > 0 Then
                    txtchkno.Text = Trim(dssave!total_nochk) & ""
                    txtchkamt.Text = Format(dssave!TOTAL_CHKAMT, "#,##,##,##,##0.00") & ""
                    txtcashamt.Text = Format(dssave!total_cashamt, "#,##,##,##,##0.00") & ""
                    txttchk = dssave!TOTAL_CHKAMT
                    txttcash = dssave!total_cashamt
                
                End If
                dssave.Close
                
                chkdtype.Value = 1
                msdate = Format(dscodeadd!Schedule_date, "dd/mm/yyyy")
                medate = Format(dscodeadd!Entry_date, "dd/mm/yyyy") & ""
                cmblcode.Text = Trim(dscodeadd!location_code) & ""
                cmbbcode.Text = Trim(dscodeadd!Corr_BCode) & "" + Trim(dscodeadd!Corr_BrCode) & ""
                With dscodeadd
                Do While Not dscodeadd.EOF
                With allshow
                    .Rows = .Rows + 1
                    .row = .Rows - 1
                    .col = 0: .Text = dscodeadd!d_code
                    .col = 1: .Text = dscodeadd!client_code & ""
                    .col = 2: .Text = dscodeadd!No_check & ""
                    .col = 3: .Text = Format(dscodeadd!citicheck_amount, "#,##,##,##,##0.00") & ""
                    .col = 4: .Text = Format(dscodeadd!citicash_amount, "#,##,##,##,##0.00") & ""
                    .col = 5: .Text = dscodeadd!Deposit_Type & ""
                End With
                .MoveNext
                Loop
                End With
                bsave.Enabled = True
                bcancel.Enabled = True
                bquit.Enabled = False
                bedit.Enabled = False
                bdelete.Enabled = False
                Frame2.Enabled = False
                Frame1.Enabled = True
                txtdcode.SetFocus
                dscodeadd.Close
                Exit Sub
            ElseIf response = vbNo Then
                bsave.Enabled = False
                bdelete.Enabled = False
                bcancel.Enabled = False
                bedit.Enabled = False
                Frame1.Enabled = True
                Frame2.Enabled = True
                bquit.Enabled = True
                txtds.Text = ""
                txtds.SetFocus
                dscodeadd.Close
                Exit Sub

End If
End If
End If
dscodeadd.Close
End Sub

Public Sub cleargrid()
With allshow
    .Clear
    .Rows = 1
    .Cols = 6
    .row = 0
    .ColWidth(0) = 1300
    .ColWidth(1) = 1400
    .ColWidth(2) = 1100
    .ColWidth(3) = 1700
    .ColWidth(4) = 1700
    .ColWidth(5) = 1400
    .col = 0: .Text = "Deposit Code"
    .col = 1: .Text = "Client Code"
    .col = 2: .Text = "No of Check"
    .col = 3: .Text = "citicheckAmount"
    .col = 4: .Text = "CiticashAmount"
    .col = 5: .Text = "Deposit Type"
    
End With
End Sub
Public Sub init_item()
deldata = False
appenddata = False
selectgrid = False
bsave.Enabled = False
bcancel.Enabled = False
bedit.Enabled = False
bdelete.Enabled = False
bquit.Enabled = True
cleargrid
txtds.Text = ""
msdate.Text = "__/__/____"
cmblcode.Clear
cmbbcode.Clear
txtchkno.Text = ""
txtchkamt.Text = ""
txtcashamt.Text = ""
txtdcode.Text = ""
cmbclient.Clear
txtchno.Text = ""
txtcheck.Text = ""
txtcash.Text = ""
chkdtype.Value = 1
Frame1.Enabled = True
Frame2.Enabled = True
txtds.SetFocus
lblAcno = ""

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

Private Sub txtds_Validate(Cancel As Boolean)
On Error GoTo err
Dim iDSprev As Double
Dim SCHDULENO As String
If txtds.Text <> "" Then
    If IsNumeric(txtds.Text) Then
        iDSprev = Trim(txtds.Text) - 1
    Else
      SCHDULENO = Right(txtds.Text, 4)
    End If
End If

Set rs = Nothing
Set rs = ocon.GetResultset("select * from dschedule where ds_code='" & Trim(iDSprev) & "' order by d_code desc")
If (rs.BOF And rs.EOF) Then
  MsgBox "Previous DS no has not used,Plz confirmed that u are not skiping DS no.", vbOKOnly, "CCMS"
  
End If



'*******************Check if data exists or not
Set rs = Nothing
Set rs = ocon.GetResultset("select * from dschedule where ds_code='" & Trim(txtds.Text) & "' order by d_code desc")
If (rs.BOF And rs.EOF) Then


''**********************
            Set rs = Nothing
            Set rs = ocon.GetResultset("select * from schedulestock ")
            
            '''New modification
            
            ''//Select all the schedule stock and check with given no.
            bRangeExist = False
            If Not (rs.BOF And rs.EOF) Then
              Do Until rs.EOF
                If Not (Val(Trim(txtds.Text)) >= Val(Trim(rs!sche_from)) And Val(Trim(txtds.Text)) <= Val(Trim(rs!sche_upto))) Then
                      'MsgBox "Schedule is not in the range", vbOKOnly, "CCMS"
                     ' Exit Sub
                Else
                     bRangeExist = True
                End If
                    rs.MoveNext
                Loop
            Else
              
                MsgBox "Not in the schedule list", vbOKOnly, "CCMS"
            End If
            
            '// Now that no bRangeExist is not true we can understand no record in the table
            '// matched with given no
            If bRangeExist = False Then
              If txtds.Text <> "" Then
               MsgBox "Given No is Not in the Stock", vbOKOnly, "CCMS"
               Cancel = True
              End If
            End If
            
  End If
  Exit Sub
err:
  MsgBox (err.Description)
End Sub
