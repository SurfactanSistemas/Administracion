Public Class IngresoDatosMostrarEnCertificadosAnalisis
    Private CerrarDspGrabar As Boolean = False
    Sub New(Optional ByVal Terminado As String = "", Optional ByVal Cliente As String = "", Optional ByVal CerrarDspGrabar As Boolean = False)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtProducto.Text = Terminado
        txtCliente.Text = Cliente
        Me.CerrarDspGrabar = CerrarDspGrabar
    End Sub
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        lblDescCliente.Text = ""
        lblDescProducto.Text = ""
        txtCliente.Text = ""
        txtProducto.Text = ""
        If dgvDatos.DataSource IsNot Nothing Then DirectCast(dgvDatos.DataSource, DataTable).Rows.Clear()

        txtProducto.Focus()
    End Sub

    Private Sub IngresoDatosMostrarEnCertificadosAnalisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If txtProducto.Text.Replace(" ", "").Length = 12 And txtCliente.Text.Replace(" ", "").Length = 6 Then
            txtProducto_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
            txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        Else
            btnLimpiar_Click(Nothing, Nothing)
        End If

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
            Dim WCert As DataTable = Nothing

            If Operador.Base = "Surfactan_III" Then
                WCert = GetAll("select cv.Ensayo, Descripcion = TRIM(e.Descripcion), Valor = TRIM(cv.Valor), acf.Marca FROM CargaV cv LEFT OUTER JOIN AltaCertificadoFarma acf ON acf.Terminado = cv.Terminado And acf.Renglon = cv.Renglon and acf.cliente = '" & txtCliente.Text & "' LEFT OUTER JOIN SurfactanSa.dbo.Cliente c ON c.Cliente = acf.Cliente LEFT OUTER JOIN Surfactan_II.dbo.Ensayos e ON e.Codigo = cv.Ensayo WHERE cv.Terminado = '" & txtProducto.Text & "' and cv.Paso = '99' order by cv.Renglon")
            Else
                Dim WTemp As DataTable = GetAll("SELECT Ensayo1, Ensayo2, Ensayo3, Ensayo4, Ensayo5, Ensayo6, Ensayo7, Ensayo8, Ensayo9, Ensayo10, Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10, Valor11, Valor22, Valor33, Valor44, Valor55, Valor66, Valor77, Valor88, Valor99, Valor1010 FROM EspecifUnifica WHERE Producto = '" & txtProducto.Text & "'", "Surfactan_II")

                If WTemp.Rows.Count > 0 Then

                    WCert = New DataTable
                    For Each c As String In {"Ensayo", "Descripcion", "Valor", "Marca"}
                        WCert.Columns.Add(c)
                    Next

                    For i = 1 To 10
                        With WTemp.Rows(0)
                            If Val(OrDefault(.Item("Ensayo" & i), "")) Then WCert.Rows.Add(.Item("Ensayo" & i), "", Trim(.Item("Valor" & i)) & " " & Trim(.Item("Valor" & i & i)), "")
                        End With
                    Next

                    For i = WCert.Rows.Count To 10
                        With WTemp.Rows(0)
                            WCert.Rows.Add("", "", "", "")
                        End With
                    Next

                    For i = 0 To 9
                        With WCert.Rows(i)
                            If Val(.Item("Ensayo")) <> 0 Then
                                Dim ens As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & .Item("Ensayo") & "'", "Surfactan_II")
                                If ens IsNot Nothing Then .Item("Descripcion") = Trim(OrDefault(ens.Item("Descripcion"), ""))
                            End If
                        End With
                    Next

                    Dim WMarcas As DataRow = GetSingle("SELECT Opcion1, Opcion2, Opcion3, Opcion4, Opcion5, Opcion6, Opcion7, Opcion8, Opcion9, Opcion10 FROM AltaCertificado WHERE Cliente = '" & txtCliente.Text & "' And Producto = '" & txtProducto.Text & "'", "Surfactan_II")

                    If WMarcas IsNot Nothing Then
                        For i = 1 To 10
                            If Val(OrDefault(WMarcas.Item("Opcion" & i), "")) = 1 Then WCert.Rows(i - 1).Item("Marca") = "S"
                        Next
                    End If

                End If

            End If

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

        If Operador.Base = "Surfactan_III" Then
            WSqls.Add("DELETE FROM AltaCertificadoFarma WHERE Terminado = '" & txtProducto.Text & "' And Cliente = '" & txtCliente.Text & "'")
        Else
            WSqls.Add("DELETE FROM AltaCertificado WHERE Producto = '" & txtProducto.Text & "' And Cliente = '" & txtCliente.Text & "'")
        End If

        Dim WTerminado, WClave, WCliente, WRenglon, WMarca As String
        
        WTerminado = txtProducto.Text
        WCliente = txtCliente.Text

        Dim WEmpresaGrabacion As String = Operador.Base

        If Operador.Base = "Surfactan_III" Then
            For Each row As DataGridViewRow In dgvDatos.Rows

                With row
                    WRenglon = (.Index + 1).ToString.PadLeft(2, "0")
                    WMarca = OrDefault(.Cells("Marca").Value, "")
                End With

                WClave = WTerminado & WCliente & WRenglon

                WSqls.Add(String.Format("INSERT INTO AltaCertificadoFarma (Clave, Terminado, Cliente, Renglon, Marca) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", WClave, WTerminado, WCliente, WRenglon, WMarca))

            Next

            WSqls.Add("UPDATE AltaCertificado SET Observacion1 = '', Observacion2 = '', Observacion3 = '', Observacion4 = '', Observacion5 = '', Observacion6 = '', Observacion7 = '', Observacion8 = '', Observacion9 = '', Observacion10 = '' WHERE Terminado = '" & WTerminado & "' And Cliente = '" & WCliente & "'")

        Else

            Dim WColumnas As String = "Opcion1, Opcion2, Opcion3, Opcion4, Opcion5, Opcion6, Opcion7, Opcion8, Opcion9, Opcion10"
            Dim WDatos As String = ""

            For i = 0 To 9
                WDatos &= "'" & IIf(dgvDatos.Rows(i).Cells("Marca").Value = "S", "1", "") & "',"
            Next

            WDatos = WDatos.TrimEnd(",")

            WClave = WTerminado & WCliente

            WSqls.Add(String.Format("INSERT INTO AltaCertificado (Clave, Producto, Cliente, {0}) VALUES ('{1}', '{2}', '{3}', {4})", WColumnas, WClave, WTerminado, WCliente, WDatos))

            WEmpresaGrabacion = "Surfactan_II"

        End If

        ExecuteNonQueries(WEmpresaGrabacion, WSqls.ToArray)

        If Me.CerrarDspGrabar Then
            btnCerrar_Click(Nothing, Nothing)
        Else
            btnLimpiar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub dgvDatos_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseClick
        If e.ColumnIndex = dgvDatos.Columns("Marca").Index Then

            With dgvDatos.CurrentCell
                .Value = IIf(OrDefault(.Value, "") = "S", "", "S")
            End With

        End If
    End Sub
End Class