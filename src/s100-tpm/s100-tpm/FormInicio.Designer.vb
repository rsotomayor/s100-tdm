<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormInicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInicio))
        Me.ButtonRecogida = New System.Windows.Forms.Button
        Me.ButtonEtiquetajeRevenue = New System.Windows.Forms.Button
        Me.ButtonEtiquetajePromocional = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.ButtonSincroniza = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonRecogida
        '
        Me.ButtonRecogida.Location = New System.Drawing.Point(30, 131)
        Me.ButtonRecogida.Name = "ButtonRecogida"
        Me.ButtonRecogida.Size = New System.Drawing.Size(178, 32)
        Me.ButtonRecogida.TabIndex = 2
        Me.ButtonRecogida.Text = "Recogida"
        '
        'ButtonEtiquetajeRevenue
        '
        Me.ButtonEtiquetajeRevenue.Location = New System.Drawing.Point(30, 93)
        Me.ButtonEtiquetajeRevenue.Name = "ButtonEtiquetajeRevenue"
        Me.ButtonEtiquetajeRevenue.Size = New System.Drawing.Size(178, 34)
        Me.ButtonEtiquetajeRevenue.TabIndex = 1
        Me.ButtonEtiquetajeRevenue.Text = "Etiquetaje Revenue"
        '
        'ButtonEtiquetajePromocional
        '
        Me.ButtonEtiquetajePromocional.Location = New System.Drawing.Point(30, 56)
        Me.ButtonEtiquetajePromocional.Name = "ButtonEtiquetajePromocional"
        Me.ButtonEtiquetajePromocional.Size = New System.Drawing.Size(178, 33)
        Me.ButtonEtiquetajePromocional.TabIndex = 0
        Me.ButtonEtiquetajePromocional.Text = "Etiquetaje Promocional"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(39, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 49)
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(30, 241)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(178, 25)
        Me.ButtonSalir.TabIndex = 3
        Me.ButtonSalir.Text = "Salir"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 272)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(240, 22)
        Me.StatusBar1.Text = "Mensajes"
        '
        'ButtonSincroniza
        '
        Me.ButtonSincroniza.Location = New System.Drawing.Point(30, 203)
        Me.ButtonSincroniza.Name = "ButtonSincroniza"
        Me.ButtonSincroniza.Size = New System.Drawing.Size(178, 32)
        Me.ButtonSincroniza.TabIndex = 5
        Me.ButtonSincroniza.Text = "Sincronizacion"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 166)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(178, 32)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Inventario"
        '
        'FormInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonSincroniza)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonRecogida)
        Me.Controls.Add(Me.ButtonEtiquetajeRevenue)
        Me.Controls.Add(Me.ButtonEtiquetajePromocional)
        Me.Name = "FormInicio"
        Me.Text = "Inicio"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonRecogida As System.Windows.Forms.Button
    Friend WithEvents ButtonEtiquetajeRevenue As System.Windows.Forms.Button
    Friend WithEvents ButtonEtiquetajePromocional As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents ButtonSincroniza As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
