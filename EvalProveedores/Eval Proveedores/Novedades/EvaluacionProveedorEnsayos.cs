using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util.Clases;

namespace Eval_Proveedores.Novedades
{
    public partial class EvaluacionProveedorEnsayos : Form
    {
        private int WRow, WCol;
        public EvaluacionProveedorEnsayos()
        {
            InitializeComponent();
        }

        public EvaluacionProveedorEnsayos(string Proveedor, string Mes, string Ano)
        {
            InitializeComponent();

            lblAviso.Visible = false;

            _LimpiarGrilla();

            txtProveedor.Text = Proveedor;
            txtProveedor_KeyDown(txtProveedor, new KeyEventArgs(Keys.Enter));

            txtMes.Text = Mes;
            txtAno.Text = Ano;

            txtProveedor_KeyDown(txtAno, new KeyEventArgs(Keys.Enter));
        }

        private void EvaluacionProveedorEnsayos_Load(object sender, EventArgs e)
        {
            string Mes = txtMes.Text;
            string Ano = txtAno.Text;
            string Prov = txtProveedor.Text;
            
            btnLimpiar_Click(null, null);

            txtProveedor.Text = Prov;
            txtProveedor_KeyDown(txtProveedor, new KeyEventArgs(Keys.Enter));

            txtMes.Text = Mes;
            txtAno.Text = Ano;

            txtProveedor_KeyDown(txtAno, new KeyEventArgs(Keys.Enter));

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

            cmbAux.Visible = false;

            cmbSector1.SelectedIndex = 0;
            cmbSector2.SelectedIndex = 0;
            cmbSector3.SelectedIndex = 0;

            WRow = -1;
            WCol = -1;

            Dictionary<string, string> d = new Dictionary<string, string>()
            {
                {"Requisitos Básicos del Servicio", "Protocolo OK/evid. de calibración o ISO 17025,9001,SAC,HSPA.Met.OK"},
                {"Rapidez de Respuesta (Plazos)", "Trabajo y Entrega de doc. según plazos solic. por SURFACTAN"},
                {"Prolijidad en Ejecución del trabajo", "Trabajo realizado según las reglas de arte"},
                {"Cond. de Seguridad y Medio Ambiente", "Respeta lineamientos de Surfactan - ART"}
            };

            List<string> opciones2 = new List<string> {"", "CUMPLE", "PARCIAL", "NO CUMPLE", "NO APLICA"};

            foreach (KeyValuePair<string, string> pair in d)
            {
                int x = dgvDatos.Rows.Add(pair.Key, pair.Value);

                //((DataGridViewComboBoxCell) dgvDatos.Rows[x].Cells["Calificacion1"]).DataSource = opciones2;
                //((DataGridViewComboBoxCell) dgvDatos.Rows[x].Cells["Calificacion2"]).DataSource = opciones2;
                //((DataGridViewComboBoxCell) dgvDatos.Rows[x].Cells["Calificacion3"]).DataSource = opciones2;
                dgvDatos.Rows[x].Cells["Calificacion1"].Value = "";
                dgvDatos.Rows[x].Cells["Calificacion2"].Value = "";
                dgvDatos.Rows[x].Cells["Calificacion3"].Value = "";
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

            _LimpiarGrilla();

            cmbAux.Visible = false;

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
                            DataRow p = Query.GetSingle("SELECT Nombre, Estado, ObservacionesII FROM Proveedor WHERE Proveedor = '" + t.Text + "'");

                            lblDesProv.Text = "";
                            txtObsProveedor.Text = "";
                            lblAviso.Visible = false;

                            if (p == null) return;

                            lblDesProv.Text = Helper.OrDefault(p["Nombre"], "").ToString();
                            txtObsProveedor.Text = Helper.OrDefault(p["ObservacionesII"], "").ToString();
                            lblAviso.Visible = (int) Helper.OrDefault(p["Estado"], 0) == 2;

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

                            // Corroboramos si exiten datos para el periodo indicado.

                            _CargarDatos();

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

        private void _CargarDatos()
        {
            if (txtMes.Text.Trim() == "") txtMes.Text = "0";

            DataTable datos = Query.GetAll("SELECT ee.Proveedor, p.Nombre, ee.Mes, ee.Ano, ee.Fecha, ee.Vencimiento, ee.Evaluador, ee.Sector1, ee.Sector2, ee.Sector3, ee.ObsEvaluacion, ee.Calificacion, eed.Calificacion1, eed.Calificacion2, eed.Calificacion3 FROM EvaluaEnsayos ee INNER JOIN Proveedor p ON p.Proveedor = ee.Proveedor LEFT OUTER JOIN EvaluaEnsayosDetalles eed ON eed.Proveedor = ee.Proveedor And eed.Mes = ee.Mes And eed.Ano = ee.Ano WHERE ee.Proveedor = '" + txtProveedor.Text + "' And ee.Mes = '" + int.Parse(txtMes.Text) + "' And ee.Ano = '" + int.Parse(txtAno.Text) + "' ORDER BY eed.Clave");

            string WProveedor = txtProveedor.Text;
            string WDescProveedor = lblDesProv.Text;
            string WMes = txtMes.Text;
            string WAno = txtAno.Text;
            string WObs = txtObsProveedor.Text;
            bool WAviso = lblAviso.Visible;

            btnLimpiar.PerformClick();

            txtProveedor.Text = WProveedor;
            lblDesProv.Text = WDescProveedor;
            txtMes.Text = WMes;
            txtAno.Text = WAno;
            txtObsProveedor.Text = WObs;
            lblAviso.Visible = WAviso;

            if (datos.Rows.Count == 0) return;

            DataRow datosGenerales = datos.Rows[0];

            cmbSector1.SelectedIndex = int.Parse(Helper.OrDefault(datosGenerales["Sector1"], 0).ToString());
            cmbSector2.SelectedIndex = int.Parse(Helper.OrDefault(datosGenerales["Sector2"], 0).ToString());
            cmbSector3.SelectedIndex = int.Parse(Helper.OrDefault(datosGenerales["Sector3"], 0).ToString());

            txtObsEvaluacion.Text = Helper.OrDefault(datosGenerales["ObsEvaluacion"], "").ToString().Trim();
            txtFecha.Text = Helper.OrDefault(datosGenerales["Fecha"], "").ToString().Trim();
            txtVencimiento.Text = Helper.OrDefault(datosGenerales["Vencimiento"], "").ToString().Trim();
            lblCalificacion.Text = Helper.OrDefault(datosGenerales["Calificacion"], "").ToString().Trim();
            txtEvaluador.Text = Helper.OrDefault(datosGenerales["Evaluador"], "").ToString().Trim();

            for (var i = 0; i < dgvDatos.Rows.Count && i < datos.Rows.Count; i++)
            {
                dgvDatos.Rows[i].Cells["Calificacion1"].Value = _DeterminarValorCombo(datos.Rows[i]["Calificacion1"]);
                dgvDatos.Rows[i].Cells["Calificacion2"].Value = _DeterminarValorCombo(datos.Rows[i]["Calificacion2"]);
                dgvDatos.Rows[i].Cells["Calificacion3"].Value = _DeterminarValorCombo(datos.Rows[i]["Calificacion3"]);
            }

            //dgvDatos.EndEdit();

            _ComboHandler(null, null);

            dgvDatos.CurrentCell = dgvDatos.Rows[0].Cells[0];

        }

        private static string _DeterminarValorCombo(object dato)
        {
            switch (int.Parse(Helper.OrDefault(dato, 0).ToString()))
            {
                case 1:
                {
                    return "CUMPLE";
                    break;
                }
                case 2:
                {
                    return "PARCIAL";
                    break;
                }
                case 3:
                {
                    return "NO CUMPLE";
                    break;
                }
                case 4:
                {
                    return "NO APLICA";
                    break;
                }
                default:
                {
                    return "";
                }
            }
            
        }

        private static int _DeterminarValorComboBBDD(object dato)
        {
            switch (Helper.OrDefault(dato, "").ToString().ToUpper())
            {
                case "CUMPLE":
                    {
                        return 1;
                        break;
                    }
                case "PARCIAL":
                    {
                        return 2;
                        break;
                    }
                case "NO CUMPLE":
                    {
                        return 3;
                        break;
                    }
                case "NO APLICA":
                    {
                        return 4;
                        break;
                    }
                default:
                    {
                        return 0;
                    }
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validarDatos()) return;

            List<string> sqls = new List<string>();

            string WProveedor = txtProveedor.Text;
            string WMes = txtMes.Text.PadLeft(2, '0');
            string WAno = txtAno.Text.PadLeft(4, '0');
            string WFecha = txtFecha.Text;
            string WVto = txtVencimiento.Text;
            string WEvaluador = txtEvaluador.Text.Trim();
            string WObsEvalua = txtObsEvaluacion.Text.Trim();
            int WSector1 = cmbSector1.SelectedIndex;
            int WSector2 = cmbSector2.SelectedIndex;
            int WSector3 = cmbSector3.SelectedIndex;

            string WCalificacion = Helper.FormatoNumerico(lblCalificacion.Text);

            sqls.Add(string.Format("DELETE FROM EvaluaEnsayos WHERE Proveedor = '{0}' And Mes = {1} And Ano = '{2}'", WProveedor, WMes, WAno));
            sqls.Add(string.Format("DELETE FROM EvaluaEnsayosDetalles WHERE Proveedor = '{0}' And Mes = {1} And Ano = '{2}'", WProveedor, WMes, WAno));

            string WClave = WProveedor + WMes + WAno;

            string sql = string.Format("INSERT INTO EvaluaEnsayos (Clave, Proveedor, Mes, Ano, Periodo, PeriodoOrd, Fecha, FechaOrd, Vencimiento, VencimientoOrd, Evaluador, Sector1, Sector2, Sector3, ObsEvaluacion, Calificacion) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}')",
                                        WClave, WProveedor, WMes, WAno, WMes + '/' + WAno, WAno + WMes, WFecha, Helper.OrdenarFecha(WFecha), WVto, Helper.OrdenarFecha(WVto), WEvaluador, WSector1, WSector2, WSector3, WObsEvalua, WCalificacion);

            sqls.Add(sql);

            short renglon = 0;

            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                int WCalificacion1 = _DeterminarValorComboBBDD(row.Cells["Calificacion1"].Value);
                int WCalificacion2 = _DeterminarValorComboBBDD(row.Cells["Calificacion2"].Value);
                int WCalificacion3 = _DeterminarValorComboBBDD(row.Cells["Calificacion3"].Value);

                renglon++;

                WClave = WProveedor + WMes + WAno + renglon.ToString().PadLeft(2, '0');

                sql = string.Format("INSERT INTO EvaluaEnsayosDetalles (Clave, Proveedor, Mes, Ano, Renglon, Calificacion1, Calificacion2, Calificacion3) " 
                                    + "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", 
                                    WClave, WProveedor, WMes, WAno, renglon, WCalificacion1, WCalificacion2, WCalificacion3);

                sqls.Add(sql);
            }

            Query.ExecuteNonQueries(sqls.ToArray());

            btnLimpiar.PerformClick();

            Close();

        }

        private bool validarDatos()
        {
            if (txtProveedor.Text.Trim() == "") return false;

            DataRow prov =
                Query.GetSingle("SELECT Proveedor FROM Proveedor WHERE Proveedor = '" + txtProveedor.Text + "'");

            if (prov == null)
            {
                MessageBox.Show("No existe el Proveedor Indicado");
                return false;
            }

            int WMes, WAno;

            int.TryParse(txtMes.Text, out WMes);
            int.TryParse(txtAno.Text, out WAno);

            if (WMes < 1 || WMes > 12 || WAno < 1900 || WAno > 2100)
            {
                MessageBox.Show("Debe indicar un Periodo válido de Evaluación.");
                return false;
            }

            if (int.Parse(Helper.OrdenarFecha(txtFecha.Text)) == 0)
            {
                MessageBox.Show("Se deben indicar una Fecha válida.");
                return false;
            }

            if (txtVencimiento.Text.Replace(" ", "").Length  == 10 && int.Parse(Helper.OrdenarFecha(txtVencimiento.Text)) == 0)
            {
                MessageBox.Show("Se deben indicar una Fecha de Vencimiento válida.");
                return false;
            }

            if (txtEvaluador.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar el responsable de la Evaluación.");
                return false;
            }

            return true;
        }
        
        private Color _DeterminarColorFondo(string condicion)
        {
            switch (condicion)
            {
                case "APTO":
                {
                    return Color.Green;
                    break;
                }
                case "NO APTO":
                {
                    return Color.Red;
                    break;
                }
                case "CONDICIONAL":
                {
                    return Color.Orange;
                    break;
                }
                default:
                {
                    return (Color) Globales.WBackColorTerciario;
                }
            }
        }

        private string _DeterminarCalificacion(int[,] cal, int i)
        {
            if (((ComboBox) this.Controls["gbSectores"].Controls["cmbSector" + (i + 1)]).SelectedIndex > 0)
            {
                if (cal[0, i] == 2)
                {
                    return "NO APTO";
                }
                else if (cal[1,i] == 1 && cal[2,i] == 1 && cal[3,i] == 1)
                {
                    return "APTO";
                }
                else if (cal[0, i] != 0 || cal[1, i] != 0 || cal[2, i] != 0 || cal[3, i] != 0)
                {
                    return "CONDICIONAL";    
                }
                return "";
            }

            return "";
        }

        private void _ComboHandler(object sender, EventArgs e)
        {
            //dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            
            int[,] cal = new int[4, 3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0},
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    DataGridViewRow row = dgvDatos.Rows[j];

                    cal[j, i] = _DeterminarValorComboBBDD(row.Cells["Calificacion" + (i + 1)].Value);
                }
            }

