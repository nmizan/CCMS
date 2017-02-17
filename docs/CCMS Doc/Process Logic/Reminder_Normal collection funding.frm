VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.2#0"; "crystl32.ocx"
Begin VB.Form frmManifold 
   ClientHeight    =   5505
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6660
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   ScaleHeight     =   5505
   ScaleWidth      =   6660
   StartUpPosition =   3  'Windows Default
   Begin Crystal.CrystalReport CrystalReport1 
      Left            =   90
      Top             =   60
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      PrintFileLinesPerPage=   60
   End
   Begin VB.Frame Frame9 
      Caption         =   "Deposit Code"
      Enabled         =   0   'False
      Height          =   705
      Left            =   4080
      TabIndex        =   31
      Top             =   2400
      Width           =   2535
      Begin VB.TextBox txtdcode 
         Height          =   285
         Left            =   120
         MaxLength       =   5
         TabIndex        =   32
         Top             =   240
         Width           =   855
      End
   End
   Begin VB.Frame Frame8 
      Enabled         =   0   'False
      Height          =   630
      Left            =   105
      TabIndex        =   28
      Top             =   3165
      Width           =   6480
      Begin VB.TextBox txtBankbranch 
         Height          =   285
         Left            =   1440
         TabIndex        =   30
         Top             =   210
         Width           =   4935
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "Bank && branch"
         Height          =   195
         Left            =   240
         TabIndex        =   29
         Top             =   240
         Width           =   1050
      End
   End
   Begin VB.Frame Frame7 
      Caption         =   "Reminder Number"
      Enabled         =   0   'False
      Height          =   705
      Left            =   120
      TabIndex        =   23
      Top             =   2400
      Width           =   3855
      Begin VB.ComboBox cboReminderNo 
         Height          =   315
         Left            =   1440
         Style           =   2  'Dropdown List
         TabIndex        =   24
         Top             =   240
         Width           =   855
      End
      Begin VB.Label lblReminderName 
         Height          =   255
         Left            =   2400
         TabIndex        =   26
         Top             =   240
         Width           =   1335
      End
      Begin VB.Label lblReminder 
         AutoSize        =   -1  'True
         Caption         =   "Reminder "
         Height          =   195
         Left            =   600
         TabIndex        =   25
         Top             =   240
         Width           =   720
      End
   End
   Begin VB.Frame Frame6 
      Caption         =   "Decide To"
      Height          =   765
      Left            =   120
      TabIndex        =   17
      Top             =   4695
      Width           =   6510
      Begin VB.CommandButton cmdCancel 
         Caption         =   "&Cancel"
         CausesValidation=   0   'False
         Height          =   375
         Left            =   2520
         TabIndex        =   27
         Top             =   240
         Width           =   1455
      End
      Begin VB.CommandButton cmdExit 
         Caption         =   "&Exit"
         CausesValidation=   0   'False
         Height          =   375
         Left            =   4560
         TabIndex        =   19
         Top             =   240
         Width           =   1455
      End
      Begin VB.CommandButton cmdGenerateReport 
         Caption         =   "&Generate Report"
         Height          =   375
         Left            =   480
         TabIndex        =   18
         Top             =   240
         Width           =   1455
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "Send To"
      Height          =   720
      Left            =   120
      TabIndex        =   16
      Top             =   3960
      Width           =   6495
      Begin VB.OptionButton optFile 
         Caption         =   "File"
         Height          =   345
         Left            =   4560
         TabIndex        =   22
         Top             =   255
         Width           =   1335
      End
      Begin VB.OptionButton optScreen 
         Caption         =   "Screen"
         Height          =   315
         Left            =   435
         TabIndex        =   21
         Top             =   255
         Value           =   -1  'True
         Width           =   1335
      End
      Begin VB.OptionButton optPrint 
         Caption         =   "Printer"
         Height          =   375
         Left            =   2490
         TabIndex        =   20
         Top             =   255
         Width           =   1215
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Client and Location"
      Height          =   750
      Left            =   120
      TabIndex        =   6
      Top             =   1575
      Width           =   6495
      Begin VB.TextBox txtLocation 
         Height          =   285
         Left            =   4080
         MaxLength       =   3
         TabIndex        =   14
         Top             =   270
         Width           =   615
      End
      Begin VB.TextBox txtClient 
         Height          =   285
         Left            =   1440
         MaxLength       =   6
         TabIndex        =   12
         Top             =   270
         Width           =   855
      End
      Begin VB.Frame Frame4 
         Caption         =   "Frame4"
         Height          =   135
         Left            =   1800
         TabIndex        =   7
         Top             =   480
         Width           =   15
      End
      Begin VB.Label lblLocation 
         AutoSize        =   -1  'True
         Caption         =   "Location Code"
         Height          =   195
         Left            =   2880
         TabIndex        =   15
         Top             =   270
         Width           =   1035
      End
      Begin VB.Label lblClient 
         AutoSize        =   -1  'True
         Caption         =   "Client Code"
         Height          =   195
         Left            =   480
         TabIndex        =   13
         Top             =   270
         Width           =   810
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Range"
      Height          =   660
      Left            =   120
      TabIndex        =   5
      Top             =   840
      Width           =   6495
      Begin VB.TextBox txtEnding 
         Height          =   285
         Left            =   4080
         MaxLength       =   10
         TabIndex        =   9
         Top             =   240
         Width           =   1095
      End
      Begin VB.TextBox txtStarting 
         Height          =   285
         Left            =   1440
         MaxLength       =   10
         TabIndex        =   8
         Top             =   240
         Width           =   1095
      End
      Begin VB.Label lblTo 
         AutoSize        =   -1  'True
         Caption         =   "To"
         Height          =   195
         Left            =   3720
         TabIndex        =   11
         Top             =   255
         Width           =   195
      End
      Begin VB.Label lblFrom 
         AutoSize        =   -1  'True
         Caption         =   "From"
         Height          =   195
         Left            =   960
         TabIndex        =   10
         Top             =   255
         Width           =   345
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Report Options"
      Height          =   705
      Left            =   120
      TabIndex        =   0
      Top             =   60
      Width           =   6495
      Begin VB.CheckBox chkLocation 
         Caption         =   "Location"
         Height          =   255
         Left            =   5280
         TabIndex        =   4
         Top             =   300
         Width           =   975
      End
      Begin VB.CheckBox chkClient 
         Caption         =   "Client Code"
         Height          =   255
         Left            =   3720
         TabIndex        =   3
         Top             =   300
         Width           =   1215
      End
      Begin VB.CheckBox chkRefNoRange 
         Caption         =   "Reference Range"
         Enabled         =   0   'False
         Height          =   255
         Left            =   1920
         TabIndex        =   2
         Top             =   300
         Width           =   1575
      End
      Begin VB.CheckBox chkDateRange 
         Caption         =   "Date Range"
         Height          =   255
         Left            =   480
         TabIndex        =   1
         Top             =   300
         Width           =   1215
      End
   End
