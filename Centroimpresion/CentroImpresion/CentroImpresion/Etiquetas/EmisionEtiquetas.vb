Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EmisionEtiquetas

    Private WPartiOri As String = ""
    Private WTipoVencimiento As String = ""

    Private Sub EmisionEtiquetas_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        For Each t As TextBox In {txtDescTerminado, txtDescCliente}
            t.BackColor = WBackColorTerciario
        Next
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click

        For Each control As Control In {txtCantEtiq, txtCantidad, txtCliente, txtCodSeg, txtDescCliente, txtDescTerminado, txtLote, txtLoteMP, txtPedido, txtTara, txtTerminado, txtDesde, txtHasta}
            control.Text = ""
        Next
        For Each o As Control In {txtCantEtiq, txtCantidad, txtTara}
            o.Text = 1
        Next

        For Each control As Control In {txtCodSeg, txtPedido, lblPedido, lblCodSeg}
            control.Visible = False
        Next

        txtCantidad.Text = formatonumerico(txtCantidad.Text)
        txtTara.Text = formatonumerico(txtTara.Text)

        ckImprimeNumEtiq.Checked = False
        ckRangos.Checked = False

        ckImprimeNumEtiq_Click(Nothing, Nothing)

        cmbIdioma.SelectedIndex = 0

        txtLote.Focus()

    End Sub

    Private Sub EmisionEtiquetas_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtLote.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLote.KeyPress, txtCantEtiq.KeyPress, txtPedido.KeyPress, txtCodSeg.KeyPress, txtHasta.KeyPress, txtDesde.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCantidad.KeyPress, txtTara.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Public Sub txtLote_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLote.KeyDown

        If e.KeyData = Keys.Enter Then
            Label7.Text = ""
            If Val(txtLote.Text) = 0 Then : Exit Sub : End If

            Dim WHoja As DataRow = Nothing

            '
            ' Busco en las Empresas de Surfactan
            '
            For Each empresa As String In Empresas
                WHoja = GetSingle("SELECT h.Hoja, h.Producto Terminado, t.Descripcion FROM Hoja h INNER JOIN Terminado t ON t.Codigo = h.Producto WHERE Hoja = '" & txtLote.Text & "'", empresa)
                If WHoja IsNot Nothing Then Exit For
            Next

            If WHoja Is Nothing Then
                MsgBox("No se encuentra la Hoja de Producción indicada", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            txtTerminado.Text = WHoja.Item("Terminado")
            txtDescTerminado.Text = WHoja.Item("Descripcion")

            Label7.Text = CodigoSeguridad(txtLote.Text)

            txtCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLote.Text = ""
        End If

    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            txtDescCliente.Text = ""

            If Trim(txtCliente.Text) = "" Then
                txtCantidad.Focus()
                Exit Sub
            End If

            txtCliente.Text = txtCliente.Text.ToUpper()
            Dim WCli As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            For Each c As Control In {txtPedido, txtCodSeg, lblPedido, lblCodSeg}
                c.Visible = WCli IsNot Nothing
            Next

            If WCli Is Nothing Then Exit Sub

            txtDescCliente.Text = WCli.Item("Razon")

            txtPedido.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub txtPedido_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPedido.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPedido.Text) = "" Then : Exit Sub : End If

            Dim WPedido As DataRow = GetSingle("SELECT Pedido, Cliente FROM Pedido WHERE Pedido = '" & txtPedido.Text & "'")

            If WPedido Is Nothing Then
                MsgBox("El Pedido no existe", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If txtCliente.Text.Trim <> "" And OrDefault(WPedido.Item("Cliente"), "") <> UCase(txtCliente.Text) Then
                MsgBox("El Cliente del Pedido no se corresponde con el informado.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            txtCodSeg.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPedido.Text = ""
        End If

    End Sub

    Private Sub txtCodSeg_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodSeg.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodSeg.Text) = "" Then : Exit Sub : End If

            Dim WCodSegI As String = CodigoSeguridad(txtLote.Text)

            If WCodSegI.Trim <> txtCodSeg.Text.Trim Then
                MsgBox("Código de Seguridad Incorrecto.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            txtCantidad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodSeg.Text = ""
        End If

    End Sub

    Private Sub txtCliente_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtCliente.Enter
        txtCliente.SelectionStart = 0
        txtCliente.SelectionLength = 0
    End Sub

    Private Sub txtCliente_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCliente.MouseClick
        If txtCliente.Text.Trim = "" Then
            txtCliente.SelectionStart = 0
            txtCliente.SelectionLength = 0
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantidad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtCantidad.Text) = 0 Then : Exit Sub : End If

            txtCantEtiq.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCantidad.Text = ""
        End If

    End Sub

    Private Sub txtCantEtiq_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCantEtiq.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtCantEtiq.Text) = 0 Then : Exit Sub : End If

            txtTara.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCantEtiq.Text = ""
        End If

    End Sub

    Private Sub txtTara_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTara.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtTara.Text) = 0 Then : Exit Sub : End If

            txtTara.Text = formatonumerico(txtTara.Text)

            txtLote.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtTara.Text = ""
        End If

    End Sub



    Public Sub btnEmitir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEmitir.Click

        WPartiOri = ""
        WTipoVencimiento = ""

        If Val(txtCantidad.Text) = 0 Then txtCantidad.Text = "1"
        If Val(txtCantEtiq.Text) = 0 Then txtCantEtiq.Text = "1"
        If Val(txtTara.Text) = 0 Then txtTara.Text = "1"
        If Val(txtDesde.Text) = 0 Then txtDesde.Text = "1"
        If Val(txtHasta.Text) = 0 Then txtHasta.Text = txtCantEtiq.Text

        Dim WEtiI, WEtiII As Integer

        txtCantidad.Text = formatonumerico(txtCantidad.Text)
        txtTara.Text = formatonumerico(txtTara.Text)

        '
        ' Definimos el rango de etiquetas que enumerar.
        '
        Dim WDesdeEtiq, WHastaEtiq As String
        Dim WElaboracion, WVencimiento As String

        WDesdeEtiq = txtDesde.Text
        WHastaEtiq = txtHasta.Text

        Dim WEmpresaHoja = "SurfactanSA"
        Dim WHoja As DataRow = Nothing

        '
        ' Busco en las Empresas de Surfactan la Hoja de Producción.
        '
        For Each empresa As String In Empresas
            WHoja = GetSingle("SELECT Producto, Revalida, MesesRevalida, FechaRevalida, Fecha, Articulo, Lote1, SumaReal = isnull(Real, 0) + isnull(realant, 0) FROM Hoja WHERE Hoja = '" & txtLote.Text & "' And Renglon = 1", empresa)
            WEmpresaHoja = empresa

            If WHoja IsNot Nothing Then

                '
                ' Verifico que se encuentre actualizada por Laboratorio.
                '
                If OrDefault(WHoja.Item("SumaReal"), 0) = 0 And txtCliente.Text.Trim <> "" And OrDefault(WHoja.Item("Producto"), "") = txtTerminado.Text Then
                    MsgBox("La Hoja de Producción no ha sido aprobada por Laboratorio.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                Exit For
            End If
        Next

        '
        ' Verifico que la Hoja exista.
        '
        If WHoja Is Nothing Then
            MsgBox("La Hoja de Producción no existe.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' Verifico que el Código de Producto exista.
        '
        Dim WTer As DataRow = GetSingle("SELECT Linea, Vida, MarcaLabora, Sedronar FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'")

        If WTer Is Nothing Then
            MsgBox("El Producto indicado no existe.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim WSedronar As Byte = Val(OrDefault(WTer("Sedronar"), ""))

        Dim WCli As DataRow = GetSingle("SELECT Cliente, Razon, ImpreVto, Provincia, Idioma, EtiI, EtiII, DirEntrega FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")
        Dim WCodSegI As String = CodigoSeguridad(txtLote.Text)

        Dim IdEmpresa As Integer = Helper._IdEmpresaSegunBase(WEmpresaHoja)

        '
        ' Comprobamos los datos para el Cliente, en caso de que se haya definido uno.
        '
        If txtCliente.Text.Trim <> "" Then

            If WCli Is Nothing Then
                MsgBox("El Cliente Informado no existe.")
                Exit Sub
            End If

            If Helper.Left(txtTerminado.Text, 2).ToUpper = "SE" Then
                MsgBox("No se puede emitir etiquetas SE a un Cliente.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If (Val(txtLote.Text) > 216400 And Val(txtLote.Text) < 299999) Or (Val(txtLote.Text) > 108000 And Val(txtLote.Text) < 199999 And True) Then
                If WCodSegI <> txtCodSeg.Text.Trim Then
                    MsgBox("El Código de Seguridad no es correcto.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If

        End If

        '
        ' Comprobamos que se hayan cargado los datos de Peligrosidad.
        '
        Dim WClavePelig = ""
        Dim WClaveProd = ""

        WClaveProd = Helper.Left(txtTerminado.Text, 2).ToUpper()

        If WClaveProd = "SE" Then

            WClavePelig = "SE" & Mid(txtTerminado.Text, 3, 10) & "001"

        ElseIf WClaveProd.StartsWith("Y") Then

            WClavePelig = Mid(txtTerminado.Text, 1, 10) & "001"
            WClaveProd = Helper.Left(txtTerminado.Text, 2)

        Else

            WClavePelig = "PT" & Mid(txtTerminado.Text, 3, 10) & "001"
            WClaveProd = "PT"

        End If

        '
        ' En caso de no encontrar los datos en las etiquetas con la clave generada, me fijo que en caso de ser terminado un RE pudo haber venido de un SE, por lo que lo busco por su SE respectivo.
        '
        Dim WDatosEtiqExisten As DataRow = GetSingle("SELECT Clave FROM DatosEtiqueta WHERE Clave = '" & WClavePelig & "'")

        If WDatosEtiqExisten Is Nothing And txtTerminado.Text.StartsWith("RE") Then

            WClavePelig = "SE" & Mid(txtTerminado.Text, 3, 10) & "001"
            WDatosEtiqExisten = GetSingle("SELECT Clave FROM DatosEtiqueta WHERE Clave = '" & WClavePelig & "'")

            If WDatosEtiqExisten Is Nothing Then
                MsgBox("No se encuentran cargados los datos adicionales de peligrosidad.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

        End If


        WEtiI = 0
        WEtiII = 0

        If WCli IsNot Nothing Then
            If OrDefault(WCli.Item("Idioma"), 0) = 1 Then cmbIdioma.SelectedIndex = 1
            WEtiI = OrDefault(WCli.Item("EtiI"), 0)
            WEtiII = OrDefault(WCli.Item("EtiII"), 0)
        End If

        Dim WTipoPro = "PT"
        Dim Auxi As String = Mid(txtTerminado.Text, 4, 5)

        If Not txtTerminado.Text.StartsWith("PT") Then
            Select Case Helper.Left(txtTerminado.Text, 2)
                Case "DY", "DS"
                    WTipoPro = "CO"
                Case "QC", "YF"
                    WTipoPro = "FA"
                Case "YQ", "YH", "YP"
                    WTipoPro = "PT"
            End Select
        Else
            If (Val(Auxi) > 0 And Val(Auxi) < 999) Or (Val(Auxi) > 11000 And Val(Auxi) < 12999) Then
                WTipoPro = "CO"
            ElseIf Val(Auxi) > 25000 And Val(Auxi) < 25999 Then
                WTipoPro = "FA"
            ElseIf Val(Auxi) > 2300 And Val(Auxi) < 2399 Then
                WTipoPro = "BI"
            End If
        End If

        Dim WLinea As Integer = OrDefault(WTer.Item("Linea"), 0)

        If (Auxi >= 25000 And Auxi <= 25999) Or {10, 20, 22, 24, 25, 26, 27, 28, 29, 30}.Contains(WLinea) Then
            WTipoPro = "FA"
        End If

        Dim WDireccionEntrega = ""
        Dim WOrdenCPA = ""

        If txtCliente.Text.Trim <> "" Then

            '
            ' Busco en caso de que se trate de un producto de Colorantes (CO) y se haya cargado un Cliente los datos de Entrega según el Pedido.
            '
            If WTipoPro = "CO" Then
                Dim WPedido As DataRow = GetSingle("SELECT * FROM Pedido WHERE Pedido WHERE Pedido = '" & txtPedido.Text & "'")

                '
                ' Compruebo que el Pedido exista.
                '
                If WPedido Is Nothing Then
                    MsgBox("El pedido indicado no existe.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                '
                ' Que el Cliente del Pedido se corresponda con le que indicó el Usuario.
                '
                If txtCliente.Text.Trim <> OrDefault(WPedido.Item("Cliente"), "") Then
                    MsgBox("El Cliente indicado no se corresponde con el informado en el Pedido.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                '
                ' Extraigo OrdenCPA y en que Direccion de entrega del Cliente se hará.
                '
                Dim WIndiceDireEntrega As Integer = OrDefault(WPedido.Item("DirEntrega"), 1)

                WOrdenCPA = OrDefault(WPedido.Item("OrdenCPA"), 1)

                If WIndiceDireEntrega = 1 Then
                    WDireccionEntrega = OrDefault(WCli.Item("DirEntrega"), "")
                End If

            End If

            '
            ' Verifico que a un Cliente únicamente se le emitan etiquetas de PT e Y's.
            '
            If Not txtTerminado.Text.StartsWith("PT") And Not txtTerminado.Text.StartsWith("Y") Then
                MsgBox("Solo se puede emitir etiqietas a productos PT.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

        End If

        '
        ' Buscamos si el Producto Terminado, tienen tiempo de Vida Útil.
        '
        Dim WMarcaLabora As String = OrDefault(WTer.Item("MarcaLabora"), "")
        Dim WMeses As Integer = OrDefault(WTer.Item("Vida"), 0)
        Dim WRevalida, WMesesRevalida, WFechaRevalida, WFechaHoja, WOrdVto, WFechaActual, WFechaActualOrd, WMarcaVencida As String
        Dim WVida, WMes, WAnio As Integer

        WFechaActual = Date.Now.ToString("dd/MM/yyyy")
        WFechaActualOrd = ordenaFecha(WFechaActual)
        WMarcaVencida = ""

        '
        ' Si se definió un tiempo de vida, se verifican vencimientos y limites de vida útil.
        '
        'If WMeses <> 0 Then

        With WHoja
            WRevalida = OrDefault(.Item("Revalida"), "")
            WMesesRevalida = OrDefault(.Item("MesesRevalida"), "0")
            WFechaRevalida = OrDefault(.Item("FechaRevalida"), "00/00/0000")
            WFechaHoja = OrDefault(.Item("Fecha"), "")
        End With

        '
        ' Verificamos el 75% de vida útil.
        '
        If Val(WRevalida) <> 0 Then
            WVida = CInt(Val(WMesesRevalida) * 0.75)
            WMes = Mid(WFechaRevalida, 4, 2)
            WAnio = Helper.Right(WFechaRevalida, 4)
        Else
            WVida = CInt(Val(WMeses) * 0.75)
            WMes = Mid(WFechaHoja, 4, 2)
            WAnio = Helper.Right(WFechaHoja, 4)
        End If

        For Ciclo = 1 To WVida
            WMes = WMes + 1
            If WMes > 12 Then
                WAnio = WAnio + 1
                WMes = 1
            End If
        Next

        WOrdVto = WAnio & WMes.ToString.PadLeft(2, "0") & "01"

        If Val(WOrdVto) < Val(WFechaActualOrd) Then
            WMarcaVencida = "S"
        End If

        '
        ' Verificamos el 100% de vida útil.
        '
        If Val(WRevalida) <> 0 Then
            WVida = CInt(Val(WMesesRevalida))
            WMes = Mid(WFechaRevalida, 4, 2)
            WAnio = Helper.Right(WFechaRevalida, 4)
        Else
            WVida = CInt(Val(WMeses))
            WMes = Mid(WFechaHoja, 4, 2)
            WAnio = Helper.Right(WFechaHoja, 4)
        End If

        For Ciclo = 1 To WVida
            WMes = WMes + 1
            If WMes > 12 Then
                WAnio = WAnio + 1
                WMes = 1
            End If
        Next

        WOrdVto = WAnio & WMes.ToString.PadLeft(2, "0") & "01"

        If Val(WVida) <> 0 Then WVencimiento = "01" & "/" & WMes.ToString.PadLeft(2, "0") & "/" & WAnio.ToString.PadLeft(4, "0")

        If Val(WOrdVto) < Val(WFechaActualOrd) Then
            WMarcaVencida = "V"
        End If
        '
        'End If

        If Val(WMeses) <> 0 Then

            '
            ' Verificamos si se encuentra en sus 75% de vida útil.
            '
            If WMarcaVencida = "S" Then

                If WTipoPro <> "FA" Then
                    MsgBox("La Partida ya paso mas del 75% de su vida util" + Chr(13) + _
                            "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("ATENCION : La Partida ya paso mas del 75% de su vida util." + Chr(13) + _
                            "Puede ser Bloqueada su facturación por AC", MsgBoxStyle.Exclamation)
                End If

                If txtCliente.Text.Trim <> "" Then Exit Sub

            End If

            '
            ' Verificamos si se encuentra en su 100% de vida útil.
            '
            If WMarcaVencida = "V" Then
                MsgBox("La Partida se encuentra vencida " + Chr(13) + _
                 "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

        End If

        '
        ' Busco la información general del Producto Terminado.
        '
        Dim WTerGral As DataRow = GetSingle("SELECT Descripcion, DescriEtiqueta, Conservacion, ConservacionII, CodRNPA, DescripcionIngles, DescriEtiquetaIngles, ConservacionIngles, ConservacionIIIngles, ImpreAdi, Clase, Riesgo, Intervencion, Naciones, Embalaje, DescriOnu, TipoEti FROM Terminado wHERE Codigo = '" & txtTerminado.Text & "'")

        Dim WDescripcion, WDEscriEtiqueta, WConservacion, WConservacionII, WImpreAdi, WClase, WRiesgo, WIntervencion, WNaciones, WEmbalaje, WDescriOnu, WTipoEti, WObservaciones, WDescripcionFarma, WCodRNPA As String

        WDescripcion = ""

        If WTerGral IsNot Nothing Then
            With WTerGral

                If cmbIdioma.SelectedIndex = 0 Then

                    WDEscriEtiqueta = OrDefault(.Item("DescriEtiqueta"), "")
                    WConservacion = OrDefault(.Item("Conservacion"), "")
                    WConservacionII = OrDefault(.Item("ConservacionII"), "")

                    WDescripcion = ""

                    If {5, 11}.Contains(IdEmpresa) Then
                        WDescripcion = OrDefault(.Item("Descripcion"), "")
                    End If

                Else

                    WDEscriEtiqueta = OrDefault(.Item("DescriEtiquetaIngles"), "")
                    WConservacion = OrDefault(.Item("ConservacionIngles"), "")
                    WConservacionII = OrDefault(.Item("ConservacionIIIngles"), "")

                    WDescripcion = ""

                    If {5, 11}.Contains(IdEmpresa) Then

                        WDescripcion = Trim(OrDefault(.Item("Descripcion"), "")) & " - " & Trim(WDEscriEtiqueta)

                    End If

                End If

                WDescripcionFarma = Trim(WDEscriEtiqueta)
                WImpreAdi = OrDefault(.Item("ImpreAdi"), "")
                WClase = OrDefault(.Item("Clase"), "")
                WRiesgo = OrDefault(.Item("Riesgo"), "")
                WIntervencion = OrDefault(.Item("Intervencion"), "")
                WNaciones = OrDefault(.Item("Naciones"), "")
                WEmbalaje = OrDefault(.Item("Embalaje"), "")
                WDescriOnu = OrDefault(.Item("DescriOnu"), "")
                WTipoEti = OrDefault(.Item("TipoEti"), "")
                WCodRNPA = OrDefault(.Item("CodRNPA"), "")

            End With
        End If

        '
        ' Buscamos los nombres de los Productos que se pudieron definir para el Cliente particular.
        '
        Dim WPrecios As DataRow = GetSingle("SELECT Descripcion, DescripcionFarma FROM Precios WHERE Clave = '" & txtCliente.Text & txtTerminado.Text & "'")
        Dim WDescriPrecio = ""

        If WPrecios IsNot Nothing Then
            With WPrecios

                If IdEmpresa = 5 Or IdEmpresa = 11 Then
                    WDescriPrecio = Trim(OrDefault(.Item("DescripcionFarma"), ""))
                Else
                    WDescripcion = Trim(OrDefault(.Item("Descripcion"), ""))
                End If

            End With
        End If

        '
        ' Determinamos si la Hoja de Producción, se trata de una mezcla y guardamos el Lote mas antiguo para la validación de Vencimiento posterior.
        '
        Dim WMezcla, WMezclaPartida, WMezclaCodTerminado As String

        WMezcla = "S"
        WMezclaPartida = "999999"
        WMezclaCodTerminado = ""

        Dim WHojaComposicion As DataTable = GetAll("SELECT * FROM Hoja WHERE Hoja = '" & txtLote.Text & "' Order by Renglon", WEmpresaHoja)

        For Each row As DataRow In WHojaComposicion.Rows
            With row

                WElaboracion = OrDefault(.Item("Fecha"), "")

                If Helper.Left(OrDefault(.Item("Terminado"), ""), 8) <> Helper.Left(OrDefault(.Item("Producto"), ""), 8) Then
                    WMezcla = "N"
                Else
                    Dim WLote1, WLote2, WLote3 As String

                    WLote1 = OrDefault(.Item("Lote1"), "")
                    WLote2 = OrDefault(.Item("Lote2"), "")
                    WLote3 = OrDefault(.Item("Lote3"), "")

                    If Val(WLote1) < Val(WMezclaPartida) And Val(WLote1) <> 0 Then

                        WMezclaPartida = WLote1
                        WMezclaCodTerminado = OrDefault(.Item("Terminado"), "")

                    ElseIf Val(WLote2) < Val(WMezclaPartida) And Val(WLote2) <> 0 Then

                        WMezclaPartida = WLote2
                        WMezclaCodTerminado = OrDefault(.Item("Terminado"), "")

                    ElseIf Val(WLote3) < Val(WMezclaPartida) And Val(WLote3) <> 0 Then

                        WMezclaPartida = WLote3
                        WMezclaCodTerminado = OrDefault(.Item("Terminado"), "")

                    End If

                End If

            End With
        Next


        If WTipoPro = "FA" Then

            If WMezcla = "S" And IdEmpresa = 5 Then

                If Val(WMezclaPartida) = 999999 Then
                    MsgBox("Es una Hoja de produccion de mezcla y no se informaron las partidas a utilizar")
                    Exit Sub
                End If

                '
                ' Verifico la fecha de vencimiento de la hoja mas antigua.
                '
                Dim WHojaMezcla As DataRow = GetSingle("SELECT Fecha, Revalida, MesesRevalida, FechaRevalida FROM Hoja WHERE Hoja = '" & WMezclaPartida & "' And Producto = '" & WMezclaCodTerminado & "' And Renglon = 1", WEmpresaHoja)

                If WHojaMezcla IsNot Nothing Then

                    With WHojaMezcla

                        Dim WFechaAuxi As String = OrDefault(.Item("Fecha"), "00/00/0000")

                        Dim WMesMezcla As Integer = Val(Mid(WFechaAuxi, 4, 2))
                        Dim WAnioMezcla As Integer = Val(Helper.Left(WFechaAuxi, 4))
                        Dim WVidaMezcla As Integer = WVida

                        Dim WRevalidaMezcla As Integer = OrDefault(.Item("Revalida"), 0)
                        Dim WMesesRevalidaMezcla As Integer = OrDefault(.Item("MesesRevalida"), 0)
                        Dim WFechaRevalidaMezcla As String = OrDefault(.Item("FechaRevalida"), "00/00/0000")

                        If WRevalidaMezcla <> 0 Then
                            WMesMezcla = Mid(WFechaRevalidaMezcla, 4, 2)
                            WAnioMezcla = Helper.Left(WFechaRevalidaMezcla, 4)
                            WVidaMezcla = WMesesRevalidaMezcla
                        End If

                        WElaboracion = WFechaAuxi

                        For Ciclo = 1 To WVidaMezcla
                            WMesMezcla += 1
                            If WMesMezcla > 12 Then
                                WAnioMezcla += 1
                                WMesMezcla = 1
                            End If
                        Next Ciclo

                        If Val(WVidaMezcla) <> 0 Then WVencimiento = "01" & "/" & WMesMezcla.ToString.PadLeft(2, "0") & "/" & WAnioMezcla.ToString.PadLeft(4, "0")

                    End With
                End If

            End If

        End If

        '
        ' Calculamos las Fechas de Elaboración y Vencimiento del Mono Componente.
        '

        Dim WDatosMono() As String = _CalculaMonoOtro(txtLote.Text, WEmpresaHoja)

        If WTipoPro = "FA" Then

            If WDatosMono(0) <> "-1" Or WDatosMono(1) <> "-1" Then

                '
                ' Verificamos si se trata de un Mono Producto.
                '
                Dim WBuscaMono As DataRow = GetSingle("SELECT Codigo FROM CodigoMono WHERE Codigo = '" & txtTerminado.Text & "'")

                If WBuscaMono IsNot Nothing Or WLinea = 20 Or WLinea = 28 Then

                    If Trim(WDatosMono(0)) <> "" Then
                        WElaboracion = WDatosMono(0)
                    End If

                    If Trim(WDatosMono(1)) <> "" Then
                        WVencimiento = WDatosMono(1)
                    End If

                    If WVencimiento <> "" Then
                        If Val(ordenaFecha(WVencimiento)) < Val(WFechaActualOrd) Then
                            MsgBox("La Partida se encuentra vencida " + Chr(13) + _
                 "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    End If

                End If
            End If

        Else

            WElaboracion = ""

            If Trim(WDatosMono(1)) <> "" AndAlso Trim(WDatosMono(1)) <> "-1" Then
                WVencimiento = WDatosMono(1)
            End If

            If WVencimiento <> "" Then
                If Val(ordenaFecha(WVencimiento)) < Val(WFechaActualOrd) Then
                    MsgBox("La Partida se encuentra vencida " + Chr(13) + _
         "Por favor comuniquese con el laboratorio para su revalida", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If

        End If


        Dim WTara As Double = Val(formatonumerico(txtTara.Text))
        Dim WNeto As Double = Val(formatonumerico(txtCantidad.Text))
        Dim WBruto As Double = 0

        If WTara = 0 Then
            If WTipoPro = "FA" Then WBruto = WNeto
        Else
            WBruto = WTara + WNeto
        End If

        Dim WRazon, WRazonFarma, WImpreVto, WProvincia As String

        WRazon = ""
        WRazonFarma = ""
        WImpreVto = ""
        WProvincia = ""

        If WCli IsNot Nothing Then
            With WCli
                WRazon = OrDefault(.Item("Razon"), "")
                WRazonFarma = OrDefault(.Item("Razon"), "")
                WImpreVto = OrDefault(.Item("ImpreVto"), "")
                WProvincia = OrDefault(.Item("Provincia"), "")

                If Trim(WRazon) <> "" Then WRazon = "Cliente:  " & WRazon
                If Trim(WRazonFarma) <> "" Then WRazonFarma = "Cliente:  " & WRazonFarma

                If cmbIdioma.SelectedIndex = 1 Then
                    WRazon = WRazon.Replace("Cliente", "Client")
                    WRazonFarma = WRazonFarma.Replace("Cliente", "Client")
                End If

                WRazon = Helper.Left(Trim(WRazon), 50)
                WRazonFarma = Trim(WRazonFarma)

            End With
        End If

        Dim WNombreLargo As String = ""

        If WDescripcion.Trim.Length > 50 Then WNombreLargo = WDescripcion.Trim

        WDescripcion = Helper.Left(WDescripcion.Trim, 50)

        Dim WNombreI, WNombreII, WNombreIII As String
        Dim Wlargo, WLimiteI, WLimiteII As Integer

        WNombreI = ""
        WNombreII = ""
        WNombreIII = ""

        Wlargo = WDescripcion.Length
        WLimiteI = 15
        WLimiteII = 23

        If WTipoPro = "FA" Then
            WLimiteI = 17
            WLimiteII = 30
        End If

        If Wlargo < WLimiteI Then

            WNombreI = WDescripcion

        ElseIf Wlargo <= WLimiteII Then

            WNombreII = WDescripcion

        Else
            WNombreIII = WDescripcion
        End If


        Dim WRazonI, WRazonII, WRazonIII As String

        Wlargo = WRazon.Length

        WLimiteII = 25

        If WTipoPro = "FA" Then WLimiteII = 35

        If Wlargo < 20 Then

            WRazonI = WRazon

        ElseIf Wlargo <= WLimiteII Then

            WRazonII = WRazon

        Else
            WRazonIII = WRazon
        End If


        If Val(WProvincia) = 24 Then
            WObservaciones = "Hecho en Argentina"
            If cmbIdioma.SelectedIndex = 1 Then WObservaciones = "Made in Argentina"
        End If

        Dim WLugarImpreI, WLugarImpreII, WLugarImpreIII As Integer
        Dim WImpreI(999), WImpreII(999), WImpreIII(999), WPalabra, WLogo(9) As String

        WLugarImpreI = 0
        WLugarImpreII = 0
        WLugarImpreIII = 0

        For i = 0 To 999
            WImpreI(i) = ""
            WImpreII(i) = ""
            WImpreIII(i) = ""
        Next

        For i = 0 To 9
            WLogo(i) = ""
        Next

        For i = 1 To 999
            Dim WDatosEtiquetas As DataTable = GetAll("SELECT Palabra, Tipo, Pictograma1, Pictograma2, Pictograma3, Pictograma4, Pictograma5, Pictograma6, Pictograma7, Pictograma8, Pictograma9, " _
                                                      & " Descripcion1h, Descripcion2h, Descripcion3h, Descripcion1p, Descripcion2p, Descripcion3p, Observaciones, Denominacion FROM DatosEtiqueta WHERE Clave = '" & WClaveProd & Mid(txtTerminado.Text, 3, 10) & i.ToString.PadLeft(3, "0") & "'")

            For Each row As DataRow In WDatosEtiquetas.Rows
                With row
                    WPalabra = OrDefault(.Item("Palabra"), "")

                    For x = 1 To 9
                        WLogo(x) = OrDefault(.Item("Pictograma" & x), "0")
                    Next

                    Dim WTipo As Integer = OrDefault(.Item("Tipo"), 0)


                    Select Case WTipo
                        Case 1

                            Dim WImpreAuxi As String = OrDefault(.Item("Descripcion1h"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreI += 1
                                WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion2h"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreI += 1
                                WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion3h"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreI += 1
                                WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                            End If

                        Case 2

                            Dim WImpreAuxi As String = OrDefault(.Item("Descripcion1p"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion2p"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Descripcion3p"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                            WImpreAuxi = OrDefault(.Item("Observaciones"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreII += 1
                                WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                            End If

                        Case 3

                            Dim WImpreAuxi As String = OrDefault(.Item("Denominacion"), "")

                            If WImpreAuxi <> "" Then
                                WLugarImpreIII += 1
                                WImpreIII(WLugarImpreIII) = Trim(WImpreAuxi)
                            End If

                    End Select

                End With
            Next

            If WDatosEtiquetas.Rows.Count = 0 Then Exit For

        Next

        If cmbIdioma.SelectedIndex = 1 Then
            For i = 1 To 999
                Dim WDatosEtiquetas As DataTable = GetAll("SELECT Descripcion1hIngles, Descripcion2hIngles, Descripcion3hIngles, Descripcion1pIngles, Descripcion2pIngles, Descripcion3pIngles, Tipo FROM DatosEtiquetaIngles WHERE Clave = '" & WClaveProd & Mid(txtTerminado.Text, 3, 10) & i.ToString.PadLeft(3, "0") & "'")

                For Each row As DataRow In WDatosEtiquetas.Rows
                    With row

                        Dim WTipo As Integer = OrDefault(.Item("Tipo"), 0)

                        Select Case WTipo
                            Case 4

                                Dim WImpreAuxi As String = OrDefault(.Item("Descripcion1hIngles"), "")

                                If WImpreAuxi <> "" Then
                                    WLugarImpreI += 1
                                    WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                                End If

                                WImpreAuxi = OrDefault(.Item("Descripcion2hIngles"), "")

                                If WImpreAuxi <> "" Then
                                    WLugarImpreI += 1
                                    WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                                End If

                                WImpreAuxi = OrDefault(.Item("Descripcion3hIngles"), "")

                                If WImpreAuxi <> "" Then
                                    WLugarImpreI += 1
                                    WImpreI(WLugarImpreI) = Trim(WImpreAuxi)
                                End If

                            Case 5

                                Dim WImpreAuxi As String = OrDefault(.Item("Descripcion1pIngles"), "")

                                If WImpreAuxi <> "" Then
                                    WLugarImpreII += 1
                                    WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                                End If

                                WImpreAuxi = OrDefault(.Item("Descripcion2pIngles"), "")

                                If WImpreAuxi <> "" Then
                                    WLugarImpreII += 1
                                    WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                                End If

                                WImpreAuxi = OrDefault(.Item("Descripcion3pIngles"), "")

                                If WImpreAuxi <> "" Then
                                    WLugarImpreII += 1
                                    WImpreII(WLugarImpreII) = Trim(WImpreAuxi)
                                End If

                        End Select

                    End With
                Next

                If WDatosEtiquetas.Rows.Count = 0 Then Exit For

            Next
        End If

        '
        ' Formateo las Frases. (Se copia exactamente como se encontraba en el sistema viejo.
        '
        Dim ZZImpreFrase(99) As String
        Dim LugarFrase = 1
        Dim ZZCorte As Integer = 115
        Dim ZZHastaII, ZZHastaIII As Integer

        If WTipoPro <> "CO" Then
            ZZCorte = 185
        End If

        Dim ZZEntraVarios As String = "N"

        For Ciclo = 1 To 99

            If Trim(WImpreIII(Ciclo)) <> "" Then

                ZZEntraVarios = "S"
                ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Trim(WImpreIII(Ciclo)) + " "

                If Len(ZZImpreFrase(LugarFrase)) > ZZCorte Then

                    Do

                        ZZHastaIII = Len(ZZImpreFrase(LugarFrase))

                        ZZHastaII = Len(ZZImpreFrase(LugarFrase))
                        For Da = 1 To ZZHastaIII
                            If Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                                ZZHastaII = ZZHastaII + 0.5
                            End If
                        Next Da

                        If ZZHastaII > ZZCorte Then

                            For Da = ZZHastaIII - 1 To 1 Step -1
                                If Mid$(ZZImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "/" Then

                                    Auxi = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                    ZZHastaIII = Len(Auxi)
                                    ZZHastaII = 0
                                    For DaIII = 1 To ZZHastaIII
                                        ZZHastaII = ZZHastaII + 1
                                        If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                            ZZHastaII = ZZHastaII + 0.5
                                        End If
                                    Next DaIII
                                    If ZZHastaII <= ZZCorte Then
                                        Auxi = ZZImpreFrase(LugarFrase)
                                        ZZImpreFrase(LugarFrase) = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                        LugarFrase = LugarFrase + 1
                                        ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, ZZCorte)
                                        Exit For
                                    End If

                                End If
                            Next Da

                        Else

                            Exit Do

                        End If
                    Loop

                End If
            End If

        Next Ciclo

        If ZZEntraVarios = "S" Then
            LugarFrase = LugarFrase + 1
        End If

        '
        ' Formateo las Frases H. Se copia exactamente como se encontraba en el sistema viejo.
        '
        Dim ZZEntraH As String = "N"

        For Ciclo = 1 To 99

            If Trim(WImpreI(Ciclo)) <> "" Then

                If ZZEntraH = "N" Then
                    If cmbIdioma.SelectedIndex = 0 Then
                        ZZImpreFrase(LugarFrase) = "INDICACIONES DE PELIGRO : "
                    Else
                        ZZImpreFrase(LugarFrase) = "INDICATIONS OF DANGER : "
                    End If
                End If
                ZZEntraH = "S"
                ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Trim(WImpreI(Ciclo)) + " "

                Do

                    ZZHastaIII = Len(ZZImpreFrase(LugarFrase))

                    ZZHastaII = Len(ZZImpreFrase(LugarFrase))
                    For Da = 1 To ZZHastaIII
                        If Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                            ZZHastaII = ZZHastaII + 0.5
                        End If
                    Next Da

                    If ZZHastaII > ZZCorte Then

                        For Da = ZZHastaIII - 1 To 1 Step -1
                            If Mid$(ZZImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "/" Then

                                Auxi = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                ZZHastaIII = Len(Auxi)
                                ZZHastaII = 0
                                For DaIII = 1 To ZZHastaIII
                                    ZZHastaII = ZZHastaII + 1
                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                        ZZHastaII = ZZHastaII + 0.5
                                    End If
                                Next DaIII
                                If ZZHastaII <= ZZCorte Then
                                    Auxi = ZZImpreFrase(LugarFrase)
                                    ZZImpreFrase(LugarFrase) = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                    LugarFrase = LugarFrase + 1
                                    ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, ZZCorte)
                                    Exit For
                                End If

                            End If
                        Next Da

                    Else

                        Exit Do

                    End If
                Loop
            End If

        Next Ciclo

        If ZZEntraH = "S" Then
            LugarFrase = LugarFrase + 1
        End If

        '
        ' Formateo las frases P. Se copia exactamente como se encontraba en el sistema viejo.
        '
        Dim ZZEntraP As String = "N"

        For Ciclo = 1 To 99

            If Trim(WImpreII(Ciclo)) <> "" Then

                If ZZEntraP = "N" Then
                    If cmbIdioma.SelectedIndex = 0 Then
                        ZZImpreFrase(LugarFrase) = "DECLARACIONES DE PRUDENCIA : "
                    Else
                        ZZImpreFrase(LugarFrase) = "PRUDENCE STATEMENTS : "
                    End If
                End If
                ZZEntraP = "S"
                ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Trim(WImpreII(Ciclo)) + " "

                Do

                    ZZHastaIII = Len(ZZImpreFrase(LugarFrase))

                    ZZHastaII = Len(ZZImpreFrase(LugarFrase))
                    For Da = 1 To ZZHastaIII
                        If Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) >= 65 And Asc(Mid$(ZZImpreFrase(LugarFrase), Da, 1)) <= 90 Then
                            ZZHastaII = ZZHastaII + 0.5
                        End If
                    Next Da

                    If ZZHastaII > ZZCorte Then

                        For Da = ZZHastaIII - 1 To 1 Step -1
                            If Mid$(ZZImpreFrase(LugarFrase), Da, 1) = Space$(1) Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "-" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "+" Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "," Or Mid$(ZZImpreFrase(LugarFrase), Da, 1) = "/" Then

                                Auxi = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                ZZHastaIII = Len(Auxi)
                                ZZHastaII = 0
                                For DaIII = 1 To ZZHastaIII
                                    ZZHastaII = ZZHastaII + 1
                                    If Asc(Mid$(Auxi, DaIII, 1)) >= 65 And Asc(Mid$(Auxi, DaIII, 1)) <= 90 Then
                                        ZZHastaII = ZZHastaII + 0.5
                                    End If
                                Next DaIII
                                If ZZHastaII <= ZZCorte Then
                                    Auxi = ZZImpreFrase(LugarFrase)
                                    ZZImpreFrase(LugarFrase) = Mid$(ZZImpreFrase(LugarFrase), 1, Da)
                                    LugarFrase = LugarFrase + 1
                                    ZZImpreFrase(LugarFrase) = ZZImpreFrase(LugarFrase) + Mid$(Auxi, Da + 1, ZZCorte)
                                    Exit For
                                End If

                            End If
                        Next Da

                    Else

                        Exit Do

                    End If
                Loop
            End If

        Next Ciclo

        '
        ' YA TERMINADO PROCESAMIENTO DE DATOS PARA LAS ETIQUETAS, SIGO CON LA GRABACIÓN DE LOS DATOS EN LAS TABLAS TEMPORALES PARA LA IMPRESION DE ETIQUETAS.
        '

        Dim WBuscaMonoII As DataRow = GetSingle("SELECT Codigo, Tipo FROM CodigoMono WHERE Codigo = '" & txtTerminado.Text & "'")

        Dim WEsMonoProd As Boolean = Not IsNothing(WBuscaMonoII)
        Dim WPasaMono As Integer = 0

        If Not IsNothing(WBuscaMonoII) Then WPasaMono = IIf(OrDefault(WBuscaMonoII.Item("Tipo"), 0) = 0, 1, 2)

        '
        ' Grabamos los datos en EtiquetaII.
        '
        Dim WEtiquetaII As DataTable = New DBAuxi.EtiquetaDataTable

        For i = 1 To Val(txtCantEtiq.Text)

            Dim _r As DataRow = WEtiquetaII.NewRow

            With _r

                .Item("Codigo") = i
                .Item("Terminado") = txtTerminado.Text
                .Item("Lote") = txtLote.Text
                .Item("Cliente") = txtCliente.Text
                .Item("Cantidad") = Val(formatonumerico(txtCantidad.Text))
                .Item("Nombre") = IIf(WNombreLargo = "", WNombreI, "")
                .Item("NombreII") = IIf(WNombreLargo = "", WNombreII, "")
                .Item("NombreIII") = IIf(WNombreLargo = "", WNombreIII, "")
                .Item("Impre2") = ""
                .Item("ImpreDirEntrega") = ""

                If Trim(WPartiOri) <> "" Then
                    .Item("Impre2") = Helper.Left(WPartiOri, 30)
                    .Item("ImpreDirEntrega") = Helper.Left(WPartiOri, 30)
                End If

                .Item("Razon") = WRazonI
                .Item("RazonII") = WRazonII
                .Item("RazonIII") = WRazonIII
                .Item("Clase") = WClase
                .Item("Intervencion") = WIntervencion
                .Item("DescriOnu") = WDescriOnu
                .Item("Naciones") = WNaciones
                .Item("Embalaje") = WEmbalaje
                .Item("Bruto") = WBruto
                .Item("Tara") = WTara
                .Item("Neto") = WNeto
                .Item("Observaciones") = WObservaciones
                .Item("Elaboracion") = Helper.Right(WElaboracion, 7)
                .Item("Vencimiento") = Helper.Right(WVencimiento, 7)

                If WTipoPro = "FA" And WMezcla <> "S" And Val(WRevalida) <> 0 Then
                    .Item("Revalida") = "(Rev.:" & Trim(WRevalida) & ")"
                End If

                .Item("Conservacion") = WConservacionII
                .Item("ConservacionII") = WConservacionII

                If Val(txtPedido.Text) <> 0 Then
                    .Item("Conservacion") = WConservacion
                End If

                If WTipoPro = "FA" Then
                    If Trim(WCodRNPA) <> "" Then
                        .Item("Conservacion") = "RNE:02-035.078     RNPA:" + Trim(WCodRNPA)
                    Else
                        .Item("Conservacion") = ""
                    End If

                    If WPasaMono = 0 Or Not _EsFazon(txtTerminado.Text) Then
                        WTipoVencimiento = ""
                    End If
                    If Val(WMarcaLabora) = 0 Then

                        .Item("Impre1") = "Codigo: " + Mid(txtTerminado.Text, 4, 5) + Helper.Right(txtTerminado.Text, 3) +
                                          "   Partida: " + txtLote.Text.PadLeft(6, "0")
                    Else
                        .Item("Impre1") = "Codigo: " + Mid(txtTerminado.Text, 4, 5) + Helper.Right(txtTerminado.Text, 3) +
                                          "  (F)   Partida: " + txtLote.Text.PadLeft(6, "0")
                    End If

                    If cmbIdioma.SelectedIndex = 1 Then
                        .Item("Impre1") = .Item("Impre1").ToString.Replace("Codigo", "Code")
                        .Item("Impre1") = .Item("Impre1").ToString.Replace("Partida", "Batch")
                    End If

                    .Item("NombreFarmaII") = WDescripcionFarma
                    .Item("NombreFarmaI") = WDescriPrecio

                Else

                    If Trim(txtCliente.Text) <> "" Then

                        .Item("Impre1") = "Codigo: " & Mid(txtTerminado.Text, 4, 5) & Helper.Right(txtTerminado.Text, 3) & "   " + txtLote.Text.PadLeft(6, "0")

                    Else
                        .Item("Impre1") = Mid(txtTerminado.Text, 4, 5) & Helper.Right(txtTerminado.Text, 3) & ""
                        .Item("NombreFarmaI") = txtLote.Text.PadLeft(6, "0")
                    End If

                End If

                .Item("TipoPro") = ""

                If Trim(txtCliente.Text) = "" Then
                    .Item("TipoPro") = Helper.Left(txtTerminado.Text, 2)
                End If

                Dim ZFazon = "N"

                Select Case Val(WLinea)
                    Case 3, 4, 5, 7, 8, 9, 11, 12, 14, 19, 22
                        ZFazon = "N"
                    Case 6, 16, 17
                        ZFazon = "N"
                    Case 10, 20, 22, 24, 25, 26, 27, 28, 29, 30
                        ZFazon = "N"
                    Case Else
                        ZFazon = "S"
                End Select

                .Item("ImpreOC") = ""

                If Val(WEtiI) = 1 And Trim(WOrdenCPA) <> "" Then
                    .Item("ImpreOC") = "Orden Cpa.:" & Trim(WOrdenCPA)
                End If

                If Val(WEtiII) = 1 Then
                    .Item("ImpreOC") = .Item("ImpreOC") & " - " & Trim(WDireccionEntrega)
                End If

                .Item("ImpreOC") = Helper.Left(.Item("ImpreOC"), 50)

                .Item("Neti") = 0

                If (Val(txtLote.Text) > 200000 And Val(txtLote.Text) < 299999) Or (Val(txtLote.Text) > 100000 And Val(txtLote.Text) < 199999) Then
                    .Item("Neti") = WCodSegI
                End If

                .Item("Foto1") = 0
                .Item("Foto2") = 0
                .Item("Foto3") = 0
                .Item("Foto4") = 0
                .Item("Foto5") = 0

                For x = 1 To 9
                    If Val(WLogo(x)) <> 0 Then

                        Select Case Val(WLogo(x))
                            Case 1
                                .Item("Foto1") = x
                            Case 2
                                .Item("Foto2") = x
                            Case 3
                                .Item("Foto3") = x
                            Case 4
                                .Item("Foto4") = x
                            Case 5
                                .Item("Foto5") = x
                        End Select

                    End If
                Next

                If ckImprimeNumEtiq.Checked Then
                    If IdEmpresa = 5 Then
                        .Item("ImpreNumero") = ""
                    Else
                        .Item("ImpreNumero") = txtDesde.Text
                        txtDesde.Text = Val(txtDesde.Text) + 1
                    End If
                End If

                If txtCliente.Text.Trim <> "" Then

                    '[UltEtiqBarraFinal]

                    ExecuteNonQueries(WEmpresaHoja, {"UPDATE Hoja SET UltEtiqBarraFinal = ISNULL(UltEtiqBarraFinal, 0) + 1 WHERE Hoja = '" & txtLote.Text & "'"})

                    Dim WUltEtiqBarraFinal As DataRow = GetSingle("SELECT UltEtiqBarraFinal FROM Hoja WHERE Hoja = '" & txtLote.Text & "' And Renglon = 1", WEmpresaHoja)
                    Dim WUlt As Integer = 0

                    If WUltEtiqBarraFinal IsNot Nothing Then
                        WUlt = Val(OrDefault(WUltEtiqBarraFinal.Item("UltEtiqBarraFinal"), ""))
                    End If

                    .Item("CodBarra") = "*" & txtLote.Text.PadLeft(6, "0") & txtPedido.Text.PadLeft(6, "0") & formatonumerico(txtCantidad.Text).replace(".", "").PadLeft(6, "0") & WUlt.ToString.PadLeft(4, "0") & "*"

                    ExecuteNonQueries("SurfactanSa", {("INSERT INTO ProcesoCentroImpresion (Lote, CantEtiq, CantPorEtiq, Impresora, Impresion, Pedido, Estado, CodBarra, EtiqFinal) VALUES ('" & txtLote.Text & "', '" & "1" & "', '" & formatonumerico(txtCantidad.Text) & "', '', '', '" & txtPedido.Text & "', '0', '" & .Item("CodBarra").ToString.Replace("*", "") & "', '1')").ToString})

                Else
                    .Item("CodBarra") = "*" & txtLote.Text.PadLeft(6, "0") & txtTerminado.Text & "*"
                End If

            End With

            WEtiquetaII.Rows.Add(_r)

        Next

        '
        ' Grabamos los datos de EtiquetaIII.
        '
        Dim WEtiquetaIII As DataTable = New DBAuxi.EtiquetaIIDataTable

        For i = 1 To Val(txtCantEtiq.Text)

            Dim _r As DataRow = WEtiquetaIII.NewRow

            With _r
                .Item("Codigo") = i

                For x = 1 To 10
                    .Item("Frase" & x) = ZZImpreFrase(x)
                Next

            End With

            WEtiquetaIII.Rows.Add(_r)

        Next

        '
        ' Grabamos los datos de EtiquetaIV
        '
        Dim WEtiquetaIV As DataTable = New DBAuxi.EtiquetaIIIDataTable

        For i = 1 To Val(txtCantEtiq.Text)

            Dim _r As DataRow = WEtiquetaIV.NewRow

            With _r
                .Item("Codigo") = i

                For x = 11 To 19
                    .Item("Frase" & x) = ZZImpreFrase(x)
                Next

                .Item("Frase20") = ""

                If Val(WPalabra) = 1 Then
                    .Item("Frase20") = IIf(cmbIdioma.SelectedIndex = 0, "PELIGRO", "DANGER")
                End If

                If Val(WPalabra) = 2 Then
                    .Item("Frase20") = IIf(cmbIdioma.SelectedIndex = 0, "ATENCION", "ATTENTION")
                End If


            End With

            WEtiquetaIV.Rows.Add(_r)

        Next

        Dim WPictograma As New DBAuxi.PictogramaDataTable
        Dim WPictograma1 As New DBAuxi.Pictograma1DataTable
        Dim WPictograma2 As New DBAuxi.Pictograma2DataTable
        Dim WPictograma3 As New DBAuxi.Pictograma3DataTable
        Dim WPictograma4 As New DBAuxi.Pictograma4DataTable

        For Each pic As DataTable In {WPictograma, WPictograma1, WPictograma2, WPictograma3, WPictograma4}

            pic.Rows.Add(0, "", Application.StartupPath & "\SGA\SB_SGA0.png")

            For i = 1 To 9

                Dim r As DataRow = pic.NewRow

                With r
                    .Item("Codigo") = i
                    .Item("Imagen") = Application.StartupPath & "\SGA\SB_SGA" & i & ".png"
                End With

                pic.Rows.Add(r)

            Next
        Next

        Select Case UCase(txtTerminado.Text)
            Case "SE-00300-050", "SE-00200-072", "SE-00161-150", "SE-00165-100", "SE-00463-151", "SE-00162-150"
                REM paa estos productos fuerzo que tome
                REM la etiqueta comun
                WTipoPro = ""
        End Select

        'If WTipoPro <> "CO" Then
        '    If Trim(WClase) <> "" Then
        '        MsgBox("Coloque la etiqueta de producto Peligroso Clase Nro.: " + WClase, 0, "Impresion de Etiquetas")
        '    End If
        'End If

        Dim rpt As ReportDocument

        Dim ds As New DataSet

        Dim ImpreRNPQ As String = "SI"

        If WTipoPro = "CO" Then
            ImpreRNPQ = "NO"
            rpt = New etinuevacolorante
        ElseIf WTipoPro = "FA" Then

            If cmbIdioma.SelectedIndex = 0 Then

                rpt = New etinuevanormachica25000

                If WPasaMono = 2 And Not _EsFazon(txtTerminado.Text) Then
                    rpt = New etinuevanormachica25000reetiquetado
                End If

                rpt.SetParameterValue("ImpreVto", "F.Reanálisis:")

                If WPasaMono > 0 Or _EsFazon(txtTerminado.Text) Then

                    If Val(WTipoVencimiento) = 1 Then
                        rpt.SetParameterValue("ImpreVto", "F.Reanálisis:")
                    Else
                        rpt.SetParameterValue("ImpreVto", "F.Vencimiento:")
                    End If

                End If
            Else

                rpt = New etinuevanormachica25000ingles

                rpt.SetParameterValue("ImpreNombreMuyLargo", WNombreLargo)
                rpt.SetParameterValue("ImpreVto", "D.Reanalysis:")

                If WPasaMono > 0 Or _EsFazon(txtTerminado.Text) Then

                    If Val(WTipoVencimiento) = 1 Then
                        rpt.SetParameterValue("ImpreVto", "D.Reanalysis:")
                    Else
                        rpt.SetParameterValue("ImpreVto", "D.Expiry:")
                    End If

                End If

            End If

        Else

            If Trim(txtCliente.Text) = "" Then
                'rpt = New etinuevanormachica25000
                rpt = New etinuevanormachicaprueba
                'rpt.SetParameterValue("ImpreVto", "F.Vencimiento:")

            Else
                rpt = New etinuevanormachica
            End If
        End If

        Dim p As ParameterFields = rpt.ParameterFields

        ds.Tables.Add(WEtiquetaII)
        ds.Tables.Add(WEtiquetaIII)
        ds.Tables.Add(WEtiquetaIV)
        ds.Tables.Add(WPictograma)
        ds.Tables.Add(WPictograma1)
        ds.Tables.Add(WPictograma2)
        ds.Tables.Add(WPictograma3)
        ds.Tables.Add(WPictograma4)

        rpt.SetDataSource(ds)

        For Each _p As ParameterField In p
            rpt.ParameterFields(_p.Name).CurrentValues = _p.CurrentValues
        Next

        With New VistaPrevia
            .Reporte = rpt

            Dim Sedronar As String = ""
            If ImpreRNPQ = "SI" Then
                Dim SQLCnslt As String = "SELECT Sedronar FROM Terminado WHERE Codigo = '" & txtTerminado.Text & "'"
                Dim row As DataRow = GetSingle(SQLCnslt)
                If row IsNot Nothing Then
                    If Val(OrDefault(row.Item("Sedronar"), 0)) = 1 Then
                        Sedronar = "RNPQ: 1160/97"
                    End If
                End If
                .Reporte.SetParameterValue("ImpreSedronar", Sedronar)
            End If
            '.Mostrar()
            .Imprimir()
        End With

        'MsgBox("Funciono")

        'With New VistaPreviaDS(WPictograma)
        '    .Show()
        'End With

    End Sub

    Private Function _EsFazon(ByVal Terminado As String) As Boolean

        Dim WTer As String

        WTer = Mid(Terminado, 4, 5)

        Return Val(WTer) > 2999 And Val(WTer) < 4000

    End Function

    '
    ' Devuelve las Fechas de Elaboración y Vencimiento de un mono componente, en un Array de dos items. (0 - Elaboración   1 - Vencimiento)
    ' Si se detuvo la impresión, se devuelven en ambos items '-1'.
    '
    Private Function _CalculaMonoOtro(ByVal Hoja As String, ByVal EmpresaHoja As String) As String()
        Dim WDatos(1) As String
        WDatos(0) = "-1"
        WDatos(1) = "-1"

        Dim WRenglon = 0
        Dim WLote, WLote1, WLote2, WLote3, WTipo, WArticulo, WReferencia, WProducto As String

        Dim WFechaVtoI, WFechaVtoII, WFechaVtoIII, WFechaVtoIOrd, WFechaVtoIIOrd, WFechaVtoIIIOrd

        WFechaVtoI = "99/99/9999"
        WFechaVtoII = "99/99/9999"
        WFechaVtoIII = "99/99/9999"

        Dim WHoja As DataTable = GetAll("SELECT Lote1, Lote2, Lote3, Tipo, Articulo, Producto FROM Hoja WHERE Hoja = '" & Hoja & "'", EmpresaHoja)

        For Each row As DataRow In WHoja.Rows
            With row
                WRenglon += 1
                WLote = OrDefault(.Item("Lote1"), "0")
                WLote1 = OrDefault(.Item("Lote1"), "0")
                WLote2 = OrDefault(.Item("Lote2"), "0")
                WLote3 = OrDefault(.Item("Lote3"), "0")

                WReferencia = "N"

                If Val(WLote1) <> 0 And Val(WLote2) = 0 And Val(WLote3) = 0 Then WReferencia = "S"

                If Val(WLote2) < Val(WLote) And Val(WLote2) <> 0 Then WLote = WLote2
                If Val(WLote3) < Val(WLote) And Val(WLote3) <> 0 Then WLote = WLote3

                WTipo = OrDefault(.Item("Tipo"), "")
                WArticulo = OrDefault(.Item("Articulo"), "")
                WProducto = OrDefault(.Item("Producto"), "")
            End With
        Next

        Dim WTer As DataRow = GetSingle("SELECT Linea FROM Terminado WHERE Codigo  = '" & WProducto & "'")

        If WTer Is Nothing Then
            MsgBox("No se encontró el Producto Relacionado a este Mono Componente.")
            Return WDatos
        End If

        WDatos(0) = "-1"
        WDatos(1) = "-1"

        Dim WLinea As Integer = OrDefault(WTer.Item("Linea"), 0)

        Dim WLaudo As DataRow = Nothing

        For Each empresa As String In Empresas

            If Val(WLote1) <> 0 Then
                WLaudo = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLote1 & "' And Articulo = '" & WArticulo & "'", empresa)
                If WLaudo IsNot Nothing Then WFechaVtoI = OrDefault(WLaudo.Item("FechaVencimiento"), "99/99/9999")
            End If

            If Val(WLote2) <> 0 Then
                WLaudo = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLote2 & "' And Articulo = '" & WArticulo & "'", empresa)
                If WLaudo IsNot Nothing Then WFechaVtoII = OrDefault(WLaudo.Item("FechaVencimiento"), "99/99/9999")
            End If

            If Val(WLote3) <> 0 Then
                WLaudo = GetSingle("SELECT FechaVencimiento FROM Laudo WHERE Laudo = '" & WLote3 & "' And Articulo = '" & WArticulo & "'", empresa)
                If WLaudo IsNot Nothing Then WFechaVtoIII = OrDefault(WLaudo.Item("FechaVencimiento"), "99/99/9999")
            End If

        Next

        WFechaVtoIOrd = ordenaFecha(WFechaVtoI)
        WFechaVtoIIOrd = ordenaFecha(WFechaVtoII)
        WFechaVtoIIIOrd = ordenaFecha(WFechaVtoIII)

        Dim Auxi As String = WFechaVtoIOrd
        WLote = WLote1

        If Val(WFechaVtoIIOrd) < Val(Auxi) Then
            Auxi = WFechaVtoIIOrd
            WLote = WLote2
        ElseIf Val(WFechaVtoIIIOrd) < Val(Auxi) Then
            Auxi = WFechaVtoIIIOrd
            WLote = WLote3
        End If

        '
        ' Solo si es Mono Componente y de una Materia Prima, prosigo calculando la Fecha de Vencimiento.
        '
        If WRenglon = 1 And UCase(WTipo) = "M" Then

            '
            ' Verifico que se hayan cargado algun lote de MP. Si no, se detiene la impresión de las mismas.
            ' 
            If Val(WLote) = 0 Then

                If Val(txtLoteMP.Text) = 0 Then
                    MsgBox("Se debe informar lote de MP", MsgBoxStyle.Exclamation)

                    WDatos(0) = "-1"
                    WDatos(1) = "-1"
                    Return WDatos
                End If
            End If

            WLote = txtLoteMP.Text

            Dim WFechaVencimiento, WFechaElaboracion As String

            WFechaVencimiento = ""
            WFechaElaboracion = ""

            For Each emp As String In Empresas
                WLaudo = GetSingle("SELECT FechaVencimiento, TipoVencimiento, FechaElaboracion, PartiOri FROM Laudo WHERE Laudo = '" & WLote & "'and Articulo = '" & WArticulo & "'", emp)

                If WLaudo IsNot Nothing Then
                    With WLaudo

                        WFechaVencimiento = OrDefault(.Item("FechaVencimiento"), "")
                        WTipoVencimiento = OrDefault(.Item("TipoVencimiento"), "")

                        If WLinea <> 20 And WLinea <> 28 Then WFechaElaboracion = OrDefault(.Item("FechaElaboracion"), "")

                        WPartiOri = OrDefault(.Item("PartiOri"), "")

                        If Trim(WPartiOri) = "" Then
                            If MsgBox("El Lote Original del Laudo no se encuentra cargado. ¿Desea continuar con la impresión?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                                WDatos(0) = "-1"
                                WDatos(1) = "-1"
                                Return WDatos
                            End If
                        End If

                        If WReferencia <> "S" Then
                            WPartiOri = ""
                        End If

                        Exit For

                    End With
                End If
            Next

            If Val(WFechaElaboracion.Replace("/", "")) <> 0 Then

                If _ValidarFecha(WFechaElaboracion) Then
                    WDatos(0) = WFechaElaboracion
                End If
            Else
                WDatos(0) = ""
            End If

            If Val(WFechaVencimiento.Replace("/", "")) <> 0 Then

                If _ValidarFecha(WFechaVencimiento) Then
                    WDatos(1) = WFechaVencimiento
                End If
            Else
                WDatos(1) = ""
            End If

        End If

        Return WDatos
    End Function

    Private Sub ckImprimeNumEtiq_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ckImprimeNumEtiq.Click
        ckRangos.Enabled = ckImprimeNumEtiq.Checked

        ckRangos_Click(Nothing, Nothing)

    End Sub

    Private Sub ckRangos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ckRangos.Click
        gbRango.Enabled = ckRangos.Checked And ckImprimeNumEtiq.Checked

        If ckRangos.Checked Then txtDesde.Focus()

    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtDesde.Text) = 0 Then : Exit Sub : End If

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtHasta.Text) = 0 Then : Exit Sub : End If

            If Val(txtDesde.Text) = 0 Then txtDesde.Text = "1"

            txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub
End Class