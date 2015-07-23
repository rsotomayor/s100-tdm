Imports System.Data.SQLite
Public Class FormRecogida


    Dim myprod As Producto.tProducto


    Private Sub BuscaArticulo(ByVal ean_p As String)
        If ean_p.Length = 0 Then
            Exit Sub
        End If

        If Producto.getRegistro(ean_p, myprod) = 0 Then
            LabelREEAN.Text = "EAN: " & ean_p
            LabelRESKU.Text = "SKU: " & myprod.SKU
            LabelRENombreProducto.Text = "PROD: " & myprod.PROD
            LabelREPrecio.Text = "PRECIO: " & myprod.PRECIO
            If (myprod.flagRecogida = 1) Then
                LabelREAlarma.Text = "Alarma " & MyGlobal.UnixTimeNow()
                LabelREAlarma.ForeColor = Color.Red
                Beep()
            Else
                LabelREAlarma.Text = "OK " & MyGlobal.UnixTimeNow()
                LabelREAlarma.ForeColor = Color.Green
            End If
        Else
            LabelREEAN.Text = "EAN: " & ean_p
            LabelRESKU.Text = "SKU: "
            LabelRENombreProducto.Text = "PROD: "
            LabelREPrecio.Text = "PRECIO: "
            LabelREAlarma.Text = "KO " & MyGlobal.UnixTimeNow()
            LabelREAlarma.ForeColor = Color.Yellow
            StatusBar1.Text = "Registro no encontrado: " & MyGlobal.UnixTimeNow()
        End If


    End Sub

    Private Sub ButtonRecogida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecogida.Click
        BuscaArticulo(TextBoxREBarCode.Text)
        TextBoxREBarCode.Text = ""
        TextBoxREBarCode.Focus()

    End Sub

    Private Sub FormRecogida_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.Close()
    End Sub

    Private Sub ButtonRecogidaLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRecogidaLimpiar.Click
        LabelREEAN.Text = "EAN: "
        LabelRESKU.Text = "SKU: "
        LabelRENombreProducto.Text = "PROD: "
        LabelREPrecio.Text = "PRECIO: "
        LabelREAlarma.Text = ""
        StatusBar1.Text = ""
        TextBoxREBarCode.Text = ""
        TextBoxREBarCode.Focus()
    End Sub

    Private Sub TextBoxREBarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxREBarCode.TextChanged
        If TextBoxREBarCode.Text.Length >= 13 Then
            myprod.EAN = TextBoxREBarCode.Text
            BuscaArticulo(myprod.EAN)
            TextBoxREBarCode.Text = ""
            TextBoxREBarCode.Focus()
        End If
    End Sub

    Private Sub FormRecogida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBoxREBarCode.Focus()
    End Sub
End Class