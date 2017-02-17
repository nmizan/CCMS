Imports CCMS.Common

Public Class FrmPPMServiceCollection

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

    Private Sub FrmPPMService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disableHour()
    End Sub

    Private Function CheckValidData() As Boolean
        If (rdoHour.Checked = True) Then
            If (Convert.ToDecimal(txtHour.Text.Trim) < 0) Then
                MessageBox.Show("Hour Interval must be greater than zero!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHour.Focus()
                Return False
            End If
        End If
        If (chkCollection.Checked = False And chkCollectionReturn.Checked = False) Then
            MessageBox.Show("One of the files must be selected!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function
    Private Function SaveData() As TransState
        Dim tStatus As TransState
        Return tStatus
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tState As TransState

        lblToolStatus.Text = ""
        If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If CheckValidData() Then

                tState = SaveData()

            End If
        End If
    End Sub
End Class