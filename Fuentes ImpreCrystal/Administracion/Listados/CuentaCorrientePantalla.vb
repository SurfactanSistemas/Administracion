Imports ClasesCompartidas
Imports System.IO

Public Class CuentaCorrientePantalla

    Dim dataGridBuilder As GridBuilder
    Dim Aa As Integer

    Private Sub txtproveedor_KeyPress(ByVal sender As Object, _
                    ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                    Handles txtProveedor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            Dim CampoProveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(txtProveedor.Text)
            txtRazon.Text = CampoProveedor.razonSocial
            Call Proceso()
            txtRazon.Focus()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            e.Handled = True
            txtRazon.Focus()
        End If
    End Sub

    Private Sub CuentaCorrientePantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dataGridBuilder = New GridBuilder(GRilla)

        opcPendiente.Checked = True
        opcCompleto.Checked = False

    End Sub

    Private Sub Proceso()

        Dim WRenglon As Integer
        Dim WSuma As Double

        GRilla.Rows.Clear()
        GRilla.Rows.Add()
        WRenglon = 0

        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo
        Dim WTipo As Char
        WTipo = "T"

        If (opcPendiente.Checked) Then
            WTipo = "P"
        End If
        WSuma = 0

        REM dada fix CAMBIAR Al uso de dao!!
        Dim tabla As DataTable
        tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_deuda", txtProveedor.Text, WTipo)

        For Each row As DataRow In tabla.Rows

            Dim CamposCtaCtePrv As New CtaCteProveedoresDeuda(row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4), row.Item(5), row.Item(6).ToString, row.Item(7).ToString)


            GRilla.Rows.Add()

            GRilla.Item(0, WRenglon).Value = CamposCtaCtePrv.Tipo
            GRilla.Item(1, WRenglon).Value = CamposCtaCtePrv.letra
            GRilla.Item(2, WRenglon).Value = CamposCtaCtePrv.punto
            GRilla.Item(3, WRenglon).Value = CamposCtaCtePrv.numero
            GRilla.Item(4, WRenglon).Value = formatonumerico(CamposCtaCtePrv.total, "########0.#0", ".")
            GRilla.Item(5, WRenglon).Value = formatonumerico(CamposCtaCtePrv.saldo, "########0.#0", ".")
            GRilla.Item(6, WRenglon).Value = CamposCtaCtePrv.fecha
            GRilla.Item(7, WRenglon).Value = CamposCtaCtePrv.vencimiento

            WRenglon = WRenglon + 1
            WSuma = WSuma + CamposCtaCtePrv.saldo

        Next


        GRilla.AllowUserToAddRows = False
        txtSaldo.Text = formatonumerico(WSuma, "########0.#0", ".")


    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click

        boxPantallaProveedores.Visible = True
        lstAyuda.DataSource = DAOProveedor.buscarProveedorPorNombre("")

        txtAyuda.Text = ""
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
        txtProveedor.Text = proveedor.id
        txtRazon.Text = proveedor.razonSocial
        boxPantallaProveedores.Visible = False
        Call Proceso()
    End Sub

    Private Sub lstAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAyuda.Click
        mostrarProveedor(lstAyuda.SelectedValue)
    End Sub
  
    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Me.Close()
        MenuPrincipal.Show()
    End Sub

    Private Sub opcCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcCompleto.CheckedChanged
        Call Proceso()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim opc As DialogResult = MsgBox("¿Desea salir de esta aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
        If opc = Windows.Forms.DialogResult.Yes Then
            Aa = 1
            'End
        Else
            'e.Cancel = True
            Aa = 2
        End If
        Stop
    End Sub

End Class