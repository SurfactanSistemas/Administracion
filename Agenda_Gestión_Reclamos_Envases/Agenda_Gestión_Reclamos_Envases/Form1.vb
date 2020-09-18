Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class Form1 : Implements IPasarFecha

    ' Dim DesdeFecha As String = Date.Today.AddDays(-90).ToString("dd/MM/yyyy")

    Dim FechaActual As String = Date.Today.ToString("dd/MM/yyyy")
    Dim FechaActualOrd As String = ordenaFecha(FechaActual)
    Dim TablaAux As New DataTable

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



        Dim SQLCnslt As String = "SELECT Cliente, Razon FROM Cliente WHERE Cliente >= '" & txt_DesdeCodigo.Text & "' AND Cliente <= '" & txt_HastaCodigo.Text & "' AND Provincia <> 24 ORDER BY Cliente"

        Dim TablaCli As DataTable = GetAll(SQLCnslt, "SurfactanSa")

        If TablaCli.Rows.Count > 0 Then
            For Each RowCli As DataRow In TablaCli.Rows

                ' VERIFICAMOS SI SE ENCUENTRA EN LA TABLA RE REPROGRAMACION DE LLAMADOS
                SQLCnslt = "SELECT FechaOrd FROM ReclamosEnvReProg WHERE Cliente = '" & RowCli.Item("Cliente") & "'"
                Dim RowRecla As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowRecla IsNot Nothing Then
                    If FechaActualOrd < RowRecla.Item("FechaOrd") Then
                        'SI LA FECHA ACTUAL ES MENOR QUE LA FECHA QUE SE REPROGRAMO EL LLAMADO, SALTEAMOS AL CLIENTE
                        Continue For
                        'Else
                        'SI LA FECHA ES MAYOR O IGUAL QUIERE DECIR QUE YA SE ALCANZO LA FECHA DE REPROGRAMACION 
                        'POR ESO ELIMINAMOS EL REGISTRO Y CONTINUAMOS CON LOS CALCULOS
                        '  SQLCnslt = "DELETE FROM ReclamosEnvReProg WHERE Cliente = '" & RowCli.Item("Cliente") & "'"
                        '  ExecuteNonQueries({SQLCnslt}, "SurfactanSa")
                    End If
                End If

                Dim CantidadEntradas As Integer = 0

                SQLCnslt = "SELECT de.Cantidad " _
                            & "FROM Surfactan_II.dbo.DevolucionEnvases de INNER JOIN SurfactanSa.dbo.EquivEnvArticulo eea ON de.Envase = eea.Articulo " _
                            & "WHERE de.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND de.OrdFecha >= '" & DesdeFechaOrd & "' AND de.OrdFecha <= '" & FechaActualOrd & "'" _
                            & "AND eea.Envase = 30"

                Dim tablaDevolEnv As DataTable = GetAll(SQLCnslt)

                If tablaDevolEnv.Rows.Count > 0 Then
                    For Each rowdevolEnv As DataRow In tablaDevolEnv.Rows
                        CantidadEntradas = CantidadEntradas + rowdevolEnv.Item("Cantidad")
                    Next
                End If

                'FALTAN LAS ENTRADAS EN HOJARUTADEENV EN PLANTA I
                SQLCnslt = "SELECT hrde.Cantidad " _
                            & "FROM HojaRutaDevEnv hrde INNER JOIN EquivEnvArticulo eea ON hrde.Envase = eea.Articulo " _
                            & "WHERE hrde.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND hrde.FechaOrd >= '20200101' AND hrde.FechaOrd <= '20200910' " _
                            & "AND eea.Envase = 30"
                Dim tablaHojaRuta As DataTable = GetAll(SQLCnslt)

                If tablaHojaRuta.Rows.Count > 0 Then
                    For Each rowHojaRuta As DataRow In tablaHojaRuta.Rows
                        CantidadEntradas = CantidadEntradas + rowHojaRuta.Item("Cantidad")
                    Next
                End If


                Dim CantidadSalidas As Integer = 0

                SQLCnslt = "SELECT Cantidad FROM MovEnv " _
                            & "WHERE Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND FechaOrd >= '" & DesdeFechaOrd & "' AND FechaOrd <= '" & FechaActualOrd & "'" _
                            & "AND Envase = 30 AND Marca <> 'X' "

                Dim tablaSalidas As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If tablaSalidas.Rows.Count > 0 Then
                    For Each rowSal As DataRow In tablaSalidas.Rows
                        CantidadSalidas = CantidadSalidas + rowSal.Item("Cantidad")
                    Next
                End If

                Dim Dif As Integer = CantidadSalidas - CantidadEntradas

                If Dif <> 0 Then
                    TablaAux.Rows.Add(RowCli.Item("Cliente"), RowCli.Item("Razon"), CantidadEntradas, CantidadSalidas, Dif)
                End If

                ProgressBar1.Value += 1
            Next

            DGV_Clientes.DataSource = TablaAux
            If chk_MostrarAFavor.Checked Then
                TablaAux.DefaultView.RowFilter = ""
            Else
                TablaAux.DefaultView.RowFilter = "Diferencia > 0"
            End If
            ProgressBar1.Value = 3000
            ProgressBar1.Visible = False
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbx_AFecha.SelectedIndex = 1
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True

        With TablaAux.Columns
            .Add("Cliente")
            .Add("Descripcion")
            .Add("Entradas")
            .Add("Salidas")
            .Add("Diferencia")
        End With

        ' Indicamos (por ejemplo en el evento Load) que el BackgroundWorker va a informar sobre el progreso 

        ' Me.BackgroundWorker1.WorkerReportsProgress = True
        'CheckForIllegalCrossThreadCalls = True
        'Me.BackgroundWorker1.RunWorkerAsync()
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

                SQLCnslt = "SELECT de.Cantidad " _
                            & "FROM Surfactan_II.dbo.DevolucionEnvases de INNER JOIN SurfactanSa.dbo.EquivEnvArticulo eea ON de.Envase = eea.Articulo " _
                            & "WHERE de.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND de.OrdFecha >= '" & DesdeFechaOrd & "' AND de.OrdFecha <= '" & FechaActualOrd & "'" _
                            & "AND eea.Envase = 30"

                Dim tablaDevolEnv As DataTable = GetAll(SQLCnslt)

                If tablaDevolEnv.Rows.Count > 0 Then
                    For Each rowdevolEnv As DataRow In tablaDevolEnv.Rows
                        CantidadEntradas = CantidadEntradas + rowdevolEnv.Item("Cantidad")
                    Next
                End If

                'FALTAN LAS ENTRADAS EN HOJARUTADEENV EN PLANTA I
                SQLCnslt = "SELECT hrde.Cantidad " _
                            & "FROM HojaRutaDevEnv hrde INNER JOIN EquivEnvArticulo eea ON hrde.Envase = eea.Articulo " _
                            & "WHERE hrde.Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND hrde.FechaOrd >= '20200101' AND hrde.FechaOrd <= '20200910' " _
                            & "AND eea.Envase = 30"
                Dim tablaHojaRuta As DataTable = GetAll(SQLCnslt)

                If tablaHojaRuta.Rows.Count > 0 Then
                    For Each rowHojaRuta As DataRow In tablaHojaRuta.Rows
                        CantidadEntradas = CantidadEntradas + rowHojaRuta.Item("Cantidad")
                    Next
                End If


                Dim CantidadSalidas As Integer = 0

                SQLCnslt = "SELECT Cantidad FROM MovEnv " _
                            & "WHERE Cliente = '" & RowCli.Item("Cliente") & "' " _
                            & "AND FechaOrd >= '" & DesdeFechaOrd & "' AND FechaOrd <= '" & FechaActualOrd & "'" _
                            & "AND Envase = 30 AND Marca <> 'X' "

                Dim tablaSalidas As DataTable = GetAll(SQLCnslt, "SurfactanSa")

                If tablaSalidas.Rows.Count > 0 Then
                    For Each rowSal As DataRow In tablaSalidas.Rows
                        CantidadSalidas = CantidadSalidas + rowSal.Item("Cantidad")
                    Next
                End If

                Dim Dif As Integer = CantidadSalidas - CantidadEntradas

                If Dif <> 0 Then
                    TablaAux.Rows.Add(RowCli.Item("Cliente"), RowCli.Item("Razon"), CantidadEntradas, CantidadSalidas, Dif)
                End If

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



    Private Sub txt_Procesar_Click(sender As Object, e As EventArgs) Handles txt_Procesar.Click
        Proceso()
    End Sub

 

    Private Sub chk_MostrarAFavor_Click(sender As Object, e As EventArgs) Handles chk_MostrarAFavor.Click
        Dim TablaFiltrar As DataTable = DGV_Clientes.DataSource
        If chk_MostrarAFavor.Checked Then
            TablaFiltrar.DefaultView.RowFilter = ""
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
            With New FechaReprog
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
End Class
