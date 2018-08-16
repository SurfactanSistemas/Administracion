Imports System.Data.SqlClient

Public Class DiferenciaInventarioPT

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim ds As New DSDiferenciaInventario
        Dim WDatos As sqldataadapter = _TraerDatos()
        WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioPT
        rpt.SetDataSource(ds)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt
        frm.Formula = "{Detalles.Terminado} IN '" & txtDesde.Text & "' TO '" & txtHasta.Text & "'"

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Mostrar()
        End If

    End Sub

    Private Function _TraerDatos() As SqlDataAdapter

        Dim WEmpresa As String = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A.")
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("select a.Codigo as Terminado, a.Descripcion, Stock = (a.Entradas - a.Salidas), Inventario = ISNULL(SUM(i.Cantidad), 0), Empresa = '" & WEmpresa & "' from Terminado a LEFT OUTER JOIN Inventario i ON i.Terminado = a.Codigo GROUP BY a.Codigo, a.Descripcion, a.Entradas, a.Salidas HAVING LEFT(UPPER(a.Codigo), 2) IN ('PT', 'SE', 'RE', 'NK', 'YQ') AND NOT ((a.Entradas - a.Salidas) = 0 AND ISNULL(SUM(i.Cantidad), 0) = 0) order by a.Codigo")

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            Dim dr As New SqlDataAdapter(cm)

            Return dr

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            'dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Sub LimpiarIngresoInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Text = "AA-00000-000"
        txtHasta.Text = "ZZ-99999-999"
    End Sub

    Private Sub DiferenciaInventarioPT_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 12 Then : Exit Sub : End If

            txtDesde.Text = txtDesde.Text.ToUpper

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then

            If Trim(txtHasta.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtHasta.Text.Replace(" ", "").Length < 12 Then : Exit Sub : End If

            txtHasta.Text = txtHasta.Text.ToUpper

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub
End Class