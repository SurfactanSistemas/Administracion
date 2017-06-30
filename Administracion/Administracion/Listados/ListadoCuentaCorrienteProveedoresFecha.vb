Imports ClasesCompartidas
Imports System.IO

Public Class ListadoCuentaCorrienteProveedoresFecha

    Private Sub ListadoCuentaCorrienteProveedoresFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesdeProveedor.Text = ""
        txtFechaEmision.Text = "  /  /    "
        opcPantalla.Checked = False
        opcImpesora.Checked = True
    End Sub

    Private Sub txtfechaemision_KeyPress(ByVal sender As Object, _
               ByVal e As System.Windows.Forms.KeyPressEventArgs) _
               Handles txtFechaEmision.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If ValidaFecha(txtFechaEmision.Text) = "S" Then
                txtDesdeProveedor.Focus()
            End If
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtFechaEmision.Text = "  /  /    "
            Me.txtFechaEmision.SelectionStart = 0
        End If
    End Sub

    Private Sub txtdesdeproveedor_KeyPress(ByVal sender As Object, _
                    ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                    Handles txtDesdeProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            ' DADA que no rompa cuando el codigo no existe y usar la funcion "ceros" para completar??
            Dim CampoProveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtDesdeProveedor.Text)
            txtRazon.Text = CampoProveedor.razonSocial
            txtRazon.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtRazon.Focus()
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        Me.Size = New System.Drawing.Size(643, 490)

        lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre("")

        txtAyuda.Text = ""
        txtAyuda.Visible = True
        lstAyuda.Visible = True

        txtAyuda.Focus()

    End Sub

    Private Sub txtAyuda_KeyPress(ByVal sender As Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                   Handles txtAyuda.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre(txtAyuda.Text)
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtAyuda.Text = ""
        End If
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        txtDesdeProveedor.Text = proveedor.id
        REM txtHastaProveedor.Text = proveedor.id
        txtDesdeProveedor.Focus()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub


    Private Sub btnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcepta.Click

        Dim txtUno, txtDos As String

        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim WSuma As Double
        Dim WOrden As Integer
        Dim txtCorte As String = ""
        Dim txtLLave As Integer = 0
        Dim txtEmpresa As String

        Dim varOrdFecha As String
        Dim varProveedor, varLetra, VarTipo, varPunto, varNumero As String
        Dim varClave As String
        Dim varDada As Integer

        SQLConnector.retrieveDataTable("limpiar_impCtaCtePrvNet")


        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo
        Dim WTipo As Char
        WTipo = "T"

        txtEmpresa = "Surfactan S.A."

        varOrdFecha = ordenaFecha(txtFechaEmision.Text)




        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_desdehasta", txtDesdeProveedor.Text, txtDesdeProveedor.Text, WTipo)

        For Each row As DataRow In tabla.Rows

            Dim CCPrv As New CtaCteProveedoresDeudaDesdeHasta(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString, row.Item(9).ToString, row.Item(10), row.Item(11).ToString, row.Item(12).ToString)

            If ordenaFecha(CCPrv.fecha) <= varOrdFecha Then
                vardada = vardada + 1
                SQLConnector.executeProcedure("alta_impCtaCtePrvNet", CCPrv.Clave, CCPrv.Proveedor, CCPrv.Tipo, CCPrv.letra, CCPrv.punto, CCPrv.numero, CCPrv.total, CCPrv.saldo, CCPrv.fecha, CCPrv.vencimiento, txtFechaEmision.Text, CCPrv.Impre, CCPrv.nroInterno, txtEmpresa, WSuma, WOrden, txtFechaEmision.Text, "", "", "", 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0)
            End If

        Next





        Dim tablaII As DataTable
        tablaII = SQLConnector.retrieveDataTable("buscar_pagos_fecha_Proveedor", txtDesdeProveedor.Text, txtDesdeProveedor.Text, varOrdFecha)

        For Each row As DataRow In tablaII.Rows

            Dim CampoPagos As New LeePagos(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString,
                                           row.Item(3), row.Item(4).ToString, row.Item(5).ToString,
                                           row.Item(6).ToString, row.Item(7).ToString, row.Item(8).ToString,
                                           row.Item(9), row.Item(10), row.Item(11), row.Item(12),
                                           row.Item(13), row.Item(14), row.Item(15), row.Item(16), row.Item(17),
                                           row.Item(18), row.Item(19), row.Item(20), row.Item(21))

            varProveedor = CampoPagos.proveedor
            varLetra = CampoPagos.letra1
            VarTipo = CampoPagos.tipo1
            varPunto = CampoPagos.punto1
            varNumero = CampoPagos.numero1

            varClave = ceros(varProveedor, 11) + varLetra + ceros(VarTipo, 2) + ceros(varPunto, 4) + ceros(varNumero, 8)

            SQLConnector.executeProcedure("modificar_saldo_impctacteprv", varClave, CampoPagos.importe1)

        Next






        Dim tablaIII As DataTable
        tablaIII = SQLConnector.retrieveDataTable("buscar_pagos_fecha_Proveedor", txtDesdeProveedor.Text, txtDesdeProveedor.Text, varOrdFecha)

        For Each row As DataRow In tablaIII.Rows

            Dim CampoAplica As New LeeAplicaProve(row.Item(0), row.Item(1), row.Item(2),
                                           row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7).ToString,
                                           row.Item(8), row.Item(9), row.Item(10))

            varProveedor = CampoAplica.proveedor
            varLetra = CampoAplica.letra
            VarTipo = CampoAplica.tipo
            varPunto = CampoAplica.punto
            varNumero = CampoAplica.numero

            varClave = ceros(varProveedor, 11) + varLetra + ceros(VarTipo, 2) + ceros(varPunto, 4) + ceros(varNumero, 8)

            SQLConnector.executeProcedure("modificar_saldo_impctacteprv", varClave, CampoAplica.importe)

        Next



        txtUno = "{impCtaCtePrvNet.Proveedor} in " + x + "" + x + " to " + x + "ZZZZZZZZZZZ" + x
        txtDos = " and {impCtaCtePrvNet.Saldo} <> 0.00"
        txtFormula = txtUno + txtDos

        Dim viewer As New ReportViewer("Listado de Corriente de Proveedres a Fecha", Globals.reportPathWithName("wccprvfecnet.rpt"), txtFormula)

        If opcPantalla.Checked = True Then
            viewer.Show()
        Else
            viewer.imprimirReporte()
        End If


    End Sub

End Class