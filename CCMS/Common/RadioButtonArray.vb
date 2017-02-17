Public Class RadioButtonArray
    Inherits System.Collections.CollectionBase
    Private ReadOnly HostPanel As Windows.Forms.FlowLayoutPanel

    Public Function AddNewButton() As System.Windows.Forms.RadioButton

        Dim rdoButton As New RadioButton()
        Me.List.Add(rdoButton)

        HostPanel.Controls.Add(rdoButton)

        Return rdoButton

    End Function



End Class
