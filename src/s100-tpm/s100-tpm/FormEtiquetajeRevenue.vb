Imports System.Data.SQLite

Public Class FormEtiquetajeRevenue

    Dim myprod As Producto.tProducto

    Private Sub BuscaArticulo(ByVal ean_p As String)
        If ean_p.Length = 0 Then
            Exit Sub
        End If

        If Producto.getRegistro(ean_p, myprod) = 0 Then
            LabelEREAN.Text = "EAN: " & ean_p
            LabelERSKU.Text = "SKU: " & myprod.SKU
            LabelERSKU.ForeColor = Color.Black
            LabelERNombreProducto.Text = "PROD: " & myprod.PROD
            LabelERPrecio.Text = "PRECIO: " & myprod.PRECIO
            StatusBar1.Text = "OK:" & MyGlobal.UnixTimeNow()
            If (myprod.flagRevenue = 1) Then
                ButtonImprimirRevenue.Enabled = True
                ButtonNoImprimirRevenue.Enabled = True
            Else
                ButtonImprimirRevenue.Enabled = False
                ButtonNoImprimirRevenue.Enabled = False
            End If
        Else
            LabelEREAN.Text = "EAN: " & ean_p
            LabelERSKU.Text = "SKU: EAN NO ENCONTRADO"
            LabelERSKU.ForeColor = Color.Red
            LabelERNombreProducto.Text = "PROD: "
            LabelERPrecio.Text = "PRECIO: "
            ButtonImprimirRevenue.Enabled = False
            ButtonNoImprimirRevenue.Enabled = False
            StatusBar1.Text = "Falló lectura: " & MyGlobal.UnixTimeNow()
        End If


    End Sub

    Private Sub ButtonEREnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEREnviar.Click
        BuscaArticulo(TextBoxERBarCode.Text)
        TextBoxERBarCode.Text = ""
        TextBoxERBarCode.Focus()

    End Sub

    Private Sub ButtonImprimirRevenue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirRevenue.Click

        Dim mycommand As SQLiteCommand
        mycommand = New SQLiteCommand(MyGlobal.sqlConnTransacciones_a)
        '        mycommand.CommandText = "SELECT * FROM PRODUCTS WHERE ID = '" + TextBoxEPBarCode.Text + "' ; "
        Dim dtmTest As Date
        dtmTest = DateValue(Now)


        Dim IDOPCION As Integer
        Dim OPCION As Integer
        Dim objCurrentDate As Date = DateTime.Now
        Dim FECHAHORA As String

        FECHAHORA = objCurrentDate.Year & "-" & objCurrentDate.Month & "-" & objCurrentDate.Day
        FECHAHORA = FECHAHORA + " " & objCurrentDate.Hour & ":" & objCurrentDate.Minute & ":" & objCurrentDate.Second


        IDOPCION = 1
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
        'Dim szRegistro As String
        'Try
        'szRegistro = Sync.setRegistroImprime(SKU, 1, 1)
        'StatusBar1.Text = szRegistro
        'Catch ex As Exception
        'StatusBar1.Text = "Falló escritura en servidor: " & MyGlobal.UnixTimeNow()
        'End Try

    End Sub

    Private Sub ButtonNoImprimirRevenue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNoImprimirRevenue.Click

        Dim mycommand As SQLiteCommand
        mycommand = New SQLiteCommand(MyGlobal.sqlConnTransacciones_a)
        '        mycommand.CommandText = "SELECT * FROM PRODUCTS WHERE ID = '" + TextBoxEPBarCode.Text + "' ; "
        Dim dtmTest As Date
        dtmTest = DateValue(Now)


        Dim IDOPCION As Integer
        Dim OPCION As Integer
        Dim objCurrentDate As Date = DateTime.Now
        Dim FECHAHORA As String

        FECHAHORA = objCurrentDate.Year & "-" & objCurrentDate.Month & "-" & objCurrentDate.Day
        FECHAHORA = FECHAHORA + " " & objCurrentDate.Hour & ":" & objCurrentDate.Minute & ":" & objCurrentDate.Second


        IDOPCION = 1
        OPCION = 0

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

        StatusBar1.Text = "OK No Print: " & MyGlobal.UnixTimeNow()


    End Sub

    Private Sub FormEtiquetajeRevenue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ButtonImprimirRevenue.Enabled = False
        ButtonNoImprimirRevenue.Enabled = False
        TextBoxERBarCode.Text = ""
        Me.KeyPreview = True
        TextBoxERBarCode.Focus()

    End Sub

    Private Sub FormEtiquetajeRevenue_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        ButtonImprimirRevenue.Enabled = False
        ButtonNoImprimirRevenue.Enabled = False
    End Sub


    Private Sub FormEP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '        Contador = Contador + 1
        '       TextBoxERBarCode.Text = TextBoxERBarCode.Text & e.KeyChar
        '      StatusBar1.Text = Contador
    End Sub

    Private Sub ButtonERLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonERLimpiar.Click
        TextBoxERBarCode.Text = ""
        LabelEREAN.Text = "EAN:"
        LabelERSKU.Text = "SKU:"

        LabelERNombreProducto.Text = "PROD: "
        LabelERPrecio.Text = "PRECIO: "
        ButtonImprimirRevenue.Enabled = False
        ButtonNoImprimirRevenue.Enabled = False
        StatusBar1.Text = ""
        TextBoxERBarCode.Focus()
    End Sub

    Private Sub TextBoxERBarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxERBarCode.TextChanged
        If TextBoxERBarCode.Text.Length >= 13 Then
            myprod.EAN = TextBoxERBarCode.Text
            BuscaArticulo(myprod.EAN)
            TextBoxERBarCode.Focus()
            TextBoxERBarCode.Text = ""
        End If
    End Sub
End Class