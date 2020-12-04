Imports CrystalDecisions.Data
Imports Microsoft.Office.Core
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports Microsoft.Office.Interop
Public Class PedidoProforma : Implements IConsultaCliente, IConsultaPedidos, IConsulta_Terminado

    Dim NroPedido As String

    Private MOSTRAR_MSG_IDIOMAS As Boolean = True

    ' Para controles de grilla.
    Private Const YMARGEN = 1.5
    Private Const XMARGEN = 4.9
    Private WRow, Wcol As Integer

    ' Constantes
    Private Const PRODUCTOS_MAX = 8
    Private Const SEPARADOR_CONSULTA = "____"

    Sub New(Optional ByVal Pedido As String = "0")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        NroPedido = Pedido
    End Sub


    Private Sub PedidoProforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQLCnslt As String
        If Val(NroPedido) <> 0 Then
            SQLCnslt = "SELECT p.*, c.Razon, c.NombrePais  FROM PedidoProformaExportacion p INNER JOIN Cliente c ON p.Cliente = c.Cliente " _
                                     & "WHERE NroPedido = '" & NroPedido & "' ORDER BY Renglon"
            Dim Tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If Tabla.Rows.Count > 0 Then
                Dim Posicion As Integer = 0
                For Each row As DataRow In Tabla.Rows
                    With row
                        If Posicion = 0 Then
                            txt_NroPedido.Text = Trim(.Item("NroPedido"))
                            txt_Fecha.Text = .Item("Fecha")
                            txt_Cliente.Text = .Item("Cliente")
                            txt_DescripcionCliente.Text = .Item("Razon")
                            txt_CondicionPago.Text = .Item("CondPago")
                            txt_OCCliente.Text = .Item("OCCliente")
                            txt_NroProforma.Text = .Item("NroProforma")
                            cmb_Condicion.SelectedIndex = .Item("Condicion")
                            cmb_Idioma.SelectedIndex = .Item("idioma")
                            cmb_Via.SelectedIndex = .Item("Via")
                            txt_DireccionCliente.Text = .Item("Direccion")
                            txt_LocalidadCliente.Text = .Item("Localidad")
                            txt_Pais.Text = IIf(IsDBNull(.Item("NombrePais")), "", .Item("NombrePais"))
                            txt_Observaciones.Text = .Item("Observaciones")
                            txt_ObservacionesII.Text = .Item("ObservacionesII")
                            txt_ObservacionesIII.Text = .Item("ObservacionesIII")
                            txt_Contacto.Text = .Item("Contacto")
                            txt_MailContacto.Text = .Item("MailContacto")
                            txt_Total.Text = formatonumerico(.Item("Total"))
                            txt_Operador.Text = IIf(IsDBNull(.Item("OperadorDesc")), "", .Item("OperadorDesc"))
                        End If
                        Dim Saldo As Double = .Item("Cantidad") * .Item("Precio")



                        dgvProductos.Rows.Add(.Item("Producto"), .Item("DescriProducto"), .Item("Cantidad"), .Item("Precio"), formatonumerico(Saldo))
                        Posicion += 1
                    End With

                Next


            End If

            txt_Cliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        Else
            SQLCnslt = "SELECT Descripcion FROM Operador WHERE Clave = '" & Operador.Clave & "'"
            Dim row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If row IsNot Nothing Then
                txt_Operador.Text = row.Item("Descripcion")
            End If

        End If

    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btn_ConsultaCliente.Click
        With ConsultaCliente
            .Show(Me)
        End With
    End Sub

    Public Sub PasarCliente(CodigoCli As String, RazonCli As String, NombrePais As String) Implements IConsultaCliente.PasarCliente
        txt_Cliente.Text = CodigoCli
        txt_DescripcionCliente.Text = RazonCli
        If Trim(NombrePais) = "" Then
            txt_Pais.Focus()
        Else
            txt_Pais.Text = Trim(NombrePais)
            cmb_Idioma.Focus()
        End If

        Dim SQlCnslt As String = "SELECT EnvasesI, EnvasesII, EnvasesIII, EtiquetaI, EtiquetaII, " _
                                  & "Especif1, Especif2, Especif3, Especif4, Especif5 " _
                                  & "FROM ClienteEspecif WHERE Cliente = '" & txt_Cliente.Text & "'"
        Dim rowEspecif As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
        If rowEspecif IsNot Nothing Then
            With rowEspecif
                txt_Envases.Text = OrDefault(.Item("EnvasesI"), "") & vbCrLf _
                                 & OrDefault(.Item("EnvasesII"), "") & vbCrLf _
                                 & OrDefault(.Item("EnvasesIII"), "")

                txt_Etiquetas.Text = OrDefault(.Item("EtiquetaI"), "") & vbCrLf _
                                   & OrDefault(.Item("EtiquetaII"), "")

                txt_Otras.Text = OrDefault(.Item("Especif1"), "") & vbCrLf _
                               & OrDefault(.Item("Especif2"), "") & vbCrLf _
                               & OrDefault(.Item("Especif3"), "") & vbCrLf _
                               & OrDefault(.Item("Especif4"), "") & vbCrLf _
                               & OrDefault(.Item("Especif5"), "")
            End With
        End If

    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_NroPedido.Text = ""
        txt_Fecha.Text = ""
        txt_Cliente.Text = ""
        txt_DescripcionCliente.Text = ""
        txt_CondicionPago.Text = ""
        txt_OCCliente.Text = ""
        txt_NroProforma.Text = ""
        txt_DireccionCliente.Text = ""
        txt_LocalidadCliente.Text = ""
        txt_Pais.Text = ""
        txt_Observaciones.Text = ""
        txt_ObservacionesII.Text = ""
        txt_ObservacionesIII.Text = ""
        txt_Contacto.Text = ""
        txt_MailContacto.Text = ""
        txt_Total.Text = ""

        cmb_Condicion.SelectedIndex = 0
        cmb_Idioma.SelectedIndex = 0
        cmb_Via.SelectedIndex = 0

        dgvProductos.Rows.Clear()

    End Sub

    Private Sub btn_CosultaPedidosPendientes_Click(sender As Object, e As EventArgs) Handles btn_CosultaPedidosPendientes.Click
        With New ConsultaPedidosPendXCliente
            .Show(Me)
        End With
    End Sub

    Public Sub PasaPedido(NroPedido As Integer) Implements IConsultaPedidos.PasaPedido

        btn_Limpiar_Click(Nothing, Nothing)

        Dim SQLCnslt As String = "SELECT p.Pedido, p.Cliente, p.Fecha, p.Via, PedidoDirEntrega = p.DirEntrega, p.Observaciones, p.Facturado, p.Terminado, p.Cantidad, p.Precio, p.Descripcion, " _
                                 & "c.Razon, c.Localidad, PedDirEntrega = c.DirEntrega, c.DirEntregaII, c.DirEntregaIII, c.DirEntregaIV, c.DirEntregaV, c.Idioma " _
                                 & "FROM Pedido p INNER JOIN Cliente c ON p.Cliente = c.Cliente " _
                                 & "WHERE Pedido = '" & NroPedido & "' AND Facturado < Cantidad  ORDER BY Renglon"
        Dim Tabla As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If Tabla.Rows.Count > 0 Then
            Dim Posicion As Integer = 0
            For Each row As DataRow In Tabla.Rows
                With row
                    If Posicion = 0 Then
                        txt_NroPedido.Text = NroPedido
                        txt_Fecha.Text = .Item("Fecha")
                        txt_Cliente.Text = .Item("Cliente")
                        txt_DescripcionCliente.Text = .Item("Razon")
                       
                        Dim Widioma As Integer = IIf(IsDBNull(.Item("Idioma")), 0, .Item("Idioma"))
                        cmb_Idioma.SelectedIndex = Widioma
                        Select Case .Item("PedidoDirEntrega")
                            Case 1
                                txt_DireccionCliente.Text = .Item("PedDirEntrega")
                            Case 2
                                txt_DireccionCliente.Text = .Item("DirEntregaII")
                            Case 3
                                txt_DireccionCliente.Text = .Item("DirEntregaIII")
                            Case 4
                                txt_DireccionCliente.Text = .Item("DirEntregaIV")
                            Case 5
                                txt_DireccionCliente.Text = .Item("DirEntregaV")
                        End Select
                       
                        txt_LocalidadCliente.Text = .Item("Localidad")


                        Dim Wobservaciones As String = .Item("Observaciones")
                        Wobservaciones = Wobservaciones.PadRight(100)
                        txt_Observaciones.Text = Trim(Wobservaciones.Substring(0, 50))
                        txt_ObservacionesII.Text = Trim(Wobservaciones.Substring(50, 50))
                    

                    End If
                    Dim Saldo As Double = .Item("Cantidad") * .Item("Precio")
                    dgvProductos.Rows.Add(.Item("Terminado"), .Item("Descripcion"), formatonumerico(.Item("Cantidad")),
                                          formatonumerico(.Item("Precio")), formatonumerico(Saldo))
                    Posicion += 1
                End With

            Next
            Dim WTotal As Double = 0
            For Each row As DataGridViewRow In dgvProductos.Rows
                WTotal += Val(Util.Clases.Helper.formatonumerico(row.Cells("Total").Value))
            Next
            txt_Total.Text = Util.Clases.Helper.formatonumerico(WTotal)
        End If
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        If txt_NroPedido.Text = "" Then
            Exit Sub
        End If
        Dim SQLCnslt As String = "SELECT NroProforma FROM PedidoProformaExportacion WHERE NroPedido = '" & txt_NroPedido.Text & "'"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            If Row.Item("NroProforma") = "" Then
                If MsgBox("¿Desea eliminar el pedido de proforma Nro: " & txt_NroPedido.Text & "?", vbYesNo) = vbYes Then
                    SQLCnslt = "DELETE  FROM PedidoProformaExportacion WHERE NroPedido = '" & txt_NroPedido.Text & "'"
                    ExecuteNonQueries("SurfactanSa", SQLCnslt)


                    Dim WOwner As IPreProforma = TryCast(Owner, IPreProforma)
                    If WOwner IsNot Nothing Then
                        WOwner.RecargaGrilla()
                        Close()
                    End If

                End If
            Else
                MsgBox("No se puede eliminar un pedido de proforma que ya se le a asignado una proforma", vbExclamation)
            End If
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Trim(txt_MailContacto.Text) = "" And Trim(txt_Contacto.Text) = "" Then
            MsgBox("Se debe ingresar un valor en los campos de Contacto o Mail Contacto, para porder grabar", vbExclamation)
            Exit Sub
        End If

        If Trim(txt_NroProforma.Text) <> "" Then
            MsgBox("Este pedido ya tiene un Nro. de proforma asignado, no se puede actualizar", vbExclamation)
            Exit Sub
        End If

        Dim SQlCnslt As String
        Dim Clave As String
        Dim Renglon As Integer = 0

        Try

            If txt_NroPedido.Text <> "" Then
                SQlCnslt = "DELETE  FROM PedidoProformaExportacion WHERE NroPedido = '" & txt_NroPedido.Text & "'"
                ExecuteNonQueries("SurfactanSa", SQlCnslt)
            End If


            SQlCnslt = "SELECT Descripcion FROM Operador WHERE Clave = '" & Operador.Clave & "'"
            Dim rowOpe As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
            If rowOpe IsNot Nothing Then
                If Trim(txt_Operador.Text) <> Trim(rowOpe.Item("Descripcion")) Then
                    txt_Operador.Text = rowOpe.Item("Descripcion")
                End If
            End If


            Dim listaSQLCnslt As New List(Of String)

            For Each row As DataGridViewRow In dgvProductos.Rows
                Renglon += 1
                If row.Cells("Producto").Value = "" Then
                    Continue For
                End If
                Dim WRenglon As String = Renglon.ToString().PadLeft(2, "0")

                Dim WNroPedido As Integer
                If txt_NroPedido.Text = "" Then

                    SQlCnslt = "SELECT Maxpedido = Max(NroPedido) FROM PedidoProformaExportacion"
                    Dim RowNroPedido As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
                    If RowNroPedido IsNot Nothing Then

                        WNroPedido = IIf(IsDBNull(RowNroPedido.Item("Maxpedido")), 0, RowNroPedido.Item("Maxpedido")) + 1

                    End If
                    txt_NroPedido.Text = WNroPedido

                End If



                Clave = txt_NroPedido.Text & WRenglon

                SQlCnslt = "INSERT INTO PedidoProformaExportacion(Clave, " _
                    & "Renglon, " _
                    & "NroPedido, " _
                    & "Fecha, " _
                    & "FechaOrd, " _
                    & "Cliente, " _
                    & "Direccion, " _
                    & "Localidad, " _
                    & "Pais, " _
                    & "CondPago, " _
                    & "OCCliente, " _
                    & "Condicion, " _
                    & "Via, " _
                    & "Observaciones, " _
                    & "ObservacionesII, " _
                    & "ObservacionesIII, " _
                    & "Producto, " _
                    & "DescriProducto, " _
                    & "Cantidad, " _
                    & "Precio, " _
                    & "Total, " _
                    & "Idioma, " _
                    & "Contacto, " _
                    & "MailContacto, " _
                    & "NroProforma, " _
                    & "OperadorDesc) " _
                    & "Values( " _
                    & "'" & Clave & "', " _
                    & "'" & Renglon & "', " _
                    & "'" & Trim(txt_NroPedido.Text) & "', " _
                    & "'" & txt_Fecha.Text & "', " _
                    & "'" & ordenaFecha(txt_Fecha.Text) & "', " _
                    & "'" & txt_Cliente.Text & "', " _
                    & "'" & txt_DireccionCliente.Text & "', " _
                    & "'" & txt_LocalidadCliente.Text & "', " _
                    & "'" & txt_Pais.Text & "', " _
                    & "'" & txt_CondicionPago.Text & "', " _
                    & "'" & txt_OCCliente.Text & "', " _
                    & "'" & cmb_Condicion.SelectedIndex & "', " _
                    & "'" & cmb_Via.SelectedIndex & "', " _
                    & "'" & txt_Observaciones.Text & "', " _
                    & "'" & txt_ObservacionesII.Text & "', " _
                    & "'" & txt_ObservacionesIII.Text & "', " _
                    & "'" & row.Cells("Producto").Value & "', " _
                    & "'" & row.Cells("Descripcion").Value & "', " _
                    & "'" & formatonumerico(row.Cells("Cantidad").Value) & "', " _
                    & "'" & formatonumerico(row.Cells("Precio").Value) & "', " _
                    & "'" & txt_Total.Text & "', " _
                    & "'" & cmb_Idioma.SelectedIndex & "', " _
                    & "'" & txt_Contacto.Text & "', " _
                    & "'" & txt_MailContacto.Text & "', " _
                    & "'" & txt_NroProforma.Text & "', " _
                    & "'" & txt_Operador.Text & "')"

                listaSQLCnslt.Add(SQlCnslt)

            Next

            ExecuteNonQueries("SurfactanSa", listaSQLCnslt.ToArray())


            SQlCnslt = "SELECT NombrePais FROM Cliente WHERE Cliente = '" & Trim(txt_Cliente.Text) & "'"
            Dim rowCli As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
            If rowCli IsNot Nothing Then
                Dim Wnombrepais As String = IIf(IsDBNull(rowCli.Item("NombrePais")), "", rowCli.Item("NombrePais"))
                If Trim(Wnombrepais) = "" Or Trim(Wnombrepais) <> Trim(txt_Pais.Text) Then
                    SQlCnslt = "UPDATE Cliente SET NombrePais = '" & Trim(txt_Pais.Text) & "' WHERE Cliente = '" & Trim(txt_Cliente.Text) & "'"
                    ExecuteNonQueries("SurfactanSa", SQlCnslt)
                End If
            End If

            _AvisarPorEmail()

            Dim WOwner As IPreProforma = TryCast(Owner, IPreProforma)
            If WOwner IsNot Nothing Then
                WOwner.RecargaGrilla()
                Close()
            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub PedidoProforma_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Fecha.Focus()
    End Sub

    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) = "S" Then
                    txt_Cliente.Focus()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
    End Sub

    Private Sub txt_Cliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cliente.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Cliente.Text = "" Then
                    With New ConsultaCliente
                        .Show(Me)
                    End With
                    txt_Pais.Focus()
                Else
                    txt_Cliente.Text = UCase(txt_Cliente.Text)
                    Dim SQlCnslt As String = "SELECT Razon, Direccion, Localidad FROM Cliente WHERE cliente = '" & txt_Cliente.Text & "'"
                    Dim row As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
                    If row IsNot Nothing Then
                        txt_DescripcionCliente.Text = UCase(row.Item("Razon"))
                        txt_DireccionCliente.Text = UCase(row.Item("Direccion"))
                        txt_LocalidadCliente.Text = UCase(row.Item("Localidad"))
                        txt_Pais.Focus()

                        SQlCnslt = "SELECT EnvasesI, EnvasesII, EnvasesIII, EtiquetaI, EtiquetaII, " _
                                 & "Especif1, Especif2, Especif3, Especif4, Especif5 " _
                                 & "FROM ClienteEspecif WHERE Cliente = '" & txt_Cliente.Text & "'"
                        Dim rowEspecif As DataRow = GetSingle(SQlCnslt, "SurfactanSa")
                        If rowEspecif IsNot Nothing Then
                            With rowEspecif
                                txt_Envases.Text = OrDefault(.Item("EnvasesI"), "") & vbCrLf _
                                                 & OrDefault(.Item("EnvasesII"), "") & vbCrLf _
                                                 & OrDefault(.Item("EnvasesIII"), "")

                                txt_Etiquetas.Text = OrDefault(.Item("EtiquetaI"), "") & vbCrLf _
                                                   & OrDefault(.Item("EtiquetaII"), "")

                                txt_Otras.Text = OrDefault(.Item("Especif1"), "") & vbCrLf _
                                               & OrDefault(.Item("Especif2"), "") & vbCrLf _
                                               & OrDefault(.Item("Especif3"), "") & vbCrLf _
                                               & OrDefault(.Item("Especif4"), "") & vbCrLf _
                                               & OrDefault(.Item("Especif5"), "")
                            End With

                        End If

                    Else
                        txt_Cliente.Focus()
                    End If
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select
    End Sub

    Private Sub txt_Pais_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Pais.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                cmb_Idioma.Focus()
            Case Keys.Escape
                txt_Pais.Text = ""
        End Select
    End Sub

    Private Sub cmb_Idioma_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_Idioma.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_CondicionPago.Focus()
        End Select

    End Sub

    Private Sub txt_CondicionPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_CondicionPago.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_OCCliente.Focus()
            Case Keys.Escape
                txt_CondicionPago.Text = ""
        End Select
    End Sub

    Private Sub txt_OCCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_OCCliente.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                cmb_Via.Focus()
            Case Keys.Escape
                txt_OCCliente.Text = ""
        End Select
    End Sub

    Private Sub cmb_Via_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_Via.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                cmb_Condicion.Focus()

        End Select
    End Sub

    Private Sub cmb_Condicion_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_Condicion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Contacto.Focus()

        End Select
    End Sub

    Private Sub txt_Contacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Contacto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_MailContacto.Focus()
            Case Keys.Escape
                txt_Contacto.Text = ""
        End Select
    End Sub

    Private Sub txt_MailContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_MailContacto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_Observaciones.Focus()
            Case Keys.Escape
                txt_MailContacto.Text = ""
        End Select
    End Sub

    Private Sub txt_Observaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Observaciones.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_ObservacionesII.Focus()
            Case Keys.Escape
                txt_Observaciones.Text = ""
        End Select
    End Sub

    Private Sub txt_ObservacionesII_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ObservacionesII.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txt_ObservacionesIII.Focus()
            Case Keys.Escape
                txt_ObservacionesII.Text = ""
        End Select
    End Sub


    Private Sub txt_ObservacionesIII_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ObservacionesIII.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            Case Keys.Escape
                txt_ObservacionesIII.Text = ""
        End Select
    End Sub

    Private Sub txtFechaAux_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFechaAux.KeyDown
        If e.KeyData = Keys.Enter Then
            If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then
                txtFechaAux_DoubleClick(Nothing, Nothing)
                Exit Sub
            End If

            If WRow >= 0 And Wcol >= 0 Then

                With dgvProductos
                    .Rows(WRow).Cells(0).Value = txtFechaAux.Text

                    Dim terminado = _BuscarTerminado(txtFechaAux.Text)

                    If Not IsNothing(terminado) Then
                        .Rows(WRow).Cells(0).Value = terminado("Codigo")
                        .Rows(WRow).Cells(1).Value = _TraerNombreProducto(terminado("Codigo")) 'terminado("Descripcion")

                        .CurrentCell = .Rows(WRow).Cells(2)
                        .Focus()

                        txtFechaAux.Visible = False
                        txtFechaAux.Location = New Point(680, 390) ' Lo reubicamos lejos de la grilla.
                    Else
                        txtFechaAux.Focus()
                    End If
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaAux.Text = ""
        End If
    End Sub
    Private Function _BuscarTerminado(ByVal terminado As String) As DataRow


        Dim SQLCnslt = "SELECT * FROM Terminado WHERE Codigo = '" & terminado.Trim() & "'"
        ' Dim resultados As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        Dim resultados As New DataTable
        Try
            resultados = GetAll(SQLCnslt, "SurfactanSa")

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Exclamation)
        End Try

        If resultados.Rows.Count > 0 Then
            Return _NormalizarFila(resultados.Rows(0))
        Else
            Return Nothing
        End If

    End Function

    Private Function _TraerNombreProducto(ByVal _Codigo As String)

        Dim SQLCnslt As String = "SELECT t.Linea, t.Descripcion, t.DescripcionIngles, p.Descripcion as DescripcionNoFarma " _
                                 & "FROM Terminado as t, Precios as p WHERE t.Codigo = '" & Trim(_Codigo) & "' " _
                                 & "AND t.Codigo = p.Terminado AND p.Cliente = '" & txt_Cliente.Text & "' ORDER BY t.Codigo"

        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        Dim WLinea = 0, WDescripcion = "", WDescripcionIng = ""

        Try


            If Row IsNot Nothing Then

                With Row

                    WLinea = IIf(IsDBNull(.Item("Linea")), 0, Val(.Item("Linea")))

                    Select Case WLinea
                        Case 10, 20, 22, 24, 25, 26, 27, 29, 30 ' Producto de Farma

                            WDescripcion = IIf(IsDBNull(.Item("Descripcion")), "", Trim(.Item("Descripcion")))
                            WDescripcionIng = IIf(IsDBNull(.Item("DescripcionIngles")), "", Trim(.Item("DescripcionIngles")))

                            If cmb_Idioma.SelectedIndex = 2 Then
                                If Trim(WDescripcionIng) = "" Then
                                    'Throw New Exception("El Código " & _Codigo & ", no posee descripción en Inglés.")

                                    If MOSTRAR_MSG_IDIOMAS Then
                                        MsgBox("El Código " & _Codigo & ", no posee descripción en Inglés.", MsgBoxStyle.Exclamation)
                                    End If

                                    Return WDescripcion
                                End If

                                Return WDescripcionIng
                            Else
                                Return WDescripcion
                            End If

                        Case Else ' Productos NO Farma

                            WDescripcion = IIf(IsDBNull(.Item("DescripcionNoFarma")), "", Trim(.Item("DescripcionNoFarma")))

                            Return WDescripcion
                            'WDescripcion = _BuscarNombreProductoPorCliente(.Item("Codigo"), txtCliente.Text)
                    End Select

                    '   WItem = .Item("Codigo") & SEPARADOR_CONSULTA & WDescripcion

                    'lstConsulta.Items.Add(WItem)

                End With

                'Loop

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally


        End Try

        Return WDescripcion
    End Function

    Private Sub dgvProductos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellEnter
        With dgvProductos
            If e.ColumnIndex = 0 Then
                .ClearSelection()
                .CurrentCell.Style.SelectionBackColor = Color.White ' Evitamos que se vea la seleccion de la celda.
                Dim _location As Point = .GetCellDisplayRectangle(0, e.RowIndex, False).Location

                _location.Y += .Location.Y + (.CurrentCell.Size.Height / 4) - YMARGEN
                _location.X += .Location.X + (.CurrentCell.Size.Width - txtFechaAux.Size.Width) - XMARGEN
                txtFechaAux.Location = _location
                txtFechaAux.Text = .Rows(e.RowIndex).Cells(0).Value
                WRow = e.RowIndex
                Wcol = e.ColumnIndex
                txtFechaAux.Visible = True
                txtFechaAux.Focus()
            End If
        End With
    End Sub
    Private Sub dgvProductos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductos.RowHeaderMouseDoubleClick
        If MsgBox("¿Seguro de que quiere eliminar el renglón correspondiente a este Producto?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        With dgvProductos.Rows(e.RowIndex)

            txtFechaAux.Clear()

            For i = 0 To .Cells.Count - 1

                .Cells(i).Value = ""

            Next

        End With

        dgvProductos.ClearSelection()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        With dgvProductos
            If .Focused Or .IsCurrentCellInEditMode Then ' Detectamos los ENTER tanto si solo estan en foco o si estan en edición una celda.
                .CommitEdit(DataGridViewDataErrorContexts.Commit) ' Guardamos todos los datos que no hayan sido confirmados.

                Dim iCol = .CurrentCell.ColumnIndex
                Dim iRow = .CurrentCell.RowIndex
                Dim valor = .CurrentCell.Value

                ' Limitamos los caracteres permitidos para cada una de las columnas.
                Select Case iCol
                    'Case 1
                    'If Not _EsNumeroOControl(keyData) Then
                    '    Return True
                    'End If
                    Case 1
                        If Not _EsDecimalOControl(keyData) Then
                            Return True
                        End If
                    Case Else

                End Select

                If msg.WParam.ToInt32() = Keys.Enter Then

                    If Val(valor) <> 0 Then

                        Select Case iCol
                            Case 2, 3
                                _RecalcularTotalFila(iRow)
                        End Select

                        _NormalizarNumerosGrilla()

                    End If

                    Select Case iCol
                        Case 3, 4
                            If iRow = PRODUCTOS_MAX - 1 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol)
                            Else
                                Try
                                    .CurrentCell = .Rows(iRow + 1).Cells(0)
                                Catch ex As Exception
                                    .CurrentCell = .Rows(iRow).Cells(iCol)
                                End Try
                            End If

                        Case Else
                            .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                    End Select

                    Return True

                ElseIf msg.WParam.ToInt32() = Keys.Escape Then


                    Select Case iCol
                        Case 0, 2, 3

                            .Rows(iRow).Cells(iCol).Value = ""

                            If iCol = 4 Then
                                .CurrentCell = .Rows(iRow).Cells(iCol - 1)
                            Else
                                .CurrentCell = .Rows(iRow).Cells(iCol + 1)
                            End If

                            .CurrentCell = .Rows(iRow).Cells(iCol)

                    End Select

                End If
            End If

        End With

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub _NormalizarNumerosGrilla()
        Dim WTotal = 0.0

        For Each row As DataGridViewRow In dgvProductos.Rows
            With row
                .Cells(2).Value = IIf(Val(.Cells(2).Value) <> 0, formatonumerico(.Cells(2).Value), "")
                .Cells(3).Value = IIf(Val(.Cells(3).Value) <> 0, formatonumerico(.Cells(3).Value), "")
                WTotal += (Val(.Cells(2).Value) * Val(.Cells(3).Value))
            End With
        Next

        txt_Total.Text = formatonumerico(WTotal)
        '_RecalcularTotal()
    End Sub

    Private Sub _RecalcularTotalFila(ByVal iRow As Integer)

        Dim WTotal = 0.0

        With dgvProductos.Rows(iRow)
            WTotal += Val(.Cells(2).Value)
            WTotal *= Val(.Cells(3).Value)

            .Cells(4).Value = formatonumerico(WTotal)
        End With

    End Sub

    Private Function _EsDecimalOControl(ByVal keycode) As Boolean
        Dim valido As Boolean = False

        If _EsDecimal(CInt(keycode)) Or _EsControl(keycode) Then
            valido = True
        Else
            valido = False
        End If

        Return valido
    End Function
    Private Function _EsDecimal(ByVal keycode As Integer) As Boolean
        Return (keycode >= 48 And keycode <= 57) Or (keycode >= 96 And keycode <= 105) Or (keycode = 110 Or keycode = 190)
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

    Private Sub txtFechaAux_DoubleClick(sender As Object, e As EventArgs) Handles txtFechaAux.DoubleClick
        If Trim(txtFechaAux.Text.Replace("-", "")) = "" Then
            ' Abrimos la Consulta de Productos que el Cliente Puede Comprar.
            With New Consulta_Terminado(txt_Cliente.Text)
                .Show(Me)
            End With
            ' btnConsulta.PerformClick()
            '  lstOpcionesConsulta.SelectedIndex = 1
            ' lstOpcionesConsulta_MouseClick(Nothing, Nothing)

        End If
    End Sub

    Public Sub PasaCodigo(Codigo As String) Implements IConsulta_Terminado.PasaCodigo
        txtFechaAux.Text = Codigo
        txtFechaAux_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub _AvisarPorEmail()

        '  If MsgBox("¿Desea avisar por Email que genero un pedido de Proforma con el NRO: " & Trim(txt_NroPedido.Text) & " a Federico Monti (fgmonti@surfactan.com.ar)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem

        '  Dim cn As SqlConnection = New SqlConnection()
        '  Dim cm As SqlCommand = New SqlCommand("")
        '  Dim trans As SqlTransaction = Nothing

        Try
            '  If wProforma.ToString.Length < 6 Then : Helper.ceros(wProforma, 6) : End If
            '
            '  cn.ConnectionString = Helper._ConectarA
            '  cn.Open()
            '  trans = cn.BeginTransaction
            '  cm.Connection = cn
            '  cm.Transaction = trans
            '
            '  cm.CommandText = "UPDATE ProformaExportacion SET AvisoPackingList = '1' WHERE Proforma = '" & wProforma & "'"
            '  cm.ExecuteNonQuery()

            oApp = New Outlook.Application()

            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = "Notificación de Pedido de Proforma (Pedido Nº: " & Trim(txt_NroPedido.Text) & ")"
            oMsg.Body = vbCrLf & vbCrLf & vbCrLf & "" & Trim(txt_Operador.Text) & " acaba de generar un pedido de Proforma " _
                        & vbCrLf & "Para el Cliente " & Trim(txt_Cliente.Text) & " " & Trim(txt_DescripcionCliente.Text) & " " _
                        & vbCrLf & "El numero de Pedido asignado es el siguiente : " & Trim(txt_NroPedido.Text)

            'WArchivoProforma = Helper._CarpetaArchivosProforma(wProforma) & "Proforma" & wProforma & ".pdf"

            'If Not File.Exists(WArchivoProforma) Then
            '    _ActualizarPDFProforma(wProforma)
            'End If

            'oMsg.Attachments.Add(WArchivoProforma)

            ' Modificar por los E-Mails que correspondan.
            oMsg.To = Configuration.ConfigurationManager.AppSettings("AVISO_PEDIDO_PROFORMA") '"soporte@surfactan.com.ar"
            'oMsg.To = "nsoto@surfactan.com.ar"

            'oMsg.Display()
            oMsg.Send()

            ' trans.Commit()

            MsgBox("Aviso Enviado correctamente a <Federico García Monti> fgmonti@surfactan.com.ar", MsgBoxStyle.Information)



        Catch ex As Exception
            'If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            Throw New Exception("No se pudo crear el E-Mail solicitado." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        End Try
        '  End If

    End Sub

    Private Sub txt_Cliente_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_Cliente.MouseDoubleClick
        With New ConsultaCliente
            .Show(Me)
        End With
    End Sub
End Class