Imports ConsultasVarias.Clases.Query
Imports ConsultasVarias.Clases.Helper
Public Class IngresoPedidoDesarrollo



    Sub New(Optional ByVal Pedido As String = "0")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Val(Pedido) <> 0 Then

            Dim SQLCnslt As String = "SELECT Pedido, Fecha, Cliente, Vendedor, Observaciones, Material, Muestra, " _
            & "Uso, DescripcionI, DescripcionII, DescripcionIII, DescripcionIV, DescripcionV, " _
            & "ObservacionesI, ObservacionesII, ObservacionesIII, Volumen, Costo, EstadoLabora, " _
            & "RequisitoI, RequisitoII, RequisitoIII, RequisitoIV, RequisitoV, RequisitoVI," _
            & "ReferenciaI, ReferenciaII, ReferenciaIII " _
            & "FROM PedidoOrdenTrabajo WHERE Pedido = '" & Val(Pedido) & "'"

            Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If row IsNot Nothing Then
                With row
                    txtPedido.Text = .Item("Pedido")
                    txtFecha.Text = .Item("Fecha")
                    txtCodCliente.Text = .Item("Cliente")
                    txtCodCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    txtCodVendedor.Text = .Item("Vendedor")
                    txtCodVendedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                    txtTitulo.Text = .Item("Observaciones")
                    TxtMaterial.Text = .Item("Material")
                    txtMuestra.Text = .Item("Muestra")
                    txtUso.Text = .Item("Uso")
                    txtDescripcion.Text = Trim(.Item("DescripcionI") & .Item("DescripcionII") & .Item("DescripcionIII") & .Item("DescripcionIV") & .Item("DescripcionV"))
                    txtObservaciones.Text = Trim(.Item("ObservacionesI") & .Item("ObservacionesII") & .Item("ObservacionesIII"))
                    txtVolumen.Text = .Item("Volumen")
                    txtCosto.Text = .Item("Costo")
                    txtRequisito.Text = Trim(.Item("RequisitoI") & .Item("RequisitoII"))
                    txtOtrosRequisitos.Text = Trim(.Item("RequisitoIII") & .Item("RequisitoIV"))
                    txtRequisitosLegales.Text = Trim(.Item("RequisitoV") & .Item("RequisitoVI"))
                    txtReferencia1.Text = .Item("ReferenciaI")
                    txtReferencia2.Text = .Item("ReferenciaII")
                    txtReferencia3.Text = .Item("ReferenciaIII")
                    btnAutorizar.Visible = True
                End With
            End If
        End If

    End Sub



    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumen.KeyPress, txtCosto.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodVendedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub CompletarConVacios()
        txtDescripcion.Text = txtDescripcion.Text.PadRight(250, " ")
        txtObservaciones.Text = txtObservaciones.Text.PadRight(150, " ")
        txtRequisito.Text = txtRequisito.Text.PadRight(100, " ")
        txtOtrosRequisitos.Text = txtOtrosRequisitos.Text.PadRight(100, " ")
        txtRequisitosLegales.Text = txtRequisitosLegales.Text.PadRight(100, " ")
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        If ValidaFecha(txtFecha.Text) = "N" Then
            MsgBox("La fecha ingresada no es una fecha valida, por favor corrija y vuelva a intentar grabar")
        Else
            Dim SQLCnslt As String = ""
            Dim WPedido As String
            Dim WOrdFecha As String = ordenaFecha(txtFecha.Text)
            Dim WEstadoLabora As String = ""
            CompletarConVacios()

            If Val(txtPedido.Text) = 0 Then
                SQLCnslt = "SELECT PedidoMayor = Max(Pedido) FROM PedidoOrdenTrabajo"
                Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If Row IsNot Nothing Then
                    WPedido = Row.Item("PedidoMayor") + 1
                Else
                    WPedido = 1
                End If


                SQLCnslt = "INSERT INTO PedidoOrdenTrabajo ( Pedido, Fecha, OrdFecha, Cliente, Vendedor, Observaciones, " _
                         & "Material, Muestra, Uso, DescripcionI, DescripcionII, DescripcionIII, DescripcionIV, DescripcionV, " _
                         & "Respuesta, RespuestaI, RespuestaII, RespuestaIII, RespuestaIV, RespuestaV, RespuestaVI, " _
                         & "ObservacionesI, ObservacionesII, ObservacionesIII, Volumen, Costo, Destino, CodigoOrden, " _
                         & "EstadoLabora, RequisitoI, RequisitoII, RequisitoIII, RequisitoIV, RequisitoV, RequisitoVI, " _
                         & "ReferenciaI, ReferenciaII, ReferenciaIII) " _
                         & "Values ( '" & WPedido & "', '" & txtFecha.Text & "', '" & WOrdFecha & "', '" & txtCodCliente.Text & "', " _
                         & "'" & txtCodVendedor.Text & "', '" & txtTitulo.Text & "', '" & TxtMaterial.Text & "', '" & txtMuestra.Text & "', " _
                         & "'" & txtUso.Text & "', '" & txtDescripcion.Text.Substring(0, 50) & "', '" & txtDescripcion.Text.Substring(50, 50) & "', " _
                         & "'" & txtDescripcion.Text.Substring(100, 50) & "', '" & txtDescripcion.Text.Substring(150, 50) & "', '" & txtDescripcion.Text.Substring(200, 50) & "', " _
                         & "'" & "0" & "' , '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & "" & "' , '" & "" & "' , " _
                         & "'" & txtObservaciones.Text.Substring(0, 50) & "' , '" & txtObservaciones.Text.Substring(50, 50) & "' , '" & txtObservaciones.Text.Substring(100, 50) & "' , " _
                         & "'" & txtVolumen.Text & "' , '" & txtCosto.Text & "' , '" & "0" & "' , '" & "" & "' , '" & WEstadoLabora & "' , " _
                         & "'" & txtRequisito.Text.Substring(0, 50) & "' , '" & txtRequisito.Text.Substring(50, 50) & "' , '" & txtOtrosRequisitos.Text.Substring(0, 50) & "' , " _
                         & "'" & txtOtrosRequisitos.Text.Substring(50, 50) & "' , '" & txtRequisitosLegales.Text.Substring(0, 50) & "' , " _
                         & "'" & txtRequisitosLegales.Text.Substring(50, 50) & "' , '" & txtReferencia1.Text & "' , '" & txtReferencia2.Text & "' , " _
                         & "'" & txtReferencia3.Text & "')"


                ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

                MsgBox("Se asigno el numero de pedido " + WPedido)
            Else

                SQLCnslt = "SELECT Pedido FROM PedidoOrdenTrabajo WHERE Pedido = '" & txtPedido.Text & "'"
                Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If row IsNot Nothing Then

                    SQLCnslt = "UPDATE PedidoOrdenTrabajo SET Fecha = '" & txtFecha.Text & "', " _
                             & "OrdFecha = '" & WOrdFecha & "', " _
                             & "Cliente = '" & txtCodCliente.Text & "', " _
                             & "Vendedor = '" & txtCodVendedor.Text & "', " _
                             & "Observaciones = '" & txtTitulo.Text & "', " _
                             & "Material = '" & TxtMaterial.Text & "', " _
                             & "Muestra = '" & txtMuestra.Text & "', " _
                             & "Uso = '" & txtUso.Text & "', " _
                             & "DescripcionI = '" & txtDescripcion.Text.Substring(0, 50) & "', " _
                             & "DescripcionII = '" & txtDescripcion.Text.Substring(50, 50) & "', " _
                             & "DescripcionIII = '" & txtDescripcion.Text.Substring(100, 50) & "', " _
                             & "DescripcionIV = '" & txtDescripcion.Text.Substring(150, 50) & "', " _
                             & "DescripcionV = '" & txtDescripcion.Text.Substring(200, 50) & "', " _
                             & "ObservacionesI = '" & txtObservaciones.Text.Substring(0, 50) & "', " _
                             & "ObservacionesII = '" & txtObservaciones.Text.Substring(50, 50) & "', " _
                             & "ObservacionesIII = '" & txtObservaciones.Text.Substring(100, 50) & "', " _
                             & "Volumen = '" & txtVolumen.Text & "', " _
                             & "Costo = '" & txtCosto.Text & "', " _
                             & "EstadoLabora = '" & WEstadoLabora & "', " _
                             & "RequisitoI = '" & txtRequisito.Text.Substring(0, 50) & "', " _
                             & "RequisitoII = '" & txtRequisito.Text.Substring(50, 50) & "', " _
                             & "RequisitoIII = '" & txtOtrosRequisitos.Text.Substring(0, 50) & "', " _
                             & "RequisitoIV = '" & txtOtrosRequisitos.Text.Substring(50, 50) & "', " _
                             & "RequisitoV = '" & txtRequisitosLegales.Text.Substring(0, 50) & "', " _
                             & "RequisitoVI = '" & txtRequisitosLegales.Text.Substring(50, 50) & "', " _
                             & "ReferenciaI = '" & txtReferencia1.Text & "', " _
                             & "ReferenciaII = '" & txtReferencia2.Text & "', " _
                             & "ReferenciaIII = '" & txtReferencia3.Text & "' " _
                             & "WHERE Pedido = '" & txtPedido.Text & "'"

                    ExecuteNonQueries({SQLCnslt}, "SurfactanSa")


                End If


            End If
            Dim WOwner As IOrdenDeTrabajoDesarrollo = TryCast(Owner, IOrdenDeTrabajoDesarrollo)
            If WOwner IsNot Nothing Then
                WOwner._ProcesarDatosOrdenDesarrollo()
            End If
            Close()
        End If

    End Sub

    Private Sub IngresoPedidoDesarrollo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Text = Date.Today.ToString("dd/MM/yyyy")
    End Sub

    Private Sub IngresoPedidoDesarrollo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCodCliente.Focus()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtFecha.Text = ""
        txtCodCliente.Text = ""
        txtDescpCliente.Text = ""
        txtCodVendedor.Text = ""
        txtDescripVendedor.Text = ""
        txtTitulo.Text = ""
        TxtMaterial.Text = ""
        txtMuestra.Text = ""
        txtUso.Text = ""
        txtDescripcion.Text = ""
        txtObservaciones.Text = ""
        txtVolumen.Text = ""
        txtCosto.Text = ""
        txtRequisito.Text = ""
        txtOtrosRequisitos.Text = ""
        txtRequisitosLegales.Text = ""
        txtReferencia1.Text = ""
        txtReferencia2.Text = ""
        txtReferencia3.Text = ""
    End Sub

    Private Sub txtAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        With New AutorizarOrdenTrabajo(txtPedido.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txtFecha.Text) = "N" Then
                    MsgBox("La fecha ingresada no es una fecha valida")
                Else
                    txtCodCliente.Focus()
                End If
            Case Keys.Escape
                txtFecha.Text = ""
        End Select
        
    End Sub

    Private Sub txtCodCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodCliente.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = "SELECT Razon FROM Cliente Where Cliente = '" & txtCodCliente.Text & "'"

                Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If row IsNot Nothing Then

                    txtDescpCliente.Text = row.Item("Razon")
                    txtCodVendedor.Focus()
                End If
            Case Keys.Escape
                txtCodCliente.Text = ""
        End Select
    End Sub

    Private Sub txtCodVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodVendedor.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = "SELECT Nombre FROM Vendedor Where Vendedor = '" & txtCodVendedor.Text & "'"

                Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If row IsNot Nothing Then

                    txtDescripVendedor.Text = row.Item("Nombre")
                    txtTitulo.Focus()
                End If
            Case Keys.Escape
                txtCodVendedor.Text = ""
        End Select
    End Sub

    Private Sub txtTitulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitulo.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtTitulo.Text = ""
        End Select
    End Sub
   

    Private Sub TxtMaterial_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMaterial.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtMuestra.Focus()
            Case Keys.Escape
                TxtMaterial.Text = ""
        End Select
    End Sub

    Private Sub txtMuestra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMuestra.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtUso.Focus()
            Case Keys.Escape
                txtMuestra.Text = ""
        End Select
    End Sub

    Private Sub txtUso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUso.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtDescripcion.Focus()
            Case Keys.Escape
                txtUso.Text = ""
        End Select
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtObservaciones.Focus()
            Case Keys.Escape
                txtDescripcion.Text = ""
        End Select
    End Sub

    Private Sub txtObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservaciones.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtVolumen.Focus()
            Case Keys.Escape
                txtObservaciones.Text = ""
        End Select
    End Sub

    Private Sub txtVolumen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVolumen.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtCosto.Focus()
            Case Keys.Escape
                txtVolumen.Text = ""
        End Select
    End Sub

    Private Sub txtCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtCosto.Text = ""
        End Select
    End Sub

  
    Private Sub txtRequisito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRequisito.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtOtrosRequisitos.Focus()
            Case Keys.Escape
                txtRequisito.Text = ""
        End Select
    End Sub

    Private Sub txtOtrosRequisitos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtrosRequisitos.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtRequisitosLegales.Focus()
            Case Keys.Escape
                txtOtrosRequisitos.Text = ""
        End Select
    End Sub

    Private Sub txtRequisitosLegales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRequisitosLegales.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReferencia1.Focus()
            Case Keys.Escape
                txtRequisitosLegales.Text = ""
        End Select
    End Sub

    Private Sub txtReferencia1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferencia1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReferencia2.Focus()
            Case Keys.Escape
                txtReferencia1.Text = ""
        End Select
    End Sub

    Private Sub txtReferencia2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferencia2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtReferencia3.Focus()
            Case Keys.Escape
                txtReferencia2.Text = ""
        End Select
    End Sub

    Private Sub txtReferencia3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferencia3.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtReferencia3.Text = ""
        End Select
    End Sub
End Class