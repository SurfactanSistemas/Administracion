using System.ComponentModel;
using System.Windows.Forms;

namespace Vista
{
    partial class Exportar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exportar));
            this.label1 = new System.Windows.Forms.Label();
            this.TBNombreExport = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TV_Directorio = new System.Windows.Forms.TreeView();
            this.imageListIconos = new System.Windows.Forms.ImageList(this.components);
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTAceptar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip_Aceptar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_Cancelar = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // TBNombreExport
            // 
            this.TBNombreExport.Location = new System.Drawing.Point(100, 17);
            this.TBNombreExport.Name = "TBNombreExport";
            this.TBNombreExport.Size = new System.Drawing.Size(163, 20);
            this.TBNombreExport.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TV_Directorio);
            this.panel1.Location = new System.Drawing.Point(63, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 252);
            this.panel1.TabIndex = 3;
            // 
            // TV_Directorio
            // 
            this.TV_Directorio.CausesValidation = false;
            this.TV_Directorio.FullRowSelect = true;
            this.TV_Directorio.ImageIndex = 0;
            this.TV_Directorio.ImageList = this.imageListIconos;
            this.TV_Directorio.Location = new System.Drawing.Point(5, 3);
            this.TV_Directorio.Name = "TV_Directorio";
            this.TV_Directorio.SelectedImageIndex = 0;
            this.TV_Directorio.Size = new System.Drawing.Size(194, 246);
            this.TV_Directorio.TabIndex = 6;
            this.TV_Directorio.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TV_Directorio_BeforeExpand);
            this.TV_Directorio.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Directorio_AfterSelect);
            // 
            // imageListIconos
            // 
            this.imageListIconos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIconos.ImageStream")));
            this.imageListIconos.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIconos.Images.SetKeyName(0, "HDD.png");
            this.imageListIconos.Images.SetKeyName(1, "directorio.jpg");
            this.imageListIconos.Images.SetKeyName(2, "Cdrom.jpg");
            this.imageListIconos.Images.SetKeyName(3, "usb.png");
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackgroundImage = global::Vista.Properties.Resources.Cancelar_N1;
            this.BTCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTCancelar.FlatAppearance.BorderSize = 0;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Location = new System.Drawing.Point(182, 331);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(34, 37);
            this.BTCancelar.TabIndex = 5;
            this.toolTip_Cancelar.SetToolTip(this.BTCancelar, "Cancelar");
            this.BTCancelar.UseVisualStyleBackColor = true;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // BTAceptar
            // 
            this.BTAceptar.BackgroundImage = global::Vista.Properties.Resources.Aceptar_N1;
            this.BTAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAceptar.FlatAppearance.BorderSize = 0;
            this.BTAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAceptar.Location = new System.Drawing.Point(226, 331);
            this.BTAceptar.Margin = new System.Windows.Forms.Padding(0);
            this.BTAceptar.Name = "BTAceptar";
            this.BTAceptar.Size = new System.Drawing.Size(36, 37);
            this.BTAceptar.TabIndex = 4;
            this.toolTip_Aceptar.SetToolTip(this.BTAceptar, "Aceptar");
            this.BTAceptar.UseVisualStyleBackColor = true;
            this.BTAceptar.Click += new System.EventHandler(this.BTAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.BTCancelar);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.BTAceptar);
            this.panel2.Controls.Add(this.TBNombreExport);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(8, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 405);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(1, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 422);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 39);
            this.panel4.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "EXPORTACION";
            // 
            // Exportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 459);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Exportar";
            this.Load += new System.EventHandler(this.Exportar_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox TBNombreExport;
        private FolderBrowserDialog folderBrowserDialog1;
        private Panel panel1;
        private Button BTAceptar;
        private Button BTCancelar;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TreeView TV_Directorio;
        private Label label2;
        private ToolTip toolTip_Aceptar;
        private ToolTip toolTip_Cancelar;
        private ImageList imageListIconos;
    }
}