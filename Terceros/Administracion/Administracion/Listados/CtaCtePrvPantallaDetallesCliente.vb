Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ClasesCompartidas

Public Class CtaCtePrvPantallaDetallesCliente

    Private _Cliente As String = ""

    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = Trim(value)
        End Set
    End Property

    Private _Saldo As String = ""

    Public Property SaldoTotal() As String
        Get
            Return _Saldo
        End Get
        Set(ByVal value As String)
            _Saldo = value
        End Set
    End Property


    Private Sub CtaCtePrvPantallaDetallesCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cliente As Cliente = DAOCliente.buscarClientePorCodigo(Me.Cliente)

        txtProveedor.Text = cliente.id
        txtRazon.Text = Trim(cliente.razon)

        txtSaldo.Text = Me.SaldoTotal

        _CargarDetalles()
    End Sub

    Private Sub _CargarDetalles()

        If Me.Cliente = "" Then
            Exit Sub
        End If

        Dim cn As SqlConnection = New SqlConnection()
        Dim cm As SqlCommand = New SqlCommand("SELECT * FROM CtaCte WHERE Cliente = '" & Me.Cliente & "' and Saldo <> '0'")
        Dim dr As SqlDataReader

        SQLConnector.conexionSql(cn, cm)

        Try

            dr = cm.ExecuteReader()

            If dr.HasRows Then

                Do While dr.Read()
                    Dim i As Integer = DGVDetalles.Rows.Add()
                    With DGVDetalles.Rows(i)
                        .Cells(0).Value = dr.Item("Impre")
                        .Cells(1).Value = dr.Item("Numero")
                        .Cells(2).Value = dr.Item("Fecha")
                        .Cells(3).Value = "$ " & Proceso.formatonumerico(dr.Item("Saldo"), "########0.#0", ".")
                    End With
                Loop

            End If

        Catch ex As Exception
            MsgBox("Hubo un problema al querer consultar la Base de Datos.", MsgBoxStyle.Critical)
        Finally

            dr = Nothing
            cn.Close()
            cn = Nothing
            cm = Nothing

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
