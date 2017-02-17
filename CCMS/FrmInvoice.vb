Public Class FrmInvoice
    Public Shared frmNm As String
    
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If (frmNm = "FrmCitiCashDetail") Then
            FrmCitiCashDetail.AddText = txtAddText.Text
            Me.Close()
        ElseIf (frmNm = "FrmCitiSpeedDetailSlip") Then
            FrmCitiSpeedDetail.AddSlipText = txtAddText.Text
            Me.Close()
        ElseIf (frmNm = "FrmCitiSpeedDetailCheck") Then
            FrmCitiSpeedDetail.AddCheckText = txtAddText.Text
            Me.Close()
        ElseIf (frmNm = "FrmClearingDetailSlip") Then
            FrmClearingDetail.AddSlipText = txtAddText.Text
            Me.Close()
        ElseIf (frmNm = "FrmClearingDetailCheck") Then
            FrmClearingDetail.AddCheckText = txtAddText.Text
            Me.Close()
        End If
    End Sub

    Private Sub FrmInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (frmNm = "FrmCitiCashDetail") Then
            txtAddText.Text = FrmCitiCashDetail.AddText

        ElseIf (frmNm = "FrmCitiSpeedDetailSlip") Then
            txtAddText.Text = FrmCitiSpeedDetail.AddSlipText

        ElseIf (frmNm = "FrmCitiSpeedDetailCheck") Then
            txtAddText.Text = FrmCitiSpeedDetail.AddCheckText

        ElseIf (frmNm = "FrmClearingDetailSlip") Then
            txtAddText.Text = FrmClearingDetail.AddSlipText

        ElseIf (frmNm = "FrmClearingDetailCheck") Then
            txtAddText.Text = FrmClearingDetail.AddCheckText

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class