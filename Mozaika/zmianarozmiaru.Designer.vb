<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class zmianarozmiaru
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(zmianarozmiaru))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nrx = New System.Windows.Forms.NumericUpDown()
        Me.nry = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbloldy = New System.Windows.Forms.Label()
        Me.lbloldx = New System.Windows.Forms.Label()
        Me.btnanuluj = New System.Windows.Forms.Button()
        Me.btnzastosuj = New System.Windows.Forms.Button()
        CType(Me.nrx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X:"
        '
        'nrx
        '
        Me.nrx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.nrx.Location = New System.Drawing.Point(181, 62)
        Me.nrx.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.nrx.Minimum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nrx.Name = "nrx"
        Me.nrx.Size = New System.Drawing.Size(70, 26)
        Me.nrx.TabIndex = 1
        Me.nrx.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'nry
        '
        Me.nry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.nry.Location = New System.Drawing.Point(181, 102)
        Me.nry.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.nry.Minimum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nry.Name = "nry"
        Me.nry.Size = New System.Drawing.Size(70, 26)
        Me.nry.TabIndex = 3
        Me.nry.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Y:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(149, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nowy rozmiar:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Stary rozmiar:"
        '
        'lbloldy
        '
        Me.lbloldy.AutoSize = True
        Me.lbloldy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbloldy.Location = New System.Drawing.Point(23, 104)
        Me.lbloldy.Name = "lbloldy"
        Me.lbloldy.Size = New System.Drawing.Size(26, 20)
        Me.lbloldy.TabIndex = 7
        Me.lbloldy.Text = "Y:"
        '
        'lbloldx
        '
        Me.lbloldx.AutoSize = True
        Me.lbloldx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lbloldx.Location = New System.Drawing.Point(23, 64)
        Me.lbloldx.Name = "lbloldx"
        Me.lbloldx.Size = New System.Drawing.Size(26, 20)
        Me.lbloldx.TabIndex = 5
        Me.lbloldx.Text = "X:"
        '
        'btnanuluj
        '
        Me.btnanuluj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnanuluj.Location = New System.Drawing.Point(192, 150)
        Me.btnanuluj.Name = "btnanuluj"
        Me.btnanuluj.Size = New System.Drawing.Size(80, 30)
        Me.btnanuluj.TabIndex = 10
        Me.btnanuluj.Text = "Anuluj"
        Me.btnanuluj.UseVisualStyleBackColor = True
        '
        'btnzastosuj
        '
        Me.btnzastosuj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnzastosuj.Location = New System.Drawing.Point(106, 150)
        Me.btnzastosuj.Name = "btnzastosuj"
        Me.btnzastosuj.Size = New System.Drawing.Size(80, 30)
        Me.btnzastosuj.TabIndex = 11
        Me.btnzastosuj.Text = "Zastosuj"
        Me.btnzastosuj.UseVisualStyleBackColor = True
        '
        'zmianarozmiaru
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 192)
        Me.Controls.Add(Me.btnzastosuj)
        Me.Controls.Add(Me.btnanuluj)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbloldy)
        Me.Controls.Add(Me.lbloldx)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nry)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nrx)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "zmianarozmiaru"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zmiana rozmiaru"
        CType(Me.nrx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents nrx As NumericUpDown
    Friend WithEvents nry As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbloldy As Label
    Friend WithEvents lbloldx As Label
    Friend WithEvents btnanuluj As Button
    Friend WithEvents btnzastosuj As Button
End Class
