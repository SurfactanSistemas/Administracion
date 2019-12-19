Public Class InformeRecepcionDrogaLAB

    Private Sub InformeRecepcionDrogaLAB_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtOrdenCompra.Focus()
    End Sub


    Private Sub InformeRecepcionDrogaLAB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PnlEstadoEnvases.Visible = False
        pnlCertifAnaliyEstadoEtiquet.Visible = False
        pnlAviso.Visible = False
        pnlAyudaProv.Visible = False
        pnlBuscarProveedor.Visible = False

        txtNroInforme.Text = 0
        mastxtFecha.Text = Date.Today
        txtOrdenCompra.Text = 0


    End Sub

    Private Sub txtNroInforme_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroInforme.KeyDown

        Dim SQLCnsl As String
        Dim Entra As String = "N"

        Select Case e.KeyData
            Case Keys.Enter
                If Val(txtNroInforme.Text) <> 0 Then

                    SQLCnsl = "SELECT Fecha, Proveedor, Remito, Orden FROM Informe WHERE Informe = '" & txtNroInforme.Text & "' ORDER BY Renglon"
                    Dim tabla As DataTable = GetAll(SQLCnsl)
                    If tabla.Rows.Count > 0 Then
                        Entra = "S"
                        mastxtFecha.Text = tabla.Rows(0).Item("Fecha")
                        txtProveedor.Text = tabla.Rows(0).Item("Proveedor")
                        txtRemito.Text = tabla.Rows(0).Item("Remito")
                        txtOrdenCompra.Text = tabla.Rows(0).Item("Orden")
                    End If

                    If Entra = "S" Then
                        SQLCnsl = "SELECT Nombre FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'"
                        Dim row As DataRow = GetSingle(SQLCnsl)
                        If row IsNot Nothing Then
                            txtDescripcionProv.Text = row.Item("Nombre")
                        End If
                        _ProcesarInformesViejos()
                    Else
                        Dim Variable As String = txtNroInforme.Text
                        _LimpiarForm()
                        txtNroInforme.Text = Variable
                        txtNroInforme.Focus()
                    End If

                Else
                    _LimpiarForm()
                    txtNroInforme.Focus()
                End If
                
            Case Keys.Escape
                txtNroInforme.Text = ""
        End Select
    End Sub

    Private Sub _LimpiarRenglonDeModicacion()
        txtOrden.Text = ""
        mastxtMateriaPrima.Text = ""
        txtDescripcionMP.Text = ""
        txtCantIngre.Text = ""
        txtSaldoOC.Text = ""
        txtDescOC.Text = ""
        txtEnvase.Text = ""
        txtEtiqueta.Text = ""
    End Sub

    Private Sub _LimpiarForm()
        txtNroInforme.Text = ""
        mastxtFecha.Text = ""
        txtProveedor.Text = ""
        txtDescripcionProv.Text = ""
        txtOrdenCompra.Text = ""
        txtRemito.Text = ""

        DGV_InformeRecepcion.Rows.Clear()

        txtNroInforme.Text = 0
        mastxtFecha.Text = Date.Today
        txtOrdenCompra.Text = 0

        _LimpiarRenglonDeModicacion()

        btnGrabar.Enabled = True
        txtOrdenCompra.Focus()
    End Sub

    Private Sub _ProcesarInformesViejos()
        DGV_InformeRecepcion.Rows.Clear()
        Dim vuelta As Integer = -1
        Dim variableAuxiliar As String
        Dim SQLCnslt As String

        SQLCnslt = "SELECT * FROM Informe WHERE Informe = '" & txtNroInforme.Text & "' ORDER BY Renglon"


        Dim tabla As DataTable = GetAll(SQLCnslt)

        If tabla.Rows.Count > 0 Then
            For Each Row As DataRow In tabla.Rows
                vuelta += 1
                DGV_InformeRecepcion.Rows.Add()
                DGV_InformeRecepcion.Rows(vuelta).Cells("Orden").Value = Row.Item("Orden")
                DGV_InformeRecepcion.Rows(vuelta).Cells("Producto").Value = Row.Item("Articulo")
                DGV_InformeRecepcion.Rows(vuelta).Cells("CantIngre").Value = Row.Item("Cantidad")
                DGV_InformeRecepcion.Rows(vuelta).Cells("DescOC").Value = Row.Item("Resta")
                DGV_InformeRecepcion.Rows(vuelta).Cells("Envase").Value = Row.Item("Envase")

                'Datos pnl Chico
                variableAuxiliar = IIf(IsDBNull(Row.Item("Certificado1")), "0", Row.Item("Certificado1"))
                If variableAuxiliar = 0 Then
                    DGV_InformeRecepcion.Rows(vuelta).Cells("Certificado1").Value = False ' 0 = False
                Else
                    DGV_InformeRecepcion.Rows(vuelta).Cells("Certificado1").Value = True ' 1 = True
                End If

                DGV_InformeRecepcion.Rows(vuelta).Cells("Certificado2").Value = IIf(IsDBNull(Row.Item("Certificado2")), "", Row.Item("Certificado2"))

                variableAuxiliar = IIf(IsDBNull(Row.Item("Estado1")), "0", Row.Item("Estado1"))
                If variableAuxiliar = 0 Then
                    DGV_InformeRecepcion.Rows(vuelta).Cells("Estado1").Value = False ' 0 = False
                Else
                    DGV_InformeRecepcion.Rows(vuelta).Cells("Estado1").Value = True ' 1 = true
                End If

                DGV_InformeRecepcion.Rows(vuelta).Cells("Estado2").Value = IIf(IsDBNull(Row.Item("Estado2")), "", Row.Item("Estado2"))
                DGV_InformeRecepcion.Rows(vuelta).Cells("FechaVencimiento").Value = IIf(IsDBNull(Row.Item("Fechavencimiento")), "  /  /    ", Row.Item("Fechavencimiento"))

                ' Datos para PnL Grande
                DGV_InformeRecepcion.Rows(vuelta).Cells("EstadoEnvI").Value = IIf(IsDBNull(Row.Item("EstadoEnvI")), False, Row.Item("EstadoEnvI"))
                DGV_InformeRecepcion.Rows(vuelta).Cells("ObservaI").Value = IIf(IsDBNull(Row.Item("ObservaI")), "", Row.Item("ObservaI")) + IIf(IsDBNull(Row.Item("ObservaII")), "", Row.Item("ObservaII"))

                DGV_InformeRecepcion.Rows(vuelta).Cells("EstadoEnvIII").Value = IIf(IsDBNull(Row.Item("EstadoEnvIII")), False, Row.Item("EstadoEnvIII"))
                DGV_InformeRecepcion.Rows(vuelta).Cells("ObservaIII").Value = IIf(IsDBNull(Row.Item("ObservaIII")), "", Row.Item("ObservaIII")) + IIf(IsDBNull(Row.Item("ObservaIV")), "", Row.Item("ObservaIV"))

                DGV_InformeRecepcion.Rows(vuelta).Cells("EstadoEnvV").Value = IIf(IsDBNull(Row.Item("EstadoEnvV")), False, Row.Item("EstadoEnvV"))

                DGV_InformeRecepcion.Rows(vuelta).Cells("EstadoEnvVII").Value = IIf(IsDBNull(Row.Item("EstadoEnvVII")), False, Row.Item("EstadoEnvVII"))

                DGV_InformeRecepcion.Rows(vuelta).Cells("EstadoEnvIX").Value = IIf(IsDBNull(Row.Item("EstadoEnvIX")), False, Row.Item("EstadoEnvIX"))

                DGV_InformeRecepcion.Rows(vuelta).Cells("CantidadEnv").Value = IIf(IsDBNull(Row.Item("CantidadEnv")), "0", Row.Item("CantidadEnv"))


                SQLCnslt = "SELECT Descripcion FROM Envases WHERE Envases = '" & Row.Item("Envase") & "'"

                Dim RowEnvases As DataRow = GetSingle(SQLCnslt)

                If RowEnvases IsNot Nothing Then
                    DGV_InformeRecepcion.Rows(vuelta).Cells("DescripcionEnvase").Value = IIf(IsDBNull(RowEnvases.Item("Descripcion")), "", RowEnvases.Item("Descripcion"))
                End If

                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & Row.Item("Articulo") & "'"
                Dim rowArticulo As DataRow = GetSingle(SQLCnslt)

                DGV_InformeRecepcion.Rows(vuelta).Cells("Descripcion").Value = rowArticulo.Item("Descripcion")
            Next
        End If
    End Sub

   
    


    Sub _ModificarDatosGRilla()
        For i As Integer = 0 To DGV_InformeRecepcion.Rows.Count - 1
            If DGV_InformeRecepcion.Rows(i).Cells("Producto").Value = mastxtMateriaPrima.Text Then
                DGV_InformeRecepcion.Rows(i).Cells("CantIngre").Value = txtCantIngre.Text
                DGV_InformeRecepcion.Rows(i).Cells("DescOC").Value = txtDescOC.Text
                DGV_InformeRecepcion.Rows(i).Cells("Envase").Value = txtEnvase.Text
                DGV_InformeRecepcion.Rows(i).Cells("Etiqueta").Value = txtEtiqueta.Text
                Exit For
            End If
        Next
        txtOrden.Text = ""
        mastxtMateriaPrima.Text = ""
        txtDescripcionMP.Text = ""
        txtCantIngre.Text = ""
        txtSaldoOC.Text = ""
        txtDescOC.Text = ""
        txtEnvase.Text = ""
        txtEtiqueta.Text = ""
        txtDescOC.Enabled = True
    End Sub
    
    Private Sub txtEtiqueta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEtiqueta.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                Dim TipoOrden As Integer = 0
                Dim SQLCnslt As String
                
                SQLCnslt = "SELECT Tipo FROM Orden WHERE Orden = '" & txtOrden.Text & "' ORDER BY Renglon"
                Dim rowOrden As DataRow = GetSingle(SQLCnslt)
                If rowOrden IsNot Nothing Then
                    TipoOrden = rowOrden.Item("Tipo")
                End If
                If TipoOrden <> 4 Or TipoOrden <> 3 Then Exit Sub 'sino es orden de drogas de lab termina el proceso

                pnlCertifAnaliyEstadoEtiquet.Visible = True

        End Select
    End Sub

    Private Sub DGV_InformeRecepcion_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_InformeRecepcion.CellDoubleClick
        'Renglon abajo de la grilla
        txtOrden.Text = DGV_InformeRecepcion.CurrentRow.Cells("Orden").Value
        mastxtMateriaPrima.Text = DGV_InformeRecepcion.CurrentRow.Cells("Producto").Value
        txtDescripcionMP.Text = DGV_InformeRecepcion.CurrentRow.Cells("Descripcion").Value
        txtCantIngre.Text = DGV_InformeRecepcion.CurrentRow.Cells("CantIngre").Value
        txtSaldoOC.Text = DGV_InformeRecepcion.CurrentRow.Cells("SaldoOC").Value
        txtDescOC.Text = DGV_InformeRecepcion.CurrentRow.Cells("DescOC").Value
        txtEnvase.Text = DGV_InformeRecepcion.CurrentRow.Cells("Envase").Value

        'panel pequeño
        If DGV_InformeRecepcion.CurrentRow.Cells("Certificado1").Value = True Then
            rabtnSI_CertifAnalisis2.Checked = True
        Else
            rabtnNO_CertifAnalisis2.Checked = True
        End If

        txtCertifAnalisis2.Text = DGV_InformeRecepcion.CurrentRow.Cells("Certificado2").Value

        If DGV_InformeRecepcion.CurrentRow.Cells("Estado1").Value = True Then
            rabtnSI_EstadoEnvases5.checked = True
        Else
            rabtnNO_EstadoEnvases5.Checked = True
        End If

        txtEstadoEnvases5.Text = DGV_InformeRecepcion.CurrentRow.Cells("Estado2").Value

        mastxtVencimiento_pnlIngreCertif.Text = DGV_InformeRecepcion.CurrentRow.Cells("Fechavencimiento").Value


        'Panel grande

        If DGV_InformeRecepcion.CurrentRow.Cells("EstadoEnvI").Value = True Then
            rabtnCum_CertifAnalisis.Checked = True
        Else
            rabtnNOCum_CertifAnalisis.Checked = True
        End If
        txtCertifAnalisis.Text = DGV_InformeRecepcion.CurrentRow.Cells("ObservaI").Value

        If DGV_InformeRecepcion.CurrentRow.Cells("EstadoEnvIII").Value = True Then
            rabtnCum_EstadoEnvases1.Checked = True
        Else
            rabtnNOCum_EstadoEnvases1.Checked = True
        End If
        txtEstadoEnvases1.Text = DGV_InformeRecepcion.CurrentRow.Cells("ObservaIII").Value

        If DGV_InformeRecepcion.CurrentRow.Cells("EstadoEnvV").Value = True Then
            rabtnCum_EstadoEnvases2.Checked = True
        Else
            rabtnNOCum_EstadoEnvases2.Checked = True
        End If

        If DGV_InformeRecepcion.CurrentRow.Cells("EstadoEnvVII").Value = True Then
            rabtnCum_EstadoEnvases3.Checked = True
        Else
            rabtnNOCum_EstadoEnvases3.Checked = True
        End If

        If DGV_InformeRecepcion.CurrentRow.Cells("EstadoEnvIX").Value = True Then
            rabtnCum_EstadoEnvases4.Checked = True
        Else
            rabtnNOCum_EstadoEnvases4.Checked = True
        End If

        txtCantRechazada.Text = DGV_InformeRecepcion.CurrentRow.Cells("CantidadEnv").Value

        txtCantIngre.Focus()

        _CargarLebels()

    End Sub

    Sub _CargarLebels()

        Dim SQLCnslt As String
       

        Dim Ensayo1 As String = "0"
        Dim Ensayo2 As String = "0"
        Dim Ensayo3 As String = "0"
        Dim Ensayo4 As String = "0"
        Dim Ensayo5 As String = "0"

        lblCertifAnalisis.Text = ""
        lblEstadoEnvases1.Text = ""
        lblEstadoEnvases2.Text = ""
        lblEstadoEnvases3.Text = ""
        lblEstadoEnvases4.Text = ""


        SQLCnslt = "SELECT Ensayo1, Ensayo2, Ensayo3, Ensayo4, Ensayo5 FROM EspecificacionesUnifica WHERE Producto = '" & mastxtMateriaPrima.Text & "'"

        Dim row As DataRow = GetSingle(SQLCnslt, "Surfactan_II")

        If row IsNot Nothing Then
            Ensayo1 = Str$(row.Item("Ensayo1"))
            Ensayo2 = Str$(row.Item("Ensayo2"))
            Ensayo3 = Str$(row.Item("Ensayo3"))
            Ensayo4 = Str$(row.Item("Ensayo4"))
            Ensayo5 = Str$(row.Item("Ensayo5"))
        End If

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo1 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then
            lblEstadoEnvases1.Text = row.Item("Descripcion")
        End If

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo2 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then
            lblEstadoEnvases2.Text = row.Item("Descripcion")
        End If

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo3 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then
            lblEstadoEnvases3.Text = row.Item("Descripcion")
        End If

        SQLCnslt = "SELECT Descripcion FROM Ensayos WHERE Codigo = '" & Ensayo4 & "'"
        row = GetSingle(SQLCnslt, "Surfactan_II")
        If row IsNot Nothing Then
            lblEstadoEnvases4.Text = row.Item("Descripcion")
        End If
    End Sub

    Private Sub btnAceptar_pnlAviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar_pnlAviso.Click
        pnlAviso.Visible = False

    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrdenCompra.KeyPress, txtRemito.KeyPress, txtProveedor.KeyPress, txtNroInforme.KeyPress, txtEtiqueta.KeyPress, txtEnvase.KeyPress, mastxtVencimiento_pnlIngreCertif.KeyPress, mastxtFecha.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    




    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantIngre.KeyPress, txtDescOC.KeyPress, txtCantRechazada.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub




    Private Sub txtOrdenCompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrdenCompra.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If Val(txtOrdenCompra.Text) = 0 Then
                    txtProveedor.Focus()
                Else
                    Dim TipoOrden As Integer
                    Dim SQLCnslt As String = "SELECT Tipo FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "'"
                    Dim roworden As DataRow = GetSingle(SQLCnslt)
                    If roworden IsNot Nothing Then
                        TipoOrden = roworden.Item("Tipo")
                    End If
                    Dim auxiliar As String = txtOrdenCompra.Text
                    _LimpiarForm()
                    txtOrdenCompra.Text = auxiliar
                    If TipoOrden = 4 Or TipoOrden = 3 Then
                        txtNroInforme.Text = 0
                        _LimpiarRenglonDeModicacion()
                        txtRemito.Text = ""
                        _ProcesoLLenarGrilla()
                        If _BuscarRepetidos() <> "" Then
                            btnGrabar.Enabled = False
                            MsgBox("No se podra grabar un informe, ya que hay Articulos repetidos en la orden de compra")
                        End If
                    Else
                        Exit Sub 'sino es orden de drogas de lab termina el proceso
                    End If
                End If
            Case Keys.Escape
                txtOrdenCompra.Text = ""
        End Select
    End Sub

    Private Function _BuscarRepetidos() As String
        Dim PosicionActual As Integer = 0
        Dim CodigoActual As String
        For i As Integer = 0 To DGV_InformeRecepcion.Rows.Count - 1
            With DGV_InformeRecepcion
                CodigoActual = .Rows(i).Cells("Producto").Value
                PosicionActual = i
                For j As Integer = 0 To .Rows.Count - 1
                    If PosicionActual = j Then
                        Continue For
                    End If
                    If CodigoActual = .Rows(j).Cells("Producto").Value Then
                        Return "SE REPITEN"
                    End If
                Next
            End With
        Next

        Return ""

    End Function

    Private Sub _ProcesoLLenarGrilla()

        If Val(txtOrdenCompra.Text) <> 0 Then

            DGV_InformeRecepcion.Rows.Clear()

            Dim Renglon As Integer = -1
            Dim Auxiliar As String
            Dim SQLCnslt As String

            SQLCnslt = "SELECT Cantidad, Recibida, Articulo, Proveedor FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "' ORDER BY Renglon"

            Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

            If tablaOrdenesCompra.Rows.Count > 0 Then
                For i As Integer = 0 To tablaOrdenesCompra.Rows.Count - 1
                    Dim Saldo As Double = tablaOrdenesCompra.Rows(i).Item("Cantidad") - tablaOrdenesCompra.Rows(i).Item("Recibida")

                    If Saldo > 0 Then

                        Renglon += 1

                        DGV_InformeRecepcion.Rows.Add()


                        DGV_InformeRecepcion.Rows(Renglon).Cells("Orden").Value = txtOrdenCompra.Text
                        DGV_InformeRecepcion.Rows(Renglon).Cells("Producto").Value = tablaOrdenesCompra.Rows(i).Item("Articulo")

                        Saldo = tablaOrdenesCompra.Rows(i).Item("Cantidad") - tablaOrdenesCompra.Rows(i).Item("Recibida")


                        DGV_InformeRecepcion.Rows(Renglon).Cells("CantIngre").Value = formatonumerico(0)
                        DGV_InformeRecepcion.Rows(Renglon).Cells("SaldoOC").Value = formatonumerico(Saldo)
                        DGV_InformeRecepcion.Rows(Renglon).Cells("DescOC").Value = formatonumerico(0)
                        DGV_InformeRecepcion.Rows(Renglon).Cells("Envase").Value = ""
                    End If
                Next

                txtProveedor.Text = tablaOrdenesCompra.Rows(0).Item("Proveedor")
            End If


            SQLCnslt = " SELECT Nombre FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'"

            Dim RowProveedor As DataRow = GetSingle(SQLCnslt)
            If RowProveedor IsNot Nothing Then
                txtDescripcionProv.Text = RowProveedor.Item("Nombre")
            End If

        
        
            For Each DG_ROW As DataGridViewRow In DGV_InformeRecepcion.Rows
                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & DG_ROW.Cells("Producto").Value & "'"
                Dim rowArticulo As DataRow = GetSingle(SQLCnslt)

                If rowArticulo IsNot Nothing Then
                    DG_ROW.Cells("Descripcion").Value = rowArticulo.Item("Descripcion")
                End If

            Next
        End If

        If DGV_InformeRecepcion.Rows.Count > 0 Then
            txtRemito.Focus()
        End If

    End Sub

    Private Sub txtCantIngre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantIngre.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtSaldoOC.Text = "" Then
                    txtEnvase.Focus()
                Else
                    txtCantIngre.Text = formatonumerico(txtCantIngre.Text)
                    If Val(txtCantIngre.Text) >= Val(txtSaldoOC.Text) Then
                        txtDescOC.Text = txtSaldoOC.Text
                        txtDescOC.Enabled = False
                        txtEnvase.Focus()
                    Else
                        txtDescOC.Enabled = True
                        txtDescOC.Focus()
                    End If

                    txtDescOC.Focus()
                End If

            Case Keys.Escape
                txtCantIngre.Text = ""
        End Select
    End Sub

    
 
    Private Sub txtDescOC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescOC.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txtSaldoOC.Text.Trim() = "" Then
                    txtEnvase.Focus()
                Else


                    If Val(txtDescOC.Text) > Val(txtSaldoOC.Text) Then
                        MsgBox("No puede ser mayor al Saldo de Orden de Compra")
                        txtDescOC.Focus()
                    Else
                        If Val(txtDescOC.Text) < Val(txtSaldoOC.Text) And Val(txtDescOC.Text) < Val(txtCantIngre.Text) Then
                            txtDescOC.Text = txtCantIngre.Text
                        End If

                        txtDescOC.Text = formatonumerico(txtDescOC.Text)
                        txtEnvase.Focus()
                    End If
                End If

            Case Keys.Escape
                txtDescOC.Text = ""
        End Select
    End Sub

    Private Sub txtEnvase_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEnvase.KeyDown
        Select Case e.KeyData
            Case Keys.Enter

                If txtSaldoOC.Text.Trim() = "" Then
                    If Val(txtCantIngre.Text) > 0 And Val(txtDescOC.Text) > 0 Then
                        If txtDescripcionMP.Text <> "" Then
                            PnlEstadoEnvases.Visible = True
                        End If
                    End If
                Else
                    If Val(txtCantIngre.Text) = 0 Then
                        txtCantIngre.Focus()
                        Exit Sub
                    End If

                    If Val(txtDescOC.Text) = 0 Then
                        txtDescOC.Focus()
                        Exit Sub
                    End If

                    Dim TipoOrden As Integer = 0
                    Dim SQLCnslt As String
                    Dim Entra As String

                    SQLCnslt = "SELECT Tipo FROM Orden WHERE Orden = '" & txtOrden.Text & "' ORDER BY Renglon"
                    Dim rowOrden As DataRow = GetSingle(SQLCnslt)
                    If rowOrden IsNot Nothing Then
                        TipoOrden = rowOrden.Item("Tipo")
                    End If

                    If TipoOrden <> 3 And TipoOrden <> 4 Then

                        SQLCnslt = "SELECT Envases FROM Envases WHERE Envases = '" & txtEnvase.Text & "'"
                        rowOrden = GetSingle(SQLCnslt)
                        If rowOrden IsNot Nothing Then
                            txtEtiqueta.Focus()
                        Else
                            txtEnvase.Focus()
                        End If
                        If txtEnvase.Text <> "" Then
                            PnlEstadoEnvases.Visible = True
                        End If
                    Else
                        If TipoOrden = 3 Or TipoOrden = 4 Then

                            Entra = "N"
                            SQLCnslt = "SELECT Informe FROM Informe WHERE Informe = '" & _txtNroInforme.Text & "'"
                            Dim rowInforme As DataRow = GetSingle(SQLCnslt)
                            If rowInforme IsNot Nothing Then
                                Entra = "S"
                            End If

                            txtEnvase.Text = "0"
                            txtEtiqueta.Text = "0"


                            If Entra = "N" Then
                                If Val(txtDescOC.Text) > Val(txtSaldoOC.Text) Then
                                    Dim mensaje As String = "La cantidad a descontar supera el saldo de la orden de compra"
                                    MsgBox(mensaje, 0, "Ingreso de Informe de recepcion")
                                    txtDescOC.Text = ""
                                    txtDescOC.Focus()
                                    Exit Sub
                                Else
                                    If Val(txtDescOC.Text) <> Val(txtSaldoOC.Text) Then
                                        Dim Dife As Double = Str$(Val(txtSaldoOC.Text) - Val(txtDescOC.Text))
                                        Dim Termina As String = "Ingreso de Informe de recepcion"
                                        Dim mensaje As String = "La orden de compra del " + mastxtMateriaPrima.Text + " quedara con un saldo pendiente de entrega de " + Dife + " Kgs" + vbCrLf + "Confirma este procedimiento"
                                        Dim Respuesta = MsgBox(mensaje, 32 + 4, Termina)
                                        If Respuesta <> 6 Then
                                            Exit Sub
                                        End If
                                        lblAviso2.Text = "LA CANTIDAD DE " + Str$(Dife) + " KGS. Y QUE EL PROVEEDOR"
                                        pnlAviso.Visible = True
                                    End If
                                End If
                            End If

                            '_CargarLebels()

                            _ModificarDatosGRilla()
                        End If
                    End If


                End If
            Case Keys.Escape
                txtEnvase.Text = ""
        End Select
    End Sub

    Private Sub btnAceptar_pnlEstadoEnvases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar_pnlEstadoEnvases.Click
        PnlEstadoEnvases.Visible = False
    End Sub

    Private Sub btnAceptar_IngreCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar_IngreCert.Click
        pnlCertifAnaliyEstadoEtiquet.Visible = False
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown

        Dim SQLCnslt As String

        Select Case e.KeyData
            Case Keys.Enter
                If txtProveedor.Text <> "" Then
                    If txtOrdenCompra.Text <> "" Then
                        SQLCnslt = "SELECT Articulo FROM Orden WHERE Orden = '" & txtOrdenCompra.Text & "' AND Proveedor = '" & txtProveedor.Text & "'"
                        Dim rowOrd As DataRow = GetSingle(SQLCnslt)
                        If rowOrd IsNot Nothing Then
                            Exit Sub
                        End If
                    End If

                    Dim Auxiliar As String = txtProveedor.Text
                    _LimpiarForm()
                    txtProveedor.Text = Auxiliar

                    SQLCnslt = "SELECT AyudaDescripcion = a.Descripcion, AyudaArticulo = o.Articulo,  AyudaSaldo = o.Cantidad - o.Recibida, NroOrden = o.Orden "
                    SQLCnslt = SQLCnslt & "FROM Orden o INNER JOIN Articulo a ON o.Articulo = a.Codigo  WHERE (o.Tipo = 3 OR o.Tipo = 4) AND o.Saldo > 0 AND o.Recibida < o.Cantidad  AND o.Proveedor = '" & txtProveedor.Text & "' ORDER BY o.Articulo "
                    Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

                    DGV_AyudaProv.DataSource = tablaOrdenesCompra

                    If tablaOrdenesCompra.Rows.Count > 0 Then
                        pnlAyudaProv.Visible = True
                    Else
                        SQLCnslt = "Select Proveedor from proveedor where proveedor = '" & txtProveedor.Text & "'"
                        Dim row As DataRow = GetSingle(SQLCnslt)
                        If row IsNot Nothing Then
                            MsgBox("No existen ordenes de compra pendientes para este proveedor")
                        Else
                            txtProveedor.Focus()
                        End If

                    End If
                End If
            Case Keys.Escape
                txtProveedor.Text = ""
        End Select
        End Sub

    Private Sub btnVolver_pnlAyudaProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver_pnlAyudaProv.Click
        pnlAyudaProv.Visible = False
    End Sub

    Private Sub DGV_AyudaProv_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_AyudaProv.CellMouseDoubleClick
        txtOrdenCompra.Text = DGV_AyudaProv.CurrentRow.Cells("NroOrden").Value
        pnlAyudaProv.Visible = False
        txtOrdenCompra_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub btnLimpiarForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarForm.Click
        _LimpiarForm()
    End Sub

    Private Sub btnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub txtOrdenCompra_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrdenCompra.DoubleClick
        Dim SQLCnslt As String
        If txtProveedor.Text <> "" Then
            SQLCnslt = "SELECT AyudaDescripcion = a.Descripcion, AyudaArticulo = o.Articulo,  AyudaSaldo = o.Cantidad - o.Recibida, NroOrden = o.Orden "
            SQLCnslt = SQLCnslt & "FROM Orden o INNER JOIN Articulo a ON o.Articulo = a.Codigo  WHERE (o.Tipo = 3 OR o.Tipo = 4) AND o.Saldo > 0 AND o.Recibida < o.Cantidad  AND o.Proveedor = '" & txtProveedor.Text & "' ORDER BY o.Articulo "
            Dim tablaOrdenesCompra As DataTable = GetAll(SQLCnslt)

            DGV_AyudaProv.DataSource = tablaOrdenesCompra

            If tablaOrdenesCompra.Rows.Count > 0 Then
                pnlAyudaProv.Visible = True
            End If
        End If


    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim Auxiliar, Auxiliar2 As String

        auxiliar = ValidaFecha(mastxtFecha.Text)

        If auxiliar <> "S" Then
            Dim mensaje As String = "La fecha del informe de recepcion es incorrecta"
            MsgBox(mensaje, 0, "Ingreso de Orden de Compra")
            Exit Sub
        End If


        If Trim(txtRemito.Text) = "" Then
            Dim mensaje As String = "Es obligatorio informar el numero de remito"
            MsgBox(mensaje, 0, "Ingreso de Informe de recepcion")
            Exit Sub
        End If



        Dim Renglon As Integer = 0
  

        Dim Orden As String
        Dim Articulo As String
        Dim DesArticulo As String
        Dim Cantidad As String
        Dim Saldo As String
        Dim Resta As String
        Dim Envase As String
        Dim CantiEti As String

        Dim CertificadoSi As Integer
        Dim CertificadoNo As Integer
        Dim Certificado2 As String

        Dim EstadoSi As Integer
        Dim EstadoNo As Integer
        Dim Estado2 As String

        Dim Vencimiento As String
        Dim OrdVencimiento As String

        Dim Certificado1 As String
        Dim Estado1 As String

        Dim EstadoEnv1 As Integer
        Dim EstadoEnv2 As Integer
        Dim EstadoEnv3 As Integer
        Dim EstadoEnv4 As Integer
        Dim EstadoEnv5 As Integer
        Dim EstadoEnv6 As Integer
        Dim EstadoEnv7 As Integer
        Dim EstadoEnv8 As Integer
        Dim EstadoEnv9 As Integer
        Dim EstadoEnv10 As Integer
        Dim CantidadEnv As Integer
        Dim ObservaI As String
        Dim ObservaII As String
        Dim ObservaIII As String
        Dim ObservaIV As String

        Dim Clave As String
        Dim Informe As String
        Dim Fecha As String
        Dim Proveedor As String
        Dim Remito As String
        Dim Fechaord As String
        Dim WDate As String


        Dim ClaveOrden As String
        Dim Recibida As String


        Dim Entradas As String
        Dim Costo1 As String
        Dim Costo3 As String

        Dim ClaveMovVar As String
        Dim Tipo As String
        Dim Terminado As String
        Dim Movi As String
        Dim Lote As String
        Dim Tipomov As String
        Dim Observaciones As String
        Dim Marca As String

        Dim SQLCnslt As String
        Dim listaSQLCnslt As New List(Of String)

        'duda?
        Dim CodMovVar As String

        SQLCnslt = "SELECT Codigo = MAX(Codigo) + 1 FROM Movvar "
        Dim rowmovvar As DataRow = GetSingle(SQLCnslt)

        If rowmovvar IsNot Nothing Then
            CodMovVar = rowmovvar.Item("Codigo")
        Else
            CodMovVar = 1
        End If
        'Hasta aca




        SQLCnslt = "SELECT Informe = MAX(Informe) +1 FROM Informe "
        Dim row As DataRow = GetSingle(SQLCnslt)

        txtNroInforme.Text = row.Item("Informe")

        For i = 0 To DGV_InformeRecepcion.Rows.Count - 1

            If Val(DGV_InformeRecepcion.Rows(i).Cells("CantIngre").Value) = 0 Then
                Continue For
            End If

            If DGV_InformeRecepcion.Rows(i).Cells("SaldoOC").Value Is Nothing Then
                MsgBox("No puede grabar un Informe ya existente")
                Exit Sub
            End If


            With DGV_InformeRecepcion.Rows(i)

                Orden = .Cells("Orden").Value
                Articulo = UCase(.Cells("Producto").Value)
                DesArticulo = UCase(.Cells("Descripcion").Value)
                Cantidad = .Cells("CantIngre").Value
                Saldo = .Cells("SaldoOC").Value
                Resta = .Cells("DescOC").Value
                Envase = .Cells("Envase").Value
                CantiEti = .Cells("Etiqueta").Value

            End With

            Dim XLote1 As String = ""
            Dim XLote2 As String = ""
            Dim XLote3 As String = ""
            Dim XLote4 As String = ""
            Dim XLote5 As String = ""
            Dim XCantiLote1 As String = ""
            Dim XCantiLote2 As String = ""
            Dim XCantiLote3 As String = ""
            Dim XCantiLote4 As String = ""
            Dim XCantiLote5 As String = ""

            CertificadoSi = 1
            CertificadoNo = 0
            Certificado2 = ""

            EstadoSi = 1
            EstadoNo = 0
            Estado2 = ""

            If CertificadoNo = 1 Then
                Certificado1 = 0
            End If

            If CertificadoSi = 1 Then
                Certificado1 = 1
            End If

            If EstadoNo = 1 Then
                Estado1 = 1
            End If

            If EstadoSi = 1 Then
                Estado1 = 1
            End If

            Vencimiento = "  /  /    "
            OrdVencimiento = ""

            EstadoEnv1 = 1
            EstadoEnv2 = 0
            EstadoEnv3 = 1
            EstadoEnv4 = 0
            EstadoEnv5 = 1
            EstadoEnv6 = 0
            EstadoEnv7 = 1
            EstadoEnv8 = 0
            EstadoEnv9 = 1
            EstadoEnv10 = 0
            CantidadEnv = 0
            ObservaI = ""
            ObservaII = ""
            ObservaIII = ""
            ObservaIV = ""

            If Articulo <> "" Then

                Auxiliar = Renglon.ToString().PadLeft(2, "0")

                Auxiliar2 = txtNroInforme.Text.PadLeft(6, "0")

                Clave = Auxiliar2 + Auxiliar
                Informe = txtNroInforme.Text   'FALTA OBTERNER EL VALOR MAXIMO ANTES DE INSERTAR
                Renglon = (Renglon).ToString()
                Fecha = mastxtFecha.Text
                Proveedor = txtProveedor.Text
                Remito = txtRemito.Text
                Fechaord = Microsoft.VisualBasic.Right(Fecha, 4) + Mid$(Fecha, 4, 2) + Microsoft.VisualBasic.Left(Fecha, 2)
                WDate = Date.Now.ToString("MM-dd-yyyy")



                SQLCnslt = "INSERT INTO Informe (Clave , Informe , Renglon , Fecha ,"
                SQLCnslt = SQLCnslt & "Remito , Proveedor , Orden , Articulo , Cantidad ,"
                SQLCnslt = SQLCnslt & "Resta , FechaOrd , Envase , Lote1 , Canti1 ,"
                SQLCnslt = SQLCnslt & "Lote2 , Canti2 , Lote3 , Canti3 , Lote4 ,"
                SQLCnslt = SQLCnslt & "Canti4 ,Lote5 , Canti5 , Certificado1 , Certificado2 ,"
                SQLCnslt = SQLCnslt & "Estado1 , Estado2 , EstadoEnvI , EstadoEnvII , EstadoEnvIII ,"
                SQLCnslt = SQLCnslt & "EstadoEnvIV , EstadoEnvV , EstadoEnvVI , EstadoEnvVII ,EstadoEnvVIII ,"
                SQLCnslt = SQLCnslt & "EstadoEnvIX ,EstadoEnvX , CantidadEnv , ObservaI , ObservaII ,"
                SQLCnslt = SQLCnslt & "ObservaIII , ObservaIV , FechaVencimiento , OrdFechaVencimiento )"
                SQLCnslt = SQLCnslt & "Values ('" & Clave & "', '" & Informe & "', '" & Renglon & "', '" & Fecha & "',"
                SQLCnslt = SQLCnslt & "'" & Remito & "', '" & Proveedor & "', '" & Orden & "', '" & Articulo & "', '" & Cantidad & "',"
                SQLCnslt = SQLCnslt & "'" & Resta & "', '" & Fechaord & "', '" & Envase & "', '" & XLote1 & "', '" & XCantiLote1 & "',"
                SQLCnslt = SQLCnslt & "'" & XLote2 & "', '" & XCantiLote2 & "', '" & XLote3 & "', '" & XCantiLote3 & "', '" & XLote4 & "',"
                SQLCnslt = SQLCnslt & "'" & XCantiLote4 & "', '" & XLote5 & "', '" & XCantiLote5 & "', '" & Certificado1 & "', '" & Certificado2 & "',"
                SQLCnslt = SQLCnslt & "'" & Estado1 & "', '" & Estado2 & "', '" & EstadoEnv1 & "', '" & EstadoEnv2 & "', '" & EstadoEnv3 & "',"
                SQLCnslt = SQLCnslt & "'" & EstadoEnv4 & "', '" & EstadoEnv5 & "', '" & EstadoEnv6 & "', '" & EstadoEnv7 & "', '" & EstadoEnv8 & "',"
                SQLCnslt = SQLCnslt & "'" & EstadoEnv9 & "', '" & EstadoEnv10 & "', '" & CantidadEnv & "', '" & ObservaI & "', '" & ObservaII & "',"
                SQLCnslt = SQLCnslt & "'" & ObservaIII & "', '" & ObservaIV & "', '" & Vencimiento & "', '" & OrdVencimiento & "')"

                listaSQLCnslt.Add(SQLCnslt)

                Dim TipoOrden As Integer = 0

                SQLCnslt = "SELECT Tipo FROM Orden WHERE Orden = '" & Orden & "'"
                row = GetSingle(SQLCnslt)

                TipoOrden = row.Item("Tipo")


                SQLCnslt = "SELECT Pedido, Laboratorio FROM Articulo WHERE Codigo = '" & Articulo & "'"

                Dim RowArticulo As DataRow = GetSingle(SQLCnslt)

                If RowArticulo IsNot Nothing Then

                    If TipoOrden <> 2 Then

                        Dim Pedido As String = (RowArticulo.Item("Pedido") - Val(Resta)).ToString()
                        Dim Laboratorio As String = (RowArticulo.Item("Laboratorio") + Val(Cantidad)).ToString()

                        SQLCnslt = "UPDATE Articulo SET Pedido = '" & Pedido & "', Laboratorio = '" & Laboratorio & "', Wdate = '" & WDate & "' WHERE Codigo = '" & Articulo & "'"

                        listaSQLCnslt.Add(SQLCnslt)


                        For j = 1 To 11
                            SQLCnslt = "UPDATE  " & _AQueEmpresa(j) & ".dbo.Articulo SET Envase = '" & Envase & "', Proveedor = '" & Proveedor & "' WHERE Codigo = '" & Articulo & "'"
                            listaSQLCnslt.Add(SQLCnslt)
                        Next

                        SQLCnslt = "SELECT Clave, Recibida FROM Orden WHERE Orden = '" & Orden & "' AND Articulo = '" & Articulo & "'"

                        Dim RowOrden As DataRow = GetSingle(SQLCnslt)

                        If RowOrden IsNot Nothing Then
                            ClaveOrden = RowOrden.Item("Clave")
                            Recibida = RowOrden.Item("Recibida") + Val(Resta)

                            SQLCnslt = "UPDATE Orden SET Recibida = '" & Recibida & "', Wdate = '" & WDate & "' WHERE Clave = '" & ClaveOrden & "'"

                            listaSQLCnslt.Add(SQLCnslt)


                            If Val(txtOrden.Text) >= 800000 Then
                                If TipoOrden = 3 Then

                                    If Val(Cantidad) <> 0 Then

                                        SQLCnslt = "SELECT  Entradas, Costo1, Costo3 FROM Articulo WHERE Codigo = '" & Articulo & "'"
                                        RowArticulo = GetSingle(SQLCnslt)

                                        If RowArticulo IsNot Nothing Then

                                            Entradas = (RowArticulo.Item("Entradas") + Val(Cantidad)).ToString()
                                            Costo1 = (RowArticulo.Item("Costo1")).ToString()
                                            Costo3 = (IIf(IsDBNull(RowArticulo.Item("Costo3")), "0", RowArticulo.Item("Costo3"))).ToString()

                                            SQLCnslt = "UPDATE SET Laboratorio = '" & Laboratorio & "', Entradas = '" & Entradas & "', Wdate = " & WDate & "', Costo1 = '" & Costo1 & "', Costo3 = '" & Costo3 & "' WHERE Codigo = '" & Articulo & "'"
                                            listaSQLCnslt.Add(SQLCnslt)
                                        End If


                                        Auxiliar = CodMovVar.PadLeft(6, "0")
                                        Auxiliar2 = Renglon.ToString().PadLeft(2, "0")

                                        ClaveMovVar = Auxiliar + Auxiliar2
                                        Tipo = "M"
                                        Terminado = ""
                                        Movi = "E"
                                        Lote = ""
                                        Tipomov = "0"
                                        Observaciones = "Informe " + txtNroInforme.Text + " O/C " + txtOrdenCompra.Text
                                        Marca = ""

                                        SQLCnslt = "INSER INTO Movvar(Clave,Codigo,Renglon,Fecha,Tipo,Articulo,Terminado,Cantidad,FechaOrd,Movi,Tipomov,Observaciones,Wdate,Marca,Lote) "
                                        SQLCnslt = SQLCnslt & "VALUES('" & CodMovVar & "', '" & CodMovVar & "', '" & Renglon & "', '" & Fecha & "', '" & Tipo & "', '" & Articulo & "', "
                                        SQLCnslt = SQLCnslt & "'" & Terminado & "', '" & Cantidad & "', '" & Fechaord & "', '" & Movi & "', '" & Tipomov & "', '" & Observaciones & "', "
                                        SQLCnslt = SQLCnslt & "'" & WDate & "', '" & Marca & "', '" & Lote & "')"

                                        listaSQLCnslt.Add(SQLCnslt)
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Renglon += 1

        Next

        ExecuteNonQueries(listaSQLCnslt.ToArray())

        _LimpiarForm()

    End Sub

    Private Function _AQueEmpresa(ByVal Empresa As String) As String
        If (Empresa = "1") Then
            Return "SurfactanSa"
        End If
        If (Empresa = "2") Then
            Return "Surfactan_II"
        End If
        If (Empresa = "3") Then
            Return "Surfactan_III"
        End If
        If (Empresa = "4") Then
            Return "Surfactan_IV"
        End If
        If (Empresa = "5") Then
            Return "Surfactan_V"
        End If
        If (Empresa = "6") Then
            Return "Surfactan_VI"
        End If
        If (Empresa = "7") Then
            Return "Surfactan_VII"
        End If
        If (Empresa = "8") Then
            Return "PellitalSa"
        End If
        If (Empresa = "9") Then
            Return "Pelitall_II"
        End If
        If (Empresa = "10") Then
            Return "Pellital_III"
        End If

        Return "Pellital_V"

    End Function

    Private Sub btnVolver_PnlProveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolver_PnlProveedores.Click
        pnlBuscarProveedor.Visible = False
    End Sub

    Private Sub btnBuscarProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProv.Click
        txtBuscardorProv.Text = ""
        Dim SQLCnslt As String
        SQLCnslt = "SELECT CodigoProv = Proveedor, DescripcionProv = Nombre FROM Proveedor WHERE TipoProv = 4 or TipoProv = 2 or TipoProv = 31 ORDER BY Nombre "
        Dim tablaProv As DataTable = GetAll(SQLCnslt)
        DGV_Proveedores.DataSource = tablaProv
        pnlBuscarProveedor.Visible = True
        txtBuscardorProv.Focus()
    End Sub

    Private Sub DGV_Proveedores_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Proveedores.CellDoubleClick
        txtProveedor.Text = DGV_Proveedores.CurrentRow.Cells("CodigoProv").Value
        pnlBuscarProveedor.Visible = False
        txtProveedor_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        txtDescripcionProv.Text = DGV_Proveedores.CurrentRow.Cells("DescripcionProv").Value
    End Sub


    Private Sub txtBuscardorProv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscardorProv.KeyUp
        Dim tabla As DataTable = DGV_Proveedores.DataSource
        tabla.DefaultView.RowFilter = "CodigoProv LIKE '%" & txtBuscardorProv.Text & "%' OR DescripcionProv LIKE '%" & txtBuscardorProv.Text & "%'"
        DGV_Proveedores.DataSource = tabla
    End Sub

    Private Sub mastxtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mastxtFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(mastxtFecha.Text) = "S" Then
                    txtOrdenCompra.Focus()
                Else
                    mastxtFecha.Focus()
                End If
            Case Keys.Escape
                mastxtFecha.Text = ""
        End Select
    End Sub

    Private Sub txtRemito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemito.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txtRemito.Text = ""
        End Select
    End Sub
End Class