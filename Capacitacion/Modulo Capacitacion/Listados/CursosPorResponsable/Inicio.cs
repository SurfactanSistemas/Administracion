using System;
using System.Data;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Listados.CursosPorResponsable
{
    public partial class Inicio : Form
    {
        Cronograma Cro = new Cronograma();
        Legajo L = new Legajo();
        CronogramaII CroII = new CronogramaII();

        DataTable dtResponsable;
        Responsable R = new Responsable();
        DataTable dtInforme = new DataTable();
        DataTable dtCronograma;
        DataTable dtResponsables;
        DataTable dtCronogramaII;
        int MesDevuelto;
        int MesIngresado;
        string Tipo;

        
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            CargarResponsables();
            CargardtInforme();
            CB_Ordenamiento.SelectedIndex = 0;
        }

        private void CargardtInforme()
        {
            dtInforme.Columns.Add("CodResponsable", typeof (string));
            dtInforme.Columns.Add("DescResponsable", typeof(string));
            dtInforme.Columns.Add("CodLegajo", typeof(string));
            dtInforme.Columns.Add("DescLegajo", typeof(string));
            dtInforme.Columns.Add("CodCurso", typeof(string));
            dtInforme.Columns.Add("DescCurso", typeof(string));
        }

        private void CargarResponsables()
        {
            dtResponsable = R.ListarTodos();


            DataRow fila;
            fila = dtResponsable.NewRow();
            dtResponsable.Rows.InsertAt(fila, 0);

           

            CargarDescResp();
            CargarCodigosResp();
        }

        private void CargarDescResp()
        {
            TB_Responsable2.DataSource = dtResponsable;
            TB_Responsable2.DisplayMember = "Descripcion";
            TB_Responsable2.ValueMember = "Codigo";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Descripcion"]));

            }

            TB_Responsable2.AutoCompleteCustomSource = stringCodArti;
            TB_Responsable2.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_Responsable2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CargarCodigosResp()
        {
            TB_CodResponsable2.DataSource = dtResponsable;
            TB_CodResponsable2.DisplayMember = "Codigo";
            TB_CodResponsable2.ValueMember = "Codigo";
            TB_CodResponsable2.Text = "";

            AutoCompleteStringCollection stringCodArti = new AutoCompleteStringCollection();
            foreach (DataRow row in dtResponsable.Rows)
            {
                stringCodArti.Add(Convert.ToString(row["Codigo"]));

            }

            TB_CodResponsable2.AutoCompleteCustomSource = stringCodArti;
            TB_CodResponsable2.AutoCompleteMode = AutoCompleteMode.Suggest;
            TB_CodResponsable2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            CargarInforme();

            Tipo = "Pantalla";

            ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
            Impre.ShowDialog();
            
        }

        private void CargarInforme()
        {
            try
            {
                if (TB_CodResponsable2.Text == "") throw new Exception("Se debe elegir el responsable");

                if (TB_Mes.Text == "") throw new Exception("Se debe ingresar el mes");

                if (TB_Año.Text == "") throw new Exception("Se debe ingresar el año");

                if (CB_Ordenamiento.Text == "") throw new Exception("Se debe elegir un ordenamiento");

                int Año = 0;

                int.TryParse(TB_Año.Text, out Año);

                if (Año == 0) throw new Exception("Se debe ingresar un año valido");

                MesIngresado = 0;

                int.TryParse(TB_Mes.Text, out MesIngresado);

                if ((MesIngresado == 0) || (MesIngresado > 12)) throw new Exception("Se debe ingresar un mes valido");


                //Consulto los cronogramas PENDIENTES
                dtCronograma = Cro.CronogramaPendiente(Año);
                dtInforme.Rows.Clear();

                foreach (DataRow filaCrono in dtCronograma.Rows)
                {
                    int Lega = int.Parse(filaCrono[2].ToString());

                    //BUSCO LOS RESPONSABLES POR EL PERFIL DE CADA LEGAJO
                    dtResponsables = L.LegajoPerfilResponsable(Lega);

                    foreach (DataRow filaResp in dtResponsables.Rows)
                    {
                        //CONSULTO SI LOS RESPONSABLES DEVUELTOS SON IGUAL A EL RESPONSABLE INGRESADO
                        if ((filaResp[1].ToString() == TB_CodResponsable2.Text) || (filaResp[2].ToString() == TB_CodResponsable2.Text))
                        {
                            int Curs = int.Parse(filaCrono[3].ToString());

                            dtCronogramaII = CroII.ListarPorCurso(Año, Curs);


                            //RECORRO LOS MESES 
                            foreach (DataRow filaCroII in dtCronogramaII.Rows)
                            {
                                if (filaCroII[11].ToString() == "x") MesDevuelto = 12;

                                if (filaCroII[10].ToString() == "x") MesDevuelto = 11;

                                if (filaCroII[9].ToString() == "x") MesDevuelto = 10;

                                if (filaCroII[8].ToString() == "x") MesDevuelto = 9;

                                if (filaCroII[7].ToString() == "x") MesDevuelto = 8;

                                if (filaCroII[6].ToString() == "x") MesDevuelto = 7;

                                if (filaCroII[5].ToString() == "x") MesDevuelto = 6;

                                if (filaCroII[4].ToString() == "x") MesDevuelto = 5;

                                if (filaCroII[3].ToString() == "x") MesDevuelto = 4;

                                if (filaCroII[2].ToString() == "x") MesDevuelto = 3;

                                if (filaCroII[1].ToString() == "x") MesDevuelto = 2;

                                if (filaCroII[0].ToString() == "x") MesDevuelto = 1;
                            }

                            if (MesIngresado >= MesDevuelto)
                            {
                                DataRow filaInforme = dtInforme.NewRow();

                                filaInforme[0] = TB_CodResponsable2.Text;
                                filaInforme[1] = TB_Responsable2.Text;
                                filaInforme[2] = filaCrono[2].ToString();
                                filaInforme[3] = filaResp[3].ToString();
                                filaInforme[4] = filaCrono[3].ToString();
                                filaInforme[5] = filaCrono[4].ToString();

                                dtInforme.Rows.Add(filaInforme);
                            }

                        }
                    }

                }
                

            }


            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TB_CodResponsable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Mes.Focus();
        }

        private void TB_Responsable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Mes.Focus();
        }

        private void TB_Mes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Año.Focus();
            }
        }

        private void TB_Año_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            CargarInforme();

            Tipo = "Impresion";

            ImpreInforme Impre = new ImpreInforme(dtInforme, Tipo);
            Impre.ShowDialog();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_CodResponsable2.Focus();
        }
    }
}
