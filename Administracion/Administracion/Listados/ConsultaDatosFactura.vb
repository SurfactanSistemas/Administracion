Imports System.Data.SqlClient
Imports System.IO
Imports ClasesCompartidas
Imports System.Text.RegularExpressions

Public Class ConsultaDatosFactura


    Private _NroInterno As String

    Public Property NroInterno As String
        Get
            Return _NroInterno
        End Get
        Set(ByVal value As String)
            _NroInterno = value

            _LimpiarCampos()

            _ObtenerDatosDeNroInterno(value)
        End Set
    End Property

    Private Sub _LimpiarCampos()
        For Each Control As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            Control.Text = ""
        Next

        For Each Control As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)()
            Control.Clear()
        Next

        DGVArticulos.Rows.Clear()

    End Sub

    Private Sub _ObtenerDatosDeNroInterno(ByVal _NroInterno)
        Dim XProveedor As String

        Dim cs As String = Configuration.ConfigurationManager.ConnectionStrings(ClasesCompartidas.Globals.empresa).ToString '"Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"
        Dim XCs = ""
        Dim _Empresas = Proceso.Empresas 'As New List(Of String) From {"SurfactanSA", "surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT ic.Numero, ic.Fecha, ic.Remito, ic.Proveedor, ic.Despacho, ic.Paridad, ic.Fecha as FechaEmision, ic.Vencimiento, ic.Vencimiento1, ic.Pago as Moneda, ic.Periodo as FechaIva from IvaComp as ic WHERE ic.NroInterno = '" & _NroInterno & "'")
        Dim dr As SqlDataReader

        ' Extraemos datos de proveedor y remito.
        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            With dr
                If .HasRows Then

                    .Read()

                    txtFactura.Text = .Item("Numero")
                    txtFechaFactura.Text = .Item("Fecha")

                    If Not IsDBNull(.Item("Remito")) Then
                        txtRemito.Text = Regex.Replace(Trim(dr.Item("Remito")), "\,\d+", "")
                    Else
                        txtRemito.Text = ""
                    End If

                    XProveedor = .Item("Proveedor")

                    txtParidad.Text = Proceso.formatonumerico(OrDefault(.Item("Paridad"), "0"))

                    If Not IsDBNull(.Item("Despacho")) Then
                        txtDespacho.Text = Trim(.Item("Despacho"))
                    Else
                        txtDespacho.Text = ""
                    End If

                    txtNroInterno.Text = _NroInterno
                    txtFechaEmision.Text = IIf(IsDBNull(.Item("FechaEmision")), "", Trim(.Item("FechaEmision")))
                    txtFechaVto1.Text = IIf(IsDBNull(.Item("Vencimiento")), "", Trim(.Item("Vencimiento")))
                    txtFechaVto2.Text = IIf(IsDBNull(.Item("Vencimiento1")), "", Trim(.Item("Vencimiento1")))
                    txtFechaVtoIva.Text = IIf(IsDBNull(.Item("FechaIva")), "", Trim(.Item("FechaIva")))

                    txtMoneda.Text = IIf(OrDefault(.Item("Moneda"), 1) = 1, "Pesos", "Cláusula Dólar")

                End If
            End With

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try

        ' Busco el informe segun empresa.
        For Each _Empresa As String In _Empresas
            'XCs = cs.Replace("#EMPRESA#", _Empresa)

            Dim Wrem = "SurfactanSA"

            If Proceso._EsPellital Then
                Wrem = "Pellital_III"
            End If

            XCs = cs.Replace("Catalog=" & Wrem, "Catalog=" & _Empresa)

            Try

                cn.ConnectionString = XCs
                cn.Open()
                cm.Connection = cn
                cm.CommandText = "SELECT i.Informe, i.Fecha, i.Orden, p.Nombre FROM Informe as i, Proveedor as p WHERE i.Remito = '" & txtRemito.Text & "' AND i.Proveedor = '" & XProveedor & "' AND i.Proveedor = p.Proveedor"

                dr = cm.ExecuteReader()

                With dr
                    If .HasRows Then

                        .Read()

                        txtInformeRecepcion.Text = Trim(.Item("Informe"))
                        txtFechaInformeRecepcion.Text = .Item("Fecha")
                        txtOrdenCompra.Text = Trim(.Item("Orden"))
                        txtNombreProveedor.Text = Trim(.Item("Nombre"))

                        Exit For
                    Else
                        XCs = ""
                    End If
                End With

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                XCs = ""
                Exit For
            Finally
                cn.Close()
            End Try

        Next

        ' Con el connection string donde conseguimos el informe, hacemos la consulta para extraer los detalles de los articulos.

        If XCs = "" Then
            Exit Sub
        End If

        ' Si el informe tiene numero de Orden, traemos los datos.

        If txtOrdenCompra.Text <> "" Then

            Try

                cn.ConnectionString = XCs
                cn.Open()
                cm.Connection = cn
                cm.CommandText = "SELECT Fecha, Carpeta FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "'"

                dr = cm.ExecuteReader()

                With dr
                    If .HasRows Then

                        .Read()
                        txtFechaOrdenCompra.Text = .Item("Fecha")
                        txtCarpeta.Text = .Item("Carpeta")

                    End If
                End With

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                XCs = ""
            Finally
                cn.Close()
            End Try

        End If

        If XCs = "" Then
            Exit Sub
        End If

        '' Extraemos los detalles de los articulos y los listamos.
        'Try

        '    cn.ConnectionString = XCs
        '    cn.Open()
        '    cm.Connection = cn
        '    cm.CommandText = "SELECT i.Orden, i.Articulo, a.Descripcion, i.Cantidad, o.Precio FROM Informe as i, Orden as o, Articulo as a WHERE i.Informe = '" & Trim(txtInformeRecepcion.Text) & "' AND i.Orden = o.Orden  AND i.Articulo = a.Codigo AND i.Articulo = o.Articulo"

        '    dr = cm.ExecuteReader()

        '    If dr.HasRows Then
        '        Dim i = 0
        '        Do While dr.Read()
        '            i = DGVArticulos.Rows.Add
        '            With DGVArticulos.Rows(i)
        '                .Cells(0).Value = Trim(dr.Item("Orden"))
        '                .Cells(1).Value = Trim(dr.Item("Articulo"))
        '                .Cells(2).Value = Trim(dr.Item("Descripcion"))
        '                .Cells(3).Value = formatonumerico(dr.Item("Cantidad"), "######0.#0", ".")
        '                .Cells(4).Value = formatonumerico(dr.Item("Precio"), "######0.#0", ".")

        '            End With

        '        Loop

        '    End If

        'Catch ex As Exception
        '    MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        '    XCs = ""
        'Finally
        '    cn.Close()
        'End Try

        ' Extraemos los detalles de los articulos y los listamos.
        Try

            cn.ConnectionString = XCs
            cn.Open()
            cm.Connection = cn
            'cm.CommandText = "SELECT i.Orden, i.Articulo, a.Descripcion, i.Cantidad, o.Precio FROM Informe as i, Orden as o, Articulo as a WHERE i.Informe = '" & Trim(txtInformeRecepcion.Text) & "' AND i.Orden = o.Orden  AND i.Articulo = a.Codigo AND i.Articulo = o.Articulo"
            cm.CommandText = "select i.Informe, i.Remito, i.Proveedor, i.fecha As FechaInforme, i.orden, p.nombre, o.fecha As FechaOrden, o.Carpeta, i.Articulo, a.Descripcion, i.Cantidad, o.Precio from informe i inner join Proveedor p on p.Proveedor = i.Proveedor inner join orden o on o.Orden = i.Orden inner join Articulo a on a.Codigo = i.Articulo where remito = '" & txtRemito.Text & "' and i.Proveedor = '" & XProveedor & "'"

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                Dim i = 0
                Do While dr.Read()
                    i = DGVArticulos.Rows.Add
                    With DGVArticulos.Rows(i)
                        .Cells("Informe").Value = Trim(OrDefault(dr.Item("Informe"), ""))
                        .Cells("FechaInforme").Value = Trim(OrDefault(dr.Item("FechaInforme"), ""))
                        .Cells("Remito").Value = Trim(OrDefault(dr.Item("Remito"), ""))
                        .Cells("Orden").Value = Trim(OrDefault(dr.Item("Orden"), ""))
                        .Cells("FechaOrden").Value = Trim(OrDefault(dr.Item("FechaOrden"), ""))
                        .Cells("Carpeta").Value = Trim(OrDefault(dr.Item("Carpeta"), ""))
                        .Cells("Producto").Value = Trim(OrDefault(dr.Item("Articulo"), ""))
                        .Cells("Descripcion").Value = Trim(OrDefault(dr.Item("Descripcion"), ""))
                        .Cells("Cantidad").Value = formatonumerico(OrDefault(dr.Item("Cantidad"), ""))
                        .Cells("Precio").Value = formatonumerico(OrDefault(dr.Item("Precio"), ""))
                    End With

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
            XCs = ""
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ConsultaDatosFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With DGVArticulos
            _AlinearDerecha(.Columns(0))
            _AlinearDerecha(.Columns(3))
            _AlinearDerecha(.Columns(4))
        End With

        TabControl1.TabIndex = 0

    End Sub

    Private Sub _AlinearDerecha(ByRef columna As DataGridViewColumn)
        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub DGVArticulos_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles DGVArticulos.SortCompare

        Dim num1, num2

        Select Case e.Column.Index
            Case 0, 3, 4

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 6, 7

                num1 = Proceso.ordenaFecha(e.CellValue1)
                num2 = Proceso.ordenaFecha(e.CellValue2)

            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True
    End Sub

    Private Sub btn_VerAdjunto_Click(sender As Object, e As EventArgs) Handles btn_VerAdjunto.Click
        Dim RutaGuardar As String = "\\193.168.0.2\g$\vb\NET\ArchivosRelacionadosFacturasCompras"
        Try
            If (Not Directory.Exists(RutaGuardar & "\" & NroInterno)) Then
                MsgBox("No existe ningun archivo para este numero interno")
                Exit Sub
            End If
            Dim RutaArchivo() As String = Directory.GetFiles(RutaGuardar & "\" & NroInterno)

            ' If RutaArchivo.Any() Then
            With New EditorArchivos(2, RutaGuardar & "\" & NroInterno, False)
                .Show(Me)
            End With
            '  For Each RutaArc In RutaArchivo
            '      Process.Start(RutaArc, "f")
            '  Next
            'Else
            '   MsgBox("Existe una carpeta para este numero interno, pero no contiene archivos adjuntos", vbExclamation)
            'End If

        Catch ex As Exception

        End Try
        
    End Sub


End Class