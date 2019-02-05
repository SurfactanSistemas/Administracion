﻿Public Class IngresoEnsayosIntermediosPT : Implements INotasEnsayosProductosTerminados, IIngresoClaveSeguridad, IIngresoMotivoDesvio

    Private WNotas As New List(Of String)
    Private WEsPorDesvio As Boolean = False
    Private WMotivoDesvio As String = ""

    Private Sub btnCerrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtArchivo, txtCodigo, txtConfecciono, txtDesvio, txtEtapa, txtFecha, txtLibros, txtOOS, txtPaginas, txtPartida, lblTipoProceso}
            c.Text = ""
        Next
        dgvEnsayos.Rows.Clear()

        WNotas = New List(Of String)
        For i = 0 To 8
            WNotas.Add("")
        Next

        WEsPorDesvio = False
        WMotivoDesvio = ""

        txtPartida.Focus()
    End Sub

    Private Sub IngresoEnsayosIntermediosPT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub IngresoEnsayosIntermediosPT_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        txtPartida.Focus()
    End Sub

    Private Sub txtPartida_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPartida.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtPartida.Text) = "" Then : Exit Sub : End If

            Dim WHoja As DataRow = GetSingle("SELECT Producto FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon in ('1', '01')")

            If IsNothing(WHoja) Then Exit Sub

            With WHoja
                txtCodigo.Text = OrDefault(.Item("Producto"), "")
            End With

            lblTipoProceso.Text = ""

            Dim WCargaIII As DataRow = GetSingle("SELECT TipoProceso FROM CargaIII WHERE Terminado = '" & txtCodigo.Text & "' And Paso in ('1', '01')")

            If WCargaIII IsNot Nothing Then
                lblTipoProceso.Text = OrDefault(WCargaIII.Item("TipoProceso"), "").ToString.Trim.ToUpper
            End If

            txtEtapa.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtPartida.Text = ""
        End If

    End Sub

    Private Sub txtEtapa_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEtapa.KeyDown

        If e.KeyData = Keys.Enter Then
            If Val(txtEtapa.Text) = 0 Then : Exit Sub : End If
            If Val(txtPartida.Text) = 0 Then : Exit Sub : End If

            WMotivoDesvio = ""

            btnGrabar.Text = "GRABAR"

            Dim WExiste As DataRow = GetSingle("SELECT Clave FROM PrueterfarmaIntermedio WHERE Producto = '" + txtCodigo.Text + "' And Paso = '" & txtEtapa.Text & "' And Renglon = '1'")

            If WExiste IsNot Nothing Then

                Dim WPrueterFarma As DataTable = GetAll("SELECT * FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

                If WPrueterFarma.Rows.Count = 0 Then Exit Sub

                dgvEnsayos.Rows.Clear()

                Dim WFecha = ""
                Dim WConfecciono = ""
                Dim WLibros = ""
                Dim WPaginas = ""
                Dim WNroOOS = ""
                Dim WNroDesvio = ""
                Dim WArchivo = ""

                For Each row As DataRow In WPrueterFarma.Rows
                    With row
                        Dim WEns = OrDefault(.Item("Codigo"), "")
                        Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                        Dim WValor = OrDefault(.Item("ValorReal"), "")
                        Dim WResultado = OrDefault(.Item("Resultado"), "")
                        Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                        Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                        Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                        Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                        Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                        Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                        Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                        Dim WImpreResultado = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                        WFecha = OrDefault(.Item("Fecha"), "")
                        WConfecciono = OrDefault(.Item("Confecciono"), "")
                        WLibros = OrDefault(.Item("Libros"), "")
                        WPaginas = OrDefault(.Item("Paginas"), "")
                        WNroOOS = OrDefault(.Item("NroOOS"), "")
                        WNroDesvio = OrDefault(.Item("NroDesvio"), "")
                        WArchivo = OrDefault(.Item("Archiva"), "")
                        WMotivoDesvio = OrDefault(.Item("MotivoDesvio"), "")

                        If Val(WTipoEspecif) = 0 And WImpreResultado <> "" Then WImpreResultado &= " (c)"

                        Dim WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                        Dim r = dgvEnsayos.Rows.Add

                        With dgvEnsayos.Rows(r)
                            .Cells("Ensayo").Value = WEns
                            .Cells("Valor").Value = Trim(WValor)
                            .Cells("Resultado").Value = Trim(WResultado)
                            .Cells("Especificacion").Value = Trim(WEspecificacion)
                            .Cells("Descripcion").Value = Trim(WDescripcion)
                            .Cells("Farmacopea").Value = Trim(WFarmacopea)
                            .Cells("TipoEspecif").Value = WTipoEspecif
                            .Cells("DesdeEspecif").Value = WDesdeEspecif
                            .Cells("HastaEspecif").Value = WHastaEspecif
                            .Cells("UnidadEspecif").Value = WUnidadEspecif
                            .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                            .Cells("InformaEspecif").Value = WInformaEspecif
                            .Cells("Parametro").Value = Trim(WImpreResultado)
                        End With

                    End With

                Next

                txtFecha.Text = Trim(WFecha)
                txtConfecciono.Text = Trim(WConfecciono).ToUpper
                txtLibros.Text = Trim(WLibros)
                txtPaginas.Text = Trim(WPaginas)
                txtOOS.Text = Trim(WNroOOS)
                txtDesvio.Text = Trim(WNroDesvio)
                txtArchivo.Text = Trim(WArchivo)

                Dim _Notas As DataRow = GetSingle("SELECT Nota1, Nota2, Nota3, Nota4, Nota5, Nota6, Nota7, Nota8, Nota9 FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "'")

                WNotas.Clear()

                If _Notas IsNot Nothing Then

                    For i = 0 To 8

                        Dim WContenido As String = OrDefault(_Notas.Item("Nota" & i + 1), "")

                        WNotas.Add(Trim(WContenido))

                    Next

                End If

                btnGrabar.Text = "ACTUALIZAR"

            Else

                Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

                If WCargaV.Rows.Count = 0 Then Exit Sub

                dgvEnsayos.Rows.Clear()

                For Each row As DataRow In WCargaV.Rows
                    With row
                        Dim WEns = OrDefault(.Item("Ensayo"), 0)
                        Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                        Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                        Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                        Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                        Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                        Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                        Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                        Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                        Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                        If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                        Dim WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                        Dim r = dgvEnsayos.Rows.Add

                        With dgvEnsayos.Rows(r)
                            .Cells("Ensayo").Value = WEns
                            .Cells("Especificacion").Value = Trim(WEspecificacion)
                            .Cells("Descripcion").Value = Trim(WDescripcion)
                            .Cells("Farmacopea").Value = Trim(WFarmacopea)
                            .Cells("TipoEspecif").Value = WTipoEspecif
                            .Cells("DesdeEspecif").Value = WDesdeEspecif
                            .Cells("HastaEspecif").Value = WHastaEspecif
                            .Cells("UnidadEspecif").Value = WUnidadEspecif
                            .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                            .Cells("InformaEspecif").Value = WInformaEspecif
                            .Cells("Parametro").Value = Trim(WImpreParametro)
                        End With

                    End With

                Next

                txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")

            End If

            If dgvEnsayos.Rows.Count > 0 Then
                dgvEnsayos.CurrentCell = dgvEnsayos.Item("Valor", 0)
                dgvEnsayos.Focus()
            Else
                txtEtapa.Focus()
            End If

        ElseIf e.KeyData = Keys.Escape Then
            txtEtapa.Text = ""
        End If

    End Sub

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wMenorIgualEspecif As Object) As String
        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wTipoEspecif = Trim(wTipoEspecif)
        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

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

    Private Sub btnNotas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotas.Click

        With New NotasEnsayosProductosTerminados
            .Partida = Val(txtPartida.Text)
            .Terminado = txtCodigo.Text
            .Etapa = Val(txtEtapa.Text)
            .Notas = WNotas
            .ShowDialog(Me)
        End With

    End Sub

    Public Sub _ProcesarNotasEnsayosProductosTerminados(ByVal _Notas As List(Of String)) Implements INotasEnsayosProductosTerminados._ProcesarNotasEnsayosProductosTerminados
        WNotas = _Notas
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGrabar.Click

        Try

            _ValidarDatos()

            If Not _ValidarValoresIngresados() And Not WEsPorDesvio Then

                If MsgBox("Algunos de los valores introducidos no se encuentran dentro de los valores especificados para este Producto." & vbCrLf & vbCrLf & vbCrLf & "¿Desea Continuar con la Grabación por Desvío?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    WEsPorDesvio = False
                    Exit Sub
                End If

                If Val(txtDesvio.Text) = 0 Then Throw New Exception("Se debe indicar un número de Desvío.")
                If Val(txtOOS.Text) = 0 Then Throw New Exception("Se debe indicar un número de OOS.")

                Dim mot As New IngresoMotivoDesvio(WMotivoDesvio)

                If mot.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

                Dim frm As New IngresoClaveSeguridad
                frm.ShowDialog(Me)

                txtPartida.Focus()

                Exit Sub

            End If

            Dim WSqls As New List(Of String)

            Dim WPartida = txtPartida.Text
            Dim WCodigo = txtCodigo.Text
            Dim WEtapa = txtEtapa.Text
            Dim WFecha = txtFecha.Text
            Dim WFechaOrd = ordenaFecha(txtFecha.Text)
            Dim WLibros = txtLibros.Text.Trim
            Dim WPaginas = txtPaginas.Text.Trim
            Dim WNroOOS = txtOOS.Text.Trim
            Dim WNroDesvio = txtDesvio.Text.Trim
            Dim WConfecciono = txtConfecciono.Text.Trim
            Dim WArchivo = txtArchivo.Text.Trim

            Dim WPorDesvio = "0"

            If WEsPorDesvio Then
                WPorDesvio = "1"
            Else
                WMotivoDesvio = ""
            End If

            'Dim WMotivoDesvio = ""
            Dim WLiberada = ""

            If WNotas Is Nothing Then
                For i = 0 To 9
                    WNotas.Add("")
                Next
            End If

            Dim WRenglon = 0

            WSqls.Add("DELETE FROM PrueterfarmaIntermedio WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Paso = '" & WEtapa & "'")

            For Each row As DataGridViewRow In dgvEnsayos.Rows
                With row
                    Dim WEns As String = OrDefault(.Cells("Ensayo").Value, 0)
                    Dim WEspecificacion As String = OrDefault(.Cells("Especificacion").Value, "")
                    Dim WValor As String = OrDefault(.Cells("Valor").Value, "")
                    Dim WResultado As String = OrDefault(.Cells("Resultado").Value, "")
                    Dim WFarmacopea As String = OrDefault(.Cells("Farmacopea").Value, "")
                    Dim WTipoEspecif As String = OrDefault(.Cells("TipoEspecif").Value, 0)
                    Dim WDesdeEspecif As String = OrDefault(.Cells("DesdeEspecif").Value, "")
                    Dim WHastaEspecif As String = OrDefault(.Cells("HastaEspecif").Value, "")
                    Dim WUnidadEspecif As String = OrDefault(.Cells("UnidadEspecif").Value, "")
                    Dim WMenorIgualEspecif As String = OrDefault(.Cells("MenorIgualEspecif").Value, 0)
                    Dim WInformaEspecif As String = OrDefault(.Cells("InformaEspecif").Value, 0)
                    Dim WObservaciones As String = OrDefault(.Cells("Observaciones").Value, "")
                    WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor)
                    'Dim WImpreResultado = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                    WRenglon += 1

                    'Dim WClave = "1" & WCodigo & txtPartida.Text.PadLeft(6, "0") & txtEtapa.Text.PadLeft(2, "0") & WRenglon.ToString.PadLeft(2, "0")
                    Dim WClave = "1" & WCodigo & txtPartida.Ceros(6) & txtEtapa.Ceros(2) & WRenglon.Ceros(2)
                    Dim ZSql = ""
                    ZSql = ZSql & "INSERT INTO PrueTerFarmaIntermedio ("
                    ZSql = ZSql & "Clave ,"
                    ZSql = ZSql & "Paso ,"
                    ZSql = ZSql & "Tipo ,"
                    ZSql = ZSql & "Partida ,"
                    ZSql = ZSql & "Renglon ,"
                    ZSql = ZSql & "Producto ,"
                    ZSql = ZSql & "Fecha ,"
                    ZSql = ZSql & "FechaOrd ,"
                    ZSql = ZSql & "Codigo ,"
                    ZSql = ZSql & "Valor ,"
                    ZSql = ZSql & "Resultado ,"
                    ZSql = ZSql & "Observaciones ,"
                    ZSql = ZSql & "ValorReal ,"
                    ZSql = ZSql & "TipoEspecif ,"
                    ZSql = ZSql & "InformaEspecif ,"
                    ZSql = ZSql & "MenorIgualEspecif ,"
                    ZSql = ZSql & "UnidadEspecif ,"
                    ZSql = ZSql & "DesdeEspecif ,"
                    ZSql = ZSql & "HastaEspecif ,"
                    ZSql = ZSql & "Farmacopea ,"
                    ZSql = ZSql & "PorDesvio ,"
                    ZSql = ZSql & "MotivoDesvio ,"
                    ZSql = ZSql & "NroDesvio ,"
                    ZSql = ZSql & "Libros ,"
                    ZSql = ZSql & "Archiva ,"
                    ZSql = ZSql & "NroOOS ,"
                    ZSql = ZSql & "Paginas ,"
                    ZSql = ZSql & "Estado ,"
                    ZSql = ZSql & "Confecciono ,"
                    ZSql = ZSql & "Liberada )"
                    ZSql = ZSql & "Values ("
                    ZSql = ZSql & "'" & WClave & "',"
                    ZSql = ZSql & "'" & Trim(txtEtapa.Text) & "',"
                    ZSql = ZSql & "'" & "1" & "',"
                    ZSql = ZSql & "'" & WPartida.left(6) & "',"
                    ZSql = ZSql & "'" & WRenglon.left(2) & "',"
                    ZSql = ZSql & "'" & WCodigo.left(12) & "',"
                    ZSql = ZSql & "'" & WFecha & "',"
                    ZSql = ZSql & "'" & WFechaOrd & "',"
                    ZSql = ZSql & "'" & WEns & "',"
                    ZSql = ZSql & "'" & WEspecificacion.left(50) & "',"
                    ZSql = ZSql & "'" & WResultado.left(50) & "',"
                    ZSql = ZSql & "'" & WObservaciones.left(100) & "',"
                    ZSql = ZSql & "'" & WValor.left(10) & "',"
                    ZSql = ZSql & "'" & WTipoEspecif.left(1) & "',"
                    ZSql = ZSql & "'" & WInformaEspecif.left(1) & "',"
                    ZSql = ZSql & "'" & WMenorIgualEspecif.left(1) & "',"
                    ZSql = ZSql & "'" & WUnidadEspecif.left(20) & "',"
                    ZSql = ZSql & "'" & WDesdeEspecif.left(10) & "',"
                    ZSql = ZSql & "'" & WHastaEspecif.left(10) & "',"
                    ZSql = ZSql & "'" & WFarmacopea.left(10) & "',"
                    ZSql = ZSql & "'" & WPorDesvio.left(1) & "',"
                    ZSql = ZSql & "'" & WMotivoDesvio.left(100) & "',"
                    ZSql = ZSql & "'" & WNroDesvio.left(10) & "',"
                    ZSql = ZSql & "'" & WLibros.left(20) & "',"
                    ZSql = ZSql & "'" & WArchivo.left(30) & "',"
                    ZSql = ZSql & "'" & WNroOOS.left(10) & "',"
                    ZSql = ZSql & "'" & WPaginas.left(20) & "',"
                    ZSql = ZSql & "'" & "1" & "',"
                    ZSql = ZSql & "'" & WConfecciono.left(50) & "',"
                    ZSql = ZSql & "'" & WLiberada & "')"

                    WSqls.Add(ZSql)

                End With

            Next

            With WNotas
                WSqls.Add("UPDATE Prueterfarmaintermedio SET " &
                          "Nota1 = '" & .Item(0) & "'," &
                          "Nota2 = '" & .Item(1) & "'," &
                          "Nota3 = '" & .Item(2) & "'," &
                          "Nota4 = '" & .Item(3) & "'," &
                          "Nota5 = '" & .Item(4) & "'," &
                          "Nota6 = '" & .Item(5) & "'," &
                          "Nota7 = '" & .Item(6) & "'," &
                          "Nota8 = '" & .Item(7) & "'," &
                          "Nota9 = '" & .Item(8) & "'" &
                          " WHERE Partida = '" & WPartida & "' And Producto = '" & WCodigo & "' And Paso = '" & WEtapa & "'"
                          )
            End With

            ExecuteNonQueries(WSqls.ToArray)

            'MsgBox("Actualizado")

            btnLimpiar.PerformClick()

            txtPartida.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            txtPartida.Focus()
        End Try

    End Sub

    Private Function _ValidarValoresIngresados() As Boolean
        '
        ' Validamos los valores ingresados.
        '
        ' Se validan los datos para aquellos Prductos para los que se han definido
        ' las especificaciones por Sistema. En los casos de aquellos productos que no,
        ' se deja sin validación como hasta el dia de hoy.
        '
        For Each row As DataGridViewRow In dgvEnsayos.Rows
            With row

                Dim WTipo As String = OrDefault(.Cells("TipoEspecif").Value, "")
                Dim WMenorIgual As String = OrDefault(.Cells("MenorIgualEspecif").Value, "")
                Dim WMin As Double = Val(formatonumerico(OrDefault(.Cells("DesdeEspecif").Value, ""), 10))
                Dim WMax As Double = Val(formatonumerico(OrDefault(.Cells("HastaEspecif").Value, ""), 10))
                Dim WValor As String = OrDefault(.Cells("Valor").Value, "")
                Dim WEns As String = OrDefault(.Cells("Ensayo").Value, "")

                If WEns.Trim <> "" And WValor.Trim <> "" And WTipo.Trim <> "" Then

                    If Val(WTipo) = 1 Then

                        If WValor.ToUpper = "P" Then Return True

                        Dim WNumeroValido = True

                        Double.TryParse(WValor, WNumeroValido)
                        If Not WNumeroValido Then Throw New Exception("Hay un error de Formato en alguno de los campos. " & vbCrLf & vbCrLf & "Se esperaba un valor numérico.")

                        Dim WValorNum As Double = Val(formatonumerico(WValor, 10))

                        If Val(WMenorIgual) = 0 And (WValorNum < WMin Or WValorNum > WMax) Then Return False

                        If Val(WMenorIgual) = 1 And (WValorNum <= WMin Or WValorNum >= WMax) Then Return False

                    Else

                        If Not {"S", "P", "N"}.Contains(WValor.ToUpper) Then Return False

                    End If

                End If

            End With
        Next

        Return True
    End Function

    Private Function _GenerarImpreResultado(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wValor As Object) As Object

        If wValor = "" Then Return ""

        If Val(wTipoEspecif) = 1 Then

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 9999 Then Return "CUMPLE"

            Dim WValido = True
            Double.TryParse(wValor.ToString, WValido)

            If Not WValido Then Return ""

            Return String.Format("{0} {1}", wValor, wUnidadEspecif)

        Else

            Select Case UCase(wValor)
                Case "S"
                    Return "CUMPLE"
                Case "N"
                    Return "NO CUMPLE"
                Case "P"
                    Return "PENDIENTE"
                Case Else
                    Return ""
            End Select

        End If

    End Function

    Private Sub _ValidarDatos()
        '
        ' Verificamos Datos Obligatorios.
        '
        If Val(txtPartida.Text) = 0 Then Throw New Exception("No se ha cargado una partida válida.")
        If txtCodigo.Text.Replace(" ", "").Length < 12 Then Throw New Exception("No se ha cargado un Código de Producto Terminado válido.")
        If Val(txtEtapa.Text) = 0 Then Throw New Exception("No se ha cargado una Etapa válida.")
        If txtLibros.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Libros correspondiente.")
        If txtPaginas.Text.Trim = "" Then Throw New Exception("No se ha informado la información de Páginas correspondiente.")
        If txtConfecciono.Text.Trim = "" Then Throw New Exception("No se ha informado quién Confecciona el ingreso de Ensayos.")

        '
        ' Verificamos Datos Ingresados.
        '
        Dim WTerminado As DataRow = GetSingle("SELECT Codigo FROM Terminado WHERE Codigo = '" & txtCodigo.Text & "'")
        If WTerminado Is Nothing Then Throw New Exception("El Código de Producto Terminado es inválido.")

        Dim WHoja As DataRow = GetSingle("SELECT Producto FROM Hoja WHERE Hoja = '" & txtPartida.Text & "' And Renglon in ('1', '01')")

        If WHoja Is Nothing Then Throw New Exception("La Hoja indicada es Inexistente.")

        If WHoja.Item("Producto").ToString.ToUpper <> txtCodigo.Text.ToUpper Then Throw New Exception("El Código de Producto Terminado indicado no se corresponde con el indicado en la Hoja de Producción.")

    End Sub

    Public Sub _ProcesarIngresoClaveSeguridad(ByVal WClave As Object) Implements IIngresoClaveSeguridad._ProcesarIngresoClaveSeguridad
        If WClave.ToString.ToUpper = "SEGURO" Then
            WEsPorDesvio = True
            btnGrabar.PerformClick()
        Else
            MsgBox("Clave Incorrecta")
            Dim frm As New IngresoClaveSeguridad
            frm.ShowDialog(Me)
        End If
    End Sub

    Public Sub _ProcesarIngresoMotivoDesvio(ByVal _Motivo As Object) Implements IIngresoMotivoDesvio._ProcesarIngresoMotivoDesvio
        WMotivoDesvio = Trim(_Motivo)
    End Sub

    Private Sub btnRegistroProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistroProd.Click

        Try
            Dim WPrueterfarma As DataTable = GetAll("SELECT * FROM PrueterFarmaIntermedio WHERE Partida = '" & txtPartida.Text & "' And Producto = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

            If WPrueterfarma.Rows.Count = 0 Then
                txtPartida.Focus()
                Exit Sub
            End If

            Dim WSqls As New List(Of String)

            Dim WPartida As String = txtPartida.Text
            Dim WCodigo As String = txtCodigo.Text
            Dim WEtapa As String = txtEtapa.Text

            btnLimpiar.PerformClick()

            txtPartida.Text = WPartida
            txtPartida_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            txtEtapa.Text = WEtapa
            txtEtapa_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

            _ActualizarTablaEnsayos()

            '
            ' Obtenemos el Producto Original en caso de que se haya ingresado como RE/NK.
            '
            If txtCodigo.Text.ToUpper.StartsWith("RE") Or txtCodigo.Text.ToUpper.StartsWith("NK") Then
                Dim _Hoja As DataRow = GetSingle("SELECT ISNULL(TipoOri, '') TipoOri FROM Hoja WHERE Hoja = '" & WPartida & "' And Renglon IN ('1', '01')")

                If Not IsNothing(_Hoja) Then

                    If {"PT", "RE"}.Contains(_Hoja.Item("TipoOri")) Then
                        WCodigo = WCodigo.Replace("RE", _Hoja.Item("TipoOri"))
                        WCodigo = WCodigo.Replace("NK", _Hoja.Item("TipoOri"))
                    End If

                End If

            End If

            Dim WConfecciono As String = txtConfecciono.Text.left(50)

            WSqls.Add("UPDATE CargaV SET ObservaIV = '" & WConfecciono & "' WHERE Terminado = '" & WCodigo & "' And Paso = '" & txtEtapa.Text & "'")

            For Each row As datarow In WPrueterfarma.Rows
                With row
                    '
                    ' Actualizamos los resultados y la confeccion en CargaV.
                    '
                    Dim WResultado As String = OrDefault(row.Item("Resultado"), "")

                    WResultado = WResultado.left(50)

                    WSqls.Add("UPDATE CargaV SET Resultado = '" & WResultado & "' WHERE Terminado = '" & WCodigo & "' And Paso = '" & txtEtapa.Text & "'")

                    Dim WTipo = OrDefault(row.Item("TipoEspecif"), "")
                    Dim WMenorIgual = OrDefault(row.Item("MenorIgualEspecif"), "")
                    Dim WDesde = OrDefault(row.Item("DesdeEspecif"), "")
                    Dim WHasta = OrDefault(row.Item("HastaEspecif"), "")
                    Dim WUnidad = OrDefault(row.Item("UnidadEspecif"), "")
                    Dim WClave = OrDefault(row.Item("Clave"), "")
                    Dim WValor = OrDefault(row.Item("Valor"), "")

                    Dim WImpreParametro As String = _GenerarImpreParametro(WTipo, WDesde, WHasta, WUnidad, WMenorIgual)

                    WSqls.Add("UPDATE PrueterFarmaIntermedio SET Impre1 = '" & WImpreParametro & "', Impre2 = '" & WValor & "' WHERE Clave = '" & WClave & "'")

                End With
            Next

            Dim WHoja As DataRow = GetSingle("SELECT Teorico, Cantidad FROM Hoja WHERE Hoja = '" & txtPartida.Text & "'")
            Dim WTeorico As Double = 0

            If WHoja IsNot Nothing Then
                WTeorico = OrDefault(WHoja.Item("Teorico"), 0)
            End If

            WSqls.Add("UPDATE CargaV SET ImpreTerminado = '" & txtCodigo.Text & "', Partida = '" & txtPartida.Text & "', FechaIng = '" & txtFecha.Text & "', CantidadPartida = '" & formatonumerico(WTeorico) & "', ImprePaso = '" & txtEtapa.Text & "' WHERE Terminado = '" & txtCodigo.Text & "'")

            ExecuteNonQueries(WSqls.ToArray)

            Dim frm As New VistaPrevia

            With frm
                .Reporte = New ResultadosIntermediosPT
                .Formula = "{PrueterFarma.Producto} = {Terminado.Codigo} And {PrueterFarma.Paso} = " & txtEtapa.Text & " And {PrueterFarma.Codigo} = {Ensayos.Codigo} And {PrueterFarma.Partida}  = " & txtPartida.Text & ""
                .Mostrar()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub _ActualizarTablaEnsayos()

        '
        ' Obtenemos los valores de los ensayos de las bases correspondientes, segun la empresa que se representa.
        '
        Dim WBaseEnsayos = "Surfactan_III"

        If Operador.Base.ToUpper.StartsWith("PELLITAL") Or Operador.Base.ToUpper.StartsWith("PELITALL") Then WBaseEnsayos = "Pelitall_II"

        Dim WEnsayosBase As DataTable = GetAll("SELECT Codigo, Descripcion, DescripcionII, Unidad FROM Ensayos Order By Codigo", WBaseEnsayos)

        Dim WSqls As New List(Of String)

        For Each row As datarow In WEnsayosBase.Rows
            With row
                Dim WCodigo = OrDefault(.item("Codigo"), "")
                Dim WDescripcion = OrDefault(.Item("Descripcion"), "")
                Dim WDescripcionII = OrDefault(.Item("DescripcionII"), "")
                Dim WUnidad = OrDefault(.Item("Unidad"), "")
                Dim ZSql = ""

                Dim WEnsayo As DataRow = GetSingle("SELECT Codigo FROM Ensayos WHERE Codigo = '" & WCodigo & "'")

                If WEnsayo Is Nothing Then
                    ZSql = String.Format("INSERT INTO Ensayos (Codigo, Descripcion, DescripcionII, Unidad) VALUES ('{0}', '{1}', '{2}', '{3}')", WCodigo, WDescripcion, WDescripcionII, WUnidad)
                Else
                    ZSql = String.Format("UPDATE Ensayos SET Descripcion = '{1}', DescripcionII = '{2}', Unidad = '{3}' WHERE Codigo = '{0}'", WCodigo, WDescripcion, WDescripcionII, WUnidad)
                End If

                WSqls.Add(ZSql)

            End With
        Next

        ExecuteNonQueries(WSqls.ToArray)

    End Sub

    Private Sub btnActualizarEspecif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarEspecif.Click
        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & txtCodigo.Text & "' And Paso = '" & txtEtapa.Text & "' Order By Clave")

        If WCargaV.Rows.Count = 0 Then Exit Sub

        Dim WRenglon = 0

        For Each row As DataRow In WCargaV.Rows
            With row
                Dim WEns = OrDefault(.Item("Ensayo"), 0)
                Dim WEspecificacion = OrDefault(.Item("Valor"), "")
                Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                Dim WImpreParametro = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif)

                If Val(WTipoEspecif) = 0 And WImpreParametro <> "" Then WImpreParametro &= " (c)"

                Dim WDescripcion = "" 'OrDefault(.Item("Ensayo"), 0)

                If WRenglon > dgvEnsayos.Rows.Count - 1 Then WRenglon = dgvEnsayos.Rows.Add

                With dgvEnsayos.Rows(WRenglon)
                    .Cells("Ensayo").Value = WEns
                    .Cells("Especificacion").Value = Trim(WEspecificacion)
                    .Cells("Descripcion").Value = Trim(WDescripcion)
                    .Cells("Farmacopea").Value = Trim(WFarmacopea)
                    .Cells("TipoEspecif").Value = WTipoEspecif
                    .Cells("DesdeEspecif").Value = WDesdeEspecif
                    .Cells("HastaEspecif").Value = WHastaEspecif
                    .Cells("UnidadEspecif").Value = WUnidadEspecif
                    .Cells("MenorIgualEspecif").Value = WMenorIgualEspecif
                    .Cells("InformaEspecif").Value = WInformaEspecif
                    .Cells("Parametro").Value = Trim(WImpreParametro)
                End With
                WRenglon += 1
            End With

        Next
    End Sub
End Class