Imports System.Text.RegularExpressions

Public Class AltaMotivoINCMP
    Property TipoResponsableBloqueados As Boolean
    Property Proveedor As String = ""
    Property DescProveedor As String = ""
    Property Orden As String = ""
    Property Titulo As String = ""
    Property Lote As String = ""
    Property LotePrv As String = ""
    Property Codigo As String = ""
    Property Empresa As String = ""
    Property Fecha As String = ""
    Property NumeroINC As String = ""
    Property ClaveSac As String = ""
    Property Tipo As String = ""
    Property Año As String = ""
    Property NumeroTipo As String = ""
    Property ResultadosFueraEspecif As String = ""

    Private WSaltos As New Dictionary(Of Control, Control)

    Private Sub AltaMotivoINCMP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _PrepararSaltos()

        If Fecha = "" Then Fecha = Date.Now.ToString("dd/MM/yyyy")
        Año = _Right(Fecha, 4)

        If Empresa = "" Then Empresa = Operador.IDBase

        '
        ' Cargamos los Tipos de INC.
        '
        Dim WTipos As DataTable = GetAll("SELECT Codigo, UPPER(Descripcion) Descripcion FROM TiposINC Order By Codigo", "SurfactanSa")

        With cmbTipo
            .DataSource = WTipos
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            If .Items.Count > 0 Then .SelectedIndex = 0
        End With

        '
        ' Cargamos los posibles Responsables de INC.
        '
        Dim WResponsables As DataTable = GetAll("SELECT Codigo, UPPER(Descripcion) Descripcion FROM ResponsableINC Order By Descripcion", "SurfactanSa")

        With cmbResponsable
            .DataSource = WResponsables
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
            If .Items.Count > 0 Then .SelectedItem = WTipos.Select("Descripcion = 'S.VARELA'")(0).Item("Codigo")
        End With

        cmbTipo.Enabled = Not Me.TipoResponsableBloqueados
        cmbResponsable.Enabled = Not Me.TipoResponsableBloqueados

        If ClaveSac <> "" AndAlso ClaveSac.Length = 14 Then
            Tipo = _Left(ClaveSac, 4)
            Año = Mid(ClaveSac, 5, 4)
            NumeroINC = _Right(ClaveSac, 6)
        End If

        '
        ' Verifico Preexistencia del INC.
        '
        Dim WINC As DataRow = GetSingle("SELECT Titulo, Referencia, Motivos, Responsable, TipoInc, NroIncidencia,  FROM CargaIncidencias WHERE Incidencia = '" & NumeroINC & "'", "SurfactanSa")

        If WINC IsNot Nothing Then
            With WINC

                txtTitulo.Text = Trim(OrDefault(.Item("Titulo"), ""))
                txtReferencia.Text = Trim(OrDefault(.Item("Referencia"), ""))
                txtMotivos.Text = Trim(OrDefault(.Item("Motivos"), ""))

                Dim _Resp, _Tipo As String

                _Resp = Val(OrDefault(.Item("Responsable"), ""))
                _Tipo = Val(OrDefault(.Item("TipoInc"), ""))

                If Val(_Resp) > 0 And cmbResponsable.Items.Count > 0 Then cmbResponsable.SelectedItem = TryCast(cmbResponsable.DataSource, DataTable).Select("Codigo = '" & _Resp & "'")(0).Item("Codigo")
                If Val(_Tipo) > 0 And cmbTipo.Items.Count > 0 Then cmbTipo.SelectedItem = TryCast(cmbTipo.DataSource, DataTable).Select("Codigo = '" & _Resp & "'")(0).Item("Codigo")

            End With
        End If

        If Val(Orden) > 0 Then
            Dim WOrden As DataRow = GetSingle("SELECT o.Proveedor, p.Nombre FROM Orden o INNER JOIN Proveedor p ON p.Proveedor = o.Proveedor WHERE o.Orden = '" & Orden & "' And o.Renglon = 1")

            If WOrden IsNot Nothing Then
                With WOrden
                    Proveedor = OrDefault(.Item("Proveedor"), "")
                    DescProveedor = Trim(OrDefault(.Item("Nombre"), "")).ToUpper
                End With
            End If

        End If

        '
        ' Cargo los datos por defecto en los datos que no tenga nada cargado.
        '
        If txtTitulo.Text.Trim = "" Then txtTitulo.Text = Codigo & " x "
        If txtReferencia.Text.Trim = "" Then txtReferencia.Text = "Rec. a Prov: " & DescProveedor & " x " & Codigo

        '
        ' Forzamos que el titulo tenga si o si el código de la MP.
        '
        If Not txtTitulo.Text.Contains(Codigo) Then txtTitulo.Text = Codigo & " x " & txtTitulo.Text

        '
        ' Genero el string de Ensayos fuera de Especif.
        '
        If txtMotivos.Text.Trim = "" Then

            Dim WResFueraEspecif As String = _GenerarEnsayosFueraEspecif()

            If WResFueraEspecif.Trim <> "" Then
                
                txtMotivos.Text &= "--------------------------------------------------------------------" & vbCrLf
                txtMotivos.Text &= " ENSAYOS FUERA DE ESPECIFICACIÓN:" & vbCrLf
                txtMotivos.Text &= "--------------------------------------------------------------------" & vbCrLf & vbCrLf
                txtMotivos.Text &= vbCrLf & WResFueraEspecif

            End If

        End If

        Dim WTieneINCAsociado As Boolean = False
        Dim WTieneSACAsociada As Boolean = ClaveSac <> "" AndAlso ClaveSac.Trim.Trim.Length

        Dim WLaudo As DataRow = GetSingle("SELECT NroIncidencia FROM Laudo WHERE Laudo = '" & Lote & "'")

        Dim WINCAsociado As Integer = Val(OrDefault(WLaudo.Item("NroIncidencia"), ""))
        WTieneINCAsociado = WLaudo IsNot Nothing AndAlso WINCAsociado <> 0

        NumeroINC = WINCAsociado

        Dim WSqls As New List(Of String)

        If Not WTieneINCAsociado And Not WTieneSACAsociada Then
            Tipo = TryCast(cmbTipo.SelectedItem, DataRowView).Item("Codigo")

            '
            ' Damos de alta una nueva Incidencia, en caso de que no tenga una SAC asociada ni tenga una INC asociada.
            '
            Dim WProxINC As Integer = 0
            Dim WProxINCTipo As Integer = 0

            Dim WUltINC As DataRow = GetSingle("SELECT MAX(Incidencia) Ultimo FROM CargaIncidencias", "SurfactanSa")
            Dim WUltINCTipo As DataRow = GetSingle("SELECT MAX(Numero) Ultimo FROM CargaIncidencias WHERE Ano = '" & Año & "' AND TipoINC = '" & Tipo & "'", "SurfactanSa")

            If WUltINC IsNot Nothing Then WProxINC = Val(OrDefault(WUltINC.Item("Ultimo"), ""))
            If WUltINCTipo IsNot Nothing Then WProxINCTipo = Val(OrDefault(WUltINCTipo.Item("Ultimo"), ""))

            WProxINC += 1
            WProxINCTipo += 1

            NumeroINC = WProxINC

            Dim ZSql As String = ""

            ZSql &= " INSERT INTO CargaIncidencias "
            ZSql &= " (Incidencia, Numero, Renglon, Tipo, TipoINC, Ano, Fecha, FechaOrd, Estado, Titulo, Referencia, Producto, Lote, ClaveSAC, TipoProd, Empresa, Orden, Proveedor, Motivos) "
            ZSql &= " VALUES ("
            ZSql &= "'" & Trim(WProxINC) & "'," ' Incidencia
            ZSql &= "'" & Trim(WProxINCTipo) & "'," ' Numero
            ZSql &= "'" & "1" & "'," ' Renglon
            ZSql &= "'2'," ' Tipo
            ZSql &= "'" & Trim(Tipo) & "'," ' TipoINC
            ZSql &= "'" & Trim(Año) & "'," ' Anio
            ZSql &= "'" & Fecha & "'," ' Fecha
            ZSql &= "'" & ordenaFecha(Fecha) & "'," ' FechaOrd
            ZSql &= "'" & "0" & "'," ' Estado
            ZSql &= "'" & Trim(txtTitulo.Text) & "'," ' titulo
            ZSql &= "'" & Trim(txtReferencia.Text) & "'," ' referecnia
            ZSql &= "'" & Codigo & "'," ' Producto
            ZSql &= "'" & Trim(Lote) & "'," ' Lote
            ZSql &= "'" & "" & "'," ' ClaveSac
            ZSql &= "'" & "M" & "'," ' TipoProd
            ZSql &= "'" & Operador.IDBase & "'," ' Empresa
            ZSql &= "'" & Orden & "'," ' Orden
            ZSql &= "'" & Proveedor & "'," ' Proveedor
            ZSql &= "'" & Trim(txtMotivos.Text) & "'" & ")" & "" ' PosiblesUsos

            WSqls.Add(ZSql)

        End If

        WSqls.Add("UPDATE " & Operador.Base & ".dbo.Laudo SET ClaveSac = '" & ClaveSac & "' And NroIncidencia = '" & NumeroINC & "' WHERE Laudo = '" & Lote & "'")

        ExecuteNonQueries("SurfactanSa", WSqls.ToArray)

    End Sub

    Private Sub _PrepararSaltos()
        WSaltos.Add(txtTitulo, txtReferencia)
        WSaltos.Add(txtReferencia, txtMotivos)

        For Each pair As KeyValuePair(Of Control,Control) In WSaltos
            AddHandler pair.Key.KeyDown, AddressOf txtTitulo_KeyDown
        Next
    End Sub

    Private Function _GenerarEnsayosFueraEspecif() As String
        Dim WTexto As New List(Of String)

        Dim WPruArt As DataTable = GetAll("SELECT * FROM PrueArtNuevo WHERE Prueba = '" & Lote & "'")

        For Each row As Datarow In WPruArt.Rows
            
            If Not _ValidarDato(row) Then WTexto.Add(_GenerarLineaFueraEspecif(row))

        Next

        If WTexto.Count > 0 Then Return String.Join(vbCrLf, WTexto)

        Return ""
    End Function

    Private Function _GenerarLineaFueraEspecif(ByVal row As DataRow) As String
        With row
            Dim WEspecificacion = OrDefault(.Item("Valor"), "")
            Dim WValor = Trim(OrDefault(.Item("ValorReal"), ""))
            Dim WTipoEspecif = OrDefault(.Item("TipoEspecif"), "")
            Dim WDesdeEspecif = OrDefault(.Item("DesdeEspecif"), "")
            Dim WHastaEspecif = OrDefault(.Item("HastaEspecif"), "")
            Dim WUnidadEspecif = OrDefault(.Item("UnidadEspecif"), "")
            Dim WMenorIgualEspecif = OrDefault(.Item("MenorIgualEspecif"), "")
            Dim WInformaEspecif = OrDefault(.Item("InformaEspecif"), "")
            Dim WImpreResultado = _GenerarImpreParametro(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WMenorIgualEspecif, WInformaEspecif)

            Dim WResultado = OrDefault(.Item("Resultado"), "") = _GenerarImpreResultado(WTipoEspecif, WDesdeEspecif, WHastaEspecif, WUnidadEspecif, WValor, WMenorIgualEspecif, WInformaEspecif)

            Return String.Format("{0} ({1}): {2} {3}", WEspecificacion, WImpreResultado, WResultado, WUnidadEspecif)
        End With

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

    Private Function _GenerarImpreParametro(ByVal wTipoEspecif As String, ByVal wDesdeEspecif As String, ByVal wHastaEspecif As String, ByVal wUnidadEspecif As String, ByVal wMenorIgualEspecif As String, ByVal WInformaEspecif As String) As String

        If Val(WInformaEspecif) = 0 And Val(wTipoEspecif) = 2 Then Return "Informativo"
        If Val(wDesdeEspecif) = 0 And Val(wHastaEspecif) = 0 Then Return "Cumple Ensayo"
        If Trim(wDesdeEspecif) = "" And Trim(wHastaEspecif) = "" Then Return ""

        wTipoEspecif = Trim(wTipoEspecif)
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

    Private Function _ValidarDato(ByVal row As DataRow) As Boolean

        With row

            Dim WTipo As String = OrDefault(.Item("TipoEspecif").Value, "")
            Dim WMenorIgual As String = OrDefault(.Item("MenorIgualEspecif").Value, "")
            Dim WMin As Double = Val(formatonumerico(OrDefault(.Item("DesdeEspecif").Value, ""), 10))
            Dim WMax As Double = Val(formatonumerico(OrDefault(.Item("HastaEspecif").Value, ""), 10))
            Dim WValor As String = OrDefault(.Item("Valor").Value, "")
            Dim WEns As String = OrDefault(.Item("Ensayo").Value, "")

            If WEns.Trim <> "" And WValor.Trim <> "" And WTipo.Trim <> "" Then

                If Val(WTipo) = 1 Or Val(WTipo) = 2 Then

                    If WValor.ToUpper <> "P" Then

                        If Not Regex.IsMatch(WValor, "(^[\-]?\d+[\.\,]?(\d+)?$)") Then Return False

                        Dim WValorNum As Double = Val(formatonumerico(WValor, 10))

                        If Val(WMenorIgual) = 0 And (WValorNum < WMin Or WValorNum > WMax) Then Return False

                        If Val(WMenorIgual) = 1 And (WValorNum < WMin Or WValorNum >= WMax) Then Return False

                    End If

                Else

                    If Not {"S", "P", "N"}.Contains(WValor.ToUpper) Then Return False

                End If

            End If

        End With
        Return True
    End Function

    Private Sub AltaMotivoINCMP_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtTitulo.Focus()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub txtTitulo_KeyDown(sender As Object, e As KeyEventArgs)

        Dim WControl As Control = TryCast(sender, Control)
        If WControl Is Nothing Then Exit Sub

        If e.KeyData = Keys.Enter Then

            If WSaltos.ContainsKey(WControl) Then WSaltos.Item(WControl).Focus()

        ElseIf e.KeyData = Keys.Escape Then
            WControl.Text = ""
        End If

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtTitulo.Text.Trim = "" Then MsgBox("Debe cargarse un titulo para el INC.", MsgBoxStyle.Critical) : Exit Sub
        If txtReferencia.Text.Trim = "" Then MsgBox("Debe cargarse una referencia para el INC.", MsgBoxStyle.Critical) : Exit Sub
        If txtMotivos.Text.Trim = "" Then MsgBox("Debe cargarse un motivo para el INC.", MsgBoxStyle.Critical) : Exit Sub

        Tipo = OrDefault(TryCast(cmbTipo.SelectedItem, DataRowView).Item("Codigo"), 0)
        Dim WResponsable As Short = OrDefault(TryCast(cmbResponsable.SelectedItem, DataRowView).Item("Codigo"), 0)

        ExecuteNonQueries("SurfactanSa", {String.Format("UPDATE CargaIncidencias SET Tipo = '{1}', Motivos = '{2}', Responsable = '{3}', Titulo = '{4}', Referencia = '{5}' WHERE Incidencia = '{0}'",
                                                        NumeroINC, Tipo, txtMotivos.Text.Trim, WResponsable, txtTitulo.Text.Trim, txtReferencia.Text.Trim)})

        Close()

    End Sub
End Class