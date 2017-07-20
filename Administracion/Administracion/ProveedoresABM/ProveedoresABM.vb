Imports ClasesCompartidas
Imports System.Data.SqlClient

Public Class ProveedoresABM

    Dim organizadorABM As New FormOrganizer(Me, 800, 800)
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
    Private Const EXPANDED_HEIGHT = 720

    Private Sub ProveedoresABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim provincias = DAOProveedor.listarProvincias
        'cmbProvincia.DisplayMember = "ToString"
        'cmbProvincia.ValueMember = "valueMember"
        'cmbProvincia.DataSource = provincias
        
        cmbRubro.DisplayMember = "ToString"
        cmbRubro.ValueMember = "valueMember"
        cmbRubro.DataSource = DAORubroProveedor.buscarRubroProveedorPorDescripcion("")
        limpiar()
    End Sub

    Private Sub limpiar()
        'Cleanner.clean(Me)
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
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()

        ZSql = "UPDATE Proveedor " _
                    & " SET " _
                    & "Nombre =  '" & Mid(Trim(txtRazonSocial.Text), 1, 50) & "', " _
                    & "Direccion =  '" & Mid(Trim(txtDireccion.Text), 1, 50) & "', " _
                    & "Localidad =  '" & Mid(Trim(txtLocalidad.Text), 1, 50) & "', " _
                    & "Provincia =  '" & ceros(NormalizarIndex(cmbProvincia.SelectedIndex), 2) & "', " _
                    & "Postal =  '" & Mid(Trim(txtCodigoPostal.Text), 1, 4) & "', " _
                    & "Cuit =  '" & Mid(Trim(txtCUIT.Text), 1, 15) & "', " _
                    & "Telefono =  '" & Mid(Trim(txtTelefono.Text), 1, 30) & "', " _
                    & "Email =  '" & Mid(Trim(txtEmail.Text), 1, 400) & "', " _
                    & "Observaciones =  '" & Mid(Trim(txtObservaciones.Text), 1, 50) & "', " _
                    & "Tipo =  '" & NormalizarIndex(cmbTipoProveedor.SelectedIndex) & "', " _
                    & "Iva =  '" & NormalizarIndex(cmbIVA.SelectedIndex) & "', " _
                    & "Dias =  '" & Mid(Trim(txtDiasPlazo.Text), 1, 20) & "', " _
                    & "Empresa =  '1', " _
                    & "Cuenta =  '" & Mid(Trim(txtCuenta.Text), 1, 10) & "', " _
                    & "NombreCheque =  '" & Mid(Trim(txtCheque.Text), 1, 50) & "', " _
                    & "wdate =  '" & Date.Now.ToString("dd-MM-yyyy") & "', " _
                    & "CodIb =  '" & NormalizarIndex(cmbCondicionIB1.SelectedIndex) & "', " _
                    & "NroIb =  '" & Mid(Trim(txtNroIB.Text), 1, 20) & "', " _
                    & "NroInsc =  '" & Mid(Trim(txtNroSEDRONAR1.Text), 1, 15) & "', " _
                    & "Cai =  '', " _
                    & "VtoCai =  '', " _
                    & "TipoProv =  '" & NormalizarIndex(cmbRubro.SelectedIndex) & "', " _
                    & "CategoriaI =  '" & NormalizarIndex(cmbCategoria1.SelectedIndex) & "', " _
                    & "CategoriaII =  '" & NormalizarIndex(cmbCategoria2.SelectedIndex) & "', " _
                    & "Iso =  '" & NormalizarIndex(cmbCertificados.SelectedIndex) & "', " _
                    & "Region =  '" & NormalizarIndex(cmbRegion.SelectedIndex) & "', " _
                    & "PorceIb =  '" & Trim(txtPorcelProv.Text) & "', " _
                    & "Estado =  '" & NormalizarIndex(cmbEstado.SelectedIndex) & "', " _
                    & "Califica =  '" & NormalizarIndex(cmbCalificacion.SelectedIndex) & "', " _
                    & "FechaCalifica =  '" & Mid(Trim(txtCalificacion.Text), 1, 10) & "', " _
                    & "OrdFechaCalifica =  '" & Mid(_FechaComoOrd(txtCalificacion.Text), 1, 10) & "', " _
                    & "ObservacionesII =  '" & observaciones & "', " _
                    & "FechaCategoria =  '" & Mid(Trim(txtCategoria.Text), 1, 10) & "', " _
                    & "OrdFechaCategoria =  '" & Mid(_FechaComoOrd(txtCategoria.Text), 1, 10) & "', " _
                    & "FechaNroInsc =  '" & Mid(Trim(txtNroSEDRONAR2.Text), 1, 10) & "', " _
                    & "OrdFechaNroInsc =  '" & Mid(_FechaComoOrd(txtNroSEDRONAR2.Text), 1, 10) & "', " _
                    & "PorceIbCaba =  '" & Trim(txtPorcelCABA.Text) & "', " _
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
                    & "ClienteAsociado = '" & Mid(Trim(txtClienteAsociado.Text), 1, 6) & "', " _
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

    Private Sub _ActualizarProveedor(ByVal Clave As String)
        Dim ZSql As String = ""
        Dim _Empresas As New List(Of String) From {"SurfactanSA", "surfactan_II", "Surfactan_III", "Surfactan_IV", "Surfactan_V", "Surfactan_VI", "Surfactan_VII", "GastonPruebas"}
        Dim Xcs As String = "Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader

        ' Comprobamos que exista cuenta contable.
        ' Comprobamos que se haya informado tipo proveedor.
        ' Comprobamos que si se informó numero de sedrona, se haya cargado tambien la fecha.
        ' Comprobamos que numero de cuit sea correcto.

        ' Recorrer todos las plantas y actualizar en cada ocurrencia.

        For Each _Empresa In _Empresas

            Dim cs = Xcs.Replace("#EMPRESA#", _Empresa)

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

        ' Validamos el Cuit en caso de que se haya ingresado alguno.

        If Trim(txtCUIT.Text.Replace("/", "")) <> "" Then
            If Not _CuitValido(txtCUIT.Text) Then
                MsgBox("El CUIT indicado no es válido.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If


        ' Validamos la cuenta corriente en caso de que haya colocado alguna.
        If Trim(txtCuenta.Text) <> "" Then
            Dim cuentacontable As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(txtCuenta.Text)

            If IsNothing(cuentacontable) Then
                MsgBox("La cuenta contable indicada no existe.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If


        ' Validamos que se haya indicado fecha para sedronar en caso de que se haya colocado un valor.
        ' y que esta sea valida.
        If Trim(txtNroSEDRONAR1.Text) <> "" Then

            If Trim(txtNroSEDRONAR2.Text).Replace("/", "") = "" And Not Proceso._ValidarFecha(txtNroSEDRONAR2.Text) Then
                MsgBox("Se debe informar la fecha de vencimiento de Sedronar.", MsgBoxStyle.Information)
                Exit Sub
            End If

        End If

        ' Validamos los campos de fechas restantes.

        If cmbCalificacion.SelectedIndex > 0 Then

            If Not Proceso._ValidarFecha(txtCalificacion.Text) Then
                MsgBox("Debe ingresarse fecha de la Calificación.", MsgBoxStyle.Information)
                Exit Sub
            End If

        End If

        If cmbCertificados.SelectedIndex > 0 Then

            If Not Proceso._ValidarFecha(txtCertificados.Text) Then
                MsgBox("Debe ingresarse fecha del certificado.", MsgBoxStyle.Information)
                Exit Sub
            End If

        End If


        If Trim(txtClienteAsociado.Text) <> "" Then
            Dim c As Cliente = DAOCliente.buscarClientePorCodigo(Trim(txtClienteAsociado.Text))

            If IsNothing(c) Then
                MsgBox("El cliente indicado no es un cliente válido.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If


        ' Se supone que llegados hasta acá todos los datos introducidos son validos.

        Dim proveedor As Proveedor

        proveedor = DAOProveedor.buscarProveedorPorCodigo(txtCodigo.Text)

        ' Comprobamos si se trata de una actualización o de un proveedor nuevo.
        If Not IsNothing(proveedor) Then
            _ActualizarProveedor(proveedor.id)
            Exit Sub
        End If
        proveedor = New Proveedor(txtCodigo.Text, txtRazonSocial.Text)

        proveedor.direccion = txtDireccion.Text
        proveedor.localidad = txtLocalidad.Text
        proveedor.provincia = cmbProvincia.SelectedIndex
        proveedor.codPostal = txtCodigoPostal.Text
        proveedor.region = cmbRegion.SelectedIndex
        proveedor.telefono = txtTelefono.Text
        proveedor.diasPlazo = txtDiasPlazo.Text
        proveedor.email = txtEmail.Text
        proveedor.observaciones = txtObservaciones.Text
        proveedor.cuit = txtCUIT.Text
        proveedor.tipo = cmbTipoProveedor.SelectedIndex
        proveedor.codIva = cmbIVA.SelectedIndex
        proveedor.cuenta = DAOCuentaContable.buscarCuentaContablePorCodigo(txtCuenta.Text)
        proveedor.nombreCheque = txtCheque.Text
        proveedor.condicionIB1 = cmbCondicionIB1.SelectedIndex
        proveedor.condicionIB2 = cmbCondicionIB2.SelectedIndex
        proveedor.numeroIB = txtNroIB.Text
        proveedor.porceIBProvincia = CustomConvert.toDoubleOrZero(txtPorcelProv.Text)
        proveedor.porceIBCABA = CustomConvert.toDoubleOrZero(txtPorcelCABA.Text)
        proveedor.RawRubro = cmbRubro.SelectedIndex
        proveedor.numeroSEDRONAR = txtNroSEDRONAR1.Text
        proveedor.vtoSEDRONAR = txtNroSEDRONAR2.Text
        proveedor.categoria = cmbCategoria1.SelectedIndex
        proveedor.categoriaCalif = cmbCategoria2.SelectedIndex
        proveedor.vtoCategoria = txtCategoria.Text
        proveedor.tipoInscripcionIB = cmbInscripcionIB.SelectedIndex
        proveedor.cai = "" 'txtCAI.Text
        proveedor.vtoCAI = "" 'txtCAIVto.Text
        proveedor.certificados = cmbCertificados.SelectedIndex
        proveedor.vtoCertificados = txtCertificados.Text
        proveedor.estado = cmbEstado.SelectedIndex
        proveedor.calificacion = cmbCalificacion.SelectedIndex
        proveedor.vtoCalificacion = txtCalificacion.Text

        proveedor.observacionCompleta = observaciones
        proveedor.cufe1 = cufe1.Item1
        proveedor.cufe2 = cufe2.Item1
        proveedor.cufe3 = cufe3.Item1
        proveedor.dirCUFE1 = cufe1.Item2
        proveedor.dirCUFE2 = cufe2.Item2
        proveedor.dirCUFE3 = cufe3.Item2

        Dim cliente As Cliente = DAOCliente.buscarClientePorCodigo(Trim(txtClienteAsociado.Text))

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
            MsgBox("Error")
        End Try
    End Sub

    Private Sub borrar()
        Try
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
        txtCodigo.Text = proveedor.id
        txtRazonSocial.Text = proveedor.razonSocial
        txtDireccion.Text = proveedor.direccion
        txtLocalidad.Text = proveedor.localidad
        cmbProvincia.SelectedIndex = proveedor.provincia
        txtCodigoPostal.Text = proveedor.codPostal
        cmbRegion.SelectedIndex = proveedor.region
        txtTelefono.Text = proveedor.telefono
        txtDiasPlazo.Text = proveedor.diasPlazo
        txtEmail.Text = proveedor.email
        txtObservaciones.Text = proveedor.observaciones
        txtCUIT.Text = proveedor.cuit
        cmbTipoProveedor.SelectedIndex = proveedor.tipo
        cmbIVA.SelectedIndex = proveedor.codIva
        mostrarCuenta(proveedor.cuenta)
        txtCheque.Text = proveedor.nombreCheque
        cmbCondicionIB1.SelectedIndex = proveedor.condicionIB1
        cmbCondicionIB2.SelectedIndex = proveedor.condicionIB2
        txtNroIB.Text = proveedor.numeroIB
        txtPorcelProv.Text = proveedor.porceIBProvincia
        txtPorcelCABA.Text = proveedor.porceIBCABA
        'mostrarRubro(proveedor.rubro)
        cmbRubro.SelectedIndex = proveedor.RawRubro
        txtNroSEDRONAR1.Text = proveedor.numeroSEDRONAR
        txtNroSEDRONAR2.Text = proveedor.vtoSEDRONAR
        cmbCategoria1.SelectedIndex = proveedor.categoria
        cmbCategoria2.SelectedIndex = proveedor.categoriaCalif
        txtCategoria.Text = proveedor.vtoCategoria
        cmbInscripcionIB.SelectedIndex = proveedor.tipoInscripcionIB
        txtCAI.Text = "" 'proveedor.cai
        txtCAIVto.Text = "" ' proveedor.vtoCAI
        cmbCertificados.SelectedIndex = proveedor.certificados
        txtCertificados.Text = proveedor.vtoCertificados
        cmbEstado.SelectedIndex = proveedor.estado
        cmbCalificacion.SelectedIndex = proveedor.calificacion
        txtCalificacion.Text = proveedor.vtoCalificacion
        txtClienteAsociado.Text = Trim(proveedor.cliente.id)
        txtClienteAsociadoDescripcion.Text = Trim(proveedor.cliente.razon)

        CKBProveedorInactivo.Checked = IIf(proveedor.Inhabilitado = "0", False, True)

        observaciones = proveedor.observacionCompleta
        cufe1 = Tuple.Create(proveedor.cufe1, proveedor.dirCUFE1)
        cufe2 = Tuple.Create(proveedor.cufe2, proveedor.dirCUFE2)
        cufe3 = Tuple.Create(proveedor.cufe3, proveedor.dirCUFE3)

        txtPaginaWeb.Text = proveedor.PaginaWeb(0).ToString

        _Contacto1 = Tuple.Create(proveedor.contacto1(0).ToString, proveedor.contacto1(1).ToString, proveedor.contacto1(2).ToString, proveedor.contacto1(3).ToString)
        _Contacto2 = Tuple.Create(proveedor.contacto2(0).ToString, proveedor.contacto2(1).ToString, proveedor.contacto2(2).ToString, proveedor.contacto2(3).ToString)
        _Contacto3 = Tuple.Create(proveedor.contacto3(0).ToString, proveedor.contacto3(1).ToString, proveedor.contacto3(2).ToString, proveedor.contacto3(3).ToString)

    End Sub

    Private Sub mostrarCuenta(ByVal cuenta As CuentaContable)
        If Not IsNothing(cuenta) Then
            txtCuenta.Text = cuenta.id
            txtCuentaDescripcion.Text = cuenta.descripcion
        End If
    End Sub

    Private Sub mostrarRubro(ByVal rubro As RubroProveedor)
        If Not IsNothing(rubro) Then
            cmbRubro.SelectedItem = rubro.descripcion
        Else
            cmbRubro.SelectedValue = -1
        End If
    End Sub

    Private Sub listado()
        'DirectCast(Me.Controls("controlButtonsGroupBox").Controls("btnLastReg"), CustomButton).PerformClick()
        'Do While txtCodigo.Text <> "00000000001"
        '    DirectCast(Me.Controls("controlButtonsGroupBox").Controls("btnPreviousReg"), CustomButton).PerformClick()
        'Loop
    End Sub

    Private Sub btnObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservaciones.Click
        Dim formularioObservaciones As New ObservacionesProveedor()

        formularioObservaciones.CustomTextBox1.Text = observaciones
        If formularioObservaciones.ShowDialog(Me) = DialogResult.OK Then
            observaciones = formularioObservaciones.CustomTextBox1.Text
        End If
    End Sub

    Private Sub btnCUFE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCUFE.Click

        With CUFEProveedor

            .txtCUFE1.Text = cufe1.Item1
            .txtCUFE1Fecha.Text = cufe1.Item2
            .txtCUFE2.Text = cufe2.Item1
            .txtCUFE2Fecha.Text = cufe2.Item2
            .txtCUFE3.Text = cufe3.Item1
            .txtCUFE3Fecha.Text = cufe3.Item2()

            .ShowDialog()

            cufe1 = Tuple.Create(.txtCUFE1.Text, .txtCUFE1Fecha.Text)
            cufe2 = Tuple.Create(.txtCUFE2.Text, .txtCUFE2Fecha.Text)
            cufe3 = Tuple.Create(.txtCUFE3.Text, .txtCUFE3Fecha.Text)

        End With

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
        LBConsulta_Opciones.Visible = IIf(opcion = "", True, False)

        If opcion <> "" Then

            If LCase(opcion) = "proveedor" Then
                _ListarConsulta("Nombre", "Proveedor")
            ElseIf LCase(opcion) = "cuenta" Then
                _ListarConsulta("Descripcion", "Cuenta")
            End If

        Else
            _ExpandirFormulario()
        End If

    End Sub

    Private Sub _ContraerFormulario()

        Me.Height = MAIN_HEIGHT

    End Sub

    Private Sub _ExpandirFormulario()

        Me.Height = EXPANDED_HEIGHT

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
                _ListarConsulta("Nombre", "Proveedor")
            Case 1
                _ListarConsulta("Descripcion", "Cuenta")
            Case 2
                _ListarConsulta("Razon", "Cliente")
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
            Case "Cuenta"
                _TraerCuenta(LBConsulta.SelectedItem)
            Case "Cliente"
                _TraerCliente(LBConsulta.SelectedItem)
            Case Else
        End Select

    End Sub

    Private Sub _TraerCliente(ByVal clave As String)
        If Trim(clave) = "" Then : Exit Sub : End If
        Try
            ' Lo buscamos por nombre
            Dim cliente As List(Of Cliente) = DAOCliente.buscarClientePorNombre(Trim(clave))

            If cliente.Count > 0 Then

                txtClienteAsociado.Text = Trim(cliente(0).id)
                txtClienteAsociadoDescripcion.Text = Trim(cliente(0).razon)

            Else
                ' Lo buscamos por codigo.
                Dim cliente2 As Cliente = DAOCliente.buscarClientePorCodigo(Trim(clave))
                If Not IsNothing(cliente2) Then

                    txtClienteAsociado.Text = Trim(cliente2.id)
                    txtClienteAsociadoDescripcion.Text = Trim(cliente2.razon)

                Else
                    txtClienteAsociadoDescripcion.Text = ""
                End If

            End If
        Catch ex As Exception
            MsgBox("No se pudo consultar la base de datos para el cliente indicado.", MsgBoxStyle.Information)
            Exit Sub
        End Try

        _ContraerFormulario()

    End Sub

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged

        If LBConsulta_Filtrada.SelectedItem = "" Then
            Exit Sub
        End If

        Select Case TipoConsulta
            Case "Proveedor"
                _TraerProveedor(LBConsulta_Filtrada.SelectedItem)
            Case "Cuenta"
                _TraerCuenta(LBConsulta_Filtrada.SelectedItem)
            Case "Cliente"
                _TraerCliente(LBConsulta_Filtrada.SelectedItem)
            Case Else
        End Select

    End Sub

    Private Sub _TraerProveedor(ByVal nombre As String)
        Dim proveedor As List(Of Proveedor) = DAOProveedor.buscarProveedorPorNombre(nombre)

        If Not IsNothing(proveedor) Then

            mostrarProveedor(proveedor(0))

            _ContraerFormulario()

            txtCodigo.Focus()

        End If

    End Sub

    Private Sub _ListarConsulta(ByVal columnas As String, ByVal tabla As String)
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT " + columnas + " FROM " + tabla)
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                LBConsulta.Items.Clear()

                Do While dr.Read()

                    LBConsulta.Items.Add(dr.Item(0))

                Loop

                dr.Close()

                TipoConsulta = tabla
                LBConsulta_Opciones.Visible = False
                txtFiltrar.Enabled = True
                txtFiltrar.Focus()

                _ExpandirFormulario()

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

    Private Sub _TraerCuenta(ByVal descripcion)
        Dim cuenta As New List(Of CuentaContable)
        cuenta = DAOCuentaContable.buscarCuentaContablePorDescripcion(descripcion)

        If Not IsNothing(cuenta) Then

            txtCuenta.Text = cuenta(0).id
            txtCuentaDescripcion.Text = cuenta(0).descripcion

            _ContraerFormulario()
            txtCheque.Focus()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ProveedoresABM_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.DesktopLocation = New Point(200, 0)
        txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtCodigo.Text) = "" Then
                _AbrirConsulta("Proveedor")
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
            _SaltarA(cmbRegion)
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
        Dim valido As Boolean = False
        Dim suma As Integer = 0

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
            _SaltarA(txtCuenta)
        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If
    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuenta.KeyDown
        If e.KeyData = Keys.Enter Then


            If Trim(txtCuenta.Text) <> "" Then
                Dim cuenta As CuentaContable = DAOCuentaContable.buscarCuentaContablePorCodigo(txtCuenta.Text)
                If Not IsNothing(cuenta) Then
                    txtCuentaDescripcion.Text = cuenta.descripcion
                    _SaltarA(txtCheque)
                Else
                    txtCuentaDescripcion.Text = ""
                    txtCuenta.Focus()
                End If
            Else
                _SaltarA(txtCheque)
            End If

            
        ElseIf e.KeyData = Keys.Escape Then
            txtCuenta.Text = ""
        End If
    End Sub

    Private Sub txtCuentaDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCheque)
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
            _SaltarA(txtNroSEDRONAR1)
        ElseIf e.KeyData = Keys.Escape Then
            txtPorcelCABA.Text = ""
        End If
    End Sub

    Private Sub txtNroSEDRONAR1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroSEDRONAR1.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroSEDRONAR2)
        ElseIf e.KeyData = Keys.Escape Then
            txtNroSEDRONAR1.Text = ""
        End If
    End Sub

    Private Sub txtNroSEDRONAR2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroSEDRONAR2.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCertificados)
        ElseIf e.KeyData = Keys.Escape Then
            txtNroSEDRONAR2.Text = ""
        End If
    End Sub

    Private Sub txtCategoria_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbInscripcionIB)
        ElseIf e.KeyData = Keys.Escape Then
            txtCategoria.Text = ""
        End If
    End Sub

    Private Sub txtCertificados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCertificados.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCalificacion)
        ElseIf e.KeyData = Keys.Escape Then
            txtCertificados.Text = ""
        End If
    End Sub

    Private Sub cmbRegion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRegion.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtTelefono)
        ElseIf e.KeyData = Keys.Escape Then
            cmbRegion.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbRegion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.TextChanged
        _SaltarA(txtTelefono)
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

    Private Sub cmbRubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRubro.TextChanged
        _SaltarA(txtNroSEDRONAR1)
    End Sub

    Private Sub cmbRubro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbRubro.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroSEDRONAR1)
        ElseIf e.KeyData = Keys.Escape Then
            cmbRubro.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbCategoria1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCategoria1.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCategoria2)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCategoria1.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbCategoria1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria1.TextChanged
        _SaltarA(cmbCategoria2)
    End Sub

    Private Sub cmbCategoria2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCategoria2.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCategoria)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCategoria2.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCategoria2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoria2.TextChanged
        _SaltarA(txtCategoria)
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

    Private Sub cmbCertificados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCertificados.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCertificados)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCertificados.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCertificados_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCertificados.TextChanged
        _SaltarA(txtCertificados)
    End Sub

    Private Sub cmbCalificacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCalificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCalificacion)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCalificacion.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCalificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalificacion.TextChanged
        _SaltarA(txtCalificacion)
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

    End Sub

    Private Sub txtCuenta_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCuenta.MouseDoubleClick

            _AbrirConsulta("Cuenta")

    End Sub

    Private Sub txtCalificacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCalificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbEstado)
        End If

    End Sub

    Private Sub txtCertificados_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtCertificados.TypeValidationCompleted

        If Trim(txtCertificados.Text).Length = 10 Then
            e.Cancel = Not Proceso._ValidarFecha(txtCertificados.Text, e.IsValidInput)
        End If

    End Sub

    Private Sub txtNroSEDRONAR2_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtNroSEDRONAR2.TypeValidationCompleted
        If Trim(txtNroSEDRONAR2.Text).Length = 10 Then
            e.Cancel = Not Proceso._ValidarFecha(txtNroSEDRONAR2.Text, e.IsValidInput)
        End If
    End Sub

    Private Sub txtCalificacion_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtCalificacion.TypeValidationCompleted
        If Trim(txtCalificacion.Text).Length = 10 Then
            e.Cancel = Not Proceso._ValidarFecha(txtCalificacion.Text, e.IsValidInput)
        End If
    End Sub

    Private Sub cmbProvincia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProvincia.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtLocalidad)
        End If

    End Sub

    Private Sub cmbProvincia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.TextChanged
        _SaltarA(txtLocalidad)
    End Sub

    Private Sub txtClienteAsociado_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtClienteAsociado.MouseDoubleClick
        LBConsulta_Opciones.SelectedIndex = 2
        LBConsulta_Opciones_SelectedIndexChanged(Nothing, Nothing)
        _ExpandirFormulario()
    End Sub

    Private Sub txtClienteAsociado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClienteAsociado.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClienteAsociado.Text) <> "" Then
                _TraerCliente(Trim(txtClienteAsociado.Text))
            Else
                txtClienteAsociadoDescripcion.Text = ""
            End If
        End If

    End Sub

    Private Sub CKBProveedorInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CKBProveedorInactivo.CheckedChanged

        If CKBProveedorInactivo.Checked Then
            _Inhabilitado = "1"
        Else
            _Inhabilitado = "0"
        End If

    End Sub
End Class