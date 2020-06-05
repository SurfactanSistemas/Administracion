Imports ClasesCompartidas
Imports Util

Public Class ListadoCuentaCorrienteProveedores : Implements IAyudaGeneral

    Enum Reporte
        Imprimir
        Pantalla
    End Enum

    Private Sub ListadoCuentaCorrienteProveedores_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label2.Text = Globals.NombreEmpresa()
        txtDesdeProveedor.Text = "0"
        txtHastaProveedor.Text = "99999999999"
        opcPendiente.Checked = True
        opcCompleto.Checked = False

        _PurgarSaldosCtaCtePrvs()
    End Sub

    Private Sub btnCancela_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancela.Click
        Close()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsulta.Click

        With New AyudaGeneral(GetAll("SELECT Proveedor Codigo, Nombre Descripcion FROM Proveedor ORDER BY Nombre"), "LISTADO DE PROVEEDORES DISPONIBLES")
            .Show(Me)
        End With

    End Sub
    
    Private Sub _Imprimir(ByVal TipoImpresion As Reporte)
        Dim txtUno As String

        Dim txtFormula As String
        Dim x As Char = Chr(34)
        Dim WSuma As Double
        Dim WOrden As Integer
        Dim txtCorte = ""
        Dim txtLLave = 0
        Dim txtEmpresa As String

        SQLConnector.retrieveDataTable("limpiar_impCtaCtePrvNet")


        REM Reviso el cual esta checkeado asi le pongo los valores a Tipo
        Dim WTipo As Char
        WTipo = "T"
        If (opcPendiente.Checked) Then
            WTipo = "P"
        End If

        txtEmpresa = "Surfactan S.A."

        If _EsPellital() Then
            txtEmpresa = "Pellital S.A."
        End If

        Dim tabla As DataTable
        'tabla = SQLConnector.retrieveDataTable("buscar_cuenta_corriente_proveedores_desdehasta", txtDesdeProveedor.Text, txtHastaProveedor.Text, WTipo)

        Dim WFiltro As String = IIf(opcCompleto.Checked, "", " And Saldo <> 0")

        tabla = GetAll("SELECT Tipo, Letra, Punto, Numero, Total, Saldo, fecha, Vencimiento, Vencimiento1, Impre, NroInterno, Clave, Proveedor FROM CtactePrv WHERE ISNULL(MarcaVirtual, '') <> 'X' " & WFiltro & " ORDER BY Proveedor, OrdFecha, Tipo, Numero")

        For Each row As DataRow In tabla.Rows

            Dim CCPrv As New CtaCteProveedoresDeudaDesdeHasta(row.Item("Tipo").ToString, row.Item("Letra").ToString, row.Item("Punto").ToString, row.Item("Numero").ToString, row.Item("Total"), row.Item("Saldo"), row.Item("Fecha").ToString, row.Item("Vencimiento").ToString, row.Item("Vencimiento1").ToString, row.Item("Impre").ToString, row.Item("NroInterno"), row.Item("Clave").ToString, row.Item("Proveedor").ToString)

            If ckSoloAnticipos.Checked And UCase(CCPrv.Impre) <> "AN" Then Continue For

            If txtLLave = 0 Then
                txtLLave = 1
                txtCorte = CCPrv.Proveedor
                WSuma = 0
                WOrden = 0
            End If

            If txtCorte <> CCPrv.Proveedor Then
                txtCorte = CCPrv.Proveedor
                WSuma = 0
                WOrden = 0
            End If

            WSuma = WSuma + CCPrv.saldo
            WOrden = WOrden + 1
            SQLConnector.executeProcedure("alta_impCtaCtePrvNet", CCPrv.Clave, CCPrv.Proveedor, CCPrv.Tipo, CCPrv.letra, CCPrv.punto, CCPrv.numero, CCPrv.total, CCPrv.saldo, CCPrv.fecha, CCPrv.vencimiento, CCPrv.VencimientoII, CCPrv.Impre, CCPrv.nroInterno, txtEmpresa, WSuma, WOrden, "", "", "", "", 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0)

        Next

        Dim WDesde, WHasta

        WDesde = txtDesdeProveedor.Text
        WHasta = txtHastaProveedor.Text

        If Trim(WDesde) = "" Then
            WDesde = "0"
        End If

        If Trim(WHasta) = "" Then
            WHasta = "99999999999"
        End If

        txtUno = "{ImpCtaCtePrvNet.Proveedor} in " & x & WDesde & x & " to " & x & WHasta & x
        txtFormula = txtUno

        With New VistaPrevia
            .Reporte = New wccprvnet()
            .Formula = txtFormula

            Select Case TipoImpresion
                Case Reporte.Imprimir
                    .Imprimir()
                Case Reporte.Pantalla
                    .Mostrar()
            End Select

        End With

    End Sub

    Private Sub txtDesdeProveedor_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtDesdeProveedor.MouseDoubleClick, txtHastaProveedor.MouseDoubleClick
        btnConsulta.PerformClick()
    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtDesdeProveedor.KeyPress, txtHastaProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPorPantalla_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPorPantalla.Click
        _Imprimir(Reporte.Pantalla)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimir.Click
        _Imprimir(Reporte.Imprimir)
    End Sub

    Private Sub txtDesdeProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDesdeProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesdeProveedor.Text) = "" Then : Exit Sub : End If

            txtHastaProveedor.Text = txtDesdeProveedor.Text

        ElseIf e.KeyData = Keys.Escape Then
            txtDesdeProveedor.Text = ""
        End If

    End Sub

    Private Sub txtHastaProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHastaProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHastaProveedor.Text) = "" Then : Exit Sub : End If

            txtDesdeProveedor.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaProveedor.Text = ""
        End If

    End Sub

    Public Sub _ProcesarAyudaGeneral(row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        txtDesdeProveedor.Text = row.Cells("Codigo").Value
        txtHastaProveedor.Text = txtDesdeProveedor.Text
        txtHastaProveedor.Focus()
    End Sub
End Class