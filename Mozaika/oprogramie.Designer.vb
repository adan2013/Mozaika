<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class oprogramie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(oprogramie))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblver = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.imglogo = New System.Windows.Forms.PictureBox()
        CType(Me.imglogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(84, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 30)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Autor:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "adan2013"
        '
        'lblver
        '
        Me.lblver.AutoSize = True
        Me.lblver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblver.Location = New System.Drawing.Point(170, 46)
        Me.lblver.Name = "lblver"
        Me.lblver.Size = New System.Drawing.Size(48, 15)
        Me.lblver.TabIndex = 6
        Me.lblver.Text = "Wersja:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Mozaika"
        '
        'imglogo
        '
        Me.imglogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imglogo.Location = New System.Drawing.Point(12, 12)
        Me.imglogo.Name = "imglogo"
        Me.imglogo.Size = New System.Drawing.Size(64, 64)
        Me.imglogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imglogo.TabIndex = 4
        Me.imglogo.TabStop = False
        '
        'oprogramie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 92)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.imglogo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "oprogramie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "O programie"
        CType(Me.imglogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents lblver As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents imglogo As PictureBox
End Class
