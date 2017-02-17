VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsExportFile"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'Title                  : clsExport
'Author                 : Dewan Ahsanullah
'Purpose                : Export Recordset as text flie
'Creation date          : 06/02/2002
'Reference              :
'Identifier             : Nikashtab-Class-Export-1.0-OK(UT,TE,OK)
'***************************************************************************
'Modification History   :
'Author         Date       Version    Description of change
Option Explicit
Dim exptext As String
Dim expsourcefile As String
'Dim HD, HT As String
Dim exp As Long
Dim i As Integer
Dim totalrec As Long
Dim Openrec As String
Dim fso As New Scripting.FileSystemObject
Dim rsOpenRec As New ADODB.Recordset
'Dim m1, m2, d1, d2, y1, Y2 As Integer
Public Sub exportfile()
    Dim A, B, c, d, e, f, g, h, K, l, j, m, n, o, p, q, r, s, t, u, v, w As String
    Dim expseq As String
    Dim expfile As String
    Dim LOCATION As String
    Dim seqno As String
    
    Set rs = Nothing
    Set rs = ocon.GetResultset("select * from nikashtab where oprdate='" & Format(FrmAccumulate.TxtOpeDate, "mm/dd/yyyy") & "'", adCmdText)
    If Not (rs.BOF And rs.EOF) Then
    
   
    ''//Get data to generate seqno
    
             Set rs = Nothing
             Set rs = ocon.GetResultset("select * from genprm")
             If Not (rs.BOF And rs.EOF) Then
                 seqno = rs!regseqno + 1
             End If

    '/For Create Export file
        LOCATION = Trim(FrmAccumulate.CboEntLoc(0))
        'location = Mid(FrmAccumulate.CboEntLoc, 1, (InStr(FrmAccumulate.CboEntLoc, "-") - 1))
        expseq = Mid(Format(Date, "dd/mm/yyyy"), 1, 2) & Mid(Format(Date, "dd/mm/yyyy"), 4, 2)
        expfile = Right(Format(Date, "dd/mm/yyyy"), 2)
        expfile = LOCATION + expseq + expfile + ".dat"
        '+ Left(Userlocation, 2)_
        '+ ".DAT"
        If fso.FileExists(App.path & "\FileAccumulate\" & expfile) = True Then
        fso.DeleteFile (App.path & "\FileAccumulate\" & expfile)
        End If
        expsourcefile = App.path & "\FileAccumulate\" & expfile   'DAT file location
        
        fso.CreateTextFile App.path & "\FileAccumulate\" & expfile, True
    
'
'    '/Nikash information(003)
'

        If rsOpenRec.State = adStateOpen Then rsOpenRec.Close
       Set rsOpenRec = ocon.GetResultset("select * from nikashtab where oprdate='" & Format(FrmAccumulate.TxtOpeDate, "mm/dd/yyyy") & "'", adCmdText)

        With rsOpenRec
            If Not (.BOF And .EOF) Then
               totalrec = 0
               .MoveLast
               totalrec = .RecordCount
               .MoveFirst
               FrmAccumulate.ProgressBar1 = 0
               FrmAccumulate.Lblcount = "Nikash Information"
               FrmAccumulate.ProgressBar1.Max = totalrec

                Do Until .EOF
exptext = "": A = "": B = "": c = "": d = "": e = "": f = "": g = "": h = "": K = "": l = "": m = "": n = "": o = "": p = "": q = "": r = "": s = "": t = ""
A = Len(.Fields(0)): B = Len(.Fields(1)): c = Len(.Fields(2)): d = Len(.Fields(3)):
e = Len(.Fields(4)): f = Len(.Fields(5)): g = Len(.Fields(6)): h = Len(.Fields(7))
K = Len(.Fields(8)): l = Len(.Fields(9)): m = Len(.Fields(10)): n = Len(.Fields(11))
: o = Len(.Fields(12)): p = Len(.Fields(13)): q = Len(.Fields(14)):
r = IIf(IsNull(Len(.Fields(15))) = True, 0, Len(.Fields(15))): s = IIf(IsNull(Len(.Fields(16))) = True, 0, Len(.Fields(16))): t = IIf(IsNull(Len(.Fields(17))) = True, 0, Len(.Fields(17))): u = IIf(IsNull(Len(.Fields(18))) = True, 0, Len(.Fields(18)))
v = Len(.Fields(19)): w = Len(.Fields(20))
'r = Len(.Fields(16)) ': t = Len(.Fields(17))
                   
                   
                   exptext = "003" _
                   + CStr(.Fields(0)) _
                   + CStr(.Fields(1)) _
                   + CStr(IIf(c < 8, CStr(.Fields(2)) + Space(8 - c), CStr(.Fields(2)))) _
                   + CStr(IIf(d < 8, CStr(.Fields(3)) + Space(8 - d), CStr(.Fields(3)))) _
                   + CStr(IIf(e < 40, CStr(.Fields(4)) + Space(40 - e), CStr(.Fields(4)))) _
                   + CStr(IIf(f < 4, CStr(.Fields(5)) + Space(4 - f), CStr(.Fields(5)))) _
                   + CStr(IIf(g < 15, CStr(.Fields(6)) + Space(15 - g), CStr(.Fields(6)))) _
                   + CStr(IIf(h < 8, CStr(.Fields(7)) + Space(8 - h), CStr(.Fields(7)))) _
                   + CStr(IIf(K < 8, CStr(.Fields(8)) + Space(8 - K), CStr(.Fields(8)))) _
                   + CStr(IIf(l < 8, CStr(.Fields(9)) + Space(8 - l), CStr(.Fields(9)))) _
                   + CStr(IIf(m < 15, CStr(.Fields(10)) + Space(15 - m), CStr(.Fields(10)))) _
                   + CStr(IIf(n < 20, CStr(.Fields(11)) + Space(20 - n), CStr(.Fields(11)))) _
                   + CStr(IIf(o < 8, CStr(.Fields(12)) + Space(8 - o), CStr(.Fields(12)))) _
                   + CStr(IIf(p < 15, CStr(.Fields(13)) + Space(15 - p), CStr(.Fields(13)))) _
                   + CStr(IIf(q < 8, CStr(.Fields(14)) + Space(8 - q), CStr(.Fields(14)))) _
                   + CStr(IIf(r < 8, IIf(IsNull(.Fields(15)) = True, 0, CStr(.Fields(15))) + Space(8 - r), CStr(.Fields(15)))) _
                   + CStr(IIf(s < 20, IIf(IsNull(.Fields(16)) = True, 0, CStr(.Fields(16))) + Space(20 - s), CStr(.Fields(16)))) _
                   + CStr(IIf(t < 5, IIf(IsNull(.Fields(17)) = True, 0, CStr(.Fields(17))) + Space(5 - t), CStr(.Fields(17)))) _
                   + CStr(IIf(u < 8, CStr(.Fields(18)) + Space(8 - u), CStr(.Fields(18)))) _
                   + CStr(IIf(v < 1, CStr(.Fields(19)) + Space(1 - v), CStr(.Fields(19)))) _
                   + CStr(IIf(w < 15, CStr(.Fields(20)) + Space(15 - w), CStr(.Fields(20)))) _
                   + CStr(.Fields(21)) _
                   + CStr(.Fields(22))
                    fso.OpenTextFile(App.path & "\FileAccumulate\" & expfile, ForAppending).WriteLine exptext
                   exp = exp + 1
                 .MoveNext
                FrmAccumulate.ProgressBar1.Max = totalrec
                FrmAccumulate.ProgressBar1.Value = FrmAccumulate.ProgressBar1.Value + 1
                FrmAccumulate.ProgressBar1.Max = totalrec

                Loop
            End If
        End With

 '//// data insert to a text file from chektotal table //////
       Set rsOpenRec = Nothing
       Set rsOpenRec = ocon.GetResultset("select * from checktotal where oprdate='" & Format(FrmAccumulate.TxtOpeDate, "mm/dd/yyyy") & "'", adCmdText)
        'Set rsOpenRec = ocon.GetResultset("select * from checktotal ") 'where oprdate=" & Format(FrmAccumulate.TxtOpeDate, "dd/mm/yyyy") & "", adCmdText)
           With rsOpenRec
           If Not (.BOF And .EOF) Then
                totalrec = 0
               .MoveLast
               totalrec = .RecordCount
               .MoveFirst
               FrmAccumulate.ProgressBar1 = 0
               FrmAccumulate.Lblcount = "check_total"
               FrmAccumulate.ProgressBar1.Max = totalrec

               Do Until .EOF
                   exptext = "": A = "": B = "": c = "": d = "": e = "": f = "": g = "": h = ""
                   A = Len(.Fields(0)): B = Len(.Fields(1)): c = Len(.Fields(2)): d = Len(.Fields(3)): e = Len(.Fields(4)):
                   f = Len(.Fields(5)): g = Len(.Fields(6)): h = Len(.Fields(7))
                   exptext = "004" _
                   + CStr(IIf(A < 8, CStr(.Fields(0)) + Space(8 - A), CStr(.Fields(0)))) _
                   + CStr(IIf(B < 35, CStr(.Fields(1)) + Space(35 - B), CStr(.Fields(1)))) _
                   + CStr(IIf(c < 35, CStr(.Fields(2)) + Space(35 - c), CStr(.Fields(2)))) _
                   + CStr(.Fields(3)) _
                   + CStr(IIf(e < 15, CStr(.Fields(4)) + Space(15 - e), CStr(.Fields(4)))) _
                   + CStr(IIf(f < 3, CStr(.Fields(5)) + Space(3 - f), CStr(.Fields(5)))) _
                   + CStr(IIf(g < 15, CStr(.Fields(6)) + Space(15 - g), CStr(.Fields(6)))) _
                   + CStr(IIf(h < 5, CStr(.Fields(7)) + Space(5 - h), CStr(.Fields(7)))) _
                   + CStr(.Fields(8)) + CStr(.Fields(9))

                   
                   '+ CStr(IIf(e < 35, CStr(.Fields(4)) + Space(35 - e), CStr(.Fields(4))))
                   '+ CStr(IIf(c < 35, CStr(.Fields(5)) + Space(35 - c), CStr(.Fields(5)))) _

                  fso.OpenTextFile(App.path & "\FileAccumulate\" & expfile, ForAppending).WriteLine exptext
                  exp = exp + 1
               
               .MoveNext
               FrmAccumulate.ProgressBar1.Value = FrmAccumulate.ProgressBar1.Value + 1
               Loop
           End If
       End With
       
                        Set rs = Nothing
                        Set rs = ocon.GetResultset("select * from genprm")
                        If Not (rs.BOF And rs.EOF) Then
                            rs!regseqno = seqno
                            rs.Update
                        End If
        
'     End If
'
MsgBox "File is ready for Accumulation!!!!!!.  "
Else
  MsgBox "No record found !!!!!!.", vbOKOnly, "CCMS Subsystem"
End If
End Sub

Public Sub DDExport()
 Dim A, B, c, d, e, f, g, h, K, l, j, m, n, o, p, q, r, s, t, u, v, w As String
    Dim expseq As String
    Dim expfile As String
    Dim LOCATION As String
    Dim seqno As String
    Dim sDSNO As String
    Dim oprdate As Date
    Dim sDDAccno As String
    
    
    Set rs = Nothing
    Set rs = ocon.GetResultset("select * from dd where d_code ='" & Trim(FrmSubSysDDinfo.TxtDSCode.Text) & "'", adCmdText)
    If Not (rs.BOF And rs.EOF) Then
    
  
    ''//Get data to generate seqno
    
             Set rs = Nothing
             Set rs = ocon.GetResultset("select * from genprm")
             If Not (rs.BOF And rs.EOF) Then
            seqno = rs!regseqno + 1
             End If

     '/Assign operation date
      oprdate = Format(FrmSubSysDDinfo.DTPicker1.Value, "mm/dd/yyyy")
     '//

    '/For Create Export file
        'LOCATION = Trim(FrmSubSysDDinfo.CboEntLoc(0))
        'location = Mid(FrmAccumulate.CboEntLoc, 1, (InStr(FrmAccumulate.CboEntLoc, "-") - 1))
        expseq = Mid(Format(Date, "dd/mm/yyyy"), 1, 2) & Mid(Format(Date, "dd/mm/yyyy"), 4, 2)
        expfile = Right(Format(Date, "dd/mm/yyyy"), 2)
        expfile = "DD" + expseq + expfile + ".dat"
        
        '+ Left(Userlocation, 2)_
        '+ ".DAT"
        If fso.FileExists(App.path & "\DDFile\" & expfile) = True Then
        fso.DeleteFile (App.path & "\DDFile\" & expfile)
        End If
        expsourcefile = App.path & "\DDFile\" & expfile   'DAT file location
        
        fso.CreateTextFile App.path & "\DDFile\" & expfile, True
    
'
'    '/Nikash information(003)
'
       sDDAccno = Trim(FrmSubSysDDinfo.TxtAcNo.Text)
        If rsOpenRec.State = adStateOpen Then rsOpenRec.Close
       Set rsOpenRec = ocon.GetResultset("select isnull(drawer_bankcode,0)bank_code,isnull(nikbranch_code,0)nikbranch_code,dd_date,isnull(oprdate,'01/01/1900')oprdate,dd_no, " & _
       " '14'chqtype,amount,d_code,'010009275590007' Acc_no ,SLNO " & _
       " from dd where d_code ='" & Trim(FrmSubSysDDinfo.TxtDSCode.Text) & "'", adCmdText)

        With rsOpenRec
            If Not (.BOF And .EOF) Then
               totalrec = 0
               .MoveLast
               totalrec = Val(.RecordCount)
               .MoveFirst
               FrmSubSysDDinfo.ProgressBar1.Visible = True
               FrmSubSysDDinfo.ProgressBar1 = 0
               FrmSubSysDDinfo.Lblcount = "Nikash Information"
               FrmSubSysDDinfo.ProgressBar1.Max = totalrec
               i = Len(sDDAccno)
                Do Until .EOF
                    exptext = "": A = "": B = "": c = "": d = "": e = "": f = "": g = "": h = "": K = "": l = "": m = "": n = "": o = "": p = "": q = "": r = "": s = "": t = ""
                    A = Len(Trim(.Fields(0))): B = Len(Trim(.Fields(1))): c = Len(Trim(.Fields(2))): d = Len(IIf(IsNull(Trim(.Fields(3))) = True, 0, .Fields(3))):
                    e = Len(Trim(.Fields(4))): f = Len(Trim(.Fields(5)) + Space(1)): g = Len(Trim(.Fields(6))): h = Len(Trim(.Fields(7)))
                    i = Len(Trim(sDDAccno)) 'i = Len(Trim(.Fields(8)))
: K = Len(Trim(oprdate))
                    ': l = Len(.Fields(9)): m = Len(.Fields(10)): n = Len(.Fields(11))
                    ': o = Len(.Fields(12)): p = Len(.Fields(13)): q = Len(.Fields(14)):
                    'r = IIf(IsNull(Len(.Fields(15))) = True, 0, Len(.Fields(15))): s = IIf(IsNull(Len(.Fields(16))) = True, 0, Len(.Fields(16))): t = IIf(IsNull(Len(.Fields(17))) = True, 0, Len(.Fields(17))): u = IIf(IsNull(Len(.Fields(18))) = True, 0, Len(.Fields(18)))
                    'v = Len(.Fields(19)): w = Len(.Fields(20))
                    'r = Len(.Fields(16)) ': t = Len(.Fields(17))
                   sDSNO = CStr(rsOpenRec!d_code) + CStr(Left(rsOpenRec!slno, 3))
                  '' From Field "9-20" are given 0 values
                   exptext = "003" _
                   + CheckSpace(CStr(IIf(IsNull(.Fields(1)) = True, "", .Fields(1))), 7) + CheckSpace(CStr(.Fields(2)), 10) + _
                   CheckSpace(CStr(oprdate), 10) + IIf(e < 15, CStr(Trim(.Fields(4))) + Space(15 - e), CStr(Trim(.Fields(4)))) _
                   + CStr(IIf(f < 3, CStr(Trim(.Fields(5))) + Space(3 - f), CStr(.Fields(5)))) _
                   + CStr(IIf(g < 12, CStr(Trim(.Fields(6))) + Space(12 - g), CStr(Trim(.Fields(6))))) _
                   + CheckSpace(sDSNO, 8) _
                   + CStr(IIf(i < 16, CStr(Trim(sDDAccno)) + Space(16 - i), CStr(Trim(sDDAccno)))) _
                   + "P" + "2600001" + "0"    '+ "0"
                   'IIf(d < 10, CStr(IIf(IsNull(.Fields(3)) = True, "", .Fields(3)))  + Space(10 - d), CStr(.Fields(3))) _
    '                  ' + CStr(IIf(k < 15, CStr(.Fields(9)) + Space(15 - k), CStr(.Fields(10)))) _
'+ CStr(IIf(i < 16, CStr(Trim(.Fields(8))) + Space(16 - i), CStr(Trim(.Fields(8))))) _
'
'                  ' + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0" _
'                   + "0"
                    fso.OpenTextFile(App.path & "\DDFile\" & expfile, ForAppending).WriteLine exptext
                   exp = exp + 1
                 .MoveNext
                FrmSubSysDDinfo.ProgressBar1.Max = totalrec
                FrmSubSysDDinfo.ProgressBar1.Value = FrmSubSysDDinfo.ProgressBar1.Value + 1
                FrmSubSysDDinfo.ProgressBar1.Max = totalrec

                Loop
            End If
        End With

 '//// data insert to a text file from chektotal table //////
       Set rsOpenRec = Nothing
       Set rsOpenRec = ocon.GetResultset("select isnull(d_code,0)d_code,count(d_code)total_chkno,sum(amount)total_chkamt,isnull(oprdate,'01/01/1900'),isnull(nikbranch_code,0)nikbranch_code,'9275590007' Acc_no From dd where d_code ='" & Trim(FrmSubSysDDinfo.TxtDSCode.Text) & "' group by d_code,oprdate,nikbranch_code ", adCmdText)
        'Set rsOpenRec = ocon.GetResultset("select * from checktotal ") 'where oprdate=" & Format(FrmAccumulate.TxtOpeDate, "dd/mm/yyyy") & "", adCmdText)
           With rsOpenRec
           If Not (.BOF And .EOF) Then
                totalrec = 0
               .MoveLast
               totalrec = .RecordCount
               .MoveFirst
               FrmSubSysDDinfo.ProgressBar1 = 0
               FrmSubSysDDinfo.Lblcount = "check_total"
               FrmSubSysDDinfo.ProgressBar1.Max = totalrec

               Do Until .EOF
                   exptext = "": A = "": B = "": c = "": d = "": e = "": f = "": g = "": h = ""
                   A = Len(.Fields(0)): B = Len(.Fields(1)): c = Len(.Fields(2)): d = Len(.Fields(3)): e = Len(.Fields(4)):
                   f = Len(.Fields(5))
                   ': g = Len(.Fields(6)): h = Len(.Fields(7))
                    exptext = "004" _
                    + CStr(IIf(A < 8, CStr(.Fields(0)) + Space(8 - A), CStr(.Fields(0)))) _
                    + CStr(IIf(B < 35, CStr(.Fields(1)) + Space(35 - B), CStr(.Fields(1)))) _
                    + CStr(IIf(c < 35, CStr(.Fields(2)) + Space(35 - c), CStr(.Fields(2)))) _
                    + CStr(oprdate) _
                    + CStr(IIf(e < 15, CStr(.Fields(4)) + Space(15 - e), CStr(.Fields(4)))) _
                    + CStr(IIf(f < 3, CStr(.Fields(5)) + Space(10 - f), CStr(.Fields(5)))) _
                   ' + CStr(IIf(g < 15, CStr(.Fields(6)) + Space(15 - g), CStr(.Fields(6)))) _
                  ' + CStr(IIf(h < 5, CStr(.Fields(7)) + Space(5 - h), CStr(.Fields(7))))
                 '  + CStr(.Fields(8)) + CStr(.Fields(9))

                   
                   '+ CStr(IIf(e < 35, CStr(.Fields(4)) + Space(35 - e), CStr(.Fields(4))))
                   '+ CStr(IIf(c < 35, CStr(.Fields(5)) + Space(35 - c), CStr(.Fields(5)))) _

                  fso.OpenTextFile(App.path & "\DDFile\" & expfile, ForAppending).WriteLine exptext
                  exp = exp + 1
               
               .MoveNext
               FrmSubSysDDinfo.ProgressBar1.Value = FrmSubSysDDinfo.ProgressBar1.Value + 1
               Loop
           End If
       End With
       
                        Set rs = Nothing
                        Set rs = ocon.GetResultset("select * from genprm")
                        If Not (rs.BOF And rs.EOF) Then
                            rs!regseqno = seqno
                            rs.Update
                        End If
        
'     End If
'
MsgBox "File is ready for Accumulation!!!!!!.  "
Else
  MsgBox "No record found !!!!!!.", vbOKOnly, "CCMS Subsystem"
End If
End Sub
Public Function CheckSpace(ByVal DataField As String, ByVal FieldLength As Integer) As String
Dim ilength As Integer
   ilength = Len(DataField)
   ilength = FieldLength - ilength
   CheckSpace = CStr(DataField) + Space(ilength)
   
End Function
