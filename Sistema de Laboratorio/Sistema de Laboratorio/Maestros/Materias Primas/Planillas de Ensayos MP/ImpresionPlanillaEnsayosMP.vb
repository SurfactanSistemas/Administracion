Imports ConsultasVarias.Interfaces

Public Class ImpresionPlanillaEnsayosMP : Implements ConsultasVarias.Interfaces.IAyudaMPs

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        With New ConsultasVarias.AyudaMPs
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaMPs(Codigo As String, Descripcion As String) Implements IAyudaMPs._ProcesarAyudaMPs
        txtCodigo.Text = Codigo
        txtCodigo_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown

        If e.KeyData = Keys.Enter Then

            lblDescripcion.Text = ""
            dgvEspecif.Rows.Clear()

            If txtCodigo.Text.Replace(" ", "").Length > 12 Then : Exit Sub : End If

            Dim WTerminado As DataRow = GetSingle("SELECT Descripcion FROM Articulo WHERE Codigo = '" & txtCodigo.Text & "'")
            If WTerminado Is Nothing Then Exit Sub

            lblDescripcion.Text = Trim(OrDefault(WTerminado.Item("Descripcion"), "")).ToUpper

            '
            ' Chequeamos que se haya cargado el producto por el cual consultar.
            '
            If txtCodigo.Text.Replace(" ", "").Length < 10 Then
                MsgBox("El código de Materia Prima indicado no es correcto.", MsgBoxStyle.Exclamation)
                txtCodigo.Focus()
                Exit Sub
            End If

            '
            ' Verificamos que haya especificaciones cargadas para la etapa indicada.
            '
            _CargarDatosEspecifMP()

            If dgvEspecif.Rows.Count = 0 Then
                MsgBox("No se han actualizado las especificaciones de la Materia Prima al Nuevo Formato.")
                Exit Sub
            End If

            For Each row As DataGridViewRow In dgvEspecif.Rows
                With row
                    .Cells("Descripcion").Value = _TraerDescripcionEnsayo(.Cells("Ensayo").Value)
                End With
            Next

        ElseIf e.KeyData = Keys.Escape Then
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Function _TraerDescripcionEnsayo(ByVal _Ens As Object)

        Dim WEns As String = OrDefault(_Ens, "0")

        Dim WBaseII = "Surfactan_II"
        If _EsPellital() Then WBaseII = "Pelitall_II"

        Dim WEnsayo As DataRow = GetSingle("SELECT Descripcion FROM Ensayos WHERE Codigo = '" & WEns & "'", WBaseII)

        If WEnsayo IsNot Nothing Then
            Return Trim(OrDefault(WEnsayo.Item("Descripcion"), ""))
        End If

        Return ""
    End Function


    Private Sub _CargarDatosEspecifMP()

        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaVMP WHERE Articulo = '" & txtCodigo.Text & "' Order By Clave", "Surfactan_II")

        dgvEspecif.Rows.Clear()

        If WCargaV.Rows.Count = 0 Then Return

        For Each row As DataRow In WCargaV.Rows
            With row
                Dim WEns = OrDefault(.Item("Ensayo"), 0)
                Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "0")
                Dim WDesdeEspecif As String = OrDefault(.Item("DesdeEspecif"), "")
                Dim WHastaEspecif As String = OrDefault(.Item("HastaEspecif"), "")
                Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "0")
                Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                Dim r = dgvEspecif.Rows.Add

                With dgvEspecif.Rows(r)
                    .Cells("Ensayo").Value = WEns
                    .Cells("Descripcion").Value = ""
                    .Cells("DescParametros").Value = Trim(WEspecificacion)
                    .Cells("Parametro").Value = Trim(WImpreParametro)
                End With

            End With

        Next

    End Sub

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As String, ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String) As String

        wDesdeEspecif = OrDefault(Trim(wDesdeEspecif), "")
        wHastaEspecif = OrDefault(Trim(wHastaEspecif), "")
        wUnidadEspecif = OrDefault(Trim(wUnidadEspecif), "")
        wMenorIgualEspecif = OrDefault(Trim(wMenorIgualEspecif), "")

        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return "Cumple Ensayo"

        If Val(wDesdeEspecif) <> 0 Or Val(wHastaEspecif) <> 9999 Then

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) <> 0 Then
                Return String.Format("{0} - {1} {2}", wDesdeEspecif, wHastaEspecif, wUnidadEspecif)
            End If

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) <> 0 Then

                If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Máximo {0} {1}", wHastaEspecif, wUnidadEspecif)

                Return String.Format("Menor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

            If Val(wDesdeEspecif) <> 0 And Val(wHastaEspecif) = 9999 Then

                If Val(wMenorIgualEspecif) = 1 Then Return String.Format("Mínimo {0} {1}", wHastaEspecif, wUnidadEspecif)

                Return String.Format("Mayor a {0} {1}", wHastaEspecif, wUnidadEspecif)

            End If

        End If

        Return ""
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvEspecif.Rows.Count = 0 Then Exit Sub

        Dim WTabla As DataTable = New DBAuxi.PlanilllaEnsayosDataTable

        For Each row As DataGridViewRow In dgvEspecif.Rows
            Dim r As DataRow = WTabla.NewRow
            With r
                .Item("Ensayo") = row.Cells("Ensayo").Value
                .Item("DescEnsayo") = row.Cells("Descripcion").Value
                .Item("DescParametro") = row.Cells("DescParametros").Value
                .Item("Parametro") = row.Cells("Parametro").Value
                .Item("Titulo") = "Materia Prima"
                .Item("Codigo") = txtCodigo.Text
                .Item("Descripcion") = lblDescripcion.Text
                .Item("Etapa") = ""
            End With
            WTabla.Rows.Add(r)
        Next

        With New ConsultasVarias.VistaPrevia
            .Reporte = New PlanillaEnsayos
            .Reporte.SetDataSource(WTabla)
            '.Mostrar()
            .Imprimir()
        End With

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ImpresionPlanillaEnsayosMP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Text = ""
        lblDescripcion.Text = ""
    End Sub

    Private Sub ImpresionPlanillaEnsayosMP_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtCodigo.Focus()
    End Sub
End Class