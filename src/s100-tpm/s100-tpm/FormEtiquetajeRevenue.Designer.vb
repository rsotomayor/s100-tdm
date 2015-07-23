<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormEtiquetajeRevenue
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
        Me.ButtonEREnviar = New System.Windows.Forms.Button
        Me.LabelERPrecio = New System.Windows.Forms.Label
        Me.LabelERSKU = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelERNombreProducto = New System.Windows.Forms.Label
        Me.ButtonNoImprimirRevenue = New System.Windows.Forms.Button
        Me.ButtonImprimirRevenue = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TextBoxERBarCode = New System.Windows.Forms.TextBox
        Me.TextBoxERUbicacion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonERLimpiar = New System.Windows.Forms.Button
        Me.LabelEREAN = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ButtonEREnviar
        '
        Me.ButtonEREnviar.Location = New System.Drawing.Point(23, 61)
        Me.ButtonEREnviar.Name = "ButtonEREnviar"
        Me.ButtonEREnviar.Size = New System.Drawing.Size(78, 20)
        Me.ButtonEREnviar.TabIndex = 15
        Me.ButtonEREnviar.Text = "Consultar"
        '
        'LabelERPrecio
        '
        Me.LabelERPrecio.Location = New System.Drawing.Point(23, 169)
        Me.LabelERPrecio.Name = "LabelERPrecio"
        Me.LabelERPrecio.Size = New System.Drawing.Size(200, 20)
        Me.LabelERPrecio.Text = "Precio"
        Me.LabelERPrecio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelERSKU
        '
        Me.LabelERSKU.Location = New System.Drawing.Point(23, 110)
        Me.LabelERSKU.Name = "LabelERSKU"
        Me.LabelERSKU.Size = New System.Drawing.Size(200, 20)
        Me.LabelERSKU.Text = "SKU"
        Me.LabelERSKU.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.Text = "BarCode"
        '
        'LabelERNombreProducto
        '
        Me.LabelERNombreProducto.Location = New System.Drawing.Point(23, 130)
        Me.LabelERNombreProducto.Name = "LabelERNombreProducto"
        Me.LabelERNombreProducto.Size = New System.Drawing.Size(200, 32)
        Me.LabelERNombreProducto.Text = "Nombre Producto"
        Me.LabelERNombreProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonNoImprimirRevenue
        '
        Me.ButtonNoImprimirRevenue.Location = New System.Drawing.Point(121, 192)
        Me.ButtonNoImprimirRevenue.Name = "ButtonNoImprimirRevenue"
        Me.ButtonNoImprimirRevenue.Size = New System.Drawing.Size(84, 20)
        Me.ButtonNoImprimirRevenue.TabIndex = 31
        Me.ButtonNoImprimirRevenue.Text = "No Imprimir"
        '
        'ButtonImprimirRevenue
        '
        Me.ButtonImprimirRevenue.Location = New System.Drawing.Point(23, 192)
        Me.ButtonImprimirRevenue.Name = "ButtonImprimirRevenue"
        Me.ButtonImprimirRevenue.Size = New System.Drawing.Size(83, 20)
        Me.ButtonImprimirRevenue.TabIndex = 30
        Me.ButtonImprimirRevenue.Text = "Imprimir"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 273)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(238, 22)
        Me.StatusBar1.Text = "Mensajes"
        '
        'TextBoxERBarCode
        '
        Me.TextBoxERBarCode.Location = New System.Drawing.Point(65, 30)
        Me.TextBoxERBarCode.Name = "TextBoxERBarCode"
        Me.TextBoxERBarCode.Size = New System.Drawing.Size(161, 21)
        Me.TextBoxERBarCode.TabIndex = 36
        '
        'TextBoxERUbicacion
        '
        Me.TextBoxERUbicacion.Location = New System.Drawing.Point(65, 3)
        Me.TextBoxERUbicacion.Name = "TextBoxERUbicacion"
        Me.TextBoxERUbicacion.Size = New System.Drawing.Size(161, 21)
        Me.TextBoxERUbicacion.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(2, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.Text = "Ubic."
        '
        'ButtonERLimpiar
        '
        Me.ButtonERLimpiar.Location = New System.Drawing.Point(121, 61)
        Me.ButtonERLimpiar.Name = "ButtonERLimpiar"
        Me.ButtonERLimpiar.Size = New System.Drawing.Size(81, 20)
        Me.ButtonERLimpiar.TabIndex = 46
        Me.ButtonERLimpiar.Text = "Limpiar"
        '
        'LabelEREAN
        '
        Me.LabelEREAN.Location = New System.Drawing.Point(23, 90)
        Me.LabelEREAN.Name = "LabelEREAN"
        Me.LabelEREAN.Size = New System.Drawing.Size(200, 20)
        Me.LabelEREAN.Text = "EAN"
        Me.LabelEREAN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormEtiquetajeRevenue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.LabelEREAN)
        Me.Controls.Add(Me.ButtonERLimpiar)
        Me.Controls.Add(Me.TextBoxERUbicacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxERBarCode)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ButtonNoImprimirRevenue)
        Me.Controls.Add(Me.ButtonImprimirRevenue)
        Me.Controls.Add(Me.LabelERNombreProducto)
        Me.Controls.Add(Me.ButtonEREnviar)
        Me.Controls.Add(Me.LabelERPrecio)
        Me.Controls.Add(Me.LabelERSKU)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormEtiquetajeRevenue"
        Me.Text = "Etiquetaje Revenue"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonEREnviar As System.Windows.Forms.Button
    Friend WithEvents LabelERPrecio As System.Windows.Forms.Label
    Friend WithEvents LabelERSKU As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelERNombreProducto As System.Windows.Forms.Label
    Friend WithEvents ButtonNoImprimirRevenue As System.Windows.Forms.Button
    Friend WithEvents ButtonImprimirRevenue As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents TextBoxERBarCode As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxERUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonERLimpiar As System.Windows.Forms.Button
    Friend WithEvents LabelEREAN As System.Windows.Forms.Label
End Class
