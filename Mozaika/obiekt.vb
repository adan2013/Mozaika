<Serializable()>
Public Class obiekt

    Public ReadOnly typ As typobiektu
    Public kolor As Byte
    Public wsp As Point
    Public wsp2 As Point
    Public zazn As Boolean = False

    Public Location As Point
    Public Size As Size

    Public Enum typobiektu
        pelny = 0
        skos_NE = 1
        skos_SE = 2
        skos_SW = 3
        skos_NW = 4
        dlugi_N_prawy = 5
        dlugi_N_lewy = 6
        dlugi_E_prawy = 7
        dlugi_E_lewy = 8
        dlugi_S_prawy = 9
        dlugi_S_lewy = 10
        dlugi_W_prawy = 11
        dlugi_W_lewy = 12
    End Enum

    Public Sub New(ByVal INITwsp As Point, ByVal INITkolor As Byte, ByVal INITkierunek As Byte, ByVal nieklonuj As Boolean, ByVal klonzeschowka As obiekt, ByVal schowekX As Integer, ByVal schowekY As Integer)
        If nieklonuj Then
            kolor = INITkolor
            Select Case INITkierunek
                Case 0
                    typ = 0
                    wsp = INITwsp
                Case 2
                    typ = 1
                    wsp = INITwsp
                Case 4
                    typ = 2
                    wsp = INITwsp
                Case 6
                    typ = 3
                    wsp = INITwsp
                Case 8
                    typ = 4
                    wsp = INITwsp
                Case 1
                    If MODshift Then
                        If MODctrl Then
                            ' SHIFT + CTRL
                            typ = 9
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 1)
                        Else
                            ' SHIFT
                            typ = 6
                            wsp = obliczwsp(INITwsp, 1)
                            wsp2 = INITwsp
                        End If
                    Else
                        If MODctrl Then
                            ' CTRL
                            typ = 10
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 1)
                        Else
                            ' brak
                            typ = 5
                            wsp = obliczwsp(INITwsp, 1)
                            wsp2 = INITwsp
                        End If
                    End If
                Case 3
                    If MODshift Then
                        If MODctrl Then
                            ' SHIFT + CTRL
                            typ = 11
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 3)
                        Else
                            ' SHIFT
                            typ = 8
                            wsp = obliczwsp(INITwsp, 3)
                            wsp2 = INITwsp
                        End If
                    Else
                        If MODctrl Then
                            ' CTRL
                            typ = 12
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 3)
                        Else
                            ' brak
                            typ = 7
                            wsp = obliczwsp(INITwsp, 3)
                            wsp2 = INITwsp
                        End If
                    End If
                Case 5
                    If MODshift Then
                        If MODctrl Then
                            ' SHIFT + CTRL
                            typ = 5
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 5)
                        Else
                            ' SHIFT
                            typ = 10
                            wsp = obliczwsp(INITwsp, 5)
                            wsp2 = INITwsp
                        End If
                    Else
                        If MODctrl Then
                            ' CTRL
                            typ = 6
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 5)
                        Else
                            ' brak
                            typ = 9
                            wsp = obliczwsp(INITwsp, 5)
                            wsp2 = INITwsp
                        End If
                    End If
                Case 7
                    If MODshift Then
                        If MODctrl Then
                            ' SHIFT + CTRL
                            typ = 7
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 7)
                        Else
                            ' SHIFT
                            typ = 12
                            wsp = obliczwsp(INITwsp, 7)
                            wsp2 = INITwsp
                        End If
                    Else
                        If MODctrl Then
                            ' CTRL
                            typ = 8
                            wsp = INITwsp
                            wsp2 = obliczwsp(INITwsp, 7)
                        Else
                            ' brak
                            typ = 11
                            wsp = obliczwsp(INITwsp, 7)
                            wsp2 = INITwsp
                        End If
                    End If
            End Select
        Else
            If klonzeschowka Is Nothing Then
                kolor = dane.OSTobiekt.kolor
                typ = dane.OSTobiekt.typ
                Select Case typ
                    Case typobiektu.pelny, typobiektu.pelny, typobiektu.skos_SE, typobiektu.skos_SW, typobiektu.skos_NW
                        wsp = INITwsp
                        wsp2 = dane.OSTobiekt.wsp2
                    Case typobiektu.dlugi_N_prawy, typobiektu.dlugi_N_lewy
                        wsp = INITwsp
                        wsp2 = obliczwsp(INITwsp, 5)
                    Case typobiektu.dlugi_E_prawy, typobiektu.dlugi_E_lewy
                        wsp = obliczwsp(INITwsp, 3)
                        wsp2 = INITwsp
                    Case typobiektu.dlugi_S_prawy, typobiektu.dlugi_S_lewy
                        wsp = obliczwsp(INITwsp, 5)
                        wsp2 = INITwsp
                    Case typobiektu.dlugi_W_prawy, typobiektu.dlugi_W_lewy
                        wsp = INITwsp
                        wsp2 = obliczwsp(INITwsp, 3)
                End Select
            Else
                kolor = klonzeschowka.kolor
                typ = klonzeschowka.typ
                wsp = New Point(klonzeschowka.wsp.X - schowekX, klonzeschowka.wsp.Y - schowekY)
                wsp2 = New Point(klonzeschowka.wsp2.X - schowekX, klonzeschowka.wsp2.Y - schowekY)
            End If
        End If
        zmienpozycje(dane.zoomplanszy, dane.pozplanszy)
    End Sub

    Public Sub zmienpozycje(ByVal NEWzoom As Byte, ByVal NEWpoz As Point)
        If typ < 5 Then
            Location = New Point(wsp.X * NEWzoom + NEWpoz.X + 25, wsp.Y * NEWzoom + NEWpoz.Y + 25)
            Size = New Size(NEWzoom, NEWzoom)
        Else
            Location = New Point(IIf(wsp.X < wsp2.X, wsp.X, wsp2.X) * NEWzoom + NEWpoz.X + 25, IIf(wsp.Y < wsp2.Y, wsp.Y, wsp2.Y) * NEWzoom + NEWpoz.Y + 25)
            Select Case typ
                Case 5, 6, 9, 10
                    Size = New Size(NEWzoom, NEWzoom * 2)
                Case 7, 8, 11, 12
                    Size = New Size(NEWzoom * 2, NEWzoom)
            End Select
        End If
        Size.Width += Location.X
        Size.Height += Location.Y
    End Sub
End Class
