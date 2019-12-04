Imports ConsultasVarias

Public Class EmisionCertificadoAnalisis : Implements IAyudaGeneral

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        For Each c As Control In {txtCliente, txtPartida, lblCantidad, lblDescCliente, lblDescProducto, lblDescProductocliente, lblTerminado}
            c.Text = ""
        Next
        cmbIdioma.SelectedIndex = 0
        cmbTipoSalida.SelectedIndex = 0

        txtPartida.Focus()
    End Sub

    Private Sub EmisionCertificadoAnalisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub EmisionCertificadoAnalisis_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtPartida.Focus()
    End Sub

    Private Sub txtCliente_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCliente.MouseDoubleClick
        Dim WCliente As DataTable = GetAll("SELECT Cliente Codigo, Razon Descripcion FROM Cliente WHERE Razon <> '' ORDER BY Razon")
        With New AyudaGeneral(WCliente)
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub _ProcesarAyudaGeneral(ByVal row As DataGridViewRow) Implements IAyudaGeneral._ProcesarAyudaGeneral
        txtCliente.Text = row.Cells("Codigo").Value
        lblDescCliente.Text = row.Cells("Descripcion").Value
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        '
        ' Buscamos la Información del Cliente.
        '
        Dim WCliente As DataRow = GetSingle("SELECT * FROM Cliente WHERE Cliente = '" & txtCliente.Text & "'", "SurfactanSA")

        If WCliente Is Nothing Then
            MsgBox("El Cliente no es válido", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' Buscamos la Información de la Prueba.
        '
        Dim WPrueterFarma As DataTable = GetAll("SELECT * FROM PrueterFarma WHERE Partida = '" & txtPartida.Text & "' ORDER BY Renglon")

        If WPrueterFarma.Rows.Count = 0 Then
            MsgBox("No se ha encontrado pruebas ingresadas para el Lote Indicado.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' Modificamos el idioma del Certificado en caso de que el Cliente tenga idioma inglés cargado en su Ficha. Sino, dejamos el que hayan indicado.
        '
        If OrDefault(WCliente.Item("Idioma"), 0) = 1 Then cmbIdioma.SelectedIndex = 1

        '
        ' Definimos las abreviaturas según idioma seleccionado.
        '
        Dim ZZMes() As String = _AbreviaturasMesesSegunIdioma(cmbIdioma.SelectedIndex)

        '
        ' Buscamos los datos del Alta de Certificado. En caso de no tener definido, buscamos los de Surfactan.
        '
        Dim WAltaCertificado As DataTable = GetAll("SELECT Renglon, Marca FROM AltaCertificadoFarma WHERE Terminado = '" & lblTerminado.Text & "' And Cliente = '" & txtCliente.Text & "' ORDER BY Renglon")
        If WAltaCertificado.Rows.Count = 0 Then WAltaCertificado = GetAll("SELECT Renglon, Marca FROM AltaCertificadoFarma WHERE Terminado = '" & lblTerminado.Text & "' And Cliente = 'S00102' ORDER BY Renglon")

        '
        ' Controlamos que por lo menos hayan cargado los genéricos.
        '
        If WAltaCertificado.Rows.Count = 0 Then
            MsgBox("No se encuentra definido el Certificado de Análisis para este Producto.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        '
        ' Cargo los datos de CargaV.
        '
        Dim WCargaV As DataTable = GetAll("SELECT * FROM CargaV WHERE Terminado = '" & lblTerminado.Text & "' And Paso = '99'")

        '
        ' En caso de que sea Inglés el Idioma definido, se reemplaza los valores y unidades.
        '
        If cmbIdioma.SelectedIndex = 1 Then
            Dim WCargaVIngles As DataTable = GetAll("SELECT * FROM CargaVIngles WHERE Terminado  = '" & lblTerminado.Text & "' And Paso = '99' Order by Renglon")
            For Each row As DataRow In WCargaVIngles.Rows
                Dim fila() As DataRow = WCargaV.Select("Renglon = '" & row.Item("Renglon") & "'")

                If fila.Count > 0 Then
                    fila(0).Item("Valor") = row.Item("Valor")
                    fila(0).Item("UnidadesEspecif") = row.Item("UnidadesEspecif")
                End If
            Next

        End If

    End Sub

    Private Function _AbreviaturasMesesSegunIdioma(p1 As Integer) As String()

        Dim ZZMes() As String = New String(12) {}

        If cmbIdioma.SelectedIndex = 1 Then

            ZZMes(1) = "Jan."
            ZZMes(2) = "Feb."
            ZZMes(3) = "Mar."
            ZZMes(4) = "Apr."
            ZZMes(5) = "May"
            ZZMes(6) = "Jun."
            ZZMes(7) = "Jul."
            ZZMes(8) = "Aug."
            ZZMes(9) = "Sep."
            ZZMes(10) = "Oct."
            ZZMes(11) = "Nov."
            ZZMes(12) = "Dec."

        Else

            ZZMes(1) = "Enero"
            ZZMes(2) = "Febr."
            ZZMes(3) = "Marzo"
            ZZMes(4) = "Abril"
            ZZMes(5) = "Mayo "
            ZZMes(6) = "Junio"
            ZZMes(7) = "Julio"
            ZZMes(8) = "Agos."
            ZZMes(9) = "Sept."
            ZZMes(10) = "Oct. "
            ZZMes(11) = "Nov. "
            ZZMes(12) = "Dic. "

        End If
        Return ZZMes
    End Function

End Class