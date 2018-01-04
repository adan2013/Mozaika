Public Class zmianapalety

    Const maxil As Byte = 15
    Dim wybr As Byte = 0

    Private Sub zmianapalety_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ladujliste()
    End Sub

    Private Sub ladujliste()
        lblil.Text = "Ilość kolorów: " & dane.paleta.Count & " / " & maxil
        If dane.paleta.Count > 0 Then
            btnusun.Enabled = True
            btnwgore.Enabled = True
            btnwdol.Enabled = True
            btnzmien.Enabled = True
        Else
            btnusun.Enabled = False
            btnwgore.Enabled = False
            btnwdol.Enabled = False
            btnzmien.Enabled = False
        End If
        menukolor.Items.Clear()
        If dane.paleta.Count = 0 Then Exit Sub
        For i As Byte = 0 To dane.paleta.Count - 1
            Dim o As Color = dane.paleta.Item(i)
            Dim itm As ToolStripButton = New ToolStripButton()
            With itm
                .Name = "kolor" & i
                If i < 9 Then .Text = i + 1
                If i = 9 Then .Text = "0"
                If .Text = "" Then .Text = "-"
                If i = wybr Then .Checked = True
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
            menukolor.Items.Add(itm)
            AddHandler itm.Click, AddressOf zmiana
        Next
    End Sub

    Private Sub zmiana(sender As Object, e As EventArgs)
        wybr = sender.Name.Substring(5)
        For i As Byte = 0 To menukolor.Items.Count - 1 Step 1
            Dim o As ToolStripItem = menukolor.Items(i)
            If TypeOf o Is ToolStripButton Then
                CType(o, ToolStripButton).Checked = False
                If i = wybr Then CType(o, ToolStripButton).Checked = True
            End If
        Next
    End Sub

    Private Sub btnnowy_Click(sender As Object, e As EventArgs) Handles btnnowy.Click
        If dane.paleta.Count < maxil Then
            zapiszprojekt(False)
            dane.paleta.Add(Color.FromArgb(0, 0, 0))
            wybr = dane.paleta.Count - 1
            ladujliste()
            wprowadzonozmiany()
        Else
            MsgBox("Przekroczono ilość kolorów w palecie!", MsgBoxStyle.Information, "Mozaika")
        End If
    End Sub

    Private Sub btnusun_Click(sender As Object, e As EventArgs) Handles btnusun.Click
        If dane.paleta.Count = 1 Then
            MsgBox("Nie można usunąć koloru!" & vbNewLine & "Paleta musi zawierać przynajmniej jeden kolor!", MsgBoxStyle.Exclamation, "Mozaika")
        Else
            Select Case MsgBox("Usunąć wybrany kolor?" & vbNewLine & "Obiekty wykorzystujące ten kolor mogą zostać usunięte lub mogą zostać przekolorowane na kolor z numerem " & IIf(wybr = 0, "2", "1") & ":" & vbNewLine & vbNewLine & "Tak - Usuń te obiekty" & vbNewLine & "Nie - Przekoloruj obiekty" & vbNewLine & "Anuluj - Nie usuwaj koloru", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel, "Mozaika")
                Case MsgBoxResult.Yes
                    zapiszprojekt(False)
                    If dane.zawartosc.Count > 0 Then
                        Dim i As Integer = 0
                        Do
                            If dane.zawartosc.Item(i).kolor = wybr Then
                                dane.zawartosc.RemoveAt(i)
                            Else
                                i += 1
                            End If
                            If i >= dane.zawartosc.Count Then Exit Do
                        Loop
                    End If
                Case MsgBoxResult.No
                    zapiszprojekt(False)
                    For Each i As obiekt In dane.zawartosc
                        If i.kolor = wybr Then i.kolor = IIf(wybr = 0, 1, 0)
                    Next
                Case Else
                    Exit Sub
            End Select
            dane.paleta.RemoveAt(wybr)
            For Each i As obiekt In dane.zawartosc
                If i.kolor > wybr Then i.kolor -= 1
            Next
            If wybr > 0 Then wybr -= 1
            ladujliste()
            wprowadzonozmiany()
        End If
    End Sub

    Private Sub btnwgore_Click(sender As Object, e As EventArgs) Handles btnwgore.Click
        If wybr > 0 Then
            zapiszprojekt(False)
            Dim lp As Byte = wybr - 1
            dane.paleta.Insert(lp, dane.paleta.Item(lp + 1))
            dane.paleta.RemoveAt(lp + 2)
            wybr -= 1
            ladujliste()
            For Each i As obiekt In dane.zawartosc
                If i.kolor = wybr Then
                    i.kolor = wybr + 1
                Else
                    If i.kolor = wybr + 1 Then i.kolor = wybr
                End If
            Next
            wprowadzonozmiany()
        End If
    End Sub

    Private Sub btnwdol_Click(sender As Object, e As EventArgs) Handles btnwdol.Click
        If wybr + 1 < dane.paleta.Count Then
            zapiszprojekt(False)
            Dim lp As Byte = wybr + 1
            dane.paleta.Insert(lp + 1, dane.paleta.Item(lp - 1))
            dane.paleta.RemoveAt(lp - 1)
            wybr += 1
            ladujliste()
            For Each i As obiekt In dane.zawartosc
                If i.kolor = wybr Then
                    i.kolor = wybr - 1
                Else
                    If i.kolor = wybr - 1 Then i.kolor = wybr
                End If
            Next
            wprowadzonozmiany()
        End If
    End Sub

    Private Sub btnzmien_Click(sender As Object, e As EventArgs) Handles btnzmien.Click
        zapiszprojekt(False)
        colordialog.Color = dane.paleta(wybr)
        colordialog.ShowDialog()
        dane.paleta.Item(wybr) = colordialog.Color
        ladujliste()
        wprowadzonozmiany()
    End Sub

    Private Sub zmianapalety_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If main.akt.Enabled Then main.rysuj()
    End Sub
End Class