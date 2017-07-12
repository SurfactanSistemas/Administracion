Public Class ConsultaCompras

    Dim duenio As Compras
    Dim query As QueryFunction
    Dim showMethod As ShowMethod
    Dim onlyProveedores As Boolean

    Public Sub New(ByVal form As Form, Optional ByVal isForProveedores As Boolean = False)
        InitializeComponent()
        duenio = form
        onlyProveedores = isForProveedores
    End Sub

    Private Sub lstSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSeleccion.Click
        If lstSeleccion.SelectedItem = "Proveedores" Then
            query = AddressOf DAOProveedor.buscarProveedorPorNombre
            showMethod = AddressOf duenio.mostrarProveedorConsulta
        Else
            query = AddressOf DAOCuentaContable.buscarCuentaContablePorDescripcion
            showMethod = AddressOf duenio.mostrarCuentaContable
        End If
        lstConsulta.DataSource = query.Invoke("")
        txtConsulta.Visible = True
        lstConsulta.Visible = True
        CLBFiltrado.Visible = False
        lstSeleccion.Visible = False
        Me.Size = New System.Drawing.Size(400, 300)
        txtConsulta.Focus()
    End Sub

    Private Sub ConsultaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(200, 100)
        If onlyProveedores Then
            lstSeleccion.SelectedItem = "Proveedores"
            lstSeleccion_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsulta.KeyDown
        'If e.KeyValue = Keys.Enter Then
        '    lstConsulta.DataSource = query.Invoke(txtConsulta.Text)
        'End If
        CLBFiltrado.Items.Clear()

        If UCase(Trim(txtConsulta.Text)) <> "" Then

            For Each item In lstConsulta.Items

                If UCase(item.ToString()).Contains(UCase(Trim(txtConsulta.Text))) Then

                    CLBFiltrado.Items.Add(item.ToString())

                End If

            Next

            lstConsulta.Visible = False
            CLBFiltrado.Visible = True

        Else
            lstConsulta.Visible = True
            CLBFiltrado.Visible = False

        End If
    End Sub

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        If Trim(lstConsulta.SelectedItem.ToString()) <> "" Then
            Close()
            showMethod.Invoke(lstConsulta.SelectedItem.ToString())
        End If

    End Sub

    Private Sub CLBFiltrado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CLBFiltrado.Click
        If Trim(CLBFiltrado.SelectedItem) <> "" Then
            lstConsulta.SelectedIndex = lstConsulta.FindStringExact(CLBFiltrado.SelectedItem)
            lstConsulta_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ConsultaCompras_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtConsulta.Focus()
    End Sub
End Class