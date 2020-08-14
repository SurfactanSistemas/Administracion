Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Public Class Centro_Importaciones_CarpetasPendientes

    Dim tablaResivida As New DataTable

    Sub New(ByVal Tabla As DataTable)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        With tablaResivida.Columns
            .Add("Orden")
            .Add("Carpeta")
            .Add("Proveedor")
            .Add("FechaInforme")
            .Add("Empresa")
        End With

        Dim fila As Integer = 0
        For Each row As DataRow In Tabla.Rows
            tablaResivida.Rows.Add()
            tablaResivida.Rows(fila).Item("Orden") = row.Item("Orden")
            tablaResivida.Rows(fila).Item("Carpeta") = row.Item("Carpeta")
            tablaResivida.Rows(fila).Item("Proveedor") = row.Item("Proveedor")
            tablaResivida.Rows(fila).Item("FechaInforme") = row.Item("FechaInforme")
            tablaResivida.Rows(fila).Item("Empresa") = row.Item("Empresa")



        Next








    End Sub




    Private Sub Centro_Importaciones_CarpetasPendientes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Dim fila As Integer = 0
        For Each row As DataRow In tablaResivida.Rows

            With row
                'CONSULTAR GASTON
                Dim WOrden As String = IIf(IsDBNull(.Item("Orden")), "Nulo", .Item("Orden"))
                If WOrden = "Nulo" Then
                    Continue For
                End If

                Dim WCarpeta As String = .Item("Carpeta")
                Dim WCodProveedor As String = .Item("Proveedor")
                Dim WNombreProveedor As String = ""
                Dim WFechaInforme As String = .Item("FechaInforme")
                Dim WEmpresa As String = .Item("Empresa")

                Dim WAno As String = Microsoft.VisualBasic.Right$(.Item("FechaInforme"), 4)
                Dim WMes As String = Mid$(.Item("FechaInforme"), 4, 2)
                Dim WDia As String = Microsoft.VisualBasic.Left$(.Item("FechaInforme"), 2)
                Dim WFechaInformeOrd As String = WAno & WMes & WDia

                DGV_Pendientes.Rows.Add()
                DGV_Pendientes.Rows(fila).Cells("Orden").Value = WOrden
                DGV_Pendientes.Rows(fila).Cells("Carpeta").Value = WCarpeta
                DGV_Pendientes.Rows(fila).Cells("CodProveedor").Value = WCodProveedor
                DGV_Pendientes.Rows(fila).Cells("NombreProveedor").Value = WNombreProveedor
                DGV_Pendientes.Rows(fila).Cells("FechaInforme").Value = WFechaInforme
                DGV_Pendientes.Rows(fila).Cells("Empresa").Value = WEmpresa
                DGV_Pendientes.Rows(fila).Cells("FechaOrd").Value = WFechaInformeOrd


                fila += 1
            End With

        Next

        'ORDENA POR FECHA ORD
        'DGV_Pendientes.ColumnHeaderMouseClick(DGV_Pendientes.Columns("FechaOrd"), Nothing)

        If DGV_Pendientes.Rows.Count > 0 Then
            For Each DGVPen_Row As DataGridViewRow In DGV_Pendientes.Rows

                Dim ZZProveedor As String = DGVPen_Row.Cells("CodProveedor").Value
                Dim SQLCnlst As String = "SELECT Nombre" _
                                        & " FROM Proveedor" _
                                        & " WHERE Proveedor = '" & ZZProveedor & "'"
                Dim RowProv As DataRow = GetSingle(SQLCnlst, Operador.Base)

                If RowProv IsNot Nothing Then
                    DGVPen_Row.Cells("NombreProveedor").Value = RowProv.Item("Nombre")
                End If

            Next

        End If


    End Sub

    Private Sub btn_CerrarP_Click(sender As Object, e As EventArgs) Handles btn_CerrarP.Click
        Close()
    End Sub

    Private Sub btn_Impresion_Click(sender As Object, e As EventArgs) Handles btn_Impresion.Click




        Dim SQLCnlst As String = "DELETE ControlImpoImpre"

        ExecuteNonQueries({SQLCnlst}, Operador.Base)

        Dim ListaSQLCnslt As New List(Of String)

        For Each DGVRow As DataGridViewRow In DGV_Pendientes.Rows

            Dim WOrden As String = DGVRow.Cells("orden").Value
            Dim WCarpeta As String = DGVRow.Cells("Carpeta").Value
            Dim WProveedor As String = DGVRow.Cells("NombreProveedor").Value
            Dim WFecha As String = DGVRow.Cells("FechaInforme").Value

            Dim WEmpresa As String
            Select Case UCase(DGVRow.Cells("Empresa").Value)
                Case "SURFACTANSA"
                    WEmpresa = "I"
                Case "SURFACTAN_II"
                    WEmpresa = "II"
                Case "SURFACTAN_III"
                    WEmpresa = "III"
                Case "SURFACTAN_V"
                    WEmpresa = "V"
                Case "SURFACTAN_VI"
                    WEmpresa = "VI"
                Case "SURFACTAN_VII"
                    WEmpresa = "VII"

            End Select


            Dim ZOrden As String = WOrden
            Dim ZPta As String = WEmpresa
            Dim ZFecha As String = WFecha
            Dim ZProveedor As String = WProveedor
            Dim ZMoneda As String = ""
            Dim ZCarpeta As String = WCarpeta
            Dim ZDJai As String = ""
            Dim ZOrigen As String = ""
            Dim ZIncoterms As String = ""
            Dim ZTransporte As String = ""
            Dim ZFLLegada As String = ""
            Dim ZTPago As String = ""
            Dim ZDespacho As String = ""
            Dim ZPagoDespacho As String = ""
            Dim ZLetra As String = ""
            Dim ZPagoLetra As String = ""
            Dim ZVtoLetra As String = ""
            Dim ZPagoParcial As String = ""
            Dim ZFEmbarque As String = ""

            Dim ZSumaI As String = DGV_Pendientes.Rows.Count.ToString()
            Dim ZSumaII As String = ""



            SQLCnlst = "INSERT INTO ControlImpoImpre (" _
            & "Orden ," _
            & "Pta ," _
            & "Fecha ," _
            & "Proveedor ," _
            & "Moneda ," _
            & "Carpeta ," _
            & "Djai ," _
            & "Origen ," _
            & "Incoterms ," _
            & "Transporte," _
            & "FLLegada  ," _
            & "TPago ," _
            & "SumaI ," _
            & "SumaII ," _
            & "Despacho ," _
            & "PagoDespacho ," _
            & "Letra ," _
            & "PagoLetra ," _
            & "VtoLetra ," _
            & "PagoParcial ," _
            & "FEmbarque) " _
            & "Values (" _
            & "'" & ZOrden & "'," _
            & "'" & ZPta & "'," _
            & "'" & ZFecha & "'," _
            & "'" & ZProveedor & "'," _
            & "'" & ZMoneda & "'," _
            & "'" & ZCarpeta & "'," _
            & "'" & ZDJai & "'," _
            & "'" & ZOrigen & "'," _
            & "'" & ZIncoterms & "'," _
            & "'" & ZTransporte & "'," _
            & "'" & ZFLLegada & "'," _
            & "'" & ZTPago & "'," _
            & "'" & ZSumaI & "'," _
            & "'" & ZSumaII & "'," _
            & "'" & ZDespacho & "'," _
            & "'" & ZPagoDespacho & "'," _
            & "'" & ZLetra & "'," _
            & "'" & ZPagoLetra & "'," _
            & "'" & ZVtoLetra & "'," _
            & "'" & ZPagoParcial & "'," _
            & "'" & ZFEmbarque & "')"

            ListaSQLCnslt.Add(SQLCnlst)
        Next

        If ListaSQLCnslt.Count > 0 Then
            ExecuteNonQueries(ListaSQLCnslt.ToArray(), Operador.Base)
            With New VistaPrevia
                .Reporte = New Reporte_CentroDe_Exportacion_Pendientes()

                .Mostrar()
            End With

        End If

    End Sub

    Private Sub DGV_Pendientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Pendientes.CellMouseDoubleClick

        Dim Worden As String = DGV_Pendientes.CurrentRow.Cells("Orden").Value
        Dim WCarpeta As String = DGV_Pendientes.CurrentRow.Cells("Carpeta").Value
        Dim WPlanta As String = DGV_Pendientes.CurrentRow.Cells("Empresa").Value

        Dim WEmpresa As String = ""
        Select Case WPlanta
            Case "I"
                WEmpresa = "SurfactanSa"
            Case "II"
                WEmpresa = "Surfactan_II"
            Case "III"
                WEmpresa = "Surfactan_III"
            Case "V"
                WEmpresa = "Surfactan_V"
            Case "VI"
                WEmpresa = "Surfactan_VI"
            Case "VII"
                WEmpresa = "Surfactan_VII"
        End Select


        With New Ingreso_OrdenCompra(Worden, WCarpeta, WPlanta)
            .Show()
        End With

    End Sub
End Class