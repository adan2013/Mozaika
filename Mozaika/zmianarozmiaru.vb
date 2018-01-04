Public Class zmianarozmiaru

    Private Sub zmianarozmiaru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbloldx.Text = "X: " & dane.rozplanszy.Width
        lbloldy.Text = "Y: " & dane.rozplanszy.Height
        nrx.Value = dane.rozplanszy.Width
        nry.Value = dane.rozplanszy.Height
    End Sub

    Private Sub btnanuluj_Click(sender As Object, e As EventArgs) Handles btnanuluj.Click
        Close()
    End Sub

    Private Sub btnzastosuj_Click(sender As Object, e As EventArgs) Handles btnzastosuj.Click
        Dim lista As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.typ > 4 Then
                If Math.Min(i.wsp.X, i.wsp2.X) >= nrx.Value Or Math.Min(i.wsp.Y, i.wsp2.Y) >= nry.Value Then lista.Add(i)
            Else
                If i.wsp.X >= nrx.Value Or i.wsp.Y >= nry.Value Then lista.Add(i)
            End If
        Next
        If lista.Count > 0 AndAlso Not MsgBox("Część elementów projektu znajduje się poza nowymi granicami planszy. Wprowadzenie nowych granic oznacza ich usunięcie! Kontynuować?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then Exit Sub
        For Each i As obiekt In lista
            dane.zawartosc.Remove(i)
        Next
        dane.rozplanszy = New Size(nrx.Value, nry.Value)
        Close()
    End Sub
End Class