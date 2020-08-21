Imports Util
Imports Util.Clases.Query
Imports Util.Clases.Helper

Public Class DatosdeCliente
    Sub New(ByVal CodCliente As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim SQLCnlst As String = "SELECT Razon, Direccion, Localidad, Postal, Telefono,Contacto, Observaciones, " _
                                 & "Cuit, Vendedor, Email, Fax, Rubro, Horario, Pago1, Pago2, Limite, Minimo, " _
                                 & "DirEntrega, Provincia, Iva " _
                                 & "FROM Cliente WHERE Cliente = '" & CodCliente & "'"

        Dim RowCli As DataRow = getsingle(SQLCnlst, Operador.Base)


        If RowCli IsNot Nothing Then

            With RowCli

                txt_Cliente.Text = UCase(CodCliente)
                txt_Razon.Text = .Item("Razon")
                txt_Direccion.Text = .Item("Direccion")
                txt_Localidad.Text = .Item("Localidad")
                txt_CPostal.Text = .Item("Postal")
                txt_Telefono.Text = .Item("Telefono")
                txt_Contacto.Text = .Item("Contacto")
                txt_Observaciones.Text = .Item("Observaciones")
                txt_Cuit.Text = .Item("Cuit")
                txt_Vendedor.Text = .Item("Vendedor")
                txt_Email.Text = .Item("email")
                txt_Fax.Text = .Item("fax")
                txt_Rubro.Text = .Item("Rubro")
                txt_Horarios.Text = .Item("Horario")
                txt_Pago1.Text = .Item("Pago1")
                txt_Pago2.Text = .Item("Pago2")
                txt_Limite.Text = formatonumerico(.Item("Limite"))
                txt_Minimo.Text = formatonumerico(.Item("MInimo"))
                txt_DirEntrega.Text = .Item("DirEntrega")
                cbx_Provincia.SelectedIndex = .Item("Provincia")
                Select Case Val(.Item("Iva"))
                    Case 1
                        rabtn_Incripto.Checked = True
                    Case 2
                        rabtn_NoIncripto.Checked = True
                    Case 3
                        rabtn_ConsFinal.Checked = True
                    Case 4
                        rabtn_Exento.Checked = True
                    Case 5
                        rabtn_Monotributo.Checked = True
                    Case 6
                        rabtn_NoCatalogado.Checked = True
                    Case Else
                End Select

                Imprime_Descripcion()

            End With
            
        End If
    End Sub

    Private Sub Imprime_Descripcion()

        REM lee rubro

        Dim SQLCnslt As String = "SELECT Nombre FROM Rubros WHERE Rubro = '" & txt_Rubro.Text & "'"
        Dim RowRubro As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If RowRubro IsNot Nothing Then
            txt_DesRubro.Text = RowRubro.Item("Nombre")
        End If
        
        REM lee vendedor
        SQLCnslt = "SELECT Nombre FROM Vendedor WHERE Vendedor = '" & txt_Vendedor.Text & "'"
        Dim RowVendedor As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If RowVendedor IsNot Nothing Then
            txt_DesVendedor.Text = RowVendedor.Item("Nombre")
        End If

      

        REM lee condicion de pago 1

        SQLCnslt = "SELECT Nombre FROM Pago WHERE Pago = '" & txt_Pago1.Text & "'"
        Dim RowPago As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If RowPago IsNot Nothing Then
            txt_DesPago1.Text = RowPago.Item("Nombre")
        End If

     

        REM lee condicion de pago 2



        SQLCnslt = "SELECT Nombre FROM Pago WHERE Pago = '" & txt_Pago2.Text & "'"
        Dim RowPago2 As DataRow = GetSingle(SQLCnslt, Operador.Base)

        If RowPago2 IsNot Nothing Then
            txt_DesPago2.Text = RowPago2.Item("Nombre")
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class