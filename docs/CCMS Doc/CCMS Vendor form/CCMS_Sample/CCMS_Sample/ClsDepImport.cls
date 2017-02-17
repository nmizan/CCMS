VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ClsDepImport"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
'Title                  : clsImport
'Author                 :
'Purpose                : Import Recordset as text flie
'Creation date          : 08/02/2002
'Reference              :""
'Identifier             :
'***************************************************************************
'Modification History   :
'Author         Date       Version    Description of change
Option Explicit

    Dim TempStr As String                    'Text line
    Dim textline As TextStream               'Read text line
    Dim textfilename As String               'Filename
    Dim goahead As Boolean                   'To procees next step
    Dim FileNo As Integer
    
    Dim firsttemp As String                  'To read just first line from the required text file
    Dim countrec As Integer                  'To counting record
    
'/no. record
    Dim totalrec As Integer              'No. of record
'/count
    Dim hdrno As Integer                 'Count Header
    Dim bthdrno As Integer               'Count batch header
    Dim prg As Integer                   'for progress bar

'/File Status Report
    Dim fstdate As String
    Dim fsttime As String
    Dim fsttrndate As String

'Common
    Dim rsHeader As New ADODB.Recordset      'File Header
    Dim rstHeader As New ADODB.Recordset     'Temporary File Header
    Dim fso As New Scripting.FileSystemObject
    Dim f, f1 As String     'unzip file name veriable from split method
    Dim fil As File
    Dim exptext As String
    Dim HD, HT As String
    Dim exp As Long
    Dim i As Integer
    Dim Openrec As String
    Dim m1, m2, d1, d2, y1, Y2 As Integer
    Dim rsBlock As New ADODB.Recordset
Public Sub exportfile()
        
    Dim expseq As String
    Dim expfile As String
    Dim FromDate As Date
    Dim ToDate As Date
    
End Sub
Public Sub splitfile(ByVal flname As String) ', ByVal prgb1 As Object, ByVal cryst As Object, ByVal stsbar1 As Object)
    'Split extract file (say 110101.DAT) into the several tables
    'By  code
    
   On Error Resume Next
    
    totalrec = 0
    countrec = 0
    prg = 0
    Dim fileready As Boolean
    f = flname
    fileready = False
    textfilename = flname
    '======= to get file which is reday to split and check file label validation =========
   ' For Each fil In fso.GetFolder(App.Path & "\Import").Files
       ' textfilename = fil.Name
       ' If fil.Size <> 0 Then
            If Len(f) <> 12 Then
                MsgBox "File Name InCorrect.", vbCritical, "Nikash"
                fileready = False
            Else
                If UCase(Mid(f, 10, 3)) = "DAT" Then
                    fileready = True
                Else
                    MsgBox "Select correct file for restore data", vbInformation, "BEHTRUC"
                    fileready = False
                End If
                
            End If

    
    '======= End File Label Validation ================
    
'=====File label validation satisfied ========

    If fileready = True Then     'File label validation satisfied
    
        'Add text file into the several tables
        gathinfo
        
        If goahead = True Then
      
            MsgBox f & " Successfully Imported.", vbInformation, "Nikash"
         
            'prgb1.Value = 0
            
        Else
            Exit Sub
        End If
    Else
        MsgBox "Sorry this file has been corrupted, Select another file.", vbCritical, "Nikash"
        fileready = False
        Exit Sub
       
    End If
    Exit Sub
End Sub
Private Sub gathinfo()

Dim rsdivision As ADODB.Recordset
Set con = Nothing

