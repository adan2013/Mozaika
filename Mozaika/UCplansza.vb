Public Class UCplansza

    Public wspkw As Point
    Public dragmode As Boolean = False
    Dim dragstart As Point = New Point(0, 0)

    Public kier As SByte = -1
    Public obpodgl As obiekt
    Public czyjestkolizja As Boolean = False

    Private Sub ekran_MouseDown(sender As Object, e As MouseEventArgs) Handles ekran.MouseDown
        If e.Button = MouseButtons.Right Then
            dragmode = True
            Cursor = Cursors.NoMove2D
            dragstart = e.Location
        End If
        Select Case dane.wybrnarzedzie
            Case 3 'rysowanie
                If e.Button = MouseButtons.Left Then
                    kier = 0
                    generujpodglad()
                End If
        End Select
    End Sub

    Private Sub ekran_MouseMove(sender As Object, e As MouseEventArgs) Handles ekran.MouseMove
        If dragmode Then
            dane.pozplanszy = New Point(dane.pozplanszy.X + (e.X - dragstart.X), dane.pozplanszy.Y + (e.Y - dragstart.Y))
            main.przesunplansze(e.X - dragstart.X, e.Y - dragstart.Y)
            dragstart = e.Location
        End If
        If Not Cursor = Cursors.Default AndAlso e.Button = MouseButtons.None Then Cursor = Cursors.Default
        Select Case dane.wybrnarzedzie
            Case 3 'rysowanie
                If e.Button = MouseButtons.Left Then
                    Dim OLDkier As SByte = kier
                    Dim wspcur As Point = New Point(e.Location.X - 25 - wspkw.X * dane.zoomplanszy - dane.pozplanszy.X, e.Location.Y - 25 - wspkw.Y * dane.zoomplanszy - dane.pozplanszy.Y)
                    kier = 0
                    If wspcur.X > 0 AndAlso wspcur.Y < 0 AndAlso wspcur.X < dane.zoomplanszy Then kier = 1 'N
                    If wspcur.X > 0 AndAlso wspcur.Y > dane.zoomplanszy AndAlso wspcur.X < dane.zoomplanszy Then kier = 5 'S
                    If wspcur.X > dane.zoomplanszy AndAlso wspcur.Y > 0 AndAlso wspcur.Y < dane.zoomplanszy Then kier = 3 'E
                    If wspcur.X < 0 AndAlso wspcur.Y > 0 AndAlso wspcur.Y < dane.zoomplanszy Then kier = 7 'W
                    If wspcur.X >= dane.zoomplanszy AndAlso wspcur.Y <= 0 Then kier = 2 'NE
                    If wspcur.X >= dane.zoomplanszy AndAlso wspcur.Y >= dane.zoomplanszy Then kier = 4 'SE
                    If wspcur.X <= 0 AndAlso wspcur.Y >= dane.zoomplanszy Then kier = 6 'SW
                    If wspcur.X <= 0 AndAlso wspcur.Y <= 0 Then kier = 8 'NW

                    Select Case kier
                        Case 2, 4, 6, 8
                            If Not dane.zezwskosy Then kier = 0
                        Case 1, 3, 5, 7
                            If Not dane.zezwdlugie Then kier = 0
                    End Select

                    Select Case kier
                        Case 1
                            Cursor = Cursors.PanNorth
                        Case 2
                            Cursor = Cursors.PanNE
                        Case 3
                            Cursor = Cursors.PanEast
                        Case 4
                            Cursor = Cursors.PanSE
                        Case 5
                            Cursor = Cursors.PanSouth
                        Case 6
                            Cursor = Cursors.PanSW
                        Case 7
                            Cursor = Cursors.PanWest
                        Case 8
                            Cursor = Cursors.PanNW
                        Case Else
                            Cursor = Cursors.Default
                    End Select
                    If Not OLDkier = kier Then generujpodglad()
                End If
        End Select
        If e.Button = MouseButtons.None Then
            wspkw = New Point(IIf((e.X - dane.pozplanszy.X - 25) \ dane.zoomplanszy >= dane.rozplanszy.Width, dane.rozplanszy.Width - 1, (e.X - dane.pozplanszy.X - 25) \ dane.zoomplanszy), IIf((e.Y - dane.pozplanszy.Y - 25) \ dane.zoomplanszy >= dane.rozplanszy.Height, dane.rozplanszy.Height - 1, (e.Y - dane.pozplanszy.Y - 25) \ dane.zoomplanszy))
            If wspkw.X < 0 Then wspkw.X = 0
            If wspkw.Y < 0 Then wspkw.Y = 0
            main.lblwsp.Text = wspkw.X & ", " & wspkw.Y
        End If
    End Sub

    Private Sub ekran_MouseUp(sender As Object, e As MouseEventArgs) Handles ekran.MouseUp
        If e.Button = MouseButtons.Right Then
            dragmode = False
            wspkw = New Point(IIf((e.X - dane.pozplanszy.X) \ dane.zoomplanszy >= dane.rozplanszy.Width, dane.rozplanszy.Width - 1, (e.X - dane.pozplanszy.X) \ dane.zoomplanszy), IIf((e.Y - dane.pozplanszy.Y) \ dane.zoomplanszy >= dane.rozplanszy.Height, dane.rozplanszy.Height - 1, (e.Y - dane.pozplanszy.Y) \ dane.zoomplanszy))
            main.lblwsp.Text = wspkw.X + 1 & ", " & wspkw.Y + 1
            Cursor = Cursors.Default
            wprowadzonozmiany()
        End If
        If e.Button = MouseButtons.Left Then
            Select Case dane.wybrnarzedzie
                Case 0 'zaznaczanie
                    If MODshift Then
                        If MODctrl Then
                            ' SHIFT + CTRL
                            zapiszprojekt(False)
                            dodajobszarzazn(wspkw, False)
                            wprowadzonozmiany()
                        Else
                            ' SHIFT
                            zapiszprojekt(False)
                            dodajobszarzazn(wspkw, True)
                            wprowadzonozmiany()
                        End If
                    Else
                        If MODctrl Then
                            ' CTRL
                            zapiszprojekt(False)
                            dodajzazn(wspkw, False)
                            wprowadzonozmiany()
                        Else
                            ' brak
                            zapiszprojekt(False)
                            usunzazn()
                            dodajzazn(wspkw, True)
                            wprowadzonozmiany()
                        End If
                    End If
                Case 1 'rozdzka
                    If MODshift Then
                        If MODctrl Then
                            ' SHIFT + CTRL
                            zapiszprojekt(False)
                            rozdzka(wspkw, True, True)
                        Else
                            ' SHIFT
                            zapiszprojekt(False)
                            usunzazn()
                            rozdzka(wspkw, False, True)
                        End If
                    Else
                        If MODctrl Then
                            ' CTRL
                            zapiszprojekt(False)
                            rozdzka(wspkw, True, False)
                        Else
                            ' brak
                            zapiszprojekt(False)
                            usunzazn()
                            rozdzka(wspkw, False, False)
                        End If
                    End If
                Case 2 'kolorowanie
                    If MODshift Then
                        ' SHIFT
                        zapiszprojekt(False)
                        zmienkolor(wspkw, dane.wybrkolor, True)
                        wprowadzonozmiany()
                    Else
                        ' brak
                        zapiszprojekt(False)
                        zmienkolor(wspkw, dane.wybrkolor, False)
                        wprowadzonozmiany()
                    End If
                Case 3 'rysowanie
                    zapiszprojekt(False)
                    Cursor = Cursors.Default
                    dodajobiekt(wspkw, dane.wybrkolor, kier)
                    wprowadzonozmiany()
                    kier = -1
                    czyjestkolizja = False
                Case 4 'duplikacja
                    If MODshift Then
                        ' SHIFT
                        zapiszprojekt(False)
                        duplikujobszarem(wspkw)
                        wprowadzonozmiany()
                    Else
                        ' brak
                        zapiszprojekt(False)
                        duplikujobiekt(wspkw)
                        wprowadzonozmiany()
                    End If
                Case 5 'gumka
                    zapiszprojekt(False)
                    usuntenobiekt(wspkw)
                    wprowadzonozmiany()
                Case 6 'zakraplacz
                    zapiszprojekt(False)
                    przelacznatenkolor(wspkw)
                    wprowadzonozmiany()
            End Select
        End If
        If e.Button = MouseButtons.Middle Then
            Select Case dane.wybrnarzedzie
                Case 3, 4 'rysowanie i duplikacja
                    zapiszprojekt(False)
                    usuntenobiekt(wspkw)
                    wprowadzonozmiany()
            End Select
        End If
        If main.akt.Enabled Then main.rysuj()
    End Sub

    Public Sub generujpodglad()
        If kier < 0 Then Exit Sub
        obpodgl = New obiekt(main.plansza.wspkw, dane.wybrkolor, kier, True, Nothing, 0, 0)
        obpodgl.zmienpozycje(dane.zoomplanszy, dane.pozplanszy)
        czyjestkolizja = obslugakolizji(obpodgl, True)
    End Sub
End Class
