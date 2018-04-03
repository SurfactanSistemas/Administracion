using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Modulo_Capacitacion.Maestros.Sectores
{
    public partial class AgModSector : Form
    {
        private int UltimoId;
        private Sector nuevoSector = new Sector();
        private AgModSector modificarSector;
        private bool EsModificar = false;
        private Sector SectorAModificar;

        public AgModSector()
        {
            InitializeComponent();
        }

        public AgModSector(int UltimoId)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.UltimoId = UltimoId;
            
            nuevoSector.Codigo = this.UltimoId;
            TB_Codigo.Text = UltimoId.ToString();
            TB_Nombre.Focus();
        }

        public AgModSector(Sector SectorAModificar)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.SectorAModificar = SectorAModificar;
            EsModificar = true;
            TB_Codigo.Text = this.SectorAModificar.Codigo.ToString();
            TB_Nombre.Text = this.SectorAModificar.Descripcion;
            TB_Nombre.Focus();
        }

        private void BT_LimpiarPant_Click(object sender, EventArgs e)
        {
            //TB_Codigo.Text = "";
            TB_Nombre.Text = "";
            TB_Nombre.Focus();
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_Nombre.Text == "") throw new Exception("Se debe completar el campo Nombre");

                if (!EsModificar) { 
                    nuevoSector.Descripcion = TB_Nombre.Text;
                    nuevoSector.Agregar();
                }
                else
                {
                    this.SectorAModificar.Descripcion = TB_Nombre.Text;
                    nuevoSector.Modificar(this.SectorAModificar);
                }

                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Error");
            }
        }
    }
}
