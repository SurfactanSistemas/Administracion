Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class AplicacionComprobantes

    Dim proveedorActual As String 'Lo uso para insertar y actualizar

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        If IsNothing(proveedor) Then : Exit Sub : End If
        txtProveedor.Text = proveedor.id
        txtRazon.Text = proveedor.razonSocial
        ' Uso la variable global ya que sin querer pueden llegar a haber cambiado el texto y romperia todo
        proveedorActual = txtProveedor.Text
        _Proceso()
        Me.Height = 501
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        Me.Height = 630
        lstAyuda.Visible = True
        txtAyuda.Visible = True
        lstAyuda.DataSource = DAOProveedor.buscarProveedoresActivoPorNombre("")
        txtAyuda.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub

    Private Sub btnProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceso.Click
        Dim proveedor = DAOProveedor.buscarProveedorPorCodigo(Trim(txtProveedor.Text))
        If Not IsNothing(proveedor) Then
            mostrarProveedor(proveedor)
        Else
            txtProveedor.Text = ""
            txtRazon.Text = ""
            txtProveedor.Focus()
        End If
    End Sub

    Private Function _DatosValidos(ByVal tipo As String, ByVal valor As Double, ByVal iRow As Integer, ByVal iCol As Integer) As Boolean
        Dim _valido As Boolean = True

        Select Case Val(tipo)

            Case 1, 2, 4

                If Math.Abs(valor) > Math.Abs(CDbl(dtgCuentas.Rows(iRow).Cells(iCol - 1).Value)) Or valor > 0 Then
                    _valido = False
                End If

            Case 3, 5

                If Math.Abs(valor) > Math.Abs(CDbl(dtgCuentas.Rows(iRow).Cells(iCol - 1).Value)) Or valor < 0 Then
                    _valido = False
                End If

        End Select

        Return _valido
    End Function

    Private Sub AplicacionComprobantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gridFormasBuilder As New GridBuilder(dtgCuentas)
        gridFormasBuilder.addTextColumn(0, "Tipo", True)
        gridFormasBuilder.addTextColumn(1, "Letra", True)
        gridFormasBuilder.addTextColumn(2, "Punto", True)
        gridFormasBuilder.addTextColumn(3, "Numero", True)
        gridFormasBuilder.addDateColumn(4, "Fecha", True)
        gridFormasBuilder.addFloatColumn(5, "Importe", True)
        gridFormasBuilder.addFloatColumn(6, "Saldo", True)
        gridFormasBuilder.addFloatColumn(7, "Aplica", True)
    End Sub

    Private Sub _Proceso()
        txtAyuda.Visible = False
        lstAyuda.Visible = False

        Dim WRenglon As Integer
        Dim WSuma As Double

        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo

        REM dada fix CAMBIAR Al uso de dao!!
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_deuda", txtProveedor.Text, "P")

        If tabla.Rows.Count = 0 Then : Exit Sub : End If

        dtgCuentas.Rows.Clear()
        WRenglon = 0

        For Each row As DataRow In tabla.Rows

            Dim CamposCtaCtePrv As New CtaCteProveedoresDeuda(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, "", row.Item(9).ToString)
            dtgCuentas.Rows.Add()

            dtgCuentas.Item(0, WRenglon).Value = CamposCtaCtePrv.Impre ' CamposCtaCtePrv.Tipo
            dtgCuentas.Item(1, WRenglon).Value = CamposCtaCtePrv.letra
            dtgCuentas.Item(2, WRenglon).Value = CamposCtaCtePrv.punto
            dtgCuentas.Item(3, WRenglon).Value = CamposCtaCtePrv.numero
            dtgCuentas.Item(4, WRenglon).Value = CamposCtaCtePrv.fecha

            dtgCuentas.Item(5, WRenglon).Value = formatonumerico(CamposCtaCtePrv.total, "########0.#0", ".")
            dtgCuentas.Item(6, WRenglon).Value = formatonumerico(CamposCtaCtePrv.saldo, "########0.#0", ".")
            dtgCuentas.Item(8, WRenglon).Value = CamposCtaCtePrv.Tipo

            WRenglon = WRenglon + 1
            WSuma = WSuma + CamposCtaCtePrv.saldo

        Next

        dtgCuentas.AllowUserToAddRows = False
        txtAyuda.Text = ""

        txtSaldo.Text = "0.00"


        If dtgCuentas.Rows.Count > 0 Then
            dtgCuentas.CurrentCell = dtgCuentas.Item(7, 0)
            dtgCuentas.Rows(0).Cells(7).Selected = True
            dtgCuentas.Focus()
        Else
            txtProveedor.Focus()
            MsgBox("El proveedor no posee datos para ser listados.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Function _ObtenerProximoCodigo() As Integer
        Dim ultimo As Integer = 0
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Max(Codigo) as Ultimo FROM AplicaProve")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                ultimo = dr.Item("Ultimo")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return ultimo + 1
    End Function

    Private Sub btnGraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGraba.Click
        Dim saldo As Double = 0 ' Convert.ToDouble(txtSaldo.Text)
        Dim importe As Double = 0
        Dim WCodigo As Integer = 0
        Dim WRenglon As Integer = 0

        Try
            _RecalcularSaldo()

            saldo = Convert.ToDouble(txtSaldo.Text)

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If saldo <> 0 Then
            MsgBox("Importe a aplicar no balancea")
        Else

            WCodigo = _ObtenerProximoCodigo()

            For Each row As DataGridViewRow In dtgCuentas.Rows
                If Not row.IsNewRow Then
                    importe = CustomConvert.toDoubleOrZero(row.Cells(7).Value)

                    If importe <> 0 Then
                        ' Actualizamos la cta cte del proveedor.
                        Try
                            SQLConnector.retrieveDataTable("actualizar_cuenta_corriente_proveedor", row.Cells(8).Value.ToString, row.Cells(1).Value.ToString, row.Cells(2).Value.ToString, row.Cells(3).Value.ToString, row.Cells(4).Value.ToString, CustomConvert.toDoubleOrZero(row.Cells(7).Value), proveedorActual)
                        Catch ex As Exception
                            MsgBox("Ocurrió un problema al querer actualizar la Cuenta Corriente del Proveedor.")
                            Exit Sub
                        End Try

                        ' Si no hubo problemas, damos de alta los renglones en AplicaProve
                        WRenglon += 1

                        Try
                            _DarDeAltaRenglonAplicacionComprobante(row, WRenglon, WCodigo)
                        Catch ex As Exception
                            MsgBox("Error al dar de alta Aplicacion de Comprobantes", MsgBoxStyle.Information)
                            Exit Sub
                        End Try

                    End If

                End If
            Next

            limpiar()
            MsgBox("La aplicación de Comprobantes fue existosa.", MsgBoxStyle.Information)

        End If
    End Sub

    Private Sub _DarDeAltaRenglonAplicacionComprobante(ByVal row As DataGridViewRow, ByVal WRenglon As Integer, ByVal WCodigo As Integer)
        Dim ZSql As String = ""
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dr As SqlDataReader
        Dim ZZClave As String = ""
        Dim ZZCodigo As String = ""
        Dim ZZRenglon As String = ""
        Dim ZZFecha As String = Date.Now.ToString("dd/MM/yyyy")
        Dim ZZOrdFecha As String = Proceso.ordenaFecha(ZZFecha)
        Dim ZZProveedor As String = Trim(txtProveedor.Text)
        Dim ZZTipo As String = ""
        Dim ZZLetra As String = ""
        Dim ZZPunto As String = ""
        Dim ZZNumero As String = ""
        Dim ZZImporte As String = ""

        With row
            ZZClave = ceros(WCodigo, 8) & ceros(WRenglon, 3)
            ZZRenglon = WRenglon
            ZZTipo = .Cells(8).Value
            ZZLetra = .Cells(1).Value
            ZZPunto = .Cells(2).Value
            ZZNumero = .Cells(3).Value
            ZZImporte = Proceso.formatonumerico(-1 * .Cells(7).Value)
        End With

        ZSql = ""
        ZSql &= "INSERT INTO AplicaProve ("
        ZSql &= "Clave ,"
        ZSql &= "Codigo ,"
        ZSql &= "Renglon ,"
        ZSql &= "Fecha ,"
        ZSql &= "OrdFecha ,"
        ZSql &= "Proveedor ,"
        ZSql &= "Tipo ,"
        ZSql &= "Letra ,"
        ZSql &= "Punto ,"
        ZSql &= "Numero ,"
        ZSql &= "Importe )"
        ZSql &= "Values ("
        ZSql &= "'" & ZZClave & "',"
        ZSql &= "'" & WCodigo & "',"
        ZSql &= "'" & ZZRenglon & "',"
        ZSql &= "'" & ZZFecha & "',"
        ZSql &= "'" & ZZOrdFecha & "',"
        ZSql &= "'" & ZZProveedor & "',"
        ZSql &= "'" & ZZTipo & "',"
        ZSql &= "'" & ZZLetra & "',"
        ZSql &= "'" & ZZPunto & "',"
        ZSql &= "'" & ZZNumero & "',"
        ZSql &= "'" & ZZImporte & "')"

        cm.CommandText = ZSql

        SQLConnector.conexionSql(cn, cm)

        Try
            cm.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos.")
            Exit Sub
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Sub

    Private Sub limpiar()
        dtgCuentas.Rows.Clear()
        txtAyuda.Text = ""
        txtProveedor.Text = ""
        txtRazon.Text = ""
        txtProveedor.Focus()
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

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtProveedor.Text) = "" Then
                btnConsulta.PerformClick()
                Exit Sub
            End If

            _Proceso()

        ElseIf e.KeyData = Keys.Escape Then
            txtProveedor.Text = ""
        End If

    End Sub

    Private Sub AplicacionComprobantes_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtProveedor.Focus()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dtgCuentas
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex

                If msg.WParam.ToInt32() = Keys.Enter Then

                    Dim valor = .Rows(iRow).Cells(iCol).Value
                    Dim tipo = .Rows(iRow).Cells(8).Value

                    If Not IsNothing(valor) Then

                        ' Comprobamos que los datos sean posibles.
                        If Not _DatosValidos(tipo, valor, iRow, iCol) Then
                            dtgCuentas.CurrentCell = dtgCuentas.Rows(iRow).Cells(iCol)
                            Return True
                        Else
                            Try
                                _RecalcularSaldo()

                                If .Rows.Count - 1 > iRow Then ' en caso de que lleguemos a la ult fila.
                                    dtgCuentas.CurrentCell = dtgCuentas.Rows(iRow + 1).Cells(iCol)
                                Else
                                    dtgCuentas.CurrentCell = dtgCuentas.Rows(0).Cells(iCol)
                                End If

                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Information)
                                Return True
                            End Try
                        End If
                        Return True
                    End If

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then
                    .Rows(iRow).Cells(iCol).Value = ""
                End If
            End If
        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub _RecalcularSaldo()
        Dim tipo As String = ""
        Dim valorAplica As Double = 0
        Dim valor As Double = 0
        Dim iRow, iCol As Integer

        For Each _row As DataGridViewRow In dtgCuentas.Rows

            If IsNothing(dtgCuentas.Rows(dtgCuentas.CurrentCell.RowIndex).Cells(dtgCuentas.CurrentCell.ColumnIndex).Value) Then
                dtgCuentas.Rows(dtgCuentas.CurrentCell.RowIndex).Cells(dtgCuentas.CurrentCell.ColumnIndex).Value = 0
            End If

            tipo = _row.Cells(8).Value
            valor = Convert.ToDouble(_row.Cells(7).Value)
            iRow = _row.Index
            iCol = 7

            If Not _DatosValidos(tipo, valor, iRow, iCol) Then
                Throw New Exception("Uno de los valores no es valido.")
                Exit For
            End If

            valorAplica += valor

        Next

        txtSaldo.Text = Proceso.formatonumerico(valorAplica)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
End Class
