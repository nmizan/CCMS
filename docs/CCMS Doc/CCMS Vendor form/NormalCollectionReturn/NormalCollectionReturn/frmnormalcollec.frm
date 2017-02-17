VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "MSMASK32.OCX"
Begin VB.Form frmnormalcollect 
   Caption         =   "Normal Collection Return"
   ClientHeight    =   4725
   ClientLeft      =   3360
   ClientTop       =   2700
   ClientWidth     =   6165
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   4725
   ScaleWidth      =   6165
   Begin VB.CommandButton CmbtnUpdate 
      Caption         =   "Update Status"
      CausesValidation=   0   'False
      Height          =   375
      Left            =   2520
      TabIndex        =   26
      Top             =   4200
      Width           =   1455
   End
   Begin VB.Frame Frame1 
      Height          =   4695
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   6135
      Begin VB.TextBox TxtCheckNo 
         Height          =   285
         Left            =   3960
         MaxLength       =   15
         TabIndex        =   27
         Top             =   240
         Width           =   1815
      End
      Begin VB.CommandButton bquit 
         Caption         =   "Close"
         CausesValidation=   0   'False
         Height          =   375
         Left            =   1440
         TabIndex        =   23
         Top             =   4200
         Width           =   975
      End
      Begin VB.TextBox txtrcode 
         Height          =   330
         Left            =   4440
         MaxLength       =   2
         TabIndex        =   3
         Top             =   1320
         Width           =   780
      End
      Begin VB.TextBox txtrefno 
         Height          =   285
         Left            =   1200
         MaxLength       =   7
         TabIndex        =   1
         Top             =   240
         Width           =   1575
      End
      Begin MSMask.MaskEdBox rdate 
         Height          =   345
         Left            =   1200
         TabIndex        =   2
         Top             =   720
         Width           =   1335
         _ExtentX        =   2355
         _ExtentY        =   609
         _Version        =   393216
         Enabled         =   0   'False
         MaxLength       =   10
         Format          =   "dd/mm/yyyy"
         Mask            =   "##/##/####"
         PromptChar      =   "_"
      End
      Begin VB.Label lblAcno 
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   1560
         TabIndex        =   30
         Top             =   3600
         Width           =   2775
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
         Height          =   285
         Left            =   120
         TabIndex        =   29
         Top             =   3600
         Width           =   1230
      End
      Begin VB.Label Label14 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Check No"
         Height          =   270
         Left            =   2880
         TabIndex        =   28
         Top             =   240
         Width           =   960
      End
      Begin VB.Label Label13 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1200
         TabIndex        =   25
         Top             =   1440
         Width           =   1695
      End
      Begin VB.Label Label12 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "CheckRef"
         Height          =   255
         Left            =   120
         TabIndex        =   24
         Top             =   1440
         Width           =   975
      End
      Begin VB.Label Label1 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "RefNo"
         Height          =   270
         Left            =   120
         TabIndex        =   22
         Top             =   240
         Width           =   960
      End
      Begin VB.Label Label4 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Return Date"
         Height          =   255
         Left            =   120
         TabIndex        =   21
         Top             =   720
         Width           =   975
      End
      Begin VB.Label Label3 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Check_no"
         Height          =   255
         Left            =   120
         TabIndex        =   20
         Top             =   1080
         Width           =   975
      End
      Begin VB.Label Label5 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Amount"
         Height          =   255
         Left            =   120
         TabIndex        =   19
         Top             =   1800
         Width           =   975
      End
      Begin VB.Label lblchkno 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1200
         TabIndex        =   18
         Top             =   1080
         Width           =   1695
      End
      Begin VB.Label Label7 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Deposit_Code"
         Height          =   255
         Left            =   3120
         TabIndex        =   17
         Top             =   1800
         Width           =   1095
      End
      Begin VB.Label lbldcode 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   4440
         TabIndex        =   16
         Top             =   1800
         Width           =   1095
      End
      Begin VB.Label lblamount 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1200
         TabIndex        =   15
         Top             =   1800
         Width           =   1455
      End
      Begin VB.Label lblClient 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1560
         TabIndex        =   14
         Top             =   3240
         Width           =   3975
      End
      Begin VB.Label Label8 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Client_code"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   3240
         Width           =   1335
      End
      Begin VB.Label lblbank 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1560
         TabIndex        =   12
         Top             =   2520
         Width           =   3975
      End
      Begin VB.Label Label9 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Drawee_Bank"
         Height          =   255
         Left            =   120
         TabIndex        =   11
         Top             =   2520
         Width           =   1335
      End
      Begin VB.Label lblbranch 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1560
         TabIndex        =   10
         Top             =   2880
         Width           =   3975
      End
      Begin VB.Label Label10 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Drawee_Branch"
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   2880
         Width           =   1335
      End
      Begin VB.Label Label6 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Return_Code"
         Height          =   255
         Left            =   3120
         TabIndex        =   8
         Top             =   1320
         Width           =   1095
      End
      Begin VB.Label lblstatus 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   1200
         TabIndex        =   7
         Top             =   2160
         Width           =   1815
      End
      Begin VB.Label Label11 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Status"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   2160
         Width           =   975
      End
      Begin VB.Label Label2 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Status Date"
         Height          =   255
         Left            =   3120
         TabIndex        =   5
         Top             =   2160
         Width           =   975
      End
      Begin VB.Label lblstdate 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   4200
         TabIndex        =   4
         Top             =   2160
         Width           =   1335
      End
   End
