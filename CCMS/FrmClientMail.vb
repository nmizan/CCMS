

Imports CCMS.Common
Imports Microsoft.Office.Interop
Imports System
Imports Outlook = Microsoft.Office.Interop.Outlook

Imports System.Net.Mail

Imports System.Net

Public Class FrmClientMail

    Inherits System.Windows.Forms.Form

    Private moApp As Outlook.Application
    Private mbKillMe As Boolean = True

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmClientMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            moApp = CType(GetObject(, "Outlook.Application"), Outlook.Application)
            mbKillMe = False
        Catch ex As Exception
            If moApp Is Nothing Then
                moApp = New Outlook.Application
                mbKillMe = True
            End If


        End Try
        If moApp Is Nothing Then
            MessageBox.Show("Outlook is not installed or available.", "RobDog888's Outlook Code Demo", MessageBoxButtons.OK)
            Me.btnSend.Enabled = False
            Exit Sub
        End If

        txtSubject.Text = "[secure]"

    End Sub

    Private Sub FrmClientMail_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If mbKillMe = True Then
            If Not moApp Is Nothing Then
                moApp.Quit()
                moApp = Nothing
            End If
        End If
    End Sub

    Private Function CheckValidData() As Boolean


        If txtTo.Text.Trim() = "" Then
            MessageBox.Show("Recipent required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTo.Focus()
            Return False

        ElseIf txtSubject.Text.Trim() = "" Then
            MessageBox.Show("Subject required !!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSubject.Focus()
            Return False
        End If



        Return True

    End Function
    


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        'Dim oEmail As Outlook.MailItem
        'Me.Cursor = Cursors.WaitCursor
        'oEmail = DirectCast(moApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
        'With oEmail
        '    .To = Me.txtTo.Text
        '    .Subject = Me.txtSubject.Text
        '    '.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
        '    '.Body = Me.txtBody.Text
        '    '<OR CREATE A HTML BASED EMAIL MESSAGE. REMOVE THE 2 LINES ABOVE THIS COMMENT>
        '    .BodyFormat = Outlook.OlBodyFormat.olFormatHTML
        '    .HTMLBody = "<HTML><BODY bgcolor='#f3f3f3'>" & Me.txtBody.Text + "<br/><br/>" + " On Behalf Of " + "<br/>" + CommonAppSet.User & "</BODY></HTML>"
        '    .Display()
        'End With
        'Me.Cursor = Cursors.Default

        ' Different Way

        If MessageBox.Show("Do you really want to Save?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If CheckValidData() Then

                Dim oApp As Outlook._Application
                oApp = New Outlook.Application()
                Dim oMsg As Outlook._MailItem
                oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
                oMsg.Subject = txtSubject.Text
                oMsg.Body = txtBody.Text

                oMsg.To = txtTo.Text

                oMsg.Send()
                oApp = Nothing
                oMsg = Nothing

            End If
        End If





        'fahadcse07@gmail.com
    End Sub
End Class