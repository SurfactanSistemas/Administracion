Public Class MostrarSoliFondos


    Sub New(ByVal NroSoli As Integer, ByVal Paridad As Double)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        Dim SQLCnlst As String = "SELECT s.NroSolicitud, s.Solicitante, Tipo = IIF(s.Tipo = 1, 'Pago Prov.',  'Varios'), " _
                                 & "Destino = IIF(s.Proveedor = '',c.Descripcion, p.Nombre), s.Titulo, s.Concepto, " _
                                 & "Moneda = IIF(s.Moneda = 2, 'U$D',  '$'), s.Importe, s.Proveedor, s.Cuenta, " _
                                 & "Efectivo_Chk, Transferencia_Chk, ECheq_Chk , CheqTerceros_Chk " _
                                 & "FROM SolicitudFondos s LEFT JOIN Proveedor p ON s.Proveedor = p.Proveedor " _
                                 & "LEFT JOIN Cuenta c ON s.Cuenta = c.Cuenta WHERE s.NroSolicitud = '" & NroSoli & "'   ORDER BY s.NroSolicitud"

        Dim RowSoli As DataRow = GetSingle(SQLCnlst, "SurfactanSa")

        If RowSoli IsNot Nothing Then
            With RowSoli

                txt_NroSolicitud.Text = .Item("NroSolicitud")
                txt_Solicitante.Text = .Item("Solicitante")
                If (Trim(.Item("Proveedor")) = "") Then
                    txt_Destino.Text = .Item("Cuenta")
                Else
                    txt_Destino.Text = .Item("Proveedor")
                End If
                txt_DescripDestino.Text = .Item("Destino")
                If .Item("Moneda") = "U$D" Then
                    Label9.Visible = True
                    txt_Paridad.Visible = True
                    txt_Paridad.Text = formatonumerico(Paridad)
                    txt_Importe.Text = formatonumerico(.Item("Importe"))
                    Dim Total As Double = .Item("Importe") * Paridad
                    txt_ImporteTotal.Text = formatonumerico(Total)
                Else
                    Label6.Visible = False
                    txt_Importe.Visible = False
                    txt_ImporteTotal.Text = formatonumerico(.Item("Importe"))

                End If

                txt_Detalle.Text = .Item("Concepto")

                If .Item("Efectivo_Chk") Then
                    dgv_FormasPago.Rows.Add("Efectivo")
                End If
                If .Item("Transferencia_Chk") Then
                    dgv_FormasPago.Rows.Add("Transferencia")
                End If
                If .Item("CheqTerceros_Chk") Then
                    dgv_FormasPago.Rows.Add("Cheques de Terceros")
                End If
                If .Item("ECheq_Chk") Then
                    dgv_FormasPago.Rows.Add("Cheques Electronicos")
                End If
                
            End With
        End If

    End Sub
End Class