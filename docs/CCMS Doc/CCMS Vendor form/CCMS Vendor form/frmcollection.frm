VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "MSMASK32.OCX"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Begin VB.Form frmcollection 
   Caption         =   "Collection"
   ClientHeight    =   8595
   ClientLeft      =   60
   ClientTop       =   180
   ClientWidth     =   11460
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   8595
   ScaleWidth      =   11460
   WindowState     =   2  'Maximized
   Begin VB.CommandButton CmdSave 
      Caption         =   "Save"
      Height          =   315
      Left            =   1680
      TabIndex        =   9
      Top             =   2400
      Width           =   900
   End
   Begin VB.Frame Frame3 
      Caption         =   "RETURN DETAIL"
      Height          =   4290
      Left            =   6240
      TabIndex        =   33
      Top             =   2760
      Width           =   5175
      Begin VB.TextBox txtrtcode 
         Height          =   285
         Left            =   3990
         MaxLength       =   2
         TabIndex        =   36
         Top             =   180
         Width           =   885
      End
      Begin VB.TextBox txtramt 
         Height          =   285
         Left            =   1320
         TabIndex        =   34
         Top             =   195
         Width           =   1440
      End
      Begin MSFlexGridLib.MSFlexGrid rtnshow 
         Height          =   3300
         Left            =   240
         TabIndex        =   35
         Top             =   510
         Width           =   4785
         _ExtentX        =   8440
         _ExtentY        =   5821
         _Version        =   393216
         FixedCols       =   0
      End
      Begin VB.Label Label10 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "ReturnCode"
         Height          =   240
         Left            =   2880
         TabIndex        =   38
         Top             =   210
         Width           =   975
      End
      Begin VB.Label Label6 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "ReturnAmount"
         Height          =   255
         Left            =   120
         TabIndex        =   37
         Top             =   225
         Width           =   1125
      End
   End
   Begin VB.CommandButton bdelete 
      Caption         =   "Delete"
      Height          =   315
      Left            =   2640
      TabIndex        =   10
      Top             =   2400
      Width           =   900
   End
   Begin VB.CommandButton bcancel 
      Caption         =   "Cancel"
      Height          =   315
      Left            =   3720
      TabIndex        =   11
      Top             =   2400
      Width           =   900
   End
   Begin VB.CommandButton bquit 
      Caption         =   "Quit"
      CausesValidation=   0   'False
      Height          =   315
      Left            =   4800
      TabIndex        =   12
      Top             =   2400
      Width           =   900
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00C0C0C0&
      Height          =   2100
      Left            =   6360
      TabIndex        =   20
      Top             =   240
      Width           =   4950
      Begin VB.TextBox txtchno 
         ForeColor       =   &H00C00000&
         Height          =   285
         Left            =   1680
         MaxLength       =   4
         TabIndex        =   7
         Top             =   1140
         Width           =   975
      End
      Begin VB.TextBox txtcash 
         ForeColor       =   &H00C00000&
         Height          =   285
         Left            =   1680
         TabIndex        =   6
         Top             =   840
         Width           =   1695
      End
      Begin VB.TextBox txtcheck 
         ForeColor       =   &H00C00000&
         Height          =   285
         Left            =   1680
         TabIndex        =   8
         Top             =   1440
         Width           =   1575
      End
      Begin VB.TextBox txtds 
         ForeColor       =   &H00C00000&
         Height          =   285
         Left            =   1080
         MaxLength       =   5
         TabIndex        =   5
         Top             =   480
         Width           =   1065
      End
      Begin VB.Label lblloc 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   2160
         TabIndex        =   28
         Top             =   480
         Width           =   2655
      End
      Begin VB.Label Label13 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "CheckAmount"
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
         Left            =   360
         TabIndex        =   24
         Top             =   1425
         Width           =   1245
      End
      Begin VB.Label Label12 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "CashAmount"
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
         Left            =   360
         TabIndex        =   23
         Top             =   840
         Width           =   1275
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
         Height          =   270
         Left            =   360
         TabIndex        =   22
         Top             =   1125
         Width           =   1290
      End
      Begin VB.Label Label5 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "DS Code"
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
         Height          =   255
         Left            =   120
         TabIndex        =   21
         Top             =   480
         Width           =   870
      End
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00C0C0C0&
      Height          =   2100
      Left            =   15
      TabIndex        =   14
      Top             =   240
      Width           =   6345
      Begin VB.TextBox txtcollected 
         Height          =   285
         Left            =   1680
         TabIndex        =   4
         Top             =   1440
         Width           =   2535
      End
      Begin VB.TextBox txtcs 
         Height          =   270
         Left            =   1650
         MaxLength       =   5
         TabIndex        =   0
         Top             =   195
         Width           =   1215
      End
      Begin VB.ComboBox cmbbcode 
         Height          =   315
         Left            =   1680
         TabIndex        =   3
         Top             =   1125
         Width           =   4635
      End
      Begin VB.ComboBox cmblcode 
         Height          =   315
         Left            =   1650
         TabIndex        =   2
         Top             =   795
         Width           =   4590
      End
      Begin MSMask.MaskEdBox msdate 
         Height          =   300
         Left            =   1635
         TabIndex        =   1
         Top             =   495
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
         Left            =   4335
         TabIndex        =   13
         Top             =   465
         Width           =   1050
         _ExtentX        =   1852
         _ExtentY        =   529
         _Version        =   393216
         MaxLength       =   10
         Format          =   "dd/mm/yyyy"
         Mask            =   "##/##/####"
         PromptChar      =   "_"
      End
      Begin VB.Label Label3 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "TotalCollected"
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
         TabIndex        =   29
         Top             =   1440
         Width           =   1455
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
         Height          =   270
         Left            =   3345
         TabIndex        =   19
         Top             =   480
         Width           =   945
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
         Height          =   255
         Left            =   120
         TabIndex        =   18
         Top             =   480
         Width           =   1500
      End
      Begin VB.Label Label4 
         BorderStyle     =   1  'Fixed Single
         Caption         =   "CS Code"
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
         Height          =   240
         Left            =   120
         TabIndex        =   17
         Top             =   225
         Width           =   1500
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
         Height          =   270
         Left            =   135
         TabIndex        =   16
         Top             =   780
         Width           =   1485
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
         TabIndex        =   15
         Top             =   1065
         Width           =   1500
      End
   End
   Begin MSFlexGridLib.MSFlexGrid allshow 
      Height          =   5325
      Left            =   0
      TabIndex        =   25
      Top             =   2760
      Width           =   6120
      _ExtentX        =   10795
      _ExtentY        =   9393
      _Version        =   393216
      FixedCols       =   0
   End
   Begin VB.Label lblbcode 
      BorderStyle     =   1  'Fixed Single
      Height          =   225
      Left            =   8520
      TabIndex        =   32
      Top             =   7440
      Visible         =   0   'False
      Width           =   915
   End
   Begin VB.Label lblds 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Left            =   7200
      TabIndex        =   31
      Top             =   7920
      Visible         =   0   'False
      Width           =   1095
   End
   Begin VB.Label lbllcode 
      BorderStyle     =   1  'Fixed Single
      Height          =   255
      Left            =   7320
      TabIndex        =   30
      Top             =   8160
      Visible         =   0   'False
      Width           =   1095
   End
   Begin VB.Label lbldcode 
      BorderStyle     =   1  'Fixed Single
      Height          =   225
      Left            =   7200
      TabIndex        =   27
      Top             =   7560
      Visible         =   0   'False
      Width           =   1095
   End
   Begin VB.Label lblslno 
      BorderStyle     =   1  'Fixed Single
      Height          =   225
      Left            =   8520
      TabIndex        =   26
      Top             =   7680
      Visible         =   0   'False
      Width           =   885
   End
