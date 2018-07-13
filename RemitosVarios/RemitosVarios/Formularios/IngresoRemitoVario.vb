Imports System.Data.SqlClient
Imports System.Globalization
Imports SistemaSurfactan1.Clases

Public Class IngresoRemitoVario

    Private Sub IngresoOrdenTrabajo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        _LimpiarCampos()
        txtCliente.Focus()
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub

    Private Sub _LimpiarCampos()

        For Each _txt As TextBox In Panel3.Controls.OfType(Of TextBox)().Union(GroupBox1.Controls.OfType(Of TextBox)())
            _txt.Text = ""
        Next

        For Each _m As MaskedTextBox In Panel3.Controls.OfType(Of MaskedTextBox)().Union(GroupBox1.Controls.OfType(Of MaskedTextBox)())
            _m.Clear()
        Next

        For Each _c As ComboBox In Panel3.Controls.OfType(Of ComboBox)().Union(GroupBox1.Controls.OfType(Of ComboBox)())
            If _c.Items.Count > 0 Then _c.SelectedIndex = 0
        Next

        ckBloquear.Checked = False

    End Sub

    Private Sub IngresoOrdenTrabajo_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCliente.Focus()
    End Sub

    Private Sub txtRemito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemito.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtRemito.Text) <> "" Then
                _TraerDatosRemito()
            End If

            txtFecha.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtRemito.Text = ""
        End If

    End Sub

    Private Sub _TraerDatosRemito()

        Dim WRemito = txtRemito.Text

        btnLimpiar.PerformClick()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM RemitosVarios WHERE Remito = '" & WRemito & "' AND Punto = '" & Conexion.WPunto & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                dr.Read()

                txtCliente.Text = IIf(IsDBNull(dr.Item("Cliente")), "", dr.Item("Cliente"))
                txtRemito.Text = IIf(IsDBNull(dr.Item("Remito")), "", dr.Item("Remito"))
                txtFecha.Text = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))
                txtDesCliente.Text = IIf(IsDBNull(dr.Item("Razon")), "", dr.Item("Razon"))
                txtLocalidad.Text = IIf(IsDBNull(dr.Item("Localidad")), "", dr.Item("Localidad"))
                txtDireccion.Text = IIf(IsDBNull(dr.Item("Direccion")), "", dr.Item("Direccion"))
                txtDireccionEntrega.Text = IIf(IsDBNull(dr.Item("DirEntrega")), "", dr.Item("DirEntrega"))
                txtCuit.Text = IIf(IsDBNull(dr.Item("Cuit")), "", dr.Item("Cuit"))
                txtObservaciones.Text = IIf(IsDBNull(dr.Item("Observaciones")), "", dr.Item("Observaciones"))

                For Each txt As TextBox In {txtRemito, txtDesCliente, txtLocalidad, txtDireccion, txtDireccionEntrega, txtObservaciones}
                    txt.Text = txt.Text.Trim()
                Next

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar el Remito desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        txtRemito.Text = WRemito

    End Sub

    Private Sub txtFecha_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtFecha.Text.Replace("/", "")) = "" Then : Exit Sub : End If

            If Not Helper._ValidarFecha(txtFecha.Text) Then
                MsgBox("La fecha debe ser una fecha válida")
            End If

            Dim WFecha As New DateTime

            Date.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, WFecha)

            If (WFecha.DayOfWeek = DayOfWeek.Sunday Or WFecha.DayOfWeek = DayOfWeek.Saturday) Then
                MsgBox("La fecha indicada cae durante un Fin de Semana.")
            End If

            txtCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFecha.Text = ""
        End If

    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCliente.Text) <> "" Then

                Dim WCliente As DataRow = _TraerDatosCliente(txtCliente.Text)

                ckBloquear.Checked = False

                If Not IsNothing(WCliente) Then

                    txtDesCliente.Text = WCliente.Item("Razon")
                    txtDireccion.Text = WCliente.Item("Direccion")
                    txtLocalidad.Text = WCliente.Item("Localidad")
                    txtCuit.Text = WCliente.Item("Cuit")

                    ckBloquear.Checked = True

                    txtDireccionEntrega.Focus()

                    btnDireccionesEntrega.PerformClick()
                End If

                For Each txt As TextBox In {txtDesCliente, txtDireccion, txtLocalidad}
                    txt.Text = txt.Text.Trim()
                Next

                Exit Sub
            End If

            txtDesCliente.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCliente.Text = ""
        End If

    End Sub

    Private Function _TraerDatosCliente(ByVal WCliente As String) As DataRow

        Dim tabla As New DataTable

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Cliente, ISNULL(Razon, '') Razon, ISNULL(Direccion, '') Direccion, ISNULL(Localidad, '') Localidad, ISNULL(Cuit, '') Cuit, ISNULL(DirEntrega, '') DirEntrega, ISNULL(DirEntregaII, '') DirEntregaII, ISNULL(DirEntregaIII, '') DirEntregaIII, ISNULL(DirEntregaIV, '') DirEntregaIV, ISNULL(DirEntregaV, '') DirEntregaV FROM Cliente WHERE Cliente = '" & WCliente & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                tabla.Load(dr)

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los datos del Cliente desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

        If tabla.Rows.Count > 0 Then
            Return tabla.Rows(0)
        Else
            Return Nothing
        End If

    End Function

    Private Sub txtDesCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesCliente.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesCliente.Text) = "" Then : Exit Sub : End If

            txtDireccion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesCliente.Text = ""
        End If

    End Sub

    Private Sub txtDireccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDireccion.Text) = "" Then : Exit Sub : End If

            txtLocalidad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDireccion.Text = ""
        End If

    End Sub

    Private Sub txtLocalidad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocalidad.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtLocalidad.Text) = "" Then : Exit Sub : End If

            txtCuit.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtLocalidad.Text = ""
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Not _DatosValidos() Then Return

        Dim WPunto = Conexion.WPunto
        Dim WRemito = txtRemito.Text
        Dim WCliente = txtCliente.Text
        Dim WRazon = txtDesCliente.Text
        Dim WObservaciones = txtObservaciones.Text
        Dim WLocalidad = txtLocalidad.Text
        Dim WDireccion = txtDireccion.Text
        Dim WDireccionEntrega = txtDireccionEntrega.Text
        Dim WCuit = txtCuit.Text
        Dim WFecha = txtFecha.Text
        Dim WFechaOrd = Helper.ordenaFecha(WFecha)
        Dim WCai = "", WFechaCai = ""
        Dim WActualizar = True

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            cm.CommandText = "SELECT Remito, Cai, FechaCai FROM RemitosVarios WHERE Remito = '" & WRemito & "'"
            dr = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                WCai = IIf(IsDBNull(dr.Item("Cai")), "", dr.Item("Cai"))
                WFechaCai = IIf(IsDBNull(dr.Item("FechaCai")), "", dr.Item("FechaCai"))

                WActualizar = False
            Else
                WRemito = "0"
                WCai = ""
                WFechaCai = ""
                txtRemito.Text = "0"
            End If

            If Not dr.IsClosed Then dr.Close()

            If Val(WRemito) = 0 Then

                cm.CommandText = "SELECT Ultimo, Fecha, Cai FROM NumeroRemito WHERE Punto = '" & Conexion.WPunto & "'"
                dr = cm.ExecuteReader

                If dr.HasRows Then
                    dr.Read()

                    WRemito = IIf(IsDBNull(dr.Item("Ultimo")), "0", dr.Item("Ultimo"))
                    WCai = IIf(IsDBNull(dr.Item("Cai")), "", dr.Item("Cai"))
                    WFechaCai = IIf(IsDBNull(dr.Item("Fecha")), "", dr.Item("Fecha"))

                    WRemito = Val(WRemito) + 1

                    txtRemito.Text = WRemito

                End If

            End If

            If Not dr.IsClosed Then dr.Close()

            cm.CommandText = "DELETE FROM RemitosVarios WHERE Remito = '" & WRemito & "'"
            cm.ExecuteNonQuery()

            cm.CommandText = String.Format("INSERT INTO RemitosVarios (Remito, Cliente, Razon, Direccion, Localidad, DirEntrega, Fecha, FechaOrd, Observaciones, Punto, Cuit, Cai, FechaCai) " _
                                         & " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", _
                                         WRemito, WCliente, WRazon, WDireccion, WLocalidad, WDireccionEntrega, WFecha, WFechaOrd, WObservaciones, WPunto, WCuit, WCai, WFechaCai)

            cm.ExecuteNonQuery()

            If WActualizar Then
                cm.CommandText = "UPDATE NumeroRemito SET Ultimo = '" + WRemito + "' WHERE Punto = '" & WPunto & "'"
                cm.ExecuteNonQuery()
            End If

            trans.Commit()

            MsgBox("Remito grabado con Nº " & WRemito, MsgBoxStyle.Information)

            If MsgBox("¿Desea imprimir el remito?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim frm As VistaPrevia = New VistaPrevia()

                frm.Reporte = New ImpRemito2()
                frm.Formula = "{RemitosVarios.Remito}='" & WRemito & "'"

                'frm.Mostrar()
                frm.Imprimir()
            End If

            btnLimpiar.PerformClick()

        Catch ex As Exception
            If Not IsNothing(dr) AndAlso Not dr.IsClosed Then dr.Close()
            If Not IsNothing(trans) And Not IsNothing(trans.Connection) Then trans.Rollback()

            MsgBox("Hubo un problema al querer guardar el Remito Vario en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message, MsgBoxStyle.Exclamation)

        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _DatosValidos() As Boolean

        If Panel3.Controls.OfType(Of TextBox)().Any(Function(st) (st.Text.Trim() = "" And st.Name <> "txtRemito")) Then
            Return False
        End If

        If Panel3.Controls.OfType(Of MaskedTextBox)().Any(Function(st) (st.Text.Trim().Replace("/", "") = "")) Then
            Return False
        End If

        If GroupBox1.Controls.OfType(Of TextBox)().Any(Function(st) st.Text.Trim() = "") Then
            Return False
        End If

        If GroupBox1.Controls.OfType(Of MaskedTextBox)().Any(Function(st) (st.Text.Trim().Replace("/", "") = "" And st.Name <> "txtCliente")) Then
            Return False
        End If

        Return True
    End Function

    Private Sub txtCuit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCuit.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtCuit.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            'If txtCuit.Text.Replace(" ", "").Length = 0 Then : Exit Sub : End If

            txtDireccionEntrega.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCuit.Text = ""
        End If

    End Sub

    Private Sub txtDireccionEntrega_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccionEntrega.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDireccionEntrega.Text) = "" Then : Exit Sub : End If

            txtObservaciones.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDireccionEntrega.Text = ""
        End If

    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        Label12.Text = String.Format("{1} de {0} Caracteres Disponibles.", txtObservaciones.MaxLength, (txtObservaciones.MaxLength - txtObservaciones.Text.Length))
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        txtCliente.Text = txtCliente.Text.ToUpper
    End Sub

    Private Sub btnDireccionesEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDireccionesEntrega.Click
        If txtCliente.Text.Trim <> "" Then
            Dim frm = New DireccionesCliente(txtCliente.Text)
            frm.Show(Me)
        End If
    End Sub

    Public Sub AsignarDireccion(ByVal wDireccion As Object)
        txtDireccionEntrega.Text = wDireccion
        txtObservaciones.Focus()
    End Sub

    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click
        Dim frm = New AyudaClientes()
        frm.Show(Me)
    End Sub

    Public Sub AsignarCliente(ByVal wCliente As Object)
        txtCliente.Text = wCliente
        txtCliente_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtCliente_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnConsultas.PerformClick()
    End Sub

    Private Sub ckBloquear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckBloquear.CheckedChanged
        For Each c As Control In {txtCuit, txtDesCliente, txtDireccion, txtDireccionEntrega, txtLocalidad}
            c.Enabled = Not c.Enabled
        Next
    End Sub
End Class