VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "Msmask32.ocx"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "Msflxgrd.ocx"
Begin VB.Form frmdd 
   Caption         =   "DD Detail"
   ClientHeight    =   7170
   ClientLeft      =   825
   ClientTop       =   255
   ClientWidth     =   11130
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   7170
   ScaleWidth      =   11130
   Begin VB.Frame Frame1 
      Height          =   4755
      Left            =   0
      TabIndex        =   11
      Top             =   0
      Width           =   11085
      Begin VB.ComboBox CmbNikashBrach 
         Height          =   315
         Left            =   4920
         TabIndex        =   6
         Top             =   1440
         Width           =   4695
      End
      Begin VB.TextBox TxtVAT 
         Height          =   360
         Left            =   4935
         TabIndex        =   8
         Top             =   1785
         Width           =   1260
      End
      Begin VB.CommandButton bquit 
         Caption         =   "Quit"
         CausesValidation=   0   'False
         Height          =   315
         Left            =   5280
         TabIndex        =   31
         Top             =   4275
         Width           =   1380
      End
      Begin VB.CommandButton bdelete 
         Caption         =   "Delete"
         Height          =   315
         Left            =   5280
         TabIndex        =   30
         Top             =   3915
         Width           =   1380
      End
      Begin VB.CommandButton bstatus 
         Caption         =   "UpdateStatus"
         Height          =   315
         Left            =   5280
         TabIndex        =   15
         Top             =   2820
         Width           =   1365
      End
      Begin VB.TextBox txtdcode 
         Height          =   285
         Left            =   1440
         MaxLength       =   5
         TabIndex        =   0
         Top             =   720
         Width           =   1020
      End
      Begin VB.TextBox txtamount 
         Height          =   360
         Left            =   4920
         TabIndex        =   9
         Top             =   2190
         Width           =   1260
      End
      Begin VB.TextBox txtddno 
         Height          =   300
         Left            =   1440
         MaxLength       =   18
         TabIndex        =   1
         Top             =   1080
         Width           =   2160
      End
      Begin VB.ComboBox cmbbranch 
         Height          =   315
         Left            =   4935
         TabIndex        =   4
         Top             =   675
         Width           =   4695
      End
      Begin VB.ComboBox cmblocation 
         Height          =   315
         Left            =   4935
         TabIndex        =   5
         Top             =   1080
         Width           =   4695
      End
      Begin VB.ComboBox cmbdrbank 
         Height          =   315
         Left            =   4935
         TabIndex        =   3
         Top             =   360
         Width           =   4695
      End
      Begin VB.TextBox txtdrawer 
         Height          =   300
         Left            =   270
         MaxLength       =   25
         TabIndex        =   7
         Top             =   2070
         Visible         =   0   'False
         Width           =   1995
      End
      Begin VB.CommandButton bclear 
         Caption         =   "Clear"
         Height          =   315
         Left            =   5280
         TabIndex        =   13
         Top             =   3195
         Width           =   1380
      End
      Begin VB.CommandButton bpaid 
         Caption         =   "Paid"
         Height          =   315
         Left            =   5280
         TabIndex        =   12
         Top             =   3555
         Width           =   1380
      End
      Begin MSFlexGridLib.MSFlexGrid ddstatus1 
         Height          =   1905
         Left            =   6840
         TabIndex        =   14
         Top             =   2715
         Width           =   4155
         _ExtentX        =   7329
         _ExtentY        =   3360
         _Version        =   393216
         FixedCols       =   0
      End
      Begin MSMask.MaskEdBox medate 
         Height          =   315
         Left            =   1440
         TabIndex        =   16
         Top             =   360
         Width           =   1125
         _ExtentX        =   1984
         _ExtentY        =   556
         _Version        =   393216
         Enabled         =   0   'False
         MaxLength       =   10
         Format          =   "dd/mm/yyyy"
         Mask            =   "##/##/####"
         PromptChar      =   "_"
      End
      Begin MSMask.MaskEdBox mddate 
         Height          =   315
         Left            =   1440
         TabIndex        =   2
         Top             =   1455
         Width           =   1125
         _ExtentX        =   1984
         _ExtentY        =   556
         _Version        =   393216
         MaxLength       =   10
         Format          =   "dd/mm/yyyy"
         Mask            =   "##/##/####"
         PromptChar      =   "_"
      End
      Begin MSFlexGridLib.MSFlexGrid ddstatus 
         Height          =   1800
         Left            =   240
         TabIndex        =   17
         Top             =   2835
         Width           =   4710
         _ExtentX        =   8308
         _ExtentY        =   3175
         _Version        =   393216
         FixedCols       =   0
      End
      Begin VB.Label Label7 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "VAT"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   315
         Left            =   3720
         TabIndex        =   33
         Top             =   1785
         Width           =   1170
      End
      Begin VB.Label Label1 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "DepositCode"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   225
         Left            =   120
         TabIndex        =   29
         Top             =   720
         Width           =   1215
      End
      Begin VB.Label Label2 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "DD_No"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   225
         Left            =   120
         TabIndex        =   28
         Top             =   1080
         Width           =   1215
      End
      Begin VB.Label Label3 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "DD Date"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
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
         TabIndex        =   27
         Top             =   1440
         Width           =   1215
      End
      Begin VB.Label Label4 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "DD Amount"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   315
         Left            =   3720
         TabIndex        =   26
         Top             =   2190
         Width           =   1170
      End
      Begin VB.Label Label9 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Entry_Date"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   270
         Left            =   120
         TabIndex        =   25
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label lblamt 
         BorderStyle     =   1  'Fixed Single
         Height          =   270
         Left            =   8640
         TabIndex        =   24
         Top             =   1800
         Visible         =   0   'False
         Width           =   1305
      End
      Begin VB.Label lbltamt 
         BorderStyle     =   1  'Fixed Single
         Height          =   285
         Left            =   7320
         TabIndex        =   23
         Top             =   2265
         Width           =   1260
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
         Left            =   3720
         TabIndex        =   22
         Top             =   675
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
         Left            =   3720
         TabIndex        =   21
         Top             =   1035
         Width           =   1185
      End
      Begin VB.Label Label16 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Bank"
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
         Left            =   3720
         TabIndex        =   20
         Top             =   375
         Width           =   1185
      End
      Begin VB.Label Label15 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Drawee"
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
         Left            =   3720
         TabIndex        =   19
         Top             =   1440
         Width           =   1185
      End
      Begin VB.Label Label5 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Total"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00800000&
         Height          =   255
         Left            =   6240
         TabIndex        =   18
         Top             =   2265
         Width           =   975
      End
   End
   Begin MSFlexGridLib.MSFlexGrid ddupdate 
      Height          =   2205
      Left            =   -15
      TabIndex        =   10
      Top             =   4950
      Width           =   11100
      _ExtentX        =   19579
      _ExtentY        =   3889
      _Version        =   393216
      FixedCols       =   0
   End
   Begin VB.Label Label6 
      Caption         =   "Label6"
      Height          =   15
      Left            =   4560
      TabIndex        =   32
      Top             =   5280
      Width           =   15
   End
