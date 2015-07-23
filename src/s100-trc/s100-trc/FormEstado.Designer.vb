<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormEstado
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
        Me.LabelEstado = New System.Windows.Forms.Label
        Me.ButtonActualizaPosicion = New System.Windows.Forms.Button
        Me.lb1Heading = New System.Windows.Forms.Label
        Me.lb1Speed = New System.Windows.Forms.Label
        Me.lb1Lng = New System.Windows.Forms.Label
        Me.lb1Lat = New System.Windows.Forms.Label
        Me.lb1Altitude = New System.Windows.Forms.Label
        Me.Lb1Time = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
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
        'LabelEstado
        '
        Me.LabelEstado.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LabelEstado.ForeColor = System.Drawing.Color.Lime
        Me.LabelEstado.Location = New System.Drawing.Point(4, 157)
        Me.LabelEstado.Name = "LabelEstado"
        Me.LabelEstado.Size = New System.Drawing.Size(220, 22)
        Me.LabelEstado.Text = "Estado"
        '
        'ButtonActualizaPosicion
        '
        Me.ButtonActualizaPosicion.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.ButtonActualizaPosicion.Location = New System.Drawing.Point(62, 221)
        Me.ButtonActualizaPosicion.Name = "ButtonActualizaPosicion"
        Me.ButtonActualizaPosicion.Size = New System.Drawing.Size(102, 20)
        Me.ButtonActualizaPosicion.TabIndex = 29
        Me.ButtonActualizaPosicion.Text = "Actualizar"
        '
        'lb1Heading
        '
        Me.lb1Heading.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lb1Heading.ForeColor = System.Drawing.Color.Lime
        Me.lb1Heading.Location = New System.Drawing.Point(4, 136)
        Me.lb1Heading.Name = "lb1Heading"
        Me.lb1Heading.Size = New System.Drawing.Size(220, 21)
        Me.lb1Heading.Text = "Heading"
        '
        'lb1Speed
        '
        Me.lb1Speed.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lb1Speed.ForeColor = System.Drawing.Color.Lime
        Me.lb1Speed.Location = New System.Drawing.Point(4, 115)
        Me.lb1Speed.Name = "lb1Speed"
        Me.lb1Speed.Size = New System.Drawing.Size(220, 21)
        Me.lb1Speed.Text = "Speed"
        '
        'lb1Lng
        '
        Me.lb1Lng.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lb1Lng.ForeColor = System.Drawing.Color.Lime
        Me.lb1Lng.Location = New System.Drawing.Point(4, 94)
        Me.lb1Lng.Name = "lb1Lng"
        Me.lb1Lng.Size = New System.Drawing.Size(220, 21)
        Me.lb1Lng.Text = "Long"
        '
        'lb1Lat
        '
        Me.lb1Lat.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lb1Lat.ForeColor = System.Drawing.Color.Lime
        Me.lb1Lat.Location = New System.Drawing.Point(4, 73)
        Me.lb1Lat.Name = "lb1Lat"
        Me.lb1Lat.Size = New System.Drawing.Size(220, 21)
        Me.lb1Lat.Text = "Lat"
        '
        'lb1Altitude
        '
        Me.lb1Altitude.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lb1Altitude.ForeColor = System.Drawing.Color.Lime
        Me.lb1Altitude.Location = New System.Drawing.Point(4, 47)
        Me.lb1Altitude.Name = "lb1Altitude"
        Me.lb1Altitude.Size = New System.Drawing.Size(220, 21)
        Me.lb1Altitude.Text = "Alt"
        '
        'Lb1Time
        '
        Me.Lb1Time.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Lb1Time.ForeColor = System.Drawing.Color.Lime
        Me.Lb1Time.Location = New System.Drawing.Point(4, 26)
        Me.Lb1Time.Name = "Lb1Time"
        Me.Lb1Time.Size = New System.Drawing.Size(220, 21)
        Me.Lb1Time.Text = "UTC"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TextBox1.Location = New System.Drawing.Point(25, 191)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(187, 19)
        Me.TextBox1.TabIndex = 28
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.StatusBar1.Location = New System.Drawing.Point(0, 255)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(228, 20)
        Me.StatusBar1.Text = "Estado GPS"
        '
        'FormEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(228, 275)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.LabelEstado)
        Me.Controls.Add(Me.ButtonActualizaPosicion)
        Me.Controls.Add(Me.lb1Heading)
        Me.Controls.Add(Me.lb1Speed)
        Me.Controls.Add(Me.lb1Lng)
        Me.Controls.Add(Me.lb1Lat)
        Me.Controls.Add(Me.lb1Altitude)
        Me.Controls.Add(Me.Lb1Time)
        Me.Controls.Add(Me.TextBox1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Menu = Me.mainMenu1
        Me.Name = "FormEstado"
        Me.Text = "Estado"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents LabelEstado As System.Windows.Forms.Label
    Friend WithEvents ButtonActualizaPosicion As System.Windows.Forms.Button
    Friend WithEvents lb1Heading As System.Windows.Forms.Label
    Friend WithEvents lb1Speed As System.Windows.Forms.Label
    Friend WithEvents lb1Lng As System.Windows.Forms.Label
    Friend WithEvents lb1Lat As System.Windows.Forms.Label
    Friend WithEvents lb1Altitude As System.Windows.Forms.Label
    Friend WithEvents Lb1Time As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
End Class
