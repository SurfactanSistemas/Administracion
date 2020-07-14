﻿Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class PreciosClienteProducto

    Sub New(Optional ByVal Cliente As String = "", Optional Producto As String = "", Optional ByVal Reventa As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        btnLimpiar_Click(Nothing, Nothing)

        rbTerminado.Checked = Not Reventa
        rbReventa.Checked = Reventa

        rbTerminado_MouseClick(Nothing, Nothing)

        txtCliente.Text = Cliente

        txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        txtProducto.Text = Producto

        If {12, 10}.Contains(Producto.Replace(" ", "").Length) Then txtProducto_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Sub PreciosClienteProducto_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If txtCliente.Text = "" Then

            If {12, 10}.Contains(txtProducto.Text.Replace(" ", "").Length) Then
                txtPrecio.Focus()
            Else
                txtCliente.Focus()
            End If

        Else
            txtProducto.Focus()
        End If
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) = "" Then : Exit Sub : End If

            lblRazon.Text = ""

            Dim WDatos As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            If WDatos Is Nothing Then Exit Sub

            lblRazon.Text = Trim(OrDefault(WDatos("Razon"), ""))

            txtProducto.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescripcion.Text = "DESCRIPCIÓN"
            lblDescripcion2.Text = ""

            Dim WProducto As String = txtProducto.Text.Replace(" ", "")
            If (rbTerminado.Checked And WProducto.Length < 12) Or (rbReventa.Checked And WProducto.Length < 10) Then : Exit Sub : End If

            Dim WDatos As DataRow = Nothing

            Dim WColumnasFac As String = ""

            For i = 1 To 5
                WColumnasFac &= String.Format("{1}.Fecha{0}, {1}.Factura{0}, {1}.Precio{0}, {1}.Cantidad{0},", i, IIf(rbTerminado.Checked, "p", "pmp"))
            Next

            If rbTerminado.Checked Then
                WDatos = GetSingle("SELECT " & WColumnasFac & " p.Precio, p.Fecha, p.Estado, p.Pago, p.Descripcion, p.DescripcionFarma, DescProd = t.Descripcion FROM Precios p INNER JOIN Terminado t ON t.Codigo = p.Terminado WHERE p.Terminado = '" & txtProducto.Text & "' and p.Cliente = '" & txtCliente.Text & "'")
            Else
                WDatos = GetSingle("SELECT " & WColumnasFac & " pmp.Precio, pmp.Fecha, pmp.Estado, pmp.Pago, Descripcion = CASE LTRIM(RTRIM(a.DescriComercial)) WHEN '' THEN a.Descripcion ELSE a.DescriComercial END, DescProd = a.Descripcion FROM Preciosmp pmp INNER JOIN Articulo a ON a.Codigo = pmp.Articulo WHERE pmp.articulo = '" & txtProducto.Text & "' AND pmp.cliente = '" & txtCliente.Text & "'")
            End If

            If WDatos IsNot Nothing Then

                txtPrecio.Text = formatonumerico(OrDefault(WDatos("Precio"), ""))
                txtDescComercial.Text = OrDefault(WDatos("Descripcion"), "")
                lblDescProducto.Text = OrDefault(WDatos("DescProd"), "")

                With lblUltimaActualizacion

                    .Text = OrDefault(WDatos("Fecha"), "  /  /    ")

                    .Text = Helper.Mid(.Text, 4, 2) & "/" & Helper.Left(.Text, 2) & "/" & Helper.Right(.Text, 4)

                End With

                cmbEstado.SelectedIndex = Val(OrDefault(WDatos("Estado"), ""))

                txtCondicionPago.Text = OrDefault(WDatos("Pago"), "")

                If Val(txtCondicionPago.Text) = 0 Then txtCondicionPago.Text = ""

                txtCondicionPago_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

                Dim codigo As String = Mid(txtProducto.Text, 4, 5)

                If Val(codigo) >= 25000 And Val(codigo) <= 25999 Then
                    txtDescComercial.Text = OrDefault(WDatos("DescripcionFarma"), "")
                    lblDescripcion.Text = "DESC ADIC."
                    lblDescripcion2.Text = "2° Renglon Etiq."
                End If

                dgvFacturas.Rows.Clear()

                For i = 1 To 5
                    Dim WFecha, WFactura, WPrecio, WCantidad As String

                    WFecha = OrDefault(WDatos("Fecha" & i), "")
                    WFactura = OrDefault(WDatos("Factura" & i), "")

                    WFactura = WFactura.Ceros(6)

                    WPrecio = formatonumerico(OrDefault(WDatos("Precio" & i), ""))
                    WCantidad = formatonumerico(OrDefault(WDatos("Cantidad" & i), 0))

                    If Val(WFactura) = 0 Then Continue For

                    dgvFacturas.Rows.Add(WFecha, WFactura, WPrecio, WCantidad)
                Next

            End If

            txtPrecio.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtProducto.Text = ""
        End If

    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtPrecio.Text) < 0 Then : Exit Sub : End If

            txtDescComercial.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPrecio.Text = ""
        End If

    End Sub

    Private Sub txtDescComercial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescComercial.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtDescComercial.Text) = "" Then : Exit Sub : End If

            txtCondicionPago.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescComercial.Text = ""
        End If

    End Sub

    Private Sub cmbEstado_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEstado.DropDownClosed
        txtDescComercial.Focus()
    End Sub

    Private Sub txtCondicionPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCondicionPago.KeyDown

        If e.KeyData = Keys.Enter Then

            Dim WCondPago As DataRow = GetSingle("SELECT Nombre FROM Pago WHERE Pago = '" & txtCondicionPago.Text & "'")

            lblDescPago.Text = ""

            If WCondPago Is Nothing Then Exit Sub

            lblDescPago.Text = Trim(OrDefault(WCondPago("Nombre"), ""))

        ElseIf e.KeyData = Keys.Escape Then
            txtCondicionPago.Text = ""
            lblDescPago.Text = ""
        End If

    End Sub

    Private Sub rbTerminado_MouseClick(sender As Object, e As MouseEventArgs) Handles rbTerminado.MouseClick, rbReventa.MouseClick
        txtProducto.Mask = IIf(rbTerminado.Checked, ">LL-00000-000", ">LL-000-000")
        txtProducto.Focus()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        
        Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click


        Dim WOwner As INotificacionCambios = TryCast(Owner, INotificacionCambios)

        If WOwner IsNot Nothing Then WOwner.NotificarCambios()

        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtCondicionPago, txtDescComercial, txtPrecio, txtProducto, lblDescPago, lblDescProducto, lblDescripcion2, lblRazon, lblRazon, lblUltimaActualizacion}
            c.Text = ""
        Next
    End Sub

    Private Sub PreciosClienteProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not {12, 10}.Contains(txtProducto.Text.Replace(" ", "").Length) Then btnLimpiar_Click(Nothing, Nothing)
    End Sub
End Class