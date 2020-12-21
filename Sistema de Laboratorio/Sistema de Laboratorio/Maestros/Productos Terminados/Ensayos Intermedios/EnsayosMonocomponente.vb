Public Class EnsayosMonocomponente
    Private ReadOnly Producto As String
    Private ReadOnly LotePartida As String
    Private ReadOnly Tabla As String
    Private ReadOnly EsMP As Boolean

    Sub New(ByVal Producto As String, ByVal LotePartida As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Producto = Producto
        Me.LotePartida = LotePartida
        EsMP = Producto.Trim.Length = 10
        Tabla = IIf(EsMP, "PrueArtNuevo", "PrueterFarma")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub EnsayosMonocomponente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim WTablaDatos As String = IIf(EsMP, "Articulo", "Terminado")
        Dim WDatos As DataRow = GetSingle("SELECT Descripcion FROM " & WTablaDatos & " WHERE Codigo = '" & Producto & "'")

        If WDatos IsNot Nothing Then
            lblDescripcion.Text = UCase(Trim(OrDefault(WDatos.Item("Descripcion"), "")))
        End If

        lblProducto.Text = Producto
        lblLotePartida.Text = LotePartida

        _CargarDatosPT()

        Me.Location = New Point((Owner.Location.X + Owner.Width) - (Me.Width * 0.75), Owner.Location.Y + Owner.Height - Me.Height - 10)

    End Sub

    Private Sub _CargarDatosPT()

        Dim WPrueterFarma As DataTable

        If EsMP Then
            WPrueterFarma = GetAll("SELECT * FROM " & Tabla & " WHERE LotePartida = '" & LotePartida & "' And Producto = '" & Producto & "' Order By Clave")
        Else
            WPrueterFarma = GetAll("SELECT * FROM " & Tabla & " WHERE Partida = '" & LotePartida & "' And Producto = '" & Producto & "' Order By Clave")
        End If

        dgvEnsayos.Rows.Clear()

        If WPrueterFarma.Rows.Count = 0 Then Exit Sub

        For Each row As DataRow In WPrueterFarma.Rows
            With row
                Dim WEns = OrDefault(.Item("Codigo"), "")
                Dim WEspecificacion = OrDefault(.Item("Valor"), "")

                Dim WResultado As String
                Dim WFarmacopea = OrDefault(.Item("Farmacopea"), "")
                Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
                Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
                Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
                Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
                Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
                Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
                Dim WFormulaEspecif = OrDefault(.Item("FormulaEspecif"), "")
                Dim WImpreResultado = _GenerarImpreParametro(WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WTipoEspecif, WInformaEspecif)

                Dim WOperador = OrDefault(.Item("OperadorLabora"), "")
                Dim WValor = Trim(OrDefault(.Item("ValorReal"), ""))

                Dim WFormulas(10, 2) As String

                For i = 1 To 10
                    WFormulas(i, 1) = Trim(OrDefault(.Item("Variable" & i), ""))
                    WFormulas(i, 2) = Trim(OrDefault(.Item("VariableValor" & i), "0"))
                Next

                If Val(WTipoEspecif) = 0 And WImpreResultado <> "" Then WImpreResultado &= " (c)"

                Dim WDescripcion As String

                WResultado = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor, WMenorIgualEspecif, WInformaEspecif)

                Dim r = dgvEnsayos.Rows.Add

                With dgvEnsayos.Rows(r)
                    .Cells("Ensayo").Value = WEns
                    .Cells("Valor").Value = Trim(UCase(WValor))
                    .Cells("ValorBandera").Value = Trim(UCase(WValor))
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
                    .Cells("FormulaEspecif").Value = Trim(WFormulaEspecif)

                    .Cells("OperadorLabora").Value = Trim(WOperador)

                    Dim rowOP As DataRow = GetSingle("SELECT Iniciales FROM Operador WHERE Operador = '" & WOperador & "'", "SurfactanSa")
                    If rowOP IsNot Nothing Then
                        .Cells("OperadorIniciales").Value = OrDefault(rowOP.Item("Iniciales"), "")
                    Else
                        .Cells("OperadorIniciales").Value = ""
                    End If

                    For i = 1 To 10
                        .Cells("Variable" & i).Value = Trim(WFormulas(i, 1))
                        .Cells("VariableValor" & i).Value = WFormulas(i, 2)
                    Next

                    .Cells("Decimales").Value = ""

                    Dim WDecimales As String = .Cells("Decimales").Value

                    If WDecimales.Trim = "" Then
                        WDecimales = _CalcularCantidadDecimales(WDesdeEspecif)
                        If Val(WDecimales) < _CalcularCantidadDecimales(WHastaEspecif) Then WDecimales = _CalcularCantidadDecimales(WHastaEspecif)
                    End If

                    .Cells("Resultado").Value = WResultado
                    .Cells("Valor").Value = WValor

                    If Double.TryParse(WValor, Nothing) Then
                        .Cells("Valor").Value = formatonumerico(WValor, WDecimales)
                    End If

                    .Cells("Decimales").Value = WDecimales

                End With

            End With

        Next

    End Sub

    Private Function _CalcularCantidadDecimales(ByVal WValor As String, Optional ByVal _Default As Short = 0) As Short

        If Double.TryParse(WValor, Nothing) Then
            Dim aux As Integer = WValor.Trim.IndexOfAny({",", "."})

            If aux > 0 Then
                Dim t As String = _Right(WValor, WValor.Trim.Replace(".", "").Replace(",", "").Length - aux)
                Return t.Length
            End If
        End If

        Return _Default

    End Function

    Private Function _GenerarImpreParametro(ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String, ByVal WTipoEspecif As String, ByVal WInformaEspecif As String) As String
        If Val(WInformaEspecif) = 0 And Val(WTipoEspecif) = 2 Then Return "Informativo"
        If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 0 Then Return "Cumple Ensayo"
        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wDesdeEspecif = Trim(wDesdeEspecif)
        wHastaEspecif = Trim(wHastaEspecif)
        wUnidadEspecif = Trim(wUnidadEspecif)
        wMenorIgualEspecif = Trim(wMenorIgualEspecif)

        If {99, 999, 9999, 99999}.Contains(Val(wHastaEspecif)) Then wHastaEspecif = "9999"

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

    Private Function _GenerarImpreResultado(ByVal wTipoEspecif As Object, ByVal wDesdeEspecif As Object, ByVal wHastaEspecif As Object, ByVal wUnidadEspecif As Object, ByVal wValor As Object, ByVal WMenorIgualEspecif As String, ByVal WInformaEspecif As String) As Object

        If wValor = "" Then Return ""

        If UCase(Trim(wValor)) = "P" Then Return "PENDIENTE"

        wUnidadEspecif = Trim(wUnidadEspecif)
        wHastaEspecif = Trim(wHastaEspecif)

        If Val(wTipoEspecif) = 1 Or Val(wTipoEspecif) = 2 Then

            If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 9999 Then Return "CUMPLE"

            Dim WValido As Double = 0

            If Not Double.TryParse(wValor.ToString, WValido) Then Return ""

            Dim WDecimales As Short = _CalcularCantidadDecimales(wDesdeEspecif, 0)

            If WDecimales < _CalcularCantidadDecimales(wHastaEspecif, 0) Then WDecimales = _CalcularCantidadDecimales(wHastaEspecif, 0)

            wValor = formatonumerico(wValor, WDecimales)

            Return String.Format("{0} {1}", wValor, wUnidadEspecif)
        ElseIf Val(wTipoEspecif) = 0 And Val(WMenorIgualEspecif) = 1 And Val(WInformaEspecif) = 1 Then
            Return String.Format("< {0} {1}", wHastaEspecif, wUnidadEspecif)
        Else

            Select Case UCase(wValor)
                Case "S"
                    Return "CUMPLE"
                Case "N"
                    Return "NO CUMPLE"
                Case Else
                    Return ""
            End Select

        End If

    End Function


    Private Sub dgvEnsayos_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEnsayos.RowHeaderMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IEnsayosMonoComponente = TryCast(Owner, IEnsayosMonoComponente)

        If WOwner IsNot Nothing Then WOwner._ProcesarEnsayosMonoComponente(dgvEnsayos.CurrentRow)

    End Sub
End Class