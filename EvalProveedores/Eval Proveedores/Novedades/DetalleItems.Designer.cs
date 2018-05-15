namespace Eval_Proveedores.Novedades
{
    partial class DetalleItems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.LBCamion = new System.Windows.Forms.Label();
            this.DGV_EvalSemProve = new System.Windows.Forms.DataGridView();
            this.CodigoProve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desviad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Envase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPosibleEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aprobado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rechazado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liberada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Laudo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Devuelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EvalSemProve)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.lblProveedor);
            this.panel1.Controls.Add(this.LBCamion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 39);
            this.panel1.TabIndex = 4;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.White;
            this.lblProveedor.Location = new System.Drawing.Point(163, 11);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(0, 19);
            this.lblProveedor.TabIndex = 0;
            // 
            // LBCamion
            // 
            this.LBCamion.AutoSize = true;
            this.LBCamion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCamion.ForeColor = System.Drawing.Color.White;
            this.LBCamion.Location = new System.Drawing.Point(22, 11);
            this.LBCamion.Name = "LBCamion";
            this.LBCamion.Size = new System.Drawing.Size(112, 19);
            this.LBCamion.TabIndex = 0;
            this.LBCamion.Text = "DETALLE ITEMS";
            // 
            // DGV_EvalSemProve
            // 
            this.DGV_EvalSemProve.AllowUserToAddRows = false;
            this.DGV_EvalSemProve.AllowUserToDeleteRows = false;
            this.DGV_EvalSemProve.AllowUserToResizeRows = false;
            this.DGV_EvalSemProve.ColumnHeadersHeight = 34;
            this.DGV_EvalSemProve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoProve,
            this.Descripcion,
            this.Articulo,
            this.Orden,
            this.Desviad,
            this.DescArticulo,
            this.Certificado,
            this.Envase,
            this.Informe,
            this.Cantidad,
            this.FechaEntrega,
            this.FechaPosibleEntrega,
            this.Aprobado,
            this.Desvio,
            this.Rechazado,
            this.Atraso,
            this.Liberada,
            this.Laudo,
            this.Devuelta});
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_EvalSemProve.DefaultCellStyle = dataGridViewCellStyle55;
            this.DGV_EvalSemProve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_EvalSemProve.Location = new System.Drawing.Point(0, 39);
            this.DGV_EvalSemProve.Name = "DGV_EvalSemProve";
            this.DGV_EvalSemProve.RowHeadersWidth = 10;
            this.DGV_EvalSemProve.Size = new System.Drawing.Size(920, 419);
            this.DGV_EvalSemProve.TabIndex = 10;
            // 
            // CodigoProve
            // 
            this.CodigoProve.DataPropertyName = "CodProve";
            this.CodigoProve.HeaderText = "CodigoProve";
            this.CodigoProve.Name = "CodigoProve";
            this.CodigoProve.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "DescProve";
            this.Descripcion.HeaderText = "Proveedor";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = false;
            this.Descripcion.Width = 130;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Articulo";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Width = 70;
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Orden.DefaultCellStyle = dataGridViewCellStyle45;
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.Width = 40;
            // 
            // Desviad
            // 
            this.Desviad.DataPropertyName = "Clave";
            this.Desviad.HeaderText = "Clave";
            this.Desviad.Name = "Desviad";
            this.Desviad.Visible = false;
            this.Desviad.Width = 70;
            // 
            // DescArticulo
            // 
            this.DescArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescArticulo.HeaderText = "Descripcion";
            this.DescArticulo.Name = "DescArticulo";
            // 
            // Certificado
            // 
            this.Certificado.DataPropertyName = "Certifica";
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Certificado.DefaultCellStyle = dataGridViewCellStyle46;
            this.Certificado.HeaderText = "Certificado";
            this.Certificado.Name = "Certificado";
            this.Certificado.Width = 60;
            // 
            // Envase
            // 
            this.Envase.DataPropertyName = "Envase";
            this.Envase.HeaderText = "Envase";
            this.Envase.Name = "Envase";
            this.Envase.Width = 60;
            // 
            // Informe
            // 
            this.Informe.DataPropertyName = "Informe";
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Informe.DefaultCellStyle = dataGridViewCellStyle47;
            this.Informe.HeaderText = "Informe";
            this.Informe.Name = "Informe";
            this.Informe.Width = 50;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle48;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 50;
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.DataPropertyName = "fecha";
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FechaEntrega.DefaultCellStyle = dataGridViewCellStyle49;
            this.FechaEntrega.HeaderText = "Fecha Ent.";
            this.FechaEntrega.Name = "FechaEntrega";
            this.FechaEntrega.Width = 70;
            // 
            // FechaPosibleEntrega
            // 
            this.FechaPosibleEntrega.DataPropertyName = "Fecha2";
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FechaPosibleEntrega.DefaultCellStyle = dataGridViewCellStyle50;
            this.FechaPosibleEntrega.HeaderText = "Fecha Posib. Ent.";
            this.FechaPosibleEntrega.Name = "FechaPosibleEntrega";
            this.FechaPosibleEntrega.Width = 90;
            // 
            // Aprobado
            // 
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Aprobado.DefaultCellStyle = dataGridViewCellStyle51;
            this.Aprobado.HeaderText = "Aprobado";
            this.Aprobado.Name = "Aprobado";
            // 
            // Desvio
            // 
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Desvio.DefaultCellStyle = dataGridViewCellStyle52;
            this.Desvio.HeaderText = "Desvio";
            this.Desvio.Name = "Desvio";
            this.Desvio.Width = 50;
            // 
            // Rechazado
            // 
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Rechazado.DefaultCellStyle = dataGridViewCellStyle53;
            this.Rechazado.HeaderText = "Rechazado";
            this.Rechazado.Name = "Rechazado";
            // 
            // Atraso
            // 
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Atraso.DefaultCellStyle = dataGridViewCellStyle54;
            this.Atraso.HeaderText = "Atraso";
            this.Atraso.Name = "Atraso";
            this.Atraso.Width = 50;
            // 
            // Liberada
            // 
            this.Liberada.DataPropertyName = "Liberada";
            this.Liberada.HeaderText = "Liberada";
            this.Liberada.Name = "Liberada";
            this.Liberada.Width = 60;
            // 
            // Laudo
            // 
            this.Laudo.DataPropertyName = "Laudo";
            this.Laudo.HeaderText = "Laudo";
            this.Laudo.Name = "Laudo";
            this.Laudo.Width = 80;
            // 
            // Devuelta
            // 
            this.Devuelta.DataPropertyName = "Devuelta";
            this.Devuelta.HeaderText = "Devuelta";
            this.Devuelta.Name = "Devuelta";
            this.Devuelta.Width = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 64);
            this.panel2.TabIndex = 11;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Imprimir;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(434, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(53, 45);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // DetalleItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(920, 458);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DGV_EvalSemProve);
            this.Controls.Add(this.panel1);
            this.Name = "DetalleItems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DetalleItems_Load);
            this.ResizeBegin += new System.EventHandler(this.DetalleItemsEnvases_ResizeEnd);
            this.ResizeEnd += new System.EventHandler(this.DetalleItemsEnvases_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DetalleItemsEnvases_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EvalSemProve)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBCamion;
        private System.Windows.Forms.DataGridView DGV_EvalSemProve;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desviad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Envase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPosibleEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aprobado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rechazado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Atraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Liberada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Laudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Devuelta;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnImprimir;
    }
}