End
Attribute VB_Name = "frmManifold"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim rsMani As New ADODB.Recordset
Dim rsMani1 As New ADODB.Recordset
Dim rsMani2 As New ADODB.Recordset
Dim rs As New ADODB.Recordset
Dim rs1 As New ADODB.Recordset
Dim rs2 As New ADODB.Recordset
Dim rs3 As New ADODB.Recordset
Dim rs4 As New ADODB.Recordset
Dim con As New conn
Dim ocon As New ADODB.Connection
Dim oDate As New clsDate
Dim strReportName As String
Dim strReportHeader As String
Dim varReference As String
Dim varReference1 As String
Dim varZone1 As String
Dim varZone2 As String
Dim intRecordCount As Long 'Integer
Dim strRecordCount As String
Dim intSlno As Long 'Integer
Dim strDcode As String
Dim strReminderName As String
Dim strStarting As String
Dim strEnding As String
Dim grSelectionFormula As String
Dim zn, nzn As Long 'Integer

Private Sub cboReminderNo_Click()
If cboReminderNo.Text = 1 Then
   lblReminderName.Caption = "FIRST"
ElseIf cboReminderNo.Text = 2 Then
   lblReminderName.Caption = "SECOND"
ElseIf cboReminderNo.Text = 3 Then
   lblReminderName.Caption = "THIRD"
ElseIf cboReminderNo.Text = 4 Then
   lblReminderName.Caption = "FOURTH"
ElseIf cboReminderNo.Text = 5 Then
   lblReminderName.Caption = "FIFTH"
ElseIf cboReminderNo.Text = 6 Then
   lblReminderName.Caption = "SIXTH"
ElseIf cboReminderNo.Text = 7 Then
   lblReminderName.Caption = "SEVENTH"
ElseIf cboReminderNo.Text = 8 Then
   lblReminderName.Caption = "EIGHTTH"
ElseIf cboReminderNo.Text = 9 Then
   lblReminderName.Caption = "NINETH"

