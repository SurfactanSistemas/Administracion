Imports System.Data.SqlClient
Imports Inventario.Clases

Public Class IngresoTalonInventario

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dgvTalones.Rows.Clear()
        txtNroMovimiento.Text = ""
        txtNroMovimiento.Focus()
    End Sub

    Private Sub IngresoTalonInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub IngresoTalonInventario_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtNroMovimiento.Focus()
    End Sub

    Private Sub txtNroMovimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroMovimiento.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtNroMovimiento.Text) = "" Then : Exit Sub : End If

            If Not _ExisteMovimiento(txtNroMovimiento.Text) Then
                dgvTalones.Rows.Clear()
                Exit Sub
            End If

            _CargarMovimiento(txtnromovimiento.Text)

        ElseIf e.KeyData = Keys.Escape Then
            txtNroMovimiento.Text = ""
        End If

    End Sub

    Private Sub _CargarMovimiento(ByVal s As String)

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Talon, Tipo, Articulo, Terminado, Cantidad, Lote, Ubicacion, Observaciones FROM Inventario WHERE Numero = '" & s & "' ORDER BY Talon")
        Dim dr As SqlDataReader
        Dim row As Integer = 0

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Dim WMovimiento = txtNroMovimiento.Text

            btnLimpiar_Click(Nothing, Nothing)

            If dr.HasRows Then

                txtNroMovimiento.Text = WMovimiento

                Do While dr.Read()

                    row = dgvTalones.Rows.Add

                    With dgvTalones.Rows(row)

                        .Cells("Talon").Value = dr.Item("Talon")
                        .Cells("Tipo").Value = dr.Item("Tipo")
                        .Cells("Articulo").Value = dr.Item("Articulo")
                        .Cells("Terminado").Value = dr.Item("Terminado")
                        .Cells("Cantidad").Value = dr.Item("Cantidad")
                        .Cells("Lote").Value = dr.Item("Lote")
                        .Cells("Ubicacion").Value = dr.Item("Ubicacion")
                        .Cells("Observaciones").Value = dr.Item("Observaciones")

                    End With

                Loop

                With dgvTalones
                    row = .Rows.Add()
                    .CurrentCell = .Rows(row).Cells("Talon")
                    .Focus()
                End With

            End If

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _ExisteMovimiento(ByVal s As String) As Boolean
        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Numero FROM Inventario WHERE Numero = '" & s & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del movimiento en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Sub dgvTalones_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTalones.RowHeaderMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        If MsgBox("¿Está seguro de eliminar la fila seleccionada?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub

        With dgvTalones

            .Rows.Remove(.Rows(e.RowIndex))

            Dim I = IIf(.Rows.Count < 1, .Rows.Add, .Rows.Count - 1)

            .CurrentCell = .Rows(I).Cells("Talon")

            .Focus()

        End With

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("")
        Dim dr As SqlDataReader
        Dim trans As SqlTransaction = Nothing

        Try

            cn.ConnectionString = Helper._ConectarA(Conexion.EmpresaDeTrabajo)
            cn.Open()
            trans = cn.BeginTransaction

            cm.Connection = cn
            cm.Transaction = trans

            cm.CommandText = "DELETE FROM Inventario WHERE Numero = '" & txtNroMovimiento.Text & "'"
            cm.ExecuteNonQuery()

            Dim WRenglon = 0

            For Each row As DataGridViewRow In dgvTalones.Rows

                With row

                    Dim WTalon As String = If(.Cells("Talon").Value, "")
                    Dim WTipo As String = If(.Cells("Tipo").Value, "")
                    Dim WTerminado As String = If(.Cells("Terminado").Value, "")
                    Dim WArticulo As String = If(.Cells("Articulo").Value, "")
                    Dim WCantidad As String = If(.Cells("Cantidad").Value, "")
                    Dim WLote As String = If(.Cells("Lote").Value, "")
                    Dim WUbicacion As String = If(.Cells("Ubicacion").Value, "")
                    Dim WObservaciones As String = If(.Cells("Observaciones").Value, "")
                    Dim WPartida As String = ""


                    If Val(WTalon) = 0 Then Continue For

                    If Trim(WTipo) = "" Or Not {"M", "T"}.Contains(UCase(WTipo)) Then
                        MsgBox("Debe especificarse el tipo de Producto en el talón " & WTalon)
                        Exit Sub
                    End If

                    Select Case UCase(WTipo.trim)
                        Case "M"
                            
                            If WArticulo.Replace("-", "").Trim = "" Or Not _ExisteArticulo(WArticulo) Then
                                MsgBox("Debe especificarse el Artículo en el talón " & WTalon)
                                Exit Sub
                            End If

                            If {"DY", "DW", "DS"}.Contains(WArticulo.Substring(0, 2).ToUpper) Then

                                WPartida = WLote

                                cm.CommandText = "SELECT Laudo FROM Laudo WHERE Codigo  = '" & WArticulo & "' AND PartiOri = '" & WLote & "'"

                                Using dr2 = cm.ExecuteReader

                                    If dr2.HasRows Then
                                        dr2.Read()

                                        WLote = dr2.Item("Laudo")
                                    Else
                                        If Not dr2.IsClosed Then dr2.Close()

                                        cm.CommandText = "SELECT Lote FROM Guia WHERE Articulo = '" & WArticulo & "' AND PartiOri = '" & WLote & "'"

                                        Using dr3 As SqlDataReader = cm.ExecuteReader

                                            If dr3.HasRows Then
                                                dr3.Read()
                                                WLote = dr2.Item("Lote")
                                            End If

                                        End Using


                                    End If

                                End Using

                            End If

                        Case "T"

                            If WTerminado.Replace("-", "").Trim = "" Or Not _ExisteTerminado(WTerminado) Then
                                MsgBox("Debe especificarse el Producto Terminado en el talón " & WTalon)
                                Exit Sub
                            End If

                        Case Else
                            Exit Sub
                    End Select

                    If Val(WCantidad) = 0 Then
                        MsgBox("Debe especificarse el la cantidad del Producto en el talón " & WTalon)
                        Exit Sub
                    End If

                    If WTipo = "M" Then

                        If Not _ExisteLaudo(WArticulo, WLote) Then
                            MsgBox("Debe especificarse un Lote válido para el Articulo en el talón " & WTalon)
                            Exit Sub
                        End If

                    ElseIf WTipo = "T" Then

                        If Not _ExisteHoja(WTerminado, WLote) Then
                            MsgBox("Debe especificarse un Lote válido para el Producto Terminado en el talón " & WTalon)
                            Exit Sub
                        End If

                    End If

                    WUbicacion = Trim(WUbicacion)
                    WObservaciones = Trim(WObservaciones)
                    WCantidad = Helper.formatonumerico(WCantidad)

                    '
                    ' Ya validado los valores, guardamos la fila.
                    '
                    WRenglon += 1

                    Dim WClave = ""

                    WClave = txtNroMovimiento.Text.Trim.PadLeft(6, "0") & WRenglon.ToString.PadLeft(2, "0")

                    Dim ZSQL As String = ""

                    ZSQL = String.Format("INSERT INTO Inventario (Clave, Numero, Renglon, Tipo, Articulo, Terminado, Cantidad, Lote, Talon, Observaciones, Ubicacion, Partida)" &
                                         " VALUES " &
                                         " ('{0}', {1}, {2}, '{3}', '{4}', '{5}', {6}, {7}, {8}, '{9}', '{10}', '{11}')",
                                         WClave, txtNroMovimiento.Text, WRenglon, WTipo, WArticulo, WTerminado, WCantidad, WLote, WTalon, WObservaciones, WUbicacion, WPartida)
                    cm.CommandText = ZSQL
                    cm.ExecuteNonQuery()

                End With

            Next

            trans.Commit()

            btnLimpiar.PerformClick()

        Catch ex As Exception

            If Not IsNothing(trans) AndAlso Not IsNothing(trans.Connection) Then trans.Rollback()

            MsgBox("Hubo un problema al querer guardar el Movimiento en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)

        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Function _ExisteHoja(ByVal wTerminado As String, ByVal wLote As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Hoja FROM Hoja WHERE Hoja = '" & wLote & "' AND Producto = '" & wTerminado & "' ")
        Dim dr As SqlDataReader

        Try

            For Each emp As String In Conexion.Empresas

                If cn.IsOpened Then cn.Close()

                cn.ConnectionString = Helper._ConectarA(emp)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    Return True
                End If

            Next

            Return False

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Laudo " & wLote & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try
    End Function

    Private Function _ExisteLaudo(ByVal wArticulo As String, ByVal wLote As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Laudo FROM Laudo WHERE Laudo = '" & wLote & "' AND Articulo = '" & wArticulo & "' ")
        Dim dr As SqlDataReader

        Try

            For Each emp As String In Conexion.Empresas

                If cn.IsOpened Then cn.Close()

                cn.ConnectionString = Helper._ConectarA(emp)
                cn.Open()
                cm.Connection = cn

                dr = cm.ExecuteReader()

                If dr.HasRows Then
                    Return True
                End If

            Next

            Return False

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Laudo " & wLote & " en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _ExisteTerminado(ByVal wTerminado As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM Terminado WHERE Codigo = '" & wTerminado & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Terminado en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

    Private Function _ExisteArticulo(ByVal wArticulo As String) As Boolean

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT Codigo FROM Articulo WHERE Codigo = '" & wArticulo & "'")
        Dim dr As SqlDataReader

        Try

            cn.ConnectionString = Helper._ConectarA
            cn.Open()
            cm.Connection = cn

            dr = cm.ExecuteReader()

            Return dr.HasRows

        Catch ex As Exception
            Throw New Exception("Hubo un problema al querer consultar la existencia del Articulo en la Base de Datos." & vbCrLf & vbCrLf & "Motivo: " & ex.Message)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Function

End Class