            // Calificacion1
            if (cal[0, 0] == 3) cal[0, 0] = 2;
            if (cal[1, 0] == 4) cal[1, 0] = 1;
            if (cal[2, 0] == 4) cal[2, 0] = 1;
            if (cal[3, 0] == 4) cal[3, 0] = 1;

            // Calificacion2
            if (cal[0, 1] == 3) cal[0, 1] = 2;
            if (cal[1, 1] == 4) cal[1, 1] = 1;
            if (cal[2, 1] == 4) cal[2, 1] = 1;
            if (cal[3, 1] == 4) cal[3, 1] = 1;

            // Calificacion3
            if (cal[0, 2] == 3) cal[0, 2] = 2;
            if (cal[1, 2] == 4) cal[1, 2] = 1;
            if (cal[2, 2] == 4) cal[2, 2] = 1;
            if (cal[3, 2] == 4) cal[3, 2] = 1;

            // Calculamos las Calificaciones.
            lblCalificacion1.Text = _DeterminarCalificacion(cal, 0);
            lblCalificacion2.Text = _DeterminarCalificacion(cal, 1);
            lblCalificacion3.Text = _DeterminarCalificacion(cal, 2);

            lblCalificacion1.BackColor = _DeterminarColorFondo(lblCalificacion1.Text);
            lblCalificacion2.BackColor = _DeterminarColorFondo(lblCalificacion2.Text);
            lblCalificacion3.BackColor = _DeterminarColorFondo(lblCalificacion3.Text);
        }

