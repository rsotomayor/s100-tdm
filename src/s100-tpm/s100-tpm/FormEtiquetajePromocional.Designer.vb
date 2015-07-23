<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormEtiquetajePromocional
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
        Me.ButtonImprimirPromocional = New System.Windows.Forms.Button
        Me.LabelEPSemanaAntiguedad = New System.Windows.Forms.Label
        Me.ButtonEnviarPromocional = New System.Windows.Forms.Button
        Me.LabelEPPrecio = New System.Windows.Forms.Label
        Me.LabelEPSKU = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelEPNombreProducto = New System.Windows.Forms.Label
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TextBoxEPBarCode = New System.Windows.Forms.TextBox
        Me.ButtonLimpiarPromocional = New System.Windows.Forms.Button
        Me.TextBoxEPUbicacion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LabelEPEAN = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ButtonImprimirPromocional
        '
        Me.ButtonImprimirPromocional.Location = New System.Drawing.Point(61, 224)
        Me.ButtonImprimirPromocional.Name = "ButtonImprimirPromocional"
        Me.ButtonImprimirPromocional.Size = New System.Drawing.Size(125, 20)
        Me.ButtonImprimirPromocional.TabIndex = 16
        Me.ButtonImprimirPromocional.Text = "Imprimir Etiqueta"
        '
        'LabelEPSemanaAntiguedad
        '
        Me.LabelEPSemanaAntiguedad.Location = New System.Drawing.Point(18, 200)
        Me.LabelEPSemanaAntiguedad.Name = "LabelEPSemanaAntiguedad"
        Me.LabelEPSemanaAntiguedad.Size = New System.Drawing.Size(200, 20)
        Me.LabelEPSemanaAntiguedad.Text = "Semana de Antiguedad:"
        Me.LabelEPSemanaAntiguedad.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonEnviarPromocional
        '
        Me.ButtonEnviarPromocional.Location = New System.Drawing.Point(18, 61)
        Me.ButtonEnviarPromocional.Name = "ButtonEnviarPromocional"
        Me.ButtonEnviarPromocional.Size = New System.Drawing.Size(84, 20)
        Me.ButtonEnviarPromocional.TabIndex = 15
        Me.ButtonEnviarPromocional.Text = "Consultar"
        '
        'LabelEPPrecio
        '
        Me.LabelEPPrecio.Location = New System.Drawing.Point(20, 174)
        Me.LabelEPPrecio.Name = "LabelEPPrecio"
        Me.LabelEPPrecio.Size = New System.Drawing.Size(200, 20)
        Me.LabelEPPrecio.Text = "Precio"
        Me.LabelEPPrecio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelEPSKU
        '
        Me.LabelEPSKU.Location = New System.Drawing.Point(20, 115)
        Me.LabelEPSKU.Name = "LabelEPSKU"
        Me.LabelEPSKU.Size = New System.Drawing.Size(200, 20)
        Me.LabelEPSKU.Text = "SKU"
        Me.LabelEPSKU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(1, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.Text = "BarCode"
        '
        'LabelEPNombreProducto
        '
        Me.LabelEPNombreProducto.Location = New System.Drawing.Point(3, 139)
        Me.LabelEPNombreProducto.Name = "LabelEPNombreProducto"
        Me.LabelEPNombreProducto.Size = New System.Drawing.Size(217, 33)
        Me.LabelEPNombreProducto.Text = "Nombre Producto"
        Me.LabelEPNombreProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 273)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(238, 22)
        Me.StatusBar1.Text = "Mensajes"
        '
        'TextBoxEPBarCode
        '
        Me.TextBoxEPBarCode.Location = New System.Drawing.Point(63, 31)
        Me.TextBoxEPBarCode.Name = "TextBoxEPBarCode"
        Me.TextBoxEPBarCode.Size = New System.Drawing.Size(142, 21)
        Me.TextBoxEPBarCode.TabIndex = 27
        '
        'ButtonLimpiarPromocional
        '
        Me.ButtonLimpiarPromocional.Location = New System.Drawing.Point(121, 61)
        Me.ButtonLimpiarPromocional.Name = "ButtonLimpiarPromocional"
        Me.ButtonLimpiarPromocional.Size = New System.Drawing.Size(84, 20)
        Me.ButtonLimpiarPromocional.TabIndex = 35
        Me.ButtonLimpiarPromocional.Text = "Limpiar"
        '
        'TextBoxEPUbicacion
        '
        Me.TextBoxEPUbicacion.Location = New System.Drawing.Point(63, 4)
        Me.TextBoxEPUbicacion.Name = "TextBoxEPUbicacion"
        Me.TextBoxEPUbicacion.Size = New System.Drawing.Size(142, 21)
        Me.TextBoxEPUbicacion.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(1, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.Text = "Ubic."
        '
        'LabelEPEAN
        '
        Me.LabelEPEAN.Location = New System.Drawing.Point(20, 92)
        Me.LabelEPEAN.Name = "LabelEPEAN"
        Me.LabelEPEAN.Size = New System.Drawing.Size(200, 20)
        Me.LabelEPEAN.Text = "EAN"
        Me.LabelEPEAN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormEtiquetajePromocional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.LabelEPEAN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxEPUbicacion)
        Me.Controls.Add(Me.ButtonLimpiarPromocional)
        Me.Controls.Add(Me.TextBoxEPBarCode)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.LabelEPNombreProducto)
        Me.Controls.Add(Me.ButtonImprimirPromocional)
        Me.Controls.Add(Me.LabelEPSemanaAntiguedad)
        Me.Controls.Add(Me.ButtonEnviarPromocional)
        Me.Controls.Add(Me.LabelEPPrecio)
        Me.Controls.Add(Me.LabelEPSKU)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormEtiquetajePromocional"
        Me.Text = "Etiquetaje Promocional"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonImprimirPromocional As System.Windows.Forms.Button
    Friend WithEvents LabelEPSemanaAntiguedad As System.Windows.Forms.Label
    Friend WithEvents ButtonEnviarPromocional As System.Windows.Forms.Button
    Friend WithEvents LabelEPPrecio As System.Windows.Forms.Label
    Friend WithEvents LabelEPSKU As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelEPNombreProducto As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents TextBoxEPBarCode As System.Windows.Forms.TextBox
    Friend WithEvents ButtonLimpiarPromocional As System.Windows.Forms.Button
    Friend WithEvents TextBoxEPUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelEPEAN As System.Windows.Forms.Label
End Class
