Imports System.Data.SqlClient
Imports System.IO
Imports Emgu.CV

Public Class Form1

    Private capture As VideoCapture
    Private m As Mat = New Mat
    Private WHashNombre = ""
    Private _Extension = ".png"
    
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClasesCompartidas.Globals.empresa = "SURFACTAN"
        picFoto.AllowDrop = True
        btnLimpiar.PerformClick()
        
    End Sub

    Private Sub txtNroDocumento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroDocumento.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNroDocumento.Text) = "" Then : Exit Sub : End If

            Try
                ' Cargamos los datos de la Identificacion en caso de existir.
                _CargarIdentificacion()

                If Trim(txtObservaciones.Text).StartsWith(vbCrLf) Then
                    txtObservaciones.Text = txtObservaciones.Text.Substring(1, txtObservaciones.Text.Length - 1)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            txtApellido.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNroDocumento.Text = ""
        End If

    End Sub

    Private Sub _Limpiar()
        For Each txt In {txtApellido, txtDescProveedor, txtNombres, txtNroDocumento, txtObservaciones, txtProveedor}
            txt.Text = ""
        Next

        For Each txt As MaskedTextBox In {txtHastaFecha}
            txt.Clear()
        Next

        picFoto.Image = My.Resources.sin_imagen

        If File.Exists(WHashNombre) Then
            File.Delete(WHashNombre)
        End If

        txtNroDocumento.Focus()

    End Sub

    Private Sub _CargarIdentificacion()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim WNroDocumento = ""

        Try
            WNroDocumento = Trim(txtNroDocumento.Text)

            _Limpiar()

            txtNroDocumento.Text = WNroDocumento

            If WNroDocumento.Length < 8 Then Exit Sub

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT * FROM Identificaciones WHERE Dni = '" & WNroDocumento & "'"

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                With dr

                    txtApellido.Text = IIf(IsDBNull(.Item("Apellidos")), "", .Item("Apellidos"))
                    txtNombres.Text = IIf(IsDBNull(.Item("Nombres")), "", .Item("Nombres"))
                    txtProveedor.Text = IIf(IsDBNull(.Item("Proveedor")), "", .Item("Proveedor"))

                    txtHastaFecha.Text = IIf(IsDBNull(.Item("FechaHasta")), "", .Item("FechaHasta"))
                    txtObservaciones.Text = IIf(IsDBNull(.Item("ObservacionesI")), "", .Item("ObservacionesI"))

                    _CargarProveedor()

                    For Each txt In {txtNroDocumento, txtApellido, txtNombres, txtObservaciones, txtProveedor, txtDescProveedor}
                        txt.Text = Trim(txt.Text)
                    Next

                    ' Cargamos la foto en caso de que exista.

                    Dim WDestino As String = Configuration.ConfigurationManager.AppSettings("FOTOS_IDENTIFICACIONES")

                    If Directory.Exists(WDestino) Then

                        If File.Exists(WDestino & txtNroDocumento.Text & _Extension) Then

                            ' Para evitar bloqueo por recurso utilizado por otro proceso al querer eliminar el archivo temporal.
                            Dim img1 = Image.FromFile(WDestino & txtNroDocumento.Text & _Extension)
                            Dim img2 = New Bitmap(img1)

                            img1.Dispose()
                            img1 = Nothing

                            ' Cargamos la foto.
                            picFoto.Image = img2

                        End If

                    End If

                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _CargarProveedor()

        If Trim(txtProveedor.Text) = "" Then Exit Sub

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader
        Dim WPasa = "N"

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                txtDescProveedor.Text = IIf(IsDBNull(dr.Item("Nombre")), "", dr.Item("Nombre"))
                WPasa = "S"

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If WPasa = "N" Then
            Throw New Exception("Proveedor No Encontrado")
        End If

    End Sub

    Private Sub txtApellido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApellido.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtApellido.Text) = "" Then : Exit Sub : End If

            txtApellido.Text = txtApellido.Text.Capitalize

            txtNombres.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtApellido.Text = ""
        End If

    End Sub

    Private Sub txtNombres_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNombres.Text) = "" Then : Exit Sub : End If

            txtNombres.Text = txtNombres.Text.Capitalize

            txtProveedor.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtNombres.Text = ""
        End If

    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtProveedor.Text) = "" Then
                btnConsultas.PerformClick()
                Exit Sub
            End If

            Try
                _CargarProveedor()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            txtHastaFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtProveedor.Text = ""
        End If

    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtNroDocumento.Focus()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not _DatosValidos() Then Exit Sub

        Dim WClave, WDNI, WApellido, WNombres, WProveedor, WObservacionesI, WObservacionesII, WHastaFecha

        WDNI = Trim(txtNroDocumento.Text).SliceLeft(8)
        WApellido = Trim(txtApellido.Text).Capitalize.SliceLeft(30)
        WNombres = Trim(txtNombres.Text).Capitalize.SliceLeft(50)
        WProveedor = Trim(txtProveedor.Text).SliceLeft(11)

        WObservacionesI = Trim(txtObservaciones.Text).SliceLeft(200)
        WObservacionesII = ""

        WHastaFecha = txtHastaFecha.Text

        WClave = WProveedor & WDNI

        Try
            _GrabarIdentificacion(WClave, WDNI, WApellido, WNombres, WProveedor, WObservacionesI, WObservacionesII, WHastaFecha)
            '    MsgBox("Identificación guardada con éxito!", MsgBoxStyle.Information)

            If MsgBox("¿Desea imprimir la Identificación ahora?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                btnImprimir.PerformClick()
            End If

            btnLimpiar.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        txtNroDocumento.Focus()

    End Sub

    Private Sub _GrabarIdentificacion(ByVal WClave As String, ByVal WDNI As String, ByVal WApellido As String, ByVal WNombres As String, ByVal WProveedor As String, ByVal WObservacionesI As String, ByVal WObservacionesII As String, ByVal WHastaFecha As String)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim trans As SqlTransaction = Nothing
        Dim ZSql = ""
        Dim WHastaFechaOrd

        Try

            WHastaFechaOrd = Helper.ordenaFecha(WHastaFecha)

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction
            cm.Connection = cn
            cm.Transaction = trans

            ZSql = "DELETE FROM Identificaciones WHERE Clave = '" & WClave & "'"
            cm.CommandText = ZSql

            cm.ExecuteNonQuery()

            ZSql = ""
            ZSql = "INSERT INTO Identificaciones (" _
                 & "Clave," _
                 & "Dni," _
                 & "Proveedor," _
                 & "Apellidos," _
                 & "Nombres," _
                 & "FechaHasta," _
                 & "FechaHastaOrd," _
                 & "ObservacionesI," _
                 & "ObservacionesII" _
                 & ")" _
                 & " VALUES (" _
                 & "'" & WClave & "'," _
                 & "'" & WDNI & "'," _
                 & "'" & WProveedor & "'," _
                 & "'" & WApellido & "'," _
                 & "'" & WNombres & "'," _
                 & "'" & WHastaFecha & "'," _
                 & "'" & WHastaFechaOrd & "'," _
                 & "'" & WObservacionesI & "'," _
                 & "'" & WObservacionesII & "'" _
                 & ")"

            cm.CommandText = ZSql

            cm.ExecuteNonQuery()

            ' Guardamos la Foto de la Persona.

            _GuardarFoto(WDNI)

            trans.Commit()

        Catch ex As Exception
            If Not IsNothing(trans) Then
                trans.Rollback()
            End If
            Throw New Exception("Hubo un problema al querer Guardar/Actualizar la identificación en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub _GuardarFoto(ByVal wdni As String)
        Try

            Dim img As Bitmap = New Bitmap(200, 150)

            pnlFotoFinal.DrawToBitmap(img, New Rectangle(0, 0, img.Width, img.Height))

            Dim _CarpetaDestino As String = Configuration.ConfigurationManager.AppSettings("FOTOS_IDENTIFICACIONES")
            If Not Directory.Exists(_CarpetaDestino) Then
                Directory.CreateDirectory(_CarpetaDestino)
            End If

            img.Save(_CarpetaDestino & wdni & _Extension)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function _DatosValidos() As Boolean

        ' Validamos que:

        ' Se tengan datos minimos.
        If {txtNroDocumento, txtApellido, txtNombres, txtProveedor}.Any(Function(txt) Trim(txt.Text) = "") Then
            Return False
        End If

        ' Se tengan las fechas dónde es válida la credencial.
        If {txtHastaFecha}.Any(Function(txt) txt.Text.estaVacia) Then
            Return False
        End If

        If Not Helper._ValidarFecha(txtHastaFecha.Text) Then
            MsgBox("Las fechas deben ser Fechas válidas.", MsgBoxStyle.Exclamation)
            Return False
        End If

        ' El documento sea de long válida.
        If Len(txtNroDocumento.Text) < 8 Then Return False

        Try
            ' El proveedor exista.
            If Not _ExisteProveedor() Then Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Private Function _ExisteProveedor() As Boolean
        If Trim(txtProveedor.Text) = "" Then Return False

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Proveedor FROM Proveedor WHERE Proveedor = '" & Trim(txtProveedor.Text) & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el Proveedor en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Trim(txtNroDocumento.Text) = "" Or Trim(txtProveedor.Text) = "" Then Exit Sub

        If MsgBox("¿Está seguro de que quiere ELIMINAR esta Identificación?", MsgBoxStyle.YesNo) = vbNo Then
            txtNroDocumento.Focus()
            Exit Sub
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "DELETE FROM Identificaciones WHERE Clave = '" & txtProveedor.Text.Trim & txtNroDocumento.Text.Trim & "'"

            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        btnLimpiar.PerformClick()

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        _Limpiar()
    End Sub

    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click
        Try
            _CargarProveedores()
            lstFiltrada.Visible = False
            pnlConsulta.Visible = True
            txtAyuda.Text = ""
            txtAyuda.Focus()
        Catch ex As Exception
            pnlConsulta.Visible = False
            txtNroDocumento.Focus()
        End Try
    End Sub

    Private Sub _CargarProveedores()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand()
        Dim dr As SqlDataReader
        Dim WProveedores(), WIndices() As String
        Dim WAux = 0

        Try
            lstConsulta.Items.Clear()
            cmbIndices.Items.Clear()

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            cm.CommandText = "SELECT Count(Proveedor) as Total FROM Proveedor WHERE Nombre <> ''"
            dr = cm.ExecuteReader
            dr.Read()

            If dr.Item("Total") = 0 Then Exit Sub

            ReDim WProveedores(dr.Item("Total") - 1)
            ReDim WIndices(dr.Item("Total") - 1)

            If Not dr.IsClosed Then
                dr.Close()
            End If

            cm.CommandText = "SELECT Proveedor, Nombre FROM Proveedor WHERE Nombre <> '' ORDER BY Nombre"
            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()

                    WProveedores(WAux) = IIf(IsDBNull(dr.Item("Nombre")), "", dr.Item("Nombre"))
                    WIndices(WAux) = IIf(IsDBNull(dr.Item("Proveedor")), 0, dr.Item("Proveedor"))

                    WAux += 1

                Loop

            End If

            lstConsulta.Items.AddRange(WProveedores)
            cmbIndices.Items.AddRange(WIndices)

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer traer los Proveedores Disponibles desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    ' Rutinas de Filtrado Dinámico.
    Private Sub _FiltrarDinamicamente()
        Dim origen As ListBox = lstConsulta
        Dim final As ListBox = lstFiltrada
        Dim cadena As String = Trim(txtAyuda.Text)

        final.Items.Clear()

        If UCase(Trim(cadena)) <> "" Then

            For Each item In origen.Items

                If UCase(item.ToString()).Contains(UCase(Trim(cadena))) Then

                    final.Items.Add(item)

                End If

            Next

            final.Visible = True
            origen.Visible = False

        Else

            final.Visible = False
            origen.Visible = True

        End If
    End Sub

    Private Sub lstFiltrada_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiltrada.MouseClick
        Dim origen As ListBox = lstConsulta
        Dim filtrado As ListBox = lstFiltrada
        Dim texto As TextBox = txtAyuda

        If IsNothing(filtrado.SelectedItem) Then : Exit Sub : End If

        ' Buscamos el texto exacto del item seleccionado y seleccionamos el mismo item segun su indice en la lista de origen.
        origen.SelectedItem = filtrado.SelectedItem

        ' Llamamos al evento que tenga asosiado el control de origen.
        lstConsulta_Click(Nothing, Nothing)


        ' Sacamos de vista los resultados filtrados.
        filtrado.Visible = False
        texto.Text = ""
    End Sub

    Private Sub txtAyuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAyuda.TextChanged
        _FiltrarDinamicamente()
    End Sub

    Private Sub lstConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConsulta.Click
        Dim WIndice = ""

        Try
            cmbIndices.SelectedIndex = lstConsulta.SelectedIndex

            WIndice = cmbIndices.SelectedItem

            txtProveedor.Text = WIndice

            _CargarProveedor()

            pnlConsulta.Visible = False

            txtHastaFecha.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            txtAyuda.Focus()
        End Try

    End Sub

    Private Sub txtProveedor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtProveedor.MouseDoubleClick
        btnConsultas.PerformClick()
    End Sub

    Private Sub btnCerrarConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarConsulta.Click
        pnlConsulta.Visible = False
        txtProveedor.Focus()
    End Sub

    Private Sub picFoto_MouseDoubleClick()

        Try
            With OpenFileDialog1

                .Filter = "Imágenes (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png"

                .FileName = ""

                Dim result = .ShowDialog()

                If result = Windows.Forms.DialogResult.OK Then

                    picFoto.Image = Image.FromFile(.FileName)

                End If

            End With
        Catch ex As Exception
            MsgBox("Error al cargar la imagen seleccionada. Motivo: " & ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        picFoto_MouseDoubleClick()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If capture Is Nothing Then
            
            capture = New VideoCapture

            AddHandler capture.ImageGrabbed, AddressOf _Capture_ImageGrabbed

        End If

        capture.Start()

        pnlCamaraWeb.Visible = True

    End Sub

    Private Sub _Capture_ImageGrabbed(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            If Not IsNothing(capture) Then

                If capture.Retrieve(m) Then

                    PictureBox1.Image = m.Bitmap

                    System.Threading.Thread.Sleep(100)

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If capture IsNot Nothing Then
            
            capture.Dispose()

            capture = Nothing

            picFoto.Image = PictureBox1.Image

            pnlCamaraWeb.Visible = False

            txtNroDocumento.Focus()

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pnlCamaraWeb.Visible = False

        txtNroDocumento.Focus()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If WHashNombre <> "" AndAlso File.Exists(WHashNombre) Then
            picFoto.Dispose()
            File.Delete(WHashNombre)
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        ' Validamos que la credencial no se imprima despues del periodo de validez.
        If Not _ImpresionDentroDePeriodoDeValidez() Then

            txtHastaFecha.Focus()

            Exit Sub

        End If

        _ImprimirIdentificacion()

        txtNroDocumento.Focus()
    End Sub

    Private Sub _ImprimirIdentificacion()

        If Trim(txtNroDocumento.Text) <> "" Then
            
            txtNroDocumento_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            Dim tabla As New DataTable("Detalles")

            With tabla

                .Columns.Add("Dni")
                .Columns.Add("Apellidos")
                .Columns.Add("Nombres")
                .Columns.Add("DescProveedor")
                .Columns.Add("Foto")
                .Columns.Add("Empresa")
                .Columns.Add("Observaciones")
                .Columns.Add("Final")

            End With

            Dim row = tabla.NewRow

            With row
                .Item("Dni") = txtNroDocumento.Text
                .Item("Apellidos") = txtApellido.Text
                .Item("Nombres") = txtNombres.Text
                .Item("DescProveedor") = txtDescProveedor.Text
                .Item("Foto") = Configuration.ConfigurationManager.AppSettings("FOTOS_IDENTIFICACIONES") & txtNroDocumento.Text & _Extension
                .Item("Empresa") = "Surfactan S.A."
                .Item("Observaciones") = txtObservaciones.Text.Trim
                .Item("Final") = txtHastaFecha.Text
            End With

            tabla.Rows.Add(row)

            With VistaPrevia
                .Reporte = New Identificacion
                .Reporte.SetDataSource(tabla)
                '.Mostrar()
                .Imprimir()
            End With

        End If

    End Sub

    Private Function _ImpresionDentroDePeriodoDeValidez() As Boolean

        If txtHastaFecha.Text.estaVacia Then

            MsgBox("No hay fechas de validez cargada. La impresión se dentrá hasta que haya un periodo válido.", MsgBoxStyle.Exclamation)

            Return False

        End If

        Dim WFechaActual = Date.Now.ToString("dd/MM/yyyy")

        If WFechaActual.esMayorA(txtHastaFecha.Text) Then

            MsgBox("La impresión de la Identificación no puede realizarse después del Periodo de Validez.", MsgBoxStyle.Exclamation)

            Return False
        End If

        Return True

    End Function

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDocumento.KeyPress, txtProveedor.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtHastaFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHastaFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtHastaFecha.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtHastaFecha.Text) Then
                
                If Date.Now.ToString("dd/MM/yyyy").esMayorA(txtHastaFecha.Text) Then

                    MsgBox("La fecha de Finalización del periodo de validez, debe ser posterior o igual a la fecha de hoy.", MsgBoxStyle.Exclamation)

                    Exit Sub
                End If

                txtObservaciones.Focus()

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHastaFecha.Clear()
        End If

    End Sub
End Class