End If
End Sub

Private Sub cboReminderNo_GotFocus()
    cboReminderNo.AddItem "1"
    cboReminderNo.AddItem "2"
    cboReminderNo.AddItem "3"
    cboReminderNo.AddItem "4"
    cboReminderNo.AddItem "5"
    cboReminderNo.AddItem "6"
    cboReminderNo.AddItem "7"
    cboReminderNo.AddItem "8"
    cboReminderNo.AddItem "9"
End Sub

Private Sub cmdcancel_Click()
    txtStarting = ""
    txtEnding = ""
    txtLocation = ""
    txtClient = ""
    cboReminderNo.Clear
    lblReminderName.Caption = ""
    txtBankbranch = ""
    txtdcode = ""
    Set rs = Nothing
    Set rs1 = Nothing
    Set rs2 = Nothing
    Set rs3 = Nothing
    Set con = Nothing
    
End Sub

Private Sub cmdGenerateReport_Click()
   On Error GoTo ErrorCode
   ReportGenerationType
   grSelectionFormula = ""
'CitiCheck Deposit Manifold
If frmManifold.Caption = "CitiCheck Deposit Manifold Report" Then
   zoneref_procedure
   CrystalReport1.Formulas(1) = "CORRBANK='" & txtBankbranch & "'"
   strReportName = App.path & "\Reports\CitiCheck Manifold.rpt"
   strReportHeader = "CitiCheck Deposit Manifold Report"
   Generate_Report
   Printflag_for_ZoneRef
   
'Checks For Collection
ElseIf frmManifold.Caption = "Checks for Collection Report" Then
   nonzoneref_procedure
   
   CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "MMMM dd, yyyy") & "'"
   
   strReportName = App.path & "\Reports\Checks Collection_ch.rpt"
   Generate_Report
   Printflag_for_NonzoneRef
   
'Normal Collection Funding DD
ElseIf frmManifold.Caption = "Citi Anywhere Funding DD Deposit Manifold" Then
   grSelectionFormula = "{dd_check.d_code}='" & txtdcode & "'"
   CrystalReport1.SelectionFormula = grSelectionFormula
   strReportHeader = "Normal Collection Funding DD Deposit Manifold"
   CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
   strReportName = App.path & "\Reports\Normal Collection Funding DDDMani.rpt"
   Generate_Report

'Normal Collection Processing
ElseIf frmManifold.Caption = "Citi Anywhere Processing Report" Then
    
    CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
    
    If chkDateRange.Value = 1 Then
       If Not txtLocation.Text = "" Then
          If Not txtClient.Text = "" Then
             grSelectionFormula = "{ncolprocessing_check.Client_code}='" & txtClient _
              & "' and {ncolprocessing_check.dlocation_code}='" & txtLocation & "' and {ncolprocessing_check.slip_date} in date (" & Mid(txtStarting, 7, 4) _
             & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
             & ") to date (" & Mid(txtEnding, 7, 4) _
             & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
          Else
             grSelectionFormula = "{ncolprocessing_check.dlocation_code}='" & txtLocation & "' and {ncolprocessing_check.slip_date} in date (" & Mid(txtStarting, 7, 4) _
              & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
             & ") to date (" & Mid(txtEnding, 7, 4) _
             & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
                                      
          End If
                
       ElseIf Not txtClient.Text = "" Then
          grSelectionFormula = "{ncolprocessing_check.Client_code}='" & txtClient & "' and {ncolprocessing_check.slip_date} in date (" & Mid(txtStarting, 7, 4) _
         & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
         & ") to date (" & Mid(txtEnding, 7, 4) _
         & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
               
       Else
          grSelectionFormula = "{ncolprocessing_check.slip_date} in date (" & Mid(txtStarting, 7, 4) _
           & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
          & ") to date (" & Mid(txtEnding, 7, 4) _
          & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
       End If
              
    ElseIf chkLocation.Value = 1 Then
       If Not txtClient.Text = "" Then
          grSelectionFormula = "{ncolprocessing_check.Client_code}='" & txtClient & "' And {ncolprocessing_check.dlocation_code}='" & txtLocation & "'"
       Else
          grSelectionFormula = "{ncolprocessing_check.dlocation_code}='" & txtLocation & "'"
       End If
    ElseIf chkClient.Value = 1 Then
       If Not txtLocation.Text = "" Then
          grSelectionFormula = "{ncolprocessing_check.dlocation_code}='" & txtLocation & "' And {ncolprocessing_check.Client_code}='" & txtClient & "'"
       Else
          grSelectionFormula = "{ncolprocessing_check.Client_code}='" & txtClient & "'"
       End If
    End If
   CrystalReport1.SelectionFormula = grSelectionFormula
   strReportHeader = "Citi Anywhere Processing Report"
   strReportName = App.path & "\Reports\Normal Collection Processing.rpt"
   Generate_Report
         
 'Normal Collection Outstanding
