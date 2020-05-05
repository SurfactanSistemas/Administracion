Imports Util.Clases.Query

Public Class MostrarPTsXlinea
    Sub New(ByVal NroLineaVenta As Integer, ByVal NomLineaVenta As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtNroLineaVen.Text = NroLineaVenta
        txtNomLineaVen.Text = NomLineaVenta

        Dim SQLCnslt As String = "SELECT Codigo, Descripcion FROM Terminado WHERE Linea = '" & txtNroLineaVen.Text & "' ORDER BY Descripcion"
        Dim TablaTerminado As DataTable = GetAll(SQLCnslt)
        DGV_PTsXLinVen.DataSource = TablaTerminado
        LimpiarAcentos()
    End Sub



    Private Sub MostrarPTsXlinea_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscador.Focus()
    End Sub


    Private Sub txtBuscador_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscador.KeyUp
        Dim TablaTerminado As DataTable = DGV_PTsXLinVen.DataSource
        TablaTerminado.DefaultView.RowFilter = "Codigo LIKE '%" & txtBuscador.Text & "%' OR Descripcion LIKE '%" & txtBuscador.Text & "%'"
    End Sub



    Private Sub LimpiarAcentos()
        Dim TablaTerminados As DataTable = DGV_PTsXLinVen.DataSource
        For Each RowTerminado As DataRow In TablaTerminados.Rows
            RowTerminado.Item("Descripcion") = _QuitarAcentos(RowTerminado.Item("Descripcion"))
        Next

    End Sub
    Public Function _QuitarAcentos(ByVal strNombre As String) As String
        Const conAcentos = "áàäâÁÀÄÂéèëêÉÈËÊíìïîÍÌÏÎóòöôÓÒÖÔúùüûÚÙÜÛýÿÝ"
        Const sinAcentos = "aaaaAAAAeeeeEEEEiiiiIIIIooooOOOOuuuuUUUUyyY"
        Dim i As Integer
        For i = Len(conAcentos) To 1 Step -1
            strNombre = Replace(strNombre, Mid(conAcentos, i, 1), Mid(sinAcentos, i, 1))
        Next
        Return strNombre
    End Function
End Class