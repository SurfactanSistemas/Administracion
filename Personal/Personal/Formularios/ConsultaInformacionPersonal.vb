Imports System.Data.SqlClient

Public Class ConsultaInformacionPersonal

    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
      Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
      ' Limpiamos los campos.
      _LimpiarCampos()

      ' Limpiamos los archivos cargados en notas.

      ' Posicionamos en Orden y mostramos la primer pestaña.
      TabControl1.SelectedIndex = 0
      txtDni.Focus()
    End Sub

    Private Sub _LimpiarCampos()

      For Each _txt As TextBox In _CamposDeTexto()
        _txt.Text = ""
      Next

      For Each _m As MaskedTextBox In {}
        _m.Clear()
      Next

      For Each _c As ComboBox In {}
        _c.SelectedIndex = 0
      Next

      pnlConsulta.Visible = False
    End Sub

    Private Function _CamposDeTexto() As TextBox()
      Return {txtAyuda}
    End Function

    Private Sub IngresoOrdenTrabajo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
      txtDni.Focus
    End Sub

    Private Sub txtDni_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDni.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        If Trim(txtDni.Text) = "" Then : Exit Sub : End If

            ' Rutina para cargar los datos.
            Try
                
                _CargarDatos()

                txtFechaNacimiento.Focus

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        ElseIf e.KeyData = Keys.Escape Then
            txtDni.Text = ""
        End If
    
    End Sub

    Private Sub _CargarDatos()
        
        Try
            ' Busco los datos provenientes del Legajo.
            _CargarDatosLegajo()



        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Private Sub _CargarDatosLegajo()
        
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, FechaVersion, FIngreso, FEgreso, Descripcion FROM Legajo WHERE Dni = '" & txtDni.Text & "' AND Renglon = 1")
        Dim dr As SqlDataReader
        Dim WLegajoActual, WLegajos, WAux, WFechaVersion, WFechaVersionOrd, WNombreCompleto, WFechaIngreso, WFechaEgreso As String

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                WLegajos = ""

                Do While dr.Read

                    With dr

                        WFechaVersion = IIf(IsDBNull(.Item("FechaVersion")), "", .Item("FechaVersion"))
                        WAux = Helper.ordenaFecha(WFechaVersion)
                        WLegajoActual = IIf(IsDBNull(.Item("Codigo")), "", .Item("Codigo"))

                        WLegajos &= IIf(Trim(wlegajos) <> "", " - " & WLegajoActual, WLegajoActual)

                        If Val(WAux) > Val(WFechaVersionOrd) then
                            WFechaVersionOrd = WAux

                            WNombreCompleto = IIf(IsDBNull(.Item("Descripcion")), "", .Item("Descripcion"))
                            WFechaIngreso = IIf(IsDBNull(.Item("FIngreso")), "", .Item("FIngreso"))
                            WFechaEgreso = IIf(IsDBNull(.Item("FEgreso")), "", .Item("FEgreso"))

                        End If

                    End With

                Loop

                txtLegajo.Text= WLegajos
                txtFechaIngreso.Text=WFechaIngreso
                txtFechaEgreso.Text=IIf(WFechaEgreso = "00/00/0000", "  /  /    ", WFechaEgreso)
                txtNombreCompleto.Text = trim(WNombreCompleto)

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

    Private Sub txtNombreCompleto_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreCompleto.KeyDown
        
        
        If e.KeyData = Keys.Enter Then
	        If Trim(txtNombreCompleto.Text) = "" Then : Exit Sub : End If

            txtFechaNacimiento.Focus
            
        ElseIf e.KeyData = Keys.Escape Then
            txtNombreCompleto.Text = ""
        End If
        
      
        
    End Sub

    Private Sub txtFechaNacimiento_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaNacimiento.KeyDown
    
        If e.KeyData = Keys.Enter Then
	        'If txtFechaNacimiento.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtFechaNacimiento.Text) then
                txtCalle.Focus
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaNacimiento.Text = ""
        End If
        
    End Sub

    Private Sub txtCalle_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCalle.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtCalle.Text) = "" Then : Exit Sub : End If

            txtNumero.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtCalle.Text = ""
        End If
        
    End Sub

    Private Sub txtNumero_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtNumero.Text) = "" Then : Exit Sub : End If

            txtDpto.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtNumero.Text = ""
        End If
        
    End Sub

    Private Sub txtDpto_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDpto.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtDpto.Text) = "" Then : Exit Sub : End If
            
            txtCodPostal.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtDpto.Text = ""
        End If
        
    End Sub

    Private Sub txtCodPostal_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPostal.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtCodPostal.Text) = "" Then : Exit Sub : End If

            txtLocalidad.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtCodPostal.Text = ""
        End If
        
    End Sub

    Private Sub txtLocalidad_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocalidad.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtLocalidad.Text) = "" Then : Exit Sub : End If

            txtAclaracion.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtLocalidad.Text = ""
        End If
        
    End Sub

    Private Sub txtAclaracion_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAclaracion.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtAclaracion.Text) = "" Then : Exit Sub : End If

            txtFechaIngreso.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtAclaracion.Text = ""
        End If
        
    End Sub

    Private Sub txtFechaIngreso_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaIngreso.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtFechaEgreso.Text) = "" Then : Exit Sub : End If

            txtFechaEgreso.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEgreso.Clear
        End If
        
    End Sub

    Private Sub txtFechaEgreso_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaEgreso.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtFechaEgreso.Text) = "" Then : Exit Sub : End If

            TabControl1.SelectTab(1)

            txtNombreCompletoConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaEgreso.Text = ""
        End If
        
    End Sub

    Private Sub txtNombreCompletoConyugue_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreCompletoConyugue.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtNombreCompletoConyugue.Text) = "" Then : Exit Sub : End If

            txtEdadConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtNombreCompletoConyugue.Text = ""
        End If
        
    End Sub

    Private Sub txtEdadConyugue_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdadConyugue.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtEdadConyugue.Text) = "" Then : Exit Sub : End If

            txtDniConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtEdadConyugue.Text = ""
        End If
        
    End Sub

    Private Sub txtDniConyugue_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDniConyugue.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtDniConyugue.Text) = "" Then : Exit Sub : End If

            txtFechaNacimientoConyugue.Focus

        ElseIf e.KeyData = Keys.Escape Then
            txtDniConyugue.Text = ""
        End If
        
    End Sub

    Private Sub txtFechaNacimientoConyugue_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaNacimientoConyugue.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtFechaNacimientoConyugue.Text) = "" Then : Exit Sub : End If

            ' Validamos la fecha introducida sólo en los casos en que haya colocado alguna.
            If Not txtFechaNacimientoConyugue.Text.estaVacia then
                If Helper._ValidarFecha(txtFechaNacimientoConyugue.Text) then
                    txtFechaCasamiento.Focus
                Else
                    Exit Sub
                End If
            Else
                txtFechaCasamiento.Focus
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaNacimientoConyugue.Clear
        End If
        
    End Sub

    Private Sub txtFechaCasamiento_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaCasamiento.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtFechaCasamiento.Text) = "" Then : Exit Sub : End If

            If Not txtFechaCasamiento.Text.estaVacia then

                If Helper._ValidarFecha(txtFechaCasamiento.Text) then

                    TabControl1.SelectTab(2)

                    With cmbEstado
                        .DroppedDown = True
                        .Focus
                    End With

                Else
                    Exit Sub
                End If
            Else
                
                TabControl1.SelectTab(2)

                With cmbEstado
                    .DroppedDown = True
                    .Focus
                End With

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtFechaCasamiento.Clear
        End If
        
    End Sub

    Private Sub cmbEstado_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEstado.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(cmbEstado.Text) = "" Then : Exit Sub : End If

            With cmbCategoria
                .DroppedDown=True
                .Focus
            End With

        ElseIf e.KeyData = Keys.Escape Then
            cmbEstado.SelectedIndex = 0
        End If
        
    End Sub

    Private Sub cmbEstado_TextChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles cmbEstado.TextChanged
        With cmbCategoria
            .DroppedDown=True
            .Focus
        End With
    End Sub

    Private Sub cmbCategoria_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCategoria.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(cmbEstado.Text) = "" Then : Exit Sub : End If
            
            txtSueldoBruto.Focus

        ElseIf e.KeyData = Keys.Escape Then
            cmbCategoria.SelectedIndex = 0
        End If
        
    End Sub

    Private Sub cmbCategoria_TextChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles cmbCategoria.TextChanged

        txtSueldoBruto.Focus

    End Sub

    'Private Sub txtLegajo_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLegajo.KeyDown
        
    '    If e.KeyData = Keys.Enter Then
	   '     If Trim(txtLegajo.Text) = "" Then : Exit Sub : End If



    '    ElseIf e.KeyData = Keys.Escape Then
    '        txtLegajo.Text = ""
    '    End If
        
    'End Sub

    Private Sub txtSueldoBruto_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSueldoBruto.KeyDown
        
        If e.KeyData = Keys.Enter Then
	        'If Trim(txtSueldoBruto.Text) = "" Then : Exit Sub : End If

            txtSueldoBruto.Text = Helper.formatonumerico(txtSueldoBruto.Text)

            With cmbUbicacion
                .DroppedDown=True
                .Focus
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtSueldoBruto.Text = ""
        End If
        
    End Sub

    Private Sub cmbUbicacion_KeyDown( ByVal sender As System.Object,  ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbUbicacion.KeyDown
        If e.KeyData = Keys.Enter Then
	        'If Trim(cmbEstado.Text) = "" Then : Exit Sub : End If

            TabControl1.SelectTab(3)

            dgvEducacion.Focus

        ElseIf e.KeyData = Keys.Escape Then
            cmbUbicacion.SelectedIndex = 0
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                txtDni.Focus
            Case 1
                txtNombreCompletoConyugue.Focus
            Case 2
                txtSueldoBruto.Focus
            Case 3
                dgvEducacion.Focus
        End Select
    End Sub
End Class