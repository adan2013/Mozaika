<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class welcomescreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(welcomescreen))
        Me.btnnowy = New System.Windows.Forms.Button()
        Me.btnotworz = New System.Windows.Forms.Button()
        Me.quick1 = New System.Windows.Forms.Button()
        Me.quick2 = New System.Windows.Forms.Button()
        Me.quick3 = New System.Windows.Forms.Button()
        Me.quick4 = New System.Windows.Forms.Button()
        Me.img = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblver = New System.Windows.Forms.Label()
        Me.btnend = New System.Windows.Forms.Button()
        CType(Me.img, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnnowy
        '
        Me.btnnowy.FlatAppearance.BorderSize = 2
        Me.btnnowy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnowy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnnowy.Image = Global.Mozaika.My.Resources.Resources.file
        Me.btnnowy.Location = New System.Drawing.Point(12, 104)
        Me.btnnowy.Name = "btnnowy"
        Me.btnnowy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 5)
        Me.btnnowy.Size = New System.Drawing.Size(140, 140)
        Me.btnnowy.TabIndex = 13
        Me.btnnowy.Text = "Nowy projekt"
        Me.btnnowy.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnnowy.UseVisualStyleBackColor = True
        '
        'btnotworz
        '
        Me.btnotworz.FlatAppearance.BorderSize = 2
        Me.btnotworz.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnotworz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnotworz.Image = Global.Mozaika.My.Resources.Resources.folder
        Me.btnotworz.Location = New System.Drawing.Point(158, 104)
        Me.btnotworz.Name = "btnotworz"
        Me.btnotworz.Padding = New System.Windows.Forms.Padding(5, 0, 0, 5)
        Me.btnotworz.Size = New System.Drawing.Size(140, 140)
        Me.btnotworz.TabIndex = 14
        Me.btnotworz.Text = "Otwórz projekt"
        Me.btnotworz.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnotworz.UseVisualStyleBackColor = True
        '
        'quick1
        '
        Me.quick1.FlatAppearance.BorderSize = 2
        Me.quick1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.quick1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.quick1.Location = New System.Drawing.Point(12, 250)
        Me.quick1.Name = "quick1"
        Me.quick1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.quick1.Size = New System.Drawing.Size(286, 40)
        Me.quick1.TabIndex = 15
        Me.quick1.Text = "Quick"
        Me.quick1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.quick1.UseVisualStyleBackColor = True
        '
        'quick2
        '
        Me.quick2.FlatAppearance.BorderSize = 2
        Me.quick2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.quick2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.quick2.Location = New System.Drawing.Point(12, 296)
        Me.quick2.Name = "quick2"
        Me.quick2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.quick2.Size = New System.Drawing.Size(286, 40)
        Me.quick2.TabIndex = 16
        Me.quick2.Text = "Quick"
        Me.quick2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.quick2.UseVisualStyleBackColor = True
        '
        'quick3
        '
        Me.quick3.FlatAppearance.BorderSize = 2
        Me.quick3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.quick3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.quick3.Location = New System.Drawing.Point(12, 342)
        Me.quick3.Name = "quick3"
        Me.quick3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.quick3.Size = New System.Drawing.Size(286, 40)
        Me.quick3.TabIndex = 17
        Me.quick3.Text = "Quick"
        Me.quick3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.quick3.UseVisualStyleBackColor = True
        '
        'quick4
        '
        Me.quick4.FlatAppearance.BorderSize = 2
        Me.quick4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.quick4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.quick4.Location = New System.Drawing.Point(12, 388)
        Me.quick4.Name = "quick4"
        Me.quick4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.quick4.Size = New System.Drawing.Size(286, 40)
        Me.quick4.TabIndex = 18
        Me.quick4.Text = "Quick"
        Me.quick4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.quick4.UseVisualStyleBackColor = True
        '
        'img
        '
        Me.img.Location = New System.Drawing.Point(75, 25)
        Me.img.Name = "img"
        Me.img.Size = New System.Drawing.Size(64, 64)
        Me.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.img.TabIndex = 19
        Me.img.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(142, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 37)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "ozaika"
        '
        'lblver
        '
        Me.lblver.AutoSize = True
        Me.lblver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblver.Location = New System.Drawing.Point(271, 9)
        Me.lblver.Name = "lblver"
        Me.lblver.Size = New System.Drawing.Size(27, 15)
        Me.lblver.TabIndex = 21
        Me.lblver.Text = "wer"
        '
        'btnend
        '
        Me.btnend.FlatAppearance.BorderSize = 2
        Me.btnend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnend.Location = New System.Drawing.Point(208, 448)
        Me.btnend.Name = "btnend"
        Me.btnend.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnend.Size = New System.Drawing.Size(90, 30)
        Me.btnend.TabIndex = 22
        Me.btnend.Text = "Zakończ"
        Me.btnend.UseVisualStyleBackColor = True
        '
        'welcomescreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(310, 490)
        Me.Controls.Add(Me.btnend)
        Me.Controls.Add(Me.lblver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.img)
        Me.Controls.Add(Me.quick4)
        Me.Controls.Add(Me.quick3)
        Me.Controls.Add(Me.quick2)
        Me.Controls.Add(Me.quick1)
        Me.Controls.Add(Me.btnotworz)
        Me.Controls.Add(Me.btnnowy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "welcomescreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WELCOME SCREEN"
        CType(Me.img, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnnowy As Button
    Friend WithEvents btnotworz As Button
    Friend WithEvents quick1 As Button
    Friend WithEvents quick2 As Button
    Friend WithEvents quick3 As Button
    Friend WithEvents quick4 As Button
    Friend WithEvents img As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblver As Label
    Friend WithEvents btnend As Button
End Class
