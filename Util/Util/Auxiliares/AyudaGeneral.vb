Public Class AyudaGeneral

    Private ReadOnly Datos As DataTable = Nothing
    Private ReadOnly Titulo As String = ""

    Sub New(ByVal Datos As DataTable, Optional ByVal Titulo As String = "AYUDA")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Datos = Datos
        Me.Titulo = Titulo

    End Sub

    Private Sub AyudaGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTitulo.Text = Titulo
        dgvDatos.DataSource = Datos
    End Sub

    Private Sub AyudaGeneral_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Dim Tabla As DataTable = TryCast(dgvDatos.DataSource, DataTable)

        If Tabla IsNot Nothing Then Tabla.DefaultView.RowFilter = String.Format("Convert(Codigo, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", TextBox1.Text)

    End Sub

    Private Sub dgvDatos_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.CellMouseDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim WOwner As IAyudaGeneral = TryCast(Owner, IAyudaGeneral)

        If WOwner IsNot Nothing Then
            Hide()
            WOwner._ProcesarAyudaGeneral(dgvDatos.CurrentRow)
        End If

        Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class