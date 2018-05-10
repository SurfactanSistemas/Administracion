Imports System.Data.SqlClient
Imports System.Data
Imports System.Media

Public Class Principal

    Private WTiempoFuera = 0
    Private WTiempoFueraTranscurrido = 0
    Private WAcumulaPartida As String = 0

    Enum Tipo
        Exito
        Falla
    End Enum

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        txtCodigoGral.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
        pnlMsg.Location = New Point(10, 10)
        pnlMsg.Width = Me.Width - 25
        pnlMsg.Height = Me.Height - 45

        lblMensajeestado.Location = New Point(pnlMsg.Width / 2 - lblMensajeestado.Width / 2, lblMensajeestado.Location.Y)
        pnlMsg.Visible = False
        lblMensajeestado.Text = ""
        picError.Visible = False
        picExito.Visible = False
    End Sub

    Private Sub MostrarMsgError(ByVal msg As Object, Optional ByVal WTipo As Tipo = Tipo.Exito, Optional ByVal WTiempo As Integer = 5)

        pnlMsg.Visible = True

        lblMensajeestado.Text = msg

        picExito.Visible = WTipo = Tipo.Exito
        picError.Visible = WTipo = Tipo.Falla

        '
        ' Reproducimos sonidos de exito o error segun corresponda.
        '


        Select Case WTipo
            Case Tipo.Exito
                Dim player As New SoundPlayer(New IO.MemoryStream(My.Resources.Success))
                player.Play()
            Case Tipo.Falla
                Dim player As New SoundPlayer(New IO.MemoryStream(My.Resources.CriticalStop))
                player.Play()
            Case Else

        End Select


        lblCuentaRegresiva.Text = ""
        Timer1.Enabled = True

        WTiempoFueraTranscurrido = 0
        WTiempoFuera = WTiempo

    End Sub

    Private Sub OcultarMsgEstado(Optional ByVal WTiempo = 5)
        pnlMsg.Visible = False
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        txtCodigoCliente.Text = ""
        txtCodigoGral.Text = ""
        txtPartida.Text = ""

        lblCuentaRegresiva.Text = ""

        txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)
        txtTotalPedido.Text = GenerarStringCantidad(0)

        'pnlMsg.Visible = False
        'lblMensajeEstado.Text = ""
        'picError.Visible = False
        'picExito.Visible = False

        txtCodProd.Text = ""
        txtDescProd.Text = ""

        txtCodigoGral.Focus()

    End Sub

    Private Function GenerarStringCantidad(ByVal WCantidad As Object)

        Return NormalizarNumero(WCantidad, 2) & " " & "Kg(s)"

    End Function

    Private Function NormalizarNumero(ByVal WNumero, Optional ByVal WDecimales = 2) As String

        Return Helper.formatonumerico(WNumero)

    End Function

    Private Sub CamposCodigos_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoGral.GotFocus, txtCodigoCliente.GotFocus, txtCandidad.GotFocus, txtCodProd.GotFocus, txtDescProd.GotFocus, txtPartida.GotFocus
        Dim campo As TextBox = sender

        campo.BackColor = Color.Cyan
    End Sub

    Private Sub CamposCodigos_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoGral.LostFocus, txtCodigoCliente.LostFocus, txtCandidad.LostFocus, txtCodProd.LostFocus, txtDescProd.LostFocus, txtPartida.LostFocus
        Dim campo As TextBox = sender

        campo.BackColor = Color.White
    End Sub

    Private Sub txtCodigoGral_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoGral.KeyDown, txtCodProd.KeyDown, txtDescProd.KeyDown, txtPartida.KeyDown

        If e.KeyData = Keys.Enter Then
            Try
                If Trim(txtCodigoGral.Text) = "" Then : Exit Sub : End If

                Dim WCod = txtCodigoGral.Text.Trim()

                '
                ' Comprobamos que tenga el formato correcto (6 Dígitos para la Partida y 1 para indicar el Tipo)
                '
                If WCod.Length <> 7 Then
                    Throw New Exception("La Lectura no tiene el formato correcto.")
                End If

                '
                ' Comprobamos que se trate de una etiqueta general.
                '
                If Mid(WCod, 7, 1) <> "1" Then
                    Throw New Exception("La Lectura no tiene el formato correcto.")
                End If

                '
                ' Comprobamos que la Partida, sea una partida válida.
                '
                Dim WPartida = Mid(WCod, 1, 6)
                Dim WProd As New DataTable

                WProd = _PartidaValida(WPartida)

                If WProd.Rows.Count = 0 Then
                    Throw New Exception("La Hoja es inexistente")
                End If

                If WPartida <> WAcumulaPartida Then
                    txtCandidad.Text = "0"
                    txtSuma.Text = GenerarStringCantidad(0)
                    WAcumulaPartida = WPartida
                End If

                txtCodProd.Text = WProd.Rows(0).Item("Producto")
                txtDescProd.Text = WProd.Rows(0).Item("Descripcion")
                txtPartida.Text = WPartida

                txtCodigoCliente.Focus()
            Catch ex As Exception
                MostrarMsgError(ex.Message, Tipo.Falla)
                With txtCodigoGral
                    .Text = ""
                    .Focus()
                End With
            End Try

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoGral.Text = ""
        End If

    End Sub

    Private Function _PartidaValida(ByVal WPartida) As DataTable

        Dim WTabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Hoja.Hoja, Hoja.Producto, RTRIM(LTRIM(ISNULL(Terminado.Descripcion, ''))) as Descripcion FROM Hoja LEFT OUTER JOIN Terminado ON Hoja.Producto = Terminado.Codigo WHERE Hoja = '" & WPartida & "' AND Renglon = '1'")
        Dim dr As SqlDataReader

        Try
            Dim empresas() As Integer = {1, 3, 5, 6, 7} ', 10, 11}

            For Each i As Integer In empresas
                cn.ConnectionString = Helper._ConectarA(i)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                WTabla.Load(dr)

                dr.Close()
                cn.Close()

                If WTabla.Rows.Count > 0 Then Exit For
            Next

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la hoja desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WTabla
    End Function

    Private Sub txtCodigoCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyDown, txtCandidad.KeyDown

        If e.KeyData = Keys.Enter Then
            Try
                If Trim(txtCodigoGral.Text) = "" Then : Exit Sub : End If
                If Trim(txtCodigoCliente.Text) = "" Then : Exit Sub : End If

                Dim WCod = txtCodigoCliente.Text.Trim()
                Dim WTerminado = "", WPartida = "", WPedido = "", WCantidad = 0.0, WEnteros = 0, WDecimales = 0

                Dim WPartidaGral = Mid(txtCodigoGral.Text, 1, 6)

                '
                ' Comprobamos que tenga el formato correcto (6 Dígitos para la Partida, 1 para indicar el Tipo, 6 para Pedido y 6 para cantidad (4 para enteros y 2 para digitos. Ej: 145.5 -> 014550 ))
                '
                If WCod.Length <> 19 Then
                    Throw New Exception("La Lectura no tiene el formato correcto.")
                End If

                '
                ' Comprobamos que se trate de una etiqueta general.
                '
                If Mid(WCod, 7, 1) <> "2" Then
                    Throw New Exception("La Lectura no tiene el formato correcto.")
                End If

                '
                ' Controlamos que las partidas se correspondan.
                '
                WPartida = Mid(WCod, 1, 6)

                If Val(WPartidaGral) <> Val(WPartida) Then
                    Throw New Exception("Las Etiquetas no corresponden a la misma Hoja.")
                End If

                '
                ' Extraemos el numero de Pedido.
                '
                WPedido = Mid(WCod, 8, 6)
                WTerminado = _BuscarTerminado(WPartida)

                If Trim(WTerminado) = "" Then
                    Throw New Exception("No se ha podido encontrar el Codigo del Producto para la Hoja " & WPartida)
                End If

                '
                ' Controlamos que en el pedido exista el codigo.
                '
                If Not TerminadoEnPedido(WTerminado, WPedido) Then
                    Throw New Exception("El Producto no se encuentra el producto en el Pedido")
                End If

                '
                ' Controlo que en alguno de los campos de Lote se encuentre cargada la Partida.
                '
                If Not PartidaDeTerminadoEnPedido(WPartida, WTerminado, WPedido) Then
                    Throw New Exception("La Hoja no se encuentra en el Pedido")
                End If

                '
                ' Armamos la cantidad.
                '
                WEnteros = Mid(WCod, 14, 4)
                WDecimales = Mid(WCod, 18, 2)

                Dim a = (WEnteros & "." & WDecimales)

                WCantidad = Val(a)

                Dim WAux = CDbl(txtCandidad.Text)

                WAux += WCantidad

                txtCandidad.Text = WAux

                txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)

                MostrarMsgError("¡Lectura Correcta!", Tipo.Exito, 2)

                btnLimpiar_Click(Nothing, Nothing)

            Catch ex As Exception
                MostrarMsgError(ex.Message, Tipo.Falla)
                With txtCodigoCliente
                    .Text = ""
                    .Focus()
                End With
            End Try
        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoCliente.Text = ""
        End If

    End Sub

    Private Function PartidaDeTerminadoEnPedido(ByVal WPartida, ByVal WTerminado, ByVal WPedido)

        Dim WExiste = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Terminado FROM Pedido WHERE Pedido = '" & WPedido & "' AND Terminado  = '" & WTerminado & "' AND (Lote1 = '" & WPartida & "' OR Lote2 = '" & WPartida & "' OR Lote3 = '" & WPartida & "' OR Lote4 = '" & WPartida & "' OR Lote5 = '" & WPartida & "' OR UltimoLote1 = '" & WPartida & "' OR UltimoLote2 = '" & WPartida & "' OR UltimoLote3 = '" & WPartida & "' OR UltimoLote4 = '" & WPartida & "' OR UltimoLote5 = '" & WPartida & "' )")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Do While dr.Read()
                WExiste = True
            Loop

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia de la partida en el pedido desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WExiste

    End Function

    Private Function TerminadoEnPedido(ByVal WTerminado, ByVal WPedido)

        Dim WExiste = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Terminado FROM Pedido WHERE Pedido = '" & WPedido & "' AND Terminado  = '" & WTerminado & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Do While dr.Read()
                WExiste = True
            Loop

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Producto en el Pedido desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WExiste

    End Function

    Private Function _BuscarTerminado(ByVal WPartida) As String

        Dim WTerminado = ""
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Producto FROM Hoja WHERE Hoja = '" & WPartida & "' AND Renglon = 1")
        Dim dr As SqlDataReader

        Try
            Dim empresas() As Integer = {1, 3, 5, 6, 7, 10, 11}

            For Each i In empresas
                cn.ConnectionString = Helper._ConectarA(i)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                Do While dr.Read()
                    WTerminado = dr.Item("Producto")
                Loop

                cn.Close()

                If WTerminado <> "" Then Exit For
            Next

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el Codigo del Producto desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return WTerminado

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        WTiempoFueraTranscurrido += Timer1.Interval

        If WTiempoFueraTranscurrido >= WTiempoFuera * 1000 Then
            Call OcultarMsgEstado(10)
            Timer1.Enabled = False
            WTiempoFueraTranscurrido = 0
            lblCuentaRegresiva.Text = ""
        End If

        lblCuentaRegresiva.Text = "Mensaje se cierra en " & Str((WTiempoFuera - (WTiempoFueraTranscurrido / 1000))) & " Seg(s)"
    End Sub

    Private Sub txtCodigoGral_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoGral.KeyPress, txtCodProd.KeyPress, txtDescProd.KeyPress, txtPartida.KeyPress
        If pnlMsg.Visible Then e.Handled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        txtCodigoCliente.Text = ""
        txtCodigoGral.Text = ""
        txtPartida.Text = ""

        lblCuentaRegresiva.Text = ""

        txtCandidad.Text = "0"
        txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)
        txtTotalPedido.Text = GenerarStringCantidad(0)

        'pnlMsg.Visible = False
        'lblMensajeEstado.Text = ""
        'picError.Visible = False
        'picExito.Visible = False

        txtCodProd.Text = ""
        txtDescProd.Text = ""

        txtCodigoGral.Focus()

    End Sub
End Class