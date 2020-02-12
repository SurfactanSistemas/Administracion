using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConsultasVarias.Clases;

namespace Eval_Proveedores.Novedades
{
    public partial class EvaluacionProveedorEnsayos : Form
    {
        public EvaluacionProveedorEnsayos()
        {
            InitializeComponent();
        }

        private void EvaluacionProveedorEnsayos_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();

            foreach (
                Control c in
                    new Control[]
                    {
                        txtAno, txtEvaluador, txtFecha, txtMes, txtObsEvaluacion, txtObsProveedor, txtProveedor,
                        txtVencimiento, lblCalificacion, lblDesProv
                    })
            {
                c.KeyDown += txtProveedor_KeyDown;
            }
        }

        private void _LimpiarGrilla()
        {
            dgvDatos.Rows.Clear();

            Dictionary<string, string> d = new Dictionary<string, string>()
            {
                {"Requisitos Básicos del Servicio", "Protocolo OK/evid. de calibración o ISO 17025,9001,SAC,HSPA.Met.OK"},
                {"Rapidez de Respuesta (Plazos)", "Trabajo y Entrega de doc. según plazos solic. por SURFACTAN"},
                {"Prolijidad en Ejecución del trabajo", "Trabajo realizado según las reglas de arte"},
                {"Cond. de Seguridad y Medio Ambiente", "Respeta lineamientos de Surfactan - ART"}
            };

            int i = 1;

            List<string> opciones1 = new List<string> {"", "CUMPLE", "NO CUMPLE"};
            List<string> opciones2 = new List<string> {"", "CUMPLE", "PARCIAL", "NO CUMPLE", "NO APLICA"};

            foreach (KeyValuePair<string, string> pair in d)
            {
                int x = dgvDatos.Rows.Add(pair.Key, pair.Value);

                ((DataGridViewComboBoxCell) dgvDatos.Rows[x].Cells["Calificacion1"]).DataSource = (i == 1)
                    ? opciones1
                    : opciones2;
                ((DataGridViewComboBoxCell) dgvDatos.Rows[x].Cells["Calificacion2"]).DataSource = (i == 1)
                    ? opciones1
                    : opciones2;
                ((DataGridViewComboBoxCell) dgvDatos.Rows[x].Cells["Calificacion3"]).DataSource = (i == 1)
                    ? opciones1
                    : opciones2;
                dgvDatos.Rows[x].Cells["Calificacion1"].Value = "";
                dgvDatos.Rows[x].Cells["Calificacion2"].Value = "";
                dgvDatos.Rows[x].Cells["Calificacion3"].Value = "";

                i++;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in new Control []{txtAno, txtEvaluador, txtFecha, txtMes, txtObsEvaluacion, txtObsProveedor, txtProveedor, txtVencimiento, lblCalificacion, lblDesProv})
            {
                c.Text = "";
            }

            txtMes.Text = DateTime.Now.ToString("MM");
            txtAno.Text = DateTime.Now.ToString("yyyy");
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            lblAviso.Visible = false;

            _LimpiarGrilla();

            txtProveedor.Focus();
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            Control t = (Control)sender;
            
            if (e.KeyData == Keys.Enter)
            {
                if (t.Text.Trim() == "") return;

                switch (t.Name.ToUpper().Replace("TXT", ""))
                {
                    case "PROVEEDOR":
                        {
                            DataRow p = Query.GetSingle("SELECT Nombre FROM Proveedor WHERE Proveedor = '" + t.Text + "'");

                            lblDesProv.Text = "";

                            if (p == null) return;

                            lblDesProv.Text = Helper.OrDefault(p["Nombre"], "").ToString();

                            txtMes.Focus();

                            break;
                        }
                    case "MES":
                        {
                            if (t.Text.Trim() == "") t.Text = "0";
                            if (int.Parse(t.Text) < 1 || int.Parse(t.Text) > 12)
                            {

                                return;
                            }
                            txtAno.Focus();
                            break;
                        }
                    case "ANO":
                        {
                            if (t.Text.Trim() == "") t.Text = "0";
                            if (int.Parse(t.Text) < 1900 || int.Parse(t.Text) > 2100) return;
                            txtFecha.Focus();
                            break;
                        }
                    case "FECHA":
                        {
                            if (int.Parse(Helper.OrdenarFecha(t.Text)) <= 0) return;
                            txtVencimiento.Focus();
                            break;
                        }
                    case "VENCIMIENTO":
                        {
                            if (int.Parse(Helper.OrdenarFecha(t.Text)) <= 0) return;
                            txtEvaluador.Focus();
                            break;
                        }
                    case "EVALUADOR":
                        {
                            if (t.Text.Trim() == "") return;
                            txtObsProveedor.Focus();
                            break;
                        }
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                t.Text = "";
            }
        }
    }
}
