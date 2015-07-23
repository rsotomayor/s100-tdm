Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports Microsoft.WindowsMobile.Samples.Location

Public Class Sync
    Public Sub PerformSyncPost(ByVal url_p As String)

        Dim request As WebRequest = WebRequest.Create("http://solem.rso.cl/s-logger/mytdmlogger.php")

        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        '        Dim postData As String = "This is a test that posts this string to a Web server."
        Dim postData As String = ""
        postData = url_p & "idcliente=solem"
        postData = postData & "&clave=demo"
        postData = postData & "&myopcion=ingresa"
        postData = postData & "&iddispositivo=PPCRSO"
        postData = postData & "&fechahora=2007-05-25 19:00:10"
        postData = postData & "&idevento=1"
        postData = postData & "&rumbo=45.41"
        postData = postData & "&altura=100.31"
        postData = postData & "&nota=NA"


        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        Console.WriteLine(responseFromServer)
        ' Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()

    End Sub

    Public Shared Function Login(ByVal idusuario_p As String, ByVal password_p As String) As String

        Dim request As WebRequest = WebRequest.Create("http://solem.rso.cl/s-logger/mytdmlogger.php")

        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        '        Dim postData As String = "This is a test that posts this string to a Web server."
        Dim postData As String = ""
        postData = "idcliente=solem"
        postData = postData & "&ws=auth"
        postData = postData & "&idusuario=" & idusuario_p
        postData = postData & "&password=" & password_p


        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        reader.Close()
        dataStream.Close()
        response.Close()
        If InStr(responseFromServer, "OK") = 0 Then
            Login = -1
        Else
            Login = 0
        End If
    End Function

    Public Shared Function ReportaEstado(ByVal idestado_p As String, ByVal nota_p As String) As String

        Dim request As WebRequest = WebRequest.Create("http://solem.rso.cl/s-logger/mytdmlogger.php")

        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        '        Dim postData As String = "This is a test that posts this string to a Web server."
        Dim postData As String = ""
        postData = "idcliente=solem"
        postData = postData & "&ws=rd"
        postData = postData & "&idusuario=" & MyGlobal.idusuario
        postData = postData & "&idevento=" & idestado_p
        postData = postData & "&iddispositivo=" & MyGlobal.iddispositivo
        postData = postData & "&ts=" & MyGlobal.UnixTimeNow()
        postData = postData & "&velocidad=" & MyGlobal.MySpeed
        postData = postData & "&rumbo=" & MyGlobal.MyHeading
        postData = postData & "&altura=" & MyGlobal.MyAltitude
        postData = postData & "&latitud=" & MyGlobal.MyLatitud
        postData = postData & "&longitud=" & MyGlobal.MyLongitud
        postData = postData & "&nota=" & nota_p


        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        reader.Close()
        dataStream.Close()
        response.Close()
        If InStr(responseFromServer, "OK") = 0 Then
            ReportaEstado = -1
        Else
            ReportaEstado = 0
        End If
    End Function



    Public Shared Function ReportaEstadoContenedor(ByVal idestado_p As String, ByVal estadoContenedor_p As String) As String

        Dim request As WebRequest = WebRequest.Create("http://solem.rso.cl/s-logger/mytdmlogger.php")

        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        '        Dim postData As String = "This is a test that posts this string to a Web server."
        Dim postData As String = ""
        postData = "idcliente=solem"
        postData = postData & "&ws=rd"
        postData = postData & "&idusuario=" & MyGlobal.idusuario
        postData = postData & "&idevento=" & idestado_p
        postData = postData & "&iddispositivo=" & MyGlobal.iddispositivo
        postData = postData & "&ts=" & MyGlobal.UnixTimeNow()
        postData = postData & "&velocidad=" & MyGlobal.MySpeed
        postData = postData & "&rumbo=" & MyGlobal.MyHeading
        postData = postData & "&altura=" & MyGlobal.MyAltitude
        postData = postData & "&latitud=" & MyGlobal.MyLatitud
        postData = postData & "&longitud=" & MyGlobal.MyLongitud
        postData = postData & estadoContenedor_p


        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        reader.Close()
        dataStream.Close()
        response.Close()
        If InStr(responseFromServer, "OK") = 0 Then
            ReportaEstadoContenedor = -1
        Else
            ReportaEstadoContenedor = 0
        End If
    End Function

End Class