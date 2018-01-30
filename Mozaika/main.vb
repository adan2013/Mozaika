Imports System.Runtime.Serialization.Formatters.Binary
Public Class main

    Public Const tytul As String = "Mozaika [adan2013]"
    Public Const version As String = "3.1"

    Dim sfcenter As StringFormat = New StringFormat()
    Dim PENblacklinie As Pen = New Pen(Brushes.Black, 1)
    Dim PENlinie As Pen = New Pen(Brushes.LightGray, 1)
    Dim PENgrubalinia As Pen = New Pen(Brushes.Black, 2)
    Dim PENgrubalinia2 As Pen = New Pen(Brushes.Black, 3)
    Dim PENczerlinia As Pen = New Pen(Brushes.DarkRed, 3)
    Dim FONTwsp As Font = New Font("Segoe UI", 10)
    Dim FONTkolizja As Font = New Font("Segoe UI", 8)

    Dim img As Bitmap = New Bitmap(1, 1)
    Public gfx As Graphics = Graphics.FromImage(img)

    Public schowek As List(Of obiekt) = New List(Of obiekt)

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sfcenter.Alignment = StringAlignment.Center
        sfcenter.LineAlignment = StringAlignment.Center
        zaladujuchwytynarzedzi()
        savedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        opendialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        ladujprojekt()
        main_ResizeEnd(Me, New EventArgs())
        welcomescreen.ShowDialog()
    End Sub

    Private Sub main_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0
                Dim nr As Byte = e.KeyCode.ToString().Substring(1)
                If nr = 0 Then nr = 9 Else nr -= 1
                zmienkolor(nr)
            Case Keys.ShiftKey
                If MODshift Then
                    MODshift = False
                    ladujopisnarzedzia()
                    plansza.generujpodglad()
                End If
            Case Keys.ControlKey
                If MODctrl Then
                    MODctrl = False
                    ladujopisnarzedzia()
                    plansza.generujpodglad()
                End If
        End Select
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                Dim zazn As List(Of obiekt) = New List(Of obiekt)
                For Each i As obiekt In dane.zawartosc
                    If i.zazn Then zazn.Add(i)
                Next
                If zazn.Count > 0 AndAlso MsgBox("Czy chcesz usunąć te obiekty?" & vbNewLine & "Ilość elementów: " & zazn.Count, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then
                    For Each i As obiekt In zazn
                        dane.zawartosc.Remove(i)
                    Next
                End If
            Case Keys.ShiftKey
                If Not MODshift Then
                    MODshift = True
                    ladujopisnarzedzia()
                    plansza.generujpodglad()
                End If
            Case Keys.ControlKey
                If Not MODctrl Then
                    MODctrl = True
                    ladujopisnarzedzia()
                    plansza.generujpodglad()
                End If
        End Select
        If akt.Enabled Then rysuj()
    End Sub

#Region "PALETA KOLOROW"

    Public Sub zmienkolor(ByVal nr As Byte)
        If nr < dane.paleta.Count Then
            dane.wybrkolor = nr
            For Each i As ToolStripItem In menukolor.Items
                If TypeOf i Is ToolStripButton Then
                    CType(i, ToolStripButton).Checked = False
                    If i.Name = "kolor" & dane.wybrkolor Then CType(i, ToolStripButton).Checked = True
                End If
            Next
        End If
    End Sub

    Public Sub przeladujpalete()
        Dim lista As List(Of ToolStripItem) = New List(Of ToolStripItem)
        For Each i As ToolStripItem In menukolor.Items
            If TypeOf i Is ToolStripButton AndAlso i.Name.IndexOf("wiecej") < 0 Then lista.Add(i)
        Next
        For Each i As ToolStripItem In lista
            menukolor.Items.Remove(i)
        Next
        If dane.paleta.Count = 0 Then Exit Sub
        For i As Byte = 0 To dane.paleta.Count - 1 Step 1
            Dim itm As ToolStripButton = New ToolStripButton()
            With itm
                .Name = "kolor" & i
                If i < 9 Then .Text = i + 1
                If i = 9 Then .Text = "0"
                If .Text = "" Then .Text = "-"
                If i = dane.wybrkolor Then .Checked = True
                .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                .TextImageRelation = TextImageRelation.TextBeforeImage
                .Padding = New Padding(10, 10, 10, 0)
                .ImageScaling = ToolStripItemImageScaling.None
            End With
            Dim img As Bitmap = New Bitmap(32, 32)
            Using gfx As Graphics = Graphics.FromImage(img)
                gfx.Clear(dane.paleta.Item(i))
            End Using
            itm.Image = img
            menukolor.Items.Insert(i, itm)
            AddHandler itm.Click, AddressOf zmienkolor
        Next
    End Sub

    Private Sub zmienkolor(sender As Object, e As EventArgs)
        dane.wybrkolor = sender.Name.Substring(5)
        For Each i As ToolStripItem In menukolor.Items
            If TypeOf i Is ToolStripButton Then
                CType(i, ToolStripButton).Checked = False
                If i.Name = "kolor" & dane.wybrkolor Then CType(i, ToolStripButton).Checked = True
            End If
        Next
    End Sub

    Private Sub kolorwiecej_Click(sender As Object, e As EventArgs) Handles kolorwiecej.Click
        zmianapalety.ShowDialog()
        przeladujpalete()
        zmianapalety.Close()
    End Sub
#End Region

#Region "NARZEDZIA"

    Private Sub zaladujuchwytynarzedzi()
        For Each i As ToolStripItem In menunarzedzia.Items
            If TypeOf i Is ToolStripButton Then AddHandler i.Click, AddressOf zmiennarzedzie
        Next
        ladujopisnarzedzia()
    End Sub

    Public Sub zmiennarzedzie(sender As Object, e As EventArgs)
        dane.wybrnarzedzie = getidnarzedzia(sender.Name)
        If dane.wybrnarzedzie > 2 Then usunzazn()
        For Each i As ToolStripItem In menunarzedzia.Items
            If TypeOf i Is ToolStripButton Then
                CType(i, ToolStripButton).Checked = False
                If getidnarzedzia(i.Name) = dane.wybrnarzedzie Then CType(i, ToolStripButton).Checked = True
            End If
        Next
        ladujopisnarzedzia()
    End Sub

    Private Sub ladujopisnarzedzia()
        Select Case dane.wybrnarzedzie
            Case 0
                lblopis.Text = "Zaznaczanie: SHIFT - zaznaczanie obszarem | CTRL - zaznaczanie/odznaczanie do aktualnego zaznaczenia"
            Case 1
                lblopis.Text = "Różdżka: SHIFT - zaznaczanie/odznaczanie wszystkich obiektów danego koloru | CTRL - zaznaczanie lub odznaczanie koloru"
            Case 2
                lblopis.Text = "Kolorowanie: SHIFT - zmiana koloru całego obszaru zaznaczenia"
            Case 3
                lblopis.Text = "Rysowanie: SHIFT - odbicie lustrzane ( aktywne: " & IIf(MODshift, "LEWA STRONA", "prawa strona") & " ) | CTRL - kierunek obiektu ( aktywne: " & IIf(MODctrl, "ROZSZERZAJĄCY SIĘ", "zwężający się") & " )"
            Case 4
                lblopis.Text = "Duplikacja: SHIFT - duplikacja obszarem"
            Case 5
                lblopis.Text = "Gumka: brak modyfikatorów"
            Case 6
                lblopis.Text = "Zakraplacz: brak modyfikatorów"
        End Select
    End Sub

    Public Function getidnarzedzia(ByVal nazwa As String) As Byte
        Select Case nazwa
            Case "menuzazn"
                Return 0
            Case "menurozdzka"
                Return 1
            Case "menukolorowanie"
                Return 2
            Case "menurysuj"
                Return 3
            Case "menustempel"
                Return 4
            Case "menugumka"
                Return 5
            Case "menuzakraplacz"
                Return 6
            Case Else
                Return 0
        End Select
    End Function
#End Region

#Region "PLANSZA"

    Private Sub main_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta < 0 Then
            If dane.zoomplanszy > 10 Then
                dane.zoomplanszy -= 5
            Else
                Exit Sub
            End If
        Else
            If dane.zoomplanszy < 80 Then
                dane.zoomplanszy += 5
            Else
                Exit Sub
            End If
        End If
        przesunplansze(0, 0)
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        plansza.Size = New Size(Size.Width - 143, Size.Height - 87)
        lblwsp.Location = New Point(pnlstatus.Size.Width - 60, lblopis.Location.Y)
    End Sub

    Public Sub przesunplansze(ByVal kierX As Integer, ByVal kierY As Integer)
        dane.pozplanszy = New Point(dane.pozplanszy.X + kierX, dane.pozplanszy.Y + kierY)
        If dane.pozplanszy.X > 0 Then dane.pozplanszy = New Point(0, dane.pozplanszy.Y)
        If dane.pozplanszy.Y > 0 Then dane.pozplanszy = New Point(dane.pozplanszy.X, 0)
        If dane.rozplanszy.Width * dane.zoomplanszy > plansza.Size.Width - 25 Then
            If dane.pozplanszy.X - plansza.Size.Width + 25 <= -1 * dane.rozplanszy.Width * dane.zoomplanszy Then dane.pozplanszy = New Point(-1 * dane.rozplanszy.Width * dane.zoomplanszy + plansza.Size.Width - 25, dane.pozplanszy.Y)
        Else
            dane.pozplanszy = New Point(0, dane.pozplanszy.Y)
        End If
        If dane.rozplanszy.Height * dane.zoomplanszy > plansza.Size.Height - 25 Then
            If dane.pozplanszy.Y - plansza.Size.Height + 25 <= -1 * dane.rozplanszy.Height * dane.zoomplanszy Then dane.pozplanszy = New Point(dane.pozplanszy.X, -1 * dane.rozplanszy.Height * dane.zoomplanszy + plansza.Size.Height - 25)
        Else
            dane.pozplanszy = New Point(dane.pozplanszy.X, 0)
        End If
        For Each i As obiekt In dane.zawartosc
            i.zmienpozycje(dane.zoomplanszy, dane.pozplanszy)
        Next
    End Sub
#End Region

#Region "MENU"

    Private Sub menuekrstart_Click(sender As Object, e As EventArgs) Handles menuekrstart.Click
        If dane.zmiany Then
            Select Case MsgBox("Wykryto niezapisane zmiany w projekcie! Czy chcesz je zapisać?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, "Mozaika")
                Case MsgBoxResult.Yes
                    zapiszprojekt(True)
                Case MsgBoxResult.No
                    'przepuszczenie dalej
                Case Else
                    Exit Sub
            End Select
        End If
        welcomescreen.ShowDialog()
    End Sub

    Private Sub menusiatka_Click(sender As Object, e As EventArgs) Handles menusiatka.Click
        zapiszprojekt(False)
        sender.Checked = Not sender.Checked
        dane.siatka = sender.Checked
        wprowadzonozmiany()
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub menuwsp_Click(sender As Object, e As EventArgs) Handles menuwsp.Click
        zapiszprojekt(False)
        sender.Checked = Not sender.Checked
        dane.wspolrzedne = sender.Checked
        wprowadzonozmiany()
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub menukolizja_Click(sender As Object, e As EventArgs) Handles menukolizja.Click
        zapiszprojekt(False)
        sender.Checked = Not sender.Checked
        dane.kolizja = sender.Checked
        wprowadzonozmiany()
    End Sub

    Private Sub menuaa_Click(sender As Object, e As EventArgs) Handles menuaa.Click
        zapiszprojekt(False)
        sender.Checked = Not sender.Checked
        dane.antialias = sender.Checked
        If dane.antialias Then gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias Else gfx.SmoothingMode = Drawing2D.SmoothingMode.None
        wprowadzonozmiany()
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub menuskosy_Click(sender As Object, e As EventArgs) Handles menuskosy.Click
        zapiszprojekt(False)
        sender.Checked = Not sender.Checked
        dane.zezwskosy = sender.Checked
        wprowadzonozmiany()
    End Sub

    Private Sub menudlugie_Click(sender As Object, e As EventArgs) Handles menudlugie.Click
        zapiszprojekt(False)
        sender.Checked = Not sender.Checked
        dane.zezwdlugie = sender.Checked
        wprowadzonozmiany()
    End Sub

    Private Sub menupodswietl_Click(sender As Object, e As EventArgs) Handles menudomyslnykolor.Click
        zapiszprojekt(False)
        colordialog.Color = dane.kolorzazn
        colordialog.ShowDialog()
        dane.kolorzazn = colordialog.Color
        wprowadzonozmiany()
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub przywrocdomyslnykolor_Click(sender As Object, e As EventArgs) Handles przywrocdomyslnykolor.Click
        dane.kolorzazn = domyslnykolor
        wprowadzonozmiany()
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub menuopisnarzedzi_Click(sender As Object, e As EventArgs) Handles menuopisnarzedzi.Click
        oknoinfonarzedzia.ShowDialog()
    End Sub

    Private Sub menuoprogramie_Click(sender As Object, e As EventArgs) Handles menuoprogramie.Click
        oprogramie.ShowDialog()
    End Sub

    Private Sub menuzaznwszystko_Click(sender As Object, e As EventArgs) Handles menuzaznwszystko.Click
        For Each i As obiekt In dane.zawartosc
            i.zazn = True
        Next
    End Sub

    Private Sub menuodznwszystko_Click(sender As Object, e As EventArgs) Handles menuodznwszystko.Click
        usunzazn()
    End Sub

    Private Sub menuwklej_Click(sender As Object, e As EventArgs) Handles menuwklej.Click
        If schowek.Count = 0 Then
            MsgBox("Brak danych w schowku!", MsgBoxStyle.Information, "Schowek")
        Else
            zapiszprojekt(False)
            wprowadzonozmiany()
            Dim x, y As Integer
            x = dane.rozplanszy.Width
            y = dane.rozplanszy.Height
            For Each i As obiekt In schowek
                If i.typ > 4 Then
                    x = Math.Min(x, Math.Min(i.wsp.X, i.wsp2.X))
                    y = Math.Min(y, Math.Min(i.wsp.Y, i.wsp2.Y))
                Else
                    x = Math.Min(x, i.wsp.X)
                    y = Math.Min(y, i.wsp.Y)
                End If
            Next
            x = x - plansza.wspkw.X
            y = y - plansza.wspkw.Y
            usunzazn()
            Dim ilusunietych As Integer = 0
            For Each i As obiekt In schowek
                Dim dousuniecia As Boolean = False
                Dim nowyob As obiekt = New obiekt(plansza.wspkw, 0, 0, False, i, x, y)
                If nowyob.wsp.X >= dane.rozplanszy.Width Or nowyob.wsp.Y >= dane.rozplanszy.Height Then
                    dousuniecia = True
                Else
                    If i.typ > 4 AndAlso (nowyob.wsp2.X >= dane.rozplanszy.Width Or nowyob.wsp2.Y >= dane.rozplanszy.Height) Then
                        dousuniecia = True
                    End If
                End If
                If dousuniecia Then
                    ilusunietych += 1
                Else
                    nowyob.zazn = True
                    obslugakolizji(nowyob, False)
                    dane.zawartosc.Add(nowyob)
                End If
            Next
            If ilusunietych > 0 Then MsgBox("Część obiektów została wklejona poza obszarem projektu i została usunięta! Ilość usuniętych obiektów: " & ilusunietych, MsgBoxStyle.Information, "Schowek")
        End If
    End Sub

    Private Sub menukopiuj_Click(sender As Object, e As EventArgs) Handles menukopiuj.Click
        If getzazn().Count = 0 Then
            MsgBox("Nie zaznaczono żadnego obiektu!", MsgBoxStyle.Information, "Schowek")
        Else
            zapiszprojekt(False)
            wprowadzonozmiany()
            schowek.Clear()
            schowek.AddRange(getzazn())
            MsgBox("Skopiowano obiekty do schowka!" & vbNewLine & "Ilość obiektów: " & schowek.Count, MsgBoxStyle.Information, "Schowek")
        End If
    End Sub

    Private Sub menuwytnij_Click(sender As Object, e As EventArgs) Handles menuwytnij.Click
        If getzazn.Count = 0 Then
            MsgBox("Nie zaznaczono żadnego obiektu!", MsgBoxStyle.Information, "Schowek")
        Else
            zapiszprojekt(False)
            wprowadzonozmiany()
            schowek.Clear()
            schowek.AddRange(getzazn())
            For Each i As obiekt In schowek
                dane.zawartosc.Remove(i)
            Next
            MsgBox("Skopiowano obiekty do schowka!" & vbNewLine & "Ilość obiektów: " & schowek.Count, MsgBoxStyle.Information, "Schowek")
        End If
    End Sub

    Private Sub menuskrotyklaw_Click(sender As Object, e As EventArgs) Handles menuskrotyklaw.Click
        oknoinfoskrotyklaw.ShowDialog()
    End Sub

    Private Sub btnnowy_Click(sender As Object, e As EventArgs) Handles btnnowy.Click
        If dane.zmiany Then
            Select Case MsgBox("Wykryto niezapisane zmiany w projekcie! Czy chcesz je zapisać?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, "Mozaika")
                Case MsgBoxResult.Yes
                    zapiszprojekt(True)
                Case MsgBoxResult.No
                    'przepuszczenie dalej
                Case Else
                    Exit Sub
            End Select
        End If
        dane = New projekt()
        ladujprojekt()
    End Sub

    Private Sub btnotworz_Click(sender As Object, e As EventArgs) Handles btnotworz.Click
        If dane.zmiany Then
            Select Case MsgBox("Wykryto niezapisane zmiany w projekcie! Czy chcesz je zapisać?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, "Mozaika")
                Case MsgBoxResult.Yes
                    zapiszprojekt(True)
                Case MsgBoxResult.No
                    'przepuszczenie dalej
                Case Else
                    Exit Sub
            End Select
        End If
        opendialog.FileName = ""
        opendialog.ShowDialog()
        If Not opendialog.FileName = "" Then
            dane = Nothing
            dane = deserializuj(opendialog.FileName)
            quickontop(opendialog.FileName)
            ladujprojekt()
            MsgBox("Projekt został pomyślnie załadowany!", MsgBoxStyle.Information, "Mozaika")
        End If
    End Sub

    Private Sub menuzapisz_Click(sender As Object, e As EventArgs) Handles menuzapisz.Click
        zapiszprojekt(True)
    End Sub

    Private Sub menuzapiszjako_Click(sender As Object, e As EventArgs) Handles menuzapiszjako.Click
        savedialog.FileName = ""
        savedialog.ShowDialog()
        If Not savedialog.FileName = "" Then
            dane.filepath = savedialog.FileName
            quickontop(savedialog.FileName)
            zapiszprojekt(True)
        End If
    End Sub

    Private Sub menuzakoncz_Click(sender As Object, e As EventArgs) Handles menuzakoncz.Click
        Close()
    End Sub

    Private Sub menurozmiar_Click(sender As Object, e As EventArgs) Handles menurozmiar.Click
        zmianarozmiaru.ShowDialog()
        zmianarozmiaru.Close()
        If akt.Enabled Then rysuj()
    End Sub

    Private Sub menustatystyki_Click(sender As Object, e As EventArgs) Handles menustatystyki.Click
        statystyki.ShowDialog()
        statystyki.Close()
    End Sub

    Private Sub menuobraz_Click(sender As Object, e As EventArgs) Handles menuobraz.Click
        generujobraz.ShowDialog()
        generujobraz.Close()
    End Sub

    Private Sub menucofnij_Click(sender As Object, e As EventArgs) Handles menucofnij.Click
        cofinj()
    End Sub

    Private Sub menupowtorz_Click(sender As Object, e As EventArgs) Handles menupowtorz.Click
        powtorz()
    End Sub
#End Region

#Region "SERIALIZACJA"

    Public Sub serializuj(ByRef obiekt As Object, ByVal path As String)
        Try
            If IO.File.Exists(path) Then IO.File.Delete(path)
            Dim fs As IO.FileStream = IO.File.Create(path)
            Dim bf As BinaryFormatter = New BinaryFormatter
            bf.Serialize(fs, obiekt)
            fs.Close()
        Catch ex As Exception
            MsgBox("Wystąpił błąd podczas zapisu projektu!", MsgBoxStyle.Critical, "Mozaika")
        End Try
    End Sub

    Public Function deserializuj(ByVal path As String) As Object
        If IO.File.Exists(path) Then
            Try
                Dim fs As IO.FileStream = IO.File.OpenRead(path)
                Dim bf As BinaryFormatter = New BinaryFormatter
                Dim wynik As Object = bf.Deserialize(fs)
                fs.Close()
                Return wynik
            Catch ex As Exception
                MsgBox("Wystąpił błąd podczas odczytu projektu!", MsgBoxStyle.Critical, "Mozaika")
            End Try
        Else
            MsgBox("Nie znaleziono pliku projektu!", MsgBoxStyle.Critical, "Mozaika")
        End If
        Return Nothing
    End Function

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If dane.zmiany Then
            Select Case MsgBox("Wykryto niezapisane zmiany w projekcie! Czy chcesz je zapisać?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, "Mozaika")
                Case MsgBoxResult.Yes
                    zapiszprojekt(True)
                Case MsgBoxResult.No
                    'zamkniecie programu
                Case Else
                    e.Cancel = True
            End Select
        End If
    End Sub
#End Region

    Private Sub main_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        img = New Bitmap(plansza.Size.Width, plansza.Size.Height)
        gfx = Graphics.FromImage(img)
        If dane.antialias Then gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        akt.Enabled = True
    End Sub

    Private Sub main_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        akt.Enabled = False
    End Sub

    Private Sub akt_Tick(sender As Object, e As EventArgs) Handles akt.Tick
        Static ostpos As Point = Cursor.Position
        If Not ostpos.Equals(Cursor.Position) Then
            ostpos = Cursor.Position
            rysuj()
        End If
    End Sub

    Public Sub rysuj()
        Dim przesXciag As SByte = dane.pozplanszy.X Mod dane.zoomplanszy
        Dim przesYciag As SByte = dane.pozplanszy.Y Mod dane.zoomplanszy
        gfx.Clear(Color.WhiteSmoke)

        For Each i As obiekt In dane.zawartosc
            If i.Location.X > -50 AndAlso i.Location.X < plansza.Size.Width AndAlso i.Location.Y > -50 AndAlso i.Location.Y < plansza.Size.Height Then
                Dim sb As SolidBrush
                If i.zazn Then sb = New SolidBrush(dane.kolorzazn) Else sb = New SolidBrush(dane.paleta(i.kolor))
                Select Case i.typ
                    Case obiekt.typobiektu.pelny
                        gfx.FillRectangle(sb, New Rectangle(i.Location.X, i.Location.Y, dane.zoomplanszy, dane.zoomplanszy))
                    Case obiekt.typobiektu.skos_NE, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_W_lewy
                        gfx.FillPolygon(sb, {New Point(i.Location.X, i.Location.Y), New Point(i.Size.Width, i.Location.Y), New Point(i.Size.Width, i.Size.Height)})
                    Case obiekt.typobiektu.skos_SE, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_W_prawy
                        gfx.FillPolygon(sb, {New Point(i.Size.Width, i.Location.Y), New Point(i.Size.Width, i.Size.Height), New Point(i.Location.X, i.Size.Height)})
                    Case obiekt.typobiektu.skos_SW, obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_E_lewy
                        gfx.FillPolygon(sb, {New Point(i.Location.X, i.Location.Y), New Point(i.Size.Width, i.Size.Height), New Point(i.Location.X, i.Size.Height)})
                    Case obiekt.typobiektu.skos_NW, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_S_lewy
                        gfx.FillPolygon(sb, {New Point(i.Location.X, i.Location.Y), New Point(i.Size.Width, i.Location.Y), New Point(i.Location.X, i.Size.Height)})
                End Select
            End If
        Next

        If plansza.kier >= 0 AndAlso plansza.obpodgl IsNot Nothing Then
            Dim sb As SolidBrush = New SolidBrush(dane.paleta(plansza.obpodgl.kolor))
            Select Case plansza.obpodgl.typ
                Case obiekt.typobiektu.pelny
                    gfx.FillRectangle(sb, New Rectangle(plansza.obpodgl.Location.X, plansza.obpodgl.Location.Y, dane.zoomplanszy, dane.zoomplanszy))
                Case obiekt.typobiektu.skos_NE, obiekt.typobiektu.dlugi_S_prawy, obiekt.typobiektu.dlugi_W_lewy
                    gfx.FillPolygon(sb, {New Point(plansza.obpodgl.Location.X, plansza.obpodgl.Location.Y), New Point(plansza.obpodgl.Size.Width, plansza.obpodgl.Location.Y), New Point(plansza.obpodgl.Size.Width, plansza.obpodgl.Size.Height)})
                Case obiekt.typobiektu.skos_SE, obiekt.typobiektu.dlugi_N_lewy, obiekt.typobiektu.dlugi_W_prawy
                    gfx.FillPolygon(sb, {New Point(plansza.obpodgl.Size.Width, plansza.obpodgl.Location.Y), New Point(plansza.obpodgl.Size.Width, plansza.obpodgl.Size.Height), New Point(plansza.obpodgl.Location.X, plansza.obpodgl.Size.Height)})
                Case obiekt.typobiektu.skos_SW, obiekt.typobiektu.dlugi_N_prawy, obiekt.typobiektu.dlugi_E_lewy
                    gfx.FillPolygon(sb, {New Point(plansza.obpodgl.Location.X, plansza.obpodgl.Location.Y), New Point(plansza.obpodgl.Size.Width, plansza.obpodgl.Size.Height), New Point(plansza.obpodgl.Location.X, plansza.obpodgl.Size.Height)})
                Case obiekt.typobiektu.skos_NW, obiekt.typobiektu.dlugi_E_prawy, obiekt.typobiektu.dlugi_S_lewy
                    gfx.FillPolygon(sb, {New Point(plansza.obpodgl.Location.X, plansza.obpodgl.Location.Y), New Point(plansza.obpodgl.Size.Width, plansza.obpodgl.Location.Y), New Point(plansza.obpodgl.Location.X, plansza.obpodgl.Size.Height)})
            End Select
        End If
        If dane.siatka Then
            For x As Integer = 25 To plansza.Size.Width + dane.zoomplanszy Step dane.zoomplanszy
                gfx.DrawLine(PENlinie, New Point(x + przesXciag, 25), New Point(x + przesXciag, plansza.Size.Height))
            Next
            For y As Integer = 25 To plansza.Size.Height + dane.zoomplanszy Step dane.zoomplanszy
                gfx.DrawLine(PENlinie, New Point(25, y + przesYciag), New Point(plansza.Size.Width, y + przesYciag))
            Next
        End If
        If plansza.czyjestkolizja AndAlso dane.kolizja Then
            gfx.DrawRectangle(PENczerlinia, New Rectangle(plansza.wspkw.X * dane.zoomplanszy + 25 + dane.pozplanszy.X, plansza.wspkw.Y * dane.zoomplanszy + 25 + dane.pozplanszy.Y, dane.zoomplanszy, dane.zoomplanszy))
            If dane.zoomplanszy > 30 Then
                gfx.FillRectangle(Brushes.DarkRed, New Rectangle(plansza.wspkw.X * dane.zoomplanszy + 20 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, dane.zoomplanszy + 10, 20))
                gfx.DrawString("KOLIZJA", FONTkolizja, Brushes.White, New Rectangle(plansza.wspkw.X * dane.zoomplanszy + 20 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, dane.zoomplanszy + 10, 20), sfcenter)
            End If
        Else
            If Not plansza.dragmode Then
                gfx.DrawRectangle(PENgrubalinia2, New Rectangle(plansza.wspkw.X * dane.zoomplanszy + 25 + dane.pozplanszy.X, plansza.wspkw.Y * dane.zoomplanszy + 25 + dane.pozplanszy.Y, dane.zoomplanszy, dane.zoomplanszy))
                Select Case dane.wybrnarzedzie
                    Case 0
                        gfx.DrawImage(My.Resources.crop_ico, New Rectangle((plansza.wspkw.X + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, 16, 16))
                    Case 1
                        gfx.DrawImage(My.Resources.magic_wand_ico, New Rectangle((plansza.wspkw.X + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, 16, 16))
                    Case 2
                        gfx.DrawImage(My.Resources.bucket_ico, New Rectangle((plansza.wspkw.X + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, 16, 16))
                    Case 4
                        gfx.DrawImage(My.Resources.stamp_ico, New Rectangle((plansza.wspkw.X + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, 16, 16))
                    Case 5
                        gfx.DrawImage(My.Resources.rubber_ico, New Rectangle((plansza.wspkw.X + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, 16, 16))
                    Case 6
                        gfx.DrawImage(My.Resources.picker_ico, New Rectangle((plansza.wspkw.X + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.X, (plansza.wspkw.Y + 1) * dane.zoomplanszy + 30 + dane.pozplanszy.Y, 16, 16))
                End Select
            End If
        End If
        gfx.FillRectangle(Brushes.LightGray, New Rectangle(0, 0, plansza.Size.Width, 25))
        gfx.FillRectangle(Brushes.LightGray, New Rectangle(0, 0, 25, plansza.Size.Height))
        For x As Integer = 25 To plansza.Size.Width + dane.zoomplanszy Step dane.zoomplanszy
            Dim i As Integer = (x - 25 - dane.pozplanszy.X + przesXciag) / dane.zoomplanszy
            If i <= dane.rozplanszy.Width Then gfx.DrawLine(PENblacklinie, New Point(x + przesXciag, 0), New Point(x + przesXciag, 24))
            If dane.wspolrzedne And dane.zoomplanszy > 20 AndAlso i < dane.rozplanszy.Width Then gfx.DrawString(i + 1, FONTwsp, Brushes.Black, New Rectangle(x + przesXciag, 0, dane.zoomplanszy, 25), sfcenter)
        Next
        For y As Integer = 25 To plansza.Size.Height + dane.zoomplanszy Step dane.zoomplanszy
            Dim i As Integer = (y - 25 - dane.pozplanszy.Y + przesYciag) / dane.zoomplanszy
            If i <= dane.rozplanszy.Height Then gfx.DrawLine(PENblacklinie, New Point(0, y + przesYciag), New Point(24, y + przesYciag))
            If dane.wspolrzedne And dane.zoomplanszy > 20 AndAlso i < dane.rozplanszy.Height Then gfx.DrawString(i + 1, FONTwsp, Brushes.Black, New Rectangle(0, y + przesYciag, 25, dane.zoomplanszy), sfcenter)
        Next
        gfx.FillRectangle(Brushes.LightGray, New Rectangle(0, 0, 25, 25))
        gfx.DrawLine(PENblacklinie, New Point(25, 0), New Point(25, 25))
        gfx.DrawLine(PENblacklinie, New Point(0, 25), New Point(25, 25))
        gfx.DrawLine(PENgrubalinia, New Point(26 + dane.rozplanszy.Width * dane.zoomplanszy, 26), New Point(26 + dane.rozplanszy.Width * dane.zoomplanszy, 27 + dane.rozplanszy.Height * dane.zoomplanszy))
        gfx.DrawLine(PENgrubalinia, New Point(26, 26 + dane.rozplanszy.Height * dane.zoomplanszy), New Point(27 + dane.rozplanszy.Width * dane.zoomplanszy, 26 + dane.rozplanszy.Height * dane.zoomplanszy))

        plansza.ekran.Image = img
    End Sub
End Class