End
Attribute VB_Name = "frmcollection"
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
Dim dcoll As New ADODB.Recordset
Dim dscodeadd As New ADODB.Recordset
Dim clientadd As New ADODB.Recordset
Dim showall As New ADODB.Recordset
Dim tcheckamt As New ADODB.Recordset
Dim rtnchk As New ADODB.Recordset
Dim selrtn As New ADODB.Recordset
Dim RTNCHECK As New ADODB.Recordset
Dim nrtn As New ADODB.Recordset
Dim selectgrid As Boolean
Dim appenddata As Boolean
Dim deldata As Boolean
Dim editdata As Boolean
Dim csd As Boolean
Dim cchk As Boolean
Dim editchkamt As Boolean
Dim editchkno As New ADODB.Recordset
Dim editchkamt1 As Boolean
Dim editcashamt As Boolean
Dim rtnamount As Boolean
Dim txttchk As Currency
Dim txttcash As Currency
Dim txttcoll As Currency
Dim intcount As Integer
Dim tcollected As Currency
Dim ss As String


Private Sub allshow_Click()
    If deldata = True Then
        bdelete.Enabled = True
        bcancel.Enabled = True
        bquit.Enabled = False
        If allshow.Rows > 1 Then
            With allshow
                .col = 0 : lblds.Caption = .Text
        showall.Open ("select * from cschedule where cs_code='" & Trim(txtcs.Text) & "' and ds_code='" & lblds.Caption & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If showall.RecordCount > 0 Then
                    txtds.Text = Trim(showall!ds_code) & ""
                    txtchno.Text = Trim(showall!No_check) & ""
                    txtcheck.Text = Trim(showall!citicheck_amount) & ""
                    txtcash.Text = Trim(showall!citicash_amount) & ""

                End If
                showall.Close()
            End With
        End If
    End If
End Sub

Private Sub bcancel_Click()
    Dim Respns As Integer
    'If txtds.Text = "" Or txtcash.Text = "" Or txtcheck.Text = "" Then
    Respns = MsgBox("Do you want to Clear this " & vbCr _
           & "information?", vbQuestion + vbYesNo)
    Select Case Respns
        Case vbYes
            init_item()

        Case vbNo
            bcancel.SetFocus()
    End Select
    'End If

End Sub

Private Sub bdelete_Click()
    'If Not selectgrid Then
    '    MsgBox "Must select Record from grid"
    '    Exit Sub
    'End If

    appenddata = False


    If deldata = True Then
        kk = MsgBox("Are you sure you want to Delete?", vbDefaultButton3 + vbQuestion + vbYesNo)
        If kk = vbNo Then
            Exit Sub
        End If

        oconn.Connection.Execute("delete from cschedule where cs_code='" & Trim(txtcs.Text) & "' and ds_code='" & Trim(lblds.Caption) & "'")
    dssave.Open ("select * from cschedule where cs_code='" & Trim(txtcs.Text) & "' order by ds_code desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
        If dssave.RecordCount > 0 Then
            cleargrid()
            Do While Not dssave.EOF
                With allshow
                    .Rows = .Rows + 1
                    .row = .Rows - 1

                    allshow.col = 0
                    allshow.Text = Trim(dssave!ds_code) & ""
                    allshow.col = 1
                    allshow.Text = (dssave!No_check) & ""
                    allshow.col = 2
                    allshow.Text = (dssave!citicheck_amount) & ""
                    allshow.col = 3
                    allshow.Text = (dssave!citicash_amount) & ""

                End With
                dssave.MoveNext()
            Loop
            'msdate.Text = "__/__/____"
            txtds.Text = ""
            txtchno.Text = ""
            txtcash.Text = ""
            txtcheck.Text = ""
            dssave.Close()
            Exit Sub

        ElseIf dssave.RecordCount = 0 Then
            init_item()
        End If
        dssave.Close()
    End If

    bdelete.Enabled = False

End Sub

Private Sub bquit_Click()
    'If Trim(txtcs.Text) = "" Then
    Dim rs As New ADODB.Recordset
    rs = Nothing
    Dim totalcs As Currency
    Dim totalDs As Currency
    'select * from totalcs where cs_code='" & Trim(txtcs.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    rs = ocon.GetResultset("select sum(citicash_amount+citicheck_amount)totalDs from cschedule where cs_code='" & Trim(txtcs.Text) & "'")
    If Not (rs.BOF And rs.EOF) Then
        If Trim(txtcollected.Text) <> Trim(rs!totalDs) Then
            MsgBox("Mismatch amount,Please check Collection/Deposit amount", vbOKOnly)
            Exit Sub
        End If

    End If

    If txtds.Text = "" Then
        kk = MsgBox("Are you sure you want to exit?", vbYesNo + vbQuestion)
        If kk = vbNo Then
            Exit Sub
        Else
            Unload(Me)
            frmMain.Show()
        End If
        'End If
    End If
End Sub

Private Sub cmbbcode_DropDown()
corrbankadd.Open ("select a.bank_code,a.branch_code,a.branch_name,b.bank_name from branch as a,bank as b where a.bank_code=b.bank_code and a.location_code='" & Left(cmblcode.Text, 3) & "' and a.corrbank='Y'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    cmbbcode.Clear()
    If corrbankadd.RecordCount > 0 Then

        Do While Not corrbankadd.EOF
            cmbbcode.AddItem(corrbankadd!bank_code + Space(2) + ":" + Space(2) + corrbankadd!Branch_Code + Space(2) + ":" + Trim(corrbankadd!bank_name) + ":" + Trim(corrbankadd!Branch_name))
            corrbankadd.MoveNext()
        Loop
    End If
    corrbankadd.Close()

End Sub

Private Sub cmbbcode_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub cmblcode_Change()
    lbllcode.Caption = cmblcode.Text
End Sub

Private Sub cmblcode_DropDown()
locationadd.Open ("select distinct a.location_code,b.location_name from branch as a,location as b  where a.location_code=b.location_code and a.corrbank='Y' and b.location_name like '" & lbllcode.Caption & "%' order by a.location_code"), oconn.Connection, adOpenKeyset, adLockOptimistic
    cmblcode.Clear()
    If locationadd.RecordCount > 0 Then
        Do While Not locationadd.EOF
            cmblcode.AddItem(locationadd!location_code + Space(2) + ":" + Space(2) + locationadd!Location_Name)
            locationadd.MoveNext()
        Loop
    End If
    locationadd.Close()

End Sub

Private Sub cmblcode_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub cmdSave_Click()
    Dim rs As New ADODB.Recordset
    rs = Nothing
    Dim totalcs As Currency
    Dim totalDs As Currency
    Dim AmountDiff As Currency
    'select * from totalcs where cs_code='" & Trim(txtcs.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    rs = ocon.GetResultset("select sum(citicash_amount+citicheck_amount)totalDs from cschedule where cs_code='" & Trim(txtcs.Text) & "'")
    If Not (rs.BOF And rs.EOF) Then
        totalDs = Val(rs!totalDs)
        If Trim(txtcollected.Text) <> Val(Trim(totalDs)) Then
            AmountDiff = Trim(txtcollected.Text) - Val(Trim(totalDs))
            MsgBox("Mismatch amount,  " & AmountDiff & "  . Please check Collection/Deposit amount.", vbOKOnly, "CCMS")
        Else
            bcancel_Click()
        End If

    End If


End Sub

Private Sub Form_Load()
Move (frmMain.Height - Height) / 2, (frmMain.width - width) / 2
    Me.width = 11080
    txtcs.Text = ""
    txtds.Text = ""
    txtchno.Text = ""
    txtcash.Text = ""
    txtcheck.Text = ""
    'bsave.Enabled = False
    bcancel.Enabled = False
    bdelete.Enabled = False
    bquit.Enabled = True
    msdate.Text = "__/__/____"
medate.Text = Format(Date, "dd/mm/YYYY")
    Me.width = 11460
    Me.Height = 9000
    cleargrid()
    cleargrid2()

End Sub

Private Sub msdate_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub msdate_Validate(ByVal Cancel As Boolean)
    ''    If msdate.Text = "__/__/____" Then
    ''        MsgBox "Date should not be blank", vbCritical, "Citibank N.A."
    ''        Cancel = True
    ''        Exit Sub
    ''     End If
    '     If oDate.Validate(msdate) = False Then
    '        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A."
    '        Cancel = True
    '        Exit Sub
    '     End If
End Sub

Private Sub rtnshow_Click()
    'SELECTGRID = True
    If rtnshow.Rows > 1 Then

        With rtnshow
            .col = 1 : lblslno.Caption = Trim(.Text)
            .col = 0 : lbldcode.Caption = Trim(.Text)
        End With
    End If
    txtrtcode.SetFocus()

End Sub

Private Sub txtcash_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub txtcash_Validate(ByVal Cancel As Boolean)
    Dim pp As Currency
    txttcash = Val(txtcash.Text)
    txtcash.Text = Format(txtcash.Text, "#,##,##,##,##0.00")
    'dssave.Close
dssave.Open ("select total_cashamt,cash_cleared from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dssave.RecordCount > 0 Then

        If Val(txttcash) + IIf(IsNull(dssave!cash_cleared), 0, dssave!cash_cleared) <> (dssave!total_cashamt) Then

            pp = (txttcash) + IIf(IsNull(dssave!cash_cleared), 0, dssave!cash_cleared) - dssave!total_cashamt
            msg = "Amount Mismatch, " & Format(pp, "#,##,##,##,##0.00") & " Want to Change?"
            style = vbInformation + vbDefaultButton2 + vbYesNo
            title = "Mismatch Data"
            response = MsgBox(msg, style, title)
            If response = vbYes Then
                Cancel = True
                txtcash.Text = ""
                dssave.Close()
                Exit Sub
            ElseIf response = vbNo Then
                txtchno.SetFocus()
                dssave.Close()
                Exit Sub
            End If
        End If
    End If
    dssave.Close()

End Sub

Private Sub txtcheck_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub txtcheck_LostFocus()

    Dim kk As Currency
    Dim kk1 As Currency

    txttchk = Val(txtcheck.Text)
    txtcheck.Text = Format(txtcheck.Text, "#,##,##,##,##0.00")

    If Not deldata Or appenddata Then

        bquit.Enabled = False
        bcancel.Enabled = True
        If Not editdata Or Not deldata Then
            If Trim(txtcs.Text) = "" Then
                MsgBox("Must enter DSCode")
                txtds.SetFocus()
                Exit Sub
            End If

            If Trim(medate.Text) = "__/__/____" Then
                MsgBox("Must Enter Entry Date")
                medate.SetFocus()
                Exit Sub
            End If
            If Trim(msdate.Text) = "__/__/____" Then
                MsgBox("Must Enter Schedule Date")
                msdate.SetFocus()
                Exit Sub
            End If

            If oDate.Validate(msdate) = False Then
                MsgBox("Please enter a valid date", vbCritical, "Citibank N.A.")
                msdate.SetFocus()
                Exit Sub
            End If

            If Trim(cmblcode.Text) = "" Then
                MsgBox("Must Select Location Code")
                cmblcode.SetFocus()
                Exit Sub
            End If
            If Trim(txtcollected.Text) = "" Then
                txtcollected.Text = ""
                txtcollected.SetFocus()
                Exit Sub
            End If
            If Trim(txtds.Text) = "" Then
                MsgBox("Must Enter Deposit Code")
                txtds.SetFocus()
                Exit Sub
            End If
            If Trim(txtchno.Text) = "" Then
                MsgBox("Must Enter CheckNo")
                txtchno.SetFocus()
                Exit Sub
            End If
            '-------------------------------------------
            dssave.Open ("select * from totalcs where cs_code='" & Trim(txtcs.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount = 0 Then
                dssave.AddNew()
                dssave!cs_code = Trim(txtcs.Text)
                dssave!total_amount = txttcoll
                dssave.Update()
            ElseIf dssave.RecordCount > 0 Then
                oconn.Connection.Execute("update totalcs set total_amount=" & txttcoll & " where cs_code='" & Trim(txtcs.Text) & "'")
            End If
            dssave.Close()

            dssave.Open ("select total_chkamt,cleared_amount,returned_amount from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If (txttchk) + IIf(IsNull(dssave!cleared_amount), 0, dssave!cleared_amount) + IIf(IsNull(dssave!returned_amount), 0, dssave!returned_amount) > dssave!TOTAL_CHKAMT Then
                kk = Val(txtcheck.Text) + IIf(IsNull(dssave!cleared_amount), 0, dssave!cleared_amount) + IIf(IsNull(dssave!returned_amount), 0, dssave!returned_amount) - (dssave!TOTAL_CHKAMT)
                MsgBox("Excess Amount, " & Format(kk, "#,##,##,##,##0.00"))


            ElseIf (txttchk) + IIf(IsNull(dssave!cleared_amount), 0, dssave!cleared_amount) + IIf(IsNull(dssave!returned_amount), 0, dssave!returned_amount) < dssave!TOTAL_CHKAMT Then
                kk1 = (dssave!TOTAL_CHKAMT) - txttchk + IIf(IsNull(dssave!cleared_amount), 0, dssave!cleared_amount) + IIf(IsNull(dssave!returned_amount), 0, dssave!returned_amount)
                msg = "Less amount, " & Format(kk1, "#,##,##,##,##0.00  ") & " Return?"
                style = vbInformation + vbDefaultButton2 + vbYesNo
                title = "Mismatch Data"
                response = MsgBox(msg, style, title)
                If response = vbYes Then
                    rtnamount = True
                ElseIf response = vbNo Then
                    'txtds.SetFocus
                    rtnamount = False

                End If
            End If
            dssave.Close()


            dssave.Open ("select * from cschedule where cs_code = '" & Trim(txtcs.Text) & "' and ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount = 0 Then
                With dssave
                    .AddNew()
                    !cs_code = Trim(txtcs.Text)
                    !Schedule_date = Format(msdate.Text, "dd/mm/yyyy")
                    !Entry_date = Format(medate.Text, "dd/mm/yyyy")
                    !location_code = Left(cmblcode.Text, 3)
                    !Corr_BCode = Left(cmbbcode.Text, 3)
                    !Corr_BrCode = Mid(cmbbcode.Text, 7, 3)
                    !ds_code = Trim(txtds.Text)
                    !No_check = Val(txtchno.Text)
                    !citicheck_amount = txttchk
                    !citicash_amount = txttcash
                    .Update()
                End With
                'dssave.Close
            End If
            dssave.Close()





                dssave.Open ("select * from cschedule where cs_code='" & Trim(txtcs.Text) & "' order by ds_code desc"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount > 0 Then
                cleargrid()
                Do While Not dssave.EOF
                    With allshow
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                        allshow.col = 0
                        allshow.Text = Trim(dssave!ds_code)
                        allshow.col = 1
                        allshow.Text = Val(dssave!No_check) & ""
                        allshow.col = 2
                        allshow.Text = Format(dssave!citicheck_amount, "#,##,##,##,##0.00") & ""
                        allshow.col = 3
                        allshow.Text = Format(dssave!citicash_amount, "#,##,##,##,##0.00") & ""
                    End With
                    dssave.MoveNext()
                Loop
                'dssave.Close

            End If
            dssave.Close()
        End If
        If Not rtnamount Then
            txtds.Text = ""
            txtcheck.Text = ""
            txtchno.Text = ""
            txtcash.Text = ""
            txtds.SetFocus()
            Exit Sub
        End If
        If rtnamount Then
            txtramt.SetFocus()
        End If
        rtnamount = False
    End If
End Sub

Private Sub txtchno_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub txtchno_LostFocus()
    Dim kk1 As Integer
    'If txtchno.Text = "" Then
    'Exit Sub
    'End If

End Sub

Private Sub txtchno_Validate(ByVal Cancel As Boolean)
dscodeadd.Open ("select total_nochk,no_checkscleared,no_checksreturned from dcollected where ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If Val(txtchno.Text) + IIf(IsNull(dscodeadd!no_checkscleared), 0, dscodeadd!no_checkscleared) + IIf(IsNull(dscodeadd!No_checksreturned), 0, dscodeadd!No_checksreturned) <> dscodeadd!total_nochk Then 'Or CInt(txtchno.Text) + (dscodeadd!no_checkscleared) + (dscodeadd!no_checksreturned) < dscodeadd!total_nochk Then
        kk1 = Val(txtchno.Text) + IIf(IsNull(dscodeadd!no_checkscleared), 0, dscodeadd!no_checkscleared) + IIf(IsNull(dscodeadd!No_checksreturned), 0, dscodeadd!No_checksreturned) - (dscodeadd!total_nochk)
        msg = "Mismatch, " & kk1 & " Want to Change?"
        style = vbInformation + vbDefaultButton2 + vbYesNo
        title = "Mismatch Data"
        response = MsgBox(msg, style, title)
        If response = vbYes Then
            txtchno.Text = ""
            txtchno.SetFocus()
            Cancel = True
            dscodeadd.Close()
            Exit Sub
        ElseIf response = vbNo Then
            txtcheck.SetFocus()
            dscodeadd.Close()
            Exit Sub
        End If
    End If

    dscodeadd.Close()

End Sub

Private Sub txtcollected_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub txtcollected_LostFocus()
    txttcoll = Val(txtcollected.Text)
    txtcollected.Text = Format(txtcollected.Text, "#,##,##,##,##0.00")
End Sub

Private Sub txtcs_KeyPress(ByVal KeyAscii As Integer)
    bcancel.Enabled = True
    bquit.Enabled = False
    bdelete.Enabled = False

    If KeyAscii = 13 Then SendKeys("{tab}")
    cleargrid()
    cleargrid2()
    msdate.Text = "__/__/____"
    cmblcode.Clear()
    cmbbcode.Clear()
    txtcollected.Text = ""
    txtds.Text = ""
    txtchno.Text = ""
    txtcash.Text = ""
    txtcheck.Text = ""
    txtrtcode.Text = ""
    lblds.Caption = ""
    lblslno.Caption = ""
    lblloc.Caption = ""
    txtcollected.Text = ""
    Frame1.Enabled = True
    Frame2.Enabled = True

End Sub

Private Sub txtcs_LostFocus()
    appenddata = False
    appenddata = False
    selectgrid = False
    If Trim(txtcs.Text) = "" Then
        Exit Sub
    End If
    If Len(txtcs.Text) < 5 Then
        MsgBox("Must Enter 5 digits")
        txtcs.Text = ""
        txtcs.SetFocus()
        Exit Sub
    End If

dscodeadd.Open ("select * from cschedule where cs_code='" & Trim(txtcs.Text) & "'"), oconn.Connection, adOpenKeyset, adLockPessimistic
    If dscodeadd.RecordCount > 0 Then
        msg = "Duplicate Data,Want to Delete?"
        style = vbInformation + vbDefaultButton3 + vbYesNo
        title = "Duplicate Data"
        response = MsgBox(msg, style, title)

        If response = vbYes Then
        dssave.Open ("select * from totalcs where cs_code='" & Trim(txtcs.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount > 0 Then
                txtcollected.Text = Format(dssave!total_amount, "#,##,##,##,##0.00")
                txttcoll = dssave!total_amount
            End If
            dssave.Close()
            Frame2.Enabled = True
            Frame1.Enabled = False
            deldata = True
            appenddate = False
            bcancel.Enabled = True
            bquit.Enabled = False
            bdelete.Enabled = True
            bdelete.SetFocus()
            msdate = dscodeadd!Schedule_date
            medate = dscodeadd!Entry_date & ""
            cmblcode.Text = Trim(dscodeadd!location_code) & ""
            cmbbcode.Text = Trim(dscodeadd!Corr_BCode) & "" + Trim(dscodeadd!Corr_BrCode) & ""
            With dscodeadd

                Do While Not dscodeadd.EOF

                    With allshow
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                        .col = 0 : .Text = Trim(dscodeadd!ds_code)
                        .col = 1 : .Text = dscodeadd!No_check
                        .col = 2 : .Text = Format(dscodeadd!citicheck_amount, "#,##,##,##,##0.00") & ""
                        .col = 3 : .Text = Format(dscodeadd!citicash_amount, "#,##,##,##,##0.00") & ""
                    End With
                    .MoveNext()
                Loop
            End With
        ElseIf response = vbNo Then
            msg = "Duplicate Data,Want to Append?"
            style = vbInformation + vbDefaultButton3 + vbYesNo
            title = "Duplicate Data"
            response = MsgBox(msg, style, title)
            If response = vbYes Then
                dssave.Open ("select * from totalcs where cs_code='" & Trim(txtcs.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If dssave.RecordCount > 0 Then
                    txtcollected.Text = Format(dssave!total_amount, "#,##,##,##,##0.00")
                    txttcoll = dssave!total_amount
                End If
                dssave.Close()
                appenddata = True
                deldata = False
                Frame1.Enabled = True
                Frame2.Enabled = False
                bcancel.Enabled = True
                bquit.Enabled = False
                bdelete.Enabled = False
                txtds.SetFocus()
                msdate = dscodeadd!Schedule_date
                medate = dscodeadd!Entry_date & ""
                cmblcode.Text = Trim(dscodeadd!location_code) & ""
                cmbbcode.Text = Trim(dscodeadd!Corr_BCode) & "" + Trim(dscodeadd!Corr_BrCode) & ""
                With dscodeadd

                    Do While Not dscodeadd.EOF

                        With allshow
                            .Rows = .Rows + 1
                            .row = .Rows - 1
                            .col = 0 : .Text = Trim(dscodeadd!ds_code)
                            .col = 1 : .Text = dscodeadd!No_check
                            .col = 2 : .Text = Format(dscodeadd!citicheck_amount, "#,##,##,##,##0.00") & ""
                            .col = 3 : .Text = Format(dscodeadd!citicash_amount, "#,##,##,##,##0.00") & ""
                        End With
                        .MoveNext()
                    Loop
                End With
            ElseIf response = vbNo Then
                cleargrid()
                cleargrid2()
                msdate.Text = "__/__/____"
                cmblcode.Clear()
                cmbbcode.Clear()
                txtcollected.Text = ""
                txtds.Text = ""
                txtchno.Text = ""
                txtcash.Text = ""
                txtcheck.Text = ""
                txtcollected.Text = ""
                txtcs.Text = ""
                txtcs.SetFocus()

            End If

        End If
    End If
    'End If
    dscodeadd.Close()


End Sub

Private Sub txtds_KeyPress(ByVal KeyAscii As Integer)
    lblloc.Caption = ""
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Public Sub cleargrid()
    With allshow
        .Clear()
        .Rows = 1
        .Cols = 4
        .row = 0
        .ColWidth(0) = 900
        .ColWidth(1) = 1000
        .ColWidth(2) = 2000
        .ColWidth(3) = 2000

        .col = 0 : .Text = "DS Code"
        .col = 1 : .Text = "No of Check"
        .col = 2 : .Text = "        CitiCheckAmount"
        .col = 3 : .Text = "        CitiCashAmount"

    End With

End Sub

Public Sub init_item()

    bcancel.Enabled = False
    bdelete.Enabled = False
    bquit.Enabled = True
    cleargrid()
    cleargrid2()
    deldata = False
    appendata = False
    selectgrid = False
    txtrtcode.Text = ""
    lblds.Caption = ""
    lblslno.Caption = ""
    lblloc.Caption = ""
    lbllcode.Caption = ""
    txtcs.Text = ""
    txtramt.Text = ""
    txtds.Text = ""
    msdate.Text = "__/__/____"
    txtcollected.Text = ""
    cmblcode.Clear()
    cmbbcode.Clear()
    txtchno.Text = ""
    txtcheck.Text = ""
    txtcash.Text = ""
    Frame1.Enabled = True
    Frame2.Enabled = True
    txtcs.SetFocus()


End Sub

Private Sub txtds_LostFocus()
    If Trim(txtds.Text) = "" Then
        Exit Sub
    End If
    cleargrid2()

    If Len(txtds.Text) < 5 Then
        MsgBox("Must Enter 5 digits")
        txtds.Text = ""
        txtds.SetFocus()
        Exit Sub
    End If

dscodeadd.Open ("select a.ds_code,a.location_code,b.location_name from  dschedule as a,location as b where a.ds_code='" & Trim(txtds.Text) & "' and a.location_code=b.location_code "), oconn.Connection, adOpenKeyset, adLockPessimistic
    If dscodeadd.RecordCount = 0 Then
        MsgBox("Invalid DS Code")
        txtds.Text = ""
        txtds.SetFocus()
        dscodeadd.Close()
        Exit Sub
    ElseIf dscodeadd.RecordCount > 0 Then
        lblloc.Caption = dscodeadd!Location_Name
        'chkdtype.SetFocus
    End If
    dscodeadd.Close()

dscodeadd.Open ("select * from cschedule where cs_code='" & Trim(txtcs.Text) & "' and ds_code='" & Trim(txtds.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If dscodeadd.RecordCount > 0 Then
        MsgBox("Duplicate Data")
        lblloc.Caption = ""
        txtds.Text = ""
        txtds.SetFocus()
    End If
    dscodeadd.Close()
    'dscodeadd.Close



End Sub

Private Sub txtramt_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Public Sub cleargrid2()
    With rtnshow
        .Clear()
        .Rows = 1
        .Cols = 5
        .row = 0
        .ColWidth(0) = 900
        .ColWidth(1) = 700
        .ColWidth(2) = 1200
        .ColWidth(3) = 1100
        .ColWidth(4) = 700

        '.ColWidth(5) = 1200

        .col = 0 : .Text = "D_code"
        .col = 1 : .Text = "slno"
        .col = 2 : .Text = "Check_no"
        .col = 3 : .Text = "Drawee_bankcode"
        .col = 4 : .Text = "Status"
    End With
End Sub



Private Sub txtramt_LostFocus()
    If Trim(txtramt.Text) = "" Then
        Exit Sub
    End If
    cleargrid2()
dssave.Open ("SELECT a.d_code,a.slno,a.check_no,a.amount,a.draweebank_code,a.rtnstatus,b.client_code from csd as a,dschedule as b where a.d_code=b.d_code and b.ds_code='" & Trim(txtds.Text) & "' and b.client_code<>'999999' and a.amount=" & txtramt.Text & ""), oconn.Connection, adOpenKeyset, adLockPessimistic

    If dssave.RecordCount > 0 Then
        csd = True
        cleargrid2()
        Do While Not dssave.EOF
            With rtnshow
                .Rows = .Rows + 1
                .row = .Rows - 1
                .col = 0 : .Text = dssave!d_code
                .col = 1 : .Text = dssave!slno
                .col = 2 : .Text = dssave!Check_no & ""
                .col = 3 : .Text = dssave!draweebank_code & ""
                .col = 4 : .Text = dssave!rtnstatus & ""

            End With
            dssave.MoveNext()
        Loop
        rtnshow.SetFocus()

    End If
    dssave.Close()

dssave.Open ("select a.d_code,a.slno,a.check_no,a.drawee_bankcode,a.status from ccheck  a,dschedule  b where b.ds_code ='" & Trim(txtds.Text) & "' and b.client_code='999999' and b.d_code=substring(a.zoneref,4,10)  and a.amount=" & txtramt.Text & ""), oconn.Connection, adOpenKeyset, adLockOptimistic

    If dssave.RecordCount > 0 Then
        cchk = True
        Do While Not dssave.EOF
            With rtnshow
                .Rows = .Rows + 1
                .row = .Rows - 1
                .col = 0 : .Text = dssave!d_code
                .col = 1 : .Text = dssave!slno
                .col = 2 : .Text = dssave!Check_no & ""
                .col = 3 : .Text = dssave!drawee_bankcode & ""
                .col = 4 : .Text = dssave!Status & ""

            End With
            dssave.MoveNext()
        Loop
    End If
    dssave.Close()


End Sub

Private Sub txtrtcode_KeyPress(ByVal KeyAscii As Integer)
    If KeyAscii = 13 Then SendKeys("{tab}")
End Sub

Private Sub txtrtcode_Validate(ByVal Cancel As Boolean)
    If Trim(txtrtcode.Text) = "" Then
        Exit Sub
    End If

    'If Not SELECTGRID Then
    '    MsgBox "Must select Record from Grid"
    '    Exit Sub
    'End If
    If rtnchk.State = 1 Then rtnchk.Close()
 rtnchk.Open ("select * from rtnrjct where reject_code='" & Trim(txtrtcode.Text) & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
    If rtnchk.RecordCount = 0 Then
        MsgBox("Invalid Code")
        txtrtcode.Text = ""
        Cancel = True
        rtnchk.Close()
        Exit Sub
    ElseIf rtnchk.RecordCount > 0 Then
        lblreason = rtnchk!reject_reason
        style = vbYesNo + vbDefaultButton2 + vbInformation
        title = "Change Data"
        response = MsgBox(lblreason, style, title)
        If response = vbYes Then
                dssave.Open ("select d_code,rtnstatus from csd  where d_code='" & lbldcode.Caption & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount > 0 Then

                'oconn.Connection.Execute "update csd set rtnstatus='R' where d_code='" & lbldcode.Caption & "' and slno=" & lblslno.Caption & ""
                ' new update entry_date*******24-02-2000****
                        oconn.Connection.Execute "update csd set rtnstatus='R', entry_date='" & Format(Date, "mm/dd/yyyy") & "' where d_code='" & lbldcode.Caption & "' and slno=" & lblslno.Caption & ""

                        nrtn.Open ("select * from creturn where returnref='" & lbldcode.Caption + lblslno.Caption & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
                If nrtn.RecordCount = 0 Then
                    nrtn.AddNew()
                    nrtn!returnref = lbldcode.Caption + lblslno.Caption
                    nrtn!return_code = txtrtcode.Text
                    nrtn!cs_code = Trim(txtcs.Text)

                    '*********** new add entry_date*** 22-02-2000****************
                            nrtn!rtn_date = Format(Date, "dd/mm/yyyy")
                    nrtn.Update()
                ElseIf nrtn.RecordCount > 0 Then
                    'oconn.Connection.Execute "update creturn set returnref='" & lbldcode.Caption + lblslno.Caption & "',return_code='" & Trim(txtrtcode.Text) & "',cs_code='" & Trim(txtcs.Text) & "'where returnref='" & lbldcode.Caption + lblslno.Caption & "'" ',return_date='" & Format(msdate.Text, "dd/mm/yyyy") & "'"

                    '********* new update rtn_date ******22-02-2000*****
                            oconn.Connection.Execute "update creturn set returnref='" & lbldcode.Caption + lblslno.Caption & "',return_code='" & Trim(txtrtcode.Text) & "',cs_code='" & Trim(txtcs.Text) & "',rtn_date='" & Format(Date, "mm/dd/yyyy") & "' where returnref='" & lbldcode.Caption + lblslno.Caption & "'"
                End If
                nrtn.Close()
            End If
            dssave.Close()
                RTNCHECK.Open ("select d_code,status from ccheck  where d_code='" & lbldcode.Caption & "'"), oconn.Connection, adOpenKeyset, adLockOptimistic
            If RTNCHECK.RecordCount > 0 Then

                'oconn.Connection.Execute "update ccheck set status='R' where d_code='" & lbldcode.Caption & "' and slno=" & lblslno.Caption & ""
                'new update entry_date*** 24-02-2000******
                      oconn.Connection.Execute "update ccheck set status='R',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where d_code='" & lbldcode.Caption & "' and slno=" & lblslno.Caption & ""

                '''oconn.Connection.Execute "update creturn set returnref='" & lbldcode.Caption + lblslno.Caption & "',return_code='" & Trim(txtrtcode.Text) & "',cs_code='" & Trim(txtcs.Text) & "'"    ',return_date='" & Format(msdate.Text, "dd/mm/yyyy") & "'"
                dssave.Open("select * from creturn where returnref='" & lbldcode.Caption + lblslno.Caption & "'")
                If dssave.RecordCount = 0 Then
                    dssave.AddNew()
                    dssave!returnref = lbldcode.Caption + lblslno.Caption
                    dssave!return_code = txtrtcode.Text
                    dssave!cs_code = Trim(txtcs.Text)

                    '*********** new add 22-02-2000****************
                            dssave!rtn_date = Format(Date, "dd/mm/yyyy")
                    dssave.Update()
                ElseIf dssave.RecordCount > 0 Then
                    'oconn.Connection.Execute "update creturn set returnref='" & lbldcode.Caption + lblslno.Caption & "',return_code='" & Trim(txtrtcode.Text) & "',cs_code='" & Trim(txtcs.Text) & "'where returnref='" & lbldcode.Caption + lblslno.Caption & "'"  ',return_date='" & Format(msdate.Text, "dd/mm/yyyy") & "'"

                    '**************new add rtn_date**********22-02-2000*********
                            oconn.Connection.Execute "update creturn set returnref='" & lbldcode.Caption + lblslno.Caption & "',return_code='" & Trim(txtrtcode.Text) & "',cs_code='" & Trim(txtcs.Text) & "',rtn_date='" & Format(Date, "mm/dd/yyyy") & "' where returnref='" & lbldcode.Caption + lblslno.Caption & "'"


                End If
                dssave.Close()


            End If
            RTNCHECK.Close()
            cleargrid2()
                    dssave.Open ("SELECT a.d_code,a.slno,a.check_no,a.amount,a.draweebank_code,a.rtnstatus,b.client_code from csd as a,dschedule as b where a.d_code=b.d_code and b.ds_code='" & Trim(txtds.Text) & "' and b.client_code<>'999999' and a.amount=" & txtramt.Text & ""), oconn.Connection, adOpenKeyset, adLockPessimistic

            If dssave.RecordCount > 0 Then
                'cleargrid2
                Do While Not dssave.EOF
                    With rtnshow
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                        .col = 0 : .Text = dssave!d_code
                        .col = 1 : .Text = dssave!slno
                        .col = 2 : .Text = dssave!Check_no & ""
                        .col = 3 : .Text = dssave!draweebank_code & ""
                        .col = 4 : .Text = dssave!rtnstatus & ""

                    End With
                    dssave.MoveNext()
                Loop

            End If
            dssave.Close()

                    dssave.Open ("select a.d_code,a.slno,a.check_no,a.drawee_bankcode,a.status from ccheck  a,dschedule  b where b.ds_code ='" & Trim(txtds.Text) & "' and b.client_code='999999' and b.d_code=substring(a.zoneref,4,10)  and a.amount=" & txtramt.Text & ""), oconn.Connection, adOpenKeyset, adLockOptimistic
            If dssave.RecordCount > 0 Then
                Do While Not dssave.EOF
                    With rtnshow
                        .Rows = .Rows + 1
                        .row = .Rows - 1
                        .col = 0 : .Text = dssave!d_code
                        .col = 1 : .Text = dssave!slno
                        .col = 2 : .Text = dssave!Check_no & ""
                        .col = 3 : .Text = dssave!drawee_bankcode & ""
                        .col = 4 : .Text = dssave!Status & ""

                    End With
                    dssave.MoveNext()
                Loop


            End If
            dssave.Close()
            txtrtcode.Text = ""
            'bcancel.SetFocus
            txtrtcode.SetFocus()
            Cancel = True
            Exit Sub


            '------------------------------
        ElseIf response = vbNo Then

            Cancel = True
            rtnchk.Close()
            Exit Sub
        End If
    End If
    If rtnchk.State = 1 Then rtnchk.Close()

End Sub
