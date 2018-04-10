using System;
using System.Data;
using System.Windows.Forms;
using ClassConexion;

namespace Modulo_Capacitacion.Listados.CursosPendientesPorSector
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            _CargarSectores();
        }

        private void _CargarSectores()
        {
            cmbSectores.DataSource = (new Conexion()).Listar("SELECT Codigo, LTRIM(RTRIM(Descripcion)) as Descripcion FROM Sector Order by Descripcion");
            cmbSectores.DisplayMember = "Descripcion";
            cmbSectores.ValueMember = "Codigo";
        }

        private void cmbSectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void txtAno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMes.Focus();
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            txtAno.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Pantalla_Click(object sender, EventArgs e)
        {
            VistaPrevia frm = _PrepararVistaPrevia();
            frm.Show();
        }

        private VistaPrevia _PrepararVistaPrevia()
        {
            CursosPendientesPorSector reporte = _PrepararReporte();

            VistaPrevia frm = new VistaPrevia();
            frm.CargarReporte(reporte);
            return frm;
        }

        private CursosPendientesPorSector _PrepararReporte()
        {
            DataTable tabla = _PrepararDatosReporte();

            CursosPendientesPorSector reporte = new CursosPendientesPorSector();
            reporte.SetDataSource(tabla);
            return reporte;
        }

        private DataTable _PrepararDatosReporte()
        {
            Conexion conn = new Conexion();

            string WSector = cmbSectores.SelectedValue.ToString();
            DataTable tabla =
                conn.Listar(
                    "select l.codigo as Legajo, l.Descripcion as NombreApellido, l.Perfil, p.Descripcion as DescPerfil, l.Curso, c.Descripcion as DescCurso, t.Tema, t.Descripcion as DescTema, t.Horas, l.Sector, s.Descripcion as DescSector from legajo as l, Tarea as p, Curso as c, Tema as t, Sector as s where l.Perfil = p.Codigo and l.Curso = c.Codigo and c.Codigo = t.Curso and l.Sector = s.Codigo and l.sector = " +
                    WSector +
                    " and l.EstaCurso not in (1,2,6) and (l.Fegreso = '00/00/0000' OR l.Fegreso = '  /  /    ') and p.renglon = 1 order by l.Codigo, l.Curso, t.Tema");

            tabla.TableName = "Detalles";
            tabla.Columns.Add("Realizadas", typeof (double));
            tabla.Columns.Add("Clave", typeof (double));
            tabla.Columns.Add("Ano", typeof (string));

            int clave = 0;
            string WAnoActual = "", WAnoSiguiente = "";

            WAnoActual = txtAno.Text + "0501";
            WAnoSiguiente = (int.Parse(txtAno.Text) + 1) + "0431"; // 31 por si se equivocaron de ultimo dia de Abril.

            foreach (DataRow row in tabla.Rows)
            {
                string valor =
                    conn.TraerValor(
                        "SELECT SUM(Horas) as Realizadas FROM Cursadas WHERE OrdFecha BETWEEN " + WAnoActual + " AND " + WAnoSiguiente + " AND Legajo = '" +
                        row["Legajo"] + "' AND Curso = '" + row["Curso"] + "' AND Tema = '" + row["Tema"] + "'", 0.0);

                if (valor == "") valor = "0";

                row["Realizadas"] = double.Parse(valor);
                row["Clave"] = ++clave;
                row["Ano"] = txtAno.Text;
            }
            return tabla;
        }

        private void BT_Imprimir_Click(object sender, EventArgs e)
        {
            VistaPrevia frm = _PrepararVistaPrevia();
            frm.Imprimir();
            Close();
        }
    }
}
