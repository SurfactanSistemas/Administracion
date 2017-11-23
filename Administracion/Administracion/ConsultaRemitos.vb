Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class ConsultaRemitos

    Private Const SEPARADOR_DE_COLUMNAS = "    "

    Private Sub ConsultaRemitos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Limpiar()
    End Sub

    Private Sub _Limpiar()
        txtCodigoProveedor.Text = ""
        txtRemitos.Text = ""
        txtDescripcionProveedor.Text = ""
        LBRemitos.Visible = False

        _ListarProveedores()
    End Sub

    Private Sub _ListarProveedores()

        Dim proveedores As List(Of Proveedor) = DAOProveedor.buscarProveedoresActivoPorNombre("")

        If proveedores.Count > 0 Then
            LBProveedores.Items.Clear()

            For Each _prv As Proveedor In proveedores

                LBProveedores.Items.Add(_prv.id + SEPARADOR_DE_COLUMNAS + _prv.razonSocial)

            Next

            txtFiltrar.Enabled = True
            txtFiltrar.Focus()
        End If

    End Sub

    Private Sub txtFiltrar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltrar.TextChanged

        LBConsulta_Filtrada.Items.Clear()

        If UCase(Trim(txtFiltrar.Text)) <> "" Then

            For Each item In LBProveedores.Items

                If UCase(item.ToString()).Contains(UCase(Trim(txtFiltrar.Text))) Then

                    LBConsulta_Filtrada.Items.Add(item.ToString())

                End If

            Next

            LBConsulta_Filtrada.Visible = True

        Else

            LBConsulta_Filtrada.Visible = False

        End If

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged
        LBProveedores.SelectedItem = LBConsulta_Filtrada.SelectedItem
    End Sub

    Private Sub LBProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBProveedores.SelectedIndexChanged
        _TraerProveedor(LBProveedores.SelectedItem)
    End Sub

    Private Sub _TraerProveedor(ByVal linea_proveedor As String)

        If Trim(linea_proveedor) <> "" Then

            Dim proveedor() As String

            proveedor = Trim(linea_proveedor).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            txtCodigoProveedor.Text = proveedor(0)

            Dim _proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(Trim(txtCodigoProveedor.Text))

            If IsNothing(_proveedor) Then
                MsgBox("Proveedor no existente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            txtDescripcionProveedor.Text = Trim(linea_proveedor.Replace(txtCodigoProveedor.Text, ""))

            LBRemitos.Visible = False
            txtRemitos.Text = ""
            txtRemitos.Focus()

        End If

    End Sub

    Private Sub btnConsultaRemitos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaRemitos.Click
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()
        Dim dr As SqlDataReader
        Dim ConnectionStringTemplate As String
        Dim DiferenciaFechas As Long
        Dim remitos As New List(Of String)
        Dim Empresas = Proceso.Empresas 'As New List(Of String) From {"SurfactanSA", "surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII"}

        If Trim(txtCodigoProveedor.Text) = "" Then
            Exit Sub
        End If

        LBRemitos.Items.Clear()

        For Each empresa In Empresas

            ConnectionStringTemplate = _ConnectionString(empresa)

            Try
                cn.ConnectionString = ConnectionStringTemplate

                cm.CommandText = "SELECT Remito, Fecha FROM Informe WHERE Renglon = '1' AND Fechaord >= '20100101' AND Proveedor='" + Trim(txtCodigoProveedor.Text) + "'"
                cm.Connection = cn

                cn.Open()

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    Do While dr.Read()

                        DiferenciaFechas = DateDiff(DateInterval.Day, CDate(dr.Item(1)), Now.Date)

                        If DiferenciaFechas <= 90 Then
                            remitos.Add(dr.Item(0))
                        End If

                    Loop

                End If

            Catch ex As Exception
                LBRemitos.Visible = False
            Finally
                cn.Close()
                'cm = Nothing
                'dr = Nothing
            End Try

        Next

        ' Filtro aquellos que no se encuentren en la tabla IvaComp
        For Each remito In remitos

            Try
                cn.ConnectionString = _ConnectionString(Empresas.Item(0))

                cm.CommandText = "SELECT TOP 1 Proveedor FROM IvaComp WHERE Remito = '" + remito + "' AND Proveedor='" + Trim(txtCodigoProveedor.Text) + "'"
                cm.Connection = cn

                cn.Open()

                dr = cm.ExecuteReader()


                If Not dr.HasRows Then
                    LBRemitos.Items.Add(remito)
                End If

            Catch ex As Exception
                MsgBox("Error al consultar a la base de datos", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try

        Next

        If LBRemitos.Items.Count > 0 Then

            LBRemitos.Visible = True
        Else
            MsgBox("No hay remitos disponibles para este proveedor")
            LBRemitos.Visible = False
        End If

    End Sub

    Private Sub LBRemitos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBRemitos.SelectedIndexChanged

        If Not String.IsNullOrEmpty(Trim(LBRemitos.SelectedItem)) Then
            txtRemitos.Text = Trim(LBRemitos.SelectedItem)
            LBRemitos.Visible = False

            _ListarDetallesDeRemitos()
        End If

    End Sub

    Private Sub txtRemitos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemitos.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtRemitos.Text) = "" Then : Exit Sub : End If

            _ListarDetallesDeRemitos()
        ElseIf e.KeyData = Keys.Escape Then
            txtRemitos.Text = ""
        End If

    End Sub

    Private Sub _ListarDetallesDeRemitos()
        Dim consulta As String = txtCodigoProveedor.Text + "$" + txtDescripcionProveedor.Text + "$" + txtRemitos.Text
        Dim form As Form

        form = New DetallesRemitosProveedor(consulta)

        form.Show()
    End Sub

    Private Function _ConnectionString(ByVal empresa As String) As String
        Return "Data Source=193.168.0.7;Initial Catalog=" + empresa + ";User ID=usuarioadmin; Password=usuarioadmin"
    End Function

    Private Sub LBProveedores_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LBProveedores.MouseDoubleClick
        btnConsultaRemitos.PerformClick()
    End Sub

    Private Sub txtCodigoProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigoProveedor.Text) <> "" Then
                LBProveedores.SelectedIndex = LBProveedores.FindString(Trim(txtCodigoProveedor.Text))

                If Not IsNothing(LBProveedores.SelectedItem) Then
                    _TraerProveedor(LBProveedores.SelectedItem)
                Else
                    txtCodigoProveedor.Focus()
                    txtDescripcionProveedor.Text = ""
                End If

                'LBProveedores_MouseDoubleClick(Nothing, Nothing)
                'btnConsultaRemitos.PerformClick()
            Else
                txtFiltrar.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoProveedor.Text = ""
            txtDescripcionProveedor.Text = ""
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LBRemitos.Items.Clear()
        txtRemitos.Text = ""
        txtCodigoProveedor.Text = ""
        txtDescripcionProveedor.Text = ""
        txtFiltrar.Text = ""
        txtFiltrar.Focus()
    End Sub


    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



End Class