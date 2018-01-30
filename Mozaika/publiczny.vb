Module publiczny

    Public domyslnykolor As Color = Color.DeepSkyBlue

    Public MODshift As Boolean = False
    Public MODctrl As Boolean = False

    Public dane As projekt = New projekt()
    Public undo As Stack(Of String) = New Stack(Of String)
    Public redo As Stack(Of String) = New Stack(Of String)

    Public Sub ladujprojekt(Optional ByVal usunhistorie As Boolean = True)
        If dane.wybrkolor >= dane.paleta.Count Then dane.wybrkolor = dane.paleta.Count - 1
        main.przeladujpalete()
        Select Case dane.wybrnarzedzie
            Case 0
                main.zmiennarzedzie(main.menuzazn, New EventArgs())
            Case 1
                main.zmiennarzedzie(main.menurozdzka, New EventArgs())
            Case 2
                main.zmiennarzedzie(main.menukolorowanie, New EventArgs())
            Case 3
                main.zmiennarzedzie(main.menurysuj, New EventArgs())
            Case 4
                main.zmiennarzedzie(main.menustempel, New EventArgs())
            Case 5
                main.zmiennarzedzie(main.menugumka, New EventArgs())
            Case 6
                main.zmiennarzedzie(main.menuzakraplacz, New EventArgs())
        End Select
        If dane.siatka Then main.menusiatka.Checked = True Else main.menusiatka.Checked = False
        If dane.wspolrzedne Then main.menuwsp.Checked = True Else main.menuwsp.Checked = False
        If dane.kolizja Then main.menukolizja.Checked = True Else main.menukolizja.Checked = False
        If dane.antialias Then main.menuaa.Checked = True Else main.menuaa.Checked = False
        If dane.antialias Then main.gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias Else main.gfx.SmoothingMode = Drawing2D.SmoothingMode.None
        If dane.filepath = "" Then
            main.Text = "Bez nazwy - " & main.tytul
        Else
            main.Text = New IO.FileInfo(dane.filepath).Name.Substring(0, New IO.FileInfo(dane.filepath).Name.LastIndexOf(".")) & " - " & main.tytul
            If dane.zmiany Then main.Text = "* " & main.Text
        End If
        If usunhistorie Then
            undo.Clear()
            redo.Clear()
            main.menucofnij.Enabled = False
            main.menupowtorz.Enabled = False
        End If
        If main.akt.Enabled Then main.rysuj()
    End Sub

    Public Sub wprowadzonozmiany()
        dane.zmiany = True
        If Not main.Text.Substring(0, 2) = "* " Then main.Text = "* " & main.Text
    End Sub

    Public Sub cofinj()
        If undo.Count = 0 Then
            main.menucofnij.Enabled = False
        Else
            'zapisz do redo
            Dim sciezkaredo As String = IO.Path.GetTempPath() & "\MOZAIKA-" & New Guid().NewGuid().ToString() & ".moz"
            main.serializuj(dane, sciezkaredo)
            redo.Push(sciezkaredo)
            main.menupowtorz.Enabled = True
            'przywroc z undo
            Dim sciezka As String = undo.Pop()
            If undo.Count = 0 Then main.menucofnij.Enabled = False
            dane = Nothing
            dane = main.deserializuj(sciezka)
            IO.File.Delete(sciezka)
            ladujprojekt(False)
            wprowadzonozmiany()
        End If
    End Sub

    Public Sub powtorz()
        If redo.Count = 0 Then
            main.menupowtorz.Enabled = False
        Else
            'zapisz do undo
            Dim sciezkaundo As String = IO.Path.GetTempPath() & "\MOZAIKA-" & New Guid().NewGuid().ToString() & ".moz"
            main.serializuj(dane, sciezkaundo)
            undo.Push(sciezkaundo)
            main.menucofnij.Enabled = True
            'przywroc z redo
            Dim sciezka As String = redo.Pop()
            If redo.Count = 0 Then main.menupowtorz.Enabled = False
            dane = Nothing
            dane = main.deserializuj(sciezka)
            IO.File.Delete(sciezka)
            ladujprojekt(False)
            wprowadzonozmiany()
        End If
    End Sub

    Public Function getzazn() As List(Of obiekt)
        Dim w As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.zazn Then w.Add(i)
        Next
        Return w
    End Function

    Public Sub usunzazn()
        For Each i As obiekt In dane.zawartosc
            i.zazn = False
        Next
    End Sub

    Public Function obliczwsp(ByVal wsp As Point, ByVal kierunek As Byte) As Point
        Select Case kierunek
            Case 1 'N
                wsp.Y -= 1
            Case 2 'NE
                wsp.X += 1
                wsp.Y -= 1
            Case 3 'E
                wsp.X += 1
            Case 4 'SE
                wsp.X += 1
                wsp.Y += 1
            Case 5 'S
                wsp.Y += 1
            Case 6 'SW
                wsp.X -= 1
                wsp.Y += 1
            Case 7 'W
                wsp.X -= 1
            Case 8 'NW
                wsp.X -= 1
                wsp.Y -= 1
        End Select
        Return wsp
    End Function

    Public Function obslugakolizji(ByVal obiekt As obiekt, ByVal onlyscan As Boolean) As Boolean
        Dim wynik1 As Boolean = False
        Dim wynik2 As Boolean = False
        Select Case obiekt.typ
            Case 0
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {}, {})
            Case 1
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {3, 5, 8}, {})
            Case 2
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {4, 7, 10}, {})
            Case 3
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {1, 9, 12}, {})
            Case 4
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {2, 6, 11}, {})
            Case 5
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {1, 9, 12}, {9})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {9}, {})
            Case 6
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {4, 10, 7}, {10})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {10}, {})
            Case 7
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {2, 11, 6}, {11})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {11}, {})
            Case 8
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {1, 12, 9}, {12})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {12}, {})
            Case 9
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {3, 5, 8}, {5})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {5}, {})
            Case 10
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {2, 6, 11}, {6})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {6}, {})
            Case 11
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {4, 7, 10}, {7})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {7}, {})
            Case 12
                wynik1 = usunprzeszkody(onlyscan, obiekt.wsp, {3, 8, 5}, {8})
                wynik2 = usunprzeszkody(onlyscan, obiekt.wsp2, {8}, {})
        End Select
        If Not wynik1 AndAlso wynik2 Then wynik1 = True
        Return wynik1
    End Function

    Public Sub dodajzazn(ByVal wsp As Point, ByVal ustawtrue As Boolean)
        Dim w As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.wsp = wsp Then
                w.Add(i)
            Else
                If i.typ > 4 AndAlso i.wsp2 = wsp Then w.Add(i)
            End If
        Next
        If w.Count = 1 Then
            w(0).zazn = IIf(ustawtrue, True, Not w(0).zazn)
        End If
        If w.Count = 2 Then
            dialogwybor.zaladuj("zaznaczyć", "Zaznacz", False, w(0), w(1))
            dialogwybor.ShowDialog()
            Select Case dialogwybor.wynik
                Case dialogwybor.wynikdialog.obaobiekty
                    w(0).zazn = IIf(ustawtrue, True, Not w(0).zazn)
                    w(1).zazn = IIf(ustawtrue, True, Not w(1).zazn)
                Case dialogwybor.wynikdialog.obiekt1
                    w(0).zazn = IIf(ustawtrue, True, Not w(0).zazn)
                Case dialogwybor.wynikdialog.obiekt2
                    w(1).zazn = IIf(ustawtrue, True, Not w(1).zazn)
            End Select
            dialogwybor.Close()
        End If
    End Sub

    Public Sub dodajobszarzazn(ByVal wsp2 As Point, ByVal usunzaznaczenia As Boolean)
        Dim listazazn As List(Of obiekt) = getzazn()
        Dim wsp1 As Point
        If listazazn.Count = 0 Then
            wsp1 = New Point(0, 0)
        Else
            If listazazn(listazazn.Count - 1).typ > 4 Then
                wsp1 = New Point(Math.Min(listazazn(listazazn.Count - 1).wsp.X, listazazn(listazazn.Count - 1).wsp2.X), Math.Min(listazazn(listazazn.Count - 1).wsp.Y, listazazn(listazazn.Count - 1).wsp2.Y))
            Else
                wsp1 = listazazn(listazazn.Count - 1).wsp
            End If
        End If
        Dim wspL, wspP As Point
        wspL = New Point(Math.Min(wsp1.X, wsp2.X), Math.Min(wsp1.Y, wsp2.Y))
        wspP = New Point(Math.Max(wsp1.X, wsp2.X), Math.Max(wsp1.Y, wsp2.Y))
        If usunzaznaczenia Then usunzazn()
        For Each i As obiekt In dane.zawartosc
            Dim wspob As Point
            If i.typ > 4 Then
                wspob = New Point(Math.Min(i.wsp.X, i.wsp2.X), Math.Min(i.wsp.Y, i.wsp2.Y))
            Else
                wspob = i.wsp
            End If
            If wspob.X >= wspL.X AndAlso wspob.X <= wspP.X AndAlso wspob.Y >= wspL.Y AndAlso wspob.Y <= wspP.Y Then
                i.zazn = True
            End If
        Next
    End Sub

    Public Function usunprzeszkody(ByVal deleteoff As Boolean, ByVal wsp As Point, ByVal zezwolone1() As obiekt.typobiektu, ByVal zezwolone2() As obiekt.typobiektu)
        If dane.zawartosc.Count = 0 Then Return False
        Dim i As Integer = 0
        Do
            Dim flaga As Boolean = False
            If dane.zawartosc(i).wsp.Equals(wsp) Then
                flaga = True
                For Each o As obiekt.typobiektu In zezwolone1
                    If dane.zawartosc(i).typ = o Then
                        flaga = False
                        Exit For
                    End If
                Next
            End If
            If dane.zawartosc(i).typ > 4 Then
                If dane.zawartosc(i).wsp2.Equals(wsp) Then
                    flaga = True
                    For Each o As obiekt.typobiektu In zezwolone2
                        If dane.zawartosc(i).typ = o Then
                            flaga = False
                            Exit For
                        End If
                    Next
                End If
            End If
            If flaga Then
                If deleteoff Then
                    Return True
                Else
                    dane.zawartosc.RemoveAt(i)
                End If
            Else
                i += 1
            End If
            If i >= dane.zawartosc.Count Then Exit Do
        Loop
        Return False
    End Function

    Public Sub usuntenobiekt(ByVal wsp As Point)
        Dim w As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.wsp = wsp Then
                w.Add(i)
            Else
                If i.typ > 4 AndAlso i.wsp2 = wsp Then w.Add(i)
            End If
        Next
        If w.Count = 1 Then
            If w(0) Is dane.OSTobiekt Then dane.OSTobiekt = Nothing
            dane.zawartosc.Remove(w(0))
        End If
        If w.Count = 2 Then
            dialogwybor.zaladuj("usunąć", "Usuń", False, w(0), w(1))
            dialogwybor.ShowDialog()
            Select Case dialogwybor.wynik
                Case dialogwybor.wynikdialog.obaobiekty
                    If w(0) Is dane.OSTobiekt Then dane.OSTobiekt = Nothing
                    dane.zawartosc.Remove(w(0))
                    If w(1) Is dane.OSTobiekt Then dane.OSTobiekt = Nothing
                    dane.zawartosc.Remove(w(1))
                Case dialogwybor.wynikdialog.obiekt1
                    If w(0) Is dane.OSTobiekt Then dane.OSTobiekt = Nothing
                    dane.zawartosc.Remove(w(0))
                Case dialogwybor.wynikdialog.obiekt2
                    If w(1) Is dane.OSTobiekt Then dane.OSTobiekt = Nothing
                    dane.zawartosc.Remove(w(1))
            End Select
            dialogwybor.Close()
        End If
    End Sub

    Public Sub zmienkolor(ByVal wsp As Point, ByVal kolor As SByte, ByVal calezaznaczenie As Boolean)
        If calezaznaczenie Then
            For Each i As obiekt In getzazn()
                i.kolor = kolor
            Next
            usunzazn()
        Else
            Dim w As List(Of obiekt) = New List(Of obiekt)
            For Each i As obiekt In dane.zawartosc
                If i.wsp = wsp Then
                    w.Add(i)
                Else
                    If i.typ > 4 AndAlso i.wsp2 = wsp Then w.Add(i)
                End If
            Next
            If w.Count = 1 Then
                w(0).kolor = kolor
                w(0).zazn = False
            End If
            If w.Count = 2 Then
                dialogwybor.zaladuj("pokolorować", "Pokoloruj", False, w(0), w(1))
                dialogwybor.ShowDialog()
                Select Case dialogwybor.wynik
                    Case dialogwybor.wynikdialog.obaobiekty
                        w(0).kolor = kolor
                        w(0).zazn = False
                        w(1).kolor = kolor
                        w(1).zazn = False
                    Case dialogwybor.wynikdialog.obiekt1
                        w(0).kolor = kolor
                        w(0).zazn = False
                    Case dialogwybor.wynikdialog.obiekt2
                        w(1).kolor = kolor
                        w(1).zazn = False
                End Select
                dialogwybor.Close()
            End If
        End If
    End Sub

    Public Sub przelacznatenkolor(ByVal wsp As Point)
        Dim w As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.wsp = wsp Then
                w.Add(i)
            Else
                If i.typ > 4 AndAlso i.wsp2 = wsp Then w.Add(i)
            End If
        Next
        If w.Count = 1 Then
            main.zmienkolor(w(0).kolor)
        End If
        If w.Count = 2 Then
            dialogwybor.zaladuj("spróbkować", "Spróbkuj", True, w(0), w(1))
            dialogwybor.ShowDialog()
            Select Case dialogwybor.wynik
                Case dialogwybor.wynikdialog.obiekt1
                    main.zmienkolor(w(0).kolor)
                Case dialogwybor.wynikdialog.obiekt2
                    main.zmienkolor(w(1).kolor)
            End Select
            dialogwybor.Close()
        End If
    End Sub

    Public Sub duplikujobiekt(ByVal wsp As Point)
        If dane.OSTobiekt Is Nothing Then
            MsgBox("Brak ostatniego obiektu do duplikowania!", MsgBoxStyle.Information, "Duplikacja obiektu")
        Else
            dodajklon(wsp)
        End If
    End Sub

    Public Sub dodajklon(ByVal wsp As Point)
        Dim ob As obiekt = New obiekt(wsp, 0, 0, False, Nothing, 0, 0)
        obslugakolizji(ob, False)
        dane.OSTobiekt = ob
        dane.zawartosc.Add(ob)
    End Sub

    Public Sub dodajobiekt(ByVal wsp As Point, ByVal barwa As Byte, ByVal kier As Byte)
        Dim ob As obiekt = New obiekt(wsp, barwa, kier, True, Nothing, 0, 0)
        obslugakolizji(ob, False)
        dane.OSTobiekt = ob
        dane.zawartosc.Add(ob)
    End Sub

    Public Sub duplikujobszarem(ByVal wsp2 As Point)
        If dane.OSTobiekt Is Nothing Then
            MsgBox("Brak ostatniego obiektu do duplikowania!", MsgBoxStyle.Information, "Duplikacja obiektu")
        Else
            Dim wsp1 As Point
            If dane.OSTobiekt.typ > 4 Then
                wsp1 = New Point(Math.Min(dane.OSTobiekt.wsp.X, dane.OSTobiekt.wsp2.X), Math.Min(dane.OSTobiekt.wsp.Y, dane.OSTobiekt.wsp2.Y))
            Else
                wsp1 = dane.OSTobiekt.wsp
            End If
            Dim wspL, wspP As Point
            wspL = New Point(Math.Min(wsp1.X, wsp2.X), Math.Min(wsp1.Y, wsp2.Y))
            wspP = New Point(Math.Max(wsp1.X, wsp2.X), Math.Max(wsp1.Y, wsp2.Y))
            For x As Integer = wspL.X To wspP.X Step calculatestep(True, dane.OSTobiekt.typ)
                For y As Integer = wspL.Y To wspP.Y Step calculatestep(False, dane.OSTobiekt.typ)
                    dodajklon(New Point(x, y))
                Next
            Next
        End If
    End Sub

    Private Function calculatestep(ByVal x As Boolean, ByVal typ As obiekt.typobiektu) As Byte
        If x Then
            Select Case typ
                Case obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_E_lewy, obiekt.typobiektu.dlugi_W_prawy, obiekt.typobiektu.dlugi_W_lewy
                    Return 2
                Case Else
                    Return 1
            End Select
        Else
            Select Case typ
                Case obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_S_lewy
                    Return 2
                Case Else
                    Return 1
            End Select
        End If
    End Function

    Public Sub quickontop(ByVal path As String)
        Dim l As List(Of String) = New List(Of String)
        If Not My.Settings.q1 = path Then l.Add(My.Settings.q1)
        If Not My.Settings.q2 = path Then l.Add(My.Settings.q2)
        If Not My.Settings.q3 = path Then l.Add(My.Settings.q3)
        If Not My.Settings.q4 = path Then l.Add(My.Settings.q4)
        l.Insert(0, path)
        zapiszquick(l)
    End Sub

    Public Sub quickdelete(ByVal path As String)
        Dim l As List(Of String) = New List(Of String)
        If Not My.Settings.q1 = path Then l.Add(My.Settings.q1)
        If Not My.Settings.q2 = path Then l.Add(My.Settings.q2)
        If Not My.Settings.q3 = path Then l.Add(My.Settings.q3)
        If Not My.Settings.q4 = path Then l.Add(My.Settings.q4)
        zapiszquick(l)
    End Sub

    Private Sub zapiszquick(ByVal lista As List(Of String))
        My.Settings.q1 = ""
        My.Settings.q2 = ""
        My.Settings.q3 = ""
        My.Settings.q4 = ""
        If lista.Count > 0 Then My.Settings.q1 = lista(0)
        If lista.Count > 1 Then My.Settings.q2 = lista(1)
        If lista.Count > 2 Then My.Settings.q3 = lista(2)
        If lista.Count > 3 Then My.Settings.q4 = lista(3)
        My.Settings.Save()
    End Sub

    Public Sub rozdzka(ByVal wsp As Point, ByVal negacjazazn As Boolean, ByVal calykolor As Boolean)
        Dim initob As obiekt = Nothing
        Dim w As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.wsp = wsp Then
                w.Add(i)
            Else
                If i.typ > 4 AndAlso i.wsp2 = wsp Then w.Add(i)
            End If
        Next
        If w.Count = 1 Then
            initob = w(0)
        End If
        If w.Count = 2 Then
            If w(0).kolor = w(1).kolor Then
                initob = w(0)
                w(1).zazn = IIf(negacjazazn, Not initob.zazn, True)
            Else
                dialogwybor.zaladuj("zaznaczyć", "Zaznacz", True, w(0), w(1))
                dialogwybor.ShowDialog()
                Select Case dialogwybor.wynik
                    Case dialogwybor.wynikdialog.obiekt1
                        initob = w(0)
                    Case dialogwybor.wynikdialog.obiekt2
                        initob = w(1)
                End Select
                dialogwybor.Close()
            End If
        End If
        If w.Count = 0 Then
            usunzazn()
            Exit Sub
        End If
        If initob Is Nothing Then Exit Sub
        If calykolor Then
            Dim nowystan As Boolean = IIf(negacjazazn, Not initob.zazn, True)
            For Each i As obiekt In dane.zawartosc
                If i.kolor = initob.kolor Then i.zazn = nowystan
            Next
        Else
            sonar(wsp, 0, initob.kolor, IIf(negacjazazn, Not initob.zazn, True))
            initob.zazn = IIf(negacjazazn, Not initob.zazn, True)
        End If
    End Sub

    Private Sub sonar(ByVal wsp As Point, ByVal kiernadejscia As Byte, ByVal kolor As Byte, ByVal nowystan As Boolean)
        Dim kierN As Boolean = False
        Dim kierE As Boolean = False
        Dim kierS As Boolean = False
        Dim kierW As Boolean = False

        'N
        If Not kiernadejscia = 1 AndAlso zaznaczkolor(obliczwsp(wsp, 1), kolor, nowystan) Then kierN = True
        'E
        If Not kiernadejscia = 3 AndAlso zaznaczkolor(obliczwsp(wsp, 3), kolor, nowystan) Then kierE = True
        'S
        If Not kiernadejscia = 5 AndAlso zaznaczkolor(obliczwsp(wsp, 5), kolor, nowystan) Then kierS = True
        'W
        If Not kiernadejscia = 7 AndAlso zaznaczkolor(obliczwsp(wsp, 7), kolor, nowystan) Then kierW = True

        If kierN Then sonar(obliczwsp(wsp, 1), 5, kolor, nowystan)
        If kierE Then sonar(obliczwsp(wsp, 3), 7, kolor, nowystan)
        If kierS Then sonar(obliczwsp(wsp, 5), 1, kolor, nowystan)
        If kierW Then sonar(obliczwsp(wsp, 7), 3, kolor, nowystan)
    End Sub

    Private Function zaznaczkolor(ByVal wsp As Point, ByVal szukanykolor As Byte, ByVal stan As Boolean) As Boolean
        Dim flaga As Boolean = False
        Dim w As List(Of obiekt) = New List(Of obiekt)
        For Each i As obiekt In dane.zawartosc
            If i.wsp = wsp Then
                w.Add(i)
            Else
                If i.typ > 4 AndAlso i.wsp2 = wsp Then w.Add(i)
            End If
        Next
        For Each i As obiekt In w
            If i.kolor = szukanykolor AndAlso Not i.zazn = stan Then
                i.zazn = stan
                flaga = True
            End If
        Next
        Return flaga
    End Function

    Public Sub zapiszprojekt(ByVal zmianynafalse As Boolean)
        If zmianynafalse Then
            If dane.filepath = "" Then
                main.savedialog.FileName = ""
                main.savedialog.ShowDialog()
                If Not main.savedialog.FileName = "" Then
                    dane.filepath = main.savedialog.FileName
                    quickontop(main.savedialog.FileName)
                End If
            End If
            dane.zmiany = False
            main.Text = New IO.FileInfo(dane.filepath).Name.Substring(0, New IO.FileInfo(dane.filepath).Name.LastIndexOf(".")) & " - " & main.tytul
            main.serializuj(dane, dane.filepath)
        Else
            Dim sciezka As String = IO.Path.GetTempPath() & "\MOZAIKA-" & New Guid().NewGuid().ToString() & ".moz"
            main.serializuj(dane, sciezka)
            undo.Push(sciezka)
            main.menucofnij.Enabled = True
            redo.Clear()
            main.menupowtorz.Enabled = False
        End If
    End Sub
End Module
