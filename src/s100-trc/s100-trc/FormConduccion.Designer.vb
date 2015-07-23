<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormConduccion
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
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBoxEstados = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusBarConduccion = New System.Windows.Forms.StatusBar
        Me.TextBoxNota = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.Text = "Que estoy haciendo ?"
        '
        'ComboBoxEstados
        '
        Me.ComboBoxEstados.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.ComboBoxEstados.Items.Add("Inicio de Turno")
        Me.ComboBoxEstados.Items.Add("Fin de Turno")
        Me.ComboBoxEstados.Items.Add("Inicio Descarga")
        Me.ComboBoxEstados.Items.Add("Termino Descarga")
        Me.ComboBoxEstados.Items.Add("Inicio Lavado")
        Me.ComboBoxEstados.Items.Add("Termino Lavado")
        Me.ComboBoxEstados.Location = New System.Drawing.Point(3, 32)
        Me.ComboBoxEstados.Name = "ComboBoxEstados"
        Me.ComboBoxEstados.Size = New System.Drawing.Size(213, 19)
        Me.ComboBoxEstados.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(3, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.Text = "Nota/Valor"
        '
        'StatusBarConduccion
        '
        Me.StatusBarConduccion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.StatusBarConduccion.Location = New System.Drawing.Point(0, 255)
        Me.StatusBarConduccion.Name = "StatusBarConduccion"
        Me.StatusBarConduccion.Size = New System.Drawing.Size(228, 20)
        Me.StatusBarConduccion.Text = "Estado Conducción"
        '
        'TextBoxNota
        '
        Me.TextBoxNota.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TextBoxNota.Location = New System.Drawing.Point(3, 93)
        Me.TextBoxNota.Name = "TextBoxNota"
        Me.TextBoxNota.Size = New System.Drawing.Size(222, 19)
        Me.TextBoxNota.TabIndex = 59
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Button1.Location = New System.Drawing.Point(61, 149)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 20)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Enviar Estado"
        '
        'FormConduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(228, 275)
        Me.Controls.Add(Me.TextBoxNota)
        Me.Controls.Add(Me.StatusBarConduccion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxEstados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormConduccion"
        Me.Text = "Conducción"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEstados As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusBarConduccion As System.Windows.Forms.StatusBar
    Friend WithEvents TextBoxNota As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
