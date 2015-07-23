<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormRecogida
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
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.ButtonRecogida = New System.Windows.Forms.Button
        Me.LabelREPrecio = New System.Windows.Forms.Label
        Me.LabelRESKU = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxREBarCode = New System.Windows.Forms.TextBox
        Me.LabelREAlarma = New System.Windows.Forms.Label
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.LabelRENombreProducto = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxREUbicacion = New System.Windows.Forms.TextBox
        Me.ButtonRecogidaLimpiar = New System.Windows.Forms.Button
        Me.LabelREEAN = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ButtonRecogida
        '
        Me.ButtonRecogida.Location = New System.Drawing.Point(12, 62)
        Me.ButtonRecogida.Name = "ButtonRecogida"
        Me.ButtonRecogida.Size = New System.Drawing.Size(96, 20)
        Me.ButtonRecogida.TabIndex = 27
        Me.ButtonRecogida.Text = "Consultar"
        '
        'LabelREPrecio
        '
        Me.LabelREPrecio.Location = New System.Drawing.Point(23, 182)
        Me.LabelREPrecio.Name = "LabelREPrecio"
        Me.LabelREPrecio.Size = New System.Drawing.Size(200, 20)
        Me.LabelREPrecio.Text = "Precio"
        Me.LabelREPrecio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelRESKU
        '
        Me.LabelRESKU.Location = New System.Drawing.Point(23, 114)
        Me.LabelRESKU.Name = "LabelRESKU"
        Me.LabelRESKU.Size = New System.Drawing.Size(200, 20)
        Me.LabelRESKU.Text = "SKU"
        Me.LabelRESKU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.Text = "BarCode"
        '
        'TextBoxREBarCode
        '
        Me.TextBoxREBarCode.Location = New System.Drawing.Point(63, 30)
        Me.TextBoxREBarCode.Name = "TextBoxREBarCode"
        Me.TextBoxREBarCode.Size = New System.Drawing.Size(161, 21)
        Me.TextBoxREBarCode.TabIndex = 26
        '
        'LabelREAlarma
        '
        Me.LabelREAlarma.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.LabelREAlarma.ForeColor = System.Drawing.Color.Black
        Me.LabelREAlarma.Location = New System.Drawing.Point(3, 198)
        Me.LabelREAlarma.Name = "LabelREAlarma"
        Me.LabelREAlarma.Size = New System.Drawing.Size(232, 38)
        Me.LabelREAlarma.Text = "......"
        Me.LabelREAlarma.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 253)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(238, 22)
        Me.StatusBar1.Text = "Mensajes"
        '
        'LabelRENombreProducto
        '
        Me.LabelRENombreProducto.Location = New System.Drawing.Point(23, 141)
        Me.LabelRENombreProducto.Name = "LabelRENombreProducto"
        Me.LabelRENombreProducto.Size = New System.Drawing.Size(200, 37)
        Me.LabelRENombreProducto.Text = "Nombre Producto"
        Me.LabelRENombreProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.Text = "Ubic."
        '
        'TextBoxREUbicacion
        '
        Me.TextBoxREUbicacion.Location = New System.Drawing.Point(63, 3)
        Me.TextBoxREUbicacion.Name = "TextBoxREUbicacion"
        Me.TextBoxREUbicacion.Size = New System.Drawing.Size(161, 21)
        Me.TextBoxREUbicacion.TabIndex = 32
        '
        'ButtonRecogidaLimpiar
        '
        Me.ButtonRecogidaLimpiar.Location = New System.Drawing.Point(127, 62)
        Me.ButtonRecogidaLimpiar.Name = "ButtonRecogidaLimpiar"
        Me.ButtonRecogidaLimpiar.Size = New System.Drawing.Size(96, 20)
        Me.ButtonRecogidaLimpiar.TabIndex = 34
        Me.ButtonRecogidaLimpiar.Text = "Limpiar"
        '
        'LabelREEAN
        '
        Me.LabelREEAN.Location = New System.Drawing.Point(23, 87)
        Me.LabelREEAN.Name = "LabelREEAN"
        Me.LabelREEAN.Size = New System.Drawing.Size(200, 20)
        Me.LabelREEAN.Text = "EAN"
        Me.LabelREEAN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormRecogida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(238, 275)
        Me.Controls.Add(Me.LabelREEAN)
        Me.Controls.Add(Me.ButtonRecogidaLimpiar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxREUbicacion)
        Me.Controls.Add(Me.LabelRENombreProducto)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.LabelREAlarma)
        Me.Controls.Add(Me.ButtonRecogida)
        Me.Controls.Add(Me.LabelREPrecio)
        Me.Controls.Add(Me.LabelRESKU)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxREBarCode)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormRecogida"
        Me.Text = "Recogida"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonRecogida As System.Windows.Forms.Button
    Friend WithEvents LabelREPrecio As System.Windows.Forms.Label
    Friend WithEvents LabelRESKU As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxREBarCode As System.Windows.Forms.TextBox
    Friend WithEvents LabelREAlarma As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents LabelRENombreProducto As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxREUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRecogidaLimpiar As System.Windows.Forms.Button
    Friend WithEvents LabelREEAN As System.Windows.Forms.Label
End Class
