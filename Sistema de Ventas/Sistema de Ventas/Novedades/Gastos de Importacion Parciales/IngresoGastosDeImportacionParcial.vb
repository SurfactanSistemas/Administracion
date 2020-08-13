
Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class IngresoGastosDeImportacionParcial : Implements IGastosImpoParcial, IConsulta_GasImportacion

    Dim TablaArticulos As New DataTable


    Private Sub NumerosConComas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Importe.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (CChar(".")) = e.KeyChar Then
            e.Handled = True
        End If
    End Sub



    Private Sub SoloNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_NroMovimiento.KeyPress, txt_Carpeta.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txt_NroMovimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_NroMovimiento.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = "SELECT Fecha, Carpeta, Orden ,Empresa FROM MovGasParcial " _
                                         & "WHERE Codigo = '" & txt_NroMovimiento.Text & "'"
                Dim Row As DataRow = GetSingle(SQLCnslt, Operador.Base)

                If Row IsNot Nothing Then
                    txt_Fecha.Text = Row.Item("Fecha")
                    txt_Carpeta.Text = Row.Item("Carpeta")
                    txt_Orden.Text = Row.Item("Orden")
                    txt_Empresa.Text = Row.Item("Empresa")

                    Proceso()
                    txt_Concepto.Focus()

                Else
                    SQLCnslt = "Select Fecha, Carpeta ,Orden , Empresa FROM MovGasParcialArti " _
                        & "Where MovGasParcialArti.Codigo = '" & txt_NroMovimiento.Text & "'"
                    Dim ROW_ParArti As DataRow = GetSingle(SQLCnslt, Operador.Base)
                    If ROW_ParArti IsNot Nothing Then

                        txt_Fecha.Text = ROW_ParArti.Item("Fecha")
                        txt_Carpeta.Text = ROW_ParArti.Item("Carpeta")
                        txt_Orden.Text = ROW_ParArti.Item("Orden")
                        txt_Empresa.Text = ROW_ParArti.Item("Empresa")

                        Proceso()

                        txt_Concepto.Focus()
                    Else
                        '
                        Dim WCodigo As String = txt_NroMovimiento.Text
                        btn_Limpiar_Click(Nothing, Nothing)
                        txt_NroMovimiento.Text = WCodigo
                        txt_Fecha.Focus()



                    End If
                End If


            Case Keys.Escape
                txt_NroMovimiento.Text = ""
        End Select


    End Sub

    Private Sub txt_Fecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fecha.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                If ValidaFecha(txt_Fecha.Text) = "S" Then
                    txt_Carpeta.Focus()
                Else
                    MsgBox("La fecha ingresada es invalida, verifique")
                    txt_Fecha.SelectAll()
                End If
            Case Keys.Escape
                txt_Fecha.Text = ""
        End Select

    End Sub

    Private Sub txt_Carpeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Carpeta.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                Dim SQLCnslt As String = "SELECT Empresa FROM MovGas WHERE Carpeta = '" & txt_Carpeta.Text & "'"

                Dim RowCarpe As DataRow = GetSingle(SQLCnslt, Operador.Base)
                If RowCarpe IsNot Nothing Then
                    txt_Orden.Text = RowCarpe.Item("Orden")
                    txt_Empresa.Text = RowCarpe.Item("Empresa")

                    'Call Lee_Articulos()

                    txt_Concepto.Focus()
                Else
                    txt_Fecha.Focus()
                End If
            Case Keys.Escape
                txt_Carpeta.Text = ""
        End Select

    End Sub

    Private Sub Proceso()

        Dim SQLCnslt As String = "SELECT Concepto, Importe FROM MovGasParcial " _
                                & "WHERE Codigo = '" & txt_NroMovimiento.Text & "' ORDER BY Clave"

        Dim tabla As DataTable = GetAll(SQLCnslt, Operador.Base)

        If tabla.Rows.Count Then
            For Each Row As DataRow In tabla.Rows
                With Row
                    DGV_GastosImportacion.Rows.Add(.Item("Concepto"), "", formatonumerico(.Item("Importe"), 2))
                End With
            Next
        End If

        For Each DGV_Row As DataGridViewRow In DGV_GastosImportacion.Rows
            SQLCnslt = "SELECT Nombre FROM GasImpo WHERE Codigo = '" & DGV_Row.Cells("Concepto").Value & "'"
            Dim Row As DataRow = GetSingle(SQLCnslt, Operador.Base)
            If Row IsNot Nothing Then
                DGV_Row.Cells("Descripcion").Value = Row.Item("Nombre")
            End If

        Next



    End Sub

    Private Sub btn_Articulos_Click(sender As Object, e As EventArgs) Handles btn_Articulos.Click
        With New Articulos_GastosImportacionParcial(txt_NroMovimiento.Text)
            .Show(Me)
        End With
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click


        txt_fila.Text = ""
        txt_Concepto.Text = ""
        txt_Descripcion.Text = ""
        txt_Importe.Text = ""

        txt_NroMovimiento.Text = ""
        txt_Carpeta.Text = ""
        txt_Orden.Text = ""
        txt_Empresa.Text = ""
        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")

        TablaArticulos.Rows.Clear()

        DGV_GastosImportacion.Rows.Clear()


        Dim WCodigo1 As Integer
        Dim WCodigo2 As Integer

        Dim SQLCnslt As String = "SELECT MaxCodigo = MAX(Codigo) FROM MovGasParcial"

        Dim row As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If row IsNot Nothing Then
            WCodigo1 = IIf(IsDBNull(row.Item("MaxCodigo")), 0, row.Item("MaxCodigo"))
        End If


        SQLCnslt = "SELECT MaxCodigo = MAX(Codigo) FROM MovGasParcialArti"

        Dim row2 As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If row2 IsNot Nothing Then
            WCodigo2 = IIf(IsDBNull(row2.Item("MaxCodigo")), 0, row2.Item("MaxCodigo"))
        End If

        If WCodigo1 > WCodigo2 Then
            txt_NroMovimiento.Text = WCodigo1 + 1
        Else
            txt_NroMovimiento.Text = WCodigo2 + 1
        End If

        txt_NroMovimiento.Focus()

    End Sub

    Private Sub txt_Importe_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Importe.KeyDown

        Select Case e.KeyData
            Case Keys.Enter
                txt_Importe.Text = formatonumerico(txt_Importe.Text, 2)


                Carga_gastos()

            Case Keys.Escape
                txt_Importe.Text = ""
        End Select

    End Sub


    Private Sub Carga_gastos()

        If txt_fila.Text = "" Then
            DGV_GastosImportacion.Rows.Add(txt_Concepto.Text, txt_Descripcion.Text, formatonumerico(txt_Importe.Text, 2))

        Else
            DGV_GastosImportacion.Rows(txt_fila.Text).Cells("Concepto").Value = txt_Concepto.Text
            DGV_GastosImportacion.Rows(txt_fila.Text).Cells("Descripcion").Value = txt_Descripcion.Text
            DGV_GastosImportacion.Rows(txt_fila.Text).Cells("Importe").Value = formatonumerico(txt_Importe.Text, 2)

            txt_fila.Text = ""

        End If
        txt_Concepto.Text = ""
        txt_Importe.Text = ""
        txt_Descripcion.Text = ""



    End Sub

    Private Sub DGV_GastosImportacion_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_GastosImportacion.RowHeaderMouseDoubleClick
        With DGV_GastosImportacion.CurrentRow
            If MsgBox("Desea borrar el Concepto: " & Trim(.Cells("Descripcion").Value) & " con un importe de: " & .Cells("Importe").Value, vbYesNo) = vbYes Then
                Dim Posicion As Integer = .Index
                DGV_GastosImportacion.Rows.RemoveAt(Posicion)
            End If

        End With
    End Sub

    Private Sub txt_Concepto_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Concepto.KeyDown

        Select Case e.KeyData
            Case Keys.Enter

                Try
                    Dim SQLCnslt As String = "SELECT Nombre FROM Gasimpo WHERE Codigo = '" & txt_Concepto.Text & "'"

                    Dim Row As DataRow = GetSingle(SQLCnslt, "SurfactanSa")

                    If Row IsNot Nothing Then
                        txt_Descripcion.Text = Row.Item("Nombre")
                        txt_Importe.Focus()
                    Else
                        MsgBox("El codigo no es valido, Verificar", vbExclamation)
                        txt_Concepto.Select()

                    End If

                Catch ex As Exception
                    MsgBox("Se produjo un error en la consulta a Gasimpo")
                End Try
            Case Keys.Escape
                txt_Concepto.Text = ""
        End Select
    End Sub


    Private Sub DGV_GastosImportacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_GastosImportacion.CellDoubleClick

        With DGV_GastosImportacion.CurrentRow

            If e.ColumnIndex <> -1 Then
                txt_Concepto.Text = .Cells("Concepto").Value
                txt_Descripcion.Text = .Cells("Descripcion").Value
                txt_Importe.Text = .Cells("Importe").Value

                txt_fila.Text = .Index

            End If


        End With
    End Sub


    Private Sub btn_Graba_Click(sender As Object, e As EventArgs) Handles btn_Graba.Click


        Dim SQLCnslt As String = "SELECT Marca FROM MovGasParcial WHERE Codigo = '" & txt_NroMovimiento.Text & "'"

        Dim Row As DataRow = GetSingle(SQLCnslt, Operador.Base)
        If Row IsNot Nothing Then
            Dim WMarca As String

            WMarca = IIf(IsDBNull(Row.Item("Marca")), "", Row.Item("Marca"))

            If WMarca = "X" Then
                MsgBox("Esta carpeta ya fue actualizada", 0, "Nacionalizacion de Mercaderia")
                Exit Sub
            End If
        End If

        Dim ListaSQLCnlst As New List(Of String)

        SQLCnslt = "DELETE MovGasParcial WHERE Codigo = '" & txt_NroMovimiento.Text & "'"

        ListaSQLCnlst.Add(SQLCnslt)

        Dim Renglon As Integer = 0

        For Each DGV_Row As DataGridViewRow In DGV_GastosImportacion.Rows
            Renglon = Renglon + 1

            Dim WCodRenglon As String = Renglon.ToString().PadLeft(2, "0")

            Dim WCodNroMov As String = txt_NroMovimiento.Text.PadLeft(6, "0")
          

            Dim WClave As String = WCodNroMov & WCodRenglon
            Dim WCodigo As String = txt_NroMovimiento.Text
            Dim WRenglon As String = Str$(Renglon)
            Dim WFecha As String = txt_Fecha.Text
            Dim WCarpeta As String = txt_Carpeta.Text
            Dim WConcepto As String = DGV_Row.Cells("Concepto").Value
            Dim WImporte As String = DGV_Row.Cells("Importe").Value
            Dim WOrdFecha As String = ordenaFecha(txt_Fecha.Text)
            Dim WMarca As String = ""
            Dim WOrden As String = txt_Orden.Text
            Dim ZEmpresa As String = txt_Empresa.Text

            SQLCnslt = "INSERT INTO MovGasParcial (" _
            & "Clave, " _
            & "Codigo, " _
            & "Renglon, " _
            & "Fecha, " _
            & "Carpeta, " _
            & "Concepto, " _
            & "Importe, " _
            & "OrdFecha, " _
            & "Marca, " _
            & "Empresa, " _
            & "Orden)" _
            & "Values (" _
            & "'" & WClave & "', " _
            & "'" & WCodigo & "', " _
            & "'" & WRenglon & "', " _
            & "'" & WFecha & "', " _
            & "'" & WCarpeta & "', " _
            & "'" & WConcepto & "', " _
            & "'" & WImporte & "', " _
            & "'" & WOrdFecha & "', " _
            & "'" & WMarca & "', " _
            & "'" & ZEmpresa & "', " _
            & "'" & WOrden & "')"

            ListaSQLCnlst.Add(SQLCnslt)
        Next

        If TablaArticulos.Rows.Count > 0 Then

            SQLCnslt = "DELETE MovGasParcialArti WHERE Codigo = '" & txt_NroMovimiento.Text & "'"

            ListaSQLCnlst.Add(SQLCnslt)

            Renglon = 0

            For Each Row_Arti As DataRow In TablaArticulos.Rows
                Renglon = Renglon + 1

                Dim WCodRenglon As String = Renglon.ToString().PadLeft(2, "0")

                Dim WCodNroMov As String = txt_NroMovimiento.Text.PadLeft(6, "0")


                Dim WClave As String = WCodNroMov & WCodRenglon
                Dim WCodigo As String = txt_NroMovimiento.Text
                Dim WRenglon As String = Str$(Renglon)
                Dim WFecha As String = txt_Fecha.Text
                Dim WCarpeta As String = txt_Carpeta.Text
                Dim WArticulo As String = Row_Arti.Item("Articulo")
                Dim WCantidad As String = Row_Arti.Item("Cantidad")
                Dim WOrdFecha As String = ordenaFecha(txt_Fecha.Text)
                Dim WMarca As String = ""
                Dim WOrden As String = txt_Orden.Text
                Dim ZEmpresa As String = txt_Empresa.Text

                SQLCnslt = "INSERT INTO MovGasParcialArti (" _
                & "Clave, " _
                & "Codigo, " _
                & "Renglon, " _
                & "Fecha, " _
                & "Carpeta, " _
                & "Articulo, " _
                & "Cantidad, " _
                & "OrdFecha, " _
                & "Marca, " _
                & "Empresa, " _
                & "Orden)" _
                & "Values (" _
                & "'" & WClave & "', " _
                & "'" & WCodigo & "', " _
                & "'" & WRenglon & "', " _
                & "'" & WFecha & "', " _
                & "'" & WCarpeta & "', " _
                & "'" & WArticulo & "', " _
                & "'" & WCantidad & "', " _
                & "'" & WOrdFecha & "', " _
                & "'" & WMarca & "', " _
                & "'" & ZEmpresa & "', " _
                & "'" & WOrden & "')"

                ListaSQLCnlst.Add(SQLCnslt)
            Next
        End If

        btn_Limpiar_Click(Nothing, Nothing)

        txt_NroMovimiento.Focus()
        
    End Sub


    Public Sub PasaTabla(Tabla As DataTable) Implements IGastosImpoParcial.PasaTabla

        For Each row As DataRow In Tabla.Rows
            TablaArticulos.Rows.Add(row.Item("Articulo"), row.Item("Cantidad"))
            'MsgBox(row.Item("Articulo") & " " & row.Item("Cantidad"))
        Next
    End Sub

    Private Sub IngresoGastosDeImportacionParcial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With TablaArticulos.Columns
            .Add("Articulo")
            .Add("Cantidad")
        End With


      


        REM With rstMovGasParcial
        REM     .Index = "Clave"
        REM Claveven$ = "99999999"
        REM     .Seek "<=", Claveven$
        REM     If .NoMatch = False Then
        REM         Carpeta.text = !Carpeta + 1
        REM             Else
        REM         Carpeta.text = ""
        REM     End If
        REM End With

        txt_Carpeta.Text = ""
        txt_NroMovimiento.Text = ""
        txt_Orden.Text = ""
        txt_Empresa.Text = ""
        txt_Fecha.Text = Date.Today.ToString("dd/MM/yyyy")

        Dim Wcodigo1 As String = ""
        Dim Wcodigo2 As String = ""

        Dim SQLCnslt As String = "Select CodigoMayor = Max(Codigo) FROM MovGasParcial"
        Dim row As DataRow = GetSingle(SQLCnslt, Operador.Base)
        If row IsNot Nothing Then

            Wcodigo1 = IIf(IsDBNull(row.Item("CodigoMayor")), "0", row.Item("CodigoMayor"))

        End If

        SQLCnslt = "Select CodigoMayor = Max(Codigo) FROM MovGasParcialArti"
        Dim row2 As DataRow = GetSingle(SQLCnslt, Operador.Base)
        If row2 IsNot Nothing Then

            Wcodigo2 = IIf(IsDBNull(row2.Item("CodigoMayor")), "0", row2.Item("CodigoMayor"))

        End If

        If Wcodigo1 > Wcodigo2 Then
            txt_NroMovimiento.Text = Wcodigo1 + 1
        Else
            txt_NroMovimiento.Text = Wcodigo1 + 1
        End If
        
        txt_NroMovimiento.Focus()

    End Sub

    Private Sub btn_Consulta_Click(sender As Object, e As EventArgs) Handles btn_Consulta.Click
        With Consulta_GastImportacion
            .Show(Me)
        End With
    End Sub

    Public Sub PasaGasto(Codigo As String, Descripcion As String) Implements IConsulta_GasImportacion.PasaGasto
        txt_Concepto.Text = Codigo
        txt_Descripcion.Text = Descripcion
        txt_Importe.Focus()
    End Sub
End Class