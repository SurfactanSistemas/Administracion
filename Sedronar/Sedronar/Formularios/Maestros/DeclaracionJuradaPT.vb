Imports System.Data.SqlClient
Imports Sedronar.Clases

Public Class DeclaracionJuradaPT

    Private ZZCufe(11) As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Dim tabla As DataTable = CType(dgvProductos.DataSource, DataTable)

        If Not IsNothing(tabla) Then
            tabla.Rows.Clear()
        End If

        _CargarDatos()

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

            If Val(Helper.ordenaFecha(txtHasta.Text)) < Val(Helper.ordenaFecha(txtDesde.Text)) Then
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
        ZZCufe(2) = ""
        ZZCufe(3) = "9980396510004"
        ZZCufe(4) = "9980401950009"
        ZZCufe(5) = "9980396350006"
        ZZCufe(6) = ""
        ZZCufe(7) = "9980396360005"
        ZZCufe(8) = "9980307940005"
        ZZCufe(9) = ""
        ZZCufe(10) = "9980396370004"
        ZZCufe(11) = "9980396380003"

        _CargarDatos()

        txtDesde.Focus()
    End Sub

    Private Sub _CargarDatos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Terminado WHERE Sedronar = '1' ORDER BY Codigo")
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

        Dim WProducto As DataRow = Helper.QuerySingle("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")

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
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing

        Try
            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction = trans

            '
            ' Validamos que las fechas ingresadas sean válidas.
            '
            If Not Helper._ValidarFecha(txtHasta.Text) Then Throw New Exception("La fecha 'Hasta' no es válida.")
            If Not Helper._ValidarFecha(txtDesde.Text) Then Throw New Exception("La fecha 'Desde' no es válida.")

            '
            ' Validamos que las fechas sean iguales o consecutivas.
            '
            If Val(Helper.ordenaFecha(txtHasta.Text)) < Val(Helper.ordenaFecha(txtDesde.Text)) Then
                MsgBox("Las fechas deben ser iguales o consecutivas.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim WDesdeFecha As String = txtDesde.Text
            Dim WDesdeFechaOrd As String = Helper.ordenaFecha(WDesdeFecha)
            Dim WHastaFecha As String = txtHasta.Text
            Dim WHastaFechaOrd As String = Helper.ordenaFecha(WHastaFecha)

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

            If ckLimpia.Checked Then
                cm.CommandText = "DELETE FROM SedronarProceso"
                cm.ExecuteNonQuery()
            End If

            For Each WProducto As DataRow In WProductos.Rows

                Dim WCodigoProd As String = OrDefault(WProducto.Item("Codigo"), "")

                If WCodigoProd.Trim = "" Then Continue For

                '
                ' Busco los datos del Producto Terminado.
                '
                Dim WProd As DataRow = QuerySingle("SELECT CodSedronar, Descripcion, Linea FROM Terminado WHERE Codigo = '" & WCodigoProd & "'", "SurfactanSa")

                If IsNothing(WProd) Then Continue For

                Dim WCodSedronar As String = OrDefault(WProd.Item("CodSedronar"), WCodigoProd)
                Dim WDescProducto As String = OrDefault(WProd.Item("Descripcion"), "")
                Dim WLineaProd As Integer = OrDefault(WProd.Item("Linea"), 0)

                WCodSedronar = WCodSedronar.Trim

                '
                ' Obtengo los datos necesarios para Procesar.
                '
                Dim WEstadisticas As DataTable = _TraerInformacionEstadisticas(WCodigoProd, WDesdeFechaOrd, WHastaFechaOrd)

                Dim WHojasProduccionComponente As DataTable = _TraerInformacionHojasProduccionComponente(WCodigoProd, WDesdeFechaOrd, WHastaFechaOrd)

                Dim WHojasProduccionTerminado As DataTable = _TraerInformacionHojasProduccionTerminado(WCodigoProd, WDesdeFechaOrd, WHastaFechaOrd)

                Dim WMovimientosVarios As DataTable = _TraerInformacionMovimientosVarios(WCodigoProd, WDesdeFechaOrd, WHastaFechaOrd)

                Dim WGuiasTrasladoInterno As DataTable = _TraerInformacionGuiasTrasladoInterno(WCodigoProd, WDesdeFechaOrd, WHastaFechaOrd)

                Dim WMovimientosLaboratorio As DataTable = _TraerInformacionMovimientosLaboratorio(WCodigoProd, WDesdeFechaOrd, WHastaFechaOrd)

                With ProgressBar1
                    .Value = 0
                    .Maximum = {WEstadisticas, WHojasProduccionComponente, WHojasProduccionTerminado, WMovimientosLaboratorio, WMovimientosVarios, WGuiasTrasladoInterno}.Sum(Function(dt) dt.Rows.Count)
                    .Step = 1
                End With

                '
                ' Proceso las estadisticas.
                '
                For Each row As DataRow In WEstadisticas.Rows
                    With row
                        Dim WEvento = ""
                        Dim WLinea = OrDefault(.Item("Linea"), 0)
                        Dim WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                        Dim WCantidad = Helper.formatonumerico(OrDefault(.Item("Cantidad"), 0), 3)
                        Dim WNumero = OrDefault(.Item("Numero"), "")
                        Dim WCufeOrigen = ""
                        Dim WCufeDestino = ""
                        Dim WCufe = OrDefault(.Item("Cufe"), "")
                        Dim WCufeII = OrDefault(.Item("CufeII"), "")
                        Dim WCufeIII = OrDefault(.Item("CufeIII"), "")
                        Dim WPlaza = "", WDJai = "", WPaso = "", WClave = ""
                        Dim WSuma As Double = Val(WCantidad) * -1


                        If WCufe <> "" And WCufeII = "" And WCufeIII = "" Then
                            WCufeDestino = WCufe
                        End If

                        WCufeOrigen = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))

                        Select Case WLinea
                            Case 13, 20, 21
                                WEvento = "69"
                            Case Else
                                WEvento = "44"
                        End Select

                        WClave = "T" & WCodSedronar & "S" & WEvento & Helper.ordenaFecha(WFecha)

                        Dim ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                 " VALUES " &
                                                 "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                 WFecha, WEvento, WCodSedronar, WCantidad, "1", WNumero, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, formatonumerico(WSuma, 3))

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End With

                    ProgressBar1.Increment(1)

                Next


                '
                ' Proceso las Hojas de Produccion donde aparece como Terminado.
                '
                For Each row As DataRow In WHojasProduccionTerminado.Rows
                    With row
                        Dim WEvento = "40"
                        Dim WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                        Dim WCantidad = Helper.formatonumerico(OrDefault(.Item("Cantidad"), 0), 3)
                        Dim WNumero = OrDefault(.Item("Hoja"), "")
                        Dim WCufeOrigen = ""
                        Dim WCufeDestino = ""
                        Dim WPlaza = "", WDJai = "", WPaso = "", WClave = ""
                        Dim WSuma As Double = Val(WCantidad)

                        WCufeOrigen = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))

                        WClave = "T" & WCodSedronar & "E" & WEvento & Helper.ordenaFecha(WFecha)

                        Dim ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                 " VALUES " &
                                                 "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                 WFecha, WEvento, WCodSedronar, WCantidad, "3", WNumero, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, formatonumerico(WSuma, 3))

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End With

                    ProgressBar1.Increment(1)
                Next

                '
                ' Proceso las Hojas de Produccion donde aparece como Componente.
                '
                For Each row As datarow In WHojasProduccionComponente.Rows
                    With row
                        Dim WEvento = "54"
                        Dim WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                        Dim WCantidad = Helper.formatonumerico(OrDefault(.Item("Cantidad"), 0), 3)
                        Dim WNumero = OrDefault(.Item("Hoja"), "")
                        Dim WCufeOrigen = ""
                        Dim WCufeDestino = ""
                        Dim WPlaza = "", WDJai = "", WPaso = "", WClave = ""
                        Dim WSuma As Double = Val(WCantidad) * -1

                        WCufeOrigen = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))
                        
                        WClave = "T" & WCodSedronar & "S" & WEvento & Helper.ordenaFecha(WFecha)

                        Dim ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                 " VALUES " &
                                                 "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                 WFecha, WEvento, WCodSedronar, WCantidad, "3", WNumero, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, formatonumerico(WSuma, 3))

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End With

                    ProgressBar1.Increment(1)
                Next

                '
                ' Procesamos los Movimientos Varios.
                '
                For Each row As datarow In WMovimientosVarios.Rows
                    With row
                        Dim WEvento = ""
                        Dim WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                        Dim WCantidad = Helper.formatonumerico(OrDefault(.Item("Cantidad"), 0), 3)
                        Dim WNumero = "" 'OrDefault(.Item("Codigo"), "")
                        Dim WCufeOrigen = ""
                        Dim WCufeDestino = ""
                        Dim WPlaza = "", WDJai = "", WPaso = "", WClave = ""
                        Dim WSuma As Double = Val(WCantidad)

                        Dim WMovi = OrDefault(.Item("Movi"), "S")

                        If WMovi = "S" Then
                            WEvento = "66"
                            WSuma *= -1
                        Else
                            WEvento = "58"
                        End If

                        WCufeOrigen = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))

                        WClave = "T" & WCodSedronar & WMovi & WEvento & Helper.ordenaFecha(WFecha)

                        Dim ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                 " VALUES " &
                                                 "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                 WFecha, WEvento, WCodSedronar, WCantidad, "", WNumero, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, formatonumerico(WSuma, 3))

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End With

                    ProgressBar1.Increment(1)
                Next


                '
                ' Procesamos los Movimientos Laboratorio.
                '
                For Each row As DataRow In WMovimientosLaboratorio.Rows
                    With row
                        Dim WEvento = ""
                        Dim WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                        Dim WCantidad = Helper.formatonumerico(OrDefault(.Item("Cantidad"), 0), 3)
                        Dim WNumero = "" 'OrDefault(.Item("Codigo"), "")
                        Dim WCufeOrigen = ""
                        Dim WCufeDestino = ""
                        Dim WPlaza = "", WDJai = "", WPaso = "", WClave = ""
                        Dim WSuma As Double = Val(WCantidad)

                        Dim WMovi = OrDefault(.Item("Movi"), "S")

                        If WMovi = "S" Then
                            WEvento = "66"
                            WSuma *= -1
                        Else
                            WEvento = "58"
                        End If

                        WCufeOrigen = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))

                        WClave = "T" & WCodSedronar & WMovi & WEvento & Helper.ordenaFecha(WFecha)

                        Dim ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                 " VALUES " &
                                                 "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                 WFecha, WEvento, WCodSedronar, WCantidad, "", WNumero, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, formatonumerico(WSuma, 3))

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End With

                    ProgressBar1.Increment(1)
                Next

                '
                ' Procesamos las Guias de Traslado.
                '
                For Each row As DataRow In WGuiasTrasladoInterno.Rows
                    With row
                        Dim WEvento = ""
                        Dim WFecha = OrDefault(.Item("Fecha"), "00/00/0000")
                        Dim WCantidad = Helper.formatonumerico(OrDefault(.Item("Cantidad"), 0), 3)
                        Dim WNumero = OrDefault(.Item("Codigo"), "")
                        Dim WCufeOrigen = ""
                        Dim WCufeDestino = ""
                        Dim WPlaza = "", WDJai = "", WPaso = "", WClave = ""
                        Dim WSuma As Double = Val(WCantidad)
                        Dim WDestino As Integer = OrDefault(.Item("Destino"), "")
                        Dim WMovi = OrDefault(.Item("Movi"), "S")

                        If WMovi = "S" Then
                            WEvento = "48"
                            WCufeOrigen = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))
                            WCufeDestino = ZZCufe(Val(WDestino))
                            WSuma *= -1
                        Else
                            WEvento = "47"
                            WDestino = OrDefault(.Item("TipoMov"), "")
                            WCufeOrigen = ZZCufe(Val(WDestino))
                            WCufeDestino = ZZCufe(Conexion.ObtenerIdEmpresaPorNombre(Conexion.EmpresaDeTrabajo))

                        End If
                        
                        WClave = "T" & WCodSedronar & WMovi & WEvento & Helper.ordenaFecha(WFecha)

                        Dim ZSql = String.Format("INSERT INTO SedronarProceso (Fecha, Evento, Gtin, Cantidad, Tipo, Numero, CufeOrigen, CufeDestino, CufeTransportista, Plaza, Djai, Paso, Clave, Suma) " &
                                                 " VALUES " &
                                                 "('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})",
                                                 WFecha, WEvento, WCodSedronar, WCantidad, "3", WNumero, WCufeOrigen, WCufeDestino, "", WPlaza, WDJai, WPaso, WClave, formatonumerico(WSuma, 3))

                        cm.CommandText = ZSql
                        cm.ExecuteNonQuery()

                    End With

                    ProgressBar1.Increment(1)
                Next
            Next

            trans.Commit()

            MsgBox("Proceso Finalizado.", MsgBoxStyle.Information)

        Catch ex As Exception
            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function _TraerInformacionMovimientosLaboratorio(ByVal item As Object, ByVal wDesdeFechaOrd As String, ByVal wHastaFechaOrd As String) As DataTable
        Dim WDatos As DataTable = QueryAll("SELECT Fecha, Cantidad, Codigo, Movi FROM MovLab WHERE UPPER(Tipo) = 'T' AND Terminado = '" & item & "' AND FechaOrd BETWEEN '" & wDesdeFechaOrd & "' AND '" & wHastaFechaOrd & "'")

        Return WDatos
    End Function

    Private Function _TraerInformacionGuiasTrasladoInterno(ByVal item As Object, ByVal wDesdeFechaOrd As String, ByVal wHastaFechaOrd As String) As DataTable
        Dim WDatos As DataTable = QueryAll("SELECT Fecha, Codigo, Movi, Destino, TipoMov, Cantidad = CASE WHEN ISNULL(CantidadAnt, 0) <> 0 THEN CantidadAnt ELSE Cantidad END FROM Guia WHERE Terminado = '" & item & "' AND UPPER(Tipo) = 'T' AND FechaOrd BETWEEN '" & wDesdeFechaOrd & "' AND '" & wHastaFechaOrd & "'")

        Return WDatos
    End Function

    Private Function _TraerInformacionMovimientosVarios(ByVal item As Object, ByVal wDesdeFechaOrd As String, ByVal wHastaFechaOrd As String) As DataTable
        Dim WDatos As DataTable = QueryAll("SELECT Fecha, Cantidad, Codigo, Movi FROM MovVar WHERE Terminado = '" & item & "' AND UPPER(Tipo) = 'T' AND FechaOrd BETWEEN '" & wDesdeFechaOrd & "' AND '" & wHastaFechaOrd & "'")

        Return WDatos
    End Function

    Private Function _TraerInformacionHojasProduccionTerminado(ByVal item As Object, ByVal wDesdeFechaOrd As String, ByVal wHastaFechaOrd As String) As DataTable
        Dim WDatos As DataTable = QueryAll("SELECT Hoja, Fecha, Cantidad = CASE WHEN ISNULL(RealAnt, 0) <> 0 THEN RealAnt ELSE Real END FROM Hoja WHERE FechaIngOrd BETWEEN '" & wDesdeFechaOrd & "' AND '" & wHastaFechaOrd & "' AND Producto = '" & item & "' AND Renglon = 1", Conexion.EmpresaDeTrabajo)

        Return WDatos
    End Function

    Private Function _TraerInformacionHojasProduccionComponente(ByVal item As Object, ByVal wDesdeFechaOrd As String, ByVal wHastaFechaOrd As String) As DataTable
        Dim WDatos As DataTable = QueryAll("SELECT Fecha, Cantidad, Hoja FROM Hoja WHERE FechaOrd BETWEEN '" & wDesdeFechaOrd & "' AND '" & wHastaFechaOrd & "' AND Terminado = '" & item & "' AND UPPER(Tipo) = 'T'", Conexion.EmpresaDeTrabajo)

        Return WDatos
    End Function

    Private Function _TraerInformacionEstadisticas(ByVal item As Object, ByVal wDesdeFechaOrd As String, ByVal wHastaFechaOrd As String) As DataTable
        Dim WDatos As DataTable = QueryAll("SELECT e.Fecha, e.Cantidad, ISNULL(e.Numero, 0) Numero, ISNULL(e.Cliente, '') Cliente, ISNULL(c.Cufe, '') Cufe, ISNULL(c.CufeII, '') CufeII, CufeIII = '' FROM Estadistica e LEFT OUTER JOIN Cliente c ON c.Cliente = e.Cliente WHERE UPPER(ISNULL(e.Marca, '')) <> 'X' AND e.OrdFecha BETWEEN '" & wDesdeFechaOrd & "' AND '" & wHastaFechaOrd & "' AND e.Articulo = '" & item & "' ORDER BY e.OrdFecha", Conexion.EmpresaDeTrabajo)

        For Each row As datarow In WDatos.Rows
            With row
                If .Item("Numero") < 200000 Then .Item("Numero") -= 1000000
            End With
        Next

        Return WDatos
    End Function


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        txtDesde.Text = "01/01/2017"
        txtHasta.Text = "30/08/2018"
        ckLimpia.Checked = True

        btnAceptar.PerformClick()
        btnLimpiar.PerformClick()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim cn2 As New OleDb.OleDbConnection
        Dim cm2 As New OleDb.OleDbCommand
        Dim dr2 As OleDb.OleDbDataReader
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WTablaAccess As New DataTable
        Dim WTablaSql As New DataTable
        Try

            cn2.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\soporte2\Documents\VM\VB\Sedronar.mdb;"
            cn2.Open()
            cm2.Connection = cn2
            cm2.CommandText = "SELECT * FROM SedronarProcesoII ORDER BY Clave, Numero, Cantidad"

            dr2 = cm2.ExecuteReader

            If dr2.HasRows Then

                WTablaAccess.Load(dr2)

            End If

            cn.Close()

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()

            cm.Connection = cn
            cm.CommandText = "SELECT * FROM SedronarProceso ORDER BY Clave, Numero, Cantidad"

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                WTablaSql.Load(dr)

            End If

            If WTablaAccess.Rows.Count <> WTablaSql.Rows.Count Then
                Throw New Exception("Las Tablas no tienen la misma cantidad de registros.")
            End If

            For i As Integer = 0 To WTablaAccess.Rows.Count - 1
                For Each col As DataColumn In WTablaSql.Columns
                    Dim valor1 = OrDefault(WTablaSql.Rows(i).Item(col.ColumnName), "").ToString
                    Dim valor2 = WTablaAccess.Rows(i).Item(col.ColumnName)

                    If TypeOf valor2 Is Date Then
                        valor2 = CDate(valor2).ToString("dd/MM/yyyy")

                    End If

                    If valor1.ToString.Trim <> valor2.ToString.Trim Then
                        Throw New Exception("Error")
                    End If
                Next
            Next

            MsgBox("Sin errores")

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub
End Class