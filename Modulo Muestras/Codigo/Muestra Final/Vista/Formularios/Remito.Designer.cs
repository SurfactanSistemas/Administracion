using System.ComponentModel;
using System.Windows.Forms;

namespace Vista
{
    partial class Remito
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGV_Remito = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TBCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBNumRemito = new System.Windows.Forms.TextBox();
            this.LBNumRemito = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip_Aceptar = new System.Windows.Forms.ToolTip(this.components);
            this.BTAceptar = new System.Windows.Forms.Button();
            this.toolTipCancelar = new System.Windows.Forms.ToolTip(this.components);
            this.BTCancelar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Original = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Muestra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peligroso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeligrosoII = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoRemito = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Remito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.cmbTipoRemito);
            this.panel1.Controls.Add(this.DGV_Remito);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.TBCliente);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TBFecha);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TBNumRemito);
            this.panel1.Controls.Add(this.LBNumRemito);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 272);
            this.panel1.TabIndex = 0;
            // 
            // DGV_Remito
            // 
            this.DGV_Remito.AllowUserToAddRows = false;
            this.DGV_Remito.AllowUserToDeleteRows = false;
            this.DGV_Remito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Remito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Codigo_Original,
            this.Descripcion,
            this.Cantidad,
            this.Muestra,
            this.Partida,
            this.Pedido,
            this.Peligroso,
            this.PeligrosoII});
            this.DGV_Remito.Location = new System.Drawing.Point(12, 70);
            this.DGV_Remito.Name = "DGV_Remito";
            this.DGV_Remito.ReadOnly = true;
            this.DGV_Remito.RowHeadersWidth = 15;
            this.DGV_Remito.RowTemplate.Height = 18;
            this.DGV_Remito.Size = new System.Drawing.Size(575, 195);
            this.DGV_Remito.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(411, 138);
            this.dataGridView1.TabIndex = 18;
            // 
            // TBCliente
            // 
            this.TBCliente.Enabled = false;
            this.TBCliente.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCliente.Location = new System.Drawing.Point(90, 39);
            this.TBCliente.Name = "TBCliente";
            this.TBCliente.Size = new System.Drawing.Size(497, 25);
            this.TBCliente.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(24, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cliente:";
            // 
            // TBFecha
            // 
            this.TBFecha.Enabled = false;
            this.TBFecha.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.TBFecha.Location = new System.Drawing.Point(282, 9);
            this.TBFecha.Name = "TBFecha";
            this.TBFecha.Size = new System.Drawing.Size(82, 25);
            this.TBFecha.TabIndex = 15;
            this.TBFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(230, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fecha:";
            // 
            // TBNumRemito
            // 
            this.TBNumRemito.Enabled = false;
            this.TBNumRemito.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.TBNumRemito.Location = new System.Drawing.Point(129, 9);
            this.TBNumRemito.Name = "TBNumRemito";
            this.TBNumRemito.Size = new System.Drawing.Size(98, 25);
            this.TBNumRemito.TabIndex = 13;
            this.TBNumRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LBNumRemito
            // 
            this.LBNumRemito.AutoSize = true;
            this.LBNumRemito.Location = new System.Drawing.Point(137, 15);
            this.LBNumRemito.Name = "LBNumRemito";
            this.LBNumRemito.Size = new System.Drawing.Size(0, 13);
            this.LBNumRemito.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(24, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nº de Remito:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "REMITOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 55);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(412, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "SURFACTAN S.A.";
            // 
            // BTAceptar
            // 
            this.BTAceptar.BackgroundImage = global::Vista.Properties.Resources.Aceptar_N1;
            this.BTAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAceptar.FlatAppearance.BorderSize = 0;
            this.BTAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAceptar.Location = new System.Drawing.Point(220, 331);
            this.BTAceptar.Margin = new System.Windows.Forms.Padding(0);
            this.BTAceptar.Name = "BTAceptar";
            this.BTAceptar.Size = new System.Drawing.Size(55, 50);
            this.BTAceptar.TabIndex = 19;
            this.toolTip_Aceptar.SetToolTip(this.BTAceptar, "Aceptar");
            this.BTAceptar.UseVisualStyleBackColor = true;
            this.BTAceptar.Click += new System.EventHandler(this.BTAceptar_Click);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackgroundImage = global::Vista.Properties.Resources.Cancelar_N1;
            this.BTCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTCancelar.FlatAppearance.BorderSize = 0;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Location = new System.Drawing.Point(324, 331);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(55, 50);
            this.BTCancelar.TabIndex = 20;
            this.toolTipCancelar.SetToolTip(this.BTCancelar, "Cancelar");
            this.BTCancelar.UseVisualStyleBackColor = true;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "PROBAR Impresion FDS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            // 
            // Codigo_Original
            // 
            this.Codigo_Original.DataPropertyName = "Codigo_Original";
            this.Codigo_Original.HeaderText = "Codigo Original";
            this.Codigo_Original.Name = "Codigo_Original";
            this.Codigo_Original.ReadOnly = true;
            this.Codigo_Original.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 200;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 74;
            // 
            // Muestra
            // 
            this.Muestra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Muestra.DataPropertyName = "Muestra";
            this.Muestra.HeaderText = "Muestra";
            this.Muestra.Name = "Muestra";
            this.Muestra.ReadOnly = true;
            this.Muestra.Width = 70;
            // 
            // Partida
            // 
            this.Partida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Partida.DataPropertyName = "Partida";
            this.Partida.HeaderText = "Partida";
            this.Partida.Name = "Partida";
            this.Partida.ReadOnly = true;
            this.Partida.Width = 65;
            // 
            // Pedido
            // 
            this.Pedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pedido.DataPropertyName = "Pedido";
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            this.Pedido.Width = 65;
            // 
            // Peligroso
            // 
            this.Peligroso.DataPropertyName = "Peligroso";
            this.Peligroso.HeaderText = "Peligroso";
            this.Peligroso.Name = "Peligroso";
            this.Peligroso.ReadOnly = true;
            this.Peligroso.Visible = false;
            // 
            // PeligrosoII
            // 
            this.PeligrosoII.DataPropertyName = "PeligrosoII";
            this.PeligrosoII.HeaderText = "PeligrosoII";
            this.PeligrosoII.Name = "PeligrosoII";
            this.PeligrosoII.ReadOnly = true;
            this.PeligrosoII.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(370, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tipo Remito:";
            // 
            // cmbTipoRemito
            // 
            this.cmbTipoRemito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRemito.FormattingEnabled = true;
            this.cmbTipoRemito.Items.AddRange(new object[] {
            "Hoja Blanca",
            "Formulario"});
            this.cmbTipoRemito.Location = new System.Drawing.Point(459, 11);
            this.cmbTipoRemito.Name = "cmbTipoRemito";
            this.cmbTipoRemito.Size = new System.Drawing.Size(128, 21);
            this.cmbTipoRemito.TabIndex = 22;
            this.cmbTipoRemito.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRemito_SelectedIndexChanged);
            // 
            // Remito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTAceptar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Remito";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Remito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private ToolTip toolTip_Aceptar;
        private ToolTip toolTipCancelar;
        private Label label5;
        private DataGridView DGV_Remito;
        private DataGridView dataGridView1;
        private TextBox TBCliente;
        private Label label4;
        private TextBox TBFecha;
        private Label label3;
        private TextBox TBNumRemito;
        private Label LBNumRemito;
        private Label label2;
        private Button BTCancelar;
        private Button BTAceptar;
        private Button button1;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Codigo_Original;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Muestra;
        private DataGridViewTextBoxColumn Partida;
        private DataGridViewTextBoxColumn Pedido;
        private DataGridViewTextBoxColumn Peligroso;
        private DataGridViewTextBoxColumn PeligrosoII;
        private ComboBox cmbTipoRemito;
        private Label label6;
    }
}