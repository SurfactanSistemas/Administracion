Imports ClasesCompartidas
Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ListadoCuentaCorrienteProveedoresSelectivoPreparacion

    Dim varRenglon As Integer
    Dim varTotal, varSaldo, varTotalUs, varSaldoUs, varSaldoOriginal, varDife, varParidad, varParidadTotal As Double
    Dim varPago As Integer

    Private Sub ListadoCuentaCorrienteProveedoresSelectivoPreparacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCodProveedor.Text = ""
        varRenglon = 0
        _CargarProveedoresPreCargados()
    End Sub

    Private Sub _CargarProveedoresPreCargados()
        Dim _Proveedores As New List(Of Object)
        Dim _CargadosHaceMasDeUnaSemana As Integer = 0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT ps.Proveedor, ps.FechaOrd, p.Nombre, ps.Observaciones, ps.Desde, ps.Hasta FROM ProveedorSelectivo as ps, Proveedor as p WHERE ps.Proveedor = p.Proveedor")
        Dim dr As SqlDataReader
        Dim WObservaciones As String = ""

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    varRenglon = GRilla.Rows.Add()
                    GRilla.Item(0, varRenglon).Value = dr.Item("Proveedor")
                    GRilla.Item(1, varRenglon).Value = dr.Item("Nombre")

                    WObservaciones = IIf(IsDBNull(dr.Item("Observaciones")), "", dr.Item("Observaciones"))

                    txtDesde.Text = IIf(IsDBNull(dr.Item("Desde")), "", dr.Item("Desde"))
                    txtHasta.Text = IIf(IsDBNull(dr.Item("Hasta")), "", dr.Item("Hasta"))

                    GRilla.Item(2, varRenglon).Value = WObservaciones

                    GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit)
                    GRilla.CurrentCell = GRilla(0, 0)

                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Height = 690

        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Function _BuscarProveedor(ByVal proveedor As String) As Object
        Dim _Proveedor As Object = Nothing
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Proveedor, Nombre FROM Proveedor WHERE Proveedor = '" & proveedor & "' OR Nombre = '" & proveedor & "'")
        Dim dr As SqlDataReader

        If Trim(proveedor) = "" Then : Return _Proveedor : End If

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()
                _Proveedor = {dr.Item("Proveedor"), dr.Item("Nombre")}
            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return _Proveedor
    End Function

    Private Function _ProveedorYaAgregado(ByVal _CodProveedor As String) As Boolean
        Dim _YaAgregado As Boolean = False

        For Each row As DataGridViewRow In GRilla.Rows

            If Trim(row.Cells(0).Value) = Trim(_CodProveedor) Then
                _YaAgregado = True
                Exit For
            End If

        Next

        Return _YaAgregado
    End Function

    Private Function _ProveedorYaAgregado(ByVal _Proveedor As String, ByVal Excepto As Integer) As Boolean
        Dim _YaAgregado As Boolean = False

        For Each row As DataGridViewRow In GRilla.Rows

            If Trim(row.Cells(0).Value) = Trim(_Proveedor) And row.Index <> Excepto Then
                _YaAgregado = True
                Exit For
            ElseIf Trim(row.Cells(1).Value) = Trim(_Proveedor) And row.Index <> Excepto Then
                _YaAgregado = True
                Exit For
            End If

        Next

        Return _YaAgregado
    End Function

    Private Sub mostrarProveedor(ByVal proveedor As String)
        Dim _Proveedor As Object = _BuscarProveedor(proveedor)
        If IsNothing(_Proveedor) Then
            MsgBox("Proveedor incorrecto")
            txtCodProveedor.Focus()
        Else
            If Not _ProveedorYaAgregado(_Proveedor(0)) Then
                varRenglon = GRilla.Rows.Add()
                GRilla.Item(0, varRenglon).Value = _Proveedor(0)
                GRilla.Item(1, varRenglon).Value = _Proveedor(1)
                GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit)
                varRenglon = varRenglon + 1
                GRilla.CurrentCell = GRilla(0, 0)

                '_ActualizarProveedoresInscriptos(_Proveedor(0))

                txtCodProveedor.Text = ""
                txtAyuda.Text = ""
                txtCodProveedor.Focus()
            Else
                MsgBox("El Proveedor ya se encuentra agregado en el listado semanal.", MsgBoxStyle.Information)

                txtCodProveedor.Focus()

                If Me.Height > 600 Then : txtAyuda.Focus() : End If
            End If

        End If
    End Sub

    Private Sub _ActualizarProveedoresInscriptos(ByVal CodProveedor As String)
        Dim _Fecha As String = Date.Now.ToString("dd/MM/yyyy")
        Dim _FechaOrd As String = String.Join("", _Fecha.Split("/").Reverse())
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("INSERT INTO ProveedorSelectivo (Proveedor, Fecha, FechaOrd) Values ('" & CodProveedor & "', '" & _Fecha & "', '" & _FechaOrd & "')")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click

        If IsNothing(lstAyuda.SelectedValue) Then : Exit Sub : End If

        mostrarProveedor(lstAyuda.SelectedItem.ToString)
        txtAyuda.Focus()
    End Sub

    Private Sub txtCodProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodProveedor.Text) <> "" Then
                mostrarProveedor(txtCodProveedor.Text)
            Else
                btnConsulta.PerformClick()
            End If
        End If

    End Sub

    Private Sub _GuardarProveedores()
        Dim ZSql, WProveedor, WFecha, WFechaOrd, WObservaciones, WDesde, WHasta
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()

        If GRilla.Rows.Count > 0 Then


            ' Eliminamos todos los proveedores que ya hayan estado guardados para evitar duplicados.

            SQLConnector.conexionSql(cn, cm)

            Try
                cm.CommandText = "DELETE FROM ProveedorSelectivo"
                cm.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
                Exit Sub
            Finally

                cn.Close()

            End Try

            WDesde = txtDesde.Text
            WHasta = txtHasta.Text

            For Each row As DataGridViewRow In GRilla.Rows

                If Not IsNothing(row.Cells(0)) Then
                    With row
                        If Trim(.Cells(0).Value) <> "" Then
                            WProveedor = Trim(.Cells(0).Value)
                            WFecha = Date.Now.ToString("dd-MM-yyyy")
                            WFechaOrd = Proceso.ordenaFecha(WFecha)
                            WObservaciones = IIf(IsNothing(.Cells(2).Value), "", .Cells(2).Value)

                            ZSql = ""
                            ZSql &= "INSERT INTO ProveedorSelectivo "
                            ZSql &= "(Proveedor, Fecha, FechaOrd, Observaciones, Desde, Hasta) "
                            ZSql &= "VALUES ('" & WProveedor & "', '" & WFecha & "', '" & WFechaOrd & "', '" & WObservaciones & "', '" & WDesde & "', '" & WHasta & "') "

                            Try
                                cn.Open()
                                cm.CommandText = ZSql
                                cm.ExecuteNonQuery()

                            Catch ex As Exception
                                Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
                                Exit Sub
                            Finally

                                cn.Close()

                            End Try

                        End If
                    End With
                End If

            Next


        End If

    End Sub

    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click
        Try
            _GuardarProveedores()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
            Exit Sub
        End Try
        MsgBox("El listado provisorio se ha guardado correctamente", MsgBoxStyle.Information)
        txtCodProveedor.Focus()
    End Sub

    Private Sub _EliminarProveedoresSeleccionados()
        If MsgBox("¿Esta seguro que desea eliminar los proveedores seleccionados?", MsgBoxStyle.OkCancel) = DialogResult.OK Then
            For Each row As DataGridViewRow In GRilla.SelectedRows

                If Not IsNothing(row.Cells(0).Value) And Trim(row.Cells(0).Value) <> "" Then

                    If _EliminarProveedorSelectivo(row.Cells(0).Value) Then
                        GRilla.Rows.Remove(row)
                        varRenglon -= 1
                    End If

                End If

            Next
        End If
    End Sub

    Private Function _EliminarProveedorSelectivo(ByVal codProv As String) As Boolean
        Dim exito As Boolean = False
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM ProveedorSelectivo WHERE Proveedor = '" & Trim(codProv) & "'")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()
            exito = True

        Catch ex As Exception
            MsgBox("Hubo un problema al querer eliminar el Proveedor del periodo actual.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return exito
    End Function

    Private Sub btnLimpiarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarTodo.Click

        If GRilla.Rows.Count > 0 Then
            _LimpiarProveedoresSelectivos()
            txtCodProveedor.Text = ""
            txtCodProveedor.Focus()
        Else
            txtCodProveedor.Focus()
        End If

    End Sub

    Private Sub _LimpiarProveedoresSelectivos()

        If GRilla.Rows.Count > 0 Then

            If MsgBox("¿Está seguro que quiere eliminar todos los proveedores listados?", MsgBoxStyle.OkCancel) = DialogResult.OK Then
                _LimpiarTodosLosProveedoresSelectivos()
            End If

        End If

    End Sub

    Private Sub _LimpiarTodosLosProveedoresSelectivos()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("DELETE FROM ProveedorSelectivo")

        SQLConnector.conexionSql(cn, cm)

        Try

            cm.ExecuteNonQuery()

            MsgBox("Se han eliminado todos los proveedores correspondientes a este periodo.", MsgBoxStyle.Information)

            GRilla.Rows.Clear()

            txtCodProveedor.Focus()

            varRenglon = 0

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub txtCodProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstAyuda
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstAyuda
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        If IsNothing(filtrado.SelectedItem) Then : Exit Sub : End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstAyuda_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub ListadoCuentaCorrienteProveedoresSelectivoPreparacion_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtCodProveedor.Focus()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        If GRilla.Rows.Count > 0 And Not IsNothing(GRilla.Rows(0).Cells(0)) Then
            
            'crdoc.DataSourceConnections.Item(0).SetConnection("(LOCAL)\LOCALSQLSERVER", "SurfactanSA", True)
            'crdoc.DataSourceConnections.Item(0).SetConnection("193.168.0.7", "SurfactanSA", True)
            'crdoc.DataSourceConnections.Item(0).SetLogon("usuarioadmin", "usuarioadmin")

            '_Imprimir(crdoc)
            '_VistaPrevia(crdoc)
            Try
                _GuardarProveedores()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
                Exit Sub
            End Try

            With VistaPrevia
                .Reporte = New ProveedoresSelectivoPreparacionListado
                .Mostrar()
            End With

        End If

    End Sub

    Private Sub _Imprimir(ByVal crdoc As ReportDocument, Optional ByVal cant As Integer = 1)
        crdoc.PrintToPrinter(cant, True, 0, 0)
    End Sub

    Private Sub _VistaPrevia(ByVal crdoc As ReportDocument)
        With VistaPrevia
            .CrystalReportViewer1.ReportSource = crdoc
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        ' Realizan la misma funcion.
        Me.Close()
    End Sub


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GRilla_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GRilla.CellMouseDoubleClick
        Dim fila = GRilla.Rows(e.RowIndex)
        If Not IsNothing(fila) Then

            If Trim(fila.Cells(0).Value) <> "" Then

                If MsgBox("¿Seguro de querer eliminar el Proveedor Seleccionado?", MsgBoxStyle.YesNo, MsgBoxStyle.Information) = DialogResult.Yes Then
                    GRilla.Rows.Remove(fila)
                    _EliminarProveedorSelectivo(fila.Cells(0).Value)
                End If

            End If

        End If

    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtDesde.Text) Then
                txtHasta.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Clear()
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Proceso._ValidarFecha(txtDesde.Text) Then
                txtDesde.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Clear()
        End If
    End Sub

    Private Function _EsNumero(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 109)
    End Function

    Private Function _EsControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        Select Case keycode
            Case Keys.Enter, Keys.Escape, Keys.Right, Keys.Left, Keys.Back
                valido = True
            Case Else
                valido = False
        End Select

        Return valido
    End Function

    Private Function _EsNumeroOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsNumero(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If GRilla.Focused Or GRilla.IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
            GRilla.CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

            Dim iCol = GRilla.CurrentCell.ColumnIndex
            Dim iRow = GRilla.CurrentCell.RowIndex

            ' Limitamos los caracteres permitidos para cada una de las columnas.
            Select Case iCol
                Case 0
                    If Not _EsNumeroOControl(keyData) Then
                        Return True
                    End If
                Case Else

            End Select

            If msg.WParam.ToInt32() = Keys.Enter Then

                Dim valor = GRilla.Rows(iRow).Cells(iCol).Value

                If Not IsNothing(valor) Then

                    If iCol = 0 And iRow > -1 Then

                        Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(valor)

                        If Not IsNothing(proveedor) Then
                            If Not _ProveedorYaAgregado(proveedor.id, iRow) Then

                                GRilla.Rows(iRow).Cells(1).Value = Trim(proveedor.razonSocial)

                                GRilla.CurrentCell = GRilla.Rows(iRow).Cells(2)

                            Else
                                MsgBox("Proveedor ya cargado con anterioridad.", MsgBoxStyle.Information)
                                GRilla.CurrentCell = GRilla.Rows(iRow).Cells(iCol)
                            End If

                        End If
                    ElseIf iCol = 2 Then
                        If GRilla.Rows.Count < iRow + 1 Then
                            GRilla.CurrentCell = GRilla.Rows(GRilla.Rows.Add).Cells(0)
                        Else
                            GRilla.CurrentCell = GRilla.Rows(iRow + 1).Cells(0)
                        End If
                    End If

                    Return True
                Else

                    With GRilla
                        Select Case iCol
                            Case 0, 1
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Case 2
                                If .Rows.Count < iRow + 1 And Not IsNothing(.Rows(iRow).Cells(iCol).Value) Then
                                    .CurrentCell = .Rows(.Rows.Add).Cells(iCol)
                                Else
                                    .CurrentCell = .Rows(iRow + 1).Cells(iCol)
                                End If
                            Case Else
                        End Select
                    End With

                    Return True

                End If
            ElseIf msg.WParam.ToInt32() = Keys.Escape Then

                With GRilla
                    .Rows(iRow).Cells(iCol).Value = ""

                    ' Solo para que pierda el foco y se refresque el contenido sino sigue quedando ahi.
                    
                    Select Case iCol
                        Case 2
                            .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select


                    .CurrentCell = .Rows(iRow).Cells(iCol)
                End With


            End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class