ElseIf frmManifold.Caption = "Citi Anywhere Outstanding Report" Then
    
    'Con.Connection.Execute "update ncoloutstd_check set OutStd_Date='" & Format(Date, "mm/dd/yyyy") & "'"
    
    CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
    
    If chkDateRange.Value = 1 Then
       If Not txtClient.Text = "" Then
          con.Connection.Execute "update ncoloutstd_check set OutStd_Date='" & Format(Date, "mm/dd/yyyy") & "' where Client_code='" & txtClient & "' and (slip_date>='" & Format(txtStarting, "mm/dd/yyyy") & "' and slip_date<= '" & Format(txtEnding, "mm/dd/yyyy") & "')"
          grSelectionFormula = "{ncoloutstd_check.Client_code}='" & txtClient & "' and {ncoloutstd_check.slip_date} in date (" & Mid(txtStarting, 7, 4) _
           & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
          & ") to date (" & Mid(txtEnding, 7, 4) _
          & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
               
       Else
          con.Connection.Execute "update ncoloutstd_check set OutStd_Date='" & Format(Date, "mm/dd/yyyy") & "' where (slip_date>='" & Format(txtStarting, "mm/dd/yyyy") & "' and slip_date<= '" & Format(txtEnding, "mm/dd/yyyy") & "')"
          grSelectionFormula = "{ncoloutstd_check.slip_date} in date (" & Mid(txtStarting, 7, 4) _
           & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
          & ") to date (" & Mid(txtEnding, 7, 4) _
          & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
       End If
    ElseIf chkClient.Value = 1 Then
       con.Connection.Execute "update ncoloutstd_check set OutStd_Date='" & Format(Date, "mm/dd/yyyy") & "' where Client_code='" & txtClient & "'"
       grSelectionFormula = "{ncoloutstd_check.Client_code}='" & txtClient & "'"
    End If
   
   CrystalReport1.SelectionFormula = grSelectionFormula
   strReportHeader = "Normal Collection Outstanding Report"
   strReportName = App.path & "\Reports\Normal Collection Outstanding.rpt"
   Generate_Report

'CitiCheck/Normal Collection Reject Adv.
ElseIf frmManifold.Caption = "CitiCheck/Citi Anywhere Reject Advice Report" Then
    
    CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
    
    If chkClient.Value = 1 Then
       grSelectionFormula = "{ccncolrjctad_check.Client_code}='" & txtClient & "'"
    End If
   CrystalReport1.SelectionFormula = grSelectionFormula
   strReportHeader = "Normal Collection Reject Advice Report"
   strReportName = App.path & "\Reports\Normal Collection Reject Adv.rpt"
   Generate_Report

'Normal Collection Funding Report
ElseIf frmManifold.Caption = "Citi Anywhere Funding Report" Then
    
    CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
    
    If chkDateRange.Value = 1 Then
       If Not txtClient.Text = "" Then
          grSelectionFormula = "{ncolfunding_check.Client_code}='" & txtClient & "' and {ncolfunding_check.status_date} in date (" & Mid(txtStarting, 7, 4) _
           & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
          & ") to date (" & Mid(txtEnding, 7, 4) _
          & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
            
       Else
          grSelectionFormula = "{ncolfunding_check.status_date} in date (" & Mid(txtStarting, 7, 4) _
           & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
          & ") to date (" & Mid(txtEnding, 7, 4) _
          & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
       End If
    ElseIf chkClient.Value = 1 Then
       grSelectionFormula = "{ncolfunding_check.Client_code}='" & txtClient & "'"
    End If
   CrystalReport1.SelectionFormula = grSelectionFormula
   strReportHeader = "Normal Collection Funding Report"
   strReportName = App.path & "\Reports\Normal Collection Funding.rpt"
   Generate_Report

