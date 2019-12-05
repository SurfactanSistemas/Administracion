Public Class IngresoDatosMostrarEnCertificadosAnalisis

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        lblDescCliente.Text = ""
        lblDescProducto.Text = ""
        txtCliente.Text = ""
        txtProducto.Text = ""
        If dgvDatos.DataSource IsNot Nothing Then DirectCast(dgvDatos.DataSource, DataTable).Rows.Clear()

        txtProducto.Focus()
    End Sub

    Private Sub IngresoDatosMostrarEnCertificadosAnalisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub IngresoDatosMostrarEnCertificadosAnalisis_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtProducto.Focus()
    End Sub

    Private Sub txtProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProducto.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtProducto.Text.Replace(" ", "").Length < 12 Then : Exit Sub : End If

            Dim WProd As DataRow = GetSingle("SELECT Descripcion FROM Terminado WHERE Codigo = '" & txtProducto.Text & "'")

            If WProd Is Nothing Then Exit Sub

            lblDescProducto.Text = Trim(OrDefault(WProd.Item("Descripcion"), ""))

            txtCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtProducto.Text = ""
            lblDescProducto.Text = ""
        End If

    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) = "" Then txtCliente.Text = "S00102"

            If dgvDatos.DataSource IsNot Nothing Then DirectCast(dgvDatos.DataSource, DataTable).Rows.Clear()
            lblDescCliente.Text = ""

            If txtProducto.Text.Replace(" ", "").Length < 12 Then Exit Sub

            '
            ' Cargamos Datos de Cliente.
            '
            Dim WCli As DataRow = GetSingle("SELECT Razon FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

            If WCli Is Nothing Then Exit Sub

            lblDescCliente.Text = Trim(OrDefault(WCli.Item("Razon"), ""))

            '
            ' Cargamos Datos que pueden salir en Certificado de Análisis.
            '
            Dim WCert As DataTable = GetAll("select cv.Ensayo, Descripcion = TRIM(e.Descripcion), Valor = TRIM(cv.Valor), acf.Marca FROM CargaV cv LEFT OUTER JOIN AltaCertificadoFarma acf ON acf.Terminado = cv.Terminado And acf.Renglon = cv.Renglon and acf.cliente = '" & txtCliente.Text & "' LEFT OUTER JOIN SurfactanSa.dbo.Cliente c ON c.Cliente = acf.Cliente LEFT OUTER JOIN Surfactan_II.dbo.Ensayos e ON e.Codigo = cv.Ensayo WHERE cv.Terminado = '" & txtProducto.Text & "' and cv.Paso = '99' order by cv.Renglon")

            dgvDatos.DataSource = WCert

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
            lblDescCliente.Text = ""
        End If

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If txtProducto.Text.Replace(" ", "").Length < 12 then Exit Sub
        If txtCliente.Text.Replace(" ", "").Length < 6 Then Exit Sub

        Dim WTer As DataRow = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & txtProducto.Text & "'")

        If WTer Is Nothing Then
            MsgBox("No se ha cargado un Producto Terminado válido", MsgBoxStyle.Exclamation)
            txtProducto.Focus()
            Exit Sub
        End If

        Dim WCli As DataRow = GetSingle("SELECT Cliente FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'")

        If WCli Is Nothing Then
            MsgBox("No se ha cargado un Cliente válido", MsgBoxStyle.Exclamation)
            txtCliente.Focus()
            Exit Sub
        End If

        Dim WSqls As New List(Of String)

        WSqls.Add("DELETE FROM AltaCertificadoFarma WHERE Terminado = '" & txtProducto.Text & "' And Cliente = '" & txtCliente.Text & "'")

        Dim WTerminado, WClave, WCliente, WRenglon, WMarca As String
        
        WTerminado = txtProducto.Text
        WCliente = txtCliente.Text

        For Each row As DataGridViewRow In dgvDatos.Rows
            With row
                WRenglon = (.Index + 1).ToString.PadLeft(2, "0")
                WMarca = OrDefault(.Cells("Marca").Value, "")
            End With

            WClave = WTerminado & WCliente & WRenglon

            WSqls.Add(String.Format("INSERT INTO AltaCertificadoFarma (Clave, Terminado, Cliente, Renglon, Marca) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", WClave, WTerminado, WCliente, WRenglon, WMarca))

        Next

        WSqls.Add("UPDATE AltaCertificadoFarma SET Observacion1 = '', Observacion2 = '', Observacion3 = '', Observacion4 = '', Observacion5 = '', Observacion6 = '', Observacion7 = '', Observacion8 = '', Observacion9 = '', Observacion10 = '' WHERE Terminado = '" & WTerminado & "' And Cliente = '" & WCliente & "'")

        ExecuteNonQueries(WSqls.ToArray)

        btnLimpiar_Click(Nothing, Nothing)

    End Sub

    Private Sub dgvDatos_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseClick
        If e.ColumnIndex = dgvDatos.Columns("Marca").Index Then

            With dgvDatos.CurrentCell
                .Value = IIf(OrDefault(.Value, "") = "S", "", "S")
            End With

        End If
    End Sub
End Class