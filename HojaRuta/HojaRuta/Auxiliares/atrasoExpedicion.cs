using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HojaRuta.Auxiliares
{
    public partial class AtrasoExpedicion : Form
    {
        public AtrasoExpedicion(object WPedido, object WCliente, object WRazon, object WFechaEntrega)
        {
            InitializeComponent();

            txtFechaAviso.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNroPedido.Text = WPedido.ToString();
            txtCliente.Text = WCliente.ToString();
            txtDesCliente.Text = WRazon.ToString();
            txtFechaEntrega.Text = WFechaEntrega.ToString();

            cmbPlanta.SelectedIndex = 0;
            cmbRetraso.SelectedIndex = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;

            try
            {
                if (txtProblema.Text.Trim() == "") throw new Exception("Se debe informar el problema del atraso");
                if (cmbRetraso.SelectedIndex < 1) throw new Exception("Se debe informar el concpeto del atraso");
                if (cmbPlanta.SelectedIndex < 1) throw new Exception("Se debe informar la Planta");

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();
                    trans = conn.BeginTransaction();
                    
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "";
                        cmd.Transaction = trans;


                        var WCodigo = "1";

                        cmd.CommandText = "SELECT MAX(Numero) as Proximo FROM Atraso";
                        var dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dr.Read();

                            WCodigo = dr["Proximo"].ToString();
                            WCodigo = (int.Parse(WCodigo) + 1).ToString();

                            dr.Close();
                        }

                        var WFecha = txtFechaAviso.Text;
                        var WOrdFecha = Helper.OrdenarFecha(WFecha);
                        var WPedido = txtNroPedido.Text;
                        var WCliente = txtCliente.Text;
                        var WTerminado = "  -     -   ";
                        var WProblema = txtProblema.Text;
                        var WArticulo = "  -   -   ";
                        var WFechaEntrega = txtFechaEntrega.Text;
                        var WOrdFechaEntrega = Helper.OrdenarFecha(WFechaEntrega);
                        var WDesCliente = txtDesCliente.Text;
                        var WDesTerminado = "";
                        var WDesArticulo = "";
                        var WConcepto = cmbRetraso.SelectedIndex;
                        var WSolicitud = "0";
                        var WOrigen = cmbPlanta.SelectedIndex;
                        var WVersionPedido = "0";

                        var WOrig = "4";

                        if (WOrigen == 1) WOrig = "3";

                        cmd.CommandText = string.Format("INSERT INTO Atraso (Numero, Fecha, OrdFecha, Pedido, Cliente, Terminado, Problema, Articulo, FechaEntrega, OrdFechaEntrega, DesCliente, DesTerminado, DesArticulo, Concepto, Solicitud, Origen, VersionPedido) VALUES " +
                                                        "({0}, '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13}, {14}, {15}, {16})",
                                                        WCodigo, WFecha, WOrdFecha, WPedido, WCliente, WTerminado, WProblema, WArticulo, WFechaEntrega, WOrdFechaEntrega, WDesCliente, WDesTerminado, WDesArticulo, WConcepto, WSolicitud, WOrig, WVersionPedido);

                        cmd.ExecuteNonQuery();

                        trans.Commit();

                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
               if (trans != null && trans.Connection != null) trans.Rollback();
               MessageBox.Show(ex.Message);
            }
        
        }

        private void txtProblema_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtProblema.Text.Trim() == "") return;

                cmbRetraso.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtProblema.Text = "";
            }
	        
        }

        private void AtrasoExpedicion_Shown(object sender, EventArgs e)
        {
            txtProblema.Focus();
        }

        private void AtrasoExpedicion_Load(object sender, EventArgs e)
        {
            Location = new Point(Width / 2, 15);
        }
    }
}
