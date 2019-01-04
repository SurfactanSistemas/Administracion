Public Class Login

    Private WEmpresasAcceso As DataTable

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WEmpresasAcceso = New DataTable()
        With WEmpresasAcceso
            .Columns.Add("Nombre")
            .Columns.Add("BaseDatos")

            With .Rows
                .Add("SURFACTAN I.", "SurfactanSa")
                .Add("SURFACTAN II", "Surfactan_II")
                .Add("SURFACTAN III", "Surfactan_III")
                .Add("SURFACTAN IV", "Surfactan_IV")
                .Add("SURFACTAN V", "Surfactan_V")
                .Add("SURFACTAN VI", "Surfactan_VI")
                .Add("SURFACTAN VII", "Surfactan_VII")
                .Add("PELLITAL I", "PellitalSa")
                .Add("PELLITAL II", "Pelitall_II") ' Está asi en la Base de Datos.
                .Add("PELLITAL III", "Pellital_III")
                .Add("PELLITAL V", "Pellital_V")
            End With

        End With

        With cmbEmpresas
            .DataSource = WEmpresasAcceso
            .DisplayMember = "Nombre"
            .ValueMember = "BaseDatos"
            .SelectedIndex = 0
        End With

        txtClave.Text = ""

    End Sub

    Private Sub Login_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtClave.Focus()
    End Sub

    Private Sub btnIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
        Try

            If txtClave.Text.Trim = "" Then Throw New Exception("Debe indicar una Clave de Acceso al Sistema.")
            If cmbEmpresas.SelectedIndex < 0 Then cmbEmpresas.SelectedIndex = 0

            Dim WBaseDatos As String = CType(cmbEmpresas.SelectedItem, DataRowView).Item("BaseDatos")

            Dim WOperador As DataRow = GetSingle("SELECT Operador, Descripcion FROM Operador WHERE UPPER(Clave) = '" & txtClave.Text & "'", WBaseDatos)

            If IsNothing(WOperador) Then Throw New Exception("Clave Errónea")

            With WOperador
                Operador.Base = WBaseDatos
                Operador.Codigo = OrDefault(.Item("Operador"), 0)
                Operador.Clave = txtClave.Text.Trim
                Operador.Descripcion = OrDefault(.Item("Descripcion"), "")
            End With

            Dim frm As New MenuPrincipal

            frm.Show()

            Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            With txtClave
                .Focus()
                .SelectionStart = 0
                .SelectionLength = .Text.Length
            End With

        End Try
    End Sub
End Class