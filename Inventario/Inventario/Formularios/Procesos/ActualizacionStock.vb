Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class ActualizacionStock : Implements IClaveAutorizacion

    Dim cn As SqlConnection = New SqlConnection()
    Dim cm As SqlCommand = New SqlCommand("")
    Dim dr As SqlDataReader
    Dim trans As SqlTransaction = Nothing

    Dim WLaudos As New DataTable
    Dim WHojas As New DataTable
    Dim WGuias As New DataTable
    Dim WMovVarios As New DataTable
    Dim WMovLaboratorio As New DataTable
    Dim WEstadisticas As New DataTable
    Dim WDevoluciones As New DataTable

    Private WAutorizado As Boolean = False

    Private WFechaCierre As String = ""
    Private WOrdFechaCierre As String = ""

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not WAutorizado Then

            Using frm As New IngresoClave
                If frm.ShowDialog(Me) = DialogResult.Cancel Then
                    Exit Sub
                End If
            End Using

        End If

        If rbPorRango.Checked Then
            If rbMp.Checked And (txtDesde.Text.Replace(" ", "").Length < 10 Or txtHasta.Text.Replace(" ", "").Length < 10) Then
                MsgBox("El rango indicado no es válido.", MsgBoxStyle.Exclamation, "Actualización de Stock")
                Exit Sub
            End If
            If rbPt.Checked And (txtDesde.Text.Replace(" ", "").Length < 12 Or txtHasta.Text.Replace(" ", "").Length < 12) Then
                MsgBox("El rango indicado no es válido.", MsgBoxStyle.Exclamation, "Actualización de Stock")
                Exit Sub
            End If

            If txtHasta.Text < txtDesde.Text Then
                MsgBox("El rango indicado no es válido.", MsgBoxStyle.Exclamation, "Actualización de Stock")
                Exit Sub
            End If

            txtDesde.Text = txtDesde.Text.ToUpper
            txtHasta.Text = txtHasta.Text.ToUpper

        End If

        WAutorizado = False
        Refresh()

        If MsgBox("!!! ATENCION !!!   Se actualizara el stock con el recuento informado ¿Desea realizar el proceso?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        ProcesarActualizacionStock()

    End Sub

    Private Sub ProcesarActualizacionStock()

        Try

            If cn.IsOpened Then cn.Close()

            If txtFechaCierre.Text.Replace(" ", "").Length < 10 Then
                Throw New Exception("La Fecha de Cierre Indicado no es una Fecha Válida.")
            End If

            If Not Helper._ValidarFecha(txtFechaCierre.Text) Then
                Throw New Exception("La Fecha de Cierre Indicado no es una Fecha Válida.")
            End If

            WFechaCierre = txtFechaCierre.Text
            WOrdFechaCierre = Helper.ordenaFecha(WFechaCierre)

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            
            '
            ' Reseteamos los Valores de las tablas involucradas.
            '

            With lblEstado
                .Text = "Reseteando Valores..."
                .Refresh()
            End With


            _ResetearValores()

            
            '
            ' Actualizamos Saldos, Marcas y Cantidas con los datos del Inventario.
            '

            With lblEstado
                .Text = "Comenzando a Procesar Datos Inventario..."
                .Refresh()
            End With

            _ActualizarDatos()

            ProgressBar1.Value = 0
            With lblEstado
                .Text = "¡Finalizado con Éxito!"
                .Refresh()
            End With

            '
            ' Confirmamos los cambios.
            '
            trans.Commit()

            'MsgBox("No hay errores")

        Catch ex As Exception

            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            MsgBox(ex.Message)

            cn.Close()
            cm.Dispose()

        End Try

    End Sub

    Private Sub _ActualizarDatos()

        Dim WInventario As DataTable = _BuscarInventario()

        With ProgressBar1
            .Value = 0
            .Maximum = WInventario.Rows.Count + 5
        End With

        For Each row As DataRow In WInventario.Rows

            If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()

            With row

                Dim WTipo As String = .Item("Tipo")
                Dim WArticulo As String = .Item("Articulo")
                Dim WTerminado As String = .Item("Terminado")
                Dim WCantidad As Double = .Item("Cantidad")
                Dim WLote As Integer = .Item("Lote")

                If WTipo.Trim.ToUpper = "M" Then

                    '
                    ' Buscamos si controla o no Lote.
                    '
                    Dim WArt As DataRow = _BuscarArticulo(WArticulo)

                    If Not IsNothing(WArt) AndAlso Val(WArt.Item("Controla")) = 0 Then

                        If Not _PosibleActualizarMP(WArticulo) Then Continue For

                        '
                        ' Buscamos si es un Laudo.
                        '
                        Dim WLaudo As DataRow = _BuscarLaudo(WArticulo, WLote)

                        If Not IsNothing(WLaudo) Then

                            With WLaudo
                                Dim WDate = Date.Now.ToString("dd-MM-yyyy")
                                Dim WSaldo = Helper.formatonumerico(.Item("Saldo") + WCantidad)
                                Dim WLiberada = Helper.formatonumerico(.Item("Liberada") + WCantidad)
                                Dim WClave = .Item("Clave")
                                cm.CommandText = String.Format("UPDATE Laudo SET WDate = '{0}', Saldo = {1}, Liberada = {2}, Marca = '' WHERE Clave = '{3}'", WDate, WSaldo, WLiberada, WClave)
                                cm.ExecuteNonQuery()
                            End With

                        Else

                            '
                            ' Lo buscamos en alguna Guía de Traslado Interno.
                            '
                            Dim WGuia As DataRow = _BuscarGuiaArticulo(WArticulo, WLote)

                            If Not IsNothing(WGuia) Then

                                With WGuia
                                    Dim WClave = .Item("Clave")
                                    Dim WCant = Helper.formatonumerico(.Item("Cantidad") + WCantidad)
                                    Dim WSaldo = Helper.formatonumerico(.Item("Saldo") + WCantidad)

                                    cm.CommandText = String.Format("UPDATE Guia SET Cantidad = {0}, Saldo = {1}, Marca = '' WHERE Clave = '{2}'", WCant, WSaldo, WClave)
                                    cm.ExecuteNonQuery()
                                End With

                            End If

                        End If

                    End If

                Else

                    '
                    ' Busca si controla o no Lote.
                    '
                    Dim WTer As DataRow = _BuscarTerminado(WTerminado)

                    If Not IsNothing(WTer) AndAlso Val(WTer.Item("Controla")) = 0 Then

                        If Not _PosibleActualizarPT(WTerminado) Then Continue For

                        '
                        ' Busco si se trata de una Hoja de Produccion.
                        '
                        Dim WHoja As DataRow = _BuscarHoja(WLote, WTerminado)

                        If Not IsNothing(WHoja) Then

                            With WHoja
                                Dim WSaldo = Helper.formatonumerico(.Item("Saldo") + WCantidad)
                                Dim WReal = Helper.formatonumerico(.Item("Real") + WCantidad)
                                Dim WClave = .Item("Clave")
                                cm.CommandText = String.Format("UPDATE Hoja SET Saldo = {0}, Real = {1}, Marca = '' WHERE Clave = '{2}'", WSaldo, WReal, WClave)
                                cm.ExecuteNonQuery()
                            End With

                        Else

                            '
                            ' Busco entre las Guías de Traslado Interno.
                            '
                            Dim WGuia As DataRow = _BuscarGuiaTerminado(WTerminado, WLote)

                            If Not IsNothing(WGuia) Then

                                With WGuia
                                    Dim WClave = .Item("Clave")
                                    Dim WCant = Helper.formatonumerico(.Item("Cantidad") + WCantidad)
                                    Dim WSaldo = Helper.formatonumerico(.Item("Saldo") + WCantidad)
                                    cm.CommandText = String.Format("UPDATE Guia SET Cantidad = {0}, Saldo = {1}, Marca = '' WHERE Clave = '{2}'", WCant, WSaldo, WClave)
                                    cm.ExecuteNonQuery()
                                End With

                            End If

                        End If

                    End If

                End If

            End With
            ProgressBar1.Increment(1)
        Next

    End Sub

    Private Function _BuscarInventario() As DataTable
        Dim tabla As New DataTable

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()

        If rbPorRango.Checked Then
            cm.CommandText = "SELECT ISNULL(Tipo, '') Tipo, ISNULL(Articulo, '') Articulo, ISNULL(Terminado, '') Terminado, ISNULL(Cantidad, 0) Cantidad, ISNULL(Lote, 0) Lote FROM Inventario WHERE Articulo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' Or Terminado BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' ORDER BY Numero"
        Else
            cm.CommandText = "SELECT ISNULL(Tipo, '') Tipo, ISNULL(Articulo, '') Articulo, ISNULL(Terminado, '') Terminado, ISNULL(Cantidad, 0) Cantidad, ISNULL(Lote, 0) Lote FROM Inventario ORDER BY Numero"
        End If

        dr = cm.ExecuteReader

        If dr.HasRows Then
            tabla.Load(dr)
        End If

        Return tabla

    End Function

    Private Function _BuscarTerminado(ByVal WTerminado As String) As DataRow

        Dim WTer As DataRow = Nothing

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
        cm.CommandText = "SELECT ISNULL(Controla, 0) Controla FROM Terminado WHERE Codigo = '" & WTerminado & "'"
        dr = cm.ExecuteReader

        If dr.HasRows Then
            Dim tabla As New DataTable
            tabla.Load(dr)
            If tabla.Rows.Count > 0 Then WTer = tabla.Rows(0)
        End If

        Return WTer

    End Function

    Private Function _BuscarArticulo(ByVal WArticulo As String) As DataRow

        Dim WArt As DataRow = Nothing

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
        cm.CommandText = "SELECT ISNULL(Controla, 0) Controla FROM Articulo WHERE Codigo = '" & WArticulo & "'"
        dr = cm.ExecuteReader

        If dr.HasRows Then
            Dim tabla As New DataTable
            tabla.Load(dr)
            If tabla.Rows.Count > 0 Then WArt = tabla.Rows(0)
        End If
        Return WArt

    End Function

    Private Function _BuscarHoja(ByVal WLote As Integer, ByVal WTerminado As String) As DataRow

        Dim WHoja As DataRow = Nothing

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
        cm.CommandText = String.Format("SELECT Clave, ISNULL(Real, 0) Real, ISNULL(Saldo, 0) Saldo FROM Hoja WHERE Producto = '{0}' AND Hoja = '{1}' AND Renglon = '1'", WTerminado, WLote)
        dr = cm.ExecuteReader

        If dr.HasRows Then
            Dim tabla As New DataTable
            tabla.Load(dr)
            If tabla.Rows.Count > 0 Then WHoja = tabla.Rows(0)
        End If

        Return WHoja

    End Function

    Private Function _BuscarGuiaTerminado(ByVal WTerminado As String, ByVal WLote As Integer) As DataRow

        Dim WGuia As DataRow = Nothing

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
        cm.CommandText = String.Format("SELECT Clave, ISNULL(Saldo, 0) Saldo, ISNULL(Cantidad, 0) Cantidad FROM Guia WHERE Terminado = '{0}' AND Lote = '{1}' Order by saldo desc, FechaOrd", WTerminado, WLote)
        dr = cm.ExecuteReader

        If dr.HasRows Then
            Dim tabla As New DataTable
            tabla.Load(dr)
            If tabla.Rows.Count > 0 Then WGuia = tabla.Rows(0)
        End If

        Return WGuia

    End Function

    Private Function _BuscarGuiaArticulo(ByVal WArticulo As String, ByVal WLote As Integer) As DataRow

        Dim WGuia As DataRow = Nothing

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
        cm.CommandText = String.Format("SELECT Clave, ISNULL(Saldo, 0) Saldo, ISNULL(Cantidad, 0) Cantidad FROM Guia WHERE Articulo = '{0}' AND Lote = '{1}' Order by saldo desc, FechaOrd", WArticulo, WLote)
        dr = cm.ExecuteReader

        If dr.HasRows Then
            Dim tabla As New DataTable
            tabla.Load(dr)
            If tabla.Rows.Count > 0 Then WGuia = tabla.Rows(0)
        End If

        Return WGuia

    End Function

    Private Function _BuscarLaudo(ByVal WArticulo As String, ByVal WLote As Integer) As DataRow

        Dim WLaudo As DataRow = Nothing

        If Not isnothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
        cm.CommandText = String.Format("SELECT Clave, Saldo, Liberada, Marca FROM Laudo WHERE Articulo = '{0}' AND Laudo = '{1}'", WArticulo, WLote)

        dr = cm.ExecuteReader

        If dr.HasRows Then
            Dim tabla As New DataTable
            tabla.Load(dr)
            If tabla.Rows.Count > 0 Then WLaudo = tabla.Rows(0)
        End If

        Return WLaudo
    End Function

    Private Sub _ResetearValores()

        '
        ' Reseteamos datos de las Materias Primas
        '

        With ProgressBar1
            .Value = 0
            .Maximum = 1
        End With

        With lblEstado
            .Text = "Reseteando Valores Materia Prima..."
            .Refresh()
        End With

        If Not IsNothing(Conexion.EmpresaDeTrabajo) Then

            If rbPorRango.Checked Then

                cm.CommandText = String.Format("UPDATE Articulo SET FechaCierre = '{0}', OrdFechaCierre = '{1}', Inicial = 0, Laboratorio = 0, Pedido = 0 WHERE Codigo BETWEEN '{2}' AND '{3}'", WFechaCierre, WOrdFechaCierre, txtDesde.Text, txtHasta.Text)

            Else
                cm.CommandText = String.Format("UPDATE Articulo SET FechaCierre = '{0}', OrdFechaCierre = '{1}', Inicial = 0, Laboratorio = 0, Pedido = 0", WFechaCierre, WOrdFechaCierre)
            End If

            cm.ExecuteNonQuery()

        End If

        '
        'Reseteamos los datos de los Productos Terminados.
        '

        With ProgressBar1
            .Increment(1)

            Threading.Thread.Sleep(1000)

            .Value = 0
            .Maximum = 1
        End With

        With lblEstado
            .Text = "Reseteando Valores Productos Terminados..."
            .Refresh()
        End With

        If Not IsNothing(Conexion.EmpresaDeTrabajo) Then

            If rbPorRango.Checked Then

                cm.CommandText = String.Format("UPDATE Terminado SET FechaCierre = '{0}', OrdFechaCierre = '{1}', Inicial = 0, Proceso = 0 WHERE Codigo BETWEEN '{2}' AND '{3}'", WFechaCierre, WOrdFechaCierre, txtDesde.Text, txtHasta.Text)

            Else

                cm.CommandText = String.Format("UPDATE Terminado SET FechaCierre = '{0}', OrdFechaCierre = '{1}', Inicial = 0, Proceso = 0", WFechaCierre, WOrdFechaCierre)

            End If

            cm.ExecuteNonQuery()

        End If

        '
        ' Reseteamos los datos de los Laudos
        '
        Dim WDatos As DataTable

        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Articulo, ISNULL(Marca, '') Marca, ISNULL(Saldo, 0) Saldo FROM Laudo WHERE Articulo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Articulo, ISNULL(Marca, '') Marca, ISNULL(Saldo, 0) Saldo FROM Laudo", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores Laudos de Materia Prima..."
            .Refresh()
        End With

        With ProgressBar1
            .Increment(1)

            Threading.Thread.Sleep(1000)

            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row
                If Trim(.Item("Marca")) = "" Or Val(.Item("Saldo")) <> 0 Then

                    If Not _PosibleActualizarMP(.Item("Articulo")) Then Continue For

                    cm.CommandText = String.Format("UPDATE Laudo SET Marca = 'X', Saldo = 0, Liberada = 0, Devuelta = 0 WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

        '
        ' Reseteamos las Hojas de Produccion.
        '

        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Producto, ISNULL(Marca, '') Marca, ISNULL(Saldo, 0) Saldo FROM Hoja WHERE Producto BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Producto, ISNULL(Marca, '') Marca, ISNULL(Saldo, 0) Saldo FROM Hoja", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores de Hojas de Producción..."
            .Refresh()
        End With

        With ProgressBar1
            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row

                If Trim(.Item("Marca")) = "" Or Val(.Item("Saldo")) <> 0 Then

                    If Not _PosibleActualizarPT(.Item("Producto")) Then Continue For

                    cm.CommandText = String.Format("UPDATE Hoja SET Marca = 'X', Saldo = 0, Real = 0 WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

        '
        ' Reseteamos las Guias de Traslado Interno.
        '
        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Articulo, Terminado, Tipo, ISNULL(Marca, '') Marca, ISNULL(Saldo, 0) Saldo FROM Guia WHERE Articulo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' OR Terminado BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Articulo, Terminado, Tipo, ISNULL(Marca, '') Marca, ISNULL(Saldo, 0) Saldo FROM Guia", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores de Guías de Traslado Interno..."
            .Refresh()
        End With

        With ProgressBar1
            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row

                If Trim(.Item("Marca")) = "" Or Val(.Item("Saldo")) <> 0 Then

                    If .Item("Tipo") = "M" Then
                        If Not _PosibleActualizarMP(.Item("Articulo")) Then Continue For
                    Else
                        If Not _PosibleActualizarPT(.Item("Terminado")) Then Continue For
                    End If

                    cm.CommandText = String.Format("UPDATE Guia SET Marca = 'X', Saldo = 0, Cantidad = 0 WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

        '
        ' Reseteamos los Movimientos Varios.
        ' 
        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Articulo, Terminado, Tipo, ISNULL(Marca, '') Marca FROM MovVar WHERE Articulo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' OR Terminado BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Articulo, Terminado, Tipo, ISNULL(Marca, '') Marca FROM MovVar", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores de Movimientos Varios..."
            .Refresh()
        End With

        With ProgressBar1
            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row

                If Trim(.Item("Marca")) = "" Then

                    If .Item("Tipo") = "M" Then
                        If Not _PosibleActualizarMP(.Item("Articulo")) Then Continue For
                    Else
                        If Not _PosibleActualizarPT(.Item("Terminado")) Then Continue For
                    End If

                    cm.CommandText = String.Format("UPDATE MovVar SET Marca = 'X' WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

        '
        ' Reseteamos los Movimientos de Laboratorio.
        '

        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Articulo, Terminado, Tipo, ISNULL(Marca, '') Marca FROM MovLab WHERE Articulo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' OR Terminado BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Articulo, Terminado, Tipo, ISNULL(Marca, '') Marca FROM MovLab", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores de Movimientos de Laboratorio..."
            .Refresh()
        End With

        With ProgressBar1
            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row

                If Trim(.Item("Marca")) = "" Then

                    If .Item("Tipo") = "M" Then
                        If Not _PosibleActualizarMP(.Item("Articulo")) Then Continue For
                    Else
                        If Not _PosibleActualizarPT(.Item("Terminado")) Then Continue For
                    End If

                    cm.CommandText = String.Format("UPDATE MovLab SET Marca = 'X' WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

        '
        ' Reseteamos las Estadisticas.
        '

        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Ter = Articulo, Art = (LEFT(Articulo, 3) + RIGHT(Articulo, 7)), ISNULL(Marca, '') Marca FROM Estadistica WHERE (LEFT(Articulo, 3) + RIGHT(Articulo, 7)) BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' OR Articulo BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Ter = Articulo, Art = (LEFT(Articulo, 3) + RIGHT(Articulo, 7)), ISNULL(Marca, '') Marca FROM Estadistica", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores de Estadísticas..."
            .Refresh()
        End With

        With ProgressBar1
            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row

                If Trim(.Item("Marca")) = "" Then

                    Dim WLetra = .Item("Ter").ToString.Substring(0, 2).ToUpper

                    If {"PT", "YQ", "YF", "YP"}.Contains(WLetra) Then
                        If Not _PosibleActualizarPT(.Item("Ter")) Then Continue For
                    Else
                        If Not _PosibleActualizarMP(.Item("Art")) Then Continue For
                    End If

                    cm.CommandText = String.Format("UPDATE Estadistica SET Marca = 'X' WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

        '
        ' Reseteamos las Entradas por Devolución.
        '

        If rbPorRango.Checked Then
            WDatos = Query.GetAll("SELECT Clave, Terminado, Articulo = (LEFT(Terminado, 3) + RIGHT(Terminado, 7)), ISNULL(Marca, '') Marca FROM EntDev WHERE (LEFT(Terminado, 3) + RIGHT(Terminado, 7)) BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "' OR Terminado BETWEEN '" & txtDesde.Text & "' AND '" & txtHasta.Text & "'", Conexion.EmpresaDeTrabajo)
        Else
            WDatos = Query.GetAll("SELECT Clave, Terminado, Articulo = (LEFT(Terminado, 3) + RIGHT(Terminado, 7)), ISNULL(Marca, '') Marca FROM EntDev", Conexion.EmpresaDeTrabajo)
        End If

        With lblEstado
            .Text = "Reseteando Valores de Entradas por Devoluciones..."
            .Refresh()
        End With

        With ProgressBar1
            .Value = 0
            .Maximum = WDatos.Rows.Count + 2
        End With

        For Each row As DataRow In WDatos.Rows
            With row

                If Trim(.Item("Marca")) = "" Then

                    Dim WLetra = .Item("Terminado").ToString.Substring(0, 2).ToUpper

                    If {"PT", "RE", "NK", "YQ", "YF", "YP"}.Contains(WLetra) Then
                        If Not _PosibleActualizarPT(.Item("Terminado")) Then Continue For
                    Else
                        If Not _PosibleActualizarMP(.Item("Articulo")) Then Continue For
                    End If

                    cm.CommandText = String.Format("UPDATE EntDev SET Marca = 'X' WHERE Clave = '{0}'", .Item("Clave"))
                    cm.ExecuteNonQuery()

                End If
            End With
            ProgressBar1.Increment(1)
        Next

    End Sub

    Private Function _PosibleActualizarMP(ByVal item As Object) As Boolean

        If Not IsNothing(Conexion.EmpresaDeTrabajo) AndAlso Conexion.EmpresaDeTrabajo.ToUpper = "SURFACTANSA" Then
            If Not Helper._MateriaPrimaValidaPtaI(item) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Function _PosibleActualizarPT(ByVal item As Object) As Boolean

        If Not IsNothing(Conexion.EmpresaDeTrabajo) AndAlso Conexion.EmpresaDeTrabajo.ToUpper = "SURFACTANSA" Then
            If Not Helper._ProdTerminadoValidoPtaI(item) Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ActualizacionStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        lblEstado.Text = ""
        txtFechaCierre.Text = Date.Now.ToString("dd/MM/yyyy")
        WAutorizado = False
    End Sub

    Public Sub ProcesarClave(ByVal _Autorizado As Boolean) Implements IClaveAutorizacion.ProcesarClave
        WAutorizado = _Autorizado
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If WAutorizado Then
            btnAceptar.PerformClick()
            WAutorizado = False
        End If

    End Sub

    Private Sub rbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged, rbPorRango.CheckedChanged, rbPt.CheckedChanged, rbMp.CheckedChanged
        For Each ctrl As Control In {rbMp, rbPt, txtDesde, txtHasta}
            ctrl.Enabled = False
        Next

        If rbPorRango.Checked Then
            For Each ctrl As Control In {rbMp, rbPt, txtDesde, txtHasta}
                ctrl.Enabled = True
            Next

            For Each ctrl As MaskedTextBox In {txtDesde, txtHasta}
                ctrl.Mask = IIf(rbMp.Checked, "AA-000-000", "AA-00000-000")
                ctrl.Text = ""
            Next

            txtDesde.Focus()
        End If

    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If rbMp.Checked And txtDesde.Text.Replace(" ", "").Length < 10 then Exit Sub
            If rbPt.Checked And txtDesde.Text.Replace(" ", "").Length < 12 Then Exit Sub

            If txtHasta.Text.Replace("-", "").Trim = "" Then txtHasta.Text = txtDesde.Text

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If rbMp.Checked And txtHasta.Text.Replace(" ", "").Length < 10 Then Exit Sub
            If rbPt.Checked And txtHasta.Text.Replace(" ", "").Length < 12 Then Exit Sub

            If txtDesde.Text.Replace("-", "").Trim = "" Then txtDesde.Text = txtHasta.Text

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub
End Class