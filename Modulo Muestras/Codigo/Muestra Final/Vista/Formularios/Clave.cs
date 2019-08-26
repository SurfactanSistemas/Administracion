using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Formularios
{
    public partial class Clave : Form
    {
        public Clave()
        {
            InitializeComponent();
        }

        private void Clave_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text.Trim() == "") return;

                Hide();

                ICLave WOwner = (ICLave) Owner;

                if (WOwner != null) WOwner._ProcesarClaveSeguridad(textBox1.Text);

                Close();

            }
            else if (e.KeyData == Keys.Escape)
            {
                textBox1.Text = "";
            }
	        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
