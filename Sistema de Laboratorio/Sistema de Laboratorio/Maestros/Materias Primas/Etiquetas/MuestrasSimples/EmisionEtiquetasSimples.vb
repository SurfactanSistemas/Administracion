Imports ConsultasVarias.Clases
Imports CrystalDecisions.CrystalReports.Engine

Public Class EmisionEtiquetasSimples : Implements IAyudaMPDentroDeInforme

    Private Sub EmisionEtiquetasSimples_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDescMP.BackColor = Globales.WBackColorSecundario
        Button2_Click(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtAnalista, txtCantEtiq, txtCodigo, txtFecha, txtInforme, lblDescMP, txtLotePrv}
            c.Text = ""
        Next
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtInforme.Focus()
    End Sub

    Private Sub EmisionEtiquetasSimples_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtInforme.Focus()
    End Sub

    Private Sub txtInforme_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInforme.KeyDown

        If e.KeyData = Keys.Enter Then
            If Trim(txtInforme.Text) = "" Then : Exit Sub : End If

            With New AyudaMPsDentroDeInforme(txtInforme.Text)
                .Show(Me)
            End With

        ElseIf e.KeyData = Keys.Escape Then
            txtInforme.Text = ""
        End If

    End Sub

    Public Sub _ProcesarAyudaMPDentrodEInforme(ByVal Codigo As String, ByVal Descripcion As String, ByVal Cantidad As String, ByVal LotePrv As String) Implements IAyudaMPDentroDeInforme._ProcesarAyudaMPDentrodEInforme
        txtCodigo.Text = Codigo
        lblDescMP.Text = UCase(Descripcion)
        txtLotePrv.Text = LotePrv.ToUpper
        txtCantEtiq.Focus()
    End Sub

    Private Sub txtInforme_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtInforme.MouseDoubleClick
        txtInforme_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnEmitir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmitir.Click
        If DatosValidos() Then

            Dim WInforme, WArticulo, WDescripcion, WFecha, WCantEtiq, WAnalista, WLotePrv As String

            Dim DTEtiqueta As DataTable = New DBAuxi.EtiquetasSimplesDataTable
            Dim row As DataRow = Nothing
            Dim WCantidad As Integer = CalcularCantidadEtiquetas()
            Dim WLugar As Short = 0

            WInforme = txtInforme.Text
            WArticulo = txtCodigo.Text
            WDescripcion = lblDescMP.Text
            WFecha = txtFecha.Text
            WCantEtiq = txtCantEtiq.Text
            WAnalista = txtAnalista.Text.ToUpper
            WLotePrv = txtLotePrv.Text.ToUpper


            For i = 1 To WCantidad
                row = DTEtiqueta.NewRow
                WLugar += 1

                With row

                    .Item("Articulo") = WArticulo
                    .Item("Descripcion") = WDescripcion
                    .Item("Informe") = WInforme
                    .Item("Impre1") = String.Format("{0} / {1}", WLugar, WCantEtiq)
                    .Item("Impre2") = String.Format("Fecha: {0}", WFecha)
                    WLugar += 1
                    .Item("Impre3") = IIf(WLugar > Val(WCantEtiq), "", String.Format("{0} / {1}", WLugar, WCantEtiq))
                    .Item("Analista") = WAnalista
                    .Item("LotePrv") = WLotePrv

                End With

                DTEtiqueta.Rows.Add(row)

            Next

            Dim rpt As ReportDocument

            If WDescripcion.Length < 23 Then
                rpt = New ReporteEtiContra
            Else
                rpt = New ReporteEtiContraII
            End If

            rpt.SetDataSource(DTEtiqueta)

            With New VistaPrevia
                .Reporte = rpt
                .Mostrar()
            End With

        End If
    End Sub

    Private Function CalcularCantidadEtiquetas() As Integer

        Dim WCantidad As Integer = CInt(Val(txtCantEtiq.Text) / 2)
        If WCantidad * 2 <> Val(txtCantEtiq.Text) Then WCantidad += 1

        Return WCantidad

    End Function

    Private Function DatosValidos() As Boolean

        If Val(txtInforme.Text) = 0 Then Return False
        If txtCodigo.Text.Replace(" ", "").Length < 10 Then Return False
        If txtFecha.Text.Replace(" ", "").Length < 10 Then Return False
        If Val(txtCantEtiq.Text) = 0 Then Return False
        If Trim(txtAnalista.Text) = "" Then Return False

        Return True

    End Function
End Class