End
Attribute VB_Name = "frmnormalcollect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim returncheck As New ADODB.Recordset
Dim dssave As New ADODB.Recordset

Private Sub bcancel_Click()
If txtrefno.Text = "" Or txtrefno.Text <> "" Then
    txtrefno.Text = ""
    rdate.Text = "__/__/____"
    txtrcode.Text = ""
    lbldcode.Caption = ""
    lblClient.Caption = ""
    lblchkno.Caption = ""
    lblamount.Caption = ""
    lblbank.Caption = ""
    lblbranch.Caption = ""
    lblstatus.Caption = ""
    lblstdate.Caption = ""
    txtrefno.SetFocus
    'bcancel.Enabled = False
    bquit.Enabled = True
End If
End Sub

Private Sub bquit_Click()
If txtrefno.Text = "" Or txtrefno.Text <> "" Then
    kk = MsgBox("Are you sure you want to exit?", vbYesNo + vbQuestion)
        If kk = vbNo Then
            txtrefno.SetFocus
            Exit Sub
        Else
            Unload Me
            frmMain.Show
        End If
End If
'End If

End Sub

Private Sub bsave_Click()

End Sub

Private Sub CmbtnUpdate_Click()

''###########For Authorization #################
  If Authorized = False Then
   ' Command2.Enabled = True
    Exit Sub
  End If
  
  If Trim(oLoginUser.UserId) = s_user Then
         MsgBox "Login user Cannot Authorize this record,Another authorizer is required for authorization.", vbOKOnly, "CCMS"
  Exit Sub
  End If
   
  
''################################################
If txtrefno.Text <> "" Then
    Set rs = Nothing
    Set rs = ocon.GetResultset("update Ccheck set status='O' where nonzoneref= '" & txtrefno.Text & "'")
    MsgBox " Data updated succesfuly ", vbOKOnly, "CCMS"
ElseIf TxtCheckNo.Text <> "" Then
    Set rs = Nothing
    Set rs = ocon.GetResultset("update Ccheck set status='O' where check_no='" & TxtCheckNo.Text & "'")
    MsgBox " Data updated succesfuly ", vbOKOnly, "CCMS"

ElseIf (TxtCheckNo.Text <> "") And (txtrefno.Text <> "") Then
    Set rs = Nothing
    Set rs = ocon.GetResultset("update Ccheck set status='O' where check_no= '" & TxtCheckNo.Text & "' and nonzoneref='" & TxtCheckNo.Text & "'")
    MsgBox " Data updated succesfuly ", vbOKOnly, "CCMS"
End If
 RefreshText
 
    

End Sub

Private Sub Form_Load()
bquit.Enabled = True

