<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class generujobraz
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(generujobraz))
        Me.karty = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tryb5 = New System.Windows.Forms.RadioButton()
        Me.tryb3 = New System.Windows.Forms.RadioButton()
        Me.tryb4 = New System.Windows.Forms.RadioButton()
        Me.tryb2 = New System.Windows.Forms.RadioButton()
        Me.tryb1 = New System.Windows.Forms.RadioButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkboxnumer = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlsiatka = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblsiatka = New System.Windows.Forms.Label()
        Me.tbsiatka = New System.Windows.Forms.TrackBar()
        Me.lblkontur = New System.Windows.Forms.Label()
        Me.chkboxaa = New System.Windows.Forms.CheckBox()
        Me.chkboxsiatkaprzed = New System.Windows.Forms.CheckBox()
        Me.chkboxsiatkaza = New System.Windows.Forms.CheckBox()
        Me.chkboxwsp = New System.Windows.Forms.CheckBox()
        Me.tbkontur = New System.Windows.Forms.TrackBar()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblrozmiar = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbrozmiar = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnltlo = New System.Windows.Forms.Panel()
        Me.chkboxtransparent = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btngeneruj = New System.Windows.Forms.Button()
        Me.kolordialog = New System.Windows.Forms.ColorDialog()
        Me.savedialog = New System.Windows.Forms.SaveFileDialog()
        Me.karty.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.tbsiatka, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbkontur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tbrozmiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'karty
        '
        Me.karty.Controls.Add(Me.TabPage1)
        Me.karty.Controls.Add(Me.TabPage3)
        Me.karty.Controls.Add(Me.TabPage2)
        Me.karty.Location = New System.Drawing.Point(12, 12)
        Me.karty.Name = "karty"
        Me.karty.Padding = New System.Drawing.Point(12, 6)
        Me.karty.SelectedIndex = 0
        Me.karty.Size = New System.Drawing.Size(410, 250)
        Me.karty.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tryb5)
        Me.TabPage1.Controls.Add(Me.tryb3)
        Me.TabPage1.Controls.Add(Me.tryb4)
        Me.TabPage1.Controls.Add(Me.tryb2)
        Me.TabPage1.Controls.Add(Me.tryb1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(402, 218)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tryb renderowania"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tryb5
        '
        Me.tryb5.AutoSize = True
        Me.tryb5.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tryb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tryb5.Location = New System.Drawing.Point(15, 165)
        Me.tryb5.Name = "tryb5"
        Me.tryb5.Size = New System.Drawing.Size(351, 34)
        Me.tryb5.TabIndex = 4
        Me.tryb5.Text = "KOLOROWE KRAWĘDZIE - renderowanie wyłącznie linii" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "krawędziowych koloru, kolor li" &
    "nii zgodny z kolorem obiektów"
        Me.tryb5.UseVisualStyleBackColor = True
        '
        'tryb3
        '
        Me.tryb3.AutoSize = True
        Me.tryb3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tryb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tryb3.Location = New System.Drawing.Point(15, 85)
        Me.tryb3.Name = "tryb3"
        Me.tryb3.Size = New System.Drawing.Size(342, 34)
        Me.tryb3.TabIndex = 3
        Me.tryb3.Text = "KOLOROWY KONTUR - renderowanie obiektów wyłącznie" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "z konturem w ich kolorze"
        Me.tryb3.UseVisualStyleBackColor = True
        '
        'tryb4
        '
        Me.tryb4.AutoSize = True
        Me.tryb4.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tryb4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tryb4.Location = New System.Drawing.Point(15, 125)
        Me.tryb4.Name = "tryb4"
        Me.tryb4.Size = New System.Drawing.Size(321, 34)
        Me.tryb4.TabIndex = 2
        Me.tryb4.Text = "CZARNE KRAWĘDZIE - renderowanie wyłącznie linii" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "krawędziowych koloru, linie wyłą" &
    "cznie koloru czarnego"
        Me.tryb4.UseVisualStyleBackColor = True
        '
        'tryb2
        '
        Me.tryb2.AutoSize = True
        Me.tryb2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tryb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tryb2.Location = New System.Drawing.Point(15, 45)
        Me.tryb2.Name = "tryb2"
        Me.tryb2.Size = New System.Drawing.Size(320, 34)
        Me.tryb2.TabIndex = 1
        Me.tryb2.Text = "CZARNY KONTUR - renderowanie obiektów wyłącznie" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "z konturem w kolorze czarnych"
        Me.tryb2.UseVisualStyleBackColor = True
        '
        'tryb1
        '
        Me.tryb1.AutoSize = True
        Me.tryb1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.tryb1.Checked = True
        Me.tryb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tryb1.Location = New System.Drawing.Point(15, 20)
        Me.tryb1.Name = "tryb1"
        Me.tryb1.Size = New System.Drawing.Size(371, 19)
        Me.tryb1.TabIndex = 0
        Me.tryb1.TabStop = True
        Me.tryb1.Text = "PEŁNY KOLOR - renderowanie obiektów wypełnionych kolorem"
        Me.tryb1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chkboxnumer)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.pnlsiatka)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.lblsiatka)
        Me.TabPage3.Controls.Add(Me.tbsiatka)
        Me.TabPage3.Controls.Add(Me.lblkontur)
        Me.TabPage3.Controls.Add(Me.chkboxaa)
        Me.TabPage3.Controls.Add(Me.chkboxsiatkaprzed)
        Me.TabPage3.Controls.Add(Me.chkboxsiatkaza)
        Me.TabPage3.Controls.Add(Me.chkboxwsp)
        Me.TabPage3.Controls.Add(Me.tbkontur)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(402, 218)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Ustawienia wyglądu"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chkboxnumer
        '
        Me.chkboxnumer.AutoSize = True
        Me.chkboxnumer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkboxnumer.Location = New System.Drawing.Point(15, 92)
        Me.chkboxnumer.Name = "chkboxnumer"
        Me.chkboxnumer.Size = New System.Drawing.Size(173, 19)
        Me.chkboxnumer.TabIndex = 14
        Me.chkboxnumer.Text = "Wyświetlaj numery kolorów"
        Me.chkboxnumer.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(85, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 30)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "(kliknij na kolor obok," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "aby go zmienić)"
        '
        'pnlsiatka
        '
        Me.pnlsiatka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlsiatka.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlsiatka.Location = New System.Drawing.Point(15, 148)
        Me.pnlsiatka.Name = "pnlsiatka"
        Me.pnlsiatka.Size = New System.Drawing.Size(64, 64)
        Me.pnlsiatka.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(85, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Kolor siatki:"
        '
        'lblsiatka
        '
        Me.lblsiatka.AutoSize = True
        Me.lblsiatka.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblsiatka.Location = New System.Drawing.Point(243, 83)
        Me.lblsiatka.Name = "lblsiatka"
        Me.lblsiatka.Size = New System.Drawing.Size(129, 15)
        Me.lblsiatka.TabIndex = 8
        Me.lblsiatka.Text = "Grubość siatki: 1px"
        '
        'tbsiatka
        '
        Me.tbsiatka.BackColor = System.Drawing.Color.White
        Me.tbsiatka.Location = New System.Drawing.Point(246, 101)
        Me.tbsiatka.Maximum = 5
        Me.tbsiatka.Minimum = 1
        Me.tbsiatka.Name = "tbsiatka"
        Me.tbsiatka.Size = New System.Drawing.Size(150, 45)
        Me.tbsiatka.TabIndex = 7
        Me.tbsiatka.Value = 1
        '
        'lblkontur
        '
        Me.lblkontur.AutoSize = True
        Me.lblkontur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblkontur.Location = New System.Drawing.Point(243, 148)
        Me.lblkontur.Name = "lblkontur"
        Me.lblkontur.Size = New System.Drawing.Size(119, 15)
        Me.lblkontur.TabIndex = 6
        Me.lblkontur.Text = "Gr. konturów: 2px"
        '
        'chkboxaa
        '
        Me.chkboxaa.AutoSize = True
        Me.chkboxaa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkboxaa.Location = New System.Drawing.Point(15, 117)
        Me.chkboxaa.Name = "chkboxaa"
        Me.chkboxaa.Size = New System.Drawing.Size(124, 19)
        Me.chkboxaa.TabIndex = 5
        Me.chkboxaa.Text = "Użyj antyaliasingu"
        Me.chkboxaa.UseVisualStyleBackColor = True
        '
        'chkboxsiatkaprzed
        '
        Me.chkboxsiatkaprzed.AutoSize = True
        Me.chkboxsiatkaprzed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkboxsiatkaprzed.Location = New System.Drawing.Point(15, 67)
        Me.chkboxsiatkaprzed.Name = "chkboxsiatkaprzed"
        Me.chkboxsiatkaprzed.Size = New System.Drawing.Size(199, 19)
        Me.chkboxsiatkaprzed.TabIndex = 3
        Me.chkboxsiatkaprzed.Text = "Wyświetl siatkę przed obiektami"
        Me.chkboxsiatkaprzed.UseVisualStyleBackColor = True
        '
        'chkboxsiatkaza
        '
        Me.chkboxsiatkaza.AutoSize = True
        Me.chkboxsiatkaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkboxsiatkaza.Location = New System.Drawing.Point(15, 42)
        Me.chkboxsiatkaza.Name = "chkboxsiatkaza"
        Me.chkboxsiatkaza.Size = New System.Drawing.Size(181, 19)
        Me.chkboxsiatkaza.TabIndex = 2
        Me.chkboxsiatkaza.Text = "Wyświetl siatkę za obiektami"
        Me.chkboxsiatkaza.UseVisualStyleBackColor = True
        '
        'chkboxwsp
        '
        Me.chkboxwsp.AutoSize = True
        Me.chkboxwsp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkboxwsp.Location = New System.Drawing.Point(15, 17)
        Me.chkboxwsp.Name = "chkboxwsp"
        Me.chkboxwsp.Size = New System.Drawing.Size(205, 19)
        Me.chkboxwsp.TabIndex = 1
        Me.chkboxwsp.Text = "Wyświetl linijki ze współrzędnymi"
        Me.chkboxwsp.UseVisualStyleBackColor = True
        '
        'tbkontur
        '
        Me.tbkontur.BackColor = System.Drawing.Color.White
        Me.tbkontur.Location = New System.Drawing.Point(246, 167)
        Me.tbkontur.Maximum = 8
        Me.tbkontur.Minimum = 1
        Me.tbkontur.Name = "tbkontur"
        Me.tbkontur.Size = New System.Drawing.Size(150, 45)
        Me.tbkontur.TabIndex = 0
        Me.tbkontur.Value = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblrozmiar)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.tbrozmiar)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.pnltlo)
        Me.TabPage2.Controls.Add(Me.chkboxtransparent)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(402, 218)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Plik graficzny"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblrozmiar
        '
        Me.lblrozmiar.AutoSize = True
        Me.lblrozmiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblrozmiar.Location = New System.Drawing.Point(26, 156)
        Me.lblrozmiar.Name = "lblrozmiar"
        Me.lblrozmiar.Size = New System.Drawing.Size(201, 45)
        Me.lblrozmiar.TabIndex = 15
        Me.lblrozmiar.Text = "Przewidywany rozmiar obrazu:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "szerokość: 0 kwadratów * 0px = 0px" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wysokość: 0 kwa" &
    "dratów * 0px = 0px"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(219, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Rozmiar pojedynczego kwadratu:"
        '
        'tbrozmiar
        '
        Me.tbrozmiar.BackColor = System.Drawing.Color.White
        Me.tbrozmiar.Location = New System.Drawing.Point(22, 105)
        Me.tbrozmiar.Maximum = 80
        Me.tbrozmiar.Minimum = 1
        Me.tbrozmiar.Name = "tbrozmiar"
        Me.tbrozmiar.Size = New System.Drawing.Size(354, 45)
        Me.tbrozmiar.TabIndex = 13
        Me.tbrozmiar.Value = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(89, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(211, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "(kliknij na kolor obok, aby go zmienić)"
        '
        'pnltlo
        '
        Me.pnltlo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnltlo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnltlo.Location = New System.Drawing.Point(15, 15)
        Me.pnltlo.Name = "pnltlo"
        Me.pnltlo.Size = New System.Drawing.Size(64, 64)
        Me.pnltlo.TabIndex = 11
        '
        'chkboxtransparent
        '
        Me.chkboxtransparent.AutoSize = True
        Me.chkboxtransparent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkboxtransparent.Location = New System.Drawing.Point(92, 38)
        Me.chkboxtransparent.Name = "chkboxtransparent"
        Me.chkboxtransparent.Size = New System.Drawing.Size(156, 19)
        Me.chkboxtransparent.TabIndex = 10
        Me.chkboxtransparent.Text = "Użyj przeźroczystego tła"
        Me.chkboxtransparent.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Kolor tła:"
        '
        'btngeneruj
        '
        Me.btngeneruj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btngeneruj.Location = New System.Drawing.Point(293, 268)
        Me.btngeneruj.Name = "btngeneruj"
        Me.btngeneruj.Size = New System.Drawing.Size(125, 32)
        Me.btngeneruj.TabIndex = 9
        Me.btngeneruj.Text = "Generuj obraz"
        Me.btngeneruj.UseVisualStyleBackColor = True
        '
        'savedialog
        '
        Me.savedialog.Filter = "Obraz PNG (*.png)|*.png"
        '
        'generujobraz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 312)
        Me.Controls.Add(Me.btngeneruj)
        Me.Controls.Add(Me.karty)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "generujobraz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generuj obraz"
        Me.karty.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.tbsiatka, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbkontur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tbrozmiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents karty As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btngeneruj As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tryb1 As RadioButton
    Friend WithEvents tryb5 As RadioButton
    Friend WithEvents tryb3 As RadioButton
    Friend WithEvents tryb4 As RadioButton
    Friend WithEvents tryb2 As RadioButton
    Friend WithEvents chkboxsiatkaprzed As CheckBox
    Friend WithEvents chkboxsiatkaza As CheckBox
    Friend WithEvents chkboxwsp As CheckBox
    Friend WithEvents tbkontur As TrackBar
    Friend WithEvents chkboxaa As CheckBox
    Friend WithEvents lblkontur As Label
    Friend WithEvents lblsiatka As Label
    Friend WithEvents tbsiatka As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents pnltlo As Panel
    Friend WithEvents chkboxtransparent As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblrozmiar As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbrozmiar As TrackBar
    Friend WithEvents kolordialog As ColorDialog
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlsiatka As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents chkboxnumer As CheckBox
    Friend WithEvents savedialog As SaveFileDialog
End Class
