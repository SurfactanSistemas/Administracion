Imports Util
Imports Util.Clases.Helper
Imports Util.Clases.Query

Public Class Listado_PercepcionesIIBB

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim WDesde As String = ordenaFecha(txt_DesdeFecha.Text)
        Dim WHasta As String = ordenaFecha(txt_HastaFecha.Text)

        Dim TablaRecibosAux As New DataTable
        With TablaRecibosAux.Columns
            .Add("Clave")
            .Add("Fecha")
            .Add("Tipo1")
            .Add("Numero1")
        End With



        Dim SQLCnslt As String = ""

        Select Case cbx_Provincia.SelectedIndex
            Case 0
                SQLCnslt = "UPDATE Ctacte SET " _
                           & " ImpoIbTucu = 0" _
                           & " WHERE ImpoIbTucu IS NULL"
                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                SQLCnslt = "UPDATE  Ctacte SET " _
                            & "Importe4 = 0, " _
                            & "Importe5 = 0, " _
                            & "Importe6 = 0, " _
                            & "Importe7 = 0, " _
                            & "Importe8	= 0"

                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                REM Procesa las cobranzas

                Dim Renglon As String = 0

                SQLCnslt = "SELECT Clave, Fecha, Tipo1, Numero1 " _
                            & "FROM Recibos " _
                            & "WHERE FechaOrd >= '" & WDesde & "' AND FechaOrd <= '" & WHasta & "' " _
                            & "AND Tiporeg = 1 " _
                            & "ORDER BY Clave"

                Dim TablaReci As DataTable = GetAll(SQLCnslt, Operador.Base)

                If TablaReci.Rows.Count > 0 Then

                    For Each RowReci As DataRow In TablaReci.Rows

                        TablaRecibosAux.Rows.Add()
                        TablaRecibosAux.Rows(Renglon).Item("Clave") = RowReci.Item("Clave")
                        TablaRecibosAux.Rows(Renglon).Item("Fecha") = RowReci.Item("Fecha")
                        TablaRecibosAux.Rows(Renglon).Item("Tipo1") = RowReci.Item("Tipo1")
                        TablaRecibosAux.Rows(Renglon).Item("Numero1") = RowReci.Item("Numero1")

                        Renglon += 1
                    Next
                    
                End If

                For Each RowReciAux As DataRow In TablaRecibosAux.Rows

                    Dim WClave As String = RowReciAux.Item("Clave")
                    Dim WFecha As String = RowReciAux.Item("Fecha")
                    Dim WTipo As String = RowReciAux.Item("Tipo1")
                    Dim WNumero As String = RowReciAux.Item("Numero1")

                    Dim ClaveCtacte As String = WTipo & WNumero & "01"


                    SQLCnslt = "SELECT ImpoIb FROM Ctacte WHERE Clave = '" & ClaveCtacte & "'"

                    Dim RowImpoIb As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowImpoIb IsNot Nothing Then
                        Dim WImpoIb As Double = IIf(IsDBNull(RowImpoIb.Item("ImpoIb")), "0", RowImpoIb.Item("ImpoIb"))
                        If WImpoIb = 0 Then
                            RowReciAux.Item("Clave") = ""
                            RowReciAux.Item("Fecha") = ""
                            RowReciAux.Item("Tipo1") = ""
                            RowReciAux.Item("Numero1") = ""
                        End If

                    Else
                        RowReciAux.Item("Clave") = ""
                        RowReciAux.Item("Fecha") = ""
                        RowReciAux.Item("Tipo1") = ""
                        RowReciAux.Item("Numero1") = ""
                    End If

                Next
              
                For Each RowReciAux As DataRow In TablaRecibosAux.Rows

                    Dim WClave As String = RowReciAux.Item("Clave")
                    If WClave <> "" Then

                        Dim WTipo As String = RowReciAux.Item("Tipo1")
                        Dim WNumero As String = RowReciAux.Item("Numero1")
                        Dim WRecibo As String = Microsoft.VisualBasic.Left$(WClave, 6)
                        Dim WSale As String = "N"

                        SQLCnslt = "SELECT Recibo " _
                                   & "FROM Recibos " _
                                   & "WHERE Tipo1 = '" & WTipo & "' " _
                                   & "AND Numero1 = '" & WNumero & "' " _
                                   & "ORDER BY Clave"
                        Dim TablaRecib As DataTable = GetAll(SQLCnslt, Operador.Base)

                        If TablaRecib.Rows.Count > 0 Then
                            For Each RowRecib As DataRow In TablaRecib.Rows
                                If Val(RowRecib.Item("Recibo")) < Val(WRecibo) Then
                                    WSale = "S"
                                End If
                            Next
                            
                        End If

                        If WSale = "S" Then
                            RowReciAux.Item("Clave") = ""
                            RowReciAux.Item("Fecha") = ""
                            RowReciAux.Item("Tipo1") = ""
                            RowReciAux.Item("Numero1") = ""
                        End If

                    End If

                Next
              
                For Each RowReciAux As DataRow In TablaRecibosAux.Rows
                    Dim WClave = RowReciAux.Item("Clave") ' Esta es la clve de recibo
                    If WClave <> "" Then

                        '   Dim WImpoIB As Double
                        '   Dim WNeto As Double
                        '   Dim WIva1 As Double
                        '   Dim WIva2 As Double
                        '
                        '   SQLCnslt = "SELECT ImpoIB, Neto, Iva1, Iva2 FROM CtaCte WHERE Clave = '" & WClave & "'"
                        '   Dim RowAux As DataRow = GetSingle(SQLCnslt, Operador.Base)
                        '   If RowAux IsNot Nothing Then
                        '       WImpoIB = RowAux.Item("ImpoIB")
                        '       WNeto = RowAux.Item("Neto")
                        '       WIva1 = RowAux.Item("Iva1")
                        '       WIva2 = RowAux.Item("Iva2")
                        '   End If

                        Dim WTipo As String = RowReciAux.Item("Tipo1")
                        Dim WNumero As String = RowReciAux.Item("Numero1")

                        Dim ClaveCtacte As String = WTipo + WNumero + "01"



                        SQLCnslt = "UPDATE  Ctacte SET " _
                                    & "ClaveRecibo = '" & WClave & "', " _
                                    & "Importe4	= Neto, " _
                                    & "Importe5	= Iva1 , " _
                                    & "Importe6	= Iva2 , " _
                                    & "Importe7	= 0, " _
                                    & "Importe8 = ImpoIB " _
                                    & "WHERE Clave = '" & ClaveCtacte & "'"

                        ExecuteNonQueries(Operador.Base, {SQLCnslt})

                    End If
                Next

                
                Dim WTitulo As String = "del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text

                Dim WFormula As String = "{CtaCte.Tipo} >= '" & "01" & "' AND {CtaCte.Tipo} <= '" & "05" & "' " _
                                        & "AND {CtaCte.Importe8} <> 0 " _
                                        & "AND {CtaCte.OrdFecha} >= '" & "00000000" & "' AND {CtaCte.OrdFecha} <= '" & "99999999" & "'"


                REM Listado.GroupSelectionFormula = "{CtaCte.OrdFecha} in " + Chr$(34) + WDesde + Chr$(34) + " to " + Chr$(34) + WHasta + Chr$(34)
                With New VistaPrevia
                    
                    .Reporte = New Reporte_Listado_IBVen()
                    .Reporte.SetParameterValue(0, Operador.Base)
                    .Reporte.SetParameterValue(1, WTitulo)
                    .Formula = WFormula

                    If rabtn_Pantalla.Checked Then
                        .Mostrar()
                    Else
                        .Imprimir()
                    End If
                End With
                
                
            Case 1

                SQLCnslt = "UPDATE Ctacte SET " _
                            & "ImpoIbTucu = 0 " _
                            & "WHERE ImpoIbTucu IS NULL "


                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                Dim WFormula As String = "{CtaCte.Tipo} >= '" & "01" & "' AND {CtaCte.Tipo} <= '" & "05" & "' " _
                                         & "AND {CtaCte.ImpoIbTucu} <> 0 " _
                                         & "AND {CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "'"

                Dim WTitulo As String = "del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text

                With New VistaPrevia
                    .Reporte = New Reporte_Listado_IB_Tucu()
                    .Reporte.SetParameterValue(0, Operador.Base)
                    .Reporte.SetParameterValue(1, WTitulo)
                    .Formula = WFormula
                    If rabtn_Pantalla.Checked Then
                        .Mostrar()
                    Else
                        .Imprimir()
                    End If
                End With
                
                
            Case 99
                SQLCnslt = "UPDATE Ctacte SET " _
                           & "ImpoIbCiudad = 0 " _
                           & "WHERE ImpoIbCiudad IS NULL"

                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                
                Dim WTitulo As String = "del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text

                Dim WFormula As String = "{CtaCte.Tipo} >= '" & "01" & "' AND {CtaCte.Tipo} <= '" & "05" & "' " _
                                        & "AND {CtaCte.ImpoIbCiudad} <> 0 " _
                                        & "AND {CtaCte.OrdFecha} >= '" & WDesde & "' AND {CtaCte.OrdFecha} <= '" & WHasta & "'"


                With New VistaPrevia
                    '.Reporte = "ListIbCiudad.rpt"
                    .Reporte = New Reporte_Listado_IB_Ciudad()
                    .Reporte.SetParameterValue(0, Operador.Base)
                    .Reporte.SetParameterValue(1, WTitulo)
                    .Formula = WFormula
                    
                    If rabtn_Pantalla.Checked Then
                        .Mostrar()
                    Else
                        .Imprimir()
                    End If
                End With
                
            Case Else
                SQLCnslt = "UPDATE Ctacte SET " _
                            & " ImpoIbTucu = 0" _
                            & " Where ImpoIbTucu IS NULL"
                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                SQLCnslt = "UPDATE Ctacte SET " _
                           & " ImpoIbCiudad = 0" _
                           & " Where ImpoIbCiudad IS NULL"

                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                SQLCnslt = "UPDATE  Ctacte SET " _
                            & "Importe4 = 0, " _
                            & "Importe5 = 0, " _
                            & "Importe6 = 0, " _
                            & "Importe7 = 0, " _
                            & "Importe8	= 0"

                ExecuteNonQueries(Operador.Base, {SQLCnslt})

                REM Procesa las cobranzas

                Dim Renglon As String = 0

                SQLCnslt = "SELECT Clave, Fecha, Tipo1, Numero1 " _
                            & "FROM Recibos " _
                            & "WHERE FechaOrd >= '" & WDesde & "' AND FechaOrd <= '" & WHasta & "' " _
                            & "AND Tiporeg = 1 " _
                            & "ORDER BY Clave"

                Dim TablaReci As DataTable = GetAll(SQLCnslt, Operador.Base)

                If TablaReci.Rows.Count > 0 Then

                    For Each RowReci As DataRow In TablaReci.Rows

                        TablaRecibosAux.Rows.Add()
                        TablaRecibosAux.Rows(Renglon).Item("Clave") = RowReci.Item("Clave")
                        TablaRecibosAux.Rows(Renglon).Item("Fecha") = RowReci.Item("Fecha")
                        TablaRecibosAux.Rows(Renglon).Item("Tipo1") = RowReci.Item("Tipo1")
                        TablaRecibosAux.Rows(Renglon).Item("Numero1") = RowReci.Item("Numero1")

                        Renglon += 1
                    Next

                End If
                
                For Each RowReciAux As DataRow In TablaRecibosAux.Rows

                    Dim WClave As String = RowReciAux.Item("Clave")
                    Dim WFecha As String = RowReciAux.Item("Fecha")
                    Dim WTipo As String = RowReciAux.Item("Tipo1")
                    Dim WNumero As String = RowReciAux.Item("Numero1")

                    Dim ClaveCtacte As String = WTipo & WNumero & "01"


                    SQLCnslt = "SELECT ImpoIbCiudad FROM Ctacte WHERE Clave = '" & ClaveCtacte & "'"

                    Dim RowImpoIb As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If RowImpoIb IsNot Nothing Then
                        Dim WImpoIb As Double = IIf(IsDBNull(RowImpoIb.Item("ImpoIbCiudad")), "0", RowImpoIb.Item("ImpoIbCiudad"))
                        If WImpoIb = 0 Then
                            RowReciAux.Item("Clave") = ""
                            RowReciAux.Item("Fecha") = ""
                            RowReciAux.Item("Tipo1") = ""
                            RowReciAux.Item("Numero1") = ""
                        End If

                    Else
                        RowReciAux.Item("Clave") = ""
                        RowReciAux.Item("Fecha") = ""
                        RowReciAux.Item("Tipo1") = ""
                        RowReciAux.Item("Numero1") = ""
                    End If

                Next

                For Each RowReciAux As DataRow In TablaRecibosAux.Rows

                    Dim WClave As String = RowReciAux.Item("Clave")
                    If WClave <> "" Then

                        Dim WTipo As String = RowReciAux.Item("Tipo1")
                        Dim WNumero As String = RowReciAux.Item("Numero1")
                        Dim WRecibo As String = Microsoft.VisualBasic.Left$(WClave, 6)
                        Dim WSale As String = "N"

                        SQLCnslt = "SELECT Recibo " _
                                   & "FROM Recibos " _
                                   & "WHERE Tipo1 = '" & WTipo & "' " _
                                   & "AND Numero1 = '" & WNumero & "' " _
                                   & "ORDER BY Clave"
                        Dim TablaRecib As DataTable = GetAll(SQLCnslt, Operador.Base)

                        If TablaRecib.Rows.Count > 0 Then
                            For Each RowRecib As DataRow In TablaRecib.Rows
                                If Val(RowRecib.Item("Recibo")) < Val(WRecibo) Then
                                    WSale = "S"
                                End If
                            Next

                        End If

                        If WSale = "S" Then
                            RowReciAux.Item("Clave") = ""
                            RowReciAux.Item("Fecha") = ""
                            RowReciAux.Item("Tipo1") = ""
                            RowReciAux.Item("Numero1") = ""
                        End If

                    End If

                Next

            

                For Each RowReciAux As DataRow In TablaRecibosAux.Rows
                    Dim WClave = RowReciAux.Item("Clave")
                    If WClave <> "" Then

                        Dim WTipo As String = RowReciAux.Item("Tipo1")
                        Dim WNumero As String = RowReciAux.Item("Numero1")

                        Dim ClaveCtacte As String = WTipo + WNumero + "01"

                        SQLCnslt = "UPDATE  Ctacte SET " _
                                    & "ClaveRecibo = '" & WClave & "', " _
                                    & "Importe4	= Neto, " _
                                    & "Importe5	= Iva1, " _
                                    & "Importe6	= Iva2, " _
                                    & "Importe7	= 0, " _
                                    & "Importe8 = ImpoIbCiudad " _
                                    & "WHERE Clave = '" & ClaveCtacte & "'"

                        ExecuteNonQueries(Operador.Base, {SQLCnslt})

                    End If
                Next


                Dim WTitulo As String = "del " & txt_DesdeFecha.Text & " al " & txt_HastaFecha.Text

                Dim WFormula As String = "{CtaCte.Tipo} >= '" & "01" & "' AND {CtaCte.Tipo} <= '" & "05" & "' " _
                                        & "AND {CtaCte.Importe8} <> 0 " _
                                        & "AND {CtaCte.OrdFecha} >= '" & "00000000" & "' AND {CtaCte.OrdFecha} <= '" & "99999999" & "'"



                With New VistaPrevia

                    .Reporte = New Reporte_Listado_IB_Ven_Ciudad()
                    .Reporte.SetParameterValue(0, Operador.Base)
                    .Reporte.SetParameterValue(1, WTitulo)
                    .Formula = WFormula

                    If rabtn_Pantalla.Checked Then
                        .Mostrar()
                    Else
                        .Imprimir()
                    End If
                End With
                
        End Select
    End Sub

    Private Sub Listado_PercepcionesIIBB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbx_Provincia.SelectedIndex = 0
    End Sub
End Class