rdate.Text = Format(Date, "dd/mm/YYYY")
End Sub


Private Sub TxtCheckNo_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub TxtCheckNo_Validate(Cancel As Boolean)
Set dssave = Nothing
Set dssave = ocon.GetResultset("select a.d_code,a.nonzoneref,a.client_code,a.check_no,a.amount,a.drawee_bankcode, " & _
" A.branch_code , B.Acc_Name, c.bank_name, d.branch_name, A.Status, e.status_date " & _
" from ccheck as a,client as b,bank as c,branch as d,normalcollection as e " & _
" Where " & _
" A.client_code = (B.client_code) + (B.sub_client) " & _
" and a.drawee_bankcode=c.bank_code and " & _
" A.drawee_bankcode = d.bank_code And A.location_code = d.location_code " & _
" and a.branch_code=d.branch_code " & _
" and a.nonzoneref=e.nonzoneref " & _
" and a.check_no='" & Trim(TxtCheckNo.Text) & "'")

If dssave.RecordCount = 0 Then
    
        MsgBox "Invalid Check No"
        txtrcode.Text = ""
        lbldcode.Caption = ""
        lblClient.Caption = ""
        lblchkno.Caption = ""
        lblamount.Caption = ""
        lblbank.Caption = ""
        lblbranch.Caption = ""
        lblstatus.Caption = ""
        lblstdate.Caption = ""
        txtrefno.Text = ""
        txtrefno.SetFocus
        dssave.Close
        Exit Sub
    
    ElseIf dssave!Status <> "O" Then
        TxtCheckNo.Text = Trim(dssave!check_no)
        lbldcode.Caption = Trim(dssave!d_code) & ""
        lblClient.Caption = Trim(dssave!Acc_Name) & ""
        lblchkno.Caption = Trim(dssave!check_no) & ""
        lblamount.Caption = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
        lblbank.Caption = Trim(dssave!Bank_name) & ""
        lblbranch.Caption = Trim(dssave!Branch_name)
        txtrefno.Text = Trim(dssave!nonzoneref)
        If Trim(dssave!Status) = "O" Then
            lblstatus.Caption = "Outstanding"
        End If
        If Trim(dssave!Status) = "R" Then
            lblstatus.Caption = "Returned"
        End If
        If Trim(dssave!Status) = "D" Then
            lblstatus.Caption = "DD Outstanding"
        End If
        If Trim(dssave!Status) = "T" Then
            lblstatus.Caption = "DD Return"
        End If
        If Trim(dssave!Status) = "P" Then
            lblstatus.Caption = "DD Paid"
        End If
        lblstdate.Caption = Format(dssave!status_date, "dd/mm/yyyy")
        bquit.SetFocus
        
        
  ElseIf dssave!Status = "O" Then
        TxtCheckNo.Text = Trim(dssave!check_no)
        lbldcode.Caption = Trim(dssave!d_code) & ""
        lblClient.Caption = Trim(dssave!Acc_Name) & ""
        lblchkno.Caption = Trim(dssave!check_no) & ""
        lblamount.Caption = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
        lblbank.Caption = Trim(dssave!Bank_name) & ""
        lblbranch.Caption = Trim(dssave!Branch_name)
         txtrefno.Text = Trim(dssave!nonzoneref)
        If Trim(dssave!Status) = "O" Then
            lblstatus.Caption = "Outstanding"
        End If
        If Trim(dssave!Status) = "R" Then
            lblstatus.Caption = "Returned"
        End If
        If Trim(dssave!Status) = "D" Then
            lblstatus.Caption = "DD Outstanding"
        End If
        If Trim(dssave!Status) = "T" Then
            lblstatus.Caption = "DD Return"
        End If
        If Trim(dssave!Status) = "P" Then
            lblstatus.Caption = "DD Paid"
        End If
        lblstdate.Caption = Format(dssave!status_date, "dd/mm/yyyy")
        txtrcode.SetFocus
   '---------------
    End If
    dssave.Close
   
End Sub

Private Sub txtrcode_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtrcode_LostFocus()
Dim tt As String
If txtrcode.Text = "" Then
    Exit Sub
