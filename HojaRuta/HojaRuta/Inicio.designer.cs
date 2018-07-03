using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HojaRuta
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingCamionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingChoferesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hojaDeRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoVencimientosDeCamionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeVencimientosDeChoferesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.consultaHojaDeRutaCOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaHojaDeRutaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maestrosToolStripMenuItem,
            this.novedadesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.procesosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingCamionesToolStripMenuItem,
            this.ingChoferesToolStripMenuItem});
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.maestrosToolStripMenuItem.Text = "Maestros";
            // 
            // ingCamionesToolStripMenuItem
            // 
            this.ingCamionesToolStripMenuItem.Name = "ingCamionesToolStripMenuItem";
            this.ingCamionesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ingCamionesToolStripMenuItem.Text = "Ing. Camiones";
            this.ingCamionesToolStripMenuItem.Click += new System.EventHandler(this.ingCamionesToolStripMenuItem_Click);
            // 
            // ingChoferesToolStripMenuItem
            // 
            this.ingChoferesToolStripMenuItem.Name = "ingChoferesToolStripMenuItem";
            this.ingChoferesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ingChoferesToolStripMenuItem.Text = "Ing. Choferes";
            this.ingChoferesToolStripMenuItem.Click += new System.EventHandler(this.ingChoferesToolStripMenuItem_Click);
            // 
            // novedadesToolStripMenuItem
            // 
            this.novedadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hojaDeRutaToolStripMenuItem,
            this.consultaHojaDeRutaCOTToolStripMenuItem,
            this.consultaHojaDeRutaClienteToolStripMenuItem});
            this.novedadesToolStripMenuItem.Name = "novedadesToolStripMenuItem";
            this.novedadesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.novedadesToolStripMenuItem.Text = "Novedades";
            // 
            // hojaDeRutaToolStripMenuItem
            // 
            this.hojaDeRutaToolStripMenuItem.Name = "hojaDeRutaToolStripMenuItem";
            this.hojaDeRutaToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hojaDeRutaToolStripMenuItem.Text = "Hoja de Ruta";
            this.hojaDeRutaToolStripMenuItem.Click += new System.EventHandler(this.hojaDeRutaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoVencimientosDeCamionesToolStripMenuItem,
            this.listadoDeVencimientosDeChoferesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem1.Text = "Listados";
            // 
            // listadoVencimientosDeCamionesToolStripMenuItem
            // 
            this.listadoVencimientosDeCamionesToolStripMenuItem.Name = "listadoVencimientosDeCamionesToolStripMenuItem";
            this.listadoVencimientosDeCamionesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.listadoVencimientosDeCamionesToolStripMenuItem.Text = "Listado Vencimientos de Camiones";
            this.listadoVencimientosDeCamionesToolStripMenuItem.Click += new System.EventHandler(this.listadoVencimientosDeCamionesToolStripMenuItem_Click);
            // 
            // listadoDeVencimientosDeChoferesToolStripMenuItem
            // 
            this.listadoDeVencimientosDeChoferesToolStripMenuItem.Name = "listadoDeVencimientosDeChoferesToolStripMenuItem";
            this.listadoDeVencimientosDeChoferesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.listadoDeVencimientosDeChoferesToolStripMenuItem.Text = "Listado de Vencimientos de Choferes";
            this.listadoDeVencimientosDeChoferesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeVencimientosDeChoferesToolStripMenuItem_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirDelSistemaToolStripMenuItem});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.procesosToolStripMenuItem.Text = "Salir";
            this.procesosToolStripMenuItem.Click += new System.EventHandler(this.procesosToolStripMenuItem_Click);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 40);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOJA DE RUTA";
            // 
            // consultaHojaDeRutaCOTToolStripMenuItem
            // 
            this.consultaHojaDeRutaCOTToolStripMenuItem.Name = "consultaHojaDeRutaCOTToolStripMenuItem";
            this.consultaHojaDeRutaCOTToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.consultaHojaDeRutaCOTToolStripMenuItem.Text = "Consulta Hoja de Ruta (COT)";
            this.consultaHojaDeRutaCOTToolStripMenuItem.Click += new System.EventHandler(this.consultaHojaDeRutaCOTToolStripMenuItem_Click);
            // 
            // consultaHojaDeRutaClienteToolStripMenuItem
            // 
            this.consultaHojaDeRutaClienteToolStripMenuItem.Name = "consultaHojaDeRutaClienteToolStripMenuItem";
            this.consultaHojaDeRutaClienteToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.consultaHojaDeRutaClienteToolStripMenuItem.Text = "Consulta Hoja de Ruta (Cliente)";
            this.consultaHojaDeRutaClienteToolStripMenuItem.Click += new System.EventHandler(this.consultaHojaDeRutaClienteToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem maestrosToolStripMenuItem;
        private ToolStripMenuItem ingCamionesToolStripMenuItem;
        private ToolStripMenuItem ingChoferesToolStripMenuItem;
        private ToolStripMenuItem novedadesToolStripMenuItem;
        private ToolStripMenuItem procesosToolStripMenuItem;
        private Panel panel1;
        private Label label1;
        private ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private ToolStripMenuItem hojaDeRutaToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem listadoVencimientosDeCamionesToolStripMenuItem;
        private ToolStripMenuItem listadoDeVencimientosDeChoferesToolStripMenuItem;
        private ToolStripMenuItem consultaHojaDeRutaCOTToolStripMenuItem;
        private ToolStripMenuItem consultaHojaDeRutaClienteToolStripMenuItem;
    }
}

