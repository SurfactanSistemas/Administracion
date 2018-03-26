using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Logica_Negocio;

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
        int ValidClave = 0;


        public InicEvaluacion()
        {
            InitializeComponent();
        }

        private void InicEvaluacion_Load(object sender, EventArgs e)
        {
            P_Filtrado.Visible = false;
            TraerLista();
            DGV_Evaluaciones.Focus();
        }

        private void TraerLista()
        {
            DataTable dtEva = EVAGBOL.ListaGen();
            DataTable dtProve = PBOL.Lista();
            dtEva.Columns.Add("NombProve", typeof(string));
            dtEva.Columns.Add("Estado", typeof(string));
            dtEva.Columns.Add("DescTipo", typeof(string));
            dtEva.Columns.Add("DescFecha", typeof(string));
            foreach (DataRow fila in dtEva.Rows)
            {
                foreach (DataRow filaProve in dtProve.Rows)
                {
                    if ((fila[1].ToString()) == (filaProve[0].ToString()))
                    {
                        fila["NombProve"] = filaProve["Nombre"];
                        if (filaProve["Estado"].ToString() == "")
                        {
                            fila["Estado"] = "Sin Evaluar";
                            
                        }
                        else
                        {
                            if (int.Parse(filaProve["Estado"].ToString()) == 2)
                            {
                                fila["Estado"] = "Inhabilitado";

                            }
                            else
                            {
                                fila["Estado"] = "Habilitado";
                            }
                        }
                    }

                }

                int Tipo = int.Parse(fila[46].ToString());
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

                fila["DescFecha"] = fila[2].ToString() + " / " + fila[3];
                
            }

            

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
            ValidarClave();
            if (ValidClave == 1)
            {
                try
                {
                    if (DGV_Evaluaciones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ninguna Evaluación");

                    if (DGV_Evaluaciones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de una  Evaluación");

                    int Tipo = int.Parse(DGV_Evaluaciones.SelectedRows[0].Cells[4].Value.ToString());
                    string Clave = DGV_Evaluaciones.SelectedRows[0].Cells[0].Value.ToString();
                    string NombProve = DGV_Evaluaciones.SelectedRows[0].Cells[2].Value.ToString();
                    string Estado = DGV_Evaluaciones.SelectedRows[0].Cells[3].Value.ToString();

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
            }
            
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
            TBFiltro.Text = "";
        }

        private void nombreProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            columna = "NombProve";
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Nombre Proveedor";
            TBFiltro.Visible = true;
        }

        

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            CB_Tipo.Text = "";
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
            HabilitarPanelFiltrado();
            LBFiltro.Text = "Periodo";
            TBFiltro.Visible = true;
        }

        private void HabilitarPanelFiltrado()
        {
            P_Filtrado.Visible = true;
            TBFiltro.Focus();
        }

        private void BT_Filtrar_Click(object sender, EventArgs e)
        {
            if (BT_Filtrar.Text == "Filtrar")
            {
                (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + columna + ", System.String) like '%{0}%'", TBFiltro.Text);
                BT_Filtrar.Text = "Limp. Filtro";
            }
            else
            {
                (DGV_Evaluaciones.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

                P_Filtrado.Visible = false;
                TBFiltro.Text = "";
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
            ValidarClave();
            if (ValidClave == 1)
            {
                try
                {
                    if (DGV_Evaluaciones.SelectedRows.Count == 0) throw new Exception("No se ha seleccionado ninguna Evaluación");

                    if (DGV_Evaluaciones.SelectedRows.Count > 1) throw new Exception("Se ha seleccionado mas de una  Evaluación");

                    int Tipo = int.Parse(DGV_Evaluaciones.SelectedRows[0].Cells[4].Value.ToString());
                    string Clave = DGV_Evaluaciones.SelectedRows[0].Cells[0].Value.ToString();
                    string NombProve = DGV_Evaluaciones.SelectedRows[0].Cells[2].Value.ToString();
                    string Estado = DGV_Evaluaciones.SelectedRows[0].Cells[3].Value.ToString();

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
                    }


                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            
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
    }
}
