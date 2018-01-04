Public Class welcomescreen

    Private Sub welcomescreen_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(New Pen(Brushes.Black, 4), New Rectangle(0, 0, Size.Width, Size.Height))
    End Sub

    Private Sub welcomescreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblver.Text = "v" & main.version
        img.Image = My.Resources.ikona.ToBitmap()
        ladujquick()
    End Sub

    Private Sub btnnowy_Click(sender As Object, e As EventArgs) Handles btnnowy.Click
        dane = New projekt()
        ladujprojekt()
        Close()
    End Sub

    Private Sub btnotworz_Click(sender As Object, e As EventArgs) Handles btnotworz.Click
        main.opendialog.FileName = ""
        main.opendialog.ShowDialog()
        If Not main.opendialog.FileName = "" Then
            dane = Nothing
            dane = main.deserializuj(main.opendialog.FileName)
            If dane IsNot Nothing Then
                ladujprojekt()
                quickontop(dane.filepath)
                MsgBox("Projekt został pomyślnie załadowany!", MsgBoxStyle.Information, "Mozaika")
                Close()
            End If
        End If
    End Sub

    Private Sub ladujquick()
        quick1.Enabled = True
        quick2.Enabled = True
        quick3.Enabled = True
        quick4.Enabled = True
        For i As Byte = 1 To 4 Step 1
            If getsetting(i) = "" Then
                getbutton(i).Text = "Brak pozycji"
                getbutton(i).Enabled = False
            Else
                getbutton(i).Text = i & ". " & New IO.FileInfo(getsetting(i)).Name
            End If
        Next
    End Sub

    Private Function getsetting(ByVal id As Byte) As String
        Select Case id
            Case 1
                Return My.Settings.q1
            Case 2
                Return My.Settings.q2
            Case 3
                Return My.Settings.q3
            Case 4
                Return My.Settings.q4
            Case Else
                Return My.Settings.q1
        End Select
    End Function

    Private Function getbutton(ByVal id As Byte) As Button
        Select Case id
            Case 1
                Return quick1
            Case 2
                Return quick2
            Case 3
                Return quick3
            Case 4
                Return quick4
            Case Else
                Return quick1
        End Select
    End Function

    Private Sub quickstart(sender As Object, e As EventArgs)

    End Sub

    Private Sub quick1_Click(sender As Object, e As EventArgs) Handles quick1.Click
        If IO.File.Exists(getsetting(1)) Then
            dane = Nothing
            dane = main.deserializuj(getsetting(1))
            quickontop(getsetting(1))
            If dane IsNot Nothing Then
                ladujprojekt()
                Close()
            End If
        Else
            If MsgBox("Nie znaleziono pliku projektu. Możliwe że został on przeniesiony lub usunięty. Czy chcesz usunąć go z listy?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then
                quickdelete(getsetting(1))
                ladujquick()
            End If
        End If
    End Sub

    Private Sub quick2_Click(sender As Object, e As EventArgs) Handles quick2.Click
        If IO.File.Exists(getsetting(2)) Then
            dane = Nothing
            dane = main.deserializuj(getsetting(2))
            quickontop(getsetting(2))
            If dane IsNot Nothing Then
                ladujprojekt()
                Close()
            End If
        Else
            If MsgBox("Nie znaleziono pliku projektu. Możliwe że został on przeniesiony lub usunięty. Czy chcesz usunąć go z listy?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then
                quickdelete(getsetting(2))
                ladujquick()
            End If
        End If
    End Sub

    Private Sub quick3_Click(sender As Object, e As EventArgs) Handles quick3.Click
        If IO.File.Exists(getsetting(3)) Then
            dane = Nothing
            dane = main.deserializuj(getsetting(3))
            quickontop(getsetting(3))
            If dane IsNot Nothing Then
                ladujprojekt()
                Close()
            End If
        Else
            If MsgBox("Nie znaleziono pliku projektu. Możliwe że został on przeniesiony lub usunięty. Czy chcesz usunąć go z listy?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then
                quickdelete(getsetting(3))
                ladujquick()
            End If
        End If
    End Sub

    Private Sub quick4_Click(sender As Object, e As EventArgs) Handles quick4.Click
        If IO.File.Exists(getsetting(4)) Then
            dane = Nothing
            dane = main.deserializuj(getsetting(4))
            quickontop(getsetting(4))
            If dane IsNot Nothing Then
                ladujprojekt()
                Close()
            End If
        Else
            If MsgBox("Nie znaleziono pliku projektu. Możliwe że został on przeniesiony lub usunięty. Czy chcesz usunąć go z listy?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Mozaika") = MsgBoxResult.Yes Then
                quickdelete(getsetting(4))
                ladujquick()
            End If
        End If
    End Sub

    Private Sub btnend_Click(sender As Object, e As EventArgs) Handles btnend.Click
        End
    End Sub
End Class