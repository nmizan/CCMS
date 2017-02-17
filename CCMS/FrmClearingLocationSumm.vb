﻿Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Office.Interop

Public Class FrmClearingLocationSumm

#Region "user defined codes"

    Dim _formName As String = "MaintenanceClearingLocationSummary"
    Dim opt As SecForm = New SecForm(_formName)

    Private Sub EnableAuth()
        If opt.IsAuth = True Then
            btnAuthorize.Enabled = True
        Else
            DisableAuth()
        End If
    End Sub

    Private Sub DisableAuth()
        btnAuthorize.Enabled = False
    End Sub

    Private Sub LoadDataGrid()

        If dgView.Columns.Count = 0 Then Exit Sub

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingLocation_GetDetailList")

            commProc.Parameters.Clear()

            If chkShowAll.Checked = True Then
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            End If

            If rdoAuthorized.Checked = True Then
                db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@AUTH_FLAG", DbType.Int32, 0)
            End If

            Dim dt As DataTable = db.ExecuteDataSet(commProc).Tables(0)

            Dim i As Integer

            dgView.Rows.Clear()

            For i = 0 To dt.Rows.Count - 1
                dgView.Rows.Add()
                dgView.Item(1, i).Value = dt.Rows(i).Item("MOD_NO").ToString()
                dgView.Item(2, i).Value = dt.Rows(i).Item("S").ToString()
                dgView.Item(3, i).Value = dt.Rows(i).Item("LOCATION_CODE").ToString()
                dgView.Item(4, i).Value = dt.Rows(i).Item("LOCATION_NAME").ToString()
                dgView.Item(5, i).Value = dt.Rows(i).Item("INPUT_BY").ToString()
                dgView.Item(6, i).Value = NullHelper.DateToString(dt.Rows(i).Item("INPUT_DATETIME"))
                dgView.Item(7, i).Value = dt.Rows(i).Item("INPUT_DATETIME")
                dgView.Item(8, i).Value = dt.Rows(i).Item("AUTH_BY").ToString()
                dgView.Item(9, i).Value = NullHelper.DateToString(dt.Rows(i).Item("AUTH_DATETIME"))
            Next

            'dgView.AutoGenerateColumns = False
            'dgView.DataSource = ds
            'dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub



    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try


            If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing) Then

                Dim frmLocationDet As New FrmClearingLocationDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
                frmLocationDet.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmLocationDet As New FrmClearingLocationDet
        frmLocationDet.Show()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(1).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(1).Value Is DBNull.Value) Then

            Dim frmLocationDet As New FrmClearingLocationDet(dgView.SelectedRows.Item(0).Cells(3).Value, dgView.SelectedRows.Item(0).Cells(1).Value)
            frmLocationDet.Show()
        End If
    End Sub





    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If Not dgView.Rows(e.RowIndex).Cells(2).Value Is Nothing Then


                If dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "D" Then
                    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

                ElseIf dgView.Rows(e.RowIndex).Cells(2).Value.ToString() = "U" Then
                    dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
                End If
            End If

        End If
    End Sub

    Private Sub FrmLocationSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If opt.IsShow = False Then
            MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim i As Integer
        For i = 1 To dgView.Columns.Count - 1
            dgView.Columns(i).ReadOnly = True
        Next
        'LoadDataGrid()
    End Sub

    Private Sub rdoAuthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAuthorized.CheckedChanged

        If rdoAuthorized.Checked = True Then
            'btnAuthorize.Enabled = False
            DisableAuth()
            chkAll.Visible = False
            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = False
            End If
            chkShowAll.Visible = True



        ElseIf rdoUnauthorized.Checked = True Then
            'btnAuthorize.Enabled = True
            EnableAuth()
            chkAll.Visible = True

            If dgView.Columns.Count > 0 Then
                dgView.Columns(0).Visible = True
            End If
            chkShowAll.Visible = False

        End If

        LoadDataGrid()

    End Sub

    Private Sub rdoUnauthorized_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUnauthorized.CheckedChanged

    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim rowsCount, i As Integer
        rowsCount = dgView.Rows.Count

        If chkAll.Checked = True Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = True
            Next i
        ElseIf chkAll.Checked = False Then
            For i = 0 To rowsCount - 1
                dgView(0, i).Value = False
            Next i
        End If
    End Sub

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click

        Try



            If MessageBox.Show("Do you really want to Authorize?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim i As Integer

                Dim db As New SqlDatabase(CommonAppSet.ConnStr)

                Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClearingLocation_Auth")

                For i = 0 To dgView.Rows.Count - 1

                    If dgView.Rows(i).Cells(0).Value = True Then

                        commProc.Parameters.Clear()

                        db.AddInParameter(commProc, "@LOCATION_CODE", DbType.String, dgView.Rows(i).Cells(3).Value.ToString())
                        db.AddInParameter(commProc, "@MOD_NO", DbType.Int32, dgView.Rows(i).Cells(1).Value)
                        db.AddInParameter(commProc, "@MOD_DATETIME", DbType.DateTime, dgView.Rows(i).Cells(7).Value)

                        db.AddParameter(commProc, "@PROC_RET_VAL", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value.ToString(), DataRowVersion.Default, DBNull.Value)

                        Dim result As Integer

                        db.ExecuteNonQuery(commProc)
                        result = db.GetParameterValue(commProc, "@PROC_RET_VAL")
                        If result = 0 Then

                        ElseIf result = 1 Then

                            MessageBox.Show("Update not possible", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 3 Then
                            MessageBox.Show("Already authorized", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 4 Then
                            MessageBox.Show("Record not found", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ElseIf result = 5 Then
                            MessageBox.Show("You cannot authorize the transaction", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf result = 7 Then
                            MessageBox.Show("Data mismatch! Reload records", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else
                            MessageBox.Show("Auth Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If


                Next i

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        LoadDataGrid()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim objExp As New ExportUtil(dgView)

        objExp.ExportXl()



        'Try

        '    Dim totCol As Integer = dgView.Columns.Count
        '    Dim totRow As Integer = dgView.Rows.Count

        '    '--------------

        '    ' Copy the DataTable to an object array
        '    'Dim rawData(dgView.Rows.Count, dgView.Columns.Count - 1) As Object
        '    Dim rawData(totRow, totCol - 1) As Object

        '    ' Copy the column names to the first row of the object array
        '    Dim relCol As Integer = 0

        '    For col = 0 To dgView.Columns.Count - 1

        '        If Not (dgView.Columns(col).HeaderText.Trim() = "" Or dgView.Columns(col).Visible = False) Then
        '            rawData(0, relCol) = dgView.Columns(col).HeaderText
        '            relCol = relCol + 1

        '        End If

        '    Next


        '    For row = 0 To totRow - 1
        '        relCol = 0
        '        For col = 0 To totCol - 1
        '            If Not (dgView.Columns(col).HeaderText.Trim() = "" Or dgView.Columns(col).Visible = False) Then
        '                rawData(row + 1, relCol) = NullHelper.StringToObject(dgView.Rows(row).Cells(col).Value) 'dt.Rows(row).ItemArray(col)
        '                relCol = relCol + 1

        '            End If

        '        Next

        '    Next


        '    ' Calculate the final column letter
        '    Dim finalColLetter As String = String.Empty
        '    Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        '    Dim colCharsetLen As Integer = colCharset.Length

        '    If totCol > colCharsetLen Then
        '        finalColLetter = colCharset.Substring( _
        '         (totCol - 1) \ colCharsetLen - 1, 1)
        '    End If

        '    finalColLetter += colCharset.Substring( _
        '      (totCol - 1) Mod colCharsetLen, 1)

        '    Dim xlApp As New Excel.Application

        '    Dim wb As Excel.Workbook = xlApp.Workbooks.Add

        '    Dim sheet As Excel.Worksheet = wb.Worksheets.Add

        '    sheet.Name = "Export Data"

        '    Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dgView.Rows.Count + 1)

        '    sheet.Range(excelRange, Type.Missing).Value2 = rawData

        '    CType(sheet.Rows(1, Type.Missing), Excel.Range).Font.Bold = True

        '    xlApp.Visible = True
        '    wb.Activate()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub
End Class