End If
If Left(lblstatus.Caption, 1) <> "O" Then
    MsgBox "Current status is not outstanding"
    txtrcode.Text = ""
    bquit.SetFocus
    Exit Sub
End If
Dim lblreason As String
If txtrefno.Text <> "" Then
    returncheck.Open ("select * from rtnrjct where reject_code='" & Trim(txtrcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If returncheck.RecordCount = 0 Then
        MsgBox "Invalid Code"
        txtrcode.Text = ""
        txtrcode.SetFocus
        returncheck.Close
        Exit Sub
    ElseIf returncheck.RecordCount > 0 Then
        lblreason = returncheck!reject_reason
        style = vbYesNo + vbDefaultButton2 + vbInformation
        title = "Change Data"
        response = MsgBox(lblreason, style, title)
        If response = vbYes Then
            tt = Left(lblstatus.Caption, 1)
            If tt = "O" Then
                msg = "Are you Sure?"
                style = vbYesNo + vbDefaultButton2 + vbInformation
                title = "Confirmation"
                response = MsgBox(msg, style, title)
                If response = vbYes Then
                    oconn.Connection.Execute "update ccheck set status='R' where nonzoneref='" & Trim(txtrefno.Text) & "'"
                    oconn.Connection.Execute "update normalcollection set status='R',status_date='" & Format(rdate.Text, "mm/dd/yyyy") & "' where nonzoneref='" & Trim(txtrefno.Text) & "'"
                 
                    dssave.Open ("select * from norcolrtn where nonzoneref='" & Trim(txtrefno.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                    If dssave.RecordCount = 0 Then
                        dssave.AddNew
                        dssave!nonzoneref = Trim(txtrefno.Text)
                        dssave!Code = Trim(txtrcode.Text)
                        dssave.Update
                    End If
                    dssave.Close
                    txtrefno.Text = ""
                    txtrcode.Text = ""
                    lbldcode.Caption = ""
                    lblClient.Caption = ""
                    lblchkno.Caption = ""
                    lblamount.Caption = ""
                    lblbank.Caption = ""
                    lblbranch.Caption = ""
                    lblstatus.Caption = ""
                    lblstdate.Caption = ""
                    bquit.Enabled = True
                    returncheck.Close
                    txtrefno.SetFocus
                    Exit Sub
                ElseIf response = vbNo Then
                    txtrefno.Text = ""
                    txtrcode.Text = ""
                    lbldcode.Caption = ""
                    lblClient.Caption = ""
                    lblchkno.Caption = ""
                    lblamount.Caption = ""
                    lblbank.Caption = ""
                    lblbranch.Caption = ""
                    lblstatus.Caption = ""
                    lblstdate.Caption = ""
                    bquit.Enabled = True
                    returncheck.Close
                    txtrefno.SetFocus
                    Exit Sub
             End If
            ElseIf tt <> "O" Then
                MsgBox "Current status is not outstanding"
                txtrefno.Text = ""
                txtrcode.Text = ""
                lbldcode.Caption = ""
                lblClient.Caption = ""
                lblchkno.Caption = ""
                lblamount.Caption = ""
                lblbank.Caption = ""
                lblbranch.Caption = ""
                lblstatus.Caption = ""
                lblstdate.Caption = ""
                bquit.Enabled = True
                txtrefno.SetFocus
            End If
            
      ElseIf response = vbNo Then
                txtrcode.SetFocus
                returncheck.Close
                Exit Sub
         
     End If
End If
returncheck.Close
End If

    
End Sub

Private Sub txtrefno_KeyPress(KeyAscii As Integer)
 If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub txtrefno_LostFocus()
If txtrefno.Text = "" Then
    Exit Sub
End If
    
    If Len(txtrefno.Text) < 7 Then
        MsgBox "Must enter 7 digits"
        txtrefno.Text = ""
        txtrefno.SetFocus
        Exit Sub
    End If
Set dssave = Nothing
    dssave.Open ("select a.d_code,a.client_code,a.check_no,a.amount,a.drawee_bankcode,a.branch_code,b.acc_no,b.acc_name,c.bank_name,d.branch_name,a.status,e.status_date from ccheck as a,client as b,bank as c,branch as d,normalcollection as e where  a.client_code=(b.client_code) +(b.sub_client) and a.drawee_bankcode=c.bank_code and a.drawee_bankcode=d.bank_code and a.location_code=d.location_code and a.branch_code=d.branch_code and a.nonzoneref=e.nonzoneref and a.nonzoneref='" & Trim(txtrefno.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic

    If dssave.RecordCount = 0 Then
    
        MsgBox "Invalid Reference No"
        txtrcode.Text = ""
        lbldcode.Caption = ""
        lblClient.Caption = ""
        lblchkno.Caption = ""
        lblamount.Caption = ""
        lblbank.Caption = ""
        lblbranch.Caption = ""
        lblstatus.Caption = ""
        lblstdate.Caption = ""
        txtrefno.Text = ""
        txtrefno.SetFocus
        lblAcno = ""
        dssave.Close
        Exit Sub
    
    ElseIf dssave!Status <> "O" Then
        TxtCheckNo.Text = Trim(dssave!check_no)
        lbldcode.Caption = Trim(dssave!d_code) & ""
        lblClient.Caption = Trim(dssave!Acc_Name) & ""
        lblchkno.Caption = Trim(dssave!check_no) & ""
        lblamount.Caption = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
        lblbank.Caption = Trim(dssave!Bank_name) & ""
        lblbranch.Caption = Trim(dssave!Branch_name)
        If Trim(dssave!Status) = "O" Then
            lblstatus.Caption = "Outstanding"
        End If
        If Trim(dssave!Status) = "R" Then
            lblstatus.Caption = "Returned"
        End If
        If Trim(dssave!Status) = "D" Then
            lblstatus.Caption = "DD Outstanding"
        End If
        If Trim(dssave!Status) = "T" Then
            lblstatus.Caption = "DD Return"
        End If
        If Trim(dssave!Status) = "P" Then
            lblstatus.Caption = "DD Paid"
        End If
        lblstdate.Caption = Format(dssave!status_date, "dd/mm/yyyy")
        bquit.SetFocus
        
        
  ElseIf dssave!Status = "O" Then
        TxtCheckNo.Text = Trim(dssave!check_no)
        lbldcode.Caption = Trim(dssave!d_code) & ""
        lblClient.Caption = Trim(dssave!Acc_Name) & ""
        lblchkno.Caption = Trim(dssave!check_no) & ""
        lblamount.Caption = Format(dssave!Amount, "#,##,##,##,##0.00") & ""
        lblbank.Caption = Trim(dssave!Bank_name) & ""
        lblbranch.Caption = Trim(dssave!Branch_name)
        If Trim(dssave!Status) = "O" Then
            lblstatus.Caption = "Outstanding"
        End If
        If Trim(dssave!Status) = "R" Then
            lblstatus.Caption = "Returned"
        End If
        If Trim(dssave!Status) = "D" Then
            lblstatus.Caption = "DD Outstanding"
        End If
        If Trim(dssave!Status) = "T" Then
            lblstatus.Caption = "DD Return"
        End If
        If Trim(dssave!Status) = "P" Then
            lblstatus.Caption = "DD Paid"
        End If
        lblstdate.Caption = Format(dssave!status_date, "dd/mm/yyyy")
        txtrcode.SetFocus
   '---------------
    End If
    dssave.Close

    
  
End Sub

Private Sub txtstatus_LostFocus()
'If Not editdata Then

End Sub
Private Sub RefreshText()
        txtrcode.Text = ""
        lbldcode.Caption = ""
        lblClient.Caption = ""
        lblchkno.Caption = ""
        lblamount.Caption = ""
        lblbank.Caption = ""
        lblbranch.Caption = ""
        lblstatus.Caption = ""
        lblstdate.Caption = ""
        txtrefno.Text = ""
        TxtCheckNo.Text = ""
        txtrefno.SetFocus
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
ErrorCode:
End Function

