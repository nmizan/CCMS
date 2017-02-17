VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Begin VB.Form frmCitiReport 
   BorderStyle     =   3  'Fixed Dialog
   ClientHeight    =   5715
   ClientLeft      =   1455
   ClientTop       =   1905
   ClientWidth     =   7065
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5715
   ScaleWidth      =   7065
   ShowInTaskbar   =   0   'False
   Begin Crystal.CrystalReport CrystalReport1 
      Left            =   6480
      Top             =   4920
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      PrintFileLinesPerPage=   60
   End
   Begin VB.Frame Frame1 
      Height          =   5670
      Left            =   105
      TabIndex        =   18
      Top             =   0
      Width           =   6885
      Begin VB.Frame FramCharge 
         Caption         =   "Charges"
         Enabled         =   0   'False
         ForeColor       =   &H00000040&
         Height          =   3600
         Left            =   0
         TabIndex        =   33
         Top             =   960
         Visible         =   0   'False
         Width           =   6840
         Begin MSComCtl2.DTPicker txtMEndDate 
            Height          =   375
            Left            =   4560
            TabIndex        =   1
            Top             =   600
            Width           =   1335
            _ExtentX        =   2355
            _ExtentY        =   661
            _Version        =   393216
            Format          =   76021761
            CurrentDate     =   38515
         End
         Begin MSComCtl2.DTPicker TxtMStDate 
            Height          =   390
            Left            =   2040
            TabIndex        =   0
            Top             =   600
            Width           =   1335
            _ExtentX        =   2355
            _ExtentY        =   688
            _Version        =   393216
            Format          =   76021761
            CurrentDate     =   38515
         End
         Begin VB.TextBox TxtFormulaCaption 
            Height          =   285
            Left            =   2040
            TabIndex        =   5
            Top             =   2280
            Width           =   3255
         End
         Begin VB.CheckBox ChkCNetAmount 
            BackColor       =   &H0080C0FF&
            Caption         =   "Calculate On Customer Net Amount"
            Height          =   375
            Left            =   1080
            TabIndex        =   13
            Top             =   120
            Visible         =   0   'False
            Width           =   5055
         End
         Begin VB.Frame Frame8 
            Height          =   855
            Left            =   960
            TabIndex        =   41
            Top             =   2640
            Visible         =   0   'False
            Width           =   5055
            Begin VB.TextBox TxtNetCharge 
               Height          =   285
               Left            =   2400
               MaxLength       =   6
               TabIndex        =   6
               Top             =   360
               Width           =   1560
            End
            Begin VB.Label Label11 
               AutoSize        =   -1  'True
               Caption         =   "Bangladesh Bank Charges"
               ForeColor       =   &H00004000&
               Height          =   195
               Left            =   480
               TabIndex        =   42
               Top             =   360
               Width           =   1890
            End
         End
         Begin VB.ComboBox cmblcode 
            Height          =   315
            Left            =   360
            TabIndex        =   36
            Top             =   1080
            Visible         =   0   'False
            Width           =   615
         End
         Begin VB.ComboBox CmbClient 
            Height          =   315
            Left            =   2040
            TabIndex        =   2
            Top             =   1080
            Width           =   4095
         End
         Begin VB.TextBox txtOtherCharge 
            Height          =   285
            Left            =   2040
            MaxLength       =   6
            TabIndex        =   4
            Top             =   1920
            Width           =   1320
         End
         Begin VB.TextBox txtBBkCharge 
            Height          =   285
            Left            =   2040
            MaxLength       =   6
            TabIndex        =   3
            Top             =   1560
            Width           =   1320
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            Caption         =   "Caption for Report"
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   720
            TabIndex        =   44
            Top             =   2280
            Width           =   1410
         End
         Begin VB.Label Label10 
            AutoSize        =   -1  'True
            Caption         =   "Starting Date "
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   960
            TabIndex        =   40
            Top             =   645
            Width           =   975
         End
         Begin VB.Label Label9 
            AutoSize        =   -1  'True
            Caption         =   "Ending Date "
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   3600
            TabIndex        =   39
            Top             =   600
            Width           =   930
         End
         Begin VB.Label Label8 
            Caption         =   "Location"
            Height          =   255
            Left            =   120
            TabIndex        =   38
            Top             =   1080
            Visible         =   0   'False
            Width           =   735
         End
         Begin VB.Label Label7 
            Caption         =   "Client"
            Height          =   255
            Left            =   1440
            TabIndex        =   37
            Top             =   1080
            Width           =   495
         End
         Begin VB.Label Label6 
            AutoSize        =   -1  'True
            Caption         =   "Other Charges"
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   840
            TabIndex        =   35
            Top             =   1920
            Width           =   1020
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            Caption         =   "Bangladesh Bank Charges"
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   120
            TabIndex        =   34
            Top             =   1545
            Width           =   1890
         End
      End
      Begin VB.Frame Frame7 
         Caption         =   "Send to"
         ForeColor       =   &H00000040&
         Height          =   615
         Left            =   45
         TabIndex        =   32
         Top             =   210
         Width           =   6795
         Begin VB.OptionButton optPrint 
            Caption         =   "Print"
            ForeColor       =   &H00C00000&
            Height          =   330
            Left            =   4470
            TabIndex        =   12
            Top             =   180
            Width           =   1275
         End
         Begin VB.OptionButton optFile 
            Caption         =   "File"
            ForeColor       =   &H00C00000&
            Height          =   285
            Left            =   2850
            TabIndex        =   11
            Top             =   210
            Width           =   945
         End
         Begin VB.OptionButton optView 
            Caption         =   "View"
            ForeColor       =   &H00C00000&
            Height          =   285
            Left            =   1290
            TabIndex        =   10
            Top             =   195
            Value           =   -1  'True
            Width           =   1500
         End
      End
      Begin VB.Frame Frame6 
         Height          =   615
         Left            =   45
         TabIndex        =   27
         Top             =   960
         Width           =   6795
         Begin VB.OptionButton optAll 
            Caption         =   "All"
            ForeColor       =   &H00400040&
            Height          =   195
            Left            =   615
            TabIndex        =   31
            Top             =   270
            Value           =   -1  'True
            Width           =   540
         End
         Begin VB.OptionButton optClient 
            Caption         =   "Client"
            ForeColor       =   &H00400040&
            Height          =   210
            Left            =   4920
            TabIndex        =   30
            Top             =   240
            Width           =   825
         End
         Begin VB.OptionButton optLocation 
            Caption         =   "Location"
            ForeColor       =   &H00400040&
            Height          =   195
            Left            =   3480
            TabIndex        =   29
            Top             =   240
            Width           =   1035
         End
         Begin VB.OptionButton optDateRange 
            Caption         =   "Date Range"
            ForeColor       =   &H00400040&
            Height          =   195
            Left            =   1920
            TabIndex        =   28
            Top             =   270
            Width           =   1170
         End
      End
      Begin VB.Frame Frame5 
         Caption         =   "Client"
         Enabled         =   0   'False
         ForeColor       =   &H00000040&
         Height          =   840
         Left            =   120
         TabIndex        =   24
         Top             =   3600
         Width           =   6600
         Begin VB.TextBox txtClient 
            Height          =   285
            Left            =   2175
            MaxLength       =   6
            TabIndex        =   17
            Top             =   210
            Width           =   720
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            Caption         =   "Client Code"
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   1200
            TabIndex        =   26
            Top             =   225
            Width           =   810
         End
      End
      Begin VB.Frame Frame4 
         Caption         =   "Location"
         Enabled         =   0   'False
         ForeColor       =   &H00000040&
         Height          =   840
         Left            =   120
         TabIndex        =   23
         Top             =   2640
         Width           =   6675
         Begin VB.TextBox txtLocation 
            Height          =   285
            Left            =   2160
            MaxLength       =   3
            TabIndex        =   16
            Top             =   240
            Width           =   750
         End
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            Caption         =   "Location Code"
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   900
            TabIndex        =   25
            Top             =   240
            Width           =   1035
         End
      End
      Begin VB.Frame Frame3 
         Height          =   825
         Left            =   45
         TabIndex        =   22
         Top             =   4695
         Width           =   6795
         Begin VB.CommandButton cmdCancel 
            Caption         =   "&Cancel"
            CausesValidation=   0   'False
            Height          =   495
            Left            =   2520
            TabIndex        =   8
            Top             =   225
            Width           =   1560
         End
         Begin VB.CommandButton cmdExit 
            Caption         =   "Exit"
            CausesValidation=   0   'False
            Height          =   495
            Left            =   4650
            TabIndex        =   9
            Top             =   225
            Width           =   1560
         End
         Begin VB.CommandButton cmdReport 
            Caption         =   "&Generate Report"
            Height          =   495
            Left            =   360
            TabIndex        =   7
            Top             =   225
            Width           =   1560
         End
      End
      Begin VB.Frame Frame2 
         Caption         =   "Date range"
         Enabled         =   0   'False
         ForeColor       =   &H00000040&
         Height          =   615
         Left            =   165
         TabIndex        =   19
         Top             =   1755
         Width           =   6555
         Begin VB.TextBox txtEnDate 
            Height          =   285
            Left            =   4890
            MaxLength       =   10
            TabIndex        =   15
            Top             =   210
            Width           =   1050
         End
         Begin VB.TextBox txtStDate 
            Height          =   285
            Left            =   2085
            MaxLength       =   10
            TabIndex        =   14
            Top             =   210
            Width           =   1050
         End
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            Caption         =   "Ending Date "
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   3810
            TabIndex        =   21
            Top             =   255
            Width           =   930
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            Caption         =   "Starting Date "
            ForeColor       =   &H00004000&
            Height          =   195
            Left            =   1005
            TabIndex        =   20
            Top             =   255
            Width           =   975
         End
      End
   End
   Begin VB.Label Label12 
      AutoSize        =   -1  'True
      Caption         =   "Other Charges"
      ForeColor       =   &H00004000&
      Height          =   195
      Left            =   960
      TabIndex        =   43
      Top             =   3240
      Width           =   1020
   End
