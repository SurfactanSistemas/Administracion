Imports System.ComponentModel
Imports Util.Clases.Query
Public Class Listado_ECheques_Cargacheques

    Dim WCuit As String
    Dim WCliente As String

    Sub New(Optional ByVal Cuit As String = "", Optional ByVal Cliente As String = "")

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WCuit = Cuit
        WCliente = Cliente
        Cargar_Echeques()

    End Sub

    Private Sub Cargar_Echeques()
        Dim SQLCnslt As String
        If WCuit = "" Then
            SQLCnslt = "SELECT Clave, NroCheque, BancoEmisor, Importe, FechaPago, OrdFechaPago, CuitEmisor, Emisor_Razon, " _
                                & "FechaEmisor, OrdFechaEmisor, Caracter_Cheque, Modo_Cheque, Endoso_Documento, Endoso_Razon " _
                                & " FROM Carga_ChequesE " _
                                & "WHERE Marca_usado <> 'X' " _
                                & "ORDER BY OrdFechaPago desc"
        Else
            'CARGO LOS QUE ESTAN ENDOSADOS POR ESE CLIENTE
            SQLCnslt = "SELECT Clave, NroCheque, BancoEmisor, Importe, FechaPago, OrdFechaPago, CuitEmisor, Emisor_Razon, " _
                       & "FechaEmisor, OrdFechaEmisor, Caracter_Cheque, Modo_Cheque, Endoso_Documento, Endoso_Razon " _
                       & "FROM Carga_ChequesE " _
                       & "WHERE 1 =  case when Endoso_Documento <> '' then 1 else 0 end " _
                       & "AND Endoso_Documento = '" & WCuit & "' AND Marca_usado <> 'X' " _
                       & "ORDER BY OrdFechaPago asc"

            Dim TablaEchequesEndosados As DataTable = GetAll(SQLCnslt, "SurfactanSa")

            If TablaEchequesEndosados.Rows.Count > 0 Then
                For Each row As DataRow In TablaEchequesEndosados.Rows
                    With row

                        Dim WClave As String = .Item("Clave")
                        Dim WNroCheque As String = .Item("NroCheque")
                        Dim WBanco As String = .Item("BancoEmisor")
                        Dim WImporte As Double = .Item("Importe")
                        Dim WFechaPago As String = .Item("FechaPago")


                        Dim WCuitEmisor As String = .Item("Endoso_Documento")
                        Dim WRazonEmisor As String = .Item("Endoso_Razon")

                        If WCuitEmisor = "" Then
                            WCuitEmisor = .Item("CuitEmisor")
                            WRazonEmisor = .Item("Emisor_Razon")
                        End If

                        dvg_ECheques.Rows.Add(WClave, WNroCheque, WBanco, WImporte, WFechaPago, WCuitEmisor, WRazonEmisor)

                    End With

                Next
            End If
            'CARGO LOS QUE ESTAN EMITIDOS POR ESE CLIENTE
            SQLCnslt = "SELECT Clave, NroCheque, BancoEmisor, Importe, FechaPago, OrdFechaPago, CuitEmisor, Emisor_Razon, " _
                       & "FechaEmisor, OrdFechaEmisor, Caracter_Cheque, Modo_Cheque, Endoso_Documento, Endoso_Razon " _
                       & "FROM Carga_ChequesE WHERE 1 =  case when Endoso_Documento <> '' then 0 else 1 end AND CuitEmisor = '" & WCuit & "' " _
                       & "AND Marca_usado <> 'X' " _
                       & "ORDER BY OrdFechaPago asc"

        End If


        Dim TablaEcheques As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaEcheques.Rows.Count > 0 Then
            For Each row As DataRow In TablaEcheques.Rows
                With row

                    Dim WClave As String = .Item("Clave")
                    Dim WNroCheque As String = .Item("NroCheque")
                    Dim WBanco As String = .Item("BancoEmisor")
                    Dim WImporte As Double = .Item("Importe")
                    Dim WFechaPago As String = .Item("FechaPago")


                    Dim WCuitEmisor As String = .Item("Endoso_Documento")
                    Dim WRazonEmisor As String = .Item("Endoso_Razon")

                    If WCuitEmisor = "" Then
                        WCuitEmisor = .Item("CuitEmisor")
                        WRazonEmisor = .Item("Emisor_Razon")
                    End If

                    dvg_ECheques.Rows.Add(WClave, WNroCheque, WBanco, WImporte, WFechaPago, WCuitEmisor, WRazonEmisor)

                End With

            Next
        End If

        dvg_ECheques.Sort(FechaPago, ListSortDirection.Ascending)

    End Sub


    Private Sub dvg_ECheques_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dvg_ECheques.MouseDoubleClick

        Dim Wowner As IPaseEcheques = TryCast(Owner, IPaseEcheques)
        If Wowner IsNot Nothing Then
            With dvg_ECheques.CurrentRow
                .DefaultCellStyle.BackColor = Color.DarkCyan
                Dim WBancoEmisor As String = Trim(.Cells("BancoEmisor").Value)
                If WBancoEmisor.Length > 24 Then
                    WBancoEmisor = Microsoft.VisualBasic.Left(WBancoEmisor, 24)
                    WBancoEmisor = _GenerarCodigoBanco(WBancoEmisor)
                Else
                    WBancoEmisor = _GenerarCodigoBanco(WBancoEmisor)
                End If
                Wowner.PasaECheques(.Cells("NroCheque").Value, .Cells("FechaPago").Value, WBancoEmisor, .Cells("Importe").Value, .Cells("Clave").Value)
            End With

        End If
    End Sub

    Private Function _GenerarCodigoBanco(ByVal ZBanco As String) As String
        If WCuit <> "" Then

            Dim Cuit As String = Microsoft.VisualBasic.Left(WCuit, 2) & "-" & Mid(WCuit, 3, 8) & "-" & Microsoft.VisualBasic.Right(WCuit, 1)

            Dim SQLCnslt As String = "SELECT Cliente FROM Cliente WHERE Cuit = '" & Cuit & "'"
            Dim rowCliente As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

            If rowCliente IsNot Nothing Then
                If ZBanco.Trim = "" Then Return ""

                ZBanco = ZBanco.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

                Return ZBanco & "/" & Mid(rowCliente.Item("Cliente"), 1, 1) & Val(Mid(rowCliente.Item("Cliente"), 2, 6)).ToString()
            End If
        Else
            If ZBanco.Trim = "" Then Return ""

            ZBanco = ZBanco.Split("/")(0) ' Agarramos el nombre del banco, sin el cod del cliente.

            Return ZBanco & "/" & Mid(WCliente, 1, 1) & Val(Mid(WCliente, 2, 6)).ToString()
        End If

        Return ""

    End Function

    Private Sub dvg_ECheques_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles dvg_ECheques.SortCompare
        Dim num1, num2

        Select Case e.Column.Index
            Case 3

                num1 = CDbl(e.CellValue1)
                num2 = CDbl(e.CellValue2)

            Case 4

                num1 = ordenaFecha(e.CellValue1)
                num2 = ordenaFecha(e.CellValue2)

            Case Else
                Exit Sub
        End Select

        If num1 < num2 Then
            e.SortResult = -1
        ElseIf num1 = num2 Then
            e.SortResult = 0
        Else
            e.SortResult = 1
        End If

        e.Handled = True
    End Sub
End Class