End
Attribute VB_Name = "frmdd"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim bankcodeadd As New ADODB.Recordset
Dim branchadd As New ADODB.Recordset
Dim locationadd As New ADODB.Recordset
Dim statuscheck As New ADODB.Recordset
Dim delslno As Integer
Dim deldata As Boolean
Dim paiddata As Boolean
Dim open_flag As Boolean
Dim saveall As New ADODB.Recordset
Dim dssave As New ADODB.Recordset
Private Sub bclear_Click()
txtddno.Text = ""
TxtAmount.Text = ""
mddate.Text = "__/__/____"
cmbbranch.Clear
cmblocation.Clear
CmbNikashBrach.Text = ""
lbltamt.Caption = ""
lblamt.Caption = ""
TxtVAT = ""
cleargrid
cleargrid1
bdelete.Enabled = False
bquit.Enabled = True
txtddno.SetFocus
End Sub

Private Sub bdelete_Click()
'Dim delslno1 As Integer
'Dim delslno1 As Integer
paiddata = False
bdelete.Enabled = False
Dim rs As String
Dim rs1 As String
Dim dp1 As String
rs = txtdcode.Text
rs1 = rs + CStr(delslno)
   
If deldata = True Then
If dssave.State = 1 Then dssave.Close
kk = MsgBox("Are you sure you want to Delete?", vbQuestion + vbYesNo)
    If kk = vbNo Then
        Exit Sub
    End If
    ddupdate.col = 0
    
    'oconn.Connection.Execute "delete from dd where d_code='" & Trim(txtdcode.Text) & "' and slno=" & delslno & ""
