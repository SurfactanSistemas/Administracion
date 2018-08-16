Imports System.Data.SqlClient

Public Class DiferenciaInventarioMP

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim ds As New DSDiferenciaInventario
        Dim WDatos As sqldataadapter = _TraerDatos()
        WDatos.Fill(ds, "Detalles")

        Dim rpt As New ReporteDiferenciaInventarioMP
        rpt.SetDataSource(ds)

        Dim frm As New VistaPrevia
        frm.Reporte = rpt

        frm.Formula = "{Detalles.Articulo} IN '" & txtDesde.Text & "' TO '" & txtHasta.Text & "'"
        frm.Refresh()

        If rbImpresora.Checked Then
            frm.Imprimir()
        Else
            frm.Mostrar()
        End If

    End Sub

    Private Function _TraerDatos() As SqlDataAdapter

        Dim WEmpresa As String = IIf(Helper._EsPellital, "PELLITAL S.A.", "SURFACTAN S.A.")
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("select a.Codigo as Articulo, a.Descripcion, Stock = (a.Entradas - a.Salidas), Inventario = ISNULL(SUM(i.Cantidad), 0), Empresa = '" & WEmpresa & "' from Articulo a LEFT OUTER JOIN Inventario i ON i.Articulo = a.Codigo GROUP BY a.Codigo, a.Descripcion, a.Entradas, a.Salidas order by a.Codigo")

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

    Private Sub DiferenciaInventarioMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Text = "AA-000-000"
        txtHasta.Text = "ZZ-999-999"
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtDesde.Text.Replace("-", "")) = "" Then : Exit Sub : End If
            If txtDesde.Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

            txtDesde.Text = txtDesde.Text.ToUpper

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        With txtHasta
            If e.KeyData = Keys.Enter Then
                If Trim(.Text.Replace("-", "")) = "" Then : Exit Sub : End If
                If .Text.Replace(" ", "").Length < 10 Then : Exit Sub : End If

                .Text = .Text.ToUpper

            ElseIf e.KeyData = Keys.Escape Then
                .Text = ""
            End If
        End With
    End Sub

    Private Sub DiferenciaInventarioMP_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub
End Class