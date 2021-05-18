Imports System.Data.SqlClient
Imports System.Data
Imports System.Media
Imports System.IO

Enum EstadoEtiq
    NoValidada = 0
    Validada = 1
End Enum

Public Class Principal

    Private WTiempoFuera = 0
    Private WTiempoFueraTranscurrido = 0
    Private WAcumulaPartida As String = 0
    Private WTamanioPnl(2) As Integer

    Private WCodPedido As String = ""
    Private WConteoEtiquetas As New List(Of String)
    Private WCliente As String = ""
    Private WEmpresaHoja As String = ""

    Enum Tipo
        Exito
        Falla
    End Enum

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        txtCodEtiqPreenvasado.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.PortName = "COM7"
        btnLimpiar_Click(Nothing, Nothing)

        pnlMsg.Location = New Point(10, 10)
        pnlMsg.Width = Me.Width - 25
        pnlMsg.Height = Me.Height - 45

        lblMensajeestado.Location = New Point(pnlMsg.Width / 2 - lblMensajeestado.Width / 2, lblMensajeestado.Location.Y)
        pnlMsg.Visible = False
        lblMensajeestado.Text = ""
        picError.Visible = False
        picExito.Visible = False
        pnlValidarEtiqFinal.Visible = True

        'Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Environment\LectoraControl")

        'ComboBox1.SelectedIndex = Val(Microsoft.Win32.Registry.CurrentUser.GetValue("PuestoTrabajo", "0"))

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
        lblCuentaRegresiva.Text = ""

        txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)
        txtTotalPedido.Text = GenerarStringCantidad(0)

    End Sub

    Private Function GenerarStringCantidad(ByVal WCantidad As Object)

        Return NormalizarNumero(WCantidad, 2) & " " & "Kg(s)"

    End Function

    Private Function NormalizarNumero(ByVal WNumero, Optional ByVal WDecimales = 2) As String

        Return Helper.formatonumerico(WNumero)

    End Function

    Private Sub CamposCodigos_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoGral.GotFocus, txtCandidad.GotFocus
        Dim campo As TextBox = sender

        campo.BackColor = Color.Cyan
    End Sub

    Private Sub CamposCodigos_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoGral.LostFocus, txtCandidad.LostFocus
        Dim campo As TextBox = sender

        campo.BackColor = Color.White
    End Sub

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

    Private Sub _Limpiar()
        'txtCodigoCliente.Text = ""
        txtCodigoGral.Text = ""

        lblCuentaRegresiva.Text = ""

        txtCandidad.Text = "0"
        txtSuma.Text = GenerarStringCantidad(txtCandidad.Text)
        txtTotalPedido.Text = GenerarStringCantidad(0)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Microsoft.Win32.Registry.CurrentUser.SetValue("PuestoTrabajo", ComboBox1.SelectedIndex)
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pnlValidarEtiqFinal.Visible = True
        txtCodEtiqFinal.Text = ""
        txtCodEtiqPreenvasado.Text = ""
        pnlMenu.Visible = False
        txtCodEtiqPreenvasado.Focus()
    End Sub

    Private Sub btnSalirConsEtiqFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirConsEtiqFinal.Click
        pnlValidarEtiqFinal.Visible = False
        txtCodEtiqFinal.Text = ""
        txtCodEtiqPreenvasado.Text = ""
        pnlMenu.Visible = True
    End Sub

    Private Sub txtCodEtiqPreenvasado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodEtiqPreenvasado.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCodEtiqFinal.Text = ""

            txtCodEtiqPreenvasado.Text = txtCodEtiqPreenvasado.Text.Replace("(Code-39)", "").Replace("*", "")

            Dim WEtiq As DataRow = GetSingle("SELECT ID, Estado FROM ControlEtiquetas WHERE CodigoBarra = '" & txtCodEtiqPreenvasado.Text & "' And Tipo = '0'", "Surfactan_III")

            If WEtiq Is Nothing Then
                MostrarMsgError("Etiqueta inexistente", Tipo.Falla)
                txtCodEtiqPreenvasado.Text = ""
                Exit Sub
            Else
                If OrDefault(WEtiq("Estado"), 0) = EstadoEtiq.Validada Then
                    MostrarMsgError("La etiqueta ya se encuentra validada.", Tipo.Falla)
                    txtCodEtiqPreenvasado.Text = ""
                    Exit Sub
                End If
            End If

            txtCodEtiqFinal.Focus()

        ElseIf e.KeyCode = Keys.Escape Then
            txtCodEtiqPreenvasado.Text = ""
            txtCodEtiqFinal.Text = ""
        End If
    End Sub

    Private Sub txtCodEtiqFinal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodEtiqFinal.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try
                txtCodEtiqFinal.Text = txtCodEtiqFinal.Text.Replace("(Code-39)", "").Replace("*", "")

                '
                ' Busco la informacion de la etiqueta de cuarentena.
                '
                Dim WEtiqFinal As DataRow = GetSingle("SELECT ID, Estado, Producto, Partida, Cantidad FROM ProcesoCentroImpresion WHERE CodBarra = '" & txtCodEtiqFinal.Text & "' And Tipo = '1'", "Surfactan_III")

                If WEtiqFinal Is Nothing OrElse OrDefault(WEtiqFinal("Estado"), EstadoEtiq.NoValidada) = EstadoEtiq.Validada Then

                    Dim msgError As String

                    msgError = IIf(WEtiqFinal Is Nothing, "Etiqueta inexistente!", "Etiqueta ya validada anteriormente!")

                    MostrarMsgError(msgError, Tipo.Falla)

                    Exit Sub

                Else
                    '
                    ' Buscamos la informacion de la Etiq de Cuarentena para validar los datos mínimos.
                    '
                    Dim WEtiqCuarentena As DataRow = GetSingle("SELECT Estado, Producto, Partida, Cantidad FROM ProcesoCentroImpresion WHERE CodBarra = '" & txtCodEtiqPreenvasado.Text & "' And Tipo = '0'", "Surfactan_III")

                    If WEtiqCuarentena Is Nothing Then
                        MostrarMsgError("Etiqueta inexistente!", Tipo.Falla)
                        Exit Sub
                    End If

                    '
                    ' Validamos que coincidan los datos.
                    '
                    If OrDefault(WEtiqCuarentena("Producto"), "") = OrDefault(WEtiqFinal("Producto"), "") Then
                        MostrarMsgError("No coinciden los Productos!", Tipo.Falla)
                        Exit Sub
                    End If

                    If OrDefault(WEtiqCuarentena("Partida"), "") = OrDefault(WEtiqFinal("Partida"), "") Then
                        MostrarMsgError("No coinciden las Partidas!", Tipo.Falla)
                        Exit Sub
                    End If

                    '
                    ' Queda comentado por si piden este control.
                    '
                    'If val(OrDefault(WEtiqCuarentena("Cantidad"), "")) = val(OrDefault(WEtiqFinal("Cantidad"), "")) Then
                    ' MostrarMsgError("No coinciden las Cantidades!", Tipo.Falla)
                    ' Exit Sub
                    'End If

                    '
                    ' Colocamos la etiqueta de cuarentena como validada, le asignamos el ID de la etiqueta final y asi mismo como validada a la Etiqueta Final.
                    '
                    ExecuteNonQueries("Surfactan_III", New String() {"UPDATE ControlEtiquetas SET Estado = '" & EstadoEtiq.Validada & "', ValidadoCon = '" & WEtiqFinal("ID") & "' WHERE CodigoBarra = '" & txtCodEtiqFinal.Text & "'", "UPDATE ControlEtiquetas SET Estado = '" & EstadoEtiq.Validada & "', ValidadoCon = '-1' WHERE CodigoBarra = '" & txtCodEtiqFinal.Text & "'"})

                    MostrarMsgError("Etiqueta validada con Éxito!", Tipo.Exito)

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                txtCodEtiqPreenvasado.Text = ""
                txtCodEtiqFinal.Text = ""
                txtCodEtiqPreenvasado.Focus()
            End Try

        ElseIf e.KeyCode = Keys.Escape Then
            txtCodEtiqPreenvasado.Text = ""
            txtCodEtiqFinal.Text = ""
            txtCodEtiqFinal.Focus()
        End If
    End Sub
End Class