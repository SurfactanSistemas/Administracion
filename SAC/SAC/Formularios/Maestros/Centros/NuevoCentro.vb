Public Class NuevoCentro : Implements IAyudaReponsableSac

    Sub New(Optional ByVal WCodigo As Object = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtCodigo.Text = WCodigo

        If txtCodigo.Text.Trim = "" Then
            txtCodigo.Text = _ProximoNumero()
        End If

        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

    End Sub

    Private Function _ProximoNumero() As String
        Dim WUltimo As DataRow = Query.GetSingle("SELECT ISNULL(Max(Codigo), 0) Ultimo FROM CentroSac")

        Return WUltimo.Item("Ultimo") + 1
    End Function

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If
            Dim c = txtCodigo.Text

            btnLimpiar.PerformClick()

            txtCodigo.Text = c

            Dim WTipoSolic As DataRow = GetSingle("SELECT cs.Codigo, LTRIM(RTRIM(cs.Descripcion)) Descripcion, ISNULL(cs.Responsable, 0) Responsable, LTRIM(RTRIM(rs.Descripcion)) DescResponsable FROM CentroSac cs LEFT OUTER JOIN ResponsableSac rs ON rs.Codigo = cs.Responsable WHERE cs.Codigo = '" & txtCodigo.Text & "'")

            If Not IsNothing(WTipoSolic) Then
                txtCodigo.Text = WTipoSolic.Item("Codigo")
                txtDescripcion.Text = WTipoSolic.Item("Descripcion")
                txtResponsable.Text = WTipoSolic.Item("Responsable")

                txtReponsable_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            End If

            txtDescripcion.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = _ProximoNumero()
        txtDescripcion.Text = ""
        txtResponsable.Text = ""
        lblDescResponsable.Text = ""
        txtCodigo.Focus()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            If {txtDescripcion, txtCodigo, txtResponsable}.Any(Function(txt) txt.Text.Trim = "") Then
                Throw New Exception("Los campos 'Descripcion', 'Codigo', y 'Responsable' son obligatorios y no pueden estar vacíos.")
            End If

            txtDescripcion.Text = Microsoft.VisualBasic.Left(txtDescripcion.Text, 50)

            Dim WResponsable As DataRow = GetSingle("SELECT Codigo FROM ResponsableSac WHERE Codigo ='" & txtResponsable.Text & "'")

            If IsNothing(WResponsable) Then Throw New Exception("El responsable indicado es inexistente")

            Query.ExecuteNonQueries("DELETE FROM CentroSac WHERE Codigo = '" & txtCodigo.Text & "'", "INSERT INTO CentroSac (Codigo, Descripcion, Responsable) VALUES (" & txtCodigo.Text & ", '" & txtDescripcion.Text & "', '" & txtResponsable.Text & "')")

            Dim WOwner As INuevoCentro = CType(Owner, INuevoCentro)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoCentro(txtCodigo.Text)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("¿Está seguro de querer eliminar este Centro Sac?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

            Query.ExecuteNonQueries("DELETE FROM CentroSac WHERE Codigo = '" & txtCodigo.Text & "'")

            Dim WOwner As INuevoCentro = CType(Owner, INuevoCentro)

            If Not IsNothing(WOwner) Then
                WOwner._ProcesarNuevoCentro(txtCodigo.Text)
            End If

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress, txtResponsable.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDescripcion.Text) = "" Then : Exit Sub : End If

            txtResponsable.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDescripcion.Text = ""
        End If

    End Sub

    Private Sub txtReponsable_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsable.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtResponsable.Text.Trim = "" Then
                btnConsultaResp.PerformClick()
            End If

            Dim WResponsable As DataRow = Query.GetSingle("SELECT Codigo, LTRIM(RTRIM(Descripcion)) Descripcion FROM ResponsableSac WHERE Codigo = '" & txtResponsable.Text & "'")

            lblDescResponsable.Text = ""

            If Not IsNothing(WResponsable) Then
                txtResponsable.Text = WResponsable.Item("Codigo")
                lblDescResponsable.Text = WResponsable.Item("Descripcion")
                txtDescripcion.Focus()
            Else
                txtResponsable.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtResponsable.Text = ""
        End If

    End Sub

    Private Sub NuevoResponsableSAC_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDescripcion.Focus()
    End Sub

    Private Sub txtResponsable_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtResponsable.MouseDoubleClick
        btnConsultaResp.PerformClick()
    End Sub

    Private Sub NuevoCentro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub _ProcesarAyudaResponsableSac(ByVal WCodigo As String) Implements IAyudaReponsableSac._ProcesarAyudaResponsableSac
        txtResponsable.Text = WCodigo
        txtReponsable_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub btnConsultaResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaResp.Click
        Dim frm As New AyudaResponsablesSac
        frm.ShowDialog(Me)
    End Sub
End Class