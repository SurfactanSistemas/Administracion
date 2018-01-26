Imports System.Data.SqlClient

Public Class AnalisisDesarrollo
    
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDesde.Clear()
        txtHasta.Clear()
    End Sub
    
    Private Sub Login_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtDesde.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown

        If e.KeyData = Keys.Enter Then
            If txtDesde.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtDesde.Text) Then
                txtHasta.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Clear()
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtHasta.Text.estaVacia Then : Exit Sub : End If

            If Helper._ValidarFecha(txtHasta.Text) Then

                If txtDesde.Text.esMenorA(txtHasta.Text) Then
                    txtDesde.Focus()
                Else
                    MsgBox("La fecha final debe ser posterior a la fecha inicial")
                End If

            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Clear()
        End If
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Orden, Fecha, Observaciones FROM OrdenTrabajo")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing
        Dim WVectorI As New List(Of Object)
        Dim WVectorII As New List(Of Object)
        Dim WDesdeFecha = Helper.ordenaFecha(txtDesde.Text), WHastaFecha = Helper.ordenaFecha(txtHasta.Text)
        Dim WFecha = "", WAux = "", WOrden = "", WObs = "", WHoja = "", WProducto = "", WCantidad = 0.0, WImpo1 = "", WImpo2 = "", WImpo3 = "", ZSql = ""
        Dim WVenta = 0.0, WA = 0

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            ' Extraemos los datos de las Ordenes de Trabajo que se encuentren dentro del rango de Fechas.
            If dr.HasRows Then

                With dr
                    Do While .Read()

                        WFecha = IIf(IsDBNull(.Item("Fecha")), "", .Item("Fecha"))
                        
                        If WFecha.estaVacia Then Continue Do

                        WAux = Helper.ordenaFecha(WFecha)

                        If WAux >= WDesdeFecha And WAux <= WHastaFecha Then

                            WOrden = IIf(IsDBNull(.Item("Orden")), "", .Item("Orden"))
                            WObs = IIf(IsDBNull(.Item("Observaciones")), "", .Item("Observaciones"))

                            WVectorI.Add({WOrden, WFecha, WObs})

                        End If

                    Loop
                End With

            End If

            If Not dr.IsClosed Then
                dr.Close()
            End If

            ' Salimos en caso de no tener Ordenes que procesar.
            If WVectorI.Count = 0 Then
                MsgBox("No se encontraron Ordenes de Trabajo dentro del rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' Limpiamos los datos antiguos de la tabla.
            cm.CommandText = "DELETE FROM AnalisisDesarrollo"
            cm.ExecuteNonQuery()

            WOrden = ""
            WFecha = ""
            WObs = ""


            ' Buscamos las Hojas que lo tengan como Producto Terminado.
            For Each _Vector As Object In WVectorI

                WOrden = _Vector(0) & "-100"
                WFecha = _Vector(1)
                WObs = _Vector(2)
                WA = 0

                cm.CommandText = "SELECT Hoja, Producto, Cantidad FROM Hoja WHERE Terminado = '" & WOrden & "' AND Renglon = 1"
                dr = cm.ExecuteReader

                WVectorII.Clear()

                If dr.HasRows Then

                    With dr
                        .Read()
                        WProducto = IIf(IsDBNull(.Item("Producto")), "", .Item("Producto"))

                        If Trim(WProducto).StartsWith("PT") Then

                            WHoja = IIf(IsDBNull(.Item("Hoja")), "", .Item("Hoja"))
                            WCantidad = IIf(IsDBNull(.Item("Cantidad")), 0.0, .Item("Cantidad"))

                            WVectorII.Add({WOrden, WFecha, WObs, WHoja, WProducto, Str$(WCantidad)})

                        End If
                    End With

                Else

                    WVectorII.Add({WOrden, WFecha, WObs, "", "", "0"})

                End If

                If Not dr.IsClosed Then
                    dr.Close()
                End If
                
                WImpo1 = "0"
                WImpo2 = "0"
                ' Buscamos en las estadisticas, las hojas encontradas.
                For Each _VectorII As Object In WVectorII

                    WA += 1

                    WOrden = _VectorII(0)
                    WFecha = _VectorII(1)
                    WObs = _VectorII(2)
                    WHoja = _VectorII(3)
                    WProducto = _VectorII(4)
                    WCantidad = _VectorII(5)

                    WVenta = 0.0

                    If cn.IsOpened Then
                        cn.Close()
                    End If

                    If Helper._EsPellital Then
                        cn.ConnectionString = Helper._ConectarA("Pellital_III")
                    Else
                        cn.ConnectionString = Helper._ConectarA("SurfactanSA")
                    End If

                    cn.Open()
                    cm.Connection = cn
                    cm.CommandText = "SELECT Lote1, Lote2, Lote3, Lote4, Lote5, Canti1, Canti2, Canti3, Canti4, Canti5 FROM Estadistica WHERE Articulo = '" & WProducto & "' And Tipo = 1"

                    dr = cm.ExecuteReader

                    If dr.HasRows Then

                        Do While dr.Read()
                            For i = 1 To 5

                                If dr.Item("Lote" & i) = Val(WHoja) Then

                                    WVenta += dr.Item("Canti" & i)

                                End If

                            Next
                        Loop

                    End If

                    If Not dr.IsClosed Then
                        dr.Close()
                    End If

                    If WVenta > WCantidad Then
                        WVenta = Val(WCantidad)
                    End If

                    WImpo1 = "0"
                    WImpo2 = "0"

                    If WA = 1 Then
                        WImpo3 = "1"
                    Else
                        WImpo3 = "0"
                    End If


                    ZSql = ""
                    ZSql = ZSql & "INSERT INTO AnalisisDesarrollo ("
                    ZSql = ZSql & "Codigo ,"
                    ZSql = ZSql & "Descripcion ,"
                    ZSql = ZSql & "Fecha ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Produccion ,"
                    ZSql = ZSql & "Venta ,"
                    ZSql = ZSql & "Hoja ,"
                    ZSql = ZSql & "Empresa ,"
                    ZSql = ZSql & "Titulo ,"
                    ZSql = ZSql & "Impo1 ,"
                    ZSql = ZSql & "Impo2 ,"
                    ZSql = ZSql & "Impo3 ,"
                    ZSql = ZSql & "Articulo )"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WOrden & "',"
                    ZSql = ZSql & "'" & WObs & "',"
                    ZSql = ZSql & "'" & WFecha & "',"
                    ZSql = ZSql & "'" & Str$(WA) & "',"
                    ZSql = ZSql & "'" & Str$(WCantidad) & "',"
                    ZSql = ZSql & "'" & Str$(WVenta) & "',"
                    ZSql = ZSql & "'" & WHoja & "',"
                    ZSql = ZSql & "'" & "" & "',"
                    ZSql = ZSql & "'" & "Desde el " & txtDesde.Text & " hasta el " & txtHasta.Text & "',"
                    ZSql = ZSql & "'" & WImpo1 & "',"
                    ZSql = ZSql & "'" & WImpo2 & "',"
                    ZSql = ZSql & "'" & WImpo3 & "',"
                    ZSql = ZSql & "'" & WProducto & "')"

                    If cn.IsOpened Then
                        cn.Close()
                    End If

                    cn.ConnectionString = Helper._ConectarA
                    cn.Open()
                    cm.Connection = cn
                    cm.CommandText = ZSql

                    cm.ExecuteNonQuery()

                    If Val(WCantidad) <> 0 Then
                        WImpo1 = 1
                    End If
                    If Val(WVenta) <> 0 Then
                        WImpo2 = 1
                    End If
                    
                    If WImpo1 = 1 Then
                        ZSql = ""
                        ZSql = ZSql + "UPDATE AnalisisDesarrollo SET "
                        ZSql = ZSql + "Impo1 = 1"
                        ZSql = ZSql + " Where Codigo = " + "'" + WOrden + "'"
                        ZSql = ZSql + " and Renglon = 1"

                        If cn.IsOpened Then
                            cn.Close()
                        End If

                        cn.ConnectionString = Helper._ConectarA
                        cn.Open()
                        cm.Connection = cn
                        cm.CommandText = ZSql

                        cm.ExecuteNonQuery()

                    End If

                    If WImpo2 = 1 Then
                        ZSql = ""
                        ZSql = ZSql + "UPDATE AnalisisDesarrollo SET "
                        ZSql = ZSql + "Impo2 = 1"
                        ZSql = ZSql + " Where Codigo = " + "'" + WOrden + "'"
                        ZSql = ZSql + " and Renglon = 1"

                        If cn.IsOpened Then
                            cn.Close()
                        End If

                        cn.ConnectionString = Helper._ConectarA
                        cn.Open()
                        cm.Connection = cn
                        cm.CommandText = ZSql

                        cm.ExecuteNonQuery()

                    End If


                Next

            Next

            
            ' Imprimimos por pantalla.

            With VistaPrevia
                .DesdeArchivo(Configuration.ConfigurationManager.AppSettings("reportsLocation").ToString & "WAnalisisDesarrollo.rpt")

                .Mostrar()
            End With


        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub
End Class