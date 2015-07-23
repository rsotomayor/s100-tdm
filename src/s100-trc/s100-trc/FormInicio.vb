Imports Microsoft.WindowsMobile.Samples.Location
Public Class FormInicio
    Dim updateDataHandler As System.EventHandler = New System.EventHandler(AddressOf UpdateData)
    Dim mygps As New Gps()
    Dim device As GpsDeviceState = Nothing
    Dim position As GpsPosition = Nothing

    Private Sub gps_Location_changed(ByVal sender As Object, ByVal args As LocationChangedEventArgs)
        position = args.Position
        Invoke(updateDataHandler)
    End Sub

    Private Sub gps_DeviceState_Changed(ByVal sender As Object, ByVal args As DeviceStateChangedEventArgs)
        device = args.DeviceState
        Invoke(updateDataHandler)
    End Sub


    Public Sub UpdateData(ByVal sender As Object, ByVal args As System.EventArgs)
        If mygps.Opened Then
            Dim str As String = ""
            If device IsNot Nothing Then
                str = device.FriendlyName
            End If

            If position IsNot Nothing Then
                If position.SeaLevelAltitudeValid AndAlso position.SpeedValid AndAlso position.LatitudeValid AndAlso position.LongitudeValid AndAlso position.SatellitesInSolutionValid AndAlso position.SatellitesInViewValid AndAlso position.SatelliteCountValid AndAlso position.TimeValid Then
                    MyGlobal.MySpeed = position.Speed
                    MyGlobal.MyHeading = position.Heading
                    MyGlobal.MyAltitude = position.EllipsoidAltitude
                    MyGlobal.MyLatitud = position.Latitude
                    MyGlobal.MyLongitud = position.Longitude
                    FormEstado.lb1Speed.Text = "Speed: " & MyGlobal.MySpeed & " km/h"
                    FormEstado.lb1Heading.Text = "Heading: " & MyGlobal.MyHeading
                    FormEstado.lb1Altitude.Text = "Alt:" & MyGlobal.MyAltitude
                    '---display the lat and lng---
                    FormEstado.lb1Lat.Text = "Lat:" & MyGlobal.MyLatitud
                    FormEstado.lb1Lng.Text = "Lng:" & MyGlobal.MyLongitud
                    FormEstado.Lb1Time.Text = "UTC:" & position.Time.ToString()
                    FormEstado.LabelEstado.Text = "Number Satellites: " & position.SatelliteCount
                ElseIf position.LatitudeValid AndAlso position.LongitudeValid AndAlso position.TimeValid Then
                    MyGlobal.MySpeed = 0
                    MyGlobal.MyHeading = 0
                    MyGlobal.MyAltitude = 0
                    MyGlobal.MyLatitud = position.Latitude
                    MyGlobal.MyLongitud = position.Longitude
                    FormEstado.lb1Speed.Text = "Speed: " & MyGlobal.MySpeed & " km/h"
                    FormEstado.lb1Heading.Text = "Heading: " & MyGlobal.MyHeading
                    FormEstado.lb1Altitude.Text = "Alt:" & MyGlobal.MyAltitude
                    '---display the lat and lng---
                    FormEstado.lb1Lat.Text = "Lat:" & MyGlobal.MyLatitud
                    FormEstado.lb1Lng.Text = "Lng:" & MyGlobal.MyLongitud
                    FormEstado.Lb1Time.Text = "UTC:" & position.Time.ToString()
                    FormEstado.LabelEstado.Text = "Number Satellites: " & 0
                End If
            End If
        End If
    End Sub


    Private Sub FormInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MenuItem5.Enabled = True
        MenuItem6.Enabled = False
        MyGlobal.MySpeed = 0
        MyGlobal.MyHeading = 0
        MyGlobal.MyAltitude = 0
        MyGlobal.MyLatitud = -32.9337
        MyGlobal.MyLongitud = -71.53867

        Try
            AddHandler mygps.DeviceStateChanged, AddressOf gps_DeviceState_Changed
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return
        End Try
        Try
            AddHandler mygps.LocationChanged, AddressOf gps_Location_changed
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return
        End Try

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Try
            mygps.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return
        End Try

        If mygps.Opened Then
            '---disable the Connect GPS menu item---
            MenuItem5.Enabled = False
            '---enable the Disconnect menu item---
            MenuItem6.Enabled = True
        Else
            MsgBox("Failed to open")
        End If

    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Try
            mygps.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return
        End Try
        MenuItem5.Enabled = True  '---Connect GPS---
        MenuItem6.Enabled = False '---Disconnect---
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        If mygps.Opened Then
            mygps.Close()
        Else
            MsgBox("Failed to close GPS")
        End If
        Me.Close()
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        FormEstado.Show()

    End Sub


    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        FormConduccion.Show()

    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        FormContenedor.Show()

    End Sub
End Class
