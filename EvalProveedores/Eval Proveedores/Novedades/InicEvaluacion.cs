using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Logica_Negocio;
using Negocio;


namespace Eval_Proveedores.Novedades
{
    public partial class InicEvaluacion : Form
    {
        EvaGeneralBOL EVAGBOL = new EvaGeneralBOL();
        EvaTransBOL EVATRABOL = new EvaTransBOL();
        EvaVariosBOL EVAVABOL = new EvaVariosBOL();
        Proveedor P = new Proveedor();
        ProveedorBOL PBOL = new ProveedorBOL();
        string columna = "";
        int ValidClave;


        public InicEvaluacion()
        {
            InitializeComponent();
        }

        private void InicEvaluacion_Load(object sender, EventArgs e)
        {
            P_Filtrado.Visible = false;
            TraerLista();
            //DGV_Evaluaciones.Focus();
            txtCodigo.Focus();
        }

        private void TraerLista()
        {
            DataTable dtEva;
            DataRow[] row;

            dtEva = ckSoloUltimas.Checked ? EVAGBOL.ListaGenUltimos() : EVAGBOL.ListaGen();

            //DataTable dtProve = PBOL.Lista();
            //dtEva.Columns.Add("NombProve", typeof(string));
            dtEva.Columns.Add("Estado", typeof(string));
            dtEva.Columns.Add("DescTipo", typeof(string));
            dtEva.Columns.Add("DescFecha", typeof(string));
            foreach (DataRow fila in dtEva.Rows)
            {
                fila["Clave"] = fila["Proveedor"] + fila["Mes"].ToString().PadLeft(2, '0') + fila["Ano"].ToString().PadLeft(4, '0');

                //fila["NombProve"] = row[0]["Nombre"];

                if (fila["ProveEstado"].ToString() == "")
                {
                    fila["Estado"] = "Sin Evaluar";

                }
                else
                {
                    fila["Estado"] = int.Parse(fila["ProveEstado"].ToString()) == 2 ? "Inhabilitado" : "Habilitado";
                }

                //row = dtProve.Select("Proveedor='" + fila["Proveedor"].ToString() + "'");

                //if (row.Length > 0)
                //{
                //    fila["NombProve"] = row[0]["Nombre"];

                //    if (row[0]["Estado"].ToString() == "")
                //    {
                //        fila["Estado"] = "Sin Evaluar";

                //    }
                //    else
                //    {
                //        fila["Estado"] = int.Parse(row[0]["Estado"].ToString()) == 2 ? "Inhabilitado" : "Habilitado";
                //    }
                //}

                int Tipo = int.Parse(fila["Tipo"].ToString());
                switch (Tipo)
                {
                    case 1: 
                        fila["DescTipo"] = "TRANSPORTISTA";
                            break;

                    case 2:
                        fila["DescTipo"] = "CALIBRACION";
                            break;

                    case 3:
                            fila["DescTipo"] = "";
                            break;

                    case 4:
                            fila["DescTipo"] = "MANTENIMIENTO";
                            break;

                    case 5:
                            fila["DescTipo"] = "OTROS";
                            break;
                }

                fila["DescFecha"] = fila["Mes"] + " / " + fila["Ano"];
                
            }

            dtEva.DefaultView.Sort = "Tipo ASC, NombProve ASC";

            DGV_Evaluaciones.DataSource = dtEva;

            //CON ESTE METODO COLOREO LAS FILAS INHABILITADAS
            BuscarInhabilitados();
        }

        private void BuscarInhabilitados()
        {
            
            foreach (DataGridViewRow row in DGV_Evaluaciones.Rows)
            {
                string Estado = Convert.ToString(row.Cells["Estado"].Value);

                if (Estado == "Inhabilitado")
                {
                    row.DefaultCellStyle.BackColor = Color.Firebrick;
                }
            }
        }

        private void BTAgregarEvaluacion_Click(object sender, EventArgs e)
        {
            ConsultaTipo Consulta = new ConsultaTipo();
            Consulta.ShowDialog();
            TraerLista();
        }

