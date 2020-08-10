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
End Class