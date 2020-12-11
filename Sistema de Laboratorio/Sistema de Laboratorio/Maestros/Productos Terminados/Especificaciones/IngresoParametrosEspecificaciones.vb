Public Class IngresoParametrosEspecificaciones : Implements IDefinicionFormulaEspecificacion


    Private WTipoEspecif As Integer
    Private WInformaEspecif As Integer
    Private WMenorIgualEspecif As Integer
    Private WUnidadEspecif As String
    Private WDesdeEspecif As String
    Private WHastaEspecif As String
    Private WFarmacopea As String
    Private WFormula As String
    Private WParametrosFormula(10) As String
    Private WEnsayo As String
    Private WDescEnsayo As String
    Private WParametro As String
    Private Terminado As String

    Sub New(ByVal Terminado As String, ByVal Ensayo As String, ByVal DescEnsayo As String, ByVal Parametro As String, ByVal Tipo As Integer, ByVal Informa As Integer, ByVal MenorIgual As Integer, ByVal Desde As String, ByVal Hasta As String, ByVal Unidad As String, ByVal Farmacopea As String, ByVal Formula As String, ByVal ParametrosFormula() As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WTipoEspecif = Tipo
        WInformaEspecif = Informa
        WMenorIgualEspecif = MenorIgual
        WDesdeEspecif = Desde
        WHastaEspecif = Hasta
        WUnidadEspecif = Unidad
        WFarmacopea = Farmacopea
        WEnsayo = Ensayo
        WDescEnsayo = DescEnsayo
        WParametro = Parametro
        WParametrosFormula = ParametrosFormula
        WFormula = Formula
        Me.Terminado = Terminado

    End Sub

    Private Sub IngresoParametrosEspecificaciones_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        txtEnsayo.Text = Trim(WEnsayo)
        txtDescEnsayo.Text = Trim(WDescEnsayo)
        txtParametro.Text = Trim(WParametro)
        txtFarmacopea.Text = Trim(WFarmacopea)
        txtFormula.Text = Trim(WFormula)
        txtUnidad.Text = Trim(WUnidadEspecif)
        txtDesde.Text = WDesdeEspecif.ToString.Replace(",", ".")
        txtHasta.Text = WHastaEspecif.ToString.Replace(",", ".")
        rbCumpleNoCumple.Checked = WTipoEspecif = 0
        rbNumerico.Checked = WTipoEspecif = 1
        rbFormula.Checked = WTipoEspecif = 2
        ckMenorIgual.Checked = WMenorIgualEspecif = 1

        rbCumpleNoCumple_Click(Nothing, Nothing)

        ckInforma.Checked = WInformaEspecif = 1

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub txtParametro_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtParametro.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtParametro.Text) = "" Then : Exit Sub : End If

            txtFarmacopea.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtParametro.Text = ""
        End If

    End Sub

    Private Sub txtFarmacopea_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtFarmacopea.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtFarmacopea.Text) = "" Then : Exit Sub : End If

            If rbNumerico.Checked Then txtDesde.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtFarmacopea.Text = ""
        End If

    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDesde.KeyDown, txtFormula.KeyDown

        If e.KeyData = Keys.Enter Then
            'If Trim(txtDesde.Text) = "" Then : Exit Sub : End If

            If txtDesde.Text.Trim = "" Then txtDesde.Text = "0"

            txtHasta.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtDesde.Text = ""
        End If

    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHasta.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtHasta.Text) = "" Then txtHasta.Text = "99999"

            txtUnidad.Focus()

        ElseIf e.KeyData = Keys.Escape Then
            txtHasta.Text = ""
        End If

    End Sub

    Private Sub txtUnidad_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtUnidad.KeyDown

        If e.KeyData = Keys.Enter Then
            '    If Trim(txtUnidad.Text) = "" Then : Exit Sub : End If
            txtParametro.Focus()
        ElseIf e.KeyData = Keys.Escape Then
            txtUnidad.Text = ""
        End If

    End Sub

    Private Sub rbCumpleNoCumple_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbNumerico.Click, rbCumpleNoCumple.Click, rbFormula.Click
        txtDesde.Enabled = True
        txtHasta.Enabled = True
        txtUnidad.Enabled = True
        ckInforma.Enabled = True
        ckMenorIgual.Enabled = True
        txtFormula.Enabled = True
        ckInforma.Checked = True

        ckHabDesdeHasta.Visible = rbCumpleNoCumple.Checked

        btnDefinirFormula.Enabled = True

        For Each control As Control In {txtDesde, txtHasta, txtUnidad, ckInforma, ckMenorIgual, txtFormula, btnDefinirFormula}
            control.Enabled = Not rbCumpleNoCumple.Checked
        Next

        ckHabDesdeHasta.Checked = (Val(WDesdeEspecif) <> 0 Or Val(WHastaEspecif) <> 0) And WTipoEspecif = 0
        ckHabDesdeHasta_Click(Nothing, Nothing)

        If rbNumerico.Checked Then
            txtFormula.Enabled = False
            btnDefinirFormula.Enabled = False
            txtDesde.Enabled = True
            txtHasta.Enabled = True
            txtUnidad.Enabled = True
            txtDesde.Focus()
        ElseIf rbCumpleNoCumple.Checked Then
            txtDesde.Enabled = ckHabDesdeHasta.Checked
            txtHasta.Enabled = ckHabDesdeHasta.Checked
            txtUnidad.Enabled = ckHabDesdeHasta.Checked
            ckInforma.Checked = False

            txtParametro.Focus()
        Else
            ckHabDesdeHasta.Checked = True
            ckHabDesdeHasta_Click(Nothing, Nothing)
            ckInforma.Enabled = True
            ckInforma.Checked = True

            txtFormula.Focus()
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        '
        ' Validamos.
        '
        If txtParametro.Text = "" Then
            MsgBox("Debe indicarse una descripción del Parámetro.", MsgBoxStyle.Exclamation)
            txtParametro.Focus()
            Exit Sub
        End If

        If txtHasta.Text.StartsWith(".") Then txtHasta.Text = "0" & txtHasta.Text
        If txtDesde.Text.StartsWith(".") Then txtDesde.Text = "0" & txtDesde.Text

        WParametro = txtParametro.Text.Trim
        WFarmacopea = txtFarmacopea.Text.Trim
        Dim WTipo As Integer = 0
        Dim WInforma As Integer = IIf(ckInforma.Checked, 1, 0)
        Dim WMenorIgual As Integer = IIf(ckMenorIgual.Checked, 1, 0)
        Dim WDesde As String = txtDesde.Text
        Dim WHasta As String = txtHasta.Text
        Dim WUnidad As String = txtUnidad.Text

        WFormula = txtFormula.Text.Trim

        If rbNumerico.Checked Then WTipo = 1
        If rbFormula.Checked Then WTipo = 2

        If rbCumpleNoCumple.Checked Then
            WDesde = IIf(ckHabDesdeHasta.Checked, txtDesde.Text, "")
            WHasta = IIf(ckHabDesdeHasta.Checked, txtHasta.Text, "")
            WUnidad = IIf(ckHabDesdeHasta.Checked, txtUnidad.Text, "")
            WInforma = 1
            WMenorIgual = IIf(ckMenorIgual.Checked, 1, 0)
        End If

        Dim WOwner As IIngresoParametrosEspecificaciones = TryCast(Owner, IIngresoParametrosEspecificaciones)

        If WOwner IsNot Nothing Then WOwner._ProcesarIngresoParametrosEspecificaciones(WParametro, WTipo, WInforma, WMenorIgual, WDesde, WHasta, WUnidad, WFarmacopea, WFormula, WParametrosFormula)

        Close()
    End Sub

    Public Sub _ProcesarDefinicionFormulaEspecificacion(ByVal Formula As String, ByVal ParametrosFormula As String()) Implements IDefinicionFormulaEspecificacion._ProcesarDefinicionFormulaEspecificacion
        txtFormula.Text = Formula
        WParametrosFormula = ParametrosFormula
        txtFormula.Focus()
    End Sub

    Private Sub btnDefinirFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefinirFormula.Click
        Dim frm As New DefinicionFormulaEspecificacion(Terminado, txtFormula.Text, WParametrosFormula)
        frm.ShowDialog(Me)
    End Sub

    Private Sub ckHabDesdeHasta_Click(sender As Object, e As EventArgs) Handles ckHabDesdeHasta.Click
        txtDesde.Enabled = ckHabDesdeHasta.Checked
        txtHasta.Enabled = ckHabDesdeHasta.Checked
        txtUnidad.Enabled = ckHabDesdeHasta.Checked
        ckMenorIgual.Enabled = ckHabDesdeHasta.Checked

        If txtDesde.Enabled Then txtDesde.Focus()

    End Sub
End Class