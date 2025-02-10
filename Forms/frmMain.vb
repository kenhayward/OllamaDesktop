Public Class frmMain
    Private Sub btnServers_Click(sender As Object, e As EventArgs) Handles btnServers.Click
        Dim MyForm As New frmServers
        MyForm.ShowDialog(Me)
    End Sub

End Class