End
Attribute VB_Name = "frmCitiReport"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim con As New conn
Dim rs As New ADODB.Recordset
Dim rs1 As New ADODB.Recordset
Dim outDate As New ADODB.Recordset
Private oDate As New clsDate
Dim grSelectionFormula As String
Dim strStarting As String
Dim strEnding As String
Const vbOpen As Integer = 1

Private Sub ChkCNetAmount_Click()
 If ChkCNetAmount.Value = 1 Then
   Frame8.Enabled = True
 Else
   Frame8.Enabled = False
 End If
End Sub

Private Sub cmbclient_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{TAB}"
End Sub

Private Sub cmdcancel_Click()
       
    txtStDate = ""
    txtEnDate = ""
    txtLocation = ""
    txtClient = ""
    txtBBkCharge = 0
    txtOtherCharge = 0
    CmbClient.SetFocus
    'rs.Close
   
    Set rs = Nothing
    Set rs1 = Nothing
    Set con = Nothing
    
End Sub

Private Sub cmdExit_Click()
'If Trim(txtds.Text) = "" Then
kk = MsgBox("Are you sure you want to exit?", vbDefaultButton3 + vbYesNo + vbQuestion, "CCMS")
If kk = vbNo Then
    Exit Sub
Else
     Unload Me
    frmMain.mnureport.Enabled = True
    frmMain.mnuexit.Enabled = True
    'frmMain.Show
