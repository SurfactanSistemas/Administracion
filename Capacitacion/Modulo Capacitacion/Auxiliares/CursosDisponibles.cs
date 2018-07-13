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

namespace Modulo_Capacitacion.Auxiliares
{
    public partial class CursosDisponibles : Form
    {
        private int WRowIndex = -1;

        public CursosDisponibles(string WTema, int RowIndex)
        {
            InitializeComponent();

            this.WRowIndex = RowIndex;
            CargarCursos(WTema);

        }

        private void CursosDisponibles_Load(object sender, EventArgs e)
        {
            txtFiltrar.Focus();
        }

        private void CargarCursos(string WTema)
        {
            try
            {
                DataTable tabla = new DataTable();
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Tema As Curso, Descripcion, Horas FROM Tema WHERE Curso = '"+ WTema + "'";

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                tabla.Load(dr);
                            }
                        }
                    }

                }

                dgvCursos.DataSource = tabla;

                DataGridViewColumn column = dgvCursos.Columns["Descripcion"];
                if (column != null)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la consulta a la Base de Datos. Motivo: " + ex.Message);
            }
        
        }

        private void dgvCursos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Novedades.IngrePlanificacionAnual WOwner = (Novedades.IngrePlanificacionAnual) this.Owner;

            if (WOwner == null) return;

            if (dgvCursos.CurrentRow != null)
            {
                var WCurso = dgvCursos.CurrentRow.Cells["Curso"].Value ?? "0";
                var WDesCurso = dgvCursos.CurrentRow.Cells["Descripcion"].Value ?? "0";
                var WHoras = dgvCursos.CurrentRow.Cells["Horas"].Value ?? "0";

                WOwner.AsignarCurso(WCurso, WDesCurso, WHoras, WRowIndex);

                Close();
            }

        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFiltrar_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable tabla = dgvCursos.DataSource as DataTable;

            if (tabla != null)
                tabla.DefaultView.RowFilter = string.Format("Convert(Curso, System.String) LIKE '%{0}%' OR Descripcion LIKE '%{0}%'", txtFiltrar.Text);
        }
    }
}