'Normal Collection Return Report
ElseIf frmManifold.Caption = "Citi Anywhere Return Report" Then
    
    CrystalReport1.Formulas(2) = "Printdate='" & Format(Date, "dd/mm/yyyy") & "'"
    
    If chkDateRange.Value = 1 Then
       grSelectionFormula = "{ncolreturn_check.status_date} in date (" & Mid(txtStarting, 7, 4) _
        & ", " & Mid(txtStarting, 4, 2) & ", " & Mid(txtStarting, 1, 2) _
       & ") to date (" & Mid(txtEnding, 7, 4) _
       & ", " & Mid(txtEnding, 4, 2) & ", " & Mid(txtEnding, 1, 2) & ")"
             
    End If
   CrystalReport1.SelectionFormula = grSelectionFormula
   strReportHeader = "Normal Collection Return Report"
   strReportName = App.path & "\Reports\Normal Collection Return.rpt"
   Generate_Report
   
'=============================================
'Modified By - Dewan Ahsanullah
'Date-10/08/2002
'==============================================
'Reminder
ElseIf frmManifold.Caption = "Reminder" Then
Dim start_day As Integer
Dim end_day As Integer
Dim last_date As Date
Dim COUNTER As Integer
Dim reminder As Integer
Set ocon = con.Connection
ocon.Execute ("delete from tempreminder_ch")
    If Day(Date) > 0 And Day(Date) < 16 Then
'--if day(getdate()) is between 1 and 15
        start_day = 1
        end_day = 15
    Else
        start_day = 16
        end_day = 31
    End If
        last_date = DateAdd("m", -6, Date)

        reminder = 6
        COUNTER = 1
  For COUNTER = 1 To 6 '/ loop  to select record
   Dim sql As String
   sql = ""
   sql = " select Slno,client_code,check_no,amount,slip_date,Drawer,dlocation_code,a.nonzoneref,convert(numeric(9),a.nonzoneref)as numnonzoneref , " & _
    " bank_name,branch_name,branch_add1,branch_add2,location_name,ref_date,(a.drawee_bankcode+a.location_code+a.branch_code) as struniquebranch_code " & _
    " from ccheck a, bank b,branch c,location d,normalcollection e where a.drawee_bankcode=c.bank_code and a.drawee_bankcode=b.bank_code and " & _
    " a.branch_code=c.branch_code and a.location_code=c.location_code and " & _
    " a.location_code=d.location_code and a.rejectref is null and a.status='O'  and " & _
    " a.zoneref is null and a.nonzoneref is not null and a.printflag ='P' and a.nonzoneref=e.nonzoneref " & _
    " and day(ref_date) between ' " & start_day & "' and '" & end_day & "' and month(ref_date) = '" & Month(last_date) & "' and year(ref_date) = '" & Year(last_date) & "' "
    
    Set rs4 = ocon.Execute(sql)
   
            Do Until rs4.EOF '/ loop to insert record into temporary table
                sql = ""
                sql = "insert into tempreminder_ch values('" & Replace(Trim(rs4!Bank_name), "'", " ") & "','" & Replace(Trim(rs4!Branch_name), "'", " ") & "','" & Replace(Trim(rs4!branch_add1), "'", " ") & "','" & Replace(Trim(rs4!branch_add2), "'", " ") & "','" & Replace(Trim(rs4!location_name), "'", " ") & "','" & rs4!slno & "','" & rs4!check_no & "','" & Trim(rs4!drawer) & "','" & rs4!Amount & "','" & rs4!nonzoneref & "','" & reminder & "','" & rs4!struniquebranch_code & "','" & rs4!numnonzoneref & "','" & Format(rs4!ref_date, "yyyy/mm/dd") & "','" & rs4!client_code & "')"
                ocon.Execute (sql)
                rs4.MoveNext
            Loop
    
            last_date = DateAdd("m", 1, last_date)
            reminder = reminder - 1
            
    Next '/ end for loop


    grSelectionFormula = ""
    CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "MMMM dd, yyyy") & "'"
    
    If chkRefNoRange.Value = 1 Then
     grSelectionFormula = "{tempreminder_ch.numnonzoneref} in " & Val(txtStarting) & " to " & Val(txtEnding) & ""
     CrystalReport1.SelectionFormula = grSelectionFormula
    ElseIf chkRefNoRange.Value = 0 And (txtClient.Text <> "") Then
     grSelectionFormula = "{tempreminder_ch.client_code}='" & txtClient & "'"
     CrystalReport1.SelectionFormula = grSelectionFormula
    ElseIf chkRefNoRange.Value = 1 And (txtClient.Text <> "") Then
     grSelectionFormula = "{tempreminder_ch.numnonzoneref} in " & Val(txtStarting) & " to " & Val(txtEnding) & " and {tempreminder_ch.client_code}='" & txtClient & "'"
     CrystalReport1.SelectionFormula = grSelectionFormula
    End If
    CrystalReport1.Formulas(0) = "ReminderNo = '" & lblReminderName & "'"
    strReportName = App.path & "\Reports\Reminder_ch.rpt"
    Generate_Report

