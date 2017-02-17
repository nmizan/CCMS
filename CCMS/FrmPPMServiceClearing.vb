Public Class FrmPPMServiceClearing
    Private Sub enableHour()
        txtHour.Enabled = True
        lblHour.Enabled = True
    End Sub
    Private Sub disableHour()
        txtHour.Enabled = False
        lblHour.Enabled = False
    End Sub
    Private Sub enableTime()
        dtpTime.Enabled = True
    End Sub
    Private Sub disableTime()
        dtpTime.Enabled = False
    End Sub
    Private Sub FrmPPMServiceClearing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disableHour()
    End Sub

    Private Sub rdoHour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHour.CheckedChanged
        If (rdoHour.Checked = True) Then
            enableHour()
        Else
            disableHour()
        End If
    End Sub

    Private Sub rdoTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTime.CheckedChanged
        If (rdoTime.Checked = True) Then
            enableTime()
        Else
            disableTime()
        End If
    End Sub
End Class