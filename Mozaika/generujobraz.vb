Public Class generujobraz

    Dim kolortla As Color = Color.White
    Dim kolorsiatka As Color = Color.LightGray

    Private Sub generujobraz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        savedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        karty.SelectTab(0)
        tbrozmiar.Value = 50
        pnltlo.BackColor = kolortla
        pnlsiatka.BackColor = kolorsiatka
    End Sub

    Private Sub pnlsiatka_Click(sender As Object, e As EventArgs) Handles pnlsiatka.Click
        kolordialog.Color = kolorsiatka
        kolordialog.ShowDialog()
        kolorsiatka = kolordialog.Color
        pnlsiatka.BackColor = kolorsiatka
    End Sub

    Private Sub pnltlo_Click(sender As Object, e As MouseEventArgs) Handles pnltlo.Click
        kolordialog.Color = kolortla
        kolordialog.ShowDialog()
        kolortla = kolordialog.Color
        pnltlo.BackColor = kolortla
    End Sub

    Private Sub tbrozmiar_ValueChanged(sender As Object, e As EventArgs) Handles tbrozmiar.ValueChanged
        lblrozmiar.Text = "Przewidywany rozmiar obrazu:" & vbNewLine
        lblrozmiar.Text &= "szerokość: " & dane.rozplanszy.Width & " kwadratów * " & tbrozmiar.Value & "px = " & (dane.rozplanszy.Width * tbrozmiar.Value) & "px" & vbNewLine
        lblrozmiar.Text &= "wysokość: " & dane.rozplanszy.Height & " kwadratów * " & tbrozmiar.Value & "px = " & (dane.rozplanszy.Height * tbrozmiar.Value) & "px" & vbNewLine
    End Sub

    Private Sub chkboxsiatkaza_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxsiatkaza.CheckedChanged
        If sender.Checked Then chkboxsiatkaprzed.Checked = False
    End Sub

    Private Sub chkboxsiatkaprzed_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxsiatkaprzed.CheckedChanged
        If sender.Checked Then chkboxsiatkaza.Checked = False
    End Sub

    Private Sub tbsiatka_ValueChanged(sender As Object, e As EventArgs) Handles tbsiatka.ValueChanged
        lblsiatka.Text = "Grubość siatki: " & tbsiatka.Value & "px"
    End Sub

    Private Sub tbkontur_ValueChanged(sender As Object, e As EventArgs) Handles tbkontur.ValueChanged
        lblkontur.Text = "Gr. konturów: " & tbkontur.Value & "px"
    End Sub

    Private Function margines() As Integer
        If chkboxwsp.Checked Then Return 25 Else Return 0
    End Function

    Private Function getwidth(ByVal ob As obiekt) As Integer
        Select Case ob.typ
            Case obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_S_lewy
                Return tbrozmiar.Value
            Case obiekt.typobiektu.dlugi_W_prawy, obiekt.typobiektu.dlugi_W_lewy, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_E_lewy
                Return tbrozmiar.Value * 2
            Case Else
                Return tbrozmiar.Value
        End Select
    End Function

    Private Function getheight(ByVal ob As obiekt) As Integer
        Select Case ob.typ
            Case obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_S_lewy
                Return tbrozmiar.Value * 2
            Case obiekt.typobiektu.dlugi_W_prawy, obiekt.typobiektu.dlugi_W_lewy, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_E_lewy
                Return tbrozmiar.Value
            Case Else
                Return tbrozmiar.Value
        End Select
    End Function

    Private Function getrecnr(ByVal wsp As Point, ByVal typ As Byte, ByVal roz As Integer) As Rectangle
        Const blok As Byte = 16
        wsp.X *= roz
        wsp.Y *= roz
        wsp.X += margines()
        wsp.Y += margines()
        Select Case typ
            Case 0
                Return New Rectangle(wsp.X + (roz - blok) / 2, wsp.Y + (roz - blok) / 2, blok, blok)
            Case 1, 9, 12
                Return New Rectangle(wsp.X + (roz - blok) - 4, wsp.Y + 4, blok, blok)
            Case 2, 6, 11
                Return New Rectangle(wsp.X + (roz - blok) - 4, wsp.Y + (roz - blok) - 4, blok, blok)
            Case 3, 5, 8
                Return New Rectangle(wsp.X + 4, wsp.Y + (roz - blok) - 4, blok, blok)
            Case 4, 7, 10
                Return New Rectangle(wsp.X + 4, wsp.Y + 4, blok, blok)
        End Select
    End Function

    Private Sub edgedetection(ByVal ob As obiekt, ByRef listawsp As List(Of Point))
        Select Case ob.typ
            Case obiekt.typobiektu.pelny
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 7, {0, 1, 2, 6, 9, 11, 12})
            Case obiekt.typobiektu.skos_NE
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 0, {3})
            Case obiekt.typobiektu.skos_SE
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 0, {4})
            Case obiekt.typobiektu.skos_SW
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 0, {1})
            Case obiekt.typobiektu.skos_NW
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 0, {2})
            Case obiekt.typobiektu.dlugi_N_prawy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {9})
            Case obiekt.typobiektu.dlugi_N_lewy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {10})
            Case obiekt.typobiektu.dlugi_E_prawy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {11})
            Case obiekt.typobiektu.dlugi_E_lewy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {12})
            Case obiekt.typobiektu.dlugi_S_prawy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {5})
            Case obiekt.typobiektu.dlugi_S_lewy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 7, {0, 1, 2, 6, 9, 11, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {6})
            Case obiekt.typobiektu.dlugi_W_prawy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 5, {0, 1, 4, 7, 9, 10, 12})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {7})
            Case obiekt.typobiektu.dlugi_W_lewy
                czyjesttamciagdalszy(listawsp, ob, ob.wsp, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 1, {0, 2, 3, 5, 6, 8, 11})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 3, {0, 3, 4, 5, 7, 8, 10})
                czyjesttamciagdalszy(listawsp, ob, ob.wsp2, 0, {8})
        End Select
    End Sub

    Private Sub czyjesttamciagdalszy(ByRef lista As List(Of Point), ByVal ob As obiekt, ByVal wspob As Point, ByVal kier As SByte, ByVal poprtypy() As Byte)
        Dim szukane As Point = obliczwsp(wspob, kier)
        Dim flaga As Boolean = False
        For Each i As obiekt In dane.zawartosc
            If (i.wsp.Equals(szukane) Or i.wsp2.Equals(szukane)) AndAlso i.kolor = ob.kolor Then
                For Each popr As Byte In poprtypy
                    If i.typ = popr Then
                        flaga = True
                        Exit For
                    End If
                Next
            End If
            If flaga Then Exit For
        Next
        If Not flaga Then
            Dim roz As Integer = tbrozmiar.Value
            Dim x As Integer = wspob.X * roz + margines()
            Dim y As Integer = wspob.Y * roz + margines()
            Select Case kier
                Case 1
                    lista.Add(New Point(x, y))
                    lista.Add(New Point(x + roz, y))
                Case 3
                    lista.Add(New Point(x + roz, y))
                    lista.Add(New Point(x + roz, y + roz))
                Case 5
                    lista.Add(New Point(x + roz, y + roz))
                    lista.Add(New Point(x, y + roz))
                Case 7
                    lista.Add(New Point(x, y + roz))
                    lista.Add(New Point(x, y))
                Case 0
                    Select Case ob.typ
                        Case 1, 9, 12, 2, 6, 11
                            If ob.typ = 1 Then lista.Add(New Point(x + roz, y + roz))
                            If ob.typ = 2 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 3 Then lista.Add(New Point(x + roz, y + roz))
                            If ob.typ = 4 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 5 Then lista.Add(New Point(x + roz, y + roz * 2))
                            If ob.typ = 6 Then lista.Add(New Point(x, y + roz * 2))
                            If ob.typ = 7 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 8 Then lista.Add(New Point(x + roz * 2, y + roz))
                            If ob.typ = 9 Then lista.Add(New Point(x + roz, y + roz * 2))
                            If ob.typ = 10 Then lista.Add(New Point(x, y + roz * 2))
                            If ob.typ = 11 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 12 Then lista.Add(New Point(x + roz * 2, y + roz))
                        Case Else
                            Select Case ob.typ
                                Case 1, 3, 5, 8, 9, 12
                                    lista.Add(New Point(x, y))
                                Case 2, 4, 6, 7, 10, 11
                                    lista.Add(New Point(x + roz, y))
                            End Select
                    End Select
                    Select Case ob.typ
                        Case 1, 9, 12, 2, 6, 11
                            Select Case ob.typ
                                Case 1, 3, 5, 8, 9, 12
                                    lista.Add(New Point(x, y))
                                Case 2, 4, 6, 7, 10, 11
                                    lista.Add(New Point(x + roz, y))
                            End Select
                        Case Else
                            If ob.typ = 1 Then lista.Add(New Point(x + roz, y + roz))
                            If ob.typ = 2 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 3 Then lista.Add(New Point(x + roz, y + roz))
                            If ob.typ = 4 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 5 Then lista.Add(New Point(x + roz, y + roz * 2))
                            If ob.typ = 6 Then lista.Add(New Point(x, y + roz * 2))
                            If ob.typ = 7 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 8 Then lista.Add(New Point(x + roz * 2, y + roz))
                            If ob.typ = 9 Then lista.Add(New Point(x + roz, y + roz * 2))
                            If ob.typ = 10 Then lista.Add(New Point(x, y + roz * 2))
                            If ob.typ = 11 Then lista.Add(New Point(x, y + roz))
                            If ob.typ = 12 Then lista.Add(New Point(x + roz * 2, y + roz))
                    End Select
                    Select Case ob.typ
                        Case 5, 6
                            lista(lista.Count - 2) = New Point(lista(lista.Count - 2).X, lista(lista.Count - 2).Y - roz)
                            lista(lista.Count - 1) = New Point(lista(lista.Count - 1).X, lista(lista.Count - 1).Y - roz)
                        Case 7
                            lista(lista.Count - 2) = New Point(lista(lista.Count - 2).X + roz, lista(lista.Count - 2).Y)
                        Case 11
                            lista(lista.Count - 2) = New Point(lista(lista.Count - 2).X - roz, lista(lista.Count - 2).Y)
                        Case 12
                            lista(lista.Count - 2) = New Point(lista(lista.Count - 2).X - roz, lista(lista.Count - 2).Y)
                            lista(lista.Count - 1) = New Point(lista(lista.Count - 1).X - roz, lista(lista.Count - 1).Y)
                    End Select
            End Select
        End If
    End Sub

    Private Sub btngeneruj_Click(sender As Object, e As EventArgs) Handles btngeneruj.Click
        savedialog.FileName = ""
        savedialog.ShowDialog()
        If savedialog.FileName = "" Then Exit Sub
        If Not tryb1.Checked Then
            If tbkontur.Value * 4 >= tbrozmiar.Value Then
                MsgBox("Grubość konturu nie może być większa niż 1/4 rozmiaru pojedynczego kwadratu!", MsgBoxStyle.Exclamation, "Mozaika")
                Exit Sub
            End If
        End If
        If chkboxnumer.Checked Then
            If tbrozmiar.Value < 40 Then
                MsgBox("Wyświetlanie numerów kolorów potrzebuje kwadratów o minimalnym rozmiarze 40 pikseli! ", MsgBoxStyle.Exclamation, "Mozaika")
                Exit Sub
            End If
        End If
        If chkboxwsp.Checked Then
            If tbrozmiar.Value < 20 Then
                MsgBox("Wyświetlanie linijek ze współrzędnymi wymaga rozmiaru kwadratu minimum 20 pikseli! ", MsgBoxStyle.Exclamation, "Mozaika")
                Exit Sub
            End If
        End If

        Dim PENsiatka As Pen = New Pen(kolorsiatka, tbsiatka.Value)
        Dim FONTwsp As Font = New Font("Segoe UI", 10)
        Dim FONTnr As Font = New Font("Segoe UI", 7)
        Dim sfcenter As StringFormat = New StringFormat()
        sfcenter.Alignment = StringAlignment.Center
        sfcenter.LineAlignment = StringAlignment.Center

        Dim roz As Integer = tbrozmiar.Value

        Dim img As Bitmap = New Bitmap(dane.rozplanszy.Width * tbrozmiar.Value + margines(), dane.rozplanszy.Height * tbrozmiar.Value + margines())
        Dim gfx As Graphics = Graphics.FromImage(img)

        If chkboxaa.Checked Then gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        gfx.Clear(IIf(chkboxtransparent.Checked, Color.Transparent, kolortla))

        'siatka za
        If chkboxsiatkaza.Checked Then
            For x As Integer = margines() To img.Size.Width Step roz
                gfx.DrawLine(PENsiatka, New Point(x, 0), New Point(x, img.Size.Height))
            Next
            For y As Integer = margines() To img.Size.Height Step roz
                gfx.DrawLine(PENsiatka, New Point(0, y), New Point(img.Size.Width, y))
            Next
        End If

        'obiekty
        If tryb1.Checked Then
            'pelne kolory
            For Each i As obiekt In dane.zawartosc
                Dim sb As SolidBrush = New SolidBrush(dane.paleta(i.kolor))
                Dim x As Integer = i.wsp.X * roz + margines()
                Dim y As Integer = i.wsp.Y * roz + margines()
                If i.typ > 4 Then
                    x = Math.Min(i.wsp.X, i.wsp2.X) * roz + margines()
                    y = Math.Min(i.wsp.Y, i.wsp2.Y) * roz + margines()
                End If
                Select Case i.typ
                    Case obiekt.typobiektu.pelny
                        gfx.FillRectangle(sb, New Rectangle(x, y, roz, roz))
                    Case obiekt.typobiektu.skos_NE, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_W_lewy
                        gfx.FillPolygon(sb, {New Point(x, y), New Point(x + getwidth(i), y), New Point(x + getwidth(i), y + getheight(i))})
                    Case obiekt.typobiektu.skos_SE, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_W_prawy
                        gfx.FillPolygon(sb, {New Point(x + getwidth(i), y), New Point(x + getwidth(i), y + getheight(i)), New Point(x, y + getheight(i))})
                    Case obiekt.typobiektu.skos_SW, obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_E_lewy
                        gfx.FillPolygon(sb, {New Point(x + getwidth(i), y + getheight(i)), New Point(x, y + getheight(i)), New Point(x, y)})
                    Case obiekt.typobiektu.skos_NW, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_S_lewy
                        gfx.FillPolygon(sb, {New Point(x, y + getheight(i)), New Point(x, y), New Point(x + getwidth(i), y)})
                End Select
            Next
        End If
        If tryb2.Checked Or tryb3.Checked Then
            'kontury
            For Each i As obiekt In dane.zawartosc
                Dim pen As Pen
                If tryb2.Checked Then
                    pen = New Pen(Color.Black, tbkontur.Value)
                Else
                    pen = New Pen(dane.paleta(i.kolor), tbkontur.Value)
                End If
                pen.Alignment = Drawing2D.PenAlignment.Inset
                Dim x As Integer = i.wsp.X * roz + margines()
                Dim y As Integer = i.wsp.Y * roz + margines()
                If i.typ > 4 Then
                    x = Math.Min(i.wsp.X, i.wsp2.X) * roz + margines()
                    y = Math.Min(i.wsp.Y, i.wsp2.Y) * roz + margines()
                End If
                Select Case i.typ
                    Case obiekt.typobiektu.pelny
                        gfx.DrawRectangle(pen, New Rectangle(x, y, roz, roz))
                    Case obiekt.typobiektu.skos_NE, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_W_lewy
                        gfx.DrawPolygon(pen, {New Point(x, y), New Point(x + getwidth(i), y), New Point(x + getwidth(i), y + getheight(i))})
                    Case obiekt.typobiektu.skos_SE, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_W_prawy
                        gfx.DrawPolygon(pen, {New Point(x + getwidth(i), y), New Point(x + getwidth(i), y + getheight(i)), New Point(x, y + getheight(i))})
                    Case obiekt.typobiektu.skos_SW, obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_E_lewy
                        gfx.DrawPolygon(pen, {New Point(x + getwidth(i), y + getheight(i)), New Point(x, y + getheight(i)), New Point(x, y)})
                    Case obiekt.typobiektu.skos_NW, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_S_lewy
                        gfx.DrawPolygon(pen, {New Point(x, y + getheight(i)), New Point(x, y), New Point(x + getwidth(i), y)})
                End Select
            Next
        End If
        If tryb4.Checked Or tryb5.Checked Then
            'edge detection
            Dim tablicakrawedzi(dane.paleta.Count - 1) As List(Of Point)
            For i As Byte = 0 To tablicakrawedzi.Count - 1 Step 1
                tablicakrawedzi(i) = New List(Of Point)
            Next
            For Each i As obiekt In dane.zawartosc
                edgedetection(i, tablicakrawedzi(i.kolor))
            Next
            For i As Byte = 0 To dane.paleta.Count - 1 Step 1
                Dim pen As Pen
                If tryb4.Checked Then
                    pen = New Pen(Color.Black, tbkontur.Value)
                Else
                    pen = New Pen(dane.paleta(i), tbkontur.Value)
                End If
                pen.Alignment = Drawing2D.PenAlignment.Inset

                If tablicakrawedzi(i).Count > 0 Then
                    Dim listasciezek As List(Of List(Of Point)) = New List(Of List(Of Point))
                    Dim posortowana As List(Of Point) = New List(Of Point)
                    posortowana.Add(tablicakrawedzi(i)(0))
                    posortowana.Add(tablicakrawedzi(i)(1))
                    Dim szukanewsp As Point = tablicakrawedzi(i)(1)
                    Do
                        If szukanewsp.Equals(posortowana(0)) Then
                            listasciezek.Add(posortowana)
                            For Each pos As Point In posortowana
                                tablicakrawedzi(i).Remove(pos)
                            Next
                            If tablicakrawedzi(i).Count = 0 Then Exit Do
                            posortowana = New List(Of Point)
                            posortowana.Add(tablicakrawedzi(i)(0))
                            posortowana.Add(tablicakrawedzi(i)(1))
                            szukanewsp = tablicakrawedzi(i)(1)
                        End If
                        For lp As Integer = 2 To tablicakrawedzi(i).Count - 1 Step 2
                            If tablicakrawedzi(i)(lp).Equals(szukanewsp) Then
                                posortowana.Add(tablicakrawedzi(i)(lp))
                                posortowana.Add(tablicakrawedzi(i)(lp + 1))
                                szukanewsp = tablicakrawedzi(i)(lp + 1)
                                Exit For
                            End If
                        Next
                    Loop
                    For Each sciezka As List(Of Point) In listasciezek
                        gfx.DrawPolygon(pen, sciezka.ToArray())
                    Next
                End If
            Next
        End If

        'siatka przed
        If chkboxsiatkaprzed.Checked Then
            For x As Integer = margines() To img.Size.Width Step roz
                gfx.DrawLine(PENsiatka, New Point(x, 0), New Point(x, img.Size.Height))
            Next
            For y As Integer = margines() To img.Size.Height Step roz
                gfx.DrawLine(PENsiatka, New Point(0, y), New Point(img.Size.Width, y))
            Next
        End If

        'numery kolorow
        If chkboxnumer.Checked Then
            For Each i As obiekt In dane.zawartosc
                Dim wsp As Rectangle = getrecnr(IIf(i.typ > 4, i.wsp2, i.wsp), i.typ, roz)
                gfx.FillRectangle(Brushes.White, wsp)
                gfx.DrawRectangle(New Pen(Brushes.Black, 1), New Rectangle(wsp.X, wsp.Y, wsp.Width - 1, wsp.Height - 1))
                gfx.DrawString(i.kolor + 1, FONTnr, Brushes.Black, wsp, sfcenter)
            Next
        End If

        'wspolrzedne
        If chkboxwsp.Checked Then
            gfx.FillRectangle(Brushes.LightGray, New Rectangle(0, 0, img.Size.Width, 25))
            gfx.FillRectangle(Brushes.LightGray, New Rectangle(0, 0, 25, img.Size.Height))
            For x As Integer = 25 To img.Size.Width Step roz
                Dim i As Integer = (x - 25) / roz
                gfx.DrawLine(PENsiatka, New Point(x, 0), New Point(x, 25))
                gfx.DrawString(i, FONTwsp, Brushes.Black, New Rectangle(x, 0, roz, 25), sfcenter)
            Next
            For y As Integer = 25 To img.Size.Height Step roz
                Dim i As Integer = (y - 25) / roz
                gfx.DrawLine(PENsiatka, New Point(0, y), New Point(25, y))
                gfx.DrawString(i, FONTwsp, Brushes.Black, New Rectangle(0, y, 25, roz), sfcenter)
            Next
        End If

        'zapis
        img.Save(savedialog.FileName, Imaging.ImageFormat.Png)
        If MsgBox("Obraz został pomyślnie wygenerowany!" & vbNewLine & "Czy chcesz go otworzyć?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then
            Process.Start(savedialog.FileName)
        End If
    End Sub
End Class