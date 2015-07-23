Imports System.Data.SQLite
Public Class FormInventario
    Dim myprod As Producto.tProducto
    Private Sub IngresaArticulo(ByVal ean_p As String)
        If ean_p.Length = 0 Then
            Exit Sub
        End If

        If TextBoxINVCantidad.Text.Length = 0 Then
            MessageBox.Show("Error en cantidad")
        End If


        Dim mycommand As SQLiteCommand
        mycommand = New SQLiteCommand(MyGlobal.sqlConnTransacciones_a)

        If Producto.getRegistro(ean_p, myprod) = 0 Then
            LabelInventario.Text = "SKU: " & myprod.SKU & Chr(13)
            LabelInventario.Text = LabelInventario.Text + "PROD: " & myprod.PROD
        Else
            LabelInventario.Text = "SKU: No en BD Local"
            myprod.PRECIO = 0
        End If

        Dim objCurrentDate As Date = DateTime.Now
        Dim FECHAHORA As String

        FECHAHORA = objCurrentDate.Year & "-" & objCurrentDate.Month & "-" & objCurrentDate.Day
        FECHAHORA = FECHAHORA + " " & objCurrentDate.Hour & ":" & objCurrentDate.Minute & ":" & objCurrentDate.Second

        Dim ID As String
        Dim REASON As Integer
        Dim LOCATION As String
        Dim UNITS As String
        REASON = 1
        ID = MyGlobal.getMD5Hash(FECHAHORA + ean_p)

        If TextBoxINVUbicacion.Text.Length = 0 Then
            LOCATION = "NO APLICA"
        Else
            LOCATION = TextBoxINVUbicacion.Text
        End If


        UNITS = TextBoxINVCantidad.Text

        mycommand.CommandText = "INSERT INTO STOCKDIARY(ID,DATENEW,REASON,LOCATION,PRODUCT,UNITS,PRICE) "
        mycommand.CommandText = mycommand.CommandText + "VALUES ( "
        mycommand.CommandText = mycommand.CommandText + "'" + ID + "',"
        mycommand.CommandText = mycommand.CommandText + "'" + FECHAHORA + "',"
        mycommand.CommandText = mycommand.CommandText + "'" & REASON & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & LOCATION & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & ean_p & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & UNITS & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & myprod.PRECIO & "');"

        Dim ATTRIBUTESETINSTANCE_ID As String
        ATTRIBUTESETINSTANCE_ID = "NO APLICA"


        Try
            mycommand.ExecuteNonQuery()
        Catch myException As SQLiteException
            MessageBox.Show("Message: " + myException.Message + "\n")
        End Try


        mycommand.CommandText = "INSERT INTO STOCKCURRENT(LOCATION,PRODUCT,ATTRIBUTESETINSTANCE_ID,UNITS) "
        mycommand.CommandText = mycommand.CommandText + "VALUES ( "
        mycommand.CommandText = mycommand.CommandText + "'" + LOCATION + "',"
        mycommand.CommandText = mycommand.CommandText + "'" & ean_p & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & ATTRIBUTESETINSTANCE_ID & "',"
        mycommand.CommandText = mycommand.CommandText + "'" & UNITS & "');"


        Try
            mycommand.ExecuteNonQuery()
        Catch myException1 As SQLiteException

            mycommand.CommandText = "UPDATE STOCKCURRENT "
            mycommand.CommandText = mycommand.CommandText + " SET UNITS = UNITS + " & UNITS & " "
            mycommand.CommandText = mycommand.CommandText + "WHERE "
            mycommand.CommandText = mycommand.CommandText + "LOCATION = '" + LOCATION + "' AND "
            mycommand.CommandText = mycommand.CommandText + "PRODUCT = '" + ean_p + "' AND "
            mycommand.CommandText = mycommand.CommandText + "ATTRIBUTESETINSTANCE_ID = '" + ATTRIBUTESETINSTANCE_ID + "' "
            Try
                mycommand.ExecuteNonQuery()
            Catch myException2 As SQLiteException
                MessageBox.Show("Message: " + myException2.Message + "\n")
            End Try
        End Try

        Dim unidades As String
        unidades = Producto.getStockCurrent(ean_p, LOCATION)

        LabelInventario.Text = LabelInventario.Text + Chr(13)
        LabelInventario.Text = LabelInventario.Text + "Stock = " & unidades

        TextBoxINVBarCode.Text = ""
        TextBoxINVBarCode.Focus()

    End Sub

    Private Sub FormInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBoxINVBarCode.Text = ""
        TextBoxINVBarCode.Focus()
    End Sub



    Private Sub TextBoxINVBarCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxINVBarCode.TextChanged

        If TextBoxINVBarCode.Text.Length >= 13 Then
            IngresaArticulo(TextBoxINVBarCode.Text)
        End If
    End Sub


    Private Sub ButtonINVGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonINVGrabar.Click
        IngresaArticulo(TextBoxINVBarCode.Text.Length)
    End Sub

    Private Sub ButtonINVLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonINVLimpiar.Click
        TextBoxINVBarCode.Text = ""
        TextBoxINVBarCode.Focus()
        LabelInventario.Text = ""
    End Sub

    Private Sub LabelInventario_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelInventario.ParentChanged

    End Sub

    Private Sub TextBoxINVUbicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxINVUbicacion.TextChanged

    End Sub

    Private Sub TextBoxINVCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxINVCantidad.TextChanged

    End Sub

    Private Sub Label3_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.ParentChanged

    End Sub

    Private Sub Label2_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.ParentChanged

    End Sub

    Private Sub Label1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.ParentChanged

    End Sub
End Class