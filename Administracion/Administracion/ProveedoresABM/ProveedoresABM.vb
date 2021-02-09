﻿Imports System.Configuration
Imports ClasesCompartidas
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports EvaluacionProvMPFarma

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
    Private Const MAIN_HEIGHT = 580
    'Private Const EXPANDED_HEIGHT = 720
    Private WBColorAntRazon As Color
    Private WColorAntRazon As Color
    Private WBColorAntEstado As Color
    Private WColorAntEstado As Color

    Private Sub ProveedoresABM_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Dim provincias = DAOProveedor.listarProvincias
        'cmbProvincia.DisplayMember = "ToString"
        'cmbProvincia.ValueMember = "valueMember"
        'cmbProvincia.DataSource = provincias
        Label2.Text = Globals.NombreEmpresa()

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

        _ContraerFormulario()

        setDefaults()
    End Sub

    Private Sub setDefaults()

        For Each Control As TextBox In Panel2.Controls.OfType(Of TextBox)()
            Control.Text = ""
        Next

        For Each Control As MaskedTextBox In Panel2.Controls.OfType(Of MaskedTextBox)()
            Control.Clear()
        Next

        For Each cmb As ComboBox In Panel2.Controls.OfType(Of ComboBox)()

            If cmb.Items.Count > 0 Then
                cmb.SelectedIndex = 0
            End If

        Next

        For Each cmb As ComboBox In GroupBox5.Controls.OfType(Of ComboBox)()
            cmb.SelectedIndex = 0
        Next

        For Each msk As MaskedTextBox In GroupBox5.Controls.OfType(Of MaskedTextBox)()
            msk.Clear()
        Next

        cmbInscripcionIB.SelectedIndex = 0
        cmbCondicionIB1.SelectedIndex = 0
        cmbCondicionIB2.SelectedIndex = 0
        txtNroIB.Text = ""
        txtPorcelProv.Text = ""
        txtPorcelCABA.Text = ""
        txtMailOp.Text = ""
        txtCbu.Text = ""

        ckAceptaCheques.Checked = False
        ckAceptaTransferencias.Checked = False

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

        cmbFormaPago.SelectedIndex = 0

        txtCodigo.Focus()

        Height = MAIN_HEIGHT
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
                    & "MailOp =  '" & Mid(Trim(txtMailOp.Text), 1, 250) & "', " _
                    & "Observaciones =  '" & Mid(Trim(txtObservaciones.Text), 1, 200) & "', " _
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
                    & "VtoIso =  '" & txtCertificados.Text & "', " _
                    & "Region =  '" & NormalizarIndex(cmbRegion.SelectedIndex) & "', " _
                    & "PorceIb =  " & formatonumerico(txtPorcelProv.Text) & ", " _
                    & "Estado =  '" & NormalizarIndex(cmbEstado.SelectedIndex) & "', " _
                    & "IbCiudadII =  '" & NormalizarIndex(cmbInscripcionIB.SelectedIndex) & "', " _
                    & "Califica =  '" & NormalizarIndex(cmbCalificacion.SelectedIndex) & "', " _
                    & "FechaCalifica =  '" & Mid(Trim(txtCalificacion.Text), 1, 10) & "', " _
                    & "OrdFechaCalifica =  '" & Mid(_FechaComoOrd(txtCalificacion.Text), 1, 10) & "', " _
                    & "ObservacionesII =  '" & observaciones & "', " _
                    & "FechaCategoria =  '" & Mid(Trim(txtCategoria.Text), 1, 10) & "', " _
                    & "OrdFechaCategoria =  '" & Mid(_FechaComoOrd(txtCategoria.Text), 1, 10) & "', " _
                    & "FechaNroInsc =  '" & Mid(Trim(txtNroSEDRONAR2.Text), 1, 10) & "', " _
                    & "OrdFechaNroInsc =  '" & Mid(_FechaComoOrd(txtNroSEDRONAR2.Text), 1, 10) & "', " _
                    & "PorceIbCaba =  " & formatonumerico(txtPorcelCABA.Text) & ", " _
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
                    & "Cbu = '" & Trim(txtCbu.Text) & "', " _
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
            cn.Close()
        End Try

    End Sub

    Private Sub _ActualizarProveedor()
        'Dim ZSql As String = ""
        Dim _Empresas As List(Of String)

        Dim Xcs As String = ConfigurationManager.ConnectionStrings(Globals.empresa).ToString '"Data Source=193.168.0.7;Initial Catalog=#EMPRESA#;User ID=usuarioadmin; Password=usuarioadmin"

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()
        Dim dr As SqlDataReader

        ' DETERMINO LAS EMPRESAS CON LAS QUE TRABAJAR.
        _Empresas = Empresas

        ' Recorrer todos las plantas y actualizar en cada ocurrencia.

        For Each _Empresa In _Empresas
            Dim Wrem = "SurfactanSA"

            If _EsPellital Then
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

        Dim WAceptaCheques As Short = IIf(ckAceptaCheques.Checked, 1, 0)
        Dim WAceptaTransferencias As Short = IIf(ckAceptaTransferencias.Checked, 1, 0)

        For Each empresa As String In Proceso.Empresas
            ExecuteNonQueries(empresa, {"UPDATE Proveedor SET FormaPago = '" & cmbFormaPago.SelectedIndex & "', AceptaCheques = '" & WAceptaCheques & "', AceptaTransferencias = '" & WAceptaTransferencias & "' WHERE Proveedor = '" & txtCodigo.Text & "'"})
        Next

        If (_ProveedorExistente(txtCodigo.Text)) Then
            _ActualizarCertificadosProveedor(txtCodigo.Text)
        End If

        MsgBox("Proveedor Actualiza correctamente!", MsgBoxStyle.Information)

        btnLimpiar.PerformClick()

    End Sub

    Private Sub agregar()
        Dim _Autorizado As Boolean

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

        '
        ' Validamos la longitud en caso de ser Cargado.
        '
        If txtCbu.Text.Trim <> "" Then
            If txtCbu.Text.Trim.Length < 22 Then
                MsgBox("El CBU indicado no es válido.", MsgBoxStyle.Information)
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
        Dim WPorcelProv = formatonumerico(txtPorcelProv.Text)
        Dim WPorcelCABA = formatonumerico(txtPorcelCABA.Text)

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
        proveedor.porceIBProvincia = Val(WPorcelProv)
        proveedor.porceIBCABA = Val(WPorcelCABA)
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

            If (_ProveedorExistente(txtCodigo.Text)) Then
                _ActualizarCertificadosProveedor(txtCodigo.Text)
                _ActualizarVariosProveedor(txtCodigo.Text)
            End If

            Dim WAceptaCheques As Short = IIf(ckAceptaCheques.Checked, 1, 0)
            Dim WAceptaTransferencias As Short = IIf(ckAceptaTransferencias.Checked, 1, 0)

            For Each empresa As String In Proceso.Empresas
                ExecuteNonQueries(empresa, {"UPDATE Proveedor SET FormaPago = '" & cmbFormaPago.SelectedIndex & "', AceptaCheques = '" & WAceptaCheques & "', AceptaTransferencias = '" & WAceptaTransferencias & "' WHERE Proveedor = '" & txtCodigo.Text & "'"})
            Next

            MsgBox("Proveedor guardado correctamente.", MsgBoxStyle.Information)
            btnLimpiar.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _ActualizarVariosProveedor(ByVal WProveedor As String)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()

        Try

            cn.ConnectionString = _ConectarA()
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "UPDATE Proveedor SET MailOp = '" & txtMailOp.Text.Trim & "', Cbu = '" & txtCbu.Text.Trim & "' WHERE Proveedor = '" & WProveedor & "'"

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar los certificados del Proveeodr en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try

    End Sub

    Private Sub _ActualizarCertificadosProveedor(ByVal WProveedor As String)

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand()

        Try

            cn.ConnectionString = _ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "UPDATE Proveedor SET Iso2 = " & NormalizarIndex(cmbCertificados2.SelectedIndex) & ", VtoIso2 = '" & txtCertificados2.Text & "', Iso3 = " & NormalizarIndex(cmbCertificados3.SelectedIndex) & ", VtoIso3 = '" & txtCertificados3.Text & "' WHERE Proveedor = '" & WProveedor & "'"

            cm.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer actualizar los certificados del Proveeodr en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try

    End Sub

    Private Function _ProveedorExistente(ByVal WProveedor As String) As Boolean

        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Proveedor FROM Proveedor WHERE Proveedor = '" & WProveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Proveedor en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()

        End Try

    End Function

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

        txtClienteAsociado.Text = ""
        txtClienteAsociadoDescripcion.Text = ""

        If Not IsNothing(proveedor.cliente) Then
            txtClienteAsociado.Text = Trim(proveedor.cliente.id)
            txtClienteAsociadoDescripcion.Text = Trim(proveedor.cliente.razon)
        End If

        CKBProveedorInactivo.Checked = proveedor.Inhabilitado <> "0"

        observaciones = proveedor.observacionCompleta
        cufe1 = Tuple.Create(proveedor.cufe1, proveedor.dirCUFE1)
        cufe2 = Tuple.Create(proveedor.cufe2, proveedor.dirCUFE2)
        cufe3 = Tuple.Create(proveedor.cufe3, proveedor.dirCUFE3)

        txtPaginaWeb.Text = proveedor.PaginaWeb(0).ToString

        _Contacto1 = Tuple.Create(proveedor.contacto1(0).ToString, proveedor.contacto1(1).ToString, proveedor.contacto1(2).ToString, proveedor.contacto1(3).ToString)
        _Contacto2 = Tuple.Create(proveedor.contacto2(0).ToString, proveedor.contacto2(1).ToString, proveedor.contacto2(2).ToString, proveedor.contacto2(3).ToString)
        _Contacto3 = Tuple.Create(proveedor.contacto3(0).ToString, proveedor.contacto3(1).ToString, proveedor.contacto3(2).ToString, proveedor.contacto3(3).ToString)

        ' Buscamos si el proveedor se encuentra en estado de Embargo
        If _ProveedorEmbargado() Then
            txtRazonSocial.BackColor = Color.Red
            txtRazonSocial.ForeColor = Color.White
        End If

        txtMailOp.Text = _ProveedorMailOp().Trim

        ' Verificas si se encuentra en estado
        If Val(proveedor.estado) = 2 Then
            cmbEstado.BackColor = Color.Red
            cmbEstado.ForeColor = Color.White
        End If

        Dim WProv As DataRow = GetSingle("SELECT FormaPago, AceptaCheques, AceptaTransferencias, Cbu FROM Proveedor WHERE Proveedor = '" & proveedor.id & "'")

        cmbFormaPago.SelectedIndex = 0
        ckAceptaCheques.Checked = False

        If WProv IsNot Nothing Then
            txtCbu.Text = Trim(OrDefault(WProv.Item("Cbu"), ""))
            cmbFormaPago.SelectedIndex = Val(OrDefault(WProv.Item("FormaPago"), "0"))
            ckAceptaCheques.Checked = Val(OrDefault(WProv("AceptaCheques"), "")) = 1
            ckAceptaTransferencias.Checked = Val(OrDefault(WProv("AceptaTransferencias"), "")) = 1
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

            cn.Close()

        End Try

        Return embargado
    End Function

    Private Function _ProveedorMailOp() As String
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT MailOp FROM Proveedor WHERE Proveedor = '" & Trim(txtCodigo.Text) & "'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                Return IIf(IsDBNull(dr.Item("MailOp")), "", dr.Item("MailOp"))

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            cn.Close()

        End Try

        Return ""
    End Function

    Private Sub mostrarCuenta(ByVal cuenta As CuentaContable)
        If Not IsNothing(cuenta) Then
            txtCuenta.Text = cuenta.id
            txtCuentaDescripcion.Text = cuenta.descripcion
        End If
    End Sub

    '    Private Sub mostrarRubro(ByVal rubro As RubroProveedor)
    '        If Not IsNothing(rubro) Then
    '            cmbRubro.SelectedItem = rubro.descripcion
    '        Else
    '            cmbRubro.SelectedValue = -1
    '        End If
    '    End Sub

    '    Private Sub listado()
    '        'DirectCast(Controls("controlButtonsGroupBox").Controls("btnLastReg"), CustomButton).PerformClick()
    '        'Do While txtCodigo.Text <> "00000000001"
    '        '    DirectCast(Controls("controlButtonsGroupBox").Controls("btnPreviousReg"), CustomButton).PerformClick()
    '        'Loop
    '    End Sub

    Private Sub btnObservaciones_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnObservaciones.Click
        Dim formularioObservaciones As New ObservacionesProveedor()

        formularioObservaciones.CustomTextBox1.Text = observaciones
        If formularioObservaciones.ShowDialog(Me) = DialogResult.OK Then
            observaciones = formularioObservaciones.CustomTextBox1.Text
        End If
    End Sub

    Private Sub btnCUFE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCUFE.Click

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

    Private Sub btnPrimerRegistro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrimerRegistro.Click
        _NavegarHaciaEl("primero")
    End Sub

    Private Sub btnUltimoRegistro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUltimoRegistro.Click
        _NavegarHaciaEl("ultimo")
    End Sub

    Private Sub btnSiguienteRegistro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguienteRegistro.Click
        _NavegarHaciaEl("siguiente", txtCodigo.Text)
    End Sub

    Private Sub btnAnteriorRegistro_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnteriorRegistro.Click
        _NavegarHaciaEl("anterior", txtCodigo.Text)
    End Sub

    Private Sub _NavegarHaciaEl(ByVal direccion As String, Optional ByVal registroActual As String = "")

        Dim proveedores As DataTable

        proveedores = SQLConnector.retrieveDataTable("get_proveedor", direccion, registroActual)

        If proveedores.Rows.Count > 0 Then
            Dim proveedor As Proveedor

            proveedor = DAOProveedor.buscarProveedorPorCodigo(proveedores(0)(0))

            If Not IsNothing(proveedor) Then

                mostrarProveedor(proveedor)

            End If

            txtCodigo.Focus()

        End If


    End Sub

    Private Sub btnAgregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregar.Click
        agregar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEliminar.Click
        borrar()
    End Sub

    Private Sub btnListado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnListado.Click
        With VistaPrevia
            .Reporte = New ListadoResumidoProveedores
            .Mostrar()
        End With
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsulta.Click
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

        'Height = MAIN_HEIGHT
        GrupoConsultas.Visible = False

    End Sub

    Private Sub _ExpandirFormulario()

        'Height = EXPANDED_HEIGHT
        GrupoConsultas.Visible = True

    End Sub

    Private Sub txtFiltrar_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFiltrar.TextChanged

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

    Private Sub LBConsulta_Opciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LBConsulta_Opciones.SelectedIndexChanged

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

    Private Sub LBConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LBConsulta.SelectedIndexChanged

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
            Case "TipoProv"
                _TraerRubros(LBConsulta.SelectedItem)
        End Select

        _ContraerFormulario()

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

    Private Sub LBConsulta_Filtrada_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LBConsulta_Filtrada.SelectedIndexChanged

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
            Case "TipoProv"
                _TraerRubros(LBConsulta_Filtrada.SelectedItem)
        End Select

        _ContraerFormulario()

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
        'Dim proveedor As List(Of Proveedor) = DAOProveedor.buscarProveedorPorNombre(Trim(nombre.Substring(11, nombre.Length - 11)))
        Dim proveedor As Proveedor = DAOProveedor.buscarProveedorPorCodigo(Trim(Microsoft.VisualBasic.Left(nombre, 11)))

        If Not IsNothing(proveedor) Then

            mostrarProveedor(proveedor)

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

            cn.Close()

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

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ProveedoresABM_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        'DesktopLocation = New Point(200, 0)
        txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigo.KeyDown

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

                If _ProveedorExistente(codigo) Then
                    _CargarCertificadosExtras(codigo)
                End If

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

    Private Sub _CargarCertificadosExtras(ByVal WProveedor As String)
        Dim cn = New SqlConnection()
        Dim cm = New SqlCommand("SELECT Iso2, VtoIso2, Iso3, VtoIso3 FROM Proveedor WHERE Proveedor = '" & WProveedor & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = _ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                With dr
                    .Read()
                    cmbCertificados2.SelectedIndex = IIf(IsDBNull(.Item("Iso2")), 0, .Item("Iso2"))
                    txtCertificados2.Text = IIf(IsDBNull(.Item("VtoIso2")), "", .Item("VtoIso2"))
                    cmbCertificados3.SelectedIndex = IIf(IsDBNull(.Item("Iso3")), 0, .Item("Iso3"))
                    txtCertificados3.Text = IIf(IsDBNull(.Item("VtoIso3")), "", .Item("VtoIso3"))

                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al traer los datos de los Certificados Extras desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _SaltarA(ByRef control As Control)
        control.Focus()
    End Sub

    Private Sub txtRazonSocial_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtRazonSocial.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtDireccion)
        ElseIf e.KeyData = Keys.Escape Then
            txtRazonSocial.Text = ""
        End If
    End Sub

    Private Sub txtDireccion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbProvincia)
        ElseIf e.KeyData = Keys.Escape Then
            txtDireccion.Text = ""
        End If
    End Sub

    Private Sub txtLocalidad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLocalidad.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCodigoPostal)
        ElseIf e.KeyData = Keys.Escape Then
            txtLocalidad.Text = ""
        End If
    End Sub

    Private Sub txtCodigoPostal_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCodigoPostal.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbRegion)
        ElseIf e.KeyData = Keys.Escape Then
            txtCodigoPostal.Text = ""
        End If
    End Sub

    Private Sub txtTelefono_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTelefono.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtEmail)
        ElseIf e.KeyData = Keys.Escape Then
            txtTelefono.Text = ""
        End If
    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtMailOp)
        ElseIf e.KeyData = Keys.Escape Then
            txtEmail.Text = ""
        End If
    End Sub

    Private Sub txtEmailOp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMailOp.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtDiasPlazo)
        ElseIf e.KeyData = Keys.Escape Then
            txtMailOp.Text = ""
        End If
    End Sub

    Private Sub txtDiasPlazo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDiasPlazo.KeyDown
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

    Private Sub txtCUIT_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCUIT.KeyDown
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

    Private Sub txtObservaciones_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtObservaciones.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCuenta)
        ElseIf e.KeyData = Keys.Escape Then
            txtObservaciones.Text = ""
        End If
    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCuenta.KeyDown
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

    Private Sub txtCuentaDescripcion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCuentaDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCheque)
        End If
    End Sub

    Private Sub txtCheque_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCheque.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCheque)
        ElseIf e.KeyData = Keys.Escape Then
            txtCheque.Text = ""
        End If
    End Sub

    Private Sub txtNroIB_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNroIB.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPorcelProv)
        ElseIf e.KeyData = Keys.Escape Then
            txtNroIB.Text = ""
        End If
    End Sub

    Private Sub txtPorcelProv_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPorcelProv.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCondicionIB2)
        ElseIf e.KeyData = Keys.Escape Then
            txtPorcelProv.Text = ""
        End If
    End Sub

    Private Sub txtPorcelCABA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPorcelCABA.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroSEDRONAR1)
        ElseIf e.KeyData = Keys.Escape Then
            txtPorcelCABA.Text = ""
        End If
    End Sub

    Private Sub txtNroSEDRONAR1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNroSEDRONAR1.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroSEDRONAR2)
        ElseIf e.KeyData = Keys.Escape Then
            txtNroSEDRONAR1.Text = ""
        End If
    End Sub

    Private Sub txtNroSEDRONAR2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNroSEDRONAR2.KeyDown
        If e.KeyData = Keys.Enter Then
            If _ValidarFecha(txtNroSEDRONAR2.Text) Then : Exit Sub : End If

            _SaltarA(cmbCertificados)
        ElseIf e.KeyData = Keys.Escape Then
            txtNroSEDRONAR2.Text = ""
        End If
    End Sub

    Private Sub txtCategoria_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbInscripcionIB)
        ElseIf e.KeyData = Keys.Escape Then
            txtCategoria.Text = ""
        End If
    End Sub

    Private Sub txtCertificados_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCertificados.KeyDown, txtCertificados3.KeyDown, txtCertificados2.KeyDown
        If e.KeyData = Keys.Enter Then
            If _ValidarFecha(txtCertificados.Text) Then : Exit Sub : End If
            _SaltarA(cmbCalificacion)
        ElseIf e.KeyData = Keys.Escape Then
            txtCertificados.Text = ""
        End If
    End Sub

    Private Sub cmbRegion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbRegion.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtTelefono)
        ElseIf e.KeyData = Keys.Escape Then
            cmbRegion.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbRegion_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRegion.TextChanged
        _SaltarA(txtTelefono)
    End Sub

    Private Sub cmbTipoProveedor_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipoProveedor.TextChanged
        _SaltarA(cmbIVA)
    End Sub

    Private Sub cmbTipoProveedor_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbTipoProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbIVA)
        ElseIf e.KeyData = Keys.Escape Then
            cmbTipoProveedor.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbIVA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbIVA.KeyDown

        If e.KeyData = Keys.Enter Then

            If cmbIVA.SelectedIndex = 5 Then ' Monotributo
                cmbTipoProveedor.SelectedIndex = 3 ' Exento
            End If

            _SaltarA(txtObservaciones)
        ElseIf e.KeyData = Keys.Escape Then
            cmbIVA.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbIVA_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbIVA.TextChanged
        If cmbIVA.SelectedIndex = 5 Then ' Monotributo
            cmbTipoProveedor.SelectedIndex = 3 ' Exento
        End If
        _SaltarA(txtObservaciones)
    End Sub

    Private Sub cmbCondicionIB1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbCondicionIB1.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroIB)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCondicionIB1.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCondicionIB1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCondicionIB1.TextChanged
        _SaltarA(txtNroIB)
    End Sub

    Private Sub cmbCondicionIB2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbCondicionIB2.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbInscripcionIB)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCondicionIB2.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCondicionIB2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCondicionIB2.TextChanged
        _SaltarA(cmbInscripcionIB)
    End Sub

    Private Sub cmbRubro_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRubro.TextChanged, cmbFormaPago.TextChanged
        _SaltarA(txtNroSEDRONAR1)
    End Sub

    Private Sub cmbRubro_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbRubro.KeyDown, cmbFormaPago.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(txtNroSEDRONAR1)
        ElseIf e.KeyData = Keys.Escape Then
            cmbRubro.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbCategoria1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbCategoria1.KeyDown
        If e.KeyData = Keys.Enter Then
            _SaltarA(cmbCategoria2)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCategoria1.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbCategoria1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCategoria1.TextChanged
        _SaltarA(cmbCategoria2)
    End Sub

    Private Sub cmbCategoria2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbCategoria2.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCategoria)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCategoria2.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCategoria2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCategoria2.TextChanged
        _SaltarA(txtCategoria)
    End Sub

    Private Sub cmbInscripcionIB_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbInscripcionIB.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPorcelCABA)
        ElseIf e.KeyData = Keys.Escape Then
            cmbInscripcionIB.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbInscripcionIB_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbInscripcionIB.TextChanged
        _SaltarA(txtPorcelCABA)
    End Sub

    Private Sub cmbEstado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbEstado.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtPaginaWeb)
        ElseIf e.KeyData = Keys.Escape Then
            cmbEstado.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbEstado_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEstado.TextChanged
        _SaltarA(txtPaginaWeb)
    End Sub

    Private Sub cmbCertificados_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbCertificados.KeyDown, cmbCertificados3.KeyDown, cmbCertificados2.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCertificados)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCertificados.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCertificados_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCertificados.TextChanged, cmbCertificados3.TextChanged, cmbCertificados2.TextChanged
        _SaltarA(txtCertificados)
    End Sub

    Private Sub cmbCalificacion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbCalificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtCalificacion)
        ElseIf e.KeyData = Keys.Escape Then
            cmbCalificacion.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbCalificacion_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCalificacion.TextChanged
        _SaltarA(txtCalificacion)
    End Sub

    Private Sub btnContactos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnContactos.Click
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

    Private Sub txtPaginaWeb_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPaginaWeb.MouseDoubleClick
        _VisitarPaginaWeb()
    End Sub

    Private Sub _VisitarPaginaWeb()
        Dim _Direccion As String = LCase(Trim(txtPaginaWeb.Text))
        Dim regex As New Regex("^(http\:\/\/)")

        ' Corroboramos que haya contenido.
        If Trim(_Direccion) = "" Then
            Exit Sub
        End If

        ' Corroboramos que comience el protocolo.
        If Not regex.IsMatch(_Direccion) Then
            _Direccion = "http://" & _Direccion
        End If

        regex = New Regex("\.[a-z]+(\/)?$")

        ' Corroboramos que tenga una extension.
        If Not regex.IsMatch(_Direccion) Then

            ' Corroboramos que pueda ser un formato de dirección valido.
            regex = New Regex("^(http:\/\/)\w+(\.[a-z]+(\/)?)$")

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

    Private Sub txtCodigo_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCodigo.MouseDoubleClick

        _AbrirConsulta("Proveedor")
        txtFiltrar.Focus()

    End Sub

    Private Sub txtCuenta_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCuenta.MouseDoubleClick

        _AbrirConsulta("Cuenta")
        txtFiltrar.Focus()

    End Sub

    Private Sub txtCalificacion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCalificacion.KeyDown

        If e.KeyData = Keys.Enter Then
            If _ValidarFecha(txtCalificacion.Text) Then : Exit Sub : End If
            _SaltarA(cmbEstado)
        End If

    End Sub

    Private Function _ValidarFecha(ByVal fecha As String) As Boolean
        Dim valido = True

        If Trim(fecha.Replace("/", "")) = "" Then
            valido = Proceso._ValidarFecha(fecha)
        End If

        Return valido
    End Function

    'Private Sub txtCertificados_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)

    '    If Trim(txtCertificados.Text).Length = 10 Then
    '        e.Cancel = _ValidarFecha(txtCertificados.Text)
    '    End If

    'End Sub

    'Private Sub txtNroSEDRONAR2_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)
    '    If Trim(txtNroSEDRONAR2.Text).Length = 10 Then
    '        e.Cancel = _ValidarFecha(txtNroSEDRONAR2.Text)
    '    End If
    'End Sub

    'Private Sub txtCalificacion_TypeValidationCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs)
    '    If Trim(txtCalificacion.Text).Length = 10 Then
    '        e.Cancel = _ValidarFecha(txtCalificacion.Text)
    '    End If
    'End Sub

    Private Sub cmbProvincia_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbProvincia.KeyDown

        If e.KeyData = Keys.Enter Then
            _SaltarA(txtLocalidad)
        End If

    End Sub

    Private Sub cmbProvincia_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProvincia.TextChanged
        _SaltarA(txtLocalidad)
    End Sub

    Private Sub txtClienteAsociado_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtClienteAsociado.MouseDoubleClick
        LBConsulta_Opciones.SelectedIndex = 2
        LBConsulta_Opciones_SelectedIndexChanged(Nothing, Nothing)
        _ExpandirFormulario()
        txtFiltrar.Focus()
    End Sub

    Private Sub txtClienteAsociado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtClienteAsociado.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtClienteAsociado.Text) <> "" Then
                _TraerCliente(Trim(txtClienteAsociado.Text))
            Else
                txtClienteAsociadoDescripcion.Text = ""
            End If
        End If

    End Sub

    Private Sub CKBProveedorInactivo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CKBProveedorInactivo.CheckedChanged

        If CKBProveedorInactivo.Checked Then
            _Inhabilitado = "1"
        Else
            _Inhabilitado = "0"
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCodigo.KeyPress, txtCodigoPostal.KeyPress, txtCuenta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        'Dim _provedores As New List(Of String) From {"01000000012", "01000000001", "00000000008", "10008321238", "1000466464 ", "00000000010", "00000000009", "10067727539", "10999888782", "10014871417", "10053801902"}

        'For Each _Proveedor As String In _provedores
        '    txtCodigo.Text = _Proveedor
        '    txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        '    btnAgregar.PerformClick()
        'Next

    End Sub

    Private Sub btnCerrarConsultas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrarConsultas.Click
        _ContraerFormulario()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        If Val(txtCodigo.Text) = 0 Then Exit Sub

        With New EncuestaFarma(txtCodigo.Text, txtEmail.Text)
            .ShowDialog(Me)
        End With

    End Sub

    Private Sub btnEvaluacion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEvaluacion.Click

        If Val(txtCodigo.Text) = 0 Or Len(txtCodigo.Text.Trim()) < 11 Then Exit Sub

        '
        ' Se llama a la ventana de Evaluación de Proveedor por Materia Prima.
        '
        Dim frm As New EvaluacionProveedorMateriaPrima(txtCodigo.Text)

        frm.ShowDialog(Me)

        GC.Collect()

    End Sub
End Class