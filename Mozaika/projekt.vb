<Serializable()>
Public Class projekt

    Public paleta As List(Of Color) = New List(Of Color)
    Public wybrkolor As Byte = 0
    Public wybrnarzedzie As Byte = 3
    Public rozplanszy As Size = New Size(10, 10)
    Public pozplanszy As Point = New Point(0, 0)
    Public zoomplanszy As Byte = 50

    Public kolorzazn As Color = Color.DeepSkyBlue
    Public siatka As Boolean = True
    Public wspolrzedne As Boolean = True
    Public kolizja As Boolean = True
    Public antialias As Boolean = False
    Public zezwskosy As Boolean = True
    Public zezwdlugie As Boolean = True

    Public zmiany As Boolean = False
    Public filepath As String = ""

    Public OSTobiekt As obiekt
    Public zawartosc As List(Of obiekt) = New List(Of obiekt)

    Public Sub New()
        paleta.Add(Color.FromArgb(0, 0, 0))
        paleta.Add(Color.FromArgb(255, 255, 255))
        paleta.Add(Color.FromArgb(220, 73, 66))
        paleta.Add(Color.FromArgb(112, 216, 66))
        paleta.Add(Color.FromArgb(43, 115, 201))
    End Sub
End Class
