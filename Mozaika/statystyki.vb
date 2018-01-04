Public Class statystyki

    Dim nrk As Byte = 0
    Dim wprojekcie As Integer = 0

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

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        nrk -= 1
        odswiez(nrk)
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        nrk += 1
        odswiez(nrk)
    End Sub

    Private Sub statystyki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Byte = 0 To dane.paleta.Count - 1 Step 1
            odswiez(i)
            wprojekcie += lblpelnych.Text
        Next
        odswiez(0)
    End Sub

    Private Sub odswiez(ByVal kolor As Byte)
        lblnr.Text = "Kolor: " & (nrk + 1) & " / " & dane.paleta.Count
        If nrk > 0 Then btnprev.Visible = True Else btnprev.Visible = False
        If nrk + 1 < dane.paleta.Count Then btnnext.Visible = True Else btnnext.Visible = False
        imgpelny.Image = generujobraz(nrk, 0)
        imgskosne.Image = generujobraz(nrk, 1)
        imgskosse.Image = generujobraz(nrk, 2)
        imgskossw.Image = generujobraz(nrk, 3)
        imgskosnw.Image = generujobraz(nrk, 4)
        imgnpr.Image = generujobraz(nrk, 5)
        imgnle.Image = generujobraz(nrk, 6)
        imgepr.Image = generujobraz(nrk, 7)
        imgele.Image = generujobraz(nrk, 8)
        imgspr.Image = generujobraz(nrk, 9)
        imgsle.Image = generujobraz(nrk, 10)
        imgwpr.Image = generujobraz(nrk, 11)
        imgwle.Image = generujobraz(nrk, 12)
        imgpelne.Image = generujobraz(nrk, 0)
        imgskosy.Image = generujobraz(nrk, 1)
        imgprawy.Image = generujobraz(nrk, 5)
        imglewy.Image = generujobraz(nrk, 6)
        Dim pelny, ne, se, sw, nw, npr, nle, spr, sle, epr, ele, wpr, wle As Integer
        For y As Integer = 0 To dane.rozplanszy.Height - 1 Step 1
            For x As Integer = 0 To dane.rozplanszy.Width - 1 Step 1
                Dim wsp As Point = New Point(x, y)
                Dim w As List(Of obiekt) = New List(Of obiekt)
                For Each i As obiekt In dane.zawartosc
                    If i.kolor = kolor Then
                        If i.typ > 4 Then
                            If New Point(Math.Min(i.wsp.X, i.wsp2.X), Math.Min(i.wsp.Y, i.wsp2.Y)) = wsp Then w.Add(i)
                        Else
                            If i.wsp = wsp Then w.Add(i)
                        End If
                    End If
                Next
                For Each i As obiekt In w
                    Select Case i.typ
                        Case obiekt.typobiektu.pelny
                            pelny += 1
                        Case obiekt.typobiektu.skos_NE
                            ne += 1
                        Case obiekt.typobiektu.skos_SE
                            se += 1
                        Case obiekt.typobiektu.skos_SW
                            sw += 1
                        Case obiekt.typobiektu.skos_NW
                            nw += 1
                        Case obiekt.typobiektu.dlugi_N_prawy
                            npr += 1
                        Case obiekt.typobiektu.dlugi_N_lewy
                            nle += 1
                        Case obiekt.typobiektu.dlugi_E_prawy
                            epr += 1
                        Case obiekt.typobiektu.dlugi_E_lewy
                            ele += 1
                        Case obiekt.typobiektu.dlugi_S_prawy
                            spr += 1
                        Case obiekt.typobiektu.dlugi_S_lewy
                            sle += 1
                        Case obiekt.typobiektu.dlugi_W_prawy
                            wpr += 1
                        Case obiekt.typobiektu.dlugi_W_lewy
                            wle += 1
                    End Select
                Next
            Next
        Next
        lblpelny.Text = pelny
        lblskosne.Text = ne
        lblskosse.Text = se
        lblskossw.Text = sw
        lblskosnw.Text = nw
        lblnpr.Text = npr
        lblnle.Text = nle
        lblepr.Text = epr
        lblele.Text = ele
        lblspr.Text = spr
        lblsle.Text = sle
        lblwpr.Text = wpr
        lblwle.Text = wle
        lblpelne.Text = pelny
        lblskosy.Text = (ne + se + sw + nw)
        lblprawy.Text = (npr + epr + spr + wpr)
        lbllewy.Text = (nle + ele + sle + wle)
        lblpelnych.Text = pelny + (CInt(lblskosy.Text) \ 2 + IIf(CInt(lblskosy.Text) Mod 2 = 0, 0, 1)) + (CInt(lblprawy.Text) \ 2 + IIf(CInt(lblprawy.Text) Mod 2 = 0, 0, 1)) * 2 + (CInt(lbllewy.Text) \ 2 + IIf(CInt(lbllewy.Text) Mod 2 = 0, 0, 1)) * 2
        lblpelnychprojekt.Text = wprojekcie
    End Sub
End Class