Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query
Imports System.Globalization

Public Class AltaAgenda : Implements Util.IAyudaGeneral
    Private ReadOnly WCliente As String
    Private ReadOnly WFecha As String

    Sub New(Optional ByVal Cliente As String = "", Optional ByVal Fecha As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WCliente = Cliente
        WFecha = Fecha
    End Sub

    Private Sub AltaAgenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In {txtCliente, txtFecha, txtObservacion, txtHora, lblDescCliente}
            c.Text = ""
        Next

        txtCliente.Text = WCliente
        txtFecha.Text = WFecha

        If WCliente <> "" And WFecha <> "" Then
            txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            txtFecha_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        With New AyudaGeneral(GetAll("SELECT Cliente as Codigo, Razon As Descripcion FROM Cliente WHERE Razon <> '' ORDER BY Razon"), "AYUDA CLIENTES")
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaGeneral(row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        txtCliente.Text = OrDefault(row.Cells("Codigo").Value, "")
        ' todo llamar a evento txtcliente keydown
    End Sub

    Private Sub btnCtaCte_Click(sender As Object, e As EventArgs) Handles btnCtaCte.Click
        ' todo llamar a la ventana de Cta cte cuando esté creada.
    End Sub

    Private Sub btnDatosCliente_Click(sender As Object, e As EventArgs) Handles btnDatosCliente.Click
        ' todo armar una ventana con la información básica que puede interesar.
    End Sub

    Private Sub btnMinuta_Click(sender As Object, e As EventArgs) Handles btnMinuta.Click
        ' todo llamar a ventana de minutas.
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            lblDescCliente.Text = ""

            If Trim(txtCliente.Text) = "" Then : Exit Sub : End If

            txtCliente.Text = FormatoCodigoCliente(txtCliente.Text)

            Dim Cliente As DataRow = GetSingle("SELECT Cliente, Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            If Cliente Is Nothing Then Exit Sub

            lblDescCliente.Text = Trim(OrDefault(Cliente("Razon"), "")).ToUpper

            txtFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            
            Dim WDatos As DataRow = GetSingle("SELECT Anotaciones, Horario FROM AgendaClientes WHERE Cliente = '" & txtCliente.Text & "' And Fecha = '" & txtFecha.Text & "' And Baja <> '1'")

            If WDatos IsNot Nothing Then

                If WDatos IsNot Nothing Then
                    txtObservacion.Text = Trim(OrDefault(WDatos("Anotaciones"), ""))
                    txtHora.Text = OrDefault(WDatos("Horario"), "")
                End If

            Else

                WDatos = GetSingle("SELECT Fecha, Hora, Anotacion, FechaII, HoraII, AnotacionII FROM Cliente WHERE Cliente = '" & txtCliente.Text & "' And (Fecha = '" & txtFecha.Text & "' Or FechaII = '" & txtFecha.Text & "')")

                If WDatos IsNot Nothing Then
                    Dim WFecha1 As String = OrDefault(WDatos("Fecha"), "  /  /    ")
                    Dim WAnotacionI As String = OrDefault(WDatos("Anotacion"), "")
                    Dim WAnotacionII As String = OrDefault(WDatos("AnotacionII"), "")
                    Dim WHora1 As String = formatonumerico(OrDefault(WDatos("Hora"), ""))
                    Dim WHora2 As String = formatonumerico(OrDefault(WDatos("HoraII"), ""))

                    WHora1 = TimeSpan.FromHours(Val(WHora1)).ToString("h\:mm")
                    WHora2 = TimeSpan.FromHours(Val(WHora2)).ToString("h\:mm")

                    If WFecha1 = txtFecha.Text Then
                        txtObservacion.Text = WAnotacionI.Trim.ToUpper
                        txtHora.Text = WHora1
                    Else
                        txtObservacion.Text = WAnotacionII.Trim.ToUpper
                        txtHora.Text = WHora2
                    End If
                Else
                    If Not FechaValidaParaAgendar() Then Exit Sub
                End If

            End If

            txtObservacion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Function FechaValidaParaAgendar() As Boolean

        If txtFecha.Text.Replace(" ", "").Length < 10 OrElse Not _ValidarFecha(txtFecha.Text) Then
            MsgBox("La fecha ingresada no es una fecha válida.", MsgBoxStyle.Exclamation)
            Return False
        End If

        '
        ' Sólo Fechas posteriores.
        '
        If Val(ordenaFecha(txtFecha.Text)) <= Val(ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) Then
            MsgBox("No se permiten realizar grabaciones para fechas posteriores al dia de hoy.", MsgBoxStyle.Exclamation)
            Return False
        End If

        '
        ' Controlamos que no se trate de fin de semana.
        '
        If EsFeriado(txtFecha.Text) Then
            If MsgBox("La Fecha indicada corresponde a un Fin de Semana.", MsgBoxStyle.Exclamation) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub txtHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHora.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtHora.Text.Replace(" ", "") < 5 Then : Exit Sub : End If

            txtObservacion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHora.Text = ""
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Not FechaValidaParaAgendar() Then Exit Sub

        '
        ' Validamos las cantidades de agendados?
        '
        Dim WFecha1, WFecha2, WHora1, WHora2, WAnotacionI, WAnotacionII As String
        Dim WExiste As DataRow

        Dim WCliente As DataRow = GetSingle("SELECT Fecha, Hora, Anotacion, FechaII, HoraII, AnotacionII FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

        If WCliente Is Nothing Then
            MsgBox("El Cliente indicado, no es un Cliente válido.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If txtHora.Text.Replace(" ", "").Length < 5 Then txtHora.Text = "00:00"

        If txtObservacion.Text.Trim = "" Then
            If MsgBox("No se ha cargado ninguna observación sobre la entrada a agendar ¿Desea grabar igualmente?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                txtObservacion.Focus()
                Exit Sub
            End If
        End If

        WFecha1 = OrDefault(WCliente("Fecha"), "  /  /    ")
        WFecha2 = OrDefault(WCliente("FechaII"), "  /  /    ")
        WAnotacionI = OrDefault(WCliente("Anotacion"), "")
        WAnotacionII = OrDefault(WCliente("AnotacionII"), "")
        WHora1 = formatonumerico(OrDefault(WCliente("Hora"), ""))
        WHora2 = formatonumerico(OrDefault(WCliente("HoraII"), ""))

        Dim WHoraDecimal As String = formatonumerico(TimeSpan.ParseExact(txtHora.Text, "h\:mm", CultureInfo.InvariantCulture).TotalHours)

        Dim WSql As New List(Of String)

        '
        ' Para mantener un minimo de compatibilidad con el sistema viejo,
        ' se van a mantener siempre las ultimas dos entradas agendadas en el formato anterior.
        '
        If Val(WFecha1) = 0 And Val(WFecha2) = 0 Then ' Ninguna de las fechas se encuentra ocupada.

            WFecha1 = txtFecha.Text
            WAnotacionI = txtObservacion.Text.ToUpper.Trim
            WHora1 = WHoraDecimal

        ElseIf Val(WFecha1) = 0 And Val(WFecha2) > 0 Then ' La primer fecha se encuentra libre, no asi la segunda.

            If WFecha2 = txtFecha.Text Then ' Si es misma fecha que la actual, se actualiza y mueve.
                WFecha1 = txtFecha.Text
                WAnotacionI = txtObservacion.Text.Trim.ToUpper
                WHora1 = WHoraDecimal

                WFecha2 = "  /  /    "
                WAnotacionII = ""
                WHora2 = ""
            Else ' sino swap.

                WFecha1 = WFecha2
                WAnotacionI = WAnotacionII.Trim.ToUpper
                WHora1 = WHora2

                WFecha2 = txtFecha.Text
                WAnotacionII = txtObservacion.Text.ToUpper.Trim
                WHora2 = WHoraDecimal

            End If

        ElseIf Val(WFecha1) > 0 And Val(WFecha2) = 0 Then ' La segunda fecha se encuentra libre, no asi la primera.

            If WFecha1 = txtFecha.Text Then ' Si es la misma, se actualiza.
                WFecha1 = txtFecha.Text
                WAnotacionI = txtObservacion.Text.ToUpper.Trim
                WHora1 = WHoraDecimal
            Else ' Sino se usa segunda fecha disponible.
                WFecha2 = txtFecha.Text
                WAnotacionII = txtObservacion.Text.ToUpper.Trim
                WHora2 = WHoraDecimal
            End If

        Else ' Ambas se encuentran ocupadas.

            If txtFecha.Text = WFecha1 Then ' Se actualiza solo la primera fecha

                WFecha1 = txtFecha.Text
                WAnotacionI = txtObservacion.Text.ToUpper.Trim
                WHora1 = WHoraDecimal

            ElseIf txtFecha.Text = WFecha2 Then ' Se actualiza solo la segunda fecha

                WFecha2 = txtFecha.Text
                WAnotacionII = txtObservacion.Text.ToUpper.Trim
                WHora2 = WHoraDecimal

            Else ' Se hace un corrimiento, descartando la primera fecha

                WExiste = GetSingle("SELECT ID FROM AgendaClientes WHERE Fecha = '" & WFecha1 & "' And Cliente = '" & txtCliente.Text & "' And Baja = '0'")

                If WExiste Is Nothing Then
                    WSql.Add(String.Format("INSERT INTO AgendaClientes (Cliente, Fecha, FechaOrd, Anotaciones, Horario) VALUES ('{0}','{1}','{2}','{3}','{4}')", txtCliente.Text, WFecha1, ordenaFecha(WFecha1), WAnotacionI, WHora1))
                End If

                WFecha1 = WFecha2
                WAnotacionI = WAnotacionII.Trim.ToUpper
                WHora1 = WHora2

                WFecha2 = txtFecha.Text
                WAnotacionII = txtObservacion.Text.ToUpper.Trim
                WHora2 = WHoraDecimal

            End If

        End If

        Dim WExisteNuevo As DataRow = GetSingle("SELECT ID FROM AgendaClientes WHERE Fecha = '" & txtFecha.Text & "' And Cliente = '" & txtCliente.Text & "' And Baja = '0'")

        If WExisteNuevo IsNot Nothing Then
            WSql.Add(String.Format("UPDATE AgendaClientes SET Anotaciones = '{1}', Horario = '{2}' WHERE ID = '{0}'", WExisteNuevo("ID"), txtObservacion.Text, txtHora.Text))
        Else
            WSql.Add(String.Format("INSERT INTO AgendaClientes (Cliente, Fecha, FechaOrd, Anotaciones, Horario) VALUES ('{0}','{1}','{2}','{3}','{4}')", txtCliente.Text, txtFecha.Text, ordenaFecha(txtFecha.Text), txtObservacion.Text, txtHora.Text))
        End If

        WSql.Add(String.Format("UPDATE Cliente SET Fecha = '{1}', Anotacion = '{2}', Hora  = '{3}', FechaII = '{4}', AnotacionII = '{5}', HoraII  = '{6}', OrdFecha = '{7}', OrdFechaII = '{8}' WHERE Cliente = '{0}'", txtCliente.Text, WFecha1, WAnotacionI, WHora1, WFecha2, WAnotacionII, WHora2, ordenaFecha(WFecha1), ordenaFecha(WFecha2)))

        ExecuteNonQueries(WSql.ToArray)

        Dim WOwner As INotificacionCambios = TryCast(Owner, INotificacionCambios)

        If WOwner IsNot Nothing Then
            WOwner.NotificarCambios()
        End If

        Close()

    End Sub

    Private Sub AltaAgenda_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCliente.Focus()

        If WCliente <> "" And WFecha <> "" Then
            txtObservacion.Focus()
        End If

    End Sub
End Class