        private void BTModifEvaluacion_Click(object sender, EventArgs e)
        {
            //ValidarClave();
            //if (ValidClave == 1)
            //{
                try
                {
                    if (DGV_Evaluaciones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ninguna Evaluación");

                    if (DGV_Evaluaciones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de una  Evaluación");

                    int Tipo = int.Parse(DGV_Evaluaciones.SelectedRows[0].Cells["Tipo"].Value.ToString());
                    string Clave = DGV_Evaluaciones.SelectedRows[0].Cells["Clave"].Value.ToString();
                    string NombProve = DGV_Evaluaciones.SelectedRows[0].Cells["NombProve"].Value.ToString();
                    string Estado = DGV_Evaluaciones.SelectedRows[0].Cells["Estado"].Value.ToString();

                    if (Tipo == 1)
                    {
                        EvaluaTransp EvaTrans = EVATRABOL.Find(Clave);

                        IngEvalTransp ModEvaTrans = new IngEvalTransp(EvaTrans, Estado, NombProve);
                        ModEvaTrans.ShowDialog();
                        TraerLista();
                        P_Filtrado.Visible = false;
                    }
                    else
                    {
                        EvaluaVarios Eva = EVAVABOL.Find(Clave);

                        IngEvalMantenimiento ModEva = new IngEvalMantenimiento(Eva, Estado, NombProve, Tipo);
                        ModEva.ShowDialog();
                        TraerLista();
                        P_Filtrado.Visible = false;
                        CB_Tipo.Visible = false;
                        PProve.Visible = false;
                    }


                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            
        }

        private void ValidarClave()
        {
            LoginAdmin Log = new LoginAdmin(ValidClave);
            Log.ShowDialog();
            ValidClave = Log.ValidClave;
        }

        private void BT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Evaluaciones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ninguna Evaluación");

                if (DGV_Evaluaciones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de una  Evaluación");

                  DialogResult Resp = MessageBox.Show("¿Esta seguro que desea eliminar la evaluación?", "Eliminar Evaluación",
               MessageBoxButtons.YesNo);

                  if (Resp == DialogResult.Yes)
                  {
                      ValidarClave();
                      if (ValidClave == 1)
                      {
                          EVAVABOL.Eliminar(DGV_Evaluaciones.SelectedRows[0].Cells[0].Value.ToString());

                          MessageBox.Show("El evaluación se eliminó con éxito", "Eliminación evaluación",
                          MessageBoxButtons.OK, MessageBoxIcon.None);
                      }
                      
                  }
                

               
                TraerLista();
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void Bt_Fin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_MenuFiltros_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CMS_Filtros.Show(ptLowerLeft);

            BT_Filtrar.Text = "Limp. Filtro";
            TBFiltroMes.Text = "";
        }

        private void nombreProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            columna = "NombProve";
            PProve.Visible = true;
            LB_Prove.Text = "Nombre";
            TB_Filtro2.Visible = true;
            TB_Filtro2.Focus();
        }


        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            CB_Tipo.Text = "";
            PProve.Visible = false;
            P_Filtrado.Visible = false;
            CB_Tipo.Visible = true;
            LBFiltro.Text = "Tipo";
            //columna = "DescTipo";
            //HabilitarPanelFiltrado();
            //LBFiltro.Text = "Tipo";
            //TBFiltro.Visible = true;
        }

        private void periodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            columna = "Periodo";
            PProve.Visible = false;
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Periodo";
            TBFiltroMes.Visible = true;
        }

        private void HabilitarPanelFiltrado()
        {
            P_Filtrado.Visible = true;
            TBFiltroMes.Focus();
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            if (BT_Filtrar.Text == "Filtrar")
            {
                DataTable table = DGV_Evaluaciones.DataSource as DataTable;
                if (table != null)
                    table.DefaultView.RowFilter = string.Format("CONVERT(" + columna + ", System.String) like '%{0}%'", TBFiltroAno.Text + TBFiltroMes.Text.PadLeft(2, '0'));
                BT_Filtrar.Text = "Limp. Filtro";
            }
            else
            {
                DataTable table = DGV_Evaluaciones.DataSource as DataTable;
                if (table != null)
                    table.DefaultView.RowFilter = string.Empty;

                P_Filtrado.Visible = false;
                TBFiltroMes.Text = "";
                TBFiltroAno.Text = "";
                BT_Filtrar.Visible = true;
            }
        }

        private void TBFiltro_TextChanged(object sender, EventArgs e)
        {
            BT_Filtrar.Text = "Filtrar";
        }

        private void TBFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Filtrar.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void DGV_Evaluaciones_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BTModifEvaluacion.PerformClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBFiltro.Text == "Tipo")
            {
                (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(DescTipo, System.String) like '%{0}%'", CB_Tipo.Text);
            }
            PProve.Visible = true;
            LB_Prove.Text = "Proveedor";

        }

        private void BT_Filtrar2_Click(object sender, EventArgs e)
        {
            if (BT_Filtrar2.Text == "Filtrar")
            {
                (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(NombProve, System.String) like '%{0}%'", TB_Filtro2.Text);
                BT_Filtrar2.Text = "Limp. Filtro";
            }
            else
            {
                (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(DescTipo, System.String) like '%{0}%'", CB_Tipo.Text);

                PProve.Visible = true;
                TB_Filtro2.Text = "";
                BT_Filtrar2.Visible = true;

            }
        }

        private void TB_Filtro2_TextChanged(object sender, EventArgs e)
        {
            BT_Filtrar2.Text = "Filtrar";
        }

        private void TB_Filtro2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Filtrar2.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void ckSoloUltimas_CheckedChanged(object sender, EventArgs e)
        {
            TraerLista();
        }

        private void TBFiltroMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TBFiltroAno.Focus();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (txtCodigo.Text.Trim() == "") return;

                foreach (DataGridViewRow row in DGV_Evaluaciones.Rows)
                {
                    var WCodigo = row.Cells["Proveedor"].Value ?? "";

                    if (WCodigo.ToString().Trim() != "")
                    {
                        if (txtCodigo.Text.Trim() == WCodigo.ToString().Trim())
                        {
                            row.Selected = true;
                            DGV_Evaluaciones_RowHeaderMouseDoubleClick(null, null);
                            txtCodigo.Text = "";
                            return;
                        }
                    }
                }

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtCodigo.Text = "";
            }
	        
        }

        private void DGV_Evaluaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
