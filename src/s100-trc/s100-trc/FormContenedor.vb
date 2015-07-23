Public Class FormContenedor

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Hide()

    End Sub

    Private Sub FormContenedor_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.Hide()

    End Sub

    Private Sub ButtonEnviarEstadoContenedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviarEstadoContenedor.Click
        Dim postData As String = ""
        Dim porcentajellenado As Double
        Dim szFalla As String
        Dim Contador As Integer
        ButtonEnviarEstadoContenedor.Enabled = False


        postData = postData & "&idcontenedor=" & TextBoxIdContenedor.Text

        If RadioButtonLlenado0.Checked = True Then
            porcentajellenado = 0
        ElseIf RadioButtonLlenado1.Checked = True Then
            porcentajellenado = 25
        ElseIf RadioButtonLlenado2.Checked = True Then
            porcentajellenado = 50
        ElseIf RadioButtonLlenado3.Checked = True Then
            porcentajellenado = 75
        ElseIf RadioButtonLlenado4.Checked = True Then
            porcentajellenado = 100
        ElseIf RadioButtonLlenado5.Checked = True Then
            porcentajellenado = 125
        Else
            porcentajellenado = 0
        End If

        postData = postData & "&porcentajellenado=" & porcentajellenado


        If RadioButtonSoporte1.Checked = True Then
            szFalla = "MALO"
        ElseIf RadioButtonSoporte2.Checked = True Then
            szFalla = "REGULAR"
        ElseIf RadioButtonSoporte3.Checked = True Then
            szFalla = "BUENO"
        Else
            szFalla = "BUENO"
        End If

        postData = postData & "&falla_soporte=" & szFalla


        If RadioButtonTapas1.Checked = True Then
            szFalla = "MALO"
        ElseIf RadioButtonTapas2.Checked = True Then
            szFalla = "REGULAR"
        ElseIf RadioButtonTapas3.Checked = True Then
            szFalla = "BUENO"
        Else
            szFalla = "BUENO"
        End If

        postData = postData & "&falla_tapa=" & szFalla


        If RadioButtonPedal1.Checked = True Then
            szFalla = "MALO"
        ElseIf RadioButtonPedal2.Checked = True Then
            szFalla = "REGULAR"
        ElseIf RadioButtonPedal3.Checked = True Then
            szFalla = "BUENO"
        Else
            szFalla = "BUENO"
        End If

        postData = postData & "&falla_pedal=" & szFalla


        If RadioButtonTina1.Checked = True Then
            szFalla = "MALO"
        ElseIf RadioButtonTina2.Checked = True Then
            szFalla = "REGULAR"
        ElseIf RadioButtonTina3.Checked = True Then
            szFalla = "BUENO"
        Else
            szFalla = "BUENO"
        End If

        postData = postData & "&falla_tina=" & szFalla

        If RadioButtonSenal1.Checked = True Then
            szFalla = "MALO"
        ElseIf RadioButtonSenal2.Checked = True Then
            szFalla = "REGULAR"
        ElseIf RadioButtonSenal3.Checked = True Then
            szFalla = "BUENO"
        Else
            szFalla = "BUENO"
        End If

        postData = postData & "&falla_senal=" & szFalla

        Contador = 0
        If TextBoxIdContenedor.Text.Length > 0 Then
            Contador = Contador + 1
        End If
        If RadioButtonLlenado0.Checked = True Or RadioButtonLlenado1.Checked Or RadioButtonLlenado2.Checked Or RadioButtonLlenado3.Checked Or RadioButtonLlenado4.Checked Or RadioButtonLlenado5.Checked Then
            Contador = Contador + 1
        End If
        If RadioButtonSoporte1.Checked = True Or RadioButtonSoporte2.Checked Or RadioButtonSoporte3.Checked Then
            Contador = Contador + 1
        End If
        If RadioButtonTapas1.Checked = True Or RadioButtonTapas2.Checked Or RadioButtonTapas3.Checked Then
            Contador = Contador + 1
        End If
        If RadioButtonPedal1.Checked = True Or RadioButtonPedal2.Checked Or RadioButtonPedal3.Checked Then
            Contador = Contador + 1
        End If
        If RadioButtonTina1.Checked = True Or RadioButtonTina2.Checked Or RadioButtonTina3.Checked Then
            Contador = Contador + 1
        End If
        If RadioButtonSenal1.Checked = True Or RadioButtonSenal2.Checked Or RadioButtonSenal3.Checked Then
            Contador = Contador + 1
        End If

        If Contador = 7 Then
            StatusBarContenedor.Text = "Enviando datos ..."

            Try
                If Sync.ReportaEstadoContenedor(20, postData) = -1 Then
                    StatusBarContenedor.Text = "Falla en el servidor"
                Else
                    StatusBarContenedor.Text = "OK"
                End If
            Catch ex As Exception
                StatusBarContenedor.Text = "Falló envio de datos"
            End Try
        Else
            StatusBarContenedor.Text = "Falta completar datos ..."
        End If
        ButtonEnviarEstadoContenedor.Enabled = True

    End Sub

    Private Sub ButtonLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLimpiar.Click
        StatusBarContenedor.Text = "Estado Contenedor"
        TextBoxIdContenedor.Text = ""
        RadioButtonLlenado0.Checked = False
        RadioButtonLlenado1.Checked = False
        RadioButtonLlenado2.Checked = False
        RadioButtonLlenado3.Checked = False
        RadioButtonLlenado4.Checked = False


        RadioButtonSoporte1.Checked = False
        RadioButtonSoporte2.Checked = False
        RadioButtonSoporte3.Checked = False

        RadioButtonTapas1.Checked = False
        RadioButtonTapas2.Checked = False
        RadioButtonTapas3.Checked = False


        RadioButtonPedal1.Checked = False
        RadioButtonPedal2.Checked = False
        RadioButtonPedal3.Checked = False

        RadioButtonTina1.Checked = False
        RadioButtonTina2.Checked = False
        RadioButtonTina3.Checked = False

        RadioButtonSenal1.Checked = False
        RadioButtonSenal2.Checked = False
        RadioButtonSenal3.Checked = False


    End Sub
End Class