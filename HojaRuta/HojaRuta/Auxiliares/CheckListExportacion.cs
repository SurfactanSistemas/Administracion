using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HojaRuta.Auxiliares
{
    public partial class CheckListExportacion : Form
    {
        private string _HojaRuta;
        private string _Fecha;
        private bool _Peligroso;

        public CheckListExportacion(string WHojaRuta, string WFecha, bool WPeligroso)
        {
            InitializeComponent();

            _HojaRuta = WHojaRuta;
            _Fecha = WFecha;
            _Peligroso = WPeligroso;

            _CargarCheckList();
        }
        private void _CargarCheckList()
        {
            try
            {
                string WItem1, WItem2, WItem3, WItem4, WItem5, WItem6, WItem7, WItem8;

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Expreso, Chapa, Chofer, Placa, Rombo, Observaciones, DesExpreso, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8 FROM CheckListExpo WHERE Hoja = '" + _HojaRuta + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                cmbProveedor.SelectedIndex = dr["Expreso"] == null ? 0 : int.Parse(dr["Expreso"].ToString());
                                txtChapa.Text = dr["Chapa"] == null ? "" : dr["Chapa"].ToString();
                                txtChofer.Text = dr["Chofer"] == null ? "" : dr["Chofer"].ToString();
                                txtPlaca.Text = dr["Placa"] == null ? "" : dr["Placa"].ToString();
                                txtRombo.Text = dr["Rombo"] == null ? "" : dr["Rombo"].ToString();
                                txtObservaciones.Text = dr["Observaciones"] == null ? "" : dr["Observaciones"].ToString();
                                txtDesExpreso.Text = dr["DesExpreso"] == null ? "" : dr["DesExpreso"].ToString();
                                
                                WItem1 = dr["Item1"] == null ? "0" : dr["Item1"].ToString();
                                WItem2 = dr["Item2"] == null ? "0" : dr["Item2"].ToString();
                                WItem3 = dr["Item3"] == null ? "0" : dr["Item3"].ToString();
                                WItem4 = dr["Item4"] == null ? "0" : dr["Item4"].ToString();
                                WItem5 = dr["Item5"] == null ? "0" : dr["Item5"].ToString();
                                WItem6 = dr["Item6"] == null ? "0" : dr["Item6"].ToString();
                                WItem7 = dr["Item7"] == null ? "0" : dr["Item7"].ToString();
                                WItem8 = dr["Item8"] == null ? "0" : dr["Item8"].ToString();

                                // Reseteamos todos los checkboxs.
                                foreach (CheckBox ck in groupBox1.Controls.OfType<GroupBox>().SelectMany(gr => gr.Controls.OfType<CheckBox>()))
                                {
                                    ck.Checked = false;
                                }

                                switch (int.Parse(WItem1))
                                {
                                    case 1:
                                    {
                                        ckItem11.Checked = true;
                                        break;
                                    }
                                    case 2:
                                    {
                                        ckItem12.Checked = true;
                                        break;
                                    }
                                    case 3:
                                    {
                                        ckItem13.Checked = true;
                                        break;
                                    }
                                }

                                switch (int.Parse(WItem2))
                                {
                                    case 1:
                                        {
                                            ckItem21.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem22.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem23.Checked = true;
                                            break;
                                        }
                                }

                                switch (int.Parse(WItem3))
                                {
                                    case 1:
                                        {
                                            ckItem31.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem32.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem33.Checked = true;
                                            break;
                                        }
                                }

                                switch (int.Parse(WItem4))
                                {
                                    case 1:
                                        {
                                            ckItem41.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem42.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem43.Checked = true;
                                            break;
                                        }
                                }

                                switch (int.Parse(WItem5))
                                {
                                    case 1:
                                        {
                                            ckItem51.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem52.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem53.Checked = true;
                                            break;
                                        }
                                }

                                switch (int.Parse(WItem6))
                                {
                                    case 1:
                                        {
                                            ckItem61.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem62.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem63.Checked = true;
                                            break;
                                        }
                                }

                                switch (int.Parse(WItem7))
                                {
                                    case 1:
                                        {
                                            ckItem71.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem72.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem73.Checked = true;
                                            break;
                                        }
                                }

                                switch (int.Parse(WItem8))
                                {
                                    case 1:
                                        {
                                            ckItem81.Checked = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            ckItem82.Checked = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            ckItem83.Checked = true;
                                            break;
                                        }
                                }

                                foreach (TextBox txt in groupBox1.Controls.OfType<TextBox>())
                                {
                                    txt.Text = txt.Text.Trim();
                                }

                                cmbProveedor.Focus();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }
        
        private void ckItem11_Click(object sender, EventArgs e)
        {
            var WParent = ((CheckBox)sender).Parent;
            var WEstado = ((CheckBox)sender).Checked;

            foreach (CheckBox ck in WParent.Controls.OfType<CheckBox>())
            {
                ck.Checked = false;
            }

            ((CheckBox) sender).Checked = WEstado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validamos datos.
            if (!_DatosValidos()) return;

            // Siendo válidos los datos, procedo a guardar o actualizar el registro.

            /*
             * 1) Si 2) No 3) N/A
             */

            string WItem1 = ckItem11.Checked ? "1" : ckItem12.Checked ? "2" : "3";
            string WItem2 = ckItem21.Checked ? "1" : ckItem22.Checked ? "2" : "3";
            string WItem3 = ckItem31.Checked ? "1" : ckItem32.Checked ? "2" : "3";
            string WItem4 = ckItem41.Checked ? "1" : ckItem42.Checked ? "2" : "3";
            string WItem5 = ckItem51.Checked ? "1" : ckItem52.Checked ? "2" : "3";
            string WItem6 = ckItem61.Checked ? "1" : ckItem62.Checked ? "2" : "3";
            string WItem7 = ckItem71.Checked ? "1" : ckItem72.Checked ? "2" : "3";
            string WItem8 = ckItem81.Checked ? "1" : ckItem82.Checked ? "2" : "3";

            int WExpreso = cmbProveedor.SelectedIndex;
            string WDesExpreso = txtDesExpreso.Text.Trim();
            string WChapa = txtChapa.Text.Trim();
            string WChofer = txtChofer.Text.Trim();
            string WPlaca = txtPlaca.Text.Trim();
            string WRombo = txtRombo.Text.Trim();
            string WObservaciones = txtObservaciones.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "";

                        if (_ExisteCheckList())
                        {
                            cmd.CommandText = string.Format("UPDATE CheckListExpo SET Expreso = {0}, DesExpreso = '{1}', Chapa = '{2}', Chofer = '{3}', Placa = '{4}', Rombo = '{5}', Observaciones = '{6}', " +
                                                            " Item1 = '{7}', Item2 = '{8}', Item3 = '{9}', Item4 = '{10}', Item5 = '{11}', Item6 = '{12}', Item7 = '{13}', Item8 = '{14}', Fecha = '{16}', OrdFecha = '{17}' WHERE Hoja = '{15}'",
                                                            WExpreso, WDesExpreso, WChapa, WChofer, WPlaca, WRombo, WObservaciones, WItem1, WItem2, WItem3, WItem4, WItem5, WItem6, WItem7, WItem8, _HojaRuta, _Fecha, Helper.OrdenarFecha(_Fecha));
                        }
                        else
                        {
                            cmd.CommandText = string.Format("INSERT INTO CheckListExpo (Hoja, Expreso, DesExpreso, Chapa, Chofer, Placa, Rombo, Observaciones, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Fecha, OrdFecha) " +
                                              " VALUES ('{15}', {0} , '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{16}', '{17}')",
                                              WExpreso, WDesExpreso, WChapa, WChofer, WPlaca, WRombo, WObservaciones, WItem1, WItem2, WItem3, WItem4, WItem5, WItem6, WItem7, WItem8, _HojaRuta, _Fecha, Helper.OrdenarFecha(_Fecha));
                        }

                        cmd.ExecuteNonQuery();
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        

        }

        private bool _ExisteCheckList()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Expreso FROM CheckListExpo WHERE Hoja = '" + _HojaRuta + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            return dr.HasRows;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la preexistencia del CheckList en la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private bool _DatosValidos()
        {
            // Controlo que todas las opciones tengan por lo menos algun valor indicado.
            if (groupBox1.Controls.OfType<GroupBox>().Any(gb => gb.Controls.OfType<CheckBox>().Count(x => x.Checked) < 1))
            {
                MessageBox.Show("Error en la Carga de Datos");
                return false;
            }

            // Controlo que se haya elegido un Expreso.
            if (cmbProveedor.SelectedIndex < 1)
            {
                MessageBox.Show("Error en la Carga de Datos");
                return false;
            }

            // Controlo que en caso de ser 'Peligrosa', se hayan completado los datos de correspondientes a 'Transporte de Sustancias Peligrosas'.
            if (_Peligroso)
            {
                if (ckItem61.Checked || ckItem73.Checked || ckItem83.Checked)
                {
                    MessageBox.Show("Error en la carga de datos, al incluir carga peligrosa. " + Environment.NewLine +
                                    Environment.NewLine + " Es obligatorio la carga de todos los datos");
                    return false;
                }

                // Controlo que tenga tambien los datos de Placa y Rombo.
                if (txtPlaca.Text.Trim() == "" || txtRombo.Text.Trim() == "")
                {
                    MessageBox.Show("Error en la Carga de Datos");
                    return false;
                }
            }

            return true;
        }
    }
}
