Public Class ConsultaCompras

    Dim duenio As Compras
    Dim query As QueryFunction
    Dim showMethod As ShowMethod

    Public Sub New(ByVal form As Form)
        InitializeComponent()
        duenio = form
    End Sub

    Private Sub lstSeleccion_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSeleccion.DoubleClick
        If lstSeleccion.SelectedItem = "Proveedores" Then
            query = AddressOf DAOProveedor.buscarProveedorPorNombre
            showMethod = AddressOf duenio.mostrarProveedor
        Else
            query = AddressOf DAOCuentaContable.buscarCuentaContablePorDescripcion
            showMethod = AddressOf duenio.mostrarCuentaContable
        End If
        lstConsulta.DataSource = query.Invoke("")
        txtConsulta.Visible = True
        lstConsulta.Visible = True
        lstSeleccion.Visible = False
        Me.Size = New System.Drawing.Size(400, 300)
        txtConsulta.Focus()
    End Sub

    Private Sub ConsultaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(200, 100)
    End Sub

    Private Sub txtConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsulta.KeyDown
        If e.KeyValue = Keys.Enter Then
            lstConsulta.DataSource = query.Invoke(txtConsulta.Text)
        End If
    End Sub

    Private Sub lstConsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.DoubleClick
        showMethod.Invoke(lstConsulta.SelectedValue)
        Close()
    End Sub
End Class