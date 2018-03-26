using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Novedades
{
    public partial class LoginAdmin : Form
    {
        string Clave = "1234";
        public int ValidClave;
        public LoginAdmin()
        {
            InitializeComponent();
        }

        public LoginAdmin(int ValidClave)
        {
            // TODO: Complete member initialization
            this.ValidClave = ValidClave;
            InitializeComponent();
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            TB_Clave.Focus();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            if (TB_Clave.Text == "1234")
            {
                ValidClave = 1;
                Close();
            }
            else
            {
                MessageBox.Show("La clave ingresada no es correcta. Por favor intentelo nuevamente o pongase en contacto con personal de sistemas", "Clave erronea",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                TB_Clave.Text = "";
            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
            ValidClave = 0;
        }

        private void TB_Clave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TB_Clave.Text == "1234")
                {
                    ValidClave = 1;
                    Close();
                }
                else
                {
                    MessageBox.Show("La clave ingresada no es correcta. Por favor intentelo nuevamente o pongase en contacto con personal de sistemas", "Clave erronea",
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                    TB_Clave.Text = "";
                }
            }
        }
    }
}
