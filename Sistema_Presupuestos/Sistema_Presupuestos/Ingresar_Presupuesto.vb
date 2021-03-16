﻿Imports GestorDeArchivos
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper
Imports Util.Clases.Conexion

Public Class Ingresar_Presupuesto : Implements IAyudaProv



    Sub New(ByVal NroPresupuesto As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If NroPresupuesto = 0 Then
            txt_NroPresupuesto.Text = ObtenerNroPresupuesto()
            txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")
            cbx_Moneda.SelectedIndex = 0
        Else
            txt_NroPresupuesto.Text = NroPresupuesto
            Try
                Dim SQLCnslt As String = "SELECT * FROM SolicitudPresupuesto WHERE NroPresupuesto = '" & NroPresupuesto & "'"
                Dim RowPresu As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                If RowPresu IsNot Nothing Then
                    txt_Codigo_Prov.Text = RowPresu.Item("Proveedor")
                    txt_Descrip_Prov.Text = RowPresu.Item("ProvDescp")
                    txt_Descripcion.Text = RowPresu.Item("Descripcion")
                    txt_Fecha.Text = RowPresu.Item("Fecha")
                    txt_Titulo.Text = RowPresu.Item("Titulo")
                    txt_FormaPago.Text = RowPresu.Item("FormaPago")
                    txt_Monto.Text = RowPresu.Item("Monto")
                    cbx_Moneda.SelectedIndex = RowPresu.Item("Moneda")
                End If

            Catch ex As Exception

            End Try
        End If



    End Sub

    Private Function ObtenerNroPresupuesto() As Integer
        Dim SQLCnslt As String = "SELECT NroMax = Max(NroPresupuesto) + 1 FROM SolicitudPresupuesto"
        Dim RowSol As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

        If RowSol IsNot Nothing Then
            Dim Maxsoli As Integer = Val(IIf(IsDBNull(RowSol.Item("NroMax")), 0, RowSol.Item("NroMax")))
            Return Maxsoli + 1
        End If
    End Function



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Codigo_Prov.KeyPress, txt_NroPresupuesto.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Monto.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub

    Private Sub Ingresar_Presupuesto_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txt_Codigo_Prov.Focus()
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Close()
    End Sub

    Private Sub txt_Codigo_Prov_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Codigo_Prov.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Codigo_Prov.Text = "" Then
                    With New Consulta_Proveedor
                        .Show(Me)
                    End With
                Else
                    If txt_Codigo_Prov.Text.Length = 11 Then
                        cargarprov(txt_Codigo_Prov.Text)
                    End If
                End If

            Case Keys.Escape
                txt_Codigo_Prov.Text = ""
        End Select
    End Sub

    Private Sub cargarprov(ByVal Prov As String)
        Dim SQLCnslt As String = "SELECT Nombre FROM Proveedor WHERE Proveedor = '" & Trim(txt_Codigo_Prov.Text) & "'"
        Dim RowProv As DataRow = GetSingle(SQLCnslt, "SurfactanSa")
        If RowProv IsNot Nothing Then
            txt_Descrip_Prov.Text = Trim(RowProv.Item("Nombre"))
            txt_Titulo.Focus()
        End If
    End Sub

    Private Sub txt_Codigo_Prov_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txt_Codigo_Prov.MouseDoubleClick
        With New Consulta_Proveedor
            .Show(Me)
        End With
    End Sub

    Public Sub PasaProve(Codigo As String, Descripcion As String) Implements IAyudaProv.PasaProve
        txt_Codigo_Prov.Text = Trim(Codigo)
        txt_Descrip_Prov.Text = Trim(Descripcion)
        txt_Titulo.Focus()
    End Sub

    Private Sub txt_Titulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Titulo.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Titulo.Text <> "" Then
                    txt_Descripcion.Focus()
                End If
            Case Keys.Escape
                txt_Titulo.Text = ""
        End Select
    End Sub

    Private Sub txt_Descripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Descripcion.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_Descripcion.Text <> "" Then
                    txt_FormaPago.Focus()
                End If
            Case Keys.Escape
                txt_Descripcion.Text = ""
        End Select
    End Sub

    Private Sub txt_FormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_FormaPago.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If txt_FormaPago.Text <> "" Then
                    txt_Monto.Focus()
                End If
            Case Keys.Escape
                txt_FormaPago.Text = ""
        End Select
    End Sub

    Private Sub txt_Monto_MouseLeave(sender As Object, e As EventArgs) Handles txt_Monto.MouseLeave
        If Val(txt_Monto.Text) > 0 Then
            txt_Monto.Text = formatonumerico(txt_Monto.Text)
        End If
    End Sub


    Private Sub txt_Monto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Monto.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If Val(txt_Monto.Text) > 0 Then
                    txt_Monto.Text = formatonumerico(txt_Monto.Text)
                End If
            Case Keys.Escape
                txt_Monto.Text = ""
        End Select
    End Sub


    Private Sub btn_Grabar_Click(sender As Object, e As EventArgs) Handles btn_Grabar.Click
        If Val(Trim(txt_Monto.Text)) <= 0 Then
            MsgBox("El monto debe ser superior a 0", vbExclamation)
            Exit Sub
        End If
        If Trim(txt_Titulo.Text) = "" Then
            MsgBox("El titulo no puede estar vacio", vbExclamation)
            Exit Sub
        End If
        If Trim(txt_Descripcion.Text) = "" Then
            MsgBox("La descripcion no puede estar vacia", vbExclamation)
            Exit Sub
        End If
        If Trim(txt_FormaPago.Text) = "" Then
            MsgBox("Debe especificar la forma de pago", vbExclamation)
            Exit Sub
        End If
        If Trim(txt_Codigo_Prov.Text) = "" Then
            MsgBox("Se debe especificar un proveedor", vbExclamation)
            Exit Sub
        End If


        'Obtener con solicitando la clave
        Dim QuienGraba As String = Operador.Clave

        Try
            Dim SQLCnslt As String = "DELETE FROM SolicitudPresupuesto WHERE NroPresupuesto = '" & Trim(txt_NroPresupuesto.Text) & "'"
            ExecuteNonQueries("SurfactanSa", SQLCnslt)

            SQLCnslt = "INSERT INTO SolicitudPresupuesto (NroPresupuesto, Fecha, OrdFecha, Proveedor, ProvDescp, Titulo, Descripcion, FormaPago, Moneda, Monto, QuienAprobo, Estado ) " _
                        & "VALUES('" & txt_NroPresupuesto.Text & "', '" & txt_Fecha.Text & "', '" & ordenaFecha(txt_Fecha.Text) & "', '" & txt_Codigo_Prov.Text & "', '" & txt_Descrip_Prov.Text & "', " _
                        & "'" & Trim(txt_Titulo.Text) & "', '" & Trim(txt_Descripcion.Text) & "', '" & Trim(txt_FormaPago.Text) & "', '" & cbx_Moneda.SelectedIndex & "', '" & formatonumerico(txt_Monto.Text) & "', '" & QuienGraba & "', '" & "Pendiente" & "')"

            ExecuteNonQueries("SurfactanSa", SQLCnslt)

            Dim Wowner As IActualzarDGV = TryCast(Owner, IActualzarDGV)

            If Wowner IsNot Nothing Then
                Wowner.RefrescaDGV()
            End If

            Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_CerrarPresupuesto_Click(sender As Object, e As EventArgs) Handles btn_CerrarPresupuesto.Click
        Try
            Dim SQLCnslt As String = "UPDATE SolicitudPresupuesto SET Estado = 'Cerrada' WHERE NroPresupuesto = '" & txt_NroPresupuesto.Text & "'"

            ExecuteNonQueries("SurfactanSa", SQLCnslt)

            Dim Wowner As IActualzarDGV = TryCast(Owner, IActualzarDGV)

            If Wowner IsNot Nothing Then
                Wowner.RefrescaDGV()
            End If

            Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Adjuntar_Click(sender As Object, e As EventArgs) Handles btn_Adjuntar.Click

        Dim WPath As String = "\\193.168.0.2\g$\vb\NET\ArchivosRelacionados_SolicitudesPresupuestos\Presu_" & Trim(txt_NroPresupuesto.Text)
        With New EditorArchivos(2, WPath, Operador.Clave)
            .Show()
        End With
    End Sub


End Class