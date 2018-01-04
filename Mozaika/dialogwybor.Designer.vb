<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dialogwybor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dialogwybor))
        Me.lbltytul = New System.Windows.Forms.Label()
        Me.btnanuluj = New System.Windows.Forms.Button()
        Me.btnob2 = New System.Windows.Forms.Button()
        Me.btnob1 = New System.Windows.Forms.Button()
        Me.btnoba = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbltytul
        '
        Me.lbltytul.AutoSize = True
        Me.lbltytul.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbltytul.Location = New System.Drawing.Point(12, 16)
        Me.lbltytul.Name = "lbltytul"
        Me.lbltytul.Size = New System.Drawing.Size(172, 24)
        Me.lbltytul.TabIndex = 10
        Me.lbltytul.Text = "Który obiekt chcesz"
        '
        'btnanuluj
        '
        Me.btnanuluj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnanuluj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnanuluj.Location = New System.Drawing.Point(342, 267)
        Me.btnanuluj.Name = "btnanuluj"
        Me.btnanuluj.Size = New System.Drawing.Size(80, 30)
        Me.btnanuluj.TabIndex = 9
        Me.btnanuluj.Text = "Anuluj"
        Me.btnanuluj.UseVisualStyleBackColor = True
        '
        'btnob2
        '
        Me.btnob2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnob2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnob2.Location = New System.Drawing.Point(222, 95)
        Me.btnob2.Name = "btnob2"
        Me.btnob2.Padding = New System.Windows.Forms.Padding(2)
        Me.btnob2.Size = New System.Drawing.Size(200, 150)
        Me.btnob2.TabIndex = 8
        Me.btnob2.Text = "ten obiekt"
        Me.btnob2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnob2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnob2.UseVisualStyleBackColor = True
        '
        'btnob1
        '
        Me.btnob1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnob1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnob1.Location = New System.Drawing.Point(12, 95)
        Me.btnob1.Name = "btnob1"
        Me.btnob1.Padding = New System.Windows.Forms.Padding(2)
        Me.btnob1.Size = New System.Drawing.Size(200, 150)
        Me.btnob1.TabIndex = 7
        Me.btnob1.Text = "ten obiekt"
        Me.btnob1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnob1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnob1.UseVisualStyleBackColor = True
        '
        'btnoba
        '
        Me.btnoba.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnoba.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.btnoba.Location = New System.Drawing.Point(12, 54)
        Me.btnoba.Name = "btnoba"
        Me.btnoba.Padding = New System.Windows.Forms.Padding(2)
        Me.btnoba.Size = New System.Drawing.Size(410, 35)
        Me.btnoba.TabIndex = 6
        Me.btnoba.Text = "oba obiekty"
        Me.btnoba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnoba.UseVisualStyleBackColor = True
        '
        'dialogwybor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 312)
        Me.Controls.Add(Me.lbltytul)
        Me.Controls.Add(Me.btnanuluj)
        Me.Controls.Add(Me.btnob2)
        Me.Controls.Add(Me.btnob1)
        Me.Controls.Add(Me.btnoba)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dialogwybor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Operacja wymaga potwierdzenia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltytul As Label
    Friend WithEvents btnanuluj As Button
    Friend WithEvents btnob2 As Button
    Friend WithEvents btnob1 As Button
    Friend WithEvents btnoba As Button
End Class
