Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class ProveedoresABM

    '    Dim organizadorABM As New FormOrganizer(Me, 800, 800)
    Dim observaciones As String = ""
    Dim _Inhabilitado As String = "0"
    Dim cufe1 As Tuple(Of String, String) = Tuple.Create("", "")
    Dim cufe2 As Tuple(Of String, String) = Tuple.Create("", "")
    Dim cufe3 As Tuple(Of String, String) = Tuple.Create("", "")
    Dim _Contacto1 As Tuple(Of String, String, String, String) = Tuple.Create("", "", "", "")
    Dim _Contacto2 As Tuple(Of String, String, String, String) = Tuple.Create("", "", "", "")
    Dim _Contacto3 As Tuple(Of String, String, String, String) = Tuple.Create("", "", "", "")

    Private Const VALIDA_CUIT = "54327654321"

    Private TipoConsulta As String
    Private Const MAIN_HEIGHT = 560
    'Private Const EXPANDED_HEIGHT = 720
    Private WBColorAntRazon As Color
    Private WColorAntRazon As Color
    Private WBColorAntEstado As Color
    Private WColorAntEstado As Color

    Private Sub ProveedoresABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim provincias = DAOProveedor.listarProvincias
        'cmbProvincia.DisplayMember = "ToString"
        'cmbProvincia.ValueMember = "valueMember"
        'cmbProvincia.DataSource = provincias
        Label2.Text = Proceso.NombreEmpresa()

        cmbRubro.DisplayMember = "ToString"
        cmbRubro.ValueMember = "valueMember"
        cmbRubro.DataSource = DAORubroProveedor.buscarRubroProveedorPorDescripcion("")
        WBColorAntRazon = txtRazonSocial.BackColor
        WColorAntRazon = txtRazonSocial.ForeColor
        WBColorAntEstado = cmbEstado.BackColor
        WColorAntEstado = cmbEstado.ForeColor

        limpiar()
    End Sub

    Private Sub limpiar()
        txtRazonSocial.BackColor = WBColorAntRazon
        txtRazonSocial.ForeColor = WColorAntRazon 'Color.White

        cmbEstado.BackColor = WBColorAntEstado
        cmbEstado.ForeColor = WColorAntEstado 'Color.White

        setDefaults()
    End Sub

    Private Sub setDefaults()

        For Each Control As TextBox In Me.Panel2.Controls.OfType(Of TextBox)()
            Control.Text = ""
        Next

        For Each Control As MaskedTextBox In Me.Panel2.Controls.OfType(Of MaskedTextBox)()
            Control.Clear()
        Next

        For Each cmb As ComboBox In Me.Panel2.Controls.OfType(Of ComboBox)()

            If cmb.Items.Count > 0 Then
                cmb.SelectedIndex = 0
            End If

        Next

        cmbInscripcionIB.SelectedIndex = 0
        cmbCondicionIB1.SelectedIndex = 0
        cmbCondicionIB2.SelectedIndex = 0
        txtNroIB.Text = ""
        txtPorcelProv.Text = ""
        txtPorcelCABA.Text = ""

        CKBProveedorInactivo.Checked = False

        cufe1 = Tuple.Create("", "")
        cufe2 = Tuple.Create("", "")
        cufe3 = Tuple.Create("", "")
        _Contacto1 = Tuple.Create("", "", "", "")
        _Contacto2 = Tuple.Create("", "", "", "")
        _Contacto3 = Tuple.Create("", "", "", "")

        txtPaginaWeb.Text = "http://"

        cmbCondicionIB2.SelectedIndex = 2

        observaciones = ""

        txtCodigo.Focus()

        Me.Height = MAIN_HEIGHT
    End Sub

    Private Function _FechaComoOrd(ByVal fecha As String) As String
        Return String.Join("", fecha.Split("/").Reverse())
    End Function

    Private Function NormalizarIndex(ByVal numero As Integer) As Integer
        Return IIf(numero < 0, 0, numero)
    End Function

    Private Sub _ActualizarProveedorEnEmpresa(ByVal cs As String)
        Dim ZSql As String
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()

        ZSql = "UPDATE Proveedor " _
                    & " SET " _
                    & "Nombre =  '" & Mid(Trim(txtRazonSocial.Text), 1, 50) & "', " _
                    & "Direccion =  '" & Mid(Trim(txtDireccion.Text), 1, 50) & "', " _
                    & "Localidad =  '" & Mid(Trim(txtLocalidad.Text), 1, 50) & "', " _
                    & "Provincia =  '" & ceros(NormalizarIndex(cmbProvincia.SelectedIndex), 2) & "', " _
                    & "Postal =  '" & Mid(Trim(txtCodigoPostal.Text), 1, 4) & "', " _
                    & "Cuit =  '" & Mid(Trim(txtCUIT.Text), 1, 15) & "', " _
                    & "Telefono =  '" & Mid(Trim(txtTelefono.Text), 1, 100) & "', " _
                    & "Email =  '" & Mid(Trim(txtEmail.Text), 1, 400) & "', " _
                    & "Observaciones =  '" & Mid(Trim(txtObservaciones.Text), 1, 200) & "', " _
                    & "Tipo =  '" & NormalizarIndex(cmbTipoProveedor.SelectedIndex) & "', " _
                    & "Iva =  '" & NormalizarIndex(cmbIVA.SelectedIndex) & "', " _
                    & "Dias =  '" & Mid(Trim(txtDiasPlazo.Text), 1, 20) & "', " _
                    & "Empresa =  '1', " _
                    & "Cuenta =  '', " _
                    & "NombreCheque =  '" & Mid(Trim(txtCheque.Text), 1, 50) & "', " _
                    & "wdate =  '" & Date.Now.ToString("dd-MM-yyyy") & "', " _
                    & "CodIb =  '" & NormalizarIndex(cmbCondicionIB1.SelectedIndex) & "', " _
                    & "NroIb =  '" & Mid(Trim(txtNroIB.Text), 1, 20) & "', " _
                    & "NroInsc =  '', " _
                    & "Cai =  '', " _
                    & "VtoCai =  '', " _
                    & "TipoProv =  '" & NormalizarIndex(cmbRubro.SelectedIndex) & "', " _
                    & "CategoriaI =  '', " _
                    & "CategoriaII =  '', " _
                    & "Iso =  '', " _
                    & "VtoIso =  '', " _
                    & "Region =  '', " _
                    & "PorceIb =  " & Proceso.formatonumerico(txtPorcelProv.Text) & ", " _
                    & "Estado =  '" & NormalizarIndex(cmbEstado.SelectedIndex) & "', " _
                    & "IbCiudadII =  '" & NormalizarIndex(cmbInscripcionIB.SelectedIndex) & "', " _
                    & "Califica =  '', " _
                    & "FechaCalifica =  '', " _
                    & "OrdFechaCalifica =  '', " _
                    & "ObservacionesII =  '" & observaciones & "', " _
                    & "FechaCategoria =  '', " _
                    & "OrdFechaCategoria =  '', " _
                    & "FechaNroInsc =  '', " _
                    & "OrdFechaNroInsc =  '', " _
                    & "PorceIbCaba =  " & Proceso.formatonumerico(txtPorcelCABA.Text) & ", " _
                    & "Cufe =  '" & Mid(Trim(cufe1.Item1), 1, 20) & "', " _
                    & "CufeII =  '" & Mid(Trim(cufe2.Item1), 1, 20) & "', " _
                    & "CufeIII =  '" & Mid(Trim(cufe3.Item1), 1, 20) & "', " _
                    & "DirCufe =  '" & Mid(Trim(cufe1.Item2), 1, 50) & "', " _
                    & "DirCufeII =  '" & Mid(Trim(cufe2.Item2), 1, 50) & "', " _
                    & "DirCufeIII =  '" & Mid(Trim(cufe3.Item2), 1, 50) & "', " _
                    & "CodIbCaba =  '" & NormalizarIndex(cmbCondicionIB2.SelectedIndex) & "', " _
                    & "PaginaWeb =  '" & Mid(Trim(txtPaginaWeb.Text), 1, 50) & "', " _
                    & "ContactoNombre1 = '" & Mid(Trim(_Contacto1.Item1), 1, 50) & "', " _
                    & "ContactoCargo1 = '" & Mid(Trim(_Contacto1.Item2), 1, 50) & "', " _
                    & "ContactoTelefono1 = '" & Mid(Trim(_Contacto1.Item3), 1, 50) & "', " _
                    & "ContactoEmail1 = '" & Mid(Trim(_Contacto1.Item4), 1, 50) & "', " _
                    & "ContactoNombre2 = '" & Mid(Trim(_Contacto2.Item1), 1, 50) & "', " _
                    & "ContactoCargo2 = '" & Mid(Trim(_Contacto2.Item2), 1, 50) & "', " _
                    & "ContactoTelefono2 = '" & Mid(Trim(_Contacto2.Item3), 1, 50) & "', " _
                    & "ContactoEmail2 = '" & Mid(Trim(_Contacto2.Item4), 1, 50) & "', " _
                    & "ContactoNombre3 = '" & Mid(Trim(_Contacto3.Item1), 1, 50) & "', " _
                    & "ContactoCargo3 = '" & Mid(Trim(_Contacto3.Item2), 1, 50) & "', " _
                    & "ContactoTelefono3 = '" & Mid(Trim(_Contacto3.Item3), 1, 50) & "', " _
                    & "ContactoEmail3 = '" & Mid(Trim(_Contacto3.Item4), 1, 50) & "', " _
                    & "ClienteAsociado = '', " _
                    & "Inhabilitado = '" & Trim(_Inhabilitado) & "' " _
                    & " WHERE Proveedor = '" & Trim(txtCodigo.Text) & "'"

        Try
            cn.ConnectionString = cs
            cn.Open()

            cm.Connection = cn

            cm.CommandText = ZSql

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Ocurrió un problema al querer actualizar al proveedor.")
        Finally
            cm = Nothing
            cn.Close()
            cn = Nothing
        End Try

        ' Actualizo proveedor con la ConnectionString en la que se encontró el proveedor.
    End Sub

    Private Sub _ActualizarProveedor()
        'Dim ZSql As String = ""
        Dim _Empresas As List(Of String)

        Dim Xcs As String = Configuration.ConfigurationManager.ConnectionStrings(ClasesCompartidas.Globals.empresa).ToString '"Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()
        Dim dr As SqlDataReader

        ' DETERMINO LAS EMPRESAS CON LAS QUE TRABAJAR.
        _Empresas = Proceso.Empresas

        ' Recorrer todos las plantas y actualizar en cada ocurrencia.

        For Each _Empresa In _Empresas
            Dim Wrem = "SurfactanSA"

            If Proceso._EsPellital Then
                Wrem = "Pellital_III"
            End If

            Dim cs = Xcs.Replace("Catalog=" & Wrem, "Catalog=" & _Empresa)

            Try
                cn.ConnectionString = cs
                cn.Open()

                cm.CommandText = "SELECT Proveedor FROM Proveedor WHERE Proveedor = '" & txtCodigo.Text & "'"

                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then

                    _ActualizarProveedorEnEmpresa(cs)

                End If

            Catch ex As Exception
                MsgBox("Ocurrió un problema al querer actualizar al proveedor.", MsgBoxStyle.Critical)
                Exit Sub
            Finally

                cn.Close()

            End Try

        Next

        MsgBox("Proveedor Actualiza correctamente!", MsgBoxStyle.Information)

        btnLimpiar.PerformClick()

    End Sub

    Private Sub agregar()
        Dim _Autorizado = False

        If Trim(txtCodigo.Text) = "" Then
            Exit Sub
        End If

        ' Validamos el Cuit en caso de que se haya ingresado alguno.

        If Trim(txtCUIT.Text.Replace("-", "")) <> "" Then
            If Not _CuitValido(txtCUIT.Text) Then
                MsgBox("El CUIT indicado no es válido.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If


        With PedirClaveAutorizacion

            .ShowDialog()
            _Autorizado = .Autorizado
            .Dispose()

        End With

        If Not _Autorizado Then
            'MsgBox("No se encuentra autorizado para realizar la modificacion requerida.", MsgBoxStyle.Information)
            txtCodigo.Focus()
            Exit Sub
        End If

        ' Se supone que llegados hasta acá todos los datos introducidos son validos.

        Dim proveedor As Proveedor

        proveedor = DAOProveedor.buscarProveedorPorCodigo(txtCodigo.Text)

        ' Normalizamos los numeros para que no rompa nada.
        Dim WPorcelProv = Proceso.formatonumerico(txtPorcelProv.Text)
        Dim WPorcelCABA = Proceso.formatonumerico(txtPorcelCABA.Text)

        ' Comprobamos si se trata de una actualización o de un proveedor nuevo.
        If Not IsNothing(proveedor) Then
            _ActualizarProveedor()
            Exit Sub
        End If
        proveedor = New Proveedor(txtCodigo.Text, txtRazonSocial.Text)

        proveedor.direccion = txtDireccion.Text
        proveedor.localidad = txtLocalidad.Text
        proveedor.provincia = cmbProvincia.SelectedIndex
        proveedor.codPostal = txtCodigoPostal.Text
        proveedor.region = 0
        proveedor.telefono = txtTelefono.Text
        proveedor.diasPlazo = txtDiasPlazo.Text
        proveedor.email = txtEmail.Text
        proveedor.observaciones = txtObservaciones.Text
        proveedor.cuit = txtCUIT.Text
        proveedor.tipo = cmbTipoProveedor.SelectedIndex
        proveedor.codIva = cmbIVA.SelectedIndex
        proveedor.cuenta = DAOCuentaContable.buscarCuentaContablePorCodigo(0)
        proveedor.nombreCheque = txtCheque.Text
        proveedor.condicionIB1 = cmbCondicionIB1.SelectedIndex
        proveedor.condicionIB2 = cmbCondicionIB2.SelectedIndex
        proveedor.numeroIB = txtNroIB.Text
        proveedor.porceIBProvincia = Val(WPorcelProv)
        proveedor.porceIBCABA = Val(WPorcelCABA)
        proveedor.RawRubro = cmbRubro.SelectedIndex
        proveedor.numeroSEDRONAR = ""
        proveedor.vtoSEDRONAR = ""
        proveedor.categoria = 0
        proveedor.categoriaCalif = 0
        proveedor.vtoCategoria = ""
        proveedor.tipoInscripcionIB = cmbInscripcionIB.SelectedIndex
        proveedor.cai = "" 'txtCAI.Text
        proveedor.vtoCAI = "" 'txtCAIVto.Text
        proveedor.certificados = 0
        proveedor.vtoCertificados = ""
        proveedor.estado = cmbEstado.SelectedIndex
        proveedor.calificacion = 0
        proveedor.vtoCalificacion = ""

        proveedor.observacionCompleta = observaciones
        proveedor.cufe1 = cufe1.Item1
        proveedor.cufe2 = cufe2.Item1
        proveedor.cufe3 = cufe3.Item1
        proveedor.dirCUFE1 = cufe1.Item2
        proveedor.dirCUFE2 = cufe2.Item2
        proveedor.dirCUFE3 = cufe3.Item2

        Dim cliente As Cliente = DAOCliente.buscarClientePorCodigo(0)

        proveedor.cliente = IIf(Not IsNothing(cliente), cliente, New Cliente())

        proveedor.PaginaWeb = New Object() {txtPaginaWeb.Text}

        proveedor.contacto1 = New Object() {_Contacto1.Item1, _Contacto1.Item2, _Contacto1.Item3, _Contacto1.Item4}
        proveedor.contacto2 = New Object() {_Contacto2.Item1, _Contacto2.Item2, _Contacto2.Item3, _Contacto2.Item4}
        proveedor.contacto3 = New Object() {_Contacto3.Item1, _Contacto3.Item2, _Contacto3.Item3, _Contacto3.Item4}

        proveedor.Inhabilitado = IIf(CKBProveedorInactivo.Checked, "1", "0")

        Try
            DAOProveedor.agregarProveedor(proveedor)
            MsgBox("Proveedor guardado correctamente.", MsgBoxStyle.Information)
            btnLimpiar.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub borrar()
        Try
            If MsgBox("¿Está seguro de querer eliminar el proveedor actual?", MsgBoxStyle.YesNo) = DialogResult.No Then : Exit Sub : End If

            DAOProveedor.eliminarProveedor(txtCodigo.Text)
            MsgBox("Proveedor eliminado con exito!", MsgBoxStyle.Information)
            btnLimpiar.PerformClick()
        Catch ex As Exception
            MsgBox("Hubo un error al querer eliminar el proveedor indicado.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mostrarProveedor(ByVal proveedor As Proveedor)
        If Not proveedor.estaDefinidoCompleto Then
            proveedor = DAOProveedor.buscarProveedorPorCodigo(proveedor.id)
        End If

        txtRazonSocial.BackColor = WBColorAntRazon
        txtRazonSocial.ForeColor = WColorAntRazon 'Color.White

        cmbEstado.BackColor = WBColorAntEstado
        cmbEstado.ForeColor = WColorAntEstado 'Color.White

        txtCodigo.Text = proveedor.id
        txtRazonSocial.Text = proveedor.razonSocial
        txtDireccion.Text = proveedor.direccion
        txtLocalidad.Text = proveedor.localidad
        cmbProvincia.SelectedIndex = proveedor.provincia
        txtCodigoPostal.Text = proveedor.codPostal
        txtTelefono.Text = proveedor.telefono
        txtDiasPlazo.Text = proveedor.diasPlazo
        txtEmail.Text = proveedor.email
        txtObservaciones.Text = proveedor.observaciones
        txtCUIT.Text = proveedor.cuit
        cmbTipoProveedor.SelectedIndex = proveedor.tipo
        cmbIVA.SelectedIndex = proveedor.codIva
        txtCheque.Text = proveedor.nombreCheque
        cmbCondicionIB1.SelectedIndex = proveedor.condicionIB1
        cmbCondicionIB2.SelectedIndex = proveedor.condicionIB2
        txtNroIB.Text = proveedor.numeroIB
        txtPorcelProv.Text = proveedor.porceIBProvincia
        txtPorcelCABA.Text = proveedor.porceIBCABA
        'mostrarRubro(proveedor.rubro)
        cmbRubro.SelectedIndex = proveedor.RawRubro
        cmbInscripcionIB.SelectedIndex = proveedor.tipoInscripcionIB
        txtCAI.Text = "" 'proveedor.cai
        txtCAIVto.Text = "" ' proveedor.vtoCAI
        cmbEstado.SelectedIndex = proveedor.estado

        CKBProveedorInactivo.Checked = proveedor.Inhabilitado <> "0"

        observaciones = proveedor.observacionCompleta

        txtPaginaWeb.Text = proveedor.PaginaWeb(0).ToString

        _Contacto1 = Tuple.Create(proveedor.contacto1(0).ToString, proveedor.contacto1(1).ToString, proveedor.contacto1(2).ToString, proveedor.contacto1(3).ToString)
        _Contacto2 = Tuple.Create(proveedor.contacto2(0).ToString, proveedor.contacto2(1).ToString, proveedor.contacto2(2).ToString, proveedor.contacto2(3).ToString)
        _Contacto3 = Tuple.Create(proveedor.contacto3(0).ToString, proveedor.contacto3(1).ToString, proveedor.contacto3(2).ToString, proveedor.contacto3(3).ToString)

        ' Buscamos si el proveedor se encuentra en estado de Embargo
        If _ProveedorEmbargado() Then
            txtRazonSocial.BackColor = Color.Red
            txtRazonSocial.ForeColor = Color.White
        End If

        ' Verificas si se encuentra en estado
        If Val(proveedor.estado) = 2 Then
            cmbEstado.BackColor = Color.Red
            cmbEstado.ForeColor = Color.White
        End If

    End Sub

    Private Function _ProveedorEmbargado() As Boolean
        Dim embargado = False
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Embargo FROM Proveedor WHERE Proveedor = '" & Trim(txtCodigo.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                If UCase(IIf(IsDBNull(dr.Item("Embargo")), "", dr.Item("Embargo"))) = "S" Then
                    embargado = True
                End If

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        Return embargado
    End Function

    Private Sub btnObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservaciones.Click
        Dim formularioObservaciones As New ObservacionesProveedor()

        formularioObservaciones.CustomTextBox1.Text = observaciones
        If formularioObservaciones.ShowDialog(Me) = DialogResult.OK Then
            observaciones = formularioObservaciones.CustomTextBox1.Text
        End If
    End Sub

    Private Sub btnPrimerRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimerRegistro.Click
        _NavegarHaciaEl("primero")
    End Sub

    Private Sub btnUltimoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimoRegistro.Click
        _NavegarHaciaEl("ultimo")
    End Sub

    Private Sub btnSiguienteRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteRegistro.Click
        _NavegarHaciaEl("siguiente", txtCodigo.Text)
    End Sub

    Private Sub btnAnteriorRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorRegistro.Click
        _NavegarHaciaEl("anterior", txtCodigo.Text)
    End Sub

    Private Sub _NavegarHaciaEl(ByVal direccion As String, Optional ByVal registroActual As String = "")

        Dim proveedores As DataTable

        proveedores = ClasesCompartidas.SQLConnector.retrieveDataTable("get_proveedor", direccion, registroActual)

        If proveedores.Rows.Count > 0 Then
            Dim proveedor As Proveedor

            proveedor = DAOProveedor.buscarProveedorPorCodigo(proveedores(0)(0))

            If Not IsNothing(proveedor) Then

                mostrarProveedor(proveedor)

            End If

            txtCodigo.Focus()

        End If


    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        agregar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        borrar()
    End Sub

    Private Sub btnListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListado.Click
        With VistaPrevia
            .Reporte = New ListadoResumidoProveedores
            .Mostrar()
        End With
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        _AbrirConsulta()
    End Sub

    Private Sub _AbrirConsulta(Optional ByVal opcion As String = "")
        txtFiltrar.Enabled = False
        txtFiltrar.Text = ""
        LBConsulta_Filtrada.Items.Clear()
        LBConsulta.Items.Clear()
        LBConsulta_Opciones.Visible = opcion = ""

        If opcion <> "" Then

            If LCase(opcion) = "proveedor" Then
                LBConsulta_Opciones.SelectedIndex = 0
                _ListarConsulta("Proveedor, Nombre", "Proveedor")
            ElseIf LCase(opcion) = "cuenta" Then
                _ListarConsulta("Descripcion", "Cuenta")
            End If

        Else
            _ExpandirFormulario()
        End If

    End Sub

    Private Sub _ContraerFormulario()

        'Me.Height = MAIN_HEIGHT
        GrupoConsultas.Visible = False

    End Sub

    Private Sub _ExpandirFormulario()

        'Me.Height = EXPANDED_HEIGHT
        GrupoConsultas.Visible = True

    End Sub

    Private Sub txtFiltrar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltrar.TextChanged

        LBConsulta_Filtrada.Items.Clear()

        If UCase(Trim(txtFiltrar.Text)) <> "" Then

            For Each item In LBConsulta.Items

                If UCase(item.ToString()).Contains(UCase(Trim(txtFiltrar.Text))) Then

                    LBConsulta_Filtrada.Items.Add(item.ToString())

                End If

            Next

            LBConsulta_Filtrada.Visible = True

        Else

            LBConsulta_Filtrada.Visible = False

        End If

    End Sub

    Private Sub LBConsulta_Opciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Opciones.SelectedIndexChanged

        If LBConsulta_Opciones.SelectedItem = "" Then
            Exit Sub
        End If


        Select Case LBConsulta_Opciones.SelectedIndex
            Case 0
                _ListarConsulta("Proveedor, Nombre", "Proveedor")
            Case 1
                _ListarConsulta("Descripcion", "Cuenta")
            Case 2
                _ListarConsulta("Razon", "Cliente")
            Case 3
                _ListarConsulta("Descripcion", "TipoProv")
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub LBConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta.SelectedIndexChanged

        If LBConsulta.SelectedItem = "" Then
            Exit Sub
        End If

        Select Case TipoConsulta
            Case "Proveedor"
                _TraerProveedor(LBConsulta.SelectedItem)
            Case "TipoProv"
                _TraerRubros(LBConsulta.SelectedItem)
        End Select

    End Sub

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged

        If LBConsulta_Filtrada.SelectedItem = "" Then
            Exit Sub
        End If

        Select Case TipoConsulta
            Case "Proveedor"
                _TraerProveedor(LBConsulta_Filtrada.SelectedItem)
            Case "TipoProv"
                _TraerRubros(LBConsulta.SelectedItem)
        End Select

    End Sub

    Private Sub _TraerRubros(ByVal Rubro As String)

        With VistaPrevia
            .Reporte = New ProveedoresPorRubro
            .Formula = "{TipoProv.Descripcion}='" & Rubro & "'"
            _ContraerFormulario()
            .Mostrar()
        End With

    End Sub

    Private Sub _TraerProveedor(ByVal nombre As String)
        Dim proveedor As List(Of Proveedor) = DAOProveedor.buscarProveedorPorNombre(Trim(nombre.Substring(11, nombre.Length - 11)))

        If Not IsNothing(proveedor) AndAlso proveedor.Count > 0 Then

            mostrarProveedor(proveedor(0))

            _ContraerFormulario()

            txtCodigo.Focus()

        End If

    End Sub

    Private Sub _ListarConsulta(ByVal columnas As String, ByVal tabla As String)
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT " + columnas + " FROM " + tabla)
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                LBConsulta.Items.Clear()

                Do While dr.Read()

                    If LBConsulta_Opciones.SelectedIndex = 0 Then
                        LBConsulta.Items.Add(dr.Item(0) & "    " & dr.Item(1))
                    Else
                        LBConsulta.Items.Add(dr.Item(0))
                    End If


                Loop

                dr.Close()

                TipoConsulta = tabla
                LBConsulta_Opciones.Visible = False
                txtFiltrar.Enabled = True
                txtFiltrar.Focus()

                _ExpandirFormulario()
                txtFiltrar.Focus()

            Else

                MsgBox("No hay registros que listar")

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer listar los registros solicitados", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing

        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ProveedoresABM_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Me.DesktopLocation = New Point(200, 0)
        txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtCodigo.Text) = "" Then
                _AbrirConsulta("Proveedor")
                txtFiltrar.Focus()
                Exit Sub
            End If

            Dim codigo As String = Trim(txtCodigo.Text)

            Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(codigo)

            If Not IsNothing(proveedor) Then
                mostrarProveedor(proveedor)
                _SaltarA(txtRazonSocial)
            Else

                btnLimpiar.PerformClick()
                txtCodigo.Text = codigo
                txtRazonSocial.Focus()

                ' En CABA es exento por Defecto.
                cmbCondicionIB2.SelectedIndex = 2
            End If


        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub _SaltarA(ByRef control As Control)
        control.Focus()
    End Sub

    Private Sub txtRazonSocial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRazonSocial.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtDireccion)
        ElseIf e.KeyData = Keys.Escape Then
            txtRazonSocial.Text = ""
        End If
    End Sub

    Private Sub txtDireccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbProvincia)
        ElseIf e.KeyData = Keys.Escape Then
            txtDireccion.Text = ""
        End If
    End Sub

    Private Sub txtLocalidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocalidad.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCodigoPostal)
        ElseIf e.KeyData = Keys.Escape Then
            txtLocalidad.Text = ""
        End If
    End Sub

    Private Sub txtCodigoPostal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoPostal.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTelefono.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoPostal.Text = ""
        End If
    End Sub

    Private Sub txtTelefono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTelefono.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtEmail)
        ElseIf e.KeyData = Keys.Escape Then
            txtTelefono.Text = ""
        End If
    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtDiasPlazo)
        ElseIf e.KeyData = Keys.Escape Then
            txtEmail.Text = ""
        End If
    End Sub

    Private Sub txtDiasPlazo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiasPlazo.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCUIT)
        ElseIf e.KeyData = Keys.Escape Then
            txtDiasPlazo.Text = ""
        End If
    End Sub

    Private Function _CuitValido(ByVal cuit As String) As Boolean
        Dim valido = False
        Dim suma = 0

        cuit = cuit.Replace("-", "")

        For i = 1 To 11
            suma = suma + (Val(Mid(cuit, i, 1)) * Val(Mid(VALIDA_CUIT, i, 1)))
        Next

        If suma > 0 Then
            valido = suma Mod 11 = 0
        End If

        Return valido
    End Function

    Private Sub txtCUIT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUIT.KeyDown
        If e.KeyData = Keys.Enter Then
            If _CuitValido(txtCUIT.Text) Or Trim(txtCUIT.Text.Replace("-", "")) = "" Then
                _SaltarA(cmbTipoProveedor)
            Else
                MsgBox("El CUIT ingresado no es correcto.")
                txtCUIT.Focus()
            End If
        ElseIf e.KeyData = Keys.Escape Then
            txtCUIT.Text = ""
        End If
    End Sub

    Private Sub txtObservaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCheque)
        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If
    End Sub

    Private Sub txtCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCheque.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCondicionIB1)
        ElseIf e.KeyData = Keys.Escape Then
            txtCheque.Text = ""
        End If
    End Sub

    Private Sub txtNroIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroIB.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPorcelProv)
        ElseIf e.KeyData = Keys.Escape Then
            txtNroIB.Text = ""
        End If
    End Sub

    Private Sub txtPorcelProv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcelProv.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCondicionIB2)
        ElseIf e.KeyData = Keys.Escape Then
            txtPorcelProv.Text = ""
        End If
    End Sub

    Private Sub txtPorcelCABA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcelCABA.KeyDown
        If e.KeyData = Keys.Enter Then
            txtPaginaWeb.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtPorcelCABA.Text = ""
        End If
    End Sub

    Private Sub cmbTipoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoProveedor.TextChanged
        _SaltarA(cmbIVA)
    End Sub

    Private Sub cmbTipoProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbIVA)
        ElseIf e.KeyData = Keys.Escape Then
            cmbTipoProveedor.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbIVA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIVA.KeyDown

        If e.KeyData = Keys.Enter Then

            If cmbIVA.SelectedIndex = 5 Then ' Monotributo
                cmbTipoProveedor.SelectedIndex = 3 ' Exento
            End If

            _SaltarA(txtObservaciones)
        ElseIf e.KeyData = Keys.Escape Then
            cmbIVA.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbIVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIVA.TextChanged
        If cmbIVA.SelectedIndex = 5 Then ' Monotributo
            cmbTipoProveedor.SelectedIndex = 3 ' Exento
        End If
        _SaltarA(txtObservaciones)
    End Sub

    Private Sub cmbCondicionIB1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCondicionIB1.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroIB)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCondicionIB1.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCondicionIB1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCondicionIB1.TextChanged
        _SaltarA(txtNroIB)
    End Sub

    Private Sub cmbCondicionIB2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCondicionIB2.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbInscripcionIB)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCondicionIB2.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCondicionIB2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCondicionIB2.TextChanged
        _SaltarA(cmbInscripcionIB)
    End Sub

    Private Sub cmbRubro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRubro.KeyDown
        If e.KeyData = Keys.Enter Then
            cmbCondicionIB1.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            cmbRubro.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbInscripcionIB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbInscripcionIB.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPorcelCABA)
        ElseIf e.KeyData = Keys.Escape Then
            cmbInscripcionIB.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbInscripcionIB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInscripcionIB.TextChanged
        _SaltarA(txtPorcelCABA)
    End Sub

    Private Sub cmbEstado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEstado.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPaginaWeb)
        ElseIf e.KeyData = Keys.Escape Then
            cmbEstado.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.TextChanged
        _SaltarA(txtPaginaWeb)
    End Sub

    Private Sub btnContactos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactos.Click
        ' Abrir ventana de Ingreso de contactos.
        With Contactos
            .txtNombre1.Text = _Contacto1.Item1
            .txtCargo1.Text = _Contacto1.Item2
            .txtTelefono1.Text = _Contacto1.Item3
            .txtEmail1.Text = _Contacto1.Item4

            .txtNombre2.Text = _Contacto2.Item1
            .txtCargo2.Text = _Contacto2.Item2
            .txtTelefono2.Text = _Contacto2.Item3
            .txtEmail2.Text = _Contacto2.Item4

            .txtNombre3.Text = _Contacto3.Item1
            .txtCargo3.Text = _Contacto3.Item2
            .txtTelefono3.Text = _Contacto3.Item3
            .txtEmail3.Text = _Contacto3.Item4

            .ShowDialog()

            _Contacto1 = Tuple.Create(.txtNombre1.Text, .txtCargo1.Text, .txtTelefono1.Text, .txtEmail1.Text)
            _Contacto2 = Tuple.Create(.txtNombre2.Text, .txtCargo2.Text, .txtTelefono2.Text, .txtEmail2.Text)
            _Contacto3 = Tuple.Create(.txtNombre3.Text, .txtCargo3.Text, .txtTelefono3.Text, .txtEmail3.Text)

        End With
    End Sub

    Private Sub txtPaginaWeb_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPaginaWeb.MouseDoubleClick
        _VisitarPaginaWeb()
    End Sub

    Private Sub _VisitarPaginaWeb()
        Dim _Direccion As String = LCase(Trim(txtPaginaWeb.Text))
        Dim regex As New System.Text.RegularExpressions.Regex("^(http\:\/\/)")

        ' Corroboramos que haya contenido.
        If Trim(_Direccion) = "" Then
            Exit Sub
        End If

        ' Corroboramos que comience el protocolo.
        If Not regex.IsMatch(_Direccion) Then
            _Direccion = "http://" & _Direccion
        End If

        regex = New System.Text.RegularExpressions.Regex("\.[a-z]+(\/)?$")

        ' Corroboramos que tenga una extension.
        If Not regex.IsMatch(_Direccion) Then

            ' Corroboramos que pueda ser un formato de dirección valido.
            regex = New System.Text.RegularExpressions.Regex("^(http:\/\/)\w+(\.[a-z]+(\/)?)$")

            If Not regex.IsMatch(_Direccion & ".com") Then
                Exit Sub
            End If

            ' En caso de que no tenga extension y que un agregado de una direccion valida, se de una sugerencia avisando que es meramente una sugerencia.
            If MsgBox("La página web no tiene un formato valido. Una sugerencia posible puede ser: " _
                      & vbCrLf & vbCrLf _
                      & vbCrLf & vbCrLf _
                      & _Direccion & ".com" _
                      & vbCrLf & vbCrLf _
                      & vbCrLf & vbCrLf _
                      & "¿Quiere intentar visitarla?", MsgBoxStyle.YesNo) = DialogResult.Yes Then

                _Direccion &= ".com"
            Else
                Exit Sub
            End If
        End If

        Try
            txtPaginaWeb.Text = _Direccion
            ' Se procede a lanzar el navegador con una posible direccion valida.
            Process.Start(_Direccion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodigo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigo.MouseDoubleClick

        _AbrirConsulta("Proveedor")
        txtFiltrar.Focus()

    End Sub

    Private Function _ValidarFecha(ByVal fecha As String) As Boolean
        Dim valido = True

        If Trim(fecha.Replace("/", "")) = "" Then
            valido = Proceso._ValidarFecha(fecha)
        End If

        Return valido
    End Function

    Private Sub cmbProvincia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProvincia.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtLocalidad)
        End If

    End Sub

    Private Sub cmbProvincia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.TextChanged
        _SaltarA(txtLocalidad)
    End Sub

    Private Sub txtClienteAsociado_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        LBConsulta_Opciones.SelectedIndex = 2
        LBConsulta_Opciones_SelectedIndexChanged(Nothing, Nothing)
        _ExpandirFormulario()
        txtFiltrar.Focus()
    End Sub

    Private Sub CKBProveedorInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CKBProveedorInactivo.CheckedChanged

        If CKBProveedorInactivo.Checked Then
            _Inhabilitado = "1"
        Else
            _Inhabilitado = "0"
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress, txtCodigoPostal.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim WProveedores As DataTable = _TraerProveedores()

        For Each _Proveedor As DataRow In WProveedores.Rows
            txtCodigo.Text = _Proveedor.Item("Proveedor")
            txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
        Next

    End Sub

    Private Function _TraerProveedores() As DataTable
        Dim cn As New SqlConnection
        Dim cm As New SqlCommand
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        cn.ConnectionString = Proceso._ConectarA
        cn.Open()
        cm.Connection = cn
        cm.CommandText = "SELECT Proveedor from proveedor order by Proveedor"

        dr = cm.ExecuteReader

        If dr.HasRows Then
            tabla.Load(dr)
        End If

        Return tabla
    End Function

    Private Sub btnCerrarConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsultas.Click
        _ContraerFormulario()
    End Sub
End Class