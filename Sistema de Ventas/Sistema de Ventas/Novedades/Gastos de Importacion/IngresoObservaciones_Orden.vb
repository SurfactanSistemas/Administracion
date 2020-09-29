Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class IngresoObservaciones_Orden

    Dim WCARPETA As String
    Dim WORDEN As String
    Dim WBASEdeORDEN As String

    Sub New(ByVal NumeroOrden As String, ByVal NumeroCarpeta As String, ByVal BaseConectar As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        WCARPETA = NumeroCarpeta
        WORDEN = NumeroOrden
        WBASEdeORDEN = BaseConectar
       
       
        Cbx_PagoDespacho.SelectedIndex = 0
     
      
        cbx_PagoLetra.SelectedIndex = 0
       
      
        cbx_EntregaI.SelectedIndex = 0
        
        cbx_EntregaII.SelectedIndex = 0
        '
        ' Call Limpia_VectorII()
        '
        ' WRenglon = 0
        '
        Dim SQLCnslt As String = "SELECT Texto1, Texto2 FROM ObservaOrden WHERE Carpeta = '" & NumeroCarpeta & "' ORDER BY Clave"

        Dim tabla As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tabla.Rows.Count > 0 Then
            For Each rowAux As DataRow In tabla.Rows
                Dim Texto1 As String = IIf(IsDBNull(rowAux.Item("Texto1")), "", rowAux.Item("Texto1"))
                Dim Texto2 As String = IIf(IsDBNull(rowAux.Item("Texto2")), "", rowAux.Item("Texto2"))
                DGV_Observaciones.Rows.Add(Texto1, Texto2)
            Next

        End If
        
        Dim CodOrdenAux As String = NumeroOrden.PadLeft(6, "0")
        
        Dim WClave As String = CodOrdenAux + "01"

        SQLCnslt = "SELECT FechaEmbarque, FechaLlegada, PagoDespacho, ImpoDespacho, VtoDespacho, PagoLetra, EntregaI, " _
            & "EntregaII, ImpoLetra, VtoLetra, VtoLetraII FROM Orden WHERE Clave = '" & WClave & "'"

        Dim RowOrden As DataRow = GetSingle(SQLCnslt, BaseConectar)

        If RowOrden IsNot Nothing Then
            txt_FechaEmbarque.Text = IIf(IsDBNull(RowOrden.Item("FechaEmbarque")), "  /  /    ", RowOrden.Item("FechaEmbarque"))
            txt_FechaLlegada.Text = IIf(IsDBNull(RowOrden.Item("FechaLlegada")), "  /  /    ", RowOrden.Item("FechaLlegada"))
            Cbx_PagoDespacho.SelectedIndex = IIf(IsDBNull(RowOrden.Item("PagoDespacho")), 0, RowOrden.Item("PagoDespacho"))
            txt_ImpoDespacho.Text = IIf(IsDBNull(RowOrden.Item("ImpoDespacho")), 0, RowOrden.Item("ImpoDespacho"))
            txt_VtoDespacho.Text = IIf(IsDBNull(RowOrden.Item("VtoDespacho")), "  /  /    ", RowOrden.Item("VtoDespacho"))
            cbx_PagoLetra.SelectedIndex = IIf(IsDBNull(RowOrden.Item("PagoLetra")), 0, RowOrden.Item("PagoLetra"))
            cbx_EntregaI.SelectedIndex = IIf(IsDBNull(RowOrden.Item("EntregaI")), 0, RowOrden.Item("EntregaI"))
            cbx_EntregaII.SelectedIndex = IIf(IsDBNull(RowOrden.Item("EntregaII")), 0, RowOrden.Item("EntregaII"))
            txt_ImpoLetra.Text = IIf(IsDBNull(RowOrden.Item("ImpoLetra")), 0, RowOrden.Item("ImpoLetra"))
            txt_VtoLetra.Text = IIf(IsDBNull(RowOrden.Item("VtoLetra")), "  /  /    ", RowOrden.Item("VtoLetra"))
            txt_VtoLetraII.Text = IIf(IsDBNull(RowOrden.Item("VtoLetraII")), "  /  /    ", RowOrden.Item("VtoLetraII"))
        End If

      







        Dim SQLCnlst As String = "Select EntregaI FROM " & BaseConectar & ".dbo.Orden WHERE Orden = '" & NumeroOrden & "'"

        Dim Row As DataRow = GetSingle(SQLCnlst)
        If Row IsNot Nothing Then
            REM BY NAN

            cbx_EntregaI.SelectedIndex = IIf(IsDBNull(Row.Item("EntregaI")), 0, Row.Item("EntregaI"))
        End If
    End Sub

  
    Private Sub btn_FinIngreso_Click(sender As Object, e As EventArgs) Handles btn_FinIngreso.Click

        If txt_FechaLlegada.Text <> "  /  /    " And txt_FechaLlegada.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaLlegada.Text) <> "S" Then
                MsgBox("Fecha de Llegada Invalida", 0, "Actualizacion de Ordenes de Compra")
                Exit Sub

            End If
        End If

        If txt_FechaEmbarque.Text <> "  /  /    " And txt_FechaEmbarque.Text <> "00/00/0000" Then
            If ValidaFecha(txt_FechaEmbarque.Text) <> "S" Then
                MsgBox("Fecha de Embarque Invalida", 0, "Actualizacion de Ordenes de Compra")
                Exit Sub

            End If
        End If

        If txt_VtoLetra.Text <> "  /  /    " And txt_VtoLetra.Text <> "00/00/0000" Then
            If ValidaFecha(txt_VtoLetra.Text) <> "S" Then
                MsgBox("Fecha de Vto. de Letra Invalida", 0, "Actualizacion de Ordenes de Compra")
                Exit Sub

            End If
        End If

        If txt_VtoLetraII.Text <> "  /  /    " And txt_VtoLetraII.Text <> "00/00/0000" Then
            If ValidaFecha(txt_VtoLetraII.Text) <> "S" Then
                MsgBox("Fecha de Vto. Real de Letra Invalida", 0, "Actualizacion de Ordenes de Compra")
                Exit Sub

            End If
        End If
   
        Dim ListaSQLCnslt As New List(Of String)

        Dim SQLCnslt As String = "DELETE ObservaOrden WHERE Carpeta = '" & WCARPETA & "'"

        ListaSQLCnslt.Add(SQLCnslt)
        Dim Renglon As Integer = 0

        For Each DGV_Row As DataGridViewRow In DGV_Observaciones.Rows
            If Trim(DGV_Row.Cells("Fecha").Value) <> "" Or Trim(DGV_Row.Cells("Observaciones").Value) <> "" Then

                Renglon += 1

                Dim CarpetaAux As String = WCARPETA.PadLeft(6, "0")

                Dim RenglonAux As String = Renglon.ToString().PadLeft(2, "0")

                Dim WClave As String = CarpetaAux & RenglonAux

                SQLCnslt = "INSERT INTO ObservaOrden ( " _
                    & "Clave, " _
                    & "Carpeta, " _
                    & "Renglon, " _
                    & "Orden, " _
                    & "Texto1, " _
                    & "Texto2) " _
                    & "VALUES (" _
                    & "'" & WClave & "'" _
                    & "'" & CarpetaAux & "'" _
                    & "'" & RenglonAux & "'" _
                    & "'" & WORDEN & "'" _
                    & "'" & Trim(DGV_Row.Cells("Fecha").Value) & "'" _
                    & "'" & Trim(DGV_Row.Cells("Observaciones").Value) & "')"


                ListaSQLCnslt.Add(SQLCnslt)
            
            End If
        Next


        Dim WTipoPago As String = ""
        Dim WFecha As String = ""

        Dim OrdenAuxi As String = WORDEN.PadLeft(6, "0")

        Dim WClaveORDEN As String = OrdenAuxi + "01"

        SQLCnslt = "SELECT TipoPago, Fecha FROM " & WBASEdeORDEN & ".dbo.Orden WHERE Clave = '" & WClaveORDEN & "'"

        Dim RowOrden As DataRow = GetSingle(SQLCnslt)

        If RowOrden IsNot Nothing Then
            WTipoPago = IIf(IsDBNull(RowOrden.Item("TipoPago")), 0, RowOrden.Item("TipoPago"))
            WFecha = RowOrden.Item("Fecha")
        End If


        If WTipoPago = 1 Then
            txt_VtoLetra.Text = WFecha
        End If
        If WTipoPago = 2 Then
            txt_VtoLetra.Text = txt_FechaLlegada.Text
        End If
        txt_VtoDespacho.Text = txt_FechaLlegada.Text

        Dim WOrdVtoDespacho As String = ordenaFecha(txt_VtoDespacho.Text)
        Dim WOrdVtoLetra As String = ordenaFecha(txt_VtoLetra.Text)
        Dim WOrdVtoLetraII As String = ordenaFecha(txt_VtoLetraII.Text)
        Dim WMarca As String = "X"

        SQLCnslt = "UPDATE " & WBASEdeORDEN & ".dbo.Orden SET " _
                    & "Fecha1 = '" & txt_FechaLlegada.Text & "', " _
                    & "Fecha2 = '" & txt_FechaLlegada.Text & "', " _
                    & "FechaEmbarque   '" & txt_FechaEmbarque.Text & "', " _
                    & "FechaLlegada = '" & txt_FechaLlegada.Text & "', " _
                    & "PagoDespacho = '" & Str$(Cbx_PagoDespacho.SelectedIndex) & "', " _
                    & "ImpoDespacho = '" & txt_ImpoDespacho.Text & "', " _
                    & "VtoDespacho =  '" & txt_VtoDespacho.Text & "', " _
                    & "OrdVtoDespacho = '" & WOrdVtoDespacho & "', " _
                    & "PagoLetra = '" & Str$(cbx_PagoLetra.SelectedIndex) & "', " _
                    & "EntregaI = '" & Str$(cbx_EntregaI.SelectedIndex) & "', " _
                    & "EntregaII = '" & Str$(cbx_EntregaII.SelectedIndex) & "', " _
                    & "ImpoLetra = '" & txt_ImpoLetra.Text & "', " _
                    & "VtoLetra = '" & txt_VtoLetra.Text & "', " _
                    & "VtoLetraII = '" & txt_VtoLetraII.Text & "', " _
                    & "OrdVtoLetra = '" & WOrdVtoLetra & "', " _
                    & "OrdVtoLetraII ='" & WOrdVtoLetraII & "', " _
                    & "Marca = '" & WMarca & "' " _
                    & "Where Orden = '" & WORDEN & "'"

        ListaSQLCnslt.Add(SQLCnslt)

        ExecuteNonQueries(Operador.Base, ListaSQLCnslt.ToArray())

        Close()

    End Sub
End Class