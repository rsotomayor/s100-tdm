Imports System.Data.SQLite



Public Class FormInicio

    Private Sub ButtonEtiquetajePromocional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEtiquetajePromocional.Click
        FormEtiquetajePromocional.Show()
    End Sub

    Private Sub ButtonEtiquetajeRevenue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEtiquetajeRevenue.Click
        FormEtiquetajeRevenue.Show()
    End Sub

    Private Sub ButtonRecogida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecogida.Click
        FormRecogida.Show()
    End Sub


    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub FormInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyGlobal.sqlConnMaestros_a = New SQLiteConnection()
        MyGlobal.sqlConnMaestros_a.ConnectionString = "Data Source=tpm_maestros.db;Version=3;"
        Try
            MyGlobal.sqlConnMaestros_a.Open()
        Catch myException As SQLiteException
            MessageBox.Show("Message: " + myException.Message + "\n")
        End Try

        MyGlobal.sqlConnTransacciones_a = New SQLiteConnection()
        MyGlobal.sqlConnTransacciones_a.ConnectionString = "Data Source=tpm_transacciones.db;Version=3;"
        Try
            MyGlobal.sqlConnTransacciones_a.Open()
        Catch myException As SQLiteException
            MessageBox.Show("Message: " + myException.Message + "\n")
        End Try


        StatusBar1.Text = "Open DB OK"


    End Sub



    Private Sub ButtonSincroniza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSincroniza.Click
        FormSincronizacion.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormInventario.Show()
    End Sub
End Class
