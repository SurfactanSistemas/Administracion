Public Class CerrarProveedorSelectivoWeb

    Private WIDSelectivo As Integer = 0
    Private WActualizar As Boolean = False

    Private Sub txtMensaje_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMensaje.KeyUp
        lblRestantes.Text = String.Format("{0} / 200", 200 - txtMensaje.Text.Length)
    End Sub

    Private Sub CerrarProveedorSelectivoWeb_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim WSelectivoWebConfig As DataRow = GetSingle("SELECT * FROM ProveedorSelectivoWebConfig WHERE ISNULL(Habilitado, '0') = '1'")

        txtFechaInicio.Text = ""
        txtFechaPago.Text = ""
        txtMensaje.Text = ""
        WIDSelectivo = 0
        WActualizar = False

        If WSelectivoWebConfig IsNot Nothing Then

            WIDSelectivo = OrDefault(WSelectivoWebConfig.Item("ID"), 0)

            Dim WFecha As Date = Date.ParseExact(WSelectivoWebConfig.Item("FechaInicio"), "dd/MM/yyyy", Nothing)
            Dim WFechaPago As Date = Date.ParseExact(WSelectivoWebConfig.Item("FechaSelectivo"), "dd/MM/yyyy", Nothing)
            txtFechaInicio.Text = WFecha.ToString("dd/MM/yyyy")
            txtFechaPago.Text = WFechaPago.ToString("dd/MM/yyyy")
            txtMensaje.Text = Trim(OrDefault(WSelectivoWebConfig.Item("Mensaje"), ""))

            WActualizar = Val(ordenaFecha(Date.Now.ToString("dd/MM/yyyy"))) < Val(ordenaFecha(txtFechaInicio.Text))

        End If

        txtFechaInicio.Focus()

    End Sub

    Private Sub CerrarProveedorSelectivoWeb_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtFechaInicio.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub CerrarProveedorSelectivoWeb_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing AndAlso Not WActualizar Then
            e.Cancel = MsgBox("¿Está seguro de querer salir?", MsgBoxStyle.YesNo) = MsgBoxResult.No
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        If txtFechaInicio.Text.Replace(" ", "").Length < 10 AndAlso Not _ValidarFecha(txtFechaInicio.Text) Then
            MsgBox("Debe cargar una Fecha de Inicio válida.", MsgBoxStyle.Exclamation)
            txtFechaInicio.Focus()
            Exit Sub
        End If

        If txtFechaPago.Text.Replace(" ", "").Length < 10 AndAlso Not _ValidarFecha(txtFechaPago.Text) Then
            MsgBox("Debe cargar una Fecha de Pago válida.", MsgBoxStyle.Exclamation)
            txtFechaPago.Focus()
            Exit Sub
        End If

        If Not WActualizar AndAlso MsgBox("¿Está seguro de querer realizar la apertura al " & txtFechaInicio.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            txtFechaInicio.Focus()
            Exit Sub
        End If

        Dim WSql As String = ""

        WSql = String.Format("INSERT INTO ProveedorSelectivoWebConfig (FechaSelectivo, Habilitado, Mensaje, FechaInicio) VALUES ('{0}', '1', '{1}', '{2}')", txtFechaPago.Text, txtMensaje.Text, txtFechaInicio.Text)

        If WIDSelectivo <> 0 And WActualizar Then
            WSql = String.Format("UPDATE ProveedorSelectivoWebConfig SET FechaSelectivo = '{0}', Habilitado = '1', Mensaje = '{1}', FechaInicio = '{2}' WHERE ID = '{3}'", txtFechaPago.Text, txtMensaje.Text, txtFechaInicio.Text, WIDSelectivo)
        End If

        ExecuteNonQueries({"UPDATE ProveedorSelectivoWebConfig SET Habilitado = '0'", WSql})

        If Not WActualizar Then MsgBox("Se ha abierto un nuevo periodo para Proveedores Selectivo por Web que comienza el " & txtFechaInicio.Text)

        Close()

    End Sub
End Class