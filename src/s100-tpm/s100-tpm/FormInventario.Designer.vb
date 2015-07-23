<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormInventario
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
        Me.TextBoxINVUbicacion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxINVBarCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxINVCantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonINVGrabar = New System.Windows.Forms.Button
        Me.ButtonINVLimpiar = New System.Windows.Forms.Button
        Me.LabelInventario = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBoxINVUbicacion
        '
        Me.TextBoxINVUbicacion.Location = New System.Drawing.Point(67, 6)
        Me.TextBoxINVUbicacion.Name = "TextBoxINVUbicacion"
        Me.TextBoxINVUbicacion.Size = New System.Drawing.Size(158, 21)
        Me.TextBoxINVUbicacion.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.Text = "Ubic."
        '
        'TextBoxINVBarCode
        '
        Me.TextBoxINVBarCode.Location = New System.Drawing.Point(67, 33)
        Me.TextBoxINVBarCode.Name = "TextBoxINVBarCode"
        Me.TextBoxINVBarCode.Size = New System.Drawing.Size(158, 21)
        Me.TextBoxINVBarCode.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.Text = "BarCode"
        '
        'TextBoxINVCantidad
        '
        Me.TextBoxINVCantidad.Location = New System.Drawing.Point(67, 65)
        Me.TextBoxINVCantidad.Name = "TextBoxINVCantidad"
        Me.TextBoxINVCantidad.Size = New System.Drawing.Size(38, 21)
        Me.TextBoxINVCantidad.TabIndex = 52
        Me.TextBoxINVCantidad.Text = "1"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 20)
        Me.Label3.Text = "Cantidad"
        '
        'ButtonINVGrabar
        '
        Me.ButtonINVGrabar.Location = New System.Drawing.Point(26, 92)
        Me.ButtonINVGrabar.Name = "ButtonINVGrabar"
        Me.ButtonINVGrabar.Size = New System.Drawing.Size(79, 23)
        Me.ButtonINVGrabar.TabIndex = 57
        Me.ButtonINVGrabar.Text = "Grabar"
        '
        'ButtonINVLimpiar
        '
        Me.ButtonINVLimpiar.Location = New System.Drawing.Point(129, 92)
        Me.ButtonINVLimpiar.Name = "ButtonINVLimpiar"
        Me.ButtonINVLimpiar.Size = New System.Drawing.Size(79, 23)
        Me.ButtonINVLimpiar.TabIndex = 58
        Me.ButtonINVLimpiar.Text = "Limpiar"
        '
        'LabelInventario
        '
        Me.LabelInventario.Location = New System.Drawing.Point(26, 137)
        Me.LabelInventario.Name = "LabelInventario"
        Me.LabelInventario.Size = New System.Drawing.Size(182, 94)
        '
        'FormInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.LabelInventario)
        Me.Controls.Add(Me.ButtonINVLimpiar)
        Me.Controls.Add(Me.ButtonINVGrabar)
        Me.Controls.Add(Me.TextBoxINVCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxINVUbicacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxINVBarCode)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "FormInventario"
        Me.Text = "Inventario"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBoxINVUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxINVBarCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxINVCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonINVGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonINVLimpiar As System.Windows.Forms.Button
    Friend WithEvents LabelInventario As System.Windows.Forms.Label
End Class
