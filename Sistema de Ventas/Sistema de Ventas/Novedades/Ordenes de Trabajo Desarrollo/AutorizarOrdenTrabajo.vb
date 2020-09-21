Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class AutorizarOrdenTrabajo

    Dim WPedido As String

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub



    Sub New(Optional ByVal Pedido As String = "0")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        WPedido = Pedido

        If Val(Pedido) <> 0 Then
            Dim SQLCnslt As String = "SELECT Respuesta, RespuestaI, RespuestaII, RespuestaIII, RespuestaIV, RespuestaV, RespuestaVI, " _
                                 & "Destino, CodigoOrden FROM PedidoOrdenTrabajo WHERE Pedido = '" & WPedido & "'"

            Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If row IsNot Nothing Then
                With row
                    cbxRespuesta.SelectedIndex = .Item("Respuesta")
                    txtObservacionesAutorizo.Text = Trim(.Item("RespuestaI") & .Item("RespuestaII") & .Item("RespuestaIII"))
                    cbxDestino.SelectedIndex = .Item("Destino")
                    txtCodDesarrollo.Text = .Item("CodigoOrden")
                    txtObservacionesLaboratorio.Text = Trim(.Item("RespuestaIV") & .Item("RespuestaV") & .Item("RespuestaVI"))
                End With
            End If
        End If

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        If MsgBox("¿Desea grabar estos cambios de Autorización?", vbYesNo) = vbYes Then

            txtObservacionesAutorizo.Text = txtObservacionesAutorizo.Text.PadRight(150, " ")
            txtObservacionesLaboratorio.Text = txtObservacionesLaboratorio.Text.PadRight(150, " ")


            Dim SQLCnslt As String = "UPDATE PedidoOrdenTrabajo SET " _
                                     & "Respuesta = '" & cbxRespuesta.SelectedIndex & "', " _
                                     & "RespuestaI = '" & txtObservacionesAutorizo.Text.Substring(0, 50) & "', " _
                                     & "RespuestaII = '" & txtObservacionesAutorizo.Text.Substring(50, 50) & "', " _
                                     & "RespuestaIII = '" & txtObservacionesAutorizo.Text.Substring(100, 50) & "', " _
                                     & "RespuestaIV = '" & txtObservacionesLaboratorio.Text.Substring(0, 50) & "', " _
                                     & "RespuestaV = '" & txtObservacionesLaboratorio.Text.Substring(50, 50) & "', " _
                                     & "RespuestaVI = '" & txtObservacionesLaboratorio.Text.Substring(100, 50) & "', " _
                                     & "Destino = '" & cbxDestino.SelectedIndex & "', " _
                                     & "CodigoOrden = '" & txtCodDesarrollo.Text & "' " _
                                     & "WHERE Pedido = '" & WPedido & "'"

            ExecuteNonQueries("SurfactanSa", {SQLCnslt})

            Close()

        End If

        
    End Sub

  
End Class