'Manifold Reprint
ElseIf frmManifold.Caption = "CitiCheck Manifold Reprint Report" Then
    
    'CrystalReport1.Formulas(2) = "PrintDate='" & Format(Date, "dd/mm/yyyy") & "'"
    
    If chkRefNoRange.Value = 1 Then
       grSelectionFormula = "Mid({checkmanifolduser_check.zoneref}, 4, 7) in '" & txtStarting & "' to '" & txtEnding & "'"
       CrystalReport1.SelectionFormula = grSelectionFormula
    End If
   strReportName = App.path & "\Reports\CitiCheck Manifold User.rpt"
   Generate_Report

ElseIf frmManifold.Caption = "Checks for Collection Reprint Report" Then
    
    CrystalReport1.Formulas(2) = "Printdate='" & Format(Date, "MMMM dd, yyyy") & "'"
    
    If chkRefNoRange.Value = 1 Then
       grSelectionFormula = "{collectionmanifolduser_check.nonzoneref} in '" & txtStarting & "' to '" & txtEnding & "'"
       CrystalReport1.SelectionFormula = grSelectionFormula
    End If
   strReportName = App.path & "\Reports\Checks Collection User_ch.rpt"
   Generate_Report
End If
    Exit Sub
ErrorCode:
    MsgBox "Error!!!!!!!" & " " & err.number & " " & err.Description, vbInformation
    frmManifold.Refresh
    Exit Sub
End Sub
Private Sub cmdExit_Click()
   Set rs = Nothing
   Set rs1 = Nothing
   Set rs2 = Nothing
   Set rs3 = Nothing
   Set con = Nothing
   Unload Me
   'frmManifold.Refresh
   frmMain.mnureport.Enabled = True
   frmMain.mnuexit.Enabled = True
   
   
   End Sub

Private Sub cmdGenerateReport_GotFocus()
   Check_procedure
End Sub

Private Sub Form_Load()
   Me.Top = (Screen.Height - Me.Height) / 2
   Me.Left = (Screen.width - Me.width) / 2
   frmMain.mnureport.Enabled = False
   frmMain.mnuexit.Enabled = False
   CrystalReport1.Connect = strconnect
End Sub
Private Sub zoneref_procedure()

If rsMani.State = 1 Then rsMani.Close
'rsMani.Open "select * from ccheck where zoneref is not null and printflag = 'P'", Con.Connection, adOpenKeyset, adLockOptimistic

'/New chane 15/11/2000
rsMani.Open "select max(substring(zoneref,4,7)) as maxzoneref from ccheck where zoneref is not null and printflag = 'P'", con.Connection, adOpenKeyset, adLockOptimistic
'/

'///before 15/11/2000
'If Not (rsMani.EOF And rsMani.BOF) Then
'   rsMani.MoveFirst
'   varReference1 = Mid(rsMani!zoneref, 4, 7)
'   Do Until rsMani.EOF
'      If Val(Mid(rsMani!zoneref, 4, 7)) > Val(varReference1) Then
'         varReference1 = Mid(rsMani!zoneref, 4, 7)
'      End If
'   rsMani.MoveNext
'   Loop
'Else
'   varReference1 = "0000000"
'End If
'///

'/New Change 15/11/2000
If Not (rsMani.EOF And rsMani.BOF) Then
   If IsNull(rsMani!maxzoneref) = False Then
         varReference1 = rsMani!maxzoneref
   Else
        varReference1 = "0000000"
   End If
End If
'/

If rsMani1.State = 1 Then rsMani1.Close
rsMani1.Open "select distinct zone_code as varZone1 from zone order by zone_code", con.Connection, adOpenKeyset, adLockOptimistic
    If rsMani1.RecordCount > 0 Then
       rsMani1.MoveFirst
       ''Do Until rsMani1.EOF
       For zn = 1 To rsMani1.RecordCount '/New change 15/11/2000
           varZone2 = rsMani1!varZone1 & ""
                If rsMani2.State = 1 Then rsMani2.Close
                rsMani2.Open "select client_code,zoneref from checkmanifold_check where substring(zoneref,1,3)='" & varZone2 & "' group by client_code,zoneref", con.Connection, adOpenKeyset, adLockOptimistic
                    If rsMani2.RecordCount > 0 Then
                        varReference1 = Val(varReference1) + 1
                        varReference1 = Format(varReference1, "0000000")
                        con.Connection.Execute "update checkmanifold_check set zoneref='" & _
                                    Trim(varZone2 + varReference1) & "',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where substring(zoneref,1,3)='" & varZone2 & "' and client_code='" & rsMani2!client_code & "'"
                    End If
       rsMani1.MoveNext
       Next '/
       ''Loop
        
    End If