        private void dgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (!cmbAux.Enabled) return;

            cmbAux.DroppedDown = false;

            switch (e.ColumnIndex)
            {
                case 2:
                case 3:
                case 4:
                {
                    DataGridViewCell cell = dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    Point p = dgvDatos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;

                    cell.Style.BackColor = (Color) Globales.WBackColorSecundario;
                    dgvDatos.ClearSelection();
                    cell.Style.BackColor = (Color)Globales.WBackColorSecundario;

                    p.X += dgvDatos.Location.X + (cell.Size.Width - cmbAux.Size.Width);
                    p.Y += dgvDatos.Location.Y + (cell.Size.Height - cmbAux.Size.Height);

                    WRow = e.RowIndex;
                    WCol = e.ColumnIndex;

                    cmbAux.Items.Clear();

                    cmbAux.Items.AddRange((e.RowIndex == 0) ? new[] { "", "CUMPLE", "", "NO CUMPLE", "" } : new[] { "", "CUMPLE", "PARCIAL", "NO CUMPLE", "NO APLICA" });

                    cmbAux.Location = p;
                    cmbAux.SelectedIndex = _DeterminarValorComboBBDD(cell.Value);

                    cmbAux.Visible = true;
                    cmbAux.Focus();
                    break;
                }
            }

        }

        private void cmbAux_DropDownClosed(object sender, EventArgs e)
        {
            if (WRow < 0 || WCol < 0) return;

            cmbAux.Visible = false;
            dgvDatos.Rows[WRow].Cells[WCol].Value = cmbAux.Text;

            _ComboHandler(null, null);
        }
    }
}
