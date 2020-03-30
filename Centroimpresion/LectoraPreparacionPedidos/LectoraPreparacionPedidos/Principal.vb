Imports System.Data.SqlClient
Imports System.Data
Imports System.Media
Imports System.IO

Enum EstadoEtiq
    SinDefinir = 0
    Habilitada = 1
    Inhabilitada = 2
End Enum

Public Class Principal

    Private WTiempoFuera = 0
    Private WTiempoFueraTranscurrido = 0
    Private WAcumulaPartida As String = 0
    Private WTamanioPnl(2) As Integer

    Private WCodPedido As String = ""
    Private WConteoEtiquetas As New List(Of String)
    Private WCliente As String = ""

    Enum Tipo
        Exito
        Falla
    End Enum

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        txtCodigoGral.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.PortName = "COM7"
        btnLimpiar_Click(Nothing, Nothing)

        pnlMsg.Location = New Point(10, 10)
        pnlMsg.Width = Me.Width - 25
        pnlMsg.Height = Me.Height - 45

        With pnlCantidades
            .Width = 228
            .Height = 259
            .Visible = False
            .Location = New Point(5, 10)
        End With

        With pnlConfirmarEtiq
            .Width = 228
            .Height = 259
            .Visible = False
            .Location = New Point(5, 10)
        End With

        With pnlPedido
            .Width = 228
            .Height = 259
            .Visible = True
            .Location = New Point(5, 10)
        End With

        With pnlValidarContenedor
            .Width = 228
            .Height = 259
            .Visible = False
            .Location = New Point(5, 10)
        End With

        lblMensajeestado.Location = New Point(pnlMsg.Width / 2 - lblMensajeestado.Width / 2, lblMensajeestado.Location.Y)
        pnlMsg.Visible = False
        lblMensajeestado.Text = ""
        picError.Visible = False
        picExito.Visible = False
        pnlConsEtiqFinal.Visible = False

        txtCantEtiq.Text = "1"
        'txtCantEtiq.Enabled = False

        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Environment\LectoraControl")

        _TraerPuestos()

        ComboBox1.SelectedIndex = Val(Microsoft.Win32.Registry.CurrentUser.GetValue("PuestoTrabajo", "0"))

        txtCodPedido.Focus()

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

        txtCodigoGral.Text = ""
        txtPartida.Text = ""

        lblCuentaRegresiva.Text = ""

        txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)
        txtTotalPedido.Text = GenerarStringCantidad(0)

        txtCodProd.Text = ""

        txtCodPedido.Focus()

    End Sub

    Private Function GenerarStringCantidad(ByVal WCantidad As Object)

        Return NormalizarNumero(WCantidad, 2) & " " & "Kg(s)"

    End Function

    Private Function NormalizarNumero(ByVal WNumero, Optional ByVal WDecimales = 2) As String

        Return Helper.formatonumerico(WNumero)

    End Function

    Private Sub CamposCodigos_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoGral.GotFocus, txtCandidad.GotFocus, txtCodProd.GotFocus, txtPartida.GotFocus, txtPedido.GotFocus
        Dim campo As TextBox = sender

        campo.BackColor = Color.Cyan
    End Sub

    Private Sub CamposCodigos_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoGral.LostFocus, txtCandidad.LostFocus, txtCodProd.LostFocus, txtPartida.LostFocus, txtPedido.LostFocus
        Dim campo As TextBox = sender

        campo.BackColor = Color.White
    End Sub

    Private Sub txtCodigoGral_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoGral.KeyDown, txtCodProd.KeyDown, txtPartida.KeyDown, txtPedido.KeyDown

        If e.KeyCode = Keys.Enter Then
            Try
                If Trim(txtCodigoGral.Text) = "" Then : Exit Sub : End If

                WConteoEtiquetas.Clear()

                Dim WCod = txtCodigoGral.Text.Trim()

                '
                ' Comprobamos que tenga el formato correcto (6 Dígitos para la Partida y 1 para indicar el Tipo)
                '
                If WCod.Length <> 18 Then
                    Throw New Exception("La Lectura no tiene el formato correcto.")
                End If

                '
                ' Comprobamos que la Partida, sea una partida válida.
                '
                Dim WPartida = Microsoft.VisualBasic.Left(WCod, 6)
                Dim WProd As New DataTable

                WProd = _PartidaValida(WPartida)

                If WProd.Rows.Count = 0 Then
                    Throw New Exception("La Hoja es inexistente")
                End If

                txtCodProd.Text = WProd.Rows(0).Item("Producto")
                txtPartida.Text = WPartida

                txtUlt.Text = txtCodProd.Text
                txtUltPartida.Text = txtPartida.Text

                '
                ' Validamos los datos del Producto contra los Datos Cargados en el Pedido.
                '
                Dim WDatosPedido As DataTable = GetAll("SELECT Pedido, Terminado, Lote1, Lote2, Lote3, Lote4, Lote5, Lote6, Lote7, Lote8, Lote9, Lote10, Lote11, Lote12 FROM Pedido WHERE Pedido = '" & WCodPedido & "' And Terminado = '" & txtCodProd.Text & "'")

                Dim WPasa As Boolean = False

                For Each WDato As DataRow In WDatosPedido.Rows
                    If WDato.Item("Terminado") = txtCodProd.Text Then
                        WPasa = True
                        For i = 1 To 12
                            If Val(OrDefault(WDato.Item("Lote" & i), "")) <> 0 Then
                                WPasa = False
                                If Val(OrDefault(WDato.Item("Lote" & i), "")) = Val(txtPartida.Text) Then
                                    WPasa = True
                                    Exit For
                                End If
                            End If
                        Next
                        Exit For
                    End If
                Next

                If Not WPasa Then
                    MostrarMsgError("El Producto no se encuentra dentro del Pedido o la Partida no se es la que se encuentra informada en el mismo", Tipo.Falla)
                    'Exit Sub
                End If

                pnlCantidades.Visible = True
                'txtCantEtiq.Text = ""
                txtCodigoGral.Text = ""
                txtCantPorEtiq.Text = ""
                txtCantPorEtiq.Focus()

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

    Private Sub _TraerPuestos()

        Dim WTabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Impresora FROM ColectoraImpresoras Order by Impresora")
        Dim dr As SqlDataReader

        Try
            cn.ConnectionString = Helper._ConectarA("SurfactanSa")
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            ComboBox1.Items.Clear()

            Do While dr.Read
                ComboBox1.Items.Add("Pto de Trab. " & OrDefault(dr.Item("Impresora"), ""))
            Loop

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la hoja desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _PartidaValida(ByVal WPartida) As DataTable

        Dim WTabla As New DataTable
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Hoja.Hoja, Hoja.Producto, RTRIM(LTRIM(ISNULL(Terminado.Descripcion, ''))) as Descripcion FROM Hoja LEFT OUTER JOIN Terminado ON Hoja.Producto = Terminado.Codigo WHERE Hoja = '" & WPartida & "' AND Renglon = '1'")
        Dim dr As SqlDataReader

        Try
            Dim empresas() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}

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

    Private Sub txtCodigoGral_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoGral.KeyPress, txtCodProd.KeyPress, txtPartida.KeyPress, txtPedido.KeyPress
        If pnlMsg.Visible Then e.Handled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            'If txtCodigoGral.Text.Trim = "" Then Exit Sub
            If Val(txtPartida.Text) = 0 Then Exit Sub
            If Val(txtCantPorEtiq.Text) = 0 Then Exit Sub

            If SerialPort1.IsOpen() Then Exit Sub

            SerialPort1.PortName = "COM7"
            'SerialPort1.Open()
            'SerialPort1.Write("^MTd")

            'SerialPort1.Write("^XA")
            'SerialPort1.Write("^FO5,5")
            'SerialPort1.Write("^ADN,36,20")

            'SerialPort1.Write("^FDPT-25530-100^FS")

            'SerialPort1.Write("^XZ")

            'SerialPort1.Write("^XA")
            'SerialPort1.Write("^FO10,10")
            'SerialPort1.Write("^ADN,20,15")

            'SerialPort1.Write("^FDNK-25005-100^FS")

            'SerialPort1.Write("^XZ")

            'SerialPort1.Close()


            '
            ' Mandar a Imprimir una etiqueta.
            '
            
            'For i = 1 To Val(txtCantEtiq.Text)

            '_ImprimirPort()

            'SerialPort1.Write("^PQ" & txtCantEtiq.Text)
            'SerialPort1.Write("^XZ")

            'Next

            If Val(txtCantEtiq.Text) = 0 Then Exit Sub

            If Val(txtCantPorEtiq.Text) > 50 Then
                txtCantEtiq.Text = "1"
            End If

            If Val(txtCantEtiq.Text) > 2 Then txtCantEtiq.Text = "2"

            Dim WPartida, WCantEtiq, WCantPorEtiq As String

            WPartida = Val(txtPartida.Text.Trim)
            WCantEtiq = Val(txtCantEtiq.Text)
            WCantPorEtiq = formatonumerico(txtCantPorEtiq.Text)

            For i = 1 To Val(WCantEtiq)

                If Not SerialPort1.IsOpen() Then
                    SerialPort1.Open()
                End If

                Threading.Thread.Sleep(1500)

                Dim WTemplate As String = My.Resources.template

                'Stop

                ' Determinamos la numeracion de la proxima etiqueta.
                Dim WUltEtiBarra As DataRow = Nothing
                Dim WUltEtiq As Integer = 0

                Dim Empresas As String() = {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

                For Each empresa As String In Empresas

                    WUltEtiBarra = GetSingle("SELECT ISNULL(UltimaEtiqBarra, 0) as Ultima FROM Hoja WHERE Hoja = '" & txtPartida.Text & "'", empresa)

                    If WUltEtiBarra IsNot Nothing Then
                        WUltEtiq = OrDefault(WUltEtiBarra.Item("Ultima"), 0)
                        ExecuteNonQueries(empresa, "UPDATE Hoja SET UltimaEtiqBarra = (ISNULL(UltimaEtiqBarra, 0) + 1) WHERE Hoja = '" & txtPartida.Text & "'")
                        Exit For
                    End If

                Next

                WUltEtiq += 1

                Dim WCodBarra As String = txtPartida.Text.PadLeft(6, "0") & txtCodProd.Text & WUltEtiq.ToString.PadLeft(4, "0")

                Dim WCodSeg, WPalabra As String
                Dim WPicto(9) As String

                For x = 1 To 9
                    WPicto(x) = "X"
                Next

                WCodSeg = ""
                WPalabra = ""

                Dim WDatosEtiquetas As DataRow = GetSingle("select Frase8, Pictograma1, Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6, Pictograma7, Pictograma8, Pictograma9 from DatosEtiqueta where Terminado = '" & txtCodProd.Text & "' and renglon = 1")

                If WDatosEtiquetas IsNot Nothing Then
                    With WDatosEtiquetas
                        WPalabra = Trim(OrDefault(.Item("Frase8"), ""))

                        For y = 1 To 9
                            WPicto(y) = IIf(Val(OrDefault(.Item("Pictograma" & y), 0)) <= 0, "X", "")
                        Next
                    End With
                End If

                WTemplate = WTemplate.Replace("#CODIGO#", txtCodProd.Text)
                WTemplate = WTemplate.Replace("#PARTIDA#", txtPartida.Text)
                WTemplate = WTemplate.Replace("#KILOS#", formatonumerico(txtCantPorEtiq.Text))
                WTemplate = WTemplate.Replace("#CODSEG#", WCodSeg)
                WTemplate = WTemplate.Replace("#PALABRA#", WPalabra)
                WTemplate = WTemplate.Replace("#CODBARRAS#", WCodBarra)
                WTemplate = WTemplate.Replace("#CANTETIQ#", "1")
                WTemplate = WTemplate.Replace("#PEDIDO#", txtPedido.Text.PadLeft(6, "0"))
                WTemplate = WTemplate.Replace("#CLIENTE#", Microsoft.VisualBasic.Right(WCliente.Trim.ToUpper, 20))

                For Z = 1 To 9
                    WTemplate = WTemplate.Replace("#PICTO" & Z & "#", WPicto(Z))
                Next

                SerialPort1.Write(WTemplate)

                SerialPort1.Close()

                'ExecuteNonQueries("INSERT INTO ProcesoCentroImpresion (Lote, CantEtiq, CantPorEtiq, Impresora, Impresion, Pedido, Estado, CodBarra) VALUES ('" & WPartida & "', '" & "1" & "', '" & WCantPorEtiq & "', '" & Trim(ComboBox1.Text.Replace("Pto de Trab.", "")) & "', '', '" & WCodPedido & "', '" & EstadoEtiq.SinDefinir & "', '" & WCodBarra & "')")
                ExecuteNonQueries("INSERT INTO ProcesoCentroImpresion (Lote, CantEtiq, CantPorEtiq, Impresora, Impresion, Pedido, Estado, CodBarra) VALUES ('" & WPartida & "', '" & "1" & "', '" & WCantPorEtiq & "', '" & Trim(ComboBox1.Text.Replace("Pto de Trab.", "")) & "', '', '" & WCodPedido & "', '" & EstadoEtiq.Habilitada & "', '" & WCodBarra & "')")

            Next

            '_Limpiar()

            pnlCantidades.Visible = False
            pnlConfirmarEtiq.Visible = True

            txtContenedor.Text = ""
            txtEtiqAConfirmar.Text = ""

            txtContenedor.Focus()

            btnConfirmarPedido_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            _Limpiar()
        End Try

    End Sub

    Private Sub _ImprimirPort()
     

    End Sub

    Private Sub _Limpiar()
        'txtCodigoCliente.Text = ""
        txtCodigoGral.Text = ""
        txtPartida.Text = ""

        lblCuentaRegresiva.Text = ""

        txtCandidad.Text = "0"
        txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)
        txtTotalPedido.Text = GenerarStringCantidad(0)

        With pnlCantidades
            .Width = 228
            .Height = 259
            .Visible = False
            .Location = New Point(5, 10)
        End With

        'pnlMsg.Visible = False
        'lblMensajeEstado.Text = ""
        'picError.Visible = False
        'picExito.Visible = False

        txtCodProd.Text = ""

        'txtCodigoGral.Focus()

        With pnlPedido
            .Width = 228
            .Height = 259
            .Visible = True
            .Location = New Point(5, 10)
        End With
        txtCodPedido.Focus()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Microsoft.Win32.Registry.CurrentUser.SetValue("PuestoTrabajo", ComboBox1.SelectedIndex)
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub txtCantEtiq_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantEtiq.KeyDown
        If e.KeyData = Keys.Enter Then
            If Val(txtCantEtiq.Text) = 0 Then Exit Sub

            txtCantPorEtiq.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCantEtiq.Text = ""
        End If
    End Sub

    Private Sub txtCantPorEtiq_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantPorEtiq.KeyDown
        If e.KeyData = Keys.Enter Then
            If Val(txtCantPorEtiq.Text) = 0 Then Exit Sub

            txtCantPorEtiq.Text = formatonumerico(txtCantPorEtiq.Text)

            Button1_Click(Nothing, Nothing)

        ElseIf e.KeyData = Keys.Escape Then
            txtCantPorEtiq.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '_Limpiar()
        pnlCantidades.Visible = False
        txtCodigoGral.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pnlMenu.Visible = True
        'Close()
    End Sub

    Private Sub txtCodPedido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPedido.KeyDown

        Try
            Select Case e.KeyCode

                Case Keys.Enter

                    '
                    ' Controlamos que el Código tenga la cantidad de caracteres válidos.
                    '
                    'If txtCodPedido.Text.Trim.Length < 6 Then
                    ' MsgBox("El Código indicado no tiene el Formato Correcto", MsgBoxStyle.Exclamation)
                    ' Exit Sub
                    ' End If

                    '
                    ' Controlamos que el Pedido sea válido.
                    '
                    WCliente = ""
                    Dim WPedido As DataRow = GetSingle("SELECT Cliente FROM Pedido WHERE Pedido = '" & txtCodPedido.Text & "'")

                    If IsNothing(WPedido) Then
                        MsgBox("El Pedido indicado no es correcto.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    Else
                        Dim WCli As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & WPedido.Item("Cliente") & "'")

                        If WCli IsNot Nothing Then WCliente = Trim(OrDefault(WCli.Item("Razon"), ""))

                    End If

                    '
                    ' Una vez validado el Pedido, lo almacenamos para reutilizarlo posterioemente 
                    '
                    WCodPedido = txtCodPedido.Text
                    txtPedido.Text = WCodPedido

                    txtCodPedido.Text = ""

                    pnlPedido.Visible = False

                    txtCodigoGral.Focus()

                Case Keys.Escape
                    txtCodPedido.Text = ""
            End Select

        Catch ex As Exception
            MostrarMsgError(ex.Message, Tipo.Falla)
            With txtCodPedido
                .Text = ""
                .Focus()
            End With
        End Try

    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        ExecuteNonQueries("UPDATE ProcesoCentroImpresion SET Impresion = 'X', Estado = '" & EstadoEtiq.Inhabilitada & "' WHERE Estado = '" & EstadoEtiq.SinDefinir & "' And Pedido = '" & WCodPedido & "' And Lote = '" & txtPartida.Text & "'")
        pnlConfirmarEtiq.Visible = False
        pnlCantidades.Visible = False
        txtCantEtiq.Text = "1"
        txtCodigoGral.Focus()
    End Sub

    Private Sub txtEtiqAConfirmar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEtiqAConfirmar.KeyDown

        Try
            Select Case e.KeyCode
                Case Keys.Enter

                    If Val(txtCantPorEtiq.Text) > 50 Then
                        txtCantEtiq.Text = "1"
                    End If

                    Dim WEtiq As DataRow = GetSingle("SELECT ID, Lote, Pedido, Estado FROM ProcesoCentroImpresion WHERE CodBarra = '" & txtEtiqAConfirmar.Text & "'")

                    If WEtiq Is Nothing Then
                        Throw New Exception("No se encuentra registro asociado a la etiqueta que trata de validar.")
                    Else
                        If OrDefault(WEtiq.Item("Estado"), EstadoEtiq.SinDefinir) = EstadoEtiq.Inhabilitada Then
                            Throw New Exception("La etiqueta se encuentra inhabilitada y no debe ser utilizada.")
                        ElseIf OrDefault(WEtiq.Item("Estado"), EstadoEtiq.SinDefinir) = EstadoEtiq.Habilitada Then
                            MostrarMsgError("¡Etiqueta ya validada con anterioridad!", Tipo.Falla)
                            With txtEtiqAConfirmar
                                .Text = ""
                                .Focus()
                            End With
                            Exit Sub
                        End If
                    End If

                    Dim WCont As DataRow = Nothing

                    Dim WPartida = Microsoft.VisualBasic.Left(txtContenedor.Text, 6)
                    Dim WTerminado = Microsoft.VisualBasic.Right(txtContenedor.Text, 12)

                    For Each emp As String In New String() {"SurfactanSa", "Surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}
                        WCont = GetSingle("SELECT TOP 1 Hoja FROM Hoja WHERE Hoja = '" & WPartida & "' And Producto = '" & WTerminado & "'", emp)
                        If WCont IsNot Nothing Then Exit For
                    Next

                    If WCont Is Nothing Then
                        Throw New Exception("No se encuentra registro asociado a la etiqueta que trata de validar.")
                    End If

                    If WEtiq.Item("Pedido") <> Val(WCodPedido) Then
                        Throw New Exception("La Etiqueta no corresponde al Pedido que se está procesando.")
                    Else
                        ExecuteNonQueries("UPDATE ProcesoCentroImpresion SET Estado = '" & EstadoEtiq.Habilitada & "' WHERE CodBarra = '" & txtEtiqAConfirmar.Text & "'")

                        If Not WConteoEtiquetas.Contains(txtEtiqAConfirmar.Text) Then WConteoEtiquetas.Add(txtEtiqAConfirmar.Text)

                        If WConteoEtiquetas.Count = Val(txtCantEtiq.Text) Then
                            MostrarMsgError("¡Producto validado con éxito!", Tipo.Exito)
                            btnConfirmarPedido_Click(Nothing, Nothing)
                            Exit Sub
                        End If

                        lblCantEtiqValidadas.Text = String.Format("Etiqueta(s) {0} de {1}", WConteoEtiquetas.Count, Val(txtCantEtiq.Text))

                        txtEtiqAConfirmar.Text = ""
                        txtEtiqAConfirmar.Focus()

                    End If
                Case Keys.Escape
                    txtEtiqAConfirmar.Text = ""
            End Select
        Catch ex As Exception
            MostrarMsgError(ex.Message, Tipo.Falla)
            With txtEtiqAConfirmar
                .Text = ""
                .Focus()
            End With
        End Try

    End Sub

    Private Sub btnCancelarVerificarContenedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarVerificarContenedor.Click
        pnlValidarContenedor.Visible = False
        pnlConfirmarEtiq.Visible = True
        'txtCodigoGral.Focus()
        txtContenedor.Focus()
    End Sub

    Private Sub btnRevalidarContenedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevalidarContenedor.Click
        If txtUlt.Text.Trim = "" Then Exit Sub

        pnlConfirmarEtiq.Visible = False
        pnlValidarContenedor.Visible = True

        With txtVerificarContenedor
            .Text = ""
            .Focus()
        End With

    End Sub

    Private Sub btnVerificarContenedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerificarContenedor.Click
        Try

            Dim WPartida = Microsoft.VisualBasic.Left(txtVerificarContenedor.Text, 6)
            Dim WTerminado = Microsoft.VisualBasic.Right(txtVerificarContenedor.Text, 12)

            If Val(WPartida) <> Val(txtUltPartida.Text) Or WTerminado <> txtUlt.Text Then
                Throw New Exception("No se puede utilizar el Contenedor, ya que no se corresponde con el anteriormente utilizado.")
            End If

            MostrarMsgError("Contenedor Validado", Tipo.Exito)

            btnCancelarVerificarContenedor_Click(Nothing, Nothing)

        Catch ex As Exception
            MostrarMsgError(ex.Message, Tipo.Falla)
            With txtVerificarContenedor
                .Text = ""
                .Focus()
            End With
        End Try
    End Sub

    Private Sub txtContenedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContenedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEtiqAConfirmar.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtContenedor.Text = ""
        End If
    End Sub

    Private Sub btnConfirmarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmarPedido.Click
        ExecuteNonQueries("UPDATE ProcesoCentroImpresion SET Impresion = 'X', Estado = '" & EstadoEtiq.Inhabilitada & "' WHERE Estado = '" & EstadoEtiq.SinDefinir & "' And Pedido = '" & WCodPedido & "' And Lote = '" & txtPartida.Text & "'")
        pnlConfirmarEtiq.Visible = False
        pnlValidarContenedor.Visible = False
        pnlPedido.Visible = True
        txtCantEtiq.Text = "1"
        txtCantPorEtiq.Text = "1"
        WCodPedido = ""
        WConteoEtiquetas.Clear()
        txtCodPedido.Text = ""
        txtCodPedido.Focus()
        'txtCodigoGral.Focus()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        pnlPedido.Visible = True
        txtCodPedido.Text = ""
        WCodPedido = ""
        txtCodPedido.Focus()
    End Sub

    Private Sub txtVerificarContenedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVerificarContenedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnVerificarContenedor_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        pnlMenu.Visible = False
        pnlPedido.Visible = True
        txtPedido.Text = ""
        txtCodPedido.Text = ""
        txtCodPedido.Focus()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pnlConsEtiqFinal.Visible = True
        txtCodEtiqFinal.Text = ""
        txtCodEtiqPreenvasado.Text = ""
        pnlMenu.Visible = False
        txtCodEtiqPreenvasado.Focus()
    End Sub

    Private Sub btnSalirConsEtiqFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirConsEtiqFinal.Click
        pnlConsEtiqFinal.Visible = False
        txtCodEtiqFinal.Text = ""
        txtCodEtiqPreenvasado.Text = ""
        pnlMenu.Visible = True
    End Sub

    Private Sub txtCodEtiqPreenvasado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodEtiqPreenvasado.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCodEtiqFinal.Text = ""
            Dim WEtiq As DataRow = GetSingle("SELECT ID FROM ProcesoCentroImpresion WHERE CodBarra = '" & txtCodEtiqPreenvasado.Text & "' And Estado = '" & EstadoEtiq.Habilitada & "' And EtiqFinal <> '1'")

            If WEtiq Is Nothing Then
                MostrarMsgError("Etiqueta inexistente o no validada", Tipo.Exito)
                txtCodEtiqPreenvasado.Text = ""
                Exit Sub
            End If

            txtCodEtiqFinal.Focus()

        ElseIf e.KeyCode = Keys.Escape Then
            txtCodEtiqPreenvasado.Text = ""
            txtCodEtiqFinal.Text = ""
        End If
    End Sub

    Private Sub txtCodEtiqFinal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodEtiqFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            
            Dim WEtiqFinal As DataRow = GetSingle("SELECT Pedido, Lote, Cantidad = CantPorEtiq FROM ProcesoCentroImpresion WHERE CodBarra = '" & txtCodEtiqFinal.Text & "' And Estado <> '" & EstadoEtiq.Habilitada & "' And EtiqFinal = '1'")

            If WEtiqFinal Is Nothing Then
                MostrarMsgError("Etiqueta inexistente o ya validada", Tipo.Falla)
                txtCodEtiqPreenvasado.Text = ""
                txtCodEtiqFinal.Text = ""
                txtCodEtiqPreenvasado.Focus()
                Exit Sub
            Else

                '
                ' Realizamos la validacion de Pedido, Lote y Cantidad.
                '
                Dim WPedidoReet, WLoteReet, WCantidadReet As String
                Dim WPedidoFinal, WLoteFinal, WCantidadFinal As String

                WPedidoFinal = Trim(OrDefault(WEtiqFinal.Item("Pedido"), ""))
                WLoteFinal = Trim(OrDefault(WEtiqFinal.Item("Lote"), ""))
                WCantidadFinal = formatonumerico(OrDefault(WEtiqFinal.Item("Cantidad"), 0))

                '
                ' Buscamos la información de los datos de la etiqueta de reetiquetado.
                '
                Dim WEtiqReet As DataRow = GetSingle("SELECT Pedido, Lote, Cantidad = CantPorEtiq FROM ProcesoCentroImpresion WHERE CodBarra = '" & txtCodEtiqPreenvasado.Text & "' And Estado = '" & EstadoEtiq.Habilitada & "' And ISNULL(EtiqFinal, '0') = '0'")

                WPedidoReet = Trim(OrDefault(WEtiqReet.Item("Pedido"), ""))
                WLoteReet = Trim(OrDefault(WEtiqReet.Item("Lote"), ""))
                WCantidadReet = formatonumerico(OrDefault(WEtiqReet.Item("Cantidad"), 0))

                If Val(WPedidoFinal) <> Val(WPedidoReet) Or Val(WLoteFinal) <> Val(WLoteReet) Or Val(WCantidadFinal) <> Val(WCantidadReet) Then
                    MostrarMsgError("La Etiqueta no se puede validar para este envase. Difiere en Pedido, Lote o Cantidad.", Tipo.Falla)
                    txtCodEtiqPreenvasado.Text = ""
                    txtCodEtiqFinal.Text = ""
                    txtCodEtiqPreenvasado.Focus()
                    Exit Sub
                End If

                ExecuteNonQueries("UPDATE ProcesoCentroImpresion SET Estado = '" & EstadoEtiq.Habilitada & "' WHERE CodBarra = '" & txtCodEtiqFinal.Text & "'")
                MostrarMsgError("Etiqueta validada con Éxito!", Tipo.Exito)
                txtCodEtiqPreenvasado.Text = ""
                txtCodEtiqFinal.Text = ""
                txtCodEtiqPreenvasado.Focus()

            End If

        ElseIf e.KeyCode = Keys.Escape Then
            txtCodEtiqPreenvasado.Text = ""
            txtCodEtiqFinal.Text = ""
            txtCodEtiqFinal.Focus()
        End If
    End Sub
End Class