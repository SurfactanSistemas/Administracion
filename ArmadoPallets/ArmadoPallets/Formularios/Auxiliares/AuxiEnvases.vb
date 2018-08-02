Imports System.Data.SqlClient

Public Class AuxiEnvases

    Private WProforma As String
    Private WTarget As Control
    Private WRowTarget(1, 1) As Integer

    Sub New(ByVal Proforma As String, ByRef target As Control)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WProforma = Proforma
        WTarget = target

    End Sub

    Private Sub AuxiProductoPartida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarEnvases()
    End Sub

    Private Sub _CargarEnvases()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo, Descripcion FROM Articulo WHERE Codigo LIKE 'ZE-%' ORDER BY Codigo")
        Dim dr As SqlDataReader
        Dim tabla As New DataTable

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            If dr.HasRows Then
                tabla.Load(dr)
            End If

            With dgvAyuda

                .DataSource = tabla
                .ReadOnly = True
                .ShowCellToolTips = False

                Dim column As DataGridViewColumn = .Columns("Codigo")
                If Not IsNothing(column) Then column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                column = .Columns("Descripcion")
                If Not IsNothing(column) Then column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            End With

            TextBox1.Focus()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los Envases desde la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp, txtPartida.KeyUp

        Dim WFiltro = ""

        ' Armamos el filtro segun las columnas mostradas.
        For Each c As DataGridViewColumn In dgvAyuda.Columns
            If WFiltro.Trim <> "" Then
                WFiltro &= " OR Convert(" & c.Name & ", System.String) LIKE '%" & TextBox1.Text & "%'"
            Else
                WFiltro &= "Convert(" & c.Name & ", System.String) LIKE '%" & TextBox1.Text & "%'"
            End If
        Next

        Dim t As DataTable = CType(dgvAyuda.DataSource, DataTable)
        If Not IsNothing(t) Then t.DefaultView.RowFilter = WFiltro

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, txtPartida.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub dgvAyuda_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAyuda.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvAyuda.CurrentRow

        txtTerminado.Text = If(row.Cells("Codigo").Value, "")

        If txtTerminado.Text.Trim <> "" Then
            Dim WWOwner As IngresoPallet = CType(Owner, IngresoPallet)
            If Not IsNothing(WWOwner) Then
                WWOwner.AgregarEnvase(WTarget, txtTerminado.Text)
                Close()
            End If
        End If

    End Sub
End Class
