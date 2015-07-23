Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO

Public Class Sync
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

    Public Shared Function getRegistroByEAN(ByVal id_p As String) As String

        Dim request As WebRequest = WebRequest.Create("http://ripley.rso.cl/apps/src/ws/wsgateway.php")

        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        '        Dim postData As String = "This is a test that posts this string to a Web server."
        Dim postData As String = ""
        postData = "wsname=getproductbyean"
        postData = postData & "&id=" & id_p
        postData = postData & "&iddispositivo=" & MyGlobal.iddispositivo
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


        getRegistroByEAN = responseFromServer
    End Function

    Public Shared Function setRegistroImprime(ByVal id_p As String, ByVal idOpcion_p As Integer, ByVal opcion_p As Integer) As String

        Dim request As WebRequest = WebRequest.Create("http://ripley.rso.cl/apps/src/ws/wsgateway.php")

        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        '        Dim postData As String = "This is a test that posts this string to a Web server."
        Dim postData As String = ""
        postData = "wsname=setproductimprime"
        postData = postData & "&id=" & id_p
        postData = postData & "&idopcion=" & idOpcion_p
        postData = postData & "&opcion=" & opcion_p
        postData = postData & "&iddispositivo=" & MyGlobal.iddispositivo


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

        setRegistroImprime = responseFromServer
    End Function


End Class
