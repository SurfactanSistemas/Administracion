Imports CrystalDecisions.CrystalReports.Engine
Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class InformeRep_SinFac_registradas

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        If ValidaFecha(txt_DesdeFecha.Text) <> "S" Then
            If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
                MsgBox("Las fechas son invalidas, Verificarlas")
                txt_DesdeFecha.Focus()
                Exit Sub
            End If
            MsgBox("Las fechas desde es invalda, Verificar")
            txt_DesdeFecha.Focus()
            Exit Sub
        End If

        If ValidaFecha(txt_HastaFecha.Text) <> "S" Then
            MsgBox("Las fechas hasta es invalda, Verificar")
            txt_HastaFecha.Focus()
            Exit Sub
        End If

        Dim WDesdeFec As String = ordenaFecha(txt_DesdeFecha.Text)
        Dim WHastaFec As String = ordenaFecha(txt_HastaFecha.Text)

        Dim TablaReporte As New DBAuxi.Reporte_InformeSinFac_RegistradasDataTable
  

        Dim VectorEmpresas(6) As String
        VectorEmpresas(0) = "SurfactanSa"
        VectorEmpresas(1) = "Surfactan_II"
        VectorEmpresas(2) = "Surfactan_III"
        VectorEmpresas(3) = "Surfactan_IV"
        VectorEmpresas(4) = "Surfactan_V"
        VectorEmpresas(5) = "Surfactan_VI"
        VectorEmpresas(6) = "Surfactan_VII"

        Dim SQLCnslt As String = ""
        For i = 0 To 6
            SQLCnslt = "SELECT i.Informe, i.Proveedor, i.Orden, i.Remito, i.Articulo , i.Cantidad, i.Fecha, i.FechaOrd, p.Nombre FROM Informe i INNER JOIN Proveedor p ON i.Proveedor = p.Proveedor WHERE i.FechaOrd >= '" & WDesdeFec & "' AND i.FechaOrd <= '" & WHastaFec & "' ORDER BY FechaOrd Desc"
            Dim TablaInforme As DataTable = GetAll(SQLCnslt, VectorEmpresas(i))
            If TablaInforme.Rows.Count > 0 Then
                For Each RowInforme As DataRow In TablaInforme.Rows

                    Dim Moneda As String = ""
                    SQLCnslt = "SELECT Tipo, Moneda, Precio FROM Orden WHERE Orden = '" & RowInforme.Item("Orden") & "'"
                    Dim RowOrden As DataRow = GetSingle(SQLCnslt, VectorEmpresas(i))
                    If RowOrden IsNot Nothing Then
                        If RowOrden.Item("Tipo") = 1 Then
                            Continue For
                        End If

                        Select Case RowOrden.Item("Moneda")
                            Case 0
                                Moneda = "Dolares"
                            Case 1
                                Moneda = "Pesos"
                            Case 2
                                Moneda = "Euros"
                        End Select

                    End If



                    SQLCnslt = "SELECT NroInterno FROM IvaComp WHERE Tipo = '01' AND Proveedor = '" & RowInforme.Item("Proveedor") & "' AND Remito LIKE '%" & RowInforme.Item("Remito") & "%'"
                    Dim RowIvaComp As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
                    If RowIvaComp Is Nothing Then
                        With RowInforme
                            TablaReporte.Rows.Add(.Item("Informe"),
                                                  .Item("Proveedor"),
                                                  .Item("Nombre"),
                                                  .Item("Orden"),
                                                  .Item("Articulo"),
                                                  "",
                                                  .Item("Cantidad"),
                                                  Moneda,
                                                  RowOrden.Item("Precio"),
                                                  .Item("Remito"),
                                                  .Item("Fecha"),
                                                  .Item("FechaOrd"))
                        End With
                    End If
                Next

            End If
        Next

        For Each row As DataRow In TablaReporte.Rows
            SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & row.Item("Articulo") & "'"
            Dim rowArticulo As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If rowArticulo IsNot Nothing Then
                row.Item("Descripcion") = rowArticulo.Item("Descripcion")
            End If
        Next

        Dim Wformula As String = ""

        If rabtn_Dolares.Checked Then
            Wformula = "{Reporte_InformeSinFac_Registradas.Moneda} = 'Dolares'"
        ElseIf rabtn_Pesos.Checked Then
            Wformula = "{Reporte_InformeSinFac_Registradas.Moneda} = 'Pesos'"
        End If

        Dim WTitulo As String = "Desde " & txt_DesdeFecha.Text & " Hasta " & txt_HastaFecha.Text & ""

        With New VistaPrevia
            .Reporte = New Reporte_InformeSinFacturasRegistradas()
            .Reporte.SetDataSource(CType(TablaReporte, DataTable))
            .Reporte.SetParameterValue(0, WTitulo)
            .Formula = Wformula
            .Mostrar()
        End With

    End Sub

    Private Sub txt_DesdeFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_DesdeFecha.Text) = "S" Then
                    txt_HastaFecha.Focus()
                Else
                    MsgBox("La fecha es invalida, verificar")
                    txt_DesdeFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_DesdeFecha.Text = ""
        End Select
    End Sub

    Private Sub txt_HastaFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaFecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_HastaFecha.Text) = "S" Then
                    btn_Aceptar_Click(Nothing, Nothing)
                Else
                    MsgBox("La fecha es invalida, verificar")
                    txt_HastaFecha.SelectAll()
                End If
            Case Keys.Escape
                txt_HastaFecha.Text = ""
        End Select
    End Sub
End Class