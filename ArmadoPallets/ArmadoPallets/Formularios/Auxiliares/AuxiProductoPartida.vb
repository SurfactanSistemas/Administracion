Imports System.Data.SqlClient
Imports ArmadoPallets.Clases

Public Class AuxiProductoPartida

    Private WProforma As String
    Private WTarget As Control
    Private WRowTarget(1, 1) As Integer

    Sub New(ByVal Proforma As String, ByVal target As Control, Optional ByVal _Terminado As String = "", Optional ByVal _Col As Integer = -1, Optional ByVal _Row As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        WProforma = proforma
        WTarget = target

        txtTerminado.Text = _Terminado

        WRowTarget(0, 0) = _Col
        WRowTarget(0, 1) = _Row

    End Sub

    Private Sub AuxiProductoPartida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CargarProductosTerminados()


        If txtTerminado.Text.Trim <> "" Then

            _CargarPartidas()

        End If

    End Sub

    Private Sub _CargarProductosTerminados()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Producto Terminado, DescriProducto Descripcion FROM ProformaExportacion WHERE Proforma = '" & WProforma & "' ORDER BY Renglon")
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

                Dim column As DataGridViewColumn = .Columns("Terminado")
                If Not IsNothing(column) Then column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                column = .Columns("Descripcion")
                If Not IsNothing(column) Then column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            End With

            TextBox1.Focus()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar los productos referidos al pedido '" & WProforma & "' la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
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

        If Not btnAtras.Visible Then

            txtTerminado.Text = ""
            If Not IsNothing(row) Then

                txtTerminado.Text = If(row.Cells("Terminado").Value, "")

            End If

            If txtTerminado.Text.Trim <> "" Then

                _CargarPartidas()

            End If

        Else

            txtPartida.Text = If(row.Cells("Hoja").Value, "")

            If txtPartida.Text.Trim Then
                Dim WWOwner As IngresoPallet = CType(Owner, IngresoPallet)
                If Not IsNothing(WWOwner) Then
                    WWOwner.AgregarTerminadoYPartida(txtTerminado.Text, txtPartida.Text, WRowTarget(0, 0), WRowTarget(0, 1))
                    Close()
                End If
            End If

        End If

    End Sub

    Private Sub _CargarPartidas()

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Producto FROM ProformaExportacion WHERE Proforma = '" & WProforma & "'")
        Dim tabla As New DataTable
        Dim WProductosProforma As New List(Of String)

        Try

            '"SELECT Producto As Terminado, T.Descripcion, Hoja FROM Hoja LEFT OUTER JOIN Terminado t ON t.Codigo = Hoja.Producto WHERE Producto = '" & txtTerminado.Text & "' AND Renglon = 1 ORDER BY Hoja DESC"

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            Using dr = cm.ExecuteReader
                If dr.HasRows Then

                    While dr.Read

                        WProductosProforma.Add(IIf(IsDBNull(dr.Item("Producto")), "", dr.Item("Producto")))

                    End While

                End If
            End Using

            cm.CommandText = "SELECT Producto As Terminado, Hoja, Cantidad as Teorico, 'Real' = CASE WHEN Real < RealAnt THEN RealAnt ELSE Real END, Saldo FROM Hoja LEFT OUTER JOIN Terminado t ON t.Codigo = Hoja.Producto WHERE Producto = '" & txtTerminado.Text & "' AND Renglon = 1 ORDER BY Hoja DESC"

            If WProductosProforma.Contains(txtTerminado.Text) Then

                For Each e As String In Conexion.Empresas

                    If cn.IsOpened Then cn.Close()

                    cn.ConnectionString = Helper._ConectarA(e)
                    cn.Open()
                    cm.Connection = cn

                    Using dr = cm.ExecuteReader
                        If dr.HasRows Then

                            tabla.Load(dr)

                        End If
                    End Using

                Next

            End If

            dgvAyuda.DataSource = tabla

            Dim c As DataGridViewColumn = dgvAyuda.Columns("Terminado")
            If Not IsNothing(c) Then c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            For Each _c As String In {"Hoja", "Saldo", "Teorico", "Real"}

                c = dgvAyuda.Columns(_c)
                If Not IsNothing(c) Then c.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            Next

            For Each _c As String In {"Hoja", "Saldo", "Teorico", "Real"}

                c = dgvAyuda.Columns(_c)
                If Not IsNothing(c) Then c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Next
            
            btnAtras.Visible = True

            If dgvAyuda.Rows.Count = 0 Then
                txtTerminado.Text = ""
                btnAtras_Click(Nothing, Nothing)
            End If

            TextBox1.Focus()

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        _CargarProductosTerminados()
        btnAtras.Visible = False
    End Sub
End Class