End Sub

Private Sub nonzoneref_procedure()

If rs.State = 1 Then rs.Close
'rs.Open "select * from ccheck where nonzoneref is not null and printflag = 'P'", Con.Connection, adOpenKeyset, adLockOptimistic

'/New Change 15/11/2000
rs.Open "select max(nonzoneref) as maxnonzoneref from ccheck where nonzoneref is not null and printflag = 'P'", con.Connection, adOpenKeyset, adLockOptimistic
'/

'///
'If Not (rs.EOF And rs.BOF) Then
'rs.MoveFirst
'intRecordCount = Val(rs!nonzoneref)
'   Do Until rs.EOF
'      If Val(rs!nonzoneref) > intRecordCount Then
'         intRecordCount = Val(rs!nonzoneref)
'      End If
'   rs.MoveNext
'   Loop
'Else
'   intRecordCount = 0
'End If
'///

'/New Change 15/11/2000
If Not (rs.EOF And rs.BOF) Then
    intRecordCount = Val(rs!maxnonzoneref)
Else
    intRecordCount = 0
End If
'/

If rs.State = 1 Then rs.Close
rs.Open "select * from collectionmanifold_check", con.Connection, adOpenKeyset, adLockOptimistic
With rs
     If Not (.EOF And .BOF) Then
        'Do Until .EOF
        For nzn = 1 To .RecordCount  '/New Change 15/11/2000
            intSlno = !slno
            strDcode = !d_code
            intRecordCount = intRecordCount + 1
            strRecordCount = CStr(Format((intRecordCount), "0000000"))
            
            con.Connection.Execute "update collectionManifold_check set nonzoneref = '" & strRecordCount & "',entry_date='" & Format(Date, "mm/dd/yyyy") & "' where slno= " & intSlno & " and d_code = '" & strDcode & "'"
            'new update entry_date at ccheck*******24-02-2000********
            'Con.Connection.Execute "update ccheck set entry_date='" & Format(Date, "mm/dd/yyyy") & "'where slno= " & intSlno & " and d_code = '" & strDcode & "'"
            
            If rs1.State = 1 Then rs1.Close
            rs1.Open "select * from normalcollection where nonzoneref = '" & strRecordCount & "'", con.Connection, adOpenKeyset, adLockOptimistic
            With rs1
                If .EOF And .BOF Then
                   .AddNew
                   !nonzoneref = strRecordCount
                   !ref_date = Format(Date, "dd/mm/yyyy")
                   !Status = "O"
                   .Update
                Else
                   !ref_date = Format(Date, "dd/mm/yyyy")
                   !Status = "O"
                   !status_date = Null
                   !ddrefno = Null
                   !collectedamount = Null
                   .Update
                End If
            End With
        .MoveNext
        Next  '/
        'Loop
     End If
End With

End Sub
Private Sub Printflag_for_ZoneRef()
If rs.State = 1 Then rs.Close
rs.Open "select * from checkmanifold_check", con.Connection, adOpenKeyset, adLockOptimistic
        If rs.RecordCount > 0 Then
           con.Connection.Execute "update checkmanifold_check set printflag = 'P'"
        End If
End Sub
Private Sub Printflag_for_NonzoneRef()
If rs2.State = 1 Then rs2.Close
rs2.Open "select * from collectionmanifold_check", con.Connection, adOpenKeyset, adLockOptimistic
    With rs2
        If Not (.EOF And .BOF) Then
           con.Connection.Execute "update collectionmanifold_check set printflag = 'P'"
        End If
    End With
End Sub
Private Sub ReportGenerationType()
    Select Case True
        Case optScreen
            CrystalReport1.Destination = crptToWindow
        Case optFile
            CrystalReport1.Destination = crptToFile
        Case optPrint
            CrystalReport1.Destination = crptToPrinter
    End Select
