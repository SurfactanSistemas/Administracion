Public Class IngresoDatosFCE : Implements IAyudaProveedores

    Property DatosFCE As DataRow

    Sub New(ByVal DatosFCE As DataRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DatosFCE = DatosFCE

        If Me.DatosFCE Is Nothing Then
            Dim tabla As New DataTable
            With tabla.Columns
                .Add("Boleto")
                .Add("Proveedor")
                .Add("Interes")
                .Add("Aranceles")
                .Add("IvaAranceles")
                .Add("Derechos")
                .Add("IvaDerechos")
                .Add("IVAPercepcion")
            End With

            Me.DatosFCE = tabla.NewRow

        End If

        For Each c As Control In {txtAranceles, txtDerechos, txtInteres, txtIvaAranceles, txtIvaDerechos, txtIVAPercepcion}
            AddHandler c.KeyPress, AddressOf NumerosConComas
        Next

        For Each c As Control In {txtBoleto, txtProveedor}
            AddHandler c.KeyPress, AddressOf SoloNumero
        Next

    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub IngresoDatosFCE_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        For Each c As Control In {txtAranceles, txtBoleto, txtDerechos, txtInteres, txtIvaAranceles, txtIvaDerechos, txtProveedor, lblDescProveedor}
            c.Text = ""
        Next

        If DatosFCE IsNot Nothing Then
            With DatosFCE
                txtBoleto.Text = OrDefault(.Item("Boleto"), "")

                txtProveedor.Text = OrDefault(.Item("Proveedor"), "")

                txtInteres_KeyDown(txtProveedor, New KeyEventArgs(Keys.Enter))

                txtInteres.Text = formatonumerico(OrDefault(.Item("Interes"), "0"))
                txtAranceles.Text = formatonumerico(OrDefault(.Item("Aranceles"), "0"))
                txtIvaAranceles.Text = formatonumerico(OrDefault(.Item("IvaAranceles"), "0"))
                txtDerechos.Text = formatonumerico(OrDefault(.Item("Derechos"), "0"))
                txtIvaDerechos.Text = formatonumerico(OrDefault(.Item("IvaDerechos"), "0"))
                txtIVAPercepcion.Text = formatonumerico(OrDefault(.Item("IVAPercepcion"), "0"))
            End With

        End If

        txtBoleto.Focus()

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub IngresoDatosFCE_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtBoleto.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        For Each c As Control In {txtAranceles, txtDerechos, txtInteres, txtIvaAranceles, txtIvaDerechos, txtIVAPercepcion}
            c.Text = formatonumerico(c.Text)
        Next

        DialogResult = Windows.Forms.DialogResult.None

        '
        ' Validamos los datos.
        '
        If Trim(txtBoleto.Text) = "" Then
            MsgBox("Debe indicarse el N° de Boleto", MsgBoxStyle.Exclamation)
            txtBoleto.Focus()
            Exit Sub
        End If

        Dim WProv As DataRow = GetSingle("SELECT Proveedor FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'")

        If txtProveedor.Text = "" OrElse WProv Is Nothing Then
            MsgBox("Debe indicarse un Proveedor válido", MsgBoxStyle.Exclamation)
            txtProveedor.Focus()
            Exit Sub
        End If

        If Val(txtInteres.Text) = 0 Then
            MsgBox("Debe indicarse el Interés.", MsgBoxStyle.Exclamation)
            txtInteres.Focus()
            Exit Sub
        End If

        DialogResult = Windows.Forms.DialogResult.OK

        With DatosFCE
            For Each c As Control In {txtBoleto, txtProveedor}
                .Item(c.Name.Replace("txt", "")) = c.Text
            Next

            For Each c As Control In {txtAranceles, txtDerechos, txtInteres, txtIvaAranceles, txtIvaDerechos, txtIVAPercepcion}
                .Item(c.Name.Replace("txt", "")) = Val(formatonumerico(c.Text))
            Next
        End With

    End Sub

    Private Sub txtInteres_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtIvaDerechos.Leave, txtIvaAranceles.Leave, txtInteres.Leave, txtDerechos.Leave, txtAranceles.Leave, txtIVAPercepcion.Leave
        With CType(sender, TextBox)
            .Text = formatonumerico(.Text)

            If .Name = "txtAranceles" Or .Name = "txtDerechos" Then
                Controls("txtIva" & .Name.Replace("txt", "")).Text = formatonumerico(Val(.Text) * 0.21)
            End If
        End With

    End Sub

    Private Sub txtInteres_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtProveedor.KeyDown, txtIvaDerechos.KeyDown, txtIvaAranceles.KeyDown, txtInteres.KeyDown, txtDerechos.KeyDown, txtBoleto.KeyDown, txtAranceles.KeyDown, txtIVAPercepcion.KeyDown

        Dim WControl As Control = CType(sender, TextBox)

        If e.KeyData = Keys.Enter Then
            Dim WDestino As Control = Nothing

            Select Case WControl.Name.Replace("txt", "")
                Case "Boleto"
                    WDestino = txtProveedor
                Case "Proveedor"

                    Dim WProv As DataRow = GetSingle("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & txtProveedor.Text & "'")
                    If WProv IsNot Nothing Then lblDescProveedor.Text = Trim(OrDefault(WProv.Item("Nombre"), ""))

                    WDestino = IIf(WProv IsNot Nothing, txtInteres, Nothing)

                Case "Interes"
                    WDestino = txtAranceles
                Case "Aranceles"
                    WDestino = txtDerechos
                Case "Derechos"
                    WDestino = txtIVAPercepcion
                Case "IVAPercepcion"
                    WDestino = txtBoleto
            End Select

            If WDestino IsNot Nothing Then WDestino.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            CType(sender, TextBox).Text = ""
        End If

    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick
        btnAyudaProveedores.PerformClick()
    End Sub

    Private Sub btnAyudaProveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyudaProveedores.Click
        With New AyudaProveedores
            .ShowDialog(Me)
        End With
        txtInteres_KeyDown(txtProveedor, New KeyEventArgs(Keys.Enter))
    End Sub

    Public Sub _ProcesarAyudaProveedores(ByVal Proveedor As String, ByVal Nombre As String) Implements IAyudaProveedores._ProcesarAyudaProveedores
        txtProveedor.Text = Proveedor
    End Sub
End Class