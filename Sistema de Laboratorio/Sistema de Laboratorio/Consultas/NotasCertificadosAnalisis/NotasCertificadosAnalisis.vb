Public Class NotasCertificadosAnalisis

    Private WArticulo As String = ""
    Private WEsArticulo As Boolean = False
    Private WTerminado As String = ""
    Dim Base As String = Operador.Base
    Dim Tabla As String = "CargaVNotas"

    Sub New(ByVal Terminado As String, Optional ByVal EsArticulo As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If EsArticulo = True Then
            WArticulo = Terminado
            WEsArticulo = EsArticulo
            Tabla = "CargaVNotasMP"
        End If

        WTerminado = Terminado
    End Sub

    Private Sub NotasCertificadosAnalisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Base <> "Surfactan_III" Then
            Base = "Surfactan_II"
            If WEsArticulo = True Then
                Tabla = "CargaVNoFarmaNotasMP"
            Else
                Tabla = "CargaVNoFarmaNotas"
            End If

        End If

        _CargarNotas()
        'dgvNotas.CurrentCell = dgvNotas.Rows(0).Cells("ID")
        'dgvNotas.Focus()

    End Sub

    Private Sub _CargarNotas()

        dgvNotas.Rows.Clear()

        

        Dim WNotas As New DataTable
        If WEsArticulo = True Then
            WNotas = GetAll("SELECT * FROM " & Tabla & " WHERE Articulo = '" & WArticulo & "' ORDER BY Articulo, Nota, Renglon", Base)
        Else
            WNotas = GetAll("SELECT * FROM " & Tabla & " WHERE Terminado = '" & WTerminado & "' ORDER BY Terminado, Nota, Renglon", Base)
        End If

        Dim Auxi As String = ""
        Dim Auxi2 As String = ""
        Dim WID As String = ""
        Dim WObservacion As String = ""

        For Each row As DataRow In WNotas.Rows
            With row

                WID = OrDefault(.Item("Nota"), "")
                WObservacion = OrDefault(.Item("Observacion"), "")

                If Auxi = "" Then Auxi = WID

                If Auxi <> WID Then

                    Dim _r = dgvNotas.Rows.Add

                    dgvNotas.Rows(_r).Cells("ID").Value = Auxi

                    dgvNotas.Rows(_r).Cells("Nota").Value = Auxi2

                    Auxi2 = ""
                    Auxi = WID
                
                End If

                Auxi2 &= WObservacion

            End With
        Next

        If Val(Auxi) <> 0 And Trim(Auxi2) <> "" Then

            Dim _r = dgvNotas.Rows.Add

            dgvNotas.Rows(_r).Cells("ID").Value = Auxi

            dgvNotas.Rows(_r).Cells("Nota").Value = Auxi2

        End If

        txtObservacion.Focus()

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Está seguro de querer salir? Todos los datos que no se hayan grabado se perderán.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'dgvNotas.Rows.Clear()
        lblIdNota.Text = ""
        txtObservacion.Text = ""

        txtObservacion.Focus()

    End Sub

    Private Sub NotasCertificadosAnalisis_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtObservacion.Focus()
    End Sub

    Private Sub dgvNotas_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvNotas.CellMouseClick
        With dgvNotas

            Dim WId As String = OrDefault(.CurrentRow.Cells("ID").Value, "")

            Dim WNota As New DataTable
            If WEsArticulo = True Then
                WNota = GetAll("SELECT Observacion FROM " & Tabla & " WHERE Articulo = '" & WArticulo & "' And Nota = '" & WId & "' ORDER BY Renglon", Base)
            Else
                WNota = GetAll("SELECT Observacion FROM " & Tabla & " WHERE Terminado = '" & WTerminado & "' And Nota = '" & WId & "' ORDER BY Renglon", Base)
            End If


            txtObservacion.Text = ""

            For Each row As datarow In WNota.Rows
                With row
                    txtObservacion.Text &= Trim(OrDefault(.Item("Observacion"), ""))
                End With
            Next

            lblIdNota.Text = WId

            txtObservacion.Focus()
            txtObservacion.SelectionStart = txtObservacion.Text.Length
            txtObservacion.SelectionLength = 0

        End With
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If txtObservacion.Text.Trim = "" Then Exit Sub

        txtObservacion.Text = txtObservacion.Text.Replace("'", "").Replace(",", "").Replace(vbCr, "").Replace(vbLf, "")

        txtObservacion.Text = txtObservacion.Text.PadRight(300, " ")

        Dim WIdNota As Integer = Val(lblIdNota.Text)

        '
        ' En caso de que sea una nueva Nota, busco el próximo numero de Identificación.
        '
        If WIdNota = 0 Then

            Dim WUlt As DataRow
            If WEsArticulo = True Then
                WUlt = GetSingle("SELECT Max(Nota) Ultimo FROM " & Tabla & " WHERE Articulo = '" & WArticulo & "'", Base)

            Else
                WUlt = GetSingle("SELECT Max(Nota) Ultimo FROM " & Tabla & " WHERE Terminado = '" & WTerminado & "'", Base)

            End If

            If WUlt IsNot Nothing Then WIdNota = OrDefault(WUlt.Item("Ultimo"), 0)

            WIdNota += 1

        End If

        Dim WConsulta As New List(Of String)

        If WEsArticulo = True Then
            WConsulta.Add("DELETE FROM " & Tabla & " WHERE Articulo = '" & WArticulo & "' and Nota = '" & WIdNota & "'")
        Else
            WConsulta.Add("DELETE FROM " & Tabla & " WHERE Terminado = '" & WTerminado & "' and Nota = '" & WIdNota & "'")
        End If

        Dim WRenglon = 0

        For i = 0 To 2

            Dim WObservacion As String = Mid(txtObservacion.Text, i * 100 + 1, 100)

            If Trim(WObservacion) <> "" Then

                WRenglon += 1

                If WEsArticulo Then
                    Dim WClave As String = WArticulo & WIdNota.ToString.PadLeft(2, "0") & WRenglon.ToString.PadLeft(2, "0")

                    WConsulta.Add(String.Format("INSERT INTO " & Tabla & " (Clave, Articulo, Nota, Renglon, Observacion) VALUES ('{0}','{1}','{2}','{3}','{4}')", WClave, WArticulo, WIdNota, WRenglon, Trim(WObservacion)))

                Else
                    Dim WClave As String = WTerminado & WIdNota.ToString.PadLeft(2, "0") & WRenglon.ToString.PadLeft(2, "0")

                    WConsulta.Add(String.Format("INSERT INTO " & Tabla & " (Clave, Terminado, Nota, Renglon, Observacion) VALUES ('{0}','{1}','{2}','{3}','{4}')", WClave, WTerminado, WIdNota, WRenglon, Trim(WObservacion)))
                End If
                

            End If

        Next

        ExecuteNonQueries(Base, WConsulta.ToArray)

        btnLimpiar.PerformClick()

        _CargarNotas()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Val(lblIdNota.Text) = 0 Then
            txtObservacion.Focus()
            Exit Sub
        End If

        If MsgBox("¿Desea eliminar la nota actual para el Producto Terminado '" & WTerminado & "'?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            txtObservacion.Focus()
            Exit Sub
        End If

        If WEsArticulo = True Then
            ExecuteNonQueries(Base, {"DELETE FROM " & Tabla & " WHERE Articulo = '" & WArticulo & "' And Nota = '" & lblIdNota.Text & "'"})

        Else
            ExecuteNonQueries(Base, {"DELETE FROM " & Tabla & " WHERE Terminado = '" & WTerminado & "' And Nota = '" & lblIdNota.Text & "'"})

        End If

        btnLimpiar.PerformClick()

        _CargarNotas()

    End Sub
End Class