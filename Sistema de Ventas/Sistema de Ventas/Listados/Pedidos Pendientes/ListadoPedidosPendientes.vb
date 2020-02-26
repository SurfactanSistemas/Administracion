
Imports ConsultasVarias
Imports ConsultasVarias.Clases.Helper
Imports ConsultasVarias.Clases.Query
Imports CrystalDecisions.Shared

Public Class ListadoPedidosPendientes : Implements IBuscadorCliente, IBuscadorVendedor

    Dim UltimoTxtBoxCLiente As Integer = 0

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles mastxtFechaDesde.KeyPress, mastxtFechaHasta.KeyPress, txtVendedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ListadoPedidosPendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbTipo.SelectedIndex = 0
        cmbTipoListado.SelectedIndex = 0

    End Sub

    Private Sub mastxtFechaDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtFechaDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtFechaDesde.Text.Length = 10 Then
                    If _ValidarFecha(mastxtFechaDesde.Text) = True Then
                        mastxtFechaHasta.Focus()
                    End If
                End If
            Case Keys.Escape
                mastxtFechaDesde.Text = ""
        End Select

    End Sub

    Private Sub mastxtFechaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtFechaHasta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If mastxtFechaHasta.Text.Length = 10 Then
                    If _ValidarFecha(mastxtFechaHasta.Text) = True Then
                        mastxtProductoDesde.Focus()
                    End If
                End If
            Case Keys.Escape
                mastxtFechaHasta.Text = ""
        End Select
    End Sub

    Private Sub CmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipo.SelectedIndexChanged
        If CmbTipo.SelectedIndex = 0 Then
            mastxtProductoDesde.Mask = ">LL-00000-000"
            mastxtProductoHasta.Mask = ">LL-00000-000"
        Else
            mastxtProductoDesde.Mask = ">LL-000-000"
            mastxtProductoHasta.Mask = ">LL-000-000"
        End If
    End Sub



    Private Sub CmbTipo_DropDownClosed(sender As Object, e As EventArgs) Handles CmbTipo.DropDownClosed
        If CmbTipo.SelectedIndex = 0 Then
            mastxtProductoDesde.Mask = ">LL-00000-000"
            mastxtProductoHasta.Mask = ">LL-00000-000"
            mastxtProductoDesde.Focus()
            mastxtProductoDesde.SelectAll()
        Else
            mastxtProductoDesde.Mask = ">LL-000-000"
            mastxtProductoHasta.Mask = ">LL-000-000"
            mastxtProductoDesde.Focus()
            mastxtProductoDesde.SelectAll()

        End If
    End Sub

    Private Sub mastxtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtProductoDesde.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                mastxtProductoHasta.Focus()

            Case Keys.Escape
                mastxtProductoDesde.Text = ""
        End Select

    End Sub

    Private Sub txtCliente1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente1.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtCliente1.Text = "" Then
                    txtVendedor.Focus()
                Else
                    txtCliente2.Text = txtCliente1.Text
                    txtCliente2.Focus()
                    txtCliente2.SelectAll()
                End If
            Case Keys.Escape
                txtCliente1.Text = ""
        End Select
    End Sub

    Private Sub txtCliente2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente2.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtCliente2.Text <> "" Then
                    txtVendedor.Focus()
                End If
            Case Keys.Escape
                txtCliente2.Text = ""
        End Select
    End Sub

    Private Sub mastxtProductoHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles mastxtProductoHasta.KeyDown

        Select Case e.KeyData
            Case Keys.Enter

                txtCliente1.Focus()

            Case Keys.Escape
                mastxtProductoDesde.Text = ""
        End Select


    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If Trim(mastxtFechaDesde.Text.Replace("/", "")) = "" Then mastxtFechaDesde.Text = Today.ToString("dd/MM/yyyy")
        If Trim(mastxtFechaHasta.Text.Replace("/", "")) = "" Then mastxtFechaHasta.Text = (Today.AddYears(1)).ToString("dd/MM/yyyy")

        Dim Tipol As Integer = 0

        If txtCliente1.Text = "" Or txtCliente2.Text = "" Then
            Tipol = 1
            If txtVendedor.Text <> "" Then
                Tipol = 3
            End If
        End If

        If txtCliente1.Text <> "" And txtCliente2.Text <> "" Then
            Tipol = 2
        End If

        If ({"PT", "PE", "YQ", "YF", "YP", "YH"}.Contains(Microsoft.VisualBasic.Left(mastxtProductoDesde.Text, 2)) Or Microsoft.VisualBasic.Left(mastxtProductoHasta.Text, 2) = "DY") And txtCliente1.Text = "" Then
            Tipol = 4
        End If

        If ({"PT", "PE", "YQ", "YF", "YP", "YH"}.Contains(Microsoft.VisualBasic.Left(mastxtProductoDesde.Text, 2)) Or Microsoft.VisualBasic.Left(mastxtProductoHasta.Text, 2) = "DY") And txtCliente1.Text <> "" Then
            Tipol = 5
        End If

        Dim WDesde As String = ordenaFecha(mastxtFechaDesde.Text)

        Dim WHasta As String = ordenaFecha(mastxtFechaHasta.Text)

        Dim SQLCnslt As String

        Dim TablaAux As New DataTable

        With TablaAux.Columns
            .Add("Pedido")
            .Add("Cliente")
            .Add("Fecha")
            .Add("FecEntrega")
            .Add("Terminado")
            .Add("Cantidad")
            .Add("FechaOrd")
            .Add("Facturado")
            .Add("Importe")
            .Add("Autorizo")
            .Add("TipoPed")
            .Add("Razon")
            .Add("Vendedor")
        End With


        SQLCnslt = "SELECT  P.Pedido, P.Cliente, P.Fecha, P.FecEntrega, P.Terminado, P.Cantidad,P.FechaOrd, P.Facturado," _
                      & "  Importe = ( P.Cantidad - (Case when M.Remito <> 0 then  P.Cantidad else  P.Facturado end)), P.Autorizo, P.Tipoped, C.Razon, C.Vendedor " _
                      & " FROM Pedido P Left outer JOIN Muestra M ON P.Pedido = M.Pedido AND (P.Terminado = M.Producto or P.Terminado = M.Articulo)" _
                      & " LEFT OUTER JOIN Cliente C ON P.Cliente = C.Cliente" _
                      & " WHERE P.Cantidad > P.Facturado AND (P.TipoPed = 5 OR P.TipoPed = 6) AND Fechaord >= '" & WDesde & "' AND Fechaord <= '" & WHasta & "' ORDER BY P.Fechaord"

        TablaAux = GetAll(SQLCnslt)

        With TablaAux.Columns
            .Add("Descripcion")
        End With


        If TablaAux.Rows.Count > 0 Then
            For i = 0 To TablaAux.Rows.Count - 1
                Dim Wproducto As String = TablaAux.Rows(i).Item("Terminado")
                Dim WtipoPro = Microsoft.VisualBasic.Left(Wproducto, 2)


                Select Case WtipoPro
                    Case "PT", "PE", "YQ", "YF", "YP", "YH"



                        SQLCnslt = "SELECT distinct Descripcion = Case When (P.Terminado >= 'ML-00000-000' or P.Terminado <= 'ML-99999-999')" _
                                  & "THEN P.NombreComercial ELSE T.Descripcion END FROM Pedido P INNER JOIN Terminado T ON P.Terminado = T.Codigo " _
                                  & "WHERE Codigo = '" & Wproducto & "'"

                        Dim row As DataRow = GetSingle(SQLCnslt)
                        If row IsNot Nothing Then
                            TablaAux.Rows(i).Item("Descripcion") = row.Item("Descripcion")
                        End If


                    Case Else
                        Dim WArticulo As String = Microsoft.VisualBasic.Left(Wproducto, 3) + Microsoft.VisualBasic.Right(Wproducto, 7)

                        SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & WArticulo & "'"
                        Dim row As DataRow = GetSingle(SQLCnslt)
                        If row IsNot Nothing Then
                            TablaAux.Rows(i).Item("Descripcion") = row.Item("Descripcion")
                        End If
                End Select
            Next
        End If



        Dim Wempresa As String = Operador.Base


        Dim WTitulo As String = "entre el " & mastxtFechaDesde.Text & " hasta el " & mastxtFechaHasta.Text







        With New VistaPrevia
            .Reporte = New ReportePedidosPendientes()
            .Reporte.SetDataSource(TablaAux)
            Select Case Tipol

                Case 2

                    .Formula = " {TablaAux.Cliente} >= '" & UCase(txtCliente1.Text) & "' AND {TablaAux.Cliente} <= '" & UCase(txtCliente2.Text) & "'"

                Case 3

                    .Formula = " {TablaAux.Vendedor} = " & txtVendedor.Text & ""

                Case 4

                    If CmbTipo.SelectedItem = "MP" Then
                        .Formula = " {TablaAux.Terminado} >= '" & Microsoft.VisualBasic.Left(mastxtProductoDesde.Text, 3) & "00" & Microsoft.VisualBasic.Right(mastxtProductoDesde.Text, 7) & "'" _
                                                    & " AND {TablaAux.Terminado} <= '" & Microsoft.VisualBasic.Left(mastxtProductoHasta.Text, 3) & "00" & Microsoft.VisualBasic.Right(mastxtProductoHasta.Text, 7) & "'"
                    Else
                        .Formula = " {TablaAux.Terminado} >= '" & mastxtProductoDesde.Text & "' AND {TablaAux.Terminado} <= '" & mastxtProductoHasta.Text & "'"
                    End If

                Case 5

                    If CmbTipo.SelectedItem = "MP" Then
                        .Formula = " {TablaAux.Terminado} >= '" & Microsoft.VisualBasic.Left(mastxtProductoDesde.Text, 3) & "00" & Microsoft.VisualBasic.Right(mastxtProductoDesde.Text, 7) & "'" _
                                                    & " AND {TablaAux.Terminado} <= '" & Microsoft.VisualBasic.Left(mastxtProductoHasta.Text, 3) & "00" & Microsoft.VisualBasic.Right(mastxtProductoDesde.Text, 7) & "'" _
                                                    & "AND {TablaAux.Cliente} >= '" & UCase(txtCliente1.Text) & "' AND {TablaAux.Cliente} <= '" & UCase(txtCliente2.Text) & "'"
                    Else
                        .Formula = " {TablaAux.Terminado} >= '" & mastxtProductoDesde.Text & "' AND {TablaAux.Terminado} <= '" & mastxtProductoHasta.Text & "'" _
                                                    & "AND {TablaAux.Cliente} >= '" & UCase(txtCliente1.Text) & "' AND {TablaAux.Cliente} <= '" & UCase(txtCliente2.Text) & "'"
                    End If

            End Select

            .Reporte.SetParameterValue(0, Wempresa)
            .Reporte.SetParameterValue(1, WTitulo)
            If rabtnImpresora.Checked = True Then
                .Imprimir()
            Else
                If RabtnExportar.Checked = True Then
                    .Exportar("", ExportFormatType.Excel, "")
                Else
                    .Mostrar()
                End If
            End If
        End With
    End Sub

    Sub _ProcesarDatosCLiente(ByVal Codigo As String, ByVal Nombre As String) Implements IBuscadorCliente._ProcesarDatosCLiente
        If UltimoTxtBoxCLiente = 1 Then
            txtCliente1.Text = Codigo
        End If
        If UltimoTxtBoxCLiente = 2 Then
            txtCliente2.Text = Codigo
        End If
    End Sub


    Private Sub txtCliente1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtCliente1.MouseDoubleClick
        UltimoTxtBoxCLiente = 1
        With New BuscadorCliente
            .Show(Me)
        End With
    End Sub

    Private Sub txtCliente2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtCliente2.MouseDoubleClick
        UltimoTxtBoxCLiente = 2
        With New BuscadorCliente
            .Show(Me)
        End With
    End Sub

    Sub _procesarDatosVendedor(ByVal Codigo As String, ByVal Nombre As String) Implements IBuscadorVendedor._ProcesarDatosVendedor
        txtVendedor.Text = Codigo
    End Sub

    Private Sub txtVendedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtVendedor.MouseDoubleClick
        With New BuscadorVendedor
            .Show(Me)
        End With
    End Sub
End Class