Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Listado_CalculoCosto_ImportacionXCarpeta



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Carpeta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub


    Private Sub txt_Carpeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Carpeta.KeyDown
        Select Case e.KeyData
            Case Keys.Escape
                txt_Carpeta.Text = ""
        End Select
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

      
        Dim VectorEmpresa(11) As String

        VectorEmpresa(1) = "SurfactanSA"
        VectorEmpresa(3) = "Surfactan_II"
        VectorEmpresa(5) = "Surfactan_III"
        VectorEmpresa(6) = "Surfactan_IV"
        VectorEmpresa(7) = "Surfactan_V"
        VectorEmpresa(10) = "Surfactan_VI"
        VectorEmpresa(11) = "Surfactan_VII"

        Dim TablaGastos As New DataTable
        With TablaGastos.Columns
            .Add("Concepto")
            .Add("Importe")
        End With


        Dim WCarpeta As String
        WCarpeta = txt_Carpeta.Text.PadLeft(6, "0")

        Dim SQLCnslt As String = "DELETE Carpeta"

        ExecuteNonQueries({SQLCnslt}, Operador.Base)


        Dim WMarca As String = ""


        Dim ImpoGastos As Double = 0
        Dim ImpoSeguro As Double = 0
        Dim ImpoFlete As Double = 0

        Dim WArancel As String = ""
        Dim WOrden As String = ""
        Dim WEmpresaOtro As Integer = 0

        SQLCnslt = "SELECT Marca, Derechos, Orden, Empresa, Concepto, Importe " _
                    & "FROM Movgas " _
                    & "WHERE Carpeta = '" & WCarpeta & "'" _
                    & "ORDER BY Carpeta"

        Dim TablaMovGas As DataTable = GetAll(SQLCnslt, Operador.Base)
        If TablaMovGas.Rows.Count > 0 Then

            For Each RowGas As DataRow In TablaMovGas.Rows
                WMarca = IIf(IsDBNull(RowGas.Item("Marca")), "", RowGas.Item("Marca"))
                If RowGas.Item("Concepto") <> 10 Then
                    WArancel = Str$(RowGas.Item("Derechos"))
                    WOrden = Str$(RowGas.Item("Orden"))
                    WEmpresaOtro = RowGas.Item("Empresa")
                    Select Case RowGas.Item("Concepto")
                        Case 2
                            ImpoSeguro = ImpoSeguro + RowGas.Item("Importe")
                        Case 4, 5
                            ImpoFlete = ImpoFlete + RowGas.Item("Importe")
                        Case Else


                            TablaGastos.Rows.Add(RowGas.Item("Concepto"), RowGas.Item("Importe"))

                            ImpoGastos = ImpoGastos + RowGas.Item("Importe")
                    End Select
                End If
            Next
           
        End If

        Dim WGastos As Integer = TablaGastos.Rows.Count
        Dim ImpoArancel As Double = 0

    
        Dim ZNroInforme As String
        Dim ZFechaInforme As String


        Dim ZCoeParidad As Double = 1
        SQLCnslt = "Select Informe, Fecha " _
                    & " FROM Informe" _
                    & " Where Orden = '" & WOrden & "'"

        Dim RowInfor As DataRow = GetSingle(SQLCnslt, VectorEmpresa(WEmpresaOtro))
        If RowInfor IsNot Nothing Then

            ZNroInforme = RowInfor.Item("Informe")
            ZFechaInforme = RowInfor.Item("Fecha")



            
            SQLCnslt = "SELECT * FROM Cambios WHERE Fecha = '" & ZFechaInforme & "'"
            Dim RowCambio As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
            If RowCambio IsNot Nothing Then
                Dim ZParidad As Double = RowCambio.Item("Cambio")
                Dim ZParidadII As Double = IIf(IsDBNull(RowCambio.Item("CambioII")), 0, RowCambio.Item("CambioII"))
                If ZParidadII <> 0 And ZParidad <> 0 Then
                    ZCoeParidad = ZParidadII / ZParidad
                End If

            End If

        

        End If


        Dim TablaVector As New DataTable
        With TablaVector.Columns
            .Add("Carpeta")
            .Add("Articulo")
            .Add("Cantidad")
            .Add("Precio")
            .Add("Total")
            .Add("Derechos")
            .Add("TotalXArancel")
            .Add("GastosImpo")
            .Add("GastosTotal")
            .Add("Clave")
        End With

        Dim Renglon As Integer = 0


        Dim WTotalImpo As Double = 0
        Dim WTotalPeso As Double = 0

        Dim WLeyenda As Integer = 0

        SQLCnslt = "SELECT Moneda, Precio, Articulo, Cantidad, Derechos, Leyenda " _
                    & "FROM Orden WHERE Orden = '" & WOrden & "' ORDER BY Orden,Renglon"

        Dim tablaOrden As DataTable = GetAll(SQLCnslt, VectorEmpresa(WEmpresaOtro))

        If tablaOrden.Rows.Count > 0 Then
            For Each rowOrden As DataRow In tablaOrden.Rows

                TablaVector.Rows.Add()


                Dim WMoneda As Integer = rowOrden.Item("Moneda")
                Dim ZZPrecio As Double = rowOrden.Item("Precio")
                If WMoneda = 2 Then
                    ZZPrecio = ZZPrecio * ZCoeParidad
                End If

                TablaVector.Rows(Renglon).Item("Carpeta") = txt_Carpeta.Text
                TablaVector.Rows(Renglon).Item("Articulo") = rowOrden.Item("Articulo")
                TablaVector.Rows(Renglon).Item("Cantidad") = rowOrden.Item("Cantidad")
                TablaVector.Rows(Renglon).Item("Precio") = Str$(ZZPrecio)
                TablaVector.Rows(Renglon).Item("Total") = Str$(rowOrden.Item("Cantidad") * ZZPrecio)
                
                If IsDBNull(rowOrden.Item("Derechos")) Then
                    TablaVector.Rows(Renglon).Item("Derechos") = ""
                Else
                    TablaVector.Rows(Renglon).Item("Derechos") = Str$(rowOrden.Item("Derechos"))
                End If

                TablaVector.Rows(Renglon).Item("TotalXArancel") = ""
                TablaVector.Rows(Renglon).Item("GastosImpo") = ""
                TablaVector.Rows(Renglon).Item("GastosTotal") = ""
                TablaVector.Rows(Renglon).Item("Clave") = WCarpeta + "01"

                WTotalImpo = WTotalImpo + (rowOrden.Item("Cantidad") * ZZPrecio)
                WTotalPeso = WTotalPeso + rowOrden.Item("Cantidad")

                WLeyenda = IIf(IsDBNull(rowOrden.Item("Leyenda")), 0, rowOrden.Item("Leyenda"))

                Renglon += 1
            Next
            
        End If



        Dim WTotal As Double = 0

        For Each Rowvector As DataRow In TablaVector.Rows
            Dim WSeguro As Double = 0
            Dim WFlete As Double = 0
            Dim WCosto As Double = 0

            If ImpoSeguro <> 0 Then
                If WTotalImpo <> 0 Then
                    WSeguro = ((Val(Rowvector.Item("Total")) / WTotalImpo) * ImpoSeguro) / Val(Rowvector.Item("Cantidad"))
                End If
            End If
            If ImpoFlete <> 0 Then
                If WTotalPeso <> 0 Then
                    WFlete = ((Rowvector.Item("Cantidad") / WTotalPeso) * ImpoFlete) / Val(Rowvector.Item("Cantidad"))
                End If
            End If
            'aa = Vector(Ciclo, 2)
            WCosto = Val(Rowvector.Item("Precio")) + WSeguro + WFlete
            WCosto = Val(formatonumerico(WCosto))
            Rowvector.Item("Precio") = Str$(WCosto)



            Dim WArticulo As String = Rowvector.Item("Articulo")
            Dim TotalAux As Double

            SQLCnslt = "SELECT * FROM Articulo WHERE Codigo = '" & WArticulo & "'"
            Dim RowArti As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If RowArti IsNot Nothing Then
                TotalAux = Val(formatonumerico(Rowvector.Item("Cantidad") * Val(Rowvector.Item("Precio")), 2))
                Rowvector.Item("Total") = TotalAux


                Dim DerechosAux As Double = Val(formatonumerico(Rowvector.Item("Derechos")))

                Dim XArancel As Double = Val(formatonumerico((TotalAux * DerechosAux / 100), 3))

                Dim TotalXArancelAux As Double = Val(Rowvector.Item("Total")) + XArancel
                Rowvector.Item("TotalXArancel") = TotalXArancelAux
                WTotal = WTotal + Val(Rowvector.Item("Total"))
                ImpoArancel = ImpoArancel + XArancel

            End If

        Next


        For Each Rowvector As DataRow In TablaVector.Rows
            If WTotal <> 0 Then
                Dim TotalAux As Double = Rowvector.Item("Total")
                'Dim GastosImpoAux as double= Str$((Val(Rowvector.Item("Total")) / WTotal) * ImpoGastos)
                Dim GastosImpoAux As Double = (TotalAux / WTotal) * ImpoGastos
                Rowvector.Item("GastosImpo") = GastosImpoAux
            End If
            If Val(Rowvector.Item("Cantidad")) <> 0 Then
                Rowvector.Item("GastosTotal") = Str$((Val(Rowvector.Item("TotalXArancel")) + Val(Rowvector.Item("GastosImpo"))) / Val(Rowvector.Item("Cantidad")))
            End If

        Next

        Dim WCoeficiente As String

        If WTotal <> 0 Then
            WCoeficiente = Str$((ImpoGastos + ImpoArancel) / (WTotal / 100))
            WCoeficiente = Str$(1 + (Val(WCoeficiente) / 100))
        Else
            WCoeficiente = ""
        End If





        Dim ListaSQLCnslt As New List(Of String)

        Dim XLeyenda As String = Str$(WLeyenda)
        For Each Rowvector As DataRow In TablaVector.Rows


            SQLCnslt = "INSERT INTO  Carpeta(" _
                         & "Carpeta," _
                         & "Articulo, " _
                         & "Cantidad, " _
                         & "CostoFlete, " _
                         & "Importe, " _
                         & "Arancel, " _
                         & "Costo, " _
                         & "Gastos, " _
                         & "Precio, " _
                         & "Coeficiente, " _
                         & "Clave, " _
                         & "Leyenda) " _
                         & "VALUES(" _
                         & "'" & Rowvector.Item("Carpeta") & "', " _
                         & "'" & Rowvector.Item("Articulo") & "', " _
                         & "'" & Rowvector.Item("Cantidad") & "', " _
                         & "'" & Rowvector.Item("Precio") & "', " _
                         & "'" & Rowvector.Item("Total").ToString().Replace(",", ".") & "', " _
                         & "'" & Rowvector.Item("Derechos") & "', " _
                         & "'" & Rowvector.Item("TotalXArancel").ToString().Replace(",", ".") & "', " _
                         & "'" & Rowvector.Item("GastosImpo").ToString().Replace(",", ".") & "', " _
                         & "'" & Rowvector.Item("GastosTotal") & "', " _
                         & "'" & WCoeficiente & "', " _
                         & "'" & Rowvector.Item("Clave") & "', " _
                         & "'" & XLeyenda & "') "

            ListaSQLCnslt.Add(SQLCnslt)

        Next

        If ListaSQLCnslt.Count > 0 Then
            ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)
        End If






        Dim WFormula As String = "{Carpeta.Carpeta} = " & txt_Carpeta.Text & ""

        With New VistaPrevia

            If WMarca <> "X" Then
                .Reporte = New Reporte_CalculoCosto_ImportacionXCarpetaFALTA
            Else
                .Reporte = New Reporte_CalculoCosto_ImportacionXCarpeta
            End If
            .Reporte.SetParameterValue(0, Operador.Base)

            .Formula = WFormula

            If rabtn_Pantalla.Checked Then
                .Mostrar()
            Else
                .Imprimir()
            End If
        End With



    End Sub
End Class