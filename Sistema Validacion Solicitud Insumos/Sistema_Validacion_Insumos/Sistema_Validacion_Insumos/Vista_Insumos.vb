Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Vista_Insumos

    Sub New(ByVal NroSolicitud As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txt_NroSoli.Text = NroSolicitud

        CargarDatos()

    End Sub

    Private Sub CargarDatos()
        Dim SQLCnslt As String = "SELECT * FROM Insumos_Provisorios WHERE Solicitud = '" & txt_NroSoli.Text & "' ORDER BY RENGLON"
        Dim TablaInsumos As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaInsumos.Rows.Count > 0 Then

            Dim WFecha, WPlanta, WSolicitante, WFechaEntrega, WObservaciones, WComentarios, WDescripcion As String
            Dim WCantidad As Double

            For Each RowInsumos As DataRow In TablaInsumos.Rows
                With RowInsumos
                    WFecha = IIf(IsDBNull(RowInsumos.Item("Fecha")), "", RowInsumos.Item("Fecha"))
                    WPlanta = IIf(IsDBNull(RowInsumos.Item("Planta")), "", RowInsumos.Item("Planta"))
                    WSolicitante = IIf(IsDBNull(RowInsumos.Item("Solicitante")), "", RowInsumos.Item("Solicitante"))
                    WFechaEntrega = IIf(IsDBNull(RowInsumos.Item("Entrega")), "", RowInsumos.Item("Entrega"))
                    WObservaciones = IIf(IsDBNull(RowInsumos.Item("Observaciones")), "", RowInsumos.Item("Observaciones"))

                    WComentarios = IIf(IsDBNull(RowInsumos.Item("Observaciones1")), "", RowInsumos.Item("Observaciones1")) _
                                & IIf(IsDBNull(RowInsumos.Item("Observaciones2")), "", RowInsumos.Item("Observaciones2")) _
                                & IIf(IsDBNull(RowInsumos.Item("Observaciones3")), "", RowInsumos.Item("Observaciones3")) _
                                & IIf(IsDBNull(RowInsumos.Item("Observaciones4")), "", RowInsumos.Item("Observaciones4")) _
                                & IIf(IsDBNull(RowInsumos.Item("Observaciones5")), "", RowInsumos.Item("Observaciones5")) _
                                & IIf(IsDBNull(RowInsumos.Item("Observaciones6")), "", RowInsumos.Item("Observaciones6")) _
                                & IIf(IsDBNull(RowInsumos.Item("Observaciones7")), "", RowInsumos.Item("Observaciones7"))
                    If WComentarios.Replace(" ", "") = "" Then
                        WComentarios = Trim(WComentarios)
                    Else
                        WComentarios = RTrim(WComentarios)
                    End If

                    cbx_Tipo.SelectedIndex = IIf(IsDBNull(RowInsumos.Item("TipoSolicitud")), 0, RowInsumos.Item("TipoSolicitud"))

                End With

                txt_Fecha.Text = WFecha
                txt_Planta.Text = WPlanta
                txt_Solicitante.Text = WSolicitante
                txt_FechaEntrega.Text = WFechaEntrega
                txt_Observaciones.Text = WObservaciones
                txt_Comentarios.Text = WComentarios

                WCantidad = IIf(IsDBNull(RowInsumos.Item("Cantidad")), 0, RowInsumos.Item("Cantidad"))
                WDescripcion = IIf(IsDBNull(RowInsumos.Item("Descripcion")), "", RowInsumos.Item("Descripcion"))

                dgv_Insumos.Rows.Add(WCantidad, WDescripcion)
            Next
        End If

    End Sub

   
    Private Sub btn_Rechazar_Click(sender As Object, e As EventArgs) Handles btn_Rechazar.Click
        If MsgBox("¿Esta seguro que desea rechazar esta solicitud?", vbYesNo) = vbYes Then
            Dim SQLCnslt As String = "UPDATE Insumos_Provisorios SET EstadoPedido = 'Rechazado' WHERE Solicitud = '" & txt_NroSoli.Text & "'"
            Try
                ExecuteNonQueries("SurfactanSa", SQLCnslt)
                MsgBox("Se rechazo la solicitud con exito.", vbInformation)
                Dim Wowner As IActualizaGrilla = TryCast(Owner, IActualizaGrilla)
                If Wowner IsNot Nothing Then
                    Wowner.ActualizarGrilla()
                End If
                Close()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click


        Dim SQLCnslt As String = ""

        Dim ListaSQLCnslt As New List(Of String)
        
        Dim WObservaciones1, WObservaciones2, WObservaciones3, WObservaciones4, WObservaciones5, WObservaciones6, WObservaciones7 As String
        txt_Comentarios.Text = txt_Comentarios.Text.PadRight(350, " ")
        WObservaciones1 = txt_Comentarios.Text.Substring(0, 50)
        WObservaciones2 = txt_Comentarios.Text.Substring(50, 50)
        WObservaciones3 = txt_Comentarios.Text.Substring(100, 50)
        WObservaciones4 = txt_Comentarios.Text.Substring(150, 50)
        WObservaciones5 = txt_Comentarios.Text.Substring(200, 50)
        WObservaciones6 = txt_Comentarios.Text.Substring(250, 50)
        WObservaciones7 = txt_Comentarios.Text.Substring(300, 50)

        Dim Renglon As Integer = 1

        Dim Woperador As Integer

        Dim CantidadRegistrosEnBase As Integer = 0
        SQLCnslt = "SELECT Operador FROM Insumos_Provisorios WHERE Solicitud = '" & txt_NroSoli.Text & "'"
        Dim TablaContar As DataTable = GetAll(SQLCnslt, "SurfactanSa")
        If TablaContar.Rows.Count > 0 Then
            Woperador = TablaContar.Rows(0).Item("Operador")
            CantidadRegistrosEnBase = TablaContar.Rows.Count
        End If

        If (dgv_Insumos.Rows.Count - 1) = CantidadRegistrosEnBase Then
            For Each dgvRow As DataGridViewRow In dgv_Insumos.Rows
                'SI CANTIDAD O DESCRIPCION ESTA VACIO NO GUARDAMOS EL RENGLON
                If Val(dgvRow.Cells("Cantidad").Value) = 0 Or dgvRow.Cells("Descripcion").Value = "" Then
                    Continue For
                End If
                SQLCnslt = "UPDATE Insumos_Provisorios SET Cantidad = '" & dgvRow.Cells("Cantidad").Value & "', " _
                         & "Descripcion = '" & dgvRow.Cells("Descripcion").Value & "', " _
                         & "Observaciones1 = '" & WObservaciones1 & "', " _
                         & "Observaciones2 = '" & WObservaciones2 & "', " _
                         & "Observaciones3 = '" & WObservaciones3 & "', " _
                         & "Observaciones4 = '" & WObservaciones4 & "', " _
                         & "Observaciones5 = '" & WObservaciones5 & "', " _
                         & "Observaciones6 = '" & WObservaciones6 & "', " _
                         & "Observaciones7 = '" & WObservaciones7 & "' " _
                         & "WHERE Solicitud = '" & txt_NroSoli.Text & "' AND Renglon = '" & Renglon & "'"

                ListaSQLCnslt.Add(SQLCnslt)
                Renglon += 1
            Next
        Else
            SQLCnslt = "DELETE FROM Insumos_Provisorios WHERE Solicitud = '" & txt_NroSoli.Text & "'"
            ListaSQLCnslt.Add(SQLCnslt)
            For Each dgvRow As DataGridViewRow In dgv_Insumos.Rows
                'SI CANTIDAD O DESCRIPCION ESTA VACIO NO GUARDAMOS EL RENGLON
                If Val(dgvRow.Cells("Cantidad").Value) = 0 Or dgvRow.Cells("Descripcion").Value = "" Then
                    Continue For
                End If
                Dim AuxClave1 As String = txt_NroSoli.Text.PadLeft(6, "0")
                Dim AuxClave2 As String = Renglon.ToString().PadLeft(2, "0")
                Dim WClave As String = AuxClave1 & AuxClave2


                SQLCnslt = "INSERT INTO Insumos_Provisorios(Clave, Solicitud, Renglon, Fecha, OrdFecha, Planta, " _
                           & "Solicitante, Observaciones, Entrega, OrdEntrega, Cantidad, Descripcion, " _
                           & " Observaciones1, Observaciones2, Observaciones3, Observaciones4, Observaciones5, Observaciones6, Observaciones7, " _
                           & "EstadoItem, TipoSolicitud, Operador, EstadoPedido) " _
                           & "VALUES(" _
                           & "'" & WClave & "', " _
                           & "'" & txt_NroSoli.Text & "', " _
                           & "'" & Renglon & "', " _
                           & "'" & txt_Fecha.Text & "', " _
                           & "'" & ordenaFecha(txt_Fecha.Text) & "', " _
                           & "'" & txt_Planta.Text & "', " _
                           & "'" & txt_Solicitante.Text & "', " _
                           & "'" & txt_Observaciones.Text & "', " _
                           & "'" & txt_FechaEntrega.Text & "', " _
                           & "'" & ordenaFecha(txt_FechaEntrega.Text) & "', " _
                           & "'" & dgvRow.Cells("Cantidad").Value & "', " _
                           & "'" & dgvRow.Cells("Descripcion").Value & "', " _
                           & "'" & WObservaciones1 & "', " _
                           & "'" & WObservaciones2 & "', " _
                           & "'" & WObservaciones3 & "', " _
                           & "'" & WObservaciones4 & "', " _
                           & "'" & WObservaciones5 & "', " _
                           & "'" & WObservaciones6 & "', " _
                           & "'" & WObservaciones7 & "', " _
                           & "'" & "" & "', " _
                           & "'" & cbx_Tipo.SelectedIndex & "', " _
                           & "'" & Woperador & "', " _
                           & "'" & "Pendiente" & "' " _
                           & ")"
                

                ListaSQLCnslt.Add(SQLCnslt)
                Renglon += 1
            Next
        End If
        

        Try
            ExecuteNonQueries("SurfactanSa", ListaSQLCnslt.ToArray())
            Dim Wowner As IActualizaGrilla = TryCast(Owner, IActualizaGrilla)
            If Wowner IsNot Nothing Then
                Wowner.ActualizarGrilla()
            End If

            If MsgBox("¿Desea enviar un mail de aviso?", vbYesNo) = vbYes Then
                With New Mail_Modificacion(txt_NroSoli.Text)
                    .Show()
                End With

            End If

            Close()
        Catch ex As Exception
            MsgBox("No se pudo actualizar la base de datos", vbExclamation)
        End Try

    End Sub

    Private Sub btn_Autorizar_Click(sender As Object, e As EventArgs) Handles btn_Autorizar.Click
        If MsgBox("¿Desea autorizar esta solicitud?", vbYesNo) = vbYes Then
            Dim SQLCnslt As String = "UPDATE Insumos_Provisorios SET EstadoPedido = 'Autorizado' WHERE Solicitud = '" & txt_NroSoli.Text & "'"
            Try
                GrabarEnElOficial()
                ExecuteNonQueries("SurfactanSa", SQLCnslt)
                MsgBox("Se autorizo la solicitud con exito.", vbInformation)
                Dim Wowner As IActualizaGrilla = TryCast(Owner, IActualizaGrilla)
                If Wowner IsNot Nothing Then
                    Wowner.ActualizarGrilla()
                End If
                Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub GrabarEnElOficial()


        Dim WFecha As String = txt_Fecha.Text
        Dim WOrdFecha As String = ordenaFecha(txt_Fecha.Text)
        Dim WPlanta As String = txt_Planta.Text
        Dim WSolicitante As String = txt_Solicitante.Text
        Dim WObservaciones As String = txt_Observaciones.Text
        Dim WEntrega As String = txt_FechaEntrega.Text
        Dim WOrdEntrega As String = ordenaFecha(txt_FechaEntrega.Text)
        Dim WEstado As Integer = 0
        Dim WEstado1 As String = ""
        Dim WEstado2 As String = ""
        Dim WEstado3 As String = ""
        Dim WEstado4 As String = ""
        Dim WEstado5 As String = ""
        Dim WEstado6 As String = ""
        txt_Comentarios.Text = txt_Comentarios.Text.PadRight(350, " ")
        Dim WRespuesta1 As String = txt_Comentarios.Text.Substring(0, 50)
        Dim WRespuesta2 As String = txt_Comentarios.Text.Substring(50, 50)
        Dim WRespuesta3 As String = txt_Comentarios.Text.Substring(100, 50)
        Dim WRespuesta4 As String = txt_Comentarios.Text.Substring(150, 50)
        Dim WRespuesta5 As String = txt_Comentarios.Text.Substring(200, 50)
        Dim WRespuesta6 As String = txt_Comentarios.Text.Substring(250, 50)
        Dim WRespuesta7 As String = txt_Comentarios.Text.Substring(300, 50)
        txt_Comentarios.Text = RTrim(txt_Comentarios.Text)
        Dim WEstadoItem As String = ""
        Dim WTipoSolicitud As Integer = cbx_Tipo.SelectedIndex
        Dim WOperador As Integer = Util.Operador.Codigo
        Dim WResponsable As String = ""
        Dim WFechaCompra As String = ""
        Dim WFechaCompraOrd As String = ""



        Dim ListaSQLCnslt As New List(Of String)

        Dim AuxClave1 As String = ""
        Dim AuxClave2 As String = ""
        Dim MaxNumero As String = ""

        Dim SQlCnlst As String = "SELECT MaxSolicitud = max(Solicitud) fROM Insumos"
        Try
            Dim RowInsumos As DataRow = GetSingle(SQlCnlst, "SurfactanSa")
            If RowInsumos IsNot Nothing Then
                MaxNumero = RowInsumos.Item("Maxsolicitud") + 1
            End If
        Catch ex As Exception
            MsgBox("Hubo un error al querer consultar el nuevo numero de solicitud para la tabla Insumos", vbExclamation)
            Exit Sub
        End Try

        

        If MaxNumero <> "" Then
            AuxClave1 = MaxNumero.PadLeft(6, "0")
            Dim Renglon As Integer = 1
            For Each dgvRow As DataGridViewRow In dgv_Insumos.Rows
                AuxClave2 = Renglon.ToString().PadLeft(2, "0")
                Dim WClave As String = AuxClave1 & AuxClave2
                Dim WSolicitud As Integer = Val(AuxClave1)

                Dim WCantidad As Double = dgvRow.Cells("Cantidad").Value
                Dim WDescripcion As String = dgvRow.Cells("Descripcion").Value
                
                SQlCnlst = "INSERT INTO Insumos(Clave, Solicitud, Renglon, Fecha, OrdFecha, Planta, " _
                            & "Solicitante, Observaciones, Entrega, OrdEntrega, Cantidad, Descripcion, " _
                            & "Estado, Estado1, Estado2, Estado3, Estado4, Estado5, Estado6, Respuesta1, " _
                            & "Respuesta2, Respuesta3, Respuesta4, Respuesta5, Respuesta6, Respuesta7, " _
                            & "EstadoItem, TipoSolicitud, Operador, Responsable, FechaCompra, FechaCompraOrd) " _
                            & "VALUES(" _
                            & "'" & WClave & "', " _
                            & "'" & WSolicitud & "', " _
                            & "'" & Renglon & "', " _
                            & "'" & WFecha & "', " _
                            & "'" & WOrdFecha & "', " _
                            & "'" & WPlanta & "', " _
                            & "'" & WSolicitante & "', " _
                            & "'" & WObservaciones & "', " _
                            & "'" & WEntrega & "', " _
                            & "'" & WOrdEntrega & "', " _
                            & "'" & WCantidad & "', " _
                            & "'" & WDescripcion & "', " _
                            & "'" & WEstado & "', " _
                            & "'" & WEstado1 & "', " _
                            & "'" & WEstado2 & "', " _
                            & "'" & WEstado3 & "', " _
                            & "'" & WEstado4 & "', " _
                            & "'" & WEstado5 & "', " _
                            & "'" & WEstado6 & "', " _
                            & "'" & WRespuesta1 & "', " _
                            & "'" & WRespuesta2 & "', " _
                            & "'" & WRespuesta3 & "', " _
                            & "'" & WRespuesta4 & "', " _
                            & "'" & WRespuesta5 & "', " _
                            & "'" & WRespuesta6 & "', " _
                            & "'" & WRespuesta7 & "', " _
                            & "'" & WEstadoItem & "', " _
                            & "'" & WTipoSolicitud & "', " _
                            & "'" & WOperador & "', " _
                            & "'" & WResponsable & "', " _
                            & "'" & WFechaCompra & "', " _
                            & "'" & WFechaCompraOrd & "' " _
                            & ")"

                ListaSQLCnslt.Add(SQlCnlst)
                'AUMENTO EL RENGLON PARA GENERAR BIEN EL SIGUIENTE CLAVE Y RENGLON
                Renglon += 1

            Next

            Try

                ExecuteNonQueries("SurfactanSa", ListaSQLCnslt.ToArray())

            Catch ex As Exception
                MsgBox("Hubo un error al querer grabar el registro en la tabla insumos tabla Insumos", vbExclamation)
                Exit Sub
            End Try




        End If
    End Sub

    Private Sub dgv_Insumos_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Insumos.RowHeaderMouseDoubleClick
        If dgv_Insumos.SelectedRows.Count > 0 Then

            If MsgBox("¿Desea eliminar la fila seleccionada?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
                Dim row As DataGridViewRow = dgv_Insumos.CurrentRow
                Try
                    dgv_Insumos.Rows.Remove(row)

                    If dgv_Insumos.RowCount = 0 Then
                        dgv_Insumos.Rows.Add()
                    End If
                Catch ex As Exception

                End Try
                
            Else
                dgv_Insumos.ClearSelection()
            End If

        End If
    End Sub
End Class