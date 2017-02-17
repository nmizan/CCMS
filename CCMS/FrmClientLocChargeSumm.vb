Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class FrmClientLocChargeSumm

#Region "Global Vairables"

    Dim _strClient_Code As String = ""

#End Region

#Region "user defined codes"

    'Dim _formName As String = "MaintenanceClientLocationChargeSummary"
    'Dim opt As SecForm = New SecForm(_formName)


    Private Sub LoadClientInfo()

        lblToolStatus.Text = ""

        Try

            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim dt As New DataTable

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_Client_GetDetailByCode")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)

            dt = db.ExecuteDataSet(commProc).Tables(0)

            If dt.Rows.Count > 0 Then

                lblClientCode.Text = dt.Rows(0)("CLIENT_CODE").ToString()
                lblAccNo.Text = dt.Rows(0)("ACC_NO").ToString()
                lblAccName.Text = dt.Rows(0)("ACC_NAME").ToString()

            Else

                MessageBox.Show("Not a valid client", "Information Loading Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()


            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub



    Private Sub LoadDataGrid()

        Try


            Dim db As New SqlDatabase(CommonAppSet.ConnStr)

            Dim commProc As DbCommand = db.GetStoredProcCommand("CMS_ClientLocCharge_GetDetailList")

            commProc.Parameters.Clear()

            db.AddInParameter(commProc, "@CLIENT_CODE", DbType.String, _strClient_Code)

            If chkShowAll.Checked = True Then
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 1)
            Else
                db.AddInParameter(commProc, "@DEL_FLAG", DbType.Int32, 0)

            End If

            Dim ds As DataSet = db.ExecuteDataSet(commProc)

            dgView.AutoGenerateColumns = False
            dgView.DataSource = ds
            dgView.DataMember = ds.Tables(0).TableName

        Catch ex As Exception

            MessageBox.Show(ex.Message, "!! Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strClientCode As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.

        _strClient_Code = strClientCode


    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub



    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try


            If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing) Then

                Dim frmClientLocChrg As New FrmClientLocChargeDet(_strClient_Code, dgView.SelectedRows.Item(0).Cells(2).Value, dgView.SelectedRows.Item(0).Cells(0).Value)
                frmClientLocChrg.ShowDialog()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataGrid()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frmClientLocChrg As New FrmClientLocChargeDet(_strClient_Code)
        frmClientLocChrg.ShowDialog()

    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If Not (dgView.SelectedRows.Item(0).Cells(0).Value Is Nothing Or dgView.SelectedRows.Item(0).Cells(0).Value Is DBNull.Value) Then

            Dim frmClientLocChrg As New FrmClientLocChargeDet(_strClient_Code, dgView.SelectedRows.Item(0).Cells(2).Value, dgView.SelectedRows.Item(0).Cells(0).Value)
            frmClientLocChrg.ShowDialog()
        End If
    End Sub





    Private Sub dgView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgView.RowPrePaint
        If (e.RowIndex < dgView.Rows.Count - 1) Then
            If dgView.Rows(e.RowIndex).Cells(1).Value.ToString() = "D" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato

            ElseIf dgView.Rows(e.RowIndex).Cells(1).Value.ToString() = "U" Then
                dgView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
            End If
        End If
    End Sub



    Private Sub FrmClientSumm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If opt.IsShow = False Then
        '    MessageBox.Show("You are not authorized !!", "Unauthorize Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'End If

        LoadClientInfo()
        If Not _strClient_Code = "" Then
            LoadDataGrid()
        End If

    End Sub

    

End Class