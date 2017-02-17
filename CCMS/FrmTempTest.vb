
Imports CCMS.Common
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql


Public Class FrmTempTest

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtSql.Clear()



        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpFormList_GetDetail")

            commProc.Parameters.Clear()

            ds = db.ExecuteDataSet(commProc)

            Dim i As Integer = 0
            If ds.Tables(0).Rows.Count > 0 Then

                For i = 0 To ds.Tables(0).Rows.Count - 1

                   

                    'txtSql.AppendText(ds.Tables(0).Rows(0)("FORMS_NAME").ToString())
                    txtSql.AppendText("INSERT INTO FORM_LIST(SLNO, FORMS_NAME, INPUT_BY, INPUT_DATETIME, MOD_NO, [STATUS])" & _
                        Environment.NewLine & _
                        "VALUES(" & (i + 1).ToString() & ",'" & ds.Tables(0).Rows(i)("FORMS_NAME").ToString() & _
                        "',substring(suser_name(),charindex('\',suser_name())+1,20),GETDATE(),1,'L');")

                    txtSql.AppendText(Environment.NewLine)
                    txtSql.AppendText(Environment.NewLine)

                Next



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtSql.SelectAll()
        txtSql.Copy()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        txtSql.Clear()



        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim ds As New DataSet

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_TmpMenuList_GetDetail")

            commProc.Parameters.Clear()

            ds = db.ExecuteDataSet(commProc)

            Dim i As Integer = 0
            If ds.Tables(0).Rows.Count > 0 Then

                For i = 0 To ds.Tables(0).Rows.Count - 1



                    'txtSql.AppendText(ds.Tables(0).Rows(0)("FORMS_NAME").ToString())
                    txtSql.AppendText("INSERT INTO MENU_LIST(SLNO, MENU_NAME, INPUT_BY, INPUT_DATETIME, MOD_NO, [STATUS])" & _
                        Environment.NewLine & _
                        "VALUES(" & (i + 1).ToString() & ",'" & ds.Tables(0).Rows(i)("MENU_NAME").ToString() & _
                        "',substring(suser_name(),charindex('\',suser_name())+1,20),GETDATE(),1,'L');")

                    txtSql.AppendText(Environment.NewLine)
                    txtSql.AppendText(Environment.NewLine)

                Next



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        txtSql.Clear()



        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_FGroup_GetDetailList")

            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)
            db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 1)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer = 0
            If dt.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count - 1



                    'txtSql.AppendText(ds.Tables(0).Rows(0)("FORMS_NAME").ToString())
                    txtSql.AppendText("INSERT INTO F_GROUP(SLNO, FG_ID, FG_NAME, DEPT_SLNO, INPUT_BY, INPUT_DATETIME, INPUT_FROM, " & _
                                        Environment.NewLine & _
                                      "AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS])" & _
                        Environment.NewLine & _
                        "VALUES(" & dt.Rows(i)("SLNO").ToString() & ",'" & dt.Rows(i)("FG_ID").ToString() & _
                        "','" & dt.Rows(i)("FG_NAME").ToString() & "'," & dt.Rows(i)("DEPT_SLNO").ToString() & _
                        ",substring(suser_name(),charindex('\',suser_name())+1,20),GETDATE(),''" & _
                        Environment.NewLine & _
                        ",substring(suser_name(),charindex('\',suser_name())+1,20),GETDATE(),''" & _
                        ",1,'L');")

                    txtSql.AppendText(Environment.NewLine)

                    txtSql.AppendText(Environment.NewLine)

                Next



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        txtSql.Clear()



        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Department_GetDetailList")

            commProc.Parameters.Clear()
            db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)
            db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 1)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer = 0
            If dt.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count - 1



                    'txtSql.AppendText(ds.Tables(0).Rows(0)("FORMS_NAME").ToString())
                    txtSql.AppendText("INSERT INTO DEPARTMENT(SLNO, DEPT_ID, DEPT_NAME, INPUT_BY, INPUT_DATETIME, INPUT_FROM,  " & _
                                        Environment.NewLine & _
                                      "AUTH_BY, AUTH_DATETIME, AUTH_FROM, MOD_NO, [STATUS])" & _
                        Environment.NewLine & _
                        "VALUES(" & dt.Rows(i)("SLNO").ToString() & ",'" & dt.Rows(i)("DEPT_ID").ToString() & _
                        "','" & dt.Rows(i)("DEPT_NAME").ToString() & "'" & _
                        ",substring(suser_name(),charindex('\',suser_name())+1,20),GETDATE(),''" & _
                        Environment.NewLine & _
                        ",substring(suser_name(),charindex('\',suser_name())+1,20),GETDATE(),''" & _
                        ",1,'L');")

                    txtSql.AppendText(Environment.NewLine)

                    txtSql.AppendText(Environment.NewLine)

                Next



            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'CMS_PermForms_GetDetailsAll

        txtSql.Clear()



        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_PermForms_GetDetailsAll")

            commProc.Parameters.Clear()
          

            dt = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer = 0

            If dt.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count - 1



                    'txtSql.AppendText(ds.Tables(0).Rows(0)("FORMS_NAME").ToString())
                    txtSql.AppendText("INSERT INTO PERM_FORMS(FG_SLNO,FORM_SLNO,IS_SHOW,IS_NEW,IS_UNLOCK,IS_AUTHORIZER,IS_DELETE,IS_SAVE,MOD_NO)" & _
                        Environment.NewLine & _
                        "VALUES(" & dt.Rows(i)("FG_SLNO").ToString() & "," & dt.Rows(i)("FORM_SLNO").ToString() & _
                        "," & NullHelper.ToIntNum(dt.Rows(i)("IS_SHOW")) & "" & _
                         "," & NullHelper.ToIntNum(dt.Rows(i)("IS_NEW")) & "" & _
                          "," & NullHelper.ToIntNum(dt.Rows(i)("IS_UNLOCK")) & "" & _
                           "," & NullHelper.ToIntNum(dt.Rows(i)("IS_AUTHORIZER")) & "" & _
                            "," & NullHelper.ToIntNum(dt.Rows(i)("IS_DELETE")) & "" & _
                            "," & NullHelper.ToIntNum(dt.Rows(i)("IS_SAVE")) & "" & _
                        ",1);")

                    txtSql.AppendText(Environment.NewLine)

                    txtSql.AppendText(Environment.NewLine)

                Next



            End If



            Dim commProc2 As DbCommand = db.GetStoredProcCommand("CMS_PermMenus_GetDetailsAll")

            commProc2.Parameters.Clear()


            dt = db.ExecuteDataSet(commProc2).Tables(0)

            i = 0

            If dt.Rows.Count > 0 Then

                For i = 0 To dt.Rows.Count - 1



                    'txtSql.AppendText(ds.Tables(0).Rows(0)("FORMS_NAME").ToString())
                    txtSql.AppendText("INSERT INTO PERM_MENUS(FG_SLNO, MENU_SLNO, IS_VISIBLE, IS_ENABLE, MOD_NO)" & _
                        Environment.NewLine & _
                        "VALUES(" & dt.Rows(i)("FG_SLNO").ToString() & "," & dt.Rows(i)("MENU_SLNO").ToString() & _
                        "," & NullHelper.ToIntNum(dt.Rows(i)("IS_VISIBLE")) & "" & _
                        "," & NullHelper.ToIntNum(dt.Rows(i)("IS_ENABLE")) & "" & _
                        ",1);")

                    txtSql.AppendText(Environment.NewLine)

                    txtSql.AppendText(Environment.NewLine)

                Next



            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class