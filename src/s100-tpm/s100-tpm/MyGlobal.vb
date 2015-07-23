Imports System.Data.SQLite
Public Class MyGlobal
    Public Shared sqlConnMaestros_a As SQLiteConnection
    Public Shared sqlConnTransacciones_a As SQLiteConnection

    Public Shared idusuario As String
    Public Shared iddispositivo As String = "pda001"

    Public Shared MyTime As String
    Public Shared MyLatitud As Double
    Public Shared MyLongitud As Double
    Public Shared MyHeading As Double
    Public Shared MySpeed As Double
    Public Shared MyAltitude As Double

    Public Shared Function UnixTimeNow() As Long
        Dim _TimeSpan As TimeSpan = DirectCast((DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)), TimeSpan)
        Return CLng(_TimeSpan.TotalSeconds)
    End Function

    Public Shared Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function
End Class
