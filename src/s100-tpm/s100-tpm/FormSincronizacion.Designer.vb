<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormSincronizacion
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
        Me.ButtonSincronizaRecibir = New System.Windows.Forms.Button
        Me.ButtonSincronizaEnviar = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'ButtonSincronizaRecibir
        '
        Me.ButtonSincronizaRecibir.Location = New System.Drawing.Point(36, 17)
        Me.ButtonSincronizaRecibir.Name = "ButtonSincronizaRecibir"
        Me.ButtonSincronizaRecibir.Size = New System.Drawing.Size(163, 37)
        Me.ButtonSincronizaRecibir.TabIndex = 0
        Me.ButtonSincronizaRecibir.Text = "Recibir Maestros"
        '
        'ButtonSincronizaEnviar
        '
        Me.ButtonSincronizaEnviar.Location = New System.Drawing.Point(36, 73)
        Me.ButtonSincronizaEnviar.Name = "ButtonSincronizaEnviar"
        Me.ButtonSincronizaEnviar.Size = New System.Drawing.Size(163, 37)
        Me.ButtonSincronizaEnviar.TabIndex = 1
        Me.ButtonSincronizaEnviar.Text = "Enviar Transacciones"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(14, 209)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(211, 20)
        '
        'FormSincronizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonSincronizaEnviar)
        Me.Controls.Add(Me.ButtonSincronizaRecibir)
        Me.Menu = Me.mainMenu1
        Me.Name = "FormSincronizacion"
        Me.Text = "Sincronizacion"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonSincronizaRecibir As System.Windows.Forms.Button
    Friend WithEvents ButtonSincronizaEnviar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