End Sub
Private Sub Generate_Report()
   CrystalReport1.WindowTitle = strReportHeader
   CrystalReport1.WindowState = crptMaximized
   CrystalReport1.ReportFileName = strReportName
   CrystalReport1.Action = 1

End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
Set frmManifold = Nothing
End Sub

Private Sub Form_Terminate()
Set frmManifold = Nothing
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Set frmManifold = Nothing
End Sub

Private Sub txtStarting_Validate(Cancel As Boolean)
   If chkDateRange.Value = 1 Then
     If txtStarting = "" Then
        MsgBox "Starting date should not be blank", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(txtStarting) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
   End If
End Sub
Private Sub txtEnding_Validate(Cancel As Boolean)
    strStarting = Mid(txtStarting, 7, 4) + Mid(txtStarting, 4, 2) + Mid(txtStarting, 1, 2)
    strEnding = Mid(txtEnding, 7, 4) + Mid(txtEnding, 4, 2) + Mid(txtEnding, 1, 2)
   If chkDateRange.Value = 1 Then
     
     If txtEnding = "" Then
        MsgBox "Ending date should not be blank", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     End If
     If oDate.Validate(txtEnding) = False Then
        MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
        Cancel = True
        Exit Sub
     'ElseIf Format(CDate(txtEnding), "dd/mm/yyyy") < Format(CDate(txtStarting), "dd/mm/yyyy") Then
     '   MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
     '   Cancel = True
     '   Exit Sub
      ElseIf Val(strEnding) < Val(strStarting) Then
        MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
        Cancel = True
        Exit Sub
      End If
   End If
End Sub
Private Sub CheckRef_procedure()
   If txtStarting = "" Then
      MsgBox "Starting number should not be blank", vbCritical, "Citibank N.A. Report"
      txtStarting.SetFocus
   ElseIf txtEnding = "" Then
      MsgBox "Ending number should not be blank", vbCritical, "Citibank N.A. Report"
      txtEnding.SetFocus
   ElseIf txtEnding < txtStarting Then
      MsgBox "Ending number must be greater than starting number", vbCritical, "Citibank N.A. Report"
      txtEnding.SetFocus
   End If
End Sub
Private Sub Check_procedure()
   If chkRefNoRange.Value = 1 Then
      CheckRef_procedure
   End If

   If frmManifold.Caption = "Reminder" And chkRefNoRange.Value = 1 And txtStarting <> "" And txtEnding <> "" And txtEnding > txtStarting Then
      If cboReminderNo.Text = "" Then
         MsgBox "Please choose reminder number", vbCritical, "Citibank N.A. Report"
         cboReminderNo.SetFocus
      End If
   End If
   If chkDateRange.Value = 1 And chkRefNoRange.Value = 0 Then
      CheckStarting_procedure
      If txtStarting <> "" And oDate.Validate(txtStarting) = True Then
         CheckEnding_procedure
      End If
   End If
   If chkClient.Value = 1 And Frame3.Enabled = True Then
      CheckClient_procedure
   End If
   If chkLocation.Value = 1 And Frame3.Enabled = True Then
      CheckLocation_procedure
   End If
   If Frame9.Enabled = True Then
      If txtdcode = "" Then
      MsgBox "Deposit code should not be blank", vbCritical, "Citibank N.A. Report"
      txtdcode.SetFocus
      End If
   End If
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
    If txtStarting = "" Then
       MsgBox "Starting date should not be blank", vbCritical, "Citibank N.A. Report"
       txtStarting.SetFocus
       Exit Sub
    ElseIf oDate.Validate(txtStarting) = False Then
       MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
       txtStarting.SetFocus
    End If
End Sub
Private Sub CheckEnding_procedure()
    strStarting = Mid(txtStarting, 7, 4) + Mid(txtStarting, 4, 2) + Mid(txtStarting, 1, 2)
    strEnding = Mid(txtEnding, 7, 4) + Mid(txtEnding, 4, 2) + Mid(txtEnding, 1, 2)
    If txtEnding = "" Then
       MsgBox "Ending date should not be blank", vbCritical, "Citibank N.A. Report"
       txtEnding.SetFocus
       Exit Sub
    ElseIf oDate.Validate(txtEnding) = False Then
       MsgBox "Please enter a valid date", vbCritical, "Citibank N.A. Report"
       txtEnding.SetFocus
       Exit Sub
    ElseIf Val(strEnding) < Val(strStarting) Then
       MsgBox "Ending date should not be less than Starting date", vbCritical, "CitiBank N.A. Report"
       txtEnding.SetFocus
    End If
End Sub





