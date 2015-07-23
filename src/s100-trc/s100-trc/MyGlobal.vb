Imports Microsoft.WindowsMobile.Samples.Location
Public Class MyGlobal
    Public Shared idusuario As String
    Public Shared iddispositivo As String = "PPCRSO"


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
End Class
