Public Class FormConduccion

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Hide()


    End Sub

    Private Sub FormConduccion_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.Hide()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim idestado As Integer
        StatusBarConduccion.Text = "Enviando Estado"

        idestado = ComboBoxEstados.SelectedIndex()
        Try
            If Sync.ReportaEstado(idestado, TextBoxNota.Text) = -1 Then
                StatusBarConduccion.Text = "Falla en el servidor"
            Else
                StatusBarConduccion.Text = "OK"
            End If
        Catch ex As Exception
            StatusBarConduccion.Text = "Falló envio de datos"
        End Try
    End Sub
End Class