'    Else
        'gether information for several tables
        
            Set textline = fso.OpenTextFile(App.path & "\DepositFile\" & textfilename, ForReading)
            TempStr = ""
           ' TempStr = textline.ReadLine
'            If Trim(TempStr) = "" Then
'                textline.SkipLine
'            Else
'                'textline.SkipLine
'            End If
        Do Until textline.AtEndOfStream
            
            TempStr = textline.ReadLine
            
            Select Case Left(TempStr, 3)
            
    '*get bank from text file
               'set con = Nothing
              
                Case "001"
                    Set rsdivision = Nothing
                   ' If rsdivision.State = adStateOpen Then rsdivision.Close
                    Set rsdivision = ocon.GetResultset("select * from NikBank WHERE bank_code='" & Mid(TempStr, 4, 3) & "'", adCmdText)
                    With rsdivision
                        If .BOF And .EOF Then
                            .AddNew
                        End If
                            .Fields(0) = Mid(TempStr, 4, 3)
                            .Fields(1) = Mid(TempStr, 7, 35)
                            .Fields(2) = Mid(TempStr, 42, 35)
                            .Fields(3) = Mid(TempStr, 77, 35)
                            .Fields(4) = Mid(TempStr, 112, 20)
                            .Fields(5) = Mid(TempStr, 132, 2)
                            .Fields(6) = Mid(TempStr, 134, 15)
                            .Fields(7) = Format(Date, "MM/dd/yyyy")
                            .Update

                    End With
                    totalrec = totalrec + 1   'no. of record
                    frmImport.Caption = " Data Retrieve " + CStr(totalrec)
                    
     ''   *get branch from text file
                
            Case "002"
'
                    Set rsdivision = Nothing 'If rsdivision.State = adStateOpen Then rsdivision.Close
                    Set rsdivision = ocon.GetResultset("select * from NikBranch WHERE Bank_code='" & Mid(TempStr, 4, 3) & "' and branch_code='" & Mid(TempStr, 7, 3) & "'" & _
                    " and location_code='" & Mid(TempStr, 45, 3) & "'", adCmdText)
                    With rsdivision
                        If .BOF And .EOF Then
                            .AddNew
                        End If
                        .Fields(0) = Mid(TempStr, 4, 3)
                        .Fields(1) = Mid(TempStr, 7, 3)
                        .Fields(2) = Mid(TempStr, 10, 35)
                        .Fields(3) = Mid(TempStr, 45, 3)
                        .Fields(4) = Mid(TempStr, 48, 35)
                        .Fields(5) = Mid(TempStr, 83, 35)
                        .Fields(6) = Mid(TempStr, 118, 3)
                        .Fields(7) = Mid(TempStr, 121, 1)
                        .Fields(8) = Mid(TempStr, 122, 7)
                        .Fields(9) = Format(Date, "MM/dd/yyyy")

                        .Update

                    End With
                    totalrec = totalrec + 1   'no. of record
                    frmImport.Caption = " Data Retrieve " + CStr(totalrec)
      
 
       Case "004":
                    Set rs = Nothing
                    Set rs = ocon.GetResultset("select * from tmpchecktotal WHERE ds_code='" & Mid(TempStr, 4, 8) & "'and OprDate='" & Format(Mid(TempStr, 82, 10), "MM/dd/yyyy") & "'", adCmdText)
                    With rs
                        If .BOF And .EOF Then
                            .AddNew
                        End If
                        .Fields(0) = Mid(TempStr, 4, 8)
                        .Fields(1) = Mid(TempStr, 12, 35)
                        .Fields(2) = Mid(TempStr, 47, 35)
                        .Fields(3) = Format(Mid(TempStr, 82, 10), "MM/dd/yyyy")
                        .Fields(4) = Mid(TempStr, 92, 15)
                        .Fields(5) = Mid(TempStr, 107, 3)
                        .Fields(6) = Mid(TempStr, 110, 15)
                        .Fields(7) = "" 'Mid(TempStr, 125, 5)
                        .Fields(8) = "" 'Mid(TempStr, 125, 15)     'textfilename
                        .Fields(9) = Mid(TempStr, 125, 15)
                        '.Fields(10) = Mid(TempStr, 144, 5)
                       ' .Fields(11) = Mid(TempStr, 149, 15)
                        .Update

                    End With
                totalrec = totalrec + 1   'no. of record
                FrmChkRegUpload.Caption = " Data Retrieve " + CStr(totalrec)
                'End Select
                 

                Case "005"

                     Set rs = Nothing
                    Set rs = ocon.GetResultset("select  Acc_no,Acc_name,flag,entrydate from Nikclient WHERE Acc_no='" & Mid(TempStr, 4, 15) & "'", adCmdText)
                    With rs
                        If .BOF And .EOF Then
                            .AddNew
                        End If
                         .Fields(0) = Mid(TempStr, 4, 15)
                         .Fields(1) = Mid(TempStr, 19, 40)
                         .Fields(2) = Val(Trim((Mid(TempStr, 59, 1))))
                         .Fields(3) = Format(Date, "yyyy/mm/dd") ' select  Acc_no,Acc_name,flag from client
'                         .Fields(4) = Mid(TempStr, 65, 35)
'                         .Fields(5) = Mid(TempStr, 100, 35)
'                         .Fields(6) = Mid(TempStr, 135, 20)
'                         .Fields(7) = Val(Mid(TempStr, 155, 20))
'                         .Fields(8) = Mid(TempStr, 210, 10)
'                         .Fields(9) = Format(Date, "MM/dd/yyyy")
                        .Update

                    End With
                    totalrec = totalrec + 1   'no. of record
                    frmImport.Caption = " Data Retrieve " + CStr(totalrec)


'        '* get location from text file
'
                Case "006"

'                        Set rs = Nothing
'                        Set rs = ocon.GetResultset("select * from location WHERE location_code='" & Mid(TempStr, 4, 3) & "'", adCmdText)
'                        With rs
'                            If .BOF And .EOF Then
'                                .AddNew
'                            End If
'                            .Fields(0) = Mid(TempStr, 4, 3)
'                            .Fields(1) = Mid(TempStr, 7, 35)
'                            .Update
'
'
'                        End With
'                        totalrec = totalrec + 1   'no. of record
'                        frmImport.Caption = " Data Retrieve " + CStr(totalrec)
'
'        '*get zone from text file
'

                Case "007"
'
'                    Set rs = Nothing
'                    Set rs = ocon.GetResultset("select * from zone WHERE zone_code='" & Mid(TempStr, 4, 3) & "'", adCmdText)
'                    With rs
'                        If .BOF And .EOF Then
'                            .AddNew
'                        End If
'                        .Fields(0) = Mid(TempStr, 4, 3)
'                        .Fields(1) = Mid(TempStr, 7, 35)
'                        .Update
'
'
'                    End With
'                    totalrec = totalrec + 1   'no. of record
'                    frmImport.Caption = " Data Retrieve " + CStr(totalrec)
'
'
'
'        '*/get return from text line
'
                Case "008"

'                    Set rs = Nothing
'                    Set rs = ocon.GetResultset("select * from rtnrjct WHERE reject_code='" & Mid(TempStr, 4, 2) & "'", adCmdText)
'                    With rs
'                        If .BOF And .EOF Then
'                            .AddNew
'                        End If
'                        .Fields(0) = Mid(TempStr, 4, 2)
'                        .Fields(1) = Mid(TempStr, 6, 100)
'                        .Update
'
'
'                    End With
'                    totalrec = totalrec + 1
'                    frmImport.Caption = " Data Retrieve " + CStr(totalrec)
'        '*/get cheqtype from text line
'
                Case "009"
'
'                    Set rs = Nothing
'                    Set rs = ocon.GetResultset("select * from chqtype WHERE ChqTypeNo='" & Mid(TempStr, 4, 2) & "'", adCmdText)
'                    With rs
'                        If .BOF And .EOF Then
'                            .AddNew
'                        End If
'                        .Fields(0) = Mid(TempStr, 4, 2)
'                        .Fields(1) = Mid(TempStr, 6, 50)
'                        .Update
'
'
'                    End With
'                    totalrec = totalrec + 1
'                    frmImport.Caption = " Data Retrieve " + CStr(totalrec)
                '        '*/get cheqtype from text line
'
                Case "010"
'
'                        Set rs = Nothing
'                        Set rs = ocon.GetResultset("select * from elocation WHERE EnLocation_Code='" & Mid(TempStr, 4, 5) & "'", adCmdText)
'                        With rs
'                            If .BOF And .EOF Then
'                                .AddNew
'                            End If
'                            .Fields(0) = Mid(TempStr, 4, 5)
'                            .Fields(1) = Mid(TempStr, 9, 35)
'                            .Fields(2) = Mid(TempStr, 44, 3)
'                            .Fields(3) = Mid(TempStr, 47, 7)
'                            .Update
'
'                        End With
'                        totalrec = totalrec + 1
'                        frmImport.Caption = " Data Retrieve " + CStr(totalrec)

                Case Else
                    MsgBox "Invalid Record Found " + Left(TempStr, 3), vbCritical, ""
                    goahead = False
                    Exit Sub
            End Select
                
        Loop
        textline.Close
        
    goahead = True  'for check other validity
'    End If

    
End Sub


