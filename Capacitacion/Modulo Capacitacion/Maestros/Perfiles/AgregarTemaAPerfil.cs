using System;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Capacitacion.Maestros.Perfiles
{
    public partial class AgregarTemaAPerfil : Form
    {
        public AgregarTemaAPerfil()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtTema.Text.Trim() == "") return;

                DataRow tema = null;

            }
            else if (e.KeyData == Keys.Escape)
            {
                txtTema.Text = "";
            }
        }
    }
}
