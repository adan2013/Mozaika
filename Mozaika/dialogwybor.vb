Public Class dialogwybor

    Public wynik As wynikdialog

    Public Enum wynikdialog
        anuluj = -1
        obiekt1 = 0
        obiekt2 = 1
        obaobiekty = 2
    End Enum

    Public Sub zaladuj(ByVal dopisektytul As String, ByVal dopisekbtn As String, ByVal obazabronione As Boolean, ByVal ob1 As obiekt, ByVal ob2 As obiekt)
        wynik = wynikdialog.anuluj
        lbltytul.Text &= " " & dopisektytul & "?"
        btnoba.Text = dopisekbtn & " " & btnoba.Text
        btnob1.Text = dopisekbtn & " " & btnob1.Text
        btnob2.Text = dopisekbtn & " " & btnob2.Text
        If obazabronione Then btnoba.Visible = False
        btnob1.Image = generujobraz(ob1.kolor, ob1.typ)
        btnob2.Image = generujobraz(ob2.kolor, ob2.typ)
    End Sub

    Private Function generujobraz(ByVal kolor As SByte, ByVal typ As obiekt.typobiektu) As Bitmap
        Dim wynik As Bitmap
        Select Case typ
            Case 5, 6, 9, 10
                wynik = New Bitmap(50, 100)
            Case 7, 8, 11, 12
                wynik = New Bitmap(100, 50)
            Case Else
                wynik = New Bitmap(50, 50)
        End Select
        Using gfx As Graphics = Graphics.FromImage(wynik)
            Dim sb As SolidBrush = New SolidBrush(dane.paleta.Item(kolor))
            Select Case typ
                Case obiekt.typobiektu.pelny
                    gfx.FillRectangle(sb, New Rectangle(0, 0, wynik.Size.Width, wynik.Size.Height))
                Case obiekt.typobiektu.skos_NE, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_W_lewy
                    gfx.FillPolygon(sb, {New Point(0, 0), New Point(wynik.Size.Width, 0), New Point(wynik.Size.Width, wynik.Size.Height)})
                Case obiekt.typobiektu.skos_SE, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_W_prawy
                    gfx.FillPolygon(sb, {New Point(wynik.Size.Width, 0), New Point(wynik.Size.Width, wynik.Size.Height), New Point(0, wynik.Size.Height)})
                Case obiekt.typobiektu.skos_SW, obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_E_lewy
                    gfx.FillPolygon(sb, {New Point(0, 0), New Point(wynik.Size.Width, wynik.Size.Height), New Point(0, wynik.Size.Height)})
                Case obiekt.typobiektu.skos_NW, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_S_lewy
                    gfx.FillPolygon(sb, {New Point(0, 0), New Point(wynik.Size.Width, 0), New Point(0, wynik.Size.Height)})
            End Select
        End Using
        Return wynik
    End Function

    Private Sub btnanuluj_Click(sender As Object, e As EventArgs) Handles btnanuluj.Click
        Close()
    End Sub

    Private Sub btnoba_Click(sender As Object, e As EventArgs) Handles btnoba.Click
        wynik = wynikdialog.obaobiekty
        Close()
    End Sub

    Private Sub btnob1_Click(sender As Object, e As EventArgs) Handles btnob1.Click
        wynik = wynikdialog.obiekt1
        Close()
    End Sub

    Private Sub btnob2_Click(sender As Object, e As EventArgs) Handles btnob2.Click
        wynik = wynikdialog.obiekt2
        Close()
    End Sub
End Class
