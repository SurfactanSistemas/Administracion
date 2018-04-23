using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Listados.PromediodeCalificacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            TB_DesdeSector.Focus();
        }

        private void TB_DesdeSector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (TB_DesdeSector.Text.Trim() == "") TB_DesdeSector.Text = "0";

                TB_HastaSector.Focus();

            }
            else if (e.KeyData == Keys.Escape)
            {
                TB_DesdeSector.Text = "";
            }
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            try
            {
                VistaPrevia frm = _PrepararReporte();

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private VistaPrevia _PrepararReporte()
        {
            if (TB_DesdeSector.Text.Trim() == "") TB_DesdeSector.Text = "0";
            if (TB_HastaSector.Text.Trim() == "") TB_HastaSector.Text = "9999";

            string WDesdeSector = TB_DesdeSector.Text;
            string WHastaSector = TB_HastaSector.Text;

            // Eliminamos posibles nulos, actualizamos descripciones y reseteamos datos.
            _NormalizarDatos();

            DataTable WDatos = _ProcesarLegajos(WDesdeSector, WHastaSector);

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(new wPromedioCalificacion(), "{Legajo.Renglon} = 1 AND {Legajo.PromedioII} = 1");
            return frm;
        }

        private DataTable _ProcesarLegajos(string WDesdeSector, string WHastaSector)
        {
            // Traemos los datos de los legajos activos que se encuentren dentro del rango de sectores.
            DataTable WLegajos = _TraerLegajos(WDesdeSector, WHastaSector);

            // Creamos la tabla donde almacenaremos los datos con los que actualizar despues los legajos.
            DataTable WDatos = _CrearTablaDatos();

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = WLegajos.Rows.Count;

            string WCorte = "", WTarea = "";
            int[] WEsta = new int[11];

            double WCantidad = 0, WPromedio = 0, WTotal = 0, WEquivale;
            int[] WNecesaria, WDeseable;
            DataRow WRow;
            
            // Recorremos los legajos calculando los puntajes y totales.
            foreach (DataRow WLegajo in WLegajos.Rows)
            {
                if (WCorte == "") WCorte = WLegajo["Legajo"].ToString();

                if (WCorte != WLegajo["Legajo"].ToString())
                {
                    WRow = WDatos.NewRow();

                    WRow["Legajo"] = WCorte;

                    WPromedio = 0;
                    if (WCantidad != 0)
                    {
                        WPromedio = WTotal/WCantidad;
                    }

                    WRow["Promedio"] = WPromedio;
                    WRow["Total"] = WTotal;

                    WDatos.Rows.Add(WRow);

                    WCorte = WLegajo["Legajo"].ToString();
                }

                if (WLegajo["Renglon"].ToString() == "1")
                {
                    WCantidad = 0;
                    WTotal = 0;
                    WEquivale = 0;
                    WPromedio = 0;

                    WTarea = "";
                    WEsta = new int[11];

                    WTarea = WLegajo["Perfil"].ToString();
                    WEsta[1] = int.Parse(WLegajo["EstaI"].ToString());
                    WEsta[2] = int.Parse(WLegajo["EstaII"].ToString());
                    WEsta[3] = int.Parse(WLegajo["EstaIII"].ToString());
                    WEsta[4] = int.Parse(WLegajo["EstaIV"].ToString());
                    WEsta[5] = int.Parse(WLegajo["EstaV"].ToString());
                    WEsta[9] = int.Parse(WLegajo["EstaVI"].ToString());
                    WEsta[10] = int.Parse(WLegajo["EstaX"].ToString());

                    switch (WEsta[9])
                    {
                        case 1:
                        case 2:
                        case 8:
                            WEquivale = 1;
                            break;
                    }

                    switch (WEsta[10])
                    {
                        case 1:
                        case 2:
                        case 8:
                            WEquivale = 1;
                            break;
                    }
                    WNecesaria = new int[6];
                    WDeseable = new int[6];

                    WNecesaria[1] = int.Parse(WLegajo["NecesariaI"].ToString());
                    WNecesaria[2] = int.Parse(WLegajo["NecesariaII"].ToString());
                    WNecesaria[3] = int.Parse(WLegajo["NecesariaIII"].ToString());
                    WNecesaria[4] = int.Parse(WLegajo["NecesariaIV"].ToString());
                    WNecesaria[5] = int.Parse(WLegajo["NecesariaV"].ToString());

                    WDeseable[1] = int.Parse(WLegajo["DeseableI"].ToString());
                    WDeseable[2] = int.Parse(WLegajo["DeseableII"].ToString());
                    WDeseable[3] = int.Parse(WLegajo["DeseableIII"].ToString());
                    WDeseable[4] = int.Parse(WLegajo["DeseableIV"].ToString());
                    WDeseable[5] = int.Parse(WLegajo["DeseableV"].ToString());

                    for (int i = 1; i <= 4; i++)
                    {
                        if (WDeseable[i] == 1 || WNecesaria[i] == 1)
                        {
                            switch (WEsta[i])
                            {
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                    if (WEquivale == 1)
                                    {
                                        WEsta[i] = 1;
                                        WEquivale = 0;
                                    }
                                    break;
                            }

                            switch (WEsta[i])
                            {
                                case 1:
                                case 2:
                                case 8:
                                    WCantidad++;
                                    WTotal += 6;
                                    break;
                                case 3:
                                    WCantidad++;
                                    WTotal += 4;
                                    break;
                                case 4:
                                    WCantidad++;
                                    WTotal += 2;
                                    break;
                                case 5:
                                case 7:
                                    WCantidad++;
                                    break;
                            }
                        }
                    }

                    if (WDeseable[5] == 1 || WNecesaria[5] == 1)
                    {
                        switch (WEsta[5])
                        {
                            case 1:
                                WCantidad++;
                                WTotal += 8;
                                break;
                            case 2:
                            case 8:
                                WCantidad++;
                                WTotal += 6;
                                break;
                            case 3:
                                WCantidad++;
                                WTotal += 4;
                                break;
                            case 4:
                                WCantidad++;
                                WTotal += 2;
                                break;
                            case 5:
                            case 7:
                                WCantidad++;
                                break;
                        }
                    }
                }

                switch (int.Parse(WLegajo["EstaCurso"].ToString()))
                {
                    case 1:
                        WCantidad++;
                        WTotal += 8;
                        break;
                    case 2:
                    case 8:
                        WCantidad++;
                        WTotal += 6;
                        break;
                    case 3:
                        WCantidad++;
                        WTotal += 4;
                        break;
                    case 4:
                        WCantidad++;
                        WTotal += 2;
                        break;
                    case 5:
                    case 7:
                        WCantidad++;
                        break;
                }

                progressBar1.Increment(1);
            }

            // Grabamos el ultimo de los legajos que por iteración se calcula, pero no se graba.

            if (WCorte != "")
            {
                WRow = WDatos.NewRow();

                WRow["Legajo"] = WCorte;

                WPromedio = 0;
                if (WCantidad != 0)
                {
                    WPromedio = WTotal / WCantidad;
                }

                WRow["Promedio"] = WPromedio;
                WRow["Total"] = WTotal;

                WDatos.Rows.Add(WRow);
            }

            progressBar1.Maximum += WDatos.Rows.Count;

            _ActualizarDatosLegajos(WDatos);

            return WDatos;
        }

        private static DataTable _CrearTablaDatos()
        {
            DataTable WDatos = new DataTable();
            WDatos.Columns.Add("Legajo");
            WDatos.Columns.Add("Promedio", typeof (double));
            WDatos.Columns.Add("Total", typeof (double));
            return WDatos;
        }

        private void _ActualizarDatosLegajos(DataTable WDatos)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "";

                    foreach (DataRow ZLegajo in WDatos.Rows)
                    {
                        cmd.CommandText = "UPDATE Legajo SET Promedio = '" + ZLegajo["Promedio"].ToString().Replace(',', '.') +
                                          "', PromedioIII = '" + ZLegajo["Total"].ToString().Replace(',', '.') +
                                          "', PromedioII = '1' WHERE Codigo = '" + ZLegajo["Legajo"] + "'";
                        cmd.ExecuteNonQuery();

                        progressBar1.Increment(1);
                    }
                }
            }
        }

        private static DataTable _TraerLegajos(string WDesdeSector, string WHastaSector)
        {
            DataTable WLegajos = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT l.codigo as Legajo, l.Renglon, l.Perfil, l.EstaI, l.EstaII, l.EstaIII,"
                                      + " l.EstaIV, l.EstaV, l.EstaVI, l.EstaX, l.EstaCurso, t.NecesariaI,"
                                      + " t.NecesariaII, t.NecesariaIII, t.NecesariaIV, t.NecesariaV, t.DeseableI,"
                                      + " t.DeseableII, t.DeseableIII, t.DeseableIV, t.DeseableV from legajo as l,"
                                      + " Tarea as t WHERE l.Sector BETWEEN " + WDesdeSector + " AND " + WHastaSector
                                      + " AND l.Perfil = t.Codigo and t.Renglon = 1"
                                      + " and l.Fegreso IN ('  /  /    ', '00/00/0000') order by l.Codigo, l.Renglon";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WLegajos.Load(dr);
                        }
                    }
                }
            }
            return WLegajos;
        }

        private void _NormalizarDatos()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Legajo SET Legajo.ImprePerfil = Tarea.Descripcion, Legajo.Sector = Tarea.Sector FROM Legajo, Tarea WHERE Legajo.Perfil = Tarea.Codigo";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET Legajo.DesSector = Sector.Descripcion FROM Legajo, Sector WHERE Legajo.Sector = Sector.Codigo";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET Promedio = 0, PromedioII = 0";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET FEgreso = '  /  /    ' WHERE FEgreso IS NULL";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Legajo SET EstaX = 0 WHERE EstaX IS NULL";
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                VistaPrevia frm = _PrepararReporte();

                frm.Imprimir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
