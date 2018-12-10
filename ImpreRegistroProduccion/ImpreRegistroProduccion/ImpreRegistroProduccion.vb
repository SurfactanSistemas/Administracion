Public Class ImpreRegistroProduccion

    Private Sub ImpreRegistroProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If Environment.GetCommandLineArgs.Length > 1 Then

                Dim WTerminado As String = Environment.GetCommandLineArgs(1)
                Dim WPartida As Integer = Environment.GetCommandLineArgs(2)
                Dim WProceso As Integer = 0

                If Environment.GetCommandLineArgs.Length > 2 Then
                    WProceso = Environment.GetCommandLineArgs(3)
                End If
                
                Select Case WProceso
                    Case 1

                    Case Else
                        _GenerarRegistroProduccion(WTerminado, WPartida)
                End Select

            End If

            Dim WTerminado2 As String = "PT-25019-100"
            Dim WPartida2 As Integer = "308665"

            _GenerarRegistroProduccion(WTerminado2, WPartida2)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Close()

    End Sub

    Private Sub _GenerarRegistroProduccion(ByVal WTerminado As String, ByVal WPartida As Integer)


        Dim WEscrito = 0

        Dim WTer As DataRow = GetSingle("SELECT Escrito FROM Terminado WHERE Codigo = '" & WTerminado & "'")

        If WTer Is Nothing Then Close()

        WEscrito = OrDefault(WTer.Item("Escrito"), 0)

        Dim WImprePlanilla = 0
        Dim WImprePlanillaII = 0
        Dim WImprePlanillaIII = 0

        Dim WCargaIII As DataRow = GetSingle("SELECT ImprimePlanilla, ImprimePlanillaII, ImprimePlanillaIII FROM CargaIII WHERE Terminado = '" & WTerminado & "'", "Surfactan_III")

        If WCargaIII Is Nothing Then Close()

        WImprePlanilla = OrDefault(WCargaIII.Item("ImprimePlanilla"), 0)
        WImprePlanillaII = OrDefault(WCargaIII.Item("ImprimePlanillaII"), 0)
        WImprePlanillaIII = OrDefault(WCargaIII.Item("ImprimePlanillaIII"), 0)

        Dim WMostrarHumedad As Integer = 0

        Dim WHumedad As DataRow = GetSingle("SELECT Humedad FROM CargaIII WHERE Terminado = '" & WTerminado & "' AND Humedad = 1 And Renglon = 1")

        If Not IsNothing(WHumedad) Then WMostrarHumedad = 1

        Dim rpt As New ImpreFarmaI

        rpt.SetParameterValue("MostrarHumedad", WMostrarHumedad)

        Dim frm As New VistaPrevia

        With frm
            .Reporte = rpt
            .Formula = "{Hoja.Hoja} = " & WPartida & " And {Hoja.Producto} = '" & WTerminado & "'"
            .Mostrar()
            '.Imprimir()
        End With
    End Sub
End Class
