Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Listado_Mercaderia_Remitos_FactuArticulo : Implements IConsulta_Terminado

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With Consulta_Terminado
            .Show(Me)
        End With
    End Sub

    Public Sub PasaCodigo(Codigo As String, Accion As String) Implements IConsulta_Terminado.PasaCodigo
        If Accion = "Ambos" Then
            txt_DesdeCodigo.Text = Codigo
            txt_HastaCodigo.Text = Codigo
        End If

        If Accion = "Desde" Then
            txt_DesdeCodigo.Text = Codigo
        End If

        If Accion = "Hasta" Then
            txt_HastaCodigo.Text = Codigo
        End If
    End Sub

  
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


        Dim TablaReporteMercad_FacturasXCliente As DataTable = New DBAuxi.TablaReporteMercad_FacturasXClienteDataTable()

        
        txt_DesdeCodigo.Text = UCase(txt_DesdeCodigo.Text)
        txt_HastaCodigo.Text = UCase(txt_HastaCodigo.Text)

        Dim SQLCnslt As String = "SELECT *" _
                & " FROM Estadistica" _
                & " WHERE Tipo = '" & "1" & "'" _
                & " AND Numero >= '" & "900000" & "'" _
                & " AND Numero <= '" & "999999" & "'" _
                & " AND Articulo >= '" & txt_DesdeCodigo.Text & "'" _
                & " AND Articulo <= '" & txt_HastaCodigo.Text & "'"

        Dim tablaEsta As DataTable = GetAll(SQLCnslt, Operador.Base)
      


        Dim Fila As Integer = 0
        If tablaEsta.Rows.Count > 0 Then


            For Each RowEstad As DataRow In tablaEsta.Rows



                Dim WCliente As String = RowEstad.Item("Cliente")
                Dim WCantidad As String = RowEstad.Item("Cantidad")
                Dim WFecha As String = RowEstad.Item("Fecha")
                Dim WNumero As String = RowEstad.Item("Numero")
                Dim WTerminado As String = RowEstad.Item("Articulo")

                TablaReporteMercad_FacturasXCliente.Rows.Add()
                With TablaReporteMercad_FacturasXCliente.Rows(Fila)


                    .Item("Cliente") = WCliente
                    .Item("Fecha") = WFecha
                    .Item("FechaOrd") = ordenaFecha(WFecha)
                    .Item("Numero") = WNumero
                    .Item("Entrada") = WCantidad
                    .Item("Salida") = 0
                    .Item("Lista1") = "Remito"
                    .Item("Terminado") = WTerminado
                    .Item("Saldo") = .Item("Entrada") + .Item("Salida")


                End With
                Fila += 1
            Next
        End If



       

        For Each RowReporte As DataRow In TablaReporteMercad_FacturasXCliente.Rows
            Dim WCliente As String = RowReporte.Item("Cliente")
            Dim WTerminado As String = RowReporte.Item("Terminado")
            Dim WDescripcion As String = ""
            Dim WDescriTer As String = ""

            SQLCnslt = "SELECT Razon FROM Cliente WHERE Cliente = '" & WCliente & "'"

            Dim RowCliente As DataRow = GetSingle(SQLCnslt, Operador.Base)

            If RowCliente IsNot Nothing Then
                WDescripcion = RowCliente.Item("Razon")
            End If



            If Microsoft.VisualBasic.Left(WTerminado, 2) = "DY" Then



                Dim CodArt As String = Microsoft.VisualBasic.Left(WTerminado, 3) & Microsoft.VisualBasic.Right(WTerminado, 7)
                SQLCnslt = "SELECT Descripcion FROM Articulo WHERE Codigo = '" & CodArt & "'"

                Dim RowTerminado As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If RowTerminado IsNot Nothing Then
                    WDescriTer = IIf(IsDBNull(RowTerminado.Item("Descripcion")), "", RowTerminado.Item("Descripcion"))
                End If

            Else
                SQLCnslt = "SELECT Descripcion FROM Terminado WHERE Codigo = '" & WTerminado & "'"

                Dim RowTerminado As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If RowTerminado IsNot Nothing Then
                    WDescriTer = IIf(IsDBNull(RowTerminado.Item("Descripcion")), "", RowTerminado.Item("Descripcion"))
                End If

            End If



            RowReporte.Item("Descripcion") = WDescripcion
            RowReporte.Item("Descriter") = WDescriTer


        Next


        Dim WFormula As String = "{TablaReporteMercad_FacturasXCliente.Terminado} >= '" & txt_DesdeCodigo.Text & "' " _
                                       & "AND {TablaReporteMercad_FacturasXCliente.Terminado} <= '" & txt_HastaCodigo.Text & "'"

        With New VistaPrevia
            .Reporte = New Reporte_Mercad_FacturasXArticulo()
            .Reporte.SetDataSource(TablaReporteMercad_FacturasXCliente)
            .Reporte.SetParameterValue(0, Operador.Base)
            '  .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If

        End With
    End Sub
End Class