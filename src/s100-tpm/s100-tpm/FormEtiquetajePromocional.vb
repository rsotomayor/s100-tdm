Imports System.Data.SQLite



Public Class FormEtiquetajePromocional

    Dim myprod As Producto.tProducto

    Private Sub BuscaArticulo(ByVal ean_p As String)
        If ean_p.Length = 0 Then
            Exit Sub
        End If


        If Producto.getRegistro(ean_p, myprod) = 0 Then
            LabelEPEAN.Text = "EAN:" + ean_p
            LabelEPSKU.Text = "SKU: " & myprod.SKU
            LabelEPSKU.ForeColor = Color.Red

            LabelEPNombreProducto.Text = "PROD: " & myprod.PROD
            LabelEPPrecio.Text = "PRECIO: " & myprod.PRECIO
            LabelEPSemanaAntiguedad.Text = "Semana Antiguedad : " & myprod.SemanaAntiguedad
            If (myprod.flagEtiquetar = 1) Then
                ButtonImprimirPromocional.Enabled = True
            Else
                ButtonImprimirPromocional.Enabled = False
            End If
            StatusBar1.Text = "OK:" & MyGlobal.UnixTimeNow()
        Else
            LabelEPEAN.Text = "EAN: " & ean_p
            LabelEPSKU.Text = "SKU: EAN NO ENCONTRADO"
            LabelEPSKU.ForeColor = Color.Red
            LabelEPNombreProducto.Text = "PROD: "
            LabelEPPrecio.Text = "PRECIO: "
            LabelEPSemanaAntiguedad.Text = "Semana Antiguedad : "
            ButtonImprimirPromocional.Enabled = False
            StatusBar1.Text = "Registro no encontrado: " & MyGlobal.UnixTimeNow()
        End If


    End Sub

    Private Sub ButtonEnviarPromocional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviarPromocional.Click
        BuscaArticulo(TextBoxEPBarCode.Text)
        TextBoxEPBarCode.Focus()
        TextBoxEPBarCode.Text = ""
    End Sub



    Private Sub ButtonImprimirPromocional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirPromocional.Click

        Dim mycommand As SQLiteCommand
        mycommand = New SQLiteCommand(MyGlobal.sqlConnTransacciones_a)


        Dim IDOPCION As Integer
        Dim OPCION As Integer
        Dim objCurrentDate As Date = DateTime.Now
        Dim FECHAHORA As String

        FECHAHORA = objCurrentDate.Year & "-" & objCurrentDate.Month & "-" & objCurrentDate.Day
        FECHAHORA = FECHAHORA + " " & objCurrentDate.Hour & ":" & objCurrentDate.Minute & ":" & objCurrentDate.Second


        IDOPCION = 0
        OPCION = 1

        mycommand.CommandText = "INSERT INTO SVT_PRODUCTS_PRINT(PRODUCT,FECHAHORA,IDDISPOSITIVO,IDOPCION,OPCION) "
        mycommand.CommandText = mycommand.CommandText + "VALUES ( "
        mycommand.CommandText = mycommand.CommandText + "'" + myprod.SKU + "',"
        mycommand.CommandText = mycommand.CommandText + "'" + FECHAHORA + "',"
        mycommand.CommandText = mycommand.CommandText + "'" + MyGlobal.iddispositivo + "',"
        mycommand.CommandText = mycommand.CommandText + "'" & IDOPCION & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & OPCION & "');"


        Try
            mycommand.ExecuteNonQuery()
        Catch myException As SQLiteException
            MessageBox.Show("Message: " + myException.Message + "\n")
        End Try
        StatusBar1.Text = "OK Print: " & MyGlobal.UnixTimeNow()

    End Sub

    Private Sub FormEtiquetajePromocional_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' myprod = New Producto.tProducto
        ButtonImprimirPromocional.Enabled = False
        TextBoxEPBarCode.Text = ""
        TextBoxEPBarCode.Focus()
        Me.KeyPreview = True

    End Sub

    Private Sub FormEtiquetajePromocional_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ButtonImprimirPromocional.Enabled = False
    End Sub

    Private Sub FormEP_KeyPressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        'Contador = Contador + 1
        ' TextBoxEPBarCode.Text = TextBoxEPBarCode.Text & e.KeyChar
        ' StatusBar1.Text = Contador
    End Sub


    Private Sub ButtonLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLimpiarPromocional.Click
        TextBoxEPBarCode.Text = ""
        LabelEPEAN.Text = "EAN:"
        LabelEPSKU.Text = "SKU:"
        LabelEPNombreProducto.Text = "PROD: "
        LabelEPPrecio.Text = "PRECIO: "
        LabelEPSemanaAntiguedad.Text = "Semana Antiguedad : "
        ButtonImprimirPromocional.Enabled = False
        StatusBar1.Text = ""
        TextBoxEPBarCode.Focus()

    End Sub

    Private Sub TextBoxEPBarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxEPBarCode.TextChanged

        If TextBoxEPBarCode.Text.Length >= 13 Then
            myprod.EAN = TextBoxEPBarCode.Text
            BuscaArticulo(myprod.EAN)
            TextBoxEPBarCode.Focus()
            TextBoxEPBarCode.Text = ""
        End If
    End Sub
End Class