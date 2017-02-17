VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomct2.ocx"
Begin VB.Form FrmSubSysDDinfo 
   Caption         =   "DD Information  For Subsystem"
   ClientHeight    =   3600
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5115
   ControlBox      =   0   'False
   DrawStyle       =   3  'Dash-Dot
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3600
   ScaleWidth      =   5115
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame2 
      Height          =   2565
      Left            =   0
      TabIndex        =   6
      Top             =   120
      Width           =   5085
      Begin VB.TextBox TxtAcNo 
         Height          =   285
         Left            =   1440
         TabIndex        =   0
         Text            =   "010009275590007"
         Top             =   480
         Width           =   2535
      End
      Begin VB.TextBox TxtDSCode 
         Height          =   285
         Left            =   1440
         TabIndex        =   2
         Top             =   1410
         Width           =   2295
      End
      Begin MSComCtl2.DTPicker DTPicker1 
         Height          =   375
         Left            =   1440
         TabIndex        =   1
         Top             =   870
         Width           =   1335
         _ExtentX        =   2355
         _ExtentY        =   661
         _Version        =   393216
         Format          =   54263809
         CurrentDate     =   38405
      End
      Begin MSComctlLib.ProgressBar ProgressBar1 
         Height          =   375
         Left            =   240
         TabIndex        =   12
         Top             =   2040
         Width           =   3735
         _ExtentX        =   6588
         _ExtentY        =   661
         _Version        =   393216
         Appearance      =   1
      End
      Begin VB.Label Label3 
         Caption         =   "A/C No"
         Height          =   285
         Left            =   480
         TabIndex        =   11
         Top             =   480
         Width           =   735
      End
      Begin VB.Label Lblcount 
         Height          =   255
         Left            =   2160
         TabIndex        =   9
         Top             =   180
         Width           =   1575
      End
      Begin VB.Label Label1 
         Caption         =   "Deposit Code"
         Height          =   285
         Left            =   150
         TabIndex        =   8
         Top             =   1380
         Width           =   1095
      End
      Begin VB.Label Label2 
         Caption         =   "Operation Date"
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   870
         Width           =   1215
      End
   End
   Begin VB.Frame Frame1 
      Height          =   885
      Left            =   0
      TabIndex        =   3
      Top             =   2640
      Width           =   5085
      Begin VB.CommandButton CmdDDBreakupRpt 
         Caption         =   "DD Breakup Report"
         Height          =   375
         Left            =   2880
         TabIndex        =   10
         Top             =   330
         Width           =   1695
      End
      Begin VB.CommandButton CmdClose 
         Caption         =   "Close"
         Height          =   375
         Left            =   1800
         TabIndex        =   5
         Top             =   330
         Width           =   975
      End
      Begin VB.CommandButton CmdProcess 
         Caption         =   "Process"
         Height          =   375
         Left            =   720
         TabIndex        =   4
         Top             =   330
         Width           =   975
      End
   End
   Begin Crystal.CrystalReport CrystalReport1 
      Left            =   0
      Top             =   0
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      PrintFileLinesPerPage=   60
   End
End
Attribute VB_Name = "FrmSubSysDDinfo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'========================================================
'Title- FrmSubSysDDinfo
'Author- Dewan Ahsanullah
'Purpose- For DD Information file generation
'Creation date:09-04-2005.
'Database- db_Citibank
'Reference -
'=========================================================
'Modification History
'   Author:         Date :      Version:   Description of change:
'1.

'==========================================================
'Control Information:



'==================================================================
Private Sub cmdClose_Click()
Unload FrmSubSysDDinfo
End Sub

Private Sub CmdDDBreakupRpt_Click()
'CrystalReport1.Formulas(0) = "PrnDate='" & Format(Date, "dd/mm/yyyy") & "'"

    CrystalReport1.Destination = crptToWindow
   
   rptSelection = "{VIEWDD_BREAKUP.dd_dcode}='" & TxtDSCode & "'"
   CrystalReport1.Formulas(0) = ""
   CrystalReport1.Formulas(1) = ""
   CrystalReport1.Formulas(2) = ""
   CrystalReport1.ReportFileName = App.path & "\Reports\DDBreakupWithCheck.rpt"
   CrystalReport1.SelectionFormula = rptSelection
            'WindowOption
   CrystalReport1.Action = 1
End Sub

Private Sub CmdProcess_Click()
 Dim clsexport As New clsExportFile
 
 If TxtAcNo.Text = "" Then
  MsgBox "Plz enter Acc no", vbOKOnly, "CCMS"
  Exit Sub
 End If
 
 
 clsexport.DDExport
End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)
 If KeyAscii = 13 Then SendKeys "{tab}"
End Sub

Private Sub Form_Load()
DTPicker1.Value = Format(Date, "DD/MM/YYYY")
ProgressBar1.Visible = False
CrystalReport1.Connect = strconnect
End Sub

