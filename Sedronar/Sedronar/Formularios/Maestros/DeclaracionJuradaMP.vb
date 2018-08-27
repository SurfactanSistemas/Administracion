Imports System.Data.SqlClient
Imports Sedronar.Clases

Public Class DeclaracionJuradaMP

    Private ZZCufe(11) As String
    Private cn As SqlConnection
    Private cm As SqlCommand
    Private dr As SqlDataReader

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Dim tabla As DataTable = CType(dgvProductos.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.Rows.Clear()
        End If

        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("/", "")) = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtDesde.Text) Then Exit Sub

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Clear()
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("/", "")) = "" Then : Exit Sub : End If
            If txtHasta.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtHasta.Text) Then Exit Sub

            If Val(Helper.ordenaFecha(txtHasta.Text)) > Val(Helper.ordenaFecha(txtDesde.Text)) Then
                MsgBox("Las fechas deben ser iguales o consecutivas.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Clear()
        End If

    End Sub

    Private Sub DeclaracionJuradaMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Clear()
        txtHasta.Clear()
        ckLimpia.Checked = False
        dgvProductos.Rows.Clear()
        txtCodigo.Clear()

        ZZCufe(1) = "9980334210003"
        ZZCufe(2) = "2222"
        ZZCufe(3) = "9980396510004"
        ZZCufe(4) = "9980401950009"
        ZZCufe(5) = "9980396350006"
        ZZCufe(6) = "5555"
        ZZCufe(7) = "9980396360005"
        ZZCufe(8) = "9980307940005"
        ZZCufe(9) = "9999"
        ZZCufe(10) = "9980396370004"
        ZZCufe(11) = "9980396380003"

        _CargarDatos()

        txtDesde.Focus()
    End Sub

    Private Sub _CargarDatos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Articulo WHERE Sedronar = '1' ORDER BY Codigo")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

            dgvProductos.DataSource = tabla

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try

    End Sub

    Private Sub dgvProductos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductos.RowHeaderMouseDoubleClick
        If MsgBox("¿Seguro de querer eliminar este Codigo del Listado?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        Dim row As DataGridViewRow = dgvProductos.CurrentRow

        dgvProductos.Rows.Remove(row)

        txtDesde.Focus()

    End Sub

    Private Sub DeclaracionJuradaMP_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtCodigo.Text.Replace("-", "").Trim = "" Then Exit Sub
        If txtCodigo.Text.Replace(" ", "").Length < 10 Then Exit Sub

        Dim WProducto As DataRow = Helper.QuerySingle("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")

        If Not IsNothing(WProducto) Then

            For Each row As DataGridViewRow In dgvProductos.Rows
                Dim WCodigo = If(row.Cells("Codigo").Value, "")

                If WCodigo.ToString.Trim.ToUpper = txtCodigo.Text.Trim.ToUpper Then
                    txtCodigo.Clear()
                    txtCodigo.Focus()
                    Exit Sub
                End If

            Next

            Dim tabla As DataTable = CType(dgvProductos.DataSource, DataTable)

            If Not IsNothing(tabla) Then
                Dim r As DataRow = tabla.NewRow

                With r
                    .Item("Codigo") = If(WProducto.Item("Codigo"), "")
                    .Item("Descripcion") = If(WProducto.Item("Descripcion"), "")
                End With

                tabla.Rows.Add(r)

                tabla.DefaultView.Sort = "Codigo ASC"

            End If

            txtCodigo.Clear()
            txtCodigo.Focus()

        End If

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            btnAgregar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Clear()
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            '
            ' Validamos que las fechas ingresadas sean válidas.
            '
            If Not Helper._ValidarFecha(txtHasta.Text) Then Throw New Exception("La fecha 'Hasta' no es válida.")
            If Not Helper._ValidarFecha(txtDesde.Text) Then Throw New Exception("La fecha 'Desde' no es válida.")

            '
            ' Validamos que las fechas sean iguales o consecutivas.
            '
            If Val(Helper.ordenaFecha(txtHasta.Text)) > Val(Helper.ordenaFecha(txtDesde.Text)) Then
                MsgBox("Las fechas deben ser iguales o consecutivas.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            '
            ' WGuardamos los datos de las materias primas.
            '
            Dim temp As DataTable = CType(dgvProductos.DataSource, DataTable)
            Dim WProductos As New DataTable

            '
            ' Guardamos una copia del listado para procesar luego.
            '
            If Not IsNothing(temp) Then
                WProductos = temp.Copy
            End If

            If IsNothing(WProductos) OrElse WProductos.Rows.Count = 0 Then Exit Sub

            WProductos.Columns.Add("CodSedronar")

            Dim WDesdeFecha As String = Helper.ordenaFecha(txtDesde.Text)
            Dim WHastaFecha As String = Helper.ordenaFecha(txtHasta.Text)

            For Each WProducto As datarow In WProductos.Rows
                Dim WCodigo As String = OrDefault(WProducto.Item("Codigo"), "")

                If WCodigo.Trim = "" Then Continue For

                Dim Mp = QuerySingle("SELECT CodSedronar FROM Articulo WHERE Codigo = '" & WCodigo & "'")

                If Not IsNothing(Mp) Then
                    WProducto.Item("CodSedronar") = OrDefault(Mp.Item("CodSedronar"), "")
                Else
                    Throw New Exception("Codigo de Materia Prima Inexistente.")
                End If

                Dim WCodSedronar = WProducto.Item("CodSedronar")

                '
                'Recuperamos la información de los grupos de información.
                '
                Dim WInformes As DataTable = _TraerInformacionInformes(WDesdeFecha, WHastaFecha, WCodigo)

                Dim WHojasProduccion As DataTable = _TraerInformacionHojasProduccion(WDesdeFecha, WHastaFecha, WCodigo)

                Dim WMovimientosVarios As DataTable = _TraerInformacionMovimientosVarios(WDesdeFecha, WHastaFecha, WCodigo)

                Dim WGuiasInternas As DataTable = _TraerInformacionGuiasInternas(WDesdeFecha, WHastaFecha, WCodigo)

                Dim WMovimientosLaboratorio As DataTable = _TraerInformacionMovimientosLaboratorio(WDesdeFecha, WHastaFecha, WCodigo)

                Dim WFecha = ""
                Dim WEvento = ""
                Dim WGtin = ""
                Dim WCantidad As Double = 0
                Dim WAnalitica = ""
                Dim WParcial = ""
                Dim WTipo = ""
                Dim WNumero = ""
                Dim WCufeOrigen = ""
                Dim WCufeDestino = ""
                Dim WCufeTransportista = ""
                Dim WPermiso = ""
                Dim WPermisoII = ""
                Dim WDominio = ""
                Dim WTipoDoc = ""
                Dim WNroDoc = ""
                Dim WTipoTransporte = ""
                Dim WPlaza = ""
                Dim WDJai = ""
                Dim WPaso = ""
                Dim WNroCertificado = ""
                Dim WClave = ""
                Dim WSuma As Double = 0

                Dim cn As SqlConnection = New SqlConnection()
                Dim cm As SqlCommand = New SqlCommand("")
                Dim dr As SqlDataReader
                Dim trans As SqlTransaction = Nothing

                Try

                    cn.ConnectionString = Helper._ConectarA
                    cn.Open()
                    trans = cn.BeginTransaction
                    cm.Connection = cn
                    cm.Transaction = trans

                    '
                    ' Grabamos los informes.
                    '
                    For Each WInforme As DataRow In WInformes.Rows
                        With WInforme

                            WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                            Dim WFechaOrd = Helper.ordenaFecha(WFecha)
                            WEvento = OrDefault(.Item("Evento"), "")
                            WCantidad = Val(Helper.formatonumerico(OrDefault(.Item("Laudo"), 0)))
                            WCodigo = OrDefault(.Item("Remito"), "")
                            Dim WCufeOk = OrDefault(.Item("CufeOk"), "")
                            WCufeDestino = WCufeOk
                            WCufeOrigen = ZZCufe(Val(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo)))
                            WPlaza = OrDefault(.Item("NroDespacho"), "")
                            WClave = "M" & WCodSedronar & "E" & WEvento & WFechaOrd
                            WSuma = WCantidad

                            Dim WTipoOrden = OrDefault(.Item("TipoOrden"), "")

                            WDJai = "Falta DJAI"

                            If Val(WTipoOrden) <> 1 Then WDJai = ""

                            If WCantidad = 0 Then Continue For

                            Dim ZSql = ""

                            ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                     " VALUES " &
                                                     "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                     WFecha, WEvento, WCodSedronar, WCantidad, "2", WCodigo, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, WSuma)

                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                            If Val(WTipoOrden) = 4 Then

                                WEvento = "66"

                                WCufeOrigen = ZZCufe(Val(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo)))
                                WCufeDestino = ""
                                WNumero = ""
                                WPlaza = ""
                                WPaso = ""
                                WDJai = ""
                                WSuma = WSuma * -1

                                Dim WMovi = OrDefault(.Item("Informe"), "")
                                WClave = "M" & WCodSedronar & WMovi & WFechaOrd

                                ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                     " VALUES " &
                                                     "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                     WFecha, WEvento, WCodSedronar, WCantidad, "", WCodigo, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, WSuma)

                                cm.CommandText = ZSql
                                cm.ExecuteNonQuery()

                            End If

                        End With

                    Next

                    '
                    ' Grabamos las Hojas de Producción.
                    '
                    WCufeDestino = ""
                    WPlaza = ""
                    WDJai = ""
                    WPaso = ""
                    WGtin = WCodSedronar
                    WCufeOrigen = ZZCufe(Val(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo)))

                    For Each row As datarow In WHojasProduccion.Rows
                        With row
                            WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                            Dim WFechaOrd = Helper.ordenaFecha(WFecha)
                            WEvento = OrDefault(.Item("Evento"), "")
                            WCantidad = OrDefault(.Item("Cantidad"), 0)
                            WNumero = OrDefault(.Item("Hoja"), "")
                            WSuma = WCantidad * -1
                            WClave = "M" & WCodSedronar & "S" & WEvento & WFechaOrd

                            Dim ZSql = ""

                            ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                     " VALUES " &
                                                     "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                     WFecha, WEvento, WCodSedronar, WCantidad, "2", WCodigo, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, WSuma)

                            cm.CommandText = ZSql
                            cm.ExecuteNonQuery()

                        End With
                    Next

                    '
                    ' Grabamos los Movimientos Varios.
                    '
                    For Each row As datarow In WMovimientosVarios.Rows
                        With row

                        End With
                    Next

                Catch ex As Exception
                    If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()
                    Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
                Finally

                    dr = Nothing
                    cn.Close()
                    cn = Nothing
                    cm = Nothing

                End Try

            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function _TraerInformacionMovimientosLaboratorio(ByVal wDesdeFecha As String, ByVal wHastaFecha As String, ByVal wCodigo As String) As DataTable
        Dim tabla As DataTable = QueryAll("SELECT Fecha, Cantidad, Codigo, Movi FROM MovLab WHERE UPPER(Tipo) = 'M' AND Articulo = '" & wCodigo & "' AND (Right(Fecha, 4) + SUBSTRING(Fecha, 4, 2) + left(Fecha, 2)) BETWEEN '" & wDesdeFecha & "' AND '" & wHastaFecha & "'")

        '
        ' Procesamos los datos.
        '

        tabla.Columns.Add("Evento")

        If tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows

                With row

                    .Item("Evento") = ""

                    Dim WConver As Double = OrDefault(.Item("Cantidad"), 0)

                    Select Case UCase(wCodigo)
                        Case "DC-000-100"
                            WConver /= 1.17
                        Case "DS-001-100"
                            WConver /= 1.84
                        Case "DA-005-100"
                            WConver /= 1.053
                    End Select

                    .Item("Cantidad") = WConver

                    Dim WMovi As String = OrDefault(.Item("Producto"), "")

                    If UCase(WMovi) = "S" Then
                        .Item("Evento") = "66"
                    Else
                        .Item("Evento") = "58"
                    End If

                End With

            Next
        End If

        Return tabla
    End Function

    Private Function _TraerInformacionGuiasInternas(ByVal wDesdeFecha As String, ByVal wHastaFecha As String, ByVal wCodigo As String) As DataTable
        Dim tabla As DataTable = QueryAll("SELECT Fecha, Canti = CASE ISNULL(CantidadAnt, 0) <> 0 THEN CantidadAnt ELSE Cantidad END, Codigo, Movi, Destino, TipoMov FROM Guia WHERE UPPER(Tipo) = 'M' AND Codigo < 900000 AND Articulo = '" & wCodigo & "' AND (Right(Fecha, 4) + SUBSTRING(Fecha, 4, 2) + left(Fecha, 2)) BETWEEN '" & wDesdeFecha & "' AND '" & wHastaFecha & "'")

        '
        ' Procesamos los datos.
        '
        tabla.Columns.Add("Evento")
        tabla.Columns.Add("CufeOrigen")
        tabla.Columns.Add("CufeDestino")

        If tabla.Rows.Count > 0 Then
            For Each row As datarow In tabla.Rows
                With row

                    .Item("Evento") = ""
                    .Item("CufeDestino") = ""
                    .Item("CufeOrigen") = ""

                    Dim WMovi As String = OrDefault(.Item("Movi"), "")
                    Dim WEvento As String = ""
                    Dim WLugarCufe As String = ""
                    Dim WCufeOrigen As String = ""
                    Dim WCufeDestino As String = ""

                    If Trim(WMovi) = "" Then WMovi = "S"

                    If WMovi = "S" Then
                        WEvento = "48"
                        WLugarCufe = .Item("Destino")
                        WCufeOrigen = ZZCufe(Val(WLugarCufe))
                        WCufeDestino = ZZCufe(Val(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo)))
                    Else
                        WEvento = "47"
                        WLugarCufe = .Item("TipoMov")
                        WCufeDestino = ZZCufe(Val(WLugarCufe))
                        WCufeOrigen = ZZCufe(Val(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo)))
                    End If

                    .Item("Evento") = WEvento
                    .Item("CufeDestino") = WCufeDestino
                    .Item("CufeOrigen") = WCufeOrigen

                End With
            Next
        End If

        Return tabla
    End Function

    Private Function _TraerInformacionMovimientosVarios(ByVal wDesdeFecha As String, ByVal wHastaFecha As String, ByVal wCodigo As String) As DataTable
        Dim tabla As DataTable = QueryAll("SELECT Fecha, Cantidad, Codigo, Movi FROM Movvar WHERE UPPER(Tipo) = 'M' AND Articulo = '" & wCodigo & "' AND ISNULL(Cantidad, 0) > 0 AND (Right(Fecha, 4) + SUBSTRING(Fecha, 4, 2) + left(Fecha, 2)) BETWEEN '" & wDesdeFecha & "' AND '" & wHastaFecha & "'")

        '
        ' Procesamos los datos.
        '

        tabla.Columns.Add("Evento")

        If tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows

                With row

                    .Item("Evento") = ""

                    Dim WConver As Double = OrDefault(.Item("Cantidad"), 0)

                    Select Case UCase(wCodigo)
                        Case "DC-000-100"
                            WConver /= 1.17
                        Case "DS-001-100"
                            WConver /= 1.84
                        Case "DA-005-100"
                            WConver /= 1.053
                    End Select

                    .Item("Cantidad") = WConver

                    Dim WMovi As String = OrDefault(.Item("Producto"), "")

                    If UCase(WMovi) = "S" Then
                        .Item("Evento") = "66"
                    Else
                        .Item("Evento") = "58"
                    End If

                End With

            Next
        End If

        Return tabla
    End Function

    Private Function _TraerInformacionHojasProduccion(ByVal wDesdeFecha As String, ByVal wHastaFecha As String, ByVal wCodigo As String) As DataTable
        '
        ' Buscamos los datos de las hojas que contengan la MP como componente entre las fechas indicadas.
        '
        Dim tabla As DataTable = QueryAll("SELECT Fecha, Cantidad, Hoja, Producto FROM Hojas WHERE UPPER(Tipo) = 'M' AND Articulo = '" & wCodigo & "' AND (Right(Fecha, 4) + SUBSTRING(Fecha, 4, 2) + left(Fecha, 2)) BETWEEN '" & wDesdeFecha & "' AND '" & wHastaFecha & "'")

        '
        ' Procesamos los datos.
        '

        tabla.Columns.Add("Evento")

        If tabla.Rows.Count > 0 Then

            For Each row As DataRow In tabla.Rows

                With row

                    .Item("Evento") = ""

                    Dim WConver As Double = OrDefault(.Item("Cantidad"), 0)

                    Select Case UCase(wCodigo)
                        Case "DC-000-100"
                            WConver /= 1.17
                        Case "DS-001-100"
                            WConver /= 1.84
                        Case "DA-005-100"
                            WConver /= 1.053
                    End Select

                    .Item("Cantidad") = WConver

                    Dim WCodTer As String = .Item("Producto").ToString.Substring(3, 5)

                    If WCodTer >= "40000" And WCodTer <= 41999 Then
                        .Item("Evento") = "69"
                    Else
                        .Item("Evento") = "54"
                    End If

                End With

            Next

        End If

        Return tabla
    End Function

    Private Function _TraerInformacionInformes(ByVal WDesdeFecha As Object, ByVal WHastaFecha As Object, ByVal wCodigo As String) As DataTable
        '
        ' Buscamos los informes en la empresa en la que está realizando el proceso.
        '
        Dim tabla As DataTable = QueryAll("SELECT Tipo = '1', i.Fecha, i.Cantidad, i.Remito, i.Informe, i.Orden, ISNULL(o.Proveedor, '') Proveedor FROM Informe i LEFT OUTER JOIN Orden o ON o.Orden = i.Orden WHERE Articulo = '" & wCodigo & "' and FechaOrd BETWEEN '" & WDesdeFecha & "' AND '" & WHastaFecha & "'")

        tabla.Columns.Add("CufeOk")
        tabla.Columns.Add("CufeI")
        tabla.Columns.Add("CufeII")
        tabla.Columns.Add("CufeIII")
        tabla.Columns.Add("Evento")
        tabla.Columns.Add("NroDespacho")
        tabla.Columns.Add("TipoOrden")
        tabla.Columns.Add("Laudo", GetType(System.Double))

        '
        ' Buscamos los datos CUFE en Planta I o Pellital III según se esté o no procesando en Surfactan.
        '
        For Each row As DataRow In tabla.Rows

            With row

                .Item("CufeOk") = ""
                .Item("CufeI") = ""
                .Item("CufeII") = ""
                .Item("CufeIII") = ""

                Dim WProveedor As DataRow = QuerySingle("SELECT ISNULL(CufeI, '') CufeI, ISNULL(CufeII, '') CufeII, ISNULL(CufeIII, '') CufeIII FROM Proveedor WHERE Proveedor = '" & row.Item("Proveedor") & "'", IIf(Helper._EsPellital, "Pellital_III", "SurfactanSa"))

                If Not IsNothing(WProveedor) Then
                    .Item("CufeI") = WProveedor.Item("CufeI")
                    .Item("CufeII") = WProveedor.Item("CufeII")
                    .Item("CufeIII") = WProveedor.Item("CufeIII")
                End If

                For Each v As String In {"CufeI", "CufeII", "CufeIII"}
                    .Item(v) = .Item(v).ToString.Trim
                Next

                '
                ' Determinamos el Cufe.
                '
                If .Item("CufeI") <> "" And .Item("CufeII") = "" And .Item("CufeIII") = "" Then
                    .Item("CufeOk") = .Item("CufeI")
                Else
                    .Item("CufeOk") = .Item("Proveedor")
                End If

                '
                ' Buscamos la informacion de la Orden de Compra, para Calcular el Laudo.
                '
                Dim WOrden As DataRow = QuerySingle("SELECT ISNULL(Tipo, 0) Tipo FROM Orden WHERE Orden = '" & .Item("Orden") & "'")
                .Item("Laudo") = 0
                .Item("NroDespacho") = ""
                .Item("Evento") = ""
                .Item("TipoOrden") = ""

                If Not IsNothing(WOrden) Then

                    .Item("TipoOrden") = OrDefault(WOrden.Item("Tipo"), 0)

                    Select Case .Item("TipoOrden")
                        Case 4
                            .Item("Laudo") = .Item("Cantidad")
                        Case Else
                            Dim WLaudos As DataTable = QueryAll("SELECT ISNULL(NroDespacho, '') NroDespacho, ISNULL(LiberadaAnt, 0) LiberadaAnt, ISNULL(Liberada, 0) Liberada FROM Laudo WHERE Articulo = '" & .Item("Articulo") & "' AND Informe = '" & .Item("Informe") & "'")

                            .Item("NroDespacho") = ""
                            Dim WLiberada As Double = 0
                            Dim WDespacho As String = ""
                            Dim WLaudo As Double = 0

                            If WLaudos.Rows.Count > 0 Then
                                For Each L As DataRow In WLaudos.Rows
                                    WLiberada = 0

                                    WDespacho = L.Item("NroDespacho")
                                    WLiberada = L.Item("LiberadaAnt")

                                    If Val(.Item("Liberada")) = 0 Then
                                        WLiberada = L.Item("Liberada")
                                    End If

                                    WLaudo += WLiberada

                                Next
                            End If

                            .Item("NroDespacho") = WDespacho
                            .Item("Laudo") = WLaudo

                    End Select

                    Dim WConver As Double = .Item("Laudo")

                    Select Case .Item("Articulo")
                        Case "DC-000-100"
                            WConver /= 1.17
                        Case "DS-001-100"
                            WConver /= 1.84
                        Case "DA-005-100"
                            WConver /= 1.053
                        Case "ZL-103-150"
                            WConver *= 0.45
                    End Select

                    .Item("Laudo") = WConver

                    If .Item("Laudo") > 0 Then

                        Select Case .Item("TipoOrden")
                            Case 1
                                .Item("Evento") = "45"
                            Case 4
                                .Item("Evento") = "66"
                            Case Else
                                If .Item("Articulo").ToString.StartsWith("XX") Or .Item("Proveedor") = "10071011210" Then
                                    .Item("Evento") = "68"
                                Else
                                    .Item("Evento") = "43"
                                End If
                        End Select

                    End If

                End If

            End With

        Next

        Return tabla
    End Function
End Class