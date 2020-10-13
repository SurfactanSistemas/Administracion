Imports Util
Imports Util.Clases
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Form1 : Implements IPasarFecha, IBuscarClienteCashFlow



    Dim FechaActual As String = Date.Today.ToString("dd/MM/yyyy")
    Dim FechaActualOrd As String = ordenaFecha(FechaActual)
    Dim TablaAux As New DataTable

    Private WOrd As String = ""

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Function BuscarFechaDesde() As String
        Dim FechaDevolver As String

        If cbx_AFecha.SelectedIndex = 0 Then
            FechaDevolver = Date.Today.AddMonths(-1).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

        If cbx_AFecha.SelectedIndex = 1 Then
            FechaDevolver = Date.Today.AddMonths(-3).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

        If cbx_AFecha.SelectedIndex = 2 Then
            FechaDevolver = Date.Today.AddMonths(-6).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

        If cbx_AFecha.SelectedIndex = 3 Then
            FechaDevolver = Date.Today.AddMonths(-12).ToString("dd/MM/yyyy")
            Return FechaDevolver
        End If

    End Function


    Private Sub Proceso()

        If Trim(txt_DesdeCodigo.Text) = "" Then
            txt_DesdeCodigo.Text = "A00000"
        End If
        If Trim(txt_HastaCodigo.Text) = "" Then
            txt_HastaCodigo.Text = "Z99999"
        End If

        txt_DesdeCodigo.Text = UCase(txt_DesdeCodigo.Text)
        txt_HastaCodigo.Text = UCase(txt_HastaCodigo.Text)



        Dim DesdeFecha As String = BuscarFechaDesde()
        Dim DesdeFechaOrd As String = ordenaFecha(DesdeFecha)
        TablaAux.Rows.Clear()

        ProgressBar1.Value = 0
        ProgressBar1.Visible = True

        Dim SQLCnslt As String = "SELECT DISTINCT c.Cliente, c.Razon, ISNULL(re.FechaOrd, '') FechaOrd FROM Cliente c INNER JOIN Estadistica e ON e.Cliente = c.Cliente LEFT OUTER JOIN ReclamosEnvReProg re ON re.Cliente = c.Cliente WHERE c.Cliente BETWEEN '" & txt_DesdeCodigo.Text & "' AND '" & txt_HastaCodigo.Text & "' AND c.Provincia < 24"

        If txt_DesdeCodigo.Text = "A00000" And txt_HastaCodigo.Text = "Z99999" Then
            SQLCnslt = "SELECT DISTINCT c.Cliente, c.Razon, ISNULL(re.FechaOrd, '') FechaOrd FROM Cliente c INNER JOIN Estadistica e ON e.Cliente = c.Cliente LEFT OUTER JOIN ReclamosEnvReProg re ON re.Cliente = c.Cliente WHERE c.Provincia < 24 AND e.OrdFecha > '20190101'"
        End If

        
        Dim TablaCli As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        ProgressBar1.Maximum = TablaCli.Rows.Count + 5

        If TablaCli.Rows.Count > 0 Then

            For Each RowCli As DataRow In TablaCli.Select("FechaOrd >= '" & FechaActualOrd & "' Or FechaOrd = ''")

               

                Dim CantidadEntradas As Integer = 0

               

                SQLCnslt = "SELECT SUM(de.Cantidad) " _
                            & "FROM Surfactan_II.dbo.DevolucionEnvases de INNER JOIN SurfactanSa.dbo.EquivEnvArticulo eea ON de.Envase = eea.Articulo " _
                            & "WHERE de.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND de.OrdFecha >= '" & DesdeFechaOrd & "'" _
                            & "AND eea.Envase = 30"
               

                Dim EntDev As DataRow = GetSingle(SQLCnslt)

                If EntDev IsNot Nothing Then CantidadEntradas += OrDefault(EntDev(0), 0)

               

                SQLCnslt = "SELECT SUM(hrde.Cantidad) " _
                            & "FROM HojaRutaDevEnv hrde INNER JOIN EquivEnvArticulo eea ON hrde.Envase = eea.Articulo " _
                            & "WHERE hrde.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND hrde.FechaOrd >= '" & DesdeFechaOrd & "'" _
                            & "AND eea.Envase = 30"
               
                Dim EntHojaRuta As DataRow = GetSingle(SQLCnslt)

                If EntHojaRuta IsNot Nothing Then CantidadEntradas += OrDefault(EntHojaRuta(0), 0)

                Dim CantidadSalidas As Integer = 0


                SQLCnslt = "SELECT SUM(Cantidad) FROM MovEnv " _
                            & "WHERE Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND FechaOrd >= '" & DesdeFechaOrd & "'" _
                            & "AND Envase = 30 AND Marca <> 'X' "
               
                Dim Salidas As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If Salidas IsNot Nothing Then CantidadSalidas += OrDefault(Salidas(0), 0)

                Dim Dif As Integer = CantidadSalidas - CantidadEntradas

                'If Dif <> 0 Then

                Dim r As DataRow = TablaAux.NewRow()

                With r
                    .Item("Cliente") = RowCli("Cliente")
                    .Item("Descripcion") = RowCli("Razon")
                    .Item("Entradas") = CantidadEntradas
                    .Item("Salidas") = CantidadSalidas
                    .Item("Diferencia") = Dif
                End With

                TablaAux.Rows.Add(r)

                'TablaAux.Rows.Add(RowCli.Item("Cliente"), RowCli.Item("Razon"), CantidadEntradas, CantidadSalidas, Dif)
                'End If

                ProgressBar1.Value += 1
            Next

            DGV_Clientes.DataSource = TablaAux



            If chk_MostrarAFavor.Checked Then
                TablaAux.DefaultView.RowFilter = ""
            Else
                TablaAux.DefaultView.RowFilter = "Diferencia > 0"
            End If

            TablaAux.DefaultView.Sort() = "Cliente"

            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbx_AFecha.SelectedIndex = 3
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True


        With TablaAux.Columns
            .Add("Cliente")
            .Add("Descripcion")
            .Add("Entradas", GetType(Int32))
            .Add("Salidas", GetType(Int32))
            .Add("Diferencia", GetType(Int32))
        End With

        Operador.Base = "SurfactanSa"

    End Sub





    ' Evento que realiza la operación asíncrona
    Private Sub BackgroundWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        Dim SQLCnslt As String = "SELECT Cliente, Razon FROM Cliente WHERE Provincia <> 24 ORDER BY Cliente"

        Dim TablaCli As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        Me.BackgroundWorker1.ReportProgress(1, TablaCli)

    End Sub

    ' Evento que actualiza la progressbar para que el usuario vea la evolución de la operación
    Private Sub BackgroundWorker_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged


        Dim DesdeFecha As String = BuscarFechaDesde()
        Dim DesdeFechaOrd As String = ordenaFecha(DesdeFecha)


        Dim tablacli As DataTable = TryCast(e.UserState, DataTable)
        Dim SQLCnslt As String = ""

        If tablacli.Rows.Count > 0 Then
            For Each RowCli As DataRow In tablacli.Rows

                'VERIFICAMOS SI SE ENCUENTRA EN LA TABLA RE REPROGRAMACION DE LLAMADOS
                SQLCnslt = "SELECT FechaOrd FROM ReclamosEnvReProg WHERE Cliente = '" & RowCli.Item("Cliente") & "'"
                Dim RowRecla As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowRecla IsNot Nothing Then
                    If FechaActualOrd < RowRecla.Item("FechaOrd") Then
                        'SI LA FECHA ACTUAL ES MENOR QUE LA FECHA QUE SE REPROGRAMO EL LLAMADO, SALTEAMOS AL CLIENTE
                        Continue For
                    Else
                        'SI LA FECHA ES MAYOR O IGUAL QUIERE DECIR QUE YA SE ALCANZO LA FECHA DE REPROGRAMACION 
                        'POR ESO ELIMINAMOS EL REGISTRO Y CONTINUAMOS CON LOS CALCULOS
                        SQLCnslt = "DELETE FROM ReclamosEnvReProg WHERE Cliente = '" & RowCli.Item("Cliente") & "'"
                        ExecuteNonQueries({SQLCnslt}, "SurfactanSa")
                    End If
                End If

                Dim CantidadEntradas As Integer = 0

                'SQLCnslt = "SELECT de.Cantidad " _
                '            & "FROM Surfactan_II.dbo.DevolucionEnvases de INNER JOIN SurfactanSa.dbo.EquivEnvArticulo eea ON de.Envase = eea.Articulo " _
                '            & "WHERE de.Cliente = '" & RowCli.Item("Cliente") & "' " _
                '            & "AND de.OrdFecha >= '" & DesdeFechaOrd & "' AND de.OrdFecha <= '" & FechaActualOrd & "'" _
                '            & "AND eea.Envase = 30"

                'Dim tablaDevolEnv As DataTable = GetAll(SQLCnslt)

                'If tablaDevolEnv.Rows.Count > 0 Then
                '    For Each rowdevolEnv As DataRow In tablaDevolEnv.Rows
                '        CantidadEntradas = CantidadEntradas + rowdevolEnv.Item("Cantidad")
                '    Next
                'End If

                SQLCnslt = "SELECT SUM(de.Cantidad) " _
                            & "FROM Surfactan_II.dbo.DevolucionEnvases de INNER JOIN SurfactanSa.dbo.EquivEnvArticulo eea ON de.Envase = eea.Articulo " _
                            & "WHERE de.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND de.OrdFecha >= '" & DesdeFechaOrd & "' AND de.OrdFecha <= '" & FechaActualOrd & "'" _
                            & "AND eea.Envase = 30"

                Dim DevolEnv As DataRow = GetSingle(SQLCnslt)

                If DevolEnv IsNot Nothing Then CantidadEntradas += OrDefault(DevolEnv(0), 0)

                'FALTAN LAS ENTRADAS EN HOJARUTADEENV EN PLANTA I
                'SQLCnslt = "SELECT hrde.Cantidad " _
                '            & "FROM HojaRutaDevEnv hrde INNER JOIN EquivEnvArticulo eea ON hrde.Envase = eea.Articulo " _
                '            & "WHERE hrde.Cliente = '" & RowCli.Item("Cliente") & "' " _
                '            & "AND hrde.FechaOrd >= '20200101' AND hrde.FechaOrd <= '20200910' " _
                '            & "AND eea.Envase = 30"
                'Dim tablaHojaRuta As DataTable = GetAll(SQLCnslt)

                'If tablaHojaRuta.Rows.Count > 0 Then
                '    For Each rowHojaRuta As DataRow In tablaHojaRuta.Rows
                '        CantidadEntradas = CantidadEntradas + rowHojaRuta.Item("Cantidad")
                '    Next
                'End If

                SQLCnslt = "SELECT SUM(hrde.Cantidad) " _
                            & "FROM HojaRutaDevEnv hrde INNER JOIN EquivEnvArticulo eea ON hrde.Envase = eea.Articulo " _
                            & "WHERE hrde.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND hrde.FechaOrd >= '20200101' AND hrde.FechaOrd <= '20200910' " _
                            & "AND eea.Envase = 30"

                Dim EntHojaRuta As DataRow = GetSingle(SQLCnslt)

                If EntHojaRuta IsNot Nothing Then CantidadEntradas += OrDefault(EntHojaRuta(0), 0)

                Dim CantidadSalidas As Integer = 0

                'SQLCnslt = "SELECT Cantidad FROM MovEnv " _
                '            & "WHERE Cliente = '" & RowCli.Item("Cliente") & "' " _
                '            & "AND FechaOrd >= '" & DesdeFechaOrd & "' AND FechaOrd <= '" & FechaActualOrd & "'" _
                '            & "AND Envase = 30 AND Marca <> 'X' "

                'Dim tablaSalidas As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                'If tablaSalidas.Rows.Count > 0 Then
                '    For Each rowSal As DataRow In tablaSalidas.Rows
                '        CantidadSalidas = CantidadSalidas + rowSal.Item("Cantidad")
                '    Next
                'End If

                SQLCnslt = "SELECT SUM(Cantidad) FROM MovEnv " _
                            & "WHERE Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND FechaOrd >= '" & DesdeFechaOrd & "' AND FechaOrd <= '" & FechaActualOrd & "'" _
                            & "AND Envase = 30 AND Marca <> 'X' "

                Dim SalidasMovEnv As DataRow = GetSingle(SQLCnslt)

                If SalidasMovEnv IsNot Nothing Then CantidadSalidas += OrDefault(SalidasMovEnv(0), 0)

                Dim Dif As Integer = CantidadSalidas - CantidadEntradas

                Dim r As DataRow = TablaAux.NewRow()

                With r
                    .Item("Cliente") = RowCli("Cliente")
                    .Item("Descripcion") = RowCli("Razon")
                    .Item("Entradas") = CantidadEntradas
                    .Item("Salidas") = CantidadSalidas
                    .Item("Diferencia") = Dif
                End With

                TablaAux.Rows.Add(r)

                'If Dif <> 0 Then
                '                TablaAux.Rows.Add(RowCli.Item("Cliente"), RowCli.Item("Razon"), CantidadEntradas, CantidadSalidas, Dif)
                'End If

                ProgressBar1.Value += 1
            Next
        End If

        DGV_Clientes.DataSource = TablaAux
        TablaAux.DefaultView.RowFilter = " Diferencia > 0"
        ProgressBar1.Value = 3000
        ProgressBar1.Visible = False

    End Sub

    ' Evento que muestra una alerta para informar al usuario de que la operación asíncrona ha finalizado (ya sea porque el usuario la ha cancelado, se ha producido un erorr, o ha finalizado correctamente)
    Private Sub BackgroundWorker_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        If e.Cancelled Then
            MessageBox.Show("La operación ha sido cancelada.")
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Se ha producido un error durante la ejecución: " & e.Error.Message)
        End If

    End Sub



    Private Sub txt_Procesar_Click(sender As Object, e As EventArgs) Handles btn_Procesar.Click
        Proceso()
        txt_Filtro.Focus()
    End Sub



    Private Sub chk_MostrarAFavor_Click(sender As Object, e As EventArgs) Handles chk_MostrarAFavor.Click
        Dim TablaFiltrar As DataTable = DGV_Clientes.DataSource
        If chk_MostrarAFavor.Checked Then
            TablaFiltrar.DefaultView.RowFilter = "Diferencia <> 0"
        Else
            TablaFiltrar.DefaultView.RowFilter = "Diferencia > 0"
        End If

        For Each Dgv_row As DataGridViewRow In DGV_Clientes.Rows
            If Dgv_row.Cells("Diferencia").Value < 0 Then
                Dgv_row.Cells("Diferencia").Style.BackColor = Color.DarkCyan
                Dgv_row.Cells("Diferencia").Style.ForeColor = Color.GhostWhite
            End If
        Next

    End Sub

    Private Sub txt_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Filtro.KeyUp
        Dim TablaFiltrar As DataTable = DGV_Clientes.DataSource
        If chk_MostrarAFavor.Checked Then
            TablaFiltrar.DefaultView.RowFilter = "Cliente LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%'"
        Else
            TablaFiltrar.DefaultView.RowFilter = "(Cliente LIKE '%" & txt_Filtro.Text & "%' OR Descripcion LIKE '%" & txt_Filtro.Text & "%') AND diferencia > 0"
        End If
    End Sub

    Private Sub DGV_Clientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Clientes.CellClick
        DGV_Clientes.Rows(DGV_Clientes.CurrentCell.RowIndex).Selected = True
    End Sub

    Private Sub btn_ReprogramarLlamado_Click(sender As Object, e As EventArgs) Handles btn_ReprogramarLlamado.Click

        If DGV_Clientes.SelectedRows.Count = 1 Then

            '
            ' Busco las minutas pendientes, si existen y agarro siempre la mas próxima.
            '
            Dim WMinuta As DataRow = GetSingle("SELECT id, Fecha FROM DevolucionEnvMinutas WHERE Cliente = '" & DGV_Clientes.SelectedRows(0).Cells("Cliente").Value & "' And CantEnvIngresan = 0 AND NroHojaRuta = '" & "" & "' Order By FechaOrd")

            If WMinuta IsNot Nothing Then
                If MsgBox("El Cliente " & DGV_Clientes.SelectedRows(0).Cells("Descripcion").Value & " ya tiene generada una minuta el dia " & WMinuta("Fecha") & vbCrLf & "¿Quiere editarla?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    With New MinutaBaja_Modificacion(WMinuta("id"), DGV_Clientes.SelectedRows(0).Cells("Descripcion").Value)
                        .Show(Me)
                    End With
                    Exit Sub
                End If
            End If

            With New FechaReprog(DGV_Clientes.SelectedRows(0).Cells("Cliente").Value)
                .Show(Me)
            End With

        End If

    End Sub

    Public Sub pasaFecha(Fecha As String, Observaciones As String) Implements IPasarFecha.pasaFecha


        Dim SQLCnslt As String = "INSERT INTO ReclamosEnvReProg (" _
            & "Cliente, " _
            & "Fecha, " _
            & "FechaOrd, " _
            & "WDate, " _
            & "Observaciones) " _
            & "VALUES (" _
            & "'" & DGV_Clientes.CurrentRow.Cells("Cliente").Value & "', " _
            & "'" & Fecha & "', " _
            & "'" & ordenaFecha(Fecha) & "', " _
            & "'" & Date.Today.ToString("yyyy-dd-MM") & "', " _
            & "'" & Observaciones & "')"


        ExecuteNonQueries({SQLCnslt}, "SurfactanSa")

        RemoverdeTabla(DGV_Clientes.CurrentRow.Cells("Cliente").Value)

    End Sub


    Private Sub RemoverdeTabla(ByVal CodCliente As String)

        Dim FilaABorrar As Integer = 0
        Dim Contador As Integer = 0
        Dim TablaCli As DataTable = DGV_Clientes.DataSource
        For Each row As DataRow In TablaCli.Rows
            If row.Item("Cliente") = CodCliente Then
                FilaABorrar = Contador
            End If
            Contador += 1
        Next

        TablaCli.Rows.RemoveAt(FilaABorrar)

    End Sub

    Private Sub btn_ListaReprogramados_Click(sender As Object, e As EventArgs) Handles btn_ListaReprogramados.Click
        With New ClientesReprogramados
            .Show()
        End With
    End Sub

    Private Sub DGV_Clientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Clientes.CellMouseDoubleClick
        With New Discriminado_Mov_Env(DGV_Clientes.CurrentRow.Cells("Cliente").Value, cbx_AFecha.SelectedIndex)
            .Show(Me)
        End With
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_DesdeCodigo.Focus()
    End Sub

    
    Private Sub DGV_Clientes_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Clientes.ColumnHeaderMouseClick

        'DGV_Clientes.DataSource = TablaAux

        Dim TablaAuxII As DataTable = TryCast(DGV_Clientes.DataSource, DataTable)

        ' Yo, lo haría asi. O mejor dicho, lo hago así.

        WOrd = IIf(WOrd = "", "DESC", "")

       
        Select Case e.ColumnIndex

            Case 0
                TablaAuxII.DefaultView.Sort = "Cliente " & WOrd ' si lo pones como aca, sin nada, te lo toma como ASC
            Case 1
                TablaAuxII.DefaultView.Sort = "Descripcion " & WOrd
            Case 2
                ' Deberias poner una bandera para poder switchear entre ASC y DESC
                TablaAuxII.DefaultView.Sort = "Entradas " & WOrd ' "Convert('Entradas', System.Double) DESC"
            Case 3
                TablaAuxII.DefaultView.Sort = "Salidas " & WOrd
            Case 4
                TablaAuxII.DefaultView.Sort = "Diferencia " & WOrd

        End Select

    End Sub

    Private Sub txt_DesdeCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_DesdeCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txt_DesdeCodigo.Text) = "" Then : Exit Sub : End If

            txt_DesdeCodigo.Text = Helper.FormatoCodigoCliente(txt_DesdeCodigo.Text)

            txt_DesdeCodigo.Text = UCase(txt_DesdeCodigo.Text)

            txt_HastaCodigo.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txt_DesdeCodigo.Text = ""
        End If

    End Sub

    Private Sub txt_HastaCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_HastaCodigo.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txt_HastaCodigo.Text) = "" Then : Exit Sub : End If

            txt_HastaCodigo.Text = Helper.FormatoCodigoCliente(txt_HastaCodigo.Text)

            txt_HastaCodigo.Text = UCase(txt_HastaCodigo.Text)

            btn_Procesar.PerformClick()

        ElseIf e.KeyData = Keys.Escape Then
            txt_HastaCodigo.Text = ""
        End If

    End Sub

    Private Sub btnListadoMinutas_Click(sender As Object, e As EventArgs) Handles btnListadoMinutas.Click
        With GenerarReportes
            .Show()
        End With
    End Sub
    
    Private Sub txt_DesdeCodigo_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_DesdeCodigo.MouseDoubleClick
        With New ConsultaCliente
            .Show(Me)
        End With
    End Sub

    Public Sub CompletaCliente(CodigoCliente As String, Accion As String) Implements IBuscarClienteCashFlow.CompletaCliente
        If Accion = "Ambos" Then
            txt_DesdeCodigo.Text = CodigoCliente
            txt_HastaCodigo.Text = CodigoCliente
        End If

        If Accion = "Desde" Then
            txt_DesdeCodigo.Text = CodigoCliente
        End If

        If Accion = "Hasta" Then
            txt_HastaCodigo.Text = CodigoCliente
        End If
    End Sub

End Class