'''***** Changes date***08-02-2000 ****** don't delete it form dd table , just update status="R"*********
    oconn.Connection.Execute "update dd  set status='R',Entry_date='" & Format(Date, "mm/dd/yyyy") & "' where d_code='" & Trim(txtdcode.Text) & "' and slno=" & delslno & ""
        
    'oconn.Connection.Execute "update normalcollection set status='O' where ddrefno='" & rs1 & "'"
    'new update status_date********23-03-2000*******
    oconn.Connection.Execute "update normalcollection set status='O',status_date='" & Format(Date, "mm/dd/yyyy") & "' where ddrefno='" & rs1 & "'"
    
    dssave.Open ("select nonzoneref from normalcollection where ddrefno='" & rs1 & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
    cleargrid2
        Do While Not dssave.EOF
            dp1 = dssave!nonzoneref
            'oconn.Connection.Execute "update ccheck set status='O' where nonzoneref='" & dp1 & "'"
         'new update entry_date*******24-02-2000*******
            oconn.Connection.Execute "update ccheck set status='O',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where nonzoneref='" & dp1 & "'"
            dssave.MoveNext
            Loop
    End If
    dssave.Close
    
    dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and status is null order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
        cleargrid2
        Do While Not dssave.EOF
        With ddupdate
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                        .col = 0: .Text = dssave!slno
                        .col = 1: .Text = Trim(dssave!dd_no) & ""
                        .col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
                        .col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
                        .col = 4: .Text = Trim(dssave!drawer_brcode) & ""
                        .col = 5: .Text = Trim(dssave!drawer_location) & ""
                        .col = 6: .Text = Trim(dssave!drawee_branch) & ""
                        .col = 7: .Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
                         End With
                        dssave.MoveNext
                        Loop
                        txtddno.Text = ""
                        TxtAmount.Text = ""
                        mddate.Text = "__/__/____"
                        cmbdrbank.Clear
                        cmbbranch.Clear
                        cmblocation.Clear
                        TxtVAT = ""
                        CmbNikashBrach.Text = ""
                        bdelete.Enabled = False
                        bquit.Enabled = True
                        
    ElseIf dssave.RecordCount = 0 Then
                        txtdcode.Text = ""
                        txtddno.Text = ""
                        TxtAmount.Text = ""
                        mddate.Text = "__/__/____"
                        cmbdrbank.Clear
                        cmbbranch.Clear
                        cmblocation.Clear
                        TxtVAT = ""
                        CmbNikashBrach.Text = ""
                        bdelete.Enabled = False
                        bquit.Enabled = True
                        txtdcode.SetFocus
    End If
 End If

If dssave.State = 1 Then dssave.Close
   
End Sub

Private Sub bpaid_Click()
If paiddata Then
    bpaid.Enabled = False
    Dim rs As String
    Dim rs1 As String
    Dim dp1 As String
    rs = txtdcode.Text
    rs1 = rs + CStr(delslno)
    If dssave.State = 1 Then dssave.Close
    
    'oconn.Connection.Execute "update dd set status='P' where d_code='" & Trim(txtdcode.Text) & "' and slno=" & delslno & ""
  'new update entry_date*******24-02-2000*******
    oconn.Connection.Execute "update dd set status='P',Entry_date='" & Format(Date, "mm/dd/yyyy") & "' where d_code='" & Trim(txtdcode.Text) & "' and slno=" & delslno & ""
    
    'oconn.Connection.Execute "update normalcollection set status='P',status_date='" & Format(mddate.Text, "mm/dd/yyyy") & "' where ddrefno='" & rs1 & "'"
'** Change 05-02-2000***update status_date as System Date***********
    oconn.Connection.Execute "update normalcollection set status='P',status_date='" & Format(Date, "mm/dd/yyyy") & "' where ddrefno='" & rs1 & "'"
    
    dssave.Open ("select nonzoneref from normalcollection where ddrefno='" & rs1 & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then
        Do While Not dssave.EOF
            dp1 = dssave!nonzoneref
            'oconn.Connection.Execute "update ccheck set status='P' where nonzoneref='" & dp1 & "'"
          'new update entry_date***24-02-2000******
            oconn.Connection.Execute "update ccheck set status='P',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where nonzoneref='" & dp1 & "'"
            dssave.MoveNext
        Loop
    End If
    dssave.Close
        
    dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and slno<>" & delslno & " and status is null order by slno"), oconn.Connection, adOpenKeyset, adLockOptimistic
    
    If dssave.RecordCount > 0 Then
        cleargrid2
        Do While Not dssave.EOF
            With  ddupdate
            .Rows = .Rows + 1
            .row = .Rows - 1
            ddupdate.col = 0
            ddupdate.Text = dssave!slno
            ddupdate.col = 1
            ddupdate.Text = Trim(dssave!dd_no) & ""
            ddupdate.col = 2
            ddupdate.Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
            ddupdate.col = 3
            ddupdate.Text = Trim(dssave!drawer_bankcode) & ""
            ddupdate.col = 4
            ddupdate.Text = Trim(dssave!drawer_brcode) & ""
            ddupdate.col = 5
            ddupdate.Text = Trim(dssave!drawer_location) & ""
            ddupdate.col = 6
            ddupdate.Text = Trim(dssave!drawee_branch) & ""
            ddupdate.col = 7
            ddupdate.Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
            End With
            dssave.MoveNext
            Loop
            txtddno.Text = ""
            TxtAmount.Text = ""
            mddate.Text = "__/__/____"
            cmbdrbank.Clear
            cmbbranch.Clear
            cmblocation.Clear
            CmbNikashBrach.Text = ""
            TxtVAT = ""
            bdelete.Enabled = False
            bquit.Enabled = True
            dssave.Close
            Exit Sub
            
    ElseIf dssave.RecordCount = 0 Then
            txtddno.Text = ""
            TxtAmount.Text = ""
            mddate.Text = "__/__/____"
            TxtVAT = ""
            cmbdrbank.Clear
            cmbbranch.Clear
            cmblocation.Clear
            cleargrid2
            CmbNikashBrach.Text = ""
            bdelete.Enabled = False
            bquit.Enabled = True
        
    End If
    dssave.Close
 End If
If dssave.State = 1 Then dssave.Close
End Sub

Private Sub bquit_Click()
kk = MsgBox("Are you sure you want to exit?", vbYesNo + vbQuestion)
If kk = vbNo Then
    txtdcode.SetFocus
    Exit Sub
Else
    Unload Me
    frmMain.Show
End If
End Sub


Private Sub bstatus_Click()
If Not deldata Then

    If txtddno.Text = "" Then
        MsgBox "Must enter DDno"
        txtddno.SetFocus
        Exit Sub
    End If
    If TxtAmount.Text = "" Then
         MsgBox "Must enter amount"
         TxtAmount.SetFocus
         Exit Sub
    End If
    
    Dim intcounter As Integer
    bquit.Enabled = False
    bdelete.Enabled = False
    Dim icounter As Integer
    Dim nn As Currency
    Dim nn1 As Currency
    Dim xx As Integer
    Dim kk As Currency
    If dssave.State = 1 Then dssave.Close
    If Val(TxtAmount.Text) >= Val(lbltamt.Caption) Then
        nn = Val(TxtAmount.Text) - Val(lbltamt.Caption)
        msg = "DD amount is Excess  " & Format(nn, "#,##,##,##,##0.00") & "   ADD MORE ?"
        style = vbInformation + vbDefaultButton3 + vbYesNo
        title = "Mismatch"
        response = MsgBox(msg, style, title)
        If response = vbYes Then
            Exit Sub
        ElseIf response = vbNo Then
            dssave.Open ("select isnull(max(slno),0) as slno from dd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount = 0 Then
                xx = 1
            ElseIf dssave.RecordCount <> 0 Then
                dssave.MoveLast
                xx = dssave!slno + 1
            End If
            dssave.Close
            If saveall.State = 1 Then saveall.Close
            saveall.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
            If saveall.RecordCount = 0 Then
                With saveall
                .AddNew
                !d_code = Trim(txtdcode.Text)
                !slno = xx
                !dd_no = Trim(txtddno.Text)
                If mddate.Text <> "__/__/____" Then
                    !dd_date = Format(mddate.Text, "dd/mm/yyyy")
                End If
                !Entry_date = Format(medate.Text, "dd/mm/yyyy")
                !Amount = Val(TxtAmount.Text)
                !drawer_bankcode = Left(cmbdrbank.Text, 3)
                !drawer_brcode = Left(cmbbranch.Text, 3)
                !drawer_location = Left(cmblocation.Text, 3)
                !NikBranch_code = Left(Trim(CmbNikashBrach.Text), 7)
                !vat = Val(TxtVAT.Text)
                !drawee_branch = Left(Mid(Trim(CmbNikashBrach.Text), 11), 25)
                .Update
                End With
                saveall.Close
                End If

                cleargrid2
                dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
                Do While Not dssave.EOF
                    With ddupdate
                    .Rows = .Rows + 1
                    .row = .Rows - 1
                    .col = 0: .Text = dssave!slno
                    .col = 1: .Text = Trim(dssave!dd_no) & ""
                    .col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
                    .col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
                    .col = 4: .Text = Trim(dssave!drawer_brcode) & ""
                    .col = 5: .Text = Trim(dssave!drawer_location) & ""
                    .col = 6: .Text = Trim(dssave!drawee_branch) & ""
                    .col = 7: .Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
                    End With
                    dssave.MoveNext
                    Loop
                    dssave.Close
                    With ddstatus1
                        For intcounter = 1 To ddstatus1.Rows - 1
                        ddstatus1.row = intcounter
                        ddstatus1.col = 0
                        'oconn.Connection.Execute "update ccheck set status='D' where nonzoneref='" & Trim(.Text) & "' and status ='O'"
                     'new update entry_date*******24-02-2000*******
                        oconn.Connection.Execute "update ccheck set status='D',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where nonzoneref='" & Trim(.Text) & "' and status ='O'"
                        Next
                        End With
        
                    Dim kk1 As String
                    Dim kk2 As String
                    Dim mm As String
                    Dim intcounter1 As Integer
        
                    kk1 = txtdcode.Text
                    kk2 = kk1 + CStr(xx)
                    With ddstatus1
                    For intcounter1 = 1 To ddstatus1.Rows - 1
                         ddstatus1.row = intcounter1
                         ddstatus1.col = 0
            
                    dssave.Open ("select nonzoneref from normalcollection where nonzoneref='" & Trim(.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                    If dssave.RecordCount > 0 Then
                        mm = dssave!nonzoneref
                        .col = 2
                        oconn.Connection.Execute "update normalcollection set status='D',status_date='" & Format(Date, "mm/dd/yyyy") & "',ddrefno='" & kk2 & "',collectedamount =" & Trim(.Text) & ",vat =" & (TxtVAT.Text / lbltamt) * Trim(.Text) & " where nonzoneref='" & mm & "'"
                    End If
                    dssave.Close
                    Next
                End With
                txtddno.Text = ""
                TxtAmount.Text = ""
                mddate.Text = "__/__/____"
                cmbbranch.Clear
                cmblocation.Clear
                CmbNikashBrach.Text = ""
                lbltamt.Caption = ""
                lblamt.Caption = ""
                TxtVAT = ""
                cleargrid
                cleargrid1
                bdelete.Enabled = False
                bquit.Enabled = True
                txtddno.SetFocus
        End If

ElseIf Val(TxtAmount.Text) < Val(lbltamt.Caption) Then
        nn1 = Val(lbltamt.Caption) - Val(TxtAmount.Text)
        msg = "DD amount is Less  " & Format(nn1, "#,##,##,##,##0.00") & "   Change?"
        style = vbInformation + vbDefaultButton3 + vbYesNo
        title = "Mismatch"
        response = MsgBox(msg, style, title)
        If response = vbYes Then
            cleargrid1
            lbltamt.Caption = ""
            Exit Sub
        ElseIf response = vbNo Then
            dssave.Open ("select isnull(max(slno),0) as slno from dd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount = 0 Then
                xx = 1
            ElseIf dssave.RecordCount <> 0 Then
                dssave.MoveLast
                xx = dssave!slno + 1
            End If
            dssave.Close
            If saveall.State = 1 Then saveall.Close
            saveall.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and slno=" & xx & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
            If saveall.RecordCount = 0 Then
                With saveall
                .AddNew
                !d_code = Trim(txtdcode.Text)
                !slno = xx
                !dd_no = Trim(txtddno.Text)
                If mddate.Text <> "__/__/____" Then
                !dd_date = Format(mddate.Text, "dd/mm/yyyy")
                End If
                !Entry_date = Format(medate.Text, "dd/mm/yyyy")
                !Amount = Val(TxtAmount.Text)
                !drawer_bankcode = Left(cmbdrbank.Text, 3)
                !drawer_brcode = Left(cmbbranch.Text, 3)
                !drawer_location = Left(cmblocation.Text, 3)
                !NikBranch_code = Left(Trim(CmbNikashBrach.Text), 7)
                !drawee_branch = Trim(Left(Mid(Trim(CmbNikashBrach.Text), 11), 25))
                !vat = Val(TxtVAT.Text)
                .Update
                End With
                'saveall.Close
                End If
                cleargrid2
                dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' order by slno desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
                Do While Not dssave.EOF
                    With ddupdate
                    .Rows = .Rows + 1
                    .row = .Rows - 1
                    .col = 0: .Text = dssave!slno
                    .col = 1: .Text = Trim(dssave!dd_no) & ""
                    .col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
                    .col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
                    .col = 4: .Text = Trim(dssave!drawer_brcode) & ""
                    .col = 5: .Text = Trim(dssave!drawer_location) & ""
                    .col = 6: .Text = Trim(dssave!drawee_branch) & ""
                    .col = 7: .Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
                    End With
                    dssave.MoveNext
                Loop
                dssave.Close
                
                
                With ddstatus1
                For intcounter = 1 To ddstatus1.Rows - 1
                    ddstatus1.row = intcounter
                    ddstatus1.col = 0
                    'oconn.Connection.Execute "update ccheck set status='D'where nonzoneref='" & Trim(.Text) & "' and status ='O'"
                'new update entry_date********24-02-2000*******
                    oconn.Connection.Execute "update ccheck set status='D',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where nonzoneref='" & Trim(.Text) & "' and status ='O'"

                Next
                End With

                
                  kk1 = txtdcode.Text
                  kk2 = kk1 + CStr(xx)
                  With ddstatus1
                  For intcounter1 = 1 To ddstatus1.Rows - 1
                 ddstatus1.row = intcounter1
                 ddstatus1.col = 0
                 dssave.Open ("select nonzoneref from normalcollection where nonzoneref='" & Trim(.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                 If dssave.RecordCount > 0 Then
                      mm = dssave!nonzoneref
                      .col = 2
                       oconn.Connection.Execute "update normalcollection set status='D',status_date='" & Format(Date, "mm/dd/yyyy") & "',ddrefno='" & kk2 & "',collectedamount =" & (TxtAmount.Text / lbltamt) * Trim(.Text) & ",vat =" & (TxtVAT.Text / lbltamt) * Trim(.Text) & "  where nonzoneref='" & mm & "'"
                 End If
                 dssave.Close
                 Next
                End With
                txtddno.Text = ""
                TxtAmount.Text = ""
                mddate.Text = "__/__/____"
                TxtVAT = ""
                cmbbranch.Clear
                cmblocation.Clear
                CmbNikashBrach.Text = ""
                lbltamt.Caption = ""
                lblamt.Caption = ""
                cleargrid
                cleargrid1
                bdelete.Enabled = False
                bquit.Enabled = True
                txtddno.SetFocus

        End If

End If
End If
If dssave.State = 1 Then dssave.Close

       
       ' oconn.Connection.Execute "update normalcollection set status='R',status_date='" & Format(rdate.Text, "mm/dd/yyyy") & "' where nonzoneref='" & Trim(txtrefno.Text) & "'"
'End If
'kk = Val((lbltamt.Caption * 99.8) / 100)
'If Val(txtamount.Text) < kk Then
'  MsgBox "DD amount is less then checkamount"
'  Exit Sub
'End If
'dssave.Open ("select * from ccheck where drawee_bankcode='" & Left(cmbdrbank.Text, 3) & "' and branch_code='" & Left(cmbbranch.Text, 3) & "' and location_code='" & Left(cmblocation.Text, 3) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'If dssave.RecordCount > 0 Then
'        For intcounter = 1 To ddstatus1.Rows - 1
'        oconn.Connection.Execute "update ccheck set status='ddopen' where rejectref='" & Trim(ddstatus1.Text) & "'"
'        Next
'    dssave.Close
'End If
'
''----------------
'With ddupdate
'    .Rows = .Rows + 1
'    .Row = .Rows - 1
'    .Col = 1: .Text = Trim(txtddno.Text)
'    .Col = 2: .Text = Format(mddate.Text, "dd/mm/yyyy")
'    .Col = 3: .Text = Left(cmbdrbank.Text, 3)
'    .Col = 4: .Text = Left(cmbbranch.Text, 3)
'    .Col = 5: .Text = Left(cmblocation.Text, 3)
'    .Col = 6: .Text = Val(txtamount.Text)
'End With
'Dim intserialnumber As Integer
''Dim icounter As Integer
'    With ddupdate
'        For icounter = 1 To .Rows - 1
'            .Row = icounter
'            .Col = 0: .Text = icounter
'        Next
'        intserialnumber = icounter - 1
'    End With




End Sub

Private Sub cmbbranch_DropDown()
If cmblocation.Text = "" Then
   'Set branchadd = Nothing
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
End Sub

Private Sub cmbbranch_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub cmbdrbank_DropDown()
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



Private Sub Command2_Click()
'''cleargrid2
'''deldata = False
'''paiddata = False
'''If Trim(txtdcode.Text) <> "" Then
'''    If Len(txtdcode.Text) < 5 Then
'''        MsgBox "Must enter 5 digits"
'''        txtdcode.Text = ""
'''        txtdcode.SetFocus
'''        Exit Sub
'''    End If
'''End If
'''If saveall.State = 1 Then saveall.Close
'''saveall.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''
'''     If saveall.RecordCount > 0 Then
'''            msg = "Duplicate Data,Want to Delete?"
'''            style = vbInformation + vbDefaultButton2 + vbYesNo
'''            title = "Duplicate Data"
'''            response = MsgBox(msg, style, title)
'''            If response = vbYes Then
'''                deldata = True
'''                paiddata = False
'''                bdelete.Enabled = True
'''                bclear.Enabled = True
'''                bstatus.Enabled = False
'''                bpaid.Enabled = False
'''                bquit.Enabled = True
'''                dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and status is null "), oconn.Connection, adOpenKeyset, adLockOptimistic
'''                If dssave.RecordCount > 0 Then
'''                    With dssave
'''                    Do While Not dssave.EOF
'''                        With ddupdate
'''                        .Rows = .Rows + 1
'''                        .Row = .Rows - 1
'''                        .Col = 0: .Text = dssave!slno
'''                        .Col = 1: .Text = Trim(dssave!dd_no) & ""
'''                        .Col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
'''                        .Col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
'''                        .Col = 4: .Text = Trim(dssave!drawer_brcode) & ""
'''                        .Col = 5: .Text = Trim(dssave!drawer_location) & ""
'''                        .Col = 6: .Text = Trim(dssave!drawee_branch) & ""
'''                        .Col = 7: .Text = Format(dssave!amount, "#,##,##,##,##0.00") & ""
'''                         End With
'''                        .MoveNext
'''                        Loop
'''                        End With
'''                        bclear.SetFocus
'''                 End If
'''                 dssave.Close
'''                 'saveall.Close
'''
'''            ElseIf response = vbNo Then
'''                        msg = "Want to Update Payment ?  "
'''                        style = vbInformation + vbDefaultButton2 + vbYesNo
'''                        title = "Duplicate Data"
'''                        response = MsgBox(msg, style, title)
'''                        If response = vbYes Then
'''                                   paiddata = True
'''                                   deldata = False
'''                                   bdelete.Enabled = False
'''                                   bpaid.Enabled = True
'''                                   bclear.Enabled = True
'''                                   bstatus.Enabled = False
'''                                   bquit.Enabled = True
'''                                   dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and status is null"), oconn.Connection, adOpenKeyset, adLockOptimistic
'''                                   If dssave.RecordCount > 0 Then
'''                                       With dssave
'''                                       Do While Not dssave.EOF
'''                                           With ddupdate
'''                                           .Rows = .Rows + 1
'''                                           .Row = .Rows - 1
'''                                           .Col = 0: .Text = dssave!slno
'''                                            .Col = 1: .Text = Trim(dssave!dd_no) & ""
'''                                            .Col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
'''                                            .Col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
'''                                            .Col = 4: .Text = Trim(dssave!drawer_brcode) & ""
'''                                            .Col = 5: .Text = Trim(dssave!drawer_location) & ""
'''                                            .Col = 6: .Text = Trim(dssave!drawee_branch) & ""
'''                                            .Col = 7: .Text = Format(dssave!amount, "#,##,##,##,##0.00") & ""
'''                                             End With
'''                                            dssave.MoveNext
'''                                            Loop
'''                                            End With
'''                                            bclear.SetFocus
'''                                        End If
'''                                        dssave.Close
'''                                        'saveall.Close
'''                                        Exit Sub
'''                                ElseIf response = vbNo Then
'''                                        txtdcode.Text = ""
'''                                        txtdcode.SetFocus
'''                                End If
'''                        End If
'''
'''
'''            'saveall.Close
'''            End If

End Sub



Private Sub CmbNikashBrach_DropDown()
    'Set branchadd = Nothing
    branchadd.Open ("select nikbranch_code,branch_name from nikbranch where branch_name like '" & Trim(CmbNikashBrach.Text) & "%' and bank_code='" & Left(cmbdrbank.Text, 3) & "' order by branch_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
    CmbNikashBrach.Clear
    If branchadd.RecordCount > 0 Then
        Do While Not branchadd.EOF
        CmbNikashBrach.AddItem Trim(branchadd!NikBranch_code) + Space(2) + ":" + Trim(branchadd!Branch_name)
        branchadd.MoveNext
        Loop
    End If
    branchadd.Close

End Sub

Private Sub CmbNikashBrach_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub ddstatus_Click()
Dim kk As Currency
Dim kk1 As Currency
Dim drec As Integer
Dim intEditRecordNumber As Integer
If ddstatus1.Rows > 1 Then
    For drec = 1 To ddstatus1.Rows - 1
        ddstatus1.row = drec
        ddstatus.col = 0
        ddstatus1.col = 0
        
        If Trim(ddstatus1.Text) = Trim(ddstatus.Text) Then
            MsgBox "You have already entered this Item !", vbCritical
            
            'Cancel = True
            Exit Sub
        End If
    Next
End If
            
            
  With ddstatus
    .col = 2: lblamt.Caption = Trim(.Text)
  
    ddstatus.col = 0
    ddstatus1.Rows = ddstatus1.Rows + 1
    ddstatus1.row = ddstatus1.Rows - 1
    ddstatus1.col = 0
    ddstatus1.Text = Trim(ddstatus.Text)
    lbltamt.Caption = Val(lblamt.Caption) + Val(lbltamt.Caption)
    ddstatus.col = 1
    ddstatus1.col = 1
    ddstatus1.Text = Trim(ddstatus.Text)
    ddstatus.col = 2
    ddstatus1.col = 2
    ddstatus1.Text = Trim(ddstatus.Text)
End With
        
End Sub

Private Sub ddupdate_Click()
If paiddata Then
    deldata = False
    bdelete.Enabled = False
    bquit.Enabled = False
    bpaid.Enabled = True
End If
If deldata Then
    paiddata = False
    bpaid.Enabled = False
    bquit.Enabled = False
    bdelete.Enabled = True
End If

If deldata = True Or paiddata = True Then
    If ddupdate.Rows > 1 Then
        With ddupdate
        .col = 0:
        dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and slno=" & Trim(.Text) & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
        If dssave.RecordCount > 0 Then
                        '.Col = 0: .Text = dssave!slno
                       delslno = dssave!slno
                       txtddno.Text = Trim(dssave!dd_no) & ""
                       mddate.Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
                       cmbdrbank.Text = Trim(dssave!drawer_bankcode) & ""
                       cmbbranch.Text = Trim(dssave!drawer_brcode) & ""
                       cmblocation.Text = Trim(dssave!drawer_location) & ""
                       CmbNikashBrach.Text = IIf(IsNull(Trim(dssave!NikBranch_code)) = True, 0, Trim(dssave!NikBranch_code))
                       TxtAmount.Text = Trim(dssave!Amount) & ""
                       
                        End If
            dssave.Close
        End With
    End If
End If

End Sub

Private Sub Form_Load()
Move (frmMain.Height - Height) / 2, (frmMain.width - width) / 2
bpaid.Enabled = False
bstatus.Enabled = False
bclear.Enabled = False
bdelete.Enabled = False
bquit.Enabled = True
medate.Text = Format(Date, "dd/mm/yyyy")
cleargrid
cleargrid1
cleargrid2
End Sub

Private Sub mddate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub mddate_Validate(Cancel As Boolean)
'    If mddate.Text = "" Then
'        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
'        Cancel = True
'        Exit Sub
'     End If
     If oDate.Validate(mddate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
        Cancel = True
        Exit Sub
     End If
End Sub

Private Sub TxtAmount_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
lblamt.Caption = ""
lbltamt.Caption = ""
cleargrid
cleargrid1
End Sub

Private Sub txtamount_LostFocus()
cleargrid
statuscheck.Open ("select * from ccheck where drawee_bankcode='" & Left(cmbdrbank.Text, 3) & "' and branch_code='" & Left(cmbbranch.Text, 3) & "' and location_code='" & Left(cmblocation.Text, 3) & "' and status='O' and nonzoneref>'0'"), oconn.Connection, adOpenKeyset, adLockOptimistic
If statuscheck.RecordCount > 0 Then
    

    If statuscheck.RecordCount > 0 Then

        Do While Not statuscheck.EOF
        With ddstatus
                .Rows = .Rows + 1
                .row = .Rows - 1
                 
                .col = 0: .Text = statuscheck!nonzoneref & ""
                .col = 1: .Text = statuscheck!check_no & ""
                .col = 2: .Text = Val(statuscheck!Amount) & ""
                
        End With
        statuscheck.MoveNext
        Loop
    End If
End If
statuscheck.Close
End Sub

Public Sub cleargrid()
With ddstatus
    .Clear
    .Rows = 1
    .Cols = 3
    .row = 0
    .ColWidth(0) = 1300
    .ColWidth(1) = 1400
    .ColWidth(2) = 1100

    .col = 0: .Text = "Ref No"
    .col = 1: .Text = "Check_no"
    .col = 2: .Text = "Amount"

End With



End Sub

Private Sub txtdcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
bstatus.Enabled = True
bclear.Enabled = True
TxtAmount.Text = ""
mddate.Text = "__/__/____"
cmbdrbank.Clear
cmbbranch.Clear
cmblocation.Clear
CmbNikashBrach.Text = ""
lbltamt.Caption = ""
lblamt.Caption = ""
TxtVAT = ""
cleargrid
cleargrid2

End Sub

Private Sub txtdcode_LostFocus()
cleargrid2
deldata = False
paiddata = False
If Trim(txtdcode.Text) <> "" Then
    If Len(txtdcode.Text) < 5 Then
        MsgBox "Must enter 5 digits"
        txtdcode.Text = ""
        txtdcode.SetFocus
        Exit Sub
    End If
End If
If saveall.State = 1 Then saveall.Close
saveall.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    
     If saveall.RecordCount > 0 Then
            msg = "Duplicate Data,Want to Delete?"
            style = vbInformation + vbDefaultButton2 + vbYesNo
            title = "Duplicate Data"
            response = MsgBox(msg, style, title)
            If response = vbYes Then
                deldata = True
                paiddata = False
                bdelete.Enabled = True
                bclear.Enabled = True
                bstatus.Enabled = False
                bpaid.Enabled = False
                bquit.Enabled = True
                dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and status is null "), oconn.Connection, adOpenKeyset, adLockOptimistic
                If dssave.RecordCount > 0 Then
                    With dssave
                    Do While Not dssave.EOF
                        With ddupdate
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                        .col = 0: .Text = dssave!slno
                        .col = 1: .Text = Trim(dssave!dd_no) & ""
                        .col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
                        .col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
                        .col = 4: .Text = Trim(dssave!drawer_brcode) & ""
                        .col = 5: .Text = Trim(dssave!drawer_location) & ""
                        .col = 6: .Text = Trim(dssave!drawee_branch) & ""
                        .col = 7: .Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
                         End With
                        .MoveNext
                        Loop
                        End With
                        bclear.SetFocus
                 End If
                 dssave.Close
                 
            ElseIf response = vbNo Then
                        msg = "Want to Update Payment ?  "
                        style = vbInformation + vbDefaultButton2 + vbYesNo
                        title = "Duplicate Data"
                        response = MsgBox(msg, style, title)
                        If response = vbYes Then
                                   paiddata = True
                                   deldata = False
                                   bdelete.Enabled = False
                                   bpaid.Enabled = True
                                   bclear.Enabled = True
                                   bstatus.Enabled = False
                                   bquit.Enabled = True
                                   dssave.Open ("select * from dd where d_code='" & Trim(txtdcode.Text) & "' and status is null"), oconn.Connection, adOpenKeyset, adLockOptimistic
                                   If dssave.RecordCount > 0 Then
                                       With dssave
                                       Do While Not dssave.EOF
                                           With ddupdate
                                           .Rows = .Rows + 1
                                           .row = .Rows - 1
                                           .col = 0: .Text = dssave!slno
                                            .col = 1: .Text = Trim(dssave!dd_no) & ""
                                            .col = 2: .Text = Format(dssave!dd_date, "dd/mm/yyyy") & ""
                                            .col = 3: .Text = Trim(dssave!drawer_bankcode) & ""
                                            .col = 4: .Text = Trim(dssave!drawer_brcode) & ""
                                            .col = 5: .Text = Trim(dssave!drawer_location) & ""
                                            .col = 6: .Text = Trim(dssave!drawee_branch) & ""
                                            .col = 7: .Text = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
                                             End With
                                            dssave.MoveNext
                                            Loop
                                            End With
                                            bclear.SetFocus
                                        End If
                                        dssave.Close
                                        If saveall.State = 1 Then saveall.Close
                                        Exit Sub
                                ElseIf response = vbNo Then
                                        txtdcode.Text = ""
                                        txtdcode.SetFocus
                                End If
                        End If
            End If

End Sub



Public Sub cleargrid1()
With ddstatus1
     .Clear
    .Rows = 1
    .Cols = 3
    .row = 0
    .ColWidth(0) = 1300
    .ColWidth(1) = 1400
    .ColWidth(2) = 1100
    
    .col = 0: .Text = "Ref No"
    .col = 1: .Text = "Check_no"
    .col = 2: .Text = "Amount"
    
    
    
End With
End Sub

Public Sub cleargrid2()
With ddupdate
    .Clear
    .Rows = 1
    .Cols = 8
    .row = 0
    .ColWidth(0) = 1300
    .ColWidth(1) = 1400
    .ColWidth(2) = 1100
    .ColWidth(3) = 1700
    .ColWidth(4) = 1700
    .ColWidth(5) = 1400
    .ColWidth(6) = 1400
    .ColWidth(7) = 1400
    .col = 0: .Text = "Slno"
    .col = 1: .Text = "DDNo"
    .col = 2: .Text = "DD_Date"
    .col = 3: .Text = "Bank"
    .col = 4: .Text = "Branch"
    .col = 5: .Text = "Location"
    .col = 6: .Text = "Drawee"
    .col = 7: .Text = "DD Amount"
End With
End Sub

Private Sub txtddno_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtdrawer_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub



Private Sub TxtVAT_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub
