Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_CalculoCosto_NacionalizacionMercaderia

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click


        Dim WCarpeta As String = txt_Carpeta.Text.PadLeft(6, "0")

        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "DELETE Carpeta"

        ListaSQLCnslt.Add(SQLCnslt)


        Dim Renglon As Integer = 0

        Dim tablaGastos As New DataTable
        With tablaGastos.Columns
            .Add("Concepto")
            .Add("Importe")
        End With

        Dim ImpoGastos As Double = 0
        Dim ImpoSeguro As Double = 0
        Dim ImpoFlete As Double = 0

        Dim WArancel As String
        Dim WOrden As String = ""
        Dim WEmpresaOtro As Integer


        SQLCnslt = "SELECT Derechos, Orden, Empresa, Concepto, Importe " _
                    & "FROM Movgas WHERE Carpeta = '" & txt_Carpeta.Text & "' ORDER BY Carpeta"

        Dim TablaMovGas As DataTable = GetAll(SQLCnslt, Operador.Base)

        If TablaMovGas.Rows.Count > 0 Then

            For Each RowMov As DataRow In TablaMovGas.Rows

                If RowMov.Item("Concepto") <> 10 Then
                    WArancel = Str$(RowMov.Item("Derechos"))
                    WOrden = Str$(RowMov.Item("Orden"))
                    WEmpresaOtro = RowMov.Item("Empresa")
                    Select Case RowMov.Item("Concepto")
                        Case 2
                            ImpoSeguro = ImpoSeguro + RowMov.Item("Importe")
                        Case 4, 5
                            ImpoFlete = ImpoFlete + RowMov.Item("Importe")
                        Case Else

                            tablaGastos.Rows.Add()
                            tablaGastos.Rows(Renglon).Item("Concepto") = Str$(RowMov.Item("Concepto"))
                            tablaGastos.Rows(Renglon).Item("Importe") = Str$(RowMov.Item("Importe"))
                            Renglon += 1
                            ImpoGastos = ImpoGastos + RowMov.Item("Importe")
                    End Select
                End If

            Next


        End If


        Dim ImpoArancel As Double = 0
        Dim WTotal As Double = 0

       

        Dim WTotalImpo As Double = 0
        Dim WTotalPeso As Double = 0

        Dim TablaReporte As New DataTable

        With TablaReporte.Columns
            .Add("Carpeta")
            .Add("Articulo")
            .Add("Cantidad")
            .Add("CostoFlete")
            .Add("Importe")
            .Add("Arancel")
            .Add("Costo")
            .Add("Gastos")
            .Add("Precio")
            .Add("Coeficiente")
            .Add("Clave")
            .Add("Leyenda")
            .Add("Vector13")
            .Add("CantidadII")
            .Add("GastosII")
        End With

        Dim WEmpresaOrden As String = Devuleve_Empresa(WEmpresaOtro)

        Renglon = 0


        SQLCnslt = "SELECT Articulo, Precio, Cantidad, Derechos, Leyenda " _
                    & "FROM " & WEmpresaOrden & ".dbo.Orden WHERE Orden = '" & WOrden & "' ORDER BY Orden,Renglon"


        Dim WLeyenda As String = ""

        Dim tablaOrden As DataTable = GetAll(SQLCnslt)

        If tablaOrden.Rows.Count > 0 Then

            For Each RowOrden As DataRow In tablaOrden.Rows

                TablaReporte.Rows.Add()


                TablaReporte.Rows(Renglon).Item("Carpeta") = txt_Carpeta.Text
                TablaReporte.Rows(Renglon).Item("Articulo") = RowOrden.Item("Articulo")
                TablaReporte.Rows(Renglon).Item("Cantidad") = RowOrden.Item("Cantidad")
                TablaReporte.Rows(Renglon).Item("CostoFlete") = RowOrden.Item("Precio")
                TablaReporte.Rows(Renglon).Item("Importe") = RowOrden.Item("Cantidad") * RowOrden.Item("Precio")
                TablaReporte.Rows(Renglon).Item("Arancel") = RowOrden.Item("Derechos")
                TablaReporte.Rows(Renglon).Item("Costo") = 0
                TablaReporte.Rows(Renglon).Item("Gastos") = 0
                TablaReporte.Rows(Renglon).Item("Precio") = 0
                TablaReporte.Rows(Renglon).Item("Coeficiente") = 0
                TablaReporte.Rows(Renglon).Item("Clave") = WCarpeta + "01"
                TablaReporte.Rows(Renglon).Item("Leyenda") = ""
                TablaReporte.Rows(Renglon).Item("CantidadII") = 0
                TablaReporte.Rows(Renglon).Item("Vector13") = 0
                TablaReporte.Rows(Renglon).Item("GastosII") = 0

                WTotalImpo = WTotalImpo + (RowOrden.Item("Cantidad") * RowOrden.Item("Precio"))
                WTotalPeso = WTotalPeso + RowOrden.Item("Cantidad")

                WLeyenda = IIf(IsDBNull(RowOrden.Item("Leyenda")), "0", RowOrden.Item("Leyenda"))

                Renglon += 1

            Next

        End If

        For i = 0 To TablaReporte.Rows.Count - 1
            Dim WSeguro As Double = 0
            Dim WFlete As Double = 0
            If ImpoSeguro <> 0 Then
                If WTotalImpo <> 0 Then
                    WSeguro = ((TablaReporte.Rows(i).Item("Importe") / WTotalImpo) * ImpoSeguro) / TablaReporte.Rows(i).Item("Cantidad")
                End If
            End If
            If ImpoFlete <> 0 Then
                If WTotalPeso <> 0 Then
                    WFlete = ((Val(TablaReporte.Rows(i).Item("Cantidad")) / WTotalPeso) * ImpoFlete) / Val(TablaReporte.Rows(i).Item("Cantidad"))
                End If
            End If
            Dim WCosto As Double = Val(TablaReporte.Rows(i).Item("CostoFlete")) + WSeguro + WFlete

            TablaReporte.Rows(i).Item("CostoFlete") = WCosto

        Next

        WTotal = 0

        For i = 0 To TablaReporte.Rows.Count - 1

            Dim WArticulo As String = TablaReporte.Rows(i).Item("Articulo")

            SQLCnslt = "SELECT Flete FROM Articulo WHERE Codigo = '" & WArticulo & "'"
            Dim RowArti As DataRow = GetSingle(SQLCnslt, Operador.Base)

            If RowArti IsNot Nothing Then
                REM Vector(Ciclo, 4) = Str$(rstArticulo!Flete)

                Dim Cantidad As Double = TablaReporte.Rows(i).Item("Cantidad")
                Dim CostoFlete As Double = TablaReporte.Rows(i).Item("CostoFlete")
                Dim Importe As Double
                Importe = Cantidad * CostoFlete
                TablaReporte.Rows(i).Item("Importe") = Importe
                Dim Arancel As Double = TablaReporte.Rows(i).Item("Arancel")
                Dim XArancel As Double = (TablaReporte.Rows(i).Item("Importe") * Arancel) / 100
                Dim Costo As Double = TablaReporte.Rows(i).Item("Importe") + XArancel
                TablaReporte.Rows(i).Item("Costo") = Costo
                WTotal = WTotal + TablaReporte.Rows(i).Item("Importe")
                ImpoArancel = ImpoArancel + XArancel

            End If
        Next

        For i = 0 To TablaReporte.Rows.Count - 1
            If WTotal <> 0 Then
                Dim ValorImporte As Double = TablaReporte.Rows(i).Item("Importe")
                Dim aux As Double = (TablaReporte.Rows(i).Item("Importe") / WTotal) * ImpoGastos
                TablaReporte.Rows(i).Item("Gastos") = aux
            End If
            If TablaReporte.Rows(i).Item("Cantidad") <> 0 Then
                Dim Costo As Double = TablaReporte.Rows(i).Item("Costo")
                Dim Cantidad As Double = TablaReporte.Rows(i).Item("Cantidad")
                Dim Gastos As Double = TablaReporte.Rows(i).Item("Gastos")
                Dim X As Double = (Costo + Gastos) / Cantidad
                TablaReporte.Rows(i).Item("Precio") = X
            End If
        Next

        Dim WCoeficiente As Double

        If WTotal <> 0 Then
            WCoeficiente = (ImpoGastos + ImpoArancel) / (WTotal / 100)
            WCoeficiente = (1 + WCoeficiente) / 100
        Else
            WCoeficiente = 0
        End If

        Dim Lugar As Integer = 0
        Dim SumaTotal As Double = 0
        Dim SumaGastos As Double = 0

        SQLCnslt = "Select Cantidad FROM MovGasParcialArti WHERE Codigo = '" & txt_Movimiento.Text & "' ORDER BY Clave"

        Dim TablaMovGasParArti As DataTable = GetAll(SQLCnslt)

        If TablaMovGasParArti.Rows.Count > 0 Then
            For Each rowMov As DataRow In TablaMovGasParArti.Rows
                Dim CantidadII As Double = rowMov.Item("Cantidad")
                TablaReporte.Rows(Lugar).Item("CantidadII") = CantidadII
                TablaReporte.Rows(Lugar).Item("Vector13") = TablaReporte.Rows(Lugar).Item("Precio") * TablaReporte.Rows(Lugar).Item("CantidadII")
                SumaTotal = SumaTotal + TablaReporte.Rows(Lugar).Item("Vector13")
                Lugar += 1
            Next
            
        End If


        SQLCnslt = "Select Importe FROM MovGasParcial WHERE Codigo = '" & txt_Movimiento.Text & "' ORDER BY Clave"

        Dim tablaMovGasPar As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tablaMovGasPar.Rows.Count > 0 Then
            For Each rowMovGas In tablaMovGasPar.Rows

                SumaGastos = SumaGastos + rowMovGas.item("Importe")

            Next

        End If

        For i = 0 To TablaReporte.Rows.Count - 1

            If SumaTotal <> 0 Then
                TablaReporte.Rows(i).Item("GastosII") = (TablaReporte.Rows(i).Item("Vector13") / SumaTotal) * SumaGastos
            End If

        Next

        Dim XLeyenda As String = Str$(WLeyenda)

        For i = 0 To TablaReporte.Rows.Count - 1

            Dim ZCarpeta As Integer = TablaReporte.Rows(i).Item("Carpeta")
            Dim ZArticulo As String = TablaReporte.Rows(i).Item("Articulo")
            Dim ZCantidad As String = TablaReporte.Rows(i).Item("Cantidad")
            ZCantidad = ZCantidad.Replace(",", ".")
            Dim ZCostoFlete As String = TablaReporte.Rows(i).Item("CostoFlete")
            ZCostoFlete = ZCostoFlete.Replace(",", ".")
            Dim ZImporte As String = TablaReporte.Rows(i).Item("Importe")
            ZImporte = ZImporte.Replace(",", ".")
            Dim ZArancel As String = TablaReporte.Rows(i).Item("Arancel")
            ZArancel = ZArancel.Replace(",", ".")
            Dim ZCosto As String = TablaReporte.Rows(i).Item("Costo")
            ZCosto = ZCosto.Replace(",", ".")
            Dim ZGastos As String = TablaReporte.Rows(i).Item("Gastos")
            ZGastos = ZGastos.Replace(",", ".")
            Dim ZPrecio As String = TablaReporte.Rows(i).Item("Precio")
            ZPrecio = ZPrecio.Replace(",", ".")
            Dim ZCoeficiente As String = WCoeficiente
            ZCoeficiente = ZCoeficiente.Replace(",", ".")
            Dim ZClave As String = TablaReporte.Rows(i).Item("Clave")
            Dim ZCantidadII As String = TablaReporte.Rows(i).Item("CantidadII")
            ZCantidadII = ZCantidadII.Replace(",", ".")
            Dim ZGastosII As String = TablaReporte.Rows(i).Item("GastosII")
            ZGastosII = ZGastosII.Replace(",", ".")

            SQLCnslt = "INSERT INTO Carpeta (" _
                            & "Carpeta ," _
                            & "Articulo ," _
                            & "Cantidad ," _
                            & "CostoFlete ," _
                            & "Importe ," _
                            & "Arancel ," _
                            & "Costo ," _
                            & "Gastos ," _
                            & "Precio ," _
                            & "Coeficiente ," _
                            & "Clave ," _
                            & "Leyenda ," _
                            & "CantidadII ," _
                            & "GastosII )" _
                            & "Values (" _
                            & "'" & ZCarpeta & "'," _
                            & "'" & ZArticulo & "'," _
                            & "'" & ZCantidad & "'," _
                            & "'" & ZCostoFlete & "'," _
                            & "'" & ZImporte & "'," _
                            & "'" & ZArancel & "'," _
                            & "'" & ZCosto & "'," _
                            & "'" & ZGastos & "'," _
                            & "'" & ZPrecio & "'," _
                            & "'" & ZCoeficiente & "'," _
                            & "'" & ZClave & "'," _
                            & "'" & XLeyenda & "'," _
                            & "'" & ZCantidadII & "'," _
                            & "'" & ZGastosII & "')"

            ListaSQLCnslt.Add(SQLCnslt)

        Next

        ExecuteNonQueries(Operador.Base, ListaSQLCnslt.ToArray())

        

        Dim WFormula As String = "{Carpeta.Carpeta} >= " & txt_Carpeta.Text & " AND {Carpeta.Carpeta} <= " & txt_Carpeta.Text & " " _
                                 & "AND {Carpeta.CantidadII} > 0"

        With New VistaPrevia
            .Reporte = New Reporte_CarpetaParcial()
            .Reporte.SetParameterValue(0, Operador.Base)
            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With

    End Sub



    Private Function Devuleve_Empresa(ByVal NumeroEmpresa As Integer) As String

        Select Case NumeroEmpresa

            Case 1
                Return "SurfactanSa"
            Case 3
                Return "Surfactan_II"
            Case 5
                Return "Surfactan_III"
            Case 6
                Return "Surfactan_IV"
            Case 7
                Return "Surfactan_V"
            Case 10
                Return "Surfactan_VI"

            Case Else
                Return "Surfactan_VII"
        End Select

    End Function




    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Movimiento.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txt_Movimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Movimiento.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnlst As String = "SELECT Carpeta FROM MovGasParcial WHERE Codigo = '" & txt_Movimiento.Text & "'"

                Dim rowMovGasPar As DataRow = GetSingle(SQLCnlst, Operador.Base)

                If rowMovGasPar IsNot Nothing Then
                    txt_Carpeta.Text = rowMovGasPar.Item("Carpeta")
                Else
                    SQLCnlst = "SELECT Carpeta FROM MovGasParcialArti WHERE Codigo = '" & txt_Movimiento.Text & "'"

                    Dim rowMovGasParArti As DataRow = GetSingle(SQLCnlst, Operador.Base)
                    If rowMovGasParArti IsNot Nothing Then
                        txt_Carpeta.Text = rowMovGasParArti.Item("Carpeta")
                    End If

                End If
            Case Keys.Escape
                txt_Movimiento.Text = ""
        End Select

       
    End Sub

    Private Sub Listado_CalculoCosto_NacionalizacionMercaderia_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Movimiento.Focus()
    End Sub
End Class