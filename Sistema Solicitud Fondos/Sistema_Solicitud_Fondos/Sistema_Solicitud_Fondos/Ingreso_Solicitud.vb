Imports System.IO
Imports ClasesCompartidas
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports GestorDeArchivos
Imports Util

Public Class Ingreso_Solicitud : Implements IConsulta, IContraseña

    Dim CarpetaAux As String = "C:\" & "Auxiliar_SolicitudFondos"
    Dim RutaGuardar As String = "\\193.168.0.2\g$\vb\NET\ArchivosRelacionadosSolicitudFondos"

    Dim LimpiaGrabar As String = "NO"
    Dim NRO_SOLICITUD As Integer = 0

    Dim WParidad As Double = 0
    Dim ZCambioDivisa As Double

    Dim VALIDACIONES As Boolean = True



    Sub New(Optional ByVal NroSoli As Integer = 0, Optional ByVal MostrarAutorizar As String = "No_Mostrar")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_FechaSolicitud.Text = Date.Today.ToString("dd/MM/yyyy")
        txt_CuentaDescrip.Enabled = False
        txt_Cuenta.Enabled = False
        txt_Proveedor.Enabled = False
        txt_ProveedorDescrip.Enabled = False

        btn_Limpiar_Click(Nothing, Nothing)

        'OBTENEMOS LA PARIDAD
        Try
            ZCambioDivisa = _BuscarParidad(Date.Today.ToString("dd/MM/yyyy"))
        Catch ex As System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '
        'If ZCambioDivisa = 0 Then
        '    MsgBox("La fecha " & Date.Today.ToString("dd/MM/yyyy") & " no tiene informado paridad, se de cargar para calcular las retenciones", MsgBoxStyle.Information)
        'End If
        '
        WParidad = ZCambioDivisa

        txt_Paridad.Text = WParidad



        Dim SQLCnslt As String = ""
        If NroSoli <> 0 Then

            If MostrarAutorizar = "Mostrar" Then
                btn_Autorizar.Visible = True
            End If


            'CARGAMOS EL REGISTRO
            SQLCnslt = "SELECT * FROM SolicitudFondos WHERE NroSolicitud = '" & NroSoli & "'"
            Dim rowsoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowsoli IsNot Nothing Then

                NRO_SOLICITUD = NroSoli

                cbx_Moneda.SelectedIndex = rowsoli.Item("Moneda")
                cbx_TipoDolar.SelectedIndex = IIf(IsDBNull(rowsoli.Item("TipoDolar")), 0, rowsoli.Item("TipoDolar"))
                If cbx_Moneda.SelectedIndex = 2 Then
                    lbl_TipoDolar.Visible = True
                    cbx_TipoDolar.Visible = True

                    cbx_TipoDolar.Enabled = False

                    If cbx_TipoDolar.SelectedIndex = 3 Then
                        txt_Paridad.ReadOnly = False
                    End If

                End If



                'SI YA ESTA AUTORIZADA SACAMOS EL BOTON DE AUTORIZAR
                Dim EstadoSoli As String = IIf(IsDBNull(rowsoli.Item("Estado")), "", rowsoli.Item("Estado"))
                If Trim(UCase(EstadoSoli)) = "AUTORIZO" Then
                    btn_Autorizar.Visible = False
                   
                End If

                'OBTENEMOS LA PARIDAD
                Try
                    'SI EL TIPO DE DOLAR ES INFORMADO< TRAEMOS EL VALOR DE LA TABLA
                    If cbx_TipoDolar.SelectedIndex = 3 Then
                        ZCambioDivisa = rowsoli.Item("ParidadInformada")
                        'Y BLOQUEAMOS LA PARIDAD INGRESADA
                        txt_Paridad.ReadOnly = True
                    Else
                        ZCambioDivisa = _BuscarParidad(Date.Today.ToString("dd/MM/yyyy"))
                    End If

                Catch ex As System.Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                '
                'If ZCambioDivisa = 0 Then
                '    MsgBox("La fecha " & Date.Today.ToString("dd/MM/yyyy") & " no tiene informado paridad, se de cargar para calcular las retenciones", MsgBoxStyle.Information)
                'End If
                '
                WParidad = ZCambioDivisa

                txt_Paridad.Text = WParidad

                cbx_Tipo.SelectedIndex = rowsoli.Item("Tipo")

                txt_Solicitante.Text = Trim(IIf(IsDBNull(rowsoli.Item("Solicitante")), "", rowsoli.Item("Solicitante")))
                txt_Observaciones.Text = Trim(IIf(IsDBNull(rowsoli.Item("ObservacionesPago")), "", rowsoli.Item("ObservacionesPago")))
                txt_Titulo.Text = Trim(IIf(IsDBNull(rowsoli.Item("Titulo")), "", rowsoli.Item("Titulo")))
                txt_Concepto.Text = Trim(IIf(IsDBNull(rowsoli.Item("Concepto")), "", rowsoli.Item("Concepto")))
                txt_FechaSolicitud.Text = Trim(IIf(IsDBNull(rowsoli.Item("Fecha")), "", rowsoli.Item("Fecha")))

                txt_Proveedor.Text = IIf(IsDBNull(rowsoli.Item("Proveedor")), "", Trim(rowsoli.Item("Proveedor")))
                If Trim(txt_Proveedor.Text) <> "" Then
                    txt_Proveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                End If

                txt_Cuenta.Text = IIf(IsDBNull(rowsoli.Item("Cuenta")), "", Trim(rowsoli.Item("Cuenta")))
                If Trim(txt_Cuenta.Text) <> "" Then
                    txt_Cuenta_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                End If

                txt_FechaRequerida.Text = IIf(IsDBNull(rowsoli.Item("FechaRequerida")), "", rowsoli.Item("FechaRequerida"))
                txt_Importe.Text = formatonumerico(rowsoli.Item("Importe"))



                'chk_Efectivo.Checked = OrDefault(rowsoli.Item("Efectivo_Chk"), 0) = 1
                chk_Efectivo.Checked = IIf(IsDBNull(rowsoli.Item("Efectivo_Chk")), 0, rowsoli.Item("Efectivo_Chk"))
                'chk_Tranferencia.Checked = OrDefault(rowsoli.Item("Transferencia_Chk"), 0) = 1
                chk_Tranferencia.Checked = IIf(IsDBNull(rowsoli.Item("Transferencia_Chk")), 0, rowsoli.Item("Transferencia_Chk"))
                'chk_Echeq.Checked = OrDefault(rowsoli.Item("ECheq_Chk"), 0) = 1
                chk_Echeq.Checked = IIf(IsDBNull(rowsoli.Item("ECheq_Chk")), 0, rowsoli.Item("ECheq_Chk"))
                'chk_ChequeTerceros.Checked = OrDefault(rowsoli.Item("CheqTerceros_Chk"), 0) = 1
                chk_ChequeTerceros.Checked = IIf(IsDBNull(rowsoli.Item("CheqTerceros_Chk")), 0, rowsoli.Item("CheqTerceros_Chk"))
                'chk_ChequePropio.Checked = OrDefault(rowsoli.Item("CheqPropio_Chk"), 0) = 1
                chk_ChequePropio.Checked = IIf(IsDBNull(rowsoli.Item("CheqPropio_Chk")), 0, rowsoli.Item("CheqPropio_Chk"))
                chk_Tarjeta.Checked = IIf(IsDBNull(rowsoli.Item("Tarjeta_Chk")), 0, rowsoli.Item("Tarjeta_Chk"))

                'EN CASO DE QUE SEA EN DOLARES MULTIPLICAMOS EL VALOR POR LA PARIDAD
                If WParidad <> 0 Then
                    Multiplicaporparidad()
                End If

                txt_Importe_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            End If

            'VERIFICO SI TIENE ARCHIVOS

            Dim Ruta As String = RutaGuardar & "\" & NRO_SOLICITUD

            If Directory.Exists(Ruta) Then
                Dim CantidadArchivos As Integer = 0
                For Each archivo As String In Directory.GetFiles(Ruta)
                    CantidadArchivos += 1
                Next
                'SI HAY PINTAMOS LE BOTON DE VERDEE
                If CantidadArchivos > 1 Then
                    btn_Adjuntar.BackColor = Color.Green
                    btn_Adjuntar.ForeColor = Color.White
                End If
            End If

            'HAGO VISIBLE EL BOTON PARA GENERAR EL REPORTE DE SOLICITUD
            btn_MostrarSolicitud.Visible = True

            'DESHABILITAMOS LOS CAMPOS QUE NO PUEDE EDITAR
            btn_Limpiar.Visible = False

            '  chk_Echeq.Enabled = False
            '  chk_Efectivo.Enabled = False
            '  chk_Tranferencia.Enabled = False
            '  chk_ChequeTerceros.Enabled = False
            '  chk_ChequePropio.Enabled = False

            cbx_Tipo.Enabled = False
            cbx_Moneda.Enabled = False

            txt_Titulo.ReadOnly = True
            txt_Concepto.ReadOnly = True
            txt_Solicitante.ReadOnly = True
            txt_FechaSolicitud.ReadOnly = True
            txt_Cuenta.ReadOnly = True
            txt_Proveedor.ReadOnly = True
            txt_Importe.ReadOnly = True
        End If

    End Sub

    Private Sub Multiplicaporparidad()
        If cbx_Moneda.SelectedIndex = 2 Then
            Dim TotalPesos As Double = WParidad * Val(txt_Importe.Text)
            txt_ImportePesos.Text = formatonumerico(TotalPesos)
        Else
            txt_ImportePesos.Text = formatonumerico(txt_Importe.Text)
        End If

    End Sub

    Private Function _BuscarParidad(ByVal ZZFecha As String) As Double
        Dim ZCambioParidad = 0.0

        Try

            Dim SQLCnslt As String = "SELECT Cambio, CambioDivisa FROM Cambios WHERE Fecha = '" & ZZFecha.Substring(0, 10) & "'"

            Dim RowParidad As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If RowParidad IsNot Nothing Then

                With RowParidad
                    If cbx_TipoDolar.SelectedIndex = 1 Or cbx_TipoDolar.SelectedIndex = 3 Then
                        ZCambioParidad = IIf(IsDBNull(.Item("CambioDivisa")), "0", .Item("CambioDivisa"))
                        If cbx_TipoDolar.SelectedIndex = 2 Then
                            MsgBox("Se utilizara el divisa para los calculos, pero al autorizar se solicitara la paridad a usar", MsgBoxStyle.Information)
                        End If
                    Else
                        If cbx_TipoDolar.SelectedIndex = 2 Then
                            ZCambioParidad = IIf(IsDBNull(.Item("Cambio")), "0", .Item("Cambio"))
                        End If
                    End If

                    If cbx_TipoDolar.SelectedIndex = 0 Then
                        Return ZCambioParidad
                    End If

                    If cbx_TipoDolar.SelectedIndex <> 0 Then
                        If ZCambioParidad = 0 Then
                            MsgBox("La fecha " & Date.Today.ToString("dd/MM/yyyy") & " no tiene informado cambio Dolar", MsgBoxStyle.Information)
                        End If
                    End If

                End With



            End If

        Catch ex As System.Exception
            Throw New System.Exception("Hubo un problema al querer consultar la Base de Datos.")
        End Try

        Return ZCambioParidad
    End Function





    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Importe.KeyPress, txt_Paridad.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Proveedor.KeyPress, txt_Cuenta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        Dim SQLCnslt As String
        Dim ValidacionesOk As Boolean = True
        VALIDACIONES = ValidacionesOk
        '
        '    VALIDACIONES
        '
        If Trim(txt_FechaRequerida.Text.Replace("/", "")) <> "" Then
            If ValidaTiempoFecha(txt_FechaRequerida.Text) = "N" Then
                ValidacionesOk = False
                VALIDACIONES = ValidacionesOk
                Exit Sub
            End If
        End If

        Select Case cbx_Tipo.SelectedIndex
            Case 0
                MsgBox("Debe seleccionar un tipo de solicitud", vbExclamation)
                ValidacionesOk = False
                VALIDACIONES = ValidacionesOk
                Exit Sub
            Case 1
                If Trim(txt_Proveedor.Text) <> "" Then
                    SQLCnslt = "SELECT Proveedor FROM Proveedor WHERE Proveedor = '" & Trim(txt_Proveedor.Text) & "'"
                    Dim rowProveedor As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If rowProveedor Is Nothing Then
                        MsgBox("El proveedor ingresado no es valido verificar", vbExclamation)
                        ValidacionesOk = False
                        VALIDACIONES = ValidacionesOk
                        Exit Sub
                    End If
                Else
                    MsgBox("Debe ingresarse un proovedpr", vbExclamation)
                    ValidacionesOk = False
                    VALIDACIONES = ValidacionesOk
                    Exit Sub
                End If

            Case 2
                If Trim(txt_Cuenta.Text) <> "" Then
                    SQLCnslt = "SELECT Cuenta FROM Cuenta WHERE Cuenta = '" & Trim(txt_Cuenta.Text) & "'"
                    Dim rowCuenta As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If rowCuenta Is Nothing Then
                        MsgBox("La Cuenta ingresada no es valida verificar", vbExclamation)
                        ValidacionesOk = False
                        VALIDACIONES = ValidacionesOk
                        Exit Sub
                    End If
                Else
                    MsgBox("Debe ingresarse una Cuenta", vbExclamation)
                    ValidacionesOk = False
                    VALIDACIONES = ValidacionesOk
                    Exit Sub
                End If
        End Select

        If cbx_Moneda.SelectedIndex = 0 Then
            MsgBox("No se selecciono el tipo de moneda", vbExclamation)
            ValidacionesOk = False
            VALIDACIONES = ValidacionesOk
            Exit Sub
        End If

        If cbx_Moneda.SelectedIndex = 2 And cbx_TipoDolar.SelectedIndex = 0 Then
            MsgBox("No se selecciono el tipo de Dolar", vbExclamation)
            ValidacionesOk = False
            VALIDACIONES = ValidacionesOk
            Exit Sub
        End If

        If Val(txt_Importe.Text) = 0 Then
            MsgBox("No se puede generar una solicitud con un valor de importe igual a 0", vbExclamation)
            ValidacionesOk = False
            VALIDACIONES = ValidacionesOk
            Exit Sub
        End If

        If (chk_Efectivo.Checked = False And chk_Tranferencia.Checked = False And chk_Echeq.Checked = False And chk_ChequeTerceros.Checked = False And chk_ChequePropio.Checked = False And chk_Tarjeta.Checked = False) Then
            MsgBox("Se debe seleccionar al menos una forma de pago", vbExclamation)
            ValidacionesOk = False
            VALIDACIONES = ValidacionesOk
            Exit Sub
        End If

        If Trim(txt_Titulo.Text) = "" Then
            MsgBox("Se debe ingresar un Titulo", vbExclamation)
            ValidacionesOk = False
            VALIDACIONES = ValidacionesOk
            Exit Sub
        End If

        If Trim(txt_Concepto.Text) = "" Then
            MsgBox("Se debe ingresar un Detalle", vbExclamation)
            ValidacionesOk = False
            VALIDACIONES = ValidacionesOk
            Exit Sub
        End If




        '
        '  FIN DE VALIDACIONES
        '

        Dim Estado As String = ""
        Try

            'SI ESTA EDITANDO USO EL NUMERO DE EDICION Y BORRO EL REGISTRO EN CASO CONTRARIO OBTENGO EL SIGUIENTE NUMERO
            Dim NroSolicitud As Integer
            If NRO_SOLICITUD = 0 Then
                SQLCnslt = "SELECT NroSolicitudes = max(NroSolicitud) FROM SolicitudFondos"
                Dim RowSolicitud As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                If RowSolicitud IsNot Nothing Then
                    With RowSolicitud
                        NroSolicitud = IIf(IsDBNull(.Item("NroSolicitudes")), 0, .Item("NroSolicitudes")) + 1
                    End With
                End If
            Else
                NroSolicitud = NRO_SOLICITUD

                Try
                    SQLCnslt = "SELECT Estado FROM SolicitudFondos WHERE NroSolicitud = '" & NroSolicitud & "'"
                    Dim RowSoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowSoli IsNot Nothing Then
                        Estado = Trim(IIf(IsDBNull(RowSoli.Item("Estado")), "", RowSoli.Item("Estado")))
                    End If


                    SQLCnslt = "DELETE FROM SolicitudFondos WHERE NroSolicitud = '" & NroSolicitud & "'"
                    ExecuteNonQueries("SurfactanSa", SQLCnslt)
                Catch ex As Exception
                    MsgBox("No se pudo Actualizar el registro")
                    Exit Sub
                End Try

            End If



            Dim ProvCuenta As String
            Select Case cbx_Tipo.SelectedIndex

                Case 1
                    ProvCuenta = "'" & txt_Proveedor.Text & "', " _
                                & "'" & "" & "', "
                Case 2
                    ProvCuenta = "'" & "" & "', " _
                                & "'" & txt_Cuenta.Text & "', "
            End Select


            Dim agregado_1 As String = ""
            Dim agregado_2 As String = ""

            If Estado <> "" Then
                agregado_1 = "Estado, "
                agregado_2 = "'" & Estado & "', "
            End If

            Dim ParidadInformada_1 As String = ""
            Dim ParidadInformada_2 As String = ""

            If cbx_TipoDolar.SelectedItem = "Informado" Then
                ParidadInformada_1 = "ParidadInformada, "
                ParidadInformada_2 = "'" & formatonumerico(txt_Paridad.Text) & "', "
            End If
            


            SQLCnslt = "INSERT INTO SolicitudFondos(" _
                       & "NroSolicitud, " _
                       & "Solicitante, " _
                       & "Fecha, " _
                       & "OrdFecha, " _
                       & "Tipo, " _
                       & "Proveedor, " _
                       & "Cuenta, " _
                       & "ObservacionesPago, " _
                       & "Titulo, " _
                       & "Concepto, " _
                       & "Moneda, " _
                       & "TipoDolar, " _
                       & "Importe, " _
                       & "Efectivo_chk, " _
                       & "Transferencia_chk, " _
                       & "Echeq_chk, " _
                       & "CheqTerceros_chk, " _
                       & "CheqPropio_chk, " _
                       & "Tarjeta_chk, " _
                       & "FechaRequerida, " _
                       & "OrdFechaRequerida, " _
                       & "" & agregado_1 & "" _
                       & "" & ParidadInformada_1 & "" _
                       & "MarcaPopUp, " _
                       & "MarcaPopUp_Pachi, " _
                       & "Operador_Sector, " _
                       & "OrdenPago)" _
                       & " VALUES(" _
                       & "'" & NroSolicitud & "', " _
                       & "'" & Trim(txt_Solicitante.Text) & "', " _
                       & "'" & txt_FechaSolicitud.Text & "', " _
                       & "'" & ordenaFecha(txt_FechaSolicitud.Text) & "', " _
                       & "'" & cbx_Tipo.SelectedIndex & "', " _
                       & ProvCuenta _
                       & "'" & Trim(txt_Observaciones.Text) & "', " _
                       & "'" & Trim(txt_Titulo.Text) & "', " _
                       & "'" & Trim(txt_Concepto.Text) & "', " _
                       & "'" & cbx_Moneda.SelectedIndex & "', " _
                       & "'" & cbx_TipoDolar.SelectedIndex & "', " _
                       & "'" & formatonumerico(txt_Importe.Text) & "', " _
                       & "'" & chk_Efectivo.Checked & "', " _
                       & "'" & chk_Tranferencia.Checked & "', " _
                       & "'" & chk_Echeq.Checked & "', " _
                       & "'" & chk_ChequeTerceros.Checked & "', " _
                       & "'" & chk_ChequePropio.Checked & "', " _
                       & "'" & chk_Tarjeta.Checked & "', " _
                       & "'" & txt_FechaRequerida.Text & "', " _
                       & "'" & ordenaFecha(txt_FechaRequerida.Text) & "', " _
                       & "" & agregado_2 & " " _
                       & "" & ParidadInformada_2 & " " _
                       & "'" & "" & "', " _
                       & "'" & "" & "', " _
                       & "'" & Trim(Operador.Solifondos_Sector) & "', " _
                       & "'" & "" & "') "

            ExecuteNonQueries("SurfactanSa", SQLCnslt)



            If DirecctorioVacio(CarpetaAux) Then
                _SubirArchvios(NroSolicitud)
            End If

            If MsgBox("Su numero de solicitud es " & NroSolicitud & ". ¿Desea imprimirla?", vbYesNo) = vbYes Then
                Dim WFormula As String = "{SolicitudFondos.NroSolicitud} = " & NroSolicitud & ""

                With New VistaPrevia
                    .Reporte = New Reporte_SolicitudFondos
                    .Formula = WFormula
                    '.Formula = "{SolicitudFondos.NroSolicitud} > " & (NRO_SOLICITUD - 1) & " AND {SolicitudFondos.NroSolicitud} < " & (NRO_SOLICITUD + 1) & ""

                    .Imprimir()

                End With
            End If

            If NRO_SOLICITUD = 0 Then
                GuardarSolicitudOriginal(NroSolicitud)
            End If



            Dim Wowner As IActualizaSolicitudes = TryCast(Owner, IActualizaSolicitudes)

            If Wowner IsNot Nothing Then
                Wowner.ActualizaGrilla()
            End If

            'Actualizamos esta variable para no informar que se mostraron los archivos
            LimpiaGrabar = "SI"
            btn_Limpiar_Click(Nothing, Nothing)

            If NRO_SOLICITUD <> 0 Then
                Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GuardarSolicitudOriginal(ByVal NroSolicitud As Integer)
        Dim WFormula As String = "{SolicitudFondos.NroSolicitud} = " & NroSolicitud & ""

        With New VistaPrevia
            .Reporte = New Reporte_SolicitudFondos
            .Formula = WFormula
            '.Formula = "{SolicitudFondos.NroSolicitud} > " & (NRO_SOLICITUD - 1) & " AND {SolicitudFondos.NroSolicitud} < " & (NRO_SOLICITUD + 1) & ""
            Dim UbicacionGrabar As String = RutaGuardar & "\" & NroSolicitud
            If Not Directory.Exists(UbicacionGrabar) Then
                Directory.CreateDirectory(UbicacionGrabar)
            End If

            .GuardarPDF("SolicitudOriginal_" & NroSolicitud.ToString(), UbicacionGrabar & "\")

        End With
       
    End Sub
    
    Private Sub Ingreso_Solicitud_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cbx_Tipo.Focus()
    End Sub

    Private Sub txt_Solicitante_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Solicitante.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_Solicitante.Text) <> "" Then
                    cbx_Tipo.Focus()
                End If
            Case Keys.Escape
                txt_Solicitante.Text = ""
        End Select
    End Sub

    Private Sub cbx_Tipo_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_Tipo.DropDownClosed
        Select Case cbx_Tipo.SelectedIndex
            Case 0
                txt_CuentaDescrip.Text = ""
                txt_Cuenta.Text = ""
                txt_Proveedor.Text = ""
                txt_ProveedorDescrip.Text = ""
                txt_CuentaDescrip.Enabled = False
                txt_Cuenta.Enabled = False
                txt_Proveedor.Enabled = False
                txt_ProveedorDescrip.Enabled = False
            Case 1
                txt_CuentaDescrip.Text = ""
                txt_Cuenta.Text = ""
                txt_CuentaDescrip.Enabled = False
                txt_Cuenta.Enabled = False
                txt_Proveedor.Enabled = True
                txt_ProveedorDescrip.Enabled = True
            Case 2
                txt_CuentaDescrip.Enabled = True
                txt_Cuenta.Enabled = True
                txt_Proveedor.Text = ""
                txt_ProveedorDescrip.Text = ""
                txt_Proveedor.Enabled = False
                txt_ProveedorDescrip.Enabled = False
        End Select
    End Sub

    Private Sub cbx_Tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_Tipo.SelectedIndexChanged
        Select Case cbx_Tipo.SelectedIndex
            Case 0
                txt_CuentaDescrip.Text = ""
                txt_Cuenta.Text = ""
                txt_Proveedor.Text = ""
                txt_ProveedorDescrip.Text = ""
                txt_CuentaDescrip.Enabled = False
                txt_Cuenta.Enabled = False
                txt_Proveedor.Enabled = False
                txt_ProveedorDescrip.Enabled = False
            Case 1
                txt_CuentaDescrip.Text = ""
                txt_Cuenta.Text = ""
                txt_CuentaDescrip.Enabled = False
                txt_Cuenta.Enabled = False
                txt_Proveedor.Enabled = True
                txt_ProveedorDescrip.Enabled = True
            Case 2
                txt_CuentaDescrip.Enabled = True
                txt_Cuenta.Enabled = True
                txt_Proveedor.Text = ""
                txt_ProveedorDescrip.Text = ""
                txt_Proveedor.Enabled = False
                txt_ProveedorDescrip.Enabled = False
        End Select
    End Sub

    Private Sub cbx_Tipo_KeyDown(sender As Object, e As KeyEventArgs) Handles cbx_Tipo.KeyDown
        If txt_Proveedor.Enabled = True Then
            txt_Proveedor.Focus()
        Else
            txt_Cuenta.Focus()
        End If
    End Sub

    Private Sub txt_Proveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Proveedor.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = ""
                If Trim(txt_Proveedor.Text) <> "" Then
                    SQLCnslt = "SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Trim(txt_Proveedor.Text) & "'"
                    Dim RowProveedor As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowProveedor IsNot Nothing Then
                        txt_ProveedorDescrip.Text = Trim(RowProveedor.Item("Nombre"))
                        cbx_Moneda.Focus()
                    Else
                        MsgBox("No se encontro un proveedor con ese codigo, verifique", vbExclamation)
                        txt_Proveedor.SelectAll()
                    End If

                Else
                    With New Consulta()
                        .Show(Me)
                    End With
                End If
            Case Keys.Escape
                txt_Proveedor.Text = ""
        End Select

    End Sub

    Private Sub txt_Cuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cuenta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = ""
                If Trim(txt_Cuenta.Text) <> "" Then
                    SQLCnslt = "SELECT Descripcion FROM Cuenta WHERE Cuenta = '" & Trim(txt_Cuenta.Text) & "'"
                    Dim RowCuenta As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowCuenta IsNot Nothing Then
                        txt_CuentaDescrip.Text = Trim(RowCuenta.Item("Descripcion"))
                        cbx_Moneda.Focus()
                    Else
                        MsgBox("No se encontro una Cuenta con ese codigo, verifique", vbExclamation)
                        txt_Cuenta.SelectAll()
                    End If
                Else
                    With New Consulta(1)
                        .Show(Me)
                    End With
                End If
            Case Keys.Escape
                txt_Cuenta.Text = ""
        End Select
    End Sub

    Private Sub cbx_Moneda_KeyDown(sender As Object, e As KeyEventArgs) Handles cbx_Moneda.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If cbx_Moneda.SelectedIndex <> 0 Then
                    If cbx_Moneda.SelectedIndex = 2 Then
                        lbl_TipoDolar.Visible = True
                        cbx_TipoDolar.Visible = True
                    Else
                        lbl_TipoDolar.Visible = False
                        cbx_TipoDolar.Visible = False
                    End If
                    txt_Importe.Focus()
                End If

        End Select
    End Sub
    Private Sub cbx_Moneda_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_Moneda.DropDownClosed

        If cbx_Moneda.SelectedIndex = 2 Then
            lbl_TipoDolar.Visible = True
            cbx_TipoDolar.Visible = True
        Else
            lbl_TipoDolar.Visible = False
            cbx_TipoDolar.Visible = False
        End If
        txt_Importe.Focus()

    End Sub

    Private Sub txt_Importe_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Importe.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If Val(txt_Importe.Text) > 0 Then
                    txt_Importe.Text = formatonumerico(txt_Importe.Text)
                    Multiplicaporparidad()
                    _RecalcularRetenciones()
                    txt_TotalApagar.Text = formatonumerico(Val(txt_ImportePesos.Text) - Val(txt_TotalRetenciones.Text))
                    txt_FechaRequerida.Focus()
                End If
            Case Keys.Escape
                txt_Importe.Text = ""
        End Select
    End Sub

    Private Sub txt_FechaRequerida_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FechaRequerida.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_FechaRequerida.Text.Replace("/", "")) = "" Then
                    txt_Observaciones.Focus()
                Else
                    If ValidaFecha(txt_FechaRequerida.Text) = "S" Then
                        If ValidaTiempoFecha(txt_FechaRequerida.Text) = "S" Then
                            txt_Observaciones.Focus()
                        End If
                    Else
                        MsgBox("La fecha Requerida no es valida, verificar", vbExclamation)
                        txt_FechaRequerida.SelectAll()
                    End If
                End If
            Case Keys.Escape
                txt_FechaRequerida.Text = ""
        End Select
    End Sub

    Private Function ValidaTiempoFecha(ByVal Fecha As String)
        Dim DateFecha As Date = Date.Today
        DateFecha = DateFecha.AddMonths(1)
        Dim OrdFechaMax As String = DateFecha.ToString("yyyyMMdd")
        Dim OrdFechaActual As String = Date.Today.ToString("yyyyMMdd")
        Dim OrdFecha As String = ordenaFecha(Fecha)
        Dim Resultado As String = "S"
        'CONSULTAMOS SI LA FECHA ES MENOR A LA FECHA ACTUAL
        If OrdFecha < OrdFechaActual Then
            MsgBox("La fecha requerida no puede ser menor a la fecha actual")
            Return "N"
        End If
        'CONSULTAMOS SI LA FECHA ES MAYOR A UN MES DE LA FECHA ACTUAL
        If OrdFecha > OrdFechaMax Then
            MsgBox("La fecha requerida no puede superar el mes desde la fecha actual")
            Return "N"
        End If

        Return "S"
    End Function


    Private Sub txt_Observaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Observaciones.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                txt_Titulo.Focus()

            Case Keys.Escape
                txt_Observaciones.Text = ""
        End Select
    End Sub
    Private Sub txt_Titulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Titulo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Trim(txt_Titulo.Text) <> "" Then
                    txt_Concepto.Focus()
                End If
            Case Keys.Escape
                txt_Titulo.Text = ""
        End Select
    End Sub


    Private Sub txt_Concepto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Concepto.KeyDown
        Select Case e.KeyData

            Case Keys.Escape
                txt_Concepto.Text = ""
        End Select
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Close()
    End Sub

    Private Sub txt_Proveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_Proveedor.MouseDoubleClick
        With New Consulta()
            .Show(Me)
        End With
    End Sub

    Private Sub txt_Cuenta_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_Cuenta.MouseDoubleClick
        With New Consulta(1)
            .Show(Me)
        End With
    End Sub

    Public Sub PasaConsulta(opcion As Integer, Codigo As String, Descripcion As String) Implements IConsulta.PasaConsulta
        Select Case opcion
            Case 0
                txt_Proveedor.Text = Trim(Codigo)
                txt_ProveedorDescrip.Text = Trim(Descripcion)
                cbx_Moneda.Focus()
            Case 1
                txt_Cuenta.Text = Trim(Codigo)
                txt_CuentaDescrip.Text = Trim(Descripcion)
                cbx_Moneda.Focus()
        End Select
    End Sub



    Private Sub btn_Adjuntar_Click(sender As Object, e As EventArgs) Handles btn_Adjuntar.Click

        If NRO_SOLICITUD = 0 Then
            If Not Directory.Exists(CarpetaAux) Then
                Directory.CreateDirectory(CarpetaAux)
            End If
            With New EditorArchivos(2, CarpetaAux, Operador.Clave)
                .Show()
            End With
        Else
            With New EditorArchivos(2, RutaGuardar & "\" & NRO_SOLICITUD, Operador.Clave)
                .Show()
            End With
        End If


        '  With New EditorArchivos(2, RutaGuardar & "\" & txtNroInterno.Text)
        '      .Show()
        '  End With

    End Sub

    Private Sub _SubirArchvios(ByVal NroInterno As String)

        Dim WDestino = RutaGuardar & "\" & NroInterno
        Dim WCantCorrectas = 0

        'If RutaArchivo.Length = 0 Then : Return : End If

        Try
            'Verificamos sino existe la carpeta, sino existe la creamos
            If (Not Directory.Exists(WDestino)) Then
                Directory.CreateDirectory(WDestino)
            End If
        Catch ex As Exception

        End Try

        For Each archivo As String In Directory.GetFiles("C:\Auxiliar")
            Try
                Dim NombreArchivo As String = archivo.Remove(0, ("C:\Auxiliar\").Length)
                If Not File.Exists(WDestino & "\" & NombreArchivo) Then
                    'Si no existe lo copio
                    File.Move(archivo, WDestino & "\" & NombreArchivo)
                    WCantCorrectas += 1
                    File.Delete(archivo)
                Else
                    'sino llegan a haber borrado los archivos y le adjuntan uno
                    ' que ya existe con el mismo nombre consutamos si sobre escribir
                    If MsgBox("El Archivo """ & Path.GetFileName(archivo) & """, ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        File.Delete(WDestino & "\" & NombreArchivo)
                        File.Move(archivo, WDestino & "\" & NombreArchivo)
                        WCantCorrectas += 1

                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return
            End Try
        Next



    End Sub

    Public Function DirecctorioVacio(ByVal Ruta As String) As Boolean
        Return Directory.EnumerateFileSystemEntries(Ruta).Any()
    End Function




    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click


        txt_Solicitante.Text = Trim(Operador.Descripcion)
        txt_Proveedor.Text = ""
        txt_ProveedorDescrip.Text = ""
        txt_Cuenta.Text = ""
        txt_CuentaDescrip.Text = ""
        txt_FechaRequerida.Text = ""
        txt_Importe.Text = ""
        txt_Observaciones.Text = ""
        txt_Titulo.Text = ""
        txt_Concepto.Text = ""

        txt_RetGanancia.Text = ""
        txt_RetIBCiudad.Text = ""
        txt_RetIBru.Text = ""
        txt_RetIVA.Text = ""
        txt_Paridad.Text = ""
        txt_ImportePesos.Text = ""
        txt_TotalRetenciones.Text = ""
        txt_TotalApagar.Text = ""

        cbx_Moneda.SelectedIndex = 0
        cbx_TipoDolar.SelectedIndex = 0
        cbx_Tipo.SelectedIndex = 0

        chk_Efectivo.Checked = False
        chk_Tranferencia.Checked = False
        chk_ChequeTerceros.Checked = False
        chk_Echeq.Checked = False
        chk_ChequePropio.Checked = False

        limpiarCarpetaDatosAux()


    End Sub

    Private Sub limpiarCarpetaDatosAux()
        If Not Directory.Exists(CarpetaAux) Then Directory.CreateDirectory(CarpetaAux)

        If DirecctorioVacio(CarpetaAux) Then
            If LimpiaGrabar = "NO" Then
                MsgBox("Se limpiaron tambien los archivos adjuntos", vbExclamation)
            End If


        End If
        If Directory.Exists(CarpetaAux) Then Directory.Delete(CarpetaAux, True)

        Directory.CreateDirectory(CarpetaAux)
        'Vuelvo a asignarle a la bandera el valor de "NO"
        LimpiaGrabar = "NO"
    End Sub


    Private Sub btn_MostrarSolicitud_Click(sender As Object, e As EventArgs) Handles btn_MostrarSolicitud.Click
        Try
            Dim WFormula As String = "{SolicitudFondos.NroSolicitud} = " & NRO_SOLICITUD & ""

            With New VistaPrevia
                .Reporte = New Reporte_SolicitudFondos
                .Formula = WFormula
                '.Formula = "{SolicitudFondos.NroSolicitud} > " & (NRO_SOLICITUD - 1) & " AND {SolicitudFondos.NroSolicitud} < " & (NRO_SOLICITUD + 1) & ""

                .Mostrar()
            End With
        Catch ex As Exception

        End Try

    End Sub

    'CALCULO DE RETENCIONES

    Private Sub _RecalcularRetenciones()

        Dim WGanancias As Double = 0.0
        Dim WIBCiudad As Double = 0.0
        Dim WIngresosBrutos As Double = 0.0
        Dim WIVA As Double = 0.0
        Dim WTotal As Double = 0.0

        If Trim(txt_Proveedor.Text) <> "" And Trim(txt_ProveedorDescrip.Text) <> "" Then
            Dim SQLCnslt As String = "SELECT Tipo, Iva, CodIb, CodIbCaba, porceIB, porceIBCABA FROM Proveedor WHERE Proveedor = '" & Trim(txt_Proveedor.Text) & "'"

            Dim RowProveedor As DataRow = GetSingle(SQLCnslt, "SurfactanSa")


            Dim WTipoProv = RowProveedor.Item("tipo") + 1
            Dim WTipoIva = RowProveedor.Item("Iva")
            Dim WTipoIb = RowProveedor.Item("CodIb")
            Dim WTipoIbCaba = RowProveedor.Item("CodIbCaba")
            Dim WPorceIb = RowProveedor.Item("porceIB")
            Dim WPorceIbCaba = RowProveedor.Item("porceIBCABA")




            ' Recalculo de Retenciones de Ganancias.
            Try
                _RecalcularRetencionGanancias(WGanancias, WTipoProv, WTipoIva)
            Catch ex As Exception
            End Try


            ' Recalculo de Retenciones por Iva.
            _RecalcularRetencionIVA()


            Try
                ' Recalculo IB Provincia
                _RecalcularIBProvincia(WIngresosBrutos, WTipoIb, WPorceIb)
            Catch ex As Exception
            End Try



            Try
                ' Recalculo IB CABA
                _RecalcularIBCABA(WIBCiudad, WTipoIbCaba, WPorceIbCaba)
            Catch ex As Exception
            End Try


            txt_RetGanancia.Text = formatonumerico(WGanancias)
            txt_RetIVA.Text = formatonumerico(WIVA)
            txt_RetIBCiudad.Text = formatonumerico(WIBCiudad)
            txt_RetIBru.Text = formatonumerico(WIngresosBrutos)

            txt_TotalRetenciones.Text = formatonumerico(Val(formatonumerico(WIVA)) + Val(formatonumerico(WGanancias)) + Val(formatonumerico(WIBCiudad)) + Val(formatonumerico(WIngresosBrutos)))


        End If

    End Sub

    Private Sub _RecalcularRetencionGanancias(ByRef WGanancias As Double, ByVal WTipoProv As Integer, ByVal WTipoIva As Integer)
        Dim ZZBase As Object = _CalcularSaldoBaseRetencionesGanancias(WTipoIva)

        Dim varOrdFecha As String = Mid(ordenaFecha(Date.Today.ToString("dd/MM/yyyy")), 3, 4)

        Dim CampoAcumulado As LeeAcumulado = DaoAcumulado.buscarAcumulado(txt_Proveedor.Text, varOrdFecha)

        Dim varAcuNeto = CampoAcumulado.neto
        Dim varAcuRetenido = CampoAcumulado.retenido
        Dim varAcuAnticipo = CampoAcumulado.anticipo
        Dim varAcuBruto = CampoAcumulado.bruto
        Dim varAcuIva = CampoAcumulado.iva


        Dim varRetGan = CaculoRetencionGanancia(Val(WTipoProv), ZZBase, varAcuNeto, varAcuRetenido, varAcuAnticipo, varAcuBruto, varAcuIva)

        WGanancias = varRetGan
    End Sub

    Private Function _CalcularSaldoBaseRetencionesGanancias(ByVal WTipoIva As Integer) As Object

        Dim varAcuNeto = 0
        Dim varAcuRetenido = 0
        Dim varAcuAnticipo = 0
        Dim varAcuBruto = 0
        Dim varAcuIva = 0

        Dim varOrdFecha As String = Mid(ordenaFecha(Date.Today.ToString("dd/MM/yyyy")), 3, 4)

        Dim CampoAcumulado As LeeAcumulado = DaoAcumulado.buscarAcumulado(txt_Proveedor.Text, varOrdFecha)

        If Not IsNothing(CampoAcumulado) Then

            varAcuNeto = CampoAcumulado.neto
            varAcuRetenido = CampoAcumulado.retenido
            varAcuAnticipo = CampoAcumulado.anticipo
            varAcuBruto = CampoAcumulado.bruto
            varAcuIva = CampoAcumulado.iva

        End If

        Dim ZZBase, ZZSumaNeto

        ZZBase = 0.0
        ZZSumaNeto = 0.0

        ' Recalculo sobre porcentaje neto en Iva Comp.
        'For Each row As DataGridViewRow In gridPagos.Rows
        '    With row
        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma
        Dim ZFactura As DataRow

        If Trim(txt_ImportePesos.Text) <> "" Then
            'ZTipo = .Cells(0).Value
            'ZLetra = .Cells(1).Value
            'ZPunto = .Cells(2).Value
            'ZNumero = .Cells(3).Value
            ZImporte = txt_ImportePesos.Text '.Cells(4).Value

            'ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZPunto, ZLetra, ZNumero)

            'If Not IsNothing(ZFactura) Then
            '
            '    ZNeto = _NormalizarNumero(ZFactura.Item("Neto"))
            '    ZIva = _NormalizarNumero(ZFactura.Item("Iva21"))
            '    ZIva5 = _NormalizarNumero(ZFactura.Item("Iva5"))
            '    ZIva27 = _NormalizarNumero(ZFactura.Item("Iva27"))
            '    ZIva105 = _NormalizarNumero(ZFactura.Item("Iva105"))
            '    ZIb = _NormalizarNumero(ZFactura.Item("Ib"))
            '    ZExento = _NormalizarNumero(ZFactura.Item("Exento"))
            '
            '    ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento
            '
            '
            '    If Val(ZImporte) = Val(ZTotal) Then
            '
            '        ZZSuma = ZNeto
            '
            '    Else
            '
            '        ZPorce = Val(ZImporte) / ZTotal
            '
            '        ZZSuma = ZNeto * ZPorce
            '    End If
            '
            'Else

            ZZSuma = Val(ZImporte) / 1.21

        End If

        ZZBase += Val(ZImporte)
        ZZSumaNeto += ZZSuma
        '        Else
        'Exit For
        '        End If
        '    End With
        'Next

        If Val(WTipoIva) = 2 Then
            ZZBase = ZZSumaNeto
        End If
        Return ZZBase
    End Function

    Private Sub _RecalcularRetencionIVA()
        ' Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte
        ' Dim ZNeto, ZZSuma, ZZBase
        ' Dim ZFactura As DataRow
        '
        ' ZZBase = 0
        '
        ' ' Recalculo sobre porcentaje neto en Iva Comp.
        ' For Each row As DataGridViewRow In gridPagos.Rows
        '     With row
        '         If Trim(.Cells(4).Value) <> "" Then
        '             ZTipo = .Cells(0).Value
        '             ZLetra = .Cells(1).Value
        '             ZPunto = .Cells(2).Value
        '             ZNumero = .Cells(3).Value
        '             ZImporte = .Cells(4).Value
        '
        '
        '             ZZSuma = 0.0
        '
        '             If Val(ZImporte) <> 0 And UCase(ZLetra) = "M" Then
        '
        '                 ZNeto = ZImporte / 1.21
        '
        '                 If ZNeto >= 1000 Then
        '
        '                     ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZPunto, ZLetra, ZNumero)
        '
        '                     If Not IsNothing(ZFactura) Then
        '
        '                         ZZSuma = ZFactura.Item("Iva21")
        '
        '                     Else
        '
        '                         ZZSuma = Val(ZImporte) / 1.21
        '
        '                     End If
        '
        '                 End If
        '
        '             End If
        '
        '             ZZBase += ZZSuma
        '         Else
        '             Exit For
        '         End If
        '     End With
        ' Next
        '
        ' txtIVA.Text = _NormalizarNumero(ZZBase)
    End Sub

    Private Sub _RecalcularIBProvincia(ByRef WIngresosBrutos As Double, ByVal WTipoIb As String, ByVal WPorceIb As String)
        Dim acumProv

        Dim ZTipo, ZNumero, ZPunto, ZLetra, ZImporte, ZTotal
        Dim ZNeto, ZIva, ZIva5, ZIva27, ZIva105, ZIb, ZExento, ZPorce, ZZSuma
        Dim ZFactura As DataRow

        acumProv = 0

        'For Each row As DataGridViewRow In gridPagos.Rows
        '    With row
        If Trim(txt_ImportePesos.Text) <> "" Then

            ZZSuma = 0.0

            ' Recalculo sobre porcentaje neto en Iva Comp.
            If Trim(txt_ImportePesos.Text) <> "" Then
                ' ZTipo = .Cells(0).Value
                ' ZLetra = .Cells(1).Value
                ' ZPunto = .Cells(2).Value
                ' ZNumero = .Cells(3).Value
                ZImporte = _NormalizarNumero(txt_ImportePesos.Text)
                '
                ' ZFactura = _BuscarCompra(txtProveedor.Text, ZTipo, ZPunto, ZLetra, ZNumero)
                '
                ' If Not IsNothing(ZFactura) Then
                '
                '     ZNeto = _NormalizarNumero(ZFactura.Item("Neto"))
                '
                '     ZIva = _NormalizarNumero(ZFactura.Item("Iva21"))
                '     ZIva5 = _NormalizarNumero(ZFactura.Item("Iva5"))
                '     ZIva27 = _NormalizarNumero(ZFactura.Item("Iva27"))
                '     ZIva105 = _NormalizarNumero(ZFactura.Item("Iva105"))
                '     ZIb = _NormalizarNumero(ZFactura.Item("Ib"))
                '     ZExento = _NormalizarNumero(ZFactura.Item("Exento"))
                '
                '     ZTotal = ZNeto + ZIva + ZIva27 + ZIva105 + ZIb + ZIva5 + ZExento
                '
                '     If Val(_NormalizarNumero(ZImporte)) = Val(_NormalizarNumero(ZTotal)) Then
                '
                '         ZZSuma = ZNeto
                '
                '     Else
                '
                '         ZPorce = Val(ZImporte) / ZTotal
                '
                '         ZZSuma = ZNeto * ZPorce
                '     End If
                '
                ' Else

                ZZSuma = Val(ZImporte) / 1.21

                ' End If

            End If

            acumProv += CaculoRetencionIngresosBrutos(Val(WTipoIb), Val(WPorceIb), Val(ZZSuma))
            'Else
            ' Exit For
        End If
        '     End With
        ' Next

        WIngresosBrutos = _NormalizarNumero(acumProv)
    End Sub

    Private Sub _RecalcularIBCABA(ByRef WIBCiudad As Double, ByVal WTipoIBCaba As String, ByVal WPorceIbCaba As String)

        Dim ZZSuma, acumCaba

        acumCaba = 0.0

        If Val(WPorceIbCaba) <> 0 And Val(WTipoIBCaba) <> 2 Then

            If Trim(txt_ImportePesos.Text) <> "" Then

                ZZSuma = Val(txt_ImportePesos.Text) / 1.21

                acumCaba = CaculoRetencionIngresosBrutosCaba(Val(WTipoIBCaba), WPorceIbCaba, Val(ZZSuma))

            End If



        End If

        WIBCiudad = _NormalizarNumero(acumCaba)
    End Sub

    Private Function _NormalizarNumero(ByVal znumero As Object, Optional ByVal decimales As Integer = 2)
        If IsDBNull(znumero) Then
            znumero = ""
        End If
        Return Val(formatonumerico(Trim(znumero), decimales))
    End Function


    Private Sub cbx_TipoDolar_DropDownClosed(sender As Object, e As EventArgs) Handles cbx_TipoDolar.DropDownClosed

        'SI SE SELECCIONA INFORMADO SE DEBE CARGAR LA PARIDAD MANUALMENTE
        If cbx_TipoDolar.SelectedItem = "Informado" Then
            WParidad = 0
        Else
            Try
                'OBTENEMOS LA PARIDAD
                ZCambioDivisa = _BuscarParidad(Date.Today.ToString("dd/MM/yyyy"))
            Catch ex As System.Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

            If ZCambioDivisa = 0 Then
                If cbx_TipoDolar.SelectedIndex <> 0 Then
                    MsgBox("La fecha " & Date.Today.ToString("dd/MM/yyyy") & " no tiene informado paridad, se de cargar para calcular las retenciones", MsgBoxStyle.Information)
                End If

            End If
            WParidad = ZCambioDivisa
            txt_Paridad.ReadOnly = True
        End If
        

        txt_Paridad.Text = WParidad

        If WParidad = 0 And cbx_TipoDolar.SelectedItem = "Informado" Then
            txt_Paridad.ReadOnly = False
            txt_Paridad.SelectAll()
            txt_Paridad.Focus()
        End If


    End Sub

    Private Sub cbx_TipoDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles cbx_TipoDolar.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                'OBTENEMOS LA PARIDAD
                Try
                    ZCambioDivisa = _BuscarParidad(Date.Today.ToString("dd/MM/yyyy"))
                Catch ex As System.Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

                If ZCambioDivisa = 0 Then
                    MsgBox("La fecha " & Date.Today.ToString("dd/MM/yyyy") & " no tiene informado paridad, se de cargar para calcular las retenciones", MsgBoxStyle.Information)
                End If

                WParidad = ZCambioDivisa

                txt_Paridad.Text = WParidad
        End Select
    End Sub


    Private Sub btn_Autorizar_Click(sender As Object, e As EventArgs) Handles btn_Autorizar.Click
        'LO TUVE QUE PONER ACA ESTE CAST SINO PERDIA LA REFERENCIA NO SE PORQUE
        Dim Wowner As IActualizaSolicitudes = TryCast(Owner, IActualizaSolicitudes)

        If MsgBox("¿Desea autorizar la solicitud?", vbYesNo) = vbYes Then
            If Trim(Operador.Clave) = "" Then
                With New SoliContra()
                    .Show(Me)
                End With
            Else
                Try
                    Dim SQLCnslts As String = "SELECT SolicitudFondosEdicion FROM Operador WHERE UPPER(Clave) = '" & UCase(Operador.Clave) & "'"
                    Dim Row As DataRow = GetSingle(SQLCnslts, "SurfactanSa")

                    If Row IsNot Nothing Then
                        Dim PermisoSistemaSolicitud As String = IIf(IsDBNull(Row.Item("SolicitudFondosEdicion")), "N", Row.Item("SolicitudFondosEdicion"))
                        'If UCase(txt_Contraseña.Text) = "AUTORIZO" Then
                        If PermisoSistemaSolicitud = "S" Then

                            '    Autorizado("S", NRO_SOLICITUD)
                            '
                            'Else

                            AutorizarSolicitudes()
                            'Dim Wowner As IActualizaSolicitudes = TryCast(Owner, IActualizaSolicitudes)
                            If Wowner IsNot Nothing Then
                                Wowner.ActualizaGrilla()
                            End If
                            Close()
                        End If
                    End If


                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Public Sub Autorizado(Permiso As String, NroSolicutud As Integer) Implements IContraseña.Autorizado
        Throw New NotImplementedException
    End Sub

    Public Sub AutorizarSolicitudes() Implements IContraseña.AutorizarSolicitudes
        'EJECUTAMOS EL GRABAR PARA QUE SE ACTUALIZE LAS MODIFICACIONES
        btn_Grabar_Click(Nothing, Nothing)

        Dim listaAutorizar As New List(Of String)
        Dim SQLCnslt As String = ""

        If VALIDACIONES = False Then
            Exit Sub
        End If

        SQLCnslt = "UPDATE SolicitudFondos SET Estado = 'AUTORIZO' WHERE NroSolicitud = '" & NRO_SOLICITUD & "'"
        listaAutorizar.Add(SQLCnslt)

        Try
            ExecuteNonQueries("SurfactanSa", listaAutorizar.ToArray())

            Dim Wowner As IActualizaSolicitudes = TryCast(Owner, IActualizaSolicitudes)

            If Wowner IsNot Nothing Then
                Wowner.ActualizaGrilla()
            End If

        Catch ex As Exception

        End Try
       
    End Sub
    
    Private Sub txt_Paridad_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Paridad.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                WParidad = Val(formatonumerico(txt_Paridad.Text))
            Case Keys.Escape
                txt_Paridad.Text = "0.00"
                txt_Paridad.SelectAll()
        End Select
    End Sub

    Private Sub txt_Paridad_Leave(sender As Object, e As EventArgs) Handles txt_Paridad.Leave
        WParidad = Val(formatonumerico(txt_Paridad.Text))
        txt_Paridad.Text = Val(formatonumerico(txt_Paridad.Text))
    End Sub

End Class