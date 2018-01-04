Public Class oprogramie

    Private Sub oprogramie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imglogo.Image = My.Resources.ikona.ToBitmap()
        lblver.Text = "Wersja:" & vbNewLine & main.version
    End Sub
End Class