'End If
End If
   
    
End Sub

Private Sub cmdReport_Click()
    
    On Error GoTo ErrorCode
    Select Case True
        Case optView
            CrystalReport1.Destination = crptToWindow
        Case optFile
            CrystalReport1.Destination = crptToFile
        Case optPrint
            CrystalReport1.Destination = crptToPrinter
    End Select
    
        If rs.State = vbOpen Then rs.Close
    CrystalReport1.Formulas(0) = ""
   CrystalReport1.Formulas(1) = ""
   CrystalReport1.Formulas(2) = ""
grSelectionFormula = ""
'CitiCash Deposit Report
    If frmCitiReport.Caption = "CitiCash Deposit Report" Then
         
         CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
              cdcrun_report
         ElseIf optDateRange.Value = True Then
               If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{cdc_check.client_code}='" & txtClient _
                    & "' and {cdc_check.location_code}='" & txtLocation & "' and {cdc_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{cdc_check.location_code}='" & txtLocation & "' and {cdc_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{cdc_check.client_code}='" & txtClient & "' and {cdc_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{cdc_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              cdcrun_report
         ElseIf optLocation.Value = True Then
            If Not txtClient.Text = "" Then
               grSelectionFormula = "{cdc_check.client_code}='" & txtClient & "' And {cdc_check.location_code}='" & txtLocation & "'"
            Else
               grSelectionFormula = "{cdc_check.location_code}='" & txtLocation & "'"
            End If
            CrystalReport1.SelectionFormula = grSelectionFormula
            cdcrun_report
         ElseIf optClient.Value = True Then
            If Not txtLocation.Text = "" Then
               grSelectionFormula = "{cdc_check.location_code}='" & txtLocation & "' And {cdc_check.client_code}='" & txtClient & "'"
            Else
               grSelectionFormula = "{cdc_check.client_code}='" & txtClient.Text & "'"
                
            End If
               CrystalReport1.SelectionFormula = grSelectionFormula
               cdcrun_report
         End If
         
 'CitiSpeed Deposit Report
    ElseIf frmCitiReport.Caption = "CitiSpeed Deposit Report" Then
        
         CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
                csdrun_report
         ElseIf optDateRange.Value = True Then
               If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{csd_check.Client_code}='" & txtClient _
                    & "' and {csd_check.Location_code}='" & txtLocation & "' and {csd_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                    & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                    & ") to date (" & Mid(txtEnDate, 7, 4) _
                    & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                    grSelectionFormula = "{csd_check.Location_code}='" & txtLocation & "' and {csd_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                    & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                    & ") to date (" & Mid(txtEnDate, 7, 4) _
                   & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{csd_check.Client_code}='" & txtClient & "' and {csd_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{csd_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               End If
               CrystalReport1.SelectionFormula = grSelectionFormula
               csdrun_report
            
         ElseIf optLocation.Value = True Then
                If Not txtClient.Text = "" Then
                  grSelectionFormula = "{csd_check.Client_code}='" & txtClient & "' And {csd_check.Location_code}='" & txtLocation & "'"
                Else
                  grSelectionFormula = "{csd_check.Location_code}='" & txtLocation & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                csdrun_report
            
         ElseIf optClient.Value = True Then
                If Not txtLocation.Text = "" Then
                  grSelectionFormula = "{csd_check.Location_code}='" & txtLocation & "' And {csd_check.Client_code}='" & txtClient & "'"
                Else
                  grSelectionFormula = "{csd_check.Client_code}='" & txtClient & "'"
                End If
                 CrystalReport1.SelectionFormula = grSelectionFormula
                 csdrun_report
         End If
                
'CitiSpeed Return
    ElseIf frmCitiReport.Caption = "CitiSpeed Return Report" Then
           
        CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
                csdrtn_report
         ElseIf optDateRange.Value = True Then
              If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{csdrtn_check.Client_code}='" & txtClient _
                    & "' and {csdrtn_check.Location_code}='" & txtLocation & "' and {csdrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{csdrtn_check.Location_code}='" & txtLocation & "' and {csdrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
              ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{csdrtn_check.Client_code}='" & txtClient & "' and {csdrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{csdrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
            CrystalReport1.SelectionFormula = grSelectionFormula
                csdrtn_report
         
         ElseIf optLocation.Value = True Then
               If Not txtClient.Text = "" Then
                  grSelectionFormula = "{csdrtn_check.Client_code}='" & txtClient & "' And {csdrtn_check.Location_code}='" & txtLocation & "'"
                Else
                  grSelectionFormula = "{csdrtn_check.Location_code}='" & txtLocation & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                csdrtn_report
         ElseIf optClient.Value = True Then
                If Not txtLocation.Text = "" Then
                  grSelectionFormula = "{csdrtn_check.Location_code}='" & txtLocation & "' And {csdrtn_check.Client_code}='" & txtClient & "'"
                Else
                  grSelectionFormula = "{csdrtn_check.Client_code}='" & txtClient & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                csdrtn_report
         End If


'Consolidate CitiSpeed/Cash
    ElseIf frmCitiReport.Caption = "Consolidated CitiSpeed Report" Then
        
        CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
                concscc_report
         ElseIf optDateRange.Value = True Then
             If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{concscc_check.Client_code}='" & txtClient _
                    & "' and {concscc_check.Location_code}='" & txtLocation & "' and {concscc_check.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{concscc_check.Location_code}='" & txtLocation & "' and {concscc_check.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
              ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{concscc_check.Client_code}='" & txtClient & "' and {concscc_check.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{concscc_check.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                concscc_report
         ElseIf optLocation.Value = True Then
                If Not txtClient.Text = "" Then
                  grSelectionFormula = "{concscc_check.Client_code}='" & txtClient & "' And {concscc_check.Location_code}='" & txtLocation & "'"
                Else
                  grSelectionFormula = "{concscc_check.Location_code}='" & txtLocation & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                concscc_report
         ElseIf optClient.Value = True Then
                If Not txtLocation.Text = "" Then
                  grSelectionFormula = "{concscc_check.Location_code}='" & txtLocation & "' And {concscc_check.Client_code}='" & txtClient & "'"
                Else
                  grSelectionFormula = "{concscc_check.Client_code}='" & txtClient & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                concscc_report
            End If
  '=====================================================
         'Modified by dewan on 29/07/2002'
     ElseIf frmCitiReport.Caption = "Monthly Bill for cash management Services" Then
            ocon.GetResultset ("execute SpMonbill '" & Format(TxtMStDate, "MM/DD/YYYY") & "','" & Format(txtMEndDate, "MM/DD/YYYY") & "','" & Left(CmbClient, 6) & "'")
            FramCharge.Enabled = True
            FramCharge.Visible = True
            grSelectionFormula = ""
            If txtOtherCharge.Text = "" Then
             txtOtherCharge.Text = 0
            End If
            If txtBBkCharge.Text = "" Then
              txtBBkCharge.Text = 0
            End If
            If CmbClient = "" And cmblcode = "" Then
                 grSelectionFormula = "{viewmonbill.schedule_date} in date (" & Mid(TxtMStDate, 7, 4) _
                      & ", " & Mid(TxtMStDate, 4, 2) & ", " & Mid(TxtMStDate, 1, 2) _
                      & ") to date (" & Mid(txtMEndDate, 7, 4) _
                      & ", " & Mid(txtMEndDate, 4, 2) & ", " & Mid(txtMEndDate, 1, 2) & ")"
            ElseIf CmbClient <> "" And cmblcode = "" Then
                  grSelectionFormula = "{viewmonbill.client_code}='" & Left(CmbClient, 6) & "' and {viewmonbill.schedule_date} in date (" & Mid(TxtMStDate, 7, 4) _
                      & ", " & Mid(TxtMStDate, 4, 2) & ", " & Mid(TxtMStDate, 1, 2) _
                      & ") to date (" & Mid(txtMEndDate, 7, 4) _
                      & ", " & Mid(txtMEndDate, 4, 2) & ", " & Mid(txtMEndDate, 1, 2) & ")"
            ElseIf CmbClient <> "" And cmblcode <> "" Then
                  grSelectionFormula = "{viewmonbill.client_code}='" & Left(CmbClient.Text, 3) & "' and {viewmonbill.location_code}='" & cmblcode & "'and {viewmonbill.Schedule_date} in date (" & Mid(TxtMStDate, 7, 4) _
                      & ", " & Mid(TxtMStDate, 4, 2) & ", " & Mid(TxtMStDate, 1, 2) _
                      & ") to date (" & Mid(txtMEndDate, 7, 4) _
                      & ", " & Mid(txtMEndDate, 4, 2) & ", " & Mid(txtMEndDate, 1, 2) & ")"
                
            End If
              
            
          CrystalReport1.SelectionFormula = grSelectionFormula
          Monbill_report
    'Citispeed Deposit Schedule
'CitiCheck Deposit Details
    ElseIf frmCitiReport.Caption = "CitiCheck Deposit Details Report" Then
            
             
        CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
                ccdd_report
         ElseIf optDateRange.Value = True Then
              If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{ccdd_check.Client_code}='" & txtClient _
                    & "' and {ccdd_check.dlocation_code}='" & txtLocation & "' and {ccdd_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{ccdd_check.dlocation_code}='" & txtLocation & "' and {ccdd_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{ccdd_check.Client_code}='" & txtClient & "' and {ccdd_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{ccdd_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              ccdd_report
         ElseIf optLocation.Value = True Then
               If Not txtClient.Text = "" Then
                  grSelectionFormula = "{ccdd_check.Client_code}='" & txtClient & "' And {ccdd_check.dlocation_code}='" & txtLocation & "'"
                Else
                  grSelectionFormula = "{ccdd_check.dlocation_code}='" & txtLocation & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                ccdd_report
         ElseIf optClient.Value = True Then
                If Not txtLocation.Text = "" Then
                  grSelectionFormula = "{ccdd_check.dlocation_code}='" & txtLocation & "' And {ccdd_check.Client_code}='" & txtClient & "'"
                Else
                  grSelectionFormula = "{ccdd_check.Client_code}='" & txtClient & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                ccdd_report
         End If
        
        
'Consolidate CitiCheck Deposit Report
    ElseIf frmCitiReport.Caption = "Consolidate CitiCheck Deposit Report" Then
              
        CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
                concheckdd_report
         ElseIf optDateRange.Value = True Then
             If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{conccheckdeposit_check.Client_code}='" & txtClient _
                    & "' and {conccheckdeposit_check.dlocation_code}='" & txtLocation & "' and {conccheckdeposit_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & "l " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{conccheckdeposit_check.dlocation_code}='" & txtLocation & "' and {conccheckdeposit_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{conccheckdeposit_check.Client_code}='" & txtClient & "' and {conccheckdeposit_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{conccheckdeposit_check.value_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              concheckdd_report
         ElseIf optLocation.Value = True Then
               If Not txtClient.Text = "" Then
                  grSelectionFormula = "{conccheckdeposit_check.Client_code}='" & txtClient & "' And {conccheckdeposit_check.dlocation_code}='" & txtLocation & "'"
                Else
                  grSelectionFormula = "{conccheckdeposit_check.dlocation_code}='" & txtLocation & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                concheckdd_report
         ElseIf optClient.Value = True Then
                If Not txtLocation.Text = "" Then
                  grSelectionFormula = "{conccheckdeposit_check.dlocation_code}='" & txtLocation & "' And {conccheckdeposit_check.Client_code}='" & txtClient & "'"
                Else
                  grSelectionFormula = "{conccheckdeposit_check.Client_code}='" & txtClient & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                concheckdd_report
         End If
  ''---------------------------------------
   'CitiSpeed & CitiCash Summery Report
   '
    ElseIf frmCitiReport.Caption = "CitiCash & CitiSpeed Summery Report" Then
         
         CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
              CitiSpeed_Cash_sum
         ElseIf optDateRange.Value = True Then
               If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{ViewClientDepSum.client_code}='" & txtClient _
                    & "' and {ViewClientDepSum.location_code}='" & txtLocation & "' and {ViewClientDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{ViewClientDepSum.location_code}='" & txtLocation & "' and {ViewClientDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{ViewClientDepSum.client_code}='" & txtClient & "' and {ViewClientDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{ViewClientDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              CitiSpeed_Cash_sum
         ElseIf optLocation.Value = True Then
            If Not txtClient.Text = "" Then
               grSelectionFormula = "{ViewClientDepSum.client_code}='" & txtClient & "' And {ViewClientDepSum.location_code}='" & txtLocation & "'"
            Else
               grSelectionFormula = "{ViewClientDepSum.location_code}='" & txtLocation & "'"
            End If
            CrystalReport1.SelectionFormula = grSelectionFormula
            CitiSpeed_Cash_sum
         ElseIf optClient.Value = True Then
            If Not txtLocation.Text = "" Then
               grSelectionFormula = "{ViewClientDepSum.location_code}='" & txtLocation & "' And {ViewClientDepSum.client_code}='" & txtClient & "'"
            Else
               grSelectionFormula = "{ViewClientDepSum.client_code}='" & txtClient.Text & "'"
                
            End If
               CrystalReport1.SelectionFormula = grSelectionFormula
               CitiSpeed_Cash_sum
         End If
 
   '
   '
  ''---------------------------------------
  
  
  'CitiCheck Return
    ElseIf frmCitiReport.Caption = "CitiCheck Return Report" Then
         
        CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
             
         If optAll.Value = True Then
                ccheckrtn_report
         ElseIf optDateRange.Value = True Then
             If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{ccrtn_check.Client_code}='" & txtClient _
                    & "' and {ccrtn_check.dlocation_code}='" & txtLocation & "' and {ccrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{ccrtn_check.dlocation_code}='" & txtLocation & "' and {ccrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{ccrtn_check.Client_code}='" & txtClient & "' and {ccrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{ccrtn_check.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              ccheckrtn_report
         ElseIf optLocation.Value = True Then
               If Not txtClient.Text = "" Then
                  grSelectionFormula = "{ccrtn_check.Client_code}='" & txtClient & "' And {ccrtn_check.dlocation_code}='" & txtLocation & "'"
                Else
                  grSelectionFormula = "{ccrtn_check.dlocation_code}='" & txtLocation & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                ccheckrtn_report
         ElseIf optClient.Value = True Then
                If Not txtLocation.Text = "" Then
                  grSelectionFormula = "{ccrtn_check.dlocation_code}='" & txtLocation & "' And {ccrtn_check.Client_code}='" & txtClient & "'"
                Else
                  grSelectionFormula = "{ccrtn_check.Client_code}='" & txtClient & "'"
                End If
                CrystalReport1.SelectionFormula = grSelectionFormula
                ccheckrtn_report
         End If
         
         
         
   ''''Day Zero CitiSpeed & CitiCash Summery Report --02/11/2011
   '____________________________________________________________
   '
    ElseIf frmCitiReport.Caption = "Day Zero Cash and Check Report" Then
         
         CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
              DayZero_CitiSpeed_Cash_sum
         ElseIf optDateRange.Value = True Then
               If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{ViewClientZeroDepSum.client_code}='" & txtClient _
                    & "' and {ViewClientZeroDepSum.location_code}='" & txtLocation & "' and {ViewClientZeroDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{ViewClientZeroDepSum.location_code}='" & txtLocation & "' and {ViewClientZeroDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{ViewClientZeroDepSum.client_code}='" & txtClient & "' and {ViewClientZeroDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{ViewClientZeroDepSum.schedule_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              DayZero_CitiSpeed_Cash_sum
         ElseIf optLocation.Value = True Then
            If Not txtClient.Text = "" Then
               grSelectionFormula = "{ViewClientZeroDepSum.client_code}='" & txtClient & "' And {ViewClientZeroDepSum.location_code}='" & txtLocation & "'"
            Else
               grSelectionFormula = "{ViewClientZeroDepSum.location_code}='" & txtLocation & "'"
            End If
            CrystalReport1.SelectionFormula = grSelectionFormula
            DayZero_CitiSpeed_Cash_sum
         ElseIf optClient.Value = True Then
            If Not txtLocation.Text = "" Then
               grSelectionFormula = "{ViewClientZeroDepSum.location_code}='" & txtLocation & "' And {ViewClientZeroDepSum.client_code}='" & txtClient & "'"
            Else
               grSelectionFormula = "{ViewClientZeroDepSum.client_code}='" & txtClient.Text & "'"
                
            End If
               CrystalReport1.SelectionFormula = grSelectionFormula
               DayZero_CitiSpeed_Cash_sum
         End If
 
   '
   '
  ''---------------------------------------
         
         
               
   ''''Day Zero CitiSpeed & CitiCash Summery Report --02/11/2011
   '____________________________________________________________
   '
    ElseIf frmCitiReport.Caption = "Day Zero Cash Report" Then
         
         CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
              DayZero_CitiSpeed_Cash
         ElseIf optDateRange.Value = True Then
               If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{cdc_check_Day_Zero.client_code}='" & txtClient _
                    & "' and {cdc_check_Day_Zero.location_code}='" & txtLocation & "' and {cdc_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{cdc_check_Day_Zero.location_code}='" & txtLocation & "' and {cdc_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{cdc_check_Day_Zero.client_code}='" & txtClient & "' and {cdc_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{cdc_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              DayZero_CitiSpeed_Cash
         ElseIf optLocation.Value = True Then
            If Not txtClient.Text = "" Then
               grSelectionFormula = "{cdc_check_Day_Zero.client_code}='" & txtClient & "' And {cdc_check_Day_Zero.location_code}='" & txtLocation & "'"
            Else
               grSelectionFormula = "{cdc_check_Day_Zero.location_code}='" & txtLocation & "'"
            End If
            CrystalReport1.SelectionFormula = grSelectionFormula
            DayZero_CitiSpeed_Cash
         ElseIf optClient.Value = True Then
            If Not txtLocation.Text = "" Then
               grSelectionFormula = "{cdc_check_Day_Zero.location_code}='" & txtLocation & "' And {cdc_check_Day_Zero.client_code}='" & txtClient & "'"
            Else
               grSelectionFormula = "{cdc_check_Day_Zero.client_code}='" & txtClient.Text & "'"
                
            End If
               CrystalReport1.SelectionFormula = grSelectionFormula
               DayZero_CitiSpeed_Cash
         End If
 
   '
   '
  ''---------------------------------------
         
          ElseIf frmCitiReport.Caption = "Day Zero Check Report" Then
         
         CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
         
         If optAll.Value = True Then
              DayZero_CitiSpeed_Check
         ElseIf optDateRange.Value = True Then
               If Not txtLocation.Text = "" Then
                  If Not txtClient.Text = "" Then
                   grSelectionFormula = "{csd_check_Day_Zero.client_code}='" & txtClient _
                    & "' and {csd_check_Day_Zero.location_code}='" & txtLocation & "' and {csd_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                  Else
                   grSelectionFormula = "{csd_check_Day_Zero.location_code}='" & txtLocation & "' and {csd_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                  & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                  & ") to date (" & Mid(txtEnDate, 7, 4) _
                  & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
                                      
                  End If
                
               ElseIf Not txtClient.Text = "" Then
                  grSelectionFormula = "{csd_check_Day_Zero.client_code}='" & txtClient & "' and {csd_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
               
               Else
                  grSelectionFormula = "{csd_check_Day_Zero.slip_date} in date (" & Mid(txtStDate, 7, 4) _
                 & ", " & Mid(txtStDate, 4, 2) & ", " & Mid(txtStDate, 1, 2) _
                 & ") to date (" & Mid(txtEnDate, 7, 4) _
                 & ", " & Mid(txtEnDate, 4, 2) & ", " & Mid(txtEnDate, 1, 2) & ")"
              End If
              CrystalReport1.SelectionFormula = grSelectionFormula
              DayZero_CitiSpeed_Check
         ElseIf optLocation.Value = True Then
            If Not txtClient.Text = "" Then
               grSelectionFormula = "{csd_check_Day_Zero.client_code}='" & txtClient & "' And {csd_check_Day_Zero.location_code}='" & txtLocation & "'"
            Else
               grSelectionFormula = "{csd_check_Day_Zero.location_code}='" & txtLocation & "'"
            End If
            CrystalReport1.SelectionFormula = grSelectionFormula
            DayZero_CitiSpeed_Check
         ElseIf optClient.Value = True Then
            If Not txtLocation.Text = "" Then
               grSelectionFormula = "{csd_check_Day_Zero.location_code}='" & txtLocation & "' And {csd_check_Day_Zero.client_code}='" & txtClient & "'"
            Else
               grSelectionFormula = "{csd_check_Day_Zero.client_code}='" & txtClient.Text & "'"
                
            End If
               CrystalReport1.SelectionFormula = grSelectionFormula
               DayZero_CitiSpeed_Check
         End If
         
         
         
         
         
    End If
    Exit Sub
ErrorCode:
    MsgBox "Error!!!!!!!" & " " & err.number & " " & err.Description, vbInformation
    frmCitiReport.Refresh

End Sub

Private Sub cmdReport_GotFocus()
If frmCitiReport.Caption = "Monthly Bill for cash management Services" Then
Exit Sub
End If
    Check_procedure
End Sub

Private Sub Form_Load()
    Me.Top = (Screen.Height - Me.Height) / 2
    Me.Left = (Screen.width - Me.width) / 2
    frmMain.mnureport.Enabled = False
    frmMain.mnuexit.Enabled = False
    ''Connect 1 with ODBC
    
     strconnect = "uid=" & sUserid & ";pwd=" & sPwd & ";Data Source=" & sDSN & ";Initial Catalog=" & sDbName & " "
     CrystalReport1.Connect = strconnect
    ''Connect 2 without ODBC
     ' strconnect = "dsn=apacbdmtjus02\uat;uid=" & sUserid & ";pwd=;dsq=db_citibank"
     ' CrystalReport1.Connect = strconnect
      
      ''Connect 3 SQL
     
    
End Sub

Private Sub Form_LostFocus()
rs.Close
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
Set frmCitiReport = Nothing
End Sub

Private Sub Form_Unload(Cancel As Integer)
Unload Me
Set frmCitiReport = Nothing
End Sub



Private Sub optAll_Click()
    
    Frame2.Enabled = False
    Frame4.Enabled = False
    Frame5.Enabled = False
    
End Sub

Private Sub optDateRange_Click()
    Frame2.Enabled = True
    Frame4.Enabled = True
    Frame5.Enabled = True
End Sub

Private Sub optDateRange_LostFocus()
    Frame2.Enabled = True
    Frame4.Enabled = True
    Frame5.Enabled = True
End Sub

Private Sub optLocation_Click()
    Frame4.Enabled = True
    Frame2.Enabled = False
    Frame5.Enabled = False
End Sub

Private Sub optLocation_LostFocus()
    Frame4.Enabled = True
    Frame2.Enabled = False
    Frame5.Enabled = False
End Sub

Private Sub optClient_Click()
    Frame5.Enabled = True
    Frame4.Enabled = False
    Frame2.Enabled = False
End Sub

Private Sub optClient_LostFocus()
    Frame5.Enabled = True
    Frame4.Enabled = False
    Frame2.Enabled = False
End Sub




Private Sub txtBBkCharge_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{TAB}"
End Sub

Private Sub txtEnDate_Validate(Cancel As Boolean)
    strStarting = Mid(txtStDate, 7, 4) + Mid(txtStDate, 4, 2) + Mid(txtStDate, 1, 2)
    strEnding = Mid(txtEnDate, 7, 4) + Mid(txtEnDate, 4, 2) + Mid(txtEnDate, 1, 2)
     If txtEnDate = "" Then
        MsgBox "Ending date should not be blank", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(txtEnDate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
'     ElseIf Format(CDate(txtEnDate), "dd/mm/yyyy") < Format(CDate(txtStDate), "dd/mm/yyyy") Then
'        MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
'        Cancel = True
'        Exit Sub
     ElseIf Val(strEnding) < Val(strStarting) Then
       MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
       Cancel = True
       Exit Sub
     End If
End Sub

Private Sub TxtFormulaCaption_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{TAB}"
End Sub

Private Sub txtMEndDate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{TAB}"
End Sub

Private Sub TxtMStDate_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{TAB}"
End Sub

Private Sub txtOtherCharge_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then SendKeys "{TAB}"
End Sub

Private Sub txtStDate_Validate(Cancel As Boolean)
     If txtStDate = "" Then
        MsgBox "Starting date should not be blank", vbCritical, "CitiBank N.A. Report"
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(txtStDate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
End Sub

Private Sub cdcrun_report()
   CrystalReport1.WindowTitle = "CitiCash Deposit Report"
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = App.path & "\Reports\CitiCash Deposit.rpt"
   CrystalReport1.Action = 1
End Sub
Private Sub CitiSpeed_Cash_sum()
   CrystalReport1.WindowTitle = "CitiCash & Citispeed Deposit Summery  Report"
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = App.path & "\Reports\ClientDepSum.rpt"
   CrystalReport1.Action = 1
End Sub

Private Sub DayZero_CitiSpeed_Cash_sum()
   CrystalReport1.WindowTitle = "Day Zero Client DepSum  Report"
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = App.path & "\Reports\DayZeroClientDepSum.rpt"
   CrystalReport1.Action = 1
End Sub


Private Sub DayZero_CitiSpeed_Cash()
   CrystalReport1.WindowTitle = "Day Zero Cash Report"
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = App.path & "\Reports\CitiCash_Deposit_Day_Zero.rpt"
   CrystalReport1.Action = 1
End Sub
Private Sub DayZero_CitiSpeed_Check()
   CrystalReport1.WindowTitle = "Day Zero Check Report"
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = App.path & "\Reports\CitiSpeed_Deposit_Day_Zero.rpt"
   CrystalReport1.Action = 1
End Sub



Private Sub csdrun_report()
   CrystalReport1.WindowTitle = "CitiSpeed Deposit Report"
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = App.path & "\Reports\CitiSpeed Deposit.rpt"
   CrystalReport1.Action = 1
End Sub

Private Sub csdrtn_report()
    CrystalReport1.WindowTitle = "CitiSpeed Return Report"
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\CitiSpeed Return.rpt"
    CrystalReport1.Action = 1
End Sub

Private Sub concscc_report()
    CrystalReport1.WindowTitle = "Consolidated CitiSpeed Report"
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\Consolidate CitispeedCash.rpt"
    CrystalReport1.Action = 1
End Sub

Private Sub ccdd_report()
    CrystalReport1.WindowTitle = "CitiCheck Deposit Details Report"
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\Citicheck Deposit details.rpt"
    CrystalReport1.Action = 1
End Sub

Private Sub concheckdd_report()
    CrystalReport1.WindowTitle = "Consolidate Citicheck Deposit Report"
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\Consolidate CitiCheck Deposit.rpt"
    CrystalReport1.Action = 1
End Sub

Private Sub ccheckrtn_report()
    CrystalReport1.WindowTitle = "CitiCheck Return Report"
    CrystalReport1.WindowState = crptMaximized
    CrystalReport1.ReportFileName = App.path & "\Reports\Citicheck Return.rpt"
    CrystalReport1.Action = 1
End Sub

Private Sub CheckClient_procedure()
   If txtClient = "" Then
      MsgBox "Client Code should not be blank", vbCritical, "Citibank N.A. Report"
      txtClient.SetFocus
   End If
End Sub
Private Sub CheckLocation_procedure()
   If txtLocation = "" Then
      MsgBox "Location Code should not be blank", vbCritical, "Citibank N.A. Report"
      txtLocation.SetFocus
   End If
End Sub
Private Sub CheckStarting_procedure()
    If txtStDate = "" Then
       MsgBox "Starting date should not be blank", vbCritical, "Citibank N.A. Report"
       txtStDate.SetFocus
       Exit Sub
    ElseIf oDate.Validate(txtStDate) = False Then
       MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
       txtStDate.SetFocus
    End If
End Sub
Private Sub CheckEnding_procedure()
    strStarting = Mid(txtStDate, 7, 4) + Mid(txtStDate, 4, 2) + Mid(txtStDate, 1, 2)
    strEnding = Mid(txtEnDate, 7, 4) + Mid(txtEnDate, 4, 2) + Mid(txtEnDate, 1, 2)
    If txtEnDate = "" Then
       MsgBox "Ending date should not be blank", vbCritical, "Citibank N.A. Report"
       txtEnDate.SetFocus
       Exit Sub
    ElseIf oDate.Validate(txtEnDate) = False Then
       MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
       txtEnDate.SetFocus
       Exit Sub
'    ElseIf Format(CDate(txtEnDate), "dd/mm/yyyy") < Format(CDate(txtStDate), "dd/mm/yyyy") Then
'       MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
'       txtEnDate.SetFocus
    ElseIf Val(strEnding) < Val(strStarting) Then
       MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
       txtEnDate.SetFocus
    End If
End Sub

Private Sub Check_procedure()
    If optDateRange.Value = True Then
       CheckStarting_procedure
       If txtStDate <> "" And oDate.Validate(txtStDate) = True Then
          CheckEnding_procedure
       End If
    End If
    If optClient.Value = True Then
       CheckClient_procedure
    End If
    If optLocation.Value = True Then
       CheckLocation_procedure
    End If
End Sub
Private Sub Monbill_report()

    CrystalReport1.Formulas(0) = "BBKCharge =" & Trim(txtBBkCharge.Text) & ""
    'CrystalReport1.Formulas(1) = "Authorizer ='" & s_user & "'"
    CrystalReport1.Formulas(1) = "OtherCharge =" & Trim(txtOtherCharge.Text) & ""
    CrystalReport1.Formulas(2) = "Caption ='" & Trim(TxtFormulaCaption.Text) & "'"
    CrystalReport1.WindowTitle = "Monthly Bill For Cash Management Services"
    CrystalReport1.WindowState = crptMaximized
    'CrystalReport1.ReportFileName = App.path & "\Reports\MonBillCashLocLess.rpt"
    If ChkCNetAmount.Value <> 1 Then
        CrystalReport1.ReportFileName = App.path & "\Reports\MonBillCash.rpt"
    Else
       ' CrystalReport1.Formulas(2) = "NetChargePerCheck=" & TxtNetCharge & " "
        CrystalReport1.ReportFileName = App.path & "\Reports\MonBillCashNetAmount.rpt"
    End If
        CrystalReport1.Action = 1


   CrystalReport1.Formulas(0) = ""
   CrystalReport1.Formulas(1) = ""
   CrystalReport1.Formulas(2) = ""

End Sub

Private Sub cmbclient_DropDown()
Dim sClientCode As String
Dim sSql As String

sClientCode = CmbClient.Text
 sSql = ""
If CmbClient.Text = "" Then
    sSql = "select distinct client_code,sub_client,acc_name from client "
Else
    sSql = "select distinct client_code,sub_client,acc_name from client where acc_name like '" & sClientCode & "%' order by client_code"
End If
    cmblcode.Clear
    Set rs = Nothing
    Set rs = ocon.GetResultset(sSql)

CmbClient.Clear
If rs.RecordCount > 0 Then

    Do While Not rs.EOF
        CmbClient.AddItem Trim(rs!client_code) + Trim(rs!sub_client) + Space(2) + ":" + Space(2) + Trim(rs!Acc_Name)
        rs.MoveNext
        Loop
End If
'clientadd.Close

End Sub
Private Sub cmblcode_DropDown()
Dim sLocationName As String
Dim sSql As String

sLocationName = cmblcode.Text
 sSql = ""
If cmblcode.Text = "" Then
    sSql = "select distinct location_code,location_name from location  "
Else
    sSql = "select distinct location_code,location_name from location where location_name like '" & sLocationName & "%' "
End If
    cmblcode.Clear
    Set rs = Nothing
    Set rs = ocon.GetResultset(sSql)
    If rs.RecordCount > 0 Then
        Do While Not rs.EOF
            cmblcode.AddItem rs!location_code + Space(2) + ":" + Space(2) + rs!location_name
            rs.MoveNext
        Loop
    End If

End Sub

Private Sub txtMEndDate_Validate(Cancel As Boolean)
    strStarting = Mid(TxtMStDate, 7, 4) + Mid(TxtMStDate, 4, 2) + Mid(TxtMStDate, 1, 2)
    strEnding = Mid(txtMEndDate, 7, 4) + Mid(txtMEndDate, 4, 2) + Mid(txtMEndDate, 1, 2)
     If txtMEndDate = "" Then
        MsgBox "Ending date should not be blank", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(txtMEndDate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
'     ElseIf Format(CDate(txtEnDate), "dd/mm/yyyy") < Format(CDate(txtStDate), "dd/mm/yyyy") Then
'        MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
'        Cancel = True
'        Exit Sub
     ElseIf Val(strEnding) < Val(strStarting) Then
       MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
       Cancel = True
       Exit Sub
     End If
End Sub

Private Sub TxtMStDate_Validate(Cancel As Boolean)
     If TxtMStDate = "" Then
        MsgBox "Starting date should not be blank", vbCritical, "CitiBank N.A. Report"
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(TxtMStDate) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
End Sub
