Imports System.Data.SQLite
Public Class Producto

    Structure tProducto
        Dim EAN As String
        Dim SKU As String
        Dim PROD As String
        Dim PRECIO As Double
        Dim SemanaAntiguedad As Integer
        Dim flagEtiquetar As Integer
        Dim flagRevenue As Integer
        Dim flagRecogida As Integer
    End Structure


    Public Shared Function getRegistro(ByVal ean_p As String, ByRef producto_p As tProducto) As Integer
        Dim retval As Integer

        If ean_p.Length = 0 Then
            getRegistro = -1
            Exit Function
        End If


        Dim mycommand As SQLiteCommand
        mycommand = New SQLiteCommand(MyGlobal.sqlConnMaestros_a)
        mycommand.CommandText = "SELECT PRO.*, PFL.SEMANAANTIGUEDAD,PFL.FLAGETIQUETA, PFL.FLAGREVENUE, PFL.FLAGRECOGIDA "
        mycommand.CommandText = mycommand.CommandText + "FROM PRODUCTS PRO LEFT JOIN SVT_PRODUCTS_FLAG PFL ON ( PRO.ID = PFL.PRODUCT ) "
        mycommand.CommandText = mycommand.CommandText + "WHERE "
        mycommand.CommandText = mycommand.CommandText + "PRO.CODE = '" + ean_p + "' ; "


        Dim reader As SQLiteDataReader


        Try
            reader = mycommand.ExecuteReader()
            reader.Read()
            If reader.HasRows() Then
                '            Label1.Text = reader.Item("NAME")
                producto_p.SKU = reader.Item("CODE")
                producto_p.PROD = reader.Item("NAME")
                producto_p.PRECIO = reader.Item("PRICESELL")
                producto_p.SemanaAntiguedad = reader.Item("SEMANAANTIGUEDAD")
                producto_p.flagEtiquetar = reader.Item("FLAGETIQUETA")
                producto_p.flagRevenue = reader.Item("FLAGREVENUE")
                producto_p.flagRecogida = reader.Item("FLAGRECOGIDA")
                retval = 0
            Else
                retval = 1
            End If
     
        Catch myException As SQLiteException
            MessageBox.Show("Message: " + myException.Message + "\n")
            retval = -1
        End Try

        getRegistro = retval

    End Function

    Public Shared Function getStockCurrent(ByVal ean_p As String, ByVal location_p As String) As Integer
        Dim retval As Integer
        Dim ATTRIBUTESETINSTANCE_ID As String
        ATTRIBUTESETINSTANCE_ID = "NO APLICA"

        Dim mycommand As SQLiteCommand
        mycommand = New SQLiteCommand(MyGlobal.sqlConnTransacciones_a)
        mycommand.CommandText = "SELECT UNITS "
        mycommand.CommandText = mycommand.CommandText + "FROM STOCKCURRENT "
        mycommand.CommandText = mycommand.CommandText + "WHERE "
        mycommand.CommandText = mycommand.CommandText + "LOCATION = '" + location_p + "' AND  "
        mycommand.CommandText = mycommand.CommandText + "PRODUCT = '" + ean_p + "' AND  "
        mycommand.CommandText = mycommand.CommandText + "ATTRIBUTESETINSTANCE_ID = '" + ATTRIBUTESETINSTANCE_ID + "'   "

        Dim reader As SQLiteDataReader


        Try
            reader = mycommand.ExecuteReader()
            reader.Read()
            If reader.HasRows() Then
                retval = reader.Item("UNITS")

            Else
                retval = 0
            End If

        Catch myException As SQLiteException
            MessageBox.Show("Message: " + myException.Message + "\n")
            retval = -1
        End Try
        getStockCurrent = retval


    End Function


End Class


