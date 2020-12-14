Imports Util

Public Class ListaEnsayos : Implements IActualizarPorNuevoIngreso, IListarReporteDesdeHastaBasico

    Dim WBase As String = "Surfactan_II"
    Dim PermisoGrabar As Boolean

    Sub New(Optional ByVal ID As String = "00")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim SQLCnslt As String = "SELECT Escritura FROM PermisosPerfiles WHERE ID = '" & ID & "' AND Sistema = 'LABORATORIO' AND Perfil = '" & Operador.Perfil & "' ORDER BY ID"
        Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If Row IsNot Nothing Then
            PermisoGrabar = Row.Item("Escritura")
        End If

    End Sub

    Private Sub ListaEnsayos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _LeerDatos()
        If PermisoGrabar = False Then
            Button1.Enabled = False
        End If
    End Sub

    


    Private Sub _LeerDatos()

        If Helper._EsPellital Then WBase = "Pelitall_II"

        Dim WEnsayos As DataTable = GetAll("SELECT Codigo, LTRIM(Descripcion) Descripcion FROM Ensayos Order By Codigo", WBase)

        dgvEnsayos.DataSource = WEnsayos

        txtFiltrar.Text = ""

    End Sub

    Private Sub txtFiltrar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp
        Dim tabla As DataTable = TryCast(dgvEnsayos.DataSource, DataTable)

        If tabla IsNot Nothing Then tabla.DefaultView.RowFilter = String.Format("CONVERT(Codigo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With New IngresoEnsayos
            .Show(Me)
        End With
    End Sub

    Private Sub dgvEnsayos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEnsayos.CellMouseDoubleClick
        Dim WCodigo As Short = OrDefault(dgvEnsayos.CurrentRow.Cells("Codigo").Value, 0)

        If WCodigo > 0 Then
            With New IngresoEnsayos(WCodigo, PermisoGrabar)
                .Show(Me)
            End With
        End If

    End Sub

    Public Sub _ProcesarActualizarPorNuevoIngreso() Implements IActualizarPorNuevoIngreso._ProcesarActualizarPorNuevoIngreso
        _LeerDatos()

        txtFiltrar.Focus()

    End Sub

    Private Sub ListaEnsayos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFiltrar.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtCodigo.Text) = "" Then : Exit Sub : End If

            Dim WEnsayo As DataRow = GetSingle("SELECT Codigo FROM Ensayos WHERE Codigo = '" & txtCodigo.Text & "'", WBase)

            If WEnsayo IsNot Nothing Then
                With New IngresoEnsayos(txtCodigo.Text, PermisoGrabar)
                    .ShowDialog(Me)
                End With

                txtCodigo.Text = ""
                txtFiltrar.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With New ListarReporteDesdeHastaBasico("Listar Ensayos")
            AddHandler .WOnKeyDown, AddressOf _OnKeyDownEnsayos
            .Show(Me)
        End With
    End Sub

    Private Sub _OnKeyDownEnsayos(ByVal sender As Object, ByVal e As ListadoReporteEventArgs)

        Dim WControl As TextBox = TryCast(sender, TextBox)
        Dim WEns As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WControl.Text.Trim & "'", WBase)

        If WEns IsNot Nothing Then e.Control.Text = Trim(OrDefault(WEns.Item("Descripcion"), ""))

    End Sub

    Public Sub _ProcesarListarReporteDesdeHastaBasico(ByVal Desde As String, ByVal Hasta As String, ByVal TipoVisualizacion As Util.Clases.Enumeraciones.TipoVisualizacionReporte) Implements IListarReporteDesdeHastaBasico._ProcesarListarReporteDesdeHastaBasico
        With New VistaPrevia
            .Reporte = New ReporteListadoEnsayos
            .Formula = "{Ensayos.Codigo} IN " & Desde & " TO " & Hasta & ""
            .Base = IIf(_EsPellital, "Pelitall_II", "Surfactan_II")

            If TipoVisualizacion = Util.Clases.Enumeraciones.TipoVisualizacionReporte.Pantalla Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With
    End Sub
End Class