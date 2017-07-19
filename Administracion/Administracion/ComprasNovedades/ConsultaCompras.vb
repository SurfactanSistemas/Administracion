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
            query = AddressOf DAOProveedor.buscarProveedoresActivoPorNombre
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

    Private Sub lstConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConsulta.Click

        If Trim(lstConsulta.SelectedItem.ToString) <> "" Then
            Close()
            showMethod.Invoke(lstConsulta.SelectedItem.ToString())
        End If

    End Sub

    Private Sub ConsultaCompras_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtConsulta.Focus()
    End Sub



    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstConsulta
        Dim final As ListBox = CLBFiltrado
        Dim cadena As String = Trim(txtConsulta.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True

        Else

            final.Visible = False

        End If
    End Sub

    Private Sub CLBFiltrado_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CLBFiltrado.MouseClick
        Dim origen As ListBox = lstConsulta
        Dim filtrado As ListBox = CLBFiltrado
        Dim texto As TextBox = txtConsulta

        If Trim(filtrado.SelectedItem.ToString) = "" Then
            Exit Sub
        End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedIndex = origen.FindStringExact(filtrado.SelectedItem.ToString)

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstConsulta_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtConsulta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsulta.TextChanged
        _FiltrarDinamicamente()
    End Sub

End Class