Imports System.IO
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports GestorDeArchivos
Imports Util

Public Class Ingreso_Solicitud : Implements IConsulta

    Dim CarpetaAux As String = "C:\" & "Auxiliar_SolicitudFondos"
    Dim RutaGuardar As String = "\\193.168.0.2\g$\vb\NET\ArchivosRelacionadosSoliitudFondos"

    Dim NRO_SOLICITUD As Integer = 0
    Sub New(Optional ByVal NroSoli As Integer = 0)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_FechaSolicitud.Text = Date.Today.ToString("dd/MM/yyyy")
        txt_CuentaDescrip.Enabled = False
        txt_Cuenta.Enabled = False
        txt_Proveedor.Enabled = False
        txt_ProveedorDescrip.Enabled = False

        btn_Limpiar_Click(Nothing, Nothing)



        Dim SQLCnslt As String = ""
        If NroSoli <> 0 Then
            'CARGAMOS EL REGISTRO
            SQLCnslt = "SELECT * FROM SolicitudFondos WHERE NroSolicitud = '" & NroSoli & "'"
            Dim rowsoli As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowsoli IsNot Nothing Then

                NRO_SOLICITUD = NroSoli

                cbx_Moneda.SelectedIndex = rowsoli.Item("Moneda")
                cbx_Tipo.SelectedIndex = rowsoli.Item("Tipo")

                txt_Solicitante.Text = rowsoli.Item("Solicitante")
                txt_Concepto.Text = rowsoli.Item("Concepto")
                txt_FechaSolicitud.Text = rowsoli.Item("Fecha")

                txt_Proveedor.Text = rowsoli.Item("Proveedor")
                If Trim(txt_Proveedor.Text) <> "" Then
                    txt_Proveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                End If

                txt_Cuenta.Text = rowsoli.Item("Cuenta")
                If Trim(txt_Cuenta.Text) <> "" Then
                    txt_Cuenta_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
                End If

                txt_FechaRequerida.Text = rowsoli.Item("FechaRequerida")
                txt_Importe.Text = formatonumerico(rowsoli.Item("Importe"))

                chk_Efectivo.Checked = rowsoli.Item("Efectivo_Chk")
                chk_Tranferencia.Checked = rowsoli.Item("Transferencia_Chk")
                chk_Echeq.Checked = rowsoli.Item("ECheq_Chk")
                chk_ChequeTerceros.Checked = rowsoli.Item("CheqTerceros_Chk")

            End If

            'HAGO VISIBLE EL BOTON PARA GENERAR EL REPORTE DE SOLICITUD
            btn_MostrarSolicitud.Visible = True

            'DESHABILITAMOS LOS CAMPOS QUE NO PUEDE EDITAR
            btn_Limpiar.Visible = False

            chk_Echeq.Enabled = False
            chk_Efectivo.Enabled = False
            chk_Tranferencia.Enabled = False
            chk_ChequeTerceros.Enabled = False

            cbx_Tipo.Enabled = False
            cbx_Moneda.Enabled = False

            txt_Concepto.ReadOnly = True
            txt_Solicitante.ReadOnly = True
            txt_FechaSolicitud.ReadOnly = True
            txt_Cuenta.ReadOnly = True
            txt_Proveedor.ReadOnly = True
            txt_Importe.ReadOnly = True
        End If

    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Importe.KeyPress
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

        '
        '    VALIDACIONES
        '
        Select Case cbx_Tipo.SelectedIndex
            Case 0
                MsgBox("Debe seleccionar un tipo de solicitud", vbExclamation)
                Exit Sub
            Case 1
                If Trim(txt_Proveedor.Text) <> "" Then
                    SQLCnslt = "SELECT Proveedor FROM Proveedor WHERE Proveedor = '" & Trim(txt_Proveedor.Text) & "'"
                    Dim rowProveedor As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If rowProveedor Is Nothing Then
                        MsgBox("El proveedor ingresado no es valido verificar", vbExclamation)
                        Exit Sub
                    End If
                Else
                    MsgBox("Debe ingresarse un proovedpr", vbExclamation)
                    Exit Sub
                End If

            Case 2
                If Trim(txt_Cuenta.Text) <> "" Then
                    SQLCnslt = "SELECT Cuenta FROM Cuenta WHERE Cuenta = '" & Trim(txt_Cuenta.Text) & "'"
                    Dim rowCuenta As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If rowCuenta Is Nothing Then
                        MsgBox("La Cuenta ingresada no es valida verificar", vbExclamation)
                        Exit Sub
                    End If
                Else
                    MsgBox("Debe ingresarse una Cuenta", vbExclamation)
                    Exit Sub
                End If
        End Select

        If cbx_Moneda.SelectedIndex = 0 Then
            MsgBox("No se selecciono el tipo de moneda", vbExclamation)
            Exit Sub
        End If

        If Val(txt_Importe.Text) = 0 Then
            MsgBox("No se puede generar una solicitud con un valor de importe igual a 0", vbExclamation)
            Exit Sub
        End If

        If (chk_Efectivo.Checked = False And chk_Tranferencia.Checked = False And chk_Echeq.Checked = False And chk_ChequeTerceros.Checked = False) Then
            MsgBox("Se debe seleccionar al menos una forma de pago", vbExclamation)
            Exit Sub
        End If

        If Trim(txt_Titulo.Text) = "" Then
            MsgBox("Se debe ingresar un Titulo", vbExclamation)
            Exit Sub
        End If

        If Trim(txt_Concepto.Text) = "" Then
            MsgBox("Se debe ingresar un Detalle", vbExclamation)
            Exit Sub
        End If

        '
        '  FIN DE VALIDACIONES
        '


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



            SQLCnslt = "INSERT INTO SolicitudFondos(" _
                       & "NroSolicitud, " _
                       & "Solicitante, " _
                       & "Fecha, " _
                       & "OrdFecha, " _
                       & "Tipo, " _
                       & "Proveedor, " _
                       & "Cuenta, " _
                         & "Titulo, " _
                       & "Concepto, " _
                       & "Moneda, " _
                       & "Importe, " _
                       & "Efectivo_chk, " _
                       & "Transferencia_chk, " _
                       & "Echeq_chk, " _
                       & "CheqTerceros_chk, " _
                       & "FechaRequerida, " _
                       & "OrdFechaRequerida, " _
                       & "OrdenPago)" _
                       & " VALUES(" _
                       & "'" & NroSolicitud & "', " _
                       & "'" & Trim(txt_Solicitante.Text) & "', " _
                       & "'" & txt_FechaSolicitud.Text & "', " _
                       & "'" & ordenaFecha(txt_FechaSolicitud.Text) & "', " _
                       & "'" & cbx_Tipo.SelectedIndex & "', " _
                       & ProvCuenta _
                         & "'" & Trim(txt_Titulo.Text) & "', " _
                       & "'" & Trim(txt_Concepto.Text) & "', " _
                       & "'" & cbx_Moneda.SelectedIndex & "', " _
                       & "'" & formatonumerico(txt_Importe.Text) & "', " _
                       & "'" & chk_Efectivo.Checked & "', " _
                       & "'" & chk_Tranferencia.Checked & "', " _
                       & "'" & chk_Echeq.Checked & "', " _
                       & "'" & chk_ChequeTerceros.Checked & "', " _
                       & "'" & txt_FechaRequerida.Text & "', " _
                       & "'" & ordenaFecha(txt_FechaRequerida.Text) & "', " _
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

            Dim Wowner As IActualizaSolicitudes = TryCast(Owner, IActualizaSolicitudes)

            If Wowner IsNot Nothing Then
                Wowner.ActualizaGrilla()
            End If

            btn_Limpiar_Click(Nothing, Nothing)


        Catch ex As Exception

        End Try

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
                If Trim(txt_Proveedor.Text) <> "" Then
                    SQLCnslt = "SELECT Descripcion FROM Cuenta WHERE Cuenta = '" & Trim(txt_Cuenta.Text) & "'"
                    Dim RowCuenta As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowCuenta IsNot Nothing Then
                        txt_ProveedorDescrip.Text = Trim(RowCuenta.Item("Descripcion"))
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
                    txt_Importe.Focus()
                End If

        End Select
    End Sub

    Private Sub txt_Importe_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Importe.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If Val(txt_Importe.Text) > 0 Then
                    txt_Importe.Text = formatonumerico(txt_Importe.Text)
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
                    txt_Titulo.Focus()
                Else
                    If ValidaFecha(txt_FechaRequerida.Text) = "S" Then
                        txt_Titulo.Focus()
                    Else
                        MsgBox("La fecha Requerida no es valida, verificar", vbExclamation)
                        txt_FechaRequerida.SelectAll()
                    End If
                End If
            Case Keys.Escape
                txt_FechaRequerida.Text = ""
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



    Private Sub btn_Adjuntar_Click(sender As Object, e As EventArgs) Handles Button1.Click



        If Not Directory.Exists(CarpetaAux) Then
            Directory.CreateDirectory(CarpetaAux)
        End If
        With New EditorArchivos(2, CarpetaAux)
            .Show()
        End With

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
        txt_Titulo.Text = ""
        txt_Concepto.Text = ""

        cbx_Moneda.SelectedIndex = 0
        cbx_Tipo.SelectedIndex = 0

        chk_Efectivo.Checked = False
        chk_Tranferencia.Checked = False
        chk_ChequeTerceros.Checked = False
        chk_Echeq.Checked = False

        limpiarCarpetaDatosAux()


    End Sub

    Private Sub limpiarCarpetaDatosAux()
        If Not Directory.Exists(CarpetaAux) Then Directory.CreateDirectory(CarpetaAux)

        If DirecctorioVacio(CarpetaAux) Then
            MsgBox("Se limpiaron tambien los archivos adjuntos", vbExclamation)
        End If
        If Directory.Exists(CarpetaAux) Then Directory.Delete(CarpetaAux, True)

        Directory.CreateDirectory(CarpetaAux)
    End Sub


    Private Sub btn_MostrarSolicitud_Click(sender As Object, e As EventArgs) Handles btn_MostrarSolicitud.Click

        Dim WFormula As String = "{SolicitudFondos.NroSolicitud} = " & NRO_SOLICITUD & ""

        With New VistaPrevia
            .Reporte = New Reporte_SolicitudFondos
            .Formula = WFormula
            '.Formula = "{SolicitudFondos.NroSolicitud} > " & (NRO_SOLICITUD - 1) & " AND {SolicitudFondos.NroSolicitud} < " & (NRO_SOLICITUD + 1) & ""

            .Mostrar()
        